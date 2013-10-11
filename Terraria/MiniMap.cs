// Type: Terraria.MiniMap
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace Terraria
{
  public sealed class MiniMap
  {
    private static readonly uint[] WallColors = new uint[32]
    {
      0U,
      4282532418U,
      4283972910U,
      4281410885U,
      4283051548U,
      4282729797U,
      4283432960U,
      4278190176U,
      4278210560U,
      4282908751U,
      4286007047U,
      4286743170U,
      4282325255U,
      4282320647U,
      4278190176U,
      4278211840U,
      4283972910U,
      4278190147U,
      4278204160U,
      4281532471U,
      4278190176U,
      4279378988U,
      4285621091U,
      4283318338U,
      4282396723U,
      4278919998U,
      4282145594U,
      4282001693U,
      4283520101U,
      4289331200U,
      4278233600U,
      4288256443U
    };
    private static readonly uint[] TileColors = new uint[150]
    {
      4287720015U,
      4286611584U,
      4280080478U,
      4279067940U,
      4294786563U,
      4284696113U,
      4285225294U,
      4291188253U,
      4290356247U,
      4292468703U,
      4278255602U,
      4278255602U,
      4294901760U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4285217304U,
      4279067940U,
      4292720640U,
      4284637095U,
      4287465951U,
      4287465951U,
      4283124354U,
      4287627519U,
      4291100436U,
      4287375142U,
      4278255602U,
      4285024564U,
      4278190080U,
      4286210447U,
      4294786563U,
      4294786563U,
      4294786563U,
      4294786563U,
      4292845449U,
      4287664272U,
      4289855743U,
      4289485645U,
      4283716760U,
      4293890123U,
      4281968721U,
      4289855743U,
      4294956308U,
      4293256677U,
      4294924544U,
      4285361517U,
      4281044991U,
      4278255602U,
      uint.MaxValue,
      4279067940U,
      4294957624U,
      1090519039U,
      4294946398U,
      4283912621U,
      4282664012U,
      4284883490U,
      4284236873U,
      4287616797U,
      4287616797U,
      4287286812U,
      4280976122U,
      4280976122U,
      4280976122U,
      4280976122U,
      4280976122U,
      4280976122U,
      4284362807U,
      4284317695U,
      4289834627U,
      4288057198U,
      4279067940U,
      4279067940U,
      4289855743U,
      4291166237U,
      4292149264U,
      4278255602U,
      4278255602U,
      4278232320U,
      4293219136U,
      4294932480U,
      4294932480U,
      4294932480U,
      4290822336U,
      4294902015U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4278255602U,
      4294902015U,
      4294902015U,
      4294901968U,
      4294902015U,
      4294902015U,
      4294902015U,
      4294902015U,
      4294902015U,
      4278255602U,
      4278255602U,
      4278931599U,
      4284197289U,
      4283351523U,
      4280194632U,
      4286585396U,
      4284965498U,
      4280194632U,
      4286536773U,
      4281499553U,
      4292199621U,
      4290096318U,
      4292199621U,
      4282335049U,
      4288051837U,
      4280645291U,
      4287741813U,
      4284044115U,
      4284236854U,
      4286686719U,
      4292598747U,
      4285051848U,
      4287653968U,
      4278208889U,
      4289045925U,
      4279900698U,
      4291363587U,
      4287172626U,
      4288065159U,
      4294799986U,
      4291608768U,
      4287401100U,
      4284703587U,
      4288242499U,
      4286084531U,
      4289536803U,
      4291363587U,
      4291363587U,
      4291363587U,
      4294901760U,
      4278255360U,
      4293848831U,
      4291611886U,
      4294901760U
    };
    private float mapScale = 1f;
    private short mapDestH = (short) 486;
    private const int SCROLL_SPEED = 8;
    private const float SCALE_SPEED = 0.05f;
    private const float MIN_SCALE = 1f;
    private const float MAX_SCALE = 4f;
    private const int MAP_OFFSET_X = 290;
    private const int MAP_OFFSET_X_SPLITSCREEN = 340;
    private const int MAP_TEXTURE_SLICES = 4;
    private static short width;
    private static short height;
    private static short texWidth;
    private short mapX;
    private short mapY;
    public volatile bool isThreadDone;
    private int alpha;
    private Texture2D[] mapTexture;

    static MiniMap()
    {
    }

    public static void onStartGame()
    {
      MiniMap.width = (short) ((int) Main.maxTilesX - 68);
      MiniMap.height = (short) ((int) Main.maxTilesY - 68);
      MiniMap.texWidth = (short) ((int) MiniMap.width / 4);
    }

    public void UpdateMap(UI ui)
    {
      int num1 = ui.view.SAFE_AREA_OFFSET_L + (UI.numActiveViews > 1 ? 340 : 290);
      int num2 = (int) ui.view.viewWidth - ui.view.SAFE_AREA_OFFSET_R - num1;
      int num3 = (int) Main.maxTilesX;
      int num4 = (int) Main.maxTilesY;
      if (ui.IsAlternateLeftButtonDown())
        this.mapX -= (short) 8;
      if (ui.IsAlternateRightButtonDown())
        this.mapX += (short) 8;
      if (ui.IsAlternateUpButtonDown())
        this.mapY -= (short) 8;
      if (ui.IsAlternateDownButtonDown())
        this.mapY += (short) 8;
      float left = ui.gpState.Triggers.Left;
      if ((double) left > 0.125)
      {
        this.mapScale -= 0.05f * left;
        if ((double) this.mapScale < 1.0)
          this.mapScale = 1f;
      }
      float right = ui.gpState.Triggers.Right;
      if ((double) right > 0.125)
      {
        this.mapScale += 0.05f * right;
        if ((double) this.mapScale > 4.0)
          this.mapScale = 4f;
      }
      int num5 = (int) ((double) num2 * (1.0 / (double) this.mapScale - 1.0) * 0.5);
      int num6 = (int) MiniMap.width - num2 - num5;
      if ((int) this.mapX < num5)
        this.mapX = (short) num5;
      else if ((int) this.mapX > num6)
        this.mapX = (short) num6;
      int num7 = (int) ((double) this.mapDestH * (1.0 / (double) this.mapScale - 1.0) * 0.5);
      int num8 = (int) MiniMap.height - (int) this.mapDestH - num7;
      if ((int) this.mapY < num7)
      {
        this.mapY = (short) num7;
      }
      else
      {
        if ((int) this.mapY <= num8)
          return;
        this.mapY = (short) num8;
      }
    }

    public void CreateMap(UI ui)
    {
      if (this.isThreadDone)
        this.DestroyMap();
      this.alpha = 0;
      this.mapTexture = new Texture2D[4];
      for (int index = 3; index >= 0; --index)
        this.mapTexture[index] = new Texture2D(WorldView.graphicsDevice, (int) MiniMap.texWidth, (int) MiniMap.height, false, SurfaceFormat.Bgr565);
      new Thread(new ParameterizedThreadStart(this.CreateMapThread))
      {
        IsBackground = true
      }.Start((object) ui);
    }

    public unsafe void CreateMapThread(object arg)
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        4
      });
      UI ui = (UI) arg;
      int length = (int) MiniMap.texWidth * (int) MiniMap.height;
      ushort[] data = new ushort[length];
      sbyte[] numArray1 = new sbyte[(int) MiniMap.height];
      sbyte[] numArray2 = new sbyte[(int) MiniMap.width];
      Player player = ui.player;
      for (int index1 = 3; index1 >= 0; --index1)
      {
        fixed (ushort* numPtr1 = &data[length - 1])
        {
          ushort* numPtr2 = numPtr1;
          for (int index2 = (int) MiniMap.height - 1; index2 >= 0; --index2)
          {
            int num1 = (int) MiniMap.texWidth - 1;
            int index3 = num1 + index1 * (int) MiniMap.texWidth;
            while (num1 >= 0)
            {
              fixed (Tile* tilePtr = &Main.tile[index3 + 34, index2 + 34])
              {
                if ((tilePtr->flags & Tile.Flags.VISITED) == ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                {
                  if ((int) numArray1[index2] > 0)
                    --numArray1[index2];
                  if ((int) numArray2[index3] > 0)
                    --numArray2[index3];
                }
                else
                {
                  if ((int) numArray1[index2] < 4)
                    ++numArray1[index2];
                  if ((int) numArray2[index3] < 4)
                    ++numArray2[index3];
                }
                if ((int) numArray1[index2] <= 0 && (int) numArray2[index3] <= 0)
                {
                  *numPtr2 = (ushort) 0;
                }
                else
                {
                  int num2 = (int) numArray1[index2] >= (int) numArray2[index3] ? ((int) numArray1[index2] <= (int) numArray2[index3] ? (int) numArray1[index2] * (int) numArray1[index2] + (int) numArray2[index3] * (int) numArray2[index3] : (int) numArray1[index2] * (int) numArray1[index2] + ((int) numArray2[index3] + 1) * 4) : ((int) numArray1[index2] + 1) * 4 + (int) numArray2[index3] * (int) numArray2[index3];
                  uint num3;
                  uint num4;
                  uint num5;
                  uint num6;
                  if ((int) tilePtr->active != 0)
                  {
                    num3 = MiniMap.TileColors[(int) tilePtr->type];
                  }
                  else
                  {
                    int index4 = (int) tilePtr->wall;
                    if (index4 == 0)
                    {
                      if (index2 < Main.worldSurface)
                      {
                        num4 = (uint) ((index2 >> 1) * (int) ui.view.time.bgColor.R / Main.worldSurface);
                        num5 = (uint) index2 * (uint) ui.view.time.bgColor.G / (uint) (int) ((double) Main.worldSurface * 1.20000004768372);
                        num6 = (uint) ((index2 << 1) * (int) ui.view.time.bgColor.B / Main.worldSurface);
                        if (num6 > (uint) byte.MaxValue)
                        {
                          num6 = (uint) byte.MaxValue;
                          goto label_27;
                        }
                        else
                          goto label_27;
                      }
                      else if (index2 < Main.rockLayer)
                      {
                        num4 = 84U;
                        num5 = 57U;
                        num6 = 42U;
                        goto label_27;
                      }
                      else if (index2 >= (int) Main.maxTilesY - 200)
                      {
                        num4 = 51U;
                        num5 = 0U;
                        num6 = 0U;
                        goto label_27;
                      }
                      else
                      {
                        num4 = 72U;
                        num5 = 64U;
                        num6 = 57U;
                        goto label_27;
                      }
                    }
                    else
                      num3 = MiniMap.WallColors[index4];
                  }
                  num6 = num3 & (uint) byte.MaxValue;
                  num5 = num3 >> 8 & (uint) byte.MaxValue;
                  num4 = num3 >> 16 & (uint) byte.MaxValue;
label_27:
                  uint num7 = (uint) tilePtr->liquid;
                  if (num7 > 0U)
                  {
                    if ((int) tilePtr->lava == 32)
                    {
                      num4 = (num4 * ((uint) byte.MaxValue - num7) >> 8) + num7;
                      num6 >>= 1;
                    }
                    else
                    {
                      num4 >>= 1;
                      num6 = (num6 * ((uint) byte.MaxValue - num7) >> 8) + num7;
                    }
                    num5 >>= 1;
                  }
                  if (num2 < 32)
                  {
                    num4 = (uint) ((ulong) num4 * (ulong) num2) >> 5;
                    num5 = (uint) ((ulong) num5 * (ulong) num2) >> 5;
                    num6 = (uint) ((ulong) num6 * (ulong) num2) >> 5;
                  }
                  *numPtr2 = (ushort) ((uint) ((int) (num4 >> 3) << 11 | (int) (num5 >> 2) << 5) | num6 >> 3);
                }
                --numPtr2;
              }
              --num1;
              --index3;
            }
          }
        }
        this.mapTexture[index1].SetData<ushort>(data);
      }
      int num8 = ui.view.SAFE_AREA_OFFSET_L + (UI.numActiveViews > 1 ? 340 : 290);
      int num9 = (int) ui.view.viewWidth - ui.view.SAFE_AREA_OFFSET_R - num8;
      int num10 = (int) MiniMap.width - num9;
      int num11 = (int) MiniMap.height - (int) this.mapDestH;
      this.mapX = (short) ((player.aabb.X >> 4) - 34 - (num9 >> 1));
      if ((int) this.mapX < 0)
        this.mapX = (short) 0;
      else if ((int) this.mapX > num10)
        this.mapX = (short) num10;
      this.mapY = (short) ((player.aabb.Y >> 4) - 34 - ((int) this.mapDestH >> 1));
      if ((int) this.mapY < 0)
        this.mapY = (short) 0;
      else if ((int) this.mapY > num11)
        this.mapY = (short) num11;
      this.isThreadDone = true;
    }

    public void DestroyMap()
    {
      this.isThreadDone = false;
      if (this.mapTexture == null)
        return;
      for (int index = 0; index < 4; ++index)
      {
        this.mapTexture[index].Dispose();
        this.mapTexture[index] = (Texture2D) null;
      }
      this.mapTexture = (Texture2D[]) null;
    }

    public void DrawMap(WorldView view)
    {
      int num1 = view.SAFE_AREA_OFFSET_L + (UI.numActiveViews > 1 ? 340 : 290);
      int num2 = view.SAFE_AREA_OFFSET_T;
      this.mapDestH = (short) (540 - view.SAFE_AREA_OFFSET_T - view.SAFE_AREA_OFFSET_B - 36);
      int val1 = (int) view.viewWidth - view.SAFE_AREA_OFFSET_R - num1;
      if (!this.isThreadDone)
      {
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) view.screenProjection);
        SpriteSheet<_sheetSprites>.Draw(1012, num1 + (val1 >> 1), num2 + ((int) this.mapDestH >> 1), Color.White, (float) Main.frameCounter * 0.1047198f, 1f);
      }
      else
      {
        this.alpha += 16;
        if (this.alpha > (int) byte.MaxValue)
          this.alpha = (int) byte.MaxValue;
        int num3 = num1 + (val1 >> 1);
        int num4 = num2 + ((int) this.mapDestH >> 1);
        Matrix matrix1 = Matrix.CreateTranslation((float) -num3, (float) -num4, 0.0f) * Matrix.CreateScale(this.mapScale, this.mapScale, 1f) * Matrix.CreateTranslation((float) num3, (float) num4, 0.0f);
        view.screenProjection.View = matrix1;
        Rectangle rectangle = new Rectangle();
        if (view.isFullScreen())
        {
          rectangle.X = num1;
          rectangle.Y = num2;
          rectangle.Width = val1;
          rectangle.Height = (int) this.mapDestH;
        }
        else
        {
          rectangle.X = (num1 >> 1) + view.activeViewport.X;
          rectangle.Y = (num2 >> 1) + view.activeViewport.Y;
          rectangle.Width = val1 >> 1;
          rectangle.Height = (int) this.mapDestH >> 1;
        }
        WorldView.graphicsDevice.ScissorRectangle = rectangle;
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, WorldView.scissorTest, (Effect) view.screenProjection);
        int num5 = (int) this.mapX / (int) MiniMap.texWidth;
        int num6 = ((int) this.mapX + val1 - 1) / (int) MiniMap.texWidth;
        if (num6 >= this.mapTexture.Length)
          num6 = this.mapTexture.Length - 1;
        Vector2 vector2_1 = new Vector2((float) num1, (float) num2);
        Rectangle rect = new Rectangle();
        rect.X = (int) this.mapX - num5 * (int) MiniMap.texWidth;
        rect.Y = (int) this.mapY;
        rect.Width = Math.Min(val1, (int) MiniMap.texWidth - rect.X);
        rect.Height = (int) this.mapDestH;
        Color c = new Color(this.alpha, this.alpha, this.alpha, this.alpha);
        for (int index = num5; index <= num6; ++index)
        {
          Main.spriteBatch.Draw(this.mapTexture[index], vector2_1, new Rectangle?(rect), c);
          vector2_1.X += (float) rect.Width;
          rect.X = 0;
          rect.Width = (int) MiniMap.texWidth;
        }
        switch (Main.magmaBGFrame)
        {
          case 0:
            rect.X = 659;
            rect.Y = 10;
            break;
          case 1:
            rect.X = 659;
            rect.Y = 0;
            break;
          default:
            rect.X = 759;
            rect.Y = 10;
            break;
        }
        rect.Width = 10;
        rect.Height = 10;
        for (int index1 = 195; index1 >= 0; --index1)
        {
          NPC npc = Main.npc[index1];
          if ((int) npc.active != 0)
          {
            int index2 = npc.aabb.X >> 4;
            int index3 = npc.aabb.Y >> 4;
            if (index2 >= 0 && index3 >= 0 && (index2 < (int) Main.maxTilesX && index3 < (int) Main.maxTilesY) && (Main.tile[index2, index3].flags & Tile.Flags.VISITED) == Tile.Flags.VISITED)
            {
              int num7 = index2 - (34 + (int) this.mapX);
              if (num7 >= 0 && num7 + 4 < val1)
              {
                int num8 = index3 - (34 + (int) this.mapY);
                if (num8 >= 0 && num8 + 4 < (int) this.mapDestH)
                {
                  int headTextureId = npc.getHeadTextureId();
                  if (headTextureId < 0)
                  {
                    c = new Color(106, 0, 66, (int) sbyte.MaxValue);
                    c.R = (byte) ((int) c.R * (int) UI.cursorColor.A >> 8);
                    c.G = (byte) ((int) c.G * (int) UI.cursorColor.A >> 8);
                    c.B = (byte) ((int) c.B * (int) UI.cursorColor.A >> 8);
                    c.A = (byte) ((int) c.A * (int) UI.cursorColor.A >> 8);
                    SpriteSheet<_sheetSprites>.DrawCentered(218, num1 + num7, num2 + num8, rect, c);
                  }
                  else
                    SpriteSheet<_sheetSprites>.DrawScaled(1255 + headTextureId, num1 + num7, num2 + num8, 0.5f, new Color(248, 248, 248, 248), (int) npc.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
                }
              }
            }
          }
        }
        Main.spriteBatch.End();
        Matrix world = view.screenProjection.World;
        float num9 = (float) (11.0 / 16.0 + 1.0 / 16.0 * Math.Sin((double) Main.frameCounter * (1.0 / 12.0)));
        Matrix matrix2 = Matrix.CreateTranslation(-10f, -8f, 0.0f) * Matrix.CreateScale(num9, num9, 1f);
        for (int index1 = 7; index1 >= 0; --index1)
        {
          Player player = Main.player[index1];
          if ((int) player.active != 0 && !player.dead)
          {
            int index2 = player.aabb.X >> 4;
            int index3 = player.aabb.Y >> 4;
            if ((Main.tile[index2, index3].flags & Tile.Flags.VISITED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
            {
              int num7 = index2 - (34 + (int) this.mapX);
              int num8 = index3 - (34 + (int) this.mapY);
              Vector2 vector2_2 = player.position;
              player.position.X = (float) view.screenPosition.X;
              player.position.Y = (float) view.screenPosition.Y;
              view.screenProjection.World = matrix2 * Matrix.CreateTranslation((float) (num1 + num7), (float) (num2 + num8), 0.0f);
              Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, WorldView.scissorTest, (Effect) view.screenProjection);
              player.Draw(view, true, true);
              Main.spriteBatch.End();
              player.position = vector2_2;
              player.aabb.X = (int) vector2_2.X;
              player.aabb.Y = (int) vector2_2.Y;
            }
          }
        }
        view.screenProjection.World = world;
        view.screenProjection.View = Matrix.Identity;
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) view.screenProjection);
      }
    }
  }
}
