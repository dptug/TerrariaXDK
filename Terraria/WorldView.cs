// Type: Terraria.WorldView
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria
{
  public class WorldView : IDisposable
  {
    public static readonly short[] VIEW_WIDTH = new short[7]
    {
      (short) 960,
      (short) 960,
      (short) 960,
      (short) 960,
      (short) 960,
      (short) 1920,
      (short) 1920
    };
    public static readonly byte[] SAFE_AREA_OFFSETS = new byte[28]
    {
      (byte) 48,
      (byte) 27,
      (byte) 48,
      (byte) 27,
      (byte) 96,
      (byte) 54,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 54,
      (byte) 96,
      (byte) 0,
      (byte) 96,
      (byte) 0,
      (byte) 0,
      (byte) 54,
      (byte) 0,
      (byte) 0,
      (byte) 96,
      (byte) 54,
      (byte) 96,
      (byte) 54,
      (byte) 96,
      (byte) 0,
      (byte) 96,
      (byte) 0,
      (byte) 96,
      (byte) 54
    };
    public static readonly Viewport[] VIEWPORT = new Viewport[7]
    {
      new Viewport(0, 0, 960, 540),
      new Viewport(0, 0, 480, 270),
      new Viewport(480, 0, 480, 270),
      new Viewport(0, 270, 480, 270),
      new Viewport(480, 270, 480, 270),
      new Viewport(0, 0, 960, 270),
      new Viewport(0, 270, 960, 270)
    };
    public static Texture2D[] backgroundTexture = new Texture2D[32];
    private bool SMOOTH_LIGHT = true;
    private WorldView.Type viewType = WorldView.Type.NONE;
    public int SAFE_AREA_OFFSET_L = 48;
    public int SAFE_AREA_OFFSET_T = 27;
    public int SAFE_AREA_OFFSET_R = 48;
    public int SAFE_AREA_OFFSET_B = 27;
    private int currentSAFE_AREA_OFFSET_L = 48;
    private int currentSAFE_AREA_OFFSET_T = 27;
    private int currentSAFE_AREA_OFFSET_R = 48;
    private int currentSAFE_AREA_OFFSET_B = 27;
    private int targetSAFE_AREA_OFFSET_L = 48;
    private int targetSAFE_AREA_OFFSET_T = 27;
    private int targetSAFE_AREA_OFFSET_R = 48;
    private int targetSAFE_AREA_OFFSET_B = 27;
    public Rectangle clipArea = new Rectangle(0, 0, 0, 604);
    public Rectangle viewArea = new Rectangle(0, 0, 0, 540);
    public int quickBG = 2;
    public float[] bgAlpha = new float[8];
    public float[] bgAlpha2 = new float[8];
    public Lighting lighting = new Lighting();
    public int musicBox = -1;
    public bool[] drawNpcName = new bool[196];
    public Vector2i sceneWaterPos = new Vector2i();
    public Vector2i sceneTilePos = new Vector2i();
    public Vector2i sceneTile2Pos = new Vector2i();
    public Vector2i sceneWallPos = new Vector2i();
    public Vector2i sceneBackgroundPos = new Vector2i();
    public Vector2i sceneBlackPos = new Vector2i();
    private Matrix viewMtx = Matrix.Identity;
    private float worldScale = 1f;
    private float worldScaleTarget = 1f;
    private float worldScalePrevious = 1f;
    private WorldView.Spec[] spec = new WorldView.Spec[512];
    public const bool DRAW_TO_SCREEN = false;
    public const int OFFSCREEN_RANGE_X = 32;
    public const int OFFSCREEN_RANGE_TOP = 32;
    public const int OFFSCREEN_RANGE_BOTTOM = 64;
    public const int OFFSCREEN_RANGE_VERTICAL = 96;
    public const float CAVE_PARALLAX = 0.9f;
    public const float gfxQuality = 0.25f;
    private const double VIEWPORT_ANIM_STEPS = 30.0;
    private const double VIEWPORT_ANIM_THETA_DELTA = 0.0523598775598299;
    private const double ZOOM_ANIM_STEPS = 90.0;
    private const double ZOOM_ANIM_THETA_DELTA = 0.0174532925199433;
    private const int CLIP_AREA_EXTRA_WIDTH = 32;
    private const int CLIP_AREA_EXTRA_HEIGHT = 64;
    public const int MAX_BACKGROUNDS = 32;
    private bool isDisposed;
    public short viewWidth;
    private Viewport currentViewport;
    private Viewport targetViewport;
    public Viewport activeViewport;
    private double viewportAnimTheta;
    public Player player;
    public UI ui;
    public Time time;
    public float atmo;
    public short firstTileX;
    public short lastTileX;
    public short firstTileY;
    public short lastTileY;
    public Vector2i screenPosition;
    public Vector2i screenLastPosition;
    public int bgDelay;
    public int bgStyle;
    public DustPool dustLocal;
    public ItemTextPool itemTextLocal;
    public int inactiveTiles;
    public int sandTiles;
    public int evilTiles;
    public int snowTiles;
    public int holyTiles;
    public int meteorTiles;
    public int jungleTiles;
    public int dungeonTiles;
    private RenderTarget2D backWaterTarget;
    private RenderTarget2D waterTarget;
    private RenderTarget2D tileSolidTarget;
    private RenderTarget2D blackTarget;
    private RenderTarget2D tileNonSolidTarget;
    private RenderTarget2D wallTarget;
    private RenderTarget2D backgroundTarget;
    public static GraphicsDevice graphicsDevice;
    private static Matrix halfpixelOffset;
    private static Matrix centerWideSplitscreen;
    private BasicEffect renderTargetProjection;
    public BasicEffect screenProjection;
    public static RasterizerState scissorTest;
    private double worldScaleAnimTheta;

    static WorldView()
    {
    }

    public WorldView()
    {
      this.dustLocal = new DustPool(this, 128);
      this.itemTextLocal = new ItemTextPool(this);
      this.bgAlpha[0] = 1f;
      this.bgAlpha2[0] = 1f;
      this.renderTargetProjection = new BasicEffect(WorldView.graphicsDevice);
      this.renderTargetProjection.World = Matrix.Identity;
      this.renderTargetProjection.View = Matrix.Identity;
      this.renderTargetProjection.TextureEnabled = true;
      this.renderTargetProjection.VertexColorEnabled = true;
      this.screenProjection = new BasicEffect(WorldView.graphicsDevice);
      this.screenProjection.World = Matrix.Identity;
      this.screenProjection.View = Matrix.Identity;
      this.screenProjection.TextureEnabled = true;
      this.screenProjection.VertexColorEnabled = true;
    }

    public static WorldView.Type getViewType(PlayerIndex controller, UI newUI = null)
    {
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui == newUI || ui.view != null)
        {
          ++num2;
          if (ui.controller < controller)
            ++num1;
        }
      }
      switch (num2)
      {
        case 2:
          return (WorldView.Type) (5 + num1);
        case 3:
          if (num1 == 0)
            return WorldView.Type.TOP;
          return num1 == 1 ? WorldView.Type.BOTTOM_LEFT : WorldView.Type.BOTTOM_RIGHT;
        case 4:
          return (WorldView.Type) (1 + num1);
        default:
          return WorldView.Type.FULLSCREEN;
      }
    }

    public static bool AnyViewContains(int X, int Y)
    {
      int num = UI.numActiveViews;
      while (!UI.activeView[--num].clipArea.Contains(X, Y))
      {
        if (num <= 0)
          return false;
      }
      return true;
    }

    public static bool AnyViewIntersects(ref Rectangle rect)
    {
      int num = UI.numActiveViews;
      bool result;
      do
      {
        UI.activeView[--num].clipArea.Intersects(ref rect, out result);
      }
      while (!result && num > 0);
      return result;
    }

    public static void LoadContent(ContentManager Content)
    {
      for (int index = 3; index < 32; ++index)
        WorldView.backgroundTexture[index] = Content.Load<Texture2D>("Images/Background_" + (object) index);
    }

    public static void Initialize(GraphicsDevice device)
    {
      WorldView.graphicsDevice = device;
      Matrix.CreateTranslation(0.5f, 0.5f, 0.0f, out WorldView.halfpixelOffset);
      Matrix.CreateTranslation(480f, 0.0f, 0.0f, out WorldView.centerWideSplitscreen);
      WorldView.scissorTest = new RasterizerState();
      WorldView.scissorTest.ScissorTestEnable = true;
    }

    public void onStartGame()
    {
      this.lighting.StartWorkerThread();
    }

    public void onStopGame()
    {
      this.lighting.StopWorkerThread();
      this.itemTextLocal.Clear();
    }

    public bool setViewType(WorldView.Type type = WorldView.Type.FULLSCREEN)
    {
      if (type == this.viewType)
        return false;
      if (type != WorldView.Type.FULLSCREEN)
      {
        this.SMOOTH_LIGHT = false;
      }
      else
      {
        this.SMOOTH_LIGHT = true;
        this.Zoom(1f);
      }
      WorldView.Type type1 = this.viewType;
      bool flag = this.isFullScreen();
      int num = (int) this.viewWidth;
      this.viewType = type;
      if (type != WorldView.Type.NONE)
      {
        int width1 = (int) WorldView.VIEW_WIDTH[(int) type];
        if (num != width1)
        {
          this.viewWidth = (short) width1;
          this.clipArea.Width = width1 + 32;
          this.viewArea.Width = width1;
          this.lighting.SetWidth(width1);
        }
        this.currentViewport = this.activeViewport;
        this.targetViewport = WorldView.VIEWPORT[(int) type];
        this.currentSAFE_AREA_OFFSET_L = this.SAFE_AREA_OFFSET_L;
        this.currentSAFE_AREA_OFFSET_T = this.SAFE_AREA_OFFSET_T;
        this.currentSAFE_AREA_OFFSET_R = this.SAFE_AREA_OFFSET_R;
        this.currentSAFE_AREA_OFFSET_B = this.SAFE_AREA_OFFSET_B;
        this.targetSAFE_AREA_OFFSET_L = (int) WorldView.SAFE_AREA_OFFSETS[(int) type << 2];
        this.targetSAFE_AREA_OFFSET_T = (int) WorldView.SAFE_AREA_OFFSETS[((int) type << 2) + 1];
        this.targetSAFE_AREA_OFFSET_R = (int) WorldView.SAFE_AREA_OFFSETS[((int) type << 2) + 2];
        this.targetSAFE_AREA_OFFSET_B = (int) WorldView.SAFE_AREA_OFFSETS[((int) type << 2) + 3];
        if (type1 != WorldView.Type.NONE && flag == this.isFullScreen() && num == (int) this.viewWidth)
        {
          this.viewportAnimTheta = Math.PI / 2.0;
          return false;
        }
        else
        {
          this.SAFE_AREA_OFFSET_L = this.targetSAFE_AREA_OFFSET_L;
          this.SAFE_AREA_OFFSET_T = this.targetSAFE_AREA_OFFSET_T;
          this.SAFE_AREA_OFFSET_R = this.targetSAFE_AREA_OFFSET_R;
          this.SAFE_AREA_OFFSET_B = this.targetSAFE_AREA_OFFSET_B;
          this.activeViewport = this.targetViewport;
          this.viewportAnimTheta = 0.0;
          this.UpdateProjection();
          int width2 = (int) this.viewWidth + 64;
          int height = 636;
          if (this.backWaterTarget == null || this.backWaterTarget.Width != width2 || this.backWaterTarget.Height != height)
          {
            this.DisposeRendertargets();
            this.backWaterTarget = new RenderTarget2D(WorldView.graphicsDevice, width2, height, false, SurfaceFormat.Color, DepthFormat.None);
            this.waterTarget = new RenderTarget2D(WorldView.graphicsDevice, width2, height, false, SurfaceFormat.Color, DepthFormat.None);
            this.blackTarget = new RenderTarget2D(WorldView.graphicsDevice, width2, height, false, SurfaceFormat.Color, DepthFormat.None);
            this.tileSolidTarget = new RenderTarget2D(WorldView.graphicsDevice, width2, height, false, SurfaceFormat.Color, DepthFormat.None);
            this.tileNonSolidTarget = new RenderTarget2D(WorldView.graphicsDevice, width2, height, false, SurfaceFormat.Color, DepthFormat.None);
            this.wallTarget = new RenderTarget2D(WorldView.graphicsDevice, width2, height, false, SurfaceFormat.Color, DepthFormat.None);
            this.backgroundTarget = new RenderTarget2D(WorldView.graphicsDevice, width2, height, false, SurfaceFormat.Color, DepthFormat.None);
          }
          return true;
        }
      }
      else
      {
        this.DisposeRendertargets();
        return true;
      }
    }

    public void Dispose()
    {
      this.lighting.StopWorkerThread();
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void DisposeRendertargets()
    {
      if (this.backWaterTarget == null)
        return;
      this.backWaterTarget.Dispose();
      this.backWaterTarget = (RenderTarget2D) null;
      this.waterTarget.Dispose();
      this.waterTarget = (RenderTarget2D) null;
      this.tileSolidTarget.Dispose();
      this.tileSolidTarget = (RenderTarget2D) null;
      this.blackTarget.Dispose();
      this.blackTarget = (RenderTarget2D) null;
      this.tileNonSolidTarget.Dispose();
      this.tileNonSolidTarget = (RenderTarget2D) null;
      this.wallTarget.Dispose();
      this.wallTarget = (RenderTarget2D) null;
      this.backgroundTarget.Dispose();
      this.backgroundTarget = (RenderTarget2D) null;
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.isDisposed)
        return;
      if (disposing)
        this.DisposeRendertargets();
      this.isDisposed = true;
    }

    public bool isFullScreen()
    {
      return this.viewType == WorldView.Type.FULLSCREEN;
    }

    public static void restoreViewport()
    {
      WorldView.graphicsDevice.Viewport = WorldView.VIEWPORT[0];
    }

    public void PrepareDraw(int pass)
    {
      this.screenLastPosition = this.screenPosition;
      this.player.updateScreenPosition();
      if (this.screenPosition.X < 560)
        this.screenPosition.X = 560;
      else if (this.screenPosition.X + (int) this.viewWidth > Main.rightWorld - 544 - 32)
        this.screenPosition.X = Main.rightWorld - (int) this.viewWidth - 544 - 32;
      if (this.screenPosition.Y < 560)
        this.screenPosition.Y = 560;
      else if (this.screenPosition.Y + 540 > Main.bottomWorld - 544 - 32)
        this.screenPosition.Y = Main.bottomWorld - 540 - 544 - 32;
      this.viewArea.X = this.screenPosition.X;
      this.viewArea.Y = this.screenPosition.Y;
      this.clipArea.X = this.screenPosition.X - 16;
      this.clipArea.Y = this.screenPosition.Y - 32;
      this.firstTileX = (short) (this.screenPosition.X >> 4);
      this.firstTileY = (short) (this.screenPosition.Y >> 4);
      this.lastTileX = (short) ((int) this.firstTileX + ((int) this.viewWidth >> 4));
      if ((int) this.lastTileX > (int) Main.maxTilesX)
        this.lastTileX = Main.maxTilesX;
      this.lastTileY = (short) ((int) this.firstTileY + 33);
      if ((int) this.lastTileY > (int) Main.maxTilesY)
        this.lastTileY = Main.maxTilesY;
      this.lighting.LightTiles(this);
      this.firstTileX -= (short) 2;
      if ((int) this.firstTileX < 0)
        this.firstTileX = (short) 0;
      this.firstTileY -= (short) 2;
      if ((int) this.firstTileY < 0)
        this.firstTileY = (short) 0;
      this.lastTileX += (short) 2;
      if ((int) this.lastTileX > (int) Main.maxTilesX)
        this.lastTileX = Main.maxTilesX;
      this.lastTileY += (short) 4;
      if ((int) this.lastTileY > (int) Main.maxTilesY)
        this.lastTileY = Main.maxTilesY;
      if (pass > 0)
      {
        Vector2i vector2i = this.screenPosition;
        this.screenPosition.X &= -2;
        this.screenPosition.Y &= -2;
        if (pass == 1)
          this.RenderBackground();
        else if (pass == 2)
        {
          if ((int) this.firstTileY <= Main.worldSurface)
            this.RenderBlack();
          this.RenderSolidTiles();
        }
        else if (pass == 3)
        {
          this.RenderWalls();
        }
        else
        {
          this.RenderNonSolidTiles();
          this.RenderBackWater();
          this.RenderWater();
        }
        this.screenPosition = vector2i;
      }
      if (this.worldScaleAnimTheta > 0.0)
      {
        this.worldScaleAnimTheta -= Math.PI / 180.0;
        this.worldScale = this.worldScaleAnimTheta > 0.0 ? this.worldScalePrevious + (float) ((1.0 - Math.Sin(this.worldScaleAnimTheta)) * ((double) this.worldScaleTarget - (double) this.worldScalePrevious)) : this.worldScaleTarget;
        this.UpdateView();
      }
      this.screenProjection.View = this.viewMtx;
    }

    public void Zoom(float z)
    {
      if ((double) z == (double) this.worldScaleTarget)
        return;
      this.worldScaleTarget = z;
      this.worldScalePrevious = this.worldScale;
      this.worldScaleAnimTheta = Math.PI / 2.0;
    }

    private void UpdateProjection()
    {
      this.screenProjection.Projection = !this.isFullScreen() ? WorldView.halfpixelOffset * Matrix.CreateOrthographicOffCenter(0.0f, (float) (this.activeViewport.Width << 1), (float) (this.activeViewport.Height << 1), 0.0f, 0.0f, 1f) : WorldView.halfpixelOffset * Matrix.CreateOrthographicOffCenter(0.0f, (float) this.activeViewport.Width, (float) this.activeViewport.Height, 0.0f, 0.0f, 1f);
      this.renderTargetProjection.Projection = WorldView.halfpixelOffset * Matrix.CreateOrthographicOffCenter(0.0f, (float) ((int) this.viewWidth + 64), 636f, 0.0f, 0.0f, 1f);
    }

    private void UpdateView()
    {
      int num1 = (int) this.viewWidth;
      int num2 = 540;
      int num3 = num1 >> 1;
      int num4 = num2 >> 1;
      this.viewMtx = Matrix.CreateTranslation((float) -num3, (float) -num4, 0.0f) * Matrix.CreateScale(this.worldScale, this.worldScale, 1f) * Matrix.CreateTranslation((float) num3, (float) num4, 0.0f);
    }

    public void SetWorldView()
    {
      Main.spriteBatch.End();
      this.screenProjection.View = this.viewMtx;
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.screenProjection);
    }

    public void SetScreenView()
    {
      Main.spriteBatch.End();
      this.screenProjection.View = Matrix.Identity;
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.screenProjection);
    }

    public void SetScreenViewWideCentered()
    {
      Main.spriteBatch.End();
      this.screenProjection.View = (int) this.viewWidth == 960 ? Matrix.Identity : WorldView.centerWideSplitscreen;
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.screenProjection);
    }

    private void DrawCombatText()
    {
      for (int index1 = 0; index1 < 32; ++index1)
      {
        if ((int) Main.combatText[index1].active != 0)
        {
          Vector2 pivot = Main.combatText[index1].textSize;
          pivot.X *= 0.5f;
          pivot.Y *= 0.5f;
          int index2 = Main.combatText[index1].crit ? 1 : 0;
          float scale = Main.combatText[index1].scale;
          float num = Main.combatText[index1].alpha * scale;
          Color c = new Color(num, num, num, num);
          Vector2 pos = Main.combatText[index1].position;
          pos.X += pivot.X;
          pos.X -= (float) this.screenPosition.X;
          pos.Y += pivot.Y;
          pos.Y -= (float) this.screenPosition.Y;
          UI.DrawString(UI.fontCombatText[index2], Main.combatText[index1].text, pos, c, Main.combatText[index1].rotation, pivot, scale);
        }
      }
    }

    private void DrawItemText()
    {
      for (int index = 0; index < 4; ++index)
      {
        if ((int) this.itemTextLocal.itemText[index].active != 0)
        {
          Vector2 pivot = this.itemTextLocal.itemText[index].textSize;
          pivot.X *= 0.5f;
          pivot.Y *= 0.5f;
          float num1 = (float) this.itemTextLocal.itemText[index].color.R;
          float num2 = (float) this.itemTextLocal.itemText[index].color.G;
          float num3 = (float) this.itemTextLocal.itemText[index].color.B;
          float num4 = (float) this.itemTextLocal.itemText[index].color.A;
          float scale = this.itemTextLocal.itemText[index].scale;
          double num5 = (double) this.itemTextLocal.itemText[index].alpha;
          float num6 = num1 * scale;
          float num7 = num3 * scale;
          float num8 = num2 * scale;
          float num9 = num4 * scale;
          Vector2 pos = this.itemTextLocal.itemText[index].position;
          pos.X += pivot.X;
          pos.X -= (float) this.screenPosition.X;
          pos.Y += pivot.Y;
          pos.Y -= (float) this.screenPosition.Y;
          UI.DrawStringScaled(UI.fontSmallOutline, this.itemTextLocal.itemText[index].text, pos, new Color((int) num6, (int) num8, (int) num7, (int) num9), pivot, scale);
        }
      }
    }

    private void DrawProjectiles()
    {
      for (int index = 511; index >= 0; --index)
      {
        if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].type > 0 && !Main.projectile[index].hide)
          Main.projectile[index].Draw(this);
      }
    }

    private void DrawPlayers()
    {
      for (int index = 0; index < 8; ++index)
      {
        Player player = Main.player[index];
        if ((int) player.active != 0)
        {
          if (player.ghost)
          {
            Vector2 vector2 = player.position;
            player.position = player.shadowPos[0];
            player.shadow = 0.5f;
            player.DrawGhost(this);
            player.position = player.shadowPos[1];
            player.shadow = 0.7f;
            player.DrawGhost(this);
            player.position = player.shadowPos[2];
            player.shadow = 0.9f;
            player.DrawGhost(this);
            player.position = vector2;
            player.shadow = 0.0f;
            player.DrawGhost(this);
          }
          else
          {
            bool flag1 = false;
            bool flag2 = false;
            if ((int) player.legs == 25)
              flag1 = true;
            else if ((int) player.head == 5 && (int) player.body == 5 && (int) player.legs == 5)
              flag1 = true;
            else if ((int) player.head == 7 && (int) player.body == 7 && (int) player.legs == 7)
              flag1 = true;
            else if ((int) player.head == 22 && (int) player.body == 14 && (int) player.legs == 14)
              flag1 = true;
            else if ((int) player.body == 17 && (int) player.legs == 16 && ((int) player.head == 29 || (int) player.head == 30 || (int) player.head == 31))
              flag1 = true;
            if ((int) player.legs == 26)
              flag2 = true;
            else if ((int) player.body == 19 && (int) player.legs == 18)
            {
              if ((int) player.head == 35 || (int) player.head == 36 || (int) player.head == 37)
                flag2 = true;
            }
            else if ((int) player.body == 24 && (int) player.legs == 23 && ((int) player.head == 41 || (int) player.head == 42 || (int) player.head == 43))
            {
              flag2 = true;
              flag1 = true;
            }
            if (flag2)
            {
              Vector2 vector2 = player.position;
              player.ghostFade += player.ghostDir * 0.075f;
              if ((double) player.ghostFade < 0.100000001490116)
              {
                player.ghostDir = 1f;
                player.ghostFade = 0.1f;
              }
              if ((double) player.ghostFade > 0.899999976158142)
              {
                player.ghostDir = -1f;
                player.ghostFade = 0.9f;
              }
              player.position.X = vector2.X - player.ghostFade * 5f;
              player.shadow = player.ghostFade;
              player.Draw(this, false, false);
              player.position.X = vector2.X + player.ghostFade * 5f;
              player.shadow = player.ghostFade;
              player.Draw(this, false, false);
              player.position = vector2;
              player.position.Y = vector2.Y - player.ghostFade * 5f;
              player.shadow = player.ghostFade;
              player.Draw(this, false, false);
              player.position.Y = vector2.Y + player.ghostFade * 5f;
              player.shadow = player.ghostFade;
              player.Draw(this, false, false);
              player.position = vector2;
              player.shadow = 0.0f;
            }
            if (flag1)
            {
              Vector2 vector2 = player.position;
              player.position = player.shadowPos[0];
              player.shadow = 0.5f;
              player.Draw(this, false, false);
              player.position = player.shadowPos[1];
              player.shadow = 0.7f;
              player.Draw(this, false, false);
              player.position = player.shadowPos[2];
              player.shadow = 0.9f;
              player.Draw(this, false, false);
              player.position = vector2;
              player.shadow = 0.0f;
            }
            player.Draw(this, false, false);
          }
        }
      }
    }

    private unsafe void DrawItems()
    {
      Rectangle rectangle = new Rectangle();
      Vector2 pos = new Vector2();
      fixed (Item* objPtr1 = Main.item)
      {
        Item* objPtr2 = objPtr1;
        for (int index = 199; index >= 0; --index)
        {
          if ((int) objPtr2->active != 0)
          {
            int X = (int) objPtr2->position.X;
            int Y = (int) objPtr2->position.Y;
            int id = 451 + (int) objPtr2->type;
            rectangle.Width = SpriteSheet<_sheetSprites>.src[id].Width;
            rectangle.Height = SpriteSheet<_sheetSprites>.src[id].Height;
            rectangle.X = X + ((int) objPtr2->width >> 1);
            rectangle.Y = Y + (rectangle.Height >> 1) + (int) objPtr2->height - rectangle.Height + 2;
            if (rectangle.Intersects(this.viewArea))
            {
              Color colorUnsafe = this.lighting.GetColorUnsafe(X + ((int) objPtr2->width >> 1) >> 4, Y + ((int) objPtr2->height >> 1) >> 4);
              if ((objPtr2->CanBePlacedInCoinSlot() || (int) objPtr2->type == 58 || (int) objPtr2->type == 109) && (Main.hasFocus && (int) colorUnsafe.R > 60 && (double) ((float) Main.rand.Next(500) - (float) (((double) Math.Abs(objPtr2->velocity.X) + (double) Math.Abs(objPtr2->velocity.Y)) * 10.0)) < (double) colorUnsafe.R * 0.0199999995529652))
              {
                Dust* dustPtr = this.dustLocal.NewDust(X, Y, (int) objPtr2->width, (int) objPtr2->height, 43, 0.0, 0.0, 254, new Color(), 0.5);
                if ((IntPtr) dustPtr != IntPtr.Zero)
                {
                  dustPtr->velocity.X = 0.0f;
                  dustPtr->velocity.Y = 0.0f;
                }
              }
              float rot = objPtr2->velocity.X * 0.2f;
              float scale = 1f;
              Color alpha = objPtr2->GetAlpha(colorUnsafe);
              if ((int) objPtr2->type == 58 || (int) objPtr2->type == 184)
              {
                scale = (float) ((double) UI.essScale * 0.25 + 0.75);
                alpha.R = (byte) ((double) alpha.R * (double) scale);
                alpha.G = (byte) ((double) alpha.G * (double) scale);
                alpha.B = (byte) ((double) alpha.B * (double) scale);
                alpha.A = (byte) ((double) alpha.A * (double) scale);
              }
              else if ((int) objPtr2->type == 520 || (int) objPtr2->type == 521 || ((int) objPtr2->type == 547 || (int) objPtr2->type == 548) || ((int) objPtr2->type == 549 || (int) objPtr2->type == 575 || (int) objPtr2->type == 620))
              {
                scale = UI.essScale;
                alpha.R = (byte) ((double) alpha.R * (double) scale);
                alpha.G = (byte) ((double) alpha.G * (double) scale);
                alpha.B = (byte) ((double) alpha.B * (double) scale);
                alpha.A = (byte) ((double) alpha.A * (double) scale);
              }
              pos.X = (float) (rectangle.X - this.screenPosition.X);
              pos.Y = (float) (rectangle.Y - this.screenPosition.Y);
              SpriteSheet<_sheetSprites>.Draw(id, ref pos, alpha, rot, scale);
              if ((int) objPtr2->color.PackedValue != 0)
                SpriteSheet<_sheetSprites>.Draw(id, ref pos, objPtr2->GetColor(colorUnsafe), rot, scale);
            }
          }
          ++objPtr2;
        }
      }
    }

    private unsafe void DrawBlack()
    {
      float num1 = (float) (((double) this.time.tileColorf.X + (double) this.time.tileColorf.Y + (double) this.time.tileColorf.Z) * 0.133333340287209);
      Rectangle dest = new Rectangle();
      dest.X = 32 + ((int) this.firstTileX << 4) - this.screenPosition.X;
      dest.Width = 16;
      Color black = Color.Black;
      int num2 = (int) this.lastTileY - 1;
      if (num2 > Main.worldSurface)
        num2 = Main.worldSurface;
      for (int x = (int) this.firstTileX; x < (int) this.lastTileX; ++x)
      {
        int y = (int) this.firstTileY;
        fixed (Tile* tilePtr1 = &Main.tile[x, y])
        {
          Tile* tilePtr2 = tilePtr1;
          while (true)
          {
            float num3 = this.lighting.BrightnessUnsafe(x, y);
            if ((double) num3 < (double) num1 && ((double) num3 == 0.0 || (int) tilePtr2->liquid == 0 || (int) tilePtr2->active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr2->type]))
            {
              if (dest.Height == 0)
                dest.Y = 32 + (y << 4) - this.screenPosition.Y;
              dest.Height += 16;
            }
            else if (dest.Height > 0)
            {
              SpriteSheet<_sheetTiles>.DrawStretchedY(7, ref dest, black);
              dest.Height = 0;
            }
            if (++y <= num2)
              ++tilePtr2;
            else
              break;
          }
          if (dest.Height > 0)
          {
            SpriteSheet<_sheetTiles>.DrawStretchedY(7, ref dest, black);
            dest.Height = 0;
          }
        }
        dest.X += 16;
      }
    }

    private unsafe void DrawWalls()
    {
      Vector2 pos = new Vector2();
      Color color = new Color();
      Rectangle s = new Rectangle();
      int num1 = (int) this.firstTileX;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        do
        {
          int num2 = (int) this.firstTileY;
          Tile* tilePtr2 = tilePtr1 + (num1 * 1440 + num2);
          do
          {
            int num3 = (int) tilePtr2->wall;
            tilePtr2->flags |= Tile.Flags.VISITED;
            if (num3 > 0 && !tilePtr2->isFullTile())
            {
              Color colorUnsafe1 = this.lighting.GetColorUnsafe(num1, num2);
              int id = 186 + num3;
              s.X = (int) tilePtr2->wallFrameX << 1;
              s.Y = (int) tilePtr2->wallFrameY << 1;
              s.Width = 32;
              s.Height = 32;
              pos.X = (float) (num1 * 16 - this.screenPosition.X - 8 + 32);
              pos.Y = (float) (num2 * 16 - this.screenPosition.Y - 8 + 32);
              if (this.SMOOTH_LIGHT && num3 != 21 && !WorldGen.SolidTile(num1, num2))
              {
                if ((int) colorUnsafe1.R > 216 || (double) colorUnsafe1.G > 237.6 || (double) colorUnsafe1.B > 259.2)
                {
                  s.Width = 12;
                  s.Height = 12;
                  Color colorUnsafe2 = this.lighting.GetColorUnsafe(num1 - 1, num2 - 1);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.X += 12f;
                  s.X += 12;
                  s.Width = 8;
                  colorUnsafe2 = this.lighting.GetColorUnsafe(num1, num2 - 1);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.X += 8f;
                  s.X += 8;
                  s.Width = 12;
                  colorUnsafe2 = this.lighting.GetColorUnsafe(num1 + 1, num2 - 1);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.Y += 12f;
                  s.Y += 12;
                  s.Height = 8;
                  colorUnsafe2 = this.lighting.GetColorUnsafe(num1 + 1, num2);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.X -= 8f;
                  s.X -= 8;
                  s.Width = 8;
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.X -= 12f;
                  s.X -= 12;
                  s.Width = 12;
                  colorUnsafe2 = this.lighting.GetColorUnsafe(num1 - 1, num2);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.Y += 8f;
                  s.Y += 8;
                  s.Height = 12;
                  colorUnsafe2 = this.lighting.GetColorUnsafe(num1 - 1, num2 + 1);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.X += 12f;
                  s.X += 12;
                  s.Width = 8;
                  colorUnsafe2 = this.lighting.GetColorUnsafe(num1, num2 + 1);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                  pos.X += 8f;
                  s.X += 8;
                  s.Width = 12;
                  colorUnsafe2 = this.lighting.GetColorUnsafe(num1 + 1, num2 + 1);
                  colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                  colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                  colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe2);
                }
                else if ((int) colorUnsafe1.R > 100 || (double) colorUnsafe1.G > 110 || (double) colorUnsafe1.B > 120.0)
                {
                  s.Width = 16;
                  s.Height = 16;
                  Color c = this.lighting.Brighter(num1, num2 - 1, num1 - 1, num2) ? this.lighting.GetColorUnsafe(num1 - 1, num2) : this.lighting.GetColorUnsafe(num1, num2 - 1);
                  c.R = (byte) ((int) colorUnsafe1.R + (int) c.R >> 1);
                  c.G = (byte) ((int) colorUnsafe1.G + (int) c.G >> 1);
                  c.B = (byte) ((int) colorUnsafe1.B + (int) c.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
                  s.X += 16;
                  pos.X += 16f;
                  c = this.lighting.Brighter(num1, num2 - 1, num1 + 1, num2) ? this.lighting.GetColorUnsafe(num1 + 1, num2) : this.lighting.GetColorUnsafe(num1, num2 - 1);
                  c.R = (byte) ((int) colorUnsafe1.R + (int) c.R >> 1);
                  c.G = (byte) ((int) colorUnsafe1.G + (int) c.G >> 1);
                  c.B = (byte) ((int) colorUnsafe1.B + (int) c.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
                  s.Y += 16;
                  pos.Y += 16f;
                  c = this.lighting.Brighter(num1, num2 + 1, num1 + 1, num2) ? this.lighting.GetColorUnsafe(num1 + 1, num2) : this.lighting.GetColorUnsafe(num1, num2 + 1);
                  c.R = (byte) ((int) colorUnsafe1.R + (int) c.R >> 1);
                  c.G = (byte) ((int) colorUnsafe1.G + (int) c.G >> 1);
                  c.B = (byte) ((int) colorUnsafe1.B + (int) c.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
                  s.X -= 16;
                  pos.X -= 16f;
                  c = this.lighting.Brighter(num1, num2 + 1, num1 - 1, num2) ? this.lighting.GetColorUnsafe(num1 - 1, num2) : this.lighting.GetColorUnsafe(num1, num2 + 1);
                  c.R = (byte) ((int) colorUnsafe1.R + (int) c.R >> 1);
                  c.G = (byte) ((int) colorUnsafe1.G + (int) c.G >> 1);
                  c.B = (byte) ((int) colorUnsafe1.B + (int) c.B >> 1);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
                }
                else
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe1);
              }
              else
                SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe1);
            }
            ++tilePtr2;
          }
          while (++num2 < (int) this.lastTileY);
        }
        while (++num1 < (int) this.lastTileX);
      }
    }

    private unsafe void DrawWires()
    {
      Rectangle s1 = new Rectangle();
      s1.Width = 16;
      s1.Height = 16;
      Vector2 pos = new Vector2();
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int x = (int) this.firstTileX; x < (int) this.lastTileX; ++x)
        {
          pos.X = (float) (32 + x * 16 - this.screenPosition.X);
          Tile* tilePtr2 = tilePtr1 + (x * 1440 + (int) this.firstTileY);
          int num1 = (int) this.firstTileY;
          while (num1 < (int) this.lastTileY)
          {
            if (tilePtr2->wire != 0)
            {
              pos.Y = (float) (32 + num1 * 16 - this.screenPosition.Y);
              if (this.lighting.IsNotBlackUnsafe(x, num1))
              {
                Tile* tilePtr3 = tilePtr2 - 1;
                int wire1 = tilePtr3->wire;
                Tile* tilePtr4 = tilePtr3 + 2;
                int wire2 = tilePtr4->wire;
                Tile* tilePtr5 = tilePtr4 - 1441;
                int wire3 = tilePtr5->wire;
                Tile* tilePtr6 = tilePtr5 + 2880;
                int wire4 = tilePtr6->wire;
                tilePtr2 = tilePtr6 - 1440;
                if (wire1 != 0)
                {
                  if (wire2 != 0)
                  {
                    if (wire3 != 0)
                    {
                      if (wire4 != 0)
                      {
                        s1.X = 18;
                        s1.Y = 18;
                      }
                      else
                      {
                        s1.X = 54;
                        s1.Y = 0;
                      }
                    }
                    else if (wire4 != 0)
                    {
                      s1.X = 36;
                      s1.Y = 0;
                    }
                    else
                    {
                      s1.X = 0;
                      s1.Y = 0;
                    }
                  }
                  else if (wire3 != 0)
                  {
                    if (wire4 != 0)
                    {
                      s1.X = 0;
                      s1.Y = 18;
                    }
                    else
                    {
                      s1.X = 54;
                      s1.Y = 18;
                    }
                  }
                  else if (wire4 != 0)
                  {
                    s1.X = 36;
                    s1.Y = 18;
                  }
                  else
                  {
                    s1.X = 36;
                    s1.Y = 36;
                  }
                }
                else if (wire2 != 0)
                {
                  if (wire3 != 0)
                  {
                    if (wire4 != 0)
                    {
                      s1.X = 72;
                      s1.Y = 0;
                    }
                    else
                    {
                      s1.X = 72;
                      s1.Y = 18;
                    }
                  }
                  else if (wire4 != 0)
                  {
                    s1.X = 0;
                    s1.Y = 36;
                  }
                  else
                  {
                    s1.X = 18;
                    s1.Y = 36;
                  }
                }
                else if (wire3 != 0)
                {
                  if (wire4 != 0)
                  {
                    s1.X = 18;
                    s1.Y = 0;
                  }
                  else
                  {
                    s1.X = 54;
                    s1.Y = 36;
                  }
                }
                else if (wire4 != 0)
                {
                  s1.X = 72;
                  s1.Y = 36;
                }
                else
                {
                  s1.X = 0;
                  s1.Y = 54;
                }
                Color colorUnsafe = this.lighting.GetColorUnsafe(x, num1);
                if (this.SMOOTH_LIGHT && ((int) colorUnsafe.R > 38 || (double) colorUnsafe.G > 41.8 || (double) colorUnsafe.B > 45.6))
                {
                  for (int index = 0; index < 4; ++index)
                  {
                    int num2 = 0;
                    int num3 = 0;
                    Color c = colorUnsafe;
                    Color color = colorUnsafe;
                    if (index == 0)
                      color = !this.lighting.Brighter(x, num1 - 1, x - 1, num1) ? this.lighting.GetColorUnsafe(x, num1 - 1) : this.lighting.GetColorUnsafe(x - 1, num1);
                    else if (index == 1)
                    {
                      color = !this.lighting.Brighter(x, num1 - 1, x + 1, num1) ? this.lighting.GetColorUnsafe(x, num1 - 1) : this.lighting.GetColorUnsafe(x + 1, num1);
                      num2 = 8;
                    }
                    else if (index == 2)
                    {
                      color = !this.lighting.Brighter(x, num1 + 1, x - 1, num1) ? this.lighting.GetColorUnsafe(x, num1 + 1) : this.lighting.GetColorUnsafe(x - 1, num1);
                      num3 = 8;
                    }
                    else
                    {
                      color = !this.lighting.Brighter(x, num1 + 1, x + 1, num1) ? this.lighting.GetColorUnsafe(x, num1 + 1) : this.lighting.GetColorUnsafe(x + 1, num1);
                      num2 = 8;
                      num3 = 8;
                    }
                    c.R = (byte) ((int) colorUnsafe.R + (int) color.R >> 1);
                    c.G = (byte) ((int) colorUnsafe.G + (int) color.G >> 1);
                    c.B = (byte) ((int) colorUnsafe.B + (int) color.B >> 1);
                    Rectangle s2 = s1;
                    s2.X += num2;
                    s2.Y += num3;
                    s2.Width = 8;
                    s2.Height = 8;
                    pos.X += (float) num2;
                    pos.Y += (float) num3;
                    SpriteSheet<_sheetTiles>.Draw(218, ref pos, ref s2, c);
                    pos.X -= (float) num2;
                    pos.Y -= (float) num3;
                  }
                }
                else
                  SpriteSheet<_sheetTiles>.Draw(218, ref pos, ref s1, colorUnsafe);
              }
            }
            ++num1;
            ++tilePtr2;
          }
        }
      }
    }

    public void DrawBg(UI ui)
    {
      // ISSUE: unable to decompile the method.
    }

    public void DrawWorld()
    {
      Color white = Color.White;
      Rectangle destinationRectangle = new Rectangle();
      destinationRectangle.Width = (int) this.viewWidth + 64;
      destinationRectangle.Height = 636;
      destinationRectangle.X = this.sceneWaterPos.X - this.screenPosition.X;
      destinationRectangle.Y = this.sceneWaterPos.Y - this.screenPosition.Y;
      Main.spriteBatch.Draw((Texture2D) this.backWaterTarget, destinationRectangle, white);
      destinationRectangle.X = (int) ((double) (this.sceneBackgroundPos.X - this.screenPosition.X + 32) * 0.899999976158142) - 32;
      destinationRectangle.Y = this.sceneBackgroundPos.Y - this.screenPosition.Y;
      Main.spriteBatch.Draw((Texture2D) this.backgroundTarget, destinationRectangle, white);
      if ((int) this.firstTileY <= Main.worldSurface)
      {
        destinationRectangle.X = this.sceneBlackPos.X - this.screenPosition.X;
        destinationRectangle.Y = this.sceneBlackPos.Y - this.screenPosition.Y;
        Main.spriteBatch.Draw((Texture2D) this.blackTarget, destinationRectangle, white);
      }
      destinationRectangle.X = this.sceneWallPos.X - this.screenPosition.X;
      destinationRectangle.Y = this.sceneWallPos.Y - this.screenPosition.Y;
      Main.spriteBatch.Draw((Texture2D) this.wallTarget, destinationRectangle, white);
      this.DrawWoF();
      destinationRectangle.X = this.sceneTile2Pos.X - this.screenPosition.X;
      destinationRectangle.Y = this.sceneTile2Pos.Y - this.screenPosition.Y;
      Main.spriteBatch.Draw((Texture2D) this.tileNonSolidTarget, destinationRectangle, white);
      destinationRectangle.X = this.sceneTilePos.X - this.screenPosition.X;
      destinationRectangle.Y = this.sceneTilePos.Y - this.screenPosition.Y;
      if (this.player.detectCreature)
      {
        Main.spriteBatch.Draw((Texture2D) this.tileSolidTarget, destinationRectangle, white);
        this.DrawGore();
        this.DrawNPCs(true);
        this.DrawNPCs(false);
      }
      else
      {
        this.DrawNPCs(true);
        Main.spriteBatch.Draw((Texture2D) this.tileSolidTarget, destinationRectangle, white);
        this.DrawGore();
        this.DrawNPCs(false);
      }
      this.DrawProjectiles();
      this.DrawPlayers();
      this.DrawItems();
      this.dustLocal.DrawDust(this);
      Main.dust.DrawDust(this);
      destinationRectangle.X = this.sceneWaterPos.X - this.screenPosition.X;
      destinationRectangle.Y = this.sceneWaterPos.Y - this.screenPosition.Y;
      Main.spriteBatch.Draw((Texture2D) this.waterTarget, destinationRectangle, white);
      this.DrawCombatText();
      this.DrawItemText();
    }

    private unsafe void DrawBackground()
    {
      float num1 = 0.9f;
      float num2 = 0.9f;
      float num3 = 0.9f;
      float num4 = 0.0f;
      if (this.holyTiles > this.evilTiles)
        num4 = (float) this.holyTiles * (1.0 / 800.0);
      else if (this.evilTiles > this.holyTiles)
        num4 = (float) this.evilTiles * (1.0 / 800.0);
      if ((double) num4 > 1.0)
        num4 = 1f;
      float num5 = (float) (this.screenPosition.Y - (Main.worldSurface << 4)) * (1.0 / 300.0);
      if ((double) num5 < 0.0)
        num5 = 0.0f;
      else if ((double) num5 > 1.0)
        num5 = 1f;
      float num6 = (float) (1.0 - (double) num5 + (double) num1 * (double) num5);
      this.lighting.brightness = (float) ((double) this.lighting.defBrightness * (1.0 - (double) num5) + 1.0 * (double) num5);
      float num7 = (float) (this.screenPosition.Y - 270 + 200 - (Main.rockLayer << 4)) * (1.0 / 300.0);
      if ((double) num7 < 0.0)
        num7 = 0.0f;
      else if ((double) num7 > 1.0)
        num7 = 1f;
      if (this.evilTiles > 0)
      {
        num1 = (float) (0.800000011920929 * (double) num4 + (double) num1 * (1.0 - (double) num4));
        num2 = (float) (0.75 * (double) num4 + (double) num2 * (1.0 - (double) num4));
        num3 = (float) (1.10000002384186 * (double) num4 + (double) num3 * (1.0 - (double) num4));
      }
      else if (this.holyTiles > 0)
      {
        num1 = (float) (1.0 * (double) num4 + (double) num1 * (1.0 - (double) num4));
        num2 = (float) (0.699999988079071 * (double) num4 + (double) num2 * (1.0 - (double) num4));
        num3 = (float) (0.899999976158142 * (double) num4 + (double) num3 * (1.0 - (double) num4));
      }
      float num8 = (float) ((double) num6 - (double) num7 + (double) num1 * (double) num7);
      float num9 = (float) ((double) num6 - (double) num7 + (double) num2 * (double) num7);
      float num10 = (float) ((double) num6 - (double) num7 + (double) num3 * (double) num7);
      this.lighting.defBrightness = (float) (1.20000004768372 * (1.0 - (double) num7)) + num7;
      int num11 = (int) (-Math.IEEERemainder((double) this.screenPosition.X * 0.899999976158142, 96.0) - 48.0);
      int num12 = (int) this.viewWidth / 96 + 2;
      int num13 = Main.worldSurfacePixels - this.screenPosition.Y;
      int num14 = num11;
      int num15 = -(num11 + this.screenPosition.X + 8 & 15);
      if (num15 == -8)
        num15 = 8;
      Vector2 pos1 = new Vector2((float) (num14 + num15 + 32), (float) (num13 + 32));
      Rectangle s1 = new Rectangle();
      s1.X = num15;
      s1.Width = 16;
      s1.Height = 16;
      for (int index = 0; index < num12; ++index)
      {
        int num16 = 15;
        while (num16 >= 0)
        {
          Color color = this.lighting.GetColor(num14 + 8 + this.screenPosition.X >> 4, this.screenPosition.Y + num13 >> 4);
          color.R = (byte) ((double) color.R * (double) num8);
          color.G = (byte) ((double) color.G * (double) num9);
          color.B = (byte) ((double) color.B * (double) num10);
          s1.X += 16;
          SpriteSheet<_sheetTiles>.Draw(1, ref pos1, ref s1, color);
          --num16;
          num14 += 16;
        }
      }
      bool flag1 = false;
      if (Main.worldSurfacePixels <= this.screenPosition.Y + 540 + 32)
      {
        int num16 = (Main.worldSurface << 4) - this.screenPosition.Y + 16;
        int num17 = (int) (-Math.IEEERemainder((double) this.screenPosition.X * 0.899999976158142, 96.0) - 48.0) - 32;
        int num18 = ((int) this.viewWidth + 64) / 96 + 2;
        int num19;
        int num20;
        if (Main.worldSurfacePixels < this.screenPosition.Y - 16)
        {
          num19 = num16 % 96 - 96;
          num20 = (540 - num19 + 96) / 96 + 1;
        }
        else
        {
          num19 = num16;
          num20 = (540 - num16 + 96) / 96 + 1;
        }
        if (Main.rockLayerPixels < this.screenPosition.Y + 540)
        {
          num20 = (Main.rockLayerPixels - this.screenPosition.Y + 540 - num19) / 96;
          flag1 = true;
        }
        int num21 = -(num17 + this.screenPosition.X & 15);
        if (num21 == -8)
          num21 = 8;
        Vector2 pos2 = new Vector2();
        Rectangle s2 = new Rectangle();
        s2.Width = 16;
        s2.Height = 16;
        int num22 = 0;
        int num23 = num17 + 8 + this.screenPosition.X;
        for (; num22 < num18; ++num22)
        {
          int index1 = num19 + 8 + this.screenPosition.Y >> 4;
          int num24 = 32 + num19;
          for (int index2 = 0; index2 < num20; ++index2)
          {
            int num25 = 0;
            while (num25 < 96)
            {
              int num26 = 32 + num17 + 96 * num22 + num25 + num21;
              s2.X = num25 + num21 + 16;
              int x = num23 + num25 >> 4;
              fixed (Tile* tilePtr1 = &Main.tile[x, index1])
              {
                Tile* tilePtr2 = tilePtr1;
                int num27 = 0;
                while (num27 < 96)
                {
                  Color colorUnsafe = this.lighting.GetColorUnsafe(x, index1);
                  pos2.X = (float) num26;
                  pos2.Y = (float) (num24 + num27);
                  s2.Y = num27;
                  if ((int) colorUnsafe.R > 0 || (int) colorUnsafe.G > 0 || (int) colorUnsafe.B > 0)
                  {
                    if (this.SMOOTH_LIGHT && ((int) colorUnsafe.R > 226 || (double) colorUnsafe.G > 248.600006103516 || (double) colorUnsafe.B > 271.200012207031) && ((int) tilePtr2->active == 0 && ((int) tilePtr2->wall == 0 || (int) tilePtr2->wall == 21)))
                    {
                      s2.Width = 4;
                      s2.Height = 4;
                      Color c;
                      if ((int) tilePtr2[-1441].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x - 1, index1 - 1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Height = 8;
                      s2.Y += 4;
                      pos2.Y += 4f;
                      if ((int) tilePtr2[-1440].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x - 1, index1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Height = 4;
                      s2.Y += 8;
                      pos2.Y += 8f;
                      if ((int) tilePtr2[-1439].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x - 1, index1 + 1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Width = 8;
                      s2.X += 4;
                      pos2.X += 4f;
                      if ((int) tilePtr2[1].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x, index1 + 1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Height = 8;
                      s2.Y -= 8;
                      pos2.Y -= 8f;
                      c.R = (byte) ((double) colorUnsafe.R * (double) num8);
                      c.G = (byte) ((double) colorUnsafe.G * (double) num9);
                      c.B = (byte) ((double) colorUnsafe.B * (double) num10);
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Height = 4;
                      s2.Y -= 4;
                      pos2.Y -= 4f;
                      if ((int) tilePtr2[-1].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x, index1 - 1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Width = 4;
                      s2.X += 8;
                      pos2.X += 8f;
                      if ((int) tilePtr2[1439].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x + 1, index1 - 1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Height = 8;
                      s2.Y += 4;
                      pos2.Y += 4f;
                      if ((int) tilePtr2[1440].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x + 1, index1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Height = 4;
                      s2.Y += 8;
                      pos2.Y += 8f;
                      if ((int) tilePtr2[1441].active == 0)
                      {
                        c = this.lighting.GetColorUnsafe(x + 1, index1 + 1);
                        c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                        c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                        c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      }
                      else
                        c = colorUnsafe;
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Width = s2.Height = 16;
                      s2.X -= 12;
                    }
                    else if (this.SMOOTH_LIGHT && ((int) colorUnsafe.R > 160 || (double) colorUnsafe.G > 176.0 || (double) colorUnsafe.B > 192.0))
                    {
                      s2.Width = 8;
                      s2.Height = 8;
                      Color c = !this.lighting.Brighter(x, index1 - 1, x - 1, index1) ? this.lighting.GetColorUnsafe(x, index1 - 1) : this.lighting.GetColorUnsafe(x - 1, index1);
                      c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                      c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                      c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Y += 8;
                      pos2.Y += 8f;
                      c = !this.lighting.Brighter(x, index1 + 1, x - 1, index1) ? this.lighting.GetColorUnsafe(x, index1 + 1) : this.lighting.GetColorUnsafe(x - 1, index1);
                      c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                      c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                      c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.X += 8;
                      pos2.X += 8f;
                      c = !this.lighting.Brighter(x, index1 + 1, x + 1, index1) ? this.lighting.GetColorUnsafe(x, index1 + 1) : this.lighting.GetColorUnsafe(x + 1, index1);
                      c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                      c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                      c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Y -= 8;
                      pos2.Y -= 8f;
                      c = !this.lighting.Brighter(x, index1 - 1, x + 1, index1) ? this.lighting.GetColorUnsafe(x, index1 - 1) : this.lighting.GetColorUnsafe(x + 1, index1);
                      c.R = (byte) ((double) ((int) colorUnsafe.R + (int) c.R >> 1) * (double) num8);
                      c.G = (byte) ((double) ((int) colorUnsafe.G + (int) c.G >> 1) * (double) num9);
                      c.B = (byte) ((double) ((int) colorUnsafe.B + (int) c.B >> 1) * (double) num10);
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
                      s2.Width = s2.Height = 16;
                      s2.X -= 8;
                    }
                    else
                    {
                      colorUnsafe.R = (byte) ((double) colorUnsafe.R * (double) num8);
                      colorUnsafe.G = (byte) ((double) colorUnsafe.G * (double) num9);
                      colorUnsafe.B = (byte) ((double) colorUnsafe.B * (double) num10);
                      SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, colorUnsafe);
                    }
                  }
                  else
                    SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, colorUnsafe);
                  ++index1;
                  ++tilePtr2;
                  num27 += 16;
                }
                index1 -= 6;
              }
              num25 += 16;
            }
            num24 += 96;
            index1 += 6;
          }
          num23 += 96;
        }
        if (flag1)
        {
          int num24 = (int) (-Math.IEEERemainder((double) this.screenPosition.X * 0.899999976158142, 96.0) - 48.0);
          int num25 = ((int) this.viewWidth + 64) / 96 + 2;
          int num26 = num19 + num20 * 96;
          if (num26 > -32)
          {
            Vector2 vector2 = new Vector2((float) (32 + num24 + num21), (float) (32 + num26));
            int num27 = num24 + 8;
            for (int index = 0; index < num25; ++index)
            {
              int num28 = 0;
              while (num28 < 96)
              {
                Color color = this.lighting.GetColor(num27 + this.screenPosition.X >> 4, this.screenPosition.Y + num26 >> 4);
                num27 += 16;
                color.R = (byte) ((double) color.R * (double) num8);
                color.G = (byte) ((double) color.G * (double) num9);
                color.B = (byte) ((double) color.B * (double) num10);
                Main.spriteBatch.Draw(WorldView.backgroundTexture[4], vector2, new Rectangle?(new Rectangle(num28 + num21 + 16, 0, 16, 16)), color);
                vector2.X += 16f;
                num28 += 16;
              }
            }
          }
        }
      }
      bool flag2 = false;
      int num29 = Main.magmaLayerPixels;
      if (Main.rockLayerPixels <= this.screenPosition.Y + 540)
      {
        int num16 = Main.rockLayerPixels - this.screenPosition.Y + 540 - 28;
        int num17 = (int) (-Math.IEEERemainder(96.0 + (double) this.screenPosition.X * 0.899999976158142, 96.0) - 48.0) - 32;
        int num18 = ((int) this.viewWidth + 64) / 96 + 2;
        int num19;
        int num20;
        if (Main.rockLayerPixels + 540 < this.screenPosition.Y - 16)
        {
          num19 = (int) (Math.IEEERemainder((double) num16, 96.0) - 96.0);
          num20 = (540 - num19 + 96) / 96 + 1;
        }
        else
        {
          num19 = num16;
          num20 = (540 - num16 + 96) / 96 + 1;
        }
        if (num29 < this.screenPosition.Y + 540)
        {
          num20 = (num29 - this.screenPosition.Y + 540 - num19) / 96;
          flag2 = true;
        }
        int num21 = -(num17 + this.screenPosition.X & 15);
        if (num21 == -8)
          num21 = 8;
        for (int index1 = 0; index1 < num18; ++index1)
        {
          for (int index2 = 0; index2 < num20; ++index2)
          {
            int num22 = 0;
            while (num22 < 96)
            {
              int x = num17 + 96 * index1 + num22 + 8 + this.screenPosition.X >> 4;
              int y = 0;
              while (y < 96)
              {
                int index3 = num19 + index2 * 96 + y + 8 + this.screenPosition.Y >> 4;
                Color colorUnsafe = this.lighting.GetColorUnsafe(x, index3);
                bool flag3 = false;
                switch (Main.tile[x, index3].wall)
                {
                  case (byte) 0:
                  case (byte) 21:
                    flag3 = true;
                    break;
                  default:
                    if ((int) Main.tile[x - 1, index3].wall == 0 || (int) Main.tile[x - 1, index3].wall == 21 || ((int) Main.tile[x + 1, index3].wall == 0 || (int) Main.tile[x + 1, index3].wall == 21))
                      goto case 0;
                    else
                      break;
                }
                if ((flag3 || (int) colorUnsafe.R == 0 || ((int) colorUnsafe.G == 0 || (int) colorUnsafe.B == 0)) && ((int) colorUnsafe.R > 0 || (int) colorUnsafe.G > 0 || (int) colorUnsafe.B > 0))
                {
                  if (this.SMOOTH_LIGHT && (int) colorUnsafe.R < 230 && ((int) colorUnsafe.G < 230 && (int) colorUnsafe.B < 230))
                  {
                    if (((int) colorUnsafe.R > 226 || (double) colorUnsafe.G > 248.6 || (double) colorUnsafe.B > 271.2) && (int) Main.tile[x, index3].active == 0)
                    {
                      for (int index4 = 0; index4 < 9; ++index4)
                      {
                        int num23 = 0;
                        int num24 = 0;
                        int width = 4;
                        int height = 4;
                        Color color1 = colorUnsafe;
                        Color color2 = colorUnsafe;
                        if (index4 == 0)
                        {
                          if ((int) Main.tile[x - 1, index3 - 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x - 1, index3 - 1);
                        }
                        else if (index4 == 1)
                        {
                          width = 8;
                          num23 = 4;
                          if ((int) Main.tile[x, index3 - 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x, index3 - 1);
                        }
                        else if (index4 == 2)
                        {
                          if ((int) Main.tile[x + 1, index3 - 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x + 1, index3 - 1);
                          num23 = 12;
                        }
                        else if (index4 == 3)
                        {
                          if ((int) Main.tile[x - 1, index3].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x - 1, index3);
                          height = 8;
                          num24 = 4;
                        }
                        else if (index4 == 4)
                        {
                          width = 8;
                          height = 8;
                          num23 = 4;
                          num24 = 4;
                        }
                        else if (index4 == 5)
                        {
                          num23 = 12;
                          num24 = 4;
                          height = 8;
                          if ((int) Main.tile[x + 1, index3].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x + 1, index3);
                        }
                        else if (index4 == 6)
                        {
                          if ((int) Main.tile[x - 1, index3 + 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x - 1, index3 + 1);
                          num24 = 12;
                        }
                        else if (index4 == 7)
                        {
                          width = 8;
                          height = 4;
                          num23 = 4;
                          num24 = 12;
                          if ((int) Main.tile[x, index3 + 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x, index3 + 1);
                        }
                        else
                        {
                          if ((int) Main.tile[x + 1, index3 + 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x + 1, index3 + 1);
                          num23 = 12;
                          num24 = 12;
                        }
                        color1.R = (byte) ((double) ((int) colorUnsafe.R + (int) color2.R >> 1) * (double) num8);
                        color1.G = (byte) ((double) ((int) colorUnsafe.G + (int) color2.G >> 1) * (double) num9);
                        color1.B = (byte) ((double) ((int) colorUnsafe.B + (int) color2.B >> 1) * (double) num10);
                        Main.spriteBatch.Draw(WorldView.backgroundTexture[3], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num23 + num21), (float) (32 + num19 + 96 * index2 + y + num24)), new Rectangle?(new Rectangle(num22 + num23 + num21 + 16, y + num24, width, height)), color1);
                      }
                    }
                    else if ((int) colorUnsafe.R > 160 || (double) colorUnsafe.G > 176.0 || (double) colorUnsafe.B > 192.0)
                    {
                      for (int index4 = 0; index4 < 4; ++index4)
                      {
                        int num23 = 0;
                        int num24 = 0;
                        Color color1 = colorUnsafe;
                        Color color2 = colorUnsafe;
                        if (index4 == 0)
                          color2 = !this.lighting.Brighter(x, index3 - 1, x - 1, index3) ? this.lighting.GetColorUnsafe(x, index3 - 1) : this.lighting.GetColorUnsafe(x - 1, index3);
                        else if (index4 == 1)
                        {
                          color2 = !this.lighting.Brighter(x, index3 - 1, x + 1, index3) ? this.lighting.GetColorUnsafe(x, index3 - 1) : this.lighting.GetColorUnsafe(x + 1, index3);
                          num23 = 8;
                        }
                        else if (index4 == 2)
                        {
                          color2 = !this.lighting.Brighter(x, index3 + 1, x - 1, index3) ? this.lighting.GetColorUnsafe(x, index3 + 1) : this.lighting.GetColorUnsafe(x - 1, index3);
                          num24 = 8;
                        }
                        else
                        {
                          color2 = !this.lighting.Brighter(x, index3 + 1, x + 1, index3) ? this.lighting.GetColorUnsafe(x, index3 + 1) : this.lighting.GetColorUnsafe(x + 1, index3);
                          num23 = 8;
                          num24 = 8;
                        }
                        color1.R = (byte) ((double) ((int) colorUnsafe.R + (int) color2.R >> 1) * (double) num8);
                        color1.G = (byte) ((double) ((int) colorUnsafe.G + (int) color2.G >> 1) * (double) num9);
                        color1.B = (byte) ((double) ((int) colorUnsafe.B + (int) color2.B >> 1) * (double) num10);
                        Main.spriteBatch.Draw(WorldView.backgroundTexture[3], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num23 + num21), (float) (32 + num19 + 96 * index2 + y + num24)), new Rectangle?(new Rectangle(num22 + num23 + num21 + 16, y + num24, 8, 8)), color1);
                      }
                    }
                    else
                    {
                      colorUnsafe.R = (byte) ((double) colorUnsafe.R * (double) num8);
                      colorUnsafe.G = (byte) ((double) colorUnsafe.G * (double) num9);
                      colorUnsafe.B = (byte) ((double) colorUnsafe.B * (double) num10);
                      Main.spriteBatch.Draw(WorldView.backgroundTexture[3], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num21), (float) (32 + num19 + 96 * index2 + y)), new Rectangle?(new Rectangle(num22 + num21 + 16, y, 16, 16)), colorUnsafe);
                    }
                  }
                  else
                  {
                    colorUnsafe.R = (byte) ((double) colorUnsafe.R * (double) num8);
                    colorUnsafe.G = (byte) ((double) colorUnsafe.G * (double) num9);
                    colorUnsafe.B = (byte) ((double) colorUnsafe.B * (double) num10);
                    Main.spriteBatch.Draw(WorldView.backgroundTexture[3], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num21), (float) (32 + num19 + 96 * index2 + y)), new Rectangle?(new Rectangle(num22 + num21 + 16, y, 16, 16)), colorUnsafe);
                  }
                }
                y += 16;
              }
              num22 += 16;
            }
          }
        }
        if (flag2)
        {
          int num22 = (int) (-Math.IEEERemainder((double) this.screenPosition.X * 0.899999976158142, 96.0) - 48.0);
          int num23 = (int) this.viewWidth / 96 + 2;
          int num24 = num19 + num20 * 96;
          Rectangle rectangle = new Rectangle(0, Main.magmaBGFrame << 4, 16, 16);
          int num25 = num22 + 8;
          for (int index = 0; index < num23; ++index)
          {
            int num26 = 0;
            while (num26 < 96)
            {
              rectangle.X = num26 + num21 + 16;
              Color color = this.lighting.GetColor(num25 + this.screenPosition.X >> 4, this.screenPosition.Y + num24 >> 4);
              color.R = (byte) ((double) color.R * (double) num8);
              color.G = (byte) ((double) color.G * (double) num9);
              color.B = (byte) ((double) color.B * (double) num10);
              Main.spriteBatch.Draw(WorldView.backgroundTexture[6], new Vector2((float) (32 + num22 + 96 * index + num26 + num21), (float) (32 + num24)), new Rectangle?(rectangle), color);
              num25 += 16;
              num26 += 16;
            }
          }
        }
      }
      if (num29 <= this.screenPosition.Y + 540)
      {
        int num16 = num29 - this.screenPosition.Y + 540 - 28;
        int num17 = (int) (-Math.IEEERemainder(96.0 + (double) this.screenPosition.X * 0.899999976158142, 96.0) - 48.0) - 32;
        int num18 = ((int) this.viewWidth + 64) / 96 + 2;
        int num19;
        int num20;
        if (num29 + 540 < this.screenPosition.Y - 16)
        {
          num19 = (int) (Math.IEEERemainder((double) num16, 96.0) - 96.0);
          num20 = (540 - num19 + 96) / 96 + 1;
        }
        else
        {
          num19 = num16;
          num20 = (540 - num16 + 96) / 96 + 1;
        }
        int num21 = (int) (float) Math.Round((double) -(float) Math.IEEERemainder((double) (num17 + this.screenPosition.X), 16.0));
        if (num21 == -8)
          num21 = 8;
        for (int index1 = 0; index1 < num18; ++index1)
        {
          for (int index2 = 0; index2 < num20; ++index2)
          {
            int num22 = 0;
            while (num22 < 96)
            {
              int x = num17 + 96 * index1 + num22 + 8 + this.screenPosition.X >> 4;
              int index3 = num19 + index2 * 96 + 8 + this.screenPosition.Y >> 4;
              int num23 = 0;
              while (num23 < 96)
              {
                Color colorUnsafe = this.lighting.GetColorUnsafe(x, index3);
                bool flag3 = false;
                switch (Main.tile[x, index3].wall)
                {
                  case (byte) 0:
                  case (byte) 21:
                    flag3 = true;
                    break;
                  default:
                    if ((int) Main.tile[x - 1, index3].wall == 0 || (int) Main.tile[x - 1, index3].wall == 21 || ((int) Main.tile[x + 1, index3].wall == 0 || (int) Main.tile[x + 1, index3].wall == 21))
                      goto case 0;
                    else
                      break;
                }
                if ((flag3 || (int) colorUnsafe.R == 0 || ((int) colorUnsafe.G == 0 || (int) colorUnsafe.B == 0)) && ((int) colorUnsafe.R > 0 || (int) colorUnsafe.G > 0 || (int) colorUnsafe.B > 0))
                {
                  if (this.SMOOTH_LIGHT && (int) colorUnsafe.R < 230 && ((int) colorUnsafe.G < 230 && (int) colorUnsafe.B < 230))
                  {
                    if (((int) colorUnsafe.R > 339 || (double) colorUnsafe.G > 372.899993896484 || (double) colorUnsafe.B > 406.800018310547) && (int) Main.tile[x, index3].active == 0)
                    {
                      for (int index4 = 0; index4 < 9; ++index4)
                      {
                        int num24 = 0;
                        int num25 = 0;
                        int width = 4;
                        int height = 4;
                        Color color1 = colorUnsafe;
                        Color color2 = colorUnsafe;
                        if (index4 == 0)
                        {
                          if ((int) Main.tile[x - 1, index3 - 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x - 1, index3 - 1);
                        }
                        else if (index4 == 1)
                        {
                          width = 8;
                          num24 = 4;
                          if ((int) Main.tile[x, index3 - 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x, index3 - 1);
                        }
                        else if (index4 == 2)
                        {
                          if ((int) Main.tile[x + 1, index3 - 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x + 1, index3 - 1);
                          num24 = 12;
                        }
                        else if (index4 == 3)
                        {
                          if ((int) Main.tile[x - 1, index3].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x - 1, index3);
                          height = 8;
                          num25 = 4;
                        }
                        else if (index4 == 4)
                        {
                          width = 8;
                          height = 8;
                          num24 = 4;
                          num25 = 4;
                        }
                        else if (index4 == 5)
                        {
                          num24 = 12;
                          num25 = 4;
                          height = 8;
                          if ((int) Main.tile[x + 1, index3].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x + 1, index3);
                        }
                        else if (index4 == 6)
                        {
                          if ((int) Main.tile[x - 1, index3 + 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x - 1, index3 + 1);
                          num25 = 12;
                        }
                        else if (index4 == 7)
                        {
                          width = 8;
                          height = 4;
                          num24 = 4;
                          num25 = 12;
                          if ((int) Main.tile[x, index3 + 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x, index3 + 1);
                        }
                        else
                        {
                          if ((int) Main.tile[x + 1, index3 + 1].active == 0)
                            color2 = this.lighting.GetColorUnsafe(x + 1, index3 + 1);
                          num24 = 12;
                          num25 = 12;
                        }
                        color1.R = (byte) ((double) ((int) colorUnsafe.R + (int) color2.R >> 1) * (double) num8);
                        color1.G = (byte) ((double) ((int) colorUnsafe.G + (int) color2.G >> 1) * (double) num9);
                        color1.B = (byte) ((double) ((int) colorUnsafe.B + (int) color2.B >> 1) * (double) num10);
                        Main.spriteBatch.Draw(WorldView.backgroundTexture[5], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num24 + num21), (float) (32 + num19 + 96 * index2 + num23 + num25)), new Rectangle?(new Rectangle(num22 + num24 + num21 + 16, num23 + 96 * Main.magmaBGFrame + num25, width, height)), color1);
                      }
                    }
                    else if ((int) colorUnsafe.R > 240 || (double) colorUnsafe.G > 264.0 || (double) colorUnsafe.B > 288.0)
                    {
                      for (int index4 = 0; index4 < 4; ++index4)
                      {
                        int num24 = 0;
                        int num25 = 0;
                        Color color1 = colorUnsafe;
                        Color color2 = colorUnsafe;
                        if (index4 == 0)
                          color2 = !this.lighting.Brighter(x, index3 - 1, x - 1, index3) ? this.lighting.GetColorUnsafe(x, index3 - 1) : this.lighting.GetColorUnsafe(x - 1, index3);
                        else if (index4 == 1)
                        {
                          color2 = !this.lighting.Brighter(x, index3 - 1, x + 1, index3) ? this.lighting.GetColorUnsafe(x, index3 - 1) : this.lighting.GetColorUnsafe(x + 1, index3);
                          num24 = 8;
                        }
                        else if (index4 == 2)
                        {
                          color2 = !this.lighting.Brighter(x, index3 + 1, x - 1, index3) ? this.lighting.GetColorUnsafe(x, index3 + 1) : this.lighting.GetColorUnsafe(x - 1, index3);
                          num25 = 8;
                        }
                        else
                        {
                          color2 = !this.lighting.Brighter(x, index3 + 1, x + 1, index3) ? this.lighting.GetColorUnsafe(x, index3 + 1) : this.lighting.GetColorUnsafe(x + 1, index3);
                          num24 = 8;
                          num25 = 8;
                        }
                        color1.R = (byte) ((double) ((int) colorUnsafe.R + (int) color2.R >> 1) * (double) num8);
                        color1.G = (byte) ((double) ((int) colorUnsafe.G + (int) color2.G >> 1) * (double) num9);
                        color1.B = (byte) ((double) ((int) colorUnsafe.B + (int) color2.B >> 1) * (double) num10);
                        Main.spriteBatch.Draw(WorldView.backgroundTexture[5], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num24 + num21), (float) (32 + num19 + 96 * index2 + num23 + num25)), new Rectangle?(new Rectangle(num22 + num24 + num21 + 16, num23 + 96 * Main.magmaBGFrame + num25, 8, 8)), color1);
                      }
                    }
                    else
                    {
                      colorUnsafe.R = (byte) ((double) colorUnsafe.R * (double) num8);
                      colorUnsafe.G = (byte) ((double) colorUnsafe.G * (double) num9);
                      colorUnsafe.B = (byte) ((double) colorUnsafe.B * (double) num10);
                      Main.spriteBatch.Draw(WorldView.backgroundTexture[5], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num21), (float) (32 + num19 + 96 * index2 + num23)), new Rectangle?(new Rectangle(num22 + num21 + 16, num23 + 96 * Main.magmaBGFrame, 16, 16)), colorUnsafe);
                    }
                  }
                  else
                  {
                    colorUnsafe.R = (byte) ((double) colorUnsafe.R * (double) num8);
                    colorUnsafe.G = (byte) ((double) colorUnsafe.G * (double) num9);
                    colorUnsafe.B = (byte) ((double) colorUnsafe.B * (double) num10);
                    Main.spriteBatch.Draw(WorldView.backgroundTexture[5], new Vector2((float) (32 + num17 + 96 * index1 + num22 + num21), (float) (32 + num19 + 96 * index2 + num23)), new Rectangle?(new Rectangle(num22 + num21 + 16, num23 + 96 * Main.magmaBGFrame, 16, 16)), colorUnsafe);
                  }
                }
                ++index3;
                num23 += 16;
              }
              num22 += 16;
            }
          }
        }
      }
      this.lighting.brightness = this.player.blind ? 1f : this.lighting.defBrightness;
    }

    private void RenderBlack()
    {
      WorldView.graphicsDevice.SetRenderTarget(this.blackTarget);
      WorldView.graphicsDevice.Clear(new Color());
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.renderTargetProjection);
      this.DrawBlack();
      Main.spriteBatch.End();
      this.sceneBlackPos.X = this.screenPosition.X - 32;
      this.sceneBlackPos.Y = this.screenPosition.Y - 32;
    }

    private void RenderWalls()
    {
      WorldView.graphicsDevice.SetRenderTarget(this.wallTarget);
      WorldView.graphicsDevice.Clear(new Color());
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.renderTargetProjection);
      this.DrawWalls();
      Main.spriteBatch.End();
      this.sceneWallPos.X = this.screenPosition.X - 32;
      this.sceneWallPos.Y = this.screenPosition.Y - 32;
    }

    private void RenderBackWater()
    {
      WorldView.graphicsDevice.SetRenderTarget(this.backWaterTarget);
      WorldView.graphicsDevice.Clear(new Color());
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.renderTargetProjection);
      this.DrawWater(true);
      Main.spriteBatch.End();
    }

    private void RenderBackground()
    {
      WorldView.graphicsDevice.SetRenderTarget(this.backgroundTarget);
      WorldView.graphicsDevice.Clear(new Color());
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.renderTargetProjection);
      this.DrawBackground();
      Main.spriteBatch.End();
      this.sceneBackgroundPos.X = this.screenPosition.X - 32;
      this.sceneBackgroundPos.Y = this.screenPosition.Y - 32;
    }

    private void RenderSolidTiles()
    {
      WorldView.graphicsDevice.SetRenderTarget(this.tileSolidTarget);
      WorldView.graphicsDevice.Clear(new Color());
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.renderTargetProjection);
      this.DrawSolidTiles();
      Main.spriteBatch.End();
      this.sceneTilePos.X = this.screenPosition.X - 32;
      this.sceneTilePos.Y = this.screenPosition.Y - 32;
    }

    private void RenderNonSolidTiles()
    {
      WorldView.graphicsDevice.SetRenderTarget(this.tileNonSolidTarget);
      WorldView.graphicsDevice.Clear(new Color());
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.renderTargetProjection);
      this.DrawNonSolidTiles();
      Main.spriteBatch.End();
      this.sceneTile2Pos.X = this.screenPosition.X - 32;
      this.sceneTile2Pos.Y = this.screenPosition.Y - 32;
    }

    private void RenderWater()
    {
      WorldView.graphicsDevice.SetRenderTarget(this.waterTarget);
      WorldView.graphicsDevice.Clear(new Color());
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.renderTargetProjection);
      this.DrawWater(false);
      if (this.player.inventory[(int) this.player.selectedItem].mech)
        this.DrawWires();
      Main.spriteBatch.End();
      this.sceneWaterPos.X = this.screenPosition.X - 32;
      this.sceneWaterPos.Y = this.screenPosition.Y - 32;
    }

    public static void shine(ref Color newColor, int type)
    {
      int num1;
      int num2;
      int num3;
      if (type == 25)
      {
        num1 = (int) newColor.R * 243 >> 8;
        num2 = (int) newColor.G * 217 >> 8;
        num3 = (int) newColor.B * 281 >> 8;
      }
      else if (type == 117)
      {
        num1 = (int) newColor.R * 281 >> 8;
        num2 = (int) newColor.G;
        num3 = (int) newColor.B * 307 >> 8;
        if (num1 > (int) byte.MaxValue)
          num1 = (int) byte.MaxValue;
      }
      else
      {
        num1 = (int) newColor.R * 409 >> 8;
        num2 = (int) newColor.G * 409 >> 8;
        num3 = (int) newColor.B * 409 >> 8;
        if (num1 > (int) byte.MaxValue)
          num1 = (int) byte.MaxValue;
        if (num2 > (int) byte.MaxValue)
          num2 = (int) byte.MaxValue;
      }
      if (num3 > (int) byte.MaxValue)
        num3 = (int) byte.MaxValue;
      newColor.R = (byte) num1;
      newColor.G = (byte) num2;
      newColor.B = (byte) num3;
    }

    private unsafe void Highlight2x1(Tile* pTile, Tile.Flags mask)
    {
      pTile->flags |= mask;
      if ((int) pTile->frameX == 0)
        pTile += 1440;
      else
        pTile -= 1440;
      pTile->flags |= mask;
    }

    private unsafe void Highlight2x2(Tile* pTile, Tile.Flags mask)
    {
      int num = (int) pTile->frameY == 0 ? 1 : -1;
      pTile->flags |= mask;
      pTile += num;
      pTile->flags |= mask;
      if (((int) pTile->frameX / 18 & 1) == 0)
        pTile += 1440;
      else
        pTile -= 1440;
      pTile->flags |= mask;
      pTile -= num;
      pTile->flags |= mask;
    }

    private unsafe void Highlight1x3(Tile* pTile, Tile.Flags mask)
    {
      pTile->flags |= mask;
      if ((int) pTile->frameY == 0)
      {
        ++pTile;
        pTile->flags |= mask;
        ++pTile;
      }
      else if ((int) pTile->frameY == 18)
      {
        ++pTile;
        pTile->flags |= mask;
        pTile -= 2;
      }
      else
      {
        --pTile;
        pTile->flags |= mask;
        --pTile;
      }
      pTile->flags |= mask;
    }

    private unsafe void Highlight2x3(Tile* pTile, Tile.Flags mask)
    {
      pTile->flags |= mask;
      if ((int) pTile->frameY == 0)
      {
        ++pTile;
        pTile->flags |= mask;
        ++pTile;
        pTile->flags |= mask;
        if (((int) pTile->frameX / 18 & 1) == 0)
        {
          pTile += 1438;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          ++pTile;
        }
        else
        {
          pTile -= 1440;
          pTile->flags |= mask;
          --pTile;
          pTile->flags |= mask;
          --pTile;
        }
      }
      else if ((int) pTile->frameY == 18)
      {
        ++pTile;
        pTile->flags |= mask;
        pTile -= 2;
        pTile->flags |= mask;
        if (((int) pTile->frameX / 18 & 1) == 0)
        {
          pTile += 1440;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          ++pTile;
        }
        else
        {
          pTile -= 1440;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          ++pTile;
        }
      }
      else
      {
        --pTile;
        pTile->flags |= mask;
        --pTile;
        pTile->flags |= mask;
        if (((int) pTile->frameX / 18 & 1) == 0)
        {
          pTile += 1440;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          ++pTile;
        }
        else
        {
          pTile -= 1440;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          ++pTile;
        }
      }
      pTile->flags |= mask;
    }

    private unsafe void Highlight4x2(Tile* pTile, Tile.Flags mask)
    {
      int num = (int) pTile->frameY == 0 ? 1 : -1;
      pTile->flags |= mask;
      pTile += num;
      pTile->flags |= mask;
      switch ((int) pTile->frameX / 18 & 3)
      {
        case 0:
          pTile += 1440;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          pTile += 1440;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          pTile += 1440;
          break;
        case 1:
          pTile -= 1440;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          pTile += 2880;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          pTile += 1440;
          break;
        case 2:
          pTile += 1440;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          pTile -= 2880;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          pTile -= 1440;
          break;
        default:
          pTile -= 1440;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          pTile -= 1440;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          pTile -= 1440;
          break;
      }
      pTile->flags |= mask;
      pTile -= num;
      pTile->flags |= mask;
    }

    private unsafe void Highlight2x5(Tile* pTile, Tile.Flags mask)
    {
      int num = (int) pTile->frameX == 0 ? 1440 : -1440;
      pTile->flags |= mask;
      pTile += num;
      pTile->flags |= mask;
      switch ((int) pTile->frameY / 18)
      {
        case 0:
          ++pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          ++pTile;
          break;
        case 1:
          --pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          pTile += 2;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          ++pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          ++pTile;
          break;
        case 2:
          --pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          --pTile;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          pTile += 3;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          ++pTile;
          break;
        case 3:
          ++pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          pTile -= 2;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          --pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          --pTile;
          break;
        default:
          --pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          --pTile;
          pTile->flags |= mask;
          pTile += num;
          pTile->flags |= mask;
          --pTile;
          pTile->flags |= mask;
          pTile -= num;
          pTile->flags |= mask;
          --pTile;
          break;
      }
      pTile->flags |= mask;
      pTile += num;
      pTile->flags |= mask;
    }

    private unsafe void DrawNonSolidTiles()
    {
      int index1 = 0;
      Rectangle s1 = new Rectangle();
      Vector2 pos1 = new Vector2();
      Main.tileSolid[10] = false;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        if (!this.player.dead)
        {
          Tile* tilePtr2 = ((int) Main.frameCounter & 32) == 0 ? (Tile*) null : tilePtr1 + ((int) this.player.tileInteractX * 1440 + (int) this.player.tileInteractY);
          int num1 = (this.player.aabb.X + 10 >> 4) - 10;
          int num2 = (this.player.aabb.Y + 21 >> 4) - 8;
          for (int index2 = 0; index2 < 20; ++index2)
          {
            Tile* pTile = tilePtr1 + ((num1 + index2) * 1440 + num2);
            for (int index3 = 0; index3 < 16; ++index3)
            {
              if ((int) pTile->active != 0)
              {
                Tile.Flags mask = pTile == tilePtr2 ? Tile.Flags.SELECTED : Tile.Flags.NEARBY;
                if ((pTile->flags & mask) != mask)
                {
                  byte num3 = pTile->type;
                  if ((uint) num3 <= 79U)
                  {
                    if ((uint) num3 <= 29U)
                    {
                      if ((uint) num3 <= 13U)
                      {
                        switch (num3)
                        {
                          case (byte) 4:
                          case (byte) 13:
                            break;
                          case (byte) 10:
                            this.Highlight1x3(pTile, mask);
                            goto label_33;
                          case (byte) 11:
                            goto label_27;
                          default:
                            goto label_33;
                        }
                      }
                      else if ((int) num3 != 21)
                      {
                        if ((int) num3 == 29)
                        {
                          this.Highlight2x1(pTile, mask);
                          goto label_33;
                        }
                        else
                          goto label_33;
                      }
                      else
                        goto label_29;
                    }
                    else if ((uint) num3 <= 50U)
                    {
                      switch (num3)
                      {
                        case (byte) 33:
                        case (byte) 49:
                        case (byte) 50:
                          break;
                        default:
                          goto label_33;
                      }
                    }
                    else if ((int) num3 != 55)
                    {
                      if ((int) num3 == 79)
                      {
                        this.Highlight4x2(pTile, mask);
                        goto label_33;
                      }
                      else
                        goto label_33;
                    }
                    else
                      goto label_29;
                  }
                  else if ((uint) num3 <= 125U)
                  {
                    if ((uint) num3 <= 97U)
                    {
                      if ((int) num3 == 85 || (int) num3 == 97)
                        goto label_29;
                      else
                        goto label_33;
                    }
                    else if ((int) num3 != 104)
                    {
                      if ((int) num3 == 125)
                        goto label_29;
                      else
                        goto label_33;
                    }
                    else
                    {
                      this.Highlight2x5(pTile, mask);
                      goto label_33;
                    }
                  }
                  else if ((uint) num3 <= 132U)
                  {
                    if ((int) num3 != 128)
                    {
                      if ((int) num3 == 132)
                        goto label_29;
                      else
                        goto label_33;
                    }
                    else
                      goto label_27;
                  }
                  else if ((int) num3 != 136)
                  {
                    if ((int) num3 != 139)
                    {
                      if ((int) num3 != 144)
                        goto label_33;
                    }
                    else
                      goto label_29;
                  }
                  pTile->flags |= mask;
                  goto label_33;
label_27:
                  this.Highlight2x3(pTile, mask);
                  goto label_33;
label_29:
                  this.Highlight2x2(pTile, mask);
                }
              }
label_33:
              ++pTile;
            }
          }
        }
        int x = (int) this.firstTileX - 1;
        int num4 = (int) this.lastTileX + 2;
        int num5 = (int) this.lastTileY + 2;
        do
        {
          int y = (int) this.firstTileY;
          Tile* tilePtr2 = tilePtr1 + (x * 1440 + y - 1);
          do
          {
            ++tilePtr2;
            if ((int) tilePtr2->active != 0)
            {
              int type = (int) tilePtr2->type;
              if (!Main.tileSolid[type])
              {
                Color colorUnsafe1 = this.lighting.GetColorUnsafe(x, y);
                int num1 = 0;
                int num2 = 16;
                int num3 = 16;
                s1.X = (int) tilePtr2->frameX;
                s1.Y = (int) tilePtr2->frameY;
                switch (type)
                {
                  case 113:
                  case 73:
                  case 74:
                    num1 = -12;
                    num2 = 32;
                    break;
                  case 124:
                  case 69:
                  case 72:
                  case 77:
                  case 80:
                  case 14:
                  case 15:
                  case 16:
                  case 17:
                  case 18:
                  case 20:
                  case 26:
                  case 27:
                  case 32:
                    num2 = 18;
                    break;
                  case 125:
                  case 97:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 68;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 34;
                      break;
                    }
                    else
                      break;
                  case 128:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 104;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 52;
                      break;
                    }
                    else
                      break;
                  case 132:
                    num1 = 2;
                    num2 = 18;
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 72;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 36;
                      break;
                    }
                    else
                      break;
                  case 135:
                    num1 = 2;
                    num2 = 18;
                    break;
                  case 136:
                  case 144:
                  case 55:
                  case 79:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 72;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 36;
                      break;
                    }
                    else
                      break;
                  case 139:
                    num1 = 2;
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 1512;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 756;
                      break;
                    }
                    else
                      break;
                  case 142:
                  case 143:
                  case 105:
                  case 78:
                    num1 = 2;
                    break;
                  case 104:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 176;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 88;
                      break;
                    }
                    else
                      break;
                  case 110:
                  case 61:
                  case 71:
                  case 3:
                  case 24:
                    num2 = 20;
                    break;
                  case 81:
                    num1 = -8;
                    num3 = 24;
                    num2 = 26;
                    break;
                  case 85:
                    num1 = 2;
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 72;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 36;
                      break;
                    }
                    else
                      break;
                  case 4:
                    num3 = 20;
                    num2 = 20;
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 396;
                      break;
                    }
                    else
                      break;
                  case 5:
                    num3 = 20;
                    num2 = 20;
                    break;
                  case 10:
                  case 11:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 108;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 54;
                      break;
                    }
                    else
                      break;
                  case 13:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 36;
                      break;
                    }
                    else
                      break;
                  case 21:
                    num2 = 18;
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 76;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 38;
                      break;
                    }
                    else
                      break;
                  case 29:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 36;
                      break;
                    }
                    else if ((tilePtr2->flags & Tile.Flags.NEARBY) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 18;
                      break;
                    }
                    else
                      break;
                  case 33:
                  case 49:
                    num1 = -4;
                    num2 = 20;
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 44;
                      break;
                    }
                    else
                      break;
                  case 50:
                    if ((tilePtr2->flags & Tile.Flags.SELECTED) != ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID))
                    {
                      s1.Y += 32;
                      break;
                    }
                    else
                      break;
                }
                s1.Width = num3;
                s1.Height = num2;
                pos1.X = (float) ((x << 4) - this.screenPosition.X - (num3 - 16 >> 1) + 32);
                pos1.Y = (float) ((y << 4) - this.screenPosition.Y + num1 + 32);
                if (this.player.findTreasure && (type == 12 || type == 21 || type == 28 || type >= 82 && type <= 84))
                {
                  if ((int) colorUnsafe1.R < (int) UI.mouseTextBrightness >> 1)
                    colorUnsafe1.R = (byte) ((uint) UI.mouseTextBrightness >> 1);
                  if ((int) colorUnsafe1.G < 70)
                    colorUnsafe1.G = (byte) 70;
                  if ((int) colorUnsafe1.B < 210)
                    colorUnsafe1.B = (byte) 210;
                  colorUnsafe1.A = UI.mouseTextBrightness;
                  if (Main.rand.Next(150) == 0)
                  {
                    Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 15, 0.0, 0.0, 150, new Color(), 0.800000011920929);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.X *= 0.1f;
                      dustPtr->velocity.Y *= 0.1f;
                      dustPtr->noLight = true;
                    }
                  }
                }
                switch (type)
                {
                  case 93:
                    if ((int) tilePtr2->frameX == 0 && (int) tilePtr2->frameY == 0 && Main.rand.Next(40) == 0)
                    {
                      this.dustLocal.NewDust(x * 16 + 4, y * 16 + 2, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 98:
                    if ((int) tilePtr2->frameX == 0 && (int) tilePtr2->frameY == 0 && Main.rand.Next(40) == 0)
                    {
                      this.dustLocal.NewDust(x * 16 + 12, y * 16 + 2, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 100:
                    if ((int) tilePtr2->frameY == 0 && (int) tilePtr2->frameX < 36 && Main.rand.Next(40) == 0)
                    {
                      if ((int) tilePtr2->frameX == 0)
                      {
                        if (Main.rand.Next(3) == 0)
                        {
                          this.dustLocal.NewDust(x * 16 + 4, y * 16 + 2, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
                          break;
                        }
                        else
                        {
                          this.dustLocal.NewDust(x * 16 + 14, y * 16 + 2, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
                          break;
                        }
                      }
                      else if (Main.rand.Next(3) == 0)
                      {
                        this.dustLocal.NewDust(x * 16 + 6, y * 16 + 2, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
                        break;
                      }
                      else
                      {
                        this.dustLocal.NewDust(x * 16, y * 16 + 2, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
                        break;
                      }
                    }
                    else
                      break;
                  case 133:
                  case 77:
                  case 17:
                    if (Main.rand.Next(40) == 0 && (int) tilePtr2->frameX == 18 && (int) tilePtr2->frameY == 18)
                    {
                      this.dustLocal.NewDust(x * 16 + 2, y * 16, 8, 6, 6, 0.0, 0.0, 100, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 71:
                  case 72:
                    if (Main.rand.Next(500) == 0)
                    {
                      this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 41, 0.0, 0.0, 250, new Color(), 0.800000011920929);
                      break;
                    }
                    else
                      break;
                  case 24:
                  case 32:
                    if (Main.rand.Next(500) == 0)
                    {
                      this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 14, 0.0, 0.0, 0, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 26:
                  case 31:
                    if (Main.rand.Next(20) == 0)
                    {
                      this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 14, 0.0, 0.0, 100, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 33:
                    if ((int) tilePtr2->frameX == 0 && Main.rand.Next(40) == 0)
                    {
                      this.dustLocal.NewDust(x * 16 + 4, y * 16 - 4, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 34:
                  case 35:
                  case 36:
                    if (((int) tilePtr2->frameX == 0 || (int) tilePtr2->frameX == 36) && ((int) tilePtr2->frameY == 18 && Main.rand.Next(40) == 0))
                    {
                      this.dustLocal.NewDust(x * 16, y * 16 + 2, 14, 6, 6, 0.0, 0.0, 100, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 49:
                    if (Main.rand.Next(20) == 0)
                    {
                      this.dustLocal.NewDust(x * 16 + 4, y * 16 - 4, 4, 4, 29, 0.0, 0.0, 100, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 61:
                    if ((int) tilePtr2->frameX == 144)
                    {
                      if (Main.rand.Next(60) == 0)
                      {
                        Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 44, 0.0, 0.0, 250, new Color(), 0.400000005960464);
                        if ((IntPtr) dustPtr != IntPtr.Zero)
                          dustPtr->fadeIn = 0.7f;
                      }
                      colorUnsafe1.A = colorUnsafe1.R = colorUnsafe1.B = colorUnsafe1.G = (byte) (245 - (int) UI.mouseTextBrightness + ((int) UI.mouseTextBrightness >> 1));
                      break;
                    }
                    else
                      break;
                  case 4:
                    if ((int) tilePtr2->frameX < 66 && Main.rand.Next(40) == 0)
                    {
                      int num6 = (int) tilePtr2->frameY / 22;
                      int Type;
                      switch (num6)
                      {
                        case 0:
                          Type = 6;
                          break;
                        case 8:
                          Type = 75;
                          break;
                        default:
                          Type = 58 + num6;
                          break;
                      }
                      if ((int) tilePtr2->frameX == 22)
                      {
                        this.dustLocal.NewDust(x * 16 + 6, y * 16, 4, 4, Type, 0.0, 0.0, 100, new Color(), 1.0);
                        break;
                      }
                      else if ((int) tilePtr2->frameX == 44)
                      {
                        this.dustLocal.NewDust(x * 16 + 2, y * 16, 4, 4, Type, 0.0, 0.0, 100, new Color(), 1.0);
                        break;
                      }
                      else
                      {
                        this.dustLocal.NewDust(x * 16 + 4, y * 16, 4, 4, Type, 0.0, 0.0, 100, new Color(), 1.0);
                        break;
                      }
                    }
                    else
                      break;
                  default:
                    if ((int) Main.tileShine[type] > 0 && ((int) colorUnsafe1.R > 20 || (int) colorUnsafe1.B > 20 || (int) colorUnsafe1.G > 20))
                    {
                      int num6 = (int) colorUnsafe1.R;
                      if ((int) colorUnsafe1.G > num6)
                        num6 = (int) colorUnsafe1.G;
                      if ((int) colorUnsafe1.B > num6)
                        num6 = (int) colorUnsafe1.B;
                      int num7 = num6 / 30;
                      if (Main.rand.Next((int) Main.tileShine[type]) < num7 && (type != 21 || (int) tilePtr2->frameX >= 36 && (int) tilePtr2->frameX < 180))
                      {
                        Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 43, 0.0, 0.0, 254, new Color(), 0.5);
                        if ((IntPtr) dustPtr != IntPtr.Zero)
                        {
                          dustPtr->velocity.X = 0.0f;
                          dustPtr->velocity.Y = 0.0f;
                          break;
                        }
                        else
                          break;
                      }
                      else
                        break;
                    }
                    else
                      break;
                }
                if (type == 5 && (int) tilePtr2->frameY >= 198 && (int) tilePtr2->frameX >= 22 || type == 128 && (int) tilePtr2->frameX >= 100)
                {
                  this.spec[index1].X = (short) x;
                  this.spec[index1].Y = (short) y;
                  this.spec[index1++].tileColor = colorUnsafe1;
                  if (type == 128)
                  {
                    s1.X %= 100;
                    SpriteSheet<_sheetTiles>.Draw(154, ref pos1, ref s1, colorUnsafe1);
                  }
                }
                else if (type == 129)
                {
                  colorUnsafe1.R = (byte) 200;
                  colorUnsafe1.G = (byte) 200;
                  colorUnsafe1.B = (byte) 200;
                  colorUnsafe1.A = (byte) 0;
                  SpriteSheet<_sheetTiles>.Draw(26 + type, ref pos1, ref s1, colorUnsafe1);
                }
                else if ((int) colorUnsafe1.R > 1 || (int) colorUnsafe1.G > 1 || (int) colorUnsafe1.B > 1)
                {
                  if (type == 72 && (int) tilePtr2->frameX >= 36)
                  {
                    int num6 = (int) tilePtr2->frameY / 18;
                    pos1.X = (float) (x * 16 - this.screenPosition.X - 22 + 32);
                    pos1.Y = (float) (y * 16 - this.screenPosition.Y - 26 + 32);
                    s1.X = num6 * 62;
                    s1.Y = 0;
                    s1.Width = 60;
                    s1.Height = 42;
                    SpriteSheet<_sheetTiles>.Draw(18, ref pos1, ref s1, colorUnsafe1);
                  }
                  else if (type == 51)
                  {
                    colorUnsafe1.R = (byte) ((uint) colorUnsafe1.R >> 1);
                    colorUnsafe1.G = (byte) ((uint) colorUnsafe1.G >> 1);
                    colorUnsafe1.B = (byte) ((uint) colorUnsafe1.B >> 1);
                    colorUnsafe1.A = (byte) ((uint) colorUnsafe1.A >> 1);
                    SpriteSheet<_sheetTiles>.Draw(26 + type, ref pos1, ref s1, colorUnsafe1);
                  }
                  else if (type >= 82 && type <= 84)
                  {
                    if (type > 82)
                    {
                      int num6 = (int) tilePtr2->frameX / 18;
                      if (num6 == 0 && this.time.dayTime)
                        type = 84;
                      else if (num6 == 1 && !this.time.dayTime)
                        type = 84;
                      else if (num6 == 3 && this.time.bloodMoon)
                        type = 84;
                      if (type == 84)
                      {
                        if (num6 == 0)
                        {
                          if (Main.rand.Next(100) == 0)
                          {
                            Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16 - 4, 16, 16, 19, 0.0, 0.0, 160, new Color(), 0.100000001490116);
                            if ((IntPtr) dustPtr != IntPtr.Zero)
                            {
                              dustPtr->velocity.X *= 0.5f;
                              dustPtr->velocity.Y *= 0.5f;
                              dustPtr->noGravity = true;
                              dustPtr->fadeIn = 1f;
                            }
                          }
                        }
                        else if (num6 == 1)
                        {
                          if (Main.rand.Next(100) == 0)
                            this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 41, 0.0, 0.0, 250, new Color(), 0.800000011920929);
                        }
                        else if (num6 == 3)
                        {
                          if (Main.rand.Next(200) == 0)
                          {
                            Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 14, 0.0, 0.0, 100, new Color(), 0.200000002980232);
                            if ((IntPtr) dustPtr != IntPtr.Zero)
                              dustPtr->fadeIn = 1.2f;
                          }
                          if (Main.rand.Next(75) == 0)
                          {
                            Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 27, 0.0, 0.0, 100, new Color(), 1.0);
                            if ((IntPtr) dustPtr != IntPtr.Zero)
                            {
                              dustPtr->velocity.X *= 0.5f;
                              dustPtr->velocity.Y *= 0.5f;
                            }
                          }
                        }
                        else if (num6 == 4)
                        {
                          if (Main.rand.Next(150) == 0)
                          {
                            Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 8, 16, 0.0, 0.0, 0, new Color(), 1.0);
                            if ((IntPtr) dustPtr != IntPtr.Zero)
                            {
                              dustPtr->velocity.X *= 0.3333333f;
                              dustPtr->velocity.Y *= 0.3333333f;
                              dustPtr->velocity.Y -= 0.7f;
                              dustPtr->alpha = (short) 50;
                              dustPtr->scale *= 0.1f;
                              dustPtr->fadeIn = 0.9f;
                              dustPtr->noGravity = true;
                            }
                          }
                        }
                        else if (num6 == 5)
                        {
                          if (Main.rand.Next(40) == 0)
                          {
                            Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16 - 6, 16, 16, 6, 0.0, 0.0, 0, new Color(), 1.5);
                            if ((IntPtr) dustPtr != IntPtr.Zero)
                            {
                              dustPtr->velocity.Y -= 2f;
                              dustPtr->noGravity = true;
                            }
                          }
                          colorUnsafe1.A = (byte) ((uint) UI.mouseTextBrightness >> 1);
                          colorUnsafe1.G = UI.mouseTextBrightness;
                          colorUnsafe1.B = UI.mouseTextBrightness;
                        }
                      }
                    }
                    pos1.Y = (float) (y * 16 - this.screenPosition.Y - 1 + 32);
                    s1.Height = 20;
                    SpriteSheet<_sheetTiles>.Draw(26 + type, ref pos1, ref s1, colorUnsafe1);
                  }
                  else if (type == 80)
                  {
                    bool flag1 = false;
                    bool flag2 = false;
                    int index2 = x;
                    switch (tilePtr2->frameX)
                    {
                      case (short) 36:
                        --index2;
                        break;
                      case (short) 54:
                        ++index2;
                        break;
                      case (short) 108:
                        if ((int) tilePtr2->frameY == 16)
                        {
                          --index2;
                          break;
                        }
                        else
                        {
                          ++index2;
                          break;
                        }
                    }
                    int index3 = y;
                    bool flag3 = false;
                    if ((int) Main.tile[index2, index3].type == 80 && (int) Main.tile[index2, index3].active != 0)
                      flag3 = true;
                    while ((int) Main.tile[index2, index3].active == 0 || !Main.tileSolid[(int) Main.tile[index2, index3].type] || !flag3)
                    {
                      if ((int) Main.tile[index2, index3].type == 80 && (int) Main.tile[index2, index3].active != 0)
                        flag3 = true;
                      ++index3;
                      if (index3 > y + 20)
                        break;
                    }
                    if ((int) Main.tile[index2, index3].type == 112)
                      flag1 = true;
                    else if ((int) Main.tile[index2, index3].type == 116)
                      flag2 = true;
                    SpriteSheet<_sheetTiles>.Draw(!flag1 ? (!flag2 ? 26 + type : 13) : 12, ref pos1, ref s1, colorUnsafe1);
                  }
                  else
                  {
                    bool flag = Main.tileShine2[type];
                    int id = 26 + type;
                    if (this.SMOOTH_LIGHT && Main.tileSolid[type] && type != 137)
                    {
                      if ((int) colorUnsafe1.R > 198 || (double) colorUnsafe1.G > 217.800003051758 || (double) colorUnsafe1.B > 237.600006103516)
                      {
                        s1.Width = 4;
                        s1.Height = 4;
                        Color colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y - 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X += 4f;
                        s1.X += 4;
                        s1.Width = 8;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x, y - 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X += 8f;
                        s1.X += 8;
                        s1.Width = 4;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y - 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.Y += 4f;
                        s1.Y += 4;
                        s1.Height = 8;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X -= 12f;
                        s1.X -= 12;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.Y += 8f;
                        s1.Y += 8;
                        s1.Height = 4;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y + 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X += 4f;
                        s1.X += 4;
                        s1.Width = 8;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x, y + 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X += 8f;
                        s1.X += 8;
                        s1.Width = 4;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y + 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X -= 8f;
                        pos1.Y -= 8f;
                        s1.X -= 8;
                        s1.Y -= 8;
                        s1.Width = 8;
                        s1.Height = 8;
                        if (flag)
                          WorldView.shine(ref colorUnsafe1, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe1);
                      }
                      else if ((int) colorUnsafe1.R > 38 || (double) colorUnsafe1.G > 41.7999992370605 || (double) colorUnsafe1.B > 45.6000022888184)
                      {
                        s1.Width = 8;
                        s1.Height = 8;
                        Color colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y - 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X += 8f;
                        s1.X += 8;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y - 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.Y += 8f;
                        s1.Y += 8;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y + 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                        pos1.X -= 8f;
                        s1.X -= 8;
                        colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y + 1);
                        colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                        colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                        colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                        if (flag)
                          WorldView.shine(ref colorUnsafe2, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      }
                      else
                      {
                        if (flag)
                          WorldView.shine(ref colorUnsafe1, type);
                        SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe1);
                      }
                    }
                    else
                    {
                      if (this.SMOOTH_LIGHT && flag)
                      {
                        if (type == 21)
                        {
                          if ((int) tilePtr2->frameX >= 36 && (int) tilePtr2->frameX < 178)
                            WorldView.shine(ref colorUnsafe1, type);
                        }
                        else
                          WorldView.shine(ref colorUnsafe1, type);
                      }
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe1);
                      if (type == 139)
                      {
                        colorUnsafe1.R = (byte) 200;
                        colorUnsafe1.G = (byte) 200;
                        colorUnsafe1.B = (byte) 200;
                        colorUnsafe1.A = (byte) 0;
                        SpriteSheet<_sheetTiles>.Draw(17, ref pos1, ref s1, colorUnsafe1);
                      }
                      else if (type == 144)
                      {
                        colorUnsafe1.R = (byte) 200;
                        colorUnsafe1.G = (byte) 200;
                        colorUnsafe1.B = (byte) 200;
                        colorUnsafe1.A = (byte) 0;
                        SpriteSheet<_sheetTiles>.Draw(176, ref pos1, ref s1, colorUnsafe1);
                      }
                    }
                  }
                }
              }
            }
          }
          while (++y < num5);
        }
        while (++x < num4);
        if (!this.player.dead)
        {
          int num1 = (this.player.aabb.X + 10 >> 4) - 10;
          int num2 = (this.player.aabb.Y + 21 >> 4) - 8;
          for (int index2 = -3; index2 < 23; ++index2)
          {
            Tile* tilePtr2 = tilePtr1 + ((num1 + index2) * 1440 + num2 - 4);
            for (int index3 = -4; index3 < 20; ++index3)
            {
              tilePtr2->flags &= Tile.Flags.WALLFRAME_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID;
              ++tilePtr2;
            }
          }
        }
      }
      Vector2 pos2 = new Vector2();
      for (int index2 = 0; index2 < index1; ++index2)
      {
        int index3 = (int) this.spec[index2].X;
        int index4 = (int) this.spec[index2].Y;
        Color c = this.spec[index2].tileColor;
        pos2.X = (float) (32 + index3 * 16 - this.screenPosition.X);
        pos2.Y = (float) (32 + index4 * 16 - this.screenPosition.Y);
        fixed (Tile* tilePtr = &Main.tile[index3, index4])
        {
          if ((int) tilePtr->type == 128)
          {
            int num1 = (int) tilePtr->frameY / 18;
            int num2 = (int) tilePtr->frameX;
            int num3 = num2 / 100;
            int num4 = num2 % 100;
            SpriteEffects se = SpriteEffects.FlipHorizontally;
            if (num4 >= 36)
              se = SpriteEffects.None;
            pos2.X += -4f;
            pos2.Y += (float) (-12 - (num1 << 4));
            int sh = 54;
            int id;
            if (num1 == 0)
            {
              id = num3 + 60;
              sh = 36;
            }
            else
              id = num1 != 1 ? num3 + 107 : num3 + 32;
            SpriteSheet<_sheetSprites>.Draw(id, ref pos2, sh, c, se);
          }
          else
          {
            Rectangle s2 = new Rectangle();
            if ((int) tilePtr->frameX == 22)
            {
              int num1 = 0;
              if ((int) tilePtr->frameY == 220)
                num1 = 1;
              else if ((int) tilePtr->frameY == 242)
                num1 = 2;
              int num2 = 0;
              s2.Width = 80;
              s2.Height = 80;
              int num3 = 32;
              int num4 = index4 + 100 >= (int) Main.maxTilesY ? (int) Main.maxTilesY - index4 : 100;
              for (int index5 = 0; index5 < num4; ++index5)
              {
                switch (tilePtr[index5].type)
                {
                  case (byte) 2:
                    num2 = 0;
                    goto label_292;
                  case (byte) 23:
                    num2 = 1;
                    goto label_292;
                  case (byte) 60:
                    num2 = 2;
                    s2.Width = 114;
                    s2.Height = 96;
                    num3 = 48;
                    goto label_292;
                  case (byte) 147:
                    num2 = 4;
                    goto label_292;
                  case (byte) 109:
                    num2 = 3;
                    num1 += index3 % 3 * 3;
                    s2.Height = 140;
                    goto label_292;
                  default:
                    goto default;
                }
              }
label_292:
              s2.X = num1 * (s2.Width + 2);
              pos2.X -= (float) num3;
              pos2.Y -= (float) (s2.Height - 16);
              SpriteSheet<_sheetTiles>.Draw(182 + num2, ref pos2, ref s2, c);
            }
            else if ((int) tilePtr->frameX == 44)
            {
              s2.Width = 40;
              s2.Height = 40;
              if ((int) tilePtr->frameY == 220)
                s2.Y = 42;
              else if ((int) tilePtr->frameY == 242)
                s2.Y = 84;
              int num1 = 0;
              int num2 = index4 + 100 >= (int) Main.maxTilesY ? (int) Main.maxTilesY - index4 : 100;
              for (int index5 = 0; index5 < num2; ++index5)
              {
                switch (tilePtr[index5 + 1440].type)
                {
                  case (byte) 2:
                    num1 = 0;
                    goto label_307;
                  case (byte) 23:
                    num1 = 1;
                    goto label_307;
                  case (byte) 60:
                    num1 = 2;
                    goto label_307;
                  case (byte) 147:
                    num1 = 4;
                    goto label_307;
                  case (byte) 109:
                    num1 = 3;
                    s2.Y += index3 % 3 * 126;
                    goto label_307;
                  default:
                    goto default;
                }
              }
label_307:
              pos2.X -= 24f;
              pos2.Y -= 12f;
              SpriteSheet<_sheetTiles>.Draw(177 + num1, ref pos2, ref s2, c);
            }
            else if ((int) tilePtr->frameX == 66)
            {
              s2.X = 42;
              s2.Width = 40;
              s2.Height = 40;
              if ((int) tilePtr->frameY == 220)
                s2.Y = 42;
              else if ((int) tilePtr->frameY == 242)
                s2.Y = 84;
              int num1 = 0;
              int num2 = index4 + 100 >= (int) Main.maxTilesY ? (int) Main.maxTilesY - index4 : 100;
              for (int index5 = 0; index5 < num2; ++index5)
              {
                switch (tilePtr[index5 - 1440].type)
                {
                  case (byte) 2:
                    num1 = 0;
                    goto label_322;
                  case (byte) 23:
                    num1 = 1;
                    goto label_322;
                  case (byte) 60:
                    num1 = 2;
                    goto label_322;
                  case (byte) 147:
                    num1 = 4;
                    goto label_322;
                  case (byte) 109:
                    num1 = 3;
                    s2.Y += index3 % 3 * 126;
                    goto label_322;
                  default:
                    goto default;
                }
              }
label_322:
              pos2.Y -= 12f;
              SpriteSheet<_sheetTiles>.Draw(177 + num1, ref pos2, ref s2, c);
            }
          }
        }
      }
      Main.tileSolid[10] = true;
    }

    private unsafe void DrawSolidTiles()
    {
      Main.tileSolid[10] = false;
      Rectangle s1 = new Rectangle();
      Vector2 pos1 = new Vector2();
      int num1 = (int) this.lastTileX;
      int num2 = (int) this.lastTileY;
      int x = (int) this.firstTileX;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        do
        {
          int y = (int) this.firstTileY;
          Tile* tilePtr2 = tilePtr1 + (x * 1440 + y - 1);
          do
          {
            ++tilePtr2;
            if ((int) tilePtr2->active != 0)
            {
              int type = (int) tilePtr2->type;
              if (Main.tileSolid[type])
              {
                s1.X = (int) tilePtr2->frameX;
                s1.Y = (int) tilePtr2->frameY;
                s1.Width = 16;
                s1.Height = type == 137 || type == 138 ? 18 : 16;
                pos1.X = (float) (x * 16 - this.screenPosition.X + 32);
                pos1.Y = (float) (y * 16 - this.screenPosition.Y + 32);
                Color colorUnsafe1 = this.lighting.GetColorUnsafe(x, y);
                if (this.player.findTreasure && (type == 6 || type == 7 || (type == 8 || type == 9) || (type == 22 || type == 107 || (type == 108 || type == 111)) || type >= 63 && type <= 68))
                {
                  if ((int) colorUnsafe1.R < (int) UI.mouseTextBrightness >> 1)
                    colorUnsafe1.R = (byte) ((uint) UI.mouseTextBrightness >> 1);
                  if ((int) colorUnsafe1.G < 70)
                    colorUnsafe1.G = (byte) 70;
                  if ((int) colorUnsafe1.B < 210)
                    colorUnsafe1.B = (byte) 210;
                  colorUnsafe1.A = UI.mouseTextBrightness;
                  if (Main.rand.Next(150) == 0)
                  {
                    Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 15, 0.0, 0.0, 150, new Color(), 0.800000011920929);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.X *= 0.1f;
                      dustPtr->velocity.Y *= 0.1f;
                      dustPtr->noLight = true;
                    }
                  }
                }
                switch (type)
                {
                  case 58:
                  case 76:
                    if (Main.rand.Next(250) == 0)
                    {
                      Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 6, 0.0, 0.0, 0, new Color(), (double) Main.rand.Next(3));
                      if ((IntPtr) dustPtr != IntPtr.Zero && (double) dustPtr->scale > 1.0)
                      {
                        dustPtr->noGravity = true;
                        dustPtr->noLight = true;
                        break;
                      }
                      else
                        break;
                    }
                    else
                      break;
                  case 112:
                    if (Main.rand.Next(700) == 0)
                    {
                      this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 14, 0.0, 0.0, 0, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 22:
                    if (Main.rand.Next(400) == 0)
                    {
                      this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 14, 0.0, 0.0, 0, new Color(), 1.0);
                      goto default;
                    }
                    else
                      goto default;
                  case 23:
                    if (Main.rand.Next(500) == 0)
                    {
                      this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 14, 0.0, 0.0, 0, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 25:
                    if (Main.rand.Next(700) == 0)
                    {
                      this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 14, 0.0, 0.0, 0, new Color(), 1.0);
                      break;
                    }
                    else
                      break;
                  case 37:
                    if (Main.rand.Next(250) == 0)
                    {
                      Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 6, 0.0, 0.0, 0, new Color(), (double) Main.rand.Next(3));
                      if ((IntPtr) dustPtr != IntPtr.Zero && (double) dustPtr->scale > 1.0)
                      {
                        dustPtr->noGravity = true;
                        break;
                      }
                      else
                        break;
                    }
                    else
                      break;
                  default:
                    if ((int) Main.tileShine[type] > 0 && ((int) colorUnsafe1.R > 20 || (int) colorUnsafe1.B > 20 || (int) colorUnsafe1.G > 20))
                    {
                      int num3 = (int) colorUnsafe1.R;
                      if ((int) colorUnsafe1.G > num3)
                        num3 = (int) colorUnsafe1.G;
                      if ((int) colorUnsafe1.B > num3)
                        num3 = (int) colorUnsafe1.B;
                      int num4 = num3 / 30;
                      if (Main.rand.Next((int) Main.tileShine[type]) < num4)
                      {
                        Dust* dustPtr = this.dustLocal.NewDust(x * 16, y * 16, 16, 16, 43, 0.0, 0.0, 254, new Color(), 0.5);
                        if ((IntPtr) dustPtr != IntPtr.Zero)
                        {
                          dustPtr->velocity.X = 0.0f;
                          dustPtr->velocity.Y = 0.0f;
                          break;
                        }
                        else
                          break;
                      }
                      else
                        break;
                    }
                    else
                      break;
                }
                if ((int) colorUnsafe1.R > 1 || (int) colorUnsafe1.G > 1 || (int) colorUnsafe1.B > 1)
                {
                  if (!Main.tileSolidTop[type] && ((int) tilePtr2[-1].liquid > 0 || (int) tilePtr2[1].liquid > 0 || ((int) tilePtr2[-1440].liquid > 0 || (int) tilePtr2[1440].liquid > 0)))
                  {
                    int num3 = 0;
                    bool flag1 = false;
                    bool flag2 = false;
                    bool flag3 = false;
                    bool flag4 = false;
                    int num4 = 0;
                    bool flag5 = false;
                    if ((int) tilePtr2[-1440].liquid > num3)
                    {
                      num3 = (int) tilePtr2[-1440].liquid;
                      flag1 = true;
                    }
                    else if ((int) tilePtr2[-1440].liquid > 0)
                      flag1 = true;
                    if ((int) tilePtr2[1440].liquid > num3)
                    {
                      num3 = (int) tilePtr2[1440].liquid;
                      flag2 = true;
                    }
                    else if ((int) tilePtr2[1440].liquid > 0)
                    {
                      num3 = (int) tilePtr2[1440].liquid;
                      flag2 = true;
                    }
                    if ((int) tilePtr2[-1].liquid > 0)
                      flag3 = true;
                    if ((int) tilePtr2[1].liquid > 240)
                      flag4 = true;
                    if ((int) tilePtr2[-1440].liquid > 0)
                    {
                      if ((int) tilePtr2[-1440].lava != 0)
                        num4 = 1;
                      else
                        flag5 = true;
                    }
                    if ((int) tilePtr2[1440].liquid > 0)
                    {
                      if ((int) tilePtr2[1440].lava != 0)
                        num4 = 1;
                      else
                        flag5 = true;
                    }
                    if ((int) tilePtr2[-1].liquid > 0)
                    {
                      if ((int) tilePtr2[-1].lava != 0)
                        num4 = 1;
                      else
                        flag5 = true;
                    }
                    if ((int) tilePtr2[1].liquid > 0)
                    {
                      if ((int) tilePtr2[1].lava != 0)
                        num4 = 1;
                      else
                        flag5 = true;
                    }
                    if (!flag5 || num4 != 1)
                    {
                      Vector2 pos2 = new Vector2((float) (x * 16), (float) (y * 16));
                      Rectangle s2 = new Rectangle(0, 4, 16, 16);
                      if (flag4 && (flag1 || flag2))
                      {
                        flag1 = true;
                        flag2 = true;
                      }
                      if ((!flag3 || !flag1 && !flag2) && (!flag4 || !flag3))
                      {
                        if (flag3)
                          s2.Height = 4;
                        else if (flag4 && !flag1 && !flag2)
                        {
                          pos2.Y += 12f;
                          s2.Height = 4;
                        }
                        else
                        {
                          int num5 = (int) ((double) (256 - num3) * (1.0 / 32.0)) << 1;
                          pos2.Y += (float) num5;
                          s2.Height -= num5;
                          if (!flag1 || !flag2)
                          {
                            s2.Width = 4;
                            if (!flag1)
                              pos2.X += 12f;
                          }
                        }
                      }
                      Color c = colorUnsafe1;
                      if (y >= Main.worldSurface)
                      {
                        c.R = (byte) ((uint) c.R >> 1);
                        c.G = (byte) ((uint) c.G >> 1);
                        c.B = (byte) ((uint) c.B >> 1);
                        c.A = (byte) ((uint) c.A >> 1);
                        if (num4 == 1)
                        {
                          c.R += (byte) ((uint) c.R >> 1);
                          c.G += (byte) ((uint) c.G >> 1);
                          c.B += (byte) ((uint) c.B >> 1);
                          c.A += (byte) ((uint) c.A >> 1);
                        }
                      }
                      pos2.X -= (float) this.screenPosition.X;
                      pos2.X += 32f;
                      pos2.Y -= (float) this.screenPosition.Y;
                      pos2.Y += 32f;
                      SpriteSheet<_sheetTiles>.Draw(14 + num4, ref pos2, ref s2, c);
                    }
                  }
                  bool flag = Main.tileShine2[type];
                  int id = 26 + type;
                  if (this.SMOOTH_LIGHT && type != 11 && type != 137)
                  {
                    if ((int) colorUnsafe1.R > 198 || (double) colorUnsafe1.G > 217.800003051758 || (double) colorUnsafe1.B > 237.600006103516)
                    {
                      s1.Width = 4;
                      s1.Height = 4;
                      Color colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y - 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X += 4f;
                      s1.X += 4;
                      s1.Width = 8;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x, y - 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X += 8f;
                      s1.X += 8;
                      s1.Width = 4;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y - 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.Y += 4f;
                      s1.Y += 4;
                      s1.Height = 8;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X -= 12f;
                      s1.X -= 12;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.Y += 8f;
                      s1.Y += 8;
                      s1.Height = 4;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y + 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X += 4f;
                      s1.X += 4;
                      s1.Width = 8;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x, y + 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X += 8f;
                      s1.X += 8;
                      s1.Width = 4;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y + 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X -= 8f;
                      pos1.Y -= 8f;
                      s1.X -= 8;
                      s1.Y -= 8;
                      s1.Width = 8;
                      s1.Height = 8;
                      if (flag)
                        WorldView.shine(ref colorUnsafe1, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe1);
                    }
                    else if ((int) colorUnsafe1.R > 38 || (double) colorUnsafe1.G > 41.7999992370605 || (double) colorUnsafe1.B > 45.6000022888184)
                    {
                      s1.Width = 8;
                      s1.Height = 8;
                      Color colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y - 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X += 8f;
                      s1.X += 8;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y - 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.Y += 8f;
                      s1.Y += 8;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, y + 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                      pos1.X -= 8f;
                      s1.X -= 8;
                      colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, y + 1);
                      colorUnsafe2.R = (byte) ((int) colorUnsafe1.R + (int) colorUnsafe2.R >> 1);
                      colorUnsafe2.G = (byte) ((int) colorUnsafe1.G + (int) colorUnsafe2.G >> 1);
                      colorUnsafe2.B = (byte) ((int) colorUnsafe1.B + (int) colorUnsafe2.B >> 1);
                      if (flag)
                        WorldView.shine(ref colorUnsafe2, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe2);
                    }
                    else
                    {
                      if (flag)
                        WorldView.shine(ref colorUnsafe1, type);
                      SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe1);
                    }
                  }
                  else
                  {
                    if (this.SMOOTH_LIGHT && flag)
                      WorldView.shine(ref colorUnsafe1, type);
                    SpriteSheet<_sheetTiles>.Draw(id, ref pos1, ref s1, colorUnsafe1);
                  }
                }
              }
            }
          }
          while (++y < num2);
        }
        while (++x < num1);
      }
      Main.tileSolid[10] = true;
    }

    private unsafe void DrawWater(bool bg = false)
    {
      int num1 = this.evilTiles / 7;
      if (num1 > 50)
        num1 = 50;
      int num2 = 256 - num1;
      int num3 = 256 - (num1 << 1);
      int x = (int) this.firstTileX;
      int num4 = (int) this.lastTileX;
      int num5 = (int) this.firstTileY;
      int num6 = (int) this.lastTileY;
      if (x < 5)
        x = 5;
      if (num5 < 5)
        num5 = 5;
      if (num4 > (int) Main.maxTilesX - 5)
        num4 = (int) Main.maxTilesX - 5;
      if (num6 > (int) Main.maxTilesY - 5)
        num6 = (int) Main.maxTilesY - 5;
      Vector2 vector2_1 = new Vector2();
      Vector2 vector2_2 = new Vector2();
      Rectangle s1 = new Rectangle();
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        do
        {
          int num7 = num5;
          Tile* tilePtr2 = tilePtr1 + (x * 1440 + num7);
          vector2_2.X = (float) (x << 4);
          do
          {
            int num8 = (int) tilePtr2->liquid;
            if (num8 > 0 && (bg || (int) tilePtr2->active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr2->type]) && (bg || this.lighting.IsNotBlackUnsafe(x, num7)))
            {
              Color colorUnsafe1 = this.lighting.GetColorUnsafe(x, num7);
              int id = (int) tilePtr2->lava == 0 ? 14 : 15;
              int num9 = bg ? (int) byte.MaxValue : (id == 15 ? 230 : 128);
              vector2_2.Y = (float) (num7 << 4);
              s1.Width = 16;
              Tile* tilePtr3 = tilePtr2 - 1;
              if ((int) tilePtr3->liquid == 0)
              {
                s1.Y = 0;
                s1.Height = Math.Max(1, num8 >> 4);
                vector2_2.Y += (float) (16 - s1.Height);
              }
              else
              {
                s1.Y = 4;
                s1.Height = 16;
              }
              tilePtr2 = tilePtr3 + 1;
              if (id == 15 && (int) this.dustLocal.lavaBubbles < 128 && Main.hasFocus)
              {
                if (num8 > 200 && Main.rand.Next(700) == 0)
                  this.dustLocal.NewDust(x << 4, num7 << 4, 16, 16, 35, 0.0, 0.0, 0, new Color(), 1.0);
                else if (s1.Y == 0 && Main.rand.Next(350) == 0)
                {
                  Dust* dustPtr = this.dustLocal.NewDust(x << 4, (num7 << 4) + (num8 >> 4) - 8, 16, 8, 35, 0.0, 0.0, 50, new Color(), 1.5);
                  if ((IntPtr) dustPtr != IntPtr.Zero)
                  {
                    dustPtr->velocity.X *= 1.6f;
                    dustPtr->velocity.Y *= 0.8f;
                    dustPtr->velocity.Y -= (float) Main.rand.Next(1, 7) * 0.1f;
                    if (Main.rand.Next(10) == 0)
                      dustPtr->velocity.Y *= (float) Main.rand.Next(2, 5);
                    dustPtr->noGravity = true;
                  }
                }
              }
              colorUnsafe1.R = (byte) ((int) colorUnsafe1.R * num9 >> 8);
              colorUnsafe1.G = (byte) ((int) colorUnsafe1.G * num9 >> 8);
              colorUnsafe1.B = (byte) ((int) colorUnsafe1.B * num9 >> 8);
              colorUnsafe1.A = (byte) num9;
              if (id == 14)
                colorUnsafe1.B = (byte) ((int) colorUnsafe1.B * num3 >> 8);
              else
                colorUnsafe1.R = (byte) ((int) colorUnsafe1.R * num2 >> 8);
              Vector2 pos;
              if (this.SMOOTH_LIGHT && !bg)
              {
                Color color = colorUnsafe1;
                if (id == 14 && ((int) color.R > 201 || (double) color.G > 221.1 || (double) color.B > 241.2) || ((int) color.R > 226 || (double) color.G > 248.6 || (double) color.B > 271.2))
                {
                  for (int index = 0; index < 4; ++index)
                  {
                    int num10 = 0;
                    int num11 = 0;
                    int num12 = 8;
                    int num13 = 8;
                    Color colorUnsafe2 = this.lighting.GetColorUnsafe(x, num7);
                    if (index == 0)
                    {
                      if (this.lighting.Brighter(x, num7 - 1, x - 1, num7))
                      {
                        Tile* tilePtr4 = tilePtr2 - 1440;
                        if ((int) tilePtr4->active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, num7);
                        tilePtr2 = tilePtr4 + 1440;
                      }
                      else
                      {
                        Tile* tilePtr4 = tilePtr2 - 1;
                        if ((int) tilePtr4->active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x, num7 - 1);
                        tilePtr2 = tilePtr4 + 1;
                      }
                      if (s1.Height < 8)
                        num13 = s1.Height;
                    }
                    else if (index == 1)
                    {
                      if (this.lighting.Brighter(x, num7 - 1, x + 1, num7))
                      {
                        if ((int) tilePtr2[1440].active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, num7);
                      }
                      else
                      {
                        Tile* tilePtr4 = tilePtr2 - 1;
                        if ((int) tilePtr4->active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x, num7 - 1);
                        tilePtr2 = tilePtr4 + 1;
                      }
                      num10 = 8;
                      if (s1.Height < 8)
                        num13 = s1.Height;
                    }
                    else if (index == 2)
                    {
                      if (this.lighting.Brighter(x, num7 + 1, x - 1, num7))
                      {
                        Tile* tilePtr4 = tilePtr2 - 1440;
                        if ((int) tilePtr4->active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x - 1, num7);
                        tilePtr2 = tilePtr4 + 1440;
                      }
                      else
                      {
                        Tile* tilePtr4 = tilePtr2 + 1;
                        if ((int) tilePtr4->active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x, num7 + 1);
                        tilePtr2 = tilePtr4 - 1;
                      }
                      num11 = 8;
                      num13 = 8 - (16 - s1.Height);
                    }
                    else
                    {
                      if (this.lighting.Brighter(x, num7 + 1, x + 1, num7))
                      {
                        if ((int) tilePtr2[1440].active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x + 1, num7);
                      }
                      else
                      {
                        Tile* tilePtr4 = tilePtr2 + 1;
                        if ((int) tilePtr4->active == 0)
                          colorUnsafe2 = this.lighting.GetColorUnsafe(x, num7 + 1);
                        tilePtr2 = tilePtr4 - 1;
                      }
                      num10 = 8;
                      num11 = 8;
                      num13 = 8 - (16 - s1.Height);
                    }
                    colorUnsafe2.R = (byte) ((int) colorUnsafe2.R * num9 + (int) color.R >> 9);
                    colorUnsafe2.G = (byte) ((int) colorUnsafe2.G * num9 + (int) color.G >> 9);
                    colorUnsafe2.B = (byte) ((int) colorUnsafe2.B * num9 + (int) color.B >> 9);
                    colorUnsafe2.A = (byte) num9;
                    pos = vector2_2;
                    pos.X -= (float) (this.screenPosition.X - num10 - 32);
                    pos.Y -= (float) (this.screenPosition.Y - num11 - 32);
                    Rectangle s2 = s1;
                    s2.X += num10;
                    s2.Y += num11;
                    s2.Width = num12;
                    s2.Height = num13;
                    SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s2, colorUnsafe2);
                  }
                }
                else
                {
                  pos = vector2_2;
                  pos.X -= (float) (this.screenPosition.X - 32);
                  pos.Y -= (float) (this.screenPosition.Y - 32);
                  SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s1, colorUnsafe1);
                }
              }
              else
              {
                pos = vector2_2;
                pos.X -= (float) (this.screenPosition.X - 32);
                pos.Y -= (float) (this.screenPosition.Y - 32);
                SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s1, colorUnsafe1);
              }
            }
            ++tilePtr2;
          }
          while (++num7 < num6);
        }
        while (++x < num4);
      }
    }

    private void DrawGore()
    {
      Vector2 pivot = new Vector2();
      Vector2 pos = new Vector2();
      for (int index = 0; index < 128; ++index)
      {
        if ((int) Main.gore[index].active != 0)
        {
          int id = 256 + (int) Main.gore[index].type;
          pivot.X = (float) (SpriteSheet<_sheetSprites>.src[id].Width >> 1);
          pivot.Y = (float) (SpriteSheet<_sheetSprites>.src[id].Height >> 1);
          pos.X = Main.gore[index].position.X + pivot.X;
          pos.Y = Main.gore[index].position.Y + pivot.Y;
          Color alpha = Main.gore[index].GetAlpha(this.lighting.GetColor((int) pos.X >> 4, (int) pos.Y >> 4));
          pos.X -= (float) this.screenPosition.X;
          pos.Y -= (float) this.screenPosition.Y;
          SpriteSheet<_sheetSprites>.Draw(id, ref pos, alpha, Main.gore[index].rotation, ref pivot, Main.gore[index].scale);
        }
      }
    }

    private unsafe void DrawNPCs(bool behindTiles = false)
    {
      bool flag1 = false;
      Rectangle rectangle = new Rectangle();
      rectangle.X = this.screenPosition.X - 300;
      rectangle.Y = this.screenPosition.Y - 300;
      rectangle.Width = (int) this.viewWidth + 600;
      rectangle.Height = 1140;
      Vector2 pos1 = new Vector2();
      Color c = new Color();
      for (int index1 = 195; index1 >= 0; --index1)
      {
        int num1 = (int) Main.npc[index1].type;
        if (num1 > 0 && (int) Main.npc[index1].active != 0 && Main.npc[index1].behindTiles == behindTiles)
        {
          if ((num1 == 125 || num1 == 126) && !flag1)
          {
            flag1 = true;
            for (int index2 = 0; index2 < 196; ++index2)
            {
              if ((int) Main.npc[index2].active != 0 && index1 != index2 && ((int) Main.npc[index2].type == 125 || (int) Main.npc[index2].type == 126))
              {
                float num2 = Main.npc[index2].position.X + (float) ((int) Main.npc[index2].width >> 1);
                float num3 = Main.npc[index2].position.Y + (float) ((int) Main.npc[index2].height >> 1);
                Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) ((int) Main.npc[index1].width >> 1), Main.npc[index1].position.Y + (float) ((int) Main.npc[index1].height >> 1));
                float num4 = num2 - vector2.X;
                float num5 = num3 - vector2.Y;
                float rotCenter = (float) Math.Atan2((double) num5, (double) num4) - 1.57f;
                bool flag2 = true;
                if ((double) num4 * (double) num4 + (double) num5 * (double) num5 > 4000000.0)
                  flag2 = false;
                while (flag2)
                {
                  float num6 = (float) ((double) num4 * (double) num4 + (double) num5 * (double) num5);
                  if ((double) num6 < 1600.0)
                  {
                    flag2 = false;
                  }
                  else
                  {
                    float num7 = (float) SpriteSheet<_sheetSprites>.src[197].Height / (float) Math.Sqrt((double) num6);
                    float num8 = num4 * num7;
                    float num9 = num5 * num7;
                    vector2.X += num8;
                    vector2.Y += num9;
                    num4 = num2 - vector2.X;
                    num5 = num3 - vector2.Y;
                    pos1 = vector2;
                    pos1.X -= (float) this.screenPosition.X;
                    pos1.Y -= (float) this.screenPosition.Y;
                    SpriteSheet<_sheetSprites>.DrawRotated(197, ref pos1, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
                  }
                }
              }
            }
          }
          if (rectangle.Intersects(Main.npc[index1].aabb))
          {
            if (num1 == 101)
            {
              bool flag2 = true;
              Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) ((int) Main.npc[index1].width >> 1), Main.npc[index1].position.Y + (float) ((int) Main.npc[index1].height >> 1));
              float num2 = (float) ((double) Main.npc[index1].ai0 * 16.0 + 8.0) - vector2.X;
              float num3 = (float) ((double) Main.npc[index1].ai1 * 16.0 + 8.0) - vector2.Y;
              float rot = (float) Math.Atan2((double) num3, (double) num2) - 1.57f;
              bool flag3 = true;
              do
              {
                float scale = 0.75f;
                int sh = 28;
                float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
                if ((double) num4 < 28.0 * (double) scale)
                {
                  sh = (int) num4 - 40 + 28;
                  flag3 = false;
                }
                float num5 = 20f * scale / num4;
                float num6 = num2 * num5;
                float num7 = num3 * num5;
                vector2.X += num6;
                vector2.Y += num7;
                num2 = (float) ((double) Main.npc[index1].ai0 * 16.0 + 8.0) - vector2.X;
                num3 = (float) ((double) Main.npc[index1].ai1 * 16.0 + 8.0) - vector2.Y;
                pos1 = vector2;
                pos1.X -= (float) this.screenPosition.X;
                pos1.Y -= (float) this.screenPosition.Y;
                SpriteSheet<_sheetSprites>.Draw(flag2 ? 196 : 195, ref pos1, sh, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rot, scale);
                flag2 = !flag2;
              }
              while (flag3);
            }
            else if ((int) Main.npc[index1].aiStyle == 13)
            {
              Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) ((int) Main.npc[index1].width >> 1), Main.npc[index1].position.Y + (float) ((int) Main.npc[index1].height >> 1));
              float num2 = (float) ((double) Main.npc[index1].ai0 * 16.0 + 8.0) - vector2.X;
              float num3 = (float) ((double) Main.npc[index1].ai1 * 16.0 + 8.0) - vector2.Y;
              float rotCenter = (float) Math.Atan2((double) num3, (double) num2) - 1.57f;
              bool flag2 = true;
              do
              {
                float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
                if ((double) num4 < 40.0)
                  flag2 = false;
                float num5 = 28f / num4;
                float num6 = num2 * num5;
                float num7 = num3 * num5;
                vector2.X += num6;
                vector2.Y += num7;
                num2 = (float) ((double) Main.npc[index1].ai0 * 16.0 + 8.0) - vector2.X;
                num3 = (float) ((double) Main.npc[index1].ai1 * 16.0 + 8.0) - vector2.Y;
                pos1 = vector2;
                pos1.X -= (float) this.screenPosition.X;
                pos1.Y -= (float) this.screenPosition.Y;
                SpriteSheet<_sheetSprites>.DrawRotated(num1 == 56 ? 190 : 189, ref pos1, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
              }
              while (flag2);
            }
            if (num1 == 36)
            {
              Vector2 vector2 = new Vector2((float) ((double) Main.npc[index1].position.X + (double) ((int) Main.npc[index1].width >> 1) - 5.0 * (double) Main.npc[index1].ai0), Main.npc[index1].position.Y + 20f);
              for (int index2 = 0; index2 < 2; ++index2)
              {
                float num2 = Main.npc[(int) Main.npc[index1].ai1].position.X + (float) ((int) Main.npc[(int) Main.npc[index1].ai1].width >> 1) - vector2.X;
                float num3 = Main.npc[(int) Main.npc[index1].ai1].position.Y + (float) ((int) Main.npc[(int) Main.npc[index1].ai1].height >> 1) - vector2.Y;
                float num4;
                float num5;
                float num6;
                if (index2 == 0)
                {
                  num4 = num2 - 200f * Main.npc[index1].ai0;
                  num5 = num3 + 130f;
                  num6 = 92f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
                }
                else
                {
                  num4 = num2 - 50f * Main.npc[index1].ai0;
                  num5 = num3 + 80f;
                  num6 = 60f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
                }
                vector2.X += num4 * num6;
                vector2.Y += num5 * num6;
                pos1.X = vector2.X - (float) this.screenPosition.X;
                pos1.Y = vector2.Y - (float) this.screenPosition.Y;
                SpriteSheet<_sheetSprites>.DrawRotated(3, ref pos1, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), (float) Math.Atan2((double) num5, (double) num4) - 1.57f);
                if (index2 == 0)
                {
                  vector2.X += (float) ((double) num4 * (double) num6 * 0.5);
                  vector2.Y += (float) ((double) num5 * (double) num6 * 0.5);
                }
                else if (Main.hasFocus)
                {
                  vector2.X += (float) ((double) num4 * (double) num6 - 16.0);
                  vector2.Y += (float) ((double) num5 * (double) num6 - 6.0);
                  Dust* dustPtr = this.dustLocal.NewDust((int) vector2.X, (int) vector2.Y, 30, 10, 5, (double) num4 * 0.0199999995529652, (double) num5 * 0.0199999995529652, 0, new Color(), 2.0);
                  if ((IntPtr) dustPtr != IntPtr.Zero)
                    dustPtr->noGravity = true;
                }
              }
            }
            if ((int) Main.npc[index1].aiStyle >= 33 && (int) Main.npc[index1].aiStyle <= 36)
            {
              Vector2 vector2 = new Vector2((float) ((double) Main.npc[index1].position.X + (double) ((int) Main.npc[index1].width >> 1) - 5.0 * (double) Main.npc[index1].ai0), Main.npc[index1].position.Y + 20f);
              for (int index2 = 0; index2 < 2; ++index2)
              {
                float num2 = Main.npc[(int) Main.npc[index1].ai1].position.X + (float) ((int) Main.npc[(int) Main.npc[index1].ai1].width >> 1) - vector2.X;
                float num3 = Main.npc[(int) Main.npc[index1].ai1].position.Y + (float) ((int) Main.npc[(int) Main.npc[index1].ai1].height >> 1) - vector2.Y;
                float num4;
                float num5;
                float num6;
                if (index2 == 0)
                {
                  num4 = num2 - 200f * Main.npc[index1].ai0;
                  num5 = num3 + 130f;
                  num6 = 92f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
                }
                else
                {
                  num4 = num2 - 50f * Main.npc[index1].ai0;
                  num5 = num3 + 80f;
                  num6 = 60f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
                }
                vector2.X += num4 * num6;
                vector2.Y += num5 * num6;
                pos1.X = vector2.X - (float) this.screenPosition.X;
                pos1.Y = vector2.Y - (float) this.screenPosition.Y;
                SpriteSheet<_sheetSprites>.DrawRotated(4, ref pos1, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), (float) Math.Atan2((double) num5, (double) num4) - 1.57f);
                if (index2 == 0)
                {
                  vector2.X += (float) ((double) num4 * (double) num6 * 0.5);
                  vector2.Y += (float) ((double) num5 * (double) num6 * 0.5);
                }
                else if (Main.hasFocus)
                {
                  vector2.X += (float) ((double) num4 * (double) num6 - 16.0);
                  vector2.Y += (float) ((double) num5 * (double) num6 - 6.0);
                  Dust* dustPtr = this.dustLocal.NewDust((int) vector2.X, (int) vector2.Y, 30, 10, 6, (double) num4 * 0.0199999995529652, (double) num5 * 0.0199999995529652, 0, new Color(), 2.5);
                  if ((IntPtr) dustPtr != IntPtr.Zero)
                    dustPtr->noGravity = true;
                }
              }
            }
            else if ((int) Main.npc[index1].aiStyle == 20)
            {
              Vector2 vector2 = new Vector2(Main.npc[index1].position.X + (float) ((int) Main.npc[index1].width >> 1), Main.npc[index1].position.Y + (float) ((int) Main.npc[index1].height >> 1));
              float num2 = Main.npc[index1].ai1 - vector2.X;
              float num3 = Main.npc[index1].ai2 - vector2.Y;
              float rot = (float) Math.Atan2((double) num3, (double) num2) - 1.57f;
              Main.npc[index1].rotation = rot;
              bool flag2 = true;
              while (flag2)
              {
                int sh = 12;
                float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
                if ((double) num4 < 20.0)
                {
                  sh = (int) num4 - 20 + 12;
                  flag2 = false;
                }
                float num5 = 12f / num4;
                float num6 = num2 * num5;
                float num7 = num3 * num5;
                vector2.X += num6;
                vector2.Y += num7;
                num2 = Main.npc[index1].ai1 - vector2.X;
                num3 = Main.npc[index1].ai2 - vector2.Y;
                pos1 = vector2;
                pos1.X -= (float) this.screenPosition.X;
                pos1.Y -= (float) this.screenPosition.Y;
                SpriteSheet<_sheetSprites>.Draw(198, ref pos1, sh, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rot, 1f);
              }
              pos1.X = Main.npc[index1].ai1 - (float) this.screenPosition.X;
              pos1.Y = Main.npc[index1].ai2 - (float) this.screenPosition.Y;
              SpriteSheet<_sheetSprites>.DrawRotated(1474, ref pos1, this.lighting.GetColor((int) Main.npc[index1].ai1 >> 4, (int) Main.npc[index1].ai2 >> 4), rot - 0.75f);
            }
            Color newColor = this.lighting.GetColor(Main.npc[index1].aabb.X + ((int) Main.npc[index1].width >> 1) >> 4, Main.npc[index1].aabb.Y + ((int) Main.npc[index1].height >> 1) >> 4);
            if (behindTiles && num1 != 113 && num1 != 114)
            {
              int num2 = Main.npc[index1].aabb.X - 8 >> 4;
              int num3 = Main.npc[index1].aabb.X + (int) Main.npc[index1].width + 8 >> 4;
              int num4 = Main.npc[index1].aabb.Y - 8 >> 4;
              int num5 = Main.npc[index1].aabb.Y + (int) Main.npc[index1].height + 8 >> 4;
              for (int x = num2; x <= num3; ++x)
              {
                for (int y = num4; y <= num5; ++y)
                {
                  if ((double) this.lighting.Brightness(x, y) == 0.0)
                  {
                    newColor.PackedValue = 4278190080U;
                    goto label_64;
                  }
                }
              }
            }
label_64:
            if (Main.npc[index1].poisoned)
              Player.buffColor(ref newColor, 0.65, 1.0, 0.75);
            if (this.player.detectCreature && Main.npc[index1].lifeMax > 1)
            {
              if ((int) newColor.R < 150)
              {
                newColor.A = UI.mouseTextBrightness;
                if ((int) newColor.R < 50)
                  newColor.R = (byte) 50;
              }
              if ((int) newColor.G < 200)
                newColor.G = (byte) 200;
              if ((int) newColor.B < 100)
                newColor.B = (byte) 100;
              if (Main.hasFocus && Main.rand.Next(52) == 0)
              {
                Dust* dustPtr = this.dustLocal.NewDust(Main.npc[index1].aabb.X, Main.npc[index1].aabb.Y, (int) Main.npc[index1].width, (int) Main.npc[index1].height, 15, 0.0, 0.0, 150, new Color(), 0.800000011920929);
                if ((IntPtr) dustPtr != IntPtr.Zero)
                {
                  dustPtr->velocity.X *= 0.1f;
                  dustPtr->velocity.Y *= 0.1f;
                  dustPtr->noLight = true;
                }
              }
            }
            if (num1 == 50)
            {
              Vector2 vector2 = new Vector2();
              vector2.Y = -Main.npc[index1].velocity.Y;
              vector2.X = Main.npc[index1].velocity.X * -2f;
              float rotCenter = Main.npc[index1].velocity.X * 0.05f;
              if ((int) Main.npc[index1].frameY == 120)
                vector2.Y += 2f;
              else if ((int) Main.npc[index1].frameY == 360)
                vector2.Y -= 2f;
              else if ((int) Main.npc[index1].frameY == 480)
                vector2.Y -= 6f;
              pos1.X = Main.npc[index1].position.X - (float) this.screenPosition.X + (float) ((int) Main.npc[index1].width >> 1) + vector2.X;
              pos1.Y = Main.npc[index1].position.Y - (float) this.screenPosition.Y + (float) ((int) Main.npc[index1].height >> 1) + vector2.Y;
              SpriteSheet<_sheetSprites>.DrawRotated(1088, ref pos1, newColor, rotCenter);
            }
            else if (num1 == 71)
            {
              Vector2 vector2 = new Vector2();
              vector2.Y = Main.npc[index1].velocity.Y * -0.3f;
              vector2.X = Main.npc[index1].velocity.X * -0.6f;
              float rotCenter = Main.npc[index1].velocity.X * 0.09f;
              if ((int) Main.npc[index1].frameY == 120)
                vector2.Y += 2f;
              else if ((int) Main.npc[index1].frameY == 360)
                vector2.Y -= 2f;
              else if ((int) Main.npc[index1].frameY == 480)
                vector2.Y -= 6f;
              pos1.X = Main.npc[index1].position.X - (float) this.screenPosition.X + (float) ((int) Main.npc[index1].width >> 1) + vector2.X;
              pos1.Y = Main.npc[index1].position.Y - (float) this.screenPosition.Y + (float) ((int) Main.npc[index1].height >> 1) + vector2.Y;
              SpriteSheet<_sheetSprites>.DrawRotated(778, ref pos1, newColor, rotCenter);
            }
            else if (num1 == 69 || num1 == 147)
            {
              pos1.X = Main.npc[index1].position.X - (float) this.screenPosition.X + (float) ((int) Main.npc[index1].width >> 1);
              pos1.Y = (float) ((double) Main.npc[index1].position.Y - (double) this.screenPosition.Y + (double) Main.npc[index1].height + 14.0);
              SpriteSheet<_sheetSprites>.DrawRotated(num1 == 69 ? 2 : 0, ref pos1, newColor, (float) (-(double) Main.npc[index1].rotation * 0.300000011920929));
            }
            float num8 = 0.0f;
            float num9 = 0.0f;
            int num10 = SpriteSheet<_sheetSprites>.src[1088 + num1].Width;
            Vector2 pivot = new Vector2();
            pivot.X = (float) (num10 >> 1);
            pivot.Y = (float) ((int) Main.npc[index1].frameHeight >> 1);
            switch (num1)
            {
              case 134:
              case 135:
              case 136:
                num9 = 30f;
                break;
              case 159:
              case 160:
              case 161:
              case 162:
              case 163:
              case 164:
              case 87:
              case 88:
              case 89:
              case 90:
              case 91:
              case 92:
                num9 = 56f;
                break;
              case 166:
                pivot.Y *= 0.5f;
                break;
              case 108:
              case 124:
                num8 = 2f;
                break;
              case 125:
              case 126:
                pivot = new Vector2(55f, 107f);
                num9 = 30f;
                break;
              case 48:
                num9 = 32f;
                break;
              case 49:
              case 51:
                num9 = 4f;
                break;
              case 60:
                num9 = 10f;
                break;
              case 62:
              case 65:
              case 66:
                num9 = 14f;
                break;
              case 63:
              case 64:
              case 103:
                num9 = 4f;
                pivot.Y += 4f;
                break;
              case 69:
                num9 = 4f;
                pivot.Y += 8f;
                break;
              case 70:
                num9 = -4f;
                break;
              case 72:
                num9 = -2f;
                break;
              case 83:
              case 84:
                num9 = 20f;
                break;
              case 94:
                num9 = 14f;
                break;
              case 95:
              case 96:
              case 97:
              case 98:
              case 99:
              case 100:
              case 7:
              case 8:
              case 9:
                num9 = 13f;
                break;
              case 4:
                pivot.Y = 107f;
                break;
              case 6:
              case 13:
              case 14:
              case 15:
              case 39:
              case 40:
              case 41:
                num9 = 26f;
                break;
              case 10:
              case 11:
              case 12:
                num9 = 8f;
                break;
            }
            float num11 = num9 * Main.npc[index1].scale;
            pos1 = new Vector2((float) ((double) Main.npc[index1].position.X - (double) this.screenPosition.X + (double) ((int) Main.npc[index1].width >> 1) - (double) num10 * (double) Main.npc[index1].scale * 0.5 + (double) pivot.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].position.Y - (double) this.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npc[index1].frameHeight * (double) Main.npc[index1].scale + 4.0 + (double) pivot.Y * (double) Main.npc[index1].scale) + num11 + num8);
            if ((int) Main.npc[index1].aiStyle == 10 || num1 == 72)
              newColor = Color.White;
            SpriteEffects e = (int) Main.npc[index1].spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            if (num1 == 83 || num1 == 84 || num1 == 151)
              SpriteSheet<_sheetSprites>.Draw(1088 + num1, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, Color.White, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
            else if (num1 >= 87 && num1 <= 92 || num1 >= 159 && num1 <= 164)
            {
              c = Main.npc[index1].GetAlpha(newColor);
              byte num2 = (byte) (((int) this.time.tileColor.R + (int) this.time.tileColor.G + (int) this.time.tileColor.B) / 3);
              if ((int) c.R < (int) num2)
                c.R = num2;
              if ((int) c.G < (int) num2)
                c.G = num2;
              if ((int) c.B < (int) num2)
                c.B = num2;
              SpriteSheet<_sheetSprites>.Draw(1088 + num1, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
            }
            else
            {
              if (num1 == 94)
              {
                int index2 = 1;
                while (index2 < 6)
                {
                  c = Main.npc[index1].GetAlpha(newColor);
                  c.R = (byte) ((int) c.R * (10 - index2) / 15);
                  c.G = (byte) ((int) c.G * (10 - index2) / 15);
                  c.B = (byte) ((int) c.B * (10 - index2) / 15);
                  c.A = (byte) ((int) c.A * (10 - index2) / 15);
                  pos1 = new Vector2((float) ((double) Main.npc[index1].oldPos[index2].X - (double) this.screenPosition.X + (double) ((int) Main.npc[index1].width >> 1) - (double) num10 * (double) Main.npc[index1].scale * 0.5 + (double) pivot.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index2].Y - (double) this.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npc[index1].frameHeight * (double) Main.npc[index1].scale + 4.0 + (double) pivot.Y * (double) Main.npc[index1].scale) + num11);
                  SpriteSheet<_sheetSprites>.Draw(1088 + num1, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
                  index2 += 2;
                }
              }
              else if (num1 == 125 || num1 == 126 || (num1 == (int) sbyte.MaxValue || num1 == 128) || (num1 == 129 || num1 == 130 || (num1 == 131 || num1 == 139)) || num1 == 140)
              {
                int index2 = 9;
                while (index2 >= 0)
                {
                  c = Main.npc[index1].GetAlpha(newColor);
                  c.R = (byte) ((int) c.R * (10 - index2) / 20);
                  c.G = (byte) ((int) c.G * (10 - index2) / 20);
                  c.B = (byte) ((int) c.B * (10 - index2) / 20);
                  c.A = (byte) ((int) c.A * (10 - index2) / 20);
                  pos1 = new Vector2((float) ((double) Main.npc[index1].oldPos[index2].X - (double) this.screenPosition.X + (double) ((int) Main.npc[index1].width >> 1) - (double) num10 * (double) Main.npc[index1].scale * 0.5 + (double) pivot.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index2].Y - (double) this.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npc[index1].frameHeight * (double) Main.npc[index1].scale + 4.0 + (double) pivot.Y * (double) Main.npc[index1].scale) + num11);
                  SpriteSheet<_sheetSprites>.Draw(1088 + num1, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
                  index2 -= 2;
                }
              }
              SpriteSheet<_sheetSprites>.Draw(1088 + num1, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, Main.npc[index1].GetAlpha(newColor), Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
              if ((int) Main.npc[index1].color.PackedValue != 0)
                SpriteSheet<_sheetSprites>.Draw(1088 + num1, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, Main.npc[index1].GetColor(newColor), Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
              if (Main.npc[index1].confused)
              {
                Vector2 pos2 = pos1;
                pos2.Y -= (float) (SpriteSheet<_sheetSprites>.src[203].Height + 20);
                c.PackedValue = 1190853370U;
                SpriteSheet<_sheetSprites>.Draw(203, ref pos2, c, Main.npc[index1].velocity.X * -0.05f, UI.essScale + 0.2f);
              }
              if (num1 == 125)
              {
                c.PackedValue = 16777215U;
                SpriteSheet<_sheetSprites>.Draw(220, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
              }
              else if (num1 == 139)
              {
                c.PackedValue = 16777215U;
                SpriteSheet<_sheetSprites>.Draw(1349, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
              }
              else if (num1 == (int) sbyte.MaxValue)
              {
                c.PackedValue = 13158600U;
                SpriteSheet<_sheetSprites>.Draw(137, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
              }
              else if (num1 == 131)
              {
                c.PackedValue = 13158600U;
                SpriteSheet<_sheetSprites>.Draw(138, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
              }
              else if (num1 == 120 || num1 == 154)
              {
                for (int index2 = 1; index2 < Main.npc[index1].oldPos.Length; ++index2)
                {
                  c.R = (byte) (150 * (10 - index2) / 15);
                  c.G = (byte) (100 * (10 - index2) / 15);
                  c.B = (byte) (150 * (10 - index2) / 15);
                  c.A = (byte) (50 * (10 - index2) / 15);
                  pos1 = new Vector2((float) ((double) Main.npc[index1].oldPos[index2].X - (double) this.screenPosition.X + (double) ((int) Main.npc[index1].width >> 1) - (double) num10 * (double) Main.npc[index1].scale * 0.5 + (double) pivot.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index2].Y - (double) this.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npc[index1].frameHeight * (double) Main.npc[index1].scale + 4.0 + (double) pivot.Y * (double) Main.npc[index1].scale) + num11);
                  SpriteSheet<_sheetSprites>.Draw(199, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
                }
              }
              else if (num1 >= 134 && num1 <= 136)
              {
                if ((int) newColor.PackedValue != -16777216)
                {
                  c.PackedValue = 16777215U;
                  SpriteSheet<_sheetSprites>.Draw(214 + num1 - 134, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
                }
              }
              else if (num1 == 137 || num1 == 138)
              {
                for (int index2 = 1; index2 < Main.npc[index1].oldPos.Length; ++index2)
                {
                  c.R = (byte) (150 * (10 - index2) / 15);
                  c.G = (byte) (100 * (10 - index2) / 15);
                  c.B = (byte) (150 * (10 - index2) / 15);
                  c.A = (byte) (50 * (10 - index2) / 15);
                  pos1 = new Vector2((float) ((double) Main.npc[index1].oldPos[index2].X - (double) this.screenPosition.X + (double) ((int) Main.npc[index1].width >> 1) - (double) num10 * (double) Main.npc[index1].scale * 0.5 + (double) pivot.X * (double) Main.npc[index1].scale), (float) ((double) Main.npc[index1].oldPos[index2].Y - (double) this.screenPosition.Y + (double) Main.npc[index1].height - (double) Main.npc[index1].frameHeight * (double) Main.npc[index1].scale + 4.0 + (double) pivot.Y * (double) Main.npc[index1].scale) + num11);
                  SpriteSheet<_sheetSprites>.Draw(1088 + num1, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, c, Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
                }
              }
              else if (num1 == 82)
              {
                SpriteSheet<_sheetSprites>.Draw(1488, ref pos1, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
                for (int index2 = 1; index2 < 10; ++index2)
                {
                  Vector2 pos2 = pos1 - Main.npc[index1].velocity * ((float) index2 * 0.5f);
                  SpriteSheet<_sheetSprites>.Draw(1488, ref pos2, (int) Main.npc[index1].frameY, (int) Main.npc[index1].frameHeight, new Color(110 - index2 * 10, 110 - index2 * 10, 110 - index2 * 10, 110 - index2 * 10), Main.npc[index1].rotation, ref pivot, Main.npc[index1].scale, e);
                }
              }
            }
          }
        }
      }
    }

    private void DrawWoF()
    {
      Vector2 pos = new Vector2();
      if (NPC.wof < 0 || !this.player.horrified)
        return;
      float num1 = Main.npc[NPC.wof].position.X + (float) ((int) Main.npc[NPC.wof].width >> 1);
      float num2 = Main.npc[NPC.wof].position.Y + (float) ((int) Main.npc[NPC.wof].height >> 1);
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0 && Main.player[index].tongued && !Main.player[index].dead)
        {
          Vector2 vector2 = new Vector2(Main.player[index].position.X + 10f, Main.player[index].position.Y + 21f);
          float num3 = num1 - vector2.X;
          float num4 = num2 - vector2.Y;
          float rotCenter = (float) Math.Atan2((double) num4, (double) num3) - 1.57f;
          bool flag = true;
          do
          {
            float num5 = (float) ((double) num3 * (double) num3 + (double) num4 * (double) num4);
            if ((double) num5 < 1600.0)
            {
              flag = false;
            }
            else
            {
              float num6 = (float) SpriteSheet<_sheetSprites>.src[197].Height / (float) Math.Sqrt((double) num5);
              float num7 = num3 * num6;
              float num8 = num4 * num6;
              vector2.X += num7;
              vector2.Y += num8;
              num3 = num1 - vector2.X;
              num4 = num2 - vector2.Y;
              pos = vector2;
              pos.X -= (float) this.screenPosition.X;
              pos.Y -= (float) this.screenPosition.Y;
              SpriteSheet<_sheetSprites>.DrawRotated(197, ref pos, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter);
            }
          }
          while (flag);
        }
      }
      float num9 = (float) (NPC.wofB - NPC.wofT);
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.npc[index].active != 0 && (int) Main.npc[index].aiStyle == 29)
        {
          bool flag1 = (double) Main.npc[index].frameCounter > 7.0;
          float num3 = (float) NPC.wofT + num9 * Main.npc[index].ai0;
          Vector2 vector2 = new Vector2(Main.npc[index].position.X + (float) ((int) Main.npc[index].width >> 1), Main.npc[index].position.Y + (float) ((int) Main.npc[index].height >> 1));
          float num4 = num1 - vector2.X;
          float num5 = num3 - vector2.Y;
          float rotCenter = (float) Math.Atan2((double) num5, (double) num4) - 1.57f;
          bool flag2 = true;
          while (flag2)
          {
            SpriteEffects se = SpriteEffects.None;
            if (flag1)
            {
              se = SpriteEffects.FlipHorizontally;
              flag1 = false;
            }
            else
              flag1 = true;
            float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
            if ((double) num6 < 40.0)
              flag2 = false;
            float num7 = 28f / num6;
            float num8 = num4 * num7;
            float num10 = num5 * num7;
            vector2.X += num8;
            vector2.Y += num10;
            num4 = num1 - vector2.X;
            num5 = num3 - vector2.Y;
            pos = vector2;
            pos.X -= (float) this.screenPosition.X;
            pos.Y -= (float) this.screenPosition.Y;
            SpriteSheet<_sheetSprites>.Draw(197, ref pos, this.lighting.GetColor((int) vector2.X >> 4, (int) vector2.Y >> 4), rotCenter, se);
          }
        }
      }
      int num11 = 140;
      float num12 = (float) NPC.wofT;
      float num13 = (float) NPC.wofB;
      float num14 = (float) (this.screenPosition.Y + 540);
      float num15 = (float) ((int) (((double) num12 - (double) this.screenPosition.Y) / (double) num11) + 1) * (float) num11;
      if ((double) num15 > 0.0)
        num12 -= num15;
      float num16 = num12;
      float num17 = Main.npc[NPC.wof].position.X;
      float num18 = num14 - num12;
      SpriteEffects e = SpriteEffects.None;
      if ((int) Main.npc[NPC.wof].spriteDirection == 1)
        e = SpriteEffects.FlipHorizontally;
      if ((int) Main.npc[NPC.wof].direction > 0)
        num17 -= 80f;
      int num19 = 0;
      if (++NPC.wofF > 12)
      {
        num19 = 280;
        if (NPC.wofF > 17)
          NPC.wofF = 0;
      }
      else if (NPC.wofF > 6)
        num19 = 140;
      do
      {
        float num3 = num14 - num16;
        if ((double) num3 > (double) num11)
          num3 = (float) num11;
        int num4 = 0;
        int num5 = SpriteSheet<_sheetSprites>.src[1483].Width;
        do
        {
          int x = (int) num17 + (num5 >> 1) >> 4;
          int y = (int) num16 + num4 >> 4;
          pos.X = num17 - (float) this.screenPosition.X;
          pos.Y = num16 + (float) num4 - (float) this.screenPosition.Y;
          SpriteSheet<_sheetSprites>.Draw(1483, ref pos, num19 + num4, 16, this.lighting.GetColor(x, y), e);
          num4 += 16;
        }
        while ((double) num4 < (double) num3);
        num16 += (float) num11;
      }
      while ((double) num16 < (double) num14);
    }

    public void DrawNPCHouse()
    {
      for (int index1 = 0; index1 < 196; ++index1)
      {
        if ((int) Main.npc[index1].active != 0 && Main.npc[index1].townNPC && (!Main.npc[index1].homeless && (int) Main.npc[index1].homeTileX > 0) && ((int) Main.npc[index1].homeTileY > 0 && (int) Main.npc[index1].type != 37))
        {
          int x = (int) Main.npc[index1].homeTileX;
          int index2 = (int) Main.npc[index1].homeTileY - 1;
          while ((int) Main.tile[x, index2].active == 0 || !Main.tileSolid[(int) Main.tile[x, index2].type])
          {
            --index2;
            if (index2 < 10)
              break;
          }
          int num1 = 18;
          if ((int) Main.tile[x, index2].type == 19)
            num1 -= 8;
          int y = index2 + 1;
          Color color = this.lighting.GetColor(x, y);
          SpriteSheet<_sheetSprites>.Draw(439, (x << 4) - this.screenPosition.X + 8 - 16, (y << 4) - this.screenPosition.Y + num1 - 20, color);
          int id = Main.npc[index1].getHeadTextureId() + 1255;
          float scaleCenter = 1f;
          float num2 = (float) SpriteSheet<_sheetSprites>.src[id].Height;
          if ((double) SpriteSheet<_sheetSprites>.src[id].Width > (double) num2)
            num2 = (float) SpriteSheet<_sheetSprites>.src[id].Width;
          if ((double) num2 > 24.0)
            scaleCenter = 24f / num2;
          SpriteSheet<_sheetSprites>.DrawScaled(id, (x << 4) - this.screenPosition.X + 8, (y << 4) - this.screenPosition.Y + num1 + 2, scaleCenter, color);
        }
      }
    }

    public void DrawGrid()
    {
      int num1 = (this.screenPosition.X & -16) - this.screenPosition.X;
      int num2 = (this.screenPosition.Y & -16) - this.screenPosition.Y;
      int num3 = (int) this.viewWidth >> 5;
      Color c = new Color(100, 100, 100, 15);
      for (int index1 = 0; index1 <= num3; ++index1)
      {
        for (int index2 = 0; index2 <= 16; ++index2)
          SpriteSheet<_sheetSprites>.Draw(431, (index1 << 6) + num1, (index2 << 6) + num2, c);
      }
    }

    public unsafe void spawnSnow()
    {
      if (this.snowTiles <= 1024 || this.player.aabb.Y >= Main.worldSurfacePixels || (int) this.dustLocal.snowDust >= 32)
        return;
      int upperBound = 4096 / this.snowTiles;
      if (Main.rand.Next(upperBound) != 0)
        return;
      int num = Main.rand.Next((int) this.viewWidth + 32) - 16;
      int Y = this.screenPosition.Y;
      if (num < 0 || num > 960)
        Y += Main.rand.Next(270) + 54;
      Dust* dustPtr = this.dustLocal.NewDust(num + this.screenPosition.X, Y, 10, 10, 76, 0.0, 0.0, 0, new Color(), 1.0);
      if ((IntPtr) dustPtr == IntPtr.Zero)
        return;
      dustPtr->velocity.X = Cloud.windSpeed + (float) Main.rand.Next(-10, 10) * 0.1f;
      dustPtr->velocity.Y = (float) (3.0 + (double) Main.rand.Next(30) * 0.100000001490116 * (double) dustPtr->scale);
    }

    public enum Type
    {
      FULLSCREEN,
      TOP_LEFT,
      TOP_RIGHT,
      BOTTOM_LEFT,
      BOTTOM_RIGHT,
      TOP,
      BOTTOM,
      NONE,
    }

    private struct Spec
    {
      public short X;
      public short Y;
      public Color tileColor;
    }
  }
}
