// Type: Terraria.Vector2i
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

namespace Terraria
{
  public struct Vector2i
  {
    public int X;
    public int Y;

    public Vector2i(int x, int y)
    {
      this.X = (int) (short) x;
      this.Y = (int) (short) y;
    }
  }
}
