using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria;

public static class AnimationUtils
{
	public enum SqueezeTextFlags
	{
		NoWordBreak,
		WordBreak
	}

	public static Color StringToColor(string text)
	{
		if (text.Length == 7 && text[0] == '#')
		{
			int r = HexValue(text[1]) * 16 + HexValue(text[2]);
			int g = HexValue(text[3]) * 16 + HexValue(text[4]);
			int b = HexValue(text[5]) * 16 + HexValue(text[6]);
			return new Color(r, g, b);
		}
		if (text.Length >= 11 && text[0] == '{' && text[text.Length - 1] == '}')
		{
			int r2 = 0;
			int g2 = 0;
			int b2 = 0;
			int a = 0;
			int i = 1;
			while (i + 2 < text.Length && (char.ToLower(text[i]) == 'a' || char.ToLower(text[i]) == 'r' || char.ToLower(text[i]) == 'g' || char.ToLower(text[i]) == 'b') && text[i + 1] == ':')
			{
				char c = char.ToLower(text[i]);
				int num = 0;
				for (i += 2; char.IsDigit(text[i]); i++)
				{
					num = num * 10 + (text[i] - 48);
				}
				switch (c)
				{
				case 'r':
					r2 = num;
					break;
				case 'g':
					g2 = num;
					break;
				case 'b':
					b2 = num;
					break;
				default:
					a = num;
					break;
				}
				for (; text[i] == ' '; i++)
				{
				}
			}
			return new Color(r2, g2, b2, a);
		}
		return Color.White;
	}

	private static int HexValue(char ch)
	{
		if (ch < '0' || ch > '9')
		{
			if (ch < 'a' || ch > 'z')
			{
				if (ch < 'A' || ch > 'Z')
				{
					return 0;
				}
				return ch - 65 + 10;
			}
			return ch - 97 + 10;
		}
		return ch - 48;
	}

	public static int SqueezeText(SpriteFont font, string text, int width, SqueezeTextFlags flags)
	{
		if (width <= 0 || text.Length == 0)
		{
			return 0;
		}
		if ((float)(int)UI.MeasureString(font, text).X + UI.Spacing(font) <= (float)width)
		{
			return text.Length;
		}
		int num = 0;
		int num2 = text.Length;
		do
		{
			int num3 = num + (num2 - num + 1 >> 1);
			if ((float)(int)UI.MeasureString(font, text.Substring(0, num3)).X + UI.Spacing(font) <= (float)width)
			{
				num = num3;
			}
			else
			{
				num2 = num3;
			}
		}
		while (num2 > num + 1);
		if ((flags & SqueezeTextFlags.WordBreak) != 0)
		{
			while (num >= 1)
			{
				char c = text[num - 1];
				if (c == ' ' || c == '\t' || c == '\r' || c == '\n')
				{
					break;
				}
				num--;
			}
		}
		return num;
	}
}
