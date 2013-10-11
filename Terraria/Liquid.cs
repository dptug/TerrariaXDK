// Type: Terraria.Liquid
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using System;

namespace Terraria
{
  public struct Liquid
  {
    public static int skipCount = 0;
    public static int stuckCount = 0;
    public static int stuckAmount = 0;
    private static int cycles = 7;
    public static bool stuck = false;
    public static bool quickFall = false;
    private static bool quickSettle = false;
    public static int panicCounter = 0;
    public static bool panicMode = false;
    public static int panicY = 0;
    public const int MAX_LIQUID = 4096;
    public static int numLiquid;
    private static int wetCounter;
    public short x;
    public short y;
    public short kill;
    public short delay;

    static Liquid()
    {
    }

    public void Init(int nx, int ny)
    {
      this.x = (short) nx;
      this.y = (short) ny;
      this.kill = (short) 0;
      this.delay = (short) 0;
    }

    public static void QuickSettleOn()
    {
      Liquid.quickSettle = true;
      Liquid.cycles = 1;
    }

    public static void QuickSettleOff()
    {
      Liquid.quickSettle = false;
      Liquid.cycles = 14;
    }

    public static void QuickWater(double verbose, int minY = 3, int maxY = -1, double startPercent = 0.0)
    {
      if (maxY == -1)
        maxY = (int) Main.maxTilesY - 3;
      for (int index1 = maxY; index1 >= minY; --index1)
      {
        UI.main.progress = (float) ((double) (maxY - index1) / (double) (maxY - minY + 1) * verbose + startPercent);
        for (int index2 = 0; index2 < 2; ++index2)
        {
          int num1 = 2;
          int num2 = (int) Main.maxTilesX - 2;
          int num3 = 1;
          if (index2 == 1)
          {
            num1 = num2;
            num2 = 2;
            num3 = -1;
          }
          int index3 = num1;
          while (index3 != num2)
          {
            int num4 = (int) Main.tile[index3, index1].liquid;
            if (num4 > 0)
            {
              Main.tile[index3, index1].liquid = (byte) 0;
              int num5 = -num3;
              bool flag1 = false;
              int x = index3;
              int y = index1;
              int num6 = (int) Main.tile[index3, index1].lava;
              bool flag2 = true;
              int num7 = 0;
              while (flag2 && x > 3 && (x < (int) Main.maxTilesX - 3 && y < (int) Main.maxTilesY - 3))
              {
                flag2 = false;
                while ((int) Main.tile[x, y + 1].liquid == 0 && y < (int) Main.maxTilesY - 5 && ((int) Main.tile[x, y + 1].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x, y + 1].type]))
                {
                  flag2 = true;
                  flag1 = true;
                  num5 = num3;
                  num7 = 0;
                  ++y;
                  if (y > WorldGen.waterLine)
                    num6 = 32;
                }
                if ((int) Main.tile[x, y + 1].liquid > 0 && (int) Main.tile[x, y + 1].liquid < (int) byte.MaxValue && (int) Main.tile[x, y + 1].lava == num6)
                {
                  int num8 = (int) byte.MaxValue - (int) Main.tile[x, y + 1].liquid;
                  if (num8 > num4)
                    num8 = num4;
                  Main.tile[x, y + 1].liquid += (byte) num8;
                  num4 -= (int) (byte) num8;
                  if (num4 <= 0)
                    break;
                }
                if (num7 == 0)
                {
                  if ((int) Main.tile[x + num5, y].liquid == 0 && ((int) Main.tile[x + num5, y].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x + num5, y].type]))
                    num7 = num5;
                  else if ((int) Main.tile[x - num5, y].liquid == 0 && ((int) Main.tile[x - num5, y].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x - num5, y].type]))
                    num7 = -num5;
                }
                if (num7 != 0 && (int) Main.tile[x + num7, y].liquid == 0 && ((int) Main.tile[x + num7, y].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x + num7, y].type]))
                {
                  flag2 = true;
                  x += num7;
                }
                if (flag1 && !flag2)
                {
                  flag1 = false;
                  flag2 = true;
                  num5 = -num3;
                  num7 = 0;
                }
              }
              Main.tile[x, y].liquid = (byte) num4;
              Main.tile[x, y].lava = (byte) num6;
              if ((int) Main.tile[x - 1, y].liquid > 0 && (int) Main.tile[x - 1, y].lava != num6)
              {
                if (num6 != 0)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x - 1, y);
              }
              else if ((int) Main.tile[x + 1, y].liquid > 0 && (int) Main.tile[x + 1, y].lava != num6)
              {
                if (num6 != 0)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x + 1, y);
              }
              else if ((int) Main.tile[x, y - 1].liquid > 0 && (int) Main.tile[x, y - 1].lava != num6)
              {
                if (num6 != 0)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x, y - 1);
              }
              else if ((int) Main.tile[x, y + 1].liquid > 0 && (int) Main.tile[x, y + 1].lava != num6)
              {
                if (num6 != 0)
                  Liquid.LavaCheck(x, y);
                else
                  Liquid.LavaCheck(x, y + 1);
              }
            }
            index3 += num3;
          }
        }
      }
    }

    public unsafe void Update()
    {
      fixed (Tile* tilePtr = &Main.tile[(int) this.x, (int) this.y])
      {
        if ((int) tilePtr->active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr->type])
        {
          this.kill = (short) 9;
        }
        else
        {
          int num1 = (int) tilePtr->liquid;
          int num2 = num1;
          if ((int) this.y > (int) Main.maxTilesY - 200 && num1 > 0 && (int) tilePtr->lava == 0)
          {
            int num3 = 2;
            if (num1 < num3)
              num3 = num1;
            num1 -= num3;
            tilePtr->liquid = (byte) num1;
          }
          if (num1 == 0)
          {
            this.kill = (short) 9;
          }
          else
          {
            if ((int) tilePtr->lava != 0)
            {
              Liquid.LavaCheck((int) this.x, (int) this.y);
              if (!Liquid.quickFall)
              {
                if ((int) this.delay < 5)
                {
                  ++this.delay;
                  return;
                }
                else
                  this.delay = (short) 0;
              }
            }
            else
            {
              if ((int) tilePtr[-1440].lava != 0)
                Liquid.AddWater((int) this.x - 1, (int) this.y);
              if ((int) tilePtr[1440].lava != 0)
                Liquid.AddWater((int) this.x + 1, (int) this.y);
              if ((int) tilePtr[-1].lava != 0)
                Liquid.AddWater((int) this.x, (int) this.y - 1);
              if ((int) tilePtr[1].lava != 0)
                Liquid.AddWater((int) this.x, (int) this.y + 1);
            }
            if ((int) tilePtr[1].active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr[1].type])
            {
              int num3 = (int) tilePtr[1].liquid;
              if ((num3 <= 0 || (int) tilePtr[1].lava == (int) tilePtr->lava) && num3 < (int) byte.MaxValue)
              {
                int num4 = (int) byte.MaxValue - num3;
                if (num4 > (int) tilePtr->liquid)
                  num4 = (int) tilePtr->liquid;
                IntPtr num5 = (IntPtr) tilePtr;
                int num6 = (int) (byte) ((uint) ((Tile*) num5)->liquid - (uint) (byte) num4);
                ((Tile*) num5)->liquid = (byte) num6;
                int num7 = num3 + num4;
                tilePtr[1].liquid = (byte) num7;
                tilePtr[1].lava = tilePtr->lava;
                Liquid.AddWater((int) this.x, (int) this.y + 1);
                tilePtr[1].skipLiquid = 128;
                tilePtr->skipLiquid = 128;
                if ((int) tilePtr->liquid > 250)
                {
                  tilePtr->liquid = byte.MaxValue;
                }
                else
                {
                  Liquid.AddWater((int) this.x - 1, (int) this.y);
                  Liquid.AddWater((int) this.x + 1, (int) this.y);
                }
              }
            }
            if ((int) tilePtr->liquid > 0)
            {
              bool flag1 = true;
              bool flag2 = true;
              bool flag3 = true;
              bool flag4 = true;
              if ((int) tilePtr[-1440].active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr[-1440].type])
                flag1 = false;
              else if ((int) tilePtr[-1440].liquid > 0 && (int) tilePtr[-1440].lava != (int) tilePtr->lava)
                flag1 = false;
              else if ((int) tilePtr[-2880].active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr[-2880].type])
                flag3 = false;
              else if ((int) tilePtr[-2880].liquid == 0)
                flag3 = false;
              else if ((int) tilePtr[-2880].liquid > 0 && (int) tilePtr[-2880].lava != (int) tilePtr->lava)
                flag3 = false;
              if ((int) tilePtr[1440].active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr[1440].type])
                flag2 = false;
              else if ((int) tilePtr[1440].liquid > 0 && (int) tilePtr[1440].lava != (int) tilePtr->lava)
                flag2 = false;
              else if ((int) tilePtr[2880].active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr[2880].type])
                flag4 = false;
              else if ((int) tilePtr[2880].liquid == 0)
                flag4 = false;
              else if ((int) tilePtr[2880].liquid > 0 && (int) tilePtr[2880].lava != (int) tilePtr->lava)
                flag4 = false;
              int num3 = 0;
              if ((int) tilePtr->liquid < 3)
                num3 = -1;
              if (flag1 && flag2)
              {
                if (flag3 && flag4)
                {
                  bool flag5 = true;
                  bool flag6 = true;
                  if ((int) tilePtr[-4320].active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr[-4320].type])
                    flag5 = false;
                  else if ((int) tilePtr[-4320].liquid == 0)
                    flag5 = false;
                  else if ((int) tilePtr[-4320].lava != (int) tilePtr->lava)
                    flag5 = false;
                  if ((int) tilePtr[4320].active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr[4320].type])
                    flag6 = false;
                  else if ((int) tilePtr[4320].liquid == 0)
                    flag6 = false;
                  else if ((int) tilePtr[4320].lava != (int) tilePtr->lava)
                    flag6 = false;
                  if (flag5 && flag6)
                  {
                    int num4 = ((int) tilePtr[-1440].liquid + (int) tilePtr[1440].liquid + (int) tilePtr[-2880].liquid + (int) tilePtr[2880].liquid + (int) tilePtr[-4320].liquid + (int) tilePtr[4320].liquid + (int) tilePtr->liquid + num3 + 3) / 7;
                    int num5 = 0;
                    tilePtr[-1440].lava = tilePtr->lava;
                    if ((int) tilePtr[-1440].liquid != num4)
                    {
                      Liquid.AddWater((int) this.x - 1, (int) this.y);
                      tilePtr[-1440].liquid = (byte) num4;
                    }
                    else
                      ++num5;
                    tilePtr[1440].lava = tilePtr->lava;
                    if ((int) tilePtr[1440].liquid != num4)
                    {
                      Liquid.AddWater((int) this.x + 1, (int) this.y);
                      tilePtr[1440].liquid = (byte) num4;
                    }
                    else
                      ++num5;
                    tilePtr[-2880].lava = tilePtr->lava;
                    if ((int) tilePtr[-2880].liquid != num4)
                    {
                      Liquid.AddWater((int) this.x - 2, (int) this.y);
                      tilePtr[-2880].liquid = (byte) num4;
                    }
                    else
                      ++num5;
                    tilePtr[2880].lava = tilePtr->lava;
                    if ((int) tilePtr[2880].liquid != num4)
                    {
                      Liquid.AddWater((int) this.x + 2, (int) this.y);
                      tilePtr[2880].liquid = (byte) num4;
                    }
                    else
                      ++num5;
                    tilePtr[-4320].lava = tilePtr->lava;
                    if ((int) tilePtr[-4320].liquid != num4)
                    {
                      Liquid.AddWater((int) this.x - 3, (int) this.y);
                      tilePtr[-4320].liquid = (byte) num4;
                    }
                    else
                      ++num5;
                    tilePtr[4320].lava = tilePtr->lava;
                    if ((int) tilePtr[4320].liquid != num4)
                    {
                      Liquid.AddWater((int) this.x + 3, (int) this.y);
                      tilePtr[4320].liquid = (byte) num4;
                    }
                    else
                      ++num5;
                    if ((int) tilePtr->liquid != num4 || (int) tilePtr[-1440].liquid != num4)
                      Liquid.AddWater((int) this.x - 1, (int) this.y);
                    if ((int) tilePtr->liquid != num4 || (int) tilePtr[1440].liquid != num4)
                      Liquid.AddWater((int) this.x + 1, (int) this.y);
                    if ((int) tilePtr->liquid != num4 || (int) tilePtr[-2880].liquid != num4)
                      Liquid.AddWater((int) this.x - 2, (int) this.y);
                    if ((int) tilePtr->liquid != num4 || (int) tilePtr[2880].liquid != num4)
                      Liquid.AddWater((int) this.x + 2, (int) this.y);
                    if ((int) tilePtr->liquid != num4 || (int) tilePtr[-4320].liquid != num4)
                      Liquid.AddWater((int) this.x - 3, (int) this.y);
                    if ((int) tilePtr->liquid != num4 || (int) tilePtr[4320].liquid != num4)
                      Liquid.AddWater((int) this.x + 3, (int) this.y);
                    if (num5 != 6 || (int) tilePtr[-1].liquid <= 0)
                      tilePtr->liquid = (byte) num4;
                  }
                  else
                  {
                    int num4 = 0;
                    int num5 = ((int) tilePtr[-1440].liquid + (int) tilePtr[1440].liquid + (int) tilePtr[-2880].liquid + (int) tilePtr[2880].liquid + (int) tilePtr->liquid + num3 + 2) / 5;
                    tilePtr[-1440].lava = tilePtr->lava;
                    if ((int) tilePtr[-1440].liquid != num5)
                    {
                      Liquid.AddWater((int) this.x - 1, (int) this.y);
                      tilePtr[-1440].liquid = (byte) num5;
                    }
                    else
                      ++num4;
                    tilePtr[1440].lava = tilePtr->lava;
                    if ((int) tilePtr[1440].liquid != num5)
                    {
                      Liquid.AddWater((int) this.x + 1, (int) this.y);
                      tilePtr[1440].liquid = (byte) num5;
                    }
                    else
                      ++num4;
                    tilePtr[-2880].lava = tilePtr->lava;
                    if ((int) tilePtr[-2880].liquid != num5)
                    {
                      Liquid.AddWater((int) this.x - 2, (int) this.y);
                      tilePtr[-2880].liquid = (byte) num5;
                    }
                    else
                      ++num4;
                    tilePtr[2880].lava = tilePtr->lava;
                    if ((int) tilePtr[2880].liquid != num5)
                    {
                      Liquid.AddWater((int) this.x + 2, (int) this.y);
                      tilePtr[2880].liquid = (byte) num5;
                    }
                    else
                      ++num4;
                    if ((int) tilePtr[-1440].liquid != num5 || (int) tilePtr->liquid != num5)
                      Liquid.AddWater((int) this.x - 1, (int) this.y);
                    if ((int) tilePtr[1440].liquid != num5 || (int) tilePtr->liquid != num5)
                      Liquid.AddWater((int) this.x + 1, (int) this.y);
                    if ((int) tilePtr[-2880].liquid != num5 || (int) tilePtr->liquid != num5)
                      Liquid.AddWater((int) this.x - 2, (int) this.y);
                    if ((int) tilePtr[2880].liquid != num5 || (int) tilePtr->liquid != num5)
                      Liquid.AddWater((int) this.x + 2, (int) this.y);
                    if (num4 != 4 || (int) tilePtr[-1].liquid <= 0)
                      tilePtr->liquid = (byte) num5;
                  }
                }
                else if (flag3)
                {
                  int num4 = (int) tilePtr[-1440].liquid + (int) tilePtr[1440].liquid + (int) tilePtr[-2880].liquid + (int) tilePtr->liquid + num3 + 2 >> 2;
                  tilePtr[-1440].lava = tilePtr->lava;
                  if ((int) tilePtr[-1440].liquid != num4 || (int) tilePtr->liquid != num4)
                  {
                    Liquid.AddWater((int) this.x - 1, (int) this.y);
                    tilePtr[-1440].liquid = (byte) num4;
                  }
                  tilePtr[1440].lava = tilePtr->lava;
                  if ((int) tilePtr[1440].liquid != num4 || (int) tilePtr->liquid != num4)
                  {
                    Liquid.AddWater((int) this.x + 1, (int) this.y);
                    tilePtr[1440].liquid = (byte) num4;
                  }
                  tilePtr[-2880].lava = tilePtr->lava;
                  if ((int) tilePtr[-2880].liquid != num4 || (int) tilePtr->liquid != num4)
                  {
                    tilePtr[-2880].liquid = (byte) num4;
                    Liquid.AddWater((int) this.x - 2, (int) this.y);
                  }
                  tilePtr->liquid = (byte) num4;
                }
                else if (flag4)
                {
                  int num4 = (int) tilePtr[-1440].liquid + (int) tilePtr[1440].liquid + (int) tilePtr[2880].liquid + (int) tilePtr->liquid + num3 + 2 >> 2;
                  tilePtr[-1440].lava = tilePtr->lava;
                  if ((int) tilePtr[-1440].liquid != num4 || (int) tilePtr->liquid != num4)
                  {
                    Liquid.AddWater((int) this.x - 1, (int) this.y);
                    tilePtr[-1440].liquid = (byte) num4;
                  }
                  tilePtr[1440].lava = tilePtr->lava;
                  if ((int) tilePtr[1440].liquid != num4 || (int) tilePtr->liquid != num4)
                  {
                    Liquid.AddWater((int) this.x + 1, (int) this.y);
                    tilePtr[1440].liquid = (byte) num4;
                  }
                  tilePtr[2880].lava = tilePtr->lava;
                  if ((int) tilePtr[2880].liquid != num4 || (int) tilePtr->liquid != num4)
                  {
                    tilePtr[2880].liquid = (byte) num4;
                    Liquid.AddWater((int) this.x + 2, (int) this.y);
                  }
                  tilePtr->liquid = (byte) num4;
                }
                else
                {
                  int num4 = ((int) tilePtr[-1440].liquid + (int) tilePtr[1440].liquid + (int) tilePtr->liquid + num3 + 1) / 3;
                  tilePtr[-1440].lava = tilePtr->lava;
                  if ((int) tilePtr[-1440].liquid != num4)
                    tilePtr[-1440].liquid = (byte) num4;
                  if ((int) tilePtr->liquid != num4 || (int) tilePtr[-1440].liquid != num4)
                    Liquid.AddWater((int) this.x - 1, (int) this.y);
                  tilePtr[1440].lava = tilePtr->lava;
                  if ((int) tilePtr[1440].liquid != num4)
                    tilePtr[1440].liquid = (byte) num4;
                  if ((int) tilePtr->liquid != num4 || (int) tilePtr[1440].liquid != num4)
                    Liquid.AddWater((int) this.x + 1, (int) this.y);
                  tilePtr->liquid = (byte) num4;
                }
              }
              else if (flag1)
              {
                int num4 = (int) tilePtr[-1440].liquid + (int) tilePtr->liquid + num3 + 1 >> 1;
                if ((int) tilePtr[-1440].liquid != num4)
                  tilePtr[-1440].liquid = (byte) num4;
                tilePtr[-1440].lava = tilePtr->lava;
                if ((int) tilePtr->liquid != num4 || (int) tilePtr[-1440].liquid != num4)
                  Liquid.AddWater((int) this.x - 1, (int) this.y);
                tilePtr->liquid = (byte) num4;
              }
              else if (flag2)
              {
                int num4 = (int) tilePtr[1440].liquid + (int) tilePtr->liquid + num3 + 1 >> 1;
                if ((int) tilePtr[1440].liquid != num4)
                  tilePtr[1440].liquid = (byte) num4;
                tilePtr[1440].lava = tilePtr->lava;
                if ((int) tilePtr->liquid != num4 || (int) tilePtr[1440].liquid != num4)
                  Liquid.AddWater((int) this.x + 1, (int) this.y);
                tilePtr->liquid = (byte) num4;
              }
            }
            if ((int) tilePtr->liquid != num2)
            {
              if ((int) tilePtr->liquid == 254 && num2 == (int) byte.MaxValue)
              {
                tilePtr->liquid = byte.MaxValue;
                ++this.kill;
              }
              else
              {
                Liquid.AddWater((int) this.x, (int) this.y - 1);
                this.kill = (short) 0;
              }
            }
            else
              ++this.kill;
            // ISSUE: __unpin statement
            __unpin(tilePtr);
          }
        }
      }
    }

    public static void StartPanic()
    {
      if (Liquid.panicMode)
        return;
      WorldGen.waterLine = (int) Main.maxTilesY;
      Liquid.numLiquid = 0;
      LiquidBuffer.numLiquidBuffer = 0;
      Liquid.panicCounter = 0;
      Liquid.panicMode = true;
      Liquid.panicY = (int) Main.maxTilesY - 3;
    }

    public static void UpdateLiquid()
    {
      if (!WorldGen.gen)
      {
        if (!Liquid.panicMode)
        {
          if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > 4000)
          {
            ++Liquid.panicCounter;
            if (Liquid.panicCounter > 1800 || Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > 13500)
              Liquid.StartPanic();
          }
          else
            Liquid.panicCounter = 0;
        }
        if (Liquid.panicMode)
        {
          int num = 0;
          while (Liquid.panicY >= 3 && num < 5)
          {
            ++num;
            Liquid.QuickWater(0.0, Liquid.panicY, Liquid.panicY, 0.0);
            --Liquid.panicY;
            if (Liquid.panicY < 3)
            {
              Liquid.panicCounter = 0;
              Liquid.panicMode = false;
              WorldGen.WaterCheck();
              if (Main.netMode == 2)
                Netplay.ResetSections();
            }
          }
          return;
        }
      }
      Liquid.quickFall = Liquid.quickSettle || Liquid.numLiquid > 2000;
      int num1 = 4096 / Liquid.cycles;
      int num2 = num1 * Liquid.wetCounter;
      int num3 = num1 * ++Liquid.wetCounter;
      if (Liquid.wetCounter == Liquid.cycles)
        num3 = Liquid.numLiquid;
      if (num3 > Liquid.numLiquid)
      {
        num3 = Liquid.numLiquid;
        Liquid.wetCounter = Liquid.cycles;
      }
      if (Liquid.quickFall)
      {
        for (int index = num2; index < num3; ++index)
        {
          Main.liquid[index].delay = (short) 10;
          Main.liquid[index].Update();
          Main.tile[(int) Main.liquid[index].x, (int) Main.liquid[index].y].skipLiquid = 0;
        }
      }
      else
      {
        for (int index = num2; index < num3; ++index)
        {
          if (Main.tile[(int) Main.liquid[index].x, (int) Main.liquid[index].y].skipLiquid == 0)
            Main.liquid[index].Update();
          else
            Main.tile[(int) Main.liquid[index].x, (int) Main.liquid[index].y].skipLiquid = 0;
        }
      }
      if (Liquid.wetCounter < Liquid.cycles)
        return;
      Liquid.wetCounter = 0;
      for (int l = Liquid.numLiquid - 1; l >= 0; --l)
      {
        if ((int) Main.liquid[l].kill > 3)
          Liquid.DelWater(l);
      }
      int num4 = 4096 - (4096 - Liquid.numLiquid);
      int num5 = LiquidBuffer.numLiquidBuffer;
      if (num4 > num5)
        num4 = num5;
      int index1 = num5 - num4;
      LiquidBuffer.numLiquidBuffer = index1;
      while (--num4 >= 0)
      {
        Main.tile[(int) Main.liquidBuffer[index1].x, (int) Main.liquidBuffer[index1].y].checkingLiquid = 0;
        Liquid.AddWater((int) Main.liquidBuffer[index1].x, (int) Main.liquidBuffer[index1].y);
        ++index1;
      }
      if (Liquid.numLiquid > 0 && Liquid.numLiquid > Liquid.stuckAmount - 50 && Liquid.numLiquid < Liquid.stuckAmount + 50)
      {
        if (++Liquid.stuckCount < 10000)
          return;
        Liquid.stuck = true;
        for (int l = Liquid.numLiquid - 1; l >= 0; --l)
          Liquid.DelWater(l);
        Liquid.stuck = false;
        Liquid.stuckCount = 0;
      }
      else
      {
        Liquid.stuckCount = 0;
        Liquid.stuckAmount = Liquid.numLiquid;
      }
    }

    public static unsafe void AddWater(int x, int y)
    {
      if (x < 5 || y < 5 || (x >= (int) Main.maxTilesX - 5 || y >= (int) Main.maxTilesY - 5))
        return;
      fixed (Tile* tilePtr = &Main.tile[x, y])
      {
        if ((int) tilePtr->liquid == 0 || tilePtr->checkingLiquid != 0)
          return;
        if (Liquid.numLiquid >= 4095)
        {
          LiquidBuffer.AddBuffer(x, y);
        }
        else
        {
          tilePtr->checkingLiquid = 64;
          Main.liquid[Liquid.numLiquid].Init(x, y);
          tilePtr->skipLiquid = 0;
          ++Liquid.numLiquid;
          if (Main.netMode == 2 && Liquid.numLiquid < 1365)
            NetMessage.sendWater(x, y);
          if ((int) tilePtr->active != 0)
          {
            int index = (int) tilePtr->type;
            if ((index != 4 || (int) tilePtr->frameY != 176) && (Main.tileWaterDeath[index] || (int) tilePtr->lava != 0 && Main.tileLavaDeath[index]))
            {
              if (WorldGen.gen)
                tilePtr->active = (byte) 0;
              else if (WorldGen.KillTile(x, y) && Main.netMode == 2)
              {
                NetMessage.CreateMessage5(17, 0, x, y, 0, 0);
                NetMessage.SendMessage();
              }
            }
          }
          // ISSUE: __unpin statement
          __unpin(tilePtr);
        }
      }
    }

    public static void LavaCheck(int x, int y)
    {
      int num1 = (int) Main.tile[x, y - 1].liquid;
      bool flag1 = (int) Main.tile[x, y - 1].lava == 0;
      int num2 = (int) Main.tile[x - 1, y].liquid;
      bool flag2 = (int) Main.tile[x - 1, y].lava == 0;
      int num3 = (int) Main.tile[x + 1, y].liquid;
      bool flag3 = (int) Main.tile[x + 1, y].lava == 0;
      if (num2 > 0 && flag2 || num3 > 0 && flag3 || num1 > 0 && flag1)
      {
        int num4 = 0;
        if (flag2)
        {
          num4 = num2;
          Main.tile[x - 1, y].liquid = (byte) 0;
        }
        if (flag3)
        {
          num4 += num3;
          Main.tile[x + 1, y].liquid = (byte) 0;
        }
        if (flag1)
        {
          num4 += num1;
          Main.tile[x, y - 1].liquid = (byte) 0;
        }
        if (num4 < 32 || (int) Main.tile[x, y].active != 0)
          return;
        Main.tile[x, y].liquid = (byte) 0;
        Main.tile[x, y].lava = (byte) 0;
        WorldGen.PlaceTile(x, y, 56, true, true, -1, 0);
        WorldGen.SquareTileFrame(x, y, -1);
        if (Main.netMode != 2)
          return;
        NetMessage.SendTileSquare(x - 1, y - 1, 3);
      }
      else
      {
        if ((int) Main.tile[x, y + 1].active != 0 || (int) Main.tile[x, y + 1].liquid <= 0 || (int) Main.tile[x, y + 1].lava != 0)
          return;
        Main.tile[x, y].liquid = (byte) 0;
        Main.tile[x, y].lava = (byte) 0;
        Main.tile[x, y + 1].liquid = (byte) 0;
        WorldGen.PlaceTile(x, y + 1, 56, true, true, -1, 0);
        WorldGen.SquareTileFrame(x, y + 1, -1);
        if (Main.netMode != 2)
          return;
        NetMessage.SendTileSquare(x - 1, y, 3);
      }
    }

    public static unsafe void DelWater(int l)
    {
      int index1 = (int) Main.liquid[l].x;
      int index2 = (int) Main.liquid[l].y;
      fixed (Tile* tilePtr = &Main.tile[index1, index2])
      {
        int num = (int) tilePtr->liquid;
        if (num < 2)
        {
          tilePtr->liquid = (byte) 0;
          num = 0;
          if ((int) tilePtr[-1440].liquid == 1)
            tilePtr[-1440].liquid = (byte) 0;
          if ((int) tilePtr[1440].liquid == 1)
            tilePtr[1440].liquid = (byte) 0;
        }
        else if (num < 20)
        {
          if ((int) tilePtr[1].liquid < (int) byte.MaxValue && ((int) tilePtr[1].active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr[1].type]) || (int) tilePtr[-1440].liquid < num && ((int) tilePtr[-1440].active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr[-1440].type]) || (int) tilePtr[1440].liquid < num && ((int) tilePtr[1440].active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr[1440].type]))
          {
            tilePtr->liquid = (byte) 0;
            num = 0;
          }
        }
        else if ((int) tilePtr[1].liquid < (int) byte.MaxValue && ((int) tilePtr[1].active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr[1].type]) && !Liquid.stuck)
        {
          Main.liquid[l].kill = (short) 0;
          return;
        }
        if (num < 250 && (int) tilePtr[-1].liquid > 0)
          Liquid.AddWater(index1, index2 - 1);
        if (num == 0)
        {
          tilePtr->lava = (byte) 0;
        }
        else
        {
          if ((int) tilePtr[1440].liquid > 0 && (int) tilePtr[1441].liquid < 250 && (int) tilePtr[1441].active == 0 || (int) tilePtr[-1440].liquid > 0 && (int) tilePtr[-1439].liquid < 250 && (int) tilePtr[-1439].active == 0)
          {
            Liquid.AddWater(index1 - 1, index2);
            Liquid.AddWater(index1 + 1, index2);
          }
          if ((int) tilePtr->lava != 0)
          {
            Liquid.LavaCheck(index1, index2);
            for (int i = index1 - 1; i <= index1 + 1; ++i)
            {
              for (int j = index2 - 1; j <= index2 + 1; ++j)
              {
                if ((int) Main.tile[i, j].active != 0)
                {
                  switch (Main.tile[i, j].type)
                  {
                    case (byte) 2:
                    case (byte) 23:
                    case (byte) 109:
                      Main.tile[i, j].type = (byte) 0;
                      WorldGen.SquareTileFrame(i, j, -1);
                      if (Main.netMode == 2)
                      {
                        NetMessage.SendTileSquare(index1, index2, 3);
                        continue;
                      }
                      else
                        continue;
                    case (byte) 60:
                    case (byte) 70:
                      Main.tile[i, j].type = (byte) 59;
                      WorldGen.SquareTileFrame(i, j, -1);
                      if (Main.netMode == 2)
                      {
                        NetMessage.SendTileSquare(index1, index2, 3);
                        continue;
                      }
                      else
                        continue;
                    default:
                      continue;
                  }
                }
              }
            }
          }
        }
        if (Main.netMode == 2)
          NetMessage.sendWater(index1, index2);
        --Liquid.numLiquid;
        tilePtr->checkingLiquid = 0;
        Main.liquid[l].x = Main.liquid[Liquid.numLiquid].x;
        Main.liquid[l].y = Main.liquid[Liquid.numLiquid].y;
        Main.liquid[l].kill = Main.liquid[Liquid.numLiquid].kill;
        if ((int) tilePtr->type >= 82 && (int) tilePtr->type <= 84)
          WorldGen.CheckAlch(index1, index2);
      }
    }
  }
}
