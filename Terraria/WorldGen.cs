using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Terraria.Achievements;

namespace Terraria
{
	internal static class WorldGen
	{
		public sealed class FallingSandBuffer
		{
			public int count;

			public Location[] buffer = new Location[64];

			public unsafe void Add(int i, int j)
			{
				fixed (Location* ptr = &buffer[count])
				{
					ptr->X = (short)i;
					ptr->Y = (short)j;
				}
				count++;
			}
		}

		private struct DRoom
		{
			public short X;

			public short Y;

			public short L;

			public short R;

			public short T;

			public short B;

			public float Size;
		}

		private struct DDoor
		{
			public short X;

			public short Y;

			public short Pos;
		}

		public const int MAX_MECH = 1000;

		public const int MAX_WIRE = 1000;

		public const int MAX_PUMP = 20;

		private const float CorruptionFactorForAchievement = 50f;

		private const float HallowedFactorForAchievement = 50f;

		private const int SAND_BUFFER_SIZE = 64;

		public const int MAX_ROOM_RECURSION = 400;

		public const int MAX_ROOM_TILES = 1900;

		public const int MIN_ROOM_TILES = 60;

		public const int MAX_DROOMS = 100;

		private const int MAX_DDOORS = 300;

		private const int MAX_DPLATS = 300;

		private const int MIN_JCHEST = 6;

		private const int MAX_JCHEST = 9;

		private const double JCHEST_WORLD_SIZE_MODIFIER = 1.2;

		public static int numMechs = 0;

		public static Mech[] mech = new Mech[1000];

		public static int numWire = 0;

		public static Location[] wire = new Location[1000];

		public static int numNoWire = 0;

		public static Location[] noWire = new Location[1000];

		public static int numInPump = 0;

		public static Location[] inPump = new Location[20];

		public static int numOutPump = 0;

		public static Location[] outPump = new Location[20];

		public static int totalEvil = 0;

		public static int totalGood = 0;

		public static int totalSolid = 0;

		public static int totalEvil2 = 0;

		public static int totalGood2 = 0;

		public static int totalSolid2 = 0;

		public static byte tEvil = 0;

		public static byte tGood = 0;

		public static int totalX = 0;

		public static int totalD = 0;

		private static int currentSandBuffer = 0;

		private static FallingSandBuffer[] sandBuffer = new FallingSandBuffer[2];

		public static volatile bool hardLock = false;

		public static volatile bool saveLock = false;

		private static object padlock = new object();

		public static uint woodSpawned = 0u;

		public static int lavaLine;

		public static int waterLine;

		public static int shadowOrbCount = 0;

		public static int altarCount = 0;

		public static bool spawnEye = false;

		public static bool gen = false;

		public static bool shadowOrbSmashed = false;

		public static bool spawnMeteor = false;

		private static short lastMaxTilesX = 0;

		private static short lastMaxTilesY = 0;

		public static Time tempTime = default(Time);

		private static bool stopDrops = false;

		private static bool mudWall = false;

		private static int grassSpread = 0;

		public static bool noLiquidCheck = false;

		public static bool destroyObject = false;

		public static FastRandom genRand = new FastRandom();

		public static int spawnDelay = 0;

		public static int spawnNPC = 0;

		public static int numRoomTiles;

		public static Location[] room = new Location[1900];

		public static int roomX1;

		public static int roomX2;

		public static int roomY1;

		public static int roomY2;

		public static bool canSpawn;

		public static bool[] houseTile = new bool[150];

		public static int bestX = 0;

		public static int bestY = 0;

		public static int hiScore = 0;

		public static int dungeonX;

		public static int dungeonY;

		public static Vector2i lastDungeonHall = default(Vector2i);

		public static int numDRooms = 0;

		private static DRoom[] dRoom = new DRoom[100];

		private static int numDDoors;

		private static DDoor[] dDoor = new DDoor[300];

		private static int numDPlats;

		private static Location[] DPlat = new Location[300];

		private static int numJChests = 0;

		private static Location[] JChest = new Location[10];

		public static int dEnteranceX = 0;

		public static bool dSurface = false;

		private static double dxStrength1;

		private static double dyStrength1;

		private static double dxStrength2;

		private static double dyStrength2;

		private static int dMinX;

		private static int dMaxX;

		private static int dMinY;

		private static int dMaxY;

		private static int numIslandHouses = 0;

		private static int houseCount = 0;

		private static Location[] fih = new Location[300];

		private static int numMCaves = 0;

		private static Location[] mCave = new Location[300];

		private static int JungleX = 0;

		private static int hellChest = 0;

		private static bool roomTorch;

		private static bool roomDoor;

		public static bool roomChair;

		private static bool roomTable;

		private static bool roomOccupied;

		private static bool roomEvil;

		private static int checkRoomDepth;

		private static bool mergeUp;

		private static bool mergeDown;

		private static bool mergeLeft;

		private static bool mergeRight;

		private static bool tileFrameRecursion = true;

		private static bool mergeUp2;

		private static bool mergeDown2;

		private static bool mergeLeft2;

		private static bool mergeRight2;

		public unsafe static void UpdateSand()
		{
			FallingSandBuffer fallingSandBuffer = sandBuffer[currentSandBuffer];
			int count = fallingSandBuffer.count;
			if (count > 0)
			{
				fallingSandBuffer.count = 0;
				currentSandBuffer ^= 1;
				int num = 0;
				do
				{
					int x = fallingSandBuffer.buffer[num].X;
					int y = fallingSandBuffer.buffer[num].Y;
					try
					{
						fixed (Tile* ptr = &Main.tile[x, y])
						{
							ptr->active = 0;
							int type;
							switch (ptr->type)
							{
							case 112:
								type = 56;
								break;
							case 116:
								type = 67;
								break;
							case 123:
								type = 71;
								break;
							default:
								type = 31;
								break;
							}
							int num2 = Projectile.NewProjectile(x * 16 + 8, y * 16 + 8, 0f, 2.5f, type, 10, 0f);
							if (num2 < 0)
							{
								return;
							}
							Main.projectile[num2].velocity.Y = 0.5f;
							Main.projectile[num2].position.Y += 2f;
							Main.projectile[num2].aabb.Y += 2;
							tileFrameRecursion = false;
							TileFrame(x, y - 1);
							TileFrame(x - 1, y);
							TileFrame(x + 1, y);
							tileFrameRecursion = true;
							NetMessage.SendTile(x, y);
						}
					}
					finally
					{
					}
				}
				while (++num < count);
			}
		}

		public static bool MoveNPC(int x, int y, int n)
		{
			if (!StartRoomCheck(x, y))
			{
				Main.NewText(Lang.inter[40], 255, 240, 20);
				return false;
			}
			if (!RoomNeeds())
			{
				if (Lang.lang <= 1)
				{
					int num = 0;
					string[] array = new string[4];
					if (!roomTorch)
					{
						array[num] = "a light source";
						num++;
					}
					if (!roomDoor)
					{
						array[num] = "a door";
						num++;
					}
					if (!roomTable)
					{
						array[num] = "a table";
						num++;
					}
					if (!roomChair)
					{
						array[num] = "a chair";
						num++;
					}
					string text = "";
					for (int i = 0; i < num; i++)
					{
						if (num == 2 && i == 1)
						{
							text += " and ";
						}
						else if (i > 0 && i != num - 1)
						{
							text += ", and ";
						}
						else if (i > 0)
						{
							text += ", ";
						}
						text += array[i];
					}
					Main.NewText("This housing is missing " + text + ".", 255, 240, 20);
				}
				else
				{
					Main.NewText(Lang.inter[8], 255, 240, 20);
				}
				return false;
			}
			ScoreRoom();
			if (hiScore <= 0)
			{
				if (roomOccupied)
				{
					Main.NewText(Lang.inter[41], 255, 240, 20);
				}
				else if (roomEvil)
				{
					Main.NewText(Lang.inter[42], 255, 240, 20);
				}
				else
				{
					Main.NewText(Lang.inter[8], 255, 240, 20);
				}
				return false;
			}
			return true;
		}

		public static void moveRoom(int x, int y, int n)
		{
			if (Main.netMode >= 1)
			{
				NetMessage.CreateMessage4(60, n, x, y, 1);
				NetMessage.SendMessage();
			}
			else
			{
				spawnNPC = Main.npc[n].type;
				Main.npc[n].homeless = true;
				SpawnNPC(x, y);
			}
		}

		public static void kickOut(int n)
		{
			if (Main.netMode >= 1)
			{
				NetMessage.CreateMessage4(60, n, 0, 0, 0);
				NetMessage.SendMessage();
			}
			else
			{
				Main.npc[n].homeless = true;
			}
		}

		public static void SpawnNPC(int x, int y)
		{
			if (Main.wallHouse[Main.tile[x, y].wall])
			{
				canSpawn = true;
			}
			else if (!canSpawn)
			{
				return;
			}
			if (!StartRoomCheck(x, y) || !RoomNeeds())
			{
				return;
			}
			ScoreRoom();
			if (hiScore <= 0)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < 196; i++)
			{
				if (Main.npc[i].active != 0 && Main.npc[i].homeless && Main.npc[i].type == spawnNPC)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				int num2 = bestX;
				int num3 = bestY;
				bool flag = false;
				if (!flag)
				{
					flag = true;
					Rectangle value = new Rectangle(num2 * 16 + 8 - 960 - 62, num3 * 16 + 8 - 540 - 34, 2044, 1148);
					for (int j = 0; j < 8; j++)
					{
						if (Main.player[j].active != 0 && Main.player[j].aabb.Intersects(value))
						{
							flag = false;
							break;
						}
					}
				}
				if (!flag && num3 <= Main.worldSurface)
				{
					for (int k = 1; k < 500; k++)
					{
						for (int l = 0; l < 2; l++)
						{
							num2 = ((l != 0) ? (bestX - k) : (bestX + k));
							if (num2 > 10 && num2 < Main.maxTilesX - 10)
							{
								int num4 = bestY - k;
								double num5 = bestY + k;
								if (num4 < 10)
								{
									num4 = 10;
								}
								if (num5 > (double)Main.worldSurface)
								{
									num5 = Main.worldSurface;
								}
								for (int m = num4; (double)m < num5; m++)
								{
									num3 = m;
									if (Main.tile[num2, num3].active == 0 || !Main.tileSolid[Main.tile[num2, num3].type])
									{
										continue;
									}
									if (Collision.SolidTiles(num2 - 1, num2 + 1, num3 - 3, num3 - 1))
									{
										break;
									}
									flag = true;
									Rectangle value2 = new Rectangle(num2 * 16 + 8 - 960 - 62, num3 * 16 + 8 - 540 - 34, 2044, 1148);
									for (int n = 0; n < 8; n++)
									{
										if (Main.player[n].active != 0 && Main.player[n].aabb.Intersects(value2))
										{
											flag = false;
											break;
										}
									}
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
				int num6 = NPC.NewNPC(num2 * 16, num3 * 16, spawnNPC, 1);
				Main.npc[num6].homeTileX = (short)bestX;
				Main.npc[num6].homeTileY = (short)bestY;
				if (num2 < bestX)
				{
					Main.npc[num6].direction = 1;
				}
				else if (num2 > bestX)
				{
					Main.npc[num6].direction = -1;
				}
				Main.npc[num6].netUpdate = true;
				string text;
				if (Main.npc[num6].hasName())
				{
					text = Main.npc[num6].getName();
					if (Lang.lang <= 1)
					{
						text = text + " the " + Main.npc[num6].name;
					}
				}
				else
				{
					text = Main.npc[num6].displayName;
				}
				NetMessage.SendText(text, 18, 50, 125, 255, -1);
			}
			else
			{
				Main.npc[num].homeTileX = (short)bestX;
				Main.npc[num].homeTileY = (short)bestY;
				Main.npc[num].homeless = false;
			}
			if (!Main.IsTutorial())
			{
				if (spawnNPC == 22)
				{
					UI.SetTriggerStateForAll(Trigger.HouseGuide);
				}
				CheckHousedNPCs();
			}
			spawnNPC = 0;
		}

		public static void CheckHousedNPCs()
		{
			bool flag = true;
			int num = 0;
			for (int i = 0; i < 196; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active != 0 && nPC.townNPC && nPC.type != 37 && nPC.type != 142)
				{
					flag = (flag && !nPC.homeless);
					num++;
				}
			}
			if (flag && num == 10)
			{
				UI.SetTriggerStateForAll(Trigger.HousedAllNPCs);
			}
		}

		public static bool RoomNeeds()
		{
			roomChair = false;
			roomDoor = false;
			roomTable = false;
			roomTorch = false;
			if (houseTile[15] || houseTile[79] || houseTile[89] || houseTile[102])
			{
				roomChair = true;
			}
			if (houseTile[14] || houseTile[18] || houseTile[87] || houseTile[88] || houseTile[90] || houseTile[101])
			{
				roomTable = true;
			}
			if (houseTile[4] || houseTile[33] || houseTile[34] || houseTile[35] || houseTile[36] || houseTile[42] || houseTile[49] || houseTile[93] || houseTile[95] || houseTile[98] || houseTile[100] || houseTile[149])
			{
				roomTorch = true;
			}
			if (houseTile[10] || houseTile[11] || houseTile[19])
			{
				roomDoor = true;
			}
			if (roomChair && roomTable && roomDoor && roomTorch)
			{
				canSpawn = true;
			}
			else
			{
				canSpawn = false;
			}
			return canSpawn;
		}

		public static void QuickFindHome(int npc)
		{
			if (Main.npc[npc].homeTileX <= 10 || Main.npc[npc].homeTileY <= 10 || Main.npc[npc].homeTileX >= Main.maxTilesX - 10 || Main.npc[npc].homeTileY >= Main.maxTilesY)
			{
				return;
			}
			canSpawn = false;
			StartRoomCheck(Main.npc[npc].homeTileX, Main.npc[npc].homeTileY - 1);
			if (!canSpawn)
			{
				for (int i = Main.npc[npc].homeTileX - 1; i < Main.npc[npc].homeTileX + 2; i++)
				{
					for (int j = Main.npc[npc].homeTileY - 1; j < Main.npc[npc].homeTileY + 2 && !StartRoomCheck(i, j); j++)
					{
					}
				}
			}
			if (!canSpawn)
			{
				int num = 10;
				for (int k = Main.npc[npc].homeTileX - num; k <= Main.npc[npc].homeTileX + num; k += 2)
				{
					for (int l = Main.npc[npc].homeTileY - num; l <= Main.npc[npc].homeTileY + num && !StartRoomCheck(k, l); l += 2)
					{
					}
				}
			}
			if (canSpawn)
			{
				RoomNeeds();
				if (canSpawn)
				{
					ScoreRoom(npc);
				}
				if (canSpawn && hiScore > 0)
				{
					Main.npc[npc].homeTileX = (short)bestX;
					Main.npc[npc].homeTileY = (short)bestY;
					Main.npc[npc].homeless = false;
					canSpawn = false;
				}
				else
				{
					Main.npc[npc].homeless = true;
				}
			}
			else
			{
				Main.npc[npc].homeless = true;
			}
		}

		public static void ScoreRoom(int ignoreNPC = -1)
		{
			roomOccupied = false;
			roomEvil = false;
			for (int i = 0; i < 196; i++)
			{
				if (Main.npc[i].active == 0 || !Main.npc[i].townNPC || ignoreNPC == i || Main.npc[i].homeless)
				{
					continue;
				}
				for (int j = 0; j < numRoomTiles; j++)
				{
					if (Main.npc[i].homeTileX != room[j].X || Main.npc[i].homeTileY != room[j].Y)
					{
						continue;
					}
					bool flag = false;
					for (int k = 0; k < numRoomTiles; k++)
					{
						if (Main.npc[i].homeTileX == room[k].X && Main.npc[i].homeTileY - 1 == room[k].Y)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						roomOccupied = true;
						hiScore = -1;
						return;
					}
				}
			}
			hiScore = 0;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = roomX1 - 3 - 1 - 34;
			int num5 = roomX2 + 3 + 1 + 34;
			int num6 = roomY1 - 2 - 1 - 34;
			int num7 = roomY2 + 2 + 1 + 34;
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 >= Main.maxTilesX)
			{
				num5 = Main.maxTilesX - 1;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			if (num7 > Main.maxTilesX)
			{
				num7 = Main.maxTilesX;
			}
			for (int l = num4 + 1; l < num5; l++)
			{
				for (int m = num6 + 2; m < num7 + 2; m++)
				{
					if (Main.tile[l, m].active != 0)
					{
						if (Main.tile[l, m].type == 23 || Main.tile[l, m].type == 24 || Main.tile[l, m].type == 25 || Main.tile[l, m].type == 32 || Main.tile[l, m].type == 112)
						{
							num3++;
						}
						else if (Main.tile[l, m].type == 27)
						{
							num3 -= 5;
						}
						else if (Main.tile[l, m].type == 109 || Main.tile[l, m].type == 110 || Main.tile[l, m].type == 113 || Main.tile[l, m].type == 116)
						{
							num3--;
						}
					}
				}
			}
			if (num3 < 50)
			{
				num3 = 0;
			}
			num2 = -num3;
			if (num2 <= -250)
			{
				hiScore = num2;
				roomEvil = true;
				return;
			}
			num4 = roomX1;
			num5 = roomX2;
			num6 = roomY1;
			num7 = roomY2;
			for (int n = num4 + 1; n < num5; n++)
			{
				for (int num8 = num6 + 2; num8 < num7 + 2; num8++)
				{
					if (Main.tile[n, num8].active == 0)
					{
						continue;
					}
					num = num2;
					if (!Main.tileSolidNotSolidTop[Main.tile[n, num8].type] || Collision.SolidTiles(n - 1, n + 1, num8 - 3, num8 - 1) || Main.tile[n - 1, num8].active == 0 || !Main.tileSolid[Main.tile[n - 1, num8].type] || Main.tile[n + 1, num8].active == 0 || !Main.tileSolid[Main.tile[n + 1, num8].type])
					{
						continue;
					}
					for (int num9 = n - 2; num9 < n + 3; num9++)
					{
						for (int num10 = num8 - 4; num10 < num8; num10++)
						{
							if (Main.tile[num9, num10].active != 0)
							{
								num = ((num9 != n) ? ((Main.tile[num9, num10].type != 10 && Main.tile[num9, num10].type != 11) ? ((!Main.tileSolid[Main.tile[num9, num10].type]) ? (num + 5) : (num - 5)) : (num - 20)) : (num - 15));
							}
						}
					}
					if (num <= hiScore)
					{
						continue;
					}
					bool flag2 = false;
					for (int num11 = 0; num11 < numRoomTiles; num11++)
					{
						if (room[num11].X == n && room[num11].Y == num8)
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						hiScore = num;
						bestX = n;
						bestY = num8;
					}
				}
			}
		}

		public static bool StartRoomCheck(int x, int y)
		{
			roomX1 = x;
			roomX2 = x;
			roomY1 = y;
			roomY2 = y;
			numRoomTiles = 0;
			for (int i = 0; i < 150; i++)
			{
				houseTile[i] = false;
			}
			canSpawn = true;
			if (Main.tile[x, y].active != 0 && Main.tileSolid[Main.tile[x, y].type])
			{
				canSpawn = false;
			}
			else
			{
				checkRoomDepth = 0;
				CheckRoom(x, y);
				if (numRoomTiles < 60)
				{
					canSpawn = false;
				}
			}
			return canSpawn;
		}

		public static void CheckRoom(int x, int y)
		{
			if (x < 10 || y < 10 || x >= Main.maxTilesX - 10 || y >= lastMaxTilesY - 10)
			{
				canSpawn = false;
				return;
			}
			for (int i = 0; i < numRoomTiles; i++)
			{
				if (room[i].X == x && room[i].Y == y)
				{
					return;
				}
			}
			room[numRoomTiles].X = (short)x;
			room[numRoomTiles].Y = (short)y;
			if (++numRoomTiles >= 1900)
			{
				canSpawn = false;
				return;
			}
			if (++checkRoomDepth >= 400)
			{
				canSpawn = false;
				return;
			}
			if (Main.tile[x, y].active != 0)
			{
				houseTile[Main.tile[x, y].type] = true;
				if (Main.tileSolid[Main.tile[x, y].type] || Main.tile[x, y].type == 11)
				{
					checkRoomDepth--;
					return;
				}
			}
			if (x < roomX1)
			{
				roomX1 = x;
			}
			if (x > roomX2)
			{
				roomX2 = x;
			}
			if (y < roomY1)
			{
				roomY1 = y;
			}
			if (y > roomY2)
			{
				roomY2 = y;
			}
			int num = 0;
			for (int j = -2; j < 3; j++)
			{
				if (Main.wallHouse[Main.tile[x + j, y].wall])
				{
					num |= 1;
				}
				else if (Main.tile[x + j, y].active != 0 && (Main.tileSolid[Main.tile[x + j, y].type] || Main.tile[x + j, y].type == 11))
				{
					num |= 1;
				}
				if (Main.wallHouse[Main.tile[x, y + j].wall])
				{
					num |= 2;
				}
				else if (Main.tile[x, y + j].active != 0 && (Main.tileSolid[Main.tile[x, y + j].type] || Main.tile[x, y + j].type == 11))
				{
					num |= 2;
				}
			}
			if (num != 3)
			{
				canSpawn = false;
				return;
			}
			CheckRoom(x, y - 1);
			if (!canSpawn)
			{
				return;
			}
			CheckRoom(x, y + 1);
			if (!canSpawn)
			{
				return;
			}
			CheckRoom(x - 1, y - 1);
			if (!canSpawn)
			{
				return;
			}
			CheckRoom(x - 1, y);
			if (!canSpawn)
			{
				return;
			}
			CheckRoom(x - 1, y + 1);
			if (!canSpawn)
			{
				return;
			}
			CheckRoom(x + 1, y - 1);
			if (canSpawn)
			{
				CheckRoom(x + 1, y);
				if (canSpawn)
				{
					CheckRoom(x + 1, y + 1);
					checkRoomDepth--;
				}
			}
		}

		public static bool StartSpaceCheck(int x, int y)
		{
			roomX1 = x;
			roomX2 = x;
			roomY1 = y;
			roomY2 = y;
			numRoomTiles = 0;
			for (int i = 0; i < 150; i++)
			{
				houseTile[i] = false;
			}
			canSpawn = true;
			if (Main.tile[x, y].active != 0 && Main.tileSolid[Main.tile[x, y].type])
			{
				canSpawn = false;
			}
			else
			{
				checkRoomDepth = 0;
				CheckSpace(x, y);
				if (numRoomTiles < 60)
				{
					canSpawn = false;
				}
			}
			return canSpawn;
		}

		public static void CheckSpace(int x, int y)
		{
			if (x < 10 || y < 10 || x >= Main.maxTilesX - 10 || y >= lastMaxTilesY - 10)
			{
				canSpawn = false;
				return;
			}
			for (int i = 0; i < numRoomTiles; i++)
			{
				if (room[i].X == x && room[i].Y == y)
				{
					return;
				}
			}
			room[numRoomTiles].X = (short)x;
			room[numRoomTiles].Y = (short)y;
			if (++numRoomTiles >= 1900)
			{
				canSpawn = false;
				return;
			}
			if (++checkRoomDepth >= 400)
			{
				canSpawn = false;
				return;
			}
			if (Main.tile[x, y].active != 0)
			{
				houseTile[Main.tile[x, y].type] = true;
				if (Main.tileSolid[Main.tile[x, y].type] || Main.tile[x, y].type == 11)
				{
					checkRoomDepth--;
					return;
				}
			}
			if (x < roomX1)
			{
				roomX1 = x;
			}
			if (x > roomX2)
			{
				roomX2 = x;
			}
			if (y < roomY1)
			{
				roomY1 = y;
			}
			if (y > roomY2)
			{
				roomY2 = y;
			}
			CheckSpace(x, y - 1);
			if (!canSpawn)
			{
				return;
			}
			CheckSpace(x, y + 1);
			if (!canSpawn)
			{
				return;
			}
			CheckSpace(x - 1, y - 1);
			if (!canSpawn)
			{
				return;
			}
			CheckSpace(x - 1, y);
			if (!canSpawn)
			{
				return;
			}
			CheckSpace(x - 1, y + 1);
			if (!canSpawn)
			{
				return;
			}
			CheckSpace(x + 1, y - 1);
			if (canSpawn)
			{
				CheckSpace(x + 1, y);
				if (canSpawn)
				{
					CheckSpace(x + 1, y + 1);
					checkRoomDepth--;
				}
			}
		}

		public static void dropMeteor()
		{
			bool flag = true;
			int num = 0;
			if (Main.netMode == 1)
			{
				return;
			}
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[i].active != 0)
				{
					flag = false;
					break;
				}
			}
			int num2 = 0;
			float num3 = (float)Main.maxTilesX * 0.000238095236f;
			int num4 = (int)(400f * num3);
			for (int j = 5; j < Main.maxTilesX - 5; j++)
			{
				for (int k = 5; k < Main.worldSurface; k++)
				{
					if (Main.tile[j, k].active != 0 && Main.tile[j, k].type == 37)
					{
						num2++;
						if (num2 > num4)
						{
							return;
						}
					}
				}
			}
			while (!flag)
			{
				float num5 = (float)Main.maxTilesX * 0.08f;
				int num6 = Main.rand.Next(50, Main.maxTilesX - 50);
				while ((float)num6 > (float)Main.spawnTileX - num5 && (float)num6 < (float)Main.spawnTileX + num5)
				{
					num6 = Main.rand.Next(50, Main.maxTilesX - 50);
				}
				for (int l = Main.rand.Next(100); l < Main.maxTilesY; l++)
				{
					if (Main.tile[num6, l].active != 0 && Main.tileSolid[Main.tile[num6, l].type])
					{
						flag = meteor(num6, l);
						break;
					}
				}
				num++;
				if (num >= 100)
				{
					break;
				}
			}
		}

		public static bool meteor(int i, int j)
		{
			if (i < 50 || i > Main.maxTilesX - 50)
			{
				return false;
			}
			if (j < 50 || j > Main.maxTilesY - 50)
			{
				return false;
			}
			Rectangle rectangle = new Rectangle((i - 25) * 16, (j - 25) * 16, 800, 800);
			for (int k = 0; k < 8; k++)
			{
				if (Main.player[k].active != 0)
				{
					Rectangle value = new Rectangle(Main.player[k].aabb.X + 10 - 960 - 62, Main.player[k].aabb.Y + 21 - 540 - 34, 2044, 1148);
					if (rectangle.Intersects(value))
					{
						return false;
					}
				}
			}
			for (int l = 0; l < 196; l++)
			{
				if (Main.npc[l].active != 0 && rectangle.Intersects(Main.npc[l].aabb))
				{
					return false;
				}
			}
			for (int m = i - 25; m < i + 25; m++)
			{
				for (int n = j - 25; n < j + 25; n++)
				{
					if (Main.tile[m, n].type == 21 && Main.tile[m, n].active != 0)
					{
						return false;
					}
				}
			}
			stopDrops = true;
			for (int num = i - 15; num < i + 15; num++)
			{
				for (int num2 = j - 15; num2 < j + 15; num2++)
				{
					if (num2 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num) + Math.Abs(j - num2) < 22 + Main.rand.Next(-5, 5))
					{
						if (!Main.tileSolid[Main.tile[num, num2].type])
						{
							Main.tile[num, num2].active = 0;
						}
						Main.tile[num, num2].type = 37;
					}
				}
			}
			for (int num3 = i - 10; num3 < i + 10; num3++)
			{
				for (int num4 = j - 10; num4 < j + 10; num4++)
				{
					if (num4 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num3) + Math.Abs(j - num4) < 10 + Main.rand.Next(-3, 4))
					{
						Main.tile[num3, num4].active = 0;
					}
				}
			}
			for (int num5 = i - 16; num5 < i + 16; num5++)
			{
				for (int num6 = j - 16; num6 < j + 16; num6++)
				{
					int type = Main.tile[num5, num6].type;
					if (type == 5 || type == 32)
					{
						KillTile(num5, num6);
					}
					SquareTileFrame(num5, num6);
					SquareWallFrame(num5, num6);
				}
			}
			for (int num7 = i - 23; num7 < i + 23; num7++)
			{
				for (int num8 = j - 23; num8 < j + 23; num8++)
				{
					if (Main.tile[num7, num8].active != 0 && Main.rand.Next(10) == 0 && (float)(Math.Abs(i - num7) + Math.Abs(j - num8)) < 29.9f)
					{
						if (Main.tile[num7, num8].type == 5 || Main.tile[num7, num8].type == 32)
						{
							KillTile(num7, num8);
						}
						Main.tile[num7, num8].type = 37;
						SquareTileFrame(num7, num8);
					}
				}
			}
			stopDrops = false;
			NetMessage.SendText(36, 50, 255, 130, -1);
			NetMessage.SendTileSquare(i, j, 30);
			return true;
		}

		public static void setWorldSize()
		{
			Main.bottomWorld = Main.maxTilesY * 16;
			Main.rightWorld = Main.maxTilesX * 16;
			Main.maxSectionsX = Main.maxTilesX / 40;
			Main.maxSectionsY = Main.maxTilesY / 30;
		}

		public static void worldGenCallBack()
		{
			Thread.CurrentThread.SetProcessorAffinity(5);
			clearWorld();
			generateWorld();
			everyTileFrame();
			saveWorldWhilePlaying();
			Main.StartGame();
			Main.worldGenThread = null;
		}

		public static void CreateNewWorld()
		{
			Netplay.StopFindingSessions();
			Thread thread = new Thread(worldGenCallBack);
			thread.IsBackground = true;
			thread.Start();
			Main.worldGenThread = thread;
		}

		public static void SaveAndQuit()
		{
			Main.PlaySound(11);
			Thread thread = new Thread(SaveAndQuitCallBack);
			thread.Start();
		}

		public static void SaveAndQuitCallBack()
		{
			Thread.CurrentThread.SetProcessorAffinity(4);
			Main.isGameStarted = false;
			for (int i = 0; i < 4; i++)
			{
				UI uI = Main.ui[i];
				if (uI.isStopping)
				{
					uI.player.active = 0;
					uI.player.Save(uI.playerPathName);
					uI.SaveSettings();
				}
			}
			int netMode = Main.netMode;
			Netplay.disconnect = true;
			if (netMode != 1 && UI.main.HasPlayerStorage())
			{
				for (int j = 0; j < 4; j++)
				{
					UI uI2 = Main.ui[j];
					if (uI2.isStopping)
					{
						uI2.statusText = Lang.gen[49];
					}
				}
				saveNewWorld();
			}
			for (int k = 0; k < 4; k++)
			{
				UI uI3 = Main.ui[k];
				if (!uI3.isStopping)
				{
					continue;
				}
				uI3.isStopping = false;
				if (uI3.signedInGamer != null)
				{
					uI3.LoadPlayers();
					if (uI3.menuMode != MenuMode.ERROR)
					{
						uI3.SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
					}
				}
			}
		}

		public static void playWorldCallBack()
		{
			Thread.CurrentThread.SetProcessorAffinity(5);
			if (Main.IsTutorial())
			{
				using (Stream file = TitleContainer.OpenStream("Content/Worlds/tutorial.wld"))
				{
					loadWorld(file);
				}
				tempTime.reset(0.01f);
				Main.npc[0].position.Y -= 1120f;
				Main.npc[0].aabb.Y -= 1120;
				Main.npc[1].position.Y -= 1120f;
				Main.npc[1].aabb.Y -= 1120;
			}
			else
			{
				bool flag;
				try
				{
					using (StorageContainer storageContainer = UI.main.OpenPlayerStorage("Worlds"))
					{
						using (Stream file2 = storageContainer.OpenFile(WorldSelect.worldPathName, FileMode.Open))
						{
							flag = loadWorld(file2);
						}
					}
				}
				catch (ThreadAbortException)
				{
					flag = true;
				}
				catch (IOException)
				{
					UI.main.ReadError();
					flag = false;
				}
				catch (Exception)
				{
					flag = false;
				}
				if (!flag)
				{
					UI.main.SetMenu(MenuMode.LOAD_FAILED_NO_BACKUP, rememberPrevious: false);
					Main.worldGenThread = null;
					return;
				}
			}
			everyTileFrame();
			Main.StartGame();
			Main.worldGenThread = null;
		}

		public static void playWorld()
		{
			Netplay.StopFindingSessions();
			Thread thread = new Thread(playWorldCallBack);
			thread.Start();
			Main.worldGenThread = thread;
		}

		public static void saveWorldWhilePlayingCallBack()
		{
			Thread.CurrentThread.SetProcessorAffinity(4);
			saveNewWorld();
		}

		public static void saveWorldWhilePlaying()
		{
			if (UI.main.HasPlayerStorage())
			{
				Thread thread = new Thread(saveWorldWhilePlayingCallBack);
				thread.Start();
			}
		}

		public static void savePlayerWhilePlayingCallBack()
		{
			Thread.CurrentThread.SetProcessorAffinity(4);
			for (int i = 0; i < 4; i++)
			{
				UI uI = Main.ui[i];
				if (uI.menuType != 0)
				{
					uI.player.Save(uI.playerPathName);
					uI.SaveSettings();
				}
			}
		}

		public static void savePlayerWhilePlaying()
		{
			Thread thread = new Thread(savePlayerWhilePlayingCallBack);
			thread.Start();
		}

		public static void saveAllWhilePlayingCallBack()
		{
			Thread.CurrentThread.SetProcessorAffinity(4);
			if (Main.netMode != 1 && UI.main.HasPlayerStorage())
			{
				saveNewWorld();
			}
			for (int i = 0; i < 4; i++)
			{
				UI uI = Main.ui[i];
				if (uI.menuType != 0)
				{
					uI.player.Save(uI.playerPathName);
					uI.SaveSettings();
				}
			}
		}

		public static void saveAllWhilePlaying()
		{
			Thread thread = new Thread(saveAllWhilePlayingCallBack);
			thread.Start();
		}

		public static void clearWorld()
		{
			UI.main.statusText = Lang.gen[47];
			tempTime.reset(1f);
			totalSolid2 = 0;
			totalGood2 = 0;
			totalEvil2 = 0;
			totalSolid = 0;
			totalGood = 0;
			totalEvil = 0;
			totalX = 0;
			totalD = 0;
			tEvil = 0;
			tGood = 0;
			NPC.clrNames();
			spawnEye = false;
			spawnNPC = 0;
			shadowOrbCount = 0;
			altarCount = 0;
			Main.worldID = 0;
			Main.worldTimestamp = 0;
			Main.hardMode = false;
			Main.dungeonX = 0;
			Main.dungeonY = 0;
			NPC.downedBoss1 = false;
			NPC.downedBoss2 = false;
			NPC.downedBoss3 = false;
			NPC.savedGoblin = false;
			NPC.savedWizard = false;
			NPC.savedMech = false;
			NPC.downedGoblins = false;
			NPC.downedClown = false;
			NPC.downedFrost = false;
			shadowOrbSmashed = false;
			spawnMeteor = false;
			stopDrops = false;
			Main.invasionDelay = 0;
			Main.invasionType = 0;
			Main.invasionSize = 0;
			Main.invasionWarn = 0;
			Main.invasionX = 0f;
			Liquid.numLiquid = 0;
			LiquidBuffer.numLiquidBuffer = 0;
			sandBuffer[0] = new FallingSandBuffer();
			sandBuffer[1] = new FallingSandBuffer();
			if (lastMaxTilesX > Main.maxTilesX)
			{
				for (int i = Main.maxTilesX; i < lastMaxTilesX; i++)
				{
					for (int j = 0; j < lastMaxTilesY; j++)
					{
						Main.tile[i, j].Clear();
					}
				}
			}
			if (lastMaxTilesY > Main.maxTilesY)
			{
				for (int k = 0; k < Main.maxTilesX; k++)
				{
					for (int l = Main.maxTilesY; l < lastMaxTilesY; l++)
					{
						Main.tile[k, l].Clear();
					}
				}
			}
			lastMaxTilesX = Main.maxTilesX;
			lastMaxTilesY = Main.maxTilesY;
			if (Main.netMode != 1)
			{
				for (int m = 0; m < Main.maxTilesX; m++)
				{
					for (int n = 0; n < Main.maxTilesY; n++)
					{
						Main.tile[m, n].Clear();
					}
				}
			}
			Main.dust.Init();
			for (int num = 0; num < 128; num++)
			{
				Main.gore[num].Init();
			}
			for (int num2 = 0; num2 < 200; num2++)
			{
				Main.item[num2].Init();
			}
			for (int num3 = 0; num3 < 196; num3++)
			{
				Main.npc[num3] = new NPC();
			}
			for (int num4 = 0; num4 < 512; num4++)
			{
				Main.projectile[num4].Init();
			}
			for (int num5 = 0; num5 < 1000; num5++)
			{
				Main.chest[num5] = null;
			}
			for (int num6 = 0; num6 < 1000; num6++)
			{
				Main.sign[num6].Init();
			}
			for (int num7 = 0; num7 < 8192; num7++)
			{
				Main.liquidBuffer[num7] = default(LiquidBuffer);
			}
			setWorldSize();
		}

		public static bool loadWorld(Stream file)
		{
			bool result = true;
			Time.checkXMas();
			using (MemoryStream memoryStream = new MemoryStream((int)file.Length))
			{
				memoryStream.SetLength(file.Length);
				file.Read(memoryStream.GetBuffer(), 0, (int)file.Length);
				file.Close();
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					try
					{
						int num = binaryReader.ReadInt32();
						if (num > 49)
						{
							throw new InvalidOperationException("Invalid version");
						}
						if (num <= 46)
						{
							loadOldWorld(binaryReader, num);
						}
						else
						{
							loadNewWorld(binaryReader, num, memoryStream);
						}
						gen = true;
						UI.main.NextProgressStep(Lang.gen[52]);
						for (int i = 0; i < Main.maxTilesX; i++)
						{
							if ((i & 0x3F) == 0)
							{
								UI.main.progress = (float)i / (float)Main.maxTilesX;
							}
							CountTiles(i);
						}
						NPC.setNames();
						UI.main.NextProgressStep(Lang.gen[27]);
						waterLine = Main.maxTilesY;
						Liquid.QuickWater(0.5);
						WaterCheck();
						int num2 = 0;
						Liquid.QuickSettleOn();
						int num3 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
						float num4 = 0f;
						while (Liquid.numLiquid > 0 && num2 < 512)
						{
							num2++;
							float num5 = (float)(num3 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float)num3;
							if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num3)
							{
								num3 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
							}
							if (num5 > num4)
							{
								num4 = num5;
							}
							else
							{
								num5 = num4;
							}
							if (num5 <= 0.5f)
							{
								UI.main.progress = num5 + 0.5f;
							}
							Liquid.UpdateLiquid();
						}
						Liquid.QuickSettleOff();
						WaterCheck();
						gen = false;
						return result;
					}
					catch
					{
						return false;
					}
				}
			}
		}

		private unsafe static void loadOldWorld(BinaryReader fileIO, int release)
		{
			string b = fileIO.ReadString();
			int worldID = fileIO.ReadInt32();
			Main.rightWorld = fileIO.ReadInt32();
			Main.rightWorld = fileIO.ReadInt32();
			Main.bottomWorld = fileIO.ReadInt32();
			Main.bottomWorld = fileIO.ReadInt32();
			Main.maxTilesY = (short)fileIO.ReadInt32();
			Main.maxTilesX = (short)fileIO.ReadInt32();
			clearWorld();
			Main.worldID = worldID;
			UI.main.FirstProgressStep(4, Lang.gen[51]);
			Main.spawnTileX = (short)fileIO.ReadInt32();
			Main.spawnTileY = (short)fileIO.ReadInt32();
			Main.worldSurface = (int)fileIO.ReadDouble();
			Main.worldSurfacePixels = Main.worldSurface << 4;
			Main.rockLayer = (int)fileIO.ReadDouble();
			Main.rockLayerPixels = Main.rockLayer << 4;
			UpdateMagmaLayerPos();
			tempTime.dayRate = 1f;
			tempTime.time = (float)fileIO.ReadDouble();
			tempTime.dayTime = fileIO.ReadBoolean();
			tempTime.moonPhase = (byte)fileIO.ReadInt32();
			tempTime.bloodMoon = fileIO.ReadBoolean();
			Main.dungeonX = (short)fileIO.ReadInt32();
			Main.dungeonY = (short)fileIO.ReadInt32();
			NPC.downedBoss1 = fileIO.ReadBoolean();
			NPC.downedBoss2 = fileIO.ReadBoolean();
			NPC.downedBoss3 = fileIO.ReadBoolean();
			NPC.savedGoblin = fileIO.ReadBoolean();
			NPC.savedWizard = fileIO.ReadBoolean();
			NPC.savedMech = fileIO.ReadBoolean();
			NPC.downedGoblins = fileIO.ReadBoolean();
			NPC.downedClown = fileIO.ReadBoolean();
			NPC.downedFrost = fileIO.ReadBoolean();
			shadowOrbSmashed = fileIO.ReadBoolean();
			spawnMeteor = fileIO.ReadBoolean();
			shadowOrbCount = fileIO.ReadByte();
			altarCount = fileIO.ReadInt32();
			Main.hardMode = fileIO.ReadBoolean();
			Main.invasionDelay = fileIO.ReadInt32();
			Main.invasionSize = fileIO.ReadInt32();
			Main.invasionType = fileIO.ReadInt32();
			Main.invasionX = (float)fileIO.ReadDouble();
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				if ((i & 0x1F) == 0)
				{
					UI.main.progress = (float)i / (float)Main.maxTilesX;
				}
				fixed (Tile* ptr = &Main.tile[i, 0])
				{
					Tile* ptr2 = ptr;
					int num = 0;
					while (num < Main.maxTilesY)
					{
						ptr2->flags = ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.NEARBY | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.SELECTED | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID);
						ptr2->active = fileIO.ReadByte();
						if (ptr2->active != 0)
						{
							ptr2->type = fileIO.ReadByte();
							if (ptr2->type == 127)
							{
								ptr2->active = 0;
							}
							if (Main.tileFrameImportant[ptr2->type])
							{
								ptr2->frameX = fileIO.ReadInt16();
								ptr2->frameY = fileIO.ReadInt16();
								if (ptr2->type == 144)
								{
									ptr2->frameY = 0;
								}
							}
							else
							{
								ptr2->frameX = -1;
								ptr2->frameY = -1;
							}
						}
						if (fileIO.ReadBoolean())
						{
							ptr2->wall = fileIO.ReadByte();
						}
						if (fileIO.ReadBoolean())
						{
							ptr2->liquid = fileIO.ReadByte();
							if (fileIO.ReadBoolean())
							{
								ptr2->lava = 32;
							}
						}
						if (release < 46)
						{
							if (fileIO.ReadBoolean())
							{
								ptr2->wire = 16;
							}
						}
						else
						{
							ptr2->flags |= (Tile.Flags)fileIO.ReadByte();
							if (Main.IsTutorial())
							{
								ptr2->flags &= ~Tile.Flags.VISITED;
							}
						}
						int num2 = fileIO.ReadInt16();
						num += num2;
						while (num2 > 0)
						{
							ptr2[1] = *ptr2;
							ptr2++;
							num2--;
						}
						num++;
						ptr2++;
					}
				}
			}
			for (int j = 0; j < 1000; j++)
			{
				if (!fileIO.ReadBoolean())
				{
					continue;
				}
				Main.chest[j] = new Chest();
				Main.chest[j].x = (short)fileIO.ReadInt32();
				Main.chest[j].y = (short)fileIO.ReadInt32();
				for (int k = 0; k < 20; k++)
				{
					byte b2 = fileIO.ReadByte();
					if (b2 > 0)
					{
						Main.chest[j].item[k].netDefaults(fileIO.ReadInt32(), b2);
						Main.chest[j].item[k].Prefix(fileIO.ReadByte());
					}
				}
			}
			for (int l = 0; l < 1000; l++)
			{
				if (fileIO.ReadBoolean())
				{
					string s = fileIO.ReadString();
					int num3 = fileIO.ReadInt32();
					int num4 = fileIO.ReadInt32();
					if (Main.tile[num3, num4].active != 0 && (Main.tile[num3, num4].type == 55 || Main.tile[num3, num4].type == 85))
					{
						Main.sign[l].x = (short)num3;
						Main.sign[l].y = (short)num4;
						Main.sign[l].text = s;
					}
				}
			}
			bool flag = fileIO.ReadBoolean();
			int num5 = 0;
			while (flag)
			{
				try
				{
					string value = fileIO.ReadString();
					Main.npc[num5].SetDefaults(Convert.ToUInt16(value));
					Main.npc[num5].position.X = fileIO.ReadSingle();
					Main.npc[num5].position.Y = fileIO.ReadSingle();
					Main.npc[num5].aabb.X = (int)Main.npc[num5].position.X;
					Main.npc[num5].aabb.Y = (int)Main.npc[num5].position.Y;
					Main.npc[num5].homeless = fileIO.ReadBoolean();
					Main.npc[num5].homeTileX = (short)fileIO.ReadInt32();
					Main.npc[num5].homeTileY = (short)fileIO.ReadInt32();
					num5++;
				}
				catch (FormatException)
				{
					fileIO.ReadBytes(17);
				}
				flag = fileIO.ReadBoolean();
			}
			NPC.chrName[17] = fileIO.ReadString();
			NPC.chrName[18] = fileIO.ReadString();
			NPC.chrName[19] = fileIO.ReadString();
			NPC.chrName[20] = fileIO.ReadString();
			NPC.chrName[22] = fileIO.ReadString();
			NPC.chrName[54] = fileIO.ReadString();
			NPC.chrName[38] = fileIO.ReadString();
			NPC.chrName[107] = fileIO.ReadString();
			NPC.chrName[108] = fileIO.ReadString();
			NPC.chrName[124] = fileIO.ReadString();
			bool flag2 = fileIO.ReadBoolean();
			string a = fileIO.ReadString();
			int num6 = fileIO.ReadInt32();
			if (!flag2 || a != b || num6 != Main.worldID)
			{
				throw new InvalidOperationException("Invalid footer");
			}
		}

		private unsafe static void loadNewWorld(BinaryReader fileIO, int release, MemoryStream stream)
		{
			CRC32 cRC = new CRC32();
			cRC.Update(stream.GetBuffer(), 8, (int)stream.Length - 8);
			if (cRC.GetValue() != fileIO.ReadUInt32())
			{
				throw new InvalidOperationException("Invalid CRC32");
			}
			fileIO.ReadString();
			int worldID = fileIO.ReadInt32();
			int worldTimestamp = (release >= 48) ? fileIO.ReadInt32() : 0;
			Main.rightWorld = fileIO.ReadInt32();
			Main.bottomWorld = fileIO.ReadInt16();
			Main.maxTilesY = fileIO.ReadInt16();
			Main.maxTilesX = fileIO.ReadInt16();
			clearWorld();
			Main.worldID = worldID;
			Main.worldTimestamp = worldTimestamp;
			UI.main.FirstProgressStep(4, Lang.gen[51]);
			Main.spawnTileX = fileIO.ReadInt16();
			Main.spawnTileY = fileIO.ReadInt16();
			Main.worldSurface = fileIO.ReadInt16();
			Main.worldSurfacePixels = Main.worldSurface << 4;
			Main.rockLayer = fileIO.ReadInt16();
			Main.rockLayerPixels = Main.rockLayer << 4;
			UpdateMagmaLayerPos();
			tempTime.dayRate = 1f;
			tempTime.time = fileIO.ReadSingle();
			tempTime.dayTime = fileIO.ReadBoolean();
			tempTime.moonPhase = fileIO.ReadByte();
			tempTime.bloodMoon = fileIO.ReadBoolean();
			Main.dungeonX = fileIO.ReadInt16();
			Main.dungeonY = fileIO.ReadInt16();
			NPC.downedBoss1 = fileIO.ReadBoolean();
			NPC.downedBoss2 = fileIO.ReadBoolean();
			NPC.downedBoss3 = fileIO.ReadBoolean();
			NPC.savedGoblin = fileIO.ReadBoolean();
			NPC.savedWizard = fileIO.ReadBoolean();
			NPC.savedMech = fileIO.ReadBoolean();
			NPC.downedGoblins = fileIO.ReadBoolean();
			NPC.downedClown = fileIO.ReadBoolean();
			NPC.downedFrost = fileIO.ReadBoolean();
			shadowOrbSmashed = fileIO.ReadBoolean();
			spawnMeteor = fileIO.ReadBoolean();
			shadowOrbCount = fileIO.ReadByte();
			altarCount = fileIO.ReadInt32();
			Main.hardMode = fileIO.ReadBoolean();
			Main.invasionDelay = fileIO.ReadByte();
			Main.invasionSize = fileIO.ReadInt16();
			Main.invasionType = fileIO.ReadByte();
			Main.invasionX = fileIO.ReadSingle();
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				if ((i & 0x1F) == 0)
				{
					UI.main.progress = (float)i / (float)Main.maxTilesX;
				}
				fixed (Tile* ptr = &Main.tile[i, 0])
				{
					Tile* ptr2 = ptr;
					int num = 0;
					while (num < Main.maxTilesY)
					{
						ptr2->flags = ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.NEARBY | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.SELECTED | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID);
						ptr2->active = fileIO.ReadByte();
						if (ptr2->active != 0)
						{
							ptr2->type = fileIO.ReadByte();
							if (ptr2->type == 127)
							{
								ptr2->active = 0;
							}
							if (Main.tileFrameImportant[ptr2->type])
							{
								ptr2->frameX = fileIO.ReadInt16();
								ptr2->frameY = fileIO.ReadInt16();
								if (ptr2->type == 144)
								{
									ptr2->frameY = 0;
								}
							}
							else
							{
								ptr2->frameX = -1;
								ptr2->frameY = -1;
							}
						}
						ptr2->wall = fileIO.ReadByte();
						ptr2->liquid = fileIO.ReadByte();
						if (ptr2->liquid > 0 && fileIO.ReadBoolean())
						{
							ptr2->lava = 32;
						}
						ptr2->flags |= (Tile.Flags)fileIO.ReadByte();
						if (Main.IsTutorial())
						{
							ptr2->flags &= ~Tile.Flags.VISITED;
						}
						int num2 = fileIO.ReadByte();
						if ((num2 & 0x80) != 0)
						{
							num2 &= 0x7F;
							num2 |= fileIO.ReadByte() << 7;
						}
						num += num2;
						while (num2 > 0)
						{
							ptr2[1] = *ptr2;
							ptr2++;
							num2--;
						}
						num++;
						ptr2++;
					}
				}
			}
			for (int j = 0; j < 1000; j++)
			{
				if (!fileIO.ReadBoolean())
				{
					continue;
				}
				Main.chest[j] = new Chest();
				Main.chest[j].x = fileIO.ReadInt16();
				Main.chest[j].y = fileIO.ReadInt16();
				for (int k = 0; k < 20; k++)
				{
					byte b = fileIO.ReadByte();
					if (b > 0)
					{
						Main.chest[j].item[k].netDefaults(fileIO.ReadInt16(), b);
						Main.chest[j].item[k].Prefix(fileIO.ReadByte());
					}
				}
			}
			for (int l = 0; l < 1000; l++)
			{
				Main.sign[l].Read(fileIO, release);
			}
			bool flag = fileIO.ReadBoolean();
			int num3 = 0;
			while (flag)
			{
				int type = fileIO.ReadByte();
				Main.npc[num3].SetDefaults(type);
				Main.npc[num3].position.X = fileIO.ReadSingle();
				Main.npc[num3].position.Y = fileIO.ReadSingle();
				Main.npc[num3].aabb.X = (int)Main.npc[num3].position.X;
				Main.npc[num3].aabb.Y = (int)Main.npc[num3].position.Y;
				Main.npc[num3].homeless = fileIO.ReadBoolean();
				Main.npc[num3].homeTileX = fileIO.ReadInt16();
				Main.npc[num3].homeTileY = fileIO.ReadInt16();
				num3++;
				flag = fileIO.ReadBoolean();
			}
			NPC.chrName[17] = fileIO.ReadString();
			NPC.chrName[18] = fileIO.ReadString();
			NPC.chrName[19] = fileIO.ReadString();
			NPC.chrName[20] = fileIO.ReadString();
			NPC.chrName[22] = fileIO.ReadString();
			NPC.chrName[54] = fileIO.ReadString();
			NPC.chrName[38] = fileIO.ReadString();
			NPC.chrName[107] = fileIO.ReadString();
			NPC.chrName[108] = fileIO.ReadString();
			NPC.chrName[124] = fileIO.ReadString();
		}

		public static void saveNewWorld()
		{
			if (saveLock)
			{
				return;
			}
			saveLock = true;
			if (hardLock)
			{
				UI.main.statusText = Lang.gen[48];
				do
				{
					Thread.Sleep(16);
				}
				while (hardLock);
			}
			bool flag = false;
			lock (padlock)
			{
				UI.main.FirstProgressStep(1, Lang.gen[49]);
				using (MemoryStream memoryStream = new MemoryStream(6291456))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						binaryWriter.Write(49);
						binaryWriter.Write(0u);
						binaryWriter.Write(Main.worldName);
						binaryWriter.Write(Main.worldID);
						binaryWriter.Write(Main.worldTimestamp);
						binaryWriter.Write(Main.rightWorld);
						binaryWriter.Write((short)Main.bottomWorld);
						binaryWriter.Write(Main.maxTilesY);
						binaryWriter.Write(Main.maxTilesX);
						binaryWriter.Write(Main.spawnTileX);
						binaryWriter.Write(Main.spawnTileY);
						binaryWriter.Write((short)Main.worldSurface);
						binaryWriter.Write((short)Main.rockLayer);
						binaryWriter.Write(tempTime.time);
						binaryWriter.Write(tempTime.dayTime);
						binaryWriter.Write(tempTime.moonPhase);
						binaryWriter.Write(tempTime.bloodMoon);
						binaryWriter.Write(Main.dungeonX);
						binaryWriter.Write(Main.dungeonY);
						binaryWriter.Write(NPC.downedBoss1);
						binaryWriter.Write(NPC.downedBoss2);
						binaryWriter.Write(NPC.downedBoss3);
						binaryWriter.Write(NPC.savedGoblin);
						binaryWriter.Write(NPC.savedWizard);
						binaryWriter.Write(NPC.savedMech);
						binaryWriter.Write(NPC.downedGoblins);
						binaryWriter.Write(NPC.downedClown);
						binaryWriter.Write(NPC.downedFrost);
						binaryWriter.Write(shadowOrbSmashed);
						binaryWriter.Write(spawnMeteor);
						binaryWriter.Write((byte)shadowOrbCount);
						binaryWriter.Write(altarCount);
						binaryWriter.Write(Main.hardMode);
						binaryWriter.Write((byte)Main.invasionDelay);
						binaryWriter.Write((short)Main.invasionSize);
						binaryWriter.Write((byte)Main.invasionType);
						binaryWriter.Write(Main.invasionX);
						for (int i = 0; i < Main.maxTilesX; i++)
						{
							if ((i & 0x1F) == 0)
							{
								UI.main.progress = (float)i / (float)Main.maxTilesX;
							}
							int num;
							for (num = 0; num < Main.maxTilesY; num++)
							{
								Tile tile = Main.tile[i, num];
								if (tile.type == 127)
								{
									tile.active = 0;
								}
								if (tile.active != 0)
								{
									binaryWriter.Write(value: true);
									binaryWriter.Write(tile.type);
									if (Main.tileFrameImportant[tile.type])
									{
										binaryWriter.Write(tile.frameX);
										binaryWriter.Write(tile.frameY);
									}
								}
								else
								{
									binaryWriter.Write(value: false);
								}
								binaryWriter.Write(tile.wall);
								binaryWriter.Write(tile.liquid);
								if (tile.liquid > 0)
								{
									binaryWriter.Write(tile.lava != 0);
								}
								binaryWriter.Write((byte)(tile.flags & (Tile.Flags.VISITED | Tile.Flags.WIRE)));
								int j;
								for (j = 1; num + j < Main.maxTilesY && tile.isTheSameAs(ref Main.tile[i, num + j]); j++)
								{
								}
								j--;
								num += j;
								if (j < 128)
								{
									binaryWriter.Write((byte)j);
								}
								else
								{
									int num2 = (j & 0x7F) | 0x80;
									j >>= 7;
									binaryWriter.Write((ushort)(num2 | (j << 8)));
								}
							}
						}
						for (int k = 0; k < 1000; k++)
						{
							if (Main.chest[k] == null)
							{
								binaryWriter.Write(value: false);
							}
							else
							{
								Chest chest = Main.chest[k];
								binaryWriter.Write(value: true);
								binaryWriter.Write(chest.x);
								binaryWriter.Write(chest.y);
								for (int l = 0; l < 20; l++)
								{
									if (chest.item[l].type == 0)
									{
										chest.item[l].stack = 0;
									}
									binaryWriter.Write((byte)chest.item[l].stack);
									if (chest.item[l].stack > 0)
									{
										binaryWriter.Write(chest.item[l].netID);
										binaryWriter.Write(chest.item[l].prefix);
									}
								}
							}
						}
						for (int m = 0; m < 1000; m++)
						{
							Sign sign = Main.sign[m];
							sign.Write(binaryWriter);
						}
						for (int n = 0; n < 196; n++)
						{
							NPC nPC = Main.npc[n];
							if (nPC.townNPC && nPC.active != 0)
							{
								nPC = (NPC)nPC.Clone();
								binaryWriter.Write(value: true);
								binaryWriter.Write(nPC.type);
								binaryWriter.Write(nPC.position.X);
								binaryWriter.Write(nPC.position.Y);
								binaryWriter.Write(nPC.homeless);
								binaryWriter.Write(nPC.homeTileX);
								binaryWriter.Write(nPC.homeTileY);
							}
						}
						binaryWriter.Write(value: false);
						binaryWriter.Write(NPC.chrName[17]);
						binaryWriter.Write(NPC.chrName[18]);
						binaryWriter.Write(NPC.chrName[19]);
						binaryWriter.Write(NPC.chrName[20]);
						binaryWriter.Write(NPC.chrName[22]);
						binaryWriter.Write(NPC.chrName[54]);
						binaryWriter.Write(NPC.chrName[38]);
						binaryWriter.Write(NPC.chrName[107]);
						binaryWriter.Write(NPC.chrName[108]);
						binaryWriter.Write(NPC.chrName[124]);
						CRC32 cRC = new CRC32();
						cRC.Update(memoryStream.GetBuffer(), 8, (int)memoryStream.Length - 8);
						binaryWriter.Seek(4, SeekOrigin.Begin);
						binaryWriter.Write(cRC.GetValue());
						Main.ShowSaveIcon();
						try
						{
							if (UI.main.TestStorageSpace("Worlds", WorldSelect.worldPathName, (int)memoryStream.Length))
							{
								using (StorageContainer storageContainer = UI.main.OpenPlayerStorage("Worlds"))
								{
									using (Stream stream = storageContainer.OpenFile(WorldSelect.worldPathName, FileMode.Create))
									{
										stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
										stream.Close();
										flag = true;
									}
								}
							}
						}
						catch (IOException)
						{
							UI.main.WriteError();
						}
						catch (Exception)
						{
						}
						binaryWriter.Close();
						Main.HideSaveIcon();
					}
				}
				saveLock = false;
				if (!flag)
				{
					WorldSelect.LoadWorlds();
				}
			}
		}

		private static void resetGen()
		{
			mudWall = false;
			hellChest = 0;
			JungleX = 0;
			numMCaves = 0;
			numIslandHouses = 0;
			houseCount = 0;
			dEnteranceX = 0;
			numDRooms = 0;
			numDDoors = 0;
			numDPlats = 0;
			numJChests = 0;
		}

		public static bool placeTrap(int x2, int y2, int type = -1)
		{
			int num = y2;
			while (!SolidTileUnsafe(x2, num))
			{
				if (++num >= Main.maxTilesY - 300)
				{
					return false;
				}
			}
			num--;
			if (Main.tile[x2, num].liquid > 0 && Main.tile[x2, num].lava != 0)
			{
				return false;
			}
			if (type == -1 && Main.rand.Next(20) == 0)
			{
				type = 2;
			}
			else if (type == -1)
			{
				type = Main.rand.Next(2);
			}
			if (Main.tile[x2, num].active != 0 || Main.tile[x2 - 1, num].active != 0 || Main.tile[x2 + 1, num].active != 0 || Main.tile[x2, num - 1].active != 0 || Main.tile[x2 - 1, num - 1].active != 0 || Main.tile[x2 + 1, num - 1].active != 0 || Main.tile[x2, num - 2].active != 0 || Main.tile[x2 - 1, num - 2].active != 0 || Main.tile[x2 + 1, num - 2].active != 0)
			{
				return false;
			}
			if (Main.tile[x2, num + 1].type == 48)
			{
				return false;
			}
			switch (type)
			{
			case 0:
			{
				int num7 = x2;
				int num8 = num;
				num8 -= genRand.Next(3);
				while (!SolidTileUnsafe(num7, num8))
				{
					if (--num7 < 0)
					{
						return false;
					}
				}
				int num9 = num7;
				num7 = x2;
				while (!SolidTileUnsafe(num7, num8))
				{
					if (++num7 >= Main.maxTilesX)
					{
						return false;
					}
				}
				int num10 = num7;
				int num11 = x2 - num9;
				int num12 = num10 - x2;
				bool flag = num11 > 5 && num11 < 50;
				bool flag2 = num12 > 5 && num12 < 50;
				if (flag && !SolidTileUnsafe(num9, num8 + 1))
				{
					flag = false;
				}
				else if (flag && (Main.tile[num9, num8].type == 10 || Main.tile[num9, num8].type == 48 || Main.tile[num9, num8 + 1].type == 10 || Main.tile[num9, num8 + 1].type == 48))
				{
					flag = false;
				}
				if (flag2 && !SolidTileUnsafe(num10, num8 + 1))
				{
					flag2 = false;
				}
				else if (flag2 && (Main.tile[num10, num8].type == 10 || Main.tile[num10, num8].type == 48 || Main.tile[num10, num8 + 1].type == 10 || Main.tile[num10, num8 + 1].type == 48))
				{
					flag2 = false;
				}
				int num13 = 0;
				if (flag && flag2)
				{
					num13 = 1;
					num7 = num9;
					if (genRand.Next(2) == 0)
					{
						num7 = num10;
						num13 = -1;
					}
				}
				else if (flag2)
				{
					num7 = num10;
					num13 = -1;
				}
				else
				{
					if (!flag)
					{
						return false;
					}
					num7 = num9;
					num13 = 1;
				}
				PlaceTile(x2, num, 135, mute: true, forced: true, -1, (Main.tile[x2, num].wall > 0) ? 2 : genRand.Next(2, 4));
				KillTile(num7, num8);
				PlaceTile(num7, num8, 137, mute: true, forced: true, -1, num13);
				int num14 = x2;
				int num15 = num;
				while (num14 != num7 || num15 != num8)
				{
					Main.tile[num14, num15].wire = 16;
					if (num14 > num7)
					{
						num14--;
					}
					if (num14 < num7)
					{
						num14++;
					}
					Main.tile[num14, num15].wire = 16;
					if (num15 > num8)
					{
						num15--;
					}
					if (num15 < num8)
					{
						num15++;
					}
					Main.tile[num14, num15].wire = 16;
				}
				return true;
			}
			case 1:
			{
				int num16 = x2;
				int num17 = num - 8;
				num16 += genRand.Next(-1, 2);
				bool flag3 = true;
				while (flag3)
				{
					bool flag4 = true;
					int num18 = 0;
					for (int l = num16 - 2; l <= num16 + 3; l++)
					{
						for (int m = num17; m <= num17 + 3; m++)
						{
							if (!SolidTileUnsafe(l, m))
							{
								flag4 = false;
							}
							if (Main.tile[l, m].active != 0 && (Main.tile[l, m].type == 0 || Main.tile[l, m].type == 1 || Main.tile[l, m].type == 59))
							{
								num18++;
							}
						}
					}
					num17--;
					if (num17 < Main.worldSurface)
					{
						return false;
					}
					if (flag4 && num18 > 2)
					{
						flag3 = false;
					}
				}
				if (num - num17 <= 5 || num - num17 >= 40)
				{
					return false;
				}
				for (int n = num16; n <= num16 + 1; n++)
				{
					for (int num19 = num17; num19 <= num; num19++)
					{
						if (SolidTileUnsafe(n, num19))
						{
							KillTile(n, num19);
						}
					}
				}
				for (int num20 = num16 - 2; num20 <= num16 + 3; num20++)
				{
					for (int num21 = num17 - 2; num21 <= num17 + 3; num21++)
					{
						if (SolidTileUnsafe(num20, num21))
						{
							Main.tile[num20, num21].type = 1;
						}
					}
				}
				PlaceTile(x2, num, 135, mute: true, forced: true, -1, genRand.Next(2, 4));
				PlaceTile(num16, num17 + 2, 130, mute: true);
				PlaceTile(num16 + 1, num17 + 2, 130, mute: true);
				PlaceTile(num16 + 1, num17 + 1, 138, mute: true);
				num17 += 2;
				Main.tile[num16, num17].wire = 16;
				Main.tile[num16 + 1, num17].wire = 16;
				num17++;
				PlaceTile(num16, num17, 130, mute: true);
				PlaceTile(num16 + 1, num17, 130, mute: true);
				Main.tile[num16, num17].wire = 16;
				Main.tile[num16 + 1, num17].wire = 16;
				PlaceTile(num16, num17 + 1, 130, mute: true);
				PlaceTile(num16 + 1, num17 + 1, 130, mute: true);
				Main.tile[num16, num17 + 1].wire = 16;
				Main.tile[num16 + 1, num17 + 1].wire = 16;
				int num22 = x2;
				int num23 = num;
				while (num22 != num16 || num23 != num17)
				{
					Main.tile[num22, num23].wire = 16;
					if (num22 > num16)
					{
						num22--;
					}
					if (num22 < num16)
					{
						num22++;
					}
					Main.tile[num22, num23].wire = 16;
					if (num23 > num17)
					{
						num23--;
					}
					if (num23 < num17)
					{
						num23++;
					}
					Main.tile[num22, num23].wire = 16;
				}
				return true;
			}
			case 2:
			{
				int num2 = Main.rand.Next(4, 7);
				int num3 = x2;
				num3 += Main.rand.Next(-1, 2);
				int num4 = num;
				for (int i = 0; i < num2; i++)
				{
					num4++;
					if (!SolidTileUnsafe(num3, num4))
					{
						return false;
					}
				}
				for (int j = num3 - 2; j <= num3 + 2; j++)
				{
					for (int k = num4 - 2; k <= num4 + 2; k++)
					{
						if (!SolidTileUnsafe(j, k))
						{
							return false;
						}
					}
				}
				KillTile(num3, num4);
				Main.tile[num3, num4].active = 1;
				Main.tile[num3, num4].type = 141;
				Main.tile[num3, num4].frameX = 0;
				Main.tile[num3, num4].frameY = (short)(18 * Main.rand.Next(2));
				PlaceTile(x2, num, 135, mute: true, forced: true, -1, genRand.Next(2, 4));
				int num5 = x2;
				int num6 = num;
				while (num5 != num3 || num6 != num4)
				{
					Main.tile[num5, num6].wire = 16;
					if (num5 > num3)
					{
						num5--;
					}
					if (num5 < num3)
					{
						num5++;
					}
					Main.tile[num5, num6].wire = 16;
					if (num6 > num4)
					{
						num6--;
					}
					if (num6 < num4)
					{
						num6++;
					}
					Main.tile[num5, num6].wire = 16;
				}
				break;
			}
			}
			return false;
		}

		public unsafe static void generateWorld(int seed = -1)
		{
			Time.checkXMas();
			NPC.clrNames();
			NPC.setNames();
			gen = true;
			resetGen();
			UI.main.FirstProgressStep(47, Lang.gen[0]);
			if (seed > 0)
			{
				genRand = new FastRandom((uint)seed);
			}
			Main.worldID = genRand.Next();
			Main.worldTimestamp = (int)(DateTime.UtcNow.Ticks / 10000000);
			int num = 0;
			int num2 = 0;
			float num3 = (float)Main.maxTilesY * 0.3f;
			num3 *= (float)genRand.Next(90, 110) * 0.005f;
			float num4 = num3 + (float)Main.maxTilesY * 0.2f;
			num4 *= (float)genRand.Next(90, 110) * 0.01f;
			float num5 = num3;
			float num6 = num3;
			float num7 = num4;
			float num8 = num4;
			int num9 = (genRand.Next(2) << 1) - 1;
			float num10 = 1f / (float)Main.maxTilesX;
			try
			{
				fixed (Tile* ptr = Main.tile)
				{
					for (int i = 0; i < Main.maxTilesX; i++)
					{
						UI.main.progress = (float)i * num10;
						if (num3 < num5)
						{
							num5 = num3;
						}
						if (num3 > num6)
						{
							num6 = num3;
						}
						if (num4 < num7)
						{
							num7 = num4;
						}
						if (num4 > num8)
						{
							num8 = num4;
						}
						if (--num2 <= 0)
						{
							num = genRand.Next(5);
							num2 = genRand.Next(5, 40);
							if (num == 0)
							{
								num2 *= genRand.Next(1, 6);
							}
						}
						switch (num)
						{
						case 0:
							while (genRand.Next(7) == 0)
							{
								num3 += (float)genRand.Next(-1, 2);
							}
							break;
						case 1:
							while (genRand.Next(4) == 0)
							{
								num3 -= 1f;
							}
							while (genRand.Next(10) == 0)
							{
								num3 += 1f;
							}
							break;
						case 2:
							while (genRand.Next(4) == 0)
							{
								num3 += 1f;
							}
							while (genRand.Next(10) == 0)
							{
								num3 -= 1f;
							}
							break;
						case 3:
							while (genRand.Next(2) == 0)
							{
								num3 -= 1f;
							}
							while (genRand.Next(6) == 0)
							{
								num3 += 1f;
							}
							break;
						default:
							while (genRand.Next(2) == 0)
							{
								num3 += 1f;
							}
							while (genRand.Next(5) == 0)
							{
								num3 -= 1f;
							}
							break;
						}
						if (num3 < (float)Main.maxTilesY * 0.17f)
						{
							num3 = (float)Main.maxTilesY * 0.17f;
							num2 = 0;
						}
						else if (num3 > (float)Main.maxTilesY * 0.3f)
						{
							num3 = (float)Main.maxTilesY * 0.3f;
							num2 = 0;
						}
						if ((i < 275 || i > Main.maxTilesX - 275) && num3 > (float)(Main.maxTilesY >> 2))
						{
							num3 = Main.maxTilesY >> 2;
							num2 = 1;
						}
						while (genRand.Next(3) == 0)
						{
							num4 += (float)genRand.Next(-2, 3);
						}
						if ((double)num4 < (double)num3 + (double)Main.maxTilesY * 0.05)
						{
							num4 += 1f;
						}
						else if ((double)num4 > (double)num3 + (double)Main.maxTilesY * 0.35)
						{
							num4 -= 1f;
						}
						int num11 = Main.maxTilesY - 1;
						Tile* ptr2 = ptr + (i * 1440 + num11);
						do
						{
							ptr2->active = 1;
							ptr2->type = (byte)((num11 >= (int)num4) ? 1 : 0);
							ptr2->frameX = -1;
							ptr2->frameY = -1;
							ptr2--;
						}
						while (--num11 >= (int)num3);
						do
						{
							ptr2->active = 0;
							ptr2->frameX = -1;
							ptr2->frameY = -1;
							ptr2--;
						}
						while (--num11 >= 0);
					}
					Main.worldSurface = (int)num6 + 25;
					Main.worldSurfacePixels = Main.worldSurface << 4;
					int num12 = (int)((num8 - num6 + 25f) * (355f / (678f * (float)Math.PI))) * 6;
					Main.rockLayer = Main.worldSurface + num12;
					Main.rockLayerPixels = Main.rockLayer << 4;
					UpdateMagmaLayerPos();
					waterLine = Main.rockLayer + Main.maxTilesY >> 1;
					waterLine += genRand.Next(-100, 20);
					lavaLine = waterLine + genRand.Next(50, 80);
					int num13 = 0;
					Location[] array = new Location[10];
					for (int j = 0; j < (int)((float)Main.maxTilesX * 0.0015f); j++)
					{
						int num14 = genRand.Next(450, Main.maxTilesX - 450);
						int k = 0;
						for (int l = 0; l < 10; l++)
						{
							for (; Main.tile[num14, k].active == 0; k++)
							{
							}
							array[l].X = (short)num14;
							array[l].Y = (short)(k - genRand.Next(11, 16));
							num14 += genRand.Next(5, 11);
						}
						for (int m = 0; m < 10; m++)
						{
							TileRunner(array[m].X, array[m].Y, genRand.Next(5, 8), genRand.Next(6, 9), 0, addTile: true, new Vector2(-2f, -0.3f));
							TileRunner(array[m].X, array[m].Y, genRand.Next(5, 8), genRand.Next(6, 9), 0, addTile: true, new Vector2(2f, -0.3f));
						}
					}
					UI.main.NextProgressStep(Lang.gen[1]);
					int num15 = 2 + genRand.Next((int)((float)Main.maxTilesX * 0.0008f), (int)((float)Main.maxTilesX * 0.0025f));
					for (int n = 0; n < num15; n++)
					{
						int num16 = genRand.Next(Main.maxTilesX);
						while ((float)num16 > (float)Main.maxTilesX * 0.4f && (float)num16 < (float)Main.maxTilesX * 0.6f)
						{
							num16 = genRand.Next(Main.maxTilesX);
						}
						int num17 = genRand.Next(35, 90);
						if (n == 1)
						{
							float num18 = (float)Main.maxTilesX * 0.000238095236f;
							num17 += (int)((float)genRand.Next(20, 40) * num18);
						}
						if (genRand.Next(3) == 0)
						{
							num17 *= 2;
						}
						if (n == 1)
						{
							num17 *= 2;
						}
						int num19 = num16 - num17;
						num17 = genRand.Next(35, 90);
						if (genRand.Next(3) == 0)
						{
							num17 *= 2;
						}
						if (n == 1)
						{
							num17 *= 2;
						}
						int num20 = num16 + num17;
						if (num19 < 0)
						{
							num19 = 0;
						}
						if (num20 > Main.maxTilesX)
						{
							num20 = Main.maxTilesX;
						}
						switch (n)
						{
						case 0:
							num19 = 0;
							num20 = genRand.Next(260, 300);
							if (num9 == 1)
							{
								num20 += 40;
							}
							break;
						case 2:
							num19 = Main.maxTilesX - genRand.Next(260, 300);
							num20 = Main.maxTilesX;
							if (num9 == -1)
							{
								num19 -= 40;
							}
							break;
						}
						int num21 = genRand.Next(50, 100);
						for (int num22 = num19; num22 < num20; num22++)
						{
							if (genRand.Next(2) == 0)
							{
								num21 += genRand.Next(-1, 2);
								if (num21 < 50)
								{
									num21 = 50;
								}
								if (num21 > 100)
								{
									num21 = 100;
								}
							}
							for (int num23 = 0; num23 < Main.worldSurface; num23++)
							{
								if (Main.tile[num22, num23].active != 0)
								{
									int num24 = num21;
									if (num22 - num19 < num24)
									{
										num24 = num22 - num19;
									}
									if (num20 - num22 < num24)
									{
										num24 = num20 - num22;
									}
									num24 += genRand.Next(5);
									for (int num25 = num23; num25 < num23 + num24; num25++)
									{
										if (num22 > num19 + genRand.Next(5) && num22 < num20 - genRand.Next(5))
										{
											Main.tile[num22, num25].type = 53;
										}
									}
									break;
								}
							}
						}
					}
					for (int num26 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 8E-06f); num26 > 0; num26--)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next(Main.worldSurface, Main.rockLayer), genRand.Next(15, 70), genRand.Next(20, 130), 53);
					}
					numMCaves = 0;
					UI.main.NextProgressStep(Lang.gen[2]);
					for (int num27 = 0; num27 < (int)((float)Main.maxTilesX * 0.0008f); num27++)
					{
						int num28 = 0;
						bool flag = false;
						int num29 = genRand.Next((int)((float)Main.maxTilesX * 0.25f), (int)((float)Main.maxTilesX * 0.75f));
						bool flag2;
						do
						{
							flag2 = true;
							while (num29 > (Main.maxTilesX >> 1) - 100 && num29 < (Main.maxTilesX >> 1) + 100)
							{
								num29 = genRand.Next((int)((float)Main.maxTilesX * 0.25f), (int)((float)Main.maxTilesX * 0.75f));
							}
							for (int num30 = 0; num30 < numMCaves; num30++)
							{
								if (num29 > mCave[num30].X - 50 && num29 < mCave[num30].X + 50)
								{
									num28++;
									flag2 = false;
									break;
								}
							}
							if (num28 >= 200)
							{
								flag = true;
								break;
							}
						}
						while (!flag2);
						if (!flag)
						{
							for (int num31 = 0; num31 < Main.worldSurface; num31++)
							{
								if (Main.tile[num29, num31].active != 0)
								{
									Mountinater(num29, num31);
									mCave[numMCaves].X = (short)num29;
									mCave[numMCaves].Y = (short)num31;
									numMCaves++;
									break;
								}
							}
						}
					}
					bool flag3 = Time.xMas;
					if (genRand.Next(3) == 0)
					{
						flag3 = true;
					}
					if (flag3)
					{
						UI.main.statusText = Lang.gen[56];
						int num32 = genRand.Next(Main.maxTilesX / 3, (Main.maxTilesX << 1) / 3);
						int num33 = genRand.Next(35, 90);
						float num34 = (float)Main.maxTilesX * 0.000476190471f;
						num33 += (int)((float)genRand.Next(20, 40) * num34);
						int num35 = num32 - num33;
						if (num35 < 0)
						{
							num35 = 0;
						}
						num33 = genRand.Next(35, 90);
						num33 += (int)((float)genRand.Next(20, 40) * num34);
						int num36 = num32 + num33;
						if (num36 > Main.maxTilesX)
						{
							num36 = Main.maxTilesX;
						}
						int num37 = genRand.Next(50, 100);
						for (int num38 = num35; num38 < num36; num38++)
						{
							if (genRand.Next(2) == 0)
							{
								num37 += genRand.Next(-1, 2);
								if (num37 < 50)
								{
									num37 = 50;
								}
								if (num37 > 100)
								{
									num37 = 100;
								}
							}
							for (int num39 = 0; num39 < Main.worldSurface; num39++)
							{
								if (Main.tile[num38, num39].active != 0)
								{
									int num40 = num37;
									if (num38 - num35 < num40)
									{
										num40 = num38 - num35;
									}
									if (num36 - num38 < num40)
									{
										num40 = num36 - num38;
									}
									num40 += genRand.Next(5);
									for (int num41 = num39; num41 < num39 + num40; num41++)
									{
										if (num38 > num35 + genRand.Next(5) && num38 < num36 - genRand.Next(5))
										{
											Main.tile[num38, num41].type = 147;
										}
									}
									break;
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[3]);
					for (int num42 = 1; num42 < Main.maxTilesX - 1; num42++)
					{
						UI.main.progress = (float)num42 / (float)Main.maxTilesX;
						bool flag4 = false;
						num13 += genRand.Next(-1, 2);
						if (num13 < 0)
						{
							num13 = 0;
						}
						if (num13 > 10)
						{
							num13 = 10;
						}
						for (int num43 = 0; num43 < Main.worldSurface + 10 && num43 <= Main.worldSurface + num13; num43++)
						{
							if (flag4)
							{
								Main.tile[num42, num43].wall = 2;
							}
							if (Main.tile[num42, num43].active != 0 && Main.tile[num42 - 1, num43].active != 0 && Main.tile[num42 + 1, num43].active != 0 && Main.tile[num42, num43 + 1].active != 0 && Main.tile[num42 - 1, num43 + 1].active != 0 && Main.tile[num42 + 1, num43 + 1].active != 0)
							{
								flag4 = true;
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[4]);
					for (int num44 = 0; num44 < (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0002f); num44++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5 + 1), genRand.Next(4, 15), genRand.Next(5, 40), 1);
					}
					for (int num45 = 0; num45 < (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0002f); num45++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5, (int)num6 + 1), genRand.Next(4, 10), genRand.Next(5, 30), 1);
					}
					for (int num46 = 0; num46 < (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0045f); num46++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num6, (int)num8 + 1), genRand.Next(2, 7), genRand.Next(2, 23), 1);
					}
					UI.main.NextProgressStep(Lang.gen[5]);
					for (int num47 = 0; num47 < (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.005f); num47++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num7, Main.maxTilesY), genRand.Next(2, 6), genRand.Next(2, 40), 0);
					}
					UI.main.NextProgressStep(Lang.gen[6]);
					for (int num48 = 0; num48 < (int)((float)(Main.maxTilesX * Main.maxTilesY) * 2E-05f); num48++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5), genRand.Next(4, 14), genRand.Next(10, 50), 40);
					}
					for (int num49 = 0; num49 < (int)((float)(Main.maxTilesX * Main.maxTilesY) * 5E-05f); num49++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5, (int)num6 + 1), genRand.Next(8, 14), genRand.Next(15, 45), 40);
					}
					for (int num50 = 0; num50 < (int)((float)(Main.maxTilesX * Main.maxTilesY) * 2E-05f); num50++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num6, (int)num8 + 1), genRand.Next(8, 15), genRand.Next(5, 50), 40);
					}
					for (int num51 = 5; num51 < Main.maxTilesX - 5; num51++)
					{
						for (int num52 = 1; num52 < Main.worldSurface - 1; num52++)
						{
							if (Main.tile[num51, num52].active != 0)
							{
								for (int num53 = num52; num53 < num52 + 5; num53++)
								{
									if (Main.tile[num51, num53].type == 40)
									{
										Main.tile[num51, num53].type = 0;
									}
								}
								break;
							}
						}
					}
					int num54 = 0;
					UI.main.NextProgressStep(Lang.gen[7]);
					int num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0015f);
					for (int num56 = 0; num56 < num55; num56++)
					{
						UI.main.progress = (float)num56 / (float)num55;
						int type = -1;
						if (genRand.Next(5) == 0)
						{
							type = -2;
						}
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num6, Main.maxTilesY), genRand.Next(2, 5), genRand.Next(2, 20), type);
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num6, Main.maxTilesY), genRand.Next(8, 15), genRand.Next(7, 30), type);
					}
					if (num8 <= (float)Main.maxTilesY)
					{
						UI.main.NextProgressStep(Lang.gen[8]);
						num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 3E-05f);
						for (int num57 = 0; num57 < num55; num57++)
						{
							UI.main.progress = (float)num57 / (float)num55;
							int type2 = -1;
							if (genRand.Next(6) == 0)
							{
								type2 = -2;
							}
							TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5, (int)num8 + 1), genRand.Next(5, 15), genRand.Next(30, 200), type2);
						}
					}
					if (num8 <= (float)Main.maxTilesY)
					{
						UI.main.NextProgressStep(Lang.gen[9]);
						num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.00013f);
						for (int num58 = 0; num58 < num55; num58++)
						{
							UI.main.progress = (float)num58 / (float)num55;
							int type3 = -1;
							if (genRand.Next(10) == 0)
							{
								type3 = -2;
							}
							TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num8, Main.maxTilesY), genRand.Next(6, 20), genRand.Next(50, 300), type3);
						}
					}
					UI.main.NextProgressStep(Lang.gen[10]);
					num55 = (int)((float)Main.maxTilesX * 0.0025f);
					for (int num59 = 0; num59 < num55; num59++)
					{
						num54 = genRand.Next(Main.maxTilesX);
						for (int num60 = 0; (float)num60 < num6; num60++)
						{
							if (Main.tile[num54, num60].active != 0)
							{
								TileRunner(num54, num60, genRand.Next(3, 6), genRand.Next(5, 50), -1, addTile: false, new Vector2((float)genRand.Next(-10, 11) * 0.1f, 1f));
								break;
							}
						}
					}
					num55 = (int)((float)Main.maxTilesX * 0.0007f);
					for (int num61 = 0; num61 < num55; num61++)
					{
						num54 = genRand.Next(Main.maxTilesX);
						for (int num62 = 0; (float)num62 < num6; num62++)
						{
							if (Main.tile[num54, num62].active != 0)
							{
								TileRunner(num54, num62, genRand.Next(10, 15), genRand.Next(50, 130), -1, addTile: false, new Vector2((float)genRand.Next(-10, 11) * 0.1f, 2f));
								break;
							}
						}
					}
					num55 = (int)((float)Main.maxTilesX * 0.0003f);
					for (int num63 = 0; num63 < num55; num63++)
					{
						num54 = genRand.Next(Main.maxTilesX);
						for (int num64 = 0; (float)num64 < num6; num64++)
						{
							if (Main.tile[num54, num64].active != 0)
							{
								TileRunner(num54, num64, genRand.Next(12, 25), genRand.Next(150, 500), -1, addTile: false, new Vector2((float)genRand.Next(-10, 11) * 0.1f, 4f));
								TileRunner(num54, num64, genRand.Next(8, 17), genRand.Next(60, 200), -1, addTile: false, new Vector2((float)genRand.Next(-10, 11) * 0.1f, 2f));
								TileRunner(num54, num64, genRand.Next(5, 13), genRand.Next(40, 170), -1, addTile: false, new Vector2((float)genRand.Next(-10, 11) * 0.1f, 2f));
								break;
							}
						}
					}
					num55 = (int)((float)Main.maxTilesX * 0.0004f);
					for (int num65 = 0; num65 < num55; num65++)
					{
						num54 = genRand.Next(Main.maxTilesX);
						for (int num66 = 0; (float)num66 < num6; num66++)
						{
							if (Main.tile[num54, num66].active != 0)
							{
								TileRunner(num54, num66, genRand.Next(7, 12), genRand.Next(150, 250), -1, addTile: false, new Vector2(0f, 1f), noYChange: true);
								break;
							}
						}
					}
					num55 = (int)((float)Main.maxTilesX * 0.00119047624f);
					for (int num67 = 0; num67 < num55; num67++)
					{
						Caverer(genRand.Next(100, Main.maxTilesX - 100), genRand.Next(Main.rockLayer, Main.maxTilesY - 400));
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.002f);
					for (int num68 = 0; num68 < num55; num68++)
					{
						int num69 = genRand.Next(1, Main.maxTilesX - 1);
						int num70 = genRand.Next((int)num5, (int)num6);
						if (num70 >= Main.maxTilesY)
						{
							num70 = Main.maxTilesY - 2;
						}
						if (Main.tile[num69 - 1, num70].active != 0 && Main.tile[num69 - 1, num70].type == 0 && Main.tile[num69 + 1, num70].active != 0 && Main.tile[num69 + 1, num70].type == 0 && Main.tile[num69, num70 - 1].active != 0 && Main.tile[num69, num70 - 1].type == 0 && Main.tile[num69, num70 + 1].active != 0 && Main.tile[num69, num70 + 1].type == 0)
						{
							Main.tile[num69, num70].active = 1;
							Main.tile[num69, num70].type = 2;
						}
						num69 = genRand.Next(1, Main.maxTilesX - 1);
						num70 = genRand.Next((int)num5);
						if (num70 >= Main.maxTilesY)
						{
							num70 = Main.maxTilesY - 2;
						}
						if (Main.tile[num69 - 1, num70].active != 0 && Main.tile[num69 - 1, num70].type == 0 && Main.tile[num69 + 1, num70].active != 0 && Main.tile[num69 + 1, num70].type == 0 && Main.tile[num69, num70 - 1].active != 0 && Main.tile[num69, num70 - 1].type == 0 && Main.tile[num69, num70 + 1].active != 0 && Main.tile[num69, num70 + 1].type == 0)
						{
							Main.tile[num69, num70].active = 1;
							Main.tile[num69, num70].type = 2;
						}
					}
					UI.main.NextProgressStep(Lang.gen[11]);
					int num71 = 0;
					float num72 = (float)genRand.Next(15, 30) * 0.01f;
					if (num9 == -1)
					{
						num72 = 1f - num72;
					}
					num71 = (int)((float)Main.maxTilesX * num72);
					int num73 = Main.maxTilesY + Main.rockLayer >> 1;
					float num74 = (float)Main.maxTilesX * 0.000357142853f;
					num71 += genRand.Next((int)(-100f * num74), (int)(101f * num74));
					num73 += genRand.Next((int)(-100f * num74), (int)(101f * num74));
					int num75 = num71;
					int num76 = num73;
					TileRunner(num71, num73, genRand.Next((int)(250f * num74), (int)(500f * num74)), genRand.Next(50, 150), 59, addTile: false, new Vector2(num9 * 3, 0f));
					for (int num77 = (int)(6f * num74); num77 > 0; num77--)
					{
						TileRunner(num71 + genRand.Next(-(int)(125f * num74), (int)(125f * num74)), num73 + genRand.Next(-(int)(125f * num74), (int)(125f * num74)), genRand.Next(3, 7), genRand.Next(3, 8), genRand.Next(63, 65));
					}
					UI.main.progress = 0.15f;
					num71 += genRand.Next((int)(-250f * num74), (int)(251f * num74));
					num73 += genRand.Next((int)(-150f * num74), (int)(151f * num74));
					int num78 = num71;
					int num79 = num73;
					int num80 = num71;
					int num81 = num73;
					mudWall = true;
					TileRunner(num71, num73, genRand.Next((int)(250f * num74), (int)(500f * num74)), genRand.Next(50, 150), 59);
					mudWall = false;
					for (int num82 = (int)(6f * num74); num82 > 0; num82--)
					{
						TileRunner(num71 + genRand.Next(-(int)(125f * num74), (int)(125f * num74)), num73 + genRand.Next(-(int)(125f * num74), (int)(125f * num74)), genRand.Next(3, 7), genRand.Next(3, 8), genRand.Next(65, 67));
					}
					mudWall = true;
					UI.main.progress = 0.3f;
					num71 += genRand.Next((int)(-400f * num74), (int)(401f * num74));
					num73 += genRand.Next((int)(-150f * num74), (int)(151f * num74));
					int num83 = num71;
					int num84 = num73;
					TileRunner(num71, num73, genRand.Next((int)(250f * num74), (int)(500f * num74)), genRand.Next(50, 150), 59, addTile: false, new Vector2(num9 * -3, 0f));
					mudWall = false;
					for (int num85 = (int)(6f * num74); num85 > 0; num85--)
					{
						TileRunner(num71 + genRand.Next(-(int)(125f * num74), (int)(125f * num74)), num73 + genRand.Next(-(int)(125f * num74), (int)(125f * num74)), genRand.Next(3, 7), genRand.Next(3, 8), genRand.Next(67, 69));
					}
					mudWall = true;
					UI.main.progress = 0.45f;
					num71 = (num75 + num78 + num83) / 3;
					num73 = (num76 + num79 + num84) / 3;
					TileRunner(num71, num73, genRand.Next((int)(400f * num74), (int)(600f * num74)), 10000, 59, addTile: false, new Vector2(0f, -20f), noYChange: true);
					JungleRunner(num71, num73);
					UI.main.progress = 0.6f;
					mudWall = false;
					List<uint> list = new List<uint>();
					int num86 = 0;
					for (int num87 = 20; num87 < Main.maxTilesX - 20; num87++)
					{
						for (int num88 = Main.rockLayer; num88 < Main.maxTilesY - 200; num88++)
						{
							if (Main.tile[num87, num88].wall == 15)
							{
								list.Add((uint)((num71 << 16) | num73));
								num86++;
							}
						}
					}
					int num89 = 0;
					while (num86 > 0 && num89 < Main.maxTilesX / 10)
					{
						int index = genRand.Next(num86--);
						num71 = (int)(list[index] >> 16);
						num73 = (int)(list[index] & 0xFFFF);
						list.RemoveAt(index);
						MudWallRunner(num71, num73);
						num89++;
					}
					num71 = num80;
					num73 = num81;
					num55 = (int)(20f * num74);
					for (int num90 = 0; num90 <= num55; num90++)
					{
						UI.main.progress = 0.6f + 0.2f * ((float)num90 / (float)num55);
						num71 += genRand.Next((int)(-5f * num74), (int)(6f * num74));
						num73 += genRand.Next((int)(-5f * num74), (int)(6f * num74));
						TileRunner(num71, num73, genRand.Next(40, 100), genRand.Next(300, 500), 59);
					}
					num55 = (int)(10f * num74);
					for (int num91 = 0; num91 <= num55; num91++)
					{
						UI.main.progress = 0.8f + 0.2f * ((float)num91 / (float)num55);
						num71 = num80 + genRand.Next((int)(-600f * num74), (int)(600f * num74));
						num73 = num81 + genRand.Next((int)(-200f * num74), (int)(200f * num74));
						while (num71 < 1 || num71 >= Main.maxTilesX - 1 || num73 < 1 || num73 >= Main.maxTilesY - 1 || Main.tile[num71, num73].type != 59)
						{
							num71 = num80 + genRand.Next((int)(-600f * num74), (int)(600f * num74));
							num73 = num81 + genRand.Next((int)(-200f * num74), (int)(200f * num74));
						}
						for (int num92 = 0; (float)num92 < 8f * num74; num92++)
						{
							num71 += genRand.Next(-30, 31);
							num73 += genRand.Next(-30, 31);
							int type4 = -1;
							if (genRand.Next(7) == 0)
							{
								type4 = -2;
							}
							TileRunner(num71, num73, genRand.Next(10, 20), genRand.Next(30, 70), type4);
						}
					}
					for (int num93 = 0; (float)num93 <= 300f * num74; num93++)
					{
						num71 = num80 + genRand.Next((int)(-600f * num74), (int)(600f * num74));
						num73 = num81 + genRand.Next((int)(-200f * num74), (int)(200f * num74));
						while (num71 < 1 || num71 >= Main.maxTilesX - 1 || num73 < 1 || num73 >= Main.maxTilesY - 1 || Main.tile[num71, num73].type != 59)
						{
							num71 = num80 + genRand.Next((int)(-600f * num74), (int)(600f * num74));
							num73 = num81 + genRand.Next((int)(-200f * num74), (int)(200f * num74));
						}
						TileRunner(num71, num73, genRand.Next(4, 10), genRand.Next(5, 30), 1);
						if (genRand.Next(4) == 0)
						{
							int type5 = genRand.Next(63, 69);
							TileRunner(num71 + genRand.Next(-1, 2), num73 + genRand.Next(-1, 2), genRand.Next(3, 7), genRand.Next(4, 8), type5);
						}
					}
					int num94 = (int)((float)(genRand.Next(6, 10) * Main.maxTilesX) * 0.000238095236f);
					for (int num95 = num94 - 1; num95 >= 0; num95--)
					{
						do
						{
							num71 = genRand.Next(20, Main.maxTilesX - 20);
							num73 = genRand.Next(Main.worldSurface + Main.rockLayer >> 1, Main.maxTilesY - 300);
						}
						while (Main.tile[num71, num73].type != 59);
						int num96 = genRand.Next(2, 4);
						int num97 = genRand.Next(2, 4);
						for (int num98 = num71 - num96 - 1; num98 <= num71 + num96 + 1; num98++)
						{
							for (int num99 = num73 - num97 - 1; num99 <= num73 + num97 + 1; num99++)
							{
								Main.tile[num98, num99].active = 1;
								Main.tile[num98, num99].type = 45;
								Main.tile[num98, num99].liquid = 0;
								Main.tile[num98, num99].lava = 0;
							}
						}
						for (int num100 = num71 - num96; num100 <= num71 + num96; num100++)
						{
							for (int num101 = num73 - num97; num101 <= num73 + num97; num101++)
							{
								Main.tile[num100, num101].active = 0;
							}
						}
						int num102 = 0;
						int i2;
						int j2;
						do
						{
							i2 = genRand.Next(num71 - num96, num71 + num96 + 1);
							j2 = genRand.Next(num73 - num97, num73 + num97 - 2);
						}
						while (!PlaceTile(i2, j2, 4, mute: true) && ++num102 < 100);
						for (int num103 = num73 + num97 - 2; num103 <= num73 + num97 - 1; num103++)
						{
							for (int num104 = num71 - num96 - 1; num104 <= num71 + num96 + 1; num104++)
							{
								Main.tile[num104, num103].active = 0;
							}
						}
						for (int num105 = num71 - num96 - 1; num105 <= num71 + num96 + 1; num105++)
						{
							int num106 = 4;
							int num107 = num73 + num97 + 2;
							while (Main.tile[num105, num107].active == 0 && num107 < Main.maxTilesY && num106 > 0)
							{
								Main.tile[num105, num107].active = 1;
								Main.tile[num105, num107].type = 59;
								num107++;
								num106--;
							}
						}
						num96 -= genRand.Next(1, 3);
						int num108 = num73 - num97 - 2;
						while (num96 >= 0)
						{
							for (int num109 = num71 - num96 - 1; num109 <= num71 + num96 + 1; num109++)
							{
								Main.tile[num109, num108].active = 1;
								Main.tile[num109, num108].type = 45;
							}
							num96 -= genRand.Next(1, 3);
							num108--;
						}
						JChest[numJChests].X = (short)num71;
						JChest[numJChests].Y = (short)num73;
						numJChests++;
					}
					for (int num110 = 0; num110 < Main.maxTilesY; num110++)
					{
						for (int num111 = 0; num111 < Main.maxTilesX; num111++)
						{
							if (Main.tile[num111, num110].active != 0)
							{
								try
								{
									grassSpread = 0;
									SpreadGrass(num111, num110, 59, 60);
								}
								catch
								{
									grassSpread = 0;
									SpreadGrass(num111, num110, 59, 60, repeat: false);
								}
							}
						}
					}
					numIslandHouses = 0;
					houseCount = 0;
					UI.main.NextProgressStep(Lang.gen[12]);
					num55 = (int)((double)Main.maxTilesX * 0.0008);
					for (int num112 = 0; num112 < num55; num112++)
					{
						int num113 = 0;
						bool flag5 = false;
						int num114 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
						bool flag6;
						do
						{
							flag6 = true;
							while (num114 > (Main.maxTilesX >> 1) - 80 && num114 < (Main.maxTilesX >> 1) + 80)
							{
								num114 = genRand.Next((int)((double)Main.maxTilesX * 0.1), (int)((double)Main.maxTilesX * 0.9));
							}
							for (int num115 = 0; num115 < numIslandHouses; num115++)
							{
								if (num114 > fih[num115].X - 80 && num114 < fih[num115].X + 80)
								{
									num113++;
									flag6 = false;
									break;
								}
							}
							if (num113 >= 200)
							{
								flag5 = true;
								break;
							}
						}
						while (!flag6);
						if (!flag5)
						{
							for (int num116 = 200; num116 < Main.worldSurface; num116++)
							{
								if (Main.tile[num114, num116].active != 0)
								{
									int num117 = num114;
									int num118 = genRand.Next(90, num116 - 100);
									while ((float)num118 > num5 - 50f)
									{
										num118--;
									}
									FloatingIsland(num117, num118);
									fih[numIslandHouses].X = (short)num117;
									fih[numIslandHouses].Y = (short)num118;
									numIslandHouses++;
									break;
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[13]);
					for (int num119 = Main.maxTilesX / 500 - 1; num119 >= 0; num119--)
					{
						int i3 = genRand.Next((int)((float)Main.maxTilesX * 0.3f), (int)((float)Main.maxTilesX * 0.7f));
						int j3 = genRand.Next(Main.rockLayer, Main.maxTilesY - 249);
						ShroomPatch(i3, j3);
					}
					for (int num120 = 0; num120 < Main.maxTilesX; num120++)
					{
						for (int num121 = Main.worldSurface; num121 < Main.maxTilesY; num121++)
						{
							if (Main.tile[num120, num121].active != 0)
							{
								grassSpread = 0;
								SpreadGrass(num120, num121, 59, 70, repeat: false);
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[14]);
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.001f);
					for (int num122 = 0; num122 < num55; num122++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num7, Main.maxTilesY), genRand.Next(2, 6), genRand.Next(2, 40), 59);
					}
					UI.main.NextProgressStep(Lang.gen[15]);
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0001f);
					for (int num123 = 0; num123 < num55; num123++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num8, Main.maxTilesY), genRand.Next(5, 12), genRand.Next(15, 50), 123);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0005f);
					for (int num124 = 0; num124 < num55; num124++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num8, Main.maxTilesY), genRand.Next(2, 5), genRand.Next(2, 5), 123);
					}
					UI.main.NextProgressStep(Lang.gen[16]);
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 6E-05f);
					for (int num125 = 0; num125 < num55; num125++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5, (int)num6), genRand.Next(3, 6), genRand.Next(2, 6), 7);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 8E-05f);
					for (int num126 = 0; num126 < num55; num126++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num6, (int)num8), genRand.Next(3, 7), genRand.Next(3, 7), 7);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0002f);
					for (int num127 = 0; num127 < num55; num127++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num7, Main.maxTilesY), genRand.Next(4, 9), genRand.Next(4, 8), 7);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 3E-05f);
					for (int num128 = 0; num128 < num55; num128++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5, (int)num6), genRand.Next(3, 7), genRand.Next(2, 5), 6);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 8E-05f);
					for (int num129 = 0; num129 < num55; num129++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num6, (int)num8), genRand.Next(3, 6), genRand.Next(3, 6), 6);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0002f);
					for (int num130 = 0; num130 < num55; num130++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num7, Main.maxTilesY), genRand.Next(4, 9), genRand.Next(4, 8), 6);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05f);
					for (int num131 = 0; num131 < num55; num131++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num6, (int)num8), genRand.Next(3, 6), genRand.Next(3, 6), 9);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.00015f);
					for (int num132 = 0; num132 < num55; num132++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num7, Main.maxTilesY), genRand.Next(4, 9), genRand.Next(4, 8), 9);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.00017f);
					for (int num133 = 0; num133 < num55; num133++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5), genRand.Next(4, 9), genRand.Next(4, 8), 9);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.00012f);
					for (int num134 = 0; num134 < num55; num134++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num7, Main.maxTilesY), genRand.Next(4, 8), genRand.Next(4, 8), 8);
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num5 - 20), genRand.Next(4, 8), genRand.Next(4, 8), 8);
					}
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 2E-05f);
					for (int num135 = 0; num135 < num55; num135++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next((int)num7, Main.maxTilesY), genRand.Next(2, 4), genRand.Next(3, 6), 22);
					}
					UI.main.NextProgressStep(Lang.gen[17]);
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0006f);
					for (int num136 = 0; num136 < num55; num136++)
					{
						int num137 = genRand.Next(20, Main.maxTilesX - 20);
						int num138 = genRand.Next((int)num5, Main.maxTilesY - 20);
						if (num136 < numMCaves)
						{
							num137 = mCave[num136].X;
							num138 = mCave[num136].Y;
						}
						if (Main.tile[num137, num138].active == 0 && (num138 > Main.worldSurface || Main.tile[num137, num138].wall > 0))
						{
							while (Main.tile[num137, num138].active == 0 && num138 > (int)num5)
							{
								num138--;
							}
							num138++;
							int num139 = 1;
							if (genRand.Next(2) == 0)
							{
								num139 = -1;
							}
							for (; Main.tile[num137, num138].active == 0 && num137 > 10 && num137 < Main.maxTilesX - 10; num137 += num139)
							{
							}
							num137 -= num139;
							if (num138 > Main.worldSurface || Main.tile[num137, num138].wall > 0)
							{
								TileRunner(num137, num138, genRand.Next(4, 11), genRand.Next(2, 4), 51, addTile: true, new Vector2(num139, -1f), noYChange: false, overRide: false);
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[18]);
					int num140 = Main.maxTilesY - genRand.Next(150, 190);
					for (int num141 = 0; num141 < Main.maxTilesX; num141++)
					{
						UI.main.progress = (float)num141 * 0.2f / (float)Main.maxTilesX;
						num140 += genRand.Next(-3, 4);
						if (num140 < Main.maxTilesY - 190)
						{
							num140 = Main.maxTilesY - 190;
						}
						else if (num140 > Main.maxTilesY - 160)
						{
							num140 = Main.maxTilesY - 160;
						}
						int num142 = num140 - 20 - genRand.Next(3);
						Tile* ptr3 = ptr + (num141 * 1440 + num142);
						do
						{
							if (num142 >= num140)
							{
								ptr3->active = 0;
								ptr3->lava = 0;
								ptr3->liquid = 0;
							}
							else
							{
								ptr3->type = 57;
							}
							ptr3++;
						}
						while (++num142 < Main.maxTilesY);
					}
					int num143 = Main.maxTilesY - genRand.Next(40, 70);
					for (int num144 = 10; num144 < Main.maxTilesX - 10; num144++)
					{
						num143 += genRand.Next(-10, 11);
						if (num143 > Main.maxTilesY - 60)
						{
							num143 = Main.maxTilesY - 60;
						}
						else if (num143 < Main.maxTilesY - 100)
						{
							num143 = Main.maxTilesY - 120;
						}
						int num145 = num143;
						Tile* ptr4 = ptr + (num144 * 1440 + num145);
						do
						{
							if (ptr4->active == 0)
							{
								ptr4->lava = 32;
								ptr4->liquid = byte.MaxValue;
							}
						}
						while (++num145 < Main.maxTilesY - 10);
					}
					for (int num146 = 0; num146 < Main.maxTilesX; num146++)
					{
						if (genRand.Next(50) == 0)
						{
							int num147 = Main.maxTilesY - 65;
							while (Main.tile[num146, num147].active == 0 && num147 > Main.maxTilesY - 135)
							{
								num147--;
							}
							TileRunner(genRand.Next(Main.maxTilesX), num147 + genRand.Next(20, 50), genRand.Next(15, 20), 1000, 57, addTile: true, new Vector2(0f, genRand.Next(1, 3)), noYChange: true);
							UI.main.progress = 0.2f + (float)num146 * 0.05f / (float)Main.maxTilesX;
						}
					}
					Liquid.QuickWater(0.25, 3, -1, 0.25);
					for (int num148 = 0; num148 < Main.maxTilesX; num148++)
					{
						if (genRand.Next(13) == 0)
						{
							int num149 = Main.maxTilesY - 65;
							while ((Main.tile[num148, num149].liquid > 0 || Main.tile[num148, num149].active != 0) && num149 > Main.maxTilesY - 140)
							{
								num149--;
							}
							TileRunner(num148, num149 - genRand.Next(2, 5), genRand.Next(5, 30), 1000, 57, addTile: true, new Vector2(0f, genRand.Next(1, 3)), noYChange: true);
							int num150 = genRand.Next(1, 3);
							if (genRand.Next(3) == 0)
							{
								num150 >>= 1;
							}
							if (genRand.Next(2) == 0)
							{
								TileRunner(num148, num149 - genRand.Next(2, 5), genRand.Next(5, 15) * num150, genRand.Next(10, 15) * num150, 57, addTile: true, new Vector2(1f, 0.3f));
							}
							if (genRand.Next(2) == 0)
							{
								num150 = genRand.Next(1, 3);
								TileRunner(num148, num149 - genRand.Next(2, 5), genRand.Next(5, 15) * num150, genRand.Next(10, 15) * num150, 57, addTile: true, new Vector2(-1f, 0.3f));
							}
							TileRunner(num148 + genRand.Next(-10, 10), num149 + genRand.Next(-10, 10), genRand.Next(5, 15), genRand.Next(5, 10), -2, addTile: false, new Vector2(genRand.Next(-1, 3), genRand.Next(-1, 3)));
							if (genRand.Next(3) == 0)
							{
								TileRunner(num148 + genRand.Next(-10, 10), num149 + genRand.Next(-10, 10), genRand.Next(10, 30), genRand.Next(10, 20), -2, addTile: false, new Vector2(genRand.Next(-1, 3), genRand.Next(-1, 3)));
							}
							if (genRand.Next(5) == 0)
							{
								TileRunner(num148 + genRand.Next(-15, 15), num149 + genRand.Next(-15, 10), genRand.Next(15, 30), genRand.Next(5, 20), -2, addTile: false, new Vector2(genRand.Next(-1, 3), genRand.Next(-1, 3)));
							}
							UI.main.progress = 0.5f + (float)num148 * 0.4f / (float)Main.maxTilesX;
						}
					}
					UI.main.progress = 0.9f;
					for (int num151 = 0; num151 < Main.maxTilesX; num151++)
					{
						TileRunner(genRand.Next(20, Main.maxTilesX - 20), genRand.Next(Main.maxTilesY - 180, Main.maxTilesY - 10), genRand.Next(2, 7), genRand.Next(2, 7), -2);
					}
					for (int num152 = 0; num152 < Main.maxTilesX; num152++)
					{
						if (Main.tile[num152, Main.maxTilesY - 145].active == 0)
						{
							Main.tile[num152, Main.maxTilesY - 145].liquid = byte.MaxValue;
							Main.tile[num152, Main.maxTilesY - 145].lava = 32;
						}
						if (Main.tile[num152, Main.maxTilesY - 144].active == 0)
						{
							Main.tile[num152, Main.maxTilesY - 144].liquid = byte.MaxValue;
							Main.tile[num152, Main.maxTilesY - 144].lava = 32;
						}
					}
					UI.main.progress = 0.95f;
					num55 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * 0.0008f);
					for (int num153 = 0; num153 < num55; num153++)
					{
						TileRunner(genRand.Next(Main.maxTilesX), genRand.Next(Main.maxTilesY - 140, Main.maxTilesY), genRand.Next(2, 7), genRand.Next(3, 7), 58);
					}
					UI.main.progress = 0.98f;
					AddHellHouses();
					UI.main.NextProgressStep(Lang.gen[19]);
					num55 = genRand.Next(2, (int)((float)Main.maxTilesX * 0.005f));
					for (int num154 = 0; num154 < num55; num154++)
					{
						UI.main.progress = (float)num154 / (float)num55;
						int num155 = genRand.Next(300, Main.maxTilesX - 300);
						while (num155 > (Main.maxTilesX >> 1) - 50 && num155 < (Main.maxTilesX >> 1) + 50)
						{
							num155 = genRand.Next(300, Main.maxTilesX - 300);
						}
						int num156;
						for (num156 = (int)num5 - 20; Main.tile[num155, num156].active == 0; num156++)
						{
						}
						Lakinater(num155, num156);
					}
					UI.main.NextProgressStep(Lang.gen[58]);
					int num157 = 0;
					if (num9 == -1)
					{
						num157 = genRand.Next((int)((float)Main.maxTilesX * 0.05f), (int)((float)Main.maxTilesX * 0.2f));
						num9 = -1;
					}
					else
					{
						num157 = genRand.Next((int)((float)Main.maxTilesX * 0.8f), (int)((float)Main.maxTilesX * 0.95f));
						num9 = 1;
					}
					int y = (Main.rockLayer + Main.maxTilesY >> 1) + genRand.Next(-200, 200);
					MakeDungeon(num157, y);
					UI.main.NextProgressStep(Lang.gen[20]);
					num55 = (int)((float)Main.maxTilesX * 0.00045f);
					for (int num158 = 0; num158 < num55; num158++)
					{
						UI.main.progress = (float)num158 / (float)num55;
						bool flag7 = false;
						int num159 = 0;
						int num160 = 0;
						int num161 = 0;
						do
						{
							int num162 = 0;
							int num163 = Main.maxTilesX >> 1;
							int num164 = 200;
							num159 = genRand.Next(320, Main.maxTilesX - 320);
							num160 = num159 - genRand.Next(200) - 100;
							num161 = num159 + genRand.Next(200) + 100;
							if (num160 < 285)
							{
								num160 = 285;
							}
							if (num161 > Main.maxTilesX - 285)
							{
								num161 = Main.maxTilesX - 285;
							}
							if (num159 > num163 - num164 && num159 < num163 + num164)
							{
								flag7 = false;
							}
							else if (num160 > num163 - num164 && num160 < num163 + num164)
							{
								flag7 = false;
							}
							else if (num161 > num163 - num164 && num161 < num163 + num164)
							{
								flag7 = false;
							}
							else
							{
								flag7 = true;
								int num165 = num160;
								while (flag7 && num165 < num161)
								{
									for (int num166 = 0; num166 < Main.worldSurface; num166 += 5)
									{
										if (Main.tile[num165, num166].active != 0 && Main.tileDungeon[Main.tile[num165, num166].type])
										{
											flag7 = false;
											break;
										}
									}
									num165++;
								}
							}
							if (num162 < 200 && JungleX > num160 && JungleX < num161)
							{
								num162++;
								flag7 = false;
							}
						}
						while (!flag7);
						int num167 = 0;
						for (int num168 = num160; num168 < num161; num168++)
						{
							if (num167 > 0)
							{
								num167--;
							}
							if (num168 == num159 || num167 == 0)
							{
								for (int num169 = (int)num5; num169 < Main.worldSurface - 1; num169++)
								{
									if (Main.tile[num168, num169].active != 0 || Main.tile[num168, num169].wall > 0)
									{
										if (num168 == num159)
										{
											num167 = 20;
											ChasmRunner(num168, num169, genRand.Next(150) + 150, makeOrb: true);
										}
										else if (genRand.Next(35) == 0 && num167 == 0)
										{
											num167 = 30;
											bool makeOrb = true;
											ChasmRunner(num168, num169, genRand.Next(50) + 50, makeOrb);
										}
										break;
									}
								}
							}
							for (int num170 = (int)num5; num170 < Main.worldSurface - 1; num170++)
							{
								if (Main.tile[num168, num170].active != 0)
								{
									int num171 = num170 + genRand.Next(10, 14);
									for (int num172 = num170; num172 < num171; num172++)
									{
										if ((Main.tile[num168, num172].type == 59 || Main.tile[num168, num172].type == 60) && num168 >= num160 + genRand.Next(5) && num168 < num161 - genRand.Next(5))
										{
											Main.tile[num168, num172].type = 0;
										}
									}
									break;
								}
							}
						}
						double num173 = Main.worldSurface + 40;
						for (int num174 = num160; num174 < num161; num174++)
						{
							num173 += (double)genRand.Next(-2, 3);
							if (num173 < (double)(Main.worldSurface + 30))
							{
								num173 = Main.worldSurface + 30;
							}
							if (num173 > (double)(Main.worldSurface + 50))
							{
								num173 = Main.worldSurface + 50;
							}
							num54 = num174;
							bool flag8 = false;
							for (int num175 = (int)num5; (double)num175 < num173; num175++)
							{
								if (Main.tile[num54, num175].active != 0)
								{
									if (Main.tile[num54, num175].type == 53 && num54 >= num160 + genRand.Next(5) && num54 <= num161 - genRand.Next(5))
									{
										Main.tile[num54, num175].type = 0;
									}
									if (Main.tile[num54, num175].type == 0 && num175 < Main.worldSurface - 1 && !flag8)
									{
										grassSpread = 0;
										SpreadGrass(num54, num175, 0, 23);
									}
									flag8 = true;
									if (Main.tile[num54, num175].type == 1 && num54 >= num160 + genRand.Next(5) && num54 <= num161 - genRand.Next(5))
									{
										Main.tile[num54, num175].type = 25;
									}
									if (Main.tile[num54, num175].type == 2)
									{
										Main.tile[num54, num175].type = 23;
									}
								}
							}
						}
						for (int num176 = num160; num176 < num161; num176++)
						{
							for (int num177 = 0; num177 < Main.maxTilesY - 50; num177++)
							{
								if (Main.tile[num176, num177].active != 0 && Main.tile[num176, num177].type == 31)
								{
									int num178 = num176 - 13;
									int num179 = num176 + 13;
									int num180 = num177 - 13;
									int num181 = num177 + 13;
									for (int num182 = num178; num182 < num179; num182++)
									{
										if (num182 > 10 && num182 < Main.maxTilesX - 10)
										{
											for (int num183 = num180; num183 < num181; num183++)
											{
												if (genRand.Next(3) != 0 && Math.Abs(num182 - num176) + Math.Abs(num183 - num177) < 9 + genRand.Next(11) && Main.tile[num182, num183].type != 31)
												{
													Main.tile[num182, num183].active = 1;
													Main.tile[num182, num183].type = 25;
													if (Math.Abs(num182 - num176) <= 1 && Math.Abs(num183 - num177) <= 1)
													{
														Main.tile[num182, num183].active = 0;
													}
												}
												if (Main.tile[num182, num183].type != 31 && Math.Abs(num182 - num176) <= 2 + genRand.Next(3) && Math.Abs(num183 - num177) <= 2 + genRand.Next(3))
												{
													Main.tile[num182, num183].active = 0;
												}
											}
										}
									}
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[21]);
					for (int num184 = 0; num184 < numMCaves; num184++)
					{
						int x = mCave[num184].X;
						int y2 = mCave[num184].Y;
						CaveOpenater(x, y2);
						Cavinator(x, y2, genRand.Next(40, 50));
					}
					int num185 = 0;
					int num186 = 0;
					int num187 = 20;
					int num188 = Main.maxTilesX - 20;
					UI.main.NextProgressStep(Lang.gen[22]);
					for (int num189 = 0; num189 < 2; num189++)
					{
						int num190 = 0;
						int num191 = 0;
						if (num189 == 0)
						{
							num190 = 0;
							num191 = genRand.Next(125, 200) + 50;
							if (num9 == 1)
							{
								num191 = 275;
							}
							int num192 = 0;
							float num193 = 1f;
							int num194;
							for (num194 = 0; Main.tile[num191 - 1, num194].active == 0; num194++)
							{
							}
							num185 = num194;
							num194 += genRand.Next(1, 5);
							for (int num195 = num191 - 1; num195 >= num190; num195--)
							{
								num192++;
								if (num192 < 3)
								{
									num193 += (float)genRand.Next(10, 20) * 0.2f;
								}
								else if (num192 < 6)
								{
									num193 += (float)genRand.Next(10, 20) * 0.15f;
								}
								else if (num192 < 9)
								{
									num193 += (float)genRand.Next(10, 20) * 0.1f;
								}
								else if (num192 < 15)
								{
									num193 += (float)genRand.Next(10, 20) * 0.07f;
								}
								else if (num192 < 50)
								{
									num193 += (float)genRand.Next(10, 20) * 0.05f;
								}
								else if (num192 < 75)
								{
									num193 += (float)genRand.Next(10, 20) * 0.04f;
								}
								else if (num192 < 100)
								{
									num193 += (float)genRand.Next(10, 20) * 0.03f;
								}
								else if (num192 < 125)
								{
									num193 += (float)genRand.Next(10, 20) * 0.02f;
								}
								else if (num192 < 150)
								{
									num193 += (float)genRand.Next(10, 20) * 0.01f;
								}
								else if (num192 < 175)
								{
									num193 += (float)genRand.Next(10, 20) * 0.005f;
								}
								else if (num192 < 200)
								{
									num193 += (float)genRand.Next(10, 20) * 0.001f;
								}
								else if (num192 < 230)
								{
									num193 += (float)genRand.Next(10, 20) * 0.01f;
								}
								else if (num192 < 235)
								{
									num193 += (float)genRand.Next(10, 20) * 0.05f;
								}
								else if (num192 < 240)
								{
									num193 += (float)genRand.Next(10, 20) * 0.1f;
								}
								else if (num192 < 245)
								{
									num193 += (float)genRand.Next(10, 20) * 0.05f;
								}
								else if (num192 < 255)
								{
									num193 += (float)genRand.Next(10, 20) * 0.01f;
								}
								if (num192 == 235)
								{
									num188 = num195;
								}
								if (num192 == 235)
								{
									num187 = num195;
								}
								int num196 = genRand.Next(15, 20);
								for (int num197 = 0; (float)num197 < (float)num194 + num193 + (float)num196; num197++)
								{
									if ((float)num197 < (float)num194 + num193 * 0.75f - 3f)
									{
										Main.tile[num195, num197].active = 0;
										if (num197 > num194)
										{
											Main.tile[num195, num197].liquid = byte.MaxValue;
										}
										else if (num197 == num194)
										{
											Main.tile[num195, num197].liquid = 127;
										}
									}
									else if (num197 > num194)
									{
										Main.tile[num195, num197].type = 53;
										Main.tile[num195, num197].active = 1;
									}
									Main.tile[num195, num197].wall = 0;
								}
							}
						}
						else
						{
							num190 = Main.maxTilesX - genRand.Next(125, 200) - 50;
							num191 = Main.maxTilesX;
							if (num9 == -1)
							{
								num190 = Main.maxTilesX - 275;
							}
							float num198 = 1f;
							int num199 = 0;
							int num200;
							for (num200 = 0; Main.tile[num190, num200].active == 0; num200++)
							{
							}
							num186 = num200;
							num200 += genRand.Next(1, 5);
							for (int num201 = num190; num201 < num191; num201++)
							{
								num199++;
								if (num199 < 3)
								{
									num198 += (float)genRand.Next(10, 20) * 0.2f;
								}
								else if (num199 < 6)
								{
									num198 += (float)genRand.Next(10, 20) * 0.15f;
								}
								else if (num199 < 9)
								{
									num198 += (float)genRand.Next(10, 20) * 0.1f;
								}
								else if (num199 < 15)
								{
									num198 += (float)genRand.Next(10, 20) * 0.07f;
								}
								else if (num199 < 50)
								{
									num198 += (float)genRand.Next(10, 20) * 0.05f;
								}
								else if (num199 < 75)
								{
									num198 += (float)genRand.Next(10, 20) * 0.04f;
								}
								else if (num199 < 100)
								{
									num198 += (float)genRand.Next(10, 20) * 0.03f;
								}
								else if (num199 < 125)
								{
									num198 += (float)genRand.Next(10, 20) * 0.02f;
								}
								else if (num199 < 150)
								{
									num198 += (float)genRand.Next(10, 20) * 0.01f;
								}
								else if (num199 < 175)
								{
									num198 += (float)genRand.Next(10, 20) * 0.005f;
								}
								else if (num199 < 200)
								{
									num198 += (float)genRand.Next(10, 20) * 0.001f;
								}
								else if (num199 < 230)
								{
									num198 += (float)genRand.Next(10, 20) * 0.01f;
								}
								else if (num199 < 235)
								{
									num198 += (float)genRand.Next(10, 20) * 0.05f;
								}
								else if (num199 < 240)
								{
									num198 += (float)genRand.Next(10, 20) * 0.1f;
								}
								else if (num199 < 245)
								{
									num198 += (float)genRand.Next(10, 20) * 0.05f;
								}
								else if (num199 < 255)
								{
									num198 += (float)genRand.Next(10, 20) * 0.01f;
								}
								if (num199 == 235)
								{
									num188 = num201;
								}
								int num202 = genRand.Next(15, 20);
								for (int num203 = 0; (float)num203 < (float)num200 + num198 + (float)num202; num203++)
								{
									if ((float)num203 < (float)num200 + num198 * 0.75f - 3f && num203 < Main.worldSurface - 2)
									{
										Main.tile[num201, num203].active = 0;
										if (num203 > num200)
										{
											Main.tile[num201, num203].liquid = byte.MaxValue;
										}
										else if (num203 == num200)
										{
											Main.tile[num201, num203].liquid = 127;
										}
									}
									else if (num203 > num200)
									{
										Main.tile[num201, num203].type = 53;
										Main.tile[num201, num203].active = 1;
									}
									Main.tile[num201, num203].wall = 0;
								}
							}
						}
					}
					for (; Main.tile[num187, num185].active == 0; num185++)
					{
					}
					num185++;
					for (; Main.tile[num188, num186].active == 0; num186++)
					{
					}
					num186++;
					UI.main.NextProgressStep(Lang.gen[23]);
					for (int num204 = 63; num204 <= 68; num204++)
					{
						float num205 = 0f;
						switch (num204)
						{
						case 67:
							num205 = (float)Main.maxTilesX * 0.5f;
							break;
						case 66:
							num205 = (float)Main.maxTilesX * 0.45f;
							break;
						case 63:
							num205 = (float)Main.maxTilesX * 0.3f;
							break;
						case 65:
							num205 = (float)Main.maxTilesX * 0.25f;
							break;
						case 64:
							num205 = (float)Main.maxTilesX * 0.1f;
							break;
						case 68:
							num205 = (float)Main.maxTilesX * 0.05f;
							break;
						}
						num205 *= 0.2f;
						for (int num206 = 0; (float)num206 < num205; num206++)
						{
							int num207 = genRand.Next(Main.maxTilesX);
							int num208 = genRand.Next(Main.worldSurface, Main.maxTilesY);
							while (Main.tile[num207, num208].type != 1)
							{
								num207 = genRand.Next(Main.maxTilesX);
								num208 = genRand.Next(Main.worldSurface, Main.maxTilesY);
							}
							TileRunner(num207, num208, genRand.Next(2, 6), genRand.Next(3, 7), num204);
						}
					}
					for (int num209 = 0; num209 < 2; num209++)
					{
						int num210 = 1;
						int num211 = 5;
						int num212 = Main.maxTilesX - 5;
						if (num209 == 1)
						{
							num210 = -1;
							num211 = Main.maxTilesX - 5;
							num212 = 5;
						}
						for (int num213 = num211; num213 != num212; num213 += num210)
						{
							for (int num214 = 10; num214 < Main.maxTilesY - 10; num214++)
							{
								if (Main.tile[num213, num214].active != 0 && Main.tile[num213, num214].type == 53 && Main.tile[num213, num214 + 1].active != 0 && Main.tile[num213, num214 + 1].type == 53)
								{
									int num215 = num213 + num210;
									int num216 = num214 + 1;
									if (Main.tile[num215, num214].active == 0 && Main.tile[num215, num214 + 1].active == 0)
									{
										for (; Main.tile[num215, num216].active == 0; num216++)
										{
										}
										num216--;
										Main.tile[num213, num214].active = 0;
										Main.tile[num215, num216].active = 1;
										Main.tile[num215, num216].type = 53;
									}
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[24]);
					for (int num217 = 0; num217 < Main.maxTilesX; num217++)
					{
						UI.main.progress = (float)num217 / (float)Main.maxTilesX;
						for (int num218 = Main.maxTilesY - 5; num218 > 0; num218--)
						{
							if (Main.tile[num217, num218].active != 0)
							{
								if (Main.tile[num217, num218].type == 53)
								{
									for (int num219 = num218; Main.tile[num217, num219 + 1].active == 0 && num219 < Main.maxTilesY - 5; num219++)
									{
										Main.tile[num217, num219 + 1].active = 1;
										Main.tile[num217, num219 + 1].type = 53;
									}
								}
								else if (Main.tile[num217, num218].type == 123)
								{
									for (int num220 = num218; Main.tile[num217, num220 + 1].active == 0 && num220 < Main.maxTilesY - 5; num220++)
									{
										Main.tile[num217, num220 + 1].active = 1;
										Main.tile[num217, num220 + 1].type = 123;
										Main.tile[num217, num220].active = 0;
									}
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[25]);
					for (int num221 = 3; num221 < Main.maxTilesX - 3; num221++)
					{
						UI.main.progress = (float)num221 / (float)(Main.maxTilesX - 4);
						bool flag9 = true;
						for (int num222 = 0; num222 < Main.worldSurface; num222++)
						{
							if (flag9)
							{
								if (Main.tile[num221, num222].wall == 2)
								{
									Main.tile[num221, num222].wall = 0;
								}
								if (Main.tile[num221, num222].type != 53)
								{
									if (Main.tile[num221 - 1, num222].wall == 2)
									{
										Main.tile[num221 - 1, num222].wall = 0;
									}
									if (Main.tile[num221 - 2, num222].wall == 2 && genRand.Next(2) == 0)
									{
										Main.tile[num221 - 2, num222].wall = 0;
									}
									if (Main.tile[num221 - 3, num222].wall == 2 && genRand.Next(2) == 0)
									{
										Main.tile[num221 - 3, num222].wall = 0;
									}
									if (Main.tile[num221 + 1, num222].wall == 2)
									{
										Main.tile[num221 + 1, num222].wall = 0;
									}
									if (Main.tile[num221 + 2, num222].wall == 2 && genRand.Next(2) == 0)
									{
										Main.tile[num221 + 2, num222].wall = 0;
									}
									if (Main.tile[num221 + 3, num222].wall == 2 && genRand.Next(2) == 0)
									{
										Main.tile[num221 + 3, num222].wall = 0;
									}
									if (Main.tile[num221, num222].active != 0)
									{
										flag9 = false;
									}
								}
							}
							else if (Main.tile[num221, num222].wall == 0 && Main.tile[num221, num222 + 1].wall == 0 && Main.tile[num221, num222 + 2].wall == 0 && Main.tile[num221, num222 + 3].wall == 0 && Main.tile[num221, num222 + 4].wall == 0 && Main.tile[num221 - 1, num222].wall == 0 && Main.tile[num221 + 1, num222].wall == 0 && Main.tile[num221 - 2, num222].wall == 0 && Main.tile[num221 + 2, num222].wall == 0 && Main.tile[num221, num222].active == 0 && Main.tile[num221, num222 + 1].active == 0 && Main.tile[num221, num222 + 2].active == 0 && Main.tile[num221, num222 + 3].active == 0)
							{
								flag9 = true;
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[26]);
					int y3 = (int)num6 + 20;
					num55 = Main.maxTilesX * Main.maxTilesY / 50000;
					for (int num223 = 0; num223 < num55; num223++)
					{
						UI.main.progress = (float)num223 / (float)num55;
						for (int num224 = 0; num224 < 4096; num224++)
						{
							int x2 = genRand.Next(5, Main.maxTilesX - 5);
							if (Place3x2(x2, y3, 26))
							{
								break;
							}
						}
					}
					num55 = (int)num5;
					for (int num225 = 0; num225 < Main.maxTilesX; num225++)
					{
						int num226 = num55;
						Tile* ptr5 = ptr + (num225 * 1440 + num226);
						do
						{
							if (ptr5->active != 0)
							{
								if (ptr5->type == 60)
								{
									ptr5[-1].liquid = byte.MaxValue;
									ptr5[-2].liquid = byte.MaxValue;
								}
								break;
							}
							ptr5++;
						}
						while (++num226 < Main.worldSurface - 1);
					}
					for (int num227 = 400; num227 < Main.maxTilesX - 400; num227++)
					{
						int num228 = num55;
						Tile* ptr6 = ptr + (num227 * 1440 + num228);
						do
						{
							if (ptr6->active != 0)
							{
								if (ptr6->type == 53)
								{
									Tile* ptr7 = ptr6;
									while (num228 > num55)
									{
										num228--;
										ptr7--;
										if (ptr7->liquid <= 0)
										{
											break;
										}
										ptr7->liquid = 0;
									}
								}
								break;
							}
							ptr6++;
						}
						while (++num228 < Main.worldSurface - 1);
					}
					Liquid.QuickWater(0.33333333333333331);
					WaterCheck();
					int num229 = 0;
					Liquid.QuickSettleOn();
					do
					{
						int num230 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
						num229++;
						float num231 = 0f;
						while (Liquid.numLiquid > 0)
						{
							float num232 = (float)(num230 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float)num230;
							if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num230)
							{
								num230 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
							}
							if (num232 > num231)
							{
								num231 = num232;
							}
							else
							{
								num232 = num231;
							}
							if (num229 == 1)
							{
								UI.main.progress = num232 * 0.333333343f + 0.3334f;
							}
							int num233 = 10;
							if (num229 > num233)
							{
								num233 = num229;
							}
							Liquid.UpdateLiquid();
						}
						WaterCheck();
					}
					while (num229 < 10);
					Liquid.QuickSettleOff();
					UI.main.NextProgressStep(Lang.gen[28]);
					num55 = Main.maxTilesX * Main.maxTilesY / 50000;
					for (int num234 = 0; num234 < num55; num234++)
					{
						UI.main.progress = (float)num234 / (float)num55;
						int num235 = 0;
						while (!AddLifeCrystal(genRand.Next(1, Main.maxTilesX), genRand.Next((int)(num6 + 20f), Main.maxTilesY)) && ++num235 < 10000)
						{
						}
					}
					UI.main.NextProgressStep(Lang.gen[29]);
					float num236 = (float)Main.maxTilesX * 0.000238095236f;
					int num237 = 0;
					num55 = (int)(num236 * 82f);
					for (int num238 = 0; num238 < num55; num238++)
					{
						if (num237 > 41)
						{
							num237 = 0;
						}
						UI.main.progress = (float)num238 / (float)num55;
						int num239 = 0;
						do
						{
							int num240 = genRand.Next(20, Main.maxTilesX - 20);
							int num241;
							for (num241 = genRand.Next((int)(num6 + 20f), Main.maxTilesY - 300); Main.tile[num240, num241].active == 0; num241++)
							{
							}
							num241--;
							if (PlaceTile(num240, num241, 105, mute: true, forced: true, -1, num237))
							{
								num237++;
								break;
							}
						}
						while (++num239 < 10000);
					}
					UI.main.NextProgressStep(Lang.gen[30]);
					num55 = Main.maxTilesX * Main.maxTilesY / 62500;
					for (int num242 = 0; num242 < num55; num242++)
					{
						UI.main.progress = (float)num242 / (float)num55;
						int num243 = 0;
						while (true)
						{
							int num244 = genRand.Next(1, Main.maxTilesX);
							int num245 = (num242 <= 3) ? genRand.Next(Main.maxTilesY - 200, Main.maxTilesY - 50) : genRand.Next((int)(num6 + 20f), Main.maxTilesY - 230);
							int wall = Main.tile[num244, num245].wall;
							if (wall < 7 || wall > 9)
							{
								if (AddBuriedChest(num244, num245))
								{
									if (genRand.Next(2) == 0)
									{
										int num246;
										for (num246 = num245; Main.tile[num244, num246].type != 21 && num246 < Main.maxTilesY - 300; num246++)
										{
										}
										if (num245 < Main.maxTilesY - 300)
										{
											MineHouse(num244, num246);
										}
									}
									break;
								}
								if (++num243 >= 5000)
								{
									break;
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[31]);
					num55 = Main.maxTilesX / 200;
					for (int num247 = 0; num247 < num55; num247++)
					{
						UI.main.progress = (float)num247 / (float)num55;
						int num248 = 0;
						int num249;
						int num250;
						do
						{
							num249 = genRand.Next(300, Main.maxTilesX - 300);
							num250 = genRand.Next((int)num5, Main.worldSurface);
						}
						while ((Main.tile[num249, num250].wall != 2 || Main.tile[num249, num250].active != 0 || !AddBuriedChest(num249, num250, 0, notNearOtherChests: true)) && ++num248 < 2000);
					}
					UI.main.NextProgressStep(Lang.gen[32]);
					int num251 = 0;
					for (int num252 = 0; num252 < numJChests; num252++)
					{
						UI.main.progress = (float)num252 / (float)numJChests;
						int contain = 211;
						switch (++num251)
						{
						case 2:
							contain = 212;
							break;
						case 3:
							contain = 213;
							break;
						default:
							if (Main.rand.Next(2) == 0)
							{
								num251 = ((Main.rand.Next(6) != 0) ? 622 : 624);
							}
							break;
						case 1:
							break;
						}
						if (!AddBuriedChest(JChest[num252].X + genRand.Next(2), JChest[num252].Y, contain))
						{
							KillTile(JChest[num252].X, JChest[num252].Y);
							KillTile(JChest[num252].X, JChest[num252].Y + 1);
							KillTile(JChest[num252].X + 1, JChest[num252].Y);
							KillTile(JChest[num252].X + 1, JChest[num252].Y + 1);
							AddBuriedChest(JChest[num252].X, JChest[num252].Y, contain);
						}
					}
					UI.main.NextProgressStep(Lang.gen[33]);
					int num253 = 0;
					num55 = (int)(9f * num236);
					for (int num254 = 0; num254 < num55; num254++)
					{
						UI.main.progress = (float)num254 / (float)num55;
						int contain2 = 187;
						if (++num253 == 1)
						{
							contain2 = 186;
						}
						else if (num253 == 2)
						{
							contain2 = 277;
						}
						else
						{
							num253 = 0;
						}
						bool flag10 = false;
						while (!flag10)
						{
							int num255 = genRand.Next(1, Main.maxTilesX);
							int num256 = genRand.Next(1, Main.maxTilesY - 200);
							while (Main.tile[num255, num256].liquid < 200 || Main.tile[num255, num256].lava != 0)
							{
								num255 = genRand.Next(1, Main.maxTilesX);
								num256 = genRand.Next(1, Main.maxTilesY - 200);
							}
							flag10 = AddBuriedChest(num255, num256, contain2);
						}
					}
					for (int num257 = 0; num257 < numIslandHouses; num257++)
					{
						IslandHouse(fih[num257].X, fih[num257].Y);
					}
					UI.main.NextProgressStep(Lang.gen[34]);
					num55 = (int)((float)Main.maxTilesX * 0.05f);
					for (int num258 = 0; num258 < num55; num258++)
					{
						UI.main.progress = (float)num258 / (float)num55;
						for (int num259 = 0; num259 < 1000; num259++)
						{
							int num260 = Main.rand.Next(200, Main.maxTilesX - 200);
							int num261 = Main.rand.Next(Main.worldSurface, Main.maxTilesY - 300);
							if (Main.tile[num260, num261].wall == 0 && placeTrap(num260, num261))
							{
								break;
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[35]);
					num55 = (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0008);
					for (int num262 = 0; num262 < num55; num262++)
					{
						float num263 = (float)num262 / (float)num55;
						UI.main.progress = num263;
						bool flag11 = false;
						int num264 = 0;
						while (!flag11)
						{
							int num265 = genRand.Next((int)num6, Main.maxTilesY - 10);
							if (num263 > 0.93f)
							{
								num265 = Main.maxTilesY - 150;
							}
							else if (num263 > 0.75f)
							{
								num265 = (int)num5;
							}
							int num266 = genRand.Next(1, Main.maxTilesX - 1);
							bool flag12 = false;
							for (int num267 = num265; num267 < Main.maxTilesY - 1; num267++)
							{
								if (!flag12)
								{
									if (Main.tile[num266, num267].active != 0 && Main.tileSolid[Main.tile[num266, num267].type] && Main.tile[num266, num267 - 1].lava == 0)
									{
										flag12 = true;
									}
								}
								else
								{
									if (PlacePot(num266, num267))
									{
										flag11 = true;
										break;
									}
									num264++;
									if (num264 >= 10000)
									{
										flag11 = true;
										break;
									}
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[36]);
					num55 = Main.maxTilesX / 200;
					for (int num268 = 0; num268 < num55; num268++)
					{
						UI.main.progress = (float)num268 / (float)num55;
						int num269 = 0;
						while (true)
						{
							int num270 = genRand.Next(5, Main.maxTilesX - 5);
							int num271 = Main.maxTilesY - 250;
							try
							{
								do
								{
									if (Main.tile[num270, num271].active != 0 || Main.tile[num270, num271].wall == 13 || Main.tile[num270, num271].wall == 14)
									{
										num271--;
										if (!PlaceTile(num270, num271, 77) && ++num269 < 10000)
										{
											break;
										}
										goto end_IL_6057;
									}
								}
								while (++num271 != Main.maxTilesY);
							}
							catch
							{
							}
							continue;
							end_IL_6057:
							break;
						}
					}
					UI.main.NextProgressStep(Lang.gen[37]);
					for (int num272 = 0; num272 < Main.maxTilesX; num272++)
					{
						num54 = num272;
						bool flag13 = true;
						for (int num273 = 0; num273 < Main.worldSurface - 1; num273++)
						{
							if (Main.tile[num54, num273].active != 0)
							{
								if (flag13 && Main.tile[num54, num273].type == 0)
								{
									try
									{
										grassSpread = 0;
										SpreadGrass(num54, num273);
									}
									catch
									{
										grassSpread = 0;
										SpreadGrass(num54, num273, 0, 2, repeat: false);
									}
								}
								if ((float)num273 > num6)
								{
									break;
								}
								flag13 = false;
							}
							else if (Main.tile[num54, num273].wall == 0)
							{
								flag13 = true;
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[38]);
					for (int num274 = 5; num274 < Main.maxTilesX - 5; num274++)
					{
						if (genRand.Next(8) == 0)
						{
							Tile* ptr8 = ptr + (num274 * 1440 + 5);
							int num275 = 5;
							do
							{
								if (ptr8->type == 53 && ptr8->active != 0)
								{
									ptr8--;
									if (ptr8->active == 0 && ptr8->wall == 0)
									{
										if (num274 < 250 || num274 > Main.maxTilesX - 250)
										{
											ptr8--;
											if (ptr8->liquid == byte.MaxValue)
											{
												ptr8--;
												if (ptr8->liquid == byte.MaxValue)
												{
													ptr8--;
													if (ptr8->liquid == byte.MaxValue)
													{
														PlaceTile(num274, num275 - 1, 81, mute: true);
													}
													ptr8++;
												}
												ptr8++;
											}
											ptr8++;
										}
										else if (num274 > 400 && num274 < Main.maxTilesX - 400)
										{
											PlantCactus(num274, num275);
										}
									}
									ptr8++;
								}
								ptr8++;
							}
							while (++num275 < Main.worldSurface - 1);
						}
					}
					int num276 = 5;
					while (true)
					{
						int num277 = (Main.maxTilesX >> 1) + genRand.Next(-num276, num276 + 1);
						for (int num278 = 5; num278 <= Main.worldSurface; num278++)
						{
							if (Main.tile[num277, num278].active != 0)
							{
								Main.spawnTileX = (short)num277;
								Main.spawnTileY = (short)num278;
								break;
							}
						}
						if (Main.tile[Main.spawnTileX, Main.spawnTileY - 1].liquid == 0)
						{
							break;
						}
						num276++;
					}
					int num279 = NPC.NewNPC(Main.spawnTileX * 16, Main.spawnTileY * 16, 22);
					Main.npc[num279].homeTileX = Main.spawnTileX;
					Main.npc[num279].homeTileY = Main.spawnTileY;
					Main.npc[num279].direction = 1;
					Main.npc[num279].homeless = true;
					UI.main.NextProgressStep(Lang.gen[39]);
					for (int num280 = 0; (double)num280 < (double)Main.maxTilesX * 0.002; num280++)
					{
						int num281 = 0;
						int num282 = 0;
						int num283 = 0;
						_ = Main.maxTilesX;
						num281 = genRand.Next(Main.maxTilesX);
						num282 = num281 - genRand.Next(10) - 7;
						num283 = num281 + genRand.Next(10) + 7;
						if (num282 < 0)
						{
							num282 = 0;
						}
						if (num283 > Main.maxTilesX - 1)
						{
							num283 = Main.maxTilesX - 1;
						}
						for (int num284 = num282; num284 < num283; num284++)
						{
							for (int num285 = 5; num285 < Main.worldSurface - 1; num285++)
							{
								if (Main.tile[num284, num285].type == 2 && Main.tile[num284, num285].active != 0 && Main.tile[num284, num285 - 1].active == 0)
								{
									PlaceTile(num284, num285 - 1, 27, mute: true);
								}
								if (Main.tile[num284, num285].active != 0)
								{
									break;
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[40]);
					num55 = (int)((double)Main.maxTilesX * 0.003) - 1;
					for (int num286 = num55; num286 >= 0; num286--)
					{
						int num287 = genRand.Next(50, Main.maxTilesX - 50);
						int num288 = genRand.Next(25, 50);
						for (int num289 = num287 - num288; num289 < num287 + num288; num289++)
						{
							for (int num290 = 20; num290 < Main.worldSurface; num290++)
							{
								GrowEpicTree(num289, num290);
							}
						}
					}
					AddTrees();
					UI.main.NextProgressStep(Lang.gen[41]);
					for (int num291 = (int)((double)Main.maxTilesX * 1.7) - 1; num291 >= 0; num291--)
					{
						PlantAlch();
					}
					UI.main.NextProgressStep(Lang.gen[42]);
					AddPlants();
					for (int num292 = 0; num292 < Main.maxTilesX; num292++)
					{
						for (int num293 = 1; num293 < Main.maxTilesY; num293++)
						{
							if (Main.tile[num292, num293].active != 0)
							{
								if (num293 >= Main.worldSurface && Main.tile[num292, num293].type == 70 && Main.tile[num292, num293 - 1].active == 0)
								{
									GrowShroom(num292, num293);
									if (Main.tile[num292, num293 - 1].active == 0)
									{
										PlaceTile(num292, num293 - 1, 71, mute: true);
									}
								}
								if (Main.tile[num292, num293].type == 60 && Main.tile[num292, num293 - 1].active == 0)
								{
									PlaceTile(num292, num293 - 1, 61, mute: true);
								}
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[43]);
					for (int num294 = 0; num294 < Main.maxTilesX; num294++)
					{
						int num295 = 0;
						for (int num296 = 0; num296 < Main.worldSurface; num296++)
						{
							if (num295 > 0 && Main.tile[num294, num296].active == 0)
							{
								Main.tile[num294, num296].active = 1;
								Main.tile[num294, num296].type = 52;
								num295--;
							}
							else
							{
								num295 = 0;
							}
							if (Main.tile[num294, num296].active != 0 && Main.tile[num294, num296].type == 2 && genRand.Next(5) < 3)
							{
								num295 = genRand.Next(1, 10);
							}
						}
						num295 = 0;
						for (int num297 = 0; num297 < Main.maxTilesY; num297++)
						{
							if (num295 > 0 && Main.tile[num294, num297].active == 0)
							{
								Main.tile[num294, num297].active = 1;
								Main.tile[num294, num297].type = 62;
								num295--;
							}
							else
							{
								num295 = 0;
							}
							if (Main.tile[num294, num297].active != 0 && Main.tile[num294, num297].type == 60 && genRand.Next(5) < 3)
							{
								num295 = genRand.Next(1, 10);
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[44]);
					for (int num298 = Main.maxTilesX / 200; num298 > 0; num298--)
					{
						int num299 = genRand.Next(20, Main.maxTilesX - 20);
						int num300 = genRand.Next(5, 15);
						int num301 = genRand.Next(15, 30);
						for (int num302 = 30; num302 < Main.worldSurface - 1; num302++)
						{
							if (Main.tile[num299, num302].active != 0)
							{
								for (int num303 = num299 - num300; num303 < num299 + num300; num303++)
								{
									for (int num304 = num302 - num301; num304 < num302 + num301; num304++)
									{
										if (Main.tile[num303, num304].type == 3 || Main.tile[num303, num304].type == 24)
										{
											Main.tile[num303, num304].frameX = (short)(genRand.Next(6, 8) * 18);
										}
									}
								}
								break;
							}
						}
					}
					UI.main.NextProgressStep(Lang.gen[45]);
					for (int num305 = Main.maxTilesX / 500; num305 > 0; num305--)
					{
						int num306 = genRand.Next(20, Main.maxTilesX - 20);
						int num307 = genRand.Next(4, 10);
						int num308 = genRand.Next(15, 30);
						for (int num309 = 30; num309 < Main.worldSurface - 1; num309++)
						{
							if (Main.tile[num306, num309].active != 0)
							{
								for (int num310 = num306 - num307; num310 < num306 + num307; num310++)
								{
									for (int num311 = num309 - num308; num311 < num309 + num308; num311++)
									{
										if (Main.tile[num310, num311].type == 3 || Main.tile[num310, num311].type == 24)
										{
											Main.tile[num310, num311].frameX = 144;
										}
									}
								}
								break;
							}
						}
					}
				}
			}
			finally
			{
			}
			gen = false;
		}

		public static void GrowEpicTree(int i, int y)
		{
			int j;
			for (j = y; Main.tile[i, j].type == 20; j++)
			{
			}
			if (Main.tile[i, j].active == 0 || Main.tile[i, j].type != 2 || Main.tile[i, j - 1].wall != 0 || Main.tile[i, j - 1].liquid != 0 || ((Main.tile[i - 1, j].active == 0 || (Main.tile[i - 1, j].type != 2 && Main.tile[i - 1, j].type != 23 && Main.tile[i - 1, j].type != 60 && Main.tile[i - 1, j].type != 109)) && (Main.tile[i + 1, j].active == 0 || (Main.tile[i + 1, j].type != 2 && Main.tile[i + 1, j].type != 23 && Main.tile[i + 1, j].type != 60 && Main.tile[i + 1, j].type != 109))))
			{
				return;
			}
			int num = 1;
			if (!EmptyTileCheckTree(i - num, i + num, j - 55, j - 1))
			{
				return;
			}
			int num2 = genRand.Next(10);
			int num3 = genRand.Next(20, 30);
			int num4;
			for (int k = j - num3; k < j; k++)
			{
				Main.tile[i, k].frameNumber = (byte)genRand.Next(3);
				Main.tile[i, k].active = 1;
				Main.tile[i, k].type = 5;
				num4 = genRand.Next(3);
				if (k == j - 1 || k == j - num3)
				{
					num2 = 0;
				}
				switch (num2)
				{
				case 1:
					Main.tile[i, k].frameX = 0;
					Main.tile[i, k].frameY = (short)(66 + num4 * 22);
					break;
				case 2:
					Main.tile[i, k].frameX = 22;
					Main.tile[i, k].frameY = (short)(num4 * 22);
					break;
				case 3:
					Main.tile[i, k].frameX = 44;
					Main.tile[i, k].frameY = (short)(66 + num4 * 22);
					break;
				case 4:
					Main.tile[i, k].frameX = 22;
					Main.tile[i, k].frameY = (short)(66 + num4 * 22);
					break;
				case 5:
					Main.tile[i, k].frameX = 88;
					Main.tile[i, k].frameY = (short)(num4 * 22);
					break;
				case 6:
					Main.tile[i, k].frameX = 66;
					Main.tile[i, k].frameY = (short)(66 + num4 * 22);
					break;
				case 7:
					Main.tile[i, k].frameX = 110;
					Main.tile[i, k].frameY = (short)(66 + num4 * 22);
					break;
				default:
					Main.tile[i, k].frameX = 0;
					Main.tile[i, k].frameY = (short)(num4 * 22);
					break;
				}
				bool flag = num2 == 5 || num2 == 7;
				bool flag2 = num2 == 6 || num2 == 7;
				if (flag)
				{
					Main.tile[i - 1, k].active = 1;
					Main.tile[i - 1, k].type = 5;
					num4 = genRand.Next(3);
					if (genRand.Next(3) < 2)
					{
						Main.tile[i - 1, k].frameX = 44;
						Main.tile[i - 1, k].frameY = (short)(198 + num4 * 22);
					}
					else
					{
						Main.tile[i - 1, k].frameX = 66;
						Main.tile[i - 1, k].frameY = (short)(num4 * 22);
					}
				}
				if (flag2)
				{
					Main.tile[i + 1, k].active = 1;
					Main.tile[i + 1, k].type = 5;
					num4 = genRand.Next(3);
					if (genRand.Next(3) < 2)
					{
						Main.tile[i + 1, k].frameX = 66;
						Main.tile[i + 1, k].frameY = (short)(198 + num4 * 22);
					}
					else
					{
						Main.tile[i + 1, k].frameX = 88;
						Main.tile[i + 1, k].frameY = (short)(66 + num4 * 22);
					}
				}
				do
				{
					num2 = genRand.Next(10);
				}
				while (((num2 == 5 || num2 == 7) && flag) || ((num2 == 6 || num2 == 7) && flag2));
			}
			int num5 = genRand.Next(3);
			bool flag3 = false;
			bool flag4 = false;
			if (Main.tile[i - 1, j].active != 0 && (Main.tile[i - 1, j].type == 2 || Main.tile[i - 1, j].type == 23 || Main.tile[i - 1, j].type == 60 || Main.tile[i - 1, j].type == 109))
			{
				flag3 = true;
			}
			if (Main.tile[i + 1, j].active != 0 && (Main.tile[i + 1, j].type == 2 || Main.tile[i + 1, j].type == 23 || Main.tile[i + 1, j].type == 60 || Main.tile[i + 1, j].type == 109))
			{
				flag4 = true;
			}
			if (!flag3)
			{
				if (num5 == 0)
				{
					num5 = 2;
				}
				if (num5 == 1)
				{
					num5 = 3;
				}
			}
			if (!flag4)
			{
				if (num5 == 0)
				{
					num5 = 1;
				}
				if (num5 == 2)
				{
					num5 = 3;
				}
			}
			if (flag4 && !flag3)
			{
				num5 = 1;
			}
			if (flag3 && !flag4)
			{
				num5 = 2;
			}
			if (num5 == 0 || num5 == 1)
			{
				Main.tile[i + 1, j - 1].active = 1;
				Main.tile[i + 1, j - 1].type = 5;
				num4 = genRand.Next(3);
				if (num4 == 0)
				{
					Main.tile[i + 1, j - 1].frameX = 22;
					Main.tile[i + 1, j - 1].frameY = 132;
				}
				if (num4 == 1)
				{
					Main.tile[i + 1, j - 1].frameX = 22;
					Main.tile[i + 1, j - 1].frameY = 154;
				}
				if (num4 == 2)
				{
					Main.tile[i + 1, j - 1].frameX = 22;
					Main.tile[i + 1, j - 1].frameY = 176;
				}
			}
			if (num5 == 0 || num5 == 2)
			{
				Main.tile[i - 1, j - 1].active = 1;
				Main.tile[i - 1, j - 1].type = 5;
				num4 = genRand.Next(3);
				if (num4 == 0)
				{
					Main.tile[i - 1, j - 1].frameX = 44;
					Main.tile[i - 1, j - 1].frameY = 132;
				}
				if (num4 == 1)
				{
					Main.tile[i - 1, j - 1].frameX = 44;
					Main.tile[i - 1, j - 1].frameY = 154;
				}
				if (num4 == 2)
				{
					Main.tile[i - 1, j - 1].frameX = 44;
					Main.tile[i - 1, j - 1].frameY = 176;
				}
			}
			num4 = genRand.Next(3);
			switch (num5)
			{
			case 0:
				if (num4 == 0)
				{
					Main.tile[i, j - 1].frameX = 88;
					Main.tile[i, j - 1].frameY = 132;
				}
				if (num4 == 1)
				{
					Main.tile[i, j - 1].frameX = 88;
					Main.tile[i, j - 1].frameY = 154;
				}
				if (num4 == 2)
				{
					Main.tile[i, j - 1].frameX = 88;
					Main.tile[i, j - 1].frameY = 176;
				}
				break;
			case 1:
				if (num4 == 0)
				{
					Main.tile[i, j - 1].frameX = 0;
					Main.tile[i, j - 1].frameY = 132;
				}
				if (num4 == 1)
				{
					Main.tile[i, j - 1].frameX = 0;
					Main.tile[i, j - 1].frameY = 154;
				}
				if (num4 == 2)
				{
					Main.tile[i, j - 1].frameX = 0;
					Main.tile[i, j - 1].frameY = 176;
				}
				break;
			case 2:
				if (num4 == 0)
				{
					Main.tile[i, j - 1].frameX = 66;
					Main.tile[i, j - 1].frameY = 132;
				}
				if (num4 == 1)
				{
					Main.tile[i, j - 1].frameX = 66;
					Main.tile[i, j - 1].frameY = 154;
				}
				if (num4 == 2)
				{
					Main.tile[i, j - 1].frameX = 66;
					Main.tile[i, j - 1].frameY = 176;
				}
				break;
			}
			if (genRand.Next(3) < 2)
			{
				num4 = genRand.Next(3);
				if (num4 == 0)
				{
					Main.tile[i, j - num3].frameX = 22;
					Main.tile[i, j - num3].frameY = 198;
				}
				if (num4 == 1)
				{
					Main.tile[i, j - num3].frameX = 22;
					Main.tile[i, j - num3].frameY = 220;
				}
				if (num4 == 2)
				{
					Main.tile[i, j - num3].frameX = 22;
					Main.tile[i, j - num3].frameY = 242;
				}
			}
			else
			{
				num4 = genRand.Next(3);
				if (num4 == 0)
				{
					Main.tile[i, j - num3].frameX = 0;
					Main.tile[i, j - num3].frameY = 198;
				}
				if (num4 == 1)
				{
					Main.tile[i, j - num3].frameX = 0;
					Main.tile[i, j - num3].frameY = 220;
				}
				if (num4 == 2)
				{
					Main.tile[i, j - num3].frameX = 0;
					Main.tile[i, j - num3].frameY = 242;
				}
			}
			RangeFrame(i - 2, j - num3 - 1, i + 2, j + 1);
			if (Main.netMode == 2)
			{
				NetMessage.SendTileSquare(i, (int)((double)j - (double)num3 * 0.5), num3 + 1);
			}
		}

		public unsafe static void GrowTree(int i, int y)
		{
			int j;
			for (j = y; Main.tile[i, j].type == 20; j++)
			{
			}
			if (((Main.tile[i - 1, j - 1].liquid != 0 || Main.tile[i - 1, j - 1].liquid != 0 || Main.tile[i + 1, j - 1].liquid != 0) && Main.tile[i, j].type != 60) || Main.tile[i, j].active == 0 || (Main.tile[i, j].type != 2 && Main.tile[i, j].type != 23 && Main.tile[i, j].type != 60 && Main.tile[i, j].type != 109 && Main.tile[i, j].type != 147) || Main.tile[i, j - 1].wall != 0 || ((Main.tile[i - 1, j].active == 0 || (Main.tile[i - 1, j].type != 2 && Main.tile[i - 1, j].type != 23 && Main.tile[i - 1, j].type != 60 && Main.tile[i - 1, j].type != 109 && Main.tile[i - 1, j].type != 147)) && (Main.tile[i + 1, j].active == 0 || (Main.tile[i + 1, j].type != 2 && Main.tile[i + 1, j].type != 23 && Main.tile[i + 1, j].type != 60 && Main.tile[i + 1, j].type != 109 && Main.tile[i + 1, j].type != 147))))
			{
				return;
			}
			int num = 1;
			int num2 = 16;
			if (Main.tile[i, j].type == 60)
			{
				num2 += 5;
			}
			if (!EmptyTileCheckTree(i - num, i + num, j - num2, j - 1))
			{
				return;
			}
			int num3 = genRand.Next(10);
			int num4 = genRand.Next(5, num2 + 1);
			int num5;
			for (int k = j - num4; k < j; k++)
			{
				Main.tile[i, k].frameNumber = (byte)genRand.Next(3);
				Main.tile[i, k].active = 1;
				Main.tile[i, k].type = 5;
				num5 = genRand.Next(3);
				if (k == j - 1 || k == j - num4)
				{
					num3 = 0;
				}
				switch (num3)
				{
				case 1:
					Main.tile[i, k].frameX = 0;
					Main.tile[i, k].frameY = (short)(66 + num5 * 22);
					break;
				case 2:
					Main.tile[i, k].frameX = 22;
					Main.tile[i, k].frameY = (short)(num5 * 22);
					break;
				case 3:
					Main.tile[i, k].frameX = 44;
					Main.tile[i, k].frameY = (short)(66 + num5 * 22);
					break;
				case 4:
					Main.tile[i, k].frameX = 22;
					Main.tile[i, k].frameY = (short)(66 + num5 * 22);
					break;
				case 5:
					Main.tile[i, k].frameX = 88;
					Main.tile[i, k].frameY = (short)(num5 * 22);
					break;
				case 6:
					Main.tile[i, k].frameX = 66;
					Main.tile[i, k].frameY = (short)(66 + num5 * 22);
					break;
				case 7:
					Main.tile[i, k].frameX = 110;
					Main.tile[i, k].frameY = (short)(66 + num5 * 22);
					break;
				default:
					Main.tile[i, k].frameX = 0;
					Main.tile[i, k].frameY = (short)(num5 * 22);
					break;
				}
				bool flag = num3 == 5 || num3 == 7;
				bool flag2 = num3 == 6 || num3 == 7;
				if (flag)
				{
					Main.tile[i - 1, k].active = 1;
					Main.tile[i - 1, k].type = 5;
					num5 = genRand.Next(3);
					if (genRand.Next(3) < 2)
					{
						Main.tile[i - 1, k].frameX = 44;
						Main.tile[i - 1, k].frameY = (short)(198 + num5 * 22);
					}
					else
					{
						Main.tile[i - 1, k].frameX = 66;
						Main.tile[i - 1, k].frameY = (short)(num5 * 22);
					}
				}
				if (flag2)
				{
					Main.tile[i + 1, k].active = 1;
					Main.tile[i + 1, k].type = 5;
					num5 = genRand.Next(3);
					if (genRand.Next(3) < 2)
					{
						Main.tile[i + 1, k].frameX = 66;
						Main.tile[i + 1, k].frameY = (short)(198 + num5 * 22);
					}
					else
					{
						Main.tile[i + 1, k].frameX = 88;
						Main.tile[i + 1, k].frameY = (short)(66 + num5 * 22);
					}
				}
				do
				{
					num3 = genRand.Next(10);
				}
				while (((num3 == 5 || num3 == 7) && flag) || ((num3 == 6 || num3 == 7) && flag2));
			}
			int num6 = genRand.Next(3);
			bool flag3 = false;
			bool flag4 = false;
			fixed (Tile* ptr = &Main.tile[i - 1, j])
			{
				if (ptr->active != 0)
				{
					switch (ptr->type)
					{
					case 2:
					case 23:
					case 60:
					case 109:
					case 147:
						flag3 = true;
						break;
					}
				}
			}
			fixed (Tile* ptr2 = &Main.tile[i + 1, j])
			{
				if (ptr2->active != 0)
				{
					switch (ptr2->type)
					{
					case 2:
					case 23:
					case 60:
					case 109:
					case 147:
						flag4 = true;
						break;
					}
				}
			}
			if (!flag3)
			{
				if (num6 == 0)
				{
					num6 = 2;
				}
				if (num6 == 1)
				{
					num6 = 3;
				}
			}
			if (!flag4)
			{
				if (num6 == 0)
				{
					num6 = 1;
				}
				if (num6 == 2)
				{
					num6 = 3;
				}
			}
			if (flag4 && !flag3)
			{
				num6 = 1;
			}
			if (flag3 && !flag4)
			{
				num6 = 2;
			}
			if (num6 == 0 || num6 == 1)
			{
				Main.tile[i + 1, j - 1].active = 1;
				Main.tile[i + 1, j - 1].type = 5;
				num5 = genRand.Next(3);
				if (num5 == 0)
				{
					Main.tile[i + 1, j - 1].frameX = 22;
					Main.tile[i + 1, j - 1].frameY = 132;
				}
				if (num5 == 1)
				{
					Main.tile[i + 1, j - 1].frameX = 22;
					Main.tile[i + 1, j - 1].frameY = 154;
				}
				if (num5 == 2)
				{
					Main.tile[i + 1, j - 1].frameX = 22;
					Main.tile[i + 1, j - 1].frameY = 176;
				}
			}
			if (num6 == 0 || num6 == 2)
			{
				Main.tile[i - 1, j - 1].active = 1;
				Main.tile[i - 1, j - 1].type = 5;
				num5 = genRand.Next(3);
				if (num5 == 0)
				{
					Main.tile[i - 1, j - 1].frameX = 44;
					Main.tile[i - 1, j - 1].frameY = 132;
				}
				if (num5 == 1)
				{
					Main.tile[i - 1, j - 1].frameX = 44;
					Main.tile[i - 1, j - 1].frameY = 154;
				}
				if (num5 == 2)
				{
					Main.tile[i - 1, j - 1].frameX = 44;
					Main.tile[i - 1, j - 1].frameY = 176;
				}
			}
			num5 = genRand.Next(3);
			switch (num6)
			{
			case 0:
				if (num5 == 0)
				{
					Main.tile[i, j - 1].frameX = 88;
					Main.tile[i, j - 1].frameY = 132;
				}
				if (num5 == 1)
				{
					Main.tile[i, j - 1].frameX = 88;
					Main.tile[i, j - 1].frameY = 154;
				}
				if (num5 == 2)
				{
					Main.tile[i, j - 1].frameX = 88;
					Main.tile[i, j - 1].frameY = 176;
				}
				break;
			case 1:
				if (num5 == 0)
				{
					Main.tile[i, j - 1].frameX = 0;
					Main.tile[i, j - 1].frameY = 132;
				}
				if (num5 == 1)
				{
					Main.tile[i, j - 1].frameX = 0;
					Main.tile[i, j - 1].frameY = 154;
				}
				if (num5 == 2)
				{
					Main.tile[i, j - 1].frameX = 0;
					Main.tile[i, j - 1].frameY = 176;
				}
				break;
			case 2:
				if (num5 == 0)
				{
					Main.tile[i, j - 1].frameX = 66;
					Main.tile[i, j - 1].frameY = 132;
				}
				if (num5 == 1)
				{
					Main.tile[i, j - 1].frameX = 66;
					Main.tile[i, j - 1].frameY = 154;
				}
				if (num5 == 2)
				{
					Main.tile[i, j - 1].frameX = 66;
					Main.tile[i, j - 1].frameY = 176;
				}
				break;
			}
			if (genRand.Next(4) < 3)
			{
				num5 = genRand.Next(3);
				if (num5 == 0)
				{
					Main.tile[i, j - num4].frameX = 22;
					Main.tile[i, j - num4].frameY = 198;
				}
				if (num5 == 1)
				{
					Main.tile[i, j - num4].frameX = 22;
					Main.tile[i, j - num4].frameY = 220;
				}
				if (num5 == 2)
				{
					Main.tile[i, j - num4].frameX = 22;
					Main.tile[i, j - num4].frameY = 242;
				}
			}
			else
			{
				num5 = genRand.Next(3);
				if (num5 == 0)
				{
					Main.tile[i, j - num4].frameX = 0;
					Main.tile[i, j - num4].frameY = 198;
				}
				if (num5 == 1)
				{
					Main.tile[i, j - num4].frameX = 0;
					Main.tile[i, j - num4].frameY = 220;
				}
				if (num5 == 2)
				{
					Main.tile[i, j - num4].frameX = 0;
					Main.tile[i, j - num4].frameY = 242;
				}
			}
			RangeFrame(i - 2, j - num4 - 1, i + 2, j + 1);
			if (Main.netMode == 2)
			{
				NetMessage.SendTileSquare(i, (int)((double)j - (double)num4 * 0.5), num4 + 1);
			}
		}

		public static void GrowShroom(int i, int y)
		{
			if (Main.tile[i - 1, y - 1].lava != 0 || Main.tile[i - 1, y - 1].lava != 0 || Main.tile[i + 1, y - 1].lava != 0 || Main.tile[i, y].active == 0 || Main.tile[i, y].type != 70 || Main.tile[i, y - 1].wall != 0 || Main.tile[i - 1, y].active == 0 || Main.tile[i - 1, y].type != 70 || Main.tile[i + 1, y].active == 0 || Main.tile[i + 1, y].type != 70 || !EmptyTileCheckShroom(i - 2, i + 2, y - 13, y - 1))
			{
				return;
			}
			int num = genRand.Next(4, 11);
			int num2;
			for (int j = y - num; j < y; j++)
			{
				Main.tile[i, j].frameNumber = (byte)genRand.Next(3);
				Main.tile[i, j].active = 1;
				Main.tile[i, j].type = 72;
				num2 = genRand.Next(3);
				if (num2 == 0)
				{
					Main.tile[i, j].frameX = 0;
					Main.tile[i, j].frameY = 0;
				}
				if (num2 == 1)
				{
					Main.tile[i, j].frameX = 0;
					Main.tile[i, j].frameY = 18;
				}
				if (num2 == 2)
				{
					Main.tile[i, j].frameX = 0;
					Main.tile[i, j].frameY = 36;
				}
			}
			num2 = genRand.Next(3);
			if (num2 == 0)
			{
				Main.tile[i, y - num].frameX = 36;
				Main.tile[i, y - num].frameY = 0;
			}
			if (num2 == 1)
			{
				Main.tile[i, y - num].frameX = 36;
				Main.tile[i, y - num].frameY = 18;
			}
			if (num2 == 2)
			{
				Main.tile[i, y - num].frameX = 36;
				Main.tile[i, y - num].frameY = 36;
			}
			RangeFrame(i - 2, y - num - 1, i + 2, y + 1);
			if (Main.netMode == 2)
			{
				NetMessage.SendTileSquare(i, (int)((double)y - (double)num * 0.5), num + 1);
			}
		}

		public static void AddTrees()
		{
			for (int i = 1; i < Main.maxTilesX - 1; i++)
			{
				for (int j = 20; j < Main.worldSurface; j++)
				{
					GrowTree(i, j);
				}
				int num = genRand.Next(12);
				if (num <= 6)
				{
					i++;
					if (num == 0)
					{
						i++;
					}
				}
			}
		}

		public unsafe static bool EmptyTileCheck(int startX, int endX, int startY, int endY)
		{
			if (startX < 0)
			{
				return false;
			}
			if (endX >= Main.maxTilesX)
			{
				return false;
			}
			if (startY < 0)
			{
				return false;
			}
			if (endY >= Main.maxTilesY)
			{
				return false;
			}
			fixed (Tile* ptr = Main.tile)
			{
				do
				{
					int num = startY;
					Tile* ptr2 = ptr + (startX * 1440 + num);
					do
					{
						if (ptr2->active != 0)
						{
							return false;
						}
						ptr2++;
					}
					while (++num <= endY);
				}
				while (++startX <= endX);
			}
			return true;
		}

		public unsafe static bool EmptyTileCheckTree(int startX, int endX, int startY, int endY)
		{
			if (startX < 0)
			{
				return false;
			}
			if (endX >= Main.maxTilesX)
			{
				return false;
			}
			if (startY < 0)
			{
				return false;
			}
			if (endY >= Main.maxTilesY)
			{
				return false;
			}
			fixed (Tile* ptr = Main.tile)
			{
				do
				{
					int num = startY;
					Tile* ptr2 = ptr + (startX * 1440 + num);
					do
					{
						if (ptr2->active != 0)
						{
							int type = ptr2->type;
							if (type != 20 && type != 3 && type != 24 && type != 61 && type != 32 && type != 69 && type != 73 && type != 74 && type != 110 && type != 113)
							{
								return false;
							}
						}
						ptr2++;
					}
					while (++num <= endY);
				}
				while (++startX <= endX);
			}
			return true;
		}

		public unsafe static bool EmptyTileCheckShroom(int startX, int endX, int startY, int endY)
		{
			if (startX < 0)
			{
				return false;
			}
			if (endX >= Main.maxTilesX)
			{
				return false;
			}
			if (startY < 0)
			{
				return false;
			}
			if (endY >= Main.maxTilesY)
			{
				return false;
			}
			fixed (Tile* ptr = Main.tile)
			{
				do
				{
					int num = startY;
					Tile* ptr2 = ptr + (startX * 1440 + num);
					do
					{
						if (ptr2->active != 0 && ptr2->type != 71)
						{
							return false;
						}
						ptr2++;
					}
					while (++num <= endY);
				}
				while (++startX <= endX);
			}
			return true;
		}

		public static void StartHardmodeCallBack()
		{
			Thread.CurrentThread.SetProcessorAffinity(4);
			hardLock = true;
			float num = (float)genRand.Next(300, 400) * 0.001f;
			int num2 = (int)((float)Main.maxTilesX * num);
			int num3 = (int)((float)Main.maxTilesX * (1f - num));
			int num4 = 1;
			if (genRand.Next(2) == 0)
			{
				num4 = num3;
				num3 = num2;
				num2 = num4;
				num4 = -1;
			}
			Vector2i min = default(Vector2i);
			min.X = Main.maxTilesX;
			min.Y = Main.maxTilesY;
			Vector2i maxArea = default(Vector2i);
			GERunner(num2, new Vector2(3 * num4, 5f), good: true, ref min, ref maxArea);
			GERunner(num3, new Vector2(-3 * num4, 5f), good: false, ref min, ref maxArea);
			Netplay.ResetSections(ref min, ref maxArea);
			Main.hardMode = true;
			hardLock = false;
		}

		public static void StartHardmode()
		{
			if (Main.netMode != 1 && !Main.hardMode)
			{
				Thread thread = new Thread(StartHardmodeCallBack);
				thread.IsBackground = true;
				thread.Start();
				NetMessage.SendText(15, 50, 255, 130, -1);
				UI.SetTriggerStateForAll(Trigger.UnlockedHardMode);
			}
		}

		public unsafe static bool PlaceDoor(int i, int j, int type)
		{
			if (j >= 2 && j < Main.maxTilesY - 2)
			{
				fixed (Tile* ptr = &Main.tile[i, j])
				{
					if (ptr[-2].active != 0 && Main.tileSolid[ptr[-2].type] && ptr[2].active != 0 && Main.tileSolid[ptr[2].type])
					{
						ptr[-1].active = 1;
						ptr[-1].type = 10;
						ptr[-1].frameY = 0;
						ptr[-1].frameX = (short)(genRand.Next(3) * 18);
						ptr->active = 1;
						ptr->type = 10;
						ptr->frameY = 18;
						ptr->frameX = (short)(genRand.Next(3) * 18);
						ptr[1].active = 1;
						ptr[1].type = 10;
						ptr[1].frameY = 36;
						ptr[1].frameX = (short)(genRand.Next(3) * 18);
						return true;
					}
				}
			}
			return false;
		}

		public static bool CanCloseDoor(int i, int j)
		{
			int num = i;
			int num2 = j;
			switch (Main.tile[i, j].frameX)
			{
			case 18:
				num--;
				break;
			case 36:
				num++;
				break;
			}
			int frameY = Main.tile[i, j].frameY;
			num2 -= frameY / 18;
			return !Collision.AnyPlayerOrNPC(num, num2, 3);
		}

		public static bool CloseDoor(int i, int j, bool forced = false)
		{
			int num = 0;
			int num2 = i;
			int num3 = j;
			switch (Main.tile[i, j].frameX)
			{
			case 0:
				num = 1;
				break;
			case 18:
				num2--;
				num = 1;
				break;
			case 36:
				num2++;
				num = -1;
				break;
			case 54:
				num = -1;
				break;
			}
			int frameY = Main.tile[i, j].frameY;
			num3 -= frameY / 18;
			if (!forced && Collision.AnyPlayerOrNPC(num2, num3, 3))
			{
				return false;
			}
			int num4 = num2;
			if (num == -1)
			{
				num4--;
			}
			for (int k = num4; k < num4 + 2; k++)
			{
				for (int l = num3; l < num3 + 3; l++)
				{
					if (k == num2)
					{
						Main.tile[k, l].type = 10;
						Main.tile[k, l].frameX = (short)(genRand.Next(3) * 18);
					}
					else
					{
						Main.tile[k, l].active = 0;
					}
				}
			}
			if (Main.netMode != 1)
			{
				for (int m = 0; m < 3; m++)
				{
					if (numNoWire < 999)
					{
						noWire[numNoWire].X = (short)num2;
						noWire[numNoWire].Y = (short)(num3 + m);
						numNoWire++;
					}
				}
			}
			bool flag = tileFrameRecursion;
			tileFrameRecursion = false;
			TileFrame(num2 - 1, num3 - 1);
			TileFrame(num2 - 1, num3);
			TileFrame(num2 - 1, num3 + 1);
			TileFrame(num2 - 1, num3 + 2);
			TileFrame(num2, num3 - 1);
			TileFrame(num2, num3);
			TileFrame(num2, num3 + 1);
			TileFrame(num2, num3 + 2);
			TileFrame(num2 + 1, num3 - 1);
			TileFrame(num2 + 1, num3);
			TileFrame(num2 + 1, num3 + 1);
			TileFrame(num2 + 1, num3 + 2);
			tileFrameRecursion = flag;
			Main.PlaySound(9, i * 16, j * 16);
			return true;
		}

		public unsafe static bool AddLifeCrystal(int i, int j)
		{
			fixed (Tile* ptr = Main.tile)
			{
				Tile* ptr2 = ptr + (i * 1440 + j);
				while (j < Main.maxTilesY)
				{
					if (ptr2->active != 0 && Main.tileSolid[ptr2->type])
					{
						if (ptr2[-2].lava != 0 || ptr2[-1442].lava != 0)
						{
							return false;
						}
						if (!EmptyTileCheck(i - 1, i, j - 2, j - 1))
						{
							return false;
						}
						ptr2[-1442].active = 1;
						ptr2[-1442].type = 12;
						ptr2[-1442].frameX = 0;
						ptr2[-1442].frameY = 0;
						ptr2[-1441].active = 1;
						ptr2[-1441].type = 12;
						ptr2[-1441].frameX = 0;
						ptr2[-1441].frameY = 18;
						ptr2[-2].active = 1;
						ptr2[-2].type = 12;
						ptr2[-2].frameX = 18;
						ptr2[-2].frameY = 0;
						ptr2[-1].active = 1;
						ptr2[-1].type = 12;
						ptr2[-1].frameX = 18;
						ptr2[-1].frameY = 18;
						return true;
					}
					j++;
					ptr2++;
				}
			}
			return false;
		}

		public static void AddShadowOrb(int x, int y)
		{
			if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesY - 10)
			{
				return;
			}
			for (int i = x - 1; i < x + 1; i++)
			{
				for (int j = y - 1; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0 && Main.tile[i, j].type == 31)
					{
						return;
					}
				}
			}
			Main.tile[x - 1, y - 1].active = 1;
			Main.tile[x - 1, y - 1].type = 31;
			Main.tile[x - 1, y - 1].frameX = 0;
			Main.tile[x - 1, y - 1].frameY = 0;
			Main.tile[x, y - 1].active = 1;
			Main.tile[x, y - 1].type = 31;
			Main.tile[x, y - 1].frameX = 18;
			Main.tile[x, y - 1].frameY = 0;
			Main.tile[x - 1, y].active = 1;
			Main.tile[x - 1, y].type = 31;
			Main.tile[x - 1, y].frameX = 0;
			Main.tile[x - 1, y].frameY = 18;
			Main.tile[x, y].active = 1;
			Main.tile[x, y].type = 31;
			Main.tile[x, y].frameX = 18;
			Main.tile[x, y].frameY = 18;
		}

		public static void AddHellHouses()
		{
			int num = (int)((double)Main.maxTilesX * 0.25);
			for (int i = num; i < Main.maxTilesX - num; i++)
			{
				int num2 = Main.maxTilesY - 40;
				while (Main.tile[i, num2].active != 0 || Main.tile[i, num2].liquid > 0)
				{
					num2--;
				}
				if (Main.tile[i, num2 + 1].active != 0)
				{
					int type;
					int wall;
					if (genRand.Next(10) == 0)
					{
						type = 76;
						wall = 13;
					}
					else
					{
						type = 75;
						wall = 14;
					}
					HellHouse(i, num2, type, wall);
					i += genRand.Next(15, 80);
				}
			}
			float num3 = (float)Main.maxTilesX * 0.000238095236f;
			for (int j = 0; (float)j < 200f * num3; j++)
			{
				int num4 = 0;
				bool flag = false;
				while (!flag)
				{
					num4++;
					int num5 = genRand.Next((int)((double)Main.maxTilesX * 0.2), (int)((double)Main.maxTilesX * 0.8));
					int num6 = genRand.Next(Main.maxTilesY - 300, Main.maxTilesY - 20);
					if (Main.tile[num5, num6].active != 0 && (Main.tile[num5, num6].type == 75 || Main.tile[num5, num6].type == 76))
					{
						int num7 = 0;
						if (Main.tile[num5 - 1, num6].wall > 0)
						{
							num7 = -1;
						}
						else if (Main.tile[num5 + 1, num6].wall > 0)
						{
							num7 = 1;
						}
						if (Main.tile[num5 + num7, num6].active == 0 && Main.tile[num5 + num7, num6 + 1].active == 0)
						{
							bool flag2 = false;
							for (int k = num5 - 8; k < num5 + 8; k++)
							{
								for (int l = num6 - 8; l < num6 + 8; l++)
								{
									if (Main.tile[k, l].active != 0 && Main.tile[k, l].type == 4)
									{
										flag2 = true;
										break;
									}
								}
							}
							if (!flag2)
							{
								PlaceTile(num5 + num7, num6, 4, mute: true, forced: true, -1, 7);
								flag = true;
							}
						}
					}
					if (num4 > 1000)
					{
						flag = true;
					}
				}
			}
		}

		public static void HellHouse(int i, int j, int type, int wall)
		{
			int num = genRand.Next(8, 20);
			int num2 = genRand.Next(1, 3);
			int num3 = genRand.Next(4, 13);
			int num4 = j;
			for (int k = 0; k < num2; k++)
			{
				int num5 = genRand.Next(5, 9);
				HellRoom(i, num4, num, num5, type, wall);
				num4 -= num5;
			}
			num4 = j;
			for (int l = 0; l < num3; l++)
			{
				int num6 = genRand.Next(5, 9);
				num4 += num6;
				HellRoom(i, num4, num, num6, type, wall);
			}
			for (int m = i - (num >> 1); m <= i + (num >> 1); m++)
			{
				for (num4 = j; num4 < Main.maxTilesY && ((Main.tile[m, num4].active != 0 && (Main.tile[m, num4].type == 76 || Main.tile[m, num4].type == 75)) || Main.tile[i, num4].wall == 13 || Main.tile[i, num4].wall == 14); num4++)
				{
				}
				int num7 = 6 + genRand.Next(3);
				while (num4 < Main.maxTilesY && Main.tile[m, num4].active == 0)
				{
					num7--;
					Main.tile[m, num4].active = 1;
					Main.tile[m, num4].type = 57;
					num4++;
					if (num7 <= 0)
					{
						break;
					}
				}
			}
			int num8 = 0;
			int num9 = 0;
			for (num4 = j; num4 < Main.maxTilesY && ((Main.tile[i, num4].active != 0 && (Main.tile[i, num4].type == 76 || Main.tile[i, num4].type == 75)) || Main.tile[i, num4].wall == 13 || Main.tile[i, num4].wall == 14); num4++)
			{
			}
			num4--;
			num9 = num4;
			while ((Main.tile[i, num4].active != 0 && (Main.tile[i, num4].type == 76 || Main.tile[i, num4].type == 75)) || Main.tile[i, num4].wall == 13 || Main.tile[i, num4].wall == 14)
			{
				num4--;
				if (Main.tile[i, num4].active == 0 || (Main.tile[i, num4].type != 76 && Main.tile[i, num4].type != 75))
				{
					continue;
				}
				int num10 = genRand.Next(i - (num >> 1) + 1, i + (num >> 1) - 1);
				int num11 = genRand.Next(i - (num >> 1) + 1, i + (num >> 1) - 1);
				if (num10 > num11)
				{
					int num12 = num10;
					num10 = num11;
					num11 = num12;
				}
				if (num10 == num11)
				{
					if (num10 < i)
					{
						num11++;
					}
					else
					{
						num10--;
					}
				}
				for (int n = num10; n <= num11; n++)
				{
					if (Main.tile[n, num4 - 1].wall == 13)
					{
						Main.tile[n, num4].wall = 13;
					}
					if (Main.tile[n, num4 - 1].wall == 14)
					{
						Main.tile[n, num4].wall = 14;
					}
					Main.tile[n, num4].type = 19;
					Main.tile[n, num4].active = 1;
				}
				num4--;
			}
			num8 = num4;
			float num13 = (num9 - num8) * num;
			float num14 = num13 * 0.02f;
			for (int num15 = 0; (float)num15 < num14; num15++)
			{
				int num16 = genRand.Next(i - (num >> 1), i + (num >> 1) + 1);
				int num17 = genRand.Next(num8, num9);
				int num18 = genRand.Next(3, 8);
				float num19 = (float)num18 * 0.4f;
				num19 *= num19;
				for (int num20 = num16 - num18; num20 <= num16 + num18; num20++)
				{
					float num21 = num20 - num16;
					num21 *= num21;
					for (int num22 = num17 - num18; num22 <= num17 + num18; num22++)
					{
						float num23 = num22 - num17;
						float num24 = num21 + num23 * num23;
						if (num24 < num19)
						{
							try
							{
								if (Main.tile[num20, num22].type == 76 || Main.tile[num20, num22].type == 19)
								{
									Main.tile[num20, num22].active = 0;
								}
								Main.tile[num20, num22].wall = 0;
							}
							catch
							{
							}
						}
					}
				}
			}
		}

		public static void HellRoom(int i, int j, int width, int height, int type, int wall)
		{
			if (j > Main.maxTilesY - 40)
			{
				return;
			}
			width >>= 1;
			for (int k = i - width; k <= i + width; k++)
			{
				for (int l = j - height; l <= j; l++)
				{
					try
					{
						Main.tile[k, l].active = 1;
						Main.tile[k, l].type = (byte)type;
						Main.tile[k, l].liquid = 0;
						Main.tile[k, l].lava = 0;
					}
					catch
					{
					}
				}
			}
			for (int m = i - width + 1; m <= i + width - 1; m++)
			{
				for (int n = j - height + 1; n <= j - 1; n++)
				{
					try
					{
						Main.tile[m, n].active = 0;
						Main.tile[m, n].wall = (byte)wall;
						Main.tile[m, n].liquid = 0;
						Main.tile[m, n].lava = 0;
					}
					catch
					{
					}
				}
			}
		}

		public static void MakeDungeon(int x, int y, int tileType = 41, int wallType = 7)
		{
			int num = genRand.Next(3);
			int num2 = genRand.Next(3);
			switch (num)
			{
			case 1:
				tileType = 43;
				break;
			case 2:
				tileType = 44;
				break;
			}
			switch (num2)
			{
			case 1:
				wallType = 8;
				break;
			case 2:
				wallType = 9;
				break;
			}
			numDDoors = 0;
			numDPlats = 0;
			numDRooms = 0;
			dungeonX = x;
			dungeonY = y;
			dMinX = x;
			dMaxX = x;
			dMinY = y;
			dMaxY = y;
			dxStrength1 = genRand.Next(25, 30);
			dyStrength1 = genRand.Next(20, 25);
			dxStrength2 = genRand.Next(35, 50);
			dyStrength2 = genRand.Next(10, 15);
			int num3 = Main.maxTilesX / 60;
			num3 += genRand.Next(num3 / 3);
			int num4 = num3;
			int num5 = 5;
			DungeonRoom(dungeonX, dungeonY, tileType, wallType);
			while (num3 > 0)
			{
				if (dungeonX < dMinX)
				{
					dMinX = dungeonX;
				}
				if (dungeonX > dMaxX)
				{
					dMaxX = dungeonX;
				}
				if (dungeonY > dMaxY)
				{
					dMaxY = dungeonY;
				}
				num3--;
				UI.main.progress = (float)(num4 - num3) * 0.6f / (float)num4;
				if (num5 > 0)
				{
					num5--;
				}
				if ((num5 == 0) & (genRand.Next(3) == 0))
				{
					num5 = 5;
					if (genRand.Next(2) == 0)
					{
						int num6 = dungeonX;
						int num7 = dungeonY;
						DungeonHalls(dungeonX, dungeonY, tileType, wallType);
						if (genRand.Next(2) == 0)
						{
							DungeonHalls(dungeonX, dungeonY, tileType, wallType);
						}
						DungeonRoom(dungeonX, dungeonY, tileType, wallType);
						dungeonX = num6;
						dungeonY = num7;
					}
					else
					{
						DungeonRoom(dungeonX, dungeonY, tileType, wallType);
					}
				}
				else
				{
					DungeonHalls(dungeonX, dungeonY, tileType, wallType);
				}
			}
			DungeonRoom(dungeonX, dungeonY, tileType, wallType);
			int x2 = dRoom[0].X;
			int y2 = dRoom[0].Y;
			for (int i = 1; i < numDRooms; i++)
			{
				if (dRoom[i].Y < y2)
				{
					x2 = dRoom[i].X;
					y2 = dRoom[i].Y;
				}
			}
			dungeonX = x2;
			dungeonY = y2;
			dEnteranceX = x2;
			dSurface = false;
			num5 = 5;
			while (!dSurface)
			{
				if (num5 > 0)
				{
					num5--;
				}
				if (((num5 == 0) & (genRand.Next(5) == 0)) && dungeonY > Main.worldSurface + 50)
				{
					num5 = 10;
					int num8 = dungeonX;
					int num9 = dungeonY;
					DungeonHalls(dungeonX, dungeonY, tileType, wallType, forceX: true);
					DungeonRoom(dungeonX, dungeonY, tileType, wallType);
					dungeonX = num8;
					dungeonY = num9;
				}
				DungeonStairs(dungeonX, dungeonY, tileType, wallType);
			}
			DungeonEnt(dungeonX, dungeonY, tileType, wallType);
			UI.main.progress = 0.65f;
			for (int j = 0; j < numDRooms; j++)
			{
				for (int k = dRoom[j].L; k <= dRoom[j].R; k++)
				{
					int num10 = dRoom[j].T - 1;
					if (Main.tile[k, num10].active == 0)
					{
						DPlat[numDPlats].X = (short)k;
						DPlat[numDPlats].Y = (short)num10;
						numDPlats++;
						break;
					}
				}
				for (int l = dRoom[j].L; l <= dRoom[j].R; l++)
				{
					int num11 = dRoom[j].B + 1;
					if (Main.tile[l, num11].active == 0)
					{
						DPlat[numDPlats].X = (short)l;
						DPlat[numDPlats].Y = (short)num11;
						numDPlats++;
						break;
					}
				}
				for (int m = dRoom[j].T; m <= dRoom[j].B; m++)
				{
					int num12 = dRoom[j].L - 1;
					if (Main.tile[num12, m].active == 0)
					{
						dDoor[numDDoors].X = (short)num12;
						dDoor[numDDoors].Y = (short)m;
						dDoor[numDDoors].Pos = -1;
						numDDoors++;
						break;
					}
				}
				for (int n = dRoom[j].T; n <= dRoom[j].B; n++)
				{
					int num13 = dRoom[j].R + 1;
					if (Main.tile[num13, n].active == 0)
					{
						dDoor[numDDoors].X = (short)num13;
						dDoor[numDDoors].Y = (short)n;
						dDoor[numDDoors].Pos = 1;
						numDDoors++;
						break;
					}
				}
			}
			UI.main.progress = 0.7f;
			int num14 = 0;
			int num15 = 1000;
			int num16 = 0;
			while (num16 < Main.maxTilesX / 100)
			{
				num14++;
				int num17 = genRand.Next(dMinX, dMaxX);
				int num18 = genRand.Next(Main.worldSurface + 25, dMaxY);
				int num19 = num17;
				if (Main.tile[num17, num18].wall == wallType && Main.tile[num17, num18].active == 0)
				{
					int num20 = 1;
					if (genRand.Next(2) == 0)
					{
						num20 = -1;
					}
					for (; Main.tile[num17, num18].active == 0; num18 += num20)
					{
					}
					if (Main.tile[num17 - 1, num18].active != 0 && Main.tile[num17 + 1, num18].active != 0 && Main.tile[num17 - 1, num18 - num20].active == 0 && Main.tile[num17 + 1, num18 - num20].active == 0)
					{
						num16++;
						int num21 = genRand.Next(5, 13);
						while (Main.tile[num17 - 1, num18].active != 0 && Main.tile[num17, num18 + num20].active != 0 && Main.tile[num17, num18].active != 0 && Main.tile[num17, num18 - num20].active == 0 && num21 > 0)
						{
							Main.tile[num17, num18].type = 48;
							if (Main.tile[num17 - 1, num18 - num20].active == 0 && Main.tile[num17 + 1, num18 - num20].active == 0)
							{
								Main.tile[num17, num18 - num20].type = 48;
								Main.tile[num17, num18 - num20].active = 1;
							}
							num17--;
							num21--;
						}
						num21 = genRand.Next(5, 13);
						num17 = num19 + 1;
						while (Main.tile[num17 + 1, num18].active != 0 && Main.tile[num17, num18 + num20].active != 0 && Main.tile[num17, num18].active != 0 && Main.tile[num17, num18 - num20].active == 0 && num21 > 0)
						{
							Main.tile[num17, num18].type = 48;
							if (Main.tile[num17 - 1, num18 - num20].active == 0 && Main.tile[num17 + 1, num18 - num20].active == 0)
							{
								Main.tile[num17, num18 - num20].type = 48;
								Main.tile[num17, num18 - num20].active = 1;
							}
							num17++;
							num21--;
						}
					}
				}
				if (num14 > num15)
				{
					num14 = 0;
					num16++;
				}
			}
			num14 = 0;
			num15 = 1000;
			num16 = 0;
			UI.main.progress = 0.75f;
			while (num16 < Main.maxTilesX / 100)
			{
				num14++;
				int num22 = genRand.Next(dMinX, dMaxX);
				int num23 = genRand.Next(Main.worldSurface + 25, dMaxY);
				int num24 = num23;
				if (Main.tile[num22, num23].wall == wallType && Main.tile[num22, num23].active == 0)
				{
					int num25 = 1;
					if (genRand.Next(2) == 0)
					{
						num25 = -1;
					}
					for (; num22 > 5 && num22 < Main.maxTilesX - 5 && Main.tile[num22, num23].active == 0; num22 += num25)
					{
					}
					if (Main.tile[num22, num23 - 1].active != 0 && Main.tile[num22, num23 + 1].active != 0 && Main.tile[num22 - num25, num23 - 1].active == 0 && Main.tile[num22 - num25, num23 + 1].active == 0)
					{
						num16++;
						int num26 = genRand.Next(5, 13);
						while (Main.tile[num22, num23 - 1].active != 0 && Main.tile[num22 + num25, num23].active != 0 && Main.tile[num22, num23].active != 0 && Main.tile[num22 - num25, num23].active == 0 && num26 > 0)
						{
							Main.tile[num22, num23].type = 48;
							if (Main.tile[num22 - num25, num23 - 1].active == 0 && Main.tile[num22 - num25, num23 + 1].active == 0)
							{
								Main.tile[num22 - num25, num23].type = 48;
								Main.tile[num22 - num25, num23].active = 1;
							}
							num23--;
							num26--;
						}
						num26 = genRand.Next(5, 13);
						num23 = num24 + 1;
						while (Main.tile[num22, num23 + 1].active != 0 && Main.tile[num22 + num25, num23].active != 0 && Main.tile[num22, num23].active != 0 && Main.tile[num22 - num25, num23].active == 0 && num26 > 0)
						{
							Main.tile[num22, num23].type = 48;
							if (Main.tile[num22 - num25, num23 - 1].active == 0 && Main.tile[num22 - num25, num23 + 1].active == 0)
							{
								Main.tile[num22 - num25, num23].type = 48;
								Main.tile[num22 - num25, num23].active = 1;
							}
							num23++;
							num26--;
						}
					}
				}
				if (num14 > num15)
				{
					num14 = 0;
					num16++;
				}
			}
			UI.main.progress = 0.8f;
			for (int num27 = 0; num27 < numDDoors; num27++)
			{
				int num28 = dDoor[num27].X - 10;
				int num29 = dDoor[num27].X + 10;
				int num30 = 100;
				int num31 = 0;
				int num32 = 0;
				int num33 = 0;
				for (int num34 = num28; num34 < num29; num34++)
				{
					bool flag = true;
					int num35 = dDoor[num27].Y;
					while (Main.tile[num34, num35].active == 0)
					{
						num35--;
					}
					if (!Main.tileDungeon[Main.tile[num34, num35].type])
					{
						flag = false;
					}
					num32 = num35;
					for (num35 = dDoor[num27].Y; Main.tile[num34, num35].active == 0; num35++)
					{
					}
					if (!Main.tileDungeon[Main.tile[num34, num35].type])
					{
						flag = false;
					}
					num33 = num35;
					if (num33 - num32 < 3)
					{
						continue;
					}
					int num36 = num34 - 20;
					int num37 = num34 + 20;
					int num38 = num33 - 10;
					int num39 = num33 + 10;
					for (int num40 = num36; num40 < num37; num40++)
					{
						for (int num41 = num38; num41 < num39; num41++)
						{
							if (Main.tile[num40, num41].active != 0 && Main.tile[num40, num41].type == 10)
							{
								flag = false;
								break;
							}
						}
					}
					if (flag)
					{
						for (int num42 = num33 - 3; num42 < num33; num42++)
						{
							for (int num43 = num34 - 3; num43 <= num34 + 3; num43++)
							{
								if (Main.tile[num43, num42].active != 0)
								{
									flag = false;
									break;
								}
							}
						}
					}
					if (flag && num33 - num32 < 20 && ((dDoor[num27].Pos == 0 && num33 - num32 < num30) || (dDoor[num27].Pos == -1 && num34 > num31) || (dDoor[num27].Pos == 1 && (num34 < num31 || num31 == 0))))
					{
						num31 = num34;
						num30 = num33 - num32;
					}
				}
				if (num30 >= 20)
				{
					continue;
				}
				int num44 = num31;
				int num45 = dDoor[num27].Y;
				int num46 = num45;
				for (; Main.tile[num44, num45].active == 0; num45++)
				{
					Main.tile[num44, num45].active = 0;
				}
				while (Main.tile[num44, num46].active == 0)
				{
					num46--;
				}
				num45--;
				num46++;
				for (int num47 = num46; num47 < num45 - 2; num47++)
				{
					Main.tile[num44, num47].active = 1;
					Main.tile[num44, num47].type = (byte)tileType;
				}
				PlaceTile(num44, num45, 10, mute: true);
				num44--;
				int num48 = num45 - 3;
				while (Main.tile[num44, num48].active == 0)
				{
					num48--;
				}
				if (num45 - num48 < num45 - num46 + 5 && Main.tileDungeon[Main.tile[num44, num48].type])
				{
					for (int num49 = num45 - 4 - genRand.Next(3); num49 > num48; num49--)
					{
						Main.tile[num44, num49].active = 1;
						Main.tile[num44, num49].type = (byte)tileType;
					}
				}
				num44 += 2;
				num48 = num45 - 3;
				while (Main.tile[num44, num48].active == 0)
				{
					num48--;
				}
				if (num45 - num48 < num45 - num46 + 5 && Main.tileDungeon[Main.tile[num44, num48].type])
				{
					for (int num50 = num45 - 4 - genRand.Next(3); num50 > num48; num50--)
					{
						Main.tile[num44, num50].active = 1;
						Main.tile[num44, num50].type = (byte)tileType;
					}
				}
				num45++;
				num44--;
				Main.tile[num44 - 1, num45].active = 1;
				Main.tile[num44 - 1, num45].type = (byte)tileType;
				Main.tile[num44 + 1, num45].active = 1;
				Main.tile[num44 + 1, num45].type = (byte)tileType;
			}
			UI.main.progress = 0.85f;
			for (int num51 = 0; num51 < numDPlats; num51++)
			{
				int x3 = DPlat[num51].X;
				int y3 = DPlat[num51].Y;
				int num52 = Main.maxTilesX;
				int num53 = 10;
				for (int num54 = y3 - 5; num54 <= y3 + 5; num54++)
				{
					int num55 = x3;
					int num56 = x3;
					bool flag2 = false;
					if (Main.tile[num55, num54].active != 0)
					{
						flag2 = true;
					}
					else
					{
						while (Main.tile[num55, num54].active == 0)
						{
							num55--;
							if (!Main.tileDungeon[Main.tile[num55, num54].type])
							{
								flag2 = true;
							}
						}
						while (Main.tile[num56, num54].active == 0)
						{
							num56++;
							if (!Main.tileDungeon[Main.tile[num56, num54].type])
							{
								flag2 = true;
							}
						}
					}
					if (flag2 || num56 - num55 > num53)
					{
						continue;
					}
					bool flag3 = true;
					int num57 = x3 - (num53 >> 1) - 2;
					int num58 = x3 + (num53 >> 1) + 2;
					int num59 = num54 - 5;
					int num60 = num54 + 5;
					for (int num61 = num57; num61 <= num58; num61++)
					{
						for (int num62 = num59; num62 <= num60; num62++)
						{
							if (Main.tile[num61, num62].active != 0 && Main.tile[num61, num62].type == 19)
							{
								flag3 = false;
								break;
							}
						}
					}
					for (int num63 = num54 + 3; num63 >= num54 - 5; num63--)
					{
						if (Main.tile[x3, num63].active != 0)
						{
							flag3 = false;
							break;
						}
					}
					if (flag3)
					{
						num52 = num54;
						break;
					}
				}
				if (num52 > y3 - 10 && num52 < y3 + 10)
				{
					int num64 = x3;
					int num65 = num52;
					int num66 = x3 + 1;
					while (Main.tile[num64, num65].active == 0)
					{
						Main.tile[num64, num65].active = 1;
						Main.tile[num64, num65].type = 19;
						num64--;
					}
					for (; Main.tile[num66, num65].active == 0; num66++)
					{
						Main.tile[num66, num65].active = 1;
						Main.tile[num66, num65].type = 19;
					}
				}
			}
			UI.main.progress = 0.9f;
			num14 = 0;
			num15 = 1000;
			num16 = 0;
			while (num16 < Main.maxTilesX / 20)
			{
				num14++;
				int num67 = genRand.Next(dMinX, dMaxX);
				int num68 = genRand.Next(dMinY, dMaxY);
				bool flag4 = true;
				if (Main.tile[num67, num68].wall == wallType && Main.tile[num67, num68].active == 0)
				{
					int num69 = 1;
					if (genRand.Next(2) == 0)
					{
						num69 = -1;
					}
					while (flag4 && Main.tile[num67, num68].active == 0)
					{
						num67 -= num69;
						if (num67 < 5 || num67 > Main.maxTilesX - 5)
						{
							flag4 = false;
						}
						else if (Main.tile[num67, num68].active != 0 && !Main.tileDungeon[Main.tile[num67, num68].type])
						{
							flag4 = false;
						}
					}
					if (flag4 && Main.tile[num67, num68].active != 0 && Main.tileDungeon[Main.tile[num67, num68].type] && Main.tile[num67, num68 - 1].active != 0 && Main.tileDungeon[Main.tile[num67, num68 - 1].type] && Main.tile[num67, num68 + 1].active != 0 && Main.tileDungeon[Main.tile[num67, num68 + 1].type])
					{
						num67 += num69;
						for (int num70 = num67 - 3; num70 <= num67 + 3; num70++)
						{
							for (int num71 = num68 - 3; num71 <= num68 + 3; num71++)
							{
								if (Main.tile[num70, num71].active != 0 && Main.tile[num70, num71].type == 19)
								{
									flag4 = false;
									break;
								}
							}
						}
						if (flag4 && ((Main.tile[num67, num68 - 1].active == 0) & (Main.tile[num67, num68 - 2].active == 0) & (Main.tile[num67, num68 - 3].active == 0)))
						{
							int num72 = num67;
							int num73 = num67;
							for (; num72 > dMinX && num72 < dMaxX && Main.tile[num72, num68].active == 0 && Main.tile[num72, num68 - 1].active == 0 && Main.tile[num72, num68 + 1].active == 0; num72 += num69)
							{
							}
							num72 = Math.Abs(num67 - num72);
							bool flag5 = false;
							if (genRand.Next(2) == 0)
							{
								flag5 = true;
							}
							if (num72 > 5)
							{
								for (int num74 = genRand.Next(1, 4); num74 > 0; num74--)
								{
									Main.tile[num67, num68].active = 1;
									Main.tile[num67, num68].type = 19;
									if (flag5)
									{
										PlaceTile(num67, num68 - 1, 50, mute: true);
										if (genRand.Next(50) == 0 && Main.tile[num67, num68 - 1].type == 50)
										{
											Main.tile[num67, num68 - 1].frameX = 90;
										}
									}
									num67 += num69;
								}
								num14 = 0;
								num16++;
								if (!flag5 && genRand.Next(2) == 0)
								{
									num67 = num73;
									num68--;
									int num75 = 0;
									if (genRand.Next(4) == 0)
									{
										num75 = 1;
									}
									switch (num75)
									{
									case 0:
										num75 = 13;
										break;
									case 1:
										num75 = 49;
										break;
									}
									PlaceTile(num67, num68, num75, mute: true);
									if (Main.tile[num67, num68].type == 13)
									{
										if (genRand.Next(2) == 0)
										{
											Main.tile[num67, num68].frameX = 18;
										}
										else
										{
											Main.tile[num67, num68].frameX = 36;
										}
									}
								}
							}
						}
					}
				}
				if (num14 > num15)
				{
					num14 = 0;
					num16++;
				}
			}
			UI.main.progress = 0.95f;
			int num76 = 0;
			for (int num77 = 0; num77 < numDRooms; num77++)
			{
				int num78 = 0;
				while (num78 < 1000)
				{
					int num79 = (int)(dRoom[num77].Size * 0.4f);
					int i2 = dRoom[num77].X + genRand.Next(-num79, num79 + 1);
					int num80 = dRoom[num77].Y + genRand.Next(-num79, num79 + 1);
					int num81 = 0;
					num76++;
					int style = 2;
					switch (num76)
					{
					case 1:
						num81 = 329;
						break;
					case 2:
						num81 = 155;
						break;
					case 3:
						num81 = 156;
						break;
					case 4:
						num81 = 157;
						break;
					case 5:
						num81 = 163;
						break;
					case 6:
						num81 = 113;
						break;
					case 7:
						num81 = 327;
						style = 0;
						break;
					default:
						num81 = 164;
						num76 = 0;
						break;
					}
					if (num80 < Main.worldSurface + 50)
					{
						num81 = 327;
						style = 0;
					}
					if (num81 == 0 && genRand.Next(2) == 0)
					{
						num78 = 1000;
						continue;
					}
					if (AddBuriedChest(i2, num80, num81, notNearOtherChests: false, style))
					{
						num78 += 1000;
					}
					num78++;
				}
			}
			dMinX -= 25;
			dMaxX += 25;
			dMinY -= 25;
			dMaxY += 25;
			if (dMinX < 0)
			{
				dMinX = 0;
			}
			if (dMaxX > Main.maxTilesX)
			{
				dMaxX = Main.maxTilesX;
			}
			if (dMinY < 0)
			{
				dMinY = 0;
			}
			if (dMaxY > Main.maxTilesY)
			{
				dMaxY = Main.maxTilesY;
			}
			num14 = 0;
			num15 = 1000;
			num16 = 0;
			while (num16 < Main.maxTilesX / 150)
			{
				num14++;
				int num82 = genRand.Next(dMinX, dMaxX);
				int num83 = genRand.Next(dMinY, dMaxY);
				if (Main.tile[num82, num83].wall == wallType)
				{
					for (int num84 = num83; num84 > dMinY; num84--)
					{
						if (Main.tile[num82, num84 - 1].active != 0 && Main.tile[num82, num84 - 1].type == tileType)
						{
							bool flag6 = false;
							for (int num85 = num82 - 15; num85 < num82 + 15; num85++)
							{
								for (int num86 = num84 - 15; num86 < num84 + 15; num86++)
								{
									if (num85 > 0 && num85 < Main.maxTilesX && num86 > 0 && num86 < Main.maxTilesY && Main.tile[num85, num86].type == 42)
									{
										flag6 = true;
										break;
									}
								}
							}
							if (Main.tile[num82 - 1, num84].active != 0 || Main.tile[num82 + 1, num84].active != 0 || Main.tile[num82 - 1, num84 + 1].active != 0 || Main.tile[num82 + 1, num84 + 1].active != 0 || Main.tile[num82, num84 + 2].active != 0)
							{
								flag6 = true;
							}
							if (flag6 || !Place1x2Top(num82, num84, 42))
							{
								break;
							}
							num14 = 0;
							num16++;
							Rectangle aabb = default(Rectangle);
							Rectangle aabb2 = default(Rectangle);
							aabb2.X = num82 << 4;
							aabb2.Y = (num84 << 4) + 1;
							aabb.Width = (aabb2.Width = 16);
							aabb.Height = (aabb2.Height = 16);
							for (int num87 = 0; num87 < 1000; num87++)
							{
								int num88 = num82 + genRand.Next(-12, 13);
								int num89 = num84 + genRand.Next(3, 21);
								if (Main.tile[num88, num89].active != 0 || Main.tile[num88, num89 + 1].active != 0 || Main.tile[num88 - 1, num89].type == 48 || Main.tile[num88 + 1, num89].type == 48)
								{
									continue;
								}
								aabb.X = num88 << 4;
								aabb.Y = num89 << 4;
								if (!Collision.CanHit(ref aabb, ref aabb2))
								{
									continue;
								}
								PlaceTile(num88, num89, 136, mute: true);
								if (Main.tile[num88, num89].active == 0)
								{
									continue;
								}
								while (num88 != num82 || num89 != num84)
								{
									Main.tile[num88, num89].wire = 16;
									if (num88 > num82)
									{
										num88--;
									}
									if (num88 < num82)
									{
										num88++;
									}
									Main.tile[num88, num89].wire = 16;
									if (num89 > num84)
									{
										num89--;
									}
									if (num89 < num84)
									{
										num89++;
									}
									Main.tile[num88, num89].wire = 16;
								}
								if (Main.rand.Next(3) > 0)
								{
									Main.tile[num82, num84].frameX = 18;
									Main.tile[num82, num84 + 1].frameX = 18;
								}
								break;
							}
							break;
						}
					}
				}
				if (num14 > num15)
				{
					num16++;
					num14 = 0;
				}
			}
			num14 = 0;
			num15 = 1000;
			num16 = 0;
			while (num16 < Main.maxTilesX / 500)
			{
				num14++;
				int num90 = genRand.Next(dMinX, dMaxX);
				int num91 = genRand.Next(dMinY, dMaxY);
				if (Main.tile[num90, num91].wall == wallType && placeTrap(num90, num91, 0))
				{
					num14 = num15;
				}
				if (num14 > num15)
				{
					num16++;
					num14 = 0;
				}
			}
		}

		public static void DungeonStairs(int i, int j, int tileType, int wallType)
		{
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			double num = genRand.Next(5, 9);
			int num2 = 1;
			vector.X = i;
			vector.Y = j;
			int num3 = genRand.Next(10, 30);
			num2 = ((i <= dEnteranceX) ? 1 : (-1));
			if (i > Main.maxTilesX - 400)
			{
				num2 = -1;
			}
			else if (i < 400)
			{
				num2 = 1;
			}
			vector2.Y = -1f;
			vector2.X = num2;
			if (genRand.Next(3) == 0)
			{
				vector2.X *= 0.5f;
			}
			else if (genRand.Next(3) == 0)
			{
				vector2.Y *= 2f;
			}
			while (num3 > 0)
			{
				num3--;
				int num4 = (int)((double)vector.X - num - 4.0 - (double)genRand.Next(6));
				int num5 = (int)((double)vector.X + num + 4.0 + (double)genRand.Next(6));
				int num6 = (int)((double)vector.Y - num - 4.0);
				int num7 = (int)((double)vector.Y + num + 4.0 + (double)genRand.Next(6));
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				double num8 = 1.0;
				if (vector.X > (float)(Main.maxTilesX >> 1))
				{
					num8 = -1.0;
				}
				int num9 = (int)((double)vector.X + dxStrength1 * 0.6 * num8 + dxStrength2 * num8);
				double num10 = Math.Floor(dyStrength2 * 0.5);
				int num11 = (int)((double)vector.Y - num + num10);
				if (vector.Y < (float)(Main.worldSurface - 5) && Main.tile[num9, num11 - 6].wall == 0 && Main.tile[num9, num11 - 7].wall == 0 && Main.tile[num9, num11 - 8].wall == 0)
				{
					dSurface = true;
					TileRunner(num9, (int)((double)vector.Y - num - 6.0 + num10), genRand.Next(25, 35), genRand.Next(10, 20), -1, addTile: false, new Vector2(0f, -1f));
				}
				for (int k = num4; k < num5; k++)
				{
					for (int l = num6; l < num7; l++)
					{
						Main.tile[k, l].liquid = 0;
						if (Main.tile[k, l].wall != wallType)
						{
							Main.tile[k, l].wall = 0;
							Main.tile[k, l].active = 1;
							Main.tile[k, l].type = (byte)tileType;
						}
					}
				}
				for (int m = num4 + 1; m < num5 - 1; m++)
				{
					for (int n = num6 + 1; n < num7 - 1; n++)
					{
						if (Main.tile[m, n].wall == 0)
						{
							Main.tile[m, n].wall = (byte)wallType;
						}
					}
				}
				int num12 = 0;
				if (genRand.Next((int)num) == 0)
				{
					num12 = genRand.Next(1, 3);
				}
				num4 = (int)((double)vector.X - num * 0.5 - (double)num12);
				num5 = (int)((double)vector.X + num * 0.5 + (double)num12);
				num6 = (int)((double)vector.Y - num * 0.5 - (double)num12);
				num7 = (int)((double)vector.Y + num * 0.5 + (double)num12);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int num13 = num4; num13 < num5; num13++)
				{
					for (int num14 = num6; num14 < num7; num14++)
					{
						Main.tile[num13, num14].active = 0;
						if (Main.tile[num13, num14].wall == 0)
						{
							Main.tile[num13, num14].wall = (byte)wallType;
						}
					}
				}
				if (dSurface)
				{
					num3 = 0;
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
			}
			dungeonX = (int)vector.X;
			dungeonY = (int)vector.Y;
		}

		public static void DungeonHalls(int i, int j, int tileType, int wallType, bool forceX = false)
		{
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			double num = genRand.Next(4, 6);
			Vector2i vector2i = default(Vector2i);
			Vector2i vector2i2 = default(Vector2i);
			int num2 = 1;
			vector.X = i;
			vector.Y = j;
			int num3 = genRand.Next(35, 80);
			if (forceX)
			{
				num3 += 20;
				lastDungeonHall = default(Vector2i);
			}
			else if (genRand.Next(5) == 0)
			{
				num *= 2.0;
				num3 >>= 1;
			}
			do
			{
				num2 = (genRand.Next(2) << 1) - 1;
				if (forceX || genRand.Next(2) == 0)
				{
					vector2i.Y = 0;
					vector2i.X = num2;
					vector2i2.Y = 0;
					vector2i2.X = -num2;
					vector2.Y = 0f;
					vector2.X = num2;
					if (genRand.Next(3) == 0)
					{
						if (genRand.Next(2) == 0)
						{
							vector2.Y = -0.2f;
						}
						else
						{
							vector2.Y = 0.2f;
						}
					}
					continue;
				}
				num += 1.0;
				vector2.Y = num2;
				vector2.X = 0f;
				vector2i.X = 0;
				vector2i.Y = num2;
				vector2i2.X = 0;
				vector2i2.Y = -num2;
				if (genRand.Next(2) == 0)
				{
					if (genRand.Next(2) == 0)
					{
						vector2.X = 0.3f;
					}
					else
					{
						vector2.X = -0.3f;
					}
				}
				else
				{
					num3 >>= 1;
				}
			}
			while (lastDungeonHall.X == vector2i2.X && lastDungeonHall.Y == vector2i2.Y);
			if (!forceX)
			{
				if (vector.X > (float)(lastMaxTilesX - 200))
				{
					num2 = -1;
					vector2i.Y = 0;
					vector2i.X = num2;
					vector2.Y = 0f;
					vector2.X = num2;
					if (genRand.Next(3) == 0)
					{
						if (genRand.Next(2) == 0)
						{
							vector2.Y = -0.2f;
						}
						else
						{
							vector2.Y = 0.2f;
						}
					}
				}
				else if (vector.X < 200f)
				{
					num2 = 1;
					vector2i.Y = 0;
					vector2i.X = num2;
					vector2.Y = 0f;
					vector2.X = num2;
					if (genRand.Next(3) == 0)
					{
						if (genRand.Next(2) == 0)
						{
							vector2.Y = -0.2f;
						}
						else
						{
							vector2.Y = 0.2f;
						}
					}
				}
				else if (vector.Y > (float)(lastMaxTilesY - 300))
				{
					num2 = -1;
					num += 1.0;
					vector2.Y = num2;
					vector2.X = 0f;
					vector2i.X = 0;
					vector2i.Y = num2;
					if (genRand.Next(2) == 0)
					{
						if (genRand.Next(2) == 0)
						{
							vector2.X = 0.3f;
						}
						else
						{
							vector2.X = -0.3f;
						}
					}
				}
				else if (vector.Y < (float)Main.rockLayer)
				{
					num2 = 1;
					num += 1.0;
					vector2.Y = num2;
					vector2.X = 0f;
					vector2i.X = 0;
					vector2i.Y = num2;
					if (genRand.Next(2) == 0)
					{
						if (genRand.Next(2) == 0)
						{
							vector2.X = 0.3f;
						}
						else
						{
							vector2.X = -0.3f;
						}
					}
				}
				else if (vector.X < (float)(Main.maxTilesX >> 1) && vector.X > (float)(Main.maxTilesX >> 2))
				{
					num2 = -1;
					vector2i.Y = 0;
					vector2i.X = num2;
					vector2.Y = 0f;
					vector2.X = num2;
					if (genRand.Next(3) == 0)
					{
						if (genRand.Next(2) == 0)
						{
							vector2.Y = -0.2f;
						}
						else
						{
							vector2.Y = 0.2f;
						}
					}
				}
				else if (vector.X > (float)(Main.maxTilesX >> 1) && (double)vector.X < (double)Main.maxTilesX * 0.75)
				{
					num2 = 1;
					vector2i.Y = 0;
					vector2i.X = num2;
					vector2.Y = 0f;
					vector2.X = num2;
					if (genRand.Next(3) == 0)
					{
						if (genRand.Next(2) == 0)
						{
							vector2.Y = -0.2f;
						}
						else
						{
							vector2.Y = 0.2f;
						}
					}
				}
			}
			if (vector2i.Y == 0)
			{
				dDoor[numDDoors].X = (short)vector.X;
				dDoor[numDDoors].Y = (short)vector.Y;
				dDoor[numDDoors].Pos = 0;
				numDDoors++;
			}
			else
			{
				DPlat[numDPlats].X = (short)vector.X;
				DPlat[numDPlats].Y = (short)vector.Y;
				numDPlats++;
			}
			lastDungeonHall = vector2i;
			while (num3 > 0)
			{
				if (vector2i.X > 0 && vector.X > (float)(Main.maxTilesX - 100))
				{
					num3 = 0;
				}
				else if (vector2i.X < 0 && vector.X < 100f)
				{
					num3 = 0;
				}
				else if (vector2i.Y > 0 && vector.Y > (float)(Main.maxTilesY - 100))
				{
					num3 = 0;
				}
				else if (vector2i.Y < 0 && vector.Y < (float)(Main.rockLayer + 50))
				{
					num3 = 0;
				}
				num3--;
				int num4 = (int)((double)vector.X - num - 4.0 - (double)genRand.Next(6));
				int num5 = (int)((double)vector.X + num + 4.0 + (double)genRand.Next(6));
				int num6 = (int)((double)vector.Y - num - 4.0 - (double)genRand.Next(6));
				int num7 = (int)((double)vector.Y + num + 4.0 + (double)genRand.Next(6));
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int k = num4; k < num5; k++)
				{
					for (int l = num6; l < num7; l++)
					{
						Main.tile[k, l].liquid = 0;
						if (Main.tile[k, l].wall == 0)
						{
							Main.tile[k, l].active = 1;
							Main.tile[k, l].type = (byte)tileType;
						}
					}
				}
				for (int m = num4 + 1; m < num5 - 1; m++)
				{
					for (int n = num6 + 1; n < num7 - 1; n++)
					{
						if (Main.tile[m, n].wall == 0)
						{
							Main.tile[m, n].wall = (byte)wallType;
						}
					}
				}
				int num8 = 0;
				if (vector2.Y == 0f && genRand.Next((int)num + 1) == 0)
				{
					num8 = genRand.Next(1, 3);
				}
				else if (vector2.X == 0f && genRand.Next((int)num - 1) == 0)
				{
					num8 = genRand.Next(1, 3);
				}
				else if (genRand.Next((int)num * 3) == 0)
				{
					num8 = genRand.Next(1, 3);
				}
				num4 = (int)((double)vector.X - num * 0.5 - (double)num8);
				num5 = (int)((double)vector.X + num * 0.5 + (double)num8);
				num6 = (int)((double)vector.Y - num * 0.5 - (double)num8);
				num7 = (int)((double)vector.Y + num * 0.5 + (double)num8);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int num9 = num4; num9 < num5; num9++)
				{
					for (int num10 = num6; num10 < num7; num10++)
					{
						Main.tile[num9, num10].active = 0;
						Main.tile[num9, num10].wall = (byte)wallType;
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
			}
			dungeonX = (int)vector.X;
			dungeonY = (int)vector.Y;
			if (vector2i.Y == 0)
			{
				dDoor[numDDoors].X = (short)vector.X;
				dDoor[numDDoors].Y = (short)vector.Y;
				dDoor[numDDoors].Pos = 0;
				numDDoors++;
			}
			else
			{
				DPlat[numDPlats].X = (short)vector.X;
				DPlat[numDPlats].Y = (short)vector.Y;
				numDPlats++;
			}
		}

		public static void DungeonRoom(int i, int j, int tileType, int wallType)
		{
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			float num = genRand.Next(15, 30);
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(-10, 11) * 0.1f;
			vector.X = i;
			vector.Y = (float)j - num * 0.5f;
			int num2 = genRand.Next(10, 20);
			float num3 = vector.X;
			float num4 = vector.X;
			float num5 = vector.Y;
			float num6 = vector.Y;
			while (num2 > 0)
			{
				num2--;
				int num7 = (int)(vector.X - num * 0.8f - 5f);
				int num8 = (int)(vector.X + num * 0.8f + 5f);
				int num9 = (int)(vector.Y - num * 0.8f - 5f);
				int num10 = (int)(vector.Y + num * 0.8f + 5f);
				if (num7 < 0)
				{
					num7 = 0;
				}
				if (num8 > Main.maxTilesX)
				{
					num8 = Main.maxTilesX;
				}
				if (num9 < 0)
				{
					num9 = 0;
				}
				if (num10 > Main.maxTilesY)
				{
					num10 = Main.maxTilesY;
				}
				for (int k = num7; k < num8; k++)
				{
					for (int l = num9; l < num10; l++)
					{
						Main.tile[k, l].liquid = 0;
						if (Main.tile[k, l].wall == 0)
						{
							Main.tile[k, l].active = 1;
							Main.tile[k, l].type = (byte)tileType;
						}
					}
				}
				for (int m = num7 + 1; m < num8 - 1; m++)
				{
					for (int n = num9 + 1; n < num10 - 1; n++)
					{
						if (Main.tile[m, n].wall == 0)
						{
							Main.tile[m, n].wall = (byte)wallType;
						}
					}
				}
				num7 = (int)((double)vector.X - (double)num * 0.5);
				num8 = (int)((double)vector.X + (double)num * 0.5);
				num9 = (int)((double)vector.Y - (double)num * 0.5);
				num10 = (int)((double)vector.Y + (double)num * 0.5);
				if (num7 < 0)
				{
					num7 = 0;
				}
				if (num8 > Main.maxTilesX)
				{
					num8 = Main.maxTilesX;
				}
				if (num9 < 0)
				{
					num9 = 0;
				}
				if (num10 > Main.maxTilesY)
				{
					num10 = Main.maxTilesY;
				}
				if ((float)num7 < num3)
				{
					num3 = num7;
				}
				if ((float)num8 > num4)
				{
					num4 = num8;
				}
				if ((float)num9 < num5)
				{
					num5 = num9;
				}
				if ((float)num10 > num6)
				{
					num6 = num10;
				}
				for (int num11 = num7; num11 < num8; num11++)
				{
					for (int num12 = num9; num12 < num10; num12++)
					{
						Main.tile[num11, num12].active = 0;
						Main.tile[num11, num12].wall = (byte)wallType;
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > 1f)
				{
					vector2.X = 1f;
				}
				if (vector2.X < -1f)
				{
					vector2.X = -1f;
				}
				if (vector2.Y > 1f)
				{
					vector2.Y = 1f;
				}
				if (vector2.Y < -1f)
				{
					vector2.Y = -1f;
				}
			}
			dRoom[numDRooms].X = (short)vector.X;
			dRoom[numDRooms].Y = (short)vector.Y;
			dRoom[numDRooms].Size = num;
			dRoom[numDRooms].L = (short)num3;
			dRoom[numDRooms].R = (short)num4;
			dRoom[numDRooms].T = (short)num5;
			dRoom[numDRooms].B = (short)num6;
			numDRooms++;
		}

		public static void DungeonEnt(int i, int j, int tileType, int wallType)
		{
			int num = 60;
			for (int k = i - num; k < i + num; k++)
			{
				for (int l = j - num; l < j + num; l++)
				{
					Main.tile[k, l].liquid = 0;
					Main.tile[k, l].lava = 0;
				}
			}
			double num2 = dxStrength1;
			double num3 = dyStrength1;
			Vector2 vector = default(Vector2);
			vector.X = i;
			vector.Y = (float)((double)j - num3 * 0.5);
			dMinY = (int)vector.Y;
			int num4 = 1;
			if (i > Main.maxTilesX >> 1)
			{
				num4 = -1;
			}
			int num5 = (int)((double)vector.X - num2 * 0.60000002384185791 - (double)genRand.Next(2, 5));
			int num6 = (int)((double)vector.X + num2 * 0.60000002384185791 + (double)genRand.Next(2, 5));
			int num7 = (int)((double)vector.Y - num3 * 0.60000002384185791 - (double)genRand.Next(2, 5));
			int num8 = (int)((double)vector.Y + num3 * 0.60000002384185791 + (double)genRand.Next(8, 16));
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int m = num5; m < num6; m++)
			{
				for (int n = num7; n < num8; n++)
				{
					Main.tile[m, n].liquid = 0;
					if (Main.tile[m, n].wall != wallType)
					{
						Main.tile[m, n].wall = 0;
						if (m > num5 + 1 && m < num6 - 2 && n > num7 + 1 && n < num8 - 2)
						{
							Main.tile[m, n].wall = (byte)wallType;
						}
						Main.tile[m, n].active = 1;
						Main.tile[m, n].type = (byte)tileType;
					}
				}
			}
			int num9 = num5;
			int num10 = num5 + 5 + genRand.Next(4);
			int num11 = num7 - 3 - genRand.Next(3);
			int num12 = num7;
			for (int num13 = num9; num13 < num10; num13++)
			{
				for (int num14 = num11; num14 < num12; num14++)
				{
					if (Main.tile[num13, num14].wall != wallType)
					{
						Main.tile[num13, num14].active = 1;
						Main.tile[num13, num14].type = (byte)tileType;
					}
				}
			}
			num9 = num6 - 5 - genRand.Next(4);
			num10 = num6;
			num11 = num7 - 3 - genRand.Next(3);
			num12 = num7;
			for (int num15 = num9; num15 < num10; num15++)
			{
				for (int num16 = num11; num16 < num12; num16++)
				{
					if (Main.tile[num15, num16].wall != wallType)
					{
						Main.tile[num15, num16].active = 1;
						Main.tile[num15, num16].type = (byte)tileType;
					}
				}
			}
			int num17 = 1 + genRand.Next(2);
			int num18 = 2 + genRand.Next(4);
			int num19 = 0;
			for (int num20 = num5; num20 < num6; num20++)
			{
				for (int num21 = num7 - num17; num21 < num7; num21++)
				{
					if (Main.tile[num20, num21].wall != wallType)
					{
						Main.tile[num20, num21].active = 1;
						Main.tile[num20, num21].type = (byte)tileType;
					}
				}
				num19++;
				if (num19 >= num18)
				{
					num20 += num18;
					num19 = 0;
				}
			}
			for (int num22 = num5; num22 < num6; num22++)
			{
				for (int num23 = num8; num23 < num8 + 100; num23++)
				{
					if (Main.tile[num22, num23].wall == 0)
					{
						Main.tile[num22, num23].wall = 2;
					}
				}
			}
			num5 = (int)((double)vector.X - num2 * 0.60000002384185791);
			num6 = (int)((double)vector.X + num2 * 0.60000002384185791);
			num7 = (int)((double)vector.Y - num3 * 0.60000002384185791);
			num8 = (int)((double)vector.Y + num3 * 0.60000002384185791);
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int num24 = num5; num24 < num6; num24++)
			{
				for (int num25 = num7; num25 < num8; num25++)
				{
					if (Main.tile[num24, num25].wall == 0)
					{
						Main.tile[num24, num25].wall = (byte)wallType;
					}
				}
			}
			num5 = (int)((double)vector.X - num2 * 0.6 - 1.0);
			num6 = (int)((double)vector.X + num2 * 0.6 + 1.0);
			num7 = (int)((double)vector.Y - num3 * 0.6 - 1.0);
			num8 = (int)((double)vector.Y + num3 * 0.6 + 1.0);
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int num26 = num5; num26 < num6; num26++)
			{
				for (int num27 = num7; num27 < num8; num27++)
				{
					Main.tile[num26, num27].wall = (byte)wallType;
				}
			}
			num5 = (int)((double)vector.X - num2 * 0.5);
			num6 = (int)((double)vector.X + num2 * 0.5);
			num7 = (int)((double)vector.Y - num3 * 0.5);
			num8 = (int)((double)vector.Y + num3 * 0.5);
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int num28 = num5; num28 < num6; num28++)
			{
				for (int num29 = num7; num29 < num8; num29++)
				{
					Main.tile[num28, num29].active = 0;
					Main.tile[num28, num29].wall = (byte)wallType;
				}
			}
			DPlat[numDPlats].X = (short)vector.X;
			DPlat[numDPlats].Y = (short)num8;
			numDPlats++;
			vector.X += (float)num2 * 0.6f * (float)num4;
			vector.Y += (float)num3 * 0.5f;
			num2 = dxStrength2;
			num3 = dyStrength2;
			vector.X += (float)num2 * 0.55f * (float)num4;
			vector.Y -= (float)num3 * 0.5f;
			num5 = (int)((double)vector.X - num2 * 0.60000002384185791 - (double)genRand.Next(1, 3));
			num6 = (int)((double)vector.X + num2 * 0.60000002384185791 + (double)genRand.Next(1, 3));
			num7 = (int)((double)vector.Y - num3 * 0.60000002384185791 - (double)genRand.Next(1, 3));
			num8 = (int)((double)vector.Y + num3 * 0.60000002384185791 + (double)genRand.Next(6, 16));
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int num30 = num5; num30 < num6; num30++)
			{
				for (int num31 = num7; num31 < num8; num31++)
				{
					if (Main.tile[num30, num31].wall == wallType)
					{
						continue;
					}
					bool flag = true;
					if (num4 < 0)
					{
						if ((double)num30 < (double)vector.X - num2 * 0.5)
						{
							flag = false;
						}
					}
					else if ((double)num30 > (double)vector.X + num2 * 0.5 - 1.0)
					{
						flag = false;
					}
					if (flag)
					{
						Main.tile[num30, num31].wall = 0;
						Main.tile[num30, num31].active = 1;
						Main.tile[num30, num31].type = (byte)tileType;
					}
				}
			}
			for (int num32 = num5; num32 < num6; num32++)
			{
				for (int num33 = num8; num33 < num8 + 100; num33++)
				{
					if (Main.tile[num32, num33].wall == 0)
					{
						Main.tile[num32, num33].wall = 2;
					}
				}
			}
			num5 = (int)((double)vector.X - num2 * 0.5);
			num6 = (int)((double)vector.X + num2 * 0.5);
			num9 = num5;
			if (num4 < 0)
			{
				num9++;
			}
			num10 = num9 + 5 + genRand.Next(4);
			num11 = num7 - 3 - genRand.Next(3);
			num12 = num7;
			for (int num34 = num9; num34 < num10; num34++)
			{
				for (int num35 = num11; num35 < num12; num35++)
				{
					if (Main.tile[num34, num35].wall != wallType)
					{
						Main.tile[num34, num35].active = 1;
						Main.tile[num34, num35].type = (byte)tileType;
					}
				}
			}
			num9 = num6 - 5 - genRand.Next(4);
			num10 = num6;
			num11 = num7 - 3 - genRand.Next(3);
			num12 = num7;
			for (int num36 = num9; num36 < num10; num36++)
			{
				for (int num37 = num11; num37 < num12; num37++)
				{
					if (Main.tile[num36, num37].wall != wallType)
					{
						Main.tile[num36, num37].active = 1;
						Main.tile[num36, num37].type = (byte)tileType;
					}
				}
			}
			num17 = 1 + genRand.Next(2);
			num18 = 2 + genRand.Next(4);
			num19 = 0;
			if (num4 < 0)
			{
				num6++;
			}
			for (int num38 = num5 + 1; num38 < num6 - 1; num38++)
			{
				for (int num39 = num7 - num17; num39 < num7; num39++)
				{
					if (Main.tile[num38, num39].wall != wallType)
					{
						Main.tile[num38, num39].active = 1;
						Main.tile[num38, num39].type = (byte)tileType;
					}
				}
				num19++;
				if (num19 >= num18)
				{
					num38 += num18;
					num19 = 0;
				}
			}
			num5 = (int)((double)vector.X - num2 * 0.6);
			num6 = (int)((double)vector.X + num2 * 0.6);
			num7 = (int)((double)vector.Y - num3 * 0.6);
			num8 = (int)((double)vector.Y + num3 * 0.6);
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int num40 = num5; num40 < num6; num40++)
			{
				for (int num41 = num7; num41 < num8; num41++)
				{
					Main.tile[num40, num41].wall = 0;
				}
			}
			num5 = (int)((double)vector.X - num2 * 0.5);
			num6 = (int)((double)vector.X + num2 * 0.5);
			num7 = (int)((double)vector.Y - num3 * 0.5);
			num8 = (int)((double)vector.Y + num3 * 0.5);
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int num42 = num5; num42 < num6; num42++)
			{
				for (int num43 = num7; num43 < num8; num43++)
				{
					Main.tile[num42, num43].active = 0;
					Main.tile[num42, num43].wall = 0;
				}
			}
			for (int num44 = num5; num44 < num6; num44++)
			{
				if (Main.tile[num44, num8].active == 0)
				{
					Main.tile[num44, num8].active = 1;
					Main.tile[num44, num8].type = 19;
				}
			}
			Main.dungeonX = (short)vector.X;
			Main.dungeonY = (short)num8;
			int num45 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37);
			Main.npc[num45].homeless = false;
			Main.npc[num45].homeTileX = Main.dungeonX;
			Main.npc[num45].homeTileY = Main.dungeonY;
			if (num4 == 1)
			{
				int num46 = 0;
				for (int num47 = num6; num47 < num6 + 25; num47++)
				{
					num46++;
					for (int num48 = num8 + num46; num48 < num8 + 25; num48++)
					{
						Main.tile[num47, num48].active = 1;
						Main.tile[num47, num48].type = (byte)tileType;
					}
				}
			}
			else
			{
				int num49 = 0;
				for (int num50 = num5; num50 > num5 - 25; num50--)
				{
					num49++;
					for (int num51 = num8 + num49; num51 < num8 + 25; num51++)
					{
						Main.tile[num50, num51].active = 1;
						Main.tile[num50, num51].type = (byte)tileType;
					}
				}
			}
			num17 = 1 + genRand.Next(2);
			num18 = 2 + genRand.Next(4);
			num19 = 0;
			num5 = (int)((double)vector.X - num2 * 0.5);
			num6 = (int)((double)vector.X + num2 * 0.5);
			num5 += 2;
			num6 -= 2;
			for (int num52 = num5; num52 < num6; num52++)
			{
				for (int num53 = num7; num53 < num8; num53++)
				{
					if (Main.tile[num52, num53].wall == 0)
					{
						Main.tile[num52, num53].wall = (byte)wallType;
					}
				}
				if (++num19 >= num18)
				{
					num52 += num18 * 2;
					num19 = 0;
				}
			}
			vector.X -= (float)num2 * 0.6f * (float)num4;
			vector.Y += (float)num3 * 0.5f;
			num2 = 15.0;
			num3 = 3.0;
			vector.Y -= (float)num3 * 0.5f;
			num5 = (int)((double)vector.X - num2 * 0.5);
			num6 = (int)((double)vector.X + num2 * 0.5);
			num7 = (int)((double)vector.Y - num3 * 0.5);
			num8 = (int)((double)vector.Y + num3 * 0.5);
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num6 > Main.maxTilesX)
			{
				num6 = Main.maxTilesX;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (num8 > Main.maxTilesY)
			{
				num8 = Main.maxTilesY;
			}
			for (int num54 = num5; num54 < num6; num54++)
			{
				for (int num55 = num7; num55 < num8; num55++)
				{
					Main.tile[num54, num55].active = 0;
				}
			}
			if (num4 < 0)
			{
				vector.X -= 1f;
			}
			PlaceTile((int)vector.X, (int)vector.Y + 1, 10);
		}

		public static bool AddBuriedChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
		{
			for (int k = j; k < Main.maxTilesY; k++)
			{
				if (Main.tile[i, k].active == 0 || !Main.tileSolid[Main.tile[i, k].type])
				{
					continue;
				}
				bool flag = false;
				int num = k;
				int num2 = -1;
				int style = 0;
				if (num >= Main.worldSurface + 25 || contain > 0)
				{
					style = 1;
				}
				if (Style >= 0)
				{
					style = Style;
				}
				if (num > Main.maxTilesY - 205 && contain == 0)
				{
					if (hellChest == 0)
					{
						contain = 274;
						style = 4;
						flag = true;
					}
					else if (hellChest == 1)
					{
						contain = 220;
						style = 4;
						flag = true;
					}
					else if (hellChest == 2)
					{
						contain = 112;
						style = 4;
						flag = true;
					}
					else if (hellChest == 3)
					{
						contain = 218;
						style = 4;
						flag = true;
						hellChest = 0;
					}
				}
				num2 = PlaceChest(i - 1, num - 1, notNearOtherChests, style);
				if (num2 >= 0)
				{
					if (flag)
					{
						hellChest++;
					}
					int num3 = 0;
					do
					{
						if (num < Main.worldSurface + 25)
						{
							if (contain > 0)
							{
								Main.chest[num2].item[num3].SetDefaults(contain);
								Main.chest[num2].item[num3].Prefix(-1);
							}
							else
							{
								switch (genRand.Next(7))
								{
								case 0:
									Main.chest[num2].item[num3].SetDefaults(280);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 1:
									Main.chest[num2].item[num3].SetDefaults(281);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 2:
									Main.chest[num2].item[num3].SetDefaults(284);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 3:
									Main.chest[num2].item[num3].SetDefaults(282, genRand.Next(50, 75));
									break;
								case 4:
									Main.chest[num2].item[num3].SetDefaults(279, genRand.Next(25, 50));
									break;
								default:
									if (genRand.Next(32) == 0)
									{
										Main.chest[num2].item[num3].SetDefaults(603);
										break;
									}
									Main.chest[num2].item[num3].SetDefaults(285);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								}
							}
							num3++;
							if (genRand.Next(3) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(168, genRand.Next(3, 6));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults((genRand.Next(2) == 0) ? 20 : 22, genRand.Next(3, 11));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults((genRand.Next(2) == 0) ? 40 : 42, genRand.Next(25, 51));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(28, genRand.Next(3, 6));
								num3++;
							}
							if (genRand.Next(3) > 0)
							{
								int num4 = genRand.Next(4);
								genRand.Next(1, 3);
								switch (num4)
								{
								case 0:
									num4 = 292;
									break;
								case 1:
									num4 = 298;
									break;
								case 2:
									num4 = 299;
									break;
								default:
									num4 = 290;
									break;
								}
								Main.chest[num2].item[num3].SetDefaults(num4, genRand.Next(1, 3));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults((genRand.Next(2) == 0) ? 8 : 31, genRand.Next(10, 21));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(72, genRand.Next(10, 30));
								num3++;
							}
							continue;
						}
						if (num < Main.rockLayer)
						{
							if (contain > 0)
							{
								Main.chest[num2].item[num3].SetDefaults(contain);
								Main.chest[num2].item[num3].Prefix(-1);
								num3++;
							}
							else
							{
								int num5 = genRand.Next(7);
								if (num5 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(49);
									Main.chest[num2].item[num3].Prefix(-1);
								}
								if (num5 == 1)
								{
									Main.chest[num2].item[num3].SetDefaults(50);
									Main.chest[num2].item[num3].Prefix(-1);
								}
								if (num5 == 2)
								{
									Main.chest[num2].item[num3].SetDefaults(52);
								}
								if (num5 == 3)
								{
									Main.chest[num2].item[num3].SetDefaults(53);
									Main.chest[num2].item[num3].Prefix(-1);
								}
								if (num5 == 4)
								{
									Main.chest[num2].item[num3].SetDefaults(54);
									Main.chest[num2].item[num3].Prefix(-1);
								}
								if (num5 == 5)
								{
									Main.chest[num2].item[num3].SetDefaults(55);
									Main.chest[num2].item[num3].Prefix(-1);
								}
								if (num5 == 6)
								{
									Main.chest[num2].item[num3].SetDefaults(51);
									Main.chest[num2].item[num3].stack = (short)(genRand.Next(26) + 25);
								}
								num3++;
								if (genRand.Next(40) == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(genRand.Next(2) + 603);
									num3++;
								}
							}
							if (genRand.Next(3) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(166, genRand.Next(10, 20));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								int type = genRand.Next(21, 22);
								Main.chest[num2].item[num3].SetDefaults(type, genRand.Next(5, 15));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								int num6 = genRand.Next(2);
								int stack = genRand.Next(25, 50);
								if (num6 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(40, stack);
								}
								else
								{
									Main.chest[num2].item[num3].SetDefaults(42, stack);
								}
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(28, genRand.Next(3, 6));
								num3++;
							}
							if (genRand.Next(3) > 0)
							{
								int type2;
								switch (genRand.Next(7))
								{
								case 0:
									type2 = 289;
									break;
								case 1:
									type2 = 298;
									break;
								case 2:
									type2 = 299;
									break;
								case 3:
									type2 = 290;
									break;
								case 4:
									type2 = 303;
									break;
								case 5:
									type2 = 291;
									break;
								default:
									type2 = 304;
									break;
								}
								Main.chest[num2].item[num3].SetDefaults(type2, genRand.Next(1, 3));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(8, genRand.Next(10, 21));
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(72, genRand.Next(50, 90));
								num3++;
							}
							continue;
						}
						if (num < Main.maxTilesY - 250)
						{
							if (contain > 0)
							{
								Main.chest[num2].item[num3].SetDefaults(contain);
								Main.chest[num2].item[num3].Prefix(-1);
								num3++;
							}
							else
							{
								int num7 = genRand.Next(7);
								if (num7 == 2 && genRand.Next(2) == 0)
								{
									num7 = genRand.Next(7);
								}
								switch (num7)
								{
								case 0:
									Main.chest[num2].item[num3].SetDefaults(49);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 1:
									Main.chest[num2].item[num3].SetDefaults(50);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 2:
									Main.chest[num2].item[num3].SetDefaults(52);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 3:
									Main.chest[num2].item[num3].SetDefaults(53);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 4:
									Main.chest[num2].item[num3].SetDefaults(54);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								case 5:
									Main.chest[num2].item[num3].SetDefaults(55);
									Main.chest[num2].item[num3].Prefix(-1);
									break;
								default:
									Main.chest[num2].item[num3].SetDefaults(51, genRand.Next(26) + 25);
									break;
								}
								num3++;
							}
							if (genRand.Next(5) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(43);
								num3++;
							}
							if (genRand.Next(3) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(167);
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								int num8 = genRand.Next(2);
								int num9 = genRand.Next(8) + 3;
								if (num8 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(19);
								}
								if (num8 == 1)
								{
									Main.chest[num2].item[num3].SetDefaults(21);
								}
								Main.chest[num2].item[num3].stack = (short)num9;
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								int num10 = genRand.Next(2);
								int num11 = genRand.Next(26) + 25;
								if (num10 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(41);
								}
								if (num10 == 1)
								{
									Main.chest[num2].item[num3].SetDefaults(279);
								}
								Main.chest[num2].item[num3].stack = (short)num11;
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								int num12 = genRand.Next(1);
								int num13 = genRand.Next(3) + 3;
								if (num12 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(188);
								}
								Main.chest[num2].item[num3].stack = (short)num13;
								num3++;
							}
							if (genRand.Next(3) > 0)
							{
								int num14 = genRand.Next(6);
								int num15 = genRand.Next(1, 3);
								if (num14 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(296);
								}
								if (num14 == 1)
								{
									Main.chest[num2].item[num3].SetDefaults(295);
								}
								if (num14 == 2)
								{
									Main.chest[num2].item[num3].SetDefaults(299);
								}
								if (num14 == 3)
								{
									Main.chest[num2].item[num3].SetDefaults(302);
								}
								if (num14 == 4)
								{
									Main.chest[num2].item[num3].SetDefaults(303);
								}
								if (num14 == 5)
								{
									Main.chest[num2].item[num3].SetDefaults(305);
								}
								Main.chest[num2].item[num3].stack = (short)num15;
								num3++;
							}
							if (genRand.Next(3) > 1)
							{
								int num16 = genRand.Next(4);
								int num17 = genRand.Next(1, 3);
								if (num16 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(301);
								}
								if (num16 == 1)
								{
									Main.chest[num2].item[num3].SetDefaults(302);
								}
								if (num16 == 2)
								{
									Main.chest[num2].item[num3].SetDefaults(297);
								}
								if (num16 == 3)
								{
									Main.chest[num2].item[num3].SetDefaults(304);
								}
								Main.chest[num2].item[num3].stack = (short)num17;
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								int num18 = genRand.Next(2);
								int num19 = genRand.Next(15) + 15;
								if (num18 == 0)
								{
									Main.chest[num2].item[num3].SetDefaults(8);
								}
								if (num18 == 1)
								{
									Main.chest[num2].item[num3].SetDefaults(282);
								}
								Main.chest[num2].item[num3].stack = (short)num19;
								num3++;
							}
							if (genRand.Next(2) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(73);
								Main.chest[num2].item[num3].stack = (short)genRand.Next(1, 3);
								num3++;
							}
							if (genRand.Next(32) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(621);
							}
							else if (genRand.Next(48) == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(623);
							}
							continue;
						}
						if (contain > 0)
						{
							Main.chest[num2].item[num3].SetDefaults(contain);
							Main.chest[num2].item[num3].Prefix(-1);
							num3++;
						}
						else
						{
							switch (genRand.Next(4))
							{
							case 0:
								Main.chest[num2].item[num3].SetDefaults(49);
								Main.chest[num2].item[num3].Prefix(-1);
								break;
							case 1:
								Main.chest[num2].item[num3].SetDefaults(50);
								Main.chest[num2].item[num3].Prefix(-1);
								break;
							case 2:
								Main.chest[num2].item[num3].SetDefaults(53);
								Main.chest[num2].item[num3].Prefix(-1);
								break;
							default:
								Main.chest[num2].item[num3].SetDefaults(54);
								Main.chest[num2].item[num3].Prefix(-1);
								break;
							}
							num3++;
						}
						if (genRand.Next(3) == 0)
						{
							Main.chest[num2].item[num3].SetDefaults(167);
							num3++;
						}
						if (genRand.Next(2) == 0)
						{
							int num20 = genRand.Next(2);
							int num21 = genRand.Next(15) + 15;
							if (num20 == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(117);
							}
							if (num20 == 1)
							{
								Main.chest[num2].item[num3].SetDefaults(19);
							}
							Main.chest[num2].item[num3].stack = (short)num21;
							num3++;
						}
						if (genRand.Next(2) == 0)
						{
							int num22 = genRand.Next(2);
							int num23 = genRand.Next(25) + 50;
							if (num22 == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(265);
							}
							if (num22 == 1)
							{
								Main.chest[num2].item[num3].SetDefaults(278);
							}
							Main.chest[num2].item[num3].stack = (short)num23;
							num3++;
						}
						if (genRand.Next(2) == 0)
						{
							int num24 = genRand.Next(2);
							int num25 = genRand.Next(15) + 15;
							if (num24 == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(226);
							}
							if (num24 == 1)
							{
								Main.chest[num2].item[num3].SetDefaults(227);
							}
							Main.chest[num2].item[num3].stack = (short)num25;
							num3++;
						}
						if (genRand.Next(4) > 0)
						{
							int num26 = genRand.Next(7);
							int num27 = genRand.Next(1, 3);
							if (num26 == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(296);
							}
							if (num26 == 1)
							{
								Main.chest[num2].item[num3].SetDefaults(295);
							}
							if (num26 == 2)
							{
								Main.chest[num2].item[num3].SetDefaults(293);
							}
							if (num26 == 3)
							{
								Main.chest[num2].item[num3].SetDefaults(288);
							}
							if (num26 == 4)
							{
								Main.chest[num2].item[num3].SetDefaults(294);
							}
							if (num26 == 5)
							{
								Main.chest[num2].item[num3].SetDefaults(297);
							}
							if (num26 == 6)
							{
								Main.chest[num2].item[num3].SetDefaults(304);
							}
							Main.chest[num2].item[num3].stack = (short)num27;
							num3++;
						}
						if (genRand.Next(3) > 0)
						{
							int num28 = genRand.Next(5);
							int num29 = genRand.Next(1, 3);
							if (num28 == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(305);
							}
							if (num28 == 1)
							{
								Main.chest[num2].item[num3].SetDefaults(301);
							}
							if (num28 == 2)
							{
								Main.chest[num2].item[num3].SetDefaults(302);
							}
							if (num28 == 3)
							{
								Main.chest[num2].item[num3].SetDefaults(288);
							}
							if (num28 == 4)
							{
								Main.chest[num2].item[num3].SetDefaults(300);
							}
							Main.chest[num2].item[num3].stack = (short)num29;
							num3++;
						}
						if (genRand.Next(2) == 0)
						{
							int num30 = genRand.Next(2);
							int num31 = genRand.Next(15) + 15;
							if (num30 == 0)
							{
								Main.chest[num2].item[num3].SetDefaults(8);
							}
							if (num30 == 1)
							{
								Main.chest[num2].item[num3].SetDefaults(282);
							}
							Main.chest[num2].item[num3].stack = (short)num31;
							num3++;
						}
						else if (genRand.Next(48) == 0)
						{
							Main.chest[num2].item[num3].SetDefaults(625);
							num3++;
						}
						if (genRand.Next(2) == 0)
						{
							Main.chest[num2].item[num3].SetDefaults(73);
							Main.chest[num2].item[num3].stack = (short)genRand.Next(2, 5);
							num3++;
						}
					}
					while (num3 == 0);
					return true;
				}
				return false;
			}
			return false;
		}

		public static int OpenDoor(int i, int j, int direction)
		{
			if (!DoOpenDoor(i, j, direction))
			{
				direction = -direction;
				if (!DoOpenDoor(i, j, direction))
				{
					direction = 0;
				}
			}
			return direction;
		}

		public static bool CanOpenDoor(int i, int j)
		{
			bool flag = DoCanOpenDoor(i, j, 1);
			if (!flag)
			{
				flag = DoCanOpenDoor(i, j, -1);
			}
			return flag;
		}

		private static bool DoCanOpenDoor(int i, int j, int direction)
		{
			if (Main.tile[i, j - 1].frameY == 0 && Main.tile[i, j - 1].type == Main.tile[i, j].type)
			{
				j--;
			}
			else if (Main.tile[i, j - 2].frameY == 0 && Main.tile[i, j - 2].type == Main.tile[i, j].type)
			{
				j -= 2;
			}
			else if (Main.tile[i, j + 1].frameY == 0 && Main.tile[i, j + 1].type == Main.tile[i, j].type)
			{
				j++;
			}
			i += direction;
			for (int k = j; k < j + 3; k++)
			{
				if (Main.tile[i, k].active != 0)
				{
					int type = Main.tile[i, k].type;
					if (!Main.tileCut[type] && type != 3 && type != 24 && type != 52 && type != 61 && type != 62 && type != 69 && type != 71 && type != 73 && type != 74 && type != 110 && type != 113 && type != 115)
					{
						return false;
					}
				}
			}
			return true;
		}

		private static bool DoOpenDoor(int i, int j, int direction)
		{
			int num = j;
			if (Main.tile[i, j - 1].frameY == 0 && Main.tile[i, j - 1].type == Main.tile[i, j].type)
			{
				num--;
			}
			else if (Main.tile[i, j - 2].frameY == 0 && Main.tile[i, j - 2].type == Main.tile[i, j].type)
			{
				num -= 2;
			}
			else if (Main.tile[i, j + 1].frameY == 0 && Main.tile[i, j + 1].type == Main.tile[i, j].type)
			{
				num++;
			}
			int num2 = i;
			int num3 = i;
			int num4;
			if (direction == -1)
			{
				num2--;
				num3--;
				num4 = 36;
			}
			else
			{
				num3++;
				num4 = 0;
			}
			bool flag = true;
			for (int k = num; k < num + 3; k++)
			{
				if (Main.tile[num3, k].active != 0)
				{
					int type = Main.tile[num3, k].type;
					if (!Main.tileCut[type] && type != 3 && type != 24 && type != 52 && type != 61 && type != 62 && type != 69 && type != 71 && type != 73 && type != 74 && type != 110 && type != 113 && type != 115)
					{
						flag = false;
						break;
					}
					KillTile(num3, k);
				}
			}
			if (flag)
			{
				if (Main.netMode != 1)
				{
					for (int l = num2; l <= num2 + 1; l++)
					{
						for (int m = num; m <= num + 2; m++)
						{
							if (numNoWire < 999)
							{
								noWire[numNoWire].X = (short)l;
								noWire[numNoWire].Y = (short)m;
								numNoWire++;
							}
						}
					}
				}
				Main.PlaySound(8, i * 16, j * 16);
				Main.tile[num2, num].active = 1;
				Main.tile[num2, num].type = 11;
				Main.tile[num2, num].frameY = 0;
				Main.tile[num2, num].frameX = (short)num4;
				Main.tile[num2 + 1, num].active = 1;
				Main.tile[num2 + 1, num].type = 11;
				Main.tile[num2 + 1, num].frameY = 0;
				Main.tile[num2 + 1, num].frameX = (short)(num4 + 18);
				Main.tile[num2, num + 1].active = 1;
				Main.tile[num2, num + 1].type = 11;
				Main.tile[num2, num + 1].frameY = 18;
				Main.tile[num2, num + 1].frameX = (short)num4;
				Main.tile[num2 + 1, num + 1].active = 1;
				Main.tile[num2 + 1, num + 1].type = 11;
				Main.tile[num2 + 1, num + 1].frameY = 18;
				Main.tile[num2 + 1, num + 1].frameX = (short)(num4 + 18);
				Main.tile[num2, num + 2].active = 1;
				Main.tile[num2, num + 2].type = 11;
				Main.tile[num2, num + 2].frameY = 36;
				Main.tile[num2, num + 2].frameX = (short)num4;
				Main.tile[num2 + 1, num + 2].active = 1;
				Main.tile[num2 + 1, num + 2].type = 11;
				Main.tile[num2 + 1, num + 2].frameY = 36;
				Main.tile[num2 + 1, num + 2].frameX = (short)(num4 + 18);
				bool flag2 = tileFrameRecursion;
				tileFrameRecursion = false;
				for (int n = num2 - 1; n <= num2 + 2; n++)
				{
					for (int num5 = num - 1; num5 <= num + 2; num5++)
					{
						TileFrame(n, num5);
					}
				}
				tileFrameRecursion = flag2;
			}
			return flag;
		}

		public static void Check1xX(int x, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = j - Main.tile[x, j].frameY / 18;
			int frameX = Main.tile[x, j].frameX;
			int num2 = 3;
			if (type == 92)
			{
				num2 = 6;
			}
			int num3 = 0;
			while (true)
			{
				if (num3 < num2)
				{
					if (Main.tile[x, num + num3].active == 0 || Main.tile[x, num + num3].type != type || Main.tile[x, num + num3].frameY != num3 * 18 || Main.tile[x, num + num3].frameX != frameX)
					{
						break;
					}
					num3++;
					continue;
				}
				if (Main.tile[x, num + num2].active == 0 || !Main.tileSolid[Main.tile[x, num + num2].type])
				{
					break;
				}
				return;
			}
			destroyObject = true;
			for (int i = 0; i < num2; i++)
			{
				if (Main.tile[x, num + i].type == type)
				{
					KillTile(x, num + i);
				}
			}
			if (!gen)
			{
				switch (type)
				{
				case 92:
					Item.NewItem(x * 16, j * 16, 32, 32, 341);
					break;
				case 93:
					Item.NewItem(x * 16, j * 16, 32, 32, 342);
					break;
				}
			}
			destroyObject = false;
		}

		public static void Check2xX(int i, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = Main.tile[i, j].frameX % 36;
			if (num2 == 18)
			{
				num--;
			}
			int num3 = j - Main.tile[num, j].frameY / 18;
			int frameX = Main.tile[num, j].frameX;
			int num4 = 3;
			if (type == 104)
			{
				num4 = 5;
			}
			int num5 = 0;
			while (true)
			{
				if (num5 < num4)
				{
					if (Main.tile[num, num3 + num5].active == 0 || Main.tile[num, num3 + num5].type != type || Main.tile[num, num3 + num5].frameY != num5 * 18 || Main.tile[num, num3 + num5].frameX != frameX || Main.tile[num + 1, num3 + num5].active == 0 || Main.tile[num + 1, num3 + num5].type != type || Main.tile[num + 1, num3 + num5].frameY != num5 * 18 || Main.tile[num + 1, num3 + num5].frameX != frameX + 18)
					{
						break;
					}
					num5++;
					continue;
				}
				if (Main.tile[num, num3 + num4].active == 0 || !Main.tileSolid[Main.tile[num, num3 + num4].type] || Main.tile[num + 1, num3 + num4].active == 0 || !Main.tileSolid[Main.tile[num + 1, num3 + num4].type])
				{
					break;
				}
				return;
			}
			destroyObject = true;
			for (int k = 0; k < num4; k++)
			{
				if (Main.tile[num, num3 + k].type == type)
				{
					KillTile(num, num3 + k);
				}
				if (Main.tile[num + 1, num3 + k].type == type)
				{
					KillTile(num + 1, num3 + k);
				}
			}
			if (!gen)
			{
				switch (type)
				{
				case 104:
					Item.NewItem(num * 16, j * 16, 32, 32, 359);
					break;
				case 105:
				{
					int num6 = frameX / 36;
					switch (num6)
					{
					case 0:
						num6 = 360;
						break;
					case 1:
						num6 = 52;
						break;
					default:
						num6 = 438 + num6 - 2;
						break;
					}
					Item.NewItem(num * 16, j * 16, 32, 32, num6);
					break;
				}
				}
			}
			destroyObject = false;
		}

		public static bool Place1xX(int x, int y, int type, int style = 0)
		{
			int num = style * 18;
			int num2 = 3;
			if (type == 92)
			{
				num2 = 6;
			}
			for (int i = y - num2 + 1; i < y + 1; i++)
			{
				if (Main.tile[x, i].active != 0 || (type == 93 && Main.tile[x, i].liquid > 0))
				{
					return false;
				}
			}
			if (Main.tile[x, y + 1].active != 0 && Main.tileSolid[Main.tile[x, y + 1].type])
			{
				for (int j = 0; j < num2; j++)
				{
					Main.tile[x, y - num2 + 1 + j].active = 1;
					Main.tile[x, y - num2 + 1 + j].frameY = (short)(j * 18);
					Main.tile[x, y - num2 + 1 + j].frameX = (short)num;
					Main.tile[x, y - num2 + 1 + j].type = (byte)type;
				}
				return true;
			}
			return false;
		}

		public static bool Place2xX(int x, int y, int type, int style = 0)
		{
			int num = style * 36;
			int num2 = 3;
			if (type == 104)
			{
				num2 = 5;
			}
			for (int i = y - num2 + 1; i < y + 1; i++)
			{
				if (Main.tile[x, i].active != 0 || Main.tile[x + 1, i].active != 0)
				{
					return false;
				}
			}
			if (Main.tile[x, y + 1].active != 0 && Main.tileSolid[Main.tile[x, y + 1].type] && Main.tile[x + 1, y + 1].active != 0 && Main.tileSolid[Main.tile[x + 1, y + 1].type])
			{
				for (int j = 0; j < num2; j++)
				{
					Main.tile[x, y - num2 + 1 + j].active = 1;
					Main.tile[x, y - num2 + 1 + j].frameY = (short)(j * 18);
					Main.tile[x, y - num2 + 1 + j].frameX = (short)num;
					Main.tile[x, y - num2 + 1 + j].type = (byte)type;
					Main.tile[x + 1, y - num2 + 1 + j].active = 1;
					Main.tile[x + 1, y - num2 + 1 + j].frameY = (short)(j * 18);
					Main.tile[x + 1, y - num2 + 1 + j].frameX = (short)(num + 18);
					Main.tile[x + 1, y - num2 + 1 + j].type = (byte)type;
				}
				return true;
			}
			return false;
		}

		public static void Check1x2(int x, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = j;
			bool flag = true;
			int frameY = Main.tile[x, num].frameY;
			int num2 = frameY / 40;
			frameY %= 40;
			if (frameY == 18)
			{
				num--;
			}
			if (Main.tile[x, num].frameY == 40 * num2 && Main.tile[x, num + 1].frameY == 40 * num2 + 18 && Main.tile[x, num].type == type && Main.tile[x, num + 1].type == type)
			{
				flag = false;
			}
			if (Main.tile[x, num + 2].active == 0 || !Main.tileSolid[Main.tile[x, num + 2].type])
			{
				flag = true;
			}
			if (Main.tile[x, num + 2].type != 2 && Main.tile[x, num + 2].type != 109 && Main.tile[x, num + 2].type != 147 && Main.tile[x, num].type == 20)
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			destroyObject = true;
			if (Main.tile[x, num].type == type)
			{
				KillTile(x, num);
			}
			if (Main.tile[x, num + 1].type == type)
			{
				KillTile(x, num + 1);
			}
			if (!gen)
			{
				switch (type)
				{
				case 15:
					if (num2 == 1)
					{
						Item.NewItem(x * 16, num * 16, 32, 32, 358);
					}
					else
					{
						Item.NewItem(x * 16, num * 16, 32, 32, 34);
					}
					break;
				case 134:
					Item.NewItem(x * 16, num * 16, 32, 32, 525);
					break;
				}
			}
			destroyObject = false;
		}

		public static void CheckOnTableClaypot(int x, int y)
		{
			if ((Main.tile[x, y + 1].active == 0 || !Main.tileTable[Main.tile[x, y + 1].type]) && (Main.tile[x, y + 1].active == 0 || !Main.tileSolid[Main.tile[x, y + 1].type]))
			{
				KillTile(x, y);
			}
		}

		public static void CheckOnTable1x1(int x, int y)
		{
			if (Main.tile[x, y + 1].active == 0 || !Main.tileTable[Main.tile[x, y + 1].type])
			{
				KillTile(x, y);
			}
		}

		public static void CheckSign(int x, int y, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = x - 2;
			int num2 = x + 3;
			int num3 = y - 2;
			int num4 = y + 3;
			if (num < 0 || num2 > Main.maxTilesX || num3 < 0 || num4 > Main.maxTilesY)
			{
				return;
			}
			bool flag = false;
			int num5 = (Main.tile[x, y].frameX / 18) & 1;
			int num6 = Main.tile[x, y].frameY / 18;
			int num7 = x - num5;
			int num8 = y - num6;
			int num9 = Main.tile[num7, num8].frameX / 36;
			num = num7;
			num2 = num7 + 2;
			num3 = num8;
			num4 = num8 + 2;
			num5 = 0;
			for (int i = num; i < num2; i++)
			{
				num6 = 0;
				for (int j = num3; j < num4; j++)
				{
					if (Main.tile[i, j].active == 0 || Main.tile[i, j].type != type)
					{
						flag = true;
						break;
					}
					if (Main.tile[i, j].frameX / 18 != num5 + num9 * 2 || Main.tile[i, j].frameY / 18 != num6)
					{
						flag = true;
						break;
					}
					num6++;
				}
				num5++;
			}
			if (!flag)
			{
				if (type == 85)
				{
					if (Main.tile[num7, num8 + 2].active != 0 && Main.tileSolid[Main.tile[num7, num8 + 2].type] && Main.tile[num7 + 1, num8 + 2].active != 0 && Main.tileSolid[Main.tile[num7 + 1, num8 + 2].type])
					{
						num9 = 0;
					}
					else
					{
						flag = true;
					}
				}
				else if (Main.tile[num7, num8 + 2].active != 0 && Main.tileSolid[Main.tile[num7, num8 + 2].type] && Main.tile[num7 + 1, num8 + 2].active != 0 && Main.tileSolid[Main.tile[num7 + 1, num8 + 2].type])
				{
					num9 = 0;
				}
				else if (Main.tile[num7, num8 - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num7, num8 - 1].type] && Main.tile[num7 + 1, num8 - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num7 + 1, num8 - 1].type])
				{
					num9 = 1;
				}
				else if (Main.tile[num7 - 1, num8].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num7 - 1, num8].type] && Main.tile[num7 - 1, num8 + 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num7 - 1, num8 + 1].type])
				{
					num9 = 2;
				}
				else if (Main.tile[num7 + 2, num8].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num7 + 2, num8].type] && Main.tile[num7 + 2, num8 + 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num7 + 2, num8 + 1].type])
				{
					num9 = 3;
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				destroyObject = true;
				for (int k = num; k < num2; k++)
				{
					for (int l = num3; l < num4; l++)
					{
						if (Main.tile[k, l].type == type)
						{
							KillTile(k, l);
						}
					}
				}
				Sign.KillSign(num7, num8);
				if (!gen)
				{
					if (type == 85)
					{
						Item.NewItem(x * 16, y * 16, 32, 32, 321);
					}
					else
					{
						Item.NewItem(x * 16, y * 16, 32, 32, 171);
					}
				}
				destroyObject = false;
				return;
			}
			int num10 = 36 * num9;
			for (int m = 0; m < 2; m++)
			{
				for (int n = 0; n < 2; n++)
				{
					Main.tile[num7 + m, num8 + n].active = 1;
					Main.tile[num7 + m, num8 + n].type = (byte)type;
					Main.tile[num7 + m, num8 + n].frameX = (short)(num10 + 18 * m);
					Main.tile[num7 + m, num8 + n].frameY = (short)(18 * n);
				}
			}
		}

		public static bool PlaceSign(int x, int y, int type)
		{
			int num = x - 2;
			int num2 = x + 3;
			int num3 = y - 2;
			int num4 = y + 3;
			if (num < 0)
			{
				return false;
			}
			if (num2 > Main.maxTilesX)
			{
				return false;
			}
			if (num3 < 0)
			{
				return false;
			}
			if (num4 > Main.maxTilesY)
			{
				return false;
			}
			int num5 = x;
			int num6 = y;
			int num7 = 0;
			switch (type)
			{
			case 55:
				if (Main.tile[x, y + 1].active != 0 && Main.tileSolid[Main.tile[x, y + 1].type] && Main.tile[x + 1, y + 1].active != 0 && Main.tileSolid[Main.tile[x + 1, y + 1].type])
				{
					num6--;
					num7 = 0;
					break;
				}
				if (Main.tile[x, y - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x, y - 1].type] && Main.tile[x + 1, y - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x + 1, y - 1].type])
				{
					num7 = 1;
					break;
				}
				if (Main.tile[x - 1, y].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x - 1, y].type] && !Main.tileNoAttach[Main.tile[x - 1, y].type] && Main.tile[x - 1, y + 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x - 1, y + 1].type] && !Main.tileNoAttach[Main.tile[x - 1, y + 1].type])
				{
					num7 = 2;
					break;
				}
				if (Main.tile[x + 1, y].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x + 1, y].type] && !Main.tileNoAttach[Main.tile[x + 1, y].type] && Main.tile[x + 1, y + 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x + 1, y + 1].type] && !Main.tileNoAttach[Main.tile[x + 1, y + 1].type])
				{
					num5--;
					num7 = 3;
					break;
				}
				return false;
			case 85:
				if (Main.tile[x, y + 1].active != 0 && Main.tileSolid[Main.tile[x, y + 1].type] && Main.tile[x + 1, y + 1].active != 0 && Main.tileSolid[Main.tile[x + 1, y + 1].type])
				{
					num6--;
					num7 = 0;
					break;
				}
				return false;
			}
			if (Main.tile[num5, num6].active != 0 || Main.tile[num5 + 1, num6].active != 0 || Main.tile[num5, num6 + 1].active != 0 || Main.tile[num5 + 1, num6 + 1].active != 0)
			{
				return false;
			}
			int num8 = 36 * num7;
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					Main.tile[num5 + i, num6 + j].active = 1;
					Main.tile[num5 + i, num6 + j].type = (byte)type;
					Main.tile[num5 + i, num6 + j].frameX = (short)(num8 + 18 * i);
					Main.tile[num5 + i, num6 + j].frameY = (short)(18 * j);
				}
			}
			return true;
		}

		public static bool Place1x1(int x, int y, int type, int style = 0)
		{
			if (Main.tile[x, y].active == 0 && SolidTileUnsafe(x, y + 1))
			{
				Main.tile[x, y].active = 1;
				Main.tile[x, y].type = (byte)type;
				if (type == 144)
				{
					Main.tile[x, y].frameX = (short)(style * 18);
					Main.tile[x, y].frameY = 0;
				}
				else
				{
					Main.tile[x, y].frameY = (short)(style * 18);
				}
				return true;
			}
			return false;
		}

		public static void Check1x1(int x, int y, int type)
		{
			if (Main.tile[x, y + 1].active == 0 || !Main.tileSolid[Main.tile[x, y + 1].type])
			{
				KillTile(x, y);
			}
		}

		public static bool PlaceOnTable1x1(int x, int y, int type, int style = 0)
		{
			if (Main.tile[x, y].active != 0 || Main.tile[x, y + 1].active == 0 || !Main.tileTable[Main.tile[x, y + 1].type])
			{
				return false;
			}
			if (type == 78 && (Main.tile[x, y].active != 0 || Main.tile[x, y + 1].active == 0 || !Main.tileSolid[Main.tile[x, y + 1].type]))
			{
				return false;
			}
			Main.tile[x, y].active = 1;
			Main.tile[x, y].frameX = (short)(style * 18);
			Main.tile[x, y].frameY = 0;
			Main.tile[x, y].type = (byte)type;
			if (type == 50)
			{
				Main.tile[x, y].frameX = (short)(18 * genRand.Next(5));
			}
			return true;
		}

		public static bool PlaceAlch(int x, int y, int style)
		{
			if (Main.tile[x, y].active == 0 && Main.tile[x, y + 1].active != 0)
			{
				bool flag = false;
				switch (style)
				{
				case 0:
					if (Main.tile[x, y + 1].type != 2 && Main.tile[x, y + 1].type != 78 && Main.tile[x, y + 1].type != 109)
					{
						flag = true;
					}
					if (Main.tile[x, y].liquid > 0)
					{
						flag = true;
					}
					break;
				case 1:
					if (Main.tile[x, y + 1].type != 60 && Main.tile[x, y + 1].type != 78)
					{
						flag = true;
					}
					if (Main.tile[x, y].liquid > 0)
					{
						flag = true;
					}
					break;
				case 2:
					if (Main.tile[x, y + 1].type != 0 && Main.tile[x, y + 1].type != 59 && Main.tile[x, y + 1].type != 78)
					{
						flag = true;
					}
					if (Main.tile[x, y].liquid > 0)
					{
						flag = true;
					}
					break;
				case 3:
					if (Main.tile[x, y + 1].type != 23 && Main.tile[x, y + 1].type != 25 && Main.tile[x, y + 1].type != 78)
					{
						flag = true;
					}
					if (Main.tile[x, y].liquid > 0)
					{
						flag = true;
					}
					break;
				case 4:
					if (Main.tile[x, y + 1].type != 53 && Main.tile[x, y + 1].type != 78 && Main.tile[x, y + 1].type != 116)
					{
						flag = true;
					}
					if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava != 0)
					{
						flag = true;
					}
					break;
				case 5:
					if (Main.tile[x, y + 1].type != 57 && Main.tile[x, y + 1].type != 78)
					{
						flag = true;
					}
					if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava == 0)
					{
						flag = true;
					}
					break;
				}
				if (!flag)
				{
					Main.tile[x, y].active = 1;
					Main.tile[x, y].type = 82;
					Main.tile[x, y].frameX = (short)(18 * style);
					Main.tile[x, y].frameY = 0;
					return true;
				}
			}
			return false;
		}

		public static void GrowAlch(int x, int y)
		{
			if (Main.tile[x, y].active == 0)
			{
				return;
			}
			if (Main.tile[x, y].type == 82 && genRand.Next(50) == 0)
			{
				Main.tile[x, y].type = 83;
				SquareTileFrame(x, y);
				if (Main.netMode == 2)
				{
					NetMessage.SendTile(x, y);
				}
			}
			else if (Main.tile[x, y].frameX == 36)
			{
				if (Main.tile[x, y].type == 83)
				{
					Main.tile[x, y].type = 84;
				}
				else
				{
					Main.tile[x, y].type = 83;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendTile(x, y);
				}
			}
		}

		public static void PlantAlch()
		{
			int num = genRand.Next(20, Main.maxTilesX - 20);
			int i;
			switch (genRand.Next(40))
			{
			case 0:
				i = genRand.Next(Main.rockLayer + Main.maxTilesY >> 1, Main.maxTilesY - 20);
				break;
			case 1:
			case 2:
			case 3:
			case 4:
				i = genRand.Next(Main.maxTilesY - 20);
				break;
			default:
				i = genRand.Next(Main.worldSurface, Main.maxTilesY - 20);
				break;
			}
			for (; i < Main.maxTilesY - 20 && Main.tile[num, i].active == 0; i++)
			{
			}
			if (Main.tile[num, i].active != 0 && Main.tile[num, i - 1].active == 0 && Main.tile[num, i - 1].liquid == 0)
			{
				int num2 = -1;
				switch (Main.tile[num, i].type)
				{
				case 2:
				case 109:
					num2 = 0;
					break;
				case 60:
					num2 = 1;
					break;
				case 0:
				case 59:
					num2 = 2;
					break;
				case 23:
				case 25:
					num2 = 3;
					break;
				case 53:
				case 116:
					num2 = 4;
					break;
				case 57:
					num2 = 5;
					break;
				}
				if (num2 >= 0 && PlaceAlch(num, i - 1, num2) && Main.netMode == 2)
				{
					NetMessage.SendTile(num, i - 1);
				}
			}
		}

		public static void CheckAlch(int x, int y)
		{
			bool flag = Main.tile[x, y + 1].active == 0;
			Main.tile[x, y].frameY = 0;
			if (!flag)
			{
				int num = Main.tile[x, y].frameX / 18;
				int type = Main.tile[x, y + 1].type;
				switch (num)
				{
				case 0:
					if (type != 109 && type != 2 && type != 78)
					{
						flag = true;
					}
					else if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava != 0)
					{
						flag = true;
					}
					break;
				case 1:
					if (type != 60 && type != 78)
					{
						flag = true;
					}
					else if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava != 0)
					{
						flag = true;
					}
					break;
				case 2:
					if (type != 0 && type != 59 && type != 78)
					{
						flag = true;
					}
					else if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava != 0)
					{
						flag = true;
					}
					break;
				case 3:
					if (type != 23 && type != 25 && type != 78)
					{
						flag = true;
					}
					else if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava != 0)
					{
						flag = true;
					}
					break;
				default:
				{
					int type2 = Main.tile[x, y].type;
					switch (num)
					{
					case 4:
						if (type != 53 && type != 78 && type != 116)
						{
							flag = true;
						}
						else if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava != 0)
						{
							flag = true;
						}
						if (type2 == 82 || Main.tile[x, y].lava != 0 || Main.netMode == 1)
						{
							break;
						}
						if (Main.tile[x, y].liquid > 16)
						{
							if (type2 == 83)
							{
								Main.tile[x, y].type = 84;
								if (Main.netMode == 2)
								{
									NetMessage.SendTile(x, y);
								}
							}
						}
						else if (type2 == 84)
						{
							Main.tile[x, y].type = 83;
							if (Main.netMode == 2)
							{
								NetMessage.SendTile(x, y);
							}
						}
						break;
					case 5:
						if (type != 57 && type != 78)
						{
							flag = true;
						}
						else if (Main.tile[x, y].liquid > 0 && Main.tile[x, y].lava == 0)
						{
							flag = true;
						}
						if (Main.netMode == 1 || type2 == 82 || Main.tile[x, y].lava == 0)
						{
							break;
						}
						if (Main.tile[x, y].liquid > 16)
						{
							if (type2 == 83)
							{
								Main.tile[x, y].type = 84;
								if (Main.netMode == 2)
								{
									NetMessage.SendTile(x, y);
								}
							}
						}
						else if (type2 == 84)
						{
							Main.tile[x, y].type = 83;
							if (Main.netMode == 2)
							{
								NetMessage.SendTile(x, y);
							}
						}
						break;
					}
					break;
				}
				}
			}
			if (flag)
			{
				KillTile(x, y);
			}
		}

		public static void CheckBanner(int x, int j)
		{
			if (destroyObject)
			{
				return;
			}
			int num = j - Main.tile[x, j].frameY / 18;
			int frameX = Main.tile[x, j].frameX;
			bool flag = false;
			for (int i = 0; i < 3; i++)
			{
				if (Main.tile[x, num + i].active == 0)
				{
					flag = true;
					break;
				}
				if (Main.tile[x, num + i].type != 91)
				{
					flag = true;
					break;
				}
				if (Main.tile[x, num + i].frameY != i * 18)
				{
					flag = true;
					break;
				}
				if (Main.tile[x, num + i].frameX != frameX)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				flag = (Main.tile[x, num - 1].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[x, num - 1].type]);
			}
			if (!flag)
			{
				return;
			}
			destroyObject = true;
			for (int k = 0; k < 3; k++)
			{
				if (Main.tile[x, num + k].type == 91)
				{
					KillTile(x, num + k);
				}
			}
			if (!gen)
			{
				Item.NewItem(x * 16, (num + 1) * 16, 32, 32, 337 + frameX / 18);
			}
			destroyObject = false;
		}

		public static bool PlaceBanner(int x, int y, int type, int style = 0)
		{
			int num = style * 18;
			if (Main.tile[x, y - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x, y - 1].type] && Main.tile[x, y].active == 0 && Main.tile[x, y + 1].active == 0 && Main.tile[x, y + 2].active == 0)
			{
				Main.tile[x, y].active = 1;
				Main.tile[x, y].frameY = 0;
				Main.tile[x, y].frameX = (short)num;
				Main.tile[x, y].type = (byte)type;
				Main.tile[x, y + 1].active = 1;
				Main.tile[x, y + 1].frameY = 18;
				Main.tile[x, y + 1].frameX = (short)num;
				Main.tile[x, y + 1].type = (byte)type;
				Main.tile[x, y + 2].active = 1;
				Main.tile[x, y + 2].frameY = 36;
				Main.tile[x, y + 2].frameX = (short)num;
				Main.tile[x, y + 2].type = (byte)type;
				return true;
			}
			return false;
		}

		public static bool PlaceMan(int i, int j, int dir)
		{
			for (int k = i; k <= i + 1; k++)
			{
				for (int l = j - 2; l <= j; l++)
				{
					if (Main.tile[k, l].active != 0)
					{
						return false;
					}
				}
			}
			if (!SolidTileUnsafe(i, j + 1) || !SolidTileUnsafe(i + 1, j + 1))
			{
				return false;
			}
			int num = (dir == 1) ? 36 : 0;
			Main.tile[i, j - 2].active = 1;
			Main.tile[i, j - 2].frameY = 0;
			Main.tile[i, j - 2].frameX = (byte)num;
			Main.tile[i, j - 2].type = 128;
			Main.tile[i, j - 1].active = 1;
			Main.tile[i, j - 1].frameY = 18;
			Main.tile[i, j - 1].frameX = (byte)num;
			Main.tile[i, j - 1].type = 128;
			Main.tile[i, j].active = 1;
			Main.tile[i, j].frameY = 36;
			Main.tile[i, j].frameX = (byte)num;
			Main.tile[i, j].type = 128;
			Main.tile[i + 1, j - 2].active = 1;
			Main.tile[i + 1, j - 2].frameY = 0;
			Main.tile[i + 1, j - 2].frameX = (byte)(18 + num);
			Main.tile[i + 1, j - 2].type = 128;
			Main.tile[i + 1, j - 1].active = 1;
			Main.tile[i + 1, j - 1].frameY = 18;
			Main.tile[i + 1, j - 1].frameX = (byte)(18 + num);
			Main.tile[i + 1, j - 1].type = 128;
			Main.tile[i + 1, j].active = 1;
			Main.tile[i + 1, j].frameY = 36;
			Main.tile[i + 1, j].frameX = (byte)(18 + num);
			Main.tile[i + 1, j].type = 128;
			return true;
		}

		public static void CheckMan(int i, int j)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j - Main.tile[i, j].frameY / 18;
			int num3 = Main.tile[i, j].frameX % 100 % 36;
			num -= num3 / 18;
			bool flag = false;
			for (int k = 0; k <= 1; k++)
			{
				for (int l = 0; l <= 2; l++)
				{
					int num4 = num + k;
					int num5 = num2 + l;
					int num6 = Main.tile[num4, num5].frameX % 100;
					if (num6 >= 36)
					{
						num6 -= 36;
					}
					if (Main.tile[num4, num5].active == 0 || Main.tile[num4, num5].type != 128 || Main.tile[num4, num5].frameY != l * 18 || num6 != k * 18)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag && SolidTileUnsafe(num, num2 + 3) && SolidTileUnsafe(num + 1, num2 + 3))
			{
				return;
			}
			destroyObject = true;
			for (int m = 0; m <= 1; m++)
			{
				for (int n = 0; n <= 2; n++)
				{
					int num7 = num + m;
					int num8 = num2 + n;
					if (Main.tile[num7, num8].active != 0 && Main.tile[num7, num8].type == 128)
					{
						KillTile(num7, num8);
					}
				}
			}
			if (!gen)
			{
				Item.NewItem(i * 16, j * 16, 32, 32, 498);
			}
			destroyObject = false;
		}

		public static bool Place1x2(int x, int y, int type, int style)
		{
			if (Main.tile[x, y + 1].active != 0 && Main.tileSolid[Main.tile[x, y + 1].type] && Main.tile[x, y - 1].active == 0)
			{
				int num = (type == 20) ? (genRand.Next(3) * 18) : 0;
				int num2 = style * 40;
				Main.tile[x, y - 1].active = 1;
				Main.tile[x, y - 1].frameY = (short)num2;
				Main.tile[x, y - 1].frameX = (short)num;
				Main.tile[x, y - 1].type = (byte)type;
				Main.tile[x, y].active = 1;
				Main.tile[x, y].frameY = (short)(num2 + 18);
				Main.tile[x, y].frameX = (short)num;
				Main.tile[x, y].type = (byte)type;
				return true;
			}
			return false;
		}

		public static bool Place1x2Top(int x, int y, int type)
		{
			if (Main.tile[x, y - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[x, y - 1].type] && Main.tile[x, y + 1].active == 0)
			{
				Main.tile[x, y].active = 1;
				Main.tile[x, y].frameY = 0;
				Main.tile[x, y].frameX = 0;
				Main.tile[x, y].type = (byte)type;
				Main.tile[x, y + 1].active = 1;
				Main.tile[x, y + 1].frameY = 18;
				Main.tile[x, y + 1].frameX = 0;
				Main.tile[x, y + 1].type = (byte)type;
				return true;
			}
			return false;
		}

		public static void Check1x2Top(int x, int j)
		{
			if (destroyObject)
			{
				return;
			}
			int num = j;
			if (Main.tile[x, num].frameY == 18)
			{
				num--;
			}
			if (Main.tile[x, num].frameY != 0 || Main.tile[x, num + 1].frameY != 18 || Main.tile[x, num].type != 42 || Main.tile[x, num + 1].type != 42 || Main.tile[x, num - 1].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[x, num - 1].type])
			{
				destroyObject = true;
				if (Main.tile[x, num].type == 42)
				{
					KillTile(x, num);
				}
				if (Main.tile[x, num + 1].type == 42)
				{
					KillTile(x, num + 1);
				}
				if (!gen)
				{
					Item.NewItem(x * 16, num * 16, 32, 32, 136);
				}
				destroyObject = false;
			}
		}

		public static void Check2x1(int i, int y, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			if (Main.tile[num, y].frameX == 18)
			{
				num--;
			}
			if (Main.tile[num, y].frameX == 0 && Main.tile[num + 1, y].frameX == 18 && Main.tile[num, y].type == type && Main.tile[num + 1, y].type == type)
			{
				if (type == 29 || type == 103)
				{
					if (Main.tile[num, y + 1].active != 0 && Main.tileTable[Main.tile[num, y + 1].type] && Main.tile[num + 1, y + 1].active != 0 && Main.tileTable[Main.tile[num + 1, y + 1].type])
					{
						return;
					}
				}
				else if (Main.tile[num, y + 1].active != 0 && Main.tileSolid[Main.tile[num, y + 1].type] && Main.tile[num + 1, y + 1].active != 0 && Main.tileSolid[Main.tile[num + 1, y + 1].type])
				{
					return;
				}
			}
			destroyObject = true;
			if (Main.tile[num, y].type == type)
			{
				KillTile(num, y);
			}
			if (Main.tile[num + 1, y].type == type)
			{
				KillTile(num + 1, y);
			}
			if (!gen)
			{
				switch (type)
				{
				case 16:
					Item.NewItem(num * 16, y * 16, 32, 32, 35);
					break;
				case 18:
					Item.NewItem(num * 16, y * 16, 32, 32, 36);
					break;
				case 29:
					Item.NewItem(num * 16, y * 16, 32, 32, 87);
					Main.PlaySound(13, i * 16, y * 16);
					break;
				case 103:
					Item.NewItem(num * 16, y * 16, 32, 32, 356);
					Main.PlaySound(13, i * 16, y * 16);
					break;
				case 134:
					Item.NewItem(num * 16, y * 16, 32, 32, 525);
					break;
				}
			}
			destroyObject = false;
			SquareTileFrame(num, y);
			SquareTileFrame(num + 1, y);
		}

		public static bool Place2x1(int x, int y, int type)
		{
			if ((type == 29 || type == 103 || Main.tile[x, y + 1].active == 0 || Main.tile[x + 1, y + 1].active == 0 || !Main.tileSolid[Main.tile[x, y + 1].type] || !Main.tileSolid[Main.tile[x + 1, y + 1].type] || Main.tile[x, y].active != 0 || Main.tile[x + 1, y].active != 0) && ((type != 29 && type != 103) || Main.tile[x, y + 1].active == 0 || Main.tile[x + 1, y + 1].active == 0 || !Main.tileTable[Main.tile[x, y + 1].type] || !Main.tileTable[Main.tile[x + 1, y + 1].type] || Main.tile[x, y].active != 0 || Main.tile[x + 1, y].active != 0))
			{
				return false;
			}
			Main.tile[x, y].active = 1;
			Main.tile[x, y].frameY = 0;
			Main.tile[x, y].frameX = 0;
			Main.tile[x, y].type = (byte)type;
			Main.tile[x + 1, y].active = 1;
			Main.tile[x + 1, y].frameY = 0;
			Main.tile[x + 1, y].frameX = 18;
			Main.tile[x + 1, y].type = (byte)type;
			return true;
		}

		private static void Destroy4x2(int i, int j, int x2, int y2, int type)
		{
			destroyObject = true;
			for (int k = x2; k < x2 + 4; k++)
			{
				for (int l = y2; l < y2 + 3; l++)
				{
					if (Main.tile[k, l].type == type && Main.tile[k, l].active != 0)
					{
						KillTile(k, l);
					}
				}
			}
			if (!gen)
			{
				switch (type)
				{
				case 79:
					Item.NewItem(i * 16, j * 16, 32, 32, 224);
					break;
				case 90:
					Item.NewItem(i * 16, j * 16, 32, 32, 336);
					break;
				}
			}
			destroyObject = false;
			bool flag = tileFrameRecursion;
			tileFrameRecursion = false;
			for (int m = x2 - 1; m < x2 + 4; m++)
			{
				for (int n = y2 - 1; n < y2 + 4; n++)
				{
					TileFrame(m, n);
				}
			}
			tileFrameRecursion = flag;
		}

		public static void Check4x2(int i, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j;
			num -= Main.tile[i, j].frameX / 18;
			if ((type == 79 || type == 90) && Main.tile[i, j].frameX >= 72)
			{
				num += 4;
			}
			num2 -= Main.tile[i, j].frameY / 18;
			int num3 = num;
			while (true)
			{
				if (num3 >= num + 4)
				{
					return;
				}
				for (int k = num2; k < num2 + 2; k++)
				{
					int num4 = (num3 - num) * 18;
					if ((type == 79 || type == 90) && Main.tile[i, j].frameX >= 72)
					{
						num4 = (num3 - num + 4) * 18;
					}
					if (Main.tile[num3, k].active == 0 || Main.tile[num3, k].type != type || Main.tile[num3, k].frameX != num4 || Main.tile[num3, k].frameY != (k - num2) * 18)
					{
						Destroy4x2(i, j, num, num2, type);
						return;
					}
				}
				if (Main.tile[num3, num2 + 2].active == 0 || !Main.tileSolid[Main.tile[num3, num2 + 2].type])
				{
					break;
				}
				num3++;
			}
			Destroy4x2(i, j, num, num2, type);
		}

		private static void Destroy2x2(int i, int j, int x2, int y2, int type)
		{
			destroyObject = true;
			for (int k = x2; k < x2 + 2; k++)
			{
				for (int l = y2; l < y2 + 2; l++)
				{
					if (Main.tile[k, l].type == type && Main.tile[k, l].active != 0)
					{
						KillTile(k, l);
					}
				}
			}
			if (!gen)
			{
				switch (type)
				{
				case 85:
					Item.NewItem(i * 16, j * 16, 32, 32, 321);
					break;
				case 94:
					Item.NewItem(i * 16, j * 16, 32, 32, 352);
					break;
				case 95:
					Item.NewItem(i * 16, j * 16, 32, 32, 344);
					break;
				case 96:
					Item.NewItem(i * 16, j * 16, 32, 32, 345);
					break;
				case 97:
					Item.NewItem(i * 16, j * 16, 32, 32, 346);
					break;
				case 98:
					Item.NewItem(i * 16, j * 16, 32, 32, 347);
					break;
				case 99:
					Item.NewItem(i * 16, j * 16, 32, 32, 348);
					break;
				case 100:
					Item.NewItem(i * 16, j * 16, 32, 32, 349);
					break;
				case 125:
					Item.NewItem(i * 16, j * 16, 32, 32, 487);
					break;
				case 126:
					Item.NewItem(i * 16, j * 16, 32, 32, 488);
					break;
				case 132:
					Item.NewItem(i * 16, j * 16, 32, 32, 513);
					break;
				case 142:
					Item.NewItem(i * 16, j * 16, 32, 32, 581);
					break;
				case 143:
					Item.NewItem(i * 16, j * 16, 32, 32, 582);
					break;
				case 138:
					if (Main.netMode != 1)
					{
						Projectile.NewProjectile((float)(x2 * 16) + 15.5f, y2 * 16 + 16, 0f, 0f, 99, 70, 10f);
					}
					break;
				}
			}
			destroyObject = false;
			bool flag = tileFrameRecursion;
			tileFrameRecursion = false;
			for (int m = x2 - 1; m < x2 + 3; m++)
			{
				for (int n = y2 - 1; n < y2 + 3; n++)
				{
					TileFrame(m, n);
				}
			}
			tileFrameRecursion = flag;
		}

		public static void Check2x2(int i, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j;
			int num3 = 0;
			num = -(Main.tile[i, j].frameX / 18);
			num2 = -(Main.tile[i, j].frameY / 18);
			if (num < -1)
			{
				num += 2;
				num3 = 36;
			}
			num += i;
			num2 += j;
			for (int k = num; k < num + 2; k++)
			{
				for (int l = num2; l < num2 + 2; l++)
				{
					if (Main.tile[k, l].active == 0 || Main.tile[k, l].type != type || Main.tile[k, l].frameX != (k - num) * 18 + num3 || Main.tile[k, l].frameY != (l - num2) * 18)
					{
						Destroy2x2(i, j, num, num2, type);
						return;
					}
				}
				switch (type)
				{
				case 95:
				case 126:
					if (Main.tile[k, num2 - 1].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[k, num2 - 1].type])
					{
						Destroy2x2(i, j, num, num2, type);
						return;
					}
					break;
				default:
					if (Main.tile[k, num2 + 2].active == 0 || (!Main.tileSolid[Main.tile[k, num2 + 2].type] && !Main.tileTable[Main.tile[k, num2 + 2].type]))
					{
						Destroy2x2(i, j, num, num2, type);
						return;
					}
					break;
				case 138:
					break;
				}
			}
			if (type == 138 && !SolidTileUnsafe(num, num2 + 2) && !SolidTileUnsafe(num + 1, num2 + 2))
			{
				Destroy2x2(i, j, num, num2, type);
			}
		}

		public static void OreRunner(int i, int j, double strength, int steps, int type)
		{
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			double num = strength;
			float num2 = steps;
			vector.X = i;
			vector.Y = j;
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(-10, 11) * 0.1f;
			while (num > 0.0 && num2 > 0f)
			{
				if (vector.Y < 0f && num2 > 0f && type == 59)
				{
					num2 = 0f;
				}
				num = strength * (double)(num2 / (float)steps);
				num2 -= 1f;
				int num3 = (int)((double)vector.X - num * 0.5);
				int num4 = (int)((double)vector.X + num * 0.5);
				int num5 = (int)((double)vector.Y - num * 0.5);
				int num6 = (int)((double)vector.Y + num * 0.5);
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.maxTilesX)
				{
					num4 = Main.maxTilesX;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesY)
				{
					num6 = Main.maxTilesY;
				}
				for (int k = num3; k < num4; k++)
				{
					for (int l = num5; l < num6; l++)
					{
						if ((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.5 * (double)(1f + (float)genRand.Next(-10, 11) * 0.015f) && Main.tile[k, l].active != 0 && (Main.tile[k, l].type == 0 || Main.tile[k, l].type == 1 || Main.tile[k, l].type == 23 || Main.tile[k, l].type == 25 || Main.tile[k, l].type == 40 || Main.tile[k, l].type == 53 || Main.tile[k, l].type == 57 || Main.tile[k, l].type == 59 || Main.tile[k, l].type == 60 || Main.tile[k, l].type == 70 || Main.tile[k, l].type == 109 || Main.tile[k, l].type == 112 || Main.tile[k, l].type == 116 || Main.tile[k, l].type == 117))
						{
							Main.tile[k, l].type = (byte)type;
							SquareTileFrame(k, l);
							if (Main.netMode == 2)
							{
								NetMessage.SendTile(k, l);
							}
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > 1f)
				{
					vector2.X = 1f;
				}
				else if (vector2.X < -1f)
				{
					vector2.X = -1f;
				}
			}
		}

		public static void SmashAltar(int i, int j)
		{
			if (!Main.hardMode || Main.netMode == 1)
			{
				return;
			}
			int num = altarCount % 3;
			NetMessage.SendText(12 + num, 50, 255, 130, -1);
			int num2 = altarCount / 3 + 1;
			float num3 = (float)Main.maxTilesX * 0.000238095236f;
			int num4 = 1 - num;
			num3 = num3 * 310f - (float)(85 * num);
			num3 *= 0.85f;
			num3 /= (float)num2;
			switch (num)
			{
			case 0:
				num = 107;
				num3 *= 1.05f;
				break;
			case 1:
				num = 108;
				break;
			default:
				num = 111;
				break;
			}
			for (int k = 0; (float)k < num3; k++)
			{
				int i2 = genRand.Next(100, Main.maxTilesX - 100);
				int lowerBound = Main.worldSurface;
				switch (num)
				{
				case 108:
					lowerBound = Main.rockLayer;
					break;
				case 111:
					lowerBound = (Main.rockLayer + Main.rockLayer + Main.maxTilesY) / 3;
					break;
				}
				int j2 = genRand.Next(lowerBound, Main.maxTilesY - 150);
				OreRunner(i2, j2, genRand.Next(5, 9 + num4), genRand.Next(5, 9 + num4), num);
			}
			int num5 = genRand.Next(3);
			while (num5 != 2)
			{
				int num6 = genRand.Next(100, Main.maxTilesX - 100);
				int num7 = genRand.Next(Main.rockLayer + 50, Main.maxTilesY - 300);
				if (Main.tile[num6, num7].active != 0 && Main.tile[num6, num7].type == 1)
				{
					if (num5 == 0)
					{
						Main.tile[num6, num7].type = 25;
					}
					else
					{
						Main.tile[num6, num7].type = 117;
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendTile(num6, num7);
					}
					break;
				}
			}
			if (Main.netMode != 1)
			{
				int num8 = Main.rand.Next(2) + 1;
				Rectangle rect = default(Rectangle);
				rect.X = i << 4;
				rect.Y = j << 4;
				rect.Width = (rect.Height = 16);
				for (int l = 0; l < num8; l++)
				{
					NPC.SpawnOnPlayer(Player.FindClosest(ref rect), 82);
				}
			}
			altarCount++;
		}

		public static void Check3x2(int i, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j;
			num -= Main.tile[i, j].frameX / 18;
			num2 -= Main.tile[i, j].frameY / 18;
			int num3 = num;
			while (true)
			{
				if (num3 >= num + 3)
				{
					return;
				}
				if (Main.tile[num3, num2 + 2].active == 0 || !Main.tileSolid[Main.tile[num3, num2 + 2].type])
				{
					break;
				}
				for (int k = num2; k < num2 + 2; k++)
				{
					if (Main.tile[num3, k].active == 0 || Main.tile[num3, k].type != type || Main.tile[num3, k].frameX != (num3 - num) * 18 || Main.tile[num3, k].frameY != (k - num2) * 18)
					{
						goto end_IL_00df;
					}
				}
				num3++;
				continue;
				end_IL_00df:
				break;
			}
			destroyObject = true;
			for (int l = num; l < num + 3; l++)
			{
				for (int m = num2; m < num2 + 3; m++)
				{
					if (Main.tile[l, m].type == type && Main.tile[l, m].active != 0)
					{
						KillTile(l, m);
					}
				}
			}
			if (!gen)
			{
				switch (type)
				{
				case 14:
					Item.NewItem(i * 16, j * 16, 32, 32, 32);
					break;
				case 114:
					Item.NewItem(i * 16, j * 16, 32, 32, 398);
					break;
				case 26:
					SmashAltar(i, j);
					break;
				case 17:
					Item.NewItem(i * 16, j * 16, 32, 32, 33);
					break;
				case 77:
					Item.NewItem(i * 16, j * 16, 32, 32, 221);
					break;
				case 86:
					Item.NewItem(i * 16, j * 16, 32, 32, 332);
					break;
				case 87:
					Item.NewItem(i * 16, j * 16, 32, 32, 333);
					break;
				case 88:
					Item.NewItem(i * 16, j * 16, 32, 32, 334);
					break;
				case 89:
					Item.NewItem(i * 16, j * 16, 32, 32, 335);
					break;
				case 133:
					Item.NewItem(i * 16, j * 16, 32, 32, 524);
					break;
				}
			}
			destroyObject = false;
			bool flag = tileFrameRecursion;
			tileFrameRecursion = false;
			TileFrame(num - 1, num2 - 1);
			TileFrame(num, num2 - 1);
			TileFrame(num + 1, num2 - 1);
			TileFrame(num + 2, num2 - 1);
			TileFrame(num - 1, num2);
			TileFrame(num, num2);
			TileFrame(num + 1, num2);
			TileFrame(num + 2, num2);
			TileFrame(num - 1, num2 + 1);
			TileFrame(num, num2 + 1);
			TileFrame(num + 1, num2 + 1);
			TileFrame(num + 2, num2 + 1);
			TileFrame(num - 1, num2 + 2);
			TileFrame(num, num2 + 2);
			TileFrame(num + 1, num2 + 2);
			TileFrame(num + 2, num2 + 2);
			TileFrame(num - 1, num2 + 3);
			TileFrame(num, num2 + 3);
			TileFrame(num + 1, num2 + 3);
			TileFrame(num + 2, num2 + 3);
			tileFrameRecursion = flag;
		}

		public static void Check3x4(int i, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j;
			num -= Main.tile[i, j].frameX / 18;
			num2 -= Main.tile[i, j].frameY / 18;
			for (int k = num; k < num + 3; k++)
			{
				int num3 = num2;
				while (true)
				{
					if (num3 < num2 + 4)
					{
						if (Main.tile[k, num3].active != 0 && Main.tile[k, num3].type == type && Main.tile[k, num3].frameX == (k - num) * 18 && Main.tile[k, num3].frameY == (num3 - num2) * 18)
						{
							num3++;
							continue;
						}
					}
					else if (Main.tile[k, num2 + 4].active != 0 && Main.tileSolid[Main.tile[k, num2 + 4].type])
					{
						break;
					}
					destroyObject = true;
					for (int l = num; l < num + 3; l++)
					{
						for (int m = num2; m < num2 + 4; m++)
						{
							if (Main.tile[l, m].type == type && Main.tile[l, m].active != 0)
							{
								KillTile(l, m);
							}
						}
					}
					if (!gen)
					{
						switch (type)
						{
						case 101:
							Item.NewItem(i * 16, j * 16, 32, 32, 354);
							break;
						case 102:
							Item.NewItem(i * 16, j * 16, 32, 32, 355);
							break;
						}
					}
					destroyObject = false;
					bool flag = tileFrameRecursion;
					tileFrameRecursion = false;
					for (int n = num - 1; n < num + 4; n++)
					{
						for (int num4 = num2 - 1; num4 < num2 + 4; num4++)
						{
							TileFrame(n, num4);
						}
					}
					tileFrameRecursion = flag;
					return;
				}
			}
		}

		public static bool Place4x2(int x, int y, int type, int direction = -1)
		{
			if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
			{
				return false;
			}
			for (int i = x - 1; i < x + 3; i++)
			{
				if (Main.tile[i, y + 1].active == 0 || !Main.tileSolid[Main.tile[i, y + 1].type])
				{
					return false;
				}
				for (int j = y - 1; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0)
					{
						return false;
					}
				}
			}
			int num = (direction == 1) ? 72 : 0;
			Main.tile[x - 1, y - 1].active = 1;
			Main.tile[x - 1, y - 1].frameY = 0;
			Main.tile[x - 1, y - 1].frameX = (short)num;
			Main.tile[x - 1, y - 1].type = (byte)type;
			Main.tile[x, y - 1].active = 1;
			Main.tile[x, y - 1].frameY = 0;
			Main.tile[x, y - 1].frameX = (short)(18 + num);
			Main.tile[x, y - 1].type = (byte)type;
			Main.tile[x + 1, y - 1].active = 1;
			Main.tile[x + 1, y - 1].frameY = 0;
			Main.tile[x + 1, y - 1].frameX = (short)(36 + num);
			Main.tile[x + 1, y - 1].type = (byte)type;
			Main.tile[x + 2, y - 1].active = 1;
			Main.tile[x + 2, y - 1].frameY = 0;
			Main.tile[x + 2, y - 1].frameX = (short)(54 + num);
			Main.tile[x + 2, y - 1].type = (byte)type;
			Main.tile[x - 1, y].active = 1;
			Main.tile[x - 1, y].frameY = 18;
			Main.tile[x - 1, y].frameX = (short)num;
			Main.tile[x - 1, y].type = (byte)type;
			Main.tile[x, y].active = 1;
			Main.tile[x, y].frameY = 18;
			Main.tile[x, y].frameX = (short)(18 + num);
			Main.tile[x, y].type = (byte)type;
			Main.tile[x + 1, y].active = 1;
			Main.tile[x + 1, y].frameY = 18;
			Main.tile[x + 1, y].frameX = (short)(36 + num);
			Main.tile[x + 1, y].type = (byte)type;
			Main.tile[x + 2, y].active = 1;
			Main.tile[x + 2, y].frameY = 18;
			Main.tile[x + 2, y].frameX = (short)(54 + num);
			Main.tile[x + 2, y].type = (byte)type;
			return true;
		}

		public static void SwitchMB(int i, int j)
		{
			int num = i;
			int num2 = j;
			int num3 = (Main.tile[i, j].frameY / 18) & 1;
			int num4 = Main.tile[i, j].frameX / 18;
			if (num4 >= 2)
			{
				num4 -= 2;
			}
			num = i - num4;
			num2 = j - num3;
			for (int k = num; k < num + 2; k++)
			{
				for (int l = num2; l < num2 + 2; l++)
				{
					if (Main.tile[k, l].active != 0 && Main.tile[k, l].type == 139)
					{
						if (Main.tile[k, l].frameX < 36)
						{
							Main.tile[k, l].frameX += 36;
						}
						else
						{
							Main.tile[k, l].frameX -= 36;
						}
						noWire[numNoWire].X = (short)k;
						noWire[numNoWire].Y = (short)l;
						numNoWire++;
					}
				}
			}
			NetMessage.SendTileSquare(num, num2, 3);
		}

		public static void CheckMusicBox(int i, int j)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j;
			int num3 = Main.tile[i, j].frameY / 18;
			int num4 = num3 >> 1;
			num3 &= 1;
			int num5 = Main.tile[i, j].frameX / 18;
			int num6 = 0;
			if (num5 >= 2)
			{
				num5 -= 2;
				num6++;
			}
			num = i - num5;
			num2 = j - num3;
			for (int k = num; k < num + 2; k++)
			{
				int num7 = num2;
				while (true)
				{
					if (num7 < num2 + 2)
					{
						if (Main.tile[k, num7].active != 0 && Main.tile[k, num7].type == 139 && Main.tile[k, num7].frameX == (k - num) * 18 + num6 * 36 && Main.tile[k, num7].frameY == (num7 - num2) * 18 + num4 * 36)
						{
							num7++;
							continue;
						}
					}
					else if (Main.tileSolid[Main.tile[k, num2 + 2].type])
					{
						break;
					}
					destroyObject = true;
					for (int l = num; l < num + 2; l++)
					{
						for (int m = num2; m < num2 + 3; m++)
						{
							if (Main.tile[l, m].type == 139 && Main.tile[l, m].active != 0)
							{
								KillTile(l, m);
							}
						}
					}
					Item.NewItem(i * 16, j * 16, 32, 32, 562 + num4);
					bool flag = tileFrameRecursion;
					tileFrameRecursion = false;
					for (int n = num - 1; n < num + 3; n++)
					{
						for (int num8 = num2 - 1; num8 < num2 + 3; num8++)
						{
							TileFrame(n, num8);
						}
					}
					tileFrameRecursion = flag;
					destroyObject = false;
					return;
				}
			}
		}

		public static bool PlaceMB(int X, int y, int type, int style)
		{
			int num = X + 1;
			if (num < 5 || num > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
			{
				return false;
			}
			for (int i = num - 1; i < num + 1; i++)
			{
				for (int j = y - 1; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0)
					{
						return false;
					}
				}
				if (Main.tile[i, y + 1].active == 0 || (!Main.tileSolid[Main.tile[i, y + 1].type] && !Main.tileTable[Main.tile[i, y + 1].type]))
				{
					return false;
				}
			}
			Main.tile[num - 1, y - 1].active = 1;
			Main.tile[num - 1, y - 1].frameY = (short)(style * 36);
			Main.tile[num - 1, y - 1].frameX = 0;
			Main.tile[num - 1, y - 1].type = (byte)type;
			Main.tile[num, y - 1].active = 1;
			Main.tile[num, y - 1].frameY = (short)(style * 36);
			Main.tile[num, y - 1].frameX = 18;
			Main.tile[num, y - 1].type = (byte)type;
			Main.tile[num - 1, y].active = 1;
			Main.tile[num - 1, y].frameY = (short)(style * 36 + 18);
			Main.tile[num - 1, y].frameX = 0;
			Main.tile[num - 1, y].type = (byte)type;
			Main.tile[num, y].active = 1;
			Main.tile[num, y].frameY = (short)(style * 36 + 18);
			Main.tile[num, y].frameX = 18;
			Main.tile[num, y].type = (byte)type;
			return true;
		}

		public static bool Place2x2(int x, int y, int type)
		{
			if (type == 95 || type == 126)
			{
				y++;
			}
			if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
			{
				return false;
			}
			for (int i = x - 1; i < x + 1; i++)
			{
				if (type == 95 || type == 126)
				{
					if (Main.tile[i, y - 2].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[i, y - 2].type])
					{
						return false;
					}
				}
				else if (Main.tile[i, y + 1].active == 0 || (!Main.tileSolid[Main.tile[i, y + 1].type] && !Main.tileTable[Main.tile[i, y + 1].type]))
				{
					return false;
				}
				for (int j = y - 1; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0 || (type == 98 && Main.tile[i, j].liquid > 0))
					{
						return false;
					}
				}
			}
			Main.tile[x - 1, y - 1].active = 1;
			Main.tile[x - 1, y - 1].frameY = 0;
			Main.tile[x - 1, y - 1].frameX = 0;
			Main.tile[x - 1, y - 1].type = (byte)type;
			Main.tile[x, y - 1].active = 1;
			Main.tile[x, y - 1].frameY = 0;
			Main.tile[x, y - 1].frameX = 18;
			Main.tile[x, y - 1].type = (byte)type;
			Main.tile[x - 1, y].active = 1;
			Main.tile[x - 1, y].frameY = 18;
			Main.tile[x - 1, y].frameX = 0;
			Main.tile[x - 1, y].type = (byte)type;
			Main.tile[x, y].active = 1;
			Main.tile[x, y].frameY = 18;
			Main.tile[x, y].frameX = 18;
			Main.tile[x, y].type = (byte)type;
			return true;
		}

		public static bool Place3x4(int x, int y, int type)
		{
			if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
			{
				return false;
			}
			for (int i = x - 1; i < x + 2; i++)
			{
				if (Main.tile[i, y + 1].active == 0 || !Main.tileSolid[Main.tile[i, y + 1].type])
				{
					return false;
				}
				for (int j = y - 3; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0)
					{
						return false;
					}
				}
			}
			for (int k = -3; k <= 0; k++)
			{
				short frameY = (short)((3 + k) * 18);
				Main.tile[x - 1, y + k].active = 1;
				Main.tile[x - 1, y + k].frameY = frameY;
				Main.tile[x - 1, y + k].frameX = 0;
				Main.tile[x - 1, y + k].type = (byte)type;
				Main.tile[x, y + k].active = 1;
				Main.tile[x, y + k].frameY = frameY;
				Main.tile[x, y + k].frameX = 18;
				Main.tile[x, y + k].type = (byte)type;
				Main.tile[x + 1, y + k].active = 1;
				Main.tile[x + 1, y + k].frameY = frameY;
				Main.tile[x + 1, y + k].frameX = 36;
				Main.tile[x + 1, y + k].type = (byte)type;
			}
			return true;
		}

		public static bool Place3x2(int x, int y, int type)
		{
			if (x < 5 || x > Main.maxTilesX - 5 || y < 5 || y > Main.maxTilesY - 5)
			{
				return false;
			}
			for (int i = x - 1; i < x + 2; i++)
			{
				for (int j = y - 1; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0)
					{
						return false;
					}
				}
				if (Main.tile[i, y + 1].active == 0 || !Main.tileSolid[Main.tile[i, y + 1].type])
				{
					return false;
				}
			}
			Main.tile[x - 1, y - 1].active = 1;
			Main.tile[x - 1, y - 1].frameY = 0;
			Main.tile[x - 1, y - 1].frameX = 0;
			Main.tile[x - 1, y - 1].type = (byte)type;
			Main.tile[x, y - 1].active = 1;
			Main.tile[x, y - 1].frameY = 0;
			Main.tile[x, y - 1].frameX = 18;
			Main.tile[x, y - 1].type = (byte)type;
			Main.tile[x + 1, y - 1].active = 1;
			Main.tile[x + 1, y - 1].frameY = 0;
			Main.tile[x + 1, y - 1].frameX = 36;
			Main.tile[x + 1, y - 1].type = (byte)type;
			Main.tile[x - 1, y].active = 1;
			Main.tile[x - 1, y].frameY = 18;
			Main.tile[x - 1, y].frameX = 0;
			Main.tile[x - 1, y].type = (byte)type;
			Main.tile[x, y].active = 1;
			Main.tile[x, y].frameY = 18;
			Main.tile[x, y].frameX = 18;
			Main.tile[x, y].type = (byte)type;
			Main.tile[x + 1, y].active = 1;
			Main.tile[x + 1, y].frameY = 18;
			Main.tile[x + 1, y].frameX = 36;
			Main.tile[x + 1, y].type = (byte)type;
			return true;
		}

		public static void Check3x3(int i, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j;
			num = Main.tile[i, j].frameX / 18;
			int num3 = i - num;
			if (num >= 3)
			{
				num -= 3;
			}
			num = i - num;
			num2 += Main.tile[i, j].frameY / 18 * -1;
			int num4 = num;
			while (true)
			{
				if (num4 < num + 3)
				{
					for (int k = num2; k < num2 + 3; k++)
					{
						if (Main.tile[num4, k].active == 0 || Main.tile[num4, k].type != type || Main.tile[num4, k].frameX != (num4 - num3) * 18 || Main.tile[num4, k].frameY != (k - num2) * 18)
						{
							goto end_IL_00d1;
						}
					}
					num4++;
					continue;
				}
				if (type == 106)
				{
					int num5 = num;
					while (true)
					{
						if (num5 < num + 3)
						{
							if (Main.tile[num5, num2 + 3].active == 0 || !Main.tileSolid[Main.tile[num5, num2 + 3].type])
							{
								break;
							}
							num5++;
							continue;
						}
						return;
					}
					break;
				}
				if (Main.tile[num + 1, num2 - 1].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[num + 1, num2 - 1].type])
				{
					break;
				}
				return;
				continue;
				end_IL_00d1:
				break;
			}
			destroyObject = true;
			for (int l = num; l < num + 3; l++)
			{
				for (int m = num2; m < num2 + 3; m++)
				{
					if (Main.tile[l, m].type == type && Main.tile[l, m].active != 0)
					{
						KillTile(l, m);
					}
				}
			}
			switch (type)
			{
			case 34:
				Item.NewItem(i * 16, j * 16, 32, 32, 106);
				break;
			case 35:
				Item.NewItem(i * 16, j * 16, 32, 32, 107);
				break;
			case 36:
				Item.NewItem(i * 16, j * 16, 32, 32, 108);
				break;
			case 106:
				Item.NewItem(i * 16, j * 16, 32, 32, 363);
				break;
			}
			destroyObject = false;
			bool flag = tileFrameRecursion;
			tileFrameRecursion = false;
			for (int n = num - 1; n < num + 4; n++)
			{
				for (int num6 = num2 - 1; num6 < num2 + 4; num6++)
				{
					TileFrame(n, num6);
				}
			}
			tileFrameRecursion = flag;
		}

		public static bool Place3x3(int x, int y, int type)
		{
			int num = 0;
			if (type == 106)
			{
				num = -2;
				for (int i = x - 1; i < x + 2; i++)
				{
					for (int j = y - 2; j < y + 1; j++)
					{
						if (Main.tile[i, j].active != 0)
						{
							return false;
						}
					}
				}
				for (int k = x - 1; k < x + 2; k++)
				{
					if (Main.tile[k, y + 1].active == 0 || !Main.tileSolid[Main.tile[k, y + 1].type])
					{
						return false;
					}
				}
			}
			else
			{
				for (int l = x - 1; l < x + 2; l++)
				{
					for (int m = y; m < y + 3; m++)
					{
						if (Main.tile[l, m].active != 0)
						{
							return false;
						}
					}
				}
				if (Main.tile[x, y - 1].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[x, y - 1].type])
				{
					return false;
				}
			}
			Main.tile[x - 1, y + num].active = 1;
			Main.tile[x - 1, y + num].frameY = 0;
			Main.tile[x - 1, y + num].frameX = 0;
			Main.tile[x - 1, y + num].type = (byte)type;
			Main.tile[x, y + num].active = 1;
			Main.tile[x, y + num].frameY = 0;
			Main.tile[x, y + num].frameX = 18;
			Main.tile[x, y + num].type = (byte)type;
			Main.tile[x + 1, y + num].active = 1;
			Main.tile[x + 1, y + num].frameY = 0;
			Main.tile[x + 1, y + num].frameX = 36;
			Main.tile[x + 1, y + num].type = (byte)type;
			Main.tile[x - 1, y + 1 + num].active = 1;
			Main.tile[x - 1, y + 1 + num].frameY = 18;
			Main.tile[x - 1, y + 1 + num].frameX = 0;
			Main.tile[x - 1, y + 1 + num].type = (byte)type;
			Main.tile[x, y + 1 + num].active = 1;
			Main.tile[x, y + 1 + num].frameY = 18;
			Main.tile[x, y + 1 + num].frameX = 18;
			Main.tile[x, y + 1 + num].type = (byte)type;
			Main.tile[x + 1, y + 1 + num].active = 1;
			Main.tile[x + 1, y + 1 + num].frameY = 18;
			Main.tile[x + 1, y + 1 + num].frameX = 36;
			Main.tile[x + 1, y + 1 + num].type = (byte)type;
			Main.tile[x - 1, y + 2 + num].active = 1;
			Main.tile[x - 1, y + 2 + num].frameY = 36;
			Main.tile[x - 1, y + 2 + num].frameX = 0;
			Main.tile[x - 1, y + 2 + num].type = (byte)type;
			Main.tile[x, y + 2 + num].active = 1;
			Main.tile[x, y + 2 + num].frameY = 36;
			Main.tile[x, y + 2 + num].frameX = 18;
			Main.tile[x, y + 2 + num].type = (byte)type;
			Main.tile[x + 1, y + 2 + num].active = 1;
			Main.tile[x + 1, y + 2 + num].frameY = 36;
			Main.tile[x + 1, y + 2 + num].frameX = 36;
			Main.tile[x + 1, y + 2 + num].type = (byte)type;
			return true;
		}

		public static bool PlaceSunflower(int x, int y)
		{
			if (y > Main.worldSurface - 1)
			{
				return false;
			}
			for (int i = x; i < x + 2; i++)
			{
				for (int j = y - 3; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0 || Main.tile[i, j].wall > 0)
					{
						return false;
					}
				}
				if (Main.tile[i, y + 1].active == 0 || (Main.tile[i, y + 1].type != 2 && Main.tile[i, y + 1].type != 109))
				{
					return false;
				}
			}
			for (int k = 0; k < 2; k++)
			{
				for (int l = -3; l < 1; l++)
				{
					int num = k * 18 + genRand.Next(3) * 36;
					int num2 = (l + 3) * 18;
					Main.tile[x + k, y + l].active = 1;
					Main.tile[x + k, y + l].frameX = (short)num;
					Main.tile[x + k, y + l].frameY = (short)num2;
					Main.tile[x + k, y + l].type = 27;
				}
			}
			return true;
		}

		public static void CheckSunflower(int i, int j)
		{
			if (destroyObject)
			{
				return;
			}
			int num = 0;
			int num2 = j;
			num += Main.tile[i, j].frameX / 18;
			num2 -= Main.tile[i, j].frameY / 18;
			num &= 1;
			num = -num;
			num += i;
			for (int k = num; k < num + 2; k++)
			{
				int num3 = num2;
				while (true)
				{
					if (num3 < num2 + 4)
					{
						int num4 = (Main.tile[k, num3].frameX / 18) & 1;
						if (Main.tile[k, num3].active != 0 && Main.tile[k, num3].type == 27 && num4 == k - num && Main.tile[k, num3].frameY == (num3 - num2) * 18)
						{
							num3++;
							continue;
						}
					}
					else if (Main.tile[k, num2 + 4].active != 0 && (Main.tile[k, num2 + 4].type == 2 || Main.tile[k, num2 + 4].type == 109))
					{
						break;
					}
					destroyObject = true;
					for (int l = num; l < num + 2; l++)
					{
						for (int m = num2; m < num2 + 4; m++)
						{
							if (Main.tile[l, m].type == 27 && Main.tile[l, m].active != 0)
							{
								KillTile(l, m);
							}
						}
					}
					Item.NewItem(i * 16, j * 16, 32, 32, 63);
					destroyObject = false;
					return;
				}
			}
		}

		public static bool PlacePot(int x, int y)
		{
			for (int i = x; i < x + 2; i++)
			{
				for (int j = y - 1; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0)
					{
						return false;
					}
				}
				if (Main.tile[i, y + 1].active == 0 || !Main.tileSolid[Main.tile[i, y + 1].type])
				{
					return false;
				}
			}
			for (int k = 0; k < 2; k++)
			{
				for (int l = -1; l < 1; l++)
				{
					Main.tile[x + k, y + l].active = 1;
					Main.tile[x + k, y + l].frameX = (short)(k * 18 + genRand.Next(3) * 36);
					Main.tile[x + k, y + l].frameY = (short)((l + 1) * 18);
					Main.tile[x + k, y + l].type = 28;
				}
			}
			return true;
		}

		public static bool CheckCactus(int i, int j)
		{
			int num = j;
			int num2 = i;
			while (Main.tile[num2, num].active != 0 && Main.tile[num2, num].type == 80)
			{
				num++;
				if (Main.tile[num2, num].active == 0 || Main.tile[num2, num].type != 80)
				{
					if (Main.tile[num2 - 1, num].active != 0 && Main.tile[num2 - 1, num].type == 80 && Main.tile[num2 - 1, num - 1].active != 0 && Main.tile[num2 - 1, num - 1].type == 80 && num2 >= i)
					{
						num2--;
					}
					if (Main.tile[num2 + 1, num].active != 0 && Main.tile[num2 + 1, num].type == 80 && Main.tile[num2 + 1, num - 1].active != 0 && Main.tile[num2 + 1, num - 1].type == 80 && num2 <= i)
					{
						num2++;
					}
				}
			}
			if (Main.tile[num2, num].active == 0 || (Main.tile[num2, num].type != 53 && Main.tile[num2, num].type != 112 && Main.tile[num2, num].type != 116))
			{
				KillTile(i, j);
				return true;
			}
			if (i != num2)
			{
				if ((Main.tile[i, j + 1].active == 0 || Main.tile[i, j + 1].type != 80) && (Main.tile[i - 1, j].active == 0 || Main.tile[i - 1, j].type != 80) && (Main.tile[i + 1, j].active == 0 || Main.tile[i + 1, j].type != 80))
				{
					KillTile(i, j);
					return true;
				}
			}
			else if (i == num2 && (Main.tile[i, j + 1].active == 0 || (Main.tile[i, j + 1].type != 80 && Main.tile[i, j + 1].type != 53 && Main.tile[i, j + 1].type != 112 && Main.tile[i, j + 1].type != 116)))
			{
				KillTile(i, j);
				return true;
			}
			return false;
		}

		public static void PlantCactus(int i, int j)
		{
			GrowCactus(i, j);
			for (int k = 0; k < 150; k++)
			{
				int i2 = genRand.Next(i - 1, i + 2);
				int j2 = genRand.Next(j - 10, j + 2);
				GrowCactus(i2, j2);
			}
		}

		public static void CheckOrb(int i, int j, int type)
		{
			if (destroyObject)
			{
				return;
			}
			int num = i;
			int num2 = j;
			num = ((Main.tile[i, j].frameX != 0) ? (i - 1) : i);
			num2 = ((Main.tile[i, j].frameY != 0) ? (j - 1) : j);
			if (Main.tile[num, num2].active != 0 && Main.tile[num, num2].type == type && Main.tile[num + 1, num2].active != 0 && Main.tile[num + 1, num2].type == type && Main.tile[num, num2 + 1].active != 0 && Main.tile[num, num2 + 1].type == type && Main.tile[num + 1, num2 + 1].active != 0 && Main.tile[num + 1, num2 + 1].type == type)
			{
				return;
			}
			destroyObject = true;
			if (Main.tile[num, num2].type == type)
			{
				KillTile(num, num2);
			}
			if (Main.tile[num + 1, num2].type == type)
			{
				KillTile(num + 1, num2);
			}
			if (Main.tile[num, num2 + 1].type == type)
			{
				KillTile(num, num2 + 1);
			}
			if (Main.tile[num + 1, num2 + 1].type == type)
			{
				KillTile(num + 1, num2 + 1);
			}
			if (!gen)
			{
				Main.PlaySound(13, i * 16, j * 16);
				if (Main.netMode != 1)
				{
					switch (type)
					{
					case 12:
						Item.NewItem(num * 16, num2 * 16, 32, 32, 29);
						break;
					case 31:
					{
						if (genRand.Next(2) == 0)
						{
							spawnMeteor = true;
						}
						int num3 = Main.rand.Next(5);
						if (!shadowOrbSmashed)
						{
							num3 = 0;
						}
						switch (num3)
						{
						case 0:
						{
							Item.NewItem(num * 16, num2 * 16, 32, 32, 96, 1, noBroadcast: false, -1);
							int stack = genRand.Next(25, 51);
							Item.NewItem(num * 16, num2 * 16, 32, 32, 97, stack);
							break;
						}
						case 1:
							Item.NewItem(num * 16, num2 * 16, 32, 32, 64, 1, noBroadcast: false, -1);
							break;
						case 2:
							Item.NewItem(num * 16, num2 * 16, 32, 32, 162, 1, noBroadcast: false, -1);
							break;
						case 3:
							Item.NewItem(num * 16, num2 * 16, 32, 32, 115, 1, noBroadcast: false, -1);
							break;
						case 4:
							Item.NewItem(num * 16, num2 * 16, 32, 32, 111, 1, noBroadcast: false, -1);
							break;
						}
						shadowOrbSmashed = true;
						shadowOrbCount++;
						if (shadowOrbCount >= 3)
						{
							shadowOrbCount = 0;
							Rectangle rect = default(Rectangle);
							rect.X = num << 4;
							rect.Y = num2 << 4;
							rect.Width = (rect.Height = 0);
							NPC.SpawnOnPlayer(Player.FindClosest(ref rect), 13);
						}
						else
						{
							int textId = 10;
							if (shadowOrbCount == 2)
							{
								textId = 11;
							}
							NetMessage.SendText(textId, 50, 255, 130, -1);
						}
						break;
					}
					}
				}
			}
			destroyObject = false;
		}

		public static void CheckTree(int i, int j)
		{
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			if (Main.tile[i - 1, j].active != 0)
			{
				num2 = Main.tile[i - 1, j].type;
			}
			if (Main.tile[i + 1, j].active != 0)
			{
				num3 = Main.tile[i + 1, j].type;
			}
			if (Main.tile[i, j - 1].active != 0)
			{
				num = Main.tile[i, j - 1].type;
			}
			if (Main.tile[i, j + 1].active != 0)
			{
				num4 = Main.tile[i, j + 1].type;
			}
			if (num2 >= 0 && Main.tileStone[num2])
			{
				num2 = 1;
			}
			if (num3 >= 0 && Main.tileStone[num3])
			{
				num3 = 1;
			}
			if (num >= 0 && Main.tileStone[num])
			{
				num = 1;
			}
			if (num4 >= 0 && Main.tileStone[num4])
			{
				num4 = 1;
			}
			switch (num4)
			{
			case 23:
				num4 = 2;
				break;
			case 60:
				num4 = 2;
				break;
			case 109:
				num4 = 2;
				break;
			case 147:
				num4 = 2;
				break;
			}
			int frameNumber = Main.tile[i, j].frameNumber;
			int type = Main.tile[i, j].type;
			int frameX;
			int num5 = frameX = Main.tile[i, j].frameX;
			int frameY;
			int num6 = frameY = Main.tile[i, j].frameY;
			if (frameX >= 22 && frameX <= 44 && frameY >= 132 && frameY <= 176)
			{
				if (num4 != 2)
				{
					KillTile(i, j);
				}
				else if ((frameX != 22 || num2 != type) && (frameX != 44 || num3 != type))
				{
					KillTile(i, j);
				}
			}
			else if ((frameX == 88 && frameY >= 0 && frameY <= 44) || (frameX == 66 && frameY >= 66 && frameY <= 130) || (frameX == 110 && frameY >= 66 && frameY <= 110) || (frameX == 132 && frameY >= 0 && frameY <= 176))
			{
				if (num2 == type && num3 == type)
				{
					Main.tile[i, j].frameX = 110;
					Main.tile[i, j].frameY = (short)(66 + 22 * frameNumber);
				}
				else if (num2 == type)
				{
					Main.tile[i, j].frameX = 88;
					Main.tile[i, j].frameY = (short)(22 * frameNumber);
				}
				else if (num3 == type)
				{
					Main.tile[i, j].frameX = 66;
					Main.tile[i, j].frameY = (short)(66 + 22 * frameNumber);
				}
				else
				{
					Main.tile[i, j].frameX = 0;
					Main.tile[i, j].frameY = (short)(22 * frameNumber);
				}
			}
			frameX = Main.tile[i, j].frameX;
			frameY = Main.tile[i, j].frameY;
			if (frameY >= 132 && frameY <= 176)
			{
				if (frameX == 0 || frameX == 66 || frameX == 88)
				{
					if (num4 != 2)
					{
						KillTile(i, j);
					}
					if (num2 != type && num3 != type)
					{
						Main.tile[i, j].frameX = 0;
						Main.tile[i, j].frameY = (short)(22 * frameNumber);
					}
					else if (num2 != type)
					{
						Main.tile[i, j].frameX = 0;
						Main.tile[i, j].frameY = (short)(132 + 22 * frameNumber);
					}
					else if (num3 != type)
					{
						Main.tile[i, j].frameX = 66;
						Main.tile[i, j].frameY = (short)(132 + 22 * frameNumber);
					}
					else
					{
						Main.tile[i, j].frameX = 88;
						Main.tile[i, j].frameY = (short)(132 + 22 * frameNumber);
					}
				}
			}
			else if ((frameX == 66 && (frameY == 0 || frameY == 22 || frameY == 44)) || (frameX == 44 && (frameY == 198 || frameY == 220 || frameY == 242)))
			{
				if (num3 != type)
				{
					KillTile(i, j);
				}
			}
			else if ((frameX == 88 && (frameY == 66 || frameY == 88 || frameY == 110)) || (frameX == 66 && (frameY == 198 || frameY == 220 || frameY == 242)))
			{
				if (num2 != type)
				{
					KillTile(i, j);
				}
			}
			else if (num4 == -1 || num4 == 23)
			{
				KillTile(i, j);
			}
			else if (num != type && frameY < 198 && ((frameX != 22 && frameX != 44) || frameY < 132))
			{
				if (num2 == type || num3 == type)
				{
					if (num4 == type)
					{
						if (num2 == type && num3 == type)
						{
							Main.tile[i, j].frameX = 132;
							Main.tile[i, j].frameY = (short)(132 + 22 * frameNumber);
						}
						else if (num2 == type)
						{
							Main.tile[i, j].frameX = 132;
							Main.tile[i, j].frameY = (short)(22 * frameNumber);
						}
						else if (num3 == type)
						{
							Main.tile[i, j].frameX = 132;
							Main.tile[i, j].frameY = (short)(66 + 22 * frameNumber);
						}
					}
					else if (num2 == type && num3 == type)
					{
						Main.tile[i, j].frameX = 154;
						Main.tile[i, j].frameY = (short)(132 + 22 * frameNumber);
					}
					else if (num2 == type)
					{
						Main.tile[i, j].frameX = 154;
						Main.tile[i, j].frameY = (short)(22 * frameNumber);
					}
					else if (num3 == type)
					{
						Main.tile[i, j].frameX = 154;
						Main.tile[i, j].frameY = (short)(66 + 22 * frameNumber);
					}
				}
				else
				{
					Main.tile[i, j].frameX = 110;
					Main.tile[i, j].frameY = (short)(22 * frameNumber);
				}
			}
			if (num5 >= 0 && num6 >= 0 && Main.tile[i, j].frameX != num5 && Main.tile[i, j].frameY != num6)
			{
				TileFrame(i - 1, j);
				TileFrame(i + 1, j);
				TileFrame(i, j - 1);
				TileFrame(i, j + 1);
			}
		}

		public static void CactusFrame(int i, int j)
		{
			try
			{
				int num = j;
				int num2 = i;
				if (!CheckCactus(i, j))
				{
					while (Main.tile[num2, num].active != 0 && Main.tile[num2, num].type == 80)
					{
						num++;
						if (Main.tile[num2, num].active == 0 || Main.tile[num2, num].type != 80)
						{
							if (Main.tile[num2 - 1, num].active != 0 && Main.tile[num2 - 1, num].type == 80 && Main.tile[num2 - 1, num - 1].active != 0 && Main.tile[num2 - 1, num - 1].type == 80 && num2 >= i)
							{
								num2--;
							}
							if (Main.tile[num2 + 1, num].active != 0 && Main.tile[num2 + 1, num].type == 80 && Main.tile[num2 + 1, num - 1].active != 0 && Main.tile[num2 + 1, num - 1].type == 80 && num2 <= i)
							{
								num2++;
							}
						}
					}
					num--;
					int num3 = i - num2;
					num2 = i;
					num = j;
					int type = Main.tile[i - 2, j].type;
					int num4 = Main.tile[i - 1, j].type;
					int num5 = Main.tile[i + 1, j].type;
					int num6 = Main.tile[i, j - 1].type;
					int num7 = Main.tile[i, j + 1].type;
					int num8 = Main.tile[i - 1, j + 1].type;
					int num9 = Main.tile[i + 1, j + 1].type;
					if (Main.tile[i - 1, j].active == 0)
					{
						num4 = -1;
					}
					if (Main.tile[i + 1, j].active == 0)
					{
						num5 = -1;
					}
					if (Main.tile[i, j - 1].active == 0)
					{
						num6 = -1;
					}
					if (Main.tile[i, j + 1].active == 0)
					{
						num7 = -1;
					}
					if (Main.tile[i - 1, j + 1].active == 0)
					{
						num8 = -1;
					}
					if (Main.tile[i + 1, j + 1].active == 0)
					{
						num9 = -1;
					}
					short num10 = Main.tile[i, j].frameX;
					short num11 = Main.tile[i, j].frameY;
					switch (num3)
					{
					case 0:
						if (num6 != 80)
						{
							if (num4 == 80 && num5 == 80 && num8 != 80 && num9 != 80 && type != 80)
							{
								num10 = 90;
								num11 = 0;
							}
							else if (num4 == 80 && num8 != 80 && type != 80)
							{
								num10 = 72;
								num11 = 0;
							}
							else if (num5 == 80 && num9 != 80)
							{
								num10 = 18;
								num11 = 0;
							}
							else
							{
								num10 = 0;
								num11 = 0;
							}
						}
						else if (num4 == 80 && num5 == 80 && num8 != 80 && num9 != 80 && type != 80)
						{
							num10 = 90;
							num11 = 36;
						}
						else if (num4 == 80 && num8 != 80 && type != 80)
						{
							num10 = 72;
							num11 = 36;
						}
						else if (num5 == 80 && num9 != 80)
						{
							num10 = 18;
							num11 = 36;
						}
						else if (num7 >= 0 && Main.tileSolid[num7])
						{
							num10 = 0;
							num11 = 36;
						}
						else
						{
							num10 = 0;
							num11 = 18;
						}
						break;
					case -1:
						if (num5 == 80)
						{
							if (num6 != 80 && num7 != 80)
							{
								num10 = 108;
								num11 = 36;
							}
							else if (num7 != 80)
							{
								num10 = 54;
								num11 = 36;
							}
							else if (num6 != 80)
							{
								num10 = 54;
								num11 = 0;
							}
							else
							{
								num10 = 54;
								num11 = 18;
							}
						}
						else if (num6 != 80)
						{
							num10 = 54;
							num11 = 0;
						}
						else
						{
							num10 = 54;
							num11 = 18;
						}
						break;
					case 1:
						if (num4 == 80)
						{
							if (num6 != 80 && num7 != 80)
							{
								num10 = 108;
								num11 = 16;
							}
							else if (num7 != 80)
							{
								num10 = 36;
								num11 = 36;
							}
							else if (num6 != 80)
							{
								num10 = 36;
								num11 = 0;
							}
							else
							{
								num10 = 36;
								num11 = 18;
							}
						}
						else if (num6 != 80)
						{
							num10 = 36;
							num11 = 0;
						}
						else
						{
							num10 = 36;
							num11 = 18;
						}
						break;
					}
					if (num10 != Main.tile[i, j].frameX || num11 != Main.tile[i, j].frameY)
					{
						Main.tile[i, j].frameX = num10;
						Main.tile[i, j].frameY = num11;
						SquareTileFrame(i, j);
					}
				}
			}
			catch
			{
				Main.tile[i, j].frameX = 0;
				Main.tile[i, j].frameY = 0;
			}
		}

		public static void GrowCactus(int i, int j)
		{
			int num = j;
			int num2 = i;
			if (Main.tile[i, j].active == 0 || Main.tile[i, j - 1].liquid > 0 || (Main.tile[i, j].type != 53 && Main.tile[i, j].type != 80 && Main.tile[i, j].type != 112 && Main.tile[i, j].type != 116))
			{
				return;
			}
			if (Main.tile[i, j].type == 53 || Main.tile[i, j].type == 112 || Main.tile[i, j].type == 116)
			{
				if (Main.tile[i, j - 1].active != 0 || Main.tile[i - 1, j - 1].active != 0 || Main.tile[i + 1, j - 1].active != 0)
				{
					return;
				}
				int num3 = 0;
				int num4 = 0;
				for (int k = i - 6; k <= i + 6; k++)
				{
					for (int l = j - 3; l <= j + 1; l++)
					{
						try
						{
							if (Main.tile[k, l].active != 0)
							{
								if (Main.tile[k, l].type == 80)
								{
									num3++;
									if (num3 >= 4)
									{
										return;
									}
								}
								if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 112 || Main.tile[k, l].type == 116)
								{
									num4++;
								}
							}
						}
						catch
						{
						}
					}
				}
				if (num4 > 10)
				{
					Main.tile[i, j - 1].active = 1;
					Main.tile[i, j - 1].type = 80;
					SquareTileFrame(num2, num - 1);
					if (Main.netMode == 2)
					{
						NetMessage.SendTile(i, j - 1);
					}
				}
			}
			else
			{
				if (Main.tile[i, j].type != 80)
				{
					return;
				}
				while (Main.tile[num2, num].active != 0 && Main.tile[num2, num].type == 80)
				{
					num++;
					if (Main.tile[num2, num].active == 0 || Main.tile[num2, num].type != 80)
					{
						if (Main.tile[num2 - 1, num].active != 0 && Main.tile[num2 - 1, num].type == 80 && Main.tile[num2 - 1, num - 1].active != 0 && Main.tile[num2 - 1, num - 1].type == 80 && num2 >= i)
						{
							num2--;
						}
						if (Main.tile[num2 + 1, num].active != 0 && Main.tile[num2 + 1, num].type == 80 && Main.tile[num2 + 1, num - 1].active != 0 && Main.tile[num2 + 1, num - 1].type == 80 && num2 <= i)
						{
							num2++;
						}
					}
				}
				num--;
				int num5 = num - j;
				int num6 = i - num2;
				num2 = i - num6;
				num = j;
				int num7 = 11 - num5;
				int num8 = 0;
				for (int m = num2 - 2; m <= num2 + 2; m++)
				{
					for (int n = num - num7; n <= num + num5; n++)
					{
						if (Main.tile[m, n].active != 0 && Main.tile[m, n].type == 80)
						{
							num8++;
						}
					}
				}
				if (num8 >= genRand.Next(11, 13))
				{
					return;
				}
				num2 = i;
				num = j;
				if (num6 == 0)
				{
					if (num5 == 0)
					{
						if (Main.tile[num2, num - 1].active == 0)
						{
							Main.tile[num2, num - 1].active = 1;
							Main.tile[num2, num - 1].type = 80;
							SquareTileFrame(num2, num - 1);
							if (Main.netMode == 2)
							{
								NetMessage.SendTile(num2, num - 1);
							}
						}
						return;
					}
					bool flag = false;
					bool flag2 = false;
					if (Main.tile[num2, num - 1].active != 0 && Main.tile[num2, num - 1].type == 80)
					{
						if (Main.tile[num2 - 1, num].active == 0 && Main.tile[num2 - 2, num + 1].active == 0 && Main.tile[num2 - 1, num - 1].active == 0 && Main.tile[num2 - 1, num + 1].active == 0 && Main.tile[num2 - 2, num].active == 0)
						{
							flag = true;
						}
						if (Main.tile[num2 + 1, num].active == 0 && Main.tile[num2 + 2, num + 1].active == 0 && Main.tile[num2 + 1, num - 1].active == 0 && Main.tile[num2 + 1, num + 1].active == 0 && Main.tile[num2 + 2, num].active == 0)
						{
							flag2 = true;
						}
					}
					int num9 = genRand.Next(3);
					if (num9 == 0 && flag)
					{
						Main.tile[num2 - 1, num].active = 1;
						Main.tile[num2 - 1, num].type = 80;
						SquareTileFrame(num2 - 1, num);
						if (Main.netMode == 2)
						{
							NetMessage.SendTile(num2 - 1, num);
						}
					}
					else if (num9 == 1 && flag2)
					{
						Main.tile[num2 + 1, num].active = 1;
						Main.tile[num2 + 1, num].type = 80;
						SquareTileFrame(num2 + 1, num);
						if (Main.netMode == 2)
						{
							NetMessage.SendTile(num2 + 1, num);
						}
					}
					else
					{
						if (num5 >= genRand.Next(2, 8))
						{
							return;
						}
						if (Main.tile[num2 - 1, num - 1].active != 0)
						{
							_ = Main.tile[num2 - 1, num - 1].type;
							_ = 80;
						}
						if ((Main.tile[num2 + 1, num - 1].active == 0 || Main.tile[num2 + 1, num - 1].type != 80) && Main.tile[num2, num - 1].active == 0)
						{
							Main.tile[num2, num - 1].active = 1;
							Main.tile[num2, num - 1].type = 80;
							SquareTileFrame(num2, num - 1);
							if (Main.netMode == 2)
							{
								NetMessage.SendTile(num2, num - 1);
							}
						}
					}
				}
				else if (Main.tile[num2, num - 1].active == 0 && Main.tile[num2, num - 2].active == 0 && Main.tile[num2 + num6, num - 1].active == 0 && Main.tile[num2 - num6, num - 1].active != 0 && Main.tile[num2 - num6, num - 1].type == 80)
				{
					Main.tile[num2, num - 1].active = 1;
					Main.tile[num2, num - 1].type = 80;
					SquareTileFrame(num2, num - 1);
					if (Main.netMode == 2)
					{
						NetMessage.SendTile(num2, num - 1);
					}
				}
			}
		}

		public static void CheckPot(int i, int j)
		{
			if (destroyObject)
			{
				return;
			}
			int num = 0;
			int num2 = j;
			num += Main.tile[i, j].frameX / 18;
			num2 -= Main.tile[i, j].frameY / 18;
			num &= 1;
			num = -num;
			num += i;
			for (int k = num; k < num + 2; k++)
			{
				int num3 = num2;
				while (true)
				{
					if (num3 < num2 + 2)
					{
						int num4 = (Main.tile[k, num3].frameX / 18) & 1;
						if (num4 == k - num && Main.tile[k, num3].active != 0 && Main.tile[k, num3].type == 28 && Main.tile[k, num3].frameY == (num3 - num2) * 18)
						{
							num3++;
							continue;
						}
					}
					else if (Main.tile[k, num2 + 2].active != 0 && Main.tileSolid[Main.tile[k, num2 + 2].type])
					{
						break;
					}
					destroyObject = true;
					for (int l = num; l < num + 2; l++)
					{
						for (int m = num2; m < num2 + 2; m++)
						{
							if (Main.tile[l, m].type == 28 && Main.tile[l, m].active != 0)
							{
								KillTile(l, m);
							}
						}
					}
					if (!gen)
					{
						Rectangle rect = default(Rectangle);
						rect.X = i << 4;
						rect.Y = j << 4;
						rect.Width = (rect.Height = 16);
						Main.PlaySound(13, rect.X, rect.Y);
						Gore.NewGore(new Vector2(rect.X, rect.Y), default(Vector2), 51);
						Gore.NewGore(new Vector2(rect.X, rect.Y), default(Vector2), 52);
						Gore.NewGore(new Vector2(rect.X, rect.Y), default(Vector2), 53);
						if (genRand.Next(40) == 0 && (Main.tile[num, num2].wall == 7 || Main.tile[num, num2].wall == 8 || Main.tile[num, num2].wall == 9))
						{
							Item.NewItem(rect.X, rect.Y, 16, 16, 327);
						}
						else if (genRand.Next(45) == 0)
						{
							if (j < Main.worldSurface)
							{
								int num5 = genRand.Next(4);
								if (num5 == 0)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 292);
								}
								if (num5 == 1)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 298);
								}
								if (num5 == 2)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 299);
								}
								if (num5 == 3)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 290);
								}
							}
							else if (j < Main.rockLayer)
							{
								int num6 = genRand.Next(7);
								if (num6 == 0)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 289);
								}
								if (num6 == 1)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 298);
								}
								if (num6 == 2)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 299);
								}
								if (num6 == 3)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 290);
								}
								if (num6 == 4)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 303);
								}
								if (num6 == 5)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 291);
								}
								if (num6 == 6)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 304);
								}
							}
							else if (j < Main.maxTilesY - 200)
							{
								int num7 = genRand.Next(10);
								if (num7 == 0)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 296);
								}
								if (num7 == 1)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 295);
								}
								if (num7 == 2)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 299);
								}
								if (num7 == 3)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 302);
								}
								if (num7 == 4)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 303);
								}
								if (num7 == 5)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 305);
								}
								if (num7 == 6)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 301);
								}
								if (num7 == 7)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 302);
								}
								if (num7 == 8)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 297);
								}
								if (num7 == 9)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 304);
								}
							}
							else
							{
								int num8 = genRand.Next(12);
								if (num8 == 0)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 296);
								}
								if (num8 == 1)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 295);
								}
								if (num8 == 2)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 293);
								}
								if (num8 == 3)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 288);
								}
								if (num8 == 4)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 294);
								}
								if (num8 == 5)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 297);
								}
								if (num8 == 6)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 304);
								}
								if (num8 == 7)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 305);
								}
								if (num8 == 8)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 301);
								}
								if (num8 == 9)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 302);
								}
								if (num8 == 10)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 288);
								}
								if (num8 == 11)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 300);
								}
							}
						}
						else
						{
							int num9 = Main.rand.Next(8);
							if (num9 == 0)
							{
								Player player = Player.FindClosest(ref rect);
								if (player.statLife < player.statLifeMax)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 58);
								}
							}
							else if (num9 == 1)
							{
								Player player2 = Player.FindClosest(ref rect);
								if (player2.statMana < player2.statManaMax)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 184);
								}
							}
							else if (num9 == 2)
							{
								int stack = Main.rand.Next(1, 6);
								if (Main.tile[i, j].liquid > 0)
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 282, stack);
								}
								else
								{
									Item.NewItem(rect.X, rect.Y, 16, 16, 8, stack);
								}
							}
							else if (num9 == 3)
							{
								int stack2 = Main.rand.Next(8) + 3;
								int type = 40;
								if (j < Main.rockLayer && genRand.Next(2) == 0)
								{
									type = ((!Main.hardMode) ? 42 : 168);
								}
								if (j > Main.maxTilesY - 200)
								{
									type = 265;
								}
								else if (Main.hardMode)
								{
									type = ((Main.rand.Next(2) != 0) ? 47 : 278);
								}
								Item.NewItem(rect.X, rect.Y, 16, 16, type, stack2);
							}
							else if (num9 == 4)
							{
								int type2 = 28;
								if (j > Main.maxTilesY - 200 || Main.hardMode)
								{
									type2 = 188;
								}
								Item.NewItem(rect.X, rect.Y, 16, 16, type2);
							}
							else if (num9 == 5 && j > Main.rockLayer)
							{
								int stack3 = Main.rand.Next(4) + 1;
								Item.NewItem(rect.X, rect.Y, 16, 16, 166, stack3);
							}
							else
							{
								float num10 = 200 + genRand.Next(-100, 101);
								if (j < Main.worldSurface)
								{
									num10 *= 0.5f;
								}
								else if (j < Main.rockLayer)
								{
									num10 *= 0.75f;
								}
								else if (j > Main.maxTilesY - 250)
								{
									num10 *= 1.25f;
								}
								num10 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
								if (Main.rand.Next(5) == 0)
								{
									num10 *= 1f + (float)Main.rand.Next(5, 11) * 0.01f;
								}
								if (Main.rand.Next(10) == 0)
								{
									num10 *= 1f + (float)Main.rand.Next(10, 21) * 0.01f;
								}
								if (Main.rand.Next(15) == 0)
								{
									num10 *= 1f + (float)Main.rand.Next(20, 41) * 0.01f;
								}
								if (Main.rand.Next(20) == 0)
								{
									num10 *= 1f + (float)Main.rand.Next(40, 81) * 0.01f;
								}
								if (Main.rand.Next(25) == 0)
								{
									num10 *= 1f + (float)Main.rand.Next(50, 101) * 0.01f;
								}
								while ((int)num10 > 0)
								{
									if (num10 > 1000000f)
									{
										int num11 = (int)(num10 / 1000000f);
										if (num11 > 50 && Main.rand.Next(2) == 0)
										{
											num11 /= Main.rand.Next(3) + 1;
										}
										if (Main.rand.Next(2) == 0)
										{
											num11 /= Main.rand.Next(3) + 1;
										}
										if (num11 > 0)
										{
											num10 -= (float)(1000000 * num11);
											Item.NewItem(rect.X, rect.Y, 16, 16, 74, num11);
										}
										continue;
									}
									if (num10 > 10000f)
									{
										int num12 = (int)(num10 / 10000f);
										if (num12 > 50 && Main.rand.Next(2) == 0)
										{
											num12 /= Main.rand.Next(3) + 1;
										}
										if (Main.rand.Next(2) == 0)
										{
											num12 /= Main.rand.Next(3) + 1;
										}
										if (num12 > 0)
										{
											num10 -= (float)(10000 * num12);
											Item.NewItem(rect.X, rect.Y, 16, 16, 73, num12);
										}
										continue;
									}
									if (num10 > 100f)
									{
										int num13 = (int)(num10 / 100f);
										if (num13 > 50 && Main.rand.Next(2) == 0)
										{
											num13 /= Main.rand.Next(3) + 1;
										}
										if (Main.rand.Next(2) == 0)
										{
											num13 /= Main.rand.Next(3) + 1;
										}
										if (num13 > 0)
										{
											num10 -= (float)(100 * num13);
											Item.NewItem(rect.X, rect.Y, 16, 16, 72, num13);
										}
										continue;
									}
									int num14 = (int)num10;
									if (num14 > 50 && Main.rand.Next(2) == 0)
									{
										num14 /= Main.rand.Next(3) + 1;
									}
									if (Main.rand.Next(2) == 0)
									{
										num14 /= Main.rand.Next(4) + 1;
									}
									if (num14 < 1)
									{
										num14 = 1;
									}
									num10 -= (float)num14;
									Item.NewItem(rect.X, rect.Y, 16, 16, 71, num14);
								}
							}
						}
					}
					destroyObject = false;
					return;
				}
			}
		}

		public static int PlaceChest(int x, int y, bool notNearOtherChests = false, int style = 0)
		{
			for (int i = x; i < x + 2; i++)
			{
				for (int j = y - 1; j < y + 1; j++)
				{
					if (Main.tile[i, j].active != 0)
					{
						return -1;
					}
					if (Main.tile[i, j].lava != 0)
					{
						return -1;
					}
				}
				if (Main.tile[i, y + 1].active == 0 || !Main.tileSolid[Main.tile[i, y + 1].type])
				{
					return -1;
				}
			}
			if (notNearOtherChests)
			{
				for (int k = x - 25; k < x + 25; k++)
				{
					for (int l = y - 8; l < y + 8; l++)
					{
						try
						{
							if (Main.tile[k, l].active != 0 && Main.tile[k, l].type == 21)
							{
								return -1;
							}
						}
						catch
						{
						}
					}
				}
			}
			int num = Chest.CreateChest(x, y - 1);
			if (num != -1)
			{
				Main.tile[x, y - 1].active = 1;
				Main.tile[x, y - 1].frameY = 0;
				Main.tile[x, y - 1].frameX = (short)(36 * style);
				Main.tile[x, y - 1].type = 21;
				Main.tile[x + 1, y - 1].active = 1;
				Main.tile[x + 1, y - 1].frameY = 0;
				Main.tile[x + 1, y - 1].frameX = (short)(18 + 36 * style);
				Main.tile[x + 1, y - 1].type = 21;
				Main.tile[x, y].active = 1;
				Main.tile[x, y].frameY = 18;
				Main.tile[x, y].frameX = (short)(36 * style);
				Main.tile[x, y].type = 21;
				Main.tile[x + 1, y].active = 1;
				Main.tile[x + 1, y].frameY = 18;
				Main.tile[x + 1, y].frameX = (short)(18 + 36 * style);
				Main.tile[x + 1, y].type = 21;
			}
			return num;
		}

		public static void CheckChest(int i, int j)
		{
			if (destroyObject)
			{
				return;
			}
			int num = 0;
			int num2 = j;
			num += Main.tile[i, j].frameX / 18;
			num2 -= Main.tile[i, j].frameY / 18;
			num &= 1;
			num = -num;
			num += i;
			for (int k = num; k < num + 2; k++)
			{
				int num3 = num2;
				while (true)
				{
					if (num3 < num2 + 2)
					{
						int num4 = (Main.tile[k, num3].frameX / 18) & 1;
						if (Main.tile[k, num3].active != 0 && Main.tile[k, num3].type == 21 && num4 == k - num && Main.tile[k, num3].frameY == (num3 - num2) * 18)
						{
							num3++;
							continue;
						}
					}
					else if (Main.tile[k, num2 + 2].active != 0 && Main.tileSolid[Main.tile[k, num2 + 2].type])
					{
						break;
					}
					int type = 48;
					if (Main.tile[i, j].frameX >= 216)
					{
						type = 348;
					}
					else if (Main.tile[i, j].frameX >= 180)
					{
						type = 343;
					}
					else if (Main.tile[i, j].frameX >= 108)
					{
						type = 328;
					}
					else if (Main.tile[i, j].frameX >= 36)
					{
						type = 306;
					}
					destroyObject = true;
					for (int l = num; l < num + 2; l++)
					{
						for (int m = num2; m < num2 + 3; m++)
						{
							if (Main.tile[l, m].type == 21 && Main.tile[l, m].active != 0)
							{
								Chest.DestroyChest(l, m);
								KillTile(l, m);
							}
						}
					}
					if (!gen)
					{
						Item.NewItem(i * 16, j * 16, 32, 32, type);
					}
					destroyObject = false;
					return;
				}
			}
		}

		public static bool PlaceWire(int i, int j)
		{
			if (Main.tile[i, j].wire == 0)
			{
				Main.tile[i, j].wire = 16;
				Main.PlaySound(0, i << 4, j << 4);
				return true;
			}
			return false;
		}

		public unsafe static bool KillWire(int i, int j)
		{
			if (Main.tile[i, j].wire != 0)
			{
				Main.tile[i, j].wire = 0;
				i <<= 4;
				j <<= 4;
				Main.PlaySound(0, i, j);
				if (Main.netMode != 1)
				{
					Item.NewItem(i, j, 16, 16, 530);
				}
				for (int k = 0; k < 3; k++)
				{
					if (null == Main.dust.NewDust(i, j, 16, 16, 50))
					{
						break;
					}
				}
				return true;
			}
			return false;
		}

		public static bool CanPlaceTile(int i, ref int j, int type, int style = 0)
		{
			if (i >= 0 && j >= 0 && i < Main.maxTilesX && j < Main.maxTilesY)
			{
				if (style >= 0 && Main.tile[i, j].active == 0 && Main.tileSolid[type] && Collision.AnyPlayerOrNPC(i, j, 1))
				{
					return false;
				}
				switch (type)
				{
				case 3:
				case 24:
				case 27:
				case 32:
				case 51:
				case 69:
				case 72:
					return Main.tile[i, j].liquid == 0;
				case 4:
					if ((Main.tile[i - 1, j].active != 0 && (Main.tileSolid[Main.tile[i - 1, j].type] || Main.tile[i - 1, j].type == 124 || (Main.tile[i - 1, j].type == 5 && Main.tile[i - 1, j - 1].type == 5 && Main.tile[i - 1, j + 1].type == 5))) || (Main.tile[i + 1, j].active != 0 && (Main.tileSolid[Main.tile[i + 1, j].type] || Main.tile[i + 1, j].type == 124 || (Main.tile[i + 1, j].type == 5 && Main.tile[i + 1, j - 1].type == 5 && Main.tile[i + 1, j + 1].type == 5))) || (Main.tile[i, j + 1].active != 0 && Main.tileSolid[Main.tile[i, j + 1].type]))
					{
						if (style != 8)
						{
							return Main.tile[i, j].liquid == 0;
						}
						return true;
					}
					return false;
				case 10:
					if (Main.tile[i, j - 1].active == 0 && Main.tile[i, j - 2].active == 0 && Main.tile[i, j - 3].active != 0 && Main.tileSolid[Main.tile[i, j - 3].type])
					{
						j--;
						return true;
					}
					if (Main.tile[i, j + 1].active == 0 && Main.tile[i, j + 2].active == 0 && Main.tile[i, j + 3].active != 0 && Main.tileSolid[Main.tile[i, j + 3].type])
					{
						j++;
						return true;
					}
					return false;
				case 20:
					if (Main.tile[i, j + 1].active != 0 && (Main.tile[i, j + 1].type == 2 || Main.tile[i, j + 1].type == 109 || Main.tile[i, j + 1].type == 147))
					{
						return Main.tile[i, j].liquid == 0;
					}
					return false;
				case 2:
				case 23:
				case 109:
					if (Main.tile[i, j].type == 0)
					{
						return Main.tile[i, j].active != 0;
					}
					return false;
				case 60:
				case 70:
					if (Main.tile[i, j].type == 59)
					{
						return Main.tile[i, j].active != 0;
					}
					return false;
				case 61:
				case 71:
					if (j + 1 < Main.maxTilesY && Main.tile[i, j + 1].active != 0)
					{
						return Main.tile[i, j + 1].type == type - 1;
					}
					return false;
				case 81:
					if (Main.tile[i - 1, j].active != 0 || Main.tile[i + 1, j].active != 0 || Main.tile[i, j - 1].active != 0)
					{
						return false;
					}
					if (Main.tile[i, j + 1].active == 0 || !Main.tileSolid[Main.tile[i, j + 1].type])
					{
						return false;
					}
					break;
				case 136:
					if ((Main.tile[i - 1, j].active == 0 || (!Main.tileSolid[Main.tile[i - 1, j].type] && Main.tile[i - 1, j].type != 124 && (Main.tile[i - 1, j].type != 5 || Main.tile[i - 1, j - 1].type != 5 || Main.tile[i - 1, j + 1].type != 5))) && (Main.tile[i + 1, j].active == 0 || (!Main.tileSolid[Main.tile[i + 1, j].type] && Main.tile[i + 1, j].type != 124 && (Main.tile[i + 1, j].type != 5 || Main.tile[i + 1, j - 1].type != 5 || Main.tile[i + 1, j + 1].type != 5))))
					{
						if (Main.tile[i, j + 1].active != 0)
						{
							return Main.tileSolid[Main.tile[i, j + 1].type];
						}
						return false;
					}
					return true;
				case 129:
				case 149:
					if (!SolidTileUnsafe(i - 1, j) && !SolidTileUnsafe(i + 1, j) && !SolidTileUnsafe(i, j - 1))
					{
						return SolidTileUnsafe(i, j + 1);
					}
					return true;
				}
				return true;
			}
			return false;
		}

		public unsafe static bool PlaceTile(int i, int j, int type, bool mute = false, bool forced = false, int plr = -1, int style = 0)
		{
			bool flag = false;
			fixed (Tile* ptr = &Main.tile[i, j])
			{
				if (CanPlaceTile(i, ref j, type, style) || forced)
				{
					ptr->frameX = 0;
					ptr->frameY = 0;
					switch (type)
					{
					case 3:
					case 24:
					case 110:
						if (j + 1 < Main.maxTilesY && ptr[1].active != 0 && ((type == 3 && ptr[1].type == 2) || (type == 24 && ptr[1].type == 23) || (type == 3 && ptr[1].type == 78) || (type == 110 && ptr[1].type == 109)))
						{
							if (type == 24 && genRand.Next(13) == 0)
							{
								type = 32;
								flag = true;
							}
							else if (ptr[1].type == 78)
							{
								ptr->frameX = (short)(genRand.Next(2) * 18 + 108);
								flag = true;
							}
							else if (ptr->wall == 0 && ptr[1].wall == 0)
							{
								if (genRand.Next(50) == 0 || (type == 24 && genRand.Next(40) == 0))
								{
									ptr->frameX = 144;
								}
								else if (genRand.Next(35) == 0)
								{
									ptr->frameX = (short)(genRand.Next(2) * 18 + 108);
								}
								else
								{
									ptr->frameX = (short)(genRand.Next(6) * 18);
								}
								flag = true;
							}
							if (flag)
							{
								ptr->active = 1;
								ptr->type = (byte)type;
							}
						}
						break;
					case 61:
						ptr->active = 1;
						if (genRand.Next(16) == 0 && j > Main.worldSurface)
						{
							ptr->type = 69;
						}
						else
						{
							ptr->type = (byte)type;
							if (j > Main.rockLayer && genRand.Next(60) == 0)
							{
								ptr->frameX = 144;
							}
							else if (j > Main.rockLayer && genRand.Next(1000) == 0)
							{
								ptr->frameX = 162;
							}
							else if (genRand.Next(15) == 0)
							{
								ptr->frameX = (short)(genRand.Next(2) * 18 + 108);
							}
							else
							{
								ptr->frameX = (short)(genRand.Next(6) * 18);
							}
						}
						flag = true;
						break;
					case 71:
						ptr->active = 1;
						ptr->type = (byte)type;
						ptr->frameX = (short)(genRand.Next(5) * 18);
						flag = true;
						break;
					case 129:
						ptr->active = 1;
						ptr->type = (byte)type;
						ptr->frameX = (short)(genRand.Next(8) * 18);
						flag = true;
						break;
					case 136:
						ptr->active = 1;
						ptr->type = (byte)type;
						flag = true;
						break;
					case 4:
						ptr->active = 1;
						ptr->type = (byte)type;
						ptr->frameY = (short)(22 * style);
						flag = true;
						break;
					case 10:
						flag = PlaceDoor(i, j, type);
						break;
					case 128:
						flag = PlaceMan(i, j, style);
						break;
					case 149:
						ptr->active = 1;
						ptr->type = (byte)type;
						ptr->frameX = (short)(18 * style);
						flag = true;
						break;
					case 139:
						flag = PlaceMB(i, j, type, style);
						break;
					case 34:
					case 35:
					case 36:
					case 106:
						flag = Place3x3(i, j, type);
						break;
					case 13:
					case 33:
					case 49:
					case 50:
					case 78:
						flag = PlaceOnTable1x1(i, j, type, style);
						break;
					case 14:
					case 26:
					case 86:
					case 87:
					case 88:
					case 89:
					case 114:
						flag = Place3x2(i, j, type);
						break;
					case 15:
					case 20:
						flag = Place1x2(i, j, type, style);
						break;
					case 16:
					case 18:
					case 29:
					case 103:
					case 134:
						flag = Place2x1(i, j, type);
						break;
					case 92:
					case 93:
						flag = Place1xX(i, j, type);
						break;
					case 104:
					case 105:
						flag = Place2xX(i, j, type, style);
						break;
					case 17:
					case 77:
					case 133:
						flag = Place3x2(i, j, type);
						break;
					case 21:
						flag = (PlaceChest(i, j, notNearOtherChests: false, style) >= 0);
						break;
					case 91:
						flag = PlaceBanner(i, j, type, style);
						break;
					case 135:
					case 141:
					case 144:
						flag = Place1x1(i, j, type, style);
						break;
					case 101:
					case 102:
						flag = Place3x4(i, j, type);
						break;
					case 27:
						flag = PlaceSunflower(i, j);
						break;
					case 28:
						flag = PlacePot(i, j);
						break;
					case 42:
						flag = Place1x2Top(i, j, type);
						break;
					case 55:
					case 85:
						flag = PlaceSign(i, j, type);
						break;
					case 82:
					case 83:
					case 84:
						flag = PlaceAlch(i, j, style);
						break;
					default:
						switch (type)
						{
						case 94:
						case 95:
						case 96:
						case 97:
						case 98:
						case 99:
						case 100:
						case 125:
						case 126:
						case 132:
						case 138:
						case 142:
						case 143:
							flag = Place2x2(i, j, type);
							break;
						case 79:
						case 90:
							flag = Place4x2(i, j, type, (plr < 0) ? 1 : Main.player[plr].direction);
							break;
						default:
							ptr->active = 1;
							ptr->type = (byte)type;
							switch (type)
							{
							case 81:
								ptr->frameX = (short)(26 * genRand.Next(6));
								break;
							case 137:
								if (style == 1)
								{
									ptr->frameX = 18;
								}
								break;
							}
							flag = true;
							break;
						}
						break;
					}
					if (flag && !mute && !gen)
					{
						SquareTileFrame(i, j);
						if (type == 127)
						{
							Main.PlaySound(2, i * 16, j * 16, 30);
						}
						else
						{
							Main.PlaySound(0, i * 16, j * 16);
							if (type == 22 || type == 140)
							{
								Main.dust.NewDust(i * 16, j * 16, 16, 16, 14);
								Main.dust.NewDust(i * 16, j * 16, 16, 16, 14);
							}
						}
					}
				}
			}
			return flag;
		}

		public static void UpdateMech()
		{
			for (int num = numMechs - 1; num >= 0; num--)
			{
				mech[num].Time--;
				if (Main.tile[mech[num].X, mech[num].Y].active != 0 && Main.tile[mech[num].X, mech[num].Y].type == 144)
				{
					if (Main.tile[mech[num].X, mech[num].Y].frameY == 0)
					{
						mech[num].Time = 0;
					}
					else
					{
						int num2 = Main.tile[mech[num].X, mech[num].Y].frameX / 18;
						switch (num2)
						{
						case 0:
							num2 = 60;
							break;
						case 1:
							num2 = 180;
							break;
						case 2:
							num2 = 300;
							break;
						}
						if (Math.IEEERemainder(mech[num].Time, num2) == 0.0)
						{
							mech[num].Time = 18000;
							TripWire(mech[num].X, mech[num].Y);
						}
					}
				}
				if (mech[num].Time <= 0)
				{
					if (Main.tile[mech[num].X, mech[num].Y].active != 0 && Main.tile[mech[num].X, mech[num].Y].type == 144)
					{
						Main.tile[mech[num].X, mech[num].Y].frameY = 0;
						NetMessage.SendTile(mech[num].X, mech[num].Y);
					}
					for (int i = num; i < numMechs; i++)
					{
						mech[i] = mech[i + 1];
					}
					numMechs--;
				}
			}
		}

		public static bool checkMech(int i, int j, int time)
		{
			for (int k = 0; k < numMechs; k++)
			{
				if (mech[k].X == i && mech[k].Y == j)
				{
					return false;
				}
			}
			if (numMechs < 999)
			{
				mech[numMechs].X = (short)i;
				mech[numMechs].Y = (short)j;
				mech[numMechs].Time = time;
				numMechs++;
				return true;
			}
			return false;
		}

		public static void hitSwitch(int i, int j)
		{
			if (Main.tile[i, j].type == 135)
			{
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(i, j);
			}
			else if (Main.tile[i, j].type == 136)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(i, j);
			}
			else if (Main.tile[i, j].type == 144)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
					if (Main.netMode != 1)
					{
						checkMech(i, j, 18000);
					}
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				Main.PlaySound(28, i * 16, j * 16, 0);
			}
			else
			{
				if (Main.tile[i, j].type != 132)
				{
					return;
				}
				int num = i;
				int num2 = j;
				short num3 = 36;
				num = Main.tile[i, j].frameX / 18 * -1;
				num2 = Main.tile[i, j].frameY / 18 * -1;
				if (num < -1)
				{
					num += 2;
					num3 = -36;
				}
				num += i;
				num2 += j;
				for (int k = num; k < num + 2; k++)
				{
					for (int l = num2; l < num2 + 2; l++)
					{
						if (Main.tile[k, l].type == 132)
						{
							Main.tile[k, l].frameX += num3;
						}
					}
				}
				TileFrame(num, num2);
				Main.PlaySound(28, i * 16, j * 16, 0);
				for (int m = num; m < num + 2; m++)
				{
					for (int n = num2; n < num2 + 2; n++)
					{
						if (Main.tile[m, n].type == 132 && Main.tile[m, n].active != 0 && Main.tile[m, n].wire != 0)
						{
							TripWire(m, n);
							return;
						}
					}
				}
			}
		}

		public static void TripWire(int i, int j)
		{
			if (Main.netMode != 1)
			{
				numWire = 0;
				numNoWire = 0;
				numInPump = 0;
				numOutPump = 0;
				NoWire(i, j);
				hitWire(i, j);
				if (numInPump > 0 && numOutPump > 0)
				{
					xferWater();
				}
			}
		}

		public static void xferWater()
		{
			for (int i = 0; i < numInPump; i++)
			{
				int x = inPump[i].X;
				int y = inPump[i].Y;
				int liquid = Main.tile[x, y].liquid;
				if (liquid <= 0)
				{
					continue;
				}
				int lava = Main.tile[x, y].lava;
				for (int j = 0; j < numOutPump; j++)
				{
					int x2 = outPump[j].X;
					int y2 = outPump[j].Y;
					int liquid2 = Main.tile[x2, y2].liquid;
					if (liquid2 >= 255)
					{
						continue;
					}
					int num = Main.tile[x2, y2].lava;
					if (liquid2 == 0)
					{
						num = lava;
					}
					if (lava == num)
					{
						int num2 = liquid;
						if (num2 + liquid2 > 255)
						{
							num2 = 255 - liquid2;
						}
						Main.tile[x2, y2].liquid += (byte)num2;
						Main.tile[x, y].liquid -= (byte)num2;
						liquid = Main.tile[x, y].liquid;
						Main.tile[x2, y2].lava = (byte)lava;
						SquareTileFrame(x2, y2);
						if (Main.tile[x, y].liquid == 0)
						{
							Main.tile[x, y].lava = 0;
							SquareTileFrame(x, y);
							break;
						}
					}
				}
				SquareTileFrame(x, y);
			}
		}

		public static void NoWire(int i, int j)
		{
			if (numNoWire < 999)
			{
				noWire[numNoWire].X = (short)i;
				noWire[numNoWire].Y = (short)j;
				numNoWire++;
			}
		}

		public static void hitWire(int i, int j)
		{
			if (numWire >= 999 || Main.tile[i, j].wire == 0)
			{
				return;
			}
			for (int k = 0; k < numWire; k++)
			{
				if (wire[k].X == i && wire[k].Y == j)
				{
					return;
				}
			}
			wire[numWire].X = (short)i;
			wire[numWire].Y = (short)j;
			numWire++;
			int type = Main.tile[i, j].type;
			bool flag = true;
			for (int l = 0; l < numNoWire; l++)
			{
				if (noWire[l].X == i && noWire[l].Y == j)
				{
					flag = false;
				}
			}
			if (flag && Main.tile[i, j].active != 0)
			{
				switch (type)
				{
				case 144:
					hitSwitch(i, j);
					SquareTileFrame(i, j);
					NetMessage.SendTile(i, j);
					break;
				case 130:
					Main.tile[i, j].type = 131;
					SquareTileFrame(i, j);
					NetMessage.SendTile(i, j);
					break;
				case 131:
					Main.tile[i, j].type = 130;
					SquareTileFrame(i, j);
					NetMessage.SendTile(i, j);
					break;
				case 11:
					CloseDoor(i, j, forced: true);
					NetMessage.CreateMessage2(24, i, j);
					NetMessage.SendMessage();
					break;
				case 10:
				{
					int direction = (Main.rand.Next(2) << 1) - 1;
					direction = OpenDoor(i, j, direction);
					if (direction != 0)
					{
						NetMessage.CreateMessage3(19, i, j, direction);
						NetMessage.SendMessage();
					}
					break;
				}
				case 4:
					if (Main.tile[i, j].frameX < 66)
					{
						Main.tile[i, j].frameX += 66;
					}
					else
					{
						Main.tile[i, j].frameX -= 66;
					}
					NetMessage.SendTile(i, j);
					break;
				case 149:
					if (Main.tile[i, j].frameX < 54)
					{
						Main.tile[i, j].frameX += 54;
					}
					else
					{
						Main.tile[i, j].frameX -= 54;
					}
					NetMessage.SendTile(i, j);
					break;
				case 42:
				{
					int num31 = j - Main.tile[i, j].frameY / 18;
					short num32 = 18;
					if (Main.tile[i, j].frameX > 0)
					{
						num32 = -18;
					}
					Main.tile[i, num31].frameX += num32;
					Main.tile[i, num31 + 1].frameX += num32;
					NoWire(i, num31);
					NoWire(i, num31 + 1);
					NetMessage.SendTileSquare(i, j, 2);
					break;
				}
				case 93:
				{
					int num28 = j - Main.tile[i, j].frameY / 18;
					short num29 = 18;
					if (Main.tile[i, j].frameX > 0)
					{
						num29 = -18;
					}
					Main.tile[i, num28].frameX += num29;
					Main.tile[i, num28 + 1].frameX += num29;
					Main.tile[i, num28 + 2].frameX += num29;
					NoWire(i, num28);
					NoWire(i, num28 + 1);
					NoWire(i, num28 + 2);
					NetMessage.SendTileSquare(i, num28 + 1, 3);
					break;
				}
				case 95:
				case 100:
				case 126:
				{
					int num11 = j - Main.tile[i, j].frameY / 18;
					int num12 = Main.tile[i, j].frameX / 18;
					if (num12 > 1)
					{
						num12 -= 2;
					}
					num12 = i - num12;
					short num13 = 36;
					if (Main.tile[num12, num11].frameX > 0)
					{
						num13 = -36;
					}
					Main.tile[num12, num11].frameX += num13;
					Main.tile[num12, num11 + 1].frameX += num13;
					Main.tile[num12 + 1, num11].frameX += num13;
					Main.tile[num12 + 1, num11 + 1].frameX += num13;
					NoWire(num12, num11);
					NoWire(num12, num11 + 1);
					NoWire(num12 + 1, num11);
					NoWire(num12 + 1, num11 + 1);
					NetMessage.SendTileSquare(num12, num11, 3);
					break;
				}
				case 34:
				case 35:
				case 36:
				{
					int num23 = j - Main.tile[i, j].frameY / 18;
					int num24 = Main.tile[i, j].frameX / 18;
					if (num24 > 2)
					{
						num24 -= 3;
					}
					num24 = i - num24;
					short num25 = 54;
					if (Main.tile[num24, num23].frameX > 0)
					{
						num25 = -54;
					}
					for (int num26 = num24; num26 < num24 + 3; num26++)
					{
						for (int num27 = num23; num27 < num23 + 3; num27++)
						{
							Main.tile[num26, num27].frameX += num25;
							NoWire(num26, num27);
						}
					}
					NetMessage.SendTileSquare(num24 + 1, num23 + 1, 3);
					break;
				}
				case 33:
				{
					short num14 = 18;
					if (Main.tile[i, j].frameX > 0)
					{
						num14 = -18;
					}
					Main.tile[i, j].frameX += num14;
					NetMessage.SendTileSquare(i, j, 3);
					break;
				}
				case 92:
				{
					int num33 = j - Main.tile[i, j].frameY / 18;
					short num34 = 18;
					if (Main.tile[i, j].frameX > 0)
					{
						num34 = -18;
					}
					Main.tile[i, num33].frameX += num34;
					Main.tile[i, num33 + 1].frameX += num34;
					Main.tile[i, num33 + 2].frameX += num34;
					Main.tile[i, num33 + 3].frameX += num34;
					Main.tile[i, num33 + 4].frameX += num34;
					Main.tile[i, num33 + 5].frameX += num34;
					NoWire(i, num33);
					NoWire(i, num33 + 1);
					NoWire(i, num33 + 2);
					NoWire(i, num33 + 3);
					NoWire(i, num33 + 4);
					NoWire(i, num33 + 5);
					NetMessage.SendTileSquare(i, num33 + 3, 7);
					break;
				}
				case 137:
					if (checkMech(i, j, 180))
					{
						int num30 = -1;
						if (Main.tile[i, j].frameX != 0)
						{
							num30 = 1;
						}
						float speedX = 12 * num30;
						int damage = 20;
						int type2 = 98;
						Vector2 vector = new Vector2(i * 16 + 8, j * 16 + 7);
						vector.X += 10 * num30;
						vector.Y += 2f;
						Projectile.NewProjectile((int)vector.X, (int)vector.Y, speedX, 0f, type2, damage, 2f);
					}
					break;
				case 139:
					SwitchMB(i, j);
					break;
				case 141:
					KillTile(i, j, fail: false, effectOnly: false, noItem: true);
					NetMessage.SendTile(i, j);
					Projectile.NewProjectile(i * 16 + 8, j * 16 + 8, 0f, 0f, 108, 250, 10f);
					break;
				case 142:
				case 143:
				{
					int num15 = j - Main.tile[i, j].frameY / 18;
					int num16 = Main.tile[i, j].frameX / 18;
					if (num16 > 1)
					{
						num16 -= 2;
					}
					num16 = i - num16;
					NoWire(num16, num15);
					NoWire(num16, num15 + 1);
					NoWire(num16 + 1, num15);
					NoWire(num16 + 1, num15 + 1);
					if (type == 142)
					{
						int num17 = num16;
						int num18 = num15;
						for (int num19 = 0; num19 < 4; num19++)
						{
							if (numInPump >= 19)
							{
								break;
							}
							switch (num19)
							{
							case 0:
								num17 = num16;
								num18 = num15 + 1;
								break;
							case 1:
								num17 = num16 + 1;
								num18 = num15 + 1;
								break;
							case 2:
								num17 = num16;
								num18 = num15;
								break;
							default:
								num17 = num16 + 1;
								num18 = num15;
								break;
							}
							inPump[numInPump].X = (short)num17;
							inPump[numInPump].Y = (short)num18;
							numInPump++;
						}
						break;
					}
					int num20 = num16;
					int num21 = num15;
					for (int num22 = 0; num22 < 4; num22++)
					{
						if (numOutPump >= 19)
						{
							break;
						}
						switch (num22)
						{
						case 0:
							num20 = num16;
							num21 = num15 + 1;
							break;
						case 1:
							num20 = num16 + 1;
							num21 = num15 + 1;
							break;
						case 2:
							num20 = num16;
							num21 = num15;
							break;
						default:
							num20 = num16 + 1;
							num21 = num15;
							break;
						}
						outPump[numOutPump].X = (short)num20;
						outPump[numOutPump].Y = (short)num21;
						numOutPump++;
					}
					break;
				}
				case 105:
				{
					int num = j - Main.tile[i, j].frameY / 18;
					int num2 = Main.tile[i, j].frameX / 18;
					int num3 = num2 >> 1;
					num2 = i - (num2 & 1);
					NoWire(num2, num);
					NoWire(num2, num + 1);
					NoWire(num2, num + 2);
					NoWire(num2 + 1, num);
					NoWire(num2 + 1, num + 1);
					NoWire(num2 + 1, num + 2);
					int num4 = num2 * 16 + 16;
					int num5 = (num + 3) * 16;
					int num6 = -1;
					switch (num3)
					{
					case 4:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 1))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 1);
						}
						break;
					case 7:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 49))
						{
							num6 = NPC.NewNPC(num4 - 4, num5 - 6, 49);
						}
						break;
					case 8:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 55))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 55);
						}
						break;
					case 9:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 46))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 46);
						}
						break;
					case 10:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 21))
						{
							num6 = NPC.NewNPC(num4, num5, 21);
						}
						break;
					case 18:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 67))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 67);
						}
						break;
					case 23:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 63))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 63);
						}
						break;
					case 27:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 85))
						{
							num6 = NPC.NewNPC(num4 - 9, num5, 85);
						}
						break;
					case 28:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 74))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 74);
						}
						break;
					case 42:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 58))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 58);
						}
						break;
					case 37:
						if (checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 58))
						{
							Item.NewItem(num4, num5 - 16, 0, 0, 58);
						}
						break;
					case 2:
						if (checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 184))
						{
							Item.NewItem(num4, num5 - 16, 0, 0, 184);
						}
						break;
					case 17:
						if (checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 166))
						{
							Item.NewItem(num4, num5 - 20, 0, 0, 166);
						}
						break;
					case 40:
					{
						if (!checkMech(i, j, 300))
						{
							break;
						}
						int[] array2 = new int[10];
						int num9 = 0;
						for (int n = 0; n < 196; n++)
						{
							if (Main.npc[n].active != 0 && (Main.npc[n].type == 17 || Main.npc[n].type == 19 || Main.npc[n].type == 22 || Main.npc[n].type == 38 || Main.npc[n].type == 54 || Main.npc[n].type == 107 || Main.npc[n].type == 108))
							{
								array2[num9] = n;
								num9++;
								if (num9 >= 9)
								{
									break;
								}
							}
						}
						if (num9 > 0)
						{
							int num10 = array2[Main.rand.Next(num9)];
							Main.npc[num10].aabb.X = num4 - (Main.npc[num10].width >> 1);
							Main.npc[num10].aabb.Y = num5 - Main.npc[num10].height - 1;
							Main.npc[num10].position.X = Main.npc[num10].aabb.X;
							Main.npc[num10].position.Y = Main.npc[num10].aabb.Y;
							NetMessage.CreateMessage1(23, num10);
							NetMessage.SendMessage();
						}
						break;
					}
					case 41:
					{
						if (!checkMech(i, j, 300))
						{
							break;
						}
						int[] array = new int[10];
						int num7 = 0;
						for (int m = 0; m < 196; m++)
						{
							if (Main.npc[m].active != 0 && (Main.npc[m].type == 18 || Main.npc[m].type == 20 || Main.npc[m].type == 124))
							{
								array[num7] = m;
								num7++;
								if (num7 >= 9)
								{
									break;
								}
							}
						}
						if (num7 > 0)
						{
							int num8 = array[Main.rand.Next(num7)];
							Main.npc[num8].aabb.X = num4 - (Main.npc[num8].width >> 1);
							Main.npc[num8].aabb.Y = num5 - Main.npc[num8].height - 1;
							Main.npc[num8].position.X = Main.npc[num8].aabb.X;
							Main.npc[num8].position.Y = Main.npc[num8].aabb.Y;
							NetMessage.CreateMessage1(23, num8);
							NetMessage.SendMessage();
						}
						break;
					}
					}
					if (num6 >= 0)
					{
						Main.npc[num6].value = 0f;
						Main.npc[num6].npcSlots = 0f;
					}
					break;
				}
				}
			}
			hitWire(i - 1, j);
			hitWire(i + 1, j);
			hitWire(i, j - 1);
			hitWire(i, j + 1);
		}

		public unsafe static bool CanKillTile(int i, int j)
		{
			fixed (Tile* ptr = &Main.tile[i, j])
			{
				if (ptr->active != 0 && j >= 1)
				{
					Tile* ptr2 = ptr - 1;
					if (ptr2->active != 0)
					{
						int type = ptr->type;
						int type2 = ptr2->type;
						switch (type2)
						{
						case 5:
							if (type != type2)
							{
								return (ptr[-1].frameX == 66 && ptr[-1].frameY >= 0 && ptr[-1].frameY <= 44) || (ptr[-1].frameX == 88 && ptr[-1].frameY >= 66 && ptr[-1].frameY <= 110) || ptr[-1].frameY >= 198;
							}
							return true;
						case 12:
						case 21:
						case 26:
						case 72:
							return type == type2;
						}
					}
				}
			}
			return true;
		}

		public static bool CanKillWall(int i, int j)
		{
			int wall = Main.tile[i, j].wall;
			if (Main.wallHouse[wall])
			{
				return true;
			}
			for (int k = i - 1; k < i + 2; k++)
			{
				for (int l = j - 1; l < j + 2; l++)
				{
					if (Main.tile[k, l].wall != wall)
					{
						return true;
					}
				}
			}
			return false;
		}

		public unsafe static void KillWall(int i, int j, bool fail = false)
		{
			if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY)
			{
				return;
			}
			int wall = Main.tile[i, j].wall;
			if (wall <= 0)
			{
				return;
			}
			int type = 0;
			int type2 = 0;
			switch (wall)
			{
			case 1:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
				type = 1;
				break;
			case 4:
				type = 7;
				break;
			case 12:
				type = 9;
				break;
			case 10:
			case 11:
				type = wall;
				break;
			case 21:
				type2 = 13;
				type = 13;
				break;
			case 22:
			case 28:
				type = 51;
				break;
			case 23:
				type = 38;
				break;
			case 24:
				type = 36;
				break;
			case 25:
				type = 48;
				break;
			case 26:
			case 30:
				type = 49;
				break;
			case 29:
				type = 50;
				break;
			case 31:
				type = 51;
				break;
			}
			Main.PlaySound(type2, i * 16, j * 16);
			for (int num = fail ? 1 : 5; num >= 0; num--)
			{
				switch (wall)
				{
				case 3:
					type = 1 + 13 * genRand.Next(2);
					break;
				case 27:
					type = 1 + 6 * genRand.Next(2);
					break;
				}
				Main.dust.NewDust(i * 16, j * 16, 16, 16, type);
			}
			if (!fail)
			{
				int num2 = 0;
				switch (wall)
				{
				case 1:
					num2 = 26;
					break;
				case 4:
					num2 = 93;
					break;
				case 5:
					num2 = 130;
					break;
				case 6:
					num2 = 132;
					break;
				case 7:
					num2 = 135;
					break;
				case 8:
					num2 = 138;
					break;
				case 9:
					num2 = 140;
					break;
				case 10:
					num2 = 142;
					break;
				case 11:
					num2 = 144;
					break;
				case 12:
					num2 = 146;
					break;
				case 14:
					num2 = 330;
					break;
				case 16:
					num2 = 30;
					break;
				case 17:
					num2 = 135;
					break;
				case 18:
					num2 = 138;
					break;
				case 19:
					num2 = 140;
					break;
				case 20:
					num2 = 330;
					break;
				case 21:
					num2 = 392;
					break;
				case 22:
					num2 = 417;
					break;
				case 23:
					num2 = 418;
					break;
				case 24:
					num2 = 419;
					break;
				case 25:
					num2 = 420;
					break;
				case 26:
					num2 = 421;
					break;
				case 27:
					num2 = 479;
					break;
				case 29:
					num2 = 587;
					break;
				case 30:
					num2 = 592;
					break;
				case 31:
					num2 = 595;
					break;
				}
				if (num2 > 0)
				{
					Item.NewItem(i * 16, j * 16, 16, 16, num2);
				}
				Main.tile[i, j].wall = 0;
				SquareWallFrame(i, j);
			}
		}

		public unsafe static void KillTileFast(int i, int j)
		{
			fixed (Tile* ptr = &Main.tile[i, j])
			{
				if (ptr->active != 0)
				{
					int type = ptr->type;
					if (j >= 1)
					{
						Tile* ptr2 = ptr - 1;
						if (ptr2->active != 0)
						{
							int type2 = ptr2->type;
							switch (type2)
							{
							case 5:
								if (type != type2 && (ptr[-1].frameX != 66 || ptr[-1].frameY < 0 || ptr[-1].frameY > 44) && (ptr[-1].frameX != 88 || ptr[-1].frameY < 66 || ptr[-1].frameY > 110) && ptr[-1].frameY < 198)
								{
									return;
								}
								break;
							case 12:
							case 21:
							case 26:
							case 72:
								if (type != type2)
								{
									return;
								}
								break;
							}
						}
					}
					switch (type)
					{
					case 128:
					{
						int num2 = i;
						int frameX = ptr->frameX;
						int num3 = ptr->frameX % 100 % 36;
						if (num3 == 18)
						{
							frameX = ptr[-1440].frameX;
							num2--;
						}
						if (frameX >= 100)
						{
							int num4 = frameX / 100;
							frameX %= 100;
							switch (Main.tile[num2, j].frameY / 18)
							{
							case 0:
								Item.NewItem(i * 16, j * 16, 16, 16, Item.headType[num4]);
								break;
							case 1:
								Item.NewItem(i * 16, j * 16, 16, 16, Item.bodyType[num4]);
								break;
							case 2:
								Item.NewItem(i * 16, j * 16, 16, 16, Item.legType[num4]);
								break;
							}
							frameX = Main.tile[num2, j].frameX % 100;
							Main.tile[num2, j].frameX = (short)frameX;
						}
						break;
					}
					case 21:
						if (Main.netMode != 1)
						{
							int num = ptr->frameX / 18;
							int y = j - ptr->frameY / 18;
							num = i - (num & 1);
							if (!Chest.DestroyChest(num, y))
							{
								return;
							}
						}
						break;
					}
					ptr->active = 0;
					ptr->type = 0;
					ptr->frameX = -1;
					ptr->frameY = -1;
					ptr->frameNumber = 0;
					if (type == 58 && j > Main.maxTilesY - 200)
					{
						ptr->lava = 32;
						ptr->liquid = 128;
					}
					SquareTileFrame(i, j);
				}
			}
		}

		public unsafe static bool KillTile(int i, int j)
		{
			if (i >= 0 && j >= 0 && i < Main.maxTilesX && j < Main.maxTilesY)
			{
				fixed (Tile* ptr = &Main.tile[i, j])
				{
					if (ptr->active != 0)
					{
						int type = ptr->type;
						if (j >= 1)
						{
							Tile* ptr2 = ptr - 1;
							if (ptr2->active != 0)
							{
								int type2 = ptr2->type;
								switch (type2)
								{
								case 5:
									if (type != type2 && (ptr[-1].frameX != 66 || ptr[-1].frameY < 0 || ptr[-1].frameY > 44) && (ptr[-1].frameX != 88 || ptr[-1].frameY < 66 || ptr[-1].frameY > 110) && ptr[-1].frameY < 198)
									{
										return false;
									}
									break;
								case 12:
								case 21:
								case 26:
								case 72:
									if (type != type2)
									{
										return false;
									}
									break;
								}
							}
						}
						if (!gen && !stopDrops)
						{
							if (type == 127)
							{
								Main.PlaySound(2, i * 16, j * 16, 27);
							}
							else if (type == 3 || type == 110)
							{
								Main.PlaySound(6, i * 16, j * 16);
								if (ptr->frameX == 144)
								{
									Item.NewItem(i * 16, j * 16, 16, 16, 5);
								}
							}
							else if (type == 24)
							{
								Main.PlaySound(6, i * 16, j * 16);
								if (ptr->frameX == 144)
								{
									Item.NewItem(i * 16, j * 16, 16, 16, 60);
								}
							}
							else if (type == 32 || type == 51 || type == 52 || type == 61 || type == 62 || type == 69 || type == 71 || type == 73 || type == 74 || (type >= 82 && type <= 84) || type == 113 || type == 115)
							{
								Main.PlaySound(6, i * 16, j * 16);
							}
							else
							{
								switch (type)
								{
								case 1:
								case 6:
								case 7:
								case 8:
								case 9:
								case 22:
								case 25:
								case 37:
								case 38:
								case 39:
								case 41:
								case 43:
								case 44:
								case 45:
								case 46:
								case 47:
								case 48:
								case 56:
								case 58:
								case 63:
								case 64:
								case 65:
								case 66:
								case 67:
								case 68:
								case 75:
								case 76:
								case 107:
								case 108:
								case 111:
								case 117:
								case 118:
								case 119:
								case 120:
								case 121:
								case 122:
								case 140:
									Main.PlaySound(21, i * 16, j * 16);
									break;
								default:
									Main.PlaySound(0, i * 16, j * 16);
									if (type == 129)
									{
										Main.PlaySound(2, i * 16, j * 16, 27);
									}
									break;
								case 138:
									break;
								}
							}
						}
						if (type != 138)
						{
							if (type == 128)
							{
								int num = i;
								int frameX = ptr->frameX;
								int num2 = ptr->frameX % 100 % 36;
								if (num2 == 18)
								{
									frameX = ptr[-1440].frameX;
									num--;
								}
								if (frameX >= 100)
								{
									int num3 = frameX / 100;
									frameX %= 100;
									switch (Main.tile[num, j].frameY / 18)
									{
									case 0:
										Item.NewItem(i * 16, j * 16, 16, 16, Item.headType[num3]);
										break;
									case 1:
										Item.NewItem(i * 16, j * 16, 16, 16, Item.bodyType[num3]);
										break;
									case 2:
										Item.NewItem(i * 16, j * 16, 16, 16, Item.legType[num3]);
										break;
									}
									frameX = Main.tile[num, j].frameX % 100;
									Main.tile[num, j].frameX = (short)frameX;
								}
							}
							if (!gen)
							{
								int num4 = 0;
								if (type != 0)
								{
									if (type == 1 || type == 16 || type == 17 || type == 38 || type == 39 || type == 41 || type == 43 || type == 44 || type == 48 || type == 85 || type == 90 || type == 92 || type == 96 || type == 97 || type == 99 || type == 105 || type == 117 || type == 130 || type == 131 || type == 132 || type == 135 || type == 137 || type == 142 || type == 143 || type == 144 || Main.tileStone[type])
									{
										num4 = 1;
									}
									else
									{
										switch (type)
										{
										case 33:
										case 95:
										case 98:
										case 100:
											num4 = 6;
											break;
										case 5:
										case 10:
										case 11:
										case 14:
										case 15:
										case 19:
										case 30:
										case 86:
										case 87:
										case 88:
										case 89:
										case 93:
										case 94:
										case 104:
										case 106:
										case 114:
										case 124:
										case 128:
										case 139:
											num4 = 7;
											break;
										case 21:
											num4 = ((ptr->frameX < 108) ? ((ptr->frameX < 36) ? 7 : 10) : 37);
											break;
										case 127:
											num4 = 67;
											break;
										case 91:
											num4 = -1;
											break;
										case 6:
										case 26:
											num4 = 8;
											break;
										case 7:
										case 34:
										case 47:
											num4 = 9;
											break;
										case 8:
										case 36:
										case 45:
										case 102:
											num4 = 10;
											break;
										case 9:
										case 35:
										case 42:
										case 46:
										case 126:
										case 136:
											num4 = 11;
											break;
										case 12:
											num4 = 12;
											break;
										case 3:
										case 73:
											num4 = 3;
											break;
										case 13:
										case 54:
											num4 = 13;
											break;
										case 22:
										case 140:
											num4 = 14;
											break;
										case 28:
										case 78:
											num4 = 22;
											break;
										case 29:
											num4 = 23;
											break;
										case 40:
										case 103:
											num4 = 28;
											break;
										case 49:
											num4 = 29;
											break;
										case 50:
											num4 = 22;
											break;
										case 51:
											num4 = 30;
											break;
										case 52:
											num4 = 3;
											break;
										case 53:
										case 81:
											num4 = 32;
											break;
										case 56:
										case 75:
											num4 = 37;
											break;
										case 57:
										case 119:
										case 141:
											num4 = 36;
											break;
										case 59:
										case 120:
											num4 = 38;
											break;
										case 61:
										case 62:
										case 74:
										case 80:
											num4 = 40;
											break;
										case 69:
											num4 = 7;
											break;
										case 71:
										case 72:
											num4 = 26;
											break;
										case 70:
											num4 = 17;
											break;
										case 112:
											num4 = 14;
											break;
										case 123:
											num4 = 53;
											break;
										case 116:
										case 118:
										case 147:
										case 148:
											num4 = 51;
											break;
										case 110:
										case 113:
										case 115:
											num4 = 47;
											break;
										case 107:
										case 121:
											num4 = 48;
											break;
										case 108:
										case 122:
										case 134:
										case 146:
											num4 = 49;
											break;
										case 111:
										case 133:
										case 145:
											num4 = 50;
											break;
										case 149:
											num4 = 49;
											break;
										case 82:
										case 83:
										case 84:
											switch (ptr->frameX / 18)
											{
											case 0:
												num4 = 3;
												break;
											case 1:
												num4 = 3;
												break;
											case 2:
												num4 = 7;
												break;
											case 3:
												num4 = 17;
												break;
											case 4:
												num4 = 3;
												break;
											case 5:
												num4 = 6;
												break;
											}
											break;
										default:
											switch (type)
											{
											case 129:
												num4 = ((ptr->frameX != 0 && ptr->frameX != 54 && ptr->frameX != 108) ? ((ptr->frameX != 18 && ptr->frameX != 72 && ptr->frameX != 126) ? 70 : 69) : 68);
												break;
											case 4:
											{
												int num5 = ptr->frameY / 22;
												switch (num5)
												{
												case 0:
													num4 = 6;
													break;
												case 8:
													num4 = 75;
													break;
												default:
													num4 = 58 + num5;
													break;
												}
												break;
											}
											}
											break;
										}
									}
								}
								if (num4 >= 0)
								{
									for (int num6 = 4; num6 >= 0; num6--)
									{
										switch (type)
										{
										case 2:
											num4 = genRand.Next(2) << 1;
											break;
										case 20:
											num4 = ((genRand.Next(2) == 0) ? 7 : 2);
											break;
										case 23:
										case 24:
											num4 = ((genRand.Next(2) == 0) ? 14 : 17);
											break;
										case 27:
											num4 = ((genRand.Next(2) == 0) ? 3 : 19);
											break;
										case 25:
										case 31:
											num4 = ((genRand.Next(2) != 0) ? 1 : 14);
											break;
										case 32:
											num4 = ((genRand.Next(2) == 0) ? 14 : 24);
											break;
										case 34:
										case 35:
										case 36:
										case 42:
											num4 = genRand.Next(2) * 6;
											break;
										case 37:
											num4 = ((genRand.Next(2) == 0) ? 6 : 23);
											break;
										case 61:
											num4 = 38 + genRand.Next(2);
											break;
										case 58:
										case 76:
										case 77:
											num4 = ((genRand.Next(2) == 0) ? 6 : 25);
											break;
										case 109:
											num4 = genRand.Next(2) * 47;
											break;
										}
										Main.dust.NewDust(i * 16, j * 16, 16, 16, num4);
									}
								}
							}
						}
						if (type == 21 && Main.netMode != 1)
						{
							int num7 = ptr->frameX / 18;
							int y = j - ptr->frameY / 18;
							num7 = i - (num7 & 1);
							if (!Chest.DestroyChest(num7, y))
							{
								return false;
							}
						}
						if (!gen && !stopDrops && Main.netMode != 1)
						{
							int num8 = 0;
							if (type == 0 || type == 2 || type == 109)
							{
								num8 = 2;
							}
							else if (type == 1)
							{
								num8 = 3;
							}
							else if (type == 3 || type == 73)
							{
								if (Main.rand.Next(2) == 0)
								{
									Rectangle rect = default(Rectangle);
									rect.X = i << 4;
									rect.Y = j << 4;
									rect.Width = (rect.Height = 16);
									if (Player.FindClosest(ref rect).HasItem(281))
									{
										num8 = 283;
									}
								}
							}
							else if (type == 4)
							{
								int num9 = ptr->frameY / 22;
								switch (num9)
								{
								case 0:
									num8 = 8;
									break;
								case 8:
									num8 = 523;
									break;
								default:
									num8 = 426 + num9;
									break;
								}
							}
							else if (type == 5)
							{
								if (ptr->frameX >= 22 && ptr->frameY >= 198)
								{
									if (Main.netMode != 1)
									{
										num8 = 9;
										if (genRand.Next(2) == 0)
										{
											int num10 = j - 1;
											int type3;
											do
											{
												type3 = Main.tile[i, ++num10].type;
											}
											while (!Main.tileSolidNotSolidTop[type3] || Main.tile[i, num10].active == 0);
											if (type3 == 2 || type3 == 109)
											{
												num8 = 27;
											}
										}
									}
								}
								else
								{
									num8 = 9;
								}
								woodSpawned++;
							}
							else if (type == 6)
							{
								num8 = 11;
							}
							else if (type == 7)
							{
								num8 = 12;
							}
							else if (type == 8)
							{
								num8 = 13;
							}
							else if (type == 9)
							{
								num8 = 14;
							}
							else if (type == 123)
							{
								num8 = 424;
							}
							else if (type == 124)
							{
								num8 = 480;
							}
							else if (type == 149)
							{
								if (ptr->frameX == 0 || ptr->frameX == 54)
								{
									num8 = 596;
								}
								else if (ptr->frameX == 18 || ptr->frameX == 72)
								{
									num8 = 597;
								}
								else if (ptr->frameX == 36 || ptr->frameX == 90)
								{
									num8 = 598;
								}
							}
							else if (type == 13)
							{
								Main.PlaySound(13, i * 16, j * 16);
								num8 = ((ptr->frameX == 18) ? 28 : ((ptr->frameX == 36) ? 110 : ((ptr->frameX == 54) ? 350 : ((ptr->frameX != 72) ? 31 : 351))));
							}
							else if (type == 19)
							{
								num8 = 94;
							}
							else if (type == 22)
							{
								num8 = 56;
							}
							else if (type == 140)
							{
								num8 = 577;
							}
							else if (type == 23)
							{
								num8 = 2;
							}
							else if (type == 25)
							{
								num8 = 61;
							}
							else if (type == 30)
							{
								num8 = 9;
							}
							else if (type == 33)
							{
								num8 = 105;
							}
							else if (type == 37)
							{
								num8 = 116;
							}
							else if (type == 38)
							{
								num8 = 129;
							}
							else if (type == 39)
							{
								num8 = 131;
							}
							else if (type == 40)
							{
								num8 = 133;
							}
							else if (type == 41)
							{
								num8 = 134;
							}
							else if (type == 43)
							{
								num8 = 137;
							}
							else if (type == 44)
							{
								num8 = 139;
							}
							else if (type == 45)
							{
								num8 = 141;
							}
							else if (type == 46)
							{
								num8 = 143;
							}
							else if (type == 47)
							{
								num8 = 145;
							}
							else if (type == 48)
							{
								num8 = 147;
							}
							else if (type == 49)
							{
								num8 = 148;
							}
							else if (type == 51)
							{
								num8 = 150;
							}
							else if (type == 53)
							{
								num8 = 169;
							}
							else if (type == 54)
							{
								num8 = 170;
								Main.PlaySound(13, i * 16, j * 16);
							}
							else if (type == 56)
							{
								num8 = 173;
							}
							else if (type == 57)
							{
								num8 = 172;
							}
							else if (type == 58)
							{
								num8 = 174;
							}
							else if (type == 60)
							{
								num8 = 176;
							}
							else
							{
								switch (type)
								{
								case 70:
									num8 = 176;
									break;
								case 75:
									num8 = 192;
									break;
								case 76:
									num8 = 214;
									break;
								case 78:
									num8 = 222;
									break;
								case 81:
									num8 = 275;
									break;
								case 80:
									num8 = 276;
									break;
								case 107:
									num8 = 364;
									break;
								case 108:
									num8 = 365;
									break;
								case 111:
									num8 = 366;
									break;
								case 112:
									num8 = 370;
									break;
								case 116:
									num8 = 408;
									break;
								case 117:
									num8 = 409;
									break;
								case 118:
									num8 = 412;
									break;
								case 119:
									num8 = 413;
									break;
								case 120:
									num8 = 414;
									break;
								case 121:
									num8 = 415;
									break;
								case 122:
									num8 = 416;
									break;
								case 129:
									num8 = 502;
									break;
								case 130:
									num8 = 511;
									break;
								case 131:
									num8 = 512;
									break;
								case 136:
									num8 = 538;
									break;
								case 137:
									num8 = 539;
									break;
								case 141:
									num8 = 580;
									break;
								case 145:
									num8 = 586;
									break;
								case 146:
									num8 = 591;
									break;
								case 147:
									num8 = 593;
									break;
								case 148:
									num8 = 594;
									break;
								case 135:
									if (ptr->frameY == 0)
									{
										num8 = 529;
									}
									else if (ptr->frameY == 18)
									{
										num8 = 541;
									}
									else if (ptr->frameY == 36)
									{
										num8 = 542;
									}
									else if (ptr->frameY == 54)
									{
										num8 = 543;
									}
									break;
								case 144:
									if (ptr->frameX == 0)
									{
										num8 = 583;
									}
									else if (ptr->frameX == 18)
									{
										num8 = 584;
									}
									else if (ptr->frameX == 36)
									{
										num8 = 585;
									}
									break;
								case 61:
								case 74:
									if (ptr->frameX == 144)
									{
										Item.NewItem(i * 16, j * 16, 16, 16, 331, genRand.Next(2, 4));
									}
									else if (ptr->frameX == 162)
									{
										num8 = 223;
									}
									else if (ptr->frameX >= 108 && ptr->frameX <= 126 && genRand.Next(100) == 0)
									{
										num8 = 208;
									}
									else if (genRand.Next(100) == 0)
									{
										num8 = 195;
									}
									break;
								case 59:
								case 60:
									num8 = 176;
									break;
								case 71:
								case 72:
								{
									int num12 = genRand.Next(50);
									if (num12 < 25)
									{
										num8 = ((num12 != 0) ? 183 : 194);
									}
									break;
								}
								default:
									if (ptr->type >= 63 && ptr->type <= 68)
									{
										num8 = ptr->type - 63 + 177;
									}
									else
									{
										switch (type)
										{
										case 50:
											num8 = ((ptr->frameX != 90) ? 149 : 165);
											break;
										case 83:
										case 84:
										{
											int num11 = ptr->frameX / 18;
											bool flag = type == 84;
											if (!flag)
											{
												if (num11 == 0 && Main.gameTime.dayTime)
												{
													flag = true;
												}
												else if (num11 == 1 && !Main.gameTime.dayTime)
												{
													flag = true;
												}
												else if (num11 == 3 && Main.gameTime.bloodMoon)
												{
													flag = true;
												}
											}
											if (flag)
											{
												Item.NewItem(i * 16, j * 16, 16, 16, 307 + num11, genRand.Next(1, 4));
											}
											num8 = 313 + num11;
											break;
										}
										}
									}
									break;
								}
							}
							if (num8 > 0)
							{
								Item.NewItem(i * 16, j * 16, 16, 16, num8, 1, noBroadcast: false, -1);
							}
						}
						ptr->active = 0;
						ptr->type = 0;
						ptr->frameX = -1;
						ptr->frameY = -1;
						ptr->frameNumber = 0;
						if (type == 58 && j > Main.maxTilesY - 200)
						{
							ptr->lava = 32;
							ptr->liquid = 128;
						}
						SquareTileFrame(i, j);
						return true;
					}
				}
			}
			return false;
		}

		public unsafe static void KillTile(int i, int j, bool fail, bool effectOnly = false, bool noItem = false)
		{
			if (i >= 0 && j >= 0 && i < Main.maxTilesX && j < Main.maxTilesY)
			{
				fixed (Tile* ptr = &Main.tile[i, j])
				{
					int type;
					if (ptr->active != 0)
					{
						type = ptr->type;
						if (j >= 1)
						{
							Tile* ptr2 = ptr - 1;
							if (ptr2->active != 0)
							{
								int type2 = ptr2->type;
								switch (type2)
								{
								case 5:
									if (type != type2 && (ptr[-1].frameX != 66 || ptr[-1].frameY < 0 || ptr[-1].frameY > 44) && (ptr[-1].frameX != 88 || ptr[-1].frameY < 66 || ptr[-1].frameY > 110) && ptr[-1].frameY < 198)
									{
										return;
									}
									break;
								case 12:
								case 21:
								case 26:
								case 72:
									if (type != type2)
									{
										return;
									}
									break;
								}
							}
						}
						if (!gen && !effectOnly && !stopDrops)
						{
							if (type == 127)
							{
								Main.PlaySound(2, i * 16, j * 16, 27);
							}
							else if (type == 3 || type == 110)
							{
								Main.PlaySound(6, i * 16, j * 16);
								if (ptr->frameX == 144)
								{
									Item.NewItem(i * 16, j * 16, 16, 16, 5);
								}
							}
							else if (type == 24)
							{
								Main.PlaySound(6, i * 16, j * 16);
								if (ptr->frameX == 144)
								{
									Item.NewItem(i * 16, j * 16, 16, 16, 60);
								}
							}
							else if (type == 32 || type == 51 || type == 52 || type == 61 || type == 62 || type == 69 || type == 71 || type == 73 || type == 74 || (type >= 82 && type <= 84) || type == 113 || type == 115)
							{
								Main.PlaySound(6, i * 16, j * 16);
							}
							else
							{
								switch (type)
								{
								case 1:
								case 6:
								case 7:
								case 8:
								case 9:
								case 22:
								case 25:
								case 37:
								case 38:
								case 39:
								case 41:
								case 43:
								case 44:
								case 45:
								case 46:
								case 47:
								case 48:
								case 56:
								case 58:
								case 63:
								case 64:
								case 65:
								case 66:
								case 67:
								case 68:
								case 75:
								case 76:
								case 107:
								case 108:
								case 111:
								case 117:
								case 118:
								case 119:
								case 120:
								case 121:
								case 122:
								case 140:
									Main.PlaySound(21, i * 16, j * 16);
									break;
								default:
									Main.PlaySound(0, i * 16, j * 16);
									if (type == 129 && !fail)
									{
										Main.PlaySound(2, i * 16, j * 16, 27);
									}
									break;
								case 138:
									break;
								}
							}
						}
						if (type != 138)
						{
							if (type == 128)
							{
								int num = i;
								int frameX = ptr->frameX;
								int num2 = ptr->frameX % 100 % 36;
								if (num2 == 18)
								{
									frameX = ptr[-1440].frameX;
									num--;
								}
								if (frameX >= 100)
								{
									int num3 = frameX / 100;
									frameX %= 100;
									switch (Main.tile[num, j].frameY / 18)
									{
									case 0:
										Item.NewItem(i * 16, j * 16, 16, 16, Item.headType[num3]);
										break;
									case 1:
										Item.NewItem(i * 16, j * 16, 16, 16, Item.bodyType[num3]);
										break;
									case 2:
										Item.NewItem(i * 16, j * 16, 16, 16, Item.legType[num3]);
										break;
									}
									frameX = Main.tile[num, j].frameX % 100;
									Main.tile[num, j].frameX = (short)frameX;
								}
							}
							if (!gen)
							{
								int num4 = 0;
								if (type != 0)
								{
									if (type == 1 || type == 16 || type == 17 || type == 38 || type == 39 || type == 41 || type == 43 || type == 44 || type == 48 || type == 85 || type == 90 || type == 92 || type == 96 || type == 97 || type == 99 || type == 105 || type == 117 || type == 130 || type == 131 || type == 132 || type == 135 || type == 137 || type == 142 || type == 143 || type == 144 || Main.tileStone[type])
									{
										num4 = 1;
									}
									else
									{
										switch (type)
										{
										case 33:
										case 95:
										case 98:
										case 100:
											num4 = 6;
											break;
										case 5:
										case 10:
										case 11:
										case 14:
										case 15:
										case 19:
										case 30:
										case 86:
										case 87:
										case 88:
										case 89:
										case 93:
										case 94:
										case 104:
										case 106:
										case 114:
										case 124:
										case 128:
										case 139:
											num4 = 7;
											break;
										case 21:
											num4 = ((ptr->frameX < 108) ? ((ptr->frameX < 36) ? 7 : 10) : 37);
											break;
										case 127:
											num4 = 67;
											break;
										case 91:
											num4 = -1;
											break;
										case 6:
										case 26:
											num4 = 8;
											break;
										case 7:
										case 34:
										case 47:
											num4 = 9;
											break;
										case 8:
										case 36:
										case 45:
										case 102:
											num4 = 10;
											break;
										case 9:
										case 35:
										case 42:
										case 46:
										case 126:
										case 136:
											num4 = 11;
											break;
										case 12:
											num4 = 12;
											break;
										case 3:
										case 73:
											num4 = 3;
											break;
										case 13:
										case 54:
											num4 = 13;
											break;
										case 22:
										case 140:
											num4 = 14;
											break;
										case 28:
										case 78:
											num4 = 22;
											break;
										case 29:
											num4 = 23;
											break;
										case 40:
										case 103:
											num4 = 28;
											break;
										case 49:
											num4 = 29;
											break;
										case 50:
											num4 = 22;
											break;
										case 51:
											num4 = 30;
											break;
										case 52:
											num4 = 3;
											break;
										case 53:
										case 81:
											num4 = 32;
											break;
										case 56:
										case 75:
											num4 = 37;
											break;
										case 57:
										case 119:
										case 141:
											num4 = 36;
											break;
										case 59:
										case 120:
											num4 = 38;
											break;
										case 61:
										case 62:
										case 74:
										case 80:
											num4 = 40;
											break;
										case 69:
											num4 = 7;
											break;
										case 71:
										case 72:
											num4 = 26;
											break;
										case 70:
											num4 = 17;
											break;
										case 112:
											num4 = 14;
											break;
										case 123:
											num4 = 53;
											break;
										case 116:
										case 118:
										case 147:
										case 148:
											num4 = 51;
											break;
										case 110:
										case 113:
										case 115:
											num4 = 47;
											break;
										case 107:
										case 121:
											num4 = 48;
											break;
										case 108:
										case 122:
										case 134:
										case 146:
											num4 = 49;
											break;
										case 111:
										case 133:
										case 145:
											num4 = 50;
											break;
										case 149:
											num4 = 49;
											break;
										case 82:
										case 83:
										case 84:
											switch (ptr->frameX / 18)
											{
											case 0:
												num4 = 3;
												break;
											case 1:
												num4 = 3;
												break;
											case 2:
												num4 = 7;
												break;
											case 3:
												num4 = 17;
												break;
											case 4:
												num4 = 3;
												break;
											case 5:
												num4 = 6;
												break;
											}
											break;
										default:
											switch (type)
											{
											case 129:
												num4 = ((ptr->frameX != 0 && ptr->frameX != 54 && ptr->frameX != 108) ? ((ptr->frameX != 18 && ptr->frameX != 72 && ptr->frameX != 126) ? 70 : 69) : 68);
												break;
											case 4:
											{
												int num5 = ptr->frameY / 22;
												switch (num5)
												{
												case 0:
													num4 = 6;
													break;
												case 8:
													num4 = 75;
													break;
												default:
													num4 = 58 + num5;
													break;
												}
												break;
											}
											}
											break;
										}
									}
								}
								if (num4 >= 0)
								{
									for (int num6 = fail ? 1 : 4; num6 >= 0; num6--)
									{
										switch (type)
										{
										case 2:
											num4 = genRand.Next(2) << 1;
											break;
										case 20:
											num4 = ((genRand.Next(2) == 0) ? 7 : 2);
											break;
										case 23:
										case 24:
											num4 = ((genRand.Next(2) == 0) ? 14 : 17);
											break;
										case 27:
											num4 = ((genRand.Next(2) == 0) ? 3 : 19);
											break;
										case 25:
										case 31:
											num4 = ((genRand.Next(2) != 0) ? 1 : 14);
											break;
										case 32:
											num4 = ((genRand.Next(2) == 0) ? 14 : 24);
											break;
										case 34:
										case 35:
										case 36:
										case 42:
											num4 = genRand.Next(2) * 6;
											break;
										case 37:
											num4 = ((genRand.Next(2) == 0) ? 6 : 23);
											break;
										case 61:
											num4 = 38 + genRand.Next(2);
											break;
										case 58:
										case 76:
										case 77:
											num4 = ((genRand.Next(2) == 0) ? 6 : 25);
											break;
										case 109:
											num4 = genRand.Next(2) * 47;
											break;
										}
										Main.dust.NewDust(i * 16, j * 16, 16, 16, num4);
									}
								}
							}
						}
						if (!effectOnly)
						{
							if (fail)
							{
								switch (type)
								{
								case 2:
								case 23:
								case 109:
									ptr->type = 0;
									break;
								case 60:
								case 70:
									ptr->type = 59;
									break;
								}
								SquareTileFrame(i, j);
							}
							else
							{
								if (type != 21 || Main.netMode == 1)
								{
									goto IL_0c1b;
								}
								int num7 = ptr->frameX / 18;
								int y = j - ptr->frameY / 18;
								num7 = i - (num7 & 1);
								if (Chest.DestroyChest(num7, y))
								{
									goto IL_0c1b;
								}
							}
						}
					}
					goto end_IL_0038;
					IL_0c1b:
					if (!noItem && !stopDrops && Main.netMode != 1 && !gen)
					{
						int num8 = 0;
						if (type == 0 || type == 2 || type == 109)
						{
							num8 = 2;
						}
						else if (type == 1)
						{
							num8 = 3;
						}
						else if (type == 3 || type == 73)
						{
							if (Main.rand.Next(2) == 0)
							{
								Rectangle rect = default(Rectangle);
								rect.X = i << 4;
								rect.Y = j << 4;
								rect.Width = (rect.Height = 16);
								if (Player.FindClosest(ref rect).HasItem(281))
								{
									num8 = 283;
								}
							}
						}
						else if (type == 4)
						{
							int num9 = ptr->frameY / 22;
							switch (num9)
							{
							case 0:
								num8 = 8;
								break;
							case 8:
								num8 = 523;
								break;
							default:
								num8 = 426 + num9;
								break;
							}
						}
						else if (type == 5)
						{
							if (ptr->frameX >= 22 && ptr->frameY >= 198)
							{
								if (Main.netMode != 1)
								{
									num8 = 9;
									if (genRand.Next(2) == 0)
									{
										int num10 = j - 1;
										int type3;
										do
										{
											type3 = Main.tile[i, ++num10].type;
										}
										while (!Main.tileSolidNotSolidTop[type3] || Main.tile[i, num10].active == 0);
										if (type3 == 2 || type3 == 109)
										{
											num8 = 27;
										}
									}
								}
							}
							else
							{
								num8 = 9;
							}
							woodSpawned++;
						}
						else if (type == 6)
						{
							num8 = 11;
						}
						else if (type == 7)
						{
							num8 = 12;
						}
						else if (type == 8)
						{
							num8 = 13;
						}
						else if (type == 9)
						{
							num8 = 14;
						}
						else if (type == 123)
						{
							num8 = 424;
						}
						else if (type == 124)
						{
							num8 = 480;
						}
						else if (type == 149)
						{
							if (ptr->frameX == 0 || ptr->frameX == 54)
							{
								num8 = 596;
							}
							else if (ptr->frameX == 18 || ptr->frameX == 72)
							{
								num8 = 597;
							}
							else if (ptr->frameX == 36 || ptr->frameX == 90)
							{
								num8 = 598;
							}
						}
						else if (type == 13)
						{
							Main.PlaySound(13, i * 16, j * 16);
							num8 = ((ptr->frameX == 18) ? 28 : ((ptr->frameX == 36) ? 110 : ((ptr->frameX == 54) ? 350 : ((ptr->frameX != 72) ? 31 : 351))));
						}
						else if (type == 19)
						{
							num8 = 94;
						}
						else if (type == 22)
						{
							num8 = 56;
						}
						else if (type == 140)
						{
							num8 = 577;
						}
						else if (type == 23)
						{
							num8 = 2;
						}
						else if (type == 25)
						{
							num8 = 61;
						}
						else if (type == 30)
						{
							num8 = 9;
						}
						else if (type == 33)
						{
							num8 = 105;
						}
						else if (type == 37)
						{
							num8 = 116;
						}
						else if (type == 38)
						{
							num8 = 129;
						}
						else if (type == 39)
						{
							num8 = 131;
						}
						else if (type == 40)
						{
							num8 = 133;
						}
						else if (type == 41)
						{
							num8 = 134;
						}
						else if (type == 43)
						{
							num8 = 137;
						}
						else if (type == 44)
						{
							num8 = 139;
						}
						else if (type == 45)
						{
							num8 = 141;
						}
						else if (type == 46)
						{
							num8 = 143;
						}
						else if (type == 47)
						{
							num8 = 145;
						}
						else if (type == 48)
						{
							num8 = 147;
						}
						else if (type == 49)
						{
							num8 = 148;
						}
						else if (type == 51)
						{
							num8 = 150;
						}
						else if (type == 53)
						{
							num8 = 169;
						}
						else if (type == 54)
						{
							num8 = 170;
							Main.PlaySound(13, i * 16, j * 16);
						}
						else if (type == 56)
						{
							num8 = 173;
						}
						else if (type == 57)
						{
							num8 = 172;
						}
						else if (type == 58)
						{
							num8 = 174;
						}
						else if (type == 60)
						{
							num8 = 176;
						}
						else
						{
							switch (type)
							{
							case 70:
								num8 = 176;
								break;
							case 75:
								num8 = 192;
								break;
							case 76:
								num8 = 214;
								break;
							case 78:
								num8 = 222;
								break;
							case 81:
								num8 = 275;
								break;
							case 80:
								num8 = 276;
								break;
							case 107:
								num8 = 364;
								break;
							case 108:
								num8 = 365;
								break;
							case 111:
								num8 = 366;
								break;
							case 112:
								num8 = 370;
								break;
							case 116:
								num8 = 408;
								break;
							case 117:
								num8 = 409;
								break;
							case 118:
								num8 = 412;
								break;
							case 119:
								num8 = 413;
								break;
							case 120:
								num8 = 414;
								break;
							case 121:
								num8 = 415;
								break;
							case 122:
								num8 = 416;
								break;
							case 129:
								num8 = 502;
								break;
							case 130:
								num8 = 511;
								break;
							case 131:
								num8 = 512;
								break;
							case 136:
								num8 = 538;
								break;
							case 137:
								num8 = 539;
								break;
							case 141:
								num8 = 580;
								break;
							case 145:
								num8 = 586;
								break;
							case 146:
								num8 = 591;
								break;
							case 147:
								num8 = 593;
								break;
							case 148:
								num8 = 594;
								break;
							case 135:
								if (ptr->frameY == 0)
								{
									num8 = 529;
								}
								else if (ptr->frameY == 18)
								{
									num8 = 541;
								}
								else if (ptr->frameY == 36)
								{
									num8 = 542;
								}
								else if (ptr->frameY == 54)
								{
									num8 = 543;
								}
								break;
							case 144:
								if (ptr->frameX == 0)
								{
									num8 = 583;
								}
								else if (ptr->frameX == 18)
								{
									num8 = 584;
								}
								else if (ptr->frameX == 36)
								{
									num8 = 585;
								}
								break;
							case 61:
							case 74:
								if (ptr->frameX == 144)
								{
									Item.NewItem(i * 16, j * 16, 16, 16, 331, genRand.Next(2, 4));
								}
								else if (ptr->frameX == 162)
								{
									num8 = 223;
								}
								else if (ptr->frameX >= 108 && ptr->frameX <= 126 && genRand.Next(100) == 0)
								{
									num8 = 208;
								}
								else if (genRand.Next(100) == 0)
								{
									num8 = 195;
								}
								break;
							case 59:
							case 60:
								num8 = 176;
								break;
							case 71:
							case 72:
							{
								int num12 = genRand.Next(50);
								if (num12 < 25)
								{
									num8 = ((num12 != 0) ? 183 : 194);
								}
								break;
							}
							default:
								if (ptr->type >= 63 && ptr->type <= 68)
								{
									num8 = ptr->type - 63 + 177;
								}
								else
								{
									switch (type)
									{
									case 50:
										num8 = ((ptr->frameX != 90) ? 149 : 165);
										break;
									case 83:
									case 84:
									{
										int num11 = ptr->frameX / 18;
										bool flag = type == 84;
										if (!flag)
										{
											if (num11 == 0 && Main.gameTime.dayTime)
											{
												flag = true;
											}
											else if (num11 == 1 && !Main.gameTime.dayTime)
											{
												flag = true;
											}
											else if (num11 == 3 && Main.gameTime.bloodMoon)
											{
												flag = true;
											}
										}
										if (flag)
										{
											Item.NewItem(i * 16, j * 16, 16, 16, 307 + num11, genRand.Next(1, 4));
										}
										num8 = 313 + num11;
										break;
									}
									}
								}
								break;
							}
						}
						if (num8 > 0)
						{
							Item.NewItem(i * 16, j * 16, 16, 16, num8, 1, noBroadcast: false, -1);
						}
					}
					ptr->active = 0;
					ptr->type = 0;
					ptr->frameX = -1;
					ptr->frameY = -1;
					ptr->frameNumber = 0;
					if (type == 58 && j > Main.maxTilesY - 200)
					{
						ptr->lava = 32;
						ptr->liquid = 128;
					}
					SquareTileFrame(i, j);
					end_IL_0038:;
				}
			}
		}

		public static bool PlayerLOS(int x, int y)
		{
			Rectangle rectangle = new Rectangle(x * 16, y * 16, 16, 16);
			Rectangle value = default(Rectangle);
			bool result = false;
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[i].active != 0)
				{
					value.X = (int)((double)Main.player[i].position.X + 10.0 - 1152.0);
					value.Y = (int)((double)Main.player[i].position.Y + 21.0 - 648.0);
					value.Width = 2304;
					value.Height = 1296;
					rectangle.Intersects(ref value, out result);
					if (result)
					{
						break;
					}
				}
			}
			return result;
		}

		public static void hardUpdateWorld(int i, int j)
		{
			int type = Main.tile[i, j].type;
			if (type == 117 && j > Main.rockLayer && Main.rand.Next(110) == 0)
			{
				int num = genRand.Next(4);
				int num2 = 0;
				int num3 = 0;
				switch (num)
				{
				case 0:
					num2 = -1;
					break;
				case 1:
					num2 = 1;
					break;
				default:
					num3 = ((num != 0) ? 1 : (-1));
					break;
				}
				if (Main.tile[i + num2, j + num3].active == 0)
				{
					int num4 = 0;
					int num5 = 6;
					for (int k = i - num5; k <= i + num5; k++)
					{
						for (int l = j - num5; l <= j + num5; l++)
						{
							if (Main.tile[k, l].active != 0 && Main.tile[k, l].type == 129)
							{
								num4++;
							}
						}
					}
					if (num4 < 2)
					{
						PlaceTile(i + num2, j + num3, 129, mute: true);
						NetMessage.SendTile(i + num2, j + num3);
					}
				}
			}
			else if (type == 23 || type == 25 || type == 32 || type == 112)
			{
				while (true)
				{
					int num6 = i + genRand.Next(-3, 4);
					int num7 = j + genRand.Next(-3, 4);
					if (Main.tile[num6, num7].type == 2)
					{
						Main.tile[num6, num7].type = 23;
						SquareTileFrame(num6, num7);
						NetMessage.SendTile(num6, num7);
						if (genRand.Next(2) == 0)
						{
							continue;
						}
						break;
					}
					if (Main.tile[num6, num7].type == 1)
					{
						Main.tile[num6, num7].type = 25;
						SquareTileFrame(num6, num7);
						NetMessage.SendTile(num6, num7);
						if (genRand.Next(2) == 0)
						{
							continue;
						}
						break;
					}
					if (Main.tile[num6, num7].type == 53)
					{
						Main.tile[num6, num7].type = 112;
						SquareTileFrame(num6, num7);
						NetMessage.SendTile(num6, num7);
						if (genRand.Next(2) == 0)
						{
							continue;
						}
						break;
					}
					if (Main.tile[num6, num7].type == 59)
					{
						Main.tile[num6, num7].type = 0;
						SquareTileFrame(num6, num7);
						NetMessage.SendTile(num6, num7);
						if (genRand.Next(2) == 0)
						{
							continue;
						}
						break;
					}
					if (Main.tile[num6, num7].type == 60)
					{
						Main.tile[num6, num7].type = 23;
						SquareTileFrame(num6, num7);
						NetMessage.SendTile(num6, num7);
						if (genRand.Next(2) == 0)
						{
							continue;
						}
						break;
					}
					if (Main.tile[num6, num7].type == 69)
					{
						Main.tile[num6, num7].type = 32;
						SquareTileFrame(num6, num7);
						NetMessage.SendTile(num6, num7);
						if (genRand.Next(2) == 0)
						{
							continue;
						}
						break;
					}
					break;
				}
				return;
			}
			if (type != 109 && type != 110 && type != 113 && type != 115 && type != 116 && type != 117 && type != 118)
			{
				return;
			}
			while (true)
			{
				int num8 = i + genRand.Next(-3, 4);
				int num9 = j + genRand.Next(-3, 4);
				switch (Main.tile[num8, num9].type)
				{
				default:
					return;
				case 2:
					Main.tile[num8, num9].type = 109;
					SquareTileFrame(num8, num9);
					NetMessage.SendTile(num8, num9);
					if (genRand.Next(2) == 0)
					{
						break;
					}
					return;
				case 1:
					Main.tile[num8, num9].type = 117;
					SquareTileFrame(num8, num9);
					NetMessage.SendTile(num8, num9);
					if (genRand.Next(2) == 0)
					{
						break;
					}
					return;
				case 53:
					Main.tile[num8, num9].type = 116;
					SquareTileFrame(num8, num9);
					NetMessage.SendTile(num8, num9);
					if (genRand.Next(2) != 0)
					{
						return;
					}
					break;
				}
			}
		}

		public unsafe static bool SolidTile(int i, int j)
		{
			try
			{
				fixed (Tile* ptr = &Main.tile[i, j])
				{
					return ptr->active != 0 && Main.tileSolidNotSolidTop[ptr->type];
				}
			}
			catch
			{
				return false;
			}
		}

		public unsafe static bool SolidTileUnsafe(int i, int j)
		{
			fixed (Tile* ptr = &Main.tile[i, j])
			{
				return ptr->active != 0 && Main.tileSolidNotSolidTop[ptr->type];
			}
		}

		public static bool CanStandOnTop(int i, int j)
		{
			try
			{
				return Main.tile[i, j].canStandOnTop();
			}
			catch
			{
				return false;
			}
		}

		public unsafe static void MineHouse(int i, int j)
		{
			if (i < 50 || i > Main.maxTilesX - 50 || j < 50 || j > Main.maxTilesY - 50 || SolidTileUnsafe(i, j) || Main.tile[i, j].wall > 0)
			{
				return;
			}
			int num = genRand.Next(6, 12);
			int num2 = genRand.Next(3, 6);
			int num3 = genRand.Next(15, 30);
			int num4 = genRand.Next(15, 30);
			int num5 = j - num;
			int num6 = j + num2;
			for (int k = 0; k < 2; k++)
			{
				int num7 = i;
				int num8 = j;
				int num9 = -1;
				int num10 = num3;
				if (k == 1)
				{
					num9 = 1;
					num10 = num4;
					num7++;
				}
				do
				{
					if (num8 - num < num5)
					{
						num5 = num8 - num;
					}
					if (num8 + num2 > num6)
					{
						num6 = num8 + num2;
					}
					for (int l = 0; l < 2; l++)
					{
						int num11 = num8;
						int num12 = num;
						int num13 = -1;
						if (l == 1)
						{
							num11++;
							num12 = num2;
							num13 = 1;
						}
						bool flag = true;
						do
						{
							if (num7 != i)
							{
								fixed (Tile* ptr = &Main.tile[num7 - num9, num11])
								{
									if (ptr->wall != 27 && (ptr->active == 0 || Main.tileSolidNotSolidTop[ptr->type]))
									{
										ptr->active = 1;
										ptr->type = 30;
									}
								}
							}
							if (SolidTileUnsafe(num7 - 1, num11))
							{
								Main.tile[num7 - 1, num11].type = 30;
							}
							if (SolidTileUnsafe(num7 + 1, num11))
							{
								Main.tile[num7 + 1, num11].type = 30;
							}
							if (SolidTileUnsafe(num7, num11))
							{
								int num14 = 0;
								if (SolidTileUnsafe(num7 - 1, num11))
								{
									num14 = 1;
								}
								if (SolidTileUnsafe(num7 + 1, num11))
								{
									num14++;
								}
								if (SolidTileUnsafe(num7, num11 - 1))
								{
									num14++;
								}
								if (SolidTileUnsafe(num7, num11 + 1))
								{
									num14++;
								}
								if (num14 < 2)
								{
									Main.tile[num7, num11].active = 0;
								}
								else
								{
									flag = false;
									Main.tile[num7, num11].type = 30;
								}
							}
							else
							{
								Main.tile[num7, num11].wall = 27;
								Main.tile[num7, num11].liquid = 0;
								Main.tile[num7, num11].lava = 0;
							}
							num11 += num13;
							if (--num12 <= 0)
							{
								if (Main.tile[num7, num11].active == 0)
								{
									Main.tile[num7, num11].active = 1;
									Main.tile[num7, num11].type = 30;
								}
								break;
							}
						}
						while (flag);
					}
					num10--;
					num7 += num9;
					if (!SolidTileUnsafe(num7, num8))
					{
						continue;
					}
					int num15 = 0;
					int num16 = 0;
					int num17 = num8;
					do
					{
						num17--;
						num15++;
						if (SolidTileUnsafe(num7 - num9, num17))
						{
							num15 = 999;
							break;
						}
					}
					while (SolidTileUnsafe(num7, num17));
					num17 = num8;
					do
					{
						num17++;
						num16++;
						if (SolidTileUnsafe(num7 - num9, num17))
						{
							num16 = 999;
							break;
						}
					}
					while (SolidTileUnsafe(num7, num17));
					if (num16 <= num15)
					{
						if (num16 > num2)
						{
							num10 = 0;
						}
						else
						{
							num8 += num16 + 1;
						}
					}
					else if (num15 > num)
					{
						num10 = 0;
					}
					else
					{
						num8 -= num15 + 1;
					}
				}
				while (num10 > 0);
			}
			int num18 = i - num3 - 1;
			int num19 = i + num4 + 2;
			int num20 = num5 - 1;
			int num21 = num6 + 2;
			for (int m = num18; m < num19; m++)
			{
				for (int n = num20; n < num21; n++)
				{
					if (Main.tile[m, n].wall == 27 && Main.tile[m, n].active == 0)
					{
						if (Main.tile[m - 1, n].wall != 27 && m < i && !SolidTileUnsafe(m - 1, n))
						{
							PlaceTile(m, n, 30, mute: true);
							Main.tile[m, n].wall = 0;
						}
						if (Main.tile[m + 1, n].wall != 27 && m > i && !SolidTileUnsafe(m + 1, n))
						{
							PlaceTile(m, n, 30, mute: true);
							Main.tile[m, n].wall = 0;
						}
						for (int num22 = m - 1; num22 <= m + 1; num22++)
						{
							for (int num23 = n - 1; num23 <= n + 1; num23++)
							{
								if (SolidTileUnsafe(num22, num23))
								{
									Main.tile[num22, num23].type = 30;
								}
							}
						}
					}
					if (Main.tile[m, n].type == 30 && Main.tile[m - 1, n].wall == 27 && Main.tile[m + 1, n].wall == 27 && (Main.tile[m, n - 1].wall == 27 || Main.tile[m, n - 1].active != 0) && (Main.tile[m, n + 1].wall == 27 || Main.tile[m, n + 1].active != 0))
					{
						Main.tile[m, n].active = 0;
						Main.tile[m, n].wall = 27;
					}
				}
			}
			for (int num24 = num18; num24 < num19; num24++)
			{
				for (int num25 = num20; num25 < num21; num25++)
				{
					if (Main.tile[num24, num25].type == 30)
					{
						if (Main.tile[num24 - 1, num25].wall == 27 && Main.tile[num24 + 1, num25].wall == 27 && Main.tile[num24 - 1, num25].active == 0 && Main.tile[num24 + 1, num25].active == 0)
						{
							Main.tile[num24, num25].active = 0;
							Main.tile[num24, num25].wall = 27;
						}
						if (Main.tile[num24, num25 - 1].type != 21 && Main.tile[num24 - 1, num25].wall == 27 && Main.tile[num24 + 1, num25].type == 30 && Main.tile[num24 + 2, num25].wall == 27 && Main.tile[num24 - 1, num25].active == 0 && Main.tile[num24 + 2, num25].active == 0)
						{
							Main.tile[num24, num25].active = 0;
							Main.tile[num24, num25].wall = 27;
							Main.tile[num24 + 1, num25].active = 0;
							Main.tile[num24 + 1, num25].wall = 27;
						}
						if (Main.tile[num24, num25 - 1].wall == 27 && Main.tile[num24, num25 + 1].wall == 27 && Main.tile[num24, num25 - 1].active == 0 && Main.tile[num24, num25 + 1].active == 0)
						{
							Main.tile[num24, num25].active = 0;
							Main.tile[num24, num25].wall = 27;
						}
					}
				}
			}
			for (int num26 = num18; num26 < num19; num26++)
			{
				for (int num27 = num21; num27 > num20; num27--)
				{
					bool flag2 = false;
					if (Main.tile[num26, num27].active != 0 && Main.tile[num26, num27].type == 30)
					{
						int num28 = -1;
						for (int num29 = 0; num29 < 2; num29++)
						{
							if (!SolidTileUnsafe(num26 + num28, num27) && Main.tile[num26 + num28, num27].wall == 0)
							{
								int num30 = 0;
								int num31 = num27;
								int num32 = num27;
								while (Main.tile[num26, num31].active != 0 && Main.tile[num26, num31].type == 30 && !SolidTileUnsafe(num26 + num28, num31) && Main.tile[num26 + num28, num31].wall == 0)
								{
									num31--;
									num30++;
								}
								num31++;
								int num33 = num31 + 1;
								if (num30 > 4)
								{
									if (genRand.Next(2) == 0)
									{
										num31 = num32 - 1;
										bool flag3 = true;
										for (int num34 = num26 - 2; num34 <= num26 + 2; num34++)
										{
											for (int num35 = num31 - 2; num35 <= num31; num35++)
											{
												if (num34 != num26 && Main.tile[num34, num35].active != 0)
												{
													flag3 = false;
												}
											}
										}
										if (flag3)
										{
											Main.tile[num26, num31].active = 0;
											Main.tile[num26, num31 - 1].active = 0;
											Main.tile[num26, num31 - 2].active = 0;
											PlaceTile(num26, num31, 10, mute: true);
											flag2 = true;
										}
									}
									if (!flag2)
									{
										for (int num36 = num33; num36 < num32; num36++)
										{
											Main.tile[num26, num36].type = 124;
										}
									}
								}
							}
							num28 = 1;
						}
					}
					if (flag2)
					{
						break;
					}
				}
			}
			int num37;
			for (num37 = num18; num37 < num19; num37++)
			{
				bool flag4 = true;
				for (int num38 = num20; num38 < num21; num38++)
				{
					for (int num39 = num37 - 2; num39 <= num37 + 2; num39++)
					{
						if (Main.tile[num39, num38].active != 0 && (!SolidTileUnsafe(num39, num38) || Main.tile[num39, num38].type == 10))
						{
							flag4 = false;
						}
					}
				}
				if (flag4)
				{
					for (int num40 = num20; num40 < num21; num40++)
					{
						if (Main.tile[num37, num40].wall == 27 && Main.tile[num37, num40].active == 0)
						{
							PlaceTile(num37, num40, 124, mute: true);
						}
					}
				}
				num37 += genRand.Next(3);
			}
			for (int num41 = 0; num41 < 4; num41++)
			{
				int num42 = genRand.Next(num18 + 2, num19 - 1);
				int num43 = genRand.Next(num20 + 2, num21 - 1);
				while (Main.tile[num42, num43].wall != 27)
				{
					num42 = genRand.Next(num18 + 2, num19 - 1);
					num43 = genRand.Next(num20 + 2, num21 - 1);
				}
				while (Main.tile[num42, num43].active != 0)
				{
					num43--;
				}
				for (; Main.tile[num42, num43].active == 0; num43++)
				{
				}
				num43--;
				if (Main.tile[num42, num43].wall != 27)
				{
					continue;
				}
				if (genRand.Next(3) == 0)
				{
					int type;
					switch (genRand.Next(9))
					{
					case 0:
						type = 14;
						break;
					case 1:
						type = 16;
						break;
					case 2:
						type = 18;
						break;
					case 3:
						type = 86;
						break;
					case 4:
						type = 87;
						break;
					case 5:
						type = 94;
						break;
					case 6:
						type = 101;
						break;
					case 7:
						type = 104;
						break;
					default:
						type = 106;
						break;
					}
					PlaceTile(num42, num43, type, mute: true);
				}
				else
				{
					int style = genRand.Next(2, 43);
					PlaceTile(num42, num43, 105, mute: true, forced: true, -1, style);
				}
			}
		}

		public static void CountTiles(int X)
		{
			if (X == 0)
			{
				totalEvil = totalEvil2;
				totalSolid = totalSolid2;
				totalGood = totalGood2;
				if (!gen)
				{
					if (totalSolid > 0)
					{
						tGood = (byte)Math.Round((float)(totalGood * 100) / (float)totalSolid);
						tEvil = (byte)Math.Round((float)(totalEvil * 100) / (float)totalSolid);
						if ((float)(int)tEvil >= 50f)
						{
							UI.SetTriggerStateForAll(Trigger.CorruptedWorld);
						}
						if ((float)(int)tGood >= 50f)
						{
							UI.SetTriggerStateForAll(Trigger.HallowedWorld);
						}
					}
					else
					{
						tGood = 0;
						tEvil = 0;
					}
					NetMessage.CreateMessage0(57);
					NetMessage.SendMessage();
				}
				totalEvil2 = 0;
				totalSolid2 = 0;
				totalGood2 = 0;
			}
			int worldSurface = Main.worldSurface;
			int num = Main.maxTilesY - 1;
			do
			{
				if (SolidTileUnsafe(X, num))
				{
					switch (Main.tile[X, num].type)
					{
					case 109:
					case 116:
					case 117:
						totalGood2++;
						break;
					case 23:
					case 25:
					case 112:
						totalEvil2++;
						break;
					}
					totalSolid2++;
				}
			}
			while (--num > worldSurface);
			do
			{
				if (SolidTileUnsafe(X, num))
				{
					switch (Main.tile[X, num].type)
					{
					case 109:
					case 116:
					case 117:
						totalGood2 += 5;
						break;
					case 23:
					case 25:
					case 112:
						totalEvil2 += 5;
						break;
					}
					totalSolid2 += 5;
				}
			}
			while (--num >= 0);
		}

		public unsafe static void UpdateWorld()
		{
			UpdateSand();
			UpdateMech();
			if ((++Liquid.skipCount & 1) == 0)
			{
				Liquid.UpdateLiquid();
			}
			if (hardLock)
			{
				return;
			}
			if ((++totalD & 0xF) == 0)
			{
				CountTiles(totalX);
				if (++totalX >= Main.maxTilesX)
				{
					totalX = 0;
				}
			}
			bool flag = false;
			if (Main.invasionType > 0)
			{
				spawnDelay = 0;
			}
			if (++spawnDelay >= 20)
			{
				flag = true;
				spawnDelay = 0;
				if (spawnNPC != 37)
				{
					for (int i = 0; i < 196; i++)
					{
						if (Main.npc[i].active != 0 && Main.npc[i].homeless && Main.npc[i].townNPC)
						{
							spawnNPC = Main.npc[i].type;
							break;
						}
					}
				}
			}
			float num = 3E-05f;
			for (int num2 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * num); num2 > 0; num2--)
			{
				int num3 = genRand.Next(10, Main.maxTilesX - 10);
				int num4 = genRand.Next(10, Main.worldSurface - 1);
				int num5 = num3 - 1;
				int num6 = num3 + 2;
				int num7 = num4 - 1;
				int num8 = num4 + 2;
				if (num5 < 10)
				{
					num5 = 10;
				}
				if (num6 > Main.maxTilesX - 10)
				{
					num6 = Main.maxTilesX - 10;
				}
				if (num7 < 10)
				{
					num7 = 10;
				}
				if (num8 > Main.maxTilesY - 10)
				{
					num8 = Main.maxTilesY - 10;
				}
				fixed (Tile* ptr = &Main.tile[num3, num4])
				{
					int num9 = ptr->type;
					if (num9 >= 82 && num9 <= 84)
					{
						GrowAlch(num3, num4);
					}
					if (ptr->liquid > 32)
					{
						if (ptr->active != 0 && (num9 == 3 || num9 == 20 || num9 == 24 || num9 == 27 || num9 == 73))
						{
							KillTile(num3, num4);
							if (Main.netMode == 2)
							{
								NetMessage.CreateMessage5(17, 0, num3, num4, 0);
								NetMessage.SendMessage();
							}
						}
					}
					else if (ptr->active != 0)
					{
						if (Main.hardMode)
						{
							hardUpdateWorld(num3, num4);
						}
						switch (num9)
						{
						case 80:
							if (genRand.Next(15) == 0)
							{
								GrowCactus(num3, num4);
							}
							goto end_IL_0195;
						case 53:
							if (Main.tile[num3, num7].active == 0)
							{
								if (num3 < 250 || num3 > Main.maxTilesX - 250)
								{
									if (genRand.Next(500) == 0 && Main.tile[num3, num7].liquid == byte.MaxValue && Main.tile[num3, num7 - 1].liquid == byte.MaxValue && Main.tile[num3, num7 - 2].liquid == byte.MaxValue && Main.tile[num3, num7 - 3].liquid == byte.MaxValue && Main.tile[num3, num7 - 4].liquid == byte.MaxValue && PlaceTile(num3, num7, 81, mute: true))
									{
										NetMessage.SendTile(num3, num7);
									}
								}
								else if (num3 > 400 && num3 < Main.maxTilesX - 400 && genRand.Next(300) == 0)
								{
									GrowCactus(num3, num4);
								}
							}
							goto end_IL_0195;
						case 112:
						case 116:
							if (Main.tile[num3, num7].active == 0 && num3 > 400 && num3 < Main.maxTilesX - 400 && genRand.Next(300) == 0)
							{
								GrowCactus(num3, num4);
							}
							goto end_IL_0195;
						case 78:
							if (Main.tile[num3, num7].active == 0 && PlaceTile(num3, num7, 3, mute: true))
							{
								NetMessage.SendTile(num3, num7);
							}
							goto end_IL_0195;
						case 2:
						case 23:
						case 32:
						case 109:
						{
							if (Main.tile[num3, num7].active == 0 && genRand.Next(12) == 0 && num9 == 2 && PlaceTile(num3, num7, 3, mute: true))
							{
								NetMessage.SendTile(num3, num7);
							}
							if (Main.tile[num3, num7].active == 0 && genRand.Next(10) == 0 && num9 == 23 && PlaceTile(num3, num7, 24, mute: true))
							{
								NetMessage.SendTile(num3, num7);
							}
							if (Main.tile[num3, num7].active == 0 && genRand.Next(10) == 0 && num9 == 109 && PlaceTile(num3, num7, 110, mute: true))
							{
								NetMessage.SendTile(num3, num7);
							}
							bool flag2 = false;
							for (int j = num5; j < num6; j++)
							{
								for (int k = num7; k < num8; k++)
								{
									if ((num3 != j || num4 != k) && Main.tile[j, k].active != 0)
									{
										if (num9 == 32)
										{
											num9 = 23;
										}
										if (Main.tile[j, k].type == 0 || (num9 == 23 && Main.tile[j, k].type == 2) || (num9 == 23 && Main.tile[j, k].type == 109))
										{
											SpreadGrass(j, k, 0, num9, repeat: false);
											if (num9 == 23)
											{
												SpreadGrass(j, k, 2, num9, repeat: false);
												SpreadGrass(j, k, 109, num9, repeat: false);
											}
											if (Main.tile[j, k].type == num9)
											{
												SquareTileFrame(j, k);
												flag2 = true;
											}
										}
										if (Main.tile[j, k].type == 0 || (num9 == 109 && Main.tile[j, k].type == 2) || (num9 == 109 && Main.tile[j, k].type == 23))
										{
											SpreadGrass(j, k, 0, num9, repeat: false);
											if (num9 == 109)
											{
												SpreadGrass(j, k, 2, num9, repeat: false);
												SpreadGrass(j, k, 23, num9, repeat: false);
											}
											if (Main.tile[j, k].type == num9)
											{
												SquareTileFrame(j, k);
												flag2 = true;
											}
										}
									}
								}
							}
							if (flag2)
							{
								NetMessage.SendTileSquare(num3, num4, 3);
							}
							goto end_IL_0195;
						}
						case 20:
							if (genRand.Next(20) == 0 && !PlayerLOS(num3, num4))
							{
								GrowTree(num3, num4);
							}
							goto end_IL_0195;
						case 3:
							if (genRand.Next(20) != 0)
							{
								break;
							}
							if (ptr->frameX < 144)
							{
								ptr->type = 73;
								NetMessage.SendTileSquare(num3, num4, 3);
							}
							goto end_IL_0195;
						}
						if (num9 == 110 && genRand.Next(20) == 0)
						{
							if (ptr->frameX < 144)
							{
								ptr->type = 113;
								NetMessage.SendTileSquare(num3, num4, 3);
							}
						}
						else if (num9 == 32 && genRand.Next(3) == 0)
						{
							int num10 = num3;
							int num11 = num4;
							int num12 = 0;
							if (Main.tile[num10 + 1, num11].active != 0 && Main.tile[num10 + 1, num11].type == 32)
							{
								num12++;
							}
							if (Main.tile[num10 - 1, num11].active != 0 && Main.tile[num10 - 1, num11].type == 32)
							{
								num12++;
							}
							if (Main.tile[num10, num11 + 1].active != 0 && Main.tile[num10, num11 + 1].type == 32)
							{
								num12++;
							}
							if (Main.tile[num10, num11 - 1].active != 0 && Main.tile[num10, num11 - 1].type == 32)
							{
								num12++;
							}
							if (num12 < 3 || num9 == 23)
							{
								switch (genRand.Next(4))
								{
								case 0:
									num11--;
									break;
								case 1:
									num11++;
									break;
								case 2:
									num10--;
									break;
								case 3:
									num10++;
									break;
								}
								if (Main.tile[num10, num11].active == 0)
								{
									num12 = 0;
									if (Main.tile[num10 + 1, num11].active != 0 && Main.tile[num10 + 1, num11].type == 32)
									{
										num12 = 1;
									}
									if (Main.tile[num10 - 1, num11].active != 0 && Main.tile[num10 - 1, num11].type == 32)
									{
										num12++;
									}
									if (Main.tile[num10, num11 + 1].active != 0 && Main.tile[num10, num11 + 1].type == 32)
									{
										num12++;
									}
									if (Main.tile[num10, num11 - 1].active != 0 && Main.tile[num10, num11 - 1].type == 32)
									{
										num12++;
									}
									if (num12 < 2)
									{
										int num13 = 7;
										int num14 = num10 - num13;
										int num15 = num10 + num13;
										int num16 = num11 - num13;
										int num17 = num11 + num13;
										for (int l = num14; l < num15; l++)
										{
											for (int m = num16; m < num17; m++)
											{
												if (Math.Abs(l - num10) * 2 + Math.Abs(m - num11) < 9 && Main.tile[l, m].active != 0 && Main.tile[l, m].type == 23 && Main.tile[l, m - 1].active != 0 && Main.tile[l, m - 1].type == 32 && Main.tile[l, m - 1].liquid == 0)
												{
													Main.tile[num10, num11].type = 32;
													Main.tile[num10, num11].active = 1;
													SquareTileFrame(num10, num11);
													NetMessage.SendTileSquare(num10, num11, 3);
													break;
												}
											}
										}
									}
								}
							}
						}
						else
						{
							switch (num9)
							{
							case 2:
							case 52:
								if (genRand.Next(40) == 0 && Main.tile[num3, num4 + 1].active == 0 && Main.tile[num3, num4 + 1].lava == 0)
								{
									for (int num19 = num4; num19 > num4 - 10; num19--)
									{
										if (Main.tile[num3, num19].active != 0 && Main.tile[num3, num19].type == 2)
										{
											num19 = num4 + 1;
											Main.tile[num3, num19].type = 52;
											Main.tile[num3, num19].active = 1;
											SquareTileFrame(num3, num19);
											NetMessage.SendTileSquare(num3, num19, 3);
											break;
										}
									}
								}
								goto end_IL_0195;
							case 60:
							{
								if (Main.tile[num3, num7].active == 0 && genRand.Next(7) == 0)
								{
									if (PlaceTile(num3, num7, 61, mute: true))
									{
										NetMessage.SendTile(num3, num7);
									}
								}
								else if (genRand.Next(500) == 0 && (Main.tile[num3, num7].active == 0 || Main.tile[num3, num7].type == 61 || Main.tile[num3, num7].type == 74 || Main.tile[num3, num7].type == 69) && !PlayerLOS(num3, num4))
								{
									GrowTree(num3, num4);
								}
								bool flag3 = false;
								for (int n = num5; n < num6; n++)
								{
									for (int num18 = num7; num18 < num8; num18++)
									{
										if ((num3 != n || num4 != num18) && Main.tile[n, num18].active != 0 && Main.tile[n, num18].type == 59)
										{
											SpreadGrass(n, num18, 59, num9, repeat: false);
											if (Main.tile[n, num18].type == num9)
											{
												SquareTileFrame(n, num18);
												flag3 = true;
											}
										}
									}
								}
								if (flag3)
								{
									NetMessage.SendTileSquare(num3, num4, 3);
								}
								goto end_IL_0195;
							}
							case 61:
								if (genRand.Next(3) != 0)
								{
									break;
								}
								if (ptr->frameX < 144)
								{
									ptr->type = 74;
									NetMessage.SendTileSquare(num3, num4, 3);
								}
								goto end_IL_0195;
							}
							switch (num9)
							{
							case 60:
							case 62:
								if (genRand.Next(15) == 0 && Main.tile[num3, num4 + 1].active == 0 && Main.tile[num3, num4 + 1].lava == 0)
								{
									for (int num21 = num4; num21 > num4 - 10; num21--)
									{
										if (Main.tile[num3, num21].active != 0 && Main.tile[num3, num21].type == 60)
										{
											num21 = num4 + 1;
											Main.tile[num3, num21].type = 62;
											Main.tile[num3, num21].active = 1;
											SquareTileFrame(num3, num21);
											NetMessage.SendTileSquare(num3, num21, 3);
											break;
										}
									}
								}
								break;
							case 109:
							case 115:
								if (genRand.Next(15) == 0 && Main.tile[num3, num4 + 1].active == 0 && Main.tile[num3, num4 + 1].lava == 0)
								{
									for (int num20 = num4; num20 > num4 - 10; num20--)
									{
										if (Main.tile[num3, num20].active != 0 && Main.tile[num3, num20].type == 109)
										{
											num20 = num4 + 1;
											Main.tile[num3, num20].type = 115;
											Main.tile[num3, num20].active = 1;
											SquareTileFrame(num3, num20);
											NetMessage.SendTileSquare(num3, num20, 3);
											break;
										}
									}
								}
								break;
							}
						}
					}
					else if (flag && spawnNPC > 0)
					{
						SpawnNPC(num3, num4);
					}
					end_IL_0195:;
				}
			}
			float num22 = 1.5E-05f;
			for (int num23 = (int)((float)(Main.maxTilesX * Main.maxTilesY) * num22); num23 > 0; num23--)
			{
				int num24 = genRand.Next(10, Main.maxTilesX - 10);
				int num25 = genRand.Next(Main.worldSurface - 1, Main.maxTilesY - 20);
				int num26 = num24 - 1;
				int num27 = num24 + 2;
				int num28 = num25 - 1;
				int num29 = num25 + 2;
				if (num26 < 10)
				{
					num26 = 10;
				}
				if (num27 > Main.maxTilesX - 10)
				{
					num27 = Main.maxTilesX - 10;
				}
				if (num28 < 10)
				{
					num28 = 10;
				}
				if (num29 > Main.maxTilesY - 10)
				{
					num29 = Main.maxTilesY - 10;
				}
				fixed (Tile* ptr2 = &Main.tile[num24, num25])
				{
					int type = ptr2->type;
					if (type >= 82 && type <= 84)
					{
						GrowAlch(num24, num25);
					}
					if (ptr2->liquid <= 32)
					{
						if (ptr2->active != 0)
						{
							if (Main.hardMode)
							{
								hardUpdateWorld(num24, num25);
							}
							switch (type)
							{
							case 23:
								if (Main.tile[num24, num28].active == 0 && genRand.Next(1) == 0 && PlaceTile(num24, num28, 24, mute: true))
								{
									NetMessage.SendTile(num24, num28);
								}
								break;
							case 32:
								if (genRand.Next(3) == 0)
								{
									int num43 = num24;
									int num44 = num25;
									int num45 = 0;
									if (Main.tile[num43 + 1, num44].active != 0 && Main.tile[num43 + 1, num44].type == 32)
									{
										num45++;
									}
									if (Main.tile[num43 - 1, num44].active != 0 && Main.tile[num43 - 1, num44].type == 32)
									{
										num45++;
									}
									if (Main.tile[num43, num44 + 1].active != 0 && Main.tile[num43, num44 + 1].type == 32)
									{
										num45++;
									}
									if (Main.tile[num43, num44 - 1].active != 0 && Main.tile[num43, num44 - 1].type == 32)
									{
										num45++;
									}
									if (num45 < 3 || type == 23)
									{
										switch (genRand.Next(4))
										{
										case 0:
											num44--;
											break;
										case 1:
											num44++;
											break;
										case 2:
											num43--;
											break;
										case 3:
											num43++;
											break;
										}
										if (Main.tile[num43, num44].active == 0)
										{
											num45 = 0;
											if (Main.tile[num43 + 1, num44].active != 0 && Main.tile[num43 + 1, num44].type == 32)
											{
												num45++;
											}
											if (Main.tile[num43 - 1, num44].active != 0 && Main.tile[num43 - 1, num44].type == 32)
											{
												num45++;
											}
											if (Main.tile[num43, num44 + 1].active != 0 && Main.tile[num43, num44 + 1].type == 32)
											{
												num45++;
											}
											if (Main.tile[num43, num44 - 1].active != 0 && Main.tile[num43, num44 - 1].type == 32)
											{
												num45++;
											}
											if (num45 < 2)
											{
												int num46 = 7;
												int num47 = num43 - num46;
												int num48 = num43 + num46;
												int num49 = num44 - num46;
												int num50 = num44 + num46;
												for (int num51 = num47; num51 < num48; num51++)
												{
													for (int num52 = num49; num52 < num50; num52++)
													{
														if (Math.Abs(num51 - num43) * 2 + Math.Abs(num52 - num44) < 9 && Main.tile[num51, num52].active != 0 && Main.tile[num51, num52].type == 23 && Main.tile[num51, num52 - 1].active != 0 && Main.tile[num51, num52 - 1].type == 32 && Main.tile[num51, num52 - 1].liquid == 0)
														{
															Main.tile[num43, num44].type = 32;
															Main.tile[num43, num44].active = 1;
															SquareTileFrame(num43, num44);
															NetMessage.SendTileSquare(num43, num44, 3);
															break;
														}
													}
												}
											}
										}
									}
								}
								break;
							case 60:
								if (Main.tile[num24, num28].active == 0 && genRand.Next(10) == 0)
								{
									if (PlaceTile(num24, num28, 61, mute: true))
									{
										NetMessage.SendTile(num24, num28);
									}
								}
								else
								{
									bool flag5 = false;
									for (int num53 = num26; num53 < num27; num53++)
									{
										for (int num54 = num28; num54 < num29; num54++)
										{
											if ((num24 != num53 || num25 != num54) && Main.tile[num53, num54].type == 59 && Main.tile[num53, num54].active != 0)
											{
												SpreadGrass(num53, num54, 59, type, repeat: false);
												if (Main.tile[num53, num54].type == type)
												{
													SquareTileFrame(num53, num54);
													flag5 = true;
												}
											}
										}
									}
									if (flag5)
									{
										NetMessage.SendTileSquare(num24, num25, 3);
									}
								}
								break;
							case 61:
								if (ptr2->frameX < 144 && genRand.Next(3) == 0)
								{
									ptr2->type = 74;
									NetMessage.SendTileSquare(num24, num25, 3);
								}
								break;
							default:
								switch (type)
								{
								case 60:
								case 62:
									if (genRand.Next(5) == 0 && Main.tile[num24, num25 + 1].active == 0 && Main.tile[num24, num25 + 1].lava == 0)
									{
										for (int num42 = num25; num42 > num25 - 10; num42--)
										{
											if (Main.tile[num24, num42].active != 0 && Main.tile[num24, num42].type == 60)
											{
												num42 = num25 + 1;
												Main.tile[num24, num42].type = 62;
												Main.tile[num24, num42].active = 1;
												SquareTileFrame(num24, num42);
												NetMessage.SendTileSquare(num24, num42, 3);
												break;
											}
										}
									}
									break;
								case 69:
									if (genRand.Next(3) == 0)
									{
										int num32 = num24;
										int num33 = num25;
										int num34 = 0;
										if (Main.tile[num32 + 1, num33].active != 0 && Main.tile[num32 + 1, num33].type == 69)
										{
											num34++;
										}
										if (Main.tile[num32 - 1, num33].active != 0 && Main.tile[num32 - 1, num33].type == 69)
										{
											num34++;
										}
										if (Main.tile[num32, num33 + 1].active != 0 && Main.tile[num32, num33 + 1].type == 69)
										{
											num34++;
										}
										if (Main.tile[num32, num33 - 1].active != 0 && Main.tile[num32, num33 - 1].type == 69)
										{
											num34++;
										}
										if (num34 < 3 || type == 60)
										{
											switch (genRand.Next(4))
											{
											case 0:
												num33--;
												break;
											case 1:
												num33++;
												break;
											case 2:
												num32--;
												break;
											case 3:
												num32++;
												break;
											}
											if (Main.tile[num32, num33].active == 0)
											{
												num34 = 0;
												if (Main.tile[num32 + 1, num33].active != 0 && Main.tile[num32 + 1, num33].type == 69)
												{
													num34++;
												}
												if (Main.tile[num32 - 1, num33].active != 0 && Main.tile[num32 - 1, num33].type == 69)
												{
													num34++;
												}
												if (Main.tile[num32, num33 + 1].active != 0 && Main.tile[num32, num33 + 1].type == 69)
												{
													num34++;
												}
												if (Main.tile[num32, num33 - 1].active != 0 && Main.tile[num32, num33 - 1].type == 69)
												{
													num34++;
												}
												if (num34 < 2)
												{
													int num35 = 7;
													int num36 = num32 - num35;
													int num37 = num32 + num35;
													int num38 = num33 - num35;
													int num39 = num33 + num35;
													for (int num40 = num36; num40 < num37; num40++)
													{
														for (int num41 = num38; num41 < num39; num41++)
														{
															if (Math.Abs(num40 - num32) * 2 + Math.Abs(num41 - num33) < 9 && Main.tile[num40, num41].active != 0 && Main.tile[num40, num41].type == 60 && Main.tile[num40, num41 - 1].active != 0 && Main.tile[num40, num41 - 1].type == 69 && Main.tile[num40, num41 - 1].liquid == 0)
															{
																Main.tile[num32, num33].type = 69;
																Main.tile[num32, num33].active = 1;
																SquareTileFrame(num32, num33);
																NetMessage.SendTileSquare(num32, num33, 3);
																break;
															}
														}
													}
												}
											}
										}
									}
									break;
								case 70:
									if (Main.tile[num24, num28].active == 0 && genRand.Next(10) == 0)
									{
										if (PlaceTile(num24, num28, 71, mute: true))
										{
											NetMessage.SendTile(num24, num28);
										}
									}
									else if (genRand.Next(200) == 0 && !PlayerLOS(num24, num25))
									{
										GrowShroom(num24, num25);
									}
									else
									{
										bool flag4 = false;
										for (int num30 = num26; num30 < num27; num30++)
										{
											for (int num31 = num28; num31 < num29; num31++)
											{
												if ((num24 != num30 || num25 != num31) && Main.tile[num30, num31].active != 0 && Main.tile[num30, num31].type == 59)
												{
													SpreadGrass(num30, num31, 59, type, repeat: false);
													if (Main.tile[num30, num31].type == type)
													{
														SquareTileFrame(num30, num31);
														flag4 = true;
													}
												}
											}
										}
										if (flag4)
										{
											NetMessage.SendTileSquare(num24, num25, 3);
										}
									}
									break;
								}
								break;
							}
						}
						else if (flag && spawnNPC > 0)
						{
							SpawnNPC(num24, num25);
						}
					}
				}
			}
			if (Main.rand.Next(100) == 0)
			{
				PlantAlch();
			}
			if (!Main.gameTime.dayTime)
			{
				float num55 = (float)Main.maxTilesX / 4200f;
				if ((float)Main.rand.Next(8000) < 10f * num55)
				{
					int num56 = 12;
					int num57 = Main.rand.Next(Main.maxTilesX - 50) + 100;
					num57 *= 16;
					int num58 = Main.rand.Next((int)((double)Main.maxTilesY * 0.05));
					num58 *= 16;
					Vector2 vector = new Vector2(num57, num58);
					float num59 = Main.rand.Next(-100, 101);
					float num60 = Main.rand.Next(200) + 100;
					float num61 = (float)Math.Sqrt(num59 * num59 + num60 * num60);
					num61 = (float)num56 / num61;
					num59 *= num61;
					num60 *= num61;
					Projectile.NewProjectile(vector.X, vector.Y, num59, num60, 12, 1000, 10f);
				}
			}
		}

		public static bool PlaceWall(int i, int j, int type)
		{
			if (i <= 1 || j <= 1 || i >= Main.maxTilesX - 2 || j >= Main.maxTilesY - 2)
			{
				return false;
			}
			if (Main.tile[i, j].wall == 0)
			{
				Main.tile[i, j].wall = (byte)type;
				WallFrame(i - 1, j - 1);
				WallFrame(i - 1, j);
				WallFrame(i - 1, j + 1);
				WallFrame(i, j - 1);
				WallFrame(i, j, resetFrame: true);
				WallFrame(i, j + 1);
				WallFrame(i + 1, j - 1);
				WallFrame(i + 1, j);
				WallFrame(i + 1, j + 1);
				Main.PlaySound(0, i << 4, j << 4);
				return true;
			}
			return false;
		}

		public unsafe static void AddPlants()
		{
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = 0; i < Main.maxTilesX; i++)
				{
					Tile* ptr2 = ptr + (i * 1440 + 5);
					int num = 5;
					while (num < Main.maxTilesY)
					{
						if (ptr2->active != 0)
						{
							if (ptr2->type == 2)
							{
								ptr2--;
								if (ptr2->active == 0)
								{
									PlaceTile(i, num - 1, 3, mute: true);
								}
								ptr2++;
							}
							else if (ptr2->type == 23)
							{
								ptr2--;
								if (ptr2->active == 0)
								{
									PlaceTile(i, num - 1, 24, mute: true);
								}
								ptr2++;
							}
						}
						num++;
						ptr2++;
					}
				}
			}
		}

		public static void SpreadGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true)
		{
			try
			{
				if (Main.tile[i, j].type == dirt && Main.tile[i, j].active != 0 && (j >= Main.worldSurface || grass != 70) && (j < Main.worldSurface || dirt != 0))
				{
					int num = i - 1;
					int num2 = i + 2;
					int num3 = j - 1;
					int num4 = j + 2;
					if (num < 0)
					{
						num = 0;
					}
					if (num2 > Main.maxTilesX)
					{
						num2 = Main.maxTilesX;
					}
					if (num3 < 0)
					{
						num3 = 0;
					}
					if (num4 > Main.maxTilesY)
					{
						num4 = Main.maxTilesY;
					}
					bool flag = true;
					for (int k = num; k < num2; k++)
					{
						for (int l = num3; l < num4; l++)
						{
							if (Main.tile[k, l].active == 0 || !Main.tileSolid[Main.tile[k, l].type])
							{
								flag = false;
							}
							if (Main.tile[k, l].lava != 0 && Main.tile[k, l].liquid > 0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag && (grass != 23 || Main.tile[i, j - 1].type != 27))
					{
						Main.tile[i, j].type = (byte)grass;
						for (int m = num; m < num2; m++)
						{
							for (int n = num3; n < num4; n++)
							{
								if (Main.tile[m, n].active != 0 && Main.tile[m, n].type == dirt)
								{
									try
									{
										if (repeat && grassSpread < 400)
										{
											grassSpread++;
											SpreadGrass(m, n, dirt, grass);
											grassSpread--;
										}
									}
									catch
									{
									}
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		public static void ChasmRunnerSideways(int i, int j, int direction, int steps)
		{
			Vector2 vector = default(Vector2);
			Vector2 vector2 = default(Vector2);
			float num = steps;
			vector.X = i;
			vector.Y = j;
			vector2.X = (float)genRand.Next(10, 21) * 0.1f * (float)direction;
			vector2.Y = (float)genRand.Next(-10, 10) * 0.01f;
			int num2 = genRand.Next(5) + 7;
			while (num2 > 0)
			{
				if (num > 0f)
				{
					num2 += genRand.Next(3);
					num2 -= genRand.Next(3);
					if (num2 < 7)
					{
						num2 = 7;
					}
					else if (num2 > 20)
					{
						num2 = 20;
					}
					if (num == 1f && num2 < 10)
					{
						num2 = 10;
					}
				}
				else
				{
					num2 -= genRand.Next(4);
				}
				if (vector.Y > (float)Main.rockLayer && num > 0f)
				{
					num = 0f;
				}
				num -= 1f;
				int num3 = (int)(vector.X - (float)num2 * 0.5f);
				int num4 = (int)(vector.X + (float)num2 * 0.5f);
				int num5 = (int)(vector.Y - (float)num2 * 0.5f);
				int num6 = (int)(vector.Y + (float)num2 * 0.5f);
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 > Main.maxTilesX - 1)
				{
					num4 = Main.maxTilesX - 1;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesY)
				{
					num6 = Main.maxTilesY;
				}
				for (int k = num3; k < num4; k++)
				{
					for (int l = num5; l < num6; l++)
					{
						if (Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y) < (float)num2 * 0.5f * (1f + (float)genRand.Next(-10, 11) * 0.015f) && Main.tile[k, l].type != 31 && Main.tile[k, l].type != 22)
						{
							Main.tile[k, l].active = 0;
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.Y += (float)genRand.Next(-10, 10) * 0.1f;
				if (vector.Y < (float)(j - 20))
				{
					vector2.Y += (float)genRand.Next(20) * 0.01f;
				}
				else if (vector.Y > (float)(j + 20))
				{
					vector2.Y -= (float)genRand.Next(20) * 0.01f;
				}
				if ((double)vector2.Y < -0.5)
				{
					vector2.Y = -0.5f;
				}
				else if ((double)vector2.Y > 0.5)
				{
					vector2.Y = 0.5f;
				}
				vector2.X += (float)genRand.Next(-10, 11) * 0.01f;
				switch (direction)
				{
				case -1:
					if ((double)vector2.X > -0.5)
					{
						vector2.X = -0.5f;
					}
					else if (vector2.X < -2f)
					{
						vector2.X = -2f;
					}
					break;
				case 1:
					if ((double)vector2.X < 0.5)
					{
						vector2.X = 0.5f;
					}
					else if (vector2.X > 2f)
					{
						vector2.X = 2f;
					}
					break;
				}
				num3 = (int)(vector.X - (float)num2 * 1.1f);
				num4 = (int)(vector.X + (float)num2 * 1.1f);
				num5 = (int)(vector.Y - (float)num2 * 1.1f);
				num6 = (int)(vector.Y + (float)num2 * 1.1f);
				if (num3 < 1)
				{
					num3 = 1;
				}
				if (num4 > Main.maxTilesX - 1)
				{
					num4 = Main.maxTilesX - 1;
				}
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesY)
				{
					num6 = Main.maxTilesY;
				}
				for (int m = num3; m < num4; m++)
				{
					for (int n = num5; n < num6; n++)
					{
						if (Math.Abs((float)m - vector.X) + Math.Abs((float)n - vector.Y) < (float)num2 * 1.1f * (1f + (float)genRand.Next(-10, 11) * 0.015f) && Main.tile[m, n].wall != 3)
						{
							if (Main.tile[m, n].type != 25 && n > j + genRand.Next(3, 20))
							{
								Main.tile[m, n].active = 1;
							}
							Main.tile[m, n].active = 1;
							if (Main.tile[m, n].type != 31 && Main.tile[m, n].type != 22)
							{
								Main.tile[m, n].type = 25;
							}
							if (Main.tile[m, n].wall == 2)
							{
								Main.tile[m, n].wall = 0;
							}
						}
					}
				}
				for (int num7 = num3; num7 < num4; num7++)
				{
					for (int num8 = num5; num8 < num6; num8++)
					{
						if (Math.Abs((float)num7 - vector.X) + Math.Abs((float)num8 - vector.Y) < (float)num2 * 1.1f * (1f + (float)genRand.Next(-10, 11) * 0.015f) && Main.tile[num7, num8].wall != 3)
						{
							if (Main.tile[num7, num8].type != 31 && Main.tile[num7, num8].type != 22)
							{
								Main.tile[num7, num8].type = 25;
							}
							Main.tile[num7, num8].active = 1;
							if (Main.tile[num7, num8].wall == 0)
							{
								Main.tile[num7, num8].wall = 3;
							}
						}
					}
				}
			}
			if (genRand.Next(3) == 0)
			{
				int num9 = (int)vector.X;
				int num10;
				for (num10 = (int)vector.Y; Main.tile[num9, num10].active == 0; num10++)
				{
				}
				TileRunner(num9, num10, genRand.Next(2, 6), genRand.Next(3, 7), 22);
			}
		}

		public static void ChasmRunner(int i, int j, int steps, bool makeOrb = false)
		{
			bool flag = false;
			bool flag2 = !makeOrb;
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			float num = steps;
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(11) * 0.2f + 0.5f;
			int num2 = 5;
			int num3 = genRand.Next(5) + 7;
			while (num3 > 0)
			{
				if (num > 0f)
				{
					num3 += genRand.Next(3);
					num3 -= genRand.Next(3);
					if (num3 < 7)
					{
						num3 = 7;
					}
					else if (num3 > 20)
					{
						num3 = 20;
					}
					if (num == 1f && num3 < 10)
					{
						num3 = 10;
					}
				}
				else if (vector.Y > (float)(Main.worldSurface + 45))
				{
					num3 -= genRand.Next(4);
				}
				if (vector.Y > (float)Main.rockLayer && num > 0f)
				{
					num = 0f;
				}
				num -= 1f;
				if (!flag && vector.Y > (float)(Main.worldSurface + 20))
				{
					flag = true;
					ChasmRunnerSideways((int)vector.X, (int)vector.Y, -1, genRand.Next(20, 40));
					ChasmRunnerSideways((int)vector.X, (int)vector.Y, 1, genRand.Next(20, 40));
				}
				int num4;
				int num5;
				int num6;
				int num7;
				if (num > (float)num2)
				{
					num4 = (int)(vector.X - (float)num3 * 0.5f);
					num5 = (int)(vector.X + (float)num3 * 0.5f);
					num6 = (int)(vector.Y - (float)num3 * 0.5f);
					num7 = (int)(vector.Y + (float)num3 * 0.5f);
					if (num4 < 0)
					{
						num4 = 0;
					}
					if (num5 > Main.maxTilesX - 1)
					{
						num5 = Main.maxTilesX - 1;
					}
					if (num6 < 0)
					{
						num6 = 0;
					}
					if (num7 > Main.maxTilesY)
					{
						num7 = Main.maxTilesY;
					}
					for (int k = num4; k < num5; k++)
					{
						for (int l = num6; l < num7; l++)
						{
							if (Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y) < (float)num3 * 0.5f * (1f + (float)genRand.Next(-10, 11) * 0.015f) && Main.tile[k, l].type != 31 && Main.tile[k, l].type != 22)
							{
								Main.tile[k, l].active = 0;
							}
						}
					}
				}
				if (num <= 2f && vector.Y < (float)(Main.worldSurface + 45))
				{
					num = 2f;
				}
				if (num <= 0f)
				{
					if (!flag2)
					{
						flag2 = true;
						AddShadowOrb((int)vector.X, (int)vector.Y);
					}
					else
					{
						for (int m = 0; m < 10000; m++)
						{
							int num8 = genRand.Next((int)vector.Y - 50, (int)vector.Y);
							if (num8 <= Main.worldSurface)
							{
								break;
							}
							if (num8 > Main.maxTilesY - 5)
							{
								num8 = Main.maxTilesY - 5;
							}
							int num9 = genRand.Next((int)vector.X - 25, (int)vector.X + 25);
							if (num9 < 5)
							{
								num9 = 5;
							}
							else if (num9 > Main.maxTilesX - 5)
							{
								num9 = Main.maxTilesX - 5;
							}
							if (Place3x2(num9, num8, 26))
							{
								break;
							}
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.01f;
				if (vector2.X > 0.3f)
				{
					vector2.X = 0.3f;
				}
				else if (vector2.X < -0.3f)
				{
					vector2.X = -0.3f;
				}
				num4 = (int)(vector.X - (float)num3 * 1.1f);
				num5 = (int)(vector.X + (float)num3 * 1.1f);
				num6 = (int)(vector.Y - (float)num3 * 1.1f);
				num7 = (int)(vector.Y + (float)num3 * 1.1f);
				if (num4 < 1)
				{
					num4 = 1;
				}
				if (num5 > Main.maxTilesX - 1)
				{
					num5 = Main.maxTilesX - 1;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int n = num4; n < num5; n++)
				{
					for (int num10 = num6; num10 < num7; num10++)
					{
						if (Math.Abs((float)n - vector.X) + Math.Abs((float)num10 - vector.Y) < (float)num3 * 1.1f * (1f + (float)genRand.Next(-10, 11) * 0.015f))
						{
							if (Main.tile[n, num10].type != 25 && num10 > j + genRand.Next(3, 20))
							{
								Main.tile[n, num10].active = 1;
							}
							if (steps <= num2)
							{
								Main.tile[n, num10].active = 1;
							}
							if (Main.tile[n, num10].type != 31)
							{
								Main.tile[n, num10].type = 25;
							}
							if (Main.tile[n, num10].wall == 2)
							{
								Main.tile[n, num10].wall = 0;
							}
						}
					}
				}
				for (int num11 = num4; num11 < num5; num11++)
				{
					for (int num12 = num6; num12 < num7; num12++)
					{
						if (Math.Abs((float)num11 - vector.X) + Math.Abs((float)num12 - vector.Y) < (float)num3 * 1.1f * (1f + (float)genRand.Next(-10, 11) * 0.015f))
						{
							if (Main.tile[num11, num12].type != 31)
							{
								Main.tile[num11, num12].type = 25;
							}
							if (steps <= num2)
							{
								Main.tile[num11, num12].active = 1;
							}
							if (num12 > j + genRand.Next(3, 20) && Main.tile[num11, num12].wall == 0)
							{
								Main.tile[num11, num12].wall = 3;
							}
						}
					}
				}
			}
		}

		public static void JungleRunner(int i, int j)
		{
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			double num = genRand.Next(5, 11);
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(10, 20) * 0.1f;
			int num2 = 0;
			bool flag = true;
			do
			{
				int num3 = (int)vector.X;
				int num4 = (int)vector.Y;
				if (num4 < Main.worldSurface && Main.tile[num3, num4].wall == 0 && Main.tile[num3, num4].active == 0 && Main.tile[num3, num4 - 3].wall == 0 && Main.tile[num3, num4 - 3].active == 0 && Main.tile[num3, num4 - 1].wall == 0 && Main.tile[num3, num4 - 1].active == 0 && Main.tile[num3, num4 - 4].wall == 0 && Main.tile[num3, num4 - 4].active == 0 && Main.tile[num3, num4 - 2].wall == 0 && Main.tile[num3, num4 - 2].active == 0 && Main.tile[num3, num4 - 5].wall == 0 && Main.tile[num3, num4 - 5].active == 0)
				{
					flag = false;
				}
				JungleX = num3;
				num += (double)((float)genRand.Next(-20, 21) * 0.1f);
				if (num < 5.0)
				{
					num = 5.0;
				}
				else if (num > 10.0)
				{
					num = 10.0;
				}
				int num5 = (int)((double)vector.X - num * 0.5);
				int num6 = (int)((double)vector.X + num * 0.5);
				int num7 = (int)((double)vector.Y - num * 0.5);
				int num8 = (int)((double)vector.Y + num * 0.5);
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesX)
				{
					num6 = Main.maxTilesX;
				}
				if (num7 < 0)
				{
					num7 = 0;
				}
				if (num8 > Main.maxTilesY)
				{
					num8 = Main.maxTilesY;
				}
				for (int k = num5; k < num6; k++)
				{
					for (int l = num7; l < num8; l++)
					{
						if ((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < num * 0.5 * (1.0 + (double)genRand.Next(-10, 11) * 0.015))
						{
							KillTileFast(k, l);
						}
					}
				}
				if (++num2 > 10 && genRand.Next(50) < num2)
				{
					num2 = 0;
					int num9 = -2;
					if (genRand.Next(2) == 0)
					{
						num9 = 2;
					}
					TileRunner((int)vector.X, (int)vector.Y, genRand.Next(3, 20), genRand.Next(10, 100), -1, addTile: false, new Vector2(num9, 0f));
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.Y += (float)genRand.Next(-10, 11) * 0.01f;
				if (vector2.Y > 0f)
				{
					vector2.Y = 0f;
				}
				else if (vector2.Y < -2f)
				{
					vector2.Y = -2f;
				}
				vector2.X += (float)genRand.Next(-10, 11) * 0.1f;
				if (vector.X < (float)(i - 200))
				{
					vector2.X += (float)genRand.Next(5, 21) * 0.1f;
				}
				if (vector.X > (float)(i + 200))
				{
					vector2.X -= (float)genRand.Next(5, 21) * 0.1f;
				}
				if (vector2.X > 1.5f)
				{
					vector2.X = 1.5f;
				}
				else if (vector2.X < -1.5f)
				{
					vector2.X = -1.5f;
				}
			}
			while (flag);
		}

		public static void GERunner(int i, Vector2 speed, bool good, ref Vector2i minArea, ref Vector2i maxArea)
		{
			Vector2 vector = new Vector2(i, 0f);
			Vector2 vector2 = speed;
			int num = genRand.Next(200, 250);
			float num2 = (float)Main.maxTilesX * 0.000238095236f;
			num = (int)((float)num * num2);
			int num3 = num;
			while (true)
			{
				int num4 = (int)(vector.X - (float)num3 * 0.5f);
				int num5 = (int)(vector.X + (float)num3 * 0.5f);
				int num6 = (int)(vector.Y - (float)num3 * 0.5f);
				int num7 = (int)(vector.Y + (float)num3 * 0.5f);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int j = num4; j < num5; j++)
				{
					for (int k = num6; k < num7; k++)
					{
						if (!((double)(Math.Abs((float)j - vector.X) + Math.Abs((float)k - vector.Y)) < (double)num * 0.5 * (1.0 + (double)genRand.Next(-10, 11) * 0.015)))
						{
							continue;
						}
						int num8 = 0;
						if (good)
						{
							if (Main.tile[j, k].wall == 3)
							{
								Main.tile[j, k].wall = 28;
							}
							switch (Main.tile[j, k].type)
							{
							case 1:
							case 25:
								num8 = 117;
								break;
							case 2:
							case 23:
								num8 = 109;
								break;
							case 53:
							case 112:
							case 123:
								num8 = 116;
								break;
							}
						}
						else
						{
							switch (Main.tile[j, k].type)
							{
							case 1:
							case 117:
								num8 = 25;
								break;
							case 2:
							case 109:
								num8 = 23;
								break;
							case 53:
							case 116:
							case 123:
								num8 = 112;
								break;
							}
						}
						if (num8 > 0)
						{
							if (j < minArea.X)
							{
								minArea.X = j;
							}
							if (k < minArea.Y)
							{
								minArea.Y = k;
							}
							if (j > maxArea.X)
							{
								maxArea.X = j;
							}
							if (k > maxArea.Y)
							{
								maxArea.Y = k;
							}
							Main.tile[j, k].type = (byte)num8;
							SquareTileFrameNoLiquid(j, k);
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				if (vector.X < (float)(-num) || vector.Y < (float)(-num) || vector.X > (float)(Main.maxTilesX + num) || vector.Y > (float)(Main.maxTilesX + num))
				{
					break;
				}
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > speed.X + 1f)
				{
					vector2.X = speed.X + 1f;
				}
				else if (vector2.X < speed.X - 1f)
				{
					vector2.X = speed.X - 1f;
				}
			}
		}

		public unsafe static void TileRunner(int i, int j, int strength, int steps, int type, bool addTile = false, Vector2 velocity = default(Vector2), bool noYChange = false, bool overRide = true)
		{
			Vector2 vector = new Vector2(i, j);
			float num = strength;
			int num2 = steps;
			float num3 = 1f / (float)steps;
			if (velocity.X == 0f && velocity.Y == 0f)
			{
				velocity.X = (float)genRand.Next(-10, 11) * 0.1f;
				velocity.Y = (float)genRand.Next(-10, 11) * 0.1f;
			}
			while (num > 0f && num2 > 0)
			{
				if (vector.Y < 0f && type == 59)
				{
					num2 = 0;
				}
				num = (float)strength * ((float)num2 * num3);
				num2--;
				int num4 = (int)(vector.Y - num * 0.5f);
				int num5 = (int)(vector.Y + num * 0.5f);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesY)
				{
					num5 = Main.maxTilesY;
				}
				if (num4 < num5)
				{
					int num6 = (int)(vector.X - num * 0.5f);
					int num7 = (int)(vector.X + num * 0.5f);
					if (num6 < 0)
					{
						num6 = 0;
					}
					if (num7 > Main.maxTilesX)
					{
						num7 = Main.maxTilesX;
					}
					fixed (Tile* ptr = Main.tile)
					{
						for (int k = num6; k < num7; k++)
						{
							int num8 = num4;
							Tile* ptr2 = ptr + (k * 1440 + num8);
							do
							{
								if (Math.Abs((float)k - vector.X) + Math.Abs((float)num8 - vector.Y) < (float)strength * 0.5f * (1f + (float)genRand.Next(-10, 11) * 0.015f))
								{
									if (mudWall && num8 > Main.worldSurface && num8 < Main.maxTilesY - 210 - genRand.Next(3) && ptr2->wall == 0)
									{
										ptr2->wall = 15;
									}
									if (type < 0)
									{
										if (type == -2 && ptr2->active != 0 && (num8 < waterLine || num8 > lavaLine))
										{
											ptr2->liquid = byte.MaxValue;
											if (num8 > lavaLine)
											{
												ptr2->lava = 32;
											}
										}
										ptr2->active = 0;
									}
									else
									{
										if (overRide || ptr2->active == 0)
										{
											int type2 = ptr2->type;
											if ((type != 40 || type2 != 53) && (!Main.tileStone[type] || type2 == 1) && type2 != 45 && type2 != 147 && (type2 != 1 || type != 59 || num8 >= Main.worldSurface + genRand.Next(-50, 50)))
											{
												if (type2 != 53 || num8 >= Main.worldSurface)
												{
													ptr2->type = (byte)type;
												}
												else if (type == 59)
												{
													ptr2->type = (byte)type;
												}
											}
										}
										if (addTile)
										{
											ptr2->active = 1;
											ptr2->liquid = 0;
											ptr2->lava = 0;
										}
										if (type == 59)
										{
											if (num8 > waterLine && ptr2->liquid > 0)
											{
												ptr2->liquid = 0;
												ptr2->lava = 0;
											}
										}
										else if (noYChange && num8 < Main.worldSurface)
										{
											ptr2->wall = 2;
										}
									}
								}
								ptr2++;
							}
							while (++num8 < num5);
						}
					}
				}
				vector.X += velocity.X;
				vector.Y += velocity.Y;
				if (num > 50f)
				{
					vector.X += velocity.X;
					vector.Y += velocity.Y;
					num2--;
					velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
					velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
					if (num > 100f)
					{
						vector.X += velocity.X;
						vector.Y += velocity.Y;
						num2--;
						velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
						velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
						if (num > 150f)
						{
							vector.X += velocity.X;
							vector.Y += velocity.Y;
							num2--;
							velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
							velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
							if (num > 200f)
							{
								vector.X += velocity.X;
								vector.Y += velocity.Y;
								num2--;
								velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
								velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
								if (num > 250f)
								{
									vector.X += velocity.X;
									vector.Y += velocity.Y;
									num2--;
									velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
									velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
									if (num > 300f)
									{
										vector.X += velocity.X;
										vector.Y += velocity.Y;
										num2--;
										velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
										velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
										if (num > 400f)
										{
											vector.X += velocity.X;
											vector.Y += velocity.Y;
											num2--;
											velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
											velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
											if (num > 500f)
											{
												vector.X += velocity.X;
												vector.Y += velocity.Y;
												num2--;
												velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
												velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
												if (num > 600f)
												{
													vector.X += velocity.X;
													vector.Y += velocity.Y;
													num2--;
													velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
													velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
													if (num > 700f)
													{
														vector.X += velocity.X;
														vector.Y += velocity.Y;
														num2--;
														velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
														velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
														if (num > 800f)
														{
															vector.X += velocity.X;
															vector.Y += velocity.Y;
															num2--;
															velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
															velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
															if (num > 900f)
															{
																vector.X += velocity.X;
																vector.Y += velocity.Y;
																num2--;
																velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
																velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				velocity.X += (float)genRand.Next(-10, 11) * 0.05f;
				if (velocity.X > 1f)
				{
					velocity.X = 1f;
				}
				else if (velocity.X < -1f)
				{
					velocity.X = -1f;
				}
				if (!noYChange)
				{
					velocity.Y += (float)genRand.Next(-10, 11) * 0.05f;
					if (velocity.Y > 1f)
					{
						velocity.Y = 1f;
					}
					else if (velocity.Y < -1f)
					{
						velocity.Y = -1f;
					}
					if (type == 59)
					{
						int num9 = (int)vector.Y;
						if (num9 < Main.rockLayer + 100)
						{
							velocity.Y = 1f;
						}
						else if (num9 > Main.maxTilesY - 300)
						{
							velocity.Y = -1f;
						}
						else if (velocity.Y > 0.5f)
						{
							velocity.Y = 0.5f;
						}
						else if (velocity.Y < -0.5f)
						{
							velocity.Y = -0.5f;
						}
					}
				}
				else if (type != 59 && num < 3f)
				{
					if (velocity.Y > 1f)
					{
						velocity.Y = 1f;
					}
					else if (velocity.Y < -1f)
					{
						velocity.Y = -1f;
					}
				}
			}
		}

		public static void MudWallRunner(int i, int j)
		{
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			float num = genRand.Next(5, 15);
			float num2 = genRand.Next(5, 20);
			float num3 = num2;
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(-10, 11) * 0.1f;
			while (num > 0f && num3 > 0f)
			{
				float num4 = num * (num3 / num2);
				num3 -= 1f;
				int num5 = (int)(vector.X - num4 * 0.5f);
				int num6 = (int)(vector.X + num4 * 0.5f);
				int num7 = (int)(vector.Y - num4 * 0.5f);
				int num8 = (int)(vector.Y + num4 * 0.5f);
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesX)
				{
					num6 = Main.maxTilesX;
				}
				if (num7 < 0)
				{
					num7 = 0;
				}
				if (num8 > Main.maxTilesY)
				{
					num8 = Main.maxTilesY;
				}
				for (int k = num5; k < num6; k++)
				{
					float num9 = Math.Abs((float)k - vector.X);
					for (int l = num7; l < num8; l++)
					{
						if (num9 + Math.Abs((float)l - vector.Y) < num * 0.5f * (1f + (float)genRand.Next(-10, 11) * 0.015f))
						{
							Main.tile[k, l].wall = 0;
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > 1f)
				{
					vector2.X = 1f;
				}
				else if (vector2.X < -1f)
				{
					vector2.X = -1f;
				}
				vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.Y > 1f)
				{
					vector2.Y = 1f;
				}
				else if (vector2.Y < -1f)
				{
					vector2.Y = -1f;
				}
			}
		}

		public static void FloatingIsland(int i, int j)
		{
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			float num = genRand.Next(80, 120);
			float num2 = num;
			float num3 = genRand.Next(20, 25);
			vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			while (vector2.X > -2f && vector2.X < 2f)
			{
				vector2.X = (float)genRand.Next(-20, 21) * 0.2f;
			}
			vector2.Y = (float)genRand.Next(-20, -10) * 0.02f;
			while (num > 0f && num3 > 0f)
			{
				num -= (float)genRand.Next(4);
				num3 -= 1f;
				int num4 = (int)(vector.X - num * 0.5f);
				int num5 = (int)(vector.X + num * 0.5f);
				int num6 = (int)(vector.Y - num * 0.5f);
				int num7 = (int)(vector.Y + num * 0.5f);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				num2 = num * (float)genRand.Next(80, 120) * 0.01f;
				float num8 = num2 * 0.4f;
				num8 *= num8;
				int num9 = (int)vector.Y + 1;
				for (int k = num4; k < num5; k++)
				{
					if (genRand.Next(2) == 0)
					{
						num9 += genRand.Next(-1, 2);
					}
					if (num9 < (int)vector.Y)
					{
						num9 = (int)vector.Y;
					}
					else if (num9 > (int)vector.Y + 2)
					{
						num9 = (int)vector.Y + 2;
					}
					float num10 = (float)k - vector.X;
					num10 *= num10;
					for (int l = (num6 < num9) ? num9 : num6; l < num7; l++)
					{
						float num11 = ((float)l - vector.Y) * 2f;
						float num12 = num10 + num11 * num11;
						if (num12 < num8)
						{
							Main.tile[k, l].active = 1;
							if (Main.tile[k, l].type == 59)
							{
								Main.tile[k, l].type = 0;
							}
						}
					}
				}
				TileRunner(genRand.Next(num4 + 10, num5 - 10), (int)(vector.Y + num2 * 0.1f + 5f), genRand.Next(5, 10), genRand.Next(10, 15), 0, addTile: true, new Vector2(0f, 2f), noYChange: true);
				num4 = (int)(vector.X - num * 0.4f);
				num5 = (int)(vector.X + num * 0.4f);
				num6 = (int)(vector.Y - num * 0.4f);
				num7 = (int)(vector.Y + num * 0.4f);
				num9 = (int)vector.Y + 2;
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < num9)
				{
					num6 = num9;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				num2 = num * (float)genRand.Next(80, 120) * 0.01f;
				num2 *= 0.4f;
				num2 *= num2;
				for (int m = num4; m < num5; m++)
				{
					float num13 = (float)m - vector.X;
					num13 *= num13;
					for (int n = num6; n < num7; n++)
					{
						float num14 = ((float)n - vector.Y) * 2f;
						float num15 = num13 + num14 * num14;
						if (num15 < num2)
						{
							Main.tile[m, n].wall = 2;
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > 1f)
				{
					vector2.X = 1f;
				}
				else if (vector2.X < -1f)
				{
					vector2.X = -1f;
				}
				if (vector2.Y > 0.2f)
				{
					vector2.Y = -0.2f;
				}
				else if (vector2.Y < -0.2f)
				{
					vector2.Y = -0.2f;
				}
			}
		}

		public static void Caverer(int X, int Y)
		{
			int num = genRand.Next(2);
			double num2 = (double)genRand.Next(100) * 0.01;
			double num3 = 1.0 - num2;
			if (genRand.Next(2) == 0)
			{
				num2 = 0.0 - num2;
			}
			if (genRand.Next(2) == 0)
			{
				num3 = 0.0 - num3;
			}
			Vector2 pos = new Vector2(X, Y);
			if (num == 0)
			{
				for (int num4 = genRand.Next(6, 8); num4 >= 0; num4--)
				{
					digTunnel(ref pos, num2, num3, genRand.Next(6, 20), genRand.Next(4, 9));
					num2 += (double)genRand.Next(-20, 21) * 0.1;
					num3 += (double)genRand.Next(-20, 21) * 0.1;
					if (num2 < -1.5)
					{
						num2 = -1.5;
					}
					else if (num2 > 1.5)
					{
						num2 = 1.5;
					}
					if (num3 < -1.5)
					{
						num3 = -1.5;
					}
					else if (num3 > 1.5)
					{
						num3 = 1.5;
					}
					double num5 = (double)genRand.Next(100) * 0.01;
					double num6 = 1.0 - num5;
					if (genRand.Next(2) == 0)
					{
						num5 = 0.0 - num5;
					}
					if (genRand.Next(2) == 0)
					{
						num6 = 0.0 - num6;
					}
					Vector2 pos2 = pos;
					digTunnel(ref pos2, num5, num6, genRand.Next(30, 50), genRand.Next(3, 6));
					TileRunner((int)pos2.X, (int)pos2.Y, genRand.Next(10, 20), genRand.Next(5, 10), -1);
				}
				return;
			}
			for (int num7 = genRand.Next(14, 29); num7 >= 0; num7--)
			{
				digTunnel(ref pos, num2, num3, genRand.Next(5, 15), genRand.Next(2, 6), Wet: true);
				num2 += (double)genRand.Next(-20, 21) * 0.1;
				num3 += (double)genRand.Next(-20, 21) * 0.1;
				if (num2 < -1.5)
				{
					num2 = -1.5;
				}
				else if (num2 > 1.5)
				{
					num2 = 1.5;
				}
				if (num3 < -1.5)
				{
					num3 = -1.5;
				}
				else if (num3 > 1.5)
				{
					num3 = 1.5;
				}
			}
		}

		public static void digTunnel(ref Vector2 pos, double xDir, double yDir, int Steps, int Size, bool Wet = false)
		{
			try
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = Size;
				while (Steps > 0)
				{
					Steps--;
					for (int i = (int)((double)pos.X - num3); (double)i <= (double)pos.X + num3; i++)
					{
						float num4 = Math.Abs((float)i - pos.X);
						for (int j = (int)((double)pos.Y - num3); (double)j <= (double)pos.Y + num3; j++)
						{
							if ((double)(num4 + Math.Abs((float)j - pos.Y)) < num3 * (1.0 + (double)genRand.Next(-10, 11) * 0.005))
							{
								Main.tile[i, j].active = 0;
								if (Wet)
								{
									Main.tile[i, j].liquid = byte.MaxValue;
								}
							}
						}
					}
					num3 += (double)genRand.Next(-50, 51) * 0.03;
					if (num3 < (double)Size * 0.6)
					{
						num3 = (double)Size * 0.6;
					}
					else if (num3 > (double)(Size * 2))
					{
						num3 = Size * 2;
					}
					num += (double)genRand.Next(-20, 21) * 0.01;
					num2 += (double)genRand.Next(-20, 21) * 0.01;
					if (num < -1.0)
					{
						num = -1.0;
					}
					else if (num > 1.0)
					{
						num = 1.0;
					}
					if (num2 < -1.0)
					{
						num2 = -1.0;
					}
					else if (num2 > 1.0)
					{
						num2 = 1.0;
					}
					pos.X = (float)((double)pos.X + (xDir + num) * 0.6);
					pos.Y = (float)((double)pos.Y + (yDir + num2) * 0.6);
				}
			}
			catch
			{
			}
		}

		public static void IslandHouse(int i, int j)
		{
			byte type = (byte)genRand.Next(45, 48);
			byte wall = (byte)genRand.Next(10, 13);
			Vector2 vector = new Vector2(i, j);
			int num = 1;
			if (genRand.Next(2) == 0)
			{
				num = -1;
			}
			int num2 = genRand.Next(7, 12);
			int num3 = genRand.Next(5, 7);
			vector.X = i + (num2 + 2) * num;
			for (int k = j - 15; k < j + 30; k++)
			{
				if (Main.tile[(int)vector.X, k].active != 0)
				{
					vector.Y = k - 1;
					break;
				}
			}
			vector.X = i;
			int num4 = (int)(vector.X - (float)num2 - 2f);
			int num5 = (int)(vector.X + (float)num2 + 2f);
			int num6 = (int)(vector.Y - (float)num3 - 2f);
			int num7 = (int)(vector.Y + 2f + (float)genRand.Next(3, 5));
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 > Main.maxTilesX)
			{
				num5 = Main.maxTilesX;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			if (num7 > Main.maxTilesY)
			{
				num7 = Main.maxTilesY;
			}
			for (int l = num4; l <= num5; l++)
			{
				for (int m = num6; m < num7; m++)
				{
					Main.tile[l, m].active = 1;
					Main.tile[l, m].type = type;
					Main.tile[l, m].wall = 0;
				}
			}
			num4 = (int)(vector.X - (float)num2);
			num5 = (int)(vector.X + (float)num2);
			num6 = (int)(vector.Y - (float)num3);
			num7 = (int)(vector.Y + 1f);
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num5 > Main.maxTilesX)
			{
				num5 = Main.maxTilesX;
			}
			if (num6 < 0)
			{
				num6 = 0;
			}
			if (num7 > Main.maxTilesY)
			{
				num7 = Main.maxTilesY;
			}
			for (int n = num4; n <= num5; n++)
			{
				for (int num8 = num6; num8 < num7; num8++)
				{
					if (Main.tile[n, num8].wall == 0)
					{
						Main.tile[n, num8].active = 0;
						Main.tile[n, num8].wall = wall;
					}
				}
			}
			int num9 = i + (num2 + 1) * num;
			int num10 = (int)vector.Y;
			for (int num11 = num9 - 2; num11 <= num9 + 2; num11++)
			{
				Main.tile[num11, num10].active = 0;
				Main.tile[num11, num10 - 1].active = 0;
				Main.tile[num11, num10 - 2].active = 0;
			}
			PlaceTile(num9, num10, 10, mute: true);
			int contain = 0;
			int num12 = houseCount;
			if (num12 > 2)
			{
				num12 = genRand.Next(3);
			}
			switch (num12)
			{
			case 0:
				contain = 159;
				break;
			case 1:
				contain = 65;
				break;
			case 2:
				contain = 158;
				break;
			}
			AddBuriedChest(i, num10 - 3, contain, notNearOtherChests: false, 2);
			houseCount++;
		}

		public static void Mountinater(int i, int j)
		{
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			double num = genRand.Next(80, 120);
			double num2 = num;
			float num3 = genRand.Next(40, 55);
			vector.Y += num3 * 0.5f;
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(-20, -10) * 0.1f;
			while (num > 0.0 && num3 > 0f)
			{
				num -= (double)genRand.Next(4);
				num3 -= 1f;
				int num4 = (int)((double)vector.X - num * 0.5);
				int num5 = (int)((double)vector.X + num * 0.5);
				int num6 = (int)((double)vector.Y - num * 0.5);
				int num7 = (int)((double)vector.Y + num * 0.5);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				num2 *= 0.4;
				num2 *= num2;
				for (int k = num4; k < num5; k++)
				{
					double num8 = (float)k - vector.X;
					num8 *= num8;
					for (int l = num6; l < num7; l++)
					{
						double num9 = (float)l - vector.Y;
						double num10 = num8 + num9 * num9;
						if (num10 < num2 && Main.tile[k, l].active == 0)
						{
							Main.tile[k, l].active = 1;
							Main.tile[k, l].type = 0;
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > 0.5f)
				{
					vector2.X = 0.5f;
				}
				else if (vector2.X < -0.5f)
				{
					vector2.X = -0.5f;
				}
				if (vector2.Y > -0.5f)
				{
					vector2.Y = -0.5f;
				}
				else if (vector2.Y < -1.5f)
				{
					vector2.Y = -1.5f;
				}
			}
		}

		public static void Lakinater(int i, int j)
		{
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			double num = genRand.Next(25, 50);
			double num2 = num;
			double num3 = genRand.Next(30, 80);
			if (genRand.Next(5) == 0)
			{
				num *= 1.5;
				num2 *= 1.5;
				num3 *= 1.2;
			}
			vector.Y = (float)((double)vector.Y - num3 * 0.3);
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(-20, -10) * 0.1f;
			while (num > 0.0 && num3 > 0.0)
			{
				if ((double)vector.Y + num2 * 0.5 > (double)Main.worldSurface)
				{
					num3 = 0.0;
				}
				num -= (double)genRand.Next(3);
				num3 -= 1.0;
				int num4 = (int)((double)vector.X - num * 0.5);
				int num5 = (int)((double)vector.X + num * 0.5);
				int num6 = (int)((double)vector.Y - num * 0.5);
				int num7 = (int)((double)vector.Y + num * 0.5);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				num2 *= 0.4;
				num2 *= num2;
				for (int k = num4; k < num5; k++)
				{
					double num8 = (float)k - vector.X;
					num8 *= num8;
					for (int l = num6; l < num7; l++)
					{
						double num9 = (float)l - vector.Y;
						double num10 = num8 + num9 * num9;
						if (num10 < num2 && Main.tile[k, l].active != 0)
						{
							Main.tile[k, l].active = 0;
							Main.tile[k, l].liquid = byte.MaxValue;
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > 0.5f)
				{
					vector2.X = 0.5f;
				}
				else if (vector2.X < -0.5f)
				{
					vector2.X = -0.5f;
				}
				if (vector2.Y > 1.5f)
				{
					vector2.Y = 1.5f;
				}
				else if (vector2.Y < 0.5f)
				{
					vector2.Y = 0.5f;
				}
			}
		}

		public static void ShroomPatch(int i, int j)
		{
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			double num = genRand.Next(40, 70);
			double num2 = num;
			double num3 = genRand.Next(20, 30);
			if (genRand.Next(5) == 0)
			{
				num *= 1.5;
				num2 *= 1.5;
				num3 *= 1.2;
			}
			vector.Y -= (float)(num3 * 0.3);
			vector2.X = (float)genRand.Next(-10, 11) * 0.1f;
			vector2.Y = (float)genRand.Next(-20, -10) * 0.1f;
			while (num > 0.0 && num3 > 0.0)
			{
				num -= (double)genRand.Next(3);
				num3 -= 1.0;
				int num4 = (int)((double)vector.X - num * 0.5);
				int num5 = (int)((double)vector.X + num * 0.5);
				int num6 = (int)((double)vector.Y - num * 0.5);
				int num7 = (int)((double)vector.Y + num * 0.5);
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				float num8 = (float)num2 * 0.4f;
				num8 *= num8;
				for (int k = num4; k < num5; k++)
				{
					float num9 = (float)k - vector.X;
					num9 *= num9;
					for (int l = num6; l < num7; l++)
					{
						float num10 = ((float)l - vector.Y) * 2.3f;
						float num11 = num9 + num10 * num10;
						if (!(num11 < num8))
						{
							continue;
						}
						if ((double)l < (double)vector.Y + num2 * 0.02)
						{
							if (Main.tile[k, l].type != 59)
							{
								Main.tile[k, l].active = 0;
							}
						}
						else
						{
							Main.tile[k, l].type = 59;
						}
						Main.tile[k, l].liquid = 0;
						Main.tile[k, l].lava = 0;
					}
				}
				vector.X += vector2.X;
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				vector2.Y -= (float)genRand.Next(11) * 0.05f;
				if (vector2.X > -0.5f && vector2.X < 0.5f)
				{
					if (vector2.X < 0f)
					{
						vector2.X = -0.5f;
					}
					else
					{
						vector2.X = 0.5f;
					}
				}
				if (vector2.X > 2f)
				{
					vector2.X = 1f;
				}
				else if (vector2.X < -2f)
				{
					vector2.X = -1f;
				}
				if (vector2.Y > 1f)
				{
					vector2.Y = 1f;
				}
				else if (vector2.Y < -1f)
				{
					vector2.Y = -1f;
				}
				int num12 = (int)vector.X;
				int num13 = (int)vector.Y;
				for (int m = 0; m < 2; m++)
				{
					int num14;
					int num15;
					do
					{
						num14 = num12 + genRand.Next(-20, 20);
						num15 = num13 + genRand.Next(20);
					}
					while (Main.tile[num14, num15].active == 0 && Main.tile[num14, num15].type != 59);
					int num16 = genRand.Next(7, 10);
					int num17 = genRand.Next(7, 10);
					TileRunner(num14, num15, num16, num17, 59, addTile: false, new Vector2(0f, 2f), noYChange: true);
					if (genRand.Next(3) == 0)
					{
						TileRunner(num14, num15, num16 - 3, num17 - 3, -1, addTile: false, new Vector2(0f, 2f), noYChange: true);
					}
				}
			}
		}

		public static void Cavinator(int i, int j, int steps)
		{
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = default(Vector2);
			double num = genRand.Next(7, 15);
			double num2 = num;
			int num3 = 1;
			if (genRand.Next(2) == 0)
			{
				num3 = -1;
			}
			int num4 = genRand.Next(20, 40);
			vector2.Y = (float)genRand.Next(10, 20) * 0.01f;
			vector2.X = num3;
			while (num4 > 0)
			{
				num4--;
				int num5 = (int)((double)vector.X - num * 0.5);
				int num6 = (int)((double)vector.X + num * 0.5);
				int num7 = (int)((double)vector.Y - num * 0.5);
				int num8 = (int)((double)vector.Y + num * 0.5);
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesX)
				{
					num6 = Main.maxTilesX;
				}
				if (num7 < 0)
				{
					num7 = 0;
				}
				if (num8 > Main.maxTilesY)
				{
					num8 = Main.maxTilesY;
				}
				num2 = num * (double)genRand.Next(80, 120) * 0.01;
				num2 *= 0.4;
				num2 *= num2;
				for (int k = num5; k < num6; k++)
				{
					double num9 = (float)k - vector.X;
					num9 *= num9;
					for (int l = num7; l < num8; l++)
					{
						double num10 = (float)l - vector.Y;
						double num11 = num9 + num10 * num10;
						if (num11 < num2)
						{
							Main.tile[k, l].active = 0;
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > (float)num3 + 0.5f)
				{
					vector2.X = (float)num3 + 0.5f;
				}
				else if (vector2.X < (float)num3 - 0.5f)
				{
					vector2.X = (float)num3 - 0.5f;
				}
				if (vector2.Y > 2f)
				{
					vector2.Y = 2f;
				}
				else if (vector2.Y < 0f)
				{
					vector2.Y = 0f;
				}
			}
			if (steps > 0 && (int)vector.Y < Main.rockLayer + 50)
			{
				Cavinator((int)vector.X, (int)vector.Y, steps - 1);
			}
		}

		public static void CaveOpenater(int i, int j)
		{
			int num = (genRand.Next(2) << 1) - 1;
			Vector2 vector = new Vector2(i, j);
			Vector2 vector2 = new Vector2(0f, num);
			double num2 = genRand.Next(7, 12);
			double num3 = num2;
			int num4 = 100;
			do
			{
				num4 = ((Main.tile[(int)vector.X, (int)vector.Y].wall != 0) ? (num4 - 1) : 0);
				int num5 = (int)((double)vector.X - num2 * 0.5);
				int num6 = (int)((double)vector.X + num2 * 0.5);
				int num7 = (int)((double)vector.Y - num2 * 0.5);
				int num8 = (int)((double)vector.Y + num2 * 0.5);
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (num6 > Main.maxTilesX)
				{
					num6 = Main.maxTilesX;
				}
				if (num7 < 0)
				{
					num7 = 0;
				}
				if (num8 > Main.maxTilesY)
				{
					num8 = Main.maxTilesY;
				}
				num3 = num2 * (double)genRand.Next(80, 120) * 0.01;
				num3 *= 0.4;
				num3 *= num3;
				for (int k = num5; k < num6; k++)
				{
					double num9 = (float)k - vector.X;
					num9 *= num9;
					for (int l = num7; l < num8; l++)
					{
						double num10 = (float)l - vector.Y;
						double num11 = num9 + num10 * num10;
						if (num11 < num3)
						{
							Main.tile[k, l].active = 0;
						}
					}
				}
				vector.X += vector2.X;
				vector.Y += vector2.Y;
				vector2.X += (float)genRand.Next(-10, 11) * 0.05f;
				vector2.Y += (float)genRand.Next(-10, 11) * 0.05f;
				if (vector2.X > (float)num + 0.5f)
				{
					vector2.X = (float)num + 0.5f;
				}
				else if (vector2.X < (float)num - 0.5f)
				{
					vector2.X = (float)num - 0.5f;
				}
				if (vector2.Y > 0f)
				{
					vector2.Y = 0f;
				}
				else if (vector2.Y < -0.5f)
				{
					vector2.Y = -0.5f;
				}
			}
			while (num4 > 0);
		}

		public static void SquareTileFrame(int i, int j, int frameNumber = -1)
		{
			if (!gen)
			{
				bool flag = tileFrameRecursion;
				tileFrameRecursion = false;
				TileFrame(i - 1, j - 1);
				TileFrame(i - 1, j);
				TileFrame(i - 1, j + 1);
				TileFrame(i, j - 1);
				TileFrame(i, j, frameNumber);
				TileFrame(i, j + 1);
				TileFrame(i + 1, j - 1);
				TileFrame(i + 1, j);
				TileFrame(i + 1, j + 1);
				tileFrameRecursion = flag;
			}
		}

		public static void SquareTileFrameNoLiquid(int i, int j, int frameNumber = -1)
		{
			TileFrameNoLiquid(i - 1, j - 1);
			TileFrameNoLiquid(i - 1, j);
			TileFrameNoLiquid(i - 1, j + 1);
			TileFrameNoLiquid(i, j - 1);
			TileFrameNoLiquid(i, j, frameNumber);
			TileFrameNoLiquid(i, j + 1);
			TileFrameNoLiquid(i + 1, j - 1);
			TileFrameNoLiquid(i + 1, j);
			TileFrameNoLiquid(i + 1, j + 1);
		}

		public static void SquareWallFrame(int i, int j, bool resetFrame = true)
		{
			WallFrame(i - 1, j - 1);
			WallFrame(i - 1, j);
			WallFrame(i - 1, j + 1);
			WallFrame(i, j - 1);
			WallFrame(i, j, resetFrame);
			WallFrame(i, j + 1);
			WallFrame(i + 1, j - 1);
			WallFrame(i + 1, j);
			WallFrame(i + 1, j + 1);
		}

		public static void SectionTileFrame(int startX, int startY)
		{
			int num = startX;
			int num2 = startX + 40;
			int num3 = startY;
			int num4 = startY + 30;
			if (num < 6)
			{
				num = 6;
			}
			if (num3 < 6)
			{
				num3 = 6;
			}
			if (num > Main.maxTilesX - 6)
			{
				num = Main.maxTilesX - 6;
			}
			if (num3 > Main.maxTilesY - 6)
			{
				num3 = Main.maxTilesY - 6;
			}
			tileFrameRecursion = false;
			for (int i = num - 1; i < num2 + 1; i++)
			{
				for (int j = num3 - 1; j < num4 + 1; j++)
				{
					int type = Main.tile[i, j].type;
					if (type == 4 || !Main.tileFrameImportant[type])
					{
						TileFrame(i, j, -1);
					}
					WallFrame(i, j, resetFrame: true);
				}
			}
			tileFrameRecursion = true;
		}

		public static void RangeFrame(int startX, int startY, int endX, int endY)
		{
			if (gen)
			{
				return;
			}
			bool flag = tileFrameRecursion;
			tileFrameRecursion = false;
			for (int i = startX - 1; i < endX + 2; i++)
			{
				for (int j = startY - 1; j < endY + 2; j++)
				{
					TileFrame(i, j);
					WallFrame(i, j);
				}
			}
			tileFrameRecursion = flag;
		}

		public unsafe static void WaterCheck()
		{
			Liquid.numLiquid = 0;
			LiquidBuffer.numLiquidBuffer = 0;
			fixed (Tile* ptr = Main.tile)
			{
				for (int num = Main.maxTilesX - 2; num > 0; num--)
				{
					Tile* ptr2 = ptr + (num * 1440 + Main.maxTilesY - 2);
					int num2 = Main.maxTilesY - 2;
					while (num2 > 0)
					{
						ptr2->checkingLiquid = 0;
						if (ptr2->liquid > 0)
						{
							if (ptr2->active != 0 && Main.tileSolidNotSolidTop[ptr2->type])
							{
								ptr2->liquid = 0;
							}
							else
							{
								if (ptr2->active != 0)
								{
									if (Main.tileWaterDeath[ptr2->type] && (ptr2->type != 4 || ptr2->frameY != 176))
									{
										KillTile(num, num2);
									}
									if (ptr2->lava != 0 && Main.tileLavaDeath[ptr2->type])
									{
										KillTile(num, num2);
									}
								}
								Tile* ptr3 = ptr2 + 1;
								if ((ptr3->active == 0 || !Main.tileSolidNotSolidTop[ptr3->type]) && ptr3->liquid < byte.MaxValue)
								{
									if (ptr3->liquid > 250)
									{
										ptr3->liquid = byte.MaxValue;
									}
									else
									{
										Liquid.AddWater(num, num2);
									}
								}
								ptr3 = ptr2 - 1440;
								if ((ptr3->active == 0 || !Main.tileSolidNotSolidTop[ptr3->type]) && ptr3->liquid != ptr2->liquid)
								{
									Liquid.AddWater(num, num2);
								}
								else
								{
									ptr3 = ptr2 + 1440;
									if ((ptr3->active == 0 || !Main.tileSolidNotSolidTop[ptr3->type]) && ptr3->liquid != ptr2->liquid)
									{
										Liquid.AddWater(num, num2);
									}
								}
								if (ptr2->lava != 0)
								{
									ptr3 = ptr2 - 1;
									if (ptr3->liquid > 0 && ptr3->lava == 0)
									{
										Liquid.AddWater(num, num2);
									}
									else
									{
										ptr3 = ptr2 + 1;
										if (ptr3->liquid > 0 && ptr3->lava == 0)
										{
											Liquid.AddWater(num, num2);
										}
										else
										{
											ptr3 = ptr2 - 1440;
											if (ptr3->liquid > 0 && ptr3->lava == 0)
											{
												Liquid.AddWater(num, num2);
											}
											else
											{
												ptr3 = ptr2 + 1440;
												if (ptr3->liquid > 0 && ptr3->lava == 0)
												{
													Liquid.AddWater(num, num2);
												}
											}
										}
									}
								}
							}
						}
						num2--;
						ptr2--;
					}
				}
			}
		}

		public unsafe static void everyTileFrame()
		{
			UI.main.NextProgressStep(Lang.gen[55]);
			gen = true;
			fixed (Tile* ptr = Main.tile)
			{
				for (int i = 0; i < Main.maxTilesX; i++)
				{
					if ((i & 0x3F) == 0)
					{
						UI.main.progress = (float)i / (float)Main.maxTilesX;
					}
					Tile* ptr2 = ptr + (1440 * i + Main.maxTilesY);
					for (int num = Main.maxTilesY - 1; num >= 0; num--)
					{
						ptr2--;
						if (ptr2->active != 0)
						{
							TileFrameNoLiquid(i, num, -1);
						}
						if (ptr2->wall > 0)
						{
							WallFrame(i, num, resetFrame: true);
						}
					}
				}
			}
			gen = false;
		}

		private static void PlantCheck(int i, int j)
		{
			int num = -1;
			int num2 = Main.tile[i, j].type;
			if (j + 1 >= Main.maxTilesY)
			{
				num = num2;
			}
			if (j + 1 < Main.maxTilesY && Main.tile[i, j + 1].active != 0)
			{
				num = Main.tile[i, j + 1].type;
			}
			if ((num2 != 3 || num == 2 || num == 78) && (num2 != 24 || num == 23) && (num2 != 61 || num == 60) && (num2 != 71 || num == 70) && (num2 != 73 || num == 2 || num == 78) && (num2 != 74 || num == 60) && (num2 != 110 || num == 109) && (num2 != 113 || num == 109))
			{
				return;
			}
			switch (num)
			{
			case 23:
				num2 = 24;
				if (Main.tile[i, j].frameX >= 162)
				{
					Main.tile[i, j].frameX = 126;
				}
				break;
			case 2:
				num2 = ((num2 != 113) ? 3 : 73);
				break;
			case 109:
				num2 = ((num2 != 73) ? 110 : 113);
				break;
			}
			if (num2 != Main.tile[i, j].type)
			{
				Main.tile[i, j].type = (byte)num2;
			}
			else
			{
				KillTile(i, j);
			}
		}

		public unsafe static void WallFrame(int i, int j, bool resetFrame = false)
		{
			if (i >= 0 && j >= 0 && i < Main.maxTilesX && j < Main.maxTilesY)
			{
				fixed (Tile* ptr = &Main.tile[i, j])
				{
					int wall = ptr->wall;
					if (wall != 0)
					{
						int num = wall;
						int num2 = wall;
						int num3 = wall;
						int num4 = wall;
						int num5 = wall;
						int num6 = wall;
						int num7 = wall;
						int num8 = wall;
						_ = ptr->wallFrameX;
						_ = ptr->wallFrameY;
						int num9 = -1;
						int num10 = -1;
						if (j - 1 >= 0)
						{
							num2 = ptr[-1].wall;
						}
						if (j + 1 < Main.maxTilesY)
						{
							num7 = ptr[1].wall;
						}
						if (i - 1 >= 0)
						{
							num4 = ptr[-1440].wall;
							if (j - 1 >= 0)
							{
								num = ptr[-1441].wall;
							}
							if (j + 1 < Main.maxTilesY)
							{
								num6 = ptr[-1439].wall;
							}
						}
						if (i + 1 < Main.maxTilesX)
						{
							num5 = ptr[1440].wall;
							if (j - 1 >= 0)
							{
								num3 = ptr[1439].wall;
							}
							if (j + 1 < Main.maxTilesY)
							{
								num8 = ptr[1441].wall;
							}
						}
						if (wall == 2 && j >= Main.worldSurface)
						{
							num7 = wall;
							num6 = wall;
							num8 = wall;
							if (j > Main.worldSurface)
							{
								num2 = wall;
								num = wall;
								num3 = wall;
								num4 = wall;
								num5 = wall;
							}
						}
						else
						{
							if (num7 > 0)
							{
								num7 = wall;
							}
							if (num6 > 0)
							{
								num6 = wall;
							}
							if (num8 > 0)
							{
								num8 = wall;
							}
						}
						if (num2 > 0)
						{
							num2 = wall;
						}
						if (num > 0)
						{
							num = wall;
						}
						if (num3 > 0)
						{
							num3 = wall;
						}
						if (num4 > 0)
						{
							num4 = wall;
						}
						if (num5 > 0)
						{
							num5 = wall;
						}
						int num11;
						if (resetFrame)
						{
							num11 = genRand.Next(3);
							Main.tile[i, j].wallFrameNumber = num11;
						}
						else
						{
							num11 = Main.tile[i, j].wallFrameNumber;
						}
						if (num9 < 0 || num10 < 0)
						{
							if (num2 == wall && num7 == wall && num4 == wall && num5 == wall)
							{
								if (num != wall && num3 != wall)
								{
									num9 = 108 + num11 * 18;
									num10 = 18;
								}
								else if (num6 != wall && num8 != wall)
								{
									num9 = 108 + num11 * 18;
									num10 = 36;
								}
								else if (num != wall && num6 != wall)
								{
									num9 = 180;
									num10 = num11 * 18;
								}
								else if (num3 != wall && num8 != wall)
								{
									num9 = 198;
									num10 = num11 * 18;
								}
								else
								{
									num9 = 18 + num11 * 18;
									num10 = 18;
								}
							}
							else if (num2 != wall && num7 == wall && num4 == wall && num5 == wall)
							{
								num9 = 18 + num11 * 18;
								num10 = 0;
							}
							else if (num2 == wall && num7 != wall && num4 == wall && num5 == wall)
							{
								num9 = 18 + num11 * 18;
								num10 = 36;
							}
							else if (num2 == wall && num7 == wall && num4 != wall && num5 == wall)
							{
								num9 = 0;
								num10 = num11 * 18;
							}
							else if (num2 == wall && num7 == wall && num4 == wall && num5 != wall)
							{
								num9 = 72;
								num10 = num11 * 18;
							}
							else if (num2 != wall && num7 == wall && num4 != wall && num5 == wall)
							{
								num9 = num11 * 36;
								num10 = 54;
							}
							else if (num2 != wall && num7 == wall && num4 == wall && num5 != wall)
							{
								num9 = 18 + num11 * 36;
								num10 = 54;
							}
							else if (num2 == wall && num7 != wall && num4 != wall && num5 == wall)
							{
								num9 = num11 * 36;
								num10 = 72;
							}
							else if (num2 == wall && num7 != wall && num4 == wall && num5 != wall)
							{
								num9 = 18 + num11 * 36;
								num10 = 72;
							}
							else if (num2 == wall && num7 == wall && num4 != wall && num5 != wall)
							{
								num9 = 90;
								num10 = num11 * 18;
							}
							else if (num2 != wall && num7 != wall && num4 == wall && num5 == wall)
							{
								num9 = 108 + num11 * 18;
								num10 = 72;
							}
							else if (num2 != wall && num7 == wall && num4 != wall && num5 != wall)
							{
								num9 = 108 + num11 * 18;
								num10 = 0;
							}
							else if (num2 == wall && num7 != wall && num4 != wall && num5 != wall)
							{
								num9 = 108 + num11 * 18;
								num10 = 54;
							}
							else if (num2 != wall && num7 != wall && num4 != wall && num5 == wall)
							{
								num9 = 162;
								num10 = num11 * 18;
							}
							else if (num2 != wall && num7 != wall && num4 == wall && num5 != wall)
							{
								num9 = 216;
								num10 = num11 * 18;
							}
							else if (num2 != wall && num7 != wall && num4 != wall && num5 != wall)
							{
								num9 = 162 + num11 * 18;
								num10 = 54;
							}
						}
						if (num9 < 0 || num10 < 0)
						{
							num9 = 18 + num11 * 18;
							num10 = 18;
						}
						ptr->wallFrameX = (ushort)num9;
						ptr->wallFrameY = (byte)num10;
					}
				}
			}
		}

		public unsafe static void TileFrame(int i, int j, int frameNumber = 0)
		{
			if (i > 5 && j > 5 && i < Main.maxTilesX - 5 && j < Main.maxTilesY - 5)
			{
				fixed (Tile* ptr = &Main.tile[i, j])
				{
					if (ptr->liquid > 0 && Main.netMode != 1)
					{
						Liquid.AddWater(i, j);
					}
					int num;
					int frameX;
					int frameY;
					int num2;
					int num3;
					if (ptr->active != 0)
					{
						num = ptr->type;
						if (Main.tileStone[num])
						{
							num = 1;
						}
						frameX = ptr->frameX;
						frameY = ptr->frameY;
						num2 = -1;
						num3 = -1;
						if (Main.tileFrameImportant[num])
						{
							switch (num)
							{
							case 6:
							case 7:
							case 8:
							case 9:
							case 19:
							case 22:
							case 23:
							case 25:
							case 30:
							case 32:
							case 37:
							case 38:
							case 39:
							case 40:
							case 41:
							case 43:
							case 44:
							case 45:
							case 46:
							case 47:
							case 48:
							case 49:
							case 51:
							case 52:
							case 53:
							case 54:
							case 56:
							case 57:
							case 58:
							case 59:
							case 60:
							case 62:
							case 63:
							case 64:
							case 65:
							case 66:
							case 67:
							case 68:
							case 69:
							case 70:
							case 75:
							case 76:
							case 80:
							case 107:
							case 108:
							case 109:
							case 111:
							case 112:
							case 115:
							case 116:
							case 117:
							case 118:
							case 119:
							case 120:
							case 121:
							case 122:
							case 123:
							case 124:
							case 127:
							case 130:
							case 131:
							case 137:
							case 140:
							case 145:
							case 146:
							case 147:
							case 148:
								break;
							case 28:
								CheckPot(i, j);
								break;
							case 5:
								CheckTree(i, j);
								break;
							case 3:
							case 24:
							case 61:
							case 71:
							case 73:
							case 74:
							case 110:
							case 113:
								PlantCheck(i, j);
								break;
							case 4:
							{
								int num19 = (ptr->frameX >= 66) ? 66 : 0;
								int num20 = -1;
								int num21 = -1;
								int num22 = -1;
								int num23 = -1;
								int num24 = -1;
								int num25 = -1;
								int num26 = -1;
								if (ptr[-1].active != 0)
								{
									_ = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num20 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num21 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num22 = ptr[1440].type;
								}
								if (ptr[-1439].active != 0)
								{
									num23 = ptr[-1439].type;
								}
								if (ptr[1441].active != 0)
								{
									num24 = ptr[1441].type;
								}
								if (ptr[-1441].active != 0)
								{
									num25 = ptr[-1441].type;
								}
								if (ptr[1439].active != 0)
								{
									num26 = ptr[1439].type;
								}
								if (num20 >= 0 && Main.tileSolidAndAttach[num20])
								{
									ptr->frameX = (short)num19;
								}
								else if (num21 >= 0 && (Main.tileSolidAndAttach[num21] || num21 == 124 || (num21 == 5 && num25 == 5 && num23 == 5)))
								{
									ptr->frameX = (short)(22 + num19);
								}
								else if (num22 >= 0 && (Main.tileSolidAndAttach[num22] || num22 == 124 || (num22 == 5 && num26 == 5 && num24 == 5)))
								{
									ptr->frameX = (short)(44 + num19);
								}
								else
								{
									KillTile(i, j);
								}
								break;
							}
							case 136:
							{
								int num28 = -1;
								int num29 = -1;
								int num30 = -1;
								if (ptr[-1].active != 0)
								{
									_ = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num28 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num29 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num30 = ptr[1440].type;
								}
								if (num28 >= 0 && Main.tileSolidAndAttach[num28])
								{
									ptr->frameX = 0;
								}
								else if (num29 >= 0 && (Main.tileSolidAndAttach[num29] || num29 == 124 || num29 == 5))
								{
									ptr->frameX = 18;
								}
								else if (num30 >= 0 && (Main.tileSolidAndAttach[num30] || num30 == 124 || num30 == 5))
								{
									ptr->frameX = 36;
								}
								else
								{
									KillTile(i, j);
								}
								break;
							}
							case 129:
							case 149:
							{
								int num15 = -1;
								int num16 = -1;
								int num17 = -1;
								int num18 = -1;
								if (ptr[-1].active != 0)
								{
									num16 = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num15 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num17 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num18 = ptr[1440].type;
								}
								if (num15 >= 0 && Main.tileSolidNotSolidTop[num15])
								{
									ptr->frameY = 0;
								}
								else if (num17 >= 0 && Main.tileSolidNotSolidTop[num17])
								{
									ptr->frameY = 54;
								}
								else if (num18 >= 0 && Main.tileSolidNotSolidTop[num18])
								{
									ptr->frameY = 36;
								}
								else if (num16 >= 0 && Main.tileSolidNotSolidTop[num16])
								{
									ptr->frameY = 18;
								}
								else
								{
									KillTile(i, j);
								}
								break;
							}
							case 12:
							case 31:
								CheckOrb(i, j, num);
								break;
							case 10:
								if (!destroyObject)
								{
									int num27 = j - frameY / 18;
									bool flag2 = false;
									if (Main.tile[i, num27 - 1].active == 0 || !Main.tileSolid[Main.tile[i, num27 - 1].type])
									{
										flag2 = true;
									}
									else if (Main.tile[i, num27 + 3].active == 0 || !Main.tileSolid[Main.tile[i, num27 + 3].type])
									{
										flag2 = true;
									}
									else if (Main.tile[i, num27].active == 0 || Main.tile[i, num27].type != num)
									{
										flag2 = true;
									}
									else if (Main.tile[i, num27 + 1].active == 0 || Main.tile[i, num27 + 1].type != num)
									{
										flag2 = true;
									}
									else if (Main.tile[i, num27 + 2].active == 0 || Main.tile[i, num27 + 2].type != num)
									{
										flag2 = true;
									}
									if (flag2)
									{
										destroyObject = true;
										KillTile(i, num27);
										KillTile(i, num27 + 1);
										KillTile(i, num27 + 2);
										if (!gen)
										{
											Item.NewItem(i * 16, j * 16, 16, 16, 25);
										}
									}
									destroyObject = false;
								}
								break;
							case 11:
								if (!destroyObject)
								{
									int num10 = 0;
									int num11 = 0;
									int num12 = i;
									int num13 = j;
									bool flag = false;
									switch (frameX)
									{
									case 0:
										num10 = 1;
										break;
									case 18:
										num12 = i - 1;
										num11 = -1440;
										num10 = 1;
										break;
									case 36:
										num11 = 1440;
										num12 = i + 1;
										num10 = -1;
										break;
									case 54:
										num10 = -1;
										break;
									}
									switch (frameY)
									{
									case 18:
										num11--;
										num13 = j - 1;
										break;
									case 36:
										num13 = j - 2;
										num11 -= 2;
										break;
									}
									if (ptr[num11 - 1].active == 0 || !Main.tileSolid[ptr[num11 - 1].type] || ptr[num11 + 3].active == 0 || !Main.tileSolid[ptr[num11 + 3].type])
									{
										flag = true;
										destroyObject = true;
										if (!gen)
										{
											Item.NewItem(i * 16, j * 16, 16, 16, 25);
										}
									}
									int num14 = num12;
									if (num10 == -1)
									{
										num14 = num12 - 1;
									}
									for (int k = num14; k < num14 + 2; k++)
									{
										for (int l = num13; l < num13 + 3; l++)
										{
											if (!flag)
											{
												fixed (Tile* ptr2 = &Main.tile[k, l])
												{
													if (ptr2->type != 11 || ptr2->active == 0)
													{
														destroyObject = true;
														flag = true;
														k = num14;
														l = num13;
														if (!gen)
														{
															Item.NewItem(i * 16, j * 16, 16, 16, 25);
														}
													}
												}
											}
											if (flag)
											{
												KillTile(k, l);
											}
										}
									}
									destroyObject = false;
								}
								break;
							case 34:
							case 35:
							case 36:
							case 106:
								Check3x3(i, j, num);
								break;
							case 15:
							case 20:
								Check1x2(i, j, num);
								break;
							case 14:
							case 17:
							case 26:
							case 77:
							case 86:
							case 87:
							case 88:
							case 89:
							case 114:
							case 133:
								Check3x2(i, j, num);
								break;
							case 135:
							case 141:
							case 144:
								Check1x1(i, j, num);
								break;
							case 16:
							case 18:
							case 29:
							case 103:
							case 134:
								Check2x1(i, j, num);
								break;
							case 13:
							case 33:
							case 50:
								CheckOnTable1x1(i, j);
								break;
							case 78:
								CheckOnTableClaypot(i, j);
								break;
							case 21:
								CheckChest(i, j);
								break;
							case 27:
								CheckSunflower(i, j);
								break;
							case 128:
								CheckMan(i, j);
								break;
							case 94:
							case 95:
							case 96:
							case 97:
							case 98:
							case 99:
							case 100:
							case 125:
							case 126:
							case 132:
							case 138:
							case 142:
							case 143:
								Check2x2(i, j, num);
								break;
							case 91:
								CheckBanner(i, j);
								break;
							case 139:
								CheckMusicBox(i, j);
								break;
							case 92:
							case 93:
								Check1xX(i, j, num);
								break;
							case 101:
							case 102:
								Check3x4(i, j, num);
								break;
							case 104:
							case 105:
								Check2xX(i, j, num);
								break;
							case 42:
								Check1x2Top(i, j);
								break;
							case 82:
							case 83:
							case 84:
								CheckAlch(i, j);
								break;
							case 55:
							case 85:
								CheckSign(i, j, num);
								break;
							case 79:
							case 90:
								Check4x2(i, j, num);
								break;
							case 72:
							{
								int num8 = -1;
								int num9 = -1;
								if (ptr[-1].active != 0)
								{
									num9 = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num8 = ptr[1].type;
								}
								if (num8 != num && num8 != 70)
								{
									KillTile(i, j);
								}
								else if (num9 != num && ptr->frameX == 0)
								{
									ptr->frameNumber = (byte)genRand.Next(3);
									ptr->frameX = 18;
									ptr->frameY = (short)(18 * ptr->frameNumber);
								}
								break;
							}
							case 81:
							{
								int num4 = -1;
								int num5 = -1;
								int num6 = -1;
								int num7 = -1;
								if (ptr[-1].active != 0)
								{
									num5 = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num4 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num6 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num7 = ptr[1440].type;
								}
								if (num6 != -1 || num5 != -1 || num7 != -1)
								{
									KillTile(i, j);
								}
								else if (num4 < 0 || !Main.tileSolid[num4])
								{
									KillTile(i, j);
								}
								break;
							}
							}
						}
						else
						{
							int num31 = -1;
							int num32 = -1;
							int num33 = -1;
							int num34 = -1;
							int num35 = -1;
							int num36 = -1;
							int num37 = -1;
							int num38 = -1;
							if (ptr[-1440].active != 0)
							{
								int type = ptr[-1440].type;
								num34 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1440].active != 0)
							{
								int type = ptr[1440].type;
								num35 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[-1].active != 0)
							{
								int type = ptr[-1].type;
								num32 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1].active != 0)
							{
								int type = ptr[1].type;
								num37 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[-1441].active != 0)
							{
								int type = ptr[-1441].type;
								num31 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1439].active != 0)
							{
								int type = ptr[1439].type;
								num33 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[-1439].active != 0)
							{
								int type = ptr[-1439].type;
								num36 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1441].active != 0)
							{
								int type = ptr[1441].type;
								num38 = (Main.tileStone[type] ? 1 : type);
							}
							switch (num)
							{
							case 19:
								if (num35 >= 0 && !Main.tileSolid[num35])
								{
									num35 = -1;
								}
								if (num34 >= 0 && !Main.tileSolid[num34])
								{
									num34 = -1;
								}
								num2 = ((num34 == num) ? ((num35 != num) ? ((num35 >= 0) ? 72 : 18) : 0) : ((num34 < 0) ? ((num35 == num) ? 36 : ((num35 <= 0) ? 90 : 126)) : ((num35 == num) ? 54 : ((num35 >= 0) ? 90 : 108))));
								num3 = 18 * ptr->frameNumber;
								break;
							case 80:
								CactusFrame(i, j);
								return;
							case 49:
								CheckOnTable1x1(i, j);
								return;
							}
							mergeUp = false;
							mergeDown = false;
							mergeLeft = false;
							mergeRight = false;
							if (frameNumber < 0)
							{
								frameNumber = genRand.Next(3);
								ptr->frameNumber = (byte)frameNumber;
							}
							else
							{
								frameNumber = ptr->frameNumber;
							}
							if (num == 0)
							{
								if (num32 >= 0 && Main.tileMergeDirt[num32])
								{
									TileFrame(i, j - 1);
									if (mergeDown)
									{
										num32 = num;
									}
								}
								if (num37 >= 0 && Main.tileMergeDirt[num37])
								{
									TileFrame(i, j + 1);
									if (mergeUp)
									{
										num37 = num;
									}
								}
								if (num34 >= 0 && Main.tileMergeDirt[num34])
								{
									TileFrame(i - 1, j);
									if (mergeRight)
									{
										num34 = num;
									}
								}
								if (num35 >= 0 && Main.tileMergeDirt[num35])
								{
									TileFrame(i + 1, j);
									if (mergeLeft)
									{
										num35 = num;
									}
								}
								if (num32 == 2 || num32 == 23 || num32 == 109)
								{
									num32 = num;
								}
								if (num37 == 2 || num37 == 23 || num37 == 109)
								{
									num37 = num;
								}
								if (num34 == 2 || num34 == 23 || num34 == 109)
								{
									num34 = num;
								}
								if (num35 == 2 || num35 == 23 || num35 == 109)
								{
									num35 = num;
								}
								if (num31 >= 0 && Main.tileMergeDirt[num31])
								{
									num31 = num;
								}
								else if (num31 == 2 || num31 == 23 || num31 == 109)
								{
									num31 = num;
								}
								if (num33 >= 0 && Main.tileMergeDirt[num33])
								{
									num33 = num;
								}
								else if (num33 == 2 || num33 == 23 || num33 == 109)
								{
									num33 = num;
								}
								if (num36 >= 0 && Main.tileMergeDirt[num36])
								{
									num36 = num;
								}
								else if (num36 == 2 || num36 == 23 || num33 == 109)
								{
									num36 = num;
								}
								if (num38 >= 0 && Main.tileMergeDirt[num38])
								{
									num38 = num;
								}
								else if (num38 == 2 || num38 == 23 || num38 == 109)
								{
									num38 = num;
								}
								if (j < Main.rockLayer)
								{
									if (num32 == 59)
									{
										num32 = -2;
									}
									if (num37 == 59)
									{
										num37 = -2;
									}
									if (num34 == 59)
									{
										num34 = -2;
									}
									if (num35 == 59)
									{
										num35 = -2;
									}
									if (num31 == 59)
									{
										num31 = -2;
									}
									if (num33 == 59)
									{
										num33 = -2;
									}
									if (num36 == 59)
									{
										num36 = -2;
									}
									if (num38 == 59)
									{
										num38 = -2;
									}
								}
							}
							else if (Main.tileMergeDirt[num])
							{
								if (num32 == 0)
								{
									num32 = -2;
								}
								if (num37 == 0)
								{
									num37 = -2;
								}
								if (num34 == 0)
								{
									num34 = -2;
								}
								if (num35 == 0)
								{
									num35 = -2;
								}
								if (num31 == 0)
								{
									num31 = -2;
								}
								if (num33 == 0)
								{
									num33 = -2;
								}
								if (num36 == 0)
								{
									num36 = -2;
								}
								if (num38 == 0)
								{
									num38 = -2;
								}
								if (num == 1)
								{
									if (j > Main.rockLayer)
									{
										if (num32 == 59)
										{
											TileFrame(i, j - 1);
											if (mergeDown)
											{
												num32 = num;
											}
										}
										if (num37 == 59)
										{
											TileFrame(i, j + 1);
											if (mergeUp)
											{
												num37 = num;
											}
										}
										if (num34 == 59)
										{
											TileFrame(i - 1, j);
											if (mergeRight)
											{
												num34 = num;
											}
										}
										if (num35 == 59)
										{
											TileFrame(i + 1, j);
											if (mergeLeft)
											{
												num35 = num;
											}
										}
										if (num31 == 59)
										{
											num31 = num;
										}
										if (num33 == 59)
										{
											num33 = num;
										}
										if (num36 == 59)
										{
											num36 = num;
										}
										if (num38 == 59)
										{
											num38 = num;
										}
									}
									if (num32 == 57)
									{
										TileFrame(i, j - 1);
										if (mergeDown)
										{
											num32 = num;
										}
									}
									if (num37 == 57)
									{
										TileFrame(i, j + 1);
										if (mergeUp)
										{
											num37 = num;
										}
									}
									if (num34 == 57)
									{
										TileFrame(i - 1, j);
										if (mergeRight)
										{
											num34 = num;
										}
									}
									if (num35 == 57)
									{
										TileFrame(i + 1, j);
										if (mergeLeft)
										{
											num35 = num;
										}
									}
									if (num31 == 57)
									{
										num31 = num;
									}
									if (num33 == 57)
									{
										num33 = num;
									}
									if (num36 == 57)
									{
										num36 = num;
									}
									if (num38 == 57)
									{
										num38 = num;
									}
								}
							}
							else
							{
								switch (num)
								{
								case 58:
								case 75:
								case 76:
									if (num32 == 57)
									{
										num32 = -2;
									}
									if (num37 == 57)
									{
										num37 = -2;
									}
									if (num34 == 57)
									{
										num34 = -2;
									}
									if (num35 == 57)
									{
										num35 = -2;
									}
									if (num31 == 57)
									{
										num31 = -2;
									}
									if (num33 == 57)
									{
										num33 = -2;
									}
									if (num36 == 57)
									{
										num36 = -2;
									}
									if (num38 == 57)
									{
										num38 = -2;
									}
									break;
								case 59:
									if (j > Main.rockLayer)
									{
										if (num32 == 1)
										{
											num32 = -2;
										}
										if (num37 == 1)
										{
											num37 = -2;
										}
										if (num34 == 1)
										{
											num34 = -2;
										}
										if (num35 == 1)
										{
											num35 = -2;
										}
										if (num31 == 1)
										{
											num31 = -2;
										}
										if (num33 == 1)
										{
											num33 = -2;
										}
										if (num36 == 1)
										{
											num36 = -2;
										}
										if (num38 == 1)
										{
											num38 = -2;
										}
									}
									if (num32 == 60 || num32 == 70)
									{
										num32 = num;
									}
									if (num37 == 60 || num37 == 70)
									{
										num37 = num;
									}
									if (num34 == 60 || num34 == 70)
									{
										num34 = num;
									}
									if (num35 == 60 || num35 == 70)
									{
										num35 = num;
									}
									if (num31 == 60 || num31 == 70)
									{
										num31 = num;
									}
									if (num33 == 60 || num33 == 70)
									{
										num33 = num;
									}
									if (num36 == 60 || num36 == 70)
									{
										num36 = num;
									}
									if (num38 == 60 || num38 == 70)
									{
										num38 = num;
									}
									if (j < Main.rockLayer)
									{
										if (num32 == 0)
										{
											TileFrame(i, j - 1);
											if (mergeDown)
											{
												num32 = num;
											}
										}
										if (num37 == 0)
										{
											TileFrame(i, j + 1);
											if (mergeUp)
											{
												num37 = num;
											}
										}
										if (num34 == 0)
										{
											TileFrame(i - 1, j);
											if (mergeRight)
											{
												num34 = num;
											}
										}
										if (num35 == 0)
										{
											TileFrame(i + 1, j);
											if (mergeLeft)
											{
												num35 = num;
											}
										}
										if (num31 == 0)
										{
											num31 = num;
										}
										if (num33 == 0)
										{
											num33 = num;
										}
										if (num36 == 0)
										{
											num36 = num;
										}
										if (num38 == 0)
										{
											num38 = num;
										}
									}
									break;
								case 57:
									if (num32 == 1)
									{
										num32 = -2;
									}
									if (num37 == 1)
									{
										num37 = -2;
									}
									if (num34 == 1)
									{
										num34 = -2;
									}
									if (num35 == 1)
									{
										num35 = -2;
									}
									if (num31 == 1)
									{
										num31 = -2;
									}
									if (num33 == 1)
									{
										num33 = -2;
									}
									if (num36 == 1)
									{
										num36 = -2;
									}
									if (num38 == 1)
									{
										num38 = -2;
									}
									if (num32 == 58 || num32 == 76 || num32 == 75)
									{
										TileFrame(i, j - 1);
										if (mergeDown)
										{
											num32 = num;
										}
									}
									if (num37 == 58 || num37 == 76 || num37 == 75)
									{
										TileFrame(i, j + 1);
										if (mergeUp)
										{
											num37 = num;
										}
									}
									if (num34 == 58 || num34 == 76 || num34 == 75)
									{
										TileFrame(i - 1, j);
										if (mergeRight)
										{
											num34 = num;
										}
									}
									if (num35 == 58 || num35 == 76 || num35 == 75)
									{
										TileFrame(i + 1, j);
										if (mergeLeft)
										{
											num35 = num;
										}
									}
									if (num31 == 58 || num31 == 76 || num31 == 75)
									{
										num31 = num;
									}
									if (num33 == 58 || num33 == 76 || num33 == 75)
									{
										num33 = num;
									}
									if (num36 == 58 || num36 == 76 || num36 == 75)
									{
										num36 = num;
									}
									if (num38 == 58 || num38 == 76 || num38 == 75)
									{
										num38 = num;
									}
									break;
								case 32:
									if (num37 == 23)
									{
										num37 = num;
									}
									break;
								case 69:
									if (num37 == 60)
									{
										num37 = num;
									}
									break;
								case 51:
									if (num32 >= 0 && !Main.tileNoAttach[num32])
									{
										num32 = num;
									}
									if (num37 >= 0 && !Main.tileNoAttach[num37])
									{
										num37 = num;
									}
									if (num34 >= 0 && !Main.tileNoAttach[num34])
									{
										num34 = num;
									}
									if (num35 >= 0 && !Main.tileNoAttach[num35])
									{
										num35 = num;
									}
									if (num31 >= 0 && !Main.tileNoAttach[num31])
									{
										num31 = num;
									}
									if (num33 >= 0 && !Main.tileNoAttach[num33])
									{
										num33 = num;
									}
									if (num36 >= 0 && !Main.tileNoAttach[num36])
									{
										num36 = num;
									}
									if (num38 >= 0 && !Main.tileNoAttach[num38])
									{
										num38 = num;
									}
									break;
								}
							}
							bool flag3 = false;
							if (num == 2 || num == 23 || num == 60 || num == 70 || num == 109)
							{
								flag3 = true;
								if (num32 >= 0 && num32 != num && !Main.tileSolid[num32])
								{
									num32 = -1;
								}
								if (num37 >= 0 && num37 != num && !Main.tileSolid[num37])
								{
									num37 = -1;
								}
								if (num34 >= 0 && num34 != num && !Main.tileSolid[num34])
								{
									num34 = -1;
								}
								if (num35 >= 0 && num35 != num && !Main.tileSolid[num35])
								{
									num35 = -1;
								}
								if (num31 >= 0 && num31 != num && !Main.tileSolid[num31])
								{
									num31 = -1;
								}
								if (num33 >= 0 && num33 != num && !Main.tileSolid[num33])
								{
									num33 = -1;
								}
								if (num36 >= 0 && num36 != num && !Main.tileSolid[num36])
								{
									num36 = -1;
								}
								if (num38 >= 0 && num38 != num && !Main.tileSolid[num38])
								{
									num38 = -1;
								}
								int num39 = 0;
								switch (num)
								{
								case 60:
								case 70:
									num39 = 59;
									break;
								case 2:
									if (num32 == 23)
									{
										num32 = num39;
									}
									if (num37 == 23)
									{
										num37 = num39;
									}
									if (num34 == 23)
									{
										num34 = num39;
									}
									if (num35 == 23)
									{
										num35 = num39;
									}
									if (num31 == 23)
									{
										num31 = num39;
									}
									if (num33 == 23)
									{
										num33 = num39;
									}
									if (num36 == 23)
									{
										num36 = num39;
									}
									if (num38 == 23)
									{
										num38 = num39;
									}
									break;
								case 23:
									if (num32 == 2)
									{
										num32 = num39;
									}
									if (num37 == 2)
									{
										num37 = num39;
									}
									if (num34 == 2)
									{
										num34 = num39;
									}
									if (num35 == 2)
									{
										num35 = num39;
									}
									if (num31 == 2)
									{
										num31 = num39;
									}
									if (num33 == 2)
									{
										num33 = num39;
									}
									if (num36 == 2)
									{
										num36 = num39;
									}
									if (num38 == 2)
									{
										num38 = num39;
									}
									break;
								}
								if (num32 != num && num32 != num39 && (num37 == num || num37 == num39))
								{
									if (num34 == num39 && num35 == num)
									{
										num2 = 18 * frameNumber;
										num3 = 198;
									}
									else if (num34 == num && num35 == num39)
									{
										num2 = 54 + 18 * frameNumber;
										num3 = 198;
									}
								}
								else if (num37 != num && num37 != num39 && (num32 == num || num32 == num39))
								{
									if (num34 == num39 && num35 == num)
									{
										num2 = 18 * frameNumber;
										num3 = 216;
									}
									else if (num34 == num && num35 == num39)
									{
										num2 = 54 + 18 * frameNumber;
										num3 = 216;
									}
								}
								else if (num34 != num && num34 != num39 && (num35 == num || num35 == num39))
								{
									if (num32 == num39 && num37 == num)
									{
										num2 = 72;
										num3 = 144 + 18 * frameNumber;
									}
									else if (num37 == num && num35 == num32)
									{
										num2 = 72;
										num3 = 90 + 18 * frameNumber;
									}
								}
								else if (num35 != num && num35 != num39 && (num34 == num || num34 == num39))
								{
									if (num32 == num39 && num37 == num)
									{
										num2 = 90;
										num3 = 144 + 18 * frameNumber;
									}
									else if (num37 == num && num35 == num32)
									{
										num2 = 90;
										num3 = 90 + 18 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num && num34 == num && num35 == num)
								{
									if (num31 != num && num33 != num && num36 != num && num38 != num)
									{
										if (num38 == num39)
										{
											num3 = 324;
											num2 = 108 + 18 * frameNumber;
										}
										else if (num33 == num39)
										{
											num3 = 342;
											num2 = 108 + 18 * frameNumber;
										}
										else if (num36 == num39)
										{
											num3 = 360;
											num2 = 108 + 18 * frameNumber;
										}
										else if (num31 == num39)
										{
											num3 = 378;
											num2 = 108 + 18 * frameNumber;
										}
										else
										{
											num3 = 234;
											num2 = 144 + 54 * frameNumber;
										}
									}
									else if (num31 != num && num38 != num)
									{
										num3 = 306;
										num2 = 36 + 18 * frameNumber;
									}
									else if (num33 != num && num36 != num)
									{
										num3 = 306;
										num2 = 90 + 18 * frameNumber;
									}
									else if (num31 != num && num33 == num && num36 == num && num38 == num)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num31 == num && num33 != num && num36 == num && num38 == num)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num31 == num && num33 == num && num36 != num && num38 == num)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num31 == num && num33 == num && num36 == num && num38 != num)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num39 && num34 == num && num35 == num && num31 == -1 && num33 == -1)
								{
									num3 = 18;
									num2 = 108 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num && num34 == num && num35 == num && num36 == -1 && num38 == -1)
								{
									num3 = 36;
									num2 = 108 + 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 == num39 && num35 == num && num33 == -1 && num38 == -1)
								{
									num2 = 198;
									num3 = 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 == num && num35 == num39 && num31 == -1 && num36 == -1)
								{
									num2 = 180;
									num3 = 18 * frameNumber;
								}
								else if (num32 == num && num37 == num39 && num34 == num && num35 == num)
								{
									if (num33 != -1)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num31 != -1)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
								}
								else if (num32 == num39 && num37 == num && num34 == num && num35 == num)
								{
									if (num38 != -1)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num36 != -1)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num && num34 == num && num35 == num39)
								{
									if (num31 != -1)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num36 != -1)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num && num34 == num39 && num35 == num)
								{
									if (num33 != -1)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num38 != -1)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
								}
								else if ((num32 == num39 && num37 == num && num34 == num && num35 == num) || (num32 == num && num37 == num39 && num34 == num && num35 == num) || (num32 == num && num37 == num && num34 == num39 && num35 == num) || (num32 == num && num37 == num && num34 == num && num35 == num39))
								{
									num3 = 18;
									num2 = 18 + 18 * frameNumber;
								}
								if ((num32 == num || num32 == num39) && (num37 == num || num37 == num39) && (num34 == num || num34 == num39) && (num35 == num || num35 == num39))
								{
									if (num31 != num && num31 != num39 && (num33 == num || num33 == num39) && (num36 == num || num36 == num39) && (num38 == num || num38 == num39))
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num33 != num && num33 != num39 && (num31 == num || num31 == num39) && (num36 == num || num36 == num39) && (num38 == num || num38 == num39))
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num36 != num && num36 != num39 && (num31 == num || num31 == num39) && (num33 == num || num33 == num39) && (num38 == num || num38 == num39))
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num38 != num && num38 != num39 && (num31 == num || num31 == num39) && (num36 == num || num36 == num39) && (num33 == num || num33 == num39))
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
								}
								if (num32 != num39 && num32 != num && num37 == num && num34 != num39 && num34 != num && num35 == num && num38 != num39 && num38 != num)
								{
									num3 = 270;
									num2 = 90 + 18 * frameNumber;
								}
								else if (num32 != num39 && num32 != num && num37 == num && num34 == num && num35 != num39 && num35 != num && num36 != num39 && num36 != num)
								{
									num3 = 270;
									num2 = 144 + 18 * frameNumber;
								}
								else if (num37 != num39 && num37 != num && num32 == num && num34 != num39 && num34 != num && num35 == num && num33 != num39 && num33 != num)
								{
									num3 = 288;
									num2 = 90 + 18 * frameNumber;
								}
								else if (num37 != num39 && num37 != num && num32 == num && num34 == num && num35 != num39 && num35 != num && num31 != num39 && num31 != num)
								{
									num3 = 288;
									num2 = 144 + 18 * frameNumber;
								}
								else if (num32 != num && num32 != num39 && num37 == num && num34 == num && num35 == num && num36 != num && num36 != num39 && num38 != num && num38 != num39)
								{
									num3 = 216;
									num2 = 144 + 54 * frameNumber;
								}
								else if (num37 != num && num37 != num39 && num32 == num && num34 == num && num35 == num && num31 != num && num31 != num39 && num33 != num && num33 != num39)
								{
									num3 = 252;
									num2 = 144 + 54 * frameNumber;
								}
								else if (num34 != num && num34 != num39 && num37 == num && num32 == num && num35 == num && num33 != num && num33 != num39 && num38 != num && num38 != num39)
								{
									num3 = 234;
									num2 = 126 + 54 * frameNumber;
								}
								else if (num35 != num && num35 != num39 && num37 == num && num32 == num && num34 == num && num31 != num && num31 != num39 && num36 != num && num36 != num39)
								{
									num3 = 234;
									num2 = 162 + 54 * frameNumber;
								}
								else if (num32 != num39 && num32 != num && (num37 == num39 || num37 == num) && num34 == num39 && num35 == num39)
								{
									num3 = 270;
									num2 = 36 + 18 * frameNumber;
								}
								else if (num37 != num39 && num37 != num && (num32 == num39 || num32 == num) && num34 == num39 && num35 == num39)
								{
									num3 = 288;
									num2 = 36 + 18 * frameNumber;
								}
								else if (num34 != num39 && num34 != num && (num35 == num39 || num35 == num) && num32 == num39 && num37 == num39)
								{
									num2 = 0;
									num3 = 270 + 18 * frameNumber;
								}
								else if (num35 != num39 && num35 != num && (num34 == num39 || num34 == num) && num32 == num39 && num37 == num39)
								{
									num2 = 18;
									num3 = 270 + 18 * frameNumber;
								}
								else if (num32 == num && num37 == num39 && num34 == num39 && num35 == num39)
								{
									num3 = 288;
									num2 = 198 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num && num34 == num39 && num35 == num39)
								{
									num3 = 270;
									num2 = 198 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num39 && num34 == num && num35 == num39)
								{
									num3 = 306;
									num2 = 198 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num39 && num34 == num39 && num35 == num)
								{
									num3 = 306;
									num2 = 144 + 18 * frameNumber;
								}
								if (num32 != num && num32 != num39 && num37 == num && num34 == num && num35 == num)
								{
									if ((num36 == num39 || num36 == num) && num38 != num39 && num38 != num)
									{
										num3 = 324;
										num2 = 18 * frameNumber;
									}
									else if ((num38 == num39 || num38 == num) && num36 != num39 && num36 != num)
									{
										num3 = 324;
										num2 = 54 + 18 * frameNumber;
									}
								}
								else if (num37 != num && num37 != num39 && num32 == num && num34 == num && num35 == num)
								{
									if ((num31 == num39 || num31 == num) && num33 != num39 && num33 != num)
									{
										num3 = 342;
										num2 = 18 * frameNumber;
									}
									else if ((num33 == num39 || num33 == num) && num31 != num39 && num31 != num)
									{
										num3 = 342;
										num2 = 54 + 18 * frameNumber;
									}
								}
								else if (num34 != num && num34 != num39 && num32 == num && num37 == num && num35 == num)
								{
									if ((num33 == num39 || num33 == num) && num38 != num39 && num38 != num)
									{
										num3 = 360;
										num2 = 54 + 18 * frameNumber;
									}
									else if ((num38 == num39 || num38 == num) && num33 != num39 && num33 != num)
									{
										num3 = 360;
										num2 = 18 * frameNumber;
									}
								}
								else if (num35 != num && num35 != num39 && num32 == num && num37 == num && num34 == num)
								{
									if ((num31 == num39 || num31 == num) && num36 != num39 && num36 != num)
									{
										num3 = 378;
										num2 = 18 * frameNumber;
									}
									else if ((num36 == num39 || num36 == num) && num31 != num39 && num31 != num)
									{
										num3 = 378;
										num2 = 54 + 18 * frameNumber;
									}
								}
								if ((num32 == num || num32 == num39) && (num37 == num || num37 == num39) && (num34 == num || num34 == num39) && (num35 == num || num35 == num39) && num31 != -1 && num33 != -1 && num36 != -1 && num38 != -1)
								{
									num3 = 18;
									num2 = 18 + 18 * frameNumber;
								}
								if (num32 == num39)
								{
									num32 = -2;
								}
								if (num37 == num39)
								{
									num37 = -2;
								}
								if (num34 == num39)
								{
									num34 = -2;
								}
								if (num35 == num39)
								{
									num35 = -2;
								}
								if (num31 == num39)
								{
									num31 = -2;
								}
								if (num33 == num39)
								{
									num33 = -2;
								}
								if (num36 == num39)
								{
									num36 = -2;
								}
								if (num38 == num39)
								{
									num38 = -2;
								}
							}
							if (num2 == -1 && (Main.tileMergeDirt[num] || num == 0 || num == 2 || num == 57 || num == 58 || num == 59 || num == 60 || num == 70 || num == 109 || num == 76 || num == 75))
							{
								if (!flag3)
								{
									flag3 = true;
									if (num31 >= 0 && num31 != num && !Main.tileSolid[num31])
									{
										num31 = -1;
									}
									if (num33 >= 0 && num33 != num && !Main.tileSolid[num33])
									{
										num33 = -1;
									}
									if (num36 >= 0 && num36 != num && !Main.tileSolid[num36])
									{
										num36 = -1;
									}
									if (num38 >= 0 && num38 != num && !Main.tileSolid[num38])
									{
										num38 = -1;
									}
								}
								if (num32 >= 0 && num32 != num)
								{
									num32 = -1;
								}
								if (num37 >= 0 && num37 != num)
								{
									num37 = -1;
								}
								if (num34 >= 0 && num34 != num)
								{
									num34 = -1;
								}
								if (num35 >= 0 && num35 != num)
								{
									num35 = -1;
								}
								if (num32 != -1 && num37 != -1 && num34 != -1 && num35 != -1)
								{
									if (num32 == -2 && num37 == num && num34 == num && num35 == num)
									{
										num3 = 108;
										num2 = 144 + 18 * frameNumber;
										mergeUp = true;
									}
									else if (num32 == num && num37 == -2 && num34 == num && num35 == num)
									{
										num3 = 90;
										num2 = 144 + 18 * frameNumber;
										mergeDown = true;
									}
									else if (num32 == num && num37 == num && num34 == -2 && num35 == num)
									{
										num2 = 162;
										num3 = 126 + 18 * frameNumber;
										mergeLeft = true;
									}
									else if (num32 == num && num37 == num && num34 == num && num35 == -2)
									{
										num2 = 144;
										num3 = 126 + 18 * frameNumber;
										mergeRight = true;
									}
									else if (num32 == -2 && num37 == num && num34 == -2 && num35 == num)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
										mergeUp = true;
										mergeLeft = true;
									}
									else if (num32 == -2 && num37 == num && num34 == num && num35 == -2)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
										mergeUp = true;
										mergeRight = true;
									}
									else if (num32 == num && num37 == -2 && num34 == -2 && num35 == num)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
										mergeDown = true;
										mergeLeft = true;
									}
									else if (num32 == num && num37 == -2 && num34 == num && num35 == -2)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
										mergeDown = true;
										mergeRight = true;
									}
									else if (num32 == num && num37 == num && num34 == -2 && num35 == -2)
									{
										num2 = 180;
										num3 = 126 + 18 * frameNumber;
										mergeLeft = true;
										mergeRight = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == num && num35 == num)
									{
										num3 = 180;
										num2 = 144 + 18 * frameNumber;
										mergeUp = true;
										mergeDown = true;
									}
									else if (num32 == -2 && num37 == num && num34 == -2 && num35 == -2)
									{
										num2 = 198;
										num3 = 90 + 18 * frameNumber;
										mergeUp = true;
										mergeLeft = true;
										mergeRight = true;
									}
									else if (num32 == num && num37 == -2 && num34 == -2 && num35 == -2)
									{
										num2 = 198;
										num3 = 144 + 18 * frameNumber;
										mergeDown = true;
										mergeLeft = true;
										mergeRight = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == num && num35 == -2)
									{
										num2 = 216;
										num3 = 144 + 18 * frameNumber;
										mergeUp = true;
										mergeDown = true;
										mergeRight = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == -2 && num35 == num)
									{
										num2 = 216;
										num3 = 90 + 18 * frameNumber;
										mergeUp = true;
										mergeDown = true;
										mergeLeft = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == -2 && num35 == -2)
									{
										num3 = 198;
										num2 = 108 + 18 * frameNumber;
										mergeUp = true;
										mergeDown = true;
										mergeLeft = true;
										mergeRight = true;
									}
									else if (num32 == num && num37 == num && num34 == num && num35 == num)
									{
										if (num38 == -2)
										{
											num2 = 0;
											num3 = 90 + 36 * frameNumber;
										}
										else if (num36 == -2)
										{
											num2 = 18;
											num3 = 90 + 36 * frameNumber;
										}
										else if (num33 == -2)
										{
											num2 = 0;
											num3 = 108 + 36 * frameNumber;
										}
										else if (num31 == -2)
										{
											num2 = 18;
											num3 = 108 + 36 * frameNumber;
										}
									}
								}
								else
								{
									if (num != 2 && num != 23 && num != 60 && num != 70 && num != 109)
									{
										if (num32 == -1 && num37 == -2 && num34 == num && num35 == num)
										{
											num3 = 0;
											num2 = 234 + 18 * frameNumber;
											mergeDown = true;
										}
										else if (num32 == -2 && num37 == -1 && num34 == num && num35 == num)
										{
											num3 = 18;
											num2 = 234 + 18 * frameNumber;
											mergeUp = true;
										}
										else if (num32 == num && num37 == num && num34 == -1 && num35 == -2)
										{
											num3 = 36;
											num2 = 234 + 18 * frameNumber;
											mergeRight = true;
										}
										else if (num32 == num && num37 == num && num34 == -2 && num35 == -1)
										{
											num3 = 54;
											num2 = 234 + 18 * frameNumber;
											mergeLeft = true;
										}
									}
									if (num32 != -1 && num37 != -1 && num34 == -1 && num35 == num)
									{
										if (num32 == -2 && num37 == num)
										{
											num2 = 72;
											num3 = 144 + 18 * frameNumber;
											mergeUp = true;
										}
										else if (num37 == -2 && num32 == num)
										{
											num2 = 72;
											num3 = 90 + 18 * frameNumber;
											mergeDown = true;
										}
									}
									else if (num32 != -1 && num37 != -1 && num34 == num && num35 == -1)
									{
										if (num32 == -2 && num37 == num)
										{
											num2 = 90;
											num3 = 144 + 18 * frameNumber;
											mergeUp = true;
										}
										else if (num37 == -2 && num32 == num)
										{
											num2 = 90;
											num3 = 90 + 18 * frameNumber;
											mergeDown = true;
										}
									}
									else if (num32 == -1 && num37 == num && num34 != -1 && num35 != -1)
									{
										if (num34 == -2 && num35 == num)
										{
											num2 = 18 * frameNumber;
											num3 = 198;
											mergeLeft = true;
										}
										else if (num35 == -2 && num34 == num)
										{
											num2 = 54 + 18 * frameNumber;
											num3 = 198;
											mergeRight = true;
										}
									}
									else if (num32 == num && num37 == -1 && num34 != -1 && num35 != -1)
									{
										if (num34 == -2 && num35 == num)
										{
											num2 = 18 * frameNumber;
											num3 = 216;
											mergeLeft = true;
										}
										else if (num35 == -2 && num34 == num)
										{
											num2 = 54 + 18 * frameNumber;
											num3 = 216;
											mergeRight = true;
										}
									}
									else if (num32 != -1 && num37 != -1 && num34 == -1 && num35 == -1)
									{
										if (num32 == -2 && num37 == -2)
										{
											num2 = 108;
											num3 = 216 + 18 * frameNumber;
											mergeUp = true;
											mergeDown = true;
										}
										else if (num32 == -2)
										{
											num2 = 126;
											num3 = 144 + 18 * frameNumber;
											mergeUp = true;
										}
										else if (num37 == -2)
										{
											num2 = 126;
											num3 = 90 + 18 * frameNumber;
											mergeDown = true;
										}
									}
									else if (num32 == -1 && num37 == -1 && num34 != -1 && num35 != -1)
									{
										if (num34 == -2 && num35 == -2)
										{
											num3 = 198;
											num2 = 162 + 18 * frameNumber;
											mergeLeft = true;
											mergeRight = true;
										}
										else if (num34 == -2)
										{
											num3 = 252;
											num2 = 18 * frameNumber;
											mergeLeft = true;
										}
										else if (num35 == -2)
										{
											num3 = 252;
											num2 = 54 + 18 * frameNumber;
											mergeRight = true;
										}
									}
									else if (num32 == -2 && num37 == -1 && num34 == -1 && num35 == -1)
									{
										num2 = 108;
										num3 = 144 + 18 * frameNumber;
										mergeUp = true;
									}
									else if (num32 == -1 && num37 == -2 && num34 == -1 && num35 == -1)
									{
										num2 = 108;
										num3 = 90 + 18 * frameNumber;
										mergeDown = true;
									}
									else if (num32 == -1 && num37 == -1 && num34 == -2 && num35 == -1)
									{
										num3 = 234;
										num2 = 18 * frameNumber;
										mergeLeft = true;
									}
									else if (num32 == -1 && num37 == -1 && num34 == -1 && num35 == -2)
									{
										num3 = 234;
										num2 = 54 + 18 * frameNumber;
										mergeRight = true;
									}
								}
							}
							if (num2 < 0)
							{
								if (!flag3)
								{
									flag3 = true;
									if (num32 >= 0 && num32 != num && !Main.tileSolid[num32])
									{
										num32 = -1;
									}
									if (num37 >= 0 && num37 != num && !Main.tileSolid[num37])
									{
										num37 = -1;
									}
									if (num34 >= 0 && num34 != num && !Main.tileSolid[num34])
									{
										num34 = -1;
									}
									if (num35 >= 0 && num35 != num && !Main.tileSolid[num35])
									{
										num35 = -1;
									}
									if (num31 >= 0 && num31 != num && !Main.tileSolid[num31])
									{
										num31 = -1;
									}
									if (num33 >= 0 && num33 != num && !Main.tileSolid[num33])
									{
										num33 = -1;
									}
									if (num36 >= 0 && num36 != num && !Main.tileSolid[num36])
									{
										num36 = -1;
									}
									if (num38 >= 0 && num38 != num && !Main.tileSolid[num38])
									{
										num38 = -1;
									}
								}
								if (num == 2 || num == 23 || num == 60 || num == 70 || num == 109)
								{
									if (num32 == -2)
									{
										num32 = num;
									}
									if (num37 == -2)
									{
										num37 = num;
									}
									if (num34 == -2)
									{
										num34 = num;
									}
									if (num35 == -2)
									{
										num35 = num;
									}
									if (num31 == -2)
									{
										num31 = num;
									}
									if (num33 == -2)
									{
										num33 = num;
									}
									if (num36 == -2)
									{
										num36 = num;
									}
									if (num38 == -2)
									{
										num38 = num;
									}
								}
								if (num32 == num && num37 == num && num34 == num && num35 == num)
								{
									if (num31 != num && num33 != num)
									{
										num3 = 18;
										num2 = 108 + 18 * frameNumber;
									}
									else if (num36 != num && num38 != num)
									{
										num3 = 36;
										num2 = 108 + 18 * frameNumber;
									}
									else if (num31 != num && num36 != num)
									{
										num2 = 180;
										num3 = 18 * frameNumber;
									}
									else if (num33 != num && num38 != num)
									{
										num2 = 198;
										num3 = 18 * frameNumber;
									}
									else
									{
										num3 = 18;
										num2 = 18 + 18 * frameNumber;
									}
								}
								else if (num32 != num && num37 == num && num34 == num && num35 == num)
								{
									num3 = 0;
									num2 = 18 + 18 * frameNumber;
								}
								else if (num32 == num && num37 != num && num34 == num && num35 == num)
								{
									num3 = 36;
									num2 = 18 + 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 != num && num35 == num)
								{
									num2 = 0;
									num3 = 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 == num && num35 != num)
								{
									num2 = 72;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 == num && num34 != num && num35 == num)
								{
									num2 = 36 * frameNumber;
									num3 = 54;
								}
								else if (num32 != num && num37 == num && num34 == num && num35 != num)
								{
									num2 = 18 + 36 * frameNumber;
									num3 = 54;
								}
								else if (num32 == num && num37 != num && num34 != num && num35 == num)
								{
									num2 = 36 * frameNumber;
									num3 = 72;
								}
								else if (num32 == num && num37 != num && num34 == num && num35 != num)
								{
									num2 = 18 + 36 * frameNumber;
									num3 = 72;
								}
								else if (num32 == num && num37 == num && num34 != num && num35 != num)
								{
									num2 = 90;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 != num && num34 == num && num35 == num)
								{
									num2 = 108 + 18 * frameNumber;
									num3 = 72;
								}
								else if (num32 != num && num37 == num && num34 != num && num35 != num)
								{
									num2 = 108 + 18 * frameNumber;
									num3 = 0;
								}
								else if (num32 == num && num37 != num && num34 != num && num35 != num)
								{
									num2 = 108 + 18 * frameNumber;
									num3 = 54;
								}
								else if (num32 != num && num37 != num && num34 != num && num35 == num)
								{
									num2 = 162;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 != num && num34 == num && num35 != num)
								{
									num2 = 216;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 != num && num34 != num && num35 != num)
								{
									num2 = 162 + 18 * frameNumber;
									num3 = 54;
								}
							}
							if (num2 < 0)
							{
								num3 = 18;
								num2 = 18 + 18 * frameNumber;
							}
							ptr->frameX = (short)num2;
							ptr->frameY = (short)num3;
							if (num != 52 && num != 62 && num != 115)
							{
								goto IL_332d;
							}
							num32 = ((ptr[-1].active != 0) ? ptr[-1].type : (-1));
							if (num == 52 && (num32 == 109 || num32 == 115))
							{
								ptr->type = 115;
								SquareTileFrame(i, j);
							}
							else
							{
								if (num != 115 || (num32 != 2 && num32 != 52))
								{
									if (num32 != num && (num32 == -1 || (num == 52 && num32 != 2) || (num == 62 && num32 != 60) || (num == 115 && num32 != 109)))
									{
										KillTile(i, j);
									}
									goto IL_332d;
								}
								ptr->type = 52;
								SquareTileFrame(i, j);
							}
						}
					}
					goto end_IL_003d;
					IL_332d:
					if (gen || Main.netMode == 1 || (num != 53 && num != 112 && num != 116 && num != 123))
					{
						goto IL_339f;
					}
					Tile* ptr3 = ptr + 1;
					if (ptr3->active != 0)
					{
						goto IL_339f;
					}
					ptr3 = ptr - 1;
					if (ptr3->active != 0 && ptr3->type == 21)
					{
						goto IL_339f;
					}
					ptr->active = 0;
					sandBuffer[currentSandBuffer].Add(i, j);
					goto end_IL_003d;
					IL_339f:
					if (frameX >= 0 && num2 != frameX && frameY >= 0 && num3 != frameY && tileFrameRecursion)
					{
						bool flag4 = mergeUp;
						bool flag5 = mergeDown;
						bool flag6 = mergeLeft;
						bool flag7 = mergeRight;
						TileFrame(i, j - 1);
						TileFrame(i, j + 1);
						TileFrame(i - 1, j);
						TileFrame(i + 1, j);
						mergeUp = flag4;
						mergeDown = flag5;
						mergeLeft = flag6;
						mergeRight = flag7;
					}
					end_IL_003d:;
				}
			}
		}

		public unsafe static void TileFrameNoLiquid(int i, int j, int frameNumber = 0)
		{
			if (i > 5 && j > 5 && i < Main.maxTilesX - 5 && j < Main.maxTilesY - 5)
			{
				fixed (Tile* ptr = &Main.tile[i, j])
				{
					int num;
					if (ptr->active != 0)
					{
						num = ptr->type;
						if (Main.tileStone[num])
						{
							num = 1;
						}
						int frameX = ptr->frameX;
						int frameY = ptr->frameY;
						int num2 = -1;
						int num3 = -1;
						if (Main.tileFrameImportant[num])
						{
							switch (num)
							{
							case 5:
								break;
							case 6:
							case 7:
							case 8:
							case 9:
							case 19:
							case 22:
							case 23:
							case 25:
							case 30:
							case 32:
							case 37:
							case 38:
							case 39:
							case 40:
							case 41:
							case 43:
							case 44:
							case 45:
							case 46:
							case 47:
							case 48:
							case 49:
							case 51:
							case 52:
							case 53:
							case 54:
							case 56:
							case 57:
							case 58:
							case 59:
							case 60:
							case 62:
							case 63:
							case 64:
							case 65:
							case 66:
							case 67:
							case 68:
							case 69:
							case 70:
							case 75:
							case 76:
							case 80:
							case 107:
							case 108:
							case 109:
							case 111:
							case 112:
							case 115:
							case 116:
							case 117:
							case 118:
							case 119:
							case 120:
							case 121:
							case 122:
							case 123:
							case 124:
							case 127:
							case 130:
							case 131:
							case 137:
							case 140:
							case 145:
							case 146:
							case 147:
							case 148:
								break;
							case 12:
							case 31:
								break;
							case 13:
							case 33:
							case 50:
								break;
							case 14:
							case 17:
							case 26:
							case 77:
							case 86:
							case 87:
							case 88:
							case 89:
							case 114:
							case 133:
								break;
							case 15:
							case 20:
								break;
							case 16:
							case 18:
							case 29:
							case 103:
							case 134:
								break;
							case 21:
								break;
							case 27:
								break;
							case 28:
								break;
							case 34:
							case 35:
							case 36:
							case 106:
								break;
							case 42:
								break;
							case 55:
							case 85:
								break;
							case 78:
								break;
							case 79:
							case 90:
								break;
							case 82:
							case 83:
							case 84:
								break;
							case 91:
								break;
							case 92:
							case 93:
								break;
							case 94:
							case 95:
							case 96:
							case 97:
							case 98:
							case 99:
							case 100:
							case 125:
							case 126:
							case 132:
							case 138:
							case 142:
							case 143:
								break;
							case 101:
							case 102:
								break;
							case 104:
							case 105:
								break;
							case 128:
								break;
							case 135:
							case 141:
							case 144:
								break;
							case 139:
								break;
							case 3:
							case 24:
							case 61:
							case 71:
							case 73:
							case 74:
							case 110:
							case 113:
								PlantCheck(i, j);
								break;
							case 4:
							{
								int num8 = (ptr->frameX >= 66) ? 66 : 0;
								int num9 = -1;
								int num10 = -1;
								int num11 = -1;
								int num12 = -1;
								int num13 = -1;
								int num14 = -1;
								int num15 = -1;
								if (ptr[-1].active != 0)
								{
									_ = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num9 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num10 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num11 = ptr[1440].type;
								}
								if (ptr[-1439].active != 0)
								{
									num12 = ptr[-1439].type;
								}
								if (ptr[1441].active != 0)
								{
									num13 = ptr[1441].type;
								}
								if (ptr[-1441].active != 0)
								{
									num14 = ptr[-1441].type;
								}
								if (ptr[1439].active != 0)
								{
									num15 = ptr[1439].type;
								}
								if (num9 >= 0 && Main.tileSolidAndAttach[num9])
								{
									ptr->frameX = (short)num8;
								}
								else if (num10 >= 0 && (Main.tileSolidAndAttach[num10] || num10 == 124 || (num10 == 5 && num14 == 5 && num12 == 5)))
								{
									ptr->frameX = (short)(22 + num8);
								}
								else if (num11 >= 0 && (Main.tileSolidAndAttach[num11] || num11 == 124 || (num11 == 5 && num15 == 5 && num13 == 5)))
								{
									ptr->frameX = (short)(44 + num8);
								}
								else
								{
									KillTile(i, j);
								}
								break;
							}
							case 136:
							{
								int num20 = -1;
								int num21 = -1;
								int num22 = -1;
								if (ptr[-1].active != 0)
								{
									_ = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num20 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num21 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num22 = ptr[1440].type;
								}
								if (num20 >= 0 && Main.tileSolidAndAttach[num20])
								{
									ptr->frameX = 0;
								}
								else if (num21 >= 0 && (Main.tileSolidAndAttach[num21] || num21 == 124 || num21 == 5))
								{
									ptr->frameX = 18;
								}
								else if (num22 >= 0 && (Main.tileSolidAndAttach[num22] || num22 == 124 || num22 == 5))
								{
									ptr->frameX = 36;
								}
								else
								{
									KillTile(i, j);
								}
								break;
							}
							case 129:
							case 149:
							{
								int num16 = -1;
								int num17 = -1;
								int num18 = -1;
								int num19 = -1;
								if (ptr[-1].active != 0)
								{
									num17 = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num16 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num18 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num19 = ptr[1440].type;
								}
								if (num16 >= 0 && Main.tileSolidNotSolidTop[num16])
								{
									ptr->frameY = 0;
								}
								else if (num18 >= 0 && Main.tileSolidNotSolidTop[num18])
								{
									ptr->frameY = 54;
								}
								else if (num19 >= 0 && Main.tileSolidNotSolidTop[num19])
								{
									ptr->frameY = 36;
								}
								else if (num17 >= 0 && Main.tileSolidNotSolidTop[num17])
								{
									ptr->frameY = 18;
								}
								else
								{
									KillTile(i, j);
								}
								break;
							}
							case 10:
								if (!destroyObject)
								{
									int num28 = j - frameY / 18;
									bool flag2 = false;
									if (Main.tile[i, num28 - 1].active == 0 || !Main.tileSolid[Main.tile[i, num28 - 1].type])
									{
										flag2 = true;
									}
									else if (Main.tile[i, num28 + 3].active == 0 || !Main.tileSolid[Main.tile[i, num28 + 3].type])
									{
										flag2 = true;
									}
									else if (Main.tile[i, num28].active == 0 || Main.tile[i, num28].type != num)
									{
										flag2 = true;
									}
									else if (Main.tile[i, num28 + 1].active == 0 || Main.tile[i, num28 + 1].type != num)
									{
										flag2 = true;
									}
									else if (Main.tile[i, num28 + 2].active == 0 || Main.tile[i, num28 + 2].type != num)
									{
										flag2 = true;
									}
									if (flag2)
									{
										destroyObject = true;
										KillTile(i, num28);
										KillTile(i, num28 + 1);
										KillTile(i, num28 + 2);
										if (!gen)
										{
											Item.NewItem(i * 16, j * 16, 16, 16, 25);
										}
									}
									destroyObject = false;
								}
								break;
							case 11:
								if (!destroyObject)
								{
									int num23 = 0;
									int num24 = 0;
									int num25 = i;
									int num26 = j;
									bool flag = false;
									switch (frameX)
									{
									case 0:
										num23 = 1;
										break;
									case 18:
										num25 = i - 1;
										num24 = -1440;
										num23 = 1;
										break;
									case 36:
										num24 = 1440;
										num25 = i + 1;
										num23 = -1;
										break;
									case 54:
										num23 = -1;
										break;
									}
									switch (frameY)
									{
									case 18:
										num24--;
										num26 = j - 1;
										break;
									case 36:
										num26 = j - 2;
										num24 -= 2;
										break;
									}
									if (ptr[num24 - 1].active == 0 || !Main.tileSolid[ptr[num24 - 1].type] || ptr[num24 + 3].active == 0 || !Main.tileSolid[ptr[num24 + 3].type])
									{
										flag = true;
										destroyObject = true;
										if (!gen)
										{
											Item.NewItem(i * 16, j * 16, 16, 16, 25);
										}
									}
									int num27 = num25;
									if (num23 == -1)
									{
										num27 = num25 - 1;
									}
									for (int k = num27; k < num27 + 2; k++)
									{
										for (int l = num26; l < num26 + 3; l++)
										{
											if (!flag)
											{
												fixed (Tile* ptr2 = &Main.tile[k, l])
												{
													if (ptr2->type != 11 || ptr2->active == 0)
													{
														destroyObject = true;
														flag = true;
														k = num27;
														l = num26;
														if (!gen)
														{
															Item.NewItem(i * 16, j * 16, 16, 16, 25);
														}
													}
												}
											}
											if (flag)
											{
												KillTile(k, l);
											}
										}
									}
									destroyObject = false;
								}
								break;
							case 72:
							{
								int num29 = -1;
								int num30 = -1;
								if (ptr[-1].active != 0)
								{
									num30 = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num29 = ptr[1].type;
								}
								if (num29 != num && num29 != 70)
								{
									KillTile(i, j);
								}
								else if (num30 != num && ptr->frameX == 0)
								{
									ptr->frameNumber = (byte)genRand.Next(3);
									ptr->frameX = 18;
									ptr->frameY = (short)(18 * ptr->frameNumber);
								}
								break;
							}
							case 81:
							{
								int num4 = -1;
								int num5 = -1;
								int num6 = -1;
								int num7 = -1;
								if (ptr[-1].active != 0)
								{
									num5 = ptr[-1].type;
								}
								if (ptr[1].active != 0)
								{
									num4 = ptr[1].type;
								}
								if (ptr[-1440].active != 0)
								{
									num6 = ptr[-1440].type;
								}
								if (ptr[1440].active != 0)
								{
									num7 = ptr[1440].type;
								}
								if (num6 != -1 || num5 != -1 || num7 != -1)
								{
									KillTile(i, j);
								}
								else if (num4 < 0 || !Main.tileSolid[num4])
								{
									KillTile(i, j);
								}
								break;
							}
							}
						}
						else
						{
							int num31 = -1;
							int num32 = -1;
							int num33 = -1;
							int num34 = -1;
							int num35 = -1;
							int num36 = -1;
							int num37 = -1;
							int num38 = -1;
							if (ptr[-1440].active != 0)
							{
								int type = ptr[-1440].type;
								num34 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1440].active != 0)
							{
								int type = ptr[1440].type;
								num35 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[-1].active != 0)
							{
								int type = ptr[-1].type;
								num32 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1].active != 0)
							{
								int type = ptr[1].type;
								num37 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[-1441].active != 0)
							{
								int type = ptr[-1441].type;
								num31 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1439].active != 0)
							{
								int type = ptr[1439].type;
								num33 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[-1439].active != 0)
							{
								int type = ptr[-1439].type;
								num36 = (Main.tileStone[type] ? 1 : type);
							}
							if (ptr[1441].active != 0)
							{
								int type = ptr[1441].type;
								num38 = (Main.tileStone[type] ? 1 : type);
							}
							switch (num)
							{
							case 49:
								return;
							case 19:
								if (num35 >= 0 && !Main.tileSolid[num35])
								{
									num35 = -1;
								}
								if (num34 >= 0 && !Main.tileSolid[num34])
								{
									num34 = -1;
								}
								num2 = ((num34 == num) ? ((num35 != num) ? ((num35 >= 0) ? 72 : 18) : 0) : ((num34 < 0) ? ((num35 == num) ? 36 : ((num35 <= 0) ? 90 : 126)) : ((num35 == num) ? 54 : ((num35 >= 0) ? 90 : 108))));
								num3 = 18 * ptr->frameNumber;
								break;
							case 80:
								CactusFrame(i, j);
								return;
							}
							mergeUp2 = false;
							mergeDown2 = false;
							mergeLeft2 = false;
							mergeRight2 = false;
							if (frameNumber < 0)
							{
								frameNumber = genRand.Next(3);
								ptr->frameNumber = (byte)frameNumber;
							}
							else
							{
								frameNumber = ptr->frameNumber;
							}
							if (num == 0)
							{
								if (num32 >= 0 && Main.tileMergeDirt[num32])
								{
									TileFrameNoLiquid(i, j - 1);
									if (mergeDown2)
									{
										num32 = num;
									}
								}
								if (num37 >= 0 && Main.tileMergeDirt[num37])
								{
									TileFrameNoLiquid(i, j + 1);
									if (mergeUp2)
									{
										num37 = num;
									}
								}
								if (num34 >= 0 && Main.tileMergeDirt[num34])
								{
									TileFrameNoLiquid(i - 1, j);
									if (mergeRight2)
									{
										num34 = num;
									}
								}
								if (num35 >= 0 && Main.tileMergeDirt[num35])
								{
									TileFrameNoLiquid(i + 1, j);
									if (mergeLeft2)
									{
										num35 = num;
									}
								}
								if (num32 == 2 || num32 == 23 || num32 == 109)
								{
									num32 = num;
								}
								if (num37 == 2 || num37 == 23 || num37 == 109)
								{
									num37 = num;
								}
								if (num34 == 2 || num34 == 23 || num34 == 109)
								{
									num34 = num;
								}
								if (num35 == 2 || num35 == 23 || num35 == 109)
								{
									num35 = num;
								}
								if (num31 >= 0 && Main.tileMergeDirt[num31])
								{
									num31 = num;
								}
								else if (num31 == 2 || num31 == 23 || num31 == 109)
								{
									num31 = num;
								}
								if (num33 >= 0 && Main.tileMergeDirt[num33])
								{
									num33 = num;
								}
								else if (num33 == 2 || num33 == 23 || num33 == 109)
								{
									num33 = num;
								}
								if (num36 >= 0 && Main.tileMergeDirt[num36])
								{
									num36 = num;
								}
								else if (num36 == 2 || num36 == 23 || num33 == 109)
								{
									num36 = num;
								}
								if (num38 >= 0 && Main.tileMergeDirt[num38])
								{
									num38 = num;
								}
								else if (num38 == 2 || num38 == 23 || num38 == 109)
								{
									num38 = num;
								}
								if (j < Main.rockLayer)
								{
									if (num32 == 59)
									{
										num32 = -2;
									}
									if (num37 == 59)
									{
										num37 = -2;
									}
									if (num34 == 59)
									{
										num34 = -2;
									}
									if (num35 == 59)
									{
										num35 = -2;
									}
									if (num31 == 59)
									{
										num31 = -2;
									}
									if (num33 == 59)
									{
										num33 = -2;
									}
									if (num36 == 59)
									{
										num36 = -2;
									}
									if (num38 == 59)
									{
										num38 = -2;
									}
								}
							}
							else if (Main.tileMergeDirt[num])
							{
								if (num32 == 0)
								{
									num32 = -2;
								}
								if (num37 == 0)
								{
									num37 = -2;
								}
								if (num34 == 0)
								{
									num34 = -2;
								}
								if (num35 == 0)
								{
									num35 = -2;
								}
								if (num31 == 0)
								{
									num31 = -2;
								}
								if (num33 == 0)
								{
									num33 = -2;
								}
								if (num36 == 0)
								{
									num36 = -2;
								}
								if (num38 == 0)
								{
									num38 = -2;
								}
								if (num == 1)
								{
									if (j > Main.rockLayer)
									{
										if (num32 == 59)
										{
											TileFrameNoLiquid(i, j - 1);
											if (mergeDown2)
											{
												num32 = num;
											}
										}
										if (num37 == 59)
										{
											TileFrameNoLiquid(i, j + 1);
											if (mergeUp2)
											{
												num37 = num;
											}
										}
										if (num34 == 59)
										{
											TileFrameNoLiquid(i - 1, j);
											if (mergeRight2)
											{
												num34 = num;
											}
										}
										if (num35 == 59)
										{
											TileFrameNoLiquid(i + 1, j);
											if (mergeLeft2)
											{
												num35 = num;
											}
										}
										if (num31 == 59)
										{
											num31 = num;
										}
										if (num33 == 59)
										{
											num33 = num;
										}
										if (num36 == 59)
										{
											num36 = num;
										}
										if (num38 == 59)
										{
											num38 = num;
										}
									}
									if (num32 == 57)
									{
										TileFrameNoLiquid(i, j - 1);
										if (mergeDown2)
										{
											num32 = num;
										}
									}
									if (num37 == 57)
									{
										TileFrameNoLiquid(i, j + 1);
										if (mergeUp2)
										{
											num37 = num;
										}
									}
									if (num34 == 57)
									{
										TileFrameNoLiquid(i - 1, j);
										if (mergeRight2)
										{
											num34 = num;
										}
									}
									if (num35 == 57)
									{
										TileFrameNoLiquid(i + 1, j);
										if (mergeLeft2)
										{
											num35 = num;
										}
									}
									if (num31 == 57)
									{
										num31 = num;
									}
									if (num33 == 57)
									{
										num33 = num;
									}
									if (num36 == 57)
									{
										num36 = num;
									}
									if (num38 == 57)
									{
										num38 = num;
									}
								}
							}
							else
							{
								switch (num)
								{
								case 58:
								case 75:
								case 76:
									if (num32 == 57)
									{
										num32 = -2;
									}
									if (num37 == 57)
									{
										num37 = -2;
									}
									if (num34 == 57)
									{
										num34 = -2;
									}
									if (num35 == 57)
									{
										num35 = -2;
									}
									if (num31 == 57)
									{
										num31 = -2;
									}
									if (num33 == 57)
									{
										num33 = -2;
									}
									if (num36 == 57)
									{
										num36 = -2;
									}
									if (num38 == 57)
									{
										num38 = -2;
									}
									break;
								case 59:
									if (j > Main.rockLayer)
									{
										if (num32 == 1)
										{
											num32 = -2;
										}
										if (num37 == 1)
										{
											num37 = -2;
										}
										if (num34 == 1)
										{
											num34 = -2;
										}
										if (num35 == 1)
										{
											num35 = -2;
										}
										if (num31 == 1)
										{
											num31 = -2;
										}
										if (num33 == 1)
										{
											num33 = -2;
										}
										if (num36 == 1)
										{
											num36 = -2;
										}
										if (num38 == 1)
										{
											num38 = -2;
										}
									}
									if (num32 == 60 || num32 == 70)
									{
										num32 = num;
									}
									if (num37 == 60 || num37 == 70)
									{
										num37 = num;
									}
									if (num34 == 60 || num34 == 70)
									{
										num34 = num;
									}
									if (num35 == 60 || num35 == 70)
									{
										num35 = num;
									}
									if (num31 == 60 || num31 == 70)
									{
										num31 = num;
									}
									if (num33 == 60 || num33 == 70)
									{
										num33 = num;
									}
									if (num36 == 60 || num36 == 70)
									{
										num36 = num;
									}
									if (num38 == 60 || num38 == 70)
									{
										num38 = num;
									}
									if (j < Main.rockLayer)
									{
										if (num32 == 0)
										{
											TileFrameNoLiquid(i, j - 1);
											if (mergeDown2)
											{
												num32 = num;
											}
										}
										if (num37 == 0)
										{
											TileFrameNoLiquid(i, j + 1);
											if (mergeUp2)
											{
												num37 = num;
											}
										}
										if (num34 == 0)
										{
											TileFrameNoLiquid(i - 1, j);
											if (mergeRight2)
											{
												num34 = num;
											}
										}
										if (num35 == 0)
										{
											TileFrameNoLiquid(i + 1, j);
											if (mergeLeft2)
											{
												num35 = num;
											}
										}
										if (num31 == 0)
										{
											num31 = num;
										}
										if (num33 == 0)
										{
											num33 = num;
										}
										if (num36 == 0)
										{
											num36 = num;
										}
										if (num38 == 0)
										{
											num38 = num;
										}
									}
									break;
								case 57:
									if (num32 == 1)
									{
										num32 = -2;
									}
									if (num37 == 1)
									{
										num37 = -2;
									}
									if (num34 == 1)
									{
										num34 = -2;
									}
									if (num35 == 1)
									{
										num35 = -2;
									}
									if (num31 == 1)
									{
										num31 = -2;
									}
									if (num33 == 1)
									{
										num33 = -2;
									}
									if (num36 == 1)
									{
										num36 = -2;
									}
									if (num38 == 1)
									{
										num38 = -2;
									}
									if (num32 == 58 || num32 == 76 || num32 == 75)
									{
										TileFrameNoLiquid(i, j - 1);
										if (mergeDown2)
										{
											num32 = num;
										}
									}
									if (num37 == 58 || num37 == 76 || num37 == 75)
									{
										TileFrameNoLiquid(i, j + 1);
										if (mergeUp2)
										{
											num37 = num;
										}
									}
									if (num34 == 58 || num34 == 76 || num34 == 75)
									{
										TileFrameNoLiquid(i - 1, j);
										if (mergeRight2)
										{
											num34 = num;
										}
									}
									if (num35 == 58 || num35 == 76 || num35 == 75)
									{
										TileFrameNoLiquid(i + 1, j);
										if (mergeLeft2)
										{
											num35 = num;
										}
									}
									if (num31 == 58 || num31 == 76 || num31 == 75)
									{
										num31 = num;
									}
									if (num33 == 58 || num33 == 76 || num33 == 75)
									{
										num33 = num;
									}
									if (num36 == 58 || num36 == 76 || num36 == 75)
									{
										num36 = num;
									}
									if (num38 == 58 || num38 == 76 || num38 == 75)
									{
										num38 = num;
									}
									break;
								case 32:
									if (num37 == 23)
									{
										num37 = num;
									}
									break;
								case 69:
									if (num37 == 60)
									{
										num37 = num;
									}
									break;
								case 51:
									if (num32 >= 0 && !Main.tileNoAttach[num32])
									{
										num32 = num;
									}
									if (num37 >= 0 && !Main.tileNoAttach[num37])
									{
										num37 = num;
									}
									if (num34 >= 0 && !Main.tileNoAttach[num34])
									{
										num34 = num;
									}
									if (num35 >= 0 && !Main.tileNoAttach[num35])
									{
										num35 = num;
									}
									if (num31 >= 0 && !Main.tileNoAttach[num31])
									{
										num31 = num;
									}
									if (num33 >= 0 && !Main.tileNoAttach[num33])
									{
										num33 = num;
									}
									if (num36 >= 0 && !Main.tileNoAttach[num36])
									{
										num36 = num;
									}
									if (num38 >= 0 && !Main.tileNoAttach[num38])
									{
										num38 = num;
									}
									break;
								}
							}
							bool flag3 = false;
							if (num == 2 || num == 23 || num == 60 || num == 70 || num == 109)
							{
								flag3 = true;
								if (num32 >= 0 && num32 != num && !Main.tileSolid[num32])
								{
									num32 = -1;
								}
								if (num37 >= 0 && num37 != num && !Main.tileSolid[num37])
								{
									num37 = -1;
								}
								if (num34 >= 0 && num34 != num && !Main.tileSolid[num34])
								{
									num34 = -1;
								}
								if (num35 >= 0 && num35 != num && !Main.tileSolid[num35])
								{
									num35 = -1;
								}
								if (num31 >= 0 && num31 != num && !Main.tileSolid[num31])
								{
									num31 = -1;
								}
								if (num33 >= 0 && num33 != num && !Main.tileSolid[num33])
								{
									num33 = -1;
								}
								if (num36 >= 0 && num36 != num && !Main.tileSolid[num36])
								{
									num36 = -1;
								}
								if (num38 >= 0 && num38 != num && !Main.tileSolid[num38])
								{
									num38 = -1;
								}
								int num39 = 0;
								switch (num)
								{
								case 60:
								case 70:
									num39 = 59;
									break;
								case 2:
									if (num32 == 23)
									{
										num32 = num39;
									}
									if (num37 == 23)
									{
										num37 = num39;
									}
									if (num34 == 23)
									{
										num34 = num39;
									}
									if (num35 == 23)
									{
										num35 = num39;
									}
									if (num31 == 23)
									{
										num31 = num39;
									}
									if (num33 == 23)
									{
										num33 = num39;
									}
									if (num36 == 23)
									{
										num36 = num39;
									}
									if (num38 == 23)
									{
										num38 = num39;
									}
									break;
								case 23:
									if (num32 == 2)
									{
										num32 = num39;
									}
									if (num37 == 2)
									{
										num37 = num39;
									}
									if (num34 == 2)
									{
										num34 = num39;
									}
									if (num35 == 2)
									{
										num35 = num39;
									}
									if (num31 == 2)
									{
										num31 = num39;
									}
									if (num33 == 2)
									{
										num33 = num39;
									}
									if (num36 == 2)
									{
										num36 = num39;
									}
									if (num38 == 2)
									{
										num38 = num39;
									}
									break;
								}
								if (num32 != num && num32 != num39 && (num37 == num || num37 == num39))
								{
									if (num34 == num39 && num35 == num)
									{
										num2 = 18 * frameNumber;
										num3 = 198;
									}
									else if (num34 == num && num35 == num39)
									{
										num2 = 54 + 18 * frameNumber;
										num3 = 198;
									}
								}
								else if (num37 != num && num37 != num39 && (num32 == num || num32 == num39))
								{
									if (num34 == num39 && num35 == num)
									{
										num2 = 18 * frameNumber;
										num3 = 216;
									}
									else if (num34 == num && num35 == num39)
									{
										num2 = 54 + 18 * frameNumber;
										num3 = 216;
									}
								}
								else if (num34 != num && num34 != num39 && (num35 == num || num35 == num39))
								{
									if (num32 == num39 && num37 == num)
									{
										num2 = 72;
										num3 = 144 + 18 * frameNumber;
									}
									else if (num37 == num && num35 == num32)
									{
										num2 = 72;
										num3 = 90 + 18 * frameNumber;
									}
								}
								else if (num35 != num && num35 != num39 && (num34 == num || num34 == num39))
								{
									if (num32 == num39 && num37 == num)
									{
										num2 = 90;
										num3 = 144 + 18 * frameNumber;
									}
									else if (num37 == num && num35 == num32)
									{
										num2 = 90;
										num3 = 90 + 18 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num && num34 == num && num35 == num)
								{
									if (num31 != num && num33 != num && num36 != num && num38 != num)
									{
										if (num38 == num39)
										{
											num3 = 324;
											num2 = 108 + 18 * frameNumber;
										}
										else if (num33 == num39)
										{
											num3 = 342;
											num2 = 108 + 18 * frameNumber;
										}
										else if (num36 == num39)
										{
											num3 = 360;
											num2 = 108 + 18 * frameNumber;
										}
										else if (num31 == num39)
										{
											num3 = 378;
											num2 = 108 + 18 * frameNumber;
										}
										else
										{
											num3 = 234;
											num2 = 144 + 54 * frameNumber;
										}
									}
									else if (num31 != num && num38 != num)
									{
										num3 = 306;
										num2 = 36 + 18 * frameNumber;
									}
									else if (num33 != num && num36 != num)
									{
										num3 = 306;
										num2 = 90 + 18 * frameNumber;
									}
									else if (num31 != num && num33 == num && num36 == num && num38 == num)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num31 == num && num33 != num && num36 == num && num38 == num)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num31 == num && num33 == num && num36 != num && num38 == num)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num31 == num && num33 == num && num36 == num && num38 != num)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num39 && num34 == num && num35 == num && num31 == -1 && num33 == -1)
								{
									num3 = 18;
									num2 = 108 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num && num34 == num && num35 == num && num36 == -1 && num38 == -1)
								{
									num3 = 36;
									num2 = 108 + 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 == num39 && num35 == num && num33 == -1 && num38 == -1)
								{
									num2 = 198;
									num3 = 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 == num && num35 == num39 && num31 == -1 && num36 == -1)
								{
									num2 = 180;
									num3 = 18 * frameNumber;
								}
								else if (num32 == num && num37 == num39 && num34 == num && num35 == num)
								{
									if (num33 != -1)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num31 != -1)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
								}
								else if (num32 == num39 && num37 == num && num34 == num && num35 == num)
								{
									if (num38 != -1)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num36 != -1)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num && num34 == num && num35 == num39)
								{
									if (num31 != -1)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num36 != -1)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
								}
								else if (num32 == num && num37 == num && num34 == num39 && num35 == num)
								{
									if (num33 != -1)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num38 != -1)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
								}
								else if ((num32 == num39 && num37 == num && num34 == num && num35 == num) || (num32 == num && num37 == num39 && num34 == num && num35 == num) || (num32 == num && num37 == num && num34 == num39 && num35 == num) || (num32 == num && num37 == num && num34 == num && num35 == num39))
								{
									num3 = 18;
									num2 = 18 + 18 * frameNumber;
								}
								if ((num32 == num || num32 == num39) && (num37 == num || num37 == num39) && (num34 == num || num34 == num39) && (num35 == num || num35 == num39))
								{
									if (num31 != num && num31 != num39 && (num33 == num || num33 == num39) && (num36 == num || num36 == num39) && (num38 == num || num38 == num39))
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num33 != num && num33 != num39 && (num31 == num || num31 == num39) && (num36 == num || num36 == num39) && (num38 == num || num38 == num39))
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
									}
									else if (num36 != num && num36 != num39 && (num31 == num || num31 == num39) && (num33 == num || num33 == num39) && (num38 == num || num38 == num39))
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
									}
									else if (num38 != num && num38 != num39 && (num31 == num || num31 == num39) && (num36 == num || num36 == num39) && (num33 == num || num33 == num39))
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
									}
								}
								if (num32 != num39 && num32 != num && num37 == num && num34 != num39 && num34 != num && num35 == num && num38 != num39 && num38 != num)
								{
									num3 = 270;
									num2 = 90 + 18 * frameNumber;
								}
								else if (num32 != num39 && num32 != num && num37 == num && num34 == num && num35 != num39 && num35 != num && num36 != num39 && num36 != num)
								{
									num3 = 270;
									num2 = 144 + 18 * frameNumber;
								}
								else if (num37 != num39 && num37 != num && num32 == num && num34 != num39 && num34 != num && num35 == num && num33 != num39 && num33 != num)
								{
									num3 = 288;
									num2 = 90 + 18 * frameNumber;
								}
								else if (num37 != num39 && num37 != num && num32 == num && num34 == num && num35 != num39 && num35 != num && num31 != num39 && num31 != num)
								{
									num3 = 288;
									num2 = 144 + 18 * frameNumber;
								}
								else if (num32 != num && num32 != num39 && num37 == num && num34 == num && num35 == num && num36 != num && num36 != num39 && num38 != num && num38 != num39)
								{
									num3 = 216;
									num2 = 144 + 54 * frameNumber;
								}
								else if (num37 != num && num37 != num39 && num32 == num && num34 == num && num35 == num && num31 != num && num31 != num39 && num33 != num && num33 != num39)
								{
									num3 = 252;
									num2 = 144 + 54 * frameNumber;
								}
								else if (num34 != num && num34 != num39 && num37 == num && num32 == num && num35 == num && num33 != num && num33 != num39 && num38 != num && num38 != num39)
								{
									num3 = 234;
									num2 = 126 + 54 * frameNumber;
								}
								else if (num35 != num && num35 != num39 && num37 == num && num32 == num && num34 == num && num31 != num && num31 != num39 && num36 != num && num36 != num39)
								{
									num3 = 234;
									num2 = 162 + 54 * frameNumber;
								}
								else if (num32 != num39 && num32 != num && (num37 == num39 || num37 == num) && num34 == num39 && num35 == num39)
								{
									num3 = 270;
									num2 = 36 + 18 * frameNumber;
								}
								else if (num37 != num39 && num37 != num && (num32 == num39 || num32 == num) && num34 == num39 && num35 == num39)
								{
									num3 = 288;
									num2 = 36 + 18 * frameNumber;
								}
								else if (num34 != num39 && num34 != num && (num35 == num39 || num35 == num) && num32 == num39 && num37 == num39)
								{
									num2 = 0;
									num3 = 270 + 18 * frameNumber;
								}
								else if (num35 != num39 && num35 != num && (num34 == num39 || num34 == num) && num32 == num39 && num37 == num39)
								{
									num2 = 18;
									num3 = 270 + 18 * frameNumber;
								}
								else if (num32 == num && num37 == num39 && num34 == num39 && num35 == num39)
								{
									num3 = 288;
									num2 = 198 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num && num34 == num39 && num35 == num39)
								{
									num3 = 270;
									num2 = 198 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num39 && num34 == num && num35 == num39)
								{
									num3 = 306;
									num2 = 198 + 18 * frameNumber;
								}
								else if (num32 == num39 && num37 == num39 && num34 == num39 && num35 == num)
								{
									num3 = 306;
									num2 = 144 + 18 * frameNumber;
								}
								if (num32 != num && num32 != num39 && num37 == num && num34 == num && num35 == num)
								{
									if ((num36 == num39 || num36 == num) && num38 != num39 && num38 != num)
									{
										num3 = 324;
										num2 = 18 * frameNumber;
									}
									else if ((num38 == num39 || num38 == num) && num36 != num39 && num36 != num)
									{
										num3 = 324;
										num2 = 54 + 18 * frameNumber;
									}
								}
								else if (num37 != num && num37 != num39 && num32 == num && num34 == num && num35 == num)
								{
									if ((num31 == num39 || num31 == num) && num33 != num39 && num33 != num)
									{
										num3 = 342;
										num2 = 18 * frameNumber;
									}
									else if ((num33 == num39 || num33 == num) && num31 != num39 && num31 != num)
									{
										num3 = 342;
										num2 = 54 + 18 * frameNumber;
									}
								}
								else if (num34 != num && num34 != num39 && num32 == num && num37 == num && num35 == num)
								{
									if ((num33 == num39 || num33 == num) && num38 != num39 && num38 != num)
									{
										num3 = 360;
										num2 = 54 + 18 * frameNumber;
									}
									else if ((num38 == num39 || num38 == num) && num33 != num39 && num33 != num)
									{
										num3 = 360;
										num2 = 18 * frameNumber;
									}
								}
								else if (num35 != num && num35 != num39 && num32 == num && num37 == num && num34 == num)
								{
									if ((num31 == num39 || num31 == num) && num36 != num39 && num36 != num)
									{
										num3 = 378;
										num2 = 18 * frameNumber;
									}
									else if ((num36 == num39 || num36 == num) && num31 != num39 && num31 != num)
									{
										num3 = 378;
										num2 = 54 + 18 * frameNumber;
									}
								}
								if ((num32 == num || num32 == num39) && (num37 == num || num37 == num39) && (num34 == num || num34 == num39) && (num35 == num || num35 == num39) && num31 != -1 && num33 != -1 && num36 != -1 && num38 != -1)
								{
									num3 = 18;
									num2 = 18 + 18 * frameNumber;
								}
								if (num32 == num39)
								{
									num32 = -2;
								}
								if (num37 == num39)
								{
									num37 = -2;
								}
								if (num34 == num39)
								{
									num34 = -2;
								}
								if (num35 == num39)
								{
									num35 = -2;
								}
								if (num31 == num39)
								{
									num31 = -2;
								}
								if (num33 == num39)
								{
									num33 = -2;
								}
								if (num36 == num39)
								{
									num36 = -2;
								}
								if (num38 == num39)
								{
									num38 = -2;
								}
							}
							if (num2 == -1 && (Main.tileMergeDirt[num] || num == 0 || num == 2 || num == 57 || num == 58 || num == 59 || num == 60 || num == 70 || num == 109 || num == 76 || num == 75))
							{
								if (!flag3)
								{
									flag3 = true;
									if (num31 >= 0 && num31 != num && !Main.tileSolid[num31])
									{
										num31 = -1;
									}
									if (num33 >= 0 && num33 != num && !Main.tileSolid[num33])
									{
										num33 = -1;
									}
									if (num36 >= 0 && num36 != num && !Main.tileSolid[num36])
									{
										num36 = -1;
									}
									if (num38 >= 0 && num38 != num && !Main.tileSolid[num38])
									{
										num38 = -1;
									}
								}
								if (num32 >= 0 && num32 != num)
								{
									num32 = -1;
								}
								if (num37 >= 0 && num37 != num)
								{
									num37 = -1;
								}
								if (num34 >= 0 && num34 != num)
								{
									num34 = -1;
								}
								if (num35 >= 0 && num35 != num)
								{
									num35 = -1;
								}
								if (num32 != -1 && num37 != -1 && num34 != -1 && num35 != -1)
								{
									if (num32 == -2 && num37 == num && num34 == num && num35 == num)
									{
										num3 = 108;
										num2 = 144 + 18 * frameNumber;
										mergeUp2 = true;
									}
									else if (num32 == num && num37 == -2 && num34 == num && num35 == num)
									{
										num3 = 90;
										num2 = 144 + 18 * frameNumber;
										mergeDown2 = true;
									}
									else if (num32 == num && num37 == num && num34 == -2 && num35 == num)
									{
										num2 = 162;
										num3 = 126 + 18 * frameNumber;
										mergeLeft2 = true;
									}
									else if (num32 == num && num37 == num && num34 == num && num35 == -2)
									{
										num2 = 144;
										num3 = 126 + 18 * frameNumber;
										mergeRight2 = true;
									}
									else if (num32 == -2 && num37 == num && num34 == -2 && num35 == num)
									{
										num2 = 36;
										num3 = 90 + 36 * frameNumber;
										mergeUp2 = true;
										mergeLeft2 = true;
									}
									else if (num32 == -2 && num37 == num && num34 == num && num35 == -2)
									{
										num2 = 54;
										num3 = 90 + 36 * frameNumber;
										mergeUp2 = true;
										mergeRight2 = true;
									}
									else if (num32 == num && num37 == -2 && num34 == -2 && num35 == num)
									{
										num2 = 36;
										num3 = 108 + 36 * frameNumber;
										mergeDown2 = true;
										mergeLeft2 = true;
									}
									else if (num32 == num && num37 == -2 && num34 == num && num35 == -2)
									{
										num2 = 54;
										num3 = 108 + 36 * frameNumber;
										mergeDown2 = true;
										mergeRight2 = true;
									}
									else if (num32 == num && num37 == num && num34 == -2 && num35 == -2)
									{
										num2 = 180;
										num3 = 126 + 18 * frameNumber;
										mergeLeft2 = true;
										mergeRight2 = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == num && num35 == num)
									{
										num3 = 180;
										num2 = 144 + 18 * frameNumber;
										mergeUp2 = true;
										mergeDown2 = true;
									}
									else if (num32 == -2 && num37 == num && num34 == -2 && num35 == -2)
									{
										num2 = 198;
										num3 = 90 + 18 * frameNumber;
										mergeUp2 = true;
										mergeLeft2 = true;
										mergeRight2 = true;
									}
									else if (num32 == num && num37 == -2 && num34 == -2 && num35 == -2)
									{
										num2 = 198;
										num3 = 144 + 18 * frameNumber;
										mergeDown2 = true;
										mergeLeft2 = true;
										mergeRight2 = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == num && num35 == -2)
									{
										num2 = 216;
										num3 = 144 + 18 * frameNumber;
										mergeUp2 = true;
										mergeDown2 = true;
										mergeRight2 = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == -2 && num35 == num)
									{
										num2 = 216;
										num3 = 90 + 18 * frameNumber;
										mergeUp2 = true;
										mergeDown2 = true;
										mergeLeft2 = true;
									}
									else if (num32 == -2 && num37 == -2 && num34 == -2 && num35 == -2)
									{
										num3 = 198;
										num2 = 108 + 18 * frameNumber;
										mergeUp2 = true;
										mergeDown2 = true;
										mergeLeft2 = true;
										mergeRight2 = true;
									}
									else if (num32 == num && num37 == num && num34 == num && num35 == num)
									{
										if (num38 == -2)
										{
											num2 = 0;
											num3 = 90 + 36 * frameNumber;
										}
										else if (num36 == -2)
										{
											num2 = 18;
											num3 = 90 + 36 * frameNumber;
										}
										else if (num33 == -2)
										{
											num2 = 0;
											num3 = 108 + 36 * frameNumber;
										}
										else if (num31 == -2)
										{
											num2 = 18;
											num3 = 108 + 36 * frameNumber;
										}
									}
								}
								else
								{
									if (num != 2 && num != 23 && num != 60 && num != 70 && num != 109)
									{
										if (num32 == -1 && num37 == -2 && num34 == num && num35 == num)
										{
											num3 = 0;
											num2 = 234 + 18 * frameNumber;
											mergeDown2 = true;
										}
										else if (num32 == -2 && num37 == -1 && num34 == num && num35 == num)
										{
											num3 = 18;
											num2 = 234 + 18 * frameNumber;
											mergeUp2 = true;
										}
										else if (num32 == num && num37 == num && num34 == -1 && num35 == -2)
										{
											num3 = 36;
											num2 = 234 + 18 * frameNumber;
											mergeRight2 = true;
										}
										else if (num32 == num && num37 == num && num34 == -2 && num35 == -1)
										{
											num3 = 54;
											num2 = 234 + 18 * frameNumber;
											mergeLeft2 = true;
										}
									}
									if (num32 != -1 && num37 != -1 && num34 == -1 && num35 == num)
									{
										if (num32 == -2 && num37 == num)
										{
											num2 = 72;
											num3 = 144 + 18 * frameNumber;
											mergeUp2 = true;
										}
										else if (num37 == -2 && num32 == num)
										{
											num2 = 72;
											num3 = 90 + 18 * frameNumber;
											mergeDown2 = true;
										}
									}
									else if (num32 != -1 && num37 != -1 && num34 == num && num35 == -1)
									{
										if (num32 == -2 && num37 == num)
										{
											num2 = 90;
											num3 = 144 + 18 * frameNumber;
											mergeUp2 = true;
										}
										else if (num37 == -2 && num32 == num)
										{
											num2 = 90;
											num3 = 90 + 18 * frameNumber;
											mergeDown2 = true;
										}
									}
									else if (num32 == -1 && num37 == num && num34 != -1 && num35 != -1)
									{
										if (num34 == -2 && num35 == num)
										{
											num2 = 18 * frameNumber;
											num3 = 198;
											mergeLeft2 = true;
										}
										else if (num35 == -2 && num34 == num)
										{
											num2 = 54 + 18 * frameNumber;
											num3 = 198;
											mergeRight2 = true;
										}
									}
									else if (num32 == num && num37 == -1 && num34 != -1 && num35 != -1)
									{
										if (num34 == -2 && num35 == num)
										{
											num2 = 18 * frameNumber;
											num3 = 216;
											mergeLeft2 = true;
										}
										else if (num35 == -2 && num34 == num)
										{
											num2 = 54 + 18 * frameNumber;
											num3 = 216;
											mergeRight2 = true;
										}
									}
									else if (num32 != -1 && num37 != -1 && num34 == -1 && num35 == -1)
									{
										if (num32 == -2 && num37 == -2)
										{
											num2 = 108;
											num3 = 216 + 18 * frameNumber;
											mergeUp2 = true;
											mergeDown2 = true;
										}
										else if (num32 == -2)
										{
											num2 = 126;
											num3 = 144 + 18 * frameNumber;
											mergeUp2 = true;
										}
										else if (num37 == -2)
										{
											num2 = 126;
											num3 = 90 + 18 * frameNumber;
											mergeDown2 = true;
										}
									}
									else if (num32 == -1 && num37 == -1 && num34 != -1 && num35 != -1)
									{
										if (num34 == -2 && num35 == -2)
										{
											num3 = 198;
											num2 = 162 + 18 * frameNumber;
											mergeLeft2 = true;
											mergeRight2 = true;
										}
										else if (num34 == -2)
										{
											num3 = 252;
											num2 = 18 * frameNumber;
											mergeLeft2 = true;
										}
										else if (num35 == -2)
										{
											num3 = 252;
											num2 = 54 + 18 * frameNumber;
											mergeRight2 = true;
										}
									}
									else if (num32 == -2 && num37 == -1 && num34 == -1 && num35 == -1)
									{
										num2 = 108;
										num3 = 144 + 18 * frameNumber;
										mergeUp2 = true;
									}
									else if (num32 == -1 && num37 == -2 && num34 == -1 && num35 == -1)
									{
										num2 = 108;
										num3 = 90 + 18 * frameNumber;
										mergeDown2 = true;
									}
									else if (num32 == -1 && num37 == -1 && num34 == -2 && num35 == -1)
									{
										num3 = 234;
										num2 = 18 * frameNumber;
										mergeLeft2 = true;
									}
									else if (num32 == -1 && num37 == -1 && num34 == -1 && num35 == -2)
									{
										num3 = 234;
										num2 = 54 + 18 * frameNumber;
										mergeRight2 = true;
									}
								}
							}
							if (num2 < 0)
							{
								if (!flag3)
								{
									flag3 = true;
									if (num32 >= 0 && num32 != num && !Main.tileSolid[num32])
									{
										num32 = -1;
									}
									if (num37 >= 0 && num37 != num && !Main.tileSolid[num37])
									{
										num37 = -1;
									}
									if (num34 >= 0 && num34 != num && !Main.tileSolid[num34])
									{
										num34 = -1;
									}
									if (num35 >= 0 && num35 != num && !Main.tileSolid[num35])
									{
										num35 = -1;
									}
									if (num31 >= 0 && num31 != num && !Main.tileSolid[num31])
									{
										num31 = -1;
									}
									if (num33 >= 0 && num33 != num && !Main.tileSolid[num33])
									{
										num33 = -1;
									}
									if (num36 >= 0 && num36 != num && !Main.tileSolid[num36])
									{
										num36 = -1;
									}
									if (num38 >= 0 && num38 != num && !Main.tileSolid[num38])
									{
										num38 = -1;
									}
								}
								if (num == 2 || num == 23 || num == 60 || num == 70 || num == 109)
								{
									if (num32 == -2)
									{
										num32 = num;
									}
									if (num37 == -2)
									{
										num37 = num;
									}
									if (num34 == -2)
									{
										num34 = num;
									}
									if (num35 == -2)
									{
										num35 = num;
									}
									if (num31 == -2)
									{
										num31 = num;
									}
									if (num33 == -2)
									{
										num33 = num;
									}
									if (num36 == -2)
									{
										num36 = num;
									}
									if (num38 == -2)
									{
										num38 = num;
									}
								}
								if (num32 == num && num37 == num && num34 == num && num35 == num)
								{
									if (num31 != num && num33 != num)
									{
										num3 = 18;
										num2 = 108 + 18 * frameNumber;
									}
									else if (num36 != num && num38 != num)
									{
										num3 = 36;
										num2 = 108 + 18 * frameNumber;
									}
									else if (num31 != num && num36 != num)
									{
										num2 = 180;
										num3 = 18 * frameNumber;
									}
									else if (num33 != num && num38 != num)
									{
										num2 = 198;
										num3 = 18 * frameNumber;
									}
									else
									{
										num3 = 18;
										num2 = 18 + 18 * frameNumber;
									}
								}
								else if (num32 != num && num37 == num && num34 == num && num35 == num)
								{
									num3 = 0;
									num2 = 18 + 18 * frameNumber;
								}
								else if (num32 == num && num37 != num && num34 == num && num35 == num)
								{
									num3 = 36;
									num2 = 18 + 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 != num && num35 == num)
								{
									num2 = 0;
									num3 = 18 * frameNumber;
								}
								else if (num32 == num && num37 == num && num34 == num && num35 != num)
								{
									num2 = 72;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 == num && num34 != num && num35 == num)
								{
									num2 = 36 * frameNumber;
									num3 = 54;
								}
								else if (num32 != num && num37 == num && num34 == num && num35 != num)
								{
									num2 = 18 + 36 * frameNumber;
									num3 = 54;
								}
								else if (num32 == num && num37 != num && num34 != num && num35 == num)
								{
									num2 = 36 * frameNumber;
									num3 = 72;
								}
								else if (num32 == num && num37 != num && num34 == num && num35 != num)
								{
									num2 = 18 + 36 * frameNumber;
									num3 = 72;
								}
								else if (num32 == num && num37 == num && num34 != num && num35 != num)
								{
									num2 = 90;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 != num && num34 == num && num35 == num)
								{
									num2 = 108 + 18 * frameNumber;
									num3 = 72;
								}
								else if (num32 != num && num37 == num && num34 != num && num35 != num)
								{
									num2 = 108 + 18 * frameNumber;
									num3 = 0;
								}
								else if (num32 == num && num37 != num && num34 != num && num35 != num)
								{
									num2 = 108 + 18 * frameNumber;
									num3 = 54;
								}
								else if (num32 != num && num37 != num && num34 != num && num35 == num)
								{
									num2 = 162;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 != num && num34 == num && num35 != num)
								{
									num2 = 216;
									num3 = 18 * frameNumber;
								}
								else if (num32 != num && num37 != num && num34 != num && num35 != num)
								{
									num2 = 162 + 18 * frameNumber;
									num3 = 54;
								}
							}
							if (num2 < 0)
							{
								num3 = 18;
								num2 = 18 + 18 * frameNumber;
							}
							ptr->frameX = (short)num2;
							ptr->frameY = (short)num3;
							if (num != 52 && num != 62 && num != 115)
							{
								goto IL_3260;
							}
							num32 = ((ptr[-1].active != 0) ? ptr[-1].type : (-1));
							if (num == 52 && (num32 == 109 || num32 == 115))
							{
								ptr->type = 115;
								SquareTileFrameNoLiquid(i, j);
							}
							else
							{
								if (num != 115 || (num32 != 2 && num32 != 52))
								{
									if (num32 != num && (num32 == -1 || (num == 52 && num32 != 2) || (num == 62 && num32 != 60) || (num == 115 && num32 != 109)))
									{
										KillTile(i, j);
									}
									goto IL_3260;
								}
								ptr->type = 52;
								SquareTileFrameNoLiquid(i, j);
							}
						}
					}
					goto end_IL_003c;
					IL_3260:
					if (!gen && Main.netMode != 1 && (num == 53 || num == 112 || num == 116 || num == 123))
					{
						Tile* ptr3 = ptr + 1;
						if (ptr3->active == 0)
						{
							ptr3 = ptr - 1;
							if (ptr3->active == 0 || ptr3->type != 21)
							{
								ptr->active = 0;
								sandBuffer[currentSandBuffer].Add(i, j);
							}
						}
					}
					end_IL_003c:;
				}
			}
		}

		public static void UpdateMagmaLayerPos()
		{
			int num = Main.maxTilesY - 230;
			Main.magmaLayerPixels = (Main.magmaLayer = Main.worldSurface + (num - Main.worldSurface) / 6 * 6 - 5) << 4;
		}
	}
}
