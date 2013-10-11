// Type: Terraria.AnimationUtils
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
  public static class AnimationUtils
  {
    public static Color StringToColor(string text)
    {
      if (text.Length == 7 && (int) text[0] == 35)
        return new Color(AnimationUtils.HexValue(text[1]) * 16 + AnimationUtils.HexValue(text[2]), AnimationUtils.HexValue(text[3]) * 16 + AnimationUtils.HexValue(text[4]), AnimationUtils.HexValue(text[5]) * 16 + AnimationUtils.HexValue(text[6]));
      if (text.Length < 11 || (int) text[0] != 123 || (int) text[text.Length - 1] != 125)
        return Color.White;
      int r = 0;
      int g = 0;
      int b = 0;
      int a = 0;
      int index = 1;
      while (index + 2 < text.Length && ((int) char.ToLower(text[index]) == 97 || (int) char.ToLower(text[index]) == 114 || ((int) char.ToLower(text[index]) == 103 || (int) char.ToLower(text[index]) == 98)) && (int) text[index + 1] == 58)
      {
        char ch = char.ToLower(text[index]);
        int num = 0;
        index += 2;
        for (; char.IsDigit(text[index]); ++index)
          num = num * 10 + ((int) text[index] - 48);
        if ((int) ch == 114)
          r = num;
        else if ((int) ch == 103)
          g = num;
        else if ((int) ch == 98)
          b = num;
        else
          a = num;
        while ((int) text[index] == 32)
          ++index;
      }
      return new Color(r, g, b, a);
    }

    private static int HexValue(char ch)
    {
      if ((int) ch >= 48 && (int) ch <= 57)
        return (int) ch - 48;
      if ((int) ch >= 97 && (int) ch <= 122)
        return (int) ch - 97 + 10;
      if ((int) ch < 65 || (int) ch > 90)
        return 0;
      else
        return (int) ch - 65 + 10;
    }

    public static int SqueezeText(SpriteFont font, string text, int width, AnimationUtils.SqueezeTextFlags flags)
    {
      if (width <= 0 || text.Length == 0)
        return 0;
      if ((double) (int) UI.MeasureString(font, text).X + (double) UI.Spacing(font) <= (double) width)
        return text.Length;
      int num1 = 0;
      int num2 = text.Length;
      do
      {
        int length = num1 + (num2 - num1 + 1 >> 1);
        if ((double) (int) UI.MeasureString(font, text.Substring(0, length)).X + (double) UI.Spacing(font) <= (double) width)
          num1 = length;
        else
          num2 = length;
      }
      while (num2 > num1 + 1);
      if ((flags & AnimationUtils.SqueezeTextFlags.WordBreak) != AnimationUtils.SqueezeTextFlags.NoWordBreak)
      {
        for (; num1 >= 1; --num1)
        {
          switch (text[num1 - 1])
          {
            case ' ':
            case '\t':
            case '\r':
            case '\n':
              goto label_13;
            default:
              goto default;
          }
        }
      }
label_13:
      return num1;
    }

    public enum SqueezeTextFlags
    {
      NoWordBreak,
      WordBreak,
    }
  }
}
