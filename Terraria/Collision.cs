// Type: Terraria.Collision
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public sealed class Collision
  {
    public static bool up;
    public static bool down;

    static Collision()
    {
    }

    public static bool CanHit(ref Rectangle aabb1, ref Rectangle aabb2)
    {
      int index1 = aabb1.X + (aabb1.Width >> 1) >> 4;
      int index2 = aabb1.Y + (aabb1.Height >> 1) >> 4;
      int num1 = aabb2.X + (aabb2.Width >> 1) >> 4;
      int num2 = aabb2.Y + (aabb2.Height >> 1) >> 4;
      try
      {
        do
        {
          int num3 = Math.Abs(index1 - num1);
          int num4 = Math.Abs(index2 - num2);
          if (index1 == num1 && index2 == num2)
            return true;
          if (num3 > num4)
          {
            if (index1 < num1)
              ++index1;
            else
              --index1;
            if ((int) Main.tile[index1, index2 - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index1, index2 - 1].type] && ((int) Main.tile[index1, index2 + 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index1, index2 + 1].type]))
              return false;
          }
          else
          {
            if (index2 < num2)
              ++index2;
            else
              --index2;
            if ((int) Main.tile[index1 - 1, index2].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index1 - 1, index2].type] && ((int) Main.tile[index1 + 1, index2].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index1 + 1, index2].type]))
              return false;
          }
        }
        while ((int) Main.tile[index1, index2].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[index1, index2].type]);
        return false;
      }
      catch
      {
        return false;
      }
    }

    public static bool AnyPlayerOrNPC(int i, int j, int h)
    {
      Rectangle rectangle = new Rectangle();
      rectangle.X = i * 16;
      rectangle.Y = j * 16;
      rectangle.Width = 16;
      rectangle.Height = h * 16;
      for (int index = 7; index >= 0; --index)
      {
        if ((int) Main.player[index].active != 0 && rectangle.Intersects(Main.player[index].aabb))
          return true;
      }
      for (int index = 195; index >= 0; --index)
      {
        if ((int) Main.npc[index].active != 0 && rectangle.Intersects(Main.npc[index].aabb))
          return true;
      }
      return false;
    }

    public static unsafe bool DrownCollision(ref Vector2 Position, int Width, int Height, int gravDir)
    {
      Vector2 vector2 = Position;
      int num1 = 10;
      int num2 = 12;
      if (num1 > Width)
        num1 = Width;
      if (num2 > Height)
        num2 = Height;
      vector2.X += (float) (Width >> 1);
      vector2.X -= (float) (num1 >> 1);
      vector2.Y -= 2f;
      if (gravDir == -1)
        vector2.Y += (float) ((Height >> 1) - 6);
      int num3 = ((int) Position.X >> 4) - 1;
      int num4 = ((int) Position.X + Width >> 4) + 2;
      int num5 = ((int) Position.Y >> 4) - 1;
      int num6 = ((int) Position.Y + Height >> 4) + 2;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesX)
        num4 = (int) Main.maxTilesX;
      if (num5 < 0)
        num5 = 0;
      if (num6 > (int) Main.maxTilesY)
        num6 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num3; index < num4; ++index)
        {
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num5);
          int num7 = num5;
          while (num7 < num6)
          {
            int num8 = (int) tilePtr2->liquid;
            if (num8 > 0)
            {
              int num9 = index << 4;
              float num10 = (float) (num7 << 4);
              float num11 = (float) (256 - num8) * (1.0 / 16.0);
              float num12 = num10 + num11;
              int num13 = 16 - (int) num11;
              if ((double) vector2.X + (double) num1 > (double) num9 && (double) vector2.X < (double) (num9 + 16) && ((double) vector2.Y + (double) num2 > (double) num12 && (double) vector2.Y < (double) num12 + (double) num13))
                return true;
            }
            ++num7;
            ++tilePtr2;
          }
        }
      }
      return false;
    }

    public static unsafe bool WetCollision(ref Vector2 Position, int Width, int Height)
    {
      Vector2 vector2 = new Vector2(Position.X + (float) (Width >> 1), Position.Y + (float) (Height >> 1));
      int num1 = 10;
      int num2 = Height >> 1;
      if (num1 > Width)
        num1 = Width;
      if (num2 > Height)
        num2 = Height;
      vector2.X -= (float) (num1 >> 1);
      vector2.Y -= (float) (num2 >> 1);
      int num3 = ((int) Position.X >> 4) - 1;
      int num4 = ((int) Position.X + Width >> 4) + 2;
      int num5 = ((int) Position.Y >> 4) - 1;
      int num6 = ((int) Position.Y + Height >> 4) + 2;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesX)
        num4 = (int) Main.maxTilesX;
      if (num5 < 0)
        num5 = 0;
      if (num6 > (int) Main.maxTilesY)
        num6 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num3; index < num4; ++index)
        {
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num5);
          int num7 = num5;
          while (num7 < num6)
          {
            int num8 = (int) tilePtr2->liquid;
            if (num8 > 0)
            {
              int num9 = index << 4;
              float num10 = (float) (num7 << 4);
              int num11 = 16;
              float num12 = (float) (256 - num8) * (1.0 / 16.0);
              float num13 = num10 + num12;
              int num14 = num11 - (int) num12;
              if ((double) vector2.X + (double) num1 > (double) num9 && (double) vector2.X < (double) (num9 + 16) && ((double) vector2.Y + (double) num2 > (double) num13 && (double) vector2.Y < (double) num13 + (double) num14))
                return true;
            }
            ++num7;
            ++tilePtr2;
          }
        }
      }
      return false;
    }

    public static unsafe bool LavaCollision(ref Vector2 Position, int Width, int Height)
    {
      int num1 = ((int) Position.X >> 4) - 1;
      int num2 = ((int) Position.X + Width >> 4) + 2;
      int num3 = ((int) Position.Y >> 4) - 1;
      int num4 = ((int) Position.Y + Height >> 4) + 2;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num1; index < num2; ++index)
        {
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num3);
          int num5 = num3;
          while (num5 < num4)
          {
            int num6 = (int) tilePtr2->liquid;
            if (num6 > 0 && (int) tilePtr2->lava != 0)
            {
              Vector2 vector2;
              vector2.X = (float) (index * 16);
              vector2.Y = (float) (num5 * 16);
              int num7 = 16;
              float num8 = (float) (256 - num6) * (1.0 / 16.0);
              vector2.Y += num8;
              int num9 = num7 - (int) num8;
              if ((double) Position.X + (double) Width > (double) vector2.X && (double) Position.X < (double) vector2.X + 16.0 && ((double) Position.Y + (double) Height > (double) vector2.Y && (double) Position.Y < (double) vector2.Y + (double) num9))
                return true;
            }
            ++num5;
            ++tilePtr2;
          }
        }
      }
      return false;
    }

    public static unsafe void TileCollision(ref Vector2 Position, ref Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false)
    {
      Collision.up = false;
      Collision.down = false;
      Vector2 vector2 = Velocity;
      float num1 = Position.X + (float) Width;
      float num2 = Position.Y + (float) Height;
      float num3 = Position.X + Velocity.X;
      float num4 = Position.Y + Velocity.Y;
      float num5 = num3 + (float) Width;
      float num6 = num4 + (float) Height;
      int num7 = ((int) Position.X >> 4) - 1;
      int num8 = ((int) num1 >> 4) + 2;
      int num9 = ((int) Position.Y >> 4) - 1;
      int num10 = ((int) num2 >> 4) + 2;
      int num11 = -1;
      int num12 = -1;
      int num13 = -1;
      int num14 = -1;
      if (num7 < 0)
        num7 = 0;
      if (num8 > (int) Main.maxTilesX)
        num8 = (int) Main.maxTilesX;
      if (num9 < 0)
        num9 = 0;
      if (num10 > (int) Main.maxTilesY)
        num10 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index1 = num7; index1 < num8; ++index1)
        {
          int num15 = index1 << 4;
          if ((double) num5 > (double) num15 && (double) num3 < (double) (num15 + 16))
          {
            Tile* tilePtr2 = tilePtr1 + (index1 * 1440 + num9);
            int num16 = num9;
            while (num16 < num10)
            {
              if ((int) tilePtr2->active != 0)
              {
                int index2 = (int) tilePtr2->type;
                bool flag = Main.tileSolidTop[index2];
                if (flag && (int) tilePtr2->frameY == 0 || Main.tileSolid[index2])
                {
                  int num17 = num16 << 4;
                  if ((double) num6 > (double) num17 && (double) num4 < (double) (num17 + 16))
                  {
                    if ((double) num2 <= (double) num17)
                    {
                      Collision.down = true;
                      if (!flag || !fallThrough || (double) vector2.Y > 1.0 && !fall2)
                      {
                        num13 = index1;
                        num14 = num16;
                        if (num13 != num11)
                          Velocity.Y = (float) num17 - num2;
                      }
                    }
                    else if (!flag)
                    {
                      if ((double) num1 <= (double) num15)
                      {
                        num11 = index1;
                        num12 = num16;
                        if (num12 != num14)
                          Velocity.X = (float) num15 - num1;
                        if (num13 == num11)
                          Velocity.Y = vector2.Y;
                      }
                      else if ((double) Position.X >= (double) (num15 + 16))
                      {
                        num11 = index1;
                        num12 = num16;
                        if (num12 != num14)
                          Velocity.X = (float) (num15 + 16) - Position.X;
                        if (num13 == num11)
                          Velocity.Y = vector2.Y;
                      }
                      else if ((double) Position.Y >= (double) (num17 + 16))
                      {
                        Collision.up = true;
                        num13 = index1;
                        num14 = num16;
                        Velocity.Y = (float) (num17 + 16) - Position.Y;
                        if (num14 == num12)
                          Velocity.X = vector2.X;
                      }
                    }
                  }
                }
              }
              ++num16;
              ++tilePtr2;
            }
          }
        }
      }
    }

    public static unsafe bool SolidCollision(ref Vector2 Position, int Width, int Height)
    {
      float num1 = Position.X + (float) Width;
      float num2 = Position.Y + (float) Height;
      int num3 = ((int) Position.X >> 4) - 1;
      int num4 = ((int) num1 >> 4) + 2;
      int num5 = ((int) Position.Y >> 4) - 1;
      int num6 = ((int) num2 >> 4) + 2;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesX)
        num4 = (int) Main.maxTilesX;
      if (num5 < 0)
        num5 = 0;
      if (num6 > (int) Main.maxTilesY)
        num6 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num3; index < num4; ++index)
        {
          if ((double) num1 > (double) (index << 4) && (double) Position.X < (double) (index + 1 << 4))
          {
            Tile* tilePtr2 = tilePtr1 + (index * 1440 + num5);
            int num7 = num5;
            while (num7 < num6)
            {
              if ((int) tilePtr2->active != 0 && (double) num2 > (double) (num7 << 4) && ((double) Position.Y < (double) (num7 + 1 << 4) && Main.tileSolidNotSolidTop[(int) tilePtr2->type]))
                return true;
              ++num7;
              ++tilePtr2;
            }
          }
        }
      }
      return false;
    }

    public static unsafe Vector2 WaterCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false)
    {
      Vector2 vector2_1 = Velocity;
      Vector2 vector2_2 = Position + Velocity;
      Vector2 vector2_3 = Position;
      int num1 = ((int) Position.X >> 4) - 1;
      int num2 = ((int) Position.X + Width >> 4) + 2;
      int num3 = ((int) Position.Y >> 4) - 1;
      int num4 = ((int) Position.Y + Height >> 4) + 2;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num1; index < num2; ++index)
        {
          Vector2 vector2_4;
          vector2_4.X = (float) (index * 16);
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num3);
          int num5 = num3;
          while (num5 < num4)
          {
            int num6 = (int) tilePtr2->liquid;
            if (num6 > 0)
            {
              int num7 = num6 + 16 >> 5 << 1;
              vector2_4.Y = (float) (num5 * 16 + 16 - num7);
              if ((double) vector2_2.X + (double) Width > (double) vector2_4.X && (double) vector2_2.X < (double) vector2_4.X + 16.0 && ((double) vector2_2.Y + (double) Height > (double) vector2_4.Y && (double) vector2_2.Y < (double) vector2_4.Y + (double) num7) && ((double) vector2_3.Y + (double) Height <= (double) vector2_4.Y && !fallThrough))
                vector2_1.Y = vector2_4.Y - (vector2_3.Y + (float) Height);
            }
            ++num5;
            ++tilePtr2;
          }
        }
      }
      return vector2_1;
    }

    public static unsafe void AnyCollision(ref Vector2 Position, ref Vector2 Velocity, int Width, int Height)
    {
      Vector2 vector2_1 = Position + Velocity;
      Vector2 vector2_2 = Position;
      int num1 = ((int) Position.X >> 4) - 1;
      int num2 = ((int) Position.X + Width >> 4) + 2;
      int num3 = ((int) Position.Y >> 4) - 1;
      int num4 = ((int) Position.Y + Height >> 4) + 2;
      int num5 = -1;
      int num6 = -1;
      int num7 = -1;
      int num8 = -1;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num1; index < num2; ++index)
        {
          double num9 = (double) (index << 4);
          if ((double) vector2_1.X + (double) Width > num9 && (double) vector2_1.X < num9 + 16.0)
          {
            Tile* tilePtr2 = tilePtr1 + (index * 1440 + num3);
            int num10 = num3;
            while (num10 < num4)
            {
              if ((int) tilePtr2->active != 0)
              {
                double num11 = (double) (num10 << 4);
                if ((double) vector2_1.Y + (double) Height > num11 && (double) vector2_1.Y < num11 + 16.0)
                {
                  if ((double) vector2_2.Y + (double) Height <= num11)
                  {
                    int num12 = index;
                    num8 = num10;
                    if (num12 != num5)
                      Velocity.Y = (float) (num11 - ((double) vector2_2.Y + (double) Height));
                  }
                  else if (!Main.tileSolidTop[(int) tilePtr2->type])
                  {
                    if ((double) vector2_2.X + (double) Width <= num9)
                    {
                      num5 = index;
                      num6 = num10;
                      if (num6 != num8)
                        Velocity.X = (float) (num9 - ((double) vector2_2.X + (double) Width));
                    }
                    else if ((double) vector2_2.X >= num9 + 16.0)
                    {
                      num5 = index;
                      num6 = num10;
                      if (num6 != num8)
                        Velocity.X = (float) (num9 + 16.0) - vector2_2.X;
                    }
                    else if ((double) vector2_2.Y >= num11 + 16.0)
                    {
                      num7 = index;
                      num8 = num10;
                      Velocity.Y = (float) (num11 + 16.0 - (double) vector2_2.Y + 0.01);
                      if (num8 == num6)
                        Velocity.X += 0.01f;
                    }
                  }
                }
              }
              ++num10;
              ++tilePtr2;
            }
          }
        }
      }
    }

    public static unsafe void HitTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
    {
      Vector2 vector2 = Position + Velocity;
      int num1 = ((int) Position.X >> 4) - 1;
      int num2 = ((int) Position.X + Width >> 4) + 1;
      int num3 = ((int) Position.Y >> 4) - 1;
      int num4 = ((int) Position.Y + Height >> 4) + 1;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int i = num1; i < num2; ++i)
        {
          Tile* tilePtr2 = tilePtr1 + (i * 1440 + num3);
          int j = num3;
          while (j < num4)
          {
            if (tilePtr2->canStandOnTop())
            {
              double num5 = (double) (i << 4);
              double num6 = (double) (j << 4);
              if ((double) vector2.X + (double) Width >= num5 && (double) vector2.X <= num5 + 16.0 && ((double) vector2.Y + (double) Height >= num6 && (double) vector2.Y <= num6 + 16.0))
                WorldGen.KillTile(i, j, true, true, false);
            }
            ++j;
            ++tilePtr2;
          }
        }
      }
    }

    public static unsafe int HurtTiles(ref Vector2 Position, ref Vector2 Velocity, int Width, int Height, bool fireImmune = false)
    {
      int num1 = ((int) Position.X >> 4) - 1;
      int num2 = ((int) Position.X + Width >> 4) + 1;
      int num3 = ((int) Position.Y >> 4) - 1;
      int num4 = ((int) Position.Y + Height >> 4) + 1;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num1; index < num2; ++index)
        {
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num3);
          int num5 = num3;
          while (num5 < num4)
          {
            if ((int) tilePtr2->active != 0)
            {
              int num6 = (int) tilePtr2->type;
              switch (num6)
              {
                case 32:
                case 37:
                case 48:
                case 53:
                case 57:
                case 58:
                case 69:
                case 76:
                case 112:
                case 116:
                case 123:
                  double num7 = (double) (index << 4);
                  double num8 = (double) (num5 << 4);
                  int num9 = 0;
                  if (num6 == 32 || num6 == 69 || num6 == 80)
                  {
                    if ((double) Position.X + (double) Width > num7 && (double) Position.X < num7 + 16.0 && ((double) Position.Y + (double) Height > num8 && (double) Position.Y < num8 + 16.01))
                    {
                      int num10 = 10;
                      if (num6 == 69)
                        num10 = 17;
                      else if (num6 == 80)
                        num10 = 6;
                      if ((num6 == 32 || num6 == 69) && WorldGen.KillTile(index, num5))
                      {
                        NetMessage.CreateMessage5(17, 4, index, num5, 0, 0);
                        NetMessage.SendMessage();
                      }
                      return num10;
                    }
                    else
                      break;
                  }
                  else if (num6 == 53 || num6 == 112 || (num6 == 116 || num6 == 123))
                  {
                    if ((double) Position.X + (double) Width - 2.0 >= num7 && (double) Position.X + 2.0 <= num7 + 16.0 && ((double) Position.Y + (double) Height - 2.0 >= num8 && (double) Position.Y + 2.0 <= num8 + 16.0))
                      return 20;
                    else
                      break;
                  }
                  else if ((double) Position.X + (double) Width >= num7 && (double) Position.X <= num7 + 16.0 && ((double) Position.Y + (double) Height >= num8 && (double) Position.Y <= num8 + 16.01))
                  {
                    if (num6 == 48)
                      num9 = 40;
                    else if (!fireImmune && (num6 == 37 || num6 == 58 || num6 == 76))
                      num9 = 20;
                    return num9;
                  }
                  else
                    break;
              }
            }
            ++num5;
            ++tilePtr2;
          }
        }
      }
      return 0;
    }

    public static unsafe bool SwitchTiles(Vector2 Position, int Width, int Height, Vector2 oldPosition)
    {
      int num1 = ((int) Position.X >> 4) - 1;
      int num2 = ((int) Position.X + Width >> 4) + 1;
      int num3 = ((int) Position.Y >> 4) - 1;
      int num4 = ((int) Position.Y + Height >> 4) + 1;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = num1; index < num2; ++index)
        {
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num3);
          int num5 = num3;
          while (num5 < num4)
          {
            if ((int) tilePtr2->type == 135 && (int) tilePtr2->active != 0)
            {
              double num6 = (double) (index * 16);
              double num7 = (double) (num5 * 16 + 12);
              if ((double) Position.X + (double) Width > num6 && (double) Position.X < num6 + 16.0 && ((double) Position.Y + (double) Height > num7 && (double) Position.Y < num7 + 4.01) && ((double) oldPosition.X + (double) Width <= num6 || (double) oldPosition.X >= num6 + 16.0 || ((double) oldPosition.Y + (double) Height <= num7 || (double) oldPosition.Y >= num7 + 16.01)))
              {
                WorldGen.hitSwitch(index, num5);
                NetMessage.CreateMessage2(59, index, num5);
                NetMessage.SendMessage();
                return true;
              }
            }
            ++num5;
            ++tilePtr2;
          }
        }
      }
      return false;
    }

    public static unsafe Vector2i StickyTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
    {
      Vector2 vector2 = Position;
      int num1 = ((int) Position.X >> 4) - 1;
      int num2 = ((int) Position.X + Width >> 4) + 2;
      int num3 = ((int) Position.Y >> 4) - 1;
      int num4 = ((int) Position.Y + Height >> 4) + 2;
      if (num1 < 0)
        num1 = 0;
      if (num2 > (int) Main.maxTilesX)
        num2 = (int) Main.maxTilesX;
      if (num3 < 0)
        num3 = 0;
      if (num4 > (int) Main.maxTilesY)
        num4 = (int) Main.maxTilesY;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int x = num1; x < num2; ++x)
        {
          Tile* tilePtr2 = tilePtr1 + (x * 1440 + num3);
          int y = num3;
          while (y < num4)
          {
            if ((int) tilePtr2->type == 51 && (int) tilePtr2->active != 0)
            {
              double num5 = (double) (x * 16);
              double num6 = (double) (y * 16);
              if ((double) vector2.X + (double) Width > num5 && (double) vector2.X < num5 + 16.0 && ((double) vector2.Y + (double) Height > num6 && (double) vector2.Y < num6 + 16.01))
              {
                if ((double) Math.Abs(Velocity.X) + (double) Math.Abs(Velocity.Y) > 0.699999988079071 && Main.rand.Next(30) == 0)
                  Main.dust.NewDust(x * 16, y * 16, 16, 16, 30, 0.0, 0.0, 0, new Color(), 1.0);
                return new Vector2i(x, y);
              }
            }
            ++y;
            ++tilePtr2;
          }
        }
      }
      return new Vector2i(-1, -1);
    }

    public static unsafe bool SolidTiles(int startX, int endX, int startY, int endY)
    {
      if (startX < 0 || endX >= (int) Main.maxTilesX || (startY < 0 || endY >= (int) Main.maxTilesY))
        return true;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = startX; index < endX + 1; ++index)
        {
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + startY);
          int num = startY;
          while (num < endY + 1)
          {
            if ((int) tilePtr2->active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr2->type])
              return true;
            ++num;
            ++tilePtr2;
          }
        }
      }
      return false;
    }

    public static bool LineIntersection(ref Vector2 a1, ref Vector2 a2, Vector2 b1, Vector2 b2, ref Vector2 intersection)
    {
      Vector2 vector2_1 = a2 - a1;
      Vector2 vector2_2 = b2 - b1;
      float num1 = (float) ((double) vector2_1.X * (double) vector2_2.Y - (double) vector2_1.Y * (double) vector2_2.X);
      if ((double) num1 == 0.0)
        return false;
      Vector2 vector2_3 = b1 - a1;
      float num2 = (float) ((double) vector2_3.X * (double) vector2_2.Y - (double) vector2_3.Y * (double) vector2_2.X) / num1;
      if ((double) num2 < 0.0 || (double) num2 > 1.0)
        return false;
      float num3 = (float) ((double) vector2_3.X * (double) vector2_1.Y - (double) vector2_3.Y * (double) vector2_1.X) / num1;
      if ((double) num3 < 0.0 || (double) num3 > 1.0)
        return false;
      intersection = a1 + num2 * vector2_1;
      return true;
    }
  }
}
