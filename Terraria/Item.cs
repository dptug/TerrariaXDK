using System;
using Microsoft.Xna.Framework;

namespace Terraria;

public struct Item
{
	public enum ID
	{
		NONE,
		IRON_PICKAXE,
		DIRT_BLOCK,
		STONE_BLOCK,
		IRON_BROADSWORD,
		MUSHROOM,
		IRON_SHORTSWORD,
		IRON_HAMMER,
		TORCH,
		WOOD,
		IRON_AXE,
		IRON_ORE,
		COPPER_ORE,
		GOLD_ORE,
		SILVER_ORE,
		COPPER_WATCH,
		SILVER_WATCH,
		GOLD_WATCH,
		DEPTH_METER,
		GOLD_BAR,
		COPPER_BAR,
		SILVER_BAR,
		IRON_BAR,
		GEL,
		WOODEN_SWORD,
		WOODEN_DOOR,
		STONE_WALL,
		ACORN,
		LESSER_HEALING_POTION,
		LIFE_CRYSTAL,
		DIRT_WALL,
		BOTTLE,
		WOODEN_TABLE,
		FURNACE,
		WOODEN_CHAIR,
		IRON_ANVIL,
		WORK_BENCH,
		GOGGLES,
		LENS,
		WOODEN_BOW,
		WOODEN_ARROW,
		FLAMING_ARROW,
		SHURIKEN,
		SUSPICIOUS_LOOKING_EYE,
		DEMON_BOW,
		WAR_AXE_OF_THE_NIGHT,
		LIGHTS_BANE,
		UNHOLY_ARROW,
		CHEST,
		BAND_OF_REGENERATION,
		MAGIC_MIRROR,
		JESTERS_ARROW,
		ANGEL_STATUE,
		CLOUD_IN_A_BOTTLE,
		HERMES_BOOTS,
		ENCHANTED_BOOMERANG,
		DEMONITE_ORE,
		DEMONITE_BAR,
		HEART,
		CORRUPT_SEEDS,
		VILE_MUSHROOM,
		EBONSTONE_BLOCK,
		GRASS_SEEDS,
		SUNFLOWER,
		VILETHORN,
		STARFURY,
		PURIFICATION_POWDER,
		VILE_POWDER,
		ROTTEN_CHUNK,
		WORM_TOOTH,
		WORM_FOOD,
		COPPER_COIN,
		SILVER_COIN,
		GOLD_COIN,
		PLATINUM_COIN,
		FALLEN_STAR,
		COPPER_GREAVES,
		IRON_GREAVES,
		SILVER_GREAVES,
		GOLD_GREAVES,
		COPPER_CHAINMAIL,
		IRON_CHAINMAIL,
		SILVER_CHAINMAIL,
		GOLD_CHAINMAIL,
		GRAPPLING_HOOK,
		IRON_CHAIN,
		SHADOW_SCALE,
		PIGGY_BANK,
		MINING_HELMET,
		COPPER_HELMET,
		IRON_HELMET,
		SILVER_HELMET,
		GOLD_HELMET,
		WOOD_WALL,
		WOOD_PLATFORM,
		FLINTLOCK_PISTOL,
		MUSKET,
		MUSKET_BALL,
		MINISHARK,
		IRON_BOW,
		SHADOW_GREAVES,
		SHADOW_SCALEMAIL,
		SHADOW_HELMET,
		NIGHTMARE_PICKAXE,
		THE_BREAKER,
		CANDLE,
		COPPER_CHANDELIER,
		SILVER_CHANDELIER,
		GOLD_CHANDELIER,
		MANA_CRYSTAL,
		LESSER_MANA_POTION,
		BAND_OF_STARPOWER,
		FLOWER_OF_FIRE,
		MAGIC_MISSILE,
		DIRT_ROD,
		ORB_OF_LIGHT,
		METEORITE,
		METEORITE_BAR,
		HOOK,
		FLAMARANG,
		MOLTEN_FURY,
		FIERY_GREATSWORD,
		MOLTEN_PICKAXE,
		METEOR_HELMET,
		METEOR_SUIT,
		METEOR_LEGGINGS,
		BOTTLED_WATER,
		SPACE_GUN,
		ROCKET_BOOTS,
		GRAY_BRICK,
		GRAY_BRICK_WALL,
		RED_BRICK,
		RED_BRICK_WALL,
		CLAY_BLOCK,
		BLUE_BRICK,
		BLUE_BRICK_WALL,
		CHAIN_LANTERN,
		GREEN_BRICK,
		GREEN_BRICK_WALL,
		PINK_BRICK,
		PINK_BRICK_WALL,
		GOLD_BRICK,
		GOLD_BRICK_WALL,
		SILVER_BRICK,
		SILVER_BRICK_WALL,
		COPPER_BRICK,
		COPPER_BRICK_WALL,
		SPIKE,
		WATER_CANDLE,
		BOOK,
		COBWEB,
		NECRO_HELMET,
		NECRO_BREASTPLATE,
		NECRO_GREAVES,
		BONE,
		MURAMASA,
		COBALT_SHIELD,
		AQUA_SCEPTER,
		LUCKY_HORSESHOE,
		SHINY_RED_BALLOON,
		HARPOON,
		SPIKY_BALL,
		BALL_O_HURT,
		BLUE_MOON,
		HANDGUN,
		WATER_BOLT,
		BOMB,
		DYNAMITE,
		GRENADE,
		SAND_BLOCK,
		GLASS,
		SIGN,
		ASH_BLOCK,
		OBSIDIAN,
		HELLSTONE,
		HELLSTONE_BAR,
		MUD_BLOCK,
		SAPPHIRE,
		RUBY,
		EMERALD,
		TOPAZ,
		AMETHYST,
		DIAMOND,
		GLOWING_MUSHROOM,
		STAR,
		IVY_WHIP,
		BREATHING_REED,
		FLIPPER,
		HEALING_POTION,
		MANA_POTION,
		BLADE_OF_GRASS,
		THORN_CHAKRAM,
		OBSIDIAN_BRICK,
		OBSIDIAN_SKULL,
		MUSHROOM_GRASS_SEEDS,
		JUNGLE_GRASS_SEEDS,
		WOODEN_HAMMER,
		STAR_CANNON,
		BLUE_PHASEBLADE,
		RED_PHASEBLADE,
		GREEN_PHASEBLADE,
		PURPLE_PHASEBLADE,
		WHITE_PHASEBLADE,
		YELLOW_PHASEBLADE,
		METEOR_HAMAXE,
		EMPTY_BUCKET,
		WATER_BUCKET,
		LAVA_BUCKET,
		JUNGLE_ROSE,
		STINGER,
		VINE,
		FERAL_CLAWS,
		ANKLET_OF_THE_WIND,
		STAFF_OF_REGROWTH,
		HELLSTONE_BRICK,
		WHOOPIE_CUSHION,
		SHACKLE,
		MOLTEN_HAMAXE,
		FLAMELASH,
		PHOENIX_BLASTER,
		SUNFURY,
		HELLFORGE,
		CLAY_POT,
		NATURES_GIFT,
		BED,
		SILK,
		LESSER_RESTORATION_POTION,
		RESTORATION_POTION,
		JUNGLE_HAT,
		JUNGLE_SHIRT,
		JUNGLE_PANTS,
		MOLTEN_HELMET,
		MOLTEN_BREASTPLATE,
		MOLTEN_GREAVES,
		METEOR_SHOT,
		STICKY_BOMB,
		BLACK_LENS,
		SUNGLASSES,
		WIZARD_HAT,
		TOP_HAT,
		TUXEDO_SHIRT,
		TUXEDO_PANTS,
		SUMMER_HAT,
		BUNNY_HOOD,
		PLUMBERS_HAT,
		PLUMBERS_SHIRT,
		PLUMBERS_PANTS,
		HEROS_HAT,
		HEROS_SHIRT,
		HEROS_PANTS,
		FISH_BOWL,
		ARCHAEOLOGISTS_HAT,
		ARCHAEOLOGISTS_JACKET,
		ARCHAEOLOGISTS_PANTS,
		BLACK_DYE,
		PURPLE_DYE,
		NINJA_HOOD,
		NINJA_SHIRT,
		NINJA_PANTS,
		LEATHER,
		RED_HAT,
		GOLDFISH,
		ROBE,
		ROBOT_HAT,
		GOLD_CROWN,
		HELLFIRE_ARROW,
		SANDGUN,
		GUIDE_VOODOO_DOLL,
		DIVING_HELMET,
		FAMILIAR_SHIRT,
		FAMILIAR_PANTS,
		FAMILIAR_WIG,
		DEMON_SCYTHE,
		NIGHTS_EDGE,
		DARK_LANCE,
		CORAL,
		CACTUS,
		TRIDENT,
		SILVER_BULLET,
		THROWING_KNIFE,
		SPEAR,
		BLOWPIPE,
		GLOWSTICK,
		SEED,
		WOODEN_BOOMERANG,
		AGLET,
		STICKY_GLOWSTICK,
		POISONED_KNIFE,
		OBSIDIAN_SKIN_POTION,
		REGENERATION_POTION,
		SWIFTNESS_POTION,
		GILLS_POTION,
		IRONSKIN_POTION,
		MANA_REGENERATION_POTION,
		MAGIC_POWER_POTION,
		FEATHERFALL_POTION,
		SPELUNKER_POTION,
		INVISIBILITY_POTION,
		SHINE_POTION,
		NIGHT_OWL_POTION,
		BATTLE_POTION,
		THORNS_POTION,
		WATER_WALKING_POTION,
		ARCHERY_POTION,
		HUNTER_POTION,
		GRAVITATION_POTION,
		GOLD_CHEST,
		DAYBLOOM_SEEDS,
		MOONGLOW_SEEDS,
		BLINKROOT_SEEDS,
		DEATHWEED_SEEDS,
		WATERLEAF_SEEDS,
		FIREBLOSSOM_SEEDS,
		DAYBLOOM,
		MOONGLOW,
		BLINKROOT,
		DEATHWEED,
		WATERLEAF,
		FIREBLOSSOM,
		SHARK_FIN,
		FEATHER,
		TOMBSTONE,
		MIME_MASK,
		ANTLION_MANDIBLE,
		ILLEGAL_GUN_PARTS,
		THE_DOCTORS_SHIRT,
		THE_DOCTORS_PANTS,
		GOLDEN_KEY,
		SHADOW_CHEST,
		SHADOW_KEY,
		OBSIDIAN_BRICK_WALL,
		JUNGLE_SPORES,
		LOOM,
		PIANO,
		DRESSER,
		BENCH,
		BATHTUB,
		RED_BANNER,
		GREEN_BANNER,
		BLUE_BANNER,
		YELLOW_BANNER,
		LAMP_POST,
		TIKI_TORCH,
		BARREL,
		CHINESE_LANTERN,
		COOKING_POT,
		SAFE,
		SKULL_LANTERN,
		TRASH_CAN,
		CANDELABRA,
		PINK_VASE,
		MUG,
		KEG,
		ALE,
		BOOKCASE,
		THRONE,
		BOWL,
		BOWL_OF_SOUP,
		TOILET,
		GRANDFATHER_CLOCK,
		STATUE,
		GOBLIN_BATTLE_STANDARD,
		TATTERED_CLOTH,
		SAWMILL,
		COBALT_ORE,
		MYTHRIL_ORE,
		ADAMANTITE_ORE,
		PWNHAMMER,
		EXCALIBUR,
		HALLOWED_SEEDS,
		EBONSAND_BLOCK,
		COBALT_HAT,
		COBALT_HELMET,
		COBALT_MASK,
		COBALT_BREASTPLATE,
		COBALT_LEGGINGS,
		MYTHRIL_HOOD,
		MYTHRIL_HELMET,
		MYTHRIL_HAT,
		MYTHRIL_CHAINMAIL,
		MYTHRIL_GREAVES,
		COBALT_BAR,
		MYTHRIL_BAR,
		COBALT_CHAINSAW,
		MYTHRIL_CHAINSAW,
		COBALT_DRILL,
		MYTHRIL_DRILL,
		ADAMANTITE_CHAINSAW,
		ADAMANTITE_DRILL,
		DAO_OF_POW,
		MYTHRIL_HALBERD,
		ADAMANTITE_BAR,
		GLASS_WALL,
		COMPASS,
		DIVING_GEAR,
		GPS,
		OBSIDIAN_HORSESHOE,
		OBSIDIAN_SHIELD,
		TINKERERS_WORKSHOP,
		CLOUD_IN_A_BALLOON,
		ADAMANTITE_HEADGEAR,
		ADAMANTITE_HELMET,
		ADAMANTITE_MASK,
		ADAMANTITE_BREASTPLATE,
		ADAMANTITE_LEGGINGS,
		SPECTRE_BOOTS,
		ADAMANTITE_GLAIVE,
		TOOLBELT,
		PEARLSAND_BLOCK,
		PEARLSTONE_BLOCK,
		MINING_SHIRT,
		MINING_PANTS,
		PEARLSTONE_BRICK,
		IRIDESCENT_BRICK,
		MUDSTONE_BRICK,
		COBALT_BRICK,
		MYTHRIL_BRICK,
		PEARLSTONE_BRICK_WALL,
		IRIDESCENT_BRICK_WALL,
		MUDSTONE_BRICK_WALL,
		COBALT_BRICK_WALL,
		MYTHRIL_BRICK_WALL,
		HOLY_WATER,
		UNHOLY_WATER,
		SILT_BLOCK,
		FAIRY_BELL,
		BREAKER_BLADE,
		BLUE_TORCH,
		RED_TORCH,
		GREEN_TORCH,
		PURPLE_TORCH,
		WHITE_TORCH,
		YELLOW_TORCH,
		DEMON_TORCH,
		CLOCKWORK_ASSAULT_RIFLE,
		COBALT_REPEATER,
		MYTHRIL_REPEATER,
		DUAL_HOOK,
		STAR_STATUE,
		SWORD_STATUE,
		SLIME_STATUE,
		GOBLIN_STATUE,
		SHIELD_STATUE,
		BAT_STATUE,
		FISH_STATUE,
		BUNNY_STATUE,
		SKELETON_STATUE,
		REAPER_STATUE,
		WOMAN_STATUE,
		IMP_STATUE,
		GARGOYLE_STATUE,
		GLOOM_STATUE,
		HORNET_STATUE,
		BOMB_STATUE,
		CRAB_STATUE,
		HAMMER_STATUE,
		POTION_STATUE,
		SPEAR_STATUE,
		CROSS_STATUE,
		JELLYFISH_STATUE,
		BOW_STATUE,
		BOOMERANG_STATUE,
		BOOT_STATUE,
		CHEST_STATUE,
		BIRD_STATUE,
		AXE_STATUE,
		CORRUPT_STATUE,
		TREE_STATUE,
		ANVIL_STATUE,
		PICKAXE_STATUE,
		MUSHROOM_STATUE,
		EYEBALL_STATUE,
		PILLAR_STATUE,
		HEART_STATUE,
		POT_STATUE,
		SUNFLOWER_STATUE,
		KING_STATUE,
		QUEEN_STATUE,
		PIRANHA_STATUE,
		PLANKED_WALL,
		WOODEN_BEAM,
		ADAMANTITE_REPEATER,
		ADAMANTITE_SWORD,
		COBALT_SWORD,
		MYTHRIL_SWORD,
		MOON_CHARM,
		RULER,
		CRYSTAL_BALL,
		DISCO_BALL,
		SORCERER_EMBLEM,
		WARRIOR_EMBLEM,
		RANGER_EMBLEM,
		DEMON_WINGS,
		ANGEL_WINGS,
		MAGICAL_HARP,
		RAINBOW_ROD,
		ICE_ROD,
		NEPTUNES_SHELL,
		MANNEQUIN,
		GREATER_HEALING_POTION,
		GREATER_MANA_POTION,
		PIXIE_DUST,
		CRYSTAL_SHARD,
		CLOWN_HAT,
		CLOWN_SHIRT,
		CLOWN_PANTS,
		FLAMETHROWER,
		BELL,
		HARP,
		WRENCH,
		WIRE_CUTTER,
		ACTIVE_STONE_BLOCK,
		INACTIVE_STONE_BLOCK,
		LEVER,
		LASER_RIFLE,
		CRYSTAL_BULLET,
		HOLY_ARROW,
		MAGIC_DAGGER,
		CRYSTAL_STORM,
		CURSED_FLAMES,
		SOUL_OF_LIGHT,
		SOUL_OF_NIGHT,
		CURSED_FLAME,
		CURSED_TORCH,
		ADAMANTITE_FORGE,
		MYTHRIL_ANVIL,
		UNICORN_HORN,
		DARK_SHARD,
		LIGHT_SHARD,
		RED_PRESSURE_PLATE,
		WIRE,
		SPELL_TOME,
		STAR_CLOAK,
		MEGASHARK,
		SHOTGUN,
		PHILOSOPHERS_STONE,
		TITAN_GLOVE,
		COBALT_NAGINATA,
		SWITCH,
		DART_TRAP,
		BOULDER,
		GREEN_PRESSURE_PLATE,
		GRAY_PRESSURE_PLATE,
		BROWN_PRESSURE_PLATE,
		MECHANICAL_EYE,
		CURSED_ARROW,
		CURSED_BULLET,
		SOUL_OF_FRIGHT,
		SOUL_OF_MIGHT,
		SOUL_OF_SIGHT,
		GUNGNIR,
		HALLOWED_PLATE_MAIL,
		HALLOWED_GREAVES,
		HALLOWED_HELMET,
		CROSS_NECKLACE,
		MANA_FLOWER,
		MECHANICAL_WORM,
		MECHANICAL_SKULL,
		HALLOWED_HEADGEAR,
		HALLOWED_MASK,
		SLIME_CROWN,
		LIGHT_DISC,
		MUSIC_BOX_OVERWORLD_DAY,
		MUSIC_BOX_EERIE,
		MUSIC_BOX_NIGHT,
		MUSIC_BOX_TITLE,
		MUSIC_BOX_UNDERGROUND,
		MUSIC_BOX_BOSS1,
		MUSIC_BOX_JUNGLE,
		MUSIC_BOX_CORRUPTION,
		MUSIC_BOX_UNDERGROUND_CORRUPTION,
		MUSIC_BOX_THE_HALLOW,
		MUSIC_BOX_BOSS2,
		MUSIC_BOX_UNDERGROUND_HALLOW,
		MUSIC_BOX_BOSS3,
		SOUL_OF_FLIGHT,
		MUSIC_BOX,
		DEMONITE_BRICK,
		HALLOWED_REPEATER,
		HAMDRAX,
		EXPLOSIVES,
		INLET_PUMP,
		OUTLET_PUMP,
		ONE_SECOND_TIMER,
		THREE_SECOND_TIMER,
		FIVE_SECOND_TIMER,
		CANDY_CANE_BLOCK,
		CANDY_CANE_WALL,
		SANTA_HAT,
		SANTA_SHIRT,
		SANTA_PANTS,
		GREEN_CANDY_CANE_BLOCK,
		GREEN_CANDY_CANE_WALL,
		SNOW_BLOCK,
		SNOW_BRICK,
		SNOW_BRICK_WALL,
		BLUE_LIGHT,
		RED_LIGHT,
		GREEN_LIGHT,
		BLUE_PRESENT,
		GREEN_PRESENT,
		YELLOW_PRESENT,
		SNOW_GLOBE,
		PET_SPAWN_1,
		DRAGON_MASK,
		TITAN_HELMET,
		SPECTRAL_HEADGEAR,
		DRAGON_BREASTPLATE,
		TITAN_MAIL,
		SPECTRAL_ARMOR,
		DRAGON_GREAVES,
		TITAN_LEGGINGS,
		SPECTRAL_SUBLIGAR,
		TIZONA,
		TONBOGIRI,
		SHARANGA,
		SPECTRAL_ARROW,
		VULCAN_REPEATER,
		VULCAN_BOLT,
		SUSPICIOUS_LOOKING_SKULL,
		SOUL_OF_BLIGHT,
		PET_SPAWN_2,
		PET_SPAWN_3,
		PET_SPAWN_4,
		PET_SPAWN_5,
		PET_SPAWN_6,
		MUSIC_BOX_DESERT,
		MUSIC_BOX_SPACE,
		MUSIC_BOX_TUTORIAL,
		MUSIC_BOX_BOSS4,
		MUSIC_BOX_OCEAN,
		MUSIC_BOX_SNOW,
		NUM_TYPES
	}

	public const int MAX_TYPES = 632;

	public const uint potionDelay = 3600u;

	public const uint potionDelayPhilosopher = 2700u;

	public static short[] headType = new short[48];

	public static short[] bodyType = new short[29];

	public static short[] legType = new short[28];

	public short type;

	public byte active;

	public bool beingGrabbed;

	public bool wornArmor;

	public bool mech;

	public bool wet;

	public byte wetCount;

	public bool lavaWet;

	public bool channel;

	public bool accessory;

	public bool potion;

	public bool consumable;

	public bool autoReuse;

	public bool useTurn;

	public bool buyOnce;

	public bool noUseGraphic;

	public bool noMelee;

	public bool buy;

	public bool social;

	public bool vanity;

	public bool material;

	public bool noWet;

	public bool melee;

	public bool magic;

	public bool ranged;

	public byte prefix;

	public byte noGrabDelay;

	public byte holdStyle;

	public byte useStyle;

	public byte useAnimation;

	public byte useTime;

	public byte pick;

	public byte axe;

	public byte hammer;

	public sbyte tileBoost;

	public byte placeStyle;

	public byte alpha;

	public byte owner;

	public byte ownIgnore;

	public byte ownTime;

	public byte keepTime;

	public byte useSound;

	public short stack;

	public short maxStack;

	public short createTile;

	public short createWall;

	public short damage;

	public short healLife;

	public short healMana;

	public uint spawnTime;

	public ushort width;

	public ushort height;

	public Vector2 position;

	public Vector2 velocity;

	public float knockBack;

	public Color color;

	public float scale;

	public short defense;

	public short headSlot;

	public short bodySlot;

	public short legSlot;

	public ushort buffTime;

	public byte buffType;

	public byte reuseDelay;

	public short netID;

	public short crit;

	public sbyte rare;

	public byte ammo;

	public byte useAmmo;

	public byte shoot;

	public float shootSpeed;

	public byte lifeRegen;

	public byte mana;

	public ushort release;

	public int value;

	private static readonly byte[] PREFIX_TOOLS = new byte[40]
	{
		1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
		11, 12, 13, 14, 15, 36, 37, 38, 53, 54,
		55, 39, 40, 56, 41, 57, 42, 43, 44, 45,
		46, 47, 48, 49, 50, 51, 59, 60, 61, 81
	};

	private static readonly byte[] PREFIX_SPEARS = new byte[14]
	{
		36, 37, 38, 53, 54, 55, 39, 40, 56, 41,
		57, 59, 60, 61
	};

	private static readonly byte[] PREFIX_GUNS = new byte[36]
	{
		16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
		58, 36, 37, 38, 53, 54, 55, 39, 40, 56,
		41, 57, 42, 43, 44, 45, 46, 47, 48, 49,
		50, 51, 59, 60, 61, 82
	};

	private static readonly byte[] PREFIX_MAGIC = new byte[36]
	{
		26, 27, 28, 29, 30, 31, 32, 33, 34, 35,
		52, 36, 37, 38, 53, 54, 55, 39, 40, 56,
		41, 57, 42, 43, 44, 45, 46, 47, 48, 49,
		50, 51, 59, 60, 61, 83
	};

	private static readonly byte[] PREFIX_BOOMERANG = new byte[14]
	{
		36, 37, 38, 53, 54, 55, 39, 40, 56, 41,
		57, 59, 60, 61
	};

	private static uint lastItemIndex = 0u;

	public void Init()
	{
		active = 0;
		owner = 8;
		type = 0;
		netID = 0;
		prefix = 0;
		crit = 0;
		wornArmor = false;
		mech = false;
		reuseDelay = 0;
		melee = false;
		magic = false;
		ranged = false;
		placeStyle = 0;
		buffTime = 0;
		buffType = 0;
		material = false;
		noWet = false;
		vanity = false;
		mana = 0;
		wet = false;
		wetCount = 0;
		lavaWet = false;
		channel = false;
		buyOnce = false;
		social = false;
		release = 0;
		noMelee = false;
		noUseGraphic = false;
		lifeRegen = 0;
		shootSpeed = 0f;
		alpha = 0;
		ammo = 0;
		useAmmo = 0;
		autoReuse = false;
		accessory = false;
		axe = 0;
		healMana = 0;
		bodySlot = -1;
		legSlot = -1;
		headSlot = -1;
		potion = false;
		consumable = false;
		createTile = -1;
		createWall = -1;
		damage = 0;
		defense = 0;
		hammer = 0;
		healLife = 0;
		knockBack = 0f;
		pick = 0;
		rare = 0;
		scale = 1f;
		shoot = 0;
		stack = 0;
		maxStack = 0;
		tileBoost = 0;
		holdStyle = 0;
		useStyle = 0;
		useSound = 0;
		useTime = 100;
		useAnimation = 100;
		value = 0;
		useTurn = false;
		buy = false;
		ownIgnore = 8;
		ownTime = 0;
		keepTime = 0;
	}

	public bool isLocal()
	{
		if (owner < 8)
		{
			return Main.player[owner].isLocal();
		}
		return false;
	}

	public bool isEquipable()
	{
		if (!accessory && headSlot < 0 && bodySlot < 0)
		{
			return legSlot >= 0;
		}
		return true;
	}

	public bool Prefix(int pre)
	{
		if (pre == 0 || type == 0)
		{
			return false;
		}
		int num = pre;
		float num2 = 1f;
		float num3 = 1f;
		float num4 = 1f;
		float num5 = 1f;
		float num6 = 1f;
		float num7 = 1f;
		int num8 = 0;
		bool flag = true;
		while (flag)
		{
			num2 = 1f;
			num3 = 1f;
			num4 = 1f;
			num5 = 1f;
			num6 = 1f;
			num7 = 1f;
			num8 = 0;
			flag = false;
			if (num == -1 && Main.rand.Next(4) == 0)
			{
				num = 0;
			}
			if (pre < -1)
			{
				num = -1;
			}
			if (num == -1 || num == -2 || num == -3)
			{
				if (type == 1 || type == 4 || type == 6 || type == 7 || type == 10 || type == 24 || type == 45 || type == 46 || type == 103 || type == 104 || type == 121 || type == 122 || type == 155 || type == 190 || type == 196 || type == 198 || type == 199 || type == 200 || type == 201 || type == 202 || type == 203 || type == 204 || type == 213 || type == 217 || type == 273 || type == 367 || type == 368 || type == 426 || type == 482 || type == 483 || type == 484 || type == 613)
				{
					num = PREFIX_TOOLS[Main.rand.Next(PREFIX_TOOLS.Length)];
				}
				else if (type == 162 || type == 160 || type == 163 || type == 220 || type == 274 || type == 277 || type == 280 || type == 383 || type == 384 || type == 385 || type == 386 || type == 387 || type == 388 || type == 389 || type == 390 || type == 406 || type == 537 || type == 550 || type == 579 || type == 614)
				{
					num = PREFIX_SPEARS[Main.rand.Next(PREFIX_SPEARS.Length)];
				}
				else if (type == 39 || type == 44 || type == 95 || type == 96 || type == 98 || type == 99 || type == 120 || type == 164 || type == 197 || type == 219 || type == 266 || type == 281 || type == 434 || type == 435 || type == 436 || type == 481 || type == 506 || type == 533 || type == 534 || type == 578 || type == 615 || type == 617)
				{
					num = PREFIX_GUNS[Main.rand.Next(PREFIX_GUNS.Length)];
				}
				else if (type == 64 || type == 65 || type == 112 || type == 113 || type == 127 || type == 157 || type == 165 || type == 218 || type == 272 || type == 494 || type == 495 || type == 496 || type == 514 || type == 517 || type == 518 || type == 519)
				{
					num = PREFIX_MAGIC[Main.rand.Next(PREFIX_MAGIC.Length)];
				}
				else if (type == 55 || type == 119 || type == 191 || type == 284)
				{
					num = PREFIX_BOOMERANG[Main.rand.Next(PREFIX_BOOMERANG.Length)];
				}
				else
				{
					if (!accessory || type == 267 || type == 562 || type == 563 || type == 564 || type == 565 || type == 566 || type == 567 || type == 568 || type == 569 || type == 570 || type == 571 || type == 572 || type == 573 || type == 574 || type == 576)
					{
						return false;
					}
					num = Main.rand.Next(62, 81);
				}
			}
			switch (pre)
			{
			case -3:
				return true;
			case -1:
				if (((num >= 7 && num <= 11) || num == 22 || num == 23 || num == 24 || num == 29 || num == 30 || num == 31 || num == 39 || num == 40 || num == 41 || num == 47 || num == 48 || num == 49 || num == 56) && Main.rand.Next(3) != 0)
				{
					num = 0;
				}
				break;
			}
			switch (num)
			{
			case 1:
				num5 = 1.12f;
				break;
			case 2:
				num5 = 1.18f;
				break;
			case 3:
				num2 = 1.05f;
				num8 = 2;
				num5 = 1.05f;
				break;
			case 4:
				num2 = 1.1f;
				num5 = 1.1f;
				num3 = 1.1f;
				break;
			case 5:
				num2 = 1.15f;
				break;
			case 6:
				num2 = 1.1f;
				break;
			case 81:
				num3 = 1.15f;
				num2 = 1.15f;
				num8 = 5;
				num4 = 0.9f;
				num5 = 1.1f;
				break;
			case 7:
				num5 = 0.82f;
				break;
			case 8:
				num3 = 0.85f;
				num2 = 0.85f;
				num5 = 0.87f;
				break;
			case 9:
				num5 = 0.9f;
				break;
			case 10:
				num2 = 0.85f;
				break;
			case 11:
				num4 = 1.1f;
				num3 = 0.9f;
				num5 = 0.9f;
				break;
			case 12:
				num3 = 1.1f;
				num2 = 1.05f;
				num5 = 1.1f;
				num4 = 1.15f;
				break;
			case 13:
				num3 = 0.8f;
				num2 = 0.9f;
				num5 = 1.1f;
				break;
			case 14:
				num3 = 1.15f;
				num4 = 1.1f;
				break;
			case 15:
				num3 = 0.9f;
				num4 = 0.85f;
				break;
			case 16:
				num2 = 1.1f;
				num8 = 3;
				break;
			case 17:
				num4 = 0.85f;
				num6 = 1.1f;
				break;
			case 18:
				num4 = 0.9f;
				num6 = 1.15f;
				break;
			case 19:
				num3 = 1.15f;
				num6 = 1.05f;
				break;
			case 20:
				num3 = 1.05f;
				num6 = 1.05f;
				num2 = 1.1f;
				num4 = 0.95f;
				num8 = 2;
				break;
			case 21:
				num3 = 1.15f;
				num2 = 1.1f;
				break;
			case 82:
				num3 = 1.15f;
				num2 = 1.15f;
				num8 = 5;
				num4 = 0.9f;
				num6 = 1.1f;
				break;
			case 22:
				num3 = 0.9f;
				num6 = 0.9f;
				num2 = 0.85f;
				break;
			case 23:
				num4 = 1.15f;
				num6 = 0.9f;
				break;
			case 24:
				num4 = 1.1f;
				num3 = 0.8f;
				break;
			case 25:
				num4 = 1.1f;
				num2 = 1.15f;
				num8 = 1;
				break;
			case 58:
				num4 = 0.85f;
				num2 = 0.85f;
				break;
			case 26:
				num7 = 0.85f;
				num2 = 1.1f;
				break;
			case 27:
				num7 = 0.85f;
				break;
			case 28:
				num7 = 0.85f;
				num2 = 1.15f;
				num3 = 1.05f;
				break;
			case 83:
				num3 = 1.15f;
				num2 = 1.15f;
				num8 = 5;
				num4 = 0.9f;
				num7 = 0.9f;
				break;
			case 29:
				num7 = 1.1f;
				break;
			case 30:
				num7 = 1.2f;
				num2 = 0.9f;
				break;
			case 31:
				num3 = 0.9f;
				num2 = 0.9f;
				break;
			case 32:
				num7 = 1.15f;
				num2 = 1.1f;
				break;
			case 33:
				num7 = 1.1f;
				num3 = 1.1f;
				num4 = 0.9f;
				break;
			case 34:
				num7 = 0.9f;
				num3 = 1.1f;
				num4 = 1.1f;
				num2 = 1.1f;
				break;
			case 35:
				num7 = 1.2f;
				num2 = 1.15f;
				num3 = 1.15f;
				break;
			case 52:
				num7 = 0.9f;
				num2 = 0.9f;
				num4 = 0.9f;
				break;
			case 36:
				num8 = 3;
				break;
			case 37:
				num2 = 1.1f;
				num8 = 3;
				num3 = 1.1f;
				break;
			case 38:
				num3 = 1.15f;
				break;
			case 53:
				num2 = 1.1f;
				break;
			case 54:
				num3 = 1.15f;
				break;
			case 55:
				num3 = 1.15f;
				num2 = 1.05f;
				break;
			case 59:
				num3 = 1.15f;
				num2 = 1.15f;
				num8 = 5;
				break;
			case 60:
				num2 = 1.15f;
				num8 = 5;
				break;
			case 61:
				num8 = 5;
				break;
			case 39:
				num2 = 0.7f;
				num3 = 0.8f;
				break;
			case 40:
				num2 = 0.85f;
				break;
			case 56:
				num3 = 0.8f;
				break;
			case 41:
				num3 = 0.85f;
				num2 = 0.9f;
				break;
			case 57:
				num3 = 0.9f;
				num2 = 1.18f;
				break;
			case 42:
				num4 = 0.9f;
				break;
			case 43:
				num2 = 1.1f;
				num4 = 0.9f;
				break;
			case 44:
				num4 = 0.9f;
				num8 = 3;
				break;
			case 45:
				num4 = 0.95f;
				break;
			case 46:
				num8 = 3;
				num4 = 0.94f;
				num2 = 1.07f;
				break;
			case 47:
				num4 = 1.15f;
				break;
			case 48:
				num4 = 1.2f;
				break;
			case 49:
				num4 = 1.08f;
				break;
			case 50:
				num2 = 0.8f;
				num4 = 1.15f;
				break;
			case 51:
				num3 = 0.9f;
				num4 = 0.9f;
				num2 = 1.05f;
				num8 = 2;
				break;
			}
			if (num2 != 1f && Math.Round((float)damage * num2) == (double)damage)
			{
				flag = true;
				num = -1;
			}
			if (num4 != 1f && Math.Round((float)(int)useAnimation * num4) == (double)(int)useAnimation)
			{
				flag = true;
				num = -1;
			}
			if (num7 != 1f && Math.Round((float)(int)mana * num7) == (double)(int)mana)
			{
				flag = true;
				num = -1;
			}
			if (num3 != 1f && knockBack == 0f)
			{
				flag = true;
				num = -1;
			}
			if (pre == -2 && num == 0)
			{
				num = -1;
				flag = true;
			}
		}
		damage = (short)Math.Round((float)damage * num2);
		useAnimation = (byte)Math.Round((float)(int)useAnimation * num4);
		useTime = (byte)Math.Round((float)(int)useTime * num4);
		reuseDelay = (byte)Math.Round((float)(int)reuseDelay * num4);
		mana = (byte)Math.Round((float)(int)mana * num7);
		knockBack *= num3;
		scale *= num5;
		shootSpeed *= num6;
		crit += (short)num8;
		float num9 = num2 * (2f - num4) * (2f - num7) * num5 * num3 * num6 * (1f + (float)crit * 0.02f);
		switch (num)
		{
		case 62:
		case 69:
		case 73:
		case 77:
			num9 *= 1.05f;
			break;
		case 63:
		case 67:
		case 70:
		case 74:
		case 78:
			num9 *= 1.1f;
			break;
		case 64:
		case 66:
		case 71:
		case 75:
		case 79:
			num9 *= 1.15f;
			break;
		case 65:
		case 68:
		case 72:
		case 76:
		case 80:
			num9 *= 1.2f;
			break;
		}
		prefix = (byte)num;
		if (num9 >= 1.2f)
		{
			rare += 2;
		}
		else if (num9 >= 1.05f)
		{
			rare++;
		}
		else if (num9 <= 0.8f)
		{
			rare -= 2;
		}
		else if (num9 <= 0.95f)
		{
			rare--;
		}
		if (rare < -1)
		{
			rare = -1;
		}
		else if (rare > 6)
		{
			rare = 6;
		}
		num9 *= num9;
		value = (int)((float)value * num9);
		return true;
	}

	public string Name()
	{
		return Lang.itemName(netID);
	}

	public string AffixName()
	{
		return Lang.itemAffixName(prefix, netID);
	}

	public void SetDefaults(string ItemName)
	{
		bool flag = false;
		switch (ItemName)
		{
		case "Gold Pickaxe":
			SetDefaults(1);
			color = new Color(210, 190, 0, 100);
			useTime = 17;
			pick = 55;
			useAnimation = 20;
			scale = 1.05f;
			damage = 6;
			value = 10000;
			netID = -1;
			break;
		case "Gold Broadsword":
			SetDefaults(4);
			color = new Color(210, 190, 0, 100);
			useAnimation = 20;
			damage = 13;
			scale = 1.05f;
			value = 9000;
			netID = -2;
			break;
		case "Gold Shortsword":
			SetDefaults(6);
			color = new Color(210, 190, 0, 100);
			damage = 11;
			useAnimation = 11;
			scale = 0.95f;
			value = 7000;
			netID = -3;
			break;
		case "Gold Axe":
			SetDefaults(10);
			color = new Color(210, 190, 0, 100);
			useTime = 18;
			axe = 11;
			useAnimation = 26;
			scale = 1.15f;
			damage = 7;
			value = 8000;
			netID = -4;
			break;
		case "Gold Hammer":
			SetDefaults(7);
			color = new Color(210, 190, 0, 100);
			useAnimation = 28;
			useTime = 23;
			scale = 1.25f;
			damage = 9;
			hammer = 55;
			value = 8000;
			netID = -5;
			break;
		case "Gold Bow":
			SetDefaults(99);
			useAnimation = 26;
			useTime = 26;
			color = new Color(210, 190, 0, 100);
			damage = 11;
			value = 7000;
			netID = -6;
			break;
		case "Silver Pickaxe":
			SetDefaults(1);
			color = new Color(180, 180, 180, 100);
			useTime = 11;
			pick = 45;
			useAnimation = 19;
			scale = 1.05f;
			damage = 6;
			value = 5000;
			netID = -7;
			break;
		case "Silver Broadsword":
			SetDefaults(4);
			color = new Color(180, 180, 180, 100);
			useAnimation = 21;
			damage = 11;
			value = 4500;
			netID = -8;
			break;
		case "Silver Shortsword":
			SetDefaults(6);
			color = new Color(180, 180, 180, 100);
			damage = 9;
			useAnimation = 12;
			scale = 0.95f;
			value = 3500;
			netID = -9;
			break;
		case "Silver Axe":
			SetDefaults(10);
			color = new Color(180, 180, 180, 100);
			useTime = 18;
			axe = 10;
			useAnimation = 26;
			scale = 1.15f;
			damage = 6;
			value = 4000;
			netID = -10;
			break;
		case "Silver Hammer":
			SetDefaults(7);
			color = new Color(180, 180, 180, 100);
			useAnimation = 29;
			useTime = 19;
			scale = 1.25f;
			damage = 9;
			hammer = 45;
			value = 4000;
			netID = -11;
			break;
		case "Silver Bow":
			SetDefaults(99);
			useAnimation = 27;
			useTime = 27;
			color = new Color(180, 180, 180, 100);
			damage = 9;
			value = 3500;
			netID = -12;
			break;
		case "Copper Pickaxe":
			SetDefaults(1);
			color = new Color(180, 100, 45, 80);
			useTime = 15;
			pick = 35;
			useAnimation = 23;
			damage = 4;
			scale = 0.9f;
			tileBoost = -1;
			value = 500;
			netID = -13;
			break;
		case "Copper Broadsword":
			SetDefaults(4);
			color = new Color(180, 100, 45, 80);
			useAnimation = 23;
			damage = 8;
			value = 450;
			netID = -14;
			break;
		case "Copper Shortsword":
			SetDefaults(6);
			color = new Color(180, 100, 45, 80);
			damage = 5;
			useAnimation = 13;
			scale = 0.8f;
			value = 350;
			netID = -15;
			break;
		case "Copper Axe":
			SetDefaults(10);
			color = new Color(180, 100, 45, 80);
			useTime = 21;
			axe = 7;
			useAnimation = 30;
			scale = 1f;
			damage = 3;
			tileBoost = -1;
			value = 400;
			netID = -16;
			break;
		case "Copper Hammer":
			SetDefaults(7);
			color = new Color(180, 100, 45, 80);
			useAnimation = 33;
			useTime = 23;
			scale = 1.1f;
			damage = 4;
			hammer = 35;
			tileBoost = -1;
			value = 400;
			netID = -17;
			break;
		case "Copper Bow":
			SetDefaults(99);
			useAnimation = 29;
			useTime = 29;
			color = new Color(180, 100, 45, 80);
			damage = 6;
			value = 350;
			netID = -18;
			break;
		case "Blue Phasesaber":
			SetDefaults(198);
			damage = 41;
			scale = 1.15f;
			flag = true;
			autoReuse = true;
			useTurn = true;
			rare = 4;
			netID = -19;
			break;
		case "Red Phasesaber":
			SetDefaults(199);
			damage = 41;
			scale = 1.15f;
			flag = true;
			autoReuse = true;
			useTurn = true;
			rare = 4;
			netID = -20;
			break;
		case "Green Phasesaber":
			SetDefaults(200);
			damage = 41;
			scale = 1.15f;
			flag = true;
			autoReuse = true;
			useTurn = true;
			rare = 4;
			netID = -21;
			break;
		case "Purple Phasesaber":
			SetDefaults(201);
			damage = 41;
			scale = 1.15f;
			flag = true;
			autoReuse = true;
			useTurn = true;
			rare = 4;
			netID = -22;
			break;
		case "White Phasesaber":
			SetDefaults(202);
			damage = 41;
			scale = 1.15f;
			flag = true;
			autoReuse = true;
			useTurn = true;
			rare = 4;
			netID = -23;
			break;
		case "Yellow Phasesaber":
			SetDefaults(203);
			damage = 41;
			scale = 1.15f;
			flag = true;
			autoReuse = true;
			useTurn = true;
			rare = 4;
			netID = -24;
			break;
		}
		if (flag)
		{
			material = false;
		}
		else
		{
			checkMat();
		}
	}

	public bool checkMat()
	{
		if (CanBePlacedInCoinSlot())
		{
			material = false;
			return false;
		}
		for (int i = 0; i < Recipe.numRecipes; i++)
		{
			int num = Main.recipe[i].numRequiredItems - 1;
			do
			{
				if (netID == Main.recipe[i].requiredItem[num].netID)
				{
					material = true;
					return true;
				}
			}
			while (--num >= 0);
		}
		material = false;
		return false;
	}

	public void netDefaults(int Type, int Stack = 1)
	{
		if (Type < 0)
		{
			switch (Type)
			{
			case -1:
				SetDefaults("Gold Pickaxe");
				break;
			case -2:
				SetDefaults("Gold Broadsword");
				break;
			case -3:
				SetDefaults("Gold Shortsword");
				break;
			case -4:
				SetDefaults("Gold Axe");
				break;
			case -5:
				SetDefaults("Gold Hammer");
				break;
			case -6:
				SetDefaults("Gold Bow");
				break;
			case -7:
				SetDefaults("Silver Pickaxe");
				break;
			case -8:
				SetDefaults("Silver Broadsword");
				break;
			case -9:
				SetDefaults("Silver Shortsword");
				break;
			case -10:
				SetDefaults("Silver Axe");
				break;
			case -11:
				SetDefaults("Silver Hammer");
				break;
			case -12:
				SetDefaults("Silver Bow");
				break;
			case -13:
				SetDefaults("Copper Pickaxe");
				break;
			case -14:
				SetDefaults("Copper Broadsword");
				break;
			case -15:
				SetDefaults("Copper Shortsword");
				break;
			case -16:
				SetDefaults("Copper Axe");
				break;
			case -17:
				SetDefaults("Copper Hammer");
				break;
			case -18:
				SetDefaults("Copper Bow");
				break;
			case -19:
				SetDefaults("Blue Phasesaber");
				break;
			case -20:
				SetDefaults("Red Phasesaber");
				break;
			case -21:
				SetDefaults("Green Phasesaber");
				break;
			case -22:
				SetDefaults("Purple Phasesaber");
				break;
			case -23:
				SetDefaults("White Phasesaber");
				break;
			case -24:
				SetDefaults("Yellow Phasesaber");
				break;
			}
		}
		else
		{
			SetDefaults(Type, Stack);
		}
	}

	public void SetDefaults(int Type, int Stack = 1, bool noMatCheck = false)
	{
		active = 1;
		owner = 8;
		type = (short)Type;
		netID = (short)Type;
		prefix = 0;
		crit = 0;
		wornArmor = false;
		mech = false;
		reuseDelay = 0;
		melee = false;
		magic = false;
		ranged = false;
		placeStyle = 0;
		buffTime = 0;
		buffType = 0;
		material = false;
		noWet = false;
		vanity = false;
		mana = 0;
		wet = false;
		wetCount = 0;
		lavaWet = false;
		channel = false;
		buyOnce = false;
		social = false;
		release = 0;
		noMelee = false;
		noUseGraphic = false;
		lifeRegen = 0;
		shootSpeed = 0f;
		alpha = 0;
		ammo = 0;
		useAmmo = 0;
		autoReuse = false;
		accessory = false;
		axe = 0;
		healMana = 0;
		bodySlot = -1;
		legSlot = -1;
		headSlot = -1;
		potion = false;
		color = default(Color);
		consumable = false;
		createTile = -1;
		createWall = -1;
		damage = 0;
		defense = 0;
		hammer = 0;
		healLife = 0;
		knockBack = 0f;
		pick = 0;
		rare = 0;
		scale = 1f;
		shoot = 0;
		stack = (short)Stack;
		maxStack = (short)Stack;
		tileBoost = 0;
		holdStyle = 0;
		useStyle = 0;
		useSound = 0;
		useTime = 100;
		useAnimation = 100;
		value = 0;
		useTurn = false;
		buy = false;
		ownIgnore = 8;
		ownTime = 0;
		keepTime = 0;
		switch (Type)
		{
		case 1:
			useStyle = 1;
			useTurn = true;
			useAnimation = 20;
			useTime = 13;
			autoReuse = true;
			width = 24;
			height = 28;
			damage = 5;
			pick = 40;
			useSound = 1;
			knockBack = 2f;
			value = 2000;
			melee = true;
			break;
		case 2:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 0;
			width = 12;
			height = 12;
			break;
		case 3:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 1;
			width = 12;
			height = 12;
			break;
		case 4:
			useStyle = 1;
			useTurn = false;
			useAnimation = 21;
			useTime = 21;
			width = 24;
			height = 28;
			damage = 10;
			knockBack = 5f;
			useSound = 1;
			scale = 1f;
			value = 1800;
			melee = true;
			break;
		case 5:
			useStyle = 2;
			useSound = 2;
			useTurn = false;
			useAnimation = 17;
			useTime = 17;
			width = 16;
			height = 18;
			healLife = 15;
			maxStack = 99;
			consumable = true;
			potion = true;
			value = 25;
			break;
		case 6:
			useStyle = 3;
			useTurn = false;
			useAnimation = 12;
			useTime = 12;
			width = 24;
			height = 28;
			damage = 8;
			knockBack = 4f;
			scale = 0.9f;
			useSound = 1;
			useTurn = true;
			value = 1400;
			melee = true;
			break;
		case 7:
			autoReuse = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 30;
			useTime = 20;
			hammer = 45;
			width = 24;
			height = 28;
			damage = 7;
			knockBack = 5.5f;
			scale = 1.2f;
			useSound = 1;
			value = 1600;
			melee = true;
			break;
		case 8:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			width = 10;
			height = 12;
			value = 50;
			break;
		case 9:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 30;
			width = 8;
			height = 10;
			break;
		case 10:
			useStyle = 1;
			useTurn = true;
			useAnimation = 27;
			knockBack = 4.5f;
			useTime = 19;
			autoReuse = true;
			width = 24;
			height = 28;
			damage = 5;
			axe = 9;
			scale = 1.1f;
			useSound = 1;
			value = 1600;
			melee = true;
			break;
		case 11:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 6;
			width = 12;
			height = 12;
			value = 500;
			break;
		case 12:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 7;
			width = 12;
			height = 12;
			value = 250;
			break;
		case 13:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 8;
			width = 12;
			height = 12;
			value = 2000;
			break;
		case 14:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 9;
			width = 12;
			height = 12;
			value = 1000;
			break;
		case 15:
			width = 24;
			height = 28;
			accessory = true;
			value = 1000;
			break;
		case 16:
			width = 24;
			height = 28;
			accessory = true;
			value = 5000;
			break;
		case 17:
			width = 24;
			height = 28;
			accessory = true;
			rare = 1;
			value = 10000;
			break;
		case 18:
			width = 24;
			height = 18;
			accessory = true;
			rare = 1;
			value = 10000;
			break;
		case 19:
			width = 20;
			height = 20;
			maxStack = 99;
			value = 6000;
			break;
		case 20:
			width = 20;
			height = 20;
			maxStack = 99;
			value = 750;
			break;
		case 21:
			width = 20;
			height = 20;
			maxStack = 99;
			value = 3000;
			break;
		case 22:
			width = 20;
			height = 20;
			maxStack = 99;
			value = 1500;
			break;
		case 23:
			width = 10;
			height = 12;
			maxStack = 250;
			alpha = 175;
			ammo = 23;
			color = new Color(0, 80, 255, 100);
			value = 5;
			break;
		case 24:
			useStyle = 1;
			useTurn = false;
			useAnimation = 25;
			width = 24;
			height = 28;
			damage = 7;
			knockBack = 4f;
			scale = 0.95f;
			useSound = 1;
			value = 100;
			melee = true;
			break;
		case 25:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 10;
			width = 14;
			height = 28;
			value = 200;
			break;
		case 26:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 1;
			width = 12;
			height = 12;
			break;
		case 27:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 20;
			width = 18;
			height = 18;
			value = 10;
			break;
		case 28:
			useSound = 3;
			healLife = 50;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			potion = true;
			value = 300;
			break;
		case 29:
			maxStack = 99;
			consumable = true;
			width = 18;
			height = 18;
			useStyle = 4;
			useTime = 30;
			useSound = 4;
			useAnimation = 30;
			rare = 2;
			value = 75000;
			break;
		case 30:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 16;
			width = 12;
			height = 12;
			break;
		case 31:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 13;
			width = 16;
			height = 24;
			value = 20;
			break;
		case 32:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 14;
			width = 26;
			height = 20;
			value = 300;
			break;
		case 33:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 17;
			width = 26;
			height = 24;
			value = 300;
			break;
		case 34:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 15;
			width = 12;
			height = 30;
			value = 150;
			break;
		case 35:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 16;
			width = 28;
			height = 14;
			value = 5000;
			break;
		case 36:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 18;
			width = 28;
			height = 14;
			value = 150;
			break;
		case 37:
			width = 28;
			height = 12;
			defense = 1;
			headSlot = 10;
			rare = 1;
			value = 1000;
			break;
		case 38:
			width = 12;
			height = 20;
			maxStack = 99;
			value = 500;
			break;
		case 39:
			useStyle = 5;
			useAnimation = 30;
			useTime = 30;
			width = 12;
			height = 28;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 4;
			shootSpeed = 6.1f;
			noMelee = true;
			value = 100;
			ranged = true;
			break;
		case 40:
			shootSpeed = 3f;
			shoot = 1;
			damage = 4;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 2f;
			value = 10;
			ranged = true;
			break;
		case 41:
			shootSpeed = 3.5f;
			shoot = 2;
			damage = 6;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 2f;
			value = 15;
			ranged = true;
			break;
		case 42:
			useStyle = 1;
			shootSpeed = 9f;
			shoot = 3;
			damage = 10;
			width = 18;
			height = 20;
			maxStack = 250;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			noMelee = true;
			value = 20;
			ranged = true;
			break;
		case 43:
			useStyle = 4;
			width = 22;
			height = 14;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			maxStack = 20;
			break;
		case 619:
			useStyle = 4;
			width = 26;
			height = 26;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			maxStack = 20;
			break;
		case 44:
			useStyle = 5;
			useAnimation = 25;
			useTime = 25;
			width = 12;
			height = 28;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 14;
			shootSpeed = 6.7f;
			knockBack = 1f;
			alpha = 30;
			rare = 1;
			noMelee = true;
			value = 18000;
			ranged = true;
			break;
		case 45:
			autoReuse = true;
			useStyle = 1;
			useAnimation = 30;
			knockBack = 6f;
			useTime = 15;
			width = 24;
			height = 28;
			damage = 20;
			axe = 15;
			scale = 1.2f;
			useSound = 1;
			rare = 1;
			value = 13500;
			melee = true;
			break;
		case 46:
			useStyle = 1;
			useAnimation = 20;
			knockBack = 5f;
			width = 24;
			height = 28;
			damage = 17;
			scale = 1.1f;
			useSound = 1;
			rare = 1;
			value = 13500;
			melee = true;
			break;
		case 47:
			shootSpeed = 3.4f;
			shoot = 4;
			damage = 8;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 3f;
			alpha = 30;
			rare = 1;
			value = 40;
			ranged = true;
			break;
		case 48:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 21;
			width = 26;
			height = 22;
			value = 500;
			break;
		case 49:
			width = 22;
			height = 22;
			accessory = true;
			lifeRegen = 1;
			rare = 1;
			value = 50000;
			break;
		case 50:
			mana = 20;
			useTurn = true;
			width = 20;
			height = 20;
			useStyle = 4;
			useTime = 90;
			useSound = 6;
			useAnimation = 90;
			rare = 1;
			value = 50000;
			break;
		case 51:
			shootSpeed = 0.5f;
			shoot = 5;
			damage = 9;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 4f;
			rare = 1;
			value = 100;
			ranged = true;
			break;
		case 52:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 1;
			break;
		case 53:
			width = 16;
			height = 24;
			accessory = true;
			rare = 1;
			value = 50000;
			break;
		case 54:
			width = 28;
			height = 24;
			accessory = true;
			rare = 1;
			value = 50000;
			break;
		case 55:
			noMelee = true;
			useStyle = 1;
			shootSpeed = 10f;
			shoot = 6;
			damage = 13;
			knockBack = 8f;
			width = 14;
			height = 28;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			rare = 1;
			value = 50000;
			melee = true;
			break;
		case 56:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 22;
			width = 12;
			height = 12;
			rare = 1;
			value = 4000;
			break;
		case 57:
			width = 20;
			height = 20;
			maxStack = 99;
			rare = 1;
			value = 16000;
			break;
		case 58:
			width = 12;
			height = 12;
			break;
		case 59:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 23;
			width = 14;
			height = 14;
			value = 500;
			break;
		case 60:
			width = 16;
			height = 18;
			maxStack = 99;
			value = 50;
			break;
		case 61:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 25;
			width = 12;
			height = 12;
			break;
		case 62:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 2;
			width = 14;
			height = 14;
			value = 20;
			break;
		case 63:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 27;
			width = 26;
			height = 26;
			value = 200;
			break;
		case 64:
			mana = 12;
			damage = 8;
			useStyle = 1;
			shootSpeed = 32f;
			shoot = 7;
			width = 26;
			height = 28;
			useSound = 8;
			useAnimation = 30;
			useTime = 30;
			rare = 1;
			noMelee = true;
			knockBack = 1f;
			value = 10000;
			magic = true;
			break;
		case 65:
			autoReuse = true;
			mana = 16;
			knockBack = 5f;
			alpha = 100;
			color = new Color(150, 150, 150, 0);
			damage = 16;
			useStyle = 1;
			scale = 1.15f;
			shootSpeed = 12f;
			shoot = 9;
			width = 14;
			height = 28;
			useSound = 9;
			useAnimation = 25;
			useTime = 10;
			rare = 1;
			value = 50000;
			magic = true;
			break;
		case 66:
			useStyle = 1;
			shootSpeed = 4f;
			shoot = 10;
			width = 16;
			height = 24;
			maxStack = 99;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noMelee = true;
			value = 75;
			break;
		case 67:
			damage = 0;
			useStyle = 1;
			shootSpeed = 4f;
			shoot = 11;
			width = 16;
			height = 24;
			maxStack = 99;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noMelee = true;
			value = 100;
			break;
		case 68:
			width = 18;
			height = 20;
			maxStack = 99;
			value = 10;
			break;
		case 69:
			width = 8;
			height = 20;
			maxStack = 99;
			value = 100;
			break;
		case 70:
			useStyle = 4;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			width = 28;
			height = 28;
			maxStack = 20;
			break;
		case 71:
			width = 10;
			height = 12;
			maxStack = 100;
			value = 5;
			break;
		case 72:
			width = 10;
			height = 12;
			maxStack = 100;
			value = 500;
			break;
		case 73:
			width = 10;
			height = 12;
			maxStack = 100;
			value = 50000;
			break;
		case 74:
			width = 10;
			height = 12;
			maxStack = 100;
			value = 5000000;
			break;
		case 75:
			width = 18;
			height = 20;
			maxStack = 100;
			alpha = 75;
			ammo = 15;
			value = 500;
			useStyle = 4;
			useSound = 4;
			useTurn = false;
			useAnimation = 17;
			useTime = 17;
			consumable = true;
			rare = 1;
			break;
		case 76:
			width = 18;
			height = 18;
			defense = 1;
			legSlot = 1;
			value = 750;
			break;
		case 77:
			width = 18;
			height = 18;
			defense = 2;
			legSlot = 2;
			value = 3000;
			break;
		case 78:
			width = 18;
			height = 18;
			defense = 3;
			legSlot = 3;
			value = 7500;
			break;
		case 79:
			width = 18;
			height = 18;
			defense = 4;
			legSlot = 4;
			value = 15000;
			break;
		case 80:
			width = 18;
			height = 18;
			defense = 2;
			bodySlot = 1;
			value = 1000;
			break;
		case 81:
			width = 18;
			height = 18;
			defense = 3;
			bodySlot = 2;
			value = 4000;
			break;
		case 82:
			width = 18;
			height = 18;
			defense = 4;
			bodySlot = 3;
			value = 10000;
			break;
		case 83:
			width = 18;
			height = 18;
			defense = 5;
			bodySlot = 4;
			value = 20000;
			break;
		case 84:
			noUseGraphic = true;
			damage = 0;
			knockBack = 7f;
			useStyle = 5;
			shootSpeed = 11f;
			shoot = 13;
			width = 18;
			height = 28;
			useSound = 1;
			useAnimation = 20;
			useTime = 20;
			rare = 1;
			noMelee = true;
			value = 20000;
			break;
		case 85:
			width = 14;
			height = 20;
			maxStack = 99;
			value = 1000;
			break;
		case 86:
			width = 14;
			height = 18;
			maxStack = 99;
			rare = 1;
			value = 500;
			break;
		case 87:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 29;
			width = 20;
			height = 12;
			value = 10000;
			break;
		case 88:
			width = 22;
			height = 16;
			defense = 1;
			headSlot = 11;
			rare = 1;
			value = 80000;
			break;
		case 89:
			width = 18;
			height = 18;
			defense = 1;
			headSlot = 1;
			value = 1250;
			break;
		case 90:
			width = 18;
			height = 18;
			defense = 2;
			headSlot = 2;
			value = 5000;
			break;
		case 91:
			width = 18;
			height = 18;
			defense = 3;
			headSlot = 3;
			value = 12500;
			break;
		case 92:
			width = 18;
			height = 18;
			defense = 4;
			headSlot = 4;
			value = 25000;
			break;
		case 93:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 4;
			width = 12;
			height = 12;
			break;
		case 94:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 19;
			width = 8;
			height = 10;
			break;
		case 95:
			useStyle = 5;
			useAnimation = 16;
			useTime = 16;
			width = 24;
			height = 28;
			shoot = 14;
			useAmmo = 14;
			useSound = 11;
			damage = 10;
			shootSpeed = 5f;
			noMelee = true;
			value = 50000;
			scale = 0.9f;
			rare = 1;
			ranged = true;
			break;
		case 96:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 43;
			useTime = 43;
			width = 44;
			height = 14;
			shoot = 10;
			useAmmo = 14;
			useSound = 11;
			damage = 23;
			shootSpeed = 8f;
			noMelee = true;
			value = 100000;
			knockBack = 4f;
			rare = 1;
			ranged = true;
			break;
		case 97:
			shootSpeed = 4f;
			shoot = 14;
			damage = 7;
			width = 8;
			height = 8;
			maxStack = 250;
			consumable = true;
			ammo = 14;
			knockBack = 2f;
			value = 7;
			ranged = true;
			break;
		case 98:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 8;
			useTime = 8;
			width = 50;
			height = 18;
			shoot = 10;
			useAmmo = 14;
			useSound = 11;
			damage = 6;
			shootSpeed = 7f;
			noMelee = true;
			value = 350000;
			rare = 2;
			ranged = true;
			break;
		case 99:
			useStyle = 5;
			useAnimation = 28;
			useTime = 28;
			width = 12;
			height = 28;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 8;
			shootSpeed = 6.6f;
			noMelee = true;
			value = 1400;
			ranged = true;
			break;
		case 100:
			width = 18;
			height = 18;
			defense = 6;
			legSlot = 5;
			rare = 1;
			value = 22500;
			break;
		case 101:
			width = 18;
			height = 18;
			defense = 7;
			bodySlot = 5;
			rare = 1;
			value = 30000;
			break;
		case 102:
			width = 18;
			height = 18;
			defense = 6;
			headSlot = 5;
			rare = 1;
			value = 37500;
			break;
		case 103:
			useStyle = 1;
			useTurn = true;
			useAnimation = 20;
			useTime = 15;
			autoReuse = true;
			width = 24;
			height = 28;
			damage = 9;
			pick = 65;
			useSound = 1;
			knockBack = 3f;
			rare = 1;
			value = 18000;
			scale = 1.15f;
			melee = true;
			break;
		case 104:
			autoReuse = true;
			useStyle = 1;
			useAnimation = 45;
			useTime = 19;
			hammer = 55;
			width = 24;
			height = 28;
			damage = 24;
			knockBack = 6f;
			scale = 1.3f;
			useSound = 1;
			rare = 1;
			value = 15000;
			melee = true;
			break;
		case 105:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 33;
			width = 8;
			height = 18;
			holdStyle = 1;
			break;
		case 106:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 34;
			width = 26;
			height = 26;
			break;
		case 107:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 35;
			width = 26;
			height = 26;
			break;
		case 108:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 36;
			width = 26;
			height = 26;
			break;
		case 109:
			maxStack = 99;
			consumable = true;
			width = 18;
			height = 18;
			useStyle = 4;
			useTime = 30;
			useSound = 29;
			useAnimation = 30;
			rare = 2;
			break;
		case 110:
			useSound = 3;
			healMana = 50;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 20;
			consumable = true;
			width = 14;
			height = 24;
			value = 100;
			break;
		case 111:
			width = 22;
			height = 22;
			accessory = true;
			rare = 1;
			value = 50000;
			break;
		case 112:
			mana = 17;
			damage = 44;
			useStyle = 1;
			shootSpeed = 6f;
			shoot = 15;
			width = 26;
			height = 28;
			useSound = 20;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			knockBack = 5.5f;
			value = 10000;
			magic = true;
			break;
		case 113:
			mana = 10;
			channel = true;
			damage = 22;
			useStyle = 1;
			shootSpeed = 6f;
			shoot = 16;
			width = 26;
			height = 28;
			useSound = 9;
			useAnimation = 17;
			useTime = 17;
			rare = 2;
			noMelee = true;
			knockBack = 5f;
			tileBoost = 64;
			value = 10000;
			magic = true;
			break;
		case 114:
			mana = 5;
			channel = true;
			damage = 0;
			useStyle = 1;
			shoot = 17;
			width = 26;
			height = 28;
			useSound = 8;
			useAnimation = 20;
			useTime = 20;
			rare = 1;
			noMelee = true;
			knockBack = 5f;
			value = 200000;
			break;
		case 115:
			mana = 40;
			channel = true;
			damage = 0;
			useStyle = 4;
			shoot = 18;
			width = 24;
			height = 24;
			useSound = 8;
			useAnimation = 20;
			useTime = 20;
			rare = 1;
			noMelee = true;
			value = 10000;
			buffType = 19;
			buffTime = 18000;
			break;
		case 116:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 37;
			width = 12;
			height = 12;
			value = 1000;
			break;
		case 117:
			width = 20;
			height = 20;
			maxStack = 99;
			rare = 1;
			value = 7000;
			break;
		case 118:
			maxStack = 99;
			width = 18;
			height = 18;
			value = 1000;
			break;
		case 119:
			noMelee = true;
			useStyle = 1;
			shootSpeed = 11f;
			shoot = 19;
			damage = 32;
			knockBack = 8f;
			width = 14;
			height = 28;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			rare = 3;
			value = 100000;
			melee = true;
			break;
		case 120:
			useStyle = 5;
			useAnimation = 25;
			useTime = 25;
			width = 14;
			height = 32;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 29;
			shootSpeed = 8f;
			knockBack = 2f;
			alpha = 30;
			rare = 3;
			noMelee = true;
			scale = 1.1f;
			value = 27000;
			ranged = true;
			break;
		case 615:
			useStyle = 5;
			useAnimation = 20;
			useTime = 20;
			width = 14;
			height = 32;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 35;
			shootSpeed = 10f;
			knockBack = 2.3f;
			alpha = 30;
			rare = 5;
			noMelee = true;
			scale = 1.1f;
			value = 60000;
			ranged = true;
			break;
		case 121:
			useStyle = 1;
			useAnimation = 34;
			knockBack = 6.5f;
			width = 24;
			height = 28;
			damage = 36;
			scale = 1.3f;
			useSound = 1;
			rare = 3;
			value = 27000;
			melee = true;
			break;
		case 122:
			useStyle = 1;
			useTurn = true;
			useAnimation = 25;
			useTime = 25;
			autoReuse = true;
			width = 24;
			height = 28;
			damage = 12;
			pick = 100;
			scale = 1.15f;
			useSound = 1;
			knockBack = 2f;
			rare = 3;
			value = 27000;
			melee = true;
			break;
		case 123:
			width = 18;
			height = 18;
			defense = 3;
			headSlot = 6;
			rare = 1;
			value = 45000;
			break;
		case 124:
			width = 18;
			height = 18;
			defense = 4;
			bodySlot = 6;
			rare = 1;
			value = 30000;
			break;
		case 125:
			width = 18;
			height = 18;
			defense = 3;
			legSlot = 6;
			rare = 1;
			value = 30000;
			break;
		case 126:
			useSound = 3;
			healLife = 20;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			potion = true;
			value = 20;
			break;
		case 127:
			autoReuse = true;
			useStyle = 5;
			useAnimation = 19;
			useTime = 19;
			width = 24;
			height = 28;
			shoot = 20;
			mana = 8;
			useSound = 12;
			knockBack = 0.5f;
			damage = 17;
			shootSpeed = 10f;
			noMelee = true;
			scale = 0.8f;
			rare = 1;
			magic = true;
			value = 20000;
			break;
		case 128:
			width = 28;
			height = 24;
			accessory = true;
			rare = 3;
			value = 50000;
			break;
		case 129:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 38;
			width = 12;
			height = 12;
			break;
		case 130:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 5;
			width = 12;
			height = 12;
			break;
		case 131:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 39;
			width = 12;
			height = 12;
			break;
		case 132:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 6;
			width = 12;
			height = 12;
			break;
		case 133:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 40;
			width = 12;
			height = 12;
			break;
		case 134:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 41;
			width = 12;
			height = 12;
			break;
		case 135:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 17;
			width = 12;
			height = 12;
			break;
		case 136:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 42;
			width = 12;
			height = 28;
			break;
		case 137:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 43;
			width = 12;
			height = 12;
			break;
		case 138:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 18;
			width = 12;
			height = 12;
			break;
		case 139:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 44;
			width = 12;
			height = 12;
			break;
		case 140:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 19;
			width = 12;
			height = 12;
			break;
		case 141:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 45;
			width = 12;
			height = 12;
			break;
		case 142:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 10;
			width = 12;
			height = 12;
			break;
		case 143:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 46;
			width = 12;
			height = 12;
			break;
		case 144:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 11;
			width = 12;
			height = 12;
			break;
		case 145:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 47;
			width = 12;
			height = 12;
			break;
		case 146:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 12;
			width = 12;
			height = 12;
			break;
		case 147:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 48;
			width = 12;
			height = 12;
			break;
		case 148:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 49;
			width = 8;
			height = 18;
			holdStyle = 1;
			break;
		case 149:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 50;
			width = 24;
			height = 28;
			break;
		case 150:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			maxStack = 250;
			consumable = true;
			createTile = 51;
			width = 20;
			height = 24;
			alpha = 100;
			break;
		case 151:
			width = 18;
			height = 18;
			defense = 5;
			headSlot = 7;
			rare = 2;
			value = 45000;
			break;
		case 152:
			width = 18;
			height = 18;
			defense = 6;
			bodySlot = 7;
			rare = 2;
			value = 30000;
			break;
		case 153:
			width = 18;
			height = 18;
			defense = 5;
			legSlot = 7;
			rare = 2;
			value = 30000;
			break;
		case 154:
			maxStack = 99;
			consumable = true;
			width = 12;
			height = 14;
			value = 50;
			useAnimation = 12;
			useTime = 12;
			useStyle = 1;
			useSound = 1;
			shootSpeed = 8f;
			noUseGraphic = true;
			damage = 22;
			knockBack = 4f;
			shoot = 21;
			ranged = true;
			break;
		case 155:
			autoReuse = true;
			useTurn = true;
			useStyle = 1;
			useAnimation = 20;
			width = 40;
			height = 40;
			damage = 18;
			scale = 1.1f;
			useSound = 1;
			rare = 2;
			value = 27000;
			knockBack = 1f;
			melee = true;
			break;
		case 156:
			width = 24;
			height = 28;
			rare = 2;
			value = 27000;
			accessory = true;
			defense = 1;
			break;
		case 157:
			mana = 7;
			autoReuse = true;
			useStyle = 5;
			useAnimation = 16;
			useTime = 8;
			knockBack = 5f;
			width = 38;
			height = 10;
			damage = 14;
			scale = 1f;
			shoot = 22;
			shootSpeed = 11f;
			useSound = 13;
			rare = 2;
			value = 27000;
			magic = true;
			break;
		case 158:
			width = 20;
			height = 22;
			rare = 1;
			value = 27000;
			accessory = true;
			break;
		case 159:
			width = 14;
			height = 28;
			rare = 1;
			value = 27000;
			accessory = true;
			break;
		case 160:
			autoReuse = true;
			useStyle = 5;
			useAnimation = 30;
			useTime = 30;
			knockBack = 6f;
			width = 30;
			height = 10;
			damage = 25;
			scale = 1.1f;
			shoot = 23;
			shootSpeed = 11f;
			useSound = 10;
			rare = 2;
			value = 27000;
			ranged = true;
			break;
		case 161:
			useStyle = 1;
			shootSpeed = 5f;
			shoot = 24;
			knockBack = 1f;
			damage = 15;
			width = 10;
			height = 10;
			maxStack = 250;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			noMelee = true;
			value = 80;
			ranged = true;
			break;
		case 162:
			useStyle = 5;
			useAnimation = 45;
			useTime = 45;
			knockBack = 6.5f;
			width = 30;
			height = 10;
			damage = 15;
			scale = 1.1f;
			noUseGraphic = true;
			shoot = 25;
			shootSpeed = 12f;
			useSound = 1;
			rare = 1;
			value = 27000;
			melee = true;
			channel = true;
			noMelee = true;
			break;
		case 163:
			useStyle = 5;
			useAnimation = 45;
			useTime = 45;
			knockBack = 7f;
			width = 30;
			height = 10;
			damage = 23;
			scale = 1.1f;
			noUseGraphic = true;
			shoot = 26;
			shootSpeed = 12f;
			useSound = 1;
			rare = 2;
			value = 27000;
			melee = true;
			channel = true;
			break;
		case 164:
			autoReuse = false;
			useStyle = 5;
			useAnimation = 12;
			useTime = 12;
			width = 24;
			height = 24;
			shoot = 14;
			knockBack = 3f;
			useAmmo = 14;
			useSound = 11;
			damage = 14;
			shootSpeed = 10f;
			noMelee = true;
			value = 50000;
			scale = 0.75f;
			rare = 2;
			ranged = true;
			break;
		case 165:
			autoReuse = true;
			rare = 2;
			mana = 14;
			useSound = 21;
			useStyle = 5;
			damage = 17;
			useAnimation = 17;
			useTime = 17;
			width = 24;
			height = 28;
			shoot = 27;
			scale = 0.9f;
			shootSpeed = 4.5f;
			knockBack = 5f;
			magic = true;
			value = 50000;
			break;
		case 166:
			useStyle = 1;
			shootSpeed = 5f;
			shoot = 28;
			width = 20;
			height = 20;
			maxStack = 50;
			consumable = true;
			useSound = 1;
			useAnimation = 25;
			useTime = 25;
			noUseGraphic = true;
			noMelee = true;
			value = 500;
			damage = 0;
			break;
		case 167:
			useStyle = 1;
			shootSpeed = 4f;
			shoot = 29;
			width = 8;
			height = 28;
			maxStack = 5;
			consumable = true;
			useSound = 1;
			useAnimation = 40;
			useTime = 40;
			noUseGraphic = true;
			noMelee = true;
			value = 5000;
			rare = 1;
			break;
		case 168:
			useStyle = 5;
			shootSpeed = 5.5f;
			shoot = 30;
			width = 20;
			height = 20;
			maxStack = 99;
			consumable = true;
			useSound = 1;
			useAnimation = 45;
			useTime = 45;
			noUseGraphic = true;
			noMelee = true;
			value = 400;
			damage = 60;
			knockBack = 8f;
			ranged = true;
			break;
		case 169:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 53;
			width = 12;
			height = 12;
			ammo = 42;
			break;
		case 170:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 54;
			width = 12;
			height = 12;
			break;
		case 171:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 55;
			width = 28;
			height = 28;
			break;
		case 172:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 57;
			width = 12;
			height = 12;
			break;
		case 173:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 56;
			width = 12;
			height = 12;
			break;
		case 174:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 58;
			width = 12;
			height = 12;
			rare = 2;
			break;
		case 175:
			width = 20;
			height = 20;
			maxStack = 99;
			rare = 2;
			value = 20000;
			break;
		case 176:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 59;
			width = 12;
			height = 12;
			break;
		case 181:
			maxStack = 99;
			alpha = 50;
			width = 10;
			height = 14;
			value = 1875;
			break;
		case 180:
			maxStack = 99;
			alpha = 50;
			width = 10;
			height = 14;
			value = 3750;
			break;
		case 177:
			maxStack = 99;
			alpha = 50;
			width = 10;
			height = 14;
			value = 5625;
			break;
		case 179:
			maxStack = 99;
			alpha = 50;
			width = 10;
			height = 14;
			value = 7500;
			break;
		case 178:
			maxStack = 99;
			alpha = 50;
			width = 10;
			height = 14;
			value = 11250;
			break;
		case 182:
			maxStack = 99;
			alpha = 50;
			width = 10;
			height = 14;
			value = 15000;
			break;
		case 183:
			useStyle = 2;
			useSound = 2;
			useTurn = false;
			useAnimation = 17;
			useTime = 17;
			width = 16;
			height = 18;
			healLife = 25;
			maxStack = 99;
			consumable = true;
			potion = true;
			value = 50;
			break;
		case 184:
			width = 12;
			height = 12;
			break;
		case 185:
			noUseGraphic = true;
			damage = 0;
			knockBack = 7f;
			useStyle = 5;
			shootSpeed = 13f;
			shoot = 32;
			width = 18;
			height = 28;
			useSound = 1;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			value = 20000;
			break;
		case 186:
			width = 44;
			height = 44;
			rare = 1;
			value = 10000;
			holdStyle = 2;
			break;
		case 187:
			width = 28;
			height = 28;
			rare = 1;
			value = 10000;
			accessory = true;
			break;
		case 188:
			useSound = 3;
			healLife = 100;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			rare = 1;
			potion = true;
			value = 1000;
			break;
		case 189:
			useSound = 3;
			healMana = 100;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 50;
			consumable = true;
			width = 14;
			height = 24;
			rare = 1;
			value = 250;
			break;
		case 190:
			useStyle = 1;
			useAnimation = 30;
			knockBack = 3f;
			width = 40;
			height = 40;
			damage = 28;
			scale = 1.4f;
			useSound = 1;
			rare = 3;
			value = 27000;
			melee = true;
			break;
		case 191:
			noMelee = true;
			useStyle = 1;
			shootSpeed = 11f;
			shoot = 33;
			damage = 25;
			knockBack = 8f;
			width = 14;
			height = 28;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			rare = 3;
			value = 50000;
			melee = true;
			break;
		case 192:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 75;
			width = 12;
			height = 12;
			break;
		case 193:
			width = 20;
			height = 22;
			rare = 2;
			value = 27000;
			accessory = true;
			defense = 1;
			break;
		case 194:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 70;
			width = 14;
			height = 14;
			value = 150;
			break;
		case 195:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 60;
			width = 14;
			height = 14;
			value = 150;
			break;
		case 196:
			autoReuse = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 37;
			useTime = 25;
			hammer = 25;
			width = 24;
			height = 28;
			damage = 2;
			knockBack = 5.5f;
			scale = 1.2f;
			useSound = 1;
			tileBoost = -1;
			value = 50;
			melee = true;
			break;
		case 197:
			autoReuse = true;
			useStyle = 5;
			useAnimation = 12;
			useTime = 12;
			width = 50;
			height = 18;
			shoot = 12;
			useAmmo = 15;
			useSound = 9;
			damage = 55;
			shootSpeed = 14f;
			noMelee = true;
			value = 500000;
			rare = 2;
			ranged = true;
			break;
		case 198:
			useStyle = 1;
			useAnimation = 25;
			knockBack = 3f;
			width = 40;
			height = 40;
			damage = 21;
			scale = 1f;
			useSound = 15;
			rare = 1;
			value = 27000;
			melee = true;
			break;
		case 199:
			useStyle = 1;
			useAnimation = 25;
			knockBack = 3f;
			width = 40;
			height = 40;
			damage = 21;
			scale = 1f;
			useSound = 15;
			rare = 1;
			value = 27000;
			melee = true;
			break;
		case 200:
			useStyle = 1;
			useAnimation = 25;
			knockBack = 3f;
			width = 40;
			height = 40;
			damage = 21;
			scale = 1f;
			useSound = 15;
			rare = 1;
			value = 27000;
			melee = true;
			break;
		case 201:
			useStyle = 1;
			useAnimation = 25;
			knockBack = 3f;
			width = 40;
			height = 40;
			damage = 21;
			scale = 1f;
			useSound = 15;
			rare = 1;
			value = 27000;
			melee = true;
			break;
		case 202:
			useStyle = 1;
			useAnimation = 25;
			knockBack = 3f;
			width = 40;
			height = 40;
			damage = 21;
			scale = 1f;
			useSound = 15;
			rare = 1;
			value = 27000;
			melee = true;
			break;
		case 203:
			useStyle = 1;
			useAnimation = 25;
			knockBack = 3f;
			width = 40;
			height = 40;
			damage = 21;
			scale = 1f;
			useSound = 15;
			rare = 1;
			value = 27000;
			melee = true;
			break;
		case 204:
			useTurn = true;
			autoReuse = true;
			useStyle = 1;
			useAnimation = 30;
			useTime = 16;
			hammer = 60;
			axe = 20;
			width = 24;
			height = 28;
			damage = 20;
			knockBack = 7f;
			scale = 1.2f;
			useSound = 1;
			rare = 1;
			value = 15000;
			melee = true;
			break;
		case 205:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			width = 20;
			height = 20;
			headSlot = 13;
			defense = 1;
			break;
		case 206:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			width = 20;
			height = 20;
			break;
		case 207:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			width = 20;
			height = 20;
			break;
		case 208:
			width = 20;
			height = 20;
			value = 100;
			headSlot = 23;
			vanity = true;
			break;
		case 209:
			width = 16;
			height = 18;
			maxStack = 99;
			value = 200;
			break;
		case 210:
			width = 14;
			height = 20;
			maxStack = 99;
			value = 1000;
			break;
		case 211:
			width = 20;
			height = 20;
			accessory = true;
			rare = 3;
			value = 50000;
			break;
		case 212:
			width = 20;
			height = 20;
			accessory = true;
			rare = 3;
			value = 50000;
			break;
		case 213:
			useStyle = 1;
			useTurn = true;
			useAnimation = 25;
			useTime = 13;
			autoReuse = true;
			width = 24;
			height = 28;
			damage = 7;
			createTile = 2;
			scale = 1.2f;
			useSound = 1;
			knockBack = 3f;
			rare = 3;
			value = 2000;
			melee = true;
			break;
		case 214:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 76;
			width = 12;
			height = 12;
			break;
		case 215:
			width = 18;
			height = 18;
			useTurn = true;
			useTime = 30;
			useAnimation = 30;
			noUseGraphic = true;
			useStyle = 10;
			useSound = 16;
			rare = 2;
			value = 100;
			break;
		case 216:
			width = 20;
			height = 20;
			rare = 1;
			value = 1500;
			accessory = true;
			defense = 1;
			break;
		case 217:
			useTurn = true;
			autoReuse = true;
			useStyle = 1;
			useAnimation = 27;
			useTime = 14;
			hammer = 70;
			axe = 30;
			width = 24;
			height = 28;
			damage = 20;
			knockBack = 7f;
			scale = 1.4f;
			useSound = 1;
			rare = 3;
			value = 15000;
			melee = true;
			break;
		case 218:
			mana = 16;
			channel = true;
			damage = 34;
			useStyle = 1;
			shootSpeed = 6f;
			shoot = 34;
			width = 26;
			height = 28;
			useSound = 20;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			knockBack = 6.5f;
			tileBoost = 64;
			value = 10000;
			magic = true;
			break;
		case 219:
			autoReuse = false;
			useStyle = 5;
			useAnimation = 11;
			useTime = 11;
			width = 24;
			height = 22;
			shoot = 14;
			knockBack = 2f;
			useAmmo = 14;
			useSound = 11;
			damage = 23;
			shootSpeed = 13f;
			noMelee = true;
			value = 50000;
			scale = 0.75f;
			rare = 3;
			ranged = true;
			break;
		case 220:
			noMelee = true;
			useStyle = 5;
			useAnimation = 45;
			useTime = 45;
			knockBack = 7f;
			width = 30;
			height = 10;
			damage = 33;
			scale = 1.1f;
			noUseGraphic = true;
			shoot = 35;
			shootSpeed = 12f;
			useSound = 1;
			rare = 3;
			value = 27000;
			melee = true;
			channel = true;
			break;
		case 221:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 77;
			width = 26;
			height = 24;
			value = 3000;
			break;
		case 222:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 78;
			width = 14;
			height = 14;
			value = 100;
			break;
		case 223:
			width = 20;
			height = 22;
			rare = 3;
			value = 27000;
			accessory = true;
			break;
		case 224:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 79;
			width = 28;
			height = 20;
			value = 2000;
			break;
		case 225:
			maxStack = 99;
			width = 22;
			height = 22;
			value = 1000;
			break;
		case 226:
			useSound = 3;
			healMana = 50;
			healLife = 50;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 20;
			consumable = true;
			width = 14;
			height = 24;
			potion = true;
			value = 2000;
			break;
		case 227:
			useSound = 3;
			healMana = 100;
			healLife = 100;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 20;
			consumable = true;
			width = 14;
			height = 24;
			potion = true;
			value = 4000;
			break;
		case 228:
			width = 18;
			height = 18;
			defense = 4;
			headSlot = 8;
			rare = 3;
			value = 45000;
			break;
		case 229:
			width = 18;
			height = 18;
			defense = 5;
			bodySlot = 8;
			rare = 3;
			value = 30000;
			break;
		case 230:
			width = 18;
			height = 18;
			defense = 4;
			legSlot = 8;
			rare = 3;
			value = 30000;
			break;
		case 231:
			width = 18;
			height = 18;
			defense = 8;
			headSlot = 9;
			rare = 3;
			value = 45000;
			break;
		case 232:
			width = 18;
			height = 18;
			defense = 9;
			bodySlot = 9;
			rare = 3;
			value = 30000;
			break;
		case 233:
			width = 18;
			height = 18;
			defense = 8;
			legSlot = 9;
			rare = 3;
			value = 30000;
			break;
		case 234:
			shootSpeed = 3f;
			shoot = 36;
			damage = 9;
			width = 8;
			height = 8;
			maxStack = 250;
			consumable = true;
			ammo = 14;
			knockBack = 1f;
			value = 8;
			rare = 1;
			ranged = true;
			break;
		case 235:
			useStyle = 1;
			shootSpeed = 5f;
			shoot = 37;
			width = 20;
			height = 20;
			maxStack = 50;
			consumable = true;
			useSound = 1;
			useAnimation = 25;
			useTime = 25;
			noUseGraphic = true;
			noMelee = true;
			value = 500;
			damage = 0;
			break;
		case 236:
			width = 12;
			height = 20;
			maxStack = 99;
			value = 5000;
			break;
		case 237:
			width = 28;
			height = 12;
			headSlot = 12;
			rare = 2;
			value = 10000;
			vanity = true;
			break;
		case 238:
			width = 28;
			height = 20;
			headSlot = 14;
			rare = 2;
			value = 10000;
			defense = 2;
			break;
		case 239:
			width = 18;
			height = 18;
			headSlot = 15;
			value = 10000;
			vanity = true;
			break;
		case 240:
			width = 18;
			height = 18;
			bodySlot = 10;
			value = 5000;
			vanity = true;
			break;
		case 241:
			width = 18;
			height = 18;
			legSlot = 10;
			value = 5000;
			vanity = true;
			break;
		case 242:
			width = 18;
			height = 18;
			headSlot = 16;
			value = 10000;
			vanity = true;
			break;
		case 243:
			width = 18;
			height = 18;
			headSlot = 17;
			value = 20000;
			vanity = true;
			break;
		case 244:
			width = 18;
			height = 12;
			headSlot = 18;
			value = 10000;
			vanity = true;
			break;
		case 245:
			width = 18;
			height = 18;
			bodySlot = 11;
			value = 250000;
			vanity = true;
			break;
		case 246:
			width = 18;
			height = 18;
			legSlot = 11;
			value = 250000;
			vanity = true;
			break;
		case 247:
			width = 18;
			height = 12;
			headSlot = 19;
			value = 10000;
			vanity = true;
			break;
		case 248:
			width = 18;
			height = 18;
			bodySlot = 12;
			value = 5000;
			vanity = true;
			break;
		case 249:
			width = 18;
			height = 18;
			legSlot = 12;
			value = 5000;
			vanity = true;
			break;
		case 250:
			width = 18;
			height = 18;
			headSlot = 20;
			value = 10000;
			vanity = true;
			break;
		case 251:
			width = 18;
			height = 12;
			headSlot = 21;
			value = 10000;
			vanity = true;
			break;
		case 252:
			width = 18;
			height = 18;
			bodySlot = 13;
			value = 5000;
			vanity = true;
			break;
		case 253:
			width = 18;
			height = 18;
			legSlot = 13;
			value = 5000;
			vanity = true;
			break;
		case 254:
			maxStack = 99;
			width = 12;
			height = 20;
			value = 10000;
			break;
		case 255:
			maxStack = 99;
			width = 12;
			height = 20;
			value = 2000;
			break;
		case 256:
			width = 18;
			height = 12;
			headSlot = 22;
			value = 10000;
			vanity = true;
			break;
		case 257:
			width = 18;
			height = 18;
			bodySlot = 14;
			value = 5000;
			vanity = true;
			break;
		case 258:
			width = 18;
			height = 18;
			legSlot = 14;
			value = 5000;
			vanity = true;
			break;
		case 259:
			width = 18;
			height = 20;
			maxStack = 99;
			value = 50;
			break;
		case 260:
			width = 18;
			height = 14;
			headSlot = 24;
			value = 1000;
			vanity = true;
			break;
		case 261:
			useStyle = 2;
			useSound = 2;
			useTurn = false;
			useAnimation = 17;
			useTime = 17;
			width = 20;
			height = 10;
			maxStack = 99;
			healLife = 20;
			consumable = true;
			value = 1000;
			potion = true;
			break;
		case 262:
			width = 18;
			height = 14;
			bodySlot = 15;
			value = 2000;
			vanity = true;
			break;
		case 263:
			width = 18;
			height = 18;
			headSlot = 25;
			value = 10000;
			vanity = true;
			break;
		case 264:
			width = 18;
			height = 18;
			headSlot = 26;
			value = 10000;
			vanity = true;
			break;
		case 265:
			shootSpeed = 6.5f;
			shoot = 41;
			damage = 10;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 8f;
			value = 100;
			rare = 2;
			ranged = true;
			break;
		case 618:
			shootSpeed = 6.6f;
			shoot = 114;
			damage = 12;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 8.2f;
			value = 150;
			rare = 3;
			ranged = true;
			break;
		case 266:
			useStyle = 5;
			useAnimation = 16;
			useTime = 16;
			autoReuse = true;
			width = 40;
			height = 20;
			shoot = 42;
			useAmmo = 42;
			useSound = 11;
			damage = 30;
			shootSpeed = 12f;
			noMelee = true;
			knockBack = 5f;
			value = 10000;
			rare = 2;
			ranged = true;
			break;
		case 267:
			accessory = true;
			width = 14;
			height = 26;
			value = 1000;
			break;
		case 268:
			headSlot = 27;
			defense = 2;
			width = 20;
			height = 20;
			value = 1000;
			rare = 2;
			break;
		case 269:
			bodySlot = 0;
			width = 20;
			height = 20;
			value = 10000;
			if (UI.current.player != null)
			{
				color = UI.current.player.shirtColor;
			}
			break;
		case 270:
			legSlot = 0;
			width = 20;
			height = 20;
			value = 10000;
			if (UI.current.player != null)
			{
				color = UI.current.player.pantsColor;
			}
			break;
		case 271:
			headSlot = 0;
			width = 20;
			height = 20;
			value = 10000;
			if (UI.current.player != null)
			{
				color = UI.current.player.hairColor;
			}
			break;
		case 272:
			mana = 14;
			damage = 35;
			useStyle = 5;
			shootSpeed = 0.2f;
			shoot = 45;
			width = 26;
			height = 28;
			useSound = 8;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			knockBack = 5f;
			scale = 0.9f;
			value = 10000;
			magic = true;
			break;
		case 273:
			useStyle = 1;
			useAnimation = 27;
			useTime = 27;
			knockBack = 4.5f;
			width = 40;
			height = 40;
			damage = 42;
			scale = 1.15f;
			useSound = 1;
			rare = 3;
			value = 27000;
			melee = true;
			break;
		case 274:
			useStyle = 5;
			useAnimation = 25;
			useTime = 25;
			shootSpeed = 5f;
			knockBack = 4f;
			width = 40;
			height = 40;
			damage = 27;
			scale = 1.1f;
			useSound = 1;
			shoot = 46;
			rare = 3;
			value = 27000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 275:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 81;
			width = 20;
			height = 22;
			value = 400;
			break;
		case 276:
			maxStack = 250;
			width = 12;
			height = 12;
			value = 10;
			break;
		case 277:
			useStyle = 5;
			useAnimation = 31;
			useTime = 31;
			shootSpeed = 4f;
			knockBack = 5f;
			width = 40;
			height = 40;
			damage = 10;
			scale = 1.1f;
			useSound = 1;
			shoot = 47;
			rare = 1;
			value = 10000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 278:
			shootSpeed = 4.5f;
			shoot = 14;
			damage = 9;
			width = 8;
			height = 8;
			maxStack = 250;
			consumable = true;
			ammo = 14;
			knockBack = 3f;
			value = 15;
			ranged = true;
			break;
		case 279:
			useStyle = 1;
			shootSpeed = 10f;
			shoot = 48;
			damage = 12;
			width = 18;
			height = 20;
			maxStack = 250;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			noMelee = true;
			value = 50;
			knockBack = 2f;
			ranged = true;
			break;
		case 280:
			useStyle = 5;
			useAnimation = 31;
			useTime = 31;
			shootSpeed = 3.7f;
			knockBack = 6.5f;
			width = 32;
			height = 32;
			damage = 8;
			scale = 1f;
			useSound = 1;
			shoot = 49;
			value = 1000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 281:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 45;
			useTime = 45;
			width = 38;
			height = 6;
			shoot = 10;
			useAmmo = 51;
			useSound = 5;
			damage = 9;
			shootSpeed = 11f;
			noMelee = true;
			value = 10000;
			knockBack = 4f;
			useAmmo = 51;
			ranged = true;
			break;
		case 282:
			useStyle = 1;
			shootSpeed = 6f;
			shoot = 50;
			width = 12;
			height = 12;
			maxStack = 99;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noMelee = true;
			value = 10;
			holdStyle = 1;
			break;
		case 283:
			shoot = 51;
			width = 8;
			height = 8;
			maxStack = 250;
			ammo = 51;
			break;
		case 284:
			noMelee = true;
			useStyle = 1;
			shootSpeed = 6.5f;
			shoot = 52;
			damage = 7;
			knockBack = 5f;
			width = 14;
			height = 28;
			useSound = 1;
			useAnimation = 16;
			useTime = 16;
			noUseGraphic = true;
			value = 5000;
			melee = true;
			break;
		case 285:
			width = 24;
			height = 8;
			accessory = true;
			value = 5000;
			break;
		case 286:
			useStyle = 1;
			shootSpeed = 6f;
			shoot = 53;
			width = 12;
			height = 12;
			maxStack = 99;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noMelee = true;
			value = 20;
			holdStyle = 1;
			break;
		case 287:
			useStyle = 1;
			shootSpeed = 11f;
			shoot = 54;
			damage = 13;
			width = 18;
			height = 20;
			maxStack = 250;
			consumable = true;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			noMelee = true;
			value = 60;
			knockBack = 2f;
			ranged = true;
			break;
		case 288:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 1;
			buffTime = 14400;
			value = 1000;
			rare = 1;
			break;
		case 289:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 2;
			buffTime = 18000;
			value = 1000;
			rare = 1;
			break;
		case 290:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 3;
			buffTime = 14400;
			value = 1000;
			rare = 1;
			break;
		case 291:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 4;
			buffTime = 7200;
			value = 1000;
			rare = 1;
			break;
		case 292:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 5;
			buffTime = 18000;
			value = 1000;
			rare = 1;
			break;
		case 293:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 6;
			buffTime = 7200;
			value = 1000;
			rare = 1;
			break;
		case 294:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 7;
			buffTime = 7200;
			value = 1000;
			rare = 1;
			break;
		case 295:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 8;
			buffTime = 18000;
			value = 1000;
			rare = 1;
			break;
		case 296:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 9;
			buffTime = 18000;
			value = 1000;
			rare = 1;
			break;
		case 297:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 10;
			buffTime = 7200;
			value = 1000;
			rare = 1;
			break;
		case 298:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 11;
			buffTime = 18000;
			value = 1000;
			rare = 1;
			break;
		case 299:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 12;
			buffTime = 14400;
			value = 1000;
			rare = 1;
			break;
		case 300:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 13;
			buffTime = 25200;
			value = 1000;
			rare = 1;
			break;
		case 301:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 14;
			buffTime = 7200;
			value = 1000;
			rare = 1;
			break;
		case 302:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 15;
			buffTime = 18000;
			value = 1000;
			rare = 1;
			break;
		case 303:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 16;
			buffTime = 14400;
			value = 1000;
			rare = 1;
			break;
		case 304:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 17;
			buffTime = 18000;
			value = 1000;
			rare = 1;
			break;
		case 305:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			buffType = 18;
			buffTime = 10800;
			value = 1000;
			rare = 1;
			break;
		case 306:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 21;
			placeStyle = 1;
			width = 26;
			height = 22;
			value = 5000;
			break;
		case 307:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 82;
			placeStyle = 0;
			width = 12;
			height = 14;
			value = 80;
			break;
		case 308:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 82;
			placeStyle = 1;
			width = 12;
			height = 14;
			value = 80;
			break;
		case 309:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 82;
			placeStyle = 2;
			width = 12;
			height = 14;
			value = 80;
			break;
		case 310:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 82;
			placeStyle = 3;
			width = 12;
			height = 14;
			value = 80;
			break;
		case 311:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 82;
			placeStyle = 4;
			width = 12;
			height = 14;
			value = 80;
			break;
		case 312:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 82;
			placeStyle = 5;
			width = 12;
			height = 14;
			value = 80;
			break;
		case 313:
			maxStack = 99;
			width = 12;
			height = 14;
			value = 100;
			break;
		case 314:
			maxStack = 99;
			width = 12;
			height = 14;
			value = 100;
			break;
		case 315:
			maxStack = 99;
			width = 12;
			height = 14;
			value = 100;
			break;
		case 316:
			maxStack = 99;
			width = 12;
			height = 14;
			value = 100;
			break;
		case 317:
			maxStack = 99;
			width = 12;
			height = 14;
			value = 100;
			break;
		case 318:
			maxStack = 99;
			width = 12;
			height = 14;
			value = 100;
			break;
		case 319:
			maxStack = 99;
			width = 16;
			height = 14;
			value = 200;
			break;
		case 320:
			maxStack = 99;
			width = 16;
			height = 14;
			value = 50;
			break;
		case 321:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 85;
			width = 20;
			height = 20;
			break;
		case 322:
			headSlot = 28;
			width = 20;
			height = 20;
			value = 20000;
			break;
		case 323:
			width = 10;
			height = 20;
			maxStack = 99;
			value = 50;
			break;
		case 324:
			width = 10;
			height = 20;
			maxStack = 99;
			value = 750000;
			break;
		case 325:
			width = 18;
			height = 18;
			bodySlot = 16;
			value = 200000;
			vanity = true;
			break;
		case 326:
			width = 18;
			height = 18;
			legSlot = 15;
			value = 200000;
			vanity = true;
			break;
		case 327:
			width = 14;
			height = 20;
			maxStack = 99;
			break;
		case 328:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 21;
			placeStyle = 3;
			width = 26;
			height = 22;
			value = 5000;
			break;
		case 329:
			width = 14;
			height = 20;
			maxStack = 1;
			value = 75000;
			break;
		case 330:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 20;
			width = 12;
			height = 12;
			break;
		case 331:
			width = 18;
			height = 16;
			maxStack = 99;
			value = 100;
			break;
		case 332:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 86;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 333:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 87;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 334:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 88;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 335:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 89;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 336:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 90;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 337:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 91;
			placeStyle = 0;
			width = 10;
			height = 24;
			value = 500;
			break;
		case 338:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 91;
			placeStyle = 1;
			width = 10;
			height = 24;
			value = 500;
			break;
		case 339:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 91;
			placeStyle = 2;
			width = 10;
			height = 24;
			value = 500;
			break;
		case 340:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 91;
			placeStyle = 3;
			width = 10;
			height = 24;
			value = 500;
			break;
		case 341:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 92;
			width = 10;
			height = 24;
			value = 500;
			break;
		case 342:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 93;
			width = 10;
			height = 24;
			value = 500;
			break;
		case 343:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 21;
			placeStyle = 5;
			width = 20;
			height = 20;
			value = 500;
			break;
		case 344:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 95;
			width = 20;
			height = 20;
			value = 500;
			break;
		case 345:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 96;
			width = 20;
			height = 20;
			value = 500;
			break;
		case 346:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 97;
			width = 20;
			height = 20;
			value = 500000;
			break;
		case 347:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 98;
			width = 20;
			height = 20;
			value = 500;
			break;
		case 348:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 21;
			placeStyle = 6;
			width = 20;
			height = 20;
			value = 1000;
			break;
		case 349:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 100;
			width = 20;
			height = 20;
			value = 1500;
			break;
		case 350:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 13;
			placeStyle = 3;
			width = 16;
			height = 24;
			value = 70;
			break;
		case 351:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 13;
			placeStyle = 4;
			width = 16;
			height = 24;
			value = 20;
			break;
		case 352:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 94;
			width = 24;
			height = 24;
			value = 600;
			break;
		case 353:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 10;
			height = 10;
			buffType = 25;
			buffTime = 7200;
			value = 100;
			break;
		case 354:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 101;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 355:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 102;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 356:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 103;
			width = 16;
			height = 24;
			value = 20;
			break;
		case 357:
			useSound = 3;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 10;
			height = 10;
			buffType = 26;
			buffTime = 36000;
			rare = 1;
			value = 1000;
			break;
		case 358:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 15;
			placeStyle = 1;
			width = 12;
			height = 30;
			value = 150;
			break;
		case 359:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 104;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 360:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 361:
			useStyle = 4;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			width = 28;
			height = 28;
			break;
		case 362:
			maxStack = 99;
			width = 24;
			height = 24;
			value = 30;
			break;
		case 363:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 106;
			width = 20;
			height = 20;
			value = 300;
			break;
		case 364:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 107;
			width = 12;
			height = 12;
			value = 3500;
			rare = 3;
			break;
		case 365:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 108;
			width = 12;
			height = 12;
			value = 5500;
			rare = 3;
			break;
		case 366:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 111;
			width = 12;
			height = 12;
			value = 7500;
			rare = 3;
			break;
		case 367:
			useTurn = true;
			autoReuse = true;
			useStyle = 1;
			useAnimation = 27;
			useTime = 14;
			hammer = 80;
			width = 24;
			height = 28;
			damage = 26;
			knockBack = 7.5f;
			scale = 1.2f;
			useSound = 1;
			rare = 4;
			value = 39000;
			melee = true;
			break;
		case 368:
			autoReuse = true;
			useStyle = 1;
			useAnimation = 25;
			useTime = 25;
			knockBack = 4.5f;
			width = 40;
			height = 40;
			damage = 47;
			scale = 1.15f;
			useSound = 1;
			rare = 5;
			value = 230000;
			melee = true;
			break;
		case 613:
			autoReuse = true;
			useStyle = 1;
			useAnimation = 25;
			useTime = 25;
			knockBack = 4.6f;
			width = 40;
			height = 40;
			damage = 55;
			scale = 1.15f;
			useSound = 1;
			rare = 5;
			value = 300000;
			melee = true;
			break;
		case 369:
			useTurn = true;
			useStyle = 1;
			useAnimation = 15;
			useTime = 10;
			maxStack = 99;
			consumable = true;
			createTile = 109;
			width = 14;
			height = 14;
			value = 2000;
			rare = 3;
			break;
		case 370:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 112;
			width = 12;
			height = 12;
			ammo = 42;
			break;
		case 371:
			width = 18;
			height = 18;
			defense = 2;
			headSlot = 29;
			rare = 4;
			value = 75000;
			break;
		case 372:
			width = 18;
			height = 18;
			defense = 11;
			headSlot = 30;
			rare = 4;
			value = 75000;
			break;
		case 373:
			width = 18;
			height = 18;
			defense = 4;
			headSlot = 31;
			rare = 4;
			value = 75000;
			break;
		case 374:
			width = 18;
			height = 18;
			defense = 8;
			bodySlot = 17;
			rare = 4;
			value = 60000;
			break;
		case 375:
			width = 18;
			height = 18;
			defense = 7;
			legSlot = 16;
			rare = 4;
			value = 45000;
			break;
		case 376:
			width = 18;
			height = 18;
			defense = 3;
			headSlot = 32;
			rare = 4;
			value = 112500;
			break;
		case 377:
			width = 18;
			height = 18;
			defense = 16;
			headSlot = 33;
			rare = 4;
			value = 112500;
			break;
		case 378:
			width = 18;
			height = 18;
			defense = 6;
			headSlot = 34;
			rare = 4;
			value = 112500;
			break;
		case 379:
			width = 18;
			height = 18;
			defense = 12;
			bodySlot = 18;
			rare = 4;
			value = 90000;
			break;
		case 380:
			width = 18;
			height = 18;
			defense = 9;
			legSlot = 17;
			rare = 4;
			value = 67500;
			break;
		case 381:
			width = 20;
			height = 20;
			maxStack = 99;
			value = 10500;
			rare = 3;
			break;
		case 382:
			width = 20;
			height = 20;
			maxStack = 99;
			value = 22000;
			rare = 3;
			break;
		case 383:
			useStyle = 5;
			useAnimation = 25;
			useTime = 8;
			shootSpeed = 40f;
			knockBack = 2.75f;
			width = 20;
			height = 12;
			damage = 23;
			axe = 14;
			useSound = 23;
			shoot = 57;
			rare = 4;
			value = 54000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			channel = true;
			break;
		case 384:
			useStyle = 5;
			useAnimation = 25;
			useTime = 8;
			shootSpeed = 40f;
			knockBack = 3f;
			width = 20;
			height = 12;
			damage = 29;
			axe = 17;
			useSound = 23;
			shoot = 58;
			rare = 4;
			value = 81000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			channel = true;
			break;
		case 385:
			useStyle = 5;
			useAnimation = 25;
			useTime = 13;
			shootSpeed = 32f;
			knockBack = 0f;
			width = 20;
			height = 12;
			damage = 10;
			pick = 110;
			useSound = 23;
			shoot = 59;
			rare = 4;
			value = 54000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			channel = true;
			break;
		case 386:
			useStyle = 5;
			useAnimation = 25;
			useTime = 10;
			shootSpeed = 32f;
			knockBack = 0f;
			width = 20;
			height = 12;
			damage = 15;
			pick = 150;
			useSound = 23;
			shoot = 60;
			rare = 4;
			value = 81000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			channel = true;
			break;
		case 387:
			useStyle = 5;
			useAnimation = 25;
			useTime = 6;
			shootSpeed = 40f;
			knockBack = 4.5f;
			width = 20;
			height = 12;
			damage = 33;
			axe = 20;
			useSound = 23;
			shoot = 61;
			rare = 4;
			value = 108000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			channel = true;
			break;
		case 388:
			useStyle = 5;
			useAnimation = 25;
			useTime = 7;
			shootSpeed = 32f;
			knockBack = 0f;
			width = 20;
			height = 12;
			damage = 20;
			pick = 180;
			useSound = 23;
			shoot = 62;
			rare = 4;
			value = 108000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			channel = true;
			break;
		case 389:
			noMelee = true;
			useStyle = 5;
			useAnimation = 45;
			useTime = 45;
			knockBack = 7f;
			width = 30;
			height = 10;
			damage = 49;
			scale = 1.1f;
			noUseGraphic = true;
			shoot = 63;
			shootSpeed = 15f;
			useSound = 1;
			rare = 5;
			value = 144000;
			melee = true;
			channel = true;
			break;
		case 390:
			useStyle = 5;
			useAnimation = 26;
			useTime = 26;
			shootSpeed = 4.5f;
			knockBack = 5f;
			width = 40;
			height = 40;
			damage = 35;
			scale = 1.1f;
			useSound = 1;
			shoot = 64;
			rare = 4;
			value = 67500;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 391:
			width = 20;
			height = 20;
			maxStack = 99;
			value = 37500;
			rare = 3;
			break;
		case 392:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 21;
			width = 12;
			height = 12;
			break;
		case 393:
			width = 24;
			height = 28;
			rare = 3;
			value = 100000;
			accessory = true;
			break;
		case 394:
			width = 24;
			height = 28;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 395:
			width = 24;
			height = 28;
			rare = 4;
			value = 150000;
			accessory = true;
			break;
		case 396:
			width = 24;
			height = 28;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 397:
			width = 24;
			height = 28;
			rare = 4;
			value = 100000;
			accessory = true;
			defense = 2;
			break;
		case 398:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 114;
			width = 26;
			height = 20;
			value = 100000;
			break;
		case 399:
			width = 14;
			height = 28;
			rare = 4;
			value = 150000;
			accessory = true;
			break;
		case 400:
			width = 18;
			height = 18;
			defense = 4;
			headSlot = 35;
			rare = 4;
			value = 150000;
			break;
		case 401:
			width = 18;
			height = 18;
			defense = 22;
			headSlot = 36;
			rare = 4;
			value = 150000;
			break;
		case 402:
			width = 18;
			height = 18;
			defense = 8;
			headSlot = 37;
			rare = 4;
			value = 150000;
			break;
		case 403:
			width = 18;
			height = 18;
			defense = 14;
			bodySlot = 19;
			rare = 4;
			value = 120000;
			break;
		case 404:
			width = 18;
			height = 18;
			defense = 10;
			legSlot = 18;
			rare = 4;
			value = 90000;
			break;
		case 405:
			width = 28;
			height = 24;
			accessory = true;
			rare = 4;
			value = 100000;
			break;
		case 406:
			useStyle = 5;
			useAnimation = 25;
			useTime = 25;
			shootSpeed = 5f;
			knockBack = 6f;
			width = 40;
			height = 40;
			damage = 38;
			scale = 1.1f;
			useSound = 1;
			shoot = 66;
			rare = 4;
			value = 90000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 407:
			width = 28;
			height = 24;
			accessory = true;
			rare = 3;
			value = 100000;
			break;
		case 408:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 116;
			width = 12;
			height = 12;
			ammo = 42;
			break;
		case 409:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 117;
			width = 12;
			height = 12;
			break;
		case 410:
			width = 18;
			height = 18;
			defense = 1;
			bodySlot = 20;
			value = 5000;
			rare = 1;
			break;
		case 411:
			width = 18;
			height = 18;
			defense = 1;
			legSlot = 19;
			value = 5000;
			rare = 1;
			break;
		case 412:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 118;
			width = 12;
			height = 12;
			break;
		case 413:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 119;
			width = 12;
			height = 12;
			break;
		case 414:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 120;
			width = 12;
			height = 12;
			break;
		case 415:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 121;
			width = 12;
			height = 12;
			break;
		case 416:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 122;
			width = 12;
			height = 12;
			break;
		case 417:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 22;
			width = 12;
			height = 12;
			break;
		case 418:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 23;
			width = 12;
			height = 12;
			break;
		case 419:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 24;
			width = 12;
			height = 12;
			break;
		case 420:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 25;
			width = 12;
			height = 12;
			break;
		case 421:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 26;
			width = 12;
			height = 12;
			break;
		case 422:
			useStyle = 1;
			shootSpeed = 9f;
			rare = 3;
			damage = 20;
			shoot = 69;
			width = 18;
			height = 20;
			maxStack = 250;
			consumable = true;
			knockBack = 3f;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			noMelee = true;
			value = 200;
			break;
		case 423:
			useStyle = 1;
			shootSpeed = 9f;
			rare = 3;
			damage = 20;
			shoot = 70;
			width = 18;
			height = 20;
			maxStack = 250;
			consumable = true;
			knockBack = 3f;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			noMelee = true;
			value = 200;
			break;
		case 424:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 123;
			width = 12;
			height = 12;
			break;
		case 425:
			mana = 40;
			channel = true;
			damage = 0;
			useStyle = 1;
			shoot = 72;
			width = 24;
			height = 24;
			useSound = 25;
			useAnimation = 20;
			useTime = 20;
			rare = 5;
			noMelee = true;
			value = (value = 250000);
			buffType = 27;
			buffTime = 18000;
			break;
		case 426:
			useStyle = 1;
			useAnimation = 30;
			knockBack = 8f;
			width = 60;
			height = 70;
			damage = 39;
			scale = 1.05f;
			useSound = 1;
			rare = 4;
			value = 150000;
			melee = true;
			break;
		case 427:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 1;
			width = 10;
			height = 12;
			value = 200;
			break;
		case 428:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 2;
			width = 10;
			height = 12;
			value = 200;
			break;
		case 429:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 3;
			width = 10;
			height = 12;
			value = 200;
			break;
		case 430:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 4;
			width = 10;
			height = 12;
			value = 200;
			break;
		case 431:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 5;
			width = 10;
			height = 12;
			value = 500;
			break;
		case 432:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 6;
			width = 10;
			height = 12;
			value = 200;
			break;
		case 433:
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 7;
			width = 10;
			height = 12;
			value = 300;
			break;
		case 434:
			autoReuse = true;
			useStyle = 5;
			useAnimation = 12;
			useTime = 4;
			reuseDelay = 14;
			width = 50;
			height = 18;
			shoot = 10;
			useAmmo = 14;
			useSound = 31;
			damage = 19;
			shootSpeed = 7.75f;
			noMelee = true;
			value = 150000;
			rare = 4;
			ranged = true;
			break;
		case 435:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 25;
			useTime = 25;
			width = 50;
			height = 18;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 30;
			shootSpeed = 9f;
			noMelee = true;
			value = 60000;
			ranged = true;
			rare = 4;
			knockBack = 1.5f;
			break;
		case 436:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 23;
			useTime = 23;
			width = 50;
			height = 18;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 34;
			shootSpeed = 9.5f;
			noMelee = true;
			value = 90000;
			ranged = true;
			rare = 4;
			knockBack = 2f;
			break;
		case 437:
			noUseGraphic = true;
			damage = 0;
			knockBack = 7f;
			useStyle = 5;
			shootSpeed = 14f;
			shoot = 73;
			width = 18;
			height = 28;
			useSound = 1;
			useAnimation = 20;
			useTime = 20;
			rare = 4;
			noMelee = true;
			value = 200000;
			break;
		case 438:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 2;
			break;
		case 439:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 3;
			break;
		case 440:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 4;
			break;
		case 441:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 5;
			break;
		case 442:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 6;
			break;
		case 443:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 7;
			break;
		case 444:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 8;
			break;
		case 445:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 9;
			break;
		case 446:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 10;
			break;
		case 447:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 11;
			break;
		case 448:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 12;
			break;
		case 449:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 13;
			break;
		case 450:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 14;
			break;
		case 451:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 15;
			break;
		case 452:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 16;
			break;
		case 453:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 17;
			break;
		case 454:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 18;
			break;
		case 455:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 19;
			break;
		case 456:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 20;
			break;
		case 457:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 21;
			break;
		case 458:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 22;
			break;
		case 459:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 23;
			break;
		case 460:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 24;
			break;
		case 461:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 25;
			break;
		case 462:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 26;
			break;
		case 463:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 27;
			break;
		case 464:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 28;
			break;
		case 465:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 29;
			break;
		case 466:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 30;
			break;
		case 467:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 31;
			break;
		case 468:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 32;
			break;
		case 469:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 33;
			break;
		case 470:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 34;
			break;
		case 471:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 35;
			break;
		case 472:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 36;
			break;
		case 473:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 37;
			break;
		case 474:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 38;
			break;
		case 475:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 39;
			break;
		case 476:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 40;
			break;
		case 477:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 41;
			break;
		case 478:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 105;
			width = 20;
			height = 20;
			value = 300;
			placeStyle = 42;
			break;
		case 479:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 7;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 27;
			width = 12;
			height = 12;
			break;
		case 480:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 124;
			width = 12;
			height = 12;
			break;
		case 481:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 20;
			useTime = 20;
			width = 50;
			height = 18;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 37;
			shootSpeed = 10f;
			noMelee = true;
			value = 120000;
			ranged = true;
			rare = 4;
			knockBack = 2.5f;
			break;
		case 482:
			useStyle = 1;
			useAnimation = 27;
			useTime = 27;
			knockBack = 6f;
			width = 40;
			height = 40;
			damage = 44;
			scale = 1.2f;
			useSound = 1;
			rare = 4;
			value = 138000;
			melee = true;
			break;
		case 483:
			useTurn = true;
			autoReuse = true;
			useStyle = 1;
			useAnimation = 23;
			useTime = 23;
			knockBack = 3.85f;
			width = 40;
			height = 40;
			damage = 34;
			scale = 1.1f;
			useSound = 1;
			rare = 4;
			value = 69000;
			melee = true;
			break;
		case 484:
			useStyle = 1;
			useAnimation = 26;
			useTime = 26;
			knockBack = 6f;
			width = 40;
			height = 40;
			damage = 39;
			scale = 1.15f;
			useSound = 1;
			rare = 4;
			value = 103500;
			melee = true;
			break;
		case 485:
			rare = 4;
			width = 24;
			height = 28;
			accessory = true;
			value = 150000;
			break;
		case 486:
			width = 10;
			height = 26;
			accessory = true;
			value = 10000;
			rare = 1;
			break;
		case 487:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 125;
			width = 22;
			height = 22;
			value = 100000;
			rare = 3;
			break;
		case 488:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 126;
			width = 22;
			height = 26;
			value = 10000;
			break;
		case 489:
			width = 24;
			height = 24;
			accessory = true;
			value = 100000;
			rare = 4;
			break;
		case 491:
			width = 24;
			height = 24;
			accessory = true;
			value = 100000;
			break;
		case 490:
			width = 24;
			height = 24;
			accessory = true;
			value = 100000;
			rare = 4;
			break;
		case 492:
			width = 24;
			height = 8;
			accessory = true;
			value = 400000;
			rare = 5;
			break;
		case 493:
			width = 24;
			height = 8;
			accessory = true;
			value = 400000;
			rare = 5;
			break;
		case 494:
			rare = 5;
			useStyle = 5;
			useAnimation = 12;
			useTime = 12;
			width = 12;
			height = 28;
			shoot = 76;
			holdStyle = 3;
			autoReuse = true;
			damage = 30;
			shootSpeed = 4.5f;
			noMelee = true;
			value = 200000;
			mana = 4;
			magic = true;
			break;
		case 495:
			rare = 5;
			mana = 10;
			channel = true;
			damage = 53;
			useStyle = 1;
			shootSpeed = 6f;
			shoot = 79;
			width = 26;
			height = 28;
			useSound = 28;
			useAnimation = 15;
			useTime = 15;
			noMelee = true;
			knockBack = 5f;
			tileBoost = 64;
			value = 200000;
			magic = true;
			break;
		case 496:
			rare = 4;
			mana = 7;
			damage = 26;
			useStyle = 1;
			shootSpeed = 12f;
			shoot = 80;
			width = 26;
			height = 28;
			useSound = 28;
			useAnimation = 17;
			useTime = 17;
			rare = 4;
			autoReuse = true;
			noMelee = true;
			knockBack = 0f;
			value = 1000000;
			magic = true;
			knockBack = 2f;
			break;
		case 497:
			width = 24;
			height = 28;
			accessory = true;
			value = 150000;
			rare = 5;
			break;
		case 498:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 128;
			width = 12;
			height = 12;
			break;
		case 499:
			useSound = 3;
			healLife = 150;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 30;
			consumable = true;
			width = 14;
			height = 24;
			rare = 3;
			potion = true;
			value = 5000;
			break;
		case 500:
			useSound = 3;
			healMana = 200;
			useStyle = 2;
			useTurn = true;
			useAnimation = 17;
			useTime = 17;
			maxStack = 99;
			consumable = true;
			width = 14;
			height = 24;
			rare = 3;
			value = 500;
			break;
		case 501:
			width = 16;
			height = 14;
			maxStack = 99;
			value = 500;
			rare = 1;
			break;
		case 502:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 129;
			width = 24;
			height = 24;
			value = 8000;
			rare = 1;
			break;
		case 503:
			width = 18;
			height = 18;
			headSlot = 40;
			value = 20000;
			vanity = true;
			rare = 2;
			break;
		case 504:
			width = 18;
			height = 18;
			bodySlot = 23;
			value = 10000;
			vanity = true;
			rare = 2;
			break;
		case 505:
			width = 18;
			height = 18;
			legSlot = 22;
			value = 10000;
			vanity = true;
			rare = 2;
			break;
		case 506:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 30;
			useTime = 6;
			width = 50;
			height = 18;
			shoot = 85;
			useAmmo = 23;
			useSound = 34;
			damage = 27;
			knockBack = 0.3f;
			shootSpeed = 7f;
			noMelee = true;
			value = 500000;
			rare = 5;
			ranged = true;
			break;
		case 507:
			rare = 3;
			useStyle = 1;
			useAnimation = 12;
			useTime = 12;
			width = 12;
			height = 28;
			autoReuse = true;
			noMelee = true;
			value = 10000;
			break;
		case 508:
			rare = 3;
			useStyle = 5;
			useAnimation = 12;
			useTime = 12;
			width = 12;
			height = 28;
			autoReuse = true;
			noMelee = true;
			value = 10000;
			break;
		case 509:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			width = 24;
			height = 28;
			rare = 1;
			value = 20000;
			mech = true;
			break;
		case 510:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			width = 24;
			height = 28;
			rare = 1;
			value = 20000;
			mech = true;
			break;
		case 511:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 130;
			width = 12;
			height = 12;
			value = 1000;
			mech = true;
			break;
		case 512:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 131;
			width = 12;
			height = 12;
			value = 1000;
			mech = true;
			break;
		case 513:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 132;
			width = 24;
			height = 24;
			value = 3000;
			mech = true;
			break;
		case 514:
			autoReuse = true;
			useStyle = 5;
			useAnimation = 12;
			useTime = 12;
			width = 36;
			height = 22;
			shoot = 88;
			mana = 8;
			useSound = 12;
			knockBack = 2.5f;
			damage = 29;
			shootSpeed = 17f;
			noMelee = true;
			rare = 4;
			magic = true;
			value = 500000;
			break;
		case 515:
			shootSpeed = 5f;
			shoot = 89;
			damage = 9;
			width = 8;
			height = 8;
			maxStack = 250;
			consumable = true;
			ammo = 14;
			knockBack = 1f;
			value = 30;
			ranged = true;
			rare = 3;
			break;
		case 516:
			shootSpeed = 3.5f;
			shoot = 91;
			damage = 6;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 2f;
			value = 80;
			ranged = true;
			rare = 3;
			break;
		case 517:
			useStyle = 1;
			shootSpeed = 10f;
			shoot = 93;
			damage = 28;
			width = 18;
			height = 20;
			mana = 7;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			noMelee = true;
			value = 1000000;
			knockBack = 2f;
			magic = true;
			rare = 4;
			break;
		case 518:
			autoReuse = true;
			rare = 4;
			mana = 5;
			useSound = 9;
			useStyle = 5;
			damage = 26;
			useAnimation = 7;
			useTime = 7;
			width = 24;
			height = 28;
			shoot = 94;
			scale = 0.9f;
			shootSpeed = 16f;
			knockBack = 5f;
			magic = true;
			value = 500000;
			break;
		case 519:
			autoReuse = true;
			rare = 4;
			mana = 14;
			useSound = 20;
			useStyle = 5;
			damage = 35;
			useAnimation = 20;
			useTime = 20;
			width = 24;
			height = 28;
			shoot = 95;
			scale = 0.9f;
			shootSpeed = 10f;
			knockBack = 6.5f;
			magic = true;
			value = 500000;
			break;
		case 520:
			width = 18;
			height = 18;
			maxStack = 250;
			value = 1000;
			rare = 3;
			break;
		case 521:
			width = 18;
			height = 18;
			maxStack = 250;
			value = 1000;
			rare = 3;
			break;
		case 620:
			width = 18;
			height = 18;
			maxStack = 250;
			value = 100000;
			rare = 5;
			break;
		case 522:
			width = 12;
			height = 14;
			maxStack = 99;
			value = 4000;
			rare = 3;
			break;
		case 523:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			holdStyle = 1;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 4;
			placeStyle = 8;
			width = 10;
			height = 12;
			value = 300;
			rare = 1;
			break;
		case 524:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 133;
			width = 44;
			height = 30;
			value = 50000;
			rare = 3;
			break;
		case 525:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 134;
			width = 28;
			height = 14;
			value = 25000;
			rare = 3;
			break;
		case 526:
			width = 14;
			height = 14;
			maxStack = 99;
			value = 15000;
			rare = 1;
			break;
		case 527:
			width = 14;
			height = 14;
			maxStack = 99;
			value = 4500;
			rare = 2;
			break;
		case 528:
			width = 14;
			height = 14;
			maxStack = 99;
			value = 4500;
			rare = 2;
			break;
		case 529:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 135;
			width = 12;
			height = 12;
			placeStyle = 0;
			mech = true;
			value = 5000;
			mech = true;
			break;
		case 530:
			width = 12;
			height = 18;
			maxStack = 250;
			value = 500;
			mech = true;
			break;
		case 531:
			width = 12;
			height = 18;
			maxStack = 99;
			value = 50000;
			rare = 1;
			break;
		case 532:
			width = 20;
			height = 24;
			value = 100000;
			accessory = true;
			rare = 4;
			break;
		case 533:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 7;
			useTime = 7;
			width = 50;
			height = 18;
			shoot = 10;
			useAmmo = 14;
			useSound = 11;
			damage = 23;
			shootSpeed = 10f;
			noMelee = true;
			value = 300000;
			rare = 5;
			knockBack = 1f;
			ranged = true;
			break;
		case 534:
			knockBack = 6.5f;
			useStyle = 5;
			useAnimation = 45;
			useTime = 45;
			width = 50;
			height = 14;
			shoot = 10;
			useAmmo = 14;
			useSound = 36;
			damage = 18;
			shootSpeed = 6f;
			noMelee = true;
			value = 700000;
			rare = 4;
			ranged = true;
			break;
		case 535:
			width = 12;
			height = 18;
			value = 100000;
			accessory = true;
			rare = 4;
			break;
		case 536:
			width = 12;
			height = 18;
			value = 100000;
			rare = 4;
			accessory = true;
			break;
		case 537:
			useStyle = 5;
			useAnimation = 28;
			useTime = 28;
			shootSpeed = 4.3f;
			knockBack = 4f;
			width = 40;
			height = 40;
			damage = 29;
			scale = 1.1f;
			useSound = 1;
			shoot = 97;
			rare = 4;
			value = 45000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 538:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 136;
			width = 12;
			height = 12;
			value = 2000;
			mech = true;
			break;
		case 539:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 137;
			width = 12;
			height = 12;
			value = 10000;
			mech = true;
			break;
		case 540:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 138;
			width = 12;
			height = 12;
			mech = true;
			break;
		case 541:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 135;
			width = 12;
			height = 12;
			placeStyle = 1;
			mech = true;
			value = 5000;
			break;
		case 542:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 135;
			width = 12;
			height = 12;
			placeStyle = 2;
			mech = true;
			value = 5000;
			break;
		case 543:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 135;
			width = 12;
			height = 12;
			placeStyle = 3;
			mech = true;
			value = 5000;
			break;
		case 544:
			useStyle = 4;
			width = 22;
			height = 14;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			maxStack = 20;
			rare = 3;
			break;
		case 545:
			shootSpeed = 4f;
			shoot = 103;
			damage = 14;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 3f;
			value = 80;
			ranged = true;
			rare = 3;
			break;
		case 616:
			shootSpeed = 4.2f;
			shoot = 113;
			damage = 16;
			width = 10;
			height = 28;
			maxStack = 250;
			consumable = true;
			ammo = 1;
			knockBack = 3.1f;
			value = 90;
			ranged = true;
			rare = 4;
			break;
		case 546:
			shootSpeed = 5f;
			shoot = 104;
			damage = 12;
			width = 8;
			height = 8;
			maxStack = 250;
			consumable = true;
			ammo = 14;
			knockBack = 4f;
			value = 30;
			rare = 1;
			ranged = true;
			rare = 3;
			break;
		case 547:
			width = 18;
			height = 18;
			maxStack = 250;
			value = 100000;
			rare = 5;
			break;
		case 548:
			width = 18;
			height = 18;
			maxStack = 250;
			value = 100000;
			rare = 5;
			break;
		case 549:
			width = 18;
			height = 18;
			maxStack = 250;
			value = 100000;
			rare = 5;
			break;
		case 550:
			useStyle = 5;
			useAnimation = 22;
			useTime = 22;
			shootSpeed = 5.6f;
			knockBack = 6.4f;
			width = 40;
			height = 40;
			damage = 42;
			scale = 1.1f;
			useSound = 1;
			shoot = 105;
			rare = 5;
			value = 1500000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 614:
			useStyle = 5;
			useAnimation = 20;
			useTime = 20;
			shootSpeed = 5.75f;
			knockBack = 6.7f;
			width = 40;
			height = 40;
			damage = 50;
			scale = 1.1f;
			useSound = 1;
			shoot = 112;
			rare = 5;
			value = 2000000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			break;
		case 551:
			width = 18;
			height = 18;
			defense = 15;
			bodySlot = 24;
			rare = 5;
			value = 200000;
			break;
		case 552:
			width = 18;
			height = 18;
			defense = 11;
			legSlot = 23;
			rare = 5;
			value = 150000;
			break;
		case 553:
			width = 18;
			height = 18;
			defense = 9;
			headSlot = 41;
			rare = 5;
			value = 250000;
			break;
		case 558:
			width = 18;
			height = 18;
			defense = 5;
			headSlot = 42;
			rare = 5;
			value = 250000;
			break;
		case 559:
			width = 18;
			height = 18;
			defense = 24;
			headSlot = 43;
			rare = 5;
			value = 250000;
			break;
		case 554:
			width = 20;
			height = 24;
			value = 1500;
			accessory = true;
			rare = 4;
			break;
		case 555:
			width = 20;
			height = 24;
			value = 50000;
			accessory = true;
			rare = 4;
			break;
		case 556:
			useStyle = 4;
			width = 22;
			height = 14;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			maxStack = 20;
			rare = 3;
			break;
		case 557:
			useStyle = 4;
			width = 22;
			height = 14;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			maxStack = 20;
			rare = 3;
			break;
		case 560:
			useStyle = 4;
			width = 22;
			height = 14;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			maxStack = 20;
			rare = 1;
			break;
		case 561:
			melee = true;
			autoReuse = true;
			noMelee = true;
			useStyle = 1;
			shootSpeed = 13f;
			shoot = 106;
			damage = 35;
			knockBack = 8f;
			width = 24;
			height = 24;
			useSound = 1;
			useAnimation = 15;
			useTime = 15;
			noUseGraphic = true;
			rare = 5;
			maxStack = 5;
			value = 500000;
			break;
		case 562:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 0;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 563:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 1;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 564:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 2;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 565:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 3;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 566:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 4;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 567:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 5;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 568:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 6;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 569:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 7;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 570:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 8;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 571:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 9;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 572:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 10;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 573:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 11;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 574:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 12;
			width = 24;
			height = 24;
			rare = 3;
			value = 100000;
			accessory = true;
			break;
		case 626:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 13;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 627:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 14;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 628:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 15;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 629:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 16;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 630:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 17;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 631:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			consumable = true;
			createTile = 139;
			placeStyle = 18;
			width = 24;
			height = 24;
			rare = 4;
			value = 100000;
			accessory = true;
			break;
		case 575:
			width = 18;
			height = 18;
			maxStack = 250;
			value = 1000;
			rare = 3;
			break;
		case 576:
			width = 24;
			height = 24;
			rare = 3;
			value = 100000;
			accessory = true;
			break;
		case 577:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 140;
			width = 12;
			height = 12;
			break;
		case 578:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 19;
			useTime = 19;
			width = 50;
			height = 18;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 39;
			shootSpeed = 11f;
			noMelee = true;
			value = 200000;
			ranged = true;
			rare = 4;
			knockBack = 2.5f;
			break;
		case 617:
			useStyle = 5;
			autoReuse = true;
			useAnimation = 18;
			useTime = 18;
			width = 50;
			height = 18;
			shoot = 1;
			useAmmo = 1;
			useSound = 5;
			damage = 42;
			shootSpeed = 12f;
			noMelee = true;
			value = 250000;
			ranged = true;
			rare = 5;
			knockBack = 2.65f;
			break;
		case 579:
			useStyle = 5;
			useAnimation = 25;
			useTime = 7;
			shootSpeed = 36f;
			knockBack = 4.75f;
			width = 20;
			height = 12;
			damage = 35;
			pick = 200;
			axe = 22;
			hammer = 85;
			useSound = 23;
			shoot = 107;
			rare = 4;
			value = 220000;
			noMelee = true;
			noUseGraphic = true;
			melee = true;
			channel = true;
			break;
		case 580:
			mech = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 141;
			width = 12;
			height = 12;
			break;
		case 581:
			mech = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 142;
			width = 12;
			height = 12;
			break;
		case 582:
			mech = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 143;
			width = 12;
			height = 12;
			break;
		case 583:
			mech = true;
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 144;
			placeStyle = 0;
			width = 10;
			height = 12;
			value = 50;
			break;
		case 584:
			mech = true;
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 144;
			placeStyle = 1;
			width = 10;
			height = 12;
			value = 50;
			break;
		case 585:
			mech = true;
			noWet = true;
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			createTile = 144;
			placeStyle = 2;
			width = 10;
			height = 12;
			value = 50;
			break;
		case 586:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 145;
			width = 12;
			height = 12;
			break;
		case 587:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 29;
			width = 12;
			height = 12;
			break;
		case 588:
			width = 18;
			height = 12;
			headSlot = 44;
			value = 150000;
			vanity = true;
			break;
		case 589:
			width = 18;
			height = 18;
			bodySlot = 25;
			value = 150000;
			vanity = true;
			break;
		case 590:
			width = 18;
			height = 18;
			legSlot = 24;
			value = 150000;
			vanity = true;
			break;
		case 591:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 146;
			width = 12;
			height = 12;
			break;
		case 592:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 30;
			width = 12;
			height = 12;
			break;
		case 593:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 147;
			width = 12;
			height = 12;
			break;
		case 594:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 148;
			width = 12;
			height = 12;
			break;
		case 595:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createWall = 31;
			width = 12;
			height = 12;
			break;
		case 596:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 149;
			placeStyle = 0;
			width = 12;
			height = 12;
			value = 500;
			break;
		case 597:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 149;
			placeStyle = 1;
			width = 12;
			height = 12;
			value = 500;
			break;
		case 598:
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 250;
			consumable = true;
			createTile = 149;
			placeStyle = 2;
			width = 12;
			height = 12;
			value = 500;
			break;
		case 599:
			width = 12;
			height = 12;
			rare = 1;
			break;
		case 600:
			width = 12;
			height = 12;
			rare = 1;
			break;
		case 601:
			width = 12;
			height = 12;
			rare = 1;
			break;
		case 602:
			useStyle = 4;
			consumable = true;
			useAnimation = 45;
			useTime = 45;
			width = 28;
			height = 28;
			rare = 2;
			break;
		case 603:
			damage = 0;
			useStyle = 1;
			shoot = 111;
			width = 16;
			height = 30;
			useSound = 2;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			value = 0;
			buffType = 40;
			break;
		case 621:
			damage = 0;
			useStyle = 1;
			shoot = 115;
			width = 16;
			height = 30;
			useSound = 2;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			value = 0;
			buffType = 40;
			break;
		case 622:
			damage = 0;
			useStyle = 1;
			shoot = 116;
			width = 16;
			height = 30;
			useSound = 2;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			value = 0;
			buffType = 40;
			break;
		case 623:
			damage = 0;
			useStyle = 1;
			shoot = 117;
			width = 16;
			height = 30;
			useSound = 2;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			value = 0;
			buffType = 40;
			break;
		case 624:
			damage = 0;
			useStyle = 1;
			shoot = 118;
			width = 16;
			height = 30;
			useSound = 2;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			value = 0;
			buffType = 40;
			break;
		case 625:
			damage = 0;
			useStyle = 1;
			shoot = 119;
			width = 16;
			height = 30;
			useSound = 2;
			useAnimation = 20;
			useTime = 20;
			rare = 3;
			noMelee = true;
			value = 0;
			buffType = 40;
			break;
		case 604:
			width = 26;
			height = 18;
			defense = 26;
			headSlot = 45;
			rare = 5;
			value = 500000;
			break;
		case 605:
			width = 26;
			height = 22;
			defense = 14;
			headSlot = 46;
			rare = 5;
			value = 500000;
			break;
		case 606:
			width = 22;
			height = 20;
			defense = 10;
			headSlot = 47;
			rare = 5;
			value = 500000;
			break;
		case 607:
			width = 26;
			height = 18;
			defense = 20;
			bodySlot = 26;
			rare = 5;
			value = 1000000;
			break;
		case 608:
			width = 30;
			height = 18;
			defense = 18;
			bodySlot = 27;
			rare = 5;
			value = 1000000;
			break;
		case 609:
			width = 30;
			height = 28;
			defense = 15;
			bodySlot = 28;
			rare = 5;
			value = 1000000;
			break;
		case 610:
			width = 22;
			height = 18;
			defense = 14;
			legSlot = 25;
			rare = 5;
			value = 750000;
			break;
		case 611:
			width = 22;
			height = 18;
			defense = 13;
			legSlot = 26;
			rare = 5;
			value = 750000;
			break;
		case 612:
			width = 22;
			height = 18;
			defense = 15;
			legSlot = 27;
			rare = 5;
			value = 750000;
			break;
		default:
			active = 0;
			stack = 0;
			break;
		}
		if (!noMatCheck)
		{
			checkMat();
		}
	}

	public Color GetAlpha(Color newColor)
	{
		if (type == 75)
		{
			return new Color(255, 255, 255, newColor.A - alpha);
		}
		if ((type >= 119 && type <= 122) || (type >= 198 && type <= 203) || type == 217 || type == 218 || type == 219 || type == 220)
		{
			return new Color(255, 255, 255, 255);
		}
		if (type == 520 || type == 521 || type == 522 || type == 547 || type == 548 || type == 549 || type == 575)
		{
			return new Color(255, 255, 255, 50);
		}
		if (type == 58 || type == 184 || type == 501)
		{
			return new Color(200, 200, 200, 200);
		}
		int num = 256 - alpha;
		int r = newColor.R * num >> 8;
		int g = newColor.G * num >> 8;
		int b = newColor.B * num >> 8;
		int a = newColor.A - alpha;
		return new Color(r, g, b, a);
	}

	public Color GetAlphaInventory(Color newColor)
	{
		int num = 256 - alpha;
		int r = newColor.R * num >> 8;
		int g = newColor.G * num >> 8;
		int b = newColor.B * num >> 8;
		int a = newColor.A - alpha;
		return new Color(r, g, b, a);
	}

	public Color GetColor(Color newColor)
	{
		int r = color.R - (255 - newColor.R);
		int g = color.G - (255 - newColor.G);
		int b = color.B - (255 - newColor.B);
		int a = color.A - (255 - newColor.A);
		return new Color(r, g, b, a);
	}

	public static bool MechSpawn(int x, int y, int type)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < 196; i++)
		{
			if (Main.item[i].active == 0 || Main.item[i].type != type)
			{
				continue;
			}
			num++;
			Vector2 vector = new Vector2(x, y);
			float num4 = Main.item[i].position.X - vector.X;
			float num5 = Main.item[i].position.Y - vector.Y;
			float num6 = num4 * num4 + num5 * num5;
			if (num6 < 640000f)
			{
				num3++;
				if (num6 < 90000f)
				{
					num2++;
				}
			}
		}
		if (num2 >= 3 || num3 >= 6 || num >= 10)
		{
			return false;
		}
		return true;
	}

	public unsafe void UpdateItem(int i)
	{
		float num = 0.1f;
		float num2 = 7f;
		if (wet)
		{
			num2 = 5f;
			num = 0.08f;
		}
		Vector2 vector = velocity;
		vector.X *= 0.5f;
		vector.Y *= 0.5f;
		if (ownTime > 0 && --ownTime == 0)
		{
			ownIgnore = 8;
		}
		if (keepTime > 0)
		{
			keepTime--;
		}
		else if (isLocal() || (Main.netMode != 1 && (owner == 8 || Main.player[owner].active == 0)))
		{
			FindOwner(i);
		}
		if (!beingGrabbed)
		{
			velocity.X *= 0.95f;
			if (velocity.X < 0.1f && velocity.X > -0.1f)
			{
				velocity.X = 0f;
			}
			if (type == 520 || type == 521 || type == 547 || type == 548 || type == 549 || type == 575)
			{
				velocity.Y *= 0.95f;
				if (velocity.Y < 0.1f && velocity.Y > -0.1f)
				{
					velocity.Y = 0f;
				}
			}
			else
			{
				velocity.Y += num;
				if (velocity.Y > num2)
				{
					velocity.Y = num2;
				}
			}
			bool flag = Collision.LavaCollision(ref position, width, height);
			lavaWet |= flag;
			if (Collision.WetCollision(ref position, width, height))
			{
				if (!wet)
				{
					if (wetCount == 0)
					{
						wetCount = 20;
						if (!flag)
						{
							for (int j = 0; j < 8; j++)
							{
								Dust* ptr = Main.dust.NewDust((int)position.X - 6, (int)position.Y + (height >> 1) - 8, width + 12, 24, 33);
								if (ptr == null)
								{
									break;
								}
								ptr->velocity.Y -= 4f;
								ptr->velocity.X *= 2.5f;
								ptr->scale = 1.3f;
								ptr->alpha = 100;
								ptr->noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y);
						}
						else
						{
							for (int k = 0; k < 4; k++)
							{
								Dust* ptr2 = Main.dust.NewDust((int)position.X - 6, (int)position.Y + (height >> 1) - 8, width + 12, 24, 35);
								if (ptr2 == null)
								{
									break;
								}
								ptr2->velocity.Y -= 1.5f;
								ptr2->velocity.X *= 2.5f;
								ptr2->scale = 1.3f;
								ptr2->alpha = 100;
								ptr2->noGravity = true;
							}
							Main.PlaySound(19, (int)position.X, (int)position.Y);
						}
					}
					wet = true;
				}
			}
			else if (wet)
			{
				wet = false;
			}
			if (wetCount > 0)
			{
				wetCount--;
			}
			if (wet)
			{
				Vector2 vector2 = velocity;
				Collision.TileCollision(ref position, ref velocity, width, height);
				if (velocity.X != vector2.X)
				{
					vector.X = velocity.X;
				}
				if (velocity.Y != vector2.Y)
				{
					vector.Y = velocity.Y;
				}
			}
			else
			{
				lavaWet = false;
				Collision.TileCollision(ref position, ref velocity, width, height);
			}
			if (lavaWet)
			{
				if (type == 267)
				{
					if (Main.netMode != 1)
					{
						active = 0;
						type = 0;
						stack = 0;
						for (int l = 0; l < 196; l++)
						{
							if (Main.npc[l].type == 22 && Main.npc[l].active != 0)
							{
								NetMessage.SendNpcHurt(l, 8192, 10.0, -Main.npc[l].direction);
								Main.npc[l].StrikeNPC(8192, 10f, -Main.npc[l].direction);
								NPC.SpawnWOF(ref position);
								break;
							}
						}
						NetMessage.CreateMessage2(21, UI.main.myPlayer, i);
						NetMessage.SendMessage();
					}
				}
				else if (isLocal() && type != 312 && type != 318 && type != 173 && type != 174 && type != 175 && rare == 0)
				{
					active = 0;
					type = 0;
					stack = 0;
					NetMessage.CreateMessage2(21, UI.main.myPlayer, i);
					NetMessage.SendMessage();
				}
			}
			if (type == 520)
			{
				float num3 = (float)Main.rand.Next(90, 111) * 0.01f;
				num3 *= UI.essScale;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.5f * num3, 0.1f * num3, 0.25f * num3));
			}
			else if (type == 521)
			{
				float num4 = (float)Main.rand.Next(90, 111) * 0.01f;
				num4 *= UI.essScale;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.25f * num4, 0.1f * num4, 0.5f * num4));
			}
			else if (type == 547)
			{
				float num5 = (float)Main.rand.Next(90, 111) * 0.01f;
				num5 *= UI.essScale;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.5f * num5, 0.3f * num5, 0.05f * num5));
			}
			else if (type == 548)
			{
				float num6 = (float)Main.rand.Next(90, 111) * 0.01f;
				num6 *= UI.essScale;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.1f * num6, 0.1f * num6, 0.6f * num6));
			}
			else if (type == 575)
			{
				float num7 = (float)Main.rand.Next(90, 111) * 0.01f;
				num7 *= UI.essScale;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.1f * num7, 0.3f * num7, 0.5f * num7));
			}
			else if (type == 549)
			{
				float num8 = (float)Main.rand.Next(90, 111) * 0.01f;
				num8 *= UI.essScale;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.1f * num8, 0.5f * num8, 0.2f * num8));
			}
			else if (type == 58)
			{
				float num9 = (float)Main.rand.Next(90, 111) * 0.01f;
				num9 *= UI.essScale * 0.5f;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.5f * num9, 0.1f * num9, 0.1f * num9));
			}
			else if (type == 184)
			{
				float num10 = (float)Main.rand.Next(90, 111) * 0.01f;
				num10 *= UI.essScale * 0.5f;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.1f * num10, 0.1f * num10, 0.5f * num10));
			}
			else if (type == 522)
			{
				float num11 = (float)Main.rand.Next(90, 111) * 0.01f;
				num11 *= UI.essScale * 0.2f;
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.5f * num11, 1f * num11, 0.1f * num11));
			}
			else if (type == 75 && Main.gameTime.dayTime)
			{
				for (int m = 0; m < 8; m++)
				{
					if (null == Main.dust.NewDust((int)position.X, (int)position.Y, width, height, 15, velocity.X, velocity.Y, 150, default(Color), 1.2000000476837158))
					{
						break;
					}
				}
				for (int n = 0; n < 3; n++)
				{
					Gore.NewGore(position, velocity, Main.rand.Next(16, 18));
				}
				active = 0;
				type = 0;
				stack = 0;
				if (Main.netMode == 2)
				{
					NetMessage.CreateMessage2(21, UI.main.myPlayer, i);
					NetMessage.SendMessage();
				}
			}
		}
		else
		{
			beingGrabbed = false;
		}
		if (type == 501)
		{
			if (Main.rand.Next(6) == 0)
			{
				Dust* ptr3 = Main.dust.NewDust((int)position.X, (int)position.Y, width, height, 55, 0.0, 0.0, 200, color);
				if (ptr3 != null)
				{
					ptr3->velocity.X *= 0.3f;
					ptr3->velocity.Y *= 0.3f;
					ptr3->scale *= 0.5f;
				}
			}
		}
		else if (type == 8 || type == 105)
		{
			if (!wet)
			{
				Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(1f, 0.95f, 0.8f));
			}
		}
		else if (type == 523)
		{
			Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.85f, 1f, 0.7f));
		}
		else if (type >= 427 && type <= 432)
		{
			if (!wet)
			{
				Lighting.addLight(rgb: type switch
				{
					427 => new Vector3(0.1f, 0.2f, 1.1f), 
					428 => new Vector3(1f, 0.1f, 0.1f), 
					429 => new Vector3(0f, 1f, 0.1f), 
					430 => new Vector3(0.9f, 0f, 0.9f), 
					431 => new Vector3(1.3f, 1.3f, 1.3f), 
					_ => new Vector3(0.9f, 0.9f, 0f), 
				}, i: (int)position.X + (width >> 1) >> 4, j: (int)position.Y + (height >> 1) >> 4);
			}
		}
		else if (type == 41)
		{
			if (!wet)
			{
				Lighting.addLight((int)position.X + width >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(1f, 0.75f, 0.55f));
			}
		}
		else if (type == 616)
		{
			Lighting.addLight((int)position.X + width >> 4, (int)position.Y + (height >> 1) >> 4, wet ? new Vector3(0.25f, 0.5f, 0.5f) : new Vector3(0.5f, 1f, 1f));
		}
		else if (type == 282)
		{
			Lighting.addLight((int)position.X + width >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.7f, 1f, 0.8f));
		}
		else if (type == 286)
		{
			Lighting.addLight((int)position.X + width >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.7f, 0.8f, 1f));
		}
		else if (type == 331)
		{
			Lighting.addLight((int)position.X + width >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.55f, 0.75f, 0.6f));
		}
		else if (type == 183)
		{
			Lighting.addLight((int)position.X + width >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.15f, 0.45f, 0.9f));
		}
		else if (type == 75)
		{
			Lighting.addLight((int)position.X + width >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.8f, 0.7f, 0.1f));
			if (Main.rand.Next(32) == 0)
			{
				Main.dust.NewDust((int)position.X, (int)position.Y, width, height, 58, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.2000000476837158);
			}
			else if (Main.rand.Next(64) == 0)
			{
				Gore.NewGore(position, new Vector2(velocity.X * 0.2f, velocity.Y * 0.2f), Main.rand.Next(16, 18));
			}
		}
		spawnTime++;
		if (Main.netMode == 2 && !isLocal() && ++release >= 300)
		{
			release = 0;
			FindOwner(i);
		}
		if (wet)
		{
			position.X += vector.X;
			position.Y += vector.Y;
		}
		else
		{
			position.X += velocity.X;
			position.Y += velocity.Y;
		}
		if (noGrabDelay > 0)
		{
			noGrabDelay--;
		}
	}

	public unsafe static int NewItem(int X, int Y, int Width, int Height, int Type, int Stack = 1, bool noBroadcast = false, int pfix = 0)
	{
		int num = 200;
		if (Main.netMode != 1)
		{
			uint num2 = lastItemIndex;
			uint num3 = Main.item[num2].spawnTime;
			uint num4 = num2;
			for (int num5 = 199; num5 >= 0; num5--)
			{
				if (Main.item[num2].active == 0)
				{
					num = (int)num2;
					break;
				}
				if (++num2 == 200)
				{
					num2 = 0u;
				}
				uint num6 = Main.item[num2].spawnTime;
				if (num6 > num3)
				{
					num3 = num6;
					num4 = num2;
				}
			}
			if (num == 200)
			{
				num = (int)num4;
			}
			if (++num2 == 200)
			{
				num2 = 0u;
			}
			lastItemIndex = num2;
		}
		fixed (Item* ptr = &Main.item[num])
		{
			ptr->SetDefaults(Type, Stack);
			ptr->Prefix(pfix);
			ptr->position.X = X + (Width - ptr->width >> 1);
			ptr->position.Y = Y + (Height - ptr->height >> 1);
			ptr->wet = Collision.WetCollision(ref ptr->position, ptr->width, ptr->height);
			ptr->velocity.X = (float)Main.rand.Next(-30, 31) * 0.1f;
			if (Type == 520 || Type == 521)
			{
				ptr->velocity.Y = (float)Main.rand.Next(-30, 31) * 0.1f;
			}
			else
			{
				ptr->velocity.Y = (float)Main.rand.Next(-40, -15) * 0.1f;
			}
			ptr->spawnTime = 0u;
			if (!noBroadcast && Main.netMode != 1)
			{
				NetMessage.CreateMessage2(21, UI.main.myPlayer, num);
				NetMessage.SendMessage();
				ptr->FindOwner(num);
			}
		}
		return num;
	}

	public unsafe void FindOwner(int whoAmI)
	{
		if (keepTime > 0)
		{
			return;
		}
		int num = 8;
		int num2 = 1920;
		int num3 = (int)position.X - (width >> 1);
		int num4 = (int)position.Y - height;
		fixed (Item* pNewItem = &this)
		{
			for (int i = 0; i < 8; i++)
			{
				if (ownIgnore != i && Main.player[i].active != 0 && Main.player[i].ItemSpace(pNewItem))
				{
					int num5 = Math.Abs(Main.player[i].aabb.X + 10 - num3) + Math.Abs(Main.player[i].aabb.Y + 21 - num4);
					if (num5 < num2)
					{
						num2 = num5;
						num = i;
					}
				}
			}
		}
		int num6 = owner;
		if (num != num6)
		{
			bool flag = isLocal();
			owner = (byte)num;
			if (((flag && Main.netMode >= 1) || (num6 == 8 && Main.netMode == 2) || Main.player[num6].active == 0) && active != 0)
			{
				NetMessage.CreateMessage1(22, whoAmI);
				NetMessage.SendMessage();
			}
		}
	}

	public bool IsNotTheSameAs(ref Item compareItem)
	{
		if (netID == compareItem.netID && stack == compareItem.stack)
		{
			return prefix != compareItem.prefix;
		}
		return true;
	}

	public bool CanBePlacedInAmmoSlot()
	{
		if (ammo <= 0)
		{
			return type == 530;
		}
		return true;
	}

	public bool CanBeAutoPlacedInEmptyAmmoSlot()
	{
		if (type != 169 && type != 75 && type != 23 && type != 370)
		{
			return type != 408;
		}
		return false;
	}

	public bool CanBePlacedInCoinSlot()
	{
		if (type >= 71)
		{
			return type <= 74;
		}
		return false;
	}
}
