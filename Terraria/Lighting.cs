// Type: Terraria.Lighting
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using System;
using System.Threading;

namespace Terraria
{
  public sealed class Lighting
  {
    private static Lighting.TempLight[] tempLight = new Lighting.TempLight[1024];
    public short scrX = (short) -1;
    private float negLight = 0.04f;
    private float negLight2 = 0.16f;
    private float wetLightR = 0.16f;
    private float wetLightG = 0.16f;
    private AutoResetEvent workerThreadReady = new AutoResetEvent(false);
    private AutoResetEvent workerThreadGo = new AutoResetEvent(false);
    public const int maxRenderCount = 4;
    public const int OFFSCREEN_TILES = 34;
    public const int offScreenTiles2 = 14;
    private const int MAX_LIGHT_ARRAY_Y = 107;
    private const int COLOR_H = 117;
    public const float BRIGHTNESS = 1.2f;
    private const int firstToLightY7 = 0;
    private const int MAX_TEMP_LIGHTS = 1024;
    private int MAX_LIGHT_ARRAY_X;
    private int COLOR_W;
    public float brightness;
    public float defBrightness;
    public float oldSkyColor;
    public float skyColor;
    private float lightColor;
    private float lightColorG;
    private float lightColorB;
    public Vector3[,] color;
    public Vector3[,] color2;
    public byte[] stopAndWetLight;
    private int firstTileX;
    private int firstTileY;
    private int lastTileX;
    private int lastTileY;
    private int firstToLightX;
    private int firstToLightY;
    public short scrY;
    public int minX;
    public int maxX;
    public int minY;
    public int maxY;
    private int minX7;
    private int maxX7;
    private int minY7;
    private int maxY7;
    private int firstTileX7;
    private int lastTileX7;
    private int lastTileY7;
    private int firstTileY7;
    private int lastToLightY7;
    private int firstToLightX27;
    private int lastToLightX27;
    private int firstToLightY27;
    private int lastToLightY27;
    private Thread workerThread;
    private volatile bool quitWorkerThread;
    public static int tempLightCount;

    static Lighting()
    {
    }

    public void StartWorkerThread()
    {
      if (this.workerThread != null)
        this.StopWorkerThread();
      this.quitWorkerThread = false;
      this.workerThreadReady.Reset();
      this.workerThreadGo.Reset();
      this.workerThread = new Thread(new ThreadStart(this.WorkerThread));
      this.workerThread.IsBackground = true;
      this.workerThread.Start();
    }

    public void StopWorkerThread()
    {
      if (this.workerThread == null)
        return;
      this.quitWorkerThread = true;
      this.workerThreadGo.Set();
      this.workerThread.Join();
      this.workerThread = (Thread) null;
    }

    private void WorkerThread()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        3
      });
      do
      {
        this.workerThreadReady.Set();
        this.workerThreadGo.WaitOne();
        lock (this)
          this.doColors();
      }
      while (!this.quitWorkerThread);
      this.workerThreadReady.Set();
    }

    public void SetWidth(int width)
    {
      lock (this)
      {
        this.MAX_LIGHT_ARRAY_X = (width + 64 >> 4) + 68;
        this.COLOR_W = this.MAX_LIGHT_ARRAY_X + 10;
        this.color = new Vector3[this.MAX_LIGHT_ARRAY_X, 107];
        this.color2 = new Vector3[this.COLOR_W, 117];
        this.stopAndWetLight = new byte[this.COLOR_W * 117];
      }
    }

    public unsafe void LightTiles(WorldView view)
    {
      this.firstTileX = (int) view.firstTileX;
      this.lastTileX = (int) view.lastTileX;
      this.firstTileY = (int) view.firstTileY;
      this.lastTileY = (int) view.lastTileY;
      this.firstToLightX = this.firstTileX - 34;
      this.firstToLightY = this.firstTileY - 34;
      int num1 = this.lastTileX + 34;
      int num2 = this.lastTileY + 34;
      if (this.firstToLightX < 0)
        this.firstToLightX = 0;
      if (num1 >= (int) Main.maxTilesX)
        num1 = (int) Main.maxTilesX - 1;
      if (this.firstToLightY < 0)
        this.firstToLightY = 0;
      if (num2 >= (int) Main.maxTilesY)
        num2 = (int) Main.maxTilesY - 1;
      if (Main.renderCount <= 4)
      {
        int num3 = (view.screenPosition.X >> 4) - (view.screenLastPosition.X >> 4);
        if (num3 < 0 && num3 >= -4)
        {
          Vector3[,] vector3Array;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          fixed (Vector3* vector3Ptr1 = &^((vector3Array = this.color) == null || vector3Array.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array.Address(0, 0)))
          {
            int num4 = (this.MAX_LIGHT_ARRAY_X + num3) * 107 - 1;
            int index = num3 * 107;
            Vector3* vector3Ptr2 = vector3Ptr1 + (this.MAX_LIGHT_ARRAY_X * 107 - 1);
            do
            {
              *vector3Ptr2 = vector3Ptr2[index];
              --vector3Ptr2;
            }
            while (--num4 >= 0);
          }
        }
        else if (num3 > 0 && num3 <= 4)
        {
          Vector3[,] vector3Array;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          fixed (Vector3* vector3Ptr1 = &^((vector3Array = this.color) == null || vector3Array.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array.Address(0, 0)))
          {
            int num4 = (this.MAX_LIGHT_ARRAY_X - num3) * 107 - 1;
            int index = num3 * 107;
            Vector3* vector3Ptr2 = vector3Ptr1;
            do
            {
              *vector3Ptr2 = vector3Ptr2[index];
              ++vector3Ptr2;
            }
            while (--num4 >= 0);
          }
        }
        int num5 = (view.screenPosition.Y >> 4) - (view.screenLastPosition.Y >> 4);
        if (num5 < 0 && num5 >= -4)
        {
          for (int index1 = 0; index1 < this.MAX_LIGHT_ARRAY_X; ++index1)
          {
            fixed (Vector3* vector3Ptr = &this.color[index1, 0])
            {
              for (int index2 = 107 + num5; index2 > -num5; --index2)
                vector3Ptr[index2] = vector3Ptr[index2 + num5];
            }
          }
        }
        else if (num5 > 0 && num5 <= 4)
        {
          for (int index1 = 0; index1 < this.MAX_LIGHT_ARRAY_X; ++index1)
          {
            fixed (Vector3* vector3Ptr = &this.color[index1, 0])
            {
              for (int index2 = 0; index2 < 107 - num5; ++index2)
                vector3Ptr[index2] = vector3Ptr[index2 + num5];
            }
          }
        }
        this.oldSkyColor = this.skyColor;
        this.skyColor = (float) (((double) view.time.tileColorf.X + (double) view.time.tileColorf.Y + (double) view.time.tileColorf.Z) * 0.333333343267441);
        if ((double) this.oldSkyColor == (double) this.skyColor)
          return;
        int num6 = num2 <= Main.worldSurface ? num2 : Main.worldSurface;
        Tile[,] tileArray;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
        {
          for (int index = this.firstToLightX; index < num1; ++index)
          {
            Tile* tilePtr2 = tilePtr1 + (index * 1440 + this.firstToLightY);
            int num4 = this.firstToLightY;
            while (num4 < num6)
            {
              if (((int) tilePtr2->active == 0 || !Main.tileNoSunLight[(int) tilePtr2->type]) && ((int) tilePtr2->wall == 0 || (int) tilePtr2->wall == 21) && (int) tilePtr2->liquid < 200)
              {
                fixed (Vector3* vector3Ptr = &this.color[index - this.firstToLightX, num4 - this.firstToLightY])
                {
                  if ((double) vector3Ptr->X < (double) this.skyColor)
                  {
                    vector3Ptr->X = view.time.tileColorf.X;
                    if ((double) vector3Ptr->Y < (double) this.skyColor)
                      vector3Ptr->Y = view.time.tileColorf.Y;
                    if ((double) vector3Ptr->Z < (double) this.skyColor)
                      vector3Ptr->Z = view.time.tileColorf.Z;
                  }
                }
              }
              ++num4;
              ++tilePtr2;
            }
          }
        }
      }
      else
      {
        this.workerThreadReady.WaitOne();
        int num3 = view.screenPosition.X >> 4;
        int num4 = view.screenPosition.Y >> 4;
        if ((int) this.scrX >= 0)
        {
          int num5 = num3 - (int) this.scrX;
          int num6 = num4 - (int) this.scrY;
          int num7 = num5 < 0 ? -num5 : 0;
          int num8 = num6 < 0 ? -num6 : 0;
          Vector3[,] vector3Array1;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          fixed (Vector3* vector3Ptr1 = &^((vector3Array1 = this.color) == null || vector3Array1.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array1.Address(0, 0)))
          {
            Vector3[,] vector3Array2;
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            fixed (Vector3* vector3Ptr2 = &^((vector3Array2 = this.color2) == null || vector3Array2.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array2.Address(0, 0)))
            {
              for (int index1 = num7; index1 < this.MAX_LIGHT_ARRAY_X; ++index1)
              {
                Vector3* vector3Ptr3 = vector3Ptr1 + (index1 * 107 + num8);
                Vector3* vector3Ptr4 = vector3Ptr2 + ((index1 + num5) * 117 + num8 + num6);
                for (int index2 = num8; index2 < 107; ++index2)
                  *vector3Ptr3++ = *vector3Ptr4++;
              }
            }
          }
        }
        Vector3[,] vector3Array3;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        fixed (Vector3* vector3Ptr1 = &^((vector3Array3 = this.color2) == null || vector3Array3.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array3.Address(0, 0)))
          fixed (byte* numPtr1 = this.stopAndWetLight)
          {
            Vector3* vector3Ptr2 = vector3Ptr1;
            byte* numPtr2 = numPtr1;
            for (int index = this.COLOR_W * 117 - 1; index >= 0; --index)
            {
              vector3Ptr2->X = 0.0f;
              vector3Ptr2->Y = 0.0f;
              vector3Ptr2->Z = 0.0f;
              *numPtr2 = (byte) 0;
              ++vector3Ptr2;
              ++numPtr2;
            }
          }
        fixed (Lighting.TempLight* tempLightPtr1 = Lighting.tempLight)
        {
          Vector3[,] vector3Array1;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          fixed (Vector3* vector3Ptr1 = &^((vector3Array1 = this.color2) == null || vector3Array1.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array1.Address(0, 0)))
          {
            Lighting.TempLight* tempLightPtr2 = tempLightPtr1;
            for (int index = Lighting.tempLightCount - 1; index >= 0; --index)
            {
              int num5 = (int) tempLightPtr2->x - this.firstToLightX;
              if (num5 >= 0 && num5 < this.COLOR_W)
              {
                int num6 = (int) tempLightPtr2->y - this.firstToLightY;
                if (num6 >= 0 && num6 < 117)
                {
                  Vector3* vector3Ptr2 = vector3Ptr1 + (num6 + num5 * 117);
                  vector3Ptr2->X = tempLightPtr2->color.X;
                  vector3Ptr2->Y = tempLightPtr2->color.Y;
                  vector3Ptr2->Z = tempLightPtr2->color.Z;
                }
              }
              ++tempLightPtr2;
            }
          }
        }
        int num9 = this.firstTileX - 14;
        int num10 = this.firstTileY - 14;
        int num11 = this.lastTileX + 14;
        int num12 = this.lastTileY + 14;
        if (num9 < 0)
          num9 = 0;
        if (num11 >= (int) Main.maxTilesX)
          num11 = (int) Main.maxTilesX - 1;
        if (num10 < 0)
          num10 = 0;
        if (num12 >= (int) Main.maxTilesY)
          num12 = (int) Main.maxTilesY - 1;
        if (NPC.wof >= 0)
        {
          if (view.player.horrified)
          {
            try
            {
              int num5 = (view.screenPosition.Y >> 4) - 10;
              int num6 = (view.screenPosition.Y + 540 >> 4) + 10;
              int num7 = Main.npc[NPC.wof].aabb.X >> 4;
              int num8 = (int) Main.npc[NPC.wof].direction <= 0 ? num7 + 2 : num7 - 3;
              int num13 = num8 + 8;
              Vector3 vector3 = new Vector3((float) (0.200000002980232 * (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch))), 0.03f, (float) (0.300000011920929 * ((double) Main.demonTorch + 0.5 * (1.0 - (double) Main.demonTorch))));
              for (int index1 = num8; index1 <= num13; ++index1)
              {
                for (int index2 = num5; index2 <= num6; ++index2)
                  Vector3.Max(ref vector3, this.color2.Address(index1 - this.firstToLightX, index2 - this.firstToLightY), this.color2.Address(index1 - this.firstToLightX, index2 - this.firstToLightY));
              }
            }
            catch
            {
            }
          }
        }
        int num14 = this.firstToLightX;
        int num15 = num1;
        int num16 = this.firstToLightY;
        int num17 = num2;
        int num18 = num17 < Main.worldSurface ? num17 : Main.worldSurface;
        Tile[,] tileArray1;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        fixed (Tile* tilePtr1 = &^((tileArray1 = Main.tile) == null || tileArray1.Length == 0 ? (Tile&) IntPtr.Zero : tileArray1.Address(0, 0)))
        {
          for (int index = num14; index < num15; ++index)
          {
            Tile* tilePtr2 = tilePtr1 + (index * 1440 + num16);
            int num5 = num16;
            while (num5 < num18)
            {
              switch (tilePtr2->wall)
              {
                case (byte) 0:
                case (byte) 21:
                  if ((int) tilePtr2->liquid < 200 && ((int) tilePtr2->active == 0 || !Main.tileNoSunLight[(int) tilePtr2->type]))
                  {
                    fixed (Vector3* vector3Ptr = &this.color2[index - this.firstToLightX, num5 - this.firstToLightY])
                    {
                      if ((double) vector3Ptr->X < (double) this.skyColor)
                      {
                        vector3Ptr->X = view.time.tileColorf.X;
                        if ((double) vector3Ptr->Y < (double) this.skyColor)
                          vector3Ptr->Y = view.time.tileColorf.Y;
                        if ((double) vector3Ptr->Z < (double) this.skyColor)
                          vector3Ptr->Z = view.time.tileColorf.Z;
                      }
                    }
                    break;
                  }
                  else
                    break;
              }
              ++num5;
              ++tilePtr2;
            }
          }
        }
        this.negLight = 0.91f;
        this.negLight2 = 0.72f;
        this.wetLightG = 0.97f * this.negLight * UI.blueWave;
        this.wetLightR = 0.88f * this.negLight * UI.blueWave;
        if (view.player.nightVision)
        {
          this.negLight *= 1.03f;
          this.negLight2 *= 1.03f;
        }
        if (view.player.blind)
        {
          this.negLight *= 0.95f;
          this.negLight2 *= 0.95f;
        }
        view.inactiveTiles = 0;
        view.sandTiles = 0;
        view.evilTiles = 0;
        view.snowTiles = 0;
        view.holyTiles = 0;
        view.meteorTiles = 0;
        view.jungleTiles = 0;
        view.dungeonTiles = 0;
        view.musicBox = -1;
        this.minX = this.COLOR_W;
        this.maxX = 0;
        this.minY = 117;
        this.maxY = 0;
        Tile[,] tileArray2;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        fixed (Tile* tilePtr1 = &^((tileArray2 = Main.tile) == null || tileArray2.Length == 0 ? (Tile&) IntPtr.Zero : tileArray2.Address(0, 0)))
        {
          for (int index1 = num14; index1 < num15; ++index1)
          {
            Tile* tilePtr2 = tilePtr1 + (index1 * 1440 + num16);
            int num5 = num16;
            while (num5 < num17)
            {
              int index2 = index1 - this.firstToLightX;
              int index3 = num5 - this.firstToLightY;
              fixed (Vector3* vector3Ptr = &this.color2[index2, index3])
              {
                if ((int) tilePtr2->active == 0)
                {
                  ++view.inactiveTiles;
                }
                else
                {
                  int index4 = (int) tilePtr2->type;
                  int num6 = num15 - num14 - 99 >> 1;
                  int num7 = num17 - num16 - 87 >> 1;
                  if (index1 > num14 + num6 && index1 < num15 - num6 && (num5 > num16 + num7 && num5 < num17 - num7))
                  {
                    switch (index4)
                    {
                      case 109:
                      case 110:
                      case 113:
                      case 117:
                        ++view.holyTiles;
                        break;
                      case 112:
                        ++view.sandTiles;
                        ++view.evilTiles;
                        break;
                      case 116:
                        ++view.sandTiles;
                        ++view.holyTiles;
                        break;
                      case 139:
                        if ((int) tilePtr2->frameX >= 36)
                        {
                          view.musicBox = (int) tilePtr2->frameY / 36;
                          break;
                        }
                        else
                          break;
                      case 147:
                      case 148:
                        ++view.snowTiles;
                        break;
                      case 60:
                      case 61:
                      case 62:
                      case 84:
                        ++view.jungleTiles;
                        break;
                      case 37:
                        ++view.meteorTiles;
                        break;
                      case 41:
                      case 43:
                      case 44:
                        ++view.dungeonTiles;
                        break;
                      case 53:
                        ++view.sandTiles;
                        break;
                      case 23:
                      case 24:
                      case 25:
                      case 32:
                        ++view.evilTiles;
                        break;
                      case 27:
                        view.evilTiles -= 5;
                        break;
                    }
                  }
                  if (Main.tileBlockLight[index4])
                    this.stopAndWetLight[index2 * 117 + index3] = (byte) 1;
                  if (Main.tileLighted[index4])
                  {
                    switch (index4)
                    {
                      case 140:
                      case 22:
                        float num8 = 0.12f;
                        float num13 = 0.07f;
                        float num19 = 0.32f;
                        if ((double) num8 > (double) vector3Ptr->X)
                          vector3Ptr->X = num8;
                        if ((double) num13 > (double) vector3Ptr->Y)
                          vector3Ptr->Y = num13;
                        if ((double) num19 > (double) vector3Ptr->Z)
                        {
                          vector3Ptr->Z = num19;
                          break;
                        }
                        else
                          break;
                      case 149:
                        if ((int) tilePtr2->frameX <= 36)
                        {
                          float num20;
                          float num21;
                          float num22;
                          if ((int) tilePtr2->frameX == 0)
                          {
                            num20 = 0.1f;
                            num21 = 0.2f;
                            num22 = 0.5f;
                          }
                          else if ((int) tilePtr2->frameX == 18)
                          {
                            num20 = 0.5f;
                            num21 = 0.1f;
                            num22 = 0.1f;
                          }
                          else
                          {
                            num20 = 0.2f;
                            num21 = 0.5f;
                            num22 = 0.1f;
                          }
                          if ((double) vector3Ptr->X < (double) num20)
                            vector3Ptr->X = (float) ((double) num20 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                          if ((double) vector3Ptr->Y < (double) num21)
                            vector3Ptr->Y = (float) ((double) num21 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                          if ((double) vector3Ptr->Z < (double) num22)
                          {
                            vector3Ptr->Z = (float) ((double) num22 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 125:
                        float num23 = (float) Main.rand.Next(28, 42) * 0.01f + (float) (270 - (int) UI.mouseTextBrightness) * (1.0 / 800.0);
                        if ((double) vector3Ptr->Y < 0.100000001490116 * (double) num23)
                          vector3Ptr->Y = 0.3f * num23;
                        if ((double) vector3Ptr->Z < 0.300000011920929 * (double) num23)
                        {
                          vector3Ptr->Z = 0.6f * num23;
                          break;
                        }
                        else
                          break;
                      case 126:
                        if ((int) tilePtr2->frameX < 36)
                        {
                          if ((double) Main.DiscoRGB.X > (double) vector3Ptr->X)
                            vector3Ptr->X = Main.DiscoRGB.X;
                          if ((double) Main.DiscoRGB.Y > (double) vector3Ptr->Y)
                            vector3Ptr->Y = Main.DiscoRGB.Y;
                          if ((double) Main.DiscoRGB.Z > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = Main.DiscoRGB.Z;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 129:
                        float num24;
                        float num25;
                        float num26;
                        if ((int) tilePtr2->frameX == 0 || (int) tilePtr2->frameX == 54 || (int) tilePtr2->frameX == 108)
                        {
                          num24 = 0.0f;
                          num25 = 0.05f;
                          num26 = 0.25f;
                        }
                        else if ((int) tilePtr2->frameX == 18 || (int) tilePtr2->frameX == 72 || (int) tilePtr2->frameX == 126)
                        {
                          num24 = 0.2f;
                          num25 = 0.0f;
                          num26 = 0.15f;
                        }
                        else
                        {
                          num24 = 0.1f;
                          num25 = 0.0f;
                          num26 = 0.2f;
                        }
                        if ((double) vector3Ptr->X < (double) num24)
                          vector3Ptr->X = (float) ((double) num24 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                        if ((double) vector3Ptr->Y < (double) num25)
                          vector3Ptr->Y = (float) ((double) num25 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                        if ((double) vector3Ptr->Z < (double) num26)
                        {
                          vector3Ptr->Z = (float) ((double) num26 * (double) Main.rand.Next(970, 1031) * (1.0 / 1000.0));
                          break;
                        }
                        else
                          break;
                      case 133:
                      case 17:
                        float num27 = 0.83f;
                        float num28 = 0.6f;
                        float num29 = 0.5f;
                        if ((double) num27 > (double) vector3Ptr->X)
                          vector3Ptr->X = num27;
                        if ((double) num28 > (double) vector3Ptr->Y)
                          vector3Ptr->Y = num28;
                        if ((double) num29 > (double) vector3Ptr->Z)
                        {
                          vector3Ptr->Z = num29;
                          break;
                        }
                        else
                          break;
                      case 83:
                        if ((int) tilePtr2->frameX == 18 && !view.time.dayTime)
                        {
                          float num20 = 0.1f;
                          float num21 = 0.4f;
                          float num22 = 0.6f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 84:
                        switch ((int) tilePtr2->frameX / 18)
                        {
                          case 2:
                            float num30 = (float) (270 - (int) UI.mouseTextBrightness) * (1.0 / 800.0);
                            if ((double) num30 > 1.0)
                              num30 = 1f;
                            else if ((double) num30 < 0.0)
                              num30 = 0.0f;
                            float num31 = 0.7f * num30;
                            float num32 = num30;
                            float num33 = 0.1f * num30;
                            if ((double) num31 > (double) vector3Ptr->X)
                              vector3Ptr->X = num31;
                            if ((double) num32 > (double) vector3Ptr->Y)
                              vector3Ptr->Y = num32;
                            if ((double) num33 > (double) vector3Ptr->Z)
                            {
                              vector3Ptr->Z = num33;
                              break;
                            }
                            else
                              break;
                          case 5:
                            float num34 = 0.9f;
                            float num35 = 0.72f;
                            float num36 = 0.18f;
                            if ((double) num34 > (double) vector3Ptr->X)
                              vector3Ptr->X = num34;
                            if ((double) num35 > (double) vector3Ptr->Y)
                              vector3Ptr->Y = num35;
                            if ((double) num36 > (double) vector3Ptr->Z)
                            {
                              vector3Ptr->Z = num36;
                              break;
                            }
                            else
                              break;
                        }
                      case 92:
                        if ((int) tilePtr2->frameY <= 18 && (int) tilePtr2->frameX == 0)
                        {
                          float num20 = 1f;
                          float num21 = 1f;
                          float num22 = 1f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 93:
                        if ((int) tilePtr2->frameY == 0 && (int) tilePtr2->frameX == 0)
                        {
                          float num20 = 1f;
                          float num21 = 0.97f;
                          float num22 = 0.85f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 95:
                        if ((int) tilePtr2->frameX < 36)
                        {
                          float num20 = 1f;
                          float num21 = 0.95f;
                          float num22 = 0.8f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 98:
                        if ((int) tilePtr2->frameY == 0)
                        {
                          float num20 = 1f;
                          float num21 = 0.97f;
                          float num22 = 0.85f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 100:
                        if ((int) tilePtr2->frameX < 36)
                        {
                          float num20 = 1f;
                          float num21 = 0.95f;
                          float num22 = 0.65f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 70:
                      case 71:
                      case 72:
                        float num37 = (float) Main.rand.Next(28, 42) * 0.005f + (float) (270 - (int) UI.mouseTextBrightness) * (1.0 / 500.0);
                        float num38 = 0.1f;
                        float num39 = 0.3f + num37;
                        float num40 = 0.6f + num37;
                        if ((double) num38 > (double) vector3Ptr->X)
                          vector3Ptr->X = num38;
                        if ((double) num39 > (double) vector3Ptr->Y)
                          vector3Ptr->Y = num39;
                        if ((double) num40 > (double) vector3Ptr->Z)
                        {
                          vector3Ptr->Z = num40;
                          break;
                        }
                        else
                          break;
                      case 77:
                        float num41 = 0.75f;
                        float num42 = 0.45f;
                        float num43 = 0.25f;
                        if ((double) num41 > (double) vector3Ptr->X)
                          vector3Ptr->X = num41;
                        if ((double) num42 > (double) vector3Ptr->Y)
                          vector3Ptr->Y = num42;
                        if ((double) num43 > (double) vector3Ptr->Z)
                        {
                          vector3Ptr->Z = num43;
                          break;
                        }
                        else
                          break;
                      case 49:
                        float num44 = 0.3f;
                        float num45 = 0.3f;
                        float num46 = 0.75f;
                        if ((double) num44 > (double) vector3Ptr->X)
                          vector3Ptr->X = num44;
                        if ((double) num45 > (double) vector3Ptr->Y)
                          vector3Ptr->Y = num45;
                        if ((double) num46 > (double) vector3Ptr->Z)
                        {
                          vector3Ptr->Z = num46;
                          break;
                        }
                        else
                          break;
                      case 61:
                        if ((int) tilePtr2->frameX == 144)
                        {
                          float num20 = 0.42f;
                          float num21 = 0.81f;
                          float num22 = 0.52f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 26:
                      case 31:
                        float num47 = (float) Main.rand.Next(-5, 6) * (1.0 / 400.0);
                        float num48 = 0.31f + num47;
                        float num49 = 0.1f;
                        float num50 = 0.44f + num47;
                        if ((double) num48 > (double) vector3Ptr->X)
                          vector3Ptr->X = num48;
                        if ((double) num49 > (double) vector3Ptr->Y)
                          vector3Ptr->Y = num49;
                        if ((double) num50 > (double) vector3Ptr->Z)
                        {
                          vector3Ptr->Z = num50;
                          break;
                        }
                        else
                          break;
                      case 33:
                        if ((int) tilePtr2->frameX == 0)
                        {
                          float num20 = 1f;
                          float num21 = 0.95f;
                          float num22 = 0.65f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 34:
                      case 35:
                        if ((int) tilePtr2->frameX < 54)
                        {
                          float num20 = 1f;
                          float num21 = 0.95f;
                          float num22 = 0.8f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 36:
                        if ((int) tilePtr2->frameX < 54)
                        {
                          float num20 = 1f;
                          float num21 = 0.95f;
                          float num22 = 0.65f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 37:
                        float num51 = 0.56f;
                        float num52 = 0.43f;
                        float num53 = 0.15f;
                        if ((double) num51 > (double) vector3Ptr->X)
                          vector3Ptr->X = num51;
                        if ((double) num52 > (double) vector3Ptr->Y)
                          vector3Ptr->Y = num52;
                        if ((double) num53 > (double) vector3Ptr->Z)
                        {
                          vector3Ptr->Z = num53;
                          break;
                        }
                        else
                          break;
                      case 42:
                        if ((int) tilePtr2->frameX == 0)
                        {
                          float num20 = 0.65f;
                          float num21 = 0.8f;
                          float num22 = 0.54f;
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                      case 4:
                        if ((int) tilePtr2->frameX < 66)
                        {
                          float num20;
                          float num21;
                          float num22;
                          switch (tilePtr2->frameY)
                          {
                            case (short) 154:
                              num20 = (float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch));
                              num21 = 0.3f;
                              num22 = Main.demonTorch + (float) (0.5 * (1.0 - (double) Main.demonTorch));
                              break;
                            case (short) 176:
                              num20 = 0.85f;
                              num21 = 1f;
                              num22 = 0.7f;
                              break;
                            case (short) 110:
                              num20 = 1.3f;
                              num21 = 1.3f;
                              num22 = 1.3f;
                              break;
                            case (short) 132:
                              num20 = 1f;
                              num21 = 1f;
                              num22 = 0.1f;
                              break;
                            case (short) 66:
                              num20 = 0.0f;
                              num21 = 1f;
                              num22 = 0.1f;
                              break;
                            case (short) 88:
                              num20 = 0.95f;
                              num21 = 0.1f;
                              num22 = 0.95f;
                              break;
                            case (short) 22:
                              num20 = 0.0f;
                              num21 = 0.1f;
                              num22 = 1.3f;
                              break;
                            case (short) 44:
                              num20 = 1f;
                              num21 = 0.1f;
                              num22 = 0.1f;
                              break;
                            default:
                              num20 = 1f;
                              num21 = 0.95f;
                              num22 = 0.8f;
                              break;
                          }
                          if ((double) num20 > (double) vector3Ptr->X)
                            vector3Ptr->X = num20;
                          if ((double) num21 > (double) vector3Ptr->Y)
                            vector3Ptr->Y = num21;
                          if ((double) num22 > (double) vector3Ptr->Z)
                          {
                            vector3Ptr->Z = num22;
                            break;
                          }
                          else
                            break;
                        }
                        else
                          break;
                    }
                  }
                }
                if ((int) tilePtr2->liquid > 0)
                {
                  if ((int) tilePtr2->lava != 0)
                  {
                    float num6 = 0.55f + (float) (270 - (int) UI.mouseTextBrightness) * (1.0 / 900.0);
                    if ((double) vector3Ptr->X < (double) num6)
                      vector3Ptr->X = num6;
                    if ((double) vector3Ptr->Y < (double) num6)
                      vector3Ptr->Y = num6 * 0.6f;
                    if ((double) vector3Ptr->Z < (double) num6)
                      vector3Ptr->Z = num6 * 0.2f;
                  }
                  else if ((int) tilePtr2->liquid > 128)
                    this.stopAndWetLight[index2 * 117 + index3] |= (byte) 2;
                }
                if ((double) vector3Ptr->X > 0.0 || (double) vector3Ptr->Y > 0.0 || (double) vector3Ptr->Z > 0.0)
                {
                  if (this.minX > index2)
                    this.minX = index2;
                  if (this.maxX < index2 + 1)
                    this.maxX = index2 + 1;
                  if (this.minY > index3)
                    this.minY = index3;
                  if (this.maxY < index3 + 1)
                    this.maxY = index3 + 1;
                }
              }
              ++num5;
              ++tilePtr2;
            }
          }
        }
        if (view.evilTiles < 0)
          view.evilTiles = 0;
        int num54 = view.holyTiles;
        view.holyTiles -= view.evilTiles;
        view.evilTiles -= num54;
        if (view.holyTiles < 0)
          view.holyTiles = 0;
        if (view.evilTiles < 0)
          view.evilTiles = 0;
        this.minX7 = this.minX;
        this.maxX7 = this.maxX;
        this.minY7 = this.minY;
        this.maxY7 = this.maxY;
        this.minX += this.firstToLightX;
        this.maxX += this.firstToLightX;
        this.minY += this.firstToLightY;
        this.maxY += this.firstToLightY;
        this.firstTileX7 = this.firstTileX - this.firstToLightX;
        this.lastTileX7 = this.lastTileX - this.firstToLightX;
        this.lastTileY7 = this.lastTileY - this.firstToLightY;
        this.firstTileY7 = this.firstTileY - this.firstToLightY;
        this.lastToLightY7 = num2 - this.firstToLightY;
        this.firstToLightX27 = num9 - this.firstToLightX;
        this.lastToLightX27 = num11 - this.firstToLightX;
        this.firstToLightY27 = num10 - this.firstToLightY;
        this.lastToLightY27 = num12 - this.firstToLightY;
        this.workerThreadGo.Set();
        this.scrX = (short) (view.screenPosition.X >> 4);
        this.scrY = (short) (view.screenPosition.Y >> 4);
      }
    }

    private unsafe void doColors()
    {
      Vector3[,] vector3Array1;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Vector3* vector3Ptr = &^((vector3Array1 = this.color2) == null || vector3Array1.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array1.Address(0, 0)))
      {
        int num1 = this.minX7 * 117;
        int num2 = this.minX7;
        while (num2 < this.maxX7)
        {
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          for (int index = this.minY7; index < this.lastToLightY27 + 4; ++index)
          {
            int s = num1 + index;
            this.LightColor(vector3Ptr + s, s, 1);
          }
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          for (int index = this.maxY7; index >= this.firstTileY7 - 4; --index)
          {
            int s = num1 + index;
            this.LightColor(vector3Ptr + s, s, -1);
          }
          ++num2;
          num1 += 117;
        }
      }
      Vector3[,] vector3Array2;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Vector3* vector3Ptr = &^((vector3Array2 = this.color2) == null || vector3Array2.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array2.Address(0, 0)))
      {
        for (int index = 0; index < this.lastToLightY7; ++index)
        {
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          int s1 = index + this.minX7 * 117;
          int num1 = this.minX7;
          while (num1 < this.lastTileX7 + 4)
          {
            this.LightColor(vector3Ptr + s1, s1, 117);
            ++num1;
            s1 += 117;
          }
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          int s2 = index + this.maxX7 * 117;
          int num2 = this.maxX7;
          while (num2 >= this.firstTileX7 - 4)
          {
            this.LightColor(vector3Ptr + s2, s2, -117);
            --num2;
            s2 -= 117;
          }
        }
      }
      Vector3[,] vector3Array3;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Vector3* vector3Ptr = &^((vector3Array3 = this.color2) == null || vector3Array3.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array3.Address(0, 0)))
      {
        int num1 = this.firstToLightX27 * 117;
        int num2 = this.firstToLightX27;
        while (num2 < this.lastToLightX27)
        {
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          for (int index = this.firstToLightY27; index < this.lastTileY7 + 4; ++index)
          {
            int s = index + num1;
            this.LightColor(vector3Ptr + s, s, 1);
          }
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          for (int index = this.lastToLightY27; index >= this.firstTileY7 - 4; --index)
          {
            int s = index + num1;
            this.LightColor(vector3Ptr + s, s, -1);
          }
          ++num2;
          num1 += 117;
        }
      }
      Vector3[,] vector3Array4;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Vector3* vector3Ptr = &^((vector3Array4 = this.color2) == null || vector3Array4.Length == 0 ? (Vector3&) IntPtr.Zero : vector3Array4.Address(0, 0)))
      {
        for (int index = this.firstToLightY27; index < this.lastToLightY27; ++index)
        {
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          int s1 = index + this.firstToLightX27 * 117;
          int num1 = this.firstToLightX27;
          while (num1 < this.lastTileX7 + 4)
          {
            this.LightColor(vector3Ptr + s1, s1, 117);
            ++num1;
            s1 += 117;
          }
          this.lightColor = 0.0f;
          this.lightColorG = 0.0f;
          this.lightColorB = 0.0f;
          int s2 = index + this.lastToLightX27 * 117;
          int num2 = this.lastToLightX27;
          while (num2 >= this.firstTileX7 - 4)
          {
            this.LightColor(vector3Ptr + s2, s2, -117);
            --num2;
            s2 -= 117;
          }
        }
      }
    }

    public static unsafe void addLight(int i, int j, Vector3 rgb)
    {
      if (Lighting.tempLightCount == 1024 || !WorldView.AnyViewContains(i << 4, j << 4))
        return;
      fixed (Lighting.TempLight* tempLightPtr1 = Lighting.tempLight)
      {
        int num = Lighting.tempLightCount - 1;
        Lighting.TempLight* tempLightPtr2 = tempLightPtr1 + num;
        for (; num >= 0; --num)
        {
          if ((int) tempLightPtr2->x == i && (int) tempLightPtr2->y == j)
          {
            if ((double) tempLightPtr2->color.X < (double) rgb.X)
              tempLightPtr2->color.X = rgb.X;
            if ((double) tempLightPtr2->color.Y < (double) rgb.Y)
              tempLightPtr2->color.Y = rgb.Y;
            if ((double) tempLightPtr2->color.Z >= (double) rgb.Z)
              return;
            tempLightPtr2->color.Z = rgb.Z;
            return;
          }
          else
            --tempLightPtr2;
        }
        Lighting.TempLight* tempLightPtr3 = tempLightPtr1 + Lighting.tempLightCount++;
        tempLightPtr3->x = (short) i;
        tempLightPtr3->y = (short) j;
        tempLightPtr3->color = rgb;
      }
    }

    private unsafe void LightColor(Vector3* pColor2, int s, int offset)
    {
      s = (int) this.stopAndWetLight[s];
      float num1 = this.lightColor;
      if ((double) pColor2->X > (double) num1)
        num1 = pColor2->X;
      if ((double) num1 > 0.0185000002384186)
      {
        pColor2->X = num1;
        if ((double) pColor2[offset].X <= (double) num1)
        {
          if (s == 0)
            num1 *= this.negLight;
          else if ((s & 1) != 0)
            num1 *= this.negLight2;
          else
            num1 *= (float) ((double) this.wetLightR * (double) Main.rand.Next(98, 100) * 0.00999999977648258);
        }
        this.lightColor = num1;
      }
      float num2 = this.lightColorG;
      if ((double) pColor2->Y > (double) num2)
        num2 = pColor2->Y;
      if ((double) num2 > 0.0185000002384186)
      {
        pColor2->Y = num2;
        if ((double) pColor2[offset].Y <= (double) num2)
        {
          if (s == 0)
            num2 *= this.negLight;
          else if ((s & 1) != 0)
            num2 *= this.negLight2;
          else
            num2 *= (float) ((double) this.wetLightG * (double) Main.rand.Next(97, 100) * 0.00999999977648258);
        }
        this.lightColorG = num2;
      }
      float num3 = this.lightColorB;
      if ((double) pColor2->Z > (double) num3)
        num3 = pColor2->Z;
      if ((double) num3 <= 0.0185000002384186)
        return;
      pColor2->Z = num3;
      if ((double) pColor2[offset].Z < (double) num3)
      {
        if ((s & 1) != 0)
          num3 *= this.negLight2;
        else
          num3 *= this.negLight;
      }
      this.lightColorB = num3;
    }

    public Color GetColorPlayer(int x, int y, Color oldColor)
    {
      int index1 = x - this.firstToLightX;
      int index2 = y - this.firstToLightY;
      if (index1 < 0 || index2 < 0 || (index1 >= this.MAX_LIGHT_ARRAY_X || index2 >= 107))
        return Color.Black;
      float num1 = this.color[index1, index2].X * 2.5f;
      if ((double) num1 > 1.0)
        num1 = 1f;
      int r = (int) ((double) oldColor.R * (double) num1 * (double) this.brightness);
      float num2 = this.color[index1, index2].Y * 2.5f;
      if ((double) num2 > 1.0)
        num2 = 1f;
      int g = (int) ((double) oldColor.G * (double) num2 * (double) this.brightness);
      float num3 = this.color[index1, index2].Z * 2.5f;
      if ((double) num3 > 1.0)
        num3 = 1f;
      int b = (int) ((double) oldColor.B * (double) num3 * (double) this.brightness);
      return new Color(r, g, b, (int) byte.MaxValue);
    }

    public Color GetColorPlayer(int x, int y)
    {
      int index1 = x - this.firstToLightX;
      int index2 = y - this.firstToLightY;
      if (index1 < 0 || index2 < 0 || (index1 >= this.MAX_LIGHT_ARRAY_X || index2 >= 107))
        return Color.Black;
      else
        return new Color(this.color[index1, index2] * (this.brightness * 2.5f));
    }

    public Color GetColorUnsafe(int x, int y)
    {
      return new Color(this.color[x - this.firstToLightX, y - this.firstToLightY] * this.brightness);
    }

    public Color GetColor(int x, int y)
    {
      int index1 = x - this.firstToLightX;
      int index2 = y - this.firstToLightY;
      if (index1 < 0 || index2 < 0 || (index1 >= this.MAX_LIGHT_ARRAY_X || index2 >= 107))
        return Color.Black;
      else
        return new Color(this.color[index1, index2] * this.brightness);
    }

    public unsafe float Brightness(int x, int y)
    {
      int index1 = x - this.firstToLightX;
      int index2 = y - this.firstToLightY;
      if (index1 < 0 || index2 < 0 || (index1 >= this.MAX_LIGHT_ARRAY_X || index2 >= 107))
        return 0.0f;
      fixed (Vector3* vector3Ptr = &this.color[index1, index2])
        return (float) (((double) vector3Ptr->X + (double) vector3Ptr->Y + (double) vector3Ptr->Z) * 0.333333343267441);
    }

    public unsafe float BrightnessUnsafe(int x, int y)
    {
      fixed (Vector3* vector3Ptr = &this.color[x - this.firstToLightX, y - this.firstToLightY])
        return (float) (((double) vector3Ptr->X + (double) vector3Ptr->Y + (double) vector3Ptr->Z) * 0.333333343267441);
    }

    public unsafe bool IsNotBlackUnsafe(int x, int y)
    {
      fixed (Vector3* vector3Ptr = &this.color[x - this.firstToLightX, y - this.firstToLightY])
        return (double) vector3Ptr->X > 0.0 || (double) vector3Ptr->Y > 0.0 || (double) vector3Ptr->Z > 0.0;
    }

    public unsafe bool Brighter(int x, int y, int x2, int y2)
    {
      int index1 = x - this.firstToLightX;
      int index2 = y - this.firstToLightY;
      if (index1 < 0 || index2 < 0 || (index1 >= this.MAX_LIGHT_ARRAY_X || index2 >= 107))
        return true;
      int index3 = x2 - this.firstToLightX;
      int index4 = y2 - this.firstToLightY;
      if (index3 < 0 || index4 < 0 || (index3 >= this.MAX_LIGHT_ARRAY_X || index4 >= 107))
        return false;
      fixed (Vector3* vector3Ptr1 = &this.color[index1, index2])
        fixed (Vector3* vector3Ptr2 = &this.color2[index3, index4])
          return (double) vector3Ptr1->X + (double) vector3Ptr1->Y + (double) vector3Ptr1->Z <= (double) vector3Ptr2->X + (double) vector3Ptr2->Y + (double) vector3Ptr2->Z;
    }

    private struct TempLight
    {
      public short x;
      public short y;
      public Vector3 color;
    }
  }
}
