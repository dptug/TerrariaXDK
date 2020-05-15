using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Terraria.Achievements;
using Terraria.CreateCharacter;
using Terraria.HowToPlay;
using Terraria.Leaderboards;
using Terraria.SoundUI;

namespace Terraria
{
	public sealed class UI
	{
		public enum InventorySection : byte
		{
			CRAFTING,
			ITEMS,
			CHEST,
			EQUIP,
			HOUSING,
			NUM_SECTIONS
		}

		public enum CraftingSection : byte
		{
			RECIPES,
			INGREDIENTS
		}

		private enum StackType
		{
			NONE,
			INGREDIENT,
			INVENTORY,
			HOTBAR
		}

		private const bool TEST_WATCH = false;

		private const bool TEST_DEPTH_METER = false;

		private const bool TEST_COMPASS = false;

		private const ulong MARKETPLACE_OFFER_ID = 6359384554213474305uL;

		public const int FULLSCREEN_SAFE_AREA_OFFSET_X = 48;

		public const int FULLSCREEN_SAFE_AREA_OFFSET_Y = 27;

		public const int USABLE_WIDTH = 864;

		public const int USABLE_HEIGHT = 454;

		public const int CONTROLS_HUD_X = 0;

		public const int UI_DELAY = 12;

		public const int MOUSE_DELAY = 4;

		public const float DEAD_ZONE = 0.125f;

		public const float DEAD_ZONE_SQUARED = 0.015625f;

		public const float WORLD_FADE_START = -0.25f;

		private const float WORLD_FADE_SPEED = 71f / (678f * (float)Math.PI);

		private const float UI_FADE_SPEED = 71f / (678f * (float)Math.PI);

		private const int MAX_ITEMS = 14;

		private const int MAX_DEPTH = 16;

		private const int MAX_LOAD_PLAYERS = 5;

		private const int MAX_LOAD_WORLDS = 5;

		public const int mcColorR = 125;

		public const int mcColorG = 125;

		public const int mcColorB = 255;

		public const int hcColorR = 200;

		public const int hcColorG = 125;

		public const int hcColorB = 255;

		public const float FONT_STACK_EXTRA_SCALE = 0.1f;

		public const Buttons BTN_JUMP = Buttons.A;

		public const Buttons BTN_INTERACT = Buttons.B;

		public const Buttons BTN_USE = Buttons.RightTrigger;

		public const Buttons BTN_DROP = Buttons.X;

		public const Buttons BTN_RESPAWN = Buttons.A;

		public const Buttons BTN_CURSOR_MODE = Buttons.RightStick;

		public const Buttons BTN_PREV_ITEM = Buttons.LeftShoulder;

		public const Buttons BTN_NEXT_ITEM = Buttons.RightShoulder;

		public const Buttons BTN_INVENTORY_SELL_OR_TRASH = Buttons.X;

		public const Buttons BTN_INVENTORY_SELECT = Buttons.A;

		public const Buttons BTN_INVENTORY_ACTION = Buttons.RightTrigger;

		public const Buttons BTN_INVENTORY_DROP = Buttons.X;

		public const Buttons BTN_INVENTORY_HOUSING = Buttons.LeftTrigger;

		public const Buttons BTN_INVENTORY_OPEN = Buttons.Y;

		public const Buttons BTN_INVENTORY_CLOSE = Buttons.B;

		public const Buttons BTN_NPC_CHAT_SELECT = Buttons.A;

		public const Buttons BTN_NPC_CHAT_CLOSE = Buttons.B;

		public const float LEFT_STICK_VERTICAL_THRESHOLD = 0.5f;

		public const int HOTBAR_ITEMNAME_DISPLAYTIME = 210;

		public const int QUICK_ACCESS_DISPLAYTIME = 120;

		private const int CRAFTING_INGREDIENT_COLS = 4;

		private const int CRAFTING_INGREDIENT_ROWS = 3;

		private const float CRAFTING_DEFAULT_SCROLL_MUL = 0.8125f;

		private const float CRAFTING_MIN_SCROLL_MUL = 0.25f;

		private const float CRAFTING_SCROLL_MUL_DECREMENT = 0.075f;

		private const int cooldownLen = 180;

		private const int MENU_TITLE_W = 1;

		private const int MENU_TITLE_H = 7;

		private const int MENU_PAUSE_W = 1;

		private const int MENU_PAUSE_H = 7;

		private const int MENU_SELECT_W = 1;

		private const int MENU_SELECT_H = 6;

		private const int MENU_CONFIRM_DELETE_W = 1;

		private const int MENU_CONFIRM_DELETE_H = 2;

		private const int MENU_WORLD_SIZE_W = 1;

		private const int MENU_WORLD_SIZE_H = 3;

		private const int MENU_OPTIONS_W = 1;

		private const int MENU_OPTIONS_H = 4;

		private const int MENU_SETTINGS_W = 1;

		private const int MENU_SETTINGS_H = 3;

		private const int INVENTORY_W = 864;

		private const int INVENTORY_H = 446;

		private const int INVENTORY_CLIENT_Y_OFFSET = 80;

		private const int INVENTORY_CLIENT_H = 366;

		private const int TOOLTIP_W = 322;

		private const float INVENTORY_FADE = 0.5f;

		public static Color DISABLED_COLOR = new Color(16, 16, 16, 128);

		public static Color WINDOW_OUTLINE = new Color(12, 24, 24, 255);

		public static Color DEFAULT_DIALOG_COLOR = new Color(42, 43, 101, 192);

		private static int FONT_STACK_EXTRA_OFFSET = -5;

		public static UI main;

		public static UI current;

		public static int numActiveViews;

		public static WorldView[] activeView = new WorldView[4];

		public WorldView view;

		public LocalNetworkGamer localGamer;

		public SignedInGamer signedInGamer;

		public PlayerIndex controller;

		public Player player;

		public byte myPlayer = 8;

		private byte privateSlots;

		public NetPlayer netPlayer = new NetPlayer();

		public bool wasRemovedFromSessionWithoutOurConsent;

		public MenuType menuType;

		public bool isStopping;

		public float worldFade;

		public float worldFadeTarget = 1f;

		public float uiFade = 1f;

		public float uiFadeTarget = 1f;

		public short oldMouseX;

		public short oldMouseY;

		public short mouseX;

		public short mouseY;

		public bool smartCursor = true;

		public bool alternateGrappleControls;

		public Buttons BTN_JUMP2 = Buttons.LeftStick;

		public Buttons BTN_GRAPPLE = Buttons.LeftTrigger;

		private sbyte quickAccessUp = -1;

		private sbyte quickAccessDown = -1;

		private sbyte quickAccessLeft = -1;

		private sbyte quickAccessRight = -1;

		public GamePadState gpPrevState;

		public GamePadState gpState;

		public StorageDeviceManager playerStorage;

		private List<string> transferredPlayerStorage = new List<string>(3);

		public sbyte numLoadPlayers;

		public string playerPathName;

		public Player[] loadPlayer = new Player[5];

		public string[] loadPlayerPath = new string[5];

		private float logoRotation;

		private float logoRotationDirection = 1f;

		private float logoRotationSpeed = 1f;

		private float logoScale = 1f;

		private float logoScaleDirection = 1f;

		private float logoScaleSpeed = 1f;

		private short LogoA = 255;

		private short LogoB;

		public string statusText;

		private static string errorDescription;

		private static string errorCaption;

		private static CompiledText errorCompiledText;

		private static CompiledText saveIconMessage = null;

		private static int saveIconMessageTime = 0;

		public float musicVolume = 0.75f;

		public float soundVolume = 1f;

		public bool autoSave;

		public bool showItemText = true;

		public bool isOnline;

		public bool isInviteOnly;

		public bool settingsDirty;

		private Stopwatch saveTime = new Stopwatch();

		private Color selColor = Color.White;

		private bool[] noFocus = new bool[14];

		private bool[] blockFocus = new bool[14];

		private short[] menuY = new short[14];

		private byte[] menuHC = new byte[14];

		private float[] menuScale = new float[14];

		private float[] menuItemScale = new float[14];

		private sbyte focusMenu = -1;

		private sbyte selectedMenu = -1;

		public sbyte selectedPlayer;

		public int menuDepth;

		public MenuMode menuMode = MenuMode.WELCOME;

		public MenuMode[] prevMenuMode = new MenuMode[16];

		public float progress;

		private float progressTotal;

		private float numProgressStepsInv;

		private short uiX;

		private short uiY;

		private sbyte uiWidth;

		private sbyte uiHeight;

		private sbyte uiDelayValue;

		public sbyte uiDelay;

		public Location[] uiCoords;

		private Location[] uiPos = new Location[38];

		public int cursorHighlight;

		public Terraria.CreateCharacter.UI createCharacterGUI;

		private Terraria.SoundUI.UI soundUI;

		private Terraria.HowToPlay.UI howtoUI;

		private TextSequenceBlock tips;

		private LeaderboardsUI leaderboards;

		public int hotbarItemNameTime = 210;

		public int quickAccessDisplayTime;

		public float[] hotbarScale = new float[10]
		{
			1f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f,
			0.75f
		};

		private static float inventoryScale;

		public float[] inventoryMenuSectionScale = new float[5]
		{
			0.75f,
			0.75f,
			1f,
			0.75f,
			0.75f
		};

		public byte inventoryMode;

		private bool restoreOldInventorySection;

		private InventorySection oldInventorySection;

		public InventorySection inventorySection = InventorySection.ITEMS;

		private sbyte inventoryItemX;

		private sbyte inventoryItemY;

		private sbyte inventoryChestX;

		private sbyte inventoryChestY;

		private sbyte inventoryEquipX;

		private sbyte inventoryEquipY = 1;

		private sbyte inventoryBuffX;

		private sbyte inventoryHousingX;

		private sbyte inventoryHousingY;

		private short inventoryHousingNpc = -1;

		public Recipe.Category craftingCategory;

		private CraftingSection craftingSection;

		public bool craftingShowCraftable;

		public sbyte craftingRecipeX;

		public sbyte craftingRecipeY;

		private sbyte craftingIngredientX;

		private sbyte craftingIngredientY;

		private float craftingRecipeScrollX;

		private float craftingRecipeScrollY;

		public Recipe craftingRecipe;

		private float craftingRecipeScrollMul = 0.8125f;

		public short stackSplit;

		public short stackCounter;

		public short stackDelay = 7;

		private sbyte mouseItemSrcX;

		private sbyte mouseItemSrcY;

		private InventorySection mouseItemSrcSection = InventorySection.NUM_SECTIONS;

		public Item mouseItem = default(Item);

		public Item trashItem = default(Item);

		public Item guideItem = default(Item);

		private Item toolTip = default(Item);

		public List<Recipe.SubCategoryList> currentRecipeCategory = new List<Recipe.SubCategoryList>();

		public byte npcShop;

		public bool craftGuide;

		public bool reforge;

		public string chestText;

		public bool editSign;

		public bool signBubble;

		public int signX;

		public int signY;

		public UserString npcChatText;

		public string npcCompiledChatText;

		private CompiledText npcChatCompiledText;

		public short helpText;

		public sbyte npcChatSelectedItem;

		public bool showNPCs;

		public MiniMap miniMap = new MiniMap();

		private int mapScreenCursorX;

		private int mapScreenCursorY;

		public byte teamSelected;

		public bool pvpSelected;

		public short teamCooldown;

		public short pvpCooldown;

		public Statistics Statistics;

		public TriggerSystem AchievementTriggers;

		public uint totalJumps;

		public uint totalChops;

		public uint totalSlimes;

		public uint totalAxed;

		public uint totalCopper;

		public uint totalDoorsOpened;

		public uint totalDoorsClosed;

		public uint totalWoodPlatformsPlaced;

		public uint totalWallsPlaced;

		public uint totalTorchesCrafted;

		public uint totalWoodPlatformsCrafted;

		public uint totalWallsCrafted;

		public uint totalSteps;

		public uint totalBarsCrafted;

		public uint totalPicked;

		public uint totalAnvilCrafting;

		public uint totalWires;

		public uint totalAirTime;

		public uint currentAirTime;

		public float airTravel;

		public byte petSpawnMask;

		private BitArray armorFound = new BitArray(632);

		private List<ulong> blacklist = new List<ulong>();

		private static Main theGame;

		public static byte mouseTextBrightness = 175;

		private static sbyte mouseTextColorChange = 2;

		public static Color mouseTextColor = new Color(175, 175, 175, 175);

		public static Color mouseColor = new Color(255, 95, 180);

		public static Color cursorColor = Color.White;

		public static float cursorAlpha = 0f;

		public static float cursorScale = 0f;

		public static byte invAlpha = 180;

		private static sbyte invDir = 1;

		public static float essScale = 1f;

		private static float essDir = -0.01f;

		public static float blueWave = 1f;

		private static float blueDelta = -0.0005f;

		public static bool quit = false;

		public static Texture2D logoTexture;

		public static Texture2D logo2Texture;

		public static Texture2D controlsTexture;

		public static Texture2D progressBarTexture;

		public static Texture2D textBackTexture;

		public static Texture2D chatBackTexture;

		public static Texture2D cursorTexture;

		public static SpriteFont fontBig;

		public static SpriteFont fontSmall;

		public static SpriteFont fontSmallOutline;

		public static SpriteFont fontItemStack;

		public static SpriteFont[] fontCombatText = new SpriteFont[2];

		public static CompiledText.Style styleFontSmallOutline;

		private static readonly Location[] MENU_TITLE_COORDS = new Location[8]
		{
			new Location(480, 199),
			new Location(480, 237),
			new Location(480, 275),
			new Location(480, 313),
			new Location(480, 351),
			new Location(480, 399),
			new Location(480, 437),
			new Location(480, 475)
		};

		private static readonly Location[] MENU_PAUSE_COORDS = new Location[7]
		{
			new Location(480, 221),
			new Location(480, 259),
			new Location(480, 297),
			new Location(480, 334),
			new Location(480, 372),
			new Location(480, 421),
			new Location(480, 459)
		};

		private static Location[] MENU_SELECT_COORDS = new Location[6]
		{
			new Location(480, 216),
			new Location(480, 253),
			new Location(480, 291),
			new Location(480, 329),
			new Location(480, 367),
			new Location(480, 410)
		};

		private static Location[] MENU_CONFIRM_DELETE_COORDS = new Location[2]
		{
			new Location(480, 356),
			new Location(480, 437)
		};

		private static readonly Location[] MENU_WORLD_SIZE_COORDS = new Location[3]
		{
			new Location(480, 307),
			new Location(480, 367),
			new Location(480, 415)
		};

		private static readonly Location[] MENU_OPTIONS_COORDS = new Location[4]
		{
			new Location(480, 253),
			new Location(480, 313),
			new Location(480, 372),
			new Location(480, 432)
		};

		private static readonly Location[] MENU_SETTINGS_COORDS = new Location[3]
		{
			new Location(480, 270),
			new Location(480, 340),
			new Location(480, 410)
		};

		private string[] menuString = new string[14];

		private byte numMenuItems;

		private sbyte oldMenu;

		private sbyte showPlayer = -1;

		private byte menuSpace = 80;

		private short menuTop = 250;

		private short menuLeft = 480;

		public bool inputTextEnter;

		public bool inputTextCanceled;

		private IAsyncResult kbResult;

		private string focusText;

		private string focusText3;

		private Color focusColor;

		private static CompiledText compiledToolTipText;

		private static string toolTipText;

		private static Item cpItem = default(Item);

		public static void Error(string caption, string desc, bool rememberPreviousMenu = false)
		{
			errorCompiledText = null;
			errorCaption = caption;
			errorDescription = desc;
			main.SetMenu(MenuMode.ERROR, rememberPreviousMenu);
		}

		public void InitGame()
		{
			wasRemovedFromSessionWithoutOurConsent = false;
			restoreOldInventorySection = false;
			inventoryMode = 0;
			inventorySection = InventorySection.ITEMS;
			inventoryItemX = 0;
			inventoryItemY = 0;
			inventoryChestX = 0;
			inventoryChestY = 0;
			inventoryEquipX = 0;
			inventoryEquipY = 1;
			inventoryBuffX = 0;
			inventoryHousingX = 0;
			inventoryHousingY = 0;
			inventoryHousingNpc = -1;
			craftingCategory = Recipe.Category.STRUCTURES;
			craftingSection = CraftingSection.RECIPES;
			craftingShowCraftable = false;
			craftingRecipeX = 0;
			craftingRecipeY = 0;
			craftingIngredientX = 0;
			craftingIngredientY = 0;
			craftingRecipeScrollX = 0f;
			craftingRecipeScrollY = 0f;
			mouseItem.Init();
			trashItem.Init();
			guideItem.Init();
			toolTip.Init();
			helpText = 0;
			showNPCs = false;
			mapScreenCursorX = 0;
			mapScreenCursorY = 0;
			teamSelected = 0;
			pvpSelected = false;
			teamCooldown = 0;
			pvpCooldown = 0;
			npcShop = 0;
			craftGuide = false;
			reforge = false;
			editSign = false;
			signBubble = false;
			npcChatText = null;
			npcChatSelectedItem = 0;
			player.hostile = false;
			player.NetClone(netPlayer);
			InitializeAchievementTriggers();
		}

		private void InitializeAchievementTriggers()
		{
			AchievementTriggers.ReadProfile(signedInGamer);
		}

		public bool TriggerCheckEnabled(Trigger trigger)
		{
			return AchievementTriggers.CheckEnabled(trigger);
		}

		public void SetTriggerState(Trigger trigger)
		{
			AchievementTriggers.SetState(trigger, state: true);
		}

		public static void SetTriggerStateForAll(Trigger trigger)
		{
			for (int i = 0; i < 8; i++)
			{
				Player player = Main.player[i];
				if (player.active != 0)
				{
					player.AchievementTrigger(trigger);
				}
			}
		}

		public static void IncreaseStatisticForAll(StatisticEntry entry)
		{
			if (entry == StatisticEntry.Unknown)
			{
				return;
			}
			for (int i = 0; i < 8; i++)
			{
				Player player = Main.player[i];
				if (player.active != 0)
				{
					player.IncreaseStatistic(entry);
				}
			}
		}

		private void UpdateAchievements()
		{
			if (Statistics.AllSlimeTypesKilled)
			{
				SetTriggerState(Trigger.AllSlimesKilled);
			}
			if (Statistics.AllBossesKilled)
			{
				SetTriggerState(Trigger.AllBossesKilled);
			}
			AchievementTriggers.UpdateAchievements(signedInGamer);
		}

		public static void Initialize(Main game)
		{
			theGame = game;
			Terraria.HowToPlay.UI.GenerateCache(game.GraphicsDevice);
			TextSequenceBlock.GenerateCache(game.GraphicsDevice);
		}

		public void Initialize(PlayerIndex controller)
		{
			this.controller = controller;
			current = this;
			if (main == null)
			{
				main = this;
			}
			for (int num = 13; num >= 0; num--)
			{
				menuItemScale[num] = 0.8f;
			}
			for (int num2 = 4; num2 >= 0; num2--)
			{
				loadPlayer[num2] = new Player();
			}
			createCharacterGUI = Terraria.CreateCharacter.UI.Create(this);
			soundUI = Terraria.SoundUI.UI.Create(this);
			howtoUI = Terraria.HowToPlay.UI.Create(this);
			tips = TextSequenceBlock.CreateTips();
			Statistics = Statistics.Create();
			AchievementTriggers = new TriggerSystem();
			leaderboards = new LeaderboardsUI(this);
		}

		private void SetDefaultSettings()
		{
			soundVolume = 1f;
			musicVolume = 0.75f;
			if (this == main)
			{
				Main.musicVolume = musicVolume;
				Main.soundVolume = soundVolume;
			}
			autoSave = true;
			showItemText = true;
			alternateGrappleControls = false;
			UpdateAlternateGrappleControls();
			Statistics.Init();
			totalSteps = 0u;
			totalPicked = 0u;
			totalBarsCrafted = 0u;
			totalAnvilCrafting = 0u;
			totalWires = 0u;
			totalAirTime = 0u;
			petSpawnMask = 0;
			armorFound.SetAll(value: false);
			isOnline = false;
			isInviteOnly = false;
			blacklist.Clear();
			settingsDirty = false;
		}

		private void InitPlayerStorage()
		{
			SetDefaultSettings();
			numLoadPlayers = 0;
			if (signedInGamer.IsGuest || Main.isTrial)
			{
				playerStorage = null;
				return;
			}
			if (playerStorage == null)
			{
				playerStorage = new StorageDeviceManager(theGame, controller, 196608);
				playerStorage.DeviceSelectorCanceled += DeviceSelectorCanceled;
				playerStorage.DeviceDisconnected += DeviceDisconnected;
				playerStorage.DeviceSelected += DeviceSelected;
				theGame.Components.Add(playerStorage);
			}
			if (playerStorage.Device == null)
			{
				playerStorage.PromptForDevice();
			}
		}

		public bool HasPlayerStorage()
		{
			if (playerStorage != null)
			{
				return playerStorage.Device != null;
			}
			return false;
		}

		public bool CanViewGamerCard()
		{
			if (signedInGamer.IsSignedInToLive && signedInGamer.Privileges.AllowProfileViewing != 0)
			{
				return !GuideExtensions.IsNetworkCableUnplugged;
			}
			return false;
		}

		public bool HasOnline()
		{
			if (!Main.isTrial && signedInGamer.IsSignedInToLive)
			{
				return !GuideExtensions.IsNetworkCableUnplugged;
			}
			return false;
		}

		public bool HasOnlineWithPrivileges()
		{
			if (!Main.isTrial && signedInGamer.IsSignedInToLive && signedInGamer.Privileges.AllowOnlineSessions)
			{
				return !GuideExtensions.IsNetworkCableUnplugged;
			}
			return false;
		}

		public static bool IsUserGeneratedContentAllowed()
		{
			GamerCollection<NetworkGamer> gamerCollection = (Netplay.session != null) ? Netplay.session.RemoteGamers : null;
			SignedInGamerCollection signedInGamers = Gamer.SignedInGamers;
			for (int num = signedInGamers.Count - 1; num >= 0; num--)
			{
				SignedInGamer signedInGamer = signedInGamers[num];
				if (!signedInGamer.IsGuest && signedInGamer.IsSignedInToLive)
				{
					if (signedInGamer.Privileges.AllowUserCreatedContent == GamerPrivilegeSetting.Blocked)
					{
						return false;
					}
					if (gamerCollection != null && signedInGamer.Privileges.AllowUserCreatedContent == GamerPrivilegeSetting.FriendsOnly)
					{
						for (int num2 = gamerCollection.Count - 1; num2 >= 0; num2--)
						{
							NetworkGamer gamer = gamerCollection[num2];
							if (!signedInGamer.IsFriend(gamer))
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		public bool CanPlayOnline()
		{
			if (HasOnlineWithPrivileges())
			{
				return IsUserGeneratedContentAllowed();
			}
			return false;
		}

		public bool CanCommunicate()
		{
			return signedInGamer.Privileges.AllowCommunication != GamerPrivilegeSetting.Blocked;
		}

		public static bool AllPlayersCanPlayOnline()
		{
			if (IsUserGeneratedContentAllowed())
			{
				for (int i = 0; i < 4; i++)
				{
					UI uI = Main.ui[i];
					if (uI.signedInGamer != null && !uI.HasOnlineWithPrivileges())
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public static void LoadContent(ContentManager Content)
		{
			Terraria.CreateCharacter.Assets.LoadContent(Content);
			Terraria.SoundUI.Assets.LoadContent(Content);
			Terraria.HowToPlay.Assets.LoadContent(Content);
			Terraria.Leaderboards.Assets.LoadContent(Content);
			logoTexture = Content.Load<Texture2D>("Images/Logo");
			logo2Texture = Content.Load<Texture2D>("Images/Logo2");
			controlsTexture = Content.Load<Texture2D>("UI/Controller_Layout01");
			progressBarTexture = Content.Load<Texture2D>("UI/ProgressBar");
			textBackTexture = Content.Load<Texture2D>("Images/Text_Back");
			chatBackTexture = Content.Load<Texture2D>("Images/Chat_Back");
			cursorTexture = Content.Load<Texture2D>("Images/Cursor");
			LoadFonts(Content);
		}

		public static void LoadFonts(ContentManager Content)
		{
			fontBig = Content.Load<SpriteFont>("Fonts/big");
			fontBig.Spacing = -24f;
			fontItemStack = Content.Load<SpriteFont>("Fonts/stack");
			fontItemStack.Spacing = -4f;
			FONT_STACK_EXTRA_OFFSET = -5;
			fontCombatText[0] = Content.Load<SpriteFont>("Fonts/combat");
			fontCombatText[0].Spacing = -3f;
			fontCombatText[1] = Content.Load<SpriteFont>("Fonts/combat2");
			fontCombatText[1].Spacing = -4f;
			fontSmall = Content.Load<SpriteFont>("Fonts/small");
			fontSmall.Spacing = -2f;
			fontSmall.LineSpacing = 20;
			fontSmallOutline = Content.Load<SpriteFont>("Fonts/small2");
			fontSmallOutline.Spacing = -5f;
			fontSmallOutline.LineSpacing = 22;
			styleFontSmallOutline = new CompiledText.Style(fontSmallOutline);
		}

		public static void LoadSplitscreenFonts(ContentManager Content)
		{
			fontBig = Content.Load<SpriteFont>("Fonts/big_sc");
			fontBig.Spacing = -13f;
			fontBig.LineSpacing = 19;
			fontItemStack = Content.Load<SpriteFont>("Fonts/stack_sc");
			fontItemStack.Spacing = -4f;
			FONT_STACK_EXTRA_OFFSET = -8;
			fontCombatText[0] = Content.Load<SpriteFont>("Fonts/combat_sc");
			fontCombatText[0].Spacing = -2f;
			fontCombatText[1] = Content.Load<SpriteFont>("Fonts/combat2_sc");
			fontCombatText[1].Spacing = -3f;
			fontSmall = Content.Load<SpriteFont>("Fonts/small_sc");
			fontSmall.Spacing = -2f;
			fontSmall.LineSpacing = 10;
			fontSmallOutline = Content.Load<SpriteFont>("Fonts/small2_sc");
			fontSmallOutline.Spacing = -2f;
			fontSmallOutline.LineSpacing = 13;
			styleFontSmallOutline = new CompiledText.Style(fontSmallOutline);
		}

		private void InvalidateCachedText()
		{
			toolTipText = null;
			npcCompiledChatText = null;
			errorCompiledText = null;
			Terraria.HowToPlay.UI.GenerateCache(theGame.GraphicsDevice);
			TextSequenceBlock.GenerateCache(theGame.GraphicsDevice);
		}

		public static float Spacing(SpriteFont font)
		{
			float num = font.Spacing;
			if (numActiveViews > 1)
			{
				num *= 2f;
			}
			return num;
		}

		public static int LineSpacing(SpriteFont font)
		{
			int num = font.LineSpacing;
			if (numActiveViews > 1)
			{
				num <<= 1;
			}
			return num;
		}

		public static Vector2 MeasureString(SpriteFont font)
		{
			Vector2 result = font.MeasureString(Main.strBuilder);
			if (numActiveViews > 1)
			{
				result.X *= 2f;
				result.Y *= 2f;
			}
			return result;
		}

		public static float MeasureStringX(SpriteFont font)
		{
			float num = font.MeasureString(Main.strBuilder).X;
			if (numActiveViews > 1)
			{
				num *= 2f;
			}
			return num;
		}

		public static Vector2 MeasureString(SpriteFont font, string text)
		{
			Vector2 result = font.MeasureString(text);
			if (numActiveViews > 1)
			{
				result.X *= 2f;
				result.Y *= 2f;
			}
			return result;
		}

		public static void DrawStringLB(SpriteFont font, int x, int y)
		{
			Vector2 vector = font.MeasureString(Main.strBuilder);
			Main.spriteBatch.DrawString(font, Main.strBuilder, new Vector2(x, 540 - y), Color.White, 0f, new Vector2(0f, vector.Y), (numActiveViews <= 1) ? 1 : 2, SpriteEffects.None, 0f);
		}

		public static void DrawStringLT(SpriteFont font, int x, int y, Color c)
		{
			Main.spriteBatch.DrawString(font, Main.strBuilder, new Vector2(x, y), c, 0f, default(Vector2), (numActiveViews <= 1) ? 1 : 2, SpriteEffects.None, 0f);
		}

		public static void DrawStringLT(SpriteFont font, string s, int x, int y, Color c)
		{
			Main.spriteBatch.DrawString(font, s, new Vector2(x, y), c, 0f, default(Vector2), (numActiveViews <= 1) ? 1 : 2, SpriteEffects.None, 0f);
		}

		public static void DrawStringScaled(SpriteFont font, string s, Vector2 pos, Color c, Vector2 pivot, float scale)
		{
			if (numActiveViews > 1)
			{
				scale *= 2f;
				pivot.X *= 0.5f;
				pivot.Y *= 0.5f;
			}
			Main.spriteBatch.DrawString(font, s, pos, c, 0f, pivot, scale, SpriteEffects.None, 0f);
		}

		public static void DrawString(SpriteFont font, string s, Vector2 pos, Color c, float rot, Vector2 pivot, float scale)
		{
			if (numActiveViews > 1)
			{
				scale *= 2f;
				pivot.X *= 0.5f;
				pivot.Y *= 0.5f;
			}
			Main.spriteBatch.DrawString(font, s, pos, c, rot, pivot, scale, SpriteEffects.None, 0f);
		}

		public static void DrawStringScaled(SpriteFont font, Vector2 pos, Color c, Vector2 pivot, float scale)
		{
			if (numActiveViews > 1)
			{
				scale *= 2f;
				pivot.X *= 0.5f;
				pivot.Y *= 0.5f;
			}
			Main.spriteBatch.DrawString(font, Main.strBuilder, pos, c, 0f, pivot, scale, SpriteEffects.None, 0f);
		}

		public static void DrawStringCC(SpriteFont font, string s, int x, int y, Color c)
		{
			float scale = (numActiveViews <= 1) ? 1 : 2;
			Vector2 origin = font.MeasureString(s);
			origin.X = (float)Math.Round((double)origin.X * 0.5);
			origin.Y = (float)Math.Round((double)origin.Y * 0.5);
			Main.spriteBatch.DrawString(font, s, new Vector2(x, y), c, 0f, origin, scale, SpriteEffects.None, 0f);
		}

		public static void DrawStringLC(SpriteFont font, string s, int x, int y, Color c)
		{
			float scale = (numActiveViews <= 1) ? 1 : 2;
			Vector2 origin = font.MeasureString(s);
			origin.X = 0f;
			origin.Y = (float)Math.Round((double)origin.Y * 0.5);
			Main.spriteBatch.DrawString(font, s, new Vector2(x, y), c, 0f, origin, scale, SpriteEffects.None, 0f);
		}

		public static void DrawStringRC(SpriteFont font, string s, int x, int y, Color c)
		{
			float scale = (numActiveViews <= 1) ? 1 : 2;
			Vector2 origin = font.MeasureString(s);
			origin.Y = (float)Math.Round((double)origin.Y * 0.5);
			Main.spriteBatch.DrawString(font, s, new Vector2(x, y), c, 0f, origin, scale, SpriteEffects.None, 0f);
		}

		public static float DrawStringCT(SpriteFont font, string s, int x, int y, Color c)
		{
			float num = (numActiveViews <= 1) ? 1 : 2;
			Vector2 origin = font.MeasureString(s);
			origin.X = (float)Math.Round((double)origin.X * 0.5);
			float result = origin.Y * num;
			origin.Y = 0f;
			Main.spriteBatch.DrawString(font, s, new Vector2(x, y), c, 0f, origin, num, SpriteEffects.None, 0f);
			return result;
		}

		public static float DrawStringCT(SpriteFont font, int x, int y, Color c)
		{
			float num = (numActiveViews <= 1) ? 1 : 2;
			Vector2 origin = font.MeasureString(Main.strBuilder);
			origin.X *= 0.5f;
			float result = origin.Y * num;
			origin.Y = 0f;
			Main.spriteBatch.DrawString(font, Main.strBuilder, new Vector2(x, y), c, 0f, origin, num, SpriteEffects.None, 0f);
			return result;
		}

		public void PrevMenu(int depth = -1)
		{
			Main.PlaySound(11);
			if (depth < 0)
			{
				menuDepth += depth;
				if (menuDepth >= 0)
				{
					SetMenu(prevMenuMode[menuDepth], rememberPrevious: false);
				}
				else
				{
					SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
				}
			}
			else if (depth < menuDepth)
			{
				menuDepth = depth;
				SetMenu(prevMenuMode[depth], rememberPrevious: false);
			}
			else
			{
				SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
			}
		}

		private void ResetPlayerMenuSelection()
		{
			uiX = 0;
			uiY = (short)((numLoadPlayers <= 0) ? 5 : 0);
		}

		public void SetMenu(MenuMode mode, bool rememberPrevious = true, bool reset = false)
		{
			if (settingsDirty)
			{
				SaveSettings();
			}
			numMenuItems = 0;
			if (reset)
			{
				menuDepth = 0;
			}
			if (mode == MenuMode.TITLE)
			{
				Main.SetTutorial(Tutorial.NUM_TUTORIALS);
				if (!Main.isTrial && saveIconMessage == null)
				{
					saveIconMessage = new CompiledText(Lang.menu[4], 470, styleFontSmallOutline);
					saveIconMessageTime = 480;
				}
				if (this.signedInGamer != null)
				{
					this.signedInGamer.Presence.SetPresenceModeString("Menu");
				}
				if (Netplay.isJoiningRemoteInvite)
				{
					if (!Netplay.gamersWaitingToJoinInvite.Contains(this.signedInGamer))
					{
						Exit();
						return;
					}
					mode = MenuMode.CHARACTER_SELECT;
					if (this == main)
					{
						for (int num = Netplay.gamersWaitingToJoinInvite.Count - 1; num >= 0; num--)
						{
							SignedInGamer signedInGamer = Netplay.gamersWaitingToJoinInvite[num];
							if (signedInGamer != this.signedInGamer)
							{
								UI uI = Main.ui[(int)signedInGamer.PlayerIndex];
								uI.SetMenu(MenuMode.CHARACTER_SELECT, rememberPrevious: false, reset: true);
								uI.OpenView();
							}
						}
					}
				}
			}
			if (menuMode != 0)
			{
				for (int num2 = menuHC.Length - 1; num2 >= 0; num2--)
				{
					menuHC[num2] = 0;
				}
				if (rememberPrevious)
				{
					prevMenuMode[menuDepth++] = menuMode;
				}
				uiPos[(uint)menuMode].X = uiX;
				uiPos[(uint)menuMode].Y = uiY;
			}
			menuMode = mode;
			uiX = uiPos[(uint)mode].X;
			uiY = uiPos[(uint)mode].Y;
			uiDelay = 0;
			uiDelayValue = 12;
			switch (mode)
			{
			case MenuMode.PAUSE:
				worldFadeTarget = 0.375f;
				uiWidth = 1;
				uiHeight = 7;
				uiCoords = MENU_PAUSE_COORDS;
				return;
			case MenuMode.TITLE:
				uiWidth = 1;
				uiHeight = 7;
				uiCoords = MENU_TITLE_COORDS;
				return;
			case MenuMode.CHARACTER_SELECT:
				uiWidth = 1;
				uiHeight = 6;
				uiCoords = MENU_SELECT_COORDS;
				initCharacterSelectCoordinates();
				return;
			case MenuMode.CONFIRM_LEAVE_CREATE_CHARACTER:
			case MenuMode.CONFIRM_DELETE_CHARACTER:
			case MenuMode.CONFIRM_DELETE_WORLD:
				uiWidth = 1;
				uiHeight = 2;
				uiCoords = MENU_CONFIRM_DELETE_COORDS;
				return;
			case MenuMode.VOLUME:
				soundUI.UpdateVolumes();
				break;
			case MenuMode.WORLD_SIZE:
				uiWidth = 1;
				uiHeight = 3;
				uiCoords = MENU_WORLD_SIZE_COORDS;
				return;
			case MenuMode.OPTIONS:
				uiWidth = 1;
				uiHeight = 4;
				uiCoords = MENU_OPTIONS_COORDS;
				return;
			case MenuMode.SETTINGS:
				uiWidth = 1;
				uiHeight = 3;
				uiCoords = MENU_SETTINGS_COORDS;
				return;
			case MenuMode.STATUS_SCREEN:
			case MenuMode.NETPLAY:
				progress = 0f;
				progressTotal = 0f;
				uiWidth = 0;
				uiHeight = 1;
				uiCoords = null;
				statusText = null;
				return;
			case MenuMode.WORLD_SELECT:
				if (Netplay.availableSessions.Count == 0 && !Netplay.IsFindingSessions())
				{
					Netplay.FindSessions();
				}
				break;
			case MenuMode.ERROR:
				if (Main.worldGenThread != null)
				{
					Main.worldGenThread.Abort();
					Main.worldGenThread = null;
					WorldGen.gen = false;
				}
				break;
			case MenuMode.MAP:
				worldFadeTarget = 0.375f;
				uiFade = 0f;
				uiFadeTarget = 1f;
				break;
			case MenuMode.CREDITS:
				Credits.Init();
				break;
			case MenuMode.QUIT:
				MessageBox.Show(controller, Lang.menu[15], Lang.inter[35], new string[2]
				{
					Lang.menu[105],
					Lang.menu[104]
				}, autoUpdate: false);
				break;
			case MenuMode.UPSELL:
				theGame.LoadUpsell();
				break;
			}
			uiWidth = 0;
			uiHeight = 0;
			uiCoords = null;
		}

		private void Exit()
		{
			if (numActiveViews == 1)
			{
				if (Main.isTrial)
				{
					SetMenu(MenuMode.UPSELL, rememberPrevious: false, reset: true);
				}
				else
				{
					quit = true;
				}
				return;
			}
			setPlayer(null);
			signedInGamer = null;
			menuType = MenuType.MAIN;
			menuMode = MenuMode.WELCOME;
			selectedMenu = -1;
			focusMenu = -1;
			uiX = 0;
			uiY = 0;
			uiPos = new Location[38];
			worldFade = 0f;
			worldFadeTarget = 1f;
			isStopping = false;
			if (playerStorage != null && !Netplay.isJoiningRemoteInvite)
			{
				theGame.Components.Remove(playerStorage);
				playerStorage.Dispose();
				playerStorage = null;
			}
		}

		public void ExitGame()
		{
			Main.isGameStarted = false;
			for (int i = 0; i < 4; i++)
			{
				UI uI = Main.ui[i];
				if (uI.view != null && uI.menuType != 0)
				{
					uI.view.onStopGame();
				}
			}
			for (int j = 0; j < 4; j++)
			{
				UI uI2 = Main.ui[j];
				if (uI2.view != null && uI2 != main)
				{
					if (uI2.menuType == MenuType.MAIN)
					{
						uI2.Exit();
					}
					else
					{
						uI2.StopGame();
					}
				}
			}
			main.StopGame();
		}

		public void StopGame()
		{
			CloseInventory();
			inventorySection = InventorySection.ITEMS;
			hotbarItemNameTime = 210;
			quickAccessDisplayTime = 0;
			quickAccessUp = -1;
			quickAccessDown = -1;
			quickAccessLeft = -1;
			quickAccessRight = -1;
			isStopping = true;
			worldFadeTarget = 1f;
			if (Main.saveOnExit)
			{
				statusText = Lang.menu[54];
			}
			else
			{
				statusText = "";
			}
			if (menuMode != MenuMode.ERROR)
			{
				SetMenu(MenuMode.STATUS_SCREEN, rememberPrevious: false);
			}
			menuType = MenuType.MAIN;
			if (this == main)
			{
				if (Main.saveOnExit)
				{
					Main.saveOnExit = false;
					WorldGen.SaveAndQuit();
					return;
				}
				Netplay.disconnect = true;
				LoadPlayers();
				if (menuMode != MenuMode.ERROR)
				{
					SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
				}
			}
			else if (!Main.saveOnExit)
			{
				Exit();
			}
		}

		public void PrepareDraw(int pass)
		{
			if (view != null && menuType != 0)
			{
				current = this;
				view.PrepareDraw(pass);
			}
		}

		public void Draw()
		{
			if (view != null)
			{
				current = this;
				view.DrawBg(this);
				if (menuType != 0)
				{
					view.DrawWorld();
					DrawCursor();
					view.SetScreenView();
				}
				DrawTopLayer();
				if (menuType != MenuType.NONE)
				{
					DrawMenu();
				}
				else if (Main.tutorialState < Tutorial.THE_END)
				{
					DrawTutorial();
				}
				Main.spriteBatch.End();
			}
		}

		private void DrawTopLayer()
		{
			if (worldFade < 1f)
			{
				Main.DrawSolidRect(new Rectangle(-1, -1, view.viewWidth, 540), new Color(0f, 0f, 0f, 1f - worldFade));
			}
			if (worldFade != worldFadeTarget)
			{
				if (worldFadeTarget < worldFade)
				{
					worldFade -= 71f / (678f * (float)Math.PI);
					if (worldFadeTarget > worldFade)
					{
						worldFade = worldFadeTarget;
					}
				}
				else
				{
					worldFade += 71f / (678f * (float)Math.PI);
					if (worldFadeTarget < worldFade)
					{
						worldFade = worldFadeTarget;
					}
				}
			}
			if (menuType == MenuType.NONE)
			{
				DrawInterface();
				if (inventoryMode == 0 && !player.ghost)
				{
					DrawHud();
				}
			}
		}

		private void DrawTutorial()
		{
			DrawDialog(new Vector2(view.viewWidth - chatBackTexture.Width >> 1, 540 - view.SAFE_AREA_OFFSET_B - 36), new Color(128, 128, 128, 64), new Color(255, 255, 255, 255), Main.tutorialText, null, anchorBottom: true);
		}

		private void UpdateMenu()
		{
			MenuMode menuMode = this.menuMode;
			numMenuItems = 0;
			menuTop = 250;
			menuLeft = (short)((view != null) ? (view.viewWidth >> 1) : 480);
			menuSpace = 80;
			showPlayer = -1;
			for (int i = 0; i < 14; i++)
			{
				noFocus[i] = false;
				blockFocus[i] = false;
				menuY[i] = 0;
				menuScale[i] = 1f;
			}
			if (this.menuMode == MenuMode.ERROR)
			{
				numMenuItems = 0;
				if (IsBackButtonTriggered())
				{
					SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
				}
			}
			else if (this.menuMode == MenuMode.LOAD_FAILED_NO_BACKUP)
			{
				numMenuItems = 1;
				menuString[0] = Lang.menu[9];
				noFocus[0] = true;
				menuTop = 300;
				if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.STATUS_SCREEN)
			{
				numMenuItems = 1;
				menuString[0] = statusText;
				noFocus[0] = true;
				menuTop = 175;
				tips.Update();
			}
			else if (this.menuMode == MenuMode.NETPLAY)
			{
				numMenuItems = 1;
				menuString[0] = statusText;
				noFocus[0] = true;
				menuTop = 175;
				tips.Update();
				if (IsBackButtonTriggered())
				{
					if (Netplay.sessionThread != null)
					{
						Netplay.disconnect = true;
					}
					PrevMenu();
				}
				else if (Netplay.sessionThread == null)
				{
					bool flag = true;
					for (int j = 0; j < 4; j++)
					{
						UI uI = Main.ui[j];
						if (uI.view != null && uI.menuMode != MenuMode.NETPLAY)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						Netplay.StartClient();
					}
				}
			}
			else if (this.menuMode == MenuMode.WAITING_SCREEN)
			{
				numMenuItems = 1;
				menuString[0] = Lang.menu[51];
				noFocus[0] = true;
				menuTop = 300;
				if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
				else if (Main.isGameStarted && !Main.isGamePaused)
				{
					if (Netplay.session == null)
					{
						Exit();
						return;
					}
					int count = Netplay.session.AllGamers.Count;
					if (count < 8)
					{
						int privateGamerSlots = Netplay.session.PrivateGamerSlots;
						if (privateGamerSlots > 0)
						{
							if (Main.netMode == 1)
							{
								NetMessage.CreateMessage0(66);
								NetMessage.SendMessage();
								privateSlots = (byte)privateGamerSlots;
								SetMenu(MenuMode.WAITING_FOR_PUBLIC_SLOT, rememberPrevious: false);
								return;
							}
							Netplay.session.PrivateGamerSlots--;
						}
						try
						{
							Netplay.session.AddLocalGamer(this.signedInGamer);
							SetMenu(MenuMode.WAITING_FOR_PLAYER_ID, rememberPrevious: false);
						}
						catch
						{
							Exit();
							return;
						}
					}
					else
					{
						menuString[0] = Lang.gen[57];
					}
				}
			}
			else if (this.menuMode == MenuMode.WAITING_FOR_PUBLIC_SLOT)
			{
				numMenuItems = 1;
				menuString[0] = Lang.menu[51];
				noFocus[0] = true;
				menuTop = 300;
				if (Netplay.session.PrivateGamerSlots < privateSlots)
				{
					try
					{
						Netplay.session.AddLocalGamer(this.signedInGamer);
						SetMenu(MenuMode.WAITING_FOR_PLAYER_ID, rememberPrevious: false);
					}
					catch
					{
						Exit();
						return;
					}
				}
				else if (IsBackButtonTriggered())
				{
					NetMessage.CreateMessage0(67);
					NetMessage.SendMessage();
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.WAITING_FOR_PLAYER_ID)
			{
				numMenuItems = 1;
				menuString[0] = Lang.menu[51];
				noFocus[0] = true;
				menuTop = 300;
				if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.LEADERBOARDS)
			{
				if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
				else
				{
					leaderboards.Update();
				}
			}
			else if (this.menuMode == MenuMode.TITLE)
			{
				if (main != this)
				{
					Exit();
					return;
				}
				menuTop = 172;
				menuSpace = 42;
				menuString[0] = Lang.menu[13];
				menuString[1] = Lang.menu[89];
				menuString[2] = Lang.menu[106];
				menuString[3] = Lang.menu[107];
				menuString[4] = Lang.menu[108];
				if (!Main.isTrial)
				{
					MENU_TITLE_COORDS[0].X = 480;
					menuHC[0] = 0;
				}
				else
				{
					MENU_TITLE_COORDS[0].X = 0;
					menuHC[0] = 3;
					if (uiY == 0)
					{
						uiY = 1;
					}
				}
				if (!this.signedInGamer.IsGuest && HasOnline())
				{
					MENU_TITLE_COORDS[2].X = 480;
					menuHC[2] = 0;
				}
				else
				{
					MENU_TITLE_COORDS[2].X = 0;
					menuHC[2] = 3;
					if (uiY == 2)
					{
						uiY = 3;
					}
				}
				if (!this.signedInGamer.IsGuest && !Main.isTrial)
				{
					MENU_TITLE_COORDS[3].X = 480;
					menuHC[3] = 0;
				}
				else
				{
					MENU_TITLE_COORDS[3].X = 0;
					menuHC[3] = 3;
					if (uiY == 3)
					{
						uiY = 4;
					}
				}
				if (Main.isTrial)
				{
					menuString[5] = Lang.menu[109];
					if (this.signedInGamer.Privileges.AllowPurchaseContent)
					{
						MENU_TITLE_COORDS[5].X = 480;
						menuHC[5] = 0;
					}
					else
					{
						MENU_TITLE_COORDS[5].X = 0;
						menuHC[5] = 3;
						if (uiY == 5)
						{
							uiY = 6;
						}
					}
					menuString[6] = Lang.menu[15];
					numMenuItems = 7;
					MENU_TITLE_COORDS[6].X = 480;
				}
				else
				{
					menuString[5] = Lang.menu[15];
					numMenuItems = 6;
					MENU_TITLE_COORDS[6].X = 0;
				}
				for (int num = numMenuItems - 1; num >= 0; num--)
				{
					menuScale[num] = 0.75f;
				}
				if (selectedMenu == 0)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.CHARACTER_SELECT);
					ResetPlayerMenuSelection();
				}
				else if (selectedMenu == 1)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.STATUS_SCREEN);
					Main.StartTutorial();
				}
				else if (selectedMenu == 2)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.LEADERBOARDS);
					leaderboards.InitializeData();
				}
				else if (selectedMenu == 3)
				{
					ShowAchievements();
				}
				else if (selectedMenu == 4)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.OPTIONS);
				}
				else if (selectedMenu == 5)
				{
					if (Main.isTrial)
					{
						if (!Guide.IsVisible)
						{
							bool flag2;
							do
							{
								flag2 = false;
								try
								{
									GuideExtensions.ShowMarketplace(controller, 6359384554213474305uL);
								}
								catch (GuideAlreadyVisibleException)
								{
									Thread.Sleep(32);
									flag2 = true;
								}
							}
							while (flag2);
						}
					}
					else
					{
						SetMenu(MenuMode.QUIT);
					}
				}
				else if (selectedMenu == 6)
				{
					SetMenu(MenuMode.QUIT);
				}
				else if (IsButtonTriggered(Buttons.X))
				{
					if (playerStorage != null)
					{
						playerStorage.PromptForDevice();
					}
				}
				else if (IsButtonTriggered(Buttons.Y))
				{
					ShowParty();
				}
			}
			else if (this.menuMode == MenuMode.PAUSE)
			{
				menuString[0] = Lang.menu[112];
				int num2 = 1;
				if (Main.isTrial)
				{
					menuString[num2] = Lang.menu[109];
					if (this.signedInGamer.Privileges.AllowPurchaseContent)
					{
						MENU_PAUSE_COORDS[num2].X = 480;
						menuHC[num2] = 0;
					}
					else
					{
						MENU_PAUSE_COORDS[num2].X = 0;
						menuHC[num2] = 3;
						if (uiY == num2)
						{
							uiY = 0;
						}
					}
					num2++;
					numMenuItems = 7;
					MENU_PAUSE_COORDS[6].X = 480;
				}
				else
				{
					numMenuItems = 6;
					MENU_PAUSE_COORDS[6].X = 0;
				}
				if (!HasOnline())
				{
					MENU_PAUSE_COORDS[num2 + 1].X = 0;
					menuHC[num2 + 1] = 3;
					if (uiY == num2 + 1)
					{
						uiY = 0;
					}
				}
				else
				{
					MENU_PAUSE_COORDS[num2 + 1].X = 480;
					menuHC[num2 + 1] = 0;
				}
				if (this.signedInGamer.IsGuest || Main.isTrial)
				{
					MENU_PAUSE_COORDS[num2 + 2].X = 0;
					menuHC[num2 + 2] = 3;
					if (uiY == num2 + 2)
					{
						uiY = 0;
					}
				}
				else
				{
					MENU_PAUSE_COORDS[num2 + 2].X = 480;
					menuHC[num2 + 2] = 0;
				}
				if (WorldGen.saveLock || Main.IsTutorial() || !HasPlayerStorage())
				{
					MENU_PAUSE_COORDS[num2 + 3].X = 0;
					menuHC[num2 + 3] = 3;
					if (uiY == num2 + 3)
					{
						uiY = 0;
					}
				}
				else
				{
					MENU_PAUSE_COORDS[num2 + 3].X = 480;
					menuHC[num2 + 3] = 0;
				}
				if (WorldGen.saveLock)
				{
					MENU_PAUSE_COORDS[num2 + 4].X = 0;
					menuHC[num2 + 4] = 3;
					if (uiY == num2 + 4)
					{
						uiY = 0;
					}
				}
				else
				{
					MENU_PAUSE_COORDS[num2 + 4].X = 480;
					menuHC[num2 + 4] = 0;
				}
				menuString[num2] = Lang.menu[108];
				menuString[num2 + 1] = Lang.menu[106];
				menuString[num2 + 2] = Lang.menu[107];
				menuString[num2 + 3] = Lang.menu[99];
				menuString[num2 + 4] = Lang.menu[101];
				for (int k = 0; k < numMenuItems; k++)
				{
					menuScale[k] = 0.75f;
				}
				menuTop = 200;
				menuSpace = 40;
				if (selectedMenu == 0 || IsButtonUntriggered(Buttons.Start) || IsBackButtonTriggered())
				{
					ResumeGame();
				}
				else if (Main.netMode == 1 && IsButtonTriggered(Buttons.RightShoulder))
				{
					MessageBox.Show(controller, Lang.inter[72], Lang.inter[73], new string[2]
					{
						Lang.menu[105],
						Lang.menu[104]
					}, autoUpdate: false);
					SetMenu(MenuMode.BLACKLIST);
				}
				else if (num2 > 1 && selectedMenu == 1)
				{
					if (!Guide.IsVisible)
					{
						bool flag3;
						do
						{
							flag3 = false;
							try
							{
								GuideExtensions.ShowMarketplace(controller, 6359384554213474305uL);
							}
							catch (GuideAlreadyVisibleException)
							{
								Thread.Sleep(32);
								flag3 = true;
							}
						}
						while (flag3);
					}
				}
				else if (selectedMenu == num2)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.OPTIONS);
				}
				else if (selectedMenu == num2 + 1)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.LEADERBOARDS);
					leaderboards.InitializeData();
				}
				else if (selectedMenu == num2 + 2)
				{
					ShowAchievements();
				}
				else if (selectedMenu == num2 + 3)
				{
					Main.PlaySound(10);
					WorldGen.saveAllWhilePlaying();
				}
				else if (selectedMenu == num2 + 4)
				{
					Main.PlaySound(10);
					Main.saveOnExit = (!Main.IsTutorial() && autoSave && IsStorageEnabledForAnyPlayer());
					if (!Main.saveOnExit && !Main.IsTutorial())
					{
						MessageBox.Show(options: (!IsStorageEnabledForAnyPlayer()) ? new string[2]
						{
							Lang.inter[0],
							Lang.inter[1]
						} : new string[3]
						{
							Lang.inter[0],
							Lang.inter[1],
							Lang.inter[2]
						}, controller: controller, caption: Lang.menu[100], contents: Lang.inter[5], autoUpdate: false);
					}
					SetMenu(MenuMode.EXIT);
				}
			}
			else if (this.menuMode == MenuMode.EXIT)
			{
				if (MessageBox.IsVisible())
				{
					if (!MessageBox.IsAutoUpdate() && MessageBox.Update())
					{
						int result = MessageBox.GetResult();
						if (result <= 0)
						{
							PrevMenu();
						}
						else
						{
							Main.saveOnExit = (result == 2);
						}
					}
				}
				else
				{
					ExitGame();
				}
			}
			else if (this.menuMode == MenuMode.EXIT_UGC_BLOCKED)
			{
				if (MessageBox.IsVisible())
				{
					if (!MessageBox.IsAutoUpdate() && MessageBox.Update())
					{
						int result2 = MessageBox.GetResult();
						Main.saveOnExit = (result2 != 1);
					}
				}
				else
				{
					ExitGame();
				}
			}
			else if (this.menuMode == MenuMode.BLACKLIST)
			{
				if (MessageBox.IsVisible() && !MessageBox.IsAutoUpdate() && MessageBox.Update())
				{
					int result3 = MessageBox.GetResult();
					if (result3 <= 0)
					{
						PrevMenu();
					}
					else
					{
						blacklist.Add(Main.GetWorldId());
						SaveSettings();
						ExitGame();
					}
				}
			}
			else if (this.menuMode == MenuMode.BLACKLIST_REMOVE)
			{
				if (MessageBox.IsVisible() && !MessageBox.IsAutoUpdate() && MessageBox.Update())
				{
					int result4 = MessageBox.GetResult();
					if (result4 <= 0)
					{
						if (menuType == MenuType.MAIN)
						{
							Exit();
							return;
						}
						ExitGame();
					}
					else
					{
						blacklist.Remove(Main.GetWorldId());
						settingsDirty = true;
						PrevMenu();
						if (menuType != 0)
						{
							menuType = MenuType.NONE;
						}
						Main.checkWorldId = true;
					}
				}
			}
			else if (this.menuMode == MenuMode.MAP)
			{
				if (miniMap.isThreadDone)
				{
					if (IsBackButtonTriggered())
					{
						miniMap.DestroyMap();
						ResumeGame();
					}
					else
					{
						miniMap.UpdateMap(this);
					}
				}
			}
			else if (this.menuMode == MenuMode.CHARACTER_SELECT)
			{
				menuLeft += 80;
				menuTop = 200;
				menuSpace = 40;
				for (int l = 0; l < 5; l++)
				{
					if (l < numLoadPlayers)
					{
						menuString[l] = loadPlayer[l].characterName;
						menuHC[l] = loadPlayer[l].difficulty;
						MENU_SELECT_COORDS[l].X = 480;
					}
					else
					{
						menuString[l] = null;
						MENU_SELECT_COORDS[l].X = 0;
					}
				}
				if (numLoadPlayers == 5)
				{
					blockFocus[5] = true;
					menuString[5] = null;
					MENU_SELECT_COORDS[5].X = 0;
				}
				else
				{
					menuString[5] = Lang.menu[16];
					MENU_SELECT_COORDS[5].X = 480;
				}
				numMenuItems = 6;
				for (int m = 0; m < 6; m++)
				{
					menuScale[m] = 0.8f;
				}
				if (IsBackButtonTriggered() && (Netplay.gamersWhoReceivedInvite.Count < 2 || !Netplay.gamersWhoReceivedInvite.Contains(this.signedInGamer)))
				{
					CancelInvite(this.signedInGamer);
					SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
				}
				else if (selectedMenu == 5)
				{
					Main.PlaySound(10);
					loadPlayer[numLoadPlayers] = new Player();
					loadPlayer[numLoadPlayers].characterName = this.signedInGamer.Gamertag;
					loadPlayer[numLoadPlayers].inventory[0].SetDefaults("Copper Shortsword");
					loadPlayer[numLoadPlayers].inventory[0].Prefix(-1);
					loadPlayer[numLoadPlayers].inventory[1].SetDefaults("Copper Pickaxe");
					loadPlayer[numLoadPlayers].inventory[1].Prefix(-1);
					loadPlayer[numLoadPlayers].inventory[2].SetDefaults("Copper Axe");
					loadPlayer[numLoadPlayers].inventory[2].Prefix(-1);
					createCharacterGUI.ApplyDefaultAttributes(loadPlayer[numLoadPlayers]);
					SetMenu(MenuMode.CREATE_CHARACTER);
				}
				else if (selectedMenu >= 0)
				{
					Main.PlaySound(10);
					selectedPlayer = selectedMenu;
					setPlayer(loadPlayer[selectedPlayer].DeepCopy());
					playerPathName = loadPlayerPath[selectedPlayer];
					if (Netplay.isJoiningRemoteInvite)
					{
						SetMenu(MenuMode.NETPLAY);
						statusText = Lang.menu[75];
					}
					else if (this != main)
					{
						SetMenu(MenuMode.WAITING_SCREEN);
					}
					else
					{
						SetMenu(MenuMode.WORLD_SELECT);
					}
				}
				else if (focusMenu >= 0 && focusMenu < numLoadPlayers)
				{
					if (IsButtonTriggered(Buttons.X))
					{
						selectedPlayer = focusMenu;
						Main.PlaySound(10);
						SetMenu(MenuMode.CONFIRM_DELETE_CHARACTER);
					}
					else
					{
						showPlayer = focusMenu;
					}
				}
			}
			else if (this.menuMode == MenuMode.CREATE_CHARACTER)
			{
				Player player = loadPlayer[numLoadPlayers];
				createCharacterGUI.Update(player);
			}
			else if (this.menuMode == MenuMode.CONFIRM_LEAVE_CREATE_CHARACTER)
			{
				menuString[0] = Lang.menu[49];
				noFocus[0] = true;
				menuString[1] = Lang.menu[104];
				menuString[2] = Lang.menu[105];
				numMenuItems = 3;
				if (selectedMenu == 1)
				{
					PrevMenu(-2);
				}
				else if (selectedMenu == 2 || IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.NAME_CHARACTER)
			{
				string characterName = loadPlayer[numLoadPlayers].characterName;
				string text = GetInputText(characterName, Lang.menu[53], Lang.menu[45], validate: false).text;
				numMenuItems = 0;
				if (inputTextEnter)
				{
					if (inputTextCanceled || text.Length == 0)
					{
						PrevMenu();
					}
					else
					{
						Main.PlaySound(10);
						if (text.Length > 16)
						{
							text = text.Substring(0, 16);
						}
						Player player2 = loadPlayer[numLoadPlayers];
						player2.characterName = text;
						player2.ui = this;
						loadPlayerPath[numLoadPlayers] = nextLoadPlayer();
						player2.Save(loadPlayerPath[numLoadPlayers]);
						PrevMenu(-2);
						selectedPlayer = numLoadPlayers;
						showPlayer = numLoadPlayers;
						uiY = numLoadPlayers;
						MENU_SELECT_COORDS[uiY].X = 480;
						numLoadPlayers++;
					}
				}
			}
			else if (this.menuMode == MenuMode.CONFIRM_DELETE_CHARACTER)
			{
				menuString[0] = Lang.menu[46] + loadPlayer[selectedPlayer].name + "?";
				noFocus[0] = true;
				menuString[1] = Lang.menu[104];
				menuString[2] = Lang.menu[105];
				numMenuItems = 3;
				if (selectedMenu == 2 || IsBackButtonTriggered())
				{
					PrevMenu();
				}
				else if (selectedMenu == 1)
				{
					ErasePlayer(selectedPlayer);
					Main.PlaySound(10);
					PrevMenu();
					ResetPlayerMenuSelection();
				}
			}
			else if (this.menuMode == MenuMode.WORLD_SELECT)
			{
				WorldSelect.Update();
			}
			else if (this.menuMode == MenuMode.GAME_MODE)
			{
				GameMode.Update();
			}
			else if (this.menuMode == MenuMode.NAME_WORLD)
			{
				string text2 = GetInputText(Lang.menu[56], Lang.menu[55], Lang.menu[48], validate: false).text;
				numMenuItems = 0;
				if (inputTextEnter)
				{
					if (inputTextCanceled || text2.Length == 0)
					{
						PrevMenu();
					}
					else
					{
						if (text2.Length > 20)
						{
							text2 = text2.Substring(0, 20);
						}
						SetMenu(MenuMode.STATUS_SCREEN, rememberPrevious: false);
						WorldSelect.CreateWorld(text2);
					}
				}
			}
			else if (this.menuMode == MenuMode.CONFIRM_DELETE_WORLD)
			{
				menuString[0] = Lang.menu[46] + WorldSelect.WorldName() + '?';
				noFocus[0] = true;
				menuString[1] = Lang.menu[104];
				menuString[2] = Lang.menu[105];
				numMenuItems = 3;
				if (selectedMenu == 2 || IsBackButtonTriggered())
				{
					PrevMenu();
				}
				else if (selectedMenu == 1)
				{
					WorldSelect.EraseWorld();
					Main.PlaySound(10);
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.OPTIONS)
			{
				menuTop = 220;
				menuSpace = 57;
				menuString[0] = Lang.menu[110];
				menuString[1] = Lang.menu[111];
				menuString[2] = Lang.menu[14];
				if (menuType == MenuType.MAIN)
				{
					menuString[3] = Lang.menu[47];
					MENU_OPTIONS_COORDS[3].X = 480;
					numMenuItems = 4;
				}
				else
				{
					MENU_OPTIONS_COORDS[3].X = 0;
					if (uiY == 3)
					{
						uiY = 0;
					}
					numMenuItems = 3;
				}
				if (selectedMenu == 0)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.HOW_TO_PLAY);
				}
				else if (selectedMenu == 1)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.CONTROLS);
				}
				else if (selectedMenu == 2)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.SETTINGS);
				}
				else if (selectedMenu == 3)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.CREDITS);
				}
				else if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.HOW_TO_PLAY)
			{
				howtoUI.Update();
				if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.SHOW_SIGN_IN)
			{
				if (!Guide.IsVisible)
				{
					try
					{
						Guide.ShowSignIn(1, this != main && Main.netMode != 0);
						this.menuMode = MenuMode.SIGN_IN;
					}
					catch (GuideAlreadyVisibleException)
					{
					}
				}
			}
			else if (this.menuMode == MenuMode.SIGN_IN)
			{
				if (!Guide.IsVisible)
				{
					if (this.signedInGamer == null)
					{
						foreach (SignedInGamer signedInGamer2 in Gamer.SignedInGamers)
						{
							if (signedInGamer2.PlayerIndex == controller)
							{
								signedInGamer = signedInGamer2;
								signedInGamer.Presence.SetPresenceModeString("Menu");
								InitPlayerStorage();
								break;
							}
						}
					}
					if (signedInGamer != null)
					{
						if (!IsGamerValid())
						{
							MessageBox.Show(controller, Lang.menu[5], Lang.inter[43], new string[1]
							{
								Lang.menu[90]
							});
							this.menuMode = MenuMode.SIGN_IN_FAILED;
						}
						else if (playerStorage == null || playerStorage.isDone)
						{
							PrevMenu();
						}
					}
					else
					{
						this.menuMode = MenuMode.SIGN_IN_FAILED;
					}
				}
			}
			else if (this.menuMode == MenuMode.CONTROLS)
			{
				numMenuItems = 0;
				if (IsButtonTriggered(Buttons.A))
				{
					alternateGrappleControls = !alternateGrappleControls;
					UpdateAlternateGrappleControls();
					settingsDirty = true;
				}
				else if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.SETTINGS)
			{
				menuSpace = 60;
				numMenuItems = 3;
				if (this == main)
				{
					menuString[0] = Lang.menu[65];
					MENU_SETTINGS_COORDS[0].X = 480;
				}
				else
				{
					menuString[0] = "";
					MENU_SETTINGS_COORDS[0].X = 0;
					if (uiY == 0)
					{
						uiY = 1;
					}
				}
				if (autoSave)
				{
					menuString[1] = Lang.menu[67];
				}
				else
				{
					menuString[1] = Lang.menu[68];
				}
				if (HasPlayerStorage())
				{
					MENU_SETTINGS_COORDS[1].X = 480;
					menuHC[1] = 0;
				}
				else
				{
					MENU_SETTINGS_COORDS[1].X = 0;
					menuHC[1] = 3;
					if (uiY == 1)
					{
						uiY = 2;
					}
				}
				if (showItemText)
				{
					menuString[2] = Lang.menu[71];
				}
				else
				{
					menuString[2] = Lang.menu[72];
				}
				if (selectedMenu == 2)
				{
					Main.PlaySound(12);
					showItemText = !showItemText;
					settingsDirty = true;
				}
				else if (selectedMenu == 1)
				{
					Main.PlaySound(12);
					autoSave = !autoSave;
					settingsDirty = true;
				}
				else if (selectedMenu == 0)
				{
					Main.PlaySound(10);
					SetMenu(MenuMode.VOLUME);
				}
				else if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.VOLUME)
			{
				soundUI.Update();
				menuTop = 200;
				menuSpace = 60;
				numMenuItems = 1;
				menuString[0] = Lang.menu[65];
				noFocus[0] = true;
				if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.WORLD_SIZE)
			{
				menuTop = 190;
				menuSpace = 60;
				menuY[1] = 30;
				menuY[2] = 30;
				menuY[3] = 30;
				menuY[4] = 40;
				menuString[0] = Lang.menu[91];
				noFocus[0] = true;
				menuString[1] = Lang.menu[92];
				menuString[2] = Lang.menu[93];
				menuString[3] = Lang.menu[94];
				numMenuItems = 4;
				if (IsBackButtonTriggered())
				{
					PrevMenu();
				}
				else if (selectedMenu > 0)
				{
					if (selectedMenu == 1)
					{
						Main.maxTilesX = 4200;
						Main.maxTilesY = 1200;
					}
					else if (selectedMenu == 2)
					{
						Main.maxTilesX = 4620;
						Main.maxTilesY = 1320;
					}
					else
					{
						Main.maxTilesX = 5040;
						Main.maxTilesY = 1440;
					}
					Main.PlaySound(10);
					WorldGen.setWorldSize();
					ClearInput();
					SetMenu(MenuMode.NAME_WORLD);
				}
			}
			else if (this.menuMode == MenuMode.QUIT)
			{
				if (!MessageBox.IsAutoUpdate() && MessageBox.Update())
				{
					int result5 = MessageBox.GetResult();
					if (result5 > 0)
					{
						Exit();
						return;
					}
					PrevMenu();
				}
			}
			else if (this.menuMode == MenuMode.SIGN_IN_FAILED)
			{
				if (!MessageBox.IsVisible())
				{
					if (this == main)
					{
						SetMenu(MenuMode.WELCOME, rememberPrevious: false, reset: true);
					}
					else
					{
						Exit();
					}
				}
			}
			else if (this.menuMode == MenuMode.CREDITS)
			{
				numMenuItems = 0;
				Credits.Update();
			}
			else if (this.menuMode == MenuMode.UPSELL)
			{
				numMenuItems = 0;
				if (IsBackButtonTriggered())
				{
					SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
				}
				else if (IsButtonTriggered(Buttons.A))
				{
					quit = true;
				}
				else if (IsButtonTriggered(Buttons.X) && signedInGamer.Privileges.AllowPurchaseContent && !Guide.IsVisible)
				{
					bool flag4;
					do
					{
						flag4 = false;
						try
						{
							GuideExtensions.ShowMarketplace(controller, 6359384554213474305uL);
						}
						catch (GuideAlreadyVisibleException)
						{
							Thread.Sleep(32);
							flag4 = true;
						}
					}
					while (flag4);
				}
			}
			if (this.menuMode != menuMode)
			{
				numMenuItems = 0;
				for (int n = 0; n < 14; n++)
				{
					menuItemScale[n] = 0.8f;
				}
			}
			focusMenu = -1;
			selectedMenu = -1;
			for (int num3 = 0; num3 < numMenuItems; num3++)
			{
				if (menuString[num3] != null && mouseY > menuTop + menuSpace * num3 + menuY[num3] && (float)mouseY < (float)(menuTop + menuSpace * num3 + menuY[num3]) + 50f * menuScale[num3] && Main.hasFocus && !noFocus[num3] && !blockFocus[num3])
				{
					focusMenu = (sbyte)num3;
					if (oldMenu != focusMenu)
					{
						Main.PlaySound(12);
					}
					if ((this.menuMode != MenuMode.PAUSE) ? IsSelectButtonTriggered() : IsButtonTriggered(Buttons.A))
					{
						selectedMenu = (sbyte)num3;
					}
				}
			}
			oldMenu = focusMenu;
		}

		private void DrawSaveIconMessage()
		{
			DrawDialog(new Vector2(960 - chatBackTexture.Width >> 1, 220f), new Color(128, 128, 128, 64), new Color(255, 255, 255, 255), saveIconMessage, Lang.menu[3]);
			SpriteSheet<_sheetSprites>.Draw(642, 480, 304, Color.White, (float)((double)Main.frameCounter * (-Math.PI / 60.0)), 1f);
		}

		private void DrawMenu()
		{
			if (menuMode != MenuMode.CONTROLS && menuMode != MenuMode.MAP && menuMode != MenuMode.HOW_TO_PLAY && menuMode != MenuMode.LEADERBOARDS && menuMode != MenuMode.WORLD_SELECT && menuMode != MenuMode.CREATE_CHARACTER && menuMode != MenuMode.CREDITS && menuMode != MenuMode.UPSELL)
			{
				DrawLogo();
			}
			if (saveIconMessageTime > 0)
			{
				if (!Guide.IsVisible)
				{
					saveIconMessageTime--;
					if (IsButtonTriggered(Buttons.B))
					{
						saveIconMessageTime = 0;
					}
					DrawSaveIconMessage();
					DrawControls();
				}
				return;
			}
			if (menuMode == MenuMode.STATUS_SCREEN || menuMode == MenuMode.NETPLAY)
			{
				int num = menuTop + 100;
				float num2 = progress * numProgressStepsInv + progressTotal;
				if (num2 > 0f)
				{
					Rectangle value = default(Rectangle);
					value.Height = progressBarTexture.Height >> 1;
					value.Width = (int)((float)progressBarTexture.Width * num2);
					Vector2 position = default(Vector2);
					position.X = view.viewWidth - progressBarTexture.Width >> 1;
					position.Y = num;
					Main.spriteBatch.Draw(progressBarTexture, position, value, Color.White);
					value.X = value.Width;
					value.Y = value.Height;
					position.X += value.Width;
					value.Width = progressBarTexture.Width - value.Width;
					Main.spriteBatch.Draw(progressBarTexture, position, value, Color.White);
				}
				view.SetScreenViewWideCentered();
				tips.Draw();
				view.SetScreenView();
			}
			else if (menuMode == MenuMode.CONTROLS)
			{
				int num3 = view.viewWidth >> 1;
				Vector2 position2 = default(Vector2);
				position2.X = num3 - (controlsTexture.Width >> 1);
				position2.Y = 540 - controlsTexture.Height >> 1;
				Main.spriteBatch.Draw(controlsTexture, position2, Color.White);
				int num4 = (int)MeasureString(fontSmall, Lang.inter[24]).X + 60;
				num3 = view.viewWidth - view.SAFE_AREA_OFFSET_R - num4;
				int num5 = 464 - view.SAFE_AREA_OFFSET_B;
				view.ui.DrawInventoryCursor(num3, num5, 1.0);
				if (alternateGrappleControls)
				{
					SpriteSheet<_sheetSprites>.Draw(202, num3 + 10, num5 + 10, Color.White);
				}
				DrawStringLC(fontSmall, Lang.inter[24], num3 + 60, num5 + 26, Color.White);
				ControlDesc[] array = Lang.controls();
				for (int num6 = array.Length - 1; num6 >= 0; num6--)
				{
					int alignment = array[num6].alignment;
					int num7 = array[num6].X;
					if (view.viewWidth > 960)
					{
						num7 += 480;
					}
					int num8 = array[num6].Y;
					string text = array[num6].text;
					switch (num6)
					{
					case 0:
						if (alternateGrappleControls)
						{
							text = array[9].text;
						}
						break;
					case 5:
						text = ((!alternateGrappleControls) ? (text + array[9].text) : (text + array[0].text));
						break;
					}
					Vector2 vector = MeasureString(fontSmallOutline, text);
					if (alignment < 2)
					{
						num7 -= (int)vector.X >> 1;
						if (alignment == 0)
						{
							num8 -= (int)vector.Y;
						}
					}
					else
					{
						if (alignment == 3)
						{
							num7 -= (int)vector.X;
						}
						num8 -= (int)vector.Y >> 1;
					}
					DrawStringLT(fontSmallOutline, text, num7, num8, Color.White);
				}
			}
			else if (menuMode == MenuMode.MAP)
			{
				if (Netplay.session != null)
				{
					DrawMiniMap();
				}
			}
			else if (menuMode == MenuMode.HOW_TO_PLAY)
			{
				view.SetScreenViewWideCentered();
				howtoUI.Draw();
				view.SetScreenView();
			}
			else if (menuMode == MenuMode.WORLD_SELECT)
			{
				WorldSelect.Draw(view);
			}
			else if (menuMode == MenuMode.GAME_MODE)
			{
				GameMode.Draw(view);
			}
			else if (menuMode == MenuMode.CREATE_CHARACTER)
			{
				view.SetScreenViewWideCentered();
				createCharacterGUI.Draw(view);
				view.SetScreenView();
				showPlayer = -1;
			}
			else if (menuMode == MenuMode.VOLUME)
			{
				soundUI.Draw(Main.spriteBatch);
			}
			else if (menuMode == MenuMode.WELCOME)
			{
				string text2 = Lang.menu[52];
				if (text2 == null)
				{
					text2 = "";
				}
				SpriteFont spriteFont = fontBig;
				Vector2 value2 = spriteFont.MeasureString(text2);
				Vector2 origin = value2 * 0.5f;
				Vector2 position3 = new Vector2(480f, 460f);
				float num9 = 0.75f;
				num9 *= 1f + cursorAlpha * 0.1f;
				Color color = new Color(cursorColor.A, cursorColor.A, 100, 255);
				Main.spriteBatch.DrawString(spriteFont, text2, position3, color, 0f, origin, num9, SpriteEffects.None, 0f);
			}
			else if (menuMode == MenuMode.LEADERBOARDS)
			{
				view.SetScreenViewWideCentered();
				leaderboards.Draw(view);
				view.SetScreenView();
			}
			else if (menuMode == MenuMode.ERROR)
			{
				if (errorCompiledText == null)
				{
					errorCompiledText = new CompiledText(errorDescription, 470, styleFontSmallOutline);
				}
				DrawDialog(new Vector2(view.viewWidth - chatBackTexture.Width >> 1, 260f), new Color(128, 128, 128, 64), new Color(255, 255, 255, 255), errorCompiledText, errorCaption);
			}
			else if (menuMode == MenuMode.CREDITS)
			{
				Credits.Draw();
			}
			else if (menuMode == MenuMode.UPSELL)
			{
				theGame.DrawUpsell();
			}
			for (int i = 0; i < numMenuItems; i++)
			{
				if (menuString[i] != null)
				{
					float num10 = menuItemScale[i];
					Color c;
					if (menuHC[i] == 3)
					{
						c = new Color(120, 120, 120);
					}
					else if (menuHC[i] == 2)
					{
						c = new Color(200, 125, 255);
					}
					else if (menuHC[i] == 1)
					{
						c = new Color(125, 125, 255);
					}
					else if (noFocus[i])
					{
						c = new Color(255, 200, 62, 255);
					}
					else if (i != focusMenu)
					{
						c = new Color(240, 240, 240, 240);
					}
					else
					{
						num10 *= 1f + cursorAlpha * 0.1f;
						c = new Color(cursorColor.A, cursorColor.A, 100, 255);
					}
					Vector2 pivot = MeasureString(fontBig, menuString[i]);
					pivot.X *= 0.5f;
					pivot.Y *= 0.5f;
					num10 *= menuScale[i];
					DrawStringScaled(pos: new Vector2(menuLeft, (float)(menuTop + menuSpace * i) + pivot.Y * menuScale[i] + (float)menuY[i]), font: fontBig, s: menuString[i], c: c, pivot: pivot, scale: num10);
				}
			}
			for (int j = 0; j < 14; j++)
			{
				if (j == focusMenu)
				{
					if (menuItemScale[j] < 1f)
					{
						menuItemScale[j] += 0.05f;
					}
					if (menuItemScale[j] > 1f)
					{
						menuItemScale[j] = 1f;
					}
				}
				else if ((double)menuItemScale[j] > 0.8)
				{
					menuItemScale[j] -= 0.05f;
				}
			}
			if (showPlayer >= 0)
			{
				Player player = loadPlayer[showPlayer];
				player.velocity.X = 1f;
				player.PlayerFrame();
				DrawPlayer(player, new Vector2(148f, 244f), 4f);
			}
			DrawControls();
		}

		private void ResumeGame()
		{
			Main.PlaySound(10);
			PrevMenu();
			ClearButtonTriggers();
			menuType = MenuType.NONE;
			worldFadeTarget = 1f;
		}

		public void DrawPlayer(Player player, Vector2 position, float scale)
		{
			Main.spriteBatch.End();
			Vector2 position2 = player.position;
			player.position.X = view.screenPosition.X;
			player.position.Y = view.screenPosition.Y;
			Matrix world = Matrix.CreateScale(scale, scale, 1f);
			world.M41 = position.X;
			world.M42 = position.Y;
			view.screenProjection.World = world;
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, view.screenProjection);
			player.Draw(view, isMenu: true);
			Main.spriteBatch.End();
			view.screenProjection.World = Matrix.Identity;
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, view.screenProjection);
			player.position = position2;
			player.aabb.X = (int)position2.X;
			player.aabb.Y = (int)position2.Y;
		}

		public void DrawPlayerIcon(Player player, Vector2 position, float scale)
		{
			Vector2 position2 = player.position;
			player.position.X = view.screenPosition.X;
			player.position.Y = view.screenPosition.Y;
			Vector2 velocity = player.velocity;
			player.velocity.X = 0f;
			player.velocity.Y = 0f;
			Matrix world = Matrix.CreateScale(scale, scale, 1f);
			world.M41 = position.X;
			world.M42 = position.Y;
			view.screenProjection.World = world;
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, view.screenProjection);
			player.Draw(view, isMenu: true, isIcon: true);
			Main.spriteBatch.End();
			view.screenProjection.World = Matrix.Identity;
			player.velocity = velocity;
			player.position = position2;
			player.aabb.X = (int)position2.X;
			player.aabb.Y = (int)position2.Y;
		}

		private bool IsGamerValid()
		{
			if (this == main && signedInGamer.IsGuest)
			{
				return false;
			}
			if (Main.netMode > 0 && !CanPlayOnline())
			{
				return false;
			}
			return true;
		}

		private void ShowSignInPortal()
		{
			foreach (SignedInGamer signedInGamer2 in Gamer.SignedInGamers)
			{
				if (signedInGamer2.PlayerIndex == controller)
				{
					signedInGamer = signedInGamer2;
					if (IsGamerValid())
					{
						signedInGamer2.Presence.SetPresenceModeString("Menu");
						InitPlayerStorage();
						return;
					}
					signedInGamer = null;
				}
			}
			SetMenu(MenuMode.SHOW_SIGN_IN);
		}

		private void ShowAchievements()
		{
			if (!Guide.IsVisible)
			{
				Main.PlaySound(10);
				bool flag;
				do
				{
					flag = false;
					try
					{
						GuideExtensions.ShowAchievements(controller);
					}
					catch (GuideAlreadyVisibleException)
					{
						Thread.Sleep(32);
						flag = true;
					}
				}
				while (flag);
			}
		}

		public void ShowParty()
		{
			if (CanPlayOnline() && !Guide.IsVisible)
			{
				Main.PlaySound(10);
				bool flag;
				do
				{
					flag = false;
					try
					{
						Guide.ShowPartySessions(controller);
					}
					catch (GuideAlreadyVisibleException)
					{
						Thread.Sleep(32);
						flag = true;
					}
				}
				while (flag);
			}
		}

		private void DrawLogo()
		{
			logoRotation += logoRotationSpeed * 3E-05f;
			if ((double)logoRotation > 0.1)
			{
				logoRotationDirection = -1f;
			}
			else if ((double)logoRotation < -0.1)
			{
				logoRotationDirection = 1f;
			}
			if ((logoRotationSpeed < 20f) & (logoRotationDirection == 1f))
			{
				logoRotationSpeed += 1f;
			}
			else if ((logoRotationSpeed > -20f) & (logoRotationDirection == -1f))
			{
				logoRotationSpeed -= 1f;
			}
			logoScale += logoScaleSpeed * 1E-05f;
			if ((double)logoScale > 1.1)
			{
				logoScaleDirection = -1f;
			}
			else if ((double)logoScale < 0.9)
			{
				logoScaleDirection = 1f;
			}
			if ((logoScaleSpeed < 50f) & (logoScaleDirection == 1f))
			{
				logoScaleSpeed += 1f;
			}
			else if ((logoScaleSpeed > -50f) & (logoScaleDirection == -1f))
			{
				logoScaleSpeed -= 1f;
			}
			Color color = new Color(LogoA, LogoA, LogoA, LogoA);
			Color color2 = new Color(LogoB, LogoB, LogoB, LogoB);
			float x = (view != null) ? (view.viewWidth >> 1) : 480;
			Main.spriteBatch.Draw(logoTexture, new Vector2(x, 100f), new Rectangle(0, 0, logoTexture.Width, logoTexture.Height), color, logoRotation, new Vector2(logoTexture.Width >> 1, logoTexture.Height >> 1), logoScale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(logo2Texture, new Vector2(x, 100f), new Rectangle(0, 0, logoTexture.Width, logoTexture.Height), color2, logoRotation, new Vector2(logoTexture.Width >> 1, logoTexture.Height >> 1), logoScale, SpriteEffects.None, 0f);
			if (view.time.dayTime)
			{
				LogoA += 2;
				if (LogoA > 255)
				{
					LogoA = 255;
				}
				LogoB--;
				if (LogoB < 0)
				{
					LogoB = 0;
				}
			}
			else
			{
				LogoB += 2;
				if (LogoB > 255)
				{
					LogoB = 255;
				}
				LogoA--;
				if (LogoA < 0)
				{
					LogoA = 0;
				}
			}
		}

		private void initCharacterSelectCoordinates()
		{
			if (numLoadPlayers == 0)
			{
				return;
			}
			for (int i = 0; i < 5; i++)
			{
				if (i < numLoadPlayers)
				{
					MENU_SELECT_COORDS[i].X = 480;
				}
				else
				{
					MENU_SELECT_COORDS[i].X = 0;
				}
			}
		}

		private void DrawControls()
		{
			if (menuType == MenuType.NONE)
			{
				return;
			}
			Main.strBuilder.Length = 0;
			if (saveIconMessageTime > 0)
			{
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
			}
			else
			{
				switch (menuMode)
				{
				case MenuMode.WAITING_SCREEN:
				case MenuMode.NETPLAY:
				case MenuMode.ERROR:
				case MenuMode.LOAD_FAILED_NO_BACKUP:
				case MenuMode.CREDITS:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
					break;
				case MenuMode.MAP:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.MOVE_MAP));
					Main.strBuilder.Append(' ');
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.ZOOM));
					Main.strBuilder.Append(' ');
					if (mapScreenCursorY >= 2)
					{
						if (CanViewGamerCard() && Netplay.session != null)
						{
							GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
							int num = mapScreenCursorY - 2;
							if (num < allGamers.Count)
							{
								Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_GAMERCARD));
								Main.strBuilder.Append(' ');
							}
						}
					}
					else if (mapScreenCursorX == 0)
					{
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.TOGGLE_PVP));
						Main.strBuilder.Append(' ');
					}
					else
					{
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT_TEAM));
						Main.strBuilder.Append(' ');
					}
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
					if (Netplay.gamer != null && Main.netMode > 0)
					{
						if (CanCommunicate())
						{
							Main.strBuilder.Append(' ');
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INVITE_PLAYER));
						}
						if (signedInGamer.PartySize > 1)
						{
							Main.strBuilder.Append(' ');
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INVITE_PARTY));
						}
					}
					break;
				case MenuMode.TITLE:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
					if (playerStorage != null)
					{
						Main.strBuilder.Append(' ');
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_STORAGE));
					}
					if (CanPlayOnline())
					{
						Main.strBuilder.Append(' ');
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_PARTY));
					}
					break;
				case MenuMode.CREATE_CHARACTER:
					createCharacterGUI.ControlDescription(Main.strBuilder);
					break;
				case MenuMode.VOLUME:
					soundUI.ControlDescription(Main.strBuilder);
					break;
				case MenuMode.HOW_TO_PLAY:
					howtoUI.ControlDescription(Main.strBuilder);
					break;
				case MenuMode.LEADERBOARDS:
					leaderboards.ControlDescription(Main.strBuilder);
					break;
				case MenuMode.CHARACTER_SELECT:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
					if (Netplay.gamersWhoReceivedInvite.Count < 2 || !Netplay.gamersWhoReceivedInvite.Contains(signedInGamer))
					{
						Main.strBuilder.Append(' ');
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
					}
					if (focusMenu < numLoadPlayers)
					{
						Main.strBuilder.Append(' ');
						Main.strBuilder.Append(Lang.menu[17]);
					}
					break;
				case MenuMode.WORLD_SELECT:
					WorldSelect.ControlDescription(Main.strBuilder);
					break;
				case MenuMode.UPSELL:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.EXIT));
					Main.strBuilder.Append(' ');
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK_TO_GAME));
					if (signedInGamer.Privileges.AllowPurchaseContent)
					{
						Main.strBuilder.Append(' ');
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.UNLOCK_FULL_GAME));
					}
					break;
				case MenuMode.CONTROLS:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.TOGGLE_GRAPPLE_MODE));
					Main.strBuilder.Append(' ');
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
					break;
				case MenuMode.PAUSE:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
					Main.strBuilder.Append(' ');
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
					if (Main.netMode == 1)
					{
						Main.strBuilder.Append(' ');
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BLACKLIST));
					}
					break;
				default:
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
					Main.strBuilder.Append(' ');
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
					break;
				case MenuMode.WELCOME:
				case MenuMode.STATUS_SCREEN:
					break;
				}
			}
			if (Main.strBuilder.Length > 0)
			{
				DrawStringLB(fontSmallOutline, view.SAFE_AREA_OFFSET_L, view.SAFE_AREA_OFFSET_B);
			}
		}

		private void DrawHud()
		{
			Vector2 pos = default(Vector2);
			Color c = new Color(128, 128, 128, 128);
			for (int i = 1; i < player.statLifeMax / 20 + 1; i++)
			{
				int num = view.viewWidth - view.SAFE_AREA_OFFSET_R - 460 + 26 * (i - 1) + 160 + 11;
				int num2 = view.SAFE_AREA_OFFSET_T;
				if (i > 10)
				{
					num -= 260;
					num2 += 26;
				}
				SpriteSheet<_sheetSprites>.Draw(436, num, num2, c);
				int id = 435;
				if (player.statLife < i * 20)
				{
					float num3 = (float)(player.statLife - (i - 1) * 20) / 20f;
					if (num3 <= 0f)
					{
						continue;
					}
					id = (((double)num3 < 0.25) ? 434 : ((!((double)num3 < 0.5)) ? 432 : 433));
				}
				SpriteSheet<_sheetSprites>.Draw(id, num, num2);
			}
			if (player.breath < 200)
			{
				for (int j = 1; j < 11; j++)
				{
					int num4 = view.viewWidth - view.SAFE_AREA_OFFSET_R - 460 + 26 * (j - 1) + 160 + 11;
					int num5 = view.SAFE_AREA_OFFSET_T + 52;
					SpriteSheet<_sheetSprites>.Draw(141, num4, num5, c);
					if (player.breath < j * 20)
					{
						float num6 = (float)(player.breath - (j - 1) * 20) / 20f;
						if (num6 > 0f)
						{
							float scaleCenter = num6 * 0.25f + 0.75f;
							int num7 = (int)(30f + 225f * num6);
							if (num7 < 30)
							{
								num7 = 30;
							}
							c.R = (byte)num7;
							c.G = (byte)num7;
							c.B = (byte)num7;
							c.A = (byte)num7;
							SpriteSheet<_sheetSprites>.DrawScaled(140, num4 + 11, num5 + 11, scaleCenter, c);
							c = new Color(128, 128, 128, 128);
						}
					}
					else
					{
						SpriteSheet<_sheetSprites>.Draw(140, num4, num5);
					}
				}
			}
			if (player.statManaMax2 > 0)
			{
				int num8 = player.statManaMax2 / 20;
				int num9 = view.viewWidth - view.SAFE_AREA_OFFSET_R - 22;
				pos.X = num9 + 11;
				c.R = byte.MaxValue;
				c.G = byte.MaxValue;
				c.B = byte.MaxValue;
				c.A = 229;
				int num10 = 0;
				do
				{
					bool flag = false;
					float num11 = 1f;
					if (player.statMana >= (num10 + 1) * 20)
					{
						if (player.statMana == (num10 + 1) * 20)
						{
							flag = true;
						}
					}
					else
					{
						float num12 = (float)(player.statMana - num10 * 20) / 20f;
						int num13 = (int)(30f + 225f * num12);
						if (num13 < 30)
						{
							num13 = 30;
						}
						c.R = (byte)num13;
						c.G = (byte)num13;
						c.B = (byte)num13;
						c.A = (byte)((double)num13 * 0.9);
						num11 = num12 * 0.25f + 0.5f;
						if (num11 < 0.5f)
						{
							num11 = 0.5f;
						}
						if (num12 > 0f)
						{
							flag = true;
						}
					}
					if (flag)
					{
						num11 += cursorScale - 1f;
					}
					int num14 = view.SAFE_AREA_OFFSET_T + 23 * num10;
					pos.Y = (float)(num14 + 11) + (6f - 6f * num11);
					SpriteSheet<_sheetSprites>.Draw(1087, num9, num14, new Color(128, 128, 128, 128));
					SpriteSheet<_sheetSprites>.DrawScaled(1086, ref pos, c, num11);
				}
				while (++num10 < num8);
			}
			c = new Color(99, 99, 99, 99);
			for (int k = 0; k < 10; k++)
			{
				int type = player.buff[k].Type;
				if (type <= 0)
				{
					continue;
				}
				int x = 32 + view.SAFE_AREA_OFFSET_L + k * 38;
				int num15 = 76 + view.SAFE_AREA_OFFSET_T;
				int num16 = 141 + type;
				if (type == 40)
				{
					num16 += player.pet;
				}
				SpriteSheet<_sheetSprites>.Draw(num16, x, num15, c);
				if (type != 28 && type != 34 && type != 37 && type != 38 && type != 40)
				{
					int num17 = (int)player.buff[k].Time / 60;
					Main.strBuilder.Length = 0;
					Main.strBuilder.Append((num17 / 60).ToStringLookup());
					Main.strBuilder.Append(':');
					num17 %= 60;
					if (num17 < 10)
					{
						Main.strBuilder.Append('0');
					}
					Main.strBuilder.Append(num17.ToStringLookup());
					DrawStringLT(fontItemStack, x, num15 + 32, Color.White);
				}
			}
			if (npcChatText == null)
			{
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				for (int l = 0; l < 3; l++)
				{
					Main.strBuilder.Length = 0;
					if (player.accCompass && !flag4)
					{
						Main.strBuilder.Append(Lang.menu[95]);
						int num18 = (player.aabb.X + 10 >> 3) - Main.maxTilesX;
						num18 >>= 2;
						if (num18 > 0)
						{
							Main.strBuilder.Append(num18.ToStringLookup());
							Main.strBuilder.Append(Lang.menu[96]);
						}
						else if (num18 < 0)
						{
							num18 = -num18;
							Main.strBuilder.Append(num18.ToStringLookup());
							Main.strBuilder.Append(Lang.menu[97]);
						}
						else
						{
							Main.strBuilder.Append(Lang.menu[98]);
						}
						flag4 = true;
					}
					else if (player.accDepthMeter && !flag3)
					{
						Main.strBuilder.Append(Lang.menu[85]);
						int num19 = (player.aabb.Y + 42 >> 3) - Main.worldSurface * 2;
						num19 >>= 2;
						if (num19 > 0)
						{
							Main.strBuilder.Append(num19.ToStringLookup());
							Main.strBuilder.Append(Lang.menu[86]);
						}
						else if (num19 < 0)
						{
							num19 = -num19;
							Main.strBuilder.Append(num19.ToStringLookup());
							Main.strBuilder.Append(Lang.menu[87]);
						}
						else
						{
							Main.strBuilder.Append(Lang.menu[88]);
						}
						flag3 = true;
					}
					else if (player.accWatch > 0 && !flag2)
					{
						string value = " AM";
						double num20 = Main.gameTime.time;
						if (!Main.gameTime.dayTime)
						{
							num20 += 54000.0;
						}
						num20 = num20 / 86400.0 * 24.0;
						num20 = num20 - 7.5 - 12.0;
						if (num20 < 0.0)
						{
							num20 += 24.0;
						}
						if (num20 >= 12.0)
						{
							value = " PM";
						}
						int num21 = (int)num20;
						int num22 = (int)((num20 - (double)num21) * 60.0);
						if (num21 > 12)
						{
							num21 -= 12;
						}
						if (num21 == 0)
						{
							num21 = 12;
						}
						string text;
						if (player.accWatch == 1)
						{
							text = "00";
						}
						else if (player.accWatch == 2)
						{
							text = ((num22 >= 30) ? "30" : "00");
						}
						else
						{
							text = num22.ToStringLookup();
							if (num22 < 10)
							{
								text = "0" + text;
							}
						}
						Main.strBuilder.Append(Lang.inter[34]);
						Main.strBuilder.Append(num21.ToStringLookup());
						Main.strBuilder.Append(':');
						Main.strBuilder.Append(text);
						Main.strBuilder.Append(value);
						flag2 = true;
					}
					if (Main.strBuilder.Length > 0)
					{
						DrawStringLT(fontSmallOutline, view.SAFE_AREA_OFFSET_L, 110 + 22 * l + 48, mouseTextColor);
					}
				}
			}
			int oldSelectedItem = player.oldSelectedItem;
			int num23 = (oldSelectedItem >= 0) ? oldSelectedItem : player.selectedItem;
			float num24 = (numActiveViews > 1) ? 1.25f : 1f;
			int num25 = view.SAFE_AREA_OFFSET_L;
			for (int m = 0; m < 10; m++)
			{
				float num26 = hotbarScale[m];
				if (m == num23)
				{
					if (num26 < 1f)
					{
						num26 += 0.05f;
						hotbarScale[m] = num26;
					}
				}
				else if (num26 > 0.75f)
				{
					num26 -= 0.05f;
					hotbarScale[m] = num26;
				}
				num26 *= num24;
				int y = (int)((float)view.SAFE_AREA_OFFSET_T + 22f * (1f - num26));
				int num27 = (int)(65f + 180f * num26);
				Color itemColor = new Color(num27, num27, num27, num27);
				if (m == num23)
				{
					c.R = 200;
					c.G = 200;
					c.B = 200;
					c.A = 200;
					SpriteSheet<_sheetSprites>.DrawTL(448, num25, y, c, num26);
				}
				else
				{
					c.R = 100;
					c.G = 100;
					c.B = 100;
					c.A = 100;
					SpriteSheet<_sheetSprites>.DrawTL(451, num25, y, c, num26);
				}
				int num28 = (m == oldSelectedItem) ? player.selectedItem : m;
				if (player.inventory[num28].type > 0 && player.inventory[num28].stack > 0)
				{
					inventoryScale = num26;
					DrawInventoryItem(ref player.inventory[num28], num25, y, itemColor, StackType.HOTBAR);
				}
				num25 += (int)(52f * num26) + 4;
			}
			if (quickAccessDisplayTime > 0)
			{
				quickAccessDisplayTime--;
				int alpha = (quickAccessDisplayTime < 64) ? (quickAccessDisplayTime << 2) : 255;
				DrawQuickAccess(player.selectedItem, view.SAFE_AREA_OFFSET_L, 540 - view.SAFE_AREA_OFFSET_B - 32 - 128, alpha, StackType.HOTBAR);
			}
			if (hotbarItemNameTime > 0)
			{
				hotbarItemNameTime--;
				if (player.inventory[player.selectedItem].type != 0)
				{
					string s = player.inventory[player.selectedItem].AffixName();
					int num29 = (hotbarItemNameTime < 64) ? (hotbarItemNameTime << 2) : 255;
					DrawStringCT(fontSmall, s, (int)(216f * num24) + view.SAFE_AREA_OFFSET_L, view.SAFE_AREA_OFFSET_T + (int)(44f * num24), new Color(num29, num29, num29, num29));
				}
			}
			DrawControlsIngame();
		}

		private void DrawInventoryItem(int itemTexId, int x, int y, Color itemColor)
		{
			int width = SpriteSheet<_sheetSprites>.src[itemTexId].Width;
			int height = SpriteSheet<_sheetSprites>.src[itemTexId].Height;
			float num = (width <= height) ? (41f / (float)height) : (41f / (float)width);
			num *= inventoryScale;
			if (num > 1.25f)
			{
				num = 1.25f;
			}
			Vector2 pos = default(Vector2);
			pos.X = (float)x + 26f * inventoryScale;
			pos.Y = (float)y + 26f * inventoryScale;
			SpriteSheet<_sheetSprites>.DrawScaled(itemTexId, ref pos, itemColor, num);
		}

		private void DrawInventoryItem(ref Item item, int x, int y, Color itemColor, StackType stackType = StackType.NONE)
		{
			int num = item.type + 451;
			int width = SpriteSheet<_sheetSprites>.src[num].Width;
			int height = SpriteSheet<_sheetSprites>.src[num].Height;
			float num2 = (width <= height) ? (41f / (float)height) : (41f / (float)width);
			num2 *= inventoryScale;
			if (num2 > 1.25f)
			{
				num2 = 1.25f;
			}
			Vector2 pos = default(Vector2);
			pos.X = (float)x + 26f * inventoryScale;
			pos.Y = (float)y + 26f * inventoryScale;
			SpriteSheet<_sheetSprites>.DrawScaled(num, ref pos, item.GetAlphaInventory(itemColor), num2);
			if (item.color.PackedValue != 0)
			{
				SpriteSheet<_sheetSprites>.DrawScaled(num, ref pos, item.GetColor(itemColor), num2);
			}
			switch (stackType)
			{
			case StackType.NONE:
				return;
			case StackType.INGREDIENT:
				DrawIngredientStack(ref item, x, y, itemColor);
				return;
			}
			DrawInventoryItemStack(ref item, x, y, ref itemColor);
			if (stackType != StackType.HOTBAR)
			{
				return;
			}
			int useAmmo = item.useAmmo;
			if (useAmmo > 0)
			{
				int num3 = 0;
				for (int i = 0; i < 48; i++)
				{
					if (player.inventory[i].ammo == useAmmo)
					{
						num3 += player.inventory[i].stack;
					}
				}
				DrawStringScaled(fontItemStack, num3.ToStringLookup(), new Vector2((float)(x + FONT_STACK_EXTRA_OFFSET) + 10f * inventoryScale, (float)y + 26f * inventoryScale), itemColor, default(Vector2), inventoryScale + 0.1f);
			}
			else if (item.type == 509)
			{
				int num4 = 0;
				for (int j = 0; j < 48; j++)
				{
					if (player.inventory[j].type == 530)
					{
						num4 += player.inventory[j].stack;
					}
				}
				DrawStringScaled(fontItemStack, num4.ToStringLookup(), new Vector2((float)(x + FONT_STACK_EXTRA_OFFSET) + 10f * inventoryScale, (float)y + 26f * inventoryScale), itemColor, default(Vector2), inventoryScale + 0.1f);
			}
			if (item.potion)
			{
				Color alphaInventory = item.GetAlphaInventory(itemColor);
				float num5 = (float)(int)player.potionDelay / (float)(int)player.potionDelayTime;
				alphaInventory *= num5;
				pos.X = (float)x + 26f * inventoryScale;
				pos.Y = (float)y + 26f * inventoryScale;
				SpriteSheet<_sheetSprites>.DrawScaled(204, ref pos, alphaInventory, inventoryScale);
			}
		}

		private static void DrawInventoryItemStack(ref Item item, int x, int y, ref Color itemColor)
		{
			if (item.stack > 1)
			{
				DrawStringScaled(fontItemStack, item.stack.ToStringLookup(), new Vector2((float)(x + FONT_STACK_EXTRA_OFFSET) + 10f * inventoryScale, (float)y + 26f * inventoryScale), itemColor, default(Vector2), inventoryScale + 0.1f);
			}
		}

		private void DrawIngredientStack(ref Item item, int x, int y, Color itemColor)
		{
			int num = Math.Min(item.stack, player.CountInventory(item.netID));
			Main.strBuilder.Length = 0;
			Main.strBuilder.Append(item.stack.ToStringLookup());
			if (num < item.stack)
			{
				itemColor.G >>= 1;
				itemColor.B >>= 1;
			}
			DrawStringScaled(fontItemStack, new Vector2((float)(x + FONT_STACK_EXTRA_OFFSET) + 10f * inventoryScale, (float)y + 26f * inventoryScale), itemColor, default(Vector2), inventoryScale - 0.1f);
		}

		public void DrawInterface()
		{
			if (showNPCs)
			{
				view.DrawNPCHouse();
			}
			Vector2 pos = default(Vector2);
			if (this.player.rulerAcc)
			{
				view.DrawGrid();
			}
			if (signBubble)
			{
				signBubble = false;
				int num = signX - view.screenPosition.X;
				int num2 = signY - view.screenPosition.Y;
				SpriteEffects se = SpriteEffects.None;
				if ((float)signX > this.player.position.X + 20f)
				{
					se = SpriteEffects.FlipHorizontally;
					num -= 40;
				}
				else
				{
					num += 8;
				}
				num2 -= 22;
				SpriteSheet<_sheetSprites>.Draw(200, num, num2, mouseTextColor, se);
			}
			Main.spriteBatch.End();
			for (int num3 = 7; num3 >= 0; num3--)
			{
				if (myPlayer != num3)
				{
					Player player = Main.player[num3];
					if (player.active != 0 && !player.dead && !player.aabb.Intersects(view.viewArea) && (this.player.team == 0 || player.team == 0 || this.player.team == player.team))
					{
						Vector2 a = default(Vector2);
						Vector2 a2 = default(Vector2);
						a.X = view.viewWidth >> 1;
						a.Y = 270f;
						a2.X = player.aabb.X + 10 - view.screenPosition.X;
						a2.Y = player.aabb.Y + 21 - view.screenPosition.Y;
						Vector2 intersection = default(Vector2);
						bool flag = false;
						int sAFE_AREA_OFFSET_L = view.SAFE_AREA_OFFSET_L;
						int num4 = view.viewWidth - view.SAFE_AREA_OFFSET_R - 40;
						int num5 = view.SAFE_AREA_OFFSET_T + 20 + 40;
						int num6 = 540 - view.SAFE_AREA_OFFSET_B - 40;
						if (a2.X <= (float)sAFE_AREA_OFFSET_L)
						{
							flag = Collision.LineIntersection(ref a, ref a2, new Vector2(sAFE_AREA_OFFSET_L, num5), new Vector2(sAFE_AREA_OFFSET_L, num6), ref intersection);
						}
						else if (a2.X >= (float)num4)
						{
							flag = Collision.LineIntersection(ref a, ref a2, new Vector2(num4, num5), new Vector2(num4, num6), ref intersection);
						}
						if (!flag)
						{
							if (a2.Y <= (float)num5)
							{
								flag = Collision.LineIntersection(ref a, ref a2, new Vector2(sAFE_AREA_OFFSET_L, num5), new Vector2(num4, num5), ref intersection);
							}
							else if (a2.Y >= (float)num6)
							{
								flag = Collision.LineIntersection(ref a, ref a2, new Vector2(sAFE_AREA_OFFSET_L, num6), new Vector2(num4, num6), ref intersection);
							}
						}
						float num7 = (float)view.viewWidth * 1.5f / (a2 - a).Length();
						if (num7 < 0.5f)
						{
							num7 = 0.5f;
						}
						Matrix matrix = Matrix.CreateTranslation(-10f, -8f, 0f) * Matrix.CreateScale(num7, num7, 1f);
						Vector2 position = player.position;
						player.position.X = view.screenPosition.X;
						player.position.Y = view.screenPosition.Y;
						view.screenProjection.World = matrix * Matrix.CreateTranslation(intersection.X, intersection.Y, 0f);
						Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, view.screenProjection);
						player.Draw(view, isMenu: true, isIcon: true);
						Main.spriteBatch.End();
						player.position = position;
						player.aabb.X = (int)position.X;
						player.aabb.Y = (int)position.Y;
					}
				}
			}
			view.screenProjection.World = Matrix.Identity;
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, view.screenProjection);
			if (inventoryMode == 0 && (npcChatText != null || this.player.sign != -1))
			{
				DrawNpcChat();
			}
			if (this.player.dead)
			{
				CloseInventory();
				string s = Lang.inter[38];
				DrawStringCC(fontBig, s, view.viewWidth >> 1, 270, this.player.GetDeathAlpha(default(Color)));
				return;
			}
			if (inventoryMode != 0)
			{
				DrawInventoryMenu();
				return;
			}
			view.SetWorldView();
			Rectangle rectangle = new Rectangle(this.player.aabb.X + 10 - 80, this.player.aabb.Y + 21 - 64, 160, 128);
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[i].active != 0 && myPlayer != i && !Main.player[i].dead)
				{
					Rectangle value = new Rectangle(Main.player[i].aabb.X + -6, Main.player[i].aabb.Y + 42 - 48, 32, 48);
					if (rectangle.Intersects(value))
					{
						Main.player[i].DrawInfo(view);
					}
				}
			}
			if (!this.player.dead)
			{
				for (int num8 = 195; num8 >= 0; num8--)
				{
					view.drawNpcName[num8] = true;
				}
				this.player.npcChatBubble = -1;
				int num9 = 10496;
				Rectangle value2 = default(Rectangle);
				Point center = rectangle.Center;
				for (int j = 0; j < 196; j++)
				{
					NPC nPC = Main.npc[j];
					if (nPC.active == 0)
					{
						continue;
					}
					int type = nPC.type;
					if (type == 85 && Main.npc[j].ai0 == 0f)
					{
						continue;
					}
					if ((type >= 87 && type <= 92) || (type >= 159 && type <= 164))
					{
						value2.X = nPC.aabb.X + (nPC.width >> 1) - 32;
						value2.Y = nPC.aabb.Y + (nPC.height >> 1) - 32;
						value2.Width = 64;
						value2.Height = 64;
					}
					else
					{
						int width = SpriteSheet<_sheetSprites>.src[1088 + type].Width;
						value2.X = nPC.aabb.X + (nPC.width >> 1) - (width >> 1);
						value2.Y = nPC.aabb.Y + nPC.height - nPC.frameHeight;
						value2.Width = width;
						value2.Height = nPC.frameHeight;
					}
					rectangle.Intersects(ref value2, out bool result);
					if (result)
					{
						if (nPC.canTalk() && this.player.CanInteractWithNPC())
						{
							Point value3 = value2.Center;
							int num10 = Math.Abs(center.X - value3.X);
							if (num10 <= 80)
							{
								int num11 = num10 * num10;
								num10 = Math.Abs(center.Y - value3.Y);
								if (num10 <= 64)
								{
									num11 += num10 * num10;
									if (num11 < num9)
									{
										bool result2;
										if (smartCursor)
										{
											result2 = true;
										}
										else
										{
											value3.X = mouseX + view.screenPosition.X;
											value3.Y = mouseY + view.screenPosition.Y;
											value2.Contains(ref value3, out result2);
										}
										if (result2)
										{
											this.player.npcChatBubble = (short)j;
										}
									}
								}
							}
						}
						if (nPC.drawMyName < 32)
						{
							nPC.drawMyName = 32;
						}
					}
					if (nPC.drawMyName > 0 && view.clipArea.Intersects(value2))
					{
						nPC.drawMyName--;
						nPC.DrawInfo(view);
					}
				}
				if (this.player.npcChatBubble >= 0)
				{
					NPC nPC2 = Main.npc[this.player.npcChatBubble];
					int num12 = -((nPC2.width >> 1) + 8);
					SpriteEffects se2 = SpriteEffects.None;
					if (nPC2.spriteDirection == -1)
					{
						se2 = SpriteEffects.FlipHorizontally;
						num12 = -num12;
					}
					pos.X = nPC2.aabb.X + (nPC2.width >> 1) - view.screenPosition.X - 16 - num12;
					pos.Y = nPC2.aabb.Y - 26 - view.screenPosition.Y;
					SpriteSheet<_sheetSprites>.Draw(201, ref pos, mouseTextColor, se2);
				}
			}
			view.SetScreenView();
		}

		public void ClearInput()
		{
			inputTextEnter = false;
			inputTextCanceled = false;
		}

		public UserString GetInputText(UserString oldString, string title = null, string desc = null, bool validate = true)
		{
			if (!inputTextEnter && oldString.IsEditable())
			{
				if (!Guide.IsVisible)
				{
					try
					{
						kbResult = Guide.BeginShowKeyboardInput(controller, title, desc, oldString.isCensored ? "" : oldString.text, null, null);
						return oldString;
					}
					catch (GuideAlreadyVisibleException)
					{
						return oldString;
					}
				}
				if (kbResult != null && kbResult.IsCompleted)
				{
					inputTextEnter = true;
					string text = Guide.EndShowKeyboardInput(kbResult);
					kbResult = null;
					inputTextCanceled = (text == null);
					if (!inputTextCanceled)
					{
						text = text.Trim();
						char[] array = text.ToCharArray();
						bool flag = false;
						for (int num = array.Length - 1; num >= 0; num--)
						{
							if (array[num] == '¤')
							{
								array[num] = 'Ʃ';
								flag = true;
							}
							else if (!fontSmallOutline.Characters.Contains(array[num]))
							{
								char c = array[num];
								if (c == '€')
								{
									array[num] = 'Ɛ';
								}
								else
								{
									array[num] = '?';
								}
								flag = true;
							}
						}
						if (flag)
						{
							text = new string(array);
						}
						if (validate)
						{
							oldString.SetUserString(text);
						}
						else
						{
							oldString.SetSystemString(text);
						}
					}
				}
			}
			return oldString;
		}

		public void FirstProgressStep(int numSteps, string text = null)
		{
			progress = 0f;
			progressTotal = 0f;
			numProgressStepsInv = 1f / (float)numSteps;
			if (text != null)
			{
				statusText = text;
			}
		}

		public void NextProgressStep(string text = null)
		{
			progress = 0f;
			progressTotal += numProgressStepsInv;
			if (text != null)
			{
				statusText = text;
			}
		}

		private static void UpdateCursorColor()
		{
			cursorAlpha = (float)(0.8 + 0.2 * Math.Sin((double)Main.frameCounter * 0.0625));
			double num = (double)cursorAlpha * 0.3 + 0.7;
			byte r = (byte)((float)(int)mouseColor.R * cursorAlpha);
			byte g = (byte)((float)(int)mouseColor.G * cursorAlpha);
			byte b = (byte)((float)(int)mouseColor.B * cursorAlpha);
			byte a = (byte)(255.0 * num);
			cursorColor = new Color(r, g, b, a);
			cursorScale = (float)(num + 0.1);
		}

		private void UpdateMouse()
		{
			if (uiCoords == null)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 3;
				bool flag = inventoryMode > 0 || menuMode == MenuMode.MAP || menuMode == MenuMode.WORLD_SELECT || menuMode == MenuMode.GAME_MODE;
				if (flag)
				{
					num3 = 1;
				}
				else
				{
					if (menuType == MenuType.NONE)
					{
						if (IsButtonTriggered(Buttons.RightStick))
						{
							smartCursor = !smartCursor;
						}
						if (smartCursor)
						{
							player.UpdateMouseSmart();
						}
						else
						{
							player.UpdateMouse();
						}
						return;
					}
					uiDelay = 0;
					uiDelayValue = 12;
				}
				if (menuMode != MenuMode.MAP)
				{
					if (gpState.ThumbSticks.Right.X < -0.125f)
					{
						num = -num3;
					}
					else if (gpState.ThumbSticks.Right.X > 0.125f)
					{
						num = num3;
					}
					if (gpState.ThumbSticks.Right.Y < -0.125f)
					{
						num2 = num3;
					}
					else if (gpState.ThumbSticks.Right.Y > 0.125f)
					{
						num2 = -num3;
					}
				}
				if (menuType != MenuType.NONE || inventoryMode > 0)
				{
					if (gpState.ThumbSticks.Left.X < -0.125f)
					{
						num = -num3;
					}
					else if (gpState.ThumbSticks.Left.X > 0.125f)
					{
						num = num3;
					}
					if (gpState.ThumbSticks.Left.Y < -0.125f)
					{
						num2 = num3;
					}
					else if (gpState.ThumbSticks.Left.Y > 0.125f)
					{
						num2 = -num3;
					}
					if (inventoryMode == 0 || inventorySection != InventorySection.ITEMS)
					{
						if (gpState.DPad.Left == ButtonState.Pressed)
						{
							num = -num3;
						}
						else if (gpState.DPad.Right == ButtonState.Pressed)
						{
							num = num3;
						}
						if (gpState.DPad.Down == ButtonState.Pressed)
						{
							num2 = num3;
						}
						else if (gpState.DPad.Up == ButtonState.Pressed)
						{
							num2 = -num3;
						}
					}
				}
				if (uiDelay > 0)
				{
					if (num == 0 && num2 == 0)
					{
						uiDelay = 0;
						uiDelayValue = 12;
					}
					else
					{
						uiDelay--;
					}
				}
				if (uiDelay != 0)
				{
					return;
				}
				if (flag)
				{
					if (num != 0 || num2 != 0)
					{
						uiDelay = uiDelayValue;
						uiDelayValue = 6;
					}
					if (menuMode == MenuMode.MAP)
					{
						PositionMapScreenCursor(num, num2);
						return;
					}
					if (menuMode == MenuMode.WORLD_SELECT)
					{
						WorldSelect.UpdateCursor(num, num2);
						return;
					}
					if (menuMode == MenuMode.GAME_MODE)
					{
						GameMode.UpdateCursor(num, num2);
						return;
					}
					UpdateInventoryMenu();
					if (inventorySection == InventorySection.CRAFTING)
					{
						PositionCraftingCursor(num, num2);
					}
					else
					{
						PositionInventoryCursor(num, num2);
					}
				}
				else if (num != 0 || num2 != 0)
				{
					uiDelay = 4;
					mouseX += (short)num;
					if (mouseX < 0)
					{
						mouseX = 0;
					}
					else if (mouseX > 944)
					{
						mouseX = 944;
					}
					mouseY += (short)num2;
					if (mouseY < 0)
					{
						mouseY = 0;
					}
					else if (mouseY > 524)
					{
						mouseY = 524;
					}
				}
				return;
			}
			if (uiDelay > 0)
			{
				if (gpState.ThumbSticks.Left.LengthSquared() <= 0.015625f && gpState.ThumbSticks.Right.LengthSquared() <= 0.015625f && gpState.DPad.Up == ButtonState.Released && gpState.DPad.Down == ButtonState.Released && gpState.DPad.Left == ButtonState.Released && gpState.DPad.Right == ButtonState.Released)
				{
					uiDelay = 0;
					uiDelayValue = 12;
				}
				else
				{
					uiDelay--;
				}
				return;
			}
			int num4 = IsLeftButtonDown() ? (-1) : (IsRightButtonDown() ? 1 : 0);
			if (num4 < 0)
			{
				if (--uiX < 0)
				{
					uiX = (short)(uiWidth - 1);
				}
				uiDelay = uiDelayValue;
				uiDelayValue = 6;
			}
			else if (num4 > 0)
			{
				if (++uiX == uiWidth)
				{
					uiX = 0;
				}
				uiDelay = uiDelayValue;
				uiDelayValue = 6;
			}
			num4 = (IsDownButtonDown() ? (-1) : (IsUpButtonDown() ? 1 : 0));
			while (true)
			{
				if (num4 > 0)
				{
					if (--uiY < 0)
					{
						uiY = (short)(uiHeight - 1);
					}
					uiDelay = uiDelayValue;
					uiDelayValue = 6;
				}
				else if (num4 < 0)
				{
					if (++uiY == uiHeight)
					{
						uiY = 0;
					}
					uiDelay = uiDelayValue;
					uiDelayValue = 6;
				}
				mouseX = uiCoords[uiX + uiY * uiWidth].X;
				if (mouseX != 0)
				{
					break;
				}
				if (num4 == 0 && ++uiY >= uiHeight)
				{
					uiY = 0;
				}
			}
			mouseY = uiCoords[uiX + uiY * uiWidth].Y;
		}

		public static void UpdateOnce()
		{
			UpdateCursorColor();
			mouseTextBrightness = (byte)(mouseTextBrightness + mouseTextColorChange);
			if (mouseTextBrightness <= 175 || mouseTextBrightness >= 250)
			{
				mouseTextColorChange = (sbyte)(-mouseTextColorChange);
			}
			mouseTextColor.R = mouseTextBrightness;
			mouseTextColor.G = mouseTextBrightness;
			mouseTextColor.B = mouseTextBrightness;
			mouseTextColor.A = mouseTextBrightness;
			invAlpha = (byte)(invAlpha + invDir);
			if (invAlpha > 240)
			{
				invAlpha = 240;
				invDir = (sbyte)(-invDir);
			}
			else if (invAlpha < 180)
			{
				invAlpha = 180;
				invDir = (sbyte)(-invDir);
			}
			essScale += essDir;
			if (essScale > 1f)
			{
				essScale = 1f;
				essDir = 0f - essDir;
			}
			else if (essScale < 0.7f)
			{
				essScale = 0.7f;
				essDir = 0f - essDir;
			}
			blueWave += blueDelta;
			if (blueWave > 1f)
			{
				blueWave = 1f;
				blueDelta = 0f - blueDelta;
			}
			else if (blueWave < 0.97f)
			{
				blueWave = 0.97f;
				blueDelta = 0f - blueDelta;
			}
			if (MessageBox.current.autoUpdate)
			{
				MessageBox.Update();
			}
		}

		public void UpdateGamePad()
		{
			if (Main.hasFocus)
			{
				gpPrevState = gpState;
				gpState = GamePad.GetState(controller);
			}
			else
			{
				gpPrevState = (gpState = (gpState = default(GamePadState)));
			}
		}

		public void Update()
		{
			if (main.menuMode == MenuMode.WELCOME)
			{
				if (IsSelectButtonTriggered())
				{
					ClearButtonTriggers();
					OpenMainView();
				}
			}
			else if (view == null)
			{
				if (Main.isGameStarted && IsSelectButtonTriggered() && !Main.IsTutorial() && (Netplay.session == null || Netplay.session.AllGamers.Count != 8))
				{
					ClearButtonTriggers();
					SetMenu(MenuMode.CHARACTER_SELECT, rememberPrevious: false, reset: true);
					OpenView();
				}
				return;
			}
			current = this;
			if (menuType == MenuType.NONE)
			{
				if (IsButtonUntriggered(Buttons.Start))
				{
					Main.PlaySound(10);
					uiFade = 0f;
					uiFadeTarget = 1f;
					menuType = MenuType.PAUSE;
					SetMenu(MenuMode.PAUSE);
					ClearButtonTriggers();
				}
				else if (IsButtonTriggered(Buttons.Back))
				{
					miniMap.CreateMap(this);
					Main.PlaySound(10);
					if (Main.netMode == 1)
					{
						NetMessage.CreateMessage0(11);
						NetMessage.SendMessage();
					}
					SetMenu(MenuMode.MAP);
					menuType = MenuType.PAUSE;
					ClearButtonTriggers();
				}
			}
			else
			{
				if (transferredPlayerStorage.Count > 0 && !MessageBox.IsVisible())
				{
					DeleteTransferredPlayerStorage();
				}
				if (saveIconMessageTime <= 0)
				{
					UpdateMenu();
				}
			}
			if (menuType != 0)
			{
				UpdateIngame();
			}
			if (teamCooldown > 0 && --teamCooldown == 0 && teamSelected != player.team)
			{
				player.team = teamSelected;
				NetMessage.CreateMessage1(45, myPlayer);
				NetMessage.SendMessage();
			}
			if (pvpCooldown > 0 && --pvpCooldown == 0 && pvpSelected != player.hostile)
			{
				player.hostile = pvpSelected;
				NetMessage.CreateMessage1(30, myPlayer);
				NetMessage.SendMessage();
			}
			UpdateMouse();
			if (signedInGamer != null && !signedInGamer.IsGuest && !Main.isTrial)
			{
				UpdateAchievements();
			}
		}

		private void UpdateIngame()
		{
			if (editSign)
			{
				player.UpdateEditSign();
			}
			if (autoSave && Main.tutorialState == Tutorial.NUM_TUTORIALS && HasPlayerStorage())
			{
				if (!saveTime.IsRunning)
				{
					saveTime.Start();
				}
				else if (saveTime.ElapsedMilliseconds > 600000)
				{
					saveTime.Reset();
					if (Main.netMode == 1 || main != this)
					{
						WorldGen.savePlayerWhilePlaying();
					}
					else
					{
						WorldGen.saveAllWhilePlaying();
					}
				}
			}
			else if (saveTime.IsRunning)
			{
				saveTime.Stop();
			}
			view.itemTextLocal.Update();
			view.dustLocal.UpdateDust();
			view.spawnSnow();
		}

		private void OpenMainView(SignedInGamer gamer = null)
		{
			if (main != this)
			{
				view = main.view;
				view.ui = this;
				view.player = player;
				main.view = null;
				main = this;
				Main.musicVolume = musicVolume;
				Main.soundVolume = soundVolume;
			}
			signedInGamer = gamer;
			SetMenu(MenuMode.TITLE);
			if (gamer == null)
			{
				ShowSignInPortal();
			}
			else
			{
				InitPlayerStorage();
			}
		}

		private void OpenView()
		{
			CheckHDTV();
			MessageBox.Update();
			for (int i = 0; i < 4; i++)
			{
				UI uI = Main.ui[i];
				if (uI.view != null)
				{
					uI.setView(WorldView.getViewType(uI.controller, this), noAutoFullScreen: true);
				}
			}
			setView(WorldView.getViewType(controller, this), noAutoFullScreen: true);
			ShowSignInPortal();
		}

		public void ClearButtonTriggers()
		{
			gpPrevState = gpState;
		}

		public bool IsBackButtonTriggered()
		{
			if (!gpState.IsButtonDown(Buttons.Back) || !gpPrevState.IsButtonUp(Buttons.Back))
			{
				if (gpState.IsButtonDown(Buttons.B))
				{
					return gpPrevState.IsButtonUp(Buttons.B);
				}
				return false;
			}
			return true;
		}

		public bool IsSelectButtonTriggered()
		{
			if (!gpState.IsButtonDown(Buttons.Start) || !gpPrevState.IsButtonUp(Buttons.Start))
			{
				if (gpState.IsButtonDown(Buttons.A))
				{
					return gpPrevState.IsButtonUp(Buttons.A);
				}
				return false;
			}
			return true;
		}

		public bool IsLeftButtonDown()
		{
			if (!gpState.IsButtonDown(Buttons.DPadLeft) && !(gpState.ThumbSticks.Left.X < -0.125f))
			{
				return gpState.ThumbSticks.Right.X < -0.125f;
			}
			return true;
		}

		public bool IsRightButtonDown()
		{
			if (!gpState.IsButtonDown(Buttons.DPadRight) && !(gpState.ThumbSticks.Left.X > 0.125f))
			{
				return gpState.ThumbSticks.Right.X > 0.125f;
			}
			return true;
		}

		public bool IsUpButtonDown()
		{
			if (!gpState.IsButtonDown(Buttons.DPadUp) && !(gpState.ThumbSticks.Left.Y > 0.125f))
			{
				return gpState.ThumbSticks.Right.Y > 0.125f;
			}
			return true;
		}

		public bool IsDownButtonDown()
		{
			if (!gpState.IsButtonDown(Buttons.DPadDown) && !(gpState.ThumbSticks.Left.Y < -0.125f))
			{
				return gpState.ThumbSticks.Right.Y < -0.125f;
			}
			return true;
		}

		public bool IsAlternateLeftButtonDown()
		{
			return gpState.ThumbSticks.Right.X < -0.125f;
		}

		public bool IsAlternateRightButtonDown()
		{
			return gpState.ThumbSticks.Right.X > 0.125f;
		}

		public bool IsAlternateUpButtonDown()
		{
			return gpState.ThumbSticks.Right.Y > 0.125f;
		}

		public bool IsAlternateDownButtonDown()
		{
			return gpState.ThumbSticks.Right.Y < -0.125f;
		}

		public bool IsLeftButtonTriggered()
		{
			if (!gpState.IsButtonDown(Buttons.DPadLeft) || !gpPrevState.IsButtonUp(Buttons.DPadLeft))
			{
				if (gpState.ThumbSticks.Left.X < -0.125f)
				{
					return gpPrevState.ThumbSticks.Left.X >= -0.125f;
				}
				return false;
			}
			return true;
		}

		public bool IsRightButtonTriggered()
		{
			if (!gpState.IsButtonDown(Buttons.DPadRight) || !gpPrevState.IsButtonUp(Buttons.DPadRight))
			{
				if (gpState.ThumbSticks.Left.X > 0.125f)
				{
					return gpPrevState.ThumbSticks.Left.X <= 0.125f;
				}
				return false;
			}
			return true;
		}

		public bool IsButtonDown(Buttons b)
		{
			return gpState.IsButtonDown(b);
		}

		public bool IsButtonTriggered(Buttons b)
		{
			if (gpState.IsButtonDown(b))
			{
				return gpPrevState.IsButtonUp(b);
			}
			return false;
		}

		public bool IsButtonUntriggered(Buttons b)
		{
			if (gpState.IsButtonUp(b))
			{
				return gpPrevState.IsButtonDown(b);
			}
			return false;
		}

		private void DrawCursor()
		{
			if (menuType != MenuType.NONE || inventoryMode != 0 || npcChatText != null || player.dead)
			{
				return;
			}
			bool flag = player.inventory[player.selectedItem].pick > 0 || player.inventory[player.selectedItem].axe > 0 || player.inventory[player.selectedItem].hammer > 0 || player.inventory[player.selectedItem].createTile >= 0 || player.inventory[player.selectedItem].createWall >= 0;
			if (cursorHighlight > 0)
			{
				int num = (16 - (view.screenPosition.X & 0xF)) & 0xF;
				int x = ((mouseX - num) & -16) + num;
				num = ((16 - (view.screenPosition.Y & 0xF)) & 0xF);
				int y = ((mouseY - num) & -16) + num;
				Main.DrawRect(new Rectangle(x, y, 16, 16), new Color(cursorHighlight << 1, cursorHighlight << 1, 0, cursorHighlight << 1));
			}
			if (flag && player.velocity.X == 0f && player.velocity.Y == 0f)
			{
				if (cursorHighlight < 64)
				{
					cursorHighlight += 4;
				}
			}
			else if (cursorHighlight > 0)
			{
				cursorHighlight -= 2;
			}
			Rectangle value = default(Rectangle);
			value.Y = (int)(Main.frameCounter & 0x10);
			value.Width = 16;
			value.Height = 16;
			Vector2 position = default(Vector2);
			if (!smartCursor)
			{
				value.X = 16;
				position.X = mouseX - 8;
				position.Y = mouseY - 8;
			}
			else
			{
				if (player.controlDir.LengthSquared() <= 576f)
				{
					return;
				}
				position.X = player.aabb.X + 10 - view.screenPosition.X + (int)player.controlDir.X - 8;
				position.Y = player.aabb.Y + 21 - view.screenPosition.Y + (int)player.controlDir.Y - 8;
			}
			Main.spriteBatch.Draw(cursorTexture, position, value, Color.White);
		}

		public void DrawInventoryCursor(int x, int y, double scale, int alpha = 255)
		{
			alpha = mouseTextBrightness * alpha >> 8;
			SpriteSheet<_sheetSprites>.DrawTL(448, x, y, new Color(alpha, alpha, alpha, alpha), (float)scale);
			mouseX = (short)x;
			mouseY = (short)y;
		}

		public static bool IsStorageEnabledForAnyPlayer()
		{
			if (Main.isTrial)
			{
				return false;
			}
			for (int i = 0; i < 4; i++)
			{
				if (Main.ui[i].HasPlayerStorage())
				{
					return true;
				}
			}
			return false;
		}

		public void CheckPlayerStorage(string name)
		{
			bool isTransferredFromOtherPlayer;
			IAsyncResult asyncResult = playerStorage.Device.BeginOpenContainer(name, allowTransferBetweenPlayers: true, out isTransferredFromOtherPlayer, null, null);
			asyncResult.AsyncWaitHandle.WaitOne();
			StorageContainer storageContainer = playerStorage.Device.EndOpenContainer(asyncResult);
			asyncResult.AsyncWaitHandle.Close();
			if (isTransferredFromOtherPlayer)
			{
				if (storageContainer.GetFileNames().Length == 0)
				{
					Main.ShowSaveIcon();
					Main.HideSaveIcon();
				}
				else
				{
					MessageBox.Show(controller, Lang.menu[9], string.Format(Lang.inter[78], name), new string[1]
					{
						Lang.menu[90]
					});
					transferredPlayerStorage.Add(name);
				}
			}
			storageContainer.Dispose();
		}

		public void DeleteTransferredPlayerStorage()
		{
			for (int num = transferredPlayerStorage.Count - 1; num >= 0; num--)
			{
				playerStorage.Device.DeleteContainer(transferredPlayerStorage[num]);
			}
			transferredPlayerStorage.Clear();
			DeviceSelected(null, null);
		}

		public StorageContainer OpenPlayerStorage(string name)
		{
			IAsyncResult asyncResult = playerStorage.Device.BeginOpenContainer(name, null, null);
			asyncResult.AsyncWaitHandle.WaitOne();
			StorageContainer result = playerStorage.Device.EndOpenContainer(asyncResult);
			asyncResult.AsyncWaitHandle.Close();
			return result;
		}

		private void DeviceDisconnected(object sender, EventArgs args)
		{
			LoadPlayers();
			WorldSelect.LoadWorlds();
			MessageBox.Show(controller, Lang.menu[69], Lang.menu[70], new string[1]
			{
				Lang.menu[90]
			});
			if (menuMode == MenuMode.CONFIRM_DELETE_CHARACTER || menuMode == MenuMode.CONFIRM_DELETE_WORLD)
			{
				PrevMenu();
			}
		}

		private void DeviceSelectorCanceled(object sender, EventArgs args)
		{
			LoadPlayers();
			WorldSelect.LoadWorlds();
			MessageBox.Show(controller, Lang.menu[69], Lang.menu[66], new string[1]
			{
				Lang.menu[90]
			});
		}

		private void DeviceSelected(object sender, EventArgs e)
		{
			try
			{
				CheckPlayerStorage("Settings");
				CheckPlayerStorage("Characters");
				CheckPlayerStorage("Worlds");
			}
			catch (Exception)
			{
				transferredPlayerStorage.Clear();
				return;
			}
			if (transferredPlayerStorage.Count <= 0)
			{
				if (!OpenSettings())
				{
					MessageBox.Show(controller, Lang.menu[9], Lang.menu[102], new string[1]
					{
						Lang.menu[90]
					});
				}
				LoadPlayers();
				if (this == main && !WorldSelect.LoadWorlds())
				{
					MessageBox.Show(controller, Lang.menu[9], Lang.menu[103], new string[1]
					{
						Lang.menu[90]
					});
				}
			}
		}

		public void LoadPlayers()
		{
			if (HasPlayerStorage())
			{
				try
				{
					using (StorageContainer storageContainer = OpenPlayerStorage("Characters"))
					{
						while (true)
						{
							IL_0017:
							string[] fileNames = storageContainer.GetFileNames("player?.plr");
							int num = fileNames.Length;
							if (num > 5)
							{
								num = 5;
							}
							int num2 = 0;
							while (true)
							{
								if (num2 >= 5)
								{
									numLoadPlayers = (sbyte)num;
									break;
								}
								if (num2 < num)
								{
									loadPlayerPath[num2] = fileNames[num2];
									loadPlayer[num2].Load(storageContainer, loadPlayerPath[num2]);
									if (loadPlayer[num2].name == null)
									{
										MessageBox.Show(controller, Lang.menu[9], Lang.menu[12], new string[1]
										{
											Lang.menu[90]
										});
										goto IL_0017;
									}
								}
								else
								{
									loadPlayer[num2] = new Player();
								}
								num2++;
							}
							break;
						}
					}
				}
				catch (IOException)
				{
					ReadError();
					numLoadPlayers = 0;
				}
				catch (Exception)
				{
					numLoadPlayers = 0;
				}
			}
			else
			{
				numLoadPlayers = 0;
			}
			if (menuMode == MenuMode.CHARACTER_SELECT)
			{
				ResetPlayerMenuSelection();
			}
		}

		public void SaveSettings()
		{
			if (HasPlayerStorage())
			{
				using (MemoryStream memoryStream = new MemoryStream(512))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						binaryWriter.Write(5);
						binaryWriter.Write(0u);
						binaryWriter.Write(soundVolume);
						binaryWriter.Write(musicVolume);
						binaryWriter.Write(autoSave);
						binaryWriter.Write(showItemText);
						binaryWriter.Write(alternateGrappleControls);
						byte[] buffer = Statistics.Serialize();
						binaryWriter.Write(buffer);
						binaryWriter.Write(totalSteps);
						binaryWriter.Write(totalPicked);
						binaryWriter.Write(totalBarsCrafted);
						binaryWriter.Write(totalAnvilCrafting);
						binaryWriter.Write(totalWires);
						binaryWriter.Write(totalAirTime);
						binaryWriter.Write(petSpawnMask);
						int num = armorFound.Length + 7 >> 3;
						byte[] array = new byte[num];
						armorFound.CopyTo(array, 0);
						binaryWriter.Write((ushort)num);
						binaryWriter.Write(array, 0, num);
						binaryWriter.Write(isOnline);
						binaryWriter.Write(isInviteOnly);
						num = blacklist.Count;
						int num2 = num;
						if (num > 65535)
						{
							num = 65535;
						}
						binaryWriter.Write((ushort)num);
						for (int i = num2 - num; i < num2; i++)
						{
							binaryWriter.Write(blacklist[i]);
						}
						CRC32 cRC = new CRC32();
						cRC.Update(memoryStream.GetBuffer(), 8, (int)memoryStream.Length - 8);
						binaryWriter.Seek(4, SeekOrigin.Begin);
						binaryWriter.Write(cRC.GetValue());
						Main.ShowSaveIcon();
						try
						{
							if (TestStorageSpace("Settings", "config.dat", (int)memoryStream.Length))
							{
								using (StorageContainer storageContainer = OpenPlayerStorage("Settings"))
								{
									using (Stream stream = storageContainer.OpenFile("config.dat", FileMode.Create))
									{
										stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
										stream.Close();
									}
									settingsDirty = false;
								}
							}
						}
						catch (IOException)
						{
							WriteError();
						}
						catch (Exception)
						{
						}
						binaryWriter.Close();
						Main.HideSaveIcon();
					}
				}
			}
		}

		private bool OpenSettings()
		{
			bool flag = true;
			try
			{
				using (StorageContainer storageContainer = OpenPlayerStorage("Settings"))
				{
					if (storageContainer.FileExists("config.dat"))
					{
						try
						{
							using (Stream stream = storageContainer.OpenFile("config.dat", FileMode.Open))
							{
								using (MemoryStream memoryStream = new MemoryStream((int)stream.Length))
								{
									memoryStream.SetLength(stream.Length);
									stream.Read(memoryStream.GetBuffer(), 0, (int)stream.Length);
									stream.Close();
									using (BinaryReader binaryReader = new BinaryReader(memoryStream))
									{
										int num = binaryReader.ReadInt32();
										if (num > 5)
										{
											throw new InvalidOperationException("Invalid version");
										}
										if (num >= 4)
										{
											CRC32 cRC = new CRC32();
											cRC.Update(memoryStream.GetBuffer(), 8, (int)memoryStream.Length - 8);
											if (cRC.GetValue() != binaryReader.ReadUInt32())
											{
												throw new InvalidOperationException("Invalid CRC32");
											}
										}
										soundVolume = binaryReader.ReadSingle();
										musicVolume = binaryReader.ReadSingle();
										autoSave = binaryReader.ReadBoolean();
										showItemText = binaryReader.ReadBoolean();
										alternateGrappleControls = binaryReader.ReadBoolean();
										if (num <= 3)
										{
											alternateGrappleControls = false;
										}
										UpdateAlternateGrappleControls();
										if (this == main)
										{
											Main.musicVolume = musicVolume;
											Main.soundVolume = soundVolume;
										}
										int count = Statistics.CalculateSerialisationSize();
										byte[] stream2 = binaryReader.ReadBytes(count);
										Statistics.Deserialize(stream2);
										if (num >= 2)
										{
											if (num >= 3)
											{
												totalSteps = binaryReader.ReadUInt32();
												totalPicked = binaryReader.ReadUInt32();
												totalBarsCrafted = binaryReader.ReadUInt32();
												totalAnvilCrafting = binaryReader.ReadUInt32();
												totalWires = binaryReader.ReadUInt32();
												totalAirTime = binaryReader.ReadUInt32();
												petSpawnMask = binaryReader.ReadByte();
												int count2 = binaryReader.ReadUInt16();
												armorFound = new BitArray(binaryReader.ReadBytes(count2));
												if (armorFound.Length < 632)
												{
													armorFound.Length = 632;
												}
											}
											isOnline = binaryReader.ReadBoolean();
											isInviteOnly = binaryReader.ReadBoolean();
										}
										blacklist.Clear();
										if (num >= 5)
										{
											int num2 = binaryReader.ReadUInt16();
											blacklist.Capacity = num2 + 4;
											while (num2 > 0)
											{
												blacklist.Add(binaryReader.ReadUInt64());
												num2--;
											}
										}
										binaryReader.Close();
									}
								}
							}
						}
						catch (InvalidOperationException)
						{
							Main.ShowSaveIcon();
							flag = false;
							storageContainer.DeleteFile("config.dat");
							armorFound = new BitArray(632);
							Main.HideSaveIcon();
						}
						catch (Exception)
						{
						}
					}
				}
				settingsDirty = !flag;
			}
			catch (IOException)
			{
				if (!flag)
				{
					WriteError();
					flag = true;
				}
				else
				{
					ReadError();
				}
			}
			catch (Exception)
			{
			}
			if (Main.netMode == 1 && Main.isGameStarted)
			{
				CheckBlacklist();
			}
			return flag;
		}

		public void ErasePlayer(int i)
		{
			if (HasPlayerStorage())
			{
				Main.ShowSaveIcon();
				try
				{
					using (StorageContainer storageContainer = OpenPlayerStorage("Characters"))
					{
						storageContainer.DeleteFile(loadPlayerPath[i]);
					}
				}
				catch (IOException)
				{
					WriteError();
				}
				catch (Exception)
				{
				}
				Main.HideSaveIcon();
			}
			numLoadPlayers--;
			loadPlayer[i] = loadPlayer[numLoadPlayers];
			loadPlayerPath[i] = loadPlayerPath[numLoadPlayers];
		}

		private string nextLoadPlayer()
		{
			int num = 0;
			string result = null;
			if (HasPlayerStorage())
			{
				try
				{
					using (StorageContainer storageContainer = OpenPlayerStorage("Characters"))
					{
						do
						{
							num++;
							result = "player" + num + ".plr";
						}
						while (storageContainer.FileExists(result));
						return result;
					}
				}
				catch (IOException)
				{
					ReadError();
					return null;
				}
				catch (Exception)
				{
					return null;
				}
			}
			return result;
		}

		public void setView(WorldView.Type viewType, bool noAutoFullScreen = false)
		{
			if (view != null)
			{
				for (int i = 0; i < numActiveViews; i++)
				{
					if (activeView[i] == view)
					{
						activeView[i] = activeView[--numActiveViews];
						activeView[numActiveViews] = null;
						break;
					}
				}
			}
			if (viewType != WorldView.Type.NONE)
			{
				if (view == null)
				{
					view = new WorldView();
					view.player = player;
					view.ui = this;
				}
				activeView[numActiveViews++] = view;
				current = this;
				if (numActiveViews == 2)
				{
					LoadSplitscreenFonts(theGame.Content);
					InvalidateCachedText();
				}
				if (view.setViewType(viewType) && menuType != 0)
				{
					worldFade = -0.25f;
				}
			}
			else if (view != null)
			{
				view.Dispose();
				view = null;
				if (numActiveViews == 1)
				{
					LoadFonts(theGame.Content);
					InvalidateCachedText();
				}
				if (main == this)
				{
					if (numActiveViews > 0)
					{
						for (int j = 0; j < 4; j++)
						{
							if (Main.ui[j].view != null)
							{
								main = Main.ui[j];
								WorldSelect.LoadWorlds();
								break;
							}
						}
					}
					else
					{
						main = null;
					}
				}
			}
			else
			{
				noAutoFullScreen = true;
			}
			if (player != null)
			{
				player.view = view;
				if (view == null)
				{
					player.active = 0;
				}
			}
			if (noAutoFullScreen)
			{
				return;
			}
			if (numActiveViews == 1 && main != null && main.view != null && !main.view.isFullScreen())
			{
				main.view.setViewType();
				if (main.menuType != 0)
				{
					main.worldFade = -0.25f;
				}
				return;
			}
			for (int k = 0; k < 4; k++)
			{
				UI uI = Main.ui[k];
				if (uI.view != null)
				{
					uI.view.setViewType(WorldView.getViewType(uI.controller));
				}
			}
		}

		public void setPlayer(int id, bool swapIfUsed = true)
		{
			if (id < 0)
			{
				for (int num = 7; num >= 0; num--)
				{
					if (Main.player[num].active == 0 && Main.player[num].view == null)
					{
						id = num;
						break;
					}
				}
				if (id < 0)
				{
					myPlayer = 8;
					this.player = null;
					return;
				}
			}
			if (this.player != null && id != myPlayer)
			{
				Player player = this.player.DeepCopy();
				player.whoAmI = (byte)id;
				this.player.ui = null;
				this.player.view = null;
				if (swapIfUsed)
				{
					for (int i = 0; i < 4; i++)
					{
						UI uI = Main.ui[i];
						if (uI != this && uI.myPlayer == id)
						{
							uI.setPlayer(myPlayer, swapIfUsed: false);
							break;
						}
					}
				}
				if (id != myPlayer)
				{
					Main.player[id] = player;
				}
			}
			myPlayer = (byte)id;
			this.player = Main.player[id];
			this.player.ui = this;
			this.player.view = view;
			if (signedInGamer != null)
			{
				this.player.name = signedInGamer.Gamertag;
			}
			teamCooldown = 0;
			teamSelected = this.player.team;
			pvpCooldown = 0;
			pvpSelected = this.player.hostile;
			if (view != null)
			{
				view.player = this.player;
			}
			else
			{
				this.player.active = 0;
			}
		}

		public void setPlayer(Player p)
		{
			if (player != null && p != player)
			{
				player.ui = null;
				player.view = null;
			}
			player = p;
			teamCooldown = 0;
			pvpCooldown = 0;
			if (view != null)
			{
				view.player = p;
			}
			if (p != null)
			{
				teamSelected = p.team;
				pvpSelected = p.hostile;
				p.ui = this;
				p.view = view;
				p.whoAmI = myPlayer;
				if (signedInGamer != null)
				{
					p.name = signedInGamer.Gamertag;
				}
				p.active = 0;
				Main.player[myPlayer] = p;
			}
			else
			{
				myPlayer = 8;
				setView(WorldView.Type.NONE);
			}
		}

		public void JoinSession(int newPlayerIndex)
		{
			setPlayer(newPlayerIndex);
			if (Main.netMode == 1)
			{
				NetMessage.CreateMessage0(11);
				NetMessage.SendMessage();
			}
		}

		public void LeaveSession()
		{
			localGamer = null;
		}

		public void InviteAccepted(InviteAcceptedEventArgs e)
		{
			if (e.IsCurrentSession || Netplay.isJoiningRemoteInvite)
			{
				if (Netplay.session == null)
				{
					if (!Netplay.gamersWhoReceivedInvite.Contains(e.Gamer))
					{
						Netplay.gamersWhoReceivedInvite.Add(e.Gamer);
					}
					if (!Netplay.gamersWaitingToJoinInvite.Contains(e.Gamer))
					{
						Netplay.gamersWaitingToJoinInvite.Add(e.Gamer);
					}
				}
				if (view == null)
				{
					SetMenu(MenuMode.CHARACTER_SELECT, rememberPrevious: false, reset: true);
					OpenView();
				}
				return;
			}
			Netplay.isJoiningRemoteInvite = true;
			Netplay.gamersWhoReceivedInvite.Add(e.Gamer);
			Netplay.gamersWaitingToJoinInvite.Add(e.Gamer);
			for (int i = 0; i < 4; i++)
			{
				SignedInGamer signedInGamer = Main.ui[i].signedInGamer;
				if (signedInGamer != null && !Netplay.gamersWaitingToJoinInvite.Contains(signedInGamer))
				{
					Netplay.gamersWaitingToJoinInvite.Add(signedInGamer);
				}
			}
			if (Netplay.session != null)
			{
				ExitGame();
				return;
			}
			if (main.menuMode == MenuMode.WELCOME)
			{
				OpenMainView(e.Gamer);
				return;
			}
			if (Main.worldGenThread != null)
			{
				Main.worldGenThread.Abort();
				Main.worldGenThread = null;
				WorldGen.gen = false;
			}
			main.SetMenu(MenuMode.TITLE, rememberPrevious: false, reset: true);
		}

		private static void CancelInvite(SignedInGamer gamer)
		{
			Netplay.gamersWhoReceivedInvite.Remove(gamer);
			if (Netplay.gamersWhoReceivedInvite.Count == 0)
			{
				Netplay.isJoiningRemoteInvite = false;
				Netplay.gamersWaitingToJoinInvite.Clear();
			}
			else
			{
				Netplay.gamersWaitingToJoinInvite.Remove(gamer);
			}
		}

		private unsafe void DrawControlsIngame()
		{
			if (menuType == MenuType.NONE)
			{
				Main.strBuilder.Length = 0;
				if (!Main.TutorialMaskY)
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INVENTORY));
					Main.strBuilder.Append(' ');
				}
				if (player.grappleItemSlot >= 0)
				{
					Main.strBuilder.Append(Lang.controls(alternateGrappleControls ? Lang.CONTROLS.GRAPPLE_ALT : Lang.CONTROLS.GRAPPLE));
					Main.strBuilder.Append(' ');
				}
				fixed (Item* ptr = &player.inventory[player.selectedItem])
				{
					if (!Main.TutorialMaskRT && ptr->type > 0)
					{
						if (ptr->pick > 0)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DIG));
						}
						else if (ptr->axe > 0)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHOP));
						}
						else if (ptr->hammer > 0)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.HIT));
						}
						else if (ptr->createTile >= 0 || ptr->createWall >= 0)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BUILD));
						}
						else if (ptr->ammo > 0 || ptr->damage > 0)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.ATTACK));
						}
						else
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.USE));
						}
						Main.strBuilder.Append(' ');
					}
					if (!Main.TutorialMaskB)
					{
						if (player.npcChatBubble >= 0)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.TALK));
						}
						else if (player.tileInteractX != 0)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INTERACT));
						}
					}
				}
				DrawStringLB(fontSmallOutline, view.SAFE_AREA_OFFSET_L, view.SAFE_AREA_OFFSET_B);
			}
		}

		private void DrawControlsInventory()
		{
			if (menuType != MenuType.NONE)
			{
				return;
			}
			Main.strBuilder.Length = 0;
			Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
			Main.strBuilder.Append(' ');
			if (toolTip.type > 0 && !reforge && !craftGuide)
			{
				if (toolTip.isEquipable() && (inventorySection != InventorySection.EQUIP || inventoryEquipX == 0))
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.EQUIP));
					Main.strBuilder.Append(' ');
				}
				if (toolTip.type >= 599 && toolTip.type <= 601)
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.OPEN));
					Main.strBuilder.Append(' ');
				}
				else if (toolTip.stack > 1 && (mouseItem.type == 0 || mouseItem.netID == toolTip.netID))
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT_ONE));
					Main.strBuilder.Append(' ');
				}
			}
			if (mouseItem.type == 0)
			{
				if (toolTip.type > 0)
				{
					if (reforge)
					{
						if (toolTip.Prefix(-3))
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.REFORGE));
							Main.strBuilder.Append(' ');
						}
					}
					else if (craftGuide)
					{
						if (toolTip.material)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_RECIPES));
							Main.strBuilder.Append(' ');
						}
					}
					else
					{
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT_ALL));
						Main.strBuilder.Append(' ');
					}
				}
				else if (inventorySection == InventorySection.CHEST)
				{
					if (inventoryChestX < 0)
					{
						switch (inventoryChestY)
						{
						case 1:
							Main.strBuilder.Append(Lang.inter[29]);
							break;
						case 2:
							Main.strBuilder.Append(Lang.inter[30]);
							break;
						case 3:
							Main.strBuilder.Append(Lang.inter[31]);
							break;
						}
						Main.strBuilder.Append(' ');
					}
				}
				else if (inventorySection == InventorySection.EQUIP && inventoryEquipY == 0)
				{
					int num = inventoryEquipX + inventoryBuffX;
					if (player.buff[num].Time > 0 && !player.buff[num].IsDebuff())
					{
						Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CANCEL_BUFF));
						Main.strBuilder.Append(' ');
					}
				}
			}
			else
			{
				bool flag = false;
				bool flag2 = true;
				if (inventorySection == InventorySection.EQUIP)
				{
					switch (inventoryEquipY)
					{
					case 0:
						flag = (mouseItem.headSlot >= 0);
						break;
					case 1:
						flag = (mouseItem.bodySlot >= 0);
						break;
					case 2:
						flag = (mouseItem.legSlot >= 0);
						break;
					default:
						flag = mouseItem.accessory;
						break;
					}
				}
				else if (inventorySection == InventorySection.ITEMS && mouseItem.type > 0 && mouseItem.stack > 0)
				{
					switch (inventoryItemY)
					{
					case 4:
						flag2 = mouseItem.CanBePlacedInAmmoSlot();
						break;
					case 5:
						flag2 = mouseItem.CanBePlacedInCoinSlot();
						break;
					}
				}
				if (flag2)
				{
					if (toolTip.type > 0 && (toolTip.netID != mouseItem.netID || toolTip.stack == toolTip.maxStack || mouseItem.stack == mouseItem.maxStack))
					{
						if (inventorySection != InventorySection.EQUIP || flag)
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SWAP));
							Main.strBuilder.Append(' ');
						}
					}
					else if (toolTip.type == 0 || toolTip.stack < toolTip.maxStack)
					{
						if (inventorySection == InventorySection.EQUIP)
						{
							if (flag)
							{
								Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.PLACE_EQUIPMENT));
								Main.strBuilder.Append(' ');
							}
						}
						else
						{
							Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.PLACE));
							Main.strBuilder.Append(' ');
						}
					}
				}
			}
			Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
			Main.strBuilder.Append(' ');
			if (!reforge && !craftGuide)
			{
				if (mouseItem.type > 0)
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DROP));
					Main.strBuilder.Append(' ');
				}
				else if (inventorySection == InventorySection.ITEMS && toolTip.type > 0)
				{
					Lang.CONTROLS i = (npcShop <= 0) ? Lang.CONTROLS.TRASH : Lang.CONTROLS.SELL;
					Main.strBuilder.Append(Lang.controls(i));
					Main.strBuilder.Append(' ');
				}
			}
			DrawStringLB(fontSmallOutline, view.SAFE_AREA_OFFSET_L, view.SAFE_AREA_OFFSET_B);
		}

		private void DrawControlsShop()
		{
			if (menuType != MenuType.NONE)
			{
				return;
			}
			Main.strBuilder.Length = 0;
			Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
			Main.strBuilder.Append(' ');
			if (toolTip.type > 0 && toolTip.stack > 1 && (mouseItem.type == 0 || mouseItem.netID == toolTip.netID))
			{
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BUY_ONE));
				Main.strBuilder.Append(' ');
			}
			if (mouseItem.type == 0)
			{
				if (toolTip.type > 0)
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BUY_ALL));
					Main.strBuilder.Append(' ');
				}
			}
			else if (toolTip.type == 0)
			{
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELL_ITEM_IN_HAND));
				Main.strBuilder.Append(' ');
			}
			Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
			Main.strBuilder.Append(' ');
			if (mouseItem.type > 0)
			{
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DROP));
				Main.strBuilder.Append(' ');
			}
			DrawStringLB(fontSmallOutline, view.SAFE_AREA_OFFSET_L, view.SAFE_AREA_OFFSET_B);
		}

		private void DrawControlsCrafting()
		{
			if (menuType == MenuType.NONE)
			{
				Main.strBuilder.Length = 0;
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
				Main.strBuilder.Append(' ');
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CRAFTING_CATEGORY));
				Main.strBuilder.Append(' ');
				if (player.CanCraftRecipe(craftingRecipe))
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CRAFT));
					Main.strBuilder.Append(' ');
				}
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
				Main.strBuilder.Append(' ');
				if (mouseItem.type > 0)
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DROP));
					Main.strBuilder.Append(' ');
				}
				else
				{
					Main.strBuilder.Append(Lang.controls(craftingShowCraftable ? Lang.CONTROLS.SHOW_ALL : Lang.CONTROLS.SHOW_AVAILABLE));
					Main.strBuilder.Append(' ');
				}
				Lang.CONTROLS i = (craftingSection == CraftingSection.RECIPES) ? Lang.CONTROLS.INGREDIENTS : Lang.CONTROLS.RECIPES;
				Main.strBuilder.Append(Lang.controls(i));
				DrawStringLB(fontSmallOutline, view.SAFE_AREA_OFFSET_L, view.SAFE_AREA_OFFSET_B);
			}
		}

		private void DrawControlsHousing()
		{
			if (menuType == MenuType.NONE)
			{
				Main.strBuilder.Length = 0;
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
				Main.strBuilder.Append(' ');
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHECK_HOUSING));
				Main.strBuilder.Append(' ');
				Main.strBuilder.Append(Lang.controls(showNPCs ? Lang.CONTROLS.HIDE_BANNERS : Lang.CONTROLS.SHOW_BANNERS));
				Main.strBuilder.Append(' ');
				if (inventoryHousingNpc >= 0)
				{
					Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.ASSIGN_TO_ROOM));
					Main.strBuilder.Append(' ');
				}
				Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
				Main.strBuilder.Append(' ');
				DrawStringLB(fontSmallOutline, view.SAFE_AREA_OFFSET_L, view.SAFE_AREA_OFFSET_B);
			}
		}

		public int DrawDialog(Vector2 pos, Color backColor, Color textColor, CompiledText ct, string caption = null, bool anchorBottom = false)
		{
			int num = 30;
			if (anchorBottom)
			{
				pos.Y -= ct.Height + num;
				num = 0;
			}
			Main.spriteBatch.Draw(chatBackTexture, pos, new Rectangle(0, 0, chatBackTexture.Width, ct.Height + num), backColor);
			pos.Y += ct.Height + num;
			Main.spriteBatch.Draw(chatBackTexture, pos, new Rectangle(0, chatBackTexture.Height - 30, chatBackTexture.Width, 30), backColor);
			pos.Y -= ct.Height + num;
			if (caption != null)
			{
				int num2 = (int)fontSmallOutline.MeasureString(caption).X;
				int num3 = chatBackTexture.Width - num2 >> 1;
				int num4 = 0;
				Main.spriteBatch.DrawString(fontSmallOutline, caption, new Vector2(pos.X + (float)num3, pos.Y + (float)num4), Color.LightGreen);
				pos.Y += num;
			}
			else
			{
				pos.Y += 10f;
			}
			pos.X += 20f;
			ct.Draw(Main.spriteBatch, new Rectangle((int)pos.X, (int)pos.Y, 470, 540), textColor, new Color(255, 212, 64, 255));
			return ct.Height;
		}

		private void HelpText()
		{
			bool flag = player.statLifeMax > 100;
			bool flag2 = player.statManaMax > 0;
			bool flag3 = true;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			for (int i = 0; i < 48; i++)
			{
				if (player.inventory[i].pick > 0 && player.inventory[i].netID != -13)
				{
					flag3 = false;
				}
				else if (player.inventory[i].axe > 0 && player.inventory[i].netID != -16)
				{
					flag3 = false;
				}
				else if (player.inventory[i].hammer > 0)
				{
					flag3 = false;
				}
				switch (player.inventory[i].type)
				{
				case 11:
				case 12:
				case 13:
				case 14:
					flag4 = true;
					break;
				case 19:
				case 20:
				case 21:
				case 22:
					flag5 = true;
					break;
				case 75:
					flag6 = true;
					break;
				case 38:
					flag7 = true;
					break;
				case 68:
				case 70:
					flag8 = true;
					break;
				case 84:
					flag9 = true;
					break;
				}
			}
			bool flag10 = false;
			bool flag11 = false;
			bool flag12 = false;
			bool flag13 = false;
			bool flag14 = false;
			bool flag15 = false;
			bool flag16 = false;
			bool flag17 = false;
			bool flag18 = false;
			for (int j = 0; j < 196; j++)
			{
				if (Main.npc[j].active != 0)
				{
					switch (Main.npc[j].type)
					{
					case 17:
						flag10 = true;
						break;
					case 18:
						flag11 = true;
						break;
					case 19:
						flag13 = true;
						break;
					case 20:
						flag12 = true;
						break;
					case 107:
						flag17 = true;
						break;
					case 54:
						flag18 = true;
						break;
					case 124:
						flag15 = true;
						break;
					case 38:
						flag14 = true;
						break;
					case 108:
						flag16 = true;
						break;
					}
				}
			}
			while (true)
			{
				helpText++;
				if (flag3)
				{
					if (helpText == 1)
					{
						npcChatText = Lang.dialog(player, 177);
						return;
					}
					if (helpText == 2)
					{
						npcChatText = Lang.dialog(player, 178);
						return;
					}
					if (helpText == 3)
					{
						npcChatText = Lang.dialog(player, 179);
						return;
					}
					if (helpText == 4)
					{
						npcChatText = Lang.dialog(player, 180);
						return;
					}
					if (helpText == 5)
					{
						npcChatText = Lang.dialog(player, 181);
						return;
					}
					if (helpText == 6)
					{
						npcChatText = Lang.dialog(player, 182);
						return;
					}
				}
				if (flag3 && !flag4 && !flag5 && helpText == 11)
				{
					npcChatText = Lang.dialog(player, 183);
					return;
				}
				if (flag3 && flag4 && !flag5)
				{
					if (helpText == 21)
					{
						npcChatText = Lang.dialog(player, 184);
						return;
					}
					if (helpText == 22)
					{
						npcChatText = Lang.dialog(player, 185);
						return;
					}
				}
				if (flag3 && flag5)
				{
					if (helpText == 31)
					{
						npcChatText = Lang.dialog(player, 186);
						return;
					}
					if (helpText == 32)
					{
						npcChatText = Lang.dialog(player, 187);
						return;
					}
				}
				if (!flag && helpText == 41)
				{
					npcChatText = Lang.dialog(player, 188);
					return;
				}
				if (!flag2 && helpText == 42)
				{
					npcChatText = Lang.dialog(player, 189);
					return;
				}
				if (!flag2 && !flag6 && helpText == 43)
				{
					npcChatText = Lang.dialog(player, 190);
					return;
				}
				if (!flag10 && !flag11)
				{
					if (helpText == 51)
					{
						npcChatText = Lang.dialog(player, 191);
						return;
					}
					if (helpText == 52)
					{
						npcChatText = Lang.dialog(player, 192);
						return;
					}
					if (helpText == 53)
					{
						npcChatText = Lang.dialog(player, 193);
						return;
					}
					if (helpText == 54)
					{
						npcChatText = Lang.dialog(player, 194);
						return;
					}
				}
				if (!flag10 && helpText == 61)
				{
					npcChatText = Lang.dialog(player, 195);
					return;
				}
				if (!flag11 && helpText == 62)
				{
					npcChatText = Lang.dialog(player, 196);
					return;
				}
				if (!flag13 && helpText == 63)
				{
					npcChatText = Lang.dialog(player, 197);
					return;
				}
				if (!flag12 && helpText == 64)
				{
					npcChatText = Lang.dialog(player, 198);
					return;
				}
				if (!flag15 && helpText == 65 && NPC.downedBoss3)
				{
					npcChatText = Lang.dialog(player, 199);
					return;
				}
				if (!flag18 && helpText == 66 && NPC.downedBoss3)
				{
					npcChatText = Lang.dialog(player, 200);
					return;
				}
				if (!flag14 && helpText == 67)
				{
					npcChatText = Lang.dialog(player, 201);
					return;
				}
				if (!flag17 && NPC.downedBoss2 && helpText == 68)
				{
					npcChatText = Lang.dialog(player, 202);
					return;
				}
				if (!flag16 && Main.hardMode && helpText == 69)
				{
					npcChatText = Lang.dialog(player, 203);
					return;
				}
				if (flag7 && helpText == 71)
				{
					npcChatText = Lang.dialog(player, 204);
					return;
				}
				if (flag8 && helpText == 72)
				{
					npcChatText = Lang.dialog(player, 205);
					return;
				}
				if ((flag7 || flag8) && helpText == 80)
				{
					npcChatText = Lang.dialog(player, 206);
					return;
				}
				if (!flag9 && helpText == 201 && !Main.hardMode && !NPC.downedBoss3 && !NPC.downedBoss2)
				{
					npcChatText = Lang.dialog(player, 207);
					return;
				}
				if (helpText == 1000 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					npcChatText = Lang.dialog(player, 208);
					return;
				}
				if (helpText == 1001 && !NPC.downedBoss1 && !NPC.downedBoss2)
				{
					npcChatText = Lang.dialog(player, 209);
					return;
				}
				if (helpText == 1002 && !NPC.downedBoss3)
				{
					npcChatText = Lang.dialog(player, 210);
					return;
				}
				if (helpText == 1050 && !NPC.downedBoss1)
				{
					if (player.statLifeMax < 200)
					{
						npcChatText = Lang.dialog(player, 211);
						return;
					}
					continue;
				}
				if (helpText == 1051 && !NPC.downedBoss1)
				{
					if (player.statDefense <= 10)
					{
						npcChatText = Lang.dialog(player, 212);
						return;
					}
					continue;
				}
				if (helpText == 1052 && !NPC.downedBoss1)
				{
					if (player.statLifeMax >= 200 && player.statDefense > 10)
					{
						npcChatText = Lang.dialog(player, 213);
						return;
					}
					continue;
				}
				if (helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2)
				{
					if (player.statLifeMax < 300)
					{
						npcChatText = Lang.dialog(player, 214);
						return;
					}
					continue;
				}
				if (helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2)
				{
					if (player.statLifeMax >= 300)
					{
						npcChatText = Lang.dialog(player, 215);
						return;
					}
					continue;
				}
				if (helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2)
				{
					if (player.statLifeMax >= 300)
					{
						npcChatText = Lang.dialog(player, 216);
						return;
					}
					continue;
				}
				if (helpText == 1056 && NPC.downedBoss1 && NPC.downedBoss2 && !NPC.downedBoss3)
				{
					npcChatText = Lang.dialog(player, 217);
					return;
				}
				if (helpText == 1057 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && player.statLifeMax < 400)
				{
					npcChatText = Lang.dialog(player, 218);
					return;
				}
				if (helpText == 1058 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && player.statLifeMax >= 400)
				{
					npcChatText = Lang.dialog(player, 219);
					return;
				}
				if (helpText == 1059 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && player.statLifeMax >= 400)
				{
					npcChatText = Lang.dialog(player, 220);
					return;
				}
				if (helpText == 1060 && NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && !Main.hardMode && player.statLifeMax >= 400)
				{
					npcChatText = Lang.dialog(player, 221);
					return;
				}
				if (helpText == 1061 && Main.hardMode)
				{
					npcChatText = Lang.dialog(player, 222);
					return;
				}
				if (helpText == 1062 && Main.hardMode)
				{
					break;
				}
				if (helpText > 1100)
				{
					helpText = 0;
				}
			}
			npcChatText = Lang.dialog(player, 223);
		}

		public void UpdateNpcChat()
		{
			focusText = null;
			focusText3 = null;
			int num = (mouseTextBrightness * 2 + 255) / 3;
			focusColor = new Color(num, (int)((double)num * 0.90909090909090906), num >> 1, num);
			int num2 = player.statLifeMax - player.statLife;
			if (player.sign >= 0)
			{
				focusText = Lang.inter[48];
			}
			else if (Main.npc[player.talkNPC].type == 20)
			{
				focusText = Lang.inter[28];
				focusText3 = Lang.inter[49];
			}
			else if (Main.npc[player.talkNPC].type == 107)
			{
				focusText = Lang.inter[28];
				focusText3 = Lang.inter[19];
			}
			else if (Main.npc[player.talkNPC].type == 17 || Main.npc[player.talkNPC].type == 19 || Main.npc[player.talkNPC].type == 38 || Main.npc[player.talkNPC].type == 54 || Main.npc[player.talkNPC].type == 108 || Main.npc[player.talkNPC].type == 124 || Main.npc[player.talkNPC].type == 142)
			{
				focusText = Lang.inter[28];
			}
			else if (Main.npc[player.talkNPC].type == 37)
			{
				if (!Main.gameTime.dayTime)
				{
					focusText = Lang.inter[50];
				}
			}
			else if (Main.npc[player.talkNPC].type == 22)
			{
				focusText = Lang.inter[51];
				if (!Main.IsTutorial())
				{
					focusText3 = Lang.inter[25];
				}
			}
			else if (Main.npc[player.talkNPC].type == 18)
			{
				focusText = Lang.inter[54];
				for (int i = 0; i < 10; i++)
				{
					if (player.buff[i].IsHealable())
					{
						num2 += 1000;
					}
				}
				if (num2 > 0)
				{
					string text = "";
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = (int)((double)num2 * 0.75);
					if (num7 < 1)
					{
						num7 = 1;
					}
					num2 = num7;
					if (num7 >= 1000000)
					{
						num3 = num7 / 1000000;
						num7 -= num3 * 1000000;
					}
					if (num7 >= 10000)
					{
						num4 = num7 / 10000;
						num7 -= num4 * 10000;
					}
					if (num7 >= 100)
					{
						num5 = num7 / 100;
						num7 -= num5 * 100;
					}
					if (num7 > 0)
					{
						num6 = num7;
					}
					if (num3 > 0)
					{
						text = num3 + Lang.inter[15];
					}
					if (num4 > 0)
					{
						text = text + num4 + Lang.inter[16];
					}
					if (num5 > 0)
					{
						text = text + num5 + Lang.inter[17];
					}
					if (num6 > 0)
					{
						text = text + num6 + Lang.inter[18];
					}
					float num8 = (float)(int)mouseTextBrightness * 0.003921569f;
					if (num3 > 0)
					{
						focusColor = new Color((byte)(220f * num8), (byte)(220f * num8), (byte)(198f * num8), mouseTextBrightness);
					}
					else if (num4 > 0)
					{
						focusColor = new Color((byte)(224f * num8), (byte)(201f * num8), (byte)(92f * num8), mouseTextBrightness);
					}
					else if (num5 > 0)
					{
						focusColor = new Color((byte)(181f * num8), (byte)(192f * num8), (byte)(193f * num8), mouseTextBrightness);
					}
					else if (num6 > 0)
					{
						focusColor = new Color((byte)(246f * num8), (byte)(138f * num8), (byte)(96f * num8), mouseTextBrightness);
					}
					focusText = focusText + " (" + text + ")";
				}
			}
			player.releaseUseItem = false;
			if (focusText == null && focusText3 == null)
			{
				npcChatSelectedItem = 1;
			}
			else if (IsLeftButtonTriggered())
			{
				Main.PlaySound(12);
				if (--npcChatSelectedItem < 0)
				{
					npcChatSelectedItem = (sbyte)((focusText3 == null) ? 1 : 2);
				}
			}
			else if (IsRightButtonTriggered())
			{
				Main.PlaySound(12);
				npcChatSelectedItem++;
				if (npcChatSelectedItem == 3 || (npcChatSelectedItem == 2 && focusText3 == null))
				{
					npcChatSelectedItem = 0;
				}
			}
			if (IsButtonTriggered(Buttons.B))
			{
				player.talkNPC = -1;
				player.sign = -1;
				editSign = false;
				npcChatText = null;
				Main.PlaySound(11);
				ClearButtonTriggers();
			}
			else
			{
				if (!IsButtonTriggered(Buttons.A))
				{
					return;
				}
				if (npcChatSelectedItem == 0)
				{
					if (player.sign != -1)
					{
						Main.PlaySound(12);
						editSign = true;
						ClearInput();
					}
					else if (Main.npc[player.talkNPC].type == 17)
					{
						npcChatText = null;
						npcShop = 1;
						Main.shop[npcShop].SetupShop(npcShop, player);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 19)
					{
						npcChatText = null;
						npcShop = 2;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 124)
					{
						npcChatText = null;
						npcShop = 8;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 142)
					{
						npcChatText = null;
						npcShop = 9;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 37)
					{
						if (Main.netMode != 1)
						{
							NPC.SpawnSkeletron();
						}
						else
						{
							NetMessage.CreateMessage0(62);
							NetMessage.SendMessage();
						}
						npcChatText = null;
					}
					else if (Main.npc[player.talkNPC].type == 20)
					{
						npcChatText = null;
						npcShop = 3;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 38)
					{
						npcChatText = null;
						npcShop = 4;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 54)
					{
						npcChatText = null;
						npcShop = 5;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 107)
					{
						npcChatText = null;
						npcShop = 6;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 108)
					{
						npcChatText = null;
						npcShop = 7;
						Main.shop[npcShop].SetupShop(npcShop);
						Main.PlaySound(12);
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 22)
					{
						Main.PlaySound(12);
						HelpText();
					}
					else if (Main.npc[player.talkNPC].type == 18)
					{
						Main.PlaySound(12);
						if (num2 > 0)
						{
							if (player.BuyItem(num2))
							{
								Main.PlaySound(2, -1, -1, 4);
								player.HealEffect(player.statLifeMax - player.statLife);
								if ((float)player.statLife < (float)player.statLifeMax * 0.25f)
								{
									npcChatText = Lang.dialog(player, 227);
								}
								else if ((float)player.statLife < (float)player.statLifeMax * 0.5f)
								{
									npcChatText = Lang.dialog(player, 228);
								}
								else if ((float)player.statLife < (float)player.statLifeMax * 0.75f)
								{
									npcChatText = Lang.dialog(player, 229);
								}
								else
								{
									npcChatText = Lang.dialog(player, 230);
								}
								player.statLife = player.statLifeMax;
								for (int j = 0; j < 10; j++)
								{
									if (player.buff[j].IsHealable())
									{
										j = player.DelBuff(j);
									}
								}
							}
							else
							{
								switch (Main.rand.Next(3))
								{
								case 0:
									npcChatText = Lang.dialog(player, 52);
									break;
								case 1:
									npcChatText = Lang.dialog(player, 53);
									break;
								default:
									npcChatText = Lang.dialog(player, 54);
									break;
								}
							}
						}
						else
						{
							switch (Main.rand.Next(3))
							{
							case 0:
								npcChatText = Lang.dialog(player, 55);
								break;
							case 1:
								npcChatText = Lang.dialog(player, 56);
								break;
							default:
								npcChatText = Lang.dialog(player, 57);
								break;
							}
						}
					}
				}
				else if (npcChatSelectedItem == 1)
				{
					player.talkNPC = -1;
					player.sign = -1;
					editSign = false;
					npcChatText = null;
					Main.PlaySound(11);
				}
				else if (player.talkNPC >= 0)
				{
					if (Main.npc[player.talkNPC].type == 20)
					{
						Main.PlaySound(12);
						npcChatText = Lang.evilGood();
					}
					else if (Main.npc[player.talkNPC].type == 22)
					{
						npcChatText = null;
						Main.PlaySound(12);
						craftGuide = true;
						guideItem.Init();
						OpenInventory();
					}
					else if (Main.npc[player.talkNPC].type == 107)
					{
						npcChatText = null;
						Main.PlaySound(12);
						reforge = true;
						OpenInventory();
					}
				}
				ClearButtonTriggers();
			}
		}

		private void DrawNpcChat()
		{
			string @string = npcChatText.GetString();
			if (@string != npcCompiledChatText)
			{
				npcCompiledChatText = @string;
				npcChatCompiledText = new CompiledText(@string, 470, styleFontSmallOutline);
			}
			int num = (mouseTextBrightness * 2 + 255) / 3;
			int num2 = DrawDialog(textColor: new Color(num, num, num, num), pos: new Vector2(view.viewWidth - chatBackTexture.Width >> 1, 100f), backColor: new Color(200, 200, 200, 200), ct: npcChatCompiledText);
			num = mouseTextBrightness;
			int num3 = 180 + (view.viewWidth - 800 >> 1);
			int num4 = 128 + num2;
			Vector2 pivot = default(Vector2);
			if (focusText != null)
			{
				pivot = MeasureString(fontSmallOutline, focusText);
				pivot.X *= 0.5f;
				pivot.Y *= 0.5f;
				DrawStringScaled(fontSmallOutline, focusText, new Vector2((float)num3 + pivot.X, (float)num4 + pivot.Y), focusColor, pivot, (npcChatSelectedItem == 0) ? 1.1f : 0.9f);
			}
			string text = Lang.inter[52];
			Color c = new Color(num, (int)((double)num * 0.90909090909090906), num >> 1, num);
			num3 = num3 + (int)(pivot.X * 2f) + 30;
			Vector2 pivot2 = MeasureString(fontSmallOutline, text);
			pivot2.X *= 0.5f;
			pivot2.Y *= 0.5f;
			DrawStringScaled(fontSmallOutline, text, new Vector2((float)num3 + pivot2.X, (float)num4 + pivot2.Y), c, pivot2, (npcChatSelectedItem == 1) ? 1.1f : 0.9f);
			if (focusText3 != null)
			{
				num3 = num3 + (int)(pivot2.X * 2f) + 30;
				Vector2 pivot3 = MeasureString(fontSmallOutline, focusText3);
				pivot3.X *= 0.5f;
				pivot3.Y *= 0.5f;
				DrawStringScaled(fontSmallOutline, focusText3, new Vector2((float)num3 + pivot3.X, (float)num4 + pivot3.Y), c, pivot3, (npcChatSelectedItem == 2) ? 1.1f : 0.9f);
			}
		}

		private void Reforge(int slot, bool isArmor = false)
		{
			if (toolTip.Prefix(-3) && player.BuyItem(toolTip.value))
			{
				int prefix = toolTip.prefix;
				toolTip.netDefaults(toolTip.netID);
				do
				{
					toolTip.Prefix(-2);
				}
				while (toolTip.prefix == prefix);
				toolTip.position.X = player.aabb.X + 10 - (toolTip.width >> 1);
				toolTip.position.Y = player.aabb.Y + 21 - (toolTip.height >> 1);
				if (isArmor)
				{
					player.armor[slot] = toolTip;
				}
				else
				{
					player.inventory[slot] = toolTip;
				}
				Main.PlaySound(2, player.aabb.X, player.aabb.Y, 37);
			}
		}

		private void CraftingGuide()
		{
			if (toolTip.type <= 0 || !toolTip.material)
			{
				return;
			}
			guideItem = toolTip;
			inventorySection = InventorySection.CRAFTING;
			craftingCategory = Recipe.Category.MISC;
			for (int i = 0; i < 6; i++)
			{
				NextCraftingCategory();
				if (currentRecipeCategory.Count > 0)
				{
					break;
				}
			}
		}

		private bool IsSlotAssignedToQuickAccess(int slot)
		{
			if (quickAccessUp != slot && quickAccessDown != slot && quickAccessLeft != slot)
			{
				return quickAccessRight == slot;
			}
			return true;
		}

		private void UpdateInventory()
		{
			if (inventoryItemX == 9 && inventoryItemY == 6)
			{
				if (!IsButtonTriggered(Buttons.A))
				{
					return;
				}
				if (mouseItem.type != 0)
				{
					trashItem.Init();
				}
				Item item = mouseItem;
				mouseItem = trashItem;
				trashItem = item;
				mouseItemSrcSection = InventorySection.ITEMS;
				mouseItemSrcX = inventoryItemX;
				mouseItemSrcY = inventoryItemY;
				if (trashItem.type == 0 || trashItem.stack < 1)
				{
					trashItem.Init();
				}
				if (mouseItem.netID == trashItem.netID && trashItem.stack != trashItem.maxStack && mouseItem.stack != mouseItem.maxStack)
				{
					if (mouseItem.stack + trashItem.stack <= mouseItem.maxStack)
					{
						trashItem.stack += mouseItem.stack;
						mouseItem.stack = 0;
					}
					else
					{
						short num = (short)(mouseItem.maxStack - trashItem.stack);
						trashItem.stack += num;
						mouseItem.stack -= num;
					}
				}
				if (mouseItem.type == 0 || mouseItem.stack < 1)
				{
					mouseItem.Init();
				}
				if (mouseItem.type > 0 || trashItem.type > 0)
				{
					Main.PlaySound(7);
				}
				return;
			}
			bool flag = true;
			int num2;
			switch (inventoryItemY)
			{
			case 4:
				num2 = 44 + inventoryItemX - 6;
				flag = mouseItem.CanBePlacedInAmmoSlot();
				break;
			case 5:
				num2 = 40 + inventoryItemX - 6;
				flag = mouseItem.CanBePlacedInCoinSlot();
				break;
			default:
				num2 = inventoryItemX + inventoryItemY * 10;
				break;
			}
			if (num2 < 40 && mouseItem.type == 0)
			{
				if (IsButtonTriggered(Buttons.DPadUp))
				{
					if (quickAccessUp == num2)
					{
						quickAccessUp = -1;
					}
					else
					{
						quickAccessUp = (sbyte)num2;
						if (quickAccessDown == num2)
						{
							quickAccessDown = -1;
						}
						else if (quickAccessLeft == num2)
						{
							quickAccessLeft = -1;
						}
						else if (quickAccessRight == num2)
						{
							quickAccessRight = -1;
						}
					}
					Main.PlaySound(7);
				}
				else if (IsButtonTriggered(Buttons.DPadDown))
				{
					if (quickAccessDown == num2)
					{
						quickAccessDown = -1;
					}
					else
					{
						quickAccessDown = (sbyte)num2;
						if (quickAccessUp == num2)
						{
							quickAccessUp = -1;
						}
						else if (quickAccessLeft == num2)
						{
							quickAccessLeft = -1;
						}
						else if (quickAccessRight == num2)
						{
							quickAccessRight = -1;
						}
					}
					Main.PlaySound(7);
				}
				else if (IsButtonTriggered(Buttons.DPadLeft))
				{
					if (quickAccessLeft == num2)
					{
						quickAccessLeft = -1;
					}
					else
					{
						quickAccessLeft = (sbyte)num2;
						if (quickAccessUp == num2)
						{
							quickAccessUp = -1;
						}
						else if (quickAccessDown == num2)
						{
							quickAccessDown = -1;
						}
						else if (quickAccessRight == num2)
						{
							quickAccessRight = -1;
						}
					}
					Main.PlaySound(7);
				}
				else if (IsButtonTriggered(Buttons.DPadRight))
				{
					if (quickAccessRight == num2)
					{
						quickAccessRight = -1;
					}
					else
					{
						quickAccessRight = (sbyte)num2;
						if (quickAccessUp == num2)
						{
							quickAccessUp = -1;
						}
						else if (quickAccessDown == num2)
						{
							quickAccessDown = -1;
						}
						else if (quickAccessLeft == num2)
						{
							quickAccessLeft = -1;
						}
					}
					Main.PlaySound(7);
				}
			}
			if (IsButtonTriggered(Buttons.A))
			{
				if (reforge)
				{
					Reforge(num2);
				}
				else if (craftGuide)
				{
					CraftingGuide();
				}
				else
				{
					if (mouseItem.type != 0 && (!flag || (player.selectedItem == num2 && player.itemAnimation > 0)))
					{
						return;
					}
					Item item2 = mouseItem;
					mouseItem = player.inventory[num2];
					player.inventory[num2] = item2;
					if (player.inventory[num2].type == 0 || player.inventory[num2].stack < 1)
					{
						player.inventory[num2].Init();
					}
					bool flag2 = false;
					if (mouseItem.netID == player.inventory[num2].netID && player.inventory[num2].stack != player.inventory[num2].maxStack && mouseItem.stack != mouseItem.maxStack)
					{
						if (mouseItem.stack + player.inventory[num2].stack <= mouseItem.maxStack)
						{
							player.inventory[num2].stack += mouseItem.stack;
							mouseItem.Init();
						}
						else
						{
							short num3 = (short)(mouseItem.maxStack - player.inventory[num2].stack);
							player.inventory[num2].stack += num3;
							mouseItem.stack -= num3;
							flag2 = true;
						}
					}
					if (mouseItem.type > 0 && item2.type > 0 && !flag2 && mouseItemSrcSection == InventorySection.ITEMS && mouseItemSrcX < 10 && mouseItemSrcY < 4)
					{
						int num4 = mouseItemSrcX + mouseItemSrcY * 10;
						if (player.inventory[num4].type == 0)
						{
							player.inventory[num4] = mouseItem;
							mouseItem.Init();
						}
						if (quickAccessUp == num4)
						{
							quickAccessUp = (sbyte)num2;
						}
						else if (quickAccessDown == num4)
						{
							quickAccessDown = (sbyte)num2;
						}
						else if (quickAccessLeft == num4)
						{
							quickAccessLeft = (sbyte)num2;
						}
						else if (quickAccessRight == num4)
						{
							quickAccessRight = (sbyte)num2;
						}
					}
					mouseItemSrcSection = InventorySection.ITEMS;
					mouseItemSrcX = inventoryItemX;
					mouseItemSrcY = inventoryItemY;
					if (mouseItem.type > 0 || player.inventory[num2].type > 0)
					{
						Main.PlaySound(7);
					}
				}
			}
			else if (gpState.IsButtonDown(Buttons.RightTrigger))
			{
				if (gpPrevState.IsButtonUp(Buttons.RightTrigger))
				{
					if (player.inventory[num2].type >= 599 && player.inventory[num2].type <= 601)
					{
						Main.PlaySound(7);
						stackSplit = 30;
						int num5 = Main.rand.Next(14);
						if (num5 == 0 && Main.hardMode)
						{
							player.inventory[num2].SetDefaults(602);
							return;
						}
						player.inventory[num2].SetDefaults((num5 <= 7) ? 586 : 591);
						player.inventory[num2].stack = (short)Main.rand.Next(20, 50);
					}
					else if (player.inventory[num2].isEquipable())
					{
						player.inventory[num2] = player.armorSwap(ref player.inventory[num2]);
					}
				}
				else if (stackSplit <= 1 && player.inventory[num2].maxStack > 1 && player.inventory[num2].type > 0 && (mouseItem.netID == player.inventory[num2].netID || mouseItem.type == 0) && (mouseItem.stack < mouseItem.maxStack || mouseItem.type == 0))
				{
					if (mouseItem.type == 0)
					{
						mouseItem = player.inventory[num2];
						mouseItem.stack = 0;
						mouseItemSrcSection = InventorySection.ITEMS;
						mouseItemSrcX = inventoryItemX;
						mouseItemSrcY = inventoryItemY;
					}
					mouseItem.stack++;
					player.inventory[num2].stack--;
					if (player.inventory[num2].stack <= 0)
					{
						player.inventory[num2].Init();
					}
					Main.PlaySound(12);
					if (stackSplit == 0)
					{
						stackSplit = 15;
					}
					else
					{
						stackSplit = stackDelay;
					}
				}
			}
			else
			{
				if (mouseItem.type != 0 || reforge || !IsButtonTriggered(Buttons.X) || player.inventory[num2].type <= 0)
				{
					return;
				}
				if (npcShop > 0 && !player.inventory[num2].CanBePlacedInCoinSlot())
				{
					if (player.SellItem(player.inventory[num2].value, player.inventory[num2].stack))
					{
						Main.shop[npcShop].AddShop(ref player.inventory[num2]);
						player.inventory[num2].Init();
						Main.PlaySound(18);
					}
					else if (player.inventory[num2].value == 0)
					{
						Main.shop[npcShop].AddShop(ref player.inventory[num2]);
						player.inventory[num2].Init();
						Main.PlaySound(7);
					}
				}
				else
				{
					Main.PlaySound(7);
					trashItem = player.inventory[num2];
					player.inventory[num2].Init();
				}
			}
		}

		private void DrawInventory(int itemsSectionX, int itemsSectionY)
		{
			Vector2 pos = default(Vector2);
			Color color = new Color(invAlpha, invAlpha, invAlpha, invAlpha);
			inventoryScale = 149f / 160f;
			DrawStringRC(fontSmall, Lang.inter[3], itemsSectionX + 469, itemsSectionY + 338, Color.White);
			int num = 469 + itemsSectionX;
			int num2 = 312 + itemsSectionY;
			if (inventoryItemX == 9 && inventoryItemY == 6)
			{
				DrawInventoryCursor(num, num2, inventoryScale);
				toolTip = trashItem;
			}
			else
			{
				SpriteSheet<_sheetSprites>.DrawTL(446, num, num2, color, inventoryScale);
			}
			if (trashItem.type == 0 || trashItem.stack == 0)
			{
				pos.X = (float)num + 26f * inventoryScale;
				pos.Y = (float)num2 + 26f * inventoryScale;
				SpriteSheet<_sheetSprites>.DrawScaled(1482, ref pos, new Color(100, 100, 100, 100), inventoryScale);
			}
			else
			{
				DrawInventoryItem(ref trashItem, num, num2, Color.White, StackType.INVENTORY);
			}
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int x = itemsSectionX + (int)((float)i * 52.1499977f);
					int y = itemsSectionY + (int)((float)j * 52.1499977f);
					int num3 = i + j * 10;
					if (inventoryItemX == i && inventoryItemY == j)
					{
						toolTip = player.inventory[num3];
						DrawInventoryCursor(x, y, inventoryScale);
					}
					else
					{
						Color c = color;
						int id;
						if (!IsSlotAssignedToQuickAccess(num3))
						{
							id = ((j == 0) ? 447 : 451);
						}
						else
						{
							id = 450;
							c = mouseTextColor;
						}
						SpriteSheet<_sheetSprites>.DrawTL(id, x, y, c, inventoryScale);
					}
					if (player.inventory[num3].type > 0 && player.inventory[num3].stack > 0)
					{
						StackType stackType;
						Color itemColor;
						if ((craftGuide && !player.inventory[num3].material) || (reforge && !player.inventory[num3].Prefix(-3)))
						{
							stackType = StackType.NONE;
							itemColor = DISABLED_COLOR;
						}
						else
						{
							stackType = StackType.INVENTORY;
							itemColor = new Color(255, 255, 255, 255);
						}
						DrawInventoryItem(ref player.inventory[num3], x, y, itemColor, stackType);
					}
				}
			}
			DrawStringRC(fontSmall, Lang.inter[26], itemsSectionX + 312, itemsSectionY + 286, Color.White);
			for (int k = 0; k < 4; k++)
			{
				int x2 = (int)((float)(6 + k) * 52.1499977f) + itemsSectionX;
				int y2 = 260 + itemsSectionY;
				int num4 = k + 40;
				if (inventoryItemY == 5 && inventoryItemX - 6 == k)
				{
					DrawInventoryCursor(x2, y2, inventoryScale);
					toolTip = player.inventory[num4];
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawTL(451, x2, y2, color, inventoryScale);
				}
				if (player.inventory[num4].type > 0 && player.inventory[num4].stack > 0)
				{
					DrawInventoryItem(ref player.inventory[num4], x2, y2, Color.White, StackType.INVENTORY);
				}
			}
			DrawStringRC(fontSmall, Lang.inter[27], itemsSectionX + 312, itemsSectionY + 234, Color.White);
			for (int l = 0; l < 4; l++)
			{
				int x3 = (int)((float)(6 + l) * 52.1499977f) + itemsSectionX;
				int y3 = 208 + itemsSectionY;
				int num5 = l + 44;
				if (inventorySection == InventorySection.ITEMS && inventoryItemY == 4 && inventoryItemX - 6 == l)
				{
					DrawInventoryCursor(x3, y3, inventoryScale);
					toolTip = player.inventory[num5];
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawTL(451, x3, y3, color, inventoryScale);
				}
				if (player.inventory[num5].type > 0 && player.inventory[num5].stack > 0)
				{
					StackType stackType2;
					Color itemColor2;
					if ((craftGuide && !player.inventory[num5].material) || reforge)
					{
						stackType2 = StackType.NONE;
						itemColor2 = DISABLED_COLOR;
					}
					else
					{
						stackType2 = StackType.INVENTORY;
						itemColor2 = new Color(255, 255, 255, 255);
					}
					DrawInventoryItem(ref player.inventory[num5], x3, y3, itemColor2, stackType2);
				}
			}
			DrawQuickAccess(-1, itemsSectionX + 26, itemsSectionY + 234, 255, StackType.INVENTORY);
			UpdateToolTipText(null);
			DrawToolTip(itemsSectionX + 864 - 322 - 8, itemsSectionY + 8, 344);
			DrawControlsInventory();
		}

		public int UpdateQuickAccess()
		{
			int result = -1;
			int num = quickAccessUp;
			if (num >= 0)
			{
				if (player.inventory[num].type == 0)
				{
					quickAccessUp = -1;
				}
				else if (gpState.DPad.Up == ButtonState.Pressed && gpPrevState.DPad.Up == ButtonState.Released)
				{
					result = num;
				}
			}
			num = quickAccessDown;
			if (num >= 0)
			{
				if (player.inventory[num].type == 0)
				{
					quickAccessDown = -1;
				}
				else if (gpState.DPad.Down == ButtonState.Pressed && gpPrevState.DPad.Down == ButtonState.Released)
				{
					result = num;
				}
			}
			num = quickAccessLeft;
			if (num >= 0)
			{
				if (player.inventory[num].type == 0)
				{
					quickAccessLeft = -1;
				}
				else if (gpState.DPad.Left == ButtonState.Pressed && gpPrevState.DPad.Left == ButtonState.Released)
				{
					result = num;
				}
			}
			num = quickAccessRight;
			if (num >= 0)
			{
				if (player.inventory[num].type == 0)
				{
					quickAccessRight = -1;
				}
				else if (gpState.DPad.Right == ButtonState.Pressed && gpPrevState.DPad.Right == ButtonState.Released)
				{
					result = num;
				}
			}
			return result;
		}

		private void DrawQuickAccess(int selectedItem, int x, int y, int alpha, StackType stackType)
		{
			Color color = new Color(alpha, alpha, alpha, alpha);
			Color color2 = new Color(0, 0, 0, alpha >> 1);
			alpha = alpha * mouseTextBrightness >> 8;
			Color c = new Color(alpha, alpha, alpha, alpha);
			SpriteSheet<_sheetSprites>.Draw(217, x, y, color);
			inventoryScale = 1f;
			int num = quickAccessUp;
			if (num >= 0)
			{
				if (selectedItem == num)
				{
					SpriteSheet<_sheetSprites>.Draw(448, x + 32 + 4, y - 4, color2);
					SpriteSheet<_sheetSprites>.Draw(448, x + 32, y - 4 - 4, c);
				}
				if (player.inventory[num].type > 0)
				{
					if (selectedItem != num)
					{
						DrawInventoryItem(ref player.inventory[num], x + 32 + 4, y - 4, color2, stackType);
					}
					DrawInventoryItem(ref player.inventory[num], x + 32, y - 4 - 4, color, stackType);
				}
			}
			num = quickAccessDown;
			if (num >= 0)
			{
				if (selectedItem == num)
				{
					SpriteSheet<_sheetSprites>.Draw(448, x + 32 + 4, y + 112 - 42 + 4, color2);
					SpriteSheet<_sheetSprites>.Draw(448, x + 32, y + 112 - 42, c);
				}
				if (player.inventory[num].type > 0)
				{
					if (selectedItem != num)
					{
						DrawInventoryItem(ref player.inventory[num], x + 32 + 4, y + 112 - 42 + 4, color2, stackType);
					}
					DrawInventoryItem(ref player.inventory[num], x + 32, y + 112 - 42, color, stackType);
				}
			}
			num = quickAccessLeft;
			if (num >= 0)
			{
				if (selectedItem == num)
				{
					SpriteSheet<_sheetSprites>.Draw(448, x - 4, y + 30 + 4, color2);
					SpriteSheet<_sheetSprites>.Draw(448, x - 4 - 4, y + 30, c);
				}
				if (player.inventory[num].type > 0)
				{
					if (selectedItem != num)
					{
						DrawInventoryItem(ref player.inventory[num], x - 4, y + 30 + 4, color2, stackType);
					}
					DrawInventoryItem(ref player.inventory[num], x - 4 - 4, y + 30, color, stackType);
				}
			}
			num = quickAccessRight;
			if (num < 0)
			{
				return;
			}
			if (selectedItem == num)
			{
				SpriteSheet<_sheetSprites>.Draw(448, x + 112 - 42 + 4, y + 30 + 4, color2);
				SpriteSheet<_sheetSprites>.Draw(448, x + 112 - 42, y + 30, c);
			}
			if (player.inventory[num].type > 0)
			{
				if (selectedItem != num)
				{
					DrawInventoryItem(ref player.inventory[num], x + 112 - 42 + 4, y + 30 + 4, color2, stackType);
				}
				DrawInventoryItem(ref player.inventory[num], x + 112 - 42, y + 30, color, stackType);
			}
		}

		private void UpdateStorage()
		{
			if (inventoryChestX < 0)
			{
				if (!IsButtonTriggered(Buttons.A))
				{
					return;
				}
				switch (inventoryChestY)
				{
				case 1:
					if (player.chest >= 0)
					{
						Main.chest[player.chest].LootAll(player);
					}
					else if (player.chest == -3)
					{
						player.safe.LootAll(player);
					}
					else
					{
						player.bank.LootAll(player);
					}
					break;
				case 2:
					if (player.chest >= 0)
					{
						Main.chest[player.chest].Deposit(player);
					}
					else if (player.chest == -3)
					{
						player.safe.Deposit(player);
					}
					else
					{
						player.bank.Deposit(player);
					}
					break;
				case 3:
					if (player.chest >= 0)
					{
						Main.chest[player.chest].QuickStack(player);
					}
					else if (player.chest == -3)
					{
						player.safe.QuickStack(player);
					}
					else
					{
						player.bank.QuickStack(player);
					}
					break;
				}
				return;
			}
			int chest = player.chest;
			Chest chest2;
			switch (chest)
			{
			case -2:
				chest2 = player.bank;
				break;
			case -3:
				chest2 = player.safe;
				break;
			default:
				chest2 = Main.chest[chest];
				break;
			}
			int num = inventoryChestX + inventoryChestY * 5;
			if (IsButtonTriggered(Buttons.A))
			{
				if (player.selectedItem == num && player.itemAnimation > 0)
				{
					return;
				}
				Item item = mouseItem;
				mouseItem = chest2.item[num];
				mouseItemSrcSection = InventorySection.CHEST;
				mouseItemSrcX = inventoryChestX;
				mouseItemSrcY = inventoryChestY;
				chest2.item[num] = item;
				if (chest2.item[num].type == 0 || chest2.item[num].stack < 1)
				{
					chest2.item[num].Init();
				}
				if (mouseItem.netID == chest2.item[num].netID && chest2.item[num].stack != chest2.item[num].maxStack && mouseItem.stack != mouseItem.maxStack)
				{
					if (mouseItem.stack + chest2.item[num].stack <= mouseItem.maxStack)
					{
						chest2.item[num].stack += mouseItem.stack;
						mouseItem.stack = 0;
					}
					else
					{
						short num2 = (short)(mouseItem.maxStack - chest2.item[num].stack);
						chest2.item[num].stack += num2;
						mouseItem.stack -= num2;
					}
				}
				if (mouseItem.type == 0 || mouseItem.stack < 1)
				{
					mouseItem.Init();
				}
				if (mouseItem.type > 0 || chest2.item[num].type > 0)
				{
					Main.PlaySound(7);
				}
				if (chest >= 0)
				{
					NetMessage.CreateMessage2(32, chest, num);
					NetMessage.SendMessage();
				}
			}
			else if (IsButtonTriggered(Buttons.RightTrigger) && chest2.item[num].isEquipable())
			{
				chest2.item[num] = player.armorSwap(ref chest2.item[num]);
				if (chest >= 0)
				{
					NetMessage.CreateMessage2(32, chest, num);
					NetMessage.SendMessage();
				}
			}
			else if (stackSplit <= 1 && gpState.IsButtonDown(Buttons.RightTrigger) && chest2.item[num].maxStack > 1 && (mouseItem.netID == chest2.item[num].netID || mouseItem.type == 0) && (mouseItem.stack < mouseItem.maxStack || mouseItem.type == 0))
			{
				if (mouseItem.type == 0)
				{
					mouseItem = chest2.item[num];
					mouseItem.stack = 0;
					mouseItemSrcSection = InventorySection.CHEST;
					mouseItemSrcX = inventoryChestX;
					mouseItemSrcY = inventoryChestY;
				}
				mouseItem.stack++;
				chest2.item[num].stack--;
				if (chest2.item[num].stack <= 0)
				{
					chest2.item[num].Init();
				}
				Main.PlaySound(12);
				if (stackSplit == 0)
				{
					stackSplit = 15;
				}
				else
				{
					stackSplit = stackDelay;
				}
				if (chest >= 0)
				{
					NetMessage.CreateMessage2(32, chest, num);
					NetMessage.SendMessage();
				}
			}
		}

		private void DrawStorage(int INVENTORY_X, int INVENTORY_Y)
		{
			int chest = player.chest;
			Chest chest2;
			switch (chest)
			{
			case -1:
				return;
			case -2:
				chest2 = player.bank;
				break;
			case -3:
				chest2 = player.safe;
				break;
			default:
				chest2 = Main.chest[chest];
				break;
			}
			Color c = new Color(invAlpha, invAlpha, invAlpha, invAlpha);
			inventoryScale = 1f;
			int x = 112 + INVENTORY_X + -56;
			int num = 56 + INVENTORY_Y + 56;
			int id = (inventoryChestX < 0 && inventoryChestY == 1) ? 448 : 451;
			SpriteSheet<_sheetSprites>.DrawTL(id, x, num, c, inventoryScale);
			id = 1085;
			DrawInventoryItem(id, x, num, Color.White);
			num += 56;
			id = ((inventoryChestX < 0 && inventoryChestY == 2) ? 448 : 451);
			SpriteSheet<_sheetSprites>.DrawTL(id, x, num, c, inventoryScale);
			id = 213;
			DrawInventoryItem(id, x, num, Color.White);
			num += 56;
			id = ((inventoryChestX < 0 && inventoryChestY == 3) ? 448 : 451);
			SpriteSheet<_sheetSprites>.DrawTL(id, x, num, c, inventoryScale);
			id = 1469;
			DrawInventoryItem(id, x, num, Color.White);
			if (inventoryChestX < 0)
			{
				toolTip.Init();
			}
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					x = 112 + INVENTORY_X + i * 56;
					num = 56 + INVENTORY_Y + j * 56;
					int num2 = i + j * 5;
					SpriteSheet<_sheetSprites>.DrawTL(444, x, num, c, inventoryScale);
					if (inventoryChestX == i && inventoryChestY == j)
					{
						DrawInventoryCursor(x, num, inventoryScale);
						toolTip = chest2.item[num2];
					}
					if (chest2.item[num2].type > 0 && chest2.item[num2].stack > 0)
					{
						Color white = Color.White;
						DrawInventoryItem(ref chest2.item[num2], x, num, white, StackType.INVENTORY);
					}
				}
			}
			UpdateToolTipText(null);
			DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
			DrawControlsInventory();
		}

		private void UpdateShop()
		{
			int num = inventoryChestX + inventoryChestY * 5;
			if (IsButtonTriggered(Buttons.A))
			{
				if (mouseItem.type == 0)
				{
					if ((player.selectedItem == num && player.itemAnimation > 0) || !player.BuyItem(Main.shop[npcShop].item[num].value))
					{
						return;
					}
					if (Main.shop[npcShop].item[num].buyOnce)
					{
						int prefix = Main.shop[npcShop].item[num].prefix;
						mouseItem.netDefaults(Main.shop[npcShop].item[num].netID);
						mouseItem.Prefix(prefix);
					}
					else
					{
						mouseItem.netDefaults(Main.shop[npcShop].item[num].netID);
						mouseItem.Prefix(-1);
					}
					mouseItem.position.X = player.position.X + 10f - (float)(mouseItem.width >> 1);
					mouseItem.position.Y = player.position.Y + 21f - (float)(mouseItem.height >> 1);
					if (Main.shop[npcShop].item[num].buyOnce)
					{
						Main.shop[npcShop].item[num].stack--;
						if (Main.shop[npcShop].item[num].stack <= 0)
						{
							Main.shop[npcShop].item[num].Init();
						}
					}
					Main.PlaySound(18);
				}
				else if (Main.shop[npcShop].item[num].type == 0)
				{
					if (player.SellItem(mouseItem.value, mouseItem.stack))
					{
						Main.shop[npcShop].AddShop(ref mouseItem);
						mouseItem.stack = 0;
						mouseItem.type = 0;
						Main.PlaySound(18);
					}
					else if (mouseItem.value == 0)
					{
						Main.shop[npcShop].AddShop(ref mouseItem);
						mouseItem.stack = 0;
						mouseItem.type = 0;
						Main.PlaySound(7);
					}
				}
			}
			else
			{
				if (stackSplit > 1 || !gpState.IsButtonDown(Buttons.RightTrigger) || (mouseItem.netID != Main.shop[npcShop].item[num].netID && mouseItem.type != 0) || (mouseItem.stack >= mouseItem.maxStack && mouseItem.type != 0) || !player.BuyItem(Main.shop[npcShop].item[num].value))
				{
					return;
				}
				Main.PlaySound(18);
				if (mouseItem.type == 0)
				{
					mouseItem.netDefaults(Main.shop[npcShop].item[num].netID);
					mouseItem.stack = 0;
				}
				mouseItem.stack++;
				if (stackSplit == 0)
				{
					stackSplit = 15;
				}
				else
				{
					stackSplit = stackDelay;
				}
				if (Main.shop[npcShop].item[num].buyOnce)
				{
					Main.shop[npcShop].item[num].stack--;
					if (Main.shop[npcShop].item[num].stack <= 0)
					{
						Main.shop[npcShop].item[num].Init();
					}
				}
			}
		}

		private void DrawShop(int INVENTORY_X, int INVENTORY_Y)
		{
			Color c = new Color(invAlpha, invAlpha, invAlpha, invAlpha);
			inventoryScale = 1f;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int x = 112 + INVENTORY_X + i * 56;
					int y = 56 + INVENTORY_Y + j * 56;
					int num = i + j * 5;
					SpriteSheet<_sheetSprites>.DrawTL(445, x, y, c, inventoryScale);
					if (inventorySection == InventorySection.CHEST && inventoryChestX == i && inventoryChestY == j)
					{
						DrawInventoryCursor(x, y, inventoryScale);
						toolTip = Main.shop[npcShop].item[num];
						toolTip.buy = true;
					}
					if (Main.shop[npcShop].item[num].type > 0 && Main.shop[npcShop].item[num].stack > 0)
					{
						Color white = Color.White;
						DrawInventoryItem(ref Main.shop[npcShop].item[num], x, y, white, StackType.INVENTORY);
					}
				}
			}
			UpdateToolTipText(null);
			DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
			DrawControlsShop();
		}

		private void UpdateEquip()
		{
			if (inventoryEquipY == 0)
			{
				if (IsButtonTriggered(Buttons.A))
				{
					int num = inventoryEquipX + inventoryBuffX;
					if (player.buff[num].Time > 0 && !player.buff[num].IsDebuff())
					{
						player.DelBuff(num);
						Main.PlaySound(12);
					}
				}
				return;
			}
			int num2 = (inventoryEquipY == 4) ? (3 + inventoryEquipX) : ((inventoryEquipX != 0) ? (inventoryEquipY + 7) : (inventoryEquipY - 1));
			if (IsButtonTriggered(Buttons.A))
			{
				if (reforge)
				{
					Reforge(num2, isArmor: true);
				}
				else if (craftGuide)
				{
					CraftingGuide();
				}
				else if (mouseItem.type == 0 || (mouseItem.headSlot >= 0 && (num2 == 0 || num2 == 8)) || (mouseItem.bodySlot >= 0 && (num2 == 1 || num2 == 9)) || (mouseItem.legSlot >= 0 && (num2 == 2 || num2 == 10)) || (mouseItem.accessory && num2 > 2 && !AccCheck(ref mouseItem, num2)))
				{
					Item item = mouseItem;
					mouseItem = player.armor[num2];
					player.armor[num2] = item;
					mouseItemSrcSection = InventorySection.EQUIP;
					mouseItemSrcX = inventoryEquipX;
					mouseItemSrcY = inventoryEquipY;
					if (player.armor[num2].type == 0 || player.armor[num2].stack < 1)
					{
						player.armor[num2].Init();
					}
					if (mouseItem.type > 0 || player.armor[num2].type > 0)
					{
						Main.PlaySound(7);
					}
				}
			}
			else if (IsButtonTriggered(Buttons.RightTrigger) && player.armor[num2].isEquipable() && !reforge)
			{
				player.armor[num2] = player.armorSwap(ref player.armor[num2]);
			}
		}

		private void DrawEquip(int INVENTORY_X, int INVENTORY_Y)
		{
			Color c = new Color(invAlpha, invAlpha, invAlpha, invAlpha);
			Color c2 = new Color(invAlpha >> 1, invAlpha, invAlpha >> 1, invAlpha);
			inventoryScale = 1f;
			int num = INVENTORY_X + 112;
			int y = INVENTORY_Y;
			Rectangle rect = default(Rectangle);
			rect.Y = y;
			rect.Width = 16;
			rect.Height = 56;
			if (inventoryBuffX > 0)
			{
				rect.X = num - 16;
				SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect, SpriteEffects.FlipHorizontally);
			}
			if (inventoryBuffX < 5)
			{
				rect.X = num + 280;
				SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect);
			}
			string extraInfo = null;
			for (int i = 0; i < 5; i++)
			{
				int num2 = player.buff[inventoryBuffX + i].Type;
				if (inventoryEquipY == 0 && inventoryEquipX == i)
				{
					DrawInventoryCursor(num, y, inventoryScale);
					toolTip.Init();
					extraInfo = ((!Buff.IsDebuff(num2)) ? "<f c='#C0FFC0'>" : "<f c='#FFC0C0'>");
					if (num2 == 40)
					{
						num2 += player.pet;
					}
					extraInfo += Buff.buffName[num2];
					extraInfo += "</f>\n";
					extraInfo += Buff.buffTip[num2];
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawTL(442, num, y, c2, inventoryScale);
				}
				if (num2 > 0)
				{
					int num3 = 141 + num2;
					if (num2 == 40)
					{
						num3 += player.pet;
					}
					DrawInventoryItem(num3, num, y, Color.White);
				}
				num += 56;
			}
			num = INVENTORY_X + 112;
			y = INVENTORY_Y + 88;
			for (int j = 0; j < 3; j++)
			{
				if (inventoryEquipX == 0 && inventoryEquipY == j + 1)
				{
					DrawInventoryCursor(num, y, inventoryScale);
					toolTip = player.armor[j];
					toolTip.wornArmor = true;
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawTL(442, num, y, c, inventoryScale);
				}
				if (player.armor[j].type > 0 && player.armor[j].stack > 0)
				{
					DrawInventoryItem(itemColor: ((craftGuide && !player.armor[j].material) || (reforge && !player.armor[j].Prefix(-3))) ? DISABLED_COLOR : new Color(255, 255, 255, 255), item: ref player.armor[j], x: num, y: y);
				}
				y += 56;
			}
			y += 32;
			for (int k = 3; k < 8; k++)
			{
				if (inventoryEquipY == 4 && inventoryEquipX == k - 3)
				{
					DrawInventoryCursor(num, y, inventoryScale);
					toolTip = player.armor[k];
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawTL(442, num, y, c, inventoryScale);
				}
				if (player.armor[k].type > 0 && player.armor[k].stack > 0)
				{
					DrawInventoryItem(itemColor: ((craftGuide && !player.armor[k].material) || (reforge && !player.armor[k].Prefix(-3))) ? DISABLED_COLOR : new Color(255, 255, 255, 255), item: ref player.armor[k], x: num, y: y);
				}
				num += 56;
			}
			num -= 56;
			y = INVENTORY_Y + 88;
			for (int l = 8; l < 11; l++)
			{
				if (inventoryEquipX == 4 && inventoryEquipY == l - 7)
				{
					DrawInventoryCursor(num, y, inventoryScale);
					toolTip = player.armor[l];
					toolTip.social = true;
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawTL(442, num, y, c, inventoryScale);
				}
				if (player.armor[l].type > 0 && player.armor[l].stack > 0)
				{
					DrawInventoryItem(itemColor: ((craftGuide && !player.armor[l].material) || (reforge && !player.armor[l].Prefix(-3))) ? DISABLED_COLOR : new Color(255, 255, 255, 255), item: ref player.armor[l], x: num, y: y);
				}
				y += 56;
			}
			DrawPlayer(player, new Vector2(INVENTORY_X + 112 + 112, INVENTORY_Y + 88), 3.75f);
			DrawStringCT(fontSmall, Lang.inter[6], INVENTORY_X + 112 + 140, INVENTORY_Y + 56 - 12, Color.White);
			DrawStringCT(fontSmall, Lang.inter[45], INVENTORY_X + 112 + 28, y - 12, Color.White);
			DrawStringCT(fontSmall, Lang.inter[11], num + 28, y - 12, Color.White);
			DrawStringCT(fontSmallOutline, ((int)player.statDefense).ToStringLookup() + Lang.inter[10], INVENTORY_X + 112 + 140, y - 6, new Color(100, 255, 200, 255));
			UpdateToolTipText(extraInfo);
			DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
			DrawControlsInventory();
		}

		private void UpdateHousing()
		{
			int x = player.aabb.X >> 4;
			int y = player.aabb.Y >> 4;
			if (IsButtonTriggered(Buttons.X))
			{
				Main.PlaySound(12);
				if (WorldGen.MoveNPC(x, y, -1))
				{
					Main.NewText(Lang.inter[39], 255, 240, 20);
				}
			}
			else if (IsButtonTriggered(Buttons.Y))
			{
				Main.PlaySound(12);
				showNPCs = !showNPCs;
			}
			else if (IsButtonTriggered(Buttons.A) && inventoryHousingNpc >= 0)
			{
				Main.PlaySound(12);
				if (WorldGen.MoveNPC(x, y, inventoryHousingNpc))
				{
					WorldGen.moveRoom(x, y, inventoryHousingNpc);
					Main.PlaySound(12);
				}
			}
		}

		private void DrawHousing(int INVENTORY_X, int INVENTORY_Y)
		{
			Color c = new Color(invAlpha, invAlpha, invAlpha, invAlpha);
			inventoryScale = 1f;
			string extraInfo = null;
			int num = INVENTORY_X;
			int num2 = INVENTORY_Y;
			for (int i = 0; i < 11; i++)
			{
				if (i == 6)
				{
					num += 240;
					num2 = INVENTORY_Y;
				}
				string text = null;
				NPC nPC = null;
				int num3 = -1;
				for (int j = 0; j < 196; j++)
				{
					nPC = Main.npc[j];
					if (nPC.active != 0 && i + 1 == nPC.getHeadTextureId())
					{
						num3 = j;
						text = ((!nPC.hasName()) ? nPC.displayName : nPC.getName());
						break;
					}
				}
				if (inventoryHousingX == i / 6 && inventoryHousingY == i % 6)
				{
					DrawInventoryCursor(num, num2, inventoryScale);
					inventoryHousingNpc = (short)num3;
					if (text != null)
					{
						extraInfo = text;
						if (i != 10 && Lang.lang <= 1)
						{
							extraInfo = extraInfo + " the " + nPC.name;
						}
						extraInfo += '\n';
						extraInfo += Lang.inter[55 + i];
					}
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawTL(449, num, num2, c, inventoryScale);
				}
				if (num3 >= 0)
				{
					int itemTexId = i + 1256;
					DrawInventoryItem(itemTexId, num, num2, Color.White);
					if (!nPC.homeless)
					{
						SpriteSheet<_sheetSprites>.DrawTL(437, num + 60 - 16, num2 - 8, Color.White, inventoryScale);
					}
					DrawStringLC(fontSmallOutline, text, num + 60, num2 + 30, Color.White);
				}
				num2 += 60;
			}
			UpdateToolTipText(extraInfo);
			DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
			DrawControlsHousing();
		}

		private void DrawMouseItem()
		{
			if (mouseItem.stack <= 0)
			{
				mouseItem.Init();
			}
			else if (mouseItem.type > 0 && mouseItem.stack > 0)
			{
				inventoryScale = cursorScale;
				DrawInventoryItem(ref mouseItem, mouseX + 6, mouseY + 6, new Color(0, 0, 0, 128), StackType.INVENTORY);
				DrawInventoryItem(ref mouseItem, mouseX, mouseY, Color.White, StackType.INVENTORY);
			}
		}

		private void DrawInventoryMenu()
		{
			int num = view.SAFE_AREA_OFFSET_L;
			int sAFE_AREA_OFFSET_T = view.SAFE_AREA_OFFSET_T;
			if (view.viewWidth > 960)
			{
				num = view.viewWidth - 864 >> 1;
			}
			bool flag = player.chest != -1;
			bool flag2 = npcShop > 0;
			bool flag3 = flag || flag2;
			int texId;
			switch (inventorySection)
			{
			case InventorySection.CRAFTING:
				texId = 441;
				break;
			case InventorySection.EQUIP:
				texId = 442;
				break;
			case InventorySection.CHEST:
				texId = (flag2 ? 445 : 444);
				break;
			case InventorySection.HOUSING:
				texId = 449;
				break;
			default:
				texId = 451;
				break;
			}
			Main.DrawRect(texId, new Rectangle(num, sAFE_AREA_OFFSET_T, 864, 446), 96);
			Color c = default(Color);
			int num2 = num + (864 - ((flag3 ? 4 : 3) * 43 + 56)) / 2;
			for (int i = 0; i < 5; i++)
			{
				switch ((byte)i)
				{
				case 1:
					texId = 440;
					break;
				case 0:
					texId = 205;
					break;
				case 3:
					texId = 219;
					break;
				case 2:
					if (flag2)
					{
						texId = Chest.GetShopOwnerHeadTextureId(npcShop);
						break;
					}
					if (!flag)
					{
						continue;
					}
					switch (player.chest)
					{
					case -2:
						texId = 538;
						break;
					case -3:
						texId = 797;
						break;
					default:
						texId = 499;
						break;
					}
					break;
				default:
					texId = 437;
					break;
				}
				int num3 = (int)inventorySection;
				float num4 = inventoryMenuSectionScale[i];
				if (i == num3)
				{
					if (num4 < 1f)
					{
						num4 += 0.05f;
						inventoryMenuSectionScale[i] = num4;
					}
				}
				else if (num4 > 0.75f)
				{
					num4 -= 0.05f;
					inventoryMenuSectionScale[i] = num4;
				}
				int y = (int)((float)sAFE_AREA_OFFSET_T + 22f * (1f - num4));
				int num5 = (int)(65f + 180f * num4);
				if (i == num3)
				{
					c.R = 200;
					c.G = 200;
					c.B = 200;
					c.A = 200;
					SpriteSheet<_sheetSprites>.DrawTL(448, num2, y, c, num4);
				}
				else
				{
					c.R = 100;
					c.G = 100;
					c.B = 100;
					c.A = 100;
					SpriteSheet<_sheetSprites>.DrawTL(451, num2, y, c, num4);
				}
				inventoryScale = num4;
				Color itemColor = (!IsInventorySectionAvailable((InventorySection)i)) ? DISABLED_COLOR : new Color(num5, num5, num5, num5);
				DrawInventoryItem(texId, num2, y, itemColor);
				num2 += (int)(52f * num4) + 4;
			}
			string text;
			switch (inventorySection)
			{
			case InventorySection.CRAFTING:
				text = Lang.inter[25];
				break;
			case InventorySection.ITEMS:
				text = Lang.inter[4];
				break;
			case InventorySection.CHEST:
				if (flag2)
				{
					text = Lang.inter[28];
					break;
				}
				_ = player.chest;
				switch (player.chest)
				{
				case -2:
					text = Lang.inter[32];
					break;
				case -3:
					text = Lang.inter[33];
					break;
				default:
					text = chestText;
					break;
				}
				break;
			case InventorySection.EQUIP:
				text = Lang.inter[45];
				break;
			default:
				text = Lang.inter[7];
				break;
			}
			if (reforge)
			{
				text += " (";
				text += Lang.inter[19];
				text += ')';
			}
			DrawStringCT(fontSmall, text, num + 432, sAFE_AREA_OFFSET_T + 44, Color.White);
			switch (inventorySection)
			{
			case InventorySection.ITEMS:
				DrawInventory(num, sAFE_AREA_OFFSET_T + 80);
				break;
			case InventorySection.CHEST:
				if (flag2)
				{
					DrawShop(num, sAFE_AREA_OFFSET_T + 80);
				}
				else
				{
					DrawStorage(num, sAFE_AREA_OFFSET_T + 80);
				}
				break;
			case InventorySection.CRAFTING:
				DrawCrafting(num, sAFE_AREA_OFFSET_T + 80);
				break;
			case InventorySection.EQUIP:
				DrawEquip(num, sAFE_AREA_OFFSET_T + 80);
				break;
			case InventorySection.HOUSING:
				DrawHousing(num, sAFE_AREA_OFFSET_T + 80);
				break;
			}
			DrawMouseItem();
		}

		private void DrawCrafting(int CRAFTING_X, int CRAFTING_Y)
		{
			Color color = default(Color);
			Color color2 = new Color(invAlpha, invAlpha, invAlpha, invAlpha);
			string text = null;
			Main.DrawRectOpenAtTop(441, new Rectangle(CRAFTING_X, CRAFTING_Y + 48, 864, 318), 192);
			int num = CRAFTING_X + 3;
			for (int i = 0; i < 6; i++)
			{
				Rectangle rect = new Rectangle(num, CRAFTING_Y + 8, 127, 32);
				if ((int)craftingCategory != i)
				{
					Main.DrawRectStraightBottom(441, rect, 192, 2);
				}
				else
				{
					Main.DrawRectOpenAtBottom(441, rect, 192);
				}
				SpriteSheet<_sheetSprites>.DrawCentered(206 + i, ref rect);
				num += 146;
			}
			int num2 = CRAFTING_X + 4 + 16;
			int num3 = CRAFTING_Y + 12 + 48;
			int count = currentRecipeCategory.Count;
			if (count > 0)
			{
				inventoryScale = 1f;
				int num4 = craftingRecipeY - Math.Sign(craftingRecipeScrollY);
				int num5 = Math.Min(8, currentRecipeCategory[craftingRecipeY].recipes.Count) * 56;
				int width = (craftingRecipeScrollX == 0f) ? 448 : num5;
				int num6 = Math.Min(5, count) * 56;
				Rectangle scissorRectangle = default(Rectangle);
				for (int j = 0; j < 2; j++)
				{
					Main.spriteBatch.End();
					scissorRectangle.X = num2;
					scissorRectangle.Y = num3;
					if (j == 0)
					{
						scissorRectangle.Width = 56;
						scissorRectangle.Height = num6;
					}
					else
					{
						scissorRectangle.Y += 56;
						scissorRectangle.Width = width;
						scissorRectangle.Height = 56;
					}
					if (!view.isFullScreen())
					{
						scissorRectangle.X >>= 1;
						scissorRectangle.X += view.activeViewport.X;
						scissorRectangle.Y >>= 1;
						scissorRectangle.Y += view.activeViewport.Y;
						scissorRectangle.Width >>= 1;
						scissorRectangle.Height >>= 1;
					}
					WorldView.graphicsDevice.ScissorRectangle = scissorRectangle;
					Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, WorldView.scissorTest, view.screenProjection);
					int num7 = num3;
					int num8 = 1;
					if (craftingRecipeScrollY != 0f)
					{
						num8 = 2;
						num7 -= 56;
						num7 -= (int)((1f - Math.Abs(craftingRecipeScrollY)) * 56f) * Math.Sign(craftingRecipeScrollY);
						if (j == 1)
						{
							craftingRecipeScrollY *= craftingRecipeScrollMul;
							if (Math.Abs(craftingRecipeScrollY) < 0.0178571437f)
							{
								craftingRecipeScrollY = 0f;
							}
						}
					}
					for (int k = -num8; k < 5 + num8; k++)
					{
						int num9 = num4 + k;
						if (num9 >= 0)
						{
							if (num9 >= count)
							{
								int num10 = num7 - num3;
								if (num10 < num6)
								{
									num6 = num10;
								}
								break;
							}
							int num11 = 0;
							int num12 = num2;
							if (craftingRecipeScrollX != 0f && num9 == craftingRecipeY)
							{
								num11 = 1;
								num12 -= 56;
								if (j == 0)
								{
									craftingRecipeScrollX *= craftingRecipeScrollMul;
									if (Math.Abs(craftingRecipeScrollX) < 0.0178571437f)
									{
										craftingRecipeScrollX = 0f;
									}
								}
								num12 -= (int)((1f - Math.Abs(craftingRecipeScrollX)) * 56f) * Math.Sign(craftingRecipeScrollX);
							}
							Recipe.SubCategoryList subCategoryList = currentRecipeCategory[num9];
							int num13 = (num9 == craftingRecipeY) ? (craftingRecipeX - Math.Sign(craftingRecipeScrollX)) : 0;
							int count2 = subCategoryList.recipes.Count;
							for (int l = -num11; l < 8 + num11; l++)
							{
								int num14 = num13 + l;
								if (num14 < 0)
								{
									num14 += count2;
								}
								if (num11 == 0 && l >= count2)
								{
									break;
								}
								num14 %= subCategoryList.recipes.Count;
								int num15 = subCategoryList.recipes[num14];
								Recipe recipe = Main.recipe[num15];
								bool flag = player.CanCraftRecipe(recipe);
								bool flag2 = num9 == craftingRecipeY && num14 == craftingRecipeX;
								if (flag2)
								{
									craftingRecipe = recipe;
									DrawInventoryCursor(num12, num7, inventoryScale, (craftingSection == CraftingSection.RECIPES) ? 255 : 96);
									if (j == 0)
									{
										toolTip = recipe.createItem;
										text = "(";
										text += player.CountPossession(toolTip.netID).ToStringLookup();
										text += Lang.menu[1];
										UpdateToolTipText(text);
									}
								}
								else
								{
									int id = (j == 0) ? 443 : 450;
									color = color2;
									if (!flag)
									{
										color.R >>= 1;
										color.G >>= 1;
										color.B >>= 1;
										color.A >>= 1;
									}
									SpriteSheet<_sheetSprites>.DrawTL(id, num12, num7, color, inventoryScale);
								}
								color = (flag ? new Color(255, 255, 255, 255) : new Color(16, 16, 16, 128));
								DrawInventoryItem(ref recipe.createItem, num12, num7, color, StackType.INVENTORY);
								if (player.recipesNew.Get(num15))
								{
									if (flag2)
									{
										player.recipesNew.Set(num15, value: false);
									}
									else
									{
										color = new Color(cursorAlpha, cursorAlpha, cursorAlpha, cursorAlpha);
										SpriteSheet<_sheetTiles>.Draw(23, num12 + 56 - 16, num7 + 12, color, (float)((double)Main.frameCounter * (1.0 / (8.0 * Math.PI))), (float)(0.8 + Math.Sin((double)Main.frameCounter * (1.0 / (16.0 * Math.PI))) * 0.2));
										SpriteSheet<_sheetTiles>.Draw(23, num12 + 28, num7 + 28, color, (float)((double)Main.frameCounter * (1.0 / (6.0 * Math.PI))), (float)(0.6 + Math.Sin((double)Main.frameCounter * (1.0 / (24.0 * Math.PI))) * 0.4));
										SpriteSheet<_sheetTiles>.Draw(23, num12 + 28 - 12, num7 + 28 - 8, color, (float)((double)Main.frameCounter * 0.079577471545947673), (float)(0.7 + Math.Sin((double)Main.frameCounter * (1.0 / (32.0 * Math.PI))) * 0.3));
									}
								}
								num12 += 56;
							}
						}
						num7 += 56;
					}
				}
				Main.spriteBatch.End();
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, view.screenProjection);
				if (craftingRecipeScrollX == 0f && craftingRecipeScrollY == 0f)
				{
					Rectangle rect2 = default(Rectangle);
					if (num5 > 56)
					{
						rect2.X = num2 - 16;
						rect2.Y = num3 + 56;
						rect2.Width = 16;
						rect2.Height = 56;
						SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect2, SpriteEffects.FlipHorizontally);
						rect2.X += 10 + num5;
						SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect2);
					}
					if (count > 1)
					{
						if (craftingRecipeY == 0)
						{
							num3 += 56;
							num6 -= 56;
						}
						rect2.X = num2;
						rect2.Y = num3 - 16;
						rect2.Width = 56;
						rect2.Height = 16;
						SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect2, SpriteEffects.FlipVertically);
						rect2.Y += num6 + 10;
						SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect2);
						if (craftingRecipeY == 0)
						{
							num3 -= 56;
							num6 += 56;
						}
					}
				}
				int num16 = num2 + 56 + 8;
				int num17 = num3 + 112 + 8;
				Main.DrawRect(441, new Rectangle(num16, num17, CRAFTING_X + 864 - 322 - 32 - num16, 174), 96);
				fontSmall.MeasureString(Lang.menu[0]);
				DrawStringCT(fontSmall, Lang.menu[0], num16 + 100, num17 + 150 - 6, Color.White);
				inventoryScale = 0.9f;
				int num18 = 0;
				for (int m = 0; m < 3; m++)
				{
					int num19 = 0;
					while (num19 < 4)
					{
						int num12 = num16 + 50 * num19;
						int num7 = num17 + 50 * m;
						if (craftingSection == CraftingSection.INGREDIENTS && num19 == craftingIngredientX && m == craftingIngredientY)
						{
							DrawInventoryCursor(num12, num7, inventoryScale);
							if (num18 < craftingRecipe.numRequiredItems)
							{
								toolTip = craftingRecipe.requiredItem[num18];
								text = "(";
								text += player.CountPossession(toolTip.netID).ToStringLookup();
								text += Lang.menu[1];
								UpdateToolTipText(text);
							}
						}
						else
						{
							int id2 = 442;
							color = ((num18 < craftingRecipe.numRequiredItems) ? color2 : new Color(64, 64, 64, 64));
							SpriteSheet<_sheetSprites>.DrawTL(id2, num12, num7, color, inventoryScale);
						}
						if (num18 < craftingRecipe.numRequiredItems)
						{
							DrawInventoryItem(ref craftingRecipe.requiredItem[num18], num12, num7, new Color(255, 255, 255, 255), StackType.INGREDIENT);
						}
						num19++;
						num18++;
					}
				}
				int num20 = -1;
				Main.strBuilder.Length = 0;
				if (craftingRecipe.numRequiredTiles > 0)
				{
					Main.strBuilder.Append(Main.tileName[craftingRecipe.requiredTile[0]]);
					switch (craftingRecipe.requiredTile[0])
					{
					case 13:
						num20 = 1;
						break;
					case 14:
						num20 = 1480;
						Main.strBuilder.Append(" & ");
						Main.strBuilder.Append(Main.tileName[15]);
						break;
					case 16:
						num20 = 486;
						break;
					case 17:
						num20 = 484;
						break;
					case 18:
						if (craftingRecipe.requiredTile[1] == 15)
						{
							num20 = 1487;
							Main.strBuilder.Append(" & ");
							Main.strBuilder.Append(Main.tileName[15]);
						}
						else
						{
							num20 = 487;
						}
						break;
					case 26:
						num20 = 212;
						break;
					case 86:
						num20 = 783;
						break;
					case 94:
						num20 = 803;
						break;
					case 96:
						num20 = 796;
						break;
					case 101:
						num20 = 139;
						break;
					case 106:
						num20 = 814;
						break;
					case 114:
						num20 = 849;
						break;
					case 134:
						num20 = 976;
						break;
					}
				}
				else if (craftingRecipe.needWater)
				{
					num20 = 1484;
					Main.strBuilder.Append(Lang.inter[53]);
				}
				if (num20 >= 0)
				{
					Rectangle rect3 = default(Rectangle);
					rect3.X = num16 + 200 + 80;
					rect3.Y = num17 + 18 + 28;
					rect3.Width = 68;
					rect3.Height = 68;
					Main.DrawRect(442, rect3, 192);
					int width2 = SpriteSheet<_sheetSprites>.src[num20].Width;
					int height = SpriteSheet<_sheetSprites>.src[num20].Height;
					float scaleCenter = (width2 <= height) ? (64f / (float)height) : (64f / (float)width2);
					Vector2 pos = default(Vector2);
					pos.X = rect3.Center.X;
					pos.Y = rect3.Center.Y;
					SpriteSheet<_sheetSprites>.DrawScaled(num20, ref pos, Color.White, scaleCenter);
					DrawStringCT(fontSmall, rect3.Center.X, rect3.Bottom + 2, player.IsNearCraftingStation(craftingRecipe) ? Color.White : new Color(255, 64, 64, 255));
				}
				if (text != null)
				{
					DrawToolTip(CRAFTING_X + 864 - 322 - 8, num3 + 8, 286);
				}
			}
			DrawControlsCrafting();
		}

		private void DrawMiniMap()
		{
			int sAFE_AREA_OFFSET_L = view.SAFE_AREA_OFFSET_L;
			int sAFE_AREA_OFFSET_T = view.SAFE_AREA_OFFSET_T;
			int width = view.viewWidth - view.SAFE_AREA_OFFSET_L - view.SAFE_AREA_OFFSET_R;
			int height = 540 - view.SAFE_AREA_OFFSET_T - view.SAFE_AREA_OFFSET_B - 36;
			Main.DrawRect(451, new Rectangle(sAFE_AREA_OFFSET_L, sAFE_AREA_OFFSET_T, width, height), 128);
			int num = 31 + sAFE_AREA_OFFSET_L;
			int num2 = 2 + sAFE_AREA_OFFSET_T;
			if (mapScreenCursorX == 0 && mapScreenCursorY < 2)
			{
				DrawInventoryCursor(num, num2, 1.0);
			}
			else
			{
				SpriteSheet<_sheetSprites>.Draw(451, num, num2);
			}
			Color white = Color.White;
			if (pvpSelected)
			{
				SpriteSheet<_sheetSprites>.Draw(455, num + 9, num2 + 11, white);
				SpriteSheet<_sheetSprites>.Draw(455, num + 11, num2 + 11, white, SpriteEffects.FlipHorizontally);
			}
			else
			{
				SpriteSheet<_sheetSprites>.DrawRotatedTL(455, num - 7, num2 + 25, white, -0.785f);
				SpriteSheet<_sheetSprites>.DrawRotatedTL(455, num + 11, num2 + 25, white, -0.785f);
			}
			int num3 = num + 123;
			for (int i = 0; i < 5; i++)
			{
				white = Main.teamColor[i];
				if (i == teamSelected)
				{
					white.A = mouseTextBrightness;
				}
				else
				{
					white.R >>= 1;
					white.G >>= 1;
					white.B >>= 1;
					white.A >>= 1;
				}
				int num4 = num3;
				int num5 = num2 + 3;
				switch (i)
				{
				case 0:
					num4 -= 32;
					num5 += 16;
					break;
				case 2:
					num4 += 32;
					break;
				case 3:
					num5 += 32;
					break;
				default:
					num4 += 32;
					num5 += 32;
					break;
				case 1:
					break;
				}
				num4 -= 8;
				num5 -= 8;
				if ((i == 0 && mapScreenCursorX == 1) || (i == 1 && mapScreenCursorX == 2 && mapScreenCursorY == 0) || (i == 2 && mapScreenCursorX == 3 && mapScreenCursorY == 0) || (i == 3 && mapScreenCursorX == 2 && mapScreenCursorY == 1) || (i == 4 && mapScreenCursorX == 3 && mapScreenCursorY == 1))
				{
					DrawInventoryCursor(num4, num5, 0.61538461538461542);
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawScaledTL(451, num4, num5, Color.White, 0.615384638f);
				}
				num4 += 8;
				num5 += 8;
				SpriteSheet<_sheetSprites>.Draw(1481, num4, num5, white);
			}
			int num6 = sAFE_AREA_OFFSET_L;
			int num7 = 98 + sAFE_AREA_OFFSET_T;
			for (int num8 = 8; num8 > 0; num8--)
			{
				int num9 = num7 + 44 * (num8 - 1);
				if (mapScreenCursorY - 1 == num8)
				{
					DrawInventoryCursor(num6 - 2, num9 - 2, 0.92307692307692313);
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawScaledTL(451, num6 + 2, num9 + 2, Color.White, 0.7692308f);
				}
			}
			Main.spriteBatch.End();
			GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
			for (int j = 0; j < allGamers.Count; j++)
			{
				NetworkGamer networkGamer = allGamers[j];
				Player player = networkGamer.Tag as Player;
				if (player != null)
				{
					DrawPlayerIcon(player, new Vector2(num6 + 8, num7 + 8 + j * 44), 1.5f);
				}
			}
			miniMap.DrawMap(view);
			DrawStringCC(fontSmall, Lang.menu[81], num + 26, num2 + 69, Color.White);
			DrawStringCC(fontSmall, Lang.menu[82], num3 + 16, num2 + 69, Color.White);
			for (int k = 0; k < allGamers.Count; k++)
			{
				NetworkGamer networkGamer2 = allGamers[k];
				Player player2 = networkGamer2.Tag as Player;
				if (player2 != null)
				{
					int y = num7 + 4 + 44 * k;
					DrawStringLT(fontSmallOutline, player2.name, num6 + 52, y, Main.teamColor[player2.team]);
				}
			}
		}

		private bool AccCheck(ref Item newItem, int slot)
		{
			if (player.armor[slot].netID == newItem.netID)
			{
				return false;
			}
			for (int i = 3; i < 11; i++)
			{
				if (newItem.netID == player.armor[i].netID)
				{
					return true;
				}
			}
			return false;
		}

		private void UpdateToolTipText(string extraInfo)
		{
			Main.strBuilder.Length = 0;
			string text2;
			if (toolTip.type > 0)
			{
				switch (toolTip.rare)
				{
				case -1:
					Main.strBuilder.Append("<f c='#828282'>");
					break;
				case 1:
					Main.strBuilder.Append("<f c='#9696FF'>");
					break;
				case 2:
					Main.strBuilder.Append("<f c='#96FF96'>");
					break;
				case 3:
					Main.strBuilder.Append("<f c='#FFC896'>");
					break;
				case 4:
					Main.strBuilder.Append("<f c='#FF9696'>");
					break;
				case 5:
					Main.strBuilder.Append("<f c='#FF96FF'>");
					break;
				case 6:
					Main.strBuilder.Append("<f c='#D2A0FF'>");
					break;
				default:
					Main.strBuilder.Append("<f c='#FFFFD2'>");
					break;
				}
				Main.strBuilder.Append(toolTip.AffixName());
				if (toolTip.stack > 1)
				{
					Main.strBuilder.Append(toolTip.stack.ToStackString());
				}
				Main.strBuilder.Append("</f>\n");
				if (extraInfo != null)
				{
					Main.strBuilder.Append(extraInfo);
					Main.strBuilder.Append('\n');
				}
				if (npcShop > 0 || (reforge && toolTip.Prefix(-3)))
				{
					if (toolTip.value > 0)
					{
						int num = toolTip.value * toolTip.stack;
						if (reforge)
						{
							Main.strBuilder.Append(Lang.inter[46]);
						}
						else if (toolTip.buy)
						{
							Main.strBuilder.Append(Lang.tip[50]);
						}
						else
						{
							num /= 5;
							Main.strBuilder.Append(Lang.tip[49]);
						}
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						if (num < 1)
						{
							num = 1;
						}
						if (num >= 1000000)
						{
							num2 = num / 1000000;
							num -= num2 * 1000000;
						}
						if (num >= 10000)
						{
							num3 = num / 10000;
							num -= num3 * 10000;
						}
						if (num >= 100)
						{
							num4 = num / 100;
							num -= num4 * 100;
						}
						if (num >= 1)
						{
							num5 = num;
						}
						if (num2 > 0)
						{
							Main.strBuilder.Append("<f c='#DCDCC6'>");
							Main.strBuilder.Append(num2.ToStringLookup());
							Main.strBuilder.Append(Lang.inter[15]);
							Main.strBuilder.Append("</f>");
						}
						if (num3 > 0)
						{
							Main.strBuilder.Append("<f c='#E0C95C'>");
							Main.strBuilder.Append(num3.ToStringLookup());
							Main.strBuilder.Append(Lang.inter[16]);
							Main.strBuilder.Append("</f>");
						}
						if (num4 > 0)
						{
							Main.strBuilder.Append("<f c='#B5C0C1'>");
							Main.strBuilder.Append(num4.ToStringLookup());
							Main.strBuilder.Append(Lang.inter[17]);
							Main.strBuilder.Append("</f>");
						}
						if (num5 > 0)
						{
							Main.strBuilder.Append("<f c='#F68A60'>");
							Main.strBuilder.Append(num5.ToStringLookup());
							Main.strBuilder.Append(Lang.inter[18]);
							Main.strBuilder.Append("</f>");
						}
						Main.strBuilder.Append('\n');
					}
					else
					{
						Main.strBuilder.Append("<f c='#787878'>");
						Main.strBuilder.Append(Lang.tip[51]);
						Main.strBuilder.Append("</f>\n");
					}
				}
				if (toolTip.material)
				{
					Main.strBuilder.Append("¤ ");
					Main.strBuilder.Append(Lang.tip[36]);
					Main.strBuilder.Append('\n');
				}
				if (toolTip.createWall > 0 || toolTip.createTile >= 0)
				{
					if (toolTip.type != 213)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[33]);
						Main.strBuilder.Append('\n');
					}
				}
				else if (toolTip.ammo > 0)
				{
					Main.strBuilder.Append("¤ ");
					Main.strBuilder.Append(Lang.tip[34]);
					Main.strBuilder.Append('\n');
				}
				else if (toolTip.consumable)
				{
					Main.strBuilder.Append("¤ ");
					Main.strBuilder.Append(Lang.tip[35]);
					Main.strBuilder.Append('\n');
				}
				if (toolTip.social)
				{
					Main.strBuilder.Append(Lang.tip[0]);
					Main.strBuilder.Append('\n');
					Main.strBuilder.Append(Lang.tip[1]);
					Main.strBuilder.Append('\n');
				}
				else
				{
					if (toolTip.damage > 0)
					{
						int damage = toolTip.damage;
						int num6 = 0;
						if (toolTip.melee)
						{
							Main.strBuilder.Append("¤ ");
							Main.strBuilder.Append(((int)(player.meleeDamage * (float)damage)).ToStringLookup());
							Main.strBuilder.Append(Lang.tip[2]);
							num6 = player.meleeCrit;
						}
						else if (toolTip.ranged)
						{
							Main.strBuilder.Append("¤ ");
							Main.strBuilder.Append(((int)(player.rangedDamage * (float)damage)).ToStringLookup());
							Main.strBuilder.Append(Lang.tip[3]);
							num6 = player.rangedCrit;
						}
						else if (toolTip.magic)
						{
							Main.strBuilder.Append("¤ ");
							Main.strBuilder.Append(((int)(player.magicDamage * (float)damage)).ToStringLookup());
							Main.strBuilder.Append(Lang.tip[4]);
							num6 = player.magicCrit;
						}
						num6 -= player.inventory[player.selectedItem].crit;
						num6 += toolTip.crit;
						Main.strBuilder.Append("\n¤ ");
						Main.strBuilder.Append(num6.ToStringLookup());
						Main.strBuilder.Append(Lang.tip[5]);
						Main.strBuilder.Append('\n');
						if (toolTip.useStyle > 0)
						{
							int num7 = 13;
							if (toolTip.useAnimation <= 8)
							{
								num7 = 6;
							}
							else if (toolTip.useAnimation <= 20)
							{
								num7 = 7;
							}
							else if (toolTip.useAnimation <= 25)
							{
								num7 = 8;
							}
							else if (toolTip.useAnimation <= 30)
							{
								num7 = 9;
							}
							else if (toolTip.useAnimation <= 35)
							{
								num7 = 10;
							}
							else if (toolTip.useAnimation <= 45)
							{
								num7 = 11;
							}
							else if (toolTip.useAnimation <= 55)
							{
								num7 = 12;
							}
							Main.strBuilder.Append("¤ ");
							Main.strBuilder.Append(Lang.tip[num7]);
							Main.strBuilder.Append('\n');
						}
						int num8 = 22;
						double num9 = toolTip.knockBack;
						if (player.kbGlove)
						{
							num9 *= 1.7;
						}
						if (num9 == 0.0)
						{
							num8 = 14;
						}
						else if (num9 <= 1.5)
						{
							num8 = 15;
						}
						else if (num9 <= 3.0)
						{
							num8 = 16;
						}
						else if (num9 <= 4.0)
						{
							num8 = 17;
						}
						else if (num9 <= 6.0)
						{
							num8 = 18;
						}
						else if (num9 <= 7.0)
						{
							num8 = 19;
						}
						else if (num9 <= 9.0)
						{
							num8 = 20;
						}
						else if (num9 <= 11.0)
						{
							num8 = 21;
						}
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[num8]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.isEquipable())
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[23]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.vanity)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[24]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.defense > 0)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(toolTip.defense.ToStringLookup());
						Main.strBuilder.Append(Lang.tip[25]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.pick > 0)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(((int)toolTip.pick).ToStringLookup());
						Main.strBuilder.Append(Lang.tip[26]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.axe > 0)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append((toolTip.axe * 5).ToStringLookup());
						Main.strBuilder.Append(Lang.tip[27]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.hammer > 0)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(((int)toolTip.hammer).ToStringLookup());
						Main.strBuilder.Append(Lang.tip[28]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.healLife > 0)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[29]);
						Main.strBuilder.Append(toolTip.healLife.ToStringLookup());
						Main.strBuilder.Append(Lang.tip[30]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.healMana > 0)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[29]);
						Main.strBuilder.Append(toolTip.healMana.ToStringLookup());
						Main.strBuilder.Append(Lang.tip[31]);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.mana > 0 && (toolTip.type != 127 || !player.spaceGun))
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[32]);
						Main.strBuilder.Append(((int)((float)(int)toolTip.mana * player.manaCost)).ToStringLookup());
						Main.strBuilder.Append(Lang.tip[31]);
						Main.strBuilder.Append('\n');
					}
					string text = Lang.toolTip(toolTip.netID);
					if (text != null)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(text);
						Main.strBuilder.Append('\n');
					}
					text = Lang.toolTip2(toolTip.netID);
					if (text != null)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(text);
						Main.strBuilder.Append('\n');
					}
					if (toolTip.buffTime > 0)
					{
						Main.strBuilder.Append("¤ ");
						if ((int)toolTip.buffTime / 60 >= 60)
						{
							Main.strBuilder.Append(((int)Math.Round((double)((int)toolTip.buffTime / 60) / 60.0)).ToStringLookup());
							Main.strBuilder.Append(Lang.tip[37]);
						}
						else
						{
							Main.strBuilder.Append(((int)Math.Round((double)(int)toolTip.buffTime / 60.0)).ToStringLookup());
							Main.strBuilder.Append(Lang.tip[38]);
						}
						Main.strBuilder.Append('\n');
					}
					if (toolTip.prefix > 0)
					{
						if (cpItem.netID != toolTip.netID)
						{
							cpItem.netDefaults(toolTip.netID);
						}
						if (cpItem.damage != toolTip.damage)
						{
							int num10 = toolTip.damage - cpItem.damage;
							num10 = (int)Math.Round((double)num10 * 100.0 / (double)cpItem.damage);
							if (num10 > 0)
							{
								Main.strBuilder.Append("¤ <f c='#78BE78'>+");
							}
							else
							{
								Main.strBuilder.Append("¤ <f c='#BE7878'>");
							}
							Main.strBuilder.Append(num10.ToStringLookup());
							Main.strBuilder.Append(Lang.tip[39]);
							Main.strBuilder.Append("</f>\n");
						}
						if (cpItem.useAnimation != toolTip.useAnimation)
						{
							int num11 = toolTip.useAnimation - cpItem.useAnimation;
							num11 = (int)Math.Round((double)num11 * 100.0 / (double)(int)cpItem.useAnimation);
							if (num11 > 0)
							{
								Main.strBuilder.Append("¤ <f c='#78BE78'>+");
							}
							else
							{
								Main.strBuilder.Append("¤ <f c='#BE7878'>");
							}
							Main.strBuilder.Append(num11.ToStringLookup());
							Main.strBuilder.Append(Lang.tip[40]);
							Main.strBuilder.Append("</f>\n");
						}
						if (cpItem.crit != toolTip.crit)
						{
							int num12 = toolTip.crit - cpItem.crit;
							if (num12 > 0)
							{
								Main.strBuilder.Append("¤ <f c='#78BE78'>+");
							}
							else
							{
								Main.strBuilder.Append("¤ <f c='#BE7878'>");
							}
							Main.strBuilder.Append(num12.ToStringLookup());
							Main.strBuilder.Append(Lang.tip[41]);
							Main.strBuilder.Append("</f>\n");
						}
						if (cpItem.mana != toolTip.mana)
						{
							int num13 = toolTip.mana - cpItem.mana;
							num13 = (int)Math.Round((double)num13 * 100.0 / (double)(int)cpItem.mana);
							if (num13 > 0)
							{
								Main.strBuilder.Append("¤ <f c='#78BE78'>+");
							}
							else
							{
								Main.strBuilder.Append("¤ <f c='#BE7878'>");
							}
							Main.strBuilder.Append(num13.ToStringLookup());
							Main.strBuilder.Append(Lang.tip[42]);
							Main.strBuilder.Append("</f>\n");
						}
						if (cpItem.scale != toolTip.scale)
						{
							int num14 = (int)Math.Round((double)(toolTip.scale - cpItem.scale) * 100.0 / (double)cpItem.scale);
							if (num14 > 0)
							{
								Main.strBuilder.Append("¤ <f c='#78BE78'>+");
							}
							else
							{
								Main.strBuilder.Append("¤ <f c='#BE7878'>");
							}
							Main.strBuilder.Append(num14.ToStringLookup());
							Main.strBuilder.Append(Lang.tip[43]);
							Main.strBuilder.Append("</f>\n");
						}
						if (cpItem.shootSpeed != toolTip.shootSpeed)
						{
							int num15 = (int)Math.Round((double)(toolTip.shootSpeed - cpItem.shootSpeed) * 100.0 / (double)cpItem.shootSpeed);
							if (num15 > 0)
							{
								Main.strBuilder.Append("¤ <f c='#78BE78'>+");
							}
							else
							{
								Main.strBuilder.Append("¤ <f c='#BE7878'>");
							}
							Main.strBuilder.Append(num15.ToStringLookup());
							Main.strBuilder.Append(Lang.tip[44]);
							Main.strBuilder.Append("</f>\n");
						}
						if (cpItem.knockBack != toolTip.knockBack)
						{
							int num16 = (int)Math.Round((double)(toolTip.knockBack - cpItem.knockBack) * 100.0 / (double)cpItem.knockBack);
							if (num16 > 0)
							{
								Main.strBuilder.Append("¤ <f c='#78BE78'>+");
							}
							else
							{
								Main.strBuilder.Append("¤ <f c='#BE7878'>");
							}
							Main.strBuilder.Append(num16.ToStringLookup());
							Main.strBuilder.Append(Lang.tip[45]);
							Main.strBuilder.Append("</f>\n");
						}
						switch (toolTip.prefix)
						{
						case 62:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
							Main.strBuilder.Append(Lang.tip[25]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 63:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
							Main.strBuilder.Append(Lang.tip[25]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 64:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
							Main.strBuilder.Append(Lang.tip[25]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 65:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
							Main.strBuilder.Append(Lang.tip[25]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 66:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+20");
							Main.strBuilder.Append(Lang.tip[31]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 67:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
							Main.strBuilder.Append(Lang.tip[5]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 68:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
							Main.strBuilder.Append(Lang.tip[5]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 69:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
							Main.strBuilder.Append(Lang.tip[39]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 70:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
							Main.strBuilder.Append(Lang.tip[39]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 71:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
							Main.strBuilder.Append(Lang.tip[39]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 72:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
							Main.strBuilder.Append(Lang.tip[39]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 73:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
							Main.strBuilder.Append(Lang.tip[46]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 74:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
							Main.strBuilder.Append(Lang.tip[46]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 75:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
							Main.strBuilder.Append(Lang.tip[46]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 76:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
							Main.strBuilder.Append(Lang.tip[46]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 77:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
							Main.strBuilder.Append(Lang.tip[47]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 78:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
							Main.strBuilder.Append(Lang.tip[47]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 79:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
							Main.strBuilder.Append(Lang.tip[47]);
							Main.strBuilder.Append("</f>\n");
							break;
						case 80:
							Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
							Main.strBuilder.Append(Lang.tip[47]);
							Main.strBuilder.Append("</f>\n");
							break;
						}
					}
					if (toolTip.wornArmor && player.setBonus != null)
					{
						Main.strBuilder.Append("¤ ");
						Main.strBuilder.Append(Lang.tip[48]);
						Main.strBuilder.Append(player.setBonus);
						Main.strBuilder.Append('\n');
					}
				}
				text2 = Main.strBuilder.ToString();
			}
			else
			{
				text2 = extraInfo;
				if (text2 == null)
				{
					text2 = "";
				}
			}
			if (text2 != toolTipText)
			{
				toolTipText = text2;
				compiledToolTipText = new CompiledText(text2, 322, styleFontSmallOutline);
			}
		}

		private void DrawToolTip(int TOOLTIP_X, int TOOLTIP_Y, int TOOLTIP_H)
		{
			Rectangle rectangle = new Rectangle(TOOLTIP_X, TOOLTIP_Y, 322, TOOLTIP_H);
			Main.DrawRect(451, rectangle, 255);
			compiledToolTipText.Draw(Main.spriteBatch, rectangle, new Color(255, 255, 255, 255), new Color(255, 212, 64, 255));
		}

		public void OpenInventory()
		{
			inventoryMode = 1;
			oldMouseX = mouseX;
			oldMouseY = mouseY;
			ClearButtonTriggers();
			if (worldFadeTarget > 0.5f)
			{
				worldFadeTarget = 0.5f;
			}
			craftingRecipeX = 0;
			craftingRecipeY = 0;
			player.AdjTiles();
			if (npcShop > 0)
			{
				restoreOldInventorySection = true;
				oldInventorySection = inventorySection;
				inventorySection = InventorySection.CHEST;
				inventoryChestX = 0;
				inventoryChestY = 0;
			}
			else if (player.chest != -1)
			{
				restoreOldInventorySection = true;
				oldInventorySection = inventorySection;
				inventorySection = InventorySection.CHEST;
				inventoryChestX = -1;
				inventoryChestY = 1;
			}
			else if (reforge || craftGuide)
			{
				restoreOldInventorySection = true;
				oldInventorySection = inventorySection;
				inventorySection = InventorySection.ITEMS;
			}
			else if (inventorySection == InventorySection.CRAFTING)
			{
				Recipe.FindRecipes(this, craftingCategory, craftingShowCraftable);
			}
		}

		public void CloseInventory()
		{
			if (inventoryMode > 0)
			{
				if (restoreOldInventorySection)
				{
					restoreOldInventorySection = false;
					inventorySection = oldInventorySection;
				}
				inventoryMode = 0;
				player.chest = -1;
				player.talkNPC = -1;
				npcShop = 0;
				reforge = false;
				craftGuide = false;
				mouseX = oldMouseX;
				mouseY = oldMouseY;
				toolTip.Init();
				ClearButtonTriggers();
				if (worldFadeTarget == 0.5f)
				{
					worldFadeTarget = 1f;
				}
				hotbarItemNameTime = 210;
			}
		}

		private bool IsInventorySectionAvailable(InventorySection section)
		{
			bool result = player.chest != -1 || npcShop > 0;
			switch (section)
			{
			case InventorySection.CHEST:
				return result;
			case InventorySection.HOUSING:
				if (mouseItem.type == 0 && !reforge)
				{
					return !craftGuide;
				}
				return false;
			case InventorySection.CRAFTING:
				if (mouseItem.type == 0 && !reforge)
				{
					if (craftGuide)
					{
						return guideItem.type > 0;
					}
					return true;
				}
				return false;
			case InventorySection.EQUIP:
				if (mouseItem.type != 0)
				{
					return mouseItem.isEquipable();
				}
				return true;
			default:
				return true;
			}
		}

		private void UpdateInventoryMenu()
		{
			int num = (int)inventorySection;
			bool flag = true;
			bool flag2 = IsButtonTriggered(Buttons.RightShoulder);
			bool flag3 = IsButtonTriggered(Buttons.LeftShoulder);
			do
			{
				if (flag2)
				{
					if (++num == 5)
					{
						num = 0;
					}
				}
				else if (flag3)
				{
					if (--num < 0)
					{
						num = 4;
					}
				}
				else if (!flag)
				{
					num = 1;
				}
				flag = IsInventorySectionAvailable((InventorySection)num);
			}
			while (!flag);
			inventorySection = (InventorySection)num;
			if (flag3 || flag2)
			{
				toolTip.Init();
				if (inventorySection == InventorySection.CRAFTING)
				{
					Recipe.FindRecipes(this, craftingCategory, craftingShowCraftable);
				}
			}
			if (gpState.IsButtonUp(Buttons.RightTrigger) && gpState.IsButtonUp(Buttons.A))
			{
				stackSplit = 0;
			}
			else if (stackSplit > 0)
			{
				stackSplit--;
			}
			if (stackSplit == 0)
			{
				stackCounter = 0;
				stackDelay = 7;
			}
			else if (++stackCounter >= 30)
			{
				stackCounter = 0;
				if (--stackDelay < 2)
				{
					stackDelay = 2;
				}
			}
		}

		public void PositionInventoryCursor(int dx, int dy)
		{
			while (true)
			{
				switch (inventorySection)
				{
				case InventorySection.ITEMS:
					inventoryItemX += (sbyte)dx;
					if (inventoryItemX < 0)
					{
						inventoryItemX += 10;
					}
					else if (inventoryItemX >= 10)
					{
						inventoryItemX -= 10;
					}
					inventoryItemY += (sbyte)dy;
					if (inventoryItemY < 0)
					{
						inventoryItemY += 7;
					}
					else if (inventoryItemY >= 7)
					{
						inventoryItemY -= 7;
					}
					if (inventoryItemY == 4)
					{
						if (reforge)
						{
							dy |= 1;
							break;
						}
						if (inventoryItemX < 6)
						{
							break;
						}
					}
					else if (inventoryItemY == 5)
					{
						if (reforge)
						{
							dy |= 1;
							break;
						}
						if (inventoryItemX < 6)
						{
							break;
						}
					}
					else if (inventoryItemY == 6 && inventoryItemX < 9)
					{
						break;
					}
					UpdateInventory();
					return;
				case InventorySection.CHEST:
					inventoryChestX += (sbyte)dx;
					if (inventoryChestX < -1)
					{
						inventoryChestX += 6;
					}
					else if (inventoryChestX >= 5)
					{
						inventoryChestX -= 6;
					}
					inventoryChestY += (sbyte)dy;
					if (inventoryChestY < 0)
					{
						inventoryChestY += 4;
					}
					else if (inventoryChestY >= 4)
					{
						inventoryChestY -= 4;
					}
					if (inventoryChestX < 0)
					{
						if (npcShop > 0 || mouseItem.type > 0)
						{
							if (dx == 0)
							{
								inventoryChestX = 0;
							}
							break;
						}
						if (inventoryChestY == 0)
						{
							inventoryChestY = 1;
						}
					}
					if (npcShop > 0)
					{
						UpdateShop();
					}
					else
					{
						UpdateStorage();
					}
					return;
				case InventorySection.EQUIP:
					inventoryEquipY += (sbyte)dy;
					if (inventoryEquipY < 0)
					{
						inventoryEquipY += 5;
					}
					else if (inventoryEquipY >= 5)
					{
						inventoryEquipY -= 5;
					}
					inventoryEquipX += (sbyte)dx;
					if (inventoryEquipX < 0)
					{
						if (inventoryEquipY == 0)
						{
							inventoryEquipX = 0;
							if (--inventoryBuffX < 0)
							{
								inventoryBuffX = 0;
							}
						}
						else
						{
							inventoryEquipX += 5;
						}
					}
					else if (inventoryEquipX >= 5)
					{
						if (inventoryEquipY == 0)
						{
							inventoryEquipX = 4;
							if (++inventoryBuffX > 5)
							{
								inventoryBuffX = 5;
							}
						}
						else
						{
							inventoryEquipX -= 5;
						}
					}
					if (inventoryEquipX < 1 || inventoryEquipX > 3 || inventoryEquipY < 1 || inventoryEquipY > 3)
					{
						UpdateEquip();
						return;
					}
					break;
				case InventorySection.HOUSING:
					if (dx != 0)
					{
						inventoryHousingX ^= 1;
					}
					inventoryHousingY += (sbyte)dy;
					if (inventoryHousingY < 0)
					{
						inventoryHousingY += 6;
					}
					else if (inventoryHousingY >= 6)
					{
						inventoryHousingY -= 6;
					}
					if (inventoryHousingX != 1 || inventoryHousingY != 5)
					{
						UpdateHousing();
						return;
					}
					break;
				}
			}
		}

		private bool UpdateCraftButtonInput(Recipe r)
		{
			if (stackSplit <= 1 && gpState.IsButtonDown(Buttons.A) && player.CanCraftRecipe(r))
			{
				int type = mouseItem.type;
				short stack = mouseItem.stack;
				mouseItem = r.createItem;
				mouseItem.Prefix(-1);
				mouseItem.stack += stack;
				mouseItem.position.X = player.aabb.X + 10 - (mouseItem.width >> 1);
				mouseItem.position.Y = player.aabb.Y + 21 - (mouseItem.height >> 1);
				mouseItemSrcSection = InventorySection.CRAFTING;
				mouseItemSrcX = -1;
				mouseItemSrcY = -1;
				r.Create(this);
				if (mouseItem.type > 0 || r.createItem.type > 0)
				{
					Main.PlaySound(7);
				}
				if (type == 0)
				{
					if (stackSplit == 0)
					{
						stackSplit = 15;
					}
					else
					{
						stackSplit = stackDelay;
					}
					player.GetItem(ref mouseItem);
				}
				return true;
			}
			return false;
		}

		private void PrevCraftingCategory()
		{
			int num = (int)craftingCategory;
			if (--num < 0)
			{
				num = 5;
			}
			Recipe.FindRecipes(this, (Recipe.Category)num, craftingShowCraftable);
			craftingCategory = (Recipe.Category)num;
			craftingRecipeX = 0;
			craftingRecipeY = 0;
			craftingRecipeScrollX = 0f;
			craftingRecipeScrollY = 0f;
		}

		private void NextCraftingCategory()
		{
			int num = (int)craftingCategory;
			if (++num == 6)
			{
				num = 0;
			}
			Recipe.FindRecipes(this, (Recipe.Category)num, craftingShowCraftable);
			craftingCategory = (Recipe.Category)num;
			craftingRecipeX = 0;
			craftingRecipeY = 0;
			craftingRecipeScrollX = 0f;
			craftingRecipeScrollY = 0f;
		}

		public void PositionCraftingCursor(int dx, int dy)
		{
			if (IsButtonUntriggered(Buttons.X) && mouseItem.type == 0)
			{
				craftingShowCraftable = !craftingShowCraftable;
				craftingRecipeX = 0;
				craftingRecipeScrollX = 0f;
				craftingRecipeScrollY = 0f;
				Recipe.FindRecipes(this, craftingCategory, craftingShowCraftable);
			}
			else if (IsButtonUntriggered(Buttons.A))
			{
				Recipe.FindRecipes(this, craftingCategory, craftingShowCraftable);
			}
			else
			{
				if (UpdateCraftButtonInput(craftingRecipe))
				{
					return;
				}
				if (IsButtonTriggered(Buttons.Y))
				{
					craftingSection ^= CraftingSection.INGREDIENTS;
				}
				else if (IsButtonTriggered(Buttons.LeftTrigger))
				{
					PrevCraftingCategory();
				}
				else if (IsButtonTriggered(Buttons.RightTrigger))
				{
					NextCraftingCategory();
				}
				else if (dx != 0 || dy != 0)
				{
					if (craftingRecipeScrollMul >= 0.325f)
					{
						craftingRecipeScrollMul -= 0.075f;
					}
					if (craftingSection == CraftingSection.RECIPES)
					{
						if (dx != 0)
						{
							if (craftingRecipeScrollX != 0f || craftingRecipeScrollY != 0f || currentRecipeCategory.Count == 0)
							{
								return;
							}
							int count = currentRecipeCategory[craftingRecipeY].recipes.Count;
							if (count != 1)
							{
								int num = craftingRecipeX + dx;
								if (num < 0)
								{
									num += count;
								}
								else if (num >= count)
								{
									num -= count;
								}
								craftingRecipeX = (sbyte)num;
								craftingRecipeScrollX = dx;
							}
						}
						else if (craftingRecipeScrollX == 0f && craftingRecipeScrollY == 0f)
						{
							craftingRecipeX = 0;
							int num2 = craftingRecipeY + dy;
							int count2 = currentRecipeCategory.Count;
							if (num2 < 0)
							{
								num2 += count2;
							}
							else if (num2 >= count2)
							{
								num2 -= count2;
							}
							else
							{
								craftingRecipeScrollY = dy;
							}
							craftingRecipeY = (sbyte)num2;
						}
					}
					else
					{
						int num3 = craftingIngredientX;
						num3 += dx;
						if (num3 < 0)
						{
							num3 += 4;
						}
						else if (num3 >= 4)
						{
							num3 -= 4;
						}
						craftingIngredientX = (sbyte)num3;
						int num4 = craftingIngredientY;
						num4 += dy;
						if (num4 < 0)
						{
							num4 += 3;
						}
						else if (num4 >= 3)
						{
							num4 -= 3;
						}
						craftingIngredientY = (sbyte)num4;
					}
				}
				else
				{
					craftingRecipeScrollMul = 0.8125f;
				}
			}
		}

		public void PositionMapScreenCursor(int dx, int dy)
		{
			if (IsButtonTriggered(Buttons.A))
			{
				Main.PlaySound(10);
				if (mapScreenCursorX == 0)
				{
					if (mapScreenCursorY < 2)
					{
						pvpCooldown = 180;
						pvpSelected = !pvpSelected;
					}
					else if (CanViewGamerCard() && Netplay.session != null)
					{
						GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
						int num = mapScreenCursorY - 2;
						if (num < allGamers.Count)
						{
							NetworkGamer gamer = allGamers[num];
							ShowGamerCard(gamer);
						}
					}
				}
				else
				{
					teamCooldown = 180;
					if (mapScreenCursorY == 0)
					{
						teamSelected = (byte)(mapScreenCursorX - 1);
					}
					else
					{
						teamSelected = (byte)((mapScreenCursorX != 1) ? (mapScreenCursorX + 1) : 0);
					}
				}
				return;
			}
			if (IsButtonTriggered(Buttons.X) && CanCommunicate())
			{
				if (Main.netMode > 0 && Netplay.gamer != null && !Guide.IsVisible)
				{
					Main.PlaySound(10);
					bool flag;
					do
					{
						flag = false;
						try
						{
							Guide.ShowGameInvite(controller, null);
						}
						catch (GuideAlreadyVisibleException)
						{
							Thread.Sleep(32);
							flag = true;
						}
					}
					while (flag);
				}
				return;
			}
			if (IsButtonTriggered(Buttons.Y))
			{
				if (signedInGamer.PartySize > 1 && Main.netMode > 0 && Netplay.gamer != null && localGamer != null)
				{
					localGamer.SendPartyInvites();
				}
				return;
			}
			if (dy != 0)
			{
				do
				{
					mapScreenCursorY += dy;
				}
				while (mapScreenCursorX == 0 && mapScreenCursorY == 1);
				dy = ((mapScreenCursorX > 0) ? 2 : 10);
				if (mapScreenCursorY < 0)
				{
					mapScreenCursorY += dy;
				}
				else if (mapScreenCursorY >= dy)
				{
					mapScreenCursorY -= dy;
				}
			}
			if (mapScreenCursorY < 2)
			{
				mapScreenCursorX += dx;
				if (mapScreenCursorX < 0)
				{
					mapScreenCursorX += 4;
				}
				else if (mapScreenCursorX >= 4)
				{
					mapScreenCursorX -= 4;
				}
			}
		}

		public void FoundPotentialArmor(int itemType)
		{
			if (TriggerCheckEnabled(Trigger.CollectedAllArmor))
			{
				armorFound.Set(itemType, value: true);
				if (armorFound.Get(604) && armorFound.Get(607) && armorFound.Get(610) && armorFound.Get(605) && armorFound.Get(608) && armorFound.Get(611) && armorFound.Get(606) && armorFound.Get(609) && armorFound.Get(612) && armorFound.Get(558) && armorFound.Get(559) && armorFound.Get(553) && armorFound.Get(551) && armorFound.Get(552) && armorFound.Get(400) && armorFound.Get(402) && armorFound.Get(401) && armorFound.Get(403) && armorFound.Get(404) && armorFound.Get(376) && armorFound.Get(377) && armorFound.Get(378) && armorFound.Get(379) && armorFound.Get(380) && armorFound.Get(371) && armorFound.Get(372) && armorFound.Get(373) && armorFound.Get(374) && armorFound.Get(375) && armorFound.Get(231) && armorFound.Get(232) && armorFound.Get(233) && armorFound.Get(151) && armorFound.Get(152) && armorFound.Get(153) && armorFound.Get(228) && armorFound.Get(229) && armorFound.Get(230) && armorFound.Get(102) && armorFound.Get(101) && armorFound.Get(100) && armorFound.Get(123) && armorFound.Get(124) && armorFound.Get(125) && armorFound.Get(92) && armorFound.Get(83) && armorFound.Get(79) && armorFound.Get(91) && armorFound.Get(82) && armorFound.Get(78) && armorFound.Get(90) && armorFound.Get(81) && armorFound.Get(77) && armorFound.Get(89) && armorFound.Get(80) && armorFound.Get(76) && armorFound.Get(88) && armorFound.Get(410) && armorFound.Get(411))
				{
					SetTriggerState(Trigger.CollectedAllArmor);
				}
			}
		}

		private void UpdateAlternateGrappleControls()
		{
			if (alternateGrappleControls)
			{
				BTN_JUMP2 = Buttons.LeftTrigger;
				BTN_GRAPPLE = Buttons.LeftStick;
			}
			else
			{
				BTN_JUMP2 = Buttons.LeftStick;
				BTN_GRAPPLE = Buttons.LeftTrigger;
			}
		}

		public bool IsJumpButtonDown()
		{
			if (!gpState.IsButtonDown(Buttons.A))
			{
				return gpState.IsButtonDown(BTN_JUMP2);
			}
			return true;
		}

		public bool WasJumpButtonUp()
		{
			if (gpPrevState.IsButtonUp(Buttons.A))
			{
				return gpPrevState.IsButtonUp(BTN_JUMP2);
			}
			return false;
		}

		public void ShowGamerCard(Gamer gamer)
		{
			if (gamer != null && !Guide.IsVisible)
			{
				bool flag;
				do
				{
					flag = false;
					try
					{
						Guide.ShowGamerCard(controller, gamer);
					}
					catch (GuideAlreadyVisibleException)
					{
						Thread.Sleep(32);
						flag = true;
					}
					catch (ObjectDisposedException)
					{
						gamer = Gamer.GetFromGamertag(gamer.Gamertag);
						flag = true;
					}
					catch (Exception)
					{
					}
				}
				while (flag);
			}
		}

		public void SignOut()
		{
			if (this.signedInGamer == null)
			{
				return;
			}
			SignedInGamer signedInGamer = this.signedInGamer;
			this.signedInGamer = null;
			foreach (SignedInGamer signedInGamer4 in Gamer.SignedInGamers)
			{
				if (signedInGamer4.PlayerIndex == controller && signedInGamer4.Gamertag == signedInGamer.Gamertag)
				{
					this.signedInGamer = signedInGamer4;
				}
			}
			if (this.signedInGamer != null)
			{
				if (Main.netMode > 0 && !HasOnline())
				{
					Error(Lang.menu[5], Lang.inter[36]);
					main.ExitGame();
				}
				else
				{
					if (!Main.isGameStarted)
					{
						return;
					}
					wasRemovedFromSessionWithoutOurConsent = true;
					if (this == main)
					{
						for (int i = 0; i < Netplay.session.LocalGamers.Count; i++)
						{
							SignedInGamer signedInGamer3 = Netplay.session.LocalGamers[i].SignedInGamer;
							Main.ui[(int)signedInGamer3.PlayerIndex].wasRemovedFromSessionWithoutOurConsent = true;
						}
					}
				}
				return;
			}
			wasRemovedFromSessionWithoutOurConsent = false;
			MessageBox.RemoveMessagesFor(controller);
			CancelInvite(signedInGamer);
			blacklist.Clear();
			if (this == main)
			{
				Netplay.StopFindingSessions();
				if (Main.worldGenThread != null)
				{
					Main.worldGenThread.Abort();
					Main.worldGenThread = null;
					WorldGen.gen = false;
				}
				if (playerStorage != null)
				{
					theGame.Components.Remove(playerStorage);
					playerStorage.Dispose();
					playerStorage = null;
				}
				if (numActiveViews == 1 || Main.isGameStarted)
				{
					if (Main.isGameStarted)
					{
						ExitGame();
					}
					SetMenu(MenuMode.WELCOME, rememberPrevious: false, reset: true);
					return;
				}
			}
			Exit();
		}

		public bool TestStorageSpace(string container, string destinationPath, int writeSize)
		{
			using (StorageContainer storageContainer = OpenPlayerStorage(container))
			{
				long num = storageContainer.StorageDevice.FreeSpace;
				if (num >= writeSize)
				{
					return true;
				}
				if (storageContainer.FileExists(destinationPath))
				{
					using (Stream stream = storageContainer.OpenFile(destinationPath, FileMode.Open, FileAccess.Read))
					{
						num += stream.Length;
					}
					if (num >= writeSize)
					{
						storageContainer.DeleteFile(destinationPath);
						return true;
					}
				}
			}
			MessageBox.Show(controller, Lang.menu[5], Lang.inter[70], new string[1]
			{
				Lang.menu[90]
			});
			return false;
		}

		public void WriteError()
		{
			MessageBox.Show(controller, Lang.menu[5], Lang.gen[54], new string[1]
			{
				Lang.menu[90]
			});
		}

		public void ReadError()
		{
			MessageBox.Show(controller, Lang.menu[9], Lang.gen[53], new string[1]
			{
				Lang.menu[90]
			});
		}

		public void CheckHDTV()
		{
			if (!Main.isHDTV)
			{
				Main.isHDTV = true;
				MessageBox.Show(controller, Lang.menu[3], Lang.inter[71], new string[1]
				{
					Lang.menu[90]
				});
			}
		}

		public bool CheckBlacklist()
		{
			ulong worldId = Main.GetWorldId();
			for (int num = blacklist.Count - 1; num >= 0; num--)
			{
				if (blacklist[num] == worldId)
				{
					if (menuType != 0)
					{
						menuType = MenuType.PAUSE;
					}
					string[] array = new string[2];
					if (menuType == MenuType.MAIN)
					{
						array[0] = Lang.menu[15];
					}
					else
					{
						array[0] = Lang.menu[100];
					}
					array[1] = Lang.inter[75];
					MessageBox.Show(controller, Lang.menu[3], Lang.inter[74], array, autoUpdate: false);
					SetMenu(MenuMode.BLACKLIST_REMOVE);
					return true;
				}
			}
			return false;
		}

		public void CheckUserGeneratedContent()
		{
			if (!IsUserGeneratedContentAllowed())
			{
				menuType = MenuType.PAUSE;
				MessageBox.Show(options: (!autoSave && IsStorageEnabledForAnyPlayer()) ? new string[2]
				{
					Lang.inter[2],
					Lang.inter[1]
				} : new string[1]
				{
					Lang.menu[15]
				}, controller: controller, caption: Lang.menu[3], contents: Lang.inter[79], autoUpdate: false);
				SetMenu(MenuMode.EXIT_UGC_BLOCKED);
			}
		}
	}
}
