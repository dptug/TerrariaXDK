namespace Terraria;

public struct Liquid
{
	public const int MAX_LIQUID = 4096;

	public static int skipCount = 0;

	public static int stuckCount = 0;

	public static int stuckAmount = 0;

	private static int cycles = 7;

	public static int numLiquid;

	public static bool stuck = false;

	public static bool quickFall = false;

	private static bool quickSettle = false;

	private static int wetCounter;

	public static int panicCounter = 0;

	public static bool panicMode = false;

	public static int panicY = 0;

	public short x;

	public short y;

	public short kill;

	public short delay;

	public void Init(int nx, int ny)
	{
		x = (short)nx;
		y = (short)ny;
		kill = 0;
		delay = 0;
	}

	public static void QuickSettleOn()
	{
		quickSettle = true;
		cycles = 1;
	}

	public static void QuickSettleOff()
	{
		quickSettle = false;
		cycles = 14;
	}

	public static void QuickWater(double verbose, int minY = 3, int maxY = -1, double startPercent = 0.0)
	{
		if (maxY == -1)
		{
			maxY = Main.maxTilesY - 3;
		}
		for (int num = maxY; num >= minY; num--)
		{
			UI.main.progress = (float)((double)(maxY - num) / (double)(maxY - minY + 1) * verbose + startPercent);
			for (int i = 0; i < 2; i++)
			{
				int num2 = 2;
				int num3 = Main.maxTilesX - 2;
				int num4 = 1;
				if (i == 1)
				{
					num2 = num3;
					num3 = 2;
					num4 = -1;
				}
				for (int j = num2; j != num3; j += num4)
				{
					int num5 = Main.tile[j, num].liquid;
					if (num5 <= 0)
					{
						continue;
					}
					Main.tile[j, num].liquid = 0;
					int num6 = -num4;
					bool flag = false;
					int num7 = j;
					int num8 = num;
					int num9 = Main.tile[j, num].lava;
					bool flag2 = true;
					int num10 = 0;
					while (flag2 && num7 > 3 && num7 < Main.maxTilesX - 3 && num8 < Main.maxTilesY - 3)
					{
						flag2 = false;
						while (Main.tile[num7, num8 + 1].liquid == 0 && num8 < Main.maxTilesY - 5 && (Main.tile[num7, num8 + 1].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[num7, num8 + 1].type]))
						{
							flag2 = true;
							flag = true;
							num6 = num4;
							num10 = 0;
							num8++;
							if (num8 > WorldGen.waterLine)
							{
								num9 = 32;
							}
						}
						if (Main.tile[num7, num8 + 1].liquid > 0 && Main.tile[num7, num8 + 1].liquid < byte.MaxValue && Main.tile[num7, num8 + 1].lava == num9)
						{
							int num11 = 255 - Main.tile[num7, num8 + 1].liquid;
							if (num11 > num5)
							{
								num11 = num5;
							}
							Main.tile[num7, num8 + 1].liquid += (byte)num11;
							num5 -= (byte)num11;
							if (num5 <= 0)
							{
								break;
							}
						}
						if (num10 == 0)
						{
							if (Main.tile[num7 + num6, num8].liquid == 0 && (Main.tile[num7 + num6, num8].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[num7 + num6, num8].type]))
							{
								num10 = num6;
							}
							else if (Main.tile[num7 - num6, num8].liquid == 0 && (Main.tile[num7 - num6, num8].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[num7 - num6, num8].type]))
							{
								num10 = -num6;
							}
						}
						if (num10 != 0 && Main.tile[num7 + num10, num8].liquid == 0 && (Main.tile[num7 + num10, num8].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[num7 + num10, num8].type]))
						{
							flag2 = true;
							num7 += num10;
						}
						if (flag && !flag2)
						{
							flag = false;
							flag2 = true;
							num6 = -num4;
							num10 = 0;
						}
					}
					Main.tile[num7, num8].liquid = (byte)num5;
					Main.tile[num7, num8].lava = (byte)num9;
					if (Main.tile[num7 - 1, num8].liquid > 0 && Main.tile[num7 - 1, num8].lava != num9)
					{
						if (num9 != 0)
						{
							LavaCheck(num7, num8);
						}
						else
						{
							LavaCheck(num7 - 1, num8);
						}
					}
					else if (Main.tile[num7 + 1, num8].liquid > 0 && Main.tile[num7 + 1, num8].lava != num9)
					{
						if (num9 != 0)
						{
							LavaCheck(num7, num8);
						}
						else
						{
							LavaCheck(num7 + 1, num8);
						}
					}
					else if (Main.tile[num7, num8 - 1].liquid > 0 && Main.tile[num7, num8 - 1].lava != num9)
					{
						if (num9 != 0)
						{
							LavaCheck(num7, num8);
						}
						else
						{
							LavaCheck(num7, num8 - 1);
						}
					}
					else if (Main.tile[num7, num8 + 1].liquid > 0 && Main.tile[num7, num8 + 1].lava != num9)
					{
						if (num9 != 0)
						{
							LavaCheck(num7, num8);
						}
						else
						{
							LavaCheck(num7, num8 + 1);
						}
					}
				}
			}
		}
	}

	public unsafe void Update()
	{
		fixed (Tile* ptr = &Main.tile[x, y])
		{
			if (ptr->active != 0 && Main.tileSolidNotSolidTop[ptr->type])
			{
				kill = 9;
				return;
			}
			int num = ptr->liquid;
			int num2 = num;
			int num3 = 0;
			if (y > Main.maxTilesY - 200 && num > 0 && ptr->lava == 0)
			{
				int num4 = 2;
				if (num < num4)
				{
					num4 = num;
				}
				num -= num4;
				ptr->liquid = (byte)num;
			}
			if (num == 0)
			{
				kill = 9;
				return;
			}
			if (ptr->lava != 0)
			{
				LavaCheck(x, y);
				if (!quickFall)
				{
					if (delay < 5)
					{
						delay++;
						return;
					}
					delay = 0;
				}
			}
			else
			{
				if (ptr[-1440].lava != 0)
				{
					AddWater(x - 1, y);
				}
				if (ptr[1440].lava != 0)
				{
					AddWater(x + 1, y);
				}
				if (ptr[-1].lava != 0)
				{
					AddWater(x, y - 1);
				}
				if (ptr[1].lava != 0)
				{
					AddWater(x, y + 1);
				}
			}
			if (ptr[1].active == 0 || !Main.tileSolidNotSolidTop[ptr[1].type])
			{
				num = ptr[1].liquid;
				if ((num <= 0 || ptr[1].lava == ptr->lava) && num < 255)
				{
					num3 = 255 - num;
					if (num3 > ptr->liquid)
					{
						num3 = ptr->liquid;
					}
					ptr->liquid -= (byte)num3;
					num += num3;
					ptr[1].liquid = (byte)num;
					ptr[1].lava = ptr->lava;
					AddWater(x, y + 1);
					ptr[1].skipLiquid = 128;
					ptr->skipLiquid = 128;
					if (ptr->liquid > 250)
					{
						ptr->liquid = byte.MaxValue;
					}
					else
					{
						AddWater(x - 1, y);
						AddWater(x + 1, y);
					}
				}
			}
			if (ptr->liquid > 0)
			{
				bool flag = true;
				bool flag2 = true;
				bool flag3 = true;
				bool flag4 = true;
				if (ptr[-1440].active != 0 && Main.tileSolidNotSolidTop[ptr[-1440].type])
				{
					flag = false;
				}
				else if (ptr[-1440].liquid > 0 && ptr[-1440].lava != ptr->lava)
				{
					flag = false;
				}
				else if (ptr[-2880].active != 0 && Main.tileSolidNotSolidTop[ptr[-2880].type])
				{
					flag3 = false;
				}
				else if (ptr[-2880].liquid == 0)
				{
					flag3 = false;
				}
				else if (ptr[-2880].liquid > 0 && ptr[-2880].lava != ptr->lava)
				{
					flag3 = false;
				}
				if (ptr[1440].active != 0 && Main.tileSolidNotSolidTop[ptr[1440].type])
				{
					flag2 = false;
				}
				else if (ptr[1440].liquid > 0 && ptr[1440].lava != ptr->lava)
				{
					flag2 = false;
				}
				else if (ptr[2880].active != 0 && Main.tileSolidNotSolidTop[ptr[2880].type])
				{
					flag4 = false;
				}
				else if (ptr[2880].liquid == 0)
				{
					flag4 = false;
				}
				else if (ptr[2880].liquid > 0 && ptr[2880].lava != ptr->lava)
				{
					flag4 = false;
				}
				int num5 = 0;
				if (ptr->liquid < 3)
				{
					num5 = -1;
				}
				if (flag && flag2)
				{
					if (flag3 && flag4)
					{
						bool flag5 = true;
						bool flag6 = true;
						if (ptr[-4320].active != 0 && Main.tileSolidNotSolidTop[ptr[-4320].type])
						{
							flag5 = false;
						}
						else if (ptr[-4320].liquid == 0)
						{
							flag5 = false;
						}
						else if (ptr[-4320].lava != ptr->lava)
						{
							flag5 = false;
						}
						if (ptr[4320].active != 0 && Main.tileSolidNotSolidTop[ptr[4320].type])
						{
							flag6 = false;
						}
						else if (ptr[4320].liquid == 0)
						{
							flag6 = false;
						}
						else if (ptr[4320].lava != ptr->lava)
						{
							flag6 = false;
						}
						if (flag5 && flag6)
						{
							num3 = ptr[-1440].liquid + ptr[1440].liquid + ptr[-2880].liquid + ptr[2880].liquid + ptr[-4320].liquid + ptr[4320].liquid + ptr->liquid + num5;
							num3 = (num3 + 3) / 7;
							int num6 = 0;
							ptr[-1440].lava = ptr->lava;
							if (ptr[-1440].liquid != num3)
							{
								AddWater(x - 1, y);
								ptr[-1440].liquid = (byte)num3;
							}
							else
							{
								num6++;
							}
							ptr[1440].lava = ptr->lava;
							if (ptr[1440].liquid != num3)
							{
								AddWater(x + 1, y);
								ptr[1440].liquid = (byte)num3;
							}
							else
							{
								num6++;
							}
							ptr[-2880].lava = ptr->lava;
							if (ptr[-2880].liquid != num3)
							{
								AddWater(x - 2, y);
								ptr[-2880].liquid = (byte)num3;
							}
							else
							{
								num6++;
							}
							ptr[2880].lava = ptr->lava;
							if (ptr[2880].liquid != num3)
							{
								AddWater(x + 2, y);
								ptr[2880].liquid = (byte)num3;
							}
							else
							{
								num6++;
							}
							ptr[-4320].lava = ptr->lava;
							if (ptr[-4320].liquid != num3)
							{
								AddWater(x - 3, y);
								ptr[-4320].liquid = (byte)num3;
							}
							else
							{
								num6++;
							}
							ptr[4320].lava = ptr->lava;
							if (ptr[4320].liquid != num3)
							{
								AddWater(x + 3, y);
								ptr[4320].liquid = (byte)num3;
							}
							else
							{
								num6++;
							}
							if (ptr->liquid != num3 || ptr[-1440].liquid != num3)
							{
								AddWater(x - 1, y);
							}
							if (ptr->liquid != num3 || ptr[1440].liquid != num3)
							{
								AddWater(x + 1, y);
							}
							if (ptr->liquid != num3 || ptr[-2880].liquid != num3)
							{
								AddWater(x - 2, y);
							}
							if (ptr->liquid != num3 || ptr[2880].liquid != num3)
							{
								AddWater(x + 2, y);
							}
							if (ptr->liquid != num3 || ptr[-4320].liquid != num3)
							{
								AddWater(x - 3, y);
							}
							if (ptr->liquid != num3 || ptr[4320].liquid != num3)
							{
								AddWater(x + 3, y);
							}
							if (num6 != 6 || ptr[-1].liquid <= 0)
							{
								ptr->liquid = (byte)num3;
							}
						}
						else
						{
							int num7 = 0;
							num3 = ptr[-1440].liquid + ptr[1440].liquid + ptr[-2880].liquid + ptr[2880].liquid + ptr->liquid + num5;
							num3 = (num3 + 2) / 5;
							ptr[-1440].lava = ptr->lava;
							if (ptr[-1440].liquid != num3)
							{
								AddWater(x - 1, y);
								ptr[-1440].liquid = (byte)num3;
							}
							else
							{
								num7++;
							}
							ptr[1440].lava = ptr->lava;
							if (ptr[1440].liquid != num3)
							{
								AddWater(x + 1, y);
								ptr[1440].liquid = (byte)num3;
							}
							else
							{
								num7++;
							}
							ptr[-2880].lava = ptr->lava;
							if (ptr[-2880].liquid != num3)
							{
								AddWater(x - 2, y);
								ptr[-2880].liquid = (byte)num3;
							}
							else
							{
								num7++;
							}
							ptr[2880].lava = ptr->lava;
							if (ptr[2880].liquid != num3)
							{
								AddWater(x + 2, y);
								ptr[2880].liquid = (byte)num3;
							}
							else
							{
								num7++;
							}
							if (ptr[-1440].liquid != num3 || ptr->liquid != num3)
							{
								AddWater(x - 1, y);
							}
							if (ptr[1440].liquid != num3 || ptr->liquid != num3)
							{
								AddWater(x + 1, y);
							}
							if (ptr[-2880].liquid != num3 || ptr->liquid != num3)
							{
								AddWater(x - 2, y);
							}
							if (ptr[2880].liquid != num3 || ptr->liquid != num3)
							{
								AddWater(x + 2, y);
							}
							if (num7 != 4 || ptr[-1].liquid <= 0)
							{
								ptr->liquid = (byte)num3;
							}
						}
					}
					else if (flag3)
					{
						num3 = ptr[-1440].liquid + ptr[1440].liquid + ptr[-2880].liquid + ptr->liquid + num5;
						num3 = num3 + 2 >> 2;
						ptr[-1440].lava = ptr->lava;
						if (ptr[-1440].liquid != num3 || ptr->liquid != num3)
						{
							AddWater(x - 1, y);
							ptr[-1440].liquid = (byte)num3;
						}
						ptr[1440].lava = ptr->lava;
						if (ptr[1440].liquid != num3 || ptr->liquid != num3)
						{
							AddWater(x + 1, y);
							ptr[1440].liquid = (byte)num3;
						}
						ptr[-2880].lava = ptr->lava;
						if (ptr[-2880].liquid != num3 || ptr->liquid != num3)
						{
							ptr[-2880].liquid = (byte)num3;
							AddWater(x - 2, y);
						}
						ptr->liquid = (byte)num3;
					}
					else if (flag4)
					{
						num3 = ptr[-1440].liquid + ptr[1440].liquid + ptr[2880].liquid + ptr->liquid + num5;
						num3 = num3 + 2 >> 2;
						ptr[-1440].lava = ptr->lava;
						if (ptr[-1440].liquid != num3 || ptr->liquid != num3)
						{
							AddWater(x - 1, y);
							ptr[-1440].liquid = (byte)num3;
						}
						ptr[1440].lava = ptr->lava;
						if (ptr[1440].liquid != num3 || ptr->liquid != num3)
						{
							AddWater(x + 1, y);
							ptr[1440].liquid = (byte)num3;
						}
						ptr[2880].lava = ptr->lava;
						if (ptr[2880].liquid != num3 || ptr->liquid != num3)
						{
							ptr[2880].liquid = (byte)num3;
							AddWater(x + 2, y);
						}
						ptr->liquid = (byte)num3;
					}
					else
					{
						num3 = ptr[-1440].liquid + ptr[1440].liquid + ptr->liquid + num5;
						num3 = (num3 + 1) / 3;
						ptr[-1440].lava = ptr->lava;
						if (ptr[-1440].liquid != num3)
						{
							ptr[-1440].liquid = (byte)num3;
						}
						if (ptr->liquid != num3 || ptr[-1440].liquid != num3)
						{
							AddWater(x - 1, y);
						}
						ptr[1440].lava = ptr->lava;
						if (ptr[1440].liquid != num3)
						{
							ptr[1440].liquid = (byte)num3;
						}
						if (ptr->liquid != num3 || ptr[1440].liquid != num3)
						{
							AddWater(x + 1, y);
						}
						ptr->liquid = (byte)num3;
					}
				}
				else if (flag)
				{
					num3 = ptr[-1440].liquid + ptr->liquid + num5;
					num3 = num3 + 1 >> 1;
					if (ptr[-1440].liquid != num3)
					{
						ptr[-1440].liquid = (byte)num3;
					}
					ptr[-1440].lava = ptr->lava;
					if (ptr->liquid != num3 || ptr[-1440].liquid != num3)
					{
						AddWater(x - 1, y);
					}
					ptr->liquid = (byte)num3;
				}
				else if (flag2)
				{
					num3 = ptr[1440].liquid + ptr->liquid + num5;
					num3 = num3 + 1 >> 1;
					if (ptr[1440].liquid != num3)
					{
						ptr[1440].liquid = (byte)num3;
					}
					ptr[1440].lava = ptr->lava;
					if (ptr->liquid != num3 || ptr[1440].liquid != num3)
					{
						AddWater(x + 1, y);
					}
					ptr->liquid = (byte)num3;
				}
			}
			if (ptr->liquid != num2)
			{
				if (ptr->liquid == 254 && num2 == 255)
				{
					ptr->liquid = byte.MaxValue;
					kill++;
				}
				else
				{
					AddWater(x, y - 1);
					kill = 0;
				}
			}
			else
			{
				kill++;
			}
		}
	}

	public static void StartPanic()
	{
		if (!panicMode)
		{
			WorldGen.waterLine = Main.maxTilesY;
			numLiquid = 0;
			LiquidBuffer.numLiquidBuffer = 0;
			panicCounter = 0;
			panicMode = true;
			panicY = Main.maxTilesY - 3;
		}
	}

	public static void UpdateLiquid()
	{
		if (!WorldGen.gen)
		{
			if (!panicMode)
			{
				if (numLiquid + LiquidBuffer.numLiquidBuffer > 4000)
				{
					panicCounter++;
					if (panicCounter > 1800 || numLiquid + LiquidBuffer.numLiquidBuffer > 13500)
					{
						StartPanic();
					}
				}
				else
				{
					panicCounter = 0;
				}
			}
			if (panicMode)
			{
				int num = 0;
				while (panicY >= 3 && num < 5)
				{
					num++;
					QuickWater(0.0, panicY, panicY);
					panicY--;
					if (panicY < 3)
					{
						panicCounter = 0;
						panicMode = false;
						WorldGen.WaterCheck();
						if (Main.netMode == 2)
						{
							Netplay.ResetSections();
						}
					}
				}
				return;
			}
		}
		quickFall = quickSettle || numLiquid > 2000;
		int num2 = 4096 / cycles;
		int num3 = num2 * wetCounter;
		int num4 = num2 * ++wetCounter;
		if (wetCounter == cycles)
		{
			num4 = numLiquid;
		}
		if (num4 > numLiquid)
		{
			num4 = numLiquid;
			wetCounter = cycles;
		}
		if (quickFall)
		{
			for (int i = num3; i < num4; i++)
			{
				Main.liquid[i].delay = 10;
				Main.liquid[i].Update();
				Main.tile[Main.liquid[i].x, Main.liquid[i].y].skipLiquid = 0;
			}
		}
		else
		{
			for (int j = num3; j < num4; j++)
			{
				if (Main.tile[Main.liquid[j].x, Main.liquid[j].y].skipLiquid == 0)
				{
					Main.liquid[j].Update();
				}
				else
				{
					Main.tile[Main.liquid[j].x, Main.liquid[j].y].skipLiquid = 0;
				}
			}
		}
		if (wetCounter < cycles)
		{
			return;
		}
		wetCounter = 0;
		for (int num5 = numLiquid - 1; num5 >= 0; num5--)
		{
			if (Main.liquid[num5].kill > 3)
			{
				DelWater(num5);
			}
		}
		int num6 = 4096 - (4096 - numLiquid);
		int numLiquidBuffer = LiquidBuffer.numLiquidBuffer;
		if (num6 > numLiquidBuffer)
		{
			num6 = numLiquidBuffer;
		}
		numLiquidBuffer = (LiquidBuffer.numLiquidBuffer = numLiquidBuffer - num6);
		while (--num6 >= 0)
		{
			Main.tile[Main.liquidBuffer[numLiquidBuffer].x, Main.liquidBuffer[numLiquidBuffer].y].checkingLiquid = 0;
			AddWater(Main.liquidBuffer[numLiquidBuffer].x, Main.liquidBuffer[numLiquidBuffer].y);
			numLiquidBuffer++;
		}
		if (numLiquid > 0 && numLiquid > stuckAmount - 50 && numLiquid < stuckAmount + 50)
		{
			if (++stuckCount >= 10000)
			{
				stuck = true;
				for (int num7 = numLiquid - 1; num7 >= 0; num7--)
				{
					DelWater(num7);
				}
				stuck = false;
				stuckCount = 0;
			}
		}
		else
		{
			stuckCount = 0;
			stuckAmount = numLiquid;
		}
	}

	public unsafe static void AddWater(int x, int y)
	{
		if (x < 5 || y < 5 || x >= Main.maxTilesX - 5 || y >= Main.maxTilesY - 5)
		{
			return;
		}
		fixed (Tile* ptr = &Main.tile[x, y])
		{
			if (ptr->liquid == 0 || ptr->checkingLiquid != 0)
			{
				return;
			}
			if (numLiquid >= 4095)
			{
				LiquidBuffer.AddBuffer(x, y);
				return;
			}
			ptr->checkingLiquid = 64;
			Main.liquid[numLiquid].Init(x, y);
			ptr->skipLiquid = 0;
			numLiquid++;
			if (Main.netMode == 2 && numLiquid < 1365)
			{
				NetMessage.sendWater(x, y);
			}
			if (ptr->active == 0)
			{
				return;
			}
			int type = ptr->type;
			if ((type != 4 || ptr->frameY != 176) && (Main.tileWaterDeath[type] || (ptr->lava != 0 && Main.tileLavaDeath[type])))
			{
				if (WorldGen.gen)
				{
					ptr->active = 0;
				}
				else if (WorldGen.KillTile(x, y) && Main.netMode == 2)
				{
					NetMessage.CreateMessage5(17, 0, x, y, 0);
					NetMessage.SendMessage();
				}
			}
		}
	}

	public static void LavaCheck(int x, int y)
	{
		int liquid = Main.tile[x, y - 1].liquid;
		bool flag = Main.tile[x, y - 1].lava == 0;
		int liquid2 = Main.tile[x - 1, y].liquid;
		bool flag2 = Main.tile[x - 1, y].lava == 0;
		int liquid3 = Main.tile[x + 1, y].liquid;
		bool flag3 = Main.tile[x + 1, y].lava == 0;
		if ((liquid2 > 0 && flag2) || (liquid3 > 0 && flag3) || (liquid > 0 && flag))
		{
			int num = 0;
			if (flag2)
			{
				num = liquid2;
				Main.tile[x - 1, y].liquid = 0;
			}
			if (flag3)
			{
				num += liquid3;
				Main.tile[x + 1, y].liquid = 0;
			}
			if (flag)
			{
				num += liquid;
				Main.tile[x, y - 1].liquid = 0;
			}
			if (num >= 32 && Main.tile[x, y].active == 0)
			{
				Main.tile[x, y].liquid = 0;
				Main.tile[x, y].lava = 0;
				WorldGen.PlaceTile(x, y, 56, mute: true, forced: true);
				WorldGen.SquareTileFrame(x, y);
				if (Main.netMode == 2)
				{
					NetMessage.SendTileSquare(x - 1, y - 1, 3);
				}
			}
		}
		else if (Main.tile[x, y + 1].active == 0 && Main.tile[x, y + 1].liquid > 0 && Main.tile[x, y + 1].lava == 0)
		{
			Main.tile[x, y].liquid = 0;
			Main.tile[x, y].lava = 0;
			Main.tile[x, y + 1].liquid = 0;
			WorldGen.PlaceTile(x, y + 1, 56, mute: true, forced: true);
			WorldGen.SquareTileFrame(x, y + 1);
			if (Main.netMode == 2)
			{
				NetMessage.SendTileSquare(x - 1, y, 3);
			}
		}
	}

	public unsafe static void DelWater(int l)
	{
		int num = Main.liquid[l].x;
		int num2 = Main.liquid[l].y;
		fixed (Tile* ptr = &Main.tile[num, num2])
		{
			int num3 = ptr->liquid;
			if (num3 < 2)
			{
				ptr->liquid = 0;
				num3 = 0;
				if (ptr[-1440].liquid == 1)
				{
					ptr[-1440].liquid = 0;
				}
				if (ptr[1440].liquid == 1)
				{
					ptr[1440].liquid = 0;
				}
			}
			else if (num3 < 20)
			{
				if ((ptr[1].liquid < byte.MaxValue && (ptr[1].active == 0 || !Main.tileSolidNotSolidTop[ptr[1].type])) || (ptr[-1440].liquid < num3 && (ptr[-1440].active == 0 || !Main.tileSolidNotSolidTop[ptr[-1440].type])) || (ptr[1440].liquid < num3 && (ptr[1440].active == 0 || !Main.tileSolidNotSolidTop[ptr[1440].type])))
				{
					ptr->liquid = 0;
					num3 = 0;
				}
			}
			else if (ptr[1].liquid < byte.MaxValue && (ptr[1].active == 0 || !Main.tileSolidNotSolidTop[ptr[1].type]) && !stuck)
			{
				Main.liquid[l].kill = 0;
				return;
			}
			if (num3 < 250 && ptr[-1].liquid > 0)
			{
				AddWater(num, num2 - 1);
			}
			if (num3 == 0)
			{
				ptr->lava = 0;
			}
			else
			{
				if ((ptr[1440].liquid > 0 && ptr[1441].liquid < 250 && ptr[1441].active == 0) || (ptr[-1440].liquid > 0 && ptr[-1439].liquid < 250 && ptr[-1439].active == 0))
				{
					AddWater(num - 1, num2);
					AddWater(num + 1, num2);
				}
				if (ptr->lava != 0)
				{
					LavaCheck(num, num2);
					for (int i = num - 1; i <= num + 1; i++)
					{
						for (int j = num2 - 1; j <= num2 + 1; j++)
						{
							if (Main.tile[i, j].active == 0)
							{
								continue;
							}
							switch (Main.tile[i, j].type)
							{
							case 2:
							case 23:
							case 109:
								Main.tile[i, j].type = 0;
								WorldGen.SquareTileFrame(i, j);
								if (Main.netMode == 2)
								{
									NetMessage.SendTileSquare(num, num2, 3);
								}
								break;
							case 60:
							case 70:
								Main.tile[i, j].type = 59;
								WorldGen.SquareTileFrame(i, j);
								if (Main.netMode == 2)
								{
									NetMessage.SendTileSquare(num, num2, 3);
								}
								break;
							}
						}
					}
				}
			}
			if (Main.netMode == 2)
			{
				NetMessage.sendWater(num, num2);
			}
			numLiquid--;
			ptr->checkingLiquid = 0;
			Main.liquid[l].x = Main.liquid[numLiquid].x;
			Main.liquid[l].y = Main.liquid[numLiquid].y;
			Main.liquid[l].kill = Main.liquid[numLiquid].kill;
			if (ptr->type >= 82 && ptr->type <= 84)
			{
				WorldGen.CheckAlch(num, num2);
			}
		}
	}
}
