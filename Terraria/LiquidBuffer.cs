// Type: Terraria.LiquidBuffer
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

namespace Terraria
{
  public struct LiquidBuffer
  {
    public const int MAX_LIQUID_BUFFER = 8192;
    public static int numLiquidBuffer;
    public short x;
    public short y;

    public static void AddBuffer(int x, int y)
    {
      if (LiquidBuffer.numLiquidBuffer == 8191 || Main.tile[x, y].checkingLiquid != 0)
        return;
      Main.tile[x, y].checkingLiquid = 64;
      Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].x = (short) x;
      Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].y = (short) y;
      ++LiquidBuffer.numLiquidBuffer;
    }
  }
}
