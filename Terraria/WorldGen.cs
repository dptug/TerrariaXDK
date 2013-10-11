// Type: Terraria.WorldGen
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

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
    public static byte tEvil = (byte) 0;
    public static byte tGood = (byte) 0;
    public static int totalX = 0;
    public static int totalD = 0;
    private static int currentSandBuffer = 0;
    private static WorldGen.FallingSandBuffer[] sandBuffer = new WorldGen.FallingSandBuffer[2];
    public static volatile bool hardLock = false;
    public static volatile bool saveLock = false;
    private static object padlock = new object();
    public static uint woodSpawned = 0U;
    public static int shadowOrbCount = 0;
    public static int altarCount = 0;
    public static bool spawnEye = false;
    public static bool gen = false;
    public static bool shadowOrbSmashed = false;
    public static bool spawnMeteor = false;
    private static short lastMaxTilesX = (short) 0;
    private static short lastMaxTilesY = (short) 0;
    public static Time tempTime = new Time();
    private static bool stopDrops = false;
    private static bool mudWall = false;
    private static int grassSpread = 0;
    public static bool noLiquidCheck = false;
    public static bool destroyObject = false;
    public static FastRandom genRand = new FastRandom();
    public static int spawnDelay = 0;
    public static int spawnNPC = 0;
    public static Location[] room = new Location[1900];
    public static bool[] houseTile = new bool[150];
    public static int bestX = 0;
    public static int bestY = 0;
    public static int hiScore = 0;
    public static Vector2i lastDungeonHall = new Vector2i();
    public static int numDRooms = 0;
    private static WorldGen.DRoom[] dRoom = new WorldGen.DRoom[100];
    private static WorldGen.DDoor[] dDoor = new WorldGen.DDoor[300];
    private static Location[] DPlat = new Location[300];
    private static int numJChests = 0;
    private static Location[] JChest = new Location[10];
    public static int dEnteranceX = 0;
    public static bool dSurface = false;
    private static int numIslandHouses = 0;
    private static int houseCount = 0;
    private static Location[] fih = new Location[300];
    private static int numMCaves = 0;
    private static Location[] mCave = new Location[300];
    private static int JungleX = 0;
    private static int hellChest = 0;
    private static bool tileFrameRecursion = true;
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
    public static int lavaLine;
    public static int waterLine;
    public static int numRoomTiles;
    public static int roomX1;
    public static int roomX2;
    public static int roomY1;
    public static int roomY2;
    public static bool canSpawn;
    public static int dungeonX;
    public static int dungeonY;
    private static int numDDoors;
    private static int numDPlats;
    private static double dxStrength1;
    private static double dyStrength1;
    private static double dxStrength2;
    private static double dyStrength2;
    private static int dMinX;
    private static int dMaxX;
    private static int dMinY;
    private static int dMaxY;
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
    private static bool mergeUp2;
    private static bool mergeDown2;
    private static bool mergeLeft2;
    private static bool mergeRight2;

    static WorldGen()
    {
    }

    public static unsafe void UpdateSand()
    {
      WorldGen.FallingSandBuffer fallingSandBuffer = WorldGen.sandBuffer[WorldGen.currentSandBuffer];
      int num = fallingSandBuffer.count;
      if (num <= 0)
        return;
      fallingSandBuffer.count = 0;
      WorldGen.currentSandBuffer ^= 1;
      int index1 = 0;
      do
      {
        int index2 = (int) fallingSandBuffer.buffer[index1].X;
        int index3 = (int) fallingSandBuffer.buffer[index1].Y;
        fixed (Tile* tilePtr = &Main.tile[index2, index3])
        {
          tilePtr->active = (byte) 0;
          int Type;
          switch (tilePtr->type)
          {
            case (byte) 112:
              Type = 56;
              break;
            case (byte) 116:
              Type = 67;
              break;
            case (byte) 123:
              Type = 71;
              break;
            default:
              Type = 31;
              break;
          }
          int index4 = Projectile.NewProjectile((float) (index2 * 16 + 8), (float) (index3 * 16 + 8), 0.0f, 2.5f, Type, 10, 0.0f, 8, true);
          if (index4 < 0)
            break;
          Main.projectile[index4].velocity.Y = 0.5f;
          Main.projectile[index4].position.Y += 2f;
          Main.projectile[index4].aabb.Y += 2;
          WorldGen.tileFrameRecursion = false;
          WorldGen.TileFrame(index2, index3 - 1, 0);
          WorldGen.TileFrame(index2 - 1, index3, 0);
          WorldGen.TileFrame(index2 + 1, index3, 0);
          WorldGen.tileFrameRecursion = true;
          NetMessage.SendTile(index2, index3);
        }
      }
      while (++index1 < num);
    }

    public static bool MoveNPC(int x, int y, int n)
    {
      if (!WorldGen.StartRoomCheck(x, y))
      {
        Main.NewText(Lang.inter[40], (int) byte.MaxValue, 240, 20);
        return false;
      }
      else if (!WorldGen.RoomNeeds())
      {
        if (Lang.lang <= 1)
        {
          int index1 = 0;
          string[] strArray = new string[4];
          if (!WorldGen.roomTorch)
          {
            strArray[index1] = "a light source";
            ++index1;
          }
          if (!WorldGen.roomDoor)
          {
            strArray[index1] = "a door";
            ++index1;
          }
          if (!WorldGen.roomTable)
          {
            strArray[index1] = "a table";
            ++index1;
          }
          if (!WorldGen.roomChair)
          {
            strArray[index1] = "a chair";
            ++index1;
          }
          string str = "";
          for (int index2 = 0; index2 < index1; ++index2)
          {
            if (index1 == 2 && index2 == 1)
              str = str + " and ";
            else if (index2 > 0 && index2 != index1 - 1)
              str = str + ", and ";
            else if (index2 > 0)
              str = str + ", ";
            str = str + strArray[index2];
          }
          Main.NewText("This housing is missing " + str + ".", (int) byte.MaxValue, 240, 20);
        }
        else
          Main.NewText(Lang.inter[8], (int) byte.MaxValue, 240, 20);
        return false;
      }
      else
      {
        WorldGen.ScoreRoom(-1);
        if (WorldGen.hiScore > 0)
          return true;
        if (WorldGen.roomOccupied)
          Main.NewText(Lang.inter[41], (int) byte.MaxValue, 240, 20);
        else if (WorldGen.roomEvil)
          Main.NewText(Lang.inter[42], (int) byte.MaxValue, 240, 20);
        else
          Main.NewText(Lang.inter[8], (int) byte.MaxValue, 240, 20);
        return false;
      }
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
        WorldGen.spawnNPC = (int) Main.npc[n].type;
        Main.npc[n].homeless = true;
        WorldGen.SpawnNPC(x, y);
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
        Main.npc[n].homeless = true;
    }

    public static void SpawnNPC(int x, int y)
    {
      if (Main.wallHouse[(int) Main.tile[x, y].wall])
        WorldGen.canSpawn = true;
      else if (!WorldGen.canSpawn)
        return;
      if (!WorldGen.StartRoomCheck(x, y) || !WorldGen.RoomNeeds())
        return;
      WorldGen.ScoreRoom(-1);
      if (WorldGen.hiScore <= 0)
        return;
      int index1 = -1;
      for (int index2 = 0; index2 < 196; ++index2)
      {
        if ((int) Main.npc[index2].active != 0 && Main.npc[index2].homeless && (int) Main.npc[index2].type == WorldGen.spawnNPC)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 < 0)
      {
        int index2 = WorldGen.bestX;
        int index3 = WorldGen.bestY;
        bool flag = false;
        if (!flag)
        {
          flag = true;
          Rectangle rectangle = new Rectangle(index2 * 16 + 8 - 960 - 62, index3 * 16 + 8 - 540 - 34, 2044, 1148);
          for (int index4 = 0; index4 < 8; ++index4)
          {
            if ((int) Main.player[index4].active != 0 && Main.player[index4].aabb.Intersects(rectangle))
            {
              flag = false;
              break;
            }
          }
        }
        if (!flag && index3 <= Main.worldSurface)
        {
          for (int index4 = 1; index4 < 500; ++index4)
          {
            for (int index5 = 0; index5 < 2; ++index5)
            {
              index2 = index5 != 0 ? WorldGen.bestX - index4 : WorldGen.bestX + index4;
              if (index2 > 10 && index2 < (int) Main.maxTilesX - 10)
              {
                int num1 = WorldGen.bestY - index4;
                double num2 = (double) (WorldGen.bestY + index4);
                if (num1 < 10)
                  num1 = 10;
                if (num2 > (double) Main.worldSurface)
                  num2 = (double) Main.worldSurface;
                for (int index6 = num1; (double) index6 < num2; ++index6)
                {
                  index3 = index6;
                  if ((int) Main.tile[index2, index3].active != 0 && Main.tileSolid[(int) Main.tile[index2, index3].type])
                  {
                    if (!Collision.SolidTiles(index2 - 1, index2 + 1, index3 - 3, index3 - 1))
                    {
                      flag = true;
                      Rectangle rectangle = new Rectangle(index2 * 16 + 8 - 960 - 62, index3 * 16 + 8 - 540 - 34, 2044, 1148);
                      for (int index7 = 0; index7 < 8; ++index7)
                      {
                        if ((int) Main.player[index7].active != 0 && Main.player[index7].aabb.Intersects(rectangle))
                        {
                          flag = false;
                          break;
                        }
                      }
                      break;
                    }
                    else
                      break;
                  }
                }
              }
              if (flag)
                break;
            }
            if (flag)
              break;
          }
        }
        int index8 = NPC.NewNPC(index2 * 16, index3 * 16, WorldGen.spawnNPC, 1);
        Main.npc[index8].homeTileX = (short) WorldGen.bestX;
        Main.npc[index8].homeTileY = (short) WorldGen.bestY;
        if (index2 < WorldGen.bestX)
          Main.npc[index8].direction = (sbyte) 1;
        else if (index2 > WorldGen.bestX)
          Main.npc[index8].direction = (sbyte) -1;
        Main.npc[index8].netUpdate = true;
        string prefix;
        if (Main.npc[index8].hasName())
        {
          prefix = Main.npc[index8].getName();
          if (Lang.lang <= 1)
            prefix = prefix + " the " + Main.npc[index8].name;
        }
        else
          prefix = Main.npc[index8].displayName;
        NetMessage.SendText(prefix, 18, 50, 125, (int) byte.MaxValue, -1);
      }
      else
      {
        Main.npc[index1].homeTileX = (short) WorldGen.bestX;
        Main.npc[index1].homeTileY = (short) WorldGen.bestY;
        Main.npc[index1].homeless = false;
      }
      if (!Main.IsTutorial())
      {
        if (WorldGen.spawnNPC == 22)
          UI.SetTriggerStateForAll(Trigger.HouseGuide);
        WorldGen.CheckHousedNPCs();
      }
      WorldGen.spawnNPC = 0;
    }

    public static void CheckHousedNPCs()
    {
      bool flag = true;
      int num = 0;
      for (int index = 0; index < 196; ++index)
      {
        NPC npc = Main.npc[index];
        if ((int) npc.active != 0 && npc.townNPC && ((int) npc.type != 37 && (int) npc.type != 142))
        {
          flag = flag && !npc.homeless;
          ++num;
        }
      }
      if (!flag || num != 10)
        return;
      UI.SetTriggerStateForAll(Trigger.HousedAllNPCs);
    }

    public static bool RoomNeeds()
    {
      WorldGen.roomChair = false;
      WorldGen.roomDoor = false;
      WorldGen.roomTable = false;
      WorldGen.roomTorch = false;
      if (WorldGen.houseTile[15] || WorldGen.houseTile[79] || (WorldGen.houseTile[89] || WorldGen.houseTile[102]))
        WorldGen.roomChair = true;
      if (WorldGen.houseTile[14] || WorldGen.houseTile[18] || (WorldGen.houseTile[87] || WorldGen.houseTile[88]) || (WorldGen.houseTile[90] || WorldGen.houseTile[101]))
        WorldGen.roomTable = true;
      if (WorldGen.houseTile[4] || WorldGen.houseTile[33] || (WorldGen.houseTile[34] || WorldGen.houseTile[35]) || (WorldGen.houseTile[36] || WorldGen.houseTile[42] || (WorldGen.houseTile[49] || WorldGen.houseTile[93])) || (WorldGen.houseTile[95] || WorldGen.houseTile[98] || (WorldGen.houseTile[100] || WorldGen.houseTile[149])))
        WorldGen.roomTorch = true;
      if (WorldGen.houseTile[10] || WorldGen.houseTile[11] || WorldGen.houseTile[19])
        WorldGen.roomDoor = true;
      WorldGen.canSpawn = WorldGen.roomChair && WorldGen.roomTable && (WorldGen.roomDoor && WorldGen.roomTorch);
      return WorldGen.canSpawn;
    }

    public static void QuickFindHome(int npc)
    {
      if ((int) Main.npc[npc].homeTileX <= 10 || (int) Main.npc[npc].homeTileY <= 10 || ((int) Main.npc[npc].homeTileX >= (int) Main.maxTilesX - 10 || (int) Main.npc[npc].homeTileY >= (int) Main.maxTilesY))
        return;
      WorldGen.canSpawn = false;
      WorldGen.StartRoomCheck((int) Main.npc[npc].homeTileX, (int) Main.npc[npc].homeTileY - 1);
      if (!WorldGen.canSpawn)
      {
        for (int x = (int) Main.npc[npc].homeTileX - 1; x < (int) Main.npc[npc].homeTileX + 2; ++x)
        {
          int y = (int) Main.npc[npc].homeTileY - 1;
          while (y < (int) Main.npc[npc].homeTileY + 2 && !WorldGen.StartRoomCheck(x, y))
            ++y;
        }
      }
      if (!WorldGen.canSpawn)
      {
        int num = 10;
        int x = (int) Main.npc[npc].homeTileX - num;
        while (x <= (int) Main.npc[npc].homeTileX + num)
        {
          int y = (int) Main.npc[npc].homeTileY - num;
          while (y <= (int) Main.npc[npc].homeTileY + num && !WorldGen.StartRoomCheck(x, y))
            y += 2;
          x += 2;
        }
      }
      if (WorldGen.canSpawn)
      {
        WorldGen.RoomNeeds();
        if (WorldGen.canSpawn)
          WorldGen.ScoreRoom(npc);
        if (WorldGen.canSpawn && WorldGen.hiScore > 0)
        {
          Main.npc[npc].homeTileX = (short) WorldGen.bestX;
          Main.npc[npc].homeTileY = (short) WorldGen.bestY;
          Main.npc[npc].homeless = false;
          WorldGen.canSpawn = false;
        }
        else
          Main.npc[npc].homeless = true;
      }
      else
        Main.npc[npc].homeless = true;
    }

    public static void ScoreRoom(int ignoreNPC = -1)
    {
      WorldGen.roomOccupied = false;
      WorldGen.roomEvil = false;
      for (int index1 = 0; index1 < 196; ++index1)
      {
        if ((int) Main.npc[index1].active != 0 && Main.npc[index1].townNPC && (ignoreNPC != index1 && !Main.npc[index1].homeless))
        {
          for (int index2 = 0; index2 < WorldGen.numRoomTiles; ++index2)
          {
            if ((int) Main.npc[index1].homeTileX == (int) WorldGen.room[index2].X && (int) Main.npc[index1].homeTileY == (int) WorldGen.room[index2].Y)
            {
              bool flag = false;
              for (int index3 = 0; index3 < WorldGen.numRoomTiles; ++index3)
              {
                if ((int) Main.npc[index1].homeTileX == (int) WorldGen.room[index3].X && (int) Main.npc[index1].homeTileY - 1 == (int) WorldGen.room[index3].Y)
                {
                  flag = true;
                  break;
                }
              }
              if (flag)
              {
                WorldGen.roomOccupied = true;
                WorldGen.hiScore = -1;
                return;
              }
            }
          }
        }
      }
      WorldGen.hiScore = 0;
      int num1 = 0;
      int num2 = WorldGen.roomX1 - 3 - 1 - 34;
      int num3 = WorldGen.roomX2 + 3 + 1 + 34;
      int num4 = WorldGen.roomY1 - 2 - 1 - 34;
      int num5 = WorldGen.roomY2 + 2 + 1 + 34;
      if (num2 < 0)
        num2 = 0;
      if (num3 >= (int) Main.maxTilesX)
        num3 = (int) Main.maxTilesX - 1;
      if (num4 < 0)
        num4 = 0;
      if (num5 > (int) Main.maxTilesX)
        num5 = (int) Main.maxTilesX;
      for (int index1 = num2 + 1; index1 < num3; ++index1)
      {
        for (int index2 = num4 + 2; index2 < num5 + 2; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0)
          {
            if ((int) Main.tile[index1, index2].type == 23 || (int) Main.tile[index1, index2].type == 24 || ((int) Main.tile[index1, index2].type == 25 || (int) Main.tile[index1, index2].type == 32) || (int) Main.tile[index1, index2].type == 112)
              ++num1;
            else if ((int) Main.tile[index1, index2].type == 27)
              num1 -= 5;
            else if ((int) Main.tile[index1, index2].type == 109 || (int) Main.tile[index1, index2].type == 110 || ((int) Main.tile[index1, index2].type == 113 || (int) Main.tile[index1, index2].type == 116))
              --num1;
          }
        }
      }
      if (num1 < 50)
        num1 = 0;
      int num6 = -num1;
      if (num6 <= -250)
      {
        WorldGen.hiScore = num6;
        WorldGen.roomEvil = true;
      }
      else
      {
        int num7 = WorldGen.roomX1;
        int num8 = WorldGen.roomX2;
        int num9 = WorldGen.roomY1;
        int num10 = WorldGen.roomY2;
        for (int index1 = num7 + 1; index1 < num8; ++index1)
        {
          for (int index2 = num9 + 2; index2 < num10 + 2; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0)
            {
              int num11 = num6;
              if (Main.tileSolidNotSolidTop[(int) Main.tile[index1, index2].type] && !Collision.SolidTiles(index1 - 1, index1 + 1, index2 - 3, index2 - 1) && ((int) Main.tile[index1 - 1, index2].active != 0 && Main.tileSolid[(int) Main.tile[index1 - 1, index2].type]) && ((int) Main.tile[index1 + 1, index2].active != 0 && Main.tileSolid[(int) Main.tile[index1 + 1, index2].type]))
              {
                for (int index3 = index1 - 2; index3 < index1 + 3; ++index3)
                {
                  for (int index4 = index2 - 4; index4 < index2; ++index4)
                  {
                    if ((int) Main.tile[index3, index4].active != 0)
                    {
                      if (index3 == index1)
                        num11 -= 15;
                      else if ((int) Main.tile[index3, index4].type == 10 || (int) Main.tile[index3, index4].type == 11)
                        num11 -= 20;
                      else if (Main.tileSolid[(int) Main.tile[index3, index4].type])
                        num11 -= 5;
                      else
                        num11 += 5;
                    }
                  }
                }
                if (num11 > WorldGen.hiScore)
                {
                  bool flag = false;
                  for (int index3 = 0; index3 < WorldGen.numRoomTiles; ++index3)
                  {
                    if ((int) WorldGen.room[index3].X == index1 && (int) WorldGen.room[index3].Y == index2)
                    {
                      flag = true;
                      break;
                    }
                  }
                  if (flag)
                  {
                    WorldGen.hiScore = num11;
                    WorldGen.bestX = index1;
                    WorldGen.bestY = index2;
                  }
                }
              }
            }
          }
        }
      }
    }

    public static bool StartRoomCheck(int x, int y)
    {
      WorldGen.roomX1 = x;
      WorldGen.roomX2 = x;
      WorldGen.roomY1 = y;
      WorldGen.roomY2 = y;
      WorldGen.numRoomTiles = 0;
      for (int index = 0; index < 150; ++index)
        WorldGen.houseTile[index] = false;
      WorldGen.canSpawn = true;
      if ((int) Main.tile[x, y].active != 0 && Main.tileSolid[(int) Main.tile[x, y].type])
      {
        WorldGen.canSpawn = false;
      }
      else
      {
        WorldGen.checkRoomDepth = 0;
        WorldGen.CheckRoom(x, y);
        if (WorldGen.numRoomTiles < 60)
          WorldGen.canSpawn = false;
      }
      return WorldGen.canSpawn;
    }

    public static void CheckRoom(int x, int y)
    {
      if (x < 10 || y < 10 || (x >= (int) Main.maxTilesX - 10 || y >= (int) WorldGen.lastMaxTilesY - 10))
      {
        WorldGen.canSpawn = false;
      }
      else
      {
        for (int index = 0; index < WorldGen.numRoomTiles; ++index)
        {
          if ((int) WorldGen.room[index].X == x && (int) WorldGen.room[index].Y == y)
            return;
        }
        WorldGen.room[WorldGen.numRoomTiles].X = (short) x;
        WorldGen.room[WorldGen.numRoomTiles].Y = (short) y;
        if (++WorldGen.numRoomTiles >= 1900)
          WorldGen.canSpawn = false;
        else if (++WorldGen.checkRoomDepth >= 400)
        {
          WorldGen.canSpawn = false;
        }
        else
        {
          if ((int) Main.tile[x, y].active != 0)
          {
            WorldGen.houseTile[(int) Main.tile[x, y].type] = true;
            if (Main.tileSolid[(int) Main.tile[x, y].type] || (int) Main.tile[x, y].type == 11)
            {
              --WorldGen.checkRoomDepth;
              return;
            }
          }
          if (x < WorldGen.roomX1)
            WorldGen.roomX1 = x;
          if (x > WorldGen.roomX2)
            WorldGen.roomX2 = x;
          if (y < WorldGen.roomY1)
            WorldGen.roomY1 = y;
          if (y > WorldGen.roomY2)
            WorldGen.roomY2 = y;
          int num = 0;
          for (int index = -2; index < 3; ++index)
          {
            if (Main.wallHouse[(int) Main.tile[x + index, y].wall])
              num |= 1;
            else if ((int) Main.tile[x + index, y].active != 0 && (Main.tileSolid[(int) Main.tile[x + index, y].type] || (int) Main.tile[x + index, y].type == 11))
              num |= 1;
            if (Main.wallHouse[(int) Main.tile[x, y + index].wall])
              num |= 2;
            else if ((int) Main.tile[x, y + index].active != 0 && (Main.tileSolid[(int) Main.tile[x, y + index].type] || (int) Main.tile[x, y + index].type == 11))
              num |= 2;
          }
          if (num != 3)
          {
            WorldGen.canSpawn = false;
          }
          else
          {
            WorldGen.CheckRoom(x, y - 1);
            if (!WorldGen.canSpawn)
              return;
            WorldGen.CheckRoom(x, y + 1);
            if (!WorldGen.canSpawn)
              return;
            WorldGen.CheckRoom(x - 1, y - 1);
            if (!WorldGen.canSpawn)
              return;
            WorldGen.CheckRoom(x - 1, y);
            if (!WorldGen.canSpawn)
              return;
            WorldGen.CheckRoom(x - 1, y + 1);
            if (!WorldGen.canSpawn)
              return;
            WorldGen.CheckRoom(x + 1, y - 1);
            if (!WorldGen.canSpawn)
              return;
            WorldGen.CheckRoom(x + 1, y);
            if (!WorldGen.canSpawn)
              return;
            WorldGen.CheckRoom(x + 1, y + 1);
            --WorldGen.checkRoomDepth;
          }
        }
      }
    }

    public static bool StartSpaceCheck(int x, int y)
    {
      WorldGen.roomX1 = x;
      WorldGen.roomX2 = x;
      WorldGen.roomY1 = y;
      WorldGen.roomY2 = y;
      WorldGen.numRoomTiles = 0;
      for (int index = 0; index < 150; ++index)
        WorldGen.houseTile[index] = false;
      WorldGen.canSpawn = true;
      if ((int) Main.tile[x, y].active != 0 && Main.tileSolid[(int) Main.tile[x, y].type])
      {
        WorldGen.canSpawn = false;
      }
      else
      {
        WorldGen.checkRoomDepth = 0;
        WorldGen.CheckSpace(x, y);
        if (WorldGen.numRoomTiles < 60)
          WorldGen.canSpawn = false;
      }
      return WorldGen.canSpawn;
    }

    public static void CheckSpace(int x, int y)
    {
      if (x < 10 || y < 10 || (x >= (int) Main.maxTilesX - 10 || y >= (int) WorldGen.lastMaxTilesY - 10))
      {
        WorldGen.canSpawn = false;
      }
      else
      {
        for (int index = 0; index < WorldGen.numRoomTiles; ++index)
        {
          if ((int) WorldGen.room[index].X == x && (int) WorldGen.room[index].Y == y)
            return;
        }
        WorldGen.room[WorldGen.numRoomTiles].X = (short) x;
        WorldGen.room[WorldGen.numRoomTiles].Y = (short) y;
        if (++WorldGen.numRoomTiles >= 1900)
          WorldGen.canSpawn = false;
        else if (++WorldGen.checkRoomDepth >= 400)
        {
          WorldGen.canSpawn = false;
        }
        else
        {
          if ((int) Main.tile[x, y].active != 0)
          {
            WorldGen.houseTile[(int) Main.tile[x, y].type] = true;
            if (Main.tileSolid[(int) Main.tile[x, y].type] || (int) Main.tile[x, y].type == 11)
            {
              --WorldGen.checkRoomDepth;
              return;
            }
          }
          if (x < WorldGen.roomX1)
            WorldGen.roomX1 = x;
          if (x > WorldGen.roomX2)
            WorldGen.roomX2 = x;
          if (y < WorldGen.roomY1)
            WorldGen.roomY1 = y;
          if (y > WorldGen.roomY2)
            WorldGen.roomY2 = y;
          WorldGen.CheckSpace(x, y - 1);
          if (!WorldGen.canSpawn)
            return;
          WorldGen.CheckSpace(x, y + 1);
          if (!WorldGen.canSpawn)
            return;
          WorldGen.CheckSpace(x - 1, y - 1);
          if (!WorldGen.canSpawn)
            return;
          WorldGen.CheckSpace(x - 1, y);
          if (!WorldGen.canSpawn)
            return;
          WorldGen.CheckSpace(x - 1, y + 1);
          if (!WorldGen.canSpawn)
            return;
          WorldGen.CheckSpace(x + 1, y - 1);
          if (!WorldGen.canSpawn)
            return;
          WorldGen.CheckSpace(x + 1, y);
          if (!WorldGen.canSpawn)
            return;
          WorldGen.CheckSpace(x + 1, y + 1);
          --WorldGen.checkRoomDepth;
        }
      }
    }

    public static void dropMeteor()
    {
      bool flag = true;
      int num1 = 0;
      if (Main.netMode == 1)
        return;
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0)
        {
          flag = false;
          break;
        }
      }
      int num2 = 0;
      int num3 = (int) (400.0 * (double) ((float) Main.maxTilesX * 0.0002380952f));
      for (int index1 = 5; index1 < (int) Main.maxTilesX - 5; ++index1)
      {
        for (int index2 = 5; index2 < Main.worldSurface; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type == 37)
          {
            ++num2;
            if (num2 > num3)
              return;
          }
        }
      }
      while (!flag)
      {
        float num4 = (float) Main.maxTilesX * 0.08f;
        int i = Main.rand.Next(50, (int) Main.maxTilesX - 50);
        while ((double) i > (double) Main.spawnTileX - (double) num4 && (double) i < (double) Main.spawnTileX + (double) num4)
          i = Main.rand.Next(50, (int) Main.maxTilesX - 50);
        for (int j = Main.rand.Next(100); j < (int) Main.maxTilesY; ++j)
        {
          if ((int) Main.tile[i, j].active != 0 && Main.tileSolid[(int) Main.tile[i, j].type])
          {
            flag = WorldGen.meteor(i, j);
            break;
          }
        }
        ++num1;
        if (num1 >= 100)
          break;
      }
    }

    public static bool meteor(int i, int j)
    {
      if (i < 50 || i > (int) Main.maxTilesX - 50 || (j < 50 || j > (int) Main.maxTilesY - 50))
        return false;
      Rectangle rectangle1 = new Rectangle((i - 25) * 16, (j - 25) * 16, 800, 800);
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0)
        {
          Rectangle rectangle2 = new Rectangle(Main.player[index].aabb.X + 10 - 960 - 62, Main.player[index].aabb.Y + 21 - 540 - 34, 2044, 1148);
          if (rectangle1.Intersects(rectangle2))
            return false;
        }
      }
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.npc[index].active != 0 && rectangle1.Intersects(Main.npc[index].aabb))
          return false;
      }
      for (int index1 = i - 25; index1 < i + 25; ++index1)
      {
        for (int index2 = j - 25; index2 < j + 25; ++index2)
        {
          if ((int) Main.tile[index1, index2].type == 21 && (int) Main.tile[index1, index2].active != 0)
            return false;
        }
      }
      WorldGen.stopDrops = true;
      for (int index1 = i - 15; index1 < i + 15; ++index1)
      {
        for (int index2 = j - 15; index2 < j + 15; ++index2)
        {
          if (index2 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - index1) + Math.Abs(j - index2) < 22 + Main.rand.Next(-5, 5))
          {
            if (!Main.tileSolid[(int) Main.tile[index1, index2].type])
              Main.tile[index1, index2].active = (byte) 0;
            Main.tile[index1, index2].type = (byte) 37;
          }
        }
      }
      for (int index1 = i - 10; index1 < i + 10; ++index1)
      {
        for (int index2 = j - 10; index2 < j + 10; ++index2)
        {
          if (index2 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - index1) + Math.Abs(j - index2) < 10 + Main.rand.Next(-3, 4))
            Main.tile[index1, index2].active = (byte) 0;
        }
      }
      for (int i1 = i - 16; i1 < i + 16; ++i1)
      {
        for (int j1 = j - 16; j1 < j + 16; ++j1)
        {
          switch (Main.tile[i1, j1].type)
          {
            case (byte) 5:
            case (byte) 32:
              WorldGen.KillTile(i1, j1);
              break;
          }
          WorldGen.SquareTileFrame(i1, j1, -1);
          WorldGen.SquareWallFrame(i1, j1, true);
        }
      }
      for (int i1 = i - 23; i1 < i + 23; ++i1)
      {
        for (int j1 = j - 23; j1 < j + 23; ++j1)
        {
          if ((int) Main.tile[i1, j1].active != 0 && Main.rand.Next(10) == 0 && (double) (Math.Abs(i - i1) + Math.Abs(j - j1)) < 29.8999996185303)
          {
            if ((int) Main.tile[i1, j1].type == 5 || (int) Main.tile[i1, j1].type == 32)
              WorldGen.KillTile(i1, j1);
            Main.tile[i1, j1].type = (byte) 37;
            WorldGen.SquareTileFrame(i1, j1, -1);
          }
        }
      }
      WorldGen.stopDrops = false;
      NetMessage.SendText(36, 50, (int) byte.MaxValue, 130, -1);
      NetMessage.SendTileSquare(i, j, 30);
      return true;
    }

    public static void setWorldSize()
    {
      Main.bottomWorld = (int) Main.maxTilesY * 16;
      Main.rightWorld = (int) Main.maxTilesX * 16;
      Main.maxSectionsX = (int) Main.maxTilesX / 40;
      Main.maxSectionsY = (int) Main.maxTilesY / 30;
    }

    public static void worldGenCallBack()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        5
      });
      WorldGen.clearWorld();
      WorldGen.generateWorld(-1);
      WorldGen.everyTileFrame();
      WorldGen.saveWorldWhilePlaying();
      Main.StartGame();
      Main.worldGenThread = (Thread) null;
    }

    public static void CreateNewWorld()
    {
      Netplay.StopFindingSessions();
      Thread thread = new Thread(new ThreadStart(WorldGen.worldGenCallBack));
      thread.IsBackground = true;
      thread.Start();
      Main.worldGenThread = thread;
    }

    public static void SaveAndQuit()
    {
      Main.PlaySound(11);
      new Thread(new ThreadStart(WorldGen.SaveAndQuitCallBack)).Start();
    }

    public static void SaveAndQuitCallBack()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        4
      });
      Main.isGameStarted = false;
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.isStopping)
        {
          ui.player.active = (byte) 0;
          ui.player.Save(ui.playerPathName);
          ui.SaveSettings();
        }
      }
      int num = Main.netMode;
      Netplay.disconnect = true;
      if (num != 1 && UI.main.HasPlayerStorage())
      {
        for (int index = 0; index < 4; ++index)
        {
          UI ui = Main.ui[index];
          if (ui.isStopping)
            ui.statusText = Lang.gen[49];
        }
        WorldGen.saveNewWorld();
      }
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.isStopping)
        {
          ui.isStopping = false;
          if (ui.signedInGamer != null)
          {
            ui.LoadPlayers();
            if (ui.menuMode != MenuMode.ERROR)
              ui.SetMenu(MenuMode.TITLE, false, true);
          }
        }
      }
    }

    public static void playWorldCallBack()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        5
      });
      if (Main.IsTutorial())
      {
        using (Stream file = TitleContainer.OpenStream("Content/Worlds/tutorial.wld"))
          WorldGen.loadWorld(file);
        WorldGen.tempTime.reset(0.01f);
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
            using (Stream file = storageContainer.OpenFile(WorldSelect.worldPathName, FileMode.Open))
              flag = WorldGen.loadWorld(file);
          }
        }
        catch (ThreadAbortException ex)
        {
          flag = true;
        }
        catch (IOException ex)
        {
          UI.main.ReadError();
          flag = false;
        }
        catch (Exception ex)
        {
          flag = false;
        }
        if (!flag)
        {
          UI.main.SetMenu(MenuMode.LOAD_FAILED_NO_BACKUP, false, false);
          Main.worldGenThread = (Thread) null;
          return;
        }
      }
      WorldGen.everyTileFrame();
      Main.StartGame();
      Main.worldGenThread = (Thread) null;
    }

    public static void playWorld()
    {
      Netplay.StopFindingSessions();
      Thread thread = new Thread(new ThreadStart(WorldGen.playWorldCallBack));
      thread.Start();
      Main.worldGenThread = thread;
    }

    public static void saveWorldWhilePlayingCallBack()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        4
      });
      WorldGen.saveNewWorld();
    }

    public static void saveWorldWhilePlaying()
    {
      if (!UI.main.HasPlayerStorage())
        return;
      new Thread(new ThreadStart(WorldGen.saveWorldWhilePlayingCallBack)).Start();
    }

    public static void savePlayerWhilePlayingCallBack()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        4
      });
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.menuType != MenuType.MAIN)
        {
          ui.player.Save(ui.playerPathName);
          ui.SaveSettings();
        }
      }
    }

    public static void savePlayerWhilePlaying()
    {
      new Thread(new ThreadStart(WorldGen.savePlayerWhilePlayingCallBack)).Start();
    }

    public static void saveAllWhilePlayingCallBack()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        4
      });
      if (Main.netMode != 1 && UI.main.HasPlayerStorage())
        WorldGen.saveNewWorld();
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.menuType != MenuType.MAIN)
        {
          ui.player.Save(ui.playerPathName);
          ui.SaveSettings();
        }
      }
    }

    public static void saveAllWhilePlaying()
    {
      new Thread(new ThreadStart(WorldGen.saveAllWhilePlayingCallBack)).Start();
    }

    public static void clearWorld()
    {
      UI.main.statusText = Lang.gen[47];
      WorldGen.tempTime.reset(1f);
      WorldGen.totalSolid2 = 0;
      WorldGen.totalGood2 = 0;
      WorldGen.totalEvil2 = 0;
      WorldGen.totalSolid = 0;
      WorldGen.totalGood = 0;
      WorldGen.totalEvil = 0;
      WorldGen.totalX = 0;
      WorldGen.totalD = 0;
      WorldGen.tEvil = (byte) 0;
      WorldGen.tGood = (byte) 0;
      NPC.clrNames();
      WorldGen.spawnEye = false;
      WorldGen.spawnNPC = 0;
      WorldGen.shadowOrbCount = 0;
      WorldGen.altarCount = 0;
      Main.worldID = 0;
      Main.worldTimestamp = 0;
      Main.hardMode = false;
      Main.dungeonX = (short) 0;
      Main.dungeonY = (short) 0;
      NPC.downedBoss1 = false;
      NPC.downedBoss2 = false;
      NPC.downedBoss3 = false;
      NPC.savedGoblin = false;
      NPC.savedWizard = false;
      NPC.savedMech = false;
      NPC.downedGoblins = false;
      NPC.downedClown = false;
      NPC.downedFrost = false;
      WorldGen.shadowOrbSmashed = false;
      WorldGen.spawnMeteor = false;
      WorldGen.stopDrops = false;
      Main.invasionDelay = 0;
      Main.invasionType = 0;
      Main.invasionSize = 0;
      Main.invasionWarn = 0;
      Main.invasionX = 0.0f;
      Liquid.numLiquid = 0;
      LiquidBuffer.numLiquidBuffer = 0;
      WorldGen.sandBuffer[0] = new WorldGen.FallingSandBuffer();
      WorldGen.sandBuffer[1] = new WorldGen.FallingSandBuffer();
      if ((int) WorldGen.lastMaxTilesX > (int) Main.maxTilesX)
      {
        for (int index1 = (int) Main.maxTilesX; index1 < (int) WorldGen.lastMaxTilesX; ++index1)
        {
          for (int index2 = 0; index2 < (int) WorldGen.lastMaxTilesY; ++index2)
            Main.tile[index1, index2].Clear();
        }
      }
      if ((int) WorldGen.lastMaxTilesY > (int) Main.maxTilesY)
      {
        for (int index1 = 0; index1 < (int) Main.maxTilesX; ++index1)
        {
          for (int index2 = (int) Main.maxTilesY; index2 < (int) WorldGen.lastMaxTilesY; ++index2)
            Main.tile[index1, index2].Clear();
        }
      }
      WorldGen.lastMaxTilesX = Main.maxTilesX;
      WorldGen.lastMaxTilesY = Main.maxTilesY;
      if (Main.netMode != 1)
      {
        for (int index1 = 0; index1 < (int) Main.maxTilesX; ++index1)
        {
          for (int index2 = 0; index2 < (int) Main.maxTilesY; ++index2)
            Main.tile[index1, index2].Clear();
        }
      }
      Main.dust.Init();
      for (int index = 0; index < 128; ++index)
        Main.gore[index].Init();
      for (int index = 0; index < 200; ++index)
        Main.item[index].Init();
      for (int index = 0; index < 196; ++index)
        Main.npc[index] = new NPC();
      for (int index = 0; index < 512; ++index)
        Main.projectile[index].Init();
      for (int index = 0; index < 1000; ++index)
        Main.chest[index] = (Chest) null;
      for (int index = 0; index < 1000; ++index)
        Main.sign[index].Init();
      for (int index = 0; index < 8192; ++index)
        Main.liquidBuffer[index] = new LiquidBuffer();
      WorldGen.setWorldSize();
    }

    public static bool loadWorld(Stream file)
    {
      bool flag = true;
      Time.checkXMas();
      using (MemoryStream stream = new MemoryStream((int) file.Length))
      {
        stream.SetLength(file.Length);
        file.Read(stream.GetBuffer(), 0, (int) file.Length);
        file.Close();
        using (BinaryReader fileIO = new BinaryReader((Stream) stream))
        {
          try
          {
            int release = fileIO.ReadInt32();
            if (release > 49)
              throw new InvalidOperationException("Invalid version");
            if (release <= 46)
              WorldGen.loadOldWorld(fileIO, release);
            else
              WorldGen.loadNewWorld(fileIO, release, stream);
            WorldGen.gen = true;
            UI.main.NextProgressStep(Lang.gen[52]);
            for (int X = 0; X < (int) Main.maxTilesX; ++X)
            {
              if ((X & 63) == 0)
                UI.main.progress = (float) X / (float) Main.maxTilesX;
              WorldGen.CountTiles(X);
            }
            NPC.setNames();
            UI.main.NextProgressStep(Lang.gen[27]);
            WorldGen.waterLine = (int) Main.maxTilesY;
            Liquid.QuickWater(0.5, 3, -1, 0.0);
            WorldGen.WaterCheck();
            int num1 = 0;
            Liquid.QuickSettleOn();
            int num2 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
            float num3 = 0.0f;
            while (Liquid.numLiquid > 0 && num1 < 512)
            {
              ++num1;
              float num4 = (float) (num2 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float) num2;
              if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num2)
                num2 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
              if ((double) num4 > (double) num3)
                num3 = num4;
              else
                num4 = num3;
              if ((double) num4 <= 0.5)
                UI.main.progress = num4 + 0.5f;
              Liquid.UpdateLiquid();
            }
            Liquid.QuickSettleOff();
            WorldGen.WaterCheck();
            WorldGen.gen = false;
          }
          catch
          {
            flag = false;
          }
        }
      }
      return flag;
    }

    private static unsafe void loadOldWorld(BinaryReader fileIO, int release)
    {
      string str1 = fileIO.ReadString();
      int num1 = fileIO.ReadInt32();
      Main.rightWorld = fileIO.ReadInt32();
      Main.rightWorld = fileIO.ReadInt32();
      Main.bottomWorld = fileIO.ReadInt32();
      Main.bottomWorld = fileIO.ReadInt32();
      Main.maxTilesY = (short) fileIO.ReadInt32();
      Main.maxTilesX = (short) fileIO.ReadInt32();
      WorldGen.clearWorld();
      Main.worldID = num1;
      UI.main.FirstProgressStep(4, Lang.gen[51]);
      Main.spawnTileX = (short) fileIO.ReadInt32();
      Main.spawnTileY = (short) fileIO.ReadInt32();
      Main.worldSurface = (int) fileIO.ReadDouble();
      Main.worldSurfacePixels = Main.worldSurface << 4;
      Main.rockLayer = (int) fileIO.ReadDouble();
      Main.rockLayerPixels = Main.rockLayer << 4;
      WorldGen.UpdateMagmaLayerPos();
      WorldGen.tempTime.dayRate = 1f;
      WorldGen.tempTime.time = (float) fileIO.ReadDouble();
      WorldGen.tempTime.dayTime = fileIO.ReadBoolean();
      WorldGen.tempTime.moonPhase = (byte) fileIO.ReadInt32();
      WorldGen.tempTime.bloodMoon = fileIO.ReadBoolean();
      Main.dungeonX = (short) fileIO.ReadInt32();
      Main.dungeonY = (short) fileIO.ReadInt32();
      NPC.downedBoss1 = fileIO.ReadBoolean();
      NPC.downedBoss2 = fileIO.ReadBoolean();
      NPC.downedBoss3 = fileIO.ReadBoolean();
      NPC.savedGoblin = fileIO.ReadBoolean();
      NPC.savedWizard = fileIO.ReadBoolean();
      NPC.savedMech = fileIO.ReadBoolean();
      NPC.downedGoblins = fileIO.ReadBoolean();
      NPC.downedClown = fileIO.ReadBoolean();
      NPC.downedFrost = fileIO.ReadBoolean();
      WorldGen.shadowOrbSmashed = fileIO.ReadBoolean();
      WorldGen.spawnMeteor = fileIO.ReadBoolean();
      WorldGen.shadowOrbCount = (int) fileIO.ReadByte();
      WorldGen.altarCount = fileIO.ReadInt32();
      Main.hardMode = fileIO.ReadBoolean();
      Main.invasionDelay = fileIO.ReadInt32();
      Main.invasionSize = fileIO.ReadInt32();
      Main.invasionType = fileIO.ReadInt32();
      Main.invasionX = (float) fileIO.ReadDouble();
      for (int index = 0; index < (int) Main.maxTilesX; ++index)
      {
        if ((index & 31) == 0)
          UI.main.progress = (float) index / (float) Main.maxTilesX;
        fixed (Tile* tilePtr1 = &Main.tile[index, 0])
        {
          Tile* tilePtr2 = tilePtr1;
          int num2 = 0;
          while (num2 < (int) Main.maxTilesY)
          {
            tilePtr2->flags = ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID);
            tilePtr2->active = fileIO.ReadByte();
            if ((int) tilePtr2->active != 0)
            {
              tilePtr2->type = fileIO.ReadByte();
              if ((int) tilePtr2->type == (int) sbyte.MaxValue)
                tilePtr2->active = (byte) 0;
              if (Main.tileFrameImportant[(int) tilePtr2->type])
              {
                tilePtr2->frameX = fileIO.ReadInt16();
                tilePtr2->frameY = fileIO.ReadInt16();
                if ((int) tilePtr2->type == 144)
                  tilePtr2->frameY = (short) 0;
              }
              else
              {
                tilePtr2->frameX = (short) -1;
                tilePtr2->frameY = (short) -1;
              }
            }
            if (fileIO.ReadBoolean())
              tilePtr2->wall = fileIO.ReadByte();
            if (fileIO.ReadBoolean())
            {
              tilePtr2->liquid = fileIO.ReadByte();
              if (fileIO.ReadBoolean())
                tilePtr2->lava = (byte) 32;
            }
            if (release < 46)
            {
              if (fileIO.ReadBoolean())
                tilePtr2->wire = 16;
            }
            else
            {
              tilePtr2->flags |= (Tile.Flags) fileIO.ReadByte();
              if (Main.IsTutorial())
                tilePtr2->flags &= Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID;
            }
            int num3 = (int) fileIO.ReadInt16();
            int num4 = num2 + num3;
            for (; num3 > 0; --num3)
            {
              tilePtr2[1] = *tilePtr2;
              ++tilePtr2;
            }
            num2 = num4 + 1;
            ++tilePtr2;
          }
        }
      }
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        if (fileIO.ReadBoolean())
        {
          Main.chest[index1] = new Chest();
          Main.chest[index1].x = (short) fileIO.ReadInt32();
          Main.chest[index1].y = (short) fileIO.ReadInt32();
          for (int index2 = 0; index2 < 20; ++index2)
          {
            byte num2 = fileIO.ReadByte();
            if ((int) num2 > 0)
            {
              Main.chest[index1].item[index2].netDefaults(fileIO.ReadInt32(), (int) num2);
              Main.chest[index1].item[index2].Prefix((int) fileIO.ReadByte());
            }
          }
        }
      }
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        if (fileIO.ReadBoolean())
        {
          string str2 = fileIO.ReadString();
          int index2 = fileIO.ReadInt32();
          int index3 = fileIO.ReadInt32();
          if ((int) Main.tile[index2, index3].active != 0 && ((int) Main.tile[index2, index3].type == 55 || (int) Main.tile[index2, index3].type == 85))
          {
            Main.sign[index1].x = (short) index2;
            Main.sign[index1].y = (short) index3;
            Main.sign[index1].text = (UserString) str2;
          }
        }
      }
      bool flag1 = fileIO.ReadBoolean();
      int index4 = 0;
      for (; flag1; flag1 = fileIO.ReadBoolean())
      {
        try
        {
          string str2 = fileIO.ReadString();
          Main.npc[index4].SetDefaults((int) Convert.ToUInt16(str2), -1.0);
          Main.npc[index4].position.X = fileIO.ReadSingle();
          Main.npc[index4].position.Y = fileIO.ReadSingle();
          Main.npc[index4].aabb.X = (int) Main.npc[index4].position.X;
          Main.npc[index4].aabb.Y = (int) Main.npc[index4].position.Y;
          Main.npc[index4].homeless = fileIO.ReadBoolean();
          Main.npc[index4].homeTileX = (short) fileIO.ReadInt32();
          Main.npc[index4].homeTileY = (short) fileIO.ReadInt32();
          ++index4;
        }
        catch (FormatException ex)
        {
          fileIO.ReadBytes(17);
        }
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
      string str3 = fileIO.ReadString();
      int num5 = fileIO.ReadInt32();
      if (!flag2 || str3 != str1 || num5 != Main.worldID)
        throw new InvalidOperationException("Invalid footer");
    }

    private static unsafe void loadNewWorld(BinaryReader fileIO, int release, MemoryStream stream)
    {
      CRC32 crC32 = new CRC32();
      crC32.Update(stream.GetBuffer(), 8, (int) stream.Length - 8);
      if ((int) crC32.GetValue() != (int) fileIO.ReadUInt32())
        throw new InvalidOperationException("Invalid CRC32");
      fileIO.ReadString();
      int num1 = fileIO.ReadInt32();
      int num2 = release >= 48 ? fileIO.ReadInt32() : 0;
      Main.rightWorld = fileIO.ReadInt32();
      Main.bottomWorld = (int) fileIO.ReadInt16();
      Main.maxTilesY = fileIO.ReadInt16();
      Main.maxTilesX = fileIO.ReadInt16();
      WorldGen.clearWorld();
      Main.worldID = num1;
      Main.worldTimestamp = num2;
      UI.main.FirstProgressStep(4, Lang.gen[51]);
      Main.spawnTileX = fileIO.ReadInt16();
      Main.spawnTileY = fileIO.ReadInt16();
      Main.worldSurface = (int) fileIO.ReadInt16();
      Main.worldSurfacePixels = Main.worldSurface << 4;
      Main.rockLayer = (int) fileIO.ReadInt16();
      Main.rockLayerPixels = Main.rockLayer << 4;
      WorldGen.UpdateMagmaLayerPos();
      WorldGen.tempTime.dayRate = 1f;
      WorldGen.tempTime.time = fileIO.ReadSingle();
      WorldGen.tempTime.dayTime = fileIO.ReadBoolean();
      WorldGen.tempTime.moonPhase = fileIO.ReadByte();
      WorldGen.tempTime.bloodMoon = fileIO.ReadBoolean();
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
      WorldGen.shadowOrbSmashed = fileIO.ReadBoolean();
      WorldGen.spawnMeteor = fileIO.ReadBoolean();
      WorldGen.shadowOrbCount = (int) fileIO.ReadByte();
      WorldGen.altarCount = fileIO.ReadInt32();
      Main.hardMode = fileIO.ReadBoolean();
      Main.invasionDelay = (int) fileIO.ReadByte();
      Main.invasionSize = (int) fileIO.ReadInt16();
      Main.invasionType = (int) fileIO.ReadByte();
      Main.invasionX = fileIO.ReadSingle();
      for (int index = 0; index < (int) Main.maxTilesX; ++index)
      {
        if ((index & 31) == 0)
          UI.main.progress = (float) index / (float) Main.maxTilesX;
        fixed (Tile* tilePtr1 = &Main.tile[index, 0])
        {
          Tile* tilePtr2 = tilePtr1;
          int num3 = 0;
          while (num3 < (int) Main.maxTilesY)
          {
            tilePtr2->flags = ~(Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.VISITED | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID);
            tilePtr2->active = fileIO.ReadByte();
            if ((int) tilePtr2->active != 0)
            {
              tilePtr2->type = fileIO.ReadByte();
              if ((int) tilePtr2->type == (int) sbyte.MaxValue)
                tilePtr2->active = (byte) 0;
              if (Main.tileFrameImportant[(int) tilePtr2->type])
              {
                tilePtr2->frameX = fileIO.ReadInt16();
                tilePtr2->frameY = fileIO.ReadInt16();
                if ((int) tilePtr2->type == 144)
                  tilePtr2->frameY = (short) 0;
              }
              else
              {
                tilePtr2->frameX = (short) -1;
                tilePtr2->frameY = (short) -1;
              }
            }
            tilePtr2->wall = fileIO.ReadByte();
            tilePtr2->liquid = fileIO.ReadByte();
            if ((int) tilePtr2->liquid > 0 && fileIO.ReadBoolean())
              tilePtr2->lava = (byte) 32;
            tilePtr2->flags |= (Tile.Flags) fileIO.ReadByte();
            if (Main.IsTutorial())
              tilePtr2->flags &= Tile.Flags.WALLFRAME_MASK | Tile.Flags.HIGHLIGHT_MASK | Tile.Flags.WIRE | Tile.Flags.CHECKING_LIQUID | Tile.Flags.SKIP_LIQUID;
            int num4 = (int) fileIO.ReadByte();
            if ((num4 & 128) != 0)
              num4 = num4 & (int) sbyte.MaxValue | (int) fileIO.ReadByte() << 7;
            int num5 = num3 + num4;
            for (; num4 > 0; --num4)
            {
              tilePtr2[1] = *tilePtr2;
              ++tilePtr2;
            }
            num3 = num5 + 1;
            ++tilePtr2;
          }
        }
      }
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        if (fileIO.ReadBoolean())
        {
          Main.chest[index1] = new Chest();
          Main.chest[index1].x = fileIO.ReadInt16();
          Main.chest[index1].y = fileIO.ReadInt16();
          for (int index2 = 0; index2 < 20; ++index2)
          {
            byte num3 = fileIO.ReadByte();
            if ((int) num3 > 0)
            {
              Main.chest[index1].item[index2].netDefaults((int) fileIO.ReadInt16(), (int) num3);
              Main.chest[index1].item[index2].Prefix((int) fileIO.ReadByte());
            }
          }
        }
      }
      for (int index = 0; index < 1000; ++index)
        Main.sign[index].Read(fileIO, release);
      bool flag = fileIO.ReadBoolean();
      int index3 = 0;
      for (; flag; flag = fileIO.ReadBoolean())
      {
        int Type = (int) fileIO.ReadByte();
        Main.npc[index3].SetDefaults(Type, -1.0);
        Main.npc[index3].position.X = fileIO.ReadSingle();
        Main.npc[index3].position.Y = fileIO.ReadSingle();
        Main.npc[index3].aabb.X = (int) Main.npc[index3].position.X;
        Main.npc[index3].aabb.Y = (int) Main.npc[index3].position.Y;
        Main.npc[index3].homeless = fileIO.ReadBoolean();
        Main.npc[index3].homeTileX = fileIO.ReadInt16();
        Main.npc[index3].homeTileY = fileIO.ReadInt16();
        ++index3;
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
      if (WorldGen.saveLock)
        return;
      WorldGen.saveLock = true;
      if (WorldGen.hardLock)
      {
        UI.main.statusText = Lang.gen[48];
        do
        {
          Thread.Sleep(16);
        }
        while (WorldGen.hardLock);
      }
      bool flag = false;
      lock (WorldGen.padlock)
      {
        UI.main.FirstProgressStep(1, Lang.gen[49]);
        using (MemoryStream resource_3 = new MemoryStream(6291456))
        {
          using (BinaryWriter resource_2 = new BinaryWriter((Stream) resource_3))
          {
            resource_2.Write(49);
            resource_2.Write(0U);
            resource_2.Write(Main.worldName);
            resource_2.Write(Main.worldID);
            resource_2.Write(Main.worldTimestamp);
            resource_2.Write(Main.rightWorld);
            resource_2.Write((short) Main.bottomWorld);
            resource_2.Write(Main.maxTilesY);
            resource_2.Write(Main.maxTilesX);
            resource_2.Write(Main.spawnTileX);
            resource_2.Write(Main.spawnTileY);
            resource_2.Write((short) Main.worldSurface);
            resource_2.Write((short) Main.rockLayer);
            resource_2.Write(WorldGen.tempTime.time);
            resource_2.Write(WorldGen.tempTime.dayTime);
            resource_2.Write(WorldGen.tempTime.moonPhase);
            resource_2.Write(WorldGen.tempTime.bloodMoon);
            resource_2.Write(Main.dungeonX);
            resource_2.Write(Main.dungeonY);
            resource_2.Write(NPC.downedBoss1);
            resource_2.Write(NPC.downedBoss2);
            resource_2.Write(NPC.downedBoss3);
            resource_2.Write(NPC.savedGoblin);
            resource_2.Write(NPC.savedWizard);
            resource_2.Write(NPC.savedMech);
            resource_2.Write(NPC.downedGoblins);
            resource_2.Write(NPC.downedClown);
            resource_2.Write(NPC.downedFrost);
            resource_2.Write(WorldGen.shadowOrbSmashed);
            resource_2.Write(WorldGen.spawnMeteor);
            resource_2.Write((byte) WorldGen.shadowOrbCount);
            resource_2.Write(WorldGen.altarCount);
            resource_2.Write(Main.hardMode);
            resource_2.Write((byte) Main.invasionDelay);
            resource_2.Write((short) Main.invasionSize);
            resource_2.Write((byte) Main.invasionType);
            resource_2.Write(Main.invasionX);
            for (int local_3 = 0; local_3 < (int) Main.maxTilesX; ++local_3)
            {
              if ((local_3 & 31) == 0)
                UI.main.progress = (float) local_3 / (float) Main.maxTilesX;
              for (int local_4 = 0; local_4 < (int) Main.maxTilesY; {
                int local_4_1;
                local_4 = local_4_1 + 1;
              }
              )
              {
                Tile local_5 = Main.tile[local_3, local_4];
                if ((int) local_5.type == (int) sbyte.MaxValue)
                  local_5.active = (byte) 0;
                if ((int) local_5.active != 0)
                {
                  resource_2.Write(true);
                  resource_2.Write(local_5.type);
                  if (Main.tileFrameImportant[(int) local_5.type])
                  {
                    resource_2.Write(local_5.frameX);
                    resource_2.Write(local_5.frameY);
                  }
                }
                else
                  resource_2.Write(false);
                resource_2.Write(local_5.wall);
                resource_2.Write(local_5.liquid);
                if ((int) local_5.liquid > 0)
                  resource_2.Write((int) local_5.lava != 0);
                resource_2.Write((byte) (local_5.flags & (Tile.Flags.VISITED | Tile.Flags.WIRE)));
                int local_6 = 1;
                while (local_4 + local_6 < (int) Main.maxTilesY && local_5.isTheSameAs(Main.tile.Address(local_3, local_4 + local_6)))
                  ++local_6;
                int local_6_1 = local_6 - 1;
                local_4_1 = local_4 + local_6_1;
                if (local_6_1 < 128)
                {
                  resource_2.Write((byte) local_6_1);
                }
                else
                {
                  int local_7 = local_6_1 & (int) sbyte.MaxValue | 128;
                  int local_6_2 = local_6_1 >> 7;
                  resource_2.Write((ushort) (local_7 | local_6_2 << 8));
                }
              }
            }
            for (int local_8 = 0; local_8 < 1000; ++local_8)
            {
              if (Main.chest[local_8] == null)
              {
                resource_2.Write(false);
              }
              else
              {
                Chest local_9 = Main.chest[local_8];
                resource_2.Write(true);
                resource_2.Write(local_9.x);
                resource_2.Write(local_9.y);
                for (int local_10 = 0; local_10 < 20; ++local_10)
                {
                  if ((int) local_9.item[local_10].type == 0)
                    local_9.item[local_10].stack = (short) 0;
                  resource_2.Write((byte) local_9.item[local_10].stack);
                  if ((int) local_9.item[local_10].stack > 0)
                  {
                    resource_2.Write(local_9.item[local_10].netID);
                    resource_2.Write(local_9.item[local_10].prefix);
                  }
                }
              }
            }
            for (int local_11 = 0; local_11 < 1000; ++local_11)
              Main.sign[local_11].Write(resource_2);
            for (int local_13 = 0; local_13 < 196; ++local_13)
            {
              NPC local_14 = Main.npc[local_13];
              if (local_14.townNPC && (int) local_14.active != 0)
              {
                NPC local_14_1 = (NPC) local_14.Clone();
                resource_2.Write(true);
                resource_2.Write(local_14_1.type);
                resource_2.Write(local_14_1.position.X);
                resource_2.Write(local_14_1.position.Y);
                resource_2.Write(local_14_1.homeless);
                resource_2.Write(local_14_1.homeTileX);
                resource_2.Write(local_14_1.homeTileY);
              }
            }
            resource_2.Write(false);
            resource_2.Write(NPC.chrName[17]);
            resource_2.Write(NPC.chrName[18]);
            resource_2.Write(NPC.chrName[19]);
            resource_2.Write(NPC.chrName[20]);
            resource_2.Write(NPC.chrName[22]);
            resource_2.Write(NPC.chrName[54]);
            resource_2.Write(NPC.chrName[38]);
            resource_2.Write(NPC.chrName[107]);
            resource_2.Write(NPC.chrName[108]);
            resource_2.Write(NPC.chrName[124]);
            CRC32 local_15 = new CRC32();
            local_15.Update(resource_3.GetBuffer(), 8, (int) resource_3.Length - 8);
            resource_2.Seek(4, SeekOrigin.Begin);
            resource_2.Write(local_15.GetValue());
            Main.ShowSaveIcon();
            try
            {
              if (UI.main.TestStorageSpace("Worlds", WorldSelect.worldPathName, (int) resource_3.Length))
              {
                using (StorageContainer resource_1 = UI.main.OpenPlayerStorage("Worlds"))
                {
                  using (Stream resource_0 = resource_1.OpenFile(WorldSelect.worldPathName, FileMode.Create))
                  {
                    resource_0.Write(resource_3.GetBuffer(), 0, (int) resource_3.Length);
                    resource_0.Close();
                    flag = true;
                  }
                }
              }
            }
            catch (IOException exception_0)
            {
              UI.main.WriteError();
            }
            catch (Exception exception_1)
            {
            }
            resource_2.Close();
            Main.HideSaveIcon();
          }
        }
        WorldGen.saveLock = false;
        if (flag)
          return;
        WorldSelect.LoadWorlds();
      }
    }

    private static void resetGen()
    {
      WorldGen.mudWall = false;
      WorldGen.hellChest = 0;
      WorldGen.JungleX = 0;
      WorldGen.numMCaves = 0;
      WorldGen.numIslandHouses = 0;
      WorldGen.houseCount = 0;
      WorldGen.dEnteranceX = 0;
      WorldGen.numDRooms = 0;
      WorldGen.numDDoors = 0;
      WorldGen.numDPlats = 0;
      WorldGen.numJChests = 0;
    }

    public static bool placeTrap(int x2, int y2, int type = -1)
    {
      int i1 = x2;
      int j1 = y2;
      while (!WorldGen.SolidTileUnsafe(i1, j1))
      {
        if (++j1 >= (int) Main.maxTilesY - 300)
          return false;
      }
      int j2 = j1 - 1;
      if ((int) Main.tile[i1, j2].liquid > 0 && (int) Main.tile[i1, j2].lava != 0)
        return false;
      if (type == -1 && Main.rand.Next(20) == 0)
        type = 2;
      else if (type == -1)
        type = Main.rand.Next(2);
      if ((int) Main.tile[i1, j2].active != 0 || (int) Main.tile[i1 - 1, j2].active != 0 || ((int) Main.tile[i1 + 1, j2].active != 0 || (int) Main.tile[i1, j2 - 1].active != 0) || ((int) Main.tile[i1 - 1, j2 - 1].active != 0 || (int) Main.tile[i1 + 1, j2 - 1].active != 0 || ((int) Main.tile[i1, j2 - 2].active != 0 || (int) Main.tile[i1 - 1, j2 - 2].active != 0)) || ((int) Main.tile[i1 + 1, j2 - 2].active != 0 || (int) Main.tile[i1, j2 + 1].type == 48))
        return false;
      if (type == 0)
      {
        int i2 = i1;
        int j3 = j2 - WorldGen.genRand.Next(3);
        while (!WorldGen.SolidTileUnsafe(i2, j3))
        {
          if (--i2 < 0)
            return false;
        }
        int i3 = i2;
        int i4 = i1;
        while (!WorldGen.SolidTileUnsafe(i4, j3))
        {
          if (++i4 >= (int) Main.maxTilesX)
            return false;
        }
        int i5 = i4;
        int num1 = i1 - i3;
        int num2 = i5 - i1;
        bool flag1 = num1 > 5 && num1 < 50;
        bool flag2 = num2 > 5 && num2 < 50;
        if (flag1 && !WorldGen.SolidTileUnsafe(i3, j3 + 1))
          flag1 = false;
        else if (flag1 && ((int) Main.tile[i3, j3].type == 10 || (int) Main.tile[i3, j3].type == 48 || ((int) Main.tile[i3, j3 + 1].type == 10 || (int) Main.tile[i3, j3 + 1].type == 48)))
          flag1 = false;
        if (flag2 && !WorldGen.SolidTileUnsafe(i5, j3 + 1))
          flag2 = false;
        else if (flag2 && ((int) Main.tile[i5, j3].type == 10 || (int) Main.tile[i5, j3].type == 48 || ((int) Main.tile[i5, j3 + 1].type == 10 || (int) Main.tile[i5, j3 + 1].type == 48)))
          flag2 = false;
        int style;
        int i6;
        if (flag1 && flag2)
        {
          style = 1;
          i6 = i3;
          if (WorldGen.genRand.Next(2) == 0)
          {
            i6 = i5;
            style = -1;
          }
        }
        else if (flag2)
        {
          i6 = i5;
          style = -1;
        }
        else
        {
          if (!flag1)
            return false;
          i6 = i3;
          style = 1;
        }
        WorldGen.PlaceTile(i1, j2, 135, true, true, -1, (int) Main.tile[i1, j2].wall > 0 ? 2 : WorldGen.genRand.Next(2, 4));
        WorldGen.KillTile(i6, j3);
        WorldGen.PlaceTile(i6, j3, 137, true, true, -1, style);
        int index1 = i1;
        int index2 = j2;
        while (index1 != i6 || index2 != j3)
        {
          Main.tile[index1, index2].wire = 16;
          if (index1 > i6)
            --index1;
          if (index1 < i6)
            ++index1;
          Main.tile[index1, index2].wire = 16;
          if (index2 > j3)
            --index2;
          if (index2 < j3)
            ++index2;
          Main.tile[index1, index2].wire = 16;
        }
        return true;
      }
      else if (type == 1)
      {
        int num1 = i1;
        int num2 = j2 - 8;
        int i2 = num1 + WorldGen.genRand.Next(-1, 2);
        bool flag1 = true;
        while (flag1)
        {
          bool flag2 = true;
          int num3 = 0;
          for (int i3 = i2 - 2; i3 <= i2 + 3; ++i3)
          {
            for (int j3 = num2; j3 <= num2 + 3; ++j3)
            {
              if (!WorldGen.SolidTileUnsafe(i3, j3))
                flag2 = false;
              if ((int) Main.tile[i3, j3].active != 0 && ((int) Main.tile[i3, j3].type == 0 || (int) Main.tile[i3, j3].type == 1 || (int) Main.tile[i3, j3].type == 59))
                ++num3;
            }
          }
          --num2;
          if (num2 < Main.worldSurface)
            return false;
          if (flag2 && num3 > 2)
            flag1 = false;
        }
        if (j2 - num2 <= 5 || j2 - num2 >= 40)
          return false;
        for (int i3 = i2; i3 <= i2 + 1; ++i3)
        {
          for (int j3 = num2; j3 <= j2; ++j3)
          {
            if (WorldGen.SolidTileUnsafe(i3, j3))
              WorldGen.KillTile(i3, j3);
          }
        }
        for (int i3 = i2 - 2; i3 <= i2 + 3; ++i3)
        {
          for (int j3 = num2 - 2; j3 <= num2 + 3; ++j3)
          {
            if (WorldGen.SolidTileUnsafe(i3, j3))
              Main.tile[i3, j3].type = (byte) 1;
          }
        }
        WorldGen.PlaceTile(i1, j2, 135, true, true, -1, WorldGen.genRand.Next(2, 4));
        WorldGen.PlaceTile(i2, num2 + 2, 130, true, false, -1, 0);
        WorldGen.PlaceTile(i2 + 1, num2 + 2, 130, true, false, -1, 0);
        WorldGen.PlaceTile(i2 + 1, num2 + 1, 138, true, false, -1, 0);
        int index1 = num2 + 2;
        Main.tile[i2, index1].wire = 16;
        Main.tile[i2 + 1, index1].wire = 16;
        int j4 = index1 + 1;
        WorldGen.PlaceTile(i2, j4, 130, true, false, -1, 0);
        WorldGen.PlaceTile(i2 + 1, j4, 130, true, false, -1, 0);
        Main.tile[i2, j4].wire = 16;
        Main.tile[i2 + 1, j4].wire = 16;
        WorldGen.PlaceTile(i2, j4 + 1, 130, true, false, -1, 0);
        WorldGen.PlaceTile(i2 + 1, j4 + 1, 130, true, false, -1, 0);
        Main.tile[i2, j4 + 1].wire = 16;
        Main.tile[i2 + 1, j4 + 1].wire = 16;
        int index2 = i1;
        int index3 = j2;
        while (index2 != i2 || index3 != j4)
        {
          Main.tile[index2, index3].wire = 16;
          if (index2 > i2)
            --index2;
          if (index2 < i2)
            ++index2;
          Main.tile[index2, index3].wire = 16;
          if (index3 > j4)
            --index3;
          if (index3 < j4)
            ++index3;
          Main.tile[index2, index3].wire = 16;
        }
        return true;
      }
      else
      {
        if (type == 2)
        {
          int num = Main.rand.Next(4, 7);
          int i2 = i1 + Main.rand.Next(-1, 2);
          int j3 = j2;
          for (int index = 0; index < num; ++index)
          {
            ++j3;
            if (!WorldGen.SolidTileUnsafe(i2, j3))
              return false;
          }
          for (int i3 = i2 - 2; i3 <= i2 + 2; ++i3)
          {
            for (int j4 = j3 - 2; j4 <= j3 + 2; ++j4)
            {
              if (!WorldGen.SolidTileUnsafe(i3, j4))
                return false;
            }
          }
          WorldGen.KillTile(i2, j3);
          Main.tile[i2, j3].active = (byte) 1;
          Main.tile[i2, j3].type = (byte) 141;
          Main.tile[i2, j3].frameX = (short) 0;
          Main.tile[i2, j3].frameY = (short) (18 * Main.rand.Next(2));
          WorldGen.PlaceTile(i1, j2, 135, true, true, -1, WorldGen.genRand.Next(2, 4));
          int index1 = i1;
          int index2 = j2;
          while (index1 != i2 || index2 != j3)
          {
            Main.tile[index1, index2].wire = 16;
            if (index1 > i2)
              --index1;
            if (index1 < i2)
              ++index1;
            Main.tile[index1, index2].wire = 16;
            if (index2 > j3)
              --index2;
            if (index2 < j3)
              ++index2;
            Main.tile[index1, index2].wire = 16;
          }
        }
        return false;
      }
    }

    public static unsafe void generateWorld(int seed = -1)
    {
      Time.checkXMas();
      NPC.clrNames();
      NPC.setNames();
      WorldGen.gen = true;
      WorldGen.resetGen();
      UI.main.FirstProgressStep(47, Lang.gen[0]);
      if (seed > 0)
        WorldGen.genRand = new FastRandom((uint) seed);
      Main.worldID = WorldGen.genRand.Next();
      Main.worldTimestamp = (int) (DateTime.UtcNow.Ticks / 10000000L);
      int num1 = 0;
      int num2 = 0;
      float num3 = (float) Main.maxTilesY * 0.3f * ((float) WorldGen.genRand.Next(90, 110) * 0.005f);
      float num4 = (num3 + (float) Main.maxTilesY * 0.2f) * ((float) WorldGen.genRand.Next(90, 110) * 0.01f);
      float num5 = num3;
      float num6 = num3;
      float num7 = num4;
      float num8 = num4;
      int num9 = (WorldGen.genRand.Next(2) << 1) - 1;
      float num10 = 1f / (float) Main.maxTilesX;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = 0; index < (int) Main.maxTilesX; ++index)
        {
          UI.main.progress = (float) index * num10;
          if ((double) num3 < (double) num5)
            num5 = num3;
          if ((double) num3 > (double) num6)
            num6 = num3;
          if ((double) num4 < (double) num7)
            num7 = num4;
          if ((double) num4 > (double) num8)
            num8 = num4;
          if (--num2 <= 0)
          {
            num1 = WorldGen.genRand.Next(5);
            num2 = WorldGen.genRand.Next(5, 40);
            if (num1 == 0)
              num2 *= WorldGen.genRand.Next(1, 6);
          }
          switch (num1)
          {
            case 0:
              while (WorldGen.genRand.Next(7) == 0)
                num3 += (float) WorldGen.genRand.Next(-1, 2);
              break;
            case 1:
              while (WorldGen.genRand.Next(4) == 0)
                --num3;
              while (WorldGen.genRand.Next(10) == 0)
                ++num3;
              break;
            case 2:
              while (WorldGen.genRand.Next(4) == 0)
                ++num3;
              while (WorldGen.genRand.Next(10) == 0)
                --num3;
              break;
            case 3:
              while (WorldGen.genRand.Next(2) == 0)
                --num3;
              while (WorldGen.genRand.Next(6) == 0)
                ++num3;
              break;
            default:
              while (WorldGen.genRand.Next(2) == 0)
                ++num3;
              while (WorldGen.genRand.Next(5) == 0)
                --num3;
              break;
          }
          if ((double) num3 < (double) Main.maxTilesY * 0.170000001788139)
          {
            num3 = (float) Main.maxTilesY * 0.17f;
            num2 = 0;
          }
          else if ((double) num3 > (double) Main.maxTilesY * 0.300000011920929)
          {
            num3 = (float) Main.maxTilesY * 0.3f;
            num2 = 0;
          }
          if ((index < 275 || index > (int) Main.maxTilesX - 275) && (double) num3 > (double) ((int) Main.maxTilesY >> 2))
          {
            num3 = (float) ((int) Main.maxTilesY >> 2);
            num2 = 1;
          }
          while (WorldGen.genRand.Next(3) == 0)
            num4 += (float) WorldGen.genRand.Next(-2, 3);
          if ((double) num4 < (double) num3 + (double) Main.maxTilesY * 0.05)
            ++num4;
          else if ((double) num4 > (double) num3 + (double) Main.maxTilesY * 0.35)
            --num4;
          int num11 = (int) Main.maxTilesY - 1;
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num11);
          do
          {
            tilePtr2->active = (byte) 1;
            tilePtr2->type = num11 < (int) num4 ? (byte) 0 : (byte) 1;
            tilePtr2->frameX = (short) -1;
            tilePtr2->frameY = (short) -1;
            --tilePtr2;
          }
          while (--num11 >= (int) num3);
          do
          {
            tilePtr2->active = (byte) 0;
            tilePtr2->frameX = (short) -1;
            tilePtr2->frameY = (short) -1;
            --tilePtr2;
          }
          while (--num11 >= 0);
        }
        Main.worldSurface = (int) num6 + 25;
        Main.worldSurfacePixels = Main.worldSurface << 4;
        int num12 = (int) (((double) num8 - (double) num6 + 25.0) * 0.16666667163372) * 6;
        Main.rockLayer = Main.worldSurface + num12;
        Main.rockLayerPixels = Main.rockLayer << 4;
        WorldGen.UpdateMagmaLayerPos();
        WorldGen.waterLine = Main.rockLayer + (int) Main.maxTilesY >> 1;
        WorldGen.waterLine += WorldGen.genRand.Next(-100, 20);
        WorldGen.lavaLine = WorldGen.waterLine + WorldGen.genRand.Next(50, 80);
        int num13 = 0;
        Location[] locationArray = new Location[10];
        for (int index1 = 0; index1 < (int) ((double) Main.maxTilesX * 0.00150000001303852); ++index1)
        {
          int index2 = WorldGen.genRand.Next(450, (int) Main.maxTilesX - 450);
          int index3 = 0;
          for (int index4 = 0; index4 < 10; ++index4)
          {
            while ((int) Main.tile[index2, index3].active == 0)
              ++index3;
            locationArray[index4].X = (short) index2;
            locationArray[index4].Y = (short) (index3 - WorldGen.genRand.Next(11, 16));
            index2 += WorldGen.genRand.Next(5, 11);
          }
          for (int index4 = 0; index4 < 10; ++index4)
          {
            WorldGen.TileRunner((int) locationArray[index4].X, (int) locationArray[index4].Y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(6, 9), 0, true, new Vector2(-2f, -0.3f), false, true);
            WorldGen.TileRunner((int) locationArray[index4].X, (int) locationArray[index4].Y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(6, 9), 0, true, new Vector2(2f, -0.3f), false, true);
          }
        }
        UI.main.NextProgressStep(Lang.gen[1]);
        int num14 = 2 + WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.0007999999797903), (int) ((double) Main.maxTilesX * (1.0 / 400.0)));
        for (int index1 = 0; index1 < num14; ++index1)
        {
          int num11 = WorldGen.genRand.Next((int) Main.maxTilesX);
          while ((double) num11 > (double) Main.maxTilesX * 0.400000005960464 && (double) num11 < (double) Main.maxTilesX * 0.600000023841858)
            num11 = WorldGen.genRand.Next((int) Main.maxTilesX);
          int num15 = WorldGen.genRand.Next(35, 90);
          if (index1 == 1)
          {
            float num16 = (float) Main.maxTilesX * 0.0002380952f;
            num15 += (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num16);
          }
          if (WorldGen.genRand.Next(3) == 0)
            num15 *= 2;
          if (index1 == 1)
            num15 *= 2;
          int num17 = num11 - num15;
          int num18 = WorldGen.genRand.Next(35, 90);
          if (WorldGen.genRand.Next(3) == 0)
            num18 *= 2;
          if (index1 == 1)
            num18 *= 2;
          int num19 = num11 + num18;
          if (num17 < 0)
            num17 = 0;
          if (num19 > (int) Main.maxTilesX)
            num19 = (int) Main.maxTilesX;
          if (index1 == 0)
          {
            num17 = 0;
            num19 = WorldGen.genRand.Next(260, 300);
            if (num9 == 1)
              num19 += 40;
          }
          else if (index1 == 2)
          {
            num17 = (int) Main.maxTilesX - WorldGen.genRand.Next(260, 300);
            num19 = (int) Main.maxTilesX;
            if (num9 == -1)
              num17 -= 40;
          }
          int num20 = WorldGen.genRand.Next(50, 100);
          for (int index2 = num17; index2 < num19; ++index2)
          {
            if (WorldGen.genRand.Next(2) == 0)
            {
              num20 += WorldGen.genRand.Next(-1, 2);
              if (num20 < 50)
                num20 = 50;
              if (num20 > 100)
                num20 = 100;
            }
            for (int index3 = 0; index3 < Main.worldSurface; ++index3)
            {
              if ((int) Main.tile[index2, index3].active != 0)
              {
                int num16 = num20;
                if (index2 - num17 < num16)
                  num16 = index2 - num17;
                if (num19 - index2 < num16)
                  num16 = num19 - index2;
                int num21 = num16 + WorldGen.genRand.Next(5);
                for (int index4 = index3; index4 < index3 + num21; ++index4)
                {
                  if (index2 > num17 + WorldGen.genRand.Next(5) && index2 < num19 - WorldGen.genRand.Next(5))
                    Main.tile[index2, index4].type = (byte) 53;
                }
                break;
              }
            }
          }
        }
        for (int index = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 7.99999997980194E-06); index > 0; --index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next(Main.worldSurface, Main.rockLayer), WorldGen.genRand.Next(15, 70), WorldGen.genRand.Next(20, 130), 53, false, new Vector2(), false, true);
        WorldGen.numMCaves = 0;
        UI.main.NextProgressStep(Lang.gen[2]);
        for (int index1 = 0; index1 < (int) ((double) Main.maxTilesX * 0.0007999999797903); ++index1)
        {
          int num11 = 0;
          bool flag1 = false;
          int i = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.25), (int) ((double) Main.maxTilesX * 0.75));
          bool flag2;
          do
          {
            flag2 = true;
            while (i > ((int) Main.maxTilesX >> 1) - 100 && i < ((int) Main.maxTilesX >> 1) + 100)
              i = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.25), (int) ((double) Main.maxTilesX * 0.75));
            for (int index2 = 0; index2 < WorldGen.numMCaves; ++index2)
            {
              if (i > (int) WorldGen.mCave[index2].X - 50 && i < (int) WorldGen.mCave[index2].X + 50)
              {
                ++num11;
                flag2 = false;
                break;
              }
            }
            if (num11 >= 200)
            {
              flag1 = true;
              break;
            }
          }
          while (!flag2);
          if (!flag1)
          {
            for (int j = 0; j < Main.worldSurface; ++j)
            {
              if ((int) Main.tile[i, j].active != 0)
              {
                WorldGen.Mountinater(i, j);
                WorldGen.mCave[WorldGen.numMCaves].X = (short) i;
                WorldGen.mCave[WorldGen.numMCaves].Y = (short) j;
                ++WorldGen.numMCaves;
                break;
              }
            }
          }
        }
        bool flag3 = Time.xMas;
        if (WorldGen.genRand.Next(3) == 0)
          flag3 = true;
        if (flag3)
        {
          UI.main.statusText = Lang.gen[56];
          int num11 = WorldGen.genRand.Next((int) Main.maxTilesX / 3, ((int) Main.maxTilesX << 1) / 3);
          int num15 = WorldGen.genRand.Next(35, 90);
          float num16 = (float) Main.maxTilesX * 0.0004761905f;
          int num17 = num15 + (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num16);
          int num18 = num11 - num17;
          if (num18 < 0)
            num18 = 0;
          int num19 = WorldGen.genRand.Next(35, 90) + (int) ((double) WorldGen.genRand.Next(20, 40) * (double) num16);
          int num20 = num11 + num19;
          if (num20 > (int) Main.maxTilesX)
            num20 = (int) Main.maxTilesX;
          int num21 = WorldGen.genRand.Next(50, 100);
          for (int index1 = num18; index1 < num20; ++index1)
          {
            if (WorldGen.genRand.Next(2) == 0)
            {
              num21 += WorldGen.genRand.Next(-1, 2);
              if (num21 < 50)
                num21 = 50;
              if (num21 > 100)
                num21 = 100;
            }
            for (int index2 = 0; index2 < Main.worldSurface; ++index2)
            {
              if ((int) Main.tile[index1, index2].active != 0)
              {
                int num22 = num21;
                if (index1 - num18 < num22)
                  num22 = index1 - num18;
                if (num20 - index1 < num22)
                  num22 = num20 - index1;
                int num23 = num22 + WorldGen.genRand.Next(5);
                for (int index3 = index2; index3 < index2 + num23; ++index3)
                {
                  if (index1 > num18 + WorldGen.genRand.Next(5) && index1 < num20 - WorldGen.genRand.Next(5))
                    Main.tile[index1, index3].type = (byte) 147;
                }
                break;
              }
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[3]);
        for (int index1 = 1; index1 < (int) Main.maxTilesX - 1; ++index1)
        {
          UI.main.progress = (float) index1 / (float) Main.maxTilesX;
          bool flag1 = false;
          num13 += WorldGen.genRand.Next(-1, 2);
          if (num13 < 0)
            num13 = 0;
          if (num13 > 10)
            num13 = 10;
          for (int index2 = 0; index2 < Main.worldSurface + 10 && index2 <= Main.worldSurface + num13; ++index2)
          {
            if (flag1)
              Main.tile[index1, index2].wall = (byte) 2;
            if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1 - 1, index2].active != 0 && ((int) Main.tile[index1 + 1, index2].active != 0 && (int) Main.tile[index1, index2 + 1].active != 0) && ((int) Main.tile[index1 - 1, index2 + 1].active != 0 && (int) Main.tile[index1 + 1, index2 + 1].active != 0))
              flag1 = true;
          }
        }
        UI.main.NextProgressStep(Lang.gen[4]);
        for (int index = 0; index < (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000199999994947575); ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5 + 1), WorldGen.genRand.Next(4, 15), WorldGen.genRand.Next(5, 40), 1, false, new Vector2(), false, true);
        for (int index = 0; index < (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000199999994947575); ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6 + 1), WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(5, 30), 1, false, new Vector2(), false, true);
        for (int index = 0; index < (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.0044999998062849); ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8 + 1), WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(2, 23), 1, false, new Vector2(), false, true);
        UI.main.NextProgressStep(Lang.gen[5]);
        for (int index = 0; index < (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.00499999988824129); ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num7, (int) Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 40), 0, false, new Vector2(), false, true);
        UI.main.NextProgressStep(Lang.gen[6]);
        for (int index = 0; index < (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 1.99999994947575E-05); ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5), WorldGen.genRand.Next(4, 14), WorldGen.genRand.Next(10, 50), 40, false, new Vector2(), false, true);
        for (int index = 0; index < (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 4.99999987368938E-05); ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6 + 1), WorldGen.genRand.Next(8, 14), WorldGen.genRand.Next(15, 45), 40, false, new Vector2(), false, true);
        for (int index = 0; index < (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 1.99999994947575E-05); ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8 + 1), WorldGen.genRand.Next(8, 15), WorldGen.genRand.Next(5, 50), 40, false, new Vector2(), false, true);
        for (int index1 = 5; index1 < (int) Main.maxTilesX - 5; ++index1)
        {
          for (int index2 = 1; index2 < Main.worldSurface - 1; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0)
            {
              for (int index3 = index2; index3 < index2 + 5; ++index3)
              {
                if ((int) Main.tile[index1, index3].type == 40)
                  Main.tile[index1, index3].type = (byte) 0;
              }
              break;
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[7]);
        int num24 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.00150000001303852);
        for (int index = 0; index < num24; ++index)
        {
          UI.main.progress = (float) index / (float) num24;
          int type = -1;
          if (WorldGen.genRand.Next(5) == 0)
            type = -2;
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) Main.maxTilesY), WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 20), type, false, new Vector2(), false, true);
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) Main.maxTilesY), WorldGen.genRand.Next(8, 15), WorldGen.genRand.Next(7, 30), type, false, new Vector2(), false, true);
        }
        if ((double) num8 <= (double) Main.maxTilesY)
        {
          UI.main.NextProgressStep(Lang.gen[8]);
          int num11 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 2.99999992421363E-05);
          for (int index = 0; index < num11; ++index)
          {
            UI.main.progress = (float) index / (float) num11;
            int type = -1;
            if (WorldGen.genRand.Next(6) == 0)
              type = -2;
            WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num8 + 1), WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(30, 200), type, false, new Vector2(), false, true);
          }
        }
        if ((double) num8 <= (double) Main.maxTilesY)
        {
          UI.main.NextProgressStep(Lang.gen[9]);
          int num11 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000130000000353903);
          for (int index = 0; index < num11; ++index)
          {
            UI.main.progress = (float) index / (float) num11;
            int type = -1;
            if (WorldGen.genRand.Next(10) == 0)
              type = -2;
            WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num8, (int) Main.maxTilesY), WorldGen.genRand.Next(6, 20), WorldGen.genRand.Next(50, 300), type, false, new Vector2(), false, true);
          }
        }
        UI.main.NextProgressStep(Lang.gen[10]);
        int num25 = (int) ((double) Main.maxTilesX * (1.0 / 400.0));
        for (int index = 0; index < num25; ++index)
        {
          int i = WorldGen.genRand.Next((int) Main.maxTilesX);
          for (int j = 0; (double) j < (double) num6; ++j)
          {
            if ((int) Main.tile[i, j].active != 0)
            {
              WorldGen.TileRunner(i, j, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(5, 50), -1, false, new Vector2((float) WorldGen.genRand.Next(-10, 11) * 0.1f, 1f), false, true);
              break;
            }
          }
        }
        int num26 = (int) ((double) Main.maxTilesX * 0.000699999975040555);
        for (int index = 0; index < num26; ++index)
        {
          int i = WorldGen.genRand.Next((int) Main.maxTilesX);
          for (int j = 0; (double) j < (double) num6; ++j)
          {
            if ((int) Main.tile[i, j].active != 0)
            {
              WorldGen.TileRunner(i, j, WorldGen.genRand.Next(10, 15), WorldGen.genRand.Next(50, 130), -1, false, new Vector2((float) WorldGen.genRand.Next(-10, 11) * 0.1f, 2f), false, true);
              break;
            }
          }
        }
        int num27 = (int) ((double) Main.maxTilesX * 0.000300000014249235);
        for (int index = 0; index < num27; ++index)
        {
          int i = WorldGen.genRand.Next((int) Main.maxTilesX);
          for (int j = 0; (double) j < (double) num6; ++j)
          {
            if ((int) Main.tile[i, j].active != 0)
            {
              WorldGen.TileRunner(i, j, WorldGen.genRand.Next(12, 25), WorldGen.genRand.Next(150, 500), -1, false, new Vector2((float) WorldGen.genRand.Next(-10, 11) * 0.1f, 4f), false, true);
              WorldGen.TileRunner(i, j, WorldGen.genRand.Next(8, 17), WorldGen.genRand.Next(60, 200), -1, false, new Vector2((float) WorldGen.genRand.Next(-10, 11) * 0.1f, 2f), false, true);
              WorldGen.TileRunner(i, j, WorldGen.genRand.Next(5, 13), WorldGen.genRand.Next(40, 170), -1, false, new Vector2((float) WorldGen.genRand.Next(-10, 11) * 0.1f, 2f), false, true);
              break;
            }
          }
        }
        int num28 = (int) ((double) Main.maxTilesX * 0.00039999998989515);
        for (int index = 0; index < num28; ++index)
        {
          int i = WorldGen.genRand.Next((int) Main.maxTilesX);
          for (int j = 0; (double) j < (double) num6; ++j)
          {
            if ((int) Main.tile[i, j].active != 0)
            {
              WorldGen.TileRunner(i, j, WorldGen.genRand.Next(7, 12), WorldGen.genRand.Next(150, 250), -1, false, new Vector2(0.0f, 1f), true, true);
              break;
            }
          }
        }
        int num29 = (int) ((double) Main.maxTilesX * (1.0 / 840.0));
        for (int index = 0; index < num29; ++index)
          WorldGen.Caverer(WorldGen.genRand.Next(100, (int) Main.maxTilesX - 100), WorldGen.genRand.Next(Main.rockLayer, (int) Main.maxTilesY - 400));
        int num30 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * (1.0 / 500.0));
        for (int index1 = 0; index1 < num30; ++index1)
        {
          int index2 = WorldGen.genRand.Next(1, (int) Main.maxTilesX - 1);
          int index3 = WorldGen.genRand.Next((int) num5, (int) num6);
          if (index3 >= (int) Main.maxTilesY)
            index3 = (int) Main.maxTilesY - 2;
          if ((int) Main.tile[index2 - 1, index3].active != 0 && (int) Main.tile[index2 - 1, index3].type == 0 && ((int) Main.tile[index2 + 1, index3].active != 0 && (int) Main.tile[index2 + 1, index3].type == 0) && ((int) Main.tile[index2, index3 - 1].active != 0 && (int) Main.tile[index2, index3 - 1].type == 0 && ((int) Main.tile[index2, index3 + 1].active != 0 && (int) Main.tile[index2, index3 + 1].type == 0)))
          {
            Main.tile[index2, index3].active = (byte) 1;
            Main.tile[index2, index3].type = (byte) 2;
          }
          int index4 = WorldGen.genRand.Next(1, (int) Main.maxTilesX - 1);
          int index5 = WorldGen.genRand.Next((int) num5);
          if (index5 >= (int) Main.maxTilesY)
            index5 = (int) Main.maxTilesY - 2;
          if ((int) Main.tile[index4 - 1, index5].active != 0 && (int) Main.tile[index4 - 1, index5].type == 0 && ((int) Main.tile[index4 + 1, index5].active != 0 && (int) Main.tile[index4 + 1, index5].type == 0) && ((int) Main.tile[index4, index5 - 1].active != 0 && (int) Main.tile[index4, index5 - 1].type == 0 && ((int) Main.tile[index4, index5 + 1].active != 0 && (int) Main.tile[index4, index5 + 1].type == 0)))
          {
            Main.tile[index4, index5].active = (byte) 1;
            Main.tile[index4, index5].type = (byte) 2;
          }
        }
        UI.main.NextProgressStep(Lang.gen[11]);
        float num31 = (float) WorldGen.genRand.Next(15, 30) * 0.01f;
        if (num9 == -1)
          num31 = 1f - num31;
        int num32 = (int) ((double) Main.maxTilesX * (double) num31);
        int num33 = (int) Main.maxTilesY + Main.rockLayer >> 1;
        float num34 = (float) Main.maxTilesX * 0.0003571429f;
        int i1 = num32 + WorldGen.genRand.Next((int) (-100.0 * (double) num34), (int) (101.0 * (double) num34));
        int j1 = num33 + WorldGen.genRand.Next((int) (-100.0 * (double) num34), (int) (101.0 * (double) num34));
        int num35 = i1;
        int num36 = j1;
        WorldGen.TileRunner(i1, j1, WorldGen.genRand.Next((int) (250.0 * (double) num34), (int) (500.0 * (double) num34)), WorldGen.genRand.Next(50, 150), 59, false, new Vector2((float) (num9 * 3), 0.0f), false, true);
        for (int index = (int) (6.0 * (double) num34); index > 0; --index)
          WorldGen.TileRunner(i1 + WorldGen.genRand.Next(-(int) (125.0 * (double) num34), (int) (125.0 * (double) num34)), j1 + WorldGen.genRand.Next(-(int) (125.0 * (double) num34), (int) (125.0 * (double) num34)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(63, 65), false, new Vector2(), false, true);
        UI.main.progress = 0.15f;
        int i2 = i1 + WorldGen.genRand.Next((int) (-250.0 * (double) num34), (int) (251.0 * (double) num34));
        int j2 = j1 + WorldGen.genRand.Next((int) (-150.0 * (double) num34), (int) (151.0 * (double) num34));
        int num37 = i2;
        int num38 = j2;
        int num39 = i2;
        int num40 = j2;
        WorldGen.mudWall = true;
        WorldGen.TileRunner(i2, j2, WorldGen.genRand.Next((int) (250.0 * (double) num34), (int) (500.0 * (double) num34)), WorldGen.genRand.Next(50, 150), 59, false, new Vector2(), false, true);
        WorldGen.mudWall = false;
        for (int index = (int) (6.0 * (double) num34); index > 0; --index)
          WorldGen.TileRunner(i2 + WorldGen.genRand.Next(-(int) (125.0 * (double) num34), (int) (125.0 * (double) num34)), j2 + WorldGen.genRand.Next(-(int) (125.0 * (double) num34), (int) (125.0 * (double) num34)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(65, 67), false, new Vector2(), false, true);
        WorldGen.mudWall = true;
        UI.main.progress = 0.3f;
        int i3 = i2 + WorldGen.genRand.Next((int) (-400.0 * (double) num34), (int) (401.0 * (double) num34));
        int j3 = j2 + WorldGen.genRand.Next((int) (-150.0 * (double) num34), (int) (151.0 * (double) num34));
        int num41 = i3;
        int num42 = j3;
        WorldGen.TileRunner(i3, j3, WorldGen.genRand.Next((int) (250.0 * (double) num34), (int) (500.0 * (double) num34)), WorldGen.genRand.Next(50, 150), 59, false, new Vector2((float) (num9 * -3), 0.0f), false, true);
        WorldGen.mudWall = false;
        for (int index = (int) (6.0 * (double) num34); index > 0; --index)
          WorldGen.TileRunner(i3 + WorldGen.genRand.Next(-(int) (125.0 * (double) num34), (int) (125.0 * (double) num34)), j3 + WorldGen.genRand.Next(-(int) (125.0 * (double) num34), (int) (125.0 * (double) num34)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(67, 69), false, new Vector2(), false, true);
        WorldGen.mudWall = true;
        UI.main.progress = 0.45f;
        int i4 = (num35 + num37 + num41) / 3;
        int j4 = (num36 + num38 + num42) / 3;
        WorldGen.TileRunner(i4, j4, WorldGen.genRand.Next((int) (400.0 * (double) num34), (int) (600.0 * (double) num34)), 10000, 59, false, new Vector2(0.0f, -20f), true, true);
        WorldGen.JungleRunner(i4, j4);
        UI.main.progress = 0.6f;
        WorldGen.mudWall = false;
        List<uint> list = new List<uint>();
        int num43 = 0;
        for (int index1 = 20; index1 < (int) Main.maxTilesX - 20; ++index1)
        {
          for (int index2 = Main.rockLayer; index2 < (int) Main.maxTilesY - 200; ++index2)
          {
            if ((int) Main.tile[index1, index2].wall == 15)
            {
              list.Add((uint) (i4 << 16 | j4));
              ++num43;
            }
          }
        }
        for (int index1 = 0; num43 > 0 && index1 < (int) Main.maxTilesX / 10; ++index1)
        {
          int index2 = WorldGen.genRand.Next(num43--);
          int i5 = (int) (list[index2] >> 16);
          int j5 = (int) list[index2] & (int) ushort.MaxValue;
          list.RemoveAt(index2);
          WorldGen.MudWallRunner(i5, j5);
        }
        int i6 = num39;
        int j6 = num40;
        int num44 = (int) (20.0 * (double) num34);
        for (int index = 0; index <= num44; ++index)
        {
          UI.main.progress = (float) (0.600000023841858 + 0.200000002980232 * ((double) index / (double) num44));
          i6 += WorldGen.genRand.Next((int) (-5.0 * (double) num34), (int) (6.0 * (double) num34));
          j6 += WorldGen.genRand.Next((int) (-5.0 * (double) num34), (int) (6.0 * (double) num34));
          WorldGen.TileRunner(i6, j6, WorldGen.genRand.Next(40, 100), WorldGen.genRand.Next(300, 500), 59, false, new Vector2(), false, true);
        }
        int num45 = (int) (10.0 * (double) num34);
        for (int index1 = 0; index1 <= num45; ++index1)
        {
          UI.main.progress = (float) (0.800000011920929 + 0.200000002980232 * ((double) index1 / (double) num45));
          int i5 = num39 + WorldGen.genRand.Next((int) (-600.0 * (double) num34), (int) (600.0 * (double) num34));
          int j5;
          for (j5 = num40 + WorldGen.genRand.Next((int) (-200.0 * (double) num34), (int) (200.0 * (double) num34)); i5 < 1 || i5 >= (int) Main.maxTilesX - 1 || (j5 < 1 || j5 >= (int) Main.maxTilesY - 1) || (int) Main.tile[i5, j5].type != 59; j5 = num40 + WorldGen.genRand.Next((int) (-200.0 * (double) num34), (int) (200.0 * (double) num34)))
            i5 = num39 + WorldGen.genRand.Next((int) (-600.0 * (double) num34), (int) (600.0 * (double) num34));
          for (int index2 = 0; (double) index2 < 8.0 * (double) num34; ++index2)
          {
            i5 += WorldGen.genRand.Next(-30, 31);
            j5 += WorldGen.genRand.Next(-30, 31);
            int type = -1;
            if (WorldGen.genRand.Next(7) == 0)
              type = -2;
            WorldGen.TileRunner(i5, j5, WorldGen.genRand.Next(10, 20), WorldGen.genRand.Next(30, 70), type, false, new Vector2(), false, true);
          }
        }
        for (int index = 0; (double) index <= 300.0 * (double) num34; ++index)
        {
          int i5 = num39 + WorldGen.genRand.Next((int) (-600.0 * (double) num34), (int) (600.0 * (double) num34));
          int j5;
          for (j5 = num40 + WorldGen.genRand.Next((int) (-200.0 * (double) num34), (int) (200.0 * (double) num34)); i5 < 1 || i5 >= (int) Main.maxTilesX - 1 || (j5 < 1 || j5 >= (int) Main.maxTilesY - 1) || (int) Main.tile[i5, j5].type != 59; j5 = num40 + WorldGen.genRand.Next((int) (-200.0 * (double) num34), (int) (200.0 * (double) num34)))
            i5 = num39 + WorldGen.genRand.Next((int) (-600.0 * (double) num34), (int) (600.0 * (double) num34));
          WorldGen.TileRunner(i5, j5, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(5, 30), 1, false, new Vector2(), false, true);
          if (WorldGen.genRand.Next(4) == 0)
          {
            int type = WorldGen.genRand.Next(63, 69);
            WorldGen.TileRunner(i5 + WorldGen.genRand.Next(-1, 2), j5 + WorldGen.genRand.Next(-1, 2), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(4, 8), type, false, new Vector2(), false, true);
          }
        }
        for (int index1 = (int) ((double) (WorldGen.genRand.Next(6, 10) * (int) Main.maxTilesX) * 0.000238095235545188) - 1; index1 >= 0; --index1)
        {
          int index2;
          int index3;
          do
          {
            index2 = WorldGen.genRand.Next(20, (int) Main.maxTilesX - 20);
            index3 = WorldGen.genRand.Next(Main.worldSurface + Main.rockLayer >> 1, (int) Main.maxTilesY - 300);
          }
          while ((int) Main.tile[index2, index3].type != 59);
          int num11 = WorldGen.genRand.Next(2, 4);
          int num15 = WorldGen.genRand.Next(2, 4);
          for (int index4 = index2 - num11 - 1; index4 <= index2 + num11 + 1; ++index4)
          {
            for (int index5 = index3 - num15 - 1; index5 <= index3 + num15 + 1; ++index5)
            {
              Main.tile[index4, index5].active = (byte) 1;
              Main.tile[index4, index5].type = (byte) 45;
              Main.tile[index4, index5].liquid = (byte) 0;
              Main.tile[index4, index5].lava = (byte) 0;
            }
          }
          for (int index4 = index2 - num11; index4 <= index2 + num11; ++index4)
          {
            for (int index5 = index3 - num15; index5 <= index3 + num15; ++index5)
              Main.tile[index4, index5].active = (byte) 0;
          }
          int num16 = 0;
          do
            ;
          while (!WorldGen.PlaceTile(WorldGen.genRand.Next(index2 - num11, index2 + num11 + 1), WorldGen.genRand.Next(index3 - num15, index3 + num15 - 2), 4, true, false, -1, 0) && ++num16 < 100);
          for (int index4 = index3 + num15 - 2; index4 <= index3 + num15 - 1; ++index4)
          {
            for (int index5 = index2 - num11 - 1; index5 <= index2 + num11 + 1; ++index5)
              Main.tile[index5, index4].active = (byte) 0;
          }
          for (int index4 = index2 - num11 - 1; index4 <= index2 + num11 + 1; ++index4)
          {
            int num17 = 4;
            for (int index5 = index3 + num15 + 2; (int) Main.tile[index4, index5].active == 0 && index5 < (int) Main.maxTilesY && num17 > 0; --num17)
            {
              Main.tile[index4, index5].active = (byte) 1;
              Main.tile[index4, index5].type = (byte) 59;
              ++index5;
            }
          }
          int num18 = num11 - WorldGen.genRand.Next(1, 3);
          int index6 = index3 - num15 - 2;
          while (num18 >= 0)
          {
            for (int index4 = index2 - num18 - 1; index4 <= index2 + num18 + 1; ++index4)
            {
              Main.tile[index4, index6].active = (byte) 1;
              Main.tile[index4, index6].type = (byte) 45;
            }
            num18 -= WorldGen.genRand.Next(1, 3);
            --index6;
          }
          WorldGen.JChest[WorldGen.numJChests].X = (short) index2;
          WorldGen.JChest[WorldGen.numJChests].Y = (short) index3;
          ++WorldGen.numJChests;
        }
        for (int j5 = 0; j5 < (int) Main.maxTilesY; ++j5)
        {
          for (int i5 = 0; i5 < (int) Main.maxTilesX; ++i5)
          {
            if ((int) Main.tile[i5, j5].active != 0)
            {
              try
              {
                WorldGen.grassSpread = 0;
                WorldGen.SpreadGrass(i5, j5, 59, 60, true);
              }
              catch
              {
                WorldGen.grassSpread = 0;
                WorldGen.SpreadGrass(i5, j5, 59, 60, false);
              }
            }
          }
        }
        WorldGen.numIslandHouses = 0;
        WorldGen.houseCount = 0;
        UI.main.NextProgressStep(Lang.gen[12]);
        int num46 = (int) ((double) Main.maxTilesX * 0.0008);
        for (int index1 = 0; index1 < num46; ++index1)
        {
          int num11 = 0;
          bool flag1 = false;
          int index2 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.1), (int) ((double) Main.maxTilesX * 0.9));
          bool flag2;
          do
          {
            flag2 = true;
            while (index2 > ((int) Main.maxTilesX >> 1) - 80 && index2 < ((int) Main.maxTilesX >> 1) + 80)
              index2 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.1), (int) ((double) Main.maxTilesX * 0.9));
            for (int index3 = 0; index3 < WorldGen.numIslandHouses; ++index3)
            {
              if (index2 > (int) WorldGen.fih[index3].X - 80 && index2 < (int) WorldGen.fih[index3].X + 80)
              {
                ++num11;
                flag2 = false;
                break;
              }
            }
            if (num11 >= 200)
            {
              flag1 = true;
              break;
            }
          }
          while (!flag2);
          if (!flag1)
          {
            for (int index3 = 200; index3 < Main.worldSurface; ++index3)
            {
              if ((int) Main.tile[index2, index3].active != 0)
              {
                int i5 = index2;
                int j5 = WorldGen.genRand.Next(90, index3 - 100);
                while ((double) j5 > (double) num5 - 50.0)
                  --j5;
                WorldGen.FloatingIsland(i5, j5);
                WorldGen.fih[WorldGen.numIslandHouses].X = (short) i5;
                WorldGen.fih[WorldGen.numIslandHouses].Y = (short) j5;
                ++WorldGen.numIslandHouses;
                break;
              }
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[13]);
        for (int index = (int) Main.maxTilesX / 500 - 1; index >= 0; --index)
          WorldGen.ShroomPatch(WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.300000011920929), (int) ((double) Main.maxTilesX * 0.699999988079071)), WorldGen.genRand.Next(Main.rockLayer, (int) Main.maxTilesY - 249));
        for (int i5 = 0; i5 < (int) Main.maxTilesX; ++i5)
        {
          for (int j5 = Main.worldSurface; j5 < (int) Main.maxTilesY; ++j5)
          {
            if ((int) Main.tile[i5, j5].active != 0)
            {
              WorldGen.grassSpread = 0;
              WorldGen.SpreadGrass(i5, j5, 59, 70, false);
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[14]);
        int num47 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * (1.0 / 1000.0));
        for (int index = 0; index < num47; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num7, (int) Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(2, 40), 59, false, new Vector2(), false, true);
        UI.main.NextProgressStep(Lang.gen[15]);
        int num48 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 9.99999974737875E-05);
        for (int index = 0; index < num48; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num8, (int) Main.maxTilesY), WorldGen.genRand.Next(5, 12), WorldGen.genRand.Next(15, 50), 123, false, new Vector2(), false, true);
        int num49 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000500000023748726);
        for (int index = 0; index < num49; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num8, (int) Main.maxTilesY), WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(2, 5), 123, false, new Vector2(), false, true);
        UI.main.NextProgressStep(Lang.gen[16]);
        int num50 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 5.99999984842725E-05);
        for (int index = 0; index < num50; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), 7, false, new Vector2(), false, true);
        int num51 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 7.999999797903E-05);
        for (int index = 0; index < num51; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), 7, false, new Vector2(), false, true);
        int num52 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000199999994947575);
        for (int index = 0; index < num52; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num7, (int) Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 7, false, new Vector2(), false, true);
        int num53 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 2.99999992421363E-05);
        for (int index = 0; index < num53; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5, (int) num6), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), 6, false, new Vector2(), false, true);
        int num54 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 7.999999797903E-05);
        for (int index = 0; index < num54; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), 6, false, new Vector2(), false, true);
        int num55 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000199999994947575);
        for (int index = 0; index < num55; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num7, (int) Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 6, false, new Vector2(), false, true);
        int num56 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 2.59999997069826E-05);
        for (int index = 0; index < num56; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num6, (int) num8), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), 9, false, new Vector2(), false, true);
        int num57 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000150000007124618);
        for (int index = 0; index < num57; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num7, (int) Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 9, false, new Vector2(), false, true);
        int num58 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000169999999343418);
        for (int index = 0; index < num58; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), 9, false, new Vector2(), false, true);
        int num59 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000119999996968545);
        for (int index = 0; index < num59; ++index)
        {
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num7, (int) Main.maxTilesY), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), 8, false, new Vector2(), false, true);
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num5 - 20), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), 8, false, new Vector2(), false, true);
        }
        int num60 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 1.99999994947575E-05);
        for (int index = 0; index < num60; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) num7, (int) Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), 22, false, new Vector2(), false, true);
        UI.main.NextProgressStep(Lang.gen[17]);
        int num61 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.000600000028498471);
        for (int index1 = 0; index1 < num61; ++index1)
        {
          int index2 = WorldGen.genRand.Next(20, (int) Main.maxTilesX - 20);
          int index3 = WorldGen.genRand.Next((int) num5, (int) Main.maxTilesY - 20);
          if (index1 < WorldGen.numMCaves)
          {
            index2 = (int) WorldGen.mCave[index1].X;
            index3 = (int) WorldGen.mCave[index1].Y;
          }
          if ((int) Main.tile[index2, index3].active == 0 && (index3 > Main.worldSurface || (int) Main.tile[index2, index3].wall > 0))
          {
            while ((int) Main.tile[index2, index3].active == 0 && index3 > (int) num5)
              --index3;
            int j5 = index3 + 1;
            int num11 = 1;
            if (WorldGen.genRand.Next(2) == 0)
              num11 = -1;
            while ((int) Main.tile[index2, j5].active == 0 && index2 > 10 && index2 < (int) Main.maxTilesX - 10)
              index2 += num11;
            int i5 = index2 - num11;
            if (j5 > Main.worldSurface || (int) Main.tile[i5, j5].wall > 0)
              WorldGen.TileRunner(i5, j5, WorldGen.genRand.Next(4, 11), WorldGen.genRand.Next(2, 4), 51, true, new Vector2((float) num11, -1f), false, false);
          }
        }
        UI.main.NextProgressStep(Lang.gen[18]);
        int num62 = (int) Main.maxTilesY - WorldGen.genRand.Next(150, 190);
        for (int index = 0; index < (int) Main.maxTilesX; ++index)
        {
          UI.main.progress = (float) index * 0.2f / (float) Main.maxTilesX;
          num62 += WorldGen.genRand.Next(-3, 4);
          if (num62 < (int) Main.maxTilesY - 190)
            num62 = (int) Main.maxTilesY - 190;
          else if (num62 > (int) Main.maxTilesY - 160)
            num62 = (int) Main.maxTilesY - 160;
          int num11 = num62 - 20 - WorldGen.genRand.Next(3);
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num11);
          do
          {
            if (num11 >= num62)
            {
              tilePtr2->active = (byte) 0;
              tilePtr2->lava = (byte) 0;
              tilePtr2->liquid = (byte) 0;
            }
            else
              tilePtr2->type = (byte) 57;
            ++tilePtr2;
          }
          while (++num11 < (int) Main.maxTilesY);
        }
        int num63 = (int) Main.maxTilesY - WorldGen.genRand.Next(40, 70);
        for (int index = 10; index < (int) Main.maxTilesX - 10; ++index)
        {
          num63 += WorldGen.genRand.Next(-10, 11);
          if (num63 > (int) Main.maxTilesY - 60)
            num63 = (int) Main.maxTilesY - 60;
          else if (num63 < (int) Main.maxTilesY - 100)
            num63 = (int) Main.maxTilesY - 120;
          int num11 = num63;
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + num11);
          do
          {
            if ((int) tilePtr2->active == 0)
            {
              tilePtr2->lava = (byte) 32;
              tilePtr2->liquid = byte.MaxValue;
            }
          }
          while (++num11 < (int) Main.maxTilesY - 10);
        }
        for (int index1 = 0; index1 < (int) Main.maxTilesX; ++index1)
        {
          if (WorldGen.genRand.Next(50) == 0)
          {
            int index2 = (int) Main.maxTilesY - 65;
            while ((int) Main.tile[index1, index2].active == 0 && index2 > (int) Main.maxTilesY - 135)
              --index2;
            WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), index2 + WorldGen.genRand.Next(20, 50), WorldGen.genRand.Next(15, 20), 1000, 57, true, new Vector2(0.0f, (float) WorldGen.genRand.Next(1, 3)), true, true);
            UI.main.progress = (float) (0.200000002980232 + (double) ((float) index1 * 0.05f) / (double) Main.maxTilesX);
          }
        }
        Liquid.QuickWater(0.25, 3, -1, 0.25);
        for (int i5 = 0; i5 < (int) Main.maxTilesX; ++i5)
        {
          if (WorldGen.genRand.Next(13) == 0)
          {
            int index = (int) Main.maxTilesY - 65;
            while (((int) Main.tile[i5, index].liquid > 0 || (int) Main.tile[i5, index].active != 0) && index > (int) Main.maxTilesY - 140)
              --index;
            WorldGen.TileRunner(i5, index - WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(5, 30), 1000, 57, true, new Vector2(0.0f, (float) WorldGen.genRand.Next(1, 3)), true, true);
            int num11 = WorldGen.genRand.Next(1, 3);
            if (WorldGen.genRand.Next(3) == 0)
              num11 >>= 1;
            if (WorldGen.genRand.Next(2) == 0)
              WorldGen.TileRunner(i5, index - WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(5, 15) * num11, WorldGen.genRand.Next(10, 15) * num11, 57, true, new Vector2(1f, 0.3f), false, true);
            if (WorldGen.genRand.Next(2) == 0)
            {
              int num15 = WorldGen.genRand.Next(1, 3);
              WorldGen.TileRunner(i5, index - WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(5, 15) * num15, WorldGen.genRand.Next(10, 15) * num15, 57, true, new Vector2(-1f, 0.3f), false, true);
            }
            WorldGen.TileRunner(i5 + WorldGen.genRand.Next(-10, 10), index + WorldGen.genRand.Next(-10, 10), WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(5, 10), -2, false, new Vector2((float) WorldGen.genRand.Next(-1, 3), (float) WorldGen.genRand.Next(-1, 3)), false, true);
            if (WorldGen.genRand.Next(3) == 0)
              WorldGen.TileRunner(i5 + WorldGen.genRand.Next(-10, 10), index + WorldGen.genRand.Next(-10, 10), WorldGen.genRand.Next(10, 30), WorldGen.genRand.Next(10, 20), -2, false, new Vector2((float) WorldGen.genRand.Next(-1, 3), (float) WorldGen.genRand.Next(-1, 3)), false, true);
            if (WorldGen.genRand.Next(5) == 0)
              WorldGen.TileRunner(i5 + WorldGen.genRand.Next(-15, 15), index + WorldGen.genRand.Next(-15, 10), WorldGen.genRand.Next(15, 30), WorldGen.genRand.Next(5, 20), -2, false, new Vector2((float) WorldGen.genRand.Next(-1, 3), (float) WorldGen.genRand.Next(-1, 3)), false, true);
            UI.main.progress = (float) (0.5 + (double) ((float) i5 * 0.4f) / (double) Main.maxTilesX);
          }
        }
        UI.main.progress = 0.9f;
        for (int index = 0; index < (int) Main.maxTilesX; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next(20, (int) Main.maxTilesX - 20), WorldGen.genRand.Next((int) Main.maxTilesY - 180, (int) Main.maxTilesY - 10), WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(2, 7), -2, false, new Vector2(), false, true);
        for (int index = 0; index < (int) Main.maxTilesX; ++index)
        {
          if ((int) Main.tile[index, (int) Main.maxTilesY - 145].active == 0)
          {
            Main.tile[index, (int) Main.maxTilesY - 145].liquid = byte.MaxValue;
            Main.tile[index, (int) Main.maxTilesY - 145].lava = (byte) 32;
          }
          if ((int) Main.tile[index, (int) Main.maxTilesY - 144].active == 0)
          {
            Main.tile[index, (int) Main.maxTilesY - 144].liquid = byte.MaxValue;
            Main.tile[index, (int) Main.maxTilesY - 144].lava = (byte) 32;
          }
        }
        UI.main.progress = 0.95f;
        int num64 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.0007999999797903);
        for (int index = 0; index < num64; ++index)
          WorldGen.TileRunner(WorldGen.genRand.Next((int) Main.maxTilesX), WorldGen.genRand.Next((int) Main.maxTilesY - 140, (int) Main.maxTilesY), WorldGen.genRand.Next(2, 7), WorldGen.genRand.Next(3, 7), 58, false, new Vector2(), false, true);
        UI.main.progress = 0.98f;
        WorldGen.AddHellHouses();
        UI.main.NextProgressStep(Lang.gen[19]);
        int num65 = WorldGen.genRand.Next(2, (int) ((double) Main.maxTilesX * 0.00499999988824129));
        for (int index = 0; index < num65; ++index)
        {
          UI.main.progress = (float) index / (float) num65;
          int i5 = WorldGen.genRand.Next(300, (int) Main.maxTilesX - 300);
          while (i5 > ((int) Main.maxTilesX >> 1) - 50 && i5 < ((int) Main.maxTilesX >> 1) + 50)
            i5 = WorldGen.genRand.Next(300, (int) Main.maxTilesX - 300);
          int j5 = (int) num5 - 20;
          while ((int) Main.tile[i5, j5].active == 0)
            ++j5;
          WorldGen.Lakinater(i5, j5);
        }
        UI.main.NextProgressStep(Lang.gen[58]);
        int x1;
        int num66;
        if (num9 == -1)
        {
          x1 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.0500000007450581), (int) ((double) Main.maxTilesX * 0.200000002980232));
          num66 = -1;
        }
        else
        {
          x1 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.800000011920929), (int) ((double) Main.maxTilesX * 0.949999988079071));
          num66 = 1;
        }
        int y1 = (Main.rockLayer + (int) Main.maxTilesY >> 1) + WorldGen.genRand.Next(-200, 200);
        WorldGen.MakeDungeon(x1, y1, 41, 7);
        UI.main.NextProgressStep(Lang.gen[20]);
        int num67 = (int) ((double) Main.maxTilesX * 0.000449999992270023);
        for (int index1 = 0; index1 < num67; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num67;
          int num11;
          int num15;
          int num16;
          bool flag1;
          do
          {
            int num17 = 0;
            int num18 = (int) Main.maxTilesX >> 1;
            int num19 = 200;
            num11 = WorldGen.genRand.Next(320, (int) Main.maxTilesX - 320);
            num15 = num11 - WorldGen.genRand.Next(200) - 100;
            num16 = num11 + WorldGen.genRand.Next(200) + 100;
            if (num15 < 285)
              num15 = 285;
            if (num16 > (int) Main.maxTilesX - 285)
              num16 = (int) Main.maxTilesX - 285;
            if (num11 > num18 - num19 && num11 < num18 + num19)
              flag1 = false;
            else if (num15 > num18 - num19 && num15 < num18 + num19)
              flag1 = false;
            else if (num16 > num18 - num19 && num16 < num18 + num19)
            {
              flag1 = false;
            }
            else
            {
              flag1 = true;
              for (int index2 = num15; flag1 && index2 < num16; ++index2)
              {
                int index3 = 0;
                while (index3 < Main.worldSurface)
                {
                  if ((int) Main.tile[index2, index3].active != 0 && Main.tileDungeon[(int) Main.tile[index2, index3].type])
                  {
                    flag1 = false;
                    break;
                  }
                  else
                    index3 += 5;
                }
              }
            }
            if (num17 < 200 && WorldGen.JungleX > num15 && WorldGen.JungleX < num16)
            {
              int num20 = num17 + 1;
              flag1 = false;
            }
          }
          while (!flag1);
          int num21 = 0;
          for (int i5 = num15; i5 < num16; ++i5)
          {
            if (num21 > 0)
              --num21;
            if (i5 == num11 || num21 == 0)
            {
              for (int j5 = (int) num5; j5 < Main.worldSurface - 1; ++j5)
              {
                if ((int) Main.tile[i5, j5].active != 0 || (int) Main.tile[i5, j5].wall > 0)
                {
                  if (i5 == num11)
                  {
                    num21 = 20;
                    WorldGen.ChasmRunner(i5, j5, WorldGen.genRand.Next(150) + 150, true);
                    break;
                  }
                  else if (WorldGen.genRand.Next(35) == 0 && num21 == 0)
                  {
                    num21 = 30;
                    bool makeOrb = true;
                    WorldGen.ChasmRunner(i5, j5, WorldGen.genRand.Next(50) + 50, makeOrb);
                    break;
                  }
                  else
                    break;
                }
              }
            }
            for (int index2 = (int) num5; index2 < Main.worldSurface - 1; ++index2)
            {
              if ((int) Main.tile[i5, index2].active != 0)
              {
                int num17 = index2 + WorldGen.genRand.Next(10, 14);
                for (int index3 = index2; index3 < num17; ++index3)
                {
                  if (((int) Main.tile[i5, index3].type == 59 || (int) Main.tile[i5, index3].type == 60) && (i5 >= num15 + WorldGen.genRand.Next(5) && i5 < num16 - WorldGen.genRand.Next(5)))
                    Main.tile[i5, index3].type = (byte) 0;
                }
                break;
              }
            }
          }
          double num22 = (double) (Main.worldSurface + 40);
          for (int index2 = num15; index2 < num16; ++index2)
          {
            num22 += (double) WorldGen.genRand.Next(-2, 3);
            if (num22 < (double) (Main.worldSurface + 30))
              num22 = (double) (Main.worldSurface + 30);
            if (num22 > (double) (Main.worldSurface + 50))
              num22 = (double) (Main.worldSurface + 50);
            int i5 = index2;
            bool flag2 = false;
            for (int j5 = (int) num5; (double) j5 < num22; ++j5)
            {
              if ((int) Main.tile[i5, j5].active != 0)
              {
                if ((int) Main.tile[i5, j5].type == 53 && i5 >= num15 + WorldGen.genRand.Next(5) && i5 <= num16 - WorldGen.genRand.Next(5))
                  Main.tile[i5, j5].type = (byte) 0;
                if ((int) Main.tile[i5, j5].type == 0 && j5 < Main.worldSurface - 1 && !flag2)
                {
                  WorldGen.grassSpread = 0;
                  WorldGen.SpreadGrass(i5, j5, 0, 23, true);
                }
                flag2 = true;
                if ((int) Main.tile[i5, j5].type == 1 && i5 >= num15 + WorldGen.genRand.Next(5) && i5 <= num16 - WorldGen.genRand.Next(5))
                  Main.tile[i5, j5].type = (byte) 25;
                if ((int) Main.tile[i5, j5].type == 2)
                  Main.tile[i5, j5].type = (byte) 23;
              }
            }
          }
          for (int index2 = num15; index2 < num16; ++index2)
          {
            for (int index3 = 0; index3 < (int) Main.maxTilesY - 50; ++index3)
            {
              if ((int) Main.tile[index2, index3].active != 0 && (int) Main.tile[index2, index3].type == 31)
              {
                int num17 = index2 - 13;
                int num18 = index2 + 13;
                int num19 = index3 - 13;
                int num20 = index3 + 13;
                for (int index4 = num17; index4 < num18; ++index4)
                {
                  if (index4 > 10 && index4 < (int) Main.maxTilesX - 10)
                  {
                    for (int index5 = num19; index5 < num20; ++index5)
                    {
                      if (WorldGen.genRand.Next(3) != 0 && Math.Abs(index4 - index2) + Math.Abs(index5 - index3) < 9 + WorldGen.genRand.Next(11) && (int) Main.tile[index4, index5].type != 31)
                      {
                        Main.tile[index4, index5].active = (byte) 1;
                        Main.tile[index4, index5].type = (byte) 25;
                        if (Math.Abs(index4 - index2) <= 1 && Math.Abs(index5 - index3) <= 1)
                          Main.tile[index4, index5].active = (byte) 0;
                      }
                      if ((int) Main.tile[index4, index5].type != 31 && Math.Abs(index4 - index2) <= 2 + WorldGen.genRand.Next(3) && Math.Abs(index5 - index3) <= 2 + WorldGen.genRand.Next(3))
                        Main.tile[index4, index5].active = (byte) 0;
                    }
                  }
                }
              }
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[21]);
        for (int index = 0; index < WorldGen.numMCaves; ++index)
        {
          int i5 = (int) WorldGen.mCave[index].X;
          int j5 = (int) WorldGen.mCave[index].Y;
          WorldGen.CaveOpenater(i5, j5);
          WorldGen.Cavinator(i5, j5, WorldGen.genRand.Next(40, 50));
        }
        int index7 = 0;
        int index8 = 0;
        int index9 = 20;
        int index10 = (int) Main.maxTilesX - 20;
        UI.main.NextProgressStep(Lang.gen[22]);
        for (int index1 = 0; index1 < 2; ++index1)
        {
          if (index1 == 0)
          {
            int num11 = 0;
            int num15 = WorldGen.genRand.Next(125, 200) + 50;
            if (num66 == 1)
              num15 = 275;
            int num16 = 0;
            float num17 = 1f;
            int index2 = 0;
            while ((int) Main.tile[num15 - 1, index2].active == 0)
              ++index2;
            index7 = index2;
            int num18 = index2 + WorldGen.genRand.Next(1, 5);
            for (int index3 = num15 - 1; index3 >= num11; --index3)
            {
              ++num16;
              if (num16 < 3)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.2f;
              else if (num16 < 6)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.15f;
              else if (num16 < 9)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
              else if (num16 < 15)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.07f;
              else if (num16 < 50)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
              else if (num16 < 75)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.04f;
              else if (num16 < 100)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.03f;
              else if (num16 < 125)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.02f;
              else if (num16 < 150)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
              else if (num16 < 175)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.005f;
              else if (num16 < 200)
                num17 += (float) WorldGen.genRand.Next(10, 20) * (1.0 / 1000.0);
              else if (num16 < 230)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
              else if (num16 < 235)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
              else if (num16 < 240)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
              else if (num16 < 245)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
              else if (num16 < (int) byte.MaxValue)
                num17 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
              if (num16 == 235)
                index10 = index3;
              if (num16 == 235)
                index9 = index3;
              int num19 = WorldGen.genRand.Next(15, 20);
              for (int index4 = 0; (double) index4 < (double) num18 + (double) num17 + (double) num19; ++index4)
              {
                if ((double) index4 < (double) num18 + (double) num17 * 0.75 - 3.0)
                {
                  Main.tile[index3, index4].active = (byte) 0;
                  if (index4 > num18)
                    Main.tile[index3, index4].liquid = byte.MaxValue;
                  else if (index4 == num18)
                    Main.tile[index3, index4].liquid = (byte) 127;
                }
                else if (index4 > num18)
                {
                  Main.tile[index3, index4].type = (byte) 53;
                  Main.tile[index3, index4].active = (byte) 1;
                }
                Main.tile[index3, index4].wall = (byte) 0;
              }
            }
          }
          else
          {
            int index2 = (int) Main.maxTilesX - WorldGen.genRand.Next(125, 200) - 50;
            int num11 = (int) Main.maxTilesX;
            if (num66 == -1)
              index2 = (int) Main.maxTilesX - 275;
            float num15 = 1f;
            int num16 = 0;
            int index3 = 0;
            while ((int) Main.tile[index2, index3].active == 0)
              ++index3;
            index8 = index3;
            int num17 = index3 + WorldGen.genRand.Next(1, 5);
            for (int index4 = index2; index4 < num11; ++index4)
            {
              ++num16;
              if (num16 < 3)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.2f;
              else if (num16 < 6)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.15f;
              else if (num16 < 9)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
              else if (num16 < 15)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.07f;
              else if (num16 < 50)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
              else if (num16 < 75)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.04f;
              else if (num16 < 100)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.03f;
              else if (num16 < 125)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.02f;
              else if (num16 < 150)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
              else if (num16 < 175)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.005f;
              else if (num16 < 200)
                num15 += (float) WorldGen.genRand.Next(10, 20) * (1.0 / 1000.0);
              else if (num16 < 230)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
              else if (num16 < 235)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
              else if (num16 < 240)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.1f;
              else if (num16 < 245)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.05f;
              else if (num16 < (int) byte.MaxValue)
                num15 += (float) WorldGen.genRand.Next(10, 20) * 0.01f;
              if (num16 == 235)
                index10 = index4;
              int num18 = WorldGen.genRand.Next(15, 20);
              for (int index5 = 0; (double) index5 < (double) num17 + (double) num15 + (double) num18; ++index5)
              {
                if ((double) index5 < (double) num17 + (double) num15 * 0.75 - 3.0 && index5 < Main.worldSurface - 2)
                {
                  Main.tile[index4, index5].active = (byte) 0;
                  if (index5 > num17)
                    Main.tile[index4, index5].liquid = byte.MaxValue;
                  else if (index5 == num17)
                    Main.tile[index4, index5].liquid = (byte) 127;
                }
                else if (index5 > num17)
                {
                  Main.tile[index4, index5].type = (byte) 53;
                  Main.tile[index4, index5].active = (byte) 1;
                }
                Main.tile[index4, index5].wall = (byte) 0;
              }
            }
          }
        }
        while ((int) Main.tile[index9, index7].active == 0)
          ++index7;
        int num68 = index7 + 1;
        while ((int) Main.tile[index10, index8].active == 0)
          ++index8;
        int num69 = index8 + 1;
        UI.main.NextProgressStep(Lang.gen[23]);
        for (int type = 63; type <= 68; ++type)
        {
          float num11 = 0.0f;
          if (type == 67)
            num11 = (float) Main.maxTilesX * 0.5f;
          else if (type == 66)
            num11 = (float) Main.maxTilesX * 0.45f;
          else if (type == 63)
            num11 = (float) Main.maxTilesX * 0.3f;
          else if (type == 65)
            num11 = (float) Main.maxTilesX * 0.25f;
          else if (type == 64)
            num11 = (float) Main.maxTilesX * 0.1f;
          else if (type == 68)
            num11 = (float) Main.maxTilesX * 0.05f;
          float num15 = num11 * 0.2f;
          for (int index1 = 0; (double) index1 < (double) num15; ++index1)
          {
            int i5 = WorldGen.genRand.Next((int) Main.maxTilesX);
            int j5;
            for (j5 = WorldGen.genRand.Next(Main.worldSurface, (int) Main.maxTilesY); (int) Main.tile[i5, j5].type != 1; j5 = WorldGen.genRand.Next(Main.worldSurface, (int) Main.maxTilesY))
              i5 = WorldGen.genRand.Next((int) Main.maxTilesX);
            WorldGen.TileRunner(i5, j5, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type, false, new Vector2(), false, true);
          }
        }
        for (int index1 = 0; index1 < 2; ++index1)
        {
          int num11 = 1;
          int num15 = 5;
          int num16 = (int) Main.maxTilesX - 5;
          if (index1 == 1)
          {
            num11 = -1;
            num15 = (int) Main.maxTilesX - 5;
            num16 = 5;
          }
          int index2 = num15;
          while (index2 != num16)
          {
            for (int index3 = 10; index3 < (int) Main.maxTilesY - 10; ++index3)
            {
              if ((int) Main.tile[index2, index3].active != 0 && (int) Main.tile[index2, index3].type == 53 && ((int) Main.tile[index2, index3 + 1].active != 0 && (int) Main.tile[index2, index3 + 1].type == 53))
              {
                int index4 = index2 + num11;
                int index5 = index3 + 1;
                if ((int) Main.tile[index4, index3].active == 0 && (int) Main.tile[index4, index3 + 1].active == 0)
                {
                  while ((int) Main.tile[index4, index5].active == 0)
                    ++index5;
                  int index6 = index5 - 1;
                  Main.tile[index2, index3].active = (byte) 0;
                  Main.tile[index4, index6].active = (byte) 1;
                  Main.tile[index4, index6].type = (byte) 53;
                }
              }
            }
            index2 += num11;
          }
        }
        UI.main.NextProgressStep(Lang.gen[24]);
        for (int index1 = 0; index1 < (int) Main.maxTilesX; ++index1)
        {
          UI.main.progress = (float) index1 / (float) Main.maxTilesX;
          for (int index2 = (int) Main.maxTilesY - 5; index2 > 0; --index2)
          {
            if ((int) Main.tile[index1, index2].active != 0)
            {
              if ((int) Main.tile[index1, index2].type == 53)
              {
                for (int index3 = index2; (int) Main.tile[index1, index3 + 1].active == 0 && index3 < (int) Main.maxTilesY - 5; ++index3)
                {
                  Main.tile[index1, index3 + 1].active = (byte) 1;
                  Main.tile[index1, index3 + 1].type = (byte) 53;
                }
              }
              else if ((int) Main.tile[index1, index2].type == 123)
              {
                for (int index3 = index2; (int) Main.tile[index1, index3 + 1].active == 0 && index3 < (int) Main.maxTilesY - 5; ++index3)
                {
                  Main.tile[index1, index3 + 1].active = (byte) 1;
                  Main.tile[index1, index3 + 1].type = (byte) 123;
                  Main.tile[index1, index3].active = (byte) 0;
                }
              }
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[25]);
        for (int index1 = 3; index1 < (int) Main.maxTilesX - 3; ++index1)
        {
          UI.main.progress = (float) index1 / (float) ((int) Main.maxTilesX - 4);
          bool flag1 = true;
          for (int index2 = 0; index2 < Main.worldSurface; ++index2)
          {
            if (flag1)
            {
              if ((int) Main.tile[index1, index2].wall == 2)
                Main.tile[index1, index2].wall = (byte) 0;
              if ((int) Main.tile[index1, index2].type != 53)
              {
                if ((int) Main.tile[index1 - 1, index2].wall == 2)
                  Main.tile[index1 - 1, index2].wall = (byte) 0;
                if ((int) Main.tile[index1 - 2, index2].wall == 2 && WorldGen.genRand.Next(2) == 0)
                  Main.tile[index1 - 2, index2].wall = (byte) 0;
                if ((int) Main.tile[index1 - 3, index2].wall == 2 && WorldGen.genRand.Next(2) == 0)
                  Main.tile[index1 - 3, index2].wall = (byte) 0;
                if ((int) Main.tile[index1 + 1, index2].wall == 2)
                  Main.tile[index1 + 1, index2].wall = (byte) 0;
                if ((int) Main.tile[index1 + 2, index2].wall == 2 && WorldGen.genRand.Next(2) == 0)
                  Main.tile[index1 + 2, index2].wall = (byte) 0;
                if ((int) Main.tile[index1 + 3, index2].wall == 2 && WorldGen.genRand.Next(2) == 0)
                  Main.tile[index1 + 3, index2].wall = (byte) 0;
                if ((int) Main.tile[index1, index2].active != 0)
                  flag1 = false;
              }
            }
            else if ((int) Main.tile[index1, index2].wall == 0 && (int) Main.tile[index1, index2 + 1].wall == 0 && ((int) Main.tile[index1, index2 + 2].wall == 0 && (int) Main.tile[index1, index2 + 3].wall == 0) && ((int) Main.tile[index1, index2 + 4].wall == 0 && (int) Main.tile[index1 - 1, index2].wall == 0 && ((int) Main.tile[index1 + 1, index2].wall == 0 && (int) Main.tile[index1 - 2, index2].wall == 0)) && ((int) Main.tile[index1 + 2, index2].wall == 0 && (int) Main.tile[index1, index2].active == 0 && ((int) Main.tile[index1, index2 + 1].active == 0 && (int) Main.tile[index1, index2 + 2].active == 0) && (int) Main.tile[index1, index2 + 3].active == 0))
              flag1 = true;
          }
        }
        UI.main.NextProgressStep(Lang.gen[26]);
        int y2 = (int) num6 + 20;
        int num70 = (int) Main.maxTilesX * (int) Main.maxTilesY / 50000;
        for (int index1 = 0; index1 < num70; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num70;
          int num11 = 0;
          while (num11 < 4096 && !WorldGen.Place3x2(WorldGen.genRand.Next(5, (int) Main.maxTilesX - 5), y2, 26))
            ++num11;
        }
        int num71 = (int) num5;
label_820:
        for (int index1 = 0; index1 < (int) Main.maxTilesX; ++index1)
        {
          int num11 = num71;
          Tile* tilePtr2 = tilePtr1 + (index1 * 1440 + num11);
          while ((int) tilePtr2->active == 0)
          {
            ++tilePtr2;
            if (++num11 >= Main.worldSurface - 1)
              goto label_820;
          }
          if ((int) tilePtr2->type == 60)
          {
            tilePtr2[-1].liquid = byte.MaxValue;
            tilePtr2[-2].liquid = byte.MaxValue;
          }
        }
label_831:
        for (int index1 = 400; index1 < (int) Main.maxTilesX - 400; ++index1)
        {
          int num11 = num71;
          Tile* tilePtr2 = tilePtr1 + (index1 * 1440 + num11);
          while ((int) tilePtr2->active == 0)
          {
            ++tilePtr2;
            if (++num11 >= Main.worldSurface - 1)
              goto label_831;
          }
          if ((int) tilePtr2->type == 53)
          {
            Tile* tilePtr3 = tilePtr2;
            while (num11 > num71)
            {
              --num11;
              --tilePtr3;
              if ((int) tilePtr3->liquid > 0)
                tilePtr3->liquid = (byte) 0;
              else
                break;
            }
          }
        }
        Liquid.QuickWater(1.0 / 3.0, 3, -1, 0.0);
        WorldGen.WaterCheck();
        int num72 = 0;
        Liquid.QuickSettleOn();
        do
        {
          int num11 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
          ++num72;
          float num15 = 0.0f;
          while (Liquid.numLiquid > 0)
          {
            float num16 = (float) (num11 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float) num11;
            if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num11)
              num11 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
            if ((double) num16 > (double) num15)
              num15 = num16;
            else
              num16 = num15;
            if (num72 == 1)
              UI.main.progress = (float) ((double) num16 * 0.333333343267441 + 0.333400011062622);
            int num17 = 10;
            if (num72 > num17)
              ;
            Liquid.UpdateLiquid();
          }
          WorldGen.WaterCheck();
        }
        while (num72 < 10);
        Liquid.QuickSettleOff();
        UI.main.NextProgressStep(Lang.gen[28]);
        int num73 = (int) Main.maxTilesX * (int) Main.maxTilesY / 50000;
        for (int index1 = 0; index1 < num73; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num73;
          int num11 = 0;
          do
            ;
          while (!WorldGen.AddLifeCrystal(WorldGen.genRand.Next(1, (int) Main.maxTilesX), WorldGen.genRand.Next((int) ((double) num6 + 20.0), (int) Main.maxTilesY)) && ++num11 < 10000);
        }
        UI.main.NextProgressStep(Lang.gen[29]);
        float num74 = (float) Main.maxTilesX * 0.0002380952f;
        int style = 0;
        int num75 = (int) ((double) num74 * 82.0);
        for (int index1 = 0; index1 < num75; ++index1)
        {
          if (style > 41)
            style = 0;
          UI.main.progress = (float) index1 / (float) num75;
          int num11 = 0;
          do
          {
            int i5 = WorldGen.genRand.Next(20, (int) Main.maxTilesX - 20);
            int index2 = WorldGen.genRand.Next((int) ((double) num6 + 20.0), (int) Main.maxTilesY - 300);
            while ((int) Main.tile[i5, index2].active == 0)
              ++index2;
            int j5 = index2 - 1;
            if (WorldGen.PlaceTile(i5, j5, 105, true, true, -1, style))
            {
              ++style;
              break;
            }
          }
          while (++num11 < 10000);
        }
        UI.main.NextProgressStep(Lang.gen[30]);
        int num76 = (int) Main.maxTilesX * (int) Main.maxTilesY / 62500;
        for (int index1 = 0; index1 < num76; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num76;
          int num11 = 0;
          do
          {
            int i5;
            int j5;
            int num15;
            do
            {
              i5 = WorldGen.genRand.Next(1, (int) Main.maxTilesX);
              j5 = index1 <= 3 ? WorldGen.genRand.Next((int) Main.maxTilesY - 200, (int) Main.maxTilesY - 50) : WorldGen.genRand.Next((int) ((double) num6 + 20.0), (int) Main.maxTilesY - 230);
              num15 = (int) Main.tile[i5, j5].wall;
            }
            while (num15 >= 7 && num15 <= 9);
            if (WorldGen.AddBuriedChest(i5, j5, 0, false, -1))
            {
              if (WorldGen.genRand.Next(2) == 0)
              {
                int j7 = j5;
                while ((int) Main.tile[i5, j7].type != 21 && j7 < (int) Main.maxTilesY - 300)
                  ++j7;
                if (j5 < (int) Main.maxTilesY - 300)
                {
                  WorldGen.MineHouse(i5, j7);
                  break;
                }
                else
                  break;
              }
              else
                break;
            }
          }
          while (++num11 < 5000);
        }
        UI.main.NextProgressStep(Lang.gen[31]);
        int num77 = (int) Main.maxTilesX / 200;
        for (int index1 = 0; index1 < num77; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num77;
          int num11 = 0;
          int i5;
          int j5;
          do
          {
            i5 = WorldGen.genRand.Next(300, (int) Main.maxTilesX - 300);
            j5 = WorldGen.genRand.Next((int) num5, Main.worldSurface);
          }
          while (((int) Main.tile[i5, j5].wall != 2 || (int) Main.tile[i5, j5].active != 0 || !WorldGen.AddBuriedChest(i5, j5, 0, true, -1)) && ++num11 < 2000);
        }
        UI.main.NextProgressStep(Lang.gen[32]);
        int num78 = 0;
        for (int index1 = 0; index1 < WorldGen.numJChests; ++index1)
        {
          UI.main.progress = (float) index1 / (float) WorldGen.numJChests;
          int contain = 211;
          switch (++num78)
          {
            case 1:
              if (!WorldGen.AddBuriedChest((int) WorldGen.JChest[index1].X + WorldGen.genRand.Next(2), (int) WorldGen.JChest[index1].Y, contain, false, -1))
              {
                WorldGen.KillTile((int) WorldGen.JChest[index1].X, (int) WorldGen.JChest[index1].Y);
                WorldGen.KillTile((int) WorldGen.JChest[index1].X, (int) WorldGen.JChest[index1].Y + 1);
                WorldGen.KillTile((int) WorldGen.JChest[index1].X + 1, (int) WorldGen.JChest[index1].Y);
                WorldGen.KillTile((int) WorldGen.JChest[index1].X + 1, (int) WorldGen.JChest[index1].Y + 1);
                WorldGen.AddBuriedChest((int) WorldGen.JChest[index1].X, (int) WorldGen.JChest[index1].Y, contain, false, -1);
                continue;
              }
              else
                continue;
            case 2:
              contain = 212;
              goto case 1;
            case 3:
              contain = 213;
              goto case 1;
            default:
              if (Main.rand.Next(2) == 0)
              {
                num78 = Main.rand.Next(6) != 0 ? 622 : 624;
                goto case 1;
              }
              else
                goto case 1;
          }
        }
        UI.main.NextProgressStep(Lang.gen[33]);
        int num79 = 0;
        int num80 = (int) (9.0 * (double) num74);
        for (int index1 = 0; index1 < num80; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num80;
          int contain = 187;
          if (++num79 == 1)
            contain = 186;
          else if (num79 == 2)
            contain = 277;
          else
            num79 = 0;
          for (bool flag1 = false; !flag1; {
            int i5;
            int j5;
            flag1 = WorldGen.AddBuriedChest(i5, j5, contain, false, -1);
          }
          )
          {
            i5 = WorldGen.genRand.Next(1, (int) Main.maxTilesX);
            for (j5 = WorldGen.genRand.Next(1, (int) Main.maxTilesY - 200); (int) Main.tile[i5, j5].liquid < 200 || (int) Main.tile[i5, j5].lava != 0; j5 = WorldGen.genRand.Next(1, (int) Main.maxTilesY - 200))
              i5 = WorldGen.genRand.Next(1, (int) Main.maxTilesX);
          }
        }
        for (int index1 = 0; index1 < WorldGen.numIslandHouses; ++index1)
          WorldGen.IslandHouse((int) WorldGen.fih[index1].X, (int) WorldGen.fih[index1].Y);
        UI.main.NextProgressStep(Lang.gen[34]);
        int num81 = (int) ((double) Main.maxTilesX * 0.0500000007450581);
        for (int index1 = 0; index1 < num81; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num81;
          for (int index2 = 0; index2 < 1000; ++index2)
          {
            int x2 = Main.rand.Next(200, (int) Main.maxTilesX - 200);
            int y2_1 = Main.rand.Next(Main.worldSurface, (int) Main.maxTilesY - 300);
            if ((int) Main.tile[x2, y2_1].wall == 0 && WorldGen.placeTrap(x2, y2_1, -1))
              break;
          }
        }
        UI.main.NextProgressStep(Lang.gen[35]);
        int num82 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * 0.0008);
        for (int index1 = 0; index1 < num82; ++index1)
        {
          float num11 = (float) index1 / (float) num82;
          UI.main.progress = num11;
          bool flag1 = false;
          int num15 = 0;
          while (!flag1)
          {
            int num16 = WorldGen.genRand.Next((int) num6, (int) Main.maxTilesY - 10);
            if ((double) num11 > 0.930000007152557)
              num16 = (int) Main.maxTilesY - 150;
            else if ((double) num11 > 0.75)
              num16 = (int) num5;
            int x2 = WorldGen.genRand.Next(1, (int) Main.maxTilesX - 1);
            bool flag2 = false;
            for (int y3 = num16; y3 < (int) Main.maxTilesY - 1; ++y3)
            {
              if (!flag2)
              {
                if ((int) Main.tile[x2, y3].active != 0 && Main.tileSolid[(int) Main.tile[x2, y3].type] && (int) Main.tile[x2, y3 - 1].lava == 0)
                  flag2 = true;
              }
              else if (WorldGen.PlacePot(x2, y3))
              {
                flag1 = true;
                break;
              }
              else
              {
                ++num15;
                if (num15 >= 10000)
                {
                  flag1 = true;
                  break;
                }
              }
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[36]);
        int num83 = (int) Main.maxTilesX / 200;
        for (int index1 = 0; index1 < num83; ++index1)
        {
          UI.main.progress = (float) index1 / (float) num83;
          int num11 = 0;
label_936:
          while (true)
          {
            int i5 = WorldGen.genRand.Next(5, (int) Main.maxTilesX - 5);
            int index2 = (int) Main.maxTilesY - 250;
            try
            {
              while ((int) Main.tile[i5, index2].active == 0 && (int) Main.tile[i5, index2].wall != 13 && (int) Main.tile[i5, index2].wall != 14)
              {
                if (++index2 == (int) Main.maxTilesY)
                  goto label_936;
              }
              int j5 = index2 - 1;
              if (!WorldGen.PlaceTile(i5, j5, 77, false, false, -1, 0))
              {
                if (++num11 >= 10000)
                  break;
              }
              else
                break;
            }
            catch
            {
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[37]);
        for (int index1 = 0; index1 < (int) Main.maxTilesX; ++index1)
        {
          int i5 = index1;
          bool flag1 = true;
          for (int j5 = 0; j5 < Main.worldSurface - 1; ++j5)
          {
            if ((int) Main.tile[i5, j5].active != 0)
            {
              if (flag1)
              {
                if ((int) Main.tile[i5, j5].type == 0)
                {
                  try
                  {
                    WorldGen.grassSpread = 0;
                    WorldGen.SpreadGrass(i5, j5, 0, 2, true);
                  }
                  catch
                  {
                    WorldGen.grassSpread = 0;
                    WorldGen.SpreadGrass(i5, j5, 0, 2, false);
                  }
                }
              }
              if ((double) j5 <= (double) num6)
                flag1 = false;
              else
                break;
            }
            else if ((int) Main.tile[i5, j5].wall == 0)
              flag1 = true;
          }
        }
        UI.main.NextProgressStep(Lang.gen[38]);
        for (int i5 = 5; i5 < (int) Main.maxTilesX - 5; ++i5)
        {
          if (WorldGen.genRand.Next(8) == 0)
          {
            Tile* tilePtr2 = tilePtr1 + (i5 * 1440 + 5);
            int j5 = 5;
            do
            {
              if ((int) tilePtr2->type == 53 && (int) tilePtr2->active != 0)
              {
                Tile* tilePtr3 = tilePtr2 - 1;
                if ((int) tilePtr3->active == 0 && (int) tilePtr3->wall == 0)
                {
                  if (i5 < 250 || i5 > (int) Main.maxTilesX - 250)
                  {
                    Tile* tilePtr4 = tilePtr3 - 1;
                    if ((int) tilePtr4->liquid == (int) byte.MaxValue)
                    {
                      Tile* tilePtr5 = tilePtr4 - 1;
                      if ((int) tilePtr5->liquid == (int) byte.MaxValue)
                      {
                        Tile* tilePtr6 = tilePtr5 - 1;
                        if ((int) tilePtr6->liquid == (int) byte.MaxValue)
                          WorldGen.PlaceTile(i5, j5 - 1, 81, true, false, -1, 0);
                        tilePtr5 = tilePtr6 + 1;
                      }
                      tilePtr4 = tilePtr5 + 1;
                    }
                    tilePtr3 = tilePtr4 + 1;
                  }
                  else if (i5 > 400 && i5 < (int) Main.maxTilesX - 400)
                    WorldGen.PlantCactus(i5, j5);
                }
                tilePtr2 = tilePtr3 + 1;
              }
              ++tilePtr2;
            }
            while (++j5 < Main.worldSurface - 1);
          }
        }
        int num84 = 5;
        while (true)
        {
          int index1 = ((int) Main.maxTilesX >> 1) + WorldGen.genRand.Next(-num84, num84 + 1);
          for (int index2 = 5; index2 <= Main.worldSurface; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0)
            {
              Main.spawnTileX = (short) index1;
              Main.spawnTileY = (short) index2;
              break;
            }
          }
          if ((int) Main.tile[(int) Main.spawnTileX, (int) Main.spawnTileY - 1].liquid != 0)
            ++num84;
          else
            break;
        }
        int index11 = NPC.NewNPC((int) Main.spawnTileX * 16, (int) Main.spawnTileY * 16, 22, 0);
        Main.npc[index11].homeTileX = Main.spawnTileX;
        Main.npc[index11].homeTileY = Main.spawnTileY;
        Main.npc[index11].direction = (sbyte) 1;
        Main.npc[index11].homeless = true;
        UI.main.NextProgressStep(Lang.gen[39]);
        for (int index1 = 0; (double) index1 < (double) Main.maxTilesX * 0.002; ++index1)
        {
          int num11 = (int) Main.maxTilesX;
          int num15 = WorldGen.genRand.Next((int) Main.maxTilesX);
          int num16 = num15 - WorldGen.genRand.Next(10) - 7;
          int num17 = num15 + WorldGen.genRand.Next(10) + 7;
          if (num16 < 0)
            num16 = 0;
          if (num17 > (int) Main.maxTilesX - 1)
            num17 = (int) Main.maxTilesX - 1;
          for (int i5 = num16; i5 < num17; ++i5)
          {
            for (int index2 = 5; index2 < Main.worldSurface - 1; ++index2)
            {
              if ((int) Main.tile[i5, index2].type == 2 && (int) Main.tile[i5, index2].active != 0 && (int) Main.tile[i5, index2 - 1].active == 0)
                WorldGen.PlaceTile(i5, index2 - 1, 27, true, false, -1, 0);
              if ((int) Main.tile[i5, index2].active != 0)
                break;
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[40]);
        for (int index1 = (int) ((double) Main.maxTilesX * 0.003) - 1; index1 >= 0; --index1)
        {
          int num11 = WorldGen.genRand.Next(50, (int) Main.maxTilesX - 50);
          int num15 = WorldGen.genRand.Next(25, 50);
          for (int i5 = num11 - num15; i5 < num11 + num15; ++i5)
          {
            for (int y3 = 20; y3 < Main.worldSurface; ++y3)
              WorldGen.GrowEpicTree(i5, y3);
          }
        }
        WorldGen.AddTrees();
        UI.main.NextProgressStep(Lang.gen[41]);
        for (int index1 = (int) ((double) Main.maxTilesX * 1.7) - 1; index1 >= 0; --index1)
          WorldGen.PlantAlch();
        UI.main.NextProgressStep(Lang.gen[42]);
        WorldGen.AddPlants();
        for (int i5 = 0; i5 < (int) Main.maxTilesX; ++i5)
        {
          for (int y3 = 1; y3 < (int) Main.maxTilesY; ++y3)
          {
            if ((int) Main.tile[i5, y3].active != 0)
            {
              if (y3 >= Main.worldSurface && (int) Main.tile[i5, y3].type == 70 && (int) Main.tile[i5, y3 - 1].active == 0)
              {
                WorldGen.GrowShroom(i5, y3);
                if ((int) Main.tile[i5, y3 - 1].active == 0)
                  WorldGen.PlaceTile(i5, y3 - 1, 71, true, false, -1, 0);
              }
              if ((int) Main.tile[i5, y3].type == 60 && (int) Main.tile[i5, y3 - 1].active == 0)
                WorldGen.PlaceTile(i5, y3 - 1, 61, true, false, -1, 0);
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[43]);
        for (int index1 = 0; index1 < (int) Main.maxTilesX; ++index1)
        {
          int num11 = 0;
          for (int index2 = 0; index2 < Main.worldSurface; ++index2)
          {
            if (num11 > 0 && (int) Main.tile[index1, index2].active == 0)
            {
              Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].type = (byte) 52;
              --num11;
            }
            else
              num11 = 0;
            if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type == 2 && WorldGen.genRand.Next(5) < 3)
              num11 = WorldGen.genRand.Next(1, 10);
          }
          int num15 = 0;
          for (int index2 = 0; index2 < (int) Main.maxTilesY; ++index2)
          {
            if (num15 > 0 && (int) Main.tile[index1, index2].active == 0)
            {
              Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].type = (byte) 62;
              --num15;
            }
            else
              num15 = 0;
            if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type == 60 && WorldGen.genRand.Next(5) < 3)
              num15 = WorldGen.genRand.Next(1, 10);
          }
        }
        UI.main.NextProgressStep(Lang.gen[44]);
        for (int index1 = (int) Main.maxTilesX / 200; index1 > 0; --index1)
        {
          int index2 = WorldGen.genRand.Next(20, (int) Main.maxTilesX - 20);
          int num11 = WorldGen.genRand.Next(5, 15);
          int num15 = WorldGen.genRand.Next(15, 30);
          for (int index3 = 30; index3 < Main.worldSurface - 1; ++index3)
          {
            if ((int) Main.tile[index2, index3].active != 0)
            {
              for (int index4 = index2 - num11; index4 < index2 + num11; ++index4)
              {
                for (int index5 = index3 - num15; index5 < index3 + num15; ++index5)
                {
                  if ((int) Main.tile[index4, index5].type == 3 || (int) Main.tile[index4, index5].type == 24)
                    Main.tile[index4, index5].frameX = (short) (WorldGen.genRand.Next(6, 8) * 18);
                }
              }
              break;
            }
          }
        }
        UI.main.NextProgressStep(Lang.gen[45]);
        for (int index1 = (int) Main.maxTilesX / 500; index1 > 0; --index1)
        {
          int index2 = WorldGen.genRand.Next(20, (int) Main.maxTilesX - 20);
          int num11 = WorldGen.genRand.Next(4, 10);
          int num15 = WorldGen.genRand.Next(15, 30);
          for (int index3 = 30; index3 < Main.worldSurface - 1; ++index3)
          {
            if ((int) Main.tile[index2, index3].active != 0)
            {
              for (int index4 = index2 - num11; index4 < index2 + num11; ++index4)
              {
                for (int index5 = index3 - num15; index5 < index3 + num15; ++index5)
                {
                  if ((int) Main.tile[index4, index5].type == 3 || (int) Main.tile[index4, index5].type == 24)
                    Main.tile[index4, index5].frameX = (short) 144;
                }
              }
              break;
            }
          }
        }
      }
      WorldGen.gen = false;
    }

    public static void GrowEpicTree(int i, int y)
    {
      int index1 = y;
      while ((int) Main.tile[i, index1].type == 20)
        ++index1;
      if ((int) Main.tile[i, index1].active == 0 || (int) Main.tile[i, index1].type != 2 || ((int) Main.tile[i, index1 - 1].wall != 0 || (int) Main.tile[i, index1 - 1].liquid != 0) || ((int) Main.tile[i - 1, index1].active == 0 || (int) Main.tile[i - 1, index1].type != 2 && (int) Main.tile[i - 1, index1].type != 23 && ((int) Main.tile[i - 1, index1].type != 60 && (int) Main.tile[i - 1, index1].type != 109)) && ((int) Main.tile[i + 1, index1].active == 0 || (int) Main.tile[i + 1, index1].type != 2 && (int) Main.tile[i + 1, index1].type != 23 && ((int) Main.tile[i + 1, index1].type != 60 && (int) Main.tile[i + 1, index1].type != 109)))
        return;
      int num1 = 1;
      if (!WorldGen.EmptyTileCheckTree(i - num1, i + num1, index1 - 55, index1 - 1))
        return;
      int num2 = WorldGen.genRand.Next(10);
      int num3 = WorldGen.genRand.Next(20, 30);
      for (int index2 = index1 - num3; index2 < index1; ++index2)
      {
        Main.tile[i, index2].frameNumber = (byte) WorldGen.genRand.Next(3);
        Main.tile[i, index2].active = (byte) 1;
        Main.tile[i, index2].type = (byte) 5;
        int num4 = WorldGen.genRand.Next(3);
        if (index2 == index1 - 1 || index2 == index1 - num3)
          num2 = 0;
        if (num2 == 1)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) (66 + num4 * 22);
        }
        else if (num2 == 2)
        {
          Main.tile[i, index2].frameX = (short) 22;
          Main.tile[i, index2].frameY = (short) (num4 * 22);
        }
        else if (num2 == 3)
        {
          Main.tile[i, index2].frameX = (short) 44;
          Main.tile[i, index2].frameY = (short) (66 + num4 * 22);
        }
        else if (num2 == 4)
        {
          Main.tile[i, index2].frameX = (short) 22;
          Main.tile[i, index2].frameY = (short) (66 + num4 * 22);
        }
        else if (num2 == 5)
        {
          Main.tile[i, index2].frameX = (short) 88;
          Main.tile[i, index2].frameY = (short) (num4 * 22);
        }
        else if (num2 == 6)
        {
          Main.tile[i, index2].frameX = (short) 66;
          Main.tile[i, index2].frameY = (short) (66 + num4 * 22);
        }
        else if (num2 == 7)
        {
          Main.tile[i, index2].frameX = (short) 110;
          Main.tile[i, index2].frameY = (short) (66 + num4 * 22);
        }
        else
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) (num4 * 22);
        }
        bool flag1 = num2 == 5 || num2 == 7;
        bool flag2 = num2 == 6 || num2 == 7;
        if (flag1)
        {
          Main.tile[i - 1, index2].active = (byte) 1;
          Main.tile[i - 1, index2].type = (byte) 5;
          int num5 = WorldGen.genRand.Next(3);
          if (WorldGen.genRand.Next(3) < 2)
          {
            Main.tile[i - 1, index2].frameX = (short) 44;
            Main.tile[i - 1, index2].frameY = (short) (198 + num5 * 22);
          }
          else
          {
            Main.tile[i - 1, index2].frameX = (short) 66;
            Main.tile[i - 1, index2].frameY = (short) (num5 * 22);
          }
        }
        if (flag2)
        {
          Main.tile[i + 1, index2].active = (byte) 1;
          Main.tile[i + 1, index2].type = (byte) 5;
          int num5 = WorldGen.genRand.Next(3);
          if (WorldGen.genRand.Next(3) < 2)
          {
            Main.tile[i + 1, index2].frameX = (short) 66;
            Main.tile[i + 1, index2].frameY = (short) (198 + num5 * 22);
          }
          else
          {
            Main.tile[i + 1, index2].frameX = (short) 88;
            Main.tile[i + 1, index2].frameY = (short) (66 + num5 * 22);
          }
        }
        do
        {
          num2 = WorldGen.genRand.Next(10);
        }
        while ((num2 == 5 || num2 == 7) && flag1 || (num2 == 6 || num2 == 7) && flag2);
      }
      int num6 = WorldGen.genRand.Next(3);
      bool flag3 = false;
      bool flag4 = false;
      if ((int) Main.tile[i - 1, index1].active != 0 && ((int) Main.tile[i - 1, index1].type == 2 || (int) Main.tile[i - 1, index1].type == 23 || ((int) Main.tile[i - 1, index1].type == 60 || (int) Main.tile[i - 1, index1].type == 109)))
        flag3 = true;
      if ((int) Main.tile[i + 1, index1].active != 0 && ((int) Main.tile[i + 1, index1].type == 2 || (int) Main.tile[i + 1, index1].type == 23 || ((int) Main.tile[i + 1, index1].type == 60 || (int) Main.tile[i + 1, index1].type == 109)))
        flag4 = true;
      if (!flag3)
      {
        if (num6 == 0)
          num6 = 2;
        if (num6 == 1)
          num6 = 3;
      }
      if (!flag4)
      {
        if (num6 == 0)
          num6 = 1;
        if (num6 == 2)
          num6 = 3;
      }
      if (flag4 && !flag3)
        num6 = 1;
      if (flag3 && !flag4)
        num6 = 2;
      if (num6 == 0 || num6 == 1)
      {
        Main.tile[i + 1, index1 - 1].active = (byte) 1;
        Main.tile[i + 1, index1 - 1].type = (byte) 5;
        int num4 = WorldGen.genRand.Next(3);
        if (num4 == 0)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 132;
        }
        if (num4 == 1)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 154;
        }
        if (num4 == 2)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 176;
        }
      }
      if (num6 == 0 || num6 == 2)
      {
        Main.tile[i - 1, index1 - 1].active = (byte) 1;
        Main.tile[i - 1, index1 - 1].type = (byte) 5;
        int num4 = WorldGen.genRand.Next(3);
        if (num4 == 0)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 132;
        }
        if (num4 == 1)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 154;
        }
        if (num4 == 2)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 176;
        }
      }
      int num7 = WorldGen.genRand.Next(3);
      if (num6 == 0)
      {
        if (num7 == 0)
        {
          Main.tile[i, index1 - 1].frameX = (short) 88;
          Main.tile[i, index1 - 1].frameY = (short) 132;
        }
        if (num7 == 1)
        {
          Main.tile[i, index1 - 1].frameX = (short) 88;
          Main.tile[i, index1 - 1].frameY = (short) 154;
        }
        if (num7 == 2)
        {
          Main.tile[i, index1 - 1].frameX = (short) 88;
          Main.tile[i, index1 - 1].frameY = (short) 176;
        }
      }
      else if (num6 == 1)
      {
        if (num7 == 0)
        {
          Main.tile[i, index1 - 1].frameX = (short) 0;
          Main.tile[i, index1 - 1].frameY = (short) 132;
        }
        if (num7 == 1)
        {
          Main.tile[i, index1 - 1].frameX = (short) 0;
          Main.tile[i, index1 - 1].frameY = (short) 154;
        }
        if (num7 == 2)
        {
          Main.tile[i, index1 - 1].frameX = (short) 0;
          Main.tile[i, index1 - 1].frameY = (short) 176;
        }
      }
      else if (num6 == 2)
      {
        if (num7 == 0)
        {
          Main.tile[i, index1 - 1].frameX = (short) 66;
          Main.tile[i, index1 - 1].frameY = (short) 132;
        }
        if (num7 == 1)
        {
          Main.tile[i, index1 - 1].frameX = (short) 66;
          Main.tile[i, index1 - 1].frameY = (short) 154;
        }
        if (num7 == 2)
        {
          Main.tile[i, index1 - 1].frameX = (short) 66;
          Main.tile[i, index1 - 1].frameY = (short) 176;
        }
      }
      if (WorldGen.genRand.Next(3) < 2)
      {
        int num4 = WorldGen.genRand.Next(3);
        if (num4 == 0)
        {
          Main.tile[i, index1 - num3].frameX = (short) 22;
          Main.tile[i, index1 - num3].frameY = (short) 198;
        }
        if (num4 == 1)
        {
          Main.tile[i, index1 - num3].frameX = (short) 22;
          Main.tile[i, index1 - num3].frameY = (short) 220;
        }
        if (num4 == 2)
        {
          Main.tile[i, index1 - num3].frameX = (short) 22;
          Main.tile[i, index1 - num3].frameY = (short) 242;
        }
      }
      else
      {
        int num4 = WorldGen.genRand.Next(3);
        if (num4 == 0)
        {
          Main.tile[i, index1 - num3].frameX = (short) 0;
          Main.tile[i, index1 - num3].frameY = (short) 198;
        }
        if (num4 == 1)
        {
          Main.tile[i, index1 - num3].frameX = (short) 0;
          Main.tile[i, index1 - num3].frameY = (short) 220;
        }
        if (num4 == 2)
        {
          Main.tile[i, index1 - num3].frameX = (short) 0;
          Main.tile[i, index1 - num3].frameY = (short) 242;
        }
      }
      WorldGen.RangeFrame(i - 2, index1 - num3 - 1, i + 2, index1 + 1);
      if (Main.netMode != 2)
        return;
      NetMessage.SendTileSquare(i, (int) ((double) index1 - (double) num3 * 0.5), num3 + 1);
    }

    public static unsafe void GrowTree(int i, int y)
    {
      int index1 = y;
      while ((int) Main.tile[i, index1].type == 20)
        ++index1;
      if (((int) Main.tile[i - 1, index1 - 1].liquid != 0 || (int) Main.tile[i - 1, index1 - 1].liquid != 0 || (int) Main.tile[i + 1, index1 - 1].liquid != 0) && (int) Main.tile[i, index1].type != 60 || (int) Main.tile[i, index1].active == 0 || ((int) Main.tile[i, index1].type != 2 && (int) Main.tile[i, index1].type != 23 && ((int) Main.tile[i, index1].type != 60 && (int) Main.tile[i, index1].type != 109) && (int) Main.tile[i, index1].type != 147 || (int) Main.tile[i, index1 - 1].wall != 0) || ((int) Main.tile[i - 1, index1].active == 0 || (int) Main.tile[i - 1, index1].type != 2 && (int) Main.tile[i - 1, index1].type != 23 && ((int) Main.tile[i - 1, index1].type != 60 && (int) Main.tile[i - 1, index1].type != 109) && (int) Main.tile[i - 1, index1].type != 147) && ((int) Main.tile[i + 1, index1].active == 0 || (int) Main.tile[i + 1, index1].type != 2 && (int) Main.tile[i + 1, index1].type != 23 && ((int) Main.tile[i + 1, index1].type != 60 && (int) Main.tile[i + 1, index1].type != 109) && (int) Main.tile[i + 1, index1].type != 147))
        return;
      int num1 = 1;
      int num2 = 16;
      if ((int) Main.tile[i, index1].type == 60)
        num2 += 5;
      if (!WorldGen.EmptyTileCheckTree(i - num1, i + num1, index1 - num2, index1 - 1))
        return;
      int num3 = WorldGen.genRand.Next(10);
      int num4 = WorldGen.genRand.Next(5, num2 + 1);
      for (int index2 = index1 - num4; index2 < index1; ++index2)
      {
        Main.tile[i, index2].frameNumber = (byte) WorldGen.genRand.Next(3);
        Main.tile[i, index2].active = (byte) 1;
        Main.tile[i, index2].type = (byte) 5;
        int num5 = WorldGen.genRand.Next(3);
        if (index2 == index1 - 1 || index2 == index1 - num4)
          num3 = 0;
        if (num3 == 1)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) (66 + num5 * 22);
        }
        else if (num3 == 2)
        {
          Main.tile[i, index2].frameX = (short) 22;
          Main.tile[i, index2].frameY = (short) (num5 * 22);
        }
        else if (num3 == 3)
        {
          Main.tile[i, index2].frameX = (short) 44;
          Main.tile[i, index2].frameY = (short) (66 + num5 * 22);
        }
        else if (num3 == 4)
        {
          Main.tile[i, index2].frameX = (short) 22;
          Main.tile[i, index2].frameY = (short) (66 + num5 * 22);
        }
        else if (num3 == 5)
        {
          Main.tile[i, index2].frameX = (short) 88;
          Main.tile[i, index2].frameY = (short) (num5 * 22);
        }
        else if (num3 == 6)
        {
          Main.tile[i, index2].frameX = (short) 66;
          Main.tile[i, index2].frameY = (short) (66 + num5 * 22);
        }
        else if (num3 == 7)
        {
          Main.tile[i, index2].frameX = (short) 110;
          Main.tile[i, index2].frameY = (short) (66 + num5 * 22);
        }
        else
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) (num5 * 22);
        }
        bool flag1 = num3 == 5 || num3 == 7;
        bool flag2 = num3 == 6 || num3 == 7;
        if (flag1)
        {
          Main.tile[i - 1, index2].active = (byte) 1;
          Main.tile[i - 1, index2].type = (byte) 5;
          int num6 = WorldGen.genRand.Next(3);
          if (WorldGen.genRand.Next(3) < 2)
          {
            Main.tile[i - 1, index2].frameX = (short) 44;
            Main.tile[i - 1, index2].frameY = (short) (198 + num6 * 22);
          }
          else
          {
            Main.tile[i - 1, index2].frameX = (short) 66;
            Main.tile[i - 1, index2].frameY = (short) (num6 * 22);
          }
        }
        if (flag2)
        {
          Main.tile[i + 1, index2].active = (byte) 1;
          Main.tile[i + 1, index2].type = (byte) 5;
          int num6 = WorldGen.genRand.Next(3);
          if (WorldGen.genRand.Next(3) < 2)
          {
            Main.tile[i + 1, index2].frameX = (short) 66;
            Main.tile[i + 1, index2].frameY = (short) (198 + num6 * 22);
          }
          else
          {
            Main.tile[i + 1, index2].frameX = (short) 88;
            Main.tile[i + 1, index2].frameY = (short) (66 + num6 * 22);
          }
        }
        do
        {
          num3 = WorldGen.genRand.Next(10);
        }
        while ((num3 == 5 || num3 == 7) && flag1 || (num3 == 6 || num3 == 7) && flag2);
      }
      int num7 = WorldGen.genRand.Next(3);
      bool flag3 = false;
      bool flag4 = false;
      fixed (Tile* tilePtr = &Main.tile[i - 1, index1])
      {
        if ((int) tilePtr->active != 0)
        {
          byte num5 = tilePtr->type;
          if ((uint) num5 <= 23U)
          {
            if ((int) num5 != 2 && (int) num5 != 23)
              goto label_41;
          }
          else if ((int) num5 != 60 && (int) num5 != 109 && (int) num5 != 147)
            goto label_41;
          flag3 = true;
        }
label_41:;
      }
      fixed (Tile* tilePtr = &Main.tile[i + 1, index1])
      {
        if ((int) tilePtr->active != 0)
        {
          byte num5 = tilePtr->type;
          if ((uint) num5 <= 23U)
          {
            if ((int) num5 != 2 && (int) num5 != 23)
              goto label_47;
          }
          else if ((int) num5 != 60 && (int) num5 != 109 && (int) num5 != 147)
            goto label_47;
          flag4 = true;
        }
label_47:;
      }
      if (!flag3)
      {
        if (num7 == 0)
          num7 = 2;
        if (num7 == 1)
          num7 = 3;
      }
      if (!flag4)
      {
        if (num7 == 0)
          num7 = 1;
        if (num7 == 2)
          num7 = 3;
      }
      if (flag4 && !flag3)
        num7 = 1;
      if (flag3 && !flag4)
        num7 = 2;
      if (num7 == 0 || num7 == 1)
      {
        Main.tile[i + 1, index1 - 1].active = (byte) 1;
        Main.tile[i + 1, index1 - 1].type = (byte) 5;
        int num5 = WorldGen.genRand.Next(3);
        if (num5 == 0)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 132;
        }
        if (num5 == 1)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 154;
        }
        if (num5 == 2)
        {
          Main.tile[i + 1, index1 - 1].frameX = (short) 22;
          Main.tile[i + 1, index1 - 1].frameY = (short) 176;
        }
      }
      if (num7 == 0 || num7 == 2)
      {
        Main.tile[i - 1, index1 - 1].active = (byte) 1;
        Main.tile[i - 1, index1 - 1].type = (byte) 5;
        int num5 = WorldGen.genRand.Next(3);
        if (num5 == 0)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 132;
        }
        if (num5 == 1)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 154;
        }
        if (num5 == 2)
        {
          Main.tile[i - 1, index1 - 1].frameX = (short) 44;
          Main.tile[i - 1, index1 - 1].frameY = (short) 176;
        }
      }
      int num8 = WorldGen.genRand.Next(3);
      if (num7 == 0)
      {
        if (num8 == 0)
        {
          Main.tile[i, index1 - 1].frameX = (short) 88;
          Main.tile[i, index1 - 1].frameY = (short) 132;
        }
        if (num8 == 1)
        {
          Main.tile[i, index1 - 1].frameX = (short) 88;
          Main.tile[i, index1 - 1].frameY = (short) 154;
        }
        if (num8 == 2)
        {
          Main.tile[i, index1 - 1].frameX = (short) 88;
          Main.tile[i, index1 - 1].frameY = (short) 176;
        }
      }
      else if (num7 == 1)
      {
        if (num8 == 0)
        {
          Main.tile[i, index1 - 1].frameX = (short) 0;
          Main.tile[i, index1 - 1].frameY = (short) 132;
        }
        if (num8 == 1)
        {
          Main.tile[i, index1 - 1].frameX = (short) 0;
          Main.tile[i, index1 - 1].frameY = (short) 154;
        }
        if (num8 == 2)
        {
          Main.tile[i, index1 - 1].frameX = (short) 0;
          Main.tile[i, index1 - 1].frameY = (short) 176;
        }
      }
      else if (num7 == 2)
      {
        if (num8 == 0)
        {
          Main.tile[i, index1 - 1].frameX = (short) 66;
          Main.tile[i, index1 - 1].frameY = (short) 132;
        }
        if (num8 == 1)
        {
          Main.tile[i, index1 - 1].frameX = (short) 66;
          Main.tile[i, index1 - 1].frameY = (short) 154;
        }
        if (num8 == 2)
        {
          Main.tile[i, index1 - 1].frameX = (short) 66;
          Main.tile[i, index1 - 1].frameY = (short) 176;
        }
      }
      if (WorldGen.genRand.Next(4) < 3)
      {
        int num5 = WorldGen.genRand.Next(3);
        if (num5 == 0)
        {
          Main.tile[i, index1 - num4].frameX = (short) 22;
          Main.tile[i, index1 - num4].frameY = (short) 198;
        }
        if (num5 == 1)
        {
          Main.tile[i, index1 - num4].frameX = (short) 22;
          Main.tile[i, index1 - num4].frameY = (short) 220;
        }
        if (num5 == 2)
        {
          Main.tile[i, index1 - num4].frameX = (short) 22;
          Main.tile[i, index1 - num4].frameY = (short) 242;
        }
      }
      else
      {
        int num5 = WorldGen.genRand.Next(3);
        if (num5 == 0)
        {
          Main.tile[i, index1 - num4].frameX = (short) 0;
          Main.tile[i, index1 - num4].frameY = (short) 198;
        }
        if (num5 == 1)
        {
          Main.tile[i, index1 - num4].frameX = (short) 0;
          Main.tile[i, index1 - num4].frameY = (short) 220;
        }
        if (num5 == 2)
        {
          Main.tile[i, index1 - num4].frameX = (short) 0;
          Main.tile[i, index1 - num4].frameY = (short) 242;
        }
      }
      WorldGen.RangeFrame(i - 2, index1 - num4 - 1, i + 2, index1 + 1);
      if (Main.netMode != 2)
        return;
      NetMessage.SendTileSquare(i, (int) ((double) index1 - (double) num4 * 0.5), num4 + 1);
    }

    public static void GrowShroom(int i, int y)
    {
      int index1 = y;
      if ((int) Main.tile[i - 1, index1 - 1].lava != 0 || (int) Main.tile[i - 1, index1 - 1].lava != 0 || ((int) Main.tile[i + 1, index1 - 1].lava != 0 || (int) Main.tile[i, index1].active == 0) || ((int) Main.tile[i, index1].type != 70 || (int) Main.tile[i, index1 - 1].wall != 0 || ((int) Main.tile[i - 1, index1].active == 0 || (int) Main.tile[i - 1, index1].type != 70)) || ((int) Main.tile[i + 1, index1].active == 0 || (int) Main.tile[i + 1, index1].type != 70 || !WorldGen.EmptyTileCheckShroom(i - 2, i + 2, index1 - 13, index1 - 1)))
        return;
      int num1 = WorldGen.genRand.Next(4, 11);
      for (int index2 = index1 - num1; index2 < index1; ++index2)
      {
        Main.tile[i, index2].frameNumber = (byte) WorldGen.genRand.Next(3);
        Main.tile[i, index2].active = (byte) 1;
        Main.tile[i, index2].type = (byte) 72;
        int num2 = WorldGen.genRand.Next(3);
        if (num2 == 0)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) 0;
        }
        if (num2 == 1)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) 18;
        }
        if (num2 == 2)
        {
          Main.tile[i, index2].frameX = (short) 0;
          Main.tile[i, index2].frameY = (short) 36;
        }
      }
      int num3 = WorldGen.genRand.Next(3);
      if (num3 == 0)
      {
        Main.tile[i, index1 - num1].frameX = (short) 36;
        Main.tile[i, index1 - num1].frameY = (short) 0;
      }
      if (num3 == 1)
      {
        Main.tile[i, index1 - num1].frameX = (short) 36;
        Main.tile[i, index1 - num1].frameY = (short) 18;
      }
      if (num3 == 2)
      {
        Main.tile[i, index1 - num1].frameX = (short) 36;
        Main.tile[i, index1 - num1].frameY = (short) 36;
      }
      WorldGen.RangeFrame(i - 2, index1 - num1 - 1, i + 2, index1 + 1);
      if (Main.netMode != 2)
        return;
      NetMessage.SendTileSquare(i, (int) ((double) index1 - (double) num1 * 0.5), num1 + 1);
    }

    public static void AddTrees()
    {
      for (int i = 1; i < (int) Main.maxTilesX - 1; ++i)
      {
        for (int y = 20; y < Main.worldSurface; ++y)
          WorldGen.GrowTree(i, y);
        int num = WorldGen.genRand.Next(12);
        if (num <= 6)
        {
          ++i;
          if (num == 0)
            ++i;
        }
      }
    }

    public static unsafe bool EmptyTileCheck(int startX, int endX, int startY, int endY)
    {
      if (startX < 0 || endX >= (int) Main.maxTilesX || (startY < 0 || endY >= (int) Main.maxTilesY))
        return false;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
label_3:
        int num = startY;
        Tile* tilePtr2 = tilePtr1 + (startX * 1440 + num);
        while ((int) tilePtr2->active == 0)
        {
          ++tilePtr2;
          if (++num > endY)
          {
            if (++startX > endX)
            {
              // ISSUE: __unpin statement
              __unpin(tilePtr1);
              return true;
            }
            else
              goto label_3;
          }
        }
        return false;
      }
    }

    public static unsafe bool EmptyTileCheckTree(int startX, int endX, int startY, int endY)
    {
      if (startX < 0 || endX >= (int) Main.maxTilesX || (startY < 0 || endY >= (int) Main.maxTilesY))
        return false;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        do
        {
          int num = startY;
          Tile* tilePtr2 = tilePtr1 + (startX * 1440 + num);
          do
          {
            if ((int) tilePtr2->active != 0)
            {
              switch (tilePtr2->type)
              {
                case (byte) 20:
                case (byte) 3:
                case (byte) 24:
                case (byte) 61:
                case (byte) 32:
                case (byte) 69:
                case (byte) 73:
                case (byte) 74:
                case (byte) 110:
                case (byte) 113:
                  break;
                default:
                  return false;
              }
            }
            ++tilePtr2;
          }
          while (++num <= endY);
        }
        while (++startX <= endX);
      }
      return true;
    }

    public static unsafe bool EmptyTileCheckShroom(int startX, int endX, int startY, int endY)
    {
      if (startX < 0 || endX >= (int) Main.maxTilesX || (startY < 0 || endY >= (int) Main.maxTilesY))
        return false;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
label_3:
        int num = startY;
        Tile* tilePtr2 = tilePtr1 + (startX * 1440 + num);
        while ((int) tilePtr2->active == 0 || (int) tilePtr2->type == 71)
        {
          ++tilePtr2;
          if (++num > endY)
          {
            if (++startX > endX)
            {
              // ISSUE: __unpin statement
              __unpin(tilePtr1);
              return true;
            }
            else
              goto label_3;
          }
        }
        return false;
      }
    }

    public static void StartHardmodeCallBack()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        4
      });
      WorldGen.hardLock = true;
      float num1 = (float) WorldGen.genRand.Next(300, 400) * (1.0 / 1000.0);
      int i1 = (int) ((double) Main.maxTilesX * (double) num1);
      int i2 = (int) ((double) Main.maxTilesX * (1.0 - (double) num1));
      int num2 = 1;
      if (WorldGen.genRand.Next(2) == 0)
      {
        int num3 = i2;
        i2 = i1;
        i1 = num3;
        num2 = -1;
      }
      Vector2i vector2i1 = new Vector2i();
      vector2i1.X = (int) Main.maxTilesX;
      vector2i1.Y = (int) Main.maxTilesY;
      Vector2i vector2i2 = new Vector2i();
      WorldGen.GERunner(i1, new Vector2((float) (3 * num2), 5f), true, ref vector2i1, ref vector2i2);
      WorldGen.GERunner(i2, new Vector2((float) (-3 * num2), 5f), false, ref vector2i1, ref vector2i2);
      Netplay.ResetSections(ref vector2i1, ref vector2i2);
      Main.hardMode = true;
      WorldGen.hardLock = false;
    }

    public static void StartHardmode()
    {
      if (Main.netMode == 1 || Main.hardMode)
        return;
      new Thread(new ThreadStart(WorldGen.StartHardmodeCallBack))
      {
        IsBackground = true
      }.Start();
      NetMessage.SendText(15, 50, (int) byte.MaxValue, 130, -1);
      UI.SetTriggerStateForAll(Trigger.UnlockedHardMode);
    }

    public static unsafe bool PlaceDoor(int i, int j, int type)
    {
      if (j >= 2 && j < (int) Main.maxTilesY - 2)
      {
        fixed (Tile* tilePtr = &Main.tile[i, j])
        {
          if ((int) tilePtr[-2].active != 0 && Main.tileSolid[(int) tilePtr[-2].type] && ((int) tilePtr[2].active != 0 && Main.tileSolid[(int) tilePtr[2].type]))
          {
            tilePtr[-1].active = (byte) 1;
            tilePtr[-1].type = (byte) 10;
            tilePtr[-1].frameY = (short) 0;
            tilePtr[-1].frameX = (short) (WorldGen.genRand.Next(3) * 18);
            tilePtr->active = (byte) 1;
            tilePtr->type = (byte) 10;
            tilePtr->frameY = (short) 18;
            tilePtr->frameX = (short) (WorldGen.genRand.Next(3) * 18);
            tilePtr[1].active = (byte) 1;
            tilePtr[1].type = (byte) 10;
            tilePtr[1].frameY = (short) 36;
            tilePtr[1].frameX = (short) (WorldGen.genRand.Next(3) * 18);
            return true;
          }
          else
          {
            // ISSUE: __unpin statement
            __unpin(tilePtr);
          }
        }
      }
      return false;
    }

    public static bool CanCloseDoor(int i, int j)
    {
      int i1 = i;
      int num1 = j;
      switch (Main.tile[i, j].frameX)
      {
        case (short) 18:
          --i1;
          break;
        case (short) 36:
          ++i1;
          break;
      }
      int num2 = (int) Main.tile[i, j].frameY;
      int j1 = num1 - num2 / 18;
      return !Collision.AnyPlayerOrNPC(i1, j1, 3);
    }

    public static bool CloseDoor(int i, int j, bool forced = false)
    {
      int num1 = 0;
      int i1 = i;
      int num2 = j;
      switch (Main.tile[i, j].frameX)
      {
        case (short) 0:
          num1 = 1;
          break;
        case (short) 18:
          --i1;
          num1 = 1;
          break;
        case (short) 36:
          ++i1;
          num1 = -1;
          break;
        case (short) 54:
          num1 = -1;
          break;
      }
      int num3 = (int) Main.tile[i, j].frameY;
      int j1 = num2 - num3 / 18;
      if (!forced && Collision.AnyPlayerOrNPC(i1, j1, 3))
        return false;
      int num4 = i1;
      if (num1 == -1)
        --num4;
      for (int index1 = num4; index1 < num4 + 2; ++index1)
      {
        for (int index2 = j1; index2 < j1 + 3; ++index2)
        {
          if (index1 == i1)
          {
            Main.tile[index1, index2].type = (byte) 10;
            Main.tile[index1, index2].frameX = (short) (WorldGen.genRand.Next(3) * 18);
          }
          else
            Main.tile[index1, index2].active = (byte) 0;
        }
      }
      if (Main.netMode != 1)
      {
        for (int index = 0; index < 3; ++index)
        {
          if (WorldGen.numNoWire < 999)
          {
            WorldGen.noWire[WorldGen.numNoWire].X = (short) i1;
            WorldGen.noWire[WorldGen.numNoWire].Y = (short) (j1 + index);
            ++WorldGen.numNoWire;
          }
        }
      }
      bool flag = WorldGen.tileFrameRecursion;
      WorldGen.tileFrameRecursion = false;
      WorldGen.TileFrame(i1 - 1, j1 - 1, 0);
      WorldGen.TileFrame(i1 - 1, j1, 0);
      WorldGen.TileFrame(i1 - 1, j1 + 1, 0);
      WorldGen.TileFrame(i1 - 1, j1 + 2, 0);
      WorldGen.TileFrame(i1, j1 - 1, 0);
      WorldGen.TileFrame(i1, j1, 0);
      WorldGen.TileFrame(i1, j1 + 1, 0);
      WorldGen.TileFrame(i1, j1 + 2, 0);
      WorldGen.TileFrame(i1 + 1, j1 - 1, 0);
      WorldGen.TileFrame(i1 + 1, j1, 0);
      WorldGen.TileFrame(i1 + 1, j1 + 1, 0);
      WorldGen.TileFrame(i1 + 1, j1 + 2, 0);
      WorldGen.tileFrameRecursion = flag;
      Main.PlaySound(9, i * 16, j * 16, 1);
      return true;
    }

    public static unsafe bool AddLifeCrystal(int i, int j)
    {
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        Tile* tilePtr2 = tilePtr1 + (i * 1440 + j);
        while (j < (int) Main.maxTilesY)
        {
          if ((int) tilePtr2->active != 0 && Main.tileSolid[(int) tilePtr2->type])
          {
            if ((int) tilePtr2[-2].lava != 0 || (int) tilePtr2[-1442].lava != 0 || !WorldGen.EmptyTileCheck(i - 1, i, j - 2, j - 1))
              return false;
            tilePtr2[-1442].active = (byte) 1;
            tilePtr2[-1442].type = (byte) 12;
            tilePtr2[-1442].frameX = (short) 0;
            tilePtr2[-1442].frameY = (short) 0;
            tilePtr2[-1441].active = (byte) 1;
            tilePtr2[-1441].type = (byte) 12;
            tilePtr2[-1441].frameX = (short) 0;
            tilePtr2[-1441].frameY = (short) 18;
            tilePtr2[-2].active = (byte) 1;
            tilePtr2[-2].type = (byte) 12;
            tilePtr2[-2].frameX = (short) 18;
            tilePtr2[-2].frameY = (short) 0;
            tilePtr2[-1].active = (byte) 1;
            tilePtr2[-1].type = (byte) 12;
            tilePtr2[-1].frameX = (short) 18;
            tilePtr2[-1].frameY = (short) 18;
            return true;
          }
          else
          {
            ++j;
            ++tilePtr2;
          }
        }
      }
      return false;
    }

    public static void AddShadowOrb(int x, int y)
    {
      if (x < 10 || x > (int) Main.maxTilesX - 10 || (y < 10 || y > (int) Main.maxTilesY - 10))
        return;
      for (int index1 = x - 1; index1 < x + 1; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type == 31)
            return;
        }
      }
      Main.tile[x - 1, y - 1].active = (byte) 1;
      Main.tile[x - 1, y - 1].type = (byte) 31;
      Main.tile[x - 1, y - 1].frameX = (short) 0;
      Main.tile[x - 1, y - 1].frameY = (short) 0;
      Main.tile[x, y - 1].active = (byte) 1;
      Main.tile[x, y - 1].type = (byte) 31;
      Main.tile[x, y - 1].frameX = (short) 18;
      Main.tile[x, y - 1].frameY = (short) 0;
      Main.tile[x - 1, y].active = (byte) 1;
      Main.tile[x - 1, y].type = (byte) 31;
      Main.tile[x - 1, y].frameX = (short) 0;
      Main.tile[x - 1, y].frameY = (short) 18;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].type = (byte) 31;
      Main.tile[x, y].frameX = (short) 18;
      Main.tile[x, y].frameY = (short) 18;
    }

    public static void AddHellHouses()
    {
      int num1 = (int) ((double) Main.maxTilesX * 0.25);
      for (int i = num1; i < (int) Main.maxTilesX - num1; ++i)
      {
        int j = (int) Main.maxTilesY - 40;
        while ((int) Main.tile[i, j].active != 0 || (int) Main.tile[i, j].liquid > 0)
          --j;
        if ((int) Main.tile[i, j + 1].active != 0)
        {
          int type;
          int wall;
          if (WorldGen.genRand.Next(10) == 0)
          {
            type = 76;
            wall = 13;
          }
          else
          {
            type = 75;
            wall = 14;
          }
          WorldGen.HellHouse(i, j, type, wall);
          i += WorldGen.genRand.Next(15, 80);
        }
      }
      float num2 = (float) Main.maxTilesX * 0.0002380952f;
      for (int index1 = 0; (double) index1 < 200.0 * (double) num2; ++index1)
      {
        int num3 = 0;
        bool flag1 = false;
        while (!flag1)
        {
          ++num3;
          int index2 = WorldGen.genRand.Next((int) ((double) Main.maxTilesX * 0.2), (int) ((double) Main.maxTilesX * 0.8));
          int j = WorldGen.genRand.Next((int) Main.maxTilesY - 300, (int) Main.maxTilesY - 20);
          if ((int) Main.tile[index2, j].active != 0 && ((int) Main.tile[index2, j].type == 75 || (int) Main.tile[index2, j].type == 76))
          {
            int num4 = 0;
            if ((int) Main.tile[index2 - 1, j].wall > 0)
              num4 = -1;
            else if ((int) Main.tile[index2 + 1, j].wall > 0)
              num4 = 1;
            if ((int) Main.tile[index2 + num4, j].active == 0 && (int) Main.tile[index2 + num4, j + 1].active == 0)
            {
              bool flag2 = false;
              for (int index3 = index2 - 8; index3 < index2 + 8; ++index3)
              {
                for (int index4 = j - 8; index4 < j + 8; ++index4)
                {
                  if ((int) Main.tile[index3, index4].active != 0 && (int) Main.tile[index3, index4].type == 4)
                  {
                    flag2 = true;
                    break;
                  }
                }
              }
              if (!flag2)
              {
                WorldGen.PlaceTile(index2 + num4, j, 4, true, true, -1, 7);
                flag1 = true;
              }
            }
          }
          if (num3 > 1000)
            flag1 = true;
        }
      }
    }

    public static void HellHouse(int i, int j, int type, int wall)
    {
      int width = WorldGen.genRand.Next(8, 20);
      int num1 = WorldGen.genRand.Next(1, 3);
      int num2 = WorldGen.genRand.Next(4, 13);
      int i1 = i;
      int j1 = j;
      for (int index = 0; index < num1; ++index)
      {
        int height = WorldGen.genRand.Next(5, 9);
        WorldGen.HellRoom(i1, j1, width, height, type, wall);
        j1 -= height;
      }
      int j2 = j;
      for (int index = 0; index < num2; ++index)
      {
        int height = WorldGen.genRand.Next(5, 9);
        j2 += height;
        WorldGen.HellRoom(i1, j2, width, height, type, wall);
      }
      for (int index1 = i - (width >> 1); index1 <= i + (width >> 1); ++index1)
      {
        int index2 = j;
        while (index2 < (int) Main.maxTilesY && ((int) Main.tile[index1, index2].active != 0 && ((int) Main.tile[index1, index2].type == 76 || (int) Main.tile[index1, index2].type == 75) || ((int) Main.tile[i, index2].wall == 13 || (int) Main.tile[i, index2].wall == 14)))
          ++index2;
        int num3 = 6 + WorldGen.genRand.Next(3);
        while (index2 < (int) Main.maxTilesY && (int) Main.tile[index1, index2].active == 0)
        {
          --num3;
          Main.tile[index1, index2].active = (byte) 1;
          Main.tile[index1, index2].type = (byte) 57;
          ++index2;
          if (num3 <= 0)
            break;
        }
      }
      int index3 = j;
      while (index3 < (int) Main.maxTilesY && ((int) Main.tile[i, index3].active != 0 && ((int) Main.tile[i, index3].type == 76 || (int) Main.tile[i, index3].type == 75) || ((int) Main.tile[i, index3].wall == 13 || (int) Main.tile[i, index3].wall == 14)))
        ++index3;
      int index4 = index3 - 1;
      int upperBound = index4;
      while ((int) Main.tile[i, index4].active != 0 && ((int) Main.tile[i, index4].type == 76 || (int) Main.tile[i, index4].type == 75) || ((int) Main.tile[i, index4].wall == 13 || (int) Main.tile[i, index4].wall == 14))
      {
        --index4;
        if ((int) Main.tile[i, index4].active != 0 && ((int) Main.tile[i, index4].type == 76 || (int) Main.tile[i, index4].type == 75))
        {
          int num3 = WorldGen.genRand.Next(i - (width >> 1) + 1, i + (width >> 1) - 1);
          int num4 = WorldGen.genRand.Next(i - (width >> 1) + 1, i + (width >> 1) - 1);
          if (num3 > num4)
          {
            int num5 = num3;
            num3 = num4;
            num4 = num5;
          }
          if (num3 == num4)
          {
            if (num3 < i)
              ++num4;
            else
              --num3;
          }
          for (int index1 = num3; index1 <= num4; ++index1)
          {
            if ((int) Main.tile[index1, index4 - 1].wall == 13)
              Main.tile[index1, index4].wall = (byte) 13;
            if ((int) Main.tile[index1, index4 - 1].wall == 14)
              Main.tile[index1, index4].wall = (byte) 14;
            Main.tile[index1, index4].type = (byte) 19;
            Main.tile[index1, index4].active = (byte) 1;
          }
          --index4;
        }
      }
      int lowerBound = index4;
      float num6 = (float) ((upperBound - lowerBound) * width) * 0.02f;
      for (int index1 = 0; (double) index1 < (double) num6; ++index1)
      {
        int num3 = WorldGen.genRand.Next(i - (width >> 1), i + (width >> 1) + 1);
        int num4 = WorldGen.genRand.Next(lowerBound, upperBound);
        int num5 = WorldGen.genRand.Next(3, 8);
        float num7 = (float) num5 * 0.4f;
        float num8 = num7 * num7;
        for (int index2 = num3 - num5; index2 <= num3 + num5; ++index2)
        {
          float num9 = (float) (index2 - num3);
          float num10 = num9 * num9;
          for (int index5 = num4 - num5; index5 <= num4 + num5; ++index5)
          {
            float num11 = (float) (index5 - num4);
            if ((double) (num10 + num11 * num11) < (double) num8)
            {
              try
              {
                if ((int) Main.tile[index2, index5].type == 76 || (int) Main.tile[index2, index5].type == 19)
                  Main.tile[index2, index5].active = (byte) 0;
                Main.tile[index2, index5].wall = (byte) 0;
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
      if (j > (int) Main.maxTilesY - 40)
        return;
      width >>= 1;
      for (int index1 = i - width; index1 <= i + width; ++index1)
      {
        for (int index2 = j - height; index2 <= j; ++index2)
        {
          try
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) type;
            Main.tile[index1, index2].liquid = (byte) 0;
            Main.tile[index1, index2].lava = (byte) 0;
          }
          catch
          {
          }
        }
      }
      for (int index1 = i - width + 1; index1 <= i + width - 1; ++index1)
      {
        for (int index2 = j - height + 1; index2 <= j - 1; ++index2)
        {
          try
          {
            Main.tile[index1, index2].active = (byte) 0;
            Main.tile[index1, index2].wall = (byte) wall;
            Main.tile[index1, index2].liquid = (byte) 0;
            Main.tile[index1, index2].lava = (byte) 0;
          }
          catch
          {
          }
        }
      }
    }

    public static void MakeDungeon(int x, int y, int tileType = 41, int wallType = 7)
    {
      int num1 = WorldGen.genRand.Next(3);
      int num2 = WorldGen.genRand.Next(3);
      if (num1 == 1)
        tileType = 43;
      else if (num1 == 2)
        tileType = 44;
      if (num2 == 1)
        wallType = 8;
      else if (num2 == 2)
        wallType = 9;
      WorldGen.numDDoors = 0;
      WorldGen.numDPlats = 0;
      WorldGen.numDRooms = 0;
      WorldGen.dungeonX = x;
      WorldGen.dungeonY = y;
      WorldGen.dMinX = x;
      WorldGen.dMaxX = x;
      WorldGen.dMinY = y;
      WorldGen.dMaxY = y;
      WorldGen.dxStrength1 = (double) WorldGen.genRand.Next(25, 30);
      WorldGen.dyStrength1 = (double) WorldGen.genRand.Next(20, 25);
      WorldGen.dxStrength2 = (double) WorldGen.genRand.Next(35, 50);
      WorldGen.dyStrength2 = (double) WorldGen.genRand.Next(10, 15);
      int num3 = (int) Main.maxTilesX / 60;
      int num4 = num3 + WorldGen.genRand.Next(num3 / 3);
      int num5 = num4;
      int num6 = 5;
      WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      while (num4 > 0)
      {
        if (WorldGen.dungeonX < WorldGen.dMinX)
          WorldGen.dMinX = WorldGen.dungeonX;
        if (WorldGen.dungeonX > WorldGen.dMaxX)
          WorldGen.dMaxX = WorldGen.dungeonX;
        if (WorldGen.dungeonY > WorldGen.dMaxY)
          WorldGen.dMaxY = WorldGen.dungeonY;
        --num4;
        UI.main.progress = (float) (num5 - num4) * 0.6f / (float) num5;
        if (num6 > 0)
          --num6;
        if (num6 == 0 & WorldGen.genRand.Next(3) == 0)
        {
          num6 = 5;
          if (WorldGen.genRand.Next(2) == 0)
          {
            int num7 = WorldGen.dungeonX;
            int num8 = WorldGen.dungeonY;
            WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, false);
            if (WorldGen.genRand.Next(2) == 0)
              WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, false);
            WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
            WorldGen.dungeonX = num7;
            WorldGen.dungeonY = num8;
          }
          else
            WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
        }
        else
          WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, false);
      }
      WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      int num9 = (int) WorldGen.dRoom[0].X;
      int num10 = (int) WorldGen.dRoom[0].Y;
      for (int index = 1; index < WorldGen.numDRooms; ++index)
      {
        if ((int) WorldGen.dRoom[index].Y < num10)
        {
          num9 = (int) WorldGen.dRoom[index].X;
          num10 = (int) WorldGen.dRoom[index].Y;
        }
      }
      WorldGen.dungeonX = num9;
      WorldGen.dungeonY = num10;
      WorldGen.dEnteranceX = num9;
      WorldGen.dSurface = false;
      int num11 = 5;
      while (!WorldGen.dSurface)
      {
        if (num11 > 0)
          --num11;
        if (num11 == 0 & WorldGen.genRand.Next(5) == 0 && WorldGen.dungeonY > Main.worldSurface + 50)
        {
          num11 = 10;
          int num7 = WorldGen.dungeonX;
          int num8 = WorldGen.dungeonY;
          WorldGen.DungeonHalls(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType, true);
          WorldGen.DungeonRoom(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
          WorldGen.dungeonX = num7;
          WorldGen.dungeonY = num8;
        }
        WorldGen.DungeonStairs(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      }
      WorldGen.DungeonEnt(WorldGen.dungeonX, WorldGen.dungeonY, tileType, wallType);
      UI.main.progress = 0.65f;
      for (int index1 = 0; index1 < WorldGen.numDRooms; ++index1)
      {
        for (int index2 = (int) WorldGen.dRoom[index1].L; index2 <= (int) WorldGen.dRoom[index1].R; ++index2)
        {
          int index3 = (int) WorldGen.dRoom[index1].T - 1;
          if ((int) Main.tile[index2, index3].active == 0)
          {
            WorldGen.DPlat[WorldGen.numDPlats].X = (short) index2;
            WorldGen.DPlat[WorldGen.numDPlats].Y = (short) index3;
            ++WorldGen.numDPlats;
            break;
          }
        }
        for (int index2 = (int) WorldGen.dRoom[index1].L; index2 <= (int) WorldGen.dRoom[index1].R; ++index2)
        {
          int index3 = (int) WorldGen.dRoom[index1].B + 1;
          if ((int) Main.tile[index2, index3].active == 0)
          {
            WorldGen.DPlat[WorldGen.numDPlats].X = (short) index2;
            WorldGen.DPlat[WorldGen.numDPlats].Y = (short) index3;
            ++WorldGen.numDPlats;
            break;
          }
        }
        for (int index2 = (int) WorldGen.dRoom[index1].T; index2 <= (int) WorldGen.dRoom[index1].B; ++index2)
        {
          int index3 = (int) WorldGen.dRoom[index1].L - 1;
          if ((int) Main.tile[index3, index2].active == 0)
          {
            WorldGen.dDoor[WorldGen.numDDoors].X = (short) index3;
            WorldGen.dDoor[WorldGen.numDDoors].Y = (short) index2;
            WorldGen.dDoor[WorldGen.numDDoors].Pos = (short) -1;
            ++WorldGen.numDDoors;
            break;
          }
        }
        for (int index2 = (int) WorldGen.dRoom[index1].T; index2 <= (int) WorldGen.dRoom[index1].B; ++index2)
        {
          int index3 = (int) WorldGen.dRoom[index1].R + 1;
          if ((int) Main.tile[index3, index2].active == 0)
          {
            WorldGen.dDoor[WorldGen.numDDoors].X = (short) index3;
            WorldGen.dDoor[WorldGen.numDDoors].Y = (short) index2;
            WorldGen.dDoor[WorldGen.numDDoors].Pos = (short) 1;
            ++WorldGen.numDDoors;
            break;
          }
        }
      }
      UI.main.progress = 0.7f;
      int num12 = 0;
      int num13 = 1000;
      int num14 = 0;
      while (num14 < (int) Main.maxTilesX / 100)
      {
        ++num12;
        int index1 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index2 = WorldGen.genRand.Next(Main.worldSurface + 25, WorldGen.dMaxY);
        int num7 = index1;
        if ((int) Main.tile[index1, index2].wall == wallType && (int) Main.tile[index1, index2].active == 0)
        {
          int num8 = 1;
          if (WorldGen.genRand.Next(2) == 0)
            num8 = -1;
          while ((int) Main.tile[index1, index2].active == 0)
            index2 += num8;
          if ((int) Main.tile[index1 - 1, index2].active != 0 && (int) Main.tile[index1 + 1, index2].active != 0 && ((int) Main.tile[index1 - 1, index2 - num8].active == 0 && (int) Main.tile[index1 + 1, index2 - num8].active == 0))
          {
            ++num14;
            for (int index3 = WorldGen.genRand.Next(5, 13); (int) Main.tile[index1 - 1, index2].active != 0 && (int) Main.tile[index1, index2 + num8].active != 0 && ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2 - num8].active == 0) && index3 > 0; --index3)
            {
              Main.tile[index1, index2].type = (byte) 48;
              if ((int) Main.tile[index1 - 1, index2 - num8].active == 0 && (int) Main.tile[index1 + 1, index2 - num8].active == 0)
              {
                Main.tile[index1, index2 - num8].type = (byte) 48;
                Main.tile[index1, index2 - num8].active = (byte) 1;
              }
              --index1;
            }
            int num15 = WorldGen.genRand.Next(5, 13);
            for (int index3 = num7 + 1; (int) Main.tile[index3 + 1, index2].active != 0 && (int) Main.tile[index3, index2 + num8].active != 0 && ((int) Main.tile[index3, index2].active != 0 && (int) Main.tile[index3, index2 - num8].active == 0) && num15 > 0; --num15)
            {
              Main.tile[index3, index2].type = (byte) 48;
              if ((int) Main.tile[index3 - 1, index2 - num8].active == 0 && (int) Main.tile[index3 + 1, index2 - num8].active == 0)
              {
                Main.tile[index3, index2 - num8].type = (byte) 48;
                Main.tile[index3, index2 - num8].active = (byte) 1;
              }
              ++index3;
            }
          }
        }
        if (num12 > num13)
        {
          num12 = 0;
          ++num14;
        }
      }
      int num16 = 0;
      int num17 = 1000;
      int num18 = 0;
      UI.main.progress = 0.75f;
      while (num18 < (int) Main.maxTilesX / 100)
      {
        ++num16;
        int index1 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index2 = WorldGen.genRand.Next(Main.worldSurface + 25, WorldGen.dMaxY);
        int num7 = index2;
        if ((int) Main.tile[index1, index2].wall == wallType && (int) Main.tile[index1, index2].active == 0)
        {
          int num8 = 1;
          if (WorldGen.genRand.Next(2) == 0)
            num8 = -1;
          while (index1 > 5 && index1 < (int) Main.maxTilesX - 5 && (int) Main.tile[index1, index2].active == 0)
            index1 += num8;
          if ((int) Main.tile[index1, index2 - 1].active != 0 && (int) Main.tile[index1, index2 + 1].active != 0 && ((int) Main.tile[index1 - num8, index2 - 1].active == 0 && (int) Main.tile[index1 - num8, index2 + 1].active == 0))
          {
            ++num18;
            for (int index3 = WorldGen.genRand.Next(5, 13); (int) Main.tile[index1, index2 - 1].active != 0 && (int) Main.tile[index1 + num8, index2].active != 0 && ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1 - num8, index2].active == 0) && index3 > 0; --index3)
            {
              Main.tile[index1, index2].type = (byte) 48;
              if ((int) Main.tile[index1 - num8, index2 - 1].active == 0 && (int) Main.tile[index1 - num8, index2 + 1].active == 0)
              {
                Main.tile[index1 - num8, index2].type = (byte) 48;
                Main.tile[index1 - num8, index2].active = (byte) 1;
              }
              --index2;
            }
            int num15 = WorldGen.genRand.Next(5, 13);
            for (int index3 = num7 + 1; (int) Main.tile[index1, index3 + 1].active != 0 && (int) Main.tile[index1 + num8, index3].active != 0 && ((int) Main.tile[index1, index3].active != 0 && (int) Main.tile[index1 - num8, index3].active == 0) && num15 > 0; --num15)
            {
              Main.tile[index1, index3].type = (byte) 48;
              if ((int) Main.tile[index1 - num8, index3 - 1].active == 0 && (int) Main.tile[index1 - num8, index3 + 1].active == 0)
              {
                Main.tile[index1 - num8, index3].type = (byte) 48;
                Main.tile[index1 - num8, index3].active = (byte) 1;
              }
              ++index3;
            }
          }
        }
        if (num16 > num17)
        {
          num16 = 0;
          ++num18;
        }
      }
      UI.main.progress = 0.8f;
      for (int index1 = 0; index1 < WorldGen.numDDoors; ++index1)
      {
        int num7 = (int) WorldGen.dDoor[index1].X - 10;
        int num8 = (int) WorldGen.dDoor[index1].X + 10;
        int num15 = 100;
        int num19 = 0;
        for (int index2 = num7; index2 < num8; ++index2)
        {
          bool flag = true;
          int index3 = (int) WorldGen.dDoor[index1].Y;
          while ((int) Main.tile[index2, index3].active == 0)
            --index3;
          if (!Main.tileDungeon[(int) Main.tile[index2, index3].type])
            flag = false;
          int num20 = index3;
          int index4 = (int) WorldGen.dDoor[index1].Y;
          while ((int) Main.tile[index2, index4].active == 0)
            ++index4;
          if (!Main.tileDungeon[(int) Main.tile[index2, index4].type])
            flag = false;
          int num21 = index4;
          if (num21 - num20 >= 3)
          {
            int num22 = index2 - 20;
            int num23 = index2 + 20;
            int num24 = num21 - 10;
            int num25 = num21 + 10;
            for (int index5 = num22; index5 < num23; ++index5)
            {
              for (int index6 = num24; index6 < num25; ++index6)
              {
                if ((int) Main.tile[index5, index6].active != 0 && (int) Main.tile[index5, index6].type == 10)
                {
                  flag = false;
                  break;
                }
              }
            }
            if (flag)
            {
              for (int index5 = num21 - 3; index5 < num21; ++index5)
              {
                for (int index6 = index2 - 3; index6 <= index2 + 3; ++index6)
                {
                  if ((int) Main.tile[index6, index5].active != 0)
                  {
                    flag = false;
                    break;
                  }
                }
              }
            }
            if (flag && num21 - num20 < 20 && ((int) WorldGen.dDoor[index1].Pos == 0 && num21 - num20 < num15 || (int) WorldGen.dDoor[index1].Pos == -1 && index2 > num19 || (int) WorldGen.dDoor[index1].Pos == 1 && (index2 < num19 || num19 == 0)))
            {
              num19 = index2;
              num15 = num21 - num20;
            }
          }
        }
        if (num15 < 20)
        {
          int i = num19;
          int index2 = (int) WorldGen.dDoor[index1].Y;
          int index3 = index2;
          for (; (int) Main.tile[i, index2].active == 0; ++index2)
            Main.tile[i, index2].active = (byte) 0;
          while ((int) Main.tile[i, index3].active == 0)
            --index3;
          int j = index2 - 1;
          int num20 = index3 + 1;
          for (int index4 = num20; index4 < j - 2; ++index4)
          {
            Main.tile[i, index4].active = (byte) 1;
            Main.tile[i, index4].type = (byte) tileType;
          }
          WorldGen.PlaceTile(i, j, 10, true, false, -1, 0);
          int index5 = i - 1;
          int index6 = j - 3;
          while ((int) Main.tile[index5, index6].active == 0)
            --index6;
          if (j - index6 < j - num20 + 5 && Main.tileDungeon[(int) Main.tile[index5, index6].type])
          {
            for (int index4 = j - 4 - WorldGen.genRand.Next(3); index4 > index6; --index4)
            {
              Main.tile[index5, index4].active = (byte) 1;
              Main.tile[index5, index4].type = (byte) tileType;
            }
          }
          int index7 = index5 + 2;
          int index8 = j - 3;
          while ((int) Main.tile[index7, index8].active == 0)
            --index8;
          if (j - index8 < j - num20 + 5 && Main.tileDungeon[(int) Main.tile[index7, index8].type])
          {
            for (int index4 = j - 4 - WorldGen.genRand.Next(3); index4 > index8; --index4)
            {
              Main.tile[index7, index4].active = (byte) 1;
              Main.tile[index7, index4].type = (byte) tileType;
            }
          }
          int index9 = j + 1;
          int num21 = index7 - 1;
          Main.tile[num21 - 1, index9].active = (byte) 1;
          Main.tile[num21 - 1, index9].type = (byte) tileType;
          Main.tile[num21 + 1, index9].active = (byte) 1;
          Main.tile[num21 + 1, index9].type = (byte) tileType;
        }
      }
      UI.main.progress = 0.85f;
      for (int index1 = 0; index1 < WorldGen.numDPlats; ++index1)
      {
        int index2 = (int) WorldGen.DPlat[index1].X;
        int num7 = (int) WorldGen.DPlat[index1].Y;
        int num8 = (int) Main.maxTilesX;
        int num15 = 10;
        for (int index3 = num7 - 5; index3 <= num7 + 5; ++index3)
        {
          int index4 = index2;
          int index5 = index2;
          bool flag1 = false;
          if ((int) Main.tile[index4, index3].active != 0)
          {
            flag1 = true;
          }
          else
          {
            while ((int) Main.tile[index4, index3].active == 0)
            {
              --index4;
              if (!Main.tileDungeon[(int) Main.tile[index4, index3].type])
                flag1 = true;
            }
            while ((int) Main.tile[index5, index3].active == 0)
            {
              ++index5;
              if (!Main.tileDungeon[(int) Main.tile[index5, index3].type])
                flag1 = true;
            }
          }
          if (!flag1 && index5 - index4 <= num15)
          {
            bool flag2 = true;
            int num19 = index2 - (num15 >> 1) - 2;
            int num20 = index2 + (num15 >> 1) + 2;
            int num21 = index3 - 5;
            int num22 = index3 + 5;
            for (int index6 = num19; index6 <= num20; ++index6)
            {
              for (int index7 = num21; index7 <= num22; ++index7)
              {
                if ((int) Main.tile[index6, index7].active != 0 && (int) Main.tile[index6, index7].type == 19)
                {
                  flag2 = false;
                  break;
                }
              }
            }
            for (int index6 = index3 + 3; index6 >= index3 - 5; --index6)
            {
              if ((int) Main.tile[index2, index6].active != 0)
              {
                flag2 = false;
                break;
              }
            }
            if (flag2)
            {
              num8 = index3;
              break;
            }
          }
        }
        if (num8 > num7 - 10 && num8 < num7 + 10)
        {
          int index3 = index2;
          int index4 = num8;
          int index5 = index2 + 1;
          for (; (int) Main.tile[index3, index4].active == 0; --index3)
          {
            Main.tile[index3, index4].active = (byte) 1;
            Main.tile[index3, index4].type = (byte) 19;
          }
          for (; (int) Main.tile[index5, index4].active == 0; ++index5)
          {
            Main.tile[index5, index4].active = (byte) 1;
            Main.tile[index5, index4].type = (byte) 19;
          }
        }
      }
      UI.main.progress = 0.9f;
      int num26 = 0;
      int num27 = 1000;
      int num28 = 0;
      while (num28 < (int) Main.maxTilesX / 20)
      {
        ++num26;
        int index1 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index2 = WorldGen.genRand.Next(WorldGen.dMinY, WorldGen.dMaxY);
        bool flag1 = true;
        if ((int) Main.tile[index1, index2].wall == wallType && (int) Main.tile[index1, index2].active == 0)
        {
          int num7 = 1;
          if (WorldGen.genRand.Next(2) == 0)
            num7 = -1;
          while (flag1 && (int) Main.tile[index1, index2].active == 0)
          {
            index1 -= num7;
            if (index1 < 5 || index1 > (int) Main.maxTilesX - 5)
              flag1 = false;
            else if ((int) Main.tile[index1, index2].active != 0 && !Main.tileDungeon[(int) Main.tile[index1, index2].type])
              flag1 = false;
          }
          if (flag1 && (int) Main.tile[index1, index2].active != 0 && (Main.tileDungeon[(int) Main.tile[index1, index2].type] && (int) Main.tile[index1, index2 - 1].active != 0) && (Main.tileDungeon[(int) Main.tile[index1, index2 - 1].type] && (int) Main.tile[index1, index2 + 1].active != 0 && Main.tileDungeon[(int) Main.tile[index1, index2 + 1].type]))
          {
            int i1 = index1 + num7;
            for (int index3 = i1 - 3; index3 <= i1 + 3; ++index3)
            {
              for (int index4 = index2 - 3; index4 <= index2 + 3; ++index4)
              {
                if ((int) Main.tile[index3, index4].active != 0 && (int) Main.tile[index3, index4].type == 19)
                {
                  flag1 = false;
                  break;
                }
              }
            }
            if (flag1 && (int) Main.tile[i1, index2 - 1].active == 0 & (int) Main.tile[i1, index2 - 2].active == 0 & (int) Main.tile[i1, index2 - 3].active == 0)
            {
              int index3 = i1;
              int num8 = i1;
              while (index3 > WorldGen.dMinX && index3 < WorldGen.dMaxX && ((int) Main.tile[index3, index2].active == 0 && (int) Main.tile[index3, index2 - 1].active == 0) && (int) Main.tile[index3, index2 + 1].active == 0)
                index3 += num7;
              int num15 = Math.Abs(i1 - index3);
              bool flag2 = false;
              if (WorldGen.genRand.Next(2) == 0)
                flag2 = true;
              if (num15 > 5)
              {
                for (int index4 = WorldGen.genRand.Next(1, 4); index4 > 0; --index4)
                {
                  Main.tile[i1, index2].active = (byte) 1;
                  Main.tile[i1, index2].type = (byte) 19;
                  if (flag2)
                  {
                    WorldGen.PlaceTile(i1, index2 - 1, 50, true, false, -1, 0);
                    if (WorldGen.genRand.Next(50) == 0 && (int) Main.tile[i1, index2 - 1].type == 50)
                      Main.tile[i1, index2 - 1].frameX = (short) 90;
                  }
                  i1 += num7;
                }
                num26 = 0;
                ++num28;
                if (!flag2 && WorldGen.genRand.Next(2) == 0)
                {
                  int i2 = num8;
                  int j = index2 - 1;
                  int type = 0;
                  if (WorldGen.genRand.Next(4) == 0)
                    type = 1;
                  if (type == 0)
                    type = 13;
                  else if (type == 1)
                    type = 49;
                  WorldGen.PlaceTile(i2, j, type, true, false, -1, 0);
                  if ((int) Main.tile[i2, j].type == 13)
                  {
                    if (WorldGen.genRand.Next(2) == 0)
                      Main.tile[i2, j].frameX = (short) 18;
                    else
                      Main.tile[i2, j].frameX = (short) 36;
                  }
                }
              }
            }
          }
        }
        if (num26 > num27)
        {
          num26 = 0;
          ++num28;
        }
      }
      UI.main.progress = 0.95f;
      int num29 = 0;
      for (int index = 0; index < WorldGen.numDRooms; ++index)
      {
        int num7 = 0;
        while (num7 < 1000)
        {
          int num8 = (int) ((double) WorldGen.dRoom[index].Size * 0.400000005960464);
          int i = (int) WorldGen.dRoom[index].X + WorldGen.genRand.Next(-num8, num8 + 1);
          int j = (int) WorldGen.dRoom[index].Y + WorldGen.genRand.Next(-num8, num8 + 1);
          ++num29;
          int Style = 2;
          int contain;
          if (num29 == 1)
            contain = 329;
          else if (num29 == 2)
            contain = 155;
          else if (num29 == 3)
            contain = 156;
          else if (num29 == 4)
            contain = 157;
          else if (num29 == 5)
            contain = 163;
          else if (num29 == 6)
            contain = 113;
          else if (num29 == 7)
          {
            contain = 327;
            Style = 0;
          }
          else
          {
            contain = 164;
            num29 = 0;
          }
          if (j < Main.worldSurface + 50)
          {
            contain = 327;
            Style = 0;
          }
          if (contain == 0 && WorldGen.genRand.Next(2) == 0)
          {
            num7 = 1000;
          }
          else
          {
            if (WorldGen.AddBuriedChest(i, j, contain, false, Style))
              num7 += 1000;
            ++num7;
          }
        }
      }
      WorldGen.dMinX -= 25;
      WorldGen.dMaxX += 25;
      WorldGen.dMinY -= 25;
      WorldGen.dMaxY += 25;
      if (WorldGen.dMinX < 0)
        WorldGen.dMinX = 0;
      if (WorldGen.dMaxX > (int) Main.maxTilesX)
        WorldGen.dMaxX = (int) Main.maxTilesX;
      if (WorldGen.dMinY < 0)
        WorldGen.dMinY = 0;
      if (WorldGen.dMaxY > (int) Main.maxTilesY)
        WorldGen.dMaxY = (int) Main.maxTilesY;
      int num30 = 0;
      int num31 = 1000;
      int num32 = 0;
      while (num32 < (int) Main.maxTilesX / 150)
      {
        ++num30;
        int x1 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int index1 = WorldGen.genRand.Next(WorldGen.dMinY, WorldGen.dMaxY);
        if ((int) Main.tile[x1, index1].wall == wallType)
        {
          for (int y1 = index1; y1 > WorldGen.dMinY; --y1)
          {
            if ((int) Main.tile[x1, y1 - 1].active != 0 && (int) Main.tile[x1, y1 - 1].type == tileType)
            {
              bool flag = false;
              for (int index2 = x1 - 15; index2 < x1 + 15; ++index2)
              {
                for (int index3 = y1 - 15; index3 < y1 + 15; ++index3)
                {
                  if (index2 > 0 && index2 < (int) Main.maxTilesX && (index3 > 0 && index3 < (int) Main.maxTilesY) && (int) Main.tile[index2, index3].type == 42)
                  {
                    flag = true;
                    break;
                  }
                }
              }
              if ((int) Main.tile[x1 - 1, y1].active != 0 || (int) Main.tile[x1 + 1, y1].active != 0 || ((int) Main.tile[x1 - 1, y1 + 1].active != 0 || (int) Main.tile[x1 + 1, y1 + 1].active != 0) || (int) Main.tile[x1, y1 + 2].active != 0)
                flag = true;
              if (!flag && WorldGen.Place1x2Top(x1, y1, 42))
              {
                num30 = 0;
                ++num32;
                Rectangle aabb1 = new Rectangle();
                Rectangle aabb2 = new Rectangle();
                aabb2.X = x1 << 4;
                aabb2.Y = (y1 << 4) + 1;
                aabb1.Width = aabb2.Width = 16;
                aabb1.Height = aabb2.Height = 16;
                for (int index2 = 0; index2 < 1000; ++index2)
                {
                  int i = x1 + WorldGen.genRand.Next(-12, 13);
                  int j = y1 + WorldGen.genRand.Next(3, 21);
                  if ((int) Main.tile[i, j].active == 0 && (int) Main.tile[i, j + 1].active == 0 && ((int) Main.tile[i - 1, j].type != 48 && (int) Main.tile[i + 1, j].type != 48))
                  {
                    aabb1.X = i << 4;
                    aabb1.Y = j << 4;
                    if (Collision.CanHit(ref aabb1, ref aabb2))
                    {
                      WorldGen.PlaceTile(i, j, 136, true, false, -1, 0);
                      if ((int) Main.tile[i, j].active != 0)
                      {
                        while (i != x1 || j != y1)
                        {
                          Main.tile[i, j].wire = 16;
                          if (i > x1)
                            --i;
                          if (i < x1)
                            ++i;
                          Main.tile[i, j].wire = 16;
                          if (j > y1)
                            --j;
                          if (j < y1)
                            ++j;
                          Main.tile[i, j].wire = 16;
                        }
                        if (Main.rand.Next(3) > 0)
                        {
                          Main.tile[x1, y1].frameX = (short) 18;
                          Main.tile[x1, y1 + 1].frameX = (short) 18;
                          break;
                        }
                        else
                          break;
                      }
                    }
                  }
                }
                break;
              }
              else
                break;
            }
          }
        }
        if (num30 > num31)
        {
          ++num32;
          num30 = 0;
        }
      }
      int num33 = 0;
      int num34 = 1000;
      int num35 = 0;
      while (num35 < (int) Main.maxTilesX / 500)
      {
        ++num33;
        int x2 = WorldGen.genRand.Next(WorldGen.dMinX, WorldGen.dMaxX);
        int y2 = WorldGen.genRand.Next(WorldGen.dMinY, WorldGen.dMaxY);
        if ((int) Main.tile[x2, y2].wall == wallType && WorldGen.placeTrap(x2, y2, 0))
          num33 = num34;
        if (num33 > num34)
        {
          ++num35;
          num33 = 0;
        }
      }
    }

    public static void DungeonStairs(int i, int j, int tileType, int wallType)
    {
      Vector2 vector2_1 = new Vector2();
      Vector2 vector2_2 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(5, 9);
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      int num2 = WorldGen.genRand.Next(10, 30);
      int num3 = i <= WorldGen.dEnteranceX ? 1 : -1;
      if (i > (int) Main.maxTilesX - 400)
        num3 = -1;
      else if (i < 400)
        num3 = 1;
      vector2_2.Y = -1f;
      vector2_2.X = (float) num3;
      if (WorldGen.genRand.Next(3) == 0)
        vector2_2.X *= 0.5f;
      else if (WorldGen.genRand.Next(3) == 0)
        vector2_2.Y *= 2f;
      while (num2 > 0)
      {
        --num2;
        int num4 = (int) ((double) vector2_1.X - num1 - 4.0 - (double) WorldGen.genRand.Next(6));
        int num5 = (int) ((double) vector2_1.X + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        int num6 = (int) ((double) vector2_1.Y - num1 - 4.0);
        int num7 = (int) ((double) vector2_1.Y + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        if (num4 < 0)
          num4 = 0;
        if (num5 > (int) Main.maxTilesX)
          num5 = (int) Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > (int) Main.maxTilesY)
          num7 = (int) Main.maxTilesY;
        double num8 = 1.0;
        if ((double) vector2_1.X > (double) ((int) Main.maxTilesX >> 1))
          num8 = -1.0;
        int i1 = (int) ((double) vector2_1.X + WorldGen.dxStrength1 * 0.6 * num8 + WorldGen.dxStrength2 * num8);
        double num9 = Math.Floor(WorldGen.dyStrength2 * 0.5);
        int num10 = (int) ((double) vector2_1.Y - num1 + num9);
        if ((double) vector2_1.Y < (double) (Main.worldSurface - 5) && (int) Main.tile[i1, num10 - 6].wall == 0 && ((int) Main.tile[i1, num10 - 7].wall == 0 && (int) Main.tile[i1, num10 - 8].wall == 0))
        {
          WorldGen.dSurface = true;
          WorldGen.TileRunner(i1, (int) ((double) vector2_1.Y - num1 - 6.0 + num9), WorldGen.genRand.Next(25, 35), WorldGen.genRand.Next(10, 20), -1, false, new Vector2(0.0f, -1f), false, true);
        }
        for (int index1 = num4; index1 < num5; ++index1)
        {
          for (int index2 = num6; index2 < num7; ++index2)
          {
            Main.tile[index1, index2].liquid = (byte) 0;
            if ((int) Main.tile[index1, index2].wall != wallType)
            {
              Main.tile[index1, index2].wall = (byte) 0;
              Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].type = (byte) tileType;
            }
          }
        }
        for (int index1 = num4 + 1; index1 < num5 - 1; ++index1)
        {
          for (int index2 = num6 + 1; index2 < num7 - 1; ++index2)
          {
            if ((int) Main.tile[index1, index2].wall == 0)
              Main.tile[index1, index2].wall = (byte) wallType;
          }
        }
        int num11 = 0;
        if (WorldGen.genRand.Next((int) num1) == 0)
          num11 = WorldGen.genRand.Next(1, 3);
        int num12 = (int) ((double) vector2_1.X - num1 * 0.5 - (double) num11);
        int num13 = (int) ((double) vector2_1.X + num1 * 0.5 + (double) num11);
        int num14 = (int) ((double) vector2_1.Y - num1 * 0.5 - (double) num11);
        int num15 = (int) ((double) vector2_1.Y + num1 * 0.5 + (double) num11);
        if (num12 < 0)
          num12 = 0;
        if (num13 > (int) Main.maxTilesX)
          num13 = (int) Main.maxTilesX;
        if (num14 < 0)
          num14 = 0;
        if (num15 > (int) Main.maxTilesY)
          num15 = (int) Main.maxTilesY;
        for (int index1 = num12; index1 < num13; ++index1)
        {
          for (int index2 = num14; index2 < num15; ++index2)
          {
            Main.tile[index1, index2].active = (byte) 0;
            if ((int) Main.tile[index1, index2].wall == 0)
              Main.tile[index1, index2].wall = (byte) wallType;
          }
        }
        if (WorldGen.dSurface)
          num2 = 0;
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
      }
      WorldGen.dungeonX = (int) vector2_1.X;
      WorldGen.dungeonY = (int) vector2_1.Y;
    }

    public static void DungeonHalls(int i, int j, int tileType, int wallType, bool forceX = false)
    {
      Vector2 vector2_1 = new Vector2();
      Vector2 vector2_2 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(4, 6);
      Vector2i vector2i1 = new Vector2i();
      Vector2i vector2i2 = new Vector2i();
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      int num2 = WorldGen.genRand.Next(35, 80);
      if (forceX)
      {
        num2 += 20;
        WorldGen.lastDungeonHall = new Vector2i();
      }
      else if (WorldGen.genRand.Next(5) == 0)
      {
        num1 *= 2.0;
        num2 >>= 1;
      }
      do
      {
        int num3 = (WorldGen.genRand.Next(2) << 1) - 1;
        if (forceX || WorldGen.genRand.Next(2) == 0)
        {
          vector2i1.Y = 0;
          vector2i1.X = num3;
          vector2i2.Y = 0;
          vector2i2.X = -num3;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num3;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_2.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else
        {
          ++num1;
          vector2_2.Y = (float) num3;
          vector2_2.X = 0.0f;
          vector2i1.X = 0;
          vector2i1.Y = num3;
          vector2i2.X = 0;
          vector2i2.Y = -num3;
          if (WorldGen.genRand.Next(2) == 0)
            vector2_2.X = WorldGen.genRand.Next(2) != 0 ? -0.3f : 0.3f;
          else
            num2 >>= 1;
        }
      }
      while (WorldGen.lastDungeonHall.X == vector2i2.X && WorldGen.lastDungeonHall.Y == vector2i2.Y);
      if (!forceX)
      {
        if ((double) vector2_1.X > (double) ((int) WorldGen.lastMaxTilesX - 200))
        {
          int num3 = -1;
          vector2i1.Y = 0;
          vector2i1.X = num3;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num3;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_2.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else if ((double) vector2_1.X < 200.0)
        {
          int num3 = 1;
          vector2i1.Y = 0;
          vector2i1.X = num3;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num3;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_2.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else if ((double) vector2_1.Y > (double) ((int) WorldGen.lastMaxTilesY - 300))
        {
          int num3 = -1;
          ++num1;
          vector2_2.Y = (float) num3;
          vector2_2.X = 0.0f;
          vector2i1.X = 0;
          vector2i1.Y = num3;
          if (WorldGen.genRand.Next(2) == 0)
            vector2_2.X = WorldGen.genRand.Next(2) != 0 ? -0.3f : 0.3f;
        }
        else if ((double) vector2_1.Y < (double) Main.rockLayer)
        {
          int num3 = 1;
          ++num1;
          vector2_2.Y = (float) num3;
          vector2_2.X = 0.0f;
          vector2i1.X = 0;
          vector2i1.Y = num3;
          if (WorldGen.genRand.Next(2) == 0)
            vector2_2.X = WorldGen.genRand.Next(2) != 0 ? -0.3f : 0.3f;
        }
        else if ((double) vector2_1.X < (double) ((int) Main.maxTilesX >> 1) && (double) vector2_1.X > (double) ((int) Main.maxTilesX >> 2))
        {
          int num3 = -1;
          vector2i1.Y = 0;
          vector2i1.X = num3;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num3;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_2.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
        else if ((double) vector2_1.X > (double) ((int) Main.maxTilesX >> 1) && (double) vector2_1.X < (double) Main.maxTilesX * 0.75)
        {
          int num3 = 1;
          vector2i1.Y = 0;
          vector2i1.X = num3;
          vector2_2.Y = 0.0f;
          vector2_2.X = (float) num3;
          if (WorldGen.genRand.Next(3) == 0)
            vector2_2.Y = WorldGen.genRand.Next(2) != 0 ? 0.2f : -0.2f;
        }
      }
      if (vector2i1.Y == 0)
      {
        WorldGen.dDoor[WorldGen.numDDoors].X = (short) vector2_1.X;
        WorldGen.dDoor[WorldGen.numDDoors].Y = (short) vector2_1.Y;
        WorldGen.dDoor[WorldGen.numDDoors].Pos = (short) 0;
        ++WorldGen.numDDoors;
      }
      else
      {
        WorldGen.DPlat[WorldGen.numDPlats].X = (short) vector2_1.X;
        WorldGen.DPlat[WorldGen.numDPlats].Y = (short) vector2_1.Y;
        ++WorldGen.numDPlats;
      }
      WorldGen.lastDungeonHall = vector2i1;
      while (num2 > 0)
      {
        if (vector2i1.X > 0 && (double) vector2_1.X > (double) ((int) Main.maxTilesX - 100))
          num2 = 0;
        else if (vector2i1.X < 0 && (double) vector2_1.X < 100.0)
          num2 = 0;
        else if (vector2i1.Y > 0 && (double) vector2_1.Y > (double) ((int) Main.maxTilesY - 100))
          num2 = 0;
        else if (vector2i1.Y < 0 && (double) vector2_1.Y < (double) (Main.rockLayer + 50))
          num2 = 0;
        --num2;
        int num3 = (int) ((double) vector2_1.X - num1 - 4.0 - (double) WorldGen.genRand.Next(6));
        int num4 = (int) ((double) vector2_1.X + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        int num5 = (int) ((double) vector2_1.Y - num1 - 4.0 - (double) WorldGen.genRand.Next(6));
        int num6 = (int) ((double) vector2_1.Y + num1 + 4.0 + (double) WorldGen.genRand.Next(6));
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesX)
          num4 = (int) Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > (int) Main.maxTilesY)
          num6 = (int) Main.maxTilesY;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          for (int index2 = num5; index2 < num6; ++index2)
          {
            Main.tile[index1, index2].liquid = (byte) 0;
            if ((int) Main.tile[index1, index2].wall == 0)
            {
              Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].type = (byte) tileType;
            }
          }
        }
        for (int index1 = num3 + 1; index1 < num4 - 1; ++index1)
        {
          for (int index2 = num5 + 1; index2 < num6 - 1; ++index2)
          {
            if ((int) Main.tile[index1, index2].wall == 0)
              Main.tile[index1, index2].wall = (byte) wallType;
          }
        }
        int num7 = 0;
        if ((double) vector2_2.Y == 0.0 && WorldGen.genRand.Next((int) num1 + 1) == 0)
          num7 = WorldGen.genRand.Next(1, 3);
        else if ((double) vector2_2.X == 0.0 && WorldGen.genRand.Next((int) num1 - 1) == 0)
          num7 = WorldGen.genRand.Next(1, 3);
        else if (WorldGen.genRand.Next((int) num1 * 3) == 0)
          num7 = WorldGen.genRand.Next(1, 3);
        int num8 = (int) ((double) vector2_1.X - num1 * 0.5 - (double) num7);
        int num9 = (int) ((double) vector2_1.X + num1 * 0.5 + (double) num7);
        int num10 = (int) ((double) vector2_1.Y - num1 * 0.5 - (double) num7);
        int num11 = (int) ((double) vector2_1.Y + num1 * 0.5 + (double) num7);
        if (num8 < 0)
          num8 = 0;
        if (num9 > (int) Main.maxTilesX)
          num9 = (int) Main.maxTilesX;
        if (num10 < 0)
          num10 = 0;
        if (num11 > (int) Main.maxTilesY)
          num11 = (int) Main.maxTilesY;
        for (int index1 = num8; index1 < num9; ++index1)
        {
          for (int index2 = num10; index2 < num11; ++index2)
          {
            Main.tile[index1, index2].active = (byte) 0;
            Main.tile[index1, index2].wall = (byte) wallType;
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
      }
      WorldGen.dungeonX = (int) vector2_1.X;
      WorldGen.dungeonY = (int) vector2_1.Y;
      if (vector2i1.Y == 0)
      {
        WorldGen.dDoor[WorldGen.numDDoors].X = (short) vector2_1.X;
        WorldGen.dDoor[WorldGen.numDDoors].Y = (short) vector2_1.Y;
        WorldGen.dDoor[WorldGen.numDDoors].Pos = (short) 0;
        ++WorldGen.numDDoors;
      }
      else
      {
        WorldGen.DPlat[WorldGen.numDPlats].X = (short) vector2_1.X;
        WorldGen.DPlat[WorldGen.numDPlats].Y = (short) vector2_1.Y;
        ++WorldGen.numDPlats;
      }
    }

    public static void DungeonRoom(int i, int j, int tileType, int wallType)
    {
      Vector2 vector2_1 = new Vector2();
      Vector2 vector2_2 = new Vector2();
      float num1 = (float) WorldGen.genRand.Next(15, 30);
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j - num1 * 0.5f;
      int num2 = WorldGen.genRand.Next(10, 20);
      float num3 = vector2_1.X;
      float num4 = vector2_1.X;
      float num5 = vector2_1.Y;
      float num6 = vector2_1.Y;
      while (num2 > 0)
      {
        --num2;
        int num7 = (int) ((double) vector2_1.X - (double) num1 * 0.800000011920929 - 5.0);
        int num8 = (int) ((double) vector2_1.X + (double) num1 * 0.800000011920929 + 5.0);
        int num9 = (int) ((double) vector2_1.Y - (double) num1 * 0.800000011920929 - 5.0);
        int num10 = (int) ((double) vector2_1.Y + (double) num1 * 0.800000011920929 + 5.0);
        if (num7 < 0)
          num7 = 0;
        if (num8 > (int) Main.maxTilesX)
          num8 = (int) Main.maxTilesX;
        if (num9 < 0)
          num9 = 0;
        if (num10 > (int) Main.maxTilesY)
          num10 = (int) Main.maxTilesY;
        for (int index1 = num7; index1 < num8; ++index1)
        {
          for (int index2 = num9; index2 < num10; ++index2)
          {
            Main.tile[index1, index2].liquid = (byte) 0;
            if ((int) Main.tile[index1, index2].wall == 0)
            {
              Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].type = (byte) tileType;
            }
          }
        }
        for (int index1 = num7 + 1; index1 < num8 - 1; ++index1)
        {
          for (int index2 = num9 + 1; index2 < num10 - 1; ++index2)
          {
            if ((int) Main.tile[index1, index2].wall == 0)
              Main.tile[index1, index2].wall = (byte) wallType;
          }
        }
        int num11 = (int) ((double) vector2_1.X - (double) num1 * 0.5);
        int num12 = (int) ((double) vector2_1.X + (double) num1 * 0.5);
        int num13 = (int) ((double) vector2_1.Y - (double) num1 * 0.5);
        int num14 = (int) ((double) vector2_1.Y + (double) num1 * 0.5);
        if (num11 < 0)
          num11 = 0;
        if (num12 > (int) Main.maxTilesX)
          num12 = (int) Main.maxTilesX;
        if (num13 < 0)
          num13 = 0;
        if (num14 > (int) Main.maxTilesY)
          num14 = (int) Main.maxTilesY;
        if ((double) num11 < (double) num3)
          num3 = (float) num11;
        if ((double) num12 > (double) num4)
          num4 = (float) num12;
        if ((double) num13 < (double) num5)
          num5 = (float) num13;
        if ((double) num14 > (double) num6)
          num6 = (float) num14;
        for (int index1 = num11; index1 < num12; ++index1)
        {
          for (int index2 = num13; index2 < num14; ++index2)
          {
            Main.tile[index1, index2].active = (byte) 0;
            Main.tile[index1, index2].wall = (byte) wallType;
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
        if ((double) vector2_2.Y > 1.0)
          vector2_2.Y = 1f;
        if ((double) vector2_2.Y < -1.0)
          vector2_2.Y = -1f;
      }
      WorldGen.dRoom[WorldGen.numDRooms].X = (short) vector2_1.X;
      WorldGen.dRoom[WorldGen.numDRooms].Y = (short) vector2_1.Y;
      WorldGen.dRoom[WorldGen.numDRooms].Size = num1;
      WorldGen.dRoom[WorldGen.numDRooms].L = (short) num3;
      WorldGen.dRoom[WorldGen.numDRooms].R = (short) num4;
      WorldGen.dRoom[WorldGen.numDRooms].T = (short) num5;
      WorldGen.dRoom[WorldGen.numDRooms].B = (short) num6;
      ++WorldGen.numDRooms;
    }

    public static void DungeonEnt(int i, int j, int tileType, int wallType)
    {
      int num1 = 60;
      for (int index1 = i - num1; index1 < i + num1; ++index1)
      {
        for (int index2 = j - num1; index2 < j + num1; ++index2)
        {
          Main.tile[index1, index2].liquid = (byte) 0;
          Main.tile[index1, index2].lava = (byte) 0;
        }
      }
      double num2 = WorldGen.dxStrength1;
      double num3 = WorldGen.dyStrength1;
      Vector2 vector2;
      vector2.X = (float) i;
      vector2.Y = (float) j - (float) (num3 * 0.5);
      WorldGen.dMinY = (int) vector2.Y;
      int num4 = 1;
      if (i > (int) Main.maxTilesX >> 1)
        num4 = -1;
      int num5 = (int) ((double) vector2.X - num2 * 0.600000023841858 - (double) WorldGen.genRand.Next(2, 5));
      int num6 = (int) ((double) vector2.X + num2 * 0.600000023841858 + (double) WorldGen.genRand.Next(2, 5));
      int num7 = (int) ((double) vector2.Y - num3 * 0.600000023841858 - (double) WorldGen.genRand.Next(2, 5));
      int num8 = (int) ((double) vector2.Y + num3 * 0.600000023841858 + (double) WorldGen.genRand.Next(8, 16));
      if (num5 < 0)
        num5 = 0;
      if (num6 > (int) Main.maxTilesX)
        num6 = (int) Main.maxTilesX;
      if (num7 < 0)
        num7 = 0;
      if (num8 > (int) Main.maxTilesY)
        num8 = (int) Main.maxTilesY;
      for (int index1 = num5; index1 < num6; ++index1)
      {
        for (int index2 = num7; index2 < num8; ++index2)
        {
          Main.tile[index1, index2].liquid = (byte) 0;
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            Main.tile[index1, index2].wall = (byte) 0;
            if (index1 > num5 + 1 && index1 < num6 - 2 && (index2 > num7 + 1 && index2 < num8 - 2))
              Main.tile[index1, index2].wall = (byte) wallType;
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
      }
      int num9 = num5;
      int num10 = num5 + 5 + WorldGen.genRand.Next(4);
      int num11 = num7 - 3 - WorldGen.genRand.Next(3);
      int num12 = num7;
      for (int index1 = num9; index1 < num10; ++index1)
      {
        for (int index2 = num11; index2 < num12; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
      }
      int num13 = num6 - 5 - WorldGen.genRand.Next(4);
      int num14 = num6;
      int num15 = num7 - 3 - WorldGen.genRand.Next(3);
      int num16 = num7;
      for (int index1 = num13; index1 < num14; ++index1)
      {
        for (int index2 = num15; index2 < num16; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
      }
      int num17 = 1 + WorldGen.genRand.Next(2);
      int num18 = 2 + WorldGen.genRand.Next(4);
      int num19 = 0;
      for (int index1 = num5; index1 < num6; ++index1)
      {
        for (int index2 = num7 - num17; index2 < num7; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
        ++num19;
        if (num19 >= num18)
        {
          index1 += num18;
          num19 = 0;
        }
      }
      for (int index1 = num5; index1 < num6; ++index1)
      {
        for (int index2 = num8; index2 < num8 + 100; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall == 0)
            Main.tile[index1, index2].wall = (byte) 2;
        }
      }
      int num20 = (int) ((double) vector2.X - num2 * 0.600000023841858);
      int num21 = (int) ((double) vector2.X + num2 * 0.600000023841858);
      int num22 = (int) ((double) vector2.Y - num3 * 0.600000023841858);
      int num23 = (int) ((double) vector2.Y + num3 * 0.600000023841858);
      if (num20 < 0)
        num20 = 0;
      if (num21 > (int) Main.maxTilesX)
        num21 = (int) Main.maxTilesX;
      if (num22 < 0)
        num22 = 0;
      if (num23 > (int) Main.maxTilesY)
        num23 = (int) Main.maxTilesY;
      for (int index1 = num20; index1 < num21; ++index1)
      {
        for (int index2 = num22; index2 < num23; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall == 0)
            Main.tile[index1, index2].wall = (byte) wallType;
        }
      }
      int num24 = (int) ((double) vector2.X - num2 * 0.6 - 1.0);
      int num25 = (int) ((double) vector2.X + num2 * 0.6 + 1.0);
      int num26 = (int) ((double) vector2.Y - num3 * 0.6 - 1.0);
      int num27 = (int) ((double) vector2.Y + num3 * 0.6 + 1.0);
      if (num24 < 0)
        num24 = 0;
      if (num25 > (int) Main.maxTilesX)
        num25 = (int) Main.maxTilesX;
      if (num26 < 0)
        num26 = 0;
      if (num27 > (int) Main.maxTilesY)
        num27 = (int) Main.maxTilesY;
      for (int index1 = num24; index1 < num25; ++index1)
      {
        for (int index2 = num26; index2 < num27; ++index2)
          Main.tile[index1, index2].wall = (byte) wallType;
      }
      int num28 = (int) ((double) vector2.X - num2 * 0.5);
      int num29 = (int) ((double) vector2.X + num2 * 0.5);
      int num30 = (int) ((double) vector2.Y - num3 * 0.5);
      int num31 = (int) ((double) vector2.Y + num3 * 0.5);
      if (num28 < 0)
        num28 = 0;
      if (num29 > (int) Main.maxTilesX)
        num29 = (int) Main.maxTilesX;
      if (num30 < 0)
        num30 = 0;
      if (num31 > (int) Main.maxTilesY)
        num31 = (int) Main.maxTilesY;
      for (int index1 = num28; index1 < num29; ++index1)
      {
        for (int index2 = num30; index2 < num31; ++index2)
        {
          Main.tile[index1, index2].active = (byte) 0;
          Main.tile[index1, index2].wall = (byte) wallType;
        }
      }
      WorldGen.DPlat[WorldGen.numDPlats].X = (short) vector2.X;
      WorldGen.DPlat[WorldGen.numDPlats].Y = (short) num31;
      ++WorldGen.numDPlats;
      vector2.X += (float) (num2 * 0.600000023841858) * (float) num4;
      vector2.Y += (float) num3 * 0.5f;
      double num32 = WorldGen.dxStrength2;
      double num33 = WorldGen.dyStrength2;
      vector2.X += (float) (num32 * 0.550000011920929) * (float) num4;
      vector2.Y -= (float) num33 * 0.5f;
      int num34 = (int) ((double) vector2.X - num32 * 0.600000023841858 - (double) WorldGen.genRand.Next(1, 3));
      int num35 = (int) ((double) vector2.X + num32 * 0.600000023841858 + (double) WorldGen.genRand.Next(1, 3));
      int num36 = (int) ((double) vector2.Y - num33 * 0.600000023841858 - (double) WorldGen.genRand.Next(1, 3));
      int num37 = (int) ((double) vector2.Y + num33 * 0.600000023841858 + (double) WorldGen.genRand.Next(6, 16));
      if (num34 < 0)
        num34 = 0;
      if (num35 > (int) Main.maxTilesX)
        num35 = (int) Main.maxTilesX;
      if (num36 < 0)
        num36 = 0;
      if (num37 > (int) Main.maxTilesY)
        num37 = (int) Main.maxTilesY;
      for (int index1 = num34; index1 < num35; ++index1)
      {
        for (int index2 = num36; index2 < num37; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            bool flag = true;
            if (num4 < 0)
            {
              if ((double) index1 < (double) vector2.X - num32 * 0.5)
                flag = false;
            }
            else if ((double) index1 > (double) vector2.X + num32 * 0.5 - 1.0)
              flag = false;
            if (flag)
            {
              Main.tile[index1, index2].wall = (byte) 0;
              Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].type = (byte) tileType;
            }
          }
        }
      }
      for (int index1 = num34; index1 < num35; ++index1)
      {
        for (int index2 = num37; index2 < num37 + 100; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall == 0)
            Main.tile[index1, index2].wall = (byte) 2;
        }
      }
      int num38 = (int) ((double) vector2.X - num32 * 0.5);
      int num39 = (int) ((double) vector2.X + num32 * 0.5);
      int num40 = num38;
      if (num4 < 0)
        ++num40;
      int num41 = num40 + 5 + WorldGen.genRand.Next(4);
      int num42 = num36 - 3 - WorldGen.genRand.Next(3);
      int num43 = num36;
      for (int index1 = num40; index1 < num41; ++index1)
      {
        for (int index2 = num42; index2 < num43; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
      }
      int num44 = num39 - 5 - WorldGen.genRand.Next(4);
      int num45 = num39;
      int num46 = num36 - 3 - WorldGen.genRand.Next(3);
      int num47 = num36;
      for (int index1 = num44; index1 < num45; ++index1)
      {
        for (int index2 = num46; index2 < num47; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
      }
      int num48 = 1 + WorldGen.genRand.Next(2);
      int num49 = 2 + WorldGen.genRand.Next(4);
      int num50 = 0;
      if (num4 < 0)
        ++num39;
      for (int index1 = num38 + 1; index1 < num39 - 1; ++index1)
      {
        for (int index2 = num36 - num48; index2 < num36; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall != wallType)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
        ++num50;
        if (num50 >= num49)
        {
          index1 += num49;
          num50 = 0;
        }
      }
      int num51 = (int) ((double) vector2.X - num32 * 0.6);
      int num52 = (int) ((double) vector2.X + num32 * 0.6);
      int num53 = (int) ((double) vector2.Y - num33 * 0.6);
      int num54 = (int) ((double) vector2.Y + num33 * 0.6);
      if (num51 < 0)
        num51 = 0;
      if (num52 > (int) Main.maxTilesX)
        num52 = (int) Main.maxTilesX;
      if (num53 < 0)
        num53 = 0;
      if (num54 > (int) Main.maxTilesY)
        num54 = (int) Main.maxTilesY;
      for (int index1 = num51; index1 < num52; ++index1)
      {
        for (int index2 = num53; index2 < num54; ++index2)
          Main.tile[index1, index2].wall = (byte) 0;
      }
      int num55 = (int) ((double) vector2.X - num32 * 0.5);
      int num56 = (int) ((double) vector2.X + num32 * 0.5);
      int num57 = (int) ((double) vector2.Y - num33 * 0.5);
      int index3 = (int) ((double) vector2.Y + num33 * 0.5);
      if (num55 < 0)
        num55 = 0;
      if (num56 > (int) Main.maxTilesX)
        num56 = (int) Main.maxTilesX;
      if (num57 < 0)
        num57 = 0;
      if (index3 > (int) Main.maxTilesY)
        index3 = (int) Main.maxTilesY;
      for (int index1 = num55; index1 < num56; ++index1)
      {
        for (int index2 = num57; index2 < index3; ++index2)
        {
          Main.tile[index1, index2].active = (byte) 0;
          Main.tile[index1, index2].wall = (byte) 0;
        }
      }
      for (int index1 = num55; index1 < num56; ++index1)
      {
        if ((int) Main.tile[index1, index3].active == 0)
        {
          Main.tile[index1, index3].active = (byte) 1;
          Main.tile[index1, index3].type = (byte) 19;
        }
      }
      Main.dungeonX = (short) vector2.X;
      Main.dungeonY = (short) index3;
      int index4 = NPC.NewNPC((int) Main.dungeonX * 16 + 8, (int) Main.dungeonY * 16, 37, 0);
      Main.npc[index4].homeless = false;
      Main.npc[index4].homeTileX = Main.dungeonX;
      Main.npc[index4].homeTileY = Main.dungeonY;
      if (num4 == 1)
      {
        int num58 = 0;
        for (int index1 = num56; index1 < num56 + 25; ++index1)
        {
          ++num58;
          for (int index2 = index3 + num58; index2 < index3 + 25; ++index2)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
      }
      else
      {
        int num58 = 0;
        for (int index1 = num55; index1 > num55 - 25; --index1)
        {
          ++num58;
          for (int index2 = index3 + num58; index2 < index3 + 25; ++index2)
          {
            Main.tile[index1, index2].active = (byte) 1;
            Main.tile[index1, index2].type = (byte) tileType;
          }
        }
      }
      int num59 = 1 + WorldGen.genRand.Next(2);
      int num60 = 2 + WorldGen.genRand.Next(4);
      int num61 = 0;
      int num62 = (int) ((double) vector2.X - num32 * 0.5);
      int num63 = (int) ((double) vector2.X + num32 * 0.5);
      int num64 = num62 + 2;
      int num65 = num63 - 2;
      for (int index1 = num64; index1 < num65; ++index1)
      {
        for (int index2 = num57; index2 < index3; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall == 0)
            Main.tile[index1, index2].wall = (byte) wallType;
        }
        if (++num61 >= num60)
        {
          index1 += num60 * 2;
          num61 = 0;
        }
      }
      vector2.X -= (float) (num32 * 0.600000023841858) * (float) num4;
      vector2.Y += (float) num33 * 0.5f;
      double num66 = 15.0;
      double num67 = 3.0;
      vector2.Y -= (float) num67 * 0.5f;
      int num68 = (int) ((double) vector2.X - num66 * 0.5);
      int num69 = (int) ((double) vector2.X + num66 * 0.5);
      int num70 = (int) ((double) vector2.Y - num67 * 0.5);
      int num71 = (int) ((double) vector2.Y + num67 * 0.5);
      if (num68 < 0)
        num68 = 0;
      if (num69 > (int) Main.maxTilesX)
        num69 = (int) Main.maxTilesX;
      if (num70 < 0)
        num70 = 0;
      if (num71 > (int) Main.maxTilesY)
        num71 = (int) Main.maxTilesY;
      for (int index1 = num68; index1 < num69; ++index1)
      {
        for (int index2 = num70; index2 < num71; ++index2)
          Main.tile[index1, index2].active = (byte) 0;
      }
      if (num4 < 0)
        --vector2.X;
      WorldGen.PlaceTile((int) vector2.X, (int) vector2.Y + 1, 10, false, false, -1, 0);
    }

    public static bool AddBuriedChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
    {
      for (int index1 = j; index1 < (int) Main.maxTilesY; ++index1)
      {
        if ((int) Main.tile[i, index1].active != 0 && Main.tileSolid[(int) Main.tile[i, index1].type])
        {
          bool flag = false;
          int num1 = i;
          int num2 = index1;
          int style = 0;
          if (num2 >= Main.worldSurface + 25 || contain > 0)
            style = 1;
          if (Style >= 0)
            style = Style;
          if (num2 > (int) Main.maxTilesY - 205 && contain == 0)
          {
            if (WorldGen.hellChest == 0)
            {
              contain = 274;
              style = 4;
              flag = true;
            }
            else if (WorldGen.hellChest == 1)
            {
              contain = 220;
              style = 4;
              flag = true;
            }
            else if (WorldGen.hellChest == 2)
            {
              contain = 112;
              style = 4;
              flag = true;
            }
            else if (WorldGen.hellChest == 3)
            {
              contain = 218;
              style = 4;
              flag = true;
              WorldGen.hellChest = 0;
            }
          }
          int index2 = WorldGen.PlaceChest(num1 - 1, num2 - 1, notNearOtherChests, style);
          if (index2 < 0)
            return false;
          if (flag)
            ++WorldGen.hellChest;
          int index3 = 0;
          do
          {
            if (num2 < Main.worldSurface + 25)
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain, 1, false);
                Main.chest[index2].item[index3].Prefix(-1);
              }
              else
              {
                switch (WorldGen.genRand.Next(7))
                {
                  case 0:
                    Main.chest[index2].item[index3].SetDefaults(280, 1, false);
                    Main.chest[index2].item[index3].Prefix(-1);
                    break;
                  case 1:
                    Main.chest[index2].item[index3].SetDefaults(281, 1, false);
                    Main.chest[index2].item[index3].Prefix(-1);
                    break;
                  case 2:
                    Main.chest[index2].item[index3].SetDefaults(284, 1, false);
                    Main.chest[index2].item[index3].Prefix(-1);
                    break;
                  case 3:
                    Main.chest[index2].item[index3].SetDefaults(282, WorldGen.genRand.Next(50, 75), false);
                    break;
                  case 4:
                    Main.chest[index2].item[index3].SetDefaults(279, WorldGen.genRand.Next(25, 50), false);
                    break;
                  default:
                    if (WorldGen.genRand.Next(32) == 0)
                    {
                      Main.chest[index2].item[index3].SetDefaults(603, 1, false);
                      break;
                    }
                    else
                    {
                      Main.chest[index2].item[index3].SetDefaults(285, 1, false);
                      Main.chest[index2].item[index3].Prefix(-1);
                      break;
                    }
                }
              }
              ++index3;
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(168, WorldGen.genRand.Next(3, 6), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(WorldGen.genRand.Next(2) == 0 ? 20 : 22, WorldGen.genRand.Next(3, 11), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(WorldGen.genRand.Next(2) == 0 ? 40 : 42, WorldGen.genRand.Next(25, 51), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(28, WorldGen.genRand.Next(3, 6), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int num3 = WorldGen.genRand.Next(4);
                WorldGen.genRand.Next(1, 3);
                int Type = num3 != 0 ? (num3 != 1 ? (num3 != 2 ? 290 : 299) : 298) : 292;
                Main.chest[index2].item[index3].SetDefaults(Type, WorldGen.genRand.Next(1, 3), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(WorldGen.genRand.Next(2) == 0 ? 8 : 31, WorldGen.genRand.Next(10, 21), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(72, WorldGen.genRand.Next(10, 30), false);
                ++index3;
              }
            }
            else if (num2 < Main.rockLayer)
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain, 1, false);
                Main.chest[index2].item[index3].Prefix(-1);
                ++index3;
              }
              else
              {
                int num3 = WorldGen.genRand.Next(7);
                if (num3 == 0)
                {
                  Main.chest[index2].item[index3].SetDefaults(49, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 1)
                {
                  Main.chest[index2].item[index3].SetDefaults(50, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 2)
                  Main.chest[index2].item[index3].SetDefaults(52, 1, false);
                if (num3 == 3)
                {
                  Main.chest[index2].item[index3].SetDefaults(53, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 4)
                {
                  Main.chest[index2].item[index3].SetDefaults(54, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 5)
                {
                  Main.chest[index2].item[index3].SetDefaults(55, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                if (num3 == 6)
                {
                  Main.chest[index2].item[index3].SetDefaults(51, 1, false);
                  Main.chest[index2].item[index3].stack = (short) (WorldGen.genRand.Next(26) + 25);
                }
                ++index3;
                if (WorldGen.genRand.Next(40) == 0)
                {
                  Main.chest[index2].item[index3].SetDefaults(WorldGen.genRand.Next(2) + 603, 1, false);
                  ++index3;
                }
              }
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(166, WorldGen.genRand.Next(10, 20), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int Type = WorldGen.genRand.Next(21, 22);
                Main.chest[index2].item[index3].SetDefaults(Type, WorldGen.genRand.Next(5, 15), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int Stack = WorldGen.genRand.Next(25, 50);
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(40, Stack, false);
                else
                  Main.chest[index2].item[index3].SetDefaults(42, Stack, false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(28, WorldGen.genRand.Next(3, 6), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int Type;
                switch (WorldGen.genRand.Next(7))
                {
                  case 0:
                    Type = 289;
                    break;
                  case 1:
                    Type = 298;
                    break;
                  case 2:
                    Type = 299;
                    break;
                  case 3:
                    Type = 290;
                    break;
                  case 4:
                    Type = 303;
                    break;
                  case 5:
                    Type = 291;
                    break;
                  default:
                    Type = 304;
                    break;
                }
                Main.chest[index2].item[index3].SetDefaults(Type, WorldGen.genRand.Next(1, 3), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(8, WorldGen.genRand.Next(10, 21), false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(72, WorldGen.genRand.Next(50, 90), false);
                ++index3;
              }
            }
            else if (num2 < (int) Main.maxTilesY - 250)
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain, 1, false);
                Main.chest[index2].item[index3].Prefix(-1);
                ++index3;
              }
              else
              {
                int num3 = WorldGen.genRand.Next(7);
                if (num3 == 2 && WorldGen.genRand.Next(2) == 0)
                  num3 = WorldGen.genRand.Next(7);
                if (num3 == 0)
                {
                  Main.chest[index2].item[index3].SetDefaults(49, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                else if (num3 == 1)
                {
                  Main.chest[index2].item[index3].SetDefaults(50, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                else if (num3 == 2)
                {
                  Main.chest[index2].item[index3].SetDefaults(52, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                else if (num3 == 3)
                {
                  Main.chest[index2].item[index3].SetDefaults(53, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                else if (num3 == 4)
                {
                  Main.chest[index2].item[index3].SetDefaults(54, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                else if (num3 == 5)
                {
                  Main.chest[index2].item[index3].SetDefaults(55, 1, false);
                  Main.chest[index2].item[index3].Prefix(-1);
                }
                else
                  Main.chest[index2].item[index3].SetDefaults(51, WorldGen.genRand.Next(26) + 25, false);
                ++index3;
              }
              if (WorldGen.genRand.Next(5) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(43, 1, false);
                ++index3;
              }
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(167, 1, false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int num4 = WorldGen.genRand.Next(8) + 3;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(19, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(21, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int num4 = WorldGen.genRand.Next(26) + 25;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(41, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(279, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(1);
                int num4 = WorldGen.genRand.Next(3) + 3;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(188, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int num3 = WorldGen.genRand.Next(6);
                int num4 = WorldGen.genRand.Next(1, 3);
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(296, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(295, 1, false);
                if (num3 == 2)
                  Main.chest[index2].item[index3].SetDefaults(299, 1, false);
                if (num3 == 3)
                  Main.chest[index2].item[index3].SetDefaults(302, 1, false);
                if (num3 == 4)
                  Main.chest[index2].item[index3].SetDefaults(303, 1, false);
                if (num3 == 5)
                  Main.chest[index2].item[index3].SetDefaults(305, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 1)
              {
                int num3 = WorldGen.genRand.Next(4);
                int num4 = WorldGen.genRand.Next(1, 3);
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(301, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(302, 1, false);
                if (num3 == 2)
                  Main.chest[index2].item[index3].SetDefaults(297, 1, false);
                if (num3 == 3)
                  Main.chest[index2].item[index3].SetDefaults(304, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int num4 = WorldGen.genRand.Next(15) + 15;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(8, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(282, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(73, 1, false);
                Main.chest[index2].item[index3].stack = (short) WorldGen.genRand.Next(1, 3);
                ++index3;
              }
              if (WorldGen.genRand.Next(32) == 0)
                Main.chest[index2].item[index3].SetDefaults(621, 1, false);
              else if (WorldGen.genRand.Next(48) == 0)
                Main.chest[index2].item[index3].SetDefaults(623, 1, false);
            }
            else
            {
              if (contain > 0)
              {
                Main.chest[index2].item[index3].SetDefaults(contain, 1, false);
                Main.chest[index2].item[index3].Prefix(-1);
                ++index3;
              }
              else
              {
                switch (WorldGen.genRand.Next(4))
                {
                  case 0:
                    Main.chest[index2].item[index3].SetDefaults(49, 1, false);
                    Main.chest[index2].item[index3].Prefix(-1);
                    break;
                  case 1:
                    Main.chest[index2].item[index3].SetDefaults(50, 1, false);
                    Main.chest[index2].item[index3].Prefix(-1);
                    break;
                  case 2:
                    Main.chest[index2].item[index3].SetDefaults(53, 1, false);
                    Main.chest[index2].item[index3].Prefix(-1);
                    break;
                  default:
                    Main.chest[index2].item[index3].SetDefaults(54, 1, false);
                    Main.chest[index2].item[index3].Prefix(-1);
                    break;
                }
                ++index3;
              }
              if (WorldGen.genRand.Next(3) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(167, 1, false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int num4 = WorldGen.genRand.Next(15) + 15;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(117, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(19, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int num4 = WorldGen.genRand.Next(25) + 50;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(265, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(278, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int num4 = WorldGen.genRand.Next(15) + 15;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(226, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(227, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(4) > 0)
              {
                int num3 = WorldGen.genRand.Next(7);
                int num4 = WorldGen.genRand.Next(1, 3);
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(296, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(295, 1, false);
                if (num3 == 2)
                  Main.chest[index2].item[index3].SetDefaults(293, 1, false);
                if (num3 == 3)
                  Main.chest[index2].item[index3].SetDefaults(288, 1, false);
                if (num3 == 4)
                  Main.chest[index2].item[index3].SetDefaults(294, 1, false);
                if (num3 == 5)
                  Main.chest[index2].item[index3].SetDefaults(297, 1, false);
                if (num3 == 6)
                  Main.chest[index2].item[index3].SetDefaults(304, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(3) > 0)
              {
                int num3 = WorldGen.genRand.Next(5);
                int num4 = WorldGen.genRand.Next(1, 3);
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(305, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(301, 1, false);
                if (num3 == 2)
                  Main.chest[index2].item[index3].SetDefaults(302, 1, false);
                if (num3 == 3)
                  Main.chest[index2].item[index3].SetDefaults(288, 1, false);
                if (num3 == 4)
                  Main.chest[index2].item[index3].SetDefaults(300, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                int num3 = WorldGen.genRand.Next(2);
                int num4 = WorldGen.genRand.Next(15) + 15;
                if (num3 == 0)
                  Main.chest[index2].item[index3].SetDefaults(8, 1, false);
                if (num3 == 1)
                  Main.chest[index2].item[index3].SetDefaults(282, 1, false);
                Main.chest[index2].item[index3].stack = (short) num4;
                ++index3;
              }
              else if (WorldGen.genRand.Next(48) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(625, 1, false);
                ++index3;
              }
              if (WorldGen.genRand.Next(2) == 0)
              {
                Main.chest[index2].item[index3].SetDefaults(73, 1, false);
                Main.chest[index2].item[index3].stack = (short) WorldGen.genRand.Next(2, 5);
                ++index3;
              }
            }
          }
          while (index3 == 0);
          return true;
        }
      }
      return false;
    }

    public static int OpenDoor(int i, int j, int direction)
    {
      if (!WorldGen.DoOpenDoor(i, j, direction))
      {
        direction = -direction;
        if (!WorldGen.DoOpenDoor(i, j, direction))
          direction = 0;
      }
      return direction;
    }

    public static bool CanOpenDoor(int i, int j)
    {
      bool flag = WorldGen.DoCanOpenDoor(i, j, 1);
      if (!flag)
        flag = WorldGen.DoCanOpenDoor(i, j, -1);
      return flag;
    }

    private static bool DoCanOpenDoor(int i, int j, int direction)
    {
      if ((int) Main.tile[i, j - 1].frameY == 0 && (int) Main.tile[i, j - 1].type == (int) Main.tile[i, j].type)
        --j;
      else if ((int) Main.tile[i, j - 2].frameY == 0 && (int) Main.tile[i, j - 2].type == (int) Main.tile[i, j].type)
        j -= 2;
      else if ((int) Main.tile[i, j + 1].frameY == 0 && (int) Main.tile[i, j + 1].type == (int) Main.tile[i, j].type)
        ++j;
      i += direction;
      for (int index1 = j; index1 < j + 3; ++index1)
      {
        if ((int) Main.tile[i, index1].active != 0)
        {
          int index2 = (int) Main.tile[i, index1].type;
          if (!Main.tileCut[index2] && index2 != 3 && (index2 != 24 && index2 != 52) && (index2 != 61 && index2 != 62 && (index2 != 69 && index2 != 71)) && (index2 != 73 && index2 != 74 && (index2 != 110 && index2 != 113) && index2 != 115))
            return false;
        }
      }
      return true;
    }

    private static bool DoOpenDoor(int i, int j, int direction)
    {
      int index1 = j;
      if ((int) Main.tile[i, j - 1].frameY == 0 && (int) Main.tile[i, j - 1].type == (int) Main.tile[i, j].type)
        --index1;
      else if ((int) Main.tile[i, j - 2].frameY == 0 && (int) Main.tile[i, j - 2].type == (int) Main.tile[i, j].type)
        index1 -= 2;
      else if ((int) Main.tile[i, j + 1].frameY == 0 && (int) Main.tile[i, j + 1].type == (int) Main.tile[i, j].type)
        ++index1;
      int index2 = i;
      int num1 = i;
      int i1;
      int num2;
      if (direction == -1)
      {
        --index2;
        i1 = num1 - 1;
        num2 = 36;
      }
      else
      {
        i1 = num1 + 1;
        num2 = 0;
      }
      bool flag1 = true;
      for (int j1 = index1; j1 < index1 + 3; ++j1)
      {
        if ((int) Main.tile[i1, j1].active != 0)
        {
          int index3 = (int) Main.tile[i1, j1].type;
          if (Main.tileCut[index3] || index3 == 3 || (index3 == 24 || index3 == 52) || (index3 == 61 || index3 == 62 || (index3 == 69 || index3 == 71)) || (index3 == 73 || index3 == 74 || (index3 == 110 || index3 == 113) || index3 == 115))
          {
            WorldGen.KillTile(i1, j1);
          }
          else
          {
            flag1 = false;
            break;
          }
        }
      }
      if (flag1)
      {
        if (Main.netMode != 1)
        {
          for (int index3 = index2; index3 <= index2 + 1; ++index3)
          {
            for (int index4 = index1; index4 <= index1 + 2; ++index4)
            {
              if (WorldGen.numNoWire < 999)
              {
                WorldGen.noWire[WorldGen.numNoWire].X = (short) index3;
                WorldGen.noWire[WorldGen.numNoWire].Y = (short) index4;
                ++WorldGen.numNoWire;
              }
            }
          }
        }
        Main.PlaySound(8, i * 16, j * 16, 1);
        Main.tile[index2, index1].active = (byte) 1;
        Main.tile[index2, index1].type = (byte) 11;
        Main.tile[index2, index1].frameY = (short) 0;
        Main.tile[index2, index1].frameX = (short) num2;
        Main.tile[index2 + 1, index1].active = (byte) 1;
        Main.tile[index2 + 1, index1].type = (byte) 11;
        Main.tile[index2 + 1, index1].frameY = (short) 0;
        Main.tile[index2 + 1, index1].frameX = (short) (num2 + 18);
        Main.tile[index2, index1 + 1].active = (byte) 1;
        Main.tile[index2, index1 + 1].type = (byte) 11;
        Main.tile[index2, index1 + 1].frameY = (short) 18;
        Main.tile[index2, index1 + 1].frameX = (short) num2;
        Main.tile[index2 + 1, index1 + 1].active = (byte) 1;
        Main.tile[index2 + 1, index1 + 1].type = (byte) 11;
        Main.tile[index2 + 1, index1 + 1].frameY = (short) 18;
        Main.tile[index2 + 1, index1 + 1].frameX = (short) (num2 + 18);
        Main.tile[index2, index1 + 2].active = (byte) 1;
        Main.tile[index2, index1 + 2].type = (byte) 11;
        Main.tile[index2, index1 + 2].frameY = (short) 36;
        Main.tile[index2, index1 + 2].frameX = (short) num2;
        Main.tile[index2 + 1, index1 + 2].active = (byte) 1;
        Main.tile[index2 + 1, index1 + 2].type = (byte) 11;
        Main.tile[index2 + 1, index1 + 2].frameY = (short) 36;
        Main.tile[index2 + 1, index1 + 2].frameX = (short) (num2 + 18);
        bool flag2 = WorldGen.tileFrameRecursion;
        WorldGen.tileFrameRecursion = false;
        for (int i2 = index2 - 1; i2 <= index2 + 2; ++i2)
        {
          for (int j1 = index1 - 1; j1 <= index1 + 2; ++j1)
            WorldGen.TileFrame(i2, j1, 0);
        }
        WorldGen.tileFrameRecursion = flag2;
      }
      return flag1;
    }

    public static void Check1xX(int x, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = j - (int) Main.tile[x, j].frameY / 18;
      int num2 = (int) Main.tile[x, j].frameX;
      int num3 = 3;
      if (type == 92)
        num3 = 6;
      for (int index = 0; index < num3; ++index)
      {
        if ((int) Main.tile[x, num1 + index].active == 0 || (int) Main.tile[x, num1 + index].type != type || ((int) Main.tile[x, num1 + index].frameY != index * 18 || (int) Main.tile[x, num1 + index].frameX != num2))
          goto label_9;
      }
      if ((int) Main.tile[x, num1 + num3].active != 0 && Main.tileSolid[(int) Main.tile[x, num1 + num3].type])
        return;
label_9:
      WorldGen.destroyObject = true;
      for (int index = 0; index < num3; ++index)
      {
        if ((int) Main.tile[x, num1 + index].type == type)
          WorldGen.KillTile(x, num1 + index);
      }
      if (!WorldGen.gen)
      {
        if (type == 92)
          Item.NewItem(x * 16, j * 16, 32, 32, 341, 1, false, 0);
        else if (type == 93)
          Item.NewItem(x * 16, j * 16, 32, 32, 342, 1, false, 0);
      }
      WorldGen.destroyObject = false;
    }

    public static void Check2xX(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int i1 = i;
      if ((int) Main.tile[i, j].frameX % 36 == 18)
        --i1;
      int num1 = j - (int) Main.tile[i1, j].frameY / 18;
      int num2 = (int) Main.tile[i1, j].frameX;
      int num3 = 3;
      if (type == 104)
        num3 = 5;
      for (int index = 0; index < num3; ++index)
      {
        if ((int) Main.tile[i1, num1 + index].active == 0 || (int) Main.tile[i1, num1 + index].type != type || ((int) Main.tile[i1, num1 + index].frameY != index * 18 || (int) Main.tile[i1, num1 + index].frameX != num2) || ((int) Main.tile[i1 + 1, num1 + index].active == 0 || (int) Main.tile[i1 + 1, num1 + index].type != type || ((int) Main.tile[i1 + 1, num1 + index].frameY != index * 18 || (int) Main.tile[i1 + 1, num1 + index].frameX != num2 + 18)))
          goto label_11;
      }
      if ((int) Main.tile[i1, num1 + num3].active != 0 && Main.tileSolid[(int) Main.tile[i1, num1 + num3].type] && ((int) Main.tile[i1 + 1, num1 + num3].active != 0 && Main.tileSolid[(int) Main.tile[i1 + 1, num1 + num3].type]))
        return;
label_11:
      WorldGen.destroyObject = true;
      for (int index = 0; index < num3; ++index)
      {
        if ((int) Main.tile[i1, num1 + index].type == type)
          WorldGen.KillTile(i1, num1 + index);
        if ((int) Main.tile[i1 + 1, num1 + index].type == type)
          WorldGen.KillTile(i1 + 1, num1 + index);
      }
      if (!WorldGen.gen)
      {
        if (type == 104)
          Item.NewItem(i1 * 16, j * 16, 32, 32, 359, 1, false, 0);
        else if (type == 105)
        {
          int num4 = num2 / 36;
          int Type;
          switch (num4)
          {
            case 0:
              Type = 360;
              break;
            case 1:
              Type = 52;
              break;
            default:
              Type = 438 + num4 - 2;
              break;
          }
          Item.NewItem(i1 * 16, j * 16, 32, 32, Type, 1, false, 0);
        }
      }
      WorldGen.destroyObject = false;
    }

    public static bool Place1xX(int x, int y, int type, int style = 0)
    {
      int num1 = style * 18;
      int num2 = 3;
      if (type == 92)
        num2 = 6;
      for (int index = y - num2 + 1; index < y + 1; ++index)
      {
        if ((int) Main.tile[x, index].active != 0 || type == 93 && (int) Main.tile[x, index].liquid > 0)
          return false;
      }
      if ((int) Main.tile[x, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[x, y + 1].type])
        return false;
      for (int index = 0; index < num2; ++index)
      {
        Main.tile[x, y - num2 + 1 + index].active = (byte) 1;
        Main.tile[x, y - num2 + 1 + index].frameY = (short) (index * 18);
        Main.tile[x, y - num2 + 1 + index].frameX = (short) num1;
        Main.tile[x, y - num2 + 1 + index].type = (byte) type;
      }
      return true;
    }

    public static bool Place2xX(int x, int y, int type, int style = 0)
    {
      int num1 = style * 36;
      int num2 = 3;
      if (type == 104)
        num2 = 5;
      for (int index = y - num2 + 1; index < y + 1; ++index)
      {
        if ((int) Main.tile[x, index].active != 0 || (int) Main.tile[x + 1, index].active != 0)
          return false;
      }
      if ((int) Main.tile[x, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || ((int) Main.tile[x + 1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[x + 1, y + 1].type]))
        return false;
      for (int index = 0; index < num2; ++index)
      {
        Main.tile[x, y - num2 + 1 + index].active = (byte) 1;
        Main.tile[x, y - num2 + 1 + index].frameY = (short) (index * 18);
        Main.tile[x, y - num2 + 1 + index].frameX = (short) num1;
        Main.tile[x, y - num2 + 1 + index].type = (byte) type;
        Main.tile[x + 1, y - num2 + 1 + index].active = (byte) 1;
        Main.tile[x + 1, y - num2 + 1 + index].frameY = (short) (index * 18);
        Main.tile[x + 1, y - num2 + 1 + index].frameX = (short) (num1 + 18);
        Main.tile[x + 1, y - num2 + 1 + index].type = (byte) type;
      }
      return true;
    }

    public static void Check1x2(int x, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int j1 = j;
      bool flag = true;
      int num1 = (int) Main.tile[x, j1].frameY;
      int num2 = num1 / 40;
      if (num1 % 40 == 18)
        --j1;
      if ((int) Main.tile[x, j1].frameY == 40 * num2 && (int) Main.tile[x, j1 + 1].frameY == 40 * num2 + 18 && ((int) Main.tile[x, j1].type == type && (int) Main.tile[x, j1 + 1].type == type))
        flag = false;
      if ((int) Main.tile[x, j1 + 2].active == 0 || !Main.tileSolid[(int) Main.tile[x, j1 + 2].type])
        flag = true;
      if ((int) Main.tile[x, j1 + 2].type != 2 && (int) Main.tile[x, j1 + 2].type != 109 && ((int) Main.tile[x, j1 + 2].type != 147 && (int) Main.tile[x, j1].type == 20))
        flag = true;
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      if ((int) Main.tile[x, j1].type == type)
        WorldGen.KillTile(x, j1);
      if ((int) Main.tile[x, j1 + 1].type == type)
        WorldGen.KillTile(x, j1 + 1);
      if (!WorldGen.gen)
      {
        if (type == 15)
        {
          if (num2 == 1)
            Item.NewItem(x * 16, j1 * 16, 32, 32, 358, 1, false, 0);
          else
            Item.NewItem(x * 16, j1 * 16, 32, 32, 34, 1, false, 0);
        }
        else if (type == 134)
          Item.NewItem(x * 16, j1 * 16, 32, 32, 525, 1, false, 0);
      }
      WorldGen.destroyObject = false;
    }

    public static void CheckOnTableClaypot(int x, int y)
    {
      if ((int) Main.tile[x, y + 1].active != 0 && Main.tileTable[(int) Main.tile[x, y + 1].type] || (int) Main.tile[x, y + 1].active != 0 && Main.tileSolid[(int) Main.tile[x, y + 1].type])
        return;
      WorldGen.KillTile(x, y);
    }

    public static void CheckOnTable1x1(int x, int y)
    {
      if ((int) Main.tile[x, y + 1].active != 0 && Main.tileTable[(int) Main.tile[x, y + 1].type])
        return;
      WorldGen.KillTile(x, y);
    }

    public static void CheckSign(int x, int y, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = x - 2;
      int num2 = x + 3;
      int num3 = y - 2;
      int num4 = y + 3;
      if (num1 < 0 || num2 > (int) Main.maxTilesX || (num3 < 0 || num4 > (int) Main.maxTilesY))
        return;
      bool flag = false;
      int num5 = (int) Main.tile[x, y].frameX / 18 & 1;
      int num6 = (int) Main.tile[x, y].frameY / 18;
      int x1 = x - num5;
      int y1 = y - num6;
      int num7 = (int) Main.tile[x1, y1].frameX / 36;
      int num8 = x1;
      int num9 = x1 + 2;
      int num10 = y1;
      int num11 = y1 + 2;
      int num12 = 0;
      for (int index1 = num8; index1 < num9; ++index1)
      {
        int num13 = 0;
        for (int index2 = num10; index2 < num11; ++index2)
        {
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != type)
          {
            flag = true;
            break;
          }
          else if ((int) Main.tile[index1, index2].frameX / 18 != num12 + num7 * 2 || (int) Main.tile[index1, index2].frameY / 18 != num13)
          {
            flag = true;
            break;
          }
          else
            ++num13;
        }
        ++num12;
      }
      if (!flag)
      {
        if (type == 85)
        {
          if ((int) Main.tile[x1, y1 + 2].active != 0 && Main.tileSolid[(int) Main.tile[x1, y1 + 2].type] && ((int) Main.tile[x1 + 1, y1 + 2].active != 0 && Main.tileSolid[(int) Main.tile[x1 + 1, y1 + 2].type]))
            num7 = 0;
          else
            flag = true;
        }
        else if ((int) Main.tile[x1, y1 + 2].active != 0 && Main.tileSolid[(int) Main.tile[x1, y1 + 2].type] && ((int) Main.tile[x1 + 1, y1 + 2].active != 0 && Main.tileSolid[(int) Main.tile[x1 + 1, y1 + 2].type]))
          num7 = 0;
        else if ((int) Main.tile[x1, y1 - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x1, y1 - 1].type] && ((int) Main.tile[x1 + 1, y1 - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x1 + 1, y1 - 1].type]))
          num7 = 1;
        else if ((int) Main.tile[x1 - 1, y1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x1 - 1, y1].type] && ((int) Main.tile[x1 - 1, y1 + 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x1 - 1, y1 + 1].type]))
          num7 = 2;
        else if ((int) Main.tile[x1 + 2, y1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x1 + 2, y1].type] && ((int) Main.tile[x1 + 2, y1 + 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x1 + 2, y1 + 1].type]))
          num7 = 3;
        else
          flag = true;
      }
      if (flag)
      {
        WorldGen.destroyObject = true;
        for (int i = num8; i < num9; ++i)
        {
          for (int j = num10; j < num11; ++j)
          {
            if ((int) Main.tile[i, j].type == type)
              WorldGen.KillTile(i, j);
          }
        }
        Sign.KillSign(x1, y1);
        if (!WorldGen.gen)
        {
          if (type == 85)
            Item.NewItem(x * 16, y * 16, 32, 32, 321, 1, false, 0);
          else
            Item.NewItem(x * 16, y * 16, 32, 32, 171, 1, false, 0);
        }
        WorldGen.destroyObject = false;
      }
      else
      {
        int num13 = 36 * num7;
        for (int index1 = 0; index1 < 2; ++index1)
        {
          for (int index2 = 0; index2 < 2; ++index2)
          {
            Main.tile[x1 + index1, y1 + index2].active = (byte) 1;
            Main.tile[x1 + index1, y1 + index2].type = (byte) type;
            Main.tile[x1 + index1, y1 + index2].frameX = (short) (num13 + 18 * index1);
            Main.tile[x1 + index1, y1 + index2].frameY = (short) (18 * index2);
          }
        }
      }
    }

    public static bool PlaceSign(int x, int y, int type)
    {
      int num1 = x - 2;
      int num2 = x + 3;
      int num3 = y - 2;
      int num4 = y + 3;
      if (num1 < 0 || num2 > (int) Main.maxTilesX || (num3 < 0 || num4 > (int) Main.maxTilesY))
        return false;
      int index1 = x;
      int index2 = y;
      int num5 = 0;
      if (type == 55)
      {
        if ((int) Main.tile[x, y + 1].active != 0 && Main.tileSolid[(int) Main.tile[x, y + 1].type] && ((int) Main.tile[x + 1, y + 1].active != 0 && Main.tileSolid[(int) Main.tile[x + 1, y + 1].type]))
        {
          --index2;
          num5 = 0;
        }
        else if ((int) Main.tile[x, y - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x, y - 1].type] && ((int) Main.tile[x + 1, y - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x + 1, y - 1].type]))
          num5 = 1;
        else if ((int) Main.tile[x - 1, y].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x - 1, y].type] && (!Main.tileNoAttach[(int) Main.tile[x - 1, y].type] && (int) Main.tile[x - 1, y + 1].active != 0) && (Main.tileSolidNotSolidTop[(int) Main.tile[x - 1, y + 1].type] && !Main.tileNoAttach[(int) Main.tile[x - 1, y + 1].type]))
        {
          num5 = 2;
        }
        else
        {
          if ((int) Main.tile[x + 1, y].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x + 1, y].type] || (Main.tileNoAttach[(int) Main.tile[x + 1, y].type] || (int) Main.tile[x + 1, y + 1].active == 0) || (!Main.tileSolidNotSolidTop[(int) Main.tile[x + 1, y + 1].type] || Main.tileNoAttach[(int) Main.tile[x + 1, y + 1].type]))
            return false;
          --index1;
          num5 = 3;
        }
      }
      else if (type == 85)
      {
        if ((int) Main.tile[x, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || ((int) Main.tile[x + 1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[x + 1, y + 1].type]))
          return false;
        --index2;
        num5 = 0;
      }
      if ((int) Main.tile[index1, index2].active != 0 || (int) Main.tile[index1 + 1, index2].active != 0 || ((int) Main.tile[index1, index2 + 1].active != 0 || (int) Main.tile[index1 + 1, index2 + 1].active != 0))
        return false;
      int num6 = 36 * num5;
      for (int index3 = 0; index3 < 2; ++index3)
      {
        for (int index4 = 0; index4 < 2; ++index4)
        {
          Main.tile[index1 + index3, index2 + index4].active = (byte) 1;
          Main.tile[index1 + index3, index2 + index4].type = (byte) type;
          Main.tile[index1 + index3, index2 + index4].frameX = (short) (num6 + 18 * index3);
          Main.tile[index1 + index3, index2 + index4].frameY = (short) (18 * index4);
        }
      }
      return true;
    }

    public static bool Place1x1(int x, int y, int type, int style = 0)
    {
      if ((int) Main.tile[x, y].active != 0 || !WorldGen.SolidTileUnsafe(x, y + 1))
        return false;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].type = (byte) type;
      if (type == 144)
      {
        Main.tile[x, y].frameX = (short) (style * 18);
        Main.tile[x, y].frameY = (short) 0;
      }
      else
        Main.tile[x, y].frameY = (short) (style * 18);
      return true;
    }

    public static void Check1x1(int x, int y, int type)
    {
      if ((int) Main.tile[x, y + 1].active != 0 && Main.tileSolid[(int) Main.tile[x, y + 1].type])
        return;
      WorldGen.KillTile(x, y);
    }

    public static bool PlaceOnTable1x1(int x, int y, int type, int style = 0)
    {
      if ((int) Main.tile[x, y].active != 0 || (int) Main.tile[x, y + 1].active == 0 || !Main.tileTable[(int) Main.tile[x, y + 1].type] || type == 78 && ((int) Main.tile[x, y].active != 0 || (int) Main.tile[x, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[x, y + 1].type]))
        return false;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameX = (short) (style * 18);
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].type = (byte) type;
      if (type == 50)
        Main.tile[x, y].frameX = (short) (18 * WorldGen.genRand.Next(5));
      return true;
    }

    public static bool PlaceAlch(int x, int y, int style)
    {
      if ((int) Main.tile[x, y].active == 0 && (int) Main.tile[x, y + 1].active != 0)
      {
        bool flag = false;
        if (style == 0)
        {
          if ((int) Main.tile[x, y + 1].type != 2 && (int) Main.tile[x, y + 1].type != 78 && (int) Main.tile[x, y + 1].type != 109)
            flag = true;
          if ((int) Main.tile[x, y].liquid > 0)
            flag = true;
        }
        else if (style == 1)
        {
          if ((int) Main.tile[x, y + 1].type != 60 && (int) Main.tile[x, y + 1].type != 78)
            flag = true;
          if ((int) Main.tile[x, y].liquid > 0)
            flag = true;
        }
        else if (style == 2)
        {
          if ((int) Main.tile[x, y + 1].type != 0 && (int) Main.tile[x, y + 1].type != 59 && (int) Main.tile[x, y + 1].type != 78)
            flag = true;
          if ((int) Main.tile[x, y].liquid > 0)
            flag = true;
        }
        else if (style == 3)
        {
          if ((int) Main.tile[x, y + 1].type != 23 && (int) Main.tile[x, y + 1].type != 25 && (int) Main.tile[x, y + 1].type != 78)
            flag = true;
          if ((int) Main.tile[x, y].liquid > 0)
            flag = true;
        }
        else if (style == 4)
        {
          if ((int) Main.tile[x, y + 1].type != 53 && (int) Main.tile[x, y + 1].type != 78 && (int) Main.tile[x, y + 1].type != 116)
            flag = true;
          if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava != 0)
            flag = true;
        }
        else if (style == 5)
        {
          if ((int) Main.tile[x, y + 1].type != 57 && (int) Main.tile[x, y + 1].type != 78)
            flag = true;
          if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava == 0)
            flag = true;
        }
        if (!flag)
        {
          Main.tile[x, y].active = (byte) 1;
          Main.tile[x, y].type = (byte) 82;
          Main.tile[x, y].frameX = (short) (18 * style);
          Main.tile[x, y].frameY = (short) 0;
          return true;
        }
      }
      return false;
    }

    public static void GrowAlch(int x, int y)
    {
      if ((int) Main.tile[x, y].active == 0)
        return;
      if ((int) Main.tile[x, y].type == 82 && WorldGen.genRand.Next(50) == 0)
      {
        Main.tile[x, y].type = (byte) 83;
        WorldGen.SquareTileFrame(x, y, -1);
        if (Main.netMode != 2)
          return;
        NetMessage.SendTile(x, y);
      }
      else
      {
        if ((int) Main.tile[x, y].frameX != 36)
          return;
        if ((int) Main.tile[x, y].type == 83)
          Main.tile[x, y].type = (byte) 84;
        else
          Main.tile[x, y].type = (byte) 83;
        if (Main.netMode != 2)
          return;
        NetMessage.SendTile(x, y);
      }
    }

    public static void PlantAlch()
    {
      int index1 = WorldGen.genRand.Next(20, (int) Main.maxTilesX - 20);
      int index2;
      switch (WorldGen.genRand.Next(40))
      {
        case 0:
          index2 = WorldGen.genRand.Next(Main.rockLayer + (int) Main.maxTilesY >> 1, (int) Main.maxTilesY - 20);
          break;
        case 1:
        case 2:
        case 3:
        case 4:
          index2 = WorldGen.genRand.Next((int) Main.maxTilesY - 20);
          break;
        default:
          index2 = WorldGen.genRand.Next(Main.worldSurface, (int) Main.maxTilesY - 20);
          break;
      }
      while (index2 < (int) Main.maxTilesY - 20 && (int) Main.tile[index1, index2].active == 0)
        ++index2;
      if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2 - 1].active != 0 || (int) Main.tile[index1, index2 - 1].liquid != 0)
        return;
      int style = -1;
      byte num = Main.tile[index1, index2].type;
      if ((uint) num <= 53U)
      {
        switch (num)
        {
          case (byte) 0:
            goto label_13;
          case (byte) 2:
            break;
          case (byte) 23:
          case (byte) 25:
            style = 3;
            goto label_17;
          case (byte) 53:
            goto label_15;
          default:
            goto label_17;
        }
      }
      else
      {
        switch (num)
        {
          case (byte) 57:
            style = 5;
            goto label_17;
          case (byte) 59:
            goto label_13;
          case (byte) 60:
            style = 1;
            goto label_17;
          case (byte) 109:
            break;
          case (byte) 116:
            goto label_15;
          default:
            goto label_17;
        }
      }
      style = 0;
      goto label_17;
label_13:
      style = 2;
      goto label_17;
label_15:
      style = 4;
label_17:
      if (style < 0 || !WorldGen.PlaceAlch(index1, index2 - 1, style) || Main.netMode != 2)
        return;
      NetMessage.SendTile(index1, index2 - 1);
    }

    public static void CheckAlch(int x, int y)
    {
      bool flag = (int) Main.tile[x, y + 1].active == 0;
      Main.tile[x, y].frameY = (short) 0;
      if (!flag)
      {
        int num1 = (int) Main.tile[x, y].frameX / 18;
        int num2 = (int) Main.tile[x, y + 1].type;
        if (num1 == 0)
        {
          if (num2 != 109 && num2 != 2 && num2 != 78)
            flag = true;
          else if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava != 0)
            flag = true;
        }
        else if (num1 == 1)
        {
          if (num2 != 60 && num2 != 78)
            flag = true;
          else if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava != 0)
            flag = true;
        }
        else if (num1 == 2)
        {
          if (num2 != 0 && num2 != 59 && num2 != 78)
            flag = true;
          else if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava != 0)
            flag = true;
        }
        else if (num1 == 3)
        {
          if (num2 != 23 && num2 != 25 && num2 != 78)
            flag = true;
          else if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava != 0)
            flag = true;
        }
        else
        {
          int num3 = (int) Main.tile[x, y].type;
          if (num1 == 4)
          {
            if (num2 != 53 && num2 != 78 && num2 != 116)
              flag = true;
            else if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava != 0)
              flag = true;
            if (num3 != 82 && (int) Main.tile[x, y].lava == 0 && Main.netMode != 1)
            {
              if ((int) Main.tile[x, y].liquid > 16)
              {
                if (num3 == 83)
                {
                  Main.tile[x, y].type = (byte) 84;
                  if (Main.netMode == 2)
                    NetMessage.SendTile(x, y);
                }
              }
              else if (num3 == 84)
              {
                Main.tile[x, y].type = (byte) 83;
                if (Main.netMode == 2)
                  NetMessage.SendTile(x, y);
              }
            }
          }
          else if (num1 == 5)
          {
            if (num2 != 57 && num2 != 78)
              flag = true;
            else if ((int) Main.tile[x, y].liquid > 0 && (int) Main.tile[x, y].lava == 0)
              flag = true;
            if (Main.netMode != 1 && num3 != 82 && (int) Main.tile[x, y].lava != 0)
            {
              if ((int) Main.tile[x, y].liquid > 16)
              {
                if (num3 == 83)
                {
                  Main.tile[x, y].type = (byte) 84;
                  if (Main.netMode == 2)
                    NetMessage.SendTile(x, y);
                }
              }
              else if (num3 == 84)
              {
                Main.tile[x, y].type = (byte) 83;
                if (Main.netMode == 2)
                  NetMessage.SendTile(x, y);
              }
            }
          }
        }
      }
      if (!flag)
        return;
      WorldGen.KillTile(x, y);
    }

    public static void CheckBanner(int x, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = j - (int) Main.tile[x, j].frameY / 18;
      int num2 = (int) Main.tile[x, j].frameX;
      bool flag = false;
      for (int index = 0; index < 3; ++index)
      {
        if ((int) Main.tile[x, num1 + index].active == 0)
        {
          flag = true;
          break;
        }
        else if ((int) Main.tile[x, num1 + index].type != 91)
        {
          flag = true;
          break;
        }
        else if ((int) Main.tile[x, num1 + index].frameY != index * 18)
        {
          flag = true;
          break;
        }
        else if ((int) Main.tile[x, num1 + index].frameX != num2)
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        flag = (int) Main.tile[x, num1 - 1].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x, num1 - 1].type];
      if (!flag)
        return;
      WorldGen.destroyObject = true;
      for (int index = 0; index < 3; ++index)
      {
        if ((int) Main.tile[x, num1 + index].type == 91)
          WorldGen.KillTile(x, num1 + index);
      }
      if (!WorldGen.gen)
        Item.NewItem(x * 16, (num1 + 1) * 16, 32, 32, 337 + num2 / 18, 1, false, 0);
      WorldGen.destroyObject = false;
    }

    public static bool PlaceBanner(int x, int y, int type, int style = 0)
    {
      int num = style * 18;
      if ((int) Main.tile[x, y - 1].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x, y - 1].type] || ((int) Main.tile[x, y].active != 0 || (int) Main.tile[x, y + 1].active != 0) || (int) Main.tile[x, y + 2].active != 0)
        return false;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].frameX = (short) num;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x, y + 1].active = (byte) 1;
      Main.tile[x, y + 1].frameY = (short) 18;
      Main.tile[x, y + 1].frameX = (short) num;
      Main.tile[x, y + 1].type = (byte) type;
      Main.tile[x, y + 2].active = (byte) 1;
      Main.tile[x, y + 2].frameY = (short) 36;
      Main.tile[x, y + 2].frameX = (short) num;
      Main.tile[x, y + 2].type = (byte) type;
      return true;
    }

    public static bool PlaceMan(int i, int j, int dir)
    {
      for (int index1 = i; index1 <= i + 1; ++index1)
      {
        for (int index2 = j - 2; index2 <= j; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0)
            return false;
        }
      }
      if (!WorldGen.SolidTileUnsafe(i, j + 1) || !WorldGen.SolidTileUnsafe(i + 1, j + 1))
        return false;
      int num = dir == 1 ? 36 : 0;
      Main.tile[i, j - 2].active = (byte) 1;
      Main.tile[i, j - 2].frameY = (short) 0;
      Main.tile[i, j - 2].frameX = (short) (byte) num;
      Main.tile[i, j - 2].type = (byte) sbyte.MinValue;
      Main.tile[i, j - 1].active = (byte) 1;
      Main.tile[i, j - 1].frameY = (short) 18;
      Main.tile[i, j - 1].frameX = (short) (byte) num;
      Main.tile[i, j - 1].type = (byte) sbyte.MinValue;
      Main.tile[i, j].active = (byte) 1;
      Main.tile[i, j].frameY = (short) 36;
      Main.tile[i, j].frameX = (short) (byte) num;
      Main.tile[i, j].type = (byte) sbyte.MinValue;
      Main.tile[i + 1, j - 2].active = (byte) 1;
      Main.tile[i + 1, j - 2].frameY = (short) 0;
      Main.tile[i + 1, j - 2].frameX = (short) (byte) (18 + num);
      Main.tile[i + 1, j - 2].type = (byte) sbyte.MinValue;
      Main.tile[i + 1, j - 1].active = (byte) 1;
      Main.tile[i + 1, j - 1].frameY = (short) 18;
      Main.tile[i + 1, j - 1].frameX = (short) (byte) (18 + num);
      Main.tile[i + 1, j - 1].type = (byte) sbyte.MinValue;
      Main.tile[i + 1, j].active = (byte) 1;
      Main.tile[i + 1, j].frameY = (short) 36;
      Main.tile[i + 1, j].frameX = (short) (byte) (18 + num);
      Main.tile[i + 1, j].type = (byte) sbyte.MinValue;
      return true;
    }

    public static void CheckMan(int i, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = i;
      int num2 = j - (int) Main.tile[i, j].frameY / 18;
      int num3 = (int) Main.tile[i, j].frameX % 100 % 36;
      int i1 = num1 - num3 / 18;
      bool flag = false;
      for (int index1 = 0; index1 <= 1; ++index1)
      {
        for (int index2 = 0; index2 <= 2; ++index2)
        {
          int index3 = i1 + index1;
          int index4 = num2 + index2;
          int num4 = (int) Main.tile[index3, index4].frameX % 100;
          if (num4 >= 36)
            num4 -= 36;
          if ((int) Main.tile[index3, index4].active == 0 || (int) Main.tile[index3, index4].type != 128 || ((int) Main.tile[index3, index4].frameY != index2 * 18 || num4 != index1 * 18))
          {
            flag = true;
            break;
          }
        }
      }
      if (!flag && WorldGen.SolidTileUnsafe(i1, num2 + 3) && WorldGen.SolidTileUnsafe(i1 + 1, num2 + 3))
        return;
      WorldGen.destroyObject = true;
      for (int index1 = 0; index1 <= 1; ++index1)
      {
        for (int index2 = 0; index2 <= 2; ++index2)
        {
          int i2 = i1 + index1;
          int j1 = num2 + index2;
          if ((int) Main.tile[i2, j1].active != 0 && (int) Main.tile[i2, j1].type == 128)
            WorldGen.KillTile(i2, j1);
        }
      }
      if (!WorldGen.gen)
        Item.NewItem(i * 16, j * 16, 32, 32, 498, 1, false, 0);
      WorldGen.destroyObject = false;
    }

    public static bool Place1x2(int x, int y, int type, int style)
    {
      if ((int) Main.tile[x, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[x, y + 1].type] || (int) Main.tile[x, y - 1].active != 0)
        return false;
      int num1 = type == 20 ? WorldGen.genRand.Next(3) * 18 : 0;
      int num2 = style * 40;
      Main.tile[x, y - 1].active = (byte) 1;
      Main.tile[x, y - 1].frameY = (short) num2;
      Main.tile[x, y - 1].frameX = (short) num1;
      Main.tile[x, y - 1].type = (byte) type;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameY = (short) (num2 + 18);
      Main.tile[x, y].frameX = (short) num1;
      Main.tile[x, y].type = (byte) type;
      return true;
    }

    public static bool Place1x2Top(int x, int y, int type)
    {
      if ((int) Main.tile[x, y - 1].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x, y - 1].type] || (int) Main.tile[x, y + 1].active != 0)
        return false;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].frameX = (short) 0;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x, y + 1].active = (byte) 1;
      Main.tile[x, y + 1].frameY = (short) 18;
      Main.tile[x, y + 1].frameX = (short) 0;
      Main.tile[x, y + 1].type = (byte) type;
      return true;
    }

    public static void Check1x2Top(int x, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int j1 = j;
      if ((int) Main.tile[x, j1].frameY == 18)
        --j1;
      if ((int) Main.tile[x, j1].frameY == 0 && (int) Main.tile[x, j1 + 1].frameY == 18 && ((int) Main.tile[x, j1].type == 42 && (int) Main.tile[x, j1 + 1].type == 42) && ((int) Main.tile[x, j1 - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[x, j1 - 1].type]))
        return;
      WorldGen.destroyObject = true;
      if ((int) Main.tile[x, j1].type == 42)
        WorldGen.KillTile(x, j1);
      if ((int) Main.tile[x, j1 + 1].type == 42)
        WorldGen.KillTile(x, j1 + 1);
      if (!WorldGen.gen)
        Item.NewItem(x * 16, j1 * 16, 32, 32, 136, 1, false, 0);
      WorldGen.destroyObject = false;
    }

    public static void Check2x1(int i, int y, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int i1 = i;
      if ((int) Main.tile[i1, y].frameX == 18)
        --i1;
      if ((int) Main.tile[i1, y].frameX == 0 && (int) Main.tile[i1 + 1, y].frameX == 18 && ((int) Main.tile[i1, y].type == type && (int) Main.tile[i1 + 1, y].type == type))
      {
        if (type == 29 || type == 103)
        {
          if ((int) Main.tile[i1, y + 1].active != 0 && Main.tileTable[(int) Main.tile[i1, y + 1].type] && ((int) Main.tile[i1 + 1, y + 1].active != 0 && Main.tileTable[(int) Main.tile[i1 + 1, y + 1].type]))
            return;
        }
        else if ((int) Main.tile[i1, y + 1].active != 0 && Main.tileSolid[(int) Main.tile[i1, y + 1].type] && ((int) Main.tile[i1 + 1, y + 1].active != 0 && Main.tileSolid[(int) Main.tile[i1 + 1, y + 1].type]))
          return;
      }
      WorldGen.destroyObject = true;
      if ((int) Main.tile[i1, y].type == type)
        WorldGen.KillTile(i1, y);
      if ((int) Main.tile[i1 + 1, y].type == type)
        WorldGen.KillTile(i1 + 1, y);
      if (!WorldGen.gen)
      {
        if (type == 16)
          Item.NewItem(i1 * 16, y * 16, 32, 32, 35, 1, false, 0);
        else if (type == 18)
          Item.NewItem(i1 * 16, y * 16, 32, 32, 36, 1, false, 0);
        else if (type == 29)
        {
          Item.NewItem(i1 * 16, y * 16, 32, 32, 87, 1, false, 0);
          Main.PlaySound(13, i * 16, y * 16, 1);
        }
        else if (type == 103)
        {
          Item.NewItem(i1 * 16, y * 16, 32, 32, 356, 1, false, 0);
          Main.PlaySound(13, i * 16, y * 16, 1);
        }
        else if (type == 134)
          Item.NewItem(i1 * 16, y * 16, 32, 32, 525, 1, false, 0);
      }
      WorldGen.destroyObject = false;
      WorldGen.SquareTileFrame(i1, y, -1);
      WorldGen.SquareTileFrame(i1 + 1, y, -1);
    }

    public static bool Place2x1(int x, int y, int type)
    {
      if ((type == 29 || type == 103 || ((int) Main.tile[x, y + 1].active == 0 || (int) Main.tile[x + 1, y + 1].active == 0) || (!Main.tileSolid[(int) Main.tile[x, y + 1].type] || !Main.tileSolid[(int) Main.tile[x + 1, y + 1].type] || ((int) Main.tile[x, y].active != 0 || (int) Main.tile[x + 1, y].active != 0))) && (type != 29 && type != 103 || ((int) Main.tile[x, y + 1].active == 0 || (int) Main.tile[x + 1, y + 1].active == 0) || (!Main.tileTable[(int) Main.tile[x, y + 1].type] || !Main.tileTable[(int) Main.tile[x + 1, y + 1].type] || ((int) Main.tile[x, y].active != 0 || (int) Main.tile[x + 1, y].active != 0))))
        return false;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameY = (short) 0;
      Main.tile[x, y].frameX = (short) 0;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x + 1, y].active = (byte) 1;
      Main.tile[x + 1, y].frameY = (short) 0;
      Main.tile[x + 1, y].frameX = (short) 18;
      Main.tile[x + 1, y].type = (byte) type;
      return true;
    }

    private static void Destroy4x2(int i, int j, int x2, int y2, int type)
    {
      WorldGen.destroyObject = true;
      for (int i1 = x2; i1 < x2 + 4; ++i1)
      {
        for (int j1 = y2; j1 < y2 + 3; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && (int) Main.tile[i1, j1].active != 0)
            WorldGen.KillTile(i1, j1);
        }
      }
      if (!WorldGen.gen)
      {
        if (type == 79)
          Item.NewItem(i * 16, j * 16, 32, 32, 224, 1, false, 0);
        else if (type == 90)
          Item.NewItem(i * 16, j * 16, 32, 32, 336, 1, false, 0);
      }
      WorldGen.destroyObject = false;
      bool flag = WorldGen.tileFrameRecursion;
      WorldGen.tileFrameRecursion = false;
      for (int i1 = x2 - 1; i1 < x2 + 4; ++i1)
      {
        for (int j1 = y2 - 1; j1 < y2 + 4; ++j1)
          WorldGen.TileFrame(i1, j1, 0);
      }
      WorldGen.tileFrameRecursion = flag;
    }

    public static void Check4x2(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = i;
      int num2 = j;
      int x2 = num1 - (int) Main.tile[i, j].frameX / 18;
      if ((type == 79 || type == 90) && (int) Main.tile[i, j].frameX >= 72)
        x2 += 4;
      int y2 = num2 - (int) Main.tile[i, j].frameY / 18;
      for (int index1 = x2; index1 < x2 + 4; ++index1)
      {
        for (int index2 = y2; index2 < y2 + 2; ++index2)
        {
          int num3 = (index1 - x2) * 18;
          if ((type == 79 || type == 90) && (int) Main.tile[i, j].frameX >= 72)
            num3 = (index1 - x2 + 4) * 18;
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != type || ((int) Main.tile[index1, index2].frameX != num3 || (int) Main.tile[index1, index2].frameY != (index2 - y2) * 18))
          {
            WorldGen.Destroy4x2(i, j, x2, y2, type);
            return;
          }
        }
        if ((int) Main.tile[index1, y2 + 2].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y2 + 2].type])
        {
          WorldGen.Destroy4x2(i, j, x2, y2, type);
          break;
        }
      }
    }

    private static void Destroy2x2(int i, int j, int x2, int y2, int type)
    {
      WorldGen.destroyObject = true;
      for (int i1 = x2; i1 < x2 + 2; ++i1)
      {
        for (int j1 = y2; j1 < y2 + 2; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && (int) Main.tile[i1, j1].active != 0)
            WorldGen.KillTile(i1, j1);
        }
      }
      if (!WorldGen.gen)
      {
        if (type == 85)
          Item.NewItem(i * 16, j * 16, 32, 32, 321, 1, false, 0);
        else if (type == 94)
          Item.NewItem(i * 16, j * 16, 32, 32, 352, 1, false, 0);
        else if (type == 95)
          Item.NewItem(i * 16, j * 16, 32, 32, 344, 1, false, 0);
        else if (type == 96)
          Item.NewItem(i * 16, j * 16, 32, 32, 345, 1, false, 0);
        else if (type == 97)
          Item.NewItem(i * 16, j * 16, 32, 32, 346, 1, false, 0);
        else if (type == 98)
          Item.NewItem(i * 16, j * 16, 32, 32, 347, 1, false, 0);
        else if (type == 99)
          Item.NewItem(i * 16, j * 16, 32, 32, 348, 1, false, 0);
        else if (type == 100)
          Item.NewItem(i * 16, j * 16, 32, 32, 349, 1, false, 0);
        else if (type == 125)
          Item.NewItem(i * 16, j * 16, 32, 32, 487, 1, false, 0);
        else if (type == 126)
          Item.NewItem(i * 16, j * 16, 32, 32, 488, 1, false, 0);
        else if (type == 132)
          Item.NewItem(i * 16, j * 16, 32, 32, 513, 1, false, 0);
        else if (type == 142)
          Item.NewItem(i * 16, j * 16, 32, 32, 581, 1, false, 0);
        else if (type == 143)
          Item.NewItem(i * 16, j * 16, 32, 32, 582, 1, false, 0);
        else if (type == 138 && Main.netMode != 1)
          Projectile.NewProjectile((float) (x2 * 16) + 15.5f, (float) (y2 * 16 + 16), 0.0f, 0.0f, 99, 70, 10f, 8, true);
      }
      WorldGen.destroyObject = false;
      bool flag = WorldGen.tileFrameRecursion;
      WorldGen.tileFrameRecursion = false;
      for (int i1 = x2 - 1; i1 < x2 + 3; ++i1)
      {
        for (int j1 = y2 - 1; j1 < y2 + 3; ++j1)
          WorldGen.TileFrame(i1, j1, 0);
      }
      WorldGen.tileFrameRecursion = flag;
    }

    public static void Check2x2(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = 0;
      int num2 = -((int) Main.tile[i, j].frameX / 18);
      int num3 = -((int) Main.tile[i, j].frameY / 18);
      if (num2 < -1)
      {
        num2 += 2;
        num1 = 36;
      }
      int num4 = num2 + i;
      int y2 = num3 + j;
      for (int index1 = num4; index1 < num4 + 2; ++index1)
      {
        for (int index2 = y2; index2 < y2 + 2; ++index2)
        {
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != type || ((int) Main.tile[index1, index2].frameX != (index1 - num4) * 18 + num1 || (int) Main.tile[index1, index2].frameY != (index2 - y2) * 18))
          {
            WorldGen.Destroy2x2(i, j, num4, y2, type);
            return;
          }
        }
        if (type == 95 || type == 126)
        {
          if ((int) Main.tile[index1, y2 - 1].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[index1, y2 - 1].type])
          {
            WorldGen.Destroy2x2(i, j, num4, y2, type);
            return;
          }
        }
        else if (type != 138 && ((int) Main.tile[index1, y2 + 2].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y2 + 2].type] && !Main.tileTable[(int) Main.tile[index1, y2 + 2].type]))
        {
          WorldGen.Destroy2x2(i, j, num4, y2, type);
          return;
        }
      }
      if (type != 138 || WorldGen.SolidTileUnsafe(num4, y2 + 2) || WorldGen.SolidTileUnsafe(num4 + 1, y2 + 2))
        return;
      WorldGen.Destroy2x2(i, j, num4, y2, type);
    }

    public static void OreRunner(int i, int j, double strength, int steps, int type)
    {
      Vector2 vector2_1 = new Vector2();
      Vector2 vector2_2 = new Vector2();
      double num1 = strength;
      float num2 = (float) steps;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      while (num1 > 0.0 && (double) num2 > 0.0)
      {
        if ((double) vector2_1.Y < 0.0 && (double) num2 > 0.0 && type == 59)
          num2 = 0.0f;
        num1 = strength * ((double) num2 / (double) steps);
        --num2;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesX)
          num4 = (int) Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > (int) Main.maxTilesY)
          num6 = (int) Main.maxTilesY;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          for (int index2 = num5; index2 < num6; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < strength * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239) && (int) Main.tile[index1, index2].active != 0 && ((int) Main.tile[index1, index2].type == 0 || (int) Main.tile[index1, index2].type == 1 || ((int) Main.tile[index1, index2].type == 23 || (int) Main.tile[index1, index2].type == 25) || ((int) Main.tile[index1, index2].type == 40 || (int) Main.tile[index1, index2].type == 53 || ((int) Main.tile[index1, index2].type == 57 || (int) Main.tile[index1, index2].type == 59)) || ((int) Main.tile[index1, index2].type == 60 || (int) Main.tile[index1, index2].type == 70 || ((int) Main.tile[index1, index2].type == 109 || (int) Main.tile[index1, index2].type == 112) || ((int) Main.tile[index1, index2].type == 116 || (int) Main.tile[index1, index2].type == 117))))
            {
              Main.tile[index1, index2].type = (byte) type;
              WorldGen.SquareTileFrame(index1, index2, -1);
              if (Main.netMode == 2)
                NetMessage.SendTile(index1, index2);
            }
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        else if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
      }
    }

    public static void SmashAltar(int i, int j)
    {
      if (!Main.hardMode || Main.netMode == 1)
        return;
      int num1 = WorldGen.altarCount % 3;
      NetMessage.SendText(12 + num1, 50, (int) byte.MaxValue, 130, -1);
      int num2 = WorldGen.altarCount / 3 + 1;
      float num3 = (float) Main.maxTilesX * 0.0002380952f;
      int num4 = 1 - num1;
      float num5 = (num3 * 310f - (float) (85 * num1)) * 0.85f / (float) num2;
      int type;
      if (num1 == 0)
      {
        type = 107;
        num5 *= 1.05f;
      }
      else
        type = num1 != 1 ? 111 : 108;
      for (int index = 0; (double) index < (double) num5; ++index)
      {
        int i1 = WorldGen.genRand.Next(100, (int) Main.maxTilesX - 100);
        int lowerBound = Main.worldSurface;
        if (type == 108)
          lowerBound = Main.rockLayer;
        else if (type == 111)
          lowerBound = (Main.rockLayer + Main.rockLayer + (int) Main.maxTilesY) / 3;
        int j1 = WorldGen.genRand.Next(lowerBound, (int) Main.maxTilesY - 150);
        WorldGen.OreRunner(i1, j1, (double) WorldGen.genRand.Next(5, 9 + num4), WorldGen.genRand.Next(5, 9 + num4), type);
      }
      int num6 = WorldGen.genRand.Next(3);
      while (num6 != 2)
      {
        int tileX = WorldGen.genRand.Next(100, (int) Main.maxTilesX - 100);
        int tileY = WorldGen.genRand.Next(Main.rockLayer + 50, (int) Main.maxTilesY - 300);
        if ((int) Main.tile[tileX, tileY].active != 0 && (int) Main.tile[tileX, tileY].type == 1)
        {
          if (num6 == 0)
            Main.tile[tileX, tileY].type = (byte) 25;
          else
            Main.tile[tileX, tileY].type = (byte) 117;
          if (Main.netMode == 2)
          {
            NetMessage.SendTile(tileX, tileY);
            break;
          }
          else
            break;
        }
      }
      if (Main.netMode != 1)
      {
        int num7 = Main.rand.Next(2) + 1;
        Rectangle rect = new Rectangle();
        rect.X = i << 4;
        rect.Y = j << 4;
        rect.Width = rect.Height = 16;
        for (int index = 0; index < num7; ++index)
          NPC.SpawnOnPlayer(Player.FindClosest(ref rect), 82);
      }
      ++WorldGen.altarCount;
    }

    public static void Check3x2(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = i;
      int num2 = j;
      int i1 = num1 - (int) Main.tile[i, j].frameX / 18;
      int j1 = num2 - (int) Main.tile[i, j].frameY / 18;
      for (int index1 = i1; index1 < i1 + 3; ++index1)
      {
        if ((int) Main.tile[index1, j1 + 2].active != 0 && Main.tileSolid[(int) Main.tile[index1, j1 + 2].type])
        {
          for (int index2 = j1; index2 < j1 + 2; ++index2)
          {
            if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != type || ((int) Main.tile[index1, index2].frameX != (index1 - i1) * 18 || (int) Main.tile[index1, index2].frameY != (index2 - j1) * 18))
              goto label_10;
          }
          continue;
        }
label_10:
        WorldGen.destroyObject = true;
        for (int i2 = i1; i2 < i1 + 3; ++i2)
        {
          for (int j2 = j1; j2 < j1 + 3; ++j2)
          {
            if ((int) Main.tile[i2, j2].type == type && (int) Main.tile[i2, j2].active != 0)
              WorldGen.KillTile(i2, j2);
          }
        }
        if (!WorldGen.gen)
        {
          if (type == 14)
            Item.NewItem(i * 16, j * 16, 32, 32, 32, 1, false, 0);
          else if (type == 114)
            Item.NewItem(i * 16, j * 16, 32, 32, 398, 1, false, 0);
          else if (type == 26)
            WorldGen.SmashAltar(i, j);
          else if (type == 17)
            Item.NewItem(i * 16, j * 16, 32, 32, 33, 1, false, 0);
          else if (type == 77)
            Item.NewItem(i * 16, j * 16, 32, 32, 221, 1, false, 0);
          else if (type == 86)
            Item.NewItem(i * 16, j * 16, 32, 32, 332, 1, false, 0);
          else if (type == 87)
            Item.NewItem(i * 16, j * 16, 32, 32, 333, 1, false, 0);
          else if (type == 88)
            Item.NewItem(i * 16, j * 16, 32, 32, 334, 1, false, 0);
          else if (type == 89)
            Item.NewItem(i * 16, j * 16, 32, 32, 335, 1, false, 0);
          else if (type == 133)
            Item.NewItem(i * 16, j * 16, 32, 32, 524, 1, false, 0);
        }
        WorldGen.destroyObject = false;
        bool flag = WorldGen.tileFrameRecursion;
        WorldGen.tileFrameRecursion = false;
        WorldGen.TileFrame(i1 - 1, j1 - 1, 0);
        WorldGen.TileFrame(i1, j1 - 1, 0);
        WorldGen.TileFrame(i1 + 1, j1 - 1, 0);
        WorldGen.TileFrame(i1 + 2, j1 - 1, 0);
        WorldGen.TileFrame(i1 - 1, j1, 0);
        WorldGen.TileFrame(i1, j1, 0);
        WorldGen.TileFrame(i1 + 1, j1, 0);
        WorldGen.TileFrame(i1 + 2, j1, 0);
        WorldGen.TileFrame(i1 - 1, j1 + 1, 0);
        WorldGen.TileFrame(i1, j1 + 1, 0);
        WorldGen.TileFrame(i1 + 1, j1 + 1, 0);
        WorldGen.TileFrame(i1 + 2, j1 + 1, 0);
        WorldGen.TileFrame(i1 - 1, j1 + 2, 0);
        WorldGen.TileFrame(i1, j1 + 2, 0);
        WorldGen.TileFrame(i1 + 1, j1 + 2, 0);
        WorldGen.TileFrame(i1 + 2, j1 + 2, 0);
        WorldGen.TileFrame(i1 - 1, j1 + 3, 0);
        WorldGen.TileFrame(i1, j1 + 3, 0);
        WorldGen.TileFrame(i1 + 1, j1 + 3, 0);
        WorldGen.TileFrame(i1 + 2, j1 + 3, 0);
        WorldGen.tileFrameRecursion = flag;
        break;
      }
    }

    public static void Check3x4(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = i;
      int num2 = j;
      int num3 = num1 - (int) Main.tile[i, j].frameX / 18;
      int num4 = num2 - (int) Main.tile[i, j].frameY / 18;
      for (int index1 = num3; index1 < num3 + 3; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 4; ++index2)
        {
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != type || ((int) Main.tile[index1, index2].frameX != (index1 - num3) * 18 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18))
            goto label_10;
        }
        if ((int) Main.tile[index1, num4 + 4].active != 0 && Main.tileSolid[(int) Main.tile[index1, num4 + 4].type])
          continue;
label_10:
        WorldGen.destroyObject = true;
        for (int i1 = num3; i1 < num3 + 3; ++i1)
        {
          for (int j1 = num4; j1 < num4 + 4; ++j1)
          {
            if ((int) Main.tile[i1, j1].type == type && (int) Main.tile[i1, j1].active != 0)
              WorldGen.KillTile(i1, j1);
          }
        }
        if (!WorldGen.gen)
        {
          if (type == 101)
            Item.NewItem(i * 16, j * 16, 32, 32, 354, 1, false, 0);
          else if (type == 102)
            Item.NewItem(i * 16, j * 16, 32, 32, 355, 1, false, 0);
        }
        WorldGen.destroyObject = false;
        bool flag = WorldGen.tileFrameRecursion;
        WorldGen.tileFrameRecursion = false;
        for (int i1 = num3 - 1; i1 < num3 + 4; ++i1)
        {
          for (int j1 = num4 - 1; j1 < num4 + 4; ++j1)
            WorldGen.TileFrame(i1, j1, 0);
        }
        WorldGen.tileFrameRecursion = flag;
        break;
      }
    }

    public static bool Place4x2(int x, int y, int type, int direction = -1)
    {
      if (x < 5 || x > (int) Main.maxTilesX - 5 || (y < 5 || y > (int) Main.maxTilesY - 5))
        return false;
      for (int index1 = x - 1; index1 < x + 3; ++index1)
      {
        if ((int) Main.tile[index1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          return false;
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0)
            return false;
        }
      }
      int num = direction == 1 ? 72 : 0;
      Main.tile[x - 1, y - 1].active = (byte) 1;
      Main.tile[x - 1, y - 1].frameY = (short) 0;
      Main.tile[x - 1, y - 1].frameX = (short) num;
      Main.tile[x - 1, y - 1].type = (byte) type;
      Main.tile[x, y - 1].active = (byte) 1;
      Main.tile[x, y - 1].frameY = (short) 0;
      Main.tile[x, y - 1].frameX = (short) (18 + num);
      Main.tile[x, y - 1].type = (byte) type;
      Main.tile[x + 1, y - 1].active = (byte) 1;
      Main.tile[x + 1, y - 1].frameY = (short) 0;
      Main.tile[x + 1, y - 1].frameX = (short) (36 + num);
      Main.tile[x + 1, y - 1].type = (byte) type;
      Main.tile[x + 2, y - 1].active = (byte) 1;
      Main.tile[x + 2, y - 1].frameY = (short) 0;
      Main.tile[x + 2, y - 1].frameX = (short) (54 + num);
      Main.tile[x + 2, y - 1].type = (byte) type;
      Main.tile[x - 1, y].active = (byte) 1;
      Main.tile[x - 1, y].frameY = (short) 18;
      Main.tile[x - 1, y].frameX = (short) num;
      Main.tile[x - 1, y].type = (byte) type;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameY = (short) 18;
      Main.tile[x, y].frameX = (short) (18 + num);
      Main.tile[x, y].type = (byte) type;
      Main.tile[x + 1, y].active = (byte) 1;
      Main.tile[x + 1, y].frameY = (short) 18;
      Main.tile[x + 1, y].frameX = (short) (36 + num);
      Main.tile[x + 1, y].type = (byte) type;
      Main.tile[x + 2, y].active = (byte) 1;
      Main.tile[x + 2, y].frameY = (short) 18;
      Main.tile[x + 2, y].frameX = (short) (54 + num);
      Main.tile[x + 2, y].type = (byte) type;
      return true;
    }

    public static void SwitchMB(int i, int j)
    {
      int num1 = (int) Main.tile[i, j].frameY / 18 & 1;
      int num2 = (int) Main.tile[i, j].frameX / 18;
      if (num2 >= 2)
        num2 -= 2;
      int tileX = i - num2;
      int tileY = j - num1;
      for (int index1 = tileX; index1 < tileX + 2; ++index1)
      {
        for (int index2 = tileY; index2 < tileY + 2; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type == 139)
          {
            if ((int) Main.tile[index1, index2].frameX < 36)
              Main.tile[index1, index2].frameX += (short) 36;
            else
              Main.tile[index1, index2].frameX -= (short) 36;
            WorldGen.noWire[WorldGen.numNoWire].X = (short) index1;
            WorldGen.noWire[WorldGen.numNoWire].Y = (short) index2;
            ++WorldGen.numNoWire;
          }
        }
      }
      NetMessage.SendTileSquare(tileX, tileY, 3);
    }

    public static void CheckMusicBox(int i, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = (int) Main.tile[i, j].frameY / 18;
      int num2 = num1 >> 1;
      int num3 = num1 & 1;
      int num4 = (int) Main.tile[i, j].frameX / 18;
      int num5 = 0;
      if (num4 >= 2)
      {
        num4 -= 2;
        ++num5;
      }
      int num6 = i - num4;
      int num7 = j - num3;
      for (int index1 = num6; index1 < num6 + 2; ++index1)
      {
        for (int index2 = num7; index2 < num7 + 2; ++index2)
        {
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != 139 || ((int) Main.tile[index1, index2].frameX != (index1 - num6) * 18 + num5 * 36 || (int) Main.tile[index1, index2].frameY != (index2 - num7) * 18 + num2 * 36))
            goto label_12;
        }
        if (Main.tileSolid[(int) Main.tile[index1, num7 + 2].type])
          continue;
label_12:
        WorldGen.destroyObject = true;
        for (int i1 = num6; i1 < num6 + 2; ++i1)
        {
          for (int j1 = num7; j1 < num7 + 3; ++j1)
          {
            if ((int) Main.tile[i1, j1].type == 139 && (int) Main.tile[i1, j1].active != 0)
              WorldGen.KillTile(i1, j1);
          }
        }
        Item.NewItem(i * 16, j * 16, 32, 32, 562 + num2, 1, false, 0);
        bool flag = WorldGen.tileFrameRecursion;
        WorldGen.tileFrameRecursion = false;
        for (int i1 = num6 - 1; i1 < num6 + 3; ++i1)
        {
          for (int j1 = num7 - 1; j1 < num7 + 3; ++j1)
            WorldGen.TileFrame(i1, j1, 0);
        }
        WorldGen.tileFrameRecursion = flag;
        WorldGen.destroyObject = false;
        break;
      }
    }

    public static bool PlaceMB(int X, int y, int type, int style)
    {
      int index1 = X + 1;
      if (index1 < 5 || index1 > (int) Main.maxTilesX - 5 || (y < 5 || y > (int) Main.maxTilesY - 5))
        return false;
      for (int index2 = index1 - 1; index2 < index1 + 1; ++index2)
      {
        for (int index3 = y - 1; index3 < y + 1; ++index3)
        {
          if ((int) Main.tile[index2, index3].active != 0)
            return false;
        }
        if ((int) Main.tile[index2, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index2, y + 1].type] && !Main.tileTable[(int) Main.tile[index2, y + 1].type])
          return false;
      }
      Main.tile[index1 - 1, y - 1].active = (byte) 1;
      Main.tile[index1 - 1, y - 1].frameY = (short) (style * 36);
      Main.tile[index1 - 1, y - 1].frameX = (short) 0;
      Main.tile[index1 - 1, y - 1].type = (byte) type;
      Main.tile[index1, y - 1].active = (byte) 1;
      Main.tile[index1, y - 1].frameY = (short) (style * 36);
      Main.tile[index1, y - 1].frameX = (short) 18;
      Main.tile[index1, y - 1].type = (byte) type;
      Main.tile[index1 - 1, y].active = (byte) 1;
      Main.tile[index1 - 1, y].frameY = (short) (style * 36 + 18);
      Main.tile[index1 - 1, y].frameX = (short) 0;
      Main.tile[index1 - 1, y].type = (byte) type;
      Main.tile[index1, y].active = (byte) 1;
      Main.tile[index1, y].frameY = (short) (style * 36 + 18);
      Main.tile[index1, y].frameX = (short) 18;
      Main.tile[index1, y].type = (byte) type;
      return true;
    }

    public static bool Place2x2(int x, int y, int type)
    {
      if (type == 95 || type == 126)
        ++y;
      if (x < 5 || x > (int) Main.maxTilesX - 5 || (y < 5 || y > (int) Main.maxTilesY - 5))
        return false;
      for (int index1 = x - 1; index1 < x + 1; ++index1)
      {
        if (type == 95 || type == 126)
        {
          if ((int) Main.tile[index1, y - 2].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[index1, y - 2].type])
            return false;
        }
        else if ((int) Main.tile[index1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y + 1].type] && !Main.tileTable[(int) Main.tile[index1, y + 1].type])
          return false;
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0 || type == 98 && (int) Main.tile[index1, index2].liquid > 0)
            return false;
        }
      }
      Main.tile[x - 1, y - 1].active = (byte) 1;
      Main.tile[x - 1, y - 1].frameY = (short) 0;
      Main.tile[x - 1, y - 1].frameX = (short) 0;
      Main.tile[x - 1, y - 1].type = (byte) type;
      Main.tile[x, y - 1].active = (byte) 1;
      Main.tile[x, y - 1].frameY = (short) 0;
      Main.tile[x, y - 1].frameX = (short) 18;
      Main.tile[x, y - 1].type = (byte) type;
      Main.tile[x - 1, y].active = (byte) 1;
      Main.tile[x - 1, y].frameY = (short) 18;
      Main.tile[x - 1, y].frameX = (short) 0;
      Main.tile[x - 1, y].type = (byte) type;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameY = (short) 18;
      Main.tile[x, y].frameX = (short) 18;
      Main.tile[x, y].type = (byte) type;
      return true;
    }

    public static bool Place3x4(int x, int y, int type)
    {
      if (x < 5 || x > (int) Main.maxTilesX - 5 || (y < 5 || y > (int) Main.maxTilesY - 5))
        return false;
      for (int index1 = x - 1; index1 < x + 2; ++index1)
      {
        if ((int) Main.tile[index1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          return false;
        for (int index2 = y - 3; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0)
            return false;
        }
      }
      for (int index = -3; index <= 0; ++index)
      {
        short num = (short) ((3 + index) * 18);
        Main.tile[x - 1, y + index].active = (byte) 1;
        Main.tile[x - 1, y + index].frameY = num;
        Main.tile[x - 1, y + index].frameX = (short) 0;
        Main.tile[x - 1, y + index].type = (byte) type;
        Main.tile[x, y + index].active = (byte) 1;
        Main.tile[x, y + index].frameY = num;
        Main.tile[x, y + index].frameX = (short) 18;
        Main.tile[x, y + index].type = (byte) type;
        Main.tile[x + 1, y + index].active = (byte) 1;
        Main.tile[x + 1, y + index].frameY = num;
        Main.tile[x + 1, y + index].frameX = (short) 36;
        Main.tile[x + 1, y + index].type = (byte) type;
      }
      return true;
    }

    public static bool Place3x2(int x, int y, int type)
    {
      if (x < 5 || x > (int) Main.maxTilesX - 5 || (y < 5 || y > (int) Main.maxTilesY - 5))
        return false;
      for (int index1 = x - 1; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0)
            return false;
        }
        if ((int) Main.tile[index1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          return false;
      }
      Main.tile[x - 1, y - 1].active = (byte) 1;
      Main.tile[x - 1, y - 1].frameY = (short) 0;
      Main.tile[x - 1, y - 1].frameX = (short) 0;
      Main.tile[x - 1, y - 1].type = (byte) type;
      Main.tile[x, y - 1].active = (byte) 1;
      Main.tile[x, y - 1].frameY = (short) 0;
      Main.tile[x, y - 1].frameX = (short) 18;
      Main.tile[x, y - 1].type = (byte) type;
      Main.tile[x + 1, y - 1].active = (byte) 1;
      Main.tile[x + 1, y - 1].frameY = (short) 0;
      Main.tile[x + 1, y - 1].frameX = (short) 36;
      Main.tile[x + 1, y - 1].type = (byte) type;
      Main.tile[x - 1, y].active = (byte) 1;
      Main.tile[x - 1, y].frameY = (short) 18;
      Main.tile[x - 1, y].frameX = (short) 0;
      Main.tile[x - 1, y].type = (byte) type;
      Main.tile[x, y].active = (byte) 1;
      Main.tile[x, y].frameY = (short) 18;
      Main.tile[x, y].frameX = (short) 18;
      Main.tile[x, y].type = (byte) type;
      Main.tile[x + 1, y].active = (byte) 1;
      Main.tile[x + 1, y].frameY = (short) 18;
      Main.tile[x + 1, y].frameX = (short) 36;
      Main.tile[x + 1, y].type = (byte) type;
      return true;
    }

    public static void Check3x3(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = j;
      int num2 = (int) Main.tile[i, j].frameX / 18;
      int num3 = i - num2;
      if (num2 >= 3)
        num2 -= 3;
      int num4 = i - num2;
      int num5 = num1 + (int) Main.tile[i, j].frameY / 18 * -1;
      for (int index1 = num4; index1 < num4 + 3; ++index1)
      {
        for (int index2 = num5; index2 < num5 + 3; ++index2)
        {
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != type || ((int) Main.tile[index1, index2].frameX != (index1 - num3) * 18 || (int) Main.tile[index1, index2].frameY != (index2 - num5) * 18))
            goto label_18;
        }
      }
      if (type == 106)
      {
        for (int index = num4; index < num4 + 3; ++index)
        {
          if ((int) Main.tile[index, num5 + 3].active == 0 || !Main.tileSolid[(int) Main.tile[index, num5 + 3].type])
            goto label_18;
        }
        return;
      }
      else if ((int) Main.tile[num4 + 1, num5 - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[num4 + 1, num5 - 1].type])
        return;
label_18:
      WorldGen.destroyObject = true;
      for (int i1 = num4; i1 < num4 + 3; ++i1)
      {
        for (int j1 = num5; j1 < num5 + 3; ++j1)
        {
          if ((int) Main.tile[i1, j1].type == type && (int) Main.tile[i1, j1].active != 0)
            WorldGen.KillTile(i1, j1);
        }
      }
      if (type == 34)
        Item.NewItem(i * 16, j * 16, 32, 32, 106, 1, false, 0);
      else if (type == 35)
        Item.NewItem(i * 16, j * 16, 32, 32, 107, 1, false, 0);
      else if (type == 36)
        Item.NewItem(i * 16, j * 16, 32, 32, 108, 1, false, 0);
      else if (type == 106)
        Item.NewItem(i * 16, j * 16, 32, 32, 363, 1, false, 0);
      WorldGen.destroyObject = false;
      bool flag = WorldGen.tileFrameRecursion;
      WorldGen.tileFrameRecursion = false;
      for (int i1 = num4 - 1; i1 < num4 + 4; ++i1)
      {
        for (int j1 = num5 - 1; j1 < num5 + 4; ++j1)
          WorldGen.TileFrame(i1, j1, 0);
      }
      WorldGen.tileFrameRecursion = flag;
    }

    public static bool Place3x3(int x, int y, int type)
    {
      int num = 0;
      if (type == 106)
      {
        num = -2;
        for (int index1 = x - 1; index1 < x + 2; ++index1)
        {
          for (int index2 = y - 2; index2 < y + 1; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0)
              return false;
          }
        }
        for (int index = x - 1; index < x + 2; ++index)
        {
          if ((int) Main.tile[index, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index, y + 1].type])
            return false;
        }
      }
      else
      {
        for (int index1 = x - 1; index1 < x + 2; ++index1)
        {
          for (int index2 = y; index2 < y + 3; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0)
              return false;
          }
        }
        if ((int) Main.tile[x, y - 1].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[x, y - 1].type])
          return false;
      }
      Main.tile[x - 1, y + num].active = (byte) 1;
      Main.tile[x - 1, y + num].frameY = (short) 0;
      Main.tile[x - 1, y + num].frameX = (short) 0;
      Main.tile[x - 1, y + num].type = (byte) type;
      Main.tile[x, y + num].active = (byte) 1;
      Main.tile[x, y + num].frameY = (short) 0;
      Main.tile[x, y + num].frameX = (short) 18;
      Main.tile[x, y + num].type = (byte) type;
      Main.tile[x + 1, y + num].active = (byte) 1;
      Main.tile[x + 1, y + num].frameY = (short) 0;
      Main.tile[x + 1, y + num].frameX = (short) 36;
      Main.tile[x + 1, y + num].type = (byte) type;
      Main.tile[x - 1, y + 1 + num].active = (byte) 1;
      Main.tile[x - 1, y + 1 + num].frameY = (short) 18;
      Main.tile[x - 1, y + 1 + num].frameX = (short) 0;
      Main.tile[x - 1, y + 1 + num].type = (byte) type;
      Main.tile[x, y + 1 + num].active = (byte) 1;
      Main.tile[x, y + 1 + num].frameY = (short) 18;
      Main.tile[x, y + 1 + num].frameX = (short) 18;
      Main.tile[x, y + 1 + num].type = (byte) type;
      Main.tile[x + 1, y + 1 + num].active = (byte) 1;
      Main.tile[x + 1, y + 1 + num].frameY = (short) 18;
      Main.tile[x + 1, y + 1 + num].frameX = (short) 36;
      Main.tile[x + 1, y + 1 + num].type = (byte) type;
      Main.tile[x - 1, y + 2 + num].active = (byte) 1;
      Main.tile[x - 1, y + 2 + num].frameY = (short) 36;
      Main.tile[x - 1, y + 2 + num].frameX = (short) 0;
      Main.tile[x - 1, y + 2 + num].type = (byte) type;
      Main.tile[x, y + 2 + num].active = (byte) 1;
      Main.tile[x, y + 2 + num].frameY = (short) 36;
      Main.tile[x, y + 2 + num].frameX = (short) 18;
      Main.tile[x, y + 2 + num].type = (byte) type;
      Main.tile[x + 1, y + 2 + num].active = (byte) 1;
      Main.tile[x + 1, y + 2 + num].frameY = (short) 36;
      Main.tile[x + 1, y + 2 + num].frameX = (short) 36;
      Main.tile[x + 1, y + 2 + num].type = (byte) type;
      return true;
    }

    public static bool PlaceSunflower(int x, int y)
    {
      if (y > Main.worldSurface - 1)
        return false;
      for (int index1 = x; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 3; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0 || (int) Main.tile[index1, index2].wall > 0)
            return false;
        }
        if ((int) Main.tile[index1, y + 1].active == 0 || (int) Main.tile[index1, y + 1].type != 2 && (int) Main.tile[index1, y + 1].type != 109)
          return false;
      }
      for (int index1 = 0; index1 < 2; ++index1)
      {
        for (int index2 = -3; index2 < 1; ++index2)
        {
          int num1 = index1 * 18 + WorldGen.genRand.Next(3) * 36;
          int num2 = (index2 + 3) * 18;
          Main.tile[x + index1, y + index2].active = (byte) 1;
          Main.tile[x + index1, y + index2].frameX = (short) num1;
          Main.tile[x + index1, y + index2].frameY = (short) num2;
          Main.tile[x + index1, y + index2].type = (byte) 27;
        }
      }
      return true;
    }

    public static void CheckSunflower(int i, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = 0;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18;
      int num4 = num2 - (int) Main.tile[i, j].frameY / 18;
      int num5 = -(num3 & 1) + i;
      for (int index1 = num5; index1 < num5 + 2; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 4; ++index2)
        {
          int num6 = (int) Main.tile[index1, index2].frameX / 18 & 1;
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != 27 || (num6 != index1 - num5 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18))
            goto label_10;
        }
        if ((int) Main.tile[index1, num4 + 4].active != 0 && ((int) Main.tile[index1, num4 + 4].type == 2 || (int) Main.tile[index1, num4 + 4].type == 109))
          continue;
label_10:
        WorldGen.destroyObject = true;
        for (int i1 = num5; i1 < num5 + 2; ++i1)
        {
          for (int j1 = num4; j1 < num4 + 4; ++j1)
          {
            if ((int) Main.tile[i1, j1].type == 27 && (int) Main.tile[i1, j1].active != 0)
              WorldGen.KillTile(i1, j1);
          }
        }
        Item.NewItem(i * 16, j * 16, 32, 32, 63, 1, false, 0);
        WorldGen.destroyObject = false;
        break;
      }
    }

    public static bool PlacePot(int x, int y)
    {
      for (int index1 = x; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0)
            return false;
        }
        if ((int) Main.tile[index1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          return false;
      }
      for (int index1 = 0; index1 < 2; ++index1)
      {
        for (int index2 = -1; index2 < 1; ++index2)
        {
          Main.tile[x + index1, y + index2].active = (byte) 1;
          Main.tile[x + index1, y + index2].frameX = (short) (index1 * 18 + WorldGen.genRand.Next(3) * 36);
          Main.tile[x + index1, y + index2].frameY = (short) ((index2 + 1) * 18);
          Main.tile[x + index1, y + index2].type = (byte) 28;
        }
      }
      return true;
    }

    public static bool CheckCactus(int i, int j)
    {
      int index1 = j;
      int index2 = i;
      while ((int) Main.tile[index2, index1].active != 0 && (int) Main.tile[index2, index1].type == 80)
      {
        ++index1;
        if ((int) Main.tile[index2, index1].active == 0 || (int) Main.tile[index2, index1].type != 80)
        {
          if ((int) Main.tile[index2 - 1, index1].active != 0 && (int) Main.tile[index2 - 1, index1].type == 80 && ((int) Main.tile[index2 - 1, index1 - 1].active != 0 && (int) Main.tile[index2 - 1, index1 - 1].type == 80) && index2 >= i)
            --index2;
          if ((int) Main.tile[index2 + 1, index1].active != 0 && (int) Main.tile[index2 + 1, index1].type == 80 && ((int) Main.tile[index2 + 1, index1 - 1].active != 0 && (int) Main.tile[index2 + 1, index1 - 1].type == 80) && index2 <= i)
            ++index2;
        }
      }
      if ((int) Main.tile[index2, index1].active == 0 || (int) Main.tile[index2, index1].type != 53 && (int) Main.tile[index2, index1].type != 112 && (int) Main.tile[index2, index1].type != 116)
      {
        WorldGen.KillTile(i, j);
        return true;
      }
      else
      {
        if (i != index2)
        {
          if (((int) Main.tile[i, j + 1].active == 0 || (int) Main.tile[i, j + 1].type != 80) && ((int) Main.tile[i - 1, j].active == 0 || (int) Main.tile[i - 1, j].type != 80) && ((int) Main.tile[i + 1, j].active == 0 || (int) Main.tile[i + 1, j].type != 80))
          {
            WorldGen.KillTile(i, j);
            return true;
          }
        }
        else if (i == index2 && ((int) Main.tile[i, j + 1].active == 0 || (int) Main.tile[i, j + 1].type != 80 && (int) Main.tile[i, j + 1].type != 53 && ((int) Main.tile[i, j + 1].type != 112 && (int) Main.tile[i, j + 1].type != 116)))
        {
          WorldGen.KillTile(i, j);
          return true;
        }
        return false;
      }
    }

    public static void PlantCactus(int i, int j)
    {
      WorldGen.GrowCactus(i, j);
      for (int index = 0; index < 150; ++index)
        WorldGen.GrowCactus(WorldGen.genRand.Next(i - 1, i + 2), WorldGen.genRand.Next(j - 10, j + 2));
    }

    public static void CheckOrb(int i, int j, int type)
    {
      if (WorldGen.destroyObject)
        return;
      int i1 = (int) Main.tile[i, j].frameX != 0 ? i - 1 : i;
      int j1 = (int) Main.tile[i, j].frameY != 0 ? j - 1 : j;
      if ((int) Main.tile[i1, j1].active != 0 && (int) Main.tile[i1, j1].type == type && ((int) Main.tile[i1 + 1, j1].active != 0 && (int) Main.tile[i1 + 1, j1].type == type) && ((int) Main.tile[i1, j1 + 1].active != 0 && (int) Main.tile[i1, j1 + 1].type == type && ((int) Main.tile[i1 + 1, j1 + 1].active != 0 && (int) Main.tile[i1 + 1, j1 + 1].type == type)))
        return;
      WorldGen.destroyObject = true;
      if ((int) Main.tile[i1, j1].type == type)
        WorldGen.KillTile(i1, j1);
      if ((int) Main.tile[i1 + 1, j1].type == type)
        WorldGen.KillTile(i1 + 1, j1);
      if ((int) Main.tile[i1, j1 + 1].type == type)
        WorldGen.KillTile(i1, j1 + 1);
      if ((int) Main.tile[i1 + 1, j1 + 1].type == type)
        WorldGen.KillTile(i1 + 1, j1 + 1);
      if (!WorldGen.gen)
      {
        Main.PlaySound(13, i * 16, j * 16, 1);
        if (Main.netMode != 1)
        {
          if (type == 12)
            Item.NewItem(i1 * 16, j1 * 16, 32, 32, 29, 1, false, 0);
          else if (type == 31)
          {
            if (WorldGen.genRand.Next(2) == 0)
              WorldGen.spawnMeteor = true;
            int num = Main.rand.Next(5);
            if (!WorldGen.shadowOrbSmashed)
              num = 0;
            if (num == 0)
            {
              Item.NewItem(i1 * 16, j1 * 16, 32, 32, 96, 1, false, -1);
              int Stack = WorldGen.genRand.Next(25, 51);
              Item.NewItem(i1 * 16, j1 * 16, 32, 32, 97, Stack, false, 0);
            }
            else if (num == 1)
              Item.NewItem(i1 * 16, j1 * 16, 32, 32, 64, 1, false, -1);
            else if (num == 2)
              Item.NewItem(i1 * 16, j1 * 16, 32, 32, 162, 1, false, -1);
            else if (num == 3)
              Item.NewItem(i1 * 16, j1 * 16, 32, 32, 115, 1, false, -1);
            else if (num == 4)
              Item.NewItem(i1 * 16, j1 * 16, 32, 32, 111, 1, false, -1);
            WorldGen.shadowOrbSmashed = true;
            ++WorldGen.shadowOrbCount;
            if (WorldGen.shadowOrbCount >= 3)
            {
              WorldGen.shadowOrbCount = 0;
              Rectangle rect = new Rectangle();
              rect.X = i1 << 4;
              rect.Y = j1 << 4;
              rect.Width = rect.Height = 0;
              NPC.SpawnOnPlayer(Player.FindClosest(ref rect), 13);
            }
            else
            {
              int textId = 10;
              if (WorldGen.shadowOrbCount == 2)
                textId = 11;
              NetMessage.SendText(textId, 50, (int) byte.MaxValue, 130, -1);
            }
          }
        }
      }
      WorldGen.destroyObject = false;
    }

    public static void CheckTree(int i, int j)
    {
      int index1 = -1;
      int index2 = -1;
      int index3 = -1;
      int index4 = -1;
      if ((int) Main.tile[i - 1, j].active != 0)
        index2 = (int) Main.tile[i - 1, j].type;
      if ((int) Main.tile[i + 1, j].active != 0)
        index3 = (int) Main.tile[i + 1, j].type;
      if ((int) Main.tile[i, j - 1].active != 0)
        index1 = (int) Main.tile[i, j - 1].type;
      if ((int) Main.tile[i, j + 1].active != 0)
        index4 = (int) Main.tile[i, j + 1].type;
      if (index2 >= 0 && Main.tileStone[index2])
        index2 = 1;
      if (index3 >= 0 && Main.tileStone[index3])
        index3 = 1;
      if (index1 >= 0 && Main.tileStone[index1])
        index1 = 1;
      if (index4 >= 0 && Main.tileStone[index4])
        index4 = 1;
      if (index4 == 23)
        index4 = 2;
      else if (index4 == 60)
        index4 = 2;
      else if (index4 == 109)
        index4 = 2;
      else if (index4 == 147)
        index4 = 2;
      int num1 = (int) Main.tile[i, j].frameNumber;
      int num2 = (int) Main.tile[i, j].type;
      int num3;
      int num4 = num3 = (int) Main.tile[i, j].frameX;
      int num5;
      int num6 = num5 = (int) Main.tile[i, j].frameY;
      if (num3 >= 22 && num3 <= 44 && (num5 >= 132 && num5 <= 176))
      {
        if (index4 != 2)
          WorldGen.KillTile(i, j);
        else if ((num3 != 22 || index2 != num2) && (num3 != 44 || index3 != num2))
          WorldGen.KillTile(i, j);
      }
      else if (num3 == 88 && num5 >= 0 && num5 <= 44 || num3 == 66 && num5 >= 66 && num5 <= 130 || (num3 == 110 && num5 >= 66 && num5 <= 110 || num3 == 132 && num5 >= 0 && num5 <= 176))
      {
        if (index2 == num2 && index3 == num2)
        {
          Main.tile[i, j].frameX = (short) 110;
          Main.tile[i, j].frameY = (short) (66 + 22 * num1);
        }
        else if (index2 == num2)
        {
          Main.tile[i, j].frameX = (short) 88;
          Main.tile[i, j].frameY = (short) (22 * num1);
        }
        else if (index3 == num2)
        {
          Main.tile[i, j].frameX = (short) 66;
          Main.tile[i, j].frameY = (short) (66 + 22 * num1);
        }
        else
        {
          Main.tile[i, j].frameX = (short) 0;
          Main.tile[i, j].frameY = (short) (22 * num1);
        }
      }
      int num7 = (int) Main.tile[i, j].frameX;
      int num8 = (int) Main.tile[i, j].frameY;
      if (num8 >= 132 && num8 <= 176)
      {
        if (num7 == 0 || num7 == 66 || num7 == 88)
        {
          if (index4 != 2)
            WorldGen.KillTile(i, j);
          if (index2 != num2 && index3 != num2)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) (22 * num1);
          }
          else if (index2 != num2)
          {
            Main.tile[i, j].frameX = (short) 0;
            Main.tile[i, j].frameY = (short) (132 + 22 * num1);
          }
          else if (index3 != num2)
          {
            Main.tile[i, j].frameX = (short) 66;
            Main.tile[i, j].frameY = (short) (132 + 22 * num1);
          }
          else
          {
            Main.tile[i, j].frameX = (short) 88;
            Main.tile[i, j].frameY = (short) (132 + 22 * num1);
          }
        }
      }
      else if (num7 == 66 && (num8 == 0 || num8 == 22 || num8 == 44) || num7 == 44 && (num8 == 198 || num8 == 220 || num8 == 242))
      {
        if (index3 != num2)
          WorldGen.KillTile(i, j);
      }
      else if (num7 == 88 && (num8 == 66 || num8 == 88 || num8 == 110) || num7 == 66 && (num8 == 198 || num8 == 220 || num8 == 242))
      {
        if (index2 != num2)
          WorldGen.KillTile(i, j);
      }
      else if (index4 == -1 || index4 == 23)
        WorldGen.KillTile(i, j);
      else if (index1 != num2 && num8 < 198 && (num7 != 22 && num7 != 44 || num8 < 132))
      {
        if (index2 == num2 || index3 == num2)
        {
          if (index4 == num2)
          {
            if (index2 == num2 && index3 == num2)
            {
              Main.tile[i, j].frameX = (short) 132;
              Main.tile[i, j].frameY = (short) (132 + 22 * num1);
            }
            else if (index2 == num2)
            {
              Main.tile[i, j].frameX = (short) 132;
              Main.tile[i, j].frameY = (short) (22 * num1);
            }
            else if (index3 == num2)
            {
              Main.tile[i, j].frameX = (short) 132;
              Main.tile[i, j].frameY = (short) (66 + 22 * num1);
            }
          }
          else if (index2 == num2 && index3 == num2)
          {
            Main.tile[i, j].frameX = (short) 154;
            Main.tile[i, j].frameY = (short) (132 + 22 * num1);
          }
          else if (index2 == num2)
          {
            Main.tile[i, j].frameX = (short) 154;
            Main.tile[i, j].frameY = (short) (22 * num1);
          }
          else if (index3 == num2)
          {
            Main.tile[i, j].frameX = (short) 154;
            Main.tile[i, j].frameY = (short) (66 + 22 * num1);
          }
        }
        else
        {
          Main.tile[i, j].frameX = (short) 110;
          Main.tile[i, j].frameY = (short) (22 * num1);
        }
      }
      if (num4 < 0 || num6 < 0 || ((int) Main.tile[i, j].frameX == num4 || (int) Main.tile[i, j].frameY == num6))
        return;
      WorldGen.TileFrame(i - 1, j, 0);
      WorldGen.TileFrame(i + 1, j, 0);
      WorldGen.TileFrame(i, j - 1, 0);
      WorldGen.TileFrame(i, j + 1, 0);
    }

    public static void CactusFrame(int i, int j)
    {
      try
      {
        int index1 = j;
        int index2 = i;
        if (WorldGen.CheckCactus(i, j))
          return;
        while ((int) Main.tile[index2, index1].active != 0 && (int) Main.tile[index2, index1].type == 80)
        {
          ++index1;
          if ((int) Main.tile[index2, index1].active == 0 || (int) Main.tile[index2, index1].type != 80)
          {
            if ((int) Main.tile[index2 - 1, index1].active != 0 && (int) Main.tile[index2 - 1, index1].type == 80 && ((int) Main.tile[index2 - 1, index1 - 1].active != 0 && (int) Main.tile[index2 - 1, index1 - 1].type == 80) && index2 >= i)
              --index2;
            if ((int) Main.tile[index2 + 1, index1].active != 0 && (int) Main.tile[index2 + 1, index1].type == 80 && ((int) Main.tile[index2 + 1, index1 - 1].active != 0 && (int) Main.tile[index2 + 1, index1 - 1].type == 80) && index2 <= i)
              ++index2;
          }
        }
        int num1 = index1 - 1;
        int num2 = i - index2;
        num1 = j;
        int num3 = (int) Main.tile[i - 2, j].type;
        int num4 = (int) Main.tile[i - 1, j].type;
        int num5 = (int) Main.tile[i + 1, j].type;
        int num6 = (int) Main.tile[i, j - 1].type;
        int index3 = (int) Main.tile[i, j + 1].type;
        int num7 = (int) Main.tile[i - 1, j + 1].type;
        int num8 = (int) Main.tile[i + 1, j + 1].type;
        if ((int) Main.tile[i - 1, j].active == 0)
          num4 = -1;
        if ((int) Main.tile[i + 1, j].active == 0)
          num5 = -1;
        if ((int) Main.tile[i, j - 1].active == 0)
          num6 = -1;
        if ((int) Main.tile[i, j + 1].active == 0)
          index3 = -1;
        if ((int) Main.tile[i - 1, j + 1].active == 0)
          num7 = -1;
        if ((int) Main.tile[i + 1, j + 1].active == 0)
          num8 = -1;
        short num9 = Main.tile[i, j].frameX;
        short num10 = Main.tile[i, j].frameY;
        if (num2 == 0)
        {
          if (num6 != 80)
          {
            if (num4 == 80 && num5 == 80 && (num7 != 80 && num8 != 80) && num3 != 80)
            {
              num9 = (short) 90;
              num10 = (short) 0;
            }
            else if (num4 == 80 && num7 != 80 && num3 != 80)
            {
              num9 = (short) 72;
              num10 = (short) 0;
            }
            else if (num5 == 80 && num8 != 80)
            {
              num9 = (short) 18;
              num10 = (short) 0;
            }
            else
            {
              num9 = (short) 0;
              num10 = (short) 0;
            }
          }
          else if (num4 == 80 && num5 == 80 && (num7 != 80 && num8 != 80) && num3 != 80)
          {
            num9 = (short) 90;
            num10 = (short) 36;
          }
          else if (num4 == 80 && num7 != 80 && num3 != 80)
          {
            num9 = (short) 72;
            num10 = (short) 36;
          }
          else if (num5 == 80 && num8 != 80)
          {
            num9 = (short) 18;
            num10 = (short) 36;
          }
          else if (index3 >= 0 && Main.tileSolid[index3])
          {
            num9 = (short) 0;
            num10 = (short) 36;
          }
          else
          {
            num9 = (short) 0;
            num10 = (short) 18;
          }
        }
        else if (num2 == -1)
        {
          if (num5 == 80)
          {
            if (num6 != 80 && index3 != 80)
            {
              num9 = (short) 108;
              num10 = (short) 36;
            }
            else if (index3 != 80)
            {
              num9 = (short) 54;
              num10 = (short) 36;
            }
            else if (num6 != 80)
            {
              num9 = (short) 54;
              num10 = (short) 0;
            }
            else
            {
              num9 = (short) 54;
              num10 = (short) 18;
            }
          }
          else if (num6 != 80)
          {
            num9 = (short) 54;
            num10 = (short) 0;
          }
          else
          {
            num9 = (short) 54;
            num10 = (short) 18;
          }
        }
        else if (num2 == 1)
        {
          if (num4 == 80)
          {
            if (num6 != 80 && index3 != 80)
            {
              num9 = (short) 108;
              num10 = (short) 16;
            }
            else if (index3 != 80)
            {
              num9 = (short) 36;
              num10 = (short) 36;
            }
            else if (num6 != 80)
            {
              num9 = (short) 36;
              num10 = (short) 0;
            }
            else
            {
              num9 = (short) 36;
              num10 = (short) 18;
            }
          }
          else if (num6 != 80)
          {
            num9 = (short) 36;
            num10 = (short) 0;
          }
          else
          {
            num9 = (short) 36;
            num10 = (short) 18;
          }
        }
        if ((int) num9 == (int) Main.tile[i, j].frameX && (int) num10 == (int) Main.tile[i, j].frameY)
          return;
        Main.tile[i, j].frameX = num9;
        Main.tile[i, j].frameY = num10;
        WorldGen.SquareTileFrame(i, j, -1);
      }
      catch
      {
        Main.tile[i, j].frameX = (short) 0;
        Main.tile[i, j].frameY = (short) 0;
      }
    }

    public static void GrowCactus(int i, int j)
    {
      int index1 = j;
      int i1 = i;
      if ((int) Main.tile[i, j].active == 0 || (int) Main.tile[i, j - 1].liquid > 0 || (int) Main.tile[i, j].type != 53 && (int) Main.tile[i, j].type != 80 && ((int) Main.tile[i, j].type != 112 && (int) Main.tile[i, j].type != 116))
        return;
      if ((int) Main.tile[i, j].type == 53 || (int) Main.tile[i, j].type == 112 || (int) Main.tile[i, j].type == 116)
      {
        if ((int) Main.tile[i, j - 1].active != 0 || (int) Main.tile[i - 1, j - 1].active != 0 || (int) Main.tile[i + 1, j - 1].active != 0)
          return;
        int num1 = 0;
        int num2 = 0;
        for (int index2 = i - 6; index2 <= i + 6; ++index2)
        {
          for (int index3 = j - 3; index3 <= j + 1; ++index3)
          {
            try
            {
              if ((int) Main.tile[index2, index3].active != 0)
              {
                if ((int) Main.tile[index2, index3].type == 80)
                {
                  ++num1;
                  if (num1 >= 4)
                    return;
                }
                if ((int) Main.tile[index2, index3].type != 53 && (int) Main.tile[index2, index3].type != 112)
                {
                  if ((int) Main.tile[index2, index3].type != 116)
                    continue;
                }
                ++num2;
              }
            }
            catch
            {
            }
          }
        }
        if (num2 <= 10)
          return;
        Main.tile[i, j - 1].active = (byte) 1;
        Main.tile[i, j - 1].type = (byte) 80;
        WorldGen.SquareTileFrame(i1, index1 - 1, -1);
        if (Main.netMode != 2)
          return;
        NetMessage.SendTile(i, j - 1);
      }
      else
      {
        if ((int) Main.tile[i, j].type != 80)
          return;
        while ((int) Main.tile[i1, index1].active != 0 && (int) Main.tile[i1, index1].type == 80)
        {
          ++index1;
          if ((int) Main.tile[i1, index1].active == 0 || (int) Main.tile[i1, index1].type != 80)
          {
            if ((int) Main.tile[i1 - 1, index1].active != 0 && (int) Main.tile[i1 - 1, index1].type == 80 && ((int) Main.tile[i1 - 1, index1 - 1].active != 0 && (int) Main.tile[i1 - 1, index1 - 1].type == 80) && i1 >= i)
              --i1;
            if ((int) Main.tile[i1 + 1, index1].active != 0 && (int) Main.tile[i1 + 1, index1].type == 80 && ((int) Main.tile[i1 + 1, index1 - 1].active != 0 && (int) Main.tile[i1 + 1, index1 - 1].type == 80) && i1 <= i)
              ++i1;
          }
        }
        int num1 = index1 - 1 - j;
        int num2 = i - i1;
        int num3 = i - num2;
        int num4 = j;
        int num5 = 11 - num1;
        int num6 = 0;
        for (int index2 = num3 - 2; index2 <= num3 + 2; ++index2)
        {
          for (int index3 = num4 - num5; index3 <= num4 + num1; ++index3)
          {
            if ((int) Main.tile[index2, index3].active != 0 && (int) Main.tile[index2, index3].type == 80)
              ++num6;
          }
        }
        if (num6 >= WorldGen.genRand.Next(11, 13))
          return;
        int index4 = i;
        int index5 = j;
        if (num2 == 0)
        {
          if (num1 == 0)
          {
            if ((int) Main.tile[index4, index5 - 1].active != 0)
              return;
            Main.tile[index4, index5 - 1].active = (byte) 1;
            Main.tile[index4, index5 - 1].type = (byte) 80;
            WorldGen.SquareTileFrame(index4, index5 - 1, -1);
            if (Main.netMode != 2)
              return;
            NetMessage.SendTile(index4, index5 - 1);
          }
          else
          {
            bool flag1 = false;
            bool flag2 = false;
            if ((int) Main.tile[index4, index5 - 1].active != 0 && (int) Main.tile[index4, index5 - 1].type == 80)
            {
              if ((int) Main.tile[index4 - 1, index5].active == 0 && (int) Main.tile[index4 - 2, index5 + 1].active == 0 && ((int) Main.tile[index4 - 1, index5 - 1].active == 0 && (int) Main.tile[index4 - 1, index5 + 1].active == 0) && (int) Main.tile[index4 - 2, index5].active == 0)
                flag1 = true;
              if ((int) Main.tile[index4 + 1, index5].active == 0 && (int) Main.tile[index4 + 2, index5 + 1].active == 0 && ((int) Main.tile[index4 + 1, index5 - 1].active == 0 && (int) Main.tile[index4 + 1, index5 + 1].active == 0) && (int) Main.tile[index4 + 2, index5].active == 0)
                flag2 = true;
            }
            int num7 = WorldGen.genRand.Next(3);
            if (num7 == 0 && flag1)
            {
              Main.tile[index4 - 1, index5].active = (byte) 1;
              Main.tile[index4 - 1, index5].type = (byte) 80;
              WorldGen.SquareTileFrame(index4 - 1, index5, -1);
              if (Main.netMode != 2)
                return;
              NetMessage.SendTile(index4 - 1, index5);
            }
            else if (num7 == 1 && flag2)
            {
              Main.tile[index4 + 1, index5].active = (byte) 1;
              Main.tile[index4 + 1, index5].type = (byte) 80;
              WorldGen.SquareTileFrame(index4 + 1, index5, -1);
              if (Main.netMode != 2)
                return;
              NetMessage.SendTile(index4 + 1, index5);
            }
            else
            {
              if (num1 >= WorldGen.genRand.Next(2, 8))
                return;
              if ((int) Main.tile[index4 - 1, index5 - 1].active != 0)
              {
                int num8 = (int) Main.tile[index4 - 1, index5 - 1].type;
              }
              if ((int) Main.tile[index4 + 1, index5 - 1].active != 0 && (int) Main.tile[index4 + 1, index5 - 1].type == 80 || (int) Main.tile[index4, index5 - 1].active != 0)
                return;
              Main.tile[index4, index5 - 1].active = (byte) 1;
              Main.tile[index4, index5 - 1].type = (byte) 80;
              WorldGen.SquareTileFrame(index4, index5 - 1, -1);
              if (Main.netMode != 2)
                return;
              NetMessage.SendTile(index4, index5 - 1);
            }
          }
        }
        else
        {
          if ((int) Main.tile[index4, index5 - 1].active != 0 || (int) Main.tile[index4, index5 - 2].active != 0 || ((int) Main.tile[index4 + num2, index5 - 1].active != 0 || (int) Main.tile[index4 - num2, index5 - 1].active == 0) || (int) Main.tile[index4 - num2, index5 - 1].type != 80)
            return;
          Main.tile[index4, index5 - 1].active = (byte) 1;
          Main.tile[index4, index5 - 1].type = (byte) 80;
          WorldGen.SquareTileFrame(index4, index5 - 1, -1);
          if (Main.netMode != 2)
            return;
          NetMessage.SendTile(index4, index5 - 1);
        }
      }
    }

    public static void CheckPot(int i, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = 0;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18;
      int index1 = num2 - (int) Main.tile[i, j].frameY / 18;
      int index2 = -(num3 & 1) + i;
      for (int index3 = index2; index3 < index2 + 2; ++index3)
      {
        for (int index4 = index1; index4 < index1 + 2; ++index4)
        {
          if (((int) Main.tile[index3, index4].frameX / 18 & 1) != index3 - index2 || (int) Main.tile[index3, index4].active == 0 || ((int) Main.tile[index3, index4].type != 28 || (int) Main.tile[index3, index4].frameY != (index4 - index1) * 18))
            goto label_10;
        }
        if ((int) Main.tile[index3, index1 + 2].active != 0 && Main.tileSolid[(int) Main.tile[index3, index1 + 2].type])
          continue;
label_10:
        WorldGen.destroyObject = true;
        for (int i1 = index2; i1 < index2 + 2; ++i1)
        {
          for (int j1 = index1; j1 < index1 + 2; ++j1)
          {
            if ((int) Main.tile[i1, j1].type == 28 && (int) Main.tile[i1, j1].active != 0)
              WorldGen.KillTile(i1, j1);
          }
        }
        if (!WorldGen.gen)
        {
          Rectangle rect = new Rectangle();
          rect.X = i << 4;
          rect.Y = j << 4;
          rect.Width = rect.Height = 16;
          Main.PlaySound(13, rect.X, rect.Y, 1);
          Gore.NewGore(new Vector2((float) rect.X, (float) rect.Y), new Vector2(), 51, 1.0);
          Gore.NewGore(new Vector2((float) rect.X, (float) rect.Y), new Vector2(), 52, 1.0);
          Gore.NewGore(new Vector2((float) rect.X, (float) rect.Y), new Vector2(), 53, 1.0);
          if (WorldGen.genRand.Next(40) == 0 && ((int) Main.tile[index2, index1].wall == 7 || (int) Main.tile[index2, index1].wall == 8 || (int) Main.tile[index2, index1].wall == 9))
            Item.NewItem(rect.X, rect.Y, 16, 16, 327, 1, false, 0);
          else if (WorldGen.genRand.Next(45) == 0)
          {
            if (j < Main.worldSurface)
            {
              int num4 = WorldGen.genRand.Next(4);
              if (num4 == 0)
                Item.NewItem(rect.X, rect.Y, 16, 16, 292, 1, false, 0);
              if (num4 == 1)
                Item.NewItem(rect.X, rect.Y, 16, 16, 298, 1, false, 0);
              if (num4 == 2)
                Item.NewItem(rect.X, rect.Y, 16, 16, 299, 1, false, 0);
              if (num4 == 3)
                Item.NewItem(rect.X, rect.Y, 16, 16, 290, 1, false, 0);
            }
            else if (j < Main.rockLayer)
            {
              int num4 = WorldGen.genRand.Next(7);
              if (num4 == 0)
                Item.NewItem(rect.X, rect.Y, 16, 16, 289, 1, false, 0);
              if (num4 == 1)
                Item.NewItem(rect.X, rect.Y, 16, 16, 298, 1, false, 0);
              if (num4 == 2)
                Item.NewItem(rect.X, rect.Y, 16, 16, 299, 1, false, 0);
              if (num4 == 3)
                Item.NewItem(rect.X, rect.Y, 16, 16, 290, 1, false, 0);
              if (num4 == 4)
                Item.NewItem(rect.X, rect.Y, 16, 16, 303, 1, false, 0);
              if (num4 == 5)
                Item.NewItem(rect.X, rect.Y, 16, 16, 291, 1, false, 0);
              if (num4 == 6)
                Item.NewItem(rect.X, rect.Y, 16, 16, 304, 1, false, 0);
            }
            else if (j < (int) Main.maxTilesY - 200)
            {
              int num4 = WorldGen.genRand.Next(10);
              if (num4 == 0)
                Item.NewItem(rect.X, rect.Y, 16, 16, 296, 1, false, 0);
              if (num4 == 1)
                Item.NewItem(rect.X, rect.Y, 16, 16, 295, 1, false, 0);
              if (num4 == 2)
                Item.NewItem(rect.X, rect.Y, 16, 16, 299, 1, false, 0);
              if (num4 == 3)
                Item.NewItem(rect.X, rect.Y, 16, 16, 302, 1, false, 0);
              if (num4 == 4)
                Item.NewItem(rect.X, rect.Y, 16, 16, 303, 1, false, 0);
              if (num4 == 5)
                Item.NewItem(rect.X, rect.Y, 16, 16, 305, 1, false, 0);
              if (num4 == 6)
                Item.NewItem(rect.X, rect.Y, 16, 16, 301, 1, false, 0);
              if (num4 == 7)
                Item.NewItem(rect.X, rect.Y, 16, 16, 302, 1, false, 0);
              if (num4 == 8)
                Item.NewItem(rect.X, rect.Y, 16, 16, 297, 1, false, 0);
              if (num4 == 9)
                Item.NewItem(rect.X, rect.Y, 16, 16, 304, 1, false, 0);
            }
            else
            {
              int num4 = WorldGen.genRand.Next(12);
              if (num4 == 0)
                Item.NewItem(rect.X, rect.Y, 16, 16, 296, 1, false, 0);
              if (num4 == 1)
                Item.NewItem(rect.X, rect.Y, 16, 16, 295, 1, false, 0);
              if (num4 == 2)
                Item.NewItem(rect.X, rect.Y, 16, 16, 293, 1, false, 0);
              if (num4 == 3)
                Item.NewItem(rect.X, rect.Y, 16, 16, 288, 1, false, 0);
              if (num4 == 4)
                Item.NewItem(rect.X, rect.Y, 16, 16, 294, 1, false, 0);
              if (num4 == 5)
                Item.NewItem(rect.X, rect.Y, 16, 16, 297, 1, false, 0);
              if (num4 == 6)
                Item.NewItem(rect.X, rect.Y, 16, 16, 304, 1, false, 0);
              if (num4 == 7)
                Item.NewItem(rect.X, rect.Y, 16, 16, 305, 1, false, 0);
              if (num4 == 8)
                Item.NewItem(rect.X, rect.Y, 16, 16, 301, 1, false, 0);
              if (num4 == 9)
                Item.NewItem(rect.X, rect.Y, 16, 16, 302, 1, false, 0);
              if (num4 == 10)
                Item.NewItem(rect.X, rect.Y, 16, 16, 288, 1, false, 0);
              if (num4 == 11)
                Item.NewItem(rect.X, rect.Y, 16, 16, 300, 1, false, 0);
            }
          }
          else
          {
            switch (Main.rand.Next(8))
            {
              case 0:
                Player closest1 = Player.FindClosest(ref rect);
                if ((int) closest1.statLife < (int) closest1.statLifeMax)
                {
                  Item.NewItem(rect.X, rect.Y, 16, 16, 58, 1, false, 0);
                  goto label_156;
                }
                else
                  goto label_156;
              case 1:
                Player closest2 = Player.FindClosest(ref rect);
                if ((int) closest2.statMana < (int) closest2.statManaMax)
                {
                  Item.NewItem(rect.X, rect.Y, 16, 16, 184, 1, false, 0);
                  goto label_156;
                }
                else
                  goto label_156;
              case 2:
                int Stack1 = Main.rand.Next(1, 6);
                if ((int) Main.tile[i, j].liquid > 0)
                {
                  Item.NewItem(rect.X, rect.Y, 16, 16, 282, Stack1, false, 0);
                  goto label_156;
                }
                else
                {
                  Item.NewItem(rect.X, rect.Y, 16, 16, 8, Stack1, false, 0);
                  goto label_156;
                }
              case 3:
                int Stack2 = Main.rand.Next(8) + 3;
                int Type1 = 40;
                if (j < Main.rockLayer && WorldGen.genRand.Next(2) == 0)
                  Type1 = !Main.hardMode ? 42 : 168;
                if (j > (int) Main.maxTilesY - 200)
                  Type1 = 265;
                else if (Main.hardMode)
                  Type1 = Main.rand.Next(2) != 0 ? 47 : 278;
                Item.NewItem(rect.X, rect.Y, 16, 16, Type1, Stack2, false, 0);
                goto label_156;
              case 4:
                int Type2 = 28;
                if (j > (int) Main.maxTilesY - 200 || Main.hardMode)
                  Type2 = 188;
                Item.NewItem(rect.X, rect.Y, 16, 16, Type2, 1, false, 0);
                goto label_156;
              case 5:
                if (j > Main.rockLayer)
                {
                  int Stack3 = Main.rand.Next(4) + 1;
                  Item.NewItem(rect.X, rect.Y, 16, 16, 166, Stack3, false, 0);
                  goto label_156;
                }
                else
                  break;
            }
            float num4 = (float) (200 + WorldGen.genRand.Next(-100, 101));
            if (j < Main.worldSurface)
              num4 *= 0.5f;
            else if (j < Main.rockLayer)
              num4 *= 0.75f;
            else if (j > (int) Main.maxTilesY - 250)
              num4 *= 1.25f;
            float num5 = num4 * (float) (1.0 + (double) Main.rand.Next(-20, 21) * 0.00999999977648258);
            if (Main.rand.Next(5) == 0)
              num5 *= (float) (1.0 + (double) Main.rand.Next(5, 11) * 0.00999999977648258);
            if (Main.rand.Next(10) == 0)
              num5 *= (float) (1.0 + (double) Main.rand.Next(10, 21) * 0.00999999977648258);
            if (Main.rand.Next(15) == 0)
              num5 *= (float) (1.0 + (double) Main.rand.Next(20, 41) * 0.00999999977648258);
            if (Main.rand.Next(20) == 0)
              num5 *= (float) (1.0 + (double) Main.rand.Next(40, 81) * 0.00999999977648258);
            if (Main.rand.Next(25) == 0)
              num5 *= (float) (1.0 + (double) Main.rand.Next(50, 101) * 0.00999999977648258);
            while ((int) num5 > 0)
            {
              if ((double) num5 > 1000000.0)
              {
                int Stack3 = (int) ((double) num5 / 1000000.0);
                if (Stack3 > 50 && Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(3) + 1;
                if (Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(3) + 1;
                if (Stack3 > 0)
                {
                  num5 -= (float) (1000000 * Stack3);
                  Item.NewItem(rect.X, rect.Y, 16, 16, 74, Stack3, false, 0);
                }
              }
              else if ((double) num5 > 10000.0)
              {
                int Stack3 = (int) ((double) num5 / 10000.0);
                if (Stack3 > 50 && Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(3) + 1;
                if (Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(3) + 1;
                if (Stack3 > 0)
                {
                  num5 -= (float) (10000 * Stack3);
                  Item.NewItem(rect.X, rect.Y, 16, 16, 73, Stack3, false, 0);
                }
              }
              else if ((double) num5 > 100.0)
              {
                int Stack3 = (int) ((double) num5 / 100.0);
                if (Stack3 > 50 && Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(3) + 1;
                if (Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(3) + 1;
                if (Stack3 > 0)
                {
                  num5 -= (float) (100 * Stack3);
                  Item.NewItem(rect.X, rect.Y, 16, 16, 72, Stack3, false, 0);
                }
              }
              else
              {
                int Stack3 = (int) num5;
                if (Stack3 > 50 && Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(3) + 1;
                if (Main.rand.Next(2) == 0)
                  Stack3 /= Main.rand.Next(4) + 1;
                if (Stack3 < 1)
                  Stack3 = 1;
                num5 -= (float) Stack3;
                Item.NewItem(rect.X, rect.Y, 16, 16, 71, Stack3, false, 0);
              }
            }
          }
        }
label_156:
        WorldGen.destroyObject = false;
        break;
      }
    }

    public static int PlaceChest(int x, int y, bool notNearOtherChests = false, int style = 0)
    {
      for (int index1 = x; index1 < x + 2; ++index1)
      {
        for (int index2 = y - 1; index2 < y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0 || (int) Main.tile[index1, index2].lava != 0)
            return -1;
        }
        if ((int) Main.tile[index1, y + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index1, y + 1].type])
          return -1;
      }
      if (notNearOtherChests)
      {
        for (int index1 = x - 25; index1 < x + 25; ++index1)
        {
          for (int index2 = y - 8; index2 < y + 8; ++index2)
          {
            try
            {
              if ((int) Main.tile[index1, index2].active != 0)
              {
                if ((int) Main.tile[index1, index2].type == 21)
                  return -1;
              }
            }
            catch
            {
            }
          }
        }
      }
      int chest = Chest.CreateChest(x, y - 1);
      if (chest != -1)
      {
        Main.tile[x, y - 1].active = (byte) 1;
        Main.tile[x, y - 1].frameY = (short) 0;
        Main.tile[x, y - 1].frameX = (short) (36 * style);
        Main.tile[x, y - 1].type = (byte) 21;
        Main.tile[x + 1, y - 1].active = (byte) 1;
        Main.tile[x + 1, y - 1].frameY = (short) 0;
        Main.tile[x + 1, y - 1].frameX = (short) (18 + 36 * style);
        Main.tile[x + 1, y - 1].type = (byte) 21;
        Main.tile[x, y].active = (byte) 1;
        Main.tile[x, y].frameY = (short) 18;
        Main.tile[x, y].frameX = (short) (36 * style);
        Main.tile[x, y].type = (byte) 21;
        Main.tile[x + 1, y].active = (byte) 1;
        Main.tile[x + 1, y].frameY = (short) 18;
        Main.tile[x + 1, y].frameX = (short) (18 + 36 * style);
        Main.tile[x + 1, y].type = (byte) 21;
      }
      return chest;
    }

    public static void CheckChest(int i, int j)
    {
      if (WorldGen.destroyObject)
        return;
      int num1 = 0;
      int num2 = j;
      int num3 = num1 + (int) Main.tile[i, j].frameX / 18;
      int num4 = num2 - (int) Main.tile[i, j].frameY / 18;
      int num5 = -(num3 & 1) + i;
      for (int index1 = num5; index1 < num5 + 2; ++index1)
      {
        for (int index2 = num4; index2 < num4 + 2; ++index2)
        {
          int num6 = (int) Main.tile[index1, index2].frameX / 18 & 1;
          if ((int) Main.tile[index1, index2].active == 0 || (int) Main.tile[index1, index2].type != 21 || (num6 != index1 - num5 || (int) Main.tile[index1, index2].frameY != (index2 - num4) * 18))
            goto label_10;
        }
        if ((int) Main.tile[index1, num4 + 2].active != 0 && Main.tileSolid[(int) Main.tile[index1, num4 + 2].type])
          continue;
label_10:
        int Type = 48;
        if ((int) Main.tile[i, j].frameX >= 216)
          Type = 348;
        else if ((int) Main.tile[i, j].frameX >= 180)
          Type = 343;
        else if ((int) Main.tile[i, j].frameX >= 108)
          Type = 328;
        else if ((int) Main.tile[i, j].frameX >= 36)
          Type = 306;
        WorldGen.destroyObject = true;
        for (int index2 = num5; index2 < num5 + 2; ++index2)
        {
          for (int index3 = num4; index3 < num4 + 3; ++index3)
          {
            if ((int) Main.tile[index2, index3].type == 21 && (int) Main.tile[index2, index3].active != 0)
            {
              Chest.DestroyChest(index2, index3);
              WorldGen.KillTile(index2, index3);
            }
          }
        }
        if (!WorldGen.gen)
          Item.NewItem(i * 16, j * 16, 32, 32, Type, 1, false, 0);
        WorldGen.destroyObject = false;
        break;
      }
    }

    public static bool PlaceWire(int i, int j)
    {
      if (Main.tile[i, j].wire != 0)
        return false;
      Main.tile[i, j].wire = 16;
      Main.PlaySound(0, i << 4, j << 4, 1);
      return true;
    }

    public static unsafe bool KillWire(int i, int j)
    {
      if (Main.tile[i, j].wire == 0)
        return false;
      Main.tile[i, j].wire = 0;
      i <<= 4;
      j <<= 4;
      Main.PlaySound(0, i, j, 1);
      if (Main.netMode != 1)
        Item.NewItem(i, j, 16, 16, 530, 1, false, 0);
      int num = 0;
      while (num < 3 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(i, j, 16, 16, 50, 0.0, 0.0, 0, new Color(), 1.0))
        ++num;
      return true;
    }

    public static bool CanPlaceTile(int i, ref int j, int type, int style = 0)
    {
      if (i < 0 || j < 0 || (i >= (int) Main.maxTilesX || j >= (int) Main.maxTilesY) || style >= 0 && (int) Main.tile[i, j].active == 0 && (Main.tileSolid[type] && Collision.AnyPlayerOrNPC(i, j, 1)))
        return false;
      switch (type)
      {
        case 136:
          if ((int) Main.tile[i - 1, j].active != 0 && (Main.tileSolid[(int) Main.tile[i - 1, j].type] || (int) Main.tile[i - 1, j].type == 124 || (int) Main.tile[i - 1, j].type == 5 && (int) Main.tile[i - 1, j - 1].type == 5 && (int) Main.tile[i - 1, j + 1].type == 5) || (int) Main.tile[i + 1, j].active != 0 && (Main.tileSolid[(int) Main.tile[i + 1, j].type] || (int) Main.tile[i + 1, j].type == 124 || (int) Main.tile[i + 1, j].type == 5 && (int) Main.tile[i + 1, j - 1].type == 5 && (int) Main.tile[i + 1, j + 1].type == 5))
            return true;
          if ((int) Main.tile[i, j + 1].active != 0)
            return Main.tileSolid[(int) Main.tile[i, j + 1].type];
          else
            return false;
        case 149:
        case 129:
          if (!WorldGen.SolidTileUnsafe(i - 1, j) && !WorldGen.SolidTileUnsafe(i + 1, j) && !WorldGen.SolidTileUnsafe(i, j - 1))
            return WorldGen.SolidTileUnsafe(i, j + 1);
          else
            return true;
        case 109:
        case 2:
        case 23:
          if ((int) Main.tile[i, j].type == 0)
            return (int) Main.tile[i, j].active != 0;
          else
            return false;
        case 60:
        case 70:
          if ((int) Main.tile[i, j].type == 59)
            return (int) Main.tile[i, j].active != 0;
          else
            return false;
        case 61:
        case 71:
          if (j + 1 < (int) Main.maxTilesY && (int) Main.tile[i, j + 1].active != 0)
            return (int) Main.tile[i, j + 1].type == type - 1;
          else
            return false;
        case 69:
        case 72:
        case 27:
        case 32:
        case 51:
        case 3:
        case 24:
          return (int) Main.tile[i, j].liquid == 0;
        case 81:
          if ((int) Main.tile[i - 1, j].active != 0 || (int) Main.tile[i + 1, j].active != 0 || ((int) Main.tile[i, j - 1].active != 0 || (int) Main.tile[i, j + 1].active == 0) || !Main.tileSolid[(int) Main.tile[i, j + 1].type])
            return false;
          else
            break;
        case 4:
          if (((int) Main.tile[i - 1, j].active == 0 || !Main.tileSolid[(int) Main.tile[i - 1, j].type] && (int) Main.tile[i - 1, j].type != 124 && ((int) Main.tile[i - 1, j].type != 5 || (int) Main.tile[i - 1, j - 1].type != 5 || (int) Main.tile[i - 1, j + 1].type != 5)) && ((int) Main.tile[i + 1, j].active == 0 || !Main.tileSolid[(int) Main.tile[i + 1, j].type] && (int) Main.tile[i + 1, j].type != 124 && ((int) Main.tile[i + 1, j].type != 5 || (int) Main.tile[i + 1, j - 1].type != 5 || (int) Main.tile[i + 1, j + 1].type != 5)) && ((int) Main.tile[i, j + 1].active == 0 || !Main.tileSolid[(int) Main.tile[i, j + 1].type]))
            return false;
          if (style != 8)
            return (int) Main.tile[i, j].liquid == 0;
          else
            return true;
        case 10:
          if ((int) Main.tile[i, j - 1].active == 0 && (int) Main.tile[i, j - 2].active == 0 && ((int) Main.tile[i, j - 3].active != 0 && Main.tileSolid[(int) Main.tile[i, j - 3].type]))
          {
            --j;
            return true;
          }
          else
          {
            if ((int) Main.tile[i, j + 1].active != 0 || (int) Main.tile[i, j + 2].active != 0 || ((int) Main.tile[i, j + 3].active == 0 || !Main.tileSolid[(int) Main.tile[i, j + 3].type]))
              return false;
            ++j;
            return true;
          }
        case 20:
          if ((int) Main.tile[i, j + 1].active != 0 && ((int) Main.tile[i, j + 1].type == 2 || (int) Main.tile[i, j + 1].type == 109 || (int) Main.tile[i, j + 1].type == 147))
            return (int) Main.tile[i, j].liquid == 0;
          else
            return false;
      }
      return true;
    }

    public static unsafe bool PlaceTile(int i, int j, int type, bool mute = false, bool forced = false, int plr = -1, int style = 0)
    {
      bool flag = false;
      fixed (Tile* tilePtr = &Main.tile[i, j])
      {
        if (WorldGen.CanPlaceTile(i, ref j, type, style) || forced)
        {
          tilePtr->frameX = (short) 0;
          tilePtr->frameY = (short) 0;
          if (type == 3 || type == 24 || type == 110)
          {
            if (j + 1 < (int) Main.maxTilesY && (int) tilePtr[1].active != 0 && (type == 3 && (int) tilePtr[1].type == 2 || type == 24 && (int) tilePtr[1].type == 23 || (type == 3 && (int) tilePtr[1].type == 78 || type == 110 && (int) tilePtr[1].type == 109)))
            {
              if (type == 24 && WorldGen.genRand.Next(13) == 0)
              {
                type = 32;
                flag = true;
              }
              else if ((int) tilePtr[1].type == 78)
              {
                tilePtr->frameX = (short) (WorldGen.genRand.Next(2) * 18 + 108);
                flag = true;
              }
              else if ((int) tilePtr->wall == 0 && (int) tilePtr[1].wall == 0)
              {
                if (WorldGen.genRand.Next(50) == 0 || type == 24 && WorldGen.genRand.Next(40) == 0)
                  tilePtr->frameX = (short) 144;
                else if (WorldGen.genRand.Next(35) == 0)
                  tilePtr->frameX = (short) (WorldGen.genRand.Next(2) * 18 + 108);
                else
                  tilePtr->frameX = (short) (WorldGen.genRand.Next(6) * 18);
                flag = true;
              }
              if (flag)
              {
                tilePtr->active = (byte) 1;
                tilePtr->type = (byte) type;
              }
            }
          }
          else if (type == 61)
          {
            tilePtr->active = (byte) 1;
            if (WorldGen.genRand.Next(16) == 0 && j > Main.worldSurface)
            {
              tilePtr->type = (byte) 69;
            }
            else
            {
              tilePtr->type = (byte) type;
              if (j > Main.rockLayer && WorldGen.genRand.Next(60) == 0)
                tilePtr->frameX = (short) 144;
              else if (j > Main.rockLayer && WorldGen.genRand.Next(1000) == 0)
                tilePtr->frameX = (short) 162;
              else if (WorldGen.genRand.Next(15) == 0)
                tilePtr->frameX = (short) (WorldGen.genRand.Next(2) * 18 + 108);
              else
                tilePtr->frameX = (short) (WorldGen.genRand.Next(6) * 18);
            }
            flag = true;
          }
          else if (type == 71)
          {
            tilePtr->active = (byte) 1;
            tilePtr->type = (byte) type;
            tilePtr->frameX = (short) (WorldGen.genRand.Next(5) * 18);
            flag = true;
          }
          else if (type == 129)
          {
            tilePtr->active = (byte) 1;
            tilePtr->type = (byte) type;
            tilePtr->frameX = (short) (WorldGen.genRand.Next(8) * 18);
            flag = true;
          }
          else if (type == 136)
          {
            tilePtr->active = (byte) 1;
            tilePtr->type = (byte) type;
            flag = true;
          }
          else if (type == 4)
          {
            tilePtr->active = (byte) 1;
            tilePtr->type = (byte) type;
            tilePtr->frameY = (short) (22 * style);
            flag = true;
          }
          else if (type == 10)
            flag = WorldGen.PlaceDoor(i, j, type);
          else if (type == 128)
            flag = WorldGen.PlaceMan(i, j, style);
          else if (type == 149)
          {
            tilePtr->active = (byte) 1;
            tilePtr->type = (byte) type;
            tilePtr->frameX = (short) (18 * style);
            flag = true;
          }
          else if (type == 139)
            flag = WorldGen.PlaceMB(i, j, type, style);
          else if (type == 34 || type == 35 || (type == 36 || type == 106))
            flag = WorldGen.Place3x3(i, j, type);
          else if (type == 13 || type == 33 || (type == 49 || type == 50) || type == 78)
            flag = WorldGen.PlaceOnTable1x1(i, j, type, style);
          else if (type == 14 || type == 26 || (type == 86 || type == 87) || (type == 88 || type == 89 || type == 114))
            flag = WorldGen.Place3x2(i, j, type);
          else if (type == 20 || type == 15)
            flag = WorldGen.Place1x2(i, j, type, style);
          else if (type == 16 || type == 18 || (type == 29 || type == 103) || type == 134)
            flag = WorldGen.Place2x1(i, j, type);
          else if (type == 92 || type == 93)
            flag = WorldGen.Place1xX(i, j, type, 0);
          else if (type == 104 || type == 105)
            flag = WorldGen.Place2xX(i, j, type, style);
          else if (type == 17 || type == 77 || type == 133)
            flag = WorldGen.Place3x2(i, j, type);
          else if (type == 21)
            flag = WorldGen.PlaceChest(i, j, false, style) >= 0;
          else if (type == 91)
            flag = WorldGen.PlaceBanner(i, j, type, style);
          else if (type == 135 || type == 141 || type == 144)
            flag = WorldGen.Place1x1(i, j, type, style);
          else if (type == 101 || type == 102)
            flag = WorldGen.Place3x4(i, j, type);
          else if (type == 27)
            flag = WorldGen.PlaceSunflower(i, j);
          else if (type == 28)
            flag = WorldGen.PlacePot(i, j);
          else if (type == 42)
            flag = WorldGen.Place1x2Top(i, j, type);
          else if (type == 55 || type == 85)
            flag = WorldGen.PlaceSign(i, j, type);
          else if (type >= 82 && type <= 84)
            flag = WorldGen.PlaceAlch(i, j, style);
          else if (type == 94 || type == 95 || (type == 96 || type == 97) || (type == 98 || type == 99 || (type == 100 || type == 125)) || (type == 126 || type == 132 || (type == 138 || type == 142) || type == 143))
            flag = WorldGen.Place2x2(i, j, type);
          else if (type == 79 || type == 90)
          {
            flag = WorldGen.Place4x2(i, j, type, plr >= 0 ? (int) Main.player[plr].direction : 1);
          }
          else
          {
            tilePtr->active = (byte) 1;
            tilePtr->type = (byte) type;
            if (type == 81)
              tilePtr->frameX = (short) (26 * WorldGen.genRand.Next(6));
            else if (type == 137 && style == 1)
              tilePtr->frameX = (short) 18;
            flag = true;
          }
          if (flag && !mute && !WorldGen.gen)
          {
            WorldGen.SquareTileFrame(i, j, -1);
            if (type == (int) sbyte.MaxValue)
            {
              Main.PlaySound(2, i * 16, j * 16, 30);
            }
            else
            {
              Main.PlaySound(0, i * 16, j * 16, 1);
              if (type == 22 || type == 140)
              {
                Main.dust.NewDust(i * 16, j * 16, 16, 16, 14, 0.0, 0.0, 0, new Color(), 1.0);
                Main.dust.NewDust(i * 16, j * 16, 16, 16, 14, 0.0, 0.0, 0, new Color(), 1.0);
              }
            }
          }
        }
      }
      return flag;
    }

    public static void UpdateMech()
    {
      for (int index1 = WorldGen.numMechs - 1; index1 >= 0; --index1)
      {
        --WorldGen.mech[index1].Time;
        if ((int) Main.tile[(int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y].active != 0 && (int) Main.tile[(int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y].type == 144)
        {
          if ((int) Main.tile[(int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y].frameY == 0)
          {
            WorldGen.mech[index1].Time = 0;
          }
          else
          {
            int num = (int) Main.tile[(int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y].frameX / 18;
            switch (num)
            {
              case 0:
                num = 60;
                break;
              case 1:
                num = 180;
                break;
              case 2:
                num = 300;
                break;
            }
            if (Math.IEEERemainder((double) WorldGen.mech[index1].Time, (double) num) == 0.0)
            {
              WorldGen.mech[index1].Time = 18000;
              WorldGen.TripWire((int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y);
            }
          }
        }
        if (WorldGen.mech[index1].Time <= 0)
        {
          if ((int) Main.tile[(int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y].active != 0 && (int) Main.tile[(int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y].type == 144)
          {
            Main.tile[(int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y].frameY = (short) 0;
            NetMessage.SendTile((int) WorldGen.mech[index1].X, (int) WorldGen.mech[index1].Y);
          }
          for (int index2 = index1; index2 < WorldGen.numMechs; ++index2)
            WorldGen.mech[index2] = WorldGen.mech[index2 + 1];
          --WorldGen.numMechs;
        }
      }
    }

    public static bool checkMech(int i, int j, int time)
    {
      for (int index = 0; index < WorldGen.numMechs; ++index)
      {
        if ((int) WorldGen.mech[index].X == i && (int) WorldGen.mech[index].Y == j)
          return false;
      }
      if (WorldGen.numMechs >= 999)
        return false;
      WorldGen.mech[WorldGen.numMechs].X = (short) i;
      WorldGen.mech[WorldGen.numMechs].Y = (short) j;
      WorldGen.mech[WorldGen.numMechs].Time = time;
      ++WorldGen.numMechs;
      return true;
    }

    public static void hitSwitch(int i, int j)
    {
      if ((int) Main.tile[i, j].type == 135)
      {
        Main.PlaySound(28, i * 16, j * 16, 0);
        WorldGen.TripWire(i, j);
      }
      else if ((int) Main.tile[i, j].type == 136)
      {
        if ((int) Main.tile[i, j].frameY == 0)
          Main.tile[i, j].frameY = (short) 18;
        else
          Main.tile[i, j].frameY = (short) 0;
        Main.PlaySound(28, i * 16, j * 16, 0);
        WorldGen.TripWire(i, j);
      }
      else if ((int) Main.tile[i, j].type == 144)
      {
        if ((int) Main.tile[i, j].frameY == 0)
        {
          Main.tile[i, j].frameY = (short) 18;
          if (Main.netMode != 1)
            WorldGen.checkMech(i, j, 18000);
        }
        else
          Main.tile[i, j].frameY = (short) 0;
        Main.PlaySound(28, i * 16, j * 16, 0);
      }
      else
      {
        if ((int) Main.tile[i, j].type != 132)
          return;
        short num1 = (short) 36;
        int num2 = (int) Main.tile[i, j].frameX / 18 * -1;
        int num3 = (int) Main.tile[i, j].frameY / 18 * -1;
        if (num2 < -1)
        {
          num2 += 2;
          num1 = (short) -36;
        }
        int i1 = num2 + i;
        int j1 = num3 + j;
        for (int index1 = i1; index1 < i1 + 2; ++index1)
        {
          for (int index2 = j1; index2 < j1 + 2; ++index2)
          {
            if ((int) Main.tile[index1, index2].type == 132)
              Main.tile[index1, index2].frameX += num1;
          }
        }
        WorldGen.TileFrame(i1, j1, 0);
        Main.PlaySound(28, i * 16, j * 16, 0);
        for (int i2 = i1; i2 < i1 + 2; ++i2)
        {
          for (int j2 = j1; j2 < j1 + 2; ++j2)
          {
            if ((int) Main.tile[i2, j2].type == 132 && (int) Main.tile[i2, j2].active != 0 && Main.tile[i2, j2].wire != 0)
            {
              WorldGen.TripWire(i2, j2);
              return;
            }
          }
        }
      }
    }

    public static void TripWire(int i, int j)
    {
      if (Main.netMode == 1)
        return;
      WorldGen.numWire = 0;
      WorldGen.numNoWire = 0;
      WorldGen.numInPump = 0;
      WorldGen.numOutPump = 0;
      WorldGen.NoWire(i, j);
      WorldGen.hitWire(i, j);
      if (WorldGen.numInPump <= 0 || WorldGen.numOutPump <= 0)
        return;
      WorldGen.xferWater();
    }

    public static void xferWater()
    {
      for (int index1 = 0; index1 < WorldGen.numInPump; ++index1)
      {
        int i1 = (int) WorldGen.inPump[index1].X;
        int j1 = (int) WorldGen.inPump[index1].Y;
        int num1 = (int) Main.tile[i1, j1].liquid;
        if (num1 > 0)
        {
          int num2 = (int) Main.tile[i1, j1].lava;
          for (int index2 = 0; index2 < WorldGen.numOutPump; ++index2)
          {
            int i2 = (int) WorldGen.outPump[index2].X;
            int j2 = (int) WorldGen.outPump[index2].Y;
            int num3 = (int) Main.tile[i2, j2].liquid;
            if (num3 < (int) byte.MaxValue)
            {
              int num4 = (int) Main.tile[i2, j2].lava;
              if (num3 == 0)
                num4 = num2;
              if (num2 == num4)
              {
                int num5 = num1;
                if (num5 + num3 > (int) byte.MaxValue)
                  num5 = (int) byte.MaxValue - num3;
                Main.tile[i2, j2].liquid += (byte) num5;
                Main.tile[i1, j1].liquid -= (byte) num5;
                num1 = (int) Main.tile[i1, j1].liquid;
                Main.tile[i2, j2].lava = (byte) num2;
                WorldGen.SquareTileFrame(i2, j2, -1);
                if ((int) Main.tile[i1, j1].liquid == 0)
                {
                  Main.tile[i1, j1].lava = (byte) 0;
                  WorldGen.SquareTileFrame(i1, j1, -1);
                  break;
                }
              }
            }
          }
          WorldGen.SquareTileFrame(i1, j1, -1);
        }
      }
    }

    public static void NoWire(int i, int j)
    {
      if (WorldGen.numNoWire >= 999)
        return;
      WorldGen.noWire[WorldGen.numNoWire].X = (short) i;
      WorldGen.noWire[WorldGen.numNoWire].Y = (short) j;
      ++WorldGen.numNoWire;
    }

    public static void hitWire(int i, int j)
    {
      if (WorldGen.numWire >= 999 || Main.tile[i, j].wire == 0)
        return;
      for (int index = 0; index < WorldGen.numWire; ++index)
      {
        if ((int) WorldGen.wire[index].X == i && (int) WorldGen.wire[index].Y == j)
          return;
      }
      WorldGen.wire[WorldGen.numWire].X = (short) i;
      WorldGen.wire[WorldGen.numWire].Y = (short) j;
      ++WorldGen.numWire;
      int num1 = (int) Main.tile[i, j].type;
      bool flag = true;
      for (int index = 0; index < WorldGen.numNoWire; ++index)
      {
        if ((int) WorldGen.noWire[index].X == i && (int) WorldGen.noWire[index].Y == j)
          flag = false;
      }
      if (flag && (int) Main.tile[i, j].active != 0)
      {
        if (num1 == 144)
        {
          WorldGen.hitSwitch(i, j);
          WorldGen.SquareTileFrame(i, j, -1);
          NetMessage.SendTile(i, j);
        }
        else if (num1 == 130)
        {
          Main.tile[i, j].type = (byte) 131;
          WorldGen.SquareTileFrame(i, j, -1);
          NetMessage.SendTile(i, j);
        }
        else if (num1 == 131)
        {
          Main.tile[i, j].type = (byte) 130;
          WorldGen.SquareTileFrame(i, j, -1);
          NetMessage.SendTile(i, j);
        }
        else if (num1 == 11)
        {
          WorldGen.CloseDoor(i, j, true);
          NetMessage.CreateMessage2(24, i, j);
          NetMessage.SendMessage();
        }
        else if (num1 == 10)
        {
          int direction = (Main.rand.Next(2) << 1) - 1;
          int number3 = WorldGen.OpenDoor(i, j, direction);
          if (number3 != 0)
          {
            NetMessage.CreateMessage3(19, i, j, number3);
            NetMessage.SendMessage();
          }
        }
        else if (num1 == 4)
        {
          if ((int) Main.tile[i, j].frameX < 66)
            Main.tile[i, j].frameX += (short) 66;
          else
            Main.tile[i, j].frameX -= (short) 66;
          NetMessage.SendTile(i, j);
        }
        else if (num1 == 149)
        {
          if ((int) Main.tile[i, j].frameX < 54)
            Main.tile[i, j].frameX += (short) 54;
          else
            Main.tile[i, j].frameX -= (short) 54;
          NetMessage.SendTile(i, j);
        }
        else if (num1 == 42)
        {
          int j1 = j - (int) Main.tile[i, j].frameY / 18;
          short num2 = (short) 18;
          if ((int) Main.tile[i, j].frameX > 0)
            num2 = (short) -18;
          Main.tile[i, j1].frameX += num2;
          Main.tile[i, j1 + 1].frameX += num2;
          WorldGen.NoWire(i, j1);
          WorldGen.NoWire(i, j1 + 1);
          NetMessage.SendTileSquare(i, j, 2);
        }
        else if (num1 == 93)
        {
          int j1 = j - (int) Main.tile[i, j].frameY / 18;
          short num2 = (short) 18;
          if ((int) Main.tile[i, j].frameX > 0)
            num2 = (short) -18;
          Main.tile[i, j1].frameX += num2;
          Main.tile[i, j1 + 1].frameX += num2;
          Main.tile[i, j1 + 2].frameX += num2;
          WorldGen.NoWire(i, j1);
          WorldGen.NoWire(i, j1 + 1);
          WorldGen.NoWire(i, j1 + 2);
          NetMessage.SendTileSquare(i, j1 + 1, 3);
        }
        else if (num1 == 126 || num1 == 100 || num1 == 95)
        {
          int index1 = j - (int) Main.tile[i, j].frameY / 18;
          int num2 = (int) Main.tile[i, j].frameX / 18;
          if (num2 > 1)
            num2 -= 2;
          int index2 = i - num2;
          short num3 = (short) 36;
          if ((int) Main.tile[index2, index1].frameX > 0)
            num3 = (short) -36;
          Main.tile[index2, index1].frameX += num3;
          Main.tile[index2, index1 + 1].frameX += num3;
          Main.tile[index2 + 1, index1].frameX += num3;
          Main.tile[index2 + 1, index1 + 1].frameX += num3;
          WorldGen.NoWire(index2, index1);
          WorldGen.NoWire(index2, index1 + 1);
          WorldGen.NoWire(index2 + 1, index1);
          WorldGen.NoWire(index2 + 1, index1 + 1);
          NetMessage.SendTileSquare(index2, index1, 3);
        }
        else if (num1 == 34 || num1 == 35 || num1 == 36)
        {
          int index1 = j - (int) Main.tile[i, j].frameY / 18;
          int num2 = (int) Main.tile[i, j].frameX / 18;
          if (num2 > 2)
            num2 -= 3;
          int index2 = i - num2;
          short num3 = (short) 54;
          if ((int) Main.tile[index2, index1].frameX > 0)
            num3 = (short) -54;
          for (int i1 = index2; i1 < index2 + 3; ++i1)
          {
            for (int j1 = index1; j1 < index1 + 3; ++j1)
            {
              Main.tile[i1, j1].frameX += num3;
              WorldGen.NoWire(i1, j1);
            }
          }
          NetMessage.SendTileSquare(index2 + 1, index1 + 1, 3);
        }
        else if (num1 == 33)
        {
          short num2 = (short) 18;
          if ((int) Main.tile[i, j].frameX > 0)
            num2 = (short) -18;
          Main.tile[i, j].frameX += num2;
          NetMessage.SendTileSquare(i, j, 3);
        }
        else if (num1 == 92)
        {
          int j1 = j - (int) Main.tile[i, j].frameY / 18;
          short num2 = (short) 18;
          if ((int) Main.tile[i, j].frameX > 0)
            num2 = (short) -18;
          Main.tile[i, j1].frameX += num2;
          Main.tile[i, j1 + 1].frameX += num2;
          Main.tile[i, j1 + 2].frameX += num2;
          Main.tile[i, j1 + 3].frameX += num2;
          Main.tile[i, j1 + 4].frameX += num2;
          Main.tile[i, j1 + 5].frameX += num2;
          WorldGen.NoWire(i, j1);
          WorldGen.NoWire(i, j1 + 1);
          WorldGen.NoWire(i, j1 + 2);
          WorldGen.NoWire(i, j1 + 3);
          WorldGen.NoWire(i, j1 + 4);
          WorldGen.NoWire(i, j1 + 5);
          NetMessage.SendTileSquare(i, j1 + 3, 7);
        }
        else if (num1 == 137)
        {
          if (WorldGen.checkMech(i, j, 180))
          {
            int num2 = -1;
            if ((int) Main.tile[i, j].frameX != 0)
              num2 = 1;
            float SpeedX = (float) (12 * num2);
            int Damage = 20;
            int Type = 98;
            Vector2 vector2 = new Vector2((float) (i * 16 + 8), (float) (j * 16 + 7));
            vector2.X += (float) (10 * num2);
            vector2.Y += 2f;
            Projectile.NewProjectile((float) (int) vector2.X, (float) (int) vector2.Y, SpeedX, 0.0f, Type, Damage, 2f, 8, true);
          }
        }
        else if (num1 == 139)
          WorldGen.SwitchMB(i, j);
        else if (num1 == 141)
        {
          WorldGen.KillTile(i, j, false, false, true);
          NetMessage.SendTile(i, j);
          Projectile.NewProjectile((float) (i * 16 + 8), (float) (j * 16 + 8), 0.0f, 0.0f, 108, 250, 10f, 8, true);
        }
        else if (num1 == 142 || num1 == 143)
        {
          int j1 = j - (int) Main.tile[i, j].frameY / 18;
          int num2 = (int) Main.tile[i, j].frameX / 18;
          if (num2 > 1)
            num2 -= 2;
          int i1 = i - num2;
          WorldGen.NoWire(i1, j1);
          WorldGen.NoWire(i1, j1 + 1);
          WorldGen.NoWire(i1 + 1, j1);
          WorldGen.NoWire(i1 + 1, j1 + 1);
          if (num1 == 142)
          {
            for (int index = 0; index < 4 && WorldGen.numInPump < 19; ++index)
            {
              int num3;
              int num4;
              if (index == 0)
              {
                num3 = i1;
                num4 = j1 + 1;
              }
              else if (index == 1)
              {
                num3 = i1 + 1;
                num4 = j1 + 1;
              }
              else if (index == 2)
              {
                num3 = i1;
                num4 = j1;
              }
              else
              {
                num3 = i1 + 1;
                num4 = j1;
              }
              WorldGen.inPump[WorldGen.numInPump].X = (short) num3;
              WorldGen.inPump[WorldGen.numInPump].Y = (short) num4;
              ++WorldGen.numInPump;
            }
          }
          else
          {
            for (int index = 0; index < 4 && WorldGen.numOutPump < 19; ++index)
            {
              int num3;
              int num4;
              if (index == 0)
              {
                num3 = i1;
                num4 = j1 + 1;
              }
              else if (index == 1)
              {
                num3 = i1 + 1;
                num4 = j1 + 1;
              }
              else if (index == 2)
              {
                num3 = i1;
                num4 = j1;
              }
              else
              {
                num3 = i1 + 1;
                num4 = j1;
              }
              WorldGen.outPump[WorldGen.numOutPump].X = (short) num3;
              WorldGen.outPump[WorldGen.numOutPump].Y = (short) num4;
              ++WorldGen.numOutPump;
            }
          }
        }
        else if (num1 == 105)
        {
          int j1 = j - (int) Main.tile[i, j].frameY / 18;
          int num2 = (int) Main.tile[i, j].frameX / 18;
          int num3 = num2 >> 1;
          int i1 = i - (num2 & 1);
          WorldGen.NoWire(i1, j1);
          WorldGen.NoWire(i1, j1 + 1);
          WorldGen.NoWire(i1, j1 + 2);
          WorldGen.NoWire(i1 + 1, j1);
          WorldGen.NoWire(i1 + 1, j1 + 1);
          WorldGen.NoWire(i1 + 1, j1 + 2);
          int num4 = i1 * 16 + 16;
          int num5 = (j1 + 3) * 16;
          int index1 = -1;
          if (num3 == 4)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 1))
              index1 = NPC.NewNPC(num4, num5 - 12, 1, 0);
          }
          else if (num3 == 7)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 49))
              index1 = NPC.NewNPC(num4 - 4, num5 - 6, 49, 0);
          }
          else if (num3 == 8)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 55))
              index1 = NPC.NewNPC(num4, num5 - 12, 55, 0);
          }
          else if (num3 == 9)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 46))
              index1 = NPC.NewNPC(num4, num5 - 12, 46, 0);
          }
          else if (num3 == 10)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 21))
              index1 = NPC.NewNPC(num4, num5, 21, 0);
          }
          else if (num3 == 18)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 67))
              index1 = NPC.NewNPC(num4, num5 - 12, 67, 0);
          }
          else if (num3 == 23)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 63))
              index1 = NPC.NewNPC(num4, num5 - 12, 63, 0);
          }
          else if (num3 == 27)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 85))
              index1 = NPC.NewNPC(num4 - 9, num5, 85, 0);
          }
          else if (num3 == 28)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 74))
              index1 = NPC.NewNPC(num4, num5 - 12, 74, 0);
          }
          else if (num3 == 42)
          {
            if (WorldGen.checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 58))
              index1 = NPC.NewNPC(num4, num5 - 12, 58, 0);
          }
          else if (num3 == 37)
          {
            if (WorldGen.checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 58))
              Item.NewItem(num4, num5 - 16, 0, 0, 58, 1, false, 0);
          }
          else if (num3 == 2)
          {
            if (WorldGen.checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 184))
              Item.NewItem(num4, num5 - 16, 0, 0, 184, 1, false, 0);
          }
          else if (num3 == 17)
          {
            if (WorldGen.checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 166))
              Item.NewItem(num4, num5 - 20, 0, 0, 166, 1, false, 0);
          }
          else if (num3 == 40)
          {
            if (WorldGen.checkMech(i, j, 300))
            {
              int[] numArray = new int[10];
              int upperBound = 0;
              for (int index2 = 0; index2 < 196; ++index2)
              {
                if ((int) Main.npc[index2].active != 0 && ((int) Main.npc[index2].type == 17 || (int) Main.npc[index2].type == 19 || ((int) Main.npc[index2].type == 22 || (int) Main.npc[index2].type == 38) || ((int) Main.npc[index2].type == 54 || (int) Main.npc[index2].type == 107 || (int) Main.npc[index2].type == 108)))
                {
                  numArray[upperBound] = index2;
                  ++upperBound;
                  if (upperBound >= 9)
                    break;
                }
              }
              if (upperBound > 0)
              {
                int number = numArray[Main.rand.Next(upperBound)];
                Main.npc[number].aabb.X = num4 - ((int) Main.npc[number].width >> 1);
                Main.npc[number].aabb.Y = num5 - (int) Main.npc[number].height - 1;
                Main.npc[number].position.X = (float) Main.npc[number].aabb.X;
                Main.npc[number].position.Y = (float) Main.npc[number].aabb.Y;
                NetMessage.CreateMessage1(23, number);
                NetMessage.SendMessage();
              }
            }
          }
          else if (num3 == 41 && WorldGen.checkMech(i, j, 300))
          {
            int[] numArray = new int[10];
            int upperBound = 0;
            for (int index2 = 0; index2 < 196; ++index2)
            {
              if ((int) Main.npc[index2].active != 0 && ((int) Main.npc[index2].type == 18 || (int) Main.npc[index2].type == 20 || (int) Main.npc[index2].type == 124))
              {
                numArray[upperBound] = index2;
                ++upperBound;
                if (upperBound >= 9)
                  break;
              }
            }
            if (upperBound > 0)
            {
              int number = numArray[Main.rand.Next(upperBound)];
              Main.npc[number].aabb.X = num4 - ((int) Main.npc[number].width >> 1);
              Main.npc[number].aabb.Y = num5 - (int) Main.npc[number].height - 1;
              Main.npc[number].position.X = (float) Main.npc[number].aabb.X;
              Main.npc[number].position.Y = (float) Main.npc[number].aabb.Y;
              NetMessage.CreateMessage1(23, number);
              NetMessage.SendMessage();
            }
          }
          if (index1 >= 0)
          {
            Main.npc[index1].value = 0.0f;
            Main.npc[index1].npcSlots = 0.0f;
          }
        }
      }
      WorldGen.hitWire(i - 1, j);
      WorldGen.hitWire(i + 1, j);
      WorldGen.hitWire(i, j - 1);
      WorldGen.hitWire(i, j + 1);
    }

    public static unsafe bool CanKillTile(int i, int j)
    {
      fixed (Tile* tilePtr1 = &Main.tile[i, j])
      {
        if ((int) tilePtr1->active != 0 && j >= 1)
        {
          Tile* tilePtr2 = tilePtr1 - 1;
          if ((int) tilePtr2->active != 0)
          {
            int num1 = (int) tilePtr1->type;
            int num2 = (int) tilePtr2->type;
            switch (num2)
            {
              case 21:
              case 26:
              case 72:
              case 12:
                return num1 == num2;
              case 5:
                if (num1 != num2)
                  return (int) tilePtr1[-1].frameX == 66 && (int) tilePtr1[-1].frameY >= 0 && (int) tilePtr1[-1].frameY <= 44 || (int) tilePtr1[-1].frameX == 88 && (int) tilePtr1[-1].frameY >= 66 && (int) tilePtr1[-1].frameY <= 110 || (int) tilePtr1[-1].frameY >= 198;
                else
                  return true;
            }
          }
        }
      }
      return true;
    }

    public static bool CanKillWall(int i, int j)
    {
      int index1 = (int) Main.tile[i, j].wall;
      if (Main.wallHouse[index1])
        return true;
      for (int index2 = i - 1; index2 < i + 2; ++index2)
      {
        for (int index3 = j - 1; index3 < j + 2; ++index3)
        {
          if ((int) Main.tile[index2, index3].wall != index1)
            return true;
        }
      }
      return false;
    }

    public static unsafe void KillWall(int i, int j, bool fail = false)
    {
      if (i < 0 || j < 0 || (i >= (int) Main.maxTilesX || j >= (int) Main.maxTilesY))
        return;
      int num = (int) Main.tile[i, j].wall;
      if (num <= 0)
        return;
      int Type1 = 0;
      int type = 0;
      switch (num)
      {
        case 1:
        case 5:
        case 6:
        case 7:
        case 8:
        case 9:
          Type1 = 1;
          break;
        case 4:
          Type1 = 7;
          break;
        case 10:
        case 11:
          Type1 = num;
          break;
        case 12:
          Type1 = 9;
          break;
        case 21:
          type = 13;
          Type1 = 13;
          break;
        case 22:
        case 28:
          Type1 = 51;
          break;
        case 23:
          Type1 = 38;
          break;
        case 24:
          Type1 = 36;
          break;
        case 25:
          Type1 = 48;
          break;
        case 26:
        case 30:
          Type1 = 49;
          break;
        case 29:
          Type1 = 50;
          break;
        case 31:
          Type1 = 51;
          break;
      }
      Main.PlaySound(type, i * 16, j * 16, 1);
      for (int index = fail ? 1 : 5; index >= 0; --index)
      {
        switch (num)
        {
          case 3:
            Type1 = 1 + 13 * WorldGen.genRand.Next(2);
            break;
          case 27:
            Type1 = 1 + 6 * WorldGen.genRand.Next(2);
            break;
        }
        Main.dust.NewDust(i * 16, j * 16, 16, 16, Type1, 0.0, 0.0, 0, new Color(), 1.0);
      }
      if (fail)
        return;
      int Type2 = 0;
      switch (num)
      {
        case 1:
          Type2 = 26;
          break;
        case 4:
          Type2 = 93;
          break;
        case 5:
          Type2 = 130;
          break;
        case 6:
          Type2 = 132;
          break;
        case 7:
          Type2 = 135;
          break;
        case 8:
          Type2 = 138;
          break;
        case 9:
          Type2 = 140;
          break;
        case 10:
          Type2 = 142;
          break;
        case 11:
          Type2 = 144;
          break;
        case 12:
          Type2 = 146;
          break;
        case 14:
          Type2 = 330;
          break;
        case 16:
          Type2 = 30;
          break;
        case 17:
          Type2 = 135;
          break;
        case 18:
          Type2 = 138;
          break;
        case 19:
          Type2 = 140;
          break;
        case 20:
          Type2 = 330;
          break;
        case 21:
          Type2 = 392;
          break;
        case 22:
          Type2 = 417;
          break;
        case 23:
          Type2 = 418;
          break;
        case 24:
          Type2 = 419;
          break;
        case 25:
          Type2 = 420;
          break;
        case 26:
          Type2 = 421;
          break;
        case 27:
          Type2 = 479;
          break;
        case 29:
          Type2 = 587;
          break;
        case 30:
          Type2 = 592;
          break;
        case 31:
          Type2 = 595;
          break;
      }
      if (Type2 > 0)
        Item.NewItem(i * 16, j * 16, 16, 16, Type2, 1, false, 0);
      Main.tile[i, j].wall = (byte) 0;
      WorldGen.SquareWallFrame(i, j, true);
    }

    public static unsafe void KillTileFast(int i, int j)
    {
      fixed (Tile* tilePtr1 = &Main.tile[i, j])
      {
        if ((int) tilePtr1->active != 0)
        {
          int num1 = (int) tilePtr1->type;
          if (j >= 1)
          {
            Tile* tilePtr2 = tilePtr1 - 1;
            if ((int) tilePtr2->active != 0)
            {
              int num2 = (int) tilePtr2->type;
              switch (num2)
              {
                case 21:
                case 26:
                case 72:
                case 12:
                  if (num1 != num2)
                    return;
                  else
                    break;
                case 5:
                  if (num1 != num2 && ((int) tilePtr1[-1].frameX != 66 || (int) tilePtr1[-1].frameY < 0 || (int) tilePtr1[-1].frameY > 44) && (((int) tilePtr1[-1].frameX != 88 || (int) tilePtr1[-1].frameY < 66 || (int) tilePtr1[-1].frameY > 110) && (int) tilePtr1[-1].frameY < 198))
                    return;
                  else
                    break;
              }
            }
          }
          if (num1 != 138)
          {
            if (num1 == 128)
            {
              int index1 = i;
              int num2 = (int) tilePtr1->frameX;
              if ((int) tilePtr1->frameX % 100 % 36 == 18)
              {
                num2 = (int) tilePtr1[-1440].frameX;
                --index1;
              }
              if (num2 >= 100)
              {
                int index2 = num2 / 100;
                int num3 = num2 % 100;
                switch ((int) Main.tile[index1, j].frameY / 18)
                {
                  case 0:
                    Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.headType[index2], 1, false, 0);
                    break;
                  case 1:
                    Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.bodyType[index2], 1, false, 0);
                    break;
                  case 2:
                    Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.legType[index2], 1, false, 0);
                    break;
                }
                int num4 = (int) Main.tile[index1, j].frameX % 100;
                Main.tile[index1, j].frameX = (short) num4;
              }
            }
            else if (num1 == 21 && Main.netMode != 1)
            {
              int num2 = (int) tilePtr1->frameX / 18;
              int Y = j - (int) tilePtr1->frameY / 18;
              if (!Chest.DestroyChest(i - (num2 & 1), Y))
                return;
            }
          }
          tilePtr1->active = (byte) 0;
          tilePtr1->type = (byte) 0;
          tilePtr1->frameX = (short) -1;
          tilePtr1->frameY = (short) -1;
          tilePtr1->frameNumber = (byte) 0;
          if (num1 == 58 && j > (int) Main.maxTilesY - 200)
          {
            tilePtr1->lava = (byte) 32;
            tilePtr1->liquid = (byte) sbyte.MinValue;
          }
          WorldGen.SquareTileFrame(i, j, -1);
        }
      }
    }

    public static unsafe bool KillTile(int i, int j)
    {
      if (i >= 0 && j >= 0 && (i < (int) Main.maxTilesX && j < (int) Main.maxTilesY))
      {
        fixed (Tile* tilePtr1 = &Main.tile[i, j])
        {
          if ((int) tilePtr1->active != 0)
          {
            int index1 = (int) tilePtr1->type;
            if (j >= 1)
            {
              Tile* tilePtr2 = tilePtr1 - 1;
              if ((int) tilePtr2->active != 0)
              {
                int num = (int) tilePtr2->type;
                switch (num)
                {
                  case 21:
                  case 26:
                  case 72:
                  case 12:
                    if (index1 != num)
                      return false;
                    else
                      break;
                  case 5:
                    if (index1 != num && ((int) tilePtr1[-1].frameX != 66 || (int) tilePtr1[-1].frameY < 0 || (int) tilePtr1[-1].frameY > 44) && (((int) tilePtr1[-1].frameX != 88 || (int) tilePtr1[-1].frameY < 66 || (int) tilePtr1[-1].frameY > 110) && (int) tilePtr1[-1].frameY < 198))
                      return false;
                    else
                      break;
                }
              }
            }
            if (!WorldGen.gen && !WorldGen.stopDrops)
            {
              if (index1 == (int) sbyte.MaxValue)
                Main.PlaySound(2, i * 16, j * 16, 27);
              else if (index1 == 3 || index1 == 110)
              {
                Main.PlaySound(6, i * 16, j * 16, 1);
                if ((int) tilePtr1->frameX == 144)
                  Item.NewItem(i * 16, j * 16, 16, 16, 5, 1, false, 0);
              }
              else if (index1 == 24)
              {
                Main.PlaySound(6, i * 16, j * 16, 1);
                if ((int) tilePtr1->frameX == 144)
                  Item.NewItem(i * 16, j * 16, 16, 16, 60, 1, false, 0);
              }
              else if (index1 == 32 || index1 == 51 || (index1 == 52 || index1 == 61) || (index1 == 62 || index1 == 69 || (index1 == 71 || index1 == 73)) || (index1 == 74 || index1 >= 82 && index1 <= 84 || (index1 == 113 || index1 == 115)))
                Main.PlaySound(6, i * 16, j * 16, 1);
              else if (index1 == 1 || index1 == 6 || (index1 == 7 || index1 == 8) || (index1 == 9 || index1 == 22 || (index1 == 25 || index1 == 37)) || (index1 == 38 || index1 == 39 || (index1 == 41 || index1 == 43) || (index1 == 44 || index1 == 45 || (index1 == 46 || index1 == 47))) || (index1 == 48 || index1 == 56 || (index1 == 58 || index1 == 63) || (index1 == 64 || index1 == 65 || (index1 == 66 || index1 == 67)) || (index1 == 68 || index1 == 75 || (index1 == 76 || index1 == 107) || (index1 == 108 || index1 == 111 || (index1 == 117 || index1 == 118)))) || (index1 == 119 || index1 == 120 || (index1 == 121 || index1 == 122) || index1 == 140))
                Main.PlaySound(21, i * 16, j * 16, 1);
              else if (index1 != 138)
              {
                Main.PlaySound(0, i * 16, j * 16, 1);
                if (index1 == 129)
                  Main.PlaySound(2, i * 16, j * 16, 27);
              }
            }
            if (index1 != 138)
            {
              if (index1 == 128)
              {
                int index2 = i;
                int num1 = (int) tilePtr1->frameX;
                if ((int) tilePtr1->frameX % 100 % 36 == 18)
                {
                  num1 = (int) tilePtr1[-1440].frameX;
                  --index2;
                }
                if (num1 >= 100)
                {
                  int index3 = num1 / 100;
                  int num2 = num1 % 100;
                  switch ((int) Main.tile[index2, j].frameY / 18)
                  {
                    case 0:
                      Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.headType[index3], 1, false, 0);
                      break;
                    case 1:
                      Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.bodyType[index3], 1, false, 0);
                      break;
                    case 2:
                      Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.legType[index3], 1, false, 0);
                      break;
                  }
                  int num3 = (int) Main.tile[index2, j].frameX % 100;
                  Main.tile[index2, j].frameX = (short) num3;
                }
              }
              if (!WorldGen.gen)
              {
                int Type = 0;
                if (index1 != 0)
                {
                  if (index1 == 1 || index1 == 16 || (index1 == 17 || index1 == 38) || (index1 == 39 || index1 == 41 || (index1 == 43 || index1 == 44)) || (index1 == 48 || index1 == 85 || (index1 == 90 || index1 == 92) || (index1 == 96 || index1 == 97 || (index1 == 99 || index1 == 105))) || (index1 == 117 || index1 == 130 || (index1 == 131 || index1 == 132) || (index1 == 135 || index1 == 137 || (index1 == 142 || index1 == 143)) || (index1 == 144 || Main.tileStone[index1])))
                    Type = 1;
                  else if (index1 == 33 || index1 == 95 || (index1 == 98 || index1 == 100))
                    Type = 6;
                  else if (index1 == 5 || index1 == 10 || (index1 == 11 || index1 == 14) || (index1 == 15 || index1 == 19 || (index1 == 30 || index1 == 86)) || (index1 == 87 || index1 == 88 || (index1 == 89 || index1 == 93) || (index1 == 94 || index1 == 104 || (index1 == 106 || index1 == 114))) || (index1 == 124 || index1 == 128 || index1 == 139))
                    Type = 7;
                  else if (index1 == 21)
                    Type = (int) tilePtr1->frameX < 108 ? ((int) tilePtr1->frameX < 36 ? 7 : 10) : 37;
                  else if (index1 == (int) sbyte.MaxValue)
                    Type = 67;
                  else if (index1 == 91)
                    Type = -1;
                  else if (index1 == 6 || index1 == 26)
                    Type = 8;
                  else if (index1 == 7 || index1 == 34 || index1 == 47)
                    Type = 9;
                  else if (index1 == 8 || index1 == 36 || (index1 == 45 || index1 == 102))
                    Type = 10;
                  else if (index1 == 9 || index1 == 35 || (index1 == 42 || index1 == 46) || (index1 == 126 || index1 == 136))
                    Type = 11;
                  else if (index1 == 12)
                    Type = 12;
                  else if (index1 == 3 || index1 == 73)
                    Type = 3;
                  else if (index1 == 13 || index1 == 54)
                    Type = 13;
                  else if (index1 == 22 || index1 == 140)
                    Type = 14;
                  else if (index1 == 28 || index1 == 78)
                    Type = 22;
                  else if (index1 == 29)
                    Type = 23;
                  else if (index1 == 40 || index1 == 103)
                    Type = 28;
                  else if (index1 == 49)
                    Type = 29;
                  else if (index1 == 50)
                    Type = 22;
                  else if (index1 == 51)
                    Type = 30;
                  else if (index1 == 52)
                    Type = 3;
                  else if (index1 == 53 || index1 == 81)
                    Type = 32;
                  else if (index1 == 56 || index1 == 75)
                    Type = 37;
                  else if (index1 == 57 || index1 == 119 || index1 == 141)
                    Type = 36;
                  else if (index1 == 59 || index1 == 120)
                    Type = 38;
                  else if (index1 == 61 || index1 == 62 || (index1 == 74 || index1 == 80))
                    Type = 40;
                  else if (index1 == 69)
                    Type = 7;
                  else if (index1 == 71 || index1 == 72)
                    Type = 26;
                  else if (index1 == 70)
                    Type = 17;
                  else if (index1 == 112)
                    Type = 14;
                  else if (index1 == 123)
                    Type = 53;
                  else if (index1 == 116 || index1 == 118 || (index1 == 147 || index1 == 148))
                    Type = 51;
                  else if (index1 == 110 || index1 == 113 || index1 == 115)
                    Type = 47;
                  else if (index1 == 107 || index1 == 121)
                    Type = 48;
                  else if (index1 == 108 || index1 == 122 || (index1 == 134 || index1 == 146))
                    Type = 49;
                  else if (index1 == 111 || index1 == 133 || index1 == 145)
                    Type = 50;
                  else if (index1 == 149)
                    Type = 49;
                  else if (index1 >= 82 && index1 <= 84)
                  {
                    switch ((int) tilePtr1->frameX / 18)
                    {
                      case 0:
                        Type = 3;
                        break;
                      case 1:
                        Type = 3;
                        break;
                      case 2:
                        Type = 7;
                        break;
                      case 3:
                        Type = 17;
                        break;
                      case 4:
                        Type = 3;
                        break;
                      case 5:
                        Type = 6;
                        break;
                    }
                  }
                  else if (index1 == 129)
                    Type = (int) tilePtr1->frameX == 0 || (int) tilePtr1->frameX == 54 || (int) tilePtr1->frameX == 108 ? 68 : ((int) tilePtr1->frameX == 18 || (int) tilePtr1->frameX == 72 || (int) tilePtr1->frameX == 126 ? 69 : 70);
                  else if (index1 == 4)
                  {
                    int num = (int) tilePtr1->frameY / 22;
                    switch (num)
                    {
                      case 0:
                        Type = 6;
                        break;
                      case 8:
                        Type = 75;
                        break;
                      default:
                        Type = 58 + num;
                        break;
                    }
                  }
                }
                if (Type >= 0)
                {
                  for (int index2 = 4; index2 >= 0; --index2)
                  {
                    switch (index1)
                    {
                      case 61:
                        Type = 38 + WorldGen.genRand.Next(2);
                        break;
                      case 76:
                      case 77:
                      case 58:
                        Type = WorldGen.genRand.Next(2) == 0 ? 6 : 25;
                        break;
                      case 109:
                        Type = WorldGen.genRand.Next(2) * 47;
                        break;
                      case 2:
                        Type = WorldGen.genRand.Next(2) << 1;
                        break;
                      case 20:
                        Type = WorldGen.genRand.Next(2) == 0 ? 7 : 2;
                        break;
                      case 23:
                      case 24:
                        Type = WorldGen.genRand.Next(2) == 0 ? 14 : 17;
                        break;
                      case 25:
                      case 31:
                        Type = WorldGen.genRand.Next(2) == 0 ? 14 : 1;
                        break;
                      case 27:
                        Type = WorldGen.genRand.Next(2) == 0 ? 3 : 19;
                        break;
                      case 32:
                        Type = WorldGen.genRand.Next(2) == 0 ? 14 : 24;
                        break;
                      case 34:
                      case 35:
                      case 36:
                      case 42:
                        Type = WorldGen.genRand.Next(2) * 6;
                        break;
                      case 37:
                        Type = WorldGen.genRand.Next(2) == 0 ? 6 : 23;
                        break;
                    }
                    Main.dust.NewDust(i * 16, j * 16, 16, 16, Type, 0.0, 0.0, 0, new Color(), 1.0);
                  }
                }
              }
            }
            if (index1 == 21 && Main.netMode != 1)
            {
              int num = (int) tilePtr1->frameX / 18;
              int Y = j - (int) tilePtr1->frameY / 18;
              if (!Chest.DestroyChest(i - (num & 1), Y))
                return false;
            }
            if (!WorldGen.gen && !WorldGen.stopDrops && Main.netMode != 1)
            {
              int Type = 0;
              if (index1 == 0 || index1 == 2 || index1 == 109)
                Type = 2;
              else if (index1 == 1)
                Type = 3;
              else if (index1 == 3 || index1 == 73)
              {
                if (Main.rand.Next(2) == 0)
                {
                  Rectangle rect = new Rectangle();
                  rect.X = i << 4;
                  rect.Y = j << 4;
                  rect.Width = rect.Height = 16;
                  if (Player.FindClosest(ref rect).HasItem(281))
                    Type = 283;
                }
              }
              else if (index1 == 4)
              {
                int num = (int) tilePtr1->frameY / 22;
                switch (num)
                {
                  case 0:
                    Type = 8;
                    break;
                  case 8:
                    Type = 523;
                    break;
                  default:
                    Type = 426 + num;
                    break;
                }
              }
              else if (index1 == 5)
              {
                if ((int) tilePtr1->frameX >= 22 && (int) tilePtr1->frameY >= 198)
                {
                  if (Main.netMode != 1)
                  {
                    Type = 9;
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                      int index2 = j - 1;
                      int index3;
                      do
                      {
                        index3 = (int) Main.tile[i, ++index2].type;
                      }
                      while (!Main.tileSolidNotSolidTop[index3] || (int) Main.tile[i, index2].active == 0);
                      if (index3 == 2 || index3 == 109)
                        Type = 27;
                    }
                  }
                }
                else
                  Type = 9;
                ++WorldGen.woodSpawned;
              }
              else if (index1 == 6)
                Type = 11;
              else if (index1 == 7)
                Type = 12;
              else if (index1 == 8)
                Type = 13;
              else if (index1 == 9)
                Type = 14;
              else if (index1 == 123)
                Type = 424;
              else if (index1 == 124)
                Type = 480;
              else if (index1 == 149)
              {
                if ((int) tilePtr1->frameX == 0 || (int) tilePtr1->frameX == 54)
                  Type = 596;
                else if ((int) tilePtr1->frameX == 18 || (int) tilePtr1->frameX == 72)
                  Type = 597;
                else if ((int) tilePtr1->frameX == 36 || (int) tilePtr1->frameX == 90)
                  Type = 598;
              }
              else if (index1 == 13)
              {
                Main.PlaySound(13, i * 16, j * 16, 1);
                Type = (int) tilePtr1->frameX != 18 ? ((int) tilePtr1->frameX != 36 ? ((int) tilePtr1->frameX != 54 ? ((int) tilePtr1->frameX != 72 ? 31 : 351) : 350) : 110) : 28;
              }
              else if (index1 == 19)
                Type = 94;
              else if (index1 == 22)
                Type = 56;
              else if (index1 == 140)
                Type = 577;
              else if (index1 == 23)
                Type = 2;
              else if (index1 == 25)
                Type = 61;
              else if (index1 == 30)
                Type = 9;
              else if (index1 == 33)
                Type = 105;
              else if (index1 == 37)
                Type = 116;
              else if (index1 == 38)
                Type = 129;
              else if (index1 == 39)
                Type = 131;
              else if (index1 == 40)
                Type = 133;
              else if (index1 == 41)
                Type = 134;
              else if (index1 == 43)
                Type = 137;
              else if (index1 == 44)
                Type = 139;
              else if (index1 == 45)
                Type = 141;
              else if (index1 == 46)
                Type = 143;
              else if (index1 == 47)
                Type = 145;
              else if (index1 == 48)
                Type = 147;
              else if (index1 == 49)
                Type = 148;
              else if (index1 == 51)
                Type = 150;
              else if (index1 == 53)
                Type = 169;
              else if (index1 == 54)
              {
                Type = 170;
                Main.PlaySound(13, i * 16, j * 16, 1);
              }
              else if (index1 == 56)
                Type = 173;
              else if (index1 == 57)
                Type = 172;
              else if (index1 == 58)
                Type = 174;
              else if (index1 == 60)
                Type = 176;
              else if (index1 == 70)
                Type = 176;
              else if (index1 == 75)
                Type = 192;
              else if (index1 == 76)
                Type = 214;
              else if (index1 == 78)
                Type = 222;
              else if (index1 == 81)
                Type = 275;
              else if (index1 == 80)
                Type = 276;
              else if (index1 == 107)
                Type = 364;
              else if (index1 == 108)
                Type = 365;
              else if (index1 == 111)
                Type = 366;
              else if (index1 == 112)
                Type = 370;
              else if (index1 == 116)
                Type = 408;
              else if (index1 == 117)
                Type = 409;
              else if (index1 == 118)
                Type = 412;
              else if (index1 == 119)
                Type = 413;
              else if (index1 == 120)
                Type = 414;
              else if (index1 == 121)
                Type = 415;
              else if (index1 == 122)
                Type = 416;
              else if (index1 == 129)
                Type = 502;
              else if (index1 == 130)
                Type = 511;
              else if (index1 == 131)
                Type = 512;
              else if (index1 == 136)
                Type = 538;
              else if (index1 == 137)
                Type = 539;
              else if (index1 == 141)
                Type = 580;
              else if (index1 == 145)
                Type = 586;
              else if (index1 == 146)
                Type = 591;
              else if (index1 == 147)
                Type = 593;
              else if (index1 == 148)
                Type = 594;
              else if (index1 == 135)
              {
                if ((int) tilePtr1->frameY == 0)
                  Type = 529;
                else if ((int) tilePtr1->frameY == 18)
                  Type = 541;
                else if ((int) tilePtr1->frameY == 36)
                  Type = 542;
                else if ((int) tilePtr1->frameY == 54)
                  Type = 543;
              }
              else if (index1 == 144)
              {
                if ((int) tilePtr1->frameX == 0)
                  Type = 583;
                else if ((int) tilePtr1->frameX == 18)
                  Type = 584;
                else if ((int) tilePtr1->frameX == 36)
                  Type = 585;
              }
              else if (index1 == 61 || index1 == 74)
              {
                if ((int) tilePtr1->frameX == 144)
                  Item.NewItem(i * 16, j * 16, 16, 16, 331, WorldGen.genRand.Next(2, 4), false, 0);
                else if ((int) tilePtr1->frameX == 162)
                  Type = 223;
                else if ((int) tilePtr1->frameX >= 108 && (int) tilePtr1->frameX <= 126 && WorldGen.genRand.Next(100) == 0)
                  Type = 208;
                else if (WorldGen.genRand.Next(100) == 0)
                  Type = 195;
              }
              else if (index1 == 59 || index1 == 60)
                Type = 176;
              else if (index1 == 71 || index1 == 72)
              {
                int num = WorldGen.genRand.Next(50);
                if (num < 25)
                  Type = num != 0 ? 183 : 194;
              }
              else if ((int) tilePtr1->type >= 63 && (int) tilePtr1->type <= 68)
                Type = (int) tilePtr1->type - 63 + 177;
              else if (index1 == 50)
                Type = (int) tilePtr1->frameX != 90 ? 149 : 165;
              else if (index1 == 83 || index1 == 84)
              {
                int num = (int) tilePtr1->frameX / 18;
                bool flag = index1 == 84;
                if (!flag)
                {
                  if (num == 0 && Main.gameTime.dayTime)
                    flag = true;
                  else if (num == 1 && !Main.gameTime.dayTime)
                    flag = true;
                  else if (num == 3 && Main.gameTime.bloodMoon)
                    flag = true;
                }
                if (flag)
                  Item.NewItem(i * 16, j * 16, 16, 16, 307 + num, WorldGen.genRand.Next(1, 4), false, 0);
                Type = 313 + num;
              }
              if (Type > 0)
                Item.NewItem(i * 16, j * 16, 16, 16, Type, 1, false, -1);
            }
            tilePtr1->active = (byte) 0;
            tilePtr1->type = (byte) 0;
            tilePtr1->frameX = (short) -1;
            tilePtr1->frameY = (short) -1;
            tilePtr1->frameNumber = (byte) 0;
            if (index1 == 58 && j > (int) Main.maxTilesY - 200)
            {
              tilePtr1->lava = (byte) 32;
              tilePtr1->liquid = (byte) sbyte.MinValue;
            }
            WorldGen.SquareTileFrame(i, j, -1);
            return true;
          }
          else
          {
            // ISSUE: __unpin statement
            __unpin(tilePtr1);
          }
        }
      }
      return false;
    }

    public static unsafe void KillTile(int i, int j, bool fail, bool effectOnly = false, bool noItem = false)
    {
      if (i < 0 || j < 0 || (i >= (int) Main.maxTilesX || j >= (int) Main.maxTilesY))
        return;
      fixed (Tile* tilePtr1 = &Main.tile[i, j])
      {
        if ((int) tilePtr1->active != 0)
        {
          int index1 = (int) tilePtr1->type;
          if (j >= 1)
          {
            Tile* tilePtr2 = tilePtr1 - 1;
            if ((int) tilePtr2->active != 0)
            {
              int num = (int) tilePtr2->type;
              switch (num)
              {
                case 21:
                case 26:
                case 72:
                case 12:
                  if (index1 != num)
                    return;
                  else
                    break;
                case 5:
                  if (index1 != num && ((int) tilePtr1[-1].frameX != 66 || (int) tilePtr1[-1].frameY < 0 || (int) tilePtr1[-1].frameY > 44) && (((int) tilePtr1[-1].frameX != 88 || (int) tilePtr1[-1].frameY < 66 || (int) tilePtr1[-1].frameY > 110) && (int) tilePtr1[-1].frameY < 198))
                    return;
                  else
                    break;
              }
            }
          }
          if (!WorldGen.gen && !effectOnly && !WorldGen.stopDrops)
          {
            if (index1 == (int) sbyte.MaxValue)
              Main.PlaySound(2, i * 16, j * 16, 27);
            else if (index1 == 3 || index1 == 110)
            {
              Main.PlaySound(6, i * 16, j * 16, 1);
              if ((int) tilePtr1->frameX == 144)
                Item.NewItem(i * 16, j * 16, 16, 16, 5, 1, false, 0);
            }
            else if (index1 == 24)
            {
              Main.PlaySound(6, i * 16, j * 16, 1);
              if ((int) tilePtr1->frameX == 144)
                Item.NewItem(i * 16, j * 16, 16, 16, 60, 1, false, 0);
            }
            else if (index1 == 32 || index1 == 51 || (index1 == 52 || index1 == 61) || (index1 == 62 || index1 == 69 || (index1 == 71 || index1 == 73)) || (index1 == 74 || index1 >= 82 && index1 <= 84 || (index1 == 113 || index1 == 115)))
              Main.PlaySound(6, i * 16, j * 16, 1);
            else if (index1 == 1 || index1 == 6 || (index1 == 7 || index1 == 8) || (index1 == 9 || index1 == 22 || (index1 == 25 || index1 == 37)) || (index1 == 38 || index1 == 39 || (index1 == 41 || index1 == 43) || (index1 == 44 || index1 == 45 || (index1 == 46 || index1 == 47))) || (index1 == 48 || index1 == 56 || (index1 == 58 || index1 == 63) || (index1 == 64 || index1 == 65 || (index1 == 66 || index1 == 67)) || (index1 == 68 || index1 == 75 || (index1 == 76 || index1 == 107) || (index1 == 108 || index1 == 111 || (index1 == 117 || index1 == 118)))) || (index1 == 119 || index1 == 120 || (index1 == 121 || index1 == 122) || index1 == 140))
              Main.PlaySound(21, i * 16, j * 16, 1);
            else if (index1 != 138)
            {
              Main.PlaySound(0, i * 16, j * 16, 1);
              if (index1 == 129 && !fail)
                Main.PlaySound(2, i * 16, j * 16, 27);
            }
          }
          if (index1 != 138)
          {
            if (index1 == 128)
            {
              int index2 = i;
              int num1 = (int) tilePtr1->frameX;
              if ((int) tilePtr1->frameX % 100 % 36 == 18)
              {
                num1 = (int) tilePtr1[-1440].frameX;
                --index2;
              }
              if (num1 >= 100)
              {
                int index3 = num1 / 100;
                int num2 = num1 % 100;
                switch ((int) Main.tile[index2, j].frameY / 18)
                {
                  case 0:
                    Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.headType[index3], 1, false, 0);
                    break;
                  case 1:
                    Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.bodyType[index3], 1, false, 0);
                    break;
                  case 2:
                    Item.NewItem(i * 16, j * 16, 16, 16, (int) Item.legType[index3], 1, false, 0);
                    break;
                }
                int num3 = (int) Main.tile[index2, j].frameX % 100;
                Main.tile[index2, j].frameX = (short) num3;
              }
            }
            if (!WorldGen.gen)
            {
              int Type = 0;
              if (index1 != 0)
              {
                if (index1 == 1 || index1 == 16 || (index1 == 17 || index1 == 38) || (index1 == 39 || index1 == 41 || (index1 == 43 || index1 == 44)) || (index1 == 48 || index1 == 85 || (index1 == 90 || index1 == 92) || (index1 == 96 || index1 == 97 || (index1 == 99 || index1 == 105))) || (index1 == 117 || index1 == 130 || (index1 == 131 || index1 == 132) || (index1 == 135 || index1 == 137 || (index1 == 142 || index1 == 143)) || (index1 == 144 || Main.tileStone[index1])))
                  Type = 1;
                else if (index1 == 33 || index1 == 95 || (index1 == 98 || index1 == 100))
                  Type = 6;
                else if (index1 == 5 || index1 == 10 || (index1 == 11 || index1 == 14) || (index1 == 15 || index1 == 19 || (index1 == 30 || index1 == 86)) || (index1 == 87 || index1 == 88 || (index1 == 89 || index1 == 93) || (index1 == 94 || index1 == 104 || (index1 == 106 || index1 == 114))) || (index1 == 124 || index1 == 128 || index1 == 139))
                  Type = 7;
                else if (index1 == 21)
                  Type = (int) tilePtr1->frameX < 108 ? ((int) tilePtr1->frameX < 36 ? 7 : 10) : 37;
                else if (index1 == (int) sbyte.MaxValue)
                  Type = 67;
                else if (index1 == 91)
                  Type = -1;
                else if (index1 == 6 || index1 == 26)
                  Type = 8;
                else if (index1 == 7 || index1 == 34 || index1 == 47)
                  Type = 9;
                else if (index1 == 8 || index1 == 36 || (index1 == 45 || index1 == 102))
                  Type = 10;
                else if (index1 == 9 || index1 == 35 || (index1 == 42 || index1 == 46) || (index1 == 126 || index1 == 136))
                  Type = 11;
                else if (index1 == 12)
                  Type = 12;
                else if (index1 == 3 || index1 == 73)
                  Type = 3;
                else if (index1 == 13 || index1 == 54)
                  Type = 13;
                else if (index1 == 22 || index1 == 140)
                  Type = 14;
                else if (index1 == 28 || index1 == 78)
                  Type = 22;
                else if (index1 == 29)
                  Type = 23;
                else if (index1 == 40 || index1 == 103)
                  Type = 28;
                else if (index1 == 49)
                  Type = 29;
                else if (index1 == 50)
                  Type = 22;
                else if (index1 == 51)
                  Type = 30;
                else if (index1 == 52)
                  Type = 3;
                else if (index1 == 53 || index1 == 81)
                  Type = 32;
                else if (index1 == 56 || index1 == 75)
                  Type = 37;
                else if (index1 == 57 || index1 == 119 || index1 == 141)
                  Type = 36;
                else if (index1 == 59 || index1 == 120)
                  Type = 38;
                else if (index1 == 61 || index1 == 62 || (index1 == 74 || index1 == 80))
                  Type = 40;
                else if (index1 == 69)
                  Type = 7;
                else if (index1 == 71 || index1 == 72)
                  Type = 26;
                else if (index1 == 70)
                  Type = 17;
                else if (index1 == 112)
                  Type = 14;
                else if (index1 == 123)
                  Type = 53;
                else if (index1 == 116 || index1 == 118 || (index1 == 147 || index1 == 148))
                  Type = 51;
                else if (index1 == 110 || index1 == 113 || index1 == 115)
                  Type = 47;
                else if (index1 == 107 || index1 == 121)
                  Type = 48;
                else if (index1 == 108 || index1 == 122 || (index1 == 134 || index1 == 146))
                  Type = 49;
                else if (index1 == 111 || index1 == 133 || index1 == 145)
                  Type = 50;
                else if (index1 == 149)
                  Type = 49;
                else if (index1 >= 82 && index1 <= 84)
                {
                  switch ((int) tilePtr1->frameX / 18)
                  {
                    case 0:
                      Type = 3;
                      break;
                    case 1:
                      Type = 3;
                      break;
                    case 2:
                      Type = 7;
                      break;
                    case 3:
                      Type = 17;
                      break;
                    case 4:
                      Type = 3;
                      break;
                    case 5:
                      Type = 6;
                      break;
                  }
                }
                else if (index1 == 129)
                  Type = (int) tilePtr1->frameX == 0 || (int) tilePtr1->frameX == 54 || (int) tilePtr1->frameX == 108 ? 68 : ((int) tilePtr1->frameX == 18 || (int) tilePtr1->frameX == 72 || (int) tilePtr1->frameX == 126 ? 69 : 70);
                else if (index1 == 4)
                {
                  int num = (int) tilePtr1->frameY / 22;
                  switch (num)
                  {
                    case 0:
                      Type = 6;
                      break;
                    case 8:
                      Type = 75;
                      break;
                    default:
                      Type = 58 + num;
                      break;
                  }
                }
              }
              if (Type >= 0)
              {
                for (int index2 = fail ? 1 : 4; index2 >= 0; --index2)
                {
                  switch (index1)
                  {
                    case 61:
                      Type = 38 + WorldGen.genRand.Next(2);
                      break;
                    case 76:
                    case 77:
                    case 58:
                      Type = WorldGen.genRand.Next(2) == 0 ? 6 : 25;
                      break;
                    case 109:
                      Type = WorldGen.genRand.Next(2) * 47;
                      break;
                    case 2:
                      Type = WorldGen.genRand.Next(2) << 1;
                      break;
                    case 20:
                      Type = WorldGen.genRand.Next(2) == 0 ? 7 : 2;
                      break;
                    case 23:
                    case 24:
                      Type = WorldGen.genRand.Next(2) == 0 ? 14 : 17;
                      break;
                    case 25:
                    case 31:
                      Type = WorldGen.genRand.Next(2) == 0 ? 14 : 1;
                      break;
                    case 27:
                      Type = WorldGen.genRand.Next(2) == 0 ? 3 : 19;
                      break;
                    case 32:
                      Type = WorldGen.genRand.Next(2) == 0 ? 14 : 24;
                      break;
                    case 34:
                    case 35:
                    case 36:
                    case 42:
                      Type = WorldGen.genRand.Next(2) * 6;
                      break;
                    case 37:
                      Type = WorldGen.genRand.Next(2) == 0 ? 6 : 23;
                      break;
                  }
                  Main.dust.NewDust(i * 16, j * 16, 16, 16, Type, 0.0, 0.0, 0, new Color(), 1.0);
                }
              }
            }
          }
          if (effectOnly)
            return;
          if (fail)
          {
            if (index1 == 2 || index1 == 23 || index1 == 109)
              tilePtr1->type = (byte) 0;
            else if (index1 == 60 || index1 == 70)
              tilePtr1->type = (byte) 59;
            WorldGen.SquareTileFrame(i, j, -1);
          }
          else
          {
            if (index1 == 21 && Main.netMode != 1)
            {
              int num = (int) tilePtr1->frameX / 18;
              int Y = j - (int) tilePtr1->frameY / 18;
              if (!Chest.DestroyChest(i - (num & 1), Y))
                return;
            }
            if (!noItem && !WorldGen.stopDrops && (Main.netMode != 1 && !WorldGen.gen))
            {
              int Type = 0;
              if (index1 == 0 || index1 == 2 || index1 == 109)
                Type = 2;
              else if (index1 == 1)
                Type = 3;
              else if (index1 == 3 || index1 == 73)
              {
                if (Main.rand.Next(2) == 0)
                {
                  Rectangle rect = new Rectangle();
                  rect.X = i << 4;
                  rect.Y = j << 4;
                  rect.Width = rect.Height = 16;
                  if (Player.FindClosest(ref rect).HasItem(281))
                    Type = 283;
                }
              }
              else if (index1 == 4)
              {
                int num = (int) tilePtr1->frameY / 22;
                switch (num)
                {
                  case 0:
                    Type = 8;
                    break;
                  case 8:
                    Type = 523;
                    break;
                  default:
                    Type = 426 + num;
                    break;
                }
              }
              else if (index1 == 5)
              {
                if ((int) tilePtr1->frameX >= 22 && (int) tilePtr1->frameY >= 198)
                {
                  if (Main.netMode != 1)
                  {
                    Type = 9;
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                      int index2 = j - 1;
                      int index3;
                      do
                      {
                        index3 = (int) Main.tile[i, ++index2].type;
                      }
                      while (!Main.tileSolidNotSolidTop[index3] || (int) Main.tile[i, index2].active == 0);
                      if (index3 == 2 || index3 == 109)
                        Type = 27;
                    }
                  }
                }
                else
                  Type = 9;
                ++WorldGen.woodSpawned;
              }
              else if (index1 == 6)
                Type = 11;
              else if (index1 == 7)
                Type = 12;
              else if (index1 == 8)
                Type = 13;
              else if (index1 == 9)
                Type = 14;
              else if (index1 == 123)
                Type = 424;
              else if (index1 == 124)
                Type = 480;
              else if (index1 == 149)
              {
                if ((int) tilePtr1->frameX == 0 || (int) tilePtr1->frameX == 54)
                  Type = 596;
                else if ((int) tilePtr1->frameX == 18 || (int) tilePtr1->frameX == 72)
                  Type = 597;
                else if ((int) tilePtr1->frameX == 36 || (int) tilePtr1->frameX == 90)
                  Type = 598;
              }
              else if (index1 == 13)
              {
                Main.PlaySound(13, i * 16, j * 16, 1);
                Type = (int) tilePtr1->frameX != 18 ? ((int) tilePtr1->frameX != 36 ? ((int) tilePtr1->frameX != 54 ? ((int) tilePtr1->frameX != 72 ? 31 : 351) : 350) : 110) : 28;
              }
              else if (index1 == 19)
                Type = 94;
              else if (index1 == 22)
                Type = 56;
              else if (index1 == 140)
                Type = 577;
              else if (index1 == 23)
                Type = 2;
              else if (index1 == 25)
                Type = 61;
              else if (index1 == 30)
                Type = 9;
              else if (index1 == 33)
                Type = 105;
              else if (index1 == 37)
                Type = 116;
              else if (index1 == 38)
                Type = 129;
              else if (index1 == 39)
                Type = 131;
              else if (index1 == 40)
                Type = 133;
              else if (index1 == 41)
                Type = 134;
              else if (index1 == 43)
                Type = 137;
              else if (index1 == 44)
                Type = 139;
              else if (index1 == 45)
                Type = 141;
              else if (index1 == 46)
                Type = 143;
              else if (index1 == 47)
                Type = 145;
              else if (index1 == 48)
                Type = 147;
              else if (index1 == 49)
                Type = 148;
              else if (index1 == 51)
                Type = 150;
              else if (index1 == 53)
                Type = 169;
              else if (index1 == 54)
              {
                Type = 170;
                Main.PlaySound(13, i * 16, j * 16, 1);
              }
              else if (index1 == 56)
                Type = 173;
              else if (index1 == 57)
                Type = 172;
              else if (index1 == 58)
                Type = 174;
              else if (index1 == 60)
                Type = 176;
              else if (index1 == 70)
                Type = 176;
              else if (index1 == 75)
                Type = 192;
              else if (index1 == 76)
                Type = 214;
              else if (index1 == 78)
                Type = 222;
              else if (index1 == 81)
                Type = 275;
              else if (index1 == 80)
                Type = 276;
              else if (index1 == 107)
                Type = 364;
              else if (index1 == 108)
                Type = 365;
              else if (index1 == 111)
                Type = 366;
              else if (index1 == 112)
                Type = 370;
              else if (index1 == 116)
                Type = 408;
              else if (index1 == 117)
                Type = 409;
              else if (index1 == 118)
                Type = 412;
              else if (index1 == 119)
                Type = 413;
              else if (index1 == 120)
                Type = 414;
              else if (index1 == 121)
                Type = 415;
              else if (index1 == 122)
                Type = 416;
              else if (index1 == 129)
                Type = 502;
              else if (index1 == 130)
                Type = 511;
              else if (index1 == 131)
                Type = 512;
              else if (index1 == 136)
                Type = 538;
              else if (index1 == 137)
                Type = 539;
              else if (index1 == 141)
                Type = 580;
              else if (index1 == 145)
                Type = 586;
              else if (index1 == 146)
                Type = 591;
              else if (index1 == 147)
                Type = 593;
              else if (index1 == 148)
                Type = 594;
              else if (index1 == 135)
              {
                if ((int) tilePtr1->frameY == 0)
                  Type = 529;
                else if ((int) tilePtr1->frameY == 18)
                  Type = 541;
                else if ((int) tilePtr1->frameY == 36)
                  Type = 542;
                else if ((int) tilePtr1->frameY == 54)
                  Type = 543;
              }
              else if (index1 == 144)
              {
                if ((int) tilePtr1->frameX == 0)
                  Type = 583;
                else if ((int) tilePtr1->frameX == 18)
                  Type = 584;
                else if ((int) tilePtr1->frameX == 36)
                  Type = 585;
              }
              else if (index1 == 61 || index1 == 74)
              {
                if ((int) tilePtr1->frameX == 144)
                  Item.NewItem(i * 16, j * 16, 16, 16, 331, WorldGen.genRand.Next(2, 4), false, 0);
                else if ((int) tilePtr1->frameX == 162)
                  Type = 223;
                else if ((int) tilePtr1->frameX >= 108 && (int) tilePtr1->frameX <= 126 && WorldGen.genRand.Next(100) == 0)
                  Type = 208;
                else if (WorldGen.genRand.Next(100) == 0)
                  Type = 195;
              }
              else if (index1 == 59 || index1 == 60)
                Type = 176;
              else if (index1 == 71 || index1 == 72)
              {
                int num = WorldGen.genRand.Next(50);
                if (num < 25)
                  Type = num != 0 ? 183 : 194;
              }
              else if ((int) tilePtr1->type >= 63 && (int) tilePtr1->type <= 68)
                Type = (int) tilePtr1->type - 63 + 177;
              else if (index1 == 50)
                Type = (int) tilePtr1->frameX != 90 ? 149 : 165;
              else if (index1 == 83 || index1 == 84)
              {
                int num = (int) tilePtr1->frameX / 18;
                bool flag = index1 == 84;
                if (!flag)
                {
                  if (num == 0 && Main.gameTime.dayTime)
                    flag = true;
                  else if (num == 1 && !Main.gameTime.dayTime)
                    flag = true;
                  else if (num == 3 && Main.gameTime.bloodMoon)
                    flag = true;
                }
                if (flag)
                  Item.NewItem(i * 16, j * 16, 16, 16, 307 + num, WorldGen.genRand.Next(1, 4), false, 0);
                Type = 313 + num;
              }
              if (Type > 0)
                Item.NewItem(i * 16, j * 16, 16, 16, Type, 1, false, -1);
            }
            tilePtr1->active = (byte) 0;
            tilePtr1->type = (byte) 0;
            tilePtr1->frameX = (short) -1;
            tilePtr1->frameY = (short) -1;
            tilePtr1->frameNumber = (byte) 0;
            if (index1 == 58 && j > (int) Main.maxTilesY - 200)
            {
              tilePtr1->lava = (byte) 32;
              tilePtr1->liquid = (byte) sbyte.MinValue;
            }
            WorldGen.SquareTileFrame(i, j, -1);
          }
        }
      }
    }

    public static bool PlayerLOS(int x, int y)
    {
      Rectangle rectangle1 = new Rectangle(x * 16, y * 16, 16, 16);
      Rectangle rectangle2 = new Rectangle();
      bool result = false;
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0)
        {
          rectangle2.X = (int) ((double) Main.player[index].position.X + 10.0 - 1152.0);
          rectangle2.Y = (int) ((double) Main.player[index].position.Y + 21.0 - 648.0);
          rectangle2.Width = 2304;
          rectangle2.Height = 1296;
          rectangle1.Intersects(ref rectangle2, out result);
          if (result)
            break;
        }
      }
      return result;
    }

    public static void hardUpdateWorld(int i, int j)
    {
      int num1 = (int) Main.tile[i, j].type;
      if (num1 == 117 && j > Main.rockLayer && Main.rand.Next(110) == 0)
      {
        int num2 = WorldGen.genRand.Next(4);
        int num3 = 0;
        int num4 = 0;
        if (num2 == 0)
          num3 = -1;
        else if (num2 == 1)
          num3 = 1;
        else
          num4 = num2 != 0 ? 1 : -1;
        if ((int) Main.tile[i + num3, j + num4].active == 0)
        {
          int num5 = 0;
          int num6 = 6;
          for (int index1 = i - num6; index1 <= i + num6; ++index1)
          {
            for (int index2 = j - num6; index2 <= j + num6; ++index2)
            {
              if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type == 129)
                ++num5;
            }
          }
          if (num5 < 2)
          {
            WorldGen.PlaceTile(i + num3, j + num4, 129, true, false, -1, 0);
            NetMessage.SendTile(i + num3, j + num4);
          }
        }
      }
      else if (num1 == 23 || num1 == 25 || (num1 == 32 || num1 == 112))
      {
        do
        {
          int index1 = i + WorldGen.genRand.Next(-3, 4);
          int index2 = j + WorldGen.genRand.Next(-3, 4);
          if ((int) Main.tile[index1, index2].type == 2)
          {
            Main.tile[index1, index2].type = (byte) 23;
            WorldGen.SquareTileFrame(index1, index2, -1);
            NetMessage.SendTile(index1, index2);
            if (WorldGen.genRand.Next(2) != 0)
              goto label_41;
          }
          else if ((int) Main.tile[index1, index2].type == 1)
          {
            Main.tile[index1, index2].type = (byte) 25;
            WorldGen.SquareTileFrame(index1, index2, -1);
            NetMessage.SendTile(index1, index2);
            if (WorldGen.genRand.Next(2) != 0)
              goto label_39;
          }
          else if ((int) Main.tile[index1, index2].type == 53)
          {
            Main.tile[index1, index2].type = (byte) 112;
            WorldGen.SquareTileFrame(index1, index2, -1);
            NetMessage.SendTile(index1, index2);
            if (WorldGen.genRand.Next(2) != 0)
              goto label_32;
          }
          else if ((int) Main.tile[index1, index2].type == 59)
          {
            Main.tile[index1, index2].type = (byte) 0;
            WorldGen.SquareTileFrame(index1, index2, -1);
            NetMessage.SendTile(index1, index2);
            if (WorldGen.genRand.Next(2) != 0)
              goto label_29;
          }
          else if ((int) Main.tile[index1, index2].type == 60)
          {
            Main.tile[index1, index2].type = (byte) 23;
            WorldGen.SquareTileFrame(index1, index2, -1);
            NetMessage.SendTile(index1, index2);
            if (WorldGen.genRand.Next(2) != 0)
              goto label_26;
          }
          else if ((int) Main.tile[index1, index2].type == 69)
          {
            Main.tile[index1, index2].type = (byte) 32;
            WorldGen.SquareTileFrame(index1, index2, -1);
            NetMessage.SendTile(index1, index2);
          }
          else
            goto label_23;
        }
        while (WorldGen.genRand.Next(2) == 0);
        goto label_20;
label_41:
        return;
label_39:
        return;
label_32:
        return;
label_29:
        return;
label_26:
        return;
label_23:
        return;
label_20:
        return;
      }
      if (num1 != 109 && num1 != 110 && (num1 != 113 && num1 != 115) && (num1 != 116 && num1 != 117 && num1 != 118))
        return;
      do
      {
        int index1;
        int index2;
        do
        {
          do
          {
            index1 = i + WorldGen.genRand.Next(-3, 4);
            index2 = j + WorldGen.genRand.Next(-3, 4);
            switch (Main.tile[index1, index2].type)
            {
              case (byte) 2:
                Main.tile[index1, index2].type = (byte) 109;
                WorldGen.SquareTileFrame(index1, index2, -1);
                NetMessage.SendTile(index1, index2);
                continue;
              case (byte) 1:
                goto label_40;
              case (byte) 53:
                goto label_42;
              default:
                goto label_45;
            }
          }
          while (WorldGen.genRand.Next(2) == 0);
          goto label_43;
label_40:
          Main.tile[index1, index2].type = (byte) 117;
          WorldGen.SquareTileFrame(index1, index2, -1);
          NetMessage.SendTile(index1, index2);
        }
        while (WorldGen.genRand.Next(2) == 0);
        goto label_44;
label_42:
        Main.tile[index1, index2].type = (byte) 116;
        WorldGen.SquareTileFrame(index1, index2, -1);
        NetMessage.SendTile(index1, index2);
      }
      while (WorldGen.genRand.Next(2) == 0);
      goto label_46;
label_43:
      return;
label_44:
      return;
label_45:
      return;
label_46:;
    }

    public static unsafe bool SolidTile(int i, int j)
    {
      try
      {
        fixed (Tile* tilePtr = &Main.tile[i, j])
          return (int) tilePtr->active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr->type];
      }
      catch
      {
        return false;
      }
    }

    public static unsafe bool SolidTileUnsafe(int i, int j)
    {
      fixed (Tile* tilePtr = &Main.tile[i, j])
        return (int) tilePtr->active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr->type];
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

    public static unsafe void MineHouse(int i, int j)
    {
      if (i < 50 || i > (int) Main.maxTilesX - 50 || (j < 50 || j > (int) Main.maxTilesY - 50) || (WorldGen.SolidTileUnsafe(i, j) || (int) Main.tile[i, j].wall > 0))
        return;
      int num1 = WorldGen.genRand.Next(6, 12);
      int num2 = WorldGen.genRand.Next(3, 6);
      int num3 = WorldGen.genRand.Next(15, 30);
      int num4 = WorldGen.genRand.Next(15, 30);
      int num5 = j - num1;
      int num6 = j + num2;
      for (int index1 = 0; index1 < 2; ++index1)
      {
        int i1 = i;
        int j1 = j;
        int num7 = -1;
        int num8 = num3;
        if (index1 == 1)
        {
          num7 = 1;
          num8 = num4;
          ++i1;
        }
        do
        {
          if (j1 - num1 < num5)
            num5 = j1 - num1;
          if (j1 + num2 > num6)
            num6 = j1 + num2;
          for (int index2 = 0; index2 < 2; ++index2)
          {
            int j2 = j1;
            int num9 = num1;
            int num10 = -1;
            if (index2 == 1)
            {
              ++j2;
              num9 = num2;
              num10 = 1;
            }
            bool flag = true;
            do
            {
              if (i1 != i)
              {
                fixed (Tile* tilePtr = &Main.tile[i1 - num7, j2])
                {
                  if ((int) tilePtr->wall != 27 && ((int) tilePtr->active == 0 || Main.tileSolidNotSolidTop[(int) tilePtr->type]))
                  {
                    tilePtr->active = (byte) 1;
                    tilePtr->type = (byte) 30;
                  }
                }
              }
              if (WorldGen.SolidTileUnsafe(i1 - 1, j2))
                Main.tile[i1 - 1, j2].type = (byte) 30;
              if (WorldGen.SolidTileUnsafe(i1 + 1, j2))
                Main.tile[i1 + 1, j2].type = (byte) 30;
              if (WorldGen.SolidTileUnsafe(i1, j2))
              {
                int num11 = 0;
                if (WorldGen.SolidTileUnsafe(i1 - 1, j2))
                  num11 = 1;
                if (WorldGen.SolidTileUnsafe(i1 + 1, j2))
                  ++num11;
                if (WorldGen.SolidTileUnsafe(i1, j2 - 1))
                  ++num11;
                if (WorldGen.SolidTileUnsafe(i1, j2 + 1))
                  ++num11;
                if (num11 < 2)
                {
                  Main.tile[i1, j2].active = (byte) 0;
                }
                else
                {
                  flag = false;
                  Main.tile[i1, j2].type = (byte) 30;
                }
              }
              else
              {
                Main.tile[i1, j2].wall = (byte) 27;
                Main.tile[i1, j2].liquid = (byte) 0;
                Main.tile[i1, j2].lava = (byte) 0;
              }
              j2 += num10;
              if (--num9 <= 0)
              {
                if ((int) Main.tile[i1, j2].active == 0)
                {
                  Main.tile[i1, j2].active = (byte) 1;
                  Main.tile[i1, j2].type = (byte) 30;
                  break;
                }
                else
                  break;
              }
            }
            while (flag);
          }
          --num8;
          i1 += num7;
          if (WorldGen.SolidTileUnsafe(i1, j1))
          {
            int num9 = 0;
            int num10 = 0;
            int j2 = j1;
            do
            {
              --j2;
              ++num9;
              if (WorldGen.SolidTileUnsafe(i1 - num7, j2))
              {
                num9 = 999;
                break;
              }
            }
            while (WorldGen.SolidTileUnsafe(i1, j2));
            int j3 = j1;
            do
            {
              ++j3;
              ++num10;
              if (WorldGen.SolidTileUnsafe(i1 - num7, j3))
              {
                num10 = 999;
                break;
              }
            }
            while (WorldGen.SolidTileUnsafe(i1, j3));
            if (num10 <= num9)
            {
              if (num10 > num2)
                num8 = 0;
              else
                j1 += num10 + 1;
            }
            else if (num9 > num1)
              num8 = 0;
            else
              j1 -= num9 + 1;
          }
        }
        while (num8 > 0);
      }
      int num12 = i - num3 - 1;
      int num13 = i + num4 + 2;
      int num14 = num5 - 1;
      int num15 = num6 + 2;
      for (int i1 = num12; i1 < num13; ++i1)
      {
        for (int j1 = num14; j1 < num15; ++j1)
        {
          if ((int) Main.tile[i1, j1].wall == 27 && (int) Main.tile[i1, j1].active == 0)
          {
            if ((int) Main.tile[i1 - 1, j1].wall != 27 && i1 < i && !WorldGen.SolidTileUnsafe(i1 - 1, j1))
            {
              WorldGen.PlaceTile(i1, j1, 30, true, false, -1, 0);
              Main.tile[i1, j1].wall = (byte) 0;
            }
            if ((int) Main.tile[i1 + 1, j1].wall != 27 && i1 > i && !WorldGen.SolidTileUnsafe(i1 + 1, j1))
            {
              WorldGen.PlaceTile(i1, j1, 30, true, false, -1, 0);
              Main.tile[i1, j1].wall = (byte) 0;
            }
            for (int i2 = i1 - 1; i2 <= i1 + 1; ++i2)
            {
              for (int j2 = j1 - 1; j2 <= j1 + 1; ++j2)
              {
                if (WorldGen.SolidTileUnsafe(i2, j2))
                  Main.tile[i2, j2].type = (byte) 30;
              }
            }
          }
          if ((int) Main.tile[i1, j1].type == 30 && (int) Main.tile[i1 - 1, j1].wall == 27 && (int) Main.tile[i1 + 1, j1].wall == 27 && (((int) Main.tile[i1, j1 - 1].wall == 27 || (int) Main.tile[i1, j1 - 1].active != 0) && ((int) Main.tile[i1, j1 + 1].wall == 27 || (int) Main.tile[i1, j1 + 1].active != 0)))
          {
            Main.tile[i1, j1].active = (byte) 0;
            Main.tile[i1, j1].wall = (byte) 27;
          }
        }
      }
      for (int index1 = num12; index1 < num13; ++index1)
      {
        for (int index2 = num14; index2 < num15; ++index2)
        {
          if ((int) Main.tile[index1, index2].type == 30)
          {
            if ((int) Main.tile[index1 - 1, index2].wall == 27 && (int) Main.tile[index1 + 1, index2].wall == 27 && ((int) Main.tile[index1 - 1, index2].active == 0 && (int) Main.tile[index1 + 1, index2].active == 0))
            {
              Main.tile[index1, index2].active = (byte) 0;
              Main.tile[index1, index2].wall = (byte) 27;
            }
            if ((int) Main.tile[index1, index2 - 1].type != 21 && (int) Main.tile[index1 - 1, index2].wall == 27 && ((int) Main.tile[index1 + 1, index2].type == 30 && (int) Main.tile[index1 + 2, index2].wall == 27) && ((int) Main.tile[index1 - 1, index2].active == 0 && (int) Main.tile[index1 + 2, index2].active == 0))
            {
              Main.tile[index1, index2].active = (byte) 0;
              Main.tile[index1, index2].wall = (byte) 27;
              Main.tile[index1 + 1, index2].active = (byte) 0;
              Main.tile[index1 + 1, index2].wall = (byte) 27;
            }
            if ((int) Main.tile[index1, index2 - 1].wall == 27 && (int) Main.tile[index1, index2 + 1].wall == 27 && ((int) Main.tile[index1, index2 - 1].active == 0 && (int) Main.tile[index1, index2 + 1].active == 0))
            {
              Main.tile[index1, index2].active = (byte) 0;
              Main.tile[index1, index2].wall = (byte) 27;
            }
          }
        }
      }
      for (int i1 = num12; i1 < num13; ++i1)
      {
        for (int j1 = num15; j1 > num14; --j1)
        {
          bool flag1 = false;
          if ((int) Main.tile[i1, j1].active != 0 && (int) Main.tile[i1, j1].type == 30)
          {
            int num7 = -1;
            for (int index1 = 0; index1 < 2; ++index1)
            {
              if (!WorldGen.SolidTileUnsafe(i1 + num7, j1) && (int) Main.tile[i1 + num7, j1].wall == 0)
              {
                int num8 = 0;
                int j2 = j1;
                int num9 = j1;
                while ((int) Main.tile[i1, j2].active != 0 && (int) Main.tile[i1, j2].type == 30 && (!WorldGen.SolidTileUnsafe(i1 + num7, j2) && (int) Main.tile[i1 + num7, j2].wall == 0))
                {
                  --j2;
                  ++num8;
                }
                int num10 = j2 + 1 + 1;
                if (num8 > 4)
                {
                  if (WorldGen.genRand.Next(2) == 0)
                  {
                    int j3 = num9 - 1;
                    bool flag2 = true;
                    for (int index2 = i1 - 2; index2 <= i1 + 2; ++index2)
                    {
                      for (int index3 = j3 - 2; index3 <= j3; ++index3)
                      {
                        if (index2 != i1 && (int) Main.tile[index2, index3].active != 0)
                          flag2 = false;
                      }
                    }
                    if (flag2)
                    {
                      Main.tile[i1, j3].active = (byte) 0;
                      Main.tile[i1, j3 - 1].active = (byte) 0;
                      Main.tile[i1, j3 - 2].active = (byte) 0;
                      WorldGen.PlaceTile(i1, j3, 10, true, false, -1, 0);
                      flag1 = true;
                    }
                  }
                  if (!flag1)
                  {
                    for (int index2 = num10; index2 < num9; ++index2)
                      Main.tile[i1, index2].type = (byte) 124;
                  }
                }
              }
              num7 = 1;
            }
          }
          if (flag1)
            break;
        }
      }
      for (int i1 = num12; i1 < num13; i1 = i1 + WorldGen.genRand.Next(3) + 1)
      {
        bool flag = true;
        for (int j1 = num14; j1 < num15; ++j1)
        {
          for (int i2 = i1 - 2; i2 <= i1 + 2; ++i2)
          {
            if ((int) Main.tile[i2, j1].active != 0 && (!WorldGen.SolidTileUnsafe(i2, j1) || (int) Main.tile[i2, j1].type == 10))
              flag = false;
          }
        }
        if (flag)
        {
          for (int j1 = num14; j1 < num15; ++j1)
          {
            if ((int) Main.tile[i1, j1].wall == 27 && (int) Main.tile[i1, j1].active == 0)
              WorldGen.PlaceTile(i1, j1, 124, true, false, -1, 0);
          }
        }
      }
      for (int index1 = 0; index1 < 4; ++index1)
      {
        int i1 = WorldGen.genRand.Next(num12 + 2, num13 - 1);
        int index2;
        for (index2 = WorldGen.genRand.Next(num14 + 2, num15 - 1); (int) Main.tile[i1, index2].wall != 27; index2 = WorldGen.genRand.Next(num14 + 2, num15 - 1))
          i1 = WorldGen.genRand.Next(num12 + 2, num13 - 1);
        while ((int) Main.tile[i1, index2].active != 0)
          --index2;
        while ((int) Main.tile[i1, index2].active == 0)
          ++index2;
        int j1 = index2 - 1;
        if ((int) Main.tile[i1, j1].wall == 27)
        {
          if (WorldGen.genRand.Next(3) == 0)
          {
            int type;
            switch (WorldGen.genRand.Next(9))
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
            WorldGen.PlaceTile(i1, j1, type, true, false, -1, 0);
          }
          else
          {
            int style = WorldGen.genRand.Next(2, 43);
            WorldGen.PlaceTile(i1, j1, 105, true, true, -1, style);
          }
        }
      }
    }

    public static void CountTiles(int X)
    {
      if (X == 0)
      {
        WorldGen.totalEvil = WorldGen.totalEvil2;
        WorldGen.totalSolid = WorldGen.totalSolid2;
        WorldGen.totalGood = WorldGen.totalGood2;
        if (!WorldGen.gen)
        {
          if (WorldGen.totalSolid > 0)
          {
            WorldGen.tGood = (byte) Math.Round((double) (WorldGen.totalGood * 100) / (double) WorldGen.totalSolid);
            WorldGen.tEvil = (byte) Math.Round((double) (WorldGen.totalEvil * 100) / (double) WorldGen.totalSolid);
            if ((double) WorldGen.tEvil >= 50.0)
              UI.SetTriggerStateForAll(Trigger.CorruptedWorld);
            if ((double) WorldGen.tGood >= 50.0)
              UI.SetTriggerStateForAll(Trigger.HallowedWorld);
          }
          else
          {
            WorldGen.tGood = (byte) 0;
            WorldGen.tEvil = (byte) 0;
          }
          NetMessage.CreateMessage0(57);
          NetMessage.SendMessage();
        }
        WorldGen.totalEvil2 = 0;
        WorldGen.totalSolid2 = 0;
        WorldGen.totalGood2 = 0;
      }
      int num = Main.worldSurface;
      int j = (int) Main.maxTilesY - 1;
      do
      {
        if (WorldGen.SolidTileUnsafe(X, j))
        {
          switch (Main.tile[X, j].type)
          {
            case (byte) 109:
            case (byte) 116:
            case (byte) 117:
              ++WorldGen.totalGood2;
              break;
            case (byte) 23:
            case (byte) 25:
            case (byte) 112:
              ++WorldGen.totalEvil2;
              break;
          }
          ++WorldGen.totalSolid2;
        }
      }
      while (--j > num);
      do
      {
        if (WorldGen.SolidTileUnsafe(X, j))
        {
          switch (Main.tile[X, j].type)
          {
            case (byte) 109:
            case (byte) 116:
            case (byte) 117:
              WorldGen.totalGood2 += 5;
              break;
            case (byte) 23:
            case (byte) 25:
            case (byte) 112:
              WorldGen.totalEvil2 += 5;
              break;
          }
          WorldGen.totalSolid2 += 5;
        }
      }
      while (--j >= 0);
    }

    public static unsafe void UpdateWorld()
    {
      WorldGen.UpdateSand();
      WorldGen.UpdateMech();
      if ((++Liquid.skipCount & 1) == 0)
        Liquid.UpdateLiquid();
      if (WorldGen.hardLock)
        return;
      if ((++WorldGen.totalD & 15) == 0)
      {
        WorldGen.CountTiles(WorldGen.totalX);
        if (++WorldGen.totalX >= (int) Main.maxTilesX)
          WorldGen.totalX = 0;
      }
      bool flag1 = false;
      if (Main.invasionType > 0)
        WorldGen.spawnDelay = 0;
      if (++WorldGen.spawnDelay >= 20)
      {
        flag1 = true;
        WorldGen.spawnDelay = 0;
        if (WorldGen.spawnNPC != 37)
        {
          for (int index = 0; index < 196; ++index)
          {
            if ((int) Main.npc[index].active != 0 && Main.npc[index].homeless && Main.npc[index].townNPC)
            {
              WorldGen.spawnNPC = (int) Main.npc[index].type;
              break;
            }
          }
        }
      }
      float num1 = 3E-05f;
      for (int index1 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * (double) num1); index1 > 0; --index1)
      {
        int index2 = WorldGen.genRand.Next(10, (int) Main.maxTilesX - 10);
        int index3 = WorldGen.genRand.Next(10, Main.worldSurface - 1);
        int num2 = index2 - 1;
        int num3 = index2 + 2;
        int index4 = index3 - 1;
        int num4 = index3 + 2;
        if (num2 < 10)
          num2 = 10;
        if (num3 > (int) Main.maxTilesX - 10)
          num3 = (int) Main.maxTilesX - 10;
        if (index4 < 10)
          index4 = 10;
        if (num4 > (int) Main.maxTilesY - 10)
          num4 = (int) Main.maxTilesY - 10;
        fixed (Tile* tilePtr = &Main.tile[index2, index3])
        {
          int grass = (int) tilePtr->type;
          if (grass >= 82 && grass <= 84)
            WorldGen.GrowAlch(index2, index3);
          if ((int) tilePtr->liquid > 32)
          {
            if ((int) tilePtr->active != 0 && (grass == 3 || grass == 20 || (grass == 24 || grass == 27) || grass == 73))
            {
              WorldGen.KillTile(index2, index3);
              if (Main.netMode == 2)
              {
                NetMessage.CreateMessage5(17, 0, index2, index3, 0, 0);
                NetMessage.SendMessage();
              }
            }
          }
          else if ((int) tilePtr->active != 0)
          {
            if (Main.hardMode)
              WorldGen.hardUpdateWorld(index2, index3);
            if (grass == 80)
            {
              if (WorldGen.genRand.Next(15) == 0)
                WorldGen.GrowCactus(index2, index3);
            }
            else if (grass == 53)
            {
              if ((int) Main.tile[index2, index4].active == 0)
              {
                if (index2 < 250 || index2 > (int) Main.maxTilesX - 250)
                {
                  if (WorldGen.genRand.Next(500) == 0 && (int) Main.tile[index2, index4].liquid == (int) byte.MaxValue && ((int) Main.tile[index2, index4 - 1].liquid == (int) byte.MaxValue && (int) Main.tile[index2, index4 - 2].liquid == (int) byte.MaxValue) && ((int) Main.tile[index2, index4 - 3].liquid == (int) byte.MaxValue && (int) Main.tile[index2, index4 - 4].liquid == (int) byte.MaxValue && WorldGen.PlaceTile(index2, index4, 81, true, false, -1, 0)))
                    NetMessage.SendTile(index2, index4);
                }
                else if (index2 > 400 && index2 < (int) Main.maxTilesX - 400 && WorldGen.genRand.Next(300) == 0)
                  WorldGen.GrowCactus(index2, index3);
              }
            }
            else if (grass == 116 || grass == 112)
            {
              if ((int) Main.tile[index2, index4].active == 0 && index2 > 400 && (index2 < (int) Main.maxTilesX - 400 && WorldGen.genRand.Next(300) == 0))
                WorldGen.GrowCactus(index2, index3);
            }
            else if (grass == 78)
            {
              if ((int) Main.tile[index2, index4].active == 0 && WorldGen.PlaceTile(index2, index4, 3, true, false, -1, 0))
                NetMessage.SendTile(index2, index4);
            }
            else if (grass == 2 || grass == 23 || (grass == 32 || grass == 109))
            {
              if ((int) Main.tile[index2, index4].active == 0 && WorldGen.genRand.Next(12) == 0 && (grass == 2 && WorldGen.PlaceTile(index2, index4, 3, true, false, -1, 0)))
                NetMessage.SendTile(index2, index4);
              if ((int) Main.tile[index2, index4].active == 0 && WorldGen.genRand.Next(10) == 0 && (grass == 23 && WorldGen.PlaceTile(index2, index4, 24, true, false, -1, 0)))
                NetMessage.SendTile(index2, index4);
              if ((int) Main.tile[index2, index4].active == 0 && WorldGen.genRand.Next(10) == 0 && (grass == 109 && WorldGen.PlaceTile(index2, index4, 110, true, false, -1, 0)))
                NetMessage.SendTile(index2, index4);
              bool flag2 = false;
              for (int i = num2; i < num3; ++i)
              {
                for (int j = index4; j < num4; ++j)
                {
                  if ((index2 != i || index3 != j) && (int) Main.tile[i, j].active != 0)
                  {
                    if (grass == 32)
                      grass = 23;
                    if ((int) Main.tile[i, j].type == 0 || grass == 23 && (int) Main.tile[i, j].type == 2 || grass == 23 && (int) Main.tile[i, j].type == 109)
                    {
                      WorldGen.SpreadGrass(i, j, 0, grass, false);
                      if (grass == 23)
                      {
                        WorldGen.SpreadGrass(i, j, 2, grass, false);
                        WorldGen.SpreadGrass(i, j, 109, grass, false);
                      }
                      if ((int) Main.tile[i, j].type == grass)
                      {
                        WorldGen.SquareTileFrame(i, j, -1);
                        flag2 = true;
                      }
                    }
                    if ((int) Main.tile[i, j].type == 0 || grass == 109 && (int) Main.tile[i, j].type == 2 || grass == 109 && (int) Main.tile[i, j].type == 23)
                    {
                      WorldGen.SpreadGrass(i, j, 0, grass, false);
                      if (grass == 109)
                      {
                        WorldGen.SpreadGrass(i, j, 2, grass, false);
                        WorldGen.SpreadGrass(i, j, 23, grass, false);
                      }
                      if ((int) Main.tile[i, j].type == grass)
                      {
                        WorldGen.SquareTileFrame(i, j, -1);
                        flag2 = true;
                      }
                    }
                  }
                }
              }
              if (flag2)
                NetMessage.SendTileSquare(index2, index3, 3);
            }
            else if (grass == 20)
            {
              if (WorldGen.genRand.Next(20) == 0 && !WorldGen.PlayerLOS(index2, index3))
                WorldGen.GrowTree(index2, index3);
            }
            else if (grass == 3 && WorldGen.genRand.Next(20) == 0)
            {
              if ((int) tilePtr->frameX < 144)
              {
                tilePtr->type = (byte) 73;
                NetMessage.SendTileSquare(index2, index3, 3);
              }
            }
            else if (grass == 110 && WorldGen.genRand.Next(20) == 0)
            {
              if ((int) tilePtr->frameX < 144)
              {
                tilePtr->type = (byte) 113;
                NetMessage.SendTileSquare(index2, index3, 3);
              }
            }
            else if (grass == 32 && WorldGen.genRand.Next(3) == 0)
            {
              int index5 = index2;
              int index6 = index3;
              int num5 = 0;
              if ((int) Main.tile[index5 + 1, index6].active != 0 && (int) Main.tile[index5 + 1, index6].type == 32)
                ++num5;
              if ((int) Main.tile[index5 - 1, index6].active != 0 && (int) Main.tile[index5 - 1, index6].type == 32)
                ++num5;
              if ((int) Main.tile[index5, index6 + 1].active != 0 && (int) Main.tile[index5, index6 + 1].type == 32)
                ++num5;
              if ((int) Main.tile[index5, index6 - 1].active != 0 && (int) Main.tile[index5, index6 - 1].type == 32)
                ++num5;
              if (num5 < 3 || grass == 23)
              {
                switch (WorldGen.genRand.Next(4))
                {
                  case 0:
                    --index6;
                    break;
                  case 1:
                    ++index6;
                    break;
                  case 2:
                    --index5;
                    break;
                  case 3:
                    ++index5;
                    break;
                }
                if ((int) Main.tile[index5, index6].active == 0)
                {
                  int num6 = 0;
                  if ((int) Main.tile[index5 + 1, index6].active != 0 && (int) Main.tile[index5 + 1, index6].type == 32)
                    num6 = 1;
                  if ((int) Main.tile[index5 - 1, index6].active != 0 && (int) Main.tile[index5 - 1, index6].type == 32)
                    ++num6;
                  if ((int) Main.tile[index5, index6 + 1].active != 0 && (int) Main.tile[index5, index6 + 1].type == 32)
                    ++num6;
                  if ((int) Main.tile[index5, index6 - 1].active != 0 && (int) Main.tile[index5, index6 - 1].type == 32)
                    ++num6;
                  if (num6 < 2)
                  {
                    int num7 = 7;
                    int num8 = index5 - num7;
                    int num9 = index5 + num7;
                    int num10 = index6 - num7;
                    int num11 = index6 + num7;
                    for (int index7 = num8; index7 < num9; ++index7)
                    {
                      for (int index8 = num10; index8 < num11; ++index8)
                      {
                        if (Math.Abs(index7 - index5) * 2 + Math.Abs(index8 - index6) < 9 && (int) Main.tile[index7, index8].active != 0 && ((int) Main.tile[index7, index8].type == 23 && (int) Main.tile[index7, index8 - 1].active != 0) && ((int) Main.tile[index7, index8 - 1].type == 32 && (int) Main.tile[index7, index8 - 1].liquid == 0))
                        {
                          Main.tile[index5, index6].type = (byte) 32;
                          Main.tile[index5, index6].active = (byte) 1;
                          WorldGen.SquareTileFrame(index5, index6, -1);
                          NetMessage.SendTileSquare(index5, index6, 3);
                          break;
                        }
                      }
                    }
                  }
                }
              }
            }
            else if (grass == 2 || grass == 52)
            {
              if (WorldGen.genRand.Next(40) == 0 && (int) Main.tile[index2, index3 + 1].active == 0 && (int) Main.tile[index2, index3 + 1].lava == 0)
              {
                for (int index5 = index3; index5 > index3 - 10; --index5)
                {
                  if ((int) Main.tile[index2, index5].active != 0 && (int) Main.tile[index2, index5].type == 2)
                  {
                    int index6 = index3 + 1;
                    Main.tile[index2, index6].type = (byte) 52;
                    Main.tile[index2, index6].active = (byte) 1;
                    WorldGen.SquareTileFrame(index2, index6, -1);
                    NetMessage.SendTileSquare(index2, index6, 3);
                    break;
                  }
                }
              }
            }
            else if (grass == 60)
            {
              if ((int) Main.tile[index2, index4].active == 0 && WorldGen.genRand.Next(7) == 0)
              {
                if (WorldGen.PlaceTile(index2, index4, 61, true, false, -1, 0))
                  NetMessage.SendTile(index2, index4);
              }
              else if (WorldGen.genRand.Next(500) == 0 && ((int) Main.tile[index2, index4].active == 0 || (int) Main.tile[index2, index4].type == 61 || ((int) Main.tile[index2, index4].type == 74 || (int) Main.tile[index2, index4].type == 69)) && !WorldGen.PlayerLOS(index2, index3))
                WorldGen.GrowTree(index2, index3);
              bool flag2 = false;
              for (int i = num2; i < num3; ++i)
              {
                for (int j = index4; j < num4; ++j)
                {
                  if ((index2 != i || index3 != j) && ((int) Main.tile[i, j].active != 0 && (int) Main.tile[i, j].type == 59))
                  {
                    WorldGen.SpreadGrass(i, j, 59, grass, false);
                    if ((int) Main.tile[i, j].type == grass)
                    {
                      WorldGen.SquareTileFrame(i, j, -1);
                      flag2 = true;
                    }
                  }
                }
              }
              if (flag2)
                NetMessage.SendTileSquare(index2, index3, 3);
            }
            else if (grass == 61 && WorldGen.genRand.Next(3) == 0)
            {
              if ((int) tilePtr->frameX < 144)
              {
                tilePtr->type = (byte) 74;
                NetMessage.SendTileSquare(index2, index3, 3);
              }
            }
            else if (grass == 60 || grass == 62)
            {
              if (WorldGen.genRand.Next(15) == 0 && (int) Main.tile[index2, index3 + 1].active == 0 && (int) Main.tile[index2, index3 + 1].lava == 0)
              {
                for (int index5 = index3; index5 > index3 - 10; --index5)
                {
                  if ((int) Main.tile[index2, index5].active != 0 && (int) Main.tile[index2, index5].type == 60)
                  {
                    int index6 = index3 + 1;
                    Main.tile[index2, index6].type = (byte) 62;
                    Main.tile[index2, index6].active = (byte) 1;
                    WorldGen.SquareTileFrame(index2, index6, -1);
                    NetMessage.SendTileSquare(index2, index6, 3);
                    break;
                  }
                }
              }
            }
            else if ((grass == 109 || grass == 115) && (WorldGen.genRand.Next(15) == 0 && (int) Main.tile[index2, index3 + 1].active == 0) && (int) Main.tile[index2, index3 + 1].lava == 0)
            {
              for (int index5 = index3; index5 > index3 - 10; --index5)
              {
                if ((int) Main.tile[index2, index5].active != 0 && (int) Main.tile[index2, index5].type == 109)
                {
                  int index6 = index3 + 1;
                  Main.tile[index2, index6].type = (byte) 115;
                  Main.tile[index2, index6].active = (byte) 1;
                  WorldGen.SquareTileFrame(index2, index6, -1);
                  NetMessage.SendTileSquare(index2, index6, 3);
                  break;
                }
              }
            }
          }
          else if (flag1 && WorldGen.spawnNPC > 0)
            WorldGen.SpawnNPC(index2, index3);
        }
      }
      float num12 = 1.5E-05f;
      for (int index1 = (int) ((double) ((int) Main.maxTilesX * (int) Main.maxTilesY) * (double) num12); index1 > 0; --index1)
      {
        int index2 = WorldGen.genRand.Next(10, (int) Main.maxTilesX - 10);
        int index3 = WorldGen.genRand.Next(Main.worldSurface - 1, (int) Main.maxTilesY - 20);
        int num2 = index2 - 1;
        int num3 = index2 + 2;
        int index4 = index3 - 1;
        int num4 = index3 + 2;
        if (num2 < 10)
          num2 = 10;
        if (num3 > (int) Main.maxTilesX - 10)
          num3 = (int) Main.maxTilesX - 10;
        if (index4 < 10)
          index4 = 10;
        if (num4 > (int) Main.maxTilesY - 10)
          num4 = (int) Main.maxTilesY - 10;
        fixed (Tile* tilePtr = &Main.tile[index2, index3])
        {
          int grass = (int) tilePtr->type;
          if (grass >= 82 && grass <= 84)
            WorldGen.GrowAlch(index2, index3);
          if ((int) tilePtr->liquid <= 32)
          {
            if ((int) tilePtr->active != 0)
            {
              if (Main.hardMode)
                WorldGen.hardUpdateWorld(index2, index3);
              if (grass == 23)
              {
                if ((int) Main.tile[index2, index4].active == 0 && WorldGen.genRand.Next(1) == 0 && WorldGen.PlaceTile(index2, index4, 24, true, false, -1, 0))
                  NetMessage.SendTile(index2, index4);
              }
              else if (grass == 32)
              {
                if (WorldGen.genRand.Next(3) == 0)
                {
                  int index5 = index2;
                  int index6 = index3;
                  int num5 = 0;
                  if ((int) Main.tile[index5 + 1, index6].active != 0 && (int) Main.tile[index5 + 1, index6].type == 32)
                    ++num5;
                  if ((int) Main.tile[index5 - 1, index6].active != 0 && (int) Main.tile[index5 - 1, index6].type == 32)
                    ++num5;
                  if ((int) Main.tile[index5, index6 + 1].active != 0 && (int) Main.tile[index5, index6 + 1].type == 32)
                    ++num5;
                  if ((int) Main.tile[index5, index6 - 1].active != 0 && (int) Main.tile[index5, index6 - 1].type == 32)
                    ++num5;
                  if (num5 < 3 || grass == 23)
                  {
                    switch (WorldGen.genRand.Next(4))
                    {
                      case 0:
                        --index6;
                        break;
                      case 1:
                        ++index6;
                        break;
                      case 2:
                        --index5;
                        break;
                      case 3:
                        ++index5;
                        break;
                    }
                    if ((int) Main.tile[index5, index6].active == 0)
                    {
                      int num6 = 0;
                      if ((int) Main.tile[index5 + 1, index6].active != 0 && (int) Main.tile[index5 + 1, index6].type == 32)
                        ++num6;
                      if ((int) Main.tile[index5 - 1, index6].active != 0 && (int) Main.tile[index5 - 1, index6].type == 32)
                        ++num6;
                      if ((int) Main.tile[index5, index6 + 1].active != 0 && (int) Main.tile[index5, index6 + 1].type == 32)
                        ++num6;
                      if ((int) Main.tile[index5, index6 - 1].active != 0 && (int) Main.tile[index5, index6 - 1].type == 32)
                        ++num6;
                      if (num6 < 2)
                      {
                        int num7 = 7;
                        int num8 = index5 - num7;
                        int num9 = index5 + num7;
                        int num10 = index6 - num7;
                        int num11 = index6 + num7;
                        for (int index7 = num8; index7 < num9; ++index7)
                        {
                          for (int index8 = num10; index8 < num11; ++index8)
                          {
                            if (Math.Abs(index7 - index5) * 2 + Math.Abs(index8 - index6) < 9 && (int) Main.tile[index7, index8].active != 0 && ((int) Main.tile[index7, index8].type == 23 && (int) Main.tile[index7, index8 - 1].active != 0) && ((int) Main.tile[index7, index8 - 1].type == 32 && (int) Main.tile[index7, index8 - 1].liquid == 0))
                            {
                              Main.tile[index5, index6].type = (byte) 32;
                              Main.tile[index5, index6].active = (byte) 1;
                              WorldGen.SquareTileFrame(index5, index6, -1);
                              NetMessage.SendTileSquare(index5, index6, 3);
                              break;
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
              else if (grass == 60)
              {
                if ((int) Main.tile[index2, index4].active == 0 && WorldGen.genRand.Next(10) == 0)
                {
                  if (WorldGen.PlaceTile(index2, index4, 61, true, false, -1, 0))
                    NetMessage.SendTile(index2, index4);
                }
                else
                {
                  bool flag2 = false;
                  for (int i = num2; i < num3; ++i)
                  {
                    for (int j = index4; j < num4; ++j)
                    {
                      if ((index2 != i || index3 != j) && ((int) Main.tile[i, j].type == 59 && (int) Main.tile[i, j].active != 0))
                      {
                        WorldGen.SpreadGrass(i, j, 59, grass, false);
                        if ((int) Main.tile[i, j].type == grass)
                        {
                          WorldGen.SquareTileFrame(i, j, -1);
                          flag2 = true;
                        }
                      }
                    }
                  }
                  if (flag2)
                    NetMessage.SendTileSquare(index2, index3, 3);
                }
              }
              else if (grass == 61)
              {
                if ((int) tilePtr->frameX < 144 && WorldGen.genRand.Next(3) == 0)
                {
                  tilePtr->type = (byte) 74;
                  NetMessage.SendTileSquare(index2, index3, 3);
                }
              }
              else if (grass == 60 || grass == 62)
              {
                if (WorldGen.genRand.Next(5) == 0 && (int) Main.tile[index2, index3 + 1].active == 0 && (int) Main.tile[index2, index3 + 1].lava == 0)
                {
                  for (int index5 = index3; index5 > index3 - 10; --index5)
                  {
                    if ((int) Main.tile[index2, index5].active != 0 && (int) Main.tile[index2, index5].type == 60)
                    {
                      int index6 = index3 + 1;
                      Main.tile[index2, index6].type = (byte) 62;
                      Main.tile[index2, index6].active = (byte) 1;
                      WorldGen.SquareTileFrame(index2, index6, -1);
                      NetMessage.SendTileSquare(index2, index6, 3);
                      break;
                    }
                  }
                }
              }
              else if (grass == 69)
              {
                if (WorldGen.genRand.Next(3) == 0)
                {
                  int index5 = index2;
                  int index6 = index3;
                  int num5 = 0;
                  if ((int) Main.tile[index5 + 1, index6].active != 0 && (int) Main.tile[index5 + 1, index6].type == 69)
                    ++num5;
                  if ((int) Main.tile[index5 - 1, index6].active != 0 && (int) Main.tile[index5 - 1, index6].type == 69)
                    ++num5;
                  if ((int) Main.tile[index5, index6 + 1].active != 0 && (int) Main.tile[index5, index6 + 1].type == 69)
                    ++num5;
                  if ((int) Main.tile[index5, index6 - 1].active != 0 && (int) Main.tile[index5, index6 - 1].type == 69)
                    ++num5;
                  if (num5 < 3 || grass == 60)
                  {
                    switch (WorldGen.genRand.Next(4))
                    {
                      case 0:
                        --index6;
                        break;
                      case 1:
                        ++index6;
                        break;
                      case 2:
                        --index5;
                        break;
                      case 3:
                        ++index5;
                        break;
                    }
                    if ((int) Main.tile[index5, index6].active == 0)
                    {
                      int num6 = 0;
                      if ((int) Main.tile[index5 + 1, index6].active != 0 && (int) Main.tile[index5 + 1, index6].type == 69)
                        ++num6;
                      if ((int) Main.tile[index5 - 1, index6].active != 0 && (int) Main.tile[index5 - 1, index6].type == 69)
                        ++num6;
                      if ((int) Main.tile[index5, index6 + 1].active != 0 && (int) Main.tile[index5, index6 + 1].type == 69)
                        ++num6;
                      if ((int) Main.tile[index5, index6 - 1].active != 0 && (int) Main.tile[index5, index6 - 1].type == 69)
                        ++num6;
                      if (num6 < 2)
                      {
                        int num7 = 7;
                        int num8 = index5 - num7;
                        int num9 = index5 + num7;
                        int num10 = index6 - num7;
                        int num11 = index6 + num7;
                        for (int index7 = num8; index7 < num9; ++index7)
                        {
                          for (int index8 = num10; index8 < num11; ++index8)
                          {
                            if (Math.Abs(index7 - index5) * 2 + Math.Abs(index8 - index6) < 9 && (int) Main.tile[index7, index8].active != 0 && ((int) Main.tile[index7, index8].type == 60 && (int) Main.tile[index7, index8 - 1].active != 0) && ((int) Main.tile[index7, index8 - 1].type == 69 && (int) Main.tile[index7, index8 - 1].liquid == 0))
                            {
                              Main.tile[index5, index6].type = (byte) 69;
                              Main.tile[index5, index6].active = (byte) 1;
                              WorldGen.SquareTileFrame(index5, index6, -1);
                              NetMessage.SendTileSquare(index5, index6, 3);
                              break;
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
              else if (grass == 70)
              {
                if ((int) Main.tile[index2, index4].active == 0 && WorldGen.genRand.Next(10) == 0)
                {
                  if (WorldGen.PlaceTile(index2, index4, 71, true, false, -1, 0))
                    NetMessage.SendTile(index2, index4);
                }
                else if (WorldGen.genRand.Next(200) == 0 && !WorldGen.PlayerLOS(index2, index3))
                {
                  WorldGen.GrowShroom(index2, index3);
                }
                else
                {
                  bool flag2 = false;
                  for (int i = num2; i < num3; ++i)
                  {
                    for (int j = index4; j < num4; ++j)
                    {
                      if ((index2 != i || index3 != j) && ((int) Main.tile[i, j].active != 0 && (int) Main.tile[i, j].type == 59))
                      {
                        WorldGen.SpreadGrass(i, j, 59, grass, false);
                        if ((int) Main.tile[i, j].type == grass)
                        {
                          WorldGen.SquareTileFrame(i, j, -1);
                          flag2 = true;
                        }
                      }
                    }
                  }
                  if (flag2)
                    NetMessage.SendTileSquare(index2, index3, 3);
                }
              }
            }
            else if (flag1 && WorldGen.spawnNPC > 0)
              WorldGen.SpawnNPC(index2, index3);
          }
        }
      }
      if (Main.rand.Next(100) == 0)
        WorldGen.PlantAlch();
      if (Main.gameTime.dayTime)
        return;
      float num13 = (float) Main.maxTilesX / 4200f;
      if ((double) Main.rand.Next(8000) >= 10.0 * (double) num13)
        return;
      int num14 = 12;
      Vector2 vector2 = new Vector2((float) ((Main.rand.Next((int) Main.maxTilesX - 50) + 100) * 16), (float) (Main.rand.Next((int) ((double) Main.maxTilesY * 0.05)) * 16));
      float num15 = (float) Main.rand.Next(-100, 101);
      float num16 = (float) (Main.rand.Next(200) + 100);
      float num17 = (float) Math.Sqrt((double) num15 * (double) num15 + (double) num16 * (double) num16);
      float num18 = (float) num14 / num17;
      float SpeedX = num15 * num18;
      float SpeedY = num16 * num18;
      Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 12, 1000, 10f, 8, true);
    }

    public static bool PlaceWall(int i, int j, int type)
    {
      if (i <= 1 || j <= 1 || (i >= (int) Main.maxTilesX - 2 || j >= (int) Main.maxTilesY - 2) || (int) Main.tile[i, j].wall != 0)
        return false;
      Main.tile[i, j].wall = (byte) type;
      WorldGen.WallFrame(i - 1, j - 1, false);
      WorldGen.WallFrame(i - 1, j, false);
      WorldGen.WallFrame(i - 1, j + 1, false);
      WorldGen.WallFrame(i, j - 1, false);
      WorldGen.WallFrame(i, j, true);
      WorldGen.WallFrame(i, j + 1, false);
      WorldGen.WallFrame(i + 1, j - 1, false);
      WorldGen.WallFrame(i + 1, j, false);
      WorldGen.WallFrame(i + 1, j + 1, false);
      Main.PlaySound(0, i << 4, j << 4, 1);
      return true;
    }

    public static unsafe void AddPlants()
    {
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int i = 0; i < (int) Main.maxTilesX; ++i)
        {
          Tile* tilePtr2 = tilePtr1 + (i * 1440 + 5);
          int num = 5;
          while (num < (int) Main.maxTilesY)
          {
            if ((int) tilePtr2->active != 0)
            {
              if ((int) tilePtr2->type == 2)
              {
                Tile* tilePtr3 = tilePtr2 - 1;
                if ((int) tilePtr3->active == 0)
                  WorldGen.PlaceTile(i, num - 1, 3, true, false, -1, 0);
                tilePtr2 = tilePtr3 + 1;
              }
              else if ((int) tilePtr2->type == 23)
              {
                Tile* tilePtr3 = tilePtr2 - 1;
                if ((int) tilePtr3->active == 0)
                  WorldGen.PlaceTile(i, num - 1, 24, true, false, -1, 0);
                tilePtr2 = tilePtr3 + 1;
              }
            }
            ++num;
            ++tilePtr2;
          }
        }
      }
    }

    public static void SpreadGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true)
    {
      try
      {
        if ((int) Main.tile[i, j].type != dirt || (int) Main.tile[i, j].active == 0 || j < Main.worldSurface && grass == 70 || j >= Main.worldSurface && dirt == 0)
          return;
        int num1 = i - 1;
        int num2 = i + 2;
        int num3 = j - 1;
        int num4 = j + 2;
        if (num1 < 0)
          num1 = 0;
        if (num2 > (int) Main.maxTilesX)
          num2 = (int) Main.maxTilesX;
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesY)
          num4 = (int) Main.maxTilesY;
        bool flag = true;
        for (int index1 = num1; index1 < num2; ++index1)
        {
          for (int index2 = num3; index2 < num4; ++index2)
          {
            if ((int) Main.tile[index1, index2].active == 0 || !Main.tileSolid[(int) Main.tile[index1, index2].type])
              flag = false;
            if ((int) Main.tile[index1, index2].lava != 0 && (int) Main.tile[index1, index2].liquid > 0)
            {
              flag = true;
              break;
            }
          }
        }
        if (flag || grass == 23 && (int) Main.tile[i, j - 1].type == 27)
          return;
        Main.tile[i, j].type = (byte) grass;
        for (int i1 = num1; i1 < num2; ++i1)
        {
          for (int j1 = num3; j1 < num4; ++j1)
          {
            if ((int) Main.tile[i1, j1].active != 0)
            {
              if ((int) Main.tile[i1, j1].type == dirt)
              {
                try
                {
                  if (repeat)
                  {
                    if (WorldGen.grassSpread < 400)
                    {
                      ++WorldGen.grassSpread;
                      WorldGen.SpreadGrass(i1, j1, dirt, grass, true);
                      --WorldGen.grassSpread;
                    }
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
      catch
      {
      }
    }

    public static void ChasmRunnerSideways(int i, int j, int direction, int steps)
    {
      Vector2 vector2_1 = new Vector2();
      Vector2 vector2_2 = new Vector2();
      float num1 = (float) steps;
      vector2_1.X = (float) i;
      vector2_1.Y = (float) j;
      vector2_2.X = (float) WorldGen.genRand.Next(10, 21) * 0.1f * (float) direction;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 10) * 0.01f;
      int num2 = WorldGen.genRand.Next(5) + 7;
      while (num2 > 0)
      {
        if ((double) num1 > 0.0)
        {
          num2 = num2 + WorldGen.genRand.Next(3) - WorldGen.genRand.Next(3);
          if (num2 < 7)
            num2 = 7;
          else if (num2 > 20)
            num2 = 20;
          if ((double) num1 == 1.0 && num2 < 10)
            num2 = 10;
        }
        else
          num2 -= WorldGen.genRand.Next(4);
        if ((double) vector2_1.Y > (double) Main.rockLayer && (double) num1 > 0.0)
          num1 = 0.0f;
        --num1;
        int num3 = (int) ((double) vector2_1.X - (double) num2 * 0.5);
        int num4 = (int) ((double) vector2_1.X + (double) num2 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - (double) num2 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + (double) num2 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesX - 1)
          num4 = (int) Main.maxTilesX - 1;
        if (num5 < 0)
          num5 = 0;
        if (num6 > (int) Main.maxTilesY)
          num6 = (int) Main.maxTilesY;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          for (int index2 = num5; index2 < num6; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < (double) num2 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239) && (int) Main.tile[index1, index2].type != 31 && (int) Main.tile[index1, index2].type != 22)
              Main.tile[index1, index2].active = (byte) 0;
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 10) * 0.1f;
        if ((double) vector2_1.Y < (double) (j - 20))
          vector2_2.Y += (float) WorldGen.genRand.Next(20) * 0.01f;
        else if ((double) vector2_1.Y > (double) (j + 20))
          vector2_2.Y -= (float) WorldGen.genRand.Next(20) * 0.01f;
        if ((double) vector2_2.Y < -0.5)
          vector2_2.Y = -0.5f;
        else if ((double) vector2_2.Y > 0.5)
          vector2_2.Y = 0.5f;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.01f;
        if (direction == -1)
        {
          if ((double) vector2_2.X > -0.5)
            vector2_2.X = -0.5f;
          else if ((double) vector2_2.X < -2.0)
            vector2_2.X = -2f;
        }
        else if (direction == 1)
        {
          if ((double) vector2_2.X < 0.5)
            vector2_2.X = 0.5f;
          else if ((double) vector2_2.X > 2.0)
            vector2_2.X = 2f;
        }
        int num7 = (int) ((double) vector2_1.X - (double) num2 * 1.10000002384186);
        int num8 = (int) ((double) vector2_1.X + (double) num2 * 1.10000002384186);
        int num9 = (int) ((double) vector2_1.Y - (double) num2 * 1.10000002384186);
        int num10 = (int) ((double) vector2_1.Y + (double) num2 * 1.10000002384186);
        if (num7 < 1)
          num7 = 1;
        if (num8 > (int) Main.maxTilesX - 1)
          num8 = (int) Main.maxTilesX - 1;
        if (num9 < 0)
          num9 = 0;
        if (num10 > (int) Main.maxTilesY)
          num10 = (int) Main.maxTilesY;
        for (int index1 = num7; index1 < num8; ++index1)
        {
          for (int index2 = num9; index2 < num10; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < (double) num2 * 1.10000002384186 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239) && (int) Main.tile[index1, index2].wall != 3)
            {
              if ((int) Main.tile[index1, index2].type != 25 && index2 > j + WorldGen.genRand.Next(3, 20))
                Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].active = (byte) 1;
              if ((int) Main.tile[index1, index2].type != 31 && (int) Main.tile[index1, index2].type != 22)
                Main.tile[index1, index2].type = (byte) 25;
              if ((int) Main.tile[index1, index2].wall == 2)
                Main.tile[index1, index2].wall = (byte) 0;
            }
          }
        }
        for (int index1 = num7; index1 < num8; ++index1)
        {
          for (int index2 = num9; index2 < num10; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < (double) num2 * 1.10000002384186 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239) && (int) Main.tile[index1, index2].wall != 3)
            {
              if ((int) Main.tile[index1, index2].type != 31 && (int) Main.tile[index1, index2].type != 22)
                Main.tile[index1, index2].type = (byte) 25;
              Main.tile[index1, index2].active = (byte) 1;
              if ((int) Main.tile[index1, index2].wall == 0)
                Main.tile[index1, index2].wall = (byte) 3;
            }
          }
        }
      }
      if (WorldGen.genRand.Next(3) != 0)
        return;
      int i1 = (int) vector2_1.X;
      int j1 = (int) vector2_1.Y;
      while ((int) Main.tile[i1, j1].active == 0)
        ++j1;
      WorldGen.TileRunner(i1, j1, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), 22, false, new Vector2(), false, true);
    }

    public static void ChasmRunner(int i, int j, int steps, bool makeOrb = false)
    {
      bool flag1 = false;
      bool flag2 = !makeOrb;
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      float num1 = (float) steps;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) ((double) WorldGen.genRand.Next(11) * 0.200000002980232 + 0.5);
      int num2 = 5;
      int num3 = WorldGen.genRand.Next(5) + 7;
      while (num3 > 0)
      {
        if ((double) num1 > 0.0)
        {
          num3 = num3 + WorldGen.genRand.Next(3) - WorldGen.genRand.Next(3);
          if (num3 < 7)
            num3 = 7;
          else if (num3 > 20)
            num3 = 20;
          if ((double) num1 == 1.0 && num3 < 10)
            num3 = 10;
        }
        else if ((double) vector2_1.Y > (double) (Main.worldSurface + 45))
          num3 -= WorldGen.genRand.Next(4);
        if ((double) vector2_1.Y > (double) Main.rockLayer && (double) num1 > 0.0)
          num1 = 0.0f;
        --num1;
        if (!flag1 && (double) vector2_1.Y > (double) (Main.worldSurface + 20))
        {
          flag1 = true;
          WorldGen.ChasmRunnerSideways((int) vector2_1.X, (int) vector2_1.Y, -1, WorldGen.genRand.Next(20, 40));
          WorldGen.ChasmRunnerSideways((int) vector2_1.X, (int) vector2_1.Y, 1, WorldGen.genRand.Next(20, 40));
        }
        if ((double) num1 > (double) num2)
        {
          int num4 = (int) ((double) vector2_1.X - (double) num3 * 0.5);
          int num5 = (int) ((double) vector2_1.X + (double) num3 * 0.5);
          int num6 = (int) ((double) vector2_1.Y - (double) num3 * 0.5);
          int num7 = (int) ((double) vector2_1.Y + (double) num3 * 0.5);
          if (num4 < 0)
            num4 = 0;
          if (num5 > (int) Main.maxTilesX - 1)
            num5 = (int) Main.maxTilesX - 1;
          if (num6 < 0)
            num6 = 0;
          if (num7 > (int) Main.maxTilesY)
            num7 = (int) Main.maxTilesY;
          for (int index1 = num4; index1 < num5; ++index1)
          {
            for (int index2 = num6; index2 < num7; ++index2)
            {
              if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < (double) num3 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239) && (int) Main.tile[index1, index2].type != 31 && (int) Main.tile[index1, index2].type != 22)
                Main.tile[index1, index2].active = (byte) 0;
            }
          }
        }
        if ((double) num1 <= 2.0 && (double) vector2_1.Y < (double) (Main.worldSurface + 45))
          num1 = 2f;
        if ((double) num1 <= 0.0)
        {
          if (!flag2)
          {
            flag2 = true;
            WorldGen.AddShadowOrb((int) vector2_1.X, (int) vector2_1.Y);
          }
          else
          {
            for (int index = 0; index < 10000; ++index)
            {
              int y = WorldGen.genRand.Next((int) vector2_1.Y - 50, (int) vector2_1.Y);
              if (y > Main.worldSurface)
              {
                if (y > (int) Main.maxTilesY - 5)
                  y = (int) Main.maxTilesY - 5;
                int x = WorldGen.genRand.Next((int) vector2_1.X - 25, (int) vector2_1.X + 25);
                if (x < 5)
                  x = 5;
                else if (x > (int) Main.maxTilesX - 5)
                  x = (int) Main.maxTilesX - 5;
                if (WorldGen.Place3x2(x, y, 26))
                  break;
              }
              else
                break;
            }
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.01f;
        if ((double) vector2_2.X > 0.300000011920929)
          vector2_2.X = 0.3f;
        else if ((double) vector2_2.X < -0.300000011920929)
          vector2_2.X = -0.3f;
        int num8 = (int) ((double) vector2_1.X - (double) num3 * 1.10000002384186);
        int num9 = (int) ((double) vector2_1.X + (double) num3 * 1.10000002384186);
        int num10 = (int) ((double) vector2_1.Y - (double) num3 * 1.10000002384186);
        int num11 = (int) ((double) vector2_1.Y + (double) num3 * 1.10000002384186);
        if (num8 < 1)
          num8 = 1;
        if (num9 > (int) Main.maxTilesX - 1)
          num9 = (int) Main.maxTilesX - 1;
        if (num10 < 0)
          num10 = 0;
        if (num11 > (int) Main.maxTilesY)
          num11 = (int) Main.maxTilesY;
        for (int index1 = num8; index1 < num9; ++index1)
        {
          for (int index2 = num10; index2 < num11; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < (double) num3 * 1.10000002384186 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239))
            {
              if ((int) Main.tile[index1, index2].type != 25 && index2 > j + WorldGen.genRand.Next(3, 20))
                Main.tile[index1, index2].active = (byte) 1;
              if (steps <= num2)
                Main.tile[index1, index2].active = (byte) 1;
              if ((int) Main.tile[index1, index2].type != 31)
                Main.tile[index1, index2].type = (byte) 25;
              if ((int) Main.tile[index1, index2].wall == 2)
                Main.tile[index1, index2].wall = (byte) 0;
            }
          }
        }
        for (int index1 = num8; index1 < num9; ++index1)
        {
          for (int index2 = num10; index2 < num11; ++index2)
          {
            if ((double) Math.Abs((float) index1 - vector2_1.X) + (double) Math.Abs((float) index2 - vector2_1.Y) < (double) num3 * 1.10000002384186 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239))
            {
              if ((int) Main.tile[index1, index2].type != 31)
                Main.tile[index1, index2].type = (byte) 25;
              if (steps <= num2)
                Main.tile[index1, index2].active = (byte) 1;
              if (index2 > j + WorldGen.genRand.Next(3, 20) && (int) Main.tile[index1, index2].wall == 0)
                Main.tile[index1, index2].wall = (byte) 3;
            }
          }
        }
      }
    }

    public static void JungleRunner(int i, int j)
    {
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(5, 11);
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(10, 20) * 0.1f;
      int num2 = 0;
      bool flag = true;
      do
      {
        int index1 = (int) vector2_1.X;
        int index2 = (int) vector2_1.Y;
        if (index2 < Main.worldSurface && (int) Main.tile[index1, index2].wall == 0 && ((int) Main.tile[index1, index2].active == 0 && (int) Main.tile[index1, index2 - 3].wall == 0) && ((int) Main.tile[index1, index2 - 3].active == 0 && (int) Main.tile[index1, index2 - 1].wall == 0 && ((int) Main.tile[index1, index2 - 1].active == 0 && (int) Main.tile[index1, index2 - 4].wall == 0)) && ((int) Main.tile[index1, index2 - 4].active == 0 && (int) Main.tile[index1, index2 - 2].wall == 0 && ((int) Main.tile[index1, index2 - 2].active == 0 && (int) Main.tile[index1, index2 - 5].wall == 0) && (int) Main.tile[index1, index2 - 5].active == 0))
          flag = false;
        WorldGen.JungleX = index1;
        num1 += (double) WorldGen.genRand.Next(-20, 21) * 0.100000001490116;
        if (num1 < 5.0)
          num1 = 5.0;
        else if (num1 > 10.0)
          num1 = 10.0;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesX)
          num4 = (int) Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > (int) Main.maxTilesY)
          num6 = (int) Main.maxTilesY;
        for (int i1 = num3; i1 < num4; ++i1)
        {
          for (int j1 = num5; j1 < num6; ++j1)
          {
            if ((double) Math.Abs((float) i1 - vector2_1.X) + (double) Math.Abs((float) j1 - vector2_1.Y) < num1 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
              WorldGen.KillTileFast(i1, j1);
          }
        }
        if (++num2 > 10 && WorldGen.genRand.Next(50) < num2)
        {
          num2 = 0;
          int num7 = -2;
          if (WorldGen.genRand.Next(2) == 0)
            num7 = 2;
          WorldGen.TileRunner((int) vector2_1.X, (int) vector2_1.Y, WorldGen.genRand.Next(3, 20), WorldGen.genRand.Next(10, 100), -1, false, new Vector2((float) num7, 0.0f), false, true);
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.01f;
        if ((double) vector2_2.Y > 0.0)
          vector2_2.Y = 0.0f;
        else if ((double) vector2_2.Y < -2.0)
          vector2_2.Y = -2f;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
        if ((double) vector2_1.X < (double) (i - 200))
          vector2_2.X += (float) WorldGen.genRand.Next(5, 21) * 0.1f;
        if ((double) vector2_1.X > (double) (i + 200))
          vector2_2.X -= (float) WorldGen.genRand.Next(5, 21) * 0.1f;
        if ((double) vector2_2.X > 1.5)
          vector2_2.X = 1.5f;
        else if ((double) vector2_2.X < -1.5)
          vector2_2.X = -1.5f;
      }
      while (flag);
    }

    public static void GERunner(int i, Vector2 speed, bool good, ref Vector2i minArea, ref Vector2i maxArea)
    {
      Vector2 vector2_1 = new Vector2((float) i, 0.0f);
      Vector2 vector2_2 = speed;
      int num1 = (int) ((double) WorldGen.genRand.Next(200, 250) * (double) ((float) Main.maxTilesX * 0.0002380952f));
      int num2 = num1;
      while (true)
      {
        do
        {
          int num3 = (int) ((double) vector2_1.X - (double) num2 * 0.5);
          int num4 = (int) ((double) vector2_1.X + (double) num2 * 0.5);
          int num5 = (int) ((double) vector2_1.Y - (double) num2 * 0.5);
          int num6 = (int) ((double) vector2_1.Y + (double) num2 * 0.5);
          if (num3 < 0)
            num3 = 0;
          if (num4 > (int) Main.maxTilesX)
            num4 = (int) Main.maxTilesX;
          if (num5 < 0)
            num5 = 0;
          if (num6 > (int) Main.maxTilesY)
            num6 = (int) Main.maxTilesY;
          for (int i1 = num3; i1 < num4; ++i1)
          {
            for (int j = num5; j < num6; ++j)
            {
              if ((double) Math.Abs((float) i1 - vector2_1.X) + (double) Math.Abs((float) j - vector2_1.Y) < (double) num1 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.015))
              {
                int num7 = 0;
                if (good)
                {
                  if ((int) Main.tile[i1, j].wall == 3)
                    Main.tile[i1, j].wall = (byte) 28;
                  byte num8 = Main.tile[i1, j].type;
                  if ((uint) num8 <= 25U)
                  {
                    switch (num8)
                    {
                      case (byte) 1:
                      case (byte) 25:
                        num7 = 117;
                        break;
                      case (byte) 2:
                      case (byte) 23:
                        num7 = 109;
                        break;
                    }
                  }
                  else if ((int) num8 == 53 || (int) num8 == 112 || (int) num8 == 123)
                    num7 = 116;
                }
                else
                {
                  byte num8 = Main.tile[i1, j].type;
                  if ((uint) num8 <= 53U)
                  {
                    switch (num8)
                    {
                      case (byte) 1:
                        break;
                      case (byte) 2:
                        goto label_25;
                      case (byte) 53:
                        goto label_26;
                      default:
                        goto label_27;
                    }
                  }
                  else
                  {
                    switch (num8)
                    {
                      case (byte) 109:
                        goto label_25;
                      case (byte) 116:
                      case (byte) 123:
                        goto label_26;
                      case (byte) 117:
                        break;
                      default:
                        goto label_27;
                    }
                  }
                  num7 = 25;
                  goto label_27;
label_25:
                  num7 = 23;
                  goto label_27;
label_26:
                  num7 = 112;
                }
label_27:
                if (num7 > 0)
                {
                  if (i1 < minArea.X)
                    minArea.X = i1;
                  if (j < minArea.Y)
                    minArea.Y = j;
                  if (i1 > maxArea.X)
                    maxArea.X = i1;
                  if (j > maxArea.Y)
                    maxArea.Y = j;
                  Main.tile[i1, j].type = (byte) num7;
                  WorldGen.SquareTileFrameNoLiquid(i1, j, -1);
                }
              }
            }
          }
          vector2_1.X += vector2_2.X;
          vector2_1.Y += vector2_2.Y;
          if ((double) vector2_1.X >= (double) -num1 && (double) vector2_1.Y >= (double) -num1 && ((double) vector2_1.X <= (double) ((int) Main.maxTilesX + num1) && (double) vector2_1.Y <= (double) ((int) Main.maxTilesX + num1)))
          {
            vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
            if ((double) vector2_2.X > (double) speed.X + 1.0)
              vector2_2.X = speed.X + 1f;
          }
          else
            goto label_42;
        }
        while ((double) vector2_2.X >= (double) speed.X - 1.0);
        vector2_2.X = speed.X - 1f;
      }
label_42:;
    }

    public static unsafe void TileRunner(int i, int j, int strength, int steps, int type, bool addTile = false, Vector2 velocity = null, bool noYChange = false, bool overRide = true)
    {
      Vector2 vector2 = new Vector2((float) i, (float) j);
      float num1 = (float) strength;
      int num2 = steps;
      float num3 = 1f / (float) steps;
      if ((double) velocity.X == 0.0 && (double) velocity.Y == 0.0)
      {
        velocity.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
        velocity.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      }
      while ((double) num1 > 0.0 && num2 > 0)
      {
        if ((double) vector2.Y < 0.0 && type == 59)
          num2 = 0;
        num1 = (float) strength * ((float) num2 * num3);
        --num2;
        int num4 = (int) ((double) vector2.Y - (double) num1 * 0.5);
        int num5 = (int) ((double) vector2.Y + (double) num1 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > (int) Main.maxTilesY)
          num5 = (int) Main.maxTilesY;
        if (num4 < num5)
        {
          int num6 = (int) ((double) vector2.X - (double) num1 * 0.5);
          int num7 = (int) ((double) vector2.X + (double) num1 * 0.5);
          if (num6 < 0)
            num6 = 0;
          if (num7 > (int) Main.maxTilesX)
            num7 = (int) Main.maxTilesX;
          Tile[,] tileArray;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
          {
            for (int index = num6; index < num7; ++index)
            {
              int num8 = num4;
              Tile* tilePtr2 = tilePtr1 + (index * 1440 + num8);
              do
              {
                if ((double) Math.Abs((float) index - vector2.X) + (double) Math.Abs((float) num8 - vector2.Y) < (double) strength * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239))
                {
                  if (WorldGen.mudWall && num8 > Main.worldSurface && (num8 < (int) Main.maxTilesY - 210 - WorldGen.genRand.Next(3) && (int) tilePtr2->wall == 0))
                    tilePtr2->wall = (byte) 15;
                  if (type < 0)
                  {
                    if (type == -2 && (int) tilePtr2->active != 0 && (num8 < WorldGen.waterLine || num8 > WorldGen.lavaLine))
                    {
                      tilePtr2->liquid = byte.MaxValue;
                      if (num8 > WorldGen.lavaLine)
                        tilePtr2->lava = (byte) 32;
                    }
                    tilePtr2->active = (byte) 0;
                  }
                  else
                  {
                    if (overRide || (int) tilePtr2->active == 0)
                    {
                      int num9 = (int) tilePtr2->type;
                      if ((type != 40 || num9 != 53) && (!Main.tileStone[type] || num9 == 1) && (num9 != 45 && num9 != 147) && (num9 != 1 || type != 59 || num8 >= Main.worldSurface + WorldGen.genRand.Next(-50, 50)))
                      {
                        if (num9 != 53 || num8 >= Main.worldSurface)
                          tilePtr2->type = (byte) type;
                        else if (type == 59)
                          tilePtr2->type = (byte) type;
                      }
                    }
                    if (addTile)
                    {
                      tilePtr2->active = (byte) 1;
                      tilePtr2->liquid = (byte) 0;
                      tilePtr2->lava = (byte) 0;
                    }
                    if (type == 59)
                    {
                      if (num8 > WorldGen.waterLine && (int) tilePtr2->liquid > 0)
                      {
                        tilePtr2->liquid = (byte) 0;
                        tilePtr2->lava = (byte) 0;
                      }
                    }
                    else if (noYChange && num8 < Main.worldSurface)
                      tilePtr2->wall = (byte) 2;
                  }
                }
                ++tilePtr2;
              }
              while (++num8 < num5);
            }
          }
        }
        vector2.X += velocity.X;
        vector2.Y += velocity.Y;
        if ((double) num1 > 50.0)
        {
          vector2.X += velocity.X;
          vector2.Y += velocity.Y;
          --num2;
          velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
          velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
          if ((double) num1 > 100.0)
          {
            vector2.X += velocity.X;
            vector2.Y += velocity.Y;
            --num2;
            velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
            velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
            if ((double) num1 > 150.0)
            {
              vector2.X += velocity.X;
              vector2.Y += velocity.Y;
              --num2;
              velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
              velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
              if ((double) num1 > 200.0)
              {
                vector2.X += velocity.X;
                vector2.Y += velocity.Y;
                --num2;
                velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                if ((double) num1 > 250.0)
                {
                  vector2.X += velocity.X;
                  vector2.Y += velocity.Y;
                  --num2;
                  velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                  velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                  if ((double) num1 > 300.0)
                  {
                    vector2.X += velocity.X;
                    vector2.Y += velocity.Y;
                    --num2;
                    velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                    velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if ((double) num1 > 400.0)
                    {
                      vector2.X += velocity.X;
                      vector2.Y += velocity.Y;
                      --num2;
                      velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                      velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                      if ((double) num1 > 500.0)
                      {
                        vector2.X += velocity.X;
                        vector2.Y += velocity.Y;
                        --num2;
                        velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                        velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if ((double) num1 > 600.0)
                        {
                          vector2.X += velocity.X;
                          vector2.Y += velocity.Y;
                          --num2;
                          velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                          velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                          if ((double) num1 > 700.0)
                          {
                            vector2.X += velocity.X;
                            vector2.Y += velocity.Y;
                            --num2;
                            velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                            velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if ((double) num1 > 800.0)
                            {
                              vector2.X += velocity.X;
                              vector2.Y += velocity.Y;
                              --num2;
                              velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                              velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                              if ((double) num1 > 900.0)
                              {
                                vector2.X += velocity.X;
                                vector2.Y += velocity.Y;
                                --num2;
                                velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
                                velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
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
        velocity.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) velocity.X > 1.0)
          velocity.X = 1f;
        else if ((double) velocity.X < -1.0)
          velocity.X = -1f;
        if (!noYChange)
        {
          velocity.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
          if ((double) velocity.Y > 1.0)
            velocity.Y = 1f;
          else if ((double) velocity.Y < -1.0)
            velocity.Y = -1f;
          if (type == 59)
          {
            int num6 = (int) vector2.Y;
            if (num6 < Main.rockLayer + 100)
              velocity.Y = 1f;
            else if (num6 > (int) Main.maxTilesY - 300)
              velocity.Y = -1f;
            else if ((double) velocity.Y > 0.5)
              velocity.Y = 0.5f;
            else if ((double) velocity.Y < -0.5)
              velocity.Y = -0.5f;
          }
        }
        else if (type != 59 && (double) num1 < 3.0)
        {
          if ((double) velocity.Y > 1.0)
            velocity.Y = 1f;
          else if ((double) velocity.Y < -1.0)
            velocity.Y = -1f;
        }
      }
    }

    public static void MudWallRunner(int i, int j)
    {
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      float num1 = (float) WorldGen.genRand.Next(5, 15);
      float num2 = (float) WorldGen.genRand.Next(5, 20);
      float num3 = num2;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      while ((double) num1 > 0.0 && (double) num3 > 0.0)
      {
        float num4 = num1 * (num3 / num2);
        --num3;
        int num5 = (int) ((double) vector2_1.X - (double) num4 * 0.5);
        int num6 = (int) ((double) vector2_1.X + (double) num4 * 0.5);
        int num7 = (int) ((double) vector2_1.Y - (double) num4 * 0.5);
        int num8 = (int) ((double) vector2_1.Y + (double) num4 * 0.5);
        if (num5 < 0)
          num5 = 0;
        if (num6 > (int) Main.maxTilesX)
          num6 = (int) Main.maxTilesX;
        if (num7 < 0)
          num7 = 0;
        if (num8 > (int) Main.maxTilesY)
          num8 = (int) Main.maxTilesY;
        for (int index1 = num5; index1 < num6; ++index1)
        {
          float num9 = Math.Abs((float) index1 - vector2_1.X);
          for (int index2 = num7; index2 < num8; ++index2)
          {
            if ((double) num9 + (double) Math.Abs((float) index2 - vector2_1.Y) < (double) num1 * 0.5 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.0149999996647239))
              Main.tile[index1, index2].wall = (byte) 0;
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        else if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.Y > 1.0)
          vector2_2.Y = 1f;
        else if ((double) vector2_2.Y < -1.0)
          vector2_2.Y = -1f;
      }
    }

    public static void FloatingIsland(int i, int j)
    {
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      float num1 = (float) WorldGen.genRand.Next(80, 120);
      float num2 = (float) WorldGen.genRand.Next(20, 25);
      vector2_2.X = (float) WorldGen.genRand.Next(-20, 21) * 0.2f;
      while ((double) vector2_2.X > -2.0 && (double) vector2_2.X < 2.0)
        vector2_2.X = (float) WorldGen.genRand.Next(-20, 21) * 0.2f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.02f;
      while ((double) num1 > 0.0 && (double) num2 > 0.0)
      {
        num1 -= (float) WorldGen.genRand.Next(4);
        --num2;
        int num3 = (int) ((double) vector2_1.X - (double) num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + (double) num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - (double) num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + (double) num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesX)
          num4 = (int) Main.maxTilesX;
        if (num6 > (int) Main.maxTilesY)
          num6 = (int) Main.maxTilesY;
        float num7 = (float) ((double) num1 * (double) WorldGen.genRand.Next(80, 120) * 0.00999999977648258);
        float num8 = num7 * 0.4f;
        float num9 = num8 * num8;
        int num10 = (int) vector2_1.Y + 1;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          if (WorldGen.genRand.Next(2) == 0)
            num10 += WorldGen.genRand.Next(-1, 2);
          if (num10 < (int) vector2_1.Y)
            num10 = (int) vector2_1.Y;
          else if (num10 > (int) vector2_1.Y + 2)
            num10 = (int) vector2_1.Y + 2;
          float num11 = (float) index1 - vector2_1.X;
          float num12 = num11 * num11;
          for (int index2 = num5 < num10 ? num10 : num5; index2 < num6; ++index2)
          {
            float num13 = (float) (((double) index2 - (double) vector2_1.Y) * 2.0);
            if ((double) (num12 + num13 * num13) < (double) num9)
            {
              Main.tile[index1, index2].active = (byte) 1;
              if ((int) Main.tile[index1, index2].type == 59)
                Main.tile[index1, index2].type = (byte) 0;
            }
          }
        }
        WorldGen.TileRunner(WorldGen.genRand.Next(num3 + 10, num4 - 10), (int) ((double) vector2_1.Y + (double) num7 * 0.100000001490116 + 5.0), WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(10, 15), 0, true, new Vector2(0.0f, 2f), true, true);
        int num14 = (int) ((double) vector2_1.X - (double) num1 * 0.400000005960464);
        int num15 = (int) ((double) vector2_1.X + (double) num1 * 0.400000005960464);
        int num16 = (int) ((double) vector2_1.Y - (double) num1 * 0.400000005960464);
        int num17 = (int) ((double) vector2_1.Y + (double) num1 * 0.400000005960464);
        int num18 = (int) vector2_1.Y + 2;
        if (num14 < 0)
          num14 = 0;
        if (num15 > (int) Main.maxTilesX)
          num15 = (int) Main.maxTilesX;
        if (num16 < num18)
          num16 = num18;
        if (num17 > (int) Main.maxTilesY)
          num17 = (int) Main.maxTilesY;
        float num19 = (float) ((double) num1 * (double) WorldGen.genRand.Next(80, 120) * 0.00999999977648258) * 0.4f;
        float num20 = num19 * num19;
        for (int index1 = num14; index1 < num15; ++index1)
        {
          float num11 = (float) index1 - vector2_1.X;
          float num12 = num11 * num11;
          for (int index2 = num16; index2 < num17; ++index2)
          {
            float num13 = (float) (((double) index2 - (double) vector2_1.Y) * 2.0);
            if ((double) (num12 + num13 * num13) < (double) num20)
              Main.tile[index1, index2].wall = (byte) 2;
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 1.0)
          vector2_2.X = 1f;
        else if ((double) vector2_2.X < -1.0)
          vector2_2.X = -1f;
        if ((double) vector2_2.Y > 0.200000002980232)
          vector2_2.Y = -0.2f;
        else if ((double) vector2_2.Y < -0.200000002980232)
          vector2_2.Y = -0.2f;
      }
    }

    public static void Caverer(int X, int Y)
    {
      int num = WorldGen.genRand.Next(2);
      double xDir1 = (double) WorldGen.genRand.Next(100) * 0.01;
      double yDir1 = 1.0 - xDir1;
      if (WorldGen.genRand.Next(2) == 0)
        xDir1 = -xDir1;
      if (WorldGen.genRand.Next(2) == 0)
        yDir1 = -yDir1;
      Vector2 pos1 = new Vector2((float) X, (float) Y);
      if (num == 0)
      {
        for (int index = WorldGen.genRand.Next(6, 8); index >= 0; --index)
        {
          WorldGen.digTunnel(ref pos1, xDir1, yDir1, WorldGen.genRand.Next(6, 20), WorldGen.genRand.Next(4, 9), false);
          xDir1 += (double) WorldGen.genRand.Next(-20, 21) * 0.1;
          yDir1 += (double) WorldGen.genRand.Next(-20, 21) * 0.1;
          if (xDir1 < -1.5)
            xDir1 = -1.5;
          else if (xDir1 > 1.5)
            xDir1 = 1.5;
          if (yDir1 < -1.5)
            yDir1 = -1.5;
          else if (yDir1 > 1.5)
            yDir1 = 1.5;
          double xDir2 = (double) WorldGen.genRand.Next(100) * 0.01;
          double yDir2 = 1.0 - xDir2;
          if (WorldGen.genRand.Next(2) == 0)
            xDir2 = -xDir2;
          if (WorldGen.genRand.Next(2) == 0)
            yDir2 = -yDir2;
          Vector2 pos2 = pos1;
          WorldGen.digTunnel(ref pos2, xDir2, yDir2, WorldGen.genRand.Next(30, 50), WorldGen.genRand.Next(3, 6), false);
          WorldGen.TileRunner((int) pos2.X, (int) pos2.Y, WorldGen.genRand.Next(10, 20), WorldGen.genRand.Next(5, 10), -1, false, new Vector2(), false, true);
        }
      }
      else
      {
        for (int index = WorldGen.genRand.Next(14, 29); index >= 0; --index)
        {
          WorldGen.digTunnel(ref pos1, xDir1, yDir1, WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(2, 6), true);
          xDir1 += (double) WorldGen.genRand.Next(-20, 21) * 0.1;
          yDir1 += (double) WorldGen.genRand.Next(-20, 21) * 0.1;
          if (xDir1 < -1.5)
            xDir1 = -1.5;
          else if (xDir1 > 1.5)
            xDir1 = 1.5;
          if (yDir1 < -1.5)
            yDir1 = -1.5;
          else if (yDir1 > 1.5)
            yDir1 = 1.5;
        }
      }
    }

    public static void digTunnel(ref Vector2 pos, double xDir, double yDir, int Steps, int Size, bool Wet = false)
    {
      try
      {
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = (double) Size;
        while (Steps > 0)
        {
          --Steps;
          for (int index1 = (int) ((double) pos.X - num3); (double) index1 <= (double) pos.X + num3; ++index1)
          {
            float num4 = Math.Abs((float) index1 - pos.X);
            for (int index2 = (int) ((double) pos.Y - num3); (double) index2 <= (double) pos.Y + num3; ++index2)
            {
              if ((double) num4 + (double) Math.Abs((float) index2 - pos.Y) < num3 * (1.0 + (double) WorldGen.genRand.Next(-10, 11) * 0.005))
              {
                Main.tile[index1, index2].active = (byte) 0;
                if (Wet)
                  Main.tile[index1, index2].liquid = byte.MaxValue;
              }
            }
          }
          num3 += (double) WorldGen.genRand.Next(-50, 51) * 0.03;
          if (num3 < (double) Size * 0.6)
            num3 = (double) Size * 0.6;
          else if (num3 > (double) (Size * 2))
            num3 = (double) (Size * 2);
          num1 += (double) WorldGen.genRand.Next(-20, 21) * 0.01;
          num2 += (double) WorldGen.genRand.Next(-20, 21) * 0.01;
          if (num1 < -1.0)
            num1 = -1.0;
          else if (num1 > 1.0)
            num1 = 1.0;
          if (num2 < -1.0)
            num2 = -1.0;
          else if (num2 > 1.0)
            num2 = 1.0;
          pos.X = pos.X + (float) ((xDir + num1) * 0.6);
          pos.Y = pos.Y + (float) ((yDir + num2) * 0.6);
        }
      }
      catch
      {
      }
    }

    public static void IslandHouse(int i, int j)
    {
      byte num1 = (byte) WorldGen.genRand.Next(45, 48);
      byte num2 = (byte) WorldGen.genRand.Next(10, 13);
      Vector2 vector2 = new Vector2((float) i, (float) j);
      int num3 = 1;
      if (WorldGen.genRand.Next(2) == 0)
        num3 = -1;
      int num4 = WorldGen.genRand.Next(7, 12);
      int num5 = WorldGen.genRand.Next(5, 7);
      vector2.X = (float) (i + (num4 + 2) * num3);
      for (int index = j - 15; index < j + 30; ++index)
      {
        if ((int) Main.tile[(int) vector2.X, index].active != 0)
        {
          vector2.Y = (float) (index - 1);
          break;
        }
      }
      vector2.X = (float) i;
      int num6 = (int) ((double) vector2.X - (double) num4 - 2.0);
      int num7 = (int) ((double) vector2.X + (double) num4 + 2.0);
      int num8 = (int) ((double) vector2.Y - (double) num5 - 2.0);
      int num9 = (int) ((double) vector2.Y + 2.0 + (double) WorldGen.genRand.Next(3, 5));
      if (num6 < 0)
        num6 = 0;
      if (num7 > (int) Main.maxTilesX)
        num7 = (int) Main.maxTilesX;
      if (num8 < 0)
        num8 = 0;
      if (num9 > (int) Main.maxTilesY)
        num9 = (int) Main.maxTilesY;
      for (int index1 = num6; index1 <= num7; ++index1)
      {
        for (int index2 = num8; index2 < num9; ++index2)
        {
          Main.tile[index1, index2].active = (byte) 1;
          Main.tile[index1, index2].type = num1;
          Main.tile[index1, index2].wall = (byte) 0;
        }
      }
      int num10 = (int) ((double) vector2.X - (double) num4);
      int num11 = (int) ((double) vector2.X + (double) num4);
      int num12 = (int) ((double) vector2.Y - (double) num5);
      int num13 = (int) ((double) vector2.Y + 1.0);
      if (num10 < 0)
        num10 = 0;
      if (num11 > (int) Main.maxTilesX)
        num11 = (int) Main.maxTilesX;
      if (num12 < 0)
        num12 = 0;
      if (num13 > (int) Main.maxTilesY)
        num13 = (int) Main.maxTilesY;
      for (int index1 = num10; index1 <= num11; ++index1)
      {
        for (int index2 = num12; index2 < num13; ++index2)
        {
          if ((int) Main.tile[index1, index2].wall == 0)
          {
            Main.tile[index1, index2].active = (byte) 0;
            Main.tile[index1, index2].wall = num2;
          }
        }
      }
      int i1 = i + (num4 + 1) * num3;
      int j1 = (int) vector2.Y;
      for (int index = i1 - 2; index <= i1 + 2; ++index)
      {
        Main.tile[index, j1].active = (byte) 0;
        Main.tile[index, j1 - 1].active = (byte) 0;
        Main.tile[index, j1 - 2].active = (byte) 0;
      }
      WorldGen.PlaceTile(i1, j1, 10, true, false, -1, 0);
      int contain = 0;
      int num14 = WorldGen.houseCount;
      if (num14 > 2)
        num14 = WorldGen.genRand.Next(3);
      if (num14 == 0)
        contain = 159;
      else if (num14 == 1)
        contain = 65;
      else if (num14 == 2)
        contain = 158;
      WorldGen.AddBuriedChest(i, j1 - 3, contain, false, 2);
      ++WorldGen.houseCount;
    }

    public static void Mountinater(int i, int j)
    {
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(80, 120);
      float num2 = (float) WorldGen.genRand.Next(40, 55);
      vector2_1.Y += num2 * 0.5f;
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.1f;
      while (num1 > 0.0 && (double) num2 > 0.0)
      {
        num1 -= (double) WorldGen.genRand.Next(4);
        --num2;
        int num3 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num4 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num5 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num3 < 0)
          num3 = 0;
        if (num4 > (int) Main.maxTilesX)
          num4 = (int) Main.maxTilesX;
        if (num5 < 0)
          num5 = 0;
        if (num6 > (int) Main.maxTilesY)
          num6 = (int) Main.maxTilesY;
        double num7 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01 * 0.4;
        double num8 = num7 * num7;
        for (int index1 = num3; index1 < num4; ++index1)
        {
          double num9 = (double) index1 - (double) vector2_1.X;
          double num10 = num9 * num9;
          for (int index2 = num5; index2 < num6; ++index2)
          {
            double num11 = (double) index2 - (double) vector2_1.Y;
            if (num10 + num11 * num11 < num8 && (int) Main.tile[index1, index2].active == 0)
            {
              Main.tile[index1, index2].active = (byte) 1;
              Main.tile[index1, index2].type = (byte) 0;
            }
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 0.5)
          vector2_2.X = 0.5f;
        else if ((double) vector2_2.X < -0.5)
          vector2_2.X = -0.5f;
        if ((double) vector2_2.Y > -0.5)
          vector2_2.Y = -0.5f;
        else if ((double) vector2_2.Y < -1.5)
          vector2_2.Y = -1.5f;
      }
    }

    public static void Lakinater(int i, int j)
    {
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(25, 50);
      double num2 = num1;
      double num3 = (double) WorldGen.genRand.Next(30, 80);
      if (WorldGen.genRand.Next(5) == 0)
      {
        num1 *= 1.5;
        num2 *= 1.5;
        num3 *= 1.2;
      }
      vector2_1.Y = vector2_1.Y - (float) (num3 * 0.3);
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.1f;
      while (num1 > 0.0 && num3 > 0.0)
      {
        if ((double) vector2_1.Y + num2 * 0.5 > (double) Main.worldSurface)
          num3 = 0.0;
        num1 -= (double) WorldGen.genRand.Next(3);
        --num3;
        int num4 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num5 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num7 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > (int) Main.maxTilesX)
          num5 = (int) Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > (int) Main.maxTilesY)
          num7 = (int) Main.maxTilesY;
        double num8 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01 * 0.4;
        num2 = num8 * num8;
        for (int index1 = num4; index1 < num5; ++index1)
        {
          double num9 = (double) index1 - (double) vector2_1.X;
          double num10 = num9 * num9;
          for (int index2 = num6; index2 < num7; ++index2)
          {
            double num11 = (double) index2 - (double) vector2_1.Y;
            if (num10 + num11 * num11 < num2 && (int) Main.tile[index1, index2].active != 0)
            {
              Main.tile[index1, index2].active = (byte) 0;
              Main.tile[index1, index2].liquid = byte.MaxValue;
            }
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > 0.5)
          vector2_2.X = 0.5f;
        else if ((double) vector2_2.X < -0.5)
          vector2_2.X = -0.5f;
        if ((double) vector2_2.Y > 1.5)
          vector2_2.Y = 1.5f;
        else if ((double) vector2_2.Y < 0.5)
          vector2_2.Y = 0.5f;
      }
    }

    public static void ShroomPatch(int i, int j)
    {
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(40, 70);
      double num2 = num1;
      double num3 = (double) WorldGen.genRand.Next(20, 30);
      if (WorldGen.genRand.Next(5) == 0)
      {
        num1 *= 1.5;
        double num4 = num2 * 1.5;
        num3 *= 1.2;
      }
      vector2_1.Y -= (float) (num3 * 0.3);
      vector2_2.X = (float) WorldGen.genRand.Next(-10, 11) * 0.1f;
      vector2_2.Y = (float) WorldGen.genRand.Next(-20, -10) * 0.1f;
      while (num1 > 0.0 && num3 > 0.0)
      {
        num1 -= (double) WorldGen.genRand.Next(3);
        --num3;
        int num4 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num5 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num7 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > (int) Main.maxTilesX)
          num5 = (int) Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > (int) Main.maxTilesY)
          num7 = (int) Main.maxTilesY;
        double num8 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01;
        float num9 = (float) num8 * 0.4f;
        float num10 = num9 * num9;
        for (int index1 = num4; index1 < num5; ++index1)
        {
          float num11 = (float) index1 - vector2_1.X;
          float num12 = num11 * num11;
          for (int index2 = num6; index2 < num7; ++index2)
          {
            float num13 = (float) (((double) index2 - (double) vector2_1.Y) * 2.29999995231628);
            if ((double) (num12 + num13 * num13) < (double) num10)
            {
              if ((double) index2 < (double) vector2_1.Y + num8 * 0.02)
              {
                if ((int) Main.tile[index1, index2].type != 59)
                  Main.tile[index1, index2].active = (byte) 0;
              }
              else
                Main.tile[index1, index2].type = (byte) 59;
              Main.tile[index1, index2].liquid = (byte) 0;
              Main.tile[index1, index2].lava = (byte) 0;
            }
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y -= (float) WorldGen.genRand.Next(11) * 0.05f;
        if ((double) vector2_2.X > -0.5 && (double) vector2_2.X < 0.5)
          vector2_2.X = (double) vector2_2.X >= 0.0 ? 0.5f : -0.5f;
        if ((double) vector2_2.X > 2.0)
          vector2_2.X = 1f;
        else if ((double) vector2_2.X < -2.0)
          vector2_2.X = -1f;
        if ((double) vector2_2.Y > 1.0)
          vector2_2.Y = 1f;
        else if ((double) vector2_2.Y < -1.0)
          vector2_2.Y = -1f;
        int num14 = (int) vector2_1.X;
        int num15 = (int) vector2_1.Y;
        for (int index = 0; index < 2; ++index)
        {
          int i1;
          int j1;
          do
          {
            i1 = num14 + WorldGen.genRand.Next(-20, 20);
            j1 = num15 + WorldGen.genRand.Next(20);
          }
          while ((int) Main.tile[i1, j1].active == 0 && (int) Main.tile[i1, j1].type != 59);
          int strength = WorldGen.genRand.Next(7, 10);
          int steps = WorldGen.genRand.Next(7, 10);
          WorldGen.TileRunner(i1, j1, strength, steps, 59, false, new Vector2(0.0f, 2f), true, true);
          if (WorldGen.genRand.Next(3) == 0)
            WorldGen.TileRunner(i1, j1, strength - 3, steps - 3, -1, false, new Vector2(0.0f, 2f), true, true);
        }
      }
    }

    public static void Cavinator(int i, int j, int steps)
    {
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2();
      double num1 = (double) WorldGen.genRand.Next(7, 15);
      int num2 = 1;
      if (WorldGen.genRand.Next(2) == 0)
        num2 = -1;
      int num3 = WorldGen.genRand.Next(20, 40);
      vector2_2.Y = (float) WorldGen.genRand.Next(10, 20) * 0.01f;
      vector2_2.X = (float) num2;
      while (num3 > 0)
      {
        --num3;
        int num4 = (int) ((double) vector2_1.X - num1 * 0.5);
        int num5 = (int) ((double) vector2_1.X + num1 * 0.5);
        int num6 = (int) ((double) vector2_1.Y - num1 * 0.5);
        int num7 = (int) ((double) vector2_1.Y + num1 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > (int) Main.maxTilesX)
          num5 = (int) Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > (int) Main.maxTilesY)
          num7 = (int) Main.maxTilesY;
        double num8 = num1 * (double) WorldGen.genRand.Next(80, 120) * 0.01 * 0.4;
        double num9 = num8 * num8;
        for (int index1 = num4; index1 < num5; ++index1)
        {
          double num10 = (double) index1 - (double) vector2_1.X;
          double num11 = num10 * num10;
          for (int index2 = num6; index2 < num7; ++index2)
          {
            double num12 = (double) index2 - (double) vector2_1.Y;
            if (num11 + num12 * num12 < num9)
              Main.tile[index1, index2].active = (byte) 0;
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > (double) num2 + 0.5)
          vector2_2.X = (float) num2 + 0.5f;
        else if ((double) vector2_2.X < (double) num2 - 0.5)
          vector2_2.X = (float) num2 - 0.5f;
        if ((double) vector2_2.Y > 2.0)
          vector2_2.Y = 2f;
        else if ((double) vector2_2.Y < 0.0)
          vector2_2.Y = 0.0f;
      }
      if (steps <= 0 || (int) vector2_1.Y >= Main.rockLayer + 50)
        return;
      WorldGen.Cavinator((int) vector2_1.X, (int) vector2_1.Y, steps - 1);
    }

    public static void CaveOpenater(int i, int j)
    {
      int num1 = (WorldGen.genRand.Next(2) << 1) - 1;
      Vector2 vector2_1 = new Vector2((float) i, (float) j);
      Vector2 vector2_2 = new Vector2(0.0f, (float) num1);
      double num2 = (double) WorldGen.genRand.Next(7, 12);
      int num3 = 100;
      do
      {
        if ((int) Main.tile[(int) vector2_1.X, (int) vector2_1.Y].wall == 0)
          num3 = 0;
        else
          --num3;
        int num4 = (int) ((double) vector2_1.X - num2 * 0.5);
        int num5 = (int) ((double) vector2_1.X + num2 * 0.5);
        int num6 = (int) ((double) vector2_1.Y - num2 * 0.5);
        int num7 = (int) ((double) vector2_1.Y + num2 * 0.5);
        if (num4 < 0)
          num4 = 0;
        if (num5 > (int) Main.maxTilesX)
          num5 = (int) Main.maxTilesX;
        if (num6 < 0)
          num6 = 0;
        if (num7 > (int) Main.maxTilesY)
          num7 = (int) Main.maxTilesY;
        double num8 = num2 * (double) WorldGen.genRand.Next(80, 120) * 0.01 * 0.4;
        double num9 = num8 * num8;
        for (int index1 = num4; index1 < num5; ++index1)
        {
          double num10 = (double) index1 - (double) vector2_1.X;
          double num11 = num10 * num10;
          for (int index2 = num6; index2 < num7; ++index2)
          {
            double num12 = (double) index2 - (double) vector2_1.Y;
            if (num11 + num12 * num12 < num9)
              Main.tile[index1, index2].active = (byte) 0;
          }
        }
        vector2_1.X += vector2_2.X;
        vector2_1.Y += vector2_2.Y;
        vector2_2.X += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        vector2_2.Y += (float) WorldGen.genRand.Next(-10, 11) * 0.05f;
        if ((double) vector2_2.X > (double) num1 + 0.5)
          vector2_2.X = (float) num1 + 0.5f;
        else if ((double) vector2_2.X < (double) num1 - 0.5)
          vector2_2.X = (float) num1 - 0.5f;
        if ((double) vector2_2.Y > 0.0)
          vector2_2.Y = 0.0f;
        else if ((double) vector2_2.Y < -0.5)
          vector2_2.Y = -0.5f;
      }
      while (num3 > 0);
    }

    public static void SquareTileFrame(int i, int j, int frameNumber = -1)
    {
      if (WorldGen.gen)
        return;
      bool flag = WorldGen.tileFrameRecursion;
      WorldGen.tileFrameRecursion = false;
      WorldGen.TileFrame(i - 1, j - 1, 0);
      WorldGen.TileFrame(i - 1, j, 0);
      WorldGen.TileFrame(i - 1, j + 1, 0);
      WorldGen.TileFrame(i, j - 1, 0);
      WorldGen.TileFrame(i, j, frameNumber);
      WorldGen.TileFrame(i, j + 1, 0);
      WorldGen.TileFrame(i + 1, j - 1, 0);
      WorldGen.TileFrame(i + 1, j, 0);
      WorldGen.TileFrame(i + 1, j + 1, 0);
      WorldGen.tileFrameRecursion = flag;
    }

    public static void SquareTileFrameNoLiquid(int i, int j, int frameNumber = -1)
    {
      WorldGen.TileFrameNoLiquid(i - 1, j - 1, 0);
      WorldGen.TileFrameNoLiquid(i - 1, j, 0);
      WorldGen.TileFrameNoLiquid(i - 1, j + 1, 0);
      WorldGen.TileFrameNoLiquid(i, j - 1, 0);
      WorldGen.TileFrameNoLiquid(i, j, frameNumber);
      WorldGen.TileFrameNoLiquid(i, j + 1, 0);
      WorldGen.TileFrameNoLiquid(i + 1, j - 1, 0);
      WorldGen.TileFrameNoLiquid(i + 1, j, 0);
      WorldGen.TileFrameNoLiquid(i + 1, j + 1, 0);
    }

    public static void SquareWallFrame(int i, int j, bool resetFrame = true)
    {
      WorldGen.WallFrame(i - 1, j - 1, false);
      WorldGen.WallFrame(i - 1, j, false);
      WorldGen.WallFrame(i - 1, j + 1, false);
      WorldGen.WallFrame(i, j - 1, false);
      WorldGen.WallFrame(i, j, resetFrame);
      WorldGen.WallFrame(i, j + 1, false);
      WorldGen.WallFrame(i + 1, j - 1, false);
      WorldGen.WallFrame(i + 1, j, false);
      WorldGen.WallFrame(i + 1, j + 1, false);
    }

    public static void SectionTileFrame(int startX, int startY)
    {
      int num1 = startX;
      int num2 = startX + 40;
      int num3 = startY;
      int num4 = startY + 30;
      if (num1 < 6)
        num1 = 6;
      if (num3 < 6)
        num3 = 6;
      if (num1 > (int) Main.maxTilesX - 6)
        num1 = (int) Main.maxTilesX - 6;
      if (num3 > (int) Main.maxTilesY - 6)
        num3 = (int) Main.maxTilesY - 6;
      WorldGen.tileFrameRecursion = false;
      for (int i = num1 - 1; i < num2 + 1; ++i)
      {
        for (int j = num3 - 1; j < num4 + 1; ++j)
        {
          int index = (int) Main.tile[i, j].type;
          if (index == 4 || !Main.tileFrameImportant[index])
            WorldGen.TileFrame(i, j, -1);
          WorldGen.WallFrame(i, j, true);
        }
      }
      WorldGen.tileFrameRecursion = true;
    }

    public static void RangeFrame(int startX, int startY, int endX, int endY)
    {
      if (WorldGen.gen)
        return;
      bool flag = WorldGen.tileFrameRecursion;
      WorldGen.tileFrameRecursion = false;
      for (int i = startX - 1; i < endX + 2; ++i)
      {
        for (int j = startY - 1; j < endY + 2; ++j)
        {
          WorldGen.TileFrame(i, j, 0);
          WorldGen.WallFrame(i, j, false);
        }
      }
      WorldGen.tileFrameRecursion = flag;
    }

    public static unsafe void WaterCheck()
    {
      Liquid.numLiquid = 0;
      LiquidBuffer.numLiquidBuffer = 0;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int index = (int) Main.maxTilesX - 2; index > 0; --index)
        {
          Tile* tilePtr2 = tilePtr1 + (index * 1440 + (int) Main.maxTilesY - 2);
          int num = (int) Main.maxTilesY - 2;
          while (num > 0)
          {
            tilePtr2->checkingLiquid = 0;
            if ((int) tilePtr2->liquid > 0)
            {
              if ((int) tilePtr2->active != 0 && Main.tileSolidNotSolidTop[(int) tilePtr2->type])
              {
                tilePtr2->liquid = (byte) 0;
              }
              else
              {
                if ((int) tilePtr2->active != 0)
                {
                  if (Main.tileWaterDeath[(int) tilePtr2->type] && ((int) tilePtr2->type != 4 || (int) tilePtr2->frameY != 176))
                    WorldGen.KillTile(index, num);
                  if ((int) tilePtr2->lava != 0 && Main.tileLavaDeath[(int) tilePtr2->type])
                    WorldGen.KillTile(index, num);
                }
                Tile* tilePtr3 = tilePtr2 + 1;
                if (((int) tilePtr3->active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr3->type]) && (int) tilePtr3->liquid < (int) byte.MaxValue)
                {
                  if ((int) tilePtr3->liquid > 250)
                    tilePtr3->liquid = byte.MaxValue;
                  else
                    Liquid.AddWater(index, num);
                }
                Tile* tilePtr4 = tilePtr2 - 1440;
                if (((int) tilePtr4->active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr4->type]) && (int) tilePtr4->liquid != (int) tilePtr2->liquid)
                {
                  Liquid.AddWater(index, num);
                }
                else
                {
                  Tile* tilePtr5 = tilePtr2 + 1440;
                  if (((int) tilePtr5->active == 0 || !Main.tileSolidNotSolidTop[(int) tilePtr5->type]) && (int) tilePtr5->liquid != (int) tilePtr2->liquid)
                    Liquid.AddWater(index, num);
                }
                if ((int) tilePtr2->lava != 0)
                {
                  Tile* tilePtr5 = tilePtr2 - 1;
                  if ((int) tilePtr5->liquid > 0 && (int) tilePtr5->lava == 0)
                  {
                    Liquid.AddWater(index, num);
                  }
                  else
                  {
                    Tile* tilePtr6 = tilePtr2 + 1;
                    if ((int) tilePtr6->liquid > 0 && (int) tilePtr6->lava == 0)
                    {
                      Liquid.AddWater(index, num);
                    }
                    else
                    {
                      Tile* tilePtr7 = tilePtr2 - 1440;
                      if ((int) tilePtr7->liquid > 0 && (int) tilePtr7->lava == 0)
                      {
                        Liquid.AddWater(index, num);
                      }
                      else
                      {
                        Tile* tilePtr8 = tilePtr2 + 1440;
                        if ((int) tilePtr8->liquid > 0 && (int) tilePtr8->lava == 0)
                          Liquid.AddWater(index, num);
                      }
                    }
                  }
                }
              }
            }
            --num;
            --tilePtr2;
          }
        }
      }
    }

    public static unsafe void everyTileFrame()
    {
      UI.main.NextProgressStep(Lang.gen[55]);
      WorldGen.gen = true;
      Tile[,] tileArray;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
      {
        for (int i = 0; i < (int) Main.maxTilesX; ++i)
        {
          if ((i & 63) == 0)
            UI.main.progress = (float) i / (float) Main.maxTilesX;
          Tile* tilePtr2 = tilePtr1 + (1440 * i + (int) Main.maxTilesY);
          for (int j = (int) Main.maxTilesY - 1; j >= 0; --j)
          {
            --tilePtr2;
            if ((int) tilePtr2->active != 0)
              WorldGen.TileFrameNoLiquid(i, j, -1);
            if ((int) tilePtr2->wall > 0)
              WorldGen.WallFrame(i, j, true);
          }
        }
      }
      WorldGen.gen = false;
    }

    private static void PlantCheck(int i, int j)
    {
      int num1 = -1;
      int num2 = (int) Main.tile[i, j].type;
      if (j + 1 >= (int) Main.maxTilesY)
        num1 = num2;
      if (j + 1 < (int) Main.maxTilesY && (int) Main.tile[i, j + 1].active != 0)
        num1 = (int) Main.tile[i, j + 1].type;
      if ((num2 != 3 || num1 == 2 || num1 == 78) && ((num2 != 24 || num1 == 23) && (num2 != 61 || num1 == 60)) && ((num2 != 71 || num1 == 70) && (num2 != 73 || num1 == 2 || num1 == 78)) && ((num2 != 74 || num1 == 60) && (num2 != 110 || num1 == 109) && (num2 != 113 || num1 == 109)))
        return;
      if (num1 == 23)
      {
        num2 = 24;
        if ((int) Main.tile[i, j].frameX >= 162)
          Main.tile[i, j].frameX = (short) 126;
      }
      else if (num1 == 2)
        num2 = num2 != 113 ? 3 : 73;
      else if (num1 == 109)
        num2 = num2 != 73 ? 110 : 113;
      if (num2 != (int) Main.tile[i, j].type)
        Main.tile[i, j].type = (byte) num2;
      else
        WorldGen.KillTile(i, j);
    }

    public static unsafe void WallFrame(int i, int j, bool resetFrame = false)
    {
      if (i < 0 || j < 0 || (i >= (int) Main.maxTilesX || j >= (int) Main.maxTilesY))
        return;
      fixed (Tile* tilePtr = &Main.tile[i, j])
      {
        int num1 = (int) tilePtr->wall;
        if (num1 == 0)
          return;
        int num2 = num1;
        int num3 = num1;
        int num4 = num1;
        int num5 = num1;
        int num6 = num1;
        int num7 = num1;
        int num8 = num1;
        int num9 = num1;
        int num10 = (int) tilePtr->wallFrameX;
        int num11 = (int) tilePtr->wallFrameY;
        int num12 = -1;
        int num13 = -1;
        if (j - 1 >= 0)
          num3 = (int) tilePtr[-1].wall;
        if (j + 1 < (int) Main.maxTilesY)
          num8 = (int) tilePtr[1].wall;
        if (i - 1 >= 0)
        {
          num5 = (int) tilePtr[-1440].wall;
          if (j - 1 >= 0)
            num2 = (int) tilePtr[-1441].wall;
          if (j + 1 < (int) Main.maxTilesY)
            num7 = (int) tilePtr[-1439].wall;
        }
        if (i + 1 < (int) Main.maxTilesX)
        {
          num6 = (int) tilePtr[1440].wall;
          if (j - 1 >= 0)
            num4 = (int) tilePtr[1439].wall;
          if (j + 1 < (int) Main.maxTilesY)
            num9 = (int) tilePtr[1441].wall;
        }
        if (num1 == 2 && j >= Main.worldSurface)
        {
          num8 = num1;
          num7 = num1;
          num9 = num1;
          if (j > Main.worldSurface)
          {
            num3 = num1;
            num2 = num1;
            num4 = num1;
            num5 = num1;
            num6 = num1;
          }
        }
        else
        {
          if (num8 > 0)
            num8 = num1;
          if (num7 > 0)
            num7 = num1;
          if (num9 > 0)
            num9 = num1;
        }
        if (num3 > 0)
          num3 = num1;
        if (num2 > 0)
          num2 = num1;
        if (num4 > 0)
          num4 = num1;
        if (num5 > 0)
          num5 = num1;
        if (num6 > 0)
          num6 = num1;
        int num14;
        if (resetFrame)
        {
          num14 = WorldGen.genRand.Next(3);
          Main.tile[i, j].wallFrameNumber = num14;
        }
        else
          num14 = Main.tile[i, j].wallFrameNumber;
        if (num12 < 0 || num13 < 0)
        {
          if (num3 == num1 && num8 == num1 && num5 == num1 & num6 == num1)
          {
            if (num2 != num1 && num4 != num1)
            {
              num12 = 108 + num14 * 18;
              num13 = 18;
            }
            else if (num7 != num1 && num9 != num1)
            {
              num12 = 108 + num14 * 18;
              num13 = 36;
            }
            else if (num2 != num1 && num7 != num1)
            {
              num12 = 180;
              num13 = num14 * 18;
            }
            else if (num4 != num1 && num9 != num1)
            {
              num12 = 198;
              num13 = num14 * 18;
            }
            else
            {
              num12 = 18 + num14 * 18;
              num13 = 18;
            }
          }
          else if (num3 != num1 && num8 == num1 && num5 == num1 & num6 == num1)
          {
            num12 = 18 + num14 * 18;
            num13 = 0;
          }
          else if (num3 == num1 && num8 != num1 && num5 == num1 & num6 == num1)
          {
            num12 = 18 + num14 * 18;
            num13 = 36;
          }
          else if (num3 == num1 && num8 == num1 && num5 != num1 & num6 == num1)
          {
            num12 = 0;
            num13 = num14 * 18;
          }
          else if (num3 == num1 && num8 == num1 && num5 == num1 & num6 != num1)
          {
            num12 = 72;
            num13 = num14 * 18;
          }
          else if (num3 != num1 && num8 == num1 && num5 != num1 & num6 == num1)
          {
            num12 = num14 * 36;
            num13 = 54;
          }
          else if (num3 != num1 && num8 == num1 && num5 == num1 & num6 != num1)
          {
            num12 = 18 + num14 * 36;
            num13 = 54;
          }
          else if (num3 == num1 && num8 != num1 && num5 != num1 & num6 == num1)
          {
            num12 = num14 * 36;
            num13 = 72;
          }
          else if (num3 == num1 && num8 != num1 && num5 == num1 & num6 != num1)
          {
            num12 = 18 + num14 * 36;
            num13 = 72;
          }
          else if (num3 == num1 && num8 == num1 && num5 != num1 & num6 != num1)
          {
            num12 = 90;
            num13 = num14 * 18;
          }
          else if (num3 != num1 && num8 != num1 && num5 == num1 & num6 == num1)
          {
            num12 = 108 + num14 * 18;
            num13 = 72;
          }
          else if (num3 != num1 && num8 == num1 && num5 != num1 & num6 != num1)
          {
            num12 = 108 + num14 * 18;
            num13 = 0;
          }
          else if (num3 == num1 && num8 != num1 && num5 != num1 & num6 != num1)
          {
            num12 = 108 + num14 * 18;
            num13 = 54;
          }
          else if (num3 != num1 && num8 != num1 && num5 != num1 & num6 == num1)
          {
            num12 = 162;
            num13 = num14 * 18;
          }
          else if (num3 != num1 && num8 != num1 && num5 == num1 & num6 != num1)
          {
            num12 = 216;
            num13 = num14 * 18;
          }
          else if (num3 != num1 && num8 != num1 && num5 != num1 & num6 != num1)
          {
            num12 = 162 + num14 * 18;
            num13 = 54;
          }
        }
        if (num12 < 0 || num13 < 0)
        {
          num12 = 18 + num14 * 18;
          num13 = 18;
        }
        tilePtr->wallFrameX = (ushort) num12;
        tilePtr->wallFrameY = (byte) num13;
      }
    }

    public static unsafe void TileFrame(int i, int j, int frameNumber = 0)
    {
      if (i <= 5 || j <= 5 || (i >= (int) Main.maxTilesX - 5 || j >= (int) Main.maxTilesY - 5))
        return;
      fixed (Tile* tilePtr1 = &Main.tile[i, j])
      {
        if ((int) tilePtr1->liquid > 0 && Main.netMode != 1)
          Liquid.AddWater(i, j);
        if ((int) tilePtr1->active != 0)
        {
          int type = (int) tilePtr1->type;
          if (Main.tileStone[type])
            type = 1;
          int num1 = (int) tilePtr1->frameX;
          int num2 = (int) tilePtr1->frameY;
          int num3 = -1;
          int num4 = -1;
          if (Main.tileFrameImportant[type])
          {
            switch (type)
            {
              case 3:
              case 24:
              case 61:
              case 71:
              case 73:
              case 74:
              case 110:
              case 113:
                WorldGen.PlantCheck(i, j);
                break;
              case 4:
                int num5 = (int) tilePtr1->frameX >= 66 ? 66 : 0;
                int index1 = -1;
                int index2 = -1;
                int index3 = -1;
                int num6 = -1;
                int num7 = -1;
                int num8 = -1;
                int num9 = -1;
                if ((int) tilePtr1[-1].active != 0)
                {
                  int num10 = (int) tilePtr1[-1].type;
                }
                if ((int) tilePtr1[1].active != 0)
                  index1 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  index2 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  index3 = (int) tilePtr1[1440].type;
                if ((int) tilePtr1[-1439].active != 0)
                  num6 = (int) tilePtr1[-1439].type;
                if ((int) tilePtr1[1441].active != 0)
                  num7 = (int) tilePtr1[1441].type;
                if ((int) tilePtr1[-1441].active != 0)
                  num8 = (int) tilePtr1[-1441].type;
                if ((int) tilePtr1[1439].active != 0)
                  num9 = (int) tilePtr1[1439].type;
                if (index1 >= 0 && Main.tileSolidAndAttach[index1])
                {
                  tilePtr1->frameX = (short) num5;
                  break;
                }
                else if (index2 >= 0 && (Main.tileSolidAndAttach[index2] || index2 == 124 || index2 == 5 && num8 == 5 && num6 == 5))
                {
                  tilePtr1->frameX = (short) (22 + num5);
                  break;
                }
                else if (index3 >= 0 && (Main.tileSolidAndAttach[index3] || index3 == 124 || index3 == 5 && num9 == 5 && num7 == 5))
                {
                  tilePtr1->frameX = (short) (44 + num5);
                  break;
                }
                else
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 5:
                WorldGen.CheckTree(i, j);
                break;
              case 6:
                break;
              case 7:
                break;
              case 8:
                break;
              case 9:
                break;
              case 10:
                if (WorldGen.destroyObject)
                  break;
                int j1 = j - num2 / 18;
                bool flag1 = false;
                if ((int) Main.tile[i, j1 - 1].active == 0 || !Main.tileSolid[(int) Main.tile[i, j1 - 1].type])
                  flag1 = true;
                else if ((int) Main.tile[i, j1 + 3].active == 0 || !Main.tileSolid[(int) Main.tile[i, j1 + 3].type])
                  flag1 = true;
                else if ((int) Main.tile[i, j1].active == 0 || (int) Main.tile[i, j1].type != type)
                  flag1 = true;
                else if ((int) Main.tile[i, j1 + 1].active == 0 || (int) Main.tile[i, j1 + 1].type != type)
                  flag1 = true;
                else if ((int) Main.tile[i, j1 + 2].active == 0 || (int) Main.tile[i, j1 + 2].type != type)
                  flag1 = true;
                if (flag1)
                {
                  WorldGen.destroyObject = true;
                  WorldGen.KillTile(i, j1);
                  WorldGen.KillTile(i, j1 + 1);
                  WorldGen.KillTile(i, j1 + 2);
                  if (!WorldGen.gen)
                    Item.NewItem(i * 16, j * 16, 16, 16, 25, 1, false, 0);
                }
                WorldGen.destroyObject = false;
                break;
              case 11:
                if (WorldGen.destroyObject)
                  break;
                int num11 = 0;
                int num12 = 0;
                int num13 = i;
                int num14 = j;
                bool flag2 = false;
                if (num1 == 0)
                  num11 = 1;
                else if (num1 == 18)
                {
                  num13 = i - 1;
                  num12 = -1440;
                  num11 = 1;
                }
                else if (num1 == 36)
                {
                  num12 = 1440;
                  num13 = i + 1;
                  num11 = -1;
                }
                else if (num1 == 54)
                  num11 = -1;
                if (num2 == 18)
                {
                  --num12;
                  num14 = j - 1;
                }
                else if (num2 == 36)
                {
                  num14 = j - 2;
                  num12 -= 2;
                }
                if ((int) tilePtr1[num12 - 1].active == 0 || !Main.tileSolid[(int) tilePtr1[num12 - 1].type] || ((int) tilePtr1[num12 + 3].active == 0 || !Main.tileSolid[(int) tilePtr1[num12 + 3].type]))
                {
                  flag2 = true;
                  WorldGen.destroyObject = true;
                  if (!WorldGen.gen)
                    Item.NewItem(i * 16, j * 16, 16, 16, 25, 1, false, 0);
                }
                int num15 = num13;
                if (num11 == -1)
                  num15 = num13 - 1;
                for (int i1 = num15; i1 < num15 + 2; ++i1)
                {
                  for (int j2 = num14; j2 < num14 + 3; ++j2)
                  {
                    if (!flag2)
                    {
                      fixed (Tile* tilePtr2 = &Main.tile[i1, j2])
                      {
                        if ((int) tilePtr2->type != 11 || (int) tilePtr2->active == 0)
                        {
                          WorldGen.destroyObject = true;
                          flag2 = true;
                          i1 = num15;
                          j2 = num14;
                          if (!WorldGen.gen)
                            Item.NewItem(i * 16, j * 16, 16, 16, 25, 1, false, 0);
                        }
                      }
                    }
                    if (flag2)
                      WorldGen.KillTile(i1, j2);
                  }
                }
                WorldGen.destroyObject = false;
                break;
              case 12:
              case 31:
                WorldGen.CheckOrb(i, j, type);
                break;
              case 13:
              case 33:
              case 50:
                WorldGen.CheckOnTable1x1(i, j);
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
                WorldGen.Check3x2(i, j, type);
                break;
              case 15:
              case 20:
                WorldGen.Check1x2(i, j, type);
                break;
              case 16:
              case 18:
              case 29:
              case 103:
              case 134:
                WorldGen.Check2x1(i, j, type);
                break;
              case 19:
                break;
              case 21:
                WorldGen.CheckChest(i, j);
                break;
              case 22:
                break;
              case 23:
                break;
              case 25:
                break;
              case 27:
                WorldGen.CheckSunflower(i, j);
                break;
              case 28:
                WorldGen.CheckPot(i, j);
                break;
              case 30:
                break;
              case 32:
                break;
              case 34:
              case 35:
              case 36:
              case 106:
                WorldGen.Check3x3(i, j, type);
                break;
              case 37:
                break;
              case 38:
                break;
              case 39:
                break;
              case 40:
                break;
              case 41:
                break;
              case 42:
                WorldGen.Check1x2Top(i, j);
                break;
              case 43:
                break;
              case 44:
                break;
              case 45:
                break;
              case 46:
                break;
              case 47:
                break;
              case 48:
                break;
              case 49:
                break;
              case 51:
                break;
              case 52:
                break;
              case 53:
                break;
              case 54:
                break;
              case 55:
              case 85:
                WorldGen.CheckSign(i, j, type);
                break;
              case 56:
                break;
              case 57:
                break;
              case 58:
                break;
              case 59:
                break;
              case 60:
                break;
              case 62:
                break;
              case 63:
                break;
              case 64:
                break;
              case 65:
                break;
              case 66:
                break;
              case 67:
                break;
              case 68:
                break;
              case 69:
                break;
              case 70:
                break;
              case 72:
                int num16 = -1;
                int num17 = -1;
                if ((int) tilePtr1[-1].active != 0)
                  num17 = (int) tilePtr1[-1].type;
                if ((int) tilePtr1[1].active != 0)
                  num16 = (int) tilePtr1[1].type;
                if (num16 != type && num16 != 70)
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
                else
                {
                  if (num17 == type || (int) tilePtr1->frameX != 0)
                    break;
                  tilePtr1->frameNumber = (byte) WorldGen.genRand.Next(3);
                  tilePtr1->frameX = (short) 18;
                  tilePtr1->frameY = (short) (18 * (int) tilePtr1->frameNumber);
                  break;
                }
              case 75:
                break;
              case 76:
                break;
              case 78:
                WorldGen.CheckOnTableClaypot(i, j);
                break;
              case 79:
              case 90:
                WorldGen.Check4x2(i, j, type);
                break;
              case 80:
                break;
              case 81:
                int index4 = -1;
                int num18 = -1;
                int num19 = -1;
                int num20 = -1;
                if ((int) tilePtr1[-1].active != 0)
                  num18 = (int) tilePtr1[-1].type;
                if ((int) tilePtr1[1].active != 0)
                  index4 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  num19 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  num20 = (int) tilePtr1[1440].type;
                if (num19 != -1 || num18 != -1 || num20 != -1)
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
                else
                {
                  if (index4 >= 0 && Main.tileSolid[index4])
                    break;
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 82:
              case 83:
              case 84:
                WorldGen.CheckAlch(i, j);
                break;
              case 91:
                WorldGen.CheckBanner(i, j);
                break;
              case 92:
              case 93:
                WorldGen.Check1xX(i, j, type);
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
                WorldGen.Check2x2(i, j, type);
                break;
              case 101:
              case 102:
                WorldGen.Check3x4(i, j, type);
                break;
              case 104:
              case 105:
                WorldGen.Check2xX(i, j, type);
                break;
              case 107:
                break;
              case 108:
                break;
              case 109:
                break;
              case 111:
                break;
              case 112:
                break;
              case 115:
                break;
              case 116:
                break;
              case 117:
                break;
              case 118:
                break;
              case 119:
                break;
              case 120:
                break;
              case 121:
                break;
              case 122:
                break;
              case 123:
                break;
              case 124:
                break;
              case (int) sbyte.MaxValue:
                break;
              case 128:
                WorldGen.CheckMan(i, j);
                break;
              case 129:
              case 149:
                int index5 = -1;
                int index6 = -1;
                int index7 = -1;
                int index8 = -1;
                if ((int) tilePtr1[-1].active != 0)
                  index6 = (int) tilePtr1[-1].type;
                if ((int) tilePtr1[1].active != 0)
                  index5 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  index7 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  index8 = (int) tilePtr1[1440].type;
                if (index5 >= 0 && Main.tileSolidNotSolidTop[index5])
                {
                  tilePtr1->frameY = (short) 0;
                  break;
                }
                else if (index7 >= 0 && Main.tileSolidNotSolidTop[index7])
                {
                  tilePtr1->frameY = (short) 54;
                  break;
                }
                else if (index8 >= 0 && Main.tileSolidNotSolidTop[index8])
                {
                  tilePtr1->frameY = (short) 36;
                  break;
                }
                else if (index6 >= 0 && Main.tileSolidNotSolidTop[index6])
                {
                  tilePtr1->frameY = (short) 18;
                  break;
                }
                else
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 130:
                break;
              case 131:
                break;
              case 135:
              case 141:
              case 144:
                WorldGen.Check1x1(i, j, type);
                break;
              case 136:
                int index9 = -1;
                int index10 = -1;
                int index11 = -1;
                if ((int) tilePtr1[-1].active != 0)
                {
                  int num21 = (int) tilePtr1[-1].type;
                }
                if ((int) tilePtr1[1].active != 0)
                  index9 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  index10 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  index11 = (int) tilePtr1[1440].type;
                if (index9 >= 0 && Main.tileSolidAndAttach[index9])
                {
                  tilePtr1->frameX = (short) 0;
                  break;
                }
                else if (index10 >= 0 && (Main.tileSolidAndAttach[index10] || index10 == 124 || index10 == 5))
                {
                  tilePtr1->frameX = (short) 18;
                  break;
                }
                else if (index11 >= 0 && (Main.tileSolidAndAttach[index11] || index11 == 124 || index11 == 5))
                {
                  tilePtr1->frameX = (short) 36;
                  break;
                }
                else
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 137:
                break;
              case 139:
                WorldGen.CheckMusicBox(i, j);
                break;
              case 140:
                break;
              case 145:
                break;
              case 146:
                break;
              case 147:
                break;
              case 148:
                break;
              default:
                break;
            }
          }
          else
          {
            int index12 = -1;
            int index13 = -1;
            int index14 = -1;
            int index15 = -1;
            int index16 = -1;
            int index17 = -1;
            int index18 = -1;
            int index19 = -1;
            if ((int) tilePtr1[-1440].active != 0)
            {
              int index20 = (int) tilePtr1[-1440].type;
              index15 = Main.tileStone[index20] ? 1 : index20;
            }
            if ((int) tilePtr1[1440].active != 0)
            {
              int index20 = (int) tilePtr1[1440].type;
              index16 = Main.tileStone[index20] ? 1 : index20;
            }
            if ((int) tilePtr1[-1].active != 0)
            {
              int index20 = (int) tilePtr1[-1].type;
              index13 = Main.tileStone[index20] ? 1 : index20;
            }
            if ((int) tilePtr1[1].active != 0)
            {
              int index20 = (int) tilePtr1[1].type;
              index18 = Main.tileStone[index20] ? 1 : index20;
            }
            if ((int) tilePtr1[-1441].active != 0)
            {
              int index20 = (int) tilePtr1[-1441].type;
              index12 = Main.tileStone[index20] ? 1 : index20;
            }
            if ((int) tilePtr1[1439].active != 0)
            {
              int index20 = (int) tilePtr1[1439].type;
              index14 = Main.tileStone[index20] ? 1 : index20;
            }
            if ((int) tilePtr1[-1439].active != 0)
            {
              int index20 = (int) tilePtr1[-1439].type;
              index17 = Main.tileStone[index20] ? 1 : index20;
            }
            if ((int) tilePtr1[1441].active != 0)
            {
              int index20 = (int) tilePtr1[1441].type;
              index19 = Main.tileStone[index20] ? 1 : index20;
            }
            if (type == 19)
            {
              if (index16 >= 0 && !Main.tileSolid[index16])
                index16 = -1;
              if (index15 >= 0 && !Main.tileSolid[index15])
                index15 = -1;
              num3 = index15 != type ? (index15 >= 0 ? (index16 != type ? (index16 >= 0 ? 90 : 108) : 54) : (index16 != type ? (index16 <= 0 ? 90 : 126) : 36)) : (index16 != type ? (index16 >= 0 ? 72 : 18) : 0);
              num4 = 18 * (int) tilePtr1->frameNumber;
            }
            else if (type == 80)
            {
              WorldGen.CactusFrame(i, j);
              return;
            }
            else if (type == 49)
            {
              WorldGen.CheckOnTable1x1(i, j);
              return;
            }
            WorldGen.mergeUp = false;
            WorldGen.mergeDown = false;
            WorldGen.mergeLeft = false;
            WorldGen.mergeRight = false;
            if (frameNumber < 0)
            {
              frameNumber = WorldGen.genRand.Next(3);
              tilePtr1->frameNumber = (byte) frameNumber;
            }
            else
              frameNumber = (int) tilePtr1->frameNumber;
            if (type == 0)
            {
              if (index13 >= 0 && Main.tileMergeDirt[index13])
              {
                WorldGen.TileFrame(i, j - 1, 0);
                if (WorldGen.mergeDown)
                  index13 = type;
              }
              if (index18 >= 0 && Main.tileMergeDirt[index18])
              {
                WorldGen.TileFrame(i, j + 1, 0);
                if (WorldGen.mergeUp)
                  index18 = type;
              }
              if (index15 >= 0 && Main.tileMergeDirt[index15])
              {
                WorldGen.TileFrame(i - 1, j, 0);
                if (WorldGen.mergeRight)
                  index15 = type;
              }
              if (index16 >= 0 && Main.tileMergeDirt[index16])
              {
                WorldGen.TileFrame(i + 1, j, 0);
                if (WorldGen.mergeLeft)
                  index16 = type;
              }
              if (index13 == 2 || index13 == 23 || index13 == 109)
                index13 = type;
              if (index18 == 2 || index18 == 23 || index18 == 109)
                index18 = type;
              if (index15 == 2 || index15 == 23 || index15 == 109)
                index15 = type;
              if (index16 == 2 || index16 == 23 || index16 == 109)
                index16 = type;
              if (index12 >= 0 && Main.tileMergeDirt[index12])
                index12 = type;
              else if (index12 == 2 || index12 == 23 || index12 == 109)
                index12 = type;
              if (index14 >= 0 && Main.tileMergeDirt[index14])
                index14 = type;
              else if (index14 == 2 || index14 == 23 || index14 == 109)
                index14 = type;
              if (index17 >= 0 && Main.tileMergeDirt[index17])
                index17 = type;
              else if (index17 == 2 || index17 == 23 || index14 == 109)
                index17 = type;
              if (index19 >= 0 && Main.tileMergeDirt[index19])
                index19 = type;
              else if (index19 == 2 || index19 == 23 || index19 == 109)
                index19 = type;
              if (j < Main.rockLayer)
              {
                if (index13 == 59)
                  index13 = -2;
                if (index18 == 59)
                  index18 = -2;
                if (index15 == 59)
                  index15 = -2;
                if (index16 == 59)
                  index16 = -2;
                if (index12 == 59)
                  index12 = -2;
                if (index14 == 59)
                  index14 = -2;
                if (index17 == 59)
                  index17 = -2;
                if (index19 == 59)
                  index19 = -2;
              }
            }
            else if (Main.tileMergeDirt[type])
            {
              if (index13 == 0)
                index13 = -2;
              if (index18 == 0)
                index18 = -2;
              if (index15 == 0)
                index15 = -2;
              if (index16 == 0)
                index16 = -2;
              if (index12 == 0)
                index12 = -2;
              if (index14 == 0)
                index14 = -2;
              if (index17 == 0)
                index17 = -2;
              if (index19 == 0)
                index19 = -2;
              if (type == 1)
              {
                if (j > Main.rockLayer)
                {
                  if (index13 == 59)
                  {
                    WorldGen.TileFrame(i, j - 1, 0);
                    if (WorldGen.mergeDown)
                      index13 = type;
                  }
                  if (index18 == 59)
                  {
                    WorldGen.TileFrame(i, j + 1, 0);
                    if (WorldGen.mergeUp)
                      index18 = type;
                  }
                  if (index15 == 59)
                  {
                    WorldGen.TileFrame(i - 1, j, 0);
                    if (WorldGen.mergeRight)
                      index15 = type;
                  }
                  if (index16 == 59)
                  {
                    WorldGen.TileFrame(i + 1, j, 0);
                    if (WorldGen.mergeLeft)
                      index16 = type;
                  }
                  if (index12 == 59)
                    index12 = type;
                  if (index14 == 59)
                    index14 = type;
                  if (index17 == 59)
                    index17 = type;
                  if (index19 == 59)
                    index19 = type;
                }
                if (index13 == 57)
                {
                  WorldGen.TileFrame(i, j - 1, 0);
                  if (WorldGen.mergeDown)
                    index13 = type;
                }
                if (index18 == 57)
                {
                  WorldGen.TileFrame(i, j + 1, 0);
                  if (WorldGen.mergeUp)
                    index18 = type;
                }
                if (index15 == 57)
                {
                  WorldGen.TileFrame(i - 1, j, 0);
                  if (WorldGen.mergeRight)
                    index15 = type;
                }
                if (index16 == 57)
                {
                  WorldGen.TileFrame(i + 1, j, 0);
                  if (WorldGen.mergeLeft)
                    index16 = type;
                }
                if (index12 == 57)
                  index12 = type;
                if (index14 == 57)
                  index14 = type;
                if (index17 == 57)
                  index17 = type;
                if (index19 == 57)
                  index19 = type;
              }
            }
            else if (type == 58 || type == 76 || type == 75)
            {
              if (index13 == 57)
                index13 = -2;
              if (index18 == 57)
                index18 = -2;
              if (index15 == 57)
                index15 = -2;
              if (index16 == 57)
                index16 = -2;
              if (index12 == 57)
                index12 = -2;
              if (index14 == 57)
                index14 = -2;
              if (index17 == 57)
                index17 = -2;
              if (index19 == 57)
                index19 = -2;
            }
            else if (type == 59)
            {
              if (j > Main.rockLayer)
              {
                if (index13 == 1)
                  index13 = -2;
                if (index18 == 1)
                  index18 = -2;
                if (index15 == 1)
                  index15 = -2;
                if (index16 == 1)
                  index16 = -2;
                if (index12 == 1)
                  index12 = -2;
                if (index14 == 1)
                  index14 = -2;
                if (index17 == 1)
                  index17 = -2;
                if (index19 == 1)
                  index19 = -2;
              }
              if (index13 == 60 || index13 == 70)
                index13 = type;
              if (index18 == 60 || index18 == 70)
                index18 = type;
              if (index15 == 60 || index15 == 70)
                index15 = type;
              if (index16 == 60 || index16 == 70)
                index16 = type;
              if (index12 == 60 || index12 == 70)
                index12 = type;
              if (index14 == 60 || index14 == 70)
                index14 = type;
              if (index17 == 60 || index17 == 70)
                index17 = type;
              if (index19 == 60 || index19 == 70)
                index19 = type;
              if (j < Main.rockLayer)
              {
                if (index13 == 0)
                {
                  WorldGen.TileFrame(i, j - 1, 0);
                  if (WorldGen.mergeDown)
                    index13 = type;
                }
                if (index18 == 0)
                {
                  WorldGen.TileFrame(i, j + 1, 0);
                  if (WorldGen.mergeUp)
                    index18 = type;
                }
                if (index15 == 0)
                {
                  WorldGen.TileFrame(i - 1, j, 0);
                  if (WorldGen.mergeRight)
                    index15 = type;
                }
                if (index16 == 0)
                {
                  WorldGen.TileFrame(i + 1, j, 0);
                  if (WorldGen.mergeLeft)
                    index16 = type;
                }
                if (index12 == 0)
                  index12 = type;
                if (index14 == 0)
                  index14 = type;
                if (index17 == 0)
                  index17 = type;
                if (index19 == 0)
                  index19 = type;
              }
            }
            else if (type == 57)
            {
              if (index13 == 1)
                index13 = -2;
              if (index18 == 1)
                index18 = -2;
              if (index15 == 1)
                index15 = -2;
              if (index16 == 1)
                index16 = -2;
              if (index12 == 1)
                index12 = -2;
              if (index14 == 1)
                index14 = -2;
              if (index17 == 1)
                index17 = -2;
              if (index19 == 1)
                index19 = -2;
              if (index13 == 58 || index13 == 76 || index13 == 75)
              {
                WorldGen.TileFrame(i, j - 1, 0);
                if (WorldGen.mergeDown)
                  index13 = type;
              }
              if (index18 == 58 || index18 == 76 || index18 == 75)
              {
                WorldGen.TileFrame(i, j + 1, 0);
                if (WorldGen.mergeUp)
                  index18 = type;
              }
              if (index15 == 58 || index15 == 76 || index15 == 75)
              {
                WorldGen.TileFrame(i - 1, j, 0);
                if (WorldGen.mergeRight)
                  index15 = type;
              }
              if (index16 == 58 || index16 == 76 || index16 == 75)
              {
                WorldGen.TileFrame(i + 1, j, 0);
                if (WorldGen.mergeLeft)
                  index16 = type;
              }
              if (index12 == 58 || index12 == 76 || index12 == 75)
                index12 = type;
              if (index14 == 58 || index14 == 76 || index14 == 75)
                index14 = type;
              if (index17 == 58 || index17 == 76 || index17 == 75)
                index17 = type;
              if (index19 == 58 || index19 == 76 || index19 == 75)
                index19 = type;
            }
            else if (type == 32)
            {
              if (index18 == 23)
                index18 = type;
            }
            else if (type == 69)
            {
              if (index18 == 60)
                index18 = type;
            }
            else if (type == 51)
            {
              if (index13 >= 0 && !Main.tileNoAttach[index13])
                index13 = type;
              if (index18 >= 0 && !Main.tileNoAttach[index18])
                index18 = type;
              if (index15 >= 0 && !Main.tileNoAttach[index15])
                index15 = type;
              if (index16 >= 0 && !Main.tileNoAttach[index16])
                index16 = type;
              if (index12 >= 0 && !Main.tileNoAttach[index12])
                index12 = type;
              if (index14 >= 0 && !Main.tileNoAttach[index14])
                index14 = type;
              if (index17 >= 0 && !Main.tileNoAttach[index17])
                index17 = type;
              if (index19 >= 0 && !Main.tileNoAttach[index19])
                index19 = type;
            }
            bool flag3 = false;
            if (type == 2 || type == 23 || (type == 60 || type == 70) || type == 109)
            {
              flag3 = true;
              if (index13 >= 0 && index13 != type && !Main.tileSolid[index13])
                index13 = -1;
              if (index18 >= 0 && index18 != type && !Main.tileSolid[index18])
                index18 = -1;
              if (index15 >= 0 && index15 != type && !Main.tileSolid[index15])
                index15 = -1;
              if (index16 >= 0 && index16 != type && !Main.tileSolid[index16])
                index16 = -1;
              if (index12 >= 0 && index12 != type && !Main.tileSolid[index12])
                index12 = -1;
              if (index14 >= 0 && index14 != type && !Main.tileSolid[index14])
                index14 = -1;
              if (index17 >= 0 && index17 != type && !Main.tileSolid[index17])
                index17 = -1;
              if (index19 >= 0 && index19 != type && !Main.tileSolid[index19])
                index19 = -1;
              int num22 = 0;
              if (type == 60 || type == 70)
                num22 = 59;
              else if (type == 2)
              {
                if (index13 == 23)
                  index13 = num22;
                if (index18 == 23)
                  index18 = num22;
                if (index15 == 23)
                  index15 = num22;
                if (index16 == 23)
                  index16 = num22;
                if (index12 == 23)
                  index12 = num22;
                if (index14 == 23)
                  index14 = num22;
                if (index17 == 23)
                  index17 = num22;
                if (index19 == 23)
                  index19 = num22;
              }
              else if (type == 23)
              {
                if (index13 == 2)
                  index13 = num22;
                if (index18 == 2)
                  index18 = num22;
                if (index15 == 2)
                  index15 = num22;
                if (index16 == 2)
                  index16 = num22;
                if (index12 == 2)
                  index12 = num22;
                if (index14 == 2)
                  index14 = num22;
                if (index17 == 2)
                  index17 = num22;
                if (index19 == 2)
                  index19 = num22;
              }
              if (index13 != type && index13 != num22 && (index18 == type || index18 == num22))
              {
                if (index15 == num22 && index16 == type)
                {
                  num3 = 18 * frameNumber;
                  num4 = 198;
                }
                else if (index15 == type && index16 == num22)
                {
                  num3 = 54 + 18 * frameNumber;
                  num4 = 198;
                }
              }
              else if (index18 != type && index18 != num22 && (index13 == type || index13 == num22))
              {
                if (index15 == num22 && index16 == type)
                {
                  num3 = 18 * frameNumber;
                  num4 = 216;
                }
                else if (index15 == type && index16 == num22)
                {
                  num3 = 54 + 18 * frameNumber;
                  num4 = 216;
                }
              }
              else if (index15 != type && index15 != num22 && (index16 == type || index16 == num22))
              {
                if (index13 == num22 && index18 == type)
                {
                  num3 = 72;
                  num4 = 144 + 18 * frameNumber;
                }
                else if (index18 == type && index16 == index13)
                {
                  num3 = 72;
                  num4 = 90 + 18 * frameNumber;
                }
              }
              else if (index16 != type && index16 != num22 && (index15 == type || index15 == num22))
              {
                if (index13 == num22 && index18 == type)
                {
                  num3 = 90;
                  num4 = 144 + 18 * frameNumber;
                }
                else if (index18 == type && index16 == index13)
                {
                  num3 = 90;
                  num4 = 90 + 18 * frameNumber;
                }
              }
              else if (index13 == type && index18 == type && (index15 == type && index16 == type))
              {
                if (index12 != type && index14 != type && (index17 != type && index19 != type))
                {
                  if (index19 == num22)
                  {
                    num4 = 324;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else if (index14 == num22)
                  {
                    num4 = 342;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else if (index17 == num22)
                  {
                    num4 = 360;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else if (index12 == num22)
                  {
                    num4 = 378;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else
                  {
                    num4 = 234;
                    num3 = 144 + 54 * frameNumber;
                  }
                }
                else if (index12 != type && index19 != type)
                {
                  num4 = 306;
                  num3 = 36 + 18 * frameNumber;
                }
                else if (index14 != type && index17 != type)
                {
                  num4 = 306;
                  num3 = 90 + 18 * frameNumber;
                }
                else if (index12 != type && index14 == type && (index17 == type && index19 == type))
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index12 == type && index14 != type && (index17 == type && index19 == type))
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index12 == type && index14 == type && (index17 != type && index19 == type))
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index12 == type && index14 == type && (index17 == type && index19 != type))
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
              }
              else if (index13 == type && index18 == num22 && (index15 == type && index16 == type) && (index12 == -1 && index14 == -1))
              {
                num4 = 18;
                num3 = 108 + 18 * frameNumber;
              }
              else if (index13 == num22 && index18 == type && (index15 == type && index16 == type) && (index17 == -1 && index19 == -1))
              {
                num4 = 36;
                num3 = 108 + 18 * frameNumber;
              }
              else if (index13 == type && index18 == type && (index15 == num22 && index16 == type) && (index14 == -1 && index19 == -1))
              {
                num3 = 198;
                num4 = 18 * frameNumber;
              }
              else if (index13 == type && index18 == type && (index15 == type && index16 == num22) && (index12 == -1 && index17 == -1))
              {
                num3 = 180;
                num4 = 18 * frameNumber;
              }
              else if (index13 == type && index18 == num22 && (index15 == type && index16 == type))
              {
                if (index14 != -1)
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index12 != -1)
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
              }
              else if (index13 == num22 && index18 == type && (index15 == type && index16 == type))
              {
                if (index19 != -1)
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index17 != -1)
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
              }
              else if (index13 == type && index18 == type && (index15 == type && index16 == num22))
              {
                if (index12 != -1)
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index17 != -1)
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
              }
              else if (index13 == type && index18 == type && (index15 == num22 && index16 == type))
              {
                if (index14 != -1)
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index19 != -1)
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
              }
              else if (index13 == num22 && index18 == type && (index15 == type && index16 == type) || index13 == type && index18 == num22 && (index15 == type && index16 == type) || (index13 == type && index18 == type && (index15 == num22 && index16 == type) || index13 == type && index18 == type && (index15 == type && index16 == num22)))
              {
                num4 = 18;
                num3 = 18 + 18 * frameNumber;
              }
              if ((index13 == type || index13 == num22) && (index18 == type || index18 == num22) && ((index15 == type || index15 == num22) && (index16 == type || index16 == num22)))
              {
                if (index12 != type && index12 != num22 && (index14 == type || index14 == num22) && ((index17 == type || index17 == num22) && (index19 == type || index19 == num22)))
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index14 != type && index14 != num22 && (index12 == type || index12 == num22) && ((index17 == type || index17 == num22) && (index19 == type || index19 == num22)))
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index17 != type && index17 != num22 && (index12 == type || index12 == num22) && ((index14 == type || index14 == num22) && (index19 == type || index19 == num22)))
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index19 != type && index19 != num22 && (index12 == type || index12 == num22) && ((index17 == type || index17 == num22) && (index14 == type || index14 == num22)))
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
              }
              if (index13 != num22 && index13 != type && (index18 == type && index15 != num22) && (index15 != type && index16 == type && (index19 != num22 && index19 != type)))
              {
                num4 = 270;
                num3 = 90 + 18 * frameNumber;
              }
              else if (index13 != num22 && index13 != type && (index18 == type && index15 == type) && (index16 != num22 && index16 != type && (index17 != num22 && index17 != type)))
              {
                num4 = 270;
                num3 = 144 + 18 * frameNumber;
              }
              else if (index18 != num22 && index18 != type && (index13 == type && index15 != num22) && (index15 != type && index16 == type && (index14 != num22 && index14 != type)))
              {
                num4 = 288;
                num3 = 90 + 18 * frameNumber;
              }
              else if (index18 != num22 && index18 != type && (index13 == type && index15 == type) && (index16 != num22 && index16 != type && (index12 != num22 && index12 != type)))
              {
                num4 = 288;
                num3 = 144 + 18 * frameNumber;
              }
              else if (index13 != type && index13 != num22 && (index18 == type && index15 == type) && (index16 == type && index17 != type && (index17 != num22 && index19 != type)) && index19 != num22)
              {
                num4 = 216;
                num3 = 144 + 54 * frameNumber;
              }
              else if (index18 != type && index18 != num22 && (index13 == type && index15 == type) && (index16 == type && index12 != type && (index12 != num22 && index14 != type)) && index14 != num22)
              {
                num4 = 252;
                num3 = 144 + 54 * frameNumber;
              }
              else if (index15 != type && index15 != num22 && (index18 == type && index13 == type) && (index16 == type && index14 != type && (index14 != num22 && index19 != type)) && index19 != num22)
              {
                num4 = 234;
                num3 = 126 + 54 * frameNumber;
              }
              else if (index16 != type && index16 != num22 && (index18 == type && index13 == type) && (index15 == type && index12 != type && (index12 != num22 && index17 != type)) && index17 != num22)
              {
                num4 = 234;
                num3 = 162 + 54 * frameNumber;
              }
              else if (index13 != num22 && index13 != type && (index18 == num22 || index18 == type) && (index15 == num22 && index16 == num22))
              {
                num4 = 270;
                num3 = 36 + 18 * frameNumber;
              }
              else if (index18 != num22 && index18 != type && (index13 == num22 || index13 == type) && (index15 == num22 && index16 == num22))
              {
                num4 = 288;
                num3 = 36 + 18 * frameNumber;
              }
              else if (index15 != num22 && index15 != type && (index16 == num22 || index16 == type) && (index13 == num22 && index18 == num22))
              {
                num3 = 0;
                num4 = 270 + 18 * frameNumber;
              }
              else if (index16 != num22 && index16 != type && (index15 == num22 || index15 == type) && (index13 == num22 && index18 == num22))
              {
                num3 = 18;
                num4 = 270 + 18 * frameNumber;
              }
              else if (index13 == type && index18 == num22 && (index15 == num22 && index16 == num22))
              {
                num4 = 288;
                num3 = 198 + 18 * frameNumber;
              }
              else if (index13 == num22 && index18 == type && (index15 == num22 && index16 == num22))
              {
                num4 = 270;
                num3 = 198 + 18 * frameNumber;
              }
              else if (index13 == num22 && index18 == num22 && (index15 == type && index16 == num22))
              {
                num4 = 306;
                num3 = 198 + 18 * frameNumber;
              }
              else if (index13 == num22 && index18 == num22 && (index15 == num22 && index16 == type))
              {
                num4 = 306;
                num3 = 144 + 18 * frameNumber;
              }
              if (index13 != type && index13 != num22 && (index18 == type && index15 == type) && index16 == type)
              {
                if ((index17 == num22 || index17 == type) && (index19 != num22 && index19 != type))
                {
                  num4 = 324;
                  num3 = 18 * frameNumber;
                }
                else if ((index19 == num22 || index19 == type) && (index17 != num22 && index17 != type))
                {
                  num4 = 324;
                  num3 = 54 + 18 * frameNumber;
                }
              }
              else if (index18 != type && index18 != num22 && (index13 == type && index15 == type) && index16 == type)
              {
                if ((index12 == num22 || index12 == type) && (index14 != num22 && index14 != type))
                {
                  num4 = 342;
                  num3 = 18 * frameNumber;
                }
                else if ((index14 == num22 || index14 == type) && (index12 != num22 && index12 != type))
                {
                  num4 = 342;
                  num3 = 54 + 18 * frameNumber;
                }
              }
              else if (index15 != type && index15 != num22 && (index13 == type && index18 == type) && index16 == type)
              {
                if ((index14 == num22 || index14 == type) && (index19 != num22 && index19 != type))
                {
                  num4 = 360;
                  num3 = 54 + 18 * frameNumber;
                }
                else if ((index19 == num22 || index19 == type) && (index14 != num22 && index14 != type))
                {
                  num4 = 360;
                  num3 = 18 * frameNumber;
                }
              }
              else if (index16 != type && index16 != num22 && (index13 == type && index18 == type) && index15 == type)
              {
                if ((index12 == num22 || index12 == type) && (index17 != num22 && index17 != type))
                {
                  num4 = 378;
                  num3 = 18 * frameNumber;
                }
                else if ((index17 == num22 || index17 == type) && (index12 != num22 && index12 != type))
                {
                  num4 = 378;
                  num3 = 54 + 18 * frameNumber;
                }
              }
              if ((index13 == type || index13 == num22) && (index18 == type || index18 == num22) && ((index15 == type || index15 == num22) && (index16 == type || index16 == num22)) && (index12 != -1 && index14 != -1 && (index17 != -1 && index19 != -1)))
              {
                num4 = 18;
                num3 = 18 + 18 * frameNumber;
              }
              if (index13 == num22)
                index13 = -2;
              if (index18 == num22)
                index18 = -2;
              if (index15 == num22)
                index15 = -2;
              if (index16 == num22)
                index16 = -2;
              if (index12 == num22)
                index12 = -2;
              if (index14 == num22)
                index14 = -2;
              if (index17 == num22)
                index17 = -2;
              if (index19 == num22)
                index19 = -2;
            }
            if (num3 == -1 && (Main.tileMergeDirt[type] || type == 0 || (type == 2 || type == 57) || (type == 58 || type == 59 || (type == 60 || type == 70)) || (type == 109 || type == 76 || type == 75)))
            {
              if (!flag3)
              {
                flag3 = true;
                if (index12 >= 0 && index12 != type && !Main.tileSolid[index12])
                  index12 = -1;
                if (index14 >= 0 && index14 != type && !Main.tileSolid[index14])
                  index14 = -1;
                if (index17 >= 0 && index17 != type && !Main.tileSolid[index17])
                  index17 = -1;
                if (index19 >= 0 && index19 != type && !Main.tileSolid[index19])
                  index19 = -1;
              }
              if (index13 >= 0 && index13 != type)
                index13 = -1;
              if (index18 >= 0 && index18 != type)
                index18 = -1;
              if (index15 >= 0 && index15 != type)
                index15 = -1;
              if (index16 >= 0 && index16 != type)
                index16 = -1;
              if (index13 != -1 && index18 != -1 && (index15 != -1 && index16 != -1))
              {
                if (index13 == -2 && index18 == type && (index15 == type && index16 == type))
                {
                  num4 = 108;
                  num3 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp = true;
                }
                else if (index13 == type && index18 == -2 && (index15 == type && index16 == type))
                {
                  num4 = 90;
                  num3 = 144 + 18 * frameNumber;
                  WorldGen.mergeDown = true;
                }
                else if (index13 == type && index18 == type && (index15 == -2 && index16 == type))
                {
                  num3 = 162;
                  num4 = 126 + 18 * frameNumber;
                  WorldGen.mergeLeft = true;
                }
                else if (index13 == type && index18 == type && (index15 == type && index16 == -2))
                {
                  num3 = 144;
                  num4 = 126 + 18 * frameNumber;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == -2 && index18 == type && (index15 == -2 && index16 == type))
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                  WorldGen.mergeUp = true;
                  WorldGen.mergeLeft = true;
                }
                else if (index13 == -2 && index18 == type && (index15 == type && index16 == -2))
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                  WorldGen.mergeUp = true;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == type && index18 == -2 && (index15 == -2 && index16 == type))
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                  WorldGen.mergeDown = true;
                  WorldGen.mergeLeft = true;
                }
                else if (index13 == type && index18 == -2 && (index15 == type && index16 == -2))
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                  WorldGen.mergeDown = true;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == type && index18 == type && (index15 == -2 && index16 == -2))
                {
                  num3 = 180;
                  num4 = 126 + 18 * frameNumber;
                  WorldGen.mergeLeft = true;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == -2 && index18 == -2 && (index15 == type && index16 == type))
                {
                  num4 = 180;
                  num3 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp = true;
                  WorldGen.mergeDown = true;
                }
                else if (index13 == -2 && index18 == type && (index15 == -2 && index16 == -2))
                {
                  num3 = 198;
                  num4 = 90 + 18 * frameNumber;
                  WorldGen.mergeUp = true;
                  WorldGen.mergeLeft = true;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == type && index18 == -2 && (index15 == -2 && index16 == -2))
                {
                  num3 = 198;
                  num4 = 144 + 18 * frameNumber;
                  WorldGen.mergeDown = true;
                  WorldGen.mergeLeft = true;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == -2 && index18 == -2 && (index15 == type && index16 == -2))
                {
                  num3 = 216;
                  num4 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp = true;
                  WorldGen.mergeDown = true;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == -2 && index18 == -2 && (index15 == -2 && index16 == type))
                {
                  num3 = 216;
                  num4 = 90 + 18 * frameNumber;
                  WorldGen.mergeUp = true;
                  WorldGen.mergeDown = true;
                  WorldGen.mergeLeft = true;
                }
                else if (index13 == -2 && index18 == -2 && (index15 == -2 && index16 == -2))
                {
                  num4 = 198;
                  num3 = 108 + 18 * frameNumber;
                  WorldGen.mergeUp = true;
                  WorldGen.mergeDown = true;
                  WorldGen.mergeLeft = true;
                  WorldGen.mergeRight = true;
                }
                else if (index13 == type && index18 == type && (index15 == type && index16 == type))
                {
                  if (index19 == -2)
                  {
                    num3 = 0;
                    num4 = 90 + 36 * frameNumber;
                  }
                  else if (index17 == -2)
                  {
                    num3 = 18;
                    num4 = 90 + 36 * frameNumber;
                  }
                  else if (index14 == -2)
                  {
                    num3 = 0;
                    num4 = 108 + 36 * frameNumber;
                  }
                  else if (index12 == -2)
                  {
                    num3 = 18;
                    num4 = 108 + 36 * frameNumber;
                  }
                }
              }
              else
              {
                if (type != 2 && type != 23 && (type != 60 && type != 70) && type != 109)
                {
                  if (index13 == -1 && index18 == -2 && (index15 == type && index16 == type))
                  {
                    num4 = 0;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeDown = true;
                  }
                  else if (index13 == -2 && index18 == -1 && (index15 == type && index16 == type))
                  {
                    num4 = 18;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeUp = true;
                  }
                  else if (index13 == type && index18 == type && (index15 == -1 && index16 == -2))
                  {
                    num4 = 36;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeRight = true;
                  }
                  else if (index13 == type && index18 == type && (index15 == -2 && index16 == -1))
                  {
                    num4 = 54;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeLeft = true;
                  }
                }
                if (index13 != -1 && index18 != -1 && (index15 == -1 && index16 == type))
                {
                  if (index13 == -2 && index18 == type)
                  {
                    num3 = 72;
                    num4 = 144 + 18 * frameNumber;
                    WorldGen.mergeUp = true;
                  }
                  else if (index18 == -2 && index13 == type)
                  {
                    num3 = 72;
                    num4 = 90 + 18 * frameNumber;
                    WorldGen.mergeDown = true;
                  }
                }
                else if (index13 != -1 && index18 != -1 && (index15 == type && index16 == -1))
                {
                  if (index13 == -2 && index18 == type)
                  {
                    num3 = 90;
                    num4 = 144 + 18 * frameNumber;
                    WorldGen.mergeUp = true;
                  }
                  else if (index18 == -2 && index13 == type)
                  {
                    num3 = 90;
                    num4 = 90 + 18 * frameNumber;
                    WorldGen.mergeDown = true;
                  }
                }
                else if (index13 == -1 && index18 == type && (index15 != -1 && index16 != -1))
                {
                  if (index15 == -2 && index16 == type)
                  {
                    num3 = 18 * frameNumber;
                    num4 = 198;
                    WorldGen.mergeLeft = true;
                  }
                  else if (index16 == -2 && index15 == type)
                  {
                    num3 = 54 + 18 * frameNumber;
                    num4 = 198;
                    WorldGen.mergeRight = true;
                  }
                }
                else if (index13 == type && index18 == -1 && (index15 != -1 && index16 != -1))
                {
                  if (index15 == -2 && index16 == type)
                  {
                    num3 = 18 * frameNumber;
                    num4 = 216;
                    WorldGen.mergeLeft = true;
                  }
                  else if (index16 == -2 && index15 == type)
                  {
                    num3 = 54 + 18 * frameNumber;
                    num4 = 216;
                    WorldGen.mergeRight = true;
                  }
                }
                else if (index13 != -1 && index18 != -1 && (index15 == -1 && index16 == -1))
                {
                  if (index13 == -2 && index18 == -2)
                  {
                    num3 = 108;
                    num4 = 216 + 18 * frameNumber;
                    WorldGen.mergeUp = true;
                    WorldGen.mergeDown = true;
                  }
                  else if (index13 == -2)
                  {
                    num3 = 126;
                    num4 = 144 + 18 * frameNumber;
                    WorldGen.mergeUp = true;
                  }
                  else if (index18 == -2)
                  {
                    num3 = 126;
                    num4 = 90 + 18 * frameNumber;
                    WorldGen.mergeDown = true;
                  }
                }
                else if (index13 == -1 && index18 == -1 && (index15 != -1 && index16 != -1))
                {
                  if (index15 == -2 && index16 == -2)
                  {
                    num4 = 198;
                    num3 = 162 + 18 * frameNumber;
                    WorldGen.mergeLeft = true;
                    WorldGen.mergeRight = true;
                  }
                  else if (index15 == -2)
                  {
                    num4 = 252;
                    num3 = 18 * frameNumber;
                    WorldGen.mergeLeft = true;
                  }
                  else if (index16 == -2)
                  {
                    num4 = 252;
                    num3 = 54 + 18 * frameNumber;
                    WorldGen.mergeRight = true;
                  }
                }
                else if (index13 == -2 && index18 == -1 && (index15 == -1 && index16 == -1))
                {
                  num3 = 108;
                  num4 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp = true;
                }
                else if (index13 == -1 && index18 == -2 && (index15 == -1 && index16 == -1))
                {
                  num3 = 108;
                  num4 = 90 + 18 * frameNumber;
                  WorldGen.mergeDown = true;
                }
                else if (index13 == -1 && index18 == -1 && (index15 == -2 && index16 == -1))
                {
                  num4 = 234;
                  num3 = 18 * frameNumber;
                  WorldGen.mergeLeft = true;
                }
                else if (index13 == -1 && index18 == -1 && (index15 == -1 && index16 == -2))
                {
                  num4 = 234;
                  num3 = 54 + 18 * frameNumber;
                  WorldGen.mergeRight = true;
                }
              }
            }
            if (num3 < 0)
            {
              if (!flag3)
              {
                if (index13 >= 0 && index13 != type && !Main.tileSolid[index13])
                  index13 = -1;
                if (index18 >= 0 && index18 != type && !Main.tileSolid[index18])
                  index18 = -1;
                if (index15 >= 0 && index15 != type && !Main.tileSolid[index15])
                  index15 = -1;
                if (index16 >= 0 && index16 != type && !Main.tileSolid[index16])
                  index16 = -1;
                if (index12 >= 0 && index12 != type && !Main.tileSolid[index12])
                  index12 = -1;
                if (index14 >= 0 && index14 != type && !Main.tileSolid[index14])
                  index14 = -1;
                if (index17 >= 0 && index17 != type && !Main.tileSolid[index17])
                  index17 = -1;
                if (index19 >= 0 && index19 != type && !Main.tileSolid[index19])
                  index19 = -1;
              }
              if (type == 2 || type == 23 || (type == 60 || type == 70) || type == 109)
              {
                if (index13 == -2)
                  index13 = type;
                if (index18 == -2)
                  index18 = type;
                if (index15 == -2)
                  index15 = type;
                if (index16 == -2)
                  index16 = type;
                if (index12 == -2)
                  index12 = type;
                if (index14 == -2)
                  index14 = type;
                if (index17 == -2)
                  index17 = type;
                if (index19 == -2)
                  index19 = type;
              }
              if (index13 == type && index18 == type && index15 == type & index16 == type)
              {
                if (index12 != type && index14 != type)
                {
                  num4 = 18;
                  num3 = 108 + 18 * frameNumber;
                }
                else if (index17 != type && index19 != type)
                {
                  num4 = 36;
                  num3 = 108 + 18 * frameNumber;
                }
                else if (index12 != type && index17 != type)
                {
                  num3 = 180;
                  num4 = 18 * frameNumber;
                }
                else if (index14 != type && index19 != type)
                {
                  num3 = 198;
                  num4 = 18 * frameNumber;
                }
                else
                {
                  num4 = 18;
                  num3 = 18 + 18 * frameNumber;
                }
              }
              else if (index13 != type && index18 == type && index15 == type & index16 == type)
              {
                num4 = 0;
                num3 = 18 + 18 * frameNumber;
              }
              else if (index13 == type && index18 != type && index15 == type & index16 == type)
              {
                num4 = 36;
                num3 = 18 + 18 * frameNumber;
              }
              else if (index13 == type && index18 == type && index15 != type & index16 == type)
              {
                num3 = 0;
                num4 = 18 * frameNumber;
              }
              else if (index13 == type && index18 == type && index15 == type & index16 != type)
              {
                num3 = 72;
                num4 = 18 * frameNumber;
              }
              else if (index13 != type && index18 == type && index15 != type & index16 == type)
              {
                num3 = 36 * frameNumber;
                num4 = 54;
              }
              else if (index13 != type && index18 == type && index15 == type & index16 != type)
              {
                num3 = 18 + 36 * frameNumber;
                num4 = 54;
              }
              else if (index13 == type && index18 != type && index15 != type & index16 == type)
              {
                num3 = 36 * frameNumber;
                num4 = 72;
              }
              else if (index13 == type && index18 != type && index15 == type & index16 != type)
              {
                num3 = 18 + 36 * frameNumber;
                num4 = 72;
              }
              else if (index13 == type && index18 == type && index15 != type & index16 != type)
              {
                num3 = 90;
                num4 = 18 * frameNumber;
              }
              else if (index13 != type && index18 != type && index15 == type & index16 == type)
              {
                num3 = 108 + 18 * frameNumber;
                num4 = 72;
              }
              else if (index13 != type && index18 == type && index15 != type & index16 != type)
              {
                num3 = 108 + 18 * frameNumber;
                num4 = 0;
              }
              else if (index13 == type && index18 != type && index15 != type & index16 != type)
              {
                num3 = 108 + 18 * frameNumber;
                num4 = 54;
              }
              else if (index13 != type && index18 != type && index15 != type & index16 == type)
              {
                num3 = 162;
                num4 = 18 * frameNumber;
              }
              else if (index13 != type && index18 != type && index15 == type & index16 != type)
              {
                num3 = 216;
                num4 = 18 * frameNumber;
              }
              else if (index13 != type && index18 != type && index15 != type & index16 != type)
              {
                num3 = 162 + 18 * frameNumber;
                num4 = 54;
              }
            }
            if (num3 < 0)
            {
              num4 = 18;
              num3 = 18 + 18 * frameNumber;
            }
            tilePtr1->frameX = (short) num3;
            tilePtr1->frameY = (short) num4;
            if (type == 52 || type == 62 || type == 115)
            {
              int num22 = (int) tilePtr1[-1].active != 0 ? (int) tilePtr1[-1].type : -1;
              if (type == 52 && (num22 == 109 || num22 == 115))
              {
                tilePtr1->type = (byte) 115;
                WorldGen.SquareTileFrame(i, j, -1);
                return;
              }
              else if (type == 115 && (num22 == 2 || num22 == 52))
              {
                tilePtr1->type = (byte) 52;
                WorldGen.SquareTileFrame(i, j, -1);
                return;
              }
              else if (num22 != type && (num22 == -1 || type == 52 && num22 != 2 || (type == 62 && num22 != 60 || type == 115 && num22 != 109)))
                WorldGen.KillTile(i, j);
            }
            if (!WorldGen.gen && Main.netMode != 1 && (type == 53 || type == 112 || (type == 116 || type == 123)) && (int) tilePtr1[1].active == 0)
            {
              Tile* tilePtr2 = tilePtr1 - 1;
              if ((int) tilePtr2->active == 0 || (int) tilePtr2->type != 21)
              {
                tilePtr1->active = (byte) 0;
                WorldGen.sandBuffer[WorldGen.currentSandBuffer].Add(i, j);
                return;
              }
            }
            if (num1 >= 0 && num3 != num1 && (num2 >= 0 && num4 != num2) && WorldGen.tileFrameRecursion)
            {
              bool flag4 = WorldGen.mergeUp;
              bool flag5 = WorldGen.mergeDown;
              bool flag6 = WorldGen.mergeLeft;
              bool flag7 = WorldGen.mergeRight;
              WorldGen.TileFrame(i, j - 1, 0);
              WorldGen.TileFrame(i, j + 1, 0);
              WorldGen.TileFrame(i - 1, j, 0);
              WorldGen.TileFrame(i + 1, j, 0);
              WorldGen.mergeUp = flag4;
              WorldGen.mergeDown = flag5;
              WorldGen.mergeLeft = flag6;
              WorldGen.mergeRight = flag7;
            }
          }
        }
      }
    }

    public static unsafe void TileFrameNoLiquid(int i, int j, int frameNumber = 0)
    {
      if (i <= 5 || j <= 5 || (i >= (int) Main.maxTilesX - 5 || j >= (int) Main.maxTilesY - 5))
        return;
      fixed (Tile* tilePtr1 = &Main.tile[i, j])
      {
        if ((int) tilePtr1->active != 0)
        {
          int index1 = (int) tilePtr1->type;
          if (Main.tileStone[index1])
            index1 = 1;
          int num1 = (int) tilePtr1->frameX;
          int num2 = (int) tilePtr1->frameY;
          int num3 = -1;
          int num4 = -1;
          if (Main.tileFrameImportant[index1])
          {
            switch (index1)
            {
              case 3:
              case 24:
              case 61:
              case 71:
              case 73:
              case 74:
              case 110:
              case 113:
                WorldGen.PlantCheck(i, j);
                break;
              case 4:
                int num5 = (int) tilePtr1->frameX >= 66 ? 66 : 0;
                int index2 = -1;
                int index3 = -1;
                int index4 = -1;
                int num6 = -1;
                int num7 = -1;
                int num8 = -1;
                int num9 = -1;
                if ((int) tilePtr1[-1].active != 0)
                {
                  int num10 = (int) tilePtr1[-1].type;
                }
                if ((int) tilePtr1[1].active != 0)
                  index2 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  index3 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  index4 = (int) tilePtr1[1440].type;
                if ((int) tilePtr1[-1439].active != 0)
                  num6 = (int) tilePtr1[-1439].type;
                if ((int) tilePtr1[1441].active != 0)
                  num7 = (int) tilePtr1[1441].type;
                if ((int) tilePtr1[-1441].active != 0)
                  num8 = (int) tilePtr1[-1441].type;
                if ((int) tilePtr1[1439].active != 0)
                  num9 = (int) tilePtr1[1439].type;
                if (index2 >= 0 && Main.tileSolidAndAttach[index2])
                {
                  tilePtr1->frameX = (short) num5;
                  break;
                }
                else if (index3 >= 0 && (Main.tileSolidAndAttach[index3] || index3 == 124 || index3 == 5 && num8 == 5 && num6 == 5))
                {
                  tilePtr1->frameX = (short) (22 + num5);
                  break;
                }
                else if (index4 >= 0 && (Main.tileSolidAndAttach[index4] || index4 == 124 || index4 == 5 && num9 == 5 && num7 == 5))
                {
                  tilePtr1->frameX = (short) (44 + num5);
                  break;
                }
                else
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 5:
                break;
              case 6:
                break;
              case 7:
                break;
              case 8:
                break;
              case 9:
                break;
              case 10:
                if (WorldGen.destroyObject)
                  break;
                int j1 = j - num2 / 18;
                bool flag1 = false;
                if ((int) Main.tile[i, j1 - 1].active == 0 || !Main.tileSolid[(int) Main.tile[i, j1 - 1].type])
                  flag1 = true;
                else if ((int) Main.tile[i, j1 + 3].active == 0 || !Main.tileSolid[(int) Main.tile[i, j1 + 3].type])
                  flag1 = true;
                else if ((int) Main.tile[i, j1].active == 0 || (int) Main.tile[i, j1].type != index1)
                  flag1 = true;
                else if ((int) Main.tile[i, j1 + 1].active == 0 || (int) Main.tile[i, j1 + 1].type != index1)
                  flag1 = true;
                else if ((int) Main.tile[i, j1 + 2].active == 0 || (int) Main.tile[i, j1 + 2].type != index1)
                  flag1 = true;
                if (flag1)
                {
                  WorldGen.destroyObject = true;
                  WorldGen.KillTile(i, j1);
                  WorldGen.KillTile(i, j1 + 1);
                  WorldGen.KillTile(i, j1 + 2);
                  if (!WorldGen.gen)
                    Item.NewItem(i * 16, j * 16, 16, 16, 25, 1, false, 0);
                }
                WorldGen.destroyObject = false;
                break;
              case 11:
                if (WorldGen.destroyObject)
                  break;
                int num11 = 0;
                int num12 = 0;
                int num13 = i;
                int num14 = j;
                bool flag2 = false;
                if (num1 == 0)
                  num11 = 1;
                else if (num1 == 18)
                {
                  num13 = i - 1;
                  num12 = -1440;
                  num11 = 1;
                }
                else if (num1 == 36)
                {
                  num12 = 1440;
                  num13 = i + 1;
                  num11 = -1;
                }
                else if (num1 == 54)
                  num11 = -1;
                if (num2 == 18)
                {
                  --num12;
                  num14 = j - 1;
                }
                else if (num2 == 36)
                {
                  num14 = j - 2;
                  num12 -= 2;
                }
                if ((int) tilePtr1[num12 - 1].active == 0 || !Main.tileSolid[(int) tilePtr1[num12 - 1].type] || ((int) tilePtr1[num12 + 3].active == 0 || !Main.tileSolid[(int) tilePtr1[num12 + 3].type]))
                {
                  flag2 = true;
                  WorldGen.destroyObject = true;
                  if (!WorldGen.gen)
                    Item.NewItem(i * 16, j * 16, 16, 16, 25, 1, false, 0);
                }
                int num15 = num13;
                if (num11 == -1)
                  num15 = num13 - 1;
                for (int i1 = num15; i1 < num15 + 2; ++i1)
                {
                  for (int j2 = num14; j2 < num14 + 3; ++j2)
                  {
                    if (!flag2)
                    {
                      fixed (Tile* tilePtr2 = &Main.tile[i1, j2])
                      {
                        if ((int) tilePtr2->type != 11 || (int) tilePtr2->active == 0)
                        {
                          WorldGen.destroyObject = true;
                          flag2 = true;
                          i1 = num15;
                          j2 = num14;
                          if (!WorldGen.gen)
                            Item.NewItem(i * 16, j * 16, 16, 16, 25, 1, false, 0);
                        }
                      }
                    }
                    if (flag2)
                      WorldGen.KillTile(i1, j2);
                  }
                }
                WorldGen.destroyObject = false;
                break;
              case 12:
                break;
              case 13:
                break;
              case 14:
                break;
              case 15:
                break;
              case 16:
                break;
              case 17:
                break;
              case 18:
                break;
              case 19:
                break;
              case 20:
                break;
              case 21:
                break;
              case 22:
                break;
              case 23:
                break;
              case 25:
                break;
              case 26:
                break;
              case 27:
                break;
              case 28:
                break;
              case 29:
                break;
              case 30:
                break;
              case 31:
                break;
              case 32:
                break;
              case 33:
                break;
              case 34:
                break;
              case 35:
                break;
              case 36:
                break;
              case 37:
                break;
              case 38:
                break;
              case 39:
                break;
              case 40:
                break;
              case 41:
                break;
              case 42:
                break;
              case 43:
                break;
              case 44:
                break;
              case 45:
                break;
              case 46:
                break;
              case 47:
                break;
              case 48:
                break;
              case 49:
                break;
              case 50:
                break;
              case 51:
                break;
              case 52:
                break;
              case 53:
                break;
              case 54:
                break;
              case 55:
                break;
              case 56:
                break;
              case 57:
                break;
              case 58:
                break;
              case 59:
                break;
              case 60:
                break;
              case 62:
                break;
              case 63:
                break;
              case 64:
                break;
              case 65:
                break;
              case 66:
                break;
              case 67:
                break;
              case 68:
                break;
              case 69:
                break;
              case 70:
                break;
              case 72:
                int num16 = -1;
                int num17 = -1;
                if ((int) tilePtr1[-1].active != 0)
                  num17 = (int) tilePtr1[-1].type;
                if ((int) tilePtr1[1].active != 0)
                  num16 = (int) tilePtr1[1].type;
                if (num16 != index1 && num16 != 70)
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
                else
                {
                  if (num17 == index1 || (int) tilePtr1->frameX != 0)
                    break;
                  tilePtr1->frameNumber = (byte) WorldGen.genRand.Next(3);
                  tilePtr1->frameX = (short) 18;
                  tilePtr1->frameY = (short) (18 * (int) tilePtr1->frameNumber);
                  break;
                }
              case 75:
                break;
              case 76:
                break;
              case 77:
                break;
              case 78:
                break;
              case 79:
                break;
              case 80:
                break;
              case 81:
                int index5 = -1;
                int num18 = -1;
                int num19 = -1;
                int num20 = -1;
                if ((int) tilePtr1[-1].active != 0)
                  num18 = (int) tilePtr1[-1].type;
                if ((int) tilePtr1[1].active != 0)
                  index5 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  num19 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  num20 = (int) tilePtr1[1440].type;
                if (num19 != -1 || num18 != -1 || num20 != -1)
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
                else
                {
                  if (index5 >= 0 && Main.tileSolid[index5])
                    break;
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 82:
                break;
              case 83:
                break;
              case 84:
                break;
              case 85:
                break;
              case 86:
                break;
              case 87:
                break;
              case 88:
                break;
              case 89:
                break;
              case 90:
                break;
              case 91:
                break;
              case 92:
                break;
              case 93:
                break;
              case 94:
                break;
              case 95:
                break;
              case 96:
                break;
              case 97:
                break;
              case 98:
                break;
              case 99:
                break;
              case 100:
                break;
              case 101:
                break;
              case 102:
                break;
              case 103:
                break;
              case 104:
                break;
              case 105:
                break;
              case 106:
                break;
              case 107:
                break;
              case 108:
                break;
              case 109:
                break;
              case 111:
                break;
              case 112:
                break;
              case 114:
                break;
              case 115:
                break;
              case 116:
                break;
              case 117:
                break;
              case 118:
                break;
              case 119:
                break;
              case 120:
                break;
              case 121:
                break;
              case 122:
                break;
              case 123:
                break;
              case 124:
                break;
              case 125:
                break;
              case 126:
                break;
              case (int) sbyte.MaxValue:
                break;
              case 128:
                break;
              case 129:
              case 149:
                int index6 = -1;
                int index7 = -1;
                int index8 = -1;
                int index9 = -1;
                if ((int) tilePtr1[-1].active != 0)
                  index7 = (int) tilePtr1[-1].type;
                if ((int) tilePtr1[1].active != 0)
                  index6 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  index8 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  index9 = (int) tilePtr1[1440].type;
                if (index6 >= 0 && Main.tileSolidNotSolidTop[index6])
                {
                  tilePtr1->frameY = (short) 0;
                  break;
                }
                else if (index8 >= 0 && Main.tileSolidNotSolidTop[index8])
                {
                  tilePtr1->frameY = (short) 54;
                  break;
                }
                else if (index9 >= 0 && Main.tileSolidNotSolidTop[index9])
                {
                  tilePtr1->frameY = (short) 36;
                  break;
                }
                else if (index7 >= 0 && Main.tileSolidNotSolidTop[index7])
                {
                  tilePtr1->frameY = (short) 18;
                  break;
                }
                else
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 130:
                break;
              case 131:
                break;
              case 132:
                break;
              case 133:
                break;
              case 134:
                break;
              case 135:
                break;
              case 136:
                int index10 = -1;
                int index11 = -1;
                int index12 = -1;
                if ((int) tilePtr1[-1].active != 0)
                {
                  int num21 = (int) tilePtr1[-1].type;
                }
                if ((int) tilePtr1[1].active != 0)
                  index10 = (int) tilePtr1[1].type;
                if ((int) tilePtr1[-1440].active != 0)
                  index11 = (int) tilePtr1[-1440].type;
                if ((int) tilePtr1[1440].active != 0)
                  index12 = (int) tilePtr1[1440].type;
                if (index10 >= 0 && Main.tileSolidAndAttach[index10])
                {
                  tilePtr1->frameX = (short) 0;
                  break;
                }
                else if (index11 >= 0 && (Main.tileSolidAndAttach[index11] || index11 == 124 || index11 == 5))
                {
                  tilePtr1->frameX = (short) 18;
                  break;
                }
                else if (index12 >= 0 && (Main.tileSolidAndAttach[index12] || index12 == 124 || index12 == 5))
                {
                  tilePtr1->frameX = (short) 36;
                  break;
                }
                else
                {
                  WorldGen.KillTile(i, j);
                  break;
                }
              case 137:
                break;
              case 138:
                break;
              case 139:
                break;
              case 140:
                break;
              case 141:
                break;
              case 142:
                break;
              case 143:
                break;
              case 144:
                break;
              case 145:
                break;
              case 146:
                break;
              case 147:
                break;
              case 148:
                break;
              default:
                break;
            }
          }
          else
          {
            int index13 = -1;
            int index14 = -1;
            int index15 = -1;
            int index16 = -1;
            int index17 = -1;
            int index18 = -1;
            int index19 = -1;
            int index20 = -1;
            if ((int) tilePtr1[-1440].active != 0)
            {
              int index21 = (int) tilePtr1[-1440].type;
              index16 = Main.tileStone[index21] ? 1 : index21;
            }
            if ((int) tilePtr1[1440].active != 0)
            {
              int index21 = (int) tilePtr1[1440].type;
              index17 = Main.tileStone[index21] ? 1 : index21;
            }
            if ((int) tilePtr1[-1].active != 0)
            {
              int index21 = (int) tilePtr1[-1].type;
              index14 = Main.tileStone[index21] ? 1 : index21;
            }
            if ((int) tilePtr1[1].active != 0)
            {
              int index21 = (int) tilePtr1[1].type;
              index19 = Main.tileStone[index21] ? 1 : index21;
            }
            if ((int) tilePtr1[-1441].active != 0)
            {
              int index21 = (int) tilePtr1[-1441].type;
              index13 = Main.tileStone[index21] ? 1 : index21;
            }
            if ((int) tilePtr1[1439].active != 0)
            {
              int index21 = (int) tilePtr1[1439].type;
              index15 = Main.tileStone[index21] ? 1 : index21;
            }
            if ((int) tilePtr1[-1439].active != 0)
            {
              int index21 = (int) tilePtr1[-1439].type;
              index18 = Main.tileStone[index21] ? 1 : index21;
            }
            if ((int) tilePtr1[1441].active != 0)
            {
              int index21 = (int) tilePtr1[1441].type;
              index20 = Main.tileStone[index21] ? 1 : index21;
            }
            if (index1 == 19)
            {
              if (index17 >= 0 && !Main.tileSolid[index17])
                index17 = -1;
              if (index16 >= 0 && !Main.tileSolid[index16])
                index16 = -1;
              num3 = index16 != index1 ? (index16 >= 0 ? (index17 != index1 ? (index17 >= 0 ? 90 : 108) : 54) : (index17 != index1 ? (index17 <= 0 ? 90 : 126) : 36)) : (index17 != index1 ? (index17 >= 0 ? 72 : 18) : 0);
              num4 = 18 * (int) tilePtr1->frameNumber;
            }
            else if (index1 == 80)
            {
              WorldGen.CactusFrame(i, j);
              return;
            }
            else if (index1 == 49)
              return;
            WorldGen.mergeUp2 = false;
            WorldGen.mergeDown2 = false;
            WorldGen.mergeLeft2 = false;
            WorldGen.mergeRight2 = false;
            if (frameNumber < 0)
            {
              frameNumber = WorldGen.genRand.Next(3);
              tilePtr1->frameNumber = (byte) frameNumber;
            }
            else
              frameNumber = (int) tilePtr1->frameNumber;
            if (index1 == 0)
            {
              if (index14 >= 0 && Main.tileMergeDirt[index14])
              {
                WorldGen.TileFrameNoLiquid(i, j - 1, 0);
                if (WorldGen.mergeDown2)
                  index14 = index1;
              }
              if (index19 >= 0 && Main.tileMergeDirt[index19])
              {
                WorldGen.TileFrameNoLiquid(i, j + 1, 0);
                if (WorldGen.mergeUp2)
                  index19 = index1;
              }
              if (index16 >= 0 && Main.tileMergeDirt[index16])
              {
                WorldGen.TileFrameNoLiquid(i - 1, j, 0);
                if (WorldGen.mergeRight2)
                  index16 = index1;
              }
              if (index17 >= 0 && Main.tileMergeDirt[index17])
              {
                WorldGen.TileFrameNoLiquid(i + 1, j, 0);
                if (WorldGen.mergeLeft2)
                  index17 = index1;
              }
              if (index14 == 2 || index14 == 23 || index14 == 109)
                index14 = index1;
              if (index19 == 2 || index19 == 23 || index19 == 109)
                index19 = index1;
              if (index16 == 2 || index16 == 23 || index16 == 109)
                index16 = index1;
              if (index17 == 2 || index17 == 23 || index17 == 109)
                index17 = index1;
              if (index13 >= 0 && Main.tileMergeDirt[index13])
                index13 = index1;
              else if (index13 == 2 || index13 == 23 || index13 == 109)
                index13 = index1;
              if (index15 >= 0 && Main.tileMergeDirt[index15])
                index15 = index1;
              else if (index15 == 2 || index15 == 23 || index15 == 109)
                index15 = index1;
              if (index18 >= 0 && Main.tileMergeDirt[index18])
                index18 = index1;
              else if (index18 == 2 || index18 == 23 || index15 == 109)
                index18 = index1;
              if (index20 >= 0 && Main.tileMergeDirt[index20])
                index20 = index1;
              else if (index20 == 2 || index20 == 23 || index20 == 109)
                index20 = index1;
              if (j < Main.rockLayer)
              {
                if (index14 == 59)
                  index14 = -2;
                if (index19 == 59)
                  index19 = -2;
                if (index16 == 59)
                  index16 = -2;
                if (index17 == 59)
                  index17 = -2;
                if (index13 == 59)
                  index13 = -2;
                if (index15 == 59)
                  index15 = -2;
                if (index18 == 59)
                  index18 = -2;
                if (index20 == 59)
                  index20 = -2;
              }
            }
            else if (Main.tileMergeDirt[index1])
            {
              if (index14 == 0)
                index14 = -2;
              if (index19 == 0)
                index19 = -2;
              if (index16 == 0)
                index16 = -2;
              if (index17 == 0)
                index17 = -2;
              if (index13 == 0)
                index13 = -2;
              if (index15 == 0)
                index15 = -2;
              if (index18 == 0)
                index18 = -2;
              if (index20 == 0)
                index20 = -2;
              if (index1 == 1)
              {
                if (j > Main.rockLayer)
                {
                  if (index14 == 59)
                  {
                    WorldGen.TileFrameNoLiquid(i, j - 1, 0);
                    if (WorldGen.mergeDown2)
                      index14 = index1;
                  }
                  if (index19 == 59)
                  {
                    WorldGen.TileFrameNoLiquid(i, j + 1, 0);
                    if (WorldGen.mergeUp2)
                      index19 = index1;
                  }
                  if (index16 == 59)
                  {
                    WorldGen.TileFrameNoLiquid(i - 1, j, 0);
                    if (WorldGen.mergeRight2)
                      index16 = index1;
                  }
                  if (index17 == 59)
                  {
                    WorldGen.TileFrameNoLiquid(i + 1, j, 0);
                    if (WorldGen.mergeLeft2)
                      index17 = index1;
                  }
                  if (index13 == 59)
                    index13 = index1;
                  if (index15 == 59)
                    index15 = index1;
                  if (index18 == 59)
                    index18 = index1;
                  if (index20 == 59)
                    index20 = index1;
                }
                if (index14 == 57)
                {
                  WorldGen.TileFrameNoLiquid(i, j - 1, 0);
                  if (WorldGen.mergeDown2)
                    index14 = index1;
                }
                if (index19 == 57)
                {
                  WorldGen.TileFrameNoLiquid(i, j + 1, 0);
                  if (WorldGen.mergeUp2)
                    index19 = index1;
                }
                if (index16 == 57)
                {
                  WorldGen.TileFrameNoLiquid(i - 1, j, 0);
                  if (WorldGen.mergeRight2)
                    index16 = index1;
                }
                if (index17 == 57)
                {
                  WorldGen.TileFrameNoLiquid(i + 1, j, 0);
                  if (WorldGen.mergeLeft2)
                    index17 = index1;
                }
                if (index13 == 57)
                  index13 = index1;
                if (index15 == 57)
                  index15 = index1;
                if (index18 == 57)
                  index18 = index1;
                if (index20 == 57)
                  index20 = index1;
              }
            }
            else if (index1 == 58 || index1 == 76 || index1 == 75)
            {
              if (index14 == 57)
                index14 = -2;
              if (index19 == 57)
                index19 = -2;
              if (index16 == 57)
                index16 = -2;
              if (index17 == 57)
                index17 = -2;
              if (index13 == 57)
                index13 = -2;
              if (index15 == 57)
                index15 = -2;
              if (index18 == 57)
                index18 = -2;
              if (index20 == 57)
                index20 = -2;
            }
            else if (index1 == 59)
            {
              if (j > Main.rockLayer)
              {
                if (index14 == 1)
                  index14 = -2;
                if (index19 == 1)
                  index19 = -2;
                if (index16 == 1)
                  index16 = -2;
                if (index17 == 1)
                  index17 = -2;
                if (index13 == 1)
                  index13 = -2;
                if (index15 == 1)
                  index15 = -2;
                if (index18 == 1)
                  index18 = -2;
                if (index20 == 1)
                  index20 = -2;
              }
              if (index14 == 60 || index14 == 70)
                index14 = index1;
              if (index19 == 60 || index19 == 70)
                index19 = index1;
              if (index16 == 60 || index16 == 70)
                index16 = index1;
              if (index17 == 60 || index17 == 70)
                index17 = index1;
              if (index13 == 60 || index13 == 70)
                index13 = index1;
              if (index15 == 60 || index15 == 70)
                index15 = index1;
              if (index18 == 60 || index18 == 70)
                index18 = index1;
              if (index20 == 60 || index20 == 70)
                index20 = index1;
              if (j < Main.rockLayer)
              {
                if (index14 == 0)
                {
                  WorldGen.TileFrameNoLiquid(i, j - 1, 0);
                  if (WorldGen.mergeDown2)
                    index14 = index1;
                }
                if (index19 == 0)
                {
                  WorldGen.TileFrameNoLiquid(i, j + 1, 0);
                  if (WorldGen.mergeUp2)
                    index19 = index1;
                }
                if (index16 == 0)
                {
                  WorldGen.TileFrameNoLiquid(i - 1, j, 0);
                  if (WorldGen.mergeRight2)
                    index16 = index1;
                }
                if (index17 == 0)
                {
                  WorldGen.TileFrameNoLiquid(i + 1, j, 0);
                  if (WorldGen.mergeLeft2)
                    index17 = index1;
                }
                if (index13 == 0)
                  index13 = index1;
                if (index15 == 0)
                  index15 = index1;
                if (index18 == 0)
                  index18 = index1;
                if (index20 == 0)
                  index20 = index1;
              }
            }
            else if (index1 == 57)
            {
              if (index14 == 1)
                index14 = -2;
              if (index19 == 1)
                index19 = -2;
              if (index16 == 1)
                index16 = -2;
              if (index17 == 1)
                index17 = -2;
              if (index13 == 1)
                index13 = -2;
              if (index15 == 1)
                index15 = -2;
              if (index18 == 1)
                index18 = -2;
              if (index20 == 1)
                index20 = -2;
              if (index14 == 58 || index14 == 76 || index14 == 75)
              {
                WorldGen.TileFrameNoLiquid(i, j - 1, 0);
                if (WorldGen.mergeDown2)
                  index14 = index1;
              }
              if (index19 == 58 || index19 == 76 || index19 == 75)
              {
                WorldGen.TileFrameNoLiquid(i, j + 1, 0);
                if (WorldGen.mergeUp2)
                  index19 = index1;
              }
              if (index16 == 58 || index16 == 76 || index16 == 75)
              {
                WorldGen.TileFrameNoLiquid(i - 1, j, 0);
                if (WorldGen.mergeRight2)
                  index16 = index1;
              }
              if (index17 == 58 || index17 == 76 || index17 == 75)
              {
                WorldGen.TileFrameNoLiquid(i + 1, j, 0);
                if (WorldGen.mergeLeft2)
                  index17 = index1;
              }
              if (index13 == 58 || index13 == 76 || index13 == 75)
                index13 = index1;
              if (index15 == 58 || index15 == 76 || index15 == 75)
                index15 = index1;
              if (index18 == 58 || index18 == 76 || index18 == 75)
                index18 = index1;
              if (index20 == 58 || index20 == 76 || index20 == 75)
                index20 = index1;
            }
            else if (index1 == 32)
            {
              if (index19 == 23)
                index19 = index1;
            }
            else if (index1 == 69)
            {
              if (index19 == 60)
                index19 = index1;
            }
            else if (index1 == 51)
            {
              if (index14 >= 0 && !Main.tileNoAttach[index14])
                index14 = index1;
              if (index19 >= 0 && !Main.tileNoAttach[index19])
                index19 = index1;
              if (index16 >= 0 && !Main.tileNoAttach[index16])
                index16 = index1;
              if (index17 >= 0 && !Main.tileNoAttach[index17])
                index17 = index1;
              if (index13 >= 0 && !Main.tileNoAttach[index13])
                index13 = index1;
              if (index15 >= 0 && !Main.tileNoAttach[index15])
                index15 = index1;
              if (index18 >= 0 && !Main.tileNoAttach[index18])
                index18 = index1;
              if (index20 >= 0 && !Main.tileNoAttach[index20])
                index20 = index1;
            }
            bool flag3 = false;
            if (index1 == 2 || index1 == 23 || (index1 == 60 || index1 == 70) || index1 == 109)
            {
              flag3 = true;
              if (index14 >= 0 && index14 != index1 && !Main.tileSolid[index14])
                index14 = -1;
              if (index19 >= 0 && index19 != index1 && !Main.tileSolid[index19])
                index19 = -1;
              if (index16 >= 0 && index16 != index1 && !Main.tileSolid[index16])
                index16 = -1;
              if (index17 >= 0 && index17 != index1 && !Main.tileSolid[index17])
                index17 = -1;
              if (index13 >= 0 && index13 != index1 && !Main.tileSolid[index13])
                index13 = -1;
              if (index15 >= 0 && index15 != index1 && !Main.tileSolid[index15])
                index15 = -1;
              if (index18 >= 0 && index18 != index1 && !Main.tileSolid[index18])
                index18 = -1;
              if (index20 >= 0 && index20 != index1 && !Main.tileSolid[index20])
                index20 = -1;
              int num22 = 0;
              if (index1 == 60 || index1 == 70)
                num22 = 59;
              else if (index1 == 2)
              {
                if (index14 == 23)
                  index14 = num22;
                if (index19 == 23)
                  index19 = num22;
                if (index16 == 23)
                  index16 = num22;
                if (index17 == 23)
                  index17 = num22;
                if (index13 == 23)
                  index13 = num22;
                if (index15 == 23)
                  index15 = num22;
                if (index18 == 23)
                  index18 = num22;
                if (index20 == 23)
                  index20 = num22;
              }
              else if (index1 == 23)
              {
                if (index14 == 2)
                  index14 = num22;
                if (index19 == 2)
                  index19 = num22;
                if (index16 == 2)
                  index16 = num22;
                if (index17 == 2)
                  index17 = num22;
                if (index13 == 2)
                  index13 = num22;
                if (index15 == 2)
                  index15 = num22;
                if (index18 == 2)
                  index18 = num22;
                if (index20 == 2)
                  index20 = num22;
              }
              if (index14 != index1 && index14 != num22 && (index19 == index1 || index19 == num22))
              {
                if (index16 == num22 && index17 == index1)
                {
                  num3 = 18 * frameNumber;
                  num4 = 198;
                }
                else if (index16 == index1 && index17 == num22)
                {
                  num3 = 54 + 18 * frameNumber;
                  num4 = 198;
                }
              }
              else if (index19 != index1 && index19 != num22 && (index14 == index1 || index14 == num22))
              {
                if (index16 == num22 && index17 == index1)
                {
                  num3 = 18 * frameNumber;
                  num4 = 216;
                }
                else if (index16 == index1 && index17 == num22)
                {
                  num3 = 54 + 18 * frameNumber;
                  num4 = 216;
                }
              }
              else if (index16 != index1 && index16 != num22 && (index17 == index1 || index17 == num22))
              {
                if (index14 == num22 && index19 == index1)
                {
                  num3 = 72;
                  num4 = 144 + 18 * frameNumber;
                }
                else if (index19 == index1 && index17 == index14)
                {
                  num3 = 72;
                  num4 = 90 + 18 * frameNumber;
                }
              }
              else if (index17 != index1 && index17 != num22 && (index16 == index1 || index16 == num22))
              {
                if (index14 == num22 && index19 == index1)
                {
                  num3 = 90;
                  num4 = 144 + 18 * frameNumber;
                }
                else if (index19 == index1 && index17 == index14)
                {
                  num3 = 90;
                  num4 = 90 + 18 * frameNumber;
                }
              }
              else if (index14 == index1 && index19 == index1 && (index16 == index1 && index17 == index1))
              {
                if (index13 != index1 && index15 != index1 && (index18 != index1 && index20 != index1))
                {
                  if (index20 == num22)
                  {
                    num4 = 324;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else if (index15 == num22)
                  {
                    num4 = 342;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else if (index18 == num22)
                  {
                    num4 = 360;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else if (index13 == num22)
                  {
                    num4 = 378;
                    num3 = 108 + 18 * frameNumber;
                  }
                  else
                  {
                    num4 = 234;
                    num3 = 144 + 54 * frameNumber;
                  }
                }
                else if (index13 != index1 && index20 != index1)
                {
                  num4 = 306;
                  num3 = 36 + 18 * frameNumber;
                }
                else if (index15 != index1 && index18 != index1)
                {
                  num4 = 306;
                  num3 = 90 + 18 * frameNumber;
                }
                else if (index13 != index1 && index15 == index1 && (index18 == index1 && index20 == index1))
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index13 == index1 && index15 != index1 && (index18 == index1 && index20 == index1))
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index13 == index1 && index15 == index1 && (index18 != index1 && index20 == index1))
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index13 == index1 && index15 == index1 && (index18 == index1 && index20 != index1))
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
              }
              else if (index14 == index1 && index19 == num22 && (index16 == index1 && index17 == index1) && (index13 == -1 && index15 == -1))
              {
                num4 = 18;
                num3 = 108 + 18 * frameNumber;
              }
              else if (index14 == num22 && index19 == index1 && (index16 == index1 && index17 == index1) && (index18 == -1 && index20 == -1))
              {
                num4 = 36;
                num3 = 108 + 18 * frameNumber;
              }
              else if (index14 == index1 && index19 == index1 && (index16 == num22 && index17 == index1) && (index15 == -1 && index20 == -1))
              {
                num3 = 198;
                num4 = 18 * frameNumber;
              }
              else if (index14 == index1 && index19 == index1 && (index16 == index1 && index17 == num22) && (index13 == -1 && index18 == -1))
              {
                num3 = 180;
                num4 = 18 * frameNumber;
              }
              else if (index14 == index1 && index19 == num22 && (index16 == index1 && index17 == index1))
              {
                if (index15 != -1)
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index13 != -1)
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
              }
              else if (index14 == num22 && index19 == index1 && (index16 == index1 && index17 == index1))
              {
                if (index20 != -1)
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index18 != -1)
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
              }
              else if (index14 == index1 && index19 == index1 && (index16 == index1 && index17 == num22))
              {
                if (index13 != -1)
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index18 != -1)
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
              }
              else if (index14 == index1 && index19 == index1 && (index16 == num22 && index17 == index1))
              {
                if (index15 != -1)
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index20 != -1)
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
              }
              else if (index14 == num22 && index19 == index1 && (index16 == index1 && index17 == index1) || index14 == index1 && index19 == num22 && (index16 == index1 && index17 == index1) || (index14 == index1 && index19 == index1 && (index16 == num22 && index17 == index1) || index14 == index1 && index19 == index1 && (index16 == index1 && index17 == num22)))
              {
                num4 = 18;
                num3 = 18 + 18 * frameNumber;
              }
              if ((index14 == index1 || index14 == num22) && (index19 == index1 || index19 == num22) && ((index16 == index1 || index16 == num22) && (index17 == index1 || index17 == num22)))
              {
                if (index13 != index1 && index13 != num22 && (index15 == index1 || index15 == num22) && ((index18 == index1 || index18 == num22) && (index20 == index1 || index20 == num22)))
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index15 != index1 && index15 != num22 && (index13 == index1 || index13 == num22) && ((index18 == index1 || index18 == num22) && (index20 == index1 || index20 == num22)))
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                }
                else if (index18 != index1 && index18 != num22 && (index13 == index1 || index13 == num22) && ((index15 == index1 || index15 == num22) && (index20 == index1 || index20 == num22)))
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                }
                else if (index20 != index1 && index20 != num22 && (index13 == index1 || index13 == num22) && ((index18 == index1 || index18 == num22) && (index15 == index1 || index15 == num22)))
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                }
              }
              if (index14 != num22 && index14 != index1 && (index19 == index1 && index16 != num22) && (index16 != index1 && index17 == index1 && (index20 != num22 && index20 != index1)))
              {
                num4 = 270;
                num3 = 90 + 18 * frameNumber;
              }
              else if (index14 != num22 && index14 != index1 && (index19 == index1 && index16 == index1) && (index17 != num22 && index17 != index1 && (index18 != num22 && index18 != index1)))
              {
                num4 = 270;
                num3 = 144 + 18 * frameNumber;
              }
              else if (index19 != num22 && index19 != index1 && (index14 == index1 && index16 != num22) && (index16 != index1 && index17 == index1 && (index15 != num22 && index15 != index1)))
              {
                num4 = 288;
                num3 = 90 + 18 * frameNumber;
              }
              else if (index19 != num22 && index19 != index1 && (index14 == index1 && index16 == index1) && (index17 != num22 && index17 != index1 && (index13 != num22 && index13 != index1)))
              {
                num4 = 288;
                num3 = 144 + 18 * frameNumber;
              }
              else if (index14 != index1 && index14 != num22 && (index19 == index1 && index16 == index1) && (index17 == index1 && index18 != index1 && (index18 != num22 && index20 != index1)) && index20 != num22)
              {
                num4 = 216;
                num3 = 144 + 54 * frameNumber;
              }
              else if (index19 != index1 && index19 != num22 && (index14 == index1 && index16 == index1) && (index17 == index1 && index13 != index1 && (index13 != num22 && index15 != index1)) && index15 != num22)
              {
                num4 = 252;
                num3 = 144 + 54 * frameNumber;
              }
              else if (index16 != index1 && index16 != num22 && (index19 == index1 && index14 == index1) && (index17 == index1 && index15 != index1 && (index15 != num22 && index20 != index1)) && index20 != num22)
              {
                num4 = 234;
                num3 = 126 + 54 * frameNumber;
              }
              else if (index17 != index1 && index17 != num22 && (index19 == index1 && index14 == index1) && (index16 == index1 && index13 != index1 && (index13 != num22 && index18 != index1)) && index18 != num22)
              {
                num4 = 234;
                num3 = 162 + 54 * frameNumber;
              }
              else if (index14 != num22 && index14 != index1 && (index19 == num22 || index19 == index1) && (index16 == num22 && index17 == num22))
              {
                num4 = 270;
                num3 = 36 + 18 * frameNumber;
              }
              else if (index19 != num22 && index19 != index1 && (index14 == num22 || index14 == index1) && (index16 == num22 && index17 == num22))
              {
                num4 = 288;
                num3 = 36 + 18 * frameNumber;
              }
              else if (index16 != num22 && index16 != index1 && (index17 == num22 || index17 == index1) && (index14 == num22 && index19 == num22))
              {
                num3 = 0;
                num4 = 270 + 18 * frameNumber;
              }
              else if (index17 != num22 && index17 != index1 && (index16 == num22 || index16 == index1) && (index14 == num22 && index19 == num22))
              {
                num3 = 18;
                num4 = 270 + 18 * frameNumber;
              }
              else if (index14 == index1 && index19 == num22 && (index16 == num22 && index17 == num22))
              {
                num4 = 288;
                num3 = 198 + 18 * frameNumber;
              }
              else if (index14 == num22 && index19 == index1 && (index16 == num22 && index17 == num22))
              {
                num4 = 270;
                num3 = 198 + 18 * frameNumber;
              }
              else if (index14 == num22 && index19 == num22 && (index16 == index1 && index17 == num22))
              {
                num4 = 306;
                num3 = 198 + 18 * frameNumber;
              }
              else if (index14 == num22 && index19 == num22 && (index16 == num22 && index17 == index1))
              {
                num4 = 306;
                num3 = 144 + 18 * frameNumber;
              }
              if (index14 != index1 && index14 != num22 && (index19 == index1 && index16 == index1) && index17 == index1)
              {
                if ((index18 == num22 || index18 == index1) && (index20 != num22 && index20 != index1))
                {
                  num4 = 324;
                  num3 = 18 * frameNumber;
                }
                else if ((index20 == num22 || index20 == index1) && (index18 != num22 && index18 != index1))
                {
                  num4 = 324;
                  num3 = 54 + 18 * frameNumber;
                }
              }
              else if (index19 != index1 && index19 != num22 && (index14 == index1 && index16 == index1) && index17 == index1)
              {
                if ((index13 == num22 || index13 == index1) && (index15 != num22 && index15 != index1))
                {
                  num4 = 342;
                  num3 = 18 * frameNumber;
                }
                else if ((index15 == num22 || index15 == index1) && (index13 != num22 && index13 != index1))
                {
                  num4 = 342;
                  num3 = 54 + 18 * frameNumber;
                }
              }
              else if (index16 != index1 && index16 != num22 && (index14 == index1 && index19 == index1) && index17 == index1)
              {
                if ((index15 == num22 || index15 == index1) && (index20 != num22 && index20 != index1))
                {
                  num4 = 360;
                  num3 = 54 + 18 * frameNumber;
                }
                else if ((index20 == num22 || index20 == index1) && (index15 != num22 && index15 != index1))
                {
                  num4 = 360;
                  num3 = 18 * frameNumber;
                }
              }
              else if (index17 != index1 && index17 != num22 && (index14 == index1 && index19 == index1) && index16 == index1)
              {
                if ((index13 == num22 || index13 == index1) && (index18 != num22 && index18 != index1))
                {
                  num4 = 378;
                  num3 = 18 * frameNumber;
                }
                else if ((index18 == num22 || index18 == index1) && (index13 != num22 && index13 != index1))
                {
                  num4 = 378;
                  num3 = 54 + 18 * frameNumber;
                }
              }
              if ((index14 == index1 || index14 == num22) && (index19 == index1 || index19 == num22) && ((index16 == index1 || index16 == num22) && (index17 == index1 || index17 == num22)) && (index13 != -1 && index15 != -1 && (index18 != -1 && index20 != -1)))
              {
                num4 = 18;
                num3 = 18 + 18 * frameNumber;
              }
              if (index14 == num22)
                index14 = -2;
              if (index19 == num22)
                index19 = -2;
              if (index16 == num22)
                index16 = -2;
              if (index17 == num22)
                index17 = -2;
              if (index13 == num22)
                index13 = -2;
              if (index15 == num22)
                index15 = -2;
              if (index18 == num22)
                index18 = -2;
              if (index20 == num22)
                index20 = -2;
            }
            if (num3 == -1 && (Main.tileMergeDirt[index1] || index1 == 0 || (index1 == 2 || index1 == 57) || (index1 == 58 || index1 == 59 || (index1 == 60 || index1 == 70)) || (index1 == 109 || index1 == 76 || index1 == 75)))
            {
              if (!flag3)
              {
                flag3 = true;
                if (index13 >= 0 && index13 != index1 && !Main.tileSolid[index13])
                  index13 = -1;
                if (index15 >= 0 && index15 != index1 && !Main.tileSolid[index15])
                  index15 = -1;
                if (index18 >= 0 && index18 != index1 && !Main.tileSolid[index18])
                  index18 = -1;
                if (index20 >= 0 && index20 != index1 && !Main.tileSolid[index20])
                  index20 = -1;
              }
              if (index14 >= 0 && index14 != index1)
                index14 = -1;
              if (index19 >= 0 && index19 != index1)
                index19 = -1;
              if (index16 >= 0 && index16 != index1)
                index16 = -1;
              if (index17 >= 0 && index17 != index1)
                index17 = -1;
              if (index14 != -1 && index19 != -1 && (index16 != -1 && index17 != -1))
              {
                if (index14 == -2 && index19 == index1 && (index16 == index1 && index17 == index1))
                {
                  num4 = 108;
                  num3 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp2 = true;
                }
                else if (index14 == index1 && index19 == -2 && (index16 == index1 && index17 == index1))
                {
                  num4 = 90;
                  num3 = 144 + 18 * frameNumber;
                  WorldGen.mergeDown2 = true;
                }
                else if (index14 == index1 && index19 == index1 && (index16 == -2 && index17 == index1))
                {
                  num3 = 162;
                  num4 = 126 + 18 * frameNumber;
                  WorldGen.mergeLeft2 = true;
                }
                else if (index14 == index1 && index19 == index1 && (index16 == index1 && index17 == -2))
                {
                  num3 = 144;
                  num4 = 126 + 18 * frameNumber;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == -2 && index19 == index1 && (index16 == -2 && index17 == index1))
                {
                  num3 = 36;
                  num4 = 90 + 36 * frameNumber;
                  WorldGen.mergeUp2 = true;
                  WorldGen.mergeLeft2 = true;
                }
                else if (index14 == -2 && index19 == index1 && (index16 == index1 && index17 == -2))
                {
                  num3 = 54;
                  num4 = 90 + 36 * frameNumber;
                  WorldGen.mergeUp2 = true;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == index1 && index19 == -2 && (index16 == -2 && index17 == index1))
                {
                  num3 = 36;
                  num4 = 108 + 36 * frameNumber;
                  WorldGen.mergeDown2 = true;
                  WorldGen.mergeLeft2 = true;
                }
                else if (index14 == index1 && index19 == -2 && (index16 == index1 && index17 == -2))
                {
                  num3 = 54;
                  num4 = 108 + 36 * frameNumber;
                  WorldGen.mergeDown2 = true;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == index1 && index19 == index1 && (index16 == -2 && index17 == -2))
                {
                  num3 = 180;
                  num4 = 126 + 18 * frameNumber;
                  WorldGen.mergeLeft2 = true;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == -2 && index19 == -2 && (index16 == index1 && index17 == index1))
                {
                  num4 = 180;
                  num3 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp2 = true;
                  WorldGen.mergeDown2 = true;
                }
                else if (index14 == -2 && index19 == index1 && (index16 == -2 && index17 == -2))
                {
                  num3 = 198;
                  num4 = 90 + 18 * frameNumber;
                  WorldGen.mergeUp2 = true;
                  WorldGen.mergeLeft2 = true;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == index1 && index19 == -2 && (index16 == -2 && index17 == -2))
                {
                  num3 = 198;
                  num4 = 144 + 18 * frameNumber;
                  WorldGen.mergeDown2 = true;
                  WorldGen.mergeLeft2 = true;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == -2 && index19 == -2 && (index16 == index1 && index17 == -2))
                {
                  num3 = 216;
                  num4 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp2 = true;
                  WorldGen.mergeDown2 = true;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == -2 && index19 == -2 && (index16 == -2 && index17 == index1))
                {
                  num3 = 216;
                  num4 = 90 + 18 * frameNumber;
                  WorldGen.mergeUp2 = true;
                  WorldGen.mergeDown2 = true;
                  WorldGen.mergeLeft2 = true;
                }
                else if (index14 == -2 && index19 == -2 && (index16 == -2 && index17 == -2))
                {
                  num4 = 198;
                  num3 = 108 + 18 * frameNumber;
                  WorldGen.mergeUp2 = true;
                  WorldGen.mergeDown2 = true;
                  WorldGen.mergeLeft2 = true;
                  WorldGen.mergeRight2 = true;
                }
                else if (index14 == index1 && index19 == index1 && (index16 == index1 && index17 == index1))
                {
                  if (index20 == -2)
                  {
                    num3 = 0;
                    num4 = 90 + 36 * frameNumber;
                  }
                  else if (index18 == -2)
                  {
                    num3 = 18;
                    num4 = 90 + 36 * frameNumber;
                  }
                  else if (index15 == -2)
                  {
                    num3 = 0;
                    num4 = 108 + 36 * frameNumber;
                  }
                  else if (index13 == -2)
                  {
                    num3 = 18;
                    num4 = 108 + 36 * frameNumber;
                  }
                }
              }
              else
              {
                if (index1 != 2 && index1 != 23 && (index1 != 60 && index1 != 70) && index1 != 109)
                {
                  if (index14 == -1 && index19 == -2 && (index16 == index1 && index17 == index1))
                  {
                    num4 = 0;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeDown2 = true;
                  }
                  else if (index14 == -2 && index19 == -1 && (index16 == index1 && index17 == index1))
                  {
                    num4 = 18;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeUp2 = true;
                  }
                  else if (index14 == index1 && index19 == index1 && (index16 == -1 && index17 == -2))
                  {
                    num4 = 36;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeRight2 = true;
                  }
                  else if (index14 == index1 && index19 == index1 && (index16 == -2 && index17 == -1))
                  {
                    num4 = 54;
                    num3 = 234 + 18 * frameNumber;
                    WorldGen.mergeLeft2 = true;
                  }
                }
                if (index14 != -1 && index19 != -1 && (index16 == -1 && index17 == index1))
                {
                  if (index14 == -2 && index19 == index1)
                  {
                    num3 = 72;
                    num4 = 144 + 18 * frameNumber;
                    WorldGen.mergeUp2 = true;
                  }
                  else if (index19 == -2 && index14 == index1)
                  {
                    num3 = 72;
                    num4 = 90 + 18 * frameNumber;
                    WorldGen.mergeDown2 = true;
                  }
                }
                else if (index14 != -1 && index19 != -1 && (index16 == index1 && index17 == -1))
                {
                  if (index14 == -2 && index19 == index1)
                  {
                    num3 = 90;
                    num4 = 144 + 18 * frameNumber;
                    WorldGen.mergeUp2 = true;
                  }
                  else if (index19 == -2 && index14 == index1)
                  {
                    num3 = 90;
                    num4 = 90 + 18 * frameNumber;
                    WorldGen.mergeDown2 = true;
                  }
                }
                else if (index14 == -1 && index19 == index1 && (index16 != -1 && index17 != -1))
                {
                  if (index16 == -2 && index17 == index1)
                  {
                    num3 = 18 * frameNumber;
                    num4 = 198;
                    WorldGen.mergeLeft2 = true;
                  }
                  else if (index17 == -2 && index16 == index1)
                  {
                    num3 = 54 + 18 * frameNumber;
                    num4 = 198;
                    WorldGen.mergeRight2 = true;
                  }
                }
                else if (index14 == index1 && index19 == -1 && (index16 != -1 && index17 != -1))
                {
                  if (index16 == -2 && index17 == index1)
                  {
                    num3 = 18 * frameNumber;
                    num4 = 216;
                    WorldGen.mergeLeft2 = true;
                  }
                  else if (index17 == -2 && index16 == index1)
                  {
                    num3 = 54 + 18 * frameNumber;
                    num4 = 216;
                    WorldGen.mergeRight2 = true;
                  }
                }
                else if (index14 != -1 && index19 != -1 && (index16 == -1 && index17 == -1))
                {
                  if (index14 == -2 && index19 == -2)
                  {
                    num3 = 108;
                    num4 = 216 + 18 * frameNumber;
                    WorldGen.mergeUp2 = true;
                    WorldGen.mergeDown2 = true;
                  }
                  else if (index14 == -2)
                  {
                    num3 = 126;
                    num4 = 144 + 18 * frameNumber;
                    WorldGen.mergeUp2 = true;
                  }
                  else if (index19 == -2)
                  {
                    num3 = 126;
                    num4 = 90 + 18 * frameNumber;
                    WorldGen.mergeDown2 = true;
                  }
                }
                else if (index14 == -1 && index19 == -1 && (index16 != -1 && index17 != -1))
                {
                  if (index16 == -2 && index17 == -2)
                  {
                    num4 = 198;
                    num3 = 162 + 18 * frameNumber;
                    WorldGen.mergeLeft2 = true;
                    WorldGen.mergeRight2 = true;
                  }
                  else if (index16 == -2)
                  {
                    num4 = 252;
                    num3 = 18 * frameNumber;
                    WorldGen.mergeLeft2 = true;
                  }
                  else if (index17 == -2)
                  {
                    num4 = 252;
                    num3 = 54 + 18 * frameNumber;
                    WorldGen.mergeRight2 = true;
                  }
                }
                else if (index14 == -2 && index19 == -1 && (index16 == -1 && index17 == -1))
                {
                  num3 = 108;
                  num4 = 144 + 18 * frameNumber;
                  WorldGen.mergeUp2 = true;
                }
                else if (index14 == -1 && index19 == -2 && (index16 == -1 && index17 == -1))
                {
                  num3 = 108;
                  num4 = 90 + 18 * frameNumber;
                  WorldGen.mergeDown2 = true;
                }
                else if (index14 == -1 && index19 == -1 && (index16 == -2 && index17 == -1))
                {
                  num4 = 234;
                  num3 = 18 * frameNumber;
                  WorldGen.mergeLeft2 = true;
                }
                else if (index14 == -1 && index19 == -1 && (index16 == -1 && index17 == -2))
                {
                  num4 = 234;
                  num3 = 54 + 18 * frameNumber;
                  WorldGen.mergeRight2 = true;
                }
              }
            }
            if (num3 < 0)
            {
              if (!flag3)
              {
                if (index14 >= 0 && index14 != index1 && !Main.tileSolid[index14])
                  index14 = -1;
                if (index19 >= 0 && index19 != index1 && !Main.tileSolid[index19])
                  index19 = -1;
                if (index16 >= 0 && index16 != index1 && !Main.tileSolid[index16])
                  index16 = -1;
                if (index17 >= 0 && index17 != index1 && !Main.tileSolid[index17])
                  index17 = -1;
                if (index13 >= 0 && index13 != index1 && !Main.tileSolid[index13])
                  index13 = -1;
                if (index15 >= 0 && index15 != index1 && !Main.tileSolid[index15])
                  index15 = -1;
                if (index18 >= 0 && index18 != index1 && !Main.tileSolid[index18])
                  index18 = -1;
                if (index20 >= 0 && index20 != index1 && !Main.tileSolid[index20])
                  index20 = -1;
              }
              if (index1 == 2 || index1 == 23 || (index1 == 60 || index1 == 70) || index1 == 109)
              {
                if (index14 == -2)
                  index14 = index1;
                if (index19 == -2)
                  index19 = index1;
                if (index16 == -2)
                  index16 = index1;
                if (index17 == -2)
                  index17 = index1;
                if (index13 == -2)
                  index13 = index1;
                if (index15 == -2)
                  index15 = index1;
                if (index18 == -2)
                  index18 = index1;
                if (index20 == -2)
                  index20 = index1;
              }
              if (index14 == index1 && index19 == index1 && index16 == index1 & index17 == index1)
              {
                if (index13 != index1 && index15 != index1)
                {
                  num4 = 18;
                  num3 = 108 + 18 * frameNumber;
                }
                else if (index18 != index1 && index20 != index1)
                {
                  num4 = 36;
                  num3 = 108 + 18 * frameNumber;
                }
                else if (index13 != index1 && index18 != index1)
                {
                  num3 = 180;
                  num4 = 18 * frameNumber;
                }
                else if (index15 != index1 && index20 != index1)
                {
                  num3 = 198;
                  num4 = 18 * frameNumber;
                }
                else
                {
                  num4 = 18;
                  num3 = 18 + 18 * frameNumber;
                }
              }
              else if (index14 != index1 && index19 == index1 && index16 == index1 & index17 == index1)
              {
                num4 = 0;
                num3 = 18 + 18 * frameNumber;
              }
              else if (index14 == index1 && index19 != index1 && index16 == index1 & index17 == index1)
              {
                num4 = 36;
                num3 = 18 + 18 * frameNumber;
              }
              else if (index14 == index1 && index19 == index1 && index16 != index1 & index17 == index1)
              {
                num3 = 0;
                num4 = 18 * frameNumber;
              }
              else if (index14 == index1 && index19 == index1 && index16 == index1 & index17 != index1)
              {
                num3 = 72;
                num4 = 18 * frameNumber;
              }
              else if (index14 != index1 && index19 == index1 && index16 != index1 & index17 == index1)
              {
                num3 = 36 * frameNumber;
                num4 = 54;
              }
              else if (index14 != index1 && index19 == index1 && index16 == index1 & index17 != index1)
              {
                num3 = 18 + 36 * frameNumber;
                num4 = 54;
              }
              else if (index14 == index1 && index19 != index1 && index16 != index1 & index17 == index1)
              {
                num3 = 36 * frameNumber;
                num4 = 72;
              }
              else if (index14 == index1 && index19 != index1 && index16 == index1 & index17 != index1)
              {
                num3 = 18 + 36 * frameNumber;
                num4 = 72;
              }
              else if (index14 == index1 && index19 == index1 && index16 != index1 & index17 != index1)
              {
                num3 = 90;
                num4 = 18 * frameNumber;
              }
              else if (index14 != index1 && index19 != index1 && index16 == index1 & index17 == index1)
              {
                num3 = 108 + 18 * frameNumber;
                num4 = 72;
              }
              else if (index14 != index1 && index19 == index1 && index16 != index1 & index17 != index1)
              {
                num3 = 108 + 18 * frameNumber;
                num4 = 0;
              }
              else if (index14 == index1 && index19 != index1 && index16 != index1 & index17 != index1)
              {
                num3 = 108 + 18 * frameNumber;
                num4 = 54;
              }
              else if (index14 != index1 && index19 != index1 && index16 != index1 & index17 == index1)
              {
                num3 = 162;
                num4 = 18 * frameNumber;
              }
              else if (index14 != index1 && index19 != index1 && index16 == index1 & index17 != index1)
              {
                num3 = 216;
                num4 = 18 * frameNumber;
              }
              else if (index14 != index1 && index19 != index1 && index16 != index1 & index17 != index1)
              {
                num3 = 162 + 18 * frameNumber;
                num4 = 54;
              }
            }
            if (num3 < 0)
            {
              num4 = 18;
              num3 = 18 + 18 * frameNumber;
            }
            tilePtr1->frameX = (short) num3;
            tilePtr1->frameY = (short) num4;
            if (index1 == 52 || index1 == 62 || index1 == 115)
            {
              int num22 = (int) tilePtr1[-1].active != 0 ? (int) tilePtr1[-1].type : -1;
              if (index1 == 52 && (num22 == 109 || num22 == 115))
              {
                tilePtr1->type = (byte) 115;
                WorldGen.SquareTileFrameNoLiquid(i, j, -1);
                return;
              }
              else if (index1 == 115 && (num22 == 2 || num22 == 52))
              {
                tilePtr1->type = (byte) 52;
                WorldGen.SquareTileFrameNoLiquid(i, j, -1);
                return;
              }
              else if (num22 != index1 && (num22 == -1 || index1 == 52 && num22 != 2 || (index1 == 62 && num22 != 60 || index1 == 115 && num22 != 109)))
                WorldGen.KillTile(i, j);
            }
            if (!WorldGen.gen && Main.netMode != 1 && (index1 == 53 || index1 == 112 || (index1 == 116 || index1 == 123)) && (int) tilePtr1[1].active == 0)
            {
              Tile* tilePtr2 = tilePtr1 - 1;
              if ((int) tilePtr2->active == 0 || (int) tilePtr2->type != 21)
              {
                tilePtr1->active = (byte) 0;
                WorldGen.sandBuffer[WorldGen.currentSandBuffer].Add(i, j);
              }
            }
          }
        }
      }
    }

    public static void UpdateMagmaLayerPos()
    {
      int num1 = (int) Main.maxTilesY - 230;
      int num2 = Main.worldSurface + (num1 - Main.worldSurface) / 6 * 6 - 5;
      Main.magmaLayer = num2;
      Main.magmaLayerPixels = num2 << 4;
    }

    public sealed class FallingSandBuffer
    {
      public Location[] buffer = new Location[64];
      public int count;

      public unsafe void Add(int i, int j)
      {
        fixed (Location* locationPtr = &this.buffer[this.count])
        {
          locationPtr->X = (short) i;
          locationPtr->Y = (short) j;
        }
        ++this.count;
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
  }
}
