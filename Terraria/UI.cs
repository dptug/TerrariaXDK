// Type: Terraria.UI
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Terraria.Achievements;
using Terraria.Leaderboards;

namespace Terraria
{
  public sealed class UI
  {
    public static Color DISABLED_COLOR = new Color(16, 16, 16, 128);
    public static Color WINDOW_OUTLINE = new Color(12, 24, 24, (int) byte.MaxValue);
    public static Color DEFAULT_DIALOG_COLOR = new Color(42, 43, 101, 192);
    private static int FONT_STACK_EXTRA_OFFSET = -5;
    public static WorldView[] activeView = new WorldView[4];
    private static CompiledText saveIconMessage = (CompiledText) null;
    private static int saveIconMessageTime = 0;
    public static byte mouseTextBrightness = (byte) 175;
    private static sbyte mouseTextColorChange = (sbyte) 2;
    public static Color mouseTextColor = new Color(175, 175, 175, 175);
    public static Color mouseColor = new Color((int) byte.MaxValue, 95, 180);
    public static Color cursorColor = Color.White;
    public static float cursorAlpha = 0.0f;
    public static float cursorScale = 0.0f;
    public static byte invAlpha = (byte) 180;
    private static sbyte invDir = (sbyte) 1;
    public static float essScale = 1f;
    private static float essDir = -0.01f;
    public static float blueWave = 1f;
    private static float blueDelta = -0.0005f;
    public static bool quit = false;
    public static SpriteFont[] fontCombatText = new SpriteFont[2];
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
    private static Item cpItem = new Item();
    public byte myPlayer = (byte) 8;
    public NetPlayer netPlayer = new NetPlayer();
    public float worldFadeTarget = 1f;
    public float uiFade = 1f;
    public float uiFadeTarget = 1f;
    public bool smartCursor = true;
    public Buttons BTN_JUMP2 = Buttons.LeftStick;
    public Buttons BTN_GRAPPLE = Buttons.LeftTrigger;
    private sbyte quickAccessUp = (sbyte) -1;
    private sbyte quickAccessDown = (sbyte) -1;
    private sbyte quickAccessLeft = (sbyte) -1;
    private sbyte quickAccessRight = (sbyte) -1;
    private List<string> transferredPlayerStorage = new List<string>(3);
    public Player[] loadPlayer = new Player[5];
    public string[] loadPlayerPath = new string[5];
    private float logoRotationDirection = 1f;
    private float logoRotationSpeed = 1f;
    private float logoScale = 1f;
    private float logoScaleDirection = 1f;
    private float logoScaleSpeed = 1f;
    private short LogoA = (short) byte.MaxValue;
    public float musicVolume = 0.75f;
    public float soundVolume = 1f;
    public bool showItemText = true;
    private Stopwatch saveTime = new Stopwatch();
    private Color selColor = Color.White;
    private bool[] noFocus = new bool[14];
    private bool[] blockFocus = new bool[14];
    private short[] menuY = new short[14];
    private byte[] menuHC = new byte[14];
    private float[] menuScale = new float[14];
    private float[] menuItemScale = new float[14];
    private sbyte focusMenu = (sbyte) -1;
    private sbyte selectedMenu = (sbyte) -1;
    public MenuMode menuMode = MenuMode.WELCOME;
    public MenuMode[] prevMenuMode = new MenuMode[16];
    private Location[] uiPos = new Location[38];
    public int hotbarItemNameTime = 210;
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
    public float[] inventoryMenuSectionScale = new float[5]
    {
      0.75f,
      0.75f,
      1f,
      0.75f,
      0.75f
    };
    public UI.InventorySection inventorySection = UI.InventorySection.ITEMS;
    private sbyte inventoryEquipY = (sbyte) 1;
    private short inventoryHousingNpc = (short) -1;
    private float craftingRecipeScrollMul = 13.0 / 16.0;
    public short stackDelay = (short) 7;
    private UI.InventorySection mouseItemSrcSection = UI.InventorySection.NUM_SECTIONS;
    public Item mouseItem = new Item();
    public Item trashItem = new Item();
    public Item guideItem = new Item();
    private Item toolTip = new Item();
    public List<Recipe.SubCategoryList> currentRecipeCategory = new List<Recipe.SubCategoryList>();
    public MiniMap miniMap = new MiniMap();
    private BitArray armorFound = new BitArray(632);
    private List<ulong> blacklist = new List<ulong>();
    private string[] menuString = new string[14];
    private sbyte showPlayer = (sbyte) -1;
    private byte menuSpace = (byte) 80;
    private short menuTop = (short) 250;
    private short menuLeft = (short) 480;
    private const bool TEST_WATCH = false;
    private const bool TEST_DEPTH_METER = false;
    private const bool TEST_COMPASS = false;
    private const ulong MARKETPLACE_OFFER_ID = 6359384554213474305UL;
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
    private const float WORLD_FADE_SPEED = 0.03333334f;
    private const float UI_FADE_SPEED = 0.03333334f;
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
    public static UI main;
    public static UI current;
    public static int numActiveViews;
    public WorldView view;
    public LocalNetworkGamer localGamer;
    public SignedInGamer signedInGamer;
    public PlayerIndex controller;
    public Player player;
    private byte privateSlots;
    public bool wasRemovedFromSessionWithoutOurConsent;
    public MenuType menuType;
    public bool isStopping;
    public float worldFade;
    public short oldMouseX;
    public short oldMouseY;
    public short mouseX;
    public short mouseY;
    public bool alternateGrappleControls;
    public GamePadState gpPrevState;
    public GamePadState gpState;
    public StorageDeviceManager playerStorage;
    public sbyte numLoadPlayers;
    public string playerPathName;
    private float logoRotation;
    private short LogoB;
    public string statusText;
    private static string errorDescription;
    private static string errorCaption;
    private static CompiledText errorCompiledText;
    public bool autoSave;
    public bool isOnline;
    public bool isInviteOnly;
    public bool settingsDirty;
    public sbyte selectedPlayer;
    public int menuDepth;
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
    public int cursorHighlight;
    public Terraria.CreateCharacter.UI createCharacterGUI;
    private Terraria.SoundUI.UI soundUI;
    private Terraria.HowToPlay.UI howtoUI;
    private TextSequenceBlock tips;
    private LeaderboardsUI leaderboards;
    public int quickAccessDisplayTime;
    private static float inventoryScale;
    public byte inventoryMode;
    private bool restoreOldInventorySection;
    private UI.InventorySection oldInventorySection;
    private sbyte inventoryItemX;
    private sbyte inventoryItemY;
    private sbyte inventoryChestX;
    private sbyte inventoryChestY;
    private sbyte inventoryEquipX;
    private sbyte inventoryBuffX;
    private sbyte inventoryHousingX;
    private sbyte inventoryHousingY;
    public Recipe.Category craftingCategory;
    private UI.CraftingSection craftingSection;
    public bool craftingShowCraftable;
    public sbyte craftingRecipeX;
    public sbyte craftingRecipeY;
    private sbyte craftingIngredientX;
    private sbyte craftingIngredientY;
    private float craftingRecipeScrollX;
    private float craftingRecipeScrollY;
    public Recipe craftingRecipe;
    public short stackSplit;
    public short stackCounter;
    private sbyte mouseItemSrcX;
    private sbyte mouseItemSrcY;
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
    private static Main theGame;
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
    public static CompiledText.Style styleFontSmallOutline;
    private byte numMenuItems;
    private sbyte oldMenu;
    public bool inputTextEnter;
    public bool inputTextCanceled;
    private IAsyncResult kbResult;
    private string focusText;
    private string focusText3;
    private Color focusColor;
    private static CompiledText compiledToolTipText;
    private static string toolTipText;

    static UI()
    {
    }

    public static void Error(string caption, string desc, bool rememberPreviousMenu = false)
    {
      UI.errorCompiledText = (CompiledText) null;
      UI.errorCaption = caption;
      UI.errorDescription = desc;
      UI.main.SetMenu(MenuMode.ERROR, rememberPreviousMenu, false);
    }

    public void InitGame()
    {
      this.wasRemovedFromSessionWithoutOurConsent = false;
      this.restoreOldInventorySection = false;
      this.inventoryMode = (byte) 0;
      this.inventorySection = UI.InventorySection.ITEMS;
      this.inventoryItemX = (sbyte) 0;
      this.inventoryItemY = (sbyte) 0;
      this.inventoryChestX = (sbyte) 0;
      this.inventoryChestY = (sbyte) 0;
      this.inventoryEquipX = (sbyte) 0;
      this.inventoryEquipY = (sbyte) 1;
      this.inventoryBuffX = (sbyte) 0;
      this.inventoryHousingX = (sbyte) 0;
      this.inventoryHousingY = (sbyte) 0;
      this.inventoryHousingNpc = (short) -1;
      this.craftingCategory = Recipe.Category.STRUCTURES;
      this.craftingSection = UI.CraftingSection.RECIPES;
      this.craftingShowCraftable = false;
      this.craftingRecipeX = (sbyte) 0;
      this.craftingRecipeY = (sbyte) 0;
      this.craftingIngredientX = (sbyte) 0;
      this.craftingIngredientY = (sbyte) 0;
      this.craftingRecipeScrollX = 0.0f;
      this.craftingRecipeScrollY = 0.0f;
      this.mouseItem.Init();
      this.trashItem.Init();
      this.guideItem.Init();
      this.toolTip.Init();
      this.helpText = (short) 0;
      this.showNPCs = false;
      this.mapScreenCursorX = 0;
      this.mapScreenCursorY = 0;
      this.teamSelected = (byte) 0;
      this.pvpSelected = false;
      this.teamCooldown = (short) 0;
      this.pvpCooldown = (short) 0;
      this.npcShop = (byte) 0;
      this.craftGuide = false;
      this.reforge = false;
      this.editSign = false;
      this.signBubble = false;
      this.npcChatText = (UserString) null;
      this.npcChatSelectedItem = (sbyte) 0;
      this.player.hostile = false;
      this.player.NetClone(this.netPlayer);
      this.InitializeAchievementTriggers();
    }

    private void InitializeAchievementTriggers()
    {
      this.AchievementTriggers.ReadProfile(this.signedInGamer);
    }

    public bool TriggerCheckEnabled(Trigger trigger)
    {
      return this.AchievementTriggers.CheckEnabled(trigger);
    }

    public void SetTriggerState(Trigger trigger)
    {
      this.AchievementTriggers.SetState(trigger, true);
    }

    public static void SetTriggerStateForAll(Trigger trigger)
    {
      for (int index = 0; index < 8; ++index)
      {
        Player player = Main.player[index];
        if ((int) player.active != 0)
          player.AchievementTrigger(trigger);
      }
    }

    public static void IncreaseStatisticForAll(StatisticEntry entry)
    {
      if (entry == StatisticEntry.Unknown)
        return;
      for (int index = 0; index < 8; ++index)
      {
        Player player = Main.player[index];
        if ((int) player.active != 0)
          player.IncreaseStatistic(entry);
      }
    }

    private void UpdateAchievements()
    {
      if (this.Statistics.AllSlimeTypesKilled)
        this.SetTriggerState(Trigger.AllSlimesKilled);
      if (this.Statistics.AllBossesKilled)
        this.SetTriggerState(Trigger.AllBossesKilled);
      this.AchievementTriggers.UpdateAchievements(this.signedInGamer);
    }

    public static void Initialize(Main game)
    {
      UI.theGame = game;
      Terraria.HowToPlay.UI.GenerateCache(game.GraphicsDevice);
      TextSequenceBlock.GenerateCache(game.GraphicsDevice);
    }

    public void Initialize(PlayerIndex controller)
    {
      this.controller = controller;
      UI.current = this;
      if (UI.main == null)
        UI.main = this;
      for (int index = 13; index >= 0; --index)
        this.menuItemScale[index] = 0.8f;
      for (int index = 4; index >= 0; --index)
        this.loadPlayer[index] = new Player();
      this.createCharacterGUI = Terraria.CreateCharacter.UI.Create(this);
      this.soundUI = Terraria.SoundUI.UI.Create(this);
      this.howtoUI = Terraria.HowToPlay.UI.Create(this);
      this.tips = TextSequenceBlock.CreateTips();
      this.Statistics = Statistics.Create();
      this.AchievementTriggers = new TriggerSystem();
      this.leaderboards = new LeaderboardsUI(this);
    }

    private void SetDefaultSettings()
    {
      this.soundVolume = 1f;
      this.musicVolume = 0.75f;
      if (this == UI.main)
      {
        Main.musicVolume = this.musicVolume;
        Main.soundVolume = this.soundVolume;
      }
      this.autoSave = true;
      this.showItemText = true;
      this.alternateGrappleControls = false;
      this.UpdateAlternateGrappleControls();
      this.Statistics.Init();
      this.totalSteps = 0U;
      this.totalPicked = 0U;
      this.totalBarsCrafted = 0U;
      this.totalAnvilCrafting = 0U;
      this.totalWires = 0U;
      this.totalAirTime = 0U;
      this.petSpawnMask = (byte) 0;
      this.armorFound.SetAll(false);
      this.isOnline = false;
      this.isInviteOnly = false;
      this.blacklist.Clear();
      this.settingsDirty = false;
    }

    private void InitPlayerStorage()
    {
      this.SetDefaultSettings();
      this.numLoadPlayers = (sbyte) 0;
      if (this.signedInGamer.IsGuest || Main.isTrial)
      {
        this.playerStorage = (StorageDeviceManager) null;
      }
      else
      {
        if (this.playerStorage == null)
        {
          this.playerStorage = new StorageDeviceManager((Game) UI.theGame, this.controller, 196608);
          this.playerStorage.DeviceSelectorCanceled += new EventHandler<EventArgs>(this.DeviceSelectorCanceled);
          this.playerStorage.DeviceDisconnected += new EventHandler<EventArgs>(this.DeviceDisconnected);
          this.playerStorage.DeviceSelected += new EventHandler(this.DeviceSelected);
          ((Collection<IGameComponent>) UI.theGame.Components).Add((IGameComponent) this.playerStorage);
        }
        if (this.playerStorage.Device != null)
          return;
        this.playerStorage.PromptForDevice();
      }
    }

    public bool HasPlayerStorage()
    {
      if (this.playerStorage != null)
        return this.playerStorage.Device != null;
      else
        return false;
    }

    public bool CanViewGamerCard()
    {
      if (this.signedInGamer.IsSignedInToLive && this.signedInGamer.Privileges.AllowProfileViewing != GamerPrivilegeSetting.Blocked)
        return !GuideExtensions.get_IsNetworkCableUnplugged();
      else
        return false;
    }

    public bool HasOnline()
    {
      if (!Main.isTrial && this.signedInGamer.IsSignedInToLive)
        return !GuideExtensions.get_IsNetworkCableUnplugged();
      else
        return false;
    }

    public bool HasOnlineWithPrivileges()
    {
      if (!Main.isTrial && this.signedInGamer.IsSignedInToLive && this.signedInGamer.Privileges.AllowOnlineSessions)
        return !GuideExtensions.get_IsNetworkCableUnplugged();
      else
        return false;
    }

    public static bool IsUserGeneratedContentAllowed()
    {
      GamerCollection<NetworkGamer> gamerCollection = Netplay.session != null ? Netplay.session.RemoteGamers : (GamerCollection<NetworkGamer>) null;
      SignedInGamerCollection signedInGamers = Gamer.SignedInGamers;
      for (int index1 = ((ReadOnlyCollection<SignedInGamer>) signedInGamers).Count - 1; index1 >= 0; --index1)
      {
        SignedInGamer signedInGamer = ((ReadOnlyCollection<SignedInGamer>) signedInGamers)[index1];
        if (!signedInGamer.IsGuest && signedInGamer.IsSignedInToLive)
        {
          if (signedInGamer.Privileges.AllowUserCreatedContent == GamerPrivilegeSetting.Blocked)
            return false;
          if (gamerCollection != null && signedInGamer.Privileges.AllowUserCreatedContent == GamerPrivilegeSetting.FriendsOnly)
          {
            for (int index2 = ((ReadOnlyCollection<NetworkGamer>) gamerCollection).Count - 1; index2 >= 0; --index2)
            {
              NetworkGamer networkGamer = ((ReadOnlyCollection<NetworkGamer>) gamerCollection)[index2];
              if (!signedInGamer.IsFriend((Gamer) networkGamer))
                return false;
            }
          }
        }
      }
      return true;
    }

    public bool CanPlayOnline()
    {
      if (this.HasOnlineWithPrivileges())
        return UI.IsUserGeneratedContentAllowed();
      else
        return false;
    }

    public bool CanCommunicate()
    {
      return this.signedInGamer.Privileges.AllowCommunication != GamerPrivilegeSetting.Blocked;
    }

    public static bool AllPlayersCanPlayOnline()
    {
      if (!UI.IsUserGeneratedContentAllowed())
        return false;
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.signedInGamer != null && !ui.HasOnlineWithPrivileges())
          return false;
      }
      return true;
    }

    public static void LoadContent(ContentManager Content)
    {
      Terraria.CreateCharacter.Assets.LoadContent(Content);
      Terraria.SoundUI.Assets.LoadContent(Content);
      Terraria.HowToPlay.Assets.LoadContent(Content);
      Terraria.Leaderboards.Assets.LoadContent(Content);
      UI.logoTexture = Content.Load<Texture2D>("Images/Logo");
      UI.logo2Texture = Content.Load<Texture2D>("Images/Logo2");
      UI.controlsTexture = Content.Load<Texture2D>("UI/Controller_Layout01");
      UI.progressBarTexture = Content.Load<Texture2D>("UI/ProgressBar");
      UI.textBackTexture = Content.Load<Texture2D>("Images/Text_Back");
      UI.chatBackTexture = Content.Load<Texture2D>("Images/Chat_Back");
      UI.cursorTexture = Content.Load<Texture2D>("Images/Cursor");
      UI.LoadFonts(Content);
    }

    public static void LoadFonts(ContentManager Content)
    {
      UI.fontBig = Content.Load<SpriteFont>("Fonts/big");
      UI.fontBig.Spacing = -24f;
      UI.fontItemStack = Content.Load<SpriteFont>("Fonts/stack");
      UI.fontItemStack.Spacing = -4f;
      UI.FONT_STACK_EXTRA_OFFSET = -5;
      UI.fontCombatText[0] = Content.Load<SpriteFont>("Fonts/combat");
      UI.fontCombatText[0].Spacing = -3f;
      UI.fontCombatText[1] = Content.Load<SpriteFont>("Fonts/combat2");
      UI.fontCombatText[1].Spacing = -4f;
      UI.fontSmall = Content.Load<SpriteFont>("Fonts/small");
      UI.fontSmall.Spacing = -2f;
      UI.fontSmall.LineSpacing = 20;
      UI.fontSmallOutline = Content.Load<SpriteFont>("Fonts/small2");
      UI.fontSmallOutline.Spacing = -5f;
      UI.fontSmallOutline.LineSpacing = 22;
      UI.styleFontSmallOutline = new CompiledText.Style(UI.fontSmallOutline);
    }

    public static void LoadSplitscreenFonts(ContentManager Content)
    {
      UI.fontBig = Content.Load<SpriteFont>("Fonts/big_sc");
      UI.fontBig.Spacing = -13f;
      UI.fontBig.LineSpacing = 19;
      UI.fontItemStack = Content.Load<SpriteFont>("Fonts/stack_sc");
      UI.fontItemStack.Spacing = -4f;
      UI.FONT_STACK_EXTRA_OFFSET = -8;
      UI.fontCombatText[0] = Content.Load<SpriteFont>("Fonts/combat_sc");
      UI.fontCombatText[0].Spacing = -2f;
      UI.fontCombatText[1] = Content.Load<SpriteFont>("Fonts/combat2_sc");
      UI.fontCombatText[1].Spacing = -3f;
      UI.fontSmall = Content.Load<SpriteFont>("Fonts/small_sc");
      UI.fontSmall.Spacing = -2f;
      UI.fontSmall.LineSpacing = 10;
      UI.fontSmallOutline = Content.Load<SpriteFont>("Fonts/small2_sc");
      UI.fontSmallOutline.Spacing = -2f;
      UI.fontSmallOutline.LineSpacing = 13;
      UI.styleFontSmallOutline = new CompiledText.Style(UI.fontSmallOutline);
    }

    private void InvalidateCachedText()
    {
      UI.toolTipText = (string) null;
      this.npcCompiledChatText = (string) null;
      UI.errorCompiledText = (CompiledText) null;
      Terraria.HowToPlay.UI.GenerateCache(UI.theGame.GraphicsDevice);
      TextSequenceBlock.GenerateCache(UI.theGame.GraphicsDevice);
    }

    public static float Spacing(SpriteFont font)
    {
      float spacing = font.Spacing;
      if (UI.numActiveViews > 1)
        spacing *= 2f;
      return spacing;
    }

    public static int LineSpacing(SpriteFont font)
    {
      int lineSpacing = font.LineSpacing;
      if (UI.numActiveViews > 1)
        lineSpacing <<= 1;
      return lineSpacing;
    }

    public static Vector2 MeasureString(SpriteFont font)
    {
      Vector2 vector2 = font.MeasureString(Main.strBuilder);
      if (UI.numActiveViews > 1)
      {
        vector2.X *= 2f;
        vector2.Y *= 2f;
      }
      return vector2;
    }

    public static float MeasureStringX(SpriteFont font)
    {
      float num = font.MeasureString(Main.strBuilder).X;
      if (UI.numActiveViews > 1)
        num *= 2f;
      return num;
    }

    public static Vector2 MeasureString(SpriteFont font, string text)
    {
      Vector2 vector2 = font.MeasureString(text);
      if (UI.numActiveViews > 1)
      {
        vector2.X *= 2f;
        vector2.Y *= 2f;
      }
      return vector2;
    }

    public static void DrawStringLB(SpriteFont font, int x, int y)
    {
      Vector2 vector2 = font.MeasureString(Main.strBuilder);
      Main.spriteBatch.DrawString(font, Main.strBuilder, new Vector2((float) x, (float) (540 - y)), Color.White, 0.0f, new Vector2(0.0f, vector2.Y), UI.numActiveViews > 1 ? 2f : 1f, SpriteEffects.None, 0.0f);
    }

    public static void DrawStringLT(SpriteFont font, int x, int y, Color c)
    {
      Main.spriteBatch.DrawString(font, Main.strBuilder, new Vector2((float) x, (float) y), c, 0.0f, new Vector2(), UI.numActiveViews > 1 ? 2f : 1f, SpriteEffects.None, 0.0f);
    }

    public static void DrawStringLT(SpriteFont font, string s, int x, int y, Color c)
    {
      Main.spriteBatch.DrawString(font, s, new Vector2((float) x, (float) y), c, 0.0f, new Vector2(), UI.numActiveViews > 1 ? 2f : 1f, SpriteEffects.None, 0.0f);
    }

    public static void DrawStringScaled(SpriteFont font, string s, Vector2 pos, Color c, Vector2 pivot, float scale)
    {
      if (UI.numActiveViews > 1)
      {
        scale *= 2f;
        pivot.X *= 0.5f;
        pivot.Y *= 0.5f;
      }
      Main.spriteBatch.DrawString(font, s, pos, c, 0.0f, pivot, scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawString(SpriteFont font, string s, Vector2 pos, Color c, float rot, Vector2 pivot, float scale)
    {
      if (UI.numActiveViews > 1)
      {
        scale *= 2f;
        pivot.X *= 0.5f;
        pivot.Y *= 0.5f;
      }
      Main.spriteBatch.DrawString(font, s, pos, c, rot, pivot, scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawStringScaled(SpriteFont font, Vector2 pos, Color c, Vector2 pivot, float scale)
    {
      if (UI.numActiveViews > 1)
      {
        scale *= 2f;
        pivot.X *= 0.5f;
        pivot.Y *= 0.5f;
      }
      Main.spriteBatch.DrawString(font, Main.strBuilder, pos, c, 0.0f, pivot, scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawStringCC(SpriteFont font, string s, int x, int y, Color c)
    {
      float scale = UI.numActiveViews > 1 ? 2f : 1f;
      Vector2 origin = font.MeasureString(s);
      origin.X = (float) Math.Round((double) origin.X * 0.5);
      origin.Y = (float) Math.Round((double) origin.Y * 0.5);
      Main.spriteBatch.DrawString(font, s, new Vector2((float) x, (float) y), c, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawStringLC(SpriteFont font, string s, int x, int y, Color c)
    {
      float scale = UI.numActiveViews > 1 ? 2f : 1f;
      Vector2 origin = font.MeasureString(s);
      origin.X = 0.0f;
      origin.Y = (float) Math.Round((double) origin.Y * 0.5);
      Main.spriteBatch.DrawString(font, s, new Vector2((float) x, (float) y), c, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
    }

    public static void DrawStringRC(SpriteFont font, string s, int x, int y, Color c)
    {
      float scale = UI.numActiveViews > 1 ? 2f : 1f;
      Vector2 origin = font.MeasureString(s);
      origin.Y = (float) Math.Round((double) origin.Y * 0.5);
      Main.spriteBatch.DrawString(font, s, new Vector2((float) x, (float) y), c, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
    }

    public static float DrawStringCT(SpriteFont font, string s, int x, int y, Color c)
    {
      float scale = UI.numActiveViews > 1 ? 2f : 1f;
      Vector2 origin = font.MeasureString(s);
      origin.X = (float) Math.Round((double) origin.X * 0.5);
      float num = origin.Y * scale;
      origin.Y = 0.0f;
      Main.spriteBatch.DrawString(font, s, new Vector2((float) x, (float) y), c, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
      return num;
    }

    public static float DrawStringCT(SpriteFont font, int x, int y, Color c)
    {
      float num1 = UI.numActiveViews > 1 ? 2f : 1f;
      Vector2 vector2 = font.MeasureString(Main.strBuilder);
      vector2.X *= 0.5f;
      float num2 = vector2.Y * num1;
      vector2.Y = 0.0f;
      Main.spriteBatch.DrawString(font, Main.strBuilder, new Vector2((float) x, (float) y), c, 0.0f, vector2, num1, SpriteEffects.None, 0.0f);
      return num2;
    }

    public void PrevMenu(int depth = -1)
    {
      Main.PlaySound(11);
      if (depth < 0)
      {
        this.menuDepth += depth;
        if (this.menuDepth >= 0)
          this.SetMenu(this.prevMenuMode[this.menuDepth], false, false);
        else
          this.SetMenu(MenuMode.TITLE, false, true);
      }
      else if (depth < this.menuDepth)
      {
        this.menuDepth = depth;
        this.SetMenu(this.prevMenuMode[depth], false, false);
      }
      else
        this.SetMenu(MenuMode.TITLE, false, true);
    }

    private void ResetPlayerMenuSelection()
    {
      this.uiX = (short) 0;
      this.uiY = (int) this.numLoadPlayers > 0 ? (short) 0 : (short) 5;
    }

    public void SetMenu(MenuMode mode, bool rememberPrevious = true, bool reset = false)
    {
      if (this.settingsDirty)
        this.SaveSettings();
      this.numMenuItems = (byte) 0;
      if (reset)
        this.menuDepth = 0;
      if (mode == MenuMode.TITLE)
      {
        Main.SetTutorial(Tutorial.NUM_TUTORIALS);
        if (!Main.isTrial && UI.saveIconMessage == null)
        {
          UI.saveIconMessage = new CompiledText(Lang.menu[4], 470, UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
          UI.saveIconMessageTime = 480;
        }
        if (this.signedInGamer != null)
          GamerPresenceExtensions.SetPresenceModeString(this.signedInGamer.Presence, "Menu");
        if (Netplay.isJoiningRemoteInvite)
        {
          if (Netplay.gamersWaitingToJoinInvite.Contains(this.signedInGamer))
          {
            mode = MenuMode.CHARACTER_SELECT;
            if (this == UI.main)
            {
              for (int index = Netplay.gamersWaitingToJoinInvite.Count - 1; index >= 0; --index)
              {
                SignedInGamer signedInGamer = Netplay.gamersWaitingToJoinInvite[index];
                if (signedInGamer != this.signedInGamer)
                {
                  UI ui = Main.ui[(int) signedInGamer.PlayerIndex];
                  ui.SetMenu(MenuMode.CHARACTER_SELECT, false, true);
                  ui.OpenView();
                }
              }
            }
          }
          else
          {
            this.Exit();
            return;
          }
        }
      }
      if (this.menuMode != MenuMode.NONE)
      {
        for (int index = this.menuHC.Length - 1; index >= 0; --index)
          this.menuHC[index] = (byte) 0;
        if (rememberPrevious)
          this.prevMenuMode[this.menuDepth++] = this.menuMode;
        this.uiPos[(int) this.menuMode].X = this.uiX;
        this.uiPos[(int) this.menuMode].Y = this.uiY;
      }
      this.menuMode = mode;
      this.uiX = this.uiPos[(int) mode].X;
      this.uiY = this.uiPos[(int) mode].Y;
      this.uiDelay = (sbyte) 0;
      this.uiDelayValue = (sbyte) 12;
      switch (mode)
      {
        case MenuMode.PAUSE:
          this.worldFadeTarget = 0.375f;
          this.uiWidth = (sbyte) 1;
          this.uiHeight = (sbyte) 7;
          this.uiCoords = UI.MENU_PAUSE_COORDS;
          return;
        case MenuMode.MAP:
          this.worldFadeTarget = 0.375f;
          this.uiFade = 0.0f;
          this.uiFadeTarget = 1f;
          break;
        case MenuMode.TITLE:
          this.uiWidth = (sbyte) 1;
          this.uiHeight = (sbyte) 7;
          this.uiCoords = UI.MENU_TITLE_COORDS;
          return;
        case MenuMode.CHARACTER_SELECT:
          this.uiWidth = (sbyte) 1;
          this.uiHeight = (sbyte) 6;
          this.uiCoords = UI.MENU_SELECT_COORDS;
          this.initCharacterSelectCoordinates();
          return;
        case MenuMode.CONFIRM_LEAVE_CREATE_CHARACTER:
        case MenuMode.CONFIRM_DELETE_CHARACTER:
        case MenuMode.CONFIRM_DELETE_WORLD:
          this.uiWidth = (sbyte) 1;
          this.uiHeight = (sbyte) 2;
          this.uiCoords = UI.MENU_CONFIRM_DELETE_COORDS;
          return;
        case MenuMode.WORLD_SELECT:
          if (Netplay.availableSessions.Count == 0 && !Netplay.IsFindingSessions())
          {
            Netplay.FindSessions();
            break;
          }
          else
            break;
        case MenuMode.WORLD_SIZE:
          this.uiWidth = (sbyte) 1;
          this.uiHeight = (sbyte) 3;
          this.uiCoords = UI.MENU_WORLD_SIZE_COORDS;
          return;
        case MenuMode.STATUS_SCREEN:
        case MenuMode.NETPLAY:
          this.progress = 0.0f;
          this.progressTotal = 0.0f;
          this.uiWidth = (sbyte) 0;
          this.uiHeight = (sbyte) 1;
          this.uiCoords = (Location[]) null;
          this.statusText = (string) null;
          return;
        case MenuMode.OPTIONS:
          this.uiWidth = (sbyte) 1;
          this.uiHeight = (sbyte) 4;
          this.uiCoords = UI.MENU_OPTIONS_COORDS;
          return;
        case MenuMode.SETTINGS:
          this.uiWidth = (sbyte) 1;
          this.uiHeight = (sbyte) 3;
          this.uiCoords = UI.MENU_SETTINGS_COORDS;
          return;
        case MenuMode.VOLUME:
          this.soundUI.UpdateVolumes();
          break;
        case MenuMode.ERROR:
          if (Main.worldGenThread != null)
          {
            Main.worldGenThread.Abort();
            Main.worldGenThread = (Thread) null;
            WorldGen.gen = false;
            break;
          }
          else
            break;
        case MenuMode.CREDITS:
          Credits.Init();
          break;
        case MenuMode.QUIT:
          MessageBox.Show(this.controller, Lang.menu[15], Lang.inter[35], new string[2]
          {
            Lang.menu[105],
            Lang.menu[104]
          }, 0 != 0);
          break;
        case MenuMode.UPSELL:
          UI.theGame.LoadUpsell();
          break;
      }
      this.uiWidth = (sbyte) 0;
      this.uiHeight = (sbyte) 0;
      this.uiCoords = (Location[]) null;
    }

    private void Exit()
    {
      if (UI.numActiveViews == 1)
      {
        if (Main.isTrial)
          this.SetMenu(MenuMode.UPSELL, false, true);
        else
          UI.quit = true;
      }
      else
      {
        this.setPlayer((Player) null);
        this.signedInGamer = (SignedInGamer) null;
        this.menuType = MenuType.MAIN;
        this.menuMode = MenuMode.WELCOME;
        this.selectedMenu = (sbyte) -1;
        this.focusMenu = (sbyte) -1;
        this.uiX = (short) 0;
        this.uiY = (short) 0;
        this.uiPos = new Location[38];
        this.worldFade = 0.0f;
        this.worldFadeTarget = 1f;
        this.isStopping = false;
        if (this.playerStorage == null || Netplay.isJoiningRemoteInvite)
          return;
        ((Collection<IGameComponent>) UI.theGame.Components).Remove((IGameComponent) this.playerStorage);
        this.playerStorage.Dispose();
        this.playerStorage = (StorageDeviceManager) null;
      }
    }

    public void ExitGame()
    {
      Main.isGameStarted = false;
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.view != null && ui.menuType != MenuType.MAIN)
          ui.view.onStopGame();
      }
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.view != null && ui != UI.main)
        {
          if (ui.menuType == MenuType.MAIN)
            ui.Exit();
          else
            ui.StopGame();
        }
      }
      UI.main.StopGame();
    }

    public void StopGame()
    {
      this.CloseInventory();
      this.inventorySection = UI.InventorySection.ITEMS;
      this.hotbarItemNameTime = 210;
      this.quickAccessDisplayTime = 0;
      this.quickAccessUp = (sbyte) -1;
      this.quickAccessDown = (sbyte) -1;
      this.quickAccessLeft = (sbyte) -1;
      this.quickAccessRight = (sbyte) -1;
      this.isStopping = true;
      this.worldFadeTarget = 1f;
      this.statusText = !Main.saveOnExit ? "" : Lang.menu[54];
      if (this.menuMode != MenuMode.ERROR)
        this.SetMenu(MenuMode.STATUS_SCREEN, false, false);
      this.menuType = MenuType.MAIN;
      if (this == UI.main)
      {
        if (Main.saveOnExit)
        {
          Main.saveOnExit = false;
          WorldGen.SaveAndQuit();
        }
        else
        {
          Netplay.disconnect = true;
          this.LoadPlayers();
          if (this.menuMode == MenuMode.ERROR)
            return;
          this.SetMenu(MenuMode.TITLE, false, true);
        }
      }
      else
      {
        if (Main.saveOnExit)
          return;
        this.Exit();
      }
    }

    public void PrepareDraw(int pass)
    {
      if (this.view == null || this.menuType == MenuType.MAIN)
        return;
      UI.current = this;
      this.view.PrepareDraw(pass);
    }

    public void Draw()
    {
      if (this.view == null)
        return;
      UI.current = this;
      this.view.DrawBg(this);
      if (this.menuType != MenuType.MAIN)
      {
        this.view.DrawWorld();
        this.DrawCursor();
        this.view.SetScreenView();
      }
      this.DrawTopLayer();
      if (this.menuType != MenuType.NONE)
        this.DrawMenu();
      else if (Main.tutorialState < Tutorial.THE_END)
        this.DrawTutorial();
      Main.spriteBatch.End();
    }

    private void DrawTopLayer()
    {
      if ((double) this.worldFade < 1.0)
        Main.DrawSolidRect(new Rectangle(-1, -1, (int) this.view.viewWidth, 540), new Color(0.0f, 0.0f, 0.0f, 1f - this.worldFade));
      if ((double) this.worldFade != (double) this.worldFadeTarget)
      {
        if ((double) this.worldFadeTarget < (double) this.worldFade)
        {
          this.worldFade -= 0.03333334f;
          if ((double) this.worldFadeTarget > (double) this.worldFade)
            this.worldFade = this.worldFadeTarget;
        }
        else
        {
          this.worldFade += 0.03333334f;
          if ((double) this.worldFadeTarget < (double) this.worldFade)
            this.worldFade = this.worldFadeTarget;
        }
      }
      if (this.menuType != MenuType.NONE)
        return;
      this.DrawInterface();
      if ((int) this.inventoryMode != 0 || this.player.ghost)
        return;
      this.DrawHud();
    }

    private void DrawTutorial()
    {
      this.DrawDialog(new Vector2((float) ((int) this.view.viewWidth - UI.chatBackTexture.Width >> 1), (float) (540 - this.view.SAFE_AREA_OFFSET_B - 36)), new Color(128, 128, 128, 64), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), Main.tutorialText, (string) null, true);
    }

    private void UpdateMenu()
    {
      MenuMode menuMode = this.menuMode;
      this.numMenuItems = (byte) 0;
      this.menuTop = (short) 250;
      this.menuLeft = this.view != null ? (short) ((int) this.view.viewWidth >> 1) : (short) 480;
      this.menuSpace = (byte) 80;
      this.showPlayer = (sbyte) -1;
      for (int index = 0; index < 14; ++index)
      {
        this.noFocus[index] = false;
        this.blockFocus[index] = false;
        this.menuY[index] = (short) 0;
        this.menuScale[index] = 1f;
      }
      if (this.menuMode == MenuMode.ERROR)
      {
        this.numMenuItems = (byte) 0;
        if (this.IsBackButtonTriggered())
          this.SetMenu(MenuMode.TITLE, false, true);
      }
      else if (this.menuMode == MenuMode.LOAD_FAILED_NO_BACKUP)
      {
        this.numMenuItems = (byte) 1;
        this.menuString[0] = Lang.menu[9];
        this.noFocus[0] = true;
        this.menuTop = (short) 300;
        if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.STATUS_SCREEN)
      {
        this.numMenuItems = (byte) 1;
        this.menuString[0] = this.statusText;
        this.noFocus[0] = true;
        this.menuTop = (short) 175;
        this.tips.Update();
      }
      else if (this.menuMode == MenuMode.NETPLAY)
      {
        this.numMenuItems = (byte) 1;
        this.menuString[0] = this.statusText;
        this.noFocus[0] = true;
        this.menuTop = (short) 175;
        this.tips.Update();
        if (this.IsBackButtonTriggered())
        {
          if (Netplay.sessionThread != null)
            Netplay.disconnect = true;
          this.PrevMenu(-1);
        }
        else if (Netplay.sessionThread == null)
        {
          bool flag = true;
          for (int index = 0; index < 4; ++index)
          {
            UI ui = Main.ui[index];
            if (ui.view != null && ui.menuMode != MenuMode.NETPLAY)
            {
              flag = false;
              break;
            }
          }
          if (flag)
            Netplay.StartClient();
        }
      }
      else if (this.menuMode == MenuMode.WAITING_SCREEN)
      {
        this.numMenuItems = (byte) 1;
        this.menuString[0] = Lang.menu[51];
        this.noFocus[0] = true;
        this.menuTop = (short) 300;
        if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
        else if (Main.isGameStarted && !Main.isGamePaused)
        {
          if (Netplay.session == null)
          {
            this.Exit();
            return;
          }
          else if (((ReadOnlyCollection<NetworkGamer>) Netplay.session.AllGamers).Count < 8)
          {
            int privateGamerSlots = Netplay.session.PrivateGamerSlots;
            if (privateGamerSlots > 0)
            {
              if (Main.netMode != 1)
              {
                --Netplay.session.PrivateGamerSlots;
              }
              else
              {
                NetMessage.CreateMessage0(66);
                NetMessage.SendMessage();
                this.privateSlots = (byte) privateGamerSlots;
                this.SetMenu(MenuMode.WAITING_FOR_PUBLIC_SLOT, false, false);
                return;
              }
            }
            try
            {
              Netplay.session.AddLocalGamer(this.signedInGamer);
              this.SetMenu(MenuMode.WAITING_FOR_PLAYER_ID, false, false);
            }
            catch
            {
              this.Exit();
              return;
            }
          }
          else
            this.menuString[0] = Lang.gen[57];
        }
      }
      else if (this.menuMode == MenuMode.WAITING_FOR_PUBLIC_SLOT)
      {
        this.numMenuItems = (byte) 1;
        this.menuString[0] = Lang.menu[51];
        this.noFocus[0] = true;
        this.menuTop = (short) 300;
        if (Netplay.session.PrivateGamerSlots < (int) this.privateSlots)
        {
          try
          {
            Netplay.session.AddLocalGamer(this.signedInGamer);
            this.SetMenu(MenuMode.WAITING_FOR_PLAYER_ID, false, false);
          }
          catch
          {
            this.Exit();
            return;
          }
        }
        else if (this.IsBackButtonTriggered())
        {
          NetMessage.CreateMessage0(67);
          NetMessage.SendMessage();
          this.PrevMenu(-1);
        }
      }
      else if (this.menuMode == MenuMode.WAITING_FOR_PLAYER_ID)
      {
        this.numMenuItems = (byte) 1;
        this.menuString[0] = Lang.menu[51];
        this.noFocus[0] = true;
        this.menuTop = (short) 300;
        if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.LEADERBOARDS)
      {
        if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
        else
          this.leaderboards.Update();
      }
      else if (this.menuMode == MenuMode.TITLE)
      {
        if (UI.main != this)
        {
          this.Exit();
          return;
        }
        else
        {
          this.menuTop = (short) 172;
          this.menuSpace = (byte) 42;
          this.menuString[0] = Lang.menu[13];
          this.menuString[1] = Lang.menu[89];
          this.menuString[2] = Lang.menu[106];
          this.menuString[3] = Lang.menu[107];
          this.menuString[4] = Lang.menu[108];
          if (!Main.isTrial)
          {
            UI.MENU_TITLE_COORDS[0].X = (short) 480;
            this.menuHC[0] = (byte) 0;
          }
          else
          {
            UI.MENU_TITLE_COORDS[0].X = (short) 0;
            this.menuHC[0] = (byte) 3;
            if ((int) this.uiY == 0)
              this.uiY = (short) 1;
          }
          if (!this.signedInGamer.IsGuest && this.HasOnline())
          {
            UI.MENU_TITLE_COORDS[2].X = (short) 480;
            this.menuHC[2] = (byte) 0;
          }
          else
          {
            UI.MENU_TITLE_COORDS[2].X = (short) 0;
            this.menuHC[2] = (byte) 3;
            if ((int) this.uiY == 2)
              this.uiY = (short) 3;
          }
          if (!this.signedInGamer.IsGuest && !Main.isTrial)
          {
            UI.MENU_TITLE_COORDS[3].X = (short) 480;
            this.menuHC[3] = (byte) 0;
          }
          else
          {
            UI.MENU_TITLE_COORDS[3].X = (short) 0;
            this.menuHC[3] = (byte) 3;
            if ((int) this.uiY == 3)
              this.uiY = (short) 4;
          }
          if (Main.isTrial)
          {
            this.menuString[5] = Lang.menu[109];
            if (this.signedInGamer.Privileges.AllowPurchaseContent)
            {
              UI.MENU_TITLE_COORDS[5].X = (short) 480;
              this.menuHC[5] = (byte) 0;
            }
            else
            {
              UI.MENU_TITLE_COORDS[5].X = (short) 0;
              this.menuHC[5] = (byte) 3;
              if ((int) this.uiY == 5)
                this.uiY = (short) 6;
            }
            this.menuString[6] = Lang.menu[15];
            this.numMenuItems = (byte) 7;
            UI.MENU_TITLE_COORDS[6].X = (short) 480;
          }
          else
          {
            this.menuString[5] = Lang.menu[15];
            this.numMenuItems = (byte) 6;
            UI.MENU_TITLE_COORDS[6].X = (short) 0;
          }
          for (int index = (int) this.numMenuItems - 1; index >= 0; --index)
            this.menuScale[index] = 0.75f;
          if ((int) this.selectedMenu == 0)
          {
            Main.PlaySound(10);
            this.SetMenu(MenuMode.CHARACTER_SELECT, true, false);
            this.ResetPlayerMenuSelection();
          }
          else if ((int) this.selectedMenu == 1)
          {
            Main.PlaySound(10);
            this.SetMenu(MenuMode.STATUS_SCREEN, true, false);
            Main.StartTutorial();
          }
          else if ((int) this.selectedMenu == 2)
          {
            Main.PlaySound(10);
            this.SetMenu(MenuMode.LEADERBOARDS, true, false);
            this.leaderboards.InitializeData();
          }
          else if ((int) this.selectedMenu == 3)
            this.ShowAchievements();
          else if ((int) this.selectedMenu == 4)
          {
            Main.PlaySound(10);
            this.SetMenu(MenuMode.OPTIONS, true, false);
          }
          else if ((int) this.selectedMenu == 5)
          {
            if (Main.isTrial)
            {
              if (!Guide.IsVisible)
              {
                bool flag;
                do
                {
                  flag = false;
                  try
                  {
                    GuideExtensions.ShowMarketplace(this.controller, 6359384554213474305UL);
                  }
                  catch (GuideAlreadyVisibleException ex)
                  {
                    Thread.Sleep(32);
                    flag = true;
                  }
                }
                while (flag);
              }
            }
            else
              this.SetMenu(MenuMode.QUIT, true, false);
          }
          else if ((int) this.selectedMenu == 6)
            this.SetMenu(MenuMode.QUIT, true, false);
          else if (this.IsButtonTriggered(Buttons.X))
          {
            if (this.playerStorage != null)
              this.playerStorage.PromptForDevice();
          }
          else if (this.IsButtonTriggered(Buttons.Y))
            this.ShowParty();
        }
      }
      else if (this.menuMode == MenuMode.PAUSE)
      {
        this.menuString[0] = Lang.menu[112];
        int index1 = 1;
        if (Main.isTrial)
        {
          this.menuString[index1] = Lang.menu[109];
          if (this.signedInGamer.Privileges.AllowPurchaseContent)
          {
            UI.MENU_PAUSE_COORDS[index1].X = (short) 480;
            this.menuHC[index1] = (byte) 0;
          }
          else
          {
            UI.MENU_PAUSE_COORDS[index1].X = (short) 0;
            this.menuHC[index1] = (byte) 3;
            if ((int) this.uiY == index1)
              this.uiY = (short) 0;
          }
          ++index1;
          this.numMenuItems = (byte) 7;
          UI.MENU_PAUSE_COORDS[6].X = (short) 480;
        }
        else
        {
          this.numMenuItems = (byte) 6;
          UI.MENU_PAUSE_COORDS[6].X = (short) 0;
        }
        if (!this.HasOnline())
        {
          UI.MENU_PAUSE_COORDS[index1 + 1].X = (short) 0;
          this.menuHC[index1 + 1] = (byte) 3;
          if ((int) this.uiY == index1 + 1)
            this.uiY = (short) 0;
        }
        else
        {
          UI.MENU_PAUSE_COORDS[index1 + 1].X = (short) 480;
          this.menuHC[index1 + 1] = (byte) 0;
        }
        if (this.signedInGamer.IsGuest || Main.isTrial)
        {
          UI.MENU_PAUSE_COORDS[index1 + 2].X = (short) 0;
          this.menuHC[index1 + 2] = (byte) 3;
          if ((int) this.uiY == index1 + 2)
            this.uiY = (short) 0;
        }
        else
        {
          UI.MENU_PAUSE_COORDS[index1 + 2].X = (short) 480;
          this.menuHC[index1 + 2] = (byte) 0;
        }
        if (WorldGen.saveLock || Main.IsTutorial() || !this.HasPlayerStorage())
        {
          UI.MENU_PAUSE_COORDS[index1 + 3].X = (short) 0;
          this.menuHC[index1 + 3] = (byte) 3;
          if ((int) this.uiY == index1 + 3)
            this.uiY = (short) 0;
        }
        else
        {
          UI.MENU_PAUSE_COORDS[index1 + 3].X = (short) 480;
          this.menuHC[index1 + 3] = (byte) 0;
        }
        if (WorldGen.saveLock)
        {
          UI.MENU_PAUSE_COORDS[index1 + 4].X = (short) 0;
          this.menuHC[index1 + 4] = (byte) 3;
          if ((int) this.uiY == index1 + 4)
            this.uiY = (short) 0;
        }
        else
        {
          UI.MENU_PAUSE_COORDS[index1 + 4].X = (short) 480;
          this.menuHC[index1 + 4] = (byte) 0;
        }
        this.menuString[index1] = Lang.menu[108];
        this.menuString[index1 + 1] = Lang.menu[106];
        this.menuString[index1 + 2] = Lang.menu[107];
        this.menuString[index1 + 3] = Lang.menu[99];
        this.menuString[index1 + 4] = Lang.menu[101];
        for (int index2 = 0; index2 < (int) this.numMenuItems; ++index2)
          this.menuScale[index2] = 0.75f;
        this.menuTop = (short) 200;
        this.menuSpace = (byte) 40;
        if ((int) this.selectedMenu == 0 || this.IsButtonUntriggered(Buttons.Start) || this.IsBackButtonTriggered())
          this.ResumeGame();
        else if (Main.netMode == 1 && this.IsButtonTriggered(Buttons.RightShoulder))
        {
          MessageBox.Show(this.controller, Lang.inter[72], Lang.inter[73], new string[2]
          {
            Lang.menu[105],
            Lang.menu[104]
          }, 0 != 0);
          this.SetMenu(MenuMode.BLACKLIST, true, false);
        }
        else if (index1 > 1 && (int) this.selectedMenu == 1)
        {
          if (!Guide.IsVisible)
          {
            bool flag;
            do
            {
              flag = false;
              try
              {
                GuideExtensions.ShowMarketplace(this.controller, 6359384554213474305UL);
              }
              catch (GuideAlreadyVisibleException ex)
              {
                Thread.Sleep(32);
                flag = true;
              }
            }
            while (flag);
          }
        }
        else if ((int) this.selectedMenu == index1)
        {
          Main.PlaySound(10);
          this.SetMenu(MenuMode.OPTIONS, true, false);
        }
        else if ((int) this.selectedMenu == index1 + 1)
        {
          Main.PlaySound(10);
          this.SetMenu(MenuMode.LEADERBOARDS, true, false);
          this.leaderboards.InitializeData();
        }
        else if ((int) this.selectedMenu == index1 + 2)
          this.ShowAchievements();
        else if ((int) this.selectedMenu == index1 + 3)
        {
          Main.PlaySound(10);
          WorldGen.saveAllWhilePlaying();
        }
        else if ((int) this.selectedMenu == index1 + 4)
        {
          Main.PlaySound(10);
          Main.saveOnExit = !Main.IsTutorial() && this.autoSave && UI.IsStorageEnabledForAnyPlayer();
          if (!Main.saveOnExit && !Main.IsTutorial())
          {
            string[] options;
            if (UI.IsStorageEnabledForAnyPlayer())
              options = new string[3]
              {
                Lang.inter[0],
                Lang.inter[1],
                Lang.inter[2]
              };
            else
              options = new string[2]
              {
                Lang.inter[0],
                Lang.inter[1]
              };
            MessageBox.Show(this.controller, Lang.menu[100], Lang.inter[5], options, false);
          }
          this.SetMenu(MenuMode.EXIT, true, false);
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
              this.PrevMenu(-1);
            else
              Main.saveOnExit = result == 2;
          }
        }
        else
          this.ExitGame();
      }
      else if (this.menuMode == MenuMode.EXIT_UGC_BLOCKED)
      {
        if (MessageBox.IsVisible())
        {
          if (!MessageBox.IsAutoUpdate() && MessageBox.Update())
            Main.saveOnExit = MessageBox.GetResult() != 1;
        }
        else
          this.ExitGame();
      }
      else if (this.menuMode == MenuMode.BLACKLIST)
      {
        if (MessageBox.IsVisible() && !MessageBox.IsAutoUpdate() && MessageBox.Update())
        {
          if (MessageBox.GetResult() <= 0)
          {
            this.PrevMenu(-1);
          }
          else
          {
            this.blacklist.Add(Main.GetWorldId());
            this.SaveSettings();
            this.ExitGame();
          }
        }
      }
      else if (this.menuMode == MenuMode.BLACKLIST_REMOVE)
      {
        if (MessageBox.IsVisible() && !MessageBox.IsAutoUpdate() && MessageBox.Update())
        {
          if (MessageBox.GetResult() <= 0)
          {
            if (this.menuType == MenuType.MAIN)
            {
              this.Exit();
              return;
            }
            else
              this.ExitGame();
          }
          else
          {
            this.blacklist.Remove(Main.GetWorldId());
            this.settingsDirty = true;
            this.PrevMenu(-1);
            if (this.menuType != MenuType.MAIN)
              this.menuType = MenuType.NONE;
            Main.checkWorldId = true;
          }
        }
      }
      else if (this.menuMode == MenuMode.MAP)
      {
        if (this.miniMap.isThreadDone)
        {
          if (this.IsBackButtonTriggered())
          {
            this.miniMap.DestroyMap();
            this.ResumeGame();
          }
          else
            this.miniMap.UpdateMap(this);
        }
      }
      else if (this.menuMode == MenuMode.CHARACTER_SELECT)
      {
        this.menuLeft += (short) 80;
        this.menuTop = (short) 200;
        this.menuSpace = (byte) 40;
        for (int index = 0; index < 5; ++index)
        {
          if (index < (int) this.numLoadPlayers)
          {
            this.menuString[index] = this.loadPlayer[index].characterName;
            this.menuHC[index] = this.loadPlayer[index].difficulty;
            UI.MENU_SELECT_COORDS[index].X = (short) 480;
          }
          else
          {
            this.menuString[index] = (string) null;
            UI.MENU_SELECT_COORDS[index].X = (short) 0;
          }
        }
        if ((int) this.numLoadPlayers == 5)
        {
          this.blockFocus[5] = true;
          this.menuString[5] = (string) null;
          UI.MENU_SELECT_COORDS[5].X = (short) 0;
        }
        else
        {
          this.menuString[5] = Lang.menu[16];
          UI.MENU_SELECT_COORDS[5].X = (short) 480;
        }
        this.numMenuItems = (byte) 6;
        for (int index = 0; index < 6; ++index)
          this.menuScale[index] = 0.8f;
        if (this.IsBackButtonTriggered() && (Netplay.gamersWhoReceivedInvite.Count < 2 || !Netplay.gamersWhoReceivedInvite.Contains(this.signedInGamer)))
        {
          UI.CancelInvite(this.signedInGamer);
          this.SetMenu(MenuMode.TITLE, false, true);
        }
        else if ((int) this.selectedMenu == 5)
        {
          Main.PlaySound(10);
          this.loadPlayer[(int) this.numLoadPlayers] = new Player();
          this.loadPlayer[(int) this.numLoadPlayers].characterName = this.signedInGamer.Gamertag;
          this.loadPlayer[(int) this.numLoadPlayers].inventory[0].SetDefaults("Copper Shortsword");
          this.loadPlayer[(int) this.numLoadPlayers].inventory[0].Prefix(-1);
          this.loadPlayer[(int) this.numLoadPlayers].inventory[1].SetDefaults("Copper Pickaxe");
          this.loadPlayer[(int) this.numLoadPlayers].inventory[1].Prefix(-1);
          this.loadPlayer[(int) this.numLoadPlayers].inventory[2].SetDefaults("Copper Axe");
          this.loadPlayer[(int) this.numLoadPlayers].inventory[2].Prefix(-1);
          this.createCharacterGUI.ApplyDefaultAttributes(this.loadPlayer[(int) this.numLoadPlayers]);
          this.SetMenu(MenuMode.CREATE_CHARACTER, true, false);
        }
        else if ((int) this.selectedMenu >= 0)
        {
          Main.PlaySound(10);
          this.selectedPlayer = this.selectedMenu;
          this.setPlayer(this.loadPlayer[(int) this.selectedPlayer].DeepCopy());
          this.playerPathName = this.loadPlayerPath[(int) this.selectedPlayer];
          if (Netplay.isJoiningRemoteInvite)
          {
            this.SetMenu(MenuMode.NETPLAY, true, false);
            this.statusText = Lang.menu[75];
          }
          else if (this != UI.main)
            this.SetMenu(MenuMode.WAITING_SCREEN, true, false);
          else
            this.SetMenu(MenuMode.WORLD_SELECT, true, false);
        }
        else if ((int) this.focusMenu >= 0 && (int) this.focusMenu < (int) this.numLoadPlayers)
        {
          if (this.IsButtonTriggered(Buttons.X))
          {
            this.selectedPlayer = this.focusMenu;
            Main.PlaySound(10);
            this.SetMenu(MenuMode.CONFIRM_DELETE_CHARACTER, true, false);
          }
          else
            this.showPlayer = this.focusMenu;
        }
      }
      else if (this.menuMode == MenuMode.CREATE_CHARACTER)
        this.createCharacterGUI.Update(this.loadPlayer[(int) this.numLoadPlayers]);
      else if (this.menuMode == MenuMode.CONFIRM_LEAVE_CREATE_CHARACTER)
      {
        this.menuString[0] = Lang.menu[49];
        this.noFocus[0] = true;
        this.menuString[1] = Lang.menu[104];
        this.menuString[2] = Lang.menu[105];
        this.numMenuItems = (byte) 3;
        if ((int) this.selectedMenu == 1)
          this.PrevMenu(-2);
        else if ((int) this.selectedMenu == 2 || this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.NAME_CHARACTER)
      {
        string str = this.GetInputText((UserString) this.loadPlayer[(int) this.numLoadPlayers].characterName, Lang.menu[53], Lang.menu[45], false).text;
        this.numMenuItems = (byte) 0;
        if (this.inputTextEnter)
        {
          if (this.inputTextCanceled || str.Length == 0)
          {
            this.PrevMenu(-1);
          }
          else
          {
            Main.PlaySound(10);
            if (str.Length > 16)
              str = str.Substring(0, 16);
            Player player = this.loadPlayer[(int) this.numLoadPlayers];
            player.characterName = str;
            player.ui = this;
            this.loadPlayerPath[(int) this.numLoadPlayers] = this.nextLoadPlayer();
            player.Save(this.loadPlayerPath[(int) this.numLoadPlayers]);
            this.PrevMenu(-2);
            this.selectedPlayer = this.numLoadPlayers;
            this.showPlayer = this.numLoadPlayers;
            this.uiY = (short) this.numLoadPlayers;
            UI.MENU_SELECT_COORDS[(int) this.uiY].X = (short) 480;
            ++this.numLoadPlayers;
          }
        }
      }
      else if (this.menuMode == MenuMode.CONFIRM_DELETE_CHARACTER)
      {
        this.menuString[0] = Lang.menu[46] + this.loadPlayer[(int) this.selectedPlayer].name + "?";
        this.noFocus[0] = true;
        this.menuString[1] = Lang.menu[104];
        this.menuString[2] = Lang.menu[105];
        this.numMenuItems = (byte) 3;
        if ((int) this.selectedMenu == 2 || this.IsBackButtonTriggered())
          this.PrevMenu(-1);
        else if ((int) this.selectedMenu == 1)
        {
          this.ErasePlayer((int) this.selectedPlayer);
          Main.PlaySound(10);
          this.PrevMenu(-1);
          this.ResetPlayerMenuSelection();
        }
      }
      else if (this.menuMode == MenuMode.WORLD_SELECT)
        WorldSelect.Update();
      else if (this.menuMode == MenuMode.GAME_MODE)
        GameMode.Update();
      else if (this.menuMode == MenuMode.NAME_WORLD)
      {
        string name = this.GetInputText((UserString) Lang.menu[56], Lang.menu[55], Lang.menu[48], false).text;
        this.numMenuItems = (byte) 0;
        if (this.inputTextEnter)
        {
          if (this.inputTextCanceled || name.Length == 0)
          {
            this.PrevMenu(-1);
          }
          else
          {
            if (name.Length > 20)
              name = name.Substring(0, 20);
            this.SetMenu(MenuMode.STATUS_SCREEN, false, false);
            WorldSelect.CreateWorld(name);
          }
        }
      }
      else if (this.menuMode == MenuMode.CONFIRM_DELETE_WORLD)
      {
        this.menuString[0] = Lang.menu[46] + (object) WorldSelect.WorldName() + (string) (object) '?';
        this.noFocus[0] = true;
        this.menuString[1] = Lang.menu[104];
        this.menuString[2] = Lang.menu[105];
        this.numMenuItems = (byte) 3;
        if ((int) this.selectedMenu == 2 || this.IsBackButtonTriggered())
          this.PrevMenu(-1);
        else if ((int) this.selectedMenu == 1)
        {
          WorldSelect.EraseWorld();
          Main.PlaySound(10);
          this.PrevMenu(-1);
        }
      }
      else if (this.menuMode == MenuMode.OPTIONS)
      {
        this.menuTop = (short) 220;
        this.menuSpace = (byte) 57;
        this.menuString[0] = Lang.menu[110];
        this.menuString[1] = Lang.menu[111];
        this.menuString[2] = Lang.menu[14];
        if (this.menuType == MenuType.MAIN)
        {
          this.menuString[3] = Lang.menu[47];
          UI.MENU_OPTIONS_COORDS[3].X = (short) 480;
          this.numMenuItems = (byte) 4;
        }
        else
        {
          UI.MENU_OPTIONS_COORDS[3].X = (short) 0;
          if ((int) this.uiY == 3)
            this.uiY = (short) 0;
          this.numMenuItems = (byte) 3;
        }
        if ((int) this.selectedMenu == 0)
        {
          Main.PlaySound(10);
          this.SetMenu(MenuMode.HOW_TO_PLAY, true, false);
        }
        else if ((int) this.selectedMenu == 1)
        {
          Main.PlaySound(10);
          this.SetMenu(MenuMode.CONTROLS, true, false);
        }
        else if ((int) this.selectedMenu == 2)
        {
          Main.PlaySound(10);
          this.SetMenu(MenuMode.SETTINGS, true, false);
        }
        else if ((int) this.selectedMenu == 3)
        {
          Main.PlaySound(10);
          this.SetMenu(MenuMode.CREDITS, true, false);
        }
        else if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.HOW_TO_PLAY)
      {
        this.howtoUI.Update();
        if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.SHOW_SIGN_IN)
      {
        if (!Guide.IsVisible)
        {
          try
          {
            Guide.ShowSignIn(1, this != UI.main && Main.netMode != 0);
            this.menuMode = MenuMode.SIGN_IN;
          }
          catch (GuideAlreadyVisibleException ex)
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
            using (GamerCollection<SignedInGamer>.GamerCollectionEnumerator enumerator = Gamer.SignedInGamers.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                SignedInGamer current = enumerator.Current;
                if (current.PlayerIndex == this.controller)
                {
                  this.signedInGamer = current;
                  GamerPresenceExtensions.SetPresenceModeString(this.signedInGamer.Presence, "Menu");
                  this.InitPlayerStorage();
                  break;
                }
              }
            }
          }
          if (this.signedInGamer != null)
          {
            if (!this.IsGamerValid())
            {
              MessageBox.Show(this.controller, Lang.menu[5], Lang.inter[43], new string[1]
              {
                Lang.menu[90]
              }, 1 != 0);
              this.menuMode = MenuMode.SIGN_IN_FAILED;
            }
            else if (this.playerStorage == null || this.playerStorage.isDone)
              this.PrevMenu(-1);
          }
          else
            this.menuMode = MenuMode.SIGN_IN_FAILED;
        }
      }
      else if (this.menuMode == MenuMode.CONTROLS)
      {
        this.numMenuItems = (byte) 0;
        if (this.IsButtonTriggered(Buttons.A))
        {
          UI ui = this;
          int num = !ui.alternateGrappleControls ? 1 : 0;
          ui.alternateGrappleControls = num != 0;
          this.UpdateAlternateGrappleControls();
          this.settingsDirty = true;
        }
        else if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.SETTINGS)
      {
        this.menuSpace = (byte) 60;
        this.numMenuItems = (byte) 3;
        if (this == UI.main)
        {
          this.menuString[0] = Lang.menu[65];
          UI.MENU_SETTINGS_COORDS[0].X = (short) 480;
        }
        else
        {
          this.menuString[0] = "";
          UI.MENU_SETTINGS_COORDS[0].X = (short) 0;
          if ((int) this.uiY == 0)
            this.uiY = (short) 1;
        }
        this.menuString[1] = !this.autoSave ? Lang.menu[68] : Lang.menu[67];
        if (this.HasPlayerStorage())
        {
          UI.MENU_SETTINGS_COORDS[1].X = (short) 480;
          this.menuHC[1] = (byte) 0;
        }
        else
        {
          UI.MENU_SETTINGS_COORDS[1].X = (short) 0;
          this.menuHC[1] = (byte) 3;
          if ((int) this.uiY == 1)
            this.uiY = (short) 2;
        }
        this.menuString[2] = !this.showItemText ? Lang.menu[72] : Lang.menu[71];
        if ((int) this.selectedMenu == 2)
        {
          Main.PlaySound(12);
          UI ui = this;
          int num = !ui.showItemText ? 1 : 0;
          ui.showItemText = num != 0;
          this.settingsDirty = true;
        }
        else if ((int) this.selectedMenu == 1)
        {
          Main.PlaySound(12);
          UI ui = this;
          int num = !ui.autoSave ? 1 : 0;
          ui.autoSave = num != 0;
          this.settingsDirty = true;
        }
        else if ((int) this.selectedMenu == 0)
        {
          Main.PlaySound(10);
          this.SetMenu(MenuMode.VOLUME, true, false);
        }
        else if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.VOLUME)
      {
        this.soundUI.Update();
        this.menuTop = (short) 200;
        this.menuSpace = (byte) 60;
        this.numMenuItems = (byte) 1;
        this.menuString[0] = Lang.menu[65];
        this.noFocus[0] = true;
        if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
      }
      else if (this.menuMode == MenuMode.WORLD_SIZE)
      {
        this.menuTop = (short) 190;
        this.menuSpace = (byte) 60;
        this.menuY[1] = (short) 30;
        this.menuY[2] = (short) 30;
        this.menuY[3] = (short) 30;
        this.menuY[4] = (short) 40;
        this.menuString[0] = Lang.menu[91];
        this.noFocus[0] = true;
        this.menuString[1] = Lang.menu[92];
        this.menuString[2] = Lang.menu[93];
        this.menuString[3] = Lang.menu[94];
        this.numMenuItems = (byte) 4;
        if (this.IsBackButtonTriggered())
          this.PrevMenu(-1);
        else if ((int) this.selectedMenu > 0)
        {
          if ((int) this.selectedMenu == 1)
          {
            Main.maxTilesX = (short) 4200;
            Main.maxTilesY = (short) 1200;
          }
          else if ((int) this.selectedMenu == 2)
          {
            Main.maxTilesX = (short) 4620;
            Main.maxTilesY = (short) 1320;
          }
          else
          {
            Main.maxTilesX = (short) 5040;
            Main.maxTilesY = (short) 1440;
          }
          Main.PlaySound(10);
          WorldGen.setWorldSize();
          this.ClearInput();
          this.SetMenu(MenuMode.NAME_WORLD, true, false);
        }
      }
      else if (this.menuMode == MenuMode.QUIT)
      {
        if (!MessageBox.IsAutoUpdate() && MessageBox.Update())
        {
          if (MessageBox.GetResult() <= 0)
          {
            this.PrevMenu(-1);
          }
          else
          {
            this.Exit();
            return;
          }
        }
      }
      else if (this.menuMode == MenuMode.SIGN_IN_FAILED)
      {
        if (!MessageBox.IsVisible())
        {
          if (this == UI.main)
            this.SetMenu(MenuMode.WELCOME, false, true);
          else
            this.Exit();
        }
      }
      else if (this.menuMode == MenuMode.CREDITS)
      {
        this.numMenuItems = (byte) 0;
        Credits.Update();
      }
      else if (this.menuMode == MenuMode.UPSELL)
      {
        this.numMenuItems = (byte) 0;
        if (this.IsBackButtonTriggered())
          this.SetMenu(MenuMode.TITLE, false, true);
        else if (this.IsButtonTriggered(Buttons.A))
          UI.quit = true;
        else if (this.IsButtonTriggered(Buttons.X) && this.signedInGamer.Privileges.AllowPurchaseContent && !Guide.IsVisible)
        {
          bool flag;
          do
          {
            flag = false;
            try
            {
              GuideExtensions.ShowMarketplace(this.controller, 6359384554213474305UL);
            }
            catch (GuideAlreadyVisibleException ex)
            {
              Thread.Sleep(32);
              flag = true;
            }
          }
          while (flag);
        }
      }
      if (this.menuMode != menuMode)
      {
        this.numMenuItems = (byte) 0;
        for (int index = 0; index < 14; ++index)
          this.menuItemScale[index] = 0.8f;
      }
      this.focusMenu = (sbyte) -1;
      this.selectedMenu = (sbyte) -1;
      for (int index = 0; index < (int) this.numMenuItems; ++index)
      {
        if (this.menuString[index] != null && (int) this.mouseY > (int) this.menuTop + (int) this.menuSpace * index + (int) this.menuY[index] && ((double) this.mouseY < (double) ((int) this.menuTop + (int) this.menuSpace * index + (int) this.menuY[index]) + 50.0 * (double) this.menuScale[index] && Main.hasFocus) && (!this.noFocus[index] && !this.blockFocus[index]))
        {
          this.focusMenu = (sbyte) index;
          if ((int) this.oldMenu != (int) this.focusMenu)
            Main.PlaySound(12);
          if (this.menuMode != MenuMode.PAUSE ? this.IsSelectButtonTriggered() : this.IsButtonTriggered(Buttons.A))
            this.selectedMenu = (sbyte) index;
        }
      }
      this.oldMenu = this.focusMenu;
    }

    private void DrawSaveIconMessage()
    {
      this.DrawDialog(new Vector2((float) (960 - UI.chatBackTexture.Width >> 1), 220f), new Color(128, 128, 128, 64), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), UI.saveIconMessage, Lang.menu[3], false);
      SpriteSheet<_sheetSprites>.Draw(642, 480, 304, Color.White, (float) Main.frameCounter * -0.05235988f, 1f);
    }

    private void DrawMenu()
    {
      if (this.menuMode != MenuMode.CONTROLS && this.menuMode != MenuMode.MAP && (this.menuMode != MenuMode.HOW_TO_PLAY && this.menuMode != MenuMode.LEADERBOARDS) && (this.menuMode != MenuMode.WORLD_SELECT && this.menuMode != MenuMode.CREATE_CHARACTER && (this.menuMode != MenuMode.CREDITS && this.menuMode != MenuMode.UPSELL)))
        this.DrawLogo();
      if (UI.saveIconMessageTime > 0)
      {
        if (Guide.IsVisible)
          return;
        --UI.saveIconMessageTime;
        if (this.IsButtonTriggered(Buttons.B))
          UI.saveIconMessageTime = 0;
        this.DrawSaveIconMessage();
        this.DrawControls();
      }
      else
      {
        if (this.menuMode == MenuMode.STATUS_SCREEN || this.menuMode == MenuMode.NETPLAY)
        {
          int num1 = (int) this.menuTop + 100;
          float num2 = this.progress * this.numProgressStepsInv + this.progressTotal;
          if ((double) num2 > 0.0)
          {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = UI.progressBarTexture.Height >> 1;
            rectangle.Width = (int) ((double) UI.progressBarTexture.Width * (double) num2);
            Vector2 vector2 = new Vector2();
            vector2.X = (float) ((int) this.view.viewWidth - UI.progressBarTexture.Width >> 1);
            vector2.Y = (float) num1;
            Main.spriteBatch.Draw(UI.progressBarTexture, vector2, new Rectangle?(rectangle), Color.White);
            rectangle.X = rectangle.Width;
            rectangle.Y = rectangle.Height;
            vector2.X += (float) rectangle.Width;
            rectangle.Width = UI.progressBarTexture.Width - rectangle.Width;
            Main.spriteBatch.Draw(UI.progressBarTexture, vector2, new Rectangle?(rectangle), Color.White);
          }
          this.view.SetScreenViewWideCentered();
          this.tips.Draw();
          this.view.SetScreenView();
        }
        else if (this.menuMode == MenuMode.CONTROLS)
        {
          int num1 = (int) this.view.viewWidth >> 1;
          Main.spriteBatch.Draw(UI.controlsTexture, new Vector2()
          {
            X = (float) (num1 - (UI.controlsTexture.Width >> 1)),
            Y = (float) (540 - UI.controlsTexture.Height >> 1)
          }, Color.White);
          int x1 = (int) this.view.viewWidth - this.view.SAFE_AREA_OFFSET_R - ((int) UI.MeasureString(UI.fontSmall, Lang.inter[24]).X + 60);
          int y1 = 464 - this.view.SAFE_AREA_OFFSET_B;
          this.view.ui.DrawInventoryCursor(x1, y1, 1.0, (int) byte.MaxValue);
          if (this.alternateGrappleControls)
            SpriteSheet<_sheetSprites>.Draw(202, x1 + 10, y1 + 10, Color.White);
          UI.DrawStringLC(UI.fontSmall, Lang.inter[24], x1 + 60, y1 + 26, Color.White);
          ControlDesc[] controlDescArray = Lang.controls();
          for (int index = controlDescArray.Length - 1; index >= 0; --index)
          {
            int num2 = controlDescArray[index].alignment;
            int x2 = (int) controlDescArray[index].X;
            if ((int) this.view.viewWidth > 960)
              x2 += 480;
            int y2 = (int) controlDescArray[index].Y;
            string str = controlDescArray[index].text;
            if (index == 0)
            {
              if (this.alternateGrappleControls)
                str = controlDescArray[9].text;
            }
            else if (index == 5)
              str = !this.alternateGrappleControls ? str + controlDescArray[9].text : str + controlDescArray[0].text;
            Vector2 vector2 = UI.MeasureString(UI.fontSmallOutline, str);
            if (num2 < 2)
            {
              x2 -= (int) vector2.X >> 1;
              if (num2 == 0)
                y2 -= (int) vector2.Y;
            }
            else
            {
              if (num2 == 3)
                x2 -= (int) vector2.X;
              y2 -= (int) vector2.Y >> 1;
            }
            UI.DrawStringLT(UI.fontSmallOutline, str, x2, y2, Color.White);
          }
        }
        else if (this.menuMode == MenuMode.MAP)
        {
          if (Netplay.session != null)
            this.DrawMiniMap();
        }
        else if (this.menuMode == MenuMode.HOW_TO_PLAY)
        {
          this.view.SetScreenViewWideCentered();
          this.howtoUI.Draw();
          this.view.SetScreenView();
        }
        else if (this.menuMode == MenuMode.WORLD_SELECT)
          WorldSelect.Draw(this.view);
        else if (this.menuMode == MenuMode.GAME_MODE)
          GameMode.Draw(this.view);
        else if (this.menuMode == MenuMode.CREATE_CHARACTER)
        {
          this.view.SetScreenViewWideCentered();
          this.createCharacterGUI.Draw(this.view);
          this.view.SetScreenView();
          this.showPlayer = (sbyte) -1;
        }
        else if (this.menuMode == MenuMode.VOLUME)
          this.soundUI.Draw(Main.spriteBatch);
        else if (this.menuMode == MenuMode.WELCOME)
        {
          string text = Lang.menu[52] ?? "";
          SpriteFont spriteFont = UI.fontBig;
          Vector2 origin = spriteFont.MeasureString(text) * 0.5f;
          Vector2 position = new Vector2(480f, 460f);
          float scale = 0.75f * (float) (1.0 + (double) UI.cursorAlpha * 0.100000001490116);
          Color color = new Color((int) UI.cursorColor.A, (int) UI.cursorColor.A, 100, (int) byte.MaxValue);
          Main.spriteBatch.DrawString(spriteFont, text, position, color, 0.0f, origin, scale, SpriteEffects.None, 0.0f);
        }
        else if (this.menuMode == MenuMode.LEADERBOARDS)
        {
          this.view.SetScreenViewWideCentered();
          this.leaderboards.Draw(this.view);
          this.view.SetScreenView();
        }
        else if (this.menuMode == MenuMode.ERROR)
        {
          if (UI.errorCompiledText == null)
            UI.errorCompiledText = new CompiledText(UI.errorDescription, 470, UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
          this.DrawDialog(new Vector2((float) ((int) this.view.viewWidth - UI.chatBackTexture.Width >> 1), 260f), new Color(128, 128, 128, 64), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), UI.errorCompiledText, UI.errorCaption, false);
        }
        else if (this.menuMode == MenuMode.CREDITS)
          Credits.Draw();
        else if (this.menuMode == MenuMode.UPSELL)
          UI.theGame.DrawUpsell();
        for (int index = 0; index < (int) this.numMenuItems; ++index)
        {
          if (this.menuString[index] != null)
          {
            float num = this.menuItemScale[index];
            Color c;
            if ((int) this.menuHC[index] == 3)
              c = new Color(120, 120, 120);
            else if ((int) this.menuHC[index] == 2)
              c = new Color(200, 125, (int) byte.MaxValue);
            else if ((int) this.menuHC[index] == 1)
              c = new Color(125, 125, (int) byte.MaxValue);
            else if (this.noFocus[index])
              c = new Color((int) byte.MaxValue, 200, 62, (int) byte.MaxValue);
            else if (index == (int) this.focusMenu)
            {
              num *= (float) (1.0 + (double) UI.cursorAlpha * 0.100000001490116);
              c = new Color((int) UI.cursorColor.A, (int) UI.cursorColor.A, 100, (int) byte.MaxValue);
            }
            else
              c = new Color(240, 240, 240, 240);
            Vector2 pivot = UI.MeasureString(UI.fontBig, this.menuString[index]);
            pivot.X *= 0.5f;
            pivot.Y *= 0.5f;
            float scale = num * this.menuScale[index];
            Vector2 pos = new Vector2((float) this.menuLeft, (float) ((int) this.menuTop + (int) this.menuSpace * index) + pivot.Y * this.menuScale[index] + (float) this.menuY[index]);
            UI.DrawStringScaled(UI.fontBig, this.menuString[index], pos, c, pivot, scale);
          }
        }
        for (int index = 0; index < 14; ++index)
        {
          if (index == (int) this.focusMenu)
          {
            if ((double) this.menuItemScale[index] < 1.0)
              this.menuItemScale[index] += 0.05f;
            if ((double) this.menuItemScale[index] > 1.0)
              this.menuItemScale[index] = 1f;
          }
          else if ((double) this.menuItemScale[index] > 0.8)
            this.menuItemScale[index] -= 0.05f;
        }
        if ((int) this.showPlayer >= 0)
        {
          Player player = this.loadPlayer[(int) this.showPlayer];
          player.velocity.X = 1f;
          player.PlayerFrame();
          this.DrawPlayer(player, new Vector2(148f, 244f), 4f);
        }
        this.DrawControls();
      }
    }

    private void ResumeGame()
    {
      Main.PlaySound(10);
      this.PrevMenu(-1);
      this.ClearButtonTriggers();
      this.menuType = MenuType.NONE;
      this.worldFadeTarget = 1f;
    }

    public void DrawPlayer(Player player, Vector2 position, float scale)
    {
      Main.spriteBatch.End();
      Vector2 vector2 = player.position;
      player.position.X = (float) this.view.screenPosition.X;
      player.position.Y = (float) this.view.screenPosition.Y;
      Matrix scale1 = Matrix.CreateScale(scale, scale, 1f);
      scale1.M41 = position.X;
      scale1.M42 = position.Y;
      this.view.screenProjection.World = scale1;
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, SamplerState.PointClamp, (DepthStencilState) null, (RasterizerState) null, (Effect) this.view.screenProjection);
      player.Draw(this.view, true, false);
      Main.spriteBatch.End();
      this.view.screenProjection.World = Matrix.Identity;
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.view.screenProjection);
      player.position = vector2;
      player.aabb.X = (int) vector2.X;
      player.aabb.Y = (int) vector2.Y;
    }

    public void DrawPlayerIcon(Player player, Vector2 position, float scale)
    {
      Vector2 vector2_1 = player.position;
      player.position.X = (float) this.view.screenPosition.X;
      player.position.Y = (float) this.view.screenPosition.Y;
      Vector2 vector2_2 = player.velocity;
      player.velocity.X = 0.0f;
      player.velocity.Y = 0.0f;
      Matrix scale1 = Matrix.CreateScale(scale, scale, 1f);
      scale1.M41 = position.X;
      scale1.M42 = position.Y;
      this.view.screenProjection.World = scale1;
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, SamplerState.PointClamp, (DepthStencilState) null, (RasterizerState) null, (Effect) this.view.screenProjection);
      player.Draw(this.view, true, true);
      Main.spriteBatch.End();
      this.view.screenProjection.World = Matrix.Identity;
      player.velocity = vector2_2;
      player.position = vector2_1;
      player.aabb.X = (int) vector2_1.X;
      player.aabb.Y = (int) vector2_1.Y;
    }

    private bool IsGamerValid()
    {
      return (this != UI.main || !this.signedInGamer.IsGuest) && (Main.netMode <= 0 || this.CanPlayOnline());
    }

    private void ShowSignInPortal()
    {
      using (GamerCollection<SignedInGamer>.GamerCollectionEnumerator enumerator = Gamer.SignedInGamers.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          SignedInGamer current = enumerator.Current;
          if (current.PlayerIndex == this.controller)
          {
            this.signedInGamer = current;
            if (this.IsGamerValid())
            {
              GamerPresenceExtensions.SetPresenceModeString(current.Presence, "Menu");
              this.InitPlayerStorage();
              return;
            }
            else
              this.signedInGamer = (SignedInGamer) null;
          }
        }
      }
      this.SetMenu(MenuMode.SHOW_SIGN_IN, true, false);
    }

    private void ShowAchievements()
    {
      if (Guide.IsVisible)
        return;
      Main.PlaySound(10);
      bool flag;
      do
      {
        flag = false;
        try
        {
          GuideExtensions.ShowAchievements(this.controller);
        }
        catch (GuideAlreadyVisibleException ex)
        {
          Thread.Sleep(32);
          flag = true;
        }
      }
      while (flag);
    }

    public void ShowParty()
    {
      if (!this.CanPlayOnline() || Guide.IsVisible)
        return;
      Main.PlaySound(10);
      bool flag;
      do
      {
        flag = false;
        try
        {
          Guide.ShowPartySessions(this.controller);
        }
        catch (GuideAlreadyVisibleException ex)
        {
          Thread.Sleep(32);
          flag = true;
        }
      }
      while (flag);
    }

    private void DrawLogo()
    {
      this.logoRotation += this.logoRotationSpeed * 3E-05f;
      if ((double) this.logoRotation > 0.1)
        this.logoRotationDirection = -1f;
      else if ((double) this.logoRotation < -0.1)
        this.logoRotationDirection = 1f;
      if ((double) this.logoRotationSpeed < 20.0 & (double) this.logoRotationDirection == 1.0)
        ++this.logoRotationSpeed;
      else if ((double) this.logoRotationSpeed > -20.0 & (double) this.logoRotationDirection == -1.0)
        --this.logoRotationSpeed;
      this.logoScale += this.logoScaleSpeed * 1E-05f;
      if ((double) this.logoScale > 1.1)
        this.logoScaleDirection = -1f;
      else if ((double) this.logoScale < 0.9)
        this.logoScaleDirection = 1f;
      if ((double) this.logoScaleSpeed < 50.0 & (double) this.logoScaleDirection == 1.0)
        ++this.logoScaleSpeed;
      else if ((double) this.logoScaleSpeed > -50.0 & (double) this.logoScaleDirection == -1.0)
        --this.logoScaleSpeed;
      Color color1 = new Color((int) this.LogoA, (int) this.LogoA, (int) this.LogoA, (int) this.LogoA);
      Color color2 = new Color((int) this.LogoB, (int) this.LogoB, (int) this.LogoB, (int) this.LogoB);
      float x = this.view != null ? (float) ((int) this.view.viewWidth >> 1) : 480f;
      Main.spriteBatch.Draw(UI.logoTexture, new Vector2(x, 100f), new Rectangle?(new Rectangle(0, 0, UI.logoTexture.Width, UI.logoTexture.Height)), color1, this.logoRotation, new Vector2((float) (UI.logoTexture.Width >> 1), (float) (UI.logoTexture.Height >> 1)), this.logoScale, SpriteEffects.None, 0.0f);
      Main.spriteBatch.Draw(UI.logo2Texture, new Vector2(x, 100f), new Rectangle?(new Rectangle(0, 0, UI.logoTexture.Width, UI.logoTexture.Height)), color2, this.logoRotation, new Vector2((float) (UI.logoTexture.Width >> 1), (float) (UI.logoTexture.Height >> 1)), this.logoScale, SpriteEffects.None, 0.0f);
      if (this.view.time.dayTime)
      {
        this.LogoA += (short) 2;
        if ((int) this.LogoA > (int) byte.MaxValue)
          this.LogoA = (short) byte.MaxValue;
        --this.LogoB;
        if ((int) this.LogoB >= 0)
          return;
        this.LogoB = (short) 0;
      }
      else
      {
        this.LogoB += (short) 2;
        if ((int) this.LogoB > (int) byte.MaxValue)
          this.LogoB = (short) byte.MaxValue;
        --this.LogoA;
        if ((int) this.LogoA >= 0)
          return;
        this.LogoA = (short) 0;
      }
    }

    private void initCharacterSelectCoordinates()
    {
      if ((int) this.numLoadPlayers == 0)
        return;
      for (int index = 0; index < 5; ++index)
        UI.MENU_SELECT_COORDS[index].X = index >= (int) this.numLoadPlayers ? (short) 0 : (short) 480;
    }

    private void DrawControls()
    {
      if (this.menuType == MenuType.NONE)
        return;
      Main.strBuilder.Length = 0;
      if (UI.saveIconMessageTime > 0)
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
      }
      else
      {
        switch (this.menuMode)
        {
          case MenuMode.PAUSE:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
            Main.strBuilder.Append(' ');
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
            if (Main.netMode == 1)
            {
              Main.strBuilder.Append(' ');
              Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BLACKLIST));
              break;
            }
            else
              break;
          case MenuMode.MAP:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.MOVE_MAP));
            Main.strBuilder.Append(' ');
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.ZOOM));
            Main.strBuilder.Append(' ');
            if (this.mapScreenCursorY >= 2)
            {
              if (this.CanViewGamerCard() && Netplay.session != null && this.mapScreenCursorY - 2 < ((ReadOnlyCollection<NetworkGamer>) Netplay.session.AllGamers).Count)
              {
                Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_GAMERCARD));
                Main.strBuilder.Append(' ');
              }
            }
            else if (this.mapScreenCursorX == 0)
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
              if (this.CanCommunicate())
              {
                Main.strBuilder.Append(' ');
                Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INVITE_PLAYER));
              }
              if (this.signedInGamer.PartySize > 1)
              {
                Main.strBuilder.Append(' ');
                Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INVITE_PARTY));
                break;
              }
              else
                break;
            }
            else
              break;
          case MenuMode.WELCOME:
          case MenuMode.STATUS_SCREEN:
            break;
          case MenuMode.TITLE:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
            if (this.playerStorage != null)
            {
              Main.strBuilder.Append(' ');
              Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_STORAGE));
            }
            if (this.CanPlayOnline())
            {
              Main.strBuilder.Append(' ');
              Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SHOW_PARTY));
              break;
            }
            else
              break;
          case MenuMode.CHARACTER_SELECT:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
            if (Netplay.gamersWhoReceivedInvite.Count < 2 || !Netplay.gamersWhoReceivedInvite.Contains(this.signedInGamer))
            {
              Main.strBuilder.Append(' ');
              Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
            }
            if ((int) this.focusMenu < (int) this.numLoadPlayers)
            {
              Main.strBuilder.Append(' ');
              Main.strBuilder.Append(Lang.menu[17]);
              break;
            }
            else
              break;
          case MenuMode.CREATE_CHARACTER:
            this.createCharacterGUI.ControlDescription(Main.strBuilder);
            break;
          case MenuMode.WORLD_SELECT:
            WorldSelect.ControlDescription(Main.strBuilder);
            break;
          case MenuMode.WAITING_SCREEN:
          case MenuMode.NETPLAY:
          case MenuMode.ERROR:
          case MenuMode.LOAD_FAILED_NO_BACKUP:
          case MenuMode.CREDITS:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
            break;
          case MenuMode.CONTROLS:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.TOGGLE_GRAPPLE_MODE));
            Main.strBuilder.Append(' ');
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
            break;
          case MenuMode.VOLUME:
            this.soundUI.ControlDescription(Main.strBuilder);
            break;
          case MenuMode.LEADERBOARDS:
            this.leaderboards.ControlDescription(Main.strBuilder);
            break;
          case MenuMode.HOW_TO_PLAY:
            this.howtoUI.ControlDescription(Main.strBuilder);
            break;
          case MenuMode.UPSELL:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.EXIT));
            Main.strBuilder.Append(' ');
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK_TO_GAME));
            if (this.signedInGamer.Privileges.AllowPurchaseContent)
            {
              Main.strBuilder.Append(' ');
              Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.UNLOCK_FULL_GAME));
              break;
            }
            else
              break;
          default:
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT));
            Main.strBuilder.Append(' ');
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BACK));
            break;
        }
      }
      if (Main.strBuilder.Length <= 0)
        return;
      UI.DrawStringLB(UI.fontSmallOutline, this.view.SAFE_AREA_OFFSET_L, this.view.SAFE_AREA_OFFSET_B);
    }

    private void DrawHud()
    {
      Vector2 pos = new Vector2();
      Color c = new Color(128, 128, 128, 128);
      for (int index = 1; index < (int) this.player.statLifeMax / 20 + 1; ++index)
      {
        int x = (int) this.view.viewWidth - this.view.SAFE_AREA_OFFSET_R - 460 + 26 * (index - 1) + 160 + 11;
        int y = this.view.SAFE_AREA_OFFSET_T;
        if (index > 10)
        {
          x -= 260;
          y += 26;
        }
        SpriteSheet<_sheetSprites>.Draw(436, x, y, c);
        int id = 435;
        if ((int) this.player.statLife < index * 20)
        {
          float num = (float) ((int) this.player.statLife - (index - 1) * 20) / 20f;
          if ((double) num > 0.0)
            id = (double) num >= 0.25 ? ((double) num >= 0.5 ? 432 : 433) : 434;
          else
            continue;
        }
        SpriteSheet<_sheetSprites>.Draw(id, x, y);
      }
      if ((int) this.player.breath < 200)
      {
        for (int index = 1; index < 11; ++index)
        {
          int x = (int) this.view.viewWidth - this.view.SAFE_AREA_OFFSET_R - 460 + 26 * (index - 1) + 160 + 11;
          int y = this.view.SAFE_AREA_OFFSET_T + 52;
          SpriteSheet<_sheetSprites>.Draw(141, x, y, c);
          if ((int) this.player.breath < index * 20)
          {
            float num1 = (float) ((int) this.player.breath - (index - 1) * 20) / 20f;
            if ((double) num1 > 0.0)
            {
              float scaleCenter = (float) ((double) num1 * 0.25 + 0.75);
              int num2 = (int) (30.0 + 225.0 * (double) num1);
              if (num2 < 30)
                num2 = 30;
              c.R = (byte) num2;
              c.G = (byte) num2;
              c.B = (byte) num2;
              c.A = (byte) num2;
              SpriteSheet<_sheetSprites>.DrawScaled(140, x + 11, y + 11, scaleCenter, c);
              c = new Color(128, 128, 128, 128);
            }
          }
          else
            SpriteSheet<_sheetSprites>.Draw(140, x, y);
        }
      }
      if ((int) this.player.statManaMax2 > 0)
      {
        int num1 = (int) this.player.statManaMax2 / 20;
        int x = (int) this.view.viewWidth - this.view.SAFE_AREA_OFFSET_R - 22;
        pos.X = (float) (x + 11);
        c.R = byte.MaxValue;
        c.G = byte.MaxValue;
        c.B = byte.MaxValue;
        c.A = (byte) 229;
        int num2 = 0;
        do
        {
          bool flag = false;
          float scaleCenter = 1f;
          if ((int) this.player.statMana >= (num2 + 1) * 20)
          {
            if ((int) this.player.statMana == (num2 + 1) * 20)
              flag = true;
          }
          else
          {
            float num3 = (float) ((int) this.player.statMana - num2 * 20) / 20f;
            int num4 = (int) (30.0 + 225.0 * (double) num3);
            if (num4 < 30)
              num4 = 30;
            c.R = (byte) num4;
            c.G = (byte) num4;
            c.B = (byte) num4;
            c.A = (byte) ((double) num4 * 0.9);
            scaleCenter = (float) ((double) num3 * 0.25 + 0.5);
            if ((double) scaleCenter < 0.5)
              scaleCenter = 0.5f;
            if ((double) num3 > 0.0)
              flag = true;
          }
          if (flag)
            scaleCenter += UI.cursorScale - 1f;
          int y = this.view.SAFE_AREA_OFFSET_T + 23 * num2;
          pos.Y = (float) (y + 11) + (float) (6.0 - 6.0 * (double) scaleCenter);
          SpriteSheet<_sheetSprites>.Draw(1087, x, y, new Color(128, 128, 128, 128));
          SpriteSheet<_sheetSprites>.DrawScaled(1086, ref pos, c, scaleCenter);
        }
        while (++num2 < num1);
      }
      c = new Color(99, 99, 99, 99);
      for (int index = 0; index < 10; ++index)
      {
        int num1 = (int) this.player.buff[index].Type;
        if (num1 > 0)
        {
          int x = 32 + this.view.SAFE_AREA_OFFSET_L + index * 38;
          int y = 76 + this.view.SAFE_AREA_OFFSET_T;
          int id = 141 + num1;
          if (num1 == 40)
            id += (int) this.player.pet;
          SpriteSheet<_sheetSprites>.Draw(id, x, y, c);
          if (num1 != 28 && num1 != 34 && (num1 != 37 && num1 != 38) && num1 != 40)
          {
            int num2 = (int) this.player.buff[index].Time / 60;
            Main.strBuilder.Length = 0;
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num2 / 60));
            Main.strBuilder.Append(':');
            int num3 = num2 % 60;
            if (num3 < 10)
              Main.strBuilder.Append('0');
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num3));
            UI.DrawStringLT(UI.fontItemStack, x, y + 32, Color.White);
          }
        }
      }
      if (this.npcChatText == null)
      {
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        for (int index = 0; index < 3; ++index)
        {
          Main.strBuilder.Length = 0;
          if (this.player.accCompass && !flag3)
          {
            Main.strBuilder.Append(Lang.menu[95]);
            int num1 = (this.player.aabb.X + 10 >> 3) - (int) Main.maxTilesX >> 2;
            if (num1 > 0)
            {
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num1));
              Main.strBuilder.Append(Lang.menu[96]);
            }
            else if (num1 < 0)
            {
              int num2 = -num1;
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num2));
              Main.strBuilder.Append(Lang.menu[97]);
            }
            else
              Main.strBuilder.Append(Lang.menu[98]);
            flag3 = true;
          }
          else if (this.player.accDepthMeter && !flag2)
          {
            Main.strBuilder.Append(Lang.menu[85]);
            int num1 = (this.player.aabb.Y + 42 >> 3) - Main.worldSurface * 2 >> 2;
            if (num1 > 0)
            {
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num1));
              Main.strBuilder.Append(Lang.menu[86]);
            }
            else if (num1 < 0)
            {
              int num2 = -num1;
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num2));
              Main.strBuilder.Append(Lang.menu[87]);
            }
            else
              Main.strBuilder.Append(Lang.menu[88]);
            flag2 = true;
          }
          else if ((int) this.player.accWatch > 0 && !flag1)
          {
            string str1 = " AM";
            double num1 = (double) Main.gameTime.time;
            if (!Main.gameTime.dayTime)
              num1 += 54000.0;
            double num2 = num1 / 86400.0 * 24.0 - 7.5 - 12.0;
            if (num2 < 0.0)
              num2 += 24.0;
            if (num2 >= 12.0)
              str1 = " PM";
            int num3 = (int) num2;
            int num4 = (int) ((num2 - (double) num3) * 60.0);
            if (num3 > 12)
              num3 -= 12;
            if (num3 == 0)
              num3 = 12;
            string str2;
            if ((int) this.player.accWatch == 1)
              str2 = "00";
            else if ((int) this.player.accWatch == 2)
            {
              str2 = num4 >= 30 ? "30" : "00";
            }
            else
            {
              str2 = ToStringExtensions.ToStringLookup(num4);
              if (num4 < 10)
                str2 = "0" + str2;
            }
            Main.strBuilder.Append(Lang.inter[34]);
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num3));
            Main.strBuilder.Append(':');
            Main.strBuilder.Append(str2);
            Main.strBuilder.Append(str1);
            flag1 = true;
          }
          if (Main.strBuilder.Length > 0)
            UI.DrawStringLT(UI.fontSmallOutline, this.view.SAFE_AREA_OFFSET_L, 110 + 22 * index + 48, UI.mouseTextColor);
        }
      }
      int num5 = (int) this.player.oldSelectedItem;
      int num6 = num5 >= 0 ? num5 : (int) this.player.selectedItem;
      float num7 = UI.numActiveViews > 1 ? 1.25f : 1f;
      int x1 = this.view.SAFE_AREA_OFFSET_L;
      for (int index1 = 0; index1 < 10; ++index1)
      {
        float num1 = this.hotbarScale[index1];
        if (index1 == num6)
        {
          if ((double) num1 < 1.0)
          {
            num1 += 0.05f;
            this.hotbarScale[index1] = num1;
          }
        }
        else if ((double) num1 > 0.75)
        {
          num1 -= 0.05f;
          this.hotbarScale[index1] = num1;
        }
        float scaleTopLeft = num1 * num7;
        int y = (int) ((double) this.view.SAFE_AREA_OFFSET_T + 22.0 * (1.0 - (double) scaleTopLeft));
        int num2 = (int) (65.0 + 180.0 * (double) scaleTopLeft);
        Color itemColor = new Color(num2, num2, num2, num2);
        if (index1 == num6)
        {
          c.R = (byte) 200;
          c.G = (byte) 200;
          c.B = (byte) 200;
          c.A = (byte) 200;
          SpriteSheet<_sheetSprites>.DrawTL(448, x1, y, c, scaleTopLeft);
        }
        else
        {
          c.R = (byte) 100;
          c.G = (byte) 100;
          c.B = (byte) 100;
          c.A = (byte) 100;
          SpriteSheet<_sheetSprites>.DrawTL(451, x1, y, c, scaleTopLeft);
        }
        int index2 = index1 == num5 ? (int) this.player.selectedItem : index1;
        if ((int) this.player.inventory[index2].type > 0 && (int) this.player.inventory[index2].stack > 0)
        {
          UI.inventoryScale = scaleTopLeft;
          this.DrawInventoryItem(ref this.player.inventory[index2], x1, y, itemColor, UI.StackType.HOTBAR);
        }
        x1 += (int) (52.0 * (double) scaleTopLeft) + 4;
      }
      if (this.quickAccessDisplayTime > 0)
      {
        --this.quickAccessDisplayTime;
        this.DrawQuickAccess((int) this.player.selectedItem, this.view.SAFE_AREA_OFFSET_L, 540 - this.view.SAFE_AREA_OFFSET_B - 32 - 128, this.quickAccessDisplayTime < 64 ? this.quickAccessDisplayTime << 2 : (int) byte.MaxValue, UI.StackType.HOTBAR);
      }
      if (this.hotbarItemNameTime > 0)
      {
        --this.hotbarItemNameTime;
        if ((int) this.player.inventory[(int) this.player.selectedItem].type != 0)
        {
          string s = this.player.inventory[(int) this.player.selectedItem].AffixName();
          int num1 = this.hotbarItemNameTime < 64 ? this.hotbarItemNameTime << 2 : (int) byte.MaxValue;
          double num2 = (double) UI.DrawStringCT(UI.fontSmall, s, (int) (216.0 * (double) num7) + this.view.SAFE_AREA_OFFSET_L, this.view.SAFE_AREA_OFFSET_T + (int) (44.0 * (double) num7), new Color(num1, num1, num1, num1));
        }
      }
      this.DrawControlsIngame();
    }

    private void DrawInventoryItem(int itemTexId, int x, int y, Color itemColor)
    {
      int num1 = SpriteSheet<_sheetSprites>.src[itemTexId].Width;
      int num2 = SpriteSheet<_sheetSprites>.src[itemTexId].Height;
      float scaleCenter = (num1 <= num2 ? 41f / (float) num2 : 41f / (float) num1) * UI.inventoryScale;
      if ((double) scaleCenter > 1.25)
        scaleCenter = 1.25f;
      SpriteSheet<_sheetSprites>.DrawScaled(itemTexId, ref new Vector2()
      {
        X = (float) x + 26f * UI.inventoryScale,
        Y = (float) y + 26f * UI.inventoryScale
      }, itemColor, scaleCenter);
    }

    private void DrawInventoryItem(ref Item item, int x, int y, Color itemColor, UI.StackType stackType = UI.StackType.NONE)
    {
      int id = (int) item.type + 451;
      int num1 = SpriteSheet<_sheetSprites>.src[id].Width;
      int num2 = SpriteSheet<_sheetSprites>.src[id].Height;
      float scaleCenter = (num1 <= num2 ? 41f / (float) num2 : 41f / (float) num1) * UI.inventoryScale;
      if ((double) scaleCenter > 1.25)
        scaleCenter = 1.25f;
      Vector2 pos = new Vector2();
      pos.X = (float) x + 26f * UI.inventoryScale;
      pos.Y = (float) y + 26f * UI.inventoryScale;
      SpriteSheet<_sheetSprites>.DrawScaled(id, ref pos, item.GetAlphaInventory(itemColor), scaleCenter);
      if ((int) item.color.PackedValue != 0)
        SpriteSheet<_sheetSprites>.DrawScaled(id, ref pos, item.GetColor(itemColor), scaleCenter);
      if (stackType == UI.StackType.INGREDIENT)
      {
        this.DrawIngredientStack(ref item, x, y, itemColor);
      }
      else
      {
        if (stackType == UI.StackType.NONE)
          return;
        UI.DrawInventoryItemStack(ref item, x, y, ref itemColor);
        if (stackType != UI.StackType.HOTBAR)
          return;
        int num3 = (int) item.useAmmo;
        if (num3 > 0)
        {
          int num4 = 0;
          for (int index = 0; index < 48; ++index)
          {
            if ((int) this.player.inventory[index].ammo == num3)
              num4 += (int) this.player.inventory[index].stack;
          }
          UI.DrawStringScaled(UI.fontItemStack, ToStringExtensions.ToStringLookup(num4), new Vector2((float) (x + UI.FONT_STACK_EXTRA_OFFSET) + 10f * UI.inventoryScale, (float) y + 26f * UI.inventoryScale), itemColor, new Vector2(), UI.inventoryScale + 0.1f);
        }
        else if ((int) item.type == 509)
        {
          int num4 = 0;
          for (int index = 0; index < 48; ++index)
          {
            if ((int) this.player.inventory[index].type == 530)
              num4 += (int) this.player.inventory[index].stack;
          }
          UI.DrawStringScaled(UI.fontItemStack, ToStringExtensions.ToStringLookup(num4), new Vector2((float) (x + UI.FONT_STACK_EXTRA_OFFSET) + 10f * UI.inventoryScale, (float) y + 26f * UI.inventoryScale), itemColor, new Vector2(), UI.inventoryScale + 0.1f);
        }
        if (!item.potion)
          return;
        Color c = item.GetAlphaInventory(itemColor) * ((float) this.player.potionDelay / (float) this.player.potionDelayTime);
        pos.X = (float) x + 26f * UI.inventoryScale;
        pos.Y = (float) y + 26f * UI.inventoryScale;
        SpriteSheet<_sheetSprites>.DrawScaled(204, ref pos, c, UI.inventoryScale);
      }
    }

    private static void DrawInventoryItemStack(ref Item item, int x, int y, ref Color itemColor)
    {
      if ((int) item.stack <= 1)
        return;
      UI.DrawStringScaled(UI.fontItemStack, ToStringExtensions.ToStringLookup(item.stack), new Vector2((float) (x + UI.FONT_STACK_EXTRA_OFFSET) + 10f * UI.inventoryScale, (float) y + 26f * UI.inventoryScale), itemColor, new Vector2(), UI.inventoryScale + 0.1f);
    }

    private void DrawIngredientStack(ref Item item, int x, int y, Color itemColor)
    {
      int num = Math.Min((int) item.stack, this.player.CountInventory((int) item.netID));
      Main.strBuilder.Length = 0;
      Main.strBuilder.Append(ToStringExtensions.ToStringLookup(item.stack));
      if (num < (int) item.stack)
      {
        itemColor.G >>= 1;
        itemColor.B >>= 1;
      }
      UI.DrawStringScaled(UI.fontItemStack, new Vector2((float) (x + UI.FONT_STACK_EXTRA_OFFSET) + 10f * UI.inventoryScale, (float) y + 26f * UI.inventoryScale), itemColor, new Vector2(), UI.inventoryScale - 0.1f);
    }

    public void DrawInterface()
    {
      if (this.showNPCs)
        this.view.DrawNPCHouse();
      Vector2 pos = new Vector2();
      if (this.player.rulerAcc)
        this.view.DrawGrid();
      if (this.signBubble)
      {
        this.signBubble = false;
        int num1 = this.signX - this.view.screenPosition.X;
        int num2 = this.signY - this.view.screenPosition.Y;
        SpriteEffects se = SpriteEffects.None;
        int x;
        if ((double) this.signX > (double) this.player.position.X + 20.0)
        {
          se = SpriteEffects.FlipHorizontally;
          x = num1 - 40;
        }
        else
          x = num1 + 8;
        int y = num2 - 22;
        SpriteSheet<_sheetSprites>.Draw(200, x, y, UI.mouseTextColor, se);
      }
      Main.spriteBatch.End();
      for (int index = 7; index >= 0; --index)
      {
        if ((int) this.myPlayer != index)
        {
          Player player = Main.player[index];
          if ((int) player.active != 0 && !player.dead && !player.aabb.Intersects(this.view.viewArea) && ((int) this.player.team == 0 || (int) player.team == 0 || (int) this.player.team == (int) player.team))
          {
            Vector2 a1 = new Vector2();
            Vector2 a2 = new Vector2();
            a1.X = (float) ((int) this.view.viewWidth >> 1);
            a1.Y = 270f;
            a2.X = (float) (player.aabb.X + 10 - this.view.screenPosition.X);
            a2.Y = (float) (player.aabb.Y + 21 - this.view.screenPosition.Y);
            Vector2 intersection = new Vector2();
            bool flag1 = false;
            int num1 = this.view.SAFE_AREA_OFFSET_L;
            int num2 = (int) this.view.viewWidth - this.view.SAFE_AREA_OFFSET_R - 40;
            int num3 = this.view.SAFE_AREA_OFFSET_T + 20 + 40;
            int num4 = 540 - this.view.SAFE_AREA_OFFSET_B - 40;
            if ((double) a2.X <= (double) num1)
              flag1 = Collision.LineIntersection(ref a1, ref a2, new Vector2((float) num1, (float) num3), new Vector2((float) num1, (float) num4), ref intersection);
            else if ((double) a2.X >= (double) num2)
              flag1 = Collision.LineIntersection(ref a1, ref a2, new Vector2((float) num2, (float) num3), new Vector2((float) num2, (float) num4), ref intersection);
            bool flag2;
            if (!flag1)
            {
              if ((double) a2.Y <= (double) num3)
                flag2 = Collision.LineIntersection(ref a1, ref a2, new Vector2((float) num1, (float) num3), new Vector2((float) num2, (float) num3), ref intersection);
              else if ((double) a2.Y >= (double) num4)
                flag2 = Collision.LineIntersection(ref a1, ref a2, new Vector2((float) num1, (float) num4), new Vector2((float) num2, (float) num4), ref intersection);
            }
            float num5 = (float) this.view.viewWidth * 1.5f / (a2 - a1).Length();
            if ((double) num5 < 0.5)
              num5 = 0.5f;
            Matrix matrix = Matrix.CreateTranslation(-10f, -8f, 0.0f) * Matrix.CreateScale(num5, num5, 1f);
            Vector2 vector2 = player.position;
            player.position.X = (float) this.view.screenPosition.X;
            player.position.Y = (float) this.view.screenPosition.Y;
            this.view.screenProjection.World = matrix * Matrix.CreateTranslation(intersection.X, intersection.Y, 0.0f);
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.view.screenProjection);
            player.Draw(this.view, true, true);
            Main.spriteBatch.End();
            player.position = vector2;
            player.aabb.X = (int) vector2.X;
            player.aabb.Y = (int) vector2.Y;
          }
        }
      }
      this.view.screenProjection.World = Matrix.Identity;
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.view.screenProjection);
      if ((int) this.inventoryMode == 0 && (this.npcChatText != null || (int) this.player.sign != -1))
        this.DrawNpcChat();
      if (this.player.dead)
      {
        this.CloseInventory();
        string s = Lang.inter[38];
        UI.DrawStringCC(UI.fontBig, s, (int) this.view.viewWidth >> 1, 270, this.player.GetDeathAlpha(new Color()));
      }
      else if ((int) this.inventoryMode != 0)
      {
        this.DrawInventoryMenu();
      }
      else
      {
        this.view.SetWorldView();
        Rectangle rectangle1 = new Rectangle(this.player.aabb.X + 10 - 80, this.player.aabb.Y + 21 - 64, 160, 128);
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0 && (int) this.myPlayer != index && !Main.player[index].dead)
          {
            Rectangle rectangle2 = new Rectangle(Main.player[index].aabb.X - 6, Main.player[index].aabb.Y + 42 - 48, 32, 48);
            if (rectangle1.Intersects(rectangle2))
              Main.player[index].DrawInfo(this.view);
          }
        }
        if (!this.player.dead)
        {
          for (int index = 195; index >= 0; --index)
            this.view.drawNpcName[index] = true;
          this.player.npcChatBubble = (short) -1;
          int num1 = 10496;
          Rectangle rectangle2 = new Rectangle();
          Point center1 = rectangle1.Center;
          for (int index = 0; index < 196; ++index)
          {
            NPC npc = Main.npc[index];
            if ((int) npc.active != 0)
            {
              int num2 = (int) npc.type;
              if (num2 != 85 || (double) Main.npc[index].ai0 != 0.0)
              {
                if (num2 >= 87 && num2 <= 92 || num2 >= 159 && num2 <= 164)
                {
                  rectangle2.X = npc.aabb.X + ((int) npc.width >> 1) - 32;
                  rectangle2.Y = npc.aabb.Y + ((int) npc.height >> 1) - 32;
                  rectangle2.Width = 64;
                  rectangle2.Height = 64;
                }
                else
                {
                  int num3 = SpriteSheet<_sheetSprites>.src[1088 + num2].Width;
                  rectangle2.X = npc.aabb.X + ((int) npc.width >> 1) - (num3 >> 1);
                  rectangle2.Y = npc.aabb.Y + (int) npc.height - (int) npc.frameHeight;
                  rectangle2.Width = num3;
                  rectangle2.Height = (int) npc.frameHeight;
                }
                bool result1;
                rectangle1.Intersects(ref rectangle2, out result1);
                if (result1)
                {
                  if (npc.canTalk() && this.player.CanInteractWithNPC())
                  {
                    Point center2 = rectangle2.Center;
                    int num3 = Math.Abs(center1.X - center2.X);
                    if (num3 <= 80)
                    {
                      int num4 = num3 * num3;
                      int num5 = Math.Abs(center1.Y - center2.Y);
                      if (num5 <= 64 && num4 + num5 * num5 < num1)
                      {
                        bool result2;
                        if (this.smartCursor)
                        {
                          result2 = true;
                        }
                        else
                        {
                          center2.X = (int) this.mouseX + this.view.screenPosition.X;
                          center2.Y = (int) this.mouseY + this.view.screenPosition.Y;
                          rectangle2.Contains(ref center2, out result2);
                        }
                        if (result2)
                          this.player.npcChatBubble = (short) index;
                      }
                    }
                  }
                  if ((int) npc.drawMyName < 32)
                    npc.drawMyName = (short) 32;
                }
                if ((int) npc.drawMyName > 0 && this.view.clipArea.Intersects(rectangle2))
                {
                  --npc.drawMyName;
                  npc.DrawInfo(this.view);
                }
              }
            }
          }
          if ((int) this.player.npcChatBubble >= 0)
          {
            NPC npc = Main.npc[(int) this.player.npcChatBubble];
            int num2 = -(((int) npc.width >> 1) + 8);
            SpriteEffects se = SpriteEffects.None;
            if ((int) npc.spriteDirection == -1)
            {
              se = SpriteEffects.FlipHorizontally;
              num2 = -num2;
            }
            pos.X = (float) (npc.aabb.X + ((int) npc.width >> 1) - this.view.screenPosition.X - 16 - num2);
            pos.Y = (float) (npc.aabb.Y - 26 - this.view.screenPosition.Y);
            SpriteSheet<_sheetSprites>.Draw(201, ref pos, UI.mouseTextColor, se);
          }
        }
        this.view.SetScreenView();
      }
    }

    public void ClearInput()
    {
      this.inputTextEnter = false;
      this.inputTextCanceled = false;
    }

    public UserString GetInputText(UserString oldString, string title = null, string desc = null, bool validate = true)
    {
      if (!this.inputTextEnter && oldString.IsEditable())
      {
        if (!Guide.IsVisible)
        {
          try
          {
            this.kbResult = Guide.BeginShowKeyboardInput(this.controller, title, desc, oldString.isCensored ? "" : oldString.text, (AsyncCallback) null, (object) null);
          }
          catch (GuideAlreadyVisibleException ex)
          {
          }
        }
        else if (this.kbResult != null && this.kbResult.IsCompleted)
        {
          this.inputTextEnter = true;
          string str = Guide.EndShowKeyboardInput(this.kbResult);
          this.kbResult = (IAsyncResult) null;
          this.inputTextCanceled = str == null;
          if (!this.inputTextCanceled)
          {
            string s = str.Trim();
            char[] chArray = s.ToCharArray();
            bool flag = false;
            for (int index = chArray.Length - 1; index >= 0; --index)
            {
              if ((int) chArray[index] == 164)
              {
                chArray[index] = 'Ʃ';
                flag = true;
              }
              else if (!UI.fontSmallOutline.get_Characters().Contains(chArray[index]))
              {
                chArray[index] = (int) chArray[index] != 8364 ? '?' : 'Ɛ';
                flag = true;
              }
            }
            if (flag)
              s = new string(chArray);
            if (validate)
              oldString.SetUserString(s);
            else
              oldString.SetSystemString(s);
          }
        }
      }
      return oldString;
    }

    public void FirstProgressStep(int numSteps, string text = null)
    {
      this.progress = 0.0f;
      this.progressTotal = 0.0f;
      this.numProgressStepsInv = 1f / (float) numSteps;
      if (text == null)
        return;
      this.statusText = text;
    }

    public void NextProgressStep(string text = null)
    {
      this.progress = 0.0f;
      this.progressTotal += this.numProgressStepsInv;
      if (text == null)
        return;
      this.statusText = text;
    }

    private static void UpdateCursorColor()
    {
      UI.cursorAlpha = (float) (0.8 + 0.2 * Math.Sin((double) Main.frameCounter * (1.0 / 16.0)));
      double num = (double) UI.cursorAlpha * 0.3 + 0.7;
      UI.cursorColor = new Color((int) (byte) ((double) UI.mouseColor.R * (double) UI.cursorAlpha), (int) (byte) ((double) UI.mouseColor.G * (double) UI.cursorAlpha), (int) (byte) ((double) UI.mouseColor.B * (double) UI.cursorAlpha), (int) (byte) ((double) byte.MaxValue * num));
      UI.cursorScale = (float) (num + 0.1);
    }

    private void UpdateMouse()
    {
      if (this.uiCoords == null)
      {
        int dx = 0;
        int dy = 0;
        int num1 = 3;
        bool flag = (int) this.inventoryMode > 0 || this.menuMode == MenuMode.MAP || this.menuMode == MenuMode.WORLD_SELECT || this.menuMode == MenuMode.GAME_MODE;
        if (flag)
          num1 = 1;
        else if (this.menuType == MenuType.NONE)
        {
          if (this.IsButtonTriggered(Buttons.RightStick))
          {
            UI ui = this;
            int num2 = !ui.smartCursor ? 1 : 0;
            ui.smartCursor = num2 != 0;
          }
          if (this.smartCursor)
          {
            this.player.UpdateMouseSmart();
            return;
          }
          else
          {
            this.player.UpdateMouse();
            return;
          }
        }
        else
        {
          this.uiDelay = (sbyte) 0;
          this.uiDelayValue = (sbyte) 12;
        }
        if (this.menuMode != MenuMode.MAP)
        {
          if ((double) this.gpState.ThumbSticks.Right.X < -0.125)
            dx = -num1;
          else if ((double) this.gpState.ThumbSticks.Right.X > 0.125)
            dx = num1;
          if ((double) this.gpState.ThumbSticks.Right.Y < -0.125)
            dy = num1;
          else if ((double) this.gpState.ThumbSticks.Right.Y > 0.125)
            dy = -num1;
        }
        if (this.menuType != MenuType.NONE || (int) this.inventoryMode > 0)
        {
          if ((double) this.gpState.ThumbSticks.Left.X < -0.125)
            dx = -num1;
          else if ((double) this.gpState.ThumbSticks.Left.X > 0.125)
            dx = num1;
          if ((double) this.gpState.ThumbSticks.Left.Y < -0.125)
            dy = num1;
          else if ((double) this.gpState.ThumbSticks.Left.Y > 0.125)
            dy = -num1;
          if ((int) this.inventoryMode == 0 || this.inventorySection != UI.InventorySection.ITEMS)
          {
            if (this.gpState.DPad.Left == ButtonState.Pressed)
              dx = -num1;
            else if (this.gpState.DPad.Right == ButtonState.Pressed)
              dx = num1;
            if (this.gpState.DPad.Down == ButtonState.Pressed)
              dy = num1;
            else if (this.gpState.DPad.Up == ButtonState.Pressed)
              dy = -num1;
          }
        }
        if ((int) this.uiDelay > 0)
        {
          if (dx == 0 && dy == 0)
          {
            this.uiDelay = (sbyte) 0;
            this.uiDelayValue = (sbyte) 12;
          }
          else
            --this.uiDelay;
        }
        if ((int) this.uiDelay != 0)
          return;
        if (flag)
        {
          if (dx != 0 || dy != 0)
          {
            this.uiDelay = this.uiDelayValue;
            this.uiDelayValue = (sbyte) 6;
          }
          if (this.menuMode == MenuMode.MAP)
            this.PositionMapScreenCursor(dx, dy);
          else if (this.menuMode == MenuMode.WORLD_SELECT)
            WorldSelect.UpdateCursor(dx, dy);
          else if (this.menuMode == MenuMode.GAME_MODE)
          {
            GameMode.UpdateCursor(dx, dy);
          }
          else
          {
            this.UpdateInventoryMenu();
            if (this.inventorySection == UI.InventorySection.CRAFTING)
              this.PositionCraftingCursor(dx, dy);
            else
              this.PositionInventoryCursor(dx, dy);
          }
        }
        else
        {
          if (dx == 0 && dy == 0)
            return;
          this.uiDelay = (sbyte) 4;
          this.mouseX += (short) dx;
          if ((int) this.mouseX < 0)
            this.mouseX = (short) 0;
          else if ((int) this.mouseX > 944)
            this.mouseX = (short) 944;
          this.mouseY += (short) dy;
          if ((int) this.mouseY < 0)
          {
            this.mouseY = (short) 0;
          }
          else
          {
            if ((int) this.mouseY <= 524)
              return;
            this.mouseY = (short) 524;
          }
        }
      }
      else if ((int) this.uiDelay > 0)
      {
        if ((double) this.gpState.ThumbSticks.Left.LengthSquared() <= 1.0 / 64.0 && (double) this.gpState.ThumbSticks.Right.LengthSquared() <= 1.0 / 64.0 && (this.gpState.DPad.Up == ButtonState.Released && this.gpState.DPad.Down == ButtonState.Released) && (this.gpState.DPad.Left == ButtonState.Released && this.gpState.DPad.Right == ButtonState.Released))
        {
          this.uiDelay = (sbyte) 0;
          this.uiDelayValue = (sbyte) 12;
        }
        else
          --this.uiDelay;
      }
      else
      {
        int num1 = this.IsLeftButtonDown() ? -1 : (this.IsRightButtonDown() ? 1 : 0);
        if (num1 < 0)
        {
          if ((int) --this.uiX < 0)
            this.uiX = (short) ((int) this.uiWidth - 1);
          this.uiDelay = this.uiDelayValue;
          this.uiDelayValue = (sbyte) 6;
        }
        else if (num1 > 0)
        {
          if ((int) ++this.uiX == (int) this.uiWidth)
            this.uiX = (short) 0;
          this.uiDelay = this.uiDelayValue;
          this.uiDelayValue = (sbyte) 6;
        }
        int num2 = this.IsDownButtonDown() ? -1 : (this.IsUpButtonDown() ? 1 : 0);
        while (true)
        {
          do
          {
            if (num2 > 0)
            {
              if ((int) --this.uiY < 0)
                this.uiY = (short) ((int) this.uiHeight - 1);
              this.uiDelay = this.uiDelayValue;
              this.uiDelayValue = (sbyte) 6;
            }
            else if (num2 < 0)
            {
              if ((int) ++this.uiY == (int) this.uiHeight)
                this.uiY = (short) 0;
              this.uiDelay = this.uiDelayValue;
              this.uiDelayValue = (sbyte) 6;
            }
            this.mouseX = this.uiCoords[(int) this.uiX + (int) this.uiY * (int) this.uiWidth].X;
            if ((int) this.mouseX != 0)
              goto label_87;
          }
          while (num2 != 0 || (int) ++this.uiY < (int) this.uiHeight);
          this.uiY = (short) 0;
        }
label_87:
        this.mouseY = this.uiCoords[(int) this.uiX + (int) this.uiY * (int) this.uiWidth].Y;
      }
    }

    public static void UpdateOnce()
    {
      UI.UpdateCursorColor();
      UI.mouseTextBrightness += (byte) UI.mouseTextColorChange;
      if ((int) UI.mouseTextBrightness <= 175 || (int) UI.mouseTextBrightness >= 250)
        UI.mouseTextColorChange = -UI.mouseTextColorChange;
      UI.mouseTextColor.R = UI.mouseTextBrightness;
      UI.mouseTextColor.G = UI.mouseTextBrightness;
      UI.mouseTextColor.B = UI.mouseTextBrightness;
      UI.mouseTextColor.A = UI.mouseTextBrightness;
      UI.invAlpha += (byte) UI.invDir;
      if ((int) UI.invAlpha > 240)
      {
        UI.invAlpha = (byte) 240;
        UI.invDir = -UI.invDir;
      }
      else if ((int) UI.invAlpha < 180)
      {
        UI.invAlpha = (byte) 180;
        UI.invDir = -UI.invDir;
      }
      UI.essScale += UI.essDir;
      if ((double) UI.essScale > 1.0)
      {
        UI.essScale = 1f;
        UI.essDir = -UI.essDir;
      }
      else if ((double) UI.essScale < 0.699999988079071)
      {
        UI.essScale = 0.7f;
        UI.essDir = -UI.essDir;
      }
      UI.blueWave += UI.blueDelta;
      if ((double) UI.blueWave > 1.0)
      {
        UI.blueWave = 1f;
        UI.blueDelta = -UI.blueDelta;
      }
      else if ((double) UI.blueWave < 0.970000028610229)
      {
        UI.blueWave = 0.97f;
        UI.blueDelta = -UI.blueDelta;
      }
      if (!MessageBox.current.autoUpdate)
        return;
      MessageBox.Update();
    }

    public void UpdateGamePad()
    {
      if (Main.hasFocus)
      {
        this.gpPrevState = this.gpState;
        this.gpState = GamePad.GetState(this.controller);
      }
      else
      {
        UI ui1 = this;
        UI ui2 = this;
        UI ui3 = this;
        GamePadState gamePadState1 = new GamePadState();
        GamePadState gamePadState2 = gamePadState1;
        ui3.gpState = gamePadState2;
        GamePadState gamePadState3;
        GamePadState gamePadState4 = gamePadState3 = gamePadState1;
        ui2.gpState = gamePadState3;
        GamePadState gamePadState5 = gamePadState4;
        ui1.gpPrevState = gamePadState5;
      }
    }

    public void Update()
    {
      if (UI.main.menuMode == MenuMode.WELCOME)
      {
        if (this.IsSelectButtonTriggered())
        {
          this.ClearButtonTriggers();
          this.OpenMainView((SignedInGamer) null);
        }
      }
      else if (this.view == null)
      {
        if (!Main.isGameStarted || !this.IsSelectButtonTriggered() || Main.IsTutorial() || Netplay.session != null && ((ReadOnlyCollection<NetworkGamer>) Netplay.session.AllGamers).Count == 8)
          return;
        this.ClearButtonTriggers();
        this.SetMenu(MenuMode.CHARACTER_SELECT, false, true);
        this.OpenView();
        return;
      }
      UI.current = this;
      if (this.menuType == MenuType.NONE)
      {
        if (this.IsButtonUntriggered(Buttons.Start))
        {
          Main.PlaySound(10);
          this.uiFade = 0.0f;
          this.uiFadeTarget = 1f;
          this.menuType = MenuType.PAUSE;
          this.SetMenu(MenuMode.PAUSE, true, false);
          this.ClearButtonTriggers();
        }
        else if (this.IsButtonTriggered(Buttons.Back))
        {
          this.miniMap.CreateMap(this);
          Main.PlaySound(10);
          if (Main.netMode == 1)
          {
            NetMessage.CreateMessage0(11);
            NetMessage.SendMessage();
          }
          this.SetMenu(MenuMode.MAP, true, false);
          this.menuType = MenuType.PAUSE;
          this.ClearButtonTriggers();
        }
      }
      else
      {
        if (this.transferredPlayerStorage.Count > 0 && !MessageBox.IsVisible())
          this.DeleteTransferredPlayerStorage();
        if (UI.saveIconMessageTime <= 0)
          this.UpdateMenu();
      }
      if (this.menuType != MenuType.MAIN)
        this.UpdateIngame();
      if ((int) this.teamCooldown > 0 && ((int) --this.teamCooldown == 0 && (int) this.teamSelected != (int) this.player.team))
      {
        this.player.team = this.teamSelected;
        NetMessage.CreateMessage1(45, (int) this.myPlayer);
        NetMessage.SendMessage();
      }
      if ((int) this.pvpCooldown > 0 && ((int) --this.pvpCooldown == 0 && this.pvpSelected != this.player.hostile))
      {
        this.player.hostile = this.pvpSelected;
        NetMessage.CreateMessage1(30, (int) this.myPlayer);
        NetMessage.SendMessage();
      }
      this.UpdateMouse();
      if (this.signedInGamer == null || this.signedInGamer.IsGuest || Main.isTrial)
        return;
      this.UpdateAchievements();
    }

    private void UpdateIngame()
    {
      if (this.editSign)
        this.player.UpdateEditSign();
      if (this.autoSave && Main.tutorialState == Tutorial.NUM_TUTORIALS && this.HasPlayerStorage())
      {
        if (!this.saveTime.get_IsRunning())
          this.saveTime.Start();
        else if (this.saveTime.get_ElapsedMilliseconds() > 600000L)
        {
          this.saveTime.Reset();
          if (Main.netMode == 1 || UI.main != this)
            WorldGen.savePlayerWhilePlaying();
          else
            WorldGen.saveAllWhilePlaying();
        }
      }
      else if (this.saveTime.get_IsRunning())
        this.saveTime.Stop();
      this.view.itemTextLocal.Update();
      this.view.dustLocal.UpdateDust();
      this.view.spawnSnow();
    }

    private void OpenMainView(SignedInGamer gamer = null)
    {
      if (UI.main != this)
      {
        this.view = UI.main.view;
        this.view.ui = this;
        this.view.player = this.player;
        UI.main.view = (WorldView) null;
        UI.main = this;
        Main.musicVolume = this.musicVolume;
        Main.soundVolume = this.soundVolume;
      }
      this.signedInGamer = gamer;
      this.SetMenu(MenuMode.TITLE, true, false);
      if (gamer == null)
        this.ShowSignInPortal();
      else
        this.InitPlayerStorage();
    }

    private void OpenView()
    {
      this.CheckHDTV();
      MessageBox.Update();
      for (int index = 0; index < 4; ++index)
      {
        UI ui = Main.ui[index];
        if (ui.view != null)
          ui.setView(WorldView.getViewType(ui.controller, this), true);
      }
      this.setView(WorldView.getViewType(this.controller, this), true);
      this.ShowSignInPortal();
    }

    public void ClearButtonTriggers()
    {
      this.gpPrevState = this.gpState;
    }

    public bool IsBackButtonTriggered()
    {
      if (this.gpState.IsButtonDown(Buttons.Back) && this.gpPrevState.IsButtonUp(Buttons.Back))
        return true;
      if (this.gpState.IsButtonDown(Buttons.B))
        return this.gpPrevState.IsButtonUp(Buttons.B);
      else
        return false;
    }

    public bool IsSelectButtonTriggered()
    {
      if (this.gpState.IsButtonDown(Buttons.Start) && this.gpPrevState.IsButtonUp(Buttons.Start))
        return true;
      if (this.gpState.IsButtonDown(Buttons.A))
        return this.gpPrevState.IsButtonUp(Buttons.A);
      else
        return false;
    }

    public bool IsLeftButtonDown()
    {
      if (!this.gpState.IsButtonDown(Buttons.DPadLeft) && (double) this.gpState.ThumbSticks.Left.X >= -0.125)
        return (double) this.gpState.ThumbSticks.Right.X < -0.125;
      else
        return true;
    }

    public bool IsRightButtonDown()
    {
      if (!this.gpState.IsButtonDown(Buttons.DPadRight) && (double) this.gpState.ThumbSticks.Left.X <= 0.125)
        return (double) this.gpState.ThumbSticks.Right.X > 0.125;
      else
        return true;
    }

    public bool IsUpButtonDown()
    {
      if (!this.gpState.IsButtonDown(Buttons.DPadUp) && (double) this.gpState.ThumbSticks.Left.Y <= 0.125)
        return (double) this.gpState.ThumbSticks.Right.Y > 0.125;
      else
        return true;
    }

    public bool IsDownButtonDown()
    {
      if (!this.gpState.IsButtonDown(Buttons.DPadDown) && (double) this.gpState.ThumbSticks.Left.Y >= -0.125)
        return (double) this.gpState.ThumbSticks.Right.Y < -0.125;
      else
        return true;
    }

    public bool IsAlternateLeftButtonDown()
    {
      return (double) this.gpState.ThumbSticks.Right.X < -0.125;
    }

    public bool IsAlternateRightButtonDown()
    {
      return (double) this.gpState.ThumbSticks.Right.X > 0.125;
    }

    public bool IsAlternateUpButtonDown()
    {
      return (double) this.gpState.ThumbSticks.Right.Y > 0.125;
    }

    public bool IsAlternateDownButtonDown()
    {
      return (double) this.gpState.ThumbSticks.Right.Y < -0.125;
    }

    public bool IsLeftButtonTriggered()
    {
      if (this.gpState.IsButtonDown(Buttons.DPadLeft) && this.gpPrevState.IsButtonUp(Buttons.DPadLeft))
        return true;
      if ((double) this.gpState.ThumbSticks.Left.X < -0.125)
        return (double) this.gpPrevState.ThumbSticks.Left.X >= -0.125;
      else
        return false;
    }

    public bool IsRightButtonTriggered()
    {
      if (this.gpState.IsButtonDown(Buttons.DPadRight) && this.gpPrevState.IsButtonUp(Buttons.DPadRight))
        return true;
      if ((double) this.gpState.ThumbSticks.Left.X > 0.125)
        return (double) this.gpPrevState.ThumbSticks.Left.X <= 0.125;
      else
        return false;
    }

    public bool IsButtonDown(Buttons b)
    {
      return this.gpState.IsButtonDown(b);
    }

    public bool IsButtonTriggered(Buttons b)
    {
      if (this.gpState.IsButtonDown(b))
        return this.gpPrevState.IsButtonUp(b);
      else
        return false;
    }

    public bool IsButtonUntriggered(Buttons b)
    {
      if (this.gpState.IsButtonUp(b))
        return this.gpPrevState.IsButtonDown(b);
      else
        return false;
    }

    private void DrawCursor()
    {
      if (this.menuType != MenuType.NONE || (int) this.inventoryMode != 0 || (this.npcChatText != null || this.player.dead))
        return;
      bool flag = (int) this.player.inventory[(int) this.player.selectedItem].pick > 0 || (int) this.player.inventory[(int) this.player.selectedItem].axe > 0 || ((int) this.player.inventory[(int) this.player.selectedItem].hammer > 0 || (int) this.player.inventory[(int) this.player.selectedItem].createTile >= 0) || (int) this.player.inventory[(int) this.player.selectedItem].createWall >= 0;
      if (this.cursorHighlight > 0)
      {
        int num1 = 16 - (this.view.screenPosition.X & 15) & 15;
        int x = ((int) this.mouseX - num1 & -16) + num1;
        int num2 = 16 - (this.view.screenPosition.Y & 15) & 15;
        int y = ((int) this.mouseY - num2 & -16) + num2;
        Main.DrawRect(new Rectangle(x, y, 16, 16), new Color(this.cursorHighlight << 1, this.cursorHighlight << 1, 0, this.cursorHighlight << 1), true);
      }
      if (flag && (double) this.player.velocity.X == 0.0 && (double) this.player.velocity.Y == 0.0)
      {
        if (this.cursorHighlight < 64)
          this.cursorHighlight += 4;
      }
      else if (this.cursorHighlight > 0)
        this.cursorHighlight -= 2;
      Rectangle rectangle = new Rectangle();
      rectangle.Y = (int) Main.frameCounter & 16;
      rectangle.Width = 16;
      rectangle.Height = 16;
      Vector2 vector2 = new Vector2();
      if (!this.smartCursor)
      {
        rectangle.X = 16;
        vector2.X = (float) ((int) this.mouseX - 8);
        vector2.Y = (float) ((int) this.mouseY - 8);
      }
      else
      {
        if ((double) this.player.controlDir.LengthSquared() <= 576.0)
          return;
        vector2.X = (float) (this.player.aabb.X + 10 - this.view.screenPosition.X + (int) this.player.controlDir.X - 8);
        vector2.Y = (float) (this.player.aabb.Y + 21 - this.view.screenPosition.Y + (int) this.player.controlDir.Y - 8);
      }
      Main.spriteBatch.Draw(UI.cursorTexture, vector2, new Rectangle?(rectangle), Color.White);
    }

    public void DrawInventoryCursor(int x, int y, double scale, int alpha = 255)
    {
      alpha = (int) UI.mouseTextBrightness * alpha >> 8;
      SpriteSheet<_sheetSprites>.DrawTL(448, x, y, new Color(alpha, alpha, alpha, alpha), (float) scale);
      this.mouseX = (short) x;
      this.mouseY = (short) y;
    }

    public static bool IsStorageEnabledForAnyPlayer()
    {
      if (Main.isTrial)
        return false;
      for (int index = 0; index < 4; ++index)
      {
        if (Main.ui[index].HasPlayerStorage())
          return true;
      }
      return false;
    }

    public void CheckPlayerStorage(string name)
    {
      bool flag;
      IAsyncResult asyncResult = StorageDeviceExtensions.BeginOpenContainer(this.playerStorage.Device, name, true, ref flag, (AsyncCallback) null, (object) null);
      asyncResult.AsyncWaitHandle.WaitOne();
      StorageContainer storageContainer = this.playerStorage.Device.EndOpenContainer(asyncResult);
      asyncResult.AsyncWaitHandle.Close();
      if (flag)
      {
        if (storageContainer.GetFileNames().Length == 0)
        {
          Main.ShowSaveIcon();
          Main.HideSaveIcon();
        }
        else
        {
          MessageBox.Show(this.controller, Lang.menu[9], string.Format(Lang.inter[78], (object) name), new string[1]
          {
            Lang.menu[90]
          }, 1 != 0);
          this.transferredPlayerStorage.Add(name);
        }
      }
      storageContainer.Dispose();
    }

    public void DeleteTransferredPlayerStorage()
    {
      for (int index = this.transferredPlayerStorage.Count - 1; index >= 0; --index)
        this.playerStorage.Device.DeleteContainer(this.transferredPlayerStorage[index]);
      this.transferredPlayerStorage.Clear();
      this.DeviceSelected((object) null, (EventArgs) null);
    }

    public StorageContainer OpenPlayerStorage(string name)
    {
      IAsyncResult asyncResult = this.playerStorage.Device.BeginOpenContainer(name, (AsyncCallback) null, (object) null);
      asyncResult.AsyncWaitHandle.WaitOne();
      StorageContainer storageContainer = this.playerStorage.Device.EndOpenContainer(asyncResult);
      asyncResult.AsyncWaitHandle.Close();
      return storageContainer;
    }

    private void DeviceDisconnected(object sender, EventArgs args)
    {
      this.LoadPlayers();
      WorldSelect.LoadWorlds();
      MessageBox.Show(this.controller, Lang.menu[69], Lang.menu[70], new string[1]
      {
        Lang.menu[90]
      }, 1 != 0);
      if (this.menuMode != MenuMode.CONFIRM_DELETE_CHARACTER && this.menuMode != MenuMode.CONFIRM_DELETE_WORLD)
        return;
      this.PrevMenu(-1);
    }

    private void DeviceSelectorCanceled(object sender, EventArgs args)
    {
      this.LoadPlayers();
      WorldSelect.LoadWorlds();
      MessageBox.Show(this.controller, Lang.menu[69], Lang.menu[66], new string[1]
      {
        Lang.menu[90]
      }, 1 != 0);
    }

    private void DeviceSelected(object sender, EventArgs e)
    {
      try
      {
        this.CheckPlayerStorage("Settings");
        this.CheckPlayerStorage("Characters");
        this.CheckPlayerStorage("Worlds");
      }
      catch (Exception ex)
      {
        this.transferredPlayerStorage.Clear();
        return;
      }
      if (this.transferredPlayerStorage.Count > 0)
        return;
      if (!this.OpenSettings())
        MessageBox.Show(this.controller, Lang.menu[9], Lang.menu[102], new string[1]
        {
          Lang.menu[90]
        }, 1 != 0);
      this.LoadPlayers();
      if (this != UI.main || WorldSelect.LoadWorlds())
        return;
      MessageBox.Show(this.controller, Lang.menu[9], Lang.menu[103], new string[1]
      {
        Lang.menu[90]
      }, 1 != 0);
    }

    public void LoadPlayers()
    {
      if (this.HasPlayerStorage())
      {
        try
        {
          StorageContainer c = this.OpenPlayerStorage("Characters");
label_2:
          try
          {
            string[] fileNames = c.GetFileNames("player?.plr");
            int num = fileNames.Length;
            if (num > 5)
              num = 5;
            for (int index = 0; index < 5; ++index)
            {
              if (index < num)
              {
                this.loadPlayerPath[index] = fileNames[index];
                this.loadPlayer[index].Load(c, this.loadPlayerPath[index]);
                if (this.loadPlayer[index].name == null)
                {
                  MessageBox.Show(this.controller, Lang.menu[9], Lang.menu[12], new string[1]
                  {
                    Lang.menu[90]
                  }, 1 != 0);
                  goto label_2;
                }
              }
              else
                this.loadPlayer[index] = new Player();
            }
            this.numLoadPlayers = (sbyte) num;
          }
          finally
          {
            if (c != null)
              ((IDisposable) c).Dispose();
          }
        }
        catch (IOException ex)
        {
          this.ReadError();
          this.numLoadPlayers = (sbyte) 0;
        }
        catch (Exception ex)
        {
          this.numLoadPlayers = (sbyte) 0;
        }
      }
      else
        this.numLoadPlayers = (sbyte) 0;
      if (this.menuMode != MenuMode.CHARACTER_SELECT)
        return;
      this.ResetPlayerMenuSelection();
    }

    public void SaveSettings()
    {
      if (!this.HasPlayerStorage())
        return;
      using (MemoryStream memoryStream = new MemoryStream(512))
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream))
        {
          binaryWriter.Write(5);
          binaryWriter.Write(0U);
          binaryWriter.Write(this.soundVolume);
          binaryWriter.Write(this.musicVolume);
          binaryWriter.Write(this.autoSave);
          binaryWriter.Write(this.showItemText);
          binaryWriter.Write(this.alternateGrappleControls);
          byte[] buffer1 = this.Statistics.Serialize();
          binaryWriter.Write(buffer1);
          binaryWriter.Write(this.totalSteps);
          binaryWriter.Write(this.totalPicked);
          binaryWriter.Write(this.totalBarsCrafted);
          binaryWriter.Write(this.totalAnvilCrafting);
          binaryWriter.Write(this.totalWires);
          binaryWriter.Write(this.totalAirTime);
          binaryWriter.Write(this.petSpawnMask);
          int count = this.armorFound.Length + 7 >> 3;
          byte[] buffer2 = new byte[count];
          this.armorFound.CopyTo((Array) buffer2, 0);
          binaryWriter.Write((ushort) count);
          binaryWriter.Write(buffer2, 0, count);
          binaryWriter.Write(this.isOnline);
          binaryWriter.Write(this.isInviteOnly);
          int num1 = this.blacklist.Count;
          int num2 = num1;
          if (num1 > (int) ushort.MaxValue)
            num1 = (int) ushort.MaxValue;
          binaryWriter.Write((ushort) num1);
          for (int index = num2 - num1; index < num2; ++index)
            binaryWriter.Write(this.blacklist[index]);
          CRC32 crC32 = new CRC32();
          crC32.Update(memoryStream.GetBuffer(), 8, (int) memoryStream.Length - 8);
          binaryWriter.Seek(4, SeekOrigin.Begin);
          binaryWriter.Write(crC32.GetValue());
          Main.ShowSaveIcon();
          try
          {
            if (this.TestStorageSpace("Settings", "config.dat", (int) memoryStream.Length))
            {
              using (StorageContainer storageContainer = this.OpenPlayerStorage("Settings"))
              {
                using (Stream stream = storageContainer.OpenFile("config.dat", FileMode.Create))
                {
                  stream.Write(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
                  stream.Close();
                }
                this.settingsDirty = false;
              }
            }
          }
          catch (IOException ex)
          {
            this.WriteError();
          }
          catch (Exception ex)
          {
          }
          binaryWriter.Close();
          Main.HideSaveIcon();
        }
      }
    }

    private bool OpenSettings()
    {
      bool flag = true;
      try
      {
        using (StorageContainer storageContainer = this.OpenPlayerStorage("Settings"))
        {
          if (storageContainer.FileExists("config.dat"))
          {
            try
            {
              using (Stream stream = storageContainer.OpenFile("config.dat", FileMode.Open))
              {
                using (MemoryStream memoryStream = new MemoryStream((int) stream.Length))
                {
                  memoryStream.SetLength(stream.Length);
                  stream.Read(memoryStream.GetBuffer(), 0, (int) stream.Length);
                  stream.Close();
                  using (BinaryReader binaryReader = new BinaryReader((Stream) memoryStream))
                  {
                    int num1 = binaryReader.ReadInt32();
                    if (num1 > 5)
                      throw new InvalidOperationException("Invalid version");
                    if (num1 >= 4)
                    {
                      CRC32 crC32 = new CRC32();
                      crC32.Update(memoryStream.GetBuffer(), 8, (int) memoryStream.Length - 8);
                      if ((int) crC32.GetValue() != (int) binaryReader.ReadUInt32())
                        throw new InvalidOperationException("Invalid CRC32");
                    }
                    this.soundVolume = binaryReader.ReadSingle();
                    this.musicVolume = binaryReader.ReadSingle();
                    this.autoSave = binaryReader.ReadBoolean();
                    this.showItemText = binaryReader.ReadBoolean();
                    this.alternateGrappleControls = binaryReader.ReadBoolean();
                    if (num1 <= 3)
                      this.alternateGrappleControls = false;
                    this.UpdateAlternateGrappleControls();
                    if (this == UI.main)
                    {
                      Main.musicVolume = this.musicVolume;
                      Main.soundVolume = this.soundVolume;
                    }
                    int count1 = Statistics.CalculateSerialisationSize();
                    this.Statistics.Deserialize(binaryReader.ReadBytes(count1));
                    if (num1 >= 2)
                    {
                      if (num1 >= 3)
                      {
                        this.totalSteps = binaryReader.ReadUInt32();
                        this.totalPicked = binaryReader.ReadUInt32();
                        this.totalBarsCrafted = binaryReader.ReadUInt32();
                        this.totalAnvilCrafting = binaryReader.ReadUInt32();
                        this.totalWires = binaryReader.ReadUInt32();
                        this.totalAirTime = binaryReader.ReadUInt32();
                        this.petSpawnMask = binaryReader.ReadByte();
                        int count2 = (int) binaryReader.ReadUInt16();
                        this.armorFound = new BitArray(binaryReader.ReadBytes(count2));
                        if (this.armorFound.Length < 632)
                          this.armorFound.Length = 632;
                      }
                      this.isOnline = binaryReader.ReadBoolean();
                      this.isInviteOnly = binaryReader.ReadBoolean();
                    }
                    this.blacklist.Clear();
                    if (num1 >= 5)
                    {
                      int num2 = (int) binaryReader.ReadUInt16();
                      this.blacklist.Capacity = num2 + 4;
                      for (; num2 > 0; --num2)
                        this.blacklist.Add(binaryReader.ReadUInt64());
                    }
                    binaryReader.Close();
                  }
                }
              }
            }
            catch (InvalidOperationException ex)
            {
              Main.ShowSaveIcon();
              flag = false;
              storageContainer.DeleteFile("config.dat");
              this.armorFound = new BitArray(632);
              Main.HideSaveIcon();
            }
            catch (Exception ex)
            {
            }
          }
        }
        this.settingsDirty = !flag;
      }
      catch (IOException ex)
      {
        if (!flag)
        {
          this.WriteError();
          flag = true;
        }
        else
          this.ReadError();
      }
      catch (Exception ex)
      {
      }
      if (Main.netMode == 1 && Main.isGameStarted)
        this.CheckBlacklist();
      return flag;
    }

    public void ErasePlayer(int i)
    {
      if (this.HasPlayerStorage())
      {
        Main.ShowSaveIcon();
        try
        {
          using (StorageContainer storageContainer = this.OpenPlayerStorage("Characters"))
            storageContainer.DeleteFile(this.loadPlayerPath[i]);
        }
        catch (IOException ex)
        {
          this.WriteError();
        }
        catch (Exception ex)
        {
        }
        Main.HideSaveIcon();
      }
      --this.numLoadPlayers;
      this.loadPlayer[i] = this.loadPlayer[(int) this.numLoadPlayers];
      this.loadPlayerPath[i] = this.loadPlayerPath[(int) this.numLoadPlayers];
    }

    private string nextLoadPlayer()
    {
      int num = 0;
      string file = (string) null;
      if (this.HasPlayerStorage())
      {
        try
        {
          using (StorageContainer storageContainer = this.OpenPlayerStorage("Characters"))
          {
            do
            {
              ++num;
              file = "player" + (object) num + ".plr";
            }
            while (storageContainer.FileExists(file));
          }
        }
        catch (IOException ex)
        {
          this.ReadError();
          file = (string) null;
        }
        catch (Exception ex)
        {
          file = (string) null;
        }
      }
      return file;
    }

    public void setView(WorldView.Type viewType, bool noAutoFullScreen = false)
    {
      if (this.view != null)
      {
        for (int index = 0; index < UI.numActiveViews; ++index)
        {
          if (UI.activeView[index] == this.view)
          {
            UI.activeView[index] = UI.activeView[--UI.numActiveViews];
            UI.activeView[UI.numActiveViews] = (WorldView) null;
            break;
          }
        }
      }
      if (viewType != WorldView.Type.NONE)
      {
        if (this.view == null)
        {
          this.view = new WorldView();
          this.view.player = this.player;
          this.view.ui = this;
        }
        UI.activeView[UI.numActiveViews++] = this.view;
        UI.current = this;
        if (UI.numActiveViews == 2)
        {
          UI.LoadSplitscreenFonts(UI.theGame.Content);
          this.InvalidateCachedText();
        }
        if (this.view.setViewType(viewType) && this.menuType != MenuType.MAIN)
          this.worldFade = -0.25f;
      }
      else if (this.view != null)
      {
        this.view.Dispose();
        this.view = (WorldView) null;
        if (UI.numActiveViews == 1)
        {
          UI.LoadFonts(UI.theGame.Content);
          this.InvalidateCachedText();
        }
        if (UI.main == this)
        {
          if (UI.numActiveViews > 0)
          {
            for (int index = 0; index < 4; ++index)
            {
              if (Main.ui[index].view != null)
              {
                UI.main = Main.ui[index];
                WorldSelect.LoadWorlds();
                break;
              }
            }
          }
          else
            UI.main = (UI) null;
        }
      }
      else
        noAutoFullScreen = true;
      if (this.player != null)
      {
        this.player.view = this.view;
        if (this.view == null)
          this.player.active = (byte) 0;
      }
      if (noAutoFullScreen)
        return;
      if (UI.numActiveViews == 1 && UI.main != null && (UI.main.view != null && !UI.main.view.isFullScreen()))
      {
        UI.main.view.setViewType(WorldView.Type.FULLSCREEN);
        if (UI.main.menuType == MenuType.MAIN)
          return;
        UI.main.worldFade = -0.25f;
      }
      else
      {
        for (int index = 0; index < 4; ++index)
        {
          UI ui = Main.ui[index];
          if (ui.view != null)
            ui.view.setViewType(WorldView.getViewType(ui.controller, (UI) null));
        }
      }
    }

    public void setPlayer(int id, bool swapIfUsed = true)
    {
      if (id < 0)
      {
        for (int index = 7; index >= 0; --index)
        {
          if ((int) Main.player[index].active == 0 && Main.player[index].view == null)
          {
            id = index;
            break;
          }
        }
        if (id < 0)
        {
          this.myPlayer = (byte) 8;
          this.player = (Player) null;
          return;
        }
      }
      if (this.player != null && id != (int) this.myPlayer)
      {
        Player player = this.player.DeepCopy();
        player.whoAmI = (byte) id;
        this.player.ui = (UI) null;
        this.player.view = (WorldView) null;
        if (swapIfUsed)
        {
          for (int index = 0; index < 4; ++index)
          {
            UI ui = Main.ui[index];
            if (ui != this && (int) ui.myPlayer == id)
            {
              ui.setPlayer((int) this.myPlayer, false);
              break;
            }
          }
        }
        if (id != (int) this.myPlayer)
          Main.player[id] = player;
      }
      this.myPlayer = (byte) id;
      this.player = Main.player[id];
      this.player.ui = this;
      this.player.view = this.view;
      if (this.signedInGamer != null)
        this.player.name = this.signedInGamer.Gamertag;
      this.teamCooldown = (short) 0;
      this.teamSelected = this.player.team;
      this.pvpCooldown = (short) 0;
      this.pvpSelected = this.player.hostile;
      if (this.view != null)
        this.view.player = this.player;
      else
        this.player.active = (byte) 0;
    }

    public void setPlayer(Player p)
    {
      if (this.player != null && p != this.player)
      {
        this.player.ui = (UI) null;
        this.player.view = (WorldView) null;
      }
      this.player = p;
      this.teamCooldown = (short) 0;
      this.pvpCooldown = (short) 0;
      if (this.view != null)
        this.view.player = p;
      if (p != null)
      {
        this.teamSelected = p.team;
        this.pvpSelected = p.hostile;
        p.ui = this;
        p.view = this.view;
        p.whoAmI = this.myPlayer;
        if (this.signedInGamer != null)
          p.name = this.signedInGamer.Gamertag;
        p.active = (byte) 0;
        Main.player[(int) this.myPlayer] = p;
      }
      else
      {
        this.myPlayer = (byte) 8;
        this.setView(WorldView.Type.NONE, false);
      }
    }

    public void JoinSession(int newPlayerIndex)
    {
      this.setPlayer(newPlayerIndex, true);
      if (Main.netMode != 1)
        return;
      NetMessage.CreateMessage0(11);
      NetMessage.SendMessage();
    }

    public void LeaveSession()
    {
      this.localGamer = (LocalNetworkGamer) null;
    }

    public void InviteAccepted(InviteAcceptedEventArgs e)
    {
      if (e.IsCurrentSession || Netplay.isJoiningRemoteInvite)
      {
        if (Netplay.session == null)
        {
          if (!Netplay.gamersWhoReceivedInvite.Contains(e.Gamer))
            Netplay.gamersWhoReceivedInvite.Add(e.Gamer);
          if (!Netplay.gamersWaitingToJoinInvite.Contains(e.Gamer))
            Netplay.gamersWaitingToJoinInvite.Add(e.Gamer);
        }
        if (this.view != null)
          return;
        this.SetMenu(MenuMode.CHARACTER_SELECT, false, true);
        this.OpenView();
      }
      else
      {
        Netplay.isJoiningRemoteInvite = true;
        Netplay.gamersWhoReceivedInvite.Add(e.Gamer);
        Netplay.gamersWaitingToJoinInvite.Add(e.Gamer);
        for (int index = 0; index < 4; ++index)
        {
          SignedInGamer signedInGamer = Main.ui[index].signedInGamer;
          if (signedInGamer != null && !Netplay.gamersWaitingToJoinInvite.Contains(signedInGamer))
            Netplay.gamersWaitingToJoinInvite.Add(signedInGamer);
        }
        if (Netplay.session != null)
          this.ExitGame();
        else if (UI.main.menuMode == MenuMode.WELCOME)
        {
          this.OpenMainView(e.Gamer);
        }
        else
        {
          if (Main.worldGenThread != null)
          {
            Main.worldGenThread.Abort();
            Main.worldGenThread = (Thread) null;
            WorldGen.gen = false;
          }
          UI.main.SetMenu(MenuMode.TITLE, false, true);
        }
      }
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
        Netplay.gamersWaitingToJoinInvite.Remove(gamer);
    }

    private unsafe void DrawControlsIngame()
    {
      if (this.menuType != MenuType.NONE)
        return;
      Main.strBuilder.Length = 0;
      if (!Main.TutorialMaskY)
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INVENTORY));
        Main.strBuilder.Append(' ');
      }
      if ((int) this.player.grappleItemSlot >= 0)
      {
        Main.strBuilder.Append(Lang.controls(this.alternateGrappleControls ? Lang.CONTROLS.GRAPPLE_ALT : Lang.CONTROLS.GRAPPLE));
        Main.strBuilder.Append(' ');
      }
      fixed (Item* objPtr = &this.player.inventory[(int) this.player.selectedItem])
      {
        if (!Main.TutorialMaskRT && (int) objPtr->type > 0)
        {
          if ((int) objPtr->pick > 0)
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DIG));
          else if ((int) objPtr->axe > 0)
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHOP));
          else if ((int) objPtr->hammer > 0)
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.HIT));
          else if ((int) objPtr->createTile >= 0 || (int) objPtr->createWall >= 0)
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BUILD));
          else if ((int) objPtr->ammo > 0 || (int) objPtr->damage > 0)
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.ATTACK));
          else
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.USE));
          Main.strBuilder.Append(' ');
        }
        if (!Main.TutorialMaskB)
        {
          if ((int) this.player.npcChatBubble >= 0)
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.TALK));
          else if ((int) this.player.tileInteractX != 0)
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.INTERACT));
        }
      }
      UI.DrawStringLB(UI.fontSmallOutline, this.view.SAFE_AREA_OFFSET_L, this.view.SAFE_AREA_OFFSET_B);
    }

    private void DrawControlsInventory()
    {
      if (this.menuType != MenuType.NONE)
        return;
      Main.strBuilder.Length = 0;
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
      Main.strBuilder.Append(' ');
      if ((int) this.toolTip.type > 0 && !this.reforge && !this.craftGuide)
      {
        if (this.toolTip.isEquipable() && (this.inventorySection != UI.InventorySection.EQUIP || (int) this.inventoryEquipX == 0))
        {
          Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.EQUIP));
          Main.strBuilder.Append(' ');
        }
        if ((int) this.toolTip.type >= 599 && (int) this.toolTip.type <= 601)
        {
          Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.OPEN));
          Main.strBuilder.Append(' ');
        }
        else if ((int) this.toolTip.stack > 1 && ((int) this.mouseItem.type == 0 || (int) this.mouseItem.netID == (int) this.toolTip.netID))
        {
          Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELECT_ONE));
          Main.strBuilder.Append(' ');
        }
      }
      if ((int) this.mouseItem.type == 0)
      {
        if ((int) this.toolTip.type > 0)
        {
          if (this.reforge)
          {
            if (this.toolTip.Prefix(-3))
            {
              Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.REFORGE));
              Main.strBuilder.Append(' ');
            }
          }
          else if (this.craftGuide)
          {
            if (this.toolTip.material)
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
        else if (this.inventorySection == UI.InventorySection.CHEST)
        {
          if ((int) this.inventoryChestX < 0)
          {
            switch (this.inventoryChestY)
            {
              case (sbyte) 1:
                Main.strBuilder.Append(Lang.inter[29]);
                break;
              case (sbyte) 2:
                Main.strBuilder.Append(Lang.inter[30]);
                break;
              case (sbyte) 3:
                Main.strBuilder.Append(Lang.inter[31]);
                break;
            }
            Main.strBuilder.Append(' ');
          }
        }
        else if (this.inventorySection == UI.InventorySection.EQUIP && (int) this.inventoryEquipY == 0)
        {
          int index = (int) this.inventoryEquipX + (int) this.inventoryBuffX;
          if ((int) this.player.buff[index].Time > 0 && !this.player.buff[index].IsDebuff())
          {
            Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CANCEL_BUFF));
            Main.strBuilder.Append(' ');
          }
        }
      }
      else
      {
        bool flag1 = false;
        bool flag2 = true;
        if (this.inventorySection == UI.InventorySection.EQUIP)
        {
          switch (this.inventoryEquipY)
          {
            case (sbyte) 0:
              flag1 = (int) this.mouseItem.headSlot >= 0;
              break;
            case (sbyte) 1:
              flag1 = (int) this.mouseItem.bodySlot >= 0;
              break;
            case (sbyte) 2:
              flag1 = (int) this.mouseItem.legSlot >= 0;
              break;
            default:
              flag1 = this.mouseItem.accessory;
              break;
          }
        }
        else if (this.inventorySection == UI.InventorySection.ITEMS && (int) this.mouseItem.type > 0 && (int) this.mouseItem.stack > 0)
        {
          switch (this.inventoryItemY)
          {
            case (sbyte) 4:
              flag2 = this.mouseItem.CanBePlacedInAmmoSlot();
              break;
            case (sbyte) 5:
              flag2 = this.mouseItem.CanBePlacedInCoinSlot();
              break;
          }
        }
        if (flag2)
        {
          if ((int) this.toolTip.type > 0 && ((int) this.toolTip.netID != (int) this.mouseItem.netID || (int) this.toolTip.stack == (int) this.toolTip.maxStack || (int) this.mouseItem.stack == (int) this.mouseItem.maxStack))
          {
            if (this.inventorySection != UI.InventorySection.EQUIP || flag1)
            {
              Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SWAP));
              Main.strBuilder.Append(' ');
            }
          }
          else if ((int) this.toolTip.type == 0 || (int) this.toolTip.stack < (int) this.toolTip.maxStack)
          {
            if (this.inventorySection == UI.InventorySection.EQUIP)
            {
              if (flag1)
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
      if (!this.reforge && !this.craftGuide)
      {
        if ((int) this.mouseItem.type > 0)
        {
          Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DROP));
          Main.strBuilder.Append(' ');
        }
        else if (this.inventorySection == UI.InventorySection.ITEMS && (int) this.toolTip.type > 0)
        {
          Lang.CONTROLS i = (int) this.npcShop <= 0 ? Lang.CONTROLS.TRASH : Lang.CONTROLS.SELL;
          Main.strBuilder.Append(Lang.controls(i));
          Main.strBuilder.Append(' ');
        }
      }
      UI.DrawStringLB(UI.fontSmallOutline, this.view.SAFE_AREA_OFFSET_L, this.view.SAFE_AREA_OFFSET_B);
    }

    private void DrawControlsShop()
    {
      if (this.menuType != MenuType.NONE)
        return;
      Main.strBuilder.Length = 0;
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
      Main.strBuilder.Append(' ');
      if ((int) this.toolTip.type > 0 && (int) this.toolTip.stack > 1 && ((int) this.mouseItem.type == 0 || (int) this.mouseItem.netID == (int) this.toolTip.netID))
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BUY_ONE));
        Main.strBuilder.Append(' ');
      }
      if ((int) this.mouseItem.type == 0)
      {
        if ((int) this.toolTip.type > 0)
        {
          Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.BUY_ALL));
          Main.strBuilder.Append(' ');
        }
      }
      else if ((int) this.toolTip.type == 0)
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.SELL_ITEM_IN_HAND));
        Main.strBuilder.Append(' ');
      }
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
      Main.strBuilder.Append(' ');
      if ((int) this.mouseItem.type > 0)
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DROP));
        Main.strBuilder.Append(' ');
      }
      UI.DrawStringLB(UI.fontSmallOutline, this.view.SAFE_AREA_OFFSET_L, this.view.SAFE_AREA_OFFSET_B);
    }

    private void DrawControlsCrafting()
    {
      if (this.menuType != MenuType.NONE)
        return;
      Main.strBuilder.Length = 0;
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
      Main.strBuilder.Append(' ');
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CRAFTING_CATEGORY));
      Main.strBuilder.Append(' ');
      if (this.player.CanCraftRecipe(this.craftingRecipe))
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CRAFT));
        Main.strBuilder.Append(' ');
      }
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
      Main.strBuilder.Append(' ');
      if ((int) this.mouseItem.type > 0)
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.DROP));
        Main.strBuilder.Append(' ');
      }
      else
      {
        Main.strBuilder.Append(Lang.controls(this.craftingShowCraftable ? Lang.CONTROLS.SHOW_ALL : Lang.CONTROLS.SHOW_AVAILABLE));
        Main.strBuilder.Append(' ');
      }
      Lang.CONTROLS i = this.craftingSection == UI.CraftingSection.RECIPES ? Lang.CONTROLS.INGREDIENTS : Lang.CONTROLS.RECIPES;
      Main.strBuilder.Append(Lang.controls(i));
      UI.DrawStringLB(UI.fontSmallOutline, this.view.SAFE_AREA_OFFSET_L, this.view.SAFE_AREA_OFFSET_B);
    }

    private void DrawControlsHousing()
    {
      if (this.menuType != MenuType.NONE)
        return;
      Main.strBuilder.Length = 0;
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHANGE_MENU));
      Main.strBuilder.Append(' ');
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CHECK_HOUSING));
      Main.strBuilder.Append(' ');
      Main.strBuilder.Append(Lang.controls(this.showNPCs ? Lang.CONTROLS.HIDE_BANNERS : Lang.CONTROLS.SHOW_BANNERS));
      Main.strBuilder.Append(' ');
      if ((int) this.inventoryHousingNpc >= 0)
      {
        Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.ASSIGN_TO_ROOM));
        Main.strBuilder.Append(' ');
      }
      Main.strBuilder.Append(Lang.controls(Lang.CONTROLS.CLOSE));
      Main.strBuilder.Append(' ');
      UI.DrawStringLB(UI.fontSmallOutline, this.view.SAFE_AREA_OFFSET_L, this.view.SAFE_AREA_OFFSET_B);
    }

    public int DrawDialog(Vector2 pos, Color backColor, Color textColor, CompiledText ct, string caption = null, bool anchorBottom = false)
    {
      int num1 = 30;
      if (anchorBottom)
      {
        pos.Y -= (float) ((int) ct.Height + num1);
        num1 = 0;
      }
      Main.spriteBatch.Draw(UI.chatBackTexture, pos, new Rectangle?(new Rectangle(0, 0, UI.chatBackTexture.Width, (int) ct.Height + num1)), backColor);
      pos.Y += (float) ((int) ct.Height + num1);
      Main.spriteBatch.Draw(UI.chatBackTexture, pos, new Rectangle?(new Rectangle(0, UI.chatBackTexture.Height - 30, UI.chatBackTexture.Width, 30)), backColor);
      pos.Y -= (float) ((int) ct.Height + num1);
      if (caption != null)
      {
        int num2 = (int) UI.fontSmallOutline.MeasureString(caption).X;
        int num3 = UI.chatBackTexture.Width - num2 >> 1;
        int num4 = 0;
        Main.spriteBatch.DrawString(UI.fontSmallOutline, caption, new Vector2(pos.X + (float) num3, pos.Y + (float) num4), Color.LightGreen);
        pos.Y += (float) num1;
      }
      else
        pos.Y += 10f;
      pos.X += 20f;
      ct.Draw(Main.spriteBatch, new Rectangle((int) pos.X, (int) pos.Y, 470, 540), textColor, new Color((int) byte.MaxValue, 212, 64, (int) byte.MaxValue));
      return (int) ct.Height;
    }

    private void HelpText()
    {
      bool flag1 = (int) this.player.statLifeMax > 100;
      bool flag2 = (int) this.player.statManaMax > 0;
      bool flag3 = true;
      bool flag4 = false;
      bool flag5 = false;
      bool flag6 = false;
      bool flag7 = false;
      bool flag8 = false;
      bool flag9 = false;
      for (int index = 0; index < 48; ++index)
      {
        if ((int) this.player.inventory[index].pick > 0 && (int) this.player.inventory[index].netID != -13)
          flag3 = false;
        else if ((int) this.player.inventory[index].axe > 0 && (int) this.player.inventory[index].netID != -16)
          flag3 = false;
        else if ((int) this.player.inventory[index].hammer > 0)
          flag3 = false;
        switch ((Item.ID) this.player.inventory[index].type)
        {
          case Item.ID.ROTTEN_CHUNK:
          case Item.ID.WORM_FOOD:
            flag8 = true;
            break;
          case Item.ID.FALLEN_STAR:
            flag6 = true;
            break;
          case Item.ID.GRAPPLING_HOOK:
            flag9 = true;
            break;
          case Item.ID.IRON_ORE:
          case Item.ID.COPPER_ORE:
          case Item.ID.GOLD_ORE:
          case Item.ID.SILVER_ORE:
            flag4 = true;
            break;
          case Item.ID.GOLD_BAR:
          case Item.ID.COPPER_BAR:
          case Item.ID.SILVER_BAR:
          case Item.ID.IRON_BAR:
            flag5 = true;
            break;
          case Item.ID.LENS:
            flag7 = true;
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
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.npc[index].active != 0)
        {
          switch ((NPC.ID) Main.npc[index].type)
          {
            case NPC.ID.CLOTHIER:
              flag18 = true;
              continue;
            case NPC.ID.GOBLIN_TINKERER:
              flag17 = true;
              continue;
            case NPC.ID.WIZARD:
              flag16 = true;
              continue;
            case NPC.ID.MECHANIC:
              flag15 = true;
              continue;
            case NPC.ID.MERCHANT:
              flag10 = true;
              continue;
            case NPC.ID.NURSE:
              flag11 = true;
              continue;
            case NPC.ID.ARMS_DEALER:
              flag13 = true;
              continue;
            case NPC.ID.DRYAD:
              flag12 = true;
              continue;
            case NPC.ID.DEMOLITIONIST:
              flag14 = true;
              continue;
            default:
              continue;
          }
        }
      }
      while (true)
      {
        do
        {
          ++this.helpText;
          if (flag3)
          {
            if ((int) this.helpText == 1)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 177);
              return;
            }
            else if ((int) this.helpText == 2)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 178);
              return;
            }
            else if ((int) this.helpText == 3)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 179);
              return;
            }
            else if ((int) this.helpText == 4)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 180);
              return;
            }
            else if ((int) this.helpText == 5)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 181);
              return;
            }
            else if ((int) this.helpText == 6)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 182);
              return;
            }
          }
          if (flag3 && !flag4 && (!flag5 && (int) this.helpText == 11))
          {
            this.npcChatText = (UserString) Lang.dialog(this.player, 183);
            return;
          }
          else
          {
            if (flag3 && flag4 && !flag5)
            {
              if ((int) this.helpText == 21)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 184);
                return;
              }
              else if ((int) this.helpText == 22)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 185);
                return;
              }
            }
            if (flag3 && flag5)
            {
              if ((int) this.helpText == 31)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 186);
                return;
              }
              else if ((int) this.helpText == 32)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 187);
                return;
              }
            }
            if (!flag1 && (int) this.helpText == 41)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 188);
              return;
            }
            else if (!flag2 && (int) this.helpText == 42)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 189);
              return;
            }
            else if (!flag2 && !flag6 && (int) this.helpText == 43)
            {
              this.npcChatText = (UserString) Lang.dialog(this.player, 190);
              return;
            }
            else
            {
              if (!flag10 && !flag11)
              {
                if ((int) this.helpText == 51)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 191);
                  return;
                }
                else if ((int) this.helpText == 52)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 192);
                  return;
                }
                else if ((int) this.helpText == 53)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 193);
                  return;
                }
                else if ((int) this.helpText == 54)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 194);
                  return;
                }
              }
              if (!flag10 && (int) this.helpText == 61)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 195);
                return;
              }
              else if (!flag11 && (int) this.helpText == 62)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 196);
                return;
              }
              else if (!flag13 && (int) this.helpText == 63)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 197);
                return;
              }
              else if (!flag12 && (int) this.helpText == 64)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 198);
                return;
              }
              else if (!flag15 && (int) this.helpText == 65 && NPC.downedBoss3)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 199);
                return;
              }
              else if (!flag18 && (int) this.helpText == 66 && NPC.downedBoss3)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 200);
                return;
              }
              else if (!flag14 && (int) this.helpText == 67)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 201);
                return;
              }
              else if (!flag17 && NPC.downedBoss2 && (int) this.helpText == 68)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 202);
                return;
              }
              else if (!flag16 && Main.hardMode && (int) this.helpText == 69)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 203);
                return;
              }
              else if (flag7 && (int) this.helpText == 71)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 204);
                return;
              }
              else if (flag8 && (int) this.helpText == 72)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 205);
                return;
              }
              else if ((flag7 || flag8) && (int) this.helpText == 80)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 206);
                return;
              }
              else if (!flag9 && (int) this.helpText == 201 && (!Main.hardMode && !NPC.downedBoss3) && !NPC.downedBoss2)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 207);
                return;
              }
              else if ((int) this.helpText == 1000 && !NPC.downedBoss1 && !NPC.downedBoss2)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 208);
                return;
              }
              else if ((int) this.helpText == 1001 && !NPC.downedBoss1 && !NPC.downedBoss2)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 209);
                return;
              }
              else if ((int) this.helpText == 1002 && !NPC.downedBoss3)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 210);
                return;
              }
              else if ((int) this.helpText == 1050 && !NPC.downedBoss1)
              {
                if ((int) this.player.statLifeMax < 200)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 211);
                  return;
                }
              }
              else if ((int) this.helpText == 1051 && !NPC.downedBoss1)
              {
                if ((int) this.player.statDefense <= 10)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 212);
                  return;
                }
              }
              else if ((int) this.helpText == 1052 && !NPC.downedBoss1)
              {
                if ((int) this.player.statLifeMax >= 200 && (int) this.player.statDefense > 10)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 213);
                  return;
                }
              }
              else if ((int) this.helpText == 1053 && NPC.downedBoss1 && !NPC.downedBoss2)
              {
                if ((int) this.player.statLifeMax < 300)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 214);
                  return;
                }
              }
              else if ((int) this.helpText == 1054 && NPC.downedBoss1 && !NPC.downedBoss2)
              {
                if ((int) this.player.statLifeMax >= 300)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 215);
                  return;
                }
              }
              else if ((int) this.helpText == 1055 && NPC.downedBoss1 && !NPC.downedBoss2)
              {
                if ((int) this.player.statLifeMax >= 300)
                {
                  this.npcChatText = (UserString) Lang.dialog(this.player, 216);
                  return;
                }
              }
              else if ((int) this.helpText == 1056 && NPC.downedBoss1 && (NPC.downedBoss2 && !NPC.downedBoss3))
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 217);
                return;
              }
              else if ((int) this.helpText == 1057 && NPC.downedBoss1 && (NPC.downedBoss2 && NPC.downedBoss3) && (!Main.hardMode && (int) this.player.statLifeMax < 400))
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 218);
                return;
              }
              else if ((int) this.helpText == 1058 && NPC.downedBoss1 && (NPC.downedBoss2 && NPC.downedBoss3) && (!Main.hardMode && (int) this.player.statLifeMax >= 400))
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 219);
                return;
              }
              else if ((int) this.helpText == 1059 && NPC.downedBoss1 && (NPC.downedBoss2 && NPC.downedBoss3) && (!Main.hardMode && (int) this.player.statLifeMax >= 400))
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 220);
                return;
              }
              else if ((int) this.helpText == 1060 && NPC.downedBoss1 && (NPC.downedBoss2 && NPC.downedBoss3) && (!Main.hardMode && (int) this.player.statLifeMax >= 400))
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 221);
                return;
              }
              else if ((int) this.helpText == 1061 && Main.hardMode)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 222);
                return;
              }
              else if ((int) this.helpText == 1062 && Main.hardMode)
              {
                this.npcChatText = (UserString) Lang.dialog(this.player, 223);
                return;
              }
            }
          }
        }
        while ((int) this.helpText <= 1100);
        this.helpText = (short) 0;
      }
    }

    public void UpdateNpcChat()
    {
      this.focusText = (string) null;
      this.focusText3 = (string) null;
      int num1 = ((int) UI.mouseTextBrightness * 2 + (int) byte.MaxValue) / 3;
      this.focusColor = new Color(num1, (int) ((double) num1 * (10.0 / 11.0)), num1 >> 1, num1);
      int price = (int) this.player.statLifeMax - (int) this.player.statLife;
      if ((int) this.player.sign >= 0)
        this.focusText = Lang.inter[48];
      else if ((int) Main.npc[(int) this.player.talkNPC].type == 20)
      {
        this.focusText = Lang.inter[28];
        this.focusText3 = Lang.inter[49];
      }
      else if ((int) Main.npc[(int) this.player.talkNPC].type == 107)
      {
        this.focusText = Lang.inter[28];
        this.focusText3 = Lang.inter[19];
      }
      else if ((int) Main.npc[(int) this.player.talkNPC].type == 17 || (int) Main.npc[(int) this.player.talkNPC].type == 19 || ((int) Main.npc[(int) this.player.talkNPC].type == 38 || (int) Main.npc[(int) this.player.talkNPC].type == 54) || ((int) Main.npc[(int) this.player.talkNPC].type == 108 || (int) Main.npc[(int) this.player.talkNPC].type == 124 || (int) Main.npc[(int) this.player.talkNPC].type == 142))
        this.focusText = Lang.inter[28];
      else if ((int) Main.npc[(int) this.player.talkNPC].type == 37)
      {
        if (!Main.gameTime.dayTime)
          this.focusText = Lang.inter[50];
      }
      else if ((int) Main.npc[(int) this.player.talkNPC].type == 22)
      {
        this.focusText = Lang.inter[51];
        if (!Main.IsTutorial())
          this.focusText3 = Lang.inter[25];
      }
      else if ((int) Main.npc[(int) this.player.talkNPC].type == 18)
      {
        this.focusText = Lang.inter[54];
        for (int index = 0; index < 10; ++index)
        {
          if (this.player.buff[index].IsHealable())
            price += 1000;
        }
        if (price > 0)
        {
          string str1 = "";
          int num2 = 0;
          int num3 = 0;
          int num4 = 0;
          int num5 = 0;
          int num6 = (int) ((double) price * 0.75);
          if (num6 < 1)
            num6 = 1;
          price = num6;
          if (num6 >= 1000000)
          {
            num2 = num6 / 1000000;
            num6 -= num2 * 1000000;
          }
          if (num6 >= 10000)
          {
            num3 = num6 / 10000;
            num6 -= num3 * 10000;
          }
          if (num6 >= 100)
          {
            num4 = num6 / 100;
            num6 -= num4 * 100;
          }
          if (num6 > 0)
            num5 = num6;
          if (num2 > 0)
            str1 = (string) (object) num2 + (object) Lang.inter[15];
          if (num3 > 0)
            str1 = str1 + (object) num3 + Lang.inter[16];
          if (num4 > 0)
            str1 = str1 + (object) num4 + Lang.inter[17];
          if (num5 > 0)
            str1 = str1 + (object) num5 + Lang.inter[18];
          float num7 = (float) UI.mouseTextBrightness * 0.003921569f;
          if (num2 > 0)
            this.focusColor = new Color((int) (byte) (220.0 * (double) num7), (int) (byte) (220.0 * (double) num7), (int) (byte) (198.0 * (double) num7), (int) UI.mouseTextBrightness);
          else if (num3 > 0)
            this.focusColor = new Color((int) (byte) (224.0 * (double) num7), (int) (byte) (201.0 * (double) num7), (int) (byte) (92.0 * (double) num7), (int) UI.mouseTextBrightness);
          else if (num4 > 0)
            this.focusColor = new Color((int) (byte) (181.0 * (double) num7), (int) (byte) (192.0 * (double) num7), (int) (byte) (193.0 * (double) num7), (int) UI.mouseTextBrightness);
          else if (num5 > 0)
            this.focusColor = new Color((int) (byte) (246.0 * (double) num7), (int) (byte) (138.0 * (double) num7), (int) (byte) (96.0 * (double) num7), (int) UI.mouseTextBrightness);
          UI ui = this;
          string str2 = ui.focusText + " (" + str1 + ")";
          ui.focusText = str2;
        }
      }
      this.player.releaseUseItem = false;
      if (this.focusText == null && this.focusText3 == null)
        this.npcChatSelectedItem = (sbyte) 1;
      else if (this.IsLeftButtonTriggered())
      {
        Main.PlaySound(12);
        if ((int) --this.npcChatSelectedItem < 0)
          this.npcChatSelectedItem = this.focusText3 != null ? (sbyte) 2 : (sbyte) 1;
      }
      else if (this.IsRightButtonTriggered())
      {
        Main.PlaySound(12);
        ++this.npcChatSelectedItem;
        if ((int) this.npcChatSelectedItem == 3 || (int) this.npcChatSelectedItem == 2 && this.focusText3 == null)
          this.npcChatSelectedItem = (sbyte) 0;
      }
      if (this.IsButtonTriggered(Buttons.B))
      {
        this.player.talkNPC = (short) -1;
        this.player.sign = (short) -1;
        this.editSign = false;
        this.npcChatText = (UserString) null;
        Main.PlaySound(11);
        this.ClearButtonTriggers();
      }
      else
      {
        if (!this.IsButtonTriggered(Buttons.A))
          return;
        if ((int) this.npcChatSelectedItem == 0)
        {
          if ((int) this.player.sign != -1)
          {
            Main.PlaySound(12);
            this.editSign = true;
            this.ClearInput();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 17)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 1;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, this.player);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 19)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 2;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 124)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 8;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 142)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 9;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 37)
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
            this.npcChatText = (UserString) null;
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 20)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 3;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 38)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 4;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 54)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 5;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 107)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 6;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 108)
          {
            this.npcChatText = (UserString) null;
            this.npcShop = (byte) 7;
            Main.shop[(int) this.npcShop].SetupShop((int) this.npcShop, (Player) null);
            Main.PlaySound(12);
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 22)
          {
            Main.PlaySound(12);
            this.HelpText();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 18)
          {
            Main.PlaySound(12);
            if (price > 0)
            {
              if (this.player.BuyItem(price))
              {
                Main.PlaySound(2, -1, -1, 4);
                this.player.HealEffect((int) this.player.statLifeMax - (int) this.player.statLife);
                this.npcChatText = (double) this.player.statLife >= (double) this.player.statLifeMax * 0.25 ? ((double) this.player.statLife >= (double) this.player.statLifeMax * 0.5 ? ((double) this.player.statLife >= (double) this.player.statLifeMax * 0.75 ? (UserString) Lang.dialog(this.player, 230) : (UserString) Lang.dialog(this.player, 229)) : (UserString) Lang.dialog(this.player, 228)) : (UserString) Lang.dialog(this.player, 227);
                this.player.statLife = this.player.statLifeMax;
                for (int b = 0; b < 10; ++b)
                {
                  if (this.player.buff[b].IsHealable())
                    b = this.player.DelBuff(b);
                }
              }
              else
              {
                switch (Main.rand.Next(3))
                {
                  case 0:
                    this.npcChatText = (UserString) Lang.dialog(this.player, 52);
                    break;
                  case 1:
                    this.npcChatText = (UserString) Lang.dialog(this.player, 53);
                    break;
                  default:
                    this.npcChatText = (UserString) Lang.dialog(this.player, 54);
                    break;
                }
              }
            }
            else
            {
              switch (Main.rand.Next(3))
              {
                case 0:
                  this.npcChatText = (UserString) Lang.dialog(this.player, 55);
                  break;
                case 1:
                  this.npcChatText = (UserString) Lang.dialog(this.player, 56);
                  break;
                default:
                  this.npcChatText = (UserString) Lang.dialog(this.player, 57);
                  break;
              }
            }
          }
        }
        else if ((int) this.npcChatSelectedItem == 1)
        {
          this.player.talkNPC = (short) -1;
          this.player.sign = (short) -1;
          this.editSign = false;
          this.npcChatText = (UserString) null;
          Main.PlaySound(11);
        }
        else if ((int) this.player.talkNPC >= 0)
        {
          if ((int) Main.npc[(int) this.player.talkNPC].type == 20)
          {
            Main.PlaySound(12);
            this.npcChatText = (UserString) Lang.evilGood();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 22)
          {
            this.npcChatText = (UserString) null;
            Main.PlaySound(12);
            this.craftGuide = true;
            this.guideItem.Init();
            this.OpenInventory();
          }
          else if ((int) Main.npc[(int) this.player.talkNPC].type == 107)
          {
            this.npcChatText = (UserString) null;
            Main.PlaySound(12);
            this.reforge = true;
            this.OpenInventory();
          }
        }
        this.ClearButtonTriggers();
      }
    }

    private void DrawNpcChat()
    {
      string @string = this.npcChatText.GetString();
      if (@string != this.npcCompiledChatText)
      {
        this.npcCompiledChatText = @string;
        this.npcChatCompiledText = new CompiledText(@string, 470, UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
      }
      int num1 = ((int) UI.mouseTextBrightness * 2 + (int) byte.MaxValue) / 3;
      Color color = new Color(num1, num1, num1, num1);
      int num2 = this.DrawDialog(new Vector2((float) ((int) this.view.viewWidth - UI.chatBackTexture.Width >> 1), 100f), new Color(200, 200, 200, 200), color, this.npcChatCompiledText, (string) null, false);
      int num3 = (int) UI.mouseTextBrightness;
      int num4 = 180 + ((int) this.view.viewWidth - 800 >> 1);
      int num5 = 128 + num2;
      Vector2 pivot1 = new Vector2();
      if (this.focusText != null)
      {
        pivot1 = UI.MeasureString(UI.fontSmallOutline, this.focusText);
        pivot1.X *= 0.5f;
        pivot1.Y *= 0.5f;
        UI.DrawStringScaled(UI.fontSmallOutline, this.focusText, new Vector2((float) num4 + pivot1.X, (float) num5 + pivot1.Y), this.focusColor, pivot1, (int) this.npcChatSelectedItem == 0 ? 1.1f : 0.9f);
      }
      string str = Lang.inter[52];
      color = new Color(num3, (int) ((double) num3 * (10.0 / 11.0)), num3 >> 1, num3);
      int num6 = num4 + (int) ((double) pivot1.X * 2.0) + 30;
      Vector2 pivot2 = UI.MeasureString(UI.fontSmallOutline, str);
      pivot2.X *= 0.5f;
      pivot2.Y *= 0.5f;
      UI.DrawStringScaled(UI.fontSmallOutline, str, new Vector2((float) num6 + pivot2.X, (float) num5 + pivot2.Y), color, pivot2, (int) this.npcChatSelectedItem == 1 ? 1.1f : 0.9f);
      if (this.focusText3 == null)
        return;
      int num7 = num6 + (int) ((double) pivot2.X * 2.0) + 30;
      Vector2 pivot3 = UI.MeasureString(UI.fontSmallOutline, this.focusText3);
      pivot3.X *= 0.5f;
      pivot3.Y *= 0.5f;
      UI.DrawStringScaled(UI.fontSmallOutline, this.focusText3, new Vector2((float) num7 + pivot3.X, (float) num5 + pivot3.Y), color, pivot3, (int) this.npcChatSelectedItem == 2 ? 1.1f : 0.9f);
    }

    private void Reforge(int slot, bool isArmor = false)
    {
      if (!this.toolTip.Prefix(-3) || !this.player.BuyItem(this.toolTip.value))
        return;
      int num = (int) this.toolTip.prefix;
      this.toolTip.netDefaults((int) this.toolTip.netID, 1);
      do
      {
        this.toolTip.Prefix(-2);
      }
      while ((int) this.toolTip.prefix == num);
      this.toolTip.position.X = (float) (this.player.aabb.X + 10 - ((int) this.toolTip.width >> 1));
      this.toolTip.position.Y = (float) (this.player.aabb.Y + 21 - ((int) this.toolTip.height >> 1));
      if (isArmor)
        this.player.armor[slot] = this.toolTip;
      else
        this.player.inventory[slot] = this.toolTip;
      Main.PlaySound(2, this.player.aabb.X, this.player.aabb.Y, 37);
    }

    private void CraftingGuide()
    {
      if ((int) this.toolTip.type <= 0 || !this.toolTip.material)
        return;
      this.guideItem = this.toolTip;
      this.inventorySection = UI.InventorySection.CRAFTING;
      this.craftingCategory = Recipe.Category.MISC;
      for (int index = 0; index < 6; ++index)
      {
        this.NextCraftingCategory();
        if (this.currentRecipeCategory.Count > 0)
          break;
      }
    }

    private bool IsSlotAssignedToQuickAccess(int slot)
    {
      if ((int) this.quickAccessUp != slot && (int) this.quickAccessDown != slot && (int) this.quickAccessLeft != slot)
        return (int) this.quickAccessRight == slot;
      else
        return true;
    }

    private void UpdateInventory()
    {
      if ((int) this.inventoryItemX == 9 && (int) this.inventoryItemY == 6)
      {
        if (!this.IsButtonTriggered(Buttons.A))
          return;
        if ((int) this.mouseItem.type != 0)
          this.trashItem.Init();
        Item obj = this.mouseItem;
        this.mouseItem = this.trashItem;
        this.trashItem = obj;
        this.mouseItemSrcSection = UI.InventorySection.ITEMS;
        this.mouseItemSrcX = this.inventoryItemX;
        this.mouseItemSrcY = this.inventoryItemY;
        if ((int) this.trashItem.type == 0 || (int) this.trashItem.stack < 1)
          this.trashItem.Init();
        if ((int) this.mouseItem.netID == (int) this.trashItem.netID && (int) this.trashItem.stack != (int) this.trashItem.maxStack && (int) this.mouseItem.stack != (int) this.mouseItem.maxStack)
        {
          if ((int) this.mouseItem.stack + (int) this.trashItem.stack <= (int) this.mouseItem.maxStack)
          {
            this.trashItem.stack += this.mouseItem.stack;
            this.mouseItem.stack = (short) 0;
          }
          else
          {
            short num = (short) ((int) this.mouseItem.maxStack - (int) this.trashItem.stack);
            this.trashItem.stack += num;
            this.mouseItem.stack -= num;
          }
        }
        if ((int) this.mouseItem.type == 0 || (int) this.mouseItem.stack < 1)
          this.mouseItem.Init();
        if ((int) this.mouseItem.type <= 0 && (int) this.trashItem.type <= 0)
          return;
        Main.PlaySound(7);
      }
      else
      {
        bool flag1 = true;
        int slot;
        switch (this.inventoryItemY)
        {
          case (sbyte) 4:
            slot = 44 + (int) this.inventoryItemX - 6;
            flag1 = this.mouseItem.CanBePlacedInAmmoSlot();
            break;
          case (sbyte) 5:
            slot = 40 + (int) this.inventoryItemX - 6;
            flag1 = this.mouseItem.CanBePlacedInCoinSlot();
            break;
          default:
            slot = (int) this.inventoryItemX + (int) this.inventoryItemY * 10;
            break;
        }
        if (slot < 40 && (int) this.mouseItem.type == 0)
        {
          if (this.IsButtonTriggered(Buttons.DPadUp))
          {
            if ((int) this.quickAccessUp == slot)
            {
              this.quickAccessUp = (sbyte) -1;
            }
            else
            {
              this.quickAccessUp = (sbyte) slot;
              if ((int) this.quickAccessDown == slot)
                this.quickAccessDown = (sbyte) -1;
              else if ((int) this.quickAccessLeft == slot)
                this.quickAccessLeft = (sbyte) -1;
              else if ((int) this.quickAccessRight == slot)
                this.quickAccessRight = (sbyte) -1;
            }
            Main.PlaySound(7);
          }
          else if (this.IsButtonTriggered(Buttons.DPadDown))
          {
            if ((int) this.quickAccessDown == slot)
            {
              this.quickAccessDown = (sbyte) -1;
            }
            else
            {
              this.quickAccessDown = (sbyte) slot;
              if ((int) this.quickAccessUp == slot)
                this.quickAccessUp = (sbyte) -1;
              else if ((int) this.quickAccessLeft == slot)
                this.quickAccessLeft = (sbyte) -1;
              else if ((int) this.quickAccessRight == slot)
                this.quickAccessRight = (sbyte) -1;
            }
            Main.PlaySound(7);
          }
          else if (this.IsButtonTriggered(Buttons.DPadLeft))
          {
            if ((int) this.quickAccessLeft == slot)
            {
              this.quickAccessLeft = (sbyte) -1;
            }
            else
            {
              this.quickAccessLeft = (sbyte) slot;
              if ((int) this.quickAccessUp == slot)
                this.quickAccessUp = (sbyte) -1;
              else if ((int) this.quickAccessDown == slot)
                this.quickAccessDown = (sbyte) -1;
              else if ((int) this.quickAccessRight == slot)
                this.quickAccessRight = (sbyte) -1;
            }
            Main.PlaySound(7);
          }
          else if (this.IsButtonTriggered(Buttons.DPadRight))
          {
            if ((int) this.quickAccessRight == slot)
            {
              this.quickAccessRight = (sbyte) -1;
            }
            else
            {
              this.quickAccessRight = (sbyte) slot;
              if ((int) this.quickAccessUp == slot)
                this.quickAccessUp = (sbyte) -1;
              else if ((int) this.quickAccessDown == slot)
                this.quickAccessDown = (sbyte) -1;
              else if ((int) this.quickAccessLeft == slot)
                this.quickAccessLeft = (sbyte) -1;
            }
            Main.PlaySound(7);
          }
        }
        if (this.IsButtonTriggered(Buttons.A))
        {
          if (this.reforge)
            this.Reforge(slot, false);
          else if (this.craftGuide)
          {
            this.CraftingGuide();
          }
          else
          {
            if ((int) this.mouseItem.type != 0 && (!flag1 || (int) this.player.selectedItem == slot && (int) this.player.itemAnimation > 0))
              return;
            Item obj = this.mouseItem;
            this.mouseItem = this.player.inventory[slot];
            this.player.inventory[slot] = obj;
            if ((int) this.player.inventory[slot].type == 0 || (int) this.player.inventory[slot].stack < 1)
              this.player.inventory[slot].Init();
            bool flag2 = false;
            if ((int) this.mouseItem.netID == (int) this.player.inventory[slot].netID && (int) this.player.inventory[slot].stack != (int) this.player.inventory[slot].maxStack && (int) this.mouseItem.stack != (int) this.mouseItem.maxStack)
            {
              if ((int) this.mouseItem.stack + (int) this.player.inventory[slot].stack <= (int) this.mouseItem.maxStack)
              {
                this.player.inventory[slot].stack += this.mouseItem.stack;
                this.mouseItem.Init();
              }
              else
              {
                short num = (short) ((int) this.mouseItem.maxStack - (int) this.player.inventory[slot].stack);
                this.player.inventory[slot].stack += num;
                this.mouseItem.stack -= num;
                flag2 = true;
              }
            }
            if ((int) this.mouseItem.type > 0 && (int) obj.type > 0 && (!flag2 && this.mouseItemSrcSection == UI.InventorySection.ITEMS) && ((int) this.mouseItemSrcX < 10 && (int) this.mouseItemSrcY < 4))
            {
              int index = (int) this.mouseItemSrcX + (int) this.mouseItemSrcY * 10;
              if ((int) this.player.inventory[index].type == 0)
              {
                this.player.inventory[index] = this.mouseItem;
                this.mouseItem.Init();
              }
              if ((int) this.quickAccessUp == index)
                this.quickAccessUp = (sbyte) slot;
              else if ((int) this.quickAccessDown == index)
                this.quickAccessDown = (sbyte) slot;
              else if ((int) this.quickAccessLeft == index)
                this.quickAccessLeft = (sbyte) slot;
              else if ((int) this.quickAccessRight == index)
                this.quickAccessRight = (sbyte) slot;
            }
            this.mouseItemSrcSection = UI.InventorySection.ITEMS;
            this.mouseItemSrcX = this.inventoryItemX;
            this.mouseItemSrcY = this.inventoryItemY;
            if ((int) this.mouseItem.type <= 0 && (int) this.player.inventory[slot].type <= 0)
              return;
            Main.PlaySound(7);
          }
        }
        else if (this.gpState.IsButtonDown(Buttons.RightTrigger))
        {
          if (this.gpPrevState.IsButtonUp(Buttons.RightTrigger))
          {
            if ((int) this.player.inventory[slot].type >= 599 && (int) this.player.inventory[slot].type <= 601)
            {
              Main.PlaySound(7);
              this.stackSplit = (short) 30;
              int num = Main.rand.Next(14);
              if (num == 0 && Main.hardMode)
              {
                this.player.inventory[slot].SetDefaults(602, 1, false);
              }
              else
              {
                this.player.inventory[slot].SetDefaults(num <= 7 ? 586 : 591, 1, false);
                this.player.inventory[slot].stack = (short) Main.rand.Next(20, 50);
              }
            }
            else
            {
              if (!this.player.inventory[slot].isEquipable())
                return;
              this.player.inventory[slot] = this.player.armorSwap(ref this.player.inventory[slot]);
            }
          }
          else
          {
            if ((int) this.stackSplit > 1 || (int) this.player.inventory[slot].maxStack <= 1 || (int) this.player.inventory[slot].type <= 0 || ((int) this.mouseItem.netID != (int) this.player.inventory[slot].netID && (int) this.mouseItem.type != 0 || (int) this.mouseItem.stack >= (int) this.mouseItem.maxStack && (int) this.mouseItem.type != 0))
              return;
            if ((int) this.mouseItem.type == 0)
            {
              this.mouseItem = this.player.inventory[slot];
              this.mouseItem.stack = (short) 0;
              this.mouseItemSrcSection = UI.InventorySection.ITEMS;
              this.mouseItemSrcX = this.inventoryItemX;
              this.mouseItemSrcY = this.inventoryItemY;
            }
            ++this.mouseItem.stack;
            --this.player.inventory[slot].stack;
            if ((int) this.player.inventory[slot].stack <= 0)
              this.player.inventory[slot].Init();
            Main.PlaySound(12);
            if ((int) this.stackSplit == 0)
              this.stackSplit = (short) 15;
            else
              this.stackSplit = this.stackDelay;
          }
        }
        else
        {
          if ((int) this.mouseItem.type != 0 || this.reforge || (!this.IsButtonTriggered(Buttons.X) || (int) this.player.inventory[slot].type <= 0))
            return;
          if ((int) this.npcShop > 0 && !this.player.inventory[slot].CanBePlacedInCoinSlot())
          {
            if (this.player.SellItem(this.player.inventory[slot].value, (int) this.player.inventory[slot].stack))
            {
              Main.shop[(int) this.npcShop].AddShop(ref this.player.inventory[slot]);
              this.player.inventory[slot].Init();
              Main.PlaySound(18);
            }
            else
            {
              if (this.player.inventory[slot].value != 0)
                return;
              Main.shop[(int) this.npcShop].AddShop(ref this.player.inventory[slot]);
              this.player.inventory[slot].Init();
              Main.PlaySound(7);
            }
          }
          else
          {
            Main.PlaySound(7);
            this.trashItem = this.player.inventory[slot];
            this.player.inventory[slot].Init();
          }
        }
      }
    }

    private void DrawInventory(int itemsSectionX, int itemsSectionY)
    {
      Vector2 pos = new Vector2();
      Color c1 = new Color((int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha);
      UI.inventoryScale = 0.93125f;
      UI.DrawStringRC(UI.fontSmall, Lang.inter[3], itemsSectionX + 469, itemsSectionY + 338, Color.White);
      int x1 = 469 + itemsSectionX;
      int y1 = 312 + itemsSectionY;
      if ((int) this.inventoryItemX == 9 && (int) this.inventoryItemY == 6)
      {
        this.DrawInventoryCursor(x1, y1, (double) UI.inventoryScale, (int) byte.MaxValue);
        this.toolTip = this.trashItem;
      }
      else
        SpriteSheet<_sheetSprites>.DrawTL(446, x1, y1, c1, UI.inventoryScale);
      if ((int) this.trashItem.type == 0 || (int) this.trashItem.stack == 0)
      {
        pos.X = (float) x1 + 26f * UI.inventoryScale;
        pos.Y = (float) y1 + 26f * UI.inventoryScale;
        SpriteSheet<_sheetSprites>.DrawScaled(1482, ref pos, new Color(100, 100, 100, 100), UI.inventoryScale);
      }
      else
        this.DrawInventoryItem(ref this.trashItem, x1, y1, Color.White, UI.StackType.INVENTORY);
      for (int index1 = 0; index1 < 10; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int x2 = itemsSectionX + (int) ((double) index1 * 52.1499977111816);
          int y2 = itemsSectionY + (int) ((double) index2 * 52.1499977111816);
          int slot = index1 + index2 * 10;
          if ((int) this.inventoryItemX == index1 && (int) this.inventoryItemY == index2)
          {
            this.toolTip = this.player.inventory[slot];
            this.DrawInventoryCursor(x2, y2, (double) UI.inventoryScale, (int) byte.MaxValue);
          }
          else
          {
            Color c2 = c1;
            int id;
            if (this.IsSlotAssignedToQuickAccess(slot))
            {
              id = 450;
              c2 = UI.mouseTextColor;
            }
            else
              id = index2 == 0 ? 447 : 451;
            SpriteSheet<_sheetSprites>.DrawTL(id, x2, y2, c2, UI.inventoryScale);
          }
          if ((int) this.player.inventory[slot].type > 0 && (int) this.player.inventory[slot].stack > 0)
          {
            UI.StackType stackType;
            Color itemColor;
            if (this.craftGuide && !this.player.inventory[slot].material || this.reforge && !this.player.inventory[slot].Prefix(-3))
            {
              stackType = UI.StackType.NONE;
              itemColor = UI.DISABLED_COLOR;
            }
            else
            {
              stackType = UI.StackType.INVENTORY;
              itemColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            }
            this.DrawInventoryItem(ref this.player.inventory[slot], x2, y2, itemColor, stackType);
          }
        }
      }
      UI.DrawStringRC(UI.fontSmall, Lang.inter[26], itemsSectionX + 312, itemsSectionY + 286, Color.White);
      for (int index1 = 0; index1 < 4; ++index1)
      {
        int x2 = (int) ((double) (6 + index1) * 52.1499977111816) + itemsSectionX;
        int y2 = 260 + itemsSectionY;
        int index2 = index1 + 40;
        if ((int) this.inventoryItemY == 5 && (int) this.inventoryItemX - 6 == index1)
        {
          this.DrawInventoryCursor(x2, y2, (double) UI.inventoryScale, (int) byte.MaxValue);
          this.toolTip = this.player.inventory[index2];
        }
        else
          SpriteSheet<_sheetSprites>.DrawTL(451, x2, y2, c1, UI.inventoryScale);
        if ((int) this.player.inventory[index2].type > 0 && (int) this.player.inventory[index2].stack > 0)
          this.DrawInventoryItem(ref this.player.inventory[index2], x2, y2, Color.White, UI.StackType.INVENTORY);
      }
      UI.DrawStringRC(UI.fontSmall, Lang.inter[27], itemsSectionX + 312, itemsSectionY + 234, Color.White);
      for (int index1 = 0; index1 < 4; ++index1)
      {
        int x2 = (int) ((double) (6 + index1) * 52.1499977111816) + itemsSectionX;
        int y2 = 208 + itemsSectionY;
        int index2 = index1 + 44;
        if (this.inventorySection == UI.InventorySection.ITEMS && (int) this.inventoryItemY == 4 && (int) this.inventoryItemX - 6 == index1)
        {
          this.DrawInventoryCursor(x2, y2, (double) UI.inventoryScale, (int) byte.MaxValue);
          this.toolTip = this.player.inventory[index2];
        }
        else
          SpriteSheet<_sheetSprites>.DrawTL(451, x2, y2, c1, UI.inventoryScale);
        if ((int) this.player.inventory[index2].type > 0 && (int) this.player.inventory[index2].stack > 0)
        {
          UI.StackType stackType;
          Color itemColor;
          if (this.craftGuide && !this.player.inventory[index2].material || this.reforge)
          {
            stackType = UI.StackType.NONE;
            itemColor = UI.DISABLED_COLOR;
          }
          else
          {
            stackType = UI.StackType.INVENTORY;
            itemColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          }
          this.DrawInventoryItem(ref this.player.inventory[index2], x2, y2, itemColor, stackType);
        }
      }
      this.DrawQuickAccess(-1, itemsSectionX + 26, itemsSectionY + 234, (int) byte.MaxValue, UI.StackType.INVENTORY);
      this.UpdateToolTipText((string) null);
      this.DrawToolTip(itemsSectionX + 864 - 322 - 8, itemsSectionY + 8, 344);
      this.DrawControlsInventory();
    }

    public int UpdateQuickAccess()
    {
      int num = -1;
      int index1 = (int) this.quickAccessUp;
      if (index1 >= 0)
      {
        if ((int) this.player.inventory[index1].type == 0)
          this.quickAccessUp = (sbyte) -1;
        else if (this.gpState.DPad.Up == ButtonState.Pressed && this.gpPrevState.DPad.Up == ButtonState.Released)
          num = index1;
      }
      int index2 = (int) this.quickAccessDown;
      if (index2 >= 0)
      {
        if ((int) this.player.inventory[index2].type == 0)
          this.quickAccessDown = (sbyte) -1;
        else if (this.gpState.DPad.Down == ButtonState.Pressed && this.gpPrevState.DPad.Down == ButtonState.Released)
          num = index2;
      }
      int index3 = (int) this.quickAccessLeft;
      if (index3 >= 0)
      {
        if ((int) this.player.inventory[index3].type == 0)
          this.quickAccessLeft = (sbyte) -1;
        else if (this.gpState.DPad.Left == ButtonState.Pressed && this.gpPrevState.DPad.Left == ButtonState.Released)
          num = index3;
      }
      int index4 = (int) this.quickAccessRight;
      if (index4 >= 0)
      {
        if ((int) this.player.inventory[index4].type == 0)
          this.quickAccessRight = (sbyte) -1;
        else if (this.gpState.DPad.Right == ButtonState.Pressed && this.gpPrevState.DPad.Right == ButtonState.Released)
          num = index4;
      }
      return num;
    }

    private void DrawQuickAccess(int selectedItem, int x, int y, int alpha, UI.StackType stackType)
    {
      Color color1 = new Color(alpha, alpha, alpha, alpha);
      Color color2 = new Color(0, 0, 0, alpha >> 1);
      alpha = alpha * (int) UI.mouseTextBrightness >> 8;
      Color c = new Color(alpha, alpha, alpha, alpha);
      SpriteSheet<_sheetSprites>.Draw(217, x, y, color1);
      UI.inventoryScale = 1f;
      int index1 = (int) this.quickAccessUp;
      if (index1 >= 0)
      {
        if (selectedItem == index1)
        {
          SpriteSheet<_sheetSprites>.Draw(448, x + 32 + 4, y - 4, color2);
          SpriteSheet<_sheetSprites>.Draw(448, x + 32, y - 4 - 4, c);
        }
        if ((int) this.player.inventory[index1].type > 0)
        {
          if (selectedItem != index1)
            this.DrawInventoryItem(ref this.player.inventory[index1], x + 32 + 4, y - 4, color2, stackType);
          this.DrawInventoryItem(ref this.player.inventory[index1], x + 32, y - 4 - 4, color1, stackType);
        }
      }
      int index2 = (int) this.quickAccessDown;
      if (index2 >= 0)
      {
        if (selectedItem == index2)
        {
          SpriteSheet<_sheetSprites>.Draw(448, x + 32 + 4, y + 112 - 42 + 4, color2);
          SpriteSheet<_sheetSprites>.Draw(448, x + 32, y + 112 - 42, c);
        }
        if ((int) this.player.inventory[index2].type > 0)
        {
          if (selectedItem != index2)
            this.DrawInventoryItem(ref this.player.inventory[index2], x + 32 + 4, y + 112 - 42 + 4, color2, stackType);
          this.DrawInventoryItem(ref this.player.inventory[index2], x + 32, y + 112 - 42, color1, stackType);
        }
      }
      int index3 = (int) this.quickAccessLeft;
      if (index3 >= 0)
      {
        if (selectedItem == index3)
        {
          SpriteSheet<_sheetSprites>.Draw(448, x - 4, y + 30 + 4, color2);
          SpriteSheet<_sheetSprites>.Draw(448, x - 4 - 4, y + 30, c);
        }
        if ((int) this.player.inventory[index3].type > 0)
        {
          if (selectedItem != index3)
            this.DrawInventoryItem(ref this.player.inventory[index3], x - 4, y + 30 + 4, color2, stackType);
          this.DrawInventoryItem(ref this.player.inventory[index3], x - 4 - 4, y + 30, color1, stackType);
        }
      }
      int index4 = (int) this.quickAccessRight;
      if (index4 < 0)
        return;
      if (selectedItem == index4)
      {
        SpriteSheet<_sheetSprites>.Draw(448, x + 112 - 42 + 4, y + 30 + 4, color2);
        SpriteSheet<_sheetSprites>.Draw(448, x + 112 - 42, y + 30, c);
      }
      if ((int) this.player.inventory[index4].type <= 0)
        return;
      if (selectedItem != index4)
        this.DrawInventoryItem(ref this.player.inventory[index4], x + 112 - 42 + 4, y + 30 + 4, color2, stackType);
      this.DrawInventoryItem(ref this.player.inventory[index4], x + 112 - 42, y + 30, color1, stackType);
    }

    private void UpdateStorage()
    {
      if ((int) this.inventoryChestX < 0)
      {
        if (!this.IsButtonTriggered(Buttons.A))
          return;
        switch (this.inventoryChestY)
        {
          case (sbyte) 1:
            if ((int) this.player.chest >= 0)
            {
              Main.chest[(int) this.player.chest].LootAll(this.player);
              break;
            }
            else if ((int) this.player.chest == -3)
            {
              this.player.safe.LootAll(this.player);
              break;
            }
            else
            {
              this.player.bank.LootAll(this.player);
              break;
            }
          case (sbyte) 2:
            if ((int) this.player.chest >= 0)
            {
              Main.chest[(int) this.player.chest].Deposit(this.player);
              break;
            }
            else if ((int) this.player.chest == -3)
            {
              this.player.safe.Deposit(this.player);
              break;
            }
            else
            {
              this.player.bank.Deposit(this.player);
              break;
            }
          case (sbyte) 3:
            if ((int) this.player.chest >= 0)
            {
              Main.chest[(int) this.player.chest].QuickStack(this.player);
              break;
            }
            else if ((int) this.player.chest == -3)
            {
              this.player.safe.QuickStack(this.player);
              break;
            }
            else
            {
              this.player.bank.QuickStack(this.player);
              break;
            }
        }
      }
      else
      {
        int number = (int) this.player.chest;
        Chest chest;
        switch (number)
        {
          case -3:
            chest = this.player.safe;
            break;
          case -2:
            chest = this.player.bank;
            break;
          default:
            chest = Main.chest[number];
            break;
        }
        int number2 = (int) this.inventoryChestX + (int) this.inventoryChestY * 5;
        if (this.IsButtonTriggered(Buttons.A))
        {
          if ((int) this.player.selectedItem == number2 && (int) this.player.itemAnimation > 0)
            return;
          Item obj = this.mouseItem;
          this.mouseItem = chest.item[number2];
          this.mouseItemSrcSection = UI.InventorySection.CHEST;
          this.mouseItemSrcX = this.inventoryChestX;
          this.mouseItemSrcY = this.inventoryChestY;
          chest.item[number2] = obj;
          if ((int) chest.item[number2].type == 0 || (int) chest.item[number2].stack < 1)
            chest.item[number2].Init();
          if ((int) this.mouseItem.netID == (int) chest.item[number2].netID && (int) chest.item[number2].stack != (int) chest.item[number2].maxStack && (int) this.mouseItem.stack != (int) this.mouseItem.maxStack)
          {
            if ((int) this.mouseItem.stack + (int) chest.item[number2].stack <= (int) this.mouseItem.maxStack)
            {
              chest.item[number2].stack += this.mouseItem.stack;
              this.mouseItem.stack = (short) 0;
            }
            else
            {
              short num = (short) ((int) this.mouseItem.maxStack - (int) chest.item[number2].stack);
              chest.item[number2].stack += num;
              this.mouseItem.stack -= num;
            }
          }
          if ((int) this.mouseItem.type == 0 || (int) this.mouseItem.stack < 1)
            this.mouseItem.Init();
          if ((int) this.mouseItem.type > 0 || (int) chest.item[number2].type > 0)
            Main.PlaySound(7);
          if (number < 0)
            return;
          NetMessage.CreateMessage2(32, number, number2);
          NetMessage.SendMessage();
        }
        else if (this.IsButtonTriggered(Buttons.RightTrigger) && chest.item[number2].isEquipable())
        {
          chest.item[number2] = this.player.armorSwap(ref chest.item[number2]);
          if (number < 0)
            return;
          NetMessage.CreateMessage2(32, number, number2);
          NetMessage.SendMessage();
        }
        else
        {
          if ((int) this.stackSplit > 1 || !this.gpState.IsButtonDown(Buttons.RightTrigger) || (int) chest.item[number2].maxStack <= 1 || ((int) this.mouseItem.netID != (int) chest.item[number2].netID && (int) this.mouseItem.type != 0 || (int) this.mouseItem.stack >= (int) this.mouseItem.maxStack && (int) this.mouseItem.type != 0))
            return;
          if ((int) this.mouseItem.type == 0)
          {
            this.mouseItem = chest.item[number2];
            this.mouseItem.stack = (short) 0;
            this.mouseItemSrcSection = UI.InventorySection.CHEST;
            this.mouseItemSrcX = this.inventoryChestX;
            this.mouseItemSrcY = this.inventoryChestY;
          }
          ++this.mouseItem.stack;
          --chest.item[number2].stack;
          if ((int) chest.item[number2].stack <= 0)
            chest.item[number2].Init();
          Main.PlaySound(12);
          this.stackSplit = (int) this.stackSplit != 0 ? this.stackDelay : (short) 15;
          if (number < 0)
            return;
          NetMessage.CreateMessage2(32, number, number2);
          NetMessage.SendMessage();
        }
      }
    }

    private void DrawStorage(int INVENTORY_X, int INVENTORY_Y)
    {
      int index1 = (int) this.player.chest;
      Chest chest;
      switch (index1)
      {
        case -3:
          chest = this.player.safe;
          break;
        case -2:
          chest = this.player.bank;
          break;
        case -1:
          return;
        default:
          chest = Main.chest[index1];
          break;
      }
      Color c = new Color((int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha);
      UI.inventoryScale = 1f;
      int x1 = 112 + INVENTORY_X - 56;
      int y1 = 56 + INVENTORY_Y + 56;
      SpriteSheet<_sheetSprites>.DrawTL((int) this.inventoryChestX >= 0 || (int) this.inventoryChestY != 1 ? 451 : 448, x1, y1, c, UI.inventoryScale);
      this.DrawInventoryItem(1085, x1, y1, Color.White);
      int y2 = y1 + 56;
      SpriteSheet<_sheetSprites>.DrawTL((int) this.inventoryChestX >= 0 || (int) this.inventoryChestY != 2 ? 451 : 448, x1, y2, c, UI.inventoryScale);
      this.DrawInventoryItem(213, x1, y2, Color.White);
      int y3 = y2 + 56;
      SpriteSheet<_sheetSprites>.DrawTL((int) this.inventoryChestX >= 0 || (int) this.inventoryChestY != 3 ? 451 : 448, x1, y3, c, UI.inventoryScale);
      this.DrawInventoryItem(1469, x1, y3, Color.White);
      if ((int) this.inventoryChestX < 0)
        this.toolTip.Init();
      for (int index2 = 0; index2 < 5; ++index2)
      {
        for (int index3 = 0; index3 < 4; ++index3)
        {
          int x2 = 112 + INVENTORY_X + index2 * 56;
          int y4 = 56 + INVENTORY_Y + index3 * 56;
          int index4 = index2 + index3 * 5;
          SpriteSheet<_sheetSprites>.DrawTL(444, x2, y4, c, UI.inventoryScale);
          if ((int) this.inventoryChestX == index2 && (int) this.inventoryChestY == index3)
          {
            this.DrawInventoryCursor(x2, y4, (double) UI.inventoryScale, (int) byte.MaxValue);
            this.toolTip = chest.item[index4];
          }
          if ((int) chest.item[index4].type > 0 && (int) chest.item[index4].stack > 0)
          {
            Color white = Color.White;
            this.DrawInventoryItem(ref chest.item[index4], x2, y4, white, UI.StackType.INVENTORY);
          }
        }
      }
      this.UpdateToolTipText((string) null);
      this.DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
      this.DrawControlsInventory();
    }

    private void UpdateShop()
    {
      int index = (int) this.inventoryChestX + (int) this.inventoryChestY * 5;
      if (this.IsButtonTriggered(Buttons.A))
      {
        if ((int) this.mouseItem.type == 0)
        {
          if ((int) this.player.selectedItem == index && (int) this.player.itemAnimation > 0 || !this.player.BuyItem(Main.shop[(int) this.npcShop].item[index].value))
            return;
          if (Main.shop[(int) this.npcShop].item[index].buyOnce)
          {
            int pre = (int) Main.shop[(int) this.npcShop].item[index].prefix;
            this.mouseItem.netDefaults((int) Main.shop[(int) this.npcShop].item[index].netID, 1);
            this.mouseItem.Prefix(pre);
          }
          else
          {
            this.mouseItem.netDefaults((int) Main.shop[(int) this.npcShop].item[index].netID, 1);
            this.mouseItem.Prefix(-1);
          }
          this.mouseItem.position.X = this.player.position.X + 10f - (float) ((int) this.mouseItem.width >> 1);
          this.mouseItem.position.Y = this.player.position.Y + 21f - (float) ((int) this.mouseItem.height >> 1);
          if (Main.shop[(int) this.npcShop].item[index].buyOnce)
          {
            --Main.shop[(int) this.npcShop].item[index].stack;
            if ((int) Main.shop[(int) this.npcShop].item[index].stack <= 0)
              Main.shop[(int) this.npcShop].item[index].Init();
          }
          Main.PlaySound(18);
        }
        else
        {
          if ((int) Main.shop[(int) this.npcShop].item[index].type != 0)
            return;
          if (this.player.SellItem(this.mouseItem.value, (int) this.mouseItem.stack))
          {
            Main.shop[(int) this.npcShop].AddShop(ref this.mouseItem);
            this.mouseItem.stack = (short) 0;
            this.mouseItem.type = (short) 0;
            Main.PlaySound(18);
          }
          else
          {
            if (this.mouseItem.value != 0)
              return;
            Main.shop[(int) this.npcShop].AddShop(ref this.mouseItem);
            this.mouseItem.stack = (short) 0;
            this.mouseItem.type = (short) 0;
            Main.PlaySound(7);
          }
        }
      }
      else
      {
        if ((int) this.stackSplit > 1 || !this.gpState.IsButtonDown(Buttons.RightTrigger) || (int) this.mouseItem.netID != (int) Main.shop[(int) this.npcShop].item[index].netID && (int) this.mouseItem.type != 0 || ((int) this.mouseItem.stack >= (int) this.mouseItem.maxStack && (int) this.mouseItem.type != 0 || !this.player.BuyItem(Main.shop[(int) this.npcShop].item[index].value)))
          return;
        Main.PlaySound(18);
        if ((int) this.mouseItem.type == 0)
        {
          this.mouseItem.netDefaults((int) Main.shop[(int) this.npcShop].item[index].netID, 1);
          this.mouseItem.stack = (short) 0;
        }
        ++this.mouseItem.stack;
        this.stackSplit = (int) this.stackSplit != 0 ? this.stackDelay : (short) 15;
        if (!Main.shop[(int) this.npcShop].item[index].buyOnce)
          return;
        --Main.shop[(int) this.npcShop].item[index].stack;
        if ((int) Main.shop[(int) this.npcShop].item[index].stack > 0)
          return;
        Main.shop[(int) this.npcShop].item[index].Init();
      }
    }

    private void DrawShop(int INVENTORY_X, int INVENTORY_Y)
    {
      Color c = new Color((int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha);
      UI.inventoryScale = 1f;
      for (int index1 = 0; index1 < 5; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          int x = 112 + INVENTORY_X + index1 * 56;
          int y = 56 + INVENTORY_Y + index2 * 56;
          int index3 = index1 + index2 * 5;
          SpriteSheet<_sheetSprites>.DrawTL(445, x, y, c, UI.inventoryScale);
          if (this.inventorySection == UI.InventorySection.CHEST && (int) this.inventoryChestX == index1 && (int) this.inventoryChestY == index2)
          {
            this.DrawInventoryCursor(x, y, (double) UI.inventoryScale, (int) byte.MaxValue);
            this.toolTip = Main.shop[(int) this.npcShop].item[index3];
            this.toolTip.buy = true;
          }
          if ((int) Main.shop[(int) this.npcShop].item[index3].type > 0 && (int) Main.shop[(int) this.npcShop].item[index3].stack > 0)
          {
            Color white = Color.White;
            this.DrawInventoryItem(ref Main.shop[(int) this.npcShop].item[index3], x, y, white, UI.StackType.INVENTORY);
          }
        }
      }
      this.UpdateToolTipText((string) null);
      this.DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
      this.DrawControlsShop();
    }

    private void UpdateEquip()
    {
      if ((int) this.inventoryEquipY == 0)
      {
        if (!this.IsButtonTriggered(Buttons.A))
          return;
        int b = (int) this.inventoryEquipX + (int) this.inventoryBuffX;
        if ((int) this.player.buff[b].Time <= 0 || this.player.buff[b].IsDebuff())
          return;
        this.player.DelBuff(b);
        Main.PlaySound(12);
      }
      else
      {
        int slot = (int) this.inventoryEquipY != 4 ? ((int) this.inventoryEquipX != 0 ? (int) this.inventoryEquipY + 7 : (int) this.inventoryEquipY - 1) : 3 + (int) this.inventoryEquipX;
        if (this.IsButtonTriggered(Buttons.A))
        {
          if (this.reforge)
            this.Reforge(slot, true);
          else if (this.craftGuide)
          {
            this.CraftingGuide();
          }
          else
          {
            if ((int) this.mouseItem.type != 0 && ((int) this.mouseItem.headSlot < 0 || slot != 0 && slot != 8) && (((int) this.mouseItem.bodySlot < 0 || slot != 1 && slot != 9) && ((int) this.mouseItem.legSlot < 0 || slot != 2 && slot != 10)) && (!this.mouseItem.accessory || slot <= 2 || this.AccCheck(ref this.mouseItem, slot)))
              return;
            Item obj = this.mouseItem;
            this.mouseItem = this.player.armor[slot];
            this.player.armor[slot] = obj;
            this.mouseItemSrcSection = UI.InventorySection.EQUIP;
            this.mouseItemSrcX = this.inventoryEquipX;
            this.mouseItemSrcY = this.inventoryEquipY;
            if ((int) this.player.armor[slot].type == 0 || (int) this.player.armor[slot].stack < 1)
              this.player.armor[slot].Init();
            if ((int) this.mouseItem.type <= 0 && (int) this.player.armor[slot].type <= 0)
              return;
            Main.PlaySound(7);
          }
        }
        else
        {
          if (!this.IsButtonTriggered(Buttons.RightTrigger) || !this.player.armor[slot].isEquipable() || this.reforge)
            return;
          this.player.armor[slot] = this.player.armorSwap(ref this.player.armor[slot]);
        }
      }
    }

    private void DrawEquip(int INVENTORY_X, int INVENTORY_Y)
    {
      Color c1 = new Color((int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha);
      Color c2 = new Color((int) UI.invAlpha >> 1, (int) UI.invAlpha, (int) UI.invAlpha >> 1, (int) UI.invAlpha);
      UI.inventoryScale = 1f;
      int x1 = INVENTORY_X + 112;
      int y1 = INVENTORY_Y;
      Rectangle rect = new Rectangle();
      rect.Y = y1;
      rect.Width = 16;
      rect.Height = 56;
      if ((int) this.inventoryBuffX > 0)
      {
        rect.X = x1 - 16;
        SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect, SpriteEffects.FlipHorizontally);
      }
      if ((int) this.inventoryBuffX < 5)
      {
        rect.X = x1 + 280;
        SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect);
      }
      string extraInfo = (string) null;
      for (int index = 0; index < 5; ++index)
      {
        int type = (int) this.player.buff[(int) this.inventoryBuffX + index].Type;
        if ((int) this.inventoryEquipY == 0 && (int) this.inventoryEquipX == index)
        {
          this.DrawInventoryCursor(x1, y1, (double) UI.inventoryScale, (int) byte.MaxValue);
          this.toolTip.Init();
          string str = !Buff.IsDebuff(type) ? "<f c='#C0FFC0'>" : "<f c='#FFC0C0'>";
          if (type == 40)
            type += (int) this.player.pet;
          extraInfo = str + Buff.buffName[type] + "</f>\n" + Buff.buffTip[type];
        }
        else
          SpriteSheet<_sheetSprites>.DrawTL(442, x1, y1, c2, UI.inventoryScale);
        if (type > 0)
        {
          int itemTexId = 141 + type;
          if (type == 40)
            itemTexId += (int) this.player.pet;
          this.DrawInventoryItem(itemTexId, x1, y1, Color.White);
        }
        x1 += 56;
      }
      int x2 = INVENTORY_X + 112;
      int y2 = INVENTORY_Y + 88;
      for (int index = 0; index < 3; ++index)
      {
        if ((int) this.inventoryEquipX == 0 && (int) this.inventoryEquipY == index + 1)
        {
          this.DrawInventoryCursor(x2, y2, (double) UI.inventoryScale, (int) byte.MaxValue);
          this.toolTip = this.player.armor[index];
          this.toolTip.wornArmor = true;
        }
        else
          SpriteSheet<_sheetSprites>.DrawTL(442, x2, y2, c1, UI.inventoryScale);
        if ((int) this.player.armor[index].type > 0 && (int) this.player.armor[index].stack > 0)
        {
          Color itemColor = this.craftGuide && !this.player.armor[index].material || this.reforge && !this.player.armor[index].Prefix(-3) ? UI.DISABLED_COLOR : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          this.DrawInventoryItem(ref this.player.armor[index], x2, y2, itemColor, UI.StackType.NONE);
        }
        y2 += 56;
      }
      int y3 = y2 + 32;
      for (int index = 3; index < 8; ++index)
      {
        if ((int) this.inventoryEquipY == 4 && (int) this.inventoryEquipX == index - 3)
        {
          this.DrawInventoryCursor(x2, y3, (double) UI.inventoryScale, (int) byte.MaxValue);
          this.toolTip = this.player.armor[index];
        }
        else
          SpriteSheet<_sheetSprites>.DrawTL(442, x2, y3, c1, UI.inventoryScale);
        if ((int) this.player.armor[index].type > 0 && (int) this.player.armor[index].stack > 0)
        {
          Color itemColor = this.craftGuide && !this.player.armor[index].material || this.reforge && !this.player.armor[index].Prefix(-3) ? UI.DISABLED_COLOR : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          this.DrawInventoryItem(ref this.player.armor[index], x2, y3, itemColor, UI.StackType.NONE);
        }
        x2 += 56;
      }
      int x3 = x2 - 56;
      int y4 = INVENTORY_Y + 88;
      for (int index = 8; index < 11; ++index)
      {
        if ((int) this.inventoryEquipX == 4 && (int) this.inventoryEquipY == index - 7)
        {
          this.DrawInventoryCursor(x3, y4, (double) UI.inventoryScale, (int) byte.MaxValue);
          this.toolTip = this.player.armor[index];
          this.toolTip.social = true;
        }
        else
          SpriteSheet<_sheetSprites>.DrawTL(442, x3, y4, c1, UI.inventoryScale);
        if ((int) this.player.armor[index].type > 0 && (int) this.player.armor[index].stack > 0)
        {
          Color itemColor = this.craftGuide && !this.player.armor[index].material || this.reforge && !this.player.armor[index].Prefix(-3) ? UI.DISABLED_COLOR : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          this.DrawInventoryItem(ref this.player.armor[index], x3, y4, itemColor, UI.StackType.NONE);
        }
        y4 += 56;
      }
      this.DrawPlayer(this.player, new Vector2((float) (INVENTORY_X + 112 + 112), (float) (INVENTORY_Y + 88)), 3.75f);
      double num1 = (double) UI.DrawStringCT(UI.fontSmall, Lang.inter[6], INVENTORY_X + 112 + 140, INVENTORY_Y + 56 - 12, Color.White);
      double num2 = (double) UI.DrawStringCT(UI.fontSmall, Lang.inter[45], INVENTORY_X + 112 + 28, y4 - 12, Color.White);
      double num3 = (double) UI.DrawStringCT(UI.fontSmall, Lang.inter[11], x3 + 28, y4 - 12, Color.White);
      double num4 = (double) UI.DrawStringCT(UI.fontSmallOutline, ToStringExtensions.ToStringLookup((int) this.player.statDefense) + Lang.inter[10], INVENTORY_X + 112 + 140, y4 - 6, new Color(100, (int) byte.MaxValue, 200, (int) byte.MaxValue));
      this.UpdateToolTipText(extraInfo);
      this.DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
      this.DrawControlsInventory();
    }

    private void UpdateHousing()
    {
      int x = this.player.aabb.X >> 4;
      int y = this.player.aabb.Y >> 4;
      if (this.IsButtonTriggered(Buttons.X))
      {
        Main.PlaySound(12);
        if (!WorldGen.MoveNPC(x, y, -1))
          return;
        Main.NewText(Lang.inter[39], (int) byte.MaxValue, 240, 20);
      }
      else if (this.IsButtonTriggered(Buttons.Y))
      {
        Main.PlaySound(12);
        UI ui = this;
        int num = !ui.showNPCs ? 1 : 0;
        ui.showNPCs = num != 0;
      }
      else
      {
        if (!this.IsButtonTriggered(Buttons.A) || (int) this.inventoryHousingNpc < 0)
          return;
        Main.PlaySound(12);
        if (!WorldGen.MoveNPC(x, y, (int) this.inventoryHousingNpc))
          return;
        WorldGen.moveRoom(x, y, (int) this.inventoryHousingNpc);
        Main.PlaySound(12);
      }
    }

    private void DrawHousing(int INVENTORY_X, int INVENTORY_Y)
    {
      Color c = new Color((int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha);
      UI.inventoryScale = 1f;
      string extraInfo = (string) null;
      int x = INVENTORY_X;
      int y = INVENTORY_Y;
      for (int index1 = 0; index1 < 11; ++index1)
      {
        if (index1 == 6)
        {
          x += 240;
          y = INVENTORY_Y;
        }
        string s = (string) null;
        NPC npc = (NPC) null;
        int num = -1;
        for (int index2 = 0; index2 < 196; ++index2)
        {
          npc = Main.npc[index2];
          if ((int) npc.active != 0 && index1 + 1 == npc.getHeadTextureId())
          {
            num = index2;
            s = !npc.hasName() ? npc.displayName : npc.getName();
            break;
          }
        }
        if ((int) this.inventoryHousingX == index1 / 6 && (int) this.inventoryHousingY == index1 % 6)
        {
          this.DrawInventoryCursor(x, y, (double) UI.inventoryScale, (int) byte.MaxValue);
          this.inventoryHousingNpc = (short) num;
          if (s != null)
          {
            string str = s;
            if (index1 != 10 && Lang.lang <= 1)
              str = str + " the " + npc.name;
            extraInfo = str + (object) '\n' + Lang.inter[55 + index1];
          }
        }
        else
          SpriteSheet<_sheetSprites>.DrawTL(449, x, y, c, UI.inventoryScale);
        if (num >= 0)
        {
          this.DrawInventoryItem(index1 + 1256, x, y, Color.White);
          if (!npc.homeless)
            SpriteSheet<_sheetSprites>.DrawTL(437, x + 60 - 16, y - 8, Color.White, UI.inventoryScale);
          UI.DrawStringLC(UI.fontSmallOutline, s, x + 60, y + 30, Color.White);
        }
        y += 60;
      }
      this.UpdateToolTipText(extraInfo);
      this.DrawToolTip(INVENTORY_X + 864 - 322 - 8, INVENTORY_Y + 8, 344);
      this.DrawControlsHousing();
    }

    private void DrawMouseItem()
    {
      if ((int) this.mouseItem.stack <= 0)
      {
        this.mouseItem.Init();
      }
      else
      {
        if ((int) this.mouseItem.type <= 0 || (int) this.mouseItem.stack <= 0)
          return;
        UI.inventoryScale = UI.cursorScale;
        this.DrawInventoryItem(ref this.mouseItem, (int) this.mouseX + 6, (int) this.mouseY + 6, new Color(0, 0, 0, 128), UI.StackType.INVENTORY);
        this.DrawInventoryItem(ref this.mouseItem, (int) this.mouseX, (int) this.mouseY, Color.White, UI.StackType.INVENTORY);
      }
    }

    private void DrawInventoryMenu()
    {
      int num1 = this.view.SAFE_AREA_OFFSET_L;
      int y1 = this.view.SAFE_AREA_OFFSET_T;
      if ((int) this.view.viewWidth > 960)
        num1 = (int) this.view.viewWidth - 864 >> 1;
      bool flag1 = (int) this.player.chest != -1;
      bool flag2 = (int) this.npcShop > 0;
      bool flag3 = flag1 || flag2;
      int texId;
      switch (this.inventorySection)
      {
        case UI.InventorySection.CRAFTING:
          texId = 441;
          break;
        case UI.InventorySection.CHEST:
          texId = flag2 ? 445 : 444;
          break;
        case UI.InventorySection.EQUIP:
          texId = 442;
          break;
        case UI.InventorySection.HOUSING:
          texId = 449;
          break;
        default:
          texId = 451;
          break;
      }
      Main.DrawRect(texId, new Rectangle(num1, y1, 864, 446), 96, 0);
      Color c = new Color();
      int x = num1 + (864 - ((flag3 ? 4 : 3) * 43 + 56)) / 2;
      for (int index = 0; index < 5; ++index)
      {
        int itemTexId;
        switch ((byte) index)
        {
          case (byte) 0:
            itemTexId = 205;
            break;
          case (byte) 1:
            itemTexId = 440;
            break;
          case (byte) 2:
            if (flag2)
            {
              itemTexId = Chest.GetShopOwnerHeadTextureId((int) this.npcShop);
              break;
            }
            else if (flag1)
            {
              switch (this.player.chest)
              {
                case (short) -3:
                  itemTexId = 797;
                  break;
                case (short) -2:
                  itemTexId = 538;
                  break;
                default:
                  itemTexId = 499;
                  break;
              }
            }
            else
              continue;
          case (byte) 3:
            itemTexId = 219;
            break;
          default:
            itemTexId = 437;
            break;
        }
        int num2 = (int) this.inventorySection;
        float scaleTopLeft = this.inventoryMenuSectionScale[index];
        if (index == num2)
        {
          if ((double) scaleTopLeft < 1.0)
          {
            scaleTopLeft += 0.05f;
            this.inventoryMenuSectionScale[index] = scaleTopLeft;
          }
        }
        else if ((double) scaleTopLeft > 0.75)
        {
          scaleTopLeft -= 0.05f;
          this.inventoryMenuSectionScale[index] = scaleTopLeft;
        }
        int y2 = (int) ((double) y1 + 22.0 * (1.0 - (double) scaleTopLeft));
        int num3 = (int) (65.0 + 180.0 * (double) scaleTopLeft);
        if (index == num2)
        {
          c.R = (byte) 200;
          c.G = (byte) 200;
          c.B = (byte) 200;
          c.A = (byte) 200;
          SpriteSheet<_sheetSprites>.DrawTL(448, x, y2, c, scaleTopLeft);
        }
        else
        {
          c.R = (byte) 100;
          c.G = (byte) 100;
          c.B = (byte) 100;
          c.A = (byte) 100;
          SpriteSheet<_sheetSprites>.DrawTL(451, x, y2, c, scaleTopLeft);
        }
        UI.inventoryScale = scaleTopLeft;
        Color itemColor = !this.IsInventorySectionAvailable((UI.InventorySection) index) ? UI.DISABLED_COLOR : new Color(num3, num3, num3, num3);
        this.DrawInventoryItem(itemTexId, x, y2, itemColor);
        x += (int) (52.0 * (double) scaleTopLeft) + 4;
      }
      string s;
      switch (this.inventorySection)
      {
        case UI.InventorySection.CRAFTING:
          s = Lang.inter[25];
          break;
        case UI.InventorySection.ITEMS:
          s = Lang.inter[4];
          break;
        case UI.InventorySection.CHEST:
          if (flag2)
          {
            s = Lang.inter[28];
            break;
          }
          else
          {
            int num2 = (int) this.player.chest;
            switch (this.player.chest)
            {
              case (short) -3:
                s = Lang.inter[33];
                break;
              case (short) -2:
                s = Lang.inter[32];
                break;
              default:
                s = this.chestText;
                break;
            }
          }
        case UI.InventorySection.EQUIP:
          s = Lang.inter[45];
          break;
        default:
          s = Lang.inter[7];
          break;
      }
      if (this.reforge)
        s = s + " (" + Lang.inter[19] + (object) ')';
      double num4 = (double) UI.DrawStringCT(UI.fontSmall, s, num1 + 432, y1 + 44, Color.White);
      switch (this.inventorySection)
      {
        case UI.InventorySection.CRAFTING:
          this.DrawCrafting(num1, y1 + 80);
          break;
        case UI.InventorySection.ITEMS:
          this.DrawInventory(num1, y1 + 80);
          break;
        case UI.InventorySection.CHEST:
          if (flag2)
          {
            this.DrawShop(num1, y1 + 80);
            break;
          }
          else
          {
            this.DrawStorage(num1, y1 + 80);
            break;
          }
        case UI.InventorySection.EQUIP:
          this.DrawEquip(num1, y1 + 80);
          break;
        case UI.InventorySection.HOUSING:
          this.DrawHousing(num1, y1 + 80);
          break;
      }
      this.DrawMouseItem();
    }

    private void DrawCrafting(int CRAFTING_X, int CRAFTING_Y)
    {
      Color color1 = new Color();
      Color color2 = new Color((int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha, (int) UI.invAlpha);
      string extraInfo = (string) null;
      Main.DrawRectOpenAtTop(441, new Rectangle(CRAFTING_X, CRAFTING_Y + 48, 864, 318), 192, 0);
      int x1 = CRAFTING_X + 3;
      for (int index = 0; index < 6; ++index)
      {
        Rectangle rect = new Rectangle(x1, CRAFTING_Y + 8, (int) sbyte.MaxValue, 32);
        if (this.craftingCategory != (Recipe.Category) index)
          Main.DrawRectStraightBottom(441, rect, 192, 2);
        else
          Main.DrawRectOpenAtBottom(441, rect, 192, 0);
        SpriteSheet<_sheetSprites>.DrawCentered(206 + index, ref rect);
        x1 += 146;
      }
      int num1 = CRAFTING_X + 4 + 16;
      int num2 = CRAFTING_Y + 12 + 48;
      int count1 = this.currentRecipeCategory.Count;
      if (count1 > 0)
      {
        UI.inventoryScale = 1f;
        int num3 = (int) this.craftingRecipeY - Math.Sign(this.craftingRecipeScrollY);
        int num4 = Math.Min(8, this.currentRecipeCategory[(int) this.craftingRecipeY].recipes.Count) * 56;
        int num5 = (double) this.craftingRecipeScrollX == 0.0 ? 448 : num4;
        int num6 = Math.Min(5, count1) * 56;
        Rectangle rectangle = new Rectangle();
        for (int index1 = 0; index1 < 2; ++index1)
        {
          Main.spriteBatch.End();
          rectangle.X = num1;
          rectangle.Y = num2;
          if (index1 == 0)
          {
            rectangle.Width = 56;
            rectangle.Height = num6;
          }
          else
          {
            rectangle.Y += 56;
            rectangle.Width = num5;
            rectangle.Height = 56;
          }
          if (!this.view.isFullScreen())
          {
            rectangle.X >>= 1;
            rectangle.X += this.view.activeViewport.X;
            rectangle.Y >>= 1;
            rectangle.Y += this.view.activeViewport.Y;
            rectangle.Width >>= 1;
            rectangle.Height >>= 1;
          }
          WorldView.graphicsDevice.ScissorRectangle = rectangle;
          Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, WorldView.scissorTest, (Effect) this.view.screenProjection);
          int y = num2;
          int num7 = 1;
          if ((double) this.craftingRecipeScrollY != 0.0)
          {
            num7 = 2;
            y = y - 56 - (int) ((1.0 - (double) Math.Abs(this.craftingRecipeScrollY)) * 56.0) * Math.Sign(this.craftingRecipeScrollY);
            if (index1 == 1)
            {
              this.craftingRecipeScrollY *= this.craftingRecipeScrollMul;
              if ((double) Math.Abs(this.craftingRecipeScrollY) < 0.0178571436554194)
                this.craftingRecipeScrollY = 0.0f;
            }
          }
          for (int index2 = -num7; index2 < 5 + num7; ++index2)
          {
            int index3 = num3 + index2;
            if (index3 >= 0)
            {
              if (index3 >= count1)
              {
                int num8 = y - num2;
                if (num8 < num6)
                {
                  num6 = num8;
                  break;
                }
                else
                  break;
              }
              else
              {
                int num8 = 0;
                int x2 = num1;
                if ((double) this.craftingRecipeScrollX != 0.0 && index3 == (int) this.craftingRecipeY)
                {
                  num8 = 1;
                  int num9 = x2 - 56;
                  if (index1 == 0)
                  {
                    this.craftingRecipeScrollX *= this.craftingRecipeScrollMul;
                    if ((double) Math.Abs(this.craftingRecipeScrollX) < 0.0178571436554194)
                      this.craftingRecipeScrollX = 0.0f;
                  }
                  x2 = num9 - (int) ((1.0 - (double) Math.Abs(this.craftingRecipeScrollX)) * 56.0) * Math.Sign(this.craftingRecipeScrollX);
                }
                Recipe.SubCategoryList subCategoryList = this.currentRecipeCategory[index3];
                int num10 = index3 != (int) this.craftingRecipeY ? 0 : (int) this.craftingRecipeX - Math.Sign(this.craftingRecipeScrollX);
                int count2 = subCategoryList.recipes.Count;
                for (int index4 = -num8; index4 < 8 + num8; ++index4)
                {
                  int num9 = num10 + index4;
                  if (num9 < 0)
                    num9 += count2;
                  if (num8 != 0 || index4 < count2)
                  {
                    int index5 = num9 % subCategoryList.recipes.Count;
                    int index6 = (int) subCategoryList.recipes[index5];
                    Recipe r = Main.recipe[index6];
                    bool flag1 = this.player.CanCraftRecipe(r);
                    bool flag2 = index3 == (int) this.craftingRecipeY && index5 == (int) this.craftingRecipeX;
                    if (flag2)
                    {
                      this.craftingRecipe = r;
                      this.DrawInventoryCursor(x2, y, (double) UI.inventoryScale, this.craftingSection == UI.CraftingSection.RECIPES ? (int) byte.MaxValue : 96);
                      if (index1 == 0)
                      {
                        this.toolTip = r.createItem;
                        extraInfo = "(" + ToStringExtensions.ToStringLookup(this.player.CountPossession((int) this.toolTip.netID)) + Lang.menu[1];
                        this.UpdateToolTipText(extraInfo);
                      }
                    }
                    else
                    {
                      int id = index1 == 0 ? 443 : 450;
                      color1 = color2;
                      if (!flag1)
                      {
                        color1.R >>= 1;
                        color1.G >>= 1;
                        color1.B >>= 1;
                        color1.A >>= 1;
                      }
                      SpriteSheet<_sheetSprites>.DrawTL(id, x2, y, color1, UI.inventoryScale);
                    }
                    color1 = flag1 ? new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) : new Color(16, 16, 16, 128);
                    this.DrawInventoryItem(ref r.createItem, x2, y, color1, UI.StackType.INVENTORY);
                    if (this.player.recipesNew.Get(index6))
                    {
                      if (flag2)
                      {
                        this.player.recipesNew.Set(index6, false);
                      }
                      else
                      {
                        color1 = new Color(UI.cursorAlpha, UI.cursorAlpha, UI.cursorAlpha, UI.cursorAlpha);
                        SpriteSheet<_sheetTiles>.Draw(23, x2 + 56 - 16, y + 12, color1, (float) Main.frameCounter * 0.03978873f, (float) (0.8 + Math.Sin((double) Main.frameCounter * 0.0198943678864869) * 0.2));
                        SpriteSheet<_sheetTiles>.Draw(23, x2 + 28, y + 28, color1, (float) Main.frameCounter * 0.05305165f, (float) (0.6 + Math.Sin((double) Main.frameCounter * 0.0132629119243246) * 0.4));
                        SpriteSheet<_sheetTiles>.Draw(23, x2 + 28 - 12, y + 28 - 8, color1, (float) Main.frameCounter * 0.07957747f, (float) (0.7 + Math.Sin((double) Main.frameCounter * 0.00994718394324346) * 0.3));
                      }
                    }
                    x2 += 56;
                  }
                  else
                    break;
                }
              }
            }
            y += 56;
          }
        }
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) this.view.screenProjection);
        if ((double) this.craftingRecipeScrollX == 0.0 && (double) this.craftingRecipeScrollY == 0.0)
        {
          Rectangle rect = new Rectangle();
          if (num4 > 56)
          {
            rect.X = num1 - 16;
            rect.Y = num2 + 56;
            rect.Width = 16;
            rect.Height = 56;
            SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect, SpriteEffects.FlipHorizontally);
            rect.X += 10 + num4;
            SpriteSheet<_sheetSprites>.DrawCentered(136, ref rect);
          }
          if (count1 > 1)
          {
            if ((int) this.craftingRecipeY == 0)
            {
              num2 += 56;
              num6 -= 56;
            }
            rect.X = num1;
            rect.Y = num2 - 16;
            rect.Width = 56;
            rect.Height = 16;
            SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect, SpriteEffects.FlipVertically);
            rect.Y += num6 + 10;
            SpriteSheet<_sheetSprites>.DrawCentered(135, ref rect);
            if ((int) this.craftingRecipeY == 0)
            {
              num2 -= 56;
              int num7 = num6 + 56;
            }
          }
        }
        int x3 = num1 + 56 + 8;
        int y1 = num2 + 112 + 8;
        Main.DrawRect(441, new Rectangle(x3, y1, CRAFTING_X + 864 - 322 - 32 - x3, 174), 96, 0);
        UI.fontSmall.MeasureString(Lang.menu[0]);
        double num11 = (double) UI.DrawStringCT(UI.fontSmall, Lang.menu[0], x3 + 100, y1 + 150 - 6, Color.White);
        UI.inventoryScale = 0.9f;
        int index7 = 0;
        for (int index1 = 0; index1 < 3; ++index1)
        {
          int num7 = 0;
          while (num7 < 4)
          {
            int x2 = x3 + 50 * num7;
            int y2 = y1 + 50 * index1;
            if (this.craftingSection == UI.CraftingSection.INGREDIENTS && (num7 == (int) this.craftingIngredientX && index1 == (int) this.craftingIngredientY))
            {
              this.DrawInventoryCursor(x2, y2, (double) UI.inventoryScale, (int) byte.MaxValue);
              if (index7 < (int) this.craftingRecipe.numRequiredItems)
              {
                this.toolTip = this.craftingRecipe.requiredItem[index7];
                extraInfo = "(" + ToStringExtensions.ToStringLookup(this.player.CountPossession((int) this.toolTip.netID)) + Lang.menu[1];
                this.UpdateToolTipText(extraInfo);
              }
            }
            else
            {
              int id = 442;
              color1 = index7 >= (int) this.craftingRecipe.numRequiredItems ? new Color(64, 64, 64, 64) : color2;
              SpriteSheet<_sheetSprites>.DrawTL(id, x2, y2, color1, UI.inventoryScale);
            }
            if (index7 < (int) this.craftingRecipe.numRequiredItems)
              this.DrawInventoryItem(ref this.craftingRecipe.requiredItem[index7], x2, y2, new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), UI.StackType.INGREDIENT);
            ++num7;
            ++index7;
          }
        }
        int id1 = -1;
        Main.strBuilder.Length = 0;
        if ((int) this.craftingRecipe.numRequiredTiles > 0)
        {
          Main.strBuilder.Append(Main.tileName[(int) this.craftingRecipe.requiredTile[0]]);
          switch (this.craftingRecipe.requiredTile[0])
          {
            case (short) 114:
              id1 = 849;
              break;
            case (short) 134:
              id1 = 976;
              break;
            case (short) 101:
              id1 = 139;
              break;
            case (short) 106:
              id1 = 814;
              break;
            case (short) 86:
              id1 = 783;
              break;
            case (short) 94:
              id1 = 803;
              break;
            case (short) 96:
              id1 = 796;
              break;
            case (short) 13:
              id1 = 1;
              break;
            case (short) 14:
              id1 = 1480;
              Main.strBuilder.Append(" & ");
              Main.strBuilder.Append(Main.tileName[15]);
              break;
            case (short) 16:
              id1 = 486;
              break;
            case (short) 17:
              id1 = 484;
              break;
            case (short) 18:
              if ((int) this.craftingRecipe.requiredTile[1] == 15)
              {
                id1 = 1487;
                Main.strBuilder.Append(" & ");
                Main.strBuilder.Append(Main.tileName[15]);
                break;
              }
              else
              {
                id1 = 487;
                break;
              }
            case (short) 26:
              id1 = 212;
              break;
          }
        }
        else if (this.craftingRecipe.needWater)
        {
          id1 = 1484;
          Main.strBuilder.Append(Lang.inter[53]);
        }
        if (id1 >= 0)
        {
          Rectangle rect = new Rectangle();
          rect.X = x3 + 200 + 80;
          rect.Y = y1 + 18 + 28;
          rect.Width = 68;
          rect.Height = 68;
          Main.DrawRect(442, rect, 192, 0);
          int num7 = SpriteSheet<_sheetSprites>.src[id1].Width;
          int num8 = SpriteSheet<_sheetSprites>.src[id1].Height;
          float scaleCenter = num7 <= num8 ? 64f / (float) num8 : 64f / (float) num7;
          SpriteSheet<_sheetSprites>.DrawScaled(id1, ref new Vector2()
          {
            X = (float) rect.Center.X,
            Y = (float) rect.Center.Y
          }, Color.White, scaleCenter);
          double num9 = (double) UI.DrawStringCT(UI.fontSmall, rect.Center.X, rect.Bottom + 2, this.player.IsNearCraftingStation(this.craftingRecipe) ? Color.White : new Color((int) byte.MaxValue, 64, 64, (int) byte.MaxValue));
        }
        if (extraInfo != null)
          this.DrawToolTip(CRAFTING_X + 864 - 322 - 8, num2 + 8, 286);
      }
      this.DrawControlsCrafting();
    }

    private void DrawMiniMap()
    {
      int x1 = this.view.SAFE_AREA_OFFSET_L;
      int y1 = this.view.SAFE_AREA_OFFSET_T;
      int width = (int) this.view.viewWidth - this.view.SAFE_AREA_OFFSET_L - this.view.SAFE_AREA_OFFSET_R;
      int height = 540 - this.view.SAFE_AREA_OFFSET_T - this.view.SAFE_AREA_OFFSET_B - 36;
      Main.DrawRect(451, new Rectangle(x1, y1, width, height), 128, 0);
      int x2 = 31 + x1;
      int y2 = 2 + y1;
      if (this.mapScreenCursorX == 0 && this.mapScreenCursorY < 2)
        this.DrawInventoryCursor(x2, y2, 1.0, (int) byte.MaxValue);
      else
        SpriteSheet<_sheetSprites>.Draw(451, x2, y2);
      Color white = Color.White;
      if (this.pvpSelected)
      {
        SpriteSheet<_sheetSprites>.Draw(455, x2 + 9, y2 + 11, white);
        SpriteSheet<_sheetSprites>.Draw(455, x2 + 11, y2 + 11, white, SpriteEffects.FlipHorizontally);
      }
      else
      {
        SpriteSheet<_sheetSprites>.DrawRotatedTL(455, x2 - 7, y2 + 25, white, -0.785f);
        SpriteSheet<_sheetSprites>.DrawRotatedTL(455, x2 + 11, y2 + 25, white, -0.785f);
      }
      int num1 = x2 + 123;
      for (int index = 0; index < 5; ++index)
      {
        Color c = Main.teamColor[index];
        if (index == (int) this.teamSelected)
        {
          c.A = UI.mouseTextBrightness;
        }
        else
        {
          c.R >>= 1;
          c.G >>= 1;
          c.B >>= 1;
          c.A >>= 1;
        }
        int num2 = num1;
        int num3 = y2 + 3;
        if (index == 0)
        {
          num2 -= 32;
          num3 += 16;
        }
        else if (index != 1)
        {
          if (index == 2)
            num2 += 32;
          else if (index == 3)
          {
            num3 += 32;
          }
          else
          {
            num2 += 32;
            num3 += 32;
          }
        }
        int x3 = num2 - 8;
        int y3 = num3 - 8;
        if (index == 0 && this.mapScreenCursorX == 1 || index == 1 && this.mapScreenCursorX == 2 && this.mapScreenCursorY == 0 || (index == 2 && this.mapScreenCursorX == 3 && this.mapScreenCursorY == 0 || index == 3 && this.mapScreenCursorX == 2 && this.mapScreenCursorY == 1) || index == 4 && this.mapScreenCursorX == 3 && this.mapScreenCursorY == 1)
          this.DrawInventoryCursor(x3, y3, 8.0 / 13.0, (int) byte.MaxValue);
        else
          SpriteSheet<_sheetSprites>.DrawScaledTL(451, x3, y3, Color.White, 0.6153846f);
        SpriteSheet<_sheetSprites>.Draw(1481, x3 + 8, y3 + 8, c);
      }
      int num4 = x1;
      int num5 = 98 + y1;
      for (int index = 8; index > 0; --index)
      {
        int num2 = num5 + 44 * (index - 1);
        if (this.mapScreenCursorY - 1 == index)
          this.DrawInventoryCursor(num4 - 2, num2 - 2, 12.0 / 13.0, (int) byte.MaxValue);
        else
          SpriteSheet<_sheetSprites>.DrawScaledTL(451, num4 + 2, num2 + 2, Color.White, 0.7692308f);
      }
      Main.spriteBatch.End();
      GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
      for (int index = 0; index < ((ReadOnlyCollection<NetworkGamer>) allGamers).Count; ++index)
      {
        Player player = ((ReadOnlyCollection<NetworkGamer>) allGamers)[index].Tag as Player;
        if (player != null)
          this.DrawPlayerIcon(player, new Vector2((float) (num4 + 8), (float) (num5 + 8 + index * 44)), 1.5f);
      }
      this.miniMap.DrawMap(this.view);
      UI.DrawStringCC(UI.fontSmall, Lang.menu[81], x2 + 26, y2 + 69, Color.White);
      UI.DrawStringCC(UI.fontSmall, Lang.menu[82], num1 + 16, y2 + 69, Color.White);
      for (int index = 0; index < ((ReadOnlyCollection<NetworkGamer>) allGamers).Count; ++index)
      {
        Player player = ((ReadOnlyCollection<NetworkGamer>) allGamers)[index].Tag as Player;
        if (player != null)
        {
          int y3 = num5 + 4 + 44 * index;
          UI.DrawStringLT(UI.fontSmallOutline, player.name, num4 + 52, y3, Main.teamColor[(int) player.team]);
        }
      }
    }

    private bool AccCheck(ref Item newItem, int slot)
    {
      if ((int) this.player.armor[slot].netID == (int) newItem.netID)
        return false;
      for (int index = 3; index < 11; ++index)
      {
        if ((int) newItem.netID == (int) this.player.armor[index].netID)
          return true;
      }
      return false;
    }

    private void UpdateToolTipText(string extraInfo)
    {
      Main.strBuilder.Length = 0;
      string text;
      if ((int) this.toolTip.type > 0)
      {
        switch (this.toolTip.rare)
        {
          case (sbyte) -1:
            Main.strBuilder.Append("<f c='#828282'>");
            break;
          case (sbyte) 1:
            Main.strBuilder.Append("<f c='#9696FF'>");
            break;
          case (sbyte) 2:
            Main.strBuilder.Append("<f c='#96FF96'>");
            break;
          case (sbyte) 3:
            Main.strBuilder.Append("<f c='#FFC896'>");
            break;
          case (sbyte) 4:
            Main.strBuilder.Append("<f c='#FF9696'>");
            break;
          case (sbyte) 5:
            Main.strBuilder.Append("<f c='#FF96FF'>");
            break;
          case (sbyte) 6:
            Main.strBuilder.Append("<f c='#D2A0FF'>");
            break;
          default:
            Main.strBuilder.Append("<f c='#FFFFD2'>");
            break;
        }
        Main.strBuilder.Append(this.toolTip.AffixName());
        if ((int) this.toolTip.stack > 1)
          Main.strBuilder.Append(ToStringExtensions.ToStackString(this.toolTip.stack));
        Main.strBuilder.Append("</f>\n");
        if (extraInfo != null)
        {
          Main.strBuilder.Append(extraInfo);
          Main.strBuilder.Append('\n');
        }
        if ((int) this.npcShop > 0 || this.reforge && this.toolTip.Prefix(-3))
        {
          if (this.toolTip.value > 0)
          {
            int num1 = this.toolTip.value * (int) this.toolTip.stack;
            if (this.reforge)
              Main.strBuilder.Append(Lang.inter[46]);
            else if (this.toolTip.buy)
            {
              Main.strBuilder.Append(Lang.tip[50]);
            }
            else
            {
              num1 /= 5;
              Main.strBuilder.Append(Lang.tip[49]);
            }
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            if (num1 < 1)
              num1 = 1;
            if (num1 >= 1000000)
            {
              num2 = num1 / 1000000;
              num1 -= num2 * 1000000;
            }
            if (num1 >= 10000)
            {
              num3 = num1 / 10000;
              num1 -= num3 * 10000;
            }
            if (num1 >= 100)
            {
              num4 = num1 / 100;
              num1 -= num4 * 100;
            }
            if (num1 >= 1)
              num5 = num1;
            if (num2 > 0)
            {
              Main.strBuilder.Append("<f c='#DCDCC6'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num2));
              Main.strBuilder.Append(Lang.inter[15]);
              Main.strBuilder.Append("</f>");
            }
            if (num3 > 0)
            {
              Main.strBuilder.Append("<f c='#E0C95C'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num3));
              Main.strBuilder.Append(Lang.inter[16]);
              Main.strBuilder.Append("</f>");
            }
            if (num4 > 0)
            {
              Main.strBuilder.Append("<f c='#B5C0C1'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num4));
              Main.strBuilder.Append(Lang.inter[17]);
              Main.strBuilder.Append("</f>");
            }
            if (num5 > 0)
            {
              Main.strBuilder.Append("<f c='#F68A60'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num5));
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
        if (this.toolTip.material)
        {
          Main.strBuilder.Append("¤ ");
          Main.strBuilder.Append(Lang.tip[36]);
          Main.strBuilder.Append('\n');
        }
        if ((int) this.toolTip.createWall > 0 || (int) this.toolTip.createTile >= 0)
        {
          if ((int) this.toolTip.type != 213)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[33]);
            Main.strBuilder.Append('\n');
          }
        }
        else if ((int) this.toolTip.ammo > 0)
        {
          Main.strBuilder.Append("¤ ");
          Main.strBuilder.Append(Lang.tip[34]);
          Main.strBuilder.Append('\n');
        }
        else if (this.toolTip.consumable)
        {
          Main.strBuilder.Append("¤ ");
          Main.strBuilder.Append(Lang.tip[35]);
          Main.strBuilder.Append('\n');
        }
        if (this.toolTip.social)
        {
          Main.strBuilder.Append(Lang.tip[0]);
          Main.strBuilder.Append('\n');
          Main.strBuilder.Append(Lang.tip[1]);
          Main.strBuilder.Append('\n');
        }
        else
        {
          if ((int) this.toolTip.damage > 0)
          {
            int num1 = (int) this.toolTip.damage;
            int num2 = 0;
            if (this.toolTip.melee)
            {
              Main.strBuilder.Append("¤ ");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) ((double) this.player.meleeDamage * (double) num1)));
              Main.strBuilder.Append(Lang.tip[2]);
              num2 = (int) this.player.meleeCrit;
            }
            else if (this.toolTip.ranged)
            {
              Main.strBuilder.Append("¤ ");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) ((double) this.player.rangedDamage * (double) num1)));
              Main.strBuilder.Append(Lang.tip[3]);
              num2 = (int) this.player.rangedCrit;
            }
            else if (this.toolTip.magic)
            {
              Main.strBuilder.Append("¤ ");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) ((double) this.player.magicDamage * (double) num1)));
              Main.strBuilder.Append(Lang.tip[4]);
              num2 = (int) this.player.magicCrit;
            }
            int num3 = num2 - (int) this.player.inventory[(int) this.player.selectedItem].crit + (int) this.toolTip.crit;
            Main.strBuilder.Append("\n¤ ");
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num3));
            Main.strBuilder.Append(Lang.tip[5]);
            Main.strBuilder.Append('\n');
            if ((int) this.toolTip.useStyle > 0)
            {
              int index = 13;
              if ((int) this.toolTip.useAnimation <= 8)
                index = 6;
              else if ((int) this.toolTip.useAnimation <= 20)
                index = 7;
              else if ((int) this.toolTip.useAnimation <= 25)
                index = 8;
              else if ((int) this.toolTip.useAnimation <= 30)
                index = 9;
              else if ((int) this.toolTip.useAnimation <= 35)
                index = 10;
              else if ((int) this.toolTip.useAnimation <= 45)
                index = 11;
              else if ((int) this.toolTip.useAnimation <= 55)
                index = 12;
              Main.strBuilder.Append("¤ ");
              Main.strBuilder.Append(Lang.tip[index]);
              Main.strBuilder.Append('\n');
            }
            int index1 = 22;
            double num4 = (double) this.toolTip.knockBack;
            if (this.player.kbGlove)
              num4 *= 1.7;
            if (num4 == 0.0)
              index1 = 14;
            else if (num4 <= 1.5)
              index1 = 15;
            else if (num4 <= 3.0)
              index1 = 16;
            else if (num4 <= 4.0)
              index1 = 17;
            else if (num4 <= 6.0)
              index1 = 18;
            else if (num4 <= 7.0)
              index1 = 19;
            else if (num4 <= 9.0)
              index1 = 20;
            else if (num4 <= 11.0)
              index1 = 21;
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[index1]);
            Main.strBuilder.Append('\n');
          }
          if (this.toolTip.isEquipable())
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[23]);
            Main.strBuilder.Append('\n');
          }
          if (this.toolTip.vanity)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[24]);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.defense > 0)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup(this.toolTip.defense));
            Main.strBuilder.Append(Lang.tip[25]);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.pick > 0)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) this.toolTip.pick));
            Main.strBuilder.Append(Lang.tip[26]);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.axe > 0)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) this.toolTip.axe * 5));
            Main.strBuilder.Append(Lang.tip[27]);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.hammer > 0)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) this.toolTip.hammer));
            Main.strBuilder.Append(Lang.tip[28]);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.healLife > 0)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[29]);
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup(this.toolTip.healLife));
            Main.strBuilder.Append(Lang.tip[30]);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.healMana > 0)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[29]);
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup(this.toolTip.healMana));
            Main.strBuilder.Append(Lang.tip[31]);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.mana > 0 && ((int) this.toolTip.type != (int) sbyte.MaxValue || !this.player.spaceGun))
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[32]);
            Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) ((double) this.toolTip.mana * (double) this.player.manaCost)));
            Main.strBuilder.Append(Lang.tip[31]);
            Main.strBuilder.Append('\n');
          }
          string str1 = Lang.toolTip((int) this.toolTip.netID);
          if (str1 != null)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(str1);
            Main.strBuilder.Append('\n');
          }
          string str2 = Lang.toolTip2((int) this.toolTip.netID);
          if (str2 != null)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(str2);
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.buffTime > 0)
          {
            Main.strBuilder.Append("¤ ");
            if ((int) this.toolTip.buffTime / 60 >= 60)
            {
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) Math.Round((double) ((int) this.toolTip.buffTime / 60) / 60.0)));
              Main.strBuilder.Append(Lang.tip[37]);
            }
            else
            {
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup((int) Math.Round((double) this.toolTip.buffTime / 60.0)));
              Main.strBuilder.Append(Lang.tip[38]);
            }
            Main.strBuilder.Append('\n');
          }
          if ((int) this.toolTip.prefix > 0)
          {
            if ((int) UI.cpItem.netID != (int) this.toolTip.netID)
              UI.cpItem.netDefaults((int) this.toolTip.netID, 1);
            if ((int) UI.cpItem.damage != (int) this.toolTip.damage)
            {
              int num = (int) Math.Round((double) ((int) this.toolTip.damage - (int) UI.cpItem.damage) * 100.0 / (double) UI.cpItem.damage);
              if (num > 0)
                Main.strBuilder.Append("¤ <f c='#78BE78'>+");
              else
                Main.strBuilder.Append("¤ <f c='#BE7878'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num));
              Main.strBuilder.Append(Lang.tip[39]);
              Main.strBuilder.Append("</f>\n");
            }
            if ((int) UI.cpItem.useAnimation != (int) this.toolTip.useAnimation)
            {
              int num = (int) Math.Round((double) ((int) this.toolTip.useAnimation - (int) UI.cpItem.useAnimation) * 100.0 / (double) UI.cpItem.useAnimation);
              if (num > 0)
                Main.strBuilder.Append("¤ <f c='#78BE78'>+");
              else
                Main.strBuilder.Append("¤ <f c='#BE7878'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num));
              Main.strBuilder.Append(Lang.tip[40]);
              Main.strBuilder.Append("</f>\n");
            }
            if ((int) UI.cpItem.crit != (int) this.toolTip.crit)
            {
              int num = (int) this.toolTip.crit - (int) UI.cpItem.crit;
              if (num > 0)
                Main.strBuilder.Append("¤ <f c='#78BE78'>+");
              else
                Main.strBuilder.Append("¤ <f c='#BE7878'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num));
              Main.strBuilder.Append(Lang.tip[41]);
              Main.strBuilder.Append("</f>\n");
            }
            if ((int) UI.cpItem.mana != (int) this.toolTip.mana)
            {
              int num = (int) Math.Round((double) ((int) this.toolTip.mana - (int) UI.cpItem.mana) * 100.0 / (double) UI.cpItem.mana);
              if (num > 0)
                Main.strBuilder.Append("¤ <f c='#78BE78'>+");
              else
                Main.strBuilder.Append("¤ <f c='#BE7878'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num));
              Main.strBuilder.Append(Lang.tip[42]);
              Main.strBuilder.Append("</f>\n");
            }
            if ((double) UI.cpItem.scale != (double) this.toolTip.scale)
            {
              int num = (int) Math.Round(((double) this.toolTip.scale - (double) UI.cpItem.scale) * 100.0 / (double) UI.cpItem.scale);
              if (num > 0)
                Main.strBuilder.Append("¤ <f c='#78BE78'>+");
              else
                Main.strBuilder.Append("¤ <f c='#BE7878'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num));
              Main.strBuilder.Append(Lang.tip[43]);
              Main.strBuilder.Append("</f>\n");
            }
            if ((double) UI.cpItem.shootSpeed != (double) this.toolTip.shootSpeed)
            {
              int num = (int) Math.Round(((double) this.toolTip.shootSpeed - (double) UI.cpItem.shootSpeed) * 100.0 / (double) UI.cpItem.shootSpeed);
              if (num > 0)
                Main.strBuilder.Append("¤ <f c='#78BE78'>+");
              else
                Main.strBuilder.Append("¤ <f c='#BE7878'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num));
              Main.strBuilder.Append(Lang.tip[44]);
              Main.strBuilder.Append("</f>\n");
            }
            if ((double) UI.cpItem.knockBack != (double) this.toolTip.knockBack)
            {
              int num = (int) Math.Round(((double) this.toolTip.knockBack - (double) UI.cpItem.knockBack) * 100.0 / (double) UI.cpItem.knockBack);
              if (num > 0)
                Main.strBuilder.Append("¤ <f c='#78BE78'>+");
              else
                Main.strBuilder.Append("¤ <f c='#BE7878'>");
              Main.strBuilder.Append(ToStringExtensions.ToStringLookup(num));
              Main.strBuilder.Append(Lang.tip[45]);
              Main.strBuilder.Append("</f>\n");
            }
            switch (this.toolTip.prefix)
            {
              case (byte) 62:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
                Main.strBuilder.Append(Lang.tip[25]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 63:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
                Main.strBuilder.Append(Lang.tip[25]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 64:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
                Main.strBuilder.Append(Lang.tip[25]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 65:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
                Main.strBuilder.Append(Lang.tip[25]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 66:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+20");
                Main.strBuilder.Append(Lang.tip[31]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 67:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
                Main.strBuilder.Append(Lang.tip[5]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 68:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
                Main.strBuilder.Append(Lang.tip[5]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 69:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
                Main.strBuilder.Append(Lang.tip[39]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 70:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
                Main.strBuilder.Append(Lang.tip[39]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 71:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
                Main.strBuilder.Append(Lang.tip[39]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 72:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
                Main.strBuilder.Append(Lang.tip[39]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 73:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
                Main.strBuilder.Append(Lang.tip[46]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 74:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
                Main.strBuilder.Append(Lang.tip[46]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 75:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
                Main.strBuilder.Append(Lang.tip[46]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 76:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
                Main.strBuilder.Append(Lang.tip[46]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 77:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+1");
                Main.strBuilder.Append(Lang.tip[47]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 78:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+2");
                Main.strBuilder.Append(Lang.tip[47]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 79:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+3");
                Main.strBuilder.Append(Lang.tip[47]);
                Main.strBuilder.Append("</f>\n");
                break;
              case (byte) 80:
                Main.strBuilder.Append("¤ <f c='#78BE78'>+4");
                Main.strBuilder.Append(Lang.tip[47]);
                Main.strBuilder.Append("</f>\n");
                break;
            }
          }
          if (this.toolTip.wornArmor && this.player.setBonus != null)
          {
            Main.strBuilder.Append("¤ ");
            Main.strBuilder.Append(Lang.tip[48]);
            Main.strBuilder.Append(this.player.setBonus);
            Main.strBuilder.Append('\n');
          }
        }
        text = ((object) Main.strBuilder).ToString();
      }
      else
        text = extraInfo ?? "";
      if (!(text != UI.toolTipText))
        return;
      UI.toolTipText = text;
      UI.compiledToolTipText = new CompiledText(text, 322, UI.styleFontSmallOutline, CompiledText.MarkupType.Html);
    }

    private void DrawToolTip(int TOOLTIP_X, int TOOLTIP_Y, int TOOLTIP_H)
    {
      Rectangle rectangle = new Rectangle(TOOLTIP_X, TOOLTIP_Y, 322, TOOLTIP_H);
      Main.DrawRect(451, rectangle, (int) byte.MaxValue, 0);
      UI.compiledToolTipText.Draw(Main.spriteBatch, rectangle, new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), new Color((int) byte.MaxValue, 212, 64, (int) byte.MaxValue));
    }

    public void OpenInventory()
    {
      this.inventoryMode = (byte) 1;
      this.oldMouseX = this.mouseX;
      this.oldMouseY = this.mouseY;
      this.ClearButtonTriggers();
      if ((double) this.worldFadeTarget > 0.5)
        this.worldFadeTarget = 0.5f;
      this.craftingRecipeX = (sbyte) 0;
      this.craftingRecipeY = (sbyte) 0;
      this.player.AdjTiles();
      if ((int) this.npcShop > 0)
      {
        this.restoreOldInventorySection = true;
        this.oldInventorySection = this.inventorySection;
        this.inventorySection = UI.InventorySection.CHEST;
        this.inventoryChestX = (sbyte) 0;
        this.inventoryChestY = (sbyte) 0;
      }
      else if ((int) this.player.chest != -1)
      {
        this.restoreOldInventorySection = true;
        this.oldInventorySection = this.inventorySection;
        this.inventorySection = UI.InventorySection.CHEST;
        this.inventoryChestX = (sbyte) -1;
        this.inventoryChestY = (sbyte) 1;
      }
      else if (this.reforge || this.craftGuide)
      {
        this.restoreOldInventorySection = true;
        this.oldInventorySection = this.inventorySection;
        this.inventorySection = UI.InventorySection.ITEMS;
      }
      else
      {
        if (this.inventorySection != UI.InventorySection.CRAFTING)
          return;
        Recipe.FindRecipes(this, this.craftingCategory, this.craftingShowCraftable);
      }
    }

    public void CloseInventory()
    {
      if ((int) this.inventoryMode <= 0)
        return;
      if (this.restoreOldInventorySection)
      {
        this.restoreOldInventorySection = false;
        this.inventorySection = this.oldInventorySection;
      }
      this.inventoryMode = (byte) 0;
      this.player.chest = (short) -1;
      this.player.talkNPC = (short) -1;
      this.npcShop = (byte) 0;
      this.reforge = false;
      this.craftGuide = false;
      this.mouseX = this.oldMouseX;
      this.mouseY = this.oldMouseY;
      this.toolTip.Init();
      this.ClearButtonTriggers();
      if ((double) this.worldFadeTarget == 0.5)
        this.worldFadeTarget = 1f;
      this.hotbarItemNameTime = 210;
    }

    private bool IsInventorySectionAvailable(UI.InventorySection section)
    {
      bool flag = (int) this.player.chest != -1 || (int) this.npcShop > 0;
      switch (section)
      {
        case UI.InventorySection.CRAFTING:
          if ((int) this.mouseItem.type != 0 || this.reforge)
            return false;
          if (this.craftGuide)
            return (int) this.guideItem.type > 0;
          else
            return true;
        case UI.InventorySection.CHEST:
          return flag;
        case UI.InventorySection.EQUIP:
          if ((int) this.mouseItem.type != 0)
            return this.mouseItem.isEquipable();
          else
            return true;
        case UI.InventorySection.HOUSING:
          if ((int) this.mouseItem.type == 0 && !this.reforge)
            return !this.craftGuide;
          else
            return false;
        default:
          return true;
      }
    }

    private void UpdateInventoryMenu()
    {
      int num = (int) this.inventorySection;
      bool flag1 = true;
      bool flag2 = this.IsButtonTriggered(Buttons.RightShoulder);
      bool flag3 = this.IsButtonTriggered(Buttons.LeftShoulder);
      do
      {
        if (flag2)
        {
          if (++num == 5)
            num = 0;
        }
        else if (flag3)
        {
          if (--num < 0)
            num = 4;
        }
        else if (!flag1)
          num = 1;
        flag1 = this.IsInventorySectionAvailable((UI.InventorySection) num);
      }
      while (!flag1);
      this.inventorySection = (UI.InventorySection) num;
      if (flag3 || flag2)
      {
        this.toolTip.Init();
        if (this.inventorySection == UI.InventorySection.CRAFTING)
          Recipe.FindRecipes(this, this.craftingCategory, this.craftingShowCraftable);
      }
      if (this.gpState.IsButtonUp(Buttons.RightTrigger) && this.gpState.IsButtonUp(Buttons.A))
        this.stackSplit = (short) 0;
      else if ((int) this.stackSplit > 0)
        --this.stackSplit;
      if ((int) this.stackSplit == 0)
      {
        this.stackCounter = (short) 0;
        this.stackDelay = (short) 7;
      }
      else
      {
        if ((int) ++this.stackCounter < 30)
          return;
        this.stackCounter = (short) 0;
        if ((int) --this.stackDelay >= 2)
          return;
        this.stackDelay = (short) 2;
      }
    }

    public void PositionInventoryCursor(int dx, int dy)
    {
      do
      {
        do
        {
          do
          {
            do
            {
              switch (this.inventorySection - (byte) 1)
              {
                case UI.InventorySection.CRAFTING:
                  this.inventoryItemX += (sbyte) dx;
                  if ((int) this.inventoryItemX < 0)
                    this.inventoryItemX += (sbyte) 10;
                  else if ((int) this.inventoryItemX >= 10)
                    this.inventoryItemX -= (sbyte) 10;
                  this.inventoryItemY += (sbyte) dy;
                  if ((int) this.inventoryItemY < 0)
                    this.inventoryItemY += (sbyte) 7;
                  else if ((int) this.inventoryItemY >= 7)
                    this.inventoryItemY -= (sbyte) 7;
                  if ((int) this.inventoryItemY == 4)
                  {
                    if (this.reforge)
                    {
                      dy |= 1;
                      continue;
                    }
                    else if ((int) this.inventoryItemX >= 6)
                      goto label_18;
                    else
                      continue;
                  }
                  else if ((int) this.inventoryItemY == 5)
                  {
                    if (this.reforge)
                    {
                      dy |= 1;
                      continue;
                    }
                    else if ((int) this.inventoryItemX >= 6)
                      goto label_18;
                    else
                      continue;
                  }
                  else
                    continue;
                case UI.InventorySection.ITEMS:
                  goto label_19;
                case UI.InventorySection.CHEST:
                  goto label_36;
                case UI.InventorySection.EQUIP:
                  goto label_52;
                default:
                  continue;
              }
            }
            while ((int) this.inventoryItemY == 6 && (int) this.inventoryItemX < 9);
label_18:
            this.UpdateInventory();
            return;
label_19:
            this.inventoryChestX += (sbyte) dx;
            if ((int) this.inventoryChestX < -1)
              this.inventoryChestX += (sbyte) 6;
            else if ((int) this.inventoryChestX >= 5)
              this.inventoryChestX -= (sbyte) 6;
            this.inventoryChestY += (sbyte) dy;
            if ((int) this.inventoryChestY < 0)
              this.inventoryChestY += (sbyte) 4;
            else if ((int) this.inventoryChestY >= 4)
              this.inventoryChestY -= (sbyte) 4;
            if ((int) this.inventoryChestX < 0)
            {
              if ((int) this.npcShop <= 0 && (int) this.mouseItem.type <= 0)
                goto label_31;
            }
            else
              goto label_33;
          }
          while (dx != 0);
          this.inventoryChestX = (sbyte) 0;
          continue;
label_31:
          if ((int) this.inventoryChestY == 0)
            this.inventoryChestY = (sbyte) 1;
label_33:
          if ((int) this.npcShop > 0)
          {
            this.UpdateShop();
            return;
          }
          else
          {
            this.UpdateStorage();
            return;
          }
label_36:
          this.inventoryEquipY += (sbyte) dy;
          if ((int) this.inventoryEquipY < 0)
            this.inventoryEquipY += (sbyte) 5;
          else if ((int) this.inventoryEquipY >= 5)
            this.inventoryEquipY -= (sbyte) 5;
          this.inventoryEquipX += (sbyte) dx;
          if ((int) this.inventoryEquipX < 0)
          {
            if ((int) this.inventoryEquipY == 0)
            {
              this.inventoryEquipX = (sbyte) 0;
              if ((int) --this.inventoryBuffX < 0)
                this.inventoryBuffX = (sbyte) 0;
            }
            else
              this.inventoryEquipX += (sbyte) 5;
          }
          else if ((int) this.inventoryEquipX >= 5)
          {
            if ((int) this.inventoryEquipY == 0)
            {
              this.inventoryEquipX = (sbyte) 4;
              if ((int) ++this.inventoryBuffX > 5)
                this.inventoryBuffX = (sbyte) 5;
            }
            else
              this.inventoryEquipX -= (sbyte) 5;
          }
        }
        while ((int) this.inventoryEquipX >= 1 && (int) this.inventoryEquipX <= 3 && ((int) this.inventoryEquipY >= 1 && (int) this.inventoryEquipY <= 3));
        this.UpdateEquip();
        return;
label_52:
        if (dx != 0)
          this.inventoryHousingX ^= (sbyte) 1;
        this.inventoryHousingY += (sbyte) dy;
        if ((int) this.inventoryHousingY < 0)
          this.inventoryHousingY += (sbyte) 6;
        else if ((int) this.inventoryHousingY >= 6)
          this.inventoryHousingY -= (sbyte) 6;
      }
      while ((int) this.inventoryHousingX == 1 && (int) this.inventoryHousingY == 5);
      this.UpdateHousing();
    }

    private bool UpdateCraftButtonInput(Recipe r)
    {
      if ((int) this.stackSplit > 1 || !this.gpState.IsButtonDown(Buttons.A) || !this.player.CanCraftRecipe(r))
        return false;
      int num1 = (int) this.mouseItem.type;
      short num2 = this.mouseItem.stack;
      this.mouseItem = r.createItem;
      this.mouseItem.Prefix(-1);
      this.mouseItem.stack += num2;
      this.mouseItem.position.X = (float) (this.player.aabb.X + 10 - ((int) this.mouseItem.width >> 1));
      this.mouseItem.position.Y = (float) (this.player.aabb.Y + 21 - ((int) this.mouseItem.height >> 1));
      this.mouseItemSrcSection = UI.InventorySection.CRAFTING;
      this.mouseItemSrcX = (sbyte) -1;
      this.mouseItemSrcY = (sbyte) -1;
      r.Create(this);
      if ((int) this.mouseItem.type > 0 || (int) r.createItem.type > 0)
        Main.PlaySound(7);
      if (num1 == 0)
      {
        this.stackSplit = (int) this.stackSplit != 0 ? this.stackDelay : (short) 15;
        this.player.GetItem(ref this.mouseItem);
      }
      return true;
    }

    private void PrevCraftingCategory()
    {
      int num;
      if ((num = (int) (this.craftingCategory - (byte) 1)) < 0)
        num = 5;
      Recipe.FindRecipes(this, (Recipe.Category) num, this.craftingShowCraftable);
      this.craftingCategory = (Recipe.Category) num;
      this.craftingRecipeX = (sbyte) 0;
      this.craftingRecipeY = (sbyte) 0;
      this.craftingRecipeScrollX = 0.0f;
      this.craftingRecipeScrollY = 0.0f;
    }

    private void NextCraftingCategory()
    {
      int num;
      if ((num = (int) (this.craftingCategory + (byte) 1)) == 6)
        num = 0;
      Recipe.FindRecipes(this, (Recipe.Category) num, this.craftingShowCraftable);
      this.craftingCategory = (Recipe.Category) num;
      this.craftingRecipeX = (sbyte) 0;
      this.craftingRecipeY = (sbyte) 0;
      this.craftingRecipeScrollX = 0.0f;
      this.craftingRecipeScrollY = 0.0f;
    }

    public void PositionCraftingCursor(int dx, int dy)
    {
      if (this.IsButtonUntriggered(Buttons.X) && (int) this.mouseItem.type == 0)
      {
        UI ui = this;
        int num = !ui.craftingShowCraftable ? 1 : 0;
        ui.craftingShowCraftable = num != 0;
        this.craftingRecipeX = (sbyte) 0;
        this.craftingRecipeScrollX = 0.0f;
        this.craftingRecipeScrollY = 0.0f;
        Recipe.FindRecipes(this, this.craftingCategory, this.craftingShowCraftable);
      }
      else if (this.IsButtonUntriggered(Buttons.A))
      {
        Recipe.FindRecipes(this, this.craftingCategory, this.craftingShowCraftable);
      }
      else
      {
        if (this.UpdateCraftButtonInput(this.craftingRecipe))
          return;
        if (this.IsButtonTriggered(Buttons.Y))
          this.craftingSection = this.craftingSection ^ UI.CraftingSection.INGREDIENTS;
        else if (this.IsButtonTriggered(Buttons.LeftTrigger))
          this.PrevCraftingCategory();
        else if (this.IsButtonTriggered(Buttons.RightTrigger))
          this.NextCraftingCategory();
        else if (dx != 0 || dy != 0)
        {
          if ((double) this.craftingRecipeScrollMul >= 0.324999988079071)
            this.craftingRecipeScrollMul -= 0.075f;
          if (this.craftingSection == UI.CraftingSection.RECIPES)
          {
            if (dx != 0)
            {
              if ((double) this.craftingRecipeScrollX != 0.0 || (double) this.craftingRecipeScrollY != 0.0 || this.currentRecipeCategory.Count == 0)
                return;
              int count = this.currentRecipeCategory[(int) this.craftingRecipeY].recipes.Count;
              if (count == 1)
                return;
              int num = (int) this.craftingRecipeX + dx;
              if (num < 0)
                num += count;
              else if (num >= count)
                num -= count;
              this.craftingRecipeX = (sbyte) num;
              this.craftingRecipeScrollX = (float) dx;
            }
            else
            {
              if ((double) this.craftingRecipeScrollX != 0.0 || (double) this.craftingRecipeScrollY != 0.0)
                return;
              this.craftingRecipeX = (sbyte) 0;
              int num = (int) this.craftingRecipeY + dy;
              int count = this.currentRecipeCategory.Count;
              if (num < 0)
                num += count;
              else if (num >= count)
                num -= count;
              else
                this.craftingRecipeScrollY = (float) dy;
              this.craftingRecipeY = (sbyte) num;
            }
          }
          else
          {
            int num1 = (int) this.craftingIngredientX + dx;
            if (num1 < 0)
              num1 += 4;
            else if (num1 >= 4)
              num1 -= 4;
            this.craftingIngredientX = (sbyte) num1;
            int num2 = (int) this.craftingIngredientY + dy;
            if (num2 < 0)
              num2 += 3;
            else if (num2 >= 3)
              num2 -= 3;
            this.craftingIngredientY = (sbyte) num2;
          }
        }
        else
          this.craftingRecipeScrollMul = 13.0 / 16.0;
      }
    }

    public void PositionMapScreenCursor(int dx, int dy)
    {
      if (this.IsButtonTriggered(Buttons.A))
      {
        Main.PlaySound(10);
        if (this.mapScreenCursorX == 0)
        {
          if (this.mapScreenCursorY < 2)
          {
            this.pvpCooldown = (short) 180;
            UI ui = this;
            int num = !ui.pvpSelected ? 1 : 0;
            ui.pvpSelected = num != 0;
          }
          else
          {
            if (!this.CanViewGamerCard() || Netplay.session == null)
              return;
            GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
            int index = this.mapScreenCursorY - 2;
            if (index >= ((ReadOnlyCollection<NetworkGamer>) allGamers).Count)
              return;
            this.ShowGamerCard((Gamer) ((ReadOnlyCollection<NetworkGamer>) allGamers)[index]);
          }
        }
        else
        {
          this.teamCooldown = (short) 180;
          if (this.mapScreenCursorY == 0)
            this.teamSelected = (byte) (this.mapScreenCursorX - 1);
          else
            this.teamSelected = this.mapScreenCursorX == 1 ? (byte) 0 : (byte) (this.mapScreenCursorX + 1);
        }
      }
      else if (this.IsButtonTriggered(Buttons.X) && this.CanCommunicate())
      {
        if (Main.netMode <= 0 || Netplay.gamer == null || Guide.IsVisible)
          return;
        Main.PlaySound(10);
        bool flag;
        do
        {
          flag = false;
          try
          {
            Guide.ShowGameInvite(this.controller, (IEnumerable<Gamer>) null);
          }
          catch (GuideAlreadyVisibleException ex)
          {
            Thread.Sleep(32);
            flag = true;
          }
        }
        while (flag);
      }
      else if (this.IsButtonTriggered(Buttons.Y))
      {
        if (this.signedInGamer.PartySize <= 1 || Main.netMode <= 0 || (Netplay.gamer == null || this.localGamer == null))
          return;
        this.localGamer.SendPartyInvites();
      }
      else
      {
        if (dy != 0)
        {
          do
          {
            this.mapScreenCursorY += dy;
          }
          while (this.mapScreenCursorX == 0 && this.mapScreenCursorY == 1);
          dy = this.mapScreenCursorX > 0 ? 2 : 10;
          if (this.mapScreenCursorY < 0)
            this.mapScreenCursorY += dy;
          else if (this.mapScreenCursorY >= dy)
            this.mapScreenCursorY -= dy;
        }
        if (this.mapScreenCursorY >= 2)
          return;
        this.mapScreenCursorX += dx;
        if (this.mapScreenCursorX < 0)
        {
          this.mapScreenCursorX += 4;
        }
        else
        {
          if (this.mapScreenCursorX < 4)
            return;
          this.mapScreenCursorX -= 4;
        }
      }
    }

    public void FoundPotentialArmor(int itemType)
    {
      if (!this.TriggerCheckEnabled(Trigger.CollectedAllArmor))
        return;
      this.armorFound.Set(itemType, true);
      if (!this.armorFound.Get(604) || !this.armorFound.Get(607) || (!this.armorFound.Get(610) || !this.armorFound.Get(605)) || (!this.armorFound.Get(608) || !this.armorFound.Get(611) || (!this.armorFound.Get(606) || !this.armorFound.Get(609))) || (!this.armorFound.Get(612) || !this.armorFound.Get(558) || (!this.armorFound.Get(559) || !this.armorFound.Get(553)) || (!this.armorFound.Get(551) || !this.armorFound.Get(552) || (!this.armorFound.Get(400) || !this.armorFound.Get(402)))) || (!this.armorFound.Get(401) || !this.armorFound.Get(403) || (!this.armorFound.Get(404) || !this.armorFound.Get(376)) || (!this.armorFound.Get(377) || !this.armorFound.Get(378) || (!this.armorFound.Get(379) || !this.armorFound.Get(380))) || (!this.armorFound.Get(371) || !this.armorFound.Get(372) || (!this.armorFound.Get(373) || !this.armorFound.Get(374)) || (!this.armorFound.Get(375) || !this.armorFound.Get(231) || (!this.armorFound.Get(232) || !this.armorFound.Get(233))))) || (!this.armorFound.Get(151) || !this.armorFound.Get(152) || (!this.armorFound.Get(153) || !this.armorFound.Get(228)) || (!this.armorFound.Get(229) || !this.armorFound.Get(230) || (!this.armorFound.Get(102) || !this.armorFound.Get(101))) || (!this.armorFound.Get(100) || !this.armorFound.Get(123) || (!this.armorFound.Get(124) || !this.armorFound.Get(125)) || (!this.armorFound.Get(92) || !this.armorFound.Get(83) || (!this.armorFound.Get(79) || !this.armorFound.Get(91)))) || (!this.armorFound.Get(82) || !this.armorFound.Get(78) || (!this.armorFound.Get(90) || !this.armorFound.Get(81)) || (!this.armorFound.Get(77) || !this.armorFound.Get(89) || (!this.armorFound.Get(80) || !this.armorFound.Get(76))) || (!this.armorFound.Get(88) || !this.armorFound.Get(410) || !this.armorFound.Get(411)))))
        return;
      this.SetTriggerState(Trigger.CollectedAllArmor);
    }

    private void UpdateAlternateGrappleControls()
    {
      if (this.alternateGrappleControls)
      {
        this.BTN_JUMP2 = Buttons.LeftTrigger;
        this.BTN_GRAPPLE = Buttons.LeftStick;
      }
      else
      {
        this.BTN_JUMP2 = Buttons.LeftStick;
        this.BTN_GRAPPLE = Buttons.LeftTrigger;
      }
    }

    public bool IsJumpButtonDown()
    {
      if (!this.gpState.IsButtonDown(Buttons.A))
        return this.gpState.IsButtonDown(this.BTN_JUMP2);
      else
        return true;
    }

    public bool WasJumpButtonUp()
    {
      if (this.gpPrevState.IsButtonUp(Buttons.A))
        return this.gpPrevState.IsButtonUp(this.BTN_JUMP2);
      else
        return false;
    }

    public void ShowGamerCard(Gamer gamer)
    {
      if (gamer == null || Guide.IsVisible)
        return;
      bool flag;
      do
      {
        flag = false;
        try
        {
          Guide.ShowGamerCard(this.controller, gamer);
        }
        catch (GuideAlreadyVisibleException ex)
        {
          Thread.Sleep(32);
          flag = true;
        }
        catch (ObjectDisposedException ex)
        {
          gamer = Gamer.GetFromGamertag(gamer.Gamertag);
          flag = true;
        }
        catch (Exception ex)
        {
        }
      }
      while (flag);
    }

    public void SignOut()
    {
      if (this.signedInGamer == null)
        return;
      SignedInGamer gamer = this.signedInGamer;
      this.signedInGamer = (SignedInGamer) null;
      using (GamerCollection<SignedInGamer>.GamerCollectionEnumerator enumerator = Gamer.SignedInGamers.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          SignedInGamer current = enumerator.Current;
          if (current.PlayerIndex == this.controller && current.Gamertag == gamer.Gamertag)
            this.signedInGamer = current;
        }
      }
      if (this.signedInGamer != null)
      {
        if (Main.netMode > 0 && !this.HasOnline())
        {
          UI.Error(Lang.menu[5], Lang.inter[36], false);
          UI.main.ExitGame();
        }
        else
        {
          if (!Main.isGameStarted)
            return;
          this.wasRemovedFromSessionWithoutOurConsent = true;
          if (this != UI.main)
            return;
          for (int index = 0; index < ((ReadOnlyCollection<LocalNetworkGamer>) Netplay.session.LocalGamers).Count; ++index)
          {
            SignedInGamer signedInGamer = ((ReadOnlyCollection<LocalNetworkGamer>) Netplay.session.LocalGamers)[index].SignedInGamer;
            Main.ui[(int) signedInGamer.PlayerIndex].wasRemovedFromSessionWithoutOurConsent = true;
          }
        }
      }
      else
      {
        this.wasRemovedFromSessionWithoutOurConsent = false;
        MessageBox.RemoveMessagesFor(this.controller);
        UI.CancelInvite(gamer);
        this.blacklist.Clear();
        if (this == UI.main)
        {
          Netplay.StopFindingSessions();
          if (Main.worldGenThread != null)
          {
            Main.worldGenThread.Abort();
            Main.worldGenThread = (Thread) null;
            WorldGen.gen = false;
          }
          if (this.playerStorage != null)
          {
            ((Collection<IGameComponent>) UI.theGame.Components).Remove((IGameComponent) this.playerStorage);
            this.playerStorage.Dispose();
            this.playerStorage = (StorageDeviceManager) null;
          }
          if (UI.numActiveViews == 1 || Main.isGameStarted)
          {
            if (Main.isGameStarted)
              this.ExitGame();
            this.SetMenu(MenuMode.WELCOME, false, true);
            return;
          }
        }
        this.Exit();
      }
    }

    public bool TestStorageSpace(string container, string destinationPath, int writeSize)
    {
      using (StorageContainer storageContainer = this.OpenPlayerStorage(container))
      {
        long freeSpace = storageContainer.StorageDevice.FreeSpace;
        if (freeSpace >= (long) writeSize)
          return true;
        if (storageContainer.FileExists(destinationPath))
        {
          using (Stream stream = storageContainer.OpenFile(destinationPath, FileMode.Open, FileAccess.Read))
            freeSpace += stream.Length;
          if (freeSpace >= (long) writeSize)
          {
            storageContainer.DeleteFile(destinationPath);
            return true;
          }
        }
      }
      MessageBox.Show(this.controller, Lang.menu[5], Lang.inter[70], new string[1]
      {
        Lang.menu[90]
      }, 1 != 0);
      return false;
    }

    public void WriteError()
    {
      MessageBox.Show(this.controller, Lang.menu[5], Lang.gen[54], new string[1]
      {
        Lang.menu[90]
      }, 1 != 0);
    }

    public void ReadError()
    {
      MessageBox.Show(this.controller, Lang.menu[9], Lang.gen[53], new string[1]
      {
        Lang.menu[90]
      }, 1 != 0);
    }

    public void CheckHDTV()
    {
      if (Main.isHDTV)
        return;
      Main.isHDTV = true;
      MessageBox.Show(this.controller, Lang.menu[3], Lang.inter[71], new string[1]
      {
        Lang.menu[90]
      }, 1 != 0);
    }

    public bool CheckBlacklist()
    {
      ulong worldId = Main.GetWorldId();
      for (int index = this.blacklist.Count - 1; index >= 0; --index)
      {
        if ((long) this.blacklist[index] == (long) worldId)
        {
          if (this.menuType != MenuType.MAIN)
            this.menuType = MenuType.PAUSE;
          string[] options = new string[2]
          {
            this.menuType != MenuType.MAIN ? Lang.menu[100] : Lang.menu[15],
            Lang.inter[75]
          };
          MessageBox.Show(this.controller, Lang.menu[3], Lang.inter[74], options, false);
          this.SetMenu(MenuMode.BLACKLIST_REMOVE, true, false);
          return true;
        }
      }
      return false;
    }

    public void CheckUserGeneratedContent()
    {
      if (UI.IsUserGeneratedContentAllowed())
        return;
      this.menuType = MenuType.PAUSE;
      string[] options;
      if (this.autoSave || !UI.IsStorageEnabledForAnyPlayer())
        options = new string[1]
        {
          Lang.menu[15]
        };
      else
        options = new string[2]
        {
          Lang.inter[2],
          Lang.inter[1]
        };
      MessageBox.Show(this.controller, Lang.menu[3], Lang.inter[79], options, false);
      this.SetMenu(MenuMode.EXIT_UGC_BLOCKED, true, false);
    }

    public enum InventorySection : byte
    {
      CRAFTING,
      ITEMS,
      CHEST,
      EQUIP,
      HOUSING,
      NUM_SECTIONS,
    }

    public enum CraftingSection : byte
    {
      RECIPES,
      INGREDIENTS,
    }

    private enum StackType
    {
      NONE,
      INGREDIENT,
      INVENTORY,
      HOTBAR,
    }
  }
}
