using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Terraria.Achievements;

namespace Terraria;

public sealed class Main : Game
{
	public enum Music : byte
	{
		MUSIC_1 = 0,
		MUSIC_2 = 1,
		MUSIC_3 = 2,
		MUSIC_4 = 3,
		MUSIC_5 = 4,
		MUSIC_6 = 5,
		MUSIC_7 = 6,
		MUSIC_8 = 7,
		MUSIC_9 = 8,
		MUSIC_10 = 9,
		MUSIC_11 = 10,
		MUSIC_12 = 11,
		MUSIC_13 = 12,
		DESERT = 13,
		FLOATING_ISLAND = 14,
		TUTORIAL = 15,
		BOSS4 = 16,
		OCEAN = 17,
		SNOW = 18,
		NUM_SONGS = 19,
		NONE = 19
	}

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

	private static readonly string[] CUE_NAMES = new string[19]
	{
		"Music_1", "Music_2", "Music_3", "Music_4", "Music_5", "Music_6", "Music_7", "Music_8", "Music_9", "Music_10",
		"Music_11", "Music_12", "Music_13", "Desert", "FloatingIsland", "Tutorial", "Boss4", "Ocean", "Snow"
	};

	private static readonly Music[] MUSIC_BOX_TO_SONG = new Music[19]
	{
		Music.MUSIC_1,
		Music.MUSIC_2,
		Music.MUSIC_3,
		Music.MUSIC_6,
		Music.MUSIC_4,
		Music.MUSIC_5,
		Music.MUSIC_7,
		Music.MUSIC_8,
		Music.MUSIC_10,
		Music.MUSIC_9,
		Music.MUSIC_12,
		Music.MUSIC_11,
		Music.MUSIC_13,
		Music.DESERT,
		Music.FLOATING_ISLAND,
		Music.TUTORIAL,
		Music.BOSS4,
		Music.OCEAN,
		Music.SNOW
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

	public static Thread worldGenThread;

	public static int musicBox = -1;

	public static float musicVolume = 0.75f;

	public static float soundVolume = 1f;

	private Thread loadingThread;

	public static float harpNote = 0f;

	public static bool[] projHostile = new bool[120];

	public static Recipe[] recipe = new Recipe[342];

	public static Chest[] shop = new Chest[10];

	public static int renderCount = 0;

	private static GraphicsDeviceManager graphics;

	public static SpriteBatch spriteBatch;

	public static StringBuilder strBuilder = new StringBuilder(4096, 4096);

	public static bool isGameStarted = false;

	public static bool isGamePaused = false;

	public static bool hardMode = false;

	public static int DiscoStyle = 0;

	public static Vector3 DiscoRGB = new Vector3(1f, 0f, 0f);

	public static uint frameCounter = 0u;

	public static int magmaBGFrame = 0;

	public static int rightWorld = 80640;

	public static int bottomWorld = 23040;

	public static short maxTilesX = 5040;

	public static short maxTilesY = 1440;

	public static int maxSectionsX = maxTilesX / 40;

	public static int maxSectionsY = maxTilesY / 30;

	public static string[] tileName = new string[135];

	public static short dungeonX;

	public static short dungeonY;

	public static Liquid[] liquid = new Liquid[4096];

	public static LiquidBuffer[] liquidBuffer = new LiquidBuffer[8192];

	public static Music curMusic = Music.NUM_SONGS;

	public static Music newMusic = Music.NUM_SONGS;

	public static string worldName;

	public static int worldID;

	public static int worldTimestamp;

	public static bool checkWorldId = false;

	public static bool checkUserGeneratedContent = false;

	public static int worldSurface = 360;

	public static int worldSurfacePixels = worldSurface << 4;

	public static int rockLayer;

	public static int rockLayerPixels;

	public static int magmaLayer;

	public static int magmaLayerPixels;

	public static Color[] teamColor = new Color[5];

	public static Time gameTime = default(Time);

	public static Time menuTime = default(Time);

	public static float demonTorch = 1f;

	public static float demonTorchDir = -0.01f;

	public static FastRandom rand = new FastRandom();

	public static Texture2D whiteTexture;

	public static SfxInstancePool soundMech;

	public static SfxInstancePool[] soundDig = new SfxInstancePool[3];

	public static SfxInstancePool[] soundTink = new SfxInstancePool[3];

	public static SfxInstancePool[] soundPlayerHit = new SfxInstancePool[3];

	public static SfxInstancePool[] soundFemaleHit = new SfxInstancePool[3];

	public static SfxInstancePool soundPlayerKilled;

	public static SfxInstancePool soundGrass;

	public static SfxInstancePool soundGrab;

	public static SfxInstancePool soundPixie;

	public static SfxInstancePool[] soundItem = new SfxInstancePool[37];

	public static SfxInstancePool[] soundNPCHit = new SfxInstancePool[11];

	public static SfxInstancePool[] soundNPCKilled = new SfxInstancePool[15];

	public static SfxInstancePool soundDoorOpen;

	public static SfxInstancePool soundDoorClosed;

	public static SfxInstancePool soundMenuOpen;

	public static SfxInstancePool soundMenuClose;

	public static SfxInstancePool soundMenuTick;

	public static SfxInstancePool soundShatter;

	public static SfxInstancePool[] soundZombie = new SfxInstancePool[5];

	public static SfxInstancePool[] soundRoar = new SfxInstancePool[2];

	public static SfxInstancePool[] soundSplash = new SfxInstancePool[2];

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

	public static DustPool dust = new DustPool(null, 256);

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

	public static short spawnTileX;

	public static short spawnTileY;

	public static bool hasFocus = true;

	public static int invasionType = 0;

	public static float invasionX = 0f;

	public static int invasionSize = 0;

	public static int invasionDelay = 0;

	public static int invasionWarn = 0;

	public static int netMode = 0;

	public static int netPlayCounter;

	public static int lastItemUpdate;

	private static int saveIconCounter = 0;

	private static int activeSaves = 0;

	public static bool saveOnExit;

	private static Texture2D[] splashTexture = new Texture2D[4];

	private static short showSplash = 0;

	private short splashDelay = 240;

	private short splashCounter;

	private short splashLogo;

	private bool upsellLoaded;

	public static bool isRunningSlowly;

	public static bool isTrial = true;

	public static bool isHDTV;

	public static Tutorial tutorialState = Tutorial.NUM_TUTORIALS;

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

	public static CompiledText tutorialText = null;

	private static int tutorialInputDelay;

	private static uint tutorialVar;

	private static uint tutorialVar2;

	private static Location tutorialHouse;

	public static ulong GetWorldId()
	{
		return (ulong)(((long)worldID << 32) | (uint)worldTimestamp);
	}

	public Main()
	{
		graphics = new GraphicsDeviceManager(this);
		graphics.SynchronizeWithVerticalRetrace = true;
		base.IsFixedTimeStep = true;
		base.Content.RootDirectory = "Content";
	}

	protected override void Initialize()
	{
		base.Initialize();
		menuTime.reset(86.4f);
		gameTime.reset(1f);
		NPC.clrNames();
		NPC.setNames();
		tileShine2[6] = true;
		tileShine2[7] = true;
		tileShine2[8] = true;
		tileShine2[9] = true;
		tileShine2[12] = true;
		tileShine2[21] = true;
		tileShine2[22] = true;
		tileShine2[25] = true;
		tileShine2[45] = true;
		tileShine2[46] = true;
		tileShine2[47] = true;
		tileShine2[63] = true;
		tileShine2[64] = true;
		tileShine2[65] = true;
		tileShine2[66] = true;
		tileShine2[67] = true;
		tileShine2[68] = true;
		tileShine2[107] = true;
		tileShine2[108] = true;
		tileShine2[111] = true;
		tileShine2[117] = true;
		tileShine2[121] = true;
		tileShine2[122] = true;
		tileShine[6] = 1150;
		tileShine[7] = 1100;
		tileShine[8] = 1000;
		tileShine[9] = 1050;
		tileShine[12] = 1000;
		tileShine[21] = 1200;
		tileShine[22] = 1150;
		tileShine[45] = 1900;
		tileShine[46] = 2000;
		tileShine[47] = 2100;
		tileShine[63] = 900;
		tileShine[64] = 900;
		tileShine[65] = 900;
		tileShine[66] = 900;
		tileShine[67] = 900;
		tileShine[68] = 900;
		tileShine[107] = 950;
		tileShine[108] = 900;
		tileShine[109] = 9000;
		tileShine[110] = 9000;
		tileShine[111] = 850;
		tileShine[116] = 9000;
		tileShine[117] = 9000;
		tileShine[118] = 8000;
		tileShine[121] = 1850;
		tileShine[122] = 1800;
		tileShine[125] = 600;
		tileShine[129] = 300;
		tileHammer[141] = true;
		tileHammer[4] = true;
		tileHammer[10] = true;
		tileHammer[11] = true;
		tileHammer[12] = true;
		tileHammer[13] = true;
		tileHammer[14] = true;
		tileHammer[15] = true;
		tileHammer[16] = true;
		tileHammer[17] = true;
		tileHammer[18] = true;
		tileHammer[19] = true;
		tileHammer[21] = true;
		tileHammer[26] = true;
		tileHammer[28] = true;
		tileHammer[29] = true;
		tileHammer[31] = true;
		tileHammer[33] = true;
		tileHammer[34] = true;
		tileHammer[35] = true;
		tileHammer[36] = true;
		tileHammer[42] = true;
		tileHammer[48] = true;
		tileHammer[49] = true;
		tileHammer[50] = true;
		tileHammer[54] = true;
		tileHammer[55] = true;
		tileHammer[77] = true;
		tileHammer[78] = true;
		tileHammer[79] = true;
		tileHammer[81] = true;
		tileHammer[85] = true;
		tileHammer[86] = true;
		tileHammer[87] = true;
		tileHammer[88] = true;
		tileHammer[89] = true;
		tileHammer[90] = true;
		tileHammer[91] = true;
		tileHammer[92] = true;
		tileHammer[93] = true;
		tileHammer[94] = true;
		tileHammer[95] = true;
		tileHammer[96] = true;
		tileHammer[97] = true;
		tileHammer[98] = true;
		tileHammer[99] = true;
		tileHammer[100] = true;
		tileHammer[101] = true;
		tileHammer[102] = true;
		tileHammer[103] = true;
		tileHammer[104] = true;
		tileHammer[105] = true;
		tileHammer[106] = true;
		tileHammer[114] = true;
		tileHammer[125] = true;
		tileHammer[126] = true;
		tileHammer[128] = true;
		tileHammer[129] = true;
		tileHammer[132] = true;
		tileHammer[133] = true;
		tileHammer[134] = true;
		tileHammer[135] = true;
		tileHammer[136] = true;
		tileFrameImportant[139] = true;
		tileHammer[139] = true;
		tileLighted[149] = true;
		tileFrameImportant[149] = true;
		tileHammer[149] = true;
		tileFrameImportant[142] = true;
		tileHammer[142] = true;
		tileFrameImportant[143] = true;
		tileHammer[143] = true;
		tileFrameImportant[144] = true;
		tileHammer[144] = true;
		tileStone[131] = true;
		tileFrameImportant[136] = true;
		tileFrameImportant[137] = true;
		tileFrameImportant[138] = true;
		tileBlockLight[137] = true;
		tileSolid[137] = true;
		tileBlockLight[145] = true;
		tileSolid[145] = true;
		tileMergeDirt[145] = true;
		tileBlockLight[146] = true;
		tileSolid[146] = true;
		tileMergeDirt[146] = true;
		tileBlockLight[147] = true;
		tileSolid[147] = true;
		tileMergeDirt[147] = true;
		tileBlockLight[148] = true;
		tileSolid[148] = true;
		tileMergeDirt[148] = true;
		tileBlockLight[138] = true;
		tileSolid[138] = true;
		tileBlockLight[140] = true;
		tileSolid[140] = true;
		tileAxe[5] = true;
		tileAxe[30] = true;
		tileAxe[72] = true;
		tileAxe[80] = true;
		tileAxe[124] = true;
		tileLighted[4] = true;
		tileLighted[17] = true;
		tileLighted[19] = true;
		tileLighted[22] = true;
		tileLighted[26] = true;
		tileLighted[31] = true;
		tileLighted[33] = true;
		tileLighted[34] = true;
		tileLighted[35] = true;
		tileLighted[36] = true;
		tileLighted[37] = true;
		tileLighted[42] = true;
		tileLighted[49] = true;
		tileLighted[58] = true;
		tileLighted[61] = true;
		tileLighted[70] = true;
		tileLighted[71] = true;
		tileLighted[72] = true;
		tileLighted[76] = true;
		tileLighted[77] = true;
		tileLighted[83] = true;
		tileLighted[84] = true;
		tileLighted[92] = true;
		tileLighted[93] = true;
		tileLighted[95] = true;
		tileLighted[98] = true;
		tileLighted[100] = true;
		tileLighted[109] = true;
		tileLighted[125] = true;
		tileLighted[126] = true;
		tileLighted[129] = true;
		tileLighted[133] = true;
		tileLighted[140] = true;
		tileMergeDirt[1] = true;
		tileMergeDirt[6] = true;
		tileMergeDirt[7] = true;
		tileMergeDirt[8] = true;
		tileMergeDirt[9] = true;
		tileMergeDirt[22] = true;
		tileMergeDirt[25] = true;
		tileMergeDirt[30] = true;
		tileMergeDirt[37] = true;
		tileMergeDirt[38] = true;
		tileMergeDirt[39] = true;
		tileMergeDirt[40] = true;
		tileMergeDirt[41] = true;
		tileMergeDirt[43] = true;
		tileMergeDirt[44] = true;
		tileMergeDirt[45] = true;
		tileMergeDirt[46] = true;
		tileMergeDirt[47] = true;
		tileMergeDirt[53] = true;
		tileMergeDirt[56] = true;
		tileMergeDirt[107] = true;
		tileMergeDirt[108] = true;
		tileMergeDirt[111] = true;
		tileMergeDirt[112] = true;
		tileMergeDirt[116] = true;
		tileMergeDirt[117] = true;
		tileMergeDirt[123] = true;
		tileMergeDirt[140] = true;
		tileMergeDirt[122] = true;
		tileMergeDirt[121] = true;
		tileMergeDirt[120] = true;
		tileMergeDirt[119] = true;
		tileMergeDirt[118] = true;
		tileFrameImportant[3] = true;
		tileFrameImportant[4] = true;
		tileFrameImportant[5] = true;
		tileFrameImportant[10] = true;
		tileFrameImportant[11] = true;
		tileFrameImportant[12] = true;
		tileFrameImportant[13] = true;
		tileFrameImportant[14] = true;
		tileFrameImportant[15] = true;
		tileFrameImportant[16] = true;
		tileFrameImportant[17] = true;
		tileFrameImportant[18] = true;
		tileFrameImportant[20] = true;
		tileFrameImportant[21] = true;
		tileFrameImportant[24] = true;
		tileFrameImportant[26] = true;
		tileFrameImportant[27] = true;
		tileFrameImportant[28] = true;
		tileFrameImportant[29] = true;
		tileFrameImportant[31] = true;
		tileFrameImportant[33] = true;
		tileFrameImportant[34] = true;
		tileFrameImportant[35] = true;
		tileFrameImportant[36] = true;
		tileFrameImportant[42] = true;
		tileFrameImportant[50] = true;
		tileFrameImportant[55] = true;
		tileFrameImportant[61] = true;
		tileFrameImportant[71] = true;
		tileFrameImportant[72] = true;
		tileFrameImportant[73] = true;
		tileFrameImportant[74] = true;
		tileFrameImportant[77] = true;
		tileFrameImportant[78] = true;
		tileFrameImportant[79] = true;
		tileFrameImportant[81] = true;
		tileFrameImportant[82] = true;
		tileFrameImportant[83] = true;
		tileFrameImportant[84] = true;
		tileFrameImportant[85] = true;
		tileFrameImportant[86] = true;
		tileFrameImportant[87] = true;
		tileFrameImportant[88] = true;
		tileFrameImportant[89] = true;
		tileFrameImportant[90] = true;
		tileFrameImportant[91] = true;
		tileFrameImportant[92] = true;
		tileFrameImportant[93] = true;
		tileFrameImportant[94] = true;
		tileFrameImportant[95] = true;
		tileFrameImportant[96] = true;
		tileFrameImportant[97] = true;
		tileFrameImportant[98] = true;
		tileFrameImportant[99] = true;
		tileFrameImportant[101] = true;
		tileFrameImportant[102] = true;
		tileFrameImportant[103] = true;
		tileFrameImportant[104] = true;
		tileFrameImportant[105] = true;
		tileFrameImportant[100] = true;
		tileFrameImportant[106] = true;
		tileFrameImportant[110] = true;
		tileFrameImportant[113] = true;
		tileFrameImportant[114] = true;
		tileFrameImportant[125] = true;
		tileFrameImportant[126] = true;
		tileFrameImportant[128] = true;
		tileFrameImportant[129] = true;
		tileFrameImportant[132] = true;
		tileFrameImportant[133] = true;
		tileFrameImportant[134] = true;
		tileFrameImportant[135] = true;
		tileFrameImportant[141] = true;
		tileCut[3] = true;
		tileCut[24] = true;
		tileCut[28] = true;
		tileCut[32] = true;
		tileCut[51] = true;
		tileCut[52] = true;
		tileCut[61] = true;
		tileCut[62] = true;
		tileCut[69] = true;
		tileCut[71] = true;
		tileCut[73] = true;
		tileCut[74] = true;
		tileCut[82] = true;
		tileCut[83] = true;
		tileCut[84] = true;
		tileCut[110] = true;
		tileCut[113] = true;
		tileCut[115] = true;
		tileLavaDeath[104] = true;
		tileLavaDeath[110] = true;
		tileLavaDeath[113] = true;
		tileLavaDeath[115] = true;
		tileSolid[127] = true;
		tileSolid[130] = true;
		tileBlockLight[130] = true;
		tileSolid[107] = true;
		tileBlockLight[107] = true;
		tileSolid[108] = true;
		tileBlockLight[108] = true;
		tileSolid[111] = true;
		tileBlockLight[111] = true;
		tileSolid[109] = true;
		tileBlockLight[109] = true;
		tileSolid[110] = false;
		tileNoAttach[110] = true;
		tileNoFail[110] = true;
		tileSolid[112] = true;
		tileBlockLight[112] = true;
		tileSolid[116] = true;
		tileBlockLight[116] = true;
		tileSolid[117] = true;
		tileBlockLight[117] = true;
		tileSolid[123] = true;
		tileBlockLight[123] = true;
		tileSolid[118] = true;
		tileBlockLight[118] = true;
		tileSolid[119] = true;
		tileBlockLight[119] = true;
		tileSolid[120] = true;
		tileBlockLight[120] = true;
		tileSolid[121] = true;
		tileBlockLight[121] = true;
		tileSolid[122] = true;
		tileBlockLight[122] = true;
		tileBlockLight[115] = true;
		tileSolid[0] = true;
		tileBlockLight[0] = true;
		tileSolid[1] = true;
		tileBlockLight[1] = true;
		tileSolid[2] = true;
		tileBlockLight[2] = true;
		tileSolid[3] = false;
		tileNoAttach[3] = true;
		tileNoFail[3] = true;
		tileSolid[4] = false;
		tileNoAttach[4] = true;
		tileNoFail[4] = true;
		tileNoFail[24] = true;
		tileSolid[5] = false;
		tileSolid[6] = true;
		tileBlockLight[6] = true;
		tileSolid[7] = true;
		tileBlockLight[7] = true;
		tileSolid[8] = true;
		tileBlockLight[8] = true;
		tileSolid[9] = true;
		tileBlockLight[9] = true;
		tileBlockLight[10] = true;
		tileSolid[10] = true;
		tileNoAttach[10] = true;
		tileBlockLight[10] = true;
		tileSolid[11] = false;
		tileSolidTop[19] = true;
		tileSolid[19] = true;
		tileSolid[22] = true;
		tileSolid[23] = true;
		tileSolid[25] = true;
		tileSolid[30] = true;
		tileNoFail[32] = true;
		tileBlockLight[32] = true;
		tileSolid[37] = true;
		tileBlockLight[37] = true;
		tileSolid[38] = true;
		tileBlockLight[38] = true;
		tileSolid[39] = true;
		tileBlockLight[39] = true;
		tileSolid[40] = true;
		tileBlockLight[40] = true;
		tileSolid[41] = true;
		tileBlockLight[41] = true;
		tileSolid[43] = true;
		tileBlockLight[43] = true;
		tileSolid[44] = true;
		tileBlockLight[44] = true;
		tileSolid[45] = true;
		tileBlockLight[45] = true;
		tileSolid[46] = true;
		tileBlockLight[46] = true;
		tileSolid[47] = true;
		tileBlockLight[47] = true;
		tileSolid[48] = true;
		tileBlockLight[48] = true;
		tileSolid[53] = true;
		tileBlockLight[53] = true;
		tileSolid[54] = true;
		tileBlockLight[52] = true;
		tileSolid[56] = true;
		tileBlockLight[56] = true;
		tileSolid[57] = true;
		tileBlockLight[57] = true;
		tileSolid[58] = true;
		tileBlockLight[58] = true;
		tileSolid[59] = true;
		tileBlockLight[59] = true;
		tileSolid[60] = true;
		tileBlockLight[60] = true;
		tileSolid[63] = true;
		tileBlockLight[63] = true;
		tileStone[63] = true;
		tileStone[130] = true;
		tileSolid[64] = true;
		tileBlockLight[64] = true;
		tileStone[64] = true;
		tileSolid[65] = true;
		tileBlockLight[65] = true;
		tileStone[65] = true;
		tileSolid[66] = true;
		tileBlockLight[66] = true;
		tileStone[66] = true;
		tileSolid[67] = true;
		tileBlockLight[67] = true;
		tileStone[67] = true;
		tileSolid[68] = true;
		tileBlockLight[68] = true;
		tileStone[68] = true;
		tileSolid[75] = true;
		tileBlockLight[75] = true;
		tileSolid[76] = true;
		tileBlockLight[76] = true;
		tileSolid[70] = true;
		tileBlockLight[70] = true;
		tileNoFail[50] = true;
		tileNoAttach[50] = true;
		tileDungeon[41] = true;
		tileDungeon[43] = true;
		tileDungeon[44] = true;
		tileBlockLight[30] = true;
		tileBlockLight[25] = true;
		tileBlockLight[23] = true;
		tileBlockLight[22] = true;
		tileBlockLight[62] = true;
		tileSolidTop[18] = true;
		tileSolidTop[14] = true;
		tileSolidTop[16] = true;
		tileSolidTop[114] = true;
		tileNoAttach[13] = true;
		tileNoAttach[14] = true;
		tileNoAttach[15] = true;
		tileNoAttach[16] = true;
		tileNoAttach[17] = true;
		tileNoAttach[18] = true;
		tileNoAttach[19] = true;
		tileNoAttach[21] = true;
		tileNoAttach[20] = true;
		tileNoAttach[27] = true;
		tileNoAttach[114] = true;
		tileTable[14] = true;
		tileTable[18] = true;
		tileTable[19] = true;
		tileTable[114] = true;
		tileNoAttach[86] = true;
		tileNoAttach[87] = true;
		tileNoAttach[88] = true;
		tileNoAttach[89] = true;
		tileNoAttach[90] = true;
		tileLavaDeath[86] = true;
		tileLavaDeath[87] = true;
		tileLavaDeath[88] = true;
		tileLavaDeath[89] = true;
		tileLavaDeath[125] = true;
		tileLavaDeath[126] = true;
		tileLavaDeath[101] = true;
		tileTable[101] = true;
		tileNoAttach[101] = true;
		tileLavaDeath[102] = true;
		tileNoAttach[102] = true;
		tileNoAttach[94] = true;
		tileNoAttach[95] = true;
		tileNoAttach[96] = true;
		tileNoAttach[97] = true;
		tileNoAttach[98] = true;
		tileNoAttach[99] = true;
		tileLavaDeath[94] = true;
		tileLavaDeath[95] = true;
		tileLavaDeath[96] = true;
		tileLavaDeath[97] = true;
		tileLavaDeath[98] = true;
		tileLavaDeath[99] = true;
		tileLavaDeath[100] = true;
		tileLavaDeath[103] = true;
		tileTable[87] = true;
		tileTable[88] = true;
		tileSolidTop[87] = true;
		tileSolidTop[88] = true;
		tileSolidTop[101] = true;
		tileNoAttach[91] = true;
		tileLavaDeath[91] = true;
		tileNoAttach[92] = true;
		tileLavaDeath[92] = true;
		tileNoAttach[93] = true;
		tileLavaDeath[93] = true;
		tileWaterDeath[4] = true;
		tileWaterDeath[51] = true;
		tileWaterDeath[93] = true;
		tileWaterDeath[98] = true;
		tileLavaDeath[3] = true;
		tileLavaDeath[5] = true;
		tileLavaDeath[10] = true;
		tileLavaDeath[11] = true;
		tileLavaDeath[12] = true;
		tileLavaDeath[13] = true;
		tileLavaDeath[14] = true;
		tileLavaDeath[15] = true;
		tileLavaDeath[16] = true;
		tileLavaDeath[17] = true;
		tileLavaDeath[18] = true;
		tileLavaDeath[19] = true;
		tileLavaDeath[20] = true;
		tileLavaDeath[27] = true;
		tileLavaDeath[28] = true;
		tileLavaDeath[29] = true;
		tileLavaDeath[32] = true;
		tileLavaDeath[33] = true;
		tileLavaDeath[34] = true;
		tileLavaDeath[35] = true;
		tileLavaDeath[36] = true;
		tileLavaDeath[42] = true;
		tileLavaDeath[49] = true;
		tileLavaDeath[50] = true;
		tileLavaDeath[52] = true;
		tileLavaDeath[55] = true;
		tileLavaDeath[61] = true;
		tileLavaDeath[62] = true;
		tileLavaDeath[69] = true;
		tileLavaDeath[71] = true;
		tileLavaDeath[72] = true;
		tileLavaDeath[73] = true;
		tileLavaDeath[74] = true;
		tileLavaDeath[79] = true;
		tileLavaDeath[80] = true;
		tileLavaDeath[81] = true;
		tileLavaDeath[106] = true;
		wallHouse[1] = true;
		wallHouse[4] = true;
		wallHouse[5] = true;
		wallHouse[6] = true;
		wallHouse[10] = true;
		wallHouse[11] = true;
		wallHouse[12] = true;
		wallHouse[16] = true;
		wallHouse[17] = true;
		wallHouse[18] = true;
		wallHouse[19] = true;
		wallHouse[20] = true;
		wallHouse[21] = true;
		wallHouse[22] = true;
		wallHouse[23] = true;
		wallHouse[24] = true;
		wallHouse[25] = true;
		wallHouse[26] = true;
		wallHouse[27] = true;
		wallHouse[29] = true;
		wallHouse[30] = true;
		wallHouse[31] = true;
		for (int num = 149; num >= 0; num--)
		{
			tileSolidNotSolidTop[num] = tileSolid[num] & !tileSolidTop[num];
			tileSolidAndAttach[num] = tileSolid[num] & !tileNoAttach[num];
		}
		tileNoFail[32] = true;
		tileNoFail[61] = true;
		tileNoFail[69] = true;
		tileNoFail[73] = true;
		tileNoFail[74] = true;
		tileNoFail[82] = true;
		tileNoFail[83] = true;
		tileNoFail[84] = true;
		tileNoFail[110] = true;
		tileNoFail[113] = true;
		for (int i = 0; i < 150; i++)
		{
			if (tileSolid[i])
			{
				tileNoSunLight[i] = true;
			}
		}
		tileNoSunLight[19] = false;
		tileNoSunLight[11] = true;
		dust.Init();
		for (int j = 0; j < 201; j++)
		{
			item[j].Init();
		}
		for (int k = 0; k < 197; k++)
		{
			npc[k] = new NPC();
			npc[k].whoAmI = (short)k;
		}
		for (int l = 0; l < 9; l++)
		{
			player[l] = new Player();
			player[l].whoAmI = (byte)l;
		}
		for (int m = 0; m < 512; m++)
		{
			Main.projectile[m].Init();
		}
		for (int n = 0; n < 128; n++)
		{
			gore[n].Init();
		}
		Cloud.Initialize();
		for (int num2 = 0; num2 < 32; num2++)
		{
			combatText[num2].Init();
		}
		Recipe.SetupRecipes();
		for (int num3 = 0; num3 < 7; num3++)
		{
			chatLine[num3].Init();
		}
		ref Color reference = ref teamColor[0];
		reference = Color.White;
		ref Color reference2 = ref teamColor[1];
		reference2 = new Color(230, 40, 20);
		ref Color reference3 = ref teamColor[2];
		reference3 = new Color(20, 200, 30);
		ref Color reference4 = ref teamColor[3];
		reference4 = new Color(75, 90, 255);
		ref Color reference5 = ref teamColor[4];
		reference5 = new Color(200, 180, 0);
		Projectile projectile = default(Projectile);
		for (int num4 = 1; num4 < 120; num4++)
		{
			projectile.SetDefaults(num4);
			projHostile[num4] = projectile.hostile;
		}
	}

	private void InitializePostSplash()
	{
		UI.Initialize(this);
		WorldView.Initialize(base.GraphicsDevice);
		for (int i = 0; i < 4; i++)
		{
			ui[i] = new UI();
		}
		ui[0].setView(WorldView.Type.FULLSCREEN, noAutoFullScreen: true);
		for (int j = 0; j < 4; j++)
		{
			ui[j].Initialize((PlayerIndex)j);
		}
		Item item = default(Item);
		for (int num = 631; num > 0; num--)
		{
			item.SetDefaults(num);
			if (item.headSlot > 0)
			{
				Item.headType[item.headSlot] = item.type;
			}
			else if (item.bodySlot > 0)
			{
				Item.bodyType[item.bodySlot] = item.type;
			}
			else if (item.legSlot > 0)
			{
				Item.legType[item.legSlot] = item.type;
			}
		}
		shop[0] = new Chest();
		shop[1] = new Chest();
		shop[1].SetupShop(1);
		shop[2] = new Chest();
		shop[2].SetupShop(2);
		shop[3] = new Chest();
		shop[3].SetupShop(3);
		shop[4] = new Chest();
		shop[4].SetupShop(4);
		shop[5] = new Chest();
		shop[5].SetupShop(5);
		shop[6] = new Chest();
		shop[6].SetupShop(6);
		shop[7] = new Chest();
		shop[7].SetupShop(7);
		shop[8] = new Chest();
		shop[8].SetupShop(8);
		shop[9] = new Chest();
		shop[9].SetupShop(9);
		Star.SpawnStars();
		Projectile.Initialize();
		((Collection<IGameComponent>)(object)base.Components).Add((IGameComponent)new GamerServicesComponent(this));
		SignedInGamer.SignedIn += SignedInGamer_SignedIn;
		SignedInGamer.SignedOut += SignedInGamer_SignedOut;
		NetworkSession.InviteAccepted += Netplay.NetworkSession_InviteAccepted;
	}

	protected override void LoadContent()
	{
		base.GraphicsDevice.DepthStencilState = DepthStencilState.None;
		base.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
		graphics.PreferredBackBufferWidth = 960;
		graphics.PreferredBackBufferHeight = 540;
		graphics.ApplyChanges();
		isHDTV = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height >= 720;
		spriteBatch = new SpriteBatch(base.GraphicsDevice);
		string text = Lang.setSystemLang();
		if (text != null)
		{
			splashTexture[0] = base.Content.Load<Texture2D>(text);
		}
		else
		{
			splashLogo = 1;
			splashDelay = 120;
		}
		splashTexture[1] = base.Content.Load<Texture2D>("Images/logo_1");
		loadingThread = new Thread(LoadingThread);
		loadingThread.IsBackground = true;
		loadingThread.Start();
	}

	private void LoadingThread()
	{
		Thread.CurrentThread.SetProcessorAffinity(new int[1] { 5 });
		try
		{
			for (int i = 2; i < 4; i++)
			{
				splashTexture[i] = base.Content.Load<Texture2D>("Images/logo_" + i);
			}
			audioEngine = new AudioEngine("Content/TerrariaMusic.xgs");
			soundBank = new SoundBank(audioEngine, "Content/Sound Bank.xsb");
			waveBank = new WaveBank(audioEngine, "Content/Wave Bank.xwb");
			for (int j = 0; j < 19; j++)
			{
				music[j] = soundBank.GetCue(CUE_NAMES[j]);
			}
			soundMech = new SfxInstancePool(base.Content, "Sounds/Mech_0", 3);
			soundGrab = new SfxInstancePool(base.Content, "Sounds/Grab", 3);
			soundPixie = new SfxInstancePool(base.Content, "Sounds/Pixie", 2);
			soundDig[0] = new SfxInstancePool(base.Content, "Sounds/Dig_0", 3);
			soundDig[1] = new SfxInstancePool(base.Content, "Sounds/Dig_1", 3);
			soundDig[2] = new SfxInstancePool(base.Content, "Sounds/Dig_2", 3);
			soundTink[0] = new SfxInstancePool(base.Content, "Sounds/Tink_0", 3);
			soundTink[1] = new SfxInstancePool(base.Content, "Sounds/Tink_1", 3);
			soundTink[2] = new SfxInstancePool(base.Content, "Sounds/Tink_2", 3);
			soundPlayerHit[0] = new SfxInstancePool(base.Content, "Sounds/Player_Hit_0", 3);
			soundPlayerHit[1] = new SfxInstancePool(base.Content, "Sounds/Player_Hit_1", 3);
			soundPlayerHit[2] = new SfxInstancePool(base.Content, "Sounds/Player_Hit_2", 3);
			soundFemaleHit[0] = new SfxInstancePool(base.Content, "Sounds/Female_Hit_0", 3);
			soundFemaleHit[1] = new SfxInstancePool(base.Content, "Sounds/Female_Hit_1", 3);
			soundFemaleHit[2] = new SfxInstancePool(base.Content, "Sounds/Female_Hit_2", 3);
			soundPlayerKilled = new SfxInstancePool(base.Content, "Sounds/Player_Killed", 3);
			soundChat = new SfxInstancePool(base.Content, "Sounds/Chat", 2);
			soundGrass = new SfxInstancePool(base.Content, "Sounds/Grass", 6);
			soundDoorOpen = new SfxInstancePool(base.Content, "Sounds/Door_Opened", 3);
			soundDoorClosed = new SfxInstancePool(base.Content, "Sounds/Door_Closed", 3);
			soundMenuTick = new SfxInstancePool(base.Content, "Sounds/Menu_Tick", 3);
			soundMenuOpen = new SfxInstancePool(base.Content, "Sounds/Menu_Open", 3);
			soundMenuClose = new SfxInstancePool(base.Content, "Sounds/Menu_Close", 3);
			soundShatter = new SfxInstancePool(base.Content, "Sounds/Shatter", 4);
			soundZombie[0] = new SfxInstancePool(base.Content, "Sounds/Zombie_0", 4);
			soundZombie[1] = new SfxInstancePool(base.Content, "Sounds/Zombie_1", 4);
			soundZombie[2] = new SfxInstancePool(base.Content, "Sounds/Zombie_2", 4);
			soundZombie[3] = new SfxInstancePool(base.Content, "Sounds/Zombie_3", 4);
			soundZombie[4] = new SfxInstancePool(base.Content, "Sounds/Zombie_4", 4);
			soundRoar[0] = new SfxInstancePool(base.Content, "Sounds/Roar_0", 2);
			soundRoar[1] = new SfxInstancePool(base.Content, "Sounds/Roar_1", 2);
			soundSplash[0] = new SfxInstancePool(base.Content, "Sounds/Splash_0", 4);
			soundSplash[1] = new SfxInstancePool(base.Content, "Sounds/Splash_1", 4);
			soundDoubleJump = new SfxInstancePool(base.Content, "Sounds/Double_Jump", 3);
			soundRun = new SfxInstancePool(base.Content, "Sounds/Run", 7);
			soundCoins = new SfxInstancePool(base.Content, "Sounds/Coins", 4);
			soundUnlock = new SfxInstancePool(base.Content, "Sounds/Unlock", 4);
			soundMaxMana = new SfxInstancePool(base.Content, "Sounds/MaxMana", 4);
			soundDrown = new SfxInstancePool(base.Content, "Sounds/Drown", 4);
			for (int k = 0; k < 37; k++)
			{
				int num = k + 1;
				int maxInstances = 3;
				if (num != 9 && num != 10 && num != 24 && num != 26 && num != 34)
				{
					maxInstances = 2;
				}
				soundItem[k] = new SfxInstancePool(base.Content, "Sounds/Item_" + (k + 1), maxInstances);
			}
			for (int l = 0; l < 11; l++)
			{
				soundNPCHit[l] = new SfxInstancePool(base.Content, "Sounds/NPC_Hit_" + (l + 1), 4);
			}
			for (int m = 0; m < 15; m++)
			{
				soundNPCKilled[m] = new SfxInstancePool(base.Content, "Sounds/NPC_Killed_" + (m + 1), 3);
			}
		}
		catch
		{
			musicVolume = 0f;
			soundVolume = 0f;
		}
		_sheetTiles.LoadContent(base.Content);
		_sheetSprites.LoadContent(base.Content);
		WorldView.LoadContent(base.Content);
		whiteTexture = new Texture2D(base.GraphicsDevice, 1, 1, mipMap: false, SurfaceFormat.Bgr565);
		whiteTexture.SetData(new ushort[1] { 65535 });
		UI.LoadContent(base.Content);
		CRC32.Initialize();
	}

	protected override void UnloadContent()
	{
	}

	private void UpdateMusic(Player mainPlayer)
	{
		try
		{
			if (curMusic != Music.NUM_SONGS && music[(uint)curMusic].IsPaused)
			{
				music[(uint)curMusic].Resume();
			}
			if (musicVolume == 0f)
			{
				newMusic = Music.NUM_SONGS;
			}
			else
			{
				bool flag = true;
				for (int i = 0; i < 4; i++)
				{
					if (ui[i].menuType != 0)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					if (UI.main.menuMode == MenuMode.CREDITS)
					{
						newMusic = Music.TUTORIAL;
					}
					else
					{
						newMusic = Music.MUSIC_6;
					}
				}
				else if (IsTutorial())
				{
					newMusic = Music.TUTORIAL;
				}
				else
				{
					int num = 0;
					bool result = false;
					Rectangle value = default(Rectangle);
					value.Width = 10000;
					value.Height = 10000;
					WorldView view = mainPlayer.view;
					for (int j = 0; j < 196; j++)
					{
						if (npc[j].active == 0)
						{
							continue;
						}
						int type = npc[j].type;
						switch (type)
						{
						case 134:
						case 143:
						case 144:
						case 145:
							value.X = npc[j].aabb.X + (npc[j].width >> 1) - 5000;
							value.Y = npc[j].aabb.Y + (npc[j].height >> 1) - 5000;
							view.viewArea.Intersects(ref value, out result);
							if (!result)
							{
								continue;
							}
							num = 3;
							break;
						default:
							switch (type)
							{
							case 113:
							case 114:
							case 125:
							case 126:
								value.X = npc[j].aabb.X + (npc[j].width >> 1) - 5000;
								value.Y = npc[j].aabb.Y + (npc[j].height >> 1) - 5000;
								view.viewArea.Intersects(ref value, out result);
								if (!result)
								{
									continue;
								}
								num = 2;
								break;
							case 4:
							case 166:
								value.X = npc[j].aabb.X + (npc[j].width >> 1) - 5000;
								value.Y = npc[j].aabb.Y + (npc[j].height >> 1) - 5000;
								view.viewArea.Intersects(ref value, out result);
								if (!result)
								{
									continue;
								}
								num = 4;
								break;
							default:
								if (!npc[j].boss && (type < 13 || type > 15) && (type < 26 || type > 29) && type != 111)
								{
									continue;
								}
								value.X = npc[j].aabb.X + (npc[j].width >> 1) - 5000;
								value.Y = npc[j].aabb.Y + (npc[j].height >> 1) - 5000;
								view.viewArea.Intersects(ref value, out result);
								if (!result)
								{
									continue;
								}
								num = 1;
								break;
							}
							break;
						}
						break;
					}
					if (num > 0)
					{
						switch (num)
						{
						case 1:
							newMusic = Music.MUSIC_5;
							break;
						case 2:
							newMusic = Music.MUSIC_12;
							break;
						case 3:
							newMusic = Music.MUSIC_13;
							break;
						case 4:
							newMusic = Music.BOSS4;
							break;
						}
					}
					else if (view.screenPosition.Y > maxTilesY - 200 << 4)
					{
						newMusic = Music.MUSIC_2;
					}
					else if (mainPlayer.zoneEvil)
					{
						if (view.screenPosition.Y > worldSurfacePixels + 540)
						{
							newMusic = Music.MUSIC_10;
						}
						else
						{
							newMusic = Music.MUSIC_8;
						}
					}
					else if (view.atmo < 1f)
					{
						newMusic = Music.FLOATING_ISLAND;
					}
					else if ((view.screenPosition.X < 3200 || view.screenPosition.X > (maxTilesX - 200 << 4) - 960) && view.screenPosition.Y <= worldSurfacePixels)
					{
						newMusic = Music.OCEAN;
					}
					else if (mainPlayer.zoneMeteor || mainPlayer.zoneDungeon)
					{
						newMusic = Music.MUSIC_2;
					}
					else if (mainPlayer.zoneJungle)
					{
						newMusic = Music.MUSIC_7;
					}
					else if (mainPlayer.view.sandTiles > 1000)
					{
						newMusic = Music.DESERT;
					}
					else if (mainPlayer.view.snowTiles > 80)
					{
						newMusic = Music.SNOW;
					}
					else if (view.screenPosition.Y > worldSurfacePixels)
					{
						if (mainPlayer.zoneHoly)
						{
							newMusic = Music.MUSIC_11;
						}
						else
						{
							newMusic = Music.MUSIC_4;
						}
					}
					else if (gameTime.dayTime)
					{
						if (mainPlayer.zoneHoly)
						{
							newMusic = Music.MUSIC_9;
						}
						else
						{
							newMusic = Music.MUSIC_1;
						}
					}
					else if (!gameTime.dayTime)
					{
						if (gameTime.bloodMoon)
						{
							newMusic = Music.MUSIC_2;
						}
						else
						{
							newMusic = Music.MUSIC_3;
						}
					}
					int num2 = 0;
					while (musicBox < 0 && num2 < 4)
					{
						if (ui[num2].view != null)
						{
							musicBox = ui[num2].view.musicBox;
						}
						num2++;
					}
					if (musicBox >= 0)
					{
						newMusic = MUSIC_BOX_TO_SONG[musicBox];
					}
				}
			}
			curMusic = newMusic;
			for (int k = 0; k < 19; k++)
			{
				if (k == (int)curMusic)
				{
					if (!music[k].IsPlaying)
					{
						music[k] = soundBank.GetCue(CUE_NAMES[k]);
						music[k].Play();
					}
					else
					{
						musicFade[k] += 0.005f;
						if (musicFade[k] > 1f)
						{
							musicFade[k] = 1f;
						}
					}
					music[k].SetVariable("Volume", musicFade[k] * musicVolume);
				}
				else if (music[k].IsPlaying)
				{
					if (curMusic == Music.NUM_SONGS)
					{
						musicFade[k] = 0f;
						music[k].Stop(AudioStopOptions.Immediate);
					}
					else if (musicFade[(uint)curMusic] > 0.25f)
					{
						musicFade[k] -= 0.005f;
						if (musicFade[k] <= 0f)
						{
							musicFade[k] = 0f;
							music[k].Stop(AudioStopOptions.Immediate);
						}
						else
						{
							music[k].SetVariable("Volume", musicFade[k] * musicVolume);
						}
					}
				}
				else
				{
					musicFade[k] = 0f;
				}
			}
		}
		catch
		{
			musicVolume = 0f;
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
		isRunningSlowly = dt.IsRunningSlowly;
		frameCounter++;
		switch (showSplash)
		{
		case 0:
			return;
		case 1:
			loadingThread.Join();
			loadingThread = null;
			showSplash = 2;
			InitializePostSplash();
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			ui[i].UpdateGamePad();
		}
		if (tutorialState < Tutorial.THE_END)
		{
			UpdateTutorial();
		}
		for (int j = 0; j < 4; j++)
		{
			ui[j].Update();
		}
		dust.UpdateDust();
		if (UI.quit)
		{
			Quit();
			return;
		}
		UI.UpdateOnce();
		AchievementSystem.Update();
		audioEngine.Update();
		WorldGen.destroyObject = false;
		UpdateMusic(UI.main.player);
		hasFocus = base.IsActive;
		isGamePaused = !hasFocus && netMode == 0;
		if (isGamePaused)
		{
			return;
		}
		if (Netplay.session != null)
		{
			if (!Netplay.disconnect)
			{
				if (Netplay.hookEvents)
				{
					Netplay.HookSessionEvents();
				}
				if (netMode == 1)
				{
					UpdateClient();
				}
				else
				{
					UpdateServer();
				}
			}
			else if (Netplay.stopSession)
			{
				Netplay.Disconnect();
			}
		}
		if (Netplay.invite != null)
		{
			Netplay.InviteAccepted();
		}
		if (netMode == 0)
		{
			if (UI.main.menuType == MenuType.PAUSE)
			{
				bool flag = true;
				for (int k = 0; k < 4; k++)
				{
					if (ui[k].menuType == MenuType.NONE)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					isGamePaused = true;
					return;
				}
			}
		}
		else if (checkWorldId)
		{
			for (int l = 0; l < 4; l++)
			{
				UI uI = ui[l];
				if (uI.view != null && uI.menuType == MenuType.NONE)
				{
					checkWorldId = false;
					if (uI.CheckBlacklist())
					{
						break;
					}
				}
			}
		}
		Star.UpdateStars();
		Cloud.UpdateClouds();
		for (int m = 0; m < 7; m++)
		{
			if (chatLine[m].showTime > 0)
			{
				chatLine[m].showTime--;
			}
		}
		for (int n = 0; n < 4; n++)
		{
			if (ui[n].view != null && ui[n].menuType == MenuType.MAIN)
			{
				UpdateMenuTime();
				break;
			}
		}
		if (!isGameStarted)
		{
			return;
		}
		if (netMode != 0 && checkUserGeneratedContent)
		{
			checkUserGeneratedContent = false;
			UI.main.CheckUserGeneratedContent();
		}
		if (DiscoStyle == 0)
		{
			DiscoRGB.Y += 0.02745098f;
			if (DiscoRGB.Y >= 1f)
			{
				DiscoRGB.Y = 1f;
				DiscoStyle = 1;
			}
			DiscoRGB.X -= 0.02745098f;
			if (DiscoRGB.X < 0f)
			{
				DiscoRGB.X = 0f;
			}
		}
		else if (DiscoStyle == 1)
		{
			DiscoRGB.Z += 0.02745098f;
			if (DiscoRGB.Z >= 1f)
			{
				DiscoRGB.Z = 1f;
				DiscoStyle = 2;
			}
			DiscoRGB.Y -= 0.02745098f;
			if (DiscoRGB.Y < 0f)
			{
				DiscoRGB.Y = 0f;
			}
		}
		else
		{
			DiscoRGB.X += 0.02745098f;
			if (DiscoRGB.X >= 1f)
			{
				DiscoRGB.X = 1f;
				DiscoStyle = 0;
			}
			DiscoRGB.Z -= 0.02745098f;
			if (DiscoRGB.Z < 0f)
			{
				DiscoRGB.Z = 0f;
			}
		}
		if ((frameCounter & 7) == 0 && ++magmaBGFrame >= 3)
		{
			magmaBGFrame = 0;
		}
		demonTorch += demonTorchDir;
		if (demonTorch > 1f)
		{
			demonTorch = 1f;
			demonTorchDir = 0f - demonTorchDir;
		}
		else if (demonTorch < 0f)
		{
			demonTorch = 0f;
			demonTorchDir = 0f - demonTorchDir;
		}
		if (netMode != 1)
		{
			WorldGen.UpdateWorld();
			UpdateInvasion();
		}
		musicBox = -1;
		for (int num = 0; num < 8; num++)
		{
			if (player[num].active != 0)
			{
				player[num].UpdatePlayer(num);
			}
		}
		if (netMode != 1 && tutorialState >= Tutorial.THE_END)
		{
			NPC.SpawnNPC();
		}
		for (int num2 = 0; num2 < 8; num2++)
		{
			player[num2].activeNPCs = 0f;
			player[num2].townNPCs = 0f;
		}
		if (NPC.wof >= 0 && npc[NPC.wof].active == 0)
		{
			NPC.wof = -1;
		}
		for (int num3 = 195; num3 >= 0; num3--)
		{
			if (npc[num3].active != 0)
			{
				npc[num3].UpdateNPC(num3);
			}
		}
		for (int num4 = 0; num4 < 128; num4++)
		{
			if (gore[num4].active != 0)
			{
				gore[num4].Update();
			}
		}
		for (int num5 = 0; num5 < 512; num5++)
		{
			if (projectile[num5].active != 0)
			{
				projectile[num5].Update(num5);
			}
		}
		for (int num6 = 0; num6 < 200; num6++)
		{
			if (item[num6].active != 0)
			{
				item[num6].UpdateItem(num6);
			}
		}
		CombatText.UpdateCombatText();
		UpdateTime();
	}

	private static void UpdateMenuTime()
	{
		menuTime.update();
		if (netMode == 1)
		{
			UpdateTime();
		}
	}

	private void DrawSplash(GameTime dt)
	{
		base.GraphicsDevice.Clear(default(Color));
		base.Draw(dt);
		if (splashCounter == splashDelay + 16 + 16)
		{
			splashTexture[splashLogo].Dispose();
			splashTexture[splashLogo] = null;
			splashDelay = 120;
			splashCounter = 0;
			if (++splashLogo == 4)
			{
				showSplash = 1;
				return;
			}
		}
		splashCounter++;
		spriteBatch.Begin();
		int num = 0;
		if (splashCounter < 16)
		{
			num = splashCounter * 255 / 16;
		}
		else if (splashCounter <= 16 + splashDelay)
		{
			num = 255;
		}
		else
		{
			num = splashCounter - splashDelay - 16;
			num = 255 - num * 255 / 16;
		}
		Vector2 position = default(Vector2);
		position.X = 960 - splashTexture[splashLogo].Width >> 1;
		position.Y = 540 - splashTexture[splashLogo].Height >> 1;
		spriteBatch.Draw(splashTexture[splashLogo], position, new Color(num, num, num, num));
		spriteBatch.End();
	}

	public void LoadUpsell()
	{
		if (!upsellLoaded)
		{
			upsellLoaded = true;
			for (int i = 0; i < 1; i++)
			{
				splashTexture[i] = base.Content.Load<Texture2D>("UI/Upsell/0" + (i + 1) + "_" + Lang.languageId);
			}
		}
		splashLogo = 0;
		splashCounter = 0;
	}

	public void DrawUpsell()
	{
		splashCounter++;
		int num = 0;
		num = ((splashCounter >= 16) ? 255 : (splashCounter * 255 / 16));
		Vector2 position = default(Vector2);
		position.X = 960 - splashTexture[splashLogo].Width >> 1;
		position.Y = 540 - splashTexture[splashLogo].Height >> 1;
		spriteBatch.Draw(splashTexture[splashLogo], position, new Color(num, num, num, num));
	}

	protected override void Draw(GameTime dt)
	{
		if (showSplash == 0)
		{
			DrawSplash(dt);
			return;
		}
		renderCount++;
		for (int i = 0; i < 4; i++)
		{
			ui[i].PrepareDraw(renderCount);
		}
		if (renderCount > 4)
		{
			renderCount = 0;
			Lighting.tempLightCount = 0;
		}
		base.GraphicsDevice.SetRenderTarget(null);
		base.GraphicsDevice.Clear(default(Color));
		base.Draw(dt);
		for (int j = 0; j < 4; j++)
		{
			ui[j].Draw();
		}
		WorldView.restoreViewport();
		spriteBatch.Begin();
		for (int k = 0; k < 4; k++)
		{
			if (ui[k].menuType != 0)
			{
				DrawChat();
				break;
			}
		}
		if (saveIconCounter > 0 || activeSaves > 0)
		{
			saveIconCounter--;
			SpriteSheet<_sheetSprites>.Draw(642, 878, 479, Color.White, (float)((double)saveIconCounter * (Math.PI / 60.0)), 1f);
		}
		spriteBatch.End();
	}

	private static void UpdateInvasion()
	{
		if (invasionType <= 0)
		{
			return;
		}
		if (invasionSize <= 0)
		{
			if (invasionType == 1)
			{
				NPC.downedGoblins = true;
				UI.SetTriggerStateForAll(Trigger.KilledGoblinArmy);
				NetMessage.CreateMessage0(7);
				NetMessage.SendMessage();
			}
			else if (invasionType == 2)
			{
				NPC.downedFrost = true;
			}
			InvasionWarning();
			invasionType = 0;
			invasionDelay = 7;
		}
		if (invasionX == (float)spawnTileX)
		{
			return;
		}
		float num = 1f;
		if (invasionX > (float)spawnTileX)
		{
			invasionX -= num;
			if (invasionX <= (float)spawnTileX)
			{
				invasionX = spawnTileX;
				InvasionWarning();
			}
			else
			{
				invasionWarn--;
			}
		}
		else if (invasionX < (float)spawnTileX)
		{
			invasionX += num;
			if (invasionX >= (float)spawnTileX)
			{
				invasionX = spawnTileX;
				InvasionWarning();
			}
			else
			{
				invasionWarn--;
			}
		}
		if (invasionWarn <= 0)
		{
			invasionWarn = 3600;
			InvasionWarning();
		}
	}

	private static void InvasionWarning()
	{
		int textId = ((invasionSize <= 0) ? ((invasionType == 2) ? 4 : 0) : ((invasionX < (float)spawnTileX) ? ((invasionType != 2) ? 1 : 5) : ((invasionX > (float)spawnTileX) ? ((invasionType != 2) ? 2 : 6) : ((invasionType != 2) ? 3 : 7))));
		NetMessage.SendText(textId, 175, 75, 255, -1);
	}

	public static void StartInvasion(int type = 1)
	{
		if (invasionType != 0 || invasionDelay != 0)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (player[i].active != 0 && player[i].statLifeMax >= 200)
			{
				num++;
			}
		}
		if (num > 0)
		{
			invasionType = type;
			invasionSize = 80 + 40 * num;
			invasionWarn = 0;
			if (rand.Next(2) == 0)
			{
				invasionX = 0f;
			}
			else
			{
				invasionX = maxTilesX;
			}
		}
	}

	private static void UpdateClient()
	{
		if (isGameStarted)
		{
			netPlayCounter++;
		}
		Netplay.session.Update();
		NetMessage.CheckBytesClient();
	}

	private static void UpdateServer()
	{
		if (isGameStarted)
		{
			netPlayCounter++;
			for (int num = Netplay.clients.Count - 1; num >= 0; num--)
			{
				NetClient netClient = Netplay.clients[num];
				for (int num2 = ((ReadOnlyCollection<NetworkGamer>)(object)netClient.machine.Gamers).Count - 1; num2 >= 0; num2--)
				{
					Player player = ((ReadOnlyCollection<NetworkGamer>)(object)netClient.machine.Gamers)[num2].Tag as Player;
					if (player.active != 0)
					{
						int num3 = (player.aabb.X >> 4) / 40;
						int num4 = (player.aabb.Y >> 4) / 30;
						NetMessage.SendSection(netClient, num3, num4);
						if (player.velocity.X > 0f)
						{
							if (!NetMessage.SendSection(netClient, num3 + 1, num4) && !NetMessage.SendSection(netClient, num3 + 1, num4 - 1) && !NetMessage.SendSection(netClient, num3 + 1, num4 + 1) && !NetMessage.SendSection(netClient, num3 + 2, num4) && !NetMessage.SendSection(netClient, num3 + 2, num4 - 1) && !NetMessage.SendSection(netClient, num3 + 2, num4 + 1))
							{
							}
						}
						else if (player.velocity.X < 0f && !NetMessage.SendSection(netClient, num3 - 1, num4) && !NetMessage.SendSection(netClient, num3 - 1, num4 - 1) && !NetMessage.SendSection(netClient, num3 - 1, num4 + 1) && !NetMessage.SendSection(netClient, num3 - 2, num4) && !NetMessage.SendSection(netClient, num3 - 2, num4 - 1))
						{
							NetMessage.SendSection(netClient, num3 - 2, num4 + 1);
						}
						if (player.velocity.Y > 0f)
						{
							if (!NetMessage.SendSection(netClient, num3, num4 + 1) && !NetMessage.SendSection(netClient, num3 + 1, num4 + 1) && !NetMessage.SendSection(netClient, num3 - 1, num4 + 1) && !NetMessage.SendSection(netClient, num3 + 2, num4 + 1) && !NetMessage.SendSection(netClient, num3 - 2, num4 + 1))
							{
							}
						}
						else if (player.velocity.Y < 0f && !NetMessage.SendSection(netClient, num3, num4 - 1) && !NetMessage.SendSection(netClient, num3 + 1, num4 - 1) && !NetMessage.SendSection(netClient, num3 - 1, num4 - 1) && !NetMessage.SendSection(netClient, num3 + 2, num4 - 1))
						{
							NetMessage.SendSection(netClient, num3 - 2, num4 - 1);
						}
					}
				}
			}
		}
		try
		{
			Netplay.session.Update();
		}
		catch (Exception)
		{
		}
		if (netMode == 0)
		{
			Netplay.CheckOfflineSession();
			return;
		}
		NetMessage.CheckBytesServer();
		foreach (NetworkGamer remoteGamer in Netplay.session.RemoteGamers)
		{
			Player player2 = remoteGamer.Tag as Player;
			if (player2.kill)
			{
				player2.kill = false;
				player2.active = 0;
				remoteGamer.Machine.RemoveFromSession();
			}
		}
	}

	public static void NewText(string newText, int R, int G, int B)
	{
		for (int num = 6; num > 0; num--)
		{
			ref ChatLine reference = ref chatLine[num];
			reference = chatLine[num - 1];
		}
		chatLine[0].color = new Color(R, G, B);
		chatLine[0].text = newText;
		chatLine[0].showTime = 600;
		PlaySound(12);
	}

	public static void DrawChat()
	{
		int num = 0;
		float num2 = 0f;
		for (int i = 0; i < 7; i++)
		{
			if (chatLine[i].showTime > 0)
			{
				Vector2 vector = UI.fontSmallOutline.MeasureString(chatLine[i].text);
				if (vector.X > num2)
				{
					num2 = vector.X;
				}
				num++;
			}
		}
		if (num == 0 || num2 == 0f)
		{
			return;
		}
		DrawRect(new Rectangle(48, 440 - num * 22, (int)num2 + 12, num * 22 + 12), new Color(32, 32, 32, 32));
		for (int j = 0; j < 7; j++)
		{
			if (chatLine[j].showTime > 0)
			{
				float num3 = (float)(int)UI.mouseTextBrightness * 0.003921569f;
				spriteBatch.DrawString(UI.fontSmallOutline, chatLine[j].text, new Vector2(54f, 439 - (j + 1) * 22), new Color((byte)((float)(int)chatLine[j].color.R * num3), (byte)((float)(int)chatLine[j].color.G * num3), (byte)((float)(int)chatLine[j].color.B * num3), UI.mouseTextBrightness));
			}
		}
	}

	private static void UpdateTime()
	{
		bool bloodMoon = gameTime.bloodMoon;
		if (gameTime.update())
		{
			WorldGen.spawnNPC = 0;
			NPC.checkForSpawnsTimer = 0;
			if (gameTime.dayTime)
			{
				Time.checkXMas();
				if (invasionDelay > 0)
				{
					invasionDelay--;
				}
				if (netMode != 1)
				{
					if (WorldGen.shadowOrbSmashed && rand.Next(NPC.downedGoblins ? 15 : 3) == 0)
					{
						StartInvasion();
					}
					for (int i = 0; i < 8; i++)
					{
						if (Main.player[i].active != 0)
						{
							Main.player[i].SunMoonTransition(bloodMoon);
						}
					}
				}
			}
			else if (netMode != 1)
			{
				if (WorldGen.shadowOrbSmashed && rand.Next(50) == 0)
				{
					WorldGen.spawnMeteor = true;
				}
				if (!NPC.downedBoss1)
				{
					for (int j = 0; j < 8; j++)
					{
						if (Main.player[j].active == 0 || Main.player[j].statLifeMax < 200 || Main.player[j].statDefense <= 10)
						{
							continue;
						}
						if (rand.Next(3) != 0)
						{
							break;
						}
						int num = 0;
						for (int k = 0; k < 196; k++)
						{
							if (npc[k].townNPC && npc[k].active != 0 && ++num >= 4)
							{
								WorldGen.spawnEye = true;
								NetMessage.SendText(9, 50, 255, 130, -1);
								break;
							}
						}
						break;
					}
				}
				if (!WorldGen.spawnEye && gameTime.moonPhase != 4 && rand.Next(9) == 0)
				{
					for (int l = 0; l < 8; l++)
					{
						if (Main.player[l].active != 0 && Main.player[l].statLifeMax > 120)
						{
							gameTime.bloodMoon = true;
							NetMessage.SendText(8, 50, 255, 130, -1);
							break;
						}
					}
				}
				for (int m = 0; m < 8; m++)
				{
					if (Main.player[m].active != 0)
					{
						Main.player[m].SunMoonTransition(wasBloodMoon: false);
					}
				}
			}
			if (netMode == 2)
			{
				NetMessage.CreateMessage0(7);
				NetMessage.SendMessage();
			}
		}
		else if (gameTime.dayTime)
		{
			if (netMode != 1)
			{
				NPC.checkForTownSpawns();
			}
		}
		else if (gameTime.time > 16200f)
		{
			if (WorldGen.spawnMeteor)
			{
				WorldGen.spawnMeteor = false;
				WorldGen.dropMeteor();
			}
		}
		else
		{
			if (!(gameTime.time > 4860f) || !WorldGen.spawnEye || netMode == 1)
			{
				return;
			}
			for (int n = 0; n < 8; n++)
			{
				Player player = Main.player[n];
				if (player.active != 0 && !player.dead && player.aabb.Y < worldSurfacePixels)
				{
					NPC.SpawnOnPlayer(player, 4);
					WorldGen.spawnEye = false;
					break;
				}
			}
		}
	}

	public static int DamageVar(int dmg)
	{
		double a = (double)dmg * (1.0 + (double)rand.Next(-15, 16) * 0.01);
		return (int)Math.Round(a);
	}

	public static double CalculateDamage(int Damage, int Defense)
	{
		double num = (double)Damage - (double)Defense * 0.5;
		if (num < 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	public static void PlaySound(int type, int x, int y, int style = 1)
	{
		if (soundVolume == 0f)
		{
			return;
		}
		try
		{
			float num = soundVolume;
			float num2 = 0f;
			bool flag;
			if (UI.numActiveViews > 1)
			{
				flag = WorldView.AnyViewContains(x, y);
			}
			else
			{
				Rectangle rectangle = default(Rectangle);
				rectangle.X = UI.current.view.screenPosition.X - 960;
				rectangle.Y = UI.current.view.screenPosition.Y - 540;
				rectangle.Width = 2880;
				rectangle.Height = 1620;
				flag = rectangle.Contains(x, y);
				if (flag)
				{
					Vector2 vector = new Vector2(UI.current.view.screenPosition.X + 480, UI.current.view.screenPosition.Y + 270);
					float num3 = Math.Abs((float)x - vector.X);
					float num4 = Math.Abs((float)y - vector.Y);
					float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
					num = 1f - num5 * 0.0015625f;
					if (num > 1f)
					{
						num = 1f;
					}
					num *= soundVolume;
					if (num <= 0f)
					{
						return;
					}
					num2 = ((float)x - vector.X) * 0.00052083336f;
					if (num2 < -1f)
					{
						num2 = -1f;
					}
					else if (num2 > 1f)
					{
						num2 = 1f;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			switch (type)
			{
			case 0:
			{
				int num12 = rand.Next(3);
				soundDig[num12].Play(num, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			}
			case 1:
			{
				int num13 = rand.Next(3);
				soundPlayerHit[num13].Play(num, num2);
				break;
			}
			case 2:
			{
				if (style == 1)
				{
					int num9 = rand.Next(3);
					if (num9 != 0)
					{
						style = num9 + 17;
					}
				}
				double num10 = num;
				double pitch;
				if (style == 26 || style == 35)
				{
					num10 *= 0.75;
					pitch = harpNote;
				}
				else
				{
					pitch = (double)rand.Next(-6, 7) * 0.01;
				}
				soundItem[style - 1].Play(num10, num2, pitch);
				break;
			}
			case 3:
				soundNPCHit[style - 1].Play(num, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			case 4:
				if (style != 10 || !soundNPCKilled[style - 1].IsPlaying())
				{
					soundNPCKilled[style - 1].Play(num, num2, (double)rand.Next(-10, 11) * 0.01);
				}
				break;
			case 5:
				soundPlayerKilled.Play(num, num2);
				break;
			case 6:
				soundGrass.Play(num, num2, (double)rand.Next(-30, 31) * 0.01);
				break;
			case 7:
				soundGrab.Play(num, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			case 8:
				soundDoorOpen.Play(num, num2, (double)rand.Next(-20, 21) * 0.01);
				break;
			case 9:
				soundDoorClosed.Play(num, num2, (double)rand.Next(-20, 21) * 0.01);
				break;
			case 13:
				soundShatter.Play(num, num2);
				break;
			case 14:
			{
				int num11 = rand.Next(3);
				soundZombie[num11].Play((double)num * 0.4, num2);
				break;
			}
			case 15:
				if (!soundRoar[style].IsPlaying())
				{
					soundRoar[style].Play(num, num2);
				}
				break;
			case 16:
				soundDoubleJump.Play(num, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			case 17:
				soundRun.Play(num, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			case 19:
				soundSplash[style].Play(num, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			case 20:
			{
				int num8 = rand.Next(3);
				soundFemaleHit[num8].Play(num, num2);
				break;
			}
			case 21:
			{
				int num7 = rand.Next(3);
				soundTink[num7].Play(num, num2);
				break;
			}
			case 22:
				soundUnlock.Play(num, num2);
				break;
			case 26:
			{
				int num6 = rand.Next(3, 5);
				soundZombie[num6].Play((double)num * 0.9, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			}
			case 27:
				soundPixie.UpdateOrPlay(num, num2, (double)rand.Next(-10, 11) * 0.01);
				break;
			case 28:
				if (!soundMech.IsPlaying())
				{
					soundMech.Play(num, num2, (float)rand.Next(-10, 11) * 0.01f);
				}
				break;
			}
		}
		catch
		{
		}
	}

	public static void PlaySound(int type)
	{
		if (soundVolume == 0f)
		{
			return;
		}
		try
		{
			float num = soundVolume;
			switch (type)
			{
			case 1:
			{
				int num3 = rand.Next(3);
				soundPlayerHit[num3].Play(num);
				break;
			}
			case 7:
				soundGrab.Play(num, 0.0, (double)rand.Next(-10, 11) * 0.01);
				break;
			case 10:
				soundMenuOpen.Play(num);
				break;
			case 11:
				soundMenuClose.Play(num);
				break;
			case 12:
				soundMenuTick.Play(num);
				break;
			case 18:
				soundCoins.Play(num);
				break;
			case 20:
			{
				int num2 = rand.Next(3);
				soundFemaleHit[num2].Play(num);
				break;
			}
			case 23:
				soundDrown.Play(num);
				break;
			case 24:
				soundChat.Play(num);
				break;
			case 25:
				soundMaxMana.Play(num);
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
		{
			return;
		}
		if (tutorialInputDelay > 0)
		{
			tutorialInputDelay--;
		}
		Vector2 leftThumbStick = (TutorialMaskLS ? default(Vector2) : UI.main.gpState.ThumbSticks.Left);
		Vector2 rightThumbStick = (TutorialMaskRS ? default(Vector2) : UI.main.gpState.ThumbSticks.Right);
		float leftTrigger = (TutorialMaskLT ? 0f : UI.main.gpState.Triggers.Left);
		float rightTrigger = (TutorialMaskRT ? 0f : UI.main.gpState.Triggers.Right);
		Buttons buttons = (Buttons)0;
		if (!TutorialMaskA && UI.main.gpState.IsButtonDown(Buttons.A))
		{
			buttons |= Buttons.A;
		}
		if (!TutorialMaskB && UI.main.gpState.IsButtonDown(Buttons.B))
		{
			buttons |= Buttons.B;
		}
		if (!TutorialMaskX && UI.main.gpState.IsButtonDown(Buttons.X))
		{
			buttons |= Buttons.X;
		}
		if (!TutorialMaskY && UI.main.gpState.IsButtonDown(Buttons.Y))
		{
			buttons |= Buttons.Y;
		}
		if (!TutorialMaskBack && UI.main.gpState.IsButtonDown(Buttons.Back))
		{
			buttons |= Buttons.Back;
		}
		if (!TutorialMaskLB && UI.main.gpState.IsButtonDown(Buttons.LeftShoulder))
		{
			buttons |= Buttons.LeftShoulder;
		}
		if (!TutorialMaskRB && UI.main.gpState.IsButtonDown(Buttons.RightShoulder))
		{
			buttons |= Buttons.RightShoulder;
		}
		if (!TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadLeft))
		{
			buttons |= Buttons.DPadLeft;
		}
		if (!TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadRight))
		{
			buttons |= Buttons.DPadRight;
		}
		if (!TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadUp))
		{
			buttons |= Buttons.DPadUp;
		}
		if (!TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.DPadDown))
		{
			buttons |= Buttons.DPadDown;
		}
		if (!TutorialMaskLS && UI.main.gpState.IsButtonDown(Buttons.LeftStick))
		{
			buttons |= Buttons.LeftStick;
		}
		if (!TutorialMaskRSpress && UI.main.gpState.IsButtonDown(Buttons.RightStick))
		{
			buttons |= Buttons.RightStick;
		}
		if (UI.main.gpState.IsButtonDown(Buttons.Start))
		{
			buttons |= Buttons.Start;
		}
		UI.main.gpState = new GamePadState(leftThumbStick, rightThumbStick, leftTrigger, rightTrigger, buttons);
		switch (tutorialState)
		{
		case Tutorial.INTRO:
		case Tutorial.MONSTER_INFO_1:
		case Tutorial.POTIONS_1:
		case Tutorial.TORCH_1:
		case Tutorial.INVENTORY_2:
		case Tutorial.MOVEMENT_1:
		case Tutorial.DROP_1:
		case Tutorial.EQUIPSCREEN_1:
		case Tutorial.CHEST_1:
		case Tutorial.CRAFTSCREEN_1:
		case Tutorial.MINED_ORE_1:
		case Tutorial.CURSOR_SWITCH_1:
		case Tutorial.DAY_NIGHT_1:
		case Tutorial.USE_BENCH_1:
		case Tutorial.BACK_WALL_INFO_1:
		case Tutorial.HOUSE_INFO_1:
		case Tutorial.HOUSE_DONE_1:
		case Tutorial.THE_GUIDE_1:
		case Tutorial.HAMMER_1:
		case Tutorial.CONGRATS_1:
			if (tutorialInputDelay == 0)
			{
				NextTutorial();
			}
			break;
		}
		switch (tutorialState)
		{
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
			if (UI.main.IsButtonTriggered(Buttons.B))
			{
				UI.main.ClearButtonTriggers();
				TutorialMaskB = tutorialVar != 0;
				NextTutorial();
			}
			return;
		}
		Player player = UI.main.player;
		switch (tutorialState)
		{
		case Tutorial.MOVE:
			if (UI.main.gpState.ThumbSticks.Left.LengthSquared() > 1f / 64f)
			{
				tutorialVar++;
			}
			if (tutorialVar > 4 && tutorialInputDelay == 0)
			{
				UI.main.AchievementTriggers.SetState(Trigger.FirstTutorialTaskCompleted, state: true);
				NextTutorial();
			}
			break;
		case Tutorial.JUMP:
			if (UI.main.totalJumps - tutorialVar >= 1)
			{
				NextTutorial();
			}
			break;
		case Tutorial.FALL_DOWN:
			if (player.controlDown)
			{
				int num = (int)player.position.X + 10 >> 4;
				int num2 = (int)player.position.Y + 42 >> 4;
				if (tile[num, num2 - 1].type == 19 || tile[num - 1, num2 - 1].type == 19 || tile[num + 1, num2 - 1].type == 19)
				{
					NextTutorial();
				}
			}
			break;
		case Tutorial.JUMP_OUT:
			if (UI.main.totalJumps - tutorialVar >= 1)
			{
				int num3 = (int)player.position.X + 10 >> 4;
				int num4 = (int)player.position.Y + 42 >> 4;
				if (tile[num3, num4 + 1].type == 19 || tile[num3 - 1, num4 + 1].type == 19 || tile[num3 + 1, num4 + 1].type == 19)
				{
					NextTutorial();
				}
			}
			break;
		case Tutorial.CURSOR:
			if (UI.main.gpState.ThumbSticks.Right.LengthSquared() > 1f / 64f)
			{
				tutorialVar++;
			}
			if (UI.main.IsButtonTriggered(Buttons.RightTrigger))
			{
				tutorialVar2++;
			}
			if (tutorialInputDelay == 0 && tutorialVar != 0 && tutorialVar2 != 0)
			{
				NextTutorial();
			}
			break;
		case Tutorial.HOTBAR:
			if (tutorialInputDelay == 0 && player.selectedItem == 0)
			{
				NextTutorial();
			}
			break;
		case Tutorial.SWORD_ATTACK:
			if (UI.main.totalSlimes > tutorialVar)
			{
				Item.NewItem((int)player.position.X, (int)player.position.Y, 1, 1, 23);
				NextTutorial();
			}
			else if (tutorialVar2 != 0 && --tutorialVar2 == 0)
			{
				tutorialVar2 = 900u;
				int num7 = NPC.NewNPC(player.aabb.X - 480, player.aabb.Y - 540, 1);
				npc[num7].SetDefaults("Green Slime");
			}
			break;
		case Tutorial.SELECT_AXE:
			if (tutorialInputDelay == 0 && player.inventory[player.selectedItem].axe > 0)
			{
				NextTutorial();
			}
			break;
		case Tutorial.USE_AXE:
			if (UI.main.totalChops > tutorialVar)
			{
				NextTutorial();
			}
			break;
		case Tutorial.INVENTORY:
			if (UI.main.inventoryMode == 1)
			{
				NextTutorial();
			}
			break;
		case Tutorial.EQUIPMENT:
			if (UI.main.inventorySection == UI.InventorySection.EQUIP)
			{
				NextTutorial();
			}
			break;
		case Tutorial.CRAFTING:
			if (UI.main.inventorySection == UI.InventorySection.CRAFTING)
			{
				NextTutorial();
			}
			break;
		case Tutorial.CRAFT_TORCH:
			if (UI.main.totalTorchesCrafted > tutorialVar)
			{
				NextTutorial();
			}
			break;
		case Tutorial.CRAFT_CATEGORIES:
			if (UI.main.IsButtonTriggered(Buttons.LeftTrigger) || UI.main.IsButtonTriggered(Buttons.RightTrigger))
			{
				tutorialVar++;
			}
			if (tutorialVar != 0 && tutorialInputDelay == 0)
			{
				NextTutorial();
			}
			break;
		case Tutorial.CRAFTING_EXIT:
			if (UI.main.inventoryMode == 0)
			{
				NextTutorial();
			}
			break;
		case Tutorial.SELECT_PICK:
			if (tutorialInputDelay == 0 && player.inventory[player.selectedItem].pick > 0)
			{
				NextTutorial();
			}
			break;
		case Tutorial.USE_PICK:
			if (UI.main.totalCopper - tutorialVar >= 55)
			{
				NextTutorial();
			}
			break;
		case Tutorial.WOOD_PLATFORM:
			if (UI.main.totalWoodPlatformsCrafted - tutorialVar >= 5)
			{
				NextTutorial(2);
			}
			else if (--tutorialVar2 == 0)
			{
				NextTutorial();
			}
			break;
		case Tutorial.WOOD_PLATFORM_TIME_OUT:
			if (UI.main.totalWoodPlatformsCrafted - tutorialVar >= 5)
			{
				NextTutorial();
			}
			break;
		case Tutorial.SELECT_PLATFORM:
			if (tutorialInputDelay == 0 && player.inventory[player.selectedItem].type == 94)
			{
				NextTutorial();
			}
			break;
		case Tutorial.BUILD_CURSOR:
			if (tutorialInputDelay == 0 && !UI.main.smartCursor)
			{
				TutorialMaskRSpress = true;
				NextTutorial();
			}
			break;
		case Tutorial.PLACING_1:
			if (UI.main.totalWoodPlatformsPlaced > tutorialVar)
			{
				NextTutorial();
			}
			break;
		case Tutorial.PLACING_2:
			if (player.aabb.Y < 3360)
			{
				NextTutorial();
			}
			break;
		case Tutorial.BUILD_HOUSE:
			if (tutorialInputDelay == 0)
			{
				NextTutorial();
			}
			goto case Tutorial.BUILD_HOUSE_EXTRA_INFO;
		case Tutorial.BUILD_HOUSE_EXTRA_INFO:
		{
			if ((frameCounter & 0x1Fu) != 0)
			{
				break;
			}
			int num5 = UI.main.mouseX + UI.main.view.screenPosition.X >> 4;
			int num6 = UI.main.mouseY + UI.main.view.screenPosition.Y >> 4;
			bool flag = WorldGen.StartSpaceCheck(num5, num6);
			if (!flag)
			{
				num5--;
				flag = WorldGen.StartSpaceCheck(num5, num6);
				if (!flag)
				{
					num5 += 2;
					flag = WorldGen.StartSpaceCheck(num5, num6);
				}
				if (!flag)
				{
					num5--;
					num6++;
					flag = WorldGen.StartSpaceCheck(num5, num6);
				}
			}
			if (flag)
			{
				tutorialHouse.X = (short)num5;
				tutorialHouse.Y = (short)num6;
				NextTutorial((tutorialState != Tutorial.BUILD_HOUSE) ? 1 : 2);
			}
			break;
		}
		case Tutorial.BUILD_HOUSE_2:
			if (tutorialInputDelay == 0)
			{
				NextTutorial();
			}
			goto case Tutorial.BUILD_HOUSE_2_EXTRA_INFO;
		case Tutorial.BUILD_HOUSE_2_EXTRA_INFO:
			if ((frameCounter & 0x1F) == 0 && (UI.main.totalAxed - tutorialVar >= 3 || UI.main.totalPicked - tutorialVar2 >= 3) && !WorldGen.StartSpaceCheck(tutorialHouse.X, tutorialHouse.Y))
			{
				NextTutorial((tutorialState != Tutorial.BUILD_HOUSE_2) ? 1 : 2);
			}
			break;
		case Tutorial.CRAFT_WORKBENCH:
		case Tutorial.CRAFT_WORKBENCH_EXTRA_INFO:
		{
			if ((frameCounter & 0x1Fu) != 0)
			{
				break;
			}
			int num8 = (int)player.position.X + 10 >> 4;
			int num9 = ((int)player.position.Y + 42 >> 4) - 1;
			for (int i = num8 - 5; i < num8 + 5; i++)
			{
				for (int j = num9 - 5; j < num9 + 5; j++)
				{
					if (tile[i, j].type == 18)
					{
						NextTutorial((tutorialState != Tutorial.CRAFT_WORKBENCH) ? 1 : 2);
						return;
					}
				}
			}
			break;
		}
		case Tutorial.CRAFT_DOOR:
		case Tutorial.CRAFT_DOOR_EXTRA_INFO:
			if (tutorialInputDelay == 0 && player.hasItemInInventory(25))
			{
				NextTutorial((tutorialState != Tutorial.CRAFT_DOOR) ? 1 : 2);
			}
			break;
		case Tutorial.PLACE_DOOR:
			if ((frameCounter & 0x1F) == 0 && WorldGen.StartSpaceCheck(tutorialHouse.X, tutorialHouse.Y) && (WorldGen.houseTile[10] || WorldGen.houseTile[11]))
			{
				NextTutorial();
			}
			break;
		case Tutorial.USE_DOOR:
			if (tutorialInputDelay == 0 && (UI.main.totalDoorsOpened > tutorialVar || UI.main.totalDoorsClosed > tutorialVar2))
			{
				NextTutorial();
			}
			break;
		case Tutorial.CRAFT_WALL:
		case Tutorial.CRAFT_WALL_EXTRA_INFO:
			if (tutorialInputDelay == 0 && UI.main.totalWallsCrafted - tutorialVar >= 32)
			{
				NextTutorial((tutorialState != Tutorial.CRAFT_WALL) ? 1 : 2);
			}
			break;
		case Tutorial.PLACE_WALL:
			if (tutorialInputDelay == 0 && UI.main.totalWallsPlaced - tutorialVar >= 8)
			{
				NextTutorial();
			}
			break;
		case Tutorial.BACK_WALL:
			if ((frameCounter & 0x1F) == 0 && WorldGen.StartRoomCheck(tutorialHouse.X, tutorialHouse.Y))
			{
				NextTutorial();
			}
			break;
		case Tutorial.PLACE_CHAIR:
			if ((frameCounter & 0x1F) == 0 && WorldGen.StartRoomCheck(tutorialHouse.X, tutorialHouse.Y))
			{
				WorldGen.RoomNeeds();
				if (WorldGen.roomChair)
				{
					NextTutorial();
				}
			}
			break;
		case Tutorial.PLACE_TORCH:
			if ((frameCounter & 0x1F) == 0 && WorldGen.StartRoomCheck(tutorialHouse.X, tutorialHouse.Y) && WorldGen.RoomNeeds())
			{
				NextTutorial();
			}
			break;
		case Tutorial.MONSTER_INFO_1:
		case Tutorial.MONSTER_INFO_2:
		case Tutorial.POTIONS_1:
		case Tutorial.POTIONS_2:
		case Tutorial.TORCH_1:
		case Tutorial.TORCH_2:
		case Tutorial.INVENTORY_2:
		case Tutorial.INVENTORY_3:
		case Tutorial.MOVEMENT_1:
		case Tutorial.MOVEMENT_2:
		case Tutorial.DROP_1:
		case Tutorial.DROP_2:
		case Tutorial.EQUIPSCREEN_1:
		case Tutorial.EQUIPSCREEN_2:
		case Tutorial.CHEST_1:
		case Tutorial.CHEST_2:
		case Tutorial.CRAFTSCREEN_1:
		case Tutorial.CRAFTSCREEN_2:
		case Tutorial.MINED_ORE_1:
		case Tutorial.MINED_ORE_2:
		case Tutorial.CURSOR_SWITCH_1:
		case Tutorial.CURSOR_SWITCH_2:
		case Tutorial.DAY_NIGHT_1:
		case Tutorial.DAY_NIGHT_2:
		case Tutorial.USE_BENCH_1:
		case Tutorial.USE_BENCH_2:
		case Tutorial.BACK_WALL_INFO_1:
		case Tutorial.BACK_WALL_INFO_2:
		case Tutorial.HOUSE_INFO_1:
		case Tutorial.HOUSE_INFO_2:
			break;
		}
	}

	private static void NextTutorial(int steps = 1)
	{
		if (tutorialState < Tutorial.THE_END)
		{
			SetTutorial(tutorialState + steps);
		}
	}

	public static void SetTutorial(Tutorial t)
	{
		tutorialState = t;
		if (t == Tutorial.NUM_TUTORIALS)
		{
			TutorialMaskLS = false;
			TutorialMaskRS = false;
			TutorialMaskRSpress = false;
			TutorialMaskA = false;
			TutorialMaskB = false;
			TutorialMaskX = false;
			TutorialMaskY = false;
			TutorialMaskLB = false;
			TutorialMaskRB = false;
			TutorialMaskLT = false;
			TutorialMaskRT = false;
			TutorialMaskBack = false;
			return;
		}
		tutorialInputDelay = 180;
		string text = Lang.tutorial(t);
		Player player = UI.main.player;
		switch (t)
		{
		case Tutorial.INTRO:
			TutorialMaskLS = true;
			TutorialMaskRS = true;
			TutorialMaskRSpress = true;
			TutorialMaskA = true;
			TutorialMaskB = true;
			TutorialMaskX = true;
			TutorialMaskY = true;
			TutorialMaskLB = true;
			TutorialMaskRB = true;
			TutorialMaskLT = true;
			TutorialMaskRT = true;
			TutorialMaskBack = true;
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
			tutorialVar = (TutorialMaskB ? 1u : 0u);
			TutorialMaskB = false;
			break;
		case Tutorial.MOVE:
			TutorialMaskLS = false;
			tutorialVar = 0u;
			break;
		case Tutorial.JUMP:
			TutorialMaskA = false;
			tutorialVar = UI.main.totalJumps;
			break;
		case Tutorial.JUMP_OUT:
			tutorialVar = UI.main.totalJumps;
			break;
		case Tutorial.CURSOR:
			TutorialMaskRT = false;
			TutorialMaskRS = false;
			tutorialVar = 0u;
			tutorialVar2 = 0u;
			break;
		case Tutorial.HOTBAR:
			TutorialMaskLB = false;
			TutorialMaskRB = false;
			break;
		case Tutorial.SWORD_ATTACK:
			tutorialVar = UI.main.totalSlimes;
			tutorialVar2 = 120u;
			break;
		case Tutorial.MONSTER_INFO_1:
		{
			for (int num = 195; num >= 0; num--)
			{
				if (npc[num].type == 1 && npc[num].active != 0)
				{
					npc[num].HitEffect(0, 999.0);
					npc[num].active = 0;
				}
			}
			break;
		}
		case Tutorial.USE_AXE:
			tutorialVar = UI.main.totalChops;
			break;
		case Tutorial.INVENTORY:
			TutorialMaskY = false;
			TutorialMaskB = true;
			break;
		case Tutorial.INVENTORY_2:
			TutorialMaskLB = true;
			TutorialMaskRB = true;
			break;
		case Tutorial.EQUIPMENT:
			TutorialMaskRB = false;
			TutorialMaskLB = false;
			TutorialMaskRT = false;
			TutorialMaskLT = false;
			break;
		case Tutorial.CRAFT_TORCH:
			TutorialMaskX = false;
			tutorialVar = UI.main.totalTorchesCrafted;
			break;
		case Tutorial.CRAFT_CATEGORIES:
			tutorialVar = 0u;
			break;
		case Tutorial.CRAFTING_EXIT:
			TutorialMaskB = false;
			break;
		case Tutorial.USE_PICK:
			tutorialVar = UI.main.totalCopper;
			break;
		case Tutorial.WOOD_PLATFORM:
			tutorialVar = UI.main.totalWoodPlatformsCrafted;
			tutorialVar2 = 600u;
			break;
		case Tutorial.BUILD_CURSOR:
			TutorialMaskRSpress = false;
			break;
		case Tutorial.PLACING_1:
			tutorialVar = UI.main.totalWoodPlatformsPlaced;
			break;
		case Tutorial.PLACING_2:
			text = Lang.tutorial(t - 1) + text;
			break;
		case Tutorial.CURSOR_SWITCH_1:
			TutorialMaskRSpress = false;
			break;
		case Tutorial.BUILD_HOUSE:
			tutorialInputDelay = 1800;
			break;
		case Tutorial.BUILD_HOUSE_2:
			tutorialVar = UI.main.totalAxed;
			tutorialVar2 = UI.main.totalPicked;
			tutorialInputDelay = 600;
			break;
		case Tutorial.BUILD_HOUSE_EXTRA_INFO:
		case Tutorial.BUILD_HOUSE_2_EXTRA_INFO:
			text = Lang.tutorial(t - 1) + text;
			break;
		case Tutorial.CRAFT_WORKBENCH:
			if (player.CountInventory(9) < 10)
			{
				tutorialState = t + 1;
				text += Lang.tutorial(tutorialState);
			}
			break;
		case Tutorial.CRAFT_DOOR:
			if (player.CountInventory(9) < 6)
			{
				tutorialState = t + 1;
				text += Lang.tutorial(tutorialState);
			}
			break;
		case Tutorial.USE_DOOR:
			tutorialVar = UI.main.totalDoorsOpened;
			tutorialVar2 = UI.main.totalDoorsClosed;
			break;
		case Tutorial.CRAFT_WALL:
			tutorialVar = UI.main.totalWallsCrafted;
			if (player.CountInventory(9) < 6)
			{
				tutorialState = t + 1;
				text += Lang.tutorial(tutorialState);
			}
			break;
		case Tutorial.PLACE_WALL:
			tutorialVar = UI.main.totalWallsPlaced;
			break;
		case Tutorial.THE_END:
			gameTime.dayRate = 1f;
			UI.main.AchievementTriggers.SetState(Trigger.AllTutorialTasksCompleted, state: true);
			break;
		}
		if (text != null)
		{
			tutorialText = new CompiledText(text, 470, UI.styleFontSmallOutline);
		}
		else
		{
			tutorialText = null;
		}
	}

	public static bool IsTutorial()
	{
		return tutorialState != Tutorial.NUM_TUTORIALS;
	}

	public static void StartTutorial()
	{
		Player player = new Player();
		player.name = UI.main.signedInGamer.Gamertag;
		player.selectedItem = 1;
		UI.main.createCharacterGUI.Randomize(player);
		UI.main.setPlayer(player);
		SetTutorial(Tutorial.INTRO);
		WorldGen.playWorld();
	}

	public static void StartGame()
	{
		UI main = UI.main;
		PlaySound(11);
		for (int i = 0; i < 7; i++)
		{
			chatLine[i].Init();
		}
		for (int j = 0; j < 8; j++)
		{
			if (j != main.myPlayer)
			{
				player[j].active = 0;
			}
			player[j].announced = false;
		}
		if (IsTutorial())
		{
			UI.main.signedInGamer.Presence.SetPresenceModeString("Tutorial");
		}
		else if (main.isOnline)
		{
			netMode = 2;
			main.signedInGamer.Presence.SetPresenceModeString("Online");
		}
		else
		{
			main.signedInGamer.Presence.SetPresenceModeString("Offline");
		}
		Netplay.StartServer();
		musicBox = -1;
		gameTime = WorldGen.tempTime;
		main.InitGame();
		Netplay.sessionReadyEvent.WaitOne();
		main.player.Spawn();
		main.menuType = MenuType.NONE;
		main.view.onStartGame();
		MiniMap.onStartGame();
		GC.Collect();
		isGameStarted = true;
	}

	public static void JoinGame(UI startUI)
	{
		startUI.signedInGamer.Presence.SetPresenceModeString((netMode == 0) ? "Offline" : "Online");
		PlaySound(11);
		startUI.InitGame();
		startUI.player.Spawn();
		if (netMode == 2)
		{
			NetMessage.syncPlayer(startUI.myPlayer);
		}
		startUI.menuType = MenuType.NONE;
		startUI.view.onStartGame();
		MiniMap.onStartGame();
		isGameStarted = true;
	}

	public static void DrawSolidRect(Rectangle rect, Color color)
	{
		spriteBatch.Draw(whiteTexture, rect, color);
	}

	public static void DrawSolidRect(ref Rectangle rect, Color color)
	{
		spriteBatch.Draw(whiteTexture, rect, color);
	}

	public static void DrawRect(int texId, Rectangle rect, int alpha, int shift = 0)
	{
		Rectangle s = default(Rectangle);
		Rectangle dest = rect;
		Vector2 pos = default(Vector2);
		Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
		s.X = (s.Y = 8);
		s.Width = (s.Height = 36);
		pos.X = rect.X - 8;
		pos.Y = rect.Y - 8;
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
		pos.Y = rect.Y + rect.Height;
		SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
		pos.X = rect.X + rect.Width;
		s.X = 44;
		s.Y = 44;
		SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
		pos.Y = rect.Y - 8;
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
		Rectangle s = default(Rectangle);
		Rectangle dest = rect;
		Vector2 pos = default(Vector2);
		Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
		s.X = (s.Y = 8);
		s.Width = (s.Height = 36);
		pos.X = rect.X - 8;
		pos.Y = rect.Y - 8;
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
		pos.X = rect.X + rect.Width;
		pos.Y = rect.Y - 8;
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
		Rectangle s = default(Rectangle);
		Rectangle dest = rect;
		Vector2 pos = default(Vector2);
		Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
		s.X = (s.Y = 8);
		s.Width = 36;
		s.Height = 36;
		dest.Height += 8;
		pos.X = rect.X - 8;
		pos.Y = rect.Y - 8;
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
		pos.X = rect.X + rect.Width;
		pos.Y = rect.Y - 8;
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
		Rectangle s = default(Rectangle);
		Rectangle dest = rect;
		Vector2 pos = default(Vector2);
		Color c = new Color(alpha >> shift, alpha >> shift, alpha >> shift, alpha);
		s.X = (s.Y = 8);
		s.Width = (s.Height = 36);
		pos.X = rect.X - 8;
		pos.Y = rect.Y - 8;
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
		pos.Y = rect.Y + rect.Height;
		SpriteSheet<_sheetSprites>.Draw(texId, ref pos, ref s, c);
		pos.X = rect.X + rect.Width;
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
			spriteBatch.Draw(whiteTexture, rect, color);
			color.A >>= 3;
		}
		Rectangle destinationRectangle = rect;
		destinationRectangle.Y -= 2;
		destinationRectangle.Height = 2;
		spriteBatch.Draw(whiteTexture, destinationRectangle, color);
		destinationRectangle.X -= 2;
		destinationRectangle.Y += 2;
		destinationRectangle.Height = rect.Height;
		destinationRectangle.Width = 2;
		spriteBatch.Draw(whiteTexture, destinationRectangle, color);
		destinationRectangle.X += rect.Width + 2;
		spriteBatch.Draw(whiteTexture, destinationRectangle, color);
		destinationRectangle.X = rect.X;
		destinationRectangle.Y += rect.Height;
		destinationRectangle.Width = rect.Width;
		destinationRectangle.Height = 2;
		spriteBatch.Draw(whiteTexture, destinationRectangle, color);
	}

	public static void ShowSaveIcon()
	{
		if (saveIconCounter <= 0)
		{
			saveIconCounter = 180;
		}
		activeSaves++;
	}

	public static void HideSaveIcon()
	{
		activeSaves--;
	}

	public static bool IsSaveIconVisible()
	{
		if (saveIconCounter <= 0)
		{
			return activeSaves > 0;
		}
		return true;
	}

	private void Quit()
	{
		Netplay.disconnect = true;
		Exit();
	}

	private static void SignedInGamer_SignedIn(object sender, SignedInEventArgs e)
	{
		_ = e.Gamer;
		isTrial = Guide.IsTrialMode;
		checkUserGeneratedContent = true;
	}

	private static void SignedInGamer_SignedOut(object sender, SignedOutEventArgs e)
	{
		SignedInGamer gamer = e.Gamer;
		PlayerIndex playerIndex = gamer.PlayerIndex;
		UI uI = ui[(int)playerIndex];
		uI.SignOut();
	}
}
