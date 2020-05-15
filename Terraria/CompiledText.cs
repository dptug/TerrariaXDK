using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Terraria
{
	public sealed class CompiledText
	{
		public enum MarkupType
		{
			Plain,
			Html
		}

		[Flags]
		public enum Attributes
		{
			None = 0x0,
			Italic = 0x1,
			Bold = 0x2,
			Highlighted = 0x4,
			Center = 0x8,
			Right = 0x10,
			TextStyle = 0x7,
			Alignment = 0x18
		}

		public class Style
		{
			public Color ForegroundColor;

			public SpriteFont Font;

			public Attributes TextAttributes;

			public Style(SpriteFont font)
			{
				ForegroundColor = Color.Transparent;
				Font = font;
				TextAttributes = Attributes.None;
			}

			public Style(Style copy)
			{
				ForegroundColor = copy.ForegroundColor;
				Font = copy.Font;
				TextAttributes = copy.TextAttributes;
			}
		}

		private sealed class Segment
		{
			public string SegmentText;

			public short SourceCharIndex;

			public short SourceCharLength;

			public Rectangle Position;

			public Style Style;
		}

		private enum TagType
		{
			None,
			Bold,
			Italic,
			Underline,
			Link,
			Center,
			Right,
			Font,
			Paragraph,
			Highlighted,
			FontTitle
		}

		private sealed class OpenTag
		{
			public TagType Tag;

			public Style Style;

			public OpenTag(TagType tag, Style style)
			{
				Tag = tag;
				Style = style;
			}
		}

		public const short COMPILEDTEXT_WIDTHOFFSET = 5;

		public const short COMPILEDTEXT_HEIGHTOFFSET = 12;

		private const int ParagraphBreakHeight = 1;

		public string Text;

		public short Width;

		public short Height;

		private List<Segment> _segments = new List<Segment>();

		private Stack<OpenTag> _tags = new Stack<OpenTag>();

		public CompiledText(string text, int wrapWidth, Style style, MarkupType markupType = MarkupType.Html)
		{
			_tags.Push(new OpenTag(TagType.None, style));
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			Text = text;
			Width = 0;
			Height = 0;
			int i = 0;
			while (i < text.Length)
			{
				if (markupType == MarkupType.Html && text[i] == '<' && text[i + 1] == '/')
				{
					i += 2;
					skipTag(text, markupType, ref i, closingTag: true, out TagType tagType, out Color? _);
					while (_tags.Count > 1 && _tags.Pop().Tag != tagType)
					{
					}
					continue;
				}
				if (markupType == MarkupType.Html && text[i] == '<')
				{
					i++;
					skipTag(text, markupType, ref i, closingTag: false, out TagType tagType2, out Color? newColor2);
					Style style2 = new Style(_tags.Peek().Style);
					switch (tagType2)
					{
					case TagType.Bold:
						style2.TextAttributes |= Attributes.Bold;
						break;
					case TagType.Center:
						style2.TextAttributes |= Attributes.Center;
						break;
					case TagType.Font:
						style2.ForegroundColor = newColor2.Value;
						break;
					case TagType.Italic:
						style2.TextAttributes |= Attributes.Italic;
						break;
					case TagType.Highlighted:
						style2.TextAttributes |= Attributes.Highlighted;
						break;
					case TagType.Right:
						style2.TextAttributes |= Attributes.Right;
						break;
					case TagType.FontTitle:
						style2.Font = UI.fontBig;
						break;
					}
					if (tagType2 != TagType.Paragraph)
					{
						_tags.Push(new OpenTag(tagType2, style2));
						continue;
					}
					num2 += Math.Max(UI.LineSpacing(_tags.Peek().Style.Font), num3) + 1;
					num = 0;
					num3 = 0;
					continue;
				}
				int num4 = i;
				int num5 = 0;
				while (i < text.Length && !isEol(text[i]) && (markupType != MarkupType.Html || text[i] != '<'))
				{
					i++;
					num5++;
				}
				if (wrapWidth == 0)
				{
					Vector2 vector = UI.MeasureString(_tags.Peek().Style.Font, text.Substring(num4, num5));
					vector.X += UI.Spacing(_tags.Peek().Style.Font);
					vector.Y = UI.LineSpacing(_tags.Peek().Style.Font);
					addSegment(text, num4, num5, _tags.Peek().Style, num, num2, (int)vector.X, (int)vector.Y);
					num += (int)vector.X;
					num3 = Math.Max(num3, (int)vector.Y);
				}
				else
				{
					while (num5 != 0)
					{
						int num6;
						if ((num6 = AnimationUtils.SqueezeText(_tags.Peek().Style.Font, text.Substring(num4, num5), wrapWidth - num, AnimationUtils.SqueezeTextFlags.WordBreak)) == 0 && num != 0)
						{
							num2 += Math.Max(num3, UI.LineSpacing(_tags.Peek().Style.Font));
							num = 0;
							num3 = 0;
							num6 = AnimationUtils.SqueezeText(_tags.Peek().Style.Font, text.Substring(num4, num5), wrapWidth - num, AnimationUtils.SqueezeTextFlags.WordBreak);
						}
						if (num6 == 0)
						{
							num6 = AnimationUtils.SqueezeText(_tags.Peek().Style.Font, text.Substring(num4, num5), wrapWidth - num, AnimationUtils.SqueezeTextFlags.NoWordBreak);
						}
						if (num6 == 0)
						{
							break;
						}
						Vector2 vector2 = UI.MeasureString(_tags.Peek().Style.Font, text.Substring(num4, num6));
						vector2.X += UI.Spacing(_tags.Peek().Style.Font);
						vector2.Y = UI.LineSpacing(_tags.Peek().Style.Font);
						addSegment(text, num4, num6, _tags.Peek().Style, num, num2, (int)vector2.X, (int)vector2.Y);
						num += (int)vector2.X;
						num3 = Math.Max(num3, (int)vector2.Y);
						if (num6 < num5)
						{
							num2 += Math.Max(num3, UI.LineSpacing(_tags.Peek().Style.Font));
							num = 0;
							num3 = 0;
						}
						num4 += num6;
						num5 -= num6;
						while (num5 != 0 && text[num4] == ' ')
						{
							num5--;
							num4++;
						}
					}
				}
				for (; i < text.Length && isEol(text[i]); i++)
				{
					if (text[i] == '\n')
					{
						num2 += Math.Max(num3, UI.LineSpacing(_tags.Peek().Style.Font));
						num = 0;
						num3 = 0;
					}
				}
			}
			if (wrapWidth == 0)
			{
				return;
			}
			long num7 = 0L;
			int num8 = -1;
			int num9 = -1;
			Attributes attributes = Attributes.None;
			for (int num10 = 0; num10 < _segments.Count; num10 = num9)
			{
				num9 = num10 + 1;
				if ((_segments[num10].Style.TextAttributes & Attributes.Alignment) != 0)
				{
					if (num8 == -1)
					{
						num8 = num10;
						num7 = _segments[num10].Position.Y;
						attributes = (_segments[num10].Style.TextAttributes & Attributes.Alignment);
					}
					if (num9 == _segments.Count || _segments[num9].Position.Y != num7 || (_segments[num9].Style.TextAttributes & Attributes.Alignment) != attributes)
					{
						int num11 = _segments[num10].Position.Right - _segments[num8].Position.X;
						int num12 = (wrapWidth - num11) / (((attributes & Attributes.Center) == 0) ? 1 : 2);
						for (int j = num8; j != num9; j++)
						{
							_segments[j].Position.X += num12;
						}
						num8 = -1;
					}
				}
			}
		}

		public void Draw(SpriteBatch target, Rectangle clip, Color defaultTextColor, Color defaultAccentColor)
		{
			if (clip.Width != 0 && clip.Height != 0)
			{
				foreach (Segment segment in _segments)
				{
					Color color = segment.Style.ForegroundColor;
					if ((segment.Style.TextAttributes & Attributes.Italic) != 0)
					{
						color = defaultAccentColor;
					}
					else if ((segment.Style.TextAttributes & Attributes.Highlighted) != 0)
					{
						color = new Color(64, 255, 255, 255);
					}
					if (color == Color.Transparent)
					{
						color = defaultTextColor;
					}
					if (segment.Position.X < clip.Width && segment.Position.Y < clip.Height)
					{
						UI.DrawStringLT(segment.Style.Font, segment.SegmentText, clip.X + segment.Position.X, clip.Y + segment.Position.Y, color);
						if ((segment.Style.TextAttributes & Attributes.Bold) != 0)
						{
							UI.DrawStringLT(segment.Style.Font, segment.SegmentText, clip.X + segment.Position.X + 1, clip.Y + segment.Position.Y, color);
						}
					}
				}
			}
		}

		public int CharHitTest(Point pt, bool fuzzy)
		{
			int num = -1;
			int num2 = 0;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < _segments.Count; i++)
			{
				Segment segment = _segments[i];
				bool flag = i + 1 < _segments.Count && segment.Position.Y != _segments[i + 1].Position.Y;
				if (segment.Position.Contains(pt))
				{
					return segment.SourceCharIndex + AnimationUtils.SqueezeText(segment.Style.Font, segment.SegmentText, pt.X - segment.Position.Left, AnimationUtils.SqueezeTextFlags.NoWordBreak);
				}
				if (fuzzy)
				{
					if (segment.Position.Contains(new Point(segment.Position.X, pt.Y)))
					{
						num4 = ((pt.X >= segment.Position.Left) ? (segment.SourceCharIndex + segment.SourceCharLength - (flag ? 1 : 0)) : ((num3 == segment.Position.Top) ? num4 : segment.SourceCharIndex));
						num3 = segment.Position.Top;
					}
					else if (segment.Position.Top <= pt.Y)
					{
						num2 = ((pt.Y >= segment.Position.Top) ? (segment.SourceCharIndex + segment.SourceCharLength - (flag ? 1 : 0)) : ((num == segment.Position.Top) ? num2 : segment.SourceCharIndex));
						num = segment.Position.Top;
					}
				}
			}
			if (fuzzy)
			{
				if (num4 == -1)
				{
					return num2;
				}
				return num4;
			}
			return -1;
		}

		public Point CharFind(int charIndex)
		{
			for (int i = 0; i < _segments.Count; i++)
			{
				Segment segment = _segments[i];
				if (i + 1 == _segments.Count || _segments[i + 1].SourceCharIndex > charIndex)
				{
					int num = segment.Position.X;
					int y = segment.Position.Y;
					if (charIndex > segment.SourceCharIndex)
					{
						num += (int)UI.MeasureString(segment.Style.Font, segment.SegmentText.Substring(0, charIndex - segment.SourceCharIndex)).X;
					}
					return new Point(num, y);
				}
			}
			return new Point(-1, -1);
		}

		private void skipTag(string text, MarkupType markupType, ref int ich, bool closingTag, out TagType tagType, out Color? newColor)
		{
			switch (text[ich])
			{
			case 'B':
			case 'b':
				if (text[ich + 1] == 'r' || text[ich + 1] == 'R')
				{
					tagType = TagType.Paragraph;
				}
				else
				{
					tagType = TagType.Bold;
				}
				break;
			case 'I':
			case 'i':
				tagType = TagType.Italic;
				break;
			case 'C':
			case 'c':
				tagType = TagType.Center;
				break;
			case 'F':
			case 'f':
				tagType = TagType.Font;
				break;
			case 'R':
			case 'r':
				tagType = TagType.Right;
				break;
			case 'P':
			case 'p':
				tagType = TagType.Paragraph;
				break;
			case 'H':
			case 'h':
				tagType = TagType.Highlighted;
				break;
			case 'T':
			case 't':
				tagType = TagType.FontTitle;
				break;
			default:
				tagType = TagType.None;
				break;
			}
			newColor = null;
			while (text[ich] != '=' && text[ich] != ' ' && text[ich] != '>')
			{
				ich++;
			}
			if (tagType == TagType.Font && markupType == MarkupType.Html && text[ich] == ' ' && text[ich + 1] == 'c')
			{
				while (text[ich] != '=' && text[ich] != '>')
				{
					ich++;
				}
			}
			if (tagType == TagType.Font && text[ich] == '=')
			{
				ich++;
				newColor = AnimationUtils.StringToColor(popQuotedWord(text, ref ich, '>', stripQuotes: true));
			}
			_ = text[ich];
			_ = 62;
			ich++;
		}

		private string popQuotedWord(string text, ref int ich, char stopChar, bool stripQuotes)
		{
			int num = ich;
			char c = text[ich];
			string result;
			if (c == '"' || c == '\'')
			{
				do
				{
					ich++;
				}
				while (ich < text.Length && text[ich] != c);
				if (ich != text.Length)
				{
					_ = text[ich];
				}
				ich++;
				result = ((!stripQuotes) ? text.Substring(num, ich - num) : text.Substring(num + 1, ich - num - 2));
			}
			else
			{
				while (ich < text.Length && text[ich] != stopChar && !isWhiteEol(text[ich]))
				{
					ich++;
				}
				result = text.Substring(num, ich - num);
			}
			while (ich < text.Length && isWhiteEol(text[ich]))
			{
				ich++;
			}
			return result;
		}

		private void addSegment(string text, int startIndex, int length, Style style, int xx, int yy, int cx, int cy)
		{
			Segment segment = new Segment();
			segment.SegmentText = text.Substring(startIndex, length);
			segment.SourceCharIndex = (short)startIndex;
			segment.SourceCharLength = (short)length;
			segment.Position = new Rectangle(xx, yy, cx, cy);
			segment.Style = style;
			_segments.Add(segment);
			Width = (short)Math.Max(Width, segment.Position.Right + 5);
			Height = (short)Math.Max(Height, segment.Position.Bottom + 12);
		}

		private bool isWhiteEol(char ch)
		{
			if (ch != ' ' && ch != '\t' && ch != '\r')
			{
				return ch == '\n';
			}
			return true;
		}

		private bool isEol(char ch)
		{
			if (ch != '\r')
			{
				return ch == '\n';
			}
			return true;
		}
	}
}
