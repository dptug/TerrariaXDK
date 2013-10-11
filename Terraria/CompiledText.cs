// Type: Terraria.CompiledText
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Terraria
{
  public sealed class CompiledText
  {
    private List<CompiledText.Segment> _segments = new List<CompiledText.Segment>();
    private Stack<CompiledText.OpenTag> _tags = new Stack<CompiledText.OpenTag>();
    public const short COMPILEDTEXT_WIDTHOFFSET = (short) 5;
    public const short COMPILEDTEXT_HEIGHTOFFSET = (short) 12;
    private const int ParagraphBreakHeight = 1;
    public string Text;
    public short Width;
    public short Height;

    public CompiledText(string text, int wrapWidth, CompiledText.Style style, CompiledText.MarkupType markupType = CompiledText.MarkupType.Html)
    {
      this._tags.Push(new CompiledText.OpenTag(CompiledText.TagType.None, style));
      int xx = 0;
      int yy = 0;
      int num1 = 0;
      this.Text = text;
      this.Width = (short) 0;
      this.Height = (short) 0;
      int ich = 0;
label_38:
      while (ich < text.Length)
      {
        if (markupType == CompiledText.MarkupType.Html && (int) text[ich] == 60 && (int) text[ich + 1] == 47)
        {
          ich += 2;
          CompiledText.TagType tagType;
          Color? newColor;
          this.skipTag(text, markupType, ref ich, true, out tagType, out newColor);
          do
            ;
          while (this._tags.Count > 1 && this._tags.Pop().Tag != tagType);
        }
        else if (markupType == CompiledText.MarkupType.Html && (int) text[ich] == 60)
        {
          ++ich;
          CompiledText.TagType tagType;
          Color? newColor;
          this.skipTag(text, markupType, ref ich, false, out tagType, out newColor);
          CompiledText.Style style1 = new CompiledText.Style(this._tags.Peek().Style);
          switch (tagType)
          {
            case CompiledText.TagType.Bold:
              style1.TextAttributes |= CompiledText.Attributes.Bold;
              break;
            case CompiledText.TagType.Italic:
              style1.TextAttributes |= CompiledText.Attributes.Italic;
              break;
            case CompiledText.TagType.Center:
              style1.TextAttributes |= CompiledText.Attributes.Center;
              break;
            case CompiledText.TagType.Right:
              style1.TextAttributes |= CompiledText.Attributes.Right;
              break;
            case CompiledText.TagType.Font:
              style1.ForegroundColor = newColor.Value;
              break;
            case CompiledText.TagType.Highlighted:
              style1.TextAttributes |= CompiledText.Attributes.Highlighted;
              break;
            case CompiledText.TagType.FontTitle:
              style1.Font = UI.fontBig;
              break;
          }
          if (tagType != CompiledText.TagType.Paragraph)
          {
            this._tags.Push(new CompiledText.OpenTag(tagType, style1));
          }
          else
          {
            yy += Math.Max(UI.LineSpacing(this._tags.Peek().Style.Font), num1) + 1;
            xx = 0;
            num1 = 0;
          }
        }
        else
        {
          int startIndex = ich;
          int length1 = 0;
          while (ich < text.Length && !this.isEol(text[ich]) && (markupType != CompiledText.MarkupType.Html || (int) text[ich] != 60))
          {
            ++ich;
            ++length1;
          }
          if (wrapWidth == 0)
          {
            Vector2 vector2 = UI.MeasureString(this._tags.Peek().Style.Font, text.Substring(startIndex, length1));
            vector2.X += UI.Spacing(this._tags.Peek().Style.Font);
            vector2.Y = (float) UI.LineSpacing(this._tags.Peek().Style.Font);
            this.addSegment(text, startIndex, length1, this._tags.Peek().Style, xx, yy, (int) vector2.X, (int) vector2.Y);
            xx += (int) vector2.X;
            num1 = Math.Max(num1, (int) vector2.Y);
          }
          else
          {
label_32:
            while (length1 != 0)
            {
              int length2;
              if ((length2 = AnimationUtils.SqueezeText(this._tags.Peek().Style.Font, text.Substring(startIndex, length1), wrapWidth - xx, AnimationUtils.SqueezeTextFlags.WordBreak)) == 0 && xx != 0)
              {
                yy += Math.Max(num1, UI.LineSpacing(this._tags.Peek().Style.Font));
                xx = 0;
                num1 = 0;
                length2 = AnimationUtils.SqueezeText(this._tags.Peek().Style.Font, text.Substring(startIndex, length1), wrapWidth - xx, AnimationUtils.SqueezeTextFlags.WordBreak);
              }
              if (length2 == 0)
                length2 = AnimationUtils.SqueezeText(this._tags.Peek().Style.Font, text.Substring(startIndex, length1), wrapWidth - xx, AnimationUtils.SqueezeTextFlags.NoWordBreak);
              if (length2 != 0)
              {
                Vector2 vector2 = UI.MeasureString(this._tags.Peek().Style.Font, text.Substring(startIndex, length2));
                vector2.X += UI.Spacing(this._tags.Peek().Style.Font);
                vector2.Y = (float) UI.LineSpacing(this._tags.Peek().Style.Font);
                this.addSegment(text, startIndex, length2, this._tags.Peek().Style, xx, yy, (int) vector2.X, (int) vector2.Y);
                xx += (int) vector2.X;
                num1 = Math.Max(num1, (int) vector2.Y);
                if (length2 < length1)
                {
                  yy += Math.Max(num1, UI.LineSpacing(this._tags.Peek().Style.Font));
                  xx = 0;
                  num1 = 0;
                }
                startIndex += length2;
                length1 -= length2;
                while (true)
                {
                  if (length1 != 0 && (int) text[startIndex] == 32)
                  {
                    --length1;
                    ++startIndex;
                  }
                  else
                    goto label_32;
                }
              }
              else
                break;
            }
          }
          while (true)
          {
            if (ich < text.Length && this.isEol(text[ich]))
            {
              if ((int) text[ich] == 10)
              {
                yy += Math.Max(num1, UI.LineSpacing(this._tags.Peek().Style.Font));
                xx = 0;
                num1 = 0;
              }
              ++ich;
            }
            else
              goto label_38;
          }
        }
      }
      if (wrapWidth == 0)
        return;
      long num2 = 0L;
      int index1 = -1;
      CompiledText.Attributes attributes = CompiledText.Attributes.None;
      for (int index2 = 0; index2 < this._segments.Count; {
        int index3;
        index2 = index3;
      }
      )
      {
        index3 = index2 + 1;
        if ((this._segments[index2].Style.TextAttributes & CompiledText.Attributes.Alignment) != CompiledText.Attributes.None)
        {
          if (index1 == -1)
          {
            index1 = index2;
            num2 = (long) this._segments[index2].Position.Y;
            attributes = this._segments[index2].Style.TextAttributes & CompiledText.Attributes.Alignment;
          }
          if (index3 == this._segments.Count || (long) this._segments[index3].Position.Y != num2 || (this._segments[index3].Style.TextAttributes & CompiledText.Attributes.Alignment) != attributes)
          {
            int num3 = this._segments[index2].Position.Right - this._segments[index1].Position.X;
            int num4 = (wrapWidth - num3) / ((attributes & CompiledText.Attributes.Center) != CompiledText.Attributes.None ? 2 : 1);
            for (int index3 = index1; index3 != index3; ++index3)
              this._segments[index3].Position.X += num4;
            index1 = -1;
          }
        }
      }
    }

    public void Draw(SpriteBatch target, Rectangle clip, Color defaultTextColor, Color defaultAccentColor)
    {
      if (clip.Width == 0 || clip.Height == 0)
        return;
      foreach (CompiledText.Segment segment in this._segments)
      {
        Color c = segment.Style.ForegroundColor;
        if ((segment.Style.TextAttributes & CompiledText.Attributes.Italic) != CompiledText.Attributes.None)
          c = defaultAccentColor;
        else if ((segment.Style.TextAttributes & CompiledText.Attributes.Highlighted) != CompiledText.Attributes.None)
          c = new Color(64, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        if (c == Color.Transparent)
          c = defaultTextColor;
        if (segment.Position.X < clip.Width && segment.Position.Y < clip.Height)
        {
          UI.DrawStringLT(segment.Style.Font, segment.SegmentText, clip.X + segment.Position.X, clip.Y + segment.Position.Y, c);
          if ((segment.Style.TextAttributes & CompiledText.Attributes.Bold) != CompiledText.Attributes.None)
            UI.DrawStringLT(segment.Style.Font, segment.SegmentText, clip.X + segment.Position.X + 1, clip.Y + segment.Position.Y, c);
        }
      }
    }

    public int CharHitTest(Point pt, bool fuzzy)
    {
      int num1 = -1;
      int num2 = 0;
      int num3 = -1;
      int num4 = -1;
      for (int index = 0; index < this._segments.Count; ++index)
      {
        CompiledText.Segment segment = this._segments[index];
        bool flag = index + 1 < this._segments.Count && segment.Position.Y != this._segments[index + 1].Position.Y;
        if (segment.Position.Contains(pt))
          return (int) segment.SourceCharIndex + AnimationUtils.SqueezeText(segment.Style.Font, segment.SegmentText, pt.X - segment.Position.Left, AnimationUtils.SqueezeTextFlags.NoWordBreak);
        if (fuzzy)
        {
          if (segment.Position.Contains(new Point(segment.Position.X, pt.Y)))
          {
            num4 = pt.X >= segment.Position.Left ? (int) segment.SourceCharIndex + (int) segment.SourceCharLength - (flag ? 1 : 0) : (num3 == segment.Position.Top ? num4 : (int) segment.SourceCharIndex);
            num3 = segment.Position.Top;
          }
          else if (segment.Position.Top <= pt.Y)
          {
            num2 = pt.Y >= segment.Position.Top ? (int) segment.SourceCharIndex + (int) segment.SourceCharLength - (flag ? 1 : 0) : (num1 == segment.Position.Top ? num2 : (int) segment.SourceCharIndex);
            num1 = segment.Position.Top;
          }
        }
      }
      if (!fuzzy)
        return -1;
      if (num4 == -1)
        return num2;
      else
        return num4;
    }

    public Point CharFind(int charIndex)
    {
      for (int index = 0; index < this._segments.Count; ++index)
      {
        CompiledText.Segment segment = this._segments[index];
        if (index + 1 == this._segments.Count || (int) this._segments[index + 1].SourceCharIndex > charIndex)
        {
          int x = segment.Position.X;
          int y = segment.Position.Y;
          if (charIndex > (int) segment.SourceCharIndex)
            x += (int) UI.MeasureString(segment.Style.Font, segment.SegmentText.Substring(0, charIndex - (int) segment.SourceCharIndex)).X;
          return new Point(x, y);
        }
      }
      return new Point(-1, -1);
    }

    private void skipTag(string text, CompiledText.MarkupType markupType, ref int ich, bool closingTag, out CompiledText.TagType tagType, out Color? newColor)
    {
      switch (text[ich])
      {
        case 'b':
        case 'B':
          tagType = (int) text[ich + 1] == 114 || (int) text[ich + 1] == 82 ? CompiledText.TagType.Paragraph : CompiledText.TagType.Bold;
          break;
        case 'c':
        case 'C':
          tagType = CompiledText.TagType.Center;
          break;
        case 'f':
        case 'F':
          tagType = CompiledText.TagType.Font;
          break;
        case 'h':
        case 'H':
          tagType = CompiledText.TagType.Highlighted;
          break;
        case 'i':
        case 'I':
          tagType = CompiledText.TagType.Italic;
          break;
        case 'p':
        case 'P':
          tagType = CompiledText.TagType.Paragraph;
          break;
        case 'r':
        case 'R':
          tagType = CompiledText.TagType.Right;
          break;
        case 't':
        case 'T':
          tagType = CompiledText.TagType.FontTitle;
          break;
        default:
          tagType = CompiledText.TagType.None;
          break;
      }
      newColor = new Color?();
      while ((int) text[ich] != 61 && (int) text[ich] != 32 && (int) text[ich] != 62)
        ++ich;
      if (tagType == CompiledText.TagType.Font && markupType == CompiledText.MarkupType.Html && ((int) text[ich] == 32 && (int) text[ich + 1] == 99))
      {
        while ((int) text[ich] != 61 && (int) text[ich] != 62)
          ++ich;
      }
      if (tagType == CompiledText.TagType.Font)
      {
        if ((int) text[ich] == 61)
        {
          ++ich;
          newColor = new Color?(AnimationUtils.StringToColor(this.popQuotedWord(text, ref ich, '>', true)));
        }
        else
        {
          int num1 = closingTag ? 1 : 0;
        }
      }
      int num2 = (int) text[ich];
      ++ich;
    }

    private string popQuotedWord(string text, ref int ich, char stopChar, bool stripQuotes)
    {
      int startIndex = ich;
      char ch = text[ich];
      string str;
      switch (ch)
      {
        case '"':
        case '\'':
          do
          {
            ++ich;
          }
          while (ich < text.Length && (int) text[ich] != (int) ch);
          if (ich != text.Length)
          {
            int num = (int) text[ich];
          }
          ++ich;
          str = !stripQuotes ? text.Substring(startIndex, ich - startIndex) : text.Substring(startIndex + 1, ich - startIndex - 2);
          break;
        default:
          while (ich < text.Length && (int) text[ich] != (int) stopChar && !this.isWhiteEol(text[ich]))
            ++ich;
          str = text.Substring(startIndex, ich - startIndex);
          break;
      }
      while (ich < text.Length && this.isWhiteEol(text[ich]))
        ++ich;
      return str;
    }

    private void addSegment(string text, int startIndex, int length, CompiledText.Style style, int xx, int yy, int cx, int cy)
    {
      CompiledText.Segment segment = new CompiledText.Segment();
      segment.SegmentText = text.Substring(startIndex, length);
      segment.SourceCharIndex = (short) startIndex;
      segment.SourceCharLength = (short) length;
      segment.Position = new Rectangle(xx, yy, cx, cy);
      segment.Style = style;
      this._segments.Add(segment);
      this.Width = (short) Math.Max((int) this.Width, segment.Position.Right + 5);
      this.Height = (short) Math.Max((int) this.Height, segment.Position.Bottom + 12);
    }

    private bool isWhiteEol(char ch)
    {
      if ((int) ch != 32 && (int) ch != 9 && (int) ch != 13)
        return (int) ch == 10;
      else
        return true;
    }

    private bool isEol(char ch)
    {
      if ((int) ch != 13)
        return (int) ch == 10;
      else
        return true;
    }

    public enum MarkupType
    {
      Plain,
      Html,
    }

    [System.Flags]
    public enum Attributes
    {
      None = 0,
      Italic = 1,
      Bold = 2,
      Highlighted = 4,
      Center = 8,
      Right = 16,
      TextStyle = Highlighted | Bold | Italic,
      Alignment = Right | Center,
    }

    public class Style
    {
      public Color ForegroundColor;
      public SpriteFont Font;
      public CompiledText.Attributes TextAttributes;

      public Style(SpriteFont font)
      {
        this.ForegroundColor = Color.Transparent;
        this.Font = font;
        this.TextAttributes = CompiledText.Attributes.None;
      }

      public Style(CompiledText.Style copy)
      {
        this.ForegroundColor = copy.ForegroundColor;
        this.Font = copy.Font;
        this.TextAttributes = copy.TextAttributes;
      }
    }

    private sealed class Segment
    {
      public string SegmentText;
      public short SourceCharIndex;
      public short SourceCharLength;
      public Rectangle Position;
      public CompiledText.Style Style;
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
      FontTitle,
    }

    private sealed class OpenTag
    {
      public CompiledText.TagType Tag;
      public CompiledText.Style Style;

      public OpenTag(CompiledText.TagType tag, CompiledText.Style style)
      {
        this.Tag = tag;
        this.Style = style;
      }
    }
  }
}
