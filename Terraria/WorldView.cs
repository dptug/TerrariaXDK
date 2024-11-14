using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria;

public class WorldView : IDisposable
{
	public enum Type
	{
		FULLSCREEN,
		TOP_LEFT,
		TOP_RIGHT,
		BOTTOM_LEFT,
		BOTTOM_RIGHT,
		TOP,
		BOTTOM,
		NONE
	}

	private struct Spec
	{
		public short X;

		public short Y;

		public Color tileColor;
	}

	public const bool DRAW_TO_SCREEN = false;

	public const int OFFSCREEN_RANGE_X = 32;

	public const int OFFSCREEN_RANGE_TOP = 32;

	public const int OFFSCREEN_RANGE_BOTTOM = 64;

	public const int OFFSCREEN_RANGE_VERTICAL = 96;

	public const float CAVE_PARALLAX = 0.9f;

	public const float gfxQuality = 0.25f;

	private const double VIEWPORT_ANIM_STEPS = 30.0;

	private const double VIEWPORT_ANIM_THETA_DELTA = Math.PI / 60.0;

	private const double ZOOM_ANIM_STEPS = 90.0;

	private const double ZOOM_ANIM_THETA_DELTA = Math.PI / 180.0;

	private const int CLIP_AREA_EXTRA_WIDTH = 32;

	private const int CLIP_AREA_EXTRA_HEIGHT = 64;

	public const int MAX_BACKGROUNDS = 32;

	private bool SMOOTH_LIGHT = true;

	private bool isDisposed;

	public short viewWidth;

	private Type viewType = Type.NONE;

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

	public Rectangle clipArea = new Rectangle(0, 0, 0, 604);

	public Rectangle viewArea = new Rectangle(0, 0, 0, 540);

	public Vector2i screenPosition;

	public Vector2i screenLastPosition;

	public int quickBG = 2;

	public int bgDelay;

	public int bgStyle;

	public float[] bgAlpha = new float[8];

	public float[] bgAlpha2 = new float[8];

	public DustPool dustLocal;

	public ItemTextPool itemTextLocal;

	public Lighting lighting = new Lighting();

	public int inactiveTiles;

	public int sandTiles;

	public int evilTiles;

	public int snowTiles;

	public int holyTiles;

	public int meteorTiles;

	public int jungleTiles;

	public int dungeonTiles;

	public int musicBox = -1;

	public bool[] drawNpcName = new bool[196];

	public Vector2i sceneWaterPos = default(Vector2i);

	public Vector2i sceneTilePos = default(Vector2i);

	public Vector2i sceneTile2Pos = default(Vector2i);

	public Vector2i sceneWallPos = default(Vector2i);

	public Vector2i sceneBackgroundPos = default(Vector2i);

	public Vector2i sceneBlackPos = default(Vector2i);

	private RenderTarget2D backWaterTarget;

	private RenderTarget2D waterTarget;

	private RenderTarget2D tileSolidTarget;

	private RenderTarget2D blackTarget;

	private RenderTarget2D tileNonSolidTarget;

	private RenderTarget2D wallTarget;

	private RenderTarget2D backgroundTarget;

	public static readonly short[] VIEW_WIDTH = new short[7] { 960, 960, 960, 960, 960, 1920, 1920 };

	public static readonly byte[] SAFE_AREA_OFFSETS = new byte[28]
	{
		48, 27, 48, 27, 96, 54, 0, 0, 0, 54,
		96, 0, 96, 0, 0, 54, 0, 0, 96, 54,
		96, 54, 96, 0, 96, 0, 96, 54
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

	public static GraphicsDevice graphicsDevice;

	private static Matrix halfpixelOffset;

	private static Matrix centerWideSplitscreen;

	private BasicEffect renderTargetProjection;

	public BasicEffect screenProjection;

	public static RasterizerState scissorTest;

	private Matrix viewMtx = Matrix.Identity;

	private float worldScale = 1f;

	private float worldScaleTarget = 1f;

	private float worldScalePrevious = 1f;

	private double worldScaleAnimTheta;

	public static Texture2D[] backgroundTexture = new Texture2D[32];

	private Spec[] spec = new Spec[512];

	public static Type getViewType(PlayerIndex controller, UI newUI = null)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 4; i++)
		{
			UI uI = Main.ui[i];
			if (uI == newUI || uI.view != null)
			{
				num2++;
				if (uI.controller < controller)
				{
					num++;
				}
			}
		}
		return num2 switch
		{
			2 => (Type)(5 + num), 
			3 => num switch
			{
				0 => Type.TOP, 
				1 => Type.BOTTOM_LEFT, 
				_ => Type.BOTTOM_RIGHT, 
			}, 
			4 => (Type)(1 + num), 
			_ => Type.FULLSCREEN, 
		};
	}

	public static bool AnyViewContains(int X, int Y)
	{
		int num = UI.numActiveViews;
		do
		{
			if (UI.activeView[--num].clipArea.Contains(X, Y))
			{
				return true;
			}
		}
		while (num > 0);
		return false;
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
		for (int i = 3; i < 32; i++)
		{
			backgroundTexture[i] = Content.Load<Texture2D>("Images/Background_" + i);
		}
	}

	public static void Initialize(GraphicsDevice device)
	{
		graphicsDevice = device;
		Matrix.CreateTranslation(0.5f, 0.5f, 0f, out halfpixelOffset);
		Matrix.CreateTranslation(480f, 0f, 0f, out centerWideSplitscreen);
		scissorTest = new RasterizerState();
		scissorTest.ScissorTestEnable = true;
	}

	public WorldView()
	{
		dustLocal = new DustPool(this, 128);
		itemTextLocal = new ItemTextPool(this);
		bgAlpha[0] = 1f;
		bgAlpha2[0] = 1f;
		renderTargetProjection = new BasicEffect(graphicsDevice);
		renderTargetProjection.World = Matrix.Identity;
		renderTargetProjection.View = Matrix.Identity;
		renderTargetProjection.TextureEnabled = true;
		renderTargetProjection.VertexColorEnabled = true;
		screenProjection = new BasicEffect(graphicsDevice);
		screenProjection.World = Matrix.Identity;
		screenProjection.View = Matrix.Identity;
		screenProjection.TextureEnabled = true;
		screenProjection.VertexColorEnabled = true;
	}

	public void onStartGame()
	{
		lighting.StartWorkerThread();
	}

	public void onStopGame()
	{
		lighting.StopWorkerThread();
		itemTextLocal.Clear();
	}

	public bool setViewType(Type type = Type.FULLSCREEN)
	{
		if (type == viewType)
		{
			return false;
		}
		if (type != 0)
		{
			SMOOTH_LIGHT = false;
		}
		else
		{
			SMOOTH_LIGHT = true;
			Zoom(1f);
		}
		Type type2 = viewType;
		bool flag = isFullScreen();
		int num = viewWidth;
		viewType = type;
		if (type != Type.NONE)
		{
			int num2 = VIEW_WIDTH[(int)type];
			if (num != num2)
			{
				viewWidth = (short)num2;
				clipArea.Width = num2 + 32;
				viewArea.Width = num2;
				lighting.SetWidth(num2);
			}
			currentViewport = activeViewport;
			targetViewport = VIEWPORT[(int)type];
			currentSAFE_AREA_OFFSET_L = SAFE_AREA_OFFSET_L;
			currentSAFE_AREA_OFFSET_T = SAFE_AREA_OFFSET_T;
			currentSAFE_AREA_OFFSET_R = SAFE_AREA_OFFSET_R;
			currentSAFE_AREA_OFFSET_B = SAFE_AREA_OFFSET_B;
			targetSAFE_AREA_OFFSET_L = SAFE_AREA_OFFSETS[(int)type << 2];
			targetSAFE_AREA_OFFSET_T = SAFE_AREA_OFFSETS[((int)type << 2) + 1];
			targetSAFE_AREA_OFFSET_R = SAFE_AREA_OFFSETS[((int)type << 2) + 2];
			targetSAFE_AREA_OFFSET_B = SAFE_AREA_OFFSETS[((int)type << 2) + 3];
			if (type2 != Type.NONE && flag == isFullScreen() && num == viewWidth)
			{
				viewportAnimTheta = Math.PI / 2.0;
				return false;
			}
			SAFE_AREA_OFFSET_L = targetSAFE_AREA_OFFSET_L;
			SAFE_AREA_OFFSET_T = targetSAFE_AREA_OFFSET_T;
			SAFE_AREA_OFFSET_R = targetSAFE_AREA_OFFSET_R;
			SAFE_AREA_OFFSET_B = targetSAFE_AREA_OFFSET_B;
			activeViewport = targetViewport;
			viewportAnimTheta = 0.0;
			UpdateProjection();
			int num3 = viewWidth + 64;
			int num4 = 636;
			if (backWaterTarget == null || backWaterTarget.Width != num3 || backWaterTarget.Height != num4)
			{
				DisposeRendertargets();
				backWaterTarget = new RenderTarget2D(graphicsDevice, num3, num4, mipMap: false, SurfaceFormat.Color, DepthFormat.None);
				waterTarget = new RenderTarget2D(graphicsDevice, num3, num4, mipMap: false, SurfaceFormat.Color, DepthFormat.None);
				blackTarget = new RenderTarget2D(graphicsDevice, num3, num4, mipMap: false, SurfaceFormat.Color, DepthFormat.None);
				tileSolidTarget = new RenderTarget2D(graphicsDevice, num3, num4, mipMap: false, SurfaceFormat.Color, DepthFormat.None);
				tileNonSolidTarget = new RenderTarget2D(graphicsDevice, num3, num4, mipMap: false, SurfaceFormat.Color, DepthFormat.None);
				wallTarget = new RenderTarget2D(graphicsDevice, num3, num4, mipMap: false, SurfaceFormat.Color, DepthFormat.None);
				backgroundTarget = new RenderTarget2D(graphicsDevice, num3, num4, mipMap: false, SurfaceFormat.Color, DepthFormat.None);
			}
			return true;
		}
		DisposeRendertargets();
		return true;
	}

	public void Dispose()
	{
		lighting.StopWorkerThread();
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void DisposeRendertargets()
	{
		if (backWaterTarget != null)
		{
			backWaterTarget.Dispose();
			backWaterTarget = null;
			waterTarget.Dispose();
			waterTarget = null;
			tileSolidTarget.Dispose();
			tileSolidTarget = null;
			blackTarget.Dispose();
			blackTarget = null;
			tileNonSolidTarget.Dispose();
			tileNonSolidTarget = null;
			wallTarget.Dispose();
			wallTarget = null;
			backgroundTarget.Dispose();
			backgroundTarget = null;
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!isDisposed)
		{
			if (disposing)
			{
				DisposeRendertargets();
			}
			isDisposed = true;
		}
	}

	public bool isFullScreen()
	{
		return viewType == Type.FULLSCREEN;
	}

	public static void restoreViewport()
	{
		graphicsDevice.Viewport = VIEWPORT[0];
	}

	public void PrepareDraw(int pass)
	{
		screenLastPosition = screenPosition;
		player.updateScreenPosition();
		if (screenPosition.X < 560)
		{
			screenPosition.X = 560;
		}
		else if (screenPosition.X + viewWidth > Main.rightWorld - 544 - 32)
		{
			screenPosition.X = Main.rightWorld - viewWidth - 544 - 32;
		}
		if (screenPosition.Y < 560)
		{
			screenPosition.Y = 560;
		}
		else if (screenPosition.Y + 540 > Main.bottomWorld - 544 - 32)
		{
			screenPosition.Y = Main.bottomWorld - 540 - 544 - 32;
		}
		viewArea.X = screenPosition.X;
		viewArea.Y = screenPosition.Y;
		clipArea.X = screenPosition.X - 16;
		clipArea.Y = screenPosition.Y - 32;
		firstTileX = (short)(screenPosition.X >> 4);
		firstTileY = (short)(screenPosition.Y >> 4);
		lastTileX = (short)(firstTileX + (viewWidth >> 4));
		if (lastTileX > Main.maxTilesX)
		{
			lastTileX = Main.maxTilesX;
		}
		lastTileY = (short)(firstTileY + 33);
		if (lastTileY > Main.maxTilesY)
		{
			lastTileY = Main.maxTilesY;
		}
		lighting.LightTiles(this);
		firstTileX -= 2;
		if (firstTileX < 0)
		{
			firstTileX = 0;
		}
		firstTileY -= 2;
		if (firstTileY < 0)
		{
			firstTileY = 0;
		}
		lastTileX += 2;
		if (lastTileX > Main.maxTilesX)
		{
			lastTileX = Main.maxTilesX;
		}
		lastTileY += 4;
		if (lastTileY > Main.maxTilesY)
		{
			lastTileY = Main.maxTilesY;
		}
		if (pass > 0)
		{
			Vector2i vector2i = screenPosition;
			screenPosition.X &= -2;
			screenPosition.Y &= -2;
			switch (pass)
			{
			case 1:
				RenderBackground();
				break;
			case 2:
				if (firstTileY <= Main.worldSurface)
				{
					RenderBlack();
				}
				RenderSolidTiles();
				break;
			case 3:
				RenderWalls();
				break;
			default:
				RenderNonSolidTiles();
				RenderBackWater();
				RenderWater();
				break;
			}
			screenPosition = vector2i;
		}
		if (worldScaleAnimTheta > 0.0)
		{
			worldScaleAnimTheta -= Math.PI / 180.0;
			if (worldScaleAnimTheta <= 0.0)
			{
				worldScale = worldScaleTarget;
			}
			else
			{
				double num = 1.0 - Math.Sin(worldScaleAnimTheta);
				worldScale = (float)((double)worldScalePrevious + num * (double)(worldScaleTarget - worldScalePrevious));
			}
			UpdateView();
		}
		screenProjection.View = viewMtx;
	}

	public void Zoom(float z)
	{
		if (z != worldScaleTarget)
		{
			worldScaleTarget = z;
			worldScalePrevious = worldScale;
			worldScaleAnimTheta = Math.PI / 2.0;
		}
	}

	private void UpdateProjection()
	{
		if (isFullScreen())
		{
			screenProjection.Projection = halfpixelOffset * Matrix.CreateOrthographicOffCenter(0f, activeViewport.Width, activeViewport.Height, 0f, 0f, 1f);
		}
		else
		{
			screenProjection.Projection = halfpixelOffset * Matrix.CreateOrthographicOffCenter(0f, activeViewport.Width << 1, activeViewport.Height << 1, 0f, 0f, 1f);
		}
		renderTargetProjection.Projection = halfpixelOffset * Matrix.CreateOrthographicOffCenter(0f, viewWidth + 64, 636f, 0f, 0f, 1f);
	}

	private void UpdateView()
	{
		int num = viewWidth;
		int num2 = 540;
		num >>= 1;
		num2 >>= 1;
		viewMtx = Matrix.CreateTranslation(-num, -num2, 0f) * Matrix.CreateScale(worldScale, worldScale, 1f) * Matrix.CreateTranslation(num, num2, 0f);
	}

	public void SetWorldView()
	{
		Main.spriteBatch.End();
		screenProjection.View = viewMtx;
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, screenProjection);
	}

	public void SetScreenView()
	{
		Main.spriteBatch.End();
		screenProjection.View = Matrix.Identity;
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, screenProjection);
	}

	public void SetScreenViewWideCentered()
	{
		Main.spriteBatch.End();
		screenProjection.View = ((viewWidth == 960) ? Matrix.Identity : centerWideSplitscreen);
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, screenProjection);
	}

	private void DrawCombatText()
	{
		for (int i = 0; i < 32; i++)
		{
			if (Main.combatText[i].active != 0)
			{
				Vector2 textSize = Main.combatText[i].textSize;
				textSize.X *= 0.5f;
				textSize.Y *= 0.5f;
				int num = (Main.combatText[i].crit ? 1 : 0);
				float scale = Main.combatText[i].scale;
				float num2 = Main.combatText[i].alpha * scale;
				Color c = new Color(num2, num2, num2, num2);
				Vector2 position = Main.combatText[i].position;
				position.X += textSize.X;
				position.X -= screenPosition.X;
				position.Y += textSize.Y;
				position.Y -= screenPosition.Y;
				UI.DrawString(UI.fontCombatText[num], Main.combatText[i].text, position, c, Main.combatText[i].rotation, textSize, scale);
			}
		}
	}

	private void DrawItemText()
	{
		for (int i = 0; i < 4; i++)
		{
			if (itemTextLocal.itemText[i].active != 0)
			{
				Vector2 textSize = itemTextLocal.itemText[i].textSize;
				textSize.X *= 0.5f;
				textSize.Y *= 0.5f;
				float num = (int)itemTextLocal.itemText[i].color.R;
				float num2 = (int)itemTextLocal.itemText[i].color.G;
				float num3 = (int)itemTextLocal.itemText[i].color.B;
				float num4 = (int)itemTextLocal.itemText[i].color.A;
				float scale = itemTextLocal.itemText[i].scale;
				_ = itemTextLocal.itemText[i].alpha;
				num *= scale;
				num3 *= scale;
				num2 *= scale;
				num4 *= scale;
				Vector2 position = itemTextLocal.itemText[i].position;
				position.X += textSize.X;
				position.X -= screenPosition.X;
				position.Y += textSize.Y;
				position.Y -= screenPosition.Y;
				UI.DrawStringScaled(UI.fontSmallOutline, itemTextLocal.itemText[i].text, position, new Color((int)num, (int)num2, (int)num3, (int)num4), textSize, scale);
			}
		}
	}

	private void DrawProjectiles()
	{
		for (int num = 511; num >= 0; num--)
		{
			if (Main.projectile[num].active != 0 && Main.projectile[num].type > 0 && !Main.projectile[num].hide)
			{
				Main.projectile[num].Draw(this);
			}
		}
	}

	private void DrawPlayers()
	{
		for (int i = 0; i < 8; i++)
		{
			Player player = Main.player[i];
			if (player.active == 0)
			{
				continue;
			}
			if (player.ghost)
			{
				Vector2 position = player.position;
				player.position = player.shadowPos[0];
				player.shadow = 0.5f;
				player.DrawGhost(this);
				player.position = player.shadowPos[1];
				player.shadow = 0.7f;
				player.DrawGhost(this);
				player.position = player.shadowPos[2];
				player.shadow = 0.9f;
				player.DrawGhost(this);
				player.position = position;
				player.shadow = 0f;
				player.DrawGhost(this);
				continue;
			}
			bool flag = false;
			bool flag2 = false;
			if (player.legs == 25)
			{
				flag = true;
			}
			else if (player.head == 5 && player.body == 5 && player.legs == 5)
			{
				flag = true;
			}
			else if (player.head == 7 && player.body == 7 && player.legs == 7)
			{
				flag = true;
			}
			else if (player.head == 22 && player.body == 14 && player.legs == 14)
			{
				flag = true;
			}
			else if (player.body == 17 && player.legs == 16 && (player.head == 29 || player.head == 30 || player.head == 31))
			{
				flag = true;
			}
			if (player.legs == 26)
			{
				flag2 = true;
			}
			else if (player.body == 19 && player.legs == 18)
			{
				if (player.head == 35 || player.head == 36 || player.head == 37)
				{
					flag2 = true;
				}
			}
			else if (player.body == 24 && player.legs == 23 && (player.head == 41 || player.head == 42 || player.head == 43))
			{
				flag2 = true;
				flag = true;
			}
			if (flag2)
			{
				Vector2 position2 = player.position;
				player.ghostFade += player.ghostDir * 0.075f;
				if (player.ghostFade < 0.1f)
				{
					player.ghostDir = 1f;
					player.ghostFade = 0.1f;
				}
				if (player.ghostFade > 0.9f)
				{
					player.ghostDir = -1f;
					player.ghostFade = 0.9f;
				}
				player.position.X = position2.X - player.ghostFade * 5f;
				player.shadow = player.ghostFade;
				player.Draw(this);
				player.position.X = position2.X + player.ghostFade * 5f;
				player.shadow = player.ghostFade;
				player.Draw(this);
				player.position = position2;
				player.position.Y = position2.Y - player.ghostFade * 5f;
				player.shadow = player.ghostFade;
				player.Draw(this);
				player.position.Y = position2.Y + player.ghostFade * 5f;
				player.shadow = player.ghostFade;
				player.Draw(this);
				player.position = position2;
				player.shadow = 0f;
			}
			if (flag)
			{
				Vector2 position3 = player.position;
				player.position = player.shadowPos[0];
				player.shadow = 0.5f;
				player.Draw(this);
				player.position = player.shadowPos[1];
				player.shadow = 0.7f;
				player.Draw(this);
				player.position = player.shadowPos[2];
				player.shadow = 0.9f;
				player.Draw(this);
				player.position = position3;
				player.shadow = 0f;
			}
			player.Draw(this);
		}
	}

	private unsafe void DrawItems()
	{
		Rectangle rectangle = default(Rectangle);
		Vector2 pos = default(Vector2);
		fixed (Item* ptr = Main.item)
		{
			Item* ptr2 = ptr;
			for (int num = 199; num >= 0; num--)
			{
				if (ptr2->active != 0)
				{
					int num2 = (int)ptr2->position.X;
					int num3 = (int)ptr2->position.Y;
					int num4 = 451 + ptr2->type;
					rectangle.Width = SpriteSheet<_sheetSprites>.src[num4].Width;
					rectangle.Height = SpriteSheet<_sheetSprites>.src[num4].Height;
					rectangle.X = num2 + (ptr2->width >> 1);
					rectangle.Y = num3 + (rectangle.Height >> 1) + ptr2->height - rectangle.Height + 2;
					if (rectangle.Intersects(viewArea))
					{
						int x = num2 + (ptr2->width >> 1) >> 4;
						int y = num3 + (ptr2->height >> 1) >> 4;
						Color colorUnsafe = lighting.GetColorUnsafe(x, y);
						if ((ptr2->CanBePlacedInCoinSlot() || ptr2->type == 58 || ptr2->type == 109) && Main.hasFocus && colorUnsafe.R > 60)
						{
							float num5 = (float)Main.rand.Next(500) - (Math.Abs(ptr2->velocity.X) + Math.Abs(ptr2->velocity.Y)) * 10f;
							if (num5 < (float)(int)colorUnsafe.R * 0.02f)
							{
								Dust* ptr3 = dustLocal.NewDust(num2, num3, ptr2->width, ptr2->height, 43, 0.0, 0.0, 254, default(Color), 0.5);
								if (ptr3 != null)
								{
									ptr3->velocity.X = 0f;
									ptr3->velocity.Y = 0f;
								}
							}
						}
						float rot = ptr2->velocity.X * 0.2f;
						float num6 = 1f;
						Color alpha = ptr2->GetAlpha(colorUnsafe);
						if (ptr2->type == 58 || ptr2->type == 184)
						{
							num6 = UI.essScale * 0.25f + 0.75f;
							alpha.R = (byte)((float)(int)alpha.R * num6);
							alpha.G = (byte)((float)(int)alpha.G * num6);
							alpha.B = (byte)((float)(int)alpha.B * num6);
							alpha.A = (byte)((float)(int)alpha.A * num6);
						}
						else if (ptr2->type == 520 || ptr2->type == 521 || ptr2->type == 547 || ptr2->type == 548 || ptr2->type == 549 || ptr2->type == 575 || ptr2->type == 620)
						{
							num6 = UI.essScale;
							alpha.R = (byte)((float)(int)alpha.R * num6);
							alpha.G = (byte)((float)(int)alpha.G * num6);
							alpha.B = (byte)((float)(int)alpha.B * num6);
							alpha.A = (byte)((float)(int)alpha.A * num6);
						}
						pos.X = rectangle.X - screenPosition.X;
						pos.Y = rectangle.Y - screenPosition.Y;
						SpriteSheet<_sheetSprites>.Draw(num4, ref pos, alpha, rot, num6);
						if (ptr2->color.PackedValue != 0)
						{
							SpriteSheet<_sheetSprites>.Draw(num4, ref pos, ptr2->GetColor(colorUnsafe), rot, num6);
						}
					}
				}
				ptr2++;
			}
		}
	}

	private unsafe void DrawBlack()
	{
		float num = (time.tileColorf.X + time.tileColorf.Y + time.tileColorf.Z) * (2f / 15f);
		Rectangle dest = default(Rectangle);
		dest.X = 32 + (firstTileX << 4) - screenPosition.X;
		dest.Width = 16;
		Color black = Color.Black;
		int num2 = lastTileY - 1;
		if (num2 > Main.worldSurface)
		{
			num2 = Main.worldSurface;
		}
		for (int i = firstTileX; i < lastTileX; i++)
		{
			int num3 = firstTileY;
			fixed (Tile* ptr = &Main.tile[i, num3])
			{
				Tile* ptr2 = ptr;
				while (true)
				{
					float num4 = lighting.BrightnessUnsafe(i, num3);
					if (num4 < num && (num4 == 0f || ptr2->liquid == 0 || (ptr2->active != 0 && Main.tileSolidNotSolidTop[ptr2->type])))
					{
						if (dest.Height == 0)
						{
							dest.Y = 32 + (num3 << 4) - screenPosition.Y;
						}
						dest.Height += 16;
					}
					else if (dest.Height > 0)
					{
						SpriteSheet<_sheetTiles>.DrawStretchedY(7, ref dest, black);
						dest.Height = 0;
					}
					if (++num3 > num2)
					{
						break;
					}
					ptr2++;
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
		Vector2 pos = default(Vector2);
		Color color = default(Color);
		Rectangle s = default(Rectangle);
		int num = firstTileX;
		fixed (Tile* ptr = Main.tile)
		{
			do
			{
				int num2 = firstTileY;
				Tile* ptr2 = ptr + (num * 1440 + num2);
				do
				{
					int wall = ptr2->wall;
					ptr2->flags |= Tile.Flags.VISITED;
					if (wall > 0 && !ptr2->isFullTile())
					{
						color = lighting.GetColorUnsafe(num, num2);
						int id = 186 + wall;
						s.X = ptr2->wallFrameX << 1;
						s.Y = ptr2->wallFrameY << 1;
						s.Width = 32;
						s.Height = 32;
						pos.X = num * 16 - screenPosition.X - 8 + 32;
						pos.Y = num2 * 16 - screenPosition.Y - 8 + 32;
						if (SMOOTH_LIGHT && wall != 21 && !WorldGen.SolidTile(num, num2))
						{
							if (color.R > 216 || (double)(int)color.G > 237.60000000000002 || (double)(int)color.B > 259.2)
							{
								s.Width = 12;
								s.Height = 12;
								Color colorUnsafe = lighting.GetColorUnsafe(num - 1, num2 - 1);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.X += 12f;
								s.X += 12;
								s.Width = 8;
								colorUnsafe = lighting.GetColorUnsafe(num, num2 - 1);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.X += 8f;
								s.X += 8;
								s.Width = 12;
								colorUnsafe = lighting.GetColorUnsafe(num + 1, num2 - 1);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.Y += 12f;
								s.Y += 12;
								s.Height = 8;
								colorUnsafe = lighting.GetColorUnsafe(num + 1, num2);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.X -= 8f;
								s.X -= 8;
								s.Width = 8;
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.X -= 12f;
								s.X -= 12;
								s.Width = 12;
								colorUnsafe = lighting.GetColorUnsafe(num - 1, num2);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.Y += 8f;
								s.Y += 8;
								s.Height = 12;
								colorUnsafe = lighting.GetColorUnsafe(num - 1, num2 + 1);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.X += 12f;
								s.X += 12;
								s.Width = 8;
								colorUnsafe = lighting.GetColorUnsafe(num, num2 + 1);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
								pos.X += 8f;
								s.X += 8;
								s.Width = 12;
								colorUnsafe = lighting.GetColorUnsafe(num + 1, num2 + 1);
								colorUnsafe.R = (byte)(color.R + colorUnsafe.R >> 1);
								colorUnsafe.G = (byte)(color.G + colorUnsafe.G >> 1);
								colorUnsafe.B = (byte)(color.B + colorUnsafe.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, colorUnsafe);
							}
							else if (color.R > 100 || (double)(int)color.G > 110.00000000000001 || (double)(int)color.B > 120.0)
							{
								s.Width = 16;
								s.Height = 16;
								Color c = (lighting.Brighter(num, num2 - 1, num - 1, num2) ? lighting.GetColorUnsafe(num - 1, num2) : lighting.GetColorUnsafe(num, num2 - 1));
								c.R = (byte)(color.R + c.R >> 1);
								c.G = (byte)(color.G + c.G >> 1);
								c.B = (byte)(color.B + c.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
								s.X += 16;
								pos.X += 16f;
								c = (lighting.Brighter(num, num2 - 1, num + 1, num2) ? lighting.GetColorUnsafe(num + 1, num2) : lighting.GetColorUnsafe(num, num2 - 1));
								c.R = (byte)(color.R + c.R >> 1);
								c.G = (byte)(color.G + c.G >> 1);
								c.B = (byte)(color.B + c.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
								s.Y += 16;
								pos.Y += 16f;
								c = (lighting.Brighter(num, num2 + 1, num + 1, num2) ? lighting.GetColorUnsafe(num + 1, num2) : lighting.GetColorUnsafe(num, num2 + 1));
								c.R = (byte)(color.R + c.R >> 1);
								c.G = (byte)(color.G + c.G >> 1);
								c.B = (byte)(color.B + c.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
								s.X -= 16;
								pos.X -= 16f;
								c = (lighting.Brighter(num, num2 + 1, num - 1, num2) ? lighting.GetColorUnsafe(num - 1, num2) : lighting.GetColorUnsafe(num, num2 + 1));
								c.R = (byte)(color.R + c.R >> 1);
								c.G = (byte)(color.G + c.G >> 1);
								c.B = (byte)(color.B + c.B >> 1);
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, c);
							}
							else
							{
								SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, color);
							}
						}
						else
						{
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, color);
						}
					}
					ptr2++;
				}
				while (++num2 < lastTileY);
			}
			while (++num < lastTileX);
		}
	}

	private unsafe void DrawWires()
	{
		Rectangle s = default(Rectangle);
		s.Width = 16;
		s.Height = 16;
		Vector2 pos = default(Vector2);
		fixed (Tile* ptr = Main.tile)
		{
			for (int i = firstTileX; i < lastTileX; i++)
			{
				pos.X = 32 + i * 16 - screenPosition.X;
				Tile* ptr2 = ptr + (i * 1440 + firstTileY);
				int num = firstTileY;
				while (num < lastTileY)
				{
					if (ptr2->wire != 0)
					{
						pos.Y = 32 + num * 16 - screenPosition.Y;
						if (lighting.IsNotBlackUnsafe(i, num))
						{
							ptr2--;
							int wire = ptr2->wire;
							ptr2 += 2;
							int wire2 = ptr2->wire;
							ptr2 -= 1441;
							int wire3 = ptr2->wire;
							ptr2 += 2880;
							int wire4 = ptr2->wire;
							ptr2 -= 1440;
							if (wire != 0)
							{
								if (wire2 != 0)
								{
									if (wire3 != 0)
									{
										if (wire4 != 0)
										{
											s.X = 18;
											s.Y = 18;
										}
										else
										{
											s.X = 54;
											s.Y = 0;
										}
									}
									else if (wire4 != 0)
									{
										s.X = 36;
										s.Y = 0;
									}
									else
									{
										s.X = 0;
										s.Y = 0;
									}
								}
								else if (wire3 != 0)
								{
									if (wire4 != 0)
									{
										s.X = 0;
										s.Y = 18;
									}
									else
									{
										s.X = 54;
										s.Y = 18;
									}
								}
								else if (wire4 != 0)
								{
									s.X = 36;
									s.Y = 18;
								}
								else
								{
									s.X = 36;
									s.Y = 36;
								}
							}
							else if (wire2 != 0)
							{
								if (wire3 != 0)
								{
									if (wire4 != 0)
									{
										s.X = 72;
										s.Y = 0;
									}
									else
									{
										s.X = 72;
										s.Y = 18;
									}
								}
								else if (wire4 != 0)
								{
									s.X = 0;
									s.Y = 36;
								}
								else
								{
									s.X = 18;
									s.Y = 36;
								}
							}
							else if (wire3 != 0)
							{
								if (wire4 != 0)
								{
									s.X = 18;
									s.Y = 0;
								}
								else
								{
									s.X = 54;
									s.Y = 36;
								}
							}
							else if (wire4 != 0)
							{
								s.X = 72;
								s.Y = 36;
							}
							else
							{
								s.X = 0;
								s.Y = 54;
							}
							Color colorUnsafe = lighting.GetColorUnsafe(i, num);
							if (SMOOTH_LIGHT && (colorUnsafe.R > 38 || (double)(int)colorUnsafe.G > 41.800000000000004 || (double)(int)colorUnsafe.B > 45.6))
							{
								for (int j = 0; j < 4; j++)
								{
									int num2 = 0;
									int num3 = 0;
									Color c = colorUnsafe;
									Color color = colorUnsafe;
									switch (j)
									{
									case 0:
										color = ((!lighting.Brighter(i, num - 1, i - 1, num)) ? lighting.GetColorUnsafe(i, num - 1) : lighting.GetColorUnsafe(i - 1, num));
										break;
									case 1:
										color = ((!lighting.Brighter(i, num - 1, i + 1, num)) ? lighting.GetColorUnsafe(i, num - 1) : lighting.GetColorUnsafe(i + 1, num));
										num2 = 8;
										break;
									case 2:
										color = ((!lighting.Brighter(i, num + 1, i - 1, num)) ? lighting.GetColorUnsafe(i, num + 1) : lighting.GetColorUnsafe(i - 1, num));
										num3 = 8;
										break;
									default:
										color = ((!lighting.Brighter(i, num + 1, i + 1, num)) ? lighting.GetColorUnsafe(i, num + 1) : lighting.GetColorUnsafe(i + 1, num));
										num2 = 8;
										num3 = 8;
										break;
									}
									c.R = (byte)(colorUnsafe.R + color.R >> 1);
									c.G = (byte)(colorUnsafe.G + color.G >> 1);
									c.B = (byte)(colorUnsafe.B + color.B >> 1);
									Rectangle s2 = s;
									s2.X += num2;
									s2.Y += num3;
									s2.Width = 8;
									s2.Height = 8;
									pos.X += num2;
									pos.Y += num3;
									SpriteSheet<_sheetTiles>.Draw(218, ref pos, ref s2, c);
									pos.X -= num2;
									pos.Y -= num3;
								}
							}
							else
							{
								SpriteSheet<_sheetTiles>.Draw(218, ref pos, ref s, colorUnsafe);
							}
						}
					}
					num++;
					ptr2++;
				}
			}
		}
	}

	public unsafe void DrawBg(UI ui)
	{
		if (viewportAnimTheta > 0.0 && !Guide.IsVisible)
		{
			viewportAnimTheta -= Math.PI / 60.0;
			if (viewportAnimTheta <= 0.0)
			{
				SAFE_AREA_OFFSET_L = targetSAFE_AREA_OFFSET_L;
				SAFE_AREA_OFFSET_T = targetSAFE_AREA_OFFSET_T;
				SAFE_AREA_OFFSET_R = targetSAFE_AREA_OFFSET_R;
				SAFE_AREA_OFFSET_B = targetSAFE_AREA_OFFSET_B;
				activeViewport = targetViewport;
			}
			else
			{
				double num = 1.0 - Math.Sin(viewportAnimTheta);
				SAFE_AREA_OFFSET_L = currentSAFE_AREA_OFFSET_L + (int)(num * (double)(targetSAFE_AREA_OFFSET_L - currentSAFE_AREA_OFFSET_L));
				SAFE_AREA_OFFSET_T = currentSAFE_AREA_OFFSET_T + (int)(num * (double)(targetSAFE_AREA_OFFSET_T - currentSAFE_AREA_OFFSET_T));
				SAFE_AREA_OFFSET_R = currentSAFE_AREA_OFFSET_R + (int)(num * (double)(targetSAFE_AREA_OFFSET_R - currentSAFE_AREA_OFFSET_R));
				SAFE_AREA_OFFSET_B = currentSAFE_AREA_OFFSET_B + (int)(num * (double)(targetSAFE_AREA_OFFSET_B - currentSAFE_AREA_OFFSET_B));
				activeViewport.X = currentViewport.X + (int)(num * (double)(targetViewport.X - currentViewport.X));
				activeViewport.Y = currentViewport.Y + (int)(num * (double)(targetViewport.Y - currentViewport.Y));
			}
		}
		graphicsDevice.Viewport = activeViewport;
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, screenProjection);
		int num2;
		if (ui.menuType == MenuType.MAIN)
		{
			num2 = -200;
			atmo = 1f;
			time = Main.menuTime;
			if (!time.dayTime)
			{
				time.intermediateBgColor.R = 35;
				time.intermediateBgColor.G = 35;
				time.intermediateBgColor.B = 35;
			}
			bgDelay = 1000;
			if (bgAlpha[1] > 0f)
			{
				time.applyEvil(bgAlpha[1]);
			}
			else
			{
				time.applyNothing();
			}
			time.finalizeColors();
			screenLastPosition = screenPosition;
			screenPosition.X += 2;
			screenPosition.Y = Main.worldSurfacePixels - 540 - 1;
		}
		else
		{
			num2 = (int)((float)screenPosition.Y / (float)(Main.worldSurfacePixels - 540) * -260f);
			time = Main.gameTime;
			if (jungleTiles > 0)
			{
				time.applyJungle((float)jungleTiles * 0.005f);
			}
			else if (evilTiles > 0)
			{
				time.applyEvil((float)evilTiles * 0.002f);
			}
			else
			{
				time.applyNothing();
			}
			time.finalizeColors();
			float num3 = (float)Main.maxTilesY / 1200f;
			num3 *= num3;
			atmo = ((float)(screenPosition.Y + 270 >> 4) - (65f + 10f * num3)) / ((float)Main.worldSurface * 0.2f);
			if (atmo >= 1f)
			{
				atmo = 1f;
			}
			else
			{
				if (atmo < 0f)
				{
					atmo = 0f;
				}
				time.bgColor.R = (byte)((float)(int)time.bgColor.R * atmo);
				time.bgColor.G = (byte)((float)(int)time.bgColor.G * atmo);
				time.bgColor.B = (byte)((float)(int)time.bgColor.B * atmo);
			}
		}
		Vector2 pos = default(Vector2);
		if (screenPosition.Y >= Main.worldSurfacePixels)
		{
			return;
		}
		Rectangle dest = default(Rectangle);
		dest.X = -1;
		dest.Y = num2;
		dest.Width = viewWidth;
		dest.Height = 1300 - num2;
		SpriteSheet<_sheetTiles>.DrawStretchedX(0, ref dest, time.bgColor);
		if (255 - time.bgColor.R - 100 > 0)
		{
			float num4 = (float)evilTiles * 0.002f;
			if (num4 > 1f)
			{
				num4 = 1f;
			}
			num4 = 1f - num4 * 0.5f;
			if (evilTiles <= 0)
			{
				num4 = 1f;
			}
			Color c = default(Color);
			Vector2 pos2 = default(Vector2);
			for (int i = 0; i < 96; i++)
			{
				fixed (Star* ptr = &Star.star[i])
				{
					float num5 = ptr->twinkle * num4;
					int num6 = (int)((float)(255 - time.bgColor.R - 100) * num5);
					int num7 = (int)((float)(255 - time.bgColor.G - 100) * num5);
					int num8 = (int)((float)(255 - time.bgColor.B - 100) * num5);
					if (num6 < 0)
					{
						num6 = 0;
					}
					if (num7 < 0)
					{
						num7 = 0;
					}
					if (num8 < 0)
					{
						num8 = 0;
					}
					c.R = (byte)num6;
					c.G = (byte)((float)num7 * num4);
					c.B = (byte)((float)num8 * num4);
					pos2.X = ptr->position.X;
					if (viewWidth > 960)
					{
						pos2.X = (pos2.X - 960f) * 2f + 1920f;
					}
					pos2.Y = ptr->position.Y + (float)num2;
					SpriteSheet<_sheetTiles>.Draw(19 + ptr->type, ref pos2, c, ptr->rotation, ptr->scale * ptr->twinkle);
				}
			}
		}
		int num9 = time.celestialX;
		if (viewWidth > 960)
		{
			num9 = (num9 - 960 << 1) + 1920;
		}
		if (time.dayTime)
		{
			int id = ((ui.menuType == MenuType.MAIN || ui.player.head != 12) ? 25 : 24);
			SpriteSheet<_sheetTiles>.Draw(id, num9, time.celestialY + num2, time.celestialColor, time.celestialRotation, time.celestialScale);
		}
		else
		{
			SpriteSheet<_sheetTiles>.Draw(16, num9, time.celestialY + num2, 50 * time.moonPhase, 50, time.celestialColor, time.celestialRotation, time.celestialScale);
		}
		num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1200f) + 1190;
		float num10 = num2 - 50;
		for (int j = 0; j < 20; j++)
		{
			if (!Cloud.cloud[j].active || !(Cloud.cloud[j].scale < 1f))
			{
				continue;
			}
			pos.Y = num10 + Cloud.cloud[j].position.Y;
			if (pos.Y < 540f && pos.Y > (float)(-Cloud.cloud[j].height))
			{
				pos.X = Cloud.cloud[j].position.X;
				if (viewWidth > 960)
				{
					pos.X = (pos.X - 960f) * 2f + 1920f;
				}
				Color c2 = Cloud.cloud[j].cloudColor(time.bgColor);
				if (atmo < 1f)
				{
					c2.R = (byte)((float)(int)c2.R * atmo);
					c2.G = (byte)((float)(int)c2.G * atmo);
					c2.B = (byte)((float)(int)c2.B * atmo);
					c2.A = (byte)((float)(int)c2.A * atmo);
				}
				int id2 = 8 + Cloud.cloud[j].type;
				SpriteSheet<_sheetTiles>.DrawScaledTL(id2, ref pos, c2, Cloud.cloud[j].scale);
			}
		}
		int num11 = (int)((float)backgroundTexture[7].Width * 2f);
		num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1300f) + 1090;
		int num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.15f, num11) - (double)(num11 >> 1));
		int num13 = viewWidth / num11 + 2;
		if (ui.menuType == MenuType.MAIN)
		{
			num2 = 100;
		}
		Color bgColor = time.bgColor;
		bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha2[0]);
		bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha2[0]);
		bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha2[0]);
		bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha2[0]);
		if (bgAlpha2[0] > 0f)
		{
			for (int k = 0; k < num13; k++)
			{
				Main.spriteBatch.Draw(backgroundTexture[7], new Vector2(num12 + num11 * k, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[7].Width, backgroundTexture[7].Height), bgColor, 0f, default(Vector2), 2f, SpriteEffects.None, 0f);
			}
		}
		bgColor = time.bgColor;
		bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha2[1]);
		bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha2[1]);
		bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha2[1]);
		bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha2[1]);
		if (bgAlpha2[1] > 0f)
		{
			for (int l = 0; l < num13; l++)
			{
				Main.spriteBatch.Draw(backgroundTexture[23], new Vector2(num12 + num11 * l, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[7].Width, backgroundTexture[7].Height), bgColor, 0f, default(Vector2), 2f, SpriteEffects.None, 0f);
			}
		}
		bgColor = time.bgColor;
		bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha2[2]);
		bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha2[2]);
		bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha2[2]);
		bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha2[2]);
		if (bgAlpha2[2] > 0f)
		{
			for (int m = 0; m < num13; m++)
			{
				Main.spriteBatch.Draw(backgroundTexture[24], new Vector2(num12 + num11 * m, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[7].Width, backgroundTexture[7].Height), bgColor, 0f, default(Vector2), 2f, SpriteEffects.None, 0f);
			}
		}
		num10 = num2 - 50;
		for (int n = 0; n < 20; n++)
		{
			if (!Cloud.cloud[n].active || !((double)Cloud.cloud[n].scale < 1.15) || !(Cloud.cloud[n].scale >= 1f))
			{
				continue;
			}
			pos.Y = num10 + Cloud.cloud[n].position.Y;
			if (pos.Y < 540f && pos.Y > (float)(-Cloud.cloud[n].height))
			{
				pos.X = Cloud.cloud[n].position.X;
				if (viewWidth > 960)
				{
					pos.X = (pos.X - 960f) * 2f + 1920f;
				}
				Color c3 = Cloud.cloud[n].cloudColor(time.bgColor);
				if (atmo < 1f)
				{
					c3.R = (byte)((float)(int)c3.R * atmo);
					c3.G = (byte)((float)(int)c3.G * atmo);
					c3.B = (byte)((float)(int)c3.B * atmo);
					c3.A = (byte)((float)(int)c3.A * atmo);
				}
				int id3 = 8 + Cloud.cloud[n].type;
				SpriteSheet<_sheetTiles>.DrawScaledTL(id3, ref pos, c3, Cloud.cloud[n].scale);
			}
		}
		if (holyTiles > 0)
		{
			num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.17f, 8085.0) - 4042.0);
			num13 = viewWidth / 8085 + 2;
			num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1400f) + 900;
			if (ui.menuType == MenuType.MAIN)
			{
				num2 = 230;
				num12 -= 500;
			}
			Color bgColor2 = time.bgColor;
			float num14 = (float)holyTiles * 0.0025f;
			if (num14 > 0.5f)
			{
				num14 = 0.5f;
			}
			bgColor2.R = (byte)((float)(int)bgColor2.R * num14);
			bgColor2.G = (byte)((float)(int)bgColor2.G * num14);
			bgColor2.B = (byte)((float)(int)bgColor2.B * num14);
			bgColor2.A = (byte)((float)(int)bgColor2.A * num14 * 0.8f);
			for (int num15 = 0; num15 < num13; num15++)
			{
				Main.spriteBatch.Draw(backgroundTexture[18], new Vector2(num12 + 8085 * num15, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[18].Width, backgroundTexture[18].Height), bgColor2, 0f, default(Vector2), 2.2f, SpriteEffects.None, 0f);
			}
			for (int num16 = 0; num16 < num13; num16++)
			{
				Main.spriteBatch.Draw(backgroundTexture[19], new Vector2(num12 + 8085 * num16 + 1700, num2 + 100), (Rectangle?)new Rectangle(0, 0, backgroundTexture[19].Width, backgroundTexture[19].Height), bgColor2, 0f, default(Vector2), 1.98f, SpriteEffects.None, 0f);
			}
		}
		int num17 = (int)((float)backgroundTexture[7].Width * 2.3f);
		num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.2f, num17) - (double)(num17 >> 1));
		num13 = viewWidth / num17 + 2;
		num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1400f) + 1260;
		if (ui.menuType == MenuType.MAIN)
		{
			num2 = 230;
			num12 -= 500;
		}
		bgColor = time.bgColor;
		bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha2[0]);
		bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha2[0]);
		bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha2[0]);
		bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha2[0]);
		if (bgAlpha2[0] > 0f)
		{
			for (int num18 = 0; num18 < num13; num18++)
			{
				Main.spriteBatch.Draw(backgroundTexture[8], new Vector2(num12 + num17 * num18, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[7].Width, backgroundTexture[7].Height), bgColor, 0f, default(Vector2), 2.3f, SpriteEffects.None, 0f);
			}
		}
		bgColor = time.bgColor;
		bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha2[1]);
		bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha2[1]);
		bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha2[1]);
		bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha2[1]);
		if (bgAlpha2[1] > 0f)
		{
			for (int num19 = 0; num19 < num13; num19++)
			{
				Main.spriteBatch.Draw(backgroundTexture[22], new Vector2(num12 + num17 * num19, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[7].Width, backgroundTexture[7].Height), bgColor, 0f, default(Vector2), 2.3f, SpriteEffects.None, 0f);
			}
		}
		bgColor = time.bgColor;
		bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha2[2]);
		bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha2[2]);
		bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha2[2]);
		bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha2[2]);
		if (bgAlpha2[2] > 0f)
		{
			for (int num20 = 0; num20 < num13; num20++)
			{
				Main.spriteBatch.Draw(backgroundTexture[25], new Vector2(num12 + num17 * num20, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[7].Width, backgroundTexture[7].Height), bgColor, 0f, default(Vector2), 2.3f, SpriteEffects.None, 0f);
			}
		}
		bgColor = time.bgColor;
		bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha2[3]);
		bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha2[3]);
		bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha2[3]);
		bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha2[3]);
		if (bgAlpha2[3] > 0f)
		{
			for (int num21 = 0; num21 < num13; num21++)
			{
				Main.spriteBatch.Draw(backgroundTexture[28], new Vector2(num12 + num17 * num21, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[7].Width, backgroundTexture[7].Height), bgColor, 0f, default(Vector2), 2.3f, SpriteEffects.None, 0f);
			}
		}
		num10 = (float)num2 * 1.01f - 150f;
		for (int num22 = 0; num22 < 20; num22++)
		{
			if (!Cloud.cloud[num22].active || !(Cloud.cloud[num22].scale > 2.3f))
			{
				continue;
			}
			pos.Y = num10 + Cloud.cloud[num22].position.Y;
			if (pos.Y < 540f && pos.Y > (float)(-Cloud.cloud[num22].height))
			{
				pos.X = Cloud.cloud[num22].position.X;
				if (viewWidth > 960)
				{
					pos.X = (pos.X - 960f) * 2f + 1920f;
				}
				Color c4 = Cloud.cloud[num22].cloudColor(time.bgColor);
				if (atmo < 1f)
				{
					c4.R = (byte)((float)(int)c4.R * atmo);
					c4.G = (byte)((float)(int)c4.G * atmo);
					c4.B = (byte)((float)(int)c4.B * atmo);
					c4.A = (byte)((float)(int)c4.A * atmo);
				}
				int id4 = 8 + Cloud.cloud[num22].type;
				SpriteSheet<_sheetTiles>.DrawScaledTL(id4, ref pos, c4, Cloud.cloud[num22].scale);
			}
		}
		int num23 = bgStyle;
		if (ui.menuType != 0)
		{
			int num24 = screenPosition.X + (viewWidth >> 1) >> 4;
			if (num24 < 380 || num24 > Main.maxTilesX - 380)
			{
				num23 = 4;
			}
			else if (inactiveTiles < ((viewWidth == 960) ? 8000 : 16000))
			{
				num23 = ((sandTiles > 1000) ? ((!player.zoneEvil && !player.zoneHoly) ? 2 : 5) : (player.zoneHoly ? 6 : (player.zoneEvil ? 1 : (player.zoneJungle ? 3 : 0))));
			}
		}
		float num25 = 0.05f;
		int num26 = 30;
		if (num23 == 0)
		{
			num26 = 120;
		}
		if (bgDelay < 0)
		{
			bgDelay++;
		}
		else
		{
			if (ui.menuType == MenuType.MAIN)
			{
				num25 = 0.02f;
				if (!time.dayTime)
				{
					if (ui.menuMode == MenuMode.CREDITS)
					{
						holyTiles = 200;
						bgStyle = 6;
					}
					else
					{
						holyTiles = 0;
						bgStyle = 1;
					}
				}
				else if (ui.menuMode == MenuMode.CREDITS)
				{
					holyTiles = 200;
					bgStyle = 3;
				}
				else
				{
					holyTiles = 0;
					bgStyle = 0;
				}
				num23 = bgStyle;
			}
			if (num23 != bgStyle)
			{
				bgDelay++;
				if (bgDelay > num26)
				{
					bgDelay = -60;
					bgStyle = num23;
					if (num23 == 0)
					{
						bgDelay = 0;
					}
				}
			}
			else if (bgDelay > 0)
			{
				bgDelay--;
			}
		}
		if (quickBG > 0)
		{
			quickBG--;
			bgStyle = num23;
			num25 = 1f;
		}
		if (bgStyle == 2)
		{
			bgAlpha2[0] -= num25;
			if (bgAlpha2[0] < 0f)
			{
				bgAlpha2[0] = 0f;
			}
			bgAlpha2[1] += num25;
			if (bgAlpha2[1] > 1f)
			{
				bgAlpha2[1] = 1f;
			}
			bgAlpha2[2] -= num25;
			if (bgAlpha2[2] < 0f)
			{
				bgAlpha2[2] = 0f;
			}
			bgAlpha2[3] -= num25;
			if (bgAlpha2[3] < 0f)
			{
				bgAlpha2[3] = 0f;
			}
		}
		else if (bgStyle == 5 || bgStyle == 1 || bgStyle == 6)
		{
			bgAlpha2[0] -= num25;
			if (bgAlpha2[0] < 0f)
			{
				bgAlpha2[0] = 0f;
			}
			bgAlpha2[1] -= num25;
			if (bgAlpha2[1] < 0f)
			{
				bgAlpha2[1] = 0f;
			}
			bgAlpha2[2] += num25;
			if (bgAlpha2[2] > 1f)
			{
				bgAlpha2[2] = 1f;
			}
			bgAlpha2[3] -= num25;
			if (bgAlpha2[3] < 0f)
			{
				bgAlpha2[3] = 0f;
			}
		}
		else if (bgStyle == 4)
		{
			bgAlpha2[0] -= num25;
			if (bgAlpha2[0] < 0f)
			{
				bgAlpha2[0] = 0f;
			}
			bgAlpha2[1] -= num25;
			if (bgAlpha2[1] < 0f)
			{
				bgAlpha2[1] = 0f;
			}
			bgAlpha2[2] -= num25;
			if (bgAlpha2[2] < 0f)
			{
				bgAlpha2[2] = 0f;
			}
			bgAlpha2[3] += num25;
			if (bgAlpha2[3] > 1f)
			{
				bgAlpha2[3] = 1f;
			}
		}
		else
		{
			bgAlpha2[0] += num25;
			if (bgAlpha2[0] > 1f)
			{
				bgAlpha2[0] = 1f;
			}
			bgAlpha2[1] -= num25;
			if (bgAlpha2[1] < 0f)
			{
				bgAlpha2[1] = 0f;
			}
			bgAlpha2[2] -= num25;
			if (bgAlpha2[2] < 0f)
			{
				bgAlpha2[2] = 0f;
			}
			bgAlpha2[3] -= num25;
			if (bgAlpha2[3] < 0f)
			{
				bgAlpha2[3] = 0f;
			}
		}
		for (int num27 = 0; num27 < 7; num27++)
		{
			if (bgStyle == num27)
			{
				bgAlpha[num27] += num25;
				if (bgAlpha[num27] > 1f)
				{
					bgAlpha[num27] = 1f;
				}
			}
			else
			{
				bgAlpha[num27] -= num25;
				if (bgAlpha[num27] < 0f)
				{
					bgAlpha[num27] = 0f;
				}
			}
			bgColor = time.bgColor;
			bgColor.R = (byte)((float)(int)bgColor.R * bgAlpha[num27]);
			bgColor.G = (byte)((float)(int)bgColor.G * bgAlpha[num27]);
			bgColor.B = (byte)((float)(int)bgColor.B * bgAlpha[num27]);
			bgColor.A = (byte)((float)(int)bgColor.A * bgAlpha[num27]);
			if (num27 == 3 && bgAlpha[num27] > 0f)
			{
				int num28 = (int)((float)backgroundTexture[8].Width * 2.5f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.4f, num28) - (double)(num28 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1800f) + 1660;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 320;
				}
				num13 = viewWidth / num28 + 2;
				for (int num29 = 0; num29 < num13; num29++)
				{
					Main.spriteBatch.Draw(backgroundTexture[15], new Vector2(num12 + num28 * num29, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[8].Width, backgroundTexture[8].Height), bgColor, 0f, default(Vector2), 2.5f, SpriteEffects.None, 0f);
				}
				int num30 = (int)((float)backgroundTexture[8].Width * 2.62f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.43f, num30) - (double)(num30 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1950f) + 1840;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 400;
					num12 -= 80;
				}
				num13 = viewWidth / num30 + 2;
				for (int num31 = 0; num31 < num13; num31++)
				{
					Main.spriteBatch.Draw(backgroundTexture[16], new Vector2(num12 + num30 * num31, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[8].Width, backgroundTexture[8].Height), bgColor, 0f, default(Vector2), 2.62f, SpriteEffects.None, 0f);
				}
				int num32 = (int)((float)backgroundTexture[8].Width * 2.68f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.49f, num32) - (double)(num32 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 2100f) + 2060;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 480;
					num12 -= 120;
				}
				num13 = viewWidth / num32 + 2;
				for (int num33 = 0; num33 < num13; num33++)
				{
					Main.spriteBatch.Draw(backgroundTexture[17], new Vector2(num12 + num32 * num33, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[8].Width, backgroundTexture[8].Height), bgColor, 0f, default(Vector2), 2.68f, SpriteEffects.None, 0f);
				}
			}
			else if (num27 == 2 && bgAlpha[num27] > 0f)
			{
				int num34 = (int)((float)backgroundTexture[21].Width * 2.5f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.37f, num34) - (double)(num34 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1800f) + 1750;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 320;
				}
				num13 = viewWidth / num34 + 2;
				for (int num35 = 0; num35 < num13; num35++)
				{
					Main.spriteBatch.Draw(backgroundTexture[21], new Vector2(num12 + num34 * num35, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[21].Width, backgroundTexture[21].Height), bgColor, 0f, default(Vector2), 2.5f, SpriteEffects.None, 0f);
				}
				int num36 = (int)((float)backgroundTexture[20].Width * 2.68f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.49f, num36) - (double)(num36 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 2100f) + 2150;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 480;
					num12 -= 120;
				}
				num13 = viewWidth / num36 + 2;
				for (int num37 = 0; num37 < num13; num37++)
				{
					Main.spriteBatch.Draw(backgroundTexture[20], new Vector2(num12 + num36 * num37, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[20].Width, backgroundTexture[20].Height), bgColor, 0f, default(Vector2), 2.68f, SpriteEffects.None, 0f);
				}
			}
			else if (num27 == 5 && bgAlpha[num27] > 0f)
			{
				int num38 = (int)((float)backgroundTexture[8].Width * 2.5f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.37f, num38) - (double)(num38 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1800f) + 1750;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 320;
				}
				num13 = viewWidth / num38 + 2;
				for (int num39 = 0; num39 < num13; num39++)
				{
					Main.spriteBatch.Draw(backgroundTexture[26], new Vector2(num12 + num38 * num39, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[26].Width, backgroundTexture[26].Height), bgColor, 0f, default(Vector2), 2.5f, SpriteEffects.None, 0f);
				}
				int num40 = (int)((float)backgroundTexture[8].Width * 2.68f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.49f, num40) - (double)(num40 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 2100f) + 2150;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 480;
					num12 -= 120;
				}
				num13 = viewWidth / num40 + 2;
				for (int num41 = 0; num41 < num13; num41++)
				{
					Main.spriteBatch.Draw(backgroundTexture[27], new Vector2(num12 + num40 * num41, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[27].Width, backgroundTexture[27].Height), bgColor, 0f, default(Vector2), 2.68f, SpriteEffects.None, 0f);
				}
			}
			else if (num27 == 1 && bgAlpha[num27] > 0f)
			{
				int num42 = (int)((float)backgroundTexture[8].Width * 2.5f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.4f, num42) - (double)(num42 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1800f) + 1500;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 320;
				}
				num13 = viewWidth / num42 + 2;
				for (int num43 = 0; num43 < num13; num43++)
				{
					Main.spriteBatch.Draw(backgroundTexture[12], new Vector2(num12 + num42 * num43, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[12].Width, backgroundTexture[12].Height), bgColor, 0f, default(Vector2), 2.5f, SpriteEffects.None, 0f);
				}
				int num44 = (int)((float)backgroundTexture[8].Width * 2.62f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.43f, num44) - (double)(num44 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1950f) + 1750;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 400;
					num12 -= 80;
				}
				num13 = viewWidth / num44 + 2;
				for (int num45 = 0; num45 < num13; num45++)
				{
					Main.spriteBatch.Draw(backgroundTexture[13], new Vector2(num12 + num44 * num45, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[13].Width, backgroundTexture[13].Height), bgColor, 0f, default(Vector2), 2.62f, SpriteEffects.None, 0f);
				}
				int num46 = (int)((float)backgroundTexture[8].Width * 2.68f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.49f, num46) - (double)(num46 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 2100f) + 2000;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 480;
					num12 -= 120;
				}
				num13 = viewWidth / num46 + 2;
				for (int num47 = 0; num47 < num13; num47++)
				{
					Main.spriteBatch.Draw(backgroundTexture[14], new Vector2(num12 + num46 * num47, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[14].Width, backgroundTexture[14].Height), bgColor, 0f, default(Vector2), 2.68f, SpriteEffects.None, 0f);
				}
			}
			else if (num27 == 6 && bgAlpha[num27] > 0f)
			{
				int num48 = (int)((float)backgroundTexture[8].Width * 2.5f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.4f, num48) - (double)(num48 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1800f) + 1500;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 320;
				}
				num13 = viewWidth / num48 + 2;
				for (int num49 = 0; num49 < num13; num49++)
				{
					Main.spriteBatch.Draw(backgroundTexture[29], new Vector2(num12 + num48 * num49, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[29].Width, backgroundTexture[29].Height), bgColor, 0f, default(Vector2), 2.5f, SpriteEffects.None, 0f);
				}
				int num50 = (int)((float)backgroundTexture[8].Width * 2.62f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.43f, num50) - (double)(num50 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1950f) + 1750;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 400;
					num12 -= 80;
				}
				num13 = viewWidth / num50 + 2;
				for (int num51 = 0; num51 < num13; num51++)
				{
					Main.spriteBatch.Draw(backgroundTexture[30], new Vector2(num12 + num50 * num51, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[30].Width, backgroundTexture[30].Height), bgColor, 0f, default(Vector2), 2.62f, SpriteEffects.None, 0f);
				}
				int num52 = (int)((float)backgroundTexture[8].Width * 2.68f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.49f, num52) - (double)(num52 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 2100f) + 2000;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 480;
					num12 -= 120;
				}
				num13 = viewWidth / num52 + 2;
				for (int num53 = 0; num53 < num13; num53++)
				{
					Main.spriteBatch.Draw(backgroundTexture[31], new Vector2(num12 + num52 * num53, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[31].Width, backgroundTexture[31].Height), bgColor, 0f, default(Vector2), 2.68f, SpriteEffects.None, 0f);
				}
			}
			else if (num27 == 0 && bgAlpha[num27] > 0f)
			{
				int num54 = (int)((float)backgroundTexture[8].Width * 2.5f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.4f, num54) - (double)(num54 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1800f) + 1500;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 320;
				}
				num13 = viewWidth / num54 + 2;
				for (int num55 = 0; num55 < num13; num55++)
				{
					Main.spriteBatch.Draw(backgroundTexture[9], new Vector2(num12 + num54 * num55, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[9].Width, backgroundTexture[9].Height), bgColor, 0f, default(Vector2), 2.5f, SpriteEffects.None, 0f);
				}
				int num56 = (int)((float)backgroundTexture[8].Width * 2.62f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.43f, num56) - (double)(num56 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 1950f) + 1750;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 400;
					num12 -= 80;
				}
				num13 = viewWidth / num56 + 2;
				for (int num57 = 0; num57 < num13; num57++)
				{
					Main.spriteBatch.Draw(backgroundTexture[10], new Vector2(num12 + num56 * num57, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[8].Width, backgroundTexture[8].Height), bgColor, 0f, default(Vector2), 2.62f, SpriteEffects.None, 0f);
				}
				int num58 = (int)((float)backgroundTexture[8].Width * 2.68f);
				num12 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.49f, num58) - (double)(num58 >> 1));
				num2 = (int)((float)(-screenPosition.Y) / (float)Main.worldSurfacePixels * 2100f) + 2000;
				if (ui.menuType == MenuType.MAIN)
				{
					num2 = 480;
					num12 -= 120;
				}
				num13 = viewWidth / num58 + 2;
				for (int num59 = 0; num59 < num13; num59++)
				{
					Main.spriteBatch.Draw(backgroundTexture[11], new Vector2(num12 + num58 * num59, num2), (Rectangle?)new Rectangle(0, 0, backgroundTexture[8].Width, backgroundTexture[8].Height), bgColor, 0f, default(Vector2), 2.68f, SpriteEffects.None, 0f);
				}
			}
		}
	}

	public void DrawWorld()
	{
		Color white = Color.White;
		Rectangle destinationRectangle = default(Rectangle);
		destinationRectangle.Width = viewWidth + 64;
		destinationRectangle.Height = 636;
		destinationRectangle.X = sceneWaterPos.X - screenPosition.X;
		destinationRectangle.Y = sceneWaterPos.Y - screenPosition.Y;
		Main.spriteBatch.Draw(backWaterTarget, destinationRectangle, white);
		destinationRectangle.X = (int)((float)(sceneBackgroundPos.X - screenPosition.X + 32) * 0.9f) - 32;
		destinationRectangle.Y = sceneBackgroundPos.Y - screenPosition.Y;
		Main.spriteBatch.Draw(backgroundTarget, destinationRectangle, white);
		if (firstTileY <= Main.worldSurface)
		{
			destinationRectangle.X = sceneBlackPos.X - screenPosition.X;
			destinationRectangle.Y = sceneBlackPos.Y - screenPosition.Y;
			Main.spriteBatch.Draw(blackTarget, destinationRectangle, white);
		}
		destinationRectangle.X = sceneWallPos.X - screenPosition.X;
		destinationRectangle.Y = sceneWallPos.Y - screenPosition.Y;
		Main.spriteBatch.Draw(wallTarget, destinationRectangle, white);
		DrawWoF();
		destinationRectangle.X = sceneTile2Pos.X - screenPosition.X;
		destinationRectangle.Y = sceneTile2Pos.Y - screenPosition.Y;
		Main.spriteBatch.Draw(tileNonSolidTarget, destinationRectangle, white);
		destinationRectangle.X = sceneTilePos.X - screenPosition.X;
		destinationRectangle.Y = sceneTilePos.Y - screenPosition.Y;
		if (player.detectCreature)
		{
			Main.spriteBatch.Draw(tileSolidTarget, destinationRectangle, white);
			DrawGore();
			DrawNPCs(behindTiles: true);
			DrawNPCs();
		}
		else
		{
			DrawNPCs(behindTiles: true);
			Main.spriteBatch.Draw(tileSolidTarget, destinationRectangle, white);
			DrawGore();
			DrawNPCs();
		}
		DrawProjectiles();
		DrawPlayers();
		DrawItems();
		dustLocal.DrawDust(this);
		Main.dust.DrawDust(this);
		destinationRectangle.X = sceneWaterPos.X - screenPosition.X;
		destinationRectangle.Y = sceneWaterPos.Y - screenPosition.Y;
		Main.spriteBatch.Draw(waterTarget, destinationRectangle, white);
		DrawCombatText();
		DrawItemText();
	}

	private unsafe void DrawBackground()
	{
		float num = 0.9f;
		float num2 = 0.9f;
		float num3 = 0.9f;
		float num4 = 0f;
		if (holyTiles > evilTiles)
		{
			num4 = (float)holyTiles * 0.00125f;
		}
		else if (evilTiles > holyTiles)
		{
			num4 = (float)evilTiles * 0.00125f;
		}
		if (num4 > 1f)
		{
			num4 = 1f;
		}
		float num5 = (float)(screenPosition.Y - (Main.worldSurface << 4)) * 0.0033333334f;
		if (num5 < 0f)
		{
			num5 = 0f;
		}
		else if (num5 > 1f)
		{
			num5 = 1f;
		}
		float num6 = 1f - num5 + num * num5;
		lighting.brightness = lighting.defBrightness * (1f - num5) + 1f * num5;
		float num7 = (float)(screenPosition.Y - 270 + 200 - (Main.rockLayer << 4)) * 0.0033333334f;
		if (num7 < 0f)
		{
			num7 = 0f;
		}
		else if (num7 > 1f)
		{
			num7 = 1f;
		}
		if (evilTiles > 0)
		{
			num = 0.8f * num4 + num * (1f - num4);
			num2 = 0.75f * num4 + num2 * (1f - num4);
			num3 = 1.1f * num4 + num3 * (1f - num4);
		}
		else if (holyTiles > 0)
		{
			num = 1f * num4 + num * (1f - num4);
			num2 = 0.7f * num4 + num2 * (1f - num4);
			num3 = 0.9f * num4 + num3 * (1f - num4);
		}
		num = num6 - num7 + num * num7;
		num2 = num6 - num7 + num2 * num7;
		num3 = num6 - num7 + num3 * num7;
		lighting.defBrightness = 1.2f * (1f - num7) + num7;
		int num8 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.9f, 96.0) - 48.0);
		int num9 = viewWidth / 96 + 2;
		int num10 = Main.worldSurfacePixels - screenPosition.Y;
		int num11 = num8;
		int num12 = -((num8 + screenPosition.X + 8) & 0xF);
		if (num12 == -8)
		{
			num12 = 8;
		}
		Vector2 pos = new Vector2(num11 + num12 + 32, num10 + 32);
		Rectangle s = default(Rectangle);
		s.X = num12;
		s.Width = 16;
		s.Height = 16;
		for (int i = 0; i < num9; i++)
		{
			int num13 = 15;
			while (num13 >= 0)
			{
				Color color = lighting.GetColor(num11 + 8 + screenPosition.X >> 4, screenPosition.Y + num10 >> 4);
				color.R = (byte)((float)(int)color.R * num);
				color.G = (byte)((float)(int)color.G * num2);
				color.B = (byte)((float)(int)color.B * num3);
				s.X += 16;
				SpriteSheet<_sheetTiles>.Draw(1, ref pos, ref s, color);
				num13--;
				num11 += 16;
			}
		}
		bool flag = false;
		if (Main.worldSurfacePixels <= screenPosition.Y + 540 + 32)
		{
			num10 = (Main.worldSurface << 4) - screenPosition.Y + 16;
			num8 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.9f, 96.0) - 48.0) - 32;
			num9 = (viewWidth + 64) / 96 + 2;
			int num14;
			int num15;
			if (Main.worldSurfacePixels < screenPosition.Y - 16)
			{
				num14 = num10 % 96 - 96;
				num15 = (540 - num14 + 96) / 96 + 1;
			}
			else
			{
				num14 = num10;
				num15 = (540 - num10 + 96) / 96 + 1;
			}
			if (Main.rockLayerPixels < screenPosition.Y + 540)
			{
				num15 = (Main.rockLayerPixels - screenPosition.Y + 540 - num14) / 96;
				flag = true;
			}
			int num16 = num8 + screenPosition.X;
			num16 = -(num16 & 0xF);
			if (num16 == -8)
			{
				num16 = 8;
			}
			Vector2 pos2 = default(Vector2);
			Rectangle s2 = default(Rectangle);
			s2.Width = 16;
			s2.Height = 16;
			int j = 0;
			int num17 = num8 + 8 + screenPosition.X;
			for (; j < num9; j++)
			{
				int num18 = num14 + 8 + screenPosition.Y >> 4;
				int num19 = 32 + num14;
				for (int k = 0; k < num15; k++)
				{
					for (int l = 0; l < 96; l += 16)
					{
						int num20 = 32 + num8 + 96 * j + l + num16;
						s2.X = l + num16 + 16;
						int num21 = num17 + l >> 4;
						fixed (Tile* ptr = &Main.tile[num21, num18])
						{
							Tile* ptr2 = ptr;
							for (int m = 0; m < 96; m += 16)
							{
								Color colorUnsafe = lighting.GetColorUnsafe(num21, num18);
								pos2.X = num20;
								pos2.Y = num19 + m;
								s2.Y = m;
								if (colorUnsafe.R > 0 || colorUnsafe.G > 0 || colorUnsafe.B > 0)
								{
									if (SMOOTH_LIGHT && (colorUnsafe.R > 226 || (float)(int)colorUnsafe.G > 248.6f || (float)(int)colorUnsafe.B > 271.2f) && ptr2->active == 0 && (ptr2->wall == 0 || ptr2->wall == 21))
									{
										s2.Width = 4;
										s2.Height = 4;
										Color c;
										if (ptr2[-1441].active == 0)
										{
											c = lighting.GetColorUnsafe(num21 - 1, num18 - 1);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Height = 8;
										s2.Y += 4;
										pos2.Y += 4f;
										if (ptr2[-1440].active == 0)
										{
											c = lighting.GetColorUnsafe(num21 - 1, num18);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Height = 4;
										s2.Y += 8;
										pos2.Y += 8f;
										if (ptr2[-1439].active == 0)
										{
											c = lighting.GetColorUnsafe(num21 - 1, num18 + 1);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Width = 8;
										s2.X += 4;
										pos2.X += 4f;
										if (ptr2[1].active == 0)
										{
											c = lighting.GetColorUnsafe(num21, num18 + 1);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Height = 8;
										s2.Y -= 8;
										pos2.Y -= 8f;
										c.R = (byte)((float)(int)colorUnsafe.R * num);
										c.G = (byte)((float)(int)colorUnsafe.G * num2);
										c.B = (byte)((float)(int)colorUnsafe.B * num3);
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Height = 4;
										s2.Y -= 4;
										pos2.Y -= 4f;
										if (ptr2[-1].active == 0)
										{
											c = lighting.GetColorUnsafe(num21, num18 - 1);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Width = 4;
										s2.X += 8;
										pos2.X += 8f;
										if (ptr2[1439].active == 0)
										{
											c = lighting.GetColorUnsafe(num21 + 1, num18 - 1);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Height = 8;
										s2.Y += 4;
										pos2.Y += 4f;
										if (ptr2[1440].active == 0)
										{
											c = lighting.GetColorUnsafe(num21 + 1, num18);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Height = 4;
										s2.Y += 8;
										pos2.Y += 8f;
										if (ptr2[1441].active == 0)
										{
											c = lighting.GetColorUnsafe(num21 + 1, num18 + 1);
											c.R = (byte)((float)(colorUnsafe.R + c.R >> 1) * num);
											c.G = (byte)((float)(colorUnsafe.G + c.G >> 1) * num2);
											c.B = (byte)((float)(colorUnsafe.B + c.B >> 1) * num3);
										}
										else
										{
											c = colorUnsafe;
										}
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c);
										s2.Width = (s2.Height = 16);
										s2.X -= 12;
									}
									else if (SMOOTH_LIGHT && (colorUnsafe.R > 160 || (float)(int)colorUnsafe.G > 176f || (float)(int)colorUnsafe.B > 192f))
									{
										s2.Width = 8;
										s2.Height = 8;
										Color c2 = ((!lighting.Brighter(num21, num18 - 1, num21 - 1, num18)) ? lighting.GetColorUnsafe(num21, num18 - 1) : lighting.GetColorUnsafe(num21 - 1, num18));
										c2.R = (byte)((float)(colorUnsafe.R + c2.R >> 1) * num);
										c2.G = (byte)((float)(colorUnsafe.G + c2.G >> 1) * num2);
										c2.B = (byte)((float)(colorUnsafe.B + c2.B >> 1) * num3);
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c2);
										s2.Y += 8;
										pos2.Y += 8f;
										c2 = ((!lighting.Brighter(num21, num18 + 1, num21 - 1, num18)) ? lighting.GetColorUnsafe(num21, num18 + 1) : lighting.GetColorUnsafe(num21 - 1, num18));
										c2.R = (byte)((float)(colorUnsafe.R + c2.R >> 1) * num);
										c2.G = (byte)((float)(colorUnsafe.G + c2.G >> 1) * num2);
										c2.B = (byte)((float)(colorUnsafe.B + c2.B >> 1) * num3);
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c2);
										s2.X += 8;
										pos2.X += 8f;
										c2 = ((!lighting.Brighter(num21, num18 + 1, num21 + 1, num18)) ? lighting.GetColorUnsafe(num21, num18 + 1) : lighting.GetColorUnsafe(num21 + 1, num18));
										c2.R = (byte)((float)(colorUnsafe.R + c2.R >> 1) * num);
										c2.G = (byte)((float)(colorUnsafe.G + c2.G >> 1) * num2);
										c2.B = (byte)((float)(colorUnsafe.B + c2.B >> 1) * num3);
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c2);
										s2.Y -= 8;
										pos2.Y -= 8f;
										c2 = ((!lighting.Brighter(num21, num18 - 1, num21 + 1, num18)) ? lighting.GetColorUnsafe(num21, num18 - 1) : lighting.GetColorUnsafe(num21 + 1, num18));
										c2.R = (byte)((float)(colorUnsafe.R + c2.R >> 1) * num);
										c2.G = (byte)((float)(colorUnsafe.G + c2.G >> 1) * num2);
										c2.B = (byte)((float)(colorUnsafe.B + c2.B >> 1) * num3);
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, c2);
										s2.Width = (s2.Height = 16);
										s2.X -= 8;
									}
									else
									{
										colorUnsafe.R = (byte)((float)(int)colorUnsafe.R * num);
										colorUnsafe.G = (byte)((float)(int)colorUnsafe.G * num2);
										colorUnsafe.B = (byte)((float)(int)colorUnsafe.B * num3);
										SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, colorUnsafe);
									}
								}
								else
								{
									SpriteSheet<_sheetTiles>.Draw(2, ref pos2, ref s2, colorUnsafe);
								}
								num18++;
								ptr2++;
							}
							num18 -= 6;
						}
					}
					num19 += 96;
					num18 += 6;
				}
				num17 += 96;
			}
			if (flag)
			{
				num8 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.9f, 96.0) - 48.0);
				num9 = (viewWidth + 64) / 96 + 2;
				num10 = num14 + num15 * 96;
				if (num10 > -32)
				{
					Vector2 vector = new Vector2(32 + num8 + num16, 32 + num10);
					int num22 = num8 + 8;
					for (int n = 0; n < num9; n++)
					{
						for (int num23 = 0; num23 < 96; num23 += 16)
						{
							Color color2 = lighting.GetColor(num22 + screenPosition.X >> 4, screenPosition.Y + num10 >> 4);
							num22 += 16;
							color2.R = (byte)((float)(int)color2.R * num);
							color2.G = (byte)((float)(int)color2.G * num2);
							color2.B = (byte)((float)(int)color2.B * num3);
							Main.spriteBatch.Draw(backgroundTexture[4], vector, (Rectangle?)new Rectangle(num23 + num16 + 16, 0, 16, 16), color2);
							vector.X += 16f;
						}
					}
				}
			}
		}
		bool flag2 = false;
		int magmaLayerPixels = Main.magmaLayerPixels;
		if (Main.rockLayerPixels <= screenPosition.Y + 540)
		{
			num10 = Main.rockLayerPixels - screenPosition.Y + 540 - 28;
			num8 = (int)(0.0 - Math.IEEERemainder(96f + (float)screenPosition.X * 0.9f, 96.0) - 48.0) - 32;
			num9 = (viewWidth + 64) / 96 + 2;
			int num14;
			int num15;
			if (Main.rockLayerPixels + 540 < screenPosition.Y - 16)
			{
				num14 = (int)(Math.IEEERemainder(num10, 96.0) - 96.0);
				num15 = (540 - num14 + 96) / 96 + 1;
			}
			else
			{
				num14 = num10;
				num15 = (540 - num10 + 96) / 96 + 1;
			}
			if (magmaLayerPixels < screenPosition.Y + 540)
			{
				num15 = (magmaLayerPixels - screenPosition.Y + 540 - num14) / 96;
				flag2 = true;
			}
			int num24 = num8 + screenPosition.X;
			num24 = -(num24 & 0xF);
			if (num24 == -8)
			{
				num24 = 8;
			}
			for (int num25 = 0; num25 < num9; num25++)
			{
				for (int num26 = 0; num26 < num15; num26++)
				{
					for (int num27 = 0; num27 < 96; num27 += 16)
					{
						int num28 = num8 + 96 * num25 + num27 + 8;
						int num29 = num28 + screenPosition.X >> 4;
						for (int num30 = 0; num30 < 96; num30 += 16)
						{
							int num31 = num14 + num26 * 96 + num30 + 8;
							int num32 = num31 + screenPosition.Y >> 4;
							Color colorUnsafe2 = lighting.GetColorUnsafe(num29, num32);
							bool flag3 = false;
							int wall = Main.tile[num29, num32].wall;
							if (wall == 0 || wall == 21 || Main.tile[num29 - 1, num32].wall == 0 || Main.tile[num29 - 1, num32].wall == 21 || Main.tile[num29 + 1, num32].wall == 0 || Main.tile[num29 + 1, num32].wall == 21)
							{
								flag3 = true;
							}
							if ((!flag3 && colorUnsafe2.R != 0 && colorUnsafe2.G != 0 && colorUnsafe2.B != 0) || (colorUnsafe2.R <= 0 && colorUnsafe2.G <= 0 && colorUnsafe2.B <= 0))
							{
								continue;
							}
							if (SMOOTH_LIGHT && colorUnsafe2.R < 230 && colorUnsafe2.G < 230 && colorUnsafe2.B < 230)
							{
								if ((colorUnsafe2.R > 226 || (double)(int)colorUnsafe2.G > 248.60000000000002 || (double)(int)colorUnsafe2.B > 271.2) && Main.tile[num29, num32].active == 0)
								{
									for (int num33 = 0; num33 < 9; num33++)
									{
										int num34 = 0;
										int num35 = 0;
										int width = 4;
										int height = 4;
										Color color3 = colorUnsafe2;
										Color color4 = colorUnsafe2;
										switch (num33)
										{
										case 0:
											if (Main.tile[num29 - 1, num32 - 1].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29 - 1, num32 - 1);
											}
											break;
										case 1:
											width = 8;
											num34 = 4;
											if (Main.tile[num29, num32 - 1].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29, num32 - 1);
											}
											break;
										case 2:
											if (Main.tile[num29 + 1, num32 - 1].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29 + 1, num32 - 1);
											}
											num34 = 12;
											break;
										case 3:
											if (Main.tile[num29 - 1, num32].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29 - 1, num32);
											}
											height = 8;
											num35 = 4;
											break;
										case 4:
											width = 8;
											height = 8;
											num34 = 4;
											num35 = 4;
											break;
										case 5:
											num34 = 12;
											num35 = 4;
											height = 8;
											if (Main.tile[num29 + 1, num32].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29 + 1, num32);
											}
											break;
										case 6:
											if (Main.tile[num29 - 1, num32 + 1].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29 - 1, num32 + 1);
											}
											num35 = 12;
											break;
										case 7:
											width = 8;
											height = 4;
											num34 = 4;
											num35 = 12;
											if (Main.tile[num29, num32 + 1].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29, num32 + 1);
											}
											break;
										default:
											if (Main.tile[num29 + 1, num32 + 1].active == 0)
											{
												color4 = lighting.GetColorUnsafe(num29 + 1, num32 + 1);
											}
											num34 = 12;
											num35 = 12;
											break;
										}
										color3.R = (byte)((float)(colorUnsafe2.R + color4.R >> 1) * num);
										color3.G = (byte)((float)(colorUnsafe2.G + color4.G >> 1) * num2);
										color3.B = (byte)((float)(colorUnsafe2.B + color4.B >> 1) * num3);
										Main.spriteBatch.Draw(backgroundTexture[3], new Vector2(32 + num8 + 96 * num25 + num27 + num34 + num24, 32 + num14 + 96 * num26 + num30 + num35), (Rectangle?)new Rectangle(num27 + num34 + num24 + 16, num30 + num35, width, height), color3);
									}
								}
								else if (colorUnsafe2.R > 160 || (double)(int)colorUnsafe2.G > 176.0 || (double)(int)colorUnsafe2.B > 192.0)
								{
									for (int num36 = 0; num36 < 4; num36++)
									{
										int num37 = 0;
										int num38 = 0;
										Color color5 = colorUnsafe2;
										Color color6 = colorUnsafe2;
										switch (num36)
										{
										case 0:
											color6 = ((!lighting.Brighter(num29, num32 - 1, num29 - 1, num32)) ? lighting.GetColorUnsafe(num29, num32 - 1) : lighting.GetColorUnsafe(num29 - 1, num32));
											break;
										case 1:
											color6 = ((!lighting.Brighter(num29, num32 - 1, num29 + 1, num32)) ? lighting.GetColorUnsafe(num29, num32 - 1) : lighting.GetColorUnsafe(num29 + 1, num32));
											num37 = 8;
											break;
										case 2:
											color6 = ((!lighting.Brighter(num29, num32 + 1, num29 - 1, num32)) ? lighting.GetColorUnsafe(num29, num32 + 1) : lighting.GetColorUnsafe(num29 - 1, num32));
											num38 = 8;
											break;
										default:
											color6 = ((!lighting.Brighter(num29, num32 + 1, num29 + 1, num32)) ? lighting.GetColorUnsafe(num29, num32 + 1) : lighting.GetColorUnsafe(num29 + 1, num32));
											num37 = 8;
											num38 = 8;
											break;
										}
										color5.R = (byte)((float)(colorUnsafe2.R + color6.R >> 1) * num);
										color5.G = (byte)((float)(colorUnsafe2.G + color6.G >> 1) * num2);
										color5.B = (byte)((float)(colorUnsafe2.B + color6.B >> 1) * num3);
										Main.spriteBatch.Draw(backgroundTexture[3], new Vector2(32 + num8 + 96 * num25 + num27 + num37 + num24, 32 + num14 + 96 * num26 + num30 + num38), (Rectangle?)new Rectangle(num27 + num37 + num24 + 16, num30 + num38, 8, 8), color5);
									}
								}
								else
								{
									colorUnsafe2.R = (byte)((float)(int)colorUnsafe2.R * num);
									colorUnsafe2.G = (byte)((float)(int)colorUnsafe2.G * num2);
									colorUnsafe2.B = (byte)((float)(int)colorUnsafe2.B * num3);
									Main.spriteBatch.Draw(backgroundTexture[3], new Vector2(32 + num8 + 96 * num25 + num27 + num24, 32 + num14 + 96 * num26 + num30), (Rectangle?)new Rectangle(num27 + num24 + 16, num30, 16, 16), colorUnsafe2);
								}
							}
							else
							{
								colorUnsafe2.R = (byte)((float)(int)colorUnsafe2.R * num);
								colorUnsafe2.G = (byte)((float)(int)colorUnsafe2.G * num2);
								colorUnsafe2.B = (byte)((float)(int)colorUnsafe2.B * num3);
								Main.spriteBatch.Draw(backgroundTexture[3], new Vector2(32 + num8 + 96 * num25 + num27 + num24, 32 + num14 + 96 * num26 + num30), (Rectangle?)new Rectangle(num27 + num24 + 16, num30, 16, 16), colorUnsafe2);
							}
						}
					}
				}
			}
			if (flag2)
			{
				num8 = (int)(0.0 - Math.IEEERemainder((float)screenPosition.X * 0.9f, 96.0) - 48.0);
				num9 = viewWidth / 96 + 2;
				num10 = num14 + num15 * 96;
				Rectangle value = new Rectangle(0, Main.magmaBGFrame << 4, 16, 16);
				int num39 = num8 + 8;
				for (int num40 = 0; num40 < num9; num40++)
				{
					for (int num41 = 0; num41 < 96; num41 += 16)
					{
						value.X = num41 + num24 + 16;
						Color color7 = lighting.GetColor(num39 + screenPosition.X >> 4, screenPosition.Y + num10 >> 4);
						color7.R = (byte)((float)(int)color7.R * num);
						color7.G = (byte)((float)(int)color7.G * num2);
						color7.B = (byte)((float)(int)color7.B * num3);
						Main.spriteBatch.Draw(backgroundTexture[6], new Vector2(32 + num8 + 96 * num40 + num41 + num24, 32 + num10), (Rectangle?)value, color7);
						num39 += 16;
					}
				}
			}
		}
		if (magmaLayerPixels <= screenPosition.Y + 540)
		{
			num10 = magmaLayerPixels - screenPosition.Y + 540 - 28;
			num8 = (int)(0.0 - Math.IEEERemainder(96f + (float)screenPosition.X * 0.9f, 96.0) - 48.0) - 32;
			num9 = (viewWidth + 64) / 96 + 2;
			int num14;
			int num15;
			if (magmaLayerPixels + 540 < screenPosition.Y - 16)
			{
				num14 = (int)(Math.IEEERemainder(num10, 96.0) - 96.0);
				num15 = (540 - num14 + 96) / 96 + 1;
			}
			else
			{
				num14 = num10;
				num15 = (540 - num10 + 96) / 96 + 1;
			}
			float num42 = num8 + screenPosition.X;
			num42 = 0f - (float)Math.IEEERemainder(num42, 16.0);
			num42 = (float)Math.Round(num42);
			int num43 = (int)num42;
			if (num43 == -8)
			{
				num43 = 8;
			}
			for (int num44 = 0; num44 < num9; num44++)
			{
				for (int num45 = 0; num45 < num15; num45++)
				{
					for (int num46 = 0; num46 < 96; num46 += 16)
					{
						int num47 = num8 + 96 * num44 + num46 + 8 + screenPosition.X >> 4;
						int num48 = num14 + num45 * 96 + 8 + screenPosition.Y >> 4;
						for (int num49 = 0; num49 < 96; num49 += 16)
						{
							Color colorUnsafe3 = lighting.GetColorUnsafe(num47, num48);
							bool flag4 = false;
							int wall2 = Main.tile[num47, num48].wall;
							if (wall2 == 0 || wall2 == 21 || Main.tile[num47 - 1, num48].wall == 0 || Main.tile[num47 - 1, num48].wall == 21 || Main.tile[num47 + 1, num48].wall == 0 || Main.tile[num47 + 1, num48].wall == 21)
							{
								flag4 = true;
							}
							if ((flag4 || colorUnsafe3.R == 0 || colorUnsafe3.G == 0 || colorUnsafe3.B == 0) && (colorUnsafe3.R > 0 || colorUnsafe3.G > 0 || colorUnsafe3.B > 0))
							{
								if (SMOOTH_LIGHT && colorUnsafe3.R < 230 && colorUnsafe3.G < 230 && colorUnsafe3.B < 230)
								{
									if ((colorUnsafe3.R > 339 || (float)(int)colorUnsafe3.G > 372.9f || (float)(int)colorUnsafe3.B > 1278f / (float)Math.PI) && Main.tile[num47, num48].active == 0)
									{
										for (int num50 = 0; num50 < 9; num50++)
										{
											int num51 = 0;
											int num52 = 0;
											int width2 = 4;
											int height2 = 4;
											Color color8 = colorUnsafe3;
											Color color9 = colorUnsafe3;
											switch (num50)
											{
											case 0:
												if (Main.tile[num47 - 1, num48 - 1].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47 - 1, num48 - 1);
												}
												break;
											case 1:
												width2 = 8;
												num51 = 4;
												if (Main.tile[num47, num48 - 1].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47, num48 - 1);
												}
												break;
											case 2:
												if (Main.tile[num47 + 1, num48 - 1].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47 + 1, num48 - 1);
												}
												num51 = 12;
												break;
											case 3:
												if (Main.tile[num47 - 1, num48].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47 - 1, num48);
												}
												height2 = 8;
												num52 = 4;
												break;
											case 4:
												width2 = 8;
												height2 = 8;
												num51 = 4;
												num52 = 4;
												break;
											case 5:
												num51 = 12;
												num52 = 4;
												height2 = 8;
												if (Main.tile[num47 + 1, num48].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47 + 1, num48);
												}
												break;
											case 6:
												if (Main.tile[num47 - 1, num48 + 1].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47 - 1, num48 + 1);
												}
												num52 = 12;
												break;
											case 7:
												width2 = 8;
												height2 = 4;
												num51 = 4;
												num52 = 12;
												if (Main.tile[num47, num48 + 1].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47, num48 + 1);
												}
												break;
											default:
												if (Main.tile[num47 + 1, num48 + 1].active == 0)
												{
													color9 = lighting.GetColorUnsafe(num47 + 1, num48 + 1);
												}
												num51 = 12;
												num52 = 12;
												break;
											}
											color8.R = (byte)((float)(colorUnsafe3.R + color9.R >> 1) * num);
											color8.G = (byte)((float)(colorUnsafe3.G + color9.G >> 1) * num2);
											color8.B = (byte)((float)(colorUnsafe3.B + color9.B >> 1) * num3);
											Main.spriteBatch.Draw(backgroundTexture[5], new Vector2(32 + num8 + 96 * num44 + num46 + num51 + num43, 32 + num14 + 96 * num45 + num49 + num52), (Rectangle?)new Rectangle(num46 + num51 + num43 + 16, num49 + 96 * Main.magmaBGFrame + num52, width2, height2), color8);
										}
									}
									else if (colorUnsafe3.R > 240 || (double)(int)colorUnsafe3.G > 264.0 || (double)(int)colorUnsafe3.B > 288.0)
									{
										for (int num53 = 0; num53 < 4; num53++)
										{
											int num54 = 0;
											int num55 = 0;
											Color color10 = colorUnsafe3;
											Color color11 = colorUnsafe3;
											switch (num53)
											{
											case 0:
												color11 = ((!lighting.Brighter(num47, num48 - 1, num47 - 1, num48)) ? lighting.GetColorUnsafe(num47, num48 - 1) : lighting.GetColorUnsafe(num47 - 1, num48));
												break;
											case 1:
												color11 = ((!lighting.Brighter(num47, num48 - 1, num47 + 1, num48)) ? lighting.GetColorUnsafe(num47, num48 - 1) : lighting.GetColorUnsafe(num47 + 1, num48));
												num54 = 8;
												break;
											case 2:
												color11 = ((!lighting.Brighter(num47, num48 + 1, num47 - 1, num48)) ? lighting.GetColorUnsafe(num47, num48 + 1) : lighting.GetColorUnsafe(num47 - 1, num48));
												num55 = 8;
												break;
											default:
												color11 = ((!lighting.Brighter(num47, num48 + 1, num47 + 1, num48)) ? lighting.GetColorUnsafe(num47, num48 + 1) : lighting.GetColorUnsafe(num47 + 1, num48));
												num54 = 8;
												num55 = 8;
												break;
											}
											color10.R = (byte)((float)(colorUnsafe3.R + color11.R >> 1) * num);
											color10.G = (byte)((float)(colorUnsafe3.G + color11.G >> 1) * num2);
											color10.B = (byte)((float)(colorUnsafe3.B + color11.B >> 1) * num3);
											Main.spriteBatch.Draw(backgroundTexture[5], new Vector2(32 + num8 + 96 * num44 + num46 + num54 + num43, 32 + num14 + 96 * num45 + num49 + num55), (Rectangle?)new Rectangle(num46 + num54 + num43 + 16, num49 + 96 * Main.magmaBGFrame + num55, 8, 8), color10);
										}
									}
									else
									{
										colorUnsafe3.R = (byte)((float)(int)colorUnsafe3.R * num);
										colorUnsafe3.G = (byte)((float)(int)colorUnsafe3.G * num2);
										colorUnsafe3.B = (byte)((float)(int)colorUnsafe3.B * num3);
										Main.spriteBatch.Draw(backgroundTexture[5], new Vector2(32 + num8 + 96 * num44 + num46 + num43, 32 + num14 + 96 * num45 + num49), (Rectangle?)new Rectangle(num46 + num43 + 16, num49 + 96 * Main.magmaBGFrame, 16, 16), colorUnsafe3);
									}
								}
								else
								{
									colorUnsafe3.R = (byte)((float)(int)colorUnsafe3.R * num);
									colorUnsafe3.G = (byte)((float)(int)colorUnsafe3.G * num2);
									colorUnsafe3.B = (byte)((float)(int)colorUnsafe3.B * num3);
									Main.spriteBatch.Draw(backgroundTexture[5], new Vector2(32 + num8 + 96 * num44 + num46 + num43, 32 + num14 + 96 * num45 + num49), (Rectangle?)new Rectangle(num46 + num43 + 16, num49 + 96 * Main.magmaBGFrame, 16, 16), colorUnsafe3);
								}
							}
							num48++;
						}
					}
				}
			}
		}
		lighting.brightness = (player.blind ? 1f : lighting.defBrightness);
	}

	private void RenderBlack()
	{
		graphicsDevice.SetRenderTarget(blackTarget);
		graphicsDevice.Clear(default(Color));
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, renderTargetProjection);
		DrawBlack();
		Main.spriteBatch.End();
		sceneBlackPos.X = screenPosition.X - 32;
		sceneBlackPos.Y = screenPosition.Y - 32;
	}

	private void RenderWalls()
	{
		graphicsDevice.SetRenderTarget(wallTarget);
		graphicsDevice.Clear(default(Color));
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, renderTargetProjection);
		DrawWalls();
		Main.spriteBatch.End();
		sceneWallPos.X = screenPosition.X - 32;
		sceneWallPos.Y = screenPosition.Y - 32;
	}

	private void RenderBackWater()
	{
		graphicsDevice.SetRenderTarget(backWaterTarget);
		graphicsDevice.Clear(default(Color));
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, renderTargetProjection);
		DrawWater(bg: true);
		Main.spriteBatch.End();
	}

	private void RenderBackground()
	{
		graphicsDevice.SetRenderTarget(backgroundTarget);
		graphicsDevice.Clear(default(Color));
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, renderTargetProjection);
		DrawBackground();
		Main.spriteBatch.End();
		sceneBackgroundPos.X = screenPosition.X - 32;
		sceneBackgroundPos.Y = screenPosition.Y - 32;
	}

	private void RenderSolidTiles()
	{
		graphicsDevice.SetRenderTarget(tileSolidTarget);
		graphicsDevice.Clear(default(Color));
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, null, null, null, renderTargetProjection);
		DrawSolidTiles();
		Main.spriteBatch.End();
		sceneTilePos.X = screenPosition.X - 32;
		sceneTilePos.Y = screenPosition.Y - 32;
	}

	private void RenderNonSolidTiles()
	{
		graphicsDevice.SetRenderTarget(tileNonSolidTarget);
		graphicsDevice.Clear(default(Color));
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, renderTargetProjection);
		DrawNonSolidTiles();
		Main.spriteBatch.End();
		sceneTile2Pos.X = screenPosition.X - 32;
		sceneTile2Pos.Y = screenPosition.Y - 32;
	}

	private void RenderWater()
	{
		graphicsDevice.SetRenderTarget(waterTarget);
		graphicsDevice.Clear(default(Color));
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, renderTargetProjection);
		DrawWater();
		if (player.inventory[player.selectedItem].mech)
		{
			DrawWires();
		}
		Main.spriteBatch.End();
		sceneWaterPos.X = screenPosition.X - 32;
		sceneWaterPos.Y = screenPosition.Y - 32;
	}

	public static void shine(ref Color newColor, int type)
	{
		int num;
		int num2;
		int num3;
		switch (type)
		{
		case 25:
			num = newColor.R * 243 >> 8;
			num2 = newColor.G * 217 >> 8;
			num3 = newColor.B * 281 >> 8;
			break;
		case 117:
			num = newColor.R * 281 >> 8;
			num2 = newColor.G;
			num3 = newColor.B * 307 >> 8;
			if (num > 255)
			{
				num = 255;
			}
			break;
		default:
			num = newColor.R * 409 >> 8;
			num2 = newColor.G * 409 >> 8;
			num3 = newColor.B * 409 >> 8;
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			break;
		}
		if (num3 > 255)
		{
			num3 = 255;
		}
		newColor.R = (byte)num;
		newColor.G = (byte)num2;
		newColor.B = (byte)num3;
	}

	private unsafe void Highlight2x1(Tile* pTile, Tile.Flags mask)
	{
		pTile->flags |= mask;
		pTile = ((pTile->frameX != 0) ? (pTile - 1440) : (pTile + 1440));
		pTile->flags |= mask;
	}

	private unsafe void Highlight2x2(Tile* pTile, Tile.Flags mask)
	{
		int num = ((pTile->frameY == 0) ? 1 : (-1));
		pTile->flags |= mask;
		pTile += num;
		pTile->flags |= mask;
		pTile = ((((uint)(pTile->frameX / 18) & (true ? 1u : 0u)) != 0) ? (pTile - 1440) : (pTile + 1440));
		pTile->flags |= mask;
		pTile -= num;
		pTile->flags |= mask;
	}

	private unsafe void Highlight1x3(Tile* pTile, Tile.Flags mask)
	{
		pTile->flags |= mask;
		if (pTile->frameY == 0)
		{
			pTile++;
			pTile->flags |= mask;
			pTile++;
		}
		else if (pTile->frameY == 18)
		{
			pTile++;
			pTile->flags |= mask;
			pTile -= 2;
		}
		else
		{
			pTile--;
			pTile->flags |= mask;
			pTile--;
		}
		pTile->flags |= mask;
	}

	private unsafe void Highlight2x3(Tile* pTile, Tile.Flags mask)
	{
		pTile->flags |= mask;
		if (pTile->frameY == 0)
		{
			pTile++;
			pTile->flags |= mask;
			pTile++;
			pTile->flags |= mask;
			if (((pTile->frameX / 18) & 1) == 0)
			{
				pTile += 1438;
				pTile->flags |= mask;
				pTile++;
				pTile->flags |= mask;
				pTile++;
			}
			else
			{
				pTile -= 1440;
				pTile->flags |= mask;
				pTile--;
				pTile->flags |= mask;
				pTile--;
			}
		}
		else if (pTile->frameY == 18)
		{
			pTile++;
			pTile->flags |= mask;
			pTile -= 2;
			pTile->flags |= mask;
			if (((pTile->frameX / 18) & 1) == 0)
			{
				pTile += 1440;
				pTile->flags |= mask;
				pTile++;
				pTile->flags |= mask;
				pTile++;
			}
			else
			{
				pTile -= 1440;
				pTile->flags |= mask;
				pTile++;
				pTile->flags |= mask;
				pTile++;
			}
		}
		else
		{
			pTile--;
			pTile->flags |= mask;
			pTile--;
			pTile->flags |= mask;
			if (((pTile->frameX / 18) & 1) == 0)
			{
				pTile += 1440;
				pTile->flags |= mask;
				pTile++;
				pTile->flags |= mask;
				pTile++;
			}
			else
			{
				pTile -= 1440;
				pTile->flags |= mask;
				pTile++;
				pTile->flags |= mask;
				pTile++;
			}
		}
		pTile->flags |= mask;
	}

	private unsafe void Highlight4x2(Tile* pTile, Tile.Flags mask)
	{
		int num = ((pTile->frameY == 0) ? 1 : (-1));
		pTile->flags |= mask;
		pTile += num;
		pTile->flags |= mask;
		switch ((pTile->frameX / 18) & 3)
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
		int num = ((pTile->frameX == 0) ? 1440 : (-1440));
		pTile->flags |= mask;
		pTile += num;
		pTile->flags |= mask;
		switch (pTile->frameY / 18)
		{
		case 0:
			pTile++;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile++;
			pTile->flags |= mask;
			pTile += num;
			pTile->flags |= mask;
			pTile++;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile++;
			break;
		case 1:
			pTile--;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile += 2;
			pTile->flags |= mask;
			pTile += num;
			pTile->flags |= mask;
			pTile++;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile++;
			break;
		case 2:
			pTile--;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile--;
			pTile->flags |= mask;
			pTile += num;
			pTile->flags |= mask;
			pTile += 3;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile++;
			break;
		case 3:
			pTile++;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile -= 2;
			pTile->flags |= mask;
			pTile += num;
			pTile->flags |= mask;
			pTile--;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile--;
			break;
		default:
			pTile--;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile--;
			pTile->flags |= mask;
			pTile += num;
			pTile->flags |= mask;
			pTile--;
			pTile->flags |= mask;
			pTile -= num;
			pTile->flags |= mask;
			pTile--;
			break;
		}
		pTile->flags |= mask;
		pTile += num;
		pTile->flags |= mask;
	}

	private unsafe void DrawNonSolidTiles()
	{
		int num = 0;
		Rectangle s = default(Rectangle);
		Vector2 pos = default(Vector2);
		Main.tileSolid[10] = false;
		fixed (Tile* ptr = Main.tile)
		{
			int i;
			if (!player.dead)
			{
				Tile* ptr2 = (((Main.frameCounter & 0x20) == 0) ? null : (ptr + (player.tileInteractX * 1440 + player.tileInteractY)));
				int num2 = (player.aabb.X + 10 >> 4) - 10;
				int num3 = (player.aabb.Y + 21 >> 4) - 8;
				for (i = 0; i < 20; i++)
				{
					Tile* ptr3 = ptr + ((num2 + i) * 1440 + num3);
					for (int j = 0; j < 16; j++)
					{
						if (ptr3->active != 0)
						{
							Tile.Flags flags = ((ptr3 == ptr2) ? Tile.Flags.SELECTED : Tile.Flags.NEARBY);
							if ((ptr3->flags & flags) != flags)
							{
								switch (ptr3->type)
								{
								case 4:
								case 13:
								case 33:
								case 49:
								case 50:
								case 136:
								case 144:
									ptr3->flags |= flags;
									break;
								case 11:
								case 128:
									Highlight2x3(ptr3, flags);
									break;
								case 10:
									Highlight1x3(ptr3, flags);
									break;
								case 21:
								case 55:
								case 85:
								case 97:
								case 125:
								case 132:
								case 139:
									Highlight2x2(ptr3, flags);
									break;
								case 29:
									Highlight2x1(ptr3, flags);
									break;
								case 79:
									Highlight4x2(ptr3, flags);
									break;
								case 104:
									Highlight2x5(ptr3, flags);
									break;
								}
							}
						}
						ptr3++;
					}
				}
			}
			i = firstTileX - 1;
			int num4 = lastTileX + 2;
			int num5 = lastTileY + 2;
			do
			{
				int num6 = firstTileY;
				Tile* ptr4 = ptr + (i * 1440 + num6 - 1);
				do
				{
					ptr4++;
					if (ptr4->active == 0)
					{
						continue;
					}
					int num7 = ptr4->type;
					if (Main.tileSolid[num7])
					{
						continue;
					}
					Color newColor = lighting.GetColorUnsafe(i, num6);
					int num8 = 0;
					int height = 16;
					int num9 = 16;
					s.X = ptr4->frameX;
					s.Y = ptr4->frameY;
					switch (num7)
					{
					case 3:
					case 24:
					case 61:
					case 71:
					case 110:
						height = 20;
						break;
					case 4:
						num9 = 20;
						height = 20;
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 396;
						}
						break;
					case 5:
						num9 = 20;
						height = 20;
						break;
					case 10:
					case 11:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 108;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 54;
						}
						break;
					case 13:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 36;
						}
						break;
					case 29:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 36;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 18;
						}
						break;
					case 21:
						height = 18;
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 76;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 38;
						}
						break;
					case 33:
					case 49:
						num8 = -4;
						height = 20;
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 44;
						}
						break;
					case 50:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 32;
						}
						break;
					case 73:
					case 74:
					case 113:
						num8 = -12;
						height = 32;
						break;
					case 78:
					case 105:
					case 142:
					case 143:
						num8 = 2;
						break;
					case 81:
						num8 = -8;
						num9 = 24;
						height = 26;
						break;
					case 85:
						num8 = 2;
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 72;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 36;
						}
						break;
					case 104:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 176;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 88;
						}
						break;
					case 97:
					case 125:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 68;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 34;
						}
						break;
					case 128:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 104;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 52;
						}
						break;
					case 132:
						num8 = 2;
						height = 18;
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 72;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 36;
						}
						break;
					case 135:
						num8 = 2;
						height = 18;
						break;
					case 55:
					case 79:
					case 136:
					case 144:
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 72;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 36;
						}
						break;
					case 14:
					case 15:
					case 16:
					case 17:
					case 18:
					case 20:
					case 26:
					case 27:
					case 32:
					case 69:
					case 72:
					case 77:
					case 80:
					case 124:
						height = 18;
						break;
					case 139:
						num8 = 2;
						if ((ptr4->flags & Tile.Flags.SELECTED) != 0)
						{
							s.Y += 1512;
						}
						else if ((ptr4->flags & Tile.Flags.NEARBY) != 0)
						{
							s.Y += 756;
						}
						break;
					}
					s.Width = num9;
					s.Height = height;
					pos.X = (i << 4) - screenPosition.X - (num9 - 16 >> 1) + 32;
					pos.Y = (num6 << 4) - screenPosition.Y + num8 + 32;
					if (player.findTreasure)
					{
						switch (num7)
						{
						case 12:
						case 21:
						case 28:
						case 82:
						case 83:
						case 84:
							if (newColor.R < UI.mouseTextBrightness >> 1)
							{
								newColor.R = (byte)(UI.mouseTextBrightness >> 1);
							}
							if (newColor.G < 70)
							{
								newColor.G = 70;
							}
							if (newColor.B < 210)
							{
								newColor.B = 210;
							}
							newColor.A = UI.mouseTextBrightness;
							if (Main.rand.Next(150) == 0)
							{
								Dust* ptr5 = dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 15, 0.0, 0.0, 150, default(Color), 0.800000011920929);
								if (ptr5 != null)
								{
									ptr5->velocity.X *= 0.1f;
									ptr5->velocity.Y *= 0.1f;
									ptr5->noLight = true;
								}
							}
							break;
						}
					}
					switch (num7)
					{
					case 4:
						if (ptr4->frameX < 66 && Main.rand.Next(40) == 0)
						{
							int num11 = ptr4->frameY / 22;
							num11 = num11 switch
							{
								0 => 6, 
								8 => 75, 
								_ => 58 + num11, 
							};
							if (ptr4->frameX == 22)
							{
								dustLocal.NewDust(i * 16 + 6, num6 * 16, 4, 4, num11, 0.0, 0.0, 100);
							}
							else if (ptr4->frameX == 44)
							{
								dustLocal.NewDust(i * 16 + 2, num6 * 16, 4, 4, num11, 0.0, 0.0, 100);
							}
							else
							{
								dustLocal.NewDust(i * 16 + 4, num6 * 16, 4, 4, num11, 0.0, 0.0, 100);
							}
						}
						break;
					case 24:
					case 32:
						if (Main.rand.Next(500) == 0)
						{
							dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 14);
						}
						break;
					case 26:
					case 31:
						if (Main.rand.Next(20) == 0)
						{
							dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 14, 0.0, 0.0, 100);
						}
						break;
					case 33:
						if (ptr4->frameX == 0 && Main.rand.Next(40) == 0)
						{
							dustLocal.NewDust(i * 16 + 4, num6 * 16 - 4, 4, 4, 6, 0.0, 0.0, 100);
						}
						break;
					case 34:
					case 35:
					case 36:
						if ((ptr4->frameX == 0 || ptr4->frameX == 36) && ptr4->frameY == 18 && Main.rand.Next(40) == 0)
						{
							dustLocal.NewDust(i * 16, num6 * 16 + 2, 14, 6, 6, 0.0, 0.0, 100);
						}
						break;
					case 49:
						if (Main.rand.Next(20) == 0)
						{
							dustLocal.NewDust(i * 16 + 4, num6 * 16 - 4, 4, 4, 29, 0.0, 0.0, 100);
						}
						break;
					case 93:
						if (ptr4->frameX == 0 && ptr4->frameY == 0 && Main.rand.Next(40) == 0)
						{
							dustLocal.NewDust(i * 16 + 4, num6 * 16 + 2, 4, 4, 6, 0.0, 0.0, 100);
						}
						break;
					case 98:
						if (ptr4->frameX == 0 && ptr4->frameY == 0 && Main.rand.Next(40) == 0)
						{
							dustLocal.NewDust(i * 16 + 12, num6 * 16 + 2, 4, 4, 6, 0.0, 0.0, 100);
						}
						break;
					case 100:
						if (ptr4->frameY != 0 || ptr4->frameX >= 36 || Main.rand.Next(40) != 0)
						{
							break;
						}
						if (ptr4->frameX == 0)
						{
							if (Main.rand.Next(3) == 0)
							{
								dustLocal.NewDust(i * 16 + 4, num6 * 16 + 2, 4, 4, 6, 0.0, 0.0, 100);
							}
							else
							{
								dustLocal.NewDust(i * 16 + 14, num6 * 16 + 2, 4, 4, 6, 0.0, 0.0, 100);
							}
						}
						else if (Main.rand.Next(3) == 0)
						{
							dustLocal.NewDust(i * 16 + 6, num6 * 16 + 2, 4, 4, 6, 0.0, 0.0, 100);
						}
						else
						{
							dustLocal.NewDust(i * 16, num6 * 16 + 2, 4, 4, 6, 0.0, 0.0, 100);
						}
						break;
					case 61:
					{
						if (ptr4->frameX != 144)
						{
							break;
						}
						if (Main.rand.Next(60) == 0)
						{
							Dust* ptr7 = dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 44, 0.0, 0.0, 250, default(Color), 0.4000000059604645);
							if (ptr7 != null)
							{
								ptr7->fadeIn = 0.7f;
							}
						}
						byte b2 = (newColor.G = (byte)(245 - UI.mouseTextBrightness + (UI.mouseTextBrightness >> 1)));
						b2 = (newColor.B = b2);
						b2 = (newColor.R = b2);
						newColor.A = b2;
						break;
					}
					case 71:
					case 72:
						if (Main.rand.Next(500) == 0)
						{
							dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 41, 0.0, 0.0, 250, default(Color), 0.800000011920929);
						}
						break;
					case 17:
					case 77:
					case 133:
						if (Main.rand.Next(40) == 0 && ptr4->frameX == 18 && ptr4->frameY == 18)
						{
							dustLocal.NewDust(i * 16 + 2, num6 * 16, 8, 6, 6, 0.0, 0.0, 100);
						}
						break;
					default:
					{
						if (Main.tileShine[num7] <= 0 || (newColor.R <= 20 && newColor.B <= 20 && newColor.G <= 20))
						{
							break;
						}
						int num10 = newColor.R;
						if (newColor.G > num10)
						{
							num10 = newColor.G;
						}
						if (newColor.B > num10)
						{
							num10 = newColor.B;
						}
						num10 /= 30;
						if (Main.rand.Next(Main.tileShine[num7]) < num10 && (num7 != 21 || (ptr4->frameX >= 36 && ptr4->frameX < 180)))
						{
							Dust* ptr6 = dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 43, 0.0, 0.0, 254, default(Color), 0.5);
							if (ptr6 != null)
							{
								ptr6->velocity.X = 0f;
								ptr6->velocity.Y = 0f;
							}
						}
						break;
					}
					}
					if ((num7 == 5 && ptr4->frameY >= 198 && ptr4->frameX >= 22) || (num7 == 128 && ptr4->frameX >= 100))
					{
						spec[num].X = (short)i;
						spec[num].Y = (short)num6;
						spec[num++].tileColor = newColor;
						if (num7 == 128)
						{
							s.X %= 100;
							SpriteSheet<_sheetTiles>.Draw(154, ref pos, ref s, newColor);
						}
					}
					else if (num7 == 129)
					{
						newColor.R = 200;
						newColor.G = 200;
						newColor.B = 200;
						newColor.A = 0;
						SpriteSheet<_sheetTiles>.Draw(26 + num7, ref pos, ref s, newColor);
					}
					else
					{
						if (newColor.R <= 1 && newColor.G <= 1 && newColor.B <= 1)
						{
							continue;
						}
						if (num7 == 72 && ptr4->frameX >= 36)
						{
							int num12 = ptr4->frameY / 18;
							pos.X = i * 16 - screenPosition.X - 22 + 32;
							pos.Y = num6 * 16 - screenPosition.Y - 26 + 32;
							s.X = num12 * 62;
							s.Y = 0;
							s.Width = 60;
							s.Height = 42;
							SpriteSheet<_sheetTiles>.Draw(18, ref pos, ref s, newColor);
							continue;
						}
						if (num7 == 51)
						{
							newColor.R >>= 1;
							newColor.G >>= 1;
							newColor.B >>= 1;
							newColor.A >>= 1;
							SpriteSheet<_sheetTiles>.Draw(26 + num7, ref pos, ref s, newColor);
							continue;
						}
						if (num7 >= 82 && num7 <= 84)
						{
							if (num7 > 82)
							{
								int num13 = ptr4->frameX / 18;
								if (num13 == 0 && time.dayTime)
								{
									num7 = 84;
								}
								else if (num13 == 1 && !time.dayTime)
								{
									num7 = 84;
								}
								else if (num13 == 3 && time.bloodMoon)
								{
									num7 = 84;
								}
								if (num7 == 84)
								{
									switch (num13)
									{
									case 0:
										if (Main.rand.Next(100) == 0)
										{
											Dust* ptr9 = dustLocal.NewDust(i * 16, num6 * 16 - 4, 16, 16, 19, 0.0, 0.0, 160, default(Color), 0.10000000149011612);
											if (ptr9 != null)
											{
												ptr9->velocity.X *= 0.5f;
												ptr9->velocity.Y *= 0.5f;
												ptr9->noGravity = true;
												ptr9->fadeIn = 1f;
											}
										}
										break;
									case 1:
										if (Main.rand.Next(100) == 0)
										{
											dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 41, 0.0, 0.0, 250, default(Color), 0.800000011920929);
										}
										break;
									case 3:
										if (Main.rand.Next(200) == 0)
										{
											Dust* ptr10 = dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 14, 0.0, 0.0, 100, default(Color), 0.20000000298023224);
											if (ptr10 != null)
											{
												ptr10->fadeIn = 1.2f;
											}
										}
										if (Main.rand.Next(75) == 0)
										{
											Dust* ptr11 = dustLocal.NewDust(i * 16, num6 * 16, 16, 16, 27, 0.0, 0.0, 100);
											if (ptr11 != null)
											{
												ptr11->velocity.X *= 0.5f;
												ptr11->velocity.Y *= 0.5f;
											}
										}
										break;
									case 4:
										if (Main.rand.Next(150) == 0)
										{
											Dust* ptr12 = dustLocal.NewDust(i * 16, num6 * 16, 16, 8, 16);
											if (ptr12 != null)
											{
												ptr12->velocity.X *= 1f / 3f;
												ptr12->velocity.Y *= 1f / 3f;
												ptr12->velocity.Y -= 0.7f;
												ptr12->alpha = 50;
												ptr12->scale *= 0.1f;
												ptr12->fadeIn = 0.9f;
												ptr12->noGravity = true;
											}
										}
										break;
									case 5:
										if (Main.rand.Next(40) == 0)
										{
											Dust* ptr8 = dustLocal.NewDust(i * 16, num6 * 16 - 6, 16, 16, 6, 0.0, 0.0, 0, default(Color), 1.5);
											if (ptr8 != null)
											{
												ptr8->velocity.Y -= 2f;
												ptr8->noGravity = true;
											}
										}
										newColor.A = (byte)(UI.mouseTextBrightness >> 1);
										newColor.G = UI.mouseTextBrightness;
										newColor.B = UI.mouseTextBrightness;
										break;
									}
								}
							}
							pos.Y = num6 * 16 - screenPosition.Y - 1 + 32;
							s.Height = 20;
							SpriteSheet<_sheetTiles>.Draw(26 + num7, ref pos, ref s, newColor);
							continue;
						}
						if (num7 == 80)
						{
							bool flag = false;
							bool flag2 = false;
							int num14 = i;
							switch (ptr4->frameX)
							{
							case 36:
								num14--;
								break;
							case 54:
								num14++;
								break;
							case 108:
								num14 = ((ptr4->frameY != 16) ? (num14 + 1) : (num14 - 1));
								break;
							}
							int num15 = num6;
							bool flag3 = false;
							if (Main.tile[num14, num15].type == 80 && Main.tile[num14, num15].active != 0)
							{
								flag3 = true;
							}
							while (Main.tile[num14, num15].active == 0 || !Main.tileSolid[Main.tile[num14, num15].type] || !flag3)
							{
								if (Main.tile[num14, num15].type == 80 && Main.tile[num14, num15].active != 0)
								{
									flag3 = true;
								}
								num15++;
								if (num15 > num6 + 20)
								{
									break;
								}
							}
							if (Main.tile[num14, num15].type == 112)
							{
								flag = true;
							}
							else if (Main.tile[num14, num15].type == 116)
							{
								flag2 = true;
							}
							int id = (flag ? 12 : ((!flag2) ? (26 + num7) : 13));
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor);
							continue;
						}
						bool flag4 = Main.tileShine2[num7];
						int id2 = 26 + num7;
						if (SMOOTH_LIGHT && Main.tileSolid[num7] && num7 != 137)
						{
							if (newColor.R > 198 || (float)(int)newColor.G > 217.8f || (float)(int)newColor.B > 237.6f)
							{
								s.Width = 4;
								s.Height = 4;
								Color newColor2 = lighting.GetColorUnsafe(i - 1, num6 - 1);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.X += 4f;
								s.X += 4;
								s.Width = 8;
								newColor2 = lighting.GetColorUnsafe(i, num6 - 1);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.X += 8f;
								s.X += 8;
								s.Width = 4;
								newColor2 = lighting.GetColorUnsafe(i + 1, num6 - 1);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.Y += 4f;
								s.Y += 4;
								s.Height = 8;
								newColor2 = lighting.GetColorUnsafe(i + 1, num6);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.X -= 12f;
								s.X -= 12;
								newColor2 = lighting.GetColorUnsafe(i - 1, num6);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.Y += 8f;
								s.Y += 8;
								s.Height = 4;
								newColor2 = lighting.GetColorUnsafe(i - 1, num6 + 1);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.X += 4f;
								s.X += 4;
								s.Width = 8;
								newColor2 = lighting.GetColorUnsafe(i, num6 + 1);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.X += 8f;
								s.X += 8;
								s.Width = 4;
								newColor2 = lighting.GetColorUnsafe(i + 1, num6 + 1);
								newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
								newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
								newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
								if (flag4)
								{
									shine(ref newColor2, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor2);
								pos.X -= 8f;
								pos.Y -= 8f;
								s.X -= 8;
								s.Y -= 8;
								s.Width = 8;
								s.Height = 8;
								if (flag4)
								{
									shine(ref newColor, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor);
							}
							else if (newColor.R > 38 || (float)(int)newColor.G > 41.8f || (float)(int)newColor.B > 45.600002f)
							{
								s.Width = 8;
								s.Height = 8;
								Color newColor3 = lighting.GetColorUnsafe(i - 1, num6 - 1);
								newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
								newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
								newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
								if (flag4)
								{
									shine(ref newColor3, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor3);
								pos.X += 8f;
								s.X += 8;
								newColor3 = lighting.GetColorUnsafe(i + 1, num6 - 1);
								newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
								newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
								newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
								if (flag4)
								{
									shine(ref newColor3, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor3);
								pos.Y += 8f;
								s.Y += 8;
								newColor3 = lighting.GetColorUnsafe(i + 1, num6 + 1);
								newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
								newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
								newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
								if (flag4)
								{
									shine(ref newColor3, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor3);
								pos.X -= 8f;
								s.X -= 8;
								newColor3 = lighting.GetColorUnsafe(i - 1, num6 + 1);
								newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
								newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
								newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
								if (flag4)
								{
									shine(ref newColor3, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor3);
							}
							else
							{
								if (flag4)
								{
									shine(ref newColor, num7);
								}
								SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor);
							}
							continue;
						}
						if (SMOOTH_LIGHT && flag4)
						{
							if (num7 == 21)
							{
								if (ptr4->frameX >= 36 && ptr4->frameX < 178)
								{
									shine(ref newColor, num7);
								}
							}
							else
							{
								shine(ref newColor, num7);
							}
						}
						SpriteSheet<_sheetTiles>.Draw(id2, ref pos, ref s, newColor);
						switch (num7)
						{
						case 139:
							newColor.R = 200;
							newColor.G = 200;
							newColor.B = 200;
							newColor.A = 0;
							SpriteSheet<_sheetTiles>.Draw(17, ref pos, ref s, newColor);
							break;
						case 144:
							newColor.R = 200;
							newColor.G = 200;
							newColor.B = 200;
							newColor.A = 0;
							SpriteSheet<_sheetTiles>.Draw(176, ref pos, ref s, newColor);
							break;
						}
					}
				}
				while (++num6 < num5);
			}
			while (++i < num4);
			if (!player.dead)
			{
				int num16 = (player.aabb.X + 10 >> 4) - 10;
				int num17 = (player.aabb.Y + 21 >> 4) - 8;
				for (i = -3; i < 23; i++)
				{
					Tile* ptr13 = ptr + ((num16 + i) * 1440 + num17 - 4);
					for (int k = -4; k < 20; k++)
					{
						ptr13->flags &= ~Tile.Flags.HIGHLIGHT_MASK;
						ptr13++;
					}
				}
			}
		}
		Vector2 pos2 = default(Vector2);
		for (int l = 0; l < num; l++)
		{
			int x = spec[l].X;
			int y = spec[l].Y;
			Color tileColor = spec[l].tileColor;
			pos2.X = 32 + x * 16 - screenPosition.X;
			pos2.Y = 32 + y * 16 - screenPosition.Y;
			fixed (Tile* ptr14 = &Main.tile[x, y])
			{
				if (ptr14->type == 128)
				{
					int num18 = ptr14->frameY / 18;
					int frameX = ptr14->frameX;
					int num19 = frameX / 100;
					frameX %= 100;
					SpriteEffects se = SpriteEffects.FlipHorizontally;
					if (frameX >= 36)
					{
						se = SpriteEffects.None;
					}
					pos2.X += -4f;
					pos2.Y += -12 - (num18 << 4);
					int sh = 54;
					switch (num18)
					{
					case 0:
						num19 += 60;
						sh = 36;
						break;
					case 1:
						num19 += 32;
						break;
					default:
						num19 += 107;
						break;
					}
					SpriteSheet<_sheetSprites>.Draw(num19, ref pos2, sh, tileColor, se);
					continue;
				}
				Rectangle s2 = default(Rectangle);
				if (ptr14->frameX == 22)
				{
					int num20 = 0;
					if (ptr14->frameY == 220)
					{
						num20 = 1;
					}
					else if (ptr14->frameY == 242)
					{
						num20 = 2;
					}
					int num21 = 0;
					s2.Width = 80;
					s2.Height = 80;
					int num22 = 32;
					int num23 = ((y + 100 >= Main.maxTilesY) ? (Main.maxTilesY - y) : 100);
					for (int m = 0; m < num23; m++)
					{
						switch (ptr14[m].type)
						{
						case 2:
							num21 = 0;
							break;
						case 23:
							num21 = 1;
							break;
						case 60:
							num21 = 2;
							s2.Width = 114;
							s2.Height = 96;
							num22 = 48;
							break;
						case 147:
							num21 = 4;
							break;
						case 109:
							num21 = 3;
							num20 += x % 3 * 3;
							s2.Height = 140;
							break;
						default:
							continue;
						}
						break;
					}
					s2.X = num20 * (s2.Width + 2);
					pos2.X -= num22;
					pos2.Y -= s2.Height - 16;
					SpriteSheet<_sheetTiles>.Draw(182 + num21, ref pos2, ref s2, tileColor);
				}
				else if (ptr14->frameX == 44)
				{
					s2.Width = 40;
					s2.Height = 40;
					if (ptr14->frameY == 220)
					{
						s2.Y = 42;
					}
					else if (ptr14->frameY == 242)
					{
						s2.Y = 84;
					}
					int num24 = 0;
					int num25 = ((y + 100 >= Main.maxTilesY) ? (Main.maxTilesY - y) : 100);
					for (int n = 0; n < num25; n++)
					{
						switch (ptr14[n + 1440].type)
						{
						case 2:
							num24 = 0;
							break;
						case 23:
							num24 = 1;
							break;
						case 60:
							num24 = 2;
							break;
						case 147:
							num24 = 4;
							break;
						case 109:
							num24 = 3;
							s2.Y += x % 3 * 126;
							break;
						default:
							continue;
						}
						break;
					}
					pos2.X -= 24f;
					pos2.Y -= 12f;
					SpriteSheet<_sheetTiles>.Draw(177 + num24, ref pos2, ref s2, tileColor);
				}
				else
				{
					if (ptr14->frameX != 66)
					{
						continue;
					}
					s2.X = 42;
					s2.Width = 40;
					s2.Height = 40;
					if (ptr14->frameY == 220)
					{
						s2.Y = 42;
					}
					else if (ptr14->frameY == 242)
					{
						s2.Y = 84;
					}
					int num26 = 0;
					int num27 = ((y + 100 >= Main.maxTilesY) ? (Main.maxTilesY - y) : 100);
					for (int num28 = 0; num28 < num27; num28++)
					{
						switch (ptr14[num28 - 1440].type)
						{
						case 2:
							num26 = 0;
							break;
						case 23:
							num26 = 1;
							break;
						case 60:
							num26 = 2;
							break;
						case 147:
							num26 = 4;
							break;
						case 109:
							num26 = 3;
							s2.Y += x % 3 * 126;
							break;
						default:
							continue;
						}
						break;
					}
					pos2.Y -= 12f;
					SpriteSheet<_sheetTiles>.Draw(177 + num26, ref pos2, ref s2, tileColor);
					continue;
				}
			}
		}
		Main.tileSolid[10] = true;
	}

	private unsafe void DrawSolidTiles()
	{
		Main.tileSolid[10] = false;
		Rectangle s = default(Rectangle);
		Vector2 pos = default(Vector2);
		int num = lastTileX;
		int num2 = lastTileY;
		int num3 = firstTileX;
		fixed (Tile* ptr = Main.tile)
		{
			do
			{
				int num4 = firstTileY;
				Tile* ptr2 = ptr + (num3 * 1440 + num4 - 1);
				do
				{
					ptr2++;
					if (ptr2->active == 0)
					{
						continue;
					}
					int type = ptr2->type;
					if (!Main.tileSolid[type])
					{
						continue;
					}
					s.X = ptr2->frameX;
					s.Y = ptr2->frameY;
					s.Width = 16;
					s.Height = ((type == 137 || type == 138) ? 18 : 16);
					pos.X = num3 * 16 - screenPosition.X + 32;
					pos.Y = num4 * 16 - screenPosition.Y + 32;
					Color newColor = lighting.GetColorUnsafe(num3, num4);
					if (player.findTreasure)
					{
						switch (type)
						{
						case 6:
						case 7:
						case 8:
						case 9:
						case 22:
						case 63:
						case 64:
						case 65:
						case 66:
						case 67:
						case 68:
						case 107:
						case 108:
						case 111:
							if (newColor.R < UI.mouseTextBrightness >> 1)
							{
								newColor.R = (byte)(UI.mouseTextBrightness >> 1);
							}
							if (newColor.G < 70)
							{
								newColor.G = 70;
							}
							if (newColor.B < 210)
							{
								newColor.B = 210;
							}
							newColor.A = UI.mouseTextBrightness;
							if (Main.rand.Next(150) == 0)
							{
								Dust* ptr3 = dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 15, 0.0, 0.0, 150, default(Color), 0.800000011920929);
								if (ptr3 != null)
								{
									ptr3->velocity.X *= 0.1f;
									ptr3->velocity.Y *= 0.1f;
									ptr3->noLight = true;
								}
							}
							break;
						}
					}
					switch (type)
					{
					case 22:
						if (Main.rand.Next(400) == 0)
						{
							dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 14);
						}
						goto default;
					case 25:
						if (Main.rand.Next(700) == 0)
						{
							dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 14);
						}
						break;
					case 23:
						if (Main.rand.Next(500) == 0)
						{
							dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 14);
						}
						break;
					case 37:
						if (Main.rand.Next(250) == 0)
						{
							Dust* ptr6 = dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 6, 0.0, 0.0, 0, default(Color), Main.rand.Next(3));
							if (ptr6 != null && ptr6->scale > 1f)
							{
								ptr6->noGravity = true;
							}
						}
						break;
					case 58:
					case 76:
						if (Main.rand.Next(250) == 0)
						{
							Dust* ptr4 = dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 6, 0.0, 0.0, 0, default(Color), Main.rand.Next(3));
							if (ptr4 != null && ptr4->scale > 1f)
							{
								ptr4->noGravity = true;
								ptr4->noLight = true;
							}
						}
						break;
					case 112:
						if (Main.rand.Next(700) == 0)
						{
							dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 14);
						}
						break;
					default:
					{
						if (Main.tileShine[type] <= 0 || (newColor.R <= 20 && newColor.B <= 20 && newColor.G <= 20))
						{
							break;
						}
						int num5 = newColor.R;
						if (newColor.G > num5)
						{
							num5 = newColor.G;
						}
						if (newColor.B > num5)
						{
							num5 = newColor.B;
						}
						num5 /= 30;
						if (Main.rand.Next(Main.tileShine[type]) < num5)
						{
							Dust* ptr5 = dustLocal.NewDust(num3 * 16, num4 * 16, 16, 16, 43, 0.0, 0.0, 254, default(Color), 0.5);
							if (ptr5 != null)
							{
								ptr5->velocity.X = 0f;
								ptr5->velocity.Y = 0f;
							}
						}
						break;
					}
					}
					if (newColor.R <= 1 && newColor.G <= 1 && newColor.B <= 1)
					{
						continue;
					}
					if (!Main.tileSolidTop[type] && (ptr2[-1].liquid > 0 || ptr2[1].liquid > 0 || ptr2[-1440].liquid > 0 || ptr2[1440].liquid > 0))
					{
						int num6 = 0;
						bool flag = false;
						bool flag2 = false;
						bool flag3 = false;
						bool flag4 = false;
						int num7 = 0;
						bool flag5 = false;
						if (ptr2[-1440].liquid > num6)
						{
							num6 = ptr2[-1440].liquid;
							flag = true;
						}
						else if (ptr2[-1440].liquid > 0)
						{
							flag = true;
						}
						if (ptr2[1440].liquid > num6)
						{
							num6 = ptr2[1440].liquid;
							flag2 = true;
						}
						else if (ptr2[1440].liquid > 0)
						{
							num6 = ptr2[1440].liquid;
							flag2 = true;
						}
						if (ptr2[-1].liquid > 0)
						{
							flag3 = true;
						}
						if (ptr2[1].liquid > 240)
						{
							flag4 = true;
						}
						if (ptr2[-1440].liquid > 0)
						{
							if (ptr2[-1440].lava != 0)
							{
								num7 = 1;
							}
							else
							{
								flag5 = true;
							}
						}
						if (ptr2[1440].liquid > 0)
						{
							if (ptr2[1440].lava != 0)
							{
								num7 = 1;
							}
							else
							{
								flag5 = true;
							}
						}
						if (ptr2[-1].liquid > 0)
						{
							if (ptr2[-1].lava != 0)
							{
								num7 = 1;
							}
							else
							{
								flag5 = true;
							}
						}
						if (ptr2[1].liquid > 0)
						{
							if (ptr2[1].lava != 0)
							{
								num7 = 1;
							}
							else
							{
								flag5 = true;
							}
						}
						if (!flag5 || num7 != 1)
						{
							Vector2 pos2 = new Vector2(num3 * 16, num4 * 16);
							Rectangle s2 = new Rectangle(0, 4, 16, 16);
							if (flag4 && (flag || flag2))
							{
								flag = true;
								flag2 = true;
							}
							if ((!flag3 || (!flag && !flag2)) && (!flag4 || !flag3))
							{
								if (flag3)
								{
									s2.Height = 4;
								}
								else if (flag4 && !flag && !flag2)
								{
									pos2.Y += 12f;
									s2.Height = 4;
								}
								else
								{
									int num8 = (int)((float)(256 - num6) * (1f / 32f)) << 1;
									pos2.Y += num8;
									s2.Height -= num8;
									if (!flag || !flag2)
									{
										s2.Width = 4;
										if (!flag)
										{
											pos2.X += 12f;
										}
									}
								}
							}
							Color c = newColor;
							if (num4 >= Main.worldSurface)
							{
								c.R >>= 1;
								c.G >>= 1;
								c.B >>= 1;
								c.A >>= 1;
								if (num7 == 1)
								{
									c.R += (byte)(c.R >> 1);
									c.G += (byte)(c.G >> 1);
									c.B += (byte)(c.B >> 1);
									c.A += (byte)(c.A >> 1);
								}
							}
							pos2.X -= screenPosition.X;
							pos2.X += 32f;
							pos2.Y -= screenPosition.Y;
							pos2.Y += 32f;
							SpriteSheet<_sheetTiles>.Draw(14 + num7, ref pos2, ref s2, c);
						}
					}
					bool flag6 = Main.tileShine2[type];
					int id = 26 + type;
					if (SMOOTH_LIGHT && type != 11 && type != 137)
					{
						if (newColor.R > 198 || (float)(int)newColor.G > 217.8f || (float)(int)newColor.B > 237.6f)
						{
							s.Width = 4;
							s.Height = 4;
							Color newColor2 = lighting.GetColorUnsafe(num3 - 1, num4 - 1);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.X += 4f;
							s.X += 4;
							s.Width = 8;
							newColor2 = lighting.GetColorUnsafe(num3, num4 - 1);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.X += 8f;
							s.X += 8;
							s.Width = 4;
							newColor2 = lighting.GetColorUnsafe(num3 + 1, num4 - 1);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.Y += 4f;
							s.Y += 4;
							s.Height = 8;
							newColor2 = lighting.GetColorUnsafe(num3 + 1, num4);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.X -= 12f;
							s.X -= 12;
							newColor2 = lighting.GetColorUnsafe(num3 - 1, num4);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.Y += 8f;
							s.Y += 8;
							s.Height = 4;
							newColor2 = lighting.GetColorUnsafe(num3 - 1, num4 + 1);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.X += 4f;
							s.X += 4;
							s.Width = 8;
							newColor2 = lighting.GetColorUnsafe(num3, num4 + 1);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.X += 8f;
							s.X += 8;
							s.Width = 4;
							newColor2 = lighting.GetColorUnsafe(num3 + 1, num4 + 1);
							newColor2.R = (byte)(newColor.R + newColor2.R >> 1);
							newColor2.G = (byte)(newColor.G + newColor2.G >> 1);
							newColor2.B = (byte)(newColor.B + newColor2.B >> 1);
							if (flag6)
							{
								shine(ref newColor2, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor2);
							pos.X -= 8f;
							pos.Y -= 8f;
							s.X -= 8;
							s.Y -= 8;
							s.Width = 8;
							s.Height = 8;
							if (flag6)
							{
								shine(ref newColor, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor);
						}
						else if (newColor.R > 38 || (float)(int)newColor.G > 41.8f || (float)(int)newColor.B > 45.600002f)
						{
							s.Width = 8;
							s.Height = 8;
							Color newColor3 = lighting.GetColorUnsafe(num3 - 1, num4 - 1);
							newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
							newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
							newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
							if (flag6)
							{
								shine(ref newColor3, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor3);
							pos.X += 8f;
							s.X += 8;
							newColor3 = lighting.GetColorUnsafe(num3 + 1, num4 - 1);
							newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
							newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
							newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
							if (flag6)
							{
								shine(ref newColor3, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor3);
							pos.Y += 8f;
							s.Y += 8;
							newColor3 = lighting.GetColorUnsafe(num3 + 1, num4 + 1);
							newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
							newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
							newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
							if (flag6)
							{
								shine(ref newColor3, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor3);
							pos.X -= 8f;
							s.X -= 8;
							newColor3 = lighting.GetColorUnsafe(num3 - 1, num4 + 1);
							newColor3.R = (byte)(newColor.R + newColor3.R >> 1);
							newColor3.G = (byte)(newColor.G + newColor3.G >> 1);
							newColor3.B = (byte)(newColor.B + newColor3.B >> 1);
							if (flag6)
							{
								shine(ref newColor3, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor3);
						}
						else
						{
							if (flag6)
							{
								shine(ref newColor, type);
							}
							SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor);
						}
					}
					else
					{
						if (SMOOTH_LIGHT && flag6)
						{
							shine(ref newColor, type);
						}
						SpriteSheet<_sheetTiles>.Draw(id, ref pos, ref s, newColor);
					}
				}
				while (++num4 < num2);
			}
			while (++num3 < num);
		}
		Main.tileSolid[10] = true;
	}

	private unsafe void DrawWater(bool bg = false)
	{
		int num = evilTiles / 7;
		if (num > 50)
		{
			num = 50;
		}
		int num2 = 256 - num;
		int num3 = 256 - (num << 1);
		int num4 = firstTileX;
		int num5 = lastTileX;
		int num6 = firstTileY;
		int num7 = lastTileY;
		if (num4 < 5)
		{
			num4 = 5;
		}
		if (num6 < 5)
		{
			num6 = 5;
		}
		if (num5 > Main.maxTilesX - 5)
		{
			num5 = Main.maxTilesX - 5;
		}
		if (num7 > Main.maxTilesY - 5)
		{
			num7 = Main.maxTilesY - 5;
		}
		Vector2 vector = default(Vector2);
		Vector2 vector2 = default(Vector2);
		Rectangle s = default(Rectangle);
		fixed (Tile* ptr = Main.tile)
		{
			do
			{
				int num8 = num6;
				Tile* ptr2 = ptr + (num4 * 1440 + num8);
				vector2.X = num4 << 4;
				do
				{
					int liquid = ptr2->liquid;
					if (liquid > 0 && (bg || ptr2->active == 0 || !Main.tileSolidNotSolidTop[ptr2->type]) && (bg || lighting.IsNotBlackUnsafe(num4, num8)))
					{
						Color colorUnsafe = lighting.GetColorUnsafe(num4, num8);
						int num9 = ((ptr2->lava == 0) ? 14 : 15);
						int num10 = (bg ? 255 : ((num9 == 15) ? 230 : 128));
						vector2.Y = num8 << 4;
						s.Width = 16;
						ptr2--;
						if (ptr2->liquid == 0)
						{
							s.Y = 0;
							s.Height = Math.Max(1, liquid >> 4);
							vector2.Y += 16 - s.Height;
						}
						else
						{
							s.Y = 4;
							s.Height = 16;
						}
						ptr2++;
						if (num9 == 15 && dustLocal.lavaBubbles < 128 && Main.hasFocus)
						{
							if (liquid > 200 && Main.rand.Next(700) == 0)
							{
								dustLocal.NewDust(num4 << 4, num8 << 4, 16, 16, 35);
							}
							else if (s.Y == 0 && Main.rand.Next(350) == 0)
							{
								Dust* ptr3 = dustLocal.NewDust(num4 << 4, (num8 << 4) + (liquid >> 4) - 8, 16, 8, 35, 0.0, 0.0, 50, default(Color), 1.5);
								if (ptr3 != null)
								{
									ptr3->velocity.X *= 1.6f;
									ptr3->velocity.Y *= 0.8f;
									ptr3->velocity.Y -= (float)Main.rand.Next(1, 7) * 0.1f;
									if (Main.rand.Next(10) == 0)
									{
										ptr3->velocity.Y *= Main.rand.Next(2, 5);
									}
									ptr3->noGravity = true;
								}
							}
						}
						colorUnsafe.R = (byte)(colorUnsafe.R * num10 >> 8);
						colorUnsafe.G = (byte)(colorUnsafe.G * num10 >> 8);
						colorUnsafe.B = (byte)(colorUnsafe.B * num10 >> 8);
						colorUnsafe.A = (byte)num10;
						if (num9 == 14)
						{
							colorUnsafe.B = (byte)(colorUnsafe.B * num3 >> 8);
						}
						else
						{
							colorUnsafe.R = (byte)(colorUnsafe.R * num2 >> 8);
						}
						if (SMOOTH_LIGHT && !bg)
						{
							Color color = colorUnsafe;
							if ((num9 == 14 && (color.R > 201 || (double)(int)color.G > 221.10000000000002 || (double)(int)color.B > 241.2)) || color.R > 226 || (double)(int)color.G > 248.60000000000002 || (double)(int)color.B > 271.2)
							{
								for (int i = 0; i < 4; i++)
								{
									int num11 = 0;
									int num12 = 0;
									int width = 8;
									int height = 8;
									Color colorUnsafe2 = lighting.GetColorUnsafe(num4, num8);
									switch (i)
									{
									case 0:
										if (lighting.Brighter(num4, num8 - 1, num4 - 1, num8))
										{
											ptr2 -= 1440;
											if (ptr2->active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4 - 1, num8);
											}
											ptr2 += 1440;
										}
										else
										{
											ptr2--;
											if (ptr2->active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4, num8 - 1);
											}
											ptr2++;
										}
										if (s.Height < 8)
										{
											height = s.Height;
										}
										break;
									case 1:
										if (lighting.Brighter(num4, num8 - 1, num4 + 1, num8))
										{
											if (ptr2[1440].active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4 + 1, num8);
											}
										}
										else
										{
											ptr2--;
											if (ptr2->active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4, num8 - 1);
											}
											ptr2++;
										}
										num11 = 8;
										if (s.Height < 8)
										{
											height = s.Height;
										}
										break;
									case 2:
										if (lighting.Brighter(num4, num8 + 1, num4 - 1, num8))
										{
											ptr2 -= 1440;
											if (ptr2->active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4 - 1, num8);
											}
											ptr2 += 1440;
										}
										else
										{
											ptr2++;
											if (ptr2->active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4, num8 + 1);
											}
											ptr2--;
										}
										num12 = 8;
										height = 8 - (16 - s.Height);
										break;
									default:
										if (lighting.Brighter(num4, num8 + 1, num4 + 1, num8))
										{
											if (ptr2[1440].active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4 + 1, num8);
											}
										}
										else
										{
											ptr2++;
											if (ptr2->active == 0)
											{
												colorUnsafe2 = lighting.GetColorUnsafe(num4, num8 + 1);
											}
											ptr2--;
										}
										num11 = 8;
										num12 = 8;
										height = 8 - (16 - s.Height);
										break;
									}
									colorUnsafe2.R = (byte)(colorUnsafe2.R * num10 + color.R >> 9);
									colorUnsafe2.G = (byte)(colorUnsafe2.G * num10 + color.G >> 9);
									colorUnsafe2.B = (byte)(colorUnsafe2.B * num10 + color.B >> 9);
									colorUnsafe2.A = (byte)num10;
									vector = vector2;
									vector.X -= screenPosition.X - num11 - 32;
									vector.Y -= screenPosition.Y - num12 - 32;
									Rectangle s2 = s;
									s2.X += num11;
									s2.Y += num12;
									s2.Width = width;
									s2.Height = height;
									SpriteSheet<_sheetTiles>.Draw(num9, ref vector, ref s2, colorUnsafe2);
								}
							}
							else
							{
								vector = vector2;
								vector.X -= screenPosition.X - 32;
								vector.Y -= screenPosition.Y - 32;
								SpriteSheet<_sheetTiles>.Draw(num9, ref vector, ref s, colorUnsafe);
							}
						}
						else
						{
							vector = vector2;
							vector.X -= screenPosition.X - 32;
							vector.Y -= screenPosition.Y - 32;
							SpriteSheet<_sheetTiles>.Draw(num9, ref vector, ref s, colorUnsafe);
						}
					}
					ptr2++;
				}
				while (++num8 < num7);
			}
			while (++num4 < num5);
		}
	}

	private void DrawGore()
	{
		Vector2 pivot = default(Vector2);
		Vector2 pos = default(Vector2);
		for (int i = 0; i < 128; i++)
		{
			if (Main.gore[i].active != 0)
			{
				int num = 256 + Main.gore[i].type;
				pivot.X = SpriteSheet<_sheetSprites>.src[num].Width >> 1;
				pivot.Y = SpriteSheet<_sheetSprites>.src[num].Height >> 1;
				pos.X = Main.gore[i].position.X + pivot.X;
				pos.Y = Main.gore[i].position.Y + pivot.Y;
				Color alpha = Main.gore[i].GetAlpha(lighting.GetColor((int)pos.X >> 4, (int)pos.Y >> 4));
				pos.X -= screenPosition.X;
				pos.Y -= screenPosition.Y;
				SpriteSheet<_sheetSprites>.Draw(num, ref pos, alpha, Main.gore[i].rotation, ref pivot, Main.gore[i].scale);
			}
		}
	}

	private unsafe void DrawNPCs(bool behindTiles = false)
	{
		bool flag = false;
		Rectangle rectangle = default(Rectangle);
		rectangle.X = screenPosition.X - 300;
		rectangle.Y = screenPosition.Y - 300;
		rectangle.Width = viewWidth + 600;
		rectangle.Height = 1140;
		Vector2 pos = default(Vector2);
		Color c = default(Color);
		for (int num = 195; num >= 0; num--)
		{
			int type = Main.npc[num].type;
			if (type <= 0 || Main.npc[num].active == 0 || Main.npc[num].behindTiles != behindTiles)
			{
				continue;
			}
			if ((type == 125 || type == 126) && !flag)
			{
				flag = true;
				for (int i = 0; i < 196; i++)
				{
					if (Main.npc[i].active == 0 || num == i || (Main.npc[i].type != 125 && Main.npc[i].type != 126))
					{
						continue;
					}
					float num2 = Main.npc[i].position.X + (float)(Main.npc[i].width >> 1);
					float num3 = Main.npc[i].position.Y + (float)(Main.npc[i].height >> 1);
					Vector2 vector = new Vector2(Main.npc[num].position.X + (float)(Main.npc[num].width >> 1), Main.npc[num].position.Y + (float)(Main.npc[num].height >> 1));
					float num4 = num2 - vector.X;
					float num5 = num3 - vector.Y;
					float rotCenter = (float)Math.Atan2(num5, num4) - 1.57f;
					bool flag2 = true;
					float num6 = num4 * num4 + num5 * num5;
					if (num6 > 4000000f)
					{
						flag2 = false;
					}
					while (flag2)
					{
						num6 = num4 * num4 + num5 * num5;
						if (num6 < 1600f)
						{
							flag2 = false;
							continue;
						}
						float num7 = (float)SpriteSheet<_sheetSprites>.src[197].Height / (float)Math.Sqrt(num6);
						num4 *= num7;
						num5 *= num7;
						vector.X += num4;
						vector.Y += num5;
						num4 = num2 - vector.X;
						num5 = num3 - vector.Y;
						pos = vector;
						pos.X -= screenPosition.X;
						pos.Y -= screenPosition.Y;
						SpriteSheet<_sheetSprites>.DrawRotated(197, ref pos, lighting.GetColor((int)vector.X >> 4, (int)vector.Y >> 4), rotCenter);
					}
				}
			}
			if (!rectangle.Intersects(Main.npc[num].aabb))
			{
				continue;
			}
			if (type == 101)
			{
				bool flag3 = true;
				Vector2 vector2 = new Vector2(Main.npc[num].position.X + (float)(Main.npc[num].width >> 1), Main.npc[num].position.Y + (float)(Main.npc[num].height >> 1));
				float num8 = Main.npc[num].ai0 * 16f + 8f - vector2.X;
				float num9 = Main.npc[num].ai1 * 16f + 8f - vector2.Y;
				float rot = (float)Math.Atan2(num9, num8) - 1.57f;
				bool flag4 = true;
				do
				{
					float num10 = 0.75f;
					int sh = 28;
					float num11 = (float)Math.Sqrt(num8 * num8 + num9 * num9);
					if (num11 < 28f * num10)
					{
						sh = (int)num11 - 40 + 28;
						flag4 = false;
					}
					num11 = 20f * num10 / num11;
					num8 *= num11;
					num9 *= num11;
					vector2.X += num8;
					vector2.Y += num9;
					num8 = Main.npc[num].ai0 * 16f + 8f - vector2.X;
					num9 = Main.npc[num].ai1 * 16f + 8f - vector2.Y;
					pos = vector2;
					pos.X -= screenPosition.X;
					pos.Y -= screenPosition.Y;
					SpriteSheet<_sheetSprites>.Draw(flag3 ? 196 : 195, ref pos, sh, lighting.GetColor((int)vector2.X >> 4, (int)vector2.Y >> 4), rot, num10);
					flag3 = !flag3;
				}
				while (flag4);
			}
			else if (Main.npc[num].aiStyle == 13)
			{
				Vector2 vector3 = new Vector2(Main.npc[num].position.X + (float)(Main.npc[num].width >> 1), Main.npc[num].position.Y + (float)(Main.npc[num].height >> 1));
				float num12 = Main.npc[num].ai0 * 16f + 8f - vector3.X;
				float num13 = Main.npc[num].ai1 * 16f + 8f - vector3.Y;
				float rotCenter2 = (float)Math.Atan2(num13, num12) - 1.57f;
				bool flag5 = true;
				do
				{
					float num14 = (float)Math.Sqrt(num12 * num12 + num13 * num13);
					if (num14 < 40f)
					{
						flag5 = false;
					}
					num14 = 28f / num14;
					num12 *= num14;
					num13 *= num14;
					vector3.X += num12;
					vector3.Y += num13;
					num12 = Main.npc[num].ai0 * 16f + 8f - vector3.X;
					num13 = Main.npc[num].ai1 * 16f + 8f - vector3.Y;
					pos = vector3;
					pos.X -= screenPosition.X;
					pos.Y -= screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated((type == 56) ? 190 : 189, ref pos, lighting.GetColor((int)vector3.X >> 4, (int)vector3.Y >> 4), rotCenter2);
				}
				while (flag5);
			}
			if (type == 36)
			{
				Vector2 vector4 = new Vector2(Main.npc[num].position.X + (float)(Main.npc[num].width >> 1) - 5f * Main.npc[num].ai0, Main.npc[num].position.Y + 20f);
				for (int j = 0; j < 2; j++)
				{
					float num15 = Main.npc[(int)Main.npc[num].ai1].position.X + (float)(Main.npc[(int)Main.npc[num].ai1].width >> 1) - vector4.X;
					float num16 = Main.npc[(int)Main.npc[num].ai1].position.Y + (float)(Main.npc[(int)Main.npc[num].ai1].height >> 1) - vector4.Y;
					float num17;
					if (j == 0)
					{
						num15 -= 200f * Main.npc[num].ai0;
						num16 += 130f;
						num17 = (float)Math.Sqrt(num15 * num15 + num16 * num16);
						num17 = 92f / num17;
					}
					else
					{
						num15 -= 50f * Main.npc[num].ai0;
						num16 += 80f;
						num17 = (float)Math.Sqrt(num15 * num15 + num16 * num16);
						num17 = 60f / num17;
					}
					vector4.X += num15 * num17;
					vector4.Y += num16 * num17;
					pos.X = vector4.X - (float)screenPosition.X;
					pos.Y = vector4.Y - (float)screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated(3, ref pos, lighting.GetColor((int)vector4.X >> 4, (int)vector4.Y >> 4), (float)Math.Atan2(num16, num15) - 1.57f);
					if (j == 0)
					{
						vector4.X += num15 * num17 * 0.5f;
						vector4.Y += num16 * num17 * 0.5f;
					}
					else if (Main.hasFocus)
					{
						vector4.X += num15 * num17 - 16f;
						vector4.Y += num16 * num17 - 6f;
						Dust* ptr = dustLocal.NewDust((int)vector4.X, (int)vector4.Y, 30, 10, 5, num15 * 0.02f, num16 * 0.02f, 0, default(Color), 2.0);
						if (ptr != null)
						{
							ptr->noGravity = true;
						}
					}
				}
			}
			if (Main.npc[num].aiStyle >= 33 && Main.npc[num].aiStyle <= 36)
			{
				Vector2 vector5 = new Vector2(Main.npc[num].position.X + (float)(Main.npc[num].width >> 1) - 5f * Main.npc[num].ai0, Main.npc[num].position.Y + 20f);
				for (int k = 0; k < 2; k++)
				{
					float num18 = Main.npc[(int)Main.npc[num].ai1].position.X + (float)(Main.npc[(int)Main.npc[num].ai1].width >> 1) - vector5.X;
					float num19 = Main.npc[(int)Main.npc[num].ai1].position.Y + (float)(Main.npc[(int)Main.npc[num].ai1].height >> 1) - vector5.Y;
					float num20;
					if (k == 0)
					{
						num18 -= 200f * Main.npc[num].ai0;
						num19 += 130f;
						num20 = (float)Math.Sqrt(num18 * num18 + num19 * num19);
						num20 = 92f / num20;
					}
					else
					{
						num18 -= 50f * Main.npc[num].ai0;
						num19 += 80f;
						num20 = (float)Math.Sqrt(num18 * num18 + num19 * num19);
						num20 = 60f / num20;
					}
					vector5.X += num18 * num20;
					vector5.Y += num19 * num20;
					pos.X = vector5.X - (float)screenPosition.X;
					pos.Y = vector5.Y - (float)screenPosition.Y;
					SpriteSheet<_sheetSprites>.DrawRotated(4, ref pos, lighting.GetColor((int)vector5.X >> 4, (int)vector5.Y >> 4), (float)Math.Atan2(num19, num18) - 1.57f);
					if (k == 0)
					{
						vector5.X += num18 * num20 * 0.5f;
						vector5.Y += num19 * num20 * 0.5f;
					}
					else if (Main.hasFocus)
					{
						vector5.X += num18 * num20 - 16f;
						vector5.Y += num19 * num20 - 6f;
						Dust* ptr2 = dustLocal.NewDust((int)vector5.X, (int)vector5.Y, 30, 10, 6, num18 * 0.02f, num19 * 0.02f, 0, default(Color), 2.5);
						if (ptr2 != null)
						{
							ptr2->noGravity = true;
						}
					}
				}
			}
			else if (Main.npc[num].aiStyle == 20)
			{
				Vector2 vector6 = new Vector2(Main.npc[num].position.X + (float)(Main.npc[num].width >> 1), Main.npc[num].position.Y + (float)(Main.npc[num].height >> 1));
				float num21 = Main.npc[num].ai1 - vector6.X;
				float num22 = Main.npc[num].ai2 - vector6.Y;
				float num23 = (float)Math.Atan2(num22, num21) - 1.57f;
				Main.npc[num].rotation = num23;
				bool flag6 = true;
				while (flag6)
				{
					int sh2 = 12;
					float num24 = (float)Math.Sqrt(num21 * num21 + num22 * num22);
					if (num24 < 20f)
					{
						sh2 = (int)num24 - 20 + 12;
						flag6 = false;
					}
					num24 = 12f / num24;
					num21 *= num24;
					num22 *= num24;
					vector6.X += num21;
					vector6.Y += num22;
					num21 = Main.npc[num].ai1 - vector6.X;
					num22 = Main.npc[num].ai2 - vector6.Y;
					pos = vector6;
					pos.X -= screenPosition.X;
					pos.Y -= screenPosition.Y;
					SpriteSheet<_sheetSprites>.Draw(198, ref pos, sh2, lighting.GetColor((int)vector6.X >> 4, (int)vector6.Y >> 4), num23);
				}
				pos.X = Main.npc[num].ai1 - (float)screenPosition.X;
				pos.Y = Main.npc[num].ai2 - (float)screenPosition.Y;
				SpriteSheet<_sheetSprites>.DrawRotated(1474, ref pos, lighting.GetColor((int)Main.npc[num].ai1 >> 4, (int)Main.npc[num].ai2 >> 4), num23 - 0.75f);
			}
			Color newColor = lighting.GetColor(Main.npc[num].aabb.X + (Main.npc[num].width >> 1) >> 4, Main.npc[num].aabb.Y + (Main.npc[num].height >> 1) >> 4);
			if (behindTiles && type != 113 && type != 114)
			{
				int num25 = Main.npc[num].aabb.X - 8 >> 4;
				int num26 = Main.npc[num].aabb.X + Main.npc[num].width + 8 >> 4;
				int num27 = Main.npc[num].aabb.Y - 8 >> 4;
				int num28 = Main.npc[num].aabb.Y + Main.npc[num].height + 8 >> 4;
				for (int l = num25; l <= num26; l++)
				{
					int num29 = num27;
					while (num29 <= num28)
					{
						if (lighting.Brightness(l, num29) != 0f)
						{
							num29++;
							continue;
						}
						goto IL_101b;
					}
					continue;
					IL_101b:
					newColor.PackedValue = 4278190080u;
					break;
				}
			}
			if (Main.npc[num].poisoned)
			{
				Player.buffColor(ref newColor, 0.65, 1.0, 0.75);
			}
			if (player.detectCreature && Main.npc[num].lifeMax > 1)
			{
				if (newColor.R < 150)
				{
					newColor.A = UI.mouseTextBrightness;
					if (newColor.R < 50)
					{
						newColor.R = 50;
					}
				}
				if (newColor.G < 200)
				{
					newColor.G = 200;
				}
				if (newColor.B < 100)
				{
					newColor.B = 100;
				}
				if (Main.hasFocus && Main.rand.Next(52) == 0)
				{
					Dust* ptr3 = dustLocal.NewDust(Main.npc[num].aabb.X, Main.npc[num].aabb.Y, Main.npc[num].width, Main.npc[num].height, 15, 0.0, 0.0, 150, default(Color), 0.800000011920929);
					if (ptr3 != null)
					{
						ptr3->velocity.X *= 0.1f;
						ptr3->velocity.Y *= 0.1f;
						ptr3->noLight = true;
					}
				}
			}
			switch (type)
			{
			case 50:
			{
				Vector2 vector8 = default(Vector2);
				vector8.Y = 0f - Main.npc[num].velocity.Y;
				vector8.X = Main.npc[num].velocity.X * -2f;
				float rotCenter4 = Main.npc[num].velocity.X * 0.05f;
				if (Main.npc[num].frameY == 120)
				{
					vector8.Y += 2f;
				}
				else if (Main.npc[num].frameY == 360)
				{
					vector8.Y -= 2f;
				}
				else if (Main.npc[num].frameY == 480)
				{
					vector8.Y -= 6f;
				}
				pos.X = Main.npc[num].position.X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1) + vector8.X;
				pos.Y = Main.npc[num].position.Y - (float)screenPosition.Y + (float)(Main.npc[num].height >> 1) + vector8.Y;
				SpriteSheet<_sheetSprites>.DrawRotated(1088, ref pos, newColor, rotCenter4);
				break;
			}
			case 71:
			{
				Vector2 vector7 = default(Vector2);
				vector7.Y = Main.npc[num].velocity.Y * -0.3f;
				vector7.X = Main.npc[num].velocity.X * -0.6f;
				float rotCenter3 = Main.npc[num].velocity.X * 0.09f;
				if (Main.npc[num].frameY == 120)
				{
					vector7.Y += 2f;
				}
				else if (Main.npc[num].frameY == 360)
				{
					vector7.Y -= 2f;
				}
				else if (Main.npc[num].frameY == 480)
				{
					vector7.Y -= 6f;
				}
				pos.X = Main.npc[num].position.X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1) + vector7.X;
				pos.Y = Main.npc[num].position.Y - (float)screenPosition.Y + (float)(Main.npc[num].height >> 1) + vector7.Y;
				SpriteSheet<_sheetSprites>.DrawRotated(778, ref pos, newColor, rotCenter3);
				break;
			}
			case 69:
			case 147:
			{
				pos.X = Main.npc[num].position.X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1);
				pos.Y = Main.npc[num].position.Y - (float)screenPosition.Y + (float)(int)Main.npc[num].height + 14f;
				int id = ((type == 69) ? 2 : 0);
				SpriteSheet<_sheetSprites>.DrawRotated(id, ref pos, newColor, (0f - Main.npc[num].rotation) * 0.3f);
				break;
			}
			}
			float num30 = 0f;
			float num31 = 0f;
			int width = SpriteSheet<_sheetSprites>.src[1088 + type].Width;
			Vector2 pivot = default(Vector2);
			pivot.X = width >> 1;
			pivot.Y = Main.npc[num].frameHeight >> 1;
			switch (type)
			{
			case 108:
			case 124:
				num30 = 2f;
				break;
			case 4:
				pivot.Y = 107f;
				break;
			case 166:
				pivot.Y *= 0.5f;
				break;
			case 6:
			case 13:
			case 14:
			case 15:
			case 39:
			case 40:
			case 41:
				num31 = 26f;
				break;
			case 10:
			case 11:
			case 12:
				num31 = 8f;
				break;
			case 48:
				num31 = 32f;
				break;
			case 49:
			case 51:
				num31 = 4f;
				break;
			case 60:
				num31 = 10f;
				break;
			case 62:
			case 65:
			case 66:
				num31 = 14f;
				break;
			case 63:
			case 64:
			case 103:
				num31 = 4f;
				pivot.Y += 4f;
				break;
			case 69:
				num31 = 4f;
				pivot.Y += 8f;
				break;
			case 70:
				num31 = -4f;
				break;
			case 72:
				num31 = -2f;
				break;
			case 83:
			case 84:
				num31 = 20f;
				break;
			case 7:
			case 8:
			case 9:
			case 95:
			case 96:
			case 97:
			case 98:
			case 99:
			case 100:
				num31 = 13f;
				break;
			case 87:
			case 88:
			case 89:
			case 90:
			case 91:
			case 92:
			case 159:
			case 160:
			case 161:
			case 162:
			case 163:
			case 164:
				num31 = 56f;
				break;
			case 94:
				num31 = 14f;
				break;
			case 125:
			case 126:
				pivot = new Vector2(55f, 107f);
				num31 = 30f;
				break;
			case 134:
			case 135:
			case 136:
				num31 = 30f;
				break;
			}
			num31 *= Main.npc[num].scale;
			pos = new Vector2(Main.npc[num].position.X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1) - (float)width * Main.npc[num].scale * 0.5f + pivot.X * Main.npc[num].scale, Main.npc[num].position.Y - (float)screenPosition.Y + (float)(int)Main.npc[num].height - (float)Main.npc[num].frameHeight * Main.npc[num].scale + 4f + pivot.Y * Main.npc[num].scale + num31 + num30);
			if (Main.npc[num].aiStyle == 10 || type == 72)
			{
				newColor = Color.White;
			}
			SpriteEffects e = ((Main.npc[num].spriteDirection == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
			switch (type)
			{
			case 83:
			case 84:
			case 151:
				SpriteSheet<_sheetSprites>.Draw(1088 + type, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, Color.White, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				continue;
			default:
				if (type < 159 || type > 164)
				{
					break;
				}
				goto case 87;
			case 87:
			case 88:
			case 89:
			case 90:
			case 91:
			case 92:
			{
				c = Main.npc[num].GetAlpha(newColor);
				byte b = (byte)((time.tileColor.R + time.tileColor.G + time.tileColor.B) / 3);
				if (c.R < b)
				{
					c.R = b;
				}
				if (c.G < b)
				{
					c.G = b;
				}
				if (c.B < b)
				{
					c.B = b;
				}
				SpriteSheet<_sheetSprites>.Draw(1088 + type, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				continue;
			}
			}
			switch (type)
			{
			case 94:
			{
				for (int m = 1; m < 6; m += 2)
				{
					c = Main.npc[num].GetAlpha(newColor);
					c.R = (byte)(c.R * (10 - m) / 15);
					c.G = (byte)(c.G * (10 - m) / 15);
					c.B = (byte)(c.B * (10 - m) / 15);
					c.A = (byte)(c.A * (10 - m) / 15);
					pos = new Vector2(Main.npc[num].oldPos[m].X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1) - (float)width * Main.npc[num].scale * 0.5f + pivot.X * Main.npc[num].scale, Main.npc[num].oldPos[m].Y - (float)screenPosition.Y + (float)(int)Main.npc[num].height - (float)Main.npc[num].frameHeight * Main.npc[num].scale + 4f + pivot.Y * Main.npc[num].scale + num31);
					SpriteSheet<_sheetSprites>.Draw(1088 + type, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				}
				break;
			}
			case 125:
			case 126:
			case 127:
			case 128:
			case 129:
			case 130:
			case 131:
			case 139:
			case 140:
			{
				for (int num32 = 9; num32 >= 0; num32 -= 2)
				{
					c = Main.npc[num].GetAlpha(newColor);
					c.R = (byte)(c.R * (10 - num32) / 20);
					c.G = (byte)(c.G * (10 - num32) / 20);
					c.B = (byte)(c.B * (10 - num32) / 20);
					c.A = (byte)(c.A * (10 - num32) / 20);
					pos = new Vector2(Main.npc[num].oldPos[num32].X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1) - (float)width * Main.npc[num].scale * 0.5f + pivot.X * Main.npc[num].scale, Main.npc[num].oldPos[num32].Y - (float)screenPosition.Y + (float)(int)Main.npc[num].height - (float)Main.npc[num].frameHeight * Main.npc[num].scale + 4f + pivot.Y * Main.npc[num].scale + num31);
					SpriteSheet<_sheetSprites>.Draw(1088 + type, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				}
				break;
			}
			}
			SpriteSheet<_sheetSprites>.Draw(1088 + type, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, Main.npc[num].GetAlpha(newColor), Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
			if (Main.npc[num].color.PackedValue != 0)
			{
				SpriteSheet<_sheetSprites>.Draw(1088 + type, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, Main.npc[num].GetColor(newColor), Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
			}
			if (Main.npc[num].confused)
			{
				Vector2 pos2 = pos;
				pos2.Y -= SpriteSheet<_sheetSprites>.src[203].Height + 20;
				c.PackedValue = 1190853370u;
				SpriteSheet<_sheetSprites>.Draw(203, ref pos2, c, Main.npc[num].velocity.X * -0.05f, UI.essScale + 0.2f);
			}
			switch (type)
			{
			case 125:
				c.PackedValue = 16777215u;
				SpriteSheet<_sheetSprites>.Draw(220, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				continue;
			case 139:
				c.PackedValue = 16777215u;
				SpriteSheet<_sheetSprites>.Draw(1349, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				continue;
			case 127:
				c.PackedValue = 13158600u;
				SpriteSheet<_sheetSprites>.Draw(137, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				continue;
			case 131:
				c.PackedValue = 13158600u;
				SpriteSheet<_sheetSprites>.Draw(138, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				continue;
			case 120:
			case 154:
			{
				for (int n = 1; n < Main.npc[num].oldPos.Length; n++)
				{
					c.R = (byte)(150 * (10 - n) / 15);
					c.G = (byte)(100 * (10 - n) / 15);
					c.B = (byte)(150 * (10 - n) / 15);
					c.A = (byte)(50 * (10 - n) / 15);
					pos = new Vector2(Main.npc[num].oldPos[n].X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1) - (float)width * Main.npc[num].scale * 0.5f + pivot.X * Main.npc[num].scale, Main.npc[num].oldPos[n].Y - (float)screenPosition.Y + (float)(int)Main.npc[num].height - (float)Main.npc[num].frameHeight * Main.npc[num].scale + 4f + pivot.Y * Main.npc[num].scale + num31);
					SpriteSheet<_sheetSprites>.Draw(199, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				}
				continue;
			}
			case 134:
			case 135:
			case 136:
				if (newColor.PackedValue != 4278190080u)
				{
					c.PackedValue = 16777215u;
					SpriteSheet<_sheetSprites>.Draw(214 + type - 134, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				}
				continue;
			}
			switch (type)
			{
			case 137:
			case 138:
			{
				for (int num34 = 1; num34 < Main.npc[num].oldPos.Length; num34++)
				{
					c.R = (byte)(150 * (10 - num34) / 15);
					c.G = (byte)(100 * (10 - num34) / 15);
					c.B = (byte)(150 * (10 - num34) / 15);
					c.A = (byte)(50 * (10 - num34) / 15);
					pos = new Vector2(Main.npc[num].oldPos[num34].X - (float)screenPosition.X + (float)(Main.npc[num].width >> 1) - (float)width * Main.npc[num].scale * 0.5f + pivot.X * Main.npc[num].scale, Main.npc[num].oldPos[num34].Y - (float)screenPosition.Y + (float)(int)Main.npc[num].height - (float)Main.npc[num].frameHeight * Main.npc[num].scale + 4f + pivot.Y * Main.npc[num].scale + num31);
					SpriteSheet<_sheetSprites>.Draw(1088 + type, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, c, Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				}
				break;
			}
			case 82:
			{
				SpriteSheet<_sheetSprites>.Draw(1488, ref pos, Main.npc[num].frameY, Main.npc[num].frameHeight, new Color(255, 255, 255, 255), Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				for (int num33 = 1; num33 < 10; num33++)
				{
					Vector2 pos3 = pos - Main.npc[num].velocity * ((float)num33 * 0.5f);
					SpriteSheet<_sheetSprites>.Draw(1488, ref pos3, Main.npc[num].frameY, Main.npc[num].frameHeight, new Color(110 - num33 * 10, 110 - num33 * 10, 110 - num33 * 10, 110 - num33 * 10), Main.npc[num].rotation, ref pivot, Main.npc[num].scale, e);
				}
				break;
			}
			}
		}
	}

	private void DrawWoF()
	{
		Vector2 pos = default(Vector2);
		if (NPC.wof < 0 || !player.horrified)
		{
			return;
		}
		float num = Main.npc[NPC.wof].position.X + (float)(Main.npc[NPC.wof].width >> 1);
		float num2 = Main.npc[NPC.wof].position.Y + (float)(Main.npc[NPC.wof].height >> 1);
		for (int i = 0; i < 8; i++)
		{
			if (Main.player[i].active == 0 || !Main.player[i].tongued || Main.player[i].dead)
			{
				continue;
			}
			Vector2 vector = new Vector2(Main.player[i].position.X + 10f, Main.player[i].position.Y + 21f);
			float num3 = num - vector.X;
			float num4 = num2 - vector.Y;
			float rotCenter = (float)Math.Atan2(num4, num3) - 1.57f;
			bool flag = true;
			do
			{
				float num5 = num3 * num3 + num4 * num4;
				if (num5 < 1600f)
				{
					flag = false;
					continue;
				}
				num5 = (float)SpriteSheet<_sheetSprites>.src[197].Height / (float)Math.Sqrt(num5);
				num3 *= num5;
				num4 *= num5;
				vector.X += num3;
				vector.Y += num4;
				num3 = num - vector.X;
				num4 = num2 - vector.Y;
				pos = vector;
				pos.X -= screenPosition.X;
				pos.Y -= screenPosition.Y;
				SpriteSheet<_sheetSprites>.DrawRotated(197, ref pos, lighting.GetColor((int)vector.X >> 4, (int)vector.Y >> 4), rotCenter);
			}
			while (flag);
		}
		float num6 = NPC.wofB - NPC.wofT;
		for (int j = 0; j < 196; j++)
		{
			if (Main.npc[j].active == 0 || Main.npc[j].aiStyle != 29)
			{
				continue;
			}
			bool flag2 = Main.npc[j].frameCounter > 7f;
			num2 = (float)NPC.wofT + num6 * Main.npc[j].ai0;
			Vector2 vector2 = new Vector2(Main.npc[j].position.X + (float)(Main.npc[j].width >> 1), Main.npc[j].position.Y + (float)(Main.npc[j].height >> 1));
			float num7 = num - vector2.X;
			float num8 = num2 - vector2.Y;
			float rotCenter2 = (float)Math.Atan2(num8, num7) - 1.57f;
			bool flag3 = true;
			while (flag3)
			{
				SpriteEffects se = SpriteEffects.None;
				if (flag2)
				{
					se = SpriteEffects.FlipHorizontally;
					flag2 = false;
				}
				else
				{
					flag2 = true;
				}
				float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
				if (num9 < 40f)
				{
					flag3 = false;
				}
				num9 = 28f / num9;
				num7 *= num9;
				num8 *= num9;
				vector2.X += num7;
				vector2.Y += num8;
				num7 = num - vector2.X;
				num8 = num2 - vector2.Y;
				pos = vector2;
				pos.X -= screenPosition.X;
				pos.Y -= screenPosition.Y;
				SpriteSheet<_sheetSprites>.Draw(197, ref pos, lighting.GetColor((int)vector2.X >> 4, (int)vector2.Y >> 4), rotCenter2, se);
			}
		}
		int num10 = 140;
		float num11 = NPC.wofT;
		float num12 = NPC.wofB;
		num12 = screenPosition.Y + 540;
		float num13 = (int)((num11 - (float)screenPosition.Y) / (float)num10) + 1;
		num13 *= (float)num10;
		if (num13 > 0f)
		{
			num11 -= num13;
		}
		float num14 = num11;
		float num15 = Main.npc[NPC.wof].position.X;
		float num16 = num12 - num11;
		SpriteEffects e = SpriteEffects.None;
		if (Main.npc[NPC.wof].spriteDirection == 1)
		{
			e = SpriteEffects.FlipHorizontally;
		}
		if (Main.npc[NPC.wof].direction > 0)
		{
			num15 -= 80f;
		}
		int num17 = 0;
		if (++NPC.wofF > 12)
		{
			num17 = 280;
			if (NPC.wofF > 17)
			{
				NPC.wofF = 0;
			}
		}
		else if (NPC.wofF > 6)
		{
			num17 = 140;
		}
		do
		{
			num16 = num12 - num14;
			if (num16 > (float)num10)
			{
				num16 = num10;
			}
			int num18 = 0;
			int width = SpriteSheet<_sheetSprites>.src[1483].Width;
			do
			{
				int x = (int)num15 + (width >> 1) >> 4;
				int y = (int)num14 + num18 >> 4;
				pos.X = num15 - (float)screenPosition.X;
				pos.Y = num14 + (float)num18 - (float)screenPosition.Y;
				SpriteSheet<_sheetSprites>.Draw(1483, ref pos, num17 + num18, 16, lighting.GetColor(x, y), e);
				num18 += 16;
			}
			while ((float)num18 < num16);
			num14 += (float)num10;
		}
		while (num14 < num12);
	}

	public void DrawNPCHouse()
	{
		for (int i = 0; i < 196; i++)
		{
			if (Main.npc[i].active == 0 || !Main.npc[i].townNPC || Main.npc[i].homeless || Main.npc[i].homeTileX <= 0 || Main.npc[i].homeTileY <= 0 || Main.npc[i].type == 37)
			{
				continue;
			}
			int homeTileX = Main.npc[i].homeTileX;
			int num = Main.npc[i].homeTileY - 1;
			while (Main.tile[homeTileX, num].active == 0 || !Main.tileSolid[Main.tile[homeTileX, num].type])
			{
				num--;
				if (num < 10)
				{
					break;
				}
			}
			int num2 = 18;
			if (Main.tile[homeTileX, num].type == 19)
			{
				num2 -= 8;
			}
			num++;
			Color color = lighting.GetColor(homeTileX, num);
			SpriteSheet<_sheetSprites>.Draw(439, (homeTileX << 4) - screenPosition.X + 8 - 16, (num << 4) - screenPosition.Y + num2 - 20, color);
			int num3 = Main.npc[i].getHeadTextureId() + 1255;
			float scaleCenter = 1f;
			float num4 = SpriteSheet<_sheetSprites>.src[num3].Height;
			if ((float)SpriteSheet<_sheetSprites>.src[num3].Width > num4)
			{
				num4 = SpriteSheet<_sheetSprites>.src[num3].Width;
			}
			if (num4 > 24f)
			{
				scaleCenter = 24f / num4;
			}
			SpriteSheet<_sheetSprites>.DrawScaled(num3, (homeTileX << 4) - screenPosition.X + 8, (num << 4) - screenPosition.Y + num2 + 2, scaleCenter, color);
		}
	}

	public void DrawGrid()
	{
		int num = (screenPosition.X & -16) - screenPosition.X;
		int num2 = (screenPosition.Y & -16) - screenPosition.Y;
		int num3 = viewWidth >> 5;
		Color c = new Color(100, 100, 100, 15);
		for (int i = 0; i <= num3; i++)
		{
			for (int j = 0; j <= 16; j++)
			{
				SpriteSheet<_sheetSprites>.Draw(431, (i << 6) + num, (j << 6) + num2, c);
			}
		}
	}

	public unsafe void spawnSnow()
	{
		if (snowTiles <= 1024 || player.aabb.Y >= Main.worldSurfacePixels || dustLocal.snowDust >= 32)
		{
			return;
		}
		int upperBound = 4096 / snowTiles;
		if (Main.rand.Next(upperBound) == 0)
		{
			int num = Main.rand.Next(viewWidth + 32) - 16;
			int num2 = screenPosition.Y;
			if (num < 0 || num > 960)
			{
				num2 += Main.rand.Next(270) + 54;
			}
			num += screenPosition.X;
			Dust* ptr = dustLocal.NewDust(num, num2, 10, 10, 76);
			if (ptr != null)
			{
				ptr->velocity.X = Cloud.windSpeed + (float)Main.rand.Next(-10, 10) * 0.1f;
				ptr->velocity.Y = 3f + (float)Main.rand.Next(30) * 0.1f * ptr->scale;
			}
		}
	}
}
