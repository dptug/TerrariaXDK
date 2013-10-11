// Type: Terraria.Main
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Terraria.Achievements;

namespace Terraria
{
  public sealed class Main : Game
  {
    private static readonly string[] CUE_NAMES = new string[19]
    {
      "Music_1",
      "Music_2",
      "Music_3",
      "Music_4",
      "Music_5",
      "Music_6",
      "Music_7",
      "Music_8",
      "Music_9",
      "Music_10",
      "Music_11",
      "Music_12",
      "Music_13",
      "Desert",
      "FloatingIsland",
      "Tutorial",
      "Boss4",
      "Ocean",
      "Snow"
    };
    private static readonly Main.Music[] MUSIC_BOX_TO_SONG = new Main.Music[19]
    {
      Main.Music.MUSIC_1,
      Main.Music.MUSIC_2,
      Main.Music.MUSIC_3,
      Main.Music.MUSIC_6,
      Main.Music.MUSIC_4,
      Main.Music.MUSIC_5,
      Main.Music.MUSIC_7,
      Main.Music.MUSIC_8,
      Main.Music.MUSIC_10,
      Main.Music.MUSIC_9,
      Main.Music.MUSIC_12,
      Main.Music.MUSIC_11,
      Main.Music.MUSIC_13,
      Main.Music.DESERT,
      Main.Music.FLOATING_ISLAND,
      Main.Music.TUTORIAL,
      Main.Music.BOSS4,
      Main.Music.OCEAN,
      Main.Music.SNOW
    };
    public static readonly Item.ID[] SONG_TO_MUSIC_BOX = new Item.ID[19]
    {
      Item.ID.MUSIC_BOX_OVERWORLD_DAY,
      Item.ID.MUSIC_BOX_EERIE,
      Item.ID.MUSIC_BOX_NIGHT,
      Item.ID.MUSIC_BOX_UNDERGROUND,
      Item.ID.MUSIC_BOX_BOSS1,
      Item.ID.MUSIC_BOX_TITLE,
      Item.ID.MUSIC_BOX_JUNGLE,
      Item.ID.MUSIC_BOX_CORRUPTION,
      Item.ID.MUSIC_BOX_THE_HALLOW,
      Item.ID.MUSIC_BOX_UNDERGROUND_CORRUPTION,
      Item.ID.MUSIC_BOX_UNDERGROUND_HALLOW,
      Item.ID.MUSIC_BOX_BOSS2,
      Item.ID.MUSIC_BOX_BOSS3,
      Item.ID.MUSIC_BOX_DESERT,
      Item.ID.MUSIC_BOX_SPACE,
      Item.ID.MUSIC_BOX_TUTORIAL,
      Item.ID.MUSIC_BOX_BOSS4,
      Item.ID.MUSIC_BOX_OCEAN,
      Item.ID.MUSIC_BOX_SNOW
    };
    public static UI[] ui = new UI[4];
    public static AchievementSystem AchievementSystem = new AchievementSystem();
    public static int musicBox = -1;
    public static float musicVolume = 0.75f;
    public static float soundVolume = 1f;
    public static float harpNote = 0.0f;
    public static bool[] projHostile = new bool[120];
    public static Recipe[] recipe = new Recipe[342];
    public static Chest[] shop = new Chest[10];
    public static int renderCount = 0;
    public static StringBuilder strBuilder = new StringBuilder(4096, 4096);
    public static bool isGameStarted = false;
    public static bool isGamePaused = false;
    public static bool hardMode = false;
    public static int DiscoStyle = 0;
    public static Vector3 DiscoRGB = new Vector3(1f, 0.0f, 0.0f);
    public static uint frameCounter = 0U;
    public static int magmaBGFrame = 0;
    public static int rightWorld = 80640;
    public static int bottomWorld = 23040;
    public static short maxTilesX = (short) 5040;
    public static short maxTilesY = (short) 1440;
    public static int maxSectionsX = (int) Main.maxTilesX / 40;
    public static int maxSectionsY = (int) Main.maxTilesY / 30;
    public static string[] tileName = new string[135];
    public static Liquid[] liquid = new Liquid[4096];
    public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[8192];
    public static Main.Music curMusic = Main.Music.NUM_SONGS;
    public static Main.Music newMusic = Main.Music.NUM_SONGS;
    public static bool checkWorldId = false;
    public static bool checkUserGeneratedContent = false;
    public static int worldSurface = 360;
    public static int worldSurfacePixels = Main.worldSurface << 4;
    public static Color[] teamColor = new Color[5];
    public static Time gameTime = new Time();
    public static Time menuTime = new Time();
    public static float demonTorch = 1f;
    public static float demonTorchDir = -0.01f;
    public static FastRandom rand = new FastRandom();
    public static SfxInstancePool[] soundDig = new SfxInstancePool[3];
    public static SfxInstancePool[] soundTink = new SfxInstancePool[3];
    public static SfxInstancePool[] soundPlayerHit = new SfxInstancePool[3];
    public static SfxInstancePool[] soundFemaleHit = new SfxInstancePool[3];
    public static SfxInstancePool[] soundItem = new SfxInstancePool[37];
    public static SfxInstancePool[] soundNPCHit = new SfxInstancePool[11];
    public static SfxInstancePool[] soundNPCKilled = new SfxInstancePool[15];
    public static SfxInstancePool[] soundZombie = new SfxInstancePool[5];
    public static SfxInstancePool[] soundRoar = new SfxInstancePool[2];
    public static SfxInstancePool[] soundSplash = new SfxInstancePool[2];
    public static Cue[] music = new Cue[19];
    public static float[] musicFade = new float[19];
    public static bool[] tileLighted = new bool[150];
    public static bool[] tileMergeDirt = new bool[150];
    public static bool[] tileCut = new bool[150];
    public static short[] tileShine = new short[150];
    public static bool[] tileShine2 = new bool[150];
    public static bool[] wallHouse = new bool[32];
    public static bool[] tileStone = new bool[150];
    public static bool[] tileAxe = new bool[150];
    public static bool[] tileHammer = new bool[150];
    public static bool[] tileWaterDeath = new bool[150];
    public static bool[] tileLavaDeath = new bool[150];
    public static bool[] tileTable = new bool[150];
    public static bool[] tileBlockLight = new bool[150];
    public static bool[] tileNoSunLight = new bool[150];
    public static bool[] tileDungeon = new bool[150];
    public static bool[] tileSolidTop = new bool[150];
    public static bool[] tileSolid = new bool[150];
    public static bool[] tileSolidNotSolidTop = new bool[150];
    public static bool[] tileSolidAndAttach = new bool[150];
    public static bool[] tileNoAttach = new bool[150];
    public static bool[] tileNoFail = new bool[150];
    public static bool[] tileFrameImportant = new bool[150];
    public static DustPool dust = new DustPool((WorldView) null, 256);
    public static Tile[,] tile = new Tile[5040, 1440];
    public static Item[] item = new Item[201];
    public static NPC[] npc = new NPC[197];
    public static Gore[] gore = new Gore[128];
    public static Projectile[] projectile = new Projectile[512];
    public static CombatText[] combatText = new CombatText[32];
    public static Chest[] chest = new Chest[1000];
    public static Sign[] sign = new Sign[1000];
    public static ChatLine[] chatLine = new ChatLine[7];
    public static Player[] player = new Player[9];
    public static bool hasFocus = true;
    public static int invasionType = 0;
    public static float invasionX = 0.0f;
    public static int invasionSize = 0;
    public static int invasionDelay = 0;
    public static int invasionWarn = 0;
    public static int netMode = 0;
    private static int saveIconCounter = 0;
    private static int activeSaves = 0;
    private static Texture2D[] splashTexture = new Texture2D[4];
    private static short showSplash = (short) 0;
    public static bool isTrial = true;
    public static Tutorial tutorialState = Tutorial.NUM_TUTORIALS;
    public static CompiledText tutorialText = (CompiledText) null;
    private short splashDelay = (short) 240;
    public const int screenWidth = 960;
    public const int screenHeight = 540;
    public const int WORLD_SMALL_W = 4200;
    public const int WORLD_SMALL_H = 1200;
    public const int WORLD_LARGE_W = 5040;
    public const int WORLD_LARGE_H = 1440;
    public const int WORLD_MEDIUM_W = 4620;
    public const int WORLD_MEDIUM_H = 1320;
    public const bool NET_VERBOSE = false;
    public const int MAX_CHESTS = 1000;
    public const int MAX_ITEMS = 200;
    public const int MAX_ITEM_SOUNDS = 37;
    public const int MAX_NPC_HIT_SOUNDS = 11;
    public const int MAX_NPC_KILLED_SOUNDS = 15;
    public const int MAX_LIQUID_TYPES = 2;
    public const int MAX_MUSIC = 19;
    public const int PLAYER_DATA_VERSION = 6;
    public const int SETTINGS_DATA_VERSION = 5;
    public const int OLD_WORLD_DATA_VERSION = 46;
    public const int NEW_WORLD_DATA_VERSION = 49;
    public const int NETWORK_VERSION = 1;
    public const string versionNumber = "Xbox360 v0.7.6";
    public const int worldRate = 1;
    public const bool IGNORE_ERRORS = false;
    public const int zoneX = 99;
    public const int zoneY = 87;
    public const bool showFrameRate = false;
    public const int leftWorld = 0;
    public const int topWorld = 0;
    public const int SECTION_WIDTH = 40;
    public const int SECTION_HEIGHT = 30;
    public const int MAX_TILESETS = 150;
    public const int MAX_TILENAMES = 135;
    public const int MAX_WALL_TYPES = 32;
    public const int MAX_COMBAT_TEXT = 32;
    public const int chatLength = 600;
    public const int numChatLines = 7;
    private const int maxItemUpdates = 5;
    public const int SAVE_ICON_SPRITE = 642;
    public const int SAVE_ICON_MESSAGE_TIME = 480;
    private const int SAVE_ICON_MIN_TIME = 180;
    private const int SPLASH_NUM_LOGOS = 4;
    private const int SPLASH_FADE_IN = 16;
    private const int SPLASH_FADE_OUT = 16;
    private const int SPLASH_DELAY = 120;
    private const int SPLASH_DELAY_RATING = 240;
    private const int UPSELL_NUM_SCREENS = 1;
    private const int UPSELL_DELAY = 600;
    public static Thread worldGenThread;
    private Thread loadingThread;
    private static GraphicsDeviceManager graphics;
    public static SpriteBatch spriteBatch;
    public static short dungeonX;
    public static short dungeonY;
    public static string worldName;
    public static int worldID;
    public static int worldTimestamp;
    public static int rockLayer;
    public static int rockLayerPixels;
    public static int magmaLayer;
    public static int magmaLayerPixels;
    public static Texture2D whiteTexture;
    public static SfxInstancePool soundMech;
    public static SfxInstancePool soundPlayerKilled;
    public static SfxInstancePool soundGrass;
    public static SfxInstancePool soundGrab;
    public static SfxInstancePool soundPixie;
    public static SfxInstancePool soundDoorOpen;
    public static SfxInstancePool soundDoorClosed;
    public static SfxInstancePool soundMenuOpen;
    public static SfxInstancePool soundMenuClose;
    public static SfxInstancePool soundMenuTick;
    public static SfxInstancePool soundShatter;
    public static SfxInstancePool soundDoubleJump;
    public static SfxInstancePool soundRun;
    public static SfxInstancePool soundCoins;
    public static SfxInstancePool soundUnlock;
    public static SfxInstancePool soundChat;
    public static SfxInstancePool soundMaxMana;
    public static SfxInstancePool soundDrown;
    public static AudioEngine audioEngine;
    public static SoundBank soundBank;
    public static WaveBank waveBank;
    public static short spawnTileX;
    public static short spawnTileY;
    public static int netPlayCounter;
    public static int lastItemUpdate;
    public static bool saveOnExit;
    private short splashCounter;
    private short splashLogo;
    private bool upsellLoaded;
    public static bool isRunningSlowly;
    public static bool isHDTV;
    public static bool TutorialMaskLS;
    public static bool TutorialMaskRS;
    public static bool TutorialMaskRSpress;
    public static bool TutorialMaskA;
    public static bool TutorialMaskB;
    public static bool TutorialMaskX;
    public static bool TutorialMaskY;
    public static bool TutorialMaskLB;
    public static bool TutorialMaskRB;
    public static bool TutorialMaskLT;
    public static bool TutorialMaskRT;
    public static bool TutorialMaskBack;
    private static int tutorialInputDelay;
    private static uint tutorialVar;
    private static uint tutorialVar2;
    private static Location tutorialHouse;

    static Main()
    {
    }

    public Main()
    {
      Main.graphics = new GraphicsDeviceManager((Game) this);
      Main.graphics.SynchronizeWithVerticalRetrace = true;
      this.IsFixedTimeStep = true;
      this.Content.RootDirectory = "Content";
    }

    public static ulong GetWorldId()
    {
      return (ulong) Main.worldID << 32 | (ulong) (uint) Main.worldTimestamp;
    }

    protected override void Initialize()
    {
      base.Initialize();
      Main.menuTime.reset(86.4f);
      Main.gameTime.reset(1f);
      NPC.clrNames();
      NPC.setNames();
      Main.tileShine2[6] = true;
      Main.tileShine2[7] = true;
      Main.tileShine2[8] = true;
      Main.tileShine2[9] = true;
      Main.tileShine2[12] = true;
      Main.tileShine2[21] = true;
      Main.tileShine2[22] = true;
      Main.tileShine2[25] = true;
      Main.tileShine2[45] = true;
      Main.tileShine2[46] = true;
      Main.tileShine2[47] = true;
      Main.tileShine2[63] = true;
      Main.tileShine2[64] = true;
      Main.tileShine2[65] = true;
      Main.tileShine2[66] = true;
      Main.tileShine2[67] = true;
      Main.tileShine2[68] = true;
      Main.tileShine2[107] = true;
      Main.tileShine2[108] = true;
      Main.tileShine2[111] = true;
      Main.tileShine2[117] = true;
      Main.tileShine2[121] = true;
      Main.tileShine2[122] = true;
      Main.tileShine[6] = (short) 1150;
      Main.tileShine[7] = (short) 1100;
      Main.tileShine[8] = (short) 1000;
      Main.tileShine[9] = (short) 1050;
      Main.tileShine[12] = (short) 1000;
      Main.tileShine[21] = (short) 1200;
      Main.tileShine[22] = (short) 1150;
      Main.tileShine[45] = (short) 1900;
      Main.tileShine[46] = (short) 2000;
      Main.tileShine[47] = (short) 2100;
      Main.tileShine[63] = (short) 900;
      Main.tileShine[64] = (short) 900;
      Main.tileShine[65] = (short) 900;
      Main.tileShine[66] = (short) 900;
      Main.tileShine[67] = (short) 900;
      Main.tileShine[68] = (short) 900;
      Main.tileShine[107] = (short) 950;
      Main.tileShine[108] = (short) 900;
      Main.tileShine[109] = (short) 9000;
      Main.tileShine[110] = (short) 9000;
      Main.tileShine[111] = (short) 850;
      Main.tileShine[116] = (short) 9000;
      Main.tileShine[117] = (short) 9000;
      Main.tileShine[118] = (short) 8000;
      Main.tileShine[121] = (short) 1850;
      Main.tileShine[122] = (short) 1800;
      Main.tileShine[125] = (short) 600;
      Main.tileShine[129] = (short) 300;
      Main.tileHammer[141] = true;
      Main.tileHammer[4] = true;
      Main.tileHammer[10] = true;
      Main.tileHammer[11] = true;
      Main.tileHammer[12] = true;
      Main.tileHammer[13] = true;
      Main.tileHammer[14] = true;
      Main.tileHammer[15] = true;
      Main.tileHammer[16] = true;
      Main.tileHammer[17] = true;
      Main.tileHammer[18] = true;
      Main.tileHammer[19] = true;
      Main.tileHammer[21] = true;
      Main.tileHammer[26] = true;
      Main.tileHammer[28] = true;
      Main.tileHammer[29] = true;
      Main.tileHammer[31] = true;
      Main.tileHammer[33] = true;
      Main.tileHammer[34] = true;
      Main.tileHammer[35] = true;
      Main.tileHammer[36] = true;
      Main.tileHammer[42] = true;
      Main.tileHammer[48] = true;
      Main.tileHammer[49] = true;
      Main.tileHammer[50] = true;
      Main.tileHammer[54] = true;
      Main.tileHammer[55] = true;
      Main.tileHammer[77] = true;
      Main.tileHammer[78] = true;
      Main.tileHammer[79] = true;
      Main.tileHammer[81] = true;
      Main.tileHammer[85] = true;
      Main.tileHammer[86] = true;
      Main.tileHammer[87] = true;
      Main.tileHammer[88] = true;
      Main.tileHammer[89] = true;
      Main.tileHammer[90] = true;
      Main.tileHammer[91] = true;
      Main.tileHammer[92] = true;
      Main.tileHammer[93] = true;
      Main.tileHammer[94] = true;
      Main.tileHammer[95] = true;
      Main.tileHammer[96] = true;
      Main.tileHammer[97] = true;
      Main.tileHammer[98] = true;
      Main.tileHammer[99] = true;
      Main.tileHammer[100] = true;
      Main.tileHammer[101] = true;
      Main.tileHammer[102] = true;
      Main.tileHammer[103] = true;
      Main.tileHammer[104] = true;
      Main.tileHammer[105] = true;
      Main.tileHammer[106] = true;
      Main.tileHammer[114] = true;
      Main.tileHammer[125] = true;
      Main.tileHammer[126] = true;
      Main.tileHammer[128] = true;
      Main.tileHammer[129] = true;
      Main.tileHammer[132] = true;
      Main.tileHammer[133] = true;
      Main.tileHammer[134] = true;
      Main.tileHammer[135] = true;
      Main.tileHammer[136] = true;
      Main.tileFrameImportant[139] = true;
      Main.tileHammer[139] = true;
      Main.tileLighted[149] = true;
      Main.tileFrameImportant[149] = true;
      Main.tileHammer[149] = true;
      Main.tileFrameImportant[142] = true;
      Main.tileHammer[142] = true;
      Main.tileFrameImportant[143] = true;
      Main.tileHammer[143] = true;
      Main.tileFrameImportant[144] = true;
      Main.tileHammer[144] = true;
      Main.tileStone[131] = true;
      Main.tileFrameImportant[136] = true;
      Main.tileFrameImportant[137] = true;
      Main.tileFrameImportant[138] = true;
      Main.tileBlockLight[137] = true;
      Main.tileSolid[137] = true;
      Main.tileBlockLight[145] = true;
      Main.tileSolid[145] = true;
      Main.tileMergeDirt[145] = true;
      Main.tileBlockLight[146] = true;
      Main.tileSolid[146] = true;
      Main.tileMergeDirt[146] = true;
      Main.tileBlockLight[147] = true;
      Main.tileSolid[147] = true;
      Main.tileMergeDirt[147] = true;
      Main.tileBlockLight[148] = true;
      Main.tileSolid[148] = true;
      Main.tileMergeDirt[148] = true;
      Main.tileBlockLight[138] = true;
      Main.tileSolid[138] = true;
      Main.tileBlockLight[140] = true;
      Main.tileSolid[140] = true;
      Main.tileAxe[5] = true;
      Main.tileAxe[30] = true;
      Main.tileAxe[72] = true;
      Main.tileAxe[80] = true;
      Main.tileAxe[124] = true;
      Main.tileLighted[4] = true;
      Main.tileLighted[17] = true;
      Main.tileLighted[19] = true;
      Main.tileLighted[22] = true;
      Main.tileLighted[26] = true;
      Main.tileLighted[31] = true;
      Main.tileLighted[33] = true;
      Main.tileLighted[34] = true;
      Main.tileLighted[35] = true;
      Main.tileLighted[36] = true;
      Main.tileLighted[37] = true;
      Main.tileLighted[42] = true;
      Main.tileLighted[49] = true;
      Main.tileLighted[58] = true;
      Main.tileLighted[61] = true;
      Main.tileLighted[70] = true;
      Main.tileLighted[71] = true;
      Main.tileLighted[72] = true;
      Main.tileLighted[76] = true;
      Main.tileLighted[77] = true;
      Main.tileLighted[83] = true;
      Main.tileLighted[84] = true;
      Main.tileLighted[92] = true;
      Main.tileLighted[93] = true;
      Main.tileLighted[95] = true;
      Main.tileLighted[98] = true;
      Main.tileLighted[100] = true;
      Main.tileLighted[109] = true;
      Main.tileLighted[125] = true;
      Main.tileLighted[126] = true;
      Main.tileLighted[129] = true;
      Main.tileLighted[133] = true;
      Main.tileLighted[140] = true;
      Main.tileMergeDirt[1] = true;
      Main.tileMergeDirt[6] = true;
      Main.tileMergeDirt[7] = true;
      Main.tileMergeDirt[8] = true;
      Main.tileMergeDirt[9] = true;
      Main.tileMergeDirt[22] = true;
      Main.tileMergeDirt[25] = true;
      Main.tileMergeDirt[30] = true;
      Main.tileMergeDirt[37] = true;
      Main.tileMergeDirt[38] = true;
      Main.tileMergeDirt[39] = true;
      Main.tileMergeDirt[40] = true;
      Main.tileMergeDirt[41] = true;
      Main.tileMergeDirt[43] = true;
      Main.tileMergeDirt[44] = true;
      Main.tileMergeDirt[45] = true;
      Main.tileMergeDirt[46] = true;
      Main.tileMergeDirt[47] = true;
      Main.tileMergeDirt[53] = true;
      Main.tileMergeDirt[56] = true;
      Main.tileMergeDirt[107] = true;
      Main.tileMergeDirt[108] = true;
      Main.tileMergeDirt[111] = true;
      Main.tileMergeDirt[112] = true;
      Main.tileMergeDirt[116] = true;
      Main.tileMergeDirt[117] = true;
      Main.tileMergeDirt[123] = true;
      Main.tileMergeDirt[140] = true;
      Main.tileMergeDirt[122] = true;
      Main.tileMergeDirt[121] = true;
      Main.tileMergeDirt[120] = true;
      Main.tileMergeDirt[119] = true;
      Main.tileMergeDirt[118] = true;
      Main.tileFrameImportant[3] = true;
      Main.tileFrameImportant[4] = true;
      Main.tileFrameImportant[5] = true;
      Main.tileFrameImportant[10] = true;
      Main.tileFrameImportant[11] = true;
      Main.tileFrameImportant[12] = true;
      Main.tileFrameImportant[13] = true;
      Main.tileFrameImportant[14] = true;
      Main.tileFrameImportant[15] = true;
      Main.tileFrameImportant[16] = true;
      Main.tileFrameImportant[17] = true;
      Main.tileFrameImportant[18] = true;
      Main.tileFrameImportant[20] = true;
      Main.tileFrameImportant[21] = true;
      Main.tileFrameImportant[24] = true;
      Main.tileFrameImportant[26] = true;
      Main.tileFrameImportant[27] = true;
      Main.tileFrameImportant[28] = true;
      Main.tileFrameImportant[29] = true;
      Main.tileFrameImportant[31] = true;
      Main.tileFrameImportant[33] = true;
      Main.tileFrameImportant[34] = true;
      Main.tileFrameImportant[35] = true;
      Main.tileFrameImportant[36] = true;
      Main.tileFrameImportant[42] = true;
      Main.tileFrameImportant[50] = true;
      Main.tileFrameImportant[55] = true;
      Main.tileFrameImportant[61] = true;
      Main.tileFrameImportant[71] = true;
      Main.tileFrameImportant[72] = true;
      Main.tileFrameImportant[73] = true;
      Main.tileFrameImportant[74] = true;
      Main.tileFrameImportant[77] = true;
      Main.tileFrameImportant[78] = true;
      Main.tileFrameImportant[79] = true;
      Main.tileFrameImportant[81] = true;
      Main.tileFrameImportant[82] = true;
      Main.tileFrameImportant[83] = true;
      Main.tileFrameImportant[84] = true;
      Main.tileFrameImportant[85] = true;
      Main.tileFrameImportant[86] = true;
      Main.tileFrameImportant[87] = true;
      Main.tileFrameImportant[88] = true;
      Main.tileFrameImportant[89] = true;
      Main.tileFrameImportant[90] = true;
      Main.tileFrameImportant[91] = true;
      Main.tileFrameImportant[92] = true;
      Main.tileFrameImportant[93] = true;
      Main.tileFrameImportant[94] = true;
      Main.tileFrameImportant[95] = true;
      Main.tileFrameImportant[96] = true;
      Main.tileFrameImportant[97] = true;
      Main.tileFrameImportant[98] = true;
      Main.tileFrameImportant[99] = true;
      Main.tileFrameImportant[101] = true;
      Main.tileFrameImportant[102] = true;
      Main.tileFrameImportant[103] = true;
      Main.tileFrameImportant[104] = true;
      Main.tileFrameImportant[105] = true;
      Main.tileFrameImportant[100] = true;
      Main.tileFrameImportant[106] = true;
      Main.tileFrameImportant[110] = true;
      Main.tileFrameImportant[113] = true;
      Main.tileFrameImportant[114] = true;
      Main.tileFrameImportant[125] = true;
      Main.tileFrameImportant[126] = true;
      Main.tileFrameImportant[128] = true;
      Main.tileFrameImportant[129] = true;
      Main.tileFrameImportant[132] = true;
      Main.tileFrameImportant[133] = true;
      Main.tileFrameImportant[134] = true;
      Main.tileFrameImportant[135] = true;
      Main.tileFrameImportant[141] = true;
      Main.tileCut[3] = true;
      Main.tileCut[24] = true;
      Main.tileCut[28] = true;
      Main.tileCut[32] = true;
      Main.tileCut[51] = true;
      Main.tileCut[52] = true;
      Main.tileCut[61] = true;
      Main.tileCut[62] = true;
      Main.tileCut[69] = true;
      Main.tileCut[71] = true;
      Main.tileCut[73] = true;
      Main.tileCut[74] = true;
      Main.tileCut[82] = true;
      Main.tileCut[83] = true;
      Main.tileCut[84] = true;
      Main.tileCut[110] = true;
      Main.tileCut[113] = true;
      Main.tileCut[115] = true;
      Main.tileLavaDeath[104] = true;
      Main.tileLavaDeath[110] = true;
      Main.tileLavaDeath[113] = true;
      Main.tileLavaDeath[115] = true;
      Main.tileSolid[(int) sbyte.MaxValue] = true;
      Main.tileSolid[130] = true;
      Main.tileBlockLight[130] = true;
      Main.tileSolid[107] = true;
      Main.tileBlockLight[107] = true;
      Main.tileSolid[108] = true;
      Main.tileBlockLight[108] = true;
      Main.tileSolid[111] = true;
      Main.tileBlockLight[111] = true;
      Main.tileSolid[109] = true;
      Main.tileBlockLight[109] = true;
      Main.tileSolid[110] = false;
      Main.tileNoAttach[110] = true;
      Main.tileNoFail[110] = true;
      Main.tileSolid[112] = true;
      Main.tileBlockLight[112] = true;
      Main.tileSolid[116] = true;
      Main.tileBlockLight[116] = true;
      Main.tileSolid[117] = true;
      Main.tileBlockLight[117] = true;
      Main.tileSolid[123] = true;
      Main.tileBlockLight[123] = true;
      Main.tileSolid[118] = true;
      Main.tileBlockLight[118] = true;
      Main.tileSolid[119] = true;
      Main.tileBlockLight[119] = true;
      Main.tileSolid[120] = true;
      Main.tileBlockLight[120] = true;
      Main.tileSolid[121] = true;
      Main.tileBlockLight[121] = true;
      Main.tileSolid[122] = true;
      Main.tileBlockLight[122] = true;
      Main.tileBlockLight[115] = true;
      Main.tileSolid[0] = true;
      Main.tileBlockLight[0] = true;
      Main.tileSolid[1] = true;
      Main.tileBlockLight[1] = true;
      Main.tileSolid[2] = true;
      Main.tileBlockLight[2] = true;
      Main.tileSolid[3] = false;
      Main.tileNoAttach[3] = true;
      Main.tileNoFail[3] = true;
      Main.tileSolid[4] = false;
      Main.tileNoAttach[4] = true;
      Main.tileNoFail[4] = true;
      Main.tileNoFail[24] = true;
      Main.tileSolid[5] = false;
      Main.tileSolid[6] = true;
      Main.tileBlockLight[6] = true;
      Main.tileSolid[7] = true;
      Main.tileBlockLight[7] = true;
      Main.tileSolid[8] = true;
      Main.tileBlockLight[8] = true;
      Main.tileSolid[9] = true;
      Main.tileBlockLight[9] = true;
      Main.tileBlockLight[10] = true;
      Main.tileSolid[10] = true;
      Main.tileNoAttach[10] = true;
      Main.tileBlockLight[10] = true;
      Main.tileSolid[11] = false;
      Main.tileSolidTop[19] = true;
      Main.tileSolid[19] = true;
      Main.tileSolid[22] = true;
      Main.tileSolid[23] = true;
      Main.tileSolid[25] = true;
      Main.tileSolid[30] = true;
      Main.tileNoFail[32] = true;
      Main.tileBlockLight[32] = true;
      Main.tileSolid[37] = true;
      Main.tileBlockLight[37] = true;
      Main.tileSolid[38] = true;
      Main.tileBlockLight[38] = true;
      Main.tileSolid[39] = true;
      Main.tileBlockLight[39] = true;
      Main.tileSolid[40] = true;
      Main.tileBlockLight[40] = true;
      Main.tileSolid[41] = true;
      Main.tileBlockLight[41] = true;
      Main.tileSolid[43] = true;
      Main.tileBlockLight[43] = true;
      Main.tileSolid[44] = true;
      Main.tileBlockLight[44] = true;
      Main.tileSolid[45] = true;
      Main.tileBlockLight[45] = true;
      Main.tileSolid[46] = true;
      Main.tileBlockLight[46] = true;
      Main.tileSolid[47] = true;
      Main.tileBlockLight[47] = true;
      Main.tileSolid[48] = true;
      Main.tileBlockLight[48] = true;
      Main.tileSolid[53] = true;
      Main.tileBlockLight[53] = true;
      Main.tileSolid[54] = true;
      Main.tileBlockLight[52] = true;
      Main.tileSolid[56] = true;
      Main.tileBlockLight[56] = true;
      Main.tileSolid[57] = true;
      Main.tileBlockLight[57] = true;
      Main.tileSolid[58] = true;
      Main.tileBlockLight[58] = true;
      Main.tileSolid[59] = true;
      Main.tileBlockLight[59] = true;
      Main.tileSolid[60] = true;
      Main.tileBlockLight[60] = true;
      Main.tileSolid[63] = true;
      Main.tileBlockLight[63] = true;
      Main.tileStone[63] = true;
      Main.tileStone[130] = true;
      Main.tileSolid[64] = true;
      Main.tileBlockLight[64] = true;
      Main.tileStone[64] = true;
      Main.tileSolid[65] = true;
      Main.tileBlockLight[65] = true;
      Main.tileStone[65] = true;
      Main.tileSolid[66] = true;
      Main.tileBlockLight[66] = true;
      Main.tileStone[66] = true;
      Main.tileSolid[67] = true;
      Main.tileBlockLight[67] = true;
      Main.tileStone[67] = true;
      Main.tileSolid[68] = true;
      Main.tileBlockLight[68] = true;
      Main.tileStone[68] = true;
      Main.tileSolid[75] = true;
      Main.tileBlockLight[75] = true;
      Main.tileSolid[76] = true;
      Main.tileBlockLight[76] = true;
      Main.tileSolid[70] = true;
      Main.tileBlockLight[70] = true;
      Main.tileNoFail[50] = true;
      Main.tileNoAttach[50] = true;
      Main.tileDungeon[41] = true;
      Main.tileDungeon[43] = true;
      Main.tileDungeon[44] = true;
      Main.tileBlockLight[30] = true;
      Main.tileBlockLight[25] = true;
      Main.tileBlockLight[23] = true;
      Main.tileBlockLight[22] = true;
      Main.tileBlockLight[62] = true;
      Main.tileSolidTop[18] = true;
      Main.tileSolidTop[14] = true;
      Main.tileSolidTop[16] = true;
      Main.tileSolidTop[114] = true;
      Main.tileNoAttach[13] = true;
      Main.tileNoAttach[14] = true;
      Main.tileNoAttach[15] = true;
      Main.tileNoAttach[16] = true;
      Main.tileNoAttach[17] = true;
      Main.tileNoAttach[18] = true;
      Main.tileNoAttach[19] = true;
      Main.tileNoAttach[21] = true;
      Main.tileNoAttach[20] = true;
      Main.tileNoAttach[27] = true;
      Main.tileNoAttach[114] = true;
      Main.tileTable[14] = true;
      Main.tileTable[18] = true;
      Main.tileTable[19] = true;
      Main.tileTable[114] = true;
      Main.tileNoAttach[86] = true;
      Main.tileNoAttach[87] = true;
      Main.tileNoAttach[88] = true;
      Main.tileNoAttach[89] = true;
      Main.tileNoAttach[90] = true;
      Main.tileLavaDeath[86] = true;
      Main.tileLavaDeath[87] = true;
      Main.tileLavaDeath[88] = true;
      Main.tileLavaDeath[89] = true;
      Main.tileLavaDeath[125] = true;
      Main.tileLavaDeath[126] = true;
      Main.tileLavaDeath[101] = true;
      Main.tileTable[101] = true;
      Main.tileNoAttach[101] = true;
      Main.tileLavaDeath[102] = true;
      Main.tileNoAttach[102] = true;
      Main.tileNoAttach[94] = true;
      Main.tileNoAttach[95] = true;
      Main.tileNoAttach[96] = true;
      Main.tileNoAttach[97] = true;
      Main.tileNoAttach[98] = true;
      Main.tileNoAttach[99] = true;
      Main.tileLavaDeath[94] = true;
      Main.tileLavaDeath[95] = true;
      Main.tileLavaDeath[96] = true;
      Main.tileLavaDeath[97] = true;
      Main.tileLavaDeath[98] = true;
      Main.tileLavaDeath[99] = true;
      Main.tileLavaDeath[100] = true;
      Main.tileLavaDeath[103] = true;
      Main.tileTable[87] = true;
      Main.tileTable[88] = true;
      Main.tileSolidTop[87] = true;
      Main.tileSolidTop[88] = true;
      Main.tileSolidTop[101] = true;
      Main.tileNoAttach[91] = true;
      Main.tileLavaDeath[91] = true;
      Main.tileNoAttach[92] = true;
      Main.tileLavaDeath[92] = true;
      Main.tileNoAttach[93] = true;
      Main.tileLavaDeath[93] = true;
      Main.tileWaterDeath[4] = true;
      Main.tileWaterDeath[51] = true;
      Main.tileWaterDeath[93] = true;
      Main.tileWaterDeath[98] = true;
      Main.tileLavaDeath[3] = true;
      Main.tileLavaDeath[5] = true;
      Main.tileLavaDeath[10] = true;
      Main.tileLavaDeath[11] = true;
      Main.tileLavaDeath[12] = true;
      Main.tileLavaDeath[13] = true;
      Main.tileLavaDeath[14] = true;
      Main.tileLavaDeath[15] = true;
      Main.tileLavaDeath[16] = true;
      Main.tileLavaDeath[17] = true;
      Main.tileLavaDeath[18] = true;
      Main.tileLavaDeath[19] = true;
      Main.tileLavaDeath[20] = true;
      Main.tileLavaDeath[27] = true;
      Main.tileLavaDeath[28] = true;
      Main.tileLavaDeath[29] = true;
      Main.tileLavaDeath[32] = true;
      Main.tileLavaDeath[33] = true;
      Main.tileLavaDeath[34] = true;
      Main.tileLavaDeath[35] = true;
      Main.tileLavaDeath[36] = true;
      Main.tileLavaDeath[42] = true;
      Main.tileLavaDeath[49] = true;
      Main.tileLavaDeath[50] = true;
      Main.tileLavaDeath[52] = true;
      Main.tileLavaDeath[55] = true;
      Main.tileLavaDeath[61] = true;
      Main.tileLavaDeath[62] = true;
      Main.tileLavaDeath[69] = true;
      Main.tileLavaDeath[71] = true;
      Main.tileLavaDeath[72] = true;
      Main.tileLavaDeath[73] = true;
      Main.tileLavaDeath[74] = true;
      Main.tileLavaDeath[79] = true;
      Main.tileLavaDeath[80] = true;
      Main.tileLavaDeath[81] = true;
      Main.tileLavaDeath[106] = true;
      Main.wallHouse[1] = true;
      Main.wallHouse[4] = true;
      Main.wallHouse[5] = true;
      Main.wallHouse[6] = true;
      Main.wallHouse[10] = true;
      Main.wallHouse[11] = true;
      Main.wallHouse[12] = true;
      Main.wallHouse[16] = true;
      Main.wallHouse[17] = true;
      Main.wallHouse[18] = true;
      Main.wallHouse[19] = true;
      Main.wallHouse[20] = true;
      Main.wallHouse[21] = true;
      Main.wallHouse[22] = true;
      Main.wallHouse[23] = true;
      Main.wallHouse[24] = true;
      Main.wallHouse[25] = true;
      Main.wallHouse[26] = true;
      Main.wallHouse[27] = true;
      Main.wallHouse[29] = true;
      Main.wallHouse[30] = true;
      Main.wallHouse[31] = true;
      for (int index = 149; index >= 0; --index)
      {
        Main.tileSolidNotSolidTop[index] = Main.tileSolid[index] & !Main.tileSolidTop[index];
        Main.tileSolidAndAttach[index] = Main.tileSolid[index] & !Main.tileNoAttach[index];
      }
      Main.tileNoFail[32] = true;
      Main.tileNoFail[61] = true;
      Main.tileNoFail[69] = true;
      Main.tileNoFail[73] = true;
      Main.tileNoFail[74] = true;
      Main.tileNoFail[82] = true;
      Main.tileNoFail[83] = true;
      Main.tileNoFail[84] = true;
      Main.tileNoFail[110] = true;
      Main.tileNoFail[113] = true;
      for (int index = 0; index < 150; ++index)
      {
        if (Main.tileSolid[index])
          Main.tileNoSunLight[index] = true;
      }
      Main.tileNoSunLight[19] = false;
      Main.tileNoSunLight[11] = true;
      Main.dust.Init();
      for (int index = 0; index < 201; ++index)
        Main.item[index].Init();
      for (int index = 0; index < 197; ++index)
      {
        Main.npc[index] = new NPC();
        Main.npc[index].whoAmI = (short) index;
      }
      for (int index = 0; index < 9; ++index)
      {
        Main.player[index] = new Player();
        Main.player[index].whoAmI = (byte) index;
      }
      for (int index = 0; index < 512; ++index)
        Main.projectile[index].Init();
      for (int index = 0; index < 128; ++index)
        Main.gore[index].Init();
      Cloud.Initialize();
      for (int index = 0; index < 32; ++index)
        Main.combatText[index].Init();
      Recipe.SetupRecipes();
      for (int index = 0; index < 7; ++index)
        Main.chatLine[index].Init();
      Main.teamColor[0] = Color.White;
      Main.teamColor[1] = new Color(230, 40, 20);
      Main.teamColor[2] = new Color(20, 200, 30);
      Main.teamColor[3] = new Color(75, 90, (int) byte.MaxValue);
      Main.teamColor[4] = new Color(200, 180, 0);
      Projectile projectile = new Projectile();
      for (int Type = 1; Type < 120; ++Type)
      {
        projectile.SetDefaults(Type);
        Main.projHostile[Type] = projectile.hostile;
      }
    }

    private void InitializePostSplash()
    {
      UI.Initialize(this);
      WorldView.Initialize(this.GraphicsDevice);
      for (int index = 0; index < 4; ++index)
        Main.ui[index] = new UI();
      Main.ui[0].setView(WorldView.Type.FULLSCREEN, true);
      for (int index = 0; index < 4; ++index)
        Main.ui[index].Initialize((PlayerIndex) index);
      Item obj = new Item();
      for (int Type = 631; Type > 0; --Type)
      {
        obj.SetDefaults(Type, 1, false);
        if ((int) obj.headSlot > 0)
          Item.headType[(int) obj.headSlot] = obj.type;
        else if ((int) obj.bodySlot > 0)
          Item.bodyType[(int) obj.bodySlot] = obj.type;
        else if ((int) obj.legSlot > 0)
          Item.legType[(int) obj.legSlot] = obj.type;
      }
      Main.shop[0] = new Chest();
      Main.shop[1] = new Chest();
      Main.shop[1].SetupShop(1, (Player) null);
      Main.shop[2] = new Chest();
      Main.shop[2].SetupShop(2, (Player) null);
      Main.shop[3] = new Chest();
      Main.shop[3].SetupShop(3, (Player) null);
      Main.shop[4] = new Chest();
      Main.shop[4].SetupShop(4, (Player) null);
      Main.shop[5] = new Chest();
      Main.shop[5].SetupShop(5, (Player) null);
      Main.shop[6] = new Chest();
      Main.shop[6].SetupShop(6, (Player) null);
      Main.shop[7] = new Chest();
      Main.shop[7].SetupShop(7, (Player) null);
      Main.shop[8] = new Chest();
      Main.shop[8].SetupShop(8, (Player) null);
      Main.shop[9] = new Chest();
      Main.shop[9].SetupShop(9, (Player) null);
      Star.SpawnStars();
      Projectile.Initialize();
      ((Collection<IGameComponent>) this.Components).Add((IGameComponent) new GamerServicesComponent((Game) this));
      SignedInGamer.add_SignedIn(new EventHandler<SignedInEventArgs>(Main.SignedInGamer_SignedIn));
      SignedInGamer.add_SignedOut(new EventHandler<SignedOutEventArgs>(Main.SignedInGamer_SignedOut));
      NetworkSession.add_InviteAccepted(new EventHandler<InviteAcceptedEventArgs>(Netplay.NetworkSession_InviteAccepted));
    }

    protected override void LoadContent()
    {
      this.GraphicsDevice.DepthStencilState = DepthStencilState.None;
      this.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
      Main.graphics.PreferredBackBufferWidth = 960;
      Main.graphics.PreferredBackBufferHeight = 540;
      Main.graphics.ApplyChanges();
      Main.isHDTV = Main.graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height >= 720;
      Main.spriteBatch = new SpriteBatch(this.GraphicsDevice);
      string assetName = Lang.setSystemLang();
      if (assetName != null)
      {
        Main.splashTexture[0] = this.Content.Load<Texture2D>(assetName);
      }
      else
      {
        this.splashLogo = (short) 1;
        this.splashDelay = (short) 120;
      }
      Main.splashTexture[1] = this.Content.Load<Texture2D>("Images/logo_1");
      this.loadingThread = new Thread(new ThreadStart(this.LoadingThread));
      this.loadingThread.IsBackground = true;
      this.loadingThread.Start();
    }

    private void LoadingThread()
    {
      Thread.CurrentThread.SetProcessorAffinity(new int[1]
      {
        5
      });
      try
      {
        for (int index = 2; index < 4; ++index)
          Main.splashTexture[index] = this.Content.Load<Texture2D>("Images/logo_" + (object) index);
        Main.audioEngine = new AudioEngine("Content/TerrariaMusic.xgs");
        Main.soundBank = new SoundBank(Main.audioEngine, "Content/Sound Bank.xsb");
        Main.waveBank = new WaveBank(Main.audioEngine, "Content/Wave Bank.xwb");
        for (int index = 0; index < 19; ++index)
          Main.music[index] = Main.soundBank.GetCue(Main.CUE_NAMES[index]);
        Main.soundMech = new SfxInstancePool(this.Content, "Sounds/Mech_0", 3);
        Main.soundGrab = new SfxInstancePool(this.Content, "Sounds/Grab", 3);
        Main.soundPixie = new SfxInstancePool(this.Content, "Sounds/Pixie", 2);
        Main.soundDig[0] = new SfxInstancePool(this.Content, "Sounds/Dig_0", 3);
        Main.soundDig[1] = new SfxInstancePool(this.Content, "Sounds/Dig_1", 3);
        Main.soundDig[2] = new SfxInstancePool(this.Content, "Sounds/Dig_2", 3);
        Main.soundTink[0] = new SfxInstancePool(this.Content, "Sounds/Tink_0", 3);
        Main.soundTink[1] = new SfxInstancePool(this.Content, "Sounds/Tink_1", 3);
        Main.soundTink[2] = new SfxInstancePool(this.Content, "Sounds/Tink_2", 3);
        Main.soundPlayerHit[0] = new SfxInstancePool(this.Content, "Sounds/Player_Hit_0", 3);
        Main.soundPlayerHit[1] = new SfxInstancePool(this.Content, "Sounds/Player_Hit_1", 3);
        Main.soundPlayerHit[2] = new SfxInstancePool(this.Content, "Sounds/Player_Hit_2", 3);
        Main.soundFemaleHit[0] = new SfxInstancePool(this.Content, "Sounds/Female_Hit_0", 3);
        Main.soundFemaleHit[1] = new SfxInstancePool(this.Content, "Sounds/Female_Hit_1", 3);
        Main.soundFemaleHit[2] = new SfxInstancePool(this.Content, "Sounds/Female_Hit_2", 3);
        Main.soundPlayerKilled = new SfxInstancePool(this.Content, "Sounds/Player_Killed", 3);
        Main.soundChat = new SfxInstancePool(this.Content, "Sounds/Chat", 2);
        Main.soundGrass = new SfxInstancePool(this.Content, "Sounds/Grass", 6);
        Main.soundDoorOpen = new SfxInstancePool(this.Content, "Sounds/Door_Opened", 3);
        Main.soundDoorClosed = new SfxInstancePool(this.Content, "Sounds/Door_Closed", 3);
        Main.soundMenuTick = new SfxInstancePool(this.Content, "Sounds/Menu_Tick", 3);
        Main.soundMenuOpen = new SfxInstancePool(this.Content, "Sounds/Menu_Open", 3);
        Main.soundMenuClose = new SfxInstancePool(this.Content, "Sounds/Menu_Close", 3);
        Main.soundShatter = new SfxInstancePool(this.Content, "Sounds/Shatter", 4);
        Main.soundZombie[0] = new SfxInstancePool(this.Content, "Sounds/Zombie_0", 4);
        Main.soundZombie[1] = new SfxInstancePool(this.Content, "Sounds/Zombie_1", 4);
        Main.soundZombie[2] = new SfxInstancePool(this.Content, "Sounds/Zombie_2", 4);
        Main.soundZombie[3] = new SfxInstancePool(this.Content, "Sounds/Zombie_3", 4);
        Main.soundZombie[4] = new SfxInstancePool(this.Content, "Sounds/Zombie_4", 4);
        Main.soundRoar[0] = new SfxInstancePool(this.Content, "Sounds/Roar_0", 2);
        Main.soundRoar[1] = new SfxInstancePool(this.Content, "Sounds/Roar_1", 2);
        Main.soundSplash[0] = new SfxInstancePool(this.Content, "Sounds/Splash_0", 4);
        Main.soundSplash[1] = new SfxInstancePool(this.Content, "Sounds/Splash_1", 4);
        Main.soundDoubleJump = new SfxInstancePool(this.Content, "Sounds/Double_Jump", 3);
        Main.soundRun = new SfxInstancePool(this.Content, "Sounds/Run", 7);
        Main.soundCoins = new SfxInstancePool(this.Content, "Sounds/Coins", 4);
        Main.soundUnlock = new SfxInstancePool(this.Content, "Sounds/Unlock", 4);
        Main.soundMaxMana = new SfxInstancePool(this.Content, "Sounds/MaxMana", 4);
        Main.soundDrown = new SfxInstancePool(this.Content, "Sounds/Drown", 4);
        for (int index = 0; index < 37; ++index)
        {
          int num = index + 1;
          int maxInstances = 3;
          if (num != 9 && num != 10 && (num != 24 && num != 26) && num != 34)
            maxInstances = 2;
          Main.soundItem[index] = new SfxInstancePool(this.Content, "Sounds/Item_" + (object) (index + 1), maxInstances);
        }
        for (int index = 0; index < 11; ++index)
          Main.soundNPCHit[index] = new SfxInstancePool(this.Content, "Sounds/NPC_Hit_" + (object) (index + 1), 4);
        for (int index = 0; index < 15; ++index)
          Main.soundNPCKilled[index] = new SfxInstancePool(this.Content, "Sounds/NPC_Killed_" + (object) (index + 1), 3);
      }
      catch
      {
        Main.musicVolume = 0.0f;
        Main.soundVolume = 0.0f;
      }
      _sheetTiles.LoadContent(this.Content);
      _sheetSprites.LoadContent(this.Content);
      WorldView.LoadContent(this.Content);
      Main.whiteTexture = new Texture2D(this.GraphicsDevice, 1, 1, false, SurfaceFormat.Bgr565);
      Main.whiteTexture.SetData<ushort>(new ushort[1]
      {
        ushort.MaxValue
      });
      UI.LoadContent(this.Content);
      CRC32.Initialize();
    }

    protected override void UnloadContent()
    {
    }

    private void UpdateMusic(Player mainPlayer)
    {
      try
      {
        if (Main.curMusic != Main.Music.NUM_SONGS && Main.music[(int) Main.curMusic].IsPaused)
          Main.music[(int) Main.curMusic].Resume();
        if ((double) Main.musicVolume == 0.0)
        {
          Main.newMusic = Main.Music.NUM_SONGS;
        }
        else
        {
          bool flag = true;
          for (int index = 0; index < 4; ++index)
          {
            if (Main.ui[index].menuType != MenuType.MAIN)
            {
              flag = false;
              break;
            }
          }
          if (flag)
            Main.newMusic = UI.main.menuMode != MenuMode.CREDITS ? Main.Music.MUSIC_6 : Main.Music.TUTORIAL;
          else if (Main.IsTutorial())
          {
            Main.newMusic = Main.Music.TUTORIAL;
          }
          else
          {
            int num1 = 0;
            bool result = false;
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 10000;
            rectangle.Height = 10000;
            WorldView worldView = mainPlayer.view;
            for (int index = 0; index < 196; ++index)
            {
              if ((int) Main.npc[index].active != 0)
              {
                int num2 = (int) Main.npc[index].type;
                if (num2 == 134 || num2 >= 143 && num2 <= 145)
                {
                  rectangle.X = Main.npc[index].aabb.X + ((int) Main.npc[index].width >> 1) - 5000;
                  rectangle.Y = Main.npc[index].aabb.Y + ((int) Main.npc[index].height >> 1) - 5000;
                  worldView.viewArea.Intersects(ref rectangle, out result);
                  if (result)
                  {
                    num1 = 3;
                    break;
                  }
                }
                else if (num2 == 113 || num2 == 114 || (num2 == 125 || num2 == 126))
                {
                  rectangle.X = Main.npc[index].aabb.X + ((int) Main.npc[index].width >> 1) - 5000;
                  rectangle.Y = Main.npc[index].aabb.Y + ((int) Main.npc[index].height >> 1) - 5000;
                  worldView.viewArea.Intersects(ref rectangle, out result);
                  if (result)
                  {
                    num1 = 2;
                    break;
                  }
                }
                else if (num2 == 4 || num2 == 166)
                {
                  rectangle.X = Main.npc[index].aabb.X + ((int) Main.npc[index].width >> 1) - 5000;
                  rectangle.Y = Main.npc[index].aabb.Y + ((int) Main.npc[index].height >> 1) - 5000;
                  worldView.viewArea.Intersects(ref rectangle, out result);
                  if (result)
                  {
                    num1 = 4;
                    break;
                  }
                }
                else if (Main.npc[index].boss || num2 >= 13 && num2 <= 15 || (num2 >= 26 && num2 <= 29 || num2 == 111))
                {
                  rectangle.X = Main.npc[index].aabb.X + ((int) Main.npc[index].width >> 1) - 5000;
                  rectangle.Y = Main.npc[index].aabb.Y + ((int) Main.npc[index].height >> 1) - 5000;
                  worldView.viewArea.Intersects(ref rectangle, out result);
                  if (result)
                  {
                    num1 = 1;
                    break;
                  }
                }
              }
            }
            if (num1 > 0)
            {
              switch (num1)
              {
                case 1:
                  Main.newMusic = Main.Music.MUSIC_5;
                  break;
                case 2:
                  Main.newMusic = Main.Music.MUSIC_12;
                  break;
                case 3:
                  Main.newMusic = Main.Music.MUSIC_13;
                  break;
                case 4:
                  Main.newMusic = Main.Music.BOSS4;
                  break;
              }
            }
            else if (worldView.screenPosition.Y > (int) Main.maxTilesY - 200 << 4)
              Main.newMusic = Main.Music.MUSIC_2;
            else if (mainPlayer.zoneEvil)
              Main.newMusic = worldView.screenPosition.Y <= Main.worldSurfacePixels + 540 ? Main.Music.MUSIC_8 : Main.Music.MUSIC_10;
            else if ((double) worldView.atmo < 1.0)
              Main.newMusic = Main.Music.FLOATING_ISLAND;
            else if ((worldView.screenPosition.X < 3200 || worldView.screenPosition.X > ((int) Main.maxTilesX - 200 << 4) - 960) && worldView.screenPosition.Y <= Main.worldSurfacePixels)
              Main.newMusic = Main.Music.OCEAN;
            else if (mainPlayer.zoneMeteor || mainPlayer.zoneDungeon)
              Main.newMusic = Main.Music.MUSIC_2;
            else if (mainPlayer.zoneJungle)
              Main.newMusic = Main.Music.MUSIC_7;
            else if (mainPlayer.view.sandTiles > 1000)
              Main.newMusic = Main.Music.DESERT;
            else if (mainPlayer.view.snowTiles > 80)
              Main.newMusic = Main.Music.SNOW;
            else if (worldView.screenPosition.Y > Main.worldSurfacePixels)
              Main.newMusic = !mainPlayer.zoneHoly ? Main.Music.MUSIC_4 : Main.Music.MUSIC_11;
            else if (Main.gameTime.dayTime)
              Main.newMusic = !mainPlayer.zoneHoly ? Main.Music.MUSIC_1 : Main.Music.MUSIC_9;
            else if (!Main.gameTime.dayTime)
              Main.newMusic = !Main.gameTime.bloodMoon ? Main.Music.MUSIC_3 : Main.Music.MUSIC_2;
            for (int index = 0; Main.musicBox < 0 && index < 4; ++index)
            {
              if (Main.ui[index].view != null)
                Main.musicBox = Main.ui[index].view.musicBox;
            }
            if (Main.musicBox >= 0)
              Main.newMusic = Main.MUSIC_BOX_TO_SONG[Main.musicBox];
          }
        }
        Main.curMusic = Main.newMusic;
        for (int index = 0; index < 19; ++index)
        {
          if ((Main.Music) index == Main.curMusic)
          {
            if (!Main.music[index].IsPlaying)
            {
              Main.music[index] = Main.soundBank.GetCue(Main.CUE_NAMES[index]);
              Main.music[index].Play();
            }
            else
            {
              Main.musicFade[index] += 0.005f;
              if ((double) Main.musicFade[index] > 1.0)
                Main.musicFade[index] = 1f;
            }
            Main.music[index].SetVariable("Volume", Main.musicFade[index] * Main.musicVolume);
          }
          else if (Main.music[index].IsPlaying)
          {
            if (Main.curMusic == Main.Music.NUM_SONGS)
            {
              Main.musicFade[index] = 0.0f;
              Main.music[index].Stop(AudioStopOptions.Immediate);
            }
            else if ((double) Main.musicFade[(int) Main.curMusic] > 0.25)
            {
              Main.musicFade[index] -= 0.005f;
              if ((double) Main.musicFade[index] <= 0.0)
              {
                Main.musicFade[index] = 0.0f;
                Main.music[index].Stop(AudioStopOptions.Immediate);
              }
              else
                Main.music[index].SetVariable("Volume", Main.musicFade[index] * Main.musicVolume);
            }
          }
          else
            Main.musicFade[index] = 0.0f;
        }
      }
      catch
      {
        Main.musicVolume = 0.0f;
      }
    }

    protected override void Update(GameTime dt)
    {
      try
      {
        base.Update(dt);
      }
      catch
      {
      }
      Main.isRunningSlowly = dt.IsRunningSlowly;
      ++Main.frameCounter;
      switch (Main.showSplash)
      {
        case (short) 0:
          break;
        case (short) 1:
          this.loadingThread.Join();
          this.loadingThread = (Thread) null;
          Main.showSplash = (short) 2;
          this.InitializePostSplash();
          break;
        default:
          for (int index = 0; index < 4; ++index)
            Main.ui[index].UpdateGamePad();
          if (Main.tutorialState < Tutorial.THE_END)
            Main.UpdateTutorial();
          for (int index = 0; index < 4; ++index)
            Main.ui[index].Update();
          Main.dust.UpdateDust();
          if (UI.quit)
          {
            this.Quit();
            break;
          }
          else
          {
            UI.UpdateOnce();
            Main.AchievementSystem.Update();
            Main.audioEngine.Update();
            WorldGen.destroyObject = false;
            this.UpdateMusic(UI.main.player);
            Main.hasFocus = this.IsActive;
            Main.isGamePaused = !Main.hasFocus && Main.netMode == 0;
            if (Main.isGamePaused)
              break;
            if (Netplay.session != null)
            {
              if (!Netplay.disconnect)
              {
                if (Netplay.hookEvents)
                  Netplay.HookSessionEvents();
                if (Main.netMode == 1)
                  Main.UpdateClient();
                else
                  Main.UpdateServer();
              }
              else if (Netplay.stopSession)
                Netplay.Disconnect();
            }
            if (Netplay.invite != null)
              Netplay.InviteAccepted();
            if (Main.netMode == 0)
            {
              if (UI.main.menuType == MenuType.PAUSE)
              {
                bool flag = true;
                for (int index = 0; index < 4; ++index)
                {
                  if (Main.ui[index].menuType == MenuType.NONE)
                  {
                    flag = false;
                    break;
                  }
                }
                if (flag)
                {
                  Main.isGamePaused = true;
                  break;
                }
              }
            }
            else if (Main.checkWorldId)
            {
              for (int index = 0; index < 4; ++index)
              {
                UI ui = Main.ui[index];
                if (ui.view != null && ui.menuType == MenuType.NONE)
                {
                  Main.checkWorldId = false;
                  if (ui.CheckBlacklist())
                    break;
                }
              }
            }
            Star.UpdateStars();
            Cloud.UpdateClouds();
            for (int index = 0; index < 7; ++index)
            {
              if (Main.chatLine[index].showTime > 0)
                --Main.chatLine[index].showTime;
            }
            for (int index = 0; index < 4; ++index)
            {
              if (Main.ui[index].view != null && Main.ui[index].menuType == MenuType.MAIN)
              {
                Main.UpdateMenuTime();
                break;
              }
            }
            if (!Main.isGameStarted)
              break;
            if (Main.netMode != 0 && Main.checkUserGeneratedContent)
            {
              Main.checkUserGeneratedContent = false;
              UI.main.CheckUserGeneratedContent();
            }
            if (Main.DiscoStyle == 0)
            {
              Main.DiscoRGB.Y += 0.02745098f;
              if ((double) Main.DiscoRGB.Y >= 1.0)
              {
                Main.DiscoRGB.Y = 1f;
                Main.DiscoStyle = 1;
              }
              Main.DiscoRGB.X -= 0.02745098f;
              if ((double) Main.DiscoRGB.X < 0.0)
                Main.DiscoRGB.X = 0.0f;
            }
            else if (Main.DiscoStyle == 1)
            {
              Main.DiscoRGB.Z += 0.02745098f;
              if ((double) Main.DiscoRGB.Z >= 1.0)
              {
                Main.DiscoRGB.Z = 1f;
                Main.DiscoStyle = 2;
              }
              Main.DiscoRGB.Y -= 0.02745098f;
              if ((double) Main.DiscoRGB.Y < 0.0)
                Main.DiscoRGB.Y = 0.0f;
            }
            else
            {
              Main.DiscoRGB.X += 0.02745098f;
              if ((double) Main.DiscoRGB.X >= 1.0)
              {
                Main.DiscoRGB.X = 1f;
                Main.DiscoStyle = 0;
              }
              Main.DiscoRGB.Z -= 0.02745098f;
              if ((double) Main.DiscoRGB.Z < 0.0)
                Main.DiscoRGB.Z = 0.0f;
            }
            if (((int) Main.frameCounter & 7) == 0 && ++Main.magmaBGFrame >= 3)
              Main.magmaBGFrame = 0;
            Main.demonTorch += Main.demonTorchDir;
            if ((double) Main.demonTorch > 1.0)
            {
              Main.demonTorch = 1f;
              Main.demonTorchDir = -Main.demonTorchDir;
            }
            else if ((double) Main.demonTorch < 0.0)
            {
              Main.demonTorch = 0.0f;
              Main.demonTorchDir = -Main.demonTorchDir;
            }
            if (Main.netMode != 1)
            {
              WorldGen.UpdateWorld();
              Main.UpdateInvasion();
            }
            Main.musicBox = -1;
            for (int i = 0; i < 8; ++i)
            {
              if ((int) Main.player[i].active != 0)
                Main.player[i].UpdatePlayer(i);
            }
            if (Main.netMode != 1 && Main.tutorialState >= Tutorial.THE_END)
              NPC.SpawnNPC();
            for (int index = 0; index < 8; ++index)
            {
              Main.player[index].activeNPCs = 0.0f;
              Main.player[index].townNPCs = 0.0f;
            }
            if (NPC.wof >= 0 && (int) Main.npc[NPC.wof].active == 0)
              NPC.wof = -1;
            for (int i = 195; i >= 0; --i)
            {
              if ((int) Main.npc[i].active != 0)
                Main.npc[i].UpdateNPC(i);
            }
            for (int index = 0; index < 128; ++index)
            {
              if ((int) Main.gore[index].active != 0)
                Main.gore[index].Update();
            }
            for (int i = 0; i < 512; ++i)
            {
              if ((int) Main.projectile[i].active != 0)
                Main.projectile[i].Update(i);
            }
            for (int i = 0; i < 200; ++i)
            {
              if ((int) Main.item[i].active != 0)
                Main.item[i].UpdateItem(i);
            }
            CombatText.UpdateCombatText();
            Main.UpdateTime();
            break;
          }
      }
    }

    private static void UpdateMenuTime()
    {
      Main.menuTime.update();
      if (Main.netMode != 1)
        return;
      Main.UpdateTime();
    }

    private void DrawSplash(GameTime dt)
    {
      this.GraphicsDevice.Clear(new Color());
      base.Draw(dt);
      if ((int) this.splashCounter == (int) this.splashDelay + 16 + 16)
      {
        Main.splashTexture[(int) this.splashLogo].Dispose();
        Main.splashTexture[(int) this.splashLogo] = (Texture2D) null;
        this.splashDelay = (short) 120;
        this.splashCounter = (short) 0;
        if ((int) ++this.splashLogo == 4)
        {
          Main.showSplash = (short) 1;
          return;
        }
      }
      ++this.splashCounter;
      Main.spriteBatch.Begin();
      int num = (int) this.splashCounter >= 16 ? ((int) this.splashCounter > 16 + (int) this.splashDelay ? (int) byte.MaxValue - ((int) this.splashCounter - (int) this.splashDelay - 16) * (int) byte.MaxValue / 16 : (int) byte.MaxValue) : (int) this.splashCounter * (int) byte.MaxValue / 16;
      Main.spriteBatch.Draw(Main.splashTexture[(int) this.splashLogo], new Vector2()
      {
        X = (float) (960 - Main.splashTexture[(int) this.splashLogo].Width >> 1),
        Y = (float) (540 - Main.splashTexture[(int) this.splashLogo].Height >> 1)
      }, new Color(num, num, num, num));
      Main.spriteBatch.End();
    }

    public void LoadUpsell()
    {
      if (!this.upsellLoaded)
      {
        this.upsellLoaded = true;
        for (int index = 0; index < 1; ++index)
          Main.splashTexture[index] = this.Content.Load<Texture2D>(string.Concat(new object[4]
          {
            (object) "UI/Upsell/0",
            (object) (index + 1),
            (object) "_",
            (object) Lang.languageId
          }));
      }
      this.splashLogo = (short) 0;
      this.splashCounter = (short) 0;
    }

    public void DrawUpsell()
    {
      ++this.splashCounter;
      int num = (int) this.splashCounter >= 16 ? (int) byte.MaxValue : (int) this.splashCounter * (int) byte.MaxValue / 16;
      Main.spriteBatch.Draw(Main.splashTexture[(int) this.splashLogo], new Vector2()
      {
        X = (float) (960 - Main.splashTexture[(int) this.splashLogo].Width >> 1),
        Y = (float) (540 - Main.splashTexture[(int) this.splashLogo].Height >> 1)
      }, new Color(num, num, num, num));
    }

    protected override void Draw(GameTime dt)
    {
      if ((int) Main.showSplash == 0)
      {
        this.DrawSplash(dt);
      }
      else
      {
        ++Main.renderCount;
        for (int index = 0; index < 4; ++index)
          Main.ui[index].PrepareDraw(Main.renderCount);
        if (Main.renderCount > 4)
        {
          Main.renderCount = 0;
          Lighting.tempLightCount = 0;
        }
        this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        this.GraphicsDevice.Clear(new Color());
        base.Draw(dt);
        for (int index = 0; index < 4; ++index)
          Main.ui[index].Draw();
        WorldView.restoreViewport();
        Main.spriteBatch.Begin();
        for (int index = 0; index < 4; ++index)
        {
          if (Main.ui[index].menuType != MenuType.MAIN)
          {
            Main.DrawChat();
            break;
          }
        }
        if (Main.saveIconCounter > 0 || Main.activeSaves > 0)
        {
          --Main.saveIconCounter;
          SpriteSheet<_sheetSprites>.Draw(642, 878, 479, Color.White, (float) Main.saveIconCounter * 0.05235988f, 1f);
        }
        Main.spriteBatch.End();
      }
    }

    private static void UpdateInvasion()
    {
      if (Main.invasionType <= 0)
        return;
      if (Main.invasionSize <= 0)
      {
        if (Main.invasionType == 1)
        {
          NPC.downedGoblins = true;
          UI.SetTriggerStateForAll(Trigger.KilledGoblinArmy);
          NetMessage.CreateMessage0(7);
          NetMessage.SendMessage();
        }
        else if (Main.invasionType == 2)
          NPC.downedFrost = true;
        Main.InvasionWarning();
        Main.invasionType = 0;
        Main.invasionDelay = 7;
      }
      if ((double) Main.invasionX == (double) Main.spawnTileX)
        return;
      float num = 1f;
      if ((double) Main.invasionX > (double) Main.spawnTileX)
      {
        Main.invasionX -= num;
        if ((double) Main.invasionX <= (double) Main.spawnTileX)
        {
          Main.invasionX = (float) Main.spawnTileX;
          Main.InvasionWarning();
        }
        else
          --Main.invasionWarn;
      }
      else if ((double) Main.invasionX < (double) Main.spawnTileX)
      {
        Main.invasionX += num;
        if ((double) Main.invasionX >= (double) Main.spawnTileX)
        {
          Main.invasionX = (float) Main.spawnTileX;
          Main.InvasionWarning();
        }
        else
          --Main.invasionWarn;
      }
      if (Main.invasionWarn > 0)
        return;
      Main.invasionWarn = 3600;
      Main.InvasionWarning();
    }

    private static void InvasionWarning()
    {
      NetMessage.SendText(Main.invasionSize > 0 ? ((double) Main.invasionX >= (double) Main.spawnTileX ? ((double) Main.invasionX <= (double) Main.spawnTileX ? (Main.invasionType != 2 ? 3 : 7) : (Main.invasionType != 2 ? 2 : 6)) : (Main.invasionType != 2 ? 1 : 5)) : (Main.invasionType != 2 ? 0 : 4), 175, 75, (int) byte.MaxValue, -1);
    }

    public static void StartInvasion(int type = 1)
    {
      if (Main.invasionType != 0 || Main.invasionDelay != 0)
        return;
      int num = 0;
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0 && (int) Main.player[index].statLifeMax >= 200)
          ++num;
      }
      if (num <= 0)
        return;
      Main.invasionType = type;
      Main.invasionSize = 80 + 40 * num;
      Main.invasionWarn = 0;
      if (Main.rand.Next(2) == 0)
        Main.invasionX = 0.0f;
      else
        Main.invasionX = (float) Main.maxTilesX;
    }

    private static void UpdateClient()
    {
      if (Main.isGameStarted)
        ++Main.netPlayCounter;
      Netplay.session.Update();
      NetMessage.CheckBytesClient();
    }

    private static void UpdateServer()
    {
      if (Main.isGameStarted)
      {
        ++Main.netPlayCounter;
        for (int index1 = Netplay.clients.Count - 1; index1 >= 0; --index1)
        {
          NetClient client = Netplay.clients[index1];
          for (int index2 = ((ReadOnlyCollection<NetworkGamer>) client.machine.Gamers).Count - 1; index2 >= 0; --index2)
          {
            Player player = ((ReadOnlyCollection<NetworkGamer>) client.machine.Gamers)[index2].Tag as Player;
            if ((int) player.active != 0)
            {
              int sectionX = (player.aabb.X >> 4) / 40;
              int sectionY = (player.aabb.Y >> 4) / 30;
              NetMessage.SendSection(client, sectionX, sectionY);
              if ((double) player.velocity.X > 0.0)
              {
                if (NetMessage.SendSection(client, sectionX + 1, sectionY) || NetMessage.SendSection(client, sectionX + 1, sectionY - 1) || (NetMessage.SendSection(client, sectionX + 1, sectionY + 1) || NetMessage.SendSection(client, sectionX + 2, sectionY)) || (NetMessage.SendSection(client, sectionX + 2, sectionY - 1) || !NetMessage.SendSection(client, sectionX + 2, sectionY + 1)))
                  ;
              }
              else if ((double) player.velocity.X < 0.0 && !NetMessage.SendSection(client, sectionX - 1, sectionY) && (!NetMessage.SendSection(client, sectionX - 1, sectionY - 1) && !NetMessage.SendSection(client, sectionX - 1, sectionY + 1)) && (!NetMessage.SendSection(client, sectionX - 2, sectionY) && !NetMessage.SendSection(client, sectionX - 2, sectionY - 1)))
                NetMessage.SendSection(client, sectionX - 2, sectionY + 1);
              if ((double) player.velocity.Y > 0.0)
              {
                if (NetMessage.SendSection(client, sectionX, sectionY + 1) || NetMessage.SendSection(client, sectionX + 1, sectionY + 1) || (NetMessage.SendSection(client, sectionX - 1, sectionY + 1) || NetMessage.SendSection(client, sectionX + 2, sectionY + 1)) || !NetMessage.SendSection(client, sectionX - 2, sectionY + 1))
                  ;
              }
              else if ((double) player.velocity.Y < 0.0 && !NetMessage.SendSection(client, sectionX, sectionY - 1) && (!NetMessage.SendSection(client, sectionX + 1, sectionY - 1) && !NetMessage.SendSection(client, sectionX - 1, sectionY - 1)) && !NetMessage.SendSection(client, sectionX + 2, sectionY - 1))
                NetMessage.SendSection(client, sectionX - 2, sectionY - 1);
            }
          }
        }
      }
      try
      {
        Netplay.session.Update();
      }
      catch (Exception ex)
      {
      }
      if (Main.netMode == 0)
      {
        Netplay.CheckOfflineSession();
      }
      else
      {
        NetMessage.CheckBytesServer();
        using (GamerCollection<NetworkGamer>.GamerCollectionEnumerator enumerator = Netplay.session.RemoteGamers.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            NetworkGamer current = enumerator.Current;
            Player player = current.Tag as Player;
            if (player.kill)
            {
              player.kill = false;
              player.active = (byte) 0;
              current.Machine.RemoveFromSession();
            }
          }
        }
      }
    }

    public static void NewText(string newText, int R, int G, int B)
    {
      for (int index = 6; index > 0; --index)
        Main.chatLine[index] = Main.chatLine[index - 1];
      Main.chatLine[0].color = new Color(R, G, B);
      Main.chatLine[0].text = newText;
      Main.chatLine[0].showTime = 600;
      Main.PlaySound(12);
    }

    public static void DrawChat()
    {
      int num1 = 0;
      float num2 = 0.0f;
      for (int index = 0; index < 7; ++index)
      {
        if (Main.chatLine[index].showTime > 0)
        {
          Vector2 vector2 = UI.fontSmallOutline.MeasureString(Main.chatLine[index].text);
          if ((double) vector2.X > (double) num2)
            num2 = vector2.X;
          ++num1;
        }
      }
      if (num1 == 0 || (double) num2 == 0.0)
        return;
      Main.DrawRect(new Rectangle(48, 440 - num1 * 22, (int) num2 + 12, num1 * 22 + 12), new Color(32, 32, 32, 32), true);
      for (int index = 0; index < 7; ++index)
      {
        if (Main.chatLine[index].showTime > 0)
        {
          float num3 = (float) UI.mouseTextBrightness * 0.003921569f;
          Main.spriteBatch.DrawString(UI.fontSmallOutline, Main.chatLine[index].text, new Vector2(54f, (float) (439 - (index + 1) * 22)), new Color((int) (byte) ((double) Main.chatLine[index].color.R * (double) num3), (int) (byte) ((double) Main.chatLine[index].color.G * (double) num3), (int) (byte) ((double) Main.chatLine[index].color.B * (double) num3), (int) UI.mouseTextBrightness));
        }
      }
    }

    private static void UpdateTime()
    {
      bool wasBloodMoon = Main.gameTime.bloodMoon;
      if (Main.gameTime.update())
      {
        WorldGen.spawnNPC = 0;
        NPC.checkForSpawnsTimer = (short) 0;
        if (Main.gameTime.dayTime)
        {
          Time.checkXMas();
          if (Main.invasionDelay > 0)
            --Main.invasionDelay;
          if (Main.netMode != 1)
          {
            if (WorldGen.shadowOrbSmashed && Main.rand.Next(NPC.downedGoblins ? 15 : 3) == 0)
              Main.StartInvasion(1);
            for (int index = 0; index < 8; ++index)
            {
              if ((int) Main.player[index].active != 0)
                Main.player[index].SunMoonTransition(wasBloodMoon);
            }
          }
        }
        else if (Main.netMode != 1)
        {
          if (WorldGen.shadowOrbSmashed && Main.rand.Next(50) == 0)
            WorldGen.spawnMeteor = true;
          if (!NPC.downedBoss1)
          {
            for (int index1 = 0; index1 < 8; ++index1)
            {
              if ((int) Main.player[index1].active != 0 && (int) Main.player[index1].statLifeMax >= 200 && (int) Main.player[index1].statDefense > 10)
              {
                if (Main.rand.Next(3) == 0)
                {
                  int num = 0;
                  for (int index2 = 0; index2 < 196; ++index2)
                  {
                    if (Main.npc[index2].townNPC && (int) Main.npc[index2].active != 0 && ++num >= 4)
                    {
                      WorldGen.spawnEye = true;
                      NetMessage.SendText(9, 50, (int) byte.MaxValue, 130, -1);
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
          if (!WorldGen.spawnEye && (int) Main.gameTime.moonPhase != 4 && Main.rand.Next(9) == 0)
          {
            for (int index = 0; index < 8; ++index)
            {
              if ((int) Main.player[index].active != 0 && (int) Main.player[index].statLifeMax > 120)
              {
                Main.gameTime.bloodMoon = true;
                NetMessage.SendText(8, 50, (int) byte.MaxValue, 130, -1);
                break;
              }
            }
          }
          for (int index = 0; index < 8; ++index)
          {
            if ((int) Main.player[index].active != 0)
              Main.player[index].SunMoonTransition(false);
          }
        }
        if (Main.netMode != 2)
          return;
        NetMessage.CreateMessage0(7);
        NetMessage.SendMessage();
      }
      else if (Main.gameTime.dayTime)
      {
        if (Main.netMode == 1)
          return;
        NPC.checkForTownSpawns();
      }
      else if ((double) Main.gameTime.time > 16200.0)
      {
        if (!WorldGen.spawnMeteor)
          return;
        WorldGen.spawnMeteor = false;
        WorldGen.dropMeteor();
      }
      else
      {
        if ((double) Main.gameTime.time <= 4860.0 || !WorldGen.spawnEye || Main.netMode == 1)
          return;
        for (int index = 0; index < 8; ++index)
        {
          Player p = Main.player[index];
          if ((int) p.active != 0 && !p.dead && p.aabb.Y < Main.worldSurfacePixels)
          {
            NPC.SpawnOnPlayer(p, 4);
            WorldGen.spawnEye = false;
            break;
          }
        }
      }
    }

    public static int DamageVar(int dmg)
    {
      return (int) Math.Round((double) dmg * (1.0 + (double) Main.rand.Next(-15, 16) * 0.01));
    }

    public static double CalculateDamage(int Damage, int Defense)
    {
      double num = (double) Damage - (double) Defense * 0.5;
      if (num < 1.0)
        num = 1.0;
      return num;
    }

    public static void PlaySound(int type, int x, int y, int style = 1)
    {
      if ((double) Main.soundVolume == 0.0)
        return;
      try
      {
        float num1 = Main.soundVolume;
        float num2 = 0.0f;
        bool flag;
        if (UI.numActiveViews > 1)
        {
          flag = WorldView.AnyViewContains(x, y);
        }
        else
        {
          flag = new Rectangle()
          {
            X = (UI.current.view.screenPosition.X - 960),
            Y = (UI.current.view.screenPosition.Y - 540),
            Width = 2880,
            Height = 1620
          }.Contains(x, y);
          if (flag)
          {
            Vector2 vector2 = new Vector2((float) (UI.current.view.screenPosition.X + 480), (float) (UI.current.view.screenPosition.Y + 270));
            float num3 = Math.Abs((float) x - vector2.X);
            float num4 = Math.Abs((float) y - vector2.Y);
            float num5 = (float) (1.0 - Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4) * (1.0 / 640.0));
            if ((double) num5 > 1.0)
              num5 = 1f;
            num1 = num5 * Main.soundVolume;
            if ((double) num1 <= 0.0)
              return;
            num2 = (float) (((double) x - (double) vector2.X) * 0.000520833360496908);
            if ((double) num2 < -1.0)
              num2 = -1f;
            else if ((double) num2 > 1.0)
              num2 = 1f;
          }
        }
        if (!flag)
          return;
        if (type == 0)
        {
          int index = Main.rand.Next(3);
          Main.soundDig[index].Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        }
        else if (type == 1)
        {
          int index = Main.rand.Next(3);
          Main.soundPlayerHit[index].Play((double) num1, (double) num2, 0.0);
        }
        else if (type == 2)
        {
          if (style == 1)
          {
            int num3 = Main.rand.Next(3);
            if (num3 != 0)
              style = num3 + 17;
          }
          double volume = (double) num1;
          double pitch;
          if (style == 26 || style == 35)
          {
            volume *= 0.75;
            pitch = (double) Main.harpNote;
          }
          else
            pitch = (double) Main.rand.Next(-6, 7) * 0.01;
          Main.soundItem[style - 1].Play(volume, (double) num2, pitch);
        }
        else if (type == 3)
          Main.soundNPCHit[style - 1].Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        else if (type == 4)
        {
          if (style == 10 && Main.soundNPCKilled[style - 1].IsPlaying())
            return;
          Main.soundNPCKilled[style - 1].Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        }
        else if (type == 5)
          Main.soundPlayerKilled.Play((double) num1, (double) num2, 0.0);
        else if (type == 6)
          Main.soundGrass.Play((double) num1, (double) num2, (double) Main.rand.Next(-30, 31) * 0.01);
        else if (type == 7)
          Main.soundGrab.Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        else if (type == 8)
          Main.soundDoorOpen.Play((double) num1, (double) num2, (double) Main.rand.Next(-20, 21) * 0.01);
        else if (type == 9)
          Main.soundDoorClosed.Play((double) num1, (double) num2, (double) Main.rand.Next(-20, 21) * 0.01);
        else if (type == 13)
          Main.soundShatter.Play((double) num1, (double) num2, 0.0);
        else if (type == 14)
        {
          int index = Main.rand.Next(3);
          Main.soundZombie[index].Play((double) num1 * 0.4, (double) num2, 0.0);
        }
        else if (type == 15)
        {
          if (Main.soundRoar[style].IsPlaying())
            return;
          Main.soundRoar[style].Play((double) num1, (double) num2, 0.0);
        }
        else if (type == 16)
          Main.soundDoubleJump.Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        else if (type == 17)
          Main.soundRun.Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        else if (type == 19)
          Main.soundSplash[style].Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        else if (type == 20)
        {
          int index = Main.rand.Next(3);
          Main.soundFemaleHit[index].Play((double) num1, (double) num2, 0.0);
        }
        else if (type == 21)
        {
          int index = Main.rand.Next(3);
          Main.soundTink[index].Play((double) num1, (double) num2, 0.0);
        }
        else if (type == 22)
          Main.soundUnlock.Play((double) num1, (double) num2, 0.0);
        else if (type == 26)
        {
          int index = Main.rand.Next(3, 5);
          Main.soundZombie[index].Play((double) num1 * 0.9, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        }
        else if (type == 27)
        {
          Main.soundPixie.UpdateOrPlay((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.01);
        }
        else
        {
          if (type != 28 || Main.soundMech.IsPlaying())
            return;
          Main.soundMech.Play((double) num1, (double) num2, (double) Main.rand.Next(-10, 11) * 0.00999999977648258);
        }
      }
      catch
      {
      }
    }

    public static void PlaySound(int type)
    {
      if ((double) Main.soundVolume == 0.0)
        return;
      try
      {
        float num = Main.soundVolume;
        switch (type)
        {
          case 1:
            int index1 = Main.rand.Next(3);
            Main.soundPlayerHit[index1].Play((double) num, 0.0, 0.0);
            break;
          case 7:
            Main.soundGrab.Play((double) num, 0.0, (double) Main.rand.Next(-10, 11) * 0.01);
            break;
          case 10:
            Main.soundMenuOpen.Play((double) num, 0.0, 0.0);
            break;
          case 11:
            Main.soundMenuClose.Play((double) num, 0.0, 0.0);
            break;
          case 12:
            Main.soundMenuTick.Play((double) num, 0.0, 0.0);
            break;
          case 18:
            Main.soundCoins.Play((double) num, 0.0, 0.0);
            break;
          case 20:
            int index2 = Main.rand.Next(3);
            Main.soundFemaleHit[index2].Play((double) num, 0.0, 0.0);
            break;
          case 23:
            Main.soundDrown.Play((double) num, 0.0, 0.0);
            break;
          case 24:
            Main.soundChat.Play((double) num, 0.0, 0.0);
            break;
          case 25:
            Main.soundMaxMana.Play((double) num, 0.0, 0.0);
            break;
        }
      }
      catch
      {
      }
    }

    private static void UpdateTutorial()
    {
      if (UI.main.menuType != MenuType.NONE)
        return;
      if (Main.tutorialInputDelay > 0)
        --Main.tutorialInputDelay;
      Vector2 leftThumbStick = Main.TutorialMaskLS ? new Vector2() : UI.main.gpState.ThumbSticks.Left;
      Vector2 rightThumbStick = Main.TutorialMaskRS ? new Vector2() : UI.main.gpState.ThumbSticks.Right;
      float leftTrigger = Main.TutorialMaskLT ? 0.0f : UI.main.gpState.Triggers.Left;
      float rightTrigger = Main.TutorialMaskRT ? 0.0f : UI.main.gpState.Triggers.Right;
      Buttons buttons = (Buttons) 0;
      if (!Main.TutorialMaskA && UI.main.gpState.IsButtonDown(Buttons.A))
        buttons |= Buttons.A;
      if (!Main.TutorialMaskB && UI.main.gpState.IsButtonDown(Buttons.B))
        buttons |= Buttons.B;
      if (!Main.TutorialMaskX && UI.main.gpState.IsButtonDown(Buttons.X))
        buttons |= Buttons.X;
      if (!Main.TutorialMaskY && UI.main.gpState.IsButtonDown(Buttons.Y))
        buttons |= Buttons.Y;
      if (!Main.TutorialMaskBack && UI.main.gpState.IsButtonDown(Buttons.Back))
        buttons |= Buttons.Back;
      if (!Main.TutorialMaskLB && UI.main.gpState.IsButtonDown(Buttons.LeftShoulder))
        buttons |= Buttons.LeftShoulder;
      if (!Main.TutorialMaskRB && UI.main.gpState.IsButtonDown(Buttons.RightShoulder))
        buttons |= Buttons.RightShoulder;
      if (!Main.TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadLeft))
        buttons |= Buttons.DPadLeft;
      if (!Main.TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadRight))
        buttons |= Buttons.DPadRight;
      if (!Main.TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadUp))
        buttons |= Buttons.DPadUp;
      if (!Main.TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadDown))
        buttons |= Buttons.DPadDown;
      if (!Main.TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.LeftStick))
        buttons |= Buttons.LeftStick;
      if (!Main.TutorialMaskRSpress && UI.main.gpState.IsButtonDown(Buttons.RightStick))
        buttons |= Buttons.RightStick;
      if (UI.main.gpState.IsButtonDown(Buttons.Start))
        buttons |= Buttons.Start;
      UI.main.gpState = new GamePadState(leftThumbStick, rightThumbStick, leftTrigger, rightTrigger, new Buttons[1]
      {
        buttons
      });
      switch (Main.tutorialState)
      {
        case Tutorial.BACK_WALL_INFO_1:
        case Tutorial.HOUSE_INFO_1:
        case Tutorial.HOUSE_DONE_1:
        case Tutorial.THE_GUIDE_1:
        case Tutorial.HAMMER_1:
        case Tutorial.CONGRATS_1:
        case Tutorial.MINED_ORE_1:
        case Tutorial.CURSOR_SWITCH_1:
        case Tutorial.DAY_NIGHT_1:
        case Tutorial.USE_BENCH_1:
        case Tutorial.INVENTORY_2:
        case Tutorial.MOVEMENT_1:
        case Tutorial.DROP_1:
        case Tutorial.EQUIPSCREEN_1:
        case Tutorial.CHEST_1:
        case Tutorial.CRAFTSCREEN_1:
        case Tutorial.INTRO:
        case Tutorial.MONSTER_INFO_1:
        case Tutorial.POTIONS_1:
        case Tutorial.TORCH_1:
          if (Main.tutorialInputDelay == 0)
          {
            Main.NextTutorial(1);
            break;
          }
          else
            break;
      }
      switch (Main.tutorialState)
      {
        case Tutorial.BACK_WALL_INFO_2:
        case Tutorial.HOUSE_INFO_2:
        case Tutorial.HOUSE_DONE_2:
        case Tutorial.THE_GUIDE_2:
        case Tutorial.HAMMER_2:
        case Tutorial.CONGRATS_2:
        case Tutorial.MINED_ORE_2:
        case Tutorial.CURSOR_SWITCH_2:
        case Tutorial.DAY_NIGHT_2:
        case Tutorial.USE_BENCH_2:
        case Tutorial.INVENTORY_3:
        case Tutorial.MOVEMENT_2:
        case Tutorial.DROP_2:
        case Tutorial.EQUIPSCREEN_2:
        case Tutorial.CHEST_2:
        case Tutorial.CRAFTSCREEN_2:
        case Tutorial.INTRO_2:
        case Tutorial.MONSTER_INFO_2:
        case Tutorial.POTIONS_2:
        case Tutorial.TORCH_2:
          if (!UI.main.IsButtonTriggered(Buttons.B))
            break;
          UI.main.ClearButtonTriggers();
          Main.TutorialMaskB = (int) Main.tutorialVar != 0;
          Main.NextTutorial(1);
          break;
        default:
          Player player = UI.main.player;
          switch (Main.tutorialState)
          {
            case Tutorial.MOVE:
              if ((double) UI.main.gpState.ThumbSticks.Left.LengthSquared() > 1.0 / 64.0)
                ++Main.tutorialVar;
              if (Main.tutorialVar <= 4U || Main.tutorialInputDelay != 0)
                return;
              UI.main.AchievementTriggers.SetState(Trigger.FirstTutorialTaskCompleted, true);
              Main.NextTutorial(1);
              return;
            case Tutorial.JUMP:
              if (UI.main.totalJumps - Main.tutorialVar < 1U)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.FALL_DOWN:
              if (!player.controlDown)
                return;
              int index1 = (int) player.position.X + 10 >> 4;
              int num1 = (int) player.position.Y + 42 >> 4;
              if ((int) Main.tile[index1, num1 - 1].type != 19 && (int) Main.tile[index1 - 1, num1 - 1].type != 19 && (int) Main.tile[index1 + 1, num1 - 1].type != 19)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.JUMP_OUT:
              if (UI.main.totalJumps - Main.tutorialVar < 1U)
                return;
              int index2 = (int) player.position.X + 10 >> 4;
              int num2 = (int) player.position.Y + 42 >> 4;
              if ((int) Main.tile[index2, num2 + 1].type != 19 && (int) Main.tile[index2 - 1, num2 + 1].type != 19 && (int) Main.tile[index2 + 1, num2 + 1].type != 19)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.CURSOR:
              if ((double) UI.main.gpState.ThumbSticks.Right.LengthSquared() > 1.0 / 64.0)
                ++Main.tutorialVar;
              if (UI.main.IsButtonTriggered(Buttons.RightTrigger))
                ++Main.tutorialVar2;
              if (Main.tutorialInputDelay != 0 || Main.tutorialVar <= 0U || Main.tutorialVar2 <= 0U)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.HOTBAR:
              if (Main.tutorialInputDelay != 0 || (int) player.selectedItem != 0)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.SWORD_ATTACK:
              if (UI.main.totalSlimes > Main.tutorialVar)
              {
                Item.NewItem((int) player.position.X, (int) player.position.Y, 1, 1, 23, 1, false, 0);
                Main.NextTutorial(1);
                return;
              }
              else
              {
                if (Main.tutorialVar2 <= 0U || (int) --Main.tutorialVar2 != 0)
                  return;
                Main.tutorialVar2 = 900U;
                int index3 = NPC.NewNPC(player.aabb.X - 480, player.aabb.Y - 540, 1, 0);
                Main.npc[index3].SetDefaults("Green Slime");
                return;
              }
            case Tutorial.MONSTER_INFO_1:
              return;
            case Tutorial.MONSTER_INFO_2:
              return;
            case Tutorial.POTIONS_1:
              return;
            case Tutorial.POTIONS_2:
              return;
            case Tutorial.TORCH_1:
              return;
            case Tutorial.TORCH_2:
              return;
            case Tutorial.SELECT_AXE:
              if (Main.tutorialInputDelay != 0 || (int) player.inventory[(int) player.selectedItem].axe <= 0)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.USE_AXE:
              if (UI.main.totalChops <= Main.tutorialVar)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.INVENTORY:
              if ((int) UI.main.inventoryMode != 1)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.INVENTORY_2:
              return;
            case Tutorial.INVENTORY_3:
              return;
            case Tutorial.MOVEMENT_1:
              return;
            case Tutorial.MOVEMENT_2:
              return;
            case Tutorial.DROP_1:
              return;
            case Tutorial.DROP_2:
              return;
            case Tutorial.EQUIPMENT:
              if (UI.main.inventorySection != UI.InventorySection.EQUIP)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.EQUIPSCREEN_1:
              return;
            case Tutorial.EQUIPSCREEN_2:
              return;
            case Tutorial.CHEST_1:
              return;
            case Tutorial.CHEST_2:
              return;
            case Tutorial.CRAFTING:
              if (UI.main.inventorySection != UI.InventorySection.CRAFTING)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.CRAFT_TORCH:
              if (UI.main.totalTorchesCrafted <= Main.tutorialVar)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.CRAFTSCREEN_1:
              return;
            case Tutorial.CRAFTSCREEN_2:
              return;
            case Tutorial.CRAFT_CATEGORIES:
              if (UI.main.IsButtonTriggered(Buttons.LeftTrigger) || UI.main.IsButtonTriggered(Buttons.RightTrigger))
                ++Main.tutorialVar;
              if (Main.tutorialVar <= 0U || Main.tutorialInputDelay != 0)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.CRAFTING_EXIT:
              if ((int) UI.main.inventoryMode != 0)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.SELECT_PICK:
              if (Main.tutorialInputDelay != 0 || (int) player.inventory[(int) player.selectedItem].pick <= 0)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.USE_PICK:
              if (UI.main.totalCopper - Main.tutorialVar < 55U)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.MINED_ORE_1:
              return;
            case Tutorial.MINED_ORE_2:
              return;
            case Tutorial.WOOD_PLATFORM:
              if (UI.main.totalWoodPlatformsCrafted - Main.tutorialVar >= 5U)
              {
                Main.NextTutorial(2);
                return;
              }
              else
              {
                if ((int) --Main.tutorialVar2 != 0)
                  return;
                Main.NextTutorial(1);
                return;
              }
            case Tutorial.WOOD_PLATFORM_TIME_OUT:
              if (UI.main.totalWoodPlatformsCrafted - Main.tutorialVar < 5U)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.SELECT_PLATFORM:
              if (Main.tutorialInputDelay != 0 || (int) player.inventory[(int) player.selectedItem].type != 94)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.BUILD_CURSOR:
              if (Main.tutorialInputDelay != 0 || UI.main.smartCursor)
                return;
              Main.TutorialMaskRSpress = true;
              Main.NextTutorial(1);
              return;
            case Tutorial.PLACING_1:
              if (UI.main.totalWoodPlatformsPlaced <= Main.tutorialVar)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.PLACING_2:
              if (player.aabb.Y >= 3360)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.CURSOR_SWITCH_1:
              return;
            case Tutorial.CURSOR_SWITCH_2:
              return;
            case Tutorial.DAY_NIGHT_1:
              return;
            case Tutorial.DAY_NIGHT_2:
              return;
            case Tutorial.BUILD_HOUSE:
              if (Main.tutorialInputDelay == 0)
              {
                Main.NextTutorial(1);
                goto case Tutorial.BUILD_HOUSE_EXTRA_INFO;
              }
              else
                goto case Tutorial.BUILD_HOUSE_EXTRA_INFO;
            case Tutorial.BUILD_HOUSE_EXTRA_INFO:
              if (((int) Main.frameCounter & 31) != 0)
                return;
              int x = (int) UI.main.mouseX + UI.main.view.screenPosition.X >> 4;
              int y = (int) UI.main.mouseY + UI.main.view.screenPosition.Y >> 4;
              bool flag = WorldGen.StartSpaceCheck(x, y);
              if (!flag)
              {
                --x;
                flag = WorldGen.StartSpaceCheck(x, y);
                if (!flag)
                {
                  x += 2;
                  flag = WorldGen.StartSpaceCheck(x, y);
                }
                if (!flag)
                {
                  --x;
                  ++y;
                  flag = WorldGen.StartSpaceCheck(x, y);
                }
              }
              if (!flag)
                return;
              Main.tutorialHouse.X = (short) x;
              Main.tutorialHouse.Y = (short) y;
              Main.NextTutorial(Main.tutorialState == Tutorial.BUILD_HOUSE ? 2 : 1);
              return;
            case Tutorial.BUILD_HOUSE_2:
              if (Main.tutorialInputDelay == 0)
              {
                Main.NextTutorial(1);
                goto case Tutorial.BUILD_HOUSE_2_EXTRA_INFO;
              }
              else
                goto case Tutorial.BUILD_HOUSE_2_EXTRA_INFO;
            case Tutorial.BUILD_HOUSE_2_EXTRA_INFO:
              if (((int) Main.frameCounter & 31) != 0 || UI.main.totalAxed - Main.tutorialVar < 3U && UI.main.totalPicked - Main.tutorialVar2 < 3U || WorldGen.StartSpaceCheck((int) Main.tutorialHouse.X, (int) Main.tutorialHouse.Y))
                return;
              Main.NextTutorial(Main.tutorialState == Tutorial.BUILD_HOUSE_2 ? 2 : 1);
              return;
            case Tutorial.CRAFT_WORKBENCH:
            case Tutorial.CRAFT_WORKBENCH_EXTRA_INFO:
              if (((int) Main.frameCounter & 31) != 0)
                return;
              int num3 = (int) player.position.X + 10 >> 4;
              int num4 = ((int) player.position.Y + 42 >> 4) - 1;
              for (int index3 = num3 - 5; index3 < num3 + 5; ++index3)
              {
                for (int index4 = num4 - 5; index4 < num4 + 5; ++index4)
                {
                  if ((int) Main.tile[index3, index4].type == 18)
                  {
                    Main.NextTutorial(Main.tutorialState == Tutorial.CRAFT_WORKBENCH ? 2 : 1);
                    return;
                  }
                }
              }
              return;
            case Tutorial.USE_BENCH_1:
              return;
            case Tutorial.USE_BENCH_2:
              return;
            case Tutorial.CRAFT_DOOR:
            case Tutorial.CRAFT_DOOR_EXTRA_INFO:
              if (Main.tutorialInputDelay != 0 || !player.hasItemInInventory(25))
                return;
              Main.NextTutorial(Main.tutorialState == Tutorial.CRAFT_DOOR ? 2 : 1);
              return;
            case Tutorial.PLACE_DOOR:
              if (((int) Main.frameCounter & 31) != 0 || !WorldGen.StartSpaceCheck((int) Main.tutorialHouse.X, (int) Main.tutorialHouse.Y) || !WorldGen.houseTile[10] && !WorldGen.houseTile[11])
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.USE_DOOR:
              if (Main.tutorialInputDelay != 0 || UI.main.totalDoorsOpened <= Main.tutorialVar && UI.main.totalDoorsClosed <= Main.tutorialVar2)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.BACK_WALL_INFO_1:
              return;
            case Tutorial.BACK_WALL_INFO_2:
              return;
            case Tutorial.CRAFT_WALL:
            case Tutorial.CRAFT_WALL_EXTRA_INFO:
              if (Main.tutorialInputDelay != 0 || UI.main.totalWallsCrafted - Main.tutorialVar < 32U)
                return;
              Main.NextTutorial(Main.tutorialState == Tutorial.CRAFT_WALL ? 2 : 1);
              return;
            case Tutorial.PLACE_WALL:
              if (Main.tutorialInputDelay != 0 || UI.main.totalWallsPlaced - Main.tutorialVar < 8U)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.BACK_WALL:
              if (((int) Main.frameCounter & 31) != 0 || !WorldGen.StartRoomCheck((int) Main.tutorialHouse.X, (int) Main.tutorialHouse.Y))
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.HOUSE_INFO_1:
              return;
            case Tutorial.HOUSE_INFO_2:
              return;
            case Tutorial.PLACE_CHAIR:
              if (((int) Main.frameCounter & 31) != 0 || !WorldGen.StartRoomCheck((int) Main.tutorialHouse.X, (int) Main.tutorialHouse.Y))
                return;
              WorldGen.RoomNeeds();
              if (!WorldGen.roomChair)
                return;
              Main.NextTutorial(1);
              return;
            case Tutorial.PLACE_TORCH:
              if (((int) Main.frameCounter & 31) != 0 || !WorldGen.StartRoomCheck((int) Main.tutorialHouse.X, (int) Main.tutorialHouse.Y) || !WorldGen.RoomNeeds())
                return;
              Main.NextTutorial(1);
              return;
            default:
              return;
          }
      }
    }

    private static void NextTutorial(int steps = 1)
    {
      if (Main.tutorialState >= Tutorial.THE_END)
        return;
      Main.SetTutorial(Main.tutorialState + steps);
    }

    public static void SetTutorial(Tutorial t)
    {
      Main.tutorialState = t;
      if (t == Tutorial.NUM_TUTORIALS)
      {
        Main.TutorialMaskLS = false;
        Main.TutorialMaskRS = false;
        Main.TutorialMaskRSpress = false;
        Main.TutorialMaskA = false;
        Main.TutorialMaskB = false;
        Main.TutorialMaskX = false;
        Main.TutorialMaskY = false;
        Main.TutorialMaskLB = false;
        Main.TutorialMaskRB = false;
        Main.TutorialMaskLT = false;
        Main.TutorialMaskRT = false;
        Main.TutorialMaskBack = false;
      }
      else
      {
        Main.tutorialInputDelay = 180;
        string text = Lang.tutorial(t);
        Player player = UI.main.player;
        switch (t)
        {
          case Tutorial.INTRO:
            Main.TutorialMaskLS = true;
            Main.TutorialMaskRS = true;
            Main.TutorialMaskRSpress = true;
            Main.TutorialMaskA = true;
            Main.TutorialMaskB = true;
            Main.TutorialMaskX = true;
            Main.TutorialMaskY = true;
            Main.TutorialMaskLB = true;
            Main.TutorialMaskRB = true;
            Main.TutorialMaskLT = true;
            Main.TutorialMaskRT = true;
            Main.TutorialMaskBack = true;
            UI.main.smartCursor = true;
            break;
          case Tutorial.INTRO_2:
          case Tutorial.MONSTER_INFO_2:
          case Tutorial.POTIONS_2:
          case Tutorial.TORCH_2:
          case Tutorial.INVENTORY_3:
          case Tutorial.MOVEMENT_2:
          case Tutorial.DROP_2:
          case Tutorial.EQUIPSCREEN_2:
          case Tutorial.CHEST_2:
          case Tutorial.CRAFTSCREEN_2:
          case Tutorial.MINED_ORE_2:
          case Tutorial.CURSOR_SWITCH_2:
          case Tutorial.DAY_NIGHT_2:
          case Tutorial.USE_BENCH_2:
          case Tutorial.BACK_WALL_INFO_2:
          case Tutorial.HOUSE_INFO_2:
          case Tutorial.HOUSE_DONE_2:
          case Tutorial.THE_GUIDE_2:
          case Tutorial.HAMMER_2:
          case Tutorial.CONGRATS_2:
            text = Lang.tutorial(t - 1) + text;
            Main.tutorialVar = Main.TutorialMaskB ? 1U : 0U;
            Main.TutorialMaskB = false;
            break;
          case Tutorial.MOVE:
            Main.TutorialMaskLS = false;
            Main.tutorialVar = 0U;
            break;
          case Tutorial.JUMP:
            Main.TutorialMaskA = false;
            Main.tutorialVar = UI.main.totalJumps;
            break;
          case Tutorial.JUMP_OUT:
            Main.tutorialVar = UI.main.totalJumps;
            break;
          case Tutorial.CURSOR:
            Main.TutorialMaskRT = false;
            Main.TutorialMaskRS = false;
            Main.tutorialVar = 0U;
            Main.tutorialVar2 = 0U;
            break;
          case Tutorial.HOTBAR:
            Main.TutorialMaskLB = false;
            Main.TutorialMaskRB = false;
            break;
          case Tutorial.SWORD_ATTACK:
            Main.tutorialVar = UI.main.totalSlimes;
            Main.tutorialVar2 = 120U;
            break;
          case Tutorial.MONSTER_INFO_1:
            for (int index = 195; index >= 0; --index)
            {
              if ((int) Main.npc[index].type == 1 && (int) Main.npc[index].active != 0)
              {
                Main.npc[index].HitEffect(0, 999.0);
                Main.npc[index].active = (byte) 0;
              }
            }
            break;
          case Tutorial.USE_AXE:
            Main.tutorialVar = UI.main.totalChops;
            break;
          case Tutorial.INVENTORY:
            Main.TutorialMaskY = false;
            Main.TutorialMaskB = true;
            break;
          case Tutorial.INVENTORY_2:
            Main.TutorialMaskLB = true;
            Main.TutorialMaskRB = true;
            break;
          case Tutorial.EQUIPMENT:
            Main.TutorialMaskRB = false;
            Main.TutorialMaskLB = false;
            Main.TutorialMaskRT = false;
            Main.TutorialMaskLT = false;
            break;
          case Tutorial.CRAFT_TORCH:
            Main.TutorialMaskX = false;
            Main.tutorialVar = UI.main.totalTorchesCrafted;
            break;
          case Tutorial.CRAFT_CATEGORIES:
            Main.tutorialVar = 0U;
            break;
          case Tutorial.CRAFTING_EXIT:
            Main.TutorialMaskB = false;
            break;
          case Tutorial.USE_PICK:
            Main.tutorialVar = UI.main.totalCopper;
            break;
          case Tutorial.WOOD_PLATFORM:
            Main.tutorialVar = UI.main.totalWoodPlatformsCrafted;
            Main.tutorialVar2 = 600U;
            break;
          case Tutorial.BUILD_CURSOR:
            Main.TutorialMaskRSpress = false;
            break;
          case Tutorial.PLACING_1:
            Main.tutorialVar = UI.main.totalWoodPlatformsPlaced;
            break;
          case Tutorial.PLACING_2:
            text = Lang.tutorial(t - 1) + text;
            break;
          case Tutorial.CURSOR_SWITCH_1:
            Main.TutorialMaskRSpress = false;
            break;
          case Tutorial.BUILD_HOUSE:
            Main.tutorialInputDelay = 1800;
            break;
          case Tutorial.BUILD_HOUSE_EXTRA_INFO:
          case Tutorial.BUILD_HOUSE_2_EXTRA_INFO:
            text = Lang.tutorial(t - 1) + text;
            break;
          case Tutorial.BUILD_HOUSE_2:
            Main.tutorialVar = UI.main.totalAxed;
            Main.tutorialVar2 = UI.main.totalPicked;
            Main.tutorialInputDelay = 600;
            break;
          case Tutorial.CRAFT_WORKBENCH:
            if (player.CountInventory(9) < 10)
            {
              Main.tutorialState = t + 1;
              text = text + Lang.tutorial(Main.tutorialState);
              break;
            }
            else
              break;
          case Tutorial.CRAFT_DOOR:
            if (player.CountInventory(9) < 6)
            {
              Main.tutorialState = t + 1;
              text = text + Lang.tutorial(Main.tutorialState);
              break;
            }
            else
              break;
          case Tutorial.USE_DOOR:
            Main.tutorialVar = UI.main.totalDoorsOpened;
            Main.tutorialVar2 = UI.main.totalDoorsClosed;
            break;
          case Tutorial.CRAFT_WALL:
            Main.tutorialVar = UI.main.totalWallsCrafted;
            if (player.CountInventory(9) < 6)
            {
              Main.tutorialState = t + 1;
              text = text + Lang.tutorial(Main.tutorialState);
              break;
            }
            else
              break;
          case Tutorial.PLACE_WALL:
            Main.tutorialVar = UI.main.totalWallsPlaced;
            break;
          case Tutorial.THE_END:
            Main.gameTime.dayRate = 1f;
            UI.main.AchievementTriggers.SetState(Trigger.AllTutorialTasksCompleted, true);
            break;
        }
        if (text != null)
          Main.tutorialText = new CompiledText(text, 470, UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
        else
          Main.tutorialText = (CompiledText) null;
      }
    }

    public static bool IsTutorial()
    {
      return Main.tutorialState != Tutorial.NUM_TUTORIALS;
    }

    public static void StartTutorial()
    {
      Player player = new Player();
      player.name = UI.main.signedInGamer.Gamertag;
      player.selectedItem = (sbyte) 1;
      UI.main.createCharacterGUI.Randomize(player);
      UI.main.setPlayer(player);
      Main.SetTutorial(Tutorial.INTRO);
      WorldGen.playWorld();
    }

    public static void StartGame()
    {
      UI ui = UI.main;
      Main.PlaySound(11);
      for (int index = 0; index < 7; ++index)
        Main.chatLine[index].Init();
      for (int index = 0; index < 8; ++index)
      {
        if (index != (int) ui.myPlayer)
          Main.player[index].active = (byte) 0;
        Main.player[index].announced = false;
      }
      if (Main.IsTutorial())
        GamerPresenceExtensions.SetPresenceModeString(UI.main.signedInGamer.Presence, "Tutorial");
      else if (ui.isOnline)
      {
        Main.netMode = 2;
        GamerPresenceExtensions.SetPresenceModeString(ui.signedInGamer.Presence, "Online");
      }
      else
        GamerPresenceExtensions.SetPresenceModeString(ui.signedInGamer.Presence, "Offline");
      Netplay.StartServer();
      Main.musicBox = -1;
      Main.gameTime = WorldGen.tempTime;
      ui.InitGame();
      Netplay.sessionReadyEvent.WaitOne();
      ui.player.Spawn();
      ui.menuType = MenuType.NONE;
      ui.view.onStartGame();
      MiniMap.onStartGame();
      GC.Collect();
      Main.isGameStarted = true;
    }

    public static void JoinGame(UI startUI)
    {
      GamerPresenceExtensions.SetPresenceModeString(startUI.signedInGamer.Presence, Main.netMode == 0 ? "Offline" : "Online");
      Main.PlaySound(11);
      startUI.InitGame();
      startUI.player.Spawn();
      if (Main.netMode == 2)
        NetMessage.syncPlayer((int) startUI.myPlayer);
      startUI.menuType = MenuType.NONE;
      startUI.view.onStartGame();
      MiniMap.onStartGame();
      Main.isGameStarted = true;
    }

    public static void DrawSolidRect(Rectangle rect, Color color)
    {
      Main.spriteBatch.Draw(Main.whiteTexture, rect, color);
    }

    public static void DrawSolidRect(ref Rectangle rect, Color color)
    {
      Main.spriteBatch.Draw(Main.whiteTexture, rect, color);
    }

    public static void DrawRect(int texId, Rectangle rect, int alpha, int shift = 0)
    {
      Rectangle s = new Rectangle();
      Rectangle dest = rect;
      Vector2 pos = new Vector2();
      Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
      s.X = s.Y = 8;
      s.Width = s.Height = 36;
      pos.X = (float) (rect.X - 8);
      pos.Y = (float) (rect.Y - 8);
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 9;
      s.Y = 0;
      s.Width = 34;
      s.Height = 8;
      dest.Y -= 8;
      dest.Height = 8;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.Y = 44;
      dest.Y = rect.Y + rect.Height;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.Width = 8;
      s.Y = 0;
      s.X = 0;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      s.Y = 44;
      pos.Y = (float) (rect.Y + rect.Height);
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      pos.X = (float) (rect.X + rect.Width);
      s.X = 44;
      s.Y = 44;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      pos.Y = (float) (rect.Y - 8);
      s.Y = 0;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      s.Height = 34;
      s.Y = 9;
      dest.Width = 8;
      dest.Height = rect.Height;
      dest.X += rect.Width;
      dest.Y = rect.Y;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 0;
      dest.X = rect.X - 8;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
    }

    public static void DrawRectStraightBottom(int texId, Rectangle rect, int alpha, int shift = 0)
    {
      Rectangle s = new Rectangle();
      Rectangle dest = rect;
      Vector2 pos = new Vector2();
      Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
      s.X = s.Y = 8;
      s.Width = s.Height = 36;
      pos.X = (float) (rect.X - 8);
      pos.Y = (float) (rect.Y - 8);
      dest.Height += 7;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 9;
      s.Y = 0;
      s.Width = 34;
      s.Height = 8;
      dest.Y -= 8;
      dest.Height = 8;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.Y = 51;
      s.Height = 1;
      dest.X -= 7;
      dest.Y = rect.Y + rect.Height + 7;
      dest.Width += 14;
      dest.Height = 1;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.Width = 8;
      s.Height = 8;
      s.Y = 0;
      s.X = 0;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      pos.X = (float) (rect.X + rect.Width);
      pos.Y = (float) (rect.Y - 8);
      s.X = 44;
      s.Y = 0;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      s.Height = 34;
      s.Y = 9;
      dest.Width = 8;
      dest.Height = rect.Height + 8;
      dest.X = rect.X + rect.Width;
      dest.Y = rect.Y;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 0;
      dest.X = rect.X - 8;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
    }

    public static void DrawRectOpenAtBottom(int texId, Rectangle rect, int alpha, int shift = 0)
    {
      Rectangle s = new Rectangle();
      Rectangle dest = rect;
      Vector2 pos = new Vector2();
      Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
      s.X = s.Y = 8;
      s.Width = 36;
      s.Height = 36;
      dest.Height += 8;
      pos.X = (float) (rect.X - 8);
      pos.Y = (float) (rect.Y - 8);
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 9;
      s.Y = 0;
      s.Width = 34;
      s.Height = 8;
      dest.Y -= 8;
      dest.Height = 8;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.Width = 8;
      s.Y = 0;
      s.X = 0;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      pos.X = (float) (rect.X + rect.Width);
      pos.Y = (float) (rect.Y - 8);
      s.X = 44;
      s.Y = 0;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      s.Height = 34;
      s.Y = 9;
      dest.Width = 8;
      dest.Height = rect.Height + 8;
      dest.X += rect.Width;
      dest.Y = rect.Y;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 0;
      dest.X = rect.X - 8;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
    }

    public static void DrawRectOpenAtTop(int texId, Rectangle rect, int alpha, int shift = 0)
    {
      Rectangle s = new Rectangle();
      Rectangle dest = rect;
      Vector2 pos = new Vector2();
      Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
      s.X = s.Y = 8;
      s.Width = s.Height = 36;
      pos.X = (float) (rect.X - 8);
      pos.Y = (float) (rect.Y - 8);
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 9;
      s.Width = 34;
      s.Height = 8;
      dest.Height = 8;
      s.Y = 44;
      dest.Y = rect.Y + rect.Height;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.Width = 8;
      s.X = 0;
      s.Y = 44;
      pos.Y = (float) (rect.Y + rect.Height);
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      pos.X = (float) (rect.X + rect.Width);
      s.X = 44;
      s.Y = 44;
      SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
      s.Height = 34;
      s.Y = 9;
      dest.Width = 8;
      dest.Height = rect.Height;
      dest.X += rect.Width;
      dest.Y = rect.Y;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
      s.X = 0;
      dest.X = rect.X - 8;
      SpriteSheet<_sheetSprites>.DrawStretched(texId, s, ref dest, c);
    }

    public static void DrawRect(Rectangle rect, Color color, bool center = true)
    {
      rect.X += 2;
      rect.Y += 2;
      rect.Width -= 4;
      rect.Height -= 4;
      if (center)
      {
        Main.spriteBatch.Draw(Main.whiteTexture, rect, color);
        color.A >>= 3;
      }
      Rectangle destinationRectangle = rect;
      destinationRectangle.Y -= 2;
      destinationRectangle.Height = 2;
      Main.spriteBatch.Draw(Main.whiteTexture, destinationRectangle, color);
      destinationRectangle.X -= 2;
      destinationRectangle.Y += 2;
      destinationRectangle.Height = rect.Height;
      destinationRectangle.Width = 2;
      Main.spriteBatch.Draw(Main.whiteTexture, destinationRectangle, color);
      destinationRectangle.X += rect.Width + 2;
      Main.spriteBatch.Draw(Main.whiteTexture, destinationRectangle, color);
      destinationRectangle.X = rect.X;
      destinationRectangle.Y += rect.Height;
      destinationRectangle.Width = rect.Width;
      destinationRectangle.Height = 2;
      Main.spriteBatch.Draw(Main.whiteTexture, destinationRectangle, color);
    }

    public static void ShowSaveIcon()
    {
      if (Main.saveIconCounter <= 0)
        Main.saveIconCounter = 180;
      ++Main.activeSaves;
    }

    public static void HideSaveIcon()
    {
      --Main.activeSaves;
    }

    public static bool IsSaveIconVisible()
    {
      if (Main.saveIconCounter <= 0)
        return Main.activeSaves > 0;
      else
        return true;
    }

    private void Quit()
    {
      Netplay.disconnect = true;
      this.Exit();
    }

    private static void SignedInGamer_SignedIn(object sender, SignedInEventArgs e)
    {
      SignedInGamer gamer = e.Gamer;
      Main.isTrial = Guide.IsTrialMode;
      Main.checkUserGeneratedContent = true;
    }

    private static void SignedInGamer_SignedOut(object sender, SignedOutEventArgs e)
    {
      PlayerIndex playerIndex = e.Gamer.PlayerIndex;
      Main.ui[(int) playerIndex].SignOut();
    }

    public enum Music : byte
    {
      MUSIC_1 = (byte) 0,
      MUSIC_2 = (byte) 1,
      MUSIC_3 = (byte) 2,
      MUSIC_4 = (byte) 3,
      MUSIC_5 = (byte) 4,
      MUSIC_6 = (byte) 5,
      MUSIC_7 = (byte) 6,
      MUSIC_8 = (byte) 7,
      MUSIC_9 = (byte) 8,
      MUSIC_10 = (byte) 9,
      MUSIC_11 = (byte) 10,
      MUSIC_12 = (byte) 11,
      MUSIC_13 = (byte) 12,
      DESERT = (byte) 13,
      FLOATING_ISLAND = (byte) 14,
      TUTORIAL = (byte) 15,
      BOSS4 = (byte) 16,
      OCEAN = (byte) 17,
      SNOW = (byte) 18,
      NONE = (byte) 19,
      NUM_SONGS = (byte) 19,
    }
  }
}
