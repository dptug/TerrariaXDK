using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria;

public sealed class MiniMap
{
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

	private float mapScale = 1f;

	public volatile bool isThreadDone;

	private short mapDestH = 486;

	private int alpha;

	private Texture2D[] mapTexture;

	private static readonly uint[] WallColors = new uint[32]
	{
		0u, 4282532418u, 4283972910u, 4281410885u, 4283051548u, 4282729797u, 4283432960u, 4278190176u, 4278210560u, 4282908751u,
		4286007047u, 4286743170u, 4282325255u, 4282320647u, 4278190176u, 4278211840u, 4283972910u, 4278190147u, 4278204160u, 4281532471u,
		4278190176u, 4279378988u, 4285621091u, 4283318338u, 4282396723u, 4278919998u, 4282145594u, 4282001693u, 4283520101u, 4289331200u,
		4278233600u, 4288256443u
	};

	private static readonly uint[] TileColors = new uint[150]
	{
		4287720015u, 4286611584u, 4280080478u, 4279067940u, 4294786563u, 4284696113u, 4285225294u, 4291188253u, 4290356247u, 4292468703u,
		4278255602u, 4278255602u, 4294901760u, 4278255602u, 4278255602u, 4278255602u, 4278255602u, 4278255602u, 4278255602u, 4285217304u,
		4279067940u, 4292720640u, 4284637095u, 4287465951u, 4287465951u, 4283124354u, 4287627519u, 4291100436u, 4287375142u, 4278255602u,
		4285024564u, 4278190080u, 4286210447u, 4294786563u, 4294786563u, 4294786563u, 4294786563u, 4292845449u, 4287664272u, 4289855743u,
		4289485645u, 4283716760u, 4293890123u, 4281968721u, 4289855743u, 4294956308u, 4293256677u, 4294924544u, 4285361517u, 4281044991u,
		4278255602u, 4294967295u, 4279067940u, 4294957624u, 1090519039u, 4294946398u, 4283912621u, 4282664012u, 4284883490u, 4284236873u,
		4287616797u, 4287616797u, 4287286812u, 4280976122u, 4280976122u, 4280976122u, 4280976122u, 4280976122u, 4280976122u, 4284362807u,
		4284317695u, 4289834627u, 4288057198u, 4279067940u, 4279067940u, 4289855743u, 4291166237u, 4292149264u, 4278255602u, 4278255602u,
		4278232320u, 4293219136u, 4294932480u, 4294932480u, 4294932480u, 4290822336u, 4294902015u, 4278255602u, 4278255602u, 4278255602u,
		4278255602u, 4278255602u, 4278255602u, 4278255602u, 4278255602u, 4278255602u, 4278255602u, 4294902015u, 4294902015u, 4294901968u,
		4294902015u, 4294902015u, 4294902015u, 4294902015u, 4294902015u, 4278255602u, 4278255602u, 4278931599u, 4284197289u, 4283351523u,
		4280194632u, 4286585396u, 4284965498u, 4280194632u, 4286536773u, 4281499553u, 4292199621u, 4290096318u, 4292199621u, 4282335049u,
		4288051837u, 4280645291u, 4287741813u, 4284044115u, 4284236854u, 4286686719u, 4292598747u, 4285051848u, 4287653968u, 4278208889u,
		4289045925u, 4279900698u, 4291363587u, 4287172626u, 4288065159u, 4294799986u, 4291608768u, 4287401100u, 4284703587u, 4288242499u,
		4286084531u, 4289536803u, 4291363587u, 4291363587u, 4291363587u, 4294901760u, 4278255360u, 4293848831u, 4291611886u, 4294901760u
	};

	public static void onStartGame()
	{
		width = (short)(Main.maxTilesX - 68);
		height = (short)(Main.maxTilesY - 68);
		texWidth = (short)(width / 4);
	}

	public void UpdateMap(UI ui)
	{
		int num = ui.view.SAFE_AREA_OFFSET_L + ((UI.numActiveViews > 1) ? 340 : 290);
		int num2 = ui.view.viewWidth - ui.view.SAFE_AREA_OFFSET_R - num;
		_ = Main.maxTilesX;
		_ = Main.maxTilesY;
		if (ui.IsAlternateLeftButtonDown())
		{
			mapX -= 8;
		}
		if (ui.IsAlternateRightButtonDown())
		{
			mapX += 8;
		}
		if (ui.IsAlternateUpButtonDown())
		{
			mapY -= 8;
		}
		if (ui.IsAlternateDownButtonDown())
		{
			mapY += 8;
		}
		float left = ui.gpState.Triggers.Left;
		if (left > 0.125f)
		{
			mapScale -= 0.05f * left;
			if (mapScale < 1f)
			{
				mapScale = 1f;
			}
		}
		left = ui.gpState.Triggers.Right;
		if (left > 0.125f)
		{
			mapScale += 0.05f * left;
			if (mapScale > 4f)
			{
				mapScale = 4f;
			}
		}
		int num3 = (int)((double)((float)num2 * (1f / mapScale - 1f)) * 0.5);
		int num4 = width - num2 - num3;
		if (mapX < num3)
		{
			mapX = (short)num3;
		}
		else if (mapX > num4)
		{
			mapX = (short)num4;
		}
		num3 = (int)((double)((float)mapDestH * (1f / mapScale - 1f)) * 0.5);
		num4 = height - mapDestH - num3;
		if (mapY < num3)
		{
			mapY = (short)num3;
		}
		else if (mapY > num4)
		{
			mapY = (short)num4;
		}
	}

	public void CreateMap(UI ui)
	{
		if (isThreadDone)
		{
			DestroyMap();
		}
		alpha = 0;
		mapTexture = new Texture2D[4];
		for (int num = 3; num >= 0; num--)
		{
			mapTexture[num] = new Texture2D(WorldView.graphicsDevice, texWidth, height, mipMap: false, SurfaceFormat.Bgr565);
		}
		Thread thread = new Thread(CreateMapThread);
		thread.IsBackground = true;
		thread.Start(ui);
	}

	public unsafe void CreateMapThread(object arg)
	{
		Thread.CurrentThread.SetProcessorAffinity(new int[1] { 4 });
		UI uI = (UI)arg;
		int num = texWidth * height;
		ushort[] array = new ushort[num];
		sbyte[] array2 = new sbyte[height];
		sbyte[] array3 = new sbyte[width];
		Player player = uI.player;
		for (int num2 = 3; num2 >= 0; num2--)
		{
			fixed (ushort* ptr = &array[num - 1])
			{
				ushort* ptr2 = ptr;
				for (int num3 = height - 1; num3 >= 0; num3--)
				{
					int num4 = texWidth - 1;
					int num5 = num4 + num2 * texWidth;
					while (num4 >= 0)
					{
						fixed (Tile* ptr3 = &Main.tile[num5 + 34, num3 + 34])
						{
							if ((ptr3->flags & Tile.Flags.VISITED) == 0)
							{
								if (array2[num3] > 0)
								{
									array2[num3]--;
								}
								if (array3[num5] > 0)
								{
									array3[num5]--;
								}
							}
							else
							{
								if (array2[num3] < 4)
								{
									array2[num3]++;
								}
								if (array3[num5] < 4)
								{
									array3[num5]++;
								}
							}
							if (array2[num3] <= 0 && array3[num5] <= 0)
							{
								*ptr2 = 0;
								goto IL_035c;
							}
							int num6 = ((array2[num3] < array3[num5]) ? ((array2[num3] + 1) * 4 + array3[num5] * array3[num5]) : ((array2[num3] <= array3[num5]) ? (array2[num3] * array2[num3] + array3[num5] * array3[num5]) : (array2[num3] * array2[num3] + (array3[num5] + 1) * 4)));
							uint num7;
							uint num8;
							uint num9;
							uint num10;
							if (ptr3->active != 0)
							{
								num7 = TileColors[ptr3->type];
							}
							else
							{
								int wall = ptr3->wall;
								if (wall == 0)
								{
									if (num3 < Main.worldSurface)
									{
										num8 = (uint)((num3 >> 1) * uI.view.time.bgColor.R / Main.worldSurface);
										num9 = (uint)(num3 * uI.view.time.bgColor.G / (int)((float)Main.worldSurface * 1.2f));
										num10 = (uint)((num3 << 1) * uI.view.time.bgColor.B / Main.worldSurface);
										if (num10 > 255)
										{
											num10 = 255u;
										}
									}
									else if (num3 < Main.rockLayer)
									{
										num8 = 84u;
										num9 = 57u;
										num10 = 42u;
									}
									else if (num3 >= Main.maxTilesY - 200)
									{
										num8 = 51u;
										num9 = 0u;
										num10 = 0u;
									}
									else
									{
										num8 = 72u;
										num9 = 64u;
										num10 = 57u;
									}
									goto IL_02c8;
								}
								num7 = WallColors[wall];
							}
							num10 = num7 & 0xFFu;
							num9 = (num7 >> 8) & 0xFFu;
							num8 = (num7 >> 16) & 0xFFu;
							goto IL_02c8;
							IL_02c8:
							uint liquid = ptr3->liquid;
							if (liquid != 0)
							{
								if (ptr3->lava == 32)
								{
									num8 = (num8 * (255 - liquid) >> 8) + liquid;
									num10 >>= 1;
								}
								else
								{
									num8 >>= 1;
									num10 = (num10 * (255 - liquid) >> 8) + liquid;
								}
								num9 >>= 1;
							}
							if (num6 < 32)
							{
								num8 = (uint)(num8 * num6) >> 5;
								num9 = (uint)(num9 * num6) >> 5;
								num10 = (uint)(num10 * num6) >> 5;
							}
							*ptr2 = (ushort)((num8 >> 3 << 11) | (num9 >> 2 << 5) | (num10 >> 3));
							goto IL_035c;
							IL_035c:
							ptr2--;
						}
						num4--;
						num5--;
					}
				}
			}
			mapTexture[num2].SetData(array);
		}
		int num11 = uI.view.SAFE_AREA_OFFSET_L + ((UI.numActiveViews > 1) ? 340 : 290);
		int num12 = uI.view.viewWidth - uI.view.SAFE_AREA_OFFSET_R - num11;
		int num13 = width - num12;
		int num14 = height - mapDestH;
		mapX = (short)((player.aabb.X >> 4) - 34 - (num12 >> 1));
		if (mapX < 0)
		{
			mapX = 0;
		}
		else if (mapX > num13)
		{
			mapX = (short)num13;
		}
		mapY = (short)((player.aabb.Y >> 4) - 34 - (mapDestH >> 1));
		if (mapY < 0)
		{
			mapY = 0;
		}
		else if (mapY > num14)
		{
			mapY = (short)num14;
		}
		isThreadDone = true;
	}

	public void DestroyMap()
	{
		isThreadDone = false;
		if (mapTexture != null)
		{
			for (int i = 0; i < 4; i++)
			{
				mapTexture[i].Dispose();
				mapTexture[i] = null;
			}
			mapTexture = null;
		}
	}

	public void DrawMap(WorldView view)
	{
		int num = view.SAFE_AREA_OFFSET_L + ((UI.numActiveViews > 1) ? 340 : 290);
		int sAFE_AREA_OFFSET_T = view.SAFE_AREA_OFFSET_T;
		mapDestH = (short)(540 - view.SAFE_AREA_OFFSET_T - view.SAFE_AREA_OFFSET_B - 36);
		int num2 = view.viewWidth - view.SAFE_AREA_OFFSET_R - num;
		if (!isThreadDone)
		{
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, view.screenProjection);
			SpriteSheet<_sheetSprites>.Draw(1012, num + (num2 >> 1), sAFE_AREA_OFFSET_T + (mapDestH >> 1), Color.White, (float)((double)Main.frameCounter * (Math.PI / 30.0)), 1f);
			return;
		}
		alpha += 16;
		if (alpha > 255)
		{
			alpha = 255;
		}
		int num3 = num + (num2 >> 1);
		int num4 = sAFE_AREA_OFFSET_T + (mapDestH >> 1);
		Matrix view2 = Matrix.CreateTranslation(-num3, -num4, 0f) * Matrix.CreateScale(mapScale, mapScale, 1f) * Matrix.CreateTranslation(num3, num4, 0f);
		view.screenProjection.View = view2;
		Rectangle scissorRectangle = default(Rectangle);
		if (view.isFullScreen())
		{
			scissorRectangle.X = num;
			scissorRectangle.Y = sAFE_AREA_OFFSET_T;
			scissorRectangle.Width = num2;
			scissorRectangle.Height = mapDestH;
		}
		else
		{
			scissorRectangle.X = (num >> 1) + view.activeViewport.X;
			scissorRectangle.Y = (sAFE_AREA_OFFSET_T >> 1) + view.activeViewport.Y;
			scissorRectangle.Width = num2 >> 1;
			scissorRectangle.Height = mapDestH >> 1;
		}
		WorldView.graphicsDevice.ScissorRectangle = scissorRectangle;
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, WorldView.scissorTest, view.screenProjection);
		int num5 = mapX / texWidth;
		int num6 = (mapX + num2 - 1) / texWidth;
		if (num6 >= mapTexture.Length)
		{
			num6 = mapTexture.Length - 1;
		}
		Vector2 vector = new Vector2(num, sAFE_AREA_OFFSET_T);
		Rectangle rectangle = default(Rectangle);
		rectangle.X = mapX - num5 * texWidth;
		rectangle.Y = mapY;
		rectangle.Width = Math.Min(num2, texWidth - rectangle.X);
		rectangle.Height = mapDestH;
		Color color = new Color(alpha, alpha, alpha, alpha);
		for (int i = num5; i <= num6; i++)
		{
			Main.spriteBatch.Draw(mapTexture[i], vector, (Rectangle?)rectangle, color);
			vector.X += rectangle.Width;
			rectangle.X = 0;
			rectangle.Width = texWidth;
		}
		switch (Main.magmaBGFrame)
		{
		case 0:
			rectangle.X = 659;
			rectangle.Y = 10;
			break;
		case 1:
			rectangle.X = 659;
			rectangle.Y = 0;
			break;
		default:
			rectangle.X = 759;
			rectangle.Y = 10;
			break;
		}
		rectangle.Width = 10;
		rectangle.Height = 10;
		for (int num7 = 195; num7 >= 0; num7--)
		{
			NPC nPC = Main.npc[num7];
			if (nPC.active != 0)
			{
				int num8 = nPC.aabb.X >> 4;
				int num9 = nPC.aabb.Y >> 4;
				if (num8 >= 0 && num9 >= 0 && num8 < Main.maxTilesX && num9 < Main.maxTilesY && (Main.tile[num8, num9].flags & Tile.Flags.VISITED) == Tile.Flags.VISITED)
				{
					num8 -= 34 + mapX;
					if (num8 >= 0 && num8 + 4 < num2)
					{
						num9 -= 34 + mapY;
						if (num9 >= 0 && num9 + 4 < mapDestH)
						{
							int headTextureId = nPC.getHeadTextureId();
							if (headTextureId < 0)
							{
								color = new Color(106, 0, 66, 127);
								color.R = (byte)(color.R * UI.cursorColor.A >> 8);
								color.G = (byte)(color.G * UI.cursorColor.A >> 8);
								color.B = (byte)(color.B * UI.cursorColor.A >> 8);
								color.A = (byte)(color.A * UI.cursorColor.A >> 8);
								SpriteSheet<_sheetSprites>.DrawCentered(218, num + num8, sAFE_AREA_OFFSET_T + num9, rectangle, color);
							}
							else
							{
								SpriteSheet<_sheetSprites>.DrawScaled(1255 + headTextureId, num + num8, sAFE_AREA_OFFSET_T + num9, 0.5f, new Color(248, 248, 248, 248), (nPC.spriteDirection >= 0) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
							}
						}
					}
				}
			}
		}
		Main.spriteBatch.End();
		Matrix world = view.screenProjection.World;
		float num10 = (float)(0.6875 + 0.0625 * Math.Sin((double)Main.frameCounter * (1.0 / 12.0)));
		view2 = Matrix.CreateTranslation(-10f, -8f, 0f) * Matrix.CreateScale(num10, num10, 1f);
		for (int num11 = 7; num11 >= 0; num11--)
		{
			Player player = Main.player[num11];
			if (player.active != 0 && !player.dead)
			{
				int num12 = player.aabb.X >> 4;
				int num13 = player.aabb.Y >> 4;
				if ((Main.tile[num12, num13].flags & Tile.Flags.VISITED) != 0)
				{
					num12 -= 34 + mapX;
					num13 -= 34 + mapY;
					Vector2 position = player.position;
					player.position.X = view.screenPosition.X;
					player.position.Y = view.screenPosition.Y;
					view.screenProjection.World = view2 * Matrix.CreateTranslation(num + num12, sAFE_AREA_OFFSET_T + num13, 0f);
					Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, WorldView.scissorTest, view.screenProjection);
					player.Draw(view, isMenu: true, isIcon: true);
					Main.spriteBatch.End();
					player.position = position;
					player.aabb.X = (int)position.X;
					player.aabb.Y = (int)position.Y;
				}
			}
		}
		view.screenProjection.World = world;
		view.screenProjection.View = Matrix.Identity;
		Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, view.screenProjection);
	}
}
