// Type: Terraria.NPC
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;
using System;
using Terraria.Achievements;

namespace Terraria
{
  public sealed class NPC
  {
    public static string[] chrName = new string[125];
    public static byte[] npcFrameCount = new byte[168]
    {
      (byte) 1,
      (byte) 2,
      (byte) 2,
      (byte) 3,
      (byte) 6,
      (byte) 2,
      (byte) 2,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 2,
      (byte) 16,
      (byte) 14,
      (byte) 16,
      (byte) 14,
      (byte) 15,
      (byte) 16,
      (byte) 2,
      (byte) 10,
      (byte) 1,
      (byte) 16,
      (byte) 16,
      (byte) 16,
      (byte) 3,
      (byte) 1,
      (byte) 15,
      (byte) 3,
      (byte) 1,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 16,
      (byte) 16,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 3,
      (byte) 3,
      (byte) 15,
      (byte) 3,
      (byte) 7,
      (byte) 7,
      (byte) 4,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 3,
      (byte) 3,
      (byte) 16,
      (byte) 6,
      (byte) 3,
      (byte) 6,
      (byte) 6,
      (byte) 2,
      (byte) 5,
      (byte) 3,
      (byte) 2,
      (byte) 7,
      (byte) 7,
      (byte) 4,
      (byte) 2,
      (byte) 8,
      (byte) 1,
      (byte) 5,
      (byte) 1,
      (byte) 2,
      (byte) 4,
      (byte) 16,
      (byte) 5,
      (byte) 4,
      (byte) 4,
      (byte) 15,
      (byte) 15,
      (byte) 15,
      (byte) 15,
      (byte) 2,
      (byte) 4,
      (byte) 6,
      (byte) 6,
      (byte) 18,
      (byte) 16,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 4,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 5,
      (byte) 6,
      (byte) 7,
      (byte) 16,
      (byte) 1,
      (byte) 1,
      (byte) 16,
      (byte) 16,
      (byte) 12,
      (byte) 20,
      (byte) 21,
      (byte) 1,
      (byte) 2,
      (byte) 2,
      (byte) 3,
      (byte) 6,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 15,
      (byte) 4,
      (byte) 11,
      (byte) 1,
      (byte) 14,
      (byte) 6,
      (byte) 6,
      (byte) 3,
      (byte) 1,
      (byte) 2,
      (byte) 2,
      (byte) 1,
      (byte) 3,
      (byte) 4,
      (byte) 1,
      (byte) 2,
      (byte) 1,
      (byte) 4,
      (byte) 2,
      (byte) 1,
      (byte) 15,
      (byte) 3,
      (byte) 16,
      (byte) 4,
      (byte) 5,
      (byte) 7,
      (byte) 3,
      (byte) 5,
      (byte) 4,
      (byte) 15,
      (byte) 2,
      (byte) 6,
      (byte) 15,
      (byte) 11,
      (byte) 15,
      (byte) 15,
      (byte) 3,
      (byte) 3,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 2,
      (byte) 6,
      (byte) 2
    };
    public static int wof = -1;
    public static int wofF = 0;
    private static bool noSpawnCycle = false;
    public static short checkForSpawnsTimer = (short) 0;
    public static bool downedBoss1 = false;
    public static bool downedBoss2 = false;
    public static bool downedBoss3 = false;
    public static bool savedGoblin = false;
    public static bool savedWizard = false;
    public static bool savedMech = false;
    public static bool downedGoblins = false;
    public static bool downedFrost = false;
    public static bool downedClown = false;
    private static int spawnRate = 600;
    private static int maxSpawns = 5;
    public Vector2[] oldPos = new Vector2[10];
    public int realLife = -1;
    public float npcSlots = 1f;
    public Buff[] buff = new Buff[5];
    public bool[] buffImmune = new bool[41];
    public byte[] immune = new byte[9];
    public sbyte direction = (sbyte) 1;
    public sbyte directionY = (sbyte) 1;
    public byte target = (byte) 8;
    public float scale = 1f;
    public float knockBackResist = 1f;
    public sbyte spriteDirection = (sbyte) -1;
    public short homeTileX = (short) -1;
    public short homeTileY = (short) -1;
    public short oldHomeTileX = (short) -1;
    public short oldHomeTileY = (short) -1;
    public const int MAX_NPCS = 196;
    private const int spawnSpaceX = 3;
    private const int spawnSpaceY = 3;
    public const int sWidth = 1920;
    public const int sHeight = 1080;
    public const int safeRangeX = 62;
    public const int safeRangeY = 34;
    private const int spawnRangeX = 84;
    private const int spawnRangeY = 46;
    private const int activeRangeX = 3264;
    private const int activeRangeY = 1836;
    private const int townRangeX = 1920;
    private const int townRangeY = 1080;
    private const int activeTime = 750;
    private const int defaultSpawnRate = 600;
    private const int defaultMaxSpawns = 5;
    private const int DRAW_MY_NAME_ON_STRIKE = 96;
    public const int DRAW_MY_NAME_ON_NEARBY = 32;
    public const int MAX_TYPES = 168;
    public const int MAX_NAMED_TYPES = 125;
    public const int MAX_BUFFS = 5;
    public const int MAX_TOWN_NPCS = 10;
    public static int wofT;
    public static int wofB;
    public short netSpam;
    public short netSkip;
    public bool netAlways;
    public bool wet;
    public byte wetCount;
    public bool lavaWet;
    public bool poisoned;
    public bool confused;
    public int lifeRegenCount;
    public byte active;
    public byte type;
    public bool justHit;
    public bool noGravity;
    public bool noTileCollide;
    public bool netUpdate;
    public bool netUpdate2;
    public bool collideX;
    public bool collideY;
    public bool boss;
    public bool behindTiles;
    public bool lavaImmune;
    public bool dontTakeDamage;
    public short drawMyName;
    public bool townNPC;
    public bool homeless;
    public bool friendly;
    private bool closeDoor;
    private bool oldHomeless;
    public Vector2 oldPosition;
    public Vector2 oldVelocity;
    public Vector2 position;
    public Vector2 velocity;
    public Rectangle aabb;
    public ushort width;
    public ushort height;
    public byte aiAction;
    public byte aiStyle;
    public float ai0;
    public float ai1;
    public float ai2;
    public float ai3;
    public int localAI0;
    public int localAI1;
    public int localAI2;
    public int localAI3;
    public int timeLeft;
    public int damage;
    public int defense;
    public int defDamage;
    public short defDefense;
    public short soundDelay;
    public short soundHit;
    public short soundKilled;
    public int healthBarLife;
    public int life;
    public int lifeMax;
    public Rectangle targetRect;
    public float frameCounter;
    public short frameY;
    public short frameHeight;
    public Color color;
    public byte alpha;
    public sbyte oldDirection;
    public sbyte oldDirectionY;
    public short oldTarget;
    public short whoAmI;
    public float rotation;
    public float value;
    public short netID;
    public short doorX;
    public short doorY;
    public short friendlyRegen;
    public string name;
    public string displayName;

    static NPC()
    {
    }

    public static void clrNames()
    {
      for (int index = 0; index < 125; ++index)
        NPC.chrName[index] = (string) null;
    }

    public bool hasName()
    {
      if ((int) this.type < 125)
        return NPC.chrName[(int) this.type] != null;
      else
        return false;
    }

    public string getName()
    {
      return NPC.chrName[(int) this.type];
    }

    public static void setNames()
    {
      if (NPC.chrName[18] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(23))
        {
          case 0:
            str = "Molly";
            break;
          case 1:
            str = "Amy";
            break;
          case 2:
            str = "Claire";
            break;
          case 3:
            str = "Emily";
            break;
          case 4:
            str = "Katie";
            break;
          case 5:
            str = "Madeline";
            break;
          case 6:
            str = "Katelyn";
            break;
          case 7:
            str = "Emma";
            break;
          case 8:
            str = "Abigail";
            break;
          case 9:
            str = "Carly";
            break;
          case 10:
            str = "Jenna";
            break;
          case 11:
            str = "Heather";
            break;
          case 12:
            str = "Katherine";
            break;
          case 13:
            str = "Caitlin";
            break;
          case 14:
            str = "Kaitlin";
            break;
          case 15:
            str = "Holly";
            break;
          case 16:
            str = "Kaitlyn";
            break;
          case 17:
            str = "Hannah";
            break;
          case 18:
            str = "Kathryn";
            break;
          case 19:
            str = "Lorraine";
            break;
          case 20:
            str = "Helen";
            break;
          case 21:
            str = "Kayla";
            break;
          default:
            str = "Allison";
            break;
        }
        NPC.chrName[18] = str;
      }
      if (NPC.chrName[124] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(24))
        {
          case 0:
            str = "Shayna";
            break;
          case 1:
            str = "Korrie";
            break;
          case 2:
            str = "Ginger";
            break;
          case 3:
            str = "Brooke";
            break;
          case 4:
            str = "Jenny";
            break;
          case 5:
            str = "Autumn";
            break;
          case 6:
            str = "Nancy";
            break;
          case 7:
            str = "Ella";
            break;
          case 8:
            str = "Kayla";
            break;
          case 9:
            str = "Beth";
            break;
          case 10:
            str = "Sophia";
            break;
          case 11:
            str = "Marshanna";
            break;
          case 12:
            str = "Lauren";
            break;
          case 13:
            str = "Trisha";
            break;
          case 14:
            str = "Shirlena";
            break;
          case 15:
            str = "Sheena";
            break;
          case 16:
            str = "Ellen";
            break;
          case 17:
            str = "Amy";
            break;
          case 18:
            str = "Dawn";
            break;
          case 19:
            str = "Susana";
            break;
          case 20:
            str = "Meredith";
            break;
          case 21:
            str = "Selene";
            break;
          case 22:
            str = "Terra";
            break;
          default:
            str = "Sally";
            break;
        }
        NPC.chrName[124] = str;
      }
      if (NPC.chrName[19] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(23))
        {
          case 0:
            str = "DeShawn";
            break;
          case 1:
            str = "DeAndre";
            break;
          case 2:
            str = "Marquis";
            break;
          case 3:
            str = "Darnell";
            break;
          case 4:
            str = "Terrell";
            break;
          case 5:
            str = "Malik";
            break;
          case 6:
            str = "Trevon";
            break;
          case 7:
            str = "Tyrone";
            break;
          case 8:
            str = "Willie";
            break;
          case 9:
            str = "Dominique";
            break;
          case 10:
            str = "Demetrius";
            break;
          case 11:
            str = "Reginald";
            break;
          case 12:
            str = "Jamal";
            break;
          case 13:
            str = "Maurice";
            break;
          case 14:
            str = "Jalen";
            break;
          case 15:
            str = "Darius";
            break;
          case 16:
            str = "Xavier";
            break;
          case 17:
            str = "Terrance";
            break;
          case 18:
            str = "Andre";
            break;
          case 19:
            str = "Dante";
            break;
          case 20:
            str = "Brimst";
            break;
          case 21:
            str = "Bronson";
            break;
          default:
            str = "Darryl";
            break;
        }
        NPC.chrName[19] = str;
      }
      if (NPC.chrName[22] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(35))
        {
          case 0:
            str = "Jake";
            break;
          case 1:
            str = "Connor";
            break;
          case 2:
            str = "Tanner";
            break;
          case 3:
            str = "Wyatt";
            break;
          case 4:
            str = "Cody";
            break;
          case 5:
            str = "Dustin";
            break;
          case 6:
            str = "Luke";
            break;
          case 7:
            str = "Jack";
            break;
          case 8:
            str = "Scott";
            break;
          case 9:
            str = "Logan";
            break;
          case 10:
            str = "Cole";
            break;
          case 11:
            str = "Lucas";
            break;
          case 12:
            str = "Bradley";
            break;
          case 13:
            str = "Jacob";
            break;
          case 14:
            str = "Garrett";
            break;
          case 15:
            str = "Dylan";
            break;
          case 16:
            str = "Maxwell";
            break;
          case 17:
            str = "Steve";
            break;
          case 18:
            str = "Brett";
            break;
          case 19:
            str = "Andrew";
            break;
          case 20:
            str = "Harley";
            break;
          case 21:
            str = "Kyle";
            break;
          case 22:
            str = "Jake";
            break;
          case 23:
            str = "Ryan";
            break;
          case 24:
            str = "Jeffrey";
            break;
          case 25:
            str = "Seth";
            break;
          case 26:
            str = "Marty";
            break;
          case 27:
            str = "Brandon";
            break;
          case 28:
            str = "Zach";
            break;
          case 29:
            str = "Jeff";
            break;
          case 30:
            str = "Daniel";
            break;
          case 31:
            str = "Trent";
            break;
          case 32:
            str = "Kevin";
            break;
          case 33:
            str = "Brian";
            break;
          default:
            str = "Colin";
            break;
        }
        NPC.chrName[22] = str;
      }
      if (NPC.chrName[20] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(22))
        {
          case 0:
            str = "Alalia";
            break;
          case 1:
            str = "Alalia";
            break;
          case 2:
            str = "Alura";
            break;
          case 3:
            str = "Ariella";
            break;
          case 4:
            str = "Caelia";
            break;
          case 5:
            str = "Calista";
            break;
          case 6:
            str = "Chryseis";
            break;
          case 7:
            str = "Emerenta";
            break;
          case 8:
            str = "Elysia";
            break;
          case 9:
            str = "Evvie";
            break;
          case 10:
            str = "Faye";
            break;
          case 11:
            str = "Felicitae";
            break;
          case 12:
            str = "Lunette";
            break;
          case 13:
            str = "Nata";
            break;
          case 14:
            str = "Nissa";
            break;
          case 15:
            str = "Tatiana";
            break;
          case 16:
            str = "Rosalva";
            break;
          case 17:
            str = "Shea";
            break;
          case 18:
            str = "Tania";
            break;
          case 19:
            str = "Isis";
            break;
          case 20:
            str = "Celestia";
            break;
          default:
            str = "Xylia";
            break;
        }
        NPC.chrName[20] = str;
      }
      if (NPC.chrName[38] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(22))
        {
          case 0:
            str = "Dolbere";
            break;
          case 1:
            str = "Bazdin";
            break;
          case 2:
            str = "Durim";
            break;
          case 3:
            str = "Tordak";
            break;
          case 4:
            str = "Garval";
            break;
          case 5:
            str = "Morthal";
            break;
          case 6:
            str = "Oten";
            break;
          case 7:
            str = "Dolgen";
            break;
          case 8:
            str = "Gimli";
            break;
          case 9:
            str = "Gimut";
            break;
          case 10:
            str = "Duerthen";
            break;
          case 11:
            str = "Beldin";
            break;
          case 12:
            str = "Jarut";
            break;
          case 13:
            str = "Ovbere";
            break;
          case 14:
            str = "Norkas";
            break;
          case 15:
            str = "Dolgrim";
            break;
          case 16:
            str = "Boften";
            break;
          case 17:
            str = "Norsun";
            break;
          case 18:
            str = "Dias";
            break;
          case 19:
            str = "Fikod";
            break;
          case 20:
            str = "Urist";
            break;
          default:
            str = "Darur";
            break;
        }
        NPC.chrName[38] = str;
      }
      if (NPC.chrName[108] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(21))
        {
          case 0:
            str = "Dalamar";
            break;
          case 1:
            str = "Dulais";
            break;
          case 2:
            str = "Elric";
            break;
          case 3:
            str = "Arddun";
            break;
          case 4:
            str = "Maelor";
            break;
          case 5:
            str = "Leomund";
            break;
          case 6:
            str = "Hirael";
            break;
          case 7:
            str = "Gwentor";
            break;
          case 8:
            str = "Greum";
            break;
          case 9:
            str = "Gearroid";
            break;
          case 10:
            str = "Fizban";
            break;
          case 11:
            str = "Ningauble";
            break;
          case 12:
            str = "Seonag";
            break;
          case 13:
            str = "Sargon";
            break;
          case 14:
            str = "Merlyn";
            break;
          case 15:
            str = "Magius";
            break;
          case 16:
            str = "Berwyn";
            break;
          case 17:
            str = "Arwyn";
            break;
          case 18:
            str = "Alasdair";
            break;
          case 19:
            str = "Tagar";
            break;
          default:
            str = "Xanadu";
            break;
        }
        NPC.chrName[108] = str;
      }
      if (NPC.chrName[17] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(23))
        {
          case 0:
            str = "Alfred";
            break;
          case 1:
            str = "Barney";
            break;
          case 2:
            str = "Calvin";
            break;
          case 3:
            str = "Edmund";
            break;
          case 4:
            str = "Edwin";
            break;
          case 5:
            str = "Eugene";
            break;
          case 6:
            str = "Frank";
            break;
          case 7:
            str = "Frederick";
            break;
          case 8:
            str = "Gilbert";
            break;
          case 9:
            str = "Gus";
            break;
          case 10:
            str = "Wilbur";
            break;
          case 11:
            str = "Seymour";
            break;
          case 12:
            str = "Louis";
            break;
          case 13:
            str = "Humphrey";
            break;
          case 14:
            str = "Harold";
            break;
          case 15:
            str = "Milton";
            break;
          case 16:
            str = "Mortimer";
            break;
          case 17:
            str = "Howard";
            break;
          case 18:
            str = "Walter";
            break;
          case 19:
            str = "Finn";
            break;
          case 20:
            str = "Isacc";
            break;
          case 21:
            str = "Joseph";
            break;
          default:
            str = "Ralph";
            break;
        }
        NPC.chrName[17] = str;
      }
      if (NPC.chrName[54] == null)
      {
        string str;
        switch (WorldGen.genRand.Next(24))
        {
          case 0:
            str = "Sebastian";
            break;
          case 1:
            str = "Rupert";
            break;
          case 2:
            str = "Clive";
            break;
          case 3:
            str = "Nigel";
            break;
          case 4:
            str = "Mervyn";
            break;
          case 5:
            str = "Cedric";
            break;
          case 6:
            str = "Pip";
            break;
          case 7:
            str = "Cyril";
            break;
          case 8:
            str = "Fitz";
            break;
          case 9:
            str = "Lloyd";
            break;
          case 10:
            str = "Arthur";
            break;
          case 11:
            str = "Rodney";
            break;
          case 12:
            str = "Graham";
            break;
          case 13:
            str = "Edward";
            break;
          case 14:
            str = "Alfred";
            break;
          case 15:
            str = "Edmund";
            break;
          case 16:
            str = "Henry";
            break;
          case 17:
            str = "Herald";
            break;
          case 18:
            str = "Roland";
            break;
          case 19:
            str = "Lincoln";
            break;
          case 20:
            str = "Lloyd";
            break;
          case 21:
            str = "Edgar";
            break;
          case 22:
            str = "Eustace";
            break;
          default:
            str = "Rodrick";
            break;
        }
        NPC.chrName[54] = str;
      }
      if (NPC.chrName[107] != null)
        return;
      string str1;
      switch (WorldGen.genRand.Next(25))
      {
        case 0:
          str1 = "Grodax";
          break;
        case 1:
          str1 = "Sarx";
          break;
        case 2:
          str1 = "Xon";
          break;
        case 3:
          str1 = "Mrunok";
          break;
        case 4:
          str1 = "Nuxatk";
          break;
        case 5:
          str1 = "Tgerd";
          break;
        case 6:
          str1 = "Darz";
          break;
        case 7:
          str1 = "Smador";
          break;
        case 8:
          str1 = "Stazen";
          break;
        case 9:
          str1 = "Mobart";
          break;
        case 10:
          str1 = "Knogs";
          break;
        case 11:
          str1 = "Tkanus";
          break;
        case 12:
          str1 = "Negurk";
          break;
        case 13:
          str1 = "Nort";
          break;
        case 14:
          str1 = "Durnok";
          break;
        case 15:
          str1 = "Trogem";
          break;
        case 16:
          str1 = "Stezom";
          break;
        case 17:
          str1 = "Gnudar";
          break;
        case 18:
          str1 = "Ragz";
          break;
        case 19:
          str1 = "Fahd";
          break;
        case 20:
          str1 = "Xanos";
          break;
        case 21:
          str1 = "Arback";
          break;
        case 22:
          str1 = "Fjell";
          break;
        case 23:
          str1 = "Dalek";
          break;
        default:
          str1 = "Knub";
          break;
      }
      NPC.chrName[107] = str1;
    }

    public void netDefaults(int type)
    {
      if (type < 0)
      {
        if (type == -1)
          this.SetDefaults("Slimeling");
        else if (type == -2)
          this.SetDefaults("Slimer2");
        else if (type == -3)
          this.SetDefaults("Green Slime");
        else if (type == -4)
          this.SetDefaults("Pinky");
        else if (type == -5)
          this.SetDefaults("Baby Slime");
        else if (type == -6)
          this.SetDefaults("Black Slime");
        else if (type == -7)
          this.SetDefaults("Purple Slime");
        else if (type == -8)
          this.SetDefaults("Red Slime");
        else if (type == -9)
          this.SetDefaults("Yellow Slime");
        else if (type == -10)
          this.SetDefaults("Jungle Slime");
        else if (type == -11)
          this.SetDefaults("Little Eater");
        else if (type == -12)
          this.SetDefaults("Big Eater");
        else if (type == -13)
          this.SetDefaults("Short Bones");
        else if (type == -14)
          this.SetDefaults("Big Boned");
        else if (type == -15)
          this.SetDefaults("Heavy Skeleton");
        else if (type == -16)
          this.SetDefaults("Little Stinger");
        else if (type == -17)
        {
          this.SetDefaults("Big Stinger");
        }
        else
        {
          if (type != -18)
            return;
          this.SetDefaults("Slimeling2");
        }
      }
      else
        this.SetDefaults(type, -1.0);
    }

    public void SetDefaults(string Name)
    {
      if (Name == "Slimeling")
      {
        this.SetDefaults(81, 0.600000023841858);
        this.name = Name;
        this.damage = 45;
        this.defense = 10;
        this.life = 90;
        this.knockBackResist = 1.2f;
        this.value = 100f;
        this.netID = (short) -1;
      }
      else if (Name == "Slimeling2")
      {
        this.SetDefaults(150, 0.600000023841858);
        this.name = Name;
        this.damage = 45;
        this.defense = 10;
        this.life = 105;
        this.knockBackResist = 1.2f;
        this.value = 100f;
        this.netID = (short) -18;
      }
      else if (Name == "Slimer2")
      {
        this.SetDefaults(81, 0.899999976158142);
        this.name = Name;
        this.damage = 45;
        this.defense = 20;
        this.life = 90;
        this.knockBackResist = 1.2f;
        this.value = 100f;
        this.netID = (short) -2;
      }
      else if (Name == "Green Slime")
      {
        this.SetDefaults(1, 0.899999976158142);
        this.name = Name;
        this.damage = 6;
        this.defense = 0;
        this.life = 14;
        this.knockBackResist = 1.2f;
        this.color = new Color(0, 220, 40, 100);
        this.value = 3f;
        this.netID = (short) -3;
      }
      else if (Name == "Pinky")
      {
        this.SetDefaults(1, 0.600000023841858);
        this.name = Name;
        this.damage = 5;
        this.defense = 5;
        this.life = 150;
        this.knockBackResist = 1.4f;
        this.color = new Color(250, 30, 90, 90);
        this.value = 10000f;
        this.netID = (short) -4;
      }
      else if (Name == "Baby Slime")
      {
        this.SetDefaults(1, 0.899999976158142);
        this.name = Name;
        this.damage = 13;
        this.defense = 4;
        this.life = 30;
        this.knockBackResist = 0.95f;
        this.alpha = (byte) 120;
        this.color = new Color(0, 0, 0, 50);
        this.value = 10f;
        this.netID = (short) -5;
      }
      else if (Name == "Black Slime")
      {
        this.SetDefaults(1, -1.0);
        this.name = Name;
        this.damage = 15;
        this.defense = 4;
        this.life = 45;
        this.color = new Color(0, 0, 0, 50);
        this.value = 20f;
        this.netID = (short) -6;
      }
      else if (Name == "Purple Slime")
      {
        this.SetDefaults(1, 1.20000004768372);
        this.name = Name;
        this.damage = 12;
        this.defense = 6;
        this.life = 40;
        this.knockBackResist = 0.9f;
        this.color = new Color(200, 0, (int) byte.MaxValue, 150);
        this.value = 10f;
        this.netID = (short) -7;
      }
      else if (Name == "Red Slime")
      {
        this.SetDefaults(1, -1.0);
        this.name = Name;
        this.damage = 12;
        this.defense = 4;
        this.life = 35;
        this.color = new Color((int) byte.MaxValue, 30, 0, 100);
        this.value = 8f;
        this.netID = (short) -8;
      }
      else if (Name == "Yellow Slime")
      {
        this.SetDefaults(1, 1.20000004768372);
        this.name = Name;
        this.damage = 15;
        this.defense = 7;
        this.life = 45;
        this.color = new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, 100);
        this.value = 10f;
        this.netID = (short) -9;
      }
      else if (Name == "Jungle Slime")
      {
        this.SetDefaults(1, 1.10000002384186);
        this.name = Name;
        this.damage = 18;
        this.defense = 6;
        this.life = 60;
        this.color = new Color(143, 215, 93, 100);
        this.value = 500f;
        this.netID = (short) -10;
      }
      else if (Name == "Little Eater")
      {
        this.SetDefaults(6, 0.850000023841858);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = this.npcSlots * this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = (short) -11;
      }
      else if (Name == "Big Eater")
      {
        this.SetDefaults(6, 1.14999997615814);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = this.npcSlots * this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = (short) -12;
      }
      else if (Name == "Short Bones")
      {
        this.SetDefaults(31, 0.899999976158142);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.netID = (short) -13;
      }
      else if (Name == "Big Boned")
      {
        this.SetDefaults(31, 1.14999997615814);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale * 1.1);
        this.life = (int) ((double) this.life * (double) this.scale * 1.1);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = 2f;
        this.knockBackResist *= 2f - this.scale;
        this.netID = (short) -14;
      }
      else if (Name == "Heavy Skeleton")
      {
        this.SetDefaults(77, 1.14999997615814);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale * 1.1);
        this.life = 400;
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = 2f;
        this.knockBackResist *= 2f - this.scale;
        this.height = (ushort) 44;
        this.netID = (short) -15;
      }
      else if (Name == "Little Stinger")
      {
        this.SetDefaults(42, 0.850000023841858);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = this.npcSlots * this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = (short) -16;
      }
      else if (Name == "Big Stinger")
      {
        this.SetDefaults(42, 1.20000004768372);
        this.name = Name;
        this.defense = (int) ((double) this.defense * (double) this.scale);
        this.damage = (int) ((double) this.damage * (double) this.scale);
        this.life = (int) ((double) this.life * (double) this.scale);
        this.value = (float) (int) ((double) this.value * (double) this.scale);
        this.npcSlots = this.npcSlots * this.scale;
        this.knockBackResist *= 2f - this.scale;
        this.netID = (short) -17;
      }
      this.displayName = Lang.npcName((int) this.netID);
      this.lifeMax = this.life;
      this.healthBarLife = this.life;
      this.defDamage = this.damage;
      this.defDefense = (short) this.defense;
    }

    public bool canTalk()
    {
      if (!this.townNPC && (int) this.type != 105 && (int) this.type != 106)
        return (int) this.type == 123;
      else
        return true;
    }

    public static bool MechSpawn(int x, int y, int type)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.npc[index].active != 0 && (int) Main.npc[index].type == type)
        {
          ++num1;
          Vector2 vector2 = new Vector2((float) x, (float) y);
          float num4 = Main.npc[index].position.X - vector2.X;
          float num5 = Main.npc[index].position.Y - vector2.Y;
          float num6 = (float) ((double) num4 * (double) num4 + (double) num5 * (double) num5);
          if ((double) num6 < 40000.0)
            ++num2;
          if ((double) num6 < 360000.0)
            ++num3;
        }
      }
      return num2 < 3 && num3 < 6 && num1 < 10;
    }

    public int getHeadTextureId()
    {
      byte num = this.type;
      if ((uint) num <= 54U)
      {
        switch (num)
        {
          case (byte) 17:
            return 2;
          case (byte) 18:
            return 3;
          case (byte) 19:
            return 6;
          case (byte) 20:
            return 5;
          case (byte) 22:
            return 1;
          case (byte) 38:
            return 4;
          case (byte) 54:
            return 7;
        }
      }
      else
      {
        switch (num)
        {
          case (byte) 107:
            return 9;
          case (byte) 108:
            return 10;
          case (byte) 124:
            return 8;
          case (byte) 142:
            return 11;
        }
      }
      return -1;
    }

    public void SetDefaults(int Type, double scaleOverride = -1.0)
    {
      this.type = (byte) Type;
      this.netID = (short) Type;
      this.netAlways = false;
      this.netSpam = (short) 0;
      this.drawMyName = (short) 0;
      for (int index = 0; index < this.oldPos.Length; ++index)
      {
        this.oldPos[index].X = 0.0f;
        this.oldPos[index].Y = 0.0f;
      }
      for (int index = 0; index < 5; ++index)
      {
        this.buff[index].Time = (ushort) 0;
        this.buff[index].Type = (ushort) 0;
      }
      for (int index = 0; index < 41; ++index)
        this.buffImmune[index] = false;
      this.buffImmune[31] = true;
      this.netSkip = (short) -2;
      this.realLife = -1;
      this.lifeRegenCount = 0;
      this.poisoned = false;
      this.confused = false;
      this.justHit = false;
      this.dontTakeDamage = false;
      this.npcSlots = 1f;
      this.lavaImmune = false;
      this.lavaWet = false;
      this.wetCount = (byte) 0;
      this.wet = false;
      this.townNPC = false;
      this.homeless = false;
      this.homeTileX = (short) -1;
      this.homeTileY = (short) -1;
      this.friendly = false;
      this.behindTiles = false;
      this.boss = false;
      this.noTileCollide = false;
      this.rotation = 0.0f;
      this.active = (byte) 1;
      this.alpha = (byte) 0;
      this.color = new Color();
      this.collideX = false;
      this.collideY = false;
      this.direction = (sbyte) 0;
      this.oldDirection = (sbyte) 0;
      this.frameCounter = 0.0f;
      this.netUpdate = true;
      this.netUpdate2 = false;
      this.knockBackResist = 1f;
      this.name = "";
      this.noGravity = false;
      this.scale = 1f;
      this.soundHit = (short) 0;
      this.soundKilled = (short) 0;
      this.spriteDirection = (sbyte) -1;
      this.target = (byte) 8;
      this.oldTarget = (short) this.target;
      this.targetRect = new Rectangle();
      this.timeLeft = 750;
      this.value = 0.0f;
      this.ai0 = 0.0f;
      this.ai1 = 0.0f;
      this.ai2 = 0.0f;
      this.ai3 = 0.0f;
      this.localAI0 = 0;
      this.localAI1 = 0;
      this.localAI2 = 0;
      this.localAI3 = 0;
      if ((int) this.type == 1)
      {
        this.name = "Blue Slime";
        this.width = (ushort) 24;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 1;
        this.damage = 7;
        this.defense = 2;
        this.lifeMax = 25;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.alpha = (byte) 175;
        this.color = new Color(0, 80, (int) byte.MaxValue, 100);
        this.value = 25f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 2)
      {
        this.name = "Demon Eye";
        this.width = (ushort) 30;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 2;
        this.damage = 18;
        this.defense = 2;
        this.lifeMax = 60;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 75f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 3)
      {
        this.name = "Zombie";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 14;
        this.defense = 6;
        this.lifeMax = 45;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.5f;
        this.value = 60f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 4)
      {
        this.name = "Eye of Cthulhu";
        this.width = (ushort) 100;
        this.height = (ushort) 110;
        this.aiStyle = (byte) 4;
        this.damage = 15;
        this.defense = 12;
        this.lifeMax = 2800;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.timeLeft = 22500;
        this.boss = true;
        this.value = 30000f;
        this.npcSlots = 5f;
      }
      else if ((int) this.type == 166)
      {
        this.name = "Ocram";
        this.width = (ushort) 100;
        this.height = (ushort) 110;
        this.aiStyle = (byte) 39;
        this.damage = 65;
        this.defense = 20;
        this.lifeMax = 35000;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.timeLeft = 22500;
        this.boss = true;
        this.value = 100000f;
        this.npcSlots = 5f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 5)
      {
        this.name = "Servant of Cthulhu";
        this.width = (ushort) 20;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 5;
        this.damage = 13;
        this.defense = 0;
        this.lifeMax = 10;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
      }
      else if ((int) this.type == 167)
      {
        this.name = "Servant of Ocram";
        this.width = (ushort) 20;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 5;
        this.damage = 35;
        this.defense = 5;
        this.lifeMax = 130;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
      }
      else if ((int) this.type == 6)
      {
        this.npcSlots = 1f;
        this.name = "Eater of Souls";
        this.width = (ushort) 30;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 5;
        this.damage = 22;
        this.defense = 8;
        this.lifeMax = 40;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.knockBackResist = 0.5f;
        this.value = 90f;
      }
      else if ((int) this.type == 7)
      {
        this.npcSlots = 3.5f;
        this.name = "Devourer Head";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.damage = 31;
        this.defense = 2;
        this.lifeMax = 100;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 140f;
        this.netAlways = true;
      }
      else if ((int) this.type == 8)
      {
        this.name = "Devourer Body";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 16;
        this.defense = 6;
        this.lifeMax = 100;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 140f;
      }
      else if ((int) this.type == 9)
      {
        this.name = "Devourer Tail";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 13;
        this.defense = 10;
        this.lifeMax = 100;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 140f;
      }
      else if ((int) this.type == 10)
      {
        this.name = "Giant Worm Head";
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 8;
        this.defense = 0;
        this.lifeMax = 30;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 40f;
      }
      else if ((int) this.type == 11)
      {
        this.name = "Giant Worm Body";
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 4;
        this.defense = 4;
        this.lifeMax = 30;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 40f;
      }
      else if ((int) this.type == 12)
      {
        this.name = "Giant Worm Tail";
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 4;
        this.defense = 6;
        this.lifeMax = 30;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 40f;
      }
      else if ((int) this.type == 13)
      {
        this.npcSlots = 5f;
        this.name = "Eater of Worlds Head";
        this.width = (ushort) 38;
        this.height = (ushort) 38;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 22;
        this.defense = 2;
        this.lifeMax = 65;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 300f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 14)
      {
        this.name = "Eater of Worlds Body";
        this.width = (ushort) 38;
        this.height = (ushort) 38;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 13;
        this.defense = 4;
        this.lifeMax = 150;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 300f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 15)
      {
        this.name = "Eater of Worlds Tail";
        this.width = (ushort) 38;
        this.height = (ushort) 38;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 11;
        this.defense = 8;
        this.lifeMax = 220;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 300f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 16)
      {
        this.npcSlots = 2f;
        this.name = "Mother Slime";
        this.width = (ushort) 36;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 1;
        this.damage = 20;
        this.defense = 7;
        this.lifeMax = 90;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.alpha = (byte) 120;
        this.color = new Color(0, 0, 0, 50);
        this.value = 75f;
        this.scale = 1.25f;
        this.knockBackResist = 0.6f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 17)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Merchant";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 18)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Nurse";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 19)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Arms Dealer";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 20)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Dryad";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 21)
      {
        this.name = "Skeleton";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 20;
        this.defense = 8;
        this.lifeMax = 60;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.5f;
        this.value = 100f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 22)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Guide";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 23)
      {
        this.name = "Meteor Head";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 5;
        this.damage = 40;
        this.defense = 6;
        this.lifeMax = 26;
        this.soundHit = (short) 3;
        this.soundKilled = (short) 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 80f;
        this.knockBackResist = 0.4f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 24)
      {
        this.npcSlots = 3f;
        this.name = "Fire Imp";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 8;
        this.damage = 30;
        this.defense = 16;
        this.lifeMax = 70;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
        this.lavaImmune = true;
        this.value = 350f;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 25)
      {
        this.name = "Burning Sphere";
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 9;
        this.damage = 30;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = (short) 3;
        this.soundKilled = (short) 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.alpha = (byte) 100;
      }
      else if ((int) this.type == 26)
      {
        this.name = "Goblin Peon";
        this.scale = 0.9f;
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 12;
        this.defense = 4;
        this.lifeMax = 60;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.8f;
        this.value = 100f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 27)
      {
        this.name = "Goblin Thief";
        this.scale = 0.95f;
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 20;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.7f;
        this.value = 200f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 28)
      {
        this.name = "Goblin Warrior";
        this.scale = 1.1f;
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 25;
        this.defense = 8;
        this.lifeMax = 110;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
        this.value = 150f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 29)
      {
        this.name = "Goblin Sorcerer";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 8;
        this.damage = 20;
        this.defense = 2;
        this.lifeMax = 40;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.6f;
        this.value = 200f;
      }
      else if ((int) this.type == 30)
      {
        this.name = "Chaos Ball";
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 9;
        this.damage = 20;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = (short) 3;
        this.soundKilled = (short) 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.alpha = (byte) 100;
        this.knockBackResist = 0.0f;
      }
      else if ((int) this.type == 31)
      {
        this.name = "Angry Bones";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 26;
        this.defense = 8;
        this.lifeMax = 80;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.8f;
        this.value = 130f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 32)
      {
        this.name = "Dark Caster";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 8;
        this.damage = 20;
        this.defense = 2;
        this.lifeMax = 50;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.6f;
        this.value = 140f;
        this.npcSlots = 2f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 33)
      {
        this.name = "Water Sphere";
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 9;
        this.damage = 20;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = (short) 3;
        this.soundKilled = (short) 3;
        this.noGravity = true;
        this.noTileCollide = true;
        this.alpha = (byte) 100;
        this.knockBackResist = 0.0f;
      }
      else if ((int) this.type == 34)
      {
        this.name = "Cursed Skull";
        this.width = (ushort) 26;
        this.height = (ushort) 28;
        this.aiStyle = (byte) 10;
        this.damage = 35;
        this.defense = 6;
        this.lifeMax = 40;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 150f;
        this.knockBackResist = 0.2f;
        this.npcSlots = 0.75f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 158)
      {
        this.name = "Dragon Skull";
        this.width = (ushort) 56;
        this.height = (ushort) 28;
        this.aiStyle = (byte) 10;
        this.damage = 45;
        this.defense = 8;
        this.lifeMax = 50;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 150f;
        this.knockBackResist = 0.2f;
        this.npcSlots = 0.75f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 35)
      {
        this.name = "Skeletron Head";
        this.width = (ushort) 80;
        this.height = (ushort) 102;
        this.aiStyle = (byte) 11;
        this.damage = 32;
        this.defense = 10;
        this.lifeMax = 4400;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 50000f;
        this.knockBackResist = 0.0f;
        this.boss = true;
        this.npcSlots = 6f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 36)
      {
        this.name = "Skeletron Hand";
        this.width = (ushort) 52;
        this.height = (ushort) 52;
        this.aiStyle = (byte) 12;
        this.damage = 20;
        this.defense = 14;
        this.lifeMax = 600;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 37)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Old Man";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 38)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Demolitionist";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 39)
      {
        this.npcSlots = 6f;
        this.name = "Bone Serpent Head";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 30;
        this.defense = 10;
        this.lifeMax = 250;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 5;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 1200f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 40)
      {
        this.name = "Bone Serpent Body";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 15;
        this.defense = 12;
        this.lifeMax = 250;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 5;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 1200f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 41)
      {
        this.name = "Bone Serpent Tail";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 10;
        this.defense = 18;
        this.lifeMax = 250;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 5;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 1200f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 42)
      {
        this.name = "Hornet";
        this.width = (ushort) 34;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 5;
        this.damage = 34;
        this.defense = 12;
        this.lifeMax = 50;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.5f;
        this.soundKilled = (short) 1;
        this.value = 200f;
        this.noGravity = true;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 157)
      {
        this.name = "Dragon Hornet";
        this.width = (ushort) 34;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 5;
        this.damage = 39;
        this.defense = 17;
        this.lifeMax = 65;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.5f;
        this.soundKilled = (short) 1;
        this.value = 200f;
        this.noGravity = true;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 43)
      {
        this.noGravity = true;
        this.noTileCollide = true;
        this.name = "Man Eater";
        this.width = (ushort) 30;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 13;
        this.damage = 42;
        this.defense = 14;
        this.lifeMax = 130;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.0f;
        this.soundKilled = (short) 1;
        this.value = 350f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 44)
      {
        this.name = "Undead Miner";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 22;
        this.defense = 9;
        this.lifeMax = 70;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.5f;
        this.value = 250f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 149)
      {
        this.name = "Vampire Miner";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 30;
        this.defense = 9;
        this.lifeMax = 90;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.7f;
        this.value = 250f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 45)
      {
        this.name = "Tim";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 8;
        this.damage = 20;
        this.defense = 4;
        this.lifeMax = 200;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.6f;
        this.value = 5000f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 46)
      {
        this.name = "Bunny";
        this.width = (ushort) 18;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 7;
        this.damage = 0;
        this.defense = 0;
        this.lifeMax = 5;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
      }
      else if ((int) this.type == 47)
      {
        this.name = "Corrupt Bunny";
        this.width = (ushort) 18;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 3;
        this.damage = 20;
        this.defense = 4;
        this.lifeMax = 70;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 500f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 48)
      {
        this.name = "Harpy";
        this.width = (ushort) 24;
        this.height = (ushort) 34;
        this.aiStyle = (byte) 14;
        this.damage = 25;
        this.defense = 8;
        this.lifeMax = 100;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.6f;
        this.soundKilled = (short) 1;
        this.value = 300f;
      }
      else if ((int) this.type == 49)
      {
        this.npcSlots = 0.5f;
        this.name = "Cave Bat";
        this.width = (ushort) 22;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 14;
        this.damage = 13;
        this.defense = 2;
        this.lifeMax = 16;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 4;
        this.value = 90f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 50)
      {
        this.boss = true;
        this.name = "King Slime";
        this.width = (ushort) 98;
        this.height = (ushort) 92;
        this.aiStyle = (byte) 15;
        this.damage = 40;
        this.defense = 10;
        this.lifeMax = 2000;
        this.knockBackResist = 0.0f;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.alpha = (byte) 30;
        this.value = 10000f;
        this.scale = 1.25f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 51)
      {
        this.npcSlots = 0.5f;
        this.name = "Jungle Bat";
        this.width = (ushort) 22;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 14;
        this.damage = 20;
        this.defense = 4;
        this.lifeMax = 34;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 4;
        this.value = 80f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 52)
      {
        this.name = "Doctor Bones";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 20;
        this.defense = 10;
        this.lifeMax = 500;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.5f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 53)
      {
        this.name = "The Groom";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 14;
        this.defense = 8;
        this.lifeMax = 200;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.5f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 54)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Clothier";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 55)
      {
        this.noGravity = true;
        this.name = "Goldfish";
        this.width = (ushort) 20;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 16;
        this.damage = 0;
        this.defense = 0;
        this.lifeMax = 5;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 56)
      {
        this.noTileCollide = true;
        this.noGravity = true;
        this.name = "Snatcher";
        this.width = (ushort) 30;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 13;
        this.damage = 25;
        this.defense = 10;
        this.lifeMax = 60;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.0f;
        this.soundKilled = (short) 1;
        this.value = 90f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 156)
      {
        this.noTileCollide = true;
        this.noGravity = true;
        this.name = "Dragon Snatcher";
        this.width = (ushort) 30;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 13;
        this.damage = 30;
        this.defense = 15;
        this.lifeMax = 75;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.0f;
        this.soundKilled = (short) 1;
        this.value = 90f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 57)
      {
        this.noGravity = true;
        this.name = "Corrupt Goldfish";
        this.width = (ushort) 18;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 16;
        this.damage = 30;
        this.defense = 6;
        this.lifeMax = 100;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 500f;
      }
      else if ((int) this.type == 58)
      {
        this.npcSlots = 0.5f;
        this.noGravity = true;
        this.name = "Piranha";
        this.width = (ushort) 18;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 16;
        this.damage = 25;
        this.defense = 2;
        this.lifeMax = 30;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 50f;
      }
      else if ((int) this.type == 59)
      {
        this.name = "Lava Slime";
        this.width = (ushort) 24;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 1;
        this.damage = 15;
        this.defense = 10;
        this.lifeMax = 50;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.scale = 1.1f;
        this.alpha = (byte) 50;
        this.lavaImmune = true;
        this.value = 120f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 60)
      {
        this.npcSlots = 0.5f;
        this.name = "Hellbat";
        this.width = (ushort) 22;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 14;
        this.damage = 35;
        this.defense = 8;
        this.lifeMax = 46;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 4;
        this.value = 120f;
        this.scale = 1.1f;
        this.lavaImmune = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 61)
      {
        this.name = "Vulture";
        this.width = (ushort) 36;
        this.height = (ushort) 36;
        this.aiStyle = (byte) 17;
        this.damage = 15;
        this.defense = 4;
        this.lifeMax = 40;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 60f;
      }
      else if ((int) this.type == 62)
      {
        this.npcSlots = 2f;
        this.name = "Demon";
        this.width = (ushort) 28;
        this.height = (ushort) 48;
        this.aiStyle = (byte) 14;
        this.damage = 32;
        this.defense = 8;
        this.lifeMax = 120;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 300f;
        this.lavaImmune = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 165)
      {
        this.npcSlots = 2f;
        this.name = "Arch Demon";
        this.width = (ushort) 28;
        this.height = (ushort) 48;
        this.aiStyle = (byte) 14;
        this.damage = 42;
        this.defense = 8;
        this.lifeMax = 140;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 300f;
        this.lavaImmune = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 63)
      {
        this.noGravity = true;
        this.name = "Blue Jellyfish";
        this.width = (ushort) 26;
        this.height = (ushort) 26;
        this.aiStyle = (byte) 18;
        this.damage = 20;
        this.defense = 2;
        this.lifeMax = 30;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 100f;
        this.alpha = (byte) 20;
      }
      else if ((int) this.type == 64)
      {
        this.noGravity = true;
        this.name = "Pink Jellyfish";
        this.width = (ushort) 26;
        this.height = (ushort) 26;
        this.aiStyle = (byte) 18;
        this.damage = 30;
        this.defense = 6;
        this.lifeMax = 70;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 100f;
        this.alpha = (byte) 20;
      }
      else if ((int) this.type == 65)
      {
        this.noGravity = true;
        this.name = "Shark";
        this.width = (ushort) 100;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 16;
        this.damage = 40;
        this.defense = 2;
        this.lifeMax = 300;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 400f;
        this.knockBackResist = 0.7f;
      }
      else if ((int) this.type == 148)
      {
        this.noGravity = true;
        this.name = "Orka";
        this.width = (ushort) 100;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 16;
        this.damage = 30;
        this.defense = 4;
        this.lifeMax = 350;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 400f;
        this.knockBackResist = 0.6f;
      }
      else if ((int) this.type == 66)
      {
        this.npcSlots = 2f;
        this.name = "Voodoo Demon";
        this.width = (ushort) 28;
        this.height = (ushort) 48;
        this.aiStyle = (byte) 14;
        this.damage = 32;
        this.defense = 8;
        this.lifeMax = 140;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 1000f;
        this.lavaImmune = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 67)
      {
        this.name = "Crab";
        this.width = (ushort) 28;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 3;
        this.damage = 20;
        this.defense = 10;
        this.lifeMax = 40;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 60f;
      }
      else if ((int) this.type == 68)
      {
        this.name = "Dungeon Guardian";
        this.width = (ushort) 80;
        this.height = (ushort) 102;
        this.aiStyle = (byte) 11;
        this.damage = 9000;
        this.defense = 9000;
        this.lifeMax = 9999;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 69)
      {
        this.name = "Antlion";
        this.width = (ushort) 24;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 19;
        this.damage = 10;
        this.defense = 6;
        this.lifeMax = 45;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.0f;
        this.value = 60f;
        this.behindTiles = true;
      }
      else if ((int) this.type == 147)
      {
        this.name = "Albino Antlion";
        this.width = (ushort) 24;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 19;
        this.damage = 12;
        this.defense = 8;
        this.lifeMax = 60;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.0f;
        this.value = 60f;
        this.behindTiles = true;
      }
      else if ((int) this.type == 70)
      {
        this.npcSlots = 0.3f;
        this.name = "Spike Ball";
        this.width = (ushort) 34;
        this.height = (ushort) 34;
        this.aiStyle = (byte) 20;
        this.damage = 32;
        this.defense = 100;
        this.lifeMax = 100;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.dontTakeDamage = true;
        this.scale = 1.5f;
      }
      else if ((int) this.type == 71)
      {
        this.npcSlots = 2f;
        this.name = "Dungeon Slime";
        this.width = (ushort) 36;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 1;
        this.damage = 30;
        this.defense = 7;
        this.lifeMax = 150;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.alpha = (byte) 60;
        this.value = 150f;
        this.scale = 1.25f;
        this.knockBackResist = 0.6f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 72)
      {
        this.npcSlots = 0.3f;
        this.name = "Blazing Wheel";
        this.width = (ushort) 34;
        this.height = (ushort) 34;
        this.aiStyle = (byte) 21;
        this.damage = 24;
        this.defense = 100;
        this.lifeMax = 100;
        this.alpha = (byte) 100;
        this.behindTiles = true;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.dontTakeDamage = true;
        this.scale = 1.2f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 73)
      {
        this.name = "Goblin Scout";
        this.scale = 0.95f;
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 20;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.7f;
        this.value = 200f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 74)
      {
        this.name = "Bird";
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 24;
        this.damage = 0;
        this.defense = 0;
        this.lifeMax = 5;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
      }
      else if ((int) this.type == 75)
      {
        this.noGravity = true;
        this.name = "Pixie";
        this.width = (ushort) 20;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 22;
        this.damage = 55;
        this.defense = 20;
        this.lifeMax = 150;
        this.soundHit = (short) 5;
        this.knockBackResist = 0.6f;
        this.soundKilled = (short) 7;
        this.value = 350f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 77)
      {
        this.name = "Armored Skeleton";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 60;
        this.defense = 36;
        this.lifeMax = 340;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.4f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 78)
      {
        this.name = "Mummy";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 50;
        this.defense = 16;
        this.lifeMax = 130;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.6f;
        this.value = 600f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 79)
      {
        this.name = "Dark Mummy";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 60;
        this.defense = 18;
        this.lifeMax = 180;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.5f;
        this.value = 700f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 152)
      {
        this.name = "Shadow Mummy";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 60;
        this.defense = 25;
        this.lifeMax = 190;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.5f;
        this.value = 700f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 80)
      {
        this.name = "Light Mummy";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 55;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.55f;
        this.value = 700f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 155)
      {
        this.name = "Spectral Mummy";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 65;
        this.defense = 10;
        this.lifeMax = 270;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.55f;
        this.value = 700f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 81)
      {
        this.name = "Corrupt Slime";
        this.width = (ushort) 40;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 1;
        this.damage = 55;
        this.defense = 20;
        this.lifeMax = 170;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.alpha = (byte) 55;
        this.value = 400f;
        this.scale = 1.1f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 150)
      {
        this.name = "Shadow Slime";
        this.width = (ushort) 40;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 1;
        this.damage = 60;
        this.defense = 25;
        this.lifeMax = 180;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.alpha = (byte) 55;
        this.value = 400f;
        this.scale = 1.1f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 82)
      {
        this.noGravity = true;
        this.noTileCollide = true;
        this.name = "Wraith";
        this.width = (ushort) 24;
        this.height = (ushort) 44;
        this.aiStyle = (byte) 22;
        this.damage = 75;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.alpha = (byte) 100;
        this.value = 500f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.7f;
      }
      else if ((int) this.type == 83)
      {
        this.name = "Cursed Hammer";
        this.width = (ushort) 40;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 23;
        this.damage = 80;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 6;
        this.value = 1000f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.4f;
      }
      else if ((int) this.type == 151)
      {
        this.name = "Shadow Hammer";
        this.width = (ushort) 40;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 23;
        this.damage = 95;
        this.defense = 18;
        this.lifeMax = 180;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 6;
        this.value = 1000f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.4f;
      }
      else if ((int) this.type == 84)
      {
        this.name = "Enchanted Sword";
        this.width = (ushort) 40;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 23;
        this.damage = 80;
        this.defense = 18;
        this.lifeMax = 200;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 6;
        this.value = 1000f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.4f;
      }
      else if ((int) this.type == 85)
      {
        this.name = "Mimic";
        this.width = (ushort) 24;
        this.height = (ushort) 24;
        this.aiStyle = (byte) 25;
        this.damage = 80;
        this.defense = 30;
        this.lifeMax = 500;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 6;
        this.value = 100000f;
        this.knockBackResist = 0.3f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 86)
      {
        this.name = "Unicorn";
        this.width = (ushort) 46;
        this.height = (ushort) 42;
        this.aiStyle = (byte) 26;
        this.damage = 65;
        this.defense = 30;
        this.lifeMax = 400;
        this.soundHit = (short) 10;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.3f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 87)
      {
        this.noTileCollide = true;
        this.npcSlots = 5f;
        this.name = "Wyvern Head";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 80;
        this.defense = 10;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 159)
      {
        this.noTileCollide = true;
        this.npcSlots = 5f;
        this.name = "Arch Wyvern Head";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 100;
        this.defense = 15;
        this.lifeMax = 4700;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 88)
      {
        this.noTileCollide = true;
        this.name = "Wyvern Legs";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 160)
      {
        this.noTileCollide = true;
        this.name = "Arch Wyvern Legs";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 50;
        this.defense = 25;
        this.lifeMax = 4500;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 89)
      {
        this.noTileCollide = true;
        this.name = "Wyvern Body";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 2000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 161)
      {
        this.noTileCollide = true;
        this.name = "Arch Wyvern Body";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 45;
        this.defense = 20;
        this.lifeMax = 4300;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 2000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 90)
      {
        this.noTileCollide = true;
        this.name = "Wyvern Body 2";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 162)
      {
        this.noTileCollide = true;
        this.name = "Arch Wyvern Body 2";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 91)
      {
        this.noTileCollide = true;
        this.name = "Wyvern Body 3";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 163)
      {
        this.noTileCollide = true;
        this.name = "Arch Wyvern Body 3";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 45;
        this.defense = 20;
        this.lifeMax = 4300;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 92)
      {
        this.noTileCollide = true;
        this.name = "Wyvern Tail";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 164)
      {
        this.noTileCollide = true;
        this.name = "Arch Wyvern Tail";
        this.width = (ushort) 32;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 55;
        this.defense = 15;
        this.lifeMax = 4000;
        this.soundHit = (short) 7;
        this.soundKilled = (short) 8;
        this.noGravity = true;
        this.knockBackResist = 0.0f;
        this.value = 10000f;
        this.scale = 1f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 93)
      {
        this.npcSlots = 0.5f;
        this.name = "Giant Bat";
        this.width = (ushort) 26;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 14;
        this.damage = 70;
        this.defense = 20;
        this.lifeMax = 160;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.75f;
        this.soundKilled = (short) 4;
        this.value = 400f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 94)
      {
        this.npcSlots = 1f;
        this.name = "Corruptor";
        this.width = (ushort) 44;
        this.height = (ushort) 44;
        this.aiStyle = (byte) 5;
        this.damage = 60;
        this.defense = 32;
        this.lifeMax = 230;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.knockBackResist = 0.55f;
        this.value = 500f;
      }
      else if ((int) this.type == 95)
      {
        this.name = "Digger Head";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 45;
        this.defense = 10;
        this.lifeMax = 200;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 0.9f;
        this.value = 300f;
      }
      else if ((int) this.type == 96)
      {
        this.name = "Digger Body";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 28;
        this.defense = 20;
        this.lifeMax = 200;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 0.9f;
        this.value = 300f;
      }
      else if ((int) this.type == 97)
      {
        this.name = "Digger Tail";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 26;
        this.defense = 30;
        this.lifeMax = 200;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 0.9f;
        this.value = 300f;
      }
      else if ((int) this.type == 98)
      {
        this.npcSlots = 3.5f;
        this.name = "Seeker Head";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 70;
        this.defense = 36;
        this.lifeMax = 500;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 700f;
      }
      else if ((int) this.type == 99)
      {
        this.name = "Seeker Body";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 55;
        this.defense = 40;
        this.lifeMax = 500;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 700f;
      }
      else if ((int) this.type == 100)
      {
        this.name = "Seeker Tail";
        this.width = (ushort) 22;
        this.height = (ushort) 22;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 40;
        this.defense = 44;
        this.lifeMax = 500;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 700f;
      }
      else if ((int) this.type == 101)
      {
        this.noGravity = true;
        this.noTileCollide = true;
        this.behindTiles = true;
        this.name = "Clinger";
        this.width = (ushort) 30;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 13;
        this.damage = 70;
        this.defense = 30;
        this.lifeMax = 320;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.2f;
        this.soundKilled = (short) 1;
        this.value = 600f;
      }
      else if ((int) this.type == 102)
      {
        this.npcSlots = 0.5f;
        this.noGravity = true;
        this.name = "Angler Fish";
        this.width = (ushort) 18;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 16;
        this.damage = 80;
        this.defense = 22;
        this.lifeMax = 90;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 500f;
      }
      else if ((int) this.type == 103)
      {
        this.noGravity = true;
        this.name = "Green Jellyfish";
        this.width = (ushort) 26;
        this.height = (ushort) 26;
        this.aiStyle = (byte) 18;
        this.damage = 80;
        this.defense = 30;
        this.lifeMax = 120;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.value = 800f;
        this.alpha = (byte) 20;
      }
      else if ((int) this.type == 104)
      {
        this.name = "Werewolf";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 70;
        this.defense = 40;
        this.lifeMax = 400;
        this.soundHit = (short) 6;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.4f;
        this.value = 1000f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 105)
      {
        this.friendly = true;
        this.name = "Bound Goblin";
        this.width = (ushort) 18;
        this.height = (ushort) 34;
        this.aiStyle = (byte) 0;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
        this.scale = 0.9f;
      }
      else if ((int) this.type == 106)
      {
        this.friendly = true;
        this.name = "Bound Wizard";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 0;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 107)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Goblin Tinkerer";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
        this.scale = 0.9f;
      }
      else if ((int) this.type == 108)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Wizard";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 109)
      {
        this.name = "Clown";
        this.width = (ushort) 34;
        this.height = (ushort) 78;
        this.aiStyle = (byte) 3;
        this.damage = 50;
        this.defense = 20;
        this.lifeMax = 400;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.4f;
        this.value = 8000f;
      }
      else if ((int) this.type == 110)
      {
        this.name = "Skeleton Archer";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 55;
        this.defense = 28;
        this.lifeMax = 260;
        this.soundHit = (short) 2;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.55f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 111)
      {
        this.name = "Goblin Archer";
        this.scale = 0.95f;
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 20;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.7f;
        this.value = 200f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 112)
      {
        this.name = "Vile Spit";
        this.width = (ushort) 16;
        this.height = (ushort) 16;
        this.aiStyle = (byte) 9;
        this.damage = 65;
        this.defense = 0;
        this.lifeMax = 1;
        this.soundHit = (short) 0;
        this.soundKilled = (short) 9;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.scale = 0.9f;
        this.alpha = (byte) 80;
      }
      else if ((int) this.type == 113)
      {
        this.npcSlots = 10f;
        this.name = "Wall of Flesh";
        this.width = (ushort) 100;
        this.height = (ushort) 100;
        this.aiStyle = (byte) 27;
        this.damage = 50;
        this.defense = 12;
        this.lifeMax = 8000;
        this.soundHit = (short) 8;
        this.soundKilled = (short) 10;
        this.noGravity = true;
        this.noTileCollide = true;
        this.behindTiles = true;
        this.knockBackResist = 0.0f;
        this.scale = 1.2f;
        this.boss = true;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.value = 80000f;
      }
      else if ((int) this.type == 114)
      {
        this.name = "Wall of Flesh Eye";
        this.width = (ushort) 100;
        this.height = (ushort) 100;
        this.aiStyle = (byte) 28;
        this.damage = 50;
        this.defense = 0;
        this.lifeMax = 8000;
        this.soundHit = (short) 8;
        this.soundKilled = (short) 10;
        this.noGravity = true;
        this.noTileCollide = true;
        this.behindTiles = true;
        this.knockBackResist = 0.0f;
        this.scale = 1.2f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.value = 80000f;
      }
      else if ((int) this.type == 115)
      {
        this.name = "The Hungry";
        this.width = (ushort) 30;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 29;
        this.damage = 30;
        this.defense = 10;
        this.lifeMax = 240;
        this.soundHit = (short) 9;
        this.soundKilled = (short) 11;
        this.noGravity = true;
        this.behindTiles = true;
        this.noTileCollide = true;
        this.knockBackResist = 1.1f;
      }
      else if ((int) this.type == 116)
      {
        this.name = "The Hungry II";
        this.width = (ushort) 30;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 2;
        this.damage = 30;
        this.defense = 6;
        this.lifeMax = 80;
        this.soundHit = (short) 9;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 12;
      }
      else if ((int) this.type == 117)
      {
        this.name = "Leech Head";
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 26;
        this.defense = 2;
        this.lifeMax = 60;
        this.soundHit = (short) 9;
        this.soundKilled = (short) 12;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
      }
      else if ((int) this.type == 118)
      {
        this.name = "Leech Body";
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 22;
        this.defense = 6;
        this.lifeMax = 60;
        this.soundHit = (short) 9;
        this.soundKilled = (short) 12;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
      }
      else if ((int) this.type == 119)
      {
        this.name = "Leech Tail";
        this.width = (ushort) 14;
        this.height = (ushort) 14;
        this.aiStyle = (byte) 6;
        this.netAlways = true;
        this.damage = 18;
        this.defense = 10;
        this.lifeMax = 60;
        this.soundHit = (short) 9;
        this.soundKilled = (short) 12;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
      }
      else if ((int) this.type == 120)
      {
        this.name = "Chaos Elemental";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 40;
        this.defense = 30;
        this.lifeMax = 370;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.4f;
        this.value = 600f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 154)
      {
        this.name = "Spectral Elemental";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 50;
        this.defense = 35;
        this.lifeMax = 400;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.4f;
        this.value = 600f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 121)
      {
        this.name = "Slimer";
        this.width = (ushort) 40;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 14;
        this.damage = 45;
        this.defense = 20;
        this.lifeMax = 60;
        this.soundHit = (short) 1;
        this.alpha = (byte) 55;
        this.knockBackResist = 0.8f;
        this.scale = 1.1f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 122)
      {
        this.noGravity = true;
        this.name = "Gastropod";
        this.width = (ushort) 20;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 22;
        this.damage = 60;
        this.defense = 22;
        this.lifeMax = 220;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 600f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 153)
      {
        this.noGravity = true;
        this.name = "Spectral Gastropod";
        this.width = (ushort) 20;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 22;
        this.damage = 60;
        this.defense = 22;
        this.lifeMax = 220;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 600f;
        this.buffImmune[20] = true;
      }
      else if ((int) this.type == 123)
      {
        this.friendly = true;
        this.name = "Bound Mechanic";
        this.width = (ushort) 18;
        this.height = (ushort) 34;
        this.aiStyle = (byte) 0;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
        this.scale = 0.9f;
      }
      else if ((int) this.type == 124)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Mechanic";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 125)
      {
        this.name = "Retinazer";
        this.width = (ushort) 100;
        this.height = (ushort) 110;
        this.aiStyle = (byte) 30;
        this.damage = 50;
        this.defense = 10;
        this.lifeMax = 24000;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 14;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.timeLeft = 22500;
        this.boss = true;
        this.value = 120000f;
        this.npcSlots = 5f;
      }
      else if ((int) this.type == 126)
      {
        this.name = "Spazmatism";
        this.width = (ushort) 100;
        this.height = (ushort) 110;
        this.aiStyle = (byte) 31;
        this.damage = 50;
        this.defense = 10;
        this.lifeMax = 24000;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 14;
        this.knockBackResist = 0.0f;
        this.noGravity = true;
        this.noTileCollide = true;
        this.timeLeft = 22500;
        this.boss = true;
        this.value = 120000f;
        this.npcSlots = 5f;
      }
      else if ((int) this.type == (int) sbyte.MaxValue)
      {
        this.name = "Skeletron Prime";
        this.width = (ushort) 80;
        this.height = (ushort) 102;
        this.aiStyle = (byte) 32;
        this.damage = 50;
        this.defense = 25;
        this.lifeMax = 30000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.value = 120000f;
        this.knockBackResist = 0.0f;
        this.boss = true;
        this.npcSlots = 6f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 128)
      {
        this.name = "Prime Cannon";
        this.width = (ushort) 52;
        this.height = (ushort) 52;
        this.aiStyle = (byte) 35;
        this.damage = 30;
        this.defense = 25;
        this.lifeMax = 7000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if ((int) this.type == 129)
      {
        this.name = "Prime Saw";
        this.width = (ushort) 52;
        this.height = (ushort) 52;
        this.aiStyle = (byte) 33;
        this.damage = 52;
        this.defense = 40;
        this.lifeMax = 10000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if ((int) this.type == 130)
      {
        this.name = "Prime Vice";
        this.width = (ushort) 52;
        this.height = (ushort) 52;
        this.aiStyle = (byte) 34;
        this.damage = 45;
        this.defense = 35;
        this.lifeMax = 10000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if ((int) this.type == 131)
      {
        this.name = "Prime Laser";
        this.width = (ushort) 52;
        this.height = (ushort) 52;
        this.aiStyle = (byte) 36;
        this.damage = 29;
        this.defense = 20;
        this.lifeMax = 6000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.netAlways = true;
      }
      else if ((int) this.type == 132)
      {
        this.name = "Bald Zombie";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 14;
        this.defense = 6;
        this.lifeMax = 45;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 2;
        this.knockBackResist = 0.5f;
        this.value = 60f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 133)
      {
        this.name = "Wandering Eye";
        this.width = (ushort) 30;
        this.height = (ushort) 32;
        this.aiStyle = (byte) 2;
        this.damage = 40;
        this.defense = 20;
        this.lifeMax = 300;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.8f;
        this.soundKilled = (short) 1;
        this.value = 500f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 134)
      {
        this.npcSlots = 5f;
        this.name = "The Destroyer";
        this.width = (ushort) 38;
        this.height = (ushort) 38;
        this.aiStyle = (byte) 37;
        this.damage = 60;
        this.defense = 0;
        this.lifeMax = 80000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.value = 120000f;
        this.scale = 1.25f;
        this.boss = true;
        this.netAlways = true;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 135)
      {
        this.npcSlots = 5f;
        this.name = "The Destroyer Body";
        this.width = (ushort) 38;
        this.height = (ushort) 38;
        this.aiStyle = (byte) 37;
        this.damage = 40;
        this.defense = 30;
        this.lifeMax = 80000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.netAlways = true;
        this.scale = 1.25f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 136)
      {
        this.npcSlots = 5f;
        this.name = "The Destroyer Tail";
        this.width = (ushort) 38;
        this.height = (ushort) 38;
        this.aiStyle = (byte) 37;
        this.damage = 20;
        this.defense = 35;
        this.lifeMax = 80000;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.noTileCollide = true;
        this.knockBackResist = 0.0f;
        this.behindTiles = true;
        this.scale = 1.25f;
        this.netAlways = true;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 137)
      {
        this.name = "Illuminant Bat";
        this.width = (ushort) 26;
        this.height = (ushort) 20;
        this.aiStyle = (byte) 14;
        this.damage = 75;
        this.defense = 30;
        this.lifeMax = 200;
        this.soundHit = (short) 1;
        this.knockBackResist = 0.75f;
        this.soundKilled = (short) 6;
        this.value = 500f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 138)
      {
        this.name = "Illuminant Slime";
        this.width = (ushort) 24;
        this.height = (ushort) 18;
        this.aiStyle = (byte) 1;
        this.damage = 70;
        this.defense = 30;
        this.lifeMax = 180;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 6;
        this.alpha = (byte) 100;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
        this.knockBackResist = 0.85f;
        this.scale = 1.05f;
        this.buffImmune[31] = false;
      }
      else if ((int) this.type == 139)
      {
        this.npcSlots = 1f;
        this.name = "Probe";
        this.width = (ushort) 30;
        this.height = (ushort) 30;
        this.aiStyle = (byte) 5;
        this.damage = 50;
        this.defense = 20;
        this.lifeMax = 200;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 14;
        this.noGravity = true;
        this.knockBackResist = 0.8f;
        this.noTileCollide = true;
      }
      else if ((int) this.type == 140)
      {
        this.name = "Possessed Armor";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 3;
        this.damage = 55;
        this.defense = 28;
        this.lifeMax = 260;
        this.soundHit = (short) 4;
        this.soundKilled = (short) 6;
        this.knockBackResist = 0.4f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
      }
      else if ((int) this.type == 141)
      {
        this.name = "Toxic Sludge";
        this.width = (ushort) 34;
        this.height = (ushort) 28;
        this.aiStyle = (byte) 1;
        this.damage = 50;
        this.defense = 18;
        this.lifeMax = 150;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.alpha = (byte) 55;
        this.value = 400f;
        this.scale = 1.1f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.knockBackResist = 0.8f;
      }
      else if ((int) this.type == 142)
      {
        this.townNPC = true;
        this.friendly = true;
        this.name = "Santa Claus";
        this.width = (ushort) 18;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 7;
        this.damage = 10;
        this.defense = 15;
        this.lifeMax = 250;
        this.soundHit = (short) 1;
        this.soundKilled = (short) 1;
        this.knockBackResist = 0.5f;
      }
      else if ((int) this.type == 143)
      {
        this.name = "Snowman Gangsta";
        this.width = (ushort) 26;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 38;
        this.damage = 50;
        this.defense = 20;
        this.lifeMax = 200;
        this.soundHit = (short) 11;
        this.soundKilled = (short) 15;
        this.knockBackResist = 0.6f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 144)
      {
        this.name = "Mister Stabby";
        this.width = (ushort) 26;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 38;
        this.damage = 65;
        this.defense = 26;
        this.lifeMax = 240;
        this.soundHit = (short) 11;
        this.soundKilled = (short) 15;
        this.knockBackResist = 0.6f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      else if ((int) this.type == 145)
      {
        this.name = "Snow Balla";
        this.width = (ushort) 26;
        this.height = (ushort) 40;
        this.aiStyle = (byte) 38;
        this.damage = 55;
        this.defense = 22;
        this.lifeMax = 220;
        this.soundHit = (short) 11;
        this.soundKilled = (short) 15;
        this.knockBackResist = 0.6f;
        this.value = 400f;
        this.buffImmune[20] = true;
        this.buffImmune[31] = false;
        this.buffImmune[24] = true;
        this.buffImmune[39] = true;
      }
      this.frameY = (short) 0;
      this.frameHeight = (short) (SpriteSheet<_sheetSprites>.src[1088 + (int) this.type].Height / (int) NPC.npcFrameCount[(int) this.type]);
      if (scaleOverride > 0.0)
      {
        int num1 = (int) ((double) this.width * (double) this.scale);
        int num2 = (int) ((double) this.height * (double) this.scale);
        this.position.X += (float) (num1 >> 1);
        this.position.Y += (float) num2;
        this.scale = (float) scaleOverride;
        this.width = (ushort) ((double) this.width * (double) this.scale);
        this.height = (ushort) ((double) this.height * (double) this.scale);
        if ((int) this.height == 16 || (int) this.height == 32)
          ++this.height;
        this.position.X -= (float) ((int) this.width >> 1);
        this.position.Y -= (float) this.height;
      }
      else
      {
        this.width = (ushort) ((double) this.width * (double) this.scale);
        this.height = (ushort) ((double) this.height * (double) this.scale);
      }
      this.aabb.X = (int) this.position.X;
      this.aabb.Y = (int) this.position.Y;
      this.aabb.Width = (int) this.width;
      this.aabb.Height = (int) this.height;
      this.healthBarLife = this.life = this.lifeMax;
      this.defDamage = this.damage;
      this.defDefense = (short) this.defense;
      this.displayName = Lang.npcName((int) this.netID);
    }

    private void BoundAI()
    {
      if (Main.netMode != 1)
      {
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0 && (int) Main.player[index].talkNPC == (int) this.whoAmI)
          {
            if ((int) this.type == 105)
            {
              this.Transform(107);
              return;
            }
            else if ((int) this.type == 106)
            {
              this.Transform(108);
              return;
            }
            else if ((int) this.type == 123)
            {
              this.Transform(124);
              return;
            }
          }
        }
      }
      this.velocity.X *= 0.93f;
      if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
        this.velocity.X = 0.0f;
      this.TargetClosest(true);
      this.spriteDirection = this.direction;
    }

    private unsafe void SlimeAI()
    {
      bool flag = !Main.gameTime.dayTime || this.life != this.lifeMax || this.aabb.Y > Main.worldSurface << 4;
      if ((int) this.type == 81)
      {
        flag = true;
        if (Main.rand.Next(32) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, (int) this.alpha, this.color, 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.3f;
            dustPtr->velocity.Y *= 0.3f;
          }
        }
      }
      else if ((int) this.type == 59)
      {
        Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, new Vector3(1f, 0.3f, 0.1f));
        Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.70000004768372);
        if ((IntPtr) dustPtr != IntPtr.Zero)
          dustPtr->noGravity = true;
      }
      if ((double) this.ai2 > 1.0)
        --this.ai2;
      if (this.wet)
      {
        if (this.collideY)
          this.velocity.Y = -2f;
        if ((double) this.velocity.Y < 0.0)
        {
          if ((double) this.ai3 == (double) this.position.X)
          {
            this.direction = -this.direction;
            this.ai2 = 200f;
          }
        }
        else if ((double) this.velocity.Y > 0.0)
          this.ai3 = this.position.X;
        if ((int) this.type == 59)
        {
          if ((double) this.velocity.Y > 2.0)
            this.velocity.Y *= 0.9f;
          else if ((int) this.directionY < 0)
            this.velocity.Y -= 0.8f;
          this.velocity.Y -= 0.5f;
          if ((double) this.velocity.Y < -10.0)
            this.velocity.Y = -10f;
        }
        else
        {
          if ((double) this.velocity.Y > 2.0)
            this.velocity.Y *= 0.9f;
          this.velocity.Y -= 0.5f;
          if ((double) this.velocity.Y < -4.0)
            this.velocity.Y = -4f;
        }
        if ((double) this.ai2 == 1.0 && flag)
          this.TargetClosest(true);
      }
      this.aiAction = (byte) 0;
      if ((double) this.ai2 == 0.0)
      {
        this.ai0 = -100f;
        this.ai2 = 1f;
        this.TargetClosest(true);
      }
      if ((double) this.velocity.Y == 0.0)
      {
        if ((double) this.ai3 == (double) this.position.X)
        {
          this.direction = -this.direction;
          this.ai2 = 200f;
        }
        this.ai3 = 0.0f;
        this.velocity.X *= 0.8f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        if (flag)
          ++this.ai0;
        ++this.ai0;
        if ((int) this.type == 59)
          this.ai0 += 2f;
        else if ((int) this.type == 71)
          this.ai0 += 3f;
        else if ((int) this.type == 138)
          this.ai0 += 2f;
        else if ((int) this.type == 81)
        {
          if ((double) this.scale >= 0.0)
            this.ai0 += 4f;
          else
            ++this.ai0;
        }
        if ((double) this.ai0 >= 0.0)
        {
          this.netUpdate = true;
          if (flag && (double) this.ai2 == 1.0)
            this.TargetClosest(true);
          if ((double) this.ai1 == 2.0)
          {
            if ((int) this.type == 59)
            {
              this.velocity.X += 3.5f * (float) this.direction;
              this.velocity.Y = -10f;
            }
            else
            {
              this.velocity.X += (float) (3 * (int) this.direction);
              this.velocity.Y = -8f;
            }
            this.ai0 = -200f;
            this.ai1 = 0.0f;
            this.ai3 = this.position.X;
          }
          else
          {
            this.velocity.Y = -6f;
            this.velocity.X += (float) (2 * (int) this.direction);
            if ((int) this.type == 59)
              this.velocity.X += (float) (2 * (int) this.direction);
            this.ai0 = -120f;
            ++this.ai1;
          }
          if ((int) this.type != 141)
            return;
          this.velocity.Y *= 1.3f;
          this.velocity.X *= 1.2f;
        }
        else
        {
          if ((double) this.ai0 < -30.0)
            return;
          this.aiAction = (byte) 1;
        }
      }
      else
      {
        if ((int) this.target >= 8 || ((int) this.direction != 1 || (double) this.velocity.X >= 3.0) && ((int) this.direction != -1 || (double) this.velocity.X <= -3.0))
          return;
        if ((int) this.direction == -1 && (double) this.velocity.X < 0.1 || (int) this.direction == 1 && (double) this.velocity.X > -0.1)
          this.velocity.X += 0.2f * (float) this.direction;
        else
          this.velocity.X *= 0.93f;
      }
    }

    private unsafe void FloatingEyeballAI()
    {
      this.noGravity = true;
      if (this.collideX)
      {
        this.velocity.X = this.oldVelocity.X * -0.5f;
        if ((int) this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
          this.velocity.X = 2f;
        else if ((int) this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
          this.velocity.X = -2f;
      }
      if (this.collideY)
      {
        this.velocity.Y = this.oldVelocity.Y * -0.5f;
        if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
          this.velocity.Y = 1f;
        else if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
          this.velocity.Y = -1f;
      }
      if (((int) this.type == 2 || (int) this.type == 133) && (Main.gameTime.dayTime && this.aabb.Y <= Main.worldSurfacePixels))
      {
        if (this.timeLeft > 10)
          this.timeLeft = 10;
        this.directionY = (double) this.velocity.Y > 0.0 ? (sbyte) 1 : (sbyte) -1;
        this.direction = (double) this.velocity.X > 0.0 ? (sbyte) 1 : (sbyte) -1;
      }
      else
        this.TargetClosest(true);
      if ((int) this.type == 116)
      {
        this.TargetClosest(true);
        Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, new Vector3(0.3f, 0.2f, 0.1f));
        if ((int) this.direction == -1 && (double) this.velocity.X > -6.0)
        {
          this.velocity.X -= 0.1f;
          if ((double) this.velocity.X > 6.0)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X > 0.0)
            this.velocity.X -= 0.2f;
          if ((double) this.velocity.X < -6.0)
            this.velocity.X = -6f;
        }
        else if ((int) this.direction == 1 && (double) this.velocity.X < 6.0)
        {
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X < -6.0)
            this.velocity.X += 0.1f;
          else if ((double) this.velocity.X < 0.0)
            this.velocity.X += 0.2f;
          if ((double) this.velocity.X > 6.0)
            this.velocity.X = 6f;
        }
        if ((int) this.directionY == -1 && (double) this.velocity.Y > -2.5)
        {
          this.velocity.Y -= 0.04f;
          if ((double) this.velocity.Y > 2.5)
            this.velocity.Y -= 0.05f;
          else if ((double) this.velocity.Y > 0.0)
            this.velocity.Y -= 0.15f;
          if ((double) this.velocity.Y < -2.5)
            this.velocity.Y = -2.5f;
        }
        else if ((int) this.directionY == 1 && (double) this.velocity.Y < 1.5)
        {
          this.velocity.Y += 0.04f;
          if ((double) this.velocity.Y < -2.5)
            this.velocity.Y += 0.05f;
          else if ((double) this.velocity.Y < 0.0)
            this.velocity.Y += 0.15f;
          if ((double) this.velocity.Y > 2.5)
            this.velocity.Y = 2.5f;
        }
        if (Main.rand.Next(40) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 5, (double) this.velocity.X, 2.0, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.5f;
            dustPtr->velocity.Y *= 0.1f;
          }
        }
      }
      else if ((int) this.type == 133)
      {
        if (this.life < this.lifeMax >> 1)
        {
          if ((int) this.direction == -1 && (double) this.velocity.X > -6.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 6.0)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X += 0.05f;
            if ((double) this.velocity.X < -6.0)
              this.velocity.X = -6f;
          }
          else if ((int) this.direction == 1 && (double) this.velocity.X < 6.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -6.0)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X -= 0.05f;
            if ((double) this.velocity.X > 6.0)
              this.velocity.X = 6f;
          }
          if ((int) this.directionY == -1 && (double) this.velocity.Y > -4.0)
          {
            this.velocity.Y -= 0.1f;
            if ((double) this.velocity.Y > 4.0)
              this.velocity.Y -= 0.1f;
            else if ((double) this.velocity.Y > 0.0)
              this.velocity.Y += 0.05f;
            if ((double) this.velocity.Y < -4.0)
              this.velocity.Y = -4f;
          }
          else if ((int) this.directionY == 1 && (double) this.velocity.Y < 4.0)
          {
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y < -4.0)
              this.velocity.Y += 0.1f;
            else if ((double) this.velocity.Y < 0.0)
              this.velocity.Y -= 0.05f;
            if ((double) this.velocity.Y > 4.0)
              this.velocity.Y = 4f;
          }
        }
        else
        {
          if ((int) this.direction == -1 && (double) this.velocity.X > -4.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 4.0)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X += 0.05f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X = -4f;
          }
          else if ((int) this.direction == 1 && (double) this.velocity.X < 4.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X -= 0.05f;
            else if ((double) this.velocity.X > 4.0)
              this.velocity.X = 4f;
          }
          if ((int) this.directionY == -1 && (double) this.velocity.Y > -1.5)
          {
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 1.5)
              this.velocity.Y -= 0.05f;
            else if ((double) this.velocity.Y > 0.0)
              this.velocity.Y += 0.03f;
            else if ((double) this.velocity.Y < -1.5)
              this.velocity.Y = -1.5f;
          }
          else if ((int) this.directionY == 1 && (double) this.velocity.Y < 1.5)
          {
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -1.5)
              this.velocity.Y += 0.05f;
            else if ((double) this.velocity.Y < 0.0)
              this.velocity.Y -= 0.03f;
            else if ((double) this.velocity.Y > 1.5)
              this.velocity.Y = 1.5f;
          }
        }
      }
      else
      {
        if ((int) this.direction == -1 && (double) this.velocity.X > -4.0)
        {
          this.velocity.X -= 0.1f;
          if ((double) this.velocity.X > 4.0)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X > 0.0)
            this.velocity.X += 0.05f;
          else if ((double) this.velocity.X < -4.0)
            this.velocity.X = -4f;
        }
        else if ((int) this.direction == 1 && (double) this.velocity.X < 4.0)
        {
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X < -4.0)
            this.velocity.X += 0.1f;
          else if ((double) this.velocity.X < 0.0)
            this.velocity.X -= 0.05f;
          else if ((double) this.velocity.X > 4.0)
            this.velocity.X = 4f;
        }
        if ((int) this.directionY == -1 && (double) this.velocity.Y > -1.5)
        {
          this.velocity.Y -= 0.04f;
          if ((double) this.velocity.Y > 1.5)
            this.velocity.Y -= 0.05f;
          else if ((double) this.velocity.Y > 0.0)
            this.velocity.Y += 0.03f;
          else if ((double) this.velocity.Y < -1.5)
            this.velocity.Y = -1.5f;
        }
        else if ((int) this.directionY == 1 && (double) this.velocity.Y < 1.5)
        {
          this.velocity.Y += 0.04f;
          if ((double) this.velocity.Y < -1.5)
            this.velocity.Y += 0.05f;
          else if ((double) this.velocity.Y < 0.0)
            this.velocity.Y -= 0.03f;
          else if ((double) this.velocity.Y > 1.5)
            this.velocity.Y = 1.5f;
        }
      }
      if (((int) this.type == 2 || (int) this.type == 133) && Main.rand.Next(40) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 5, (double) this.velocity.X, 2.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.5f;
          dustPtr->velocity.Y *= 0.1f;
        }
      }
      if (!this.wet)
        return;
      if ((double) this.velocity.Y > 0.0)
        this.velocity.Y *= 0.95f;
      this.velocity.Y -= 0.5f;
      if ((double) this.velocity.Y < -4.0)
        this.velocity.Y = -4f;
      this.TargetClosest(true);
    }

    private unsafe void WalkAI()
    {
      int num1 = 60;
      if ((int) this.type == 120 || (int) this.type == 154)
      {
        num1 = 20;
        if ((double) this.ai3 == -120.0)
        {
          this.velocity.X = 0.0f;
          this.velocity.Y = 0.0f;
          this.ai3 = 0.0f;
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 8);
          Vector2 vector2 = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
          float num2 = this.oldPos[2].X + (float) ((int) this.width >> 1) - vector2.X;
          float num3 = this.oldPos[2].Y + (float) ((int) this.height >> 1) - vector2.Y;
          float num4 = 2f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
          float num5 = num2 * num4;
          float num6 = num3 * num4;
          for (int index = 0; index < 16; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(71, ref this.aabb, (double) num5, (double) num6, 200, new Color(), 2.0);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->noGravity = true;
              dustPtr->velocity.X *= 2f;
            }
            else
              break;
          }
          for (int index = 0; index < 16; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust((int) this.oldPos[2].X, (int) this.oldPos[2].Y, (int) this.width, (int) this.height, 71, -(double) num5, -(double) num6, 200, new Color(), 2.0);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->noGravity = true;
              dustPtr->velocity.X *= 2f;
            }
            else
              break;
          }
        }
      }
      bool flag1 = false;
      bool flag2 = true;
      if ((int) this.type == 47 || (int) this.type == 67 || ((int) this.type == 109 || (int) this.type == 110) || ((int) this.type == 111 || (int) this.type == 120 || (int) this.type == 154))
        flag2 = false;
      if ((int) this.type != 110 && (int) this.type != 111 || (double) this.ai2 <= 0.0)
      {
        if ((double) this.velocity.Y == 0.0 && ((double) this.velocity.X > 0.0 && (int) this.direction < 0 || (double) this.velocity.X < 0.0 && (int) this.direction > 0))
          flag1 = true;
        if ((double) this.position.X == (double) this.oldPosition.X || (double) this.ai3 >= (double) num1 || flag1)
          ++this.ai3;
        else if ((double) Math.Abs(this.velocity.X) > 0.9 && (double) this.ai3 > 0.0)
          --this.ai3;
        if ((double) this.ai3 > (double) (num1 * 10))
          this.ai3 = 0.0f;
        if (this.justHit)
          this.ai3 = 0.0f;
        if ((double) this.ai3 == (double) num1)
          this.netUpdate = true;
      }
      if ((double) this.ai3 < (double) num1 && (!Main.gameTime.dayTime || this.aabb.Y > Main.worldSurfacePixels || ((int) this.type == 26 || (int) this.type == 27) || ((int) this.type == 28 || (int) this.type == 31 || ((int) this.type == 47 || (int) this.type == 67)) || ((int) this.type == 73 || (int) this.type == 77 || ((int) this.type == 78 || (int) this.type == 79) || ((int) this.type == 80 || (int) this.type == 110 || ((int) this.type == 111 || (int) this.type == 120))) || ((int) this.type == 152 || (int) this.type == 154 || (int) this.type == 155)))
      {
        if ((int) this.type == 3 || (int) this.type == 21 || ((int) this.type == 31 || (int) this.type == 77) || ((int) this.type == 110 || (int) this.type == 132))
        {
          if (Main.rand.Next(1000) == 0)
            Main.PlaySound(14, this.aabb.X, this.aabb.Y, 1);
        }
        else if (((int) this.type == 78 || (int) this.type == 79 || ((int) this.type == 80 || (int) this.type == 152) || (int) this.type == 155) && Main.rand.Next(500) == 0)
          Main.PlaySound(26, this.aabb.X, this.aabb.Y, 1);
        this.TargetClosest(true);
      }
      else if ((int) this.type != 110 && (int) this.type != 111 || (double) this.ai2 <= 0.0)
      {
        if (Main.gameTime.dayTime && this.aabb.Y >> 4 < Main.worldSurface && this.timeLeft > 10)
          this.timeLeft = 10;
        if ((double) this.velocity.X == 0.0)
        {
          if ((double) this.velocity.Y == 0.0)
          {
            ++this.ai0;
            if ((double) this.ai0 >= 2.0)
            {
              this.direction = -this.direction;
              this.spriteDirection = this.direction;
              this.ai0 = 0.0f;
            }
          }
        }
        else
          this.ai0 = 0.0f;
        if ((int) this.direction == 0)
          this.direction = (sbyte) 1;
      }
      if ((int) this.type == 120)
      {
        if ((double) this.velocity.X < -3.0 || (double) this.velocity.X > 3.0)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.8f;
        }
        else if ((double) this.velocity.X < 3.0 && (int) this.direction == 1)
        {
          if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X < 0.0)
            this.velocity.X *= 0.99f;
          this.velocity.X += 0.07f;
          if ((double) this.velocity.X > 3.0)
            this.velocity.X = 3f;
        }
        else if ((double) this.velocity.X > -3.0 && (int) this.direction == -1)
        {
          if ((double) this.velocity.Y == 0.0 && (double) this.velocity.X > 0.0)
            this.velocity.X *= 0.99f;
          this.velocity.X -= 0.07f;
          if ((double) this.velocity.X < -3.0)
            this.velocity.X = -3f;
        }
      }
      else if ((int) this.type == 27 || (int) this.type == 77 || (int) this.type == 104)
      {
        if ((double) this.velocity.X < -2.0 || (double) this.velocity.X > 2.0)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.8f;
        }
        else if ((double) this.velocity.X < 2.0 && (int) this.direction == 1)
        {
          this.velocity.X += 0.07f;
          if ((double) this.velocity.X > 2.0)
            this.velocity.X = 2f;
        }
        else if ((double) this.velocity.X > -2.0 && (int) this.direction == -1)
        {
          this.velocity.X -= 0.07f;
          if ((double) this.velocity.X < -2.0)
            this.velocity.X = -2f;
        }
      }
      else if ((int) this.type == 109)
      {
        if ((double) this.velocity.X < -2.0 || (double) this.velocity.X > 2.0)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.8f;
        }
        else if ((double) this.velocity.X < 2.0 && (int) this.direction == 1)
        {
          this.velocity.X += 0.04f;
          if ((double) this.velocity.X > 2.0)
            this.velocity.X = 2f;
        }
        else if ((double) this.velocity.X > -2.0 && (int) this.direction == -1)
        {
          this.velocity.X -= 0.04f;
          if ((double) this.velocity.X < -2.0)
            this.velocity.X = -2f;
        }
      }
      else if ((int) this.type == 21 || (int) this.type == 26 || ((int) this.type == 31 || (int) this.type == 47) || ((int) this.type == 73 || (int) this.type == 140))
      {
        if ((double) this.velocity.X < -1.5 || (double) this.velocity.X > 1.5)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.8f;
        }
        else if ((double) this.velocity.X < 1.5 && (int) this.direction == 1)
        {
          this.velocity.X += 0.07f;
          if ((double) this.velocity.X > 1.5)
            this.velocity.X = 1.5f;
        }
        else if ((double) this.velocity.X > -1.5 && (int) this.direction == -1)
        {
          this.velocity.X -= 0.07f;
          if ((double) this.velocity.X < -1.5)
            this.velocity.X = -1.5f;
        }
      }
      else if ((int) this.type == 67)
      {
        if ((double) this.velocity.X < -0.5 || (double) this.velocity.X > 0.5)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.7f;
        }
        else if ((double) this.velocity.X < 0.5 && (int) this.direction == 1)
        {
          this.velocity.X += 0.03f;
          if ((double) this.velocity.X > 0.5)
            this.velocity.X = 0.5f;
        }
        else if ((double) this.velocity.X > -0.5 && (int) this.direction == -1)
        {
          this.velocity.X -= 0.03f;
          if ((double) this.velocity.X < -0.5)
            this.velocity.X = -0.5f;
        }
      }
      else if ((int) this.type == 78 || (int) this.type == 79 || ((int) this.type == 80 || (int) this.type == 152) || (int) this.type == 155)
      {
        float num2 = 1f;
        float num3 = 0.05f;
        if (this.life < this.lifeMax >> 1)
        {
          num2 = 2f;
          num3 = 0.1f;
        }
        if ((int) this.type == 79 || (int) this.type == 152)
          num2 *= 1.5f;
        if ((double) this.velocity.X < -(double) num2 || (double) this.velocity.X > (double) num2)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.7f;
        }
        else if ((double) this.velocity.X < (double) num2 && (int) this.direction == 1)
        {
          this.velocity.X += num3;
          if ((double) this.velocity.X > (double) num2)
            this.velocity.X = num2;
        }
        else if ((double) this.velocity.X > -(double) num2 && (int) this.direction == -1)
        {
          this.velocity.X -= num3;
          if ((double) this.velocity.X < -(double) num2)
            this.velocity.X = -num2;
        }
      }
      else if ((int) this.type != 110 && (int) this.type != 111)
      {
        if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.8f;
        }
        else if ((double) this.velocity.X < 1.0 && (int) this.direction == 1)
        {
          this.velocity.X += 0.07f;
          if ((double) this.velocity.X > 1.0)
            this.velocity.X = 1f;
        }
        else if ((double) this.velocity.X > -1.0 && (int) this.direction == -1)
        {
          this.velocity.X -= 0.07f;
          if ((double) this.velocity.X < -1.0)
            this.velocity.X = -1f;
        }
      }
      if ((int) this.type == 110 || (int) this.type == 111)
      {
        if (this.confused)
        {
          this.ai2 = 0.0f;
        }
        else
        {
          if ((double) this.ai1 > 0.0)
            --this.ai1;
          if (this.justHit)
          {
            this.ai1 = 30f;
            this.ai2 = 0.0f;
          }
          int num2 = (int) this.type == 111 ? 180 : 70;
          if ((double) this.ai2 > 0.0)
          {
            this.TargetClosest(true);
            if ((double) this.ai1 == (double) (num2 >> 1))
            {
              float num3 = 11f;
              int Damage = 35;
              int Type = 82;
              if ((int) this.type == 111)
              {
                num3 = 9f;
                Damage = 11;
                Type = 81;
              }
              Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              float num4 = Main.player[(int) this.target].position.X + 10f - vector2.X;
              float num5 = Math.Abs(num4) * 0.1f;
              float num6 = Main.player[(int) this.target].position.Y + 21f - vector2.Y - num5;
              float num7 = num4 + (float) Main.rand.Next(-40, 41);
              float num8 = num6 + (float) Main.rand.Next(-40, 41);
              float num9 = (float) Math.Sqrt((double) num7 * (double) num7 + (double) num8 * (double) num8);
              this.netUpdate = true;
              float num10 = num3 / num9;
              float SpeedX = num7 * num10;
              float SpeedY = num8 * num10;
              vector2.X += SpeedX;
              vector2.Y += SpeedY;
              if (Main.netMode != 1)
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, 8, true);
              this.ai2 = (double) Math.Abs(SpeedY) <= (double) Math.Abs(SpeedX) * 2.0 ? ((double) Math.Abs(SpeedX) <= (double) Math.Abs(SpeedY) * 2.0 ? ((double) SpeedY <= 0.0 ? 4f : 2f) : 3f) : ((double) SpeedY <= 0.0 ? 5f : 1f);
            }
            if ((double) this.velocity.Y != 0.0 || (double) this.ai1 <= 0.0)
            {
              this.ai1 = 0.0f;
              this.ai2 = 0.0f;
            }
            else
            {
              this.velocity.X *= 0.9f;
              this.spriteDirection = this.direction;
            }
          }
          if ((double) this.ai2 <= 0.0 && (double) this.velocity.Y == 0.0 && ((double) this.ai1 <= 0.0 && !Main.player[(int) this.target].dead) && Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
          {
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num3 = Main.player[(int) this.target].position.X + 10f - vector2.X;
            float num4 = Math.Abs(num3) * 0.1f;
            float num5 = Main.player[(int) this.target].position.Y + 21f - vector2.Y - num4;
            float num6 = num3 + (float) Main.rand.Next(-40, 41);
            float num7 = num5 + (float) Main.rand.Next(-40, 41);
            float num8 = (float) ((double) num6 * (double) num6 + (double) num7 * (double) num7);
            if ((double) num8 < 490000.0)
            {
              this.netUpdate = true;
              this.velocity.X *= 0.5f;
              float num9 = 10f / (float) Math.Sqrt((double) num8);
              float num10 = num6 * num9;
              float num11 = num7 * num9;
              this.ai2 = 3f;
              this.ai1 = (float) num2;
              this.ai2 = (double) Math.Abs(num11) <= (double) Math.Abs(num10) * 2.0 ? ((double) Math.Abs(num10) <= (double) Math.Abs(num11) * 2.0 ? ((double) num11 <= 0.0 ? 4f : 2f) : 3f) : ((double) num11 <= 0.0 ? 5f : 1f);
            }
          }
          if ((double) this.ai2 <= 0.0)
          {
            if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
            {
              if ((double) this.velocity.Y == 0.0)
                this.velocity.X *= 0.8f;
            }
            else if ((double) this.velocity.X < 1.0 && (int) this.direction == 1)
            {
              this.velocity.X += 0.07f;
              if ((double) this.velocity.X > 1.0)
                this.velocity.X = 1f;
            }
            else if ((double) this.velocity.X > -1.0 && (int) this.direction == -1)
            {
              this.velocity.X -= 0.07f;
              if ((double) this.velocity.X < -1.0)
                this.velocity.X = -1f;
            }
          }
        }
      }
      else if ((int) this.type == 109 && Main.netMode != 1 && !Main.player[(int) this.target].dead)
      {
        if (this.justHit)
          this.ai2 = 0.0f;
        ++this.ai2;
        if ((double) this.ai2 > 450.0)
        {
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f - (float) ((int) this.direction * 24), this.position.Y + 4f);
          int num2 = 3 * (int) this.direction;
          int num3 = -5;
          int index = Projectile.NewProjectile(vector2.X, vector2.Y, (float) num2, (float) num3, 75, 0, 0.0f, 8, true);
          if (index >= 0)
            Main.projectile[index].timeLeft = 300;
          this.ai2 = 0.0f;
        }
      }
      bool flag3 = false;
      if ((double) this.velocity.Y == 0.0)
      {
        int index1 = this.aabb.Y + (int) this.height + 8 >> 4;
        int num2 = this.aabb.X >> 4;
        int num3 = this.aabb.X + (int) this.width >> 4;
        for (int index2 = num2; index2 <= num3; ++index2)
        {
          if ((int) Main.tile[index2, index1].active != 0 && Main.tileSolid[(int) Main.tile[index2, index1].type])
          {
            flag3 = true;
            break;
          }
        }
      }
      if (flag3)
      {
        int index1 = this.aabb.Y + (int) this.height - 15 >> 4;
        int index2 = ((int) this.type != 109 ? this.aabb.X + ((int) this.width >> 1) + 15 * (int) this.direction : this.aabb.X + ((int) this.width >> 1) + (((int) this.width >> 1) + 16) * (int) this.direction) >> 4;
        if (flag2 && (int) Main.tile[index2, index1 - 1].type == 10 && (int) Main.tile[index2, index1 - 1].active != 0)
        {
          ++this.ai2;
          this.ai3 = 0.0f;
          if ((double) this.ai2 >= 60.0)
          {
            if (!Main.gameTime.bloodMoon && ((int) this.type == 3 || (int) this.type == 132))
              this.ai1 = 0.0f;
            this.velocity.X = -0.5f * (float) this.direction;
            ++this.ai1;
            if ((int) this.type == 27)
              ++this.ai1;
            else if ((int) this.type == 31)
              this.ai1 += 6f;
            this.ai2 = 0.0f;
            bool flag4 = false;
            if ((double) this.ai1 >= 10.0)
            {
              flag4 = true;
              this.ai1 = 10f;
            }
            WorldGen.KillTile(index2, index1 - 1, true, false, false);
            if ((Main.netMode != 1 || !flag4) && (flag4 && Main.netMode != 1))
            {
              if ((int) this.type == 26)
              {
                WorldGen.KillTile(index2, index1 - 1);
                NetMessage.CreateMessage5(17, 0, index2, index1 - 1, 0, 0);
                NetMessage.SendMessage();
              }
              else
              {
                int number3 = WorldGen.OpenDoor(index2, index1, (int) this.direction);
                if (number3 != 0)
                {
                  NetMessage.CreateMessage3(19, index2, index1, number3);
                  NetMessage.SendMessage();
                }
                else
                {
                  this.ai3 = (float) num1;
                  this.netUpdate = true;
                }
              }
            }
          }
        }
        else
        {
          if ((double) this.velocity.X < 0.0 && (int) this.spriteDirection == -1 || (double) this.velocity.X > 0.0 && (int) this.spriteDirection == 1)
          {
            if ((int) Main.tile[index2, index1 - 2].active != 0 && Main.tileSolid[(int) Main.tile[index2, index1 - 2].type])
            {
              this.velocity.Y = (int) Main.tile[index2, index1 - 3].active == 0 || !Main.tileSolid[(int) Main.tile[index2, index1 - 3].type] ? -7f : -8f;
              this.netUpdate = true;
            }
            else if ((int) Main.tile[index2, index1 - 1].active != 0 && Main.tileSolid[(int) Main.tile[index2, index1 - 1].type])
            {
              this.velocity.Y = -6f;
              this.netUpdate = true;
            }
            else if ((int) Main.tile[index2, index1].active != 0 && Main.tileSolid[(int) Main.tile[index2, index1].type])
            {
              this.velocity.Y = -5f;
              this.netUpdate = true;
            }
            else if ((int) this.directionY < 0 && (int) this.type != 67 && ((int) Main.tile[index2, index1 + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index2, index1 + 1].type]) && ((int) Main.tile[index2 + (int) this.direction, index1 + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index2 + (int) this.direction, index1 + 1].type]))
            {
              this.velocity.Y = -8f;
              this.velocity.X *= 1.5f;
              this.netUpdate = true;
            }
            else if (flag2)
            {
              this.ai1 = 0.0f;
              this.ai2 = 0.0f;
            }
          }
          if ((int) this.type == 31 || (int) this.type == 47 || ((int) this.type == 77 || (int) this.type == 104))
          {
            if ((double) this.velocity.Y == 0.0 && (double) Math.Abs((float) ((double) this.position.X + (double) ((int) this.width >> 1) - ((double) Main.player[(int) this.target].position.X + 10.0))) < 100.0 && (double) Math.Abs((float) ((double) this.position.Y + (double) ((int) this.height >> 1) - ((double) Main.player[(int) this.target].position.Y + 21.0))) < 50.0 && ((int) this.direction > 0 && (double) this.velocity.X >= 1.0 || (int) this.direction < 0 && (double) this.velocity.X <= -1.0))
            {
              this.velocity.X *= 2f;
              if ((double) this.velocity.X > 3.0)
                this.velocity.X = 3f;
              if ((double) this.velocity.X < -3.0)
                this.velocity.X = -3f;
              this.velocity.Y = -4f;
              this.netUpdate = true;
            }
          }
          else if (((int) this.type == 120 || (int) this.type == 154) && (double) this.velocity.Y < 0.0)
            this.velocity.Y *= 1.1f;
        }
      }
      else if (flag2)
      {
        this.ai1 = 0.0f;
        this.ai2 = 0.0f;
      }
      if ((int) this.type != 120 && (int) this.type != 154 || (Main.netMode == 1 || (double) this.ai3 < (double) num1))
        return;
      int num12 = Main.player[(int) this.target].aabb.X >> 4;
      int num13 = Main.player[(int) this.target].aabb.Y >> 4;
      int num14 = this.aabb.X >> 4;
      int num15 = this.aabb.Y >> 4;
      if (Math.Abs(this.aabb.X - Main.player[(int) this.target].aabb.X) + Math.Abs(this.aabb.Y - Main.player[(int) this.target].aabb.Y) > 2000)
        return;
      int num16 = 0;
      do
      {
        int index1 = Main.rand.Next(num12 - 20, num12 + 20);
        for (int index2 = Main.rand.Next(num13 - 20, num13 + 20); index2 < num13 + 20; ++index2)
        {
          if ((index2 < num13 - 4 || index2 > num13 + 4 || (index1 < num12 - 4 || index1 > num12 + 4)) && (index2 < num15 - 1 || index2 > num15 + 1 || (index1 < num14 - 1 || index1 > num14 + 1)) && ((int) Main.tile[index1, index2].active != 0 && ((int) this.type != 32 || (int) Main.tile[index1, index2 - 1].wall != 0) && ((int) Main.tile[index1, index2 - 1].lava == 0 && Main.tileSolid[(int) Main.tile[index1, index2].type] && !Collision.SolidTiles(index1 - 1, index1 + 1, index2 - 4, index2 - 1))))
          {
            this.position.X = (float) (this.aabb.X = index1 * 16 - ((int) this.width >> 1));
            this.position.Y = (float) (this.aabb.Y = index2 * 16 - (int) this.height);
            this.netUpdate = true;
            this.ai3 = -120f;
            num16 = 32;
            break;
          }
        }
      }
      while (++num16 < 32);
    }

    private unsafe void EyeOfCthulhuAI()
    {
      if ((int) this.target == 8 || Main.player[(int) this.target].dead || (int) Main.player[(int) this.target].active == 0)
        this.TargetClosest(true);
      bool flag = Main.player[(int) this.target].dead;
      float num1 = (float) ((double) this.position.X + (double) ((int) this.width >> 1) - (double) Main.player[(int) this.target].position.X - 10.0);
      float num2 = (float) Math.Atan2((double) this.position.Y + (double) this.height - 59.0 - (double) Main.player[(int) this.target].position.Y - 21.0, (double) num1) + 1.57f;
      if ((double) num2 < 0.0)
        num2 += 6.283f;
      else if ((double) num2 > 6.28299999237061)
        num2 -= 6.283f;
      float num3 = 0.0f;
      if ((double) this.ai0 == 0.0 && (double) this.ai1 == 0.0)
        num3 = 0.02f;
      if ((double) this.ai0 == 0.0 && (double) this.ai1 == 2.0 && (double) this.ai2 > 40.0)
        num3 = 0.05f;
      if ((double) this.ai0 == 3.0 && (double) this.ai1 == 0.0)
        num3 = 0.05f;
      if ((double) this.ai0 == 3.0 && (double) this.ai1 == 2.0 && (double) this.ai2 > 40.0)
        num3 = 0.08f;
      if ((double) this.rotation < (double) num2)
      {
        if ((double) num2 - (double) this.rotation > 3.1415)
          this.rotation -= num3;
        else
          this.rotation += num3;
      }
      else if ((double) this.rotation > (double) num2)
      {
        if ((double) this.rotation - (double) num2 > 3.1415)
          this.rotation += num3;
        else
          this.rotation -= num3;
      }
      if ((double) this.rotation > (double) num2 - (double) num3 && (double) this.rotation < (double) num2 + (double) num3)
        this.rotation = num2;
      if ((double) this.rotation < 0.0)
        this.rotation += 6.283f;
      else if ((double) this.rotation > 6.28299999237061)
        this.rotation -= 6.283f;
      if ((double) this.rotation > (double) num2 - (double) num3 && (double) this.rotation < (double) num2 + (double) num3)
        this.rotation = num2;
      if (Main.rand.Next(6) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 5, (double) this.velocity.X, 2.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.5f;
          dustPtr->velocity.Y *= 0.1f;
        }
      }
      if (Main.gameTime.dayTime || flag)
      {
        this.velocity.Y -= 0.04f;
        if (this.timeLeft <= 10)
          return;
        this.timeLeft = 10;
      }
      else if ((double) this.ai0 == 0.0)
      {
        if ((double) this.ai1 == 0.0)
        {
          float num4 = 5f;
          float num5 = 0.04f;
          Vector2 vector2_1 = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
          float num6 = Main.player[(int) this.target].position.X + 10f - vector2_1.X;
          float num7 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 200.0) - vector2_1.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num8;
          float num10 = num4 / num8;
          float num11 = num6 * num10;
          float num12 = num7 * num10;
          if ((double) this.velocity.X < (double) num11)
          {
            this.velocity.X += num5;
            if ((double) this.velocity.X < 0.0 && (double) num11 > 0.0)
              this.velocity.X += num5;
          }
          else if ((double) this.velocity.X > (double) num11)
          {
            this.velocity.X -= num5;
            if ((double) this.velocity.X > 0.0 && (double) num11 < 0.0)
              this.velocity.X -= num5;
          }
          if ((double) this.velocity.Y < (double) num12)
          {
            this.velocity.Y += num5;
            if ((double) this.velocity.Y < 0.0 && (double) num12 > 0.0)
              this.velocity.Y += num5;
          }
          else if ((double) this.velocity.Y > (double) num12)
          {
            this.velocity.Y -= num5;
            if ((double) this.velocity.Y > 0.0 && (double) num12 < 0.0)
              this.velocity.Y -= num5;
          }
          ++this.ai2;
          if ((double) this.ai2 >= 600.0)
          {
            this.ai1 = 1f;
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.target = (byte) 8;
            this.netUpdate = true;
          }
          else if (this.aabb.Y + (int) this.height < Main.player[(int) this.target].aabb.Y && (double) num9 < 500.0)
          {
            if (!Main.player[(int) this.target].dead)
              ++this.ai3;
            if ((double) this.ai3 >= 110.0)
            {
              this.ai3 = 0.0f;
              this.rotation = num2;
              float num13 = Main.player[(int) this.target].position.X + 10f - vector2_1.X;
              float num14 = Main.player[(int) this.target].position.Y + 21f - vector2_1.Y;
              float num15 = 5f / (float) Math.Sqrt((double) num13 * (double) num13 + (double) num14 * (double) num14);
              Vector2 vector2_2 = vector2_1;
              Vector2 vector2_3;
              vector2_3.X = num13 * num15;
              vector2_3.Y = num14 * num15;
              vector2_2.X += vector2_3.X * 10f;
              vector2_2.Y += vector2_3.Y * 10f;
              if (Main.netMode != 1)
              {
                int number = NPC.NewNPC((int) vector2_2.X, (int) vector2_2.Y, 5, 0);
                if (number < 196)
                {
                  Main.npc[number].velocity.X = vector2_3.X;
                  Main.npc[number].velocity.Y = vector2_3.Y;
                  NetMessage.CreateMessage1(23, number);
                  NetMessage.SendMessage();
                }
              }
              Main.PlaySound(3, (int) vector2_2.X, (int) vector2_2.Y, 1);
              int num16 = 0;
              while (num16 < 8 && IntPtr.Zero != (IntPtr) Main.dust.NewDust((int) vector2_2.X, (int) vector2_2.Y, 20, 20, 5, (double) vector2_3.X * 0.400000005960464, (double) vector2_3.Y * 0.400000005960464, 0, new Color(), 1.0))
                ++num16;
            }
          }
        }
        else if ((double) this.ai1 == 1.0)
        {
          this.rotation = num2;
          float num4 = 6f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num5 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num6 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
          float num8 = num4 / num7;
          this.velocity.X = num5 * num8;
          this.velocity.Y = num6 * num8;
          this.ai1 = 2f;
        }
        else if ((double) this.ai1 == 2.0)
        {
          ++this.ai2;
          if ((double) this.ai2 >= 40.0)
          {
            this.velocity.X *= 0.98f;
            this.velocity.Y *= 0.98f;
            if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
              this.velocity.X = 0.0f;
            if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
              this.velocity.Y = 0.0f;
          }
          else
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
          if ((double) this.ai2 >= 150.0)
          {
            ++this.ai3;
            this.ai2 = 0.0f;
            this.target = (byte) 8;
            this.rotation = num2;
            if ((double) this.ai3 >= 3.0)
            {
              this.ai1 = 0.0f;
              this.ai3 = 0.0f;
            }
            else
              this.ai1 = 1f;
          }
        }
        if (this.life >= this.lifeMax >> 1)
          return;
        this.ai0 = 1f;
        this.ai1 = 0.0f;
        this.ai2 = 0.0f;
        this.ai3 = 0.0f;
        this.netUpdate = true;
      }
      else if ((double) this.ai0 == 1.0 || (double) this.ai0 == 2.0)
      {
        if ((double) this.ai0 == 1.0)
        {
          this.ai2 += 0.005f;
          if ((double) this.ai2 > 0.5)
            this.ai2 = 0.5f;
        }
        else
        {
          this.ai2 -= 0.005f;
          if ((double) this.ai2 < 0.0)
            this.ai2 = 0.0f;
        }
        this.rotation += this.ai2;
        ++this.ai1;
        if ((double) this.ai1 == 100.0)
        {
          ++this.ai0;
          this.ai1 = 0.0f;
          if ((double) this.ai0 == 3.0)
          {
            this.ai2 = 0.0f;
          }
          else
          {
            Main.PlaySound(3, this.aabb.X, this.aabb.Y, 1);
            Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
            for (int index = 0; index < 2; ++index)
            {
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 8, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 6, 1.0);
            }
            int num4 = 0;
            while (num4 < 16 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.2, (double) Main.rand.Next(-30, 31) * 0.2, 0, new Color(), 1.0))
              ++num4;
          }
        }
        Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.2, (double) Main.rand.Next(-30, 31) * 0.2, 0, new Color(), 1.0);
        this.velocity.X *= 0.98f;
        this.velocity.Y *= 0.98f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        if ((double) this.velocity.Y <= -0.1 || (double) this.velocity.Y >= 0.1)
          return;
        this.velocity.Y = 0.0f;
      }
      else
      {
        this.damage = 23;
        this.defense = 0;
        if ((double) this.ai1 == 0.0)
        {
          float num4 = 6f;
          float num5 = 0.07f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num6 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num7 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 120.0) - vector2.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num4 / num8;
          float num10 = num6 * num9;
          float num11 = num7 * num9;
          if ((double) this.velocity.X < (double) num10)
          {
            this.velocity.X += num5;
            if ((double) this.velocity.X < 0.0 && (double) num10 > 0.0)
              this.velocity.X += num5;
          }
          else if ((double) this.velocity.X > (double) num10)
          {
            this.velocity.X -= num5;
            if ((double) this.velocity.X > 0.0 && (double) num10 < 0.0)
              this.velocity.X -= num5;
          }
          if ((double) this.velocity.Y < (double) num11)
          {
            this.velocity.Y += num5;
            if ((double) this.velocity.Y < 0.0 && (double) num11 > 0.0)
              this.velocity.Y += num5;
          }
          else if ((double) this.velocity.Y > (double) num11)
          {
            this.velocity.Y -= num5;
            if ((double) this.velocity.Y > 0.0 && (double) num11 < 0.0)
              this.velocity.Y -= num5;
          }
          ++this.ai2;
          if ((double) this.ai2 < 200.0)
            return;
          this.ai1 = 1f;
          this.ai2 = 0.0f;
          this.ai3 = 0.0f;
          this.target = (byte) 8;
          this.netUpdate = true;
        }
        else if ((double) this.ai1 == 1.0)
        {
          Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
          this.rotation = num2;
          float num4 = 6.8f;
          Vector2 vector2 = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
          float num5 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num6 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
          float num8 = num4 / num7;
          this.velocity.X = num5 * num8;
          this.velocity.Y = num6 * num8;
          this.ai1 = 2f;
        }
        else
        {
          if ((double) this.ai1 != 2.0)
            return;
          ++this.ai2;
          if ((double) this.ai2 >= 40.0)
          {
            this.velocity.X *= 0.97f;
            this.velocity.Y *= 0.97f;
            if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
              this.velocity.X = 0.0f;
            if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
              this.velocity.Y = 0.0f;
          }
          else
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
          if ((double) this.ai2 < 130.0)
            return;
          ++this.ai3;
          this.ai2 = 0.0f;
          this.target = (byte) 8;
          this.rotation = num2;
          if ((double) this.ai3 >= 3.0)
          {
            this.ai1 = 0.0f;
            this.ai3 = 0.0f;
          }
          else
            this.ai1 = 1f;
        }
      }
    }

    private unsafe void AggressiveFlyerAI()
    {
      if ((int) this.target == 8 || Main.player[(int) this.target].dead)
        this.TargetClosest(true);
      byte num1 = this.type;
      float num2;
      float num3;
      if ((uint) num1 <= 42U)
      {
        switch (num1)
        {
          case (byte) 5:
            num2 = 5f;
            num3 = 0.03f;
            goto label_15;
          case (byte) 6:
            num2 = 4f;
            num3 = 0.02f;
            goto label_15;
          case (byte) 23:
            num2 = 1f;
            num3 = 0.03f;
            goto label_15;
          case (byte) 42:
            break;
          default:
            goto label_14;
        }
      }
      else if ((int) num1 != 94)
      {
        if ((int) num1 != 157)
        {
          if ((int) num1 == 167)
          {
            Lighting.addLight(this.aabb.X >> 4, this.aabb.Y >> 4, new Vector3(1f, 1f, 1f));
            num2 = 9f;
            num3 = 0.1f;
            goto label_15;
          }
          else
            goto label_14;
        }
      }
      else
      {
        num2 = 4.2f;
        num3 = 0.022f;
        goto label_15;
      }
      num2 = 3.5f;
      num3 = 0.021f;
      goto label_15;
label_14:
      num2 = 6f;
      num3 = 0.05f;
label_15:
      int num4 = this.aabb.X + ((int) this.width >> 1) & -8;
      int num5 = this.aabb.Y + ((int) this.height >> 1) & -8;
      float num6 = (float) ((Main.player[(int) this.target].aabb.X + 10 & -8) - num4);
      float num7 = (float) ((Main.player[(int) this.target].aabb.Y + 21 & -8) - num5);
      float num8 = (float) ((double) num6 * (double) num6 + (double) num7 * (double) num7);
      float num9 = num8;
      bool flag = false;
      float SpeedX1;
      float SpeedY1;
      if ((double) num8 == 0.0)
      {
        SpeedX1 = this.velocity.X;
        SpeedY1 = this.velocity.Y;
      }
      else
      {
        if ((double) num8 > 360000.0)
          flag = true;
        float num10 = num2 / (float) Math.Sqrt((double) num8);
        SpeedX1 = num6 * num10;
        SpeedY1 = num7 * num10;
      }
      if ((int) this.type == 6 || (int) this.type == 42 || ((int) this.type == 157 || (int) this.type == 94) || (int) this.type == 139)
      {
        if ((int) this.type == 42 || (int) this.type == 157 || ((int) this.type == 94 || (double) num9 > 10000.0))
        {
          ++this.ai0;
          if ((double) this.ai0 > 0.0)
            this.velocity.Y += 23.0 / 1000.0;
          else
            this.velocity.Y -= 23.0 / 1000.0;
          if ((double) this.ai0 < -100.0 || (double) this.ai0 > 100.0)
            this.velocity.X += 23.0 / 1000.0;
          else
            this.velocity.X -= 23.0 / 1000.0;
          if ((double) this.ai0 > 200.0)
            this.ai0 = -200f;
        }
        if (((int) this.type == 6 || (int) this.type == 94) && (double) num9 < 22500.0)
        {
          this.velocity.X += SpeedX1 * 0.007f;
          this.velocity.Y += SpeedY1 * 0.007f;
        }
      }
      if (Main.player[(int) this.target].dead)
      {
        SpeedX1 = (float) ((double) this.direction * (double) num2 * 0.5);
        SpeedY1 = num2 * -0.5f;
      }
      if ((double) this.velocity.X < (double) SpeedX1)
      {
        this.velocity.X += num3;
        if ((double) this.velocity.X < 0.0 && (double) SpeedX1 > 0.0 && ((int) this.type != 6 && (int) this.type != 42) && ((int) this.type != 157 && (int) this.type != 94 && (int) this.type != 139))
          this.velocity.X += num3;
      }
      else if ((double) this.velocity.X > (double) SpeedX1)
      {
        this.velocity.X -= num3;
        if ((double) this.velocity.X > 0.0 && (double) SpeedX1 < 0.0 && ((int) this.type != 6 && (int) this.type != 42) && ((int) this.type != 157 && (int) this.type != 94 && (int) this.type != 139))
          this.velocity.X -= num3;
      }
      if ((double) this.velocity.Y < (double) SpeedY1)
      {
        this.velocity.Y += num3;
        if ((double) this.velocity.Y < 0.0 && (double) SpeedY1 > 0.0 && ((int) this.type != 6 && (int) this.type != 42) && ((int) this.type != 157 && (int) this.type != 94 && (int) this.type != 139))
          this.velocity.Y += num3;
      }
      else if ((double) this.velocity.Y > (double) SpeedY1)
      {
        this.velocity.Y -= num3;
        if ((double) this.velocity.Y > 0.0 && (double) SpeedY1 < 0.0 && ((int) this.type != 6 && (int) this.type != 42) && ((int) this.type != 157 && (int) this.type != 94 && (int) this.type != 139))
          this.velocity.Y -= num3;
      }
      if ((int) this.type == 23)
      {
        if ((double) SpeedX1 > 0.0)
        {
          this.spriteDirection = (sbyte) 1;
          this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1);
        }
        else if ((double) SpeedX1 < 0.0)
        {
          this.spriteDirection = (sbyte) -1;
          this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1) + 3.14f;
        }
      }
      else if ((int) this.type == 139)
      {
        if (this.justHit)
          this.localAI0 = 0;
        else if (++this.localAI0 >= 120 && Main.netMode != 1)
        {
          this.localAI0 = 0;
          if (Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
          {
            int Damage = 25;
            int Type = 84;
            Projectile.NewProjectile((float) num4, (float) num5, SpeedX1, SpeedY1, Type, Damage, 0.0f, 8, true);
          }
        }
        if (!WorldGen.SolidTile(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4))
          Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, new Vector3(0.3f, 0.1f, 0.05f));
        if ((double) SpeedX1 > 0.0)
        {
          this.spriteDirection = (sbyte) 1;
          this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1);
        }
        if ((double) SpeedX1 < 0.0)
        {
          this.spriteDirection = (sbyte) -1;
          this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1) + 3.14f;
        }
      }
      else if ((int) this.type == 6 || (int) this.type == 94)
        this.rotation = (float) Math.Atan2((double) SpeedY1, (double) SpeedX1) - 1.57f;
      else if ((int) this.type == 42 || (int) this.type == 157)
      {
        if ((double) SpeedX1 > 0.0)
          this.spriteDirection = (sbyte) 1;
        else if ((double) SpeedX1 < 0.0)
          this.spriteDirection = (sbyte) -1;
        this.rotation = this.velocity.X * 0.1f;
      }
      else
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
      if ((int) this.type == 6 || (int) this.type == 23 || ((int) this.type == 42 || (int) this.type == 157) || ((int) this.type == 94 || (int) this.type == 139))
      {
        float num10 = 0.7f;
        if ((int) this.type == 6)
          num10 = 0.4f;
        if (this.collideX)
        {
          this.netUpdate = true;
          this.velocity.X = this.oldVelocity.X * -num10;
          if ((int) this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
            this.velocity.X = 2f;
          else if ((int) this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
            this.velocity.X = -2f;
        }
        if (this.collideY)
        {
          this.netUpdate = true;
          this.velocity.Y = this.oldVelocity.Y * -num10;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.5)
            this.velocity.Y = 2f;
          else if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.5)
            this.velocity.Y = -2f;
        }
        if ((int) this.type == 23)
        {
          Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X), (int) ((double) this.position.Y - (double) this.velocity.Y), (int) this.width, (int) this.height, 6, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->noGravity = true;
            dustPtr->velocity.X *= 0.3f;
            dustPtr->velocity.Y *= 0.3f;
          }
        }
        else if ((int) this.type != 42 && (int) this.type != 157 && ((int) this.type != 139 && Main.rand.Next(24) == 0))
        {
          Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 18, (double) this.velocity.X, 2.0, 75, this.color, (double) this.scale);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.5f;
            dustPtr->velocity.Y *= 0.1f;
          }
        }
      }
      else if (Main.rand.Next(48) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 5, (double) this.velocity.X, 2.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.5f;
          dustPtr->velocity.Y *= 0.1f;
        }
      }
      if ((int) this.type == 6 || (int) this.type == 94)
      {
        if (this.wet)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.95f;
          this.velocity.Y -= 0.3f;
          if ((double) this.velocity.Y < -2.0)
            this.velocity.Y = -2f;
        }
      }
      else if ((int) this.type == 42 || (int) this.type == 157)
      {
        if (this.wet)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.95f;
          this.velocity.Y -= 0.5f;
          if ((double) this.velocity.Y < -4.0)
            this.velocity.Y = -4f;
          this.TargetClosest(true);
        }
        if ((double) this.ai1 == 101.0)
        {
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 17);
          this.ai1 = 0.0f;
        }
        if (Main.netMode != 1)
        {
          this.ai1 += (float) Main.rand.Next(5, 20) * 0.1f * this.scale;
          if ((double) this.ai1 >= 130.0)
          {
            if (Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            {
              Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) ((int) this.height >> 1));
              float num10 = Main.player[(int) this.target].position.X + 10f - vector2.X + (float) Main.rand.Next(-20, 21);
              float num11 = Main.player[(int) this.target].position.Y + 21f - vector2.Y + (float) Main.rand.Next(-20, 21);
              if ((double) num10 < 0.0 && (double) this.velocity.X < 0.0 || (double) num10 > 0.0 && (double) this.velocity.X > 0.0)
              {
                float num12 = 8f / (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
                float SpeedX2 = num10 * num12;
                float SpeedY2 = num11 * num12;
                int Damage = (int) (13.0 * (double) this.scale);
                int Type = 55;
                int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX2, SpeedY2, Type, Damage, 0.0f, 8, true);
                if (index >= 0)
                  Main.projectile[index].timeLeft = 300;
                this.ai1 = 101f;
                this.netUpdate = true;
              }
              else
                this.ai1 = 0.0f;
            }
            else
              this.ai1 = 0.0f;
          }
        }
      }
      else if ((int) this.type == 139 && flag)
      {
        if ((double) this.velocity.X > 0.0 && (double) SpeedX1 > 0.0 || (double) this.velocity.X < 0.0 && (double) SpeedX1 < 0.0)
        {
          if ((double) Math.Abs(this.velocity.X) < 12.0)
            this.velocity.X *= 1.05f;
        }
        else
          this.velocity.X *= 0.9f;
      }
      if (Main.netMode != 1 && (int) this.type == 94 && !Main.player[(int) this.target].dead)
      {
        if (this.justHit)
          this.localAI0 = 0;
        ++this.localAI0;
        if (this.localAI0 == 180)
        {
          if (Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            NPC.NewNPC((int) ((double) this.position.X + (double) this.velocity.X) + ((int) this.width >> 1), (int) ((double) this.position.Y + (double) this.velocity.Y) + ((int) this.height >> 1), 112, 0);
          this.localAI0 = 0;
        }
      }
      if (Main.gameTime.dayTime && (int) this.type != 6 && ((int) this.type != 23 && (int) this.type != 42) && ((int) this.type != 157 && (int) this.type != 94) || Main.player[(int) this.target].dead)
      {
        this.velocity.Y -= num3 * 2f;
        if (this.timeLeft > 10)
          this.timeLeft = 10;
      }
      if (((double) this.velocity.X <= 0.0 || (double) this.oldVelocity.X >= 0.0) && ((double) this.velocity.X >= 0.0 || (double) this.oldVelocity.X <= 0.0) && (((double) this.velocity.Y <= 0.0 || (double) this.oldVelocity.Y >= 0.0) && ((double) this.velocity.Y >= 0.0 || (double) this.oldVelocity.Y <= 0.0)) || this.justHit)
        return;
      this.netUpdate = true;
    }

    private unsafe void WormAI()
    {
      if ((int) this.type == 117 && this.localAI1 == 0)
      {
        this.localAI1 = 1;
        Main.PlaySound(4, this.aabb.X, this.aabb.Y, 13);
        int num1 = 1;
        if ((double) this.velocity.X < 0.0)
          num1 = -1;
        int num2 = 0;
        while (num2 < 16 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(this.aabb.X - 20, this.aabb.Y - 20, (int) this.width + 40, (int) this.height + 40, 5, (double) (num1 * 8), -1.0, 0, new Color(), 1.0))
          ++num2;
      }
      if ((int) this.type >= 13 && (int) this.type <= 15)
        this.realLife = -1;
      else if ((double) this.ai3 > 0.0)
        this.realLife = (int) this.ai3;
      if ((int) this.target == 8 || Main.player[(int) this.target].dead)
        this.TargetClosest(true);
      if (Main.player[(int) this.target].dead && this.timeLeft > 300)
        this.timeLeft = 300;
      if (Main.netMode != 1)
      {
        if ((int) this.type == 87 || (int) this.type == 159)
        {
          if ((double) this.ai0 == 0.0)
          {
            this.ai3 = (float) this.whoAmI;
            this.realLife = (int) this.whoAmI;
            int index1 = (int) this.whoAmI;
            int num1 = (int) this.type - 87;
            for (int index2 = 0; index2 < 14; ++index2)
            {
              int num2 = 89;
              if (index2 == 1 || index2 == 8)
                num2 = 88;
              else if (index2 == 11)
                num2 = 90;
              else if (index2 == 12)
                num2 = 91;
              else if (index2 == 13)
                num2 = 92;
              int number = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, num2 + num1, (int) this.whoAmI);
              Main.npc[number].ai3 = (float) this.whoAmI;
              Main.npc[number].realLife = (int) this.whoAmI;
              Main.npc[number].ai1 = (float) index1;
              Main.npc[index1].ai0 = (float) number;
              NetMessage.CreateMessage1(23, number);
              NetMessage.SendMessage();
              index1 = number;
            }
          }
        }
        else if (((int) this.type == 7 || (int) this.type == 8 || ((int) this.type == 10 || (int) this.type == 11) || ((int) this.type == 13 || (int) this.type == 14 || ((int) this.type == 39 || (int) this.type == 40)) || ((int) this.type == 95 || (int) this.type == 96 || ((int) this.type == 98 || (int) this.type == 99) || ((int) this.type == 117 || (int) this.type == 118))) && (double) this.ai0 == 0.0)
        {
          if ((int) this.type == 7 || (int) this.type == 10 || ((int) this.type == 13 || (int) this.type == 39) || ((int) this.type == 95 || (int) this.type == 98 || (int) this.type == 117))
          {
            if ((int) this.type < 13 || (int) this.type > 15)
            {
              this.ai3 = (float) this.whoAmI;
              this.realLife = (int) this.whoAmI;
            }
            this.ai2 = (float) Main.rand.Next(8, 13);
            if ((int) this.type == 10)
              this.ai2 = (float) Main.rand.Next(4, 7);
            else if ((int) this.type == 13)
              this.ai2 = (float) Main.rand.Next(45, 56);
            else if ((int) this.type == 39)
              this.ai2 = (float) Main.rand.Next(12, 19);
            else if ((int) this.type == 95)
              this.ai2 = (float) Main.rand.Next(6, 12);
            else if ((int) this.type == 98)
              this.ai2 = (float) Main.rand.Next(20, 26);
            else if ((int) this.type == 117)
              this.ai2 = (float) Main.rand.Next(3, 6);
            this.ai0 = (float) NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, (int) this.type + 1, (int) this.whoAmI);
          }
          else
            this.ai0 = (int) this.type != 8 && (int) this.type != 11 && ((int) this.type != 14 && (int) this.type != 40) && ((int) this.type != 96 && (int) this.type != 99 && (int) this.type != 118) || (double) this.ai2 <= 0.0 ? (float) NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, (int) this.type + 1, (int) this.whoAmI) : (float) NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, (int) this.type, (int) this.whoAmI);
          if ((int) this.type < 13 || (int) this.type > 15)
          {
            Main.npc[(int) this.ai0].ai3 = this.ai3;
            Main.npc[(int) this.ai0].realLife = this.realLife;
          }
          Main.npc[(int) this.ai0].ai1 = (float) this.whoAmI;
          Main.npc[(int) this.ai0].ai2 = this.ai2 - 1f;
          this.netUpdate = true;
        }
        if (((int) this.type == 8 || (int) this.type == 9 || ((int) this.type == 11 || (int) this.type == 12) || ((int) this.type == 40 || (int) this.type == 41 || ((int) this.type == 96 || (int) this.type == 97)) || ((int) this.type == 99 || (int) this.type == 100 || (int) this.type > 87 && (int) this.type <= 92 || ((int) this.type > 159 && (int) this.type <= 164 || ((int) this.type == 118 || (int) this.type == 119)))) && ((int) Main.npc[(int) this.ai1].active == 0 || (int) Main.npc[(int) this.ai1].aiStyle != (int) this.aiStyle))
        {
          this.life = 0;
          this.HitEffect(0, 10.0);
          this.active = (byte) 0;
          if (Main.netMode != 2)
            return;
          NetMessage.SendNpcHurt((int) this.whoAmI, -1);
          return;
        }
        else if ((int) this.type == 7 || (int) this.type == 8 || ((int) this.type == 10 || (int) this.type == 11) || ((int) this.type == 39 || (int) this.type == 40 || ((int) this.type == 95 || (int) this.type == 96)) || ((int) this.type == 98 || (int) this.type == 99 || (int) this.type >= 87 && (int) this.type < 92 || ((int) this.type >= 159 && (int) this.type < 164 || ((int) this.type == 117 || (int) this.type == 118))))
        {
          if ((int) Main.npc[(int) this.ai0].active == 0 || (int) Main.npc[(int) this.ai0].aiStyle != (int) this.aiStyle)
          {
            this.life = 0;
            this.HitEffect(0, 10.0);
            this.active = (byte) 0;
            if (Main.netMode != 2)
              return;
            NetMessage.SendNpcHurt((int) this.whoAmI, -1);
            return;
          }
        }
        else if ((int) this.type >= 13 && (int) this.type <= 15)
        {
          if ((int) Main.npc[(int) this.ai1].active == 0 && (int) Main.npc[(int) this.ai0].active == 0 || (int) this.type == 13 && (int) Main.npc[(int) this.ai0].active == 0 || (int) this.type == 15 && (int) Main.npc[(int) this.ai1].active == 0)
          {
            this.life = 0;
            this.HitEffect(0, 10.0);
            this.active = (byte) 0;
          }
          if ((int) this.type == 14)
          {
            if ((int) Main.npc[(int) this.ai1].active == 0 || (int) Main.npc[(int) this.ai1].aiStyle != (int) this.aiStyle)
            {
              this.type = (byte) 13;
              int num1 = (int) this.whoAmI;
              float num2 = (float) this.life / (float) this.lifeMax;
              float num3 = this.ai0;
              this.SetDefaults((int) this.type, -1.0);
              this.life = (int) ((double) this.lifeMax * (double) num2);
              this.ai0 = num3;
              this.TargetClosest(true);
              this.netUpdate = true;
              this.whoAmI = (short) num1;
            }
            else if ((int) Main.npc[(int) this.ai0].active == 0 || (int) Main.npc[(int) this.ai0].aiStyle != (int) this.aiStyle)
            {
              int num1 = (int) this.whoAmI;
              float num2 = (float) this.life / (float) this.lifeMax;
              float num3 = this.ai1;
              this.SetDefaults((int) this.type, -1.0);
              this.life = (int) ((double) this.lifeMax * (double) num2);
              this.ai1 = num3;
              this.TargetClosest(true);
              this.netUpdate = true;
              this.whoAmI = (short) num1;
            }
          }
          if (this.life == 0)
          {
            bool flag = true;
            for (int index = 0; index < 196; ++index)
            {
              if ((int) Main.npc[index].type >= 13 && (int) Main.npc[index].type <= 15 && (int) Main.npc[index].active != 0)
              {
                flag = false;
                break;
              }
            }
            if (flag)
            {
              this.boss = true;
              this.NPCLoot();
            }
          }
          if ((int) this.active == 0)
          {
            NetMessage.SendNpcHurt((int) this.whoAmI, -1);
            return;
          }
        }
      }
      int num4 = (this.aabb.X >> 4) - 1;
      int num5 = (this.aabb.X + (int) this.width >> 4) + 2;
      int num6 = (this.aabb.Y >> 4) - 1;
      int num7 = (this.aabb.Y + (int) this.height >> 4) + 2;
      if (num4 < 0)
        num4 = 0;
      if (num5 > (int) Main.maxTilesX)
        num5 = (int) Main.maxTilesX;
      if (num6 < 0)
        num6 = 0;
      if (num7 > (int) Main.maxTilesY)
        num7 = (int) Main.maxTilesY;
      bool flag1 = (int) this.type >= 87 && (int) this.type <= 92 || (int) this.type >= 159 && (int) this.type <= 164;
      if (!flag1)
      {
        for (int i = num4; i < num5; ++i)
        {
          for (int j = num6; j < num7; ++j)
          {
            if (Main.tile[i, j].canStandOnTop() || (int) Main.tile[i, j].liquid > 64)
            {
              Vector2 vector2;
              vector2.X = (float) (i * 16);
              vector2.Y = (float) (j * 16);
              if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && ((double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0))
              {
                flag1 = true;
                if (Main.rand.Next(100) == 0 && (int) this.type != 117 && (int) Main.tile[i, j].active != 0)
                  WorldGen.KillTile(i, j, true, true, false);
              }
            }
          }
        }
      }
      if (!flag1 && ((int) this.type == 7 || (int) this.type == 10 || ((int) this.type == 13 || (int) this.type == 39) || ((int) this.type == 95 || (int) this.type == 98 || (int) this.type == 117)))
      {
        bool flag2 = true;
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0 && this.aabb.Intersects(new Rectangle(Main.player[index].aabb.X - 1000, Main.player[index].aabb.Y - 1000, 2000, 2000)))
          {
            flag2 = false;
            break;
          }
        }
        if (flag2)
          flag1 = true;
      }
      if ((int) this.type >= 87 && (int) this.type <= 92 || (int) this.type >= 159 && (int) this.type <= 164)
      {
        if ((double) this.velocity.X < 0.0)
          this.spriteDirection = (sbyte) 1;
        else if ((double) this.velocity.X > 0.0)
          this.spriteDirection = (sbyte) -1;
      }
      float num8 = 8f;
      float num9 = 0.07f;
      if ((int) this.type == 95)
      {
        num8 = 5.5f;
        num9 = 0.045f;
      }
      else if ((int) this.type == 10)
      {
        num8 = 6f;
        num9 = 0.05f;
      }
      else if ((int) this.type == 13)
      {
        num8 = 10f;
        num9 = 0.07f;
      }
      else if ((int) this.type == 87 || (int) this.type == 159)
      {
        num8 = 11f;
        num9 = 0.25f;
      }
      else if ((int) this.type == 117 && NPC.wof >= 0)
      {
        float num1 = (float) Main.npc[NPC.wof].life / (float) Main.npc[NPC.wof].lifeMax;
        if ((double) num1 < 0.5)
        {
          ++num8;
          num9 += 0.1f;
        }
        if ((double) num1 < 0.25)
        {
          ++num8;
          num9 += 0.1f;
        }
        if ((double) num1 < 0.1)
        {
          num8 += 2f;
          num9 += 0.1f;
        }
      }
      Vector2 vector2_1 = this.position;
      vector2_1.X += (float) ((int) this.width >> 1);
      vector2_1.Y += (float) ((int) this.height >> 1);
      if ((double) this.ai1 > 0.0 && (double) this.ai1 < 196.0)
      {
        vector2_1.X = this.position.X + (float) ((int) this.width >> 1);
        vector2_1.Y = this.position.Y + (float) ((int) this.height >> 1);
        float num1 = Main.npc[(int) this.ai1].position.X + (float) ((int) Main.npc[(int) this.ai1].width >> 1) - vector2_1.X;
        float num2 = Main.npc[(int) this.ai1].position.Y + (float) ((int) Main.npc[(int) this.ai1].height >> 1) - vector2_1.Y;
        this.rotation = (float) (Math.Atan2((double) num2, (double) num1) + Math.PI / 2.0);
        float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
        bool flag2 = (int) this.type >= 87 && (int) this.type <= 92 || (int) this.type >= 159 && (int) this.type <= 164;
        if ((double) num3 > 0.0)
        {
          float num10 = (float) Math.Sqrt((double) num3);
          float num11 = (num10 - (flag2 ? 30f : (float) this.width)) / num10;
          num1 *= num11;
          float num12 = num2 * num11;
          this.position.X += num1;
          this.position.Y += num12;
          this.aabb.X = (int) this.position.X;
          this.aabb.Y = (int) this.position.Y;
        }
        this.velocity.X = 0.0f;
        this.velocity.Y = 0.0f;
        if (!flag2)
          return;
        if ((double) num1 < 0.0)
        {
          this.spriteDirection = (sbyte) 1;
        }
        else
        {
          if ((double) num1 <= 0.0)
            return;
          this.spriteDirection = (sbyte) -1;
        }
      }
      else
      {
        float num1 = (float) (Main.player[(int) this.target].aabb.X + 10 & -16);
        float num2 = (float) (Main.player[(int) this.target].aabb.Y + 21 & -16);
        vector2_1.X = (float) ((int) vector2_1.X & -16);
        vector2_1.Y = (float) ((int) vector2_1.Y & -16);
        float num3 = num1 - vector2_1.X;
        float num10 = num2 - vector2_1.Y;
        if (!flag1)
        {
          this.TargetClosest(true);
          this.velocity.Y += 0.11f;
          if ((double) this.velocity.Y > (double) num8)
            this.velocity.Y = num8;
          if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num8 * 0.4)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X -= num9 * 1.1f;
            else
              this.velocity.X += num9 * 1.1f;
          }
          else if ((double) this.velocity.Y == (double) num8)
          {
            if ((double) this.velocity.X < (double) num3)
              this.velocity.X += num9;
            else if ((double) this.velocity.X > (double) num3)
              this.velocity.X -= num9;
          }
          else if ((double) this.velocity.Y > 4.0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X += num9 * 0.9f;
            else
              this.velocity.X -= num9 * 0.9f;
          }
        }
        else
        {
          float num11 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num10 * (double) num10);
          if ((int) this.soundDelay == 0 && (int) this.type != 87 && ((int) this.type != 159 && (int) this.type != 117))
          {
            int num12 = (int) ((double) num11 * 0.025000000372529);
            if (num12 < 10)
              num12 = 10;
            else if (num12 > 20)
              num12 = 20;
            this.soundDelay = (short) num12;
            Main.PlaySound(15, this.aabb.X, this.aabb.Y, 1);
          }
          float num13 = Math.Abs(num3);
          float num14 = Math.Abs(num10);
          float num15 = num8 / num11;
          float num16 = num3 * num15;
          float num17 = num10 * num15;
          if (((int) this.type == 7 || (int) this.type == 13) && !Main.player[(int) this.target].zoneEvil)
          {
            bool flag2 = true;
            for (int index = 0; index < 8; ++index)
            {
              if ((int) Main.player[index].active != 0 && !Main.player[index].dead && Main.player[index].zoneEvil)
              {
                flag2 = false;
                break;
              }
            }
            if (flag2)
            {
              if (Main.netMode != 1 && this.aabb.Y >> 4 > Main.rockLayer + (int) Main.maxTilesY >> 1)
              {
                this.active = (byte) 0;
                for (int number = (int) this.ai0; number > 0 && number < 196 && ((int) Main.npc[number].active != 0 && (int) Main.npc[number].aiStyle == (int) this.aiStyle); {
                  int num12;
                  number = num12;
                }
                )
                {
                  num12 = (int) Main.npc[number].ai0;
                  Main.npc[number].active = (byte) 0;
                  this.life = 0;
                  NetMessage.CreateMessage1(23, number);
                  NetMessage.SendMessage();
                }
                NetMessage.CreateMessage1(23, (int) this.whoAmI);
                NetMessage.SendMessage();
                return;
              }
              else
              {
                num16 = 0.0f;
                num17 = num8;
              }
            }
          }
          bool flag3 = false;
          if ((int) this.type == 87 || (int) this.type == 159)
          {
            if (((double) this.velocity.X > 0.0 && (double) num16 < 0.0 || (double) this.velocity.X < 0.0 && (double) num16 > 0.0 || ((double) this.velocity.Y > 0.0 && (double) num17 < 0.0 || (double) this.velocity.Y < 0.0 && (double) num17 > 0.0)) && ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > (double) num9 * 0.5 && (double) num11 < 300.0))
            {
              flag3 = true;
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num8)
              {
                this.velocity.X *= 1.1f;
                this.velocity.Y *= 1.1f;
              }
            }
            if (this.aabb.Y > Main.player[(int) this.target].aabb.Y || Main.player[(int) this.target].aabb.Y > Main.worldSurfacePixels || Main.player[(int) this.target].dead)
            {
              flag3 = true;
              if ((double) Math.Abs(this.velocity.X) < (double) num8 * 0.5)
              {
                if ((double) this.velocity.X == 0.0)
                  this.velocity.X -= (float) this.direction;
                this.velocity.X *= 1.1f;
              }
              else if ((double) this.velocity.Y > -(double) num8)
                this.velocity.Y -= num9;
            }
          }
          if (!flag3)
          {
            if ((double) this.velocity.X > 0.0 && (double) num16 > 0.0 || (double) this.velocity.X < 0.0 && (double) num16 < 0.0 || ((double) this.velocity.Y > 0.0 && (double) num17 > 0.0 || (double) this.velocity.Y < 0.0 && (double) num17 < 0.0))
            {
              if ((double) this.velocity.X < (double) num16)
                this.velocity.X += num9;
              else if ((double) this.velocity.X > (double) num16)
                this.velocity.X -= num9;
              if ((double) this.velocity.Y < (double) num17)
                this.velocity.Y += num9;
              else if ((double) this.velocity.Y > (double) num17)
                this.velocity.Y -= num9;
              if ((double) Math.Abs(num17) < (double) num8 * 0.2 && ((double) this.velocity.X > 0.0 && (double) num16 < 0.0 || (double) this.velocity.X < 0.0 && (double) num16 > 0.0))
              {
                if ((double) this.velocity.Y > 0.0)
                  this.velocity.Y += num9 * 2f;
                else
                  this.velocity.Y -= num9 * 2f;
              }
              if ((double) Math.Abs(num16) < (double) num8 * 0.2 && ((double) this.velocity.Y > 0.0 && (double) num17 < 0.0 || (double) this.velocity.Y < 0.0 && (double) num17 > 0.0))
              {
                if ((double) this.velocity.X > 0.0)
                  this.velocity.X += num9 * 2f;
                else
                  this.velocity.X -= num9 * 2f;
              }
            }
            else if ((double) num13 > (double) num14)
            {
              if ((double) this.velocity.X < (double) num16)
                this.velocity.X += num9 * 1.1f;
              else if ((double) this.velocity.X > (double) num16)
                this.velocity.X -= num9 * 1.1f;
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num8 * 0.5)
              {
                if ((double) this.velocity.Y > 0.0)
                  this.velocity.Y += num9;
                else
                  this.velocity.Y -= num9;
              }
            }
            else
            {
              if ((double) this.velocity.Y < (double) num17)
                this.velocity.Y += num9 * 1.1f;
              else if ((double) this.velocity.Y > (double) num17)
                this.velocity.Y -= num9 * 1.1f;
              if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num8 * 0.5)
              {
                if ((double) this.velocity.X > 0.0)
                  this.velocity.X += num9;
                else
                  this.velocity.X -= num9;
              }
            }
          }
        }
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
        if ((int) this.type != 7 && (int) this.type != 10 && ((int) this.type != 13 && (int) this.type != 39) && ((int) this.type != 95 && (int) this.type != 98 && (int) this.type != 117))
          return;
        if (flag1)
        {
          if (this.localAI0 != 1)
            this.netUpdate = true;
          this.localAI0 = 1;
        }
        else
        {
          if (this.localAI0 != 0)
            this.netUpdate = true;
          this.localAI0 = 0;
        }
        if (((double) this.velocity.X <= 0.0 || (double) this.oldVelocity.X >= 0.0) && ((double) this.velocity.X >= 0.0 || (double) this.oldVelocity.X <= 0.0) && (((double) this.velocity.Y <= 0.0 || (double) this.oldVelocity.Y >= 0.0) && ((double) this.velocity.Y >= 0.0 || (double) this.oldVelocity.Y <= 0.0)) || this.justHit)
          return;
        this.netUpdate = true;
      }
    }

    private void TownsfolkAI()
    {
      if ((int) this.type == 46)
      {
        if ((int) this.target == 8)
          this.TargetClosest(true);
      }
      else if ((int) this.type == 107)
        NPC.savedGoblin = true;
      else if ((int) this.type == 108)
        NPC.savedWizard = true;
      else if ((int) this.type == 124)
        NPC.savedMech = true;
      else if ((int) this.type == 142 && Main.netMode != 1 && !Time.xMas)
      {
        this.StrikeNPC(9999, 0.0f, 0, false, false);
        NetMessage.SendNpcHurt((int) this.whoAmI, 9999, 0.0, 0, false);
      }
      int index1 = this.aabb.X + ((int) this.width >> 1) >> 4;
      int index2 = this.aabb.Y + (int) this.height + 1 >> 4;
      bool flag1 = false;
      this.directionY = (sbyte) -1;
      this.direction |= (sbyte) 1;
      for (int index3 = 0; index3 < 8; ++index3)
      {
        if ((int) Main.player[index3].active != 0 && (int) Main.player[index3].talkNPC == (int) this.whoAmI)
        {
          flag1 = true;
          if ((double) this.ai0 != 0.0)
            this.netUpdate = true;
          this.ai0 = 0.0f;
          this.ai1 = 300f;
          this.ai2 = 100f;
          this.direction = Main.player[index3].aabb.X + 10 >= this.aabb.X + ((int) this.width >> 1) ? (sbyte) 1 : (sbyte) -1;
        }
      }
      if ((double) this.ai3 > 0.0 && (int) this.active != 0)
      {
        this.life = -1;
        this.HitEffect(0, 10.0);
        this.active = (byte) 0;
        if ((int) this.type == 37)
          Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
      }
      if ((int) this.type == 37 && Main.netMode != 1)
      {
        this.homeless = false;
        this.homeTileX = Main.dungeonX;
        this.homeTileY = Main.dungeonY;
        if (NPC.downedBoss3)
        {
          this.ai3 = 1f;
          this.netUpdate = true;
        }
      }
      int j = (int) this.homeTileY;
      if (Main.netMode != 1 && j > 0)
      {
        while (!WorldGen.SolidTile((int) this.homeTileX, j) && j < (int) Main.maxTilesY - 20)
          ++j;
      }
      if (Main.netMode != 1 && this.townNPC && !this.homeless && ((index1 != (int) this.homeTileX || index2 != j) && (!Main.gameTime.dayTime || Main.tileDungeon[(int) Main.tile[index1, index2].type])))
      {
        bool flag2 = true;
        Rectangle rectangle = new Rectangle();
        rectangle.X = this.aabb.X + ((int) this.width >> 1) - 960 - 62;
        rectangle.Y = this.aabb.Y + ((int) this.height >> 1) - 540 - 34;
        rectangle.Width = 2044;
        rectangle.Height = 1148;
        for (int index3 = 0; index3 < 8; ++index3)
        {
          if ((int) Main.player[index3].active != 0 && rectangle.Intersects(Main.player[index3].aabb))
          {
            flag2 = false;
            break;
          }
        }
        if (flag2)
        {
          rectangle.X = (int) this.homeTileX * 16 + 8 - 960 - 62;
          rectangle.Y = j * 16 + 8 - 540 - 34;
          for (int index3 = 0; index3 < 8; ++index3)
          {
            if ((int) Main.player[index3].active != 0 && rectangle.Intersects(Main.player[index3].aabb))
            {
              flag2 = false;
              break;
            }
          }
          if (flag2)
          {
            if ((int) this.type == 37 || !Collision.SolidTiles((int) this.homeTileX - 1, (int) this.homeTileX + 1, j - 3, j - 1))
            {
              this.velocity.X = 0.0f;
              this.velocity.Y = 0.0f;
              this.position.X = (float) (this.aabb.X = ((int) this.homeTileX << 4) + 8 - ((int) this.width >> 1));
              this.position.Y = (float) ((j << 4) - (int) this.height) - 0.1f;
              this.aabb.Y = (int) this.position.Y;
              this.netUpdate = true;
            }
            else
            {
              this.homeless = true;
              WorldGen.QuickFindHome((int) this.whoAmI);
            }
          }
        }
      }
      if ((double) this.ai0 == 0.0)
      {
        if ((double) this.ai2 > 0.0)
          --this.ai2;
        if (!Main.gameTime.dayTime && !flag1 && (int) this.type != 46)
        {
          if (Main.netMode != 1)
          {
            if (index1 == (int) this.homeTileX && index2 == j)
            {
              if ((double) this.velocity.X != 0.0)
                this.netUpdate = true;
              if ((double) this.velocity.X > 0.1)
                this.velocity.X -= 0.1f;
              else if ((double) this.velocity.X < -0.1)
                this.velocity.X += 0.1f;
              else
                this.velocity.X = 0.0f;
            }
            else if (!flag1)
            {
              this.direction = index1 <= (int) this.homeTileX ? (sbyte) 1 : (sbyte) -1;
              this.ai0 = 1f;
              this.ai1 = (float) (200 + Main.rand.Next(200));
              this.ai2 = 0.0f;
              this.netUpdate = true;
            }
          }
        }
        else
        {
          if ((double) this.velocity.X > 0.1)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X < -0.1)
            this.velocity.X += 0.1f;
          else
            this.velocity.X = 0.0f;
          if (Main.netMode != 1)
          {
            if ((double) this.ai1 > 0.0)
              --this.ai1;
            if ((double) this.ai1 <= 0.0)
            {
              this.ai0 = 1f;
              this.ai1 = (float) (200 + Main.rand.Next(200));
              if ((int) this.type == 46)
                this.ai1 += (float) Main.rand.Next(200, 400);
              this.ai2 = 0.0f;
              this.netUpdate = true;
            }
          }
        }
        if (Main.netMode == 1 || !Main.gameTime.dayTime && (index1 != (int) this.homeTileX || index2 != j))
          return;
        if (index1 < (int) this.homeTileX - 25 || index1 > (int) this.homeTileX + 25)
        {
          if ((double) this.ai2 != 0.0)
            return;
          if (index1 < (int) this.homeTileX - 50 && (int) this.direction == -1)
          {
            this.direction = (sbyte) 1;
            this.netUpdate = true;
          }
          else
          {
            if (index1 <= (int) this.homeTileX + 50 || (int) this.direction != 1)
              return;
            this.direction = (sbyte) -1;
            this.netUpdate = true;
          }
        }
        else
        {
          if (Main.rand.Next(80) != 0 || (double) this.ai2 != 0.0)
            return;
          this.ai2 = 200f;
          this.direction = -this.direction;
          this.netUpdate = true;
        }
      }
      else
      {
        if ((double) this.ai0 != 1.0)
          return;
        if (Main.netMode != 1 && !Main.gameTime.dayTime && (index1 == (int) this.homeTileX && index2 == (int) this.homeTileY) && (int) this.type != 46)
        {
          this.ai0 = 0.0f;
          this.ai1 = (float) (200 + Main.rand.Next(200));
          this.ai2 = 60f;
          this.netUpdate = true;
        }
        else
        {
          if (Main.netMode != 1 && !this.homeless && !Main.tileDungeon[(int) Main.tile[index1, index2].type] && (index1 < (int) this.homeTileX - 35 || index1 > (int) this.homeTileX + 35))
          {
            if (this.aabb.X < (int) this.homeTileX << 4 && (int) this.direction == -1)
              this.ai1 -= 5f;
            else if (this.aabb.X > (int) this.homeTileX << 4 && (int) this.direction == 1)
              this.ai1 -= 5f;
          }
          --this.ai1;
          if ((double) this.ai1 <= 0.0)
          {
            this.ai0 = 0.0f;
            this.ai1 = (float) (300 + Main.rand.Next(300));
            if ((int) this.type == 46)
              this.ai1 -= (float) Main.rand.Next(100);
            this.ai2 = 60f;
            this.netUpdate = true;
          }
          if (this.closeDoor)
          {
            int num1 = this.aabb.X + ((int) this.width >> 1) >> 4;
            if (num1 > (int) this.doorX + 2 || num1 < (int) this.doorX - 2)
            {
              if (WorldGen.CloseDoor((int) this.doorX, (int) this.doorY, false))
              {
                this.closeDoor = false;
                NetMessage.CreateMessage2(24, (int) this.doorX, (int) this.doorY);
                NetMessage.SendMessage();
              }
              else
              {
                int num2 = this.aabb.Y + ((int) this.height >> 1) >> 4;
                if (num1 > (int) this.doorX + 4 || num1 < (int) this.doorX - 4 || (num2 > (int) this.doorY + 4 || num2 < (int) this.doorY - 4))
                  this.closeDoor = false;
              }
            }
          }
          if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
          {
            if ((double) this.velocity.Y == 0.0)
              this.velocity.X *= 0.8f;
          }
          else if ((double) this.velocity.X < 1.15 && (int) this.direction == 1)
          {
            this.velocity.X += 0.07f;
            if ((double) this.velocity.X > 1.0)
              this.velocity.X = 1f;
          }
          else if ((double) this.velocity.X > -1.0 && (int) this.direction == -1)
          {
            this.velocity.X -= 0.07f;
            if ((double) this.velocity.X > 1.0)
              this.velocity.X = 1f;
          }
          if ((double) this.velocity.Y != 0.0)
            return;
          if ((double) this.position.X == (double) this.ai2)
            this.direction = -this.direction;
          this.ai2 = -1f;
          int index3 = this.aabb.X + ((int) this.width >> 1) + 15 * (int) this.direction >> 4;
          int index4 = this.aabb.Y + (int) this.height - 16 >> 4;
          if (this.townNPC && (int) Main.tile[index3, index4 - 2].active != 0 && (int) Main.tile[index3, index4 - 2].type == 10 && (Main.rand.Next(10) == 0 || !Main.gameTime.dayTime))
          {
            if (Main.netMode == 1)
              return;
            int number3 = WorldGen.OpenDoor(index3, index4 - 2, (int) this.direction);
            if (number3 != 0)
            {
              this.closeDoor = true;
              this.doorX = (short) index3;
              this.doorY = (short) (index4 - 2);
              NetMessage.CreateMessage3(19, index3, index4 - 2, number3);
              NetMessage.SendMessage();
              this.ai1 += 80f;
            }
            else
              this.direction = -this.direction;
            this.netUpdate = true;
          }
          else
          {
            if ((double) this.velocity.X < 0.0 && (int) this.spriteDirection == -1 || (double) this.velocity.X > 0.0 && (int) this.spriteDirection == 1)
            {
              if ((int) Main.tile[index3, index4 - 2].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index3, index4 - 2].type])
              {
                if ((int) this.direction == 1 && !Collision.SolidTiles(index3 - 2, index3 - 1, index4 - 5, index4 - 1) || (int) this.direction == -1 && !Collision.SolidTiles(index3 + 1, index3 + 2, index4 - 5, index4 - 1))
                {
                  if (!Collision.SolidTiles(index3, index3, index4 - 5, index4 - 3))
                    this.velocity.Y = -6f;
                  else
                    this.direction = -this.direction;
                }
                else
                  this.direction = -this.direction;
                this.netUpdate = true;
              }
              else if ((int) Main.tile[index3, index4 - 1].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index3, index4 - 1].type])
              {
                if ((int) this.direction == 1 && !Collision.SolidTiles(index3 - 2, index3 - 1, index4 - 4, index4 - 1) || (int) this.direction == -1 && !Collision.SolidTiles(index3 + 1, index3 + 2, index4 - 4, index4 - 1))
                {
                  if (!Collision.SolidTiles(index3, index3, index4 - 4, index4 - 2))
                    this.velocity.Y = -5f;
                  else
                    this.direction = -this.direction;
                }
                else
                  this.direction = -this.direction;
                this.netUpdate = true;
              }
              else if ((int) Main.tile[index3, index4].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index3, index4].type])
              {
                if ((int) this.direction == 1 && !Collision.SolidTiles(index3 - 2, index3, index4 - 3, index4 - 1) || (int) this.direction == -1 && !Collision.SolidTiles(index3, index3 + 2, index4 - 3, index4 - 1))
                  this.velocity.Y = -3.6f;
                else
                  this.direction = -this.direction;
                this.netUpdate = true;
              }
              if (index1 >= (int) this.homeTileX - 35 && index1 <= (int) this.homeTileX + 35 && ((int) Main.tile[index3, index4 + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index3, index4 + 1].type]) && (((int) Main.tile[index3 - (int) this.direction, index4 + 1].active == 0 || !Main.tileSolid[(int) Main.tile[index3 - (int) this.direction, index4 + 1].type]) && ((int) Main.tile[index3, index4 + 2].active == 0 || !Main.tileSolid[(int) Main.tile[index3, index4 + 2].type])) && (((int) Main.tile[index3 - (int) this.direction, index4 + 2].active == 0 || !Main.tileSolid[(int) Main.tile[index3 - (int) this.direction, index4 + 2].type]) && ((int) Main.tile[index3, index4 + 3].active == 0 || !Main.tileSolid[(int) Main.tile[index3, index4 + 3].type]) && (((int) Main.tile[index3 - (int) this.direction, index4 + 3].active == 0 || !Main.tileSolid[(int) Main.tile[index3 - (int) this.direction, index4 + 3].type]) && ((int) Main.tile[index3, index4 + 4].active == 0 || !Main.tileSolid[(int) Main.tile[index3, index4 + 4].type]))) && (((int) Main.tile[index3 - (int) this.direction, index4 + 4].active == 0 || !Main.tileSolid[(int) Main.tile[index3 - (int) this.direction, index4 + 4].type]) && (int) this.type != 46))
              {
                this.direction = -this.direction;
                this.velocity.X = -this.velocity.X;
                this.netUpdate = true;
              }
              if ((double) this.velocity.Y < 0.0)
                this.ai2 = this.position.X;
            }
            if ((double) this.velocity.Y >= 0.0)
              return;
            if (this.wet)
              this.velocity.Y *= 1.2f;
            if ((int) this.type != 46)
              return;
            this.velocity.Y *= 1.2f;
          }
        }
      }
    }

    private unsafe void SorcererAI()
    {
      this.TargetClosest(true);
      this.velocity.X *= 0.93f;
      if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
        this.velocity.X = 0.0f;
      if ((double) this.ai0 == 0.0)
        this.ai0 = 500f;
      if ((double) this.ai2 != 0.0 && (double) this.ai3 != 0.0)
      {
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 8);
        for (int index = 0; index < 42; ++index)
        {
          Dust* dustPtr;
          if ((int) this.type == 29 || (int) this.type == 45)
          {
            dustPtr = Main.dust.NewDust(27, ref this.aabb, 0.0, 0.0, 100, new Color(), (double) Main.rand.Next(1, 3));
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              if ((double) dustPtr->scale > 1.0)
                dustPtr->noGravity = true;
            }
            else
              break;
          }
          else if ((int) this.type == 32)
          {
            dustPtr = Main.dust.NewDust(29, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
              dustPtr->noGravity = true;
            else
              break;
          }
          else
          {
            dustPtr = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
              dustPtr->noGravity = true;
            else
              break;
          }
          dustPtr->velocity.X *= 3f;
          dustPtr->velocity.Y *= 3f;
        }
        this.position.X = (float) ((double) this.ai2 * 16.0 - (double) ((int) this.width >> 1) + 8.0);
        this.position.Y = this.ai3 * 16f - (float) this.height;
        this.aabb.X = (int) this.position.X;
        this.aabb.Y = (int) this.position.Y;
        this.velocity.X = 0.0f;
        this.velocity.Y = 0.0f;
        this.ai2 = 0.0f;
        this.ai3 = 0.0f;
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 8);
        for (int index = 0; index < 42; ++index)
        {
          Dust* dustPtr;
          if ((int) this.type == 29 || (int) this.type == 45)
          {
            dustPtr = Main.dust.NewDust(27, ref this.aabb, 0.0, 0.0, 100, new Color(), (double) Main.rand.Next(1, 3));
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              if ((double) dustPtr->scale > 1.0)
                dustPtr->noGravity = true;
            }
            else
              break;
          }
          else if ((int) this.type == 32)
          {
            dustPtr = Main.dust.NewDust(29, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
              dustPtr->noGravity = true;
            else
              break;
          }
          else
          {
            dustPtr = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
              dustPtr->noGravity = true;
            else
              break;
          }
          dustPtr->velocity.X *= 3f;
          dustPtr->velocity.Y *= 3f;
        }
      }
      ++this.ai0;
      if ((double) this.ai0 == 100.0 || (double) this.ai0 == 200.0 || (double) this.ai0 == 300.0)
      {
        this.ai1 = 30f;
        this.netUpdate = true;
      }
      else if ((double) this.ai0 >= 650.0 && Main.netMode != 1)
      {
        this.ai0 = 1f;
        int num1 = Main.player[(int) this.target].aabb.X >> 4;
        int num2 = Main.player[(int) this.target].aabb.Y >> 4;
        int num3 = this.aabb.X >> 4;
        int num4 = this.aabb.Y >> 4;
        int num5 = 20;
        int num6 = 0;
        bool flag1 = false;
        if (Math.Abs(this.aabb.X - Main.player[(int) this.target].aabb.X) + Math.Abs(this.aabb.Y - Main.player[(int) this.target].aabb.Y) > 2000)
        {
          num6 = 100;
          flag1 = true;
        }
        while (!flag1 && num6 < 100)
        {
          ++num6;
          int index1 = Main.rand.Next(num1 - num5, num1 + num5);
          for (int index2 = Main.rand.Next(num2 - num5, num2 + num5); index2 < num2 + num5; ++index2)
          {
            if ((index2 < num2 - 4 || index2 > num2 + 4 || (index1 < num1 - 4 || index1 > num1 + 4)) && (index2 < num4 - 1 || index2 > num4 + 1 || (index1 < num3 - 1 || index1 > num3 + 1)) && (int) Main.tile[index1, index2].active != 0)
            {
              bool flag2 = true;
              if ((int) this.type == 32 && (int) Main.tile[index1, index2 - 1].wall == 0)
                flag2 = false;
              else if ((int) Main.tile[index1, index2 - 1].lava != 0)
                flag2 = false;
              if (flag2 && Main.tileSolid[(int) Main.tile[index1, index2].type] && !Collision.SolidTiles(index1 - 1, index1 + 1, index2 - 4, index2 - 1))
              {
                this.ai1 = 20f;
                this.ai2 = (float) index1;
                this.ai3 = (float) index2;
                flag1 = true;
                break;
              }
            }
          }
        }
        this.netUpdate = true;
      }
      if ((double) this.ai1 > 0.0)
      {
        --this.ai1;
        if ((double) this.ai1 == 25.0)
        {
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 8);
          if (Main.netMode != 1)
          {
            if ((int) this.type == 29 || (int) this.type == 45)
              NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y - 8, 30, 0);
            else if ((int) this.type == 32)
              NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y - 8, 33, 0);
            else
              NPC.NewNPC(this.aabb.X + ((int) this.width >> 1) + (int) this.direction * 8, this.aabb.Y + 20, 25, 0);
          }
        }
      }
      if ((int) this.type == 29 || (int) this.type == 45)
      {
        if (Main.rand.Next(5) != 0)
          return;
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 27, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.5);
        if ((IntPtr) dustPtr == IntPtr.Zero)
          return;
        dustPtr->noGravity = true;
        dustPtr->velocity.X *= 0.5f;
        dustPtr->velocity.Y = -2f;
      }
      else if ((int) this.type == 32)
      {
        if (Main.rand.Next(2) != 0)
          return;
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 29, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
        if ((IntPtr) dustPtr == IntPtr.Zero)
          return;
        dustPtr->noGravity = true;
        dustPtr->velocity.X *= 1f;
        dustPtr->velocity.Y *= 1f;
      }
      else
      {
        if (Main.rand.Next(2) != 0)
          return;
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 6, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
        if ((IntPtr) dustPtr == IntPtr.Zero)
          return;
        dustPtr->noGravity = true;
        dustPtr->velocity.X *= 1f;
        dustPtr->velocity.Y *= 1f;
      }
    }

    private unsafe void SphereAI()
    {
      if ((int) this.target == 8)
      {
        this.TargetClosest(true);
        float num1 = 6f;
        if ((int) this.type == 25)
          num1 = 5f;
        if ((int) this.type == 112)
          num1 = 7f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num2 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num3 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
        float num5 = num1 / num4;
        this.velocity.X = num2 * num5;
        this.velocity.Y = num3 * num5;
      }
      if ((int) this.type == 112)
      {
        ++this.ai0;
        if ((double) this.ai0 > 3.0)
          this.ai0 = 3f;
        if ((double) this.ai0 == 2.0)
        {
          this.position.X += this.velocity.X;
          this.position.Y += this.velocity.Y;
          this.aabb.X = (int) this.position.X;
          this.aabb.Y = (int) this.position.Y;
          Main.PlaySound(4, this.aabb.X, this.aabb.Y, 9);
          for (int index = 0; index < 16; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 18, 0.0, 0.0, 100, new Color(), 1.79999995231628);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X *= 1.3f;
              dustPtr->velocity.Y *= 1.3f;
              dustPtr->velocity.X += this.velocity.X;
              dustPtr->velocity.Y += this.velocity.Y;
              dustPtr->noGravity = true;
            }
            else
              break;
          }
        }
        if (Collision.SolidCollision(ref this.position, (int) this.width, (int) this.height))
        {
          if (Main.netMode != 1)
          {
            int num1 = this.aabb.X + ((int) this.width >> 1) >> 4;
            int num2 = this.aabb.Y + ((int) this.height >> 1) >> 4;
            int num3 = 8;
            for (int index1 = num1 - num3; index1 <= num1 + num3; ++index1)
            {
              for (int index2 = num2 - num3; index2 < num2 + num3; ++index2)
              {
                if ((double) (Math.Abs(index1 - num1) + Math.Abs(index2 - num2)) < (double) num3 * 0.5)
                {
                  if ((int) Main.tile[index1, index2].type == 2)
                  {
                    Main.tile[index1, index2].type = (byte) 23;
                    WorldGen.SquareTileFrame(index1, index2, -1);
                    NetMessage.SendTile(index1, index2);
                  }
                  else if ((int) Main.tile[index1, index2].type == 1)
                  {
                    Main.tile[index1, index2].type = (byte) 25;
                    WorldGen.SquareTileFrame(index1, index2, -1);
                    NetMessage.SendTile(index1, index2);
                  }
                  else if ((int) Main.tile[index1, index2].type == 53)
                  {
                    Main.tile[index1, index2].type = (byte) 112;
                    WorldGen.SquareTileFrame(index1, index2, -1);
                    NetMessage.SendTile(index1, index2);
                  }
                  else if ((int) Main.tile[index1, index2].type == 109)
                  {
                    Main.tile[index1, index2].type = (byte) 23;
                    WorldGen.SquareTileFrame(index1, index2, -1);
                    NetMessage.SendTile(index1, index2);
                  }
                  else if ((int) Main.tile[index1, index2].type == 117)
                  {
                    Main.tile[index1, index2].type = (byte) 25;
                    WorldGen.SquareTileFrame(index1, index2, -1);
                    NetMessage.SendTile(index1, index2);
                  }
                  else if ((int) Main.tile[index1, index2].type == 116)
                  {
                    Main.tile[index1, index2].type = (byte) 112;
                    WorldGen.SquareTileFrame(index1, index2, -1);
                    NetMessage.SendTile(index1, index2);
                  }
                }
              }
            }
          }
          this.StrikeNPC(999, 0.0f, 0, false, false);
        }
      }
      if (this.timeLeft > 100)
        this.timeLeft = 100;
      for (int index = 0; index < 2; ++index)
      {
        Dust* dustPtr;
        if ((int) this.type == 30)
        {
          dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 27, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr == IntPtr.Zero)
            break;
        }
        else if ((int) this.type == 33)
        {
          dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 29, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr == IntPtr.Zero)
            break;
        }
        else if ((int) this.type == 112)
        {
          dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 18, (double) this.velocity.X * 0.100000001490116, (double) this.velocity.Y * 0.100000001490116, 80, new Color(), 1.29999995231628);
          if ((IntPtr) dustPtr == IntPtr.Zero)
            break;
        }
        else
        {
          Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, new Vector3(1f, 0.3f, 0.1f));
          dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 6, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
        }
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          dustPtr->velocity.X *= 0.3f;
          dustPtr->velocity.Y *= 0.3f;
          if ((int) this.type == 30)
          {
            dustPtr->velocity.X -= this.velocity.X * 0.2f;
            dustPtr->velocity.Y -= this.velocity.Y * 0.2f;
          }
        }
      }
      this.rotation += 0.4f * (float) this.direction;
    }

    private void SkullHeadAI()
    {
      float num1 = 1f;
      float num2 = 11.0 / 1000.0;
      this.TargetClosest(true);
      Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
      float num3 = Main.player[(int) this.target].position.X + 10f - vector2.X;
      float num4 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
      float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
      float num6 = num5;
      ++this.ai1;
      if ((double) this.ai1 > 600.0)
      {
        num2 *= 8f;
        num1 = 4f;
        if ((double) this.ai1 > 650.0)
          this.ai1 = 0.0f;
      }
      else if ((double) num6 < 250.0)
      {
        this.ai0 += 0.9f;
        if ((double) this.ai0 > 0.0)
          this.velocity.Y += 0.019f;
        else
          this.velocity.Y -= 0.019f;
        if ((double) this.ai0 < -100.0 || (double) this.ai0 > 100.0)
          this.velocity.X += 0.019f;
        else
          this.velocity.X -= 0.019f;
        if ((double) this.ai0 > 200.0)
          this.ai0 = -200f;
      }
      if ((double) num6 > 350.0)
      {
        num1 = 5f;
        num2 = 0.3f;
      }
      else if ((double) num6 > 300.0)
      {
        num1 = 3f;
        num2 = 0.2f;
      }
      else if ((double) num6 > 250.0)
      {
        num1 = 1.5f;
        num2 = 0.1f;
      }
      float num7 = num1 / num5;
      float num8 = num3 * num7;
      float num9 = num4 * num7;
      if (Main.player[(int) this.target].dead)
      {
        num8 = (float) ((double) this.direction * (double) num1 * 0.5);
        num9 = num1 * -0.5f;
      }
      if ((double) this.velocity.X < (double) num8)
        this.velocity.X += num2;
      else if ((double) this.velocity.X > (double) num8)
        this.velocity.X -= num2;
      if ((double) this.velocity.Y < (double) num9)
        this.velocity.Y += num2;
      else if ((double) this.velocity.Y > (double) num9)
        this.velocity.Y -= num2;
      if ((double) num8 > 0.0)
      {
        this.spriteDirection = (sbyte) -1;
        this.rotation = (float) Math.Atan2((double) num9, (double) num8);
      }
      else
      {
        if ((double) num8 >= 0.0)
          return;
        this.spriteDirection = (sbyte) 1;
        this.rotation = (float) Math.Atan2((double) num9, (double) num8) + 3.14f;
      }
    }

    private unsafe void SkeletronAI()
    {
      if ((double) this.ai0 == 0.0 && Main.netMode != 1)
      {
        this.TargetClosest(true);
        this.ai0 = 1f;
        if ((int) this.type != 68)
        {
          int index1 = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + ((int) this.height >> 1), 36, (int) this.whoAmI);
          Main.npc[index1].ai0 = -1f;
          Main.npc[index1].ai1 = (float) this.whoAmI;
          Main.npc[index1].target = this.target;
          Main.npc[index1].netUpdate = true;
          int index2 = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + ((int) this.height >> 1), 36, (int) this.whoAmI);
          Main.npc[index2].ai0 = 1f;
          Main.npc[index2].ai1 = (float) this.whoAmI;
          Main.npc[index2].ai3 = 150f;
          Main.npc[index2].target = this.target;
          Main.npc[index2].netUpdate = true;
        }
      }
      if ((int) this.type == 68 && (double) this.ai1 != 3.0 && (double) this.ai1 != 2.0)
      {
        Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
        this.ai1 = 2f;
      }
      if (Main.player[(int) this.target].dead || Math.Abs(this.aabb.X - Main.player[(int) this.target].aabb.X) > 2000 || Math.Abs(this.aabb.Y - Main.player[(int) this.target].aabb.Y) > 2000)
      {
        this.TargetClosest(true);
        if (Main.player[(int) this.target].dead || Math.Abs(this.aabb.X - Main.player[(int) this.target].aabb.X) > 2000 || Math.Abs(this.aabb.Y - Main.player[(int) this.target].aabb.Y) > 2000)
          this.ai1 = 3f;
      }
      if (Main.gameTime.dayTime && (double) this.ai1 != 3.0 && (double) this.ai1 != 2.0)
      {
        this.ai1 = 2f;
        Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
      }
      if ((double) this.ai1 == 0.0)
      {
        this.defense = 10;
        ++this.ai2;
        if ((double) this.ai2 >= 800.0)
        {
          this.ai2 = 0.0f;
          this.ai1 = 1f;
          this.TargetClosest(true);
          this.netUpdate = true;
        }
        this.rotation = this.velocity.X * 0.06666667f;
        if (this.aabb.Y > Main.player[(int) this.target].aabb.Y - 250)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.98f;
          this.velocity.Y -= 0.02f;
          if ((double) this.velocity.Y > 2.0)
            this.velocity.Y = 2f;
        }
        else if (this.aabb.Y < Main.player[(int) this.target].aabb.Y - 250)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.98f;
          this.velocity.Y += 0.02f;
          if ((double) this.velocity.Y < -2.0)
            this.velocity.Y = -2f;
        }
        if (this.aabb.X + ((int) this.width >> 1) > Main.player[(int) this.target].aabb.X + 10)
        {
          if ((double) this.velocity.X > 0.0)
            this.velocity.X *= 0.98f;
          this.velocity.X -= 0.05f;
          if ((double) this.velocity.X > 8.0)
            this.velocity.X = 8f;
        }
        else if (this.aabb.X + ((int) this.width >> 1) < Main.player[(int) this.target].aabb.X + 10)
        {
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.98f;
          this.velocity.X += 0.05f;
          if ((double) this.velocity.X < -8.0)
            this.velocity.X = -8f;
        }
      }
      else if ((double) this.ai1 == 1.0)
      {
        this.defense = 0;
        ++this.ai2;
        if ((double) this.ai2 == 2.0)
          Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
        if ((double) this.ai2 >= 400.0)
        {
          this.ai2 = 0.0f;
          this.ai1 = 0.0f;
        }
        this.rotation += (float) this.direction * 0.3f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num3 = 1.5f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        this.velocity.X = num1 * num3;
        this.velocity.Y = num2 * num3;
      }
      else if ((double) this.ai1 == 2.0)
      {
        this.damage = 9999;
        this.defense = 9999;
        this.rotation += (float) this.direction * 0.3f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num3 = 8f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        this.velocity.X = num1 * num3;
        this.velocity.Y = num2 * num3;
      }
      else if ((double) this.ai1 == 3.0)
      {
        this.velocity.Y += 0.1f;
        if ((double) this.velocity.Y < 0.0)
          this.velocity.Y *= 0.95f;
        this.velocity.X *= 0.95f;
        if (this.timeLeft > 500)
          this.timeLeft = 500;
      }
      if ((double) this.ai1 == 2.0 || (double) this.ai1 == 3.0 || (int) this.type == 68)
        return;
      Dust* dustPtr1 = Main.dust.NewDust(this.aabb.X + ((int) this.width >> 1) - 15 - (int) ((double) this.velocity.X * 5.0), this.aabb.Y + (int) this.height - 2, 30, 10, 5, (double) this.velocity.X * -0.200000002980232, 3.0, 0, new Color(), 2.0);
      if ((IntPtr) dustPtr1 != IntPtr.Zero)
      {
        dustPtr1->noGravity = true;
        dustPtr1->velocity.X *= 1.3f;
        dustPtr1->velocity.X += this.velocity.X * 0.4f;
        dustPtr1->velocity.Y += 2f + this.velocity.Y;
      }
      for (int index = 0; index < 2; ++index)
      {
        Dust* dustPtr2 = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 120, (int) this.width, 60, 5, (double) this.velocity.X, (double) this.velocity.Y, 0, new Color(), 2.0);
        if ((IntPtr) dustPtr2 == IntPtr.Zero)
          break;
        dustPtr2->noGravity = true;
        dustPtr2->velocity -= this.velocity;
        dustPtr2->velocity.Y += 5f;
      }
    }

    private void SkeletronHandAI()
    {
      this.spriteDirection = (sbyte) -(double) this.ai0;
      if ((int) Main.npc[(int) this.ai1].active == 0 || (int) Main.npc[(int) this.ai1].aiStyle != 11)
      {
        this.ai2 += 10f;
        if ((double) this.ai2 > 50.0 || Main.netMode != 2)
        {
          this.life = -1;
          this.HitEffect(0, 10.0);
          this.active = (byte) 0;
          return;
        }
      }
      if ((double) this.ai2 == 0.0 || (double) this.ai2 == 3.0)
      {
        if ((double) Main.npc[(int) this.ai1].ai1 == 3.0 && this.timeLeft > 10)
          this.timeLeft = 10;
        if ((double) Main.npc[(int) this.ai1].ai1 != 0.0)
        {
          if (this.aabb.Y > Main.npc[(int) this.ai1].aabb.Y - 100)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.07f;
            if ((double) this.velocity.Y > 6.0)
              this.velocity.Y = 6f;
          }
          else if (this.aabb.Y < Main.npc[(int) this.ai1].aabb.Y - 100)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.07f;
            if ((double) this.velocity.Y < -6.0)
              this.velocity.Y = -6f;
          }
          if (this.aabb.X + ((int) this.width >> 1) > Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1) - 120 * (int) this.ai0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          else if (this.aabb.X + ((int) this.width >> 1) < Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1) - 120 * (int) this.ai0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        else
        {
          ++this.ai3;
          if ((double) this.ai3 >= 300.0)
          {
            ++this.ai2;
            this.ai3 = 0.0f;
            this.netUpdate = true;
          }
          if (this.aabb.Y > Main.npc[(int) this.ai1].aabb.Y + 230)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
          }
          else if (this.aabb.Y < Main.npc[(int) this.ai1].aabb.Y + 230)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -3.0)
              this.velocity.Y = -3f;
          }
          if (this.aabb.X + ((int) this.width >> 1) > Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1) - 200 * (int) this.ai0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.07f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          else if (this.aabb.X + ((int) this.width >> 1) < Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1) - 200 * (int) this.ai0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X += 0.07f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2.X;
        this.rotation = (float) Math.Atan2((double) (Main.npc[(int) this.ai1].position.Y + 230f - vector2.Y), (double) num) + 1.57f;
      }
      else if ((double) this.ai2 == 1.0)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2.X;
        this.rotation = (float) Math.Atan2((double) (Main.npc[(int) this.ai1].position.Y + 230f - vector2.Y), (double) num1) + 1.57f;
        this.velocity.X *= 0.95f;
        this.velocity.Y -= 0.1f;
        if ((double) this.velocity.Y < -8.0)
          this.velocity.Y = -8f;
        if (this.aabb.Y >= Main.npc[(int) this.ai1].aabb.Y - 200)
          return;
        this.TargetClosest(true);
        this.ai2 = 2f;
        vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num2 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num3 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num4 = 18f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
        this.velocity.X = num2 * num4;
        this.velocity.Y = num3 * num4;
        this.netUpdate = true;
      }
      else if ((double) this.ai2 == 2.0)
      {
        if (this.aabb.Y <= Main.player[(int) this.target].aabb.Y && (double) this.velocity.Y >= 0.0)
          return;
        this.ai2 = 3f;
      }
      else if ((double) this.ai2 == 4.0)
      {
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2.X;
        this.rotation = (float) Math.Atan2((double) (Main.npc[(int) this.ai1].position.Y + 230f - vector2.Y), (double) num1) + 1.57f;
        this.velocity.Y *= 0.95f;
        this.velocity.X += (float) (0.100000001490116 * -(double) this.ai0);
        if ((double) this.velocity.X < -8.0)
          this.velocity.X = -8f;
        if ((double) this.velocity.X > 8.0)
          this.velocity.X = 8f;
        if (this.aabb.X + ((int) this.width >> 1) >= Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1) - 500 && this.aabb.X + ((int) this.width >> 1) <= Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1) + 500)
          return;
        this.TargetClosest(true);
        this.ai2 = 5f;
        vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num2 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num3 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num4 = 17f / (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
        this.velocity.X = num2 * num4;
        this.velocity.Y = num3 * num4;
        this.netUpdate = true;
      }
      else
      {
        if ((double) this.ai2 != 5.0 || ((double) this.velocity.X <= 0.0 || this.aabb.X + ((int) this.width >> 1) <= Main.player[(int) this.target].aabb.X + 10) && ((double) this.velocity.X >= 0.0 || this.aabb.X + ((int) this.width >> 1) >= Main.player[(int) this.target].aabb.X + 10))
          return;
        this.ai2 = 0.0f;
      }
    }

    private void PlantAI()
    {
      if ((int) Main.tile[(int) this.ai0, (int) this.ai1].active == 0)
      {
        this.life = -1;
        this.HitEffect(0, 10.0);
        this.active = (byte) 0;
      }
      else
      {
        this.TargetClosest(true);
        float num1 = 0.035f;
        float num2 = 150f;
        if ((int) this.type == 43)
          num2 = 250f;
        if ((int) this.type == 101)
          num2 = 175f;
        ++this.ai2;
        if ((double) this.ai2 > 300.0)
        {
          num2 = (float) (int) ((double) num2 * 1.29999995231628);
          if ((double) this.ai2 > 450.0)
            this.ai2 = 0.0f;
        }
        Vector2 vector2 = new Vector2((float) ((double) this.ai0 * 16.0 + 8.0), (float) ((double) this.ai1 * 16.0 + 8.0));
        float num3 = Main.player[(int) this.target].position.X + 10f - (float) ((int) this.width >> 1) - vector2.X;
        float num4 = Main.player[(int) this.target].position.Y + 21f - (float) ((int) this.height >> 1) - vector2.Y;
        float num5 = (float) ((double) num3 * (double) num3 + (double) num4 * (double) num4);
        if ((double) num5 > (double) num2 * (double) num2)
        {
          float num6 = num2 / (float) Math.Sqrt((double) num5);
          num3 *= num6;
          num4 *= num6;
        }
        if ((double) this.position.X < (double) this.ai0 * 16.0 + 8.0 + (double) num3)
        {
          this.velocity.X += num1;
          if ((double) this.velocity.X < 0.0 && (double) num3 > 0.0)
            this.velocity.X += num1 * 1.5f;
        }
        else if ((double) this.position.X > (double) this.ai0 * 16.0 + 8.0 + (double) num3)
        {
          this.velocity.X -= num1;
          if ((double) this.velocity.X > 0.0 && (double) num3 < 0.0)
            this.velocity.X -= num1 * 1.5f;
        }
        if ((double) this.position.Y < (double) this.ai1 * 16.0 + 8.0 + (double) num4)
        {
          this.velocity.Y += num1;
          if ((double) this.velocity.Y < 0.0 && (double) num4 > 0.0)
            this.velocity.Y += num1 * 1.5f;
        }
        else if ((double) this.position.Y > (double) this.ai1 * 16.0 + 8.0 + (double) num4)
        {
          this.velocity.Y -= num1;
          if ((double) this.velocity.Y > 0.0 && (double) num4 < 0.0)
            this.velocity.Y -= num1 * 1.5f;
        }
        if ((int) this.type == 43)
        {
          if ((double) this.velocity.X > 3.0)
            this.velocity.X = 3f;
          else if ((double) this.velocity.X < -3.0)
            this.velocity.X = -3f;
          if ((double) this.velocity.Y > 3.0)
            this.velocity.Y = 3f;
          else if ((double) this.velocity.Y < -3.0)
            this.velocity.Y = -3f;
        }
        else
        {
          if ((double) this.velocity.X > 2.0)
            this.velocity.X = 2f;
          else if ((double) this.velocity.X < -2.0)
            this.velocity.X = -2f;
          if ((double) this.velocity.Y > 2.0)
            this.velocity.Y = 2f;
          else if ((double) this.velocity.Y < -2.0)
            this.velocity.Y = -2f;
        }
        if ((double) num3 > 0.0)
        {
          this.spriteDirection = (sbyte) 1;
          this.rotation = (float) Math.Atan2((double) num4, (double) num3);
        }
        else if ((double) num3 < 0.0)
        {
          this.spriteDirection = (sbyte) -1;
          this.rotation = (float) Math.Atan2((double) num4, (double) num3) + 3.14f;
        }
        if (this.collideX)
        {
          this.netUpdate = true;
          this.velocity.X = this.oldVelocity.X * -0.7f;
          if ((double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
            this.velocity.X = 2f;
          else if ((double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
            this.velocity.X = -2f;
        }
        if (this.collideY)
        {
          this.netUpdate = true;
          this.velocity.Y = this.oldVelocity.Y * -0.7f;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 2.0)
            this.velocity.Y = 2f;
          else if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -2.0)
            this.velocity.Y = -2f;
        }
        if (Main.netMode == 1 || (int) this.type != 101 || Main.player[(int) this.target].dead)
          return;
        if (this.justHit)
          this.localAI0 = 0;
        if (++this.localAI0 < 120)
          return;
        if (!Collision.SolidCollision(ref this.position, (int) this.width, (int) this.height) && Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
        {
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num6 = Main.player[(int) this.target].position.X + 10f - vector2.X + (float) Main.rand.Next(-10, 11);
          float num7 = Main.player[(int) this.target].position.Y + 21f - vector2.Y + (float) Main.rand.Next(-10, 11);
          float num8 = 10f / (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float SpeedX = num6 * num8;
          float SpeedY = num7 * num8;
          int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 96, 22, 0.0f, 8, true);
          if (index >= 0)
            Main.projectile[index].timeLeft = 300;
          this.localAI0 = 0;
        }
        else
          this.localAI0 = 100;
      }
    }

    private unsafe void FlyerAI()
    {
      if ((int) this.type == 60)
      {
        Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.200000002980232, (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
          dustPtr->noGravity = true;
      }
      this.noGravity = true;
      if (this.collideX)
      {
        this.velocity.X = this.oldVelocity.X * -0.5f;
        if ((int) this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
          this.velocity.X = 2f;
        else if ((int) this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
          this.velocity.X = -2f;
      }
      if (this.collideY)
      {
        this.velocity.Y = this.oldVelocity.Y * -0.5f;
        if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
          this.velocity.Y = 1f;
        else if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
          this.velocity.Y = -1f;
      }
      this.TargetClosest(true);
      if ((int) this.direction == -1 && (double) this.velocity.X > -4.0)
      {
        this.velocity.X -= 0.1f;
        if ((double) this.velocity.X > 4.0)
          this.velocity.X -= 0.1f;
        else if ((double) this.velocity.X > 0.0)
          this.velocity.X += 0.05f;
        else if ((double) this.velocity.X < -4.0)
          this.velocity.X = -4f;
      }
      else if ((int) this.direction == 1 && (double) this.velocity.X < 4.0)
      {
        this.velocity.X += 0.1f;
        if ((double) this.velocity.X < -4.0)
          this.velocity.X += 0.1f;
        else if ((double) this.velocity.X < 0.0)
          this.velocity.X -= 0.05f;
        else if ((double) this.velocity.X > 4.0)
          this.velocity.X = 4f;
      }
      if ((int) this.directionY == -1 && (double) this.velocity.Y > -1.5)
      {
        this.velocity.Y -= 0.04f;
        if ((double) this.velocity.Y > 1.5)
          this.velocity.Y -= 0.05f;
        else if ((double) this.velocity.Y > 0.0)
          this.velocity.Y += 0.03f;
        else if ((double) this.velocity.Y < -1.5)
          this.velocity.Y = -1.5f;
      }
      else if ((int) this.directionY == 1 && (double) this.velocity.Y < 1.5)
      {
        this.velocity.Y += 0.04f;
        if ((double) this.velocity.Y < -1.5)
          this.velocity.Y += 0.05f;
        else if ((double) this.velocity.Y < 0.0)
          this.velocity.Y -= 0.03f;
        else if ((double) this.velocity.Y > 1.5)
          this.velocity.Y = 1.5f;
      }
      if ((int) this.type == 49 || (int) this.type == 51 || ((int) this.type == 60 || (int) this.type == 62) || ((int) this.type == 165 || (int) this.type == 66 || ((int) this.type == 93 || (int) this.type == 137)))
      {
        if (this.wet)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.95f;
          this.velocity.Y -= 0.5f;
          if ((double) this.velocity.Y < -4.0)
            this.velocity.Y = -4f;
          this.TargetClosest(true);
        }
        if ((int) this.type == 60)
        {
          if ((int) this.direction == -1 && (double) this.velocity.X > -4.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 4.0)
              this.velocity.X -= 0.07f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X += 0.03f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X = -4f;
          }
          else if ((int) this.direction == 1 && (double) this.velocity.X < 4.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X += 0.07f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X -= 0.03f;
            if ((double) this.velocity.X > 4.0)
              this.velocity.X = 4f;
          }
          if ((int) this.directionY == -1 && (double) this.velocity.Y > -1.5)
          {
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 1.5)
              this.velocity.Y -= 0.03f;
            else if ((double) this.velocity.Y > 0.0)
              this.velocity.Y += 0.02f;
            if ((double) this.velocity.Y < -1.5)
              this.velocity.Y = -1.5f;
          }
          else if ((int) this.directionY == 1 && (double) this.velocity.Y < 1.5)
          {
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -1.5)
              this.velocity.Y += 0.03f;
            else if ((double) this.velocity.Y < 0.0)
              this.velocity.Y -= 0.02f;
            if ((double) this.velocity.Y > 1.5)
              this.velocity.Y = 1.5f;
          }
        }
        else
        {
          if ((int) this.direction == -1 && (double) this.velocity.X > -4.0)
          {
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 4.0)
              this.velocity.X -= 0.1f;
            else if ((double) this.velocity.X > 0.0)
              this.velocity.X += 0.05f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X = -4f;
          }
          else if ((int) this.direction == 1 && (double) this.velocity.X < 4.0)
          {
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -4.0)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X < 0.0)
              this.velocity.X -= 0.05f;
            if ((double) this.velocity.X > 4.0)
              this.velocity.X = 4f;
          }
          if ((int) this.directionY == -1 && (double) this.velocity.Y > -1.5)
          {
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 1.5)
              this.velocity.Y -= 0.05f;
            else if ((double) this.velocity.Y > 0.0)
              this.velocity.Y += 0.03f;
            if ((double) this.velocity.Y < -1.5)
              this.velocity.Y = -1.5f;
          }
          else if ((int) this.directionY == 1 && (double) this.velocity.Y < 1.5)
          {
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -1.5)
              this.velocity.Y += 0.05f;
            else if ((double) this.velocity.Y < 0.0)
              this.velocity.Y -= 0.03f;
            if ((double) this.velocity.Y > 1.5)
              this.velocity.Y = 1.5f;
          }
        }
      }
      ++this.ai1;
      if ((double) this.ai1 > 200.0)
      {
        if (!Main.player[(int) this.target].wet && Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
          this.ai1 = 0.0f;
        float num1 = 0.2f;
        float num2 = 0.1f;
        float num3 = 4f;
        float num4 = 1.5f;
        if ((int) this.type == 48 || (int) this.type == 62 || ((int) this.type == 165 || (int) this.type == 66))
        {
          num1 = 0.12f;
          num2 = 0.07f;
          num3 = 3f;
          num4 = 1.25f;
        }
        if ((double) this.ai1 > 1000.0)
          this.ai1 = 0.0f;
        ++this.ai2;
        if ((double) this.ai2 > 0.0)
        {
          if ((double) this.velocity.Y < (double) num4)
            this.velocity.Y += num2;
        }
        else if ((double) this.velocity.Y > -(double) num4)
          this.velocity.Y -= num2;
        if ((double) this.ai2 < -150.0 || (double) this.ai2 > 150.0)
        {
          if ((double) this.velocity.X < (double) num3)
            this.velocity.X += num1;
        }
        else if ((double) this.velocity.X > -(double) num3)
          this.velocity.X -= num1;
        if ((double) this.ai2 > 300.0)
          this.ai2 = -300f;
      }
      if (Main.netMode == 1)
        return;
      if ((int) this.type == 48)
      {
        ++this.ai0;
        if ((double) this.ai0 == 30.0 || (double) this.ai0 == 60.0 || (double) this.ai0 == 90.0)
        {
          if (!Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            return;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X + (float) Main.rand.Next(-100, 101);
          float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y + (float) Main.rand.Next(-100, 101);
          float num3 = 6f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
          float SpeedX = num1 * num3;
          float SpeedY = num2 * num3;
          int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 38, 15, 0.0f, 8, true);
          if (index < 0)
            return;
          Main.projectile[index].timeLeft = 300;
        }
        else
        {
          if ((double) this.ai0 < (double) (400 + Main.rand.Next(400)))
            return;
          this.ai0 = 0.0f;
        }
      }
      else
      {
        if ((int) this.type != 62 && (int) this.type != 165 && (int) this.type != 66)
          return;
        ++this.ai0;
        if ((double) this.ai0 == 20.0 || (double) this.ai0 == 40.0 || ((double) this.ai0 == 60.0 || (double) this.ai0 == 80.0))
        {
          if (!Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            return;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X + (float) Main.rand.Next(-100, 101);
          float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y + (float) Main.rand.Next(-100, 101);
          float num3 = 0.2f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
          float SpeedX = num1 * num3;
          float SpeedY = num2 * num3;
          int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 44, 21, 0.0f, 8, true);
          if (index < 0)
            return;
          Main.projectile[index].timeLeft = 300;
        }
        else
        {
          if ((double) this.ai0 < (double) (300 + Main.rand.Next(300)))
            return;
          this.ai0 = 0.0f;
        }
      }
    }

    private unsafe void KingSlimeAI()
    {
      this.aiAction = (byte) 0;
      if ((double) this.ai3 == 0.0 && this.life > 0)
        this.ai3 = (float) this.lifeMax;
      if ((double) this.ai2 == 0.0)
      {
        this.ai0 = -100f;
        this.ai2 = 1f;
        this.TargetClosest(true);
      }
      if ((double) this.velocity.Y == 0.0)
      {
        this.velocity.X *= 0.8f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        double num = (double) this.life / (double) this.lifeMax;
        if (num < 0.1)
          this.ai0 += 13f;
        else if (num < 0.2)
          this.ai0 += 9f;
        else if (num < 0.4)
          this.ai0 += 6f;
        else if (num < 0.6)
          this.ai0 += 4f;
        else if (num < 0.8)
          this.ai0 += 3f;
        else
          this.ai0 += 2f;
        if ((double) this.ai0 >= 0.0)
        {
          this.netUpdate = true;
          this.TargetClosest(true);
          if ((double) this.ai1 == 3.0)
          {
            this.velocity.Y = -13f;
            this.velocity.X += 3.5f * (float) this.direction;
            this.ai0 = -200f;
            this.ai1 = 0.0f;
          }
          else if ((double) this.ai1 == 2.0)
          {
            this.velocity.Y = -6f;
            this.velocity.X += 4.5f * (float) this.direction;
            this.ai0 = -120f;
            ++this.ai1;
          }
          else
          {
            this.velocity.Y = -8f;
            this.velocity.X += 4f * (float) this.direction;
            this.ai0 = -120f;
            ++this.ai1;
          }
        }
        else if ((double) this.ai0 >= -30.0)
          this.aiAction = (byte) 1;
      }
      else if ((int) this.target < 8 && ((int) this.direction == 1 && (double) this.velocity.X < 3.0 || (int) this.direction == -1 && (double) this.velocity.X > -3.0))
      {
        if ((int) this.direction == -1 && (double) this.velocity.X < 0.1 || (int) this.direction == 1 && (double) this.velocity.X > -0.1)
          this.velocity.X += 0.2f * (float) this.direction;
        else
          this.velocity.X *= 0.93f;
      }
      Dust* dustPtr = Main.dust.NewDust(4, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, (int) byte.MaxValue, new Color(0, 80, (int) byte.MaxValue, 80), (double) this.scale * 1.20000004768372);
      if ((IntPtr) dustPtr != IntPtr.Zero)
      {
        dustPtr->noGravity = true;
        dustPtr->velocity.X *= 0.5f;
        dustPtr->velocity.Y *= 0.5f;
      }
      if (this.life <= 0)
        return;
      float num1 = (float) ((double) ((float) this.life / (float) this.lifeMax) * 0.5 + 0.75);
      if ((double) num1 != (double) this.scale)
      {
        this.position.X += (float) ((int) this.width >> 1);
        this.position.Y += (float) this.height;
        this.scale = num1;
        this.width = (ushort) (98.0 * (double) this.scale);
        this.height = (ushort) (92.0 * (double) this.scale);
        this.position.X -= (float) ((int) this.width >> 1);
        this.position.Y -= (float) this.height;
        this.aabb.X = (int) this.position.X;
        this.aabb.Y = (int) this.position.Y;
        this.aabb.Width = (int) this.width;
        this.aabb.Height = (int) this.height;
      }
      if (Main.netMode == 1 || (double) (this.life + (int) ((double) this.lifeMax * 0.05)) >= (double) this.ai3)
        return;
      this.ai3 = (float) this.life;
      int num2 = Main.rand.Next(1, 4);
      for (int index = 0; index < num2; ++index)
      {
        int number = NPC.NewNPC(this.aabb.X + Main.rand.Next((int) this.width - 32), this.aabb.Y + Main.rand.Next((int) this.height - 32), 1, 0);
        if (number < 196)
        {
          Main.npc[number].SetDefaults(1, -1.0);
          Main.npc[number].velocity.X = (float) Main.rand.Next(-15, 16) * 0.1f;
          Main.npc[number].velocity.Y = (float) Main.rand.Next(-30, 1) * 0.1f;
          Main.npc[number].ai1 = (float) Main.rand.Next(3);
          NetMessage.CreateMessage1(23, number);
          NetMessage.SendMessage();
        }
      }
    }

    private void FishAI()
    {
      if ((int) this.direction == 0)
        this.TargetClosest(true);
      if (this.wet)
      {
        bool flag = false;
        if ((int) this.type != 55)
        {
          this.TargetClosest(false);
          if (Main.player[(int) this.target].wet && !Main.player[(int) this.target].dead)
            flag = true;
        }
        if (!flag)
        {
          if (this.collideX)
          {
            this.velocity.X = -this.velocity.X;
            this.direction = -this.direction;
            this.netUpdate = true;
          }
          if (this.collideY)
          {
            this.netUpdate = true;
            this.velocity.Y = -this.velocity.Y;
            if ((double) this.velocity.Y < 0.0)
            {
              this.directionY = (sbyte) -1;
              this.ai0 = -1f;
            }
            else if ((double) this.velocity.Y > 0.0)
            {
              this.directionY = (sbyte) 1;
              this.ai0 = 1f;
            }
          }
        }
        if ((int) this.type == 102)
          Lighting.addLight(this.aabb.X + ((int) this.width >> 1) + (int) this.direction * ((int) this.width + 8) >> 4, this.aabb.Y + 2 >> 4, new Vector3(0.07f, 0.04f, 0.025f));
        if (flag)
        {
          this.TargetClosest(true);
          if ((int) this.type == 65 || (int) this.type == 102 || (int) this.type == 148)
          {
            this.velocity.X += (float) this.direction * 0.15f;
            this.velocity.Y += (float) this.directionY * 0.15f;
            if ((double) this.velocity.X > 5.0)
              this.velocity.X = 5f;
            else if ((double) this.velocity.X < -5.0)
              this.velocity.X = -5f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
            else if ((double) this.velocity.Y < -3.0)
              this.velocity.Y = -3f;
          }
          else
          {
            this.velocity.X += (float) this.direction * 0.1f;
            this.velocity.Y += (float) this.directionY * 0.1f;
            if ((double) this.velocity.X > 3.0)
              this.velocity.X = 3f;
            else if ((double) this.velocity.X < -3.0)
              this.velocity.X = -3f;
            if ((double) this.velocity.Y > 2.0)
              this.velocity.Y = 2f;
            else if ((double) this.velocity.Y < -2.0)
              this.velocity.Y = -2f;
          }
        }
        else
        {
          this.velocity.X += (float) this.direction * 0.1f;
          if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
            this.velocity.X *= 0.95f;
          if ((double) this.ai0 == -1.0)
          {
            this.velocity.Y -= 0.01f;
            if ((double) this.velocity.Y < -0.3)
              this.ai0 = 1f;
          }
          else
          {
            this.velocity.Y += 0.01f;
            if ((double) this.velocity.Y > 0.3)
              this.ai0 = -1f;
          }
          int index = this.aabb.X + ((int) this.width >> 1) >> 4;
          int num = this.aabb.Y + ((int) this.height >> 1) >> 4;
          if ((int) Main.tile[index, num - 1].liquid > 128)
          {
            if ((int) Main.tile[index, num + 1].active != 0)
              this.ai0 = -1f;
            else if ((int) Main.tile[index, num + 2].active != 0)
              this.ai0 = -1f;
          }
          if ((double) this.velocity.Y > 0.4 || (double) this.velocity.Y < -0.4)
            this.velocity.Y *= 0.95f;
        }
      }
      else
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if ((int) this.type == 65 || (int) this.type == 148)
          {
            this.velocity.X *= 0.94f;
            if ((double) this.velocity.X > -0.200000002980232 && (double) this.velocity.X < 0.200000002980232)
              this.velocity.X = 0.0f;
          }
          else if (Main.netMode != 1)
          {
            this.velocity.Y = (float) Main.rand.Next(-50, -20) * 0.1f;
            this.velocity.X = (float) Main.rand.Next(-20, 20) * 0.1f;
            this.netUpdate = true;
          }
        }
        this.velocity.Y += 0.3f;
        if ((double) this.velocity.Y > 10.0)
          this.velocity.Y = 10f;
        this.ai0 = 1f;
      }
      this.rotation = (float) ((double) this.velocity.Y * (double) this.direction * 0.100000001490116);
      if ((double) this.rotation < -0.200000002980232)
      {
        this.rotation = -0.2f;
      }
      else
      {
        if ((double) this.rotation <= 0.200000002980232)
          return;
        this.rotation = 0.2f;
      }
    }

    private void VultureAI()
    {
      this.noGravity = true;
      if ((double) this.ai0 == 0.0)
      {
        this.noGravity = false;
        this.TargetClosest(true);
        if (Main.netMode != 1)
        {
          if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y < 0.0 || (double) this.velocity.Y > 0.300000011920929)
          {
            this.ai0 = 1f;
            this.netUpdate = true;
          }
          else if (this.life < this.lifeMax || Main.player[(int) this.target].aabb.Intersects(new Rectangle(this.aabb.X - 100, this.aabb.Y - 100, (int) this.width + 200, (int) this.height + 200)))
          {
            this.ai0 = 1f;
            this.velocity.Y -= 6f;
            this.netUpdate = true;
          }
        }
      }
      else if (!Main.player[(int) this.target].dead)
      {
        if (this.collideX)
        {
          this.velocity.X = this.oldVelocity.X * -0.5f;
          if ((int) this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
            this.velocity.X = 2f;
          else if ((int) this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
            this.velocity.X = -2f;
        }
        if (this.collideY)
        {
          this.velocity.Y = this.oldVelocity.Y * -0.5f;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
            this.velocity.Y = 1f;
          else if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
            this.velocity.Y = -1f;
        }
        this.TargetClosest(true);
        if ((int) this.direction == -1 && (double) this.velocity.X > -3.0)
        {
          this.velocity.X -= 0.1f;
          if ((double) this.velocity.X > 3.0)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X > 0.0)
            this.velocity.X -= 0.05f;
          else if ((double) this.velocity.X < -3.0)
            this.velocity.X = -3f;
        }
        else if ((int) this.direction == 1 && (double) this.velocity.X < 3.0)
        {
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X < -3.0)
            this.velocity.X += 0.1f;
          else if ((double) this.velocity.X < 0.0)
            this.velocity.X += 0.05f;
          else if ((double) this.velocity.X > 3.0)
            this.velocity.X = 3f;
        }
        int num1 = Math.Abs(this.aabb.X + ((int) this.width >> 1) - (Main.player[(int) this.target].aabb.X + 10));
        int num2 = Main.player[(int) this.target].aabb.Y - ((int) this.height >> 1);
        if (num1 > 50)
          num2 -= 100;
        if (this.aabb.Y < num2)
        {
          this.velocity.Y += 0.05f;
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y += 0.01f;
        }
        else
        {
          this.velocity.Y -= 0.05f;
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y -= 0.01f;
        }
        if ((double) this.velocity.Y < -3.0)
          this.velocity.Y = -3f;
        if ((double) this.velocity.Y > 3.0)
          this.velocity.Y = 3f;
      }
      if (!this.wet)
        return;
      if ((double) this.velocity.Y > 0.0)
        this.velocity.Y *= 0.95f;
      this.velocity.Y -= 0.5f;
      if ((double) this.velocity.Y < -4.0)
        this.velocity.Y = -4f;
      this.TargetClosest(true);
    }

    private void JellyfishAI()
    {
      Lighting.addLight(this.aabb.X + ((int) this.height >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, (int) this.type != 63 ? ((int) this.type != 103 ? new Vector3(0.35f, 0.05f, 0.2f) : new Vector3(0.05f, 0.45f, 0.1f)) : new Vector3(0.05f, 0.15f, 0.4f));
      if ((int) this.direction == 0)
        this.TargetClosest(true);
      if (this.wet)
      {
        if (this.collideX)
        {
          this.velocity.X = -this.velocity.X;
          this.direction = -this.direction;
        }
        if (this.collideY)
        {
          this.velocity.Y = -this.velocity.Y;
          if ((double) this.velocity.Y < 0.0)
          {
            this.directionY = (sbyte) -1;
            this.ai0 = -1f;
          }
          else if ((double) this.velocity.Y > 0.0)
          {
            this.directionY = (sbyte) 1;
            this.ai0 = 1f;
          }
        }
        bool flag = false;
        if (!this.friendly)
        {
          this.TargetClosest(false);
          if (Main.player[(int) this.target].wet && !Main.player[(int) this.target].dead)
            flag = true;
        }
        if (flag)
        {
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
          this.velocity.X *= 0.98f;
          this.velocity.Y *= 0.98f;
          float num1 = 0.2f;
          if ((int) this.type == 103)
          {
            this.velocity.X *= 0.98f;
            this.velocity.Y *= 0.98f;
            num1 = 0.6f;
          }
          if ((double) this.velocity.X <= -(double) num1 || (double) this.velocity.X >= (double) num1 || ((double) this.velocity.Y <= -(double) num1 || (double) this.velocity.Y >= (double) num1))
            return;
          this.TargetClosest(true);
          float num2 = (int) this.type == 103 ? 9f : 7f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num3 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num4 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
          float num6 = num2 / num5;
          float num7 = num3 * num6;
          float num8 = num4 * num6;
          this.velocity.X = num7;
          this.velocity.Y = num8;
        }
        else
        {
          this.velocity.X += (float) this.direction * 0.02f;
          this.rotation = this.velocity.X * 0.4f;
          if ((double) this.velocity.X < -1.0 || (double) this.velocity.X > 1.0)
            this.velocity.X *= 0.95f;
          if ((double) this.ai0 == -1.0)
          {
            this.velocity.Y -= 0.01f;
            if ((double) this.velocity.Y < -1.0)
              this.ai0 = 1f;
          }
          else
          {
            this.velocity.Y += 0.01f;
            if ((double) this.velocity.Y > 1.0)
              this.ai0 = -1f;
          }
          int index = this.aabb.X + ((int) this.width >> 1) >> 4;
          int num = this.aabb.Y + ((int) this.height >> 1) >> 4;
          if ((int) Main.tile[index, num - 1].liquid > 128)
          {
            if ((int) Main.tile[index, num + 1].active != 0)
              this.ai0 = -1f;
            else if ((int) Main.tile[index, num + 2].active != 0)
              this.ai0 = -1f;
          }
          else
            this.ai0 = 1f;
          if ((double) this.velocity.Y <= 1.2 && (double) this.velocity.Y >= -1.2)
            return;
          this.velocity.Y *= 0.99f;
        }
      }
      else
      {
        this.rotation += this.velocity.X * 0.1f;
        if ((double) this.velocity.Y == 0.0)
        {
          this.velocity.X *= 0.98f;
          if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
            this.velocity.X = 0.0f;
        }
        this.velocity.Y += 0.2f;
        if ((double) this.velocity.Y > 10.0)
          this.velocity.Y = 10f;
        this.ai0 = 1f;
      }
    }

    private unsafe void AntlionAI()
    {
      this.TargetClosest(true);
      Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
      float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X;
      float num2 = Main.player[(int) this.target].position.Y - vector2.Y;
      float num3 = 12f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
      float SpeedX = num1 * num3;
      float SpeedY = num2 * num3;
      bool flag = false;
      if ((int) this.directionY < 0)
      {
        this.rotation = (float) (Math.Atan2((double) SpeedY, (double) SpeedX) + 1.57);
        flag = (double) this.rotation >= -1.2 && (double) this.rotation <= 1.2;
        if ((double) this.rotation < -0.8)
          this.rotation = -0.8f;
        else if ((double) this.rotation > 0.8)
          this.rotation = 0.8f;
        if ((double) this.velocity.X != 0.0)
        {
          this.velocity.X *= 0.9f;
          if ((double) this.velocity.X > -0.1 || (double) this.velocity.X < 0.1)
          {
            this.netUpdate = true;
            this.velocity.X = 0.0f;
          }
        }
      }
      if ((double) this.ai0 > 0.0)
      {
        if ((double) this.ai0 == 200.0)
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 5);
        --this.ai0;
      }
      if (Main.netMode != 1)
      {
        if (flag)
        {
          if ((double) this.ai0 == 0.0)
          {
            if (Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            {
              this.ai0 = 200f;
              int Damage = 10;
              int Type = 31;
              int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, 8, false);
              if (number >= 0)
              {
                Main.projectile[number].ai0 = 2f;
                Main.projectile[number].timeLeft = 300;
                Main.projectile[number].friendly = false;
                NetMessage.SendProjectile(number, SendDataOptions.Reliable);
                this.netUpdate = true;
              }
            }
          }
        }
      }
      try
      {
        int index1 = this.aabb.X >> 4;
        int index2 = this.aabb.X + ((int) this.width >> 1) >> 4;
        int index3 = this.aabb.X + (int) this.width >> 4;
        int index4 = this.aabb.Y + (int) this.height >> 4;
        if ((int) Main.tile[index1, index4].active != 0 && Main.tileSolid[(int) Main.tile[index1, index4].type] || (int) Main.tile[index2, index4].active != 0 && Main.tileSolid[(int) Main.tile[index2, index4].type] || (int) Main.tile[index3, index4].active != 0 && Main.tileSolid[(int) Main.tile[index3, index4].type])
        {
          this.noGravity = true;
          this.noTileCollide = true;
          this.velocity.Y = -0.2f;
        }
        else
        {
          this.noGravity = false;
          this.noTileCollide = false;
          if (Main.rand.Next(3) != 0)
            return;
          Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 4, this.aabb.Y + (int) this.height - 8, (int) this.width + 8, 24, 32, 0.0, (double) this.velocity.Y * 0.5, 0, new Color(), 1.0);
          if ((IntPtr) dustPtr == IntPtr.Zero)
            return;
          dustPtr->velocity.X *= 0.4f;
          dustPtr->velocity.Y *= -1f;
          if (Main.rand.Next(2) != 0)
            return;
          dustPtr->noGravity = true;
          dustPtr->scale += 0.2f;
        }
      }
      catch
      {
      }
    }

    private void SpinningSpikeballAI()
    {
      if ((double) this.ai0 == 0.0)
      {
        if (Main.netMode != 1)
        {
          this.TargetClosest(true);
          this.direction = -this.direction;
          this.directionY = -this.directionY;
          this.position.Y += (float) (((int) this.height >> 1) + 8);
          this.ai1 = this.position.X + (float) ((int) this.width >> 1);
          this.ai2 = this.position.Y + (float) ((int) this.height >> 1);
          if ((int) this.direction == 0)
            this.direction = (sbyte) 1;
          if ((int) this.directionY == 0)
            this.directionY = (sbyte) 1;
          this.ai3 = (float) (1.0 + (double) Main.rand.Next(15) * 0.100000001490116);
          this.velocity.Y = (float) ((int) this.directionY * 6) * this.ai3;
          ++this.ai0;
          this.netUpdate = true;
        }
        else
        {
          this.ai1 = this.position.X + (float) ((int) this.width >> 1);
          this.ai2 = this.position.Y + (float) ((int) this.height >> 1);
        }
      }
      else
      {
        float num1 = 6f * this.ai3;
        float num2 = 0.2f * this.ai3;
        float num3 = (float) ((double) num1 / (double) num2 * 0.5);
        if ((double) this.ai0 >= 1.0 && (double) this.ai0 < (double) (int) num3)
        {
          this.velocity.Y = (float) this.directionY * num1;
          ++this.ai0;
        }
        else if ((double) this.ai0 >= (double) (int) num3)
        {
          this.netUpdate = true;
          this.velocity.Y = 0.0f;
          this.directionY = -this.directionY;
          this.velocity.X = num1 * (float) this.direction;
          this.ai0 = -1f;
        }
        else
        {
          if ((int) this.directionY > 0)
          {
            if ((double) this.velocity.Y >= (double) num1)
            {
              this.netUpdate = true;
              this.directionY = -this.directionY;
              this.velocity.Y = num1;
            }
          }
          else if ((int) this.directionY < 0 && (double) this.velocity.Y <= -(double) num1)
          {
            this.directionY = -this.directionY;
            this.velocity.Y = -num1;
          }
          if ((int) this.direction > 0)
          {
            if ((double) this.velocity.X >= (double) num1)
            {
              this.direction = -this.direction;
              this.velocity.X = num1;
            }
          }
          else if ((int) this.direction < 0 && (double) this.velocity.X <= -(double) num1)
          {
            this.direction = -this.direction;
            this.velocity.X = -num1;
          }
          this.velocity.X += num2 * (float) this.direction;
          this.velocity.Y += num2 * (float) this.directionY;
        }
      }
    }

    private void GravityDiskAI()
    {
      if ((double) this.ai0 == 0.0)
      {
        this.TargetClosest(true);
        this.directionY = (sbyte) 1;
        this.ai0 = 1f;
      }
      int num = 6;
      if ((double) this.ai1 == 0.0)
      {
        this.rotation += (float) ((int) this.direction * (int) this.directionY) * 0.13f;
        if (this.collideY)
          this.ai0 = 2f;
        if (!this.collideY && (double) this.ai0 == 2.0)
        {
          this.direction = -this.direction;
          this.ai1 = 1f;
          this.ai0 = 1f;
        }
        if (this.collideX)
        {
          this.directionY = -this.directionY;
          this.ai1 = 1f;
        }
      }
      else
      {
        this.rotation -= (float) ((int) this.direction * (int) this.directionY) * 0.13f;
        if (this.collideX)
          this.ai0 = 2f;
        if (!this.collideX && (double) this.ai0 == 2.0)
        {
          this.directionY = -this.directionY;
          this.ai1 = 0.0f;
          this.ai0 = 1f;
        }
        if (this.collideY)
        {
          this.direction = -this.direction;
          this.ai1 = 0.0f;
        }
      }
      this.velocity.X = (float) (num * (int) this.direction);
      this.velocity.Y = (float) (num * (int) this.directionY);
      Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, new Vector3(0.9f, 0.3f + (float) (270 - (int) UI.mouseTextBrightness) * (1.0 / 400.0), 0.2f));
    }

    private unsafe void MoreFlyerAI()
    {
      bool flag1 = false;
      if (this.justHit)
        this.ai2 = 0.0f;
      if ((double) this.ai2 >= 0.0)
      {
        float num1 = 16f;
        bool flag2 = false;
        bool flag3 = false;
        if ((double) this.position.X > (double) this.ai0 - (double) num1 && (double) this.position.X < (double) this.ai0 + (double) num1)
          flag2 = true;
        else if ((double) this.velocity.X < 0.0 && (int) this.direction > 0 || (double) this.velocity.X > 0.0 && (int) this.direction < 0)
          flag2 = true;
        float num2 = num1 + 24f;
        if ((double) this.position.Y > (double) this.ai1 - (double) num2 && (double) this.position.Y < (double) this.ai1 + (double) num2)
          flag3 = true;
        if (flag2 && flag3)
        {
          ++this.ai2;
          if ((double) this.ai2 >= 30.0 && (double) num2 == 16.0)
            flag1 = true;
          if ((double) this.ai2 >= 60.0)
          {
            this.ai2 = -200f;
            this.direction = -this.direction;
            this.velocity.X = -this.velocity.X;
            this.collideX = false;
          }
        }
        else
        {
          this.ai0 = this.position.X;
          this.ai1 = this.position.Y;
          this.ai2 = 0.0f;
        }
        this.TargetClosest(true);
      }
      else
      {
        ++this.ai2;
        this.direction = Main.player[(int) this.target].aabb.X + 10 <= this.aabb.X + ((int) this.width >> 1) ? (sbyte) 1 : (sbyte) -1;
      }
      int index1 = (this.aabb.X + ((int) this.width >> 1) >> 4) + ((int) this.direction << 1);
      int num3 = this.aabb.Y + (int) this.height >> 4;
      bool flag4 = true;
      bool flag5 = false;
      int num4 = 3;
      if ((int) this.type == 122 || (int) this.type == 153)
      {
        if (this.justHit)
        {
          this.ai3 = 0.0f;
          this.localAI1 = 0;
        }
        float num1 = 7f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num2 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num5 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num6 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num5 * (double) num5);
        float num7 = num1 / num6;
        float SpeedX = num2 * num7;
        float SpeedY = num5 * num7;
        if (Main.netMode != 1 && (double) this.ai3 == 32.0)
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 84, 25, 0.0f, 8, true);
        num4 = 8;
        if ((double) this.ai3 > 0.0)
        {
          ++this.ai3;
          if ((double) this.ai3 >= 64.0)
            this.ai3 = 0.0f;
        }
        if (Main.netMode != 1 && (double) this.ai3 == 0.0)
        {
          ++this.localAI1;
          if (this.localAI1 > 120 && Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
          {
            this.localAI1 = 0;
            this.ai3 = 1f;
            this.netUpdate = true;
          }
        }
      }
      else if ((int) this.type == 75)
      {
        num4 = 4;
        if (Main.rand.Next(7) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust(55, ref this.aabb, 0.0, 0.0, 200, this.color, 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.3f;
            dustPtr->velocity.Y *= 0.3f;
          }
        }
        if (Main.rand.Next(42) == 0)
          Main.PlaySound(27, this.aabb.X, this.aabb.Y, 1);
      }
      for (int index2 = num3; index2 < num3 + num4; ++index2)
      {
        if ((int) Main.tile[index1, index2].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2].type] || (int) Main.tile[index1, index2].liquid > 0)
        {
          if (index2 <= num3 + 1)
            flag5 = true;
          flag4 = false;
          break;
        }
      }
      if (flag1)
      {
        flag5 = false;
        flag4 = true;
      }
      if (flag4)
      {
        if ((int) this.type == 75)
        {
          this.velocity.Y += 0.2f;
          if ((double) this.velocity.Y > 2.0)
            this.velocity.Y = 2f;
        }
        else
        {
          this.velocity.Y += 0.1f;
          if ((double) this.velocity.Y > 3.0)
            this.velocity.Y = 3f;
        }
      }
      else
      {
        if ((int) this.type == 75)
        {
          if ((int) this.directionY < 0 && (double) this.velocity.Y > 0.0 || flag5)
            this.velocity.Y -= 0.2f;
        }
        else if ((int) this.directionY < 0 && (double) this.velocity.Y > 0.0)
          this.velocity.Y -= 0.1f;
        if ((double) this.velocity.Y < -4.0)
          this.velocity.Y = -4f;
      }
      if ((int) this.type == 75 && this.wet)
      {
        this.velocity.Y -= 0.2f;
        if ((double) this.velocity.Y < -2.0)
          this.velocity.Y = -2f;
      }
      if (this.collideX)
      {
        this.velocity.X = this.oldVelocity.X * -0.4f;
        if ((int) this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 1.0)
          this.velocity.X = 1f;
        else if ((int) this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -1.0)
          this.velocity.X = -1f;
      }
      if (this.collideY)
      {
        this.velocity.Y = this.oldVelocity.Y * -0.25f;
        if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
          this.velocity.Y = 1f;
        else if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
          this.velocity.Y = -1f;
      }
      float num8 = (int) this.type == 75 ? 3f : 2f;
      if ((int) this.direction == -1 && (double) this.velocity.X > -(double) num8)
      {
        this.velocity.X -= 0.1f;
        if ((double) this.velocity.X > (double) num8)
          this.velocity.X -= 0.1f;
        else if ((double) this.velocity.X > 0.0)
          this.velocity.X += 0.05f;
        else if ((double) this.velocity.X < -(double) num8)
          this.velocity.X = -num8;
      }
      else if ((int) this.direction == 1 && (double) this.velocity.X < (double) num8)
      {
        this.velocity.X += 0.1f;
        if ((double) this.velocity.X < -(double) num8)
          this.velocity.X += 0.1f;
        else if ((double) this.velocity.X < 0.0)
          this.velocity.X -= 0.05f;
        else if ((double) this.velocity.X > (double) num8)
          this.velocity.X = num8;
      }
      if ((int) this.directionY == -1 && (double) this.velocity.Y > -1.5)
      {
        this.velocity.Y -= 0.04f;
        if ((double) this.velocity.Y > 1.5)
          this.velocity.Y -= 0.05f;
        else if ((double) this.velocity.Y > 0.0)
          this.velocity.Y += 0.03f;
        else if ((double) this.velocity.Y < -1.5)
          this.velocity.Y = -1.5f;
      }
      else if ((int) this.directionY == 1 && (double) this.velocity.Y < 1.5)
      {
        this.velocity.Y += 0.04f;
        if ((double) this.velocity.Y < -1.5)
          this.velocity.Y += 0.05f;
        else if ((double) this.velocity.Y < 0.0)
          this.velocity.Y -= 0.03f;
        else if ((double) this.velocity.Y > 1.5)
          this.velocity.Y = 1.5f;
      }
      if ((int) this.type != 122 && (int) this.type != 153)
        return;
      Lighting.addLight(this.aabb.X >> 4, this.aabb.Y >> 4, new Vector3(0.4f, 0.0f, 0.25f));
    }

    private void EnchantedWeaponAI()
    {
      this.noGravity = true;
      this.noTileCollide = true;
      Vector3 rgb = new Vector3(0.05f, 0.2f, 0.3f);
      switch ((NPC.ID) this.type)
      {
        case NPC.ID.CURSED_HAMMER:
          rgb = new Vector3(0.2f, 0.05f, 0.3f);
          break;
        case NPC.ID.SHADOW_HAMMER:
          rgb = new Vector3(0.3f, 0.05f, 0.2f);
          break;
      }
      Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, rgb);
      if ((int) this.target == 8 || Main.player[(int) this.target].dead)
        this.TargetClosest(true);
      if ((double) this.ai0 == 0.0)
      {
        float num1 = 9f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num2 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num3 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3);
        float num5 = num1 / num4;
        float num6 = num2 * num5;
        float num7 = num3 * num5;
        this.velocity.X = num6;
        this.velocity.Y = num7;
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 0.785f;
        this.ai0 = 1f;
        this.ai1 = 0.0f;
      }
      else if ((double) this.ai0 == 1.0)
      {
        if (this.justHit)
        {
          this.ai0 = 2f;
          this.ai1 = 0.0f;
        }
        this.velocity.X *= 0.99f;
        this.velocity.Y *= 0.99f;
        ++this.ai1;
        if ((double) this.ai1 < 100.0)
          return;
        this.ai0 = 2f;
        this.ai1 = 0.0f;
        this.velocity.X = 0.0f;
        this.velocity.Y = 0.0f;
      }
      else
      {
        if (this.justHit)
        {
          this.ai0 = 2f;
          this.ai1 = 0.0f;
        }
        this.velocity.X *= 0.96f;
        this.velocity.Y *= 0.96f;
        ++this.ai1;
        this.rotation += (float) (0.100000001490116 + (double) (this.ai1 / 120f) * 0.400000005960464) * (float) this.direction;
        if ((double) this.ai1 < 120.0)
          return;
        this.netUpdate = true;
        this.ai0 = 0.0f;
        this.ai1 = 0.0f;
      }
    }

    private void BirdAI()
    {
      this.noGravity = true;
      if ((double) this.ai0 == 0.0)
      {
        this.noGravity = false;
        this.TargetClosest(true);
        if (Main.netMode != 1)
        {
          if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y < 0.0 || (double) this.velocity.Y > 0.3)
          {
            this.ai0 = 1f;
            this.netUpdate = true;
            this.direction = -this.direction;
          }
          else if (this.life < this.lifeMax || Main.player[(int) this.target].aabb.Intersects(new Rectangle(this.aabb.X - 100, this.aabb.Y - 100, (int) this.width + 200, (int) this.height + 200)))
          {
            this.ai0 = 1f;
            this.velocity.Y -= 6f;
            this.netUpdate = true;
            this.direction = -this.direction;
          }
        }
      }
      else if (!Main.player[(int) this.target].dead)
      {
        if (this.collideX)
        {
          this.direction = -this.direction;
          this.velocity.X = this.oldVelocity.X * -0.5f;
          if ((int) this.direction == -1 && (double) this.velocity.X > 0.0 && (double) this.velocity.X < 2.0)
            this.velocity.X = 2f;
          else if ((int) this.direction == 1 && (double) this.velocity.X < 0.0 && (double) this.velocity.X > -2.0)
            this.velocity.X = -2f;
        }
        if (this.collideY)
        {
          this.velocity.Y = this.oldVelocity.Y * -0.5f;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0)
            this.velocity.Y = 1f;
          else if ((double) this.velocity.Y < 0.0 && (double) this.velocity.Y > -1.0)
            this.velocity.Y = -1f;
        }
        if ((int) this.direction == -1 && (double) this.velocity.X > -3.0)
        {
          this.velocity.X -= 0.1f;
          if ((double) this.velocity.X > 3.0)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X > 0.0)
            this.velocity.X -= 0.05f;
          else if ((double) this.velocity.X < -3.0)
            this.velocity.X = -3f;
        }
        else if ((int) this.direction == 1 && (double) this.velocity.X < 3.0)
        {
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X < -3.0)
            this.velocity.X += 0.1f;
          else if ((double) this.velocity.X < 0.0)
            this.velocity.X += 0.05f;
          else if ((double) this.velocity.X > 3.0)
            this.velocity.X = 3f;
        }
        int index1 = (this.aabb.X + ((int) this.width >> 1) >> 4) + (int) this.direction;
        int num = this.aabb.Y + (int) this.height >> 4;
        bool flag1 = true;
        bool flag2 = false;
        try
        {
          for (int index2 = num; index2 < num + 15; ++index2)
          {
            if ((int) Main.tile[index1, index2].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2].type] || (int) Main.tile[index1, index2].liquid > 0)
            {
              if (index2 < num + 5)
                flag2 = true;
              flag1 = false;
              break;
            }
          }
        }
        catch
        {
          flag2 = true;
          flag1 = false;
        }
        if (flag1)
          this.velocity.Y += 0.1f;
        else
          this.velocity.Y -= 0.1f;
        if (flag2)
          this.velocity.Y -= 0.2f;
        if ((double) this.velocity.Y > 3.0)
          this.velocity.Y = 3f;
        else if ((double) this.velocity.Y < -4.0)
          this.velocity.Y = -4f;
      }
      if (!this.wet)
        return;
      if ((double) this.velocity.Y > 0.0)
        this.velocity.Y *= 0.95f;
      this.velocity.Y -= 0.5f;
      if ((double) this.velocity.Y < -4.0)
        this.velocity.Y = -4f;
      this.TargetClosest(true);
    }

    private void MimicAI()
    {
      if ((double) this.ai3 == 0.0)
      {
        this.position.X += 8f;
        this.aabb.X += 8;
        int num = this.aabb.Y >> 4;
        this.ai3 = num <= (int) Main.maxTilesY - 200 ? (num <= Main.worldSurface ? 1f : 2f) : 3f;
      }
      if ((double) this.ai0 == 0.0)
      {
        this.TargetClosest(true);
        if (Main.netMode == 1)
          return;
        if ((double) this.velocity.X != 0.0 || (double) this.velocity.Y < 0.0 || (double) this.velocity.Y > 0.3)
        {
          this.ai0 = 1f;
          this.netUpdate = true;
        }
        else
        {
          if (this.life >= this.lifeMax && !new Rectangle(this.aabb.X - 100, this.aabb.Y - 100, (int) this.width + 200, (int) this.height + 200).Intersects(Main.player[(int) this.target].aabb))
            return;
          this.ai0 = 1f;
          this.netUpdate = true;
        }
      }
      else if ((double) this.velocity.Y == 0.0)
      {
        ++this.ai2;
        int num = 20;
        if ((double) this.ai1 == 0.0)
          num = 12;
        if ((double) this.ai2 < (double) num)
        {
          this.velocity.X *= 0.9f;
        }
        else
        {
          this.ai2 = 0.0f;
          this.TargetClosest(true);
          this.spriteDirection = this.direction;
          ++this.ai1;
          if ((double) this.ai1 == 2.0)
          {
            this.velocity.X = (float) this.direction * 2.5f;
            this.velocity.Y = -8f;
            this.ai1 = 0.0f;
          }
          else
          {
            this.velocity.X = (float) this.direction * 3.5f;
            this.velocity.Y = -4f;
          }
          this.netUpdate = true;
        }
      }
      else if ((int) this.direction == 1 && (double) this.velocity.X < 1.0)
      {
        this.velocity.X += 0.1f;
      }
      else
      {
        if ((int) this.direction != -1 || (double) this.velocity.X <= -1.0)
          return;
        this.velocity.X -= 0.1f;
      }
    }

    private void UnicornAI()
    {
      int num = 30;
      bool flag = false;
      if ((double) this.velocity.Y == 0.0 && ((double) this.velocity.X > 0.0 && (int) this.direction < 0 || (double) this.velocity.X < 0.0 && (int) this.direction > 0))
      {
        flag = true;
        ++this.ai3;
      }
      if ((double) this.position.X == (double) this.oldPosition.X || (double) this.ai3 >= (double) num || flag)
        ++this.ai3;
      else if ((double) this.ai3 > 0.0)
        --this.ai3;
      if ((double) this.ai3 > (double) (num * 10))
        this.ai3 = 0.0f;
      if (this.justHit)
        this.ai3 = 0.0f;
      if ((double) this.ai3 == (double) num)
        this.netUpdate = true;
      if ((double) this.ai3 < (double) num)
      {
        this.TargetClosest(true);
      }
      else
      {
        if ((double) this.velocity.X == 0.0)
        {
          if ((double) this.velocity.Y == 0.0)
          {
            ++this.ai0;
            if ((double) this.ai0 >= 2.0)
            {
              this.direction = -this.direction;
              this.spriteDirection = this.direction;
              this.ai0 = 0.0f;
            }
          }
        }
        else
          this.ai0 = 0.0f;
        this.directionY = (sbyte) -1;
        if ((int) this.direction == 0)
          this.direction = (sbyte) 1;
      }
      if ((double) this.velocity.Y == 0.0 || this.wet || (double) this.velocity.X <= 0.0 && (int) this.direction < 0 || (double) this.velocity.X >= 0.0 && (int) this.direction > 0)
      {
        if ((double) this.velocity.X < -6.0 || (double) this.velocity.X > 6.0)
        {
          if ((double) this.velocity.Y == 0.0)
            this.velocity.X *= 0.8f;
        }
        else if ((double) this.velocity.X < 6.0 && (int) this.direction == 1)
        {
          this.velocity.X += 0.07f;
          if ((double) this.velocity.X > 6.0)
            this.velocity.X = 6f;
        }
        else if ((double) this.velocity.X > -6.0 && (int) this.direction == -1)
        {
          this.velocity.X -= 0.07f;
          if ((double) this.velocity.X < -6.0)
            this.velocity.X = -6f;
        }
      }
      if ((double) this.velocity.Y != 0.0)
        return;
      int index1 = (int) ((double) this.position.X + (double) this.velocity.X * 5.0) + ((int) this.width >> 1) + (((int) this.width >> 1) + 2) * (int) this.direction >> 4;
      int index2 = this.aabb.Y + (int) this.height - 15 >> 4;
      if (((double) this.velocity.X >= 0.0 || (int) this.spriteDirection != -1) && ((double) this.velocity.X <= 0.0 || (int) this.spriteDirection != 1))
        return;
      if ((int) Main.tile[index1, index2 - 2].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2 - 2].type])
      {
        if ((int) Main.tile[index1, index2 - 3].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2 - 3].type])
        {
          this.velocity.Y = -8.5f;
          this.netUpdate = true;
        }
        else
        {
          this.velocity.Y = -7.5f;
          this.netUpdate = true;
        }
      }
      else if ((int) Main.tile[index1, index2 - 1].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2 - 1].type])
      {
        this.velocity.Y = -7f;
        this.netUpdate = true;
      }
      else if ((int) Main.tile[index1, index2].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2].type])
      {
        this.velocity.Y = -6f;
        this.netUpdate = true;
      }
      else
      {
        if ((int) this.directionY >= 0 && (double) Math.Abs(this.velocity.X) <= 3.0 || (int) Main.tile[index1, index2 + 1].active != 0 && Main.tileSolid[(int) Main.tile[index1, index2 + 1].type] || (int) Main.tile[index1 + (int) this.direction, index2 + 1].active != 0 && Main.tileSolid[(int) Main.tile[index1 + (int) this.direction, index2 + 1].type])
          return;
        this.velocity.Y = -8f;
        this.netUpdate = true;
      }
    }

    private void WallOfFleshMouthAI()
    {
      if (this.aabb.X < 160 || this.aabb.X > ((int) Main.maxTilesX - 10) * 16)
      {
        this.active = (byte) 0;
      }
      else
      {
        if (this.localAI0 == 0)
        {
          this.localAI0 = 1;
          NPC.wofB = -1;
          NPC.wofT = -1;
        }
        ++this.ai1;
        if ((double) this.ai2 == 0.0)
        {
          if ((double) this.life < (double) this.lifeMax * 0.5)
            ++this.ai1;
          if ((double) this.life < (double) this.lifeMax * 0.2)
            ++this.ai1;
          if ((double) this.ai1 > 2700.0)
            this.ai2 = 1f;
        }
        if ((double) this.ai2 > 0.0 && (double) this.ai1 > 60.0)
        {
          int num = 3;
          if ((double) this.life < (double) this.lifeMax * 0.3)
            ++num;
          ++this.ai2;
          this.ai1 = 0.0f;
          if ((double) this.ai2 > (double) num)
            this.ai2 = 0.0f;
          if (Main.netMode != 1)
          {
            int index = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + ((int) this.height >> 1) + 20, 117, 1);
            Main.npc[index].velocity.X = (float) ((int) this.direction << 3);
          }
        }
        ++this.localAI3;
        if (this.localAI3 >= 600 + Main.rand.Next(1000))
        {
          this.localAI3 = -Main.rand.Next(200);
          Main.PlaySound(4, this.aabb.X, this.aabb.Y, 10);
        }
        NPC.wof = (int) this.whoAmI;
        int num1 = this.aabb.X >> 4;
        int num2 = this.aabb.X + (int) this.width >> 4;
        int num3 = this.aabb.Y + ((int) this.height >> 1) >> 4;
        int num4 = 0;
        int j1 = num3 + 7;
        while (num4 < 15 && j1 < (int) Main.maxTilesY - 10)
        {
          ++j1;
          for (int i = num1; i <= num2; ++i)
          {
            try
            {
              if (!WorldGen.SolidTile(i, j1))
              {
                if ((int) Main.tile[i, j1].liquid <= 0)
                  continue;
              }
              ++num4;
            }
            catch
            {
              num4 += 15;
            }
          }
        }
        int num5 = j1 + 4;
        if (NPC.wofB == -1)
          NPC.wofB = num5 * 16;
        else if (NPC.wofB > num5 * 16)
        {
          --NPC.wofB;
          if (NPC.wofB < num5 * 16)
            NPC.wofB = num5 * 16;
        }
        else if (NPC.wofB < num5 * 16)
        {
          ++NPC.wofB;
          if (NPC.wofB > num5 * 16)
            NPC.wofB = num5 * 16;
        }
        int num6 = 0;
        int j2 = num3 - 7;
        while (num6 < 15 && j2 > (int) Main.maxTilesY - 200)
        {
          --j2;
          for (int i = num1; i <= num2; ++i)
          {
            try
            {
              if (!WorldGen.SolidTile(i, j2))
              {
                if ((int) Main.tile[i, j2].liquid <= 0)
                  continue;
              }
              ++num6;
            }
            catch
            {
              num6 += 15;
            }
          }
        }
        int num7 = j2 - 4;
        if (NPC.wofT == -1)
          NPC.wofT = num7 * 16;
        else if (NPC.wofT > num7 * 16)
        {
          --NPC.wofT;
          if (NPC.wofT < num7 * 16)
            NPC.wofT = num7 * 16;
        }
        else if (NPC.wofT < num7 * 16)
        {
          ++NPC.wofT;
          if (NPC.wofT > num7 * 16)
            NPC.wofT = num7 * 16;
        }
        int num8 = (NPC.wofB + NPC.wofT >> 1) - ((int) this.height >> 1);
        this.velocity.Y = 0.0f;
        this.position.Y = (float) num8;
        this.aabb.Y = num8;
        float num9 = 1.5f;
        if (this.life < (this.lifeMax >> 1) + (this.lifeMax >> 2))
          num9 += 0.25f;
        if (this.life < this.lifeMax >> 1)
          num9 += 0.4f;
        if (this.life < this.lifeMax >> 2)
          num9 += 0.5f;
        if (this.life < this.lifeMax / 10)
          num9 += 0.6f;
        if ((double) this.velocity.X == 0.0)
        {
          this.TargetClosest(true);
          this.velocity.X = (float) this.direction;
        }
        if ((double) this.velocity.X < 0.0)
        {
          this.velocity.X = -num9;
          this.direction = (sbyte) -1;
        }
        else
        {
          this.velocity.X = num9;
          this.direction = (sbyte) 1;
        }
        this.spriteDirection = this.direction;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num10 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num11 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num12 = (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
        float num13 = num10 * num12;
        float num14 = num11 * num12;
        this.rotation = (int) this.direction <= 0 ? (Main.player[(int) this.target].aabb.X + 10 >= this.aabb.X + ((int) this.width >> 1) ? 0.0f : (float) Math.Atan2((double) num14, (double) num13) + 3.14f) : (Main.player[(int) this.target].aabb.X + 10 <= this.aabb.X + ((int) this.width >> 1) ? 0.0f : (float) Math.Atan2(-(double) num14, -(double) num13) + 3.14f);
        if (this.localAI0 != 1 || Main.netMode == 1)
          return;
        this.localAI0 = 2;
        int index1 = NPC.NewNPC(this.aabb.X, (NPC.wofB + NPC.wofT >> 1) + NPC.wofT >> 1, 114, (int) this.whoAmI);
        Main.npc[index1].ai0 = 1f;
        int index2 = NPC.NewNPC(this.aabb.X, (NPC.wofB + NPC.wofT >> 1) + NPC.wofB >> 1, 114, (int) this.whoAmI);
        Main.npc[index2].ai0 = -1f;
        int Y = (NPC.wofB + NPC.wofT >> 1) + NPC.wofB >> 1;
        for (int index3 = 0; index3 < 11; ++index3)
        {
          int index4 = NPC.NewNPC(this.aabb.X, Y, 115, (int) this.whoAmI);
          Main.npc[index4].ai0 = (float) ((double) index3 * 0.100000001490116 - 0.0500000007450581);
        }
      }
    }

    private void WallOfFleshEyesAI()
    {
      if (NPC.wof < 0)
      {
        this.active = (byte) 0;
      }
      else
      {
        this.realLife = NPC.wof;
        this.TargetClosest(true);
        this.position.X = Main.npc[NPC.wof].position.X;
        this.aabb.X = Main.npc[NPC.wof].aabb.X;
        this.direction = Main.npc[NPC.wof].direction;
        this.spriteDirection = this.direction;
        int num1 = NPC.wofB + NPC.wofT >> 1;
        int num2 = ((double) this.ai0 <= 0.0 ? num1 + NPC.wofB >> 1 : num1 + NPC.wofT >> 1) - ((int) this.height >> 1);
        if (this.aabb.Y > num2 + 1)
          this.velocity.Y = -1f;
        else if (this.aabb.Y < num2 - 1)
        {
          this.velocity.Y = 1f;
        }
        else
        {
          this.velocity.Y = 0.0f;
          this.aabb.Y = num2;
          this.position.Y = (float) num2;
        }
        if ((double) this.velocity.Y > 5.0)
          this.velocity.Y = 5f;
        else if ((double) this.velocity.Y < -5.0)
          this.velocity.Y = -5f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num3 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num4 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
        float num6 = num3 * num5;
        float num7 = num4 * num5;
        bool flag = true;
        if ((int) this.direction > 0)
        {
          if (Main.player[(int) this.target].aabb.X + 10 > this.aabb.X + ((int) this.width >> 1))
          {
            this.rotation = (float) Math.Atan2(-(double) num7, -(double) num6) + 3.14f;
          }
          else
          {
            this.rotation = 0.0f;
            flag = false;
          }
        }
        else if (Main.player[(int) this.target].aabb.X + 10 < this.aabb.X + ((int) this.width >> 1))
        {
          this.rotation = (float) Math.Atan2((double) num7, (double) num6) + 3.14f;
        }
        else
        {
          this.rotation = 0.0f;
          flag = false;
        }
        if (Main.netMode == 1)
          return;
        int num8 = 4;
        ++this.localAI1;
        if ((double) Main.npc[NPC.wof].life < (double) Main.npc[NPC.wof].lifeMax * 0.75)
        {
          ++this.localAI1;
          ++num8;
        }
        if ((double) Main.npc[NPC.wof].life < (double) Main.npc[NPC.wof].lifeMax * 0.5)
        {
          ++this.localAI1;
          ++num8;
        }
        if ((double) Main.npc[NPC.wof].life < (double) Main.npc[NPC.wof].lifeMax * 0.25)
        {
          ++this.localAI1;
          num8 += 2;
        }
        if ((double) Main.npc[NPC.wof].life < (double) Main.npc[NPC.wof].lifeMax * 0.1)
        {
          this.localAI1 += 2;
          num8 += 3;
        }
        if (this.localAI2 == 0)
        {
          if (this.localAI1 <= 600)
            return;
          this.localAI2 = 1;
          this.localAI1 = 0;
        }
        else
        {
          if (this.localAI1 <= 45 || !Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            return;
          this.localAI1 = 0;
          ++this.localAI2;
          if (this.localAI2 >= num8)
            this.localAI2 = 0;
          if (!flag)
            return;
          float num9 = 9f;
          int Damage = 11;
          if ((double) Main.npc[NPC.wof].life < (double) Main.npc[NPC.wof].lifeMax * 0.5)
          {
            ++Damage;
            ++num9;
          }
          if ((double) Main.npc[NPC.wof].life < (double) Main.npc[NPC.wof].lifeMax * 0.25)
          {
            ++Damage;
            ++num9;
          }
          if ((double) Main.npc[NPC.wof].life < (double) Main.npc[NPC.wof].lifeMax * 0.1)
          {
            Damage += 2;
            num9 += 2f;
          }
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num10 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num11 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num12 = (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
          float num13 = num9 / num12;
          float SpeedX = num10 * num13;
          float SpeedY = num11 * num13;
          vector2.X += SpeedX;
          vector2.Y += SpeedY;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 83, Damage, 0.0f, 8, true);
        }
      }
    }

    private void WallOfFleshTentacleAI()
    {
      if (NPC.wof < 0)
      {
        this.active = (byte) 0;
      }
      else
      {
        if (this.justHit)
          this.ai1 = 10f;
        this.TargetClosest(true);
        float num1 = 0.1f;
        float num2 = 300f;
        if (Main.npc[NPC.wof].life < Main.npc[NPC.wof].lifeMax >> 2)
        {
          this.damage = 75;
          this.defense = 40;
          num2 = 900f;
        }
        else if (Main.npc[NPC.wof].life < Main.npc[NPC.wof].lifeMax >> 1)
        {
          this.damage = 60;
          this.defense = 30;
          num2 = 700f;
        }
        else if (Main.npc[NPC.wof].life < (Main.npc[NPC.wof].lifeMax >> 1) + (Main.npc[NPC.wof].lifeMax >> 2))
        {
          this.damage = 45;
          this.defense = 20;
          num2 = 500f;
        }
        float x = Main.npc[NPC.wof].position.X + (float) ((int) Main.npc[NPC.wof].width >> 1);
        float num3 = Main.npc[NPC.wof].position.Y;
        float num4 = (float) (NPC.wofB - NPC.wofT);
        float y = (float) NPC.wofT + num4 * this.ai0;
        ++this.ai2;
        if ((double) this.ai2 > 100.0)
        {
          num2 = (float) (int) ((double) num2 * 1.29999995231628);
          if ((double) this.ai2 > 200.0)
            this.ai2 = 0.0f;
        }
        Vector2 vector2 = new Vector2(x, y);
        float num5 = Main.player[(int) this.target].position.X + 10f - (float) ((int) this.width >> 1) - vector2.X;
        float num6 = Main.player[(int) this.target].position.Y + 21f - (float) ((int) this.height >> 1) - vector2.Y;
        if ((double) this.ai1 == 0.0)
        {
          float num7 = (float) ((double) num5 * (double) num5 + (double) num6 * (double) num6);
          if ((double) num7 > (double) num2 * (double) num2)
          {
            float num8 = num2 / (float) Math.Sqrt((double) num7);
            num5 *= num8;
            num6 *= num8;
          }
          if ((double) this.position.X < (double) x + (double) num5)
          {
            this.velocity.X += num1;
            if ((double) this.velocity.X < 0.0 && (double) num5 > 0.0)
              this.velocity.X += num1 * 2.5f;
          }
          else if ((double) this.position.X > (double) x + (double) num5)
          {
            this.velocity.X -= num1;
            if ((double) this.velocity.X > 0.0 && (double) num5 < 0.0)
              this.velocity.X -= num1 * 2.5f;
          }
          if ((double) this.position.Y < (double) y + (double) num6)
          {
            this.velocity.Y += num1;
            if ((double) this.velocity.Y < 0.0 && (double) num6 > 0.0)
              this.velocity.Y += num1 * 2.5f;
          }
          else if ((double) this.position.Y > (double) y + (double) num6)
          {
            this.velocity.Y -= num1;
            if ((double) this.velocity.Y > 0.0 && (double) num6 < 0.0)
              this.velocity.Y -= num1 * 2.5f;
          }
          if ((double) this.velocity.X > 4.0)
            this.velocity.X = 4f;
          else if ((double) this.velocity.X < -4.0)
            this.velocity.X = -4f;
          if ((double) this.velocity.Y > 4.0)
            this.velocity.Y = 4f;
          else if ((double) this.velocity.Y < -4.0)
            this.velocity.Y = -4f;
        }
        else if ((double) this.ai1 > 0.0)
          --this.ai1;
        else
          this.ai1 = 0.0f;
        if ((double) num5 > 0.0)
        {
          this.spriteDirection = (sbyte) 1;
          this.rotation = (float) Math.Atan2((double) num6, (double) num5);
        }
        else if ((double) num5 < 0.0)
        {
          this.spriteDirection = (sbyte) -1;
          this.rotation = (float) (Math.Atan2((double) num6, (double) num5) + Math.PI);
        }
        Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + ((int) this.height >> 1) >> 4, new Vector3(0.3f, 0.2f, 0.1f));
      }
    }

    private unsafe void RetinazerAI()
    {
      if ((int) this.target == 8 || Main.player[(int) this.target].dead || (int) Main.player[(int) this.target].active == 0)
        this.TargetClosest(true);
      bool flag = Main.player[(int) this.target].dead;
      float num1 = (float) ((double) this.position.X + (double) ((int) this.width >> 1) - (double) Main.player[(int) this.target].position.X - 10.0);
      float num2 = (float) Math.Atan2((double) this.position.Y + (double) this.height - 59.0 - (double) Main.player[(int) this.target].position.Y - 21.0, (double) num1) + 1.57f;
      if ((double) num2 < 0.0)
        num2 += 6.283f;
      else if ((double) num2 > 6.28299999237061)
        num2 -= 6.283f;
      if ((double) this.rotation < (double) num2)
      {
        if ((double) num2 - (double) this.rotation > 3.1415)
          this.rotation -= 0.1f;
        else
          this.rotation += 0.1f;
      }
      else if ((double) this.rotation > (double) num2)
      {
        if ((double) this.rotation - (double) num2 > 3.1415)
          this.rotation += 0.1f;
        else
          this.rotation -= 0.1f;
      }
      if ((double) this.rotation > (double) num2 - 0.100000001490116 && (double) this.rotation < (double) num2 + 0.100000001490116)
        this.rotation = num2;
      if ((double) this.rotation < 0.0)
        this.rotation += 6.283f;
      else if ((double) this.rotation > 6.28299999237061)
        this.rotation -= 6.283f;
      if ((double) this.rotation > (double) num2 - 0.100000001490116 && (double) this.rotation < (double) num2 + 0.100000001490116)
        this.rotation = num2;
      if (Main.rand.Next(6) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 5, (double) this.velocity.X, 2.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.5f;
          dustPtr->velocity.Y *= 0.1f;
        }
      }
      if (Main.gameTime.dayTime || flag)
      {
        this.velocity.Y -= 0.04f;
        if (this.timeLeft <= 10)
          return;
        this.timeLeft = 10;
      }
      else if ((double) this.ai0 == 0.0)
      {
        if ((double) this.ai1 == 0.0)
        {
          float num3 = 7f;
          float num4 = 0.1f;
          int num5 = 1;
          if (this.aabb.X + ((int) this.width >> 1) < Main.player[(int) this.target].aabb.X + 20)
            num5 = -1;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num6 = Main.player[(int) this.target].position.X + 10f + (float) (num5 * 300) - vector2.X;
          float num7 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 300.0) - vector2.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num8;
          float num10 = num3 / num8;
          float num11 = num6 * num10;
          float num12 = num7 * num10;
          if ((double) this.velocity.X < (double) num11)
          {
            this.velocity.X += num4;
            if ((double) this.velocity.X < 0.0 && (double) num11 > 0.0)
              this.velocity.X += num4;
          }
          else if ((double) this.velocity.X > (double) num11)
          {
            this.velocity.X -= num4;
            if ((double) this.velocity.X > 0.0 && (double) num11 < 0.0)
              this.velocity.X -= num4;
          }
          if ((double) this.velocity.Y < (double) num12)
          {
            this.velocity.Y += num4;
            if ((double) this.velocity.Y < 0.0 && (double) num12 > 0.0)
              this.velocity.Y += num4;
          }
          else if ((double) this.velocity.Y > (double) num12)
          {
            this.velocity.Y -= num4;
            if ((double) this.velocity.Y > 0.0 && (double) num12 < 0.0)
              this.velocity.Y -= num4;
          }
          ++this.ai2;
          if ((double) this.ai2 >= 600.0)
          {
            this.ai1 = 1f;
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.target = (byte) 8;
            this.netUpdate = true;
          }
          else if (this.aabb.Y + (int) this.height < Main.player[(int) this.target].aabb.Y && (double) num9 < 400.0)
          {
            if (!Main.player[(int) this.target].dead)
              ++this.ai3;
            if ((double) this.ai3 >= 60.0)
            {
              this.ai3 = 0.0f;
              vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              float num13 = Main.player[(int) this.target].position.X + 10f - vector2.X;
              float num14 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
              if (Main.netMode != 1)
              {
                float num15 = 9f / (float) Math.Sqrt((double) num13 * (double) num13 + (double) num14 * (double) num14);
                float num16 = num13 * num15;
                float num17 = num14 * num15;
                float SpeedX = num16 + (float) Main.rand.Next(-40, 41) * 0.08f;
                float SpeedY = num17 + (float) Main.rand.Next(-40, 41) * 0.08f;
                vector2.X += SpeedX * 15f;
                vector2.Y += SpeedY * 15f;
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 83, 20, 0.0f, 8, true);
              }
            }
          }
        }
        else if ((double) this.ai1 == 1.0)
        {
          this.rotation = num2;
          float num3 = 12f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num4 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num5 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
          float num7 = num3 / num6;
          this.velocity.X = num4 * num7;
          this.velocity.Y = num5 * num7;
          this.ai1 = 2f;
        }
        else if ((double) this.ai1 == 2.0)
        {
          ++this.ai2;
          if ((double) this.ai2 >= 25.0)
          {
            this.velocity.X *= 0.96f;
            this.velocity.Y *= 0.96f;
            if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
              this.velocity.X = 0.0f;
            if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
              this.velocity.Y = 0.0f;
          }
          else
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
          if ((double) this.ai2 >= 70.0)
          {
            ++this.ai3;
            this.ai2 = 0.0f;
            this.target = (byte) 8;
            this.rotation = num2;
            if ((double) this.ai3 >= 4.0)
            {
              this.ai1 = 0.0f;
              this.ai3 = 0.0f;
            }
            else
              this.ai1 = 1f;
          }
        }
        if ((double) this.life >= (double) this.lifeMax * 0.5)
          return;
        this.ai0 = 1f;
        this.ai1 = 0.0f;
        this.ai2 = 0.0f;
        this.ai3 = 0.0f;
        this.netUpdate = true;
      }
      else if ((double) this.ai0 == 1.0 || (double) this.ai0 == 2.0)
      {
        if ((double) this.ai0 == 1.0)
        {
          this.ai2 += 0.005f;
          if ((double) this.ai2 > 0.5)
            this.ai2 = 0.5f;
        }
        else
        {
          this.ai2 -= 0.005f;
          if ((double) this.ai2 < 0.0)
            this.ai2 = 0.0f;
        }
        this.rotation += this.ai2;
        ++this.ai1;
        if ((double) this.ai1 == 100.0)
        {
          ++this.ai0;
          this.ai1 = 0.0f;
          if ((double) this.ai0 == 3.0)
          {
            this.ai2 = 0.0f;
          }
          else
          {
            Main.PlaySound(3, this.aabb.X, this.aabb.Y, 1);
            Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
            for (int index = 0; index < 2; ++index)
            {
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 143, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 6, 1.0);
            }
            int num3 = 0;
            while (num3 < 16 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.200000002980232, (double) Main.rand.Next(-30, 31) * 0.200000002980232, 0, new Color(), 1.0))
              ++num3;
          }
        }
        Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.200000002980232, (double) Main.rand.Next(-30, 31) * 0.200000002980232, 0, new Color(), 1.0);
        this.velocity.X *= 0.98f;
        this.velocity.Y *= 0.98f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        if ((double) this.velocity.Y <= -0.1 || (double) this.velocity.Y >= 0.1)
          return;
        this.velocity.Y = 0.0f;
      }
      else
      {
        this.damage = (int) ((double) this.defDamage * 1.5);
        this.defense = (int) this.defDefense + 15;
        this.soundHit = (short) 4;
        if ((double) this.ai1 == 0.0)
        {
          float num3 = 8f;
          float num4 = 0.15f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num5 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num6 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 300.0) - vector2.Y;
          float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
          float num8 = num3 / num7;
          float num9 = num5 * num8;
          float num10 = num6 * num8;
          if ((double) this.velocity.X < (double) num9)
          {
            this.velocity.X += num4;
            if ((double) this.velocity.X < 0.0 && (double) num9 > 0.0)
              this.velocity.X += num4;
          }
          else if ((double) this.velocity.X > (double) num9)
          {
            this.velocity.X -= num4;
            if ((double) this.velocity.X > 0.0 && (double) num9 < 0.0)
              this.velocity.X -= num4;
          }
          if ((double) this.velocity.Y < (double) num10)
          {
            this.velocity.Y += num4;
            if ((double) this.velocity.Y < 0.0 && (double) num10 > 0.0)
              this.velocity.Y += num4;
          }
          else if ((double) this.velocity.Y > (double) num10)
          {
            this.velocity.Y -= num4;
            if ((double) this.velocity.Y > 0.0 && (double) num10 < 0.0)
              this.velocity.Y -= num4;
          }
          ++this.ai2;
          if ((double) this.ai2 >= 300.0)
          {
            this.ai1 = 1f;
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.TargetClosest(true);
            this.netUpdate = true;
          }
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num11 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num12 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          this.rotation = (float) Math.Atan2((double) num12, (double) num11) - 1.57f;
          if (Main.netMode == 1)
            return;
          ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.75)
            ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.5)
            ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.25)
            ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.1)
            this.localAI1 += 2;
          if (this.localAI1 <= 140 || !Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            return;
          this.localAI1 = 0;
          float num13 = 9f / (float) Math.Sqrt((double) num11 * (double) num11 + (double) num12 * (double) num12);
          float SpeedX = num11 * num13;
          float SpeedY = num12 * num13;
          vector2.X += SpeedX * 15f;
          vector2.Y += SpeedY * 15f;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 100, 25, 0.0f, 8, true);
        }
        else
        {
          int num3 = 1;
          if (this.aabb.X + ((int) this.width >> 1) < Main.player[(int) this.target].aabb.X + 20)
            num3 = -1;
          float num4 = 8f;
          float num5 = 0.2f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num6 = Main.player[(int) this.target].position.X + 10f + (float) (num3 * 340) - vector2.X;
          float num7 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num4 / num8;
          float num10 = num6 * num9;
          float num11 = num7 * num9;
          if ((double) this.velocity.X < (double) num10)
          {
            this.velocity.X += num5;
            if ((double) this.velocity.X < 0.0 && (double) num10 > 0.0)
              this.velocity.X += num5;
          }
          else if ((double) this.velocity.X > (double) num10)
          {
            this.velocity.X -= num5;
            if ((double) this.velocity.X > 0.0 && (double) num10 < 0.0)
              this.velocity.X -= num5;
          }
          if ((double) this.velocity.Y < (double) num11)
          {
            this.velocity.Y += num5;
            if ((double) this.velocity.Y < 0.0 && (double) num11 > 0.0)
              this.velocity.Y += num5;
          }
          else if ((double) this.velocity.Y > (double) num11)
          {
            this.velocity.Y -= num5;
            if ((double) this.velocity.Y > 0.0 && (double) num11 < 0.0)
              this.velocity.Y -= num5;
          }
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num12 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num13 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          this.rotation = (float) Math.Atan2((double) num13, (double) num12) - 1.57f;
          if (Main.netMode != 1)
          {
            ++this.localAI1;
            if ((double) this.life < (double) this.lifeMax * 0.75)
              ++this.localAI1;
            if ((double) this.life < (double) this.lifeMax * 0.5)
              ++this.localAI1;
            if ((double) this.life < (double) this.lifeMax * 0.25)
              ++this.localAI1;
            if ((double) this.life < (double) this.lifeMax * 0.1)
              this.localAI1 += 2;
            if (this.localAI1 > 45 && Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            {
              this.localAI1 = 0;
              float num14 = 9f / (float) Math.Sqrt((double) num12 * (double) num12 + (double) num13 * (double) num13);
              float SpeedX = num12 * num14;
              float SpeedY = num13 * num14;
              vector2.X += SpeedX * 15f;
              vector2.Y += SpeedY * 15f;
              Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 100, 20, 0.0f, 8, true);
            }
          }
          ++this.ai2;
          if ((double) this.ai2 < 200.0)
            return;
          this.ai1 = 0.0f;
          this.ai2 = 0.0f;
          this.ai3 = 0.0f;
          this.TargetClosest(true);
          this.netUpdate = true;
        }
      }
    }

    private unsafe void SpazmatismAI()
    {
      if ((int) this.target == 8 || Main.player[(int) this.target].dead || (int) Main.player[(int) this.target].active == 0)
        this.TargetClosest(true);
      bool flag = Main.player[(int) this.target].dead;
      float num1 = (float) ((double) this.position.X + (double) ((int) this.width >> 1) - (double) Main.player[(int) this.target].position.X - 10.0);
      float num2 = (float) Math.Atan2((double) this.position.Y + (double) this.height - 59.0 - (double) Main.player[(int) this.target].position.Y - 21.0, (double) num1) + 1.57f;
      if ((double) num2 < 0.0)
        num2 += 6.283f;
      else if ((double) num2 > 6.28299999237061)
        num2 -= 6.283f;
      if ((double) this.rotation < (double) num2)
      {
        if ((double) num2 - (double) this.rotation > 3.1415)
          this.rotation -= 0.15f;
        else
          this.rotation += 0.15f;
      }
      else if ((double) this.rotation > (double) num2)
      {
        if ((double) this.rotation - (double) num2 > 3.1415)
          this.rotation += 0.15f;
        else
          this.rotation -= 0.15f;
      }
      if ((double) this.rotation > (double) num2 - 0.150000005960464 && (double) this.rotation < (double) num2 + 0.150000005960464)
        this.rotation = num2;
      if ((double) this.rotation < 0.0)
        this.rotation += 6.283f;
      else if ((double) this.rotation > 6.28299999237061)
        this.rotation -= 6.283f;
      if ((double) this.rotation > (double) num2 - 0.150000005960464 && (double) this.rotation < (double) num2 + 0.150000005960464)
        this.rotation = num2;
      if (Main.rand.Next(6) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 5, (double) this.velocity.X, 2.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.5f;
          dustPtr->velocity.Y *= 0.1f;
        }
      }
      if (Main.gameTime.dayTime || flag)
      {
        this.velocity.Y -= 0.04f;
        if (this.timeLeft <= 10)
          return;
        this.timeLeft = 10;
      }
      else if ((double) this.ai0 == 0.0)
      {
        if ((double) this.ai1 == 0.0)
        {
          this.TargetClosest(true);
          float num3 = 12f;
          float num4 = 0.4f;
          int num5 = 1;
          if (this.aabb.X + ((int) this.width >> 1) < Main.player[(int) this.target].aabb.X + 20)
            num5 = -1;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num6 = Main.player[(int) this.target].position.X + 10f + (float) (num5 * 400) - vector2.X;
          float num7 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num3 / num8;
          float num10 = num6 * num9;
          float num11 = num7 * num9;
          if ((double) this.velocity.X < (double) num10)
          {
            this.velocity.X += num4;
            if ((double) this.velocity.X < 0.0 && (double) num10 > 0.0)
              this.velocity.X += num4;
          }
          else if ((double) this.velocity.X > (double) num10)
          {
            this.velocity.X -= num4;
            if ((double) this.velocity.X > 0.0 && (double) num10 < 0.0)
              this.velocity.X -= num4;
          }
          if ((double) this.velocity.Y < (double) num11)
          {
            this.velocity.Y += num4;
            if ((double) this.velocity.Y < 0.0 && (double) num11 > 0.0)
              this.velocity.Y += num4;
          }
          else if ((double) this.velocity.Y > (double) num11)
          {
            this.velocity.Y -= num4;
            if ((double) this.velocity.Y > 0.0 && (double) num11 < 0.0)
              this.velocity.Y -= num4;
          }
          ++this.ai2;
          if ((double) this.ai2 >= 600.0)
          {
            this.ai1 = 1f;
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.target = (byte) 8;
            this.netUpdate = true;
          }
          else
          {
            if (!Main.player[(int) this.target].dead)
              ++this.ai3;
            if ((double) this.ai3 >= 60.0)
            {
              this.ai3 = 0.0f;
              vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
              float num12 = Main.player[(int) this.target].position.X + 10f - vector2.X;
              float num13 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
              if (Main.netMode != 1)
              {
                float num14 = 12f / (float) Math.Sqrt((double) num12 * (double) num12 + (double) num13 * (double) num13);
                float num15 = num12 * num14;
                float num16 = num13 * num14;
                float SpeedX = num15 + (float) Main.rand.Next(-40, 41) * 0.05f;
                float SpeedY = num16 + (float) Main.rand.Next(-40, 41) * 0.05f;
                vector2.X += SpeedX * 4f;
                vector2.Y += SpeedY * 4f;
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 96, 25, 0.0f, 8, true);
              }
            }
          }
        }
        else if ((double) this.ai1 == 1.0)
        {
          this.rotation = num2;
          float num3 = 13f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num4 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num5 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
          float num7 = num3 / num6;
          this.velocity.X = num4 * num7;
          this.velocity.Y = num5 * num7;
          this.ai1 = 2f;
        }
        else if ((double) this.ai1 == 2.0)
        {
          ++this.ai2;
          if ((double) this.ai2 >= 8.0)
          {
            this.velocity.X *= 0.9f;
            this.velocity.Y *= 0.9f;
            if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
              this.velocity.X = 0.0f;
            if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
              this.velocity.Y = 0.0f;
          }
          else
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
          if ((double) this.ai2 >= 42.0)
          {
            ++this.ai3;
            this.ai2 = 0.0f;
            this.target = (byte) 8;
            this.rotation = num2;
            if ((double) this.ai3 >= 10.0)
            {
              this.ai1 = 0.0f;
              this.ai3 = 0.0f;
            }
            else
              this.ai1 = 1f;
          }
        }
        if ((double) this.life >= (double) this.lifeMax * 0.5)
          return;
        this.ai0 = 1f;
        this.ai1 = 0.0f;
        this.ai2 = 0.0f;
        this.ai3 = 0.0f;
        this.netUpdate = true;
      }
      else if ((double) this.ai0 == 1.0 || (double) this.ai0 == 2.0)
      {
        if ((double) this.ai0 == 1.0)
        {
          this.ai2 += 0.005f;
          if ((double) this.ai2 > 0.5)
            this.ai2 = 0.5f;
        }
        else
        {
          this.ai2 -= 0.005f;
          if ((double) this.ai2 < 0.0)
            this.ai2 = 0.0f;
        }
        this.rotation += this.ai2;
        ++this.ai1;
        if ((double) this.ai1 == 100.0)
        {
          ++this.ai0;
          this.ai1 = 0.0f;
          if ((double) this.ai0 == 3.0)
          {
            this.ai2 = 0.0f;
          }
          else
          {
            Main.PlaySound(3, this.aabb.X, this.aabb.Y, 1);
            Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
            for (int index = 0; index < 2; ++index)
            {
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 144, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 6, 1.0);
            }
            int num3 = 0;
            while (num3 < 16 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.200000002980232, (double) Main.rand.Next(-30, 31) * 0.200000002980232, 0, new Color(), 1.0))
              ++num3;
          }
        }
        Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.200000002980232, (double) Main.rand.Next(-30, 31) * 0.200000002980232, 0, new Color(), 1.0);
        this.velocity.X *= 0.98f;
        this.velocity.Y *= 0.98f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        if ((double) this.velocity.Y <= -0.1 || (double) this.velocity.Y >= 0.1)
          return;
        this.velocity.Y = 0.0f;
      }
      else
      {
        this.soundHit = (short) 4;
        this.damage = this.defDamage + (this.defDamage >> 1);
        this.defense = (int) this.defDefense + 25;
        if ((double) this.ai1 == 0.0)
        {
          float num3 = 4f;
          float num4 = 0.1f;
          int num5 = 1;
          if (this.aabb.X + ((int) this.width >> 1) < Main.player[(int) this.target].aabb.X + 20)
            num5 = -1;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num6 = Main.player[(int) this.target].position.X + 10f + (float) (num5 * 180) - vector2.X;
          float num7 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num3 / num8;
          float num10 = num6 * num9;
          float num11 = num7 * num9;
          if ((double) this.velocity.X < (double) num10)
          {
            this.velocity.X += num4;
            if ((double) this.velocity.X < 0.0 && (double) num10 > 0.0)
              this.velocity.X += num4;
          }
          else if ((double) this.velocity.X > (double) num10)
          {
            this.velocity.X -= num4;
            if ((double) this.velocity.X > 0.0 && (double) num10 < 0.0)
              this.velocity.X -= num4;
          }
          if ((double) this.velocity.Y < (double) num11)
          {
            this.velocity.Y += num4;
            if ((double) this.velocity.Y < 0.0 && (double) num11 > 0.0)
              this.velocity.Y += num4;
          }
          else if ((double) this.velocity.Y > (double) num11)
          {
            this.velocity.Y -= num4;
            if ((double) this.velocity.Y > 0.0 && (double) num11 < 0.0)
              this.velocity.Y -= num4;
          }
          ++this.ai2;
          if ((double) this.ai2 >= 400.0)
          {
            this.ai1 = 1f;
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.target = (byte) 8;
            this.netUpdate = true;
          }
          if (!Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            return;
          ++this.localAI2;
          if (this.localAI2 > 22)
          {
            this.localAI2 = 0;
            Main.PlaySound(2, this.aabb.X, this.aabb.Y, 34);
          }
          if (Main.netMode == 1)
            return;
          ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.75)
            ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.5)
            ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.25)
            ++this.localAI1;
          if ((double) this.life < (double) this.lifeMax * 0.100000001490116)
            this.localAI1 += 2;
          if (this.localAI1 <= 8)
            return;
          this.localAI1 = 0;
          vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num12 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num13 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num14 = 6f / (float) Math.Sqrt((double) num12 * (double) num12 + (double) num13 * (double) num13);
          float num15 = num12 * num14;
          float num16 = num13 * num14 + (float) Main.rand.Next(-40, 41) * 0.01f;
          float num17 = num15 + (float) Main.rand.Next(-40, 41) * 0.01f;
          float SpeedY = num16 + this.velocity.Y * 0.5f;
          float SpeedX = num17 + this.velocity.X * 0.5f;
          vector2.X -= SpeedX * 1f;
          vector2.Y -= SpeedY * 1f;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 101, 30, 0.0f, 8, true);
        }
        else if ((double) this.ai1 == 1.0)
        {
          Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
          this.rotation = num2;
          float num3 = 14f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num4 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num5 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
          float num7 = num3 / num6;
          this.velocity.X = num4 * num7;
          this.velocity.Y = num5 * num7;
          this.ai1 = 2f;
        }
        else
        {
          if ((double) this.ai1 != 2.0)
            return;
          ++this.ai2;
          if ((double) this.ai2 >= 50.0)
          {
            this.velocity.X *= 0.93f;
            this.velocity.Y *= 0.93f;
            if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
              this.velocity.X = 0.0f;
            if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
              this.velocity.Y = 0.0f;
          }
          else
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
          if ((double) this.ai2 < 80.0)
            return;
          ++this.ai3;
          this.ai2 = 0.0f;
          this.target = (byte) 8;
          this.rotation = num2;
          if ((double) this.ai3 >= 6.0)
          {
            this.ai1 = 0.0f;
            this.ai3 = 0.0f;
          }
          else
            this.ai1 = 1f;
        }
      }
    }

    private void SkeletronPrimeAI()
    {
      this.damage = this.defDamage;
      this.defense = (int) this.defDefense;
      if ((double) this.ai0 == 0.0 && Main.netMode != 1)
      {
        this.TargetClosest(true);
        this.ai0 = 1f;
        if ((int) this.type != 68)
        {
          int index1 = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + ((int) this.height >> 1), 128, (int) this.whoAmI);
          Main.npc[index1].ai0 = -1f;
          Main.npc[index1].ai1 = (float) this.whoAmI;
          Main.npc[index1].target = this.target;
          Main.npc[index1].netUpdate = true;
          int index2 = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + ((int) this.height >> 1), 129, (int) this.whoAmI);
          Main.npc[index2].ai0 = 1f;
          Main.npc[index2].ai1 = (float) this.whoAmI;
          Main.npc[index2].target = this.target;
          Main.npc[index2].netUpdate = true;
          int index3 = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + ((int) this.height >> 1), 130, (int) this.whoAmI);
          Main.npc[index3].ai0 = -1f;
          Main.npc[index3].ai1 = (float) this.whoAmI;
          Main.npc[index3].target = this.target;
          Main.npc[index3].ai3 = 150f;
          Main.npc[index3].netUpdate = true;
          int index4 = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + ((int) this.height >> 1), 131, (int) this.whoAmI);
          Main.npc[index4].ai0 = 1f;
          Main.npc[index4].ai1 = (float) this.whoAmI;
          Main.npc[index4].target = this.target;
          Main.npc[index4].netUpdate = true;
          Main.npc[index4].ai3 = 150f;
        }
      }
      if ((int) this.type == 68 && (double) this.ai1 != 3.0 && (double) this.ai1 != 2.0)
      {
        Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
        this.ai1 = 2f;
      }
      if (Main.player[(int) this.target].dead || Math.Abs(this.aabb.X - Main.player[(int) this.target].aabb.X) > 6000 || Math.Abs(this.aabb.Y - Main.player[(int) this.target].aabb.Y) > 6000)
      {
        this.TargetClosest(true);
        if (Main.player[(int) this.target].dead || Math.Abs(this.aabb.X - Main.player[(int) this.target].aabb.X) > 6000 || Math.Abs(this.aabb.Y - Main.player[(int) this.target].aabb.Y) > 6000)
          this.ai1 = 3f;
      }
      if (Main.gameTime.dayTime && (double) this.ai1 != 3.0 && (double) this.ai1 != 2.0)
      {
        this.ai1 = 2f;
        Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
      }
      if ((double) this.ai1 == 0.0)
      {
        ++this.ai2;
        if ((double) this.ai2 >= 600.0)
        {
          this.ai2 = 0.0f;
          this.ai1 = 1f;
          this.TargetClosest(true);
          this.netUpdate = true;
        }
        this.rotation = this.velocity.X * 0.06666667f;
        if (this.aabb.Y > Main.player[(int) this.target].aabb.Y - 200)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.98f;
          this.velocity.Y -= 0.1f;
          if ((double) this.velocity.Y > 2.0)
            this.velocity.Y = 2f;
        }
        else if (this.aabb.Y < Main.player[(int) this.target].aabb.Y - 500)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.98f;
          this.velocity.Y += 0.1f;
          if ((double) this.velocity.Y < -2.0)
            this.velocity.Y = -2f;
        }
        if (this.aabb.X + ((int) this.width >> 1) > Main.player[(int) this.target].aabb.X + 10 + 100)
        {
          if ((double) this.velocity.X > 0.0)
            this.velocity.X *= 0.98f;
          this.velocity.X -= 0.1f;
          if ((double) this.velocity.X <= 8.0)
            return;
          this.velocity.X = 8f;
        }
        else
        {
          if (this.aabb.X + ((int) this.width >> 1) >= Main.player[(int) this.target].aabb.X + 10 - 100)
            return;
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.98f;
          this.velocity.X += 0.1f;
          if ((double) this.velocity.X >= -8.0)
            return;
          this.velocity.X = -8f;
        }
      }
      else if ((double) this.ai1 == 1.0)
      {
        this.defense *= 2;
        this.damage *= 2;
        ++this.ai2;
        if ((double) this.ai2 == 2.0)
          Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
        if ((double) this.ai2 >= 400.0)
        {
          this.ai2 = 0.0f;
          this.ai1 = 0.0f;
        }
        this.rotation += (float) this.direction * 0.3f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num3 = 2f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        this.velocity.X = num1 * num3;
        this.velocity.Y = num2 * num3;
      }
      else if ((double) this.ai1 == 2.0)
      {
        this.damage = 9999;
        this.defense = 9999;
        this.rotation += (float) this.direction * 0.3f;
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num3 = 8f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        this.velocity.X = num1 * num3;
        this.velocity.Y = num2 * num3;
      }
      else
      {
        if ((double) this.ai1 != 3.0)
          return;
        this.velocity.Y += 0.1f;
        if ((double) this.velocity.Y < 0.0)
          this.velocity.Y *= 0.95f;
        this.velocity.X *= 0.95f;
        if (this.timeLeft <= 500)
          return;
        this.timeLeft = 500;
      }
    }

    private void SkeletronPrimeSawHand()
    {
      Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
      float num1 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2_1.X;
      float num2 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_1.Y;
      float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
      if ((double) this.ai2 != 99.0)
      {
        if ((double) num3 > 800.0)
          this.ai2 = 99f;
      }
      else if ((double) num3 < 400.0)
        this.ai2 = 0.0f;
      this.spriteDirection = (sbyte) -(double) this.ai0;
      if ((int) Main.npc[(int) this.ai1].active == 0 || (int) Main.npc[(int) this.ai1].aiStyle != 32)
      {
        this.ai2 += 10f;
        if ((double) this.ai2 > 50.0 || Main.netMode != 2)
        {
          this.life = -1;
          this.HitEffect(0, 10.0);
          this.active = (byte) 0;
          return;
        }
      }
      if ((double) this.ai2 == 99.0)
      {
        if (this.aabb.Y > Main.npc[(int) this.ai1].aabb.Y)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.96f;
          this.velocity.Y -= 0.1f;
          if ((double) this.velocity.Y > 8.0)
            this.velocity.Y = 8f;
        }
        else if (this.aabb.Y < Main.npc[(int) this.ai1].aabb.Y)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.96f;
          this.velocity.Y += 0.1f;
          if ((double) this.velocity.Y < -8.0)
            this.velocity.Y = -8f;
        }
        if (this.aabb.X + ((int) this.width >> 1) > Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1))
        {
          if ((double) this.velocity.X > 0.0)
            this.velocity.X *= 0.96f;
          this.velocity.X -= 0.5f;
          if ((double) this.velocity.X <= 12.0)
            return;
          this.velocity.X = 12f;
        }
        else
        {
          if (this.aabb.X + ((int) this.width >> 1) >= Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1))
            return;
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.96f;
          this.velocity.X += 0.5f;
          if ((double) this.velocity.X >= -12.0)
            return;
          this.velocity.X = -12f;
        }
      }
      else if ((double) this.ai2 == 0.0 || (double) this.ai2 == 3.0)
      {
        if ((double) Main.npc[(int) this.ai1].ai1 == 3.0 && this.timeLeft > 10)
          this.timeLeft = 10;
        if ((double) Main.npc[(int) this.ai1].ai1 != 0.0)
        {
          this.TargetClosest(true);
          if (Main.player[(int) this.target].dead)
          {
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y > 16.0)
              this.velocity.Y = 16f;
          }
          else
          {
            Vector2 vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num4 = Main.player[(int) this.target].position.X + 10f - vector2_2.X;
            float num5 = Main.player[(int) this.target].position.Y + 21f - vector2_2.Y;
            float num6 = 7f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
            float num7 = num4 * num6;
            float num8 = num5 * num6;
            this.rotation = (float) Math.Atan2((double) num8, (double) num7) - 1.57f;
            if ((double) this.velocity.X > (double) num7)
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X *= 0.97f;
              this.velocity.X -= 0.05f;
            }
            if ((double) this.velocity.X < (double) num7)
            {
              if ((double) this.velocity.X < 0.0)
                this.velocity.X *= 0.97f;
              this.velocity.X += 0.05f;
            }
            if ((double) this.velocity.Y > (double) num8)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y *= 0.97f;
              this.velocity.Y -= 0.05f;
            }
            if ((double) this.velocity.Y < (double) num8)
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y *= 0.97f;
              this.velocity.Y += 0.05f;
            }
          }
          ++this.ai3;
          if ((double) this.ai3 >= 600.0)
          {
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.netUpdate = true;
          }
        }
        else
        {
          ++this.ai3;
          if ((double) this.ai3 >= 300.0)
          {
            ++this.ai2;
            this.ai3 = 0.0f;
            this.netUpdate = true;
          }
          if (this.aabb.Y > Main.npc[(int) this.ai1].aabb.Y + 320)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
          }
          else if (this.aabb.Y < Main.npc[(int) this.ai1].aabb.Y + 260)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -3.0)
              this.velocity.Y = -3f;
          }
          if (this.aabb.X + ((int) this.width >> 1) > Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1))
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.3f;
            if ((double) this.velocity.X > 12.0)
              this.velocity.X = 12f;
          }
          else if (this.aabb.X + ((int) this.width >> 1) < Main.npc[(int) this.ai1].aabb.X + ((int) Main.npc[(int) this.ai1].width >> 1) - 250)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X += 0.3f;
            if ((double) this.velocity.X < -12.0)
              this.velocity.X = -12f;
          }
        }
        Vector2 vector2_3 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num9 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2_3.X;
        float num10 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_3.Y;
        Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
        this.rotation = (float) Math.Atan2((double) num10, (double) num9) + 1.57f;
      }
      else if ((double) this.ai2 == 1.0)
      {
        Vector2 vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num4 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2_2.X;
        float num5 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_2.Y;
        float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
        this.rotation = (float) Math.Atan2((double) num5, (double) num4) + 1.57f;
        this.velocity.X *= 0.95f;
        this.velocity.Y -= 0.1f;
        if ((double) this.velocity.Y < -8.0)
          this.velocity.Y = -8f;
        if (this.aabb.Y >= Main.npc[(int) this.ai1].aabb.Y - 200)
          return;
        this.TargetClosest(true);
        this.ai2 = 2f;
        vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num7 = Main.player[(int) this.target].position.X + 10f - vector2_2.X;
        float num8 = Main.player[(int) this.target].position.Y + 21f - vector2_2.Y;
        float num9 = 22f / (float) Math.Sqrt((double) num7 * (double) num7 + (double) num8 * (double) num8);
        this.velocity.X = num7 * num9;
        this.velocity.Y = num8 * num9;
        this.netUpdate = true;
      }
      else if ((double) this.ai2 == 2.0)
      {
        if ((double) this.velocity.Y >= 0.0 && this.aabb.Y <= Main.player[(int) this.target].aabb.Y)
          return;
        this.ai2 = 3f;
      }
      else if ((double) this.ai2 == 4.0)
      {
        this.TargetClosest(true);
        Vector2 vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num4 = Main.player[(int) this.target].position.X + 10f - vector2_2.X;
        float num5 = Main.player[(int) this.target].position.Y + 21f - vector2_2.Y;
        float num6 = 7f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
        float num7 = num4 * num6;
        float num8 = num5 * num6;
        if ((double) this.velocity.X > (double) num7)
        {
          if ((double) this.velocity.X > 0.0)
            this.velocity.X *= 0.97f;
          this.velocity.X -= 0.05f;
        }
        if ((double) this.velocity.X < (double) num7)
        {
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.97f;
          this.velocity.X += 0.05f;
        }
        if ((double) this.velocity.Y > (double) num8)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.97f;
          this.velocity.Y -= 0.05f;
        }
        if ((double) this.velocity.Y < (double) num8)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.97f;
          this.velocity.Y += 0.05f;
        }
        ++this.ai3;
        if ((double) this.ai3 >= 600.0)
        {
          this.ai2 = 0.0f;
          this.ai3 = 0.0f;
          this.netUpdate = true;
        }
        vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num9 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2_2.X;
        float num10 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_2.Y;
        float num11 = (float) Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
        this.rotation = (float) Math.Atan2((double) num10, (double) num9) + 1.57f;
      }
      else
      {
        if ((double) this.ai2 != 5.0 || ((double) this.velocity.X <= 0.0 || this.aabb.X + ((int) this.width >> 1) <= Main.player[(int) this.target].aabb.X + 10) && ((double) this.velocity.X >= 0.0 || this.aabb.X + ((int) this.width >> 1) >= Main.player[(int) this.target].aabb.X + 10))
          return;
        this.ai2 = 0.0f;
      }
    }

    private void SkeletronPrimeViceHand()
    {
      this.spriteDirection = (sbyte) -(double) this.ai0;
      Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
      float num1 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2_1.X;
      float num2 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_1.Y;
      float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
      if ((double) this.ai2 != 99.0)
      {
        if ((double) num3 > 800.0)
          this.ai2 = 99f;
      }
      else if ((double) num3 < 400.0)
        this.ai2 = 0.0f;
      if ((int) Main.npc[(int) this.ai1].active == 0 || (int) Main.npc[(int) this.ai1].aiStyle != 32)
      {
        this.ai2 += 10f;
        if ((double) this.ai2 > 50.0 || Main.netMode != 2)
        {
          this.life = -1;
          this.HitEffect(0, 10.0);
          this.active = (byte) 0;
          return;
        }
      }
      if ((double) this.ai2 == 99.0)
      {
        if ((double) this.position.Y > (double) Main.npc[(int) this.ai1].position.Y)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.96f;
          this.velocity.Y -= 0.1f;
          if ((double) this.velocity.Y > 8.0)
            this.velocity.Y = 8f;
        }
        else if ((double) this.position.Y < (double) Main.npc[(int) this.ai1].position.Y)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.96f;
          this.velocity.Y += 0.1f;
          if ((double) this.velocity.Y < -8.0)
            this.velocity.Y = -8f;
        }
        if ((double) this.position.X + (double) ((int) this.width >> 1) > (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1))
        {
          if ((double) this.velocity.X > 0.0)
            this.velocity.X *= 0.96f;
          this.velocity.X -= 0.5f;
          if ((double) this.velocity.X > 12.0)
            this.velocity.X = 12f;
        }
        if ((double) this.position.X + (double) ((int) this.width >> 1) >= (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1))
          return;
        if ((double) this.velocity.X < 0.0)
          this.velocity.X *= 0.96f;
        this.velocity.X += 0.5f;
        if ((double) this.velocity.X >= -12.0)
          return;
        this.velocity.X = -12f;
      }
      else if ((double) this.ai2 == 0.0 || (double) this.ai2 == 3.0)
      {
        if ((double) Main.npc[(int) this.ai1].ai1 == 3.0 && this.timeLeft > 10)
          this.timeLeft = 10;
        if ((double) Main.npc[(int) this.ai1].ai1 != 0.0)
        {
          this.TargetClosest(true);
          this.TargetClosest(true);
          if (Main.player[(int) this.target].dead)
          {
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y > 16.0)
              this.velocity.Y = 16f;
          }
          else
          {
            Vector2 vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num4 = Main.player[(int) this.target].position.X + 10f - vector2_2.X;
            float num5 = Main.player[(int) this.target].position.Y + 21f - vector2_2.Y;
            float num6 = 12f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
            float num7 = num4 * num6;
            float num8 = num5 * num6;
            this.rotation = (float) Math.Atan2((double) num8, (double) num7) - 1.57f;
            if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < 2.0)
            {
              this.rotation = (float) Math.Atan2((double) num8, (double) num7) - 1.57f;
              this.velocity.X = num7;
              this.velocity.Y = num8;
              this.netUpdate = true;
            }
            else
            {
              this.velocity.X *= 0.97f;
              this.velocity.Y *= 0.97f;
            }
            ++this.ai3;
            if ((double) this.ai3 >= 600.0)
            {
              this.ai2 = 0.0f;
              this.ai3 = 0.0f;
              this.netUpdate = true;
            }
          }
        }
        else
        {
          ++this.ai3;
          if ((double) this.ai3 >= 600.0)
          {
            ++this.ai2;
            this.ai3 = 0.0f;
            this.netUpdate = true;
          }
          if ((double) this.position.Y > (double) Main.npc[(int) this.ai1].position.Y + 300.0)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.1f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
          }
          else if ((double) this.position.Y < (double) Main.npc[(int) this.ai1].position.Y + 230.0)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y < -3.0)
              this.velocity.Y = -3f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) > (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) + 250.0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.94f;
            this.velocity.X -= 0.3f;
            if ((double) this.velocity.X > 9.0)
              this.velocity.X = 9f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) < (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1))
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.94f;
            this.velocity.X += 0.2f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        Vector2 vector2_3 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num9 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2_3.X;
        float num10 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_3.Y;
        Math.Sqrt((double) num9 * (double) num9 + (double) num10 * (double) num10);
        this.rotation = (float) Math.Atan2((double) num10, (double) num9) + 1.57f;
      }
      else if ((double) this.ai2 == 1.0)
      {
        if ((double) this.velocity.Y > 0.0)
          this.velocity.Y *= 0.9f;
        Vector2 vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num4 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 280.0 * (double) this.ai0) - vector2_2.X;
        float num5 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_2.Y;
        float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
        this.rotation = (float) Math.Atan2((double) num5, (double) num4) + 1.57f;
        this.velocity.X = (float) (((double) this.velocity.X * 5.0 + (double) Main.npc[(int) this.ai1].velocity.X) / 6.0);
        this.velocity.X += 0.5f;
        this.velocity.Y -= 0.5f;
        if ((double) this.velocity.Y < -9.0)
          this.velocity.Y = -9f;
        if ((double) this.position.Y >= (double) Main.npc[(int) this.ai1].position.Y - 280.0)
          return;
        this.TargetClosest(true);
        this.ai2 = 2f;
        vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num7 = Main.player[(int) this.target].position.X + 10f - vector2_2.X;
        float num8 = Main.player[(int) this.target].position.Y + 21f - vector2_2.Y;
        float num9 = 20f / (float) Math.Sqrt((double) num7 * (double) num7 + (double) num8 * (double) num8);
        this.velocity.X = num7 * num9;
        this.velocity.Y = num8 * num9;
        this.netUpdate = true;
      }
      else if ((double) this.ai2 == 2.0)
      {
        if ((double) this.position.Y <= (double) Main.player[(int) this.target].position.Y && (double) this.velocity.Y >= 0.0)
          return;
        if ((double) this.ai3 >= 4.0)
        {
          this.ai2 = 3f;
          this.ai3 = 0.0f;
        }
        else
        {
          this.ai2 = 1f;
          ++this.ai3;
        }
      }
      else if ((double) this.ai2 == 4.0)
      {
        Vector2 vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num4 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2_2.X;
        float num5 = Main.npc[(int) this.ai1].position.Y + 230f - vector2_2.Y;
        float num6 = (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
        this.rotation = (float) Math.Atan2((double) num5, (double) num4) + 1.57f;
        this.velocity.Y = (float) (((double) this.velocity.Y * 5.0 + (double) Main.npc[(int) this.ai1].velocity.Y) / 6.0);
        this.velocity.X += 0.5f;
        if ((double) this.velocity.X > 12.0)
          this.velocity.X = 12f;
        if ((double) this.position.X + (double) ((int) this.width >> 1) >= (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 500.0 && (double) this.position.X + (double) ((int) this.width >> 1) <= (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) + 500.0)
          return;
        this.TargetClosest(true);
        this.ai2 = 5f;
        vector2_2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num7 = Main.player[(int) this.target].position.X + 10f - vector2_2.X;
        float num8 = Main.player[(int) this.target].position.Y + 21f - vector2_2.Y;
        float num9 = 17f / (float) Math.Sqrt((double) num7 * (double) num7 + (double) num8 * (double) num8);
        this.velocity.X = num7 * num9;
        this.velocity.Y = num8 * num9;
        this.netUpdate = true;
      }
      else
      {
        if ((double) this.ai2 != 5.0 || (double) this.position.X + (double) ((int) this.width >> 1) >= (double) Main.player[(int) this.target].position.X + 10.0 - 100.0)
          return;
        if ((double) this.ai3 >= 4.0)
        {
          this.ai2 = 0.0f;
          this.ai3 = 0.0f;
        }
        else
        {
          this.ai2 = 4f;
          ++this.ai3;
        }
      }
    }

    private void SkeletronPrimeCannonHand()
    {
      this.spriteDirection = (sbyte) -(double) this.ai0;
      if ((int) Main.npc[(int) this.ai1].active == 0 || (int) Main.npc[(int) this.ai1].aiStyle != 32)
      {
        this.ai2 += 10f;
        if ((double) this.ai2 > 50.0 || Main.netMode != 2)
        {
          this.life = -1;
          this.HitEffect(0, 10.0);
          this.active = (byte) 0;
          return;
        }
      }
      if ((double) this.ai2 == 0.0)
      {
        if ((double) Main.npc[(int) this.ai1].ai1 == 3.0 && this.timeLeft > 10)
          this.timeLeft = 10;
        if ((double) Main.npc[(int) this.ai1].ai1 != 0.0)
        {
          this.localAI0 += 2;
          if ((double) this.position.Y > (double) Main.npc[(int) this.ai1].position.Y - 100.0)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.07f;
            if ((double) this.velocity.Y > 6.0)
              this.velocity.Y = 6f;
          }
          else if ((double) this.position.Y < (double) Main.npc[(int) this.ai1].position.Y - 100.0)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.07f;
            if ((double) this.velocity.Y < -6.0)
              this.velocity.Y = -6f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) > (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 120.0 * (double) this.ai0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) < (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 120.0 * (double) this.ai0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        else
        {
          ++this.ai3;
          if ((double) this.ai3 >= 1100.0)
          {
            this.localAI0 = 0;
            this.ai2 = 1f;
            this.ai3 = 0.0f;
            this.netUpdate = true;
          }
          if ((double) this.position.Y > (double) Main.npc[(int) this.ai1].position.Y - 150.0)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.04f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
          }
          else if ((double) this.position.Y < (double) Main.npc[(int) this.ai1].position.Y - 150.0)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.04f;
            if ((double) this.velocity.Y < -3.0)
              this.velocity.Y = -3f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) > (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) + 200.0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.2f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) < (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) + 160.0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X += 0.2f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = (float) ((double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 200.0 * (double) this.ai0) - vector2.X;
        float num2 = Main.npc[(int) this.ai1].position.Y + 230f - vector2.Y;
        float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        this.rotation = (float) Math.Atan2((double) num2, (double) num1) + 1.57f;
        if (Main.netMode == 1)
          return;
        ++this.localAI0;
        if (this.localAI0 <= 140)
          return;
        this.localAI0 = 0;
        float num4 = 12f / num3;
        float num5 = -num1 * num4;
        float num6 = -num2 * num4;
        float SpeedX = num5 + (float) Main.rand.Next(-40, 41) * 0.01f;
        float SpeedY = num6 + (float) Main.rand.Next(-40, 41) * 0.01f;
        vector2.X += SpeedX * 4f;
        vector2.Y += SpeedY * 4f;
        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 102, 0, 0.0f, 8, true);
      }
      else
      {
        if ((double) this.ai2 != 1.0)
          return;
        ++this.ai3;
        if ((double) this.ai3 >= 300.0)
        {
          this.localAI0 = 0;
          this.ai2 = 0.0f;
          this.ai3 = 0.0f;
          this.netUpdate = true;
        }
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.npc[(int) this.ai1].position.X + (float) ((int) Main.npc[(int) this.ai1].width >> 1) - vector2.X;
        float num2 = Main.npc[(int) this.ai1].position.Y - vector2.Y;
        float num3 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 80.0) - vector2.Y;
        float num4 = 6f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num3 * (double) num3);
        float num5 = num1 * num4;
        float num6 = num3 * num4;
        if ((double) this.velocity.X > (double) num5)
        {
          if ((double) this.velocity.X > 0.0)
            this.velocity.X *= 0.9f;
          this.velocity.X -= 0.04f;
        }
        if ((double) this.velocity.X < (double) num5)
        {
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.9f;
          this.velocity.X += 0.04f;
        }
        if ((double) this.velocity.Y > (double) num6)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.9f;
          this.velocity.Y -= 0.08f;
        }
        if ((double) this.velocity.Y < (double) num6)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.9f;
          this.velocity.Y += 0.08f;
        }
        this.TargetClosest(true);
        vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num7 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num8 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num9 = (float) Math.Sqrt((double) num7 * (double) num7 + (double) num8 * (double) num8);
        this.rotation = (float) Math.Atan2((double) num8, (double) num7) - 1.57f;
        if (Main.netMode == 1)
          return;
        ++this.localAI0;
        if (this.localAI0 <= 40)
          return;
        this.localAI0 = 0;
        float num10 = 10f / num9;
        float num11 = num7 * num10;
        float num12 = num8 * num10;
        float SpeedX = num11 + (float) Main.rand.Next(-40, 41) * 0.01f;
        float SpeedY = num12 + (float) Main.rand.Next(-40, 41) * 0.01f;
        vector2.X += SpeedX * 4f;
        vector2.Y += SpeedY * 4f;
        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 102, 0, 0.0f, 8, true);
      }
    }

    private void SkeletronPrimeLaserHand()
    {
      this.spriteDirection = (sbyte) -(double) this.ai0;
      if ((int) Main.npc[(int) this.ai1].active == 0 || (int) Main.npc[(int) this.ai1].aiStyle != 32)
      {
        this.ai2 += 10f;
        if ((double) this.ai2 > 50.0 || Main.netMode != 2)
        {
          this.life = -1;
          this.HitEffect(0, 10.0);
          this.active = (byte) 0;
          return;
        }
      }
      if ((double) this.ai2 == 0.0 || (double) this.ai2 == 3.0)
      {
        if ((double) Main.npc[(int) this.ai1].ai1 == 3.0 && this.timeLeft > 10)
          this.timeLeft = 10;
        if ((double) Main.npc[(int) this.ai1].ai1 != 0.0)
        {
          this.localAI0 += 3;
          if ((double) this.position.Y > (double) Main.npc[(int) this.ai1].position.Y - 100.0)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.07f;
            if ((double) this.velocity.Y > 6.0)
              this.velocity.Y = 6f;
          }
          else if ((double) this.position.Y < (double) Main.npc[(int) this.ai1].position.Y - 100.0)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.07f;
            if ((double) this.velocity.Y < -6.0)
              this.velocity.Y = -6f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) > (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 120.0 * (double) this.ai0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.1f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) < (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 120.0 * (double) this.ai0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X += 0.1f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        else
        {
          ++this.ai3;
          if ((double) this.ai3 >= 800.0)
          {
            ++this.ai2;
            this.ai3 = 0.0f;
            this.netUpdate = true;
          }
          if ((double) this.position.Y > (double) Main.npc[(int) this.ai1].position.Y - 100.0)
          {
            if ((double) this.velocity.Y > 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y -= 0.1f;
            if ((double) this.velocity.Y > 3.0)
              this.velocity.Y = 3f;
          }
          else if ((double) this.position.Y < (double) Main.npc[(int) this.ai1].position.Y - 100.0)
          {
            if ((double) this.velocity.Y < 0.0)
              this.velocity.Y *= 0.96f;
            this.velocity.Y += 0.1f;
            if ((double) this.velocity.Y < -3.0)
              this.velocity.Y = -3f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) > (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 180.0 * (double) this.ai0)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X -= 0.14f;
            if ((double) this.velocity.X > 8.0)
              this.velocity.X = 8f;
          }
          if ((double) this.position.X + (double) ((int) this.width >> 1) < (double) Main.npc[(int) this.ai1].position.X + (double) ((int) Main.npc[(int) this.ai1].width >> 1) - 180.0 * (double) this.ai0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X *= 0.96f;
            this.velocity.X += 0.14f;
            if ((double) this.velocity.X < -8.0)
              this.velocity.X = -8f;
          }
        }
        this.TargetClosest(true);
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num3 = (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        this.rotation = (float) Math.Atan2((double) num2, (double) num1) - 1.57f;
        if (Main.netMode == 1)
          return;
        ++this.localAI0;
        if (this.localAI0 <= 200)
          return;
        this.localAI0 = 0;
        float num4 = 8f / num3;
        float num5 = num1 * num4;
        float num6 = num2 * num4;
        float SpeedX = num5 + (float) Main.rand.Next(-40, 41) * 0.05f;
        float SpeedY = num6 + (float) Main.rand.Next(-40, 41) * 0.05f;
        vector2.X += SpeedX * 8f;
        vector2.Y += SpeedY * 8f;
        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 100, 25, 0.0f, 8, true);
      }
      else
      {
        if ((double) this.ai2 != 1.0)
          return;
        ++this.ai3;
        if ((double) this.ai3 >= 200.0)
        {
          this.localAI0 = 0;
          this.ai2 = 0.0f;
          this.ai3 = 0.0f;
          this.netUpdate = true;
        }
        Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num1 = (float) ((double) Main.player[(int) this.target].position.X + 10.0 - 350.0) - vector2.X;
        float num2 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 20.0) - vector2.Y;
        float num3 = 7f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
        float num4 = num1 * num3;
        float num5 = num2 * num3;
        if ((double) this.velocity.X > (double) num4)
        {
          if ((double) this.velocity.X > 0.0)
            this.velocity.X *= 0.9f;
          this.velocity.X -= 0.1f;
        }
        if ((double) this.velocity.X < (double) num4)
        {
          if ((double) this.velocity.X < 0.0)
            this.velocity.X *= 0.9f;
          this.velocity.X += 0.1f;
        }
        if ((double) this.velocity.Y > (double) num5)
        {
          if ((double) this.velocity.Y > 0.0)
            this.velocity.Y *= 0.9f;
          this.velocity.Y -= 0.03f;
        }
        if ((double) this.velocity.Y < (double) num5)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.9f;
          this.velocity.Y += 0.03f;
        }
        this.TargetClosest(true);
        vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
        float num6 = Main.player[(int) this.target].position.X + 10f - vector2.X;
        float num7 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
        float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
        this.rotation = (float) Math.Atan2((double) num7, (double) num6) - 1.57f;
        if (Main.netMode != 1)
          return;
        ++this.localAI0;
        if (this.localAI0 <= 80)
          return;
        this.localAI0 = 0;
        float num9 = 10f / num8;
        float num10 = num6 * num9;
        float num11 = num7 * num9;
        float SpeedX = num10 + (float) Main.rand.Next(-40, 41) * 0.05f;
        float SpeedY = num11 + (float) Main.rand.Next(-40, 41) * 0.05f;
        vector2.X += SpeedX * 8f;
        vector2.Y += SpeedY * 8f;
        Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 100, 25, 0.0f, 8, true);
      }
    }

    private void DestroyerAI()
    {
      if ((double) this.ai3 > 0.0)
        this.realLife = (int) this.ai3;
      if ((int) this.target == 8 || Main.player[(int) this.target].dead)
        this.TargetClosest(true);
      if ((int) this.type > 134)
      {
        bool flag = false;
        if ((double) this.ai1 <= 0.0)
          flag = true;
        else if (Main.npc[(int) this.ai1].life <= 0)
          flag = true;
        if (flag)
        {
          this.life = 0;
          if ((int) this.active != 0)
            this.HitEffect(0, 10.0);
          this.checkDead();
        }
      }
      if (Main.netMode != 1)
      {
        if ((double) this.ai0 == 0.0 && (int) this.type == 134)
        {
          this.ai3 = (float) this.whoAmI;
          this.realLife = (int) this.whoAmI;
          int index1 = (int) this.whoAmI;
          int num = 80;
          for (int index2 = 0; index2 <= num; ++index2)
          {
            int Type = 135;
            if (index2 == num)
              Type = 136;
            int number = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, Type, (int) this.whoAmI);
            Main.npc[number].ai3 = (float) this.whoAmI;
            Main.npc[number].realLife = (int) this.whoAmI;
            Main.npc[number].ai1 = (float) index1;
            Main.npc[index1].ai0 = (float) number;
            NetMessage.CreateMessage1(23, number);
            NetMessage.SendMessage();
            index1 = number;
          }
        }
        if ((int) this.type == 135)
        {
          this.localAI0 += Main.rand.Next(4);
          if (this.localAI0 >= Main.rand.Next(1400, 26000))
          {
            this.localAI0 = 0;
            this.TargetClosest(true);
            if (Collision.CanHit(ref this.aabb, ref Main.player[(int) this.target].aabb))
            {
              Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) ((int) this.height >> 1));
              float num1 = Main.player[(int) this.target].position.X + 10f - vector2.X + (float) Main.rand.Next(-20, 21);
              float num2 = Main.player[(int) this.target].position.Y + 21f - vector2.Y + (float) Main.rand.Next(-20, 21);
              float num3 = 8f / (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
              float num4 = num1 * num3;
              float num5 = num2 * num3;
              float SpeedX = num4 + (float) Main.rand.Next(-20, 21) * 0.05f;
              float SpeedY = num5 + (float) Main.rand.Next(-20, 21) * 0.05f;
              vector2.X += SpeedX * 5f;
              vector2.Y += SpeedY * 5f;
              int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 100, 22, 0.0f, 8, true);
              if (index >= 0)
              {
                Main.projectile[index].timeLeft = 300;
                this.netUpdate = true;
              }
            }
          }
        }
      }
      int num6 = ((int) this.position.X >> 4) - 1;
      int num7 = ((int) this.position.X + (int) this.width >> 4) + 2;
      int num8 = ((int) this.position.Y >> 4) - 1;
      int num9 = ((int) this.position.Y + (int) this.height >> 4) + 2;
      if (num6 < 0)
        num6 = 0;
      if (num7 > (int) Main.maxTilesX)
        num7 = (int) Main.maxTilesX;
      if (num8 < 0)
        num8 = 0;
      if (num9 > (int) Main.maxTilesY)
        num9 = (int) Main.maxTilesY;
      bool flag1 = false;
      if (!flag1)
      {
        for (int index1 = num6; index1 < num7; ++index1)
        {
          for (int index2 = num8; index2 < num9; ++index2)
          {
            if (Main.tile[index1, index2].canStandOnTop() || (int) Main.tile[index1, index2].liquid > 64)
            {
              Vector2 vector2;
              vector2.X = (float) (index1 * 16);
              vector2.Y = (float) (index2 * 16);
              if ((double) this.position.X + (double) this.width > (double) vector2.X && (double) this.position.X < (double) vector2.X + 16.0 && ((double) this.position.Y + (double) this.height > (double) vector2.Y && (double) this.position.Y < (double) vector2.Y + 16.0))
              {
                flag1 = true;
                break;
              }
            }
          }
        }
      }
      if (!flag1)
      {
        if ((int) this.type != 135 || (double) this.ai2 != 1.0)
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.3f, 0.1f, 0.05f));
        this.localAI1 = 1;
        if ((int) this.type == 134)
        {
          Rectangle rectangle1 = new Rectangle((int) this.position.X, (int) this.position.Y, (int) this.width, (int) this.height);
          bool flag2 = true;
          if ((double) this.position.Y > (double) Main.player[(int) this.target].position.Y)
          {
            for (int index = 0; index < 8; ++index)
            {
              if ((int) Main.player[index].active != 0)
              {
                Rectangle rectangle2 = new Rectangle(Main.player[index].aabb.X - 1000, Main.player[index].aabb.Y - 1000, 2000, 2000);
                if (rectangle1.Intersects(rectangle2))
                {
                  flag2 = false;
                  break;
                }
              }
            }
            if (flag2)
              flag1 = true;
          }
        }
      }
      else
        this.localAI1 = 0;
      float num10 = 16f;
      if (Main.gameTime.dayTime || Main.player[(int) this.target].dead)
      {
        flag1 = false;
        ++this.velocity.Y;
        if ((double) this.position.Y > (double) (Main.worldSurface << 4))
        {
          ++this.velocity.Y;
          num10 = 32f;
        }
        if ((double) this.position.Y > (double) (Main.rockLayer << 4))
        {
          for (int index = 0; index < 196; ++index)
          {
            if ((int) Main.npc[index].aiStyle == (int) this.aiStyle)
              Main.npc[index].active = (byte) 0;
          }
        }
      }
      Vector2 vector2_1 = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
      if ((double) this.ai1 > 0.0 && (double) this.ai1 < 196.0)
      {
        float num1 = Main.npc[(int) this.ai1].position.X + (float) ((int) Main.npc[(int) this.ai1].width >> 1) - vector2_1.X;
        float num2 = Main.npc[(int) this.ai1].position.Y + (float) ((int) Main.npc[(int) this.ai1].height >> 1) - vector2_1.Y;
        this.rotation = (float) (Math.Atan2((double) num2, (double) num1) + Math.PI / 2.0);
        float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
        if ((double) num3 > 0.0)
        {
          float num4 = (float) Math.Sqrt((double) num3);
          float num5 = (num4 - 44f * this.scale) / num4;
          float num11 = num1 * num5;
          float num12 = num2 * num5;
          this.position.X += num11;
          this.position.Y += num12;
          this.aabb.X = (int) this.position.X;
          this.aabb.Y = (int) this.position.Y;
        }
        this.velocity.X = 0.0f;
        this.velocity.Y = 0.0f;
      }
      else
      {
        float num1 = (float) (Main.player[(int) this.target].aabb.X + 10 & -16);
        float num2 = (float) (Main.player[(int) this.target].aabb.Y + 21 & -16);
        vector2_1.X = (float) ((int) vector2_1.X & -16);
        vector2_1.Y = (float) ((int) vector2_1.Y & -16);
        float num3 = num1 - vector2_1.X;
        float num4 = num2 - vector2_1.Y;
        if (!flag1)
        {
          this.TargetClosest(true);
          this.velocity.Y += 0.15f;
          if ((double) this.velocity.Y > (double) num10)
            this.velocity.Y = num10;
          if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num10 * 0.4)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X -= 0.11f;
            else
              this.velocity.X += 0.11f;
          }
          else if ((double) this.velocity.Y == (double) num10)
          {
            if ((double) this.velocity.X < (double) num3)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X > (double) num3)
              this.velocity.X -= 0.1f;
          }
          else if ((double) this.velocity.Y > 4.0)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X += 0.09f;
            else
              this.velocity.X -= 0.09f;
          }
        }
        else
        {
          float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
          if ((int) this.soundDelay == 0)
          {
            float num11 = num5 * 0.025f;
            if ((double) num11 < 10.0)
              num11 = 10f;
            else if ((double) num11 > 20.0)
              num11 = 20f;
            this.soundDelay = (short) num11;
            Main.PlaySound(15, this.aabb.X, this.aabb.Y, 1);
          }
          float num12 = Math.Abs(num3);
          float num13 = Math.Abs(num4);
          float num14 = num10 / num5;
          float num15 = num3 * num14;
          float num16 = num4 * num14;
          if (((double) this.velocity.X > 0.0 && (double) num15 > 0.0 || (double) this.velocity.X < 0.0 && (double) num15 < 0.0) && ((double) this.velocity.Y > 0.0 && (double) num16 > 0.0 || (double) this.velocity.Y < 0.0 && (double) num16 < 0.0))
          {
            if ((double) this.velocity.X < (double) num15)
              this.velocity.X += 0.15f;
            else if ((double) this.velocity.X > (double) num15)
              this.velocity.X -= 0.15f;
            if ((double) this.velocity.Y < (double) num16)
              this.velocity.Y += 0.15f;
            else if ((double) this.velocity.Y > (double) num16)
              this.velocity.Y -= 0.15f;
          }
          if ((double) this.velocity.X > 0.0 && (double) num15 > 0.0 || (double) this.velocity.X < 0.0 && (double) num15 < 0.0 || ((double) this.velocity.Y > 0.0 && (double) num16 > 0.0 || (double) this.velocity.Y < 0.0 && (double) num16 < 0.0))
          {
            if ((double) this.velocity.X < (double) num15)
              this.velocity.X += 0.1f;
            else if ((double) this.velocity.X > (double) num15)
              this.velocity.X -= 0.1f;
            if ((double) this.velocity.Y < (double) num16)
              this.velocity.Y += 0.1f;
            else if ((double) this.velocity.Y > (double) num16)
              this.velocity.Y -= 0.1f;
            if ((double) Math.Abs(num16) < (double) num10 * 0.2 && ((double) this.velocity.X > 0.0 && (double) num15 < 0.0 || (double) this.velocity.X < 0.0 && (double) num15 > 0.0))
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += 0.2f;
              else
                this.velocity.Y -= 0.2f;
            }
            if ((double) Math.Abs(num15) < (double) num10 * 0.2 && ((double) this.velocity.Y > 0.0 && (double) num16 < 0.0 || (double) this.velocity.Y < 0.0 && (double) num16 > 0.0))
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X += 0.2f;
              else
                this.velocity.X -= 0.2f;
            }
          }
          else if ((double) num12 > (double) num13)
          {
            if ((double) this.velocity.X < (double) num15)
              this.velocity.X += 0.11f;
            else if ((double) this.velocity.X > (double) num15)
              this.velocity.X -= 0.11f;
            if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num10 * 0.5)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y += 0.1f;
              else
                this.velocity.Y -= 0.1f;
            }
          }
          else
          {
            if ((double) this.velocity.Y < (double) num16)
              this.velocity.Y += 0.11f;
            else if ((double) this.velocity.Y > (double) num16)
              this.velocity.Y -= 0.11f;
            if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) < (double) num10 * 0.5)
            {
              if ((double) this.velocity.X > 0.0)
                this.velocity.X += 0.1f;
              else
                this.velocity.X -= 0.1f;
            }
          }
        }
        this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 1.57f;
        if ((int) this.type != 134)
          return;
        if (flag1)
        {
          if (this.localAI0 != 1)
            this.netUpdate = true;
          this.localAI0 = 1;
        }
        else
        {
          if (this.localAI0 != 0)
            this.netUpdate = true;
          this.localAI0 = 0;
        }
        if (((double) this.velocity.X <= 0.0 || (double) this.oldVelocity.X >= 0.0) && ((double) this.velocity.X >= 0.0 || (double) this.oldVelocity.X <= 0.0) && (((double) this.velocity.Y <= 0.0 || (double) this.oldVelocity.Y >= 0.0) && ((double) this.velocity.Y >= 0.0 || (double) this.oldVelocity.Y <= 0.0)) || this.justHit)
          return;
        this.netUpdate = true;
      }
    }

    private void SnowmanAI()
    {
      float num1 = 4f;
      float num2 = 1f;
      if ((int) this.type == 143)
      {
        num1 = 3f;
        num2 = 0.7f;
      }
      if ((int) this.type == 145)
      {
        num1 = 3.5f;
        num2 = 0.8f;
      }
      if ((int) this.type == 143)
      {
        ++this.ai2;
        if ((double) this.ai2 >= 120.0)
        {
          this.ai2 = 0.0f;
          if (Main.netMode != 1)
          {
            Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f - (float) ((int) this.direction * 12), this.position.Y + (float) this.height * 0.5f);
            float SpeedX = (float) (12 * (int) this.spriteDirection);
            float SpeedY = 0.0f;
            if (Main.netMode != 1)
            {
              int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 110, 25, 0.0f, 8, false);
              if (number >= 0)
              {
                Main.projectile[number].ai0 = 2f;
                Main.projectile[number].timeLeft = 300;
                Main.projectile[number].friendly = false;
                NetMessage.SendProjectile(number, SendDataOptions.Reliable);
                this.netUpdate = true;
              }
            }
          }
        }
      }
      if ((int) this.type == 144 && (double) this.ai1 >= 3.0)
      {
        this.TargetClosest(true);
        this.spriteDirection = this.direction;
        if ((double) this.velocity.Y == 0.0)
        {
          this.velocity.X *= 0.9f;
          ++this.ai2;
          if ((double) this.velocity.X > -0.3 && (double) this.velocity.X < 0.3)
            this.velocity.X = 0.0f;
          if ((double) this.ai2 >= 200.0)
          {
            this.ai2 = 0.0f;
            this.ai1 = 0.0f;
          }
        }
      }
      else if ((int) this.type == 145 && (double) this.ai1 >= 3.0)
      {
        this.TargetClosest(true);
        if ((double) this.velocity.Y == 0.0)
        {
          this.velocity.X *= 0.9f;
          ++this.ai2;
          if ((double) this.velocity.X > -0.3 && (double) this.velocity.X < 0.3)
            this.velocity.X = 0.0f;
          if ((double) this.ai2 >= 16.0)
          {
            this.ai2 = 0.0f;
            this.ai1 = 0.0f;
          }
        }
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0 && (double) this.ai2 == 8.0)
        {
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f - (float) ((int) this.direction * 12), this.position.Y + (float) this.height * 0.25f);
          float num3 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num4 = Main.player[(int) this.target].position.Y - vector2.Y;
          float num5 = 10f / (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
          float SpeedX = num3 * num5;
          float SpeedY = num4 * num5;
          if (Main.netMode != 1)
          {
            int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 109, 35, 0.0f, 8, true);
            if (number >= 0)
            {
              Main.projectile[number].ai0 = 2f;
              Main.projectile[number].timeLeft = 300;
              Main.projectile[number].friendly = false;
              NetMessage.SendProjectile(number, SendDataOptions.Reliable);
              this.netUpdate = true;
            }
          }
        }
      }
      else
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if (this.localAI2 == this.aabb.X)
          {
            this.direction = -this.direction;
            this.ai3 = 60f;
          }
          this.localAI2 = this.aabb.X;
          if ((double) this.ai3 == 0.0)
            this.TargetClosest(true);
          ++this.ai0;
          if ((double) this.ai0 > 2.0)
          {
            this.ai0 = 0.0f;
            ++this.ai1;
            this.velocity.Y = -8.2f;
            this.velocity.X += (float) ((double) this.direction * (double) num2 * 1.10000002384186);
          }
          else
          {
            this.velocity.Y = -6f;
            this.velocity.X += (float) ((double) this.direction * (double) num2 * 0.899999976158142);
          }
          this.spriteDirection = this.direction;
        }
        this.velocity.X += (float) ((double) this.direction * (double) num2 * 0.00999999977648258);
      }
      if ((double) this.ai3 > 0.0)
        --this.ai3;
      if ((double) this.velocity.X > (double) num1 && (int) this.direction > 0)
      {
        this.velocity.X = 4f;
      }
      else
      {
        if ((double) this.velocity.X >= -(double) num1 || (int) this.direction >= 0)
          return;
        this.velocity.X = -4f;
      }
    }

    private unsafe void OcramAI()
    {
      Lighting.addLight(this.aabb.X >> 4, this.aabb.Y >> 4, new Vector3(1f, 1f, 1f));
      if ((int) this.target == 8 || Main.player[(int) this.target].dead || (int) Main.player[(int) this.target].active == 0)
        this.TargetClosest(true);
      bool flag = Main.player[(int) this.target].dead;
      float num1 = (float) ((double) this.position.X + (double) ((int) this.width >> 1) - (double) Main.player[(int) this.target].position.X - 10.0);
      float num2 = (float) Math.Atan2((double) this.position.Y + (double) this.height - 59.0 - (double) Main.player[(int) this.target].position.Y - 21.0, (double) num1) + 1.57f;
      if ((double) num2 < 0.0)
        num2 += 6.283f;
      else if ((double) num2 > 6.28299999237061)
        num2 -= 6.283f;
      float num3 = 0.0f;
      if ((double) this.ai0 == 0.0 && (double) this.ai1 == 0.0)
        num3 = 0.02f;
      if ((double) this.ai0 == 0.0 && (double) this.ai1 == 2.0 && (double) this.ai2 > 40.0)
        num3 = 0.05f;
      if ((double) this.ai0 == 3.0 && (double) this.ai1 == 0.0)
        num3 = 0.05f;
      if ((double) this.ai0 == 3.0 && (double) this.ai1 == 2.0 && (double) this.ai2 > 40.0)
        num3 = 0.08f;
      if ((double) this.rotation < (double) num2)
      {
        if ((double) num2 - (double) this.rotation > 3.1415)
          this.rotation -= num3;
        else
          this.rotation += num3;
      }
      else if ((double) this.rotation > (double) num2)
      {
        if ((double) this.rotation - (double) num2 > 3.1415)
          this.rotation += num3;
        else
          this.rotation -= num3;
      }
      if ((double) this.rotation > (double) num2 - (double) num3 && (double) this.rotation < (double) num2 + (double) num3)
        this.rotation = num2;
      if ((double) this.rotation < 0.0)
        this.rotation += 6.283f;
      else if ((double) this.rotation > 6.28299999237061)
        this.rotation -= 6.283f;
      if ((double) this.rotation > (double) num2 - (double) num3 && (double) this.rotation < (double) num2 + (double) num3)
        this.rotation = num2;
      if (Main.rand.Next(6) == 0)
      {
        Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + ((int) this.height >> 2), (int) this.width, (int) this.height >> 1, 5, (double) this.velocity.X, 2.0, 0, new Color(), 1.0);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->velocity.X *= 0.5f;
          dustPtr->velocity.Y *= 0.1f;
        }
      }
      if (Main.gameTime.dayTime || flag)
      {
        this.velocity.Y -= 0.04f;
        if (this.timeLeft <= 10)
          return;
        this.timeLeft = 10;
      }
      else if ((double) this.ai0 == 0.0)
      {
        if ((double) this.ai1 == 0.0)
        {
          float num4 = 8f;
          float num5 = 0.12f;
          Vector2 vector2_1 = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
          float num6 = Main.player[(int) this.target].position.X + 10f - vector2_1.X;
          float num7 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 200.0) - vector2_1.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num8;
          float num10 = num4 / num8;
          float num11 = num6 * num10;
          float num12 = num7 * num10;
          if ((double) this.velocity.X < (double) num11)
          {
            this.velocity.X += num5;
            if ((double) this.velocity.X < 0.0 && (double) num11 > 0.0)
              this.velocity.X += num5;
          }
          else if ((double) this.velocity.X > (double) num11)
          {
            this.velocity.X -= num5;
            if ((double) this.velocity.X > 0.0 && (double) num11 < 0.0)
              this.velocity.X -= num5;
          }
          if ((double) this.velocity.Y < (double) num12)
          {
            this.velocity.Y += num5;
            if ((double) this.velocity.Y < 0.0 && (double) num12 > 0.0)
              this.velocity.Y += num5;
          }
          else if ((double) this.velocity.Y > (double) num12)
          {
            this.velocity.Y -= num5;
            if ((double) this.velocity.Y > 0.0 && (double) num12 < 0.0)
              this.velocity.Y -= num5;
          }
          ++this.ai2;
          if ((double) this.ai2 >= 600.0)
          {
            this.ai1 = 1f;
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.target = (byte) 8;
            this.netUpdate = true;
          }
          else if (this.aabb.Y + (int) this.height < Main.player[(int) this.target].aabb.Y && (double) num9 < 500.0)
          {
            if (!Main.player[(int) this.target].dead)
              ++this.ai3;
            if ((double) this.ai3 >= 90.0)
            {
              this.TargetClosest(true);
              float num13 = 9f / (float) Math.Sqrt((double) num11 * (double) num11 + (double) num12 * (double) num12);
              float SpeedX = num11 * num13;
              float SpeedY = num12 * num13;
              vector2_1.X += SpeedX * 15f;
              vector2_1.Y += SpeedY * 15f;
              Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, 100, 20, 0.0f, 8, true);
            }
            if ((double) this.ai3 == 60.0 || (double) this.ai3 == 70.0 || ((double) this.ai3 == 80.0 || (double) this.ai3 == 90.0))
            {
              this.rotation = num2;
              float num13 = Main.player[(int) this.target].position.X + 10f - vector2_1.X;
              float num14 = Main.player[(int) this.target].position.Y + 21f - vector2_1.Y;
              float num15 = 5f / (float) Math.Sqrt((double) num13 * (double) num13 + (double) num14 * (double) num14);
              Vector2 vector2_2 = vector2_1;
              Vector2 vector2_3;
              vector2_3.X = num13 * num15;
              vector2_3.Y = num14 * num15;
              vector2_2.X += vector2_3.X * 10f;
              vector2_2.Y += vector2_3.Y * 10f;
              if (Main.netMode != 1)
              {
                int number = NPC.NewNPC((int) vector2_2.X, (int) vector2_2.Y, 167, 0);
                if (number < 196)
                {
                  Main.npc[number].velocity.X = vector2_3.X;
                  Main.npc[number].velocity.Y = vector2_3.Y;
                  NetMessage.CreateMessage1(23, number);
                  NetMessage.SendMessage();
                }
              }
              Main.PlaySound(3, (int) vector2_2.X, (int) vector2_2.Y, 1);
              int num16 = 0;
              while (num16 < 8 && IntPtr.Zero != (IntPtr) Main.dust.NewDust((int) vector2_2.X, (int) vector2_2.Y, 20, 20, 5, (double) vector2_3.X * 0.400000005960464, (double) vector2_3.Y * 0.400000005960464, 0, new Color(), 1.0))
                ++num16;
            }
            if ((double) this.ai3 == 103.0)
              this.ai3 = 0.0f;
          }
        }
        else if ((double) this.ai1 == 1.0)
        {
          this.rotation = num2;
          float num4 = 6f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num5 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num6 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
          float num8 = num4 / num7;
          this.velocity.X = num5 * num8;
          this.velocity.Y = num6 * num8;
          this.ai1 = 2f;
        }
        else if ((double) this.ai1 == 2.0)
        {
          ++this.ai2;
          if ((double) this.ai2 >= 40.0)
          {
            this.velocity.X *= 0.98f;
            this.velocity.Y *= 0.98f;
            if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
              this.velocity.X = 0.0f;
            if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
              this.velocity.Y = 0.0f;
          }
          else
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
          if ((double) this.ai2 >= 150.0)
          {
            ++this.ai3;
            this.ai2 = 0.0f;
            this.target = (byte) 8;
            this.rotation = num2;
            if ((double) this.ai3 >= 3.0)
            {
              this.ai1 = 0.0f;
              this.ai3 = 0.0f;
            }
            else
              this.ai1 = 1f;
          }
        }
        if (this.life >= this.lifeMax >> 1)
          return;
        this.ai0 = 1f;
        this.ai1 = 0.0f;
        this.ai2 = 0.0f;
        this.ai3 = 0.0f;
        this.netUpdate = true;
      }
      else if ((double) this.ai0 == 1.0 || (double) this.ai0 == 2.0)
      {
        if ((double) this.ai0 == 1.0)
        {
          this.ai2 += 0.005f;
          if ((double) this.ai2 > 0.5)
            this.ai2 = 0.5f;
        }
        else
        {
          this.ai2 -= 0.005f;
          if ((double) this.ai2 < 0.0)
            this.ai2 = 0.0f;
        }
        this.rotation += this.ai2;
        ++this.ai1;
        if ((double) this.ai1 == 100.0)
        {
          ++this.ai0;
          this.ai1 = 0.0f;
          if ((double) this.ai0 == 3.0)
          {
            this.ai2 = 0.0f;
          }
          else
          {
            Main.PlaySound(3, this.aabb.X, this.aabb.Y, 1);
            for (int index = 0; index < 2; ++index)
            {
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 174, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 173, 1.0);
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 172, 1.0);
            }
            int num4 = 0;
            while (num4 < 16 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.200000002980232, (double) Main.rand.Next(-30, 31) * 0.200000002980232, 0, new Color(), 1.0))
              ++num4;
            Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
          }
        }
        Main.dust.NewDust(5, ref this.aabb, (double) Main.rand.Next(-30, 31) * 0.200000002980232, (double) Main.rand.Next(-30, 31) * 0.200000002980232, 0, new Color(), 1.0);
        this.velocity.X *= 0.98f;
        this.velocity.Y *= 0.98f;
        if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
          this.velocity.X = 0.0f;
        if ((double) this.velocity.Y <= -0.1 || (double) this.velocity.Y >= 0.1)
          return;
        this.velocity.Y = 0.0f;
      }
      else
      {
        this.damage = 50;
        this.defense = 0;
        if ((double) this.ai1 == 0.0)
        {
          float num4 = 9f;
          float num5 = 0.2f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num6 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num7 = (float) ((double) Main.player[(int) this.target].position.Y + 21.0 - 120.0) - vector2.Y;
          float num8 = (float) Math.Sqrt((double) num6 * (double) num6 + (double) num7 * (double) num7);
          float num9 = num4 / num8;
          float num10 = num6 * num9;
          float num11 = num7 * num9;
          if ((double) this.velocity.X < (double) num10)
          {
            this.velocity.X += num5;
            if ((double) this.velocity.X < 0.0 && (double) num10 > 0.0)
              this.velocity.X += num5;
          }
          else if ((double) this.velocity.X > (double) num10)
          {
            this.velocity.X -= num5;
            if ((double) this.velocity.X > 0.0 && (double) num10 < 0.0)
              this.velocity.X -= num5;
          }
          if ((double) this.velocity.Y < (double) num11)
          {
            this.velocity.Y += num5;
            if ((double) this.velocity.Y < 0.0 && (double) num11 > 0.0)
              this.velocity.Y += num5;
          }
          else if ((double) this.velocity.Y > (double) num11)
          {
            this.velocity.Y -= num5;
            if ((double) this.velocity.Y > 0.0 && (double) num11 < 0.0)
              this.velocity.Y -= num5;
          }
          ++this.ai2;
          if ((double) this.ai2 < 100.0)
            return;
          if ((double) this.ai2 >= 200.0)
          {
            this.ai1 = 1f;
            this.ai2 = 0.0f;
            this.ai3 = 0.0f;
            this.target = (byte) 8;
            this.netUpdate = true;
          }
          float num12 = 9f / (float) Math.Sqrt((double) num10 * (double) num10 + (double) num11 * (double) num11);
          float num13 = num10 * num12;
          float num14 = num11 * num12;
          float SpeedX = num13 + (float) Main.rand.Next(-40, 41) * 0.08f;
          float SpeedY = num14 + (float) Main.rand.Next(-40, 41) * 0.08f;
          vector2.X += SpeedX * 15f;
          vector2.Y += SpeedY * 15f;
          Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 83, 45, 0.0f, 8, true);
        }
        else if ((double) this.ai1 == 1.0)
        {
          Main.PlaySound(15, (int) this.position.X, (int) this.position.Y, 0);
          this.rotation = num2;
          float num4 = 6.8f;
          Vector2 vector2 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
          float num5 = Main.player[(int) this.target].position.X + 10f - vector2.X;
          float num6 = Main.player[(int) this.target].position.Y + 21f - vector2.Y;
          float num7 = (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
          float num8 = num4 / num7;
          this.velocity.X = num5 * num8;
          this.velocity.Y = num6 * num8;
          if ((double) this.ai1 == 1.0)
          {
            float num9 = 6f / (float) Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6);
            float num10 = num5 * num9;
            float num11 = num6 * num9;
            float SpeedX = num10 + (float) Main.rand.Next(-40, 41) * 0.08f;
            float SpeedY = num11 + (float) Main.rand.Next(-40, 41) * 0.08f;
            for (int index = 1; index <= 10; ++index)
            {
              vector2.X += (float) Main.rand.Next(-50, 50) * 2f;
              vector2.Y += (float) Main.rand.Next(-50, 50) * 2f;
              Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, 44, 45, 0.0f, 8, true);
            }
          }
          this.ai1 = 2f;
        }
        else
        {
          if ((double) this.ai1 != 2.0)
            return;
          ++this.ai2;
          if ((double) this.ai2 >= 40.0)
          {
            this.velocity.X *= 1f;
            this.velocity.Y *= 1f;
            if ((double) this.velocity.X > -0.1 && (double) this.velocity.X < 0.1)
              this.velocity.X = 0.0f;
            if ((double) this.velocity.Y > -0.1 && (double) this.velocity.Y < 0.1)
              this.velocity.Y = 0.0f;
            if ((double) this.ai2 >= 135.0)
            {
              ++this.ai3;
              this.ai2 = 0.0f;
              this.target = (byte) 8;
              this.rotation = num2;
              if ((double) this.ai3 >= 3.0)
              {
                this.ai1 = 0.0f;
                this.ai3 = 0.0f;
              }
              else
                this.ai1 = 1f;
            }
            if ((double) this.ai2 != 110.0 && (double) this.ai2 != 100.0 && ((double) this.ai2 != 130.0 && (double) this.ai2 != 120.0))
              return;
            this.rotation = num2;
            Vector2 vector2_1 = new Vector2(this.position.X + (float) this.width * 0.5f, this.position.Y + (float) this.height * 0.5f);
            float num4 = Main.player[(int) this.target].position.X + 10f - vector2_1.X;
            float num5 = Main.player[(int) this.target].position.Y + 21f - vector2_1.Y;
            float num6 = 5f / (float) Math.Sqrt((double) num4 * (double) num4 + (double) num5 * (double) num5);
            Vector2 vector2_2 = vector2_1;
            Vector2 vector2_3;
            vector2_3.X = num4 * num6;
            vector2_3.Y = num5 * num6;
            vector2_2.X += vector2_3.X * 10f;
            vector2_2.Y += vector2_3.Y * 10f;
            if (Main.netMode == 1)
              return;
            int number = NPC.NewNPC((int) vector2_2.X, (int) vector2_2.Y, 167, 0);
            if (number >= 196)
              return;
            Main.npc[number].velocity.X = vector2_3.X;
            Main.npc[number].velocity.Y = vector2_3.Y;
            NetMessage.CreateMessage1(23, number);
            NetMessage.SendMessage();
          }
          else
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) - 1.57f;
        }
      }
    }

    public void FindFrame()
    {
      int num = 0;
      if ((int) this.aiAction == 0)
        num = (double) this.velocity.Y >= 0.0 ? ((double) this.velocity.Y <= 0.0 ? ((double) this.velocity.X == 0.0 ? 0 : 1) : 3) : 2;
      else if ((int) this.aiAction == 1)
        num = 4;
      if ((int) this.type == 1 || (int) this.type == 16 || ((int) this.type == 59 || (int) this.type == 71) || ((int) this.type == 81 || (int) this.type == 150 || (int) this.type == 138))
      {
        ++this.frameCounter;
        if (num > 0)
          ++this.frameCounter;
        if (num == 4)
          ++this.frameCounter;
        if ((double) this.frameCounter >= 8.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 141)
      {
        this.spriteDirection = this.direction;
        if ((double) this.velocity.Y != 0.0)
        {
          this.frameY = (short) ((int) this.frameHeight << 1);
        }
        else
        {
          ++this.frameCounter;
          if ((double) this.frameCounter >= 8.0)
          {
            this.frameY += this.frameHeight;
            this.frameCounter = 0.0f;
          }
          if ((int) this.frameY <= (int) this.frameHeight)
            return;
          this.frameY = (short) 0;
        }
      }
      else if ((int) this.type == 143)
      {
        if ((double) this.velocity.Y > 0.0)
          ++this.frameCounter;
        else if ((double) this.velocity.Y < 0.0)
          --this.frameCounter;
        if ((double) this.frameCounter < 6.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 12.0)
          this.frameY = (short) ((int) this.frameHeight << 1);
        else if ((double) this.frameCounter < 18.0)
          this.frameY = (short) ((int) this.frameHeight * 3);
        if ((double) this.frameCounter < 0.0)
          this.frameCounter = 0.0f;
        if ((double) this.frameCounter <= 17.0)
          return;
        this.frameCounter = 17f;
      }
      else if ((int) this.type == 144)
      {
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          ++this.localAI3;
          if (this.localAI3 < 6)
            this.frameY = (short) 0;
          else if (this.localAI3 < 12)
            this.frameY = this.frameHeight;
          if (this.localAI3 < 11)
            return;
          this.localAI3 = 0;
        }
        else
        {
          if ((double) this.velocity.Y > 0.0)
            ++this.frameCounter;
          else if ((double) this.velocity.Y < 0.0)
            --this.frameCounter;
          if ((double) this.frameCounter < 6.0)
            this.frameY = (short) ((int) this.frameHeight << 1);
          else if ((double) this.frameCounter < 12.0)
            this.frameY = (short) ((int) this.frameHeight * 3);
          else if ((double) this.frameCounter < 18.0)
            this.frameY = (short) ((int) this.frameHeight << 2);
          if ((double) this.frameCounter < 0.0)
          {
            this.frameCounter = 0.0f;
          }
          else
          {
            if ((double) this.frameCounter <= 17.0)
              return;
            this.frameCounter = 17f;
          }
        }
      }
      else if ((int) this.type == 145)
      {
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          if ((double) this.ai2 < 4.0)
            this.frameY = (short) 0;
          else if ((double) this.ai2 < 8.0)
            this.frameY = this.frameHeight;
          else if ((double) this.ai2 < 12.0)
          {
            this.frameY = (short) ((int) this.frameHeight << 1);
          }
          else
          {
            if ((double) this.ai2 >= 16.0)
              return;
            this.frameY = (short) ((int) this.frameHeight * 3);
          }
        }
        else
        {
          if ((double) this.velocity.Y > 0.0)
            ++this.frameCounter;
          else if ((double) this.velocity.Y < 0.0)
            --this.frameCounter;
          if ((double) this.frameCounter < 6.0)
            this.frameY = (short) ((int) this.frameHeight << 2);
          else if ((double) this.frameCounter < 12.0)
            this.frameY = (short) ((int) this.frameHeight * 5);
          else if ((double) this.frameCounter < 18.0)
            this.frameY = (short) ((int) this.frameHeight * 6);
          if ((double) this.frameCounter < 0.0)
            this.frameCounter = 0.0f;
          if ((double) this.frameCounter <= 17.0)
            return;
          this.frameCounter = 17f;
        }
      }
      else if ((int) this.type == 50)
      {
        if ((double) this.velocity.Y != 0.0)
        {
          this.frameY = (short) ((int) this.frameHeight << 2);
        }
        else
        {
          ++this.frameCounter;
          if (num > 0)
            ++this.frameCounter;
          if (num == 4)
            ++this.frameCounter;
          if ((double) this.frameCounter >= 8.0)
          {
            this.frameY += this.frameHeight;
            this.frameCounter = 0.0f;
          }
          if ((int) this.frameY < (int) this.frameHeight * 4)
            return;
          this.frameY = (short) 0;
        }
      }
      else if ((int) this.type == 135)
      {
        if ((double) this.ai2 == 0.0)
          this.frameY = (short) 0;
        else
          this.frameY = this.frameHeight;
      }
      else if ((int) this.type == 85)
      {
        if ((double) this.ai0 == 0.0)
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) 0;
        }
        else
        {
          if ((double) this.velocity.Y == 0.0)
            --this.frameCounter;
          else
            ++this.frameCounter;
          if ((double) this.frameCounter < 0.0)
            this.frameCounter = 0.0f;
          else if ((double) this.frameCounter > 12.0)
            this.frameCounter = 12f;
          if ((double) this.frameCounter < 3.0)
            this.frameY = this.frameHeight;
          else if ((double) this.frameCounter < 6.0)
            this.frameY = (short) ((int) this.frameHeight << 1);
          else if ((double) this.frameCounter < 9.0)
            this.frameY = (short) ((int) this.frameHeight * 3);
          else if ((double) this.frameCounter < 12.0)
            this.frameY = (short) ((int) this.frameHeight << 2);
          else if ((double) this.frameCounter < 15.0)
            this.frameY = (short) ((int) this.frameHeight * 5);
          else if ((double) this.frameCounter < 18.0)
            this.frameY = (short) ((int) this.frameHeight << 2);
          else if ((double) this.frameCounter < 21.0)
          {
            this.frameY = (short) ((int) this.frameHeight * 3);
          }
          else
          {
            this.frameY = (short) ((int) this.frameHeight << 1);
            if ((double) this.frameCounter >= 24.0)
              this.frameCounter = 3f;
          }
        }
        if ((double) this.ai3 == 2.0)
        {
          this.frameY = (short) ((int) this.frameY + (int) this.frameHeight * 6);
        }
        else
        {
          if ((double) this.ai3 != 3.0)
            return;
          this.frameY = (short) ((int) this.frameY + (int) this.frameHeight * 12);
        }
      }
      else if ((int) this.type == 113 || (int) this.type == 114)
      {
        if ((double) this.ai2 == 0.0)
        {
          ++this.frameCounter;
          if ((double) this.frameCounter >= 12.0)
          {
            this.frameY += this.frameHeight;
            this.frameCounter = 0.0f;
          }
          if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
            return;
          this.frameY = (short) 0;
        }
        else
        {
          this.frameY = (short) 0;
          this.frameCounter = -60f;
        }
      }
      else if ((int) this.type == 61)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.1f;
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          this.frameY = (short) 0;
          this.frameCounter = 0.0f;
        }
        else
        {
          ++this.frameCounter;
          if ((double) this.frameCounter < 4.0)
          {
            this.frameY = this.frameHeight;
          }
          else
          {
            this.frameY = (short) ((int) this.frameHeight << 1);
            if ((double) this.frameCounter < 7.0)
              return;
            this.frameCounter = 0.0f;
          }
        }
      }
      else if ((int) this.type == 122 || (int) this.type == 153)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.05f;
        if ((double) this.ai3 > 0.0)
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) ((((int) this.ai3 >> 3) + 3) * (int) this.frameHeight);
        }
        else
        {
          ++this.frameCounter;
          if ((double) this.frameCounter >= 8.0)
          {
            this.frameY += this.frameHeight;
            this.frameCounter = 0.0f;
          }
          if ((int) this.frameY < (int) this.frameHeight * 3)
            return;
          this.frameY = (short) 0;
        }
      }
      else if ((int) this.type == 74)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.1f;
        if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0)
        {
          this.frameY = (short) ((int) this.frameHeight << 2);
          this.frameCounter = 0.0f;
        }
        else
        {
          ++this.frameCounter;
          if ((double) this.frameCounter >= 4.0)
          {
            this.frameY += this.frameHeight;
            this.frameCounter = 0.0f;
          }
          if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
            return;
          this.frameY = (short) 0;
        }
      }
      else if ((int) this.type == 62 || (int) this.type == 165 || (int) this.type == 66)
      {
        this.spriteDirection = this.direction;
        this.rotation = this.velocity.X * 0.1f;
        ++this.frameCounter;
        if ((double) this.frameCounter < 6.0)
        {
          this.frameY = (short) 0;
        }
        else
        {
          this.frameY = this.frameHeight;
          if ((double) this.frameCounter < 11.0)
            return;
          this.frameCounter = 0.0f;
        }
      }
      else if ((int) this.type == 63 || (int) this.type == 64 || (int) this.type == 103)
      {
        ++this.frameCounter;
        if ((double) this.frameCounter < 6.0)
          this.frameY = (short) 0;
        else if ((double) this.frameCounter < 12.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 18.0)
        {
          this.frameY = (short) ((int) this.frameHeight << 1);
        }
        else
        {
          this.frameY = (short) ((int) this.frameHeight * 3);
          if ((double) this.frameCounter < 23.0)
            return;
          this.frameCounter = 0.0f;
        }
      }
      else if ((int) this.type == 2 || (int) this.type == 23 || (int) this.type == 121)
      {
        if ((int) this.type == 2)
        {
          if ((double) this.velocity.X > 0.0)
          {
            this.spriteDirection = (sbyte) 1;
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
          }
          if ((double) this.velocity.X < 0.0)
          {
            this.spriteDirection = (sbyte) -1;
            this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 3.14f;
          }
        }
        else if ((int) this.type == 121)
        {
          if ((double) this.velocity.X > 0.0)
            this.spriteDirection = (sbyte) 1;
          if ((double) this.velocity.X < 0.0)
            this.spriteDirection = (sbyte) -1;
          this.rotation = this.velocity.X * 0.1f;
        }
        if ((double) ++this.frameCounter >= 8.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 133)
      {
        if ((double) this.velocity.X > 0.0)
        {
          this.spriteDirection = (sbyte) 1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
        }
        if ((double) this.velocity.X < 0.0)
        {
          this.spriteDirection = (sbyte) -1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 3.14f;
        }
        this.frameY = (double) ++this.frameCounter < 8.0 ? (short) 0 : this.frameHeight;
        if ((double) this.frameCounter >= 16.0)
        {
          this.frameY = (short) 0;
          this.frameCounter = 0.0f;
        }
        if ((double) this.life >= (double) this.lifeMax * 0.5)
          return;
        this.frameY = (short) ((int) this.frameY + ((int) this.frameHeight << 1));
      }
      else if ((int) this.type == 116)
      {
        if ((double) this.velocity.X > 0.0)
        {
          this.spriteDirection = (sbyte) 1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X);
        }
        if ((double) this.velocity.X < 0.0)
        {
          this.spriteDirection = (sbyte) -1;
          this.rotation = (float) Math.Atan2((double) this.velocity.Y, (double) this.velocity.X) + 3.14f;
        }
        if ((double) ++this.frameCounter >= 5.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 75)
      {
        this.spriteDirection = (double) this.velocity.X <= 0.0 ? (sbyte) -1 : (sbyte) 1;
        this.rotation = this.velocity.X * 0.1f;
        if ((double) ++this.frameCounter >= 4.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 55 || (int) this.type == 57 || ((int) this.type == 58 || (int) this.type == 102))
      {
        this.spriteDirection = this.direction;
        ++this.frameCounter;
        if (this.wet)
        {
          if ((double) this.frameCounter < 6.0)
            this.frameY = (short) 0;
          else if ((double) this.frameCounter < 12.0)
            this.frameY = this.frameHeight;
          else if ((double) this.frameCounter < 18.0)
            this.frameY = (short) ((int) this.frameHeight << 1);
          else if ((double) this.frameCounter < 24.0)
            this.frameY = (short) ((int) this.frameHeight * 3);
          else
            this.frameCounter = 0.0f;
        }
        else if ((double) this.frameCounter < 6.0)
          this.frameY = (short) ((int) this.frameHeight << 2);
        else if ((double) this.frameCounter < 12.0)
          this.frameY = (short) ((int) this.frameHeight * 5);
        else
          this.frameCounter = 0.0f;
      }
      else if ((int) this.type == 69 || (int) this.type == 147)
      {
        if ((double) this.ai0 < 190.0)
        {
          if ((double) ++this.frameCounter < 6.0)
            return;
          this.frameCounter = 0.0f;
          this.frameY += this.frameHeight;
          if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type] - 1)
            return;
          this.frameY = (short) 0;
        }
        else
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) ((int) this.frameHeight * ((int) NPC.npcFrameCount[(int) this.type] - 1));
        }
      }
      else if ((int) this.type == 86)
      {
        if ((double) this.velocity.Y == 0.0 || this.wet)
          this.spriteDirection = (double) this.velocity.X >= -2.0 ? ((double) this.velocity.X <= 2.0 ? this.direction : (sbyte) 1) : (sbyte) -1;
        if ((double) this.velocity.Y != 0.0)
        {
          this.frameY = (short) ((int) this.frameHeight * 15);
          this.frameCounter = 0.0f;
        }
        else if ((double) this.velocity.X == 0.0)
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) 0;
        }
        else if ((double) Math.Abs(this.velocity.X) < 3.0)
        {
          this.frameCounter += Math.Abs(this.velocity.X);
          if ((double) this.frameCounter < 6.0)
            return;
          this.frameCounter = 0.0f;
          this.frameY += this.frameHeight;
          if ((int) this.frameY / (int) this.frameHeight >= 9)
            this.frameY = this.frameHeight;
          if ((int) this.frameY / (int) this.frameHeight > 0)
            return;
          this.frameY = this.frameHeight;
        }
        else
        {
          this.frameCounter = this.frameCounter + Math.Abs(this.velocity.X);
          if ((double) this.frameCounter < 10.0)
            return;
          this.frameCounter = 0.0f;
          this.frameY += this.frameHeight;
          if ((int) this.frameY / (int) this.frameHeight >= 15)
            this.frameY = (short) ((int) this.frameHeight * 9);
          if ((int) this.frameY / (int) this.frameHeight > 8)
            return;
          this.frameY = (short) ((int) this.frameHeight * 9);
        }
      }
      else if ((int) this.type == (int) sbyte.MaxValue)
      {
        if ((double) this.ai1 == 0.0)
        {
          ++this.frameCounter;
          if ((double) this.frameCounter < 12.0)
            return;
          this.frameCounter = 0.0f;
          this.frameY += this.frameHeight;
          if ((int) this.frameY / (int) this.frameHeight < 2)
            return;
          this.frameY = (short) 0;
        }
        else
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) ((int) this.frameHeight << 1);
        }
      }
      else if ((int) this.type == 129)
      {
        if ((double) this.velocity.Y == 0.0)
          this.spriteDirection = this.direction;
        ++this.frameCounter;
        if ((double) this.frameCounter < 2.0)
          return;
        this.frameCounter = 0.0f;
        this.frameY += this.frameHeight;
        if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 130)
      {
        if ((double) this.velocity.Y == 0.0)
          this.spriteDirection = this.direction;
        ++this.frameCounter;
        if ((double) this.frameCounter < 8.0)
          return;
        this.frameCounter = 0.0f;
        this.frameY += this.frameHeight;
        if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 67)
      {
        if ((double) this.velocity.Y == 0.0)
          this.spriteDirection = this.direction;
        ++this.frameCounter;
        if ((double) this.frameCounter < 6.0)
          return;
        this.frameCounter = 0.0f;
        this.frameY += this.frameHeight;
        if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 109)
      {
        if ((double) this.velocity.Y == 0.0 && ((double) this.velocity.X <= 0.0 && (int) this.direction < 0 || (double) this.velocity.X >= 0.0 && (int) this.direction > 0))
          this.spriteDirection = this.direction;
        this.frameCounter += Math.Abs(this.velocity.X);
        if ((double) this.frameCounter < 7.0)
          return;
        this.frameCounter -= 7f;
        this.frameY += this.frameHeight;
        if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 83 || (int) this.type == 84 || (int) this.type == 151)
      {
        if ((double) this.ai0 == 2.0)
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) 0;
        }
        else
        {
          ++this.frameCounter;
          if ((double) this.frameCounter < 4.0)
            return;
          this.frameCounter = 0.0f;
          this.frameY += this.frameHeight;
          if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
            return;
          this.frameY = (short) 0;
        }
      }
      else if ((int) this.type == 72)
      {
        ++this.frameCounter;
        if ((double) this.frameCounter < 3.0)
          return;
        this.frameCounter = 0.0f;
        this.frameY += this.frameHeight;
        if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 65 || (int) this.type == 148)
      {
        this.spriteDirection = this.direction;
        ++this.frameCounter;
        if (!this.wet)
          return;
        if ((double) this.frameCounter < 6.0)
          this.frameY = (short) 0;
        else if ((double) this.frameCounter < 12.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 18.0)
          this.frameY = (short) ((int) this.frameHeight << 1);
        else if ((double) this.frameCounter < 24.0)
          this.frameY = (short) ((int) this.frameHeight * 3);
        else
          this.frameCounter = 0.0f;
      }
      else if ((int) this.type == 48 || (int) this.type == 49 || ((int) this.type == 51 || (int) this.type == 60) || ((int) this.type == 82 || (int) this.type == 93 || (int) this.type == 137))
      {
        if ((double) this.velocity.X > 0.0)
          this.spriteDirection = (sbyte) 1;
        if ((double) this.velocity.X < 0.0)
          this.spriteDirection = (sbyte) -1;
        this.rotation = this.velocity.X * 0.1f;
        ++this.frameCounter;
        if ((double) this.frameCounter >= 6.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * 4)
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 42 || (int) this.type == 157)
      {
        ++this.frameCounter;
        if ((double) this.frameCounter < 2.0)
          this.frameY = (short) 0;
        else if ((double) this.frameCounter < 4.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 6.0)
          this.frameY = (short) ((int) this.frameHeight << 1);
        else if ((double) this.frameCounter < 8.0)
          this.frameY = this.frameHeight;
        else
          this.frameCounter = 0.0f;
      }
      else if ((int) this.type == 43 || (int) this.type == 56 || (int) this.type == 156)
      {
        ++this.frameCounter;
        if ((double) this.frameCounter < 6.0)
          this.frameY = (short) 0;
        else if ((double) this.frameCounter < 12.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 18.0)
          this.frameY = (short) ((int) this.frameHeight << 1);
        else if ((double) this.frameCounter < 24.0)
          this.frameY = this.frameHeight;
        if ((double) this.frameCounter != 23.0)
          return;
        this.frameCounter = 0.0f;
      }
      else if ((int) this.type == 115)
      {
        ++this.frameCounter;
        if ((double) this.frameCounter < 3.0)
          this.frameY = (short) 0;
        else if ((double) this.frameCounter < 6.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 12.0)
          this.frameY = (short) ((int) this.frameHeight << 1);
        else if ((double) this.frameCounter < 15.0)
          this.frameY = this.frameHeight;
        if ((double) this.frameCounter != 15.0)
          return;
        this.frameCounter = 0.0f;
      }
      else if ((int) this.type == 101)
      {
        ++this.frameCounter;
        if ((double) this.frameCounter > 6.0)
        {
          this.frameY = (short) ((int) this.frameY + ((int) this.frameHeight << 1));
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY <= (int) this.frameHeight * 2)
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 17 || (int) this.type == 18 || ((int) this.type == 19 || (int) this.type == 20) || ((int) this.type == 22 || (int) this.type == 142 || ((int) this.type == 38 || (int) this.type == 26)) || ((int) this.type == 27 || (int) this.type == 28 || ((int) this.type == 31 || (int) this.type == 21) || ((int) this.type == 44 || (int) this.type == 54 || ((int) this.type == 37 || (int) this.type == 73))) || ((int) this.type == 77 || (int) this.type == 78 || ((int) this.type == 79 || (int) this.type == 80) || ((int) this.type == 104 || (int) this.type == 107 || ((int) this.type == 108 || (int) this.type == 120)) || ((int) this.type == 154 || (int) this.type == 124 || ((int) this.type == 140 || (int) this.type == 149) || ((int) this.type == 152 || (int) this.type == 155))))
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if ((int) this.direction == 1)
            this.spriteDirection = (sbyte) 1;
          else if ((int) this.direction == -1)
            this.spriteDirection = (sbyte) -1;
          if ((double) this.velocity.X == 0.0)
          {
            this.frameY = (int) this.type != 140 ? (short) 0 : this.frameHeight;
            this.frameCounter = 0.0f;
          }
          else
          {
            this.frameCounter += Math.Abs(this.velocity.X) * 2f;
            if ((double) ++this.frameCounter > 6.0)
            {
              this.frameY += this.frameHeight;
              this.frameCounter = 0.0f;
            }
            if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
              return;
            this.frameY = (short) ((int) this.frameHeight << 1);
          }
        }
        else
        {
          this.frameCounter = 0.0f;
          if ((int) this.type == 21 || (int) this.type == 31 || ((int) this.type == 44 || (int) this.type == 149) || ((int) this.type == 77 || (int) this.type == 78 || ((int) this.type == 79 || (int) this.type == 80)) || ((int) this.type == 120 || (int) this.type == 154 || ((int) this.type == 140 || (int) this.type == 152) || (int) this.type == 155))
            this.frameY = (short) 0;
          else
            this.frameY = this.frameHeight;
        }
      }
      else if ((int) this.type == 110)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if ((int) this.direction != 0)
            this.spriteDirection = this.direction;
          if ((double) this.ai2 > 0.0)
          {
            this.spriteDirection = this.direction;
            this.frameY = (short) ((int) this.frameHeight * (int) this.ai2);
            this.frameCounter = 0.0f;
          }
          else
          {
            if ((int) this.frameY < (int) this.frameHeight * 6)
              this.frameY = (short) ((int) this.frameHeight * 6);
            this.frameCounter = this.frameCounter + Math.Abs(this.velocity.X) * 2f;
            this.frameCounter += this.velocity.X;
            if ((double) this.frameCounter > 6.0)
            {
              this.frameY += this.frameHeight;
              this.frameCounter = 0.0f;
            }
            if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
              return;
            this.frameY = (short) ((int) this.frameHeight * 6);
          }
        }
        else
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) 0;
        }
      }
      else if ((int) this.type == 111)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if ((int) this.direction != 0)
            this.spriteDirection = this.direction;
          if ((double) this.ai2 > 0.0)
          {
            this.spriteDirection = this.direction;
            this.frameY = (short) ((int) this.frameHeight * ((int) this.ai2 - 1));
            this.frameCounter = 0.0f;
          }
          else
          {
            if ((int) this.frameY < (int) this.frameHeight * 7)
              this.frameY = (short) ((int) this.frameHeight * 7);
            this.frameCounter = this.frameCounter + Math.Abs(this.velocity.X) * 2f;
            this.frameCounter += this.velocity.X * 1.3f;
            if ((double) this.frameCounter > 6.0)
            {
              this.frameY += this.frameHeight;
              this.frameCounter = 0.0f;
            }
            if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
              return;
            this.frameY = (short) ((int) this.frameHeight * 7);
          }
        }
        else
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) ((int) this.frameHeight * 6);
        }
      }
      else if ((int) this.type == 3 || (int) this.type == 52 || ((int) this.type == 53 || (int) this.type == 132))
      {
        if ((double) this.velocity.Y == 0.0 && (int) this.direction != 0)
          this.spriteDirection = this.direction;
        if ((double) this.velocity.Y != 0.0 || (int) this.direction == -1 && (double) this.velocity.X > 0.0 || (int) this.direction == 1 && (double) this.velocity.X < 0.0)
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) ((int) this.frameHeight << 1);
        }
        else if ((double) this.velocity.X == 0.0)
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) 0;
        }
        else
        {
          this.frameCounter = this.frameCounter + Math.Abs(this.velocity.X);
          if ((double) this.frameCounter < 8.0)
            this.frameY = (short) 0;
          else if ((double) this.frameCounter < 16.0)
            this.frameY = this.frameHeight;
          else if ((double) this.frameCounter < 24.0)
            this.frameY = (short) ((int) this.frameHeight << 1);
          else if ((double) this.frameCounter < 32.0)
            this.frameY = this.frameHeight;
          else
            this.frameCounter = 0.0f;
        }
      }
      else if ((int) this.type == 46 || (int) this.type == 47)
      {
        if ((double) this.velocity.Y == 0.0)
        {
          if ((int) this.direction != 0)
            this.spriteDirection = this.direction;
          if ((double) this.velocity.X == 0.0)
          {
            this.frameY = (short) 0;
            this.frameCounter = 0.0f;
          }
          else
          {
            this.frameCounter = this.frameCounter + Math.Abs(this.velocity.X);
            ++this.frameCounter;
            if ((double) this.frameCounter > 6.0)
            {
              this.frameY += this.frameHeight;
              this.frameCounter = 0.0f;
            }
            if ((int) this.frameY / (int) this.frameHeight < (int) NPC.npcFrameCount[(int) this.type])
              return;
            this.frameY = (short) 0;
          }
        }
        else if ((double) this.velocity.Y < 0.0)
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) ((int) this.frameHeight << 2);
        }
        else
        {
          if ((double) this.velocity.Y <= 0.0)
            return;
          this.frameCounter = 0.0f;
          this.frameY = (short) ((int) this.frameHeight * 6);
        }
      }
      else if ((int) this.type == 4 || (int) this.type == 166 || ((int) this.type == 125 || (int) this.type == 126))
      {
        if ((double) ++this.frameCounter < 7.0)
          this.frameY = (short) 0;
        else if ((double) this.frameCounter < 14.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 21.0)
        {
          this.frameY = (short) ((int) this.frameHeight << 1);
        }
        else
        {
          this.frameCounter = 0.0f;
          this.frameY = (short) 0;
        }
        if ((double) this.ai0 <= 1.0)
          return;
        this.frameY = (short) ((int) this.frameY + (int) this.frameHeight * 3);
      }
      else if ((int) this.type == 5 || (int) this.type == 167)
      {
        if ((double) ++this.frameCounter >= 8.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 94)
      {
        if ((double) ++this.frameCounter < 6.0)
          this.frameY = (short) 0;
        else if ((double) this.frameCounter < 12.0)
          this.frameY = this.frameHeight;
        else if ((double) this.frameCounter < 18.0)
        {
          this.frameY = (short) ((int) this.frameHeight << 1);
        }
        else
        {
          this.frameY = this.frameHeight;
          if ((double) this.frameCounter < 23.0)
            return;
          this.frameCounter = 0.0f;
        }
      }
      else if ((int) this.type == 6)
      {
        ++this.frameCounter;
        if ((double) this.frameCounter >= 8.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
      else if ((int) this.type == 24)
      {
        if ((double) this.velocity.Y == 0.0 && (int) this.direction != 0)
          this.spriteDirection = this.direction;
        if ((double) this.ai1 > 0.0)
        {
          if ((int) this.frameY < 4)
            this.frameCounter = 0.0f;
          ++this.frameCounter;
          if ((double) this.frameCounter <= 4.0)
            this.frameY = (short) ((int) this.frameHeight << 2);
          else if ((double) this.frameCounter <= 8.0)
            this.frameY = (short) ((int) this.frameHeight * 5);
          else if ((double) this.frameCounter <= 12.0)
            this.frameY = (short) ((int) this.frameHeight * 6);
          else if ((double) this.frameCounter <= 16.0)
            this.frameY = (short) ((int) this.frameHeight * 7);
          else if ((double) this.frameCounter <= 20.0)
          {
            this.frameY = (short) ((int) this.frameHeight << 3);
          }
          else
          {
            this.frameY = (short) ((int) this.frameHeight * 9);
            this.frameCounter = 100f;
          }
        }
        else
        {
          ++this.frameCounter;
          if ((double) this.frameCounter <= 4.0)
            this.frameY = (short) 0;
          else if ((double) this.frameCounter <= 8.0)
            this.frameY = this.frameHeight;
          else if ((double) this.frameCounter <= 12.0)
          {
            this.frameY = (short) ((int) this.frameHeight << 1);
          }
          else
          {
            this.frameY = (short) ((int) this.frameHeight * 3);
            if ((double) this.frameCounter < 16.0)
              return;
            this.frameCounter = 0.0f;
          }
        }
      }
      else if ((int) this.type == 29 || (int) this.type == 32 || (int) this.type == 45)
      {
        if ((double) this.velocity.Y == 0.0 && (int) this.direction != 0)
          this.spriteDirection = this.direction;
        this.frameY = (short) 0;
        if ((double) this.velocity.Y != 0.0)
        {
          this.frameY += this.frameHeight;
        }
        else
        {
          if ((double) this.ai1 <= 0.0)
            return;
          this.frameY = (short) ((int) this.frameY + ((int) this.frameHeight << 1));
        }
      }
      else
      {
        if ((int) this.type != 34 && (int) this.type != 158)
          return;
        if ((double) ++this.frameCounter >= 4.0)
        {
          this.frameY += this.frameHeight;
          this.frameCounter = 0.0f;
        }
        if ((int) this.frameY < (int) this.frameHeight * (int) NPC.npcFrameCount[(int) this.type])
          return;
        this.frameY = (short) 0;
      }
    }

    public void TargetClosest(bool faceTarget = true)
    {
      int num = -1;
      this.target = (byte) 0;
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0 && !Main.player[index].dead && (num == -1 || Math.Abs(Main.player[index].aabb.X + 10 - this.aabb.X + ((int) this.width >> 1)) + Math.Abs(Main.player[index].aabb.Y + 21 - this.aabb.Y + ((int) this.height >> 1)) < num))
        {
          num = Math.Abs(Main.player[index].aabb.X + 10 - this.aabb.X + ((int) this.width >> 1)) + Math.Abs(Main.player[index].aabb.Y + 21 - this.aabb.Y + ((int) this.height >> 1));
          this.target = (byte) index;
        }
      }
      this.targetRect = Main.player[(int) this.target].aabb;
      if (Main.player[(int) this.target].dead)
        faceTarget = false;
      else if (faceTarget)
      {
        this.direction = (sbyte) 1;
        if (this.targetRect.X + (this.targetRect.Width >> 1) < this.aabb.X + ((int) this.width >> 1))
          this.direction = (sbyte) -1;
        this.directionY = (sbyte) 1;
        if (this.targetRect.Y + (this.targetRect.Height >> 1) < this.aabb.Y + ((int) this.height >> 1))
          this.directionY = (sbyte) -1;
      }
      if (this.confused)
        this.direction = -this.direction;
      if ((int) this.direction == (int) this.oldDirection && (int) this.directionY == (int) this.oldDirectionY && (int) this.target == (int) this.oldTarget || (this.collideX || this.collideY))
        return;
      this.netUpdate = true;
    }

    public void CheckActive()
    {
      if ((int) this.active == 0 || (int) this.type == 8 || ((int) this.type == 9 || (int) this.type == 11) || ((int) this.type == 12 || (int) this.type == 14 || ((int) this.type == 15 || (int) this.type == 40)) || ((int) this.type == 41 || (int) this.type == 96 || ((int) this.type == 97 || (int) this.type == 99) || ((int) this.type == 100 || (int) this.type > 87 && (int) this.type <= 92)) || ((int) this.type > 159 && (int) this.type <= 164 || ((int) this.type == 118 || (int) this.type == 119) || ((int) this.type == 113 || (int) this.type == 114 || (int) this.type == 115) || (int) this.type >= 134 && (int) this.type <= 136))
        return;
      if (this.townNPC)
      {
        Rectangle rectangle = new Rectangle(this.aabb.X + ((int) this.width >> 1) - 1920, this.aabb.Y + ((int) this.height >> 1) - 1080, 3840, 2160);
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0 && rectangle.Intersects(Main.player[index].aabb))
            Main.player[index].townNPCs += this.npcSlots;
        }
      }
      else
      {
        bool flag = false;
        Rectangle rectangle1 = new Rectangle(this.aabb.X + ((int) this.width >> 1) - 3264, this.aabb.Y + ((int) this.height >> 1) - 1836, 6528, 3672);
        Rectangle rectangle2 = new Rectangle(this.aabb.X + ((int) this.width >> 1) - 960 - (int) this.width, this.aabb.Y + ((int) this.height >> 1) - 540 - (int) this.height, 1920 + (int) this.width * 2, 1080 + (int) this.height * 2);
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0)
          {
            if (rectangle1.Intersects(Main.player[index].aabb))
            {
              flag = true;
              if ((int) this.type != 25 && (int) this.type != 30 && ((int) this.type != 33 && this.lifeMax > 0))
                Main.player[index].activeNPCs += this.npcSlots;
            }
            else if (this.boss || (int) this.type == 7 || ((int) this.type == 10 || (int) this.type == 13) || ((int) this.type == 39 || (int) this.type == 87 || ((int) this.type == 159 || (int) this.type == 35)) || ((int) this.type == 36 || (int) this.type >= (int) sbyte.MaxValue && (int) this.type <= 131))
              flag = true;
            if (rectangle2.Intersects(Main.player[index].aabb))
              this.timeLeft = 750;
          }
        }
        if (--this.timeLeft <= 0)
          flag = false;
        if (flag || Main.netMode == 1)
          return;
        NPC.noSpawnCycle = true;
        this.active = (byte) 0;
        this.netSkip = (short) -1;
        this.life = 0;
        NetMessage.CreateMessage1(23, (int) this.whoAmI);
        NetMessage.SendMessage();
        if ((int) this.aiStyle != 6)
          return;
        for (int number = (int) this.ai0; number > 0; number = (int) Main.npc[number].ai0)
        {
          if ((int) Main.npc[number].active != 0)
          {
            Main.npc[number].active = (byte) 0;
            Main.npc[number].life = 0;
            Main.npc[number].netSkip = (short) -1;
            NetMessage.CreateMessage1(23, number);
            NetMessage.SendMessage();
          }
        }
      }
    }

    public static void SpawnNPC()
    {
      if (NPC.noSpawnCycle)
      {
        NPC.noSpawnCycle = false;
      }
      else
      {
        bool flag1 = false;
        bool flag2 = false;
        int x = 0;
        int y = 0;
        int num1 = 0;
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0)
            ++num1;
        }
        for (int index1 = 0; index1 < 8; ++index1)
        {
          if ((int) Main.player[index1].active != 0 && !Main.player[index1].dead)
          {
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            if (Main.invasionType > 0 && Main.invasionDelay == 0 && (Main.invasionSize > 0 && (double) Main.player[index1].position.Y < (double) (Main.worldSurfacePixels + 1080)))
            {
              int num2 = 3000;
              if ((double) Main.player[index1].position.X > (double) Main.invasionX * 16.0 - (double) num2 && (double) Main.player[index1].position.X < (double) Main.invasionX * 16.0 + (double) num2)
                flag4 = true;
            }
            bool flag6 = false;
            NPC.spawnRate = 600;
            NPC.maxSpawns = 5;
            if (Main.hardMode)
            {
              NPC.spawnRate = 540;
              NPC.maxSpawns = 6;
            }
            if ((double) Main.player[index1].position.Y > (double) (((int) Main.maxTilesY - 200) * 16))
              NPC.maxSpawns *= 2;
            else if ((double) Main.player[index1].position.Y > (double) ((Main.rockLayer << 4) + 1080))
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.9);
            }
            else if ((double) Main.player[index1].position.Y > (double) ((Main.worldSurface << 4) + 1080))
            {
              if (Main.hardMode)
              {
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.45);
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.8);
              }
              else
              {
                NPC.spawnRate >>= 1;
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.7);
              }
            }
            else if (!Main.gameTime.dayTime)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.6);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.3);
              if (Main.gameTime.bloodMoon)
              {
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.3);
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.8);
              }
            }
            if (Main.player[index1].zoneDungeon)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.70000004768372);
            }
            else if (Main.player[index1].zoneJungle)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.5);
            }
            else if (Main.player[index1].zoneEvil)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.65);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.29999995231628);
            }
            else if (Main.player[index1].zoneMeteor)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.4);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.10000002384186);
            }
            if (Main.player[index1].zoneHoly && (double) Main.player[index1].position.Y > (double) ((Main.rockLayer << 4) + 1080))
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.65);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.29999995231628);
            }
            if (NPC.wof >= 0 && (double) Main.player[index1].position.Y > (double) (((int) Main.maxTilesY - 200) * 16))
            {
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.300000011920929);
              NPC.spawnRate *= 3;
            }
            if ((double) Main.player[index1].activeNPCs < (double) (int) ((double) NPC.maxSpawns * 0.2))
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.600000023841858);
            else if ((double) Main.player[index1].activeNPCs < (double) (int) ((double) NPC.maxSpawns * 0.4))
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.699999988079071);
            else if ((double) Main.player[index1].activeNPCs < (double) (int) ((double) NPC.maxSpawns * 0.6))
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.800000011920929);
            else if ((double) Main.player[index1].activeNPCs < (double) (int) ((double) NPC.maxSpawns * 0.8))
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.899999976158142);
            if ((double) Main.player[index1].position.Y * 16.0 > (double) (Main.worldSurface + Main.rockLayer >> 1) || Main.player[index1].zoneEvil)
            {
              if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.2)
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.699999988079071);
              else if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns * 0.4)
                NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.899999976158142);
            }
            if ((int) Main.player[index1].inventory[(int) Main.player[index1].selectedItem].type == 148)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.75);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 1.5);
            }
            if (Main.player[index1].enemySpawns)
            {
              NPC.spawnRate = (int) ((double) NPC.spawnRate * 0.5);
              NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 2.0);
            }
            if ((double) NPC.spawnRate < 60.0)
              NPC.spawnRate = 60;
            if (NPC.maxSpawns > 15)
              NPC.maxSpawns = 15;
            if (flag4)
            {
              NPC.maxSpawns = (int) (5.0 * (2.0 + 0.3 * (double) num1));
              NPC.spawnRate = 20;
            }
            if (Main.player[index1].zoneDungeon && !NPC.downedBoss3)
              NPC.spawnRate = 10;
            bool flag7 = false;
            if (!flag4 && (!Main.gameTime.bloodMoon || Main.gameTime.dayTime) && (!Main.player[index1].zoneDungeon && !Main.player[index1].zoneEvil && !Main.player[index1].zoneMeteor))
            {
              if ((double) Main.player[index1].townNPCs == 1.0)
              {
                flag3 = true;
                if (Main.rand.Next(3) <= 1)
                {
                  flag7 = true;
                  NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.6);
                }
                else
                  NPC.spawnRate = (int) ((double) NPC.spawnRate * 2.0);
              }
              else if ((double) Main.player[index1].townNPCs == 2.0)
              {
                flag3 = true;
                if (Main.rand.Next(3) == 0)
                {
                  flag7 = true;
                  NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.6);
                }
                else
                  NPC.spawnRate = (int) ((double) NPC.spawnRate * 3.0);
              }
              else if ((double) Main.player[index1].townNPCs >= 3.0)
              {
                flag3 = true;
                flag7 = true;
                NPC.maxSpawns = (int) ((double) NPC.maxSpawns * 0.6);
              }
            }
            if ((double) Main.player[index1].activeNPCs < (double) NPC.maxSpawns && Main.rand.Next(NPC.spawnRate) == 0)
            {
              int num2 = Main.player[index1].aabb.X >> 4;
              int num3 = Main.player[index1].aabb.Y >> 4;
              int lowerBound1 = num2 - 84;
              int upperBound1 = num2 + 84;
              int lowerBound2 = num3 - 46;
              int upperBound2 = num3 + 46;
              int num4 = num2 - 62;
              int num5 = num2 + 62;
              int num6 = num3 - 34;
              int num7 = num3 + 34;
              if (lowerBound1 < 0)
                lowerBound1 = 0;
              else if (upperBound1 > (int) Main.maxTilesX)
                upperBound1 = (int) Main.maxTilesX;
              if (lowerBound2 < 0)
                lowerBound2 = 0;
              else if (upperBound2 > (int) Main.maxTilesY)
                upperBound2 = (int) Main.maxTilesY;
              for (int index2 = 0; index2 < 48; ++index2)
              {
                int index3 = Main.rand.Next(lowerBound1, upperBound1);
                int index4 = Main.rand.Next(lowerBound2, upperBound2);
                if (((int) Main.tile[index3, index4].active == 0 || !Main.tileSolid[(int) Main.tile[index3, index4].type]) && !Main.wallHouse[(int) Main.tile[index3, index4].wall])
                {
                  if (!flag4 && !flag7 && (index4 < (int) ((double) Main.worldSurface * 0.349999994039536) && (index3 < (int) ((double) Main.maxTilesX * 0.45) || index3 > (int) ((double) Main.maxTilesX * 0.55) || Main.hardMode) || index4 < (int) ((double) Main.worldSurface * 0.449999988079071) && Main.hardMode && Main.rand.Next(10) == 0))
                  {
                    int num8 = (int) Main.tile[index3, index4].type;
                    x = index3;
                    y = index4;
                    flag6 = true;
                    flag2 = true;
                  }
                  if (!flag6)
                  {
                    for (int index5 = index4; index5 < (int) Main.maxTilesY; ++index5)
                    {
                      if ((int) Main.tile[index3, index5].active != 0 && Main.tileSolid[(int) Main.tile[index3, index5].type])
                      {
                        if (index3 < num4 || index3 > num5 || (index5 < num6 || index5 > num7))
                        {
                          int num8 = (int) Main.tile[index3, index5].type;
                          x = index3;
                          y = index5;
                          flag6 = true;
                          break;
                        }
                        else
                          break;
                      }
                    }
                  }
                  if (flag6)
                  {
                    int num8 = x - 1;
                    int num9 = x + 1;
                    int num10 = y - 3;
                    int num11 = y;
                    if (num8 < 0 || num9 > (int) Main.maxTilesX || (num10 < 0 || num11 > (int) Main.maxTilesY))
                    {
                      flag6 = false;
                    }
                    else
                    {
                      for (int index5 = num8; index5 < num9; ++index5)
                      {
                        for (int index6 = num10; index6 < num11; ++index6)
                        {
                          if ((int) Main.tile[index5, index6].active != 0 && Main.tileSolid[(int) Main.tile[index5, index6].type])
                          {
                            flag6 = false;
                            break;
                          }
                          else if ((int) Main.tile[index5, index6].lava != 0)
                          {
                            flag6 = false;
                            break;
                          }
                        }
                        if (!flag6)
                          break;
                      }
                    }
                    if (flag6)
                      break;
                  }
                }
              }
            }
            if (flag6)
            {
              Rectangle rectangle1 = new Rectangle(x * 16, y * 16, 16, 16);
              for (int index2 = 0; index2 < 8; ++index2)
              {
                if ((int) Main.player[index2].active != 0)
                {
                  Rectangle rectangle2 = new Rectangle(Main.player[index2].aabb.X + 10 - 960 - 62, Main.player[index2].aabb.Y + 21 - 540 - 34, 2044, 1148);
                  if (rectangle1.Intersects(rectangle2))
                  {
                    flag6 = false;
                    break;
                  }
                }
              }
            }
            if (flag6)
            {
              if (Main.player[index1].zoneDungeon && (!Main.tileDungeon[(int) Main.tile[x, y].type] || (int) Main.tile[x, y - 1].wall == 0))
                flag6 = false;
              if ((int) Main.tile[x, y - 1].liquid > 0 && (int) Main.tile[x, y - 2].liquid > 0 && (int) Main.tile[x, y - 1].lava == 0)
                flag5 = true;
            }
            if (flag6)
            {
              flag1 = false;
              int num2 = (int) Main.tile[x, y].type;
              int number = 196;
              int X = (x << 4) + 8;
              int Y = y << 4;
              if (flag2)
              {
                if (Main.hardMode && Main.rand.Next(10) == 0 && !NPC.AnyNPCs(87, 159))
                {
                  int Type = Main.rand.Next(2) == 0 ? 87 : 159;
                  NPC.NewNPC(X, Y, Type, 1);
                }
                else
                  NPC.NewNPC(X, Y, 48, 0);
              }
              else if (flag4)
              {
                if (Main.invasionType == 1)
                {
                  if (Main.rand.Next(9) == 0)
                    NPC.NewNPC(X, Y, 29, 0);
                  else if (Main.rand.Next(5) == 0)
                    NPC.NewNPC(X, Y, 26, 0);
                  else if (Main.rand.Next(3) == 0)
                    NPC.NewNPC(X, Y, 111, 0);
                  else if (Main.rand.Next(3) == 0)
                    NPC.NewNPC(X, Y, 27, 0);
                  else
                    NPC.NewNPC(X, Y, 28, 0);
                }
                else if (Main.invasionType == 2)
                {
                  if (Main.rand.Next(7) == 0)
                    NPC.NewNPC(X, Y, 145, 0);
                  else if (Main.rand.Next(3) == 0)
                    NPC.NewNPC(X, Y, 143, 0);
                  else
                    NPC.NewNPC(X, Y, 144, 0);
                }
              }
              else if (flag5 && (x < 250 || x > (int) Main.maxTilesX - 250) && (num2 == 53 && y < Main.rockLayer))
              {
                int Type;
                switch (Main.rand.Next(16))
                {
                  case 0:
                    Type = 65;
                    break;
                  case 1:
                    Type = 148;
                    break;
                  case 2:
                  case 3:
                  case 4:
                  case 5:
                  case 6:
                    Type = 67;
                    break;
                  default:
                    Type = 64;
                    break;
                }
                NPC.NewNPC(X, Y, Type, 0);
              }
              else if (flag5 && (y > Main.rockLayer && Main.rand.Next(2) == 0 || num2 == 60))
              {
                if (Main.hardMode && Main.rand.Next(3) > 0)
                  NPC.NewNPC(X, Y, 102, 0);
                else
                  NPC.NewNPC(X, Y, 58, 0);
              }
              else if (flag5 && y > Main.worldSurface && Main.rand.Next(3) == 0)
              {
                if (Main.hardMode)
                  NPC.NewNPC(X, Y, 103, 0);
                else
                  NPC.NewNPC(X, Y, 63, 0);
              }
              else if (flag5 && Main.rand.Next(4) == 0)
              {
                if (Main.player[index1].zoneEvil)
                  NPC.NewNPC(X, Y, 57, 0);
                else
                  NPC.NewNPC(X, Y, 55, 0);
              }
              else if (NPC.downedGoblins && Main.rand.Next(20) == 0 && (!flag5 && y >= Main.rockLayer) && (y < (int) Main.maxTilesY - 210 && !NPC.savedGoblin && !NPC.AnyNPCs(105)))
                NPC.NewNPC(X, Y, 105, 0);
              else if (Main.hardMode && Main.rand.Next(20) == 0 && (!flag5 && y >= Main.rockLayer) && (y < (int) Main.maxTilesY - 210 && !NPC.savedWizard && !NPC.AnyNPCs(106)))
                NPC.NewNPC(X, Y, 106, 0);
              else if (flag7)
              {
                if (flag5)
                {
                  NPC.NewNPC(X, Y, 55, 0);
                }
                else
                {
                  if (num2 != 2 && num2 != 109 && (num2 != 147 && y <= Main.worldSurface))
                    break;
                  if (Main.rand.Next(2) == 0 && y <= Main.worldSurface)
                    NPC.NewNPC(X, Y, 74, 0);
                  else
                    NPC.NewNPC(X, Y, 46, 0);
                }
              }
              else if (Main.player[index1].zoneDungeon)
              {
                if (!NPC.downedBoss3)
                  number = NPC.NewNPC(X, Y, 68, 0);
                else if (!NPC.savedMech && !flag5 && (Main.rand.Next(5) == 0 && y > Main.rockLayer) && !NPC.AnyNPCs(123))
                  NPC.NewNPC(X, Y, 123, 0);
                else if (Main.rand.Next(37) == 0)
                  number = NPC.NewNPC(X, Y, 71, 0);
                else if (Main.rand.Next(4) == 0 && !NPC.NearSpikeBall(x, y))
                  number = NPC.NewNPC(X, Y, 70, 0);
                else if (Main.rand.Next(15) == 0)
                  number = NPC.NewNPC(X, Y, 72, 0);
                else if (Main.rand.Next(9) == 0)
                  number = NPC.NewNPC(X, Y, Main.rand.Next(2) == 0 ? 34 : 158, 0);
                else if (Main.rand.Next(7) == 0)
                {
                  number = NPC.NewNPC(X, Y, 32, 0);
                }
                else
                {
                  number = NPC.NewNPC(X, Y, 31, 0);
                  if (Main.rand.Next(4) == 0)
                    Main.npc[number].SetDefaults("Big Boned");
                  else if (Main.rand.Next(5) == 0)
                    Main.npc[number].SetDefaults("Short Bones");
                }
              }
              else if (Main.player[index1].zoneMeteor)
                number = NPC.NewNPC(X, Y, 23, 0);
              else if (Main.player[index1].zoneEvil && Main.rand.Next(65) == 0)
                number = !Main.hardMode || Main.rand.Next(4) == 0 ? NPC.NewNPC(X, Y, 7, 1) : NPC.NewNPC(X, Y, 98, 1);
              else if (Main.hardMode && y > Main.worldSurface && Main.rand.Next(75) == 0)
                number = NPC.NewNPC(X, Y, 85, 0);
              else if (Main.hardMode && (int) Main.tile[x, y - 1].wall == 2 && Main.rand.Next(20) == 0)
                number = NPC.NewNPC(X, Y, 85, 0);
              else if (Main.hardMode && y <= Main.worldSurface && !Main.gameTime.dayTime && (Main.rand.Next(20) == 0 || Main.rand.Next(5) == 0 && (int) Main.gameTime.moonPhase == 4))
                number = NPC.NewNPC(X, Y, 82, 0);
              else if (num2 == 60 && Main.rand.Next(500) == 0 && !Main.gameTime.dayTime)
                number = NPC.NewNPC(X, Y, 52, 0);
              else if (num2 == 60 && y > Main.worldSurface + Main.rockLayer >> 1)
              {
                if (Main.rand.Next(3) == 0)
                {
                  number = NPC.NewNPC(X, Y, 43, 0);
                  Main.npc[number].ai0 = (float) x;
                  Main.npc[number].ai1 = (float) y;
                  Main.npc[number].netUpdate = true;
                }
                else if (Main.rand.Next(2) == 0)
                {
                  number = NPC.NewNPC(X, Y, 42, 0);
                  switch (Main.rand.Next(8))
                  {
                    case 0:
                    case 1:
                      Main.npc[number].SetDefaults("Little Stinger");
                      break;
                    case 2:
                      Main.npc[number].SetDefaults("Big Stinger");
                      break;
                  }
                }
                else
                  number = NPC.NewNPC(X, Y, 157, 0);
              }
              else if (num2 == 60 && Main.rand.Next(4) == 0)
                number = NPC.NewNPC(X, Y, 51, 0);
              else if (num2 == 60 && Main.rand.Next(8) == 0)
              {
                number = NPC.NewNPC(X, Y, Main.rand.Next(2) == 0 ? 56 : 156, 0);
                Main.npc[number].ai0 = (float) x;
                Main.npc[number].ai1 = (float) y;
                Main.npc[number].netUpdate = true;
              }
              else if (Main.hardMode && num2 == 53 && Main.rand.Next(3) == 0)
                number = NPC.NewNPC(X, Y, 78, 0);
              else if (Main.hardMode && num2 == 112 && Main.rand.Next(2) == 0)
                number = NPC.NewNPC(X, Y, Main.rand.Next(2) == 0 ? 79 : 152, 0);
              else if (Main.hardMode && num2 == 116 && Main.rand.Next(2) == 0)
                number = NPC.NewNPC(X, Y, Main.rand.Next(2) == 0 ? 80 : 155, 0);
              else if (Main.hardMode && !flag5 && y < Main.rockLayer && (num2 == 116 || num2 == 117 || num2 == 109))
                number = Main.gameTime.dayTime || Main.rand.Next(2) != 0 ? (Main.rand.Next(10) != 0 ? NPC.NewNPC(X, Y, 75, 0) : NPC.NewNPC(X, Y, 86, 0)) : NPC.NewNPC(X, Y, Main.rand.Next(2) == 0 ? 122 : 153, 0);
              else if (!flag3 && Main.hardMode && (Main.rand.Next(50) == 0 && !flag5) && y >= Main.rockLayer && (num2 == 116 || num2 == 117 || num2 == 109))
                number = NPC.NewNPC(X, Y, 84, 0);
              else if (num2 == 22 && Main.player[index1].zoneEvil || (num2 == 23 || num2 == 25) || num2 == 112)
              {
                if (Main.hardMode && y >= Main.rockLayer && Main.rand.Next(3) == 0)
                {
                  number = NPC.NewNPC(X, Y, 101, 0);
                  Main.npc[number].ai0 = (float) x;
                  Main.npc[number].ai1 = (float) y;
                  Main.npc[number].netUpdate = true;
                }
                else if (Main.hardMode && Main.rand.Next(3) == 0)
                {
                  int Type;
                  switch (Main.rand.Next(3))
                  {
                    case 0:
                      Type = 150;
                      break;
                    case 1:
                      Type = 81;
                      break;
                    default:
                      Type = 121;
                      break;
                  }
                  number = NPC.NewNPC(X, Y, Type, 0);
                }
                else if (Main.hardMode && y >= Main.rockLayer && Main.rand.Next(40) == 0)
                  number = Main.rand.Next(2) != 0 ? NPC.NewNPC(X, Y, 151, 0) : NPC.NewNPC(X, Y, 83, 0);
                else if (Main.hardMode && (Main.rand.Next(2) == 0 || y > Main.rockLayer))
                {
                  number = NPC.NewNPC(X, Y, 94, 0);
                }
                else
                {
                  number = NPC.NewNPC(X, Y, 6, 0);
                  if (Main.rand.Next(3) == 0)
                    Main.npc[number].SetDefaults("Little Eater");
                  else if (Main.rand.Next(3) == 0)
                    Main.npc[number].SetDefaults("Big Eater");
                }
              }
              else if (y <= Main.worldSurface)
              {
                if (Main.gameTime.dayTime)
                {
                  int num3 = Math.Abs(x - (int) Main.spawnTileX);
                  if (num3 < (int) Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num2 == 2 || num2 == 109 || num2 == 147))
                    NPC.NewNPC(X, Y, 46, 0);
                  else if (num3 < (int) Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num2 == 2 || num2 == 109 || num2 == 147))
                    NPC.NewNPC(X, Y, 74, 0);
                  else if (num3 > (int) Main.maxTilesX / 3 && num2 == 2 && (Main.rand.Next(300) == 0 && !NPC.AnyNPCs(50)))
                    number = NPC.NewNPC(X, Y, 50, 0);
                  else if (num2 == 53 && Main.rand.Next(5) == 0 && !flag5)
                    number = NPC.NewNPC(X, Y, Main.rand.Next(2) == 0 ? 69 : 147, 0);
                  else if (num2 == 53 && !flag5)
                    number = NPC.NewNPC(X, Y, 61, 0);
                  else if (num3 > (int) Main.maxTilesX / 3 && Main.rand.Next(15) == 0)
                  {
                    number = NPC.NewNPC(X, Y, 73, 0);
                  }
                  else
                  {
                    number = NPC.NewNPC(X, Y, 1, 0);
                    if (num2 == 60)
                      Main.npc[number].SetDefaults("Jungle Slime");
                    else if (Main.rand.Next(3) == 0 || num3 < 200)
                      Main.npc[number].SetDefaults("Green Slime");
                    else if (Main.rand.Next(10) == 0 && num3 > 400)
                      Main.npc[number].SetDefaults("Purple Slime");
                  }
                }
                else if (Main.rand.Next(6) == 0 || (int) Main.gameTime.moonPhase == 4 && Main.rand.Next(2) == 0)
                  number = !Main.hardMode || Main.rand.Next(3) != 0 ? NPC.NewNPC(X, Y, 2, 0) : NPC.NewNPC(X, Y, 133, 0);
                else if (Main.hardMode && Main.rand.Next(50) == 0 && (Main.gameTime.bloodMoon && !NPC.AnyNPCs(109)))
                  NPC.NewNPC(X, Y, 109, 0);
                else if (Main.rand.Next(250) == 0 && Main.gameTime.bloodMoon)
                  NPC.NewNPC(X, Y, 53, 0);
                else if ((int) Main.gameTime.moonPhase == 0 && Main.hardMode && Main.rand.Next(3) != 0)
                  NPC.NewNPC(X, Y, 104, 0);
                else if (Main.hardMode && Main.rand.Next(3) == 0)
                  NPC.NewNPC(X, Y, 140, 0);
                else if (Main.rand.Next(3) == 0)
                  NPC.NewNPC(X, Y, 132, 0);
                else
                  NPC.NewNPC(X, Y, 3, 0);
              }
              else if (y <= Main.rockLayer)
              {
                if (!flag3 && Main.rand.Next(50) == 0)
                  number = !Main.hardMode ? NPC.NewNPC(X, Y, 10, 1) : NPC.NewNPC(X, Y, 95, 1);
                else if (Main.hardMode && Main.rand.Next(3) == 0)
                  number = NPC.NewNPC(X, Y, 140, 0);
                else if (Main.hardMode && Main.rand.Next(4) != 0)
                {
                  number = NPC.NewNPC(X, Y, 141, 0);
                }
                else
                {
                  number = NPC.NewNPC(X, Y, 1, 0);
                  if (Main.rand.Next(5) == 0)
                    Main.npc[number].SetDefaults("Yellow Slime");
                  else if (Main.rand.Next(2) == 0)
                    Main.npc[number].SetDefaults("Red Slime");
                }
              }
              else if (y > (int) Main.maxTilesY - 190)
              {
                int Type = 60;
                int Start = 0;
                if (Main.rand.Next(40) == 0 && !NPC.AnyNPCs(39))
                {
                  Type = 39;
                  Start = 1;
                }
                else if (Main.rand.Next(14) == 0)
                  Type = 24;
                else if (Main.rand.Next(8) == 0)
                {
                  switch (Main.rand.Next(7))
                  {
                    case 0:
                      Type = 66;
                      break;
                    case 1:
                    case 2:
                    case 3:
                      Type = 62;
                      break;
                    default:
                      Type = 165;
                      break;
                  }
                }
                else if (Main.rand.Next(3) == 0)
                  Type = 59;
                number = NPC.NewNPC(X, Y, Type, Start);
              }
              else if ((num2 == 116 || num2 == 117) && (!flag3 && Main.rand.Next(8) == 0))
                number = NPC.NewNPC(X, Y, Main.rand.Next(2) == 0 ? 120 : 154, 0);
              else if (!flag3 && Main.rand.Next(75) == 0 && !Main.player[index1].zoneHoly)
                number = NPC.NewNPC(X, Y, Main.hardMode ? 95 : 10, 1);
              else if (!Main.hardMode && Main.rand.Next(10) == 0)
                number = NPC.NewNPC(X, Y, 16, 0);
              else if (!Main.hardMode && Main.rand.Next(4) == 0)
              {
                number = NPC.NewNPC(X, Y, 1, 0);
                if (Main.player[index1].zoneJungle)
                  Main.npc[number].SetDefaults("Jungle Slime");
                else
                  Main.npc[number].SetDefaults("Black Slime");
              }
              else if (Main.rand.Next(2) == 0)
              {
                if (y > Main.rockLayer + (int) Main.maxTilesY >> 1 && Main.rand.Next(700) == 0)
                  number = NPC.NewNPC(X, Y, 45, 0);
                else if (Main.hardMode && Main.rand.Next(10) != 0)
                {
                  if (Main.rand.Next(2) == 0)
                  {
                    number = NPC.NewNPC(X, Y, 77, 0);
                    if (y > Main.rockLayer + (int) Main.maxTilesY >> 1 && Main.rand.Next(5) == 0)
                      Main.npc[number].SetDefaults("Heavy Skeleton");
                  }
                  else
                    number = NPC.NewNPC(X, Y, 110, 0);
                }
                else if (Main.rand.Next(15) == 0)
                {
                  int Type = Main.rand.Next(2) == 0 ? 44 : 149;
                  number = NPC.NewNPC(X, Y, Type, 0);
                }
                else
                  number = NPC.NewNPC(X, Y, 21, 0);
              }
              else
                number = !Main.hardMode || !(Main.player[index1].zoneHoly & Main.rand.Next(2) == 0) ? (!Main.player[index1].zoneJungle ? (!Main.hardMode || !Main.player[index1].zoneHoly ? (!Main.hardMode || Main.rand.Next(6) <= 0 ? NPC.NewNPC(X, Y, 49, 0) : NPC.NewNPC(X, Y, 93, 0)) : NPC.NewNPC(X, Y, 137, 0)) : NPC.NewNPC(X, Y, 51, 0)) : NPC.NewNPC(X, Y, 138, 0);
              if (number >= 196)
                break;
              if ((int) Main.npc[number].type == 1 && Main.rand.Next(250) == 0)
                Main.npc[number].SetDefaults("Pinky");
              NetMessage.CreateMessage1(23, number);
              NetMessage.SendMessage();
              break;
            }
          }
        }
      }
    }

    public static bool SpawnWOF(ref Vector2 pos, bool force = false)
    {
      if (!force && (int) pos.Y >> 4 < (int) Main.maxTilesY - 205 || (NPC.wof >= 0 || Main.netMode == 1))
        return false;
      int num1 = -16;
      int X = (int) pos.X;
      if (X >> 4 > (int) Main.maxTilesX >> 1)
        num1 = 16;
      bool flag;
      do
      {
        flag = true;
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0 && Main.player[index].aabb.X > X - 1200 && Main.player[index].aabb.X < X + 1200)
          {
            X += num1;
            flag = false;
            break;
          }
        }
        if (num1 < 0 && X >> 4 < 42 || num1 > 0 && X >> 4 > (int) Main.maxTilesX - 34)
          flag = true;
      }
      while (!flag);
      int num2 = (int) pos.Y;
      int i = X >> 4;
      int num3 = num2 >> 4;
      int num4 = 0;
      try
      {
        for (; WorldGen.SolidTile(i, num3 - num4) || (int) Main.tile[i, num3 - num4].liquid >= 100; ++num4)
        {
          if (!WorldGen.SolidTile(i, num3 + num4) && (int) Main.tile[i, num3 + num4].liquid < 100)
          {
            num3 += num4;
            goto label_19;
          }
        }
        num3 -= num4;
      }
      catch
      {
      }
label_19:
      int Y = num3 << 4;
      int index1 = NPC.NewNPC(X, Y, 113, 0);
      Main.npc[index1].direction = num1 < 0 ? (sbyte) 1 : (sbyte) -1;
      if (Main.npc[index1].displayName.Length == 0)
        Main.npc[index1].displayName = Main.npc[index1].name;
      NetMessage.SendText(Main.npc[index1].displayName, 16, 175, 75, (int) byte.MaxValue, -1);
      return true;
    }

    public static void SpawnOnPlayer(Player p, int Type)
    {
      if (Main.netMode == 1)
        return;
      bool flag = false;
      int num1 = 0;
      int num2 = 0;
      int lowerBound1 = (p.aabb.X >> 4) - 168;
      int upperBound1 = (p.aabb.X >> 4) + 168;
      int lowerBound2 = (p.aabb.Y >> 4) - 92;
      int upperBound2 = (p.aabb.Y >> 4) + 92;
      int num3 = (p.aabb.X >> 4) - 62;
      int num4 = (p.aabb.X >> 4) + 62;
      int num5 = (p.aabb.Y >> 4) - 34;
      int num6 = (p.aabb.Y >> 4) + 34;
      if (lowerBound1 < 0)
        lowerBound1 = 0;
      if (upperBound1 > (int) Main.maxTilesX)
        upperBound1 = (int) Main.maxTilesX;
      if (lowerBound2 < 0)
        lowerBound2 = 0;
      if (upperBound2 > (int) Main.maxTilesY)
        upperBound2 = (int) Main.maxTilesY;
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        for (int index2 = 0; index2 < 100; ++index2)
        {
          int index3 = Main.rand.Next(lowerBound1, upperBound1);
          int index4 = Main.rand.Next(lowerBound2, upperBound2);
          if ((int) Main.tile[index3, index4].active == 0 || !Main.tileSolid[(int) Main.tile[index3, index4].type])
          {
            if (!Main.wallHouse[(int) Main.tile[index3, index4].wall] || index1 >= 999)
            {
              for (int index5 = index4; index5 < (int) Main.maxTilesY; ++index5)
              {
                if ((int) Main.tile[index3, index5].active != 0 && Main.tileSolid[(int) Main.tile[index3, index5].type])
                {
                  if (index3 < num3 || index3 > num4 || (index5 < num5 || index5 > num6) || index1 == 999)
                  {
                    int num7 = (int) Main.tile[index3, index5].type;
                    num1 = index3;
                    num2 = index5;
                    flag = true;
                    break;
                  }
                  else
                    break;
                }
              }
              if (flag && index1 < 999)
              {
                int num7 = num1 - 1;
                int num8 = num1 + 1;
                int num9 = num2 - 3;
                int num10 = num2;
                if (num7 < 0)
                  flag = false;
                if (num8 > (int) Main.maxTilesX)
                  flag = false;
                if (num9 < 0)
                  flag = false;
                if (num10 > (int) Main.maxTilesY)
                  flag = false;
                if (flag)
                {
                  for (int index5 = num7; index5 < num8; ++index5)
                  {
                    for (int index6 = num9; index6 < num10; ++index6)
                    {
                      if ((int) Main.tile[index5, index6].active != 0 && Main.tileSolid[(int) Main.tile[index5, index6].type])
                      {
                        flag = false;
                        break;
                      }
                    }
                  }
                }
              }
            }
            else
              continue;
          }
          if (flag || flag)
            break;
        }
        if (flag && index1 < 999)
        {
          Rectangle rectangle1 = new Rectangle(num1 * 16, num2 * 16, 16, 16);
          for (int index2 = 0; index2 < 8; ++index2)
          {
            if ((int) Main.player[index2].active != 0)
            {
              Rectangle rectangle2 = new Rectangle(Main.player[index2].aabb.X + 10 - 960 - 62, Main.player[index2].aabb.Y + 21 - 540 - 34, 2044, 1148);
              if (rectangle1.Intersects(rectangle2))
                flag = false;
            }
          }
        }
        if (flag)
          break;
      }
      if (!flag)
        return;
      int number = NPC.NewNPC(num1 * 16 + 8, num2 * 16, Type, 1);
      if (number == 196)
        return;
      Main.npc[number].target = p.whoAmI;
      Main.npc[number].timeLeft *= 20;
      string prefix = Main.npc[number].displayName;
      if (prefix.Length == 0)
        prefix = Main.npc[number].name;
      NetMessage.CreateMessage1(23, number);
      NetMessage.SendMessage();
      if (Type == 125)
      {
        NetMessage.SendText(34, 175, 75, (int) byte.MaxValue, -1);
      }
      else
      {
        if (Type == 82 || Type == 126 || Type == 50)
          return;
        NetMessage.SendText(prefix, 16, 175, 75, (int) byte.MaxValue, -1);
      }
    }

    public static int NewNPC(int X, int Y, int Type, int Start = 0)
    {
      int index1 = 196;
      for (int index2 = Start; index2 < 196; ++index2)
      {
        if ((int) Main.npc[index2].active == 0)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 < 196)
      {
        Main.npc[index1].SetDefaults(Type, -1.0);
        Main.npc[index1].position.X = (float) (Main.npc[index1].aabb.X = X - ((int) Main.npc[index1].width >> 1));
        Main.npc[index1].position.Y = (float) (Main.npc[index1].aabb.Y = Y - (int) Main.npc[index1].height);
        Main.npc[index1].active = (byte) 1;
        Main.npc[index1].timeLeft = 750;
        Main.npc[index1].wet = Collision.WetCollision(ref Main.npc[index1].position, (int) Main.npc[index1].width, (int) Main.npc[index1].height);
        if (Type == 50)
          NetMessage.SendText(Main.npc[index1].name, 16, 175, 75, (int) byte.MaxValue, -1);
      }
      return index1;
    }

    public void Transform(int newType)
    {
      Vector2 vector2 = this.velocity;
      this.position.Y += (float) this.height;
      sbyte num = this.spriteDirection;
      this.SetDefaults(newType, -1.0);
      this.spriteDirection = num;
      this.TargetClosest(true);
      this.velocity = vector2;
      this.position.Y -= (float) this.height;
      if (newType == 107 || newType == 108)
      {
        this.homeTileX = (short) ((int) this.position.X + ((int) this.width >> 1) >> 4);
        this.homeTileY = (short) ((int) this.position.Y + (int) this.height >> 4);
        this.homeless = true;
      }
      this.netUpdate = true;
      NetMessage.CreateMessage1(23, (int) this.whoAmI);
      NetMessage.SendMessage();
    }

    public double StrikeNPC(int Damage, float knockBack, int hitDirection, bool crit = false, bool noEffect = false)
    {
      if ((int) this.active == 0 || this.life <= 0)
        return 0.0;
      double dmg = Main.CalculateDamage(Damage, this.defense);
      if (crit)
        dmg *= 2.0;
      if (Damage != 9999 && this.lifeMax > 1)
      {
        if (this.friendly)
          CombatText.NewText(this.position, (int) this.width, (int) this.height, (int) dmg, crit);
        else
          CombatText.NewText(this.position, (int) this.width, (int) this.height, (int) dmg, crit);
        if ((int) this.drawMyName < 96)
          this.drawMyName = (short) 96;
      }
      if (dmg < 1.0)
        return 0.0;
      this.justHit = true;
      if (this.townNPC)
      {
        this.ai0 = 1f;
        this.ai1 = (float) (300 + Main.rand.Next(300));
        this.ai2 = 0.0f;
        this.direction = (sbyte) hitDirection;
        this.netUpdate = true;
      }
      if ((int) this.aiStyle == 8 && Main.netMode != 1)
      {
        this.ai0 = 400f;
        this.TargetClosest(true);
      }
      if (this.realLife >= 0)
      {
        Main.npc[this.realLife].life -= (int) dmg;
        this.life = Main.npc[this.realLife].life;
        this.lifeMax = Main.npc[this.realLife].lifeMax;
      }
      else
        this.life -= (int) dmg;
      if ((double) knockBack > 0.0 && (double) this.knockBackResist > 0.0)
      {
        float num1 = knockBack * this.knockBackResist;
        if ((double) num1 > 8.0)
          num1 = 8f;
        if (crit)
          num1 *= 1.4f;
        if (dmg * 10.0 < (double) this.lifeMax)
        {
          if (hitDirection < 0 && (double) this.velocity.X > -(double) num1)
          {
            if ((double) this.velocity.X > 0.0)
              this.velocity.X -= num1;
            this.velocity.X -= num1;
            if ((double) this.velocity.X < -(double) num1)
              this.velocity.X = -num1;
          }
          else if (hitDirection > 0 && (double) this.velocity.X < (double) num1)
          {
            if ((double) this.velocity.X < 0.0)
              this.velocity.X += num1;
            this.velocity.X += num1;
            if ((double) this.velocity.X > (double) num1)
              this.velocity.X = num1;
          }
          float num2 = this.noGravity ? num1 * -0.5f : num1 * -0.75f;
          if ((double) this.velocity.Y > (double) num2)
          {
            this.velocity.Y += num2;
            if ((double) this.velocity.Y < (double) num2)
              this.velocity.Y = num2;
          }
        }
        else
        {
          this.velocity.Y = this.noGravity ? (float) (-(double) num1 * 0.5) * this.knockBackResist : (float) (-(double) num1 * 0.75) * this.knockBackResist;
          this.velocity.X = num1 * (float) hitDirection * this.knockBackResist;
        }
      }
      if (((int) this.type == 113 || (int) this.type == 114) && this.life <= 0)
      {
        for (int index = 0; index < 196; ++index)
        {
          if ((int) Main.npc[index].active != 0 && ((int) Main.npc[index].type == 113 || (int) Main.npc[index].type == 114))
            Main.npc[index].HitEffect(hitDirection, dmg);
        }
      }
      else if ((int) this.active != 0)
        this.HitEffect(hitDirection, dmg);
      if ((int) this.soundHit > 0)
        Main.PlaySound(3, (int) this.position.X, (int) this.position.Y, (int) this.soundHit);
      if (this.realLife >= 0)
        Main.npc[this.realLife].checkDead();
      else
        this.checkDead();
      return dmg;
    }

    public void checkDead()
    {
      if ((int) this.active == 0 || this.realLife >= 0 && this.realLife != (int) this.whoAmI || this.life > 0)
        return;
      NPC.noSpawnCycle = true;
      if (this.townNPC && (int) this.type != 37 && Main.netMode != 1)
      {
        string prefix = this.displayName;
        if (this.displayName.Length == 0)
          prefix = this.name;
        NetMessage.SendText(prefix, 19, (int) byte.MaxValue, 25, 25, -1);
        NPC.chrName[(int) this.type] = (string) null;
        NPC.setNames();
        NetMessage.CreateMessage1(56, (int) this.type);
        NetMessage.SendMessage();
      }
      if (this.townNPC && Main.netMode != 1 && (this.homeless && WorldGen.spawnNPC == (int) this.type))
        WorldGen.spawnNPC = 0;
      if ((int) this.soundKilled > 0)
        Main.PlaySound(4, (int) this.position.X, (int) this.position.Y, (int) this.soundKilled);
      this.NPCLoot();
      if ((int) this.type >= 26 && (int) this.type <= 29 || (int) this.type == 111 || (int) this.type >= 143 && (int) this.type <= 145)
        --Main.invasionSize;
      this.active = (byte) 0;
    }

    public unsafe void NPCLoot()
    {
      if (Main.hardMode && this.lifeMax > 1 && (this.damage > 0 && !this.friendly) && (this.aabb.Y > Main.rockLayerPixels && (int) this.type != 121 && ((double) this.value > 0.0 && Main.rand.Next(7) == 0)))
      {
        Player closest = Player.FindClosest(ref this.aabb);
        if (closest.zoneEvil)
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 521, 1, false, 0);
        if (closest.zoneHoly)
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 520, 1, false, 0);
      }
      if (Time.xMas && this.lifeMax > 1 && (this.damage > 0 && !this.friendly) && ((int) this.type != 121 && (double) this.value > 0.0 && Main.rand.Next(13) == 0))
        Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, Main.rand.Next(599, 602), 1, false, 0);
      switch (this.type)
      {
        case (byte) 1:
        case (byte) 16:
        case (byte) 138:
        case (byte) 141:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 23, Main.rand.Next(1, 3), false, 0);
          break;
        case (byte) 2:
          int num1 = Main.rand.Next(150);
          if (num1 < 50)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, num1 == 38 ? 236 : 38, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 3:
        case (byte) 132:
          if (Main.rand.Next(50) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 216, 1, false, -1);
            break;
          }
          else
            break;
        case (byte) 4:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 47, Main.rand.Next(20, 50), false, 0);
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 56, Main.rand.Next(10, 30), false, 0);
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 56, Main.rand.Next(10, 30), false, 0);
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 56, Main.rand.Next(10, 30), false, 0);
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 59, Main.rand.Next(1, 4), false, 0);
          break;
        case (byte) 6:
        case (byte) 94:
          if (Main.rand.Next(3) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 68, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 7:
        case (byte) 8:
        case (byte) 9:
          if (Main.rand.Next(3) == 0)
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 68, Main.rand.Next(1, 3), false, 0);
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 69, Main.rand.Next(3, 9), false, 0);
          break;
        case (byte) 10:
        case (byte) 11:
        case (byte) 12:
        case (byte) 95:
        case (byte) 96:
        case (byte) 97:
          if (Main.rand.Next(500) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 215, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 13:
        case (byte) 14:
        case (byte) 15:
          if (Main.rand.Next(2) == 0)
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 86, Main.rand.Next(1, 3), false, 0);
          if (Main.rand.Next(2) == 0)
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 56, Main.rand.Next(2, 6), false, 0);
          if (this.boss)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 56, Main.rand.Next(10, 30), false, 0);
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 56, Main.rand.Next(10, 31), false, 0);
          }
          if (Main.rand.Next(3) == 0 && Player.FindClosest(ref this.aabb).canHeal())
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 58, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 21:
        case (byte) 44:
        case (byte) 149:
          if (Main.rand.Next(25) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 118, 1, false, 0);
            break;
          }
          else if ((int) this.type != 21)
          {
            if (Main.rand.Next(20) == 0)
            {
              Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, Main.rand.Next(410, 412), 1, false, 0);
              break;
            }
            else
            {
              Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 166, Main.rand.Next(1, 4), false, 0);
              break;
            }
          }
          else
            break;
        case (byte) 23:
          if (Main.rand.Next(50) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 116, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 24:
          if (Main.rand.Next(300) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 244, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 26:
        case (byte) 27:
        case (byte) 28:
        case (byte) 29:
        case (byte) 111:
          int num2 = Main.rand.Next(200);
          if (num2 < 100)
          {
            if (num2 == 0)
            {
              Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 160, 1, false, 0);
              break;
            }
            else
            {
              Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 161, Main.rand.Next(1, 6), false, 0);
              break;
            }
          }
          else
            break;
        case (byte) 31:
        case (byte) 32:
        case (byte) 34:
          if (Main.rand.Next(65) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 327, 1, false, 0);
            break;
          }
          else
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 154, Main.rand.Next(1, 4), false, 0);
            break;
          }
        case (byte) 42:
          if (Main.rand.Next(2) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 209, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 43:
          if (Main.rand.Next(4) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 210, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 45:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 238, 1, false, 0);
          break;
        case (byte) 47:
          if (Main.rand.Next(75) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 243, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 48:
          if (Main.rand.Next(2) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 320, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 50:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, Main.rand.Next(256, 259), 1, false, 0);
          break;
        case (byte) 52:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 251, 1, false, 0);
          break;
        case (byte) 53:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 239, 1, false, 0);
          break;
        case (byte) 54:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 260, 1, false, 0);
          break;
        case (byte) 55:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 261, 1, false, 0);
          break;
        case (byte) 58:
          int num3 = Main.rand.Next(500);
          if (num3 < 13)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, num3 == 0 ? 263 : 118, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 62:
          if (Main.rand.Next(50) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 272, 1, false, -1);
            break;
          }
          else
            break;
        case (byte) 63:
        case (byte) 64:
        case (byte) 103:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 282, Main.rand.Next(1, 5), false, 0);
          break;
        case (byte) 65:
          if (Main.rand.Next(50) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 268, 1, false, 0);
            break;
          }
          else
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 319, 1, false, 0);
            break;
          }
        case (byte) 66:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 267, 1, false, 0);
          break;
        case (byte) 69:
        case (byte) 147:
          if (Main.rand.Next(7) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 323, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 71:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 327, 1, false, 0);
          break;
        case (byte) 73:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 362, Main.rand.Next(1, 3), false, 0);
          break;
        case (byte) 75:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 501, Main.rand.Next(1, 4), false, 0);
          break;
        case (byte) 79:
          if (Main.rand.Next(10) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 527, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 80:
          if (Main.rand.Next(10) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 528, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 81:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 23, Main.rand.Next(2, 5), false, 0);
          break;
        case (byte) 85:
          if ((double) this.value > 0.0)
          {
            switch (Main.rand.Next(7))
            {
              case 0:
                Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 437, 1, false, -1);
                break;
              case 1:
                Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 517, 1, false, -1);
                break;
              case 2:
                Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 535, 1, false, -1);
                break;
              case 3:
                Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 536, 1, false, -1);
                break;
              case 4:
                Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 532, 1, false, -1);
                break;
              case 5:
                Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 393, 1, false, -1);
                break;
              default:
                Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 554, 1, false, -1);
                break;
            }
          }
          else
            break;
        case (byte) 86:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 526, 1, false, 0);
          break;
        case (byte) 87:
        case (byte) 159:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 575, Main.rand.Next(5, 11), false, 0);
          break;
        case (byte) 98:
        case (byte) 101:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 522, Main.rand.Next(2, 6), false, 0);
          break;
        case (byte) 102:
          if (Main.rand.Next(500) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 263, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 104:
          if (Main.rand.Next(60) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 485, 1, false, -1);
            break;
          }
          else
            break;
        case (byte) 109:
          if (!NPC.downedClown)
          {
            NPC.downedClown = true;
            if (Main.netMode == 2)
            {
              NetMessage.CreateMessage0(7);
              NetMessage.SendMessage();
              break;
            }
            else
              break;
          }
          else
            break;
        case (byte) 113:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 367, 1, false, -1);
          if (Main.rand.Next(2) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, Main.rand.Next(489, 492), 1, false, -1);
          }
          else
          {
            int Type;
            switch (Main.rand.Next(3))
            {
              case 0:
                Type = 514;
                break;
              case 1:
                Type = 426;
                break;
              default:
                Type = 434;
                break;
            }
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, Type, 1, false, -1);
          }
          if (Main.netMode != 1)
          {
            int num4 = this.aabb.X + ((int) this.width >> 1) >> 4;
            int num5 = this.aabb.Y + ((int) this.height >> 1) >> 4;
            int num6 = ((int) this.width >> 5) + 1;
            for (int index1 = num4 - num6; index1 <= num4 + num6; ++index1)
            {
              for (int index2 = num5 - num6; index2 <= num5 + num6; ++index2)
              {
                bool flag = false;
                fixed (Tile* tilePtr = &Main.tile[index1, index2])
                {
                  if ((index1 == num4 - num6 || index1 == num4 + num6 || (index2 == num5 - num6 || index2 == num5 + num6)) && (int) tilePtr->active == 0)
                  {
                    tilePtr->active = (byte) 1;
                    tilePtr->type = (byte) 140;
                    WorldGen.SquareTileFrame(index1, index2, -1);
                    flag = true;
                  }
                  if ((int) tilePtr->liquid > 0)
                  {
                    tilePtr->lava = (byte) 0;
                    tilePtr->liquid = (byte) 0;
                    flag = true;
                  }
                }
                if (flag)
                  NetMessage.SendTile(index1, index2);
              }
            }
            break;
          }
          else
            break;
        case (byte) 116:
        case (byte) 117:
        case (byte) 118:
        case (byte) 119:
        case (byte) 139:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 58, 1, false, 0);
          break;
        case (byte) 122:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 23, Main.rand.Next(5, 11), false, 0);
          break;
        case (byte) 125:
        case (byte) 126:
          if (!NPC.AnyNPCs((int) this.type == 125 ? 126 : 125))
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 549, Main.rand.Next(20, 31), false, 0);
            break;
          }
          else
          {
            this.value = 0.0f;
            this.boss = false;
            break;
          }
        case (byte) 127:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 547, Main.rand.Next(20, 31), false, 0);
          break;
        case (byte) 134:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 548, Main.rand.Next(20, 31), false, 0);
          break;
        case (byte) 143:
        case (byte) 144:
        case (byte) 145:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 593, Main.rand.Next(5, 11), false, 0);
          break;
        case (byte) 148:
          if (Main.rand.Next(25) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 268, 1, false, 0);
            break;
          }
          else
            break;
        case (byte) 166:
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 366, Main.rand.Next(10, 30), false, 0);
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 620, Main.rand.Next(5, 10), false, 0);
          if (Main.rand.Next(3) == 0)
          {
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 604 + Main.rand.Next(9), 1, false, 0);
            break;
          }
          else
            break;
      }
      if (this.boss)
      {
        string prefix = this.displayName;
        switch ((NPC.ID) this.type)
        {
          case NPC.ID.SKELETRON_HEAD:
            NPC.downedBoss3 = true;
            break;
          case NPC.ID.RETINAZER:
          case NPC.ID.SPAZMATISM:
            prefix = Lang.misc[20];
            UI.SetTriggerStateForAll(Trigger.KilledTheTwins);
            break;
          case NPC.ID.SKELETRON_PRIME:
            UI.SetTriggerStateForAll(Trigger.KilledSkeletronPrime);
            break;
          case NPC.ID.THE_DESTROYER_HEAD:
            UI.SetTriggerStateForAll(Trigger.KilledDestroyer);
            break;
          case NPC.ID.EYE_OF_CTHULHU:
            NPC.downedBoss1 = true;
            break;
          case NPC.ID.EATER_OF_WORLDS_HEAD:
          case NPC.ID.EATER_OF_WORLDS_BODY:
          case NPC.ID.EATER_OF_WORLDS_TAIL:
            NPC.downedBoss2 = true;
            break;
        }
        short netID = this.netID;
        if (this.realLife > 0)
          netID = Main.npc[this.realLife].netID;
        UI.IncreaseStatisticForAll(Statistics.GetBossStatisticEntryFromNetID(netID));
        int Type = 28;
        if ((int) this.type == 113)
          Type = 188;
        else if ((int) this.type > 113)
          Type = 499;
        Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, Type, Main.rand.Next(5, 16), false, 0);
        for (int index = Main.rand.Next(5, 10); index > 0; --index)
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 58, 1, false, 0);
        if (Main.netMode != 1)
        {
          if ((int) this.type == 113)
            WorldGen.StartHardmode();
          NetMessage.SendText(prefix, 17, 175, 75, (int) byte.MaxValue, -1);
          NetMessage.CreateMessage0(7);
          NetMessage.SendMessage();
        }
      }
      if (this.lifeMax > 1 && this.damage > 0)
      {
        Player closest = Player.FindClosest(ref this.aabb);
        if (Main.rand.Next(6) == 0)
        {
          if (Main.rand.Next(2) == 0 && closest.canUseMana())
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 184, 1, false, 0);
          else if (Main.rand.Next(2) == 0 && closest.canHeal())
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 58, 1, false, 0);
        }
        if (Main.rand.Next(2) == 0 && closest.canUseMana())
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 184, 1, false, 0);
      }
      float num7 = this.value * (float) (1.0 + (double) Main.rand.Next(-20, 21) * 0.00999999977648258);
      if (Main.rand.Next(5) == 0)
        num7 *= (float) (1.0 + (double) Main.rand.Next(5, 11) * 0.00999999977648258);
      if (Main.rand.Next(10) == 0)
        num7 *= (float) (1.0 + (double) Main.rand.Next(10, 21) * 0.00999999977648258);
      if (Main.rand.Next(15) == 0)
        num7 *= (float) (1.0 + (double) Main.rand.Next(15, 31) * 0.00999999977648258);
      if (Main.rand.Next(20) == 0)
        num7 *= (float) (1.0 + (double) Main.rand.Next(20, 41) * 0.00999999977648258);
      int num8 = (int) num7;
      while (num8 > 0)
      {
        if (num8 > 1000000)
        {
          int Stack = num8 / 1000000;
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Stack > 0)
          {
            num8 -= 1000000 * Stack;
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 74, Stack, false, 0);
          }
        }
        else if (num8 > 10000)
        {
          int Stack = num8 / 10000;
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Stack > 0)
          {
            num8 -= 10000 * Stack;
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 73, Stack, false, 0);
          }
        }
        else if (num8 > 100)
        {
          int Stack = num8 / 100;
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Stack > 0)
          {
            num8 -= 100 * Stack;
            Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 72, Stack, false, 0);
          }
        }
        else if (num8 > 0)
        {
          int Stack = num8;
          if (Stack > 50 && Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Main.rand.Next(5) == 0)
            Stack /= Main.rand.Next(1, 4);
          if (Stack < 1)
            Stack = 1;
          num8 -= Stack;
          Item.NewItem(this.aabb.X, this.aabb.Y, (int) this.width, (int) this.height, 71, Stack, false, 0);
        }
      }
    }

    public unsafe void HitEffect(int hitDirection = 0, double dmg = 10.0)
    {
      if ((int) this.type == 1 || (int) this.type == 16 || (int) this.type == 71)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 48 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) (2 * hitDirection), -2.0, (int) this.alpha, this.color, 1.0))
            ++num;
          if ((int) this.type != 16 || Main.netMode == 1)
            return;
          for (int index = Main.rand.Next(1, 3); index >= 0; --index)
          {
            int number = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, 1, 0);
            if (number < 196)
            {
              Main.npc[number].SetDefaults("Baby Slime");
              Main.npc[number].velocity.X = this.velocity.X * 2f;
              Main.npc[number].velocity.Y = this.velocity.Y;
              Main.npc[number].velocity.X += (float) ((double) Main.rand.Next(-20, 20) * 0.100000001490116 + (double) (index * (int) this.direction) * 0.300000011920929);
              Main.npc[number].velocity.Y -= (float) Main.rand.Next(10) * 0.1f + (float) index;
              Main.npc[number].ai1 = (float) index;
              NetMessage.CreateMessage1(23, number);
              NetMessage.SendMessage();
            }
          }
        }
      }
      else if ((int) this.type == 143 || (int) this.type == 144 || (int) this.type == 145)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
          {
            Dust* dustPtr = Main.dust.NewDust(76, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 32; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(76, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->noGravity = true;
            dustPtr->scale *= 1.2f;
          }
        }
      }
      else if ((int) this.type == 141)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, new Color(210, 230, 140), 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 40 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) (2 * hitDirection), -2.0, (int) this.alpha, new Color(210, 230, 140), 1.0))
            ++num;
        }
      }
      else if ((int) this.type == 112)
      {
        for (int index = 0; index < 16; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(this.aabb.X, this.aabb.Y + 2, (int) this.width, (int) this.height, 18, 0.0, 0.0, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr == IntPtr.Zero)
            break;
          if (Main.rand.Next(2) == 0)
          {
            dustPtr->scale *= 0.6f;
          }
          else
          {
            dustPtr->velocity.X *= 1.4f;
            dustPtr->velocity.Y *= 1.4f;
            dustPtr->noGravity = true;
          }
        }
      }
      else if ((int) this.type == 81 || (int) this.type == 150 || (int) this.type == 121)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, (int) this.alpha, this.color, 1.0))
            --num;
        }
        else
        {
          for (int index = 0; index < 42; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(14, ref this.aabb, (double) hitDirection, 0.0, (int) this.alpha, this.color, 1.0);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X *= 2f;
              dustPtr->velocity.Y *= 2f;
            }
            else
              break;
          }
          if (Main.netMode == 1)
            return;
          if ((int) this.type == 121)
          {
            int number = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, 81, 0);
            if (number >= 196)
              return;
            Main.npc[number].SetDefaults("Slimer2");
            Main.npc[number].velocity.X = this.velocity.X;
            Main.npc[number].velocity.Y = this.velocity.Y;
            Gore.NewGore(this.position, this.velocity, 94, (double) this.scale);
            NetMessage.CreateMessage1(23, number);
            NetMessage.SendMessage();
          }
          else
          {
            if ((double) this.scale < 1.0)
              return;
            string Name = (int) this.type == 81 ? "Slimeling" : "Slimeling2";
            for (int index = Main.rand.Next(1, 3); index >= 0; --index)
            {
              int number = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, 1, 0);
              if (number >= 196)
                break;
              Main.npc[number].SetDefaults(Name);
              Main.npc[number].velocity.X = this.velocity.X * 3f;
              Main.npc[number].velocity.Y = this.velocity.Y;
              Main.npc[number].velocity.X += (float) ((double) Main.rand.Next(-10, 10) * 0.100000001490116 + (double) (index * (int) this.direction) * 0.300000011920929);
              Main.npc[number].velocity.Y -= (float) Main.rand.Next(10) * 0.1f + (float) index;
              Main.npc[number].ai1 = (float) index;
              NetMessage.CreateMessage1(23, number);
              NetMessage.SendMessage();
            }
          }
        }
      }
      else if ((int) this.type == 120 || (int) this.type == 154 || ((int) this.type == 137 || (int) this.type == 138))
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(71, ref this.aabb, 0.0, 0.0, 200, new Color(), 1.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 1.5f;
            dustPtr->velocity.Y *= 1.5f;
          }
        }
        else
        {
          for (int index = 0; index < 42; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(71, ref this.aabb, (double) hitDirection, 0.0, 200, new Color(), 1.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 1.5f;
            dustPtr->velocity.Y *= 1.5f;
          }
        }
      }
      else if ((int) this.type == 122 || (int) this.type == 153)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(72, ref this.aabb, 0.0, 0.0, 200, new Color(), 1.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 1.5f;
            dustPtr->velocity.Y *= 1.5f;
          }
        }
        else
        {
          for (int index = 0; index < 42; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(72, ref this.aabb, (double) hitDirection, 0.0, 200, new Color(), 1.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 1.5f;
            dustPtr->velocity.Y *= 1.5f;
          }
        }
      }
      else if ((int) this.type == 75)
      {
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 50.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(55, ref this.aabb, 0.0, 0.0, 200, this.color, 1.0))
            ++num;
        }
        else
        {
          for (int index = 0; index < 42; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(55, ref this.aabb, (double) hitDirection, 0.0, 200, this.color, 1.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 2f;
            dustPtr->velocity.Y *= 2f;
          }
        }
      }
      else if ((int) this.type == 63 || (int) this.type == 64 || (int) this.type == 103)
      {
        Color newColor = new Color(50, 120, (int) byte.MaxValue, 100);
        if ((int) this.type == 64)
          newColor = new Color(225, 70, 140, 100);
        else if ((int) this.type == 103)
          newColor = new Color(70, 225, 140, 100);
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 50.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) hitDirection, -1.0, 0, newColor, 1.0))
            ++num;
        }
        else
        {
          int num = 0;
          while (num < 16 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) (2 * hitDirection), -2.0, 0, newColor, 1.0))
            ++num;
        }
      }
      else if ((int) this.type == 59 || (int) this.type == 60)
      {
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 80.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(6, ref this.aabb, (double) (hitDirection * 2), -1.0, (int) this.alpha, new Color(), 1.5))
            ++num;
        }
        else
        {
          int num = 0;
          while (num < 32 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(6, ref this.aabb, (double) (hitDirection * 2), -1.0, (int) this.alpha, new Color(), 1.5))
            ++num;
        }
      }
      else if ((int) this.type == 50)
      {
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 300.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) hitDirection, -1.0, 175, new Color(0, 80, (int) byte.MaxValue, 100), 1.0))
            ++num;
        }
        else
        {
          int num = 0;
          while (num < 128 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(4, ref this.aabb, (double) (hitDirection << 1), -2.0, 175, new Color(0, 80, (int) byte.MaxValue, 100), 1.0))
            ++num;
          if (Main.netMode == 1)
            return;
          for (int index = Main.rand.Next(3, 7); index >= 0; --index)
          {
            int number = NPC.NewNPC(this.aabb.X + Main.rand.Next((int) this.width - 32), this.aabb.Y + Main.rand.Next((int) this.height - 32), 1, 0);
            if (number < 196)
            {
              Main.npc[number].SetDefaults(1, -1.0);
              Main.npc[number].velocity.X = (float) Main.rand.Next(-15, 16) * 0.1f;
              Main.npc[number].velocity.Y = (float) Main.rand.Next(-30, 1) * 0.1f;
              Main.npc[number].ai1 = (float) Main.rand.Next(3);
              NetMessage.CreateMessage1(23, number);
              NetMessage.SendMessage();
            }
          }
        }
      }
      else if ((int) this.type == 49 || (int) this.type == 51 || (int) this.type == 93)
      {
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 30.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            ++num;
        }
        else
        {
          int num = 0;
          while (num < 12 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          if ((int) this.type == 51)
            Gore.NewGore(this.position, this.velocity, 83, 1.0);
          else if ((int) this.type == 93)
            Gore.NewGore(this.position, this.velocity, 107, 1.0);
          else
            Gore.NewGore(this.position, this.velocity, 82, 1.0);
        }
      }
      else if ((int) this.type == 46 || (int) this.type == 55 || ((int) this.type == 67 || (int) this.type == 74) || (int) this.type == 102)
      {
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 20.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            ++num;
        }
        else
        {
          int num = 0;
          while (num < 8 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          if ((int) this.type == 46)
          {
            Gore.NewGore(this.position, this.velocity, 76, 1.0);
            Gore.NewGore(this.position, this.velocity, 77, 1.0);
          }
          else if ((int) this.type == 67)
          {
            Gore.NewGore(this.position, this.velocity, 95, 1.0);
            Gore.NewGore(this.position, this.velocity, 95, 1.0);
            Gore.NewGore(this.position, this.velocity, 96, 1.0);
          }
          else if ((int) this.type == 74)
          {
            Gore.NewGore(this.position, this.velocity, 100, 1.0);
          }
          else
          {
            if ((int) this.type != 102)
              return;
            Gore.NewGore(this.position, this.velocity, 116, 1.0);
          }
        }
      }
      else if ((int) this.type == 47 || (int) this.type == 57 || (int) this.type == 58)
      {
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 20.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            ++num;
        }
        else
        {
          int num = 0;
          while (num < 8 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          if ((int) this.type == 57)
            Gore.NewGore(this.position, this.velocity, 84, 1.0);
          else if ((int) this.type == 58)
          {
            Gore.NewGore(this.position, this.velocity, 85, 1.0);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, 78, 1.0);
            Gore.NewGore(this.position, this.velocity, 79, 1.0);
          }
        }
      }
      else if ((int) this.type == 2)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 42 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          Gore.NewGore(this.position, this.velocity, 1, 1.0);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 2, 1.0);
        }
      }
      else if ((int) this.type == 133)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
          if (this.life >= this.lifeMax >> 1 || this.localAI0 != 0)
            return;
          this.localAI0 = 1;
          Gore.NewGore(this.position, this.velocity, 1, 1.0);
        }
        else
        {
          int num = 0;
          while (num < 48 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          Gore.NewGore(this.position, this.velocity, 155, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 14f), this.velocity, 155, 1.0);
        }
      }
      else if ((int) this.type == 69 || (int) this.type == 147)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
        }
        else
        {
          int num1 = 0;
          while (num1 < 42 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num1;
          int Type = (int) this.type == 69 ? 97 : 160;
          Gore.NewGore(this.position, this.velocity, Type, 1.0);
          int num2;
          Gore.NewGore(this.position, this.velocity, num2 = Type + 1, 1.0);
        }
      }
      else if ((int) this.type == 61)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 42 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          Gore.NewGore(this.position, this.velocity, 86, 1.0);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 87, 1.0);
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), this.velocity, 88, 1.0);
        }
      }
      else if ((int) this.type == 65 || (int) this.type == 148)
      {
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 150.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            ++num;
        }
        else
        {
          int num1 = 0;
          while (num1 < 60 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num1;
          int Type = (int) this.type == 65 ? 89 : 162;
          Vector2 Velocity = this.velocity;
          Velocity.X *= 0.8f;
          Velocity.Y *= 0.8f;
          Gore.NewGore(this.position, Velocity, Type, 1.0);
          int num2;
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), Velocity, num2 = Type + 1, 1.0);
          int num3;
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), Velocity, num3 = num2 + 1, 1.0);
          int num4;
          Gore.NewGore(new Vector2(this.position.X + 14f, this.position.Y), Velocity, num4 = num3 + 1, 1.0);
        }
      }
      else if ((int) this.type == 3 || (int) this.type == 52 || ((int) this.type == 53 || (int) this.type == 104) || ((int) this.type == 109 || (int) this.type == 132))
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 42 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0))
            ++num;
          if ((int) this.type == 104)
          {
            Gore.NewGore(this.position, this.velocity, 117, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 118, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 118, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 119, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 119, 1.0);
          }
          else if ((int) this.type == 109)
          {
            Gore.NewGore(this.position, this.velocity, 121, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 122, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 122, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 123, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 123, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 46f), this.velocity, 120, 1.0);
          }
          else
          {
            if ((int) this.type == 132)
              Gore.NewGore(this.position, this.velocity, 154, 1.0);
            else
              Gore.NewGore(this.position, this.velocity, 3, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 4, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 4, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 5, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 5, 1.0);
          }
        }
      }
      else if ((int) this.type == 83 || (int) this.type == 84 || (int) this.type == 151)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.5);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 16; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X *= 2f;
              dustPtr->velocity.Y *= 2f;
              dustPtr->noGravity = true;
            }
            else
              break;
          }
          int index1 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float) (((int) this.height >> 1) - 10)), new Vector2((float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3)), 61, (double) this.scale);
          Main.gore[index1].velocity *= 0.5f;
          int index2 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float) (((int) this.height >> 1) - 10)), new Vector2((float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3)), 61, (double) this.scale);
          Main.gore[index2].velocity *= 0.5f;
          int index3 = Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float) (((int) this.height >> 1) - 10)), new Vector2((float) Main.rand.Next(-2, 3), (float) Main.rand.Next(-2, 3)), 61, (double) this.scale);
          Main.gore[index3].velocity *= 0.5f;
        }
      }
      else if ((int) this.type == 4 || (int) this.type == 126 || (int) this.type == 125)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 128 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          for (int index = 0; index < 2; ++index)
          {
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 2, 1.0);
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 7, 1.0);
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 9, 1.0);
            if ((int) this.type == 4)
            {
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 10, 1.0);
              Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
            }
            else if ((int) this.type == 125)
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 146, 1.0);
            else if ((int) this.type == 126)
              Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 145, 1.0);
          }
          if ((int) this.type != 125 && (int) this.type != 126)
            return;
          for (int index = 0; index < 8; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X *= 1.4f;
              dustPtr->velocity.Y *= 1.4f;
            }
            else
              break;
          }
          for (int index = 0; index < 4; ++index)
          {
            Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr1 != IntPtr.Zero)
            {
              dustPtr1->noGravity = true;
              dustPtr1->velocity.X *= 5f;
              dustPtr1->velocity.Y *= 5f;
              Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
              if ((IntPtr) dustPtr2 != IntPtr.Zero)
              {
                dustPtr2->velocity.X *= 3f;
                dustPtr2->velocity.Y *= 3f;
              }
              else
                break;
            }
            else
              break;
          }
          int index1 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
          Main.gore[index1].velocity.X *= 0.4f;
          ++Main.gore[index1].velocity.X;
          Main.gore[index1].velocity.Y *= 0.4f;
          ++Main.gore[index1].velocity.Y;
          int index2 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
          Main.gore[index2].velocity.X *= 0.4f;
          --Main.gore[index2].velocity.X;
          Main.gore[index2].velocity.Y *= 0.4f;
          ++Main.gore[index2].velocity.Y;
          int index3 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
          Main.gore[index3].velocity.X *= 0.4f;
          ++Main.gore[index3].velocity.X;
          Main.gore[index3].velocity.Y *= 0.4f;
          --Main.gore[index3].velocity.Y;
          int index4 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
          Main.gore[index4].velocity.X *= 0.4f;
          --Main.gore[index4].velocity.X;
          Main.gore[index4].velocity.Y *= 0.4f;
          --Main.gore[index4].velocity.Y;
        }
      }
      else if ((int) this.type == 166)
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 128 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
            ++num;
          for (int index = 0; index < 2; ++index)
          {
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 172, 1.0);
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 173, 1.0);
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 174, 1.0);
            Gore.NewGore(this.position, new Vector2((float) Main.rand.Next(-30, 31) * 0.2f, (float) Main.rand.Next(-30, 31) * 0.2f), 172, 1.0);
            Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
          }
        }
      }
      else if ((int) this.type == 5)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 16; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 6, 1.0);
          Gore.NewGore(this.position, this.velocity, 7, 1.0);
        }
      }
      else if ((int) this.type == 167)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 16; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0);
        }
      }
      else if ((int) this.type == 113 || (int) this.type == 114)
      {
        if (this.life > 0)
        {
          for (int index = 0; index < 16; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -1.0, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 137, (double) this.scale);
          if ((int) this.type == 114)
          {
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float) ((int) this.height >> 1)), this.velocity, 139, (double) this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y), this.velocity, 139, (double) this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1)), this.velocity, 137, (double) this.scale);
          }
          else
          {
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + (float) ((int) this.height >> 1)), this.velocity, 138, (double) this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y), this.velocity, 138, (double) this.scale);
            Gore.NewGore(new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1)), this.velocity, 137, (double) this.scale);
          }
        }
      }
      else if ((int) this.type == 115 || (int) this.type == 116)
      {
        if (this.life > 0)
        {
          for (int index = 0; index < 4; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else if ((int) this.type == 115 && Main.netMode != 1)
        {
          NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, 116, 0);
          for (int index = 0; index < 8; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 16; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 132, (double) this.scale);
          Gore.NewGore(this.position, this.velocity, 133, (double) this.scale);
        }
      }
      else if ((int) this.type >= 117 && (int) this.type <= 119)
      {
        if (this.life > 0)
        {
          for (int index = 0; index < 4; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 8; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 134 + (int) this.type - 117, (double) this.scale);
        }
      }
      else if ((int) this.type == 6 || (int) this.type == 94)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, (double) this.scale);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -2.0, (int) this.alpha, this.color, (double) this.scale);
          if ((int) this.type == 94)
          {
            int num = Gore.NewGore(this.position, this.velocity, 108, (double) this.scale);
            num = Gore.NewGore(this.position, this.velocity, 108, (double) this.scale);
            num = Gore.NewGore(this.position, this.velocity, 109, (double) this.scale);
            num = Gore.NewGore(this.position, this.velocity, 110, (double) this.scale);
          }
          else
          {
            int index1 = Gore.NewGore(this.position, this.velocity, 14, (double) this.scale);
            Main.gore[index1].alpha = (short) this.alpha;
            int index2 = Gore.NewGore(this.position, this.velocity, 15, (double) this.scale);
            Main.gore[index2].alpha = (short) this.alpha;
          }
        }
      }
      else if ((int) this.type == 101)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, (double) this.scale);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -2.0, (int) this.alpha, this.color, (double) this.scale);
          Gore.NewGore(this.position, this.velocity, 110, (double) this.scale);
          Gore.NewGore(this.position, this.velocity, 114, (double) this.scale);
          Gore.NewGore(this.position, this.velocity, 114, (double) this.scale);
          Gore.NewGore(this.position, this.velocity, 115, (double) this.scale);
        }
      }
      else if ((int) this.type == 7 || (int) this.type == 8 || (int) this.type == 9)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, (double) this.scale);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -2.0, (int) this.alpha, this.color, (double) this.scale);
          int index1 = Gore.NewGore(this.position, this.velocity, (int) this.type - 7 + 18, 1.0);
          Main.gore[index1].alpha = (short) this.alpha;
        }
      }
      else if ((int) this.type == 98 || (int) this.type == 99 || (int) this.type == 100)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, (double) this.scale);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -2.0, (int) this.alpha, this.color, (double) this.scale);
          int index1 = Gore.NewGore(this.position, this.velocity, 110, 1.0);
          Main.gore[index1].alpha = (short) this.alpha;
        }
      }
      else if ((int) this.type == 10 || (int) this.type == 11 || (int) this.type == 12)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 8; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, (int) this.type - 7 + 18, 1.0);
        }
      }
      else if ((int) this.type == 95 || (int) this.type == 96 || (int) this.type == 97)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 8; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, (int) this.type - 95 + 111, 1.0);
        }
      }
      else if ((int) this.type >= 13 && (int) this.type <= 15)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, (double) this.scale);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -2.0, (int) this.alpha, this.color, (double) this.scale);
          if ((int) this.type == 13)
          {
            Gore.NewGore(this.position, this.velocity, 24, 1.0);
            Gore.NewGore(this.position, this.velocity, 25, 1.0);
          }
          else if ((int) this.type == 14)
          {
            Gore.NewGore(this.position, this.velocity, 26, 1.0);
            Gore.NewGore(this.position, this.velocity, 27, 1.0);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, 28, 1.0);
            Gore.NewGore(this.position, this.velocity, 29, 1.0);
          }
        }
      }
      else if ((int) this.type == 17)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 30, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 31, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 31, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 32, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 32, 1.0);
        }
      }
      else if ((int) this.type == 86)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 101, 1.0);
          Gore.NewGore(this.position, this.velocity, 102, 1.0);
          Gore.NewGore(this.position, this.velocity, 103, 1.0);
          Gore.NewGore(this.position, this.velocity, 103, 1.0);
          Gore.NewGore(this.position, this.velocity, 104, 1.0);
          Gore.NewGore(this.position, this.velocity, 104, 1.0);
          Gore.NewGore(this.position, this.velocity, 105, 1.0);
        }
      }
      else if ((int) this.type >= 105 && (int) this.type <= 108)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          if ((int) this.type == 105 || (int) this.type == 107)
          {
            Gore.NewGore(this.position, this.velocity, 124, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 125, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 125, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 126, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 126, 1.0);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, (int) sbyte.MaxValue, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 128, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 128, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 129, 1.0);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 129, 1.0);
          }
        }
      }
      else if ((int) this.type == 123 || (int) this.type == 124)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 151, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 152, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 152, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 153, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 153, 1.0);
        }
      }
      else if ((int) this.type == 22)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 73, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 74, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 74, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 75, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 75, 1.0);
        }
      }
      else if ((int) this.type == 142)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 157, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 158, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 158, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 159, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 159, 1.0);
        }
      }
      else if ((int) this.type == 37 || (int) this.type == 54)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 58, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 59, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 59, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 60, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 60, 1.0);
        }
      }
      else if ((int) this.type == 18)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 33, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 34, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 34, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 35, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 35, 1.0);
        }
      }
      else if ((int) this.type == 19)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 36, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 37, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 37, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 38, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 38, 1.0);
        }
      }
      else if ((int) this.type == 38)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 64, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 65, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 65, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 66, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 66, 1.0);
        }
      }
      else if ((int) this.type == 20)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 39, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 40, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 40, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 41, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 41, 1.0);
        }
      }
      else if ((int) this.type == 21 || (int) this.type == 31 || ((int) this.type == 32 || (int) this.type == 44) || ((int) this.type == 45 || (int) this.type == 77 || ((int) this.type == 110 || (int) this.type == 149)))
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Main.dust.NewDust(26, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 16; ++index)
            Main.dust.NewDust(26, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          int Type1 = (int) this.type == 149 ? 166 : 42;
          Gore.NewGore(this.position, this.velocity, Type1, (double) this.scale);
          int Type2;
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, Type2 = Type1 + 1, (double) this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, Type2, (double) this.scale);
          int Type3;
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, Type3 = Type2 + 1, (double) this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, Type3, (double) this.scale);
          if ((int) this.type == 77)
          {
            Gore.NewGore(this.position, this.velocity, 106, (double) this.scale);
          }
          else
          {
            if ((int) this.type != 110)
              return;
            Gore.NewGore(this.position, this.velocity, 130, (double) this.scale);
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 131, (double) this.scale);
          }
        }
      }
      else if ((int) this.type == 85)
      {
        int Type = 7;
        if ((double) this.ai3 == 2.0)
          Type = 10;
        else if ((double) this.ai3 == 3.0)
          Type = 37;
        if (this.life > 0)
        {
          int num = 0;
          while ((double) num < dmg / (double) this.lifeMax * 50.0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(Type, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0))
            ++num;
        }
        else
        {
          int num = 0;
          while (num < 16 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(Type, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0))
            ++num;
          int index1 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 61, (double) this.scale);
          Main.gore[index1].velocity *= 0.3f;
          int index2 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) ((int) this.height >> 1) - 10.0)), new Vector2((float) hitDirection, 0.0f), 62, (double) this.scale);
          Main.gore[index2].velocity *= 0.3f;
          int index3 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 10.0)), new Vector2((float) hitDirection, 0.0f), 63, (double) this.scale);
          Main.gore[index3].velocity *= 0.3f;
        }
      }
      else if ((int) this.type >= 87 && (int) this.type <= 92 || (int) this.type >= 159 && (int) this.type <= 164)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(16, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.5);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 1.5f;
            dustPtr->velocity.Y *= 1.5f;
            dustPtr->noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 8; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(16, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X *= 2f;
              dustPtr->velocity.Y *= 2f;
              dustPtr->noGravity = true;
            }
            else
              break;
          }
          for (int index1 = Main.rand.Next(1, 4); index1 > 0; --index1)
          {
            int index2 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) ((int) this.height >> 1) - 10.0)), new Vector2((float) hitDirection, 0.0f), Main.rand.Next(11, 14), (double) this.scale);
            Main.gore[index2].velocity *= 0.8f;
          }
        }
      }
      else if ((int) this.type == 78 || (int) this.type == 79 || ((int) this.type == 80 || (int) this.type == 152) || (int) this.type == 155)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.5);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 2f;
            dustPtr->velocity.Y *= 2f;
            dustPtr->noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 16; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X *= 2f;
              dustPtr->velocity.Y *= 2f;
              dustPtr->noGravity = true;
            }
            else
              break;
          }
          int index1 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 61, (double) this.scale);
          Main.gore[index1].velocity *= 0.3f;
          int index2 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) ((int) this.height >> 1) - 10.0)), new Vector2((float) hitDirection, 0.0f), 62, (double) this.scale);
          Main.gore[index2].velocity *= 0.3f;
          int index3 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 10.0)), new Vector2((float) hitDirection, 0.0f), 63, (double) this.scale);
          Main.gore[index3].velocity *= 0.3f;
        }
      }
      else if ((int) this.type == 82)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(54, ref this.aabb, 0.0, 0.0, 50, new Color(), 1.5);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 2f;
            dustPtr->velocity.Y *= 2f;
            dustPtr->noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 16; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(54, ref this.aabb, 0.0, 0.0, 50, new Color(), 1.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X *= 2f;
              dustPtr->velocity.Y *= 2f;
              dustPtr->noGravity = true;
            }
            else
              break;
          }
          int index1 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 99, (double) this.scale);
          Main.gore[index1].velocity *= 0.3f;
          int index2 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) ((int) this.height >> 1) - 15.0)), new Vector2((float) hitDirection, 0.0f), 99, (double) this.scale);
          Main.gore[index2].velocity *= 0.3f;
          int index3 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 20.0)), new Vector2((float) hitDirection, 0.0f), 99, (double) this.scale);
          Main.gore[index3].velocity *= 0.3f;
        }
      }
      else if ((int) this.type == 140)
      {
        if (this.life > 0)
          return;
        for (int index = 0; index < 16; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(54, ref this.aabb, 0.0, 0.0, 50, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 2f;
            dustPtr->velocity.Y *= 2f;
            dustPtr->noGravity = true;
          }
          else
            break;
        }
        int index1 = Gore.NewGore(new Vector2(this.position.X, this.position.Y - 10f), new Vector2((float) hitDirection, 0.0f), 99, (double) this.scale);
        Main.gore[index1].velocity *= 0.3f;
        int index2 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) ((int) this.height >> 1) - 15.0)), new Vector2((float) hitDirection, 0.0f), 99, (double) this.scale);
        Main.gore[index2].velocity *= 0.3f;
        int index3 = Gore.NewGore(new Vector2(this.position.X, (float) ((double) this.position.Y + (double) this.height - 20.0)), new Vector2((float) hitDirection, 0.0f), 99, (double) this.scale);
        Main.gore[index3].velocity *= 0.3f;
      }
      else if ((int) this.type == 39 || (int) this.type == 40 || (int) this.type == 41)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 50.0; ++index)
            Main.dust.NewDust(26, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 16; ++index)
            Main.dust.NewDust(26, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, (int) this.type - 39 + 67, 1.0);
        }
      }
      else if ((int) this.type == 34 || (int) this.type == 158)
      {
        if (this.life > 0)
        {
          for (int index = 0; (double) index < dmg / (double) this.lifeMax * 30.0; ++index)
          {
            Dust* dustPtr1 = Main.dust.NewDust(15, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 100, new Color(), 1.8);
            if ((IntPtr) dustPtr1 == IntPtr.Zero)
              break;
            dustPtr1->noLight = true;
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 1.3f;
            dustPtr1->velocity.Y *= 1.3f;
            Dust* dustPtr2 = Main.dust.NewDust(26, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 0, new Color(), 0.9);
            if ((IntPtr) dustPtr2 == IntPtr.Zero)
              break;
            dustPtr2->noLight = true;
            dustPtr2->velocity.X *= 1.3f;
            dustPtr2->velocity.Y *= 1.3f;
          }
        }
        else
        {
          for (int index = 0; index < 12; ++index)
          {
            Dust* dustPtr1 = Main.dust.NewDust(15, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 100, new Color(), 1.8);
            if ((IntPtr) dustPtr1 == IntPtr.Zero)
              break;
            dustPtr1->noLight = true;
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 1.3f;
            dustPtr1->velocity.Y *= 1.3f;
            Dust* dustPtr2 = Main.dust.NewDust(26, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 0, new Color(), 0.9);
            if ((IntPtr) dustPtr2 == IntPtr.Zero)
              break;
            dustPtr2->noLight = true;
            dustPtr2->velocity.X *= 1.3f;
            dustPtr2->velocity.Y *= 1.3f;
          }
        }
      }
      else if ((int) this.type == 35 || (int) this.type == 36)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(26, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 128; ++index)
            Main.dust.NewDust(26, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0);
          if ((int) this.type == 35)
          {
            Gore.NewGore(this.position, this.velocity, 54, 1.0);
            Gore.NewGore(this.position, this.velocity, 55, 1.0);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, 56, 1.0);
            Gore.NewGore(this.position, this.velocity, 57, 1.0);
            Gore.NewGore(this.position, this.velocity, 57, 1.0);
            Gore.NewGore(this.position, this.velocity, 57, 1.0);
          }
        }
      }
      else if ((int) this.type == 139)
      {
        if (this.life > 0)
          return;
        for (int index = 0; index < 8; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 1.4f;
            dustPtr->velocity.Y *= 1.4f;
          }
          else
            break;
        }
        for (int index = 0; index < 4; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 5f;
            dustPtr1->velocity.Y *= 5f;
            Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 3f;
              dustPtr2->velocity.Y *= 3f;
            }
            else
              break;
          }
          else
            break;
        }
        int index1 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index1].velocity *= 0.4f;
        ++Main.gore[index1].velocity.X;
        ++Main.gore[index1].velocity.Y;
        int index2 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index2].velocity *= 0.4f;
        --Main.gore[index2].velocity.X;
        ++Main.gore[index2].velocity.Y;
        int index3 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index3].velocity *= 0.4f;
        ++Main.gore[index3].velocity.X;
        --Main.gore[index3].velocity.Y;
        int index4 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index4].velocity *= 0.4f;
        --Main.gore[index4].velocity.X;
        --Main.gore[index4].velocity.Y;
      }
      else if ((int) this.type >= 134 && (int) this.type <= 136)
      {
        if ((int) this.type == 135 && this.life > 0 && (Main.netMode != 1 && (double) this.ai2 == 0.0) && Main.rand.Next(25) == 0)
        {
          this.ai2 = 1f;
          int number = NPC.NewNPC(this.aabb.X + ((int) this.width >> 1), this.aabb.Y + (int) this.height, 139, 0);
          if (Main.netMode == 2 && number < 196)
          {
            NetMessage.CreateMessage1(23, number);
            NetMessage.SendMessage();
          }
          this.netUpdate = true;
        }
        if (this.life > 0)
          return;
        Gore.NewGore(this.position, this.velocity, 156, 1.0);
        if (Main.rand.Next(2) != 0)
          return;
        for (int index = 0; index < 8; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 1.4f;
            dustPtr->velocity.Y *= 1.4f;
          }
          else
            break;
        }
        for (int index = 0; index < 4; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 5f;
            dustPtr1->velocity.Y *= 5f;
            Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 3f;
              dustPtr2->velocity.Y *= 3f;
            }
            else
              break;
          }
          else
            break;
        }
        int index1 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index1].velocity.X *= 0.4f;
        ++Main.gore[index1].velocity.X;
        Main.gore[index1].velocity.Y *= 0.4f;
        ++Main.gore[index1].velocity.Y;
        int index2 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index2].velocity.X *= 0.4f;
        --Main.gore[index2].velocity.X;
        Main.gore[index2].velocity.Y *= 0.4f;
        ++Main.gore[index2].velocity.Y;
        int index3 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index3].velocity.X *= 0.4f;
        ++Main.gore[index3].velocity.X;
        Main.gore[index3].velocity.Y *= 0.4f;
        --Main.gore[index3].velocity.Y;
        int index4 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index4].velocity.X *= 0.4f;
        --Main.gore[index4].velocity.X;
        Main.gore[index4].velocity.Y *= 0.4f;
        --Main.gore[index4].velocity.Y;
      }
      else if ((int) this.type == (int) sbyte.MaxValue)
      {
        if (this.life > 0)
          return;
        Gore.NewGore(this.position, this.velocity, 149, 1.0);
        Gore.NewGore(this.position, this.velocity, 150, 1.0);
        for (int index = 0; index < 8; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 1.4f;
            dustPtr->velocity.Y *= 1.4f;
          }
          else
            break;
        }
        for (int index = 0; index < 4; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 5f;
            dustPtr1->velocity.Y *= 5f;
            Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 3f;
              dustPtr2->velocity.Y *= 3f;
            }
            else
              break;
          }
          else
            break;
        }
        int index1 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index1].velocity.X *= 0.4f;
        ++Main.gore[index1].velocity.X;
        Main.gore[index1].velocity.Y *= 0.4f;
        ++Main.gore[index1].velocity.Y;
        int index2 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index2].velocity.X *= 0.4f;
        --Main.gore[index2].velocity.X;
        Main.gore[index2].velocity.Y *= 0.4f;
        ++Main.gore[index2].velocity.Y;
        int index3 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index3].velocity.X *= 0.4f;
        ++Main.gore[index3].velocity.X;
        Main.gore[index3].velocity.Y *= 0.4f;
        --Main.gore[index3].velocity.Y;
        int index4 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index4].velocity.X *= 0.4f;
        --Main.gore[index4].velocity.X;
        Main.gore[index4].velocity.Y *= 0.4f;
        --Main.gore[index4].velocity.Y;
      }
      else if ((int) this.type >= 128 && (int) this.type <= 131)
      {
        if (this.life > 0)
          return;
        Gore.NewGore(this.position, this.velocity, 147, 1.0);
        Gore.NewGore(this.position, this.velocity, 148, 1.0);
        for (int index = 0; index < 8; ++index)
        {
          Dust* dustPtr = Main.dust.NewDust(31, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 1.4f;
            dustPtr->velocity.Y *= 1.4f;
          }
          else
            break;
        }
        for (int index = 0; index < 4; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 2.5);
          if ((IntPtr) dustPtr1 != IntPtr.Zero)
          {
            dustPtr1->noGravity = true;
            dustPtr1->velocity.X *= 5f;
            dustPtr1->velocity.Y *= 5f;
            Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, 0.0, 0.0, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr2 != IntPtr.Zero)
            {
              dustPtr2->velocity.X *= 3f;
              dustPtr2->velocity.Y *= 3f;
            }
            else
              break;
          }
          else
            break;
        }
        int index1 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index1].velocity.X *= 0.4f;
        ++Main.gore[index1].velocity.X;
        Main.gore[index1].velocity.Y *= 0.4f;
        ++Main.gore[index1].velocity.Y;
        int index2 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index2].velocity.X *= 0.4f;
        --Main.gore[index2].velocity.X;
        Main.gore[index2].velocity.Y *= 0.4f;
        ++Main.gore[index2].velocity.Y;
        int index3 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index3].velocity.X *= 0.4f;
        ++Main.gore[index3].velocity.X;
        Main.gore[index3].velocity.Y *= 0.4f;
        --Main.gore[index3].velocity.Y;
        int index4 = Gore.NewGore(this.position, new Vector2(), Main.rand.Next(61, 64), 1.0);
        Main.gore[index4].velocity.X *= 0.4f;
        --Main.gore[index4].velocity.X;
        Main.gore[index4].velocity.Y *= 0.4f;
        --Main.gore[index4].velocity.Y;
      }
      else if ((int) this.type == 23)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
          {
            int Type = Main.rand.Next(2) == 0 ? 6 : 25;
            Main.dust.NewDust(Type, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
            Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.2, (double) this.velocity.Y * 0.2, 100, new Color(), 2.0);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 42; ++index)
          {
            int Type = Main.rand.Next(2) == 0 ? 6 : 25;
            if (IntPtr.Zero == (IntPtr) Main.dust.NewDust(Type, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0))
              break;
          }
          for (int index = 0; index < 42; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * 0.2, (double) this.velocity.Y * 0.2, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->velocity.X *= 6f;
            dustPtr->velocity.Y *= 6f;
            dustPtr->noGravity = true;
          }
        }
      }
      else if ((int) this.type == 24)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
          {
            Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr == IntPtr.Zero)
              break;
            dustPtr->noGravity = true;
          }
        }
        else
        {
          for (int index = 0; index < 42; ++index)
          {
            Dust* dustPtr = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X, (double) this.velocity.Y, 100, new Color(), 2.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->noGravity = true;
              dustPtr->velocity.X *= 2f;
              dustPtr->velocity.Y *= 2f;
            }
            else
              break;
          }
          Gore.NewGore(this.position, this.velocity, 45, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 46, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 46, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 47, 1.0);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 47, 1.0);
        }
      }
      else if ((int) this.type == 25)
      {
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 10);
        for (int index = 0; index < 16; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr1 == IntPtr.Zero)
            break;
          dustPtr1->noGravity = true;
          dustPtr1->velocity *= 2f;
          Dust* dustPtr2 = Main.dust.NewDust(6, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 100, new Color(), 1.0);
          if ((IntPtr) dustPtr2 == IntPtr.Zero)
            break;
          dustPtr2->velocity.X *= 2f;
          dustPtr2->velocity.Y *= 2f;
        }
      }
      else if ((int) this.type == 33)
      {
        Main.PlaySound(2, this.aabb.X, this.aabb.Y, 10);
        for (int index = 0; index < 16; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X * -0.200000002980232, (double) this.velocity.Y * -0.2, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr1 == IntPtr.Zero)
            break;
          dustPtr1->noGravity = true;
          dustPtr1->velocity.X *= 2f;
          dustPtr1->velocity.Y *= 2f;
          Dust* dustPtr2 = Main.dust.NewDust(29, ref this.aabb, (double) this.velocity.X * -0.200000002980232, (double) this.velocity.Y * -0.2, 100, new Color(), 1.0);
          if ((IntPtr) dustPtr2 == IntPtr.Zero)
            break;
          dustPtr2->velocity.X *= 2f;
          dustPtr2->velocity.Y *= 2f;
        }
      }
      else if ((int) this.type >= 26 && (int) this.type <= 29 || ((int) this.type == 73 || (int) this.type == 111))
      {
        if (this.life > 0)
        {
          int num = (int) (dmg / (double) this.lifeMax * 80.0);
          while (num > 0 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0))
            --num;
        }
        else
        {
          int num = 0;
          while (num < 42 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(5, ref this.aabb, 2.5 * (double) hitDirection, -2.5, 0, new Color(), 1.0))
            ++num;
          Gore.NewGore(this.position, this.velocity, 48, (double) this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 49, (double) this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 20f), this.velocity, 49, (double) this.scale);
          if ((int) this.type == 111)
            Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 131, (double) this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 50, (double) this.scale);
          Gore.NewGore(new Vector2(this.position.X, this.position.Y + 34f), this.velocity, 50, (double) this.scale);
        }
      }
      else if ((int) this.type == 30)
      {
        Main.PlaySound(2, (int) this.position.X, (int) this.position.Y, 10);
        for (int index = 0; index < 15; ++index)
        {
          Dust* dustPtr1 = Main.dust.NewDust(27, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 100, new Color(), 2.0);
          if ((IntPtr) dustPtr1 == IntPtr.Zero)
            break;
          dustPtr1->noGravity = true;
          dustPtr1->velocity.X *= 2f;
          dustPtr1->velocity.Y *= 2f;
          Dust* dustPtr2 = Main.dust.NewDust(27, ref this.aabb, (double) this.velocity.X * -0.2, (double) this.velocity.Y * -0.2, 100, new Color(), 1.0);
          if ((IntPtr) dustPtr2 == IntPtr.Zero)
            break;
          dustPtr2->velocity.X *= 2f;
          dustPtr2->velocity.Y *= 2f;
        }
      }
      else if ((int) this.type == 42 || (int) this.type == 157)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, (double) this.scale);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(18, ref this.aabb, (double) hitDirection, -2.0, (int) this.alpha, this.color, (double) this.scale);
          int Type = (int) this.type == 42 ? 70 : 169;
          Gore.NewGore(this.position, this.velocity, Type, (double) this.scale);
          int num;
          Gore.NewGore(this.position, this.velocity, num = Type + 1, (double) this.scale);
        }
      }
      else if ((int) this.type == 43 || (int) this.type == 56 || (int) this.type == 156)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(40, ref this.aabb, (double) hitDirection, -1.0, (int) this.alpha, this.color, 1.20000004768372);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(40, ref this.aabb, (double) hitDirection, -2.0, (int) this.alpha, this.color, 1.20000004768372);
          Gore.NewGore(this.position, this.velocity, 72, 1.0);
          Gore.NewGore(this.position, this.velocity, 72, 1.0);
        }
      }
      else if ((int) this.type == 48)
      {
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0);
          Gore.NewGore(this.position, this.velocity, 80, 1.0);
          Gore.NewGore(this.position, this.velocity, 81, 1.0);
        }
      }
      else
      {
        if ((int) this.type != 62 && (int) this.type != 165 && (int) this.type != 66)
          return;
        if (this.life > 0)
        {
          for (int index = (int) (dmg / (double) this.lifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(5, ref this.aabb, (double) hitDirection, -1.0, 0, new Color(), 1.0);
        }
        else
        {
          for (int index = 0; index < 42; ++index)
            Main.dust.NewDust(5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0);
          if ((int) this.type == 165)
          {
            Gore.NewGore(this.position, this.velocity, 171, 1.0);
            Gore.NewGore(this.position, this.velocity, 0, 1.0);
            Gore.NewGore(this.position, this.velocity, 0, 1.0);
          }
          else
          {
            Gore.NewGore(this.position, this.velocity, 93, 1.0);
            Gore.NewGore(this.position, this.velocity, 94, 1.0);
            Gore.NewGore(this.position, this.velocity, 94, 1.0);
          }
        }
      }
    }

    public static bool AnyNPCs(int Type)
    {
      for (int index = 195; index >= 0; --index)
      {
        if ((int) Main.npc[index].type == Type && (int) Main.npc[index].active != 0)
          return true;
      }
      return false;
    }

    public static bool AnyNPCs(int Type1, int Type2)
    {
      for (int index = 195; index >= 0; --index)
      {
        if ((int) Main.npc[index].active != 0 && ((int) Main.npc[index].type == Type1 || (int) Main.npc[index].type == Type2))
          return true;
      }
      return false;
    }

    public static void SpawnSkeletron()
    {
      int number = -1;
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.npc[index].active != 0)
        {
          if ((int) Main.npc[index].type == 35)
            return;
          if ((int) Main.npc[index].type == 37)
          {
            number = index;
            break;
          }
        }
      }
      if (number < 0)
        return;
      Main.npc[number].ai3 = 1f;
      int index1 = NPC.NewNPC(Main.npc[number].aabb.X + ((int) Main.npc[number].width >> 1), Main.npc[number].aabb.Y + ((int) Main.npc[number].height >> 1), 35, 0);
      Main.npc[index1].netUpdate = true;
      NetMessage.CreateMessage1(23, number);
      NetMessage.SendMessage();
      NetMessage.SendText("Skeletron", 16, 175, 75, (int) byte.MaxValue, -1);
    }

    public static bool NearSpikeBall(int x, int y)
    {
      Rectangle rectangle1 = new Rectangle(x * 16 - 300, y * 16 - 300, 600, 600);
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.npc[index].aiStyle == 20 && (int) Main.npc[index].active != 0)
        {
          Rectangle rectangle2 = new Rectangle((int) Main.npc[index].ai1, (int) Main.npc[index].ai2, 20, 20);
          if (rectangle1.Intersects(rectangle2))
            return true;
        }
      }
      return false;
    }

    public void AddBuff(int type, int time, bool quiet = false)
    {
      if (this.buffImmune[type])
        return;
      if (!quiet)
      {
        if (Main.netMode == 1)
          NetMessage.CreateMessage3(53, (int) this.whoAmI, type, time);
        else
          NetMessage.CreateMessage1(54, (int) this.whoAmI);
        NetMessage.SendMessage();
      }
      for (int index = 0; index < 5; ++index)
      {
        if ((int) this.buff[index].Type == type)
        {
          if ((int) this.buff[index].Time >= time)
            return;
          this.buff[index].Time = (ushort) time;
          return;
        }
      }
      int index1 = -1;
      do
      {
        int b = -1;
        for (int index2 = 0; index2 < 5; ++index2)
        {
          if (!this.buff[index2].IsDebuff())
          {
            b = index2;
            break;
          }
        }
        if (b == -1)
          return;
        for (int index2 = b; index2 < 5; ++index2)
        {
          if ((int) this.buff[index2].Type == 0)
          {
            index1 = index2;
            break;
          }
        }
        if (index1 == -1)
          this.DelBuff(b);
      }
      while (index1 == -1);
      this.buff[index1].Type = (ushort) type;
      this.buff[index1].Time = (ushort) time;
    }

    public void DelBuff(int b)
    {
      this.buff[b].Time = (ushort) 0;
      this.buff[b].Type = (ushort) 0;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        if ((int) this.buff[index1].Time == 0 || (int) this.buff[index1].Type == 0)
        {
          for (int index2 = index1 + 1; index2 < 5; ++index2)
          {
            this.buff[index2 - 1] = this.buff[index2];
            this.buff[index2].Time = (ushort) 0;
            this.buff[index2].Type = (ushort) 0;
          }
        }
      }
      if (Main.netMode != 2)
        return;
      NetMessage.CreateMessage1(54, (int) this.whoAmI);
      NetMessage.SendMessage();
    }

    private unsafe void FireEffect(int particleType)
    {
      if (Main.rand.Next(4) < 2)
      {
        Dust* dustPtr = Main.dust.NewDust((int) this.position.X - 2, (int) this.position.Y - 2, (int) this.width + 4, (int) this.height + 4, particleType, (double) this.velocity.X * 0.400000005960464, (double) this.velocity.Y * 0.400000005960464, 100, new Color(), 3.5);
        if ((IntPtr) dustPtr != IntPtr.Zero)
        {
          dustPtr->noGravity = true;
          dustPtr->velocity.X *= 1.8f;
          dustPtr->velocity.Y *= 1.8f;
          dustPtr->velocity.Y -= 0.5f;
          if (Main.rand.Next(4) == 0)
          {
            dustPtr->noGravity = false;
            dustPtr->scale *= 0.5f;
          }
        }
      }
      Lighting.addLight((int) this.position.X >> 4, ((int) this.position.Y >> 4) + 1, new Vector3(1f, 0.3f, 0.1f));
    }

    public unsafe void UpdateNPC(int i)
    {
      this.whoAmI = (short) i;
      if (this.aabb.X <= 0 || this.aabb.X + (int) this.width >= Main.rightWorld || (this.aabb.Y <= 0 || this.aabb.Y + (int) this.height >= Main.bottomWorld))
      {
        this.active = (byte) 0;
      }
      else
      {
        int num1 = 0;
        bool flag1 = false;
        this.poisoned = false;
        this.confused = false;
        for (int index = 0; index < 5; ++index)
        {
          if ((int) this.buff[index].Type > 0 && (int) this.buff[index].Time > 0)
          {
            ushort num2 = this.buff[index].Type;
            if ((uint) num2 <= 24U)
            {
              if ((int) num2 != 20)
              {
                if ((int) num2 == 24)
                {
                  flag1 = true;
                  if (num1 > -8)
                    num1 = -8;
                  this.FireEffect(6);
                }
              }
              else
              {
                this.poisoned = true;
                if (num1 > -4)
                  num1 = -4;
                if (Main.rand.Next(30) == 0)
                {
                  Dust* dustPtr = Main.dust.NewDust(46, ref this.aabb, 0.0, 0.0, 120, new Color(), 0.200000002980232);
                  if ((IntPtr) dustPtr != IntPtr.Zero)
                  {
                    dustPtr->noGravity = true;
                    dustPtr->fadeIn = 1.9f;
                  }
                }
              }
            }
            else
            {
              switch (num2)
              {
                case (ushort) 30:
                  if (num1 > -16)
                    num1 = -16;
                  if (Main.rand.Next(30) == 0)
                  {
                    Dust* dustPtr = Main.dust.NewDust(5, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.Y += 0.5f;
                      dustPtr->velocity *= 0.25f;
                      continue;
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                case (ushort) 31:
                  this.confused = true;
                  continue;
                case (ushort) 39:
                  if (num1 > -12)
                    num1 = -12;
                  this.FireEffect(75);
                  continue;
                default:
                  continue;
              }
            }
          }
        }
        if (Main.netMode != 1)
        {
          for (int b = 0; b < 5; ++b)
          {
            if ((int) this.buff[b].Type > 0 && (int) this.buff[b].Time == 0)
              this.DelBuff(b);
          }
        }
        if (!this.dontTakeDamage)
        {
          this.lifeRegenCount += num1;
          while (this.lifeRegenCount <= -120)
          {
            this.lifeRegenCount += 120;
            int npcId = (int) this.whoAmI;
            if (this.realLife >= 0)
              npcId = this.realLife;
            if (--Main.npc[npcId].life <= 0)
            {
              Main.npc[npcId].life = 1;
              if (Main.netMode != 1)
              {
                Main.npc[npcId].StrikeNPC(9999, 0.0f, 0, false, false);
                NetMessage.SendNpcHurt(npcId, 9999, 0.0, 0, false);
              }
            }
          }
        }
        if (Main.netMode != 1 && Main.gameTime.bloodMoon)
        {
          if ((int) this.type == 46)
            this.Transform(47);
          else if ((int) this.type == 55)
            this.Transform(57);
        }
        float num3 = 10f;
        float num4 = 0.3f;
        float num5 = (float) Main.maxTilesX * 0.0002380952f;
        float num6 = (float) ((double) this.position.Y * (1.0 / 16.0) - (60.0 + 10.0 * (double) (num5 * num5))) / (float) (Main.worldSurface / 6);
        if ((double) num6 < 0.25)
          num6 = 0.25f;
        else if ((double) num6 > 1.0)
          num6 = 1f;
        float num7 = num4 * num6;
        if (this.wet)
        {
          num7 = 0.2f;
          num3 = 7f;
        }
        if ((int) this.soundDelay > 0)
          --this.soundDelay;
        if (this.life <= 0)
        {
          this.active = (byte) 0;
        }
        else
        {
          this.oldTarget = (short) this.target;
          this.oldDirection = this.direction;
          this.oldDirectionY = this.directionY;
          try
          {
            switch (this.aiStyle)
            {
              case (byte) 0:
                this.BoundAI();
                break;
              case (byte) 1:
                this.SlimeAI();
                break;
              case (byte) 2:
                this.FloatingEyeballAI();
                break;
              case (byte) 3:
                this.WalkAI();
                break;
              case (byte) 4:
                this.EyeOfCthulhuAI();
                break;
              case (byte) 5:
                this.AggressiveFlyerAI();
                break;
              case (byte) 6:
                this.WormAI();
                break;
              case (byte) 7:
                this.TownsfolkAI();
                break;
              case (byte) 8:
                this.SorcererAI();
                break;
              case (byte) 9:
                this.SphereAI();
                break;
              case (byte) 10:
                this.SkullHeadAI();
                break;
              case (byte) 11:
                this.SkeletronAI();
                break;
              case (byte) 12:
                this.SkeletronHandAI();
                break;
              case (byte) 13:
                this.PlantAI();
                break;
              case (byte) 14:
                this.FlyerAI();
                break;
              case (byte) 15:
                this.KingSlimeAI();
                break;
              case (byte) 16:
                this.FishAI();
                break;
              case (byte) 17:
                this.VultureAI();
                break;
              case (byte) 18:
                this.JellyfishAI();
                break;
              case (byte) 19:
                this.AntlionAI();
                break;
              case (byte) 20:
                this.SpinningSpikeballAI();
                break;
              case (byte) 21:
                this.GravityDiskAI();
                break;
              case (byte) 22:
                this.MoreFlyerAI();
                break;
              case (byte) 23:
                this.EnchantedWeaponAI();
                break;
              case (byte) 24:
                this.BirdAI();
                break;
              case (byte) 25:
                this.MimicAI();
                break;
              case (byte) 26:
                this.UnicornAI();
                break;
              case (byte) 27:
                this.WallOfFleshMouthAI();
                break;
              case (byte) 28:
                this.WallOfFleshEyesAI();
                break;
              case (byte) 29:
                this.WallOfFleshTentacleAI();
                break;
              case (byte) 30:
                this.RetinazerAI();
                break;
              case (byte) 31:
                this.SpazmatismAI();
                break;
              case (byte) 32:
                this.SkeletronPrimeAI();
                break;
              case (byte) 33:
                this.SkeletronPrimeSawHand();
                break;
              case (byte) 34:
                this.SkeletronPrimeViceHand();
                break;
              case (byte) 35:
                this.SkeletronPrimeCannonHand();
                break;
              case (byte) 36:
                this.SkeletronPrimeLaserHand();
                break;
              case (byte) 37:
                this.DestroyerAI();
                break;
              case (byte) 38:
                this.SnowmanAI();
                break;
              case (byte) 39:
                this.OcramAI();
                break;
            }
          }
          catch (Exception ex)
          {
            this.active = (byte) 0;
            return;
          }
          if ((int) this.type == 44 || (int) this.type == 149)
            Lighting.addLight(this.aabb.X + ((int) this.width >> 1) >> 4, this.aabb.Y + 4 >> 4, new Vector3(0.9f, 0.75f, 0.5f));
          for (int index = 0; index < 9; ++index)
          {
            if ((int) this.immune[index] > 0)
              --this.immune[index];
          }
          if (!this.noGravity)
          {
            this.velocity.Y += num7;
            if ((double) this.velocity.Y > (double) num3)
              this.velocity.Y = num3;
          }
          if ((double) this.velocity.X < 0.00499999988824129 && (double) this.velocity.X > -0.00499999988824129)
            this.velocity.X = 0.0f;
          if (Main.netMode != 1 && (int) this.type != 37 && (this.friendly || (int) this.type == 46 || ((int) this.type == 55 || (int) this.type == 74)))
          {
            if (this.life < this.lifeMax)
            {
              ++this.friendlyRegen;
              if ((int) this.friendlyRegen > 300)
              {
                this.friendlyRegen = (short) 0;
                ++this.life;
                this.netUpdate = true;
              }
            }
            if ((int) this.immune[8] == 0)
            {
              for (int index = 0; index < 196; ++index)
              {
                if ((int) Main.npc[index].active != 0 && !Main.npc[index].friendly && (Main.npc[index].damage > 0 && this.aabb.Intersects(Main.npc[index].aabb)))
                {
                  int num2 = Main.npc[index].damage;
                  int num8 = 6;
                  int num9 = 1;
                  if (Main.npc[index].aabb.X + ((int) Main.npc[index].width >> 1) > this.aabb.X + ((int) this.width >> 1))
                    num9 = -1;
                  Main.npc[i].StrikeNPC(num2, (float) num8, num9, false, false);
                  NetMessage.SendNpcHurt(i, num2, (double) num8, num9, false);
                  this.netUpdate = true;
                  this.immune[8] = (byte) 30;
                }
              }
            }
          }
          if (!this.noTileCollide)
          {
            bool flag2 = Collision.LavaCollision(ref this.position, (int) this.width, (int) this.height);
            if (flag2)
            {
              this.lavaWet = true;
              if (!this.lavaImmune && !this.dontTakeDamage && (Main.netMode != 1 && (int) this.immune[8] == 0))
              {
                this.AddBuff(24, 420, false);
                this.immune[8] = (byte) 30;
                this.StrikeNPC(50, 0.0f, 0, false, false);
                NetMessage.SendNpcHurt((int) this.whoAmI, 50, 0.0, 0, false);
              }
            }
            bool flag3;
            if ((int) this.type == 72)
            {
              flag3 = false;
              this.wetCount = (byte) 0;
              flag2 = false;
            }
            else
              flag3 = Collision.WetCollision(ref this.position, (int) this.width, (int) this.height);
            if (flag3)
            {
              if (flag1 && !this.lavaWet && Main.netMode != 1)
              {
                for (int b = 0; b < 5; ++b)
                {
                  if ((int) this.buff[b].Type == 24)
                  {
                    this.DelBuff(b);
                    break;
                  }
                }
              }
              if (!this.wet && (int) this.wetCount == 0)
              {
                this.wetCount = (byte) 10;
                if (!flag2)
                {
                  for (int index = 0; index < 24; ++index)
                  {
                    Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 33, 0.0, 0.0, 0, new Color(), 1.0);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.Y -= 4f;
                      dustPtr->velocity.X *= 2.5f;
                      dustPtr->scale = 1.3f;
                      dustPtr->alpha = (short) 100;
                      dustPtr->noGravity = true;
                    }
                    else
                      break;
                  }
                  if ((int) this.type != 1 && (int) this.type != 59 && !this.noGravity)
                    Main.PlaySound(19, this.aabb.X, this.aabb.Y, 0);
                }
                else
                {
                  for (int index = 0; index < 7; ++index)
                  {
                    Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 35, 0.0, 0.0, 0, new Color(), 1.0);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.Y -= 1.5f;
                      dustPtr->velocity.X *= 2.5f;
                      dustPtr->scale = 1.3f;
                      dustPtr->alpha = (short) 100;
                      dustPtr->noGravity = true;
                    }
                    else
                      break;
                  }
                  if ((int) this.type != 1 && (int) this.type != 59 && !this.noGravity)
                    Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
                }
              }
              this.wet = true;
            }
            else if (this.wet)
            {
              this.velocity.X *= 0.5f;
              this.wet = false;
              if ((int) this.wetCount == 0)
              {
                this.wetCount = (byte) 10;
                if (!this.lavaWet)
                {
                  for (int index = 0; index < 24; ++index)
                  {
                    Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 33, 0.0, 0.0, 0, new Color(), 1.0);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.Y -= 4f;
                      dustPtr->velocity.X *= 2.5f;
                      dustPtr->scale = 1.3f;
                      dustPtr->alpha = (short) 100;
                      dustPtr->noGravity = true;
                    }
                    else
                      break;
                  }
                  if ((int) this.type != 1 && (int) this.type != 59 && !this.noGravity)
                    Main.PlaySound(19, this.aabb.X, this.aabb.Y, 0);
                }
                else
                {
                  for (int index = 0; index < 7; ++index)
                  {
                    Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 35, 0.0, 0.0, 0, new Color(), 1.0);
                    if ((IntPtr) dustPtr != IntPtr.Zero)
                    {
                      dustPtr->velocity.Y -= 1.5f;
                      dustPtr->velocity.X *= 2.5f;
                      dustPtr->scale = 1.3f;
                      dustPtr->alpha = (short) 100;
                      dustPtr->noGravity = true;
                    }
                    else
                      break;
                  }
                  if ((int) this.type != 1 && (int) this.type != 59 && !this.noGravity)
                    Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
                }
              }
            }
            if (!this.wet)
              this.lavaWet = false;
            if ((int) this.wetCount > 0)
              --this.wetCount;
            bool flag4 = false;
            if ((int) this.aiStyle == 10)
              flag4 = true;
            else if ((int) this.aiStyle == 14)
              flag4 = true;
            else if ((int) this.aiStyle == 3 && (int) this.directionY == 1)
              flag4 = true;
            this.oldVelocity = this.velocity;
            this.collideX = false;
            this.collideY = false;
            if (this.wet)
            {
              Vector2 vector2_1 = this.velocity;
              Collision.TileCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height, flag4, flag4);
              if (Collision.up)
                this.velocity.Y = 0.01f;
              Vector2 vector2_2 = this.velocity;
              vector2_2.X *= 0.5f;
              vector2_2.Y *= 0.5f;
              if ((double) this.velocity.X != (double) vector2_1.X)
              {
                vector2_2.X = this.velocity.X;
                this.collideX = true;
              }
              if ((double) this.velocity.Y != (double) vector2_1.Y)
              {
                vector2_2.Y = this.velocity.Y;
                this.collideY = true;
              }
              this.oldPosition = this.position;
              this.position.X += vector2_2.X;
              this.position.Y += vector2_2.Y;
            }
            else
            {
              if ((int) this.type == 72)
              {
                Vector2 Position = new Vector2(this.position.X + (float) ((int) this.width >> 1), this.position.Y + (float) ((int) this.height >> 1));
                int Width = 12;
                int Height = 12;
                Position.X -= (float) (Width >> 1);
                Position.Y -= (float) (Height >> 1);
                Collision.TileCollision(ref Position, ref this.velocity, Width, Height, true, true);
              }
              else
                Collision.TileCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height, flag4, flag4);
              if (Collision.up)
                this.velocity.Y = 0.01f;
              if ((double) this.oldVelocity.X != (double) this.velocity.X)
                this.collideX = true;
              if ((double) this.oldVelocity.Y != (double) this.velocity.Y)
                this.collideY = true;
              this.oldPosition = this.position;
              this.position.X += this.velocity.X;
              this.position.Y += this.velocity.Y;
            }
          }
          else
          {
            this.oldPosition = this.position;
            this.position.X += this.velocity.X;
            this.position.Y += this.velocity.Y;
          }
          this.aabb.X = (int) this.position.X;
          this.aabb.Y = (int) this.position.Y;
          if (Main.netMode != 1 && !this.noTileCollide && (this.lifeMax > 1 && Collision.SwitchTiles(this.position, (int) this.width, (int) this.height, this.oldPosition)) && (int) this.type == 46)
          {
            this.ai0 = 1f;
            this.ai1 = 400f;
            this.ai2 = 0.0f;
          }
          if ((int) this.active == 0)
            this.netUpdate = true;
          if (Main.netMode == 2)
          {
            if (this.townNPC)
              this.netSpam = (short) 0;
            if (this.netUpdate2)
              this.netUpdate = true;
            if ((int) this.active == 0)
              this.netSpam = (short) 0;
            if (this.netUpdate)
            {
              if ((int) this.netSpam <= 180)
              {
                this.netSpam += (short) 60;
                NetMessage.CreateMessage1(23, i);
                NetMessage.SendMessage();
                this.netUpdate2 = false;
              }
              else
                this.netUpdate2 = true;
            }
            if ((int) this.netSpam > 0)
              --this.netSpam;
            if ((int) this.active != 0 && this.townNPC && this.getHeadTextureId() != -1)
            {
              if (this.homeless != this.oldHomeless || (int) this.homeTileX != (int) this.oldHomeTileX || (int) this.homeTileY != (int) this.oldHomeTileY)
              {
                NetMessage.CreateMessage4(60, i, (int) Main.npc[i].homeTileX, (int) Main.npc[i].homeTileY, this.homeless ? 1 : 0);
                NetMessage.SendMessage();
              }
              this.oldHomeless = this.homeless;
              this.oldHomeTileX = this.homeTileX;
              this.oldHomeTileY = this.homeTileY;
            }
          }
          this.FindFrame();
          this.CheckActive();
          this.netUpdate = false;
          this.justHit = false;
          if ((int) this.type == 120 || (int) this.type == 154 || ((int) this.type == 137 || (int) this.type == 138))
          {
            for (int index = this.oldPos.Length - 1; index > 0; --index)
            {
              this.oldPos[index] = this.oldPos[index - 1];
              Lighting.addLight(this.aabb.X >> 4, this.aabb.Y >> 4, new Vector3(0.3f, 0.0f, 0.2f));
            }
            this.oldPos[0] = this.position;
          }
          else
          {
            if ((int) this.type != 94 && ((int) this.type < 125 || (int) this.type > 131) && ((int) this.type != 139 && (int) this.type != 140))
              return;
            for (int index = this.oldPos.Length - 1; index > 0; --index)
              this.oldPos[index] = this.oldPos[index - 1];
            this.oldPos[0] = this.position;
          }
        }
      }
    }

    public Color GetAlpha(Color newColor)
    {
      float num = (float) ((int) byte.MaxValue - (int) this.alpha) / (float) byte.MaxValue;
      int r = (int) ((double) newColor.R * (double) num);
      int g = (int) ((double) newColor.G * (double) num);
      int b = (int) ((double) newColor.B * (double) num);
      int a = (int) newColor.A - (int) this.alpha;
      if ((int) this.type == 25 || (int) this.type == 30 || ((int) this.type == 33 || (int) this.type == 59) || (int) this.type == 60)
        return new Color(200, 200, 200, 0);
      if ((int) this.type == 72)
      {
        r = (int) newColor.R;
        g = (int) newColor.G;
        b = (int) newColor.B;
      }
      else if ((int) this.type == 64 || (int) this.type == 63 || ((int) this.type == 75 || (int) this.type == 103))
      {
        r = (int) ((double) newColor.R * 1.5);
        g = (int) ((double) newColor.G * 1.5);
        b = (int) ((double) newColor.B * 1.5);
        if (r > (int) byte.MaxValue)
          r = (int) byte.MaxValue;
        if (g > (int) byte.MaxValue)
          g = (int) byte.MaxValue;
        if (b > (int) byte.MaxValue)
          b = (int) byte.MaxValue;
      }
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }

    public Color GetColor(Color newColor)
    {
      int r = (int) this.color.R - ((int) byte.MaxValue - (int) newColor.R);
      int g = (int) this.color.G - ((int) byte.MaxValue - (int) newColor.G);
      int b = (int) this.color.B - ((int) byte.MaxValue - (int) newColor.B);
      int a = (int) this.color.A - ((int) byte.MaxValue - (int) newColor.A);
      if (r < 0)
        r = 0;
      if (r > (int) byte.MaxValue)
        r = (int) byte.MaxValue;
      if (g < 0)
        g = 0;
      if (g > (int) byte.MaxValue)
        g = (int) byte.MaxValue;
      if (b < 0)
        b = 0;
      if (b > (int) byte.MaxValue)
        b = (int) byte.MaxValue;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }

    public string GetChat(Player player)
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      bool flag6 = false;
      bool flag7 = false;
      bool flag8 = false;
      bool flag9 = false;
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.npc[index].active != 0)
        {
          if ((int) Main.npc[index].type == 17)
            flag1 = true;
          else if ((int) Main.npc[index].type == 18)
            flag2 = true;
          else if ((int) Main.npc[index].type == 19)
            flag3 = true;
          else if ((int) Main.npc[index].type == 20)
            flag4 = true;
          else if ((int) Main.npc[index].type == 37)
            flag5 = true;
          else if ((int) Main.npc[index].type == 38)
            flag6 = true;
          else if ((int) Main.npc[index].type == 124)
            flag7 = true;
          else if ((int) Main.npc[index].type == 107)
            flag8 = true;
          else if ((int) Main.npc[index].type == 22)
            flag9 = true;
        }
      }
      string str = "";
      if ((int) this.type == 17)
      {
        if (!NPC.downedBoss1 && Main.rand.Next(3) == 0)
          str = (int) player.statLifeMax >= 200 ? ((int) player.statDefense > 10 ? Lang.dialog(player, 3) : Lang.dialog(player, 2)) : Lang.dialog(player, 1);
        else if (Main.gameTime.dayTime)
        {
          if ((double) Main.gameTime.time < 16200.0)
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str = Lang.dialog(player, 4);
                break;
              case 1:
                str = Lang.dialog(player, 5);
                break;
              default:
                str = Lang.dialog(player, 6);
                break;
            }
          }
          else if ((double) Main.gameTime.time > 37800.0)
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str = Lang.dialog(player, 7);
                break;
              case 1:
                str = Lang.dialog(player, 8);
                break;
              default:
                str = Lang.dialog(player, 9);
                break;
            }
          }
          else
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str = Lang.dialog(player, 10);
                break;
              case 1:
                str = Lang.dialog(player, 11);
                break;
              default:
                str = Lang.dialog(player, 12);
                break;
            }
          }
        }
        else if (Main.gameTime.bloodMoon)
        {
          if (flag2 && flag7 && Main.rand.Next(3) == 0)
          {
            str = Lang.dialog(player, 13);
          }
          else
          {
            switch (Main.rand.Next(4))
            {
              case 0:
                str = Lang.dialog(player, 14);
                break;
              case 1:
                str = Lang.dialog(player, 15);
                break;
              case 2:
                str = Lang.dialog(player, 16);
                break;
              default:
                str = Lang.dialog(player, 17);
                break;
            }
          }
        }
        else if ((double) Main.gameTime.time < 9720.0)
          str = Main.rand.Next(2) != 0 ? Lang.dialog(player, 19) : Lang.dialog(player, 18);
        else if ((double) Main.gameTime.time > 22680.0)
        {
          str = Main.rand.Next(2) != 0 ? Lang.dialog(player, 21) : Lang.dialog(player, 20);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 22);
              break;
            case 1:
              str = Lang.dialog(player, 23);
              break;
            default:
              str = Lang.dialog(player, 24);
              break;
          }
        }
      }
      else if ((int) this.type == 18)
      {
        if (Main.gameTime.bloodMoon)
        {
          if ((double) player.statLife < (double) player.statLifeMax * 0.66)
          {
            switch (Main.rand.Next(3))
            {
              case 0:
                str = Lang.dialog(player, 25);
                break;
              case 1:
                str = Lang.dialog(player, 26);
                break;
              default:
                str = Lang.dialog(player, 27);
                break;
            }
          }
          else
          {
            switch (Main.rand.Next(4))
            {
              case 0:
                str = Lang.dialog(player, 28);
                break;
              case 1:
                str = Lang.dialog(player, 29);
                break;
              case 2:
                str = Lang.dialog(player, 30);
                break;
              default:
                str = Lang.dialog(player, 31);
                break;
            }
          }
        }
        else if (Main.rand.Next(3) == 0 && !NPC.downedBoss3)
          str = Lang.dialog(player, 32);
        else if (flag6 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 33);
        else if (flag3 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 34);
        else if (flag9 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 35);
        else if ((double) player.statLife < (double) player.statLifeMax * 0.33)
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str = Lang.dialog(player, 36);
              break;
            case 1:
              str = Lang.dialog(player, 37);
              break;
            case 2:
              str = Lang.dialog(player, 38);
              break;
            case 3:
              str = Lang.dialog(player, 39);
              break;
            default:
              str = Lang.dialog(player, 40);
              break;
          }
        }
        else if ((double) player.statLife < (double) player.statLifeMax * 0.66)
        {
          switch (Main.rand.Next(7))
          {
            case 0:
              str = Lang.dialog(player, 41);
              break;
            case 1:
              str = Lang.dialog(player, 42);
              break;
            case 2:
              str = Lang.dialog(player, 43);
              break;
            case 3:
              str = Lang.dialog(player, 44);
              break;
            case 4:
              str = Lang.dialog(player, 45);
              break;
            case 5:
              str = Lang.dialog(player, 46);
              break;
            default:
              str = Lang.dialog(player, 47);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str = Lang.dialog(player, 48);
              break;
            case 1:
              str = Lang.dialog(player, 49);
              break;
            case 2:
              str = Lang.dialog(player, 50);
              break;
            default:
              str = Lang.dialog(player, 51);
              break;
          }
        }
      }
      else if ((int) this.type == 19)
      {
        if (NPC.downedBoss3 && !Main.hardMode)
          str = Lang.dialog(player, 58);
        else if (flag2 && Main.rand.Next(5) == 0)
          str = Lang.dialog(player, 59);
        else if (flag2 && Main.rand.Next(5) == 0)
          str = Lang.dialog(player, 60);
        else if (flag4 && Main.rand.Next(5) == 0)
          str = Lang.dialog(player, 61);
        else if (flag6 && Main.rand.Next(5) == 0)
          str = Lang.dialog(player, 62);
        else if (flag6 && Main.rand.Next(5) == 0)
          str = Lang.dialog(player, 63);
        else if (Main.gameTime.bloodMoon)
        {
          str = Main.rand.Next(2) != 0 ? Lang.dialog(player, 65) : Lang.dialog(player, 64);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 66);
              break;
            case 1:
              str = Lang.dialog(player, 67);
              break;
            default:
              str = Lang.dialog(player, 68);
              break;
          }
        }
      }
      else if ((int) this.type == 20)
      {
        if (!NPC.downedBoss2 && Main.rand.Next(3) == 0)
          str = Lang.dialog(player, 69);
        else if (flag3 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 70);
        else if (flag1 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 71);
        else if (flag5 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 72);
        else if (Main.gameTime.bloodMoon)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str = Lang.dialog(player, 73);
              break;
            case 1:
              str = Lang.dialog(player, 74);
              break;
            case 2:
              str = Lang.dialog(player, 75);
              break;
            default:
              str = Lang.dialog(player, 76);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str = Lang.dialog(player, 77);
              break;
            case 1:
              str = Lang.dialog(player, 78);
              break;
            case 2:
              str = Lang.dialog(player, 79);
              break;
            case 3:
              str = Lang.dialog(player, 80);
              break;
            default:
              str = Lang.dialog(player, 81);
              break;
          }
        }
      }
      else if ((int) this.type == 37)
      {
        if (Main.gameTime.dayTime)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 82);
              break;
            case 1:
              str = Lang.dialog(player, 83);
              break;
            default:
              str = Lang.dialog(player, 84);
              break;
          }
        }
        else if ((int) player.statLifeMax < 300 || (int) player.statDefense < 10)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str = Lang.dialog(player, 85);
              break;
            case 1:
              str = Lang.dialog(player, 86);
              break;
            case 2:
              str = Lang.dialog(player, 87);
              break;
            default:
              str = Lang.dialog(player, 88);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str = Lang.dialog(player, 89);
              break;
            case 1:
              str = Lang.dialog(player, 90);
              break;
            case 2:
              str = Lang.dialog(player, 91);
              break;
            default:
              str = Lang.dialog(player, 92);
              break;
          }
        }
      }
      else if ((int) this.type == 38)
      {
        if (!NPC.downedBoss2 && Main.rand.Next(3) == 0)
          Lang.dialog(player, 93);
        if (Main.gameTime.bloodMoon)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 94);
              break;
            case 1:
              str = Lang.dialog(player, 95);
              break;
            default:
              str = Lang.dialog(player, 96);
              break;
          }
        }
        else if (flag3 && Main.rand.Next(5) == 0)
          str = Lang.dialog(player, 97);
        else if (flag3 && Main.rand.Next(5) == 0)
          str = Lang.dialog(player, 98);
        else if (flag2 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 99);
        else if (flag4 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 100);
        else if (!Main.gameTime.dayTime)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str = Lang.dialog(player, 101);
              break;
            case 1:
              str = Lang.dialog(player, 102);
              break;
            case 2:
              str = Lang.dialog(player, 103);
              break;
            default:
              str = Lang.dialog(player, 104);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str = Lang.dialog(player, 105);
              break;
            case 1:
              str = Lang.dialog(player, 106);
              break;
            case 2:
              str = Lang.dialog(player, 107);
              break;
            case 3:
              str = Lang.dialog(player, 108);
              break;
            default:
              str = Lang.dialog(player, 109);
              break;
          }
        }
      }
      else if ((int) this.type == 54)
      {
        if (!flag7 && Main.rand.Next(2) == 0)
          str = Lang.dialog(player, 110);
        else if (Main.gameTime.bloodMoon)
          str = Lang.dialog(player, 111);
        else if (flag2 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 112);
        else if ((int) player.head == 24)
        {
          str = Lang.dialog(player, 113);
        }
        else
        {
          switch (Main.rand.Next(6))
          {
            case 0:
              str = Lang.dialog(player, 114);
              break;
            case 1:
              str = Lang.dialog(player, 115);
              break;
            case 2:
              str = Lang.dialog(player, 116);
              break;
            case 3:
              str = Lang.dialog(player, 117);
              break;
            case 4:
              str = Lang.dialog(player, 118);
              break;
            default:
              str = Lang.dialog(player, 119);
              break;
          }
        }
      }
      else if ((int) this.type == 105)
        str = Lang.dialog(player, 120);
      else if ((int) this.type == 107)
      {
        if (this.homeless)
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str = Lang.dialog(player, 121);
              break;
            case 1:
              str = Lang.dialog(player, 122);
              break;
            case 2:
              str = Lang.dialog(player, 123);
              break;
            case 3:
              str = Lang.dialog(player, 124);
              break;
            default:
              str = Lang.dialog(player, 125);
              break;
          }
        }
        else if (flag7 && Main.rand.Next(4) == 0)
          str = Lang.dialog(player, 126);
        else if (!Main.gameTime.dayTime)
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str = Lang.dialog(player, (int) sbyte.MaxValue);
              break;
            case 1:
              str = Lang.dialog(player, 128);
              break;
            case 2:
              str = Lang.dialog(player, 129);
              break;
            case 3:
              str = Lang.dialog(player, 130);
              break;
            default:
              str = Lang.dialog(player, 131);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str = Lang.dialog(player, 132);
              break;
            case 1:
              str = Lang.dialog(player, 133);
              break;
            case 2:
              str = Lang.dialog(player, 134);
              break;
            case 3:
              str = Lang.dialog(player, 135);
              break;
            default:
              str = Lang.dialog(player, 136);
              break;
          }
        }
      }
      else if ((int) this.type == 106)
        str = Lang.dialog(player, 137);
      else if ((int) this.type == 108)
      {
        if (this.homeless)
        {
          int num = Main.rand.Next(3);
          if (num == 0)
            str = Lang.dialog(player, 138);
          else if (num == 1 && !player.male)
            str = Lang.dialog(player, 139);
          else if (num == 1)
            str = Lang.dialog(player, 140);
          else if (num == 2)
            str = Lang.dialog(player, 141);
        }
        else if (player.male && flag9 && Main.rand.Next(6) == 0)
          str = Lang.dialog(player, 142);
        else if (player.male && flag6 && Main.rand.Next(6) == 0)
          str = Lang.dialog(player, 143);
        else if (player.male && flag8 && Main.rand.Next(6) == 0)
          str = Lang.dialog(player, 144);
        else if (!player.male && flag2 && Main.rand.Next(6) == 0)
          str = Lang.dialog(player, 145);
        else if (!player.male && flag7 && Main.rand.Next(6) == 0)
          str = Lang.dialog(player, 146);
        else if (!player.male && flag4 && Main.rand.Next(6) == 0)
          str = Lang.dialog(player, 147);
        else if (!Main.gameTime.dayTime)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 148);
              break;
            case 1:
              str = Lang.dialog(player, 149);
              break;
            case 2:
              str = Lang.dialog(player, 150);
              break;
          }
        }
        else
        {
          switch (Main.rand.Next(5))
          {
            case 0:
              str = Lang.dialog(player, 151);
              break;
            case 1:
              str = Lang.dialog(player, 152);
              break;
            case 2:
              str = Lang.dialog(player, 153);
              break;
            case 3:
              str = Lang.dialog(player, 154);
              break;
            default:
              str = Lang.dialog(player, 155);
              break;
          }
        }
      }
      else if ((int) this.type == 123)
        str = Lang.dialog(player, 156);
      else if ((int) this.type == 124)
      {
        if (this.homeless)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str = Lang.dialog(player, 157);
              break;
            case 1:
              str = Lang.dialog(player, 158);
              break;
            case 2:
              str = Lang.dialog(player, 159);
              break;
            default:
              str = Lang.dialog(player, 160);
              break;
          }
        }
        else if (Main.gameTime.bloodMoon)
        {
          switch (Main.rand.Next(4))
          {
            case 0:
              str = Lang.dialog(player, 161);
              break;
            case 1:
              str = Lang.dialog(player, 162);
              break;
            case 2:
              str = Lang.dialog(player, 163);
              break;
            default:
              str = Lang.dialog(player, 164);
              break;
          }
        }
        else if (flag8 && Main.rand.Next(6) == 0)
          str = Lang.dialog(player, 165);
        else if (flag3 && Main.rand.Next(6) == 0)
        {
          str = Lang.dialog(player, 166);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 167);
              break;
            case 1:
              str = Lang.dialog(player, 168);
              break;
            default:
              str = Lang.dialog(player, 169);
              break;
          }
        }
      }
      else if ((int) this.type == 22)
      {
        if (Main.gameTime.bloodMoon)
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 170);
              break;
            case 1:
              str = Lang.dialog(player, 171);
              break;
            default:
              str = Lang.dialog(player, 172);
              break;
          }
        }
        else if (!Main.gameTime.dayTime)
        {
          str = Lang.dialog(player, 173);
        }
        else
        {
          switch (Main.rand.Next(3))
          {
            case 0:
              str = Lang.dialog(player, 174);
              break;
            case 1:
              str = Lang.dialog(player, 175);
              break;
            default:
              str = Lang.dialog(player, 176);
              break;
          }
        }
      }
      else if ((int) this.type == 142)
      {
        switch (Main.rand.Next(3))
        {
          case 0:
            str = Lang.dialog(player, 224);
            break;
          case 1:
            str = Lang.dialog(player, 225);
            break;
          case 2:
            str = Lang.dialog(player, 226);
            break;
        }
      }
      return str;
    }

    public static void checkForTownSpawns()
    {
      if ((int) ++NPC.checkForSpawnsTimer < 7200)
        return;
      NPC.checkForSpawnsTimer = (short) 0;
      int num1 = 0;
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0)
          ++num1;
      }
      WorldGen.spawnNPC = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      int num7 = 0;
      int num8 = 0;
      int num9 = 0;
      int num10 = 0;
      int num11 = 0;
      int num12 = 0;
      int num13 = 0;
      int num14 = 0;
      bool flag1 = true;
      for (int npc = 0; npc < 196; ++npc)
      {
        if ((int) Main.npc[npc].active != 0 && Main.npc[npc].townNPC)
        {
          if ((int) Main.npc[npc].type != 37 && !Main.npc[npc].homeless)
            WorldGen.QuickFindHome(npc);
          bool flag2 = Main.npc[npc].homeless;
          if ((int) Main.npc[npc].type == 37)
          {
            ++num7;
            flag2 = false;
          }
          else if ((int) Main.npc[npc].type == 17)
            ++num2;
          else if ((int) Main.npc[npc].type == 18)
            ++num3;
          else if ((int) Main.npc[npc].type == 19)
            ++num5;
          else if ((int) Main.npc[npc].type == 20)
            ++num4;
          else if ((int) Main.npc[npc].type == 22)
            ++num6;
          else if ((int) Main.npc[npc].type == 38)
            ++num8;
          else if ((int) Main.npc[npc].type == 54)
            ++num9;
          else if ((int) Main.npc[npc].type == 107)
            ++num11;
          else if ((int) Main.npc[npc].type == 108)
            ++num10;
          else if ((int) Main.npc[npc].type == 124)
            ++num12;
          else if ((int) Main.npc[npc].type == 142)
          {
            ++num13;
            flag2 = false;
          }
          flag1 = flag1 && !flag2;
          ++num14;
        }
      }
      if (WorldGen.spawnNPC != 0)
        return;
      int num15 = 0;
      bool flag3 = false;
      int num16 = 0;
      bool flag4 = false;
      bool flag5 = false;
      for (int index1 = 0; index1 < 8; ++index1)
      {
        if ((int) Main.player[index1].active != 0)
        {
          for (int index2 = 0; index2 < 48; ++index2)
          {
            if ((int) Main.player[index1].inventory[index2].type > 0 && (int) Main.player[index1].inventory[index2].stack > 0)
            {
              if ((int) Main.player[index1].inventory[index2].type == 71)
                num15 += (int) Main.player[index1].inventory[index2].stack;
              else if ((int) Main.player[index1].inventory[index2].type == 72)
                num15 += (int) Main.player[index1].inventory[index2].stack * 100;
              else if ((int) Main.player[index1].inventory[index2].type == 73)
                num15 += (int) Main.player[index1].inventory[index2].stack * 10000;
              else if ((int) Main.player[index1].inventory[index2].type == 74)
                num15 += (int) Main.player[index1].inventory[index2].stack * 1000000;
              if ((int) Main.player[index1].inventory[index2].ammo == 14 || (int) Main.player[index1].inventory[index2].useAmmo == 14)
                flag4 = true;
              if ((int) Main.player[index1].inventory[index2].type == 166 || (int) Main.player[index1].inventory[index2].type == 167 || ((int) Main.player[index1].inventory[index2].type == 168 || (int) Main.player[index1].inventory[index2].type == 235))
                flag5 = true;
            }
          }
          int num17 = (int) Main.player[index1].statLifeMax / 20;
          if (num17 > 5)
            flag3 = true;
          num16 += num17;
        }
      }
      if (!NPC.downedBoss3 && num7 == 0)
      {
        int index = NPC.NewNPC((int) Main.dungeonX * 16 + 8, (int) Main.dungeonY * 16, 37, 0);
        Main.npc[index].homeless = false;
        Main.npc[index].homeTileX = Main.dungeonX;
        Main.npc[index].homeTileY = Main.dungeonY;
      }
      if (num6 < 1)
        WorldGen.spawnNPC = 22;
      else if ((double) num15 > 5000.0 && num2 < 1)
        WorldGen.spawnNPC = 17;
      else if (flag3 && num3 < 1)
        WorldGen.spawnNPC = 18;
      else if (flag4 && num5 < 1)
        WorldGen.spawnNPC = 19;
      else if ((NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num4 < 1)
        WorldGen.spawnNPC = 20;
      else if (flag5 && num2 > 0 && num8 < 1)
        WorldGen.spawnNPC = 38;
      else if (NPC.downedBoss3 && num9 < 1)
        WorldGen.spawnNPC = 54;
      else if (NPC.savedGoblin && num11 < 1)
        WorldGen.spawnNPC = 107;
      else if (NPC.savedWizard && num10 < 1)
        WorldGen.spawnNPC = 108;
      else if (NPC.savedMech && num12 < 1)
      {
        WorldGen.spawnNPC = 124;
      }
      else
      {
        if (!NPC.downedFrost || num13 >= 1 || !Time.xMas)
          return;
        WorldGen.spawnNPC = 142;
      }
    }

    public void ApplyProjectileBuff(int type)
    {
      if (type == 2)
      {
        if (Main.rand.Next(3) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 15)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(24, 300, false);
      }
      else if (type == 19)
      {
        if (Main.rand.Next(5) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 33)
      {
        if (Main.rand.Next(5) != 0)
          return;
        this.AddBuff(20, 420, false);
      }
      else if (type == 34)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(24, 240, false);
      }
      else if (type == 35)
      {
        if (Main.rand.Next(4) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 54)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(20, 600, false);
      }
      else if (type == 63)
      {
        if (Main.rand.Next(3) == 0)
          return;
        this.AddBuff(31, 120, false);
      }
      else if (type == 85)
        this.AddBuff(24, 1200, false);
      else if (type == 95 || type == 103 || (type == 104 || type == 113))
      {
        this.AddBuff(39, 420, false);
      }
      else
      {
        if (type != 98)
          return;
        this.AddBuff(20, 600, false);
      }
    }

    public void ApplyWeaponBuff(int type)
    {
      if (type == 121)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 122)
      {
        if (Main.rand.Next(10) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 190 || type == 614)
      {
        if (Main.rand.Next(4) != 0)
          return;
        this.AddBuff(20, 420, false);
      }
      else if (type == 217)
      {
        if (Main.rand.Next(5) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else
      {
        if (type != 613 || Main.rand.Next(5) != 0)
          return;
        this.AddBuff(30, 600, false);
      }
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    public void DrawInfo(WorldView view)
    {
      if (this.realLife >= 0 && this.realLife != (int) this.whoAmI)
      {
        if (!view.drawNpcName[this.realLife])
          return;
        Main.npc[this.realLife].DrawInfo(view);
      }
      else
      {
        view.drawNpcName[(int) this.whoAmI] = false;
        string s = !this.hasName() ? this.displayName : this.getName();
        int x = this.aabb.X + ((int) this.width >> 1) - view.screenPosition.X;
        int y = this.aabb.Y + (int) this.height - view.screenPosition.Y - 10;
        int num1 = y + (int) UI.DrawStringCT(UI.fontSmall, s, x, y, UI.mouseTextColor);
        if (this.lifeMax <= 1 || this.dontTakeDamage)
          return;
        int num2 = this.life - this.healthBarLife;
        if (num2 != 0)
        {
          if (Math.Abs(num2) > 1)
            this.healthBarLife += num2 >> 2;
          else
            this.healthBarLife = this.life;
        }
        Rectangle rect = new Rectangle();
        rect.X = x - 22;
        rect.Y = num1 - 4;
        rect.Height = 10;
        rect.Width = 52;
        Color color = UI.WINDOW_OUTLINE;
        Main.DrawRect(rect, color, false);
        rect.X += 2;
        rect.Y += 2;
        rect.Width = this.healthBarLife * 48 / this.lifeMax;
        rect.Height = 6;
        color = new Color((48 - rect.Width) * 5, rect.Width * 5, 16, 128);
        Main.DrawSolidRect(ref rect, color);
        if (rect.Width >= 48)
          return;
        color = new Color(0, 0, 0, 128);
        rect.X += rect.Width;
        rect.Width = 48 - rect.Width;
        Main.DrawSolidRect(ref rect, color);
      }
    }

    public enum ID
    {
      NONE,
      SLIME,
      DEMON_EYE,
      ZOMBIE,
      EYE_OF_CTHULHU,
      SERVANT_OF_CTHULHU,
      EATER_OF_SOULS,
      DEVOURER_HEAD,
      DEVOURER_BODY,
      DEVOURER_TAIL,
      GIANT_WORM_HEAD,
      GIANT_WORM_BODY,
      GIANT_WORM_TAIL,
      EATER_OF_WORLDS_HEAD,
      EATER_OF_WORLDS_BODY,
      EATER_OF_WORLDS_TAIL,
      MOTHER_SLIME,
      MERCHANT,
      NURSE,
      ARMS_DEALER,
      DRYAD,
      SKELETON,
      GUIDE,
      METEOR_HEAD,
      FIRE_IMP,
      BURNING_SPHERE,
      GOBLIN_PEON,
      GOBLIN_THIEF,
      GOBLIN_WARRIOR,
      GOBLIN_SORCERER,
      CHAOS_BALL,
      BONES,
      DARK_CASTER,
      WATER_SPHERE,
      CURSED_SKULL,
      SKELETRON_HEAD,
      SKELETRON_HAND,
      OLD_MAN,
      DEMOLITIONIST,
      BONE_SERPENT_HEAD,
      BONE_SERPENT_BODY,
      BONE_SERPENT_TAIL,
      HORNET,
      MAN_EATER,
      UNDEAD_MINER,
      TIM,
      BUNNY,
      CORRUPT_BUNNY,
      HARPY,
      CAVE_BAT,
      KING_SLIME,
      JUNGLE_BAT,
      DOCTOR_BONES,
      THE_GROOM,
      CLOTHIER,
      GOLDFISH,
      SNATCHER,
      CORRUPT_GOLDFISH,
      PIRANHA,
      LAVA_SLIME,
      HELLBAT,
      VULTURE,
      DEMON,
      BLUE_JELLYFISH,
      PINK_JELLYFISH,
      SHARK,
      VOODOO_DEMON,
      CRAB,
      DUNGEON_GUARDIAN,
      ANTLION,
      SPIKE_BALL,
      DUNGEON_SLIME,
      BLAZING_WHEEL,
      GOBLIN_SCOUT,
      BIRD,
      PIXIE,
      XXX_UNUSED_XXX,
      ARMORED_SKELETON,
      MUMMY,
      DARK_MUMMY,
      LIGHT_MUMMY,
      CORRUPT_SLIME,
      WRAITH,
      CURSED_HAMMER,
      ENCHANTED_SWORD,
      MIMIC,
      UNICORN,
      WYVERN_HEAD,
      WYVERN_LEGS,
      WYVERN_BODY1,
      WYVERN_BODY2,
      WYVERN_BODY3,
      WYVERN_TAIL,
      GIANT_BAT,
      CORRUPTOR,
      DIGGER_HEAD,
      DIGGER_BODY,
      DIGGER_TAIL,
      SEEKER_HEAD,
      SEEKER_BODY,
      SEEKER_TAIL,
      CLINGER,
      ANGLER_FISH,
      GREEN_JELLYFISH,
      WEREWOLF,
      BOUND_GOBLIN,
      BOUND_WIZARD,
      GOBLIN_TINKERER,
      WIZARD,
      CLOWN,
      SKELETON_ARCHER,
      GOBLIN_ARCHER,
      VILE_SPIT,
      WALL_OF_FLESH,
      WALL_OF_FLESH_EYE,
      THE_HUNGRY,
      THE_HUNGRY_II,
      LEECH_HEAD,
      LEECH_BODY,
      LEECH_TAIL,
      CHAOS_ELEMENTAL,
      SLIMER,
      GASTROPOD,
      BOUND_MECHANIC,
      MECHANIC,
      RETINAZER,
      SPAZMATISM,
      SKELETRON_PRIME,
      PRIME_CANNON,
      PRIME_SAW,
      PRIME_VICE,
      PRIME_LASER,
      BALD_ZOMBIE,
      WANDERING_EYE,
      THE_DESTROYER_HEAD,
      THE_DESTROYER_BODY,
      THE_DESTROYER_TAIL,
      ILLUMINANT_BAT,
      ILLUMINANT_SLIME,
      PROBE,
      POSSESSED_ARMOR,
      TOXIC_SLUDGE,
      SANTA_CLAUS,
      SNOWMAN_GANGSTA,
      MISTER_STABBY,
      SNOW_BALLA,
      SUICIDE_SNOWMAN,
      ALBINO_ANTLION,
      ORKA,
      VAMPIRE_MINER,
      SHADOW_SLIME,
      SHADOW_HAMMER,
      SHADOW_MUMMY,
      SPECTRAL_GASTROPOD,
      SPECTRAL_ELEMENTAL,
      SPECTRAL_MUMMY,
      DRAGON_SNATCHER,
      DRAGON_HORNET,
      DRAGON_SKULL,
      ARCH_WYVERN_HEAD,
      ARCH_WYVERN_LEGS,
      ARCH_WYVERN_BODY1,
      ARCH_WYVERN_BODY2,
      ARCH_WYVERN_BODY3,
      ARCH_WYVERN_TAIL,
      ARCH_DEMON,
      OCRAM,
      SERVANT_OF_OCRAM,
      NUM_TYPES,
    }
  }
}
