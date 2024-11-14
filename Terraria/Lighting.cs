using System.Threading;
using Microsoft.Xna.Framework;

namespace Terraria;

public sealed class Lighting
{
	private struct TempLight
	{
		public short x;

		public short y;

		public Vector3 color;
	}

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

	public short scrX = -1;

	public short scrY;

	public int minX;

	public int maxX;

	public int minY;

	public int maxY;

	private float negLight = 0.04f;

	private float negLight2 = 0.16f;

	private float wetLightR = 0.16f;

	private float wetLightG = 0.16f;

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

	private AutoResetEvent workerThreadReady = new AutoResetEvent(initialState: false);

	private AutoResetEvent workerThreadGo = new AutoResetEvent(initialState: false);

	private volatile bool quitWorkerThread;

	public static int tempLightCount;

	private static TempLight[] tempLight = new TempLight[1024];

	public void StartWorkerThread()
	{
		if (workerThread != null)
		{
			StopWorkerThread();
		}
		quitWorkerThread = false;
		workerThreadReady.Reset();
		workerThreadGo.Reset();
		workerThread = new Thread(WorkerThread);
		workerThread.IsBackground = true;
		workerThread.Start();
	}

	public void StopWorkerThread()
	{
		if (workerThread != null)
		{
			quitWorkerThread = true;
			workerThreadGo.Set();
			workerThread.Join();
			workerThread = null;
		}
	}

	private void WorkerThread()
	{
		Thread.CurrentThread.SetProcessorAffinity(new int[1] { 3 });
		do
		{
			workerThreadReady.Set();
			workerThreadGo.WaitOne();
			lock (this)
			{
				doColors();
			}
		}
		while (!quitWorkerThread);
		workerThreadReady.Set();
	}

	public void SetWidth(int width)
	{
		lock (this)
		{
			MAX_LIGHT_ARRAY_X = (width + 64 >> 4) + 68;
			COLOR_W = MAX_LIGHT_ARRAY_X + 10;
			color = new Vector3[MAX_LIGHT_ARRAY_X, 107];
			color2 = new Vector3[COLOR_W, 117];
			stopAndWetLight = new byte[COLOR_W * 117];
		}
	}

	public unsafe void LightTiles(WorldView view)
	{
		firstTileX = view.firstTileX;
		lastTileX = view.lastTileX;
		firstTileY = view.firstTileY;
		lastTileY = view.lastTileY;
		firstToLightX = firstTileX - 34;
		firstToLightY = firstTileY - 34;
		int num = lastTileX + 34;
		int num2 = lastTileY + 34;
		if (firstToLightX < 0)
		{
			firstToLightX = 0;
		}
		if (num >= Main.maxTilesX)
		{
			num = Main.maxTilesX - 1;
		}
		if (firstToLightY < 0)
		{
			firstToLightY = 0;
		}
		if (num2 >= Main.maxTilesY)
		{
			num2 = Main.maxTilesY - 1;
		}
		if (Main.renderCount <= 4)
		{
			int num3 = (view.screenPosition.X >> 4) - (view.screenLastPosition.X >> 4);
			if (num3 < 0 && num3 >= -4)
			{
				fixed (Vector3* ptr = color)
				{
					int num4 = (MAX_LIGHT_ARRAY_X + num3) * 107 - 1;
					num3 *= 107;
					Vector3* ptr2 = ptr + (MAX_LIGHT_ARRAY_X * 107 - 1);
					do
					{
						*ptr2 = ptr2[num3];
						ptr2--;
					}
					while (--num4 >= 0);
				}
			}
			else if (num3 > 0 && num3 <= 4)
			{
				fixed (Vector3* ptr3 = color)
				{
					int num5 = (MAX_LIGHT_ARRAY_X - num3) * 107 - 1;
					num3 *= 107;
					Vector3* ptr4 = ptr3;
					do
					{
						*ptr4 = ptr4[num3];
						ptr4++;
					}
					while (--num5 >= 0);
				}
			}
			num3 = (view.screenPosition.Y >> 4) - (view.screenLastPosition.Y >> 4);
			if (num3 < 0 && num3 >= -4)
			{
				for (int i = 0; i < MAX_LIGHT_ARRAY_X; i++)
				{
					fixed (Vector3* ptr5 = &color[i, 0])
					{
						for (int num6 = 107 + num3; num6 > -num3; num6--)
						{
							ptr5[num6] = ptr5[num6 + num3];
						}
					}
				}
			}
			else if (num3 > 0 && num3 <= 4)
			{
				for (int j = 0; j < MAX_LIGHT_ARRAY_X; j++)
				{
					fixed (Vector3* ptr6 = &color[j, 0])
					{
						for (int k = 0; k < 107 - num3; k++)
						{
							ptr6[k] = ptr6[k + num3];
						}
					}
				}
			}
			oldSkyColor = skyColor;
			skyColor = (view.time.tileColorf.X + view.time.tileColorf.Y + view.time.tileColorf.Z) * (1f / 3f);
			if (oldSkyColor == skyColor)
			{
				return;
			}
			int num7 = ((num2 <= Main.worldSurface) ? num2 : Main.worldSurface);
			fixed (Tile* ptr7 = Main.tile)
			{
				for (int l = firstToLightX; l < num; l++)
				{
					Tile* ptr8 = ptr7 + (l * 1440 + firstToLightY);
					int num8 = firstToLightY;
					while (num8 < num7)
					{
						if ((ptr8->active == 0 || !Main.tileNoSunLight[ptr8->type]) && (ptr8->wall == 0 || ptr8->wall == 21) && ptr8->liquid < 200)
						{
							fixed (Vector3* ptr9 = &color[l - firstToLightX, num8 - firstToLightY])
							{
								if (ptr9->X < skyColor)
								{
									ptr9->X = view.time.tileColorf.X;
									if (ptr9->Y < skyColor)
									{
										ptr9->Y = view.time.tileColorf.Y;
									}
									if (ptr9->Z < skyColor)
									{
										ptr9->Z = view.time.tileColorf.Z;
									}
								}
							}
						}
						num8++;
						ptr8++;
					}
				}
			}
			return;
		}
		workerThreadReady.WaitOne();
		int num9 = view.screenPosition.X >> 4;
		int num10 = view.screenPosition.Y >> 4;
		if (scrX >= 0)
		{
			num9 -= scrX;
			num10 -= scrY;
			int num11 = ((num9 < 0) ? (-num9) : 0);
			int num12 = ((num10 < 0) ? (-num10) : 0);
			fixed (Vector3* ptr10 = color)
			{
				fixed (Vector3* ptr12 = color2)
				{
					for (int m = num11; m < MAX_LIGHT_ARRAY_X; m++)
					{
						Vector3* ptr11 = ptr10 + (m * 107 + num12);
						Vector3* ptr13 = ptr12 + ((m + num9) * 117 + num12 + num10);
						for (int n = num12; n < 107; n++)
						{
							*(ptr11++) = *(ptr13++);
						}
					}
				}
			}
		}
		fixed (Vector3* ptr14 = color2)
		{
			fixed (byte* ptr16 = stopAndWetLight)
			{
				Vector3* ptr15 = ptr14;
				byte* ptr17 = ptr16;
				for (int num13 = COLOR_W * 117 - 1; num13 >= 0; num13--)
				{
					ptr15->X = 0f;
					ptr15->Y = 0f;
					ptr15->Z = 0f;
					*ptr17 = 0;
					ptr15++;
					ptr17++;
				}
			}
		}
		fixed (TempLight* ptr18 = tempLight)
		{
			fixed (Vector3* ptr20 = color2)
			{
				TempLight* ptr19 = ptr18;
				for (int num14 = tempLightCount - 1; num14 >= 0; num14--)
				{
					int num15 = ptr19->x - firstToLightX;
					if (num15 >= 0 && num15 < COLOR_W)
					{
						int num16 = ptr19->y - firstToLightY;
						if (num16 >= 0 && num16 < 117)
						{
							Vector3* ptr21 = ptr20 + (num16 + num15 * 117);
							ptr21->X = ptr19->color.X;
							ptr21->Y = ptr19->color.Y;
							ptr21->Z = ptr19->color.Z;
						}
					}
					ptr19++;
				}
			}
		}
		int num17 = firstTileX - 14;
		int num18 = firstTileY - 14;
		int num19 = lastTileX + 14;
		int num20 = lastTileY + 14;
		if (num17 < 0)
		{
			num17 = 0;
		}
		if (num19 >= Main.maxTilesX)
		{
			num19 = Main.maxTilesX - 1;
		}
		if (num18 < 0)
		{
			num18 = 0;
		}
		if (num20 >= Main.maxTilesY)
		{
			num20 = Main.maxTilesY - 1;
		}
		if (NPC.wof >= 0 && view.player.horrified)
		{
			try
			{
				int num21 = (view.screenPosition.Y >> 4) - 10;
				int num22 = (view.screenPosition.Y + 540 >> 4) + 10;
				int num23 = Main.npc[NPC.wof].aabb.X >> 4;
				num23 = ((Main.npc[NPC.wof].direction <= 0) ? (num23 + 2) : (num23 - 3));
				int num24 = num23 + 8;
				Vector3 value = new Vector3(0.2f * (0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch)), 0.030000001f, 0.3f * (Main.demonTorch + 0.5f * (1f - Main.demonTorch)));
				for (int num25 = num23; num25 <= num24; num25++)
				{
					for (int num26 = num21; num26 <= num22; num26++)
					{
						Vector3.Max(ref value, ref color2[num25 - firstToLightX, num26 - firstToLightY], out color2[num25 - firstToLightX, num26 - firstToLightY]);
					}
				}
			}
			catch
			{
			}
		}
		int num27 = firstToLightX;
		int num28 = num;
		int num29 = firstToLightY;
		int num30 = num2;
		int num31 = ((num30 < Main.worldSurface) ? num30 : Main.worldSurface);
		fixed (Tile* ptr22 = Main.tile)
		{
			for (int num32 = num27; num32 < num28; num32++)
			{
				Tile* ptr23 = ptr22 + (num32 * 1440 + num29);
				int num33 = num29;
				while (num33 < num31)
				{
					int wall = ptr23->wall;
					if ((wall == 0 || wall == 21) && ptr23->liquid < 200 && (ptr23->active == 0 || !Main.tileNoSunLight[ptr23->type]))
					{
						fixed (Vector3* ptr24 = &color2[num32 - firstToLightX, num33 - firstToLightY])
						{
							if (ptr24->X < skyColor)
							{
								ptr24->X = view.time.tileColorf.X;
								if (ptr24->Y < skyColor)
								{
									ptr24->Y = view.time.tileColorf.Y;
								}
								if (ptr24->Z < skyColor)
								{
									ptr24->Z = view.time.tileColorf.Z;
								}
							}
						}
					}
					num33++;
					ptr23++;
				}
			}
		}
		negLight = 0.91f;
		negLight2 = 0.72f;
		wetLightG = 0.97f * negLight * UI.blueWave;
		wetLightR = 0.88f * negLight * UI.blueWave;
		if (view.player.nightVision)
		{
			negLight *= 1.03f;
			negLight2 *= 1.03f;
		}
		if (view.player.blind)
		{
			negLight *= 0.95f;
			negLight2 *= 0.95f;
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
		minX = COLOR_W;
		maxX = 0;
		minY = 117;
		maxY = 0;
		fixed (Tile* ptr25 = Main.tile)
		{
			for (int num34 = num27; num34 < num28; num34++)
			{
				Tile* ptr26 = ptr25 + (num34 * 1440 + num29);
				int num35 = num29;
				while (num35 < num30)
				{
					int num36 = num34 - firstToLightX;
					int num37 = num35 - firstToLightY;
					fixed (Vector3* ptr27 = &color2[num36, num37])
					{
						if (ptr26->active == 0)
						{
							view.inactiveTiles++;
						}
						else
						{
							int type = ptr26->type;
							int num38 = num28 - num27 - 99 >> 1;
							int num39 = num30 - num29 - 87 >> 1;
							if (num34 > num27 + num38 && num34 < num28 - num38 && num35 > num29 + num39 && num35 < num30 - num39)
							{
								switch (type)
								{
								case 23:
								case 24:
								case 25:
								case 32:
									view.evilTiles++;
									break;
								case 112:
									view.sandTiles++;
									view.evilTiles++;
									break;
								case 109:
								case 110:
								case 113:
								case 117:
									view.holyTiles++;
									break;
								case 116:
									view.sandTiles++;
									view.holyTiles++;
									break;
								case 27:
									view.evilTiles -= 5;
									break;
								case 37:
									view.meteorTiles++;
									break;
								case 41:
								case 43:
								case 44:
									view.dungeonTiles++;
									break;
								case 60:
								case 61:
								case 62:
								case 84:
									view.jungleTiles++;
									break;
								case 53:
									view.sandTiles++;
									break;
								case 147:
								case 148:
									view.snowTiles++;
									break;
								case 139:
									if (ptr26->frameX >= 36)
									{
										view.musicBox = ptr26->frameY / 36;
									}
									break;
								}
							}
							if (Main.tileBlockLight[type])
							{
								stopAndWetLight[num36 * 117 + num37] = 1;
							}
							if (Main.tileLighted[type])
							{
								switch (type)
								{
								case 92:
									if (ptr26->frameY <= 18 && ptr26->frameX == 0)
									{
										float num40 = 1f;
										float num41 = 1f;
										float num42 = 1f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 93:
									if (ptr26->frameY == 0 && ptr26->frameX == 0)
									{
										float num40 = 1f;
										float num41 = 0.97f;
										float num42 = 0.85f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 98:
									if (ptr26->frameY == 0)
									{
										float num40 = 1f;
										float num41 = 0.97f;
										float num42 = 0.85f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 4:
									if (ptr26->frameX < 66)
									{
										float num40;
										float num41;
										float num42;
										switch (ptr26->frameY)
										{
										case 22:
											num40 = 0f;
											num41 = 0.1f;
											num42 = 1.3f;
											break;
										case 44:
											num40 = 1f;
											num41 = 0.1f;
											num42 = 0.1f;
											break;
										case 66:
											num40 = 0f;
											num41 = 1f;
											num42 = 0.1f;
											break;
										case 88:
											num40 = 0.95f;
											num41 = 0.1f;
											num42 = 0.95f;
											break;
										case 110:
											num40 = 1.3f;
											num41 = 1.3f;
											num42 = 1.3f;
											break;
										case 132:
											num40 = 1f;
											num41 = 1f;
											num42 = 0.1f;
											break;
										case 154:
											num40 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
											num41 = 0.3f;
											num42 = Main.demonTorch + 0.5f * (1f - Main.demonTorch);
											break;
										case 176:
											num40 = 0.85f;
											num41 = 1f;
											num42 = 0.7f;
											break;
										default:
											num40 = 1f;
											num41 = 0.95f;
											num42 = 0.8f;
											break;
										}
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 33:
									if (ptr26->frameX == 0)
									{
										float num40 = 1f;
										float num41 = 0.95f;
										float num42 = 0.65f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 36:
									if (ptr26->frameX < 54)
									{
										float num40 = 1f;
										float num41 = 0.95f;
										float num42 = 0.65f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 100:
									if (ptr26->frameX < 36)
									{
										float num40 = 1f;
										float num41 = 0.95f;
										float num42 = 0.65f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 34:
								case 35:
									if (ptr26->frameX < 54)
									{
										float num40 = 1f;
										float num41 = 0.95f;
										float num42 = 0.8f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 95:
									if (ptr26->frameX < 36)
									{
										float num40 = 1f;
										float num41 = 0.95f;
										float num42 = 0.8f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 17:
								case 133:
								{
									float num40 = 0.83f;
									float num41 = 0.6f;
									float num42 = 0.5f;
									if (num40 > ptr27->X)
									{
										ptr27->X = num40;
									}
									if (num41 > ptr27->Y)
									{
										ptr27->Y = num41;
									}
									if (num42 > ptr27->Z)
									{
										ptr27->Z = num42;
									}
									break;
								}
								case 77:
								{
									float num40 = 0.75f;
									float num41 = 0.45f;
									float num42 = 0.25f;
									if (num40 > ptr27->X)
									{
										ptr27->X = num40;
									}
									if (num41 > ptr27->Y)
									{
										ptr27->Y = num41;
									}
									if (num42 > ptr27->Z)
									{
										ptr27->Z = num42;
									}
									break;
								}
								case 37:
								{
									float num40 = 0.56f;
									float num41 = 0.43f;
									float num42 = 0.15f;
									if (num40 > ptr27->X)
									{
										ptr27->X = num40;
									}
									if (num41 > ptr27->Y)
									{
										ptr27->Y = num41;
									}
									if (num42 > ptr27->Z)
									{
										ptr27->Z = num42;
									}
									break;
								}
								case 22:
								case 140:
								{
									float num40 = 0.12f;
									float num41 = 0.07f;
									float num42 = 0.32f;
									if (num40 > ptr27->X)
									{
										ptr27->X = num40;
									}
									if (num41 > ptr27->Y)
									{
										ptr27->Y = num41;
									}
									if (num42 > ptr27->Z)
									{
										ptr27->Z = num42;
									}
									break;
								}
								case 42:
									if (ptr26->frameX == 0)
									{
										float num40 = 0.65f;
										float num41 = 0.8f;
										float num42 = 0.54f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 49:
								{
									float num40 = 0.3f;
									float num41 = 0.3f;
									float num42 = 0.75f;
									if (num40 > ptr27->X)
									{
										ptr27->X = num40;
									}
									if (num41 > ptr27->Y)
									{
										ptr27->Y = num41;
									}
									if (num42 > ptr27->Z)
									{
										ptr27->Z = num42;
									}
									break;
								}
								case 70:
								case 71:
								case 72:
								{
									float num46 = (float)Main.rand.Next(28, 42) * 0.005f;
									num46 += (float)(270 - UI.mouseTextBrightness) * 0.002f;
									float num40 = 0.1f;
									float num41 = 0.3f + num46;
									float num42 = 0.6f + num46;
									if (num40 > ptr27->X)
									{
										ptr27->X = num40;
									}
									if (num41 > ptr27->Y)
									{
										ptr27->Y = num41;
									}
									if (num42 > ptr27->Z)
									{
										ptr27->Z = num42;
									}
									break;
								}
								case 61:
									if (ptr26->frameX == 144)
									{
										float num40 = 0.42f;
										float num41 = 0.81f;
										float num42 = 0.52f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 26:
								case 31:
								{
									float num43 = (float)Main.rand.Next(-5, 6) * 0.0025f;
									float num40 = 0.31f + num43;
									float num41 = 0.1f;
									float num42 = 0.44f + num43;
									if (num40 > ptr27->X)
									{
										ptr27->X = num40;
									}
									if (num41 > ptr27->Y)
									{
										ptr27->Y = num41;
									}
									if (num42 > ptr27->Z)
									{
										ptr27->Z = num42;
									}
									break;
								}
								case 84:
									switch (ptr26->frameX / 18)
									{
									case 2:
									{
										float num45 = (float)(270 - UI.mouseTextBrightness) * 0.00125f;
										if (num45 > 1f)
										{
											num45 = 1f;
										}
										else if (num45 < 0f)
										{
											num45 = 0f;
										}
										float num40 = 0.7f * num45;
										float num41 = num45;
										float num42 = 0.1f * num45;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
										break;
									}
									case 5:
									{
										float num40 = 0.9f;
										float num41 = 0.71999997f;
										float num42 = 0.17999999f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
										break;
									}
									}
									break;
								case 83:
									if (ptr26->frameX == 18 && !view.time.dayTime)
									{
										float num40 = 0.1f;
										float num41 = 0.4f;
										float num42 = 0.6f;
										if (num40 > ptr27->X)
										{
											ptr27->X = num40;
										}
										if (num41 > ptr27->Y)
										{
											ptr27->Y = num41;
										}
										if (num42 > ptr27->Z)
										{
											ptr27->Z = num42;
										}
									}
									break;
								case 126:
									if (ptr26->frameX < 36)
									{
										if (Main.DiscoRGB.X > ptr27->X)
										{
											ptr27->X = Main.DiscoRGB.X;
										}
										if (Main.DiscoRGB.Y > ptr27->Y)
										{
											ptr27->Y = Main.DiscoRGB.Y;
										}
										if (Main.DiscoRGB.Z > ptr27->Z)
										{
											ptr27->Z = Main.DiscoRGB.Z;
										}
									}
									break;
								case 125:
								{
									float num44 = (float)Main.rand.Next(28, 42) * 0.01f;
									num44 += (float)(270 - UI.mouseTextBrightness) * 0.00125f;
									if (ptr27->Y < 0.1f * num44)
									{
										ptr27->Y = 0.3f * num44;
									}
									if (ptr27->Z < 0.3f * num44)
									{
										ptr27->Z = 0.6f * num44;
									}
									break;
								}
								case 129:
								{
									float num40;
									float num41;
									float num42;
									if (ptr26->frameX == 0 || ptr26->frameX == 54 || ptr26->frameX == 108)
									{
										num40 = 0f;
										num41 = 0.05f;
										num42 = 0.25f;
									}
									else if (ptr26->frameX == 18 || ptr26->frameX == 72 || ptr26->frameX == 126)
									{
										num40 = 0.2f;
										num41 = 0f;
										num42 = 0.15f;
									}
									else
									{
										num40 = 0.1f;
										num41 = 0f;
										num42 = 0.2f;
									}
									if (ptr27->X < num40)
									{
										ptr27->X = num40 * (float)Main.rand.Next(970, 1031) * 0.001f;
									}
									if (ptr27->Y < num41)
									{
										ptr27->Y = num41 * (float)Main.rand.Next(970, 1031) * 0.001f;
									}
									if (ptr27->Z < num42)
									{
										ptr27->Z = num42 * (float)Main.rand.Next(970, 1031) * 0.001f;
									}
									break;
								}
								case 149:
									if (ptr26->frameX <= 36)
									{
										float num40;
										float num41;
										float num42;
										if (ptr26->frameX == 0)
										{
											num40 = 0.1f;
											num41 = 0.2f;
											num42 = 0.5f;
										}
										else if (ptr26->frameX == 18)
										{
											num40 = 0.5f;
											num41 = 0.1f;
											num42 = 0.1f;
										}
										else
										{
											num40 = 0.2f;
											num41 = 0.5f;
											num42 = 0.1f;
										}
										if (ptr27->X < num40)
										{
											ptr27->X = num40 * (float)Main.rand.Next(970, 1031) * 0.001f;
										}
										if (ptr27->Y < num41)
										{
											ptr27->Y = num41 * (float)Main.rand.Next(970, 1031) * 0.001f;
										}
										if (ptr27->Z < num42)
										{
											ptr27->Z = num42 * (float)Main.rand.Next(970, 1031) * 0.001f;
										}
									}
									break;
								}
							}
						}
						if (ptr26->liquid > 0)
						{
							if (ptr26->lava != 0)
							{
								float num47 = 0.55f;
								num47 += (float)(270 - UI.mouseTextBrightness) * 0.0011111111f;
								if (ptr27->X < num47)
								{
									ptr27->X = num47;
								}
								if (ptr27->Y < num47)
								{
									ptr27->Y = num47 * 0.6f;
								}
								if (ptr27->Z < num47)
								{
									ptr27->Z = num47 * 0.2f;
								}
							}
							else if (ptr26->liquid > 128)
							{
								stopAndWetLight[num36 * 117 + num37] |= 2;
							}
						}
						if (ptr27->X > 0f || ptr27->Y > 0f || ptr27->Z > 0f)
						{
							if (minX > num36)
							{
								minX = num36;
							}
							if (maxX < num36 + 1)
							{
								maxX = num36 + 1;
							}
							if (minY > num37)
							{
								minY = num37;
							}
							if (maxY < num37 + 1)
							{
								maxY = num37 + 1;
							}
						}
					}
					num35++;
					ptr26++;
				}
			}
		}
		if (view.evilTiles < 0)
		{
			view.evilTiles = 0;
		}
		int holyTiles = view.holyTiles;
		view.holyTiles -= view.evilTiles;
		view.evilTiles -= holyTiles;
		if (view.holyTiles < 0)
		{
			view.holyTiles = 0;
		}
		if (view.evilTiles < 0)
		{
			view.evilTiles = 0;
		}
		minX7 = minX;
		maxX7 = maxX;
		minY7 = minY;
		maxY7 = maxY;
		minX += firstToLightX;
		maxX += firstToLightX;
		minY += firstToLightY;
		maxY += firstToLightY;
		firstTileX7 = firstTileX - firstToLightX;
		lastTileX7 = lastTileX - firstToLightX;
		lastTileY7 = lastTileY - firstToLightY;
		firstTileY7 = firstTileY - firstToLightY;
		lastToLightY7 = num2 - firstToLightY;
		firstToLightX27 = num17 - firstToLightX;
		lastToLightX27 = num19 - firstToLightX;
		firstToLightY27 = num18 - firstToLightY;
		lastToLightY27 = num20 - firstToLightY;
		workerThreadGo.Set();
		scrX = (short)(view.screenPosition.X >> 4);
		scrY = (short)(view.screenPosition.Y >> 4);
	}

	private unsafe void doColors()
	{
		fixed (Vector3* ptr = color2)
		{
			int num = minX7 * 117;
			int num2 = minX7;
			while (num2 < maxX7)
			{
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				for (int i = minY7; i < lastToLightY27 + 4; i++)
				{
					int num3 = num + i;
					LightColor(ptr + num3, num3, 1);
				}
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				for (int num4 = maxY7; num4 >= firstTileY7 - 4; num4--)
				{
					int num5 = num + num4;
					LightColor(ptr + num5, num5, -1);
				}
				num2++;
				num += 117;
			}
		}
		fixed (Vector3* ptr2 = color2)
		{
			for (int j = 0; j < lastToLightY7; j++)
			{
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				int num6 = j + minX7 * 117;
				int num7 = minX7;
				while (num7 < lastTileX7 + 4)
				{
					LightColor(ptr2 + num6, num6, 117);
					num7++;
					num6 += 117;
				}
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				num6 = j + maxX7 * 117;
				int num8 = maxX7;
				while (num8 >= firstTileX7 - 4)
				{
					LightColor(ptr2 + num6, num6, -117);
					num8--;
					num6 -= 117;
				}
			}
		}
		fixed (Vector3* ptr3 = color2)
		{
			int num9 = firstToLightX27 * 117;
			int num10 = firstToLightX27;
			while (num10 < lastToLightX27)
			{
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				for (int k = firstToLightY27; k < lastTileY7 + 4; k++)
				{
					int num11 = k + num9;
					LightColor(ptr3 + num11, num11, 1);
				}
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				for (int num12 = lastToLightY27; num12 >= firstTileY7 - 4; num12--)
				{
					int num13 = num12 + num9;
					LightColor(ptr3 + num13, num13, -1);
				}
				num10++;
				num9 += 117;
			}
		}
		fixed (Vector3* ptr4 = color2)
		{
			for (int l = firstToLightY27; l < lastToLightY27; l++)
			{
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				int num14 = l + firstToLightX27 * 117;
				int num15 = firstToLightX27;
				while (num15 < lastTileX7 + 4)
				{
					LightColor(ptr4 + num14, num14, 117);
					num15++;
					num14 += 117;
				}
				lightColor = 0f;
				lightColorG = 0f;
				lightColorB = 0f;
				num14 = l + lastToLightX27 * 117;
				int num16 = lastToLightX27;
				while (num16 >= firstTileX7 - 4)
				{
					LightColor(ptr4 + num14, num14, -117);
					num16--;
					num14 -= 117;
				}
			}
		}
	}

	public unsafe static void addLight(int i, int j, Vector3 rgb)
	{
		if (tempLightCount == 1024 || !WorldView.AnyViewContains(i << 4, j << 4))
		{
			return;
		}
		fixed (TempLight* ptr = tempLight)
		{
			int num = tempLightCount - 1;
			TempLight* ptr2 = ptr + num;
			while (num >= 0)
			{
				if (ptr2->x == i && ptr2->y == j)
				{
					if (ptr2->color.X < rgb.X)
					{
						ptr2->color.X = rgb.X;
					}
					if (ptr2->color.Y < rgb.Y)
					{
						ptr2->color.Y = rgb.Y;
					}
					if (ptr2->color.Z < rgb.Z)
					{
						ptr2->color.Z = rgb.Z;
					}
					return;
				}
				ptr2--;
				num--;
			}
			ptr2 = ptr + tempLightCount++;
			ptr2->x = (short)i;
			ptr2->y = (short)j;
			ptr2->color = rgb;
		}
	}

	private unsafe void LightColor(Vector3* pColor2, int s, int offset)
	{
		s = stopAndWetLight[s];
		float num = lightColor;
		if (pColor2->X > num)
		{
			num = pColor2->X;
		}
		if (num > 0.0185f)
		{
			pColor2->X = num;
			if (pColor2[offset].X <= num)
			{
				num = ((s == 0) ? (num * negLight) : (((s & 1) == 0) ? (num * (wetLightR * (float)Main.rand.Next(98, 100) * 0.01f)) : (num * negLight2)));
			}
			lightColor = num;
		}
		num = lightColorG;
		if (pColor2->Y > num)
		{
			num = pColor2->Y;
		}
		if (num > 0.0185f)
		{
			pColor2->Y = num;
			if (pColor2[offset].Y <= num)
			{
				num = ((s == 0) ? (num * negLight) : (((s & 1) == 0) ? (num * (wetLightG * (float)Main.rand.Next(97, 100) * 0.01f)) : (num * negLight2)));
			}
			lightColorG = num;
		}
		num = lightColorB;
		if (pColor2->Z > num)
		{
			num = pColor2->Z;
		}
		if (num > 0.0185f)
		{
			pColor2->Z = num;
			if (pColor2[offset].Z < num)
			{
				num = (((s & 1) == 0) ? (num * negLight) : (num * negLight2));
			}
			lightColorB = num;
		}
	}

	public Color GetColorPlayer(int x, int y, Color oldColor)
	{
		int num = x - firstToLightX;
		int num2 = y - firstToLightY;
		if (num < 0 || num2 < 0 || num >= MAX_LIGHT_ARRAY_X || num2 >= 107)
		{
			return Color.Black;
		}
		float num3 = color[num, num2].X * 2.5f;
		if (num3 > 1f)
		{
			num3 = 1f;
		}
		int r = (int)((float)(int)oldColor.R * num3 * brightness);
		num3 = color[num, num2].Y * 2.5f;
		if (num3 > 1f)
		{
			num3 = 1f;
		}
		int g = (int)((float)(int)oldColor.G * num3 * brightness);
		num3 = color[num, num2].Z * 2.5f;
		if (num3 > 1f)
		{
			num3 = 1f;
		}
		int b = (int)((float)(int)oldColor.B * num3 * brightness);
		return new Color(r, g, b, 255);
	}

	public Color GetColorPlayer(int x, int y)
	{
		int num = x - firstToLightX;
		int num2 = y - firstToLightY;
		if (num < 0 || num2 < 0 || num >= MAX_LIGHT_ARRAY_X || num2 >= 107)
		{
			return Color.Black;
		}
		return new Color(color[num, num2] * (brightness * 2.5f));
	}

	public Color GetColorUnsafe(int x, int y)
	{
		return new Color(color[x - firstToLightX, y - firstToLightY] * brightness);
	}

	public Color GetColor(int x, int y)
	{
		int num = x - firstToLightX;
		int num2 = y - firstToLightY;
		if (num < 0 || num2 < 0 || num >= MAX_LIGHT_ARRAY_X || num2 >= 107)
		{
			return Color.Black;
		}
		return new Color(color[num, num2] * brightness);
	}

	public unsafe float Brightness(int x, int y)
	{
		int num = x - firstToLightX;
		int num2 = y - firstToLightY;
		if (num < 0 || num2 < 0 || num >= MAX_LIGHT_ARRAY_X || num2 >= 107)
		{
			return 0f;
		}
		fixed (Vector3* ptr = &color[num, num2])
		{
			return (ptr->X + ptr->Y + ptr->Z) * (1f / 3f);
		}
	}

	public unsafe float BrightnessUnsafe(int x, int y)
	{
		fixed (Vector3* ptr = &color[x - firstToLightX, y - firstToLightY])
		{
			return (ptr->X + ptr->Y + ptr->Z) * (1f / 3f);
		}
	}

	public unsafe bool IsNotBlackUnsafe(int x, int y)
	{
		fixed (Vector3* ptr = &color[x - firstToLightX, y - firstToLightY])
		{
			return ptr->X > 0f || ptr->Y > 0f || ptr->Z > 0f;
		}
	}

	public unsafe bool Brighter(int x, int y, int x2, int y2)
	{
		int num = x - firstToLightX;
		int num2 = y - firstToLightY;
		if (num < 0 || num2 < 0 || num >= MAX_LIGHT_ARRAY_X || num2 >= 107)
		{
			return true;
		}
		int num3 = x2 - firstToLightX;
		int num4 = y2 - firstToLightY;
		if (num3 < 0 || num4 < 0 || num3 >= MAX_LIGHT_ARRAY_X || num4 >= 107)
		{
			return false;
		}
		fixed (Vector3* ptr = &color[num, num2])
		{
			fixed (Vector3* ptr2 = &color2[num3, num4])
			{
				return ptr->X + ptr->Y + ptr->Z <= ptr2->X + ptr2->Y + ptr2->Z;
			}
		}
	}
}
