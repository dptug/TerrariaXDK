// Type: Terraria.Dust
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;

namespace Terraria
{
  public struct Dust
  {
    public const int NUM_GLOBAL = 256;
    public const int NUM_LOCAL = 128;
    public byte active;
    public bool noGravity;
    public bool noLight;
    public ushort type;
    public short alpha;
    public Color color;
    public float fadeIn;
    public float rotation;
    public float scale;
    public Rectangle frame;
    public Vector2 position;
    public Vector2 velocity;

    public void Init()
    {
      this.active = (byte) 0;
      this.noGravity = false;
      this.noLight = false;
      this.type = (ushort) 0;
      this.fadeIn = 0.0f;
    }

    public void GetAlpha(ref Color newColor)
    {
      if ((int) this.type == 6 || (int) this.type == 75 || ((int) this.type == 20 || (int) this.type == 21))
        newColor.A = (byte) 25;
      else if (((int) this.type == 68 || (int) this.type == 70) && this.noGravity)
        newColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
      else if ((int) this.type == 66)
        newColor.A = (byte) 0;
      else if ((int) this.type == 71)
        newColor = new Color(200, 200, 200, 0);
      else if ((int) this.type == 72)
      {
        newColor = new Color(200, 200, 200, 200);
      }
      else
      {
        float num = (float) ((int) byte.MaxValue - (int) this.alpha) * 0.003921569f;
        if ((int) this.type == 15 || (int) this.type == 29 || ((int) this.type == 35 || (int) this.type == 41) || ((int) this.type == 44 || (int) this.type == 27 || ((int) this.type == 45 || (int) this.type == 55)) || ((int) this.type == 56 || (int) this.type == 57 || ((int) this.type == 58 || (int) this.type == 73) || (int) this.type == 74))
          num = (float) (((double) num + 3.0) * 0.25);
        else if ((int) this.type == 43)
          num = (float) (((double) num + 9.0) * 0.100000001490116);
        newColor.R = (byte) ((double) newColor.R * (double) num);
        newColor.G = (byte) ((double) newColor.G * (double) num);
        newColor.B = (byte) ((double) newColor.B * (double) num);
        newColor.A -= (byte) this.alpha;
      }
    }

    public void GetColor(ref Color newColor)
    {
      int r = (int) this.color.R - ((int) byte.MaxValue - (int) newColor.R);
      int g = (int) this.color.G - ((int) byte.MaxValue - (int) newColor.G);
      int b = (int) this.color.B - ((int) byte.MaxValue - (int) newColor.B);
      int a = (int) this.color.A - ((int) byte.MaxValue - (int) newColor.A);
      newColor = new Color(r, g, b, a);
    }
  }
}
