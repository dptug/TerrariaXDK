using Microsoft.Xna.Framework;
using System;
using Terraria.Achievements;

namespace Terraria
{
	public sealed class NPC
	{
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
			NUM_TYPES
		}

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

		public static string[] chrName = new string[125];

		public static byte[] npcFrameCount = new byte[168]
		{
			1,
			2,
			2,
			3,
			6,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			16,
			14,
			16,
			14,
			15,
			16,
			2,
			10,
			1,
			16,
			16,
			16,
			3,
			1,
			15,
			3,
			1,
			3,
			1,
			1,
			16,
			16,
			1,
			1,
			1,
			3,
			3,
			15,
			3,
			7,
			7,
			4,
			5,
			5,
			5,
			3,
			3,
			16,
			6,
			3,
			6,
			6,
			2,
			5,
			3,
			2,
			7,
			7,
			4,
			2,
			8,
			1,
			5,
			1,
			2,
			4,
			16,
			5,
			4,
			4,
			15,
			15,
			15,
			15,
			2,
			4,
			6,
			6,
			18,
			16,
			1,
			1,
			1,
			1,
			1,
			1,
			4,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			5,
			6,
			7,
			16,
			1,
			1,
			16,
			16,
			12,
			20,
			21,
			1,
			2,
			2,
			3,
			6,
			1,
			1,
			1,
			15,
			4,
			11,
			1,
			14,
			6,
			6,
			3,
			1,
			2,
			2,
			1,
			3,
			4,
			1,
			2,
			1,
			4,
			2,
			1,
			15,
			3,
			16,
			4,
			5,
			7,
			3,
			5,
			4,
			15,
			2,
			6,
			15,
			11,
			15,
			15,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			6,
			2
		};

		public static int wof = -1;

		public static int wofT;

		public static int wofB;

		public static int wofF = 0;

		private static bool noSpawnCycle = false;

		public static short checkForSpawnsTimer = 0;

		public Vector2[] oldPos = new Vector2[10];

		public short netSpam;

		public short netSkip;

		public bool netAlways;

		public int realLife = -1;

		public float npcSlots = 1f;

		public bool wet;

		public byte wetCount;

		public bool lavaWet;

		public Buff[] buff = new Buff[5];

		public bool[] buffImmune = new bool[41];

		public bool poisoned;

		public bool confused;

		public int lifeRegenCount;

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

		public byte[] immune = new byte[9];

		public sbyte direction = 1;

		public sbyte directionY = 1;

		public byte aiAction;

		public byte aiStyle;

		public byte target = 8;

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

		public float scale = 1f;

		public float knockBackResist = 1f;

		public byte alpha;

		public sbyte spriteDirection = -1;

		public sbyte oldDirection;

		public sbyte oldDirectionY;

		public short oldTarget;

		public short whoAmI;

		public float rotation;

		public float value;

		public short netID;

		public short homeTileX = -1;

		public short homeTileY = -1;

		public short oldHomeTileX = -1;

		public short oldHomeTileY = -1;

		public short doorX;

		public short doorY;

		public short friendlyRegen;

		public string name;

		public string displayName;

		public static void clrNames()
		{
			for (int i = 0; i < 125; i++)
			{
				chrName[i] = null;
			}
		}

		public bool hasName()
		{
			if (type < 125)
			{
				return chrName[type] != null;
			}
			return false;
		}

		public string getName()
		{
			return chrName[type];
		}

		public static void setNames()
		{
			if (chrName[18] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(23))
				{
				case 0:
					text = "Molly";
					break;
				case 1:
					text = "Amy";
					break;
				case 2:
					text = "Claire";
					break;
				case 3:
					text = "Emily";
					break;
				case 4:
					text = "Katie";
					break;
				case 5:
					text = "Madeline";
					break;
				case 6:
					text = "Katelyn";
					break;
				case 7:
					text = "Emma";
					break;
				case 8:
					text = "Abigail";
					break;
				case 9:
					text = "Carly";
					break;
				case 10:
					text = "Jenna";
					break;
				case 11:
					text = "Heather";
					break;
				case 12:
					text = "Katherine";
					break;
				case 13:
					text = "Caitlin";
					break;
				case 14:
					text = "Kaitlin";
					break;
				case 15:
					text = "Holly";
					break;
				case 16:
					text = "Kaitlyn";
					break;
				case 17:
					text = "Hannah";
					break;
				case 18:
					text = "Kathryn";
					break;
				case 19:
					text = "Lorraine";
					break;
				case 20:
					text = "Helen";
					break;
				case 21:
					text = "Kayla";
					break;
				default:
					text = "Allison";
					break;
				}
				chrName[18] = text;
			}
			if (chrName[124] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(24))
				{
				case 0:
					text = "Shayna";
					break;
				case 1:
					text = "Korrie";
					break;
				case 2:
					text = "Ginger";
					break;
				case 3:
					text = "Brooke";
					break;
				case 4:
					text = "Jenny";
					break;
				case 5:
					text = "Autumn";
					break;
				case 6:
					text = "Nancy";
					break;
				case 7:
					text = "Ella";
					break;
				case 8:
					text = "Kayla";
					break;
				case 9:
					text = "Beth";
					break;
				case 10:
					text = "Sophia";
					break;
				case 11:
					text = "Marshanna";
					break;
				case 12:
					text = "Lauren";
					break;
				case 13:
					text = "Trisha";
					break;
				case 14:
					text = "Shirlena";
					break;
				case 15:
					text = "Sheena";
					break;
				case 16:
					text = "Ellen";
					break;
				case 17:
					text = "Amy";
					break;
				case 18:
					text = "Dawn";
					break;
				case 19:
					text = "Susana";
					break;
				case 20:
					text = "Meredith";
					break;
				case 21:
					text = "Selene";
					break;
				case 22:
					text = "Terra";
					break;
				default:
					text = "Sally";
					break;
				}
				chrName[124] = text;
			}
			if (chrName[19] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(23))
				{
				case 0:
					text = "DeShawn";
					break;
				case 1:
					text = "DeAndre";
					break;
				case 2:
					text = "Marquis";
					break;
				case 3:
					text = "Darnell";
					break;
				case 4:
					text = "Terrell";
					break;
				case 5:
					text = "Malik";
					break;
				case 6:
					text = "Trevon";
					break;
				case 7:
					text = "Tyrone";
					break;
				case 8:
					text = "Willie";
					break;
				case 9:
					text = "Dominique";
					break;
				case 10:
					text = "Demetrius";
					break;
				case 11:
					text = "Reginald";
					break;
				case 12:
					text = "Jamal";
					break;
				case 13:
					text = "Maurice";
					break;
				case 14:
					text = "Jalen";
					break;
				case 15:
					text = "Darius";
					break;
				case 16:
					text = "Xavier";
					break;
				case 17:
					text = "Terrance";
					break;
				case 18:
					text = "Andre";
					break;
				case 19:
					text = "Dante";
					break;
				case 20:
					text = "Brimst";
					break;
				case 21:
					text = "Bronson";
					break;
				default:
					text = "Darryl";
					break;
				}
				chrName[19] = text;
			}
			if (chrName[22] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(35))
				{
				case 0:
					text = "Jake";
					break;
				case 1:
					text = "Connor";
					break;
				case 2:
					text = "Tanner";
					break;
				case 3:
					text = "Wyatt";
					break;
				case 4:
					text = "Cody";
					break;
				case 5:
					text = "Dustin";
					break;
				case 6:
					text = "Luke";
					break;
				case 7:
					text = "Jack";
					break;
				case 8:
					text = "Scott";
					break;
				case 9:
					text = "Logan";
					break;
				case 10:
					text = "Cole";
					break;
				case 11:
					text = "Lucas";
					break;
				case 12:
					text = "Bradley";
					break;
				case 13:
					text = "Jacob";
					break;
				case 14:
					text = "Garrett";
					break;
				case 15:
					text = "Dylan";
					break;
				case 16:
					text = "Maxwell";
					break;
				case 17:
					text = "Steve";
					break;
				case 18:
					text = "Brett";
					break;
				case 19:
					text = "Andrew";
					break;
				case 20:
					text = "Harley";
					break;
				case 21:
					text = "Kyle";
					break;
				case 22:
					text = "Jake";
					break;
				case 23:
					text = "Ryan";
					break;
				case 24:
					text = "Jeffrey";
					break;
				case 25:
					text = "Seth";
					break;
				case 26:
					text = "Marty";
					break;
				case 27:
					text = "Brandon";
					break;
				case 28:
					text = "Zach";
					break;
				case 29:
					text = "Jeff";
					break;
				case 30:
					text = "Daniel";
					break;
				case 31:
					text = "Trent";
					break;
				case 32:
					text = "Kevin";
					break;
				case 33:
					text = "Brian";
					break;
				default:
					text = "Colin";
					break;
				}
				chrName[22] = text;
			}
			if (chrName[20] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(22))
				{
				case 0:
					text = "Alalia";
					break;
				case 1:
					text = "Alalia";
					break;
				case 2:
					text = "Alura";
					break;
				case 3:
					text = "Ariella";
					break;
				case 4:
					text = "Caelia";
					break;
				case 5:
					text = "Calista";
					break;
				case 6:
					text = "Chryseis";
					break;
				case 7:
					text = "Emerenta";
					break;
				case 8:
					text = "Elysia";
					break;
				case 9:
					text = "Evvie";
					break;
				case 10:
					text = "Faye";
					break;
				case 11:
					text = "Felicitae";
					break;
				case 12:
					text = "Lunette";
					break;
				case 13:
					text = "Nata";
					break;
				case 14:
					text = "Nissa";
					break;
				case 15:
					text = "Tatiana";
					break;
				case 16:
					text = "Rosalva";
					break;
				case 17:
					text = "Shea";
					break;
				case 18:
					text = "Tania";
					break;
				case 19:
					text = "Isis";
					break;
				case 20:
					text = "Celestia";
					break;
				default:
					text = "Xylia";
					break;
				}
				chrName[20] = text;
			}
			if (chrName[38] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(22))
				{
				case 0:
					text = "Dolbere";
					break;
				case 1:
					text = "Bazdin";
					break;
				case 2:
					text = "Durim";
					break;
				case 3:
					text = "Tordak";
					break;
				case 4:
					text = "Garval";
					break;
				case 5:
					text = "Morthal";
					break;
				case 6:
					text = "Oten";
					break;
				case 7:
					text = "Dolgen";
					break;
				case 8:
					text = "Gimli";
					break;
				case 9:
					text = "Gimut";
					break;
				case 10:
					text = "Duerthen";
					break;
				case 11:
					text = "Beldin";
					break;
				case 12:
					text = "Jarut";
					break;
				case 13:
					text = "Ovbere";
					break;
				case 14:
					text = "Norkas";
					break;
				case 15:
					text = "Dolgrim";
					break;
				case 16:
					text = "Boften";
					break;
				case 17:
					text = "Norsun";
					break;
				case 18:
					text = "Dias";
					break;
				case 19:
					text = "Fikod";
					break;
				case 20:
					text = "Urist";
					break;
				default:
					text = "Darur";
					break;
				}
				chrName[38] = text;
			}
			if (chrName[108] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(21))
				{
				case 0:
					text = "Dalamar";
					break;
				case 1:
					text = "Dulais";
					break;
				case 2:
					text = "Elric";
					break;
				case 3:
					text = "Arddun";
					break;
				case 4:
					text = "Maelor";
					break;
				case 5:
					text = "Leomund";
					break;
				case 6:
					text = "Hirael";
					break;
				case 7:
					text = "Gwentor";
					break;
				case 8:
					text = "Greum";
					break;
				case 9:
					text = "Gearroid";
					break;
				case 10:
					text = "Fizban";
					break;
				case 11:
					text = "Ningauble";
					break;
				case 12:
					text = "Seonag";
					break;
				case 13:
					text = "Sargon";
					break;
				case 14:
					text = "Merlyn";
					break;
				case 15:
					text = "Magius";
					break;
				case 16:
					text = "Berwyn";
					break;
				case 17:
					text = "Arwyn";
					break;
				case 18:
					text = "Alasdair";
					break;
				case 19:
					text = "Tagar";
					break;
				default:
					text = "Xanadu";
					break;
				}
				chrName[108] = text;
			}
			if (chrName[17] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(23))
				{
				case 0:
					text = "Alfred";
					break;
				case 1:
					text = "Barney";
					break;
				case 2:
					text = "Calvin";
					break;
				case 3:
					text = "Edmund";
					break;
				case 4:
					text = "Edwin";
					break;
				case 5:
					text = "Eugene";
					break;
				case 6:
					text = "Frank";
					break;
				case 7:
					text = "Frederick";
					break;
				case 8:
					text = "Gilbert";
					break;
				case 9:
					text = "Gus";
					break;
				case 10:
					text = "Wilbur";
					break;
				case 11:
					text = "Seymour";
					break;
				case 12:
					text = "Louis";
					break;
				case 13:
					text = "Humphrey";
					break;
				case 14:
					text = "Harold";
					break;
				case 15:
					text = "Milton";
					break;
				case 16:
					text = "Mortimer";
					break;
				case 17:
					text = "Howard";
					break;
				case 18:
					text = "Walter";
					break;
				case 19:
					text = "Finn";
					break;
				case 20:
					text = "Isacc";
					break;
				case 21:
					text = "Joseph";
					break;
				default:
					text = "Ralph";
					break;
				}
				chrName[17] = text;
			}
			if (chrName[54] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(24))
				{
				case 0:
					text = "Sebastian";
					break;
				case 1:
					text = "Rupert";
					break;
				case 2:
					text = "Clive";
					break;
				case 3:
					text = "Nigel";
					break;
				case 4:
					text = "Mervyn";
					break;
				case 5:
					text = "Cedric";
					break;
				case 6:
					text = "Pip";
					break;
				case 7:
					text = "Cyril";
					break;
				case 8:
					text = "Fitz";
					break;
				case 9:
					text = "Lloyd";
					break;
				case 10:
					text = "Arthur";
					break;
				case 11:
					text = "Rodney";
					break;
				case 12:
					text = "Graham";
					break;
				case 13:
					text = "Edward";
					break;
				case 14:
					text = "Alfred";
					break;
				case 15:
					text = "Edmund";
					break;
				case 16:
					text = "Henry";
					break;
				case 17:
					text = "Herald";
					break;
				case 18:
					text = "Roland";
					break;
				case 19:
					text = "Lincoln";
					break;
				case 20:
					text = "Lloyd";
					break;
				case 21:
					text = "Edgar";
					break;
				case 22:
					text = "Eustace";
					break;
				default:
					text = "Rodrick";
					break;
				}
				chrName[54] = text;
			}
			if (chrName[107] == null)
			{
				string text;
				switch (WorldGen.genRand.Next(25))
				{
				case 0:
					text = "Grodax";
					break;
				case 1:
					text = "Sarx";
					break;
				case 2:
					text = "Xon";
					break;
				case 3:
					text = "Mrunok";
					break;
				case 4:
					text = "Nuxatk";
					break;
				case 5:
					text = "Tgerd";
					break;
				case 6:
					text = "Darz";
					break;
				case 7:
					text = "Smador";
					break;
				case 8:
					text = "Stazen";
					break;
				case 9:
					text = "Mobart";
					break;
				case 10:
					text = "Knogs";
					break;
				case 11:
					text = "Tkanus";
					break;
				case 12:
					text = "Negurk";
					break;
				case 13:
					text = "Nort";
					break;
				case 14:
					text = "Durnok";
					break;
				case 15:
					text = "Trogem";
					break;
				case 16:
					text = "Stezom";
					break;
				case 17:
					text = "Gnudar";
					break;
				case 18:
					text = "Ragz";
					break;
				case 19:
					text = "Fahd";
					break;
				case 20:
					text = "Xanos";
					break;
				case 21:
					text = "Arback";
					break;
				case 22:
					text = "Fjell";
					break;
				case 23:
					text = "Dalek";
					break;
				default:
					text = "Knub";
					break;
				}
				chrName[107] = text;
			}
		}

		public void netDefaults(int type)
		{
			if (type < 0)
			{
				switch (type)
				{
				case -1:
					SetDefaults("Slimeling");
					break;
				case -2:
					SetDefaults("Slimer2");
					break;
				case -3:
					SetDefaults("Green Slime");
					break;
				case -4:
					SetDefaults("Pinky");
					break;
				case -5:
					SetDefaults("Baby Slime");
					break;
				case -6:
					SetDefaults("Black Slime");
					break;
				case -7:
					SetDefaults("Purple Slime");
					break;
				case -8:
					SetDefaults("Red Slime");
					break;
				case -9:
					SetDefaults("Yellow Slime");
					break;
				case -10:
					SetDefaults("Jungle Slime");
					break;
				case -11:
					SetDefaults("Little Eater");
					break;
				case -12:
					SetDefaults("Big Eater");
					break;
				case -13:
					SetDefaults("Short Bones");
					break;
				case -14:
					SetDefaults("Big Boned");
					break;
				case -15:
					SetDefaults("Heavy Skeleton");
					break;
				case -16:
					SetDefaults("Little Stinger");
					break;
				case -17:
					SetDefaults("Big Stinger");
					break;
				case -18:
					SetDefaults("Slimeling2");
					break;
				}
			}
			else
			{
				SetDefaults(type);
			}
		}

		public void SetDefaults(string Name)
		{
			switch (Name)
			{
			case "Slimeling":
				SetDefaults(81, 0.60000002384185791);
				name = Name;
				damage = 45;
				defense = 10;
				life = 90;
				knockBackResist = 1.2f;
				value = 100f;
				netID = -1;
				break;
			case "Slimeling2":
				SetDefaults(150, 0.60000002384185791);
				name = Name;
				damage = 45;
				defense = 10;
				life = 105;
				knockBackResist = 1.2f;
				value = 100f;
				netID = -18;
				break;
			case "Slimer2":
				SetDefaults(81, 0.89999997615814209);
				name = Name;
				damage = 45;
				defense = 20;
				life = 90;
				knockBackResist = 1.2f;
				value = 100f;
				netID = -2;
				break;
			case "Green Slime":
				SetDefaults(1, 0.89999997615814209);
				name = Name;
				damage = 6;
				defense = 0;
				life = 14;
				knockBackResist = 1.2f;
				color = new Color(0, 220, 40, 100);
				value = 3f;
				netID = -3;
				break;
			case "Pinky":
				SetDefaults(1, 0.60000002384185791);
				name = Name;
				damage = 5;
				defense = 5;
				life = 150;
				knockBackResist = 1.4f;
				color = new Color(250, 30, 90, 90);
				value = 10000f;
				netID = -4;
				break;
			case "Baby Slime":
				SetDefaults(1, 0.89999997615814209);
				name = Name;
				damage = 13;
				defense = 4;
				life = 30;
				knockBackResist = 0.95f;
				alpha = 120;
				color = new Color(0, 0, 0, 50);
				value = 10f;
				netID = -5;
				break;
			case "Black Slime":
				SetDefaults(1);
				name = Name;
				damage = 15;
				defense = 4;
				life = 45;
				color = new Color(0, 0, 0, 50);
				value = 20f;
				netID = -6;
				break;
			case "Purple Slime":
				SetDefaults(1, 1.2000000476837158);
				name = Name;
				damage = 12;
				defense = 6;
				life = 40;
				knockBackResist = 0.9f;
				color = new Color(200, 0, 255, 150);
				value = 10f;
				netID = -7;
				break;
			case "Red Slime":
				SetDefaults(1);
				name = Name;
				damage = 12;
				defense = 4;
				life = 35;
				color = new Color(255, 30, 0, 100);
				value = 8f;
				netID = -8;
				break;
			case "Yellow Slime":
				SetDefaults(1, 1.2000000476837158);
				name = Name;
				damage = 15;
				defense = 7;
				life = 45;
				color = new Color(255, 255, 0, 100);
				value = 10f;
				netID = -9;
				break;
			case "Jungle Slime":
				SetDefaults(1, 1.1000000238418579);
				name = Name;
				damage = 18;
				defense = 6;
				life = 60;
				color = new Color(143, 215, 93, 100);
				value = 500f;
				netID = -10;
				break;
			case "Little Eater":
				SetDefaults(6, 0.85000002384185791);
				name = Name;
				defense = (int)((float)defense * scale);
				damage = (int)((float)damage * scale);
				life = (int)((float)life * scale);
				value = (int)(value * scale);
				npcSlots *= scale;
				knockBackResist *= 2f - scale;
				netID = -11;
				break;
			case "Big Eater":
				SetDefaults(6, 1.1499999761581421);
				name = Name;
				defense = (int)((float)defense * scale);
				damage = (int)((float)damage * scale);
				life = (int)((float)life * scale);
				value = (int)(value * scale);
				npcSlots *= scale;
				knockBackResist *= 2f - scale;
				netID = -12;
				break;
			case "Short Bones":
				SetDefaults(31, 0.89999997615814209);
				name = Name;
				defense = (int)((float)defense * scale);
				damage = (int)((float)damage * scale);
				life = (int)((float)life * scale);
				value = (int)(value * scale);
				netID = -13;
				break;
			case "Big Boned":
				SetDefaults(31, 1.1499999761581421);
				name = Name;
				defense = (int)((float)defense * scale);
				damage = (int)((double)((float)damage * scale) * 1.1);
				life = (int)((double)((float)life * scale) * 1.1);
				value = (int)(value * scale);
				npcSlots = 2f;
				knockBackResist *= 2f - scale;
				netID = -14;
				break;
			case "Heavy Skeleton":
				SetDefaults(77, 1.1499999761581421);
				name = Name;
				defense = (int)((float)defense * scale);
				damage = (int)((double)((float)damage * scale) * 1.1);
				life = 400;
				value = (int)(value * scale);
				npcSlots = 2f;
				knockBackResist *= 2f - scale;
				height = 44;
				netID = -15;
				break;
			case "Little Stinger":
				SetDefaults(42, 0.85000002384185791);
				name = Name;
				defense = (int)((float)defense * scale);
				damage = (int)((float)damage * scale);
				life = (int)((float)life * scale);
				value = (int)(value * scale);
				npcSlots *= scale;
				knockBackResist *= 2f - scale;
				netID = -16;
				break;
			case "Big Stinger":
				SetDefaults(42, 1.2000000476837158);
				name = Name;
				defense = (int)((float)defense * scale);
				damage = (int)((float)damage * scale);
				life = (int)((float)life * scale);
				value = (int)(value * scale);
				npcSlots *= scale;
				knockBackResist *= 2f - scale;
				netID = -17;
				break;
			}
			displayName = Lang.npcName(netID);
			lifeMax = life;
			healthBarLife = life;
			defDamage = damage;
			defDefense = (short)defense;
		}

		public bool canTalk()
		{
			if (!townNPC && type != 105 && type != 106)
			{
				return type == 123;
			}
			return true;
		}

		public static bool MechSpawn(int x, int y, int type)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 196; i++)
			{
				if (Main.npc[i].active != 0 && Main.npc[i].type == type)
				{
					num++;
					Vector2 vector = new Vector2(x, y);
					float num4 = Main.npc[i].position.X - vector.X;
					float num5 = Main.npc[i].position.Y - vector.Y;
					float num6 = num4 * num4 + num5 * num5;
					if (num6 < 40000f)
					{
						num2++;
					}
					if (num6 < 360000f)
					{
						num3++;
					}
				}
			}
			if (num2 >= 3 || num3 >= 6 || num >= 10)
			{
				return false;
			}
			return true;
		}

		public int getHeadTextureId()
		{
			switch (type)
			{
			case 17:
				return 2;
			case 18:
				return 3;
			case 19:
				return 6;
			case 20:
				return 5;
			case 22:
				return 1;
			case 38:
				return 4;
			case 54:
				return 7;
			case 107:
				return 9;
			case 108:
				return 10;
			case 124:
				return 8;
			case 142:
				return 11;
			default:
				return -1;
			}
		}

		public void SetDefaults(int Type, double scaleOverride = -1.0)
		{
			type = (byte)Type;
			netID = (short)Type;
			netAlways = false;
			netSpam = 0;
			drawMyName = 0;
			for (int i = 0; i < oldPos.Length; i++)
			{
				oldPos[i].X = 0f;
				oldPos[i].Y = 0f;
			}
			for (int j = 0; j < 5; j++)
			{
				buff[j].Time = 0;
				buff[j].Type = 0;
			}
			for (int k = 0; k < 41; k++)
			{
				buffImmune[k] = false;
			}
			buffImmune[31] = true;
			netSkip = -2;
			realLife = -1;
			lifeRegenCount = 0;
			poisoned = false;
			confused = false;
			justHit = false;
			dontTakeDamage = false;
			npcSlots = 1f;
			lavaImmune = false;
			lavaWet = false;
			wetCount = 0;
			wet = false;
			townNPC = false;
			homeless = false;
			homeTileX = -1;
			homeTileY = -1;
			friendly = false;
			behindTiles = false;
			boss = false;
			noTileCollide = false;
			rotation = 0f;
			active = 1;
			alpha = 0;
			color = default(Color);
			collideX = false;
			collideY = false;
			direction = 0;
			oldDirection = 0;
			frameCounter = 0f;
			netUpdate = true;
			netUpdate2 = false;
			knockBackResist = 1f;
			name = "";
			noGravity = false;
			scale = 1f;
			soundHit = 0;
			soundKilled = 0;
			spriteDirection = -1;
			target = 8;
			oldTarget = target;
			targetRect = default(Rectangle);
			timeLeft = 750;
			value = 0f;
			ai0 = 0f;
			ai1 = 0f;
			ai2 = 0f;
			ai3 = 0f;
			localAI0 = 0;
			localAI1 = 0;
			localAI2 = 0;
			localAI3 = 0;
			if (type == 1)
			{
				name = "Blue Slime";
				width = 24;
				height = 18;
				aiStyle = 1;
				damage = 7;
				defense = 2;
				lifeMax = 25;
				soundHit = 1;
				soundKilled = 1;
				alpha = 175;
				color = new Color(0, 80, 255, 100);
				value = 25f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 2)
			{
				name = "Demon Eye";
				width = 30;
				height = 32;
				aiStyle = 2;
				damage = 18;
				defense = 2;
				lifeMax = 60;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 75f;
				buffImmune[31] = false;
			}
			else if (type == 3)
			{
				name = "Zombie";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 14;
				defense = 6;
				lifeMax = 45;
				soundHit = 1;
				soundKilled = 2;
				knockBackResist = 0.5f;
				value = 60f;
				buffImmune[31] = false;
			}
			else if (type == 4)
			{
				name = "Eye of Cthulhu";
				width = 100;
				height = 110;
				aiStyle = 4;
				damage = 15;
				defense = 12;
				lifeMax = 2800;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0f;
				noGravity = true;
				noTileCollide = true;
				timeLeft = 22500;
				boss = true;
				value = 30000f;
				npcSlots = 5f;
			}
			else if (type == 166)
			{
				name = "Ocram";
				width = 100;
				height = 110;
				aiStyle = 39;
				damage = 65;
				defense = 20;
				lifeMax = 35000;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0f;
				noGravity = true;
				noTileCollide = true;
				timeLeft = 22500;
				boss = true;
				value = 100000f;
				npcSlots = 5f;
				buffImmune[20] = true;
			}
			else if (type == 5)
			{
				name = "Servant of Cthulhu";
				width = 20;
				height = 20;
				aiStyle = 5;
				damage = 13;
				defense = 0;
				lifeMax = 10;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
			}
			else if (type == 167)
			{
				name = "Servant of Ocram";
				width = 20;
				height = 20;
				aiStyle = 5;
				damage = 35;
				defense = 5;
				lifeMax = 130;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
			}
			else if (type == 6)
			{
				npcSlots = 1f;
				name = "Eater of Souls";
				width = 30;
				height = 30;
				aiStyle = 5;
				damage = 22;
				defense = 8;
				lifeMax = 40;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				knockBackResist = 0.5f;
				value = 90f;
			}
			else if (type == 7)
			{
				npcSlots = 3.5f;
				name = "Devourer Head";
				width = 22;
				height = 22;
				aiStyle = 6;
				damage = 31;
				defense = 2;
				lifeMax = 100;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 140f;
				netAlways = true;
			}
			else if (type == 8)
			{
				name = "Devourer Body";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 16;
				defense = 6;
				lifeMax = 100;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 140f;
			}
			else if (type == 9)
			{
				name = "Devourer Tail";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 13;
				defense = 10;
				lifeMax = 100;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 140f;
			}
			else if (type == 10)
			{
				name = "Giant Worm Head";
				width = 14;
				height = 14;
				aiStyle = 6;
				netAlways = true;
				damage = 8;
				defense = 0;
				lifeMax = 30;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 40f;
			}
			else if (type == 11)
			{
				name = "Giant Worm Body";
				width = 14;
				height = 14;
				aiStyle = 6;
				netAlways = true;
				damage = 4;
				defense = 4;
				lifeMax = 30;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 40f;
			}
			else if (type == 12)
			{
				name = "Giant Worm Tail";
				width = 14;
				height = 14;
				aiStyle = 6;
				netAlways = true;
				damage = 4;
				defense = 6;
				lifeMax = 30;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 40f;
			}
			else if (type == 13)
			{
				npcSlots = 5f;
				name = "Eater of Worlds Head";
				width = 38;
				height = 38;
				aiStyle = 6;
				netAlways = true;
				damage = 22;
				defense = 2;
				lifeMax = 65;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 300f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 14)
			{
				name = "Eater of Worlds Body";
				width = 38;
				height = 38;
				aiStyle = 6;
				netAlways = true;
				damage = 13;
				defense = 4;
				lifeMax = 150;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 300f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 15)
			{
				name = "Eater of Worlds Tail";
				width = 38;
				height = 38;
				aiStyle = 6;
				netAlways = true;
				damage = 11;
				defense = 8;
				lifeMax = 220;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 300f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 16)
			{
				npcSlots = 2f;
				name = "Mother Slime";
				width = 36;
				height = 24;
				aiStyle = 1;
				damage = 20;
				defense = 7;
				lifeMax = 90;
				soundHit = 1;
				soundKilled = 1;
				alpha = 120;
				color = new Color(0, 0, 0, 50);
				value = 75f;
				scale = 1.25f;
				knockBackResist = 0.6f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 17)
			{
				townNPC = true;
				friendly = true;
				name = "Merchant";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 18)
			{
				townNPC = true;
				friendly = true;
				name = "Nurse";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 19)
			{
				townNPC = true;
				friendly = true;
				name = "Arms Dealer";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 20)
			{
				townNPC = true;
				friendly = true;
				name = "Dryad";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 21)
			{
				name = "Skeleton";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 20;
				defense = 8;
				lifeMax = 60;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.5f;
				value = 100f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 22)
			{
				townNPC = true;
				friendly = true;
				name = "Guide";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 23)
			{
				name = "Meteor Head";
				width = 22;
				height = 22;
				aiStyle = 5;
				damage = 40;
				defense = 6;
				lifeMax = 26;
				soundHit = 3;
				soundKilled = 3;
				noGravity = true;
				noTileCollide = true;
				value = 80f;
				knockBackResist = 0.4f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 24)
			{
				npcSlots = 3f;
				name = "Fire Imp";
				width = 18;
				height = 40;
				aiStyle = 8;
				damage = 30;
				defense = 16;
				lifeMax = 70;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
				lavaImmune = true;
				value = 350f;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 25)
			{
				name = "Burning Sphere";
				width = 16;
				height = 16;
				aiStyle = 9;
				damage = 30;
				defense = 0;
				lifeMax = 1;
				soundHit = 3;
				soundKilled = 3;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				alpha = 100;
			}
			else if (type == 26)
			{
				name = "Goblin Peon";
				scale = 0.9f;
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 12;
				defense = 4;
				lifeMax = 60;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.8f;
				value = 100f;
				buffImmune[31] = false;
			}
			else if (type == 27)
			{
				name = "Goblin Thief";
				scale = 0.95f;
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 20;
				defense = 6;
				lifeMax = 80;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.7f;
				value = 200f;
				buffImmune[31] = false;
			}
			else if (type == 28)
			{
				name = "Goblin Warrior";
				scale = 1.1f;
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 25;
				defense = 8;
				lifeMax = 110;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
				value = 150f;
				buffImmune[31] = false;
			}
			else if (type == 29)
			{
				name = "Goblin Sorcerer";
				width = 18;
				height = 40;
				aiStyle = 8;
				damage = 20;
				defense = 2;
				lifeMax = 40;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.6f;
				value = 200f;
			}
			else if (type == 30)
			{
				name = "Chaos Ball";
				width = 16;
				height = 16;
				aiStyle = 9;
				damage = 20;
				defense = 0;
				lifeMax = 1;
				soundHit = 3;
				soundKilled = 3;
				noGravity = true;
				noTileCollide = true;
				alpha = 100;
				knockBackResist = 0f;
			}
			else if (type == 31)
			{
				name = "Angry Bones";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 26;
				defense = 8;
				lifeMax = 80;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.8f;
				value = 130f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 32)
			{
				name = "Dark Caster";
				width = 18;
				height = 40;
				aiStyle = 8;
				damage = 20;
				defense = 2;
				lifeMax = 50;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.6f;
				value = 140f;
				npcSlots = 2f;
				buffImmune[20] = true;
			}
			else if (type == 33)
			{
				name = "Water Sphere";
				width = 16;
				height = 16;
				aiStyle = 9;
				damage = 20;
				defense = 0;
				lifeMax = 1;
				soundHit = 3;
				soundKilled = 3;
				noGravity = true;
				noTileCollide = true;
				alpha = 100;
				knockBackResist = 0f;
			}
			else if (type == 34)
			{
				name = "Cursed Skull";
				width = 26;
				height = 28;
				aiStyle = 10;
				damage = 35;
				defense = 6;
				lifeMax = 40;
				soundHit = 2;
				soundKilled = 2;
				noGravity = true;
				noTileCollide = true;
				value = 150f;
				knockBackResist = 0.2f;
				npcSlots = 0.75f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 158)
			{
				name = "Dragon Skull";
				width = 56;
				height = 28;
				aiStyle = 10;
				damage = 45;
				defense = 8;
				lifeMax = 50;
				soundHit = 2;
				soundKilled = 2;
				noGravity = true;
				noTileCollide = true;
				value = 150f;
				knockBackResist = 0.2f;
				npcSlots = 0.75f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 35)
			{
				name = "Skeletron Head";
				width = 80;
				height = 102;
				aiStyle = 11;
				damage = 32;
				defense = 10;
				lifeMax = 4400;
				soundHit = 2;
				soundKilled = 2;
				noGravity = true;
				noTileCollide = true;
				value = 50000f;
				knockBackResist = 0f;
				boss = true;
				npcSlots = 6f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 36)
			{
				name = "Skeletron Hand";
				width = 52;
				height = 52;
				aiStyle = 12;
				damage = 20;
				defense = 14;
				lifeMax = 600;
				soundHit = 2;
				soundKilled = 2;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 37)
			{
				townNPC = true;
				friendly = true;
				name = "Old Man";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 38)
			{
				townNPC = true;
				friendly = true;
				name = "Demolitionist";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 39)
			{
				npcSlots = 6f;
				name = "Bone Serpent Head";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 30;
				defense = 10;
				lifeMax = 250;
				soundHit = 2;
				soundKilled = 5;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 1200f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 40)
			{
				name = "Bone Serpent Body";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 15;
				defense = 12;
				lifeMax = 250;
				soundHit = 2;
				soundKilled = 5;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 1200f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 41)
			{
				name = "Bone Serpent Tail";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 10;
				defense = 18;
				lifeMax = 250;
				soundHit = 2;
				soundKilled = 5;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 1200f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 42)
			{
				name = "Hornet";
				width = 34;
				height = 32;
				aiStyle = 5;
				damage = 34;
				defense = 12;
				lifeMax = 50;
				soundHit = 1;
				knockBackResist = 0.5f;
				soundKilled = 1;
				value = 200f;
				noGravity = true;
				buffImmune[20] = true;
			}
			else if (type == 157)
			{
				name = "Dragon Hornet";
				width = 34;
				height = 32;
				aiStyle = 5;
				damage = 39;
				defense = 17;
				lifeMax = 65;
				soundHit = 1;
				knockBackResist = 0.5f;
				soundKilled = 1;
				value = 200f;
				noGravity = true;
				buffImmune[20] = true;
			}
			else if (type == 43)
			{
				noGravity = true;
				noTileCollide = true;
				name = "Man Eater";
				width = 30;
				height = 30;
				aiStyle = 13;
				damage = 42;
				defense = 14;
				lifeMax = 130;
				soundHit = 1;
				knockBackResist = 0f;
				soundKilled = 1;
				value = 350f;
				buffImmune[20] = true;
			}
			else if (type == 44)
			{
				name = "Undead Miner";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 22;
				defense = 9;
				lifeMax = 70;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.5f;
				value = 250f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 149)
			{
				name = "Vampire Miner";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 30;
				defense = 9;
				lifeMax = 90;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.7f;
				value = 250f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 45)
			{
				name = "Tim";
				width = 18;
				height = 40;
				aiStyle = 8;
				damage = 20;
				defense = 4;
				lifeMax = 200;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.6f;
				value = 5000f;
				buffImmune[20] = true;
			}
			else if (type == 46)
			{
				name = "Bunny";
				width = 18;
				height = 20;
				aiStyle = 7;
				damage = 0;
				defense = 0;
				lifeMax = 5;
				soundHit = 1;
				soundKilled = 1;
			}
			else if (type == 47)
			{
				name = "Corrupt Bunny";
				width = 18;
				height = 20;
				aiStyle = 3;
				damage = 20;
				defense = 4;
				lifeMax = 70;
				soundHit = 1;
				soundKilled = 1;
				value = 500f;
				buffImmune[31] = false;
			}
			else if (type == 48)
			{
				name = "Harpy";
				width = 24;
				height = 34;
				aiStyle = 14;
				damage = 25;
				defense = 8;
				lifeMax = 100;
				soundHit = 1;
				knockBackResist = 0.6f;
				soundKilled = 1;
				value = 300f;
			}
			else if (type == 49)
			{
				npcSlots = 0.5f;
				name = "Cave Bat";
				width = 22;
				height = 18;
				aiStyle = 14;
				damage = 13;
				defense = 2;
				lifeMax = 16;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 4;
				value = 90f;
				buffImmune[31] = false;
			}
			else if (type == 50)
			{
				boss = true;
				name = "King Slime";
				width = 98;
				height = 92;
				aiStyle = 15;
				damage = 40;
				defense = 10;
				lifeMax = 2000;
				knockBackResist = 0f;
				soundHit = 1;
				soundKilled = 1;
				alpha = 30;
				value = 10000f;
				scale = 1.25f;
				buffImmune[20] = true;
			}
			else if (type == 51)
			{
				npcSlots = 0.5f;
				name = "Jungle Bat";
				width = 22;
				height = 18;
				aiStyle = 14;
				damage = 20;
				defense = 4;
				lifeMax = 34;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 4;
				value = 80f;
				buffImmune[31] = false;
			}
			else if (type == 52)
			{
				name = "Doctor Bones";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 20;
				defense = 10;
				lifeMax = 500;
				soundHit = 1;
				soundKilled = 2;
				knockBackResist = 0.5f;
				value = 1000f;
				buffImmune[31] = false;
			}
			else if (type == 53)
			{
				name = "The Groom";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 14;
				defense = 8;
				lifeMax = 200;
				soundHit = 1;
				soundKilled = 2;
				knockBackResist = 0.5f;
				value = 1000f;
				buffImmune[31] = false;
			}
			else if (type == 54)
			{
				townNPC = true;
				friendly = true;
				name = "Clothier";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 55)
			{
				noGravity = true;
				name = "Goldfish";
				width = 20;
				height = 18;
				aiStyle = 16;
				damage = 0;
				defense = 0;
				lifeMax = 5;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 56)
			{
				noTileCollide = true;
				noGravity = true;
				name = "Snatcher";
				width = 30;
				height = 30;
				aiStyle = 13;
				damage = 25;
				defense = 10;
				lifeMax = 60;
				soundHit = 1;
				knockBackResist = 0f;
				soundKilled = 1;
				value = 90f;
				buffImmune[20] = true;
			}
			else if (type == 156)
			{
				noTileCollide = true;
				noGravity = true;
				name = "Dragon Snatcher";
				width = 30;
				height = 30;
				aiStyle = 13;
				damage = 30;
				defense = 15;
				lifeMax = 75;
				soundHit = 1;
				knockBackResist = 0f;
				soundKilled = 1;
				value = 90f;
				buffImmune[20] = true;
			}
			else if (type == 57)
			{
				noGravity = true;
				name = "Corrupt Goldfish";
				width = 18;
				height = 20;
				aiStyle = 16;
				damage = 30;
				defense = 6;
				lifeMax = 100;
				soundHit = 1;
				soundKilled = 1;
				value = 500f;
			}
			else if (type == 58)
			{
				npcSlots = 0.5f;
				noGravity = true;
				name = "Piranha";
				width = 18;
				height = 20;
				aiStyle = 16;
				damage = 25;
				defense = 2;
				lifeMax = 30;
				soundHit = 1;
				soundKilled = 1;
				value = 50f;
			}
			else if (type == 59)
			{
				name = "Lava Slime";
				width = 24;
				height = 18;
				aiStyle = 1;
				damage = 15;
				defense = 10;
				lifeMax = 50;
				soundHit = 1;
				soundKilled = 1;
				scale = 1.1f;
				alpha = 50;
				lavaImmune = true;
				value = 120f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				buffImmune[31] = false;
			}
			else if (type == 60)
			{
				npcSlots = 0.5f;
				name = "Hellbat";
				width = 22;
				height = 18;
				aiStyle = 14;
				damage = 35;
				defense = 8;
				lifeMax = 46;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 4;
				value = 120f;
				scale = 1.1f;
				lavaImmune = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				buffImmune[31] = false;
			}
			else if (type == 61)
			{
				name = "Vulture";
				width = 36;
				height = 36;
				aiStyle = 17;
				damage = 15;
				defense = 4;
				lifeMax = 40;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 60f;
			}
			else if (type == 62)
			{
				npcSlots = 2f;
				name = "Demon";
				width = 28;
				height = 48;
				aiStyle = 14;
				damage = 32;
				defense = 8;
				lifeMax = 120;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 300f;
				lavaImmune = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 165)
			{
				npcSlots = 2f;
				name = "Arch Demon";
				width = 28;
				height = 48;
				aiStyle = 14;
				damage = 42;
				defense = 8;
				lifeMax = 140;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 300f;
				lavaImmune = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 63)
			{
				noGravity = true;
				name = "Blue Jellyfish";
				width = 26;
				height = 26;
				aiStyle = 18;
				damage = 20;
				defense = 2;
				lifeMax = 30;
				soundHit = 1;
				soundKilled = 1;
				value = 100f;
				alpha = 20;
			}
			else if (type == 64)
			{
				noGravity = true;
				name = "Pink Jellyfish";
				width = 26;
				height = 26;
				aiStyle = 18;
				damage = 30;
				defense = 6;
				lifeMax = 70;
				soundHit = 1;
				soundKilled = 1;
				value = 100f;
				alpha = 20;
			}
			else if (type == 65)
			{
				noGravity = true;
				name = "Shark";
				width = 100;
				height = 24;
				aiStyle = 16;
				damage = 40;
				defense = 2;
				lifeMax = 300;
				soundHit = 1;
				soundKilled = 1;
				value = 400f;
				knockBackResist = 0.7f;
			}
			else if (type == 148)
			{
				noGravity = true;
				name = "Orka";
				width = 100;
				height = 24;
				aiStyle = 16;
				damage = 30;
				defense = 4;
				lifeMax = 350;
				soundHit = 1;
				soundKilled = 1;
				value = 400f;
				knockBackResist = 0.6f;
			}
			else if (type == 66)
			{
				npcSlots = 2f;
				name = "Voodoo Demon";
				width = 28;
				height = 48;
				aiStyle = 14;
				damage = 32;
				defense = 8;
				lifeMax = 140;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 1000f;
				lavaImmune = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 67)
			{
				name = "Crab";
				width = 28;
				height = 20;
				aiStyle = 3;
				damage = 20;
				defense = 10;
				lifeMax = 40;
				soundHit = 1;
				soundKilled = 1;
				value = 60f;
			}
			else if (type == 68)
			{
				name = "Dungeon Guardian";
				width = 80;
				height = 102;
				aiStyle = 11;
				damage = 9000;
				defense = 9000;
				lifeMax = 9999;
				soundHit = 2;
				soundKilled = 2;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 69)
			{
				name = "Antlion";
				width = 24;
				height = 24;
				aiStyle = 19;
				damage = 10;
				defense = 6;
				lifeMax = 45;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0f;
				value = 60f;
				behindTiles = true;
			}
			else if (type == 147)
			{
				name = "Albino Antlion";
				width = 24;
				height = 24;
				aiStyle = 19;
				damage = 12;
				defense = 8;
				lifeMax = 60;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0f;
				value = 60f;
				behindTiles = true;
			}
			else if (type == 70)
			{
				npcSlots = 0.3f;
				name = "Spike Ball";
				width = 34;
				height = 34;
				aiStyle = 20;
				damage = 32;
				defense = 100;
				lifeMax = 100;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0f;
				noGravity = true;
				noTileCollide = true;
				dontTakeDamage = true;
				scale = 1.5f;
			}
			else if (type == 71)
			{
				npcSlots = 2f;
				name = "Dungeon Slime";
				width = 36;
				height = 24;
				aiStyle = 1;
				damage = 30;
				defense = 7;
				lifeMax = 150;
				soundHit = 1;
				soundKilled = 1;
				alpha = 60;
				value = 150f;
				scale = 1.25f;
				knockBackResist = 0.6f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 72)
			{
				npcSlots = 0.3f;
				name = "Blazing Wheel";
				width = 34;
				height = 34;
				aiStyle = 21;
				damage = 24;
				defense = 100;
				lifeMax = 100;
				alpha = 100;
				behindTiles = true;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0f;
				noGravity = true;
				dontTakeDamage = true;
				scale = 1.2f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 73)
			{
				name = "Goblin Scout";
				scale = 0.95f;
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 20;
				defense = 6;
				lifeMax = 80;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.7f;
				value = 200f;
				buffImmune[31] = false;
			}
			else if (type == 74)
			{
				name = "Bird";
				width = 14;
				height = 14;
				aiStyle = 24;
				damage = 0;
				defense = 0;
				lifeMax = 5;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
			}
			else if (type == 75)
			{
				noGravity = true;
				name = "Pixie";
				width = 20;
				height = 20;
				aiStyle = 22;
				damage = 55;
				defense = 20;
				lifeMax = 150;
				soundHit = 5;
				knockBackResist = 0.6f;
				soundKilled = 7;
				value = 350f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				buffImmune[31] = false;
			}
			else if (type == 77)
			{
				name = "Armored Skeleton";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 60;
				defense = 36;
				lifeMax = 340;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.4f;
				value = 400f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 78)
			{
				name = "Mummy";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 50;
				defense = 16;
				lifeMax = 130;
				soundHit = 1;
				soundKilled = 6;
				knockBackResist = 0.6f;
				value = 600f;
				buffImmune[31] = false;
			}
			else if (type == 79)
			{
				name = "Dark Mummy";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 60;
				defense = 18;
				lifeMax = 180;
				soundHit = 1;
				soundKilled = 6;
				knockBackResist = 0.5f;
				value = 700f;
				buffImmune[31] = false;
			}
			else if (type == 152)
			{
				name = "Shadow Mummy";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 60;
				defense = 25;
				lifeMax = 190;
				soundHit = 1;
				soundKilled = 6;
				knockBackResist = 0.5f;
				value = 700f;
				buffImmune[31] = false;
			}
			else if (type == 80)
			{
				name = "Light Mummy";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 55;
				defense = 18;
				lifeMax = 200;
				soundHit = 1;
				soundKilled = 6;
				knockBackResist = 0.55f;
				value = 700f;
				buffImmune[31] = false;
			}
			else if (type == 155)
			{
				name = "Spectral Mummy";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 65;
				defense = 10;
				lifeMax = 270;
				soundHit = 1;
				soundKilled = 6;
				knockBackResist = 0.55f;
				value = 700f;
				buffImmune[31] = false;
			}
			else if (type == 81)
			{
				name = "Corrupt Slime";
				width = 40;
				height = 30;
				aiStyle = 1;
				damage = 55;
				defense = 20;
				lifeMax = 170;
				soundHit = 1;
				soundKilled = 1;
				alpha = 55;
				value = 400f;
				scale = 1.1f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 150)
			{
				name = "Shadow Slime";
				width = 40;
				height = 30;
				aiStyle = 1;
				damage = 60;
				defense = 25;
				lifeMax = 180;
				soundHit = 1;
				soundKilled = 1;
				alpha = 55;
				value = 400f;
				scale = 1.1f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 82)
			{
				noGravity = true;
				noTileCollide = true;
				name = "Wraith";
				width = 24;
				height = 44;
				aiStyle = 22;
				damage = 75;
				defense = 18;
				lifeMax = 200;
				soundHit = 1;
				soundKilled = 6;
				alpha = 100;
				value = 500f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				knockBackResist = 0.7f;
			}
			else if (type == 83)
			{
				name = "Cursed Hammer";
				width = 40;
				height = 40;
				aiStyle = 23;
				damage = 80;
				defense = 18;
				lifeMax = 200;
				soundHit = 4;
				soundKilled = 6;
				value = 1000f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				knockBackResist = 0.4f;
			}
			else if (type == 151)
			{
				name = "Shadow Hammer";
				width = 40;
				height = 40;
				aiStyle = 23;
				damage = 95;
				defense = 18;
				lifeMax = 180;
				soundHit = 4;
				soundKilled = 6;
				value = 1000f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				knockBackResist = 0.4f;
			}
			else if (type == 84)
			{
				name = "Enchanted Sword";
				width = 40;
				height = 40;
				aiStyle = 23;
				damage = 80;
				defense = 18;
				lifeMax = 200;
				soundHit = 4;
				soundKilled = 6;
				value = 1000f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				knockBackResist = 0.4f;
			}
			else if (type == 85)
			{
				name = "Mimic";
				width = 24;
				height = 24;
				aiStyle = 25;
				damage = 80;
				defense = 30;
				lifeMax = 500;
				soundHit = 4;
				soundKilled = 6;
				value = 100000f;
				knockBackResist = 0.3f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 86)
			{
				name = "Unicorn";
				width = 46;
				height = 42;
				aiStyle = 26;
				damage = 65;
				defense = 30;
				lifeMax = 400;
				soundHit = 10;
				soundKilled = 1;
				knockBackResist = 0.3f;
				value = 1000f;
				buffImmune[31] = false;
			}
			else if (type == 87)
			{
				noTileCollide = true;
				npcSlots = 5f;
				name = "Wyvern Head";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 80;
				defense = 10;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 159)
			{
				noTileCollide = true;
				npcSlots = 5f;
				name = "Arch Wyvern Head";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 100;
				defense = 15;
				lifeMax = 4700;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 88)
			{
				noTileCollide = true;
				name = "Wyvern Legs";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 40;
				defense = 20;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 160)
			{
				noTileCollide = true;
				name = "Arch Wyvern Legs";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 50;
				defense = 25;
				lifeMax = 4500;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 89)
			{
				noTileCollide = true;
				name = "Wyvern Body";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 40;
				defense = 20;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 2000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 161)
			{
				noTileCollide = true;
				name = "Arch Wyvern Body";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 45;
				defense = 20;
				lifeMax = 4300;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 2000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 90)
			{
				noTileCollide = true;
				name = "Wyvern Body 2";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 40;
				defense = 20;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 162)
			{
				noTileCollide = true;
				name = "Arch Wyvern Body 2";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 40;
				defense = 20;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 91)
			{
				noTileCollide = true;
				name = "Wyvern Body 3";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 40;
				defense = 20;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 163)
			{
				noTileCollide = true;
				name = "Arch Wyvern Body 3";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 45;
				defense = 20;
				lifeMax = 4300;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 92)
			{
				noTileCollide = true;
				name = "Wyvern Tail";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 40;
				defense = 20;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 164)
			{
				noTileCollide = true;
				name = "Arch Wyvern Tail";
				width = 32;
				height = 32;
				aiStyle = 6;
				netAlways = true;
				damage = 55;
				defense = 15;
				lifeMax = 4000;
				soundHit = 7;
				soundKilled = 8;
				noGravity = true;
				knockBackResist = 0f;
				value = 10000f;
				scale = 1f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 93)
			{
				npcSlots = 0.5f;
				name = "Giant Bat";
				width = 26;
				height = 20;
				aiStyle = 14;
				damage = 70;
				defense = 20;
				lifeMax = 160;
				soundHit = 1;
				knockBackResist = 0.75f;
				soundKilled = 4;
				value = 400f;
				buffImmune[31] = false;
			}
			else if (type == 94)
			{
				npcSlots = 1f;
				name = "Corruptor";
				width = 44;
				height = 44;
				aiStyle = 5;
				damage = 60;
				defense = 32;
				lifeMax = 230;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				knockBackResist = 0.55f;
				value = 500f;
			}
			else if (type == 95)
			{
				name = "Digger Head";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 45;
				defense = 10;
				lifeMax = 200;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				scale = 0.9f;
				value = 300f;
			}
			else if (type == 96)
			{
				name = "Digger Body";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 28;
				defense = 20;
				lifeMax = 200;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				scale = 0.9f;
				value = 300f;
			}
			else if (type == 97)
			{
				name = "Digger Tail";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 26;
				defense = 30;
				lifeMax = 200;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				scale = 0.9f;
				value = 300f;
			}
			else if (type == 98)
			{
				npcSlots = 3.5f;
				name = "Seeker Head";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 70;
				defense = 36;
				lifeMax = 500;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 700f;
			}
			else if (type == 99)
			{
				name = "Seeker Body";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 55;
				defense = 40;
				lifeMax = 500;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 700f;
			}
			else if (type == 100)
			{
				name = "Seeker Tail";
				width = 22;
				height = 22;
				aiStyle = 6;
				netAlways = true;
				damage = 40;
				defense = 44;
				lifeMax = 500;
				soundHit = 1;
				soundKilled = 1;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 700f;
			}
			else if (type == 101)
			{
				noGravity = true;
				noTileCollide = true;
				behindTiles = true;
				name = "Clinger";
				width = 30;
				height = 30;
				aiStyle = 13;
				damage = 70;
				defense = 30;
				lifeMax = 320;
				soundHit = 1;
				knockBackResist = 0.2f;
				soundKilled = 1;
				value = 600f;
			}
			else if (type == 102)
			{
				npcSlots = 0.5f;
				noGravity = true;
				name = "Angler Fish";
				width = 18;
				height = 20;
				aiStyle = 16;
				damage = 80;
				defense = 22;
				lifeMax = 90;
				soundHit = 1;
				soundKilled = 1;
				value = 500f;
			}
			else if (type == 103)
			{
				noGravity = true;
				name = "Green Jellyfish";
				width = 26;
				height = 26;
				aiStyle = 18;
				damage = 80;
				defense = 30;
				lifeMax = 120;
				soundHit = 1;
				soundKilled = 1;
				value = 800f;
				alpha = 20;
			}
			else if (type == 104)
			{
				name = "Werewolf";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 70;
				defense = 40;
				lifeMax = 400;
				soundHit = 6;
				soundKilled = 1;
				knockBackResist = 0.4f;
				value = 1000f;
				buffImmune[31] = false;
			}
			else if (type == 105)
			{
				friendly = true;
				name = "Bound Goblin";
				width = 18;
				height = 34;
				aiStyle = 0;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
				scale = 0.9f;
			}
			else if (type == 106)
			{
				friendly = true;
				name = "Bound Wizard";
				width = 18;
				height = 40;
				aiStyle = 0;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 107)
			{
				townNPC = true;
				friendly = true;
				name = "Goblin Tinkerer";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
				scale = 0.9f;
			}
			else if (type == 108)
			{
				townNPC = true;
				friendly = true;
				name = "Wizard";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 109)
			{
				name = "Clown";
				width = 34;
				height = 78;
				aiStyle = 3;
				damage = 50;
				defense = 20;
				lifeMax = 400;
				soundHit = 1;
				soundKilled = 2;
				knockBackResist = 0.4f;
				value = 8000f;
			}
			else if (type == 110)
			{
				name = "Skeleton Archer";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 55;
				defense = 28;
				lifeMax = 260;
				soundHit = 2;
				soundKilled = 2;
				knockBackResist = 0.55f;
				value = 400f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 111)
			{
				name = "Goblin Archer";
				scale = 0.95f;
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 20;
				defense = 6;
				lifeMax = 80;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.7f;
				value = 200f;
				buffImmune[31] = false;
			}
			else if (type == 112)
			{
				name = "Vile Spit";
				width = 16;
				height = 16;
				aiStyle = 9;
				damage = 65;
				defense = 0;
				lifeMax = 1;
				soundHit = 0;
				soundKilled = 9;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				scale = 0.9f;
				alpha = 80;
			}
			else if (type == 113)
			{
				npcSlots = 10f;
				name = "Wall of Flesh";
				width = 100;
				height = 100;
				aiStyle = 27;
				damage = 50;
				defense = 12;
				lifeMax = 8000;
				soundHit = 8;
				soundKilled = 10;
				noGravity = true;
				noTileCollide = true;
				behindTiles = true;
				knockBackResist = 0f;
				scale = 1.2f;
				boss = true;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				value = 80000f;
			}
			else if (type == 114)
			{
				name = "Wall of Flesh Eye";
				width = 100;
				height = 100;
				aiStyle = 28;
				damage = 50;
				defense = 0;
				lifeMax = 8000;
				soundHit = 8;
				soundKilled = 10;
				noGravity = true;
				noTileCollide = true;
				behindTiles = true;
				knockBackResist = 0f;
				scale = 1.2f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				value = 80000f;
			}
			else if (type == 115)
			{
				name = "The Hungry";
				width = 30;
				height = 30;
				aiStyle = 29;
				damage = 30;
				defense = 10;
				lifeMax = 240;
				soundHit = 9;
				soundKilled = 11;
				noGravity = true;
				behindTiles = true;
				noTileCollide = true;
				knockBackResist = 1.1f;
			}
			else if (type == 116)
			{
				name = "The Hungry II";
				width = 30;
				height = 32;
				aiStyle = 2;
				damage = 30;
				defense = 6;
				lifeMax = 80;
				soundHit = 9;
				knockBackResist = 0.8f;
				soundKilled = 12;
			}
			else if (type == 117)
			{
				name = "Leech Head";
				width = 14;
				height = 14;
				aiStyle = 6;
				netAlways = true;
				damage = 26;
				defense = 2;
				lifeMax = 60;
				soundHit = 9;
				soundKilled = 12;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
			}
			else if (type == 118)
			{
				name = "Leech Body";
				width = 14;
				height = 14;
				aiStyle = 6;
				netAlways = true;
				damage = 22;
				defense = 6;
				lifeMax = 60;
				soundHit = 9;
				soundKilled = 12;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
			}
			else if (type == 119)
			{
				name = "Leech Tail";
				width = 14;
				height = 14;
				aiStyle = 6;
				netAlways = true;
				damage = 18;
				defense = 10;
				lifeMax = 60;
				soundHit = 9;
				soundKilled = 12;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
			}
			else if (type == 120)
			{
				name = "Chaos Elemental";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 40;
				defense = 30;
				lifeMax = 370;
				soundHit = 1;
				soundKilled = 6;
				knockBackResist = 0.4f;
				value = 600f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				buffImmune[31] = false;
			}
			else if (type == 154)
			{
				name = "Spectral Elemental";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 50;
				defense = 35;
				lifeMax = 400;
				soundHit = 1;
				soundKilled = 6;
				knockBackResist = 0.4f;
				value = 600f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				buffImmune[31] = false;
			}
			else if (type == 121)
			{
				name = "Slimer";
				width = 40;
				height = 30;
				aiStyle = 14;
				damage = 45;
				defense = 20;
				lifeMax = 60;
				soundHit = 1;
				alpha = 55;
				knockBackResist = 0.8f;
				scale = 1.1f;
				buffImmune[20] = true;
				buffImmune[31] = false;
			}
			else if (type == 122)
			{
				noGravity = true;
				name = "Gastropod";
				width = 20;
				height = 20;
				aiStyle = 22;
				damage = 60;
				defense = 22;
				lifeMax = 220;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 600f;
				buffImmune[20] = true;
			}
			else if (type == 153)
			{
				noGravity = true;
				name = "Spectral Gastropod";
				width = 20;
				height = 20;
				aiStyle = 22;
				damage = 60;
				defense = 22;
				lifeMax = 220;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 600f;
				buffImmune[20] = true;
			}
			else if (type == 123)
			{
				friendly = true;
				name = "Bound Mechanic";
				width = 18;
				height = 34;
				aiStyle = 0;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
				scale = 0.9f;
			}
			else if (type == 124)
			{
				townNPC = true;
				friendly = true;
				name = "Mechanic";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 125)
			{
				name = "Retinazer";
				width = 100;
				height = 110;
				aiStyle = 30;
				damage = 50;
				defense = 10;
				lifeMax = 24000;
				soundHit = 1;
				soundKilled = 14;
				knockBackResist = 0f;
				noGravity = true;
				noTileCollide = true;
				timeLeft = 22500;
				boss = true;
				value = 120000f;
				npcSlots = 5f;
			}
			else if (type == 126)
			{
				name = "Spazmatism";
				width = 100;
				height = 110;
				aiStyle = 31;
				damage = 50;
				defense = 10;
				lifeMax = 24000;
				soundHit = 1;
				soundKilled = 14;
				knockBackResist = 0f;
				noGravity = true;
				noTileCollide = true;
				timeLeft = 22500;
				boss = true;
				value = 120000f;
				npcSlots = 5f;
			}
			else if (type == 127)
			{
				name = "Skeletron Prime";
				width = 80;
				height = 102;
				aiStyle = 32;
				damage = 50;
				defense = 25;
				lifeMax = 30000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				value = 120000f;
				knockBackResist = 0f;
				boss = true;
				npcSlots = 6f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 128)
			{
				name = "Prime Cannon";
				width = 52;
				height = 52;
				aiStyle = 35;
				damage = 30;
				defense = 25;
				lifeMax = 7000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				netAlways = true;
			}
			else if (type == 129)
			{
				name = "Prime Saw";
				width = 52;
				height = 52;
				aiStyle = 33;
				damage = 52;
				defense = 40;
				lifeMax = 10000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				netAlways = true;
			}
			else if (type == 130)
			{
				name = "Prime Vice";
				width = 52;
				height = 52;
				aiStyle = 34;
				damage = 45;
				defense = 35;
				lifeMax = 10000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				netAlways = true;
			}
			else if (type == 131)
			{
				name = "Prime Laser";
				width = 52;
				height = 52;
				aiStyle = 36;
				damage = 29;
				defense = 20;
				lifeMax = 6000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				netAlways = true;
			}
			else if (type == 132)
			{
				name = "Bald Zombie";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 14;
				defense = 6;
				lifeMax = 45;
				soundHit = 1;
				soundKilled = 2;
				knockBackResist = 0.5f;
				value = 60f;
				buffImmune[31] = false;
			}
			else if (type == 133)
			{
				name = "Wandering Eye";
				width = 30;
				height = 32;
				aiStyle = 2;
				damage = 40;
				defense = 20;
				lifeMax = 300;
				soundHit = 1;
				knockBackResist = 0.8f;
				soundKilled = 1;
				value = 500f;
				buffImmune[31] = false;
			}
			else if (type == 134)
			{
				npcSlots = 5f;
				name = "The Destroyer";
				width = 38;
				height = 38;
				aiStyle = 37;
				damage = 60;
				defense = 0;
				lifeMax = 80000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				value = 120000f;
				scale = 1.25f;
				boss = true;
				netAlways = true;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 135)
			{
				npcSlots = 5f;
				name = "The Destroyer Body";
				width = 38;
				height = 38;
				aiStyle = 37;
				damage = 40;
				defense = 30;
				lifeMax = 80000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				netAlways = true;
				scale = 1.25f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 136)
			{
				npcSlots = 5f;
				name = "The Destroyer Tail";
				width = 38;
				height = 38;
				aiStyle = 37;
				damage = 20;
				defense = 35;
				lifeMax = 80000;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				noTileCollide = true;
				knockBackResist = 0f;
				behindTiles = true;
				scale = 1.25f;
				netAlways = true;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 137)
			{
				name = "Illuminant Bat";
				width = 26;
				height = 20;
				aiStyle = 14;
				damage = 75;
				defense = 30;
				lifeMax = 200;
				soundHit = 1;
				knockBackResist = 0.75f;
				soundKilled = 6;
				value = 500f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				buffImmune[31] = false;
			}
			else if (type == 138)
			{
				name = "Illuminant Slime";
				width = 24;
				height = 18;
				aiStyle = 1;
				damage = 70;
				defense = 30;
				lifeMax = 180;
				soundHit = 1;
				soundKilled = 6;
				alpha = 100;
				value = 400f;
				buffImmune[20] = true;
				buffImmune[24] = true;
				buffImmune[39] = true;
				knockBackResist = 0.85f;
				scale = 1.05f;
				buffImmune[31] = false;
			}
			else if (type == 139)
			{
				npcSlots = 1f;
				name = "Probe";
				width = 30;
				height = 30;
				aiStyle = 5;
				damage = 50;
				defense = 20;
				lifeMax = 200;
				soundHit = 4;
				soundKilled = 14;
				noGravity = true;
				knockBackResist = 0.8f;
				noTileCollide = true;
			}
			else if (type == 140)
			{
				name = "Possessed Armor";
				width = 18;
				height = 40;
				aiStyle = 3;
				damage = 55;
				defense = 28;
				lifeMax = 260;
				soundHit = 4;
				soundKilled = 6;
				knockBackResist = 0.4f;
				value = 400f;
				buffImmune[20] = true;
				buffImmune[31] = false;
				buffImmune[24] = true;
			}
			else if (type == 141)
			{
				name = "Toxic Sludge";
				width = 34;
				height = 28;
				aiStyle = 1;
				damage = 50;
				defense = 18;
				lifeMax = 150;
				soundHit = 1;
				soundKilled = 1;
				alpha = 55;
				value = 400f;
				scale = 1.1f;
				buffImmune[20] = true;
				buffImmune[31] = false;
				knockBackResist = 0.8f;
			}
			else if (type == 142)
			{
				townNPC = true;
				friendly = true;
				name = "Santa Claus";
				width = 18;
				height = 40;
				aiStyle = 7;
				damage = 10;
				defense = 15;
				lifeMax = 250;
				soundHit = 1;
				soundKilled = 1;
				knockBackResist = 0.5f;
			}
			else if (type == 143)
			{
				name = "Snowman Gangsta";
				width = 26;
				height = 40;
				aiStyle = 38;
				damage = 50;
				defense = 20;
				lifeMax = 200;
				soundHit = 11;
				soundKilled = 15;
				knockBackResist = 0.6f;
				value = 400f;
				buffImmune[20] = true;
				buffImmune[31] = false;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 144)
			{
				name = "Mister Stabby";
				width = 26;
				height = 40;
				aiStyle = 38;
				damage = 65;
				defense = 26;
				lifeMax = 240;
				soundHit = 11;
				soundKilled = 15;
				knockBackResist = 0.6f;
				value = 400f;
				buffImmune[20] = true;
				buffImmune[31] = false;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			else if (type == 145)
			{
				name = "Snow Balla";
				width = 26;
				height = 40;
				aiStyle = 38;
				damage = 55;
				defense = 22;
				lifeMax = 220;
				soundHit = 11;
				soundKilled = 15;
				knockBackResist = 0.6f;
				value = 400f;
				buffImmune[20] = true;
				buffImmune[31] = false;
				buffImmune[24] = true;
				buffImmune[39] = true;
			}
			frameY = 0;
			frameHeight = (short)(SpriteSheet<_sheetSprites>.src[1088 + type].Height / (int)npcFrameCount[type]);
			if (scaleOverride > 0.0)
			{
				int num = (int)((float)(int)width * scale);
				int num2 = (int)((float)(int)height * scale);
				position.X += num >> 1;
				position.Y += num2;
				scale = (float)scaleOverride;
				width = (ushort)((float)(int)width * scale);
				height = (ushort)((float)(int)height * scale);
				if (height == 16 || height == 32)
				{
					height++;
				}
				position.X -= width >> 1;
				position.Y -= (int)height;
			}
			else
			{
				width = (ushort)((float)(int)width * scale);
				height = (ushort)((float)(int)height * scale);
			}
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
			aabb.Width = width;
			aabb.Height = height;
			healthBarLife = (life = lifeMax);
			defDamage = damage;
			defDefense = (short)defense;
			displayName = Lang.npcName(netID);
		}

		private void BoundAI()
		{
			if (Main.netMode != 1)
			{
				for (int i = 0; i < 8; i++)
				{
					if (Main.player[i].active != 0 && Main.player[i].talkNPC == whoAmI)
					{
						if (type == 105)
						{
							Transform(107);
							return;
						}
						if (type == 106)
						{
							Transform(108);
							return;
						}
						if (type == 123)
						{
							Transform(124);
							return;
						}
					}
				}
			}
			velocity.X *= 0.93f;
			if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
			{
				velocity.X = 0f;
			}
			TargetClosest();
			spriteDirection = direction;
		}

		private unsafe void SlimeAI()
		{
			bool flag = !Main.gameTime.dayTime || life != lifeMax || aabb.Y > Main.worldSurface << 4;
			if (type == 81)
			{
				flag = true;
				if (Main.rand.Next(32) == 0)
				{
					Dust* ptr = Main.dust.NewDust(14, ref aabb, 0.0, 0.0, alpha, color);
					if (ptr != null)
					{
						ptr->velocity.X *= 0.3f;
						ptr->velocity.Y *= 0.3f;
					}
				}
			}
			else if (type == 59)
			{
				Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, new Vector3(1f, 0.3f, 0.1f));
				Dust* ptr2 = Main.dust.NewDust(6, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 1.7000000476837158);
				if (ptr2 != null)
				{
					ptr2->noGravity = true;
				}
			}
			if (ai2 > 1f)
			{
				ai2 -= 1f;
			}
			if (wet)
			{
				if (collideY)
				{
					velocity.Y = -2f;
				}
				if (velocity.Y < 0f)
				{
					if (ai3 == position.X)
					{
						direction = (sbyte)(-direction);
						ai2 = 200f;
					}
				}
				else if (velocity.Y > 0f)
				{
					ai3 = position.X;
				}
				if (type == 59)
				{
					if (velocity.Y > 2f)
					{
						velocity.Y *= 0.9f;
					}
					else if (directionY < 0)
					{
						velocity.Y -= 0.8f;
					}
					velocity.Y -= 0.5f;
					if (velocity.Y < -10f)
					{
						velocity.Y = -10f;
					}
				}
				else
				{
					if (velocity.Y > 2f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y -= 0.5f;
					if (velocity.Y < -4f)
					{
						velocity.Y = -4f;
					}
				}
				if (ai2 == 1f && flag)
				{
					TargetClosest();
				}
			}
			aiAction = 0;
			if (ai2 == 0f)
			{
				ai0 = -100f;
				ai2 = 1f;
				TargetClosest();
			}
			if (velocity.Y == 0f)
			{
				if (ai3 == position.X)
				{
					direction = (sbyte)(-direction);
					ai2 = 200f;
				}
				ai3 = 0f;
				velocity.X *= 0.8f;
				if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
				{
					velocity.X = 0f;
				}
				if (flag)
				{
					ai0 += 1f;
				}
				ai0 += 1f;
				if (type == 59)
				{
					ai0 += 2f;
				}
				else if (type == 71)
				{
					ai0 += 3f;
				}
				else if (type == 138)
				{
					ai0 += 2f;
				}
				else if (type == 81)
				{
					if (scale >= 0f)
					{
						ai0 += 4f;
					}
					else
					{
						ai0 += 1f;
					}
				}
				if (ai0 >= 0f)
				{
					netUpdate = true;
					if (flag && ai2 == 1f)
					{
						TargetClosest();
					}
					if (ai1 == 2f)
					{
						if (type == 59)
						{
							velocity.X += 3.5f * (float)direction;
							velocity.Y = -10f;
						}
						else
						{
							velocity.X += 3 * direction;
							velocity.Y = -8f;
						}
						ai0 = -200f;
						ai1 = 0f;
						ai3 = position.X;
					}
					else
					{
						velocity.Y = -6f;
						velocity.X += 2 * direction;
						if (type == 59)
						{
							velocity.X += 2 * direction;
						}
						ai0 = -120f;
						ai1 += 1f;
					}
					if (type == 141)
					{
						velocity.Y *= 1.3f;
						velocity.X *= 1.2f;
					}
				}
				else if (ai0 >= -30f)
				{
					aiAction = 1;
				}
			}
			else if (target < 8 && ((direction == 1 && velocity.X < 3f) || (direction == -1 && velocity.X > -3f)))
			{
				if ((direction == -1 && (double)velocity.X < 0.1) || (direction == 1 && (double)velocity.X > -0.1))
				{
					velocity.X += 0.2f * (float)direction;
				}
				else
				{
					velocity.X *= 0.93f;
				}
			}
		}

		private unsafe void FloatingEyeballAI()
		{
			noGravity = true;
			if (collideX)
			{
				velocity.X = oldVelocity.X * -0.5f;
				if (direction == -1 && velocity.X > 0f && velocity.X < 2f)
				{
					velocity.X = 2f;
				}
				else if (direction == 1 && velocity.X < 0f && velocity.X > -2f)
				{
					velocity.X = -2f;
				}
			}
			if (collideY)
			{
				velocity.Y = oldVelocity.Y * -0.5f;
				if (velocity.Y > 0f && velocity.Y < 1f)
				{
					velocity.Y = 1f;
				}
				else if (velocity.Y < 0f && velocity.Y > -1f)
				{
					velocity.Y = -1f;
				}
			}
			if ((type == 2 || type == 133) && Main.gameTime.dayTime && aabb.Y <= Main.worldSurfacePixels)
			{
				if (timeLeft > 10)
				{
					timeLeft = 10;
				}
				directionY = (sbyte)((velocity.Y > 0f) ? 1 : (-1));
				direction = (sbyte)((velocity.X > 0f) ? 1 : (-1));
			}
			else
			{
				TargetClosest();
			}
			if (type == 116)
			{
				TargetClosest();
				Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, new Vector3(0.3f, 0.2f, 0.1f));
				if (direction == -1 && velocity.X > -6f)
				{
					velocity.X -= 0.1f;
					if (velocity.X > 6f)
					{
						velocity.X -= 0.1f;
					}
					else if (velocity.X > 0f)
					{
						velocity.X -= 0.2f;
					}
					if (velocity.X < -6f)
					{
						velocity.X = -6f;
					}
				}
				else if (direction == 1 && velocity.X < 6f)
				{
					velocity.X += 0.1f;
					if (velocity.X < -6f)
					{
						velocity.X += 0.1f;
					}
					else if (velocity.X < 0f)
					{
						velocity.X += 0.2f;
					}
					if (velocity.X > 6f)
					{
						velocity.X = 6f;
					}
				}
				if (directionY == -1 && (double)velocity.Y > -2.5)
				{
					velocity.Y -= 0.04f;
					if ((double)velocity.Y > 2.5)
					{
						velocity.Y -= 0.05f;
					}
					else if (velocity.Y > 0f)
					{
						velocity.Y -= 0.15f;
					}
					if ((double)velocity.Y < -2.5)
					{
						velocity.Y = -2.5f;
					}
				}
				else if (directionY == 1 && (double)velocity.Y < 1.5)
				{
					velocity.Y += 0.04f;
					if ((double)velocity.Y < -2.5)
					{
						velocity.Y += 0.05f;
					}
					else if (velocity.Y < 0f)
					{
						velocity.Y += 0.15f;
					}
					if ((double)velocity.Y > 2.5)
					{
						velocity.Y = 2.5f;
					}
				}
				if (Main.rand.Next(40) == 0)
				{
					Dust* ptr = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 5, velocity.X, 2.0);
					if (ptr != null)
					{
						ptr->velocity.X *= 0.5f;
						ptr->velocity.Y *= 0.1f;
					}
				}
			}
			else if (type == 133)
			{
				if (life < lifeMax >> 1)
				{
					if (direction == -1 && velocity.X > -6f)
					{
						velocity.X -= 0.1f;
						if (velocity.X > 6f)
						{
							velocity.X -= 0.1f;
						}
						else if (velocity.X > 0f)
						{
							velocity.X += 0.05f;
						}
						if (velocity.X < -6f)
						{
							velocity.X = -6f;
						}
					}
					else if (direction == 1 && velocity.X < 6f)
					{
						velocity.X += 0.1f;
						if (velocity.X < -6f)
						{
							velocity.X += 0.1f;
						}
						else if (velocity.X < 0f)
						{
							velocity.X -= 0.05f;
						}
						if (velocity.X > 6f)
						{
							velocity.X = 6f;
						}
					}
					if (directionY == -1 && velocity.Y > -4f)
					{
						velocity.Y -= 0.1f;
						if (velocity.Y > 4f)
						{
							velocity.Y -= 0.1f;
						}
						else if (velocity.Y > 0f)
						{
							velocity.Y += 0.05f;
						}
						if (velocity.Y < -4f)
						{
							velocity.Y = -4f;
						}
					}
					else if (directionY == 1 && velocity.Y < 4f)
					{
						velocity.Y += 0.1f;
						if (velocity.Y < -4f)
						{
							velocity.Y += 0.1f;
						}
						else if (velocity.Y < 0f)
						{
							velocity.Y -= 0.05f;
						}
						if (velocity.Y > 4f)
						{
							velocity.Y = 4f;
						}
					}
				}
				else
				{
					if (direction == -1 && velocity.X > -4f)
					{
						velocity.X -= 0.1f;
						if (velocity.X > 4f)
						{
							velocity.X -= 0.1f;
						}
						else if (velocity.X > 0f)
						{
							velocity.X += 0.05f;
						}
						if (velocity.X < -4f)
						{
							velocity.X = -4f;
						}
					}
					else if (direction == 1 && velocity.X < 4f)
					{
						velocity.X += 0.1f;
						if (velocity.X < -4f)
						{
							velocity.X += 0.1f;
						}
						else if (velocity.X < 0f)
						{
							velocity.X -= 0.05f;
						}
						else if (velocity.X > 4f)
						{
							velocity.X = 4f;
						}
					}
					if (directionY == -1 && (double)velocity.Y > -1.5)
					{
						velocity.Y -= 0.04f;
						if ((double)velocity.Y > 1.5)
						{
							velocity.Y -= 0.05f;
						}
						else if (velocity.Y > 0f)
						{
							velocity.Y += 0.03f;
						}
						else if ((double)velocity.Y < -1.5)
						{
							velocity.Y = -1.5f;
						}
					}
					else if (directionY == 1 && (double)velocity.Y < 1.5)
					{
						velocity.Y += 0.04f;
						if ((double)velocity.Y < -1.5)
						{
							velocity.Y += 0.05f;
						}
						else if (velocity.Y < 0f)
						{
							velocity.Y -= 0.03f;
						}
						else if ((double)velocity.Y > 1.5)
						{
							velocity.Y = 1.5f;
						}
					}
				}
			}
			else
			{
				if (direction == -1 && velocity.X > -4f)
				{
					velocity.X -= 0.1f;
					if (velocity.X > 4f)
					{
						velocity.X -= 0.1f;
					}
					else if (velocity.X > 0f)
					{
						velocity.X += 0.05f;
					}
					else if (velocity.X < -4f)
					{
						velocity.X = -4f;
					}
				}
				else if (direction == 1 && velocity.X < 4f)
				{
					velocity.X += 0.1f;
					if (velocity.X < -4f)
					{
						velocity.X += 0.1f;
					}
					else if (velocity.X < 0f)
					{
						velocity.X -= 0.05f;
					}
					else if (velocity.X > 4f)
					{
						velocity.X = 4f;
					}
				}
				if (directionY == -1 && (double)velocity.Y > -1.5)
				{
					velocity.Y -= 0.04f;
					if ((double)velocity.Y > 1.5)
					{
						velocity.Y -= 0.05f;
					}
					else if (velocity.Y > 0f)
					{
						velocity.Y += 0.03f;
					}
					else if ((double)velocity.Y < -1.5)
					{
						velocity.Y = -1.5f;
					}
				}
				else if (directionY == 1 && (double)velocity.Y < 1.5)
				{
					velocity.Y += 0.04f;
					if ((double)velocity.Y < -1.5)
					{
						velocity.Y += 0.05f;
					}
					else if (velocity.Y < 0f)
					{
						velocity.Y -= 0.03f;
					}
					else if ((double)velocity.Y > 1.5)
					{
						velocity.Y = 1.5f;
					}
				}
			}
			if ((type == 2 || type == 133) && Main.rand.Next(40) == 0)
			{
				Dust* ptr2 = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 5, velocity.X, 2.0);
				if (ptr2 != null)
				{
					ptr2->velocity.X *= 0.5f;
					ptr2->velocity.Y *= 0.1f;
				}
			}
			if (wet)
			{
				if (velocity.Y > 0f)
				{
					velocity.Y *= 0.95f;
				}
				velocity.Y -= 0.5f;
				if (velocity.Y < -4f)
				{
					velocity.Y = -4f;
				}
				TargetClosest();
			}
		}

		private unsafe void WalkAI()
		{
			int num = 60;
			if (type == 120 || type == 154)
			{
				num = 20;
				if (ai3 == -120f)
				{
					velocity.X = 0f;
					velocity.Y = 0f;
					ai3 = 0f;
					Main.PlaySound(2, aabb.X, aabb.Y, 8);
					Vector2 vector = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
					float num2 = oldPos[2].X + (float)(width >> 1) - vector.X;
					float num3 = oldPos[2].Y + (float)(height >> 1) - vector.Y;
					float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					num4 = 2f / num4;
					num2 *= num4;
					num3 *= num4;
					for (int i = 0; i < 16; i++)
					{
						Dust* ptr = Main.dust.NewDust(71, ref aabb, num2, num3, 200, default(Color), 2.0);
						if (ptr == null)
						{
							break;
						}
						ptr->noGravity = true;
						ptr->velocity.X *= 2f;
					}
					for (int j = 0; j < 16; j++)
					{
						Dust* ptr2 = Main.dust.NewDust((int)oldPos[2].X, (int)oldPos[2].Y, width, height, 71, 0f - num2, 0f - num3, 200, default(Color), 2.0);
						if (ptr2 == null)
						{
							break;
						}
						ptr2->noGravity = true;
						ptr2->velocity.X *= 2f;
					}
				}
			}
			bool flag = false;
			bool flag2 = true;
			if (type == 47 || type == 67 || type == 109 || type == 110 || type == 111 || type == 120 || type == 154)
			{
				flag2 = false;
			}
			if ((type != 110 && type != 111) || !(ai2 > 0f))
			{
				if (velocity.Y == 0f && ((velocity.X > 0f && direction < 0) || (velocity.X < 0f && direction > 0)))
				{
					flag = true;
				}
				if (position.X == oldPosition.X || ai3 >= (float)num || flag)
				{
					ai3 += 1f;
				}
				else if ((double)Math.Abs(velocity.X) > 0.9 && ai3 > 0f)
				{
					ai3 -= 1f;
				}
				if (ai3 > (float)(num * 10))
				{
					ai3 = 0f;
				}
				if (justHit)
				{
					ai3 = 0f;
				}
				if (ai3 == (float)num)
				{
					netUpdate = true;
				}
			}
			if (ai3 < (float)num && (!Main.gameTime.dayTime || aabb.Y > Main.worldSurfacePixels || type == 26 || type == 27 || type == 28 || type == 31 || type == 47 || type == 67 || type == 73 || type == 77 || type == 78 || type == 79 || type == 80 || type == 110 || type == 111 || type == 120 || type == 152 || type == 154 || type == 155))
			{
				if (type == 3 || type == 21 || type == 31 || type == 77 || type == 110 || type == 132)
				{
					if (Main.rand.Next(1000) == 0)
					{
						Main.PlaySound(14, aabb.X, aabb.Y);
					}
				}
				else if ((type == 78 || type == 79 || type == 80 || type == 152 || type == 155) && Main.rand.Next(500) == 0)
				{
					Main.PlaySound(26, aabb.X, aabb.Y);
				}
				TargetClosest();
			}
			else if ((type != 110 && type != 111) || !(ai2 > 0f))
			{
				if (Main.gameTime.dayTime && aabb.Y >> 4 < Main.worldSurface && timeLeft > 10)
				{
					timeLeft = 10;
				}
				if (velocity.X == 0f)
				{
					if (velocity.Y == 0f)
					{
						ai0 += 1f;
						if (ai0 >= 2f)
						{
							direction = (sbyte)(-direction);
							spriteDirection = direction;
							ai0 = 0f;
						}
					}
				}
				else
				{
					ai0 = 0f;
				}
				if (direction == 0)
				{
					direction = 1;
				}
			}
			if (type == 120)
			{
				if (velocity.X < -3f || velocity.X > 3f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.8f;
					}
				}
				else if (velocity.X < 3f && direction == 1)
				{
					if (velocity.Y == 0f && velocity.X < 0f)
					{
						velocity.X *= 0.99f;
					}
					velocity.X += 0.07f;
					if (velocity.X > 3f)
					{
						velocity.X = 3f;
					}
				}
				else if (velocity.X > -3f && direction == -1)
				{
					if (velocity.Y == 0f && velocity.X > 0f)
					{
						velocity.X *= 0.99f;
					}
					velocity.X -= 0.07f;
					if (velocity.X < -3f)
					{
						velocity.X = -3f;
					}
				}
			}
			else if (type == 27 || type == 77 || type == 104)
			{
				if (velocity.X < -2f || velocity.X > 2f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.8f;
					}
				}
				else if (velocity.X < 2f && direction == 1)
				{
					velocity.X += 0.07f;
					if (velocity.X > 2f)
					{
						velocity.X = 2f;
					}
				}
				else if (velocity.X > -2f && direction == -1)
				{
					velocity.X -= 0.07f;
					if (velocity.X < -2f)
					{
						velocity.X = -2f;
					}
				}
			}
			else if (type == 109)
			{
				if (velocity.X < -2f || velocity.X > 2f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.8f;
					}
				}
				else if (velocity.X < 2f && direction == 1)
				{
					velocity.X += 0.04f;
					if (velocity.X > 2f)
					{
						velocity.X = 2f;
					}
				}
				else if (velocity.X > -2f && direction == -1)
				{
					velocity.X -= 0.04f;
					if (velocity.X < -2f)
					{
						velocity.X = -2f;
					}
				}
			}
			else if (type == 21 || type == 26 || type == 31 || type == 47 || type == 73 || type == 140)
			{
				if (velocity.X < -1.5f || velocity.X > 1.5f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.8f;
					}
				}
				else if (velocity.X < 1.5f && direction == 1)
				{
					velocity.X += 0.07f;
					if (velocity.X > 1.5f)
					{
						velocity.X = 1.5f;
					}
				}
				else if (velocity.X > -1.5f && direction == -1)
				{
					velocity.X -= 0.07f;
					if (velocity.X < -1.5f)
					{
						velocity.X = -1.5f;
					}
				}
			}
			else if (type == 67)
			{
				if (velocity.X < -0.5f || velocity.X > 0.5f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.7f;
					}
				}
				else if (velocity.X < 0.5f && direction == 1)
				{
					velocity.X += 0.03f;
					if (velocity.X > 0.5f)
					{
						velocity.X = 0.5f;
					}
				}
				else if (velocity.X > -0.5f && direction == -1)
				{
					velocity.X -= 0.03f;
					if (velocity.X < -0.5f)
					{
						velocity.X = -0.5f;
					}
				}
			}
			else if (type == 78 || type == 79 || type == 80 || type == 152 || type == 155)
			{
				float num5 = 1f;
				float num6 = 0.05f;
				if (life < lifeMax >> 1)
				{
					num5 = 2f;
					num6 = 0.1f;
				}
				if (type == 79 || type == 152)
				{
					num5 *= 1.5f;
				}
				if (velocity.X < 0f - num5 || velocity.X > num5)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.7f;
					}
				}
				else if (velocity.X < num5 && direction == 1)
				{
					velocity.X += num6;
					if (velocity.X > num5)
					{
						velocity.X = num5;
					}
				}
				else if (velocity.X > 0f - num5 && direction == -1)
				{
					velocity.X -= num6;
					if (velocity.X < 0f - num5)
					{
						velocity.X = 0f - num5;
					}
				}
			}
			else if (type != 110 && type != 111)
			{
				if (velocity.X < -1f || velocity.X > 1f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.8f;
					}
				}
				else if (velocity.X < 1f && direction == 1)
				{
					velocity.X += 0.07f;
					if (velocity.X > 1f)
					{
						velocity.X = 1f;
					}
				}
				else if (velocity.X > -1f && direction == -1)
				{
					velocity.X -= 0.07f;
					if (velocity.X < -1f)
					{
						velocity.X = -1f;
					}
				}
			}
			if (type == 110 || type == 111)
			{
				if (confused)
				{
					ai2 = 0f;
				}
				else
				{
					if (ai1 > 0f)
					{
						ai1 -= 1f;
					}
					if (justHit)
					{
						ai1 = 30f;
						ai2 = 0f;
					}
					int num7 = (type == 111) ? 180 : 70;
					if (ai2 > 0f)
					{
						TargetClosest();
						if (ai1 == (float)(num7 >> 1))
						{
							float num8 = 11f;
							int num9 = 35;
							int num10 = 82;
							if (type == 111)
							{
								num8 = 9f;
								num9 = 11;
								num10 = 81;
							}
							Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
							float num11 = Main.player[target].position.X + 10f - vector2.X;
							float num12 = Math.Abs(num11) * 0.1f;
							float num13 = Main.player[target].position.Y + 21f - vector2.Y - num12;
							num11 += (float)Main.rand.Next(-40, 41);
							num13 += (float)Main.rand.Next(-40, 41);
							float num14 = (float)Math.Sqrt(num11 * num11 + num13 * num13);
							netUpdate = true;
							num14 = num8 / num14;
							num11 *= num14;
							num13 *= num14;
							vector2.X += num11;
							vector2.Y += num13;
							if (Main.netMode != 1)
							{
								Projectile.NewProjectile(vector2.X, vector2.Y, num11, num13, num10, num9, 0f);
							}
							if (Math.Abs(num13) > Math.Abs(num11) * 2f)
							{
								if (num13 > 0f)
								{
									ai2 = 1f;
								}
								else
								{
									ai2 = 5f;
								}
							}
							else if (Math.Abs(num11) > Math.Abs(num13) * 2f)
							{
								ai2 = 3f;
							}
							else if (num13 > 0f)
							{
								ai2 = 2f;
							}
							else
							{
								ai2 = 4f;
							}
						}
						if (velocity.Y != 0f || ai1 <= 0f)
						{
							ai1 = 0f;
							ai2 = 0f;
						}
						else
						{
							velocity.X *= 0.9f;
							spriteDirection = direction;
						}
					}
					if (ai2 <= 0f && velocity.Y == 0f && ai1 <= 0f && !Main.player[target].dead && Collision.CanHit(ref aabb, ref Main.player[target].aabb))
					{
						Vector2 vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num15 = Main.player[target].position.X + 10f - vector3.X;
						float num16 = Math.Abs(num15) * 0.1f;
						float num17 = Main.player[target].position.Y + 21f - vector3.Y - num16;
						num15 += (float)Main.rand.Next(-40, 41);
						num17 += (float)Main.rand.Next(-40, 41);
						float num18 = num15 * num15 + num17 * num17;
						if (num18 < 490000f)
						{
							netUpdate = true;
							velocity.X *= 0.5f;
							num18 = 10f / (float)Math.Sqrt(num18);
							num15 *= num18;
							num17 *= num18;
							ai2 = 3f;
							ai1 = num7;
							if (Math.Abs(num17) > Math.Abs(num15) * 2f)
							{
								if (num17 > 0f)
								{
									ai2 = 1f;
								}
								else
								{
									ai2 = 5f;
								}
							}
							else if (Math.Abs(num15) > Math.Abs(num17) * 2f)
							{
								ai2 = 3f;
							}
							else if (num17 > 0f)
							{
								ai2 = 2f;
							}
							else
							{
								ai2 = 4f;
							}
						}
					}
					if (ai2 <= 0f)
					{
						if (velocity.X < -1f || velocity.X > 1f)
						{
							if (velocity.Y == 0f)
							{
								velocity.X *= 0.8f;
							}
						}
						else if (velocity.X < 1f && direction == 1)
						{
							velocity.X += 0.07f;
							if (velocity.X > 1f)
							{
								velocity.X = 1f;
							}
						}
						else if (velocity.X > -1f && direction == -1)
						{
							velocity.X -= 0.07f;
							if (velocity.X < -1f)
							{
								velocity.X = -1f;
							}
						}
					}
				}
			}
			else if (type == 109 && Main.netMode != 1 && !Main.player[target].dead)
			{
				if (justHit)
				{
					ai2 = 0f;
				}
				ai2 += 1f;
				if (ai2 > 450f)
				{
					Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f - (float)(direction * 24), position.Y + 4f);
					int num19 = 3 * direction;
					int num20 = -5;
					int num21 = Projectile.NewProjectile(vector4.X, vector4.Y, num19, num20, 75, 0, 0f);
					if (num21 >= 0)
					{
						Main.projectile[num21].timeLeft = 300;
					}
					ai2 = 0f;
				}
			}
			bool flag3 = false;
			if (velocity.Y == 0f)
			{
				int num22 = aabb.Y + height + 8 >> 4;
				int num23 = aabb.X >> 4;
				int num24 = aabb.X + width >> 4;
				for (int k = num23; k <= num24; k++)
				{
					if (Main.tile[k, num22].active != 0 && Main.tileSolid[Main.tile[k, num22].type])
					{
						flag3 = true;
						break;
					}
				}
			}
			if (flag3)
			{
				int num25 = aabb.Y + height - 15 >> 4;
				int num26 = (type != 109) ? (aabb.X + (width >> 1) + 15 * direction) : (aabb.X + (width >> 1) + ((width >> 1) + 16) * direction);
				num26 >>= 4;
				if (flag2 && Main.tile[num26, num25 - 1].type == 10 && Main.tile[num26, num25 - 1].active != 0)
				{
					ai2 += 1f;
					ai3 = 0f;
					if (ai2 >= 60f)
					{
						if (!Main.gameTime.bloodMoon && (type == 3 || type == 132))
						{
							ai1 = 0f;
						}
						velocity.X = -0.5f * (float)direction;
						ai1 += 1f;
						if (type == 27)
						{
							ai1 += 1f;
						}
						else if (type == 31)
						{
							ai1 += 6f;
						}
						ai2 = 0f;
						bool flag4 = false;
						if (ai1 >= 10f)
						{
							flag4 = true;
							ai1 = 10f;
						}
						WorldGen.KillTile(num26, num25 - 1, fail: true);
						if ((Main.netMode != 1 || !flag4) && flag4 && Main.netMode != 1)
						{
							if (type == 26)
							{
								WorldGen.KillTile(num26, num25 - 1);
								NetMessage.CreateMessage5(17, 0, num26, num25 - 1, 0);
								NetMessage.SendMessage();
							}
							else
							{
								int num27 = WorldGen.OpenDoor(num26, num25, direction);
								if (num27 != 0)
								{
									NetMessage.CreateMessage3(19, num26, num25, num27);
									NetMessage.SendMessage();
								}
								else
								{
									ai3 = num;
									netUpdate = true;
								}
							}
						}
					}
				}
				else
				{
					if ((velocity.X < 0f && spriteDirection == -1) || (velocity.X > 0f && spriteDirection == 1))
					{
						if (Main.tile[num26, num25 - 2].active != 0 && Main.tileSolid[Main.tile[num26, num25 - 2].type])
						{
							if (Main.tile[num26, num25 - 3].active != 0 && Main.tileSolid[Main.tile[num26, num25 - 3].type])
							{
								velocity.Y = -8f;
							}
							else
							{
								velocity.Y = -7f;
							}
							netUpdate = true;
						}
						else if (Main.tile[num26, num25 - 1].active != 0 && Main.tileSolid[Main.tile[num26, num25 - 1].type])
						{
							velocity.Y = -6f;
							netUpdate = true;
						}
						else if (Main.tile[num26, num25].active != 0 && Main.tileSolid[Main.tile[num26, num25].type])
						{
							velocity.Y = -5f;
							netUpdate = true;
						}
						else if (directionY < 0 && type != 67 && (Main.tile[num26, num25 + 1].active == 0 || !Main.tileSolid[Main.tile[num26, num25 + 1].type]) && (Main.tile[num26 + direction, num25 + 1].active == 0 || !Main.tileSolid[Main.tile[num26 + direction, num25 + 1].type]))
						{
							velocity.Y = -8f;
							velocity.X *= 1.5f;
							netUpdate = true;
						}
						else if (flag2)
						{
							ai1 = 0f;
							ai2 = 0f;
						}
					}
					if (type == 31 || type == 47 || type == 77 || type == 104)
					{
						if (velocity.Y == 0f && Math.Abs(position.X + (float)(width >> 1) - (Main.player[target].position.X + 10f)) < 100f && Math.Abs(position.Y + (float)(height >> 1) - (Main.player[target].position.Y + 21f)) < 50f && ((direction > 0 && velocity.X >= 1f) || (direction < 0 && velocity.X <= -1f)))
						{
							velocity.X *= 2f;
							if (velocity.X > 3f)
							{
								velocity.X = 3f;
							}
							if (velocity.X < -3f)
							{
								velocity.X = -3f;
							}
							velocity.Y = -4f;
							netUpdate = true;
						}
					}
					else if ((type == 120 || type == 154) && velocity.Y < 0f)
					{
						velocity.Y *= 1.1f;
					}
				}
			}
			else if (flag2)
			{
				ai1 = 0f;
				ai2 = 0f;
			}
			if ((type != 120 && type != 154) || Main.netMode == 1 || !(ai3 >= (float)num))
			{
				return;
			}
			int num28 = Main.player[target].aabb.X >> 4;
			int num29 = Main.player[target].aabb.Y >> 4;
			int num30 = aabb.X >> 4;
			int num31 = aabb.Y >> 4;
			if (Math.Abs(aabb.X - Main.player[target].aabb.X) + Math.Abs(aabb.Y - Main.player[target].aabb.Y) > 2000)
			{
				return;
			}
			int num32 = 0;
			do
			{
				int num33 = Main.rand.Next(num28 - 20, num28 + 20);
				int num34 = Main.rand.Next(num29 - 20, num29 + 20);
				for (int l = num34; l < num29 + 20; l++)
				{
					if ((l < num29 - 4 || l > num29 + 4 || num33 < num28 - 4 || num33 > num28 + 4) && (l < num31 - 1 || l > num31 + 1 || num33 < num30 - 1 || num33 > num30 + 1) && Main.tile[num33, l].active != 0 && (type != 32 || Main.tile[num33, l - 1].wall != 0) && Main.tile[num33, l - 1].lava == 0 && Main.tileSolid[Main.tile[num33, l].type] && !Collision.SolidTiles(num33 - 1, num33 + 1, l - 4, l - 1))
					{
						position.X = (aabb.X = num33 * 16 - (width >> 1));
						position.Y = (aabb.Y = l * 16 - height);
						netUpdate = true;
						ai3 = -120f;
						num32 = 32;
						break;
					}
				}
			}
			while (++num32 < 32);
		}

		private unsafe void EyeOfCthulhuAI()
		{
			if (target == 8 || Main.player[target].dead || Main.player[target].active == 0)
			{
				TargetClosest();
			}
			bool dead = Main.player[target].dead;
			float num = position.X + (float)(width >> 1) - Main.player[target].position.X - 10f;
			float num2 = position.Y + (float)(int)height - 59f - Main.player[target].position.Y - 21f;
			float num3 = (float)Math.Atan2(num2, num) + 1.57f;
			if (num3 < 0f)
			{
				num3 += 6.283f;
			}
			else if (num3 > 6.283f)
			{
				num3 -= 6.283f;
			}
			float num4 = 0f;
			if (ai0 == 0f && ai1 == 0f)
			{
				num4 = 0.02f;
			}
			if (ai0 == 0f && ai1 == 2f && ai2 > 40f)
			{
				num4 = 0.05f;
			}
			if (ai0 == 3f && ai1 == 0f)
			{
				num4 = 0.05f;
			}
			if (ai0 == 3f && ai1 == 2f && ai2 > 40f)
			{
				num4 = 0.08f;
			}
			if (rotation < num3)
			{
				if ((double)(num3 - rotation) > 3.1415)
				{
					rotation -= num4;
				}
				else
				{
					rotation += num4;
				}
			}
			else if (rotation > num3)
			{
				if ((double)(rotation - num3) > 3.1415)
				{
					rotation += num4;
				}
				else
				{
					rotation -= num4;
				}
			}
			if (rotation > num3 - num4 && rotation < num3 + num4)
			{
				rotation = num3;
			}
			if (rotation < 0f)
			{
				rotation += 6.283f;
			}
			else if (rotation > 6.283f)
			{
				rotation -= 6.283f;
			}
			if (rotation > num3 - num4 && rotation < num3 + num4)
			{
				rotation = num3;
			}
			if (Main.rand.Next(6) == 0)
			{
				Dust* ptr = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 5, velocity.X, 2.0);
				if (ptr != null)
				{
					ptr->velocity.X *= 0.5f;
					ptr->velocity.Y *= 0.1f;
				}
			}
			if (Main.gameTime.dayTime || dead)
			{
				velocity.Y -= 0.04f;
				if (timeLeft > 10)
				{
					timeLeft = 10;
				}
				return;
			}
			if (ai0 == 0f)
			{
				if (ai1 == 0f)
				{
					float num5 = 5f;
					float num6 = 0.04f;
					Vector2 vector = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
					float num7 = Main.player[target].position.X + 10f - vector.X;
					float num8 = Main.player[target].position.Y + 21f - 200f - vector.Y;
					float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
					float num10 = num9;
					num9 = num5 / num9;
					num7 *= num9;
					num8 *= num9;
					if (velocity.X < num7)
					{
						velocity.X += num6;
						if (velocity.X < 0f && num7 > 0f)
						{
							velocity.X += num6;
						}
					}
					else if (velocity.X > num7)
					{
						velocity.X -= num6;
						if (velocity.X > 0f && num7 < 0f)
						{
							velocity.X -= num6;
						}
					}
					if (velocity.Y < num8)
					{
						velocity.Y += num6;
						if (velocity.Y < 0f && num8 > 0f)
						{
							velocity.Y += num6;
						}
					}
					else if (velocity.Y > num8)
					{
						velocity.Y -= num6;
						if (velocity.Y > 0f && num8 < 0f)
						{
							velocity.Y -= num6;
						}
					}
					ai2 += 1f;
					if (ai2 >= 600f)
					{
						ai1 = 1f;
						ai2 = 0f;
						ai3 = 0f;
						target = 8;
						netUpdate = true;
					}
					else if (aabb.Y + height < Main.player[target].aabb.Y && num10 < 500f)
					{
						if (!Main.player[target].dead)
						{
							ai3 += 1f;
						}
						if (ai3 >= 110f)
						{
							ai3 = 0f;
							rotation = num3;
							float num11 = Main.player[target].position.X + 10f - vector.X;
							float num12 = Main.player[target].position.Y + 21f - vector.Y;
							float num13 = (float)Math.Sqrt(num11 * num11 + num12 * num12);
							num13 = 5f / num13;
							Vector2 vector2 = vector;
							Vector2 vector3 = default(Vector2);
							vector3.X = num11 * num13;
							vector3.Y = num12 * num13;
							vector2.X += vector3.X * 10f;
							vector2.Y += vector3.Y * 10f;
							if (Main.netMode != 1)
							{
								int num14 = NewNPC((int)vector2.X, (int)vector2.Y, 5);
								if (num14 < 196)
								{
									Main.npc[num14].velocity.X = vector3.X;
									Main.npc[num14].velocity.Y = vector3.Y;
									NetMessage.CreateMessage1(23, num14);
									NetMessage.SendMessage();
								}
							}
							Main.PlaySound(3, (int)vector2.X, (int)vector2.Y);
							for (int i = 0; i < 8; i++)
							{
								if (null == Main.dust.NewDust((int)vector2.X, (int)vector2.Y, 20, 20, 5, vector3.X * 0.4f, vector3.Y * 0.4f))
								{
									break;
								}
							}
						}
					}
				}
				else if (ai1 == 1f)
				{
					rotation = num3;
					float num15 = 6f;
					Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num16 = Main.player[target].position.X + 10f - vector4.X;
					float num17 = Main.player[target].position.Y + 21f - vector4.Y;
					float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
					num18 = num15 / num18;
					velocity.X = num16 * num18;
					velocity.Y = num17 * num18;
					ai1 = 2f;
				}
				else if (ai1 == 2f)
				{
					ai2 += 1f;
					if (ai2 >= 40f)
					{
						velocity.X *= 0.98f;
						velocity.Y *= 0.98f;
						if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
						{
							velocity.X = 0f;
						}
						if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
						{
							velocity.Y = 0f;
						}
					}
					else
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
					}
					if (ai2 >= 150f)
					{
						ai3 += 1f;
						ai2 = 0f;
						target = 8;
						rotation = num3;
						if (ai3 >= 3f)
						{
							ai1 = 0f;
							ai3 = 0f;
						}
						else
						{
							ai1 = 1f;
						}
					}
				}
				if (life < lifeMax >> 1)
				{
					ai0 = 1f;
					ai1 = 0f;
					ai2 = 0f;
					ai3 = 0f;
					netUpdate = true;
				}
				return;
			}
			if (ai0 == 1f || ai0 == 2f)
			{
				if (ai0 == 1f)
				{
					ai2 += 0.005f;
					if ((double)ai2 > 0.5)
					{
						ai2 = 0.5f;
					}
				}
				else
				{
					ai2 -= 0.005f;
					if (ai2 < 0f)
					{
						ai2 = 0f;
					}
				}
				rotation += ai2;
				ai1 += 1f;
				if (ai1 == 100f)
				{
					ai0 += 1f;
					ai1 = 0f;
					if (ai0 == 3f)
					{
						ai2 = 0f;
					}
					else
					{
						Main.PlaySound(3, aabb.X, aabb.Y);
						Main.PlaySound(15, aabb.X, aabb.Y, 0);
						for (int j = 0; j < 2; j++)
						{
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 8);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6);
						}
						for (int k = 0; k < 16; k++)
						{
							if (null == Main.dust.NewDust(5, ref aabb, (double)Main.rand.Next(-30, 31) * 0.2, (double)Main.rand.Next(-30, 31) * 0.2))
							{
								break;
							}
						}
					}
				}
				Main.dust.NewDust(5, ref aabb, (double)Main.rand.Next(-30, 31) * 0.2, (double)Main.rand.Next(-30, 31) * 0.2);
				velocity.X *= 0.98f;
				velocity.Y *= 0.98f;
				if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
				{
					velocity.X = 0f;
				}
				if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
				{
					velocity.Y = 0f;
				}
				return;
			}
			damage = 23;
			defense = 0;
			if (ai1 == 0f)
			{
				float num19 = 6f;
				float num20 = 0.07f;
				Vector2 vector5 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num21 = Main.player[target].position.X + 10f - vector5.X;
				float num22 = Main.player[target].position.Y + 21f - 120f - vector5.Y;
				float num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);
				num23 = num19 / num23;
				num21 *= num23;
				num22 *= num23;
				if (velocity.X < num21)
				{
					velocity.X += num20;
					if (velocity.X < 0f && num21 > 0f)
					{
						velocity.X += num20;
					}
				}
				else if (velocity.X > num21)
				{
					velocity.X -= num20;
					if (velocity.X > 0f && num21 < 0f)
					{
						velocity.X -= num20;
					}
				}
				if (velocity.Y < num22)
				{
					velocity.Y += num20;
					if (velocity.Y < 0f && num22 > 0f)
					{
						velocity.Y += num20;
					}
				}
				else if (velocity.Y > num22)
				{
					velocity.Y -= num20;
					if (velocity.Y > 0f && num22 < 0f)
					{
						velocity.Y -= num20;
					}
				}
				ai2 += 1f;
				if (ai2 >= 200f)
				{
					ai1 = 1f;
					ai2 = 0f;
					ai3 = 0f;
					target = 8;
					netUpdate = true;
				}
			}
			else if (ai1 == 1f)
			{
				Main.PlaySound(15, aabb.X, aabb.Y, 0);
				rotation = num3;
				float num24 = 6.8f;
				Vector2 vector6 = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
				float num25 = Main.player[target].position.X + 10f - vector6.X;
				float num26 = Main.player[target].position.Y + 21f - vector6.Y;
				float num27 = (float)Math.Sqrt(num25 * num25 + num26 * num26);
				num27 = num24 / num27;
				velocity.X = num25 * num27;
				velocity.Y = num26 * num27;
				ai1 = 2f;
			}
			else
			{
				if (ai1 != 2f)
				{
					return;
				}
				ai2 += 1f;
				if (ai2 >= 40f)
				{
					velocity.X *= 0.97f;
					velocity.Y *= 0.97f;
					if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
					{
						velocity.X = 0f;
					}
					if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
					{
						velocity.Y = 0f;
					}
				}
				else
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
				}
				if (ai2 >= 130f)
				{
					ai3 += 1f;
					ai2 = 0f;
					target = 8;
					rotation = num3;
					if (ai3 >= 3f)
					{
						ai1 = 0f;
						ai3 = 0f;
					}
					else
					{
						ai1 = 1f;
					}
				}
			}
		}

		private unsafe void AggressiveFlyerAI()
		{
			if (target == 8 || Main.player[target].dead)
			{
				TargetClosest();
			}
			float num;
			float num2;
			switch (type)
			{
			case 5:
				num = 5f;
				num2 = 0.03f;
				break;
			case 167:
				Lighting.addLight(aabb.X >> 4, aabb.Y >> 4, new Vector3(1f, 1f, 1f));
				num = 9f;
				num2 = 0.1f;
				break;
			case 6:
				num = 4f;
				num2 = 0.02f;
				break;
			case 42:
			case 157:
				num = 3.5f;
				num2 = 0.021f;
				break;
			case 23:
				num = 1f;
				num2 = 0.03f;
				break;
			case 94:
				num = 4.2f;
				num2 = 0.022f;
				break;
			default:
				num = 6f;
				num2 = 0.05f;
				break;
			}
			int num3 = (aabb.X + (width >> 1)) & -8;
			int num4 = (aabb.Y + (height >> 1)) & -8;
			float num5 = ((Main.player[target].aabb.X + 10) & -8) - num3;
			float num6 = ((Main.player[target].aabb.Y + 21) & -8) - num4;
			float num7 = num5 * num5 + num6 * num6;
			float num8 = num7;
			bool flag = false;
			if (num7 == 0f)
			{
				num5 = velocity.X;
				num6 = velocity.Y;
			}
			else
			{
				if (num7 > 360000f)
				{
					flag = true;
				}
				num7 = num / (float)Math.Sqrt(num7);
				num5 *= num7;
				num6 *= num7;
			}
			if (type == 6 || type == 42 || type == 157 || type == 94 || type == 139)
			{
				if (type == 42 || type == 157 || type == 94 || num8 > 10000f)
				{
					ai0 += 1f;
					if (ai0 > 0f)
					{
						velocity.Y += 0.023f;
					}
					else
					{
						velocity.Y -= 0.023f;
					}
					if (ai0 < -100f || ai0 > 100f)
					{
						velocity.X += 0.023f;
					}
					else
					{
						velocity.X -= 0.023f;
					}
					if (ai0 > 200f)
					{
						ai0 = -200f;
					}
				}
				if ((type == 6 || type == 94) && num8 < 22500f)
				{
					velocity.X += num5 * 0.007f;
					velocity.Y += num6 * 0.007f;
				}
			}
			if (Main.player[target].dead)
			{
				num5 = (float)direction * num * 0.5f;
				num6 = num * -0.5f;
			}
			if (velocity.X < num5)
			{
				velocity.X += num2;
				if (velocity.X < 0f && num5 > 0f && type != 6 && type != 42 && type != 157 && type != 94 && type != 139)
				{
					velocity.X += num2;
				}
			}
			else if (velocity.X > num5)
			{
				velocity.X -= num2;
				if (velocity.X > 0f && num5 < 0f && type != 6 && type != 42 && type != 157 && type != 94 && type != 139)
				{
					velocity.X -= num2;
				}
			}
			if (velocity.Y < num6)
			{
				velocity.Y += num2;
				if (velocity.Y < 0f && num6 > 0f && type != 6 && type != 42 && type != 157 && type != 94 && type != 139)
				{
					velocity.Y += num2;
				}
			}
			else if (velocity.Y > num6)
			{
				velocity.Y -= num2;
				if (velocity.Y > 0f && num6 < 0f && type != 6 && type != 42 && type != 157 && type != 94 && type != 139)
				{
					velocity.Y -= num2;
				}
			}
			if (type == 23)
			{
				if (num5 > 0f)
				{
					spriteDirection = 1;
					rotation = (float)Math.Atan2(num6, num5);
				}
				else if (num5 < 0f)
				{
					spriteDirection = -1;
					rotation = (float)Math.Atan2(num6, num5) + 3.14f;
				}
			}
			else if (type == 139)
			{
				if (justHit)
				{
					localAI0 = 0;
				}
				else if (++localAI0 >= 120 && Main.netMode != 1)
				{
					localAI0 = 0;
					if (Collision.CanHit(ref aabb, ref Main.player[target].aabb))
					{
						int num9 = 25;
						int num10 = 84;
						Projectile.NewProjectile(num3, num4, num5, num6, num10, num9, 0f);
					}
				}
				int num11 = aabb.X + (width >> 1);
				int num12 = aabb.Y + (height >> 1);
				num11 >>= 4;
				num12 >>= 4;
				if (!WorldGen.SolidTile(num11, num12))
				{
					Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, new Vector3(0.3f, 0.1f, 0.05f));
				}
				if (num5 > 0f)
				{
					spriteDirection = 1;
					rotation = (float)Math.Atan2(num6, num5);
				}
				if (num5 < 0f)
				{
					spriteDirection = -1;
					rotation = (float)Math.Atan2(num6, num5) + 3.14f;
				}
			}
			else if (type == 6 || type == 94)
			{
				rotation = (float)Math.Atan2(num6, num5) - 1.57f;
			}
			else if (type == 42 || type == 157)
			{
				if (num5 > 0f)
				{
					spriteDirection = 1;
				}
				else if (num5 < 0f)
				{
					spriteDirection = -1;
				}
				rotation = velocity.X * 0.1f;
			}
			else
			{
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
			}
			if (type == 6 || type == 23 || type == 42 || type == 157 || type == 94 || type == 139)
			{
				float num13 = 0.7f;
				if (type == 6)
				{
					num13 = 0.4f;
				}
				if (collideX)
				{
					netUpdate = true;
					velocity.X = oldVelocity.X * (0f - num13);
					if (direction == -1 && velocity.X > 0f && velocity.X < 2f)
					{
						velocity.X = 2f;
					}
					else if (direction == 1 && velocity.X < 0f && velocity.X > -2f)
					{
						velocity.X = -2f;
					}
				}
				if (collideY)
				{
					netUpdate = true;
					velocity.Y = oldVelocity.Y * (0f - num13);
					if (velocity.Y > 0f && (double)velocity.Y < 1.5)
					{
						velocity.Y = 2f;
					}
					else if (velocity.Y < 0f && (double)velocity.Y > -1.5)
					{
						velocity.Y = -2f;
					}
				}
				if (type == 23)
				{
					Dust* ptr = Main.dust.NewDust((int)(position.X - velocity.X), (int)(position.Y - velocity.Y), width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
					if (ptr != null)
					{
						ptr->noGravity = true;
						ptr->velocity.X *= 0.3f;
						ptr->velocity.Y *= 0.3f;
					}
				}
				else if (type != 42 && type != 157 && type != 139 && Main.rand.Next(24) == 0)
				{
					Dust* ptr2 = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 18, velocity.X, 2.0, 75, color, scale);
					if (ptr2 != null)
					{
						ptr2->velocity.X *= 0.5f;
						ptr2->velocity.Y *= 0.1f;
					}
				}
			}
			else if (Main.rand.Next(48) == 0)
			{
				Dust* ptr3 = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 5, velocity.X, 2.0);
				if (ptr3 != null)
				{
					ptr3->velocity.X *= 0.5f;
					ptr3->velocity.Y *= 0.1f;
				}
			}
			if (type == 6 || type == 94)
			{
				if (wet)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.95f;
					}
					velocity.Y -= 0.3f;
					if (velocity.Y < -2f)
					{
						velocity.Y = -2f;
					}
				}
			}
			else if (type == 42 || type == 157)
			{
				if (wet)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.95f;
					}
					velocity.Y -= 0.5f;
					if (velocity.Y < -4f)
					{
						velocity.Y = -4f;
					}
					TargetClosest();
				}
				if (ai1 == 101f)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 17);
					ai1 = 0f;
				}
				if (Main.netMode != 1)
				{
					ai1 += (float)Main.rand.Next(5, 20) * 0.1f * scale;
					if (ai1 >= 130f)
					{
						if (Collision.CanHit(ref aabb, ref Main.player[target].aabb))
						{
							Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(height >> 1));
							float num14 = Main.player[target].position.X + 10f - vector.X + (float)Main.rand.Next(-20, 21);
							float num15 = Main.player[target].position.Y + 21f - vector.Y + (float)Main.rand.Next(-20, 21);
							if ((num14 < 0f && velocity.X < 0f) || (num14 > 0f && velocity.X > 0f))
							{
								float num16 = (float)Math.Sqrt(num14 * num14 + num15 * num15);
								num16 = 8f / num16;
								num14 *= num16;
								num15 *= num16;
								int num17 = (int)(13f * scale);
								int num18 = 55;
								int num19 = Projectile.NewProjectile(vector.X, vector.Y, num14, num15, num18, num17, 0f);
								if (num19 >= 0)
								{
									Main.projectile[num19].timeLeft = 300;
								}
								ai1 = 101f;
								netUpdate = true;
							}
							else
							{
								ai1 = 0f;
							}
						}
						else
						{
							ai1 = 0f;
						}
					}
				}
			}
			else if (type == 139 && flag)
			{
				if ((velocity.X > 0f && num5 > 0f) || (velocity.X < 0f && num5 < 0f))
				{
					if (Math.Abs(velocity.X) < 12f)
					{
						velocity.X *= 1.05f;
					}
				}
				else
				{
					velocity.X *= 0.9f;
				}
			}
			if (Main.netMode != 1 && type == 94 && !Main.player[target].dead)
			{
				if (justHit)
				{
					localAI0 = 0;
				}
				localAI0++;
				if (localAI0 == 180)
				{
					if (Collision.CanHit(ref aabb, ref Main.player[target].aabb))
					{
						NewNPC((int)(position.X + velocity.X) + (width >> 1), (int)(position.Y + velocity.Y) + (height >> 1), 112);
					}
					localAI0 = 0;
				}
			}
			if ((Main.gameTime.dayTime && type != 6 && type != 23 && type != 42 && type != 157 && type != 94) || Main.player[target].dead)
			{
				velocity.Y -= num2 * 2f;
				if (timeLeft > 10)
				{
					timeLeft = 10;
				}
			}
			if (((velocity.X > 0f && oldVelocity.X < 0f) || (velocity.X < 0f && oldVelocity.X > 0f) || (velocity.Y > 0f && oldVelocity.Y < 0f) || (velocity.Y < 0f && oldVelocity.Y > 0f)) && !justHit)
			{
				netUpdate = true;
			}
		}

		private unsafe void WormAI()
		{
			if (type == 117 && localAI1 == 0)
			{
				localAI1 = 1;
				Main.PlaySound(4, aabb.X, aabb.Y, 13);
				int num = 1;
				if (velocity.X < 0f)
				{
					num = -1;
				}
				for (int i = 0; i < 16; i++)
				{
					if (null == Main.dust.NewDust(aabb.X - 20, aabb.Y - 20, width + 40, height + 40, 5, num * 8, -1.0))
					{
						break;
					}
				}
			}
			if (type >= 13 && type <= 15)
			{
				realLife = -1;
			}
			else if (ai3 > 0f)
			{
				realLife = (int)ai3;
			}
			if (target == 8 || Main.player[target].dead)
			{
				TargetClosest();
			}
			if (Main.player[target].dead && timeLeft > 300)
			{
				timeLeft = 300;
			}
			if (Main.netMode != 1)
			{
				if (type == 87 || type == 159)
				{
					if (ai0 == 0f)
					{
						ai3 = whoAmI;
						realLife = whoAmI;
						int num2 = 0;
						int num3 = whoAmI;
						int num4 = type - 87;
						for (int j = 0; j < 14; j++)
						{
							int num5 = 89;
							switch (j)
							{
							case 1:
							case 8:
								num5 = 88;
								break;
							case 11:
								num5 = 90;
								break;
							case 12:
								num5 = 91;
								break;
							case 13:
								num5 = 92;
								break;
							}
							num2 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, num5 + num4, whoAmI);
							Main.npc[num2].ai3 = whoAmI;
							Main.npc[num2].realLife = whoAmI;
							Main.npc[num2].ai1 = num3;
							Main.npc[num3].ai0 = num2;
							NetMessage.CreateMessage1(23, num2);
							NetMessage.SendMessage();
							num3 = num2;
						}
					}
				}
				else if ((type == 7 || type == 8 || type == 10 || type == 11 || type == 13 || type == 14 || type == 39 || type == 40 || type == 95 || type == 96 || type == 98 || type == 99 || type == 117 || type == 118) && ai0 == 0f)
				{
					if (type == 7 || type == 10 || type == 13 || type == 39 || type == 95 || type == 98 || type == 117)
					{
						if (type < 13 || type > 15)
						{
							ai3 = whoAmI;
							realLife = whoAmI;
						}
						ai2 = Main.rand.Next(8, 13);
						if (type == 10)
						{
							ai2 = Main.rand.Next(4, 7);
						}
						else if (type == 13)
						{
							ai2 = Main.rand.Next(45, 56);
						}
						else if (type == 39)
						{
							ai2 = Main.rand.Next(12, 19);
						}
						else if (type == 95)
						{
							ai2 = Main.rand.Next(6, 12);
						}
						else if (type == 98)
						{
							ai2 = Main.rand.Next(20, 26);
						}
						else if (type == 117)
						{
							ai2 = Main.rand.Next(3, 6);
						}
						ai0 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, type + 1, whoAmI);
					}
					else if ((type == 8 || type == 11 || type == 14 || type == 40 || type == 96 || type == 99 || type == 118) && ai2 > 0f)
					{
						ai0 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, type, whoAmI);
					}
					else
					{
						ai0 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, type + 1, whoAmI);
					}
					if (type < 13 || type > 15)
					{
						Main.npc[(int)ai0].ai3 = ai3;
						Main.npc[(int)ai0].realLife = realLife;
					}
					Main.npc[(int)ai0].ai1 = whoAmI;
					Main.npc[(int)ai0].ai2 = ai2 - 1f;
					netUpdate = true;
				}
				if ((type == 8 || type == 9 || type == 11 || type == 12 || type == 40 || type == 41 || type == 96 || type == 97 || type == 99 || type == 100 || (type > 87 && type <= 92) || (type > 159 && type <= 164) || type == 118 || type == 119) && (Main.npc[(int)ai1].active == 0 || Main.npc[(int)ai1].aiStyle != aiStyle))
				{
					life = 0;
					HitEffect();
					active = 0;
					if (Main.netMode == 2)
					{
						NetMessage.SendNpcHurt(whoAmI, -1);
					}
					return;
				}
				if (type == 7 || type == 8 || type == 10 || type == 11 || type == 39 || type == 40 || type == 95 || type == 96 || type == 98 || type == 99 || (type >= 87 && type < 92) || (type >= 159 && type < 164) || type == 117 || type == 118)
				{
					if (Main.npc[(int)ai0].active == 0 || Main.npc[(int)ai0].aiStyle != aiStyle)
					{
						life = 0;
						HitEffect();
						active = 0;
						if (Main.netMode == 2)
						{
							NetMessage.SendNpcHurt(whoAmI, -1);
						}
						return;
					}
				}
				else if (type >= 13 && type <= 15)
				{
					if ((Main.npc[(int)ai1].active == 0 && Main.npc[(int)ai0].active == 0) || (type == 13 && Main.npc[(int)ai0].active == 0) || (type == 15 && Main.npc[(int)ai1].active == 0))
					{
						life = 0;
						HitEffect();
						active = 0;
					}
					if (type == 14)
					{
						if (Main.npc[(int)ai1].active == 0 || Main.npc[(int)ai1].aiStyle != aiStyle)
						{
							type = 13;
							int num6 = whoAmI;
							float num7 = (float)life / (float)lifeMax;
							float num8 = ai0;
							SetDefaults(type);
							life = (int)((float)lifeMax * num7);
							ai0 = num8;
							TargetClosest();
							netUpdate = true;
							whoAmI = (short)num6;
						}
						else if (Main.npc[(int)ai0].active == 0 || Main.npc[(int)ai0].aiStyle != aiStyle)
						{
							int num9 = whoAmI;
							float num10 = (float)life / (float)lifeMax;
							float num11 = ai1;
							SetDefaults(type);
							life = (int)((float)lifeMax * num10);
							ai1 = num11;
							TargetClosest();
							netUpdate = true;
							whoAmI = (short)num9;
						}
					}
					if (life == 0)
					{
						bool flag = true;
						for (int k = 0; k < 196; k++)
						{
							if (Main.npc[k].type >= 13 && Main.npc[k].type <= 15 && Main.npc[k].active != 0)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							boss = true;
							NPCLoot();
						}
					}
					if (active == 0)
					{
						NetMessage.SendNpcHurt(whoAmI, -1);
						return;
					}
				}
			}
			int num12 = (aabb.X >> 4) - 1;
			int num13 = (aabb.X + width >> 4) + 2;
			int num14 = (aabb.Y >> 4) - 1;
			int num15 = (aabb.Y + height >> 4) + 2;
			if (num12 < 0)
			{
				num12 = 0;
			}
			if (num13 > Main.maxTilesX)
			{
				num13 = Main.maxTilesX;
			}
			if (num14 < 0)
			{
				num14 = 0;
			}
			if (num15 > Main.maxTilesY)
			{
				num15 = Main.maxTilesY;
			}
			bool flag2 = (type >= 87 && type <= 92) || (type >= 159 && type <= 164);
			if (!flag2)
			{
				Vector2 vector = default(Vector2);
				for (int l = num12; l < num13; l++)
				{
					for (int m = num14; m < num15; m++)
					{
						if (!Main.tile[l, m].canStandOnTop() && Main.tile[l, m].liquid <= 64)
						{
							continue;
						}
						vector.X = l * 16;
						vector.Y = m * 16;
						if (position.X + (float)(int)width > vector.X && position.X < vector.X + 16f && position.Y + (float)(int)height > vector.Y && position.Y < vector.Y + 16f)
						{
							flag2 = true;
							if (Main.rand.Next(100) == 0 && type != 117 && Main.tile[l, m].active != 0)
							{
								WorldGen.KillTile(l, m, fail: true, effectOnly: true);
							}
						}
					}
				}
			}
			if (!flag2 && (type == 7 || type == 10 || type == 13 || type == 39 || type == 95 || type == 98 || type == 117))
			{
				bool flag3 = true;
				for (int n = 0; n < 8; n++)
				{
					if (Main.player[n].active != 0)
					{
						Rectangle rectangle = new Rectangle(Main.player[n].aabb.X - 1000, Main.player[n].aabb.Y - 1000, 2000, 2000);
						if (aabb.Intersects(rectangle))
						{
							flag3 = false;
							break;
						}
					}
				}
				if (flag3)
				{
					flag2 = true;
				}
			}
			if ((type >= 87 && type <= 92) || (type >= 159 && type <= 164))
			{
				if (velocity.X < 0f)
				{
					spriteDirection = 1;
				}
				else if (velocity.X > 0f)
				{
					spriteDirection = -1;
				}
			}
			float num16 = 8f;
			float num17 = 0.07f;
			if (type == 95)
			{
				num16 = 5.5f;
				num17 = 0.045f;
			}
			else if (type == 10)
			{
				num16 = 6f;
				num17 = 0.05f;
			}
			else if (type == 13)
			{
				num16 = 10f;
				num17 = 0.07f;
			}
			else if (type == 87 || type == 159)
			{
				num16 = 11f;
				num17 = 0.25f;
			}
			else if (type == 117 && wof >= 0)
			{
				float num18 = (float)Main.npc[wof].life / (float)Main.npc[wof].lifeMax;
				if ((double)num18 < 0.5)
				{
					num16 += 1f;
					num17 += 0.1f;
				}
				if ((double)num18 < 0.25)
				{
					num16 += 1f;
					num17 += 0.1f;
				}
				if ((double)num18 < 0.1)
				{
					num16 += 2f;
					num17 += 0.1f;
				}
			}
			Vector2 vector2 = position;
			vector2.X += width >> 1;
			vector2.Y += height >> 1;
			float num19;
			float num20;
			if (ai1 > 0f && ai1 < 196f)
			{
				vector2.X = position.X + (float)(width >> 1);
				vector2.Y = position.Y + (float)(height >> 1);
				num19 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - vector2.X;
				num20 = Main.npc[(int)ai1].position.Y + (float)(Main.npc[(int)ai1].height >> 1) - vector2.Y;
				rotation = (float)(Math.Atan2(num20, num19) + Math.PI / 2.0);
				float num21 = num19 * num19 + num20 * num20;
				bool flag4 = (type >= 87 && type <= 92) || (type >= 159 && type <= 164);
				if (num21 > 0f)
				{
					num21 = (float)Math.Sqrt(num21);
					num21 = (num21 - (float)(flag4 ? 30 : width)) / num21;
					num19 *= num21;
					num20 *= num21;
					position.X += num19;
					position.Y += num20;
					aabb.X = (int)position.X;
					aabb.Y = (int)position.Y;
				}
				velocity.X = 0f;
				velocity.Y = 0f;
				if (flag4)
				{
					if (num19 < 0f)
					{
						spriteDirection = 1;
					}
					else if (num19 > 0f)
					{
						spriteDirection = -1;
					}
				}
				return;
			}
			num19 = ((Main.player[target].aabb.X + 10) & -16);
			num20 = ((Main.player[target].aabb.Y + 21) & -16);
			vector2.X = ((int)vector2.X & -16);
			vector2.Y = ((int)vector2.Y & -16);
			num19 -= vector2.X;
			num20 -= vector2.Y;
			if (!flag2)
			{
				TargetClosest();
				velocity.Y += 0.11f;
				if (velocity.Y > num16)
				{
					velocity.Y = num16;
				}
				if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num16 * 0.4)
				{
					if (velocity.X < 0f)
					{
						velocity.X -= num17 * 1.1f;
					}
					else
					{
						velocity.X += num17 * 1.1f;
					}
				}
				else if (velocity.Y == num16)
				{
					if (velocity.X < num19)
					{
						velocity.X += num17;
					}
					else if (velocity.X > num19)
					{
						velocity.X -= num17;
					}
				}
				else if (velocity.Y > 4f)
				{
					if (velocity.X < 0f)
					{
						velocity.X += num17 * 0.9f;
					}
					else
					{
						velocity.X -= num17 * 0.9f;
					}
				}
			}
			else
			{
				float num21 = (float)Math.Sqrt(num19 * num19 + num20 * num20);
				if (soundDelay == 0 && type != 87 && type != 159 && type != 117)
				{
					int num22 = (int)(num21 * 0.025f);
					if (num22 < 10)
					{
						num22 = 10;
					}
					else if (num22 > 20)
					{
						num22 = 20;
					}
					soundDelay = (short)num22;
					Main.PlaySound(15, aabb.X, aabb.Y);
				}
				float num23 = Math.Abs(num19);
				float num24 = Math.Abs(num20);
				float num25 = num16 / num21;
				num19 *= num25;
				num20 *= num25;
				if ((type == 7 || type == 13) && !Main.player[target].zoneEvil)
				{
					bool flag5 = true;
					for (int num26 = 0; num26 < 8; num26++)
					{
						if (Main.player[num26].active != 0 && !Main.player[num26].dead && Main.player[num26].zoneEvil)
						{
							flag5 = false;
							break;
						}
					}
					if (flag5)
					{
						if (Main.netMode != 1 && aabb.Y >> 4 > Main.rockLayer + Main.maxTilesY >> 1)
						{
							active = 0;
							int num27 = (int)ai0;
							while (num27 > 0 && num27 < 196 && Main.npc[num27].active != 0 && Main.npc[num27].aiStyle == aiStyle)
							{
								int num28 = (int)Main.npc[num27].ai0;
								Main.npc[num27].active = 0;
								life = 0;
								NetMessage.CreateMessage1(23, num27);
								NetMessage.SendMessage();
								num27 = num28;
							}
							NetMessage.CreateMessage1(23, whoAmI);
							NetMessage.SendMessage();
							return;
						}
						num19 = 0f;
						num20 = num16;
					}
				}
				bool flag6 = false;
				if (type == 87 || type == 159)
				{
					if (((velocity.X > 0f && num19 < 0f) || (velocity.X < 0f && num19 > 0f) || (velocity.Y > 0f && num20 < 0f) || (velocity.Y < 0f && num20 > 0f)) && Math.Abs(velocity.X) + Math.Abs(velocity.Y) > num17 * 0.5f && num21 < 300f)
					{
						flag6 = true;
						if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < num16)
						{
							velocity.X *= 1.1f;
							velocity.Y *= 1.1f;
						}
					}
					if (aabb.Y > Main.player[target].aabb.Y || Main.player[target].aabb.Y > Main.worldSurfacePixels || Main.player[target].dead)
					{
						flag6 = true;
						if (Math.Abs(velocity.X) < num16 * 0.5f)
						{
							if (velocity.X == 0f)
							{
								velocity.X -= direction;
							}
							velocity.X *= 1.1f;
						}
						else if (velocity.Y > 0f - num16)
						{
							velocity.Y -= num17;
						}
					}
				}
				if (!flag6)
				{
					if ((velocity.X > 0f && num19 > 0f) || (velocity.X < 0f && num19 < 0f) || (velocity.Y > 0f && num20 > 0f) || (velocity.Y < 0f && num20 < 0f))
					{
						if (velocity.X < num19)
						{
							velocity.X += num17;
						}
						else if (velocity.X > num19)
						{
							velocity.X -= num17;
						}
						if (velocity.Y < num20)
						{
							velocity.Y += num17;
						}
						else if (velocity.Y > num20)
						{
							velocity.Y -= num17;
						}
						if ((double)Math.Abs(num20) < (double)num16 * 0.2 && ((velocity.X > 0f && num19 < 0f) || (velocity.X < 0f && num19 > 0f)))
						{
							if (velocity.Y > 0f)
							{
								velocity.Y += num17 * 2f;
							}
							else
							{
								velocity.Y -= num17 * 2f;
							}
						}
						if ((double)Math.Abs(num19) < (double)num16 * 0.2 && ((velocity.Y > 0f && num20 < 0f) || (velocity.Y < 0f && num20 > 0f)))
						{
							if (velocity.X > 0f)
							{
								velocity.X += num17 * 2f;
							}
							else
							{
								velocity.X -= num17 * 2f;
							}
						}
					}
					else if (num23 > num24)
					{
						if (velocity.X < num19)
						{
							velocity.X += num17 * 1.1f;
						}
						else if (velocity.X > num19)
						{
							velocity.X -= num17 * 1.1f;
						}
						if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num16 * 0.5)
						{
							if (velocity.Y > 0f)
							{
								velocity.Y += num17;
							}
							else
							{
								velocity.Y -= num17;
							}
						}
					}
					else
					{
						if (velocity.Y < num20)
						{
							velocity.Y += num17 * 1.1f;
						}
						else if (velocity.Y > num20)
						{
							velocity.Y -= num17 * 1.1f;
						}
						if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num16 * 0.5)
						{
							if (velocity.X > 0f)
							{
								velocity.X += num17;
							}
							else
							{
								velocity.X -= num17;
							}
						}
					}
				}
			}
			rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
			if (type != 7 && type != 10 && type != 13 && type != 39 && type != 95 && type != 98 && type != 117)
			{
				return;
			}
			if (flag2)
			{
				if (localAI0 != 1)
				{
					netUpdate = true;
				}
				localAI0 = 1;
			}
			else
			{
				if (localAI0 != 0)
				{
					netUpdate = true;
				}
				localAI0 = 0;
			}
			if (((velocity.X > 0f && oldVelocity.X < 0f) || (velocity.X < 0f && oldVelocity.X > 0f) || (velocity.Y > 0f && oldVelocity.Y < 0f) || (velocity.Y < 0f && oldVelocity.Y > 0f)) && !justHit)
			{
				netUpdate = true;
			}
		}

		private void TownsfolkAI()
		{
			if (type == 46)
			{
				if (target == 8)
				{
					TargetClosest();
				}
			}
			else if (type == 107)
			{
				savedGoblin = true;
			}
			else if (type == 108)
			{
				savedWizard = true;
			}
			else if (type == 124)
			{
				savedMech = true;
			}
			else if (type == 142 && Main.netMode != 1 && !Time.xMas)
			{
				StrikeNPC(9999, 0f, 0);
				NetMessage.SendNpcHurt(whoAmI, 9999, 0.0, 0);
			}
			int num = aabb.X + (width >> 1) >> 4;
			int num2 = aabb.Y + height + 1 >> 4;
			bool flag = false;
			directionY = -1;
			direction |= 1;
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[i].active != 0 && Main.player[i].talkNPC == whoAmI)
				{
					flag = true;
					if (ai0 != 0f)
					{
						netUpdate = true;
					}
					ai0 = 0f;
					ai1 = 300f;
					ai2 = 100f;
					if (Main.player[i].aabb.X + 10 < aabb.X + (width >> 1))
					{
						direction = -1;
					}
					else
					{
						direction = 1;
					}
				}
			}
			if (ai3 > 0f && active != 0)
			{
				life = -1;
				HitEffect();
				active = 0;
				if (type == 37)
				{
					Main.PlaySound(15, aabb.X, aabb.Y, 0);
				}
			}
			if (type == 37 && Main.netMode != 1)
			{
				homeless = false;
				homeTileX = Main.dungeonX;
				homeTileY = Main.dungeonY;
				if (downedBoss3)
				{
					ai3 = 1f;
					netUpdate = true;
				}
			}
			int j = homeTileY;
			if (Main.netMode != 1 && j > 0)
			{
				for (; !WorldGen.SolidTile(homeTileX, j) && j < Main.maxTilesY - 20; j++)
				{
				}
			}
			if (Main.netMode != 1 && townNPC && !homeless && (num != homeTileX || num2 != j) && (!Main.gameTime.dayTime || Main.tileDungeon[Main.tile[num, num2].type]))
			{
				bool flag2 = true;
				Rectangle rectangle = default(Rectangle);
				rectangle.X = aabb.X + (width >> 1) - 960 - 62;
				rectangle.Y = aabb.Y + (height >> 1) - 540 - 34;
				rectangle.Width = 2044;
				rectangle.Height = 1148;
				for (int k = 0; k < 8; k++)
				{
					if (Main.player[k].active != 0 && rectangle.Intersects(Main.player[k].aabb))
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					rectangle.X = homeTileX * 16 + 8 - 960 - 62;
					rectangle.Y = j * 16 + 8 - 540 - 34;
					for (int l = 0; l < 8; l++)
					{
						if (Main.player[l].active != 0 && rectangle.Intersects(Main.player[l].aabb))
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						if (type == 37 || !Collision.SolidTiles(homeTileX - 1, homeTileX + 1, j - 3, j - 1))
						{
							velocity.X = 0f;
							velocity.Y = 0f;
							position.X = (aabb.X = (homeTileX << 4) + 8 - (width >> 1));
							position.Y = (float)((j << 4) - height) - 0.1f;
							aabb.Y = (int)position.Y;
							netUpdate = true;
						}
						else
						{
							homeless = true;
							WorldGen.QuickFindHome(whoAmI);
						}
					}
				}
			}
			if (ai0 == 0f)
			{
				if (ai2 > 0f)
				{
					ai2 -= 1f;
				}
				if (!Main.gameTime.dayTime && !flag && type != 46)
				{
					if (Main.netMode != 1)
					{
						if (num == homeTileX && num2 == j)
						{
							if (velocity.X != 0f)
							{
								netUpdate = true;
							}
							if ((double)velocity.X > 0.1)
							{
								velocity.X -= 0.1f;
							}
							else if ((double)velocity.X < -0.1)
							{
								velocity.X += 0.1f;
							}
							else
							{
								velocity.X = 0f;
							}
						}
						else if (!flag)
						{
							if (num > homeTileX)
							{
								direction = -1;
							}
							else
							{
								direction = 1;
							}
							ai0 = 1f;
							ai1 = 200 + Main.rand.Next(200);
							ai2 = 0f;
							netUpdate = true;
						}
					}
				}
				else
				{
					if ((double)velocity.X > 0.1)
					{
						velocity.X -= 0.1f;
					}
					else if ((double)velocity.X < -0.1)
					{
						velocity.X += 0.1f;
					}
					else
					{
						velocity.X = 0f;
					}
					if (Main.netMode != 1)
					{
						if (ai1 > 0f)
						{
							ai1 -= 1f;
						}
						if (ai1 <= 0f)
						{
							ai0 = 1f;
							ai1 = 200 + Main.rand.Next(200);
							if (type == 46)
							{
								ai1 += Main.rand.Next(200, 400);
							}
							ai2 = 0f;
							netUpdate = true;
						}
					}
				}
				if (Main.netMode == 1 || (!Main.gameTime.dayTime && (num != homeTileX || num2 != j)))
				{
					return;
				}
				if (num < homeTileX - 25 || num > homeTileX + 25)
				{
					if (ai2 == 0f)
					{
						if (num < homeTileX - 50 && direction == -1)
						{
							direction = 1;
							netUpdate = true;
						}
						else if (num > homeTileX + 50 && direction == 1)
						{
							direction = -1;
							netUpdate = true;
						}
					}
				}
				else if (Main.rand.Next(80) == 0 && ai2 == 0f)
				{
					ai2 = 200f;
					direction = (sbyte)(-direction);
					netUpdate = true;
				}
			}
			else
			{
				if (ai0 != 1f)
				{
					return;
				}
				if (Main.netMode != 1 && !Main.gameTime.dayTime && num == homeTileX && num2 == homeTileY && type != 46)
				{
					ai0 = 0f;
					ai1 = 200 + Main.rand.Next(200);
					ai2 = 60f;
					netUpdate = true;
					return;
				}
				if (Main.netMode != 1 && !homeless && !Main.tileDungeon[Main.tile[num, num2].type] && (num < homeTileX - 35 || num > homeTileX + 35))
				{
					if (aabb.X < homeTileX << 4 && direction == -1)
					{
						ai1 -= 5f;
					}
					else if (aabb.X > homeTileX << 4 && direction == 1)
					{
						ai1 -= 5f;
					}
				}
				ai1 -= 1f;
				if (ai1 <= 0f)
				{
					ai0 = 0f;
					ai1 = 300 + Main.rand.Next(300);
					if (type == 46)
					{
						ai1 -= Main.rand.Next(100);
					}
					ai2 = 60f;
					netUpdate = true;
				}
				if (closeDoor)
				{
					int num3 = aabb.X + (width >> 1) >> 4;
					if (num3 > doorX + 2 || num3 < doorX - 2)
					{
						if (WorldGen.CloseDoor(doorX, doorY))
						{
							closeDoor = false;
							NetMessage.CreateMessage2(24, doorX, doorY);
							NetMessage.SendMessage();
						}
						else
						{
							int num4 = aabb.Y + (height >> 1) >> 4;
							if (num3 > doorX + 4 || num3 < doorX - 4 || num4 > doorY + 4 || num4 < doorY - 4)
							{
								closeDoor = false;
							}
						}
					}
				}
				if (velocity.X < -1f || velocity.X > 1f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.8f;
					}
				}
				else if ((double)velocity.X < 1.15 && direction == 1)
				{
					velocity.X += 0.07f;
					if (velocity.X > 1f)
					{
						velocity.X = 1f;
					}
				}
				else if (velocity.X > -1f && direction == -1)
				{
					velocity.X -= 0.07f;
					if (velocity.X > 1f)
					{
						velocity.X = 1f;
					}
				}
				if (velocity.Y != 0f)
				{
					return;
				}
				if (position.X == ai2)
				{
					direction = (sbyte)(-direction);
				}
				ai2 = -1f;
				int num5 = aabb.X + (width >> 1) + 15 * direction >> 4;
				int num6 = aabb.Y + height - 16 >> 4;
				if (townNPC && Main.tile[num5, num6 - 2].active != 0 && Main.tile[num5, num6 - 2].type == 10 && (Main.rand.Next(10) == 0 || !Main.gameTime.dayTime))
				{
					if (Main.netMode != 1)
					{
						int num7 = WorldGen.OpenDoor(num5, num6 - 2, direction);
						if (num7 != 0)
						{
							closeDoor = true;
							doorX = (short)num5;
							doorY = (short)(num6 - 2);
							NetMessage.CreateMessage3(19, num5, num6 - 2, num7);
							NetMessage.SendMessage();
							ai1 += 80f;
						}
						else
						{
							direction = (sbyte)(-direction);
						}
						netUpdate = true;
					}
					return;
				}
				if ((velocity.X < 0f && spriteDirection == -1) || (velocity.X > 0f && spriteDirection == 1))
				{
					if (Main.tile[num5, num6 - 2].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num5, num6 - 2].type])
					{
						if ((direction == 1 && !Collision.SolidTiles(num5 - 2, num5 - 1, num6 - 5, num6 - 1)) || (direction == -1 && !Collision.SolidTiles(num5 + 1, num5 + 2, num6 - 5, num6 - 1)))
						{
							if (!Collision.SolidTiles(num5, num5, num6 - 5, num6 - 3))
							{
								velocity.Y = -6f;
							}
							else
							{
								direction = (sbyte)(-direction);
							}
						}
						else
						{
							direction = (sbyte)(-direction);
						}
						netUpdate = true;
					}
					else if (Main.tile[num5, num6 - 1].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num5, num6 - 1].type])
					{
						if ((direction == 1 && !Collision.SolidTiles(num5 - 2, num5 - 1, num6 - 4, num6 - 1)) || (direction == -1 && !Collision.SolidTiles(num5 + 1, num5 + 2, num6 - 4, num6 - 1)))
						{
							if (!Collision.SolidTiles(num5, num5, num6 - 4, num6 - 2))
							{
								velocity.Y = -5f;
							}
							else
							{
								direction = (sbyte)(-direction);
							}
						}
						else
						{
							direction = (sbyte)(-direction);
						}
						netUpdate = true;
					}
					else if (Main.tile[num5, num6].active != 0 && Main.tileSolidNotSolidTop[Main.tile[num5, num6].type])
					{
						if ((direction == 1 && !Collision.SolidTiles(num5 - 2, num5, num6 - 3, num6 - 1)) || (direction == -1 && !Collision.SolidTiles(num5, num5 + 2, num6 - 3, num6 - 1)))
						{
							velocity.Y = -3.6f;
						}
						else
						{
							direction = (sbyte)(-direction);
						}
						netUpdate = true;
					}
					if (num >= homeTileX - 35 && num <= homeTileX + 35 && (Main.tile[num5, num6 + 1].active == 0 || !Main.tileSolid[Main.tile[num5, num6 + 1].type]) && (Main.tile[num5 - direction, num6 + 1].active == 0 || !Main.tileSolid[Main.tile[num5 - direction, num6 + 1].type]) && (Main.tile[num5, num6 + 2].active == 0 || !Main.tileSolid[Main.tile[num5, num6 + 2].type]) && (Main.tile[num5 - direction, num6 + 2].active == 0 || !Main.tileSolid[Main.tile[num5 - direction, num6 + 2].type]) && (Main.tile[num5, num6 + 3].active == 0 || !Main.tileSolid[Main.tile[num5, num6 + 3].type]) && (Main.tile[num5 - direction, num6 + 3].active == 0 || !Main.tileSolid[Main.tile[num5 - direction, num6 + 3].type]) && (Main.tile[num5, num6 + 4].active == 0 || !Main.tileSolid[Main.tile[num5, num6 + 4].type]) && (Main.tile[num5 - direction, num6 + 4].active == 0 || !Main.tileSolid[Main.tile[num5 - direction, num6 + 4].type]) && type != 46)
					{
						direction = (sbyte)(-direction);
						velocity.X = 0f - velocity.X;
						netUpdate = true;
					}
					if (velocity.Y < 0f)
					{
						ai2 = position.X;
					}
				}
				if (velocity.Y < 0f)
				{
					if (wet)
					{
						velocity.Y *= 1.2f;
					}
					if (type == 46)
					{
						velocity.Y *= 1.2f;
					}
				}
			}
		}

		private unsafe void SorcererAI()
		{
			TargetClosest();
			velocity.X *= 0.93f;
			if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
			{
				velocity.X = 0f;
			}
			if (ai0 == 0f)
			{
				ai0 = 500f;
			}
			if (ai2 != 0f && ai3 != 0f)
			{
				Main.PlaySound(2, aabb.X, aabb.Y, 8);
				for (int i = 0; i < 42; i++)
				{
					Dust* ptr;
					if (type == 29 || type == 45)
					{
						ptr = Main.dust.NewDust(27, ref aabb, 0.0, 0.0, 100, default(Color), Main.rand.Next(1, 3));
						if (ptr == null)
						{
							break;
						}
						if (ptr->scale > 1f)
						{
							ptr->noGravity = true;
						}
					}
					else if (type == 32)
					{
						ptr = Main.dust.NewDust(29, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
						if (ptr == null)
						{
							break;
						}
						ptr->noGravity = true;
					}
					else
					{
						ptr = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
						if (ptr == null)
						{
							break;
						}
						ptr->noGravity = true;
					}
					ptr->velocity.X *= 3f;
					ptr->velocity.Y *= 3f;
				}
				position.X = ai2 * 16f - (float)(width >> 1) + 8f;
				position.Y = ai3 * 16f - (float)(int)height;
				aabb.X = (int)position.X;
				aabb.Y = (int)position.Y;
				velocity.X = 0f;
				velocity.Y = 0f;
				ai2 = 0f;
				ai3 = 0f;
				Main.PlaySound(2, aabb.X, aabb.Y, 8);
				for (int j = 0; j < 42; j++)
				{
					Dust* ptr2;
					if (type == 29 || type == 45)
					{
						ptr2 = Main.dust.NewDust(27, ref aabb, 0.0, 0.0, 100, default(Color), Main.rand.Next(1, 3));
						if (ptr2 == null)
						{
							break;
						}
						if (ptr2->scale > 1f)
						{
							ptr2->noGravity = true;
						}
					}
					else if (type == 32)
					{
						ptr2 = Main.dust.NewDust(29, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
						if (ptr2 == null)
						{
							break;
						}
						ptr2->noGravity = true;
					}
					else
					{
						ptr2 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
						if (ptr2 == null)
						{
							break;
						}
						ptr2->noGravity = true;
					}
					ptr2->velocity.X *= 3f;
					ptr2->velocity.Y *= 3f;
				}
			}
			ai0 += 1f;
			if (ai0 == 100f || ai0 == 200f || ai0 == 300f)
			{
				ai1 = 30f;
				netUpdate = true;
			}
			else if (ai0 >= 650f && Main.netMode != 1)
			{
				ai0 = 1f;
				int num = Main.player[target].aabb.X >> 4;
				int num2 = Main.player[target].aabb.Y >> 4;
				int num3 = aabb.X >> 4;
				int num4 = aabb.Y >> 4;
				int num5 = 20;
				int num6 = 0;
				bool flag = false;
				if (Math.Abs(aabb.X - Main.player[target].aabb.X) + Math.Abs(aabb.Y - Main.player[target].aabb.Y) > 2000)
				{
					num6 = 100;
					flag = true;
				}
				while (!flag && num6 < 100)
				{
					num6++;
					int num7 = Main.rand.Next(num - num5, num + num5);
					int num8 = Main.rand.Next(num2 - num5, num2 + num5);
					for (int k = num8; k < num2 + num5; k++)
					{
						if ((k < num2 - 4 || k > num2 + 4 || num7 < num - 4 || num7 > num + 4) && (k < num4 - 1 || k > num4 + 1 || num7 < num3 - 1 || num7 > num3 + 1) && Main.tile[num7, k].active != 0)
						{
							bool flag2 = true;
							if (type == 32 && Main.tile[num7, k - 1].wall == 0)
							{
								flag2 = false;
							}
							else if (Main.tile[num7, k - 1].lava != 0)
							{
								flag2 = false;
							}
							if (flag2 && Main.tileSolid[Main.tile[num7, k].type] && !Collision.SolidTiles(num7 - 1, num7 + 1, k - 4, k - 1))
							{
								ai1 = 20f;
								ai2 = num7;
								ai3 = k;
								flag = true;
								break;
							}
						}
					}
				}
				netUpdate = true;
			}
			if (ai1 > 0f)
			{
				ai1 -= 1f;
				if (ai1 == 25f)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 8);
					if (Main.netMode != 1)
					{
						if (type == 29 || type == 45)
						{
							NewNPC(aabb.X + (width >> 1), aabb.Y - 8, 30);
						}
						else if (type == 32)
						{
							NewNPC(aabb.X + (width >> 1), aabb.Y - 8, 33);
						}
						else
						{
							NewNPC(aabb.X + (width >> 1) + direction * 8, aabb.Y + 20, 25);
						}
					}
				}
			}
			if (type == 29 || type == 45)
			{
				if (Main.rand.Next(5) == 0)
				{
					Dust* ptr3 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 27, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 1.5);
					if (ptr3 != null)
					{
						ptr3->noGravity = true;
						ptr3->velocity.X *= 0.5f;
						ptr3->velocity.Y = -2f;
					}
				}
			}
			else if (type == 32)
			{
				if (Main.rand.Next(2) == 0)
				{
					Dust* ptr4 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 29, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
					if (ptr4 != null)
					{
						ptr4->noGravity = true;
						ptr4->velocity.X *= 1f;
						ptr4->velocity.Y *= 1f;
					}
				}
			}
			else if (Main.rand.Next(2) == 0)
			{
				Dust* ptr5 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
				if (ptr5 != null)
				{
					ptr5->noGravity = true;
					ptr5->velocity.X *= 1f;
					ptr5->velocity.Y *= 1f;
				}
			}
		}

		private unsafe void SphereAI()
		{
			if (target == 8)
			{
				TargetClosest();
				float num = 6f;
				if (type == 25)
				{
					num = 5f;
				}
				if (type == 112)
				{
					num = 7f;
				}
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num2 = Main.player[target].position.X + 10f - vector.X;
				float num3 = Main.player[target].position.Y + 21f - vector.Y;
				float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				num4 = num / num4;
				velocity.X = num2 * num4;
				velocity.Y = num3 * num4;
			}
			if (type == 112)
			{
				ai0 += 1f;
				if (ai0 > 3f)
				{
					ai0 = 3f;
				}
				if (ai0 == 2f)
				{
					position.X += velocity.X;
					position.Y += velocity.Y;
					aabb.X = (int)position.X;
					aabb.Y = (int)position.Y;
					Main.PlaySound(4, aabb.X, aabb.Y, 9);
					for (int i = 0; i < 16; i++)
					{
						Dust* ptr = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 18, 0.0, 0.0, 100, default(Color), 1.7999999523162842);
						if (ptr == null)
						{
							break;
						}
						ptr->velocity.X *= 1.3f;
						ptr->velocity.Y *= 1.3f;
						ptr->velocity.X += velocity.X;
						ptr->velocity.Y += velocity.Y;
						ptr->noGravity = true;
					}
				}
				if (Collision.SolidCollision(ref position, width, height))
				{
					if (Main.netMode != 1)
					{
						int num5 = aabb.X + (width >> 1) >> 4;
						int num6 = aabb.Y + (height >> 1) >> 4;
						int num7 = 8;
						for (int j = num5 - num7; j <= num5 + num7; j++)
						{
							for (int k = num6 - num7; k < num6 + num7; k++)
							{
								if ((double)(Math.Abs(j - num5) + Math.Abs(k - num6)) < (double)num7 * 0.5)
								{
									if (Main.tile[j, k].type == 2)
									{
										Main.tile[j, k].type = 23;
										WorldGen.SquareTileFrame(j, k);
										NetMessage.SendTile(j, k);
									}
									else if (Main.tile[j, k].type == 1)
									{
										Main.tile[j, k].type = 25;
										WorldGen.SquareTileFrame(j, k);
										NetMessage.SendTile(j, k);
									}
									else if (Main.tile[j, k].type == 53)
									{
										Main.tile[j, k].type = 112;
										WorldGen.SquareTileFrame(j, k);
										NetMessage.SendTile(j, k);
									}
									else if (Main.tile[j, k].type == 109)
									{
										Main.tile[j, k].type = 23;
										WorldGen.SquareTileFrame(j, k);
										NetMessage.SendTile(j, k);
									}
									else if (Main.tile[j, k].type == 117)
									{
										Main.tile[j, k].type = 25;
										WorldGen.SquareTileFrame(j, k);
										NetMessage.SendTile(j, k);
									}
									else if (Main.tile[j, k].type == 116)
									{
										Main.tile[j, k].type = 112;
										WorldGen.SquareTileFrame(j, k);
										NetMessage.SendTile(j, k);
									}
								}
							}
						}
					}
					StrikeNPC(999, 0f, 0);
				}
			}
			if (timeLeft > 100)
			{
				timeLeft = 100;
			}
			for (int l = 0; l < 2; l++)
			{
				Dust* ptr2;
				if (type == 30)
				{
					ptr2 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 27, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
					if (ptr2 == null)
					{
						break;
					}
				}
				else if (type == 33)
				{
					ptr2 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 29, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
					if (ptr2 == null)
					{
						break;
					}
				}
				else if (type == 112)
				{
					ptr2 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 18, velocity.X * 0.1f, velocity.Y * 0.1f, 80, default(Color), 1.2999999523162842);
					if (ptr2 == null)
					{
						break;
					}
				}
				else
				{
					Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, new Vector3(1f, 0.3f, 0.1f));
					ptr2 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 6, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
				}
				if (ptr2 != null)
				{
					ptr2->noGravity = true;
					ptr2->velocity.X *= 0.3f;
					ptr2->velocity.Y *= 0.3f;
					if (type == 30)
					{
						ptr2->velocity.X -= velocity.X * 0.2f;
						ptr2->velocity.Y -= velocity.Y * 0.2f;
					}
				}
			}
			rotation += 0.4f * (float)direction;
		}

		private void SkullHeadAI()
		{
			float num = 1f;
			float num2 = 0.011f;
			TargetClosest();
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num3 = Main.player[target].position.X + 10f - vector.X;
			float num4 = Main.player[target].position.Y + 21f - vector.Y;
			float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
			float num6 = num5;
			ai1 += 1f;
			if (ai1 > 600f)
			{
				num2 *= 8f;
				num = 4f;
				if (ai1 > 650f)
				{
					ai1 = 0f;
				}
			}
			else if (num6 < 250f)
			{
				ai0 += 0.9f;
				if (ai0 > 0f)
				{
					velocity.Y += 0.019f;
				}
				else
				{
					velocity.Y -= 0.019f;
				}
				if (ai0 < -100f || ai0 > 100f)
				{
					velocity.X += 0.019f;
				}
				else
				{
					velocity.X -= 0.019f;
				}
				if (ai0 > 200f)
				{
					ai0 = -200f;
				}
			}
			if (num6 > 350f)
			{
				num = 5f;
				num2 = 0.3f;
			}
			else if (num6 > 300f)
			{
				num = 3f;
				num2 = 0.2f;
			}
			else if (num6 > 250f)
			{
				num = 1.5f;
				num2 = 0.1f;
			}
			num5 = num / num5;
			num3 *= num5;
			num4 *= num5;
			if (Main.player[target].dead)
			{
				num3 = (float)direction * num * 0.5f;
				num4 = num * -0.5f;
			}
			if (velocity.X < num3)
			{
				velocity.X += num2;
			}
			else if (velocity.X > num3)
			{
				velocity.X -= num2;
			}
			if (velocity.Y < num4)
			{
				velocity.Y += num2;
			}
			else if (velocity.Y > num4)
			{
				velocity.Y -= num2;
			}
			if (num3 > 0f)
			{
				spriteDirection = -1;
				rotation = (float)Math.Atan2(num4, num3);
			}
			else if (num3 < 0f)
			{
				spriteDirection = 1;
				rotation = (float)Math.Atan2(num4, num3) + 3.14f;
			}
		}

		private unsafe void SkeletronAI()
		{
			if (ai0 == 0f && Main.netMode != 1)
			{
				TargetClosest();
				ai0 = 1f;
				if (type != 68)
				{
					int num = NewNPC(aabb.X + (width >> 1), aabb.Y + (height >> 1), 36, whoAmI);
					Main.npc[num].ai0 = -1f;
					Main.npc[num].ai1 = whoAmI;
					Main.npc[num].target = target;
					Main.npc[num].netUpdate = true;
					num = NewNPC(aabb.X + (width >> 1), aabb.Y + (height >> 1), 36, whoAmI);
					Main.npc[num].ai0 = 1f;
					Main.npc[num].ai1 = whoAmI;
					Main.npc[num].ai3 = 150f;
					Main.npc[num].target = target;
					Main.npc[num].netUpdate = true;
				}
			}
			if (type == 68 && ai1 != 3f && ai1 != 2f)
			{
				Main.PlaySound(15, aabb.X, aabb.Y, 0);
				ai1 = 2f;
			}
			if (Main.player[target].dead || Math.Abs(aabb.X - Main.player[target].aabb.X) > 2000 || Math.Abs(aabb.Y - Main.player[target].aabb.Y) > 2000)
			{
				TargetClosest();
				if (Main.player[target].dead || Math.Abs(aabb.X - Main.player[target].aabb.X) > 2000 || Math.Abs(aabb.Y - Main.player[target].aabb.Y) > 2000)
				{
					ai1 = 3f;
				}
			}
			if (Main.gameTime.dayTime && ai1 != 3f && ai1 != 2f)
			{
				ai1 = 2f;
				Main.PlaySound(15, aabb.X, aabb.Y, 0);
			}
			if (ai1 == 0f)
			{
				defense = 10;
				ai2 += 1f;
				if (ai2 >= 800f)
				{
					ai2 = 0f;
					ai1 = 1f;
					TargetClosest();
					netUpdate = true;
				}
				rotation = velocity.X * (71f / (339f * (float)Math.PI));
				if (aabb.Y > Main.player[target].aabb.Y - 250)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.98f;
					}
					velocity.Y -= 0.02f;
					if (velocity.Y > 2f)
					{
						velocity.Y = 2f;
					}
				}
				else if (aabb.Y < Main.player[target].aabb.Y - 250)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.98f;
					}
					velocity.Y += 0.02f;
					if (velocity.Y < -2f)
					{
						velocity.Y = -2f;
					}
				}
				if (aabb.X + (width >> 1) > Main.player[target].aabb.X + 10)
				{
					if (velocity.X > 0f)
					{
						velocity.X *= 0.98f;
					}
					velocity.X -= 0.05f;
					if (velocity.X > 8f)
					{
						velocity.X = 8f;
					}
				}
				else if (aabb.X + (width >> 1) < Main.player[target].aabb.X + 10)
				{
					if (velocity.X < 0f)
					{
						velocity.X *= 0.98f;
					}
					velocity.X += 0.05f;
					if (velocity.X < -8f)
					{
						velocity.X = -8f;
					}
				}
			}
			else if (ai1 == 1f)
			{
				defense = 0;
				ai2 += 1f;
				if (ai2 == 2f)
				{
					Main.PlaySound(15, aabb.X, aabb.Y, 0);
				}
				if (ai2 >= 400f)
				{
					ai2 = 0f;
					ai1 = 0f;
				}
				rotation += (float)direction * 0.3f;
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num2 = Main.player[target].position.X + 10f - vector.X;
				float num3 = Main.player[target].position.Y + 21f - vector.Y;
				float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				num4 = 1.5f / num4;
				velocity.X = num2 * num4;
				velocity.Y = num3 * num4;
			}
			else if (ai1 == 2f)
			{
				damage = 9999;
				defense = 9999;
				rotation += (float)direction * 0.3f;
				Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num5 = Main.player[target].position.X + 10f - vector2.X;
				float num6 = Main.player[target].position.Y + 21f - vector2.Y;
				float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
				num7 = 8f / num7;
				velocity.X = num5 * num7;
				velocity.Y = num6 * num7;
			}
			else if (ai1 == 3f)
			{
				velocity.Y += 0.1f;
				if (velocity.Y < 0f)
				{
					velocity.Y *= 0.95f;
				}
				velocity.X *= 0.95f;
				if (timeLeft > 500)
				{
					timeLeft = 500;
				}
			}
			if (ai1 == 2f || ai1 == 3f || type == 68)
			{
				return;
			}
			Dust* ptr = Main.dust.NewDust(aabb.X + (width >> 1) - 15 - (int)(velocity.X * 5f), aabb.Y + height - 2, 30, 10, 5, velocity.X * -0.2f, 3.0, 0, default(Color), 2.0);
			if (ptr != null)
			{
				ptr->noGravity = true;
				ptr->velocity.X *= 1.3f;
				ptr->velocity.X += velocity.X * 0.4f;
				ptr->velocity.Y += 2f + velocity.Y;
			}
			for (int i = 0; i < 2; i++)
			{
				ptr = Main.dust.NewDust(aabb.X, aabb.Y + 120, width, 60, 5, velocity.X, velocity.Y, 0, default(Color), 2.0);
				if (ptr == null)
				{
					break;
				}
				ptr->noGravity = true;
				ptr->velocity -= velocity;
				ptr->velocity.Y += 5f;
			}
		}

		private void SkeletronHandAI()
		{
			spriteDirection = (sbyte)(0f - ai0);
			if (Main.npc[(int)ai1].active == 0 || Main.npc[(int)ai1].aiStyle != 11)
			{
				ai2 += 10f;
				if (ai2 > 50f || Main.netMode != 2)
				{
					life = -1;
					HitEffect();
					active = 0;
					return;
				}
			}
			if (ai2 == 0f || ai2 == 3f)
			{
				if (Main.npc[(int)ai1].ai1 == 3f && timeLeft > 10)
				{
					timeLeft = 10;
				}
				if (Main.npc[(int)ai1].ai1 != 0f)
				{
					if (aabb.Y > Main.npc[(int)ai1].aabb.Y - 100)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.07f;
						if (velocity.Y > 6f)
						{
							velocity.Y = 6f;
						}
					}
					else if (aabb.Y < Main.npc[(int)ai1].aabb.Y - 100)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.07f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (aabb.X + (width >> 1) > Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1) - 120 * (int)ai0)
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X -= 0.1f;
						if (velocity.X > 8f)
						{
							velocity.X = 8f;
						}
					}
					else if (aabb.X + (width >> 1) < Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1) - 120 * (int)ai0)
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X += 0.1f;
						if (velocity.X < -8f)
						{
							velocity.X = -8f;
						}
					}
				}
				else
				{
					ai3 += 1f;
					if (ai3 >= 300f)
					{
						ai2 += 1f;
						ai3 = 0f;
						netUpdate = true;
					}
					if (aabb.Y > Main.npc[(int)ai1].aabb.Y + 230)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.04f;
						if (velocity.Y > 3f)
						{
							velocity.Y = 3f;
						}
					}
					else if (aabb.Y < Main.npc[(int)ai1].aabb.Y + 230)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.04f;
						if (velocity.Y < -3f)
						{
							velocity.Y = -3f;
						}
					}
					if (aabb.X + (width >> 1) > Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1) - 200 * (int)ai0)
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X -= 0.07f;
						if (velocity.X > 8f)
						{
							velocity.X = 8f;
						}
					}
					else if (aabb.X + (width >> 1) < Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1) - 200 * (int)ai0)
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X += 0.07f;
						if (velocity.X < -8f)
						{
							velocity.X = -8f;
						}
					}
				}
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector.X;
				float num2 = Main.npc[(int)ai1].position.Y + 230f - vector.Y;
				rotation = (float)Math.Atan2(num2, num) + 1.57f;
			}
			else if (ai2 == 1f)
			{
				Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num3 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector2.X;
				float num4 = Main.npc[(int)ai1].position.Y + 230f - vector2.Y;
				rotation = (float)Math.Atan2(num4, num3) + 1.57f;
				velocity.X *= 0.95f;
				velocity.Y -= 0.1f;
				if (velocity.Y < -8f)
				{
					velocity.Y = -8f;
				}
				if (aabb.Y < Main.npc[(int)ai1].aabb.Y - 200)
				{
					TargetClosest();
					ai2 = 2f;
					vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					num3 = Main.player[target].position.X + 10f - vector2.X;
					num4 = Main.player[target].position.Y + 21f - vector2.Y;
					float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
					num5 = 18f / num5;
					velocity.X = num3 * num5;
					velocity.Y = num4 * num5;
					netUpdate = true;
				}
			}
			else if (ai2 == 2f)
			{
				if (aabb.Y > Main.player[target].aabb.Y || velocity.Y < 0f)
				{
					ai2 = 3f;
				}
			}
			else if (ai2 == 4f)
			{
				Vector2 vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num6 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector3.X;
				float num7 = Main.npc[(int)ai1].position.Y + 230f - vector3.Y;
				rotation = (float)Math.Atan2(num7, num6) + 1.57f;
				velocity.Y *= 0.95f;
				velocity.X += 0.1f * (0f - ai0);
				if (velocity.X < -8f)
				{
					velocity.X = -8f;
				}
				if (velocity.X > 8f)
				{
					velocity.X = 8f;
				}
				if (aabb.X + (width >> 1) < Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1) - 500 || aabb.X + (width >> 1) > Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1) + 500)
				{
					TargetClosest();
					ai2 = 5f;
					vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					num6 = Main.player[target].position.X + 10f - vector3.X;
					num7 = Main.player[target].position.Y + 21f - vector3.Y;
					float num8 = (float)Math.Sqrt(num6 * num6 + num7 * num7);
					num8 = 17f / num8;
					velocity.X = num6 * num8;
					velocity.Y = num7 * num8;
					netUpdate = true;
				}
			}
			else if (ai2 == 5f && ((velocity.X > 0f && aabb.X + (width >> 1) > Main.player[target].aabb.X + 10) || (velocity.X < 0f && aabb.X + (width >> 1) < Main.player[target].aabb.X + 10)))
			{
				ai2 = 0f;
			}
		}

		private void PlantAI()
		{
			if (Main.tile[(int)ai0, (int)ai1].active == 0)
			{
				life = -1;
				HitEffect();
				active = 0;
				return;
			}
			TargetClosest();
			float num = 0.035f;
			float num2 = 150f;
			if (type == 43)
			{
				num2 = 250f;
			}
			if (type == 101)
			{
				num2 = 175f;
			}
			ai2 += 1f;
			if (ai2 > 300f)
			{
				num2 = (int)(num2 * 1.3f);
				if (ai2 > 450f)
				{
					ai2 = 0f;
				}
			}
			Vector2 vector = new Vector2(ai0 * 16f + 8f, ai1 * 16f + 8f);
			float num3 = Main.player[target].position.X + 10f - (float)(width >> 1) - vector.X;
			float num4 = Main.player[target].position.Y + 21f - (float)(height >> 1) - vector.Y;
			float num5 = num3 * num3 + num4 * num4;
			if (num5 > num2 * num2)
			{
				num5 = num2 / (float)Math.Sqrt(num5);
				num3 *= num5;
				num4 *= num5;
			}
			if (position.X < ai0 * 16f + 8f + num3)
			{
				velocity.X += num;
				if (velocity.X < 0f && num3 > 0f)
				{
					velocity.X += num * 1.5f;
				}
			}
			else if (position.X > ai0 * 16f + 8f + num3)
			{
				velocity.X -= num;
				if (velocity.X > 0f && num3 < 0f)
				{
					velocity.X -= num * 1.5f;
				}
			}
			if (position.Y < ai1 * 16f + 8f + num4)
			{
				velocity.Y += num;
				if (velocity.Y < 0f && num4 > 0f)
				{
					velocity.Y += num * 1.5f;
				}
			}
			else if (position.Y > ai1 * 16f + 8f + num4)
			{
				velocity.Y -= num;
				if (velocity.Y > 0f && num4 < 0f)
				{
					velocity.Y -= num * 1.5f;
				}
			}
			if (type == 43)
			{
				if (velocity.X > 3f)
				{
					velocity.X = 3f;
				}
				else if (velocity.X < -3f)
				{
					velocity.X = -3f;
				}
				if (velocity.Y > 3f)
				{
					velocity.Y = 3f;
				}
				else if (velocity.Y < -3f)
				{
					velocity.Y = -3f;
				}
			}
			else
			{
				if (velocity.X > 2f)
				{
					velocity.X = 2f;
				}
				else if (velocity.X < -2f)
				{
					velocity.X = -2f;
				}
				if (velocity.Y > 2f)
				{
					velocity.Y = 2f;
				}
				else if (velocity.Y < -2f)
				{
					velocity.Y = -2f;
				}
			}
			if (num3 > 0f)
			{
				spriteDirection = 1;
				rotation = (float)Math.Atan2(num4, num3);
			}
			else if (num3 < 0f)
			{
				spriteDirection = -1;
				rotation = (float)Math.Atan2(num4, num3) + 3.14f;
			}
			if (collideX)
			{
				netUpdate = true;
				velocity.X = oldVelocity.X * -0.7f;
				if (velocity.X > 0f && velocity.X < 2f)
				{
					velocity.X = 2f;
				}
				else if (velocity.X < 0f && velocity.X > -2f)
				{
					velocity.X = -2f;
				}
			}
			if (collideY)
			{
				netUpdate = true;
				velocity.Y = oldVelocity.Y * -0.7f;
				if (velocity.Y > 0f && velocity.Y < 2f)
				{
					velocity.Y = 2f;
				}
				else if (velocity.Y < 0f && velocity.Y > -2f)
				{
					velocity.Y = -2f;
				}
			}
			if (Main.netMode == 1 || type != 101 || Main.player[target].dead)
			{
				return;
			}
			if (justHit)
			{
				localAI0 = 0;
			}
			if (++localAI0 < 120)
			{
				return;
			}
			if (!Collision.SolidCollision(ref position, width, height) && Collision.CanHit(ref aabb, ref Main.player[target].aabb))
			{
				vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				num3 = Main.player[target].position.X + 10f - vector.X + (float)Main.rand.Next(-10, 11);
				num4 = Main.player[target].position.Y + 21f - vector.Y + (float)Main.rand.Next(-10, 11);
				num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
				num5 = 10f / num5;
				num3 *= num5;
				num4 *= num5;
				int num6 = Projectile.NewProjectile(vector.X, vector.Y, num3, num4, 96, 22, 0f);
				if (num6 >= 0)
				{
					Main.projectile[num6].timeLeft = 300;
				}
				localAI0 = 0;
			}
			else
			{
				localAI0 = 100;
			}
		}

		private unsafe void FlyerAI()
		{
			if (type == 60)
			{
				Dust* ptr = Main.dust.NewDust(6, ref aabb, velocity.X * 0.2f, velocity.Y * 0.2f, 100, default(Color), 2.0);
				if (ptr != null)
				{
					ptr->noGravity = true;
				}
			}
			noGravity = true;
			if (collideX)
			{
				velocity.X = oldVelocity.X * -0.5f;
				if (direction == -1 && velocity.X > 0f && velocity.X < 2f)
				{
					velocity.X = 2f;
				}
				else if (direction == 1 && velocity.X < 0f && velocity.X > -2f)
				{
					velocity.X = -2f;
				}
			}
			if (collideY)
			{
				velocity.Y = oldVelocity.Y * -0.5f;
				if (velocity.Y > 0f && velocity.Y < 1f)
				{
					velocity.Y = 1f;
				}
				else if (velocity.Y < 0f && velocity.Y > -1f)
				{
					velocity.Y = -1f;
				}
			}
			TargetClosest();
			if (direction == -1 && velocity.X > -4f)
			{
				velocity.X -= 0.1f;
				if (velocity.X > 4f)
				{
					velocity.X -= 0.1f;
				}
				else if (velocity.X > 0f)
				{
					velocity.X += 0.05f;
				}
				else if (velocity.X < -4f)
				{
					velocity.X = -4f;
				}
			}
			else if (direction == 1 && velocity.X < 4f)
			{
				velocity.X += 0.1f;
				if (velocity.X < -4f)
				{
					velocity.X += 0.1f;
				}
				else if (velocity.X < 0f)
				{
					velocity.X -= 0.05f;
				}
				else if (velocity.X > 4f)
				{
					velocity.X = 4f;
				}
			}
			if (directionY == -1 && (double)velocity.Y > -1.5)
			{
				velocity.Y -= 0.04f;
				if ((double)velocity.Y > 1.5)
				{
					velocity.Y -= 0.05f;
				}
				else if (velocity.Y > 0f)
				{
					velocity.Y += 0.03f;
				}
				else if ((double)velocity.Y < -1.5)
				{
					velocity.Y = -1.5f;
				}
			}
			else if (directionY == 1 && (double)velocity.Y < 1.5)
			{
				velocity.Y += 0.04f;
				if ((double)velocity.Y < -1.5)
				{
					velocity.Y += 0.05f;
				}
				else if (velocity.Y < 0f)
				{
					velocity.Y -= 0.03f;
				}
				else if ((double)velocity.Y > 1.5)
				{
					velocity.Y = 1.5f;
				}
			}
			if (type == 49 || type == 51 || type == 60 || type == 62 || type == 165 || type == 66 || type == 93 || type == 137)
			{
				if (wet)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.95f;
					}
					velocity.Y -= 0.5f;
					if (velocity.Y < -4f)
					{
						velocity.Y = -4f;
					}
					TargetClosest();
				}
				if (type == 60)
				{
					if (direction == -1 && velocity.X > -4f)
					{
						velocity.X -= 0.1f;
						if (velocity.X > 4f)
						{
							velocity.X -= 0.07f;
						}
						else if (velocity.X > 0f)
						{
							velocity.X += 0.03f;
						}
						if (velocity.X < -4f)
						{
							velocity.X = -4f;
						}
					}
					else if (direction == 1 && velocity.X < 4f)
					{
						velocity.X += 0.1f;
						if (velocity.X < -4f)
						{
							velocity.X += 0.07f;
						}
						else if (velocity.X < 0f)
						{
							velocity.X -= 0.03f;
						}
						if (velocity.X > 4f)
						{
							velocity.X = 4f;
						}
					}
					if (directionY == -1 && (double)velocity.Y > -1.5)
					{
						velocity.Y -= 0.04f;
						if ((double)velocity.Y > 1.5)
						{
							velocity.Y -= 0.03f;
						}
						else if (velocity.Y > 0f)
						{
							velocity.Y += 0.02f;
						}
						if ((double)velocity.Y < -1.5)
						{
							velocity.Y = -1.5f;
						}
					}
					else if (directionY == 1 && (double)velocity.Y < 1.5)
					{
						velocity.Y += 0.04f;
						if ((double)velocity.Y < -1.5)
						{
							velocity.Y += 0.03f;
						}
						else if (velocity.Y < 0f)
						{
							velocity.Y -= 0.02f;
						}
						if ((double)velocity.Y > 1.5)
						{
							velocity.Y = 1.5f;
						}
					}
				}
				else
				{
					if (direction == -1 && velocity.X > -4f)
					{
						velocity.X -= 0.1f;
						if (velocity.X > 4f)
						{
							velocity.X -= 0.1f;
						}
						else if (velocity.X > 0f)
						{
							velocity.X += 0.05f;
						}
						if (velocity.X < -4f)
						{
							velocity.X = -4f;
						}
					}
					else if (direction == 1 && velocity.X < 4f)
					{
						velocity.X += 0.1f;
						if (velocity.X < -4f)
						{
							velocity.X += 0.1f;
						}
						else if (velocity.X < 0f)
						{
							velocity.X -= 0.05f;
						}
						if (velocity.X > 4f)
						{
							velocity.X = 4f;
						}
					}
					if (directionY == -1 && (double)velocity.Y > -1.5)
					{
						velocity.Y -= 0.04f;
						if ((double)velocity.Y > 1.5)
						{
							velocity.Y -= 0.05f;
						}
						else if (velocity.Y > 0f)
						{
							velocity.Y += 0.03f;
						}
						if ((double)velocity.Y < -1.5)
						{
							velocity.Y = -1.5f;
						}
					}
					else if (directionY == 1 && (double)velocity.Y < 1.5)
					{
						velocity.Y += 0.04f;
						if ((double)velocity.Y < -1.5)
						{
							velocity.Y += 0.05f;
						}
						else if (velocity.Y < 0f)
						{
							velocity.Y -= 0.03f;
						}
						if ((double)velocity.Y > 1.5)
						{
							velocity.Y = 1.5f;
						}
					}
				}
			}
			ai1 += 1f;
			if (ai1 > 200f)
			{
				if (!Main.player[target].wet && Collision.CanHit(ref aabb, ref Main.player[target].aabb))
				{
					ai1 = 0f;
				}
				float num = 0.2f;
				float num2 = 0.1f;
				float num3 = 4f;
				float num4 = 1.5f;
				if (type == 48 || type == 62 || type == 165 || type == 66)
				{
					num = 0.12f;
					num2 = 0.07f;
					num3 = 3f;
					num4 = 1.25f;
				}
				if (ai1 > 1000f)
				{
					ai1 = 0f;
				}
				ai2 += 1f;
				if (ai2 > 0f)
				{
					if (velocity.Y < num4)
					{
						velocity.Y += num2;
					}
				}
				else if (velocity.Y > 0f - num4)
				{
					velocity.Y -= num2;
				}
				if (ai2 < -150f || ai2 > 150f)
				{
					if (velocity.X < num3)
					{
						velocity.X += num;
					}
				}
				else if (velocity.X > 0f - num3)
				{
					velocity.X -= num;
				}
				if (ai2 > 300f)
				{
					ai2 = -300f;
				}
			}
			if (Main.netMode == 1)
			{
				return;
			}
			if (type == 48)
			{
				ai0 += 1f;
				if (ai0 == 30f || ai0 == 60f || ai0 == 90f)
				{
					if (Collision.CanHit(ref aabb, ref Main.player[target].aabb))
					{
						Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num5 = Main.player[target].position.X + 10f - vector.X + (float)Main.rand.Next(-100, 101);
						float num6 = Main.player[target].position.Y + 21f - vector.Y + (float)Main.rand.Next(-100, 101);
						float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
						num7 = 6f / num7;
						num5 *= num7;
						num6 *= num7;
						int num8 = Projectile.NewProjectile(vector.X, vector.Y, num5, num6, 38, 15, 0f);
						if (num8 >= 0)
						{
							Main.projectile[num8].timeLeft = 300;
						}
					}
				}
				else if (ai0 >= (float)(400 + Main.rand.Next(400)))
				{
					ai0 = 0f;
				}
			}
			else
			{
				if (type != 62 && type != 165 && type != 66)
				{
					return;
				}
				ai0 += 1f;
				if (ai0 == 20f || ai0 == 40f || ai0 == 60f || ai0 == 80f)
				{
					if (Collision.CanHit(ref aabb, ref Main.player[target].aabb))
					{
						Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num9 = Main.player[target].position.X + 10f - vector2.X + (float)Main.rand.Next(-100, 101);
						float num10 = Main.player[target].position.Y + 21f - vector2.Y + (float)Main.rand.Next(-100, 101);
						float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
						num11 = 0.2f / num11;
						num9 *= num11;
						num10 *= num11;
						int num12 = Projectile.NewProjectile(vector2.X, vector2.Y, num9, num10, 44, 21, 0f);
						if (num12 >= 0)
						{
							Main.projectile[num12].timeLeft = 300;
						}
					}
				}
				else if (ai0 >= (float)(300 + Main.rand.Next(300)))
				{
					ai0 = 0f;
				}
			}
		}

		private unsafe void KingSlimeAI()
		{
			aiAction = 0;
			if (ai3 == 0f && life > 0)
			{
				ai3 = lifeMax;
			}
			if (ai2 == 0f)
			{
				ai0 = -100f;
				ai2 = 1f;
				TargetClosest();
			}
			if (velocity.Y == 0f)
			{
				velocity.X *= 0.8f;
				if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
				{
					velocity.X = 0f;
				}
				double num = (double)life / (double)lifeMax;
				if (num < 0.1)
				{
					ai0 += 13f;
				}
				else if (num < 0.2)
				{
					ai0 += 9f;
				}
				else if (num < 0.4)
				{
					ai0 += 6f;
				}
				else if (num < 0.6)
				{
					ai0 += 4f;
				}
				else if (num < 0.8)
				{
					ai0 += 3f;
				}
				else
				{
					ai0 += 2f;
				}
				if (ai0 >= 0f)
				{
					netUpdate = true;
					TargetClosest();
					if (ai1 == 3f)
					{
						velocity.Y = -13f;
						velocity.X += 3.5f * (float)direction;
						ai0 = -200f;
						ai1 = 0f;
					}
					else if (ai1 == 2f)
					{
						velocity.Y = -6f;
						velocity.X += 4.5f * (float)direction;
						ai0 = -120f;
						ai1 += 1f;
					}
					else
					{
						velocity.Y = -8f;
						velocity.X += 4f * (float)direction;
						ai0 = -120f;
						ai1 += 1f;
					}
				}
				else if (ai0 >= -30f)
				{
					aiAction = 1;
				}
			}
			else if (target < 8 && ((direction == 1 && velocity.X < 3f) || (direction == -1 && velocity.X > -3f)))
			{
				if ((direction == -1 && (double)velocity.X < 0.1) || (direction == 1 && (double)velocity.X > -0.1))
				{
					velocity.X += 0.2f * (float)direction;
				}
				else
				{
					velocity.X *= 0.93f;
				}
			}
			Dust* ptr = Main.dust.NewDust(4, ref aabb, velocity.X, velocity.Y, 255, new Color(0, 80, 255, 80), scale * 1.2f);
			if (ptr != null)
			{
				ptr->noGravity = true;
				ptr->velocity.X *= 0.5f;
				ptr->velocity.Y *= 0.5f;
			}
			if (life <= 0)
			{
				return;
			}
			float num2 = (float)life / (float)lifeMax;
			num2 = num2 * 0.5f + 0.75f;
			if (num2 != scale)
			{
				position.X += width >> 1;
				position.Y += (int)height;
				scale = num2;
				width = (ushort)(98f * scale);
				height = (ushort)(92f * scale);
				position.X -= width >> 1;
				position.Y -= (int)height;
				aabb.X = (int)position.X;
				aabb.Y = (int)position.Y;
				aabb.Width = width;
				aabb.Height = height;
			}
			if (Main.netMode == 1)
			{
				return;
			}
			int num3 = (int)((double)lifeMax * 0.05);
			if (!((float)(life + num3) < ai3))
			{
				return;
			}
			ai3 = life;
			int num4 = Main.rand.Next(1, 4);
			for (int i = 0; i < num4; i++)
			{
				int x = aabb.X + Main.rand.Next(width - 32);
				int y = aabb.Y + Main.rand.Next(height - 32);
				int num5 = NewNPC(x, y, 1);
				if (num5 < 196)
				{
					Main.npc[num5].SetDefaults(1);
					Main.npc[num5].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
					Main.npc[num5].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
					Main.npc[num5].ai1 = Main.rand.Next(3);
					NetMessage.CreateMessage1(23, num5);
					NetMessage.SendMessage();
				}
			}
		}

		private void FishAI()
		{
			if (direction == 0)
			{
				TargetClosest();
			}
			if (wet)
			{
				bool flag = false;
				if (type != 55)
				{
					TargetClosest(faceTarget: false);
					if (Main.player[target].wet && !Main.player[target].dead)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					if (collideX)
					{
						velocity.X = 0f - velocity.X;
						direction = (sbyte)(-direction);
						netUpdate = true;
					}
					if (collideY)
					{
						netUpdate = true;
						velocity.Y = 0f - velocity.Y;
						if (velocity.Y < 0f)
						{
							directionY = -1;
							ai0 = -1f;
						}
						else if (velocity.Y > 0f)
						{
							directionY = 1;
							ai0 = 1f;
						}
					}
				}
				if (type == 102)
				{
					Lighting.addLight(aabb.X + (width >> 1) + direction * (width + 8) >> 4, aabb.Y + 2 >> 4, new Vector3(0.07f, 0.04f, 0.025f));
				}
				if (flag)
				{
					TargetClosest();
					if (type == 65 || type == 102 || type == 148)
					{
						velocity.X += (float)direction * 0.15f;
						velocity.Y += (float)directionY * 0.15f;
						if (velocity.X > 5f)
						{
							velocity.X = 5f;
						}
						else if (velocity.X < -5f)
						{
							velocity.X = -5f;
						}
						if (velocity.Y > 3f)
						{
							velocity.Y = 3f;
						}
						else if (velocity.Y < -3f)
						{
							velocity.Y = -3f;
						}
					}
					else
					{
						velocity.X += (float)direction * 0.1f;
						velocity.Y += (float)directionY * 0.1f;
						if (velocity.X > 3f)
						{
							velocity.X = 3f;
						}
						else if (velocity.X < -3f)
						{
							velocity.X = -3f;
						}
						if (velocity.Y > 2f)
						{
							velocity.Y = 2f;
						}
						else if (velocity.Y < -2f)
						{
							velocity.Y = -2f;
						}
					}
				}
				else
				{
					velocity.X += (float)direction * 0.1f;
					if (velocity.X < -1f || velocity.X > 1f)
					{
						velocity.X *= 0.95f;
					}
					if (ai0 == -1f)
					{
						velocity.Y -= 0.01f;
						if ((double)velocity.Y < -0.3)
						{
							ai0 = 1f;
						}
					}
					else
					{
						velocity.Y += 0.01f;
						if ((double)velocity.Y > 0.3)
						{
							ai0 = -1f;
						}
					}
					int num = aabb.X + (width >> 1) >> 4;
					int num2 = aabb.Y + (height >> 1) >> 4;
					if (Main.tile[num, num2 - 1].liquid > 128)
					{
						if (Main.tile[num, num2 + 1].active != 0)
						{
							ai0 = -1f;
						}
						else if (Main.tile[num, num2 + 2].active != 0)
						{
							ai0 = -1f;
						}
					}
					if ((double)velocity.Y > 0.4 || (double)velocity.Y < -0.4)
					{
						velocity.Y *= 0.95f;
					}
				}
			}
			else
			{
				if (velocity.Y == 0f)
				{
					if (type == 65 || type == 148)
					{
						velocity.X *= 0.94f;
						if (velocity.X > -0.2f && velocity.X < 0.2f)
						{
							velocity.X = 0f;
						}
					}
					else if (Main.netMode != 1)
					{
						velocity.Y = (float)Main.rand.Next(-50, -20) * 0.1f;
						velocity.X = (float)Main.rand.Next(-20, 20) * 0.1f;
						netUpdate = true;
					}
				}
				velocity.Y += 0.3f;
				if (velocity.Y > 10f)
				{
					velocity.Y = 10f;
				}
				ai0 = 1f;
			}
			rotation = velocity.Y * (float)direction * 0.1f;
			if (rotation < -0.2f)
			{
				rotation = -0.2f;
			}
			else if (rotation > 0.2f)
			{
				rotation = 0.2f;
			}
		}

		private void VultureAI()
		{
			noGravity = true;
			if (ai0 == 0f)
			{
				noGravity = false;
				TargetClosest();
				if (Main.netMode != 1)
				{
					if (velocity.X != 0f || velocity.Y < 0f || velocity.Y > 0.3f)
					{
						ai0 = 1f;
						netUpdate = true;
					}
					else if (life < lifeMax || Main.player[target].aabb.Intersects(new Rectangle(aabb.X - 100, aabb.Y - 100, width + 200, height + 200)))
					{
						ai0 = 1f;
						velocity.Y -= 6f;
						netUpdate = true;
					}
				}
			}
			else if (!Main.player[target].dead)
			{
				if (collideX)
				{
					velocity.X = oldVelocity.X * -0.5f;
					if (direction == -1 && velocity.X > 0f && velocity.X < 2f)
					{
						velocity.X = 2f;
					}
					else if (direction == 1 && velocity.X < 0f && velocity.X > -2f)
					{
						velocity.X = -2f;
					}
				}
				if (collideY)
				{
					velocity.Y = oldVelocity.Y * -0.5f;
					if (velocity.Y > 0f && velocity.Y < 1f)
					{
						velocity.Y = 1f;
					}
					else if (velocity.Y < 0f && velocity.Y > -1f)
					{
						velocity.Y = -1f;
					}
				}
				TargetClosest();
				if (direction == -1 && velocity.X > -3f)
				{
					velocity.X -= 0.1f;
					if (velocity.X > 3f)
					{
						velocity.X -= 0.1f;
					}
					else if (velocity.X > 0f)
					{
						velocity.X -= 0.05f;
					}
					else if (velocity.X < -3f)
					{
						velocity.X = -3f;
					}
				}
				else if (direction == 1 && velocity.X < 3f)
				{
					velocity.X += 0.1f;
					if (velocity.X < -3f)
					{
						velocity.X += 0.1f;
					}
					else if (velocity.X < 0f)
					{
						velocity.X += 0.05f;
					}
					else if (velocity.X > 3f)
					{
						velocity.X = 3f;
					}
				}
				int num = Math.Abs(aabb.X + (width >> 1) - (Main.player[target].aabb.X + 10));
				int num2 = Main.player[target].aabb.Y - (height >> 1);
				if (num > 50)
				{
					num2 -= 100;
				}
				if (aabb.Y < num2)
				{
					velocity.Y += 0.05f;
					if (velocity.Y < 0f)
					{
						velocity.Y += 0.01f;
					}
				}
				else
				{
					velocity.Y -= 0.05f;
					if (velocity.Y > 0f)
					{
						velocity.Y -= 0.01f;
					}
				}
				if (velocity.Y < -3f)
				{
					velocity.Y = -3f;
				}
				if (velocity.Y > 3f)
				{
					velocity.Y = 3f;
				}
			}
			if (wet)
			{
				if (velocity.Y > 0f)
				{
					velocity.Y *= 0.95f;
				}
				velocity.Y -= 0.5f;
				if (velocity.Y < -4f)
				{
					velocity.Y = -4f;
				}
				TargetClosest();
			}
		}

		private void JellyfishAI()
		{
			Lighting.addLight(rgb: (type == 63) ? new Vector3(0.05f, 0.15f, 0.4f) : ((type == 103) ? new Vector3(0.05f, 0.45f, 0.1f) : new Vector3(0.35f, 0.05f, 0.2f)), i: aabb.X + (height >> 1) >> 4, j: aabb.Y + (height >> 1) >> 4);
			if (direction == 0)
			{
				TargetClosest();
			}
			if (wet)
			{
				if (collideX)
				{
					velocity.X = 0f - velocity.X;
					direction = (sbyte)(-direction);
				}
				if (collideY)
				{
					velocity.Y = 0f - velocity.Y;
					if (velocity.Y < 0f)
					{
						directionY = -1;
						ai0 = -1f;
					}
					else if (velocity.Y > 0f)
					{
						directionY = 1;
						ai0 = 1f;
					}
				}
				bool flag = false;
				if (!friendly)
				{
					TargetClosest(faceTarget: false);
					if (Main.player[target].wet && !Main.player[target].dead)
					{
						flag = true;
					}
				}
				if (flag)
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
					velocity.X *= 0.98f;
					velocity.Y *= 0.98f;
					float num = 0.2f;
					if (type == 103)
					{
						velocity.X *= 0.98f;
						velocity.Y *= 0.98f;
						num = 0.6f;
					}
					if (velocity.X > 0f - num && velocity.X < num && velocity.Y > 0f - num && velocity.Y < num)
					{
						TargetClosest();
						float num2 = (type == 103) ? 9 : 7;
						Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num3 = Main.player[target].position.X + 10f - vector.X;
						float num4 = Main.player[target].position.Y + 21f - vector.Y;
						float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
						num5 = num2 / num5;
						num3 *= num5;
						num4 *= num5;
						velocity.X = num3;
						velocity.Y = num4;
					}
					return;
				}
				velocity.X += (float)direction * 0.02f;
				rotation = velocity.X * 0.4f;
				if (velocity.X < -1f || velocity.X > 1f)
				{
					velocity.X *= 0.95f;
				}
				if (ai0 == -1f)
				{
					velocity.Y -= 0.01f;
					if (velocity.Y < -1f)
					{
						ai0 = 1f;
					}
				}
				else
				{
					velocity.Y += 0.01f;
					if (velocity.Y > 1f)
					{
						ai0 = -1f;
					}
				}
				int num6 = aabb.X + (width >> 1) >> 4;
				int num7 = aabb.Y + (height >> 1) >> 4;
				if (Main.tile[num6, num7 - 1].liquid > 128)
				{
					if (Main.tile[num6, num7 + 1].active != 0)
					{
						ai0 = -1f;
					}
					else if (Main.tile[num6, num7 + 2].active != 0)
					{
						ai0 = -1f;
					}
				}
				else
				{
					ai0 = 1f;
				}
				if ((double)velocity.Y > 1.2 || (double)velocity.Y < -1.2)
				{
					velocity.Y *= 0.99f;
				}
				return;
			}
			rotation += velocity.X * 0.1f;
			if (velocity.Y == 0f)
			{
				velocity.X *= 0.98f;
				if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
				{
					velocity.X = 0f;
				}
			}
			velocity.Y += 0.2f;
			if (velocity.Y > 10f)
			{
				velocity.Y = 10f;
			}
			ai0 = 1f;
		}

		private unsafe void AntlionAI()
		{
			TargetClosest();
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = Main.player[target].position.X + 10f - vector.X;
			float num2 = Main.player[target].position.Y - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			num3 = 12f / num3;
			num *= num3;
			num2 *= num3;
			bool flag = false;
			if (directionY < 0)
			{
				rotation = (float)(Math.Atan2(num2, num) + 1.57);
				flag = ((!((double)rotation < -1.2) && !((double)rotation > 1.2)) ? true : false);
				if ((double)rotation < -0.8)
				{
					rotation = -0.8f;
				}
				else if ((double)rotation > 0.8)
				{
					rotation = 0.8f;
				}
				if (velocity.X != 0f)
				{
					velocity.X *= 0.9f;
					if ((double)velocity.X > -0.1 || (double)velocity.X < 0.1)
					{
						netUpdate = true;
						velocity.X = 0f;
					}
				}
			}
			if (ai0 > 0f)
			{
				if (ai0 == 200f)
				{
					Main.PlaySound(2, aabb.X, aabb.Y, 5);
				}
				ai0 -= 1f;
			}
			if (Main.netMode != 1 && flag && ai0 == 0f && Collision.CanHit(ref aabb, ref Main.player[target].aabb))
			{
				ai0 = 200f;
				int num4 = 10;
				int num5 = 31;
				int num6 = Projectile.NewProjectile(vector.X, vector.Y, num, num2, num5, num4, 0f, 8, send: false);
				if (num6 >= 0)
				{
					Main.projectile[num6].ai0 = 2f;
					Main.projectile[num6].timeLeft = 300;
					Main.projectile[num6].friendly = false;
					NetMessage.SendProjectile(num6);
					netUpdate = true;
				}
			}
			try
			{
				int num7 = aabb.X >> 4;
				int num8 = aabb.X + (width >> 1) >> 4;
				int num9 = aabb.X + width >> 4;
				int num10 = aabb.Y + height >> 4;
				if ((Main.tile[num7, num10].active != 0 && Main.tileSolid[Main.tile[num7, num10].type]) || (Main.tile[num8, num10].active != 0 && Main.tileSolid[Main.tile[num8, num10].type]) || (Main.tile[num9, num10].active != 0 && Main.tileSolid[Main.tile[num9, num10].type]))
				{
					noGravity = true;
					noTileCollide = true;
					velocity.Y = -0.2f;
				}
				else
				{
					noGravity = false;
					noTileCollide = false;
					if (Main.rand.Next(3) == 0)
					{
						Dust* ptr = Main.dust.NewDust(aabb.X - 4, aabb.Y + height - 8, width + 8, 24, 32, 0.0, velocity.Y * 0.5f);
						if (ptr != null)
						{
							ptr->velocity.X *= 0.4f;
							ptr->velocity.Y *= -1f;
							if (Main.rand.Next(2) == 0)
							{
								ptr->noGravity = true;
								ptr->scale += 0.2f;
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		private void SpinningSpikeballAI()
		{
			if (ai0 == 0f)
			{
				if (Main.netMode != 1)
				{
					TargetClosest();
					direction = (sbyte)(-direction);
					directionY = (sbyte)(-directionY);
					position.Y += (height >> 1) + 8;
					ai1 = position.X + (float)(width >> 1);
					ai2 = position.Y + (float)(height >> 1);
					if (direction == 0)
					{
						direction = 1;
					}
					if (directionY == 0)
					{
						directionY = 1;
					}
					ai3 = 1f + (float)Main.rand.Next(15) * 0.1f;
					velocity.Y = (float)(directionY * 6) * ai3;
					ai0 += 1f;
					netUpdate = true;
				}
				else
				{
					ai1 = position.X + (float)(width >> 1);
					ai2 = position.Y + (float)(height >> 1);
				}
				return;
			}
			float num = 6f * ai3;
			float num2 = 0.2f * ai3;
			float num3 = num / num2 * 0.5f;
			if (ai0 >= 1f && ai0 < (float)(int)num3)
			{
				velocity.Y = (float)directionY * num;
				ai0 += 1f;
				return;
			}
			if (ai0 >= (float)(int)num3)
			{
				netUpdate = true;
				velocity.Y = 0f;
				directionY = (sbyte)(-directionY);
				velocity.X = num * (float)direction;
				ai0 = -1f;
				return;
			}
			if (directionY > 0)
			{
				if (velocity.Y >= num)
				{
					netUpdate = true;
					directionY = (sbyte)(-directionY);
					velocity.Y = num;
				}
			}
			else if (directionY < 0 && velocity.Y <= 0f - num)
			{
				directionY = (sbyte)(-directionY);
				velocity.Y = 0f - num;
			}
			if (direction > 0)
			{
				if (velocity.X >= num)
				{
					direction = (sbyte)(-direction);
					velocity.X = num;
				}
			}
			else if (direction < 0 && velocity.X <= 0f - num)
			{
				direction = (sbyte)(-direction);
				velocity.X = 0f - num;
			}
			velocity.X += num2 * (float)direction;
			velocity.Y += num2 * (float)directionY;
		}

		private void GravityDiskAI()
		{
			if (ai0 == 0f)
			{
				TargetClosest();
				directionY = 1;
				ai0 = 1f;
			}
			int num = 6;
			if (ai1 == 0f)
			{
				rotation += (float)(direction * directionY) * 0.13f;
				if (collideY)
				{
					ai0 = 2f;
				}
				if (!collideY && ai0 == 2f)
				{
					direction = (sbyte)(-direction);
					ai1 = 1f;
					ai0 = 1f;
				}
				if (collideX)
				{
					directionY = (sbyte)(-directionY);
					ai1 = 1f;
				}
			}
			else
			{
				rotation -= (float)(direction * directionY) * 0.13f;
				if (collideX)
				{
					ai0 = 2f;
				}
				if (!collideX && ai0 == 2f)
				{
					directionY = (sbyte)(-directionY);
					ai1 = 0f;
					ai0 = 1f;
				}
				if (collideY)
				{
					direction = (sbyte)(-direction);
					ai1 = 0f;
				}
			}
			velocity.X = num * direction;
			velocity.Y = num * directionY;
			float num2 = (float)(270 - UI.mouseTextBrightness) * 0.0025f;
			Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, new Vector3(0.9f, 0.3f + num2, 0.2f));
		}

		private unsafe void MoreFlyerAI()
		{
			bool flag = false;
			if (justHit)
			{
				ai2 = 0f;
			}
			if (ai2 >= 0f)
			{
				float num = 16f;
				bool flag2 = false;
				bool flag3 = false;
				if (position.X > ai0 - num && position.X < ai0 + num)
				{
					flag2 = true;
				}
				else if ((velocity.X < 0f && direction > 0) || (velocity.X > 0f && direction < 0))
				{
					flag2 = true;
				}
				num += 24f;
				if (position.Y > ai1 - num && position.Y < ai1 + num)
				{
					flag3 = true;
				}
				if (flag2 && flag3)
				{
					ai2 += 1f;
					if (ai2 >= 30f && num == 16f)
					{
						flag = true;
					}
					if (ai2 >= 60f)
					{
						ai2 = -200f;
						direction = (sbyte)(-direction);
						velocity.X = 0f - velocity.X;
						collideX = false;
					}
				}
				else
				{
					ai0 = position.X;
					ai1 = position.Y;
					ai2 = 0f;
				}
				TargetClosest();
			}
			else
			{
				ai2 += 1f;
				if (Main.player[target].aabb.X + 10 > aabb.X + (width >> 1))
				{
					direction = -1;
				}
				else
				{
					direction = 1;
				}
			}
			int num2 = (aabb.X + (width >> 1) >> 4) + (direction << 1);
			int num3 = aabb.Y + height >> 4;
			bool flag4 = true;
			bool flag5 = false;
			int num4 = 3;
			if (type == 122 || type == 153)
			{
				if (justHit)
				{
					ai3 = 0f;
					localAI1 = 0;
				}
				float num5 = 7f;
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num6 = Main.player[target].position.X + 10f - vector.X;
				float num7 = Main.player[target].position.Y + 21f - vector.Y;
				float num8 = (float)Math.Sqrt(num6 * num6 + num7 * num7);
				num8 = num5 / num8;
				num6 *= num8;
				num7 *= num8;
				if (Main.netMode != 1 && ai3 == 32f)
				{
					Projectile.NewProjectile(vector.X, vector.Y, num6, num7, 84, 25, 0f);
				}
				num4 = 8;
				if (ai3 > 0f)
				{
					ai3 += 1f;
					if (ai3 >= 64f)
					{
						ai3 = 0f;
					}
				}
				if (Main.netMode != 1 && ai3 == 0f)
				{
					localAI1++;
					if (localAI1 > 120 && Collision.CanHit(ref aabb, ref Main.player[target].aabb))
					{
						localAI1 = 0;
						ai3 = 1f;
						netUpdate = true;
					}
				}
			}
			else if (type == 75)
			{
				num4 = 4;
				if (Main.rand.Next(7) == 0)
				{
					Dust* ptr = Main.dust.NewDust(55, ref aabb, 0.0, 0.0, 200, color);
					if (ptr != null)
					{
						ptr->velocity.X *= 0.3f;
						ptr->velocity.Y *= 0.3f;
					}
				}
				if (Main.rand.Next(42) == 0)
				{
					Main.PlaySound(27, aabb.X, aabb.Y);
				}
			}
			for (int i = num3; i < num3 + num4; i++)
			{
				if ((Main.tile[num2, i].active != 0 && Main.tileSolid[Main.tile[num2, i].type]) || Main.tile[num2, i].liquid > 0)
				{
					if (i <= num3 + 1)
					{
						flag5 = true;
					}
					flag4 = false;
					break;
				}
			}
			if (flag)
			{
				flag5 = false;
				flag4 = true;
			}
			if (flag4)
			{
				if (type == 75)
				{
					velocity.Y += 0.2f;
					if (velocity.Y > 2f)
					{
						velocity.Y = 2f;
					}
				}
				else
				{
					velocity.Y += 0.1f;
					if (velocity.Y > 3f)
					{
						velocity.Y = 3f;
					}
				}
			}
			else
			{
				if (type == 75)
				{
					if ((directionY < 0 && velocity.Y > 0f) || flag5)
					{
						velocity.Y -= 0.2f;
					}
				}
				else if (directionY < 0 && velocity.Y > 0f)
				{
					velocity.Y -= 0.1f;
				}
				if (velocity.Y < -4f)
				{
					velocity.Y = -4f;
				}
			}
			if (type == 75 && wet)
			{
				velocity.Y -= 0.2f;
				if (velocity.Y < -2f)
				{
					velocity.Y = -2f;
				}
			}
			if (collideX)
			{
				velocity.X = oldVelocity.X * -0.4f;
				if (direction == -1 && velocity.X > 0f && velocity.X < 1f)
				{
					velocity.X = 1f;
				}
				else if (direction == 1 && velocity.X < 0f && velocity.X > -1f)
				{
					velocity.X = -1f;
				}
			}
			if (collideY)
			{
				velocity.Y = oldVelocity.Y * -0.25f;
				if (velocity.Y > 0f && velocity.Y < 1f)
				{
					velocity.Y = 1f;
				}
				else if (velocity.Y < 0f && velocity.Y > -1f)
				{
					velocity.Y = -1f;
				}
			}
			float num9 = (type == 75) ? 3 : 2;
			if (direction == -1 && velocity.X > 0f - num9)
			{
				velocity.X -= 0.1f;
				if (velocity.X > num9)
				{
					velocity.X -= 0.1f;
				}
				else if (velocity.X > 0f)
				{
					velocity.X += 0.05f;
				}
				else if (velocity.X < 0f - num9)
				{
					velocity.X = 0f - num9;
				}
			}
			else if (direction == 1 && velocity.X < num9)
			{
				velocity.X += 0.1f;
				if (velocity.X < 0f - num9)
				{
					velocity.X += 0.1f;
				}
				else if (velocity.X < 0f)
				{
					velocity.X -= 0.05f;
				}
				else if (velocity.X > num9)
				{
					velocity.X = num9;
				}
			}
			if (directionY == -1 && (double)velocity.Y > -1.5)
			{
				velocity.Y -= 0.04f;
				if ((double)velocity.Y > 1.5)
				{
					velocity.Y -= 0.05f;
				}
				else if (velocity.Y > 0f)
				{
					velocity.Y += 0.03f;
				}
				else if ((double)velocity.Y < -1.5)
				{
					velocity.Y = -1.5f;
				}
			}
			else if (directionY == 1 && (double)velocity.Y < 1.5)
			{
				velocity.Y += 0.04f;
				if ((double)velocity.Y < -1.5)
				{
					velocity.Y += 0.05f;
				}
				else if (velocity.Y < 0f)
				{
					velocity.Y -= 0.03f;
				}
				else if ((double)velocity.Y > 1.5)
				{
					velocity.Y = 1.5f;
				}
			}
			if (type == 122 || type == 153)
			{
				Lighting.addLight(aabb.X >> 4, aabb.Y >> 4, new Vector3(0.4f, 0f, 0.25f));
			}
		}

		private void EnchantedWeaponAI()
		{
			noGravity = true;
			noTileCollide = true;
			Vector3 rgb = new Vector3(0.05f, 0.2f, 0.3f);
			switch (type)
			{
			case 83:
				rgb = new Vector3(0.2f, 0.05f, 0.3f);
				break;
			case 151:
				rgb = new Vector3(0.3f, 0.05f, 0.2f);
				break;
			}
			Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, rgb);
			if (target == 8 || Main.player[target].dead)
			{
				TargetClosest();
			}
			if (ai0 == 0f)
			{
				float num = 9f;
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num2 = Main.player[target].position.X + 10f - vector.X;
				float num3 = Main.player[target].position.Y + 21f - vector.Y;
				float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				num4 = num / num4;
				num2 *= num4;
				num3 *= num4;
				velocity.X = num2;
				velocity.Y = num3;
				rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 0.785f;
				ai0 = 1f;
				ai1 = 0f;
				return;
			}
			if (ai0 == 1f)
			{
				if (justHit)
				{
					ai0 = 2f;
					ai1 = 0f;
				}
				velocity.X *= 0.99f;
				velocity.Y *= 0.99f;
				ai1 += 1f;
				if (ai1 >= 100f)
				{
					ai0 = 2f;
					ai1 = 0f;
					velocity.X = 0f;
					velocity.Y = 0f;
				}
				return;
			}
			if (justHit)
			{
				ai0 = 2f;
				ai1 = 0f;
			}
			velocity.X *= 0.96f;
			velocity.Y *= 0.96f;
			ai1 += 1f;
			float num5 = ai1 / 120f;
			num5 = 0.1f + num5 * 0.4f;
			rotation += num5 * (float)direction;
			if (ai1 >= 120f)
			{
				netUpdate = true;
				ai0 = 0f;
				ai1 = 0f;
			}
		}

		private void BirdAI()
		{
			noGravity = true;
			if (ai0 == 0f)
			{
				noGravity = false;
				TargetClosest();
				if (Main.netMode != 1)
				{
					if (velocity.X != 0f || velocity.Y < 0f || (double)velocity.Y > 0.3)
					{
						ai0 = 1f;
						netUpdate = true;
						direction = (sbyte)(-direction);
					}
					else if (life < lifeMax || Main.player[target].aabb.Intersects(new Rectangle(aabb.X - 100, aabb.Y - 100, width + 200, height + 200)))
					{
						ai0 = 1f;
						velocity.Y -= 6f;
						netUpdate = true;
						direction = (sbyte)(-direction);
					}
				}
			}
			else if (!Main.player[target].dead)
			{
				if (collideX)
				{
					direction = (sbyte)(-direction);
					velocity.X = oldVelocity.X * -0.5f;
					if (direction == -1 && velocity.X > 0f && velocity.X < 2f)
					{
						velocity.X = 2f;
					}
					else if (direction == 1 && velocity.X < 0f && velocity.X > -2f)
					{
						velocity.X = -2f;
					}
				}
				if (collideY)
				{
					velocity.Y = oldVelocity.Y * -0.5f;
					if (velocity.Y > 0f && velocity.Y < 1f)
					{
						velocity.Y = 1f;
					}
					else if (velocity.Y < 0f && velocity.Y > -1f)
					{
						velocity.Y = -1f;
					}
				}
				if (direction == -1 && velocity.X > -3f)
				{
					velocity.X -= 0.1f;
					if (velocity.X > 3f)
					{
						velocity.X -= 0.1f;
					}
					else if (velocity.X > 0f)
					{
						velocity.X -= 0.05f;
					}
					else if (velocity.X < -3f)
					{
						velocity.X = -3f;
					}
				}
				else if (direction == 1 && velocity.X < 3f)
				{
					velocity.X += 0.1f;
					if (velocity.X < -3f)
					{
						velocity.X += 0.1f;
					}
					else if (velocity.X < 0f)
					{
						velocity.X += 0.05f;
					}
					else if (velocity.X > 3f)
					{
						velocity.X = 3f;
					}
				}
				int num = (aabb.X + (width >> 1) >> 4) + direction;
				int num2 = aabb.Y + height >> 4;
				bool flag = true;
				bool flag2 = false;
				try
				{
					for (int i = num2; i < num2 + 15; i++)
					{
						if ((Main.tile[num, i].active != 0 && Main.tileSolid[Main.tile[num, i].type]) || Main.tile[num, i].liquid > 0)
						{
							if (i < num2 + 5)
							{
								flag2 = true;
							}
							flag = false;
							break;
						}
					}
				}
				catch
				{
					flag2 = true;
					flag = false;
				}
				if (flag)
				{
					velocity.Y += 0.1f;
				}
				else
				{
					velocity.Y -= 0.1f;
				}
				if (flag2)
				{
					velocity.Y -= 0.2f;
				}
				if (velocity.Y > 3f)
				{
					velocity.Y = 3f;
				}
				else if (velocity.Y < -4f)
				{
					velocity.Y = -4f;
				}
			}
			if (wet)
			{
				if (velocity.Y > 0f)
				{
					velocity.Y *= 0.95f;
				}
				velocity.Y -= 0.5f;
				if (velocity.Y < -4f)
				{
					velocity.Y = -4f;
				}
				TargetClosest();
			}
		}

		private void MimicAI()
		{
			if (ai3 == 0f)
			{
				position.X += 8f;
				aabb.X += 8;
				int num = aabb.Y >> 4;
				if (num > Main.maxTilesY - 200)
				{
					ai3 = 3f;
				}
				else if (num > Main.worldSurface)
				{
					ai3 = 2f;
				}
				else
				{
					ai3 = 1f;
				}
			}
			if (ai0 == 0f)
			{
				TargetClosest();
				if (Main.netMode != 1)
				{
					if (velocity.X != 0f || velocity.Y < 0f || (double)velocity.Y > 0.3)
					{
						ai0 = 1f;
						netUpdate = true;
					}
					else if (life < lifeMax || new Rectangle(aabb.X - 100, aabb.Y - 100, width + 200, height + 200).Intersects(Main.player[target].aabb))
					{
						ai0 = 1f;
						netUpdate = true;
					}
				}
			}
			else if (velocity.Y == 0f)
			{
				ai2 += 1f;
				int num2 = 20;
				if (ai1 == 0f)
				{
					num2 = 12;
				}
				if (ai2 < (float)num2)
				{
					velocity.X *= 0.9f;
					return;
				}
				ai2 = 0f;
				TargetClosest();
				spriteDirection = direction;
				ai1 += 1f;
				if (ai1 == 2f)
				{
					velocity.X = (float)direction * 2.5f;
					velocity.Y = -8f;
					ai1 = 0f;
				}
				else
				{
					velocity.X = (float)direction * 3.5f;
					velocity.Y = -4f;
				}
				netUpdate = true;
			}
			else if (direction == 1 && velocity.X < 1f)
			{
				velocity.X += 0.1f;
			}
			else if (direction == -1 && velocity.X > -1f)
			{
				velocity.X -= 0.1f;
			}
		}

		private void UnicornAI()
		{
			int num = 30;
			bool flag = false;
			if (velocity.Y == 0f && ((velocity.X > 0f && direction < 0) || (velocity.X < 0f && direction > 0)))
			{
				flag = true;
				ai3 += 1f;
			}
			if (position.X == oldPosition.X || ai3 >= (float)num || flag)
			{
				ai3 += 1f;
			}
			else if (ai3 > 0f)
			{
				ai3 -= 1f;
			}
			if (ai3 > (float)(num * 10))
			{
				ai3 = 0f;
			}
			if (justHit)
			{
				ai3 = 0f;
			}
			if (ai3 == (float)num)
			{
				netUpdate = true;
			}
			if (ai3 < (float)num)
			{
				TargetClosest();
			}
			else
			{
				if (velocity.X == 0f)
				{
					if (velocity.Y == 0f)
					{
						ai0 += 1f;
						if (ai0 >= 2f)
						{
							direction = (sbyte)(-direction);
							spriteDirection = direction;
							ai0 = 0f;
						}
					}
				}
				else
				{
					ai0 = 0f;
				}
				directionY = -1;
				if (direction == 0)
				{
					direction = 1;
				}
			}
			if (velocity.Y == 0f || wet || (velocity.X <= 0f && direction < 0) || (velocity.X >= 0f && direction > 0))
			{
				if (velocity.X < -6f || velocity.X > 6f)
				{
					if (velocity.Y == 0f)
					{
						velocity.X *= 0.8f;
					}
				}
				else if (velocity.X < 6f && direction == 1)
				{
					velocity.X += 0.07f;
					if (velocity.X > 6f)
					{
						velocity.X = 6f;
					}
				}
				else if (velocity.X > -6f && direction == -1)
				{
					velocity.X -= 0.07f;
					if (velocity.X < -6f)
					{
						velocity.X = -6f;
					}
				}
			}
			if (velocity.Y != 0f)
			{
				return;
			}
			int num2 = (int)(position.X + velocity.X * 5f) + (width >> 1) + ((width >> 1) + 2) * direction >> 4;
			int num3 = aabb.Y + height - 15 >> 4;
			if ((!(velocity.X < 0f) || spriteDirection != -1) && (!(velocity.X > 0f) || spriteDirection != 1))
			{
				return;
			}
			if (Main.tile[num2, num3 - 2].active != 0 && Main.tileSolid[Main.tile[num2, num3 - 2].type])
			{
				if (Main.tile[num2, num3 - 3].active != 0 && Main.tileSolid[Main.tile[num2, num3 - 3].type])
				{
					velocity.Y = -8.5f;
					netUpdate = true;
				}
				else
				{
					velocity.Y = -7.5f;
					netUpdate = true;
				}
			}
			else if (Main.tile[num2, num3 - 1].active != 0 && Main.tileSolid[Main.tile[num2, num3 - 1].type])
			{
				velocity.Y = -7f;
				netUpdate = true;
			}
			else if (Main.tile[num2, num3].active != 0 && Main.tileSolid[Main.tile[num2, num3].type])
			{
				velocity.Y = -6f;
				netUpdate = true;
			}
			else if ((directionY < 0 || Math.Abs(velocity.X) > 3f) && (Main.tile[num2, num3 + 1].active == 0 || !Main.tileSolid[Main.tile[num2, num3 + 1].type]) && (Main.tile[num2 + direction, num3 + 1].active == 0 || !Main.tileSolid[Main.tile[num2 + direction, num3 + 1].type]))
			{
				velocity.Y = -8f;
				netUpdate = true;
			}
		}

		private void WallOfFleshMouthAI()
		{
			if (aabb.X < 160 || aabb.X > (Main.maxTilesX - 10) * 16)
			{
				active = 0;
				return;
			}
			if (localAI0 == 0)
			{
				localAI0 = 1;
				wofB = -1;
				wofT = -1;
			}
			ai1 += 1f;
			if (ai2 == 0f)
			{
				if ((double)life < (double)lifeMax * 0.5)
				{
					ai1 += 1f;
				}
				if ((double)life < (double)lifeMax * 0.2)
				{
					ai1 += 1f;
				}
				if (ai1 > 2700f)
				{
					ai2 = 1f;
				}
			}
			if (ai2 > 0f && ai1 > 60f)
			{
				int num = 3;
				if ((double)life < (double)lifeMax * 0.3)
				{
					num++;
				}
				ai2 += 1f;
				ai1 = 0f;
				if (ai2 > (float)num)
				{
					ai2 = 0f;
				}
				if (Main.netMode != 1)
				{
					int num2 = NewNPC(aabb.X + (width >> 1), aabb.Y + (height >> 1) + 20, 117, 1);
					Main.npc[num2].velocity.X = direction << 3;
				}
			}
			localAI3++;
			if (localAI3 >= 600 + Main.rand.Next(1000))
			{
				localAI3 = -Main.rand.Next(200);
				Main.PlaySound(4, aabb.X, aabb.Y, 10);
			}
			wof = whoAmI;
			int num3 = aabb.X >> 4;
			int num4 = aabb.X + width >> 4;
			int num5 = aabb.Y + (height >> 1) >> 4;
			int num6 = 0;
			int num7 = num5 + 7;
			while (num6 < 15 && num7 < Main.maxTilesY - 10)
			{
				num7++;
				for (int i = num3; i <= num4; i++)
				{
					try
					{
						if (WorldGen.SolidTile(i, num7) || Main.tile[i, num7].liquid > 0)
						{
							num6++;
						}
					}
					catch
					{
						num6 += 15;
					}
				}
			}
			num7 += 4;
			if (wofB == -1)
			{
				wofB = num7 * 16;
			}
			else if (wofB > num7 * 16)
			{
				wofB--;
				if (wofB < num7 * 16)
				{
					wofB = num7 * 16;
				}
			}
			else if (wofB < num7 * 16)
			{
				wofB++;
				if (wofB > num7 * 16)
				{
					wofB = num7 * 16;
				}
			}
			num6 = 0;
			num7 = num5 - 7;
			while (num6 < 15 && num7 > Main.maxTilesY - 200)
			{
				num7--;
				for (int j = num3; j <= num4; j++)
				{
					try
					{
						if (WorldGen.SolidTile(j, num7) || Main.tile[j, num7].liquid > 0)
						{
							num6++;
						}
					}
					catch
					{
						num6 += 15;
					}
				}
			}
			num7 -= 4;
			if (wofT == -1)
			{
				wofT = num7 * 16;
			}
			else if (wofT > num7 * 16)
			{
				wofT--;
				if (wofT < num7 * 16)
				{
					wofT = num7 * 16;
				}
			}
			else if (wofT < num7 * 16)
			{
				wofT++;
				if (wofT > num7 * 16)
				{
					wofT = num7 * 16;
				}
			}
			int num8 = (wofB + wofT >> 1) - (height >> 1);
			velocity.Y = 0f;
			position.Y = num8;
			aabb.Y = num8;
			float num9 = 1.5f;
			if (life < (lifeMax >> 1) + (lifeMax >> 2))
			{
				num9 += 0.25f;
			}
			if (life < lifeMax >> 1)
			{
				num9 += 0.4f;
			}
			if (life < lifeMax >> 2)
			{
				num9 += 0.5f;
			}
			if (life < lifeMax / 10)
			{
				num9 += 0.6f;
			}
			if (velocity.X == 0f)
			{
				TargetClosest();
				velocity.X = direction;
			}
			if (velocity.X < 0f)
			{
				velocity.X = 0f - num9;
				direction = -1;
			}
			else
			{
				velocity.X = num9;
				direction = 1;
			}
			spriteDirection = direction;
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num10 = Main.player[target].position.X + 10f - vector.X;
			float num11 = Main.player[target].position.Y + 21f - vector.Y;
			float num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
			num10 *= num12;
			num11 *= num12;
			if (direction > 0)
			{
				if (Main.player[target].aabb.X + 10 > aabb.X + (width >> 1))
				{
					rotation = (float)Math.Atan2(0f - num11, 0f - num10) + 3.14f;
				}
				else
				{
					rotation = 0f;
				}
			}
			else if (Main.player[target].aabb.X + 10 < aabb.X + (width >> 1))
			{
				rotation = (float)Math.Atan2(num11, num10) + 3.14f;
			}
			else
			{
				rotation = 0f;
			}
			if (localAI0 == 1 && Main.netMode != 1)
			{
				localAI0 = 2;
				num8 = wofB + wofT >> 1;
				num8 = num8 + wofT >> 1;
				int num13 = NewNPC(aabb.X, num8, 114, whoAmI);
				Main.npc[num13].ai0 = 1f;
				num8 = wofB + wofT >> 1;
				num8 = num8 + wofB >> 1;
				num13 = NewNPC(aabb.X, num8, 114, whoAmI);
				Main.npc[num13].ai0 = -1f;
				num8 = wofB + wofT >> 1;
				num8 = num8 + wofB >> 1;
				for (int k = 0; k < 11; k++)
				{
					num13 = NewNPC(aabb.X, num8, 115, whoAmI);
					Main.npc[num13].ai0 = (float)k * 0.1f - 0.05f;
				}
			}
		}

		private void WallOfFleshEyesAI()
		{
			if (wof < 0)
			{
				active = 0;
				return;
			}
			realLife = wof;
			TargetClosest();
			position.X = Main.npc[wof].position.X;
			aabb.X = Main.npc[wof].aabb.X;
			direction = Main.npc[wof].direction;
			spriteDirection = direction;
			int num = wofB + wofT >> 1;
			num = ((!(ai0 > 0f)) ? (num + wofB >> 1) : (num + wofT >> 1));
			num -= height >> 1;
			if (aabb.Y > num + 1)
			{
				velocity.Y = -1f;
			}
			else if (aabb.Y < num - 1)
			{
				velocity.Y = 1f;
			}
			else
			{
				velocity.Y = 0f;
				aabb.Y = num;
				position.Y = num;
			}
			if (velocity.Y > 5f)
			{
				velocity.Y = 5f;
			}
			else if (velocity.Y < -5f)
			{
				velocity.Y = -5f;
			}
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num2 = Main.player[target].position.X + 10f - vector.X;
			float num3 = Main.player[target].position.Y + 21f - vector.Y;
			float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
			num2 *= num4;
			num3 *= num4;
			bool flag = true;
			if (direction > 0)
			{
				if (Main.player[target].aabb.X + 10 > aabb.X + (width >> 1))
				{
					rotation = (float)Math.Atan2(0f - num3, 0f - num2) + 3.14f;
				}
				else
				{
					rotation = 0f;
					flag = false;
				}
			}
			else if (Main.player[target].aabb.X + 10 < aabb.X + (width >> 1))
			{
				rotation = (float)Math.Atan2(num3, num2) + 3.14f;
			}
			else
			{
				rotation = 0f;
				flag = false;
			}
			if (Main.netMode == 1)
			{
				return;
			}
			int num5 = 4;
			localAI1++;
			if ((double)Main.npc[wof].life < (double)Main.npc[wof].lifeMax * 0.75)
			{
				localAI1++;
				num5++;
			}
			if ((double)Main.npc[wof].life < (double)Main.npc[wof].lifeMax * 0.5)
			{
				localAI1++;
				num5++;
			}
			if ((double)Main.npc[wof].life < (double)Main.npc[wof].lifeMax * 0.25)
			{
				localAI1++;
				num5 += 2;
			}
			if ((double)Main.npc[wof].life < (double)Main.npc[wof].lifeMax * 0.1)
			{
				localAI1 += 2;
				num5 += 3;
			}
			if (localAI2 == 0)
			{
				if (localAI1 > 600)
				{
					localAI2 = 1;
					localAI1 = 0;
				}
			}
			else
			{
				if (localAI1 <= 45 || !Collision.CanHit(ref aabb, ref Main.player[target].aabb))
				{
					return;
				}
				localAI1 = 0;
				localAI2++;
				if (localAI2 >= num5)
				{
					localAI2 = 0;
				}
				if (flag)
				{
					float num6 = 9f;
					int num7 = 11;
					if ((double)Main.npc[wof].life < (double)Main.npc[wof].lifeMax * 0.5)
					{
						num7++;
						num6 += 1f;
					}
					if ((double)Main.npc[wof].life < (double)Main.npc[wof].lifeMax * 0.25)
					{
						num7++;
						num6 += 1f;
					}
					if ((double)Main.npc[wof].life < (double)Main.npc[wof].lifeMax * 0.1)
					{
						num7 += 2;
						num6 += 2f;
					}
					vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					num2 = Main.player[target].position.X + 10f - vector.X;
					num3 = Main.player[target].position.Y + 21f - vector.Y;
					num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
					num4 = num6 / num4;
					num2 *= num4;
					num3 *= num4;
					vector.X += num2;
					vector.Y += num3;
					Projectile.NewProjectile(vector.X, vector.Y, num2, num3, 83, num7, 0f);
				}
			}
		}

		private void WallOfFleshTentacleAI()
		{
			if (wof < 0)
			{
				active = 0;
				return;
			}
			if (justHit)
			{
				ai1 = 10f;
			}
			TargetClosest();
			float num = 0.1f;
			float num2 = 300f;
			if (Main.npc[wof].life < Main.npc[wof].lifeMax >> 2)
			{
				damage = 75;
				defense = 40;
				num2 = 900f;
			}
			else if (Main.npc[wof].life < Main.npc[wof].lifeMax >> 1)
			{
				damage = 60;
				defense = 30;
				num2 = 700f;
			}
			else if (Main.npc[wof].life < (Main.npc[wof].lifeMax >> 1) + (Main.npc[wof].lifeMax >> 2))
			{
				damage = 45;
				defense = 20;
				num2 = 500f;
			}
			float num3 = Main.npc[wof].position.X + (float)(Main.npc[wof].width >> 1);
			float y = Main.npc[wof].position.Y;
			float num4 = wofB - wofT;
			y = (float)wofT + num4 * ai0;
			ai2 += 1f;
			if (ai2 > 100f)
			{
				num2 = (int)(num2 * 1.3f);
				if (ai2 > 200f)
				{
					ai2 = 0f;
				}
			}
			Vector2 vector = new Vector2(num3, y);
			float num5 = Main.player[target].position.X + 10f - (float)(width >> 1) - vector.X;
			float num6 = Main.player[target].position.Y + 21f - (float)(height >> 1) - vector.Y;
			if (ai1 == 0f)
			{
				float num7 = num5 * num5 + num6 * num6;
				if (num7 > num2 * num2)
				{
					num7 = num2 / (float)Math.Sqrt(num7);
					num5 *= num7;
					num6 *= num7;
				}
				if (position.X < num3 + num5)
				{
					velocity.X += num;
					if (velocity.X < 0f && num5 > 0f)
					{
						velocity.X += num * 2.5f;
					}
				}
				else if (position.X > num3 + num5)
				{
					velocity.X -= num;
					if (velocity.X > 0f && num5 < 0f)
					{
						velocity.X -= num * 2.5f;
					}
				}
				if (position.Y < y + num6)
				{
					velocity.Y += num;
					if (velocity.Y < 0f && num6 > 0f)
					{
						velocity.Y += num * 2.5f;
					}
				}
				else if (position.Y > y + num6)
				{
					velocity.Y -= num;
					if (velocity.Y > 0f && num6 < 0f)
					{
						velocity.Y -= num * 2.5f;
					}
				}
				if (velocity.X > 4f)
				{
					velocity.X = 4f;
				}
				else if (velocity.X < -4f)
				{
					velocity.X = -4f;
				}
				if (velocity.Y > 4f)
				{
					velocity.Y = 4f;
				}
				else if (velocity.Y < -4f)
				{
					velocity.Y = -4f;
				}
			}
			else if (ai1 > 0f)
			{
				ai1 -= 1f;
			}
			else
			{
				ai1 = 0f;
			}
			if (num5 > 0f)
			{
				spriteDirection = 1;
				rotation = (float)Math.Atan2(num6, num5);
			}
			else if (num5 < 0f)
			{
				spriteDirection = -1;
				rotation = (float)(Math.Atan2(num6, num5) + Math.PI);
			}
			Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + (height >> 1) >> 4, new Vector3(0.3f, 0.2f, 0.1f));
		}

		private unsafe void RetinazerAI()
		{
			if (target == 8 || Main.player[target].dead || Main.player[target].active == 0)
			{
				TargetClosest();
			}
			bool dead = Main.player[target].dead;
			float num = position.X + (float)(width >> 1) - Main.player[target].position.X - 10f;
			float num2 = position.Y + (float)(int)height - 59f - Main.player[target].position.Y - 21f;
			float num3 = (float)Math.Atan2(num2, num) + 1.57f;
			if (num3 < 0f)
			{
				num3 += 6.283f;
			}
			else if (num3 > 6.283f)
			{
				num3 -= 6.283f;
			}
			if (rotation < num3)
			{
				if ((double)(num3 - rotation) > 3.1415)
				{
					rotation -= 0.1f;
				}
				else
				{
					rotation += 0.1f;
				}
			}
			else if (rotation > num3)
			{
				if ((double)(rotation - num3) > 3.1415)
				{
					rotation += 0.1f;
				}
				else
				{
					rotation -= 0.1f;
				}
			}
			if (rotation > num3 - 0.1f && rotation < num3 + 0.1f)
			{
				rotation = num3;
			}
			if (rotation < 0f)
			{
				rotation += 6.283f;
			}
			else if (rotation > 6.283f)
			{
				rotation -= 6.283f;
			}
			if (rotation > num3 - 0.1f && rotation < num3 + 0.1f)
			{
				rotation = num3;
			}
			if (Main.rand.Next(6) == 0)
			{
				Dust* ptr = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 5, velocity.X, 2.0);
				if (ptr != null)
				{
					ptr->velocity.X *= 0.5f;
					ptr->velocity.Y *= 0.1f;
				}
			}
			if (Main.gameTime.dayTime || dead)
			{
				velocity.Y -= 0.04f;
				if (timeLeft > 10)
				{
					timeLeft = 10;
				}
				return;
			}
			if (ai0 == 0f)
			{
				if (ai1 == 0f)
				{
					float num4 = 7f;
					float num5 = 0.1f;
					int num6 = 1;
					if (aabb.X + (width >> 1) < Main.player[target].aabb.X + 20)
					{
						num6 = -1;
					}
					Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num7 = Main.player[target].position.X + 10f + (float)(num6 * 300) - vector.X;
					float num8 = Main.player[target].position.Y + 21f - 300f - vector.Y;
					float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
					float num10 = num9;
					num9 = num4 / num9;
					num7 *= num9;
					num8 *= num9;
					if (velocity.X < num7)
					{
						velocity.X += num5;
						if (velocity.X < 0f && num7 > 0f)
						{
							velocity.X += num5;
						}
					}
					else if (velocity.X > num7)
					{
						velocity.X -= num5;
						if (velocity.X > 0f && num7 < 0f)
						{
							velocity.X -= num5;
						}
					}
					if (velocity.Y < num8)
					{
						velocity.Y += num5;
						if (velocity.Y < 0f && num8 > 0f)
						{
							velocity.Y += num5;
						}
					}
					else if (velocity.Y > num8)
					{
						velocity.Y -= num5;
						if (velocity.Y > 0f && num8 < 0f)
						{
							velocity.Y -= num5;
						}
					}
					ai2 += 1f;
					if (ai2 >= 600f)
					{
						ai1 = 1f;
						ai2 = 0f;
						ai3 = 0f;
						target = 8;
						netUpdate = true;
					}
					else if (aabb.Y + height < Main.player[target].aabb.Y && num10 < 400f)
					{
						if (!Main.player[target].dead)
						{
							ai3 += 1f;
						}
						if (ai3 >= 60f)
						{
							ai3 = 0f;
							vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
							num7 = Main.player[target].position.X + 10f - vector.X;
							num8 = Main.player[target].position.Y + 21f - vector.Y;
							if (Main.netMode != 1)
							{
								num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
								num9 = 9f / num9;
								num7 *= num9;
								num8 *= num9;
								num7 += (float)Main.rand.Next(-40, 41) * 0.08f;
								num8 += (float)Main.rand.Next(-40, 41) * 0.08f;
								vector.X += num7 * 15f;
								vector.Y += num8 * 15f;
								Projectile.NewProjectile(vector.X, vector.Y, num7, num8, 83, 20, 0f);
							}
						}
					}
				}
				else if (ai1 == 1f)
				{
					rotation = num3;
					float num11 = 12f;
					Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num12 = Main.player[target].position.X + 10f - vector2.X;
					float num13 = Main.player[target].position.Y + 21f - vector2.Y;
					float num14 = (float)Math.Sqrt(num12 * num12 + num13 * num13);
					num14 = num11 / num14;
					velocity.X = num12 * num14;
					velocity.Y = num13 * num14;
					ai1 = 2f;
				}
				else if (ai1 == 2f)
				{
					ai2 += 1f;
					if (ai2 >= 25f)
					{
						velocity.X *= 0.96f;
						velocity.Y *= 0.96f;
						if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
						{
							velocity.X = 0f;
						}
						if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
						{
							velocity.Y = 0f;
						}
					}
					else
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
					}
					if (ai2 >= 70f)
					{
						ai3 += 1f;
						ai2 = 0f;
						target = 8;
						rotation = num3;
						if (ai3 >= 4f)
						{
							ai1 = 0f;
							ai3 = 0f;
						}
						else
						{
							ai1 = 1f;
						}
					}
				}
				if ((double)life < (double)lifeMax * 0.5)
				{
					ai0 = 1f;
					ai1 = 0f;
					ai2 = 0f;
					ai3 = 0f;
					netUpdate = true;
				}
				return;
			}
			if (ai0 == 1f || ai0 == 2f)
			{
				if (ai0 == 1f)
				{
					ai2 += 0.005f;
					if ((double)ai2 > 0.5)
					{
						ai2 = 0.5f;
					}
				}
				else
				{
					ai2 -= 0.005f;
					if (ai2 < 0f)
					{
						ai2 = 0f;
					}
				}
				rotation += ai2;
				ai1 += 1f;
				if (ai1 == 100f)
				{
					ai0 += 1f;
					ai1 = 0f;
					if (ai0 == 3f)
					{
						ai2 = 0f;
					}
					else
					{
						Main.PlaySound(3, aabb.X, aabb.Y);
						Main.PlaySound(15, aabb.X, aabb.Y, 0);
						for (int i = 0; i < 2; i++)
						{
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 143);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6);
						}
						for (int j = 0; j < 16; j++)
						{
							if (null == Main.dust.NewDust(5, ref aabb, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f))
							{
								break;
							}
						}
					}
				}
				Main.dust.NewDust(5, ref aabb, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f);
				velocity.X *= 0.98f;
				velocity.Y *= 0.98f;
				if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
				{
					velocity.X = 0f;
				}
				if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
				{
					velocity.Y = 0f;
				}
				return;
			}
			damage = (int)((double)defDamage * 1.5);
			defense = defDefense + 15;
			soundHit = 4;
			if (ai1 == 0f)
			{
				float num15 = 8f;
				float num16 = 0.15f;
				Vector2 vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num17 = Main.player[target].position.X + 10f - vector3.X;
				float num18 = Main.player[target].position.Y + 21f - 300f - vector3.Y;
				float num19 = (float)Math.Sqrt(num17 * num17 + num18 * num18);
				num19 = num15 / num19;
				num17 *= num19;
				num18 *= num19;
				if (velocity.X < num17)
				{
					velocity.X += num16;
					if (velocity.X < 0f && num17 > 0f)
					{
						velocity.X += num16;
					}
				}
				else if (velocity.X > num17)
				{
					velocity.X -= num16;
					if (velocity.X > 0f && num17 < 0f)
					{
						velocity.X -= num16;
					}
				}
				if (velocity.Y < num18)
				{
					velocity.Y += num16;
					if (velocity.Y < 0f && num18 > 0f)
					{
						velocity.Y += num16;
					}
				}
				else if (velocity.Y > num18)
				{
					velocity.Y -= num16;
					if (velocity.Y > 0f && num18 < 0f)
					{
						velocity.Y -= num16;
					}
				}
				ai2 += 1f;
				if (ai2 >= 300f)
				{
					ai1 = 1f;
					ai2 = 0f;
					ai3 = 0f;
					TargetClosest();
					netUpdate = true;
				}
				vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				num17 = Main.player[target].position.X + 10f - vector3.X;
				num18 = Main.player[target].position.Y + 21f - vector3.Y;
				rotation = (float)Math.Atan2(num18, num17) - 1.57f;
				if (Main.netMode != 1)
				{
					localAI1++;
					if ((double)life < (double)lifeMax * 0.75)
					{
						localAI1++;
					}
					if ((double)life < (double)lifeMax * 0.5)
					{
						localAI1++;
					}
					if ((double)life < (double)lifeMax * 0.25)
					{
						localAI1++;
					}
					if ((double)life < (double)lifeMax * 0.1)
					{
						localAI1 += 2;
					}
					if (localAI1 > 140 && Collision.CanHit(ref aabb, ref Main.player[target].aabb))
					{
						localAI1 = 0;
						num19 = (float)Math.Sqrt(num17 * num17 + num18 * num18);
						num19 = 9f / num19;
						num17 *= num19;
						num18 *= num19;
						vector3.X += num17 * 15f;
						vector3.Y += num18 * 15f;
						Projectile.NewProjectile(vector3.X, vector3.Y, num17, num18, 100, 25, 0f);
					}
				}
				return;
			}
			int num20 = 1;
			if (aabb.X + (width >> 1) < Main.player[target].aabb.X + 20)
			{
				num20 = -1;
			}
			float num21 = 8f;
			float num22 = 0.2f;
			Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num23 = Main.player[target].position.X + 10f + (float)(num20 * 340) - vector4.X;
			float num24 = Main.player[target].position.Y + 21f - vector4.Y;
			float num25 = (float)Math.Sqrt(num23 * num23 + num24 * num24);
			num25 = num21 / num25;
			num23 *= num25;
			num24 *= num25;
			if (velocity.X < num23)
			{
				velocity.X += num22;
				if (velocity.X < 0f && num23 > 0f)
				{
					velocity.X += num22;
				}
			}
			else if (velocity.X > num23)
			{
				velocity.X -= num22;
				if (velocity.X > 0f && num23 < 0f)
				{
					velocity.X -= num22;
				}
			}
			if (velocity.Y < num24)
			{
				velocity.Y += num22;
				if (velocity.Y < 0f && num24 > 0f)
				{
					velocity.Y += num22;
				}
			}
			else if (velocity.Y > num24)
			{
				velocity.Y -= num22;
				if (velocity.Y > 0f && num24 < 0f)
				{
					velocity.Y -= num22;
				}
			}
			vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			num23 = Main.player[target].position.X + 10f - vector4.X;
			num24 = Main.player[target].position.Y + 21f - vector4.Y;
			rotation = (float)Math.Atan2(num24, num23) - 1.57f;
			if (Main.netMode != 1)
			{
				localAI1++;
				if ((double)life < (double)lifeMax * 0.75)
				{
					localAI1++;
				}
				if ((double)life < (double)lifeMax * 0.5)
				{
					localAI1++;
				}
				if ((double)life < (double)lifeMax * 0.25)
				{
					localAI1++;
				}
				if ((double)life < (double)lifeMax * 0.1)
				{
					localAI1 += 2;
				}
				if (localAI1 > 45 && Collision.CanHit(ref aabb, ref Main.player[target].aabb))
				{
					localAI1 = 0;
					num25 = (float)Math.Sqrt(num23 * num23 + num24 * num24);
					num25 = 9f / num25;
					num23 *= num25;
					num24 *= num25;
					vector4.X += num23 * 15f;
					vector4.Y += num24 * 15f;
					Projectile.NewProjectile(vector4.X, vector4.Y, num23, num24, 100, 20, 0f);
				}
			}
			ai2 += 1f;
			if (ai2 >= 200f)
			{
				ai1 = 0f;
				ai2 = 0f;
				ai3 = 0f;
				TargetClosest();
				netUpdate = true;
			}
		}

		private unsafe void SpazmatismAI()
		{
			if (target == 8 || Main.player[target].dead || Main.player[target].active == 0)
			{
				TargetClosest();
			}
			bool dead = Main.player[target].dead;
			float num = position.X + (float)(width >> 1) - Main.player[target].position.X - 10f;
			float num2 = position.Y + (float)(int)height - 59f - Main.player[target].position.Y - 21f;
			float num3 = (float)Math.Atan2(num2, num) + 1.57f;
			if (num3 < 0f)
			{
				num3 += 6.283f;
			}
			else if (num3 > 6.283f)
			{
				num3 -= 6.283f;
			}
			if (rotation < num3)
			{
				if ((double)(num3 - rotation) > 3.1415)
				{
					rotation -= 0.15f;
				}
				else
				{
					rotation += 0.15f;
				}
			}
			else if (rotation > num3)
			{
				if ((double)(rotation - num3) > 3.1415)
				{
					rotation += 0.15f;
				}
				else
				{
					rotation -= 0.15f;
				}
			}
			if (rotation > num3 - 0.15f && rotation < num3 + 0.15f)
			{
				rotation = num3;
			}
			if (rotation < 0f)
			{
				rotation += 6.283f;
			}
			else if (rotation > 6.283f)
			{
				rotation -= 6.283f;
			}
			if (rotation > num3 - 0.15f && rotation < num3 + 0.15f)
			{
				rotation = num3;
			}
			if (Main.rand.Next(6) == 0)
			{
				Dust* ptr = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 5, velocity.X, 2.0);
				if (ptr != null)
				{
					ptr->velocity.X *= 0.5f;
					ptr->velocity.Y *= 0.1f;
				}
			}
			if (Main.gameTime.dayTime || dead)
			{
				velocity.Y -= 0.04f;
				if (timeLeft > 10)
				{
					timeLeft = 10;
				}
				return;
			}
			if (ai0 == 0f)
			{
				if (ai1 == 0f)
				{
					TargetClosest();
					float num4 = 12f;
					float num5 = 0.4f;
					int num6 = 1;
					if (aabb.X + (width >> 1) < Main.player[target].aabb.X + 20)
					{
						num6 = -1;
					}
					Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num7 = Main.player[target].position.X + 10f + (float)(num6 * 400) - vector.X;
					float num8 = Main.player[target].position.Y + 21f - vector.Y;
					float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
					num9 = num4 / num9;
					num7 *= num9;
					num8 *= num9;
					if (velocity.X < num7)
					{
						velocity.X += num5;
						if (velocity.X < 0f && num7 > 0f)
						{
							velocity.X += num5;
						}
					}
					else if (velocity.X > num7)
					{
						velocity.X -= num5;
						if (velocity.X > 0f && num7 < 0f)
						{
							velocity.X -= num5;
						}
					}
					if (velocity.Y < num8)
					{
						velocity.Y += num5;
						if (velocity.Y < 0f && num8 > 0f)
						{
							velocity.Y += num5;
						}
					}
					else if (velocity.Y > num8)
					{
						velocity.Y -= num5;
						if (velocity.Y > 0f && num8 < 0f)
						{
							velocity.Y -= num5;
						}
					}
					ai2 += 1f;
					if (ai2 >= 600f)
					{
						ai1 = 1f;
						ai2 = 0f;
						ai3 = 0f;
						target = 8;
						netUpdate = true;
					}
					else
					{
						if (!Main.player[target].dead)
						{
							ai3 += 1f;
						}
						if (ai3 >= 60f)
						{
							ai3 = 0f;
							vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
							num7 = Main.player[target].position.X + 10f - vector.X;
							num8 = Main.player[target].position.Y + 21f - vector.Y;
							if (Main.netMode != 1)
							{
								num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
								num9 = 12f / num9;
								num7 *= num9;
								num8 *= num9;
								num7 += (float)Main.rand.Next(-40, 41) * 0.05f;
								num8 += (float)Main.rand.Next(-40, 41) * 0.05f;
								vector.X += num7 * 4f;
								vector.Y += num8 * 4f;
								Projectile.NewProjectile(vector.X, vector.Y, num7, num8, 96, 25, 0f);
							}
						}
					}
				}
				else if (ai1 == 1f)
				{
					rotation = num3;
					float num10 = 13f;
					Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num11 = Main.player[target].position.X + 10f - vector2.X;
					float num12 = Main.player[target].position.Y + 21f - vector2.Y;
					float num13 = (float)Math.Sqrt(num11 * num11 + num12 * num12);
					num13 = num10 / num13;
					velocity.X = num11 * num13;
					velocity.Y = num12 * num13;
					ai1 = 2f;
				}
				else if (ai1 == 2f)
				{
					ai2 += 1f;
					if (ai2 >= 8f)
					{
						velocity.X *= 0.9f;
						velocity.Y *= 0.9f;
						if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
						{
							velocity.X = 0f;
						}
						if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
						{
							velocity.Y = 0f;
						}
					}
					else
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
					}
					if (ai2 >= 42f)
					{
						ai3 += 1f;
						ai2 = 0f;
						target = 8;
						rotation = num3;
						if (ai3 >= 10f)
						{
							ai1 = 0f;
							ai3 = 0f;
						}
						else
						{
							ai1 = 1f;
						}
					}
				}
				if ((double)life < (double)lifeMax * 0.5)
				{
					ai0 = 1f;
					ai1 = 0f;
					ai2 = 0f;
					ai3 = 0f;
					netUpdate = true;
				}
				return;
			}
			if (ai0 == 1f || ai0 == 2f)
			{
				if (ai0 == 1f)
				{
					ai2 += 0.005f;
					if ((double)ai2 > 0.5)
					{
						ai2 = 0.5f;
					}
				}
				else
				{
					ai2 -= 0.005f;
					if (ai2 < 0f)
					{
						ai2 = 0f;
					}
				}
				rotation += ai2;
				ai1 += 1f;
				if (ai1 == 100f)
				{
					ai0 += 1f;
					ai1 = 0f;
					if (ai0 == 3f)
					{
						ai2 = 0f;
					}
					else
					{
						Main.PlaySound(3, aabb.X, aabb.Y);
						Main.PlaySound(15, aabb.X, aabb.Y, 0);
						for (int i = 0; i < 2; i++)
						{
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 144);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6);
						}
						for (int j = 0; j < 16; j++)
						{
							if (null == Main.dust.NewDust(5, ref aabb, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f))
							{
								break;
							}
						}
					}
				}
				Main.dust.NewDust(5, ref aabb, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f);
				velocity.X *= 0.98f;
				velocity.Y *= 0.98f;
				if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
				{
					velocity.X = 0f;
				}
				if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
				{
					velocity.Y = 0f;
				}
				return;
			}
			soundHit = 4;
			damage = defDamage + (defDamage >> 1);
			defense = defDefense + 25;
			if (ai1 == 0f)
			{
				float num14 = 4f;
				float num15 = 0.1f;
				int num16 = 1;
				if (aabb.X + (width >> 1) < Main.player[target].aabb.X + 20)
				{
					num16 = -1;
				}
				Vector2 vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num17 = Main.player[target].position.X + 10f + (float)(num16 * 180) - vector3.X;
				float num18 = Main.player[target].position.Y + 21f - vector3.Y;
				float num19 = (float)Math.Sqrt(num17 * num17 + num18 * num18);
				num19 = num14 / num19;
				num17 *= num19;
				num18 *= num19;
				if (velocity.X < num17)
				{
					velocity.X += num15;
					if (velocity.X < 0f && num17 > 0f)
					{
						velocity.X += num15;
					}
				}
				else if (velocity.X > num17)
				{
					velocity.X -= num15;
					if (velocity.X > 0f && num17 < 0f)
					{
						velocity.X -= num15;
					}
				}
				if (velocity.Y < num18)
				{
					velocity.Y += num15;
					if (velocity.Y < 0f && num18 > 0f)
					{
						velocity.Y += num15;
					}
				}
				else if (velocity.Y > num18)
				{
					velocity.Y -= num15;
					if (velocity.Y > 0f && num18 < 0f)
					{
						velocity.Y -= num15;
					}
				}
				ai2 += 1f;
				if (ai2 >= 400f)
				{
					ai1 = 1f;
					ai2 = 0f;
					ai3 = 0f;
					target = 8;
					netUpdate = true;
				}
				if (!Collision.CanHit(ref aabb, ref Main.player[target].aabb))
				{
					return;
				}
				localAI2++;
				if (localAI2 > 22)
				{
					localAI2 = 0;
					Main.PlaySound(2, aabb.X, aabb.Y, 34);
				}
				if (Main.netMode != 1)
				{
					localAI1++;
					if ((float)life < (float)lifeMax * 0.75f)
					{
						localAI1++;
					}
					if ((float)life < (float)lifeMax * 0.5f)
					{
						localAI1++;
					}
					if ((float)life < (float)lifeMax * 0.25f)
					{
						localAI1++;
					}
					if ((float)life < (float)lifeMax * 0.1f)
					{
						localAI1 += 2;
					}
					if (localAI1 > 8)
					{
						localAI1 = 0;
						vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						num17 = Main.player[target].position.X + 10f - vector3.X;
						num18 = Main.player[target].position.Y + 21f - vector3.Y;
						num19 = (float)Math.Sqrt(num17 * num17 + num18 * num18);
						num19 = 6f / num19;
						num17 *= num19;
						num18 *= num19;
						num18 += (float)Main.rand.Next(-40, 41) * 0.01f;
						num17 += (float)Main.rand.Next(-40, 41) * 0.01f;
						num18 += velocity.Y * 0.5f;
						num17 += velocity.X * 0.5f;
						vector3.X -= num17 * 1f;
						vector3.Y -= num18 * 1f;
						Projectile.NewProjectile(vector3.X, vector3.Y, num17, num18, 101, 30, 0f);
					}
				}
			}
			else if (ai1 == 1f)
			{
				Main.PlaySound(15, aabb.X, aabb.Y, 0);
				rotation = num3;
				float num20 = 14f;
				Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num21 = Main.player[target].position.X + 10f - vector4.X;
				float num22 = Main.player[target].position.Y + 21f - vector4.Y;
				float num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);
				num23 = num20 / num23;
				velocity.X = num21 * num23;
				velocity.Y = num22 * num23;
				ai1 = 2f;
			}
			else
			{
				if (ai1 != 2f)
				{
					return;
				}
				ai2 += 1f;
				if (ai2 >= 50f)
				{
					velocity.X *= 0.93f;
					velocity.Y *= 0.93f;
					if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
					{
						velocity.X = 0f;
					}
					if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
					{
						velocity.Y = 0f;
					}
				}
				else
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
				}
				if (ai2 >= 80f)
				{
					ai3 += 1f;
					ai2 = 0f;
					target = 8;
					rotation = num3;
					if (ai3 >= 6f)
					{
						ai1 = 0f;
						ai3 = 0f;
					}
					else
					{
						ai1 = 1f;
					}
				}
			}
		}

		private void SkeletronPrimeAI()
		{
			damage = defDamage;
			defense = defDefense;
			if (ai0 == 0f && Main.netMode != 1)
			{
				TargetClosest();
				ai0 = 1f;
				if (type != 68)
				{
					int num = NewNPC(aabb.X + (width >> 1), aabb.Y + (height >> 1), 128, whoAmI);
					Main.npc[num].ai0 = -1f;
					Main.npc[num].ai1 = whoAmI;
					Main.npc[num].target = target;
					Main.npc[num].netUpdate = true;
					num = NewNPC(aabb.X + (width >> 1), aabb.Y + (height >> 1), 129, whoAmI);
					Main.npc[num].ai0 = 1f;
					Main.npc[num].ai1 = whoAmI;
					Main.npc[num].target = target;
					Main.npc[num].netUpdate = true;
					num = NewNPC(aabb.X + (width >> 1), aabb.Y + (height >> 1), 130, whoAmI);
					Main.npc[num].ai0 = -1f;
					Main.npc[num].ai1 = whoAmI;
					Main.npc[num].target = target;
					Main.npc[num].ai3 = 150f;
					Main.npc[num].netUpdate = true;
					num = NewNPC(aabb.X + (width >> 1), aabb.Y + (height >> 1), 131, whoAmI);
					Main.npc[num].ai0 = 1f;
					Main.npc[num].ai1 = whoAmI;
					Main.npc[num].target = target;
					Main.npc[num].netUpdate = true;
					Main.npc[num].ai3 = 150f;
				}
			}
			if (type == 68 && ai1 != 3f && ai1 != 2f)
			{
				Main.PlaySound(15, aabb.X, aabb.Y, 0);
				ai1 = 2f;
			}
			if (Main.player[target].dead || Math.Abs(aabb.X - Main.player[target].aabb.X) > 6000 || Math.Abs(aabb.Y - Main.player[target].aabb.Y) > 6000)
			{
				TargetClosest();
				if (Main.player[target].dead || Math.Abs(aabb.X - Main.player[target].aabb.X) > 6000 || Math.Abs(aabb.Y - Main.player[target].aabb.Y) > 6000)
				{
					ai1 = 3f;
				}
			}
			if (Main.gameTime.dayTime && ai1 != 3f && ai1 != 2f)
			{
				ai1 = 2f;
				Main.PlaySound(15, aabb.X, aabb.Y, 0);
			}
			if (ai1 == 0f)
			{
				ai2 += 1f;
				if (ai2 >= 600f)
				{
					ai2 = 0f;
					ai1 = 1f;
					TargetClosest();
					netUpdate = true;
				}
				rotation = velocity.X * (71f / (339f * (float)Math.PI));
				if (aabb.Y > Main.player[target].aabb.Y - 200)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.98f;
					}
					velocity.Y -= 0.1f;
					if (velocity.Y > 2f)
					{
						velocity.Y = 2f;
					}
				}
				else if (aabb.Y < Main.player[target].aabb.Y - 500)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.98f;
					}
					velocity.Y += 0.1f;
					if (velocity.Y < -2f)
					{
						velocity.Y = -2f;
					}
				}
				if (aabb.X + (width >> 1) > Main.player[target].aabb.X + 10 + 100)
				{
					if (velocity.X > 0f)
					{
						velocity.X *= 0.98f;
					}
					velocity.X -= 0.1f;
					if (velocity.X > 8f)
					{
						velocity.X = 8f;
					}
				}
				else if (aabb.X + (width >> 1) < Main.player[target].aabb.X + 10 - 100)
				{
					if (velocity.X < 0f)
					{
						velocity.X *= 0.98f;
					}
					velocity.X += 0.1f;
					if (velocity.X < -8f)
					{
						velocity.X = -8f;
					}
				}
			}
			else if (ai1 == 1f)
			{
				defense *= 2;
				damage *= 2;
				ai2 += 1f;
				if (ai2 == 2f)
				{
					Main.PlaySound(15, aabb.X, aabb.Y, 0);
				}
				if (ai2 >= 400f)
				{
					ai2 = 0f;
					ai1 = 0f;
				}
				rotation += (float)direction * 0.3f;
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num2 = Main.player[target].position.X + 10f - vector.X;
				float num3 = Main.player[target].position.Y + 21f - vector.Y;
				float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				num4 = 2f / num4;
				velocity.X = num2 * num4;
				velocity.Y = num3 * num4;
			}
			else if (ai1 == 2f)
			{
				damage = 9999;
				defense = 9999;
				rotation += (float)direction * 0.3f;
				Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num5 = Main.player[target].position.X + 10f - vector2.X;
				float num6 = Main.player[target].position.Y + 21f - vector2.Y;
				float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
				num7 = 8f / num7;
				velocity.X = num5 * num7;
				velocity.Y = num6 * num7;
			}
			else if (ai1 == 3f)
			{
				velocity.Y += 0.1f;
				if (velocity.Y < 0f)
				{
					velocity.Y *= 0.95f;
				}
				velocity.X *= 0.95f;
				if (timeLeft > 500)
				{
					timeLeft = 500;
				}
			}
		}

		private void SkeletronPrimeSawHand()
		{
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector.X;
			float num2 = Main.npc[(int)ai1].position.Y + 230f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (ai2 != 99f)
			{
				if (num3 > 800f)
				{
					ai2 = 99f;
				}
			}
			else if (num3 < 400f)
			{
				ai2 = 0f;
			}
			spriteDirection = (sbyte)(0f - ai0);
			if (Main.npc[(int)ai1].active == 0 || Main.npc[(int)ai1].aiStyle != 32)
			{
				ai2 += 10f;
				if (ai2 > 50f || Main.netMode != 2)
				{
					life = -1;
					HitEffect();
					active = 0;
					return;
				}
			}
			if (ai2 == 99f)
			{
				if (aabb.Y > Main.npc[(int)ai1].aabb.Y)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.96f;
					}
					velocity.Y -= 0.1f;
					if (velocity.Y > 8f)
					{
						velocity.Y = 8f;
					}
				}
				else if (aabb.Y < Main.npc[(int)ai1].aabb.Y)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.96f;
					}
					velocity.Y += 0.1f;
					if (velocity.Y < -8f)
					{
						velocity.Y = -8f;
					}
				}
				if (aabb.X + (width >> 1) > Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1))
				{
					if (velocity.X > 0f)
					{
						velocity.X *= 0.96f;
					}
					velocity.X -= 0.5f;
					if (velocity.X > 12f)
					{
						velocity.X = 12f;
					}
				}
				else if (aabb.X + (width >> 1) < Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1))
				{
					if (velocity.X < 0f)
					{
						velocity.X *= 0.96f;
					}
					velocity.X += 0.5f;
					if (velocity.X < -12f)
					{
						velocity.X = -12f;
					}
				}
			}
			else if (ai2 == 0f || ai2 == 3f)
			{
				if (Main.npc[(int)ai1].ai1 == 3f && timeLeft > 10)
				{
					timeLeft = 10;
				}
				if (Main.npc[(int)ai1].ai1 != 0f)
				{
					TargetClosest();
					if (Main.player[target].dead)
					{
						velocity.Y += 0.1f;
						if (velocity.Y > 16f)
						{
							velocity.Y = 16f;
						}
					}
					else
					{
						Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num4 = Main.player[target].position.X + 10f - vector2.X;
						float num5 = Main.player[target].position.Y + 21f - vector2.Y;
						float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
						num6 = 7f / num6;
						num4 *= num6;
						num5 *= num6;
						rotation = (float)Math.Atan2(num5, num4) - 1.57f;
						if (velocity.X > num4)
						{
							if (velocity.X > 0f)
							{
								velocity.X *= 0.97f;
							}
							velocity.X -= 0.05f;
						}
						if (velocity.X < num4)
						{
							if (velocity.X < 0f)
							{
								velocity.X *= 0.97f;
							}
							velocity.X += 0.05f;
						}
						if (velocity.Y > num5)
						{
							if (velocity.Y > 0f)
							{
								velocity.Y *= 0.97f;
							}
							velocity.Y -= 0.05f;
						}
						if (velocity.Y < num5)
						{
							if (velocity.Y < 0f)
							{
								velocity.Y *= 0.97f;
							}
							velocity.Y += 0.05f;
						}
					}
					ai3 += 1f;
					if (ai3 >= 600f)
					{
						ai2 = 0f;
						ai3 = 0f;
						netUpdate = true;
					}
				}
				else
				{
					ai3 += 1f;
					if (ai3 >= 300f)
					{
						ai2 += 1f;
						ai3 = 0f;
						netUpdate = true;
					}
					if (aabb.Y > Main.npc[(int)ai1].aabb.Y + 320)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.04f;
						if (velocity.Y > 3f)
						{
							velocity.Y = 3f;
						}
					}
					else if (aabb.Y < Main.npc[(int)ai1].aabb.Y + 260)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.04f;
						if (velocity.Y < -3f)
						{
							velocity.Y = -3f;
						}
					}
					if (aabb.X + (width >> 1) > Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1))
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X -= 0.3f;
						if (velocity.X > 12f)
						{
							velocity.X = 12f;
						}
					}
					else if (aabb.X + (width >> 1) < Main.npc[(int)ai1].aabb.X + (Main.npc[(int)ai1].width >> 1) - 250)
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X += 0.3f;
						if (velocity.X < -12f)
						{
							velocity.X = -12f;
						}
					}
				}
				Vector2 vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num7 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector3.X;
				float num8 = Main.npc[(int)ai1].position.Y + 230f - vector3.Y;
				Math.Sqrt(num7 * num7 + num8 * num8);
				rotation = (float)Math.Atan2(num8, num7) + 1.57f;
			}
			else if (ai2 == 1f)
			{
				Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num9 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector4.X;
				float num10 = Main.npc[(int)ai1].position.Y + 230f - vector4.Y;
				float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
				rotation = (float)Math.Atan2(num10, num9) + 1.57f;
				velocity.X *= 0.95f;
				velocity.Y -= 0.1f;
				if (velocity.Y < -8f)
				{
					velocity.Y = -8f;
				}
				if (aabb.Y < Main.npc[(int)ai1].aabb.Y - 200)
				{
					TargetClosest();
					ai2 = 2f;
					vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					num9 = Main.player[target].position.X + 10f - vector4.X;
					num10 = Main.player[target].position.Y + 21f - vector4.Y;
					num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
					num11 = 22f / num11;
					velocity.X = num9 * num11;
					velocity.Y = num10 * num11;
					netUpdate = true;
				}
			}
			else if (ai2 == 2f)
			{
				if (velocity.Y < 0f || aabb.Y > Main.player[target].aabb.Y)
				{
					ai2 = 3f;
				}
			}
			else if (ai2 == 4f)
			{
				TargetClosest();
				Vector2 vector5 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num12 = Main.player[target].position.X + 10f - vector5.X;
				float num13 = Main.player[target].position.Y + 21f - vector5.Y;
				float num14 = (float)Math.Sqrt(num12 * num12 + num13 * num13);
				num14 = 7f / num14;
				num12 *= num14;
				num13 *= num14;
				if (velocity.X > num12)
				{
					if (velocity.X > 0f)
					{
						velocity.X *= 0.97f;
					}
					velocity.X -= 0.05f;
				}
				if (velocity.X < num12)
				{
					if (velocity.X < 0f)
					{
						velocity.X *= 0.97f;
					}
					velocity.X += 0.05f;
				}
				if (velocity.Y > num13)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.97f;
					}
					velocity.Y -= 0.05f;
				}
				if (velocity.Y < num13)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.97f;
					}
					velocity.Y += 0.05f;
				}
				ai3 += 1f;
				if (ai3 >= 600f)
				{
					ai2 = 0f;
					ai3 = 0f;
					netUpdate = true;
				}
				vector5 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				num12 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector5.X;
				num13 = Main.npc[(int)ai1].position.Y + 230f - vector5.Y;
				num14 = (float)Math.Sqrt(num12 * num12 + num13 * num13);
				rotation = (float)Math.Atan2(num13, num12) + 1.57f;
			}
			else if (ai2 == 5f && ((velocity.X > 0f && aabb.X + (width >> 1) > Main.player[target].aabb.X + 10) || (velocity.X < 0f && aabb.X + (width >> 1) < Main.player[target].aabb.X + 10)))
			{
				ai2 = 0f;
			}
		}

		private void SkeletronPrimeViceHand()
		{
			spriteDirection = (sbyte)(0f - ai0);
			Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
			float num = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector.X;
			float num2 = Main.npc[(int)ai1].position.Y + 230f - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (ai2 != 99f)
			{
				if (num3 > 800f)
				{
					ai2 = 99f;
				}
			}
			else if (num3 < 400f)
			{
				ai2 = 0f;
			}
			if (Main.npc[(int)ai1].active == 0 || Main.npc[(int)ai1].aiStyle != 32)
			{
				ai2 += 10f;
				if (ai2 > 50f || Main.netMode != 2)
				{
					life = -1;
					HitEffect();
					active = 0;
					return;
				}
			}
			if (ai2 == 99f)
			{
				if (position.Y > Main.npc[(int)ai1].position.Y)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.96f;
					}
					velocity.Y -= 0.1f;
					if (velocity.Y > 8f)
					{
						velocity.Y = 8f;
					}
				}
				else if (position.Y < Main.npc[(int)ai1].position.Y)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.96f;
					}
					velocity.Y += 0.1f;
					if (velocity.Y < -8f)
					{
						velocity.Y = -8f;
					}
				}
				if (position.X + (float)(width >> 1) > Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1))
				{
					if (velocity.X > 0f)
					{
						velocity.X *= 0.96f;
					}
					velocity.X -= 0.5f;
					if (velocity.X > 12f)
					{
						velocity.X = 12f;
					}
				}
				if (position.X + (float)(width >> 1) < Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1))
				{
					if (velocity.X < 0f)
					{
						velocity.X *= 0.96f;
					}
					velocity.X += 0.5f;
					if (velocity.X < -12f)
					{
						velocity.X = -12f;
					}
				}
			}
			else if (ai2 == 0f || ai2 == 3f)
			{
				if (Main.npc[(int)ai1].ai1 == 3f && timeLeft > 10)
				{
					timeLeft = 10;
				}
				if (Main.npc[(int)ai1].ai1 != 0f)
				{
					TargetClosest();
					TargetClosest();
					if (Main.player[target].dead)
					{
						velocity.Y += 0.1f;
						if (velocity.Y > 16f)
						{
							velocity.Y = 16f;
						}
					}
					else
					{
						Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
						float num4 = Main.player[target].position.X + 10f - vector2.X;
						float num5 = Main.player[target].position.Y + 21f - vector2.Y;
						float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
						num6 = 12f / num6;
						num4 *= num6;
						num5 *= num6;
						rotation = (float)Math.Atan2(num5, num4) - 1.57f;
						if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) < 2f)
						{
							rotation = (float)Math.Atan2(num5, num4) - 1.57f;
							velocity.X = num4;
							velocity.Y = num5;
							netUpdate = true;
						}
						else
						{
							velocity.X *= 0.97f;
							velocity.Y *= 0.97f;
						}
						ai3 += 1f;
						if (ai3 >= 600f)
						{
							ai2 = 0f;
							ai3 = 0f;
							netUpdate = true;
						}
					}
				}
				else
				{
					ai3 += 1f;
					if (ai3 >= 600f)
					{
						ai2 += 1f;
						ai3 = 0f;
						netUpdate = true;
					}
					if (position.Y > Main.npc[(int)ai1].position.Y + 300f)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.1f;
						if (velocity.Y > 3f)
						{
							velocity.Y = 3f;
						}
					}
					else if (position.Y < Main.npc[(int)ai1].position.Y + 230f)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.1f;
						if (velocity.Y < -3f)
						{
							velocity.Y = -3f;
						}
					}
					if (position.X + (float)(width >> 1) > Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) + 250f)
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.94f;
						}
						velocity.X -= 0.3f;
						if (velocity.X > 9f)
						{
							velocity.X = 9f;
						}
					}
					if (position.X + (float)(width >> 1) < Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1))
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.94f;
						}
						velocity.X += 0.2f;
						if (velocity.X < -8f)
						{
							velocity.X = -8f;
						}
					}
				}
				Vector2 vector3 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num7 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector3.X;
				float num8 = Main.npc[(int)ai1].position.Y + 230f - vector3.Y;
				Math.Sqrt(num7 * num7 + num8 * num8);
				rotation = (float)Math.Atan2(num8, num7) + 1.57f;
			}
			else if (ai2 == 1f)
			{
				if (velocity.Y > 0f)
				{
					velocity.Y *= 0.9f;
				}
				Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num9 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 280f * ai0 - vector4.X;
				float num10 = Main.npc[(int)ai1].position.Y + 230f - vector4.Y;
				float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
				rotation = (float)Math.Atan2(num10, num9) + 1.57f;
				velocity.X = (velocity.X * 5f + Main.npc[(int)ai1].velocity.X) / 6f;
				velocity.X += 0.5f;
				velocity.Y -= 0.5f;
				if (velocity.Y < -9f)
				{
					velocity.Y = -9f;
				}
				if (position.Y < Main.npc[(int)ai1].position.Y - 280f)
				{
					TargetClosest();
					ai2 = 2f;
					vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					num9 = Main.player[target].position.X + 10f - vector4.X;
					num10 = Main.player[target].position.Y + 21f - vector4.Y;
					num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
					num11 = 20f / num11;
					velocity.X = num9 * num11;
					velocity.Y = num10 * num11;
					netUpdate = true;
				}
			}
			else if (ai2 == 2f)
			{
				if (position.Y > Main.player[target].position.Y || velocity.Y < 0f)
				{
					if (ai3 >= 4f)
					{
						ai2 = 3f;
						ai3 = 0f;
					}
					else
					{
						ai2 = 1f;
						ai3 += 1f;
					}
				}
			}
			else if (ai2 == 4f)
			{
				Vector2 vector5 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num12 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector5.X;
				float num13 = Main.npc[(int)ai1].position.Y + 230f - vector5.Y;
				float num14 = (float)Math.Sqrt(num12 * num12 + num13 * num13);
				rotation = (float)Math.Atan2(num13, num12) + 1.57f;
				velocity.Y = (velocity.Y * 5f + Main.npc[(int)ai1].velocity.Y) / 6f;
				velocity.X += 0.5f;
				if (velocity.X > 12f)
				{
					velocity.X = 12f;
				}
				if (position.X + (float)(width >> 1) < Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 500f || position.X + (float)(width >> 1) > Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) + 500f)
				{
					TargetClosest();
					ai2 = 5f;
					vector5 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					num12 = Main.player[target].position.X + 10f - vector5.X;
					num13 = Main.player[target].position.Y + 21f - vector5.Y;
					num14 = (float)Math.Sqrt(num12 * num12 + num13 * num13);
					num14 = 17f / num14;
					velocity.X = num12 * num14;
					velocity.Y = num13 * num14;
					netUpdate = true;
				}
			}
			else if (ai2 == 5f && position.X + (float)(width >> 1) < Main.player[target].position.X + 10f - 100f)
			{
				if (ai3 >= 4f)
				{
					ai2 = 0f;
					ai3 = 0f;
				}
				else
				{
					ai2 = 4f;
					ai3 += 1f;
				}
			}
		}

		private void SkeletronPrimeCannonHand()
		{
			spriteDirection = (sbyte)(0f - ai0);
			if (Main.npc[(int)ai1].active == 0 || Main.npc[(int)ai1].aiStyle != 32)
			{
				ai2 += 10f;
				if (ai2 > 50f || Main.netMode != 2)
				{
					life = -1;
					HitEffect();
					active = 0;
					return;
				}
			}
			if (ai2 == 0f)
			{
				if (Main.npc[(int)ai1].ai1 == 3f && timeLeft > 10)
				{
					timeLeft = 10;
				}
				if (Main.npc[(int)ai1].ai1 != 0f)
				{
					localAI0 += 2;
					if (position.Y > Main.npc[(int)ai1].position.Y - 100f)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.07f;
						if (velocity.Y > 6f)
						{
							velocity.Y = 6f;
						}
					}
					else if (position.Y < Main.npc[(int)ai1].position.Y - 100f)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.07f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (position.X + (float)(width >> 1) > Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 120f * ai0)
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X -= 0.1f;
						if (velocity.X > 8f)
						{
							velocity.X = 8f;
						}
					}
					if (position.X + (float)(width >> 1) < Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 120f * ai0)
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X += 0.1f;
						if (velocity.X < -8f)
						{
							velocity.X = -8f;
						}
					}
				}
				else
				{
					ai3 += 1f;
					if (ai3 >= 1100f)
					{
						localAI0 = 0;
						ai2 = 1f;
						ai3 = 0f;
						netUpdate = true;
					}
					if (position.Y > Main.npc[(int)ai1].position.Y - 150f)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.04f;
						if (velocity.Y > 3f)
						{
							velocity.Y = 3f;
						}
					}
					else if (position.Y < Main.npc[(int)ai1].position.Y - 150f)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.04f;
						if (velocity.Y < -3f)
						{
							velocity.Y = -3f;
						}
					}
					if (position.X + (float)(width >> 1) > Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) + 200f)
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X -= 0.2f;
						if (velocity.X > 8f)
						{
							velocity.X = 8f;
						}
					}
					if (position.X + (float)(width >> 1) < Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) + 160f)
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X += 0.2f;
						if (velocity.X < -8f)
						{
							velocity.X = -8f;
						}
					}
				}
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 200f * ai0 - vector.X;
				float num2 = Main.npc[(int)ai1].position.Y + 230f - vector.Y;
				float num3 = (float)Math.Sqrt(num * num + num2 * num2);
				rotation = (float)Math.Atan2(num2, num) + 1.57f;
				if (Main.netMode != 1)
				{
					localAI0++;
					if (localAI0 > 140)
					{
						localAI0 = 0;
						num3 = 12f / num3;
						num = (0f - num) * num3;
						num2 = (0f - num2) * num3;
						num += (float)Main.rand.Next(-40, 41) * 0.01f;
						num2 += (float)Main.rand.Next(-40, 41) * 0.01f;
						vector.X += num * 4f;
						vector.Y += num2 * 4f;
						Projectile.NewProjectile(vector.X, vector.Y, num, num2, 102, 0, 0f);
					}
				}
			}
			else
			{
				if (ai2 != 1f)
				{
					return;
				}
				ai3 += 1f;
				if (ai3 >= 300f)
				{
					localAI0 = 0;
					ai2 = 0f;
					ai3 = 0f;
					netUpdate = true;
				}
				Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num4 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - vector2.X;
				float num5 = Main.npc[(int)ai1].position.Y - vector2.Y;
				num5 = Main.player[target].position.Y + 21f - 80f - vector2.Y;
				float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				num6 = 6f / num6;
				num4 *= num6;
				num5 *= num6;
				if (velocity.X > num4)
				{
					if (velocity.X > 0f)
					{
						velocity.X *= 0.9f;
					}
					velocity.X -= 0.04f;
				}
				if (velocity.X < num4)
				{
					if (velocity.X < 0f)
					{
						velocity.X *= 0.9f;
					}
					velocity.X += 0.04f;
				}
				if (velocity.Y > num5)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y -= 0.08f;
				}
				if (velocity.Y < num5)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y += 0.08f;
				}
				TargetClosest();
				vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				num4 = Main.player[target].position.X + 10f - vector2.X;
				num5 = Main.player[target].position.Y + 21f - vector2.Y;
				num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				rotation = (float)Math.Atan2(num5, num4) - 1.57f;
				if (Main.netMode != 1)
				{
					localAI0++;
					if (localAI0 > 40)
					{
						localAI0 = 0;
						num6 = 10f / num6;
						num4 *= num6;
						num5 *= num6;
						num4 += (float)Main.rand.Next(-40, 41) * 0.01f;
						num5 += (float)Main.rand.Next(-40, 41) * 0.01f;
						vector2.X += num4 * 4f;
						vector2.Y += num5 * 4f;
						Projectile.NewProjectile(vector2.X, vector2.Y, num4, num5, 102, 0, 0f);
					}
				}
			}
		}

		private void SkeletronPrimeLaserHand()
		{
			spriteDirection = (sbyte)(0f - ai0);
			if (Main.npc[(int)ai1].active == 0 || Main.npc[(int)ai1].aiStyle != 32)
			{
				ai2 += 10f;
				if (ai2 > 50f || Main.netMode != 2)
				{
					life = -1;
					HitEffect();
					active = 0;
					return;
				}
			}
			if (ai2 == 0f || ai2 == 3f)
			{
				if (Main.npc[(int)ai1].ai1 == 3f && timeLeft > 10)
				{
					timeLeft = 10;
				}
				if (Main.npc[(int)ai1].ai1 != 0f)
				{
					localAI0 += 3;
					if (position.Y > Main.npc[(int)ai1].position.Y - 100f)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.07f;
						if (velocity.Y > 6f)
						{
							velocity.Y = 6f;
						}
					}
					else if (position.Y < Main.npc[(int)ai1].position.Y - 100f)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.07f;
						if (velocity.Y < -6f)
						{
							velocity.Y = -6f;
						}
					}
					if (position.X + (float)(width >> 1) > Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 120f * ai0)
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X -= 0.1f;
						if (velocity.X > 8f)
						{
							velocity.X = 8f;
						}
					}
					if (position.X + (float)(width >> 1) < Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 120f * ai0)
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X += 0.1f;
						if (velocity.X < -8f)
						{
							velocity.X = -8f;
						}
					}
				}
				else
				{
					ai3 += 1f;
					if (ai3 >= 800f)
					{
						ai2 += 1f;
						ai3 = 0f;
						netUpdate = true;
					}
					if (position.Y > Main.npc[(int)ai1].position.Y - 100f)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y -= 0.1f;
						if (velocity.Y > 3f)
						{
							velocity.Y = 3f;
						}
					}
					else if (position.Y < Main.npc[(int)ai1].position.Y - 100f)
					{
						if (velocity.Y < 0f)
						{
							velocity.Y *= 0.96f;
						}
						velocity.Y += 0.1f;
						if (velocity.Y < -3f)
						{
							velocity.Y = -3f;
						}
					}
					if (position.X + (float)(width >> 1) > Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 180f * ai0)
					{
						if (velocity.X > 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X -= 0.14f;
						if (velocity.X > 8f)
						{
							velocity.X = 8f;
						}
					}
					if (position.X + (float)(width >> 1) < Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - 180f * ai0)
					{
						if (velocity.X < 0f)
						{
							velocity.X *= 0.96f;
						}
						velocity.X += 0.14f;
						if (velocity.X < -8f)
						{
							velocity.X = -8f;
						}
					}
				}
				TargetClosest();
				Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num = Main.player[target].position.X + 10f - vector.X;
				float num2 = Main.player[target].position.Y + 21f - vector.Y;
				float num3 = (float)Math.Sqrt(num * num + num2 * num2);
				rotation = (float)Math.Atan2(num2, num) - 1.57f;
				if (Main.netMode != 1)
				{
					localAI0++;
					if (localAI0 > 200)
					{
						localAI0 = 0;
						num3 = 8f / num3;
						num *= num3;
						num2 *= num3;
						num += (float)Main.rand.Next(-40, 41) * 0.05f;
						num2 += (float)Main.rand.Next(-40, 41) * 0.05f;
						vector.X += num * 8f;
						vector.Y += num2 * 8f;
						Projectile.NewProjectile(vector.X, vector.Y, num, num2, 100, 25, 0f);
					}
				}
			}
			else
			{
				if (ai2 != 1f)
				{
					return;
				}
				ai3 += 1f;
				if (ai3 >= 200f)
				{
					localAI0 = 0;
					ai2 = 0f;
					ai3 = 0f;
					netUpdate = true;
				}
				Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num4 = Main.player[target].position.X + 10f - 350f - vector2.X;
				float num5 = Main.player[target].position.Y + 21f - 20f - vector2.Y;
				float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				num6 = 7f / num6;
				num4 *= num6;
				num5 *= num6;
				if (velocity.X > num4)
				{
					if (velocity.X > 0f)
					{
						velocity.X *= 0.9f;
					}
					velocity.X -= 0.1f;
				}
				if (velocity.X < num4)
				{
					if (velocity.X < 0f)
					{
						velocity.X *= 0.9f;
					}
					velocity.X += 0.1f;
				}
				if (velocity.Y > num5)
				{
					if (velocity.Y > 0f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y -= 0.03f;
				}
				if (velocity.Y < num5)
				{
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.9f;
					}
					velocity.Y += 0.03f;
				}
				TargetClosest();
				vector2 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				num4 = Main.player[target].position.X + 10f - vector2.X;
				num5 = Main.player[target].position.Y + 21f - vector2.Y;
				num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
				rotation = (float)Math.Atan2(num5, num4) - 1.57f;
				if (Main.netMode == 1)
				{
					localAI0++;
					if (localAI0 > 80)
					{
						localAI0 = 0;
						num6 = 10f / num6;
						num4 *= num6;
						num5 *= num6;
						num4 += (float)Main.rand.Next(-40, 41) * 0.05f;
						num5 += (float)Main.rand.Next(-40, 41) * 0.05f;
						vector2.X += num4 * 8f;
						vector2.Y += num5 * 8f;
						Projectile.NewProjectile(vector2.X, vector2.Y, num4, num5, 100, 25, 0f);
					}
				}
			}
		}

		private void DestroyerAI()
		{
			if (ai3 > 0f)
			{
				realLife = (int)ai3;
			}
			if (target == 8 || Main.player[target].dead)
			{
				TargetClosest();
			}
			if (type > 134)
			{
				bool flag = false;
				if (ai1 <= 0f)
				{
					flag = true;
				}
				else if (Main.npc[(int)ai1].life <= 0)
				{
					flag = true;
				}
				if (flag)
				{
					life = 0;
					if (active != 0)
					{
						HitEffect();
					}
					checkDead();
				}
			}
			if (Main.netMode != 1)
			{
				if (ai0 == 0f && type == 134)
				{
					ai3 = whoAmI;
					realLife = whoAmI;
					int num = 0;
					int num2 = whoAmI;
					int num3 = 80;
					for (int i = 0; i <= num3; i++)
					{
						int num4 = 135;
						if (i == num3)
						{
							num4 = 136;
						}
						num = NewNPC(aabb.X + (width >> 1), aabb.Y + height, num4, whoAmI);
						Main.npc[num].ai3 = whoAmI;
						Main.npc[num].realLife = whoAmI;
						Main.npc[num].ai1 = num2;
						Main.npc[num2].ai0 = num;
						NetMessage.CreateMessage1(23, num);
						NetMessage.SendMessage();
						num2 = num;
					}
				}
				if (type == 135)
				{
					localAI0 += Main.rand.Next(4);
					if (localAI0 >= Main.rand.Next(1400, 26000))
					{
						localAI0 = 0;
						TargetClosest();
						if (Collision.CanHit(ref aabb, ref Main.player[target].aabb))
						{
							Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(height >> 1));
							float num5 = Main.player[target].position.X + 10f - vector.X + (float)Main.rand.Next(-20, 21);
							float num6 = Main.player[target].position.Y + 21f - vector.Y + (float)Main.rand.Next(-20, 21);
							float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
							num7 = 8f / num7;
							num5 *= num7;
							num6 *= num7;
							num5 += (float)Main.rand.Next(-20, 21) * 0.05f;
							num6 += (float)Main.rand.Next(-20, 21) * 0.05f;
							vector.X += num5 * 5f;
							vector.Y += num6 * 5f;
							int num8 = Projectile.NewProjectile(vector.X, vector.Y, num5, num6, 100, 22, 0f);
							if (num8 >= 0)
							{
								Main.projectile[num8].timeLeft = 300;
								netUpdate = true;
							}
						}
					}
				}
			}
			int num9 = ((int)position.X >> 4) - 1;
			int num10 = ((int)position.X + width >> 4) + 2;
			int num11 = ((int)position.Y >> 4) - 1;
			int num12 = ((int)position.Y + height >> 4) + 2;
			if (num9 < 0)
			{
				num9 = 0;
			}
			if (num10 > Main.maxTilesX)
			{
				num10 = Main.maxTilesX;
			}
			if (num11 < 0)
			{
				num11 = 0;
			}
			if (num12 > Main.maxTilesY)
			{
				num12 = Main.maxTilesY;
			}
			bool flag2 = false;
			if (!flag2)
			{
				Vector2 vector2 = default(Vector2);
				for (int j = num9; j < num10; j++)
				{
					for (int k = num11; k < num12; k++)
					{
						if (Main.tile[j, k].canStandOnTop() || Main.tile[j, k].liquid > 64)
						{
							vector2.X = j * 16;
							vector2.Y = k * 16;
							if (position.X + (float)(int)width > vector2.X && position.X < vector2.X + 16f && position.Y + (float)(int)height > vector2.Y && position.Y < vector2.Y + 16f)
							{
								flag2 = true;
								break;
							}
						}
					}
				}
			}
			if (!flag2)
			{
				if (type != 135 || ai2 != 1f)
				{
					Lighting.addLight((int)position.X + (width >> 1) >> 4, (int)position.Y + (height >> 1) >> 4, new Vector3(0.3f, 0.1f, 0.05f));
				}
				localAI1 = 1;
				if (type == 134)
				{
					Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
					bool flag3 = true;
					if (position.Y > Main.player[target].position.Y)
					{
						for (int l = 0; l < 8; l++)
						{
							if (Main.player[l].active != 0)
							{
								Rectangle rectangle2 = new Rectangle(Main.player[l].aabb.X - 1000, Main.player[l].aabb.Y - 1000, 2000, 2000);
								if (rectangle.Intersects(rectangle2))
								{
									flag3 = false;
									break;
								}
							}
						}
						if (flag3)
						{
							flag2 = true;
						}
					}
				}
			}
			else
			{
				localAI1 = 0;
			}
			float num13 = 16f;
			if (Main.gameTime.dayTime || Main.player[target].dead)
			{
				flag2 = false;
				velocity.Y += 1f;
				if (position.Y > (float)(Main.worldSurface << 4))
				{
					velocity.Y += 1f;
					num13 = 32f;
				}
				if (position.Y > (float)(Main.rockLayer << 4))
				{
					for (int m = 0; m < 196; m++)
					{
						if (Main.npc[m].aiStyle == aiStyle)
						{
							Main.npc[m].active = 0;
						}
					}
				}
			}
			Vector2 vector3 = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
			float num14;
			float num15;
			if (ai1 > 0f && ai1 < 196f)
			{
				num14 = Main.npc[(int)ai1].position.X + (float)(Main.npc[(int)ai1].width >> 1) - vector3.X;
				num15 = Main.npc[(int)ai1].position.Y + (float)(Main.npc[(int)ai1].height >> 1) - vector3.Y;
				rotation = (float)(Math.Atan2(num15, num14) + Math.PI / 2.0);
				float num16 = num14 * num14 + num15 * num15;
				if (num16 > 0f)
				{
					num16 = (float)Math.Sqrt(num16);
					num16 = (num16 - 44f * scale) / num16;
					num14 *= num16;
					num15 *= num16;
					position.X += num14;
					position.Y += num15;
					aabb.X = (int)position.X;
					aabb.Y = (int)position.Y;
				}
				velocity.X = 0f;
				velocity.Y = 0f;
				return;
			}
			num14 = ((Main.player[target].aabb.X + 10) & -16);
			num15 = ((Main.player[target].aabb.Y + 21) & -16);
			vector3.X = ((int)vector3.X & -16);
			vector3.Y = ((int)vector3.Y & -16);
			num14 -= vector3.X;
			num15 -= vector3.Y;
			if (!flag2)
			{
				TargetClosest();
				velocity.Y += 0.15f;
				if (velocity.Y > num13)
				{
					velocity.Y = num13;
				}
				if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num13 * 0.4)
				{
					if (velocity.X < 0f)
					{
						velocity.X -= 0.110000007f;
					}
					else
					{
						velocity.X += 0.110000007f;
					}
				}
				else if (velocity.Y == num13)
				{
					if (velocity.X < num14)
					{
						velocity.X += 0.1f;
					}
					else if (velocity.X > num14)
					{
						velocity.X -= 0.1f;
					}
				}
				else if (velocity.Y > 4f)
				{
					if (velocity.X < 0f)
					{
						velocity.X += 0.0899999961f;
					}
					else
					{
						velocity.X -= 0.0899999961f;
					}
				}
			}
			else
			{
				float num16 = (float)Math.Sqrt(num14 * num14 + num15 * num15);
				if (soundDelay == 0)
				{
					float num17 = num16 * 0.025f;
					if (num17 < 10f)
					{
						num17 = 10f;
					}
					else if (num17 > 20f)
					{
						num17 = 20f;
					}
					soundDelay = (short)num17;
					Main.PlaySound(15, aabb.X, aabb.Y);
				}
				float num18 = Math.Abs(num14);
				float num19 = Math.Abs(num15);
				float num20 = num13 / num16;
				num14 *= num20;
				num15 *= num20;
				if (((velocity.X > 0f && num14 > 0f) || (velocity.X < 0f && num14 < 0f)) && ((velocity.Y > 0f && num15 > 0f) || (velocity.Y < 0f && num15 < 0f)))
				{
					if (velocity.X < num14)
					{
						velocity.X += 0.15f;
					}
					else if (velocity.X > num14)
					{
						velocity.X -= 0.15f;
					}
					if (velocity.Y < num15)
					{
						velocity.Y += 0.15f;
					}
					else if (velocity.Y > num15)
					{
						velocity.Y -= 0.15f;
					}
				}
				if ((velocity.X > 0f && num14 > 0f) || (velocity.X < 0f && num14 < 0f) || (velocity.Y > 0f && num15 > 0f) || (velocity.Y < 0f && num15 < 0f))
				{
					if (velocity.X < num14)
					{
						velocity.X += 0.1f;
					}
					else if (velocity.X > num14)
					{
						velocity.X -= 0.1f;
					}
					if (velocity.Y < num15)
					{
						velocity.Y += 0.1f;
					}
					else if (velocity.Y > num15)
					{
						velocity.Y -= 0.1f;
					}
					if ((double)Math.Abs(num15) < (double)num13 * 0.2 && ((velocity.X > 0f && num14 < 0f) || (velocity.X < 0f && num14 > 0f)))
					{
						if (velocity.Y > 0f)
						{
							velocity.Y += 0.2f;
						}
						else
						{
							velocity.Y -= 0.2f;
						}
					}
					if ((double)Math.Abs(num14) < (double)num13 * 0.2 && ((velocity.Y > 0f && num15 < 0f) || (velocity.Y < 0f && num15 > 0f)))
					{
						if (velocity.X > 0f)
						{
							velocity.X += 0.2f;
						}
						else
						{
							velocity.X -= 0.2f;
						}
					}
				}
				else if (num18 > num19)
				{
					if (velocity.X < num14)
					{
						velocity.X += 0.110000007f;
					}
					else if (velocity.X > num14)
					{
						velocity.X -= 0.110000007f;
					}
					if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num13 * 0.5)
					{
						if (velocity.Y > 0f)
						{
							velocity.Y += 0.1f;
						}
						else
						{
							velocity.Y -= 0.1f;
						}
					}
				}
				else
				{
					if (velocity.Y < num15)
					{
						velocity.Y += 0.110000007f;
					}
					else if (velocity.Y > num15)
					{
						velocity.Y -= 0.110000007f;
					}
					if ((double)(Math.Abs(velocity.X) + Math.Abs(velocity.Y)) < (double)num13 * 0.5)
					{
						if (velocity.X > 0f)
						{
							velocity.X += 0.1f;
						}
						else
						{
							velocity.X -= 0.1f;
						}
					}
				}
			}
			rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 1.57f;
			if (type != 134)
			{
				return;
			}
			if (flag2)
			{
				if (localAI0 != 1)
				{
					netUpdate = true;
				}
				localAI0 = 1;
			}
			else
			{
				if (localAI0 != 0)
				{
					netUpdate = true;
				}
				localAI0 = 0;
			}
			if (((velocity.X > 0f && oldVelocity.X < 0f) || (velocity.X < 0f && oldVelocity.X > 0f) || (velocity.Y > 0f && oldVelocity.Y < 0f) || (velocity.Y < 0f && oldVelocity.Y > 0f)) && !justHit)
			{
				netUpdate = true;
			}
		}

		private void SnowmanAI()
		{
			float num = 4f;
			float num2 = 1f;
			if (type == 143)
			{
				num = 3f;
				num2 = 0.7f;
			}
			if (type == 145)
			{
				num = 3.5f;
				num2 = 0.8f;
			}
			if (type == 143)
			{
				ai2 += 1f;
				if (ai2 >= 120f)
				{
					ai2 = 0f;
					if (Main.netMode != 1)
					{
						Vector2 vector = new Vector2(position.X + (float)(int)width * 0.5f - (float)(direction * 12), position.Y + (float)(int)height * 0.5f);
						float speedX = 12 * spriteDirection;
						float speedY = 0f;
						if (Main.netMode != 1)
						{
							int num3 = Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, 110, 25, 0f, 8, send: false);
							if (num3 >= 0)
							{
								Main.projectile[num3].ai0 = 2f;
								Main.projectile[num3].timeLeft = 300;
								Main.projectile[num3].friendly = false;
								NetMessage.SendProjectile(num3);
								netUpdate = true;
							}
						}
					}
				}
			}
			if (type == 144 && ai1 >= 3f)
			{
				TargetClosest();
				spriteDirection = direction;
				if (velocity.Y == 0f)
				{
					velocity.X *= 0.9f;
					ai2 += 1f;
					if ((double)velocity.X > -0.3 && (double)velocity.X < 0.3)
					{
						velocity.X = 0f;
					}
					if (ai2 >= 200f)
					{
						ai2 = 0f;
						ai1 = 0f;
					}
				}
			}
			else if (type == 145 && ai1 >= 3f)
			{
				TargetClosest();
				if (velocity.Y == 0f)
				{
					velocity.X *= 0.9f;
					ai2 += 1f;
					if ((double)velocity.X > -0.3 && (double)velocity.X < 0.3)
					{
						velocity.X = 0f;
					}
					if (ai2 >= 16f)
					{
						ai2 = 0f;
						ai1 = 0f;
					}
				}
				if (velocity.X == 0f && velocity.Y == 0f && ai2 == 8f)
				{
					Vector2 vector2 = new Vector2(position.X + (float)(int)width * 0.5f - (float)(direction * 12), position.Y + (float)(int)height * 0.25f);
					float num4 = Main.player[target].position.X + 10f - vector2.X;
					float num5 = Main.player[target].position.Y - vector2.Y;
					float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
					num6 = 10f / num6;
					num4 *= num6;
					num5 *= num6;
					if (Main.netMode != 1)
					{
						int num7 = Projectile.NewProjectile(vector2.X, vector2.Y, num4, num5, 109, 35, 0f);
						if (num7 >= 0)
						{
							Main.projectile[num7].ai0 = 2f;
							Main.projectile[num7].timeLeft = 300;
							Main.projectile[num7].friendly = false;
							NetMessage.SendProjectile(num7);
							netUpdate = true;
						}
					}
				}
			}
			else
			{
				if (velocity.Y == 0f)
				{
					if (localAI2 == aabb.X)
					{
						direction = (sbyte)(-direction);
						ai3 = 60f;
					}
					localAI2 = aabb.X;
					if (ai3 == 0f)
					{
						TargetClosest();
					}
					ai0 += 1f;
					if (ai0 > 2f)
					{
						ai0 = 0f;
						ai1 += 1f;
						velocity.Y = -8.2f;
						velocity.X += (float)direction * num2 * 1.1f;
					}
					else
					{
						velocity.Y = -6f;
						velocity.X += (float)direction * num2 * 0.9f;
					}
					spriteDirection = direction;
				}
				velocity.X += (float)direction * num2 * 0.01f;
			}
			if (ai3 > 0f)
			{
				ai3 -= 1f;
			}
			if (velocity.X > num && direction > 0)
			{
				velocity.X = 4f;
			}
			else if (velocity.X < 0f - num && direction < 0)
			{
				velocity.X = -4f;
			}
		}

		private unsafe void OcramAI()
		{
			Lighting.addLight(aabb.X >> 4, aabb.Y >> 4, new Vector3(1f, 1f, 1f));
			if (target == 8 || Main.player[target].dead || Main.player[target].active == 0)
			{
				TargetClosest();
			}
			bool dead = Main.player[target].dead;
			float num = position.X + (float)(width >> 1) - Main.player[target].position.X - 10f;
			float num2 = position.Y + (float)(int)height - 59f - Main.player[target].position.Y - 21f;
			float num3 = (float)Math.Atan2(num2, num) + 1.57f;
			if (num3 < 0f)
			{
				num3 += 6.283f;
			}
			else if (num3 > 6.283f)
			{
				num3 -= 6.283f;
			}
			float num4 = 0f;
			if (ai0 == 0f && ai1 == 0f)
			{
				num4 = 0.02f;
			}
			if (ai0 == 0f && ai1 == 2f && ai2 > 40f)
			{
				num4 = 0.05f;
			}
			if (ai0 == 3f && ai1 == 0f)
			{
				num4 = 0.05f;
			}
			if (ai0 == 3f && ai1 == 2f && ai2 > 40f)
			{
				num4 = 0.08f;
			}
			if (rotation < num3)
			{
				if ((double)(num3 - rotation) > 3.1415)
				{
					rotation -= num4;
				}
				else
				{
					rotation += num4;
				}
			}
			else if (rotation > num3)
			{
				if ((double)(rotation - num3) > 3.1415)
				{
					rotation += num4;
				}
				else
				{
					rotation -= num4;
				}
			}
			if (rotation > num3 - num4 && rotation < num3 + num4)
			{
				rotation = num3;
			}
			if (rotation < 0f)
			{
				rotation += 6.283f;
			}
			else if (rotation > 6.283f)
			{
				rotation -= 6.283f;
			}
			if (rotation > num3 - num4 && rotation < num3 + num4)
			{
				rotation = num3;
			}
			if (Main.rand.Next(6) == 0)
			{
				Dust* ptr = Main.dust.NewDust(aabb.X, aabb.Y + (height >> 2), width, height >> 1, 5, velocity.X, 2.0);
				if (ptr != null)
				{
					ptr->velocity.X *= 0.5f;
					ptr->velocity.Y *= 0.1f;
				}
			}
			if (Main.gameTime.dayTime || dead)
			{
				velocity.Y -= 0.04f;
				if (timeLeft > 10)
				{
					timeLeft = 10;
				}
				return;
			}
			if (ai0 == 0f)
			{
				if (ai1 == 0f)
				{
					float num5 = 8f;
					float num6 = 0.12f;
					Vector2 vector = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
					float num7 = Main.player[target].position.X + 10f - vector.X;
					float num8 = Main.player[target].position.Y + 21f - 200f - vector.Y;
					float num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
					float num10 = num9;
					num9 = num5 / num9;
					num7 *= num9;
					num8 *= num9;
					if (velocity.X < num7)
					{
						velocity.X += num6;
						if (velocity.X < 0f && num7 > 0f)
						{
							velocity.X += num6;
						}
					}
					else if (velocity.X > num7)
					{
						velocity.X -= num6;
						if (velocity.X > 0f && num7 < 0f)
						{
							velocity.X -= num6;
						}
					}
					if (velocity.Y < num8)
					{
						velocity.Y += num6;
						if (velocity.Y < 0f && num8 > 0f)
						{
							velocity.Y += num6;
						}
					}
					else if (velocity.Y > num8)
					{
						velocity.Y -= num6;
						if (velocity.Y > 0f && num8 < 0f)
						{
							velocity.Y -= num6;
						}
					}
					ai2 += 1f;
					if (ai2 >= 600f)
					{
						ai1 = 1f;
						ai2 = 0f;
						ai3 = 0f;
						target = 8;
						netUpdate = true;
					}
					else if (aabb.Y + height < Main.player[target].aabb.Y && num10 < 500f)
					{
						if (!Main.player[target].dead)
						{
							ai3 += 1f;
						}
						if (ai3 >= 90f)
						{
							TargetClosest();
							num9 = (float)Math.Sqrt(num7 * num7 + num8 * num8);
							num9 = 9f / num9;
							num7 *= num9;
							num8 *= num9;
							vector.X += num7 * 15f;
							vector.Y += num8 * 15f;
							Projectile.NewProjectile(vector.X, vector.Y, num7, num8, 100, 20, 0f);
						}
						if (ai3 == 60f || ai3 == 70f || ai3 == 80f || ai3 == 90f)
						{
							rotation = num3;
							float num11 = Main.player[target].position.X + 10f - vector.X;
							float num12 = Main.player[target].position.Y + 21f - vector.Y;
							float num13 = (float)Math.Sqrt(num11 * num11 + num12 * num12);
							num13 = 5f / num13;
							Vector2 vector2 = vector;
							Vector2 vector3 = default(Vector2);
							vector3.X = num11 * num13;
							vector3.Y = num12 * num13;
							vector2.X += vector3.X * 10f;
							vector2.Y += vector3.Y * 10f;
							if (Main.netMode != 1)
							{
								int num14 = NewNPC((int)vector2.X, (int)vector2.Y, 167);
								if (num14 < 196)
								{
									Main.npc[num14].velocity.X = vector3.X;
									Main.npc[num14].velocity.Y = vector3.Y;
									NetMessage.CreateMessage1(23, num14);
									NetMessage.SendMessage();
								}
							}
							Main.PlaySound(3, (int)vector2.X, (int)vector2.Y);
							for (int i = 0; i < 8; i++)
							{
								if (null == Main.dust.NewDust((int)vector2.X, (int)vector2.Y, 20, 20, 5, vector3.X * 0.4f, vector3.Y * 0.4f))
								{
									break;
								}
							}
						}
						if (ai3 == 103f)
						{
							ai3 = 0f;
						}
					}
				}
				else if (ai1 == 1f)
				{
					rotation = num3;
					float num15 = 6f;
					Vector2 vector4 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num16 = Main.player[target].position.X + 10f - vector4.X;
					float num17 = Main.player[target].position.Y + 21f - vector4.Y;
					float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
					num18 = num15 / num18;
					velocity.X = num16 * num18;
					velocity.Y = num17 * num18;
					ai1 = 2f;
				}
				else if (ai1 == 2f)
				{
					ai2 += 1f;
					if (ai2 >= 40f)
					{
						velocity.X *= 0.98f;
						velocity.Y *= 0.98f;
						if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
						{
							velocity.X = 0f;
						}
						if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
						{
							velocity.Y = 0f;
						}
					}
					else
					{
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
					}
					if (ai2 >= 150f)
					{
						ai3 += 1f;
						ai2 = 0f;
						target = 8;
						rotation = num3;
						if (ai3 >= 3f)
						{
							ai1 = 0f;
							ai3 = 0f;
						}
						else
						{
							ai1 = 1f;
						}
					}
				}
				if (life < lifeMax >> 1)
				{
					ai0 = 1f;
					ai1 = 0f;
					ai2 = 0f;
					ai3 = 0f;
					netUpdate = true;
				}
				return;
			}
			if (ai0 == 1f || ai0 == 2f)
			{
				if (ai0 == 1f)
				{
					ai2 += 0.005f;
					if ((double)ai2 > 0.5)
					{
						ai2 = 0.5f;
					}
				}
				else
				{
					ai2 -= 0.005f;
					if (ai2 < 0f)
					{
						ai2 = 0f;
					}
				}
				rotation += ai2;
				ai1 += 1f;
				if (ai1 == 100f)
				{
					ai0 += 1f;
					ai1 = 0f;
					if (ai0 == 3f)
					{
						ai2 = 0f;
					}
					else
					{
						Main.PlaySound(3, aabb.X, aabb.Y);
						for (int j = 0; j < 2; j++)
						{
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 174);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 173);
							Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 172);
						}
						for (int k = 0; k < 16; k++)
						{
							if (null == Main.dust.NewDust(5, ref aabb, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f))
							{
								break;
							}
						}
						Main.PlaySound(15, aabb.X, aabb.Y, 0);
					}
				}
				Main.dust.NewDust(5, ref aabb, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f);
				velocity.X *= 0.98f;
				velocity.Y *= 0.98f;
				if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
				{
					velocity.X = 0f;
				}
				if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
				{
					velocity.Y = 0f;
				}
				return;
			}
			damage = 50;
			defense = 0;
			if (ai1 == 0f)
			{
				float num19 = 9f;
				float num20 = 0.2f;
				Vector2 vector5 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num21 = Main.player[target].position.X + 10f - vector5.X;
				float num22 = Main.player[target].position.Y + 21f - 120f - vector5.Y;
				float num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);
				num23 = num19 / num23;
				num21 *= num23;
				num22 *= num23;
				if (velocity.X < num21)
				{
					velocity.X += num20;
					if (velocity.X < 0f && num21 > 0f)
					{
						velocity.X += num20;
					}
				}
				else if (velocity.X > num21)
				{
					velocity.X -= num20;
					if (velocity.X > 0f && num21 < 0f)
					{
						velocity.X -= num20;
					}
				}
				if (velocity.Y < num22)
				{
					velocity.Y += num20;
					if (velocity.Y < 0f && num22 > 0f)
					{
						velocity.Y += num20;
					}
				}
				else if (velocity.Y > num22)
				{
					velocity.Y -= num20;
					if (velocity.Y > 0f && num22 < 0f)
					{
						velocity.Y -= num20;
					}
				}
				ai2 += 1f;
				if (ai2 >= 100f)
				{
					if (ai2 >= 200f)
					{
						ai1 = 1f;
						ai2 = 0f;
						ai3 = 0f;
						target = 8;
						netUpdate = true;
					}
					num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);
					num23 = 9f / num23;
					num21 *= num23;
					num22 *= num23;
					num21 += (float)Main.rand.Next(-40, 41) * 0.08f;
					num22 += (float)Main.rand.Next(-40, 41) * 0.08f;
					vector5.X += num21 * 15f;
					vector5.Y += num22 * 15f;
					Projectile.NewProjectile(vector5.X, vector5.Y, num21, num22, 83, 45, 0f);
				}
			}
			else if (ai1 == 1f)
			{
				Main.PlaySound(15, (int)position.X, (int)position.Y, 0);
				rotation = num3;
				float num24 = 6.8f;
				Vector2 vector6 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
				float num25 = Main.player[target].position.X + 10f - vector6.X;
				float num26 = Main.player[target].position.Y + 21f - vector6.Y;
				float num27 = (float)Math.Sqrt(num25 * num25 + num26 * num26);
				num27 = num24 / num27;
				velocity.X = num25 * num27;
				velocity.Y = num26 * num27;
				if (ai1 == 1f)
				{
					num27 = (float)Math.Sqrt(num25 * num25 + num26 * num26);
					num27 = 6f / num27;
					num25 *= num27;
					num26 *= num27;
					num25 += (float)Main.rand.Next(-40, 41) * 0.08f;
					num26 += (float)Main.rand.Next(-40, 41) * 0.08f;
					for (int l = 1; l <= 10; l++)
					{
						vector6.X += (float)Main.rand.Next(-50, 50) * 2f;
						vector6.Y += (float)Main.rand.Next(-50, 50) * 2f;
						Projectile.NewProjectile(vector6.X, vector6.Y, num25, num26, 44, 45, 0f);
					}
				}
				ai1 = 2f;
			}
			else
			{
				if (ai1 != 2f)
				{
					return;
				}
				ai2 += 1f;
				if (ai2 >= 40f)
				{
					velocity.X *= 1f;
					velocity.Y *= 1f;
					if ((double)velocity.X > -0.1 && (double)velocity.X < 0.1)
					{
						velocity.X = 0f;
					}
					if ((double)velocity.Y > -0.1 && (double)velocity.Y < 0.1)
					{
						velocity.Y = 0f;
					}
					if (ai2 >= 135f)
					{
						ai3 += 1f;
						ai2 = 0f;
						target = 8;
						rotation = num3;
						if (ai3 >= 3f)
						{
							ai1 = 0f;
							ai3 = 0f;
						}
						else
						{
							ai1 = 1f;
						}
					}
					if (ai2 != 110f && ai2 != 100f && ai2 != 130f && ai2 != 120f)
					{
						return;
					}
					rotation = num3;
					Vector2 vector7 = new Vector2(position.X + (float)(int)width * 0.5f, position.Y + (float)(int)height * 0.5f);
					float num28 = Main.player[target].position.X + 10f - vector7.X;
					float num29 = Main.player[target].position.Y + 21f - vector7.Y;
					float num30 = (float)Math.Sqrt(num28 * num28 + num29 * num29);
					num30 = 5f / num30;
					Vector2 vector8 = vector7;
					Vector2 vector9 = default(Vector2);
					vector9.X = num28 * num30;
					vector9.Y = num29 * num30;
					vector8.X += vector9.X * 10f;
					vector8.Y += vector9.Y * 10f;
					if (Main.netMode != 1)
					{
						int num31 = NewNPC((int)vector8.X, (int)vector8.Y, 167);
						if (num31 < 196)
						{
							Main.npc[num31].velocity.X = vector9.X;
							Main.npc[num31].velocity.Y = vector9.Y;
							NetMessage.CreateMessage1(23, num31);
							NetMessage.SendMessage();
						}
					}
				}
				else
				{
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) - 1.57f;
				}
			}
		}

		public void FindFrame()
		{
			int num = 0;
			if (aiAction == 0)
			{
				num = ((velocity.Y < 0f) ? 2 : ((velocity.Y > 0f) ? 3 : ((velocity.X != 0f) ? 1 : 0)));
			}
			else if (aiAction == 1)
			{
				num = 4;
			}
			if (type == 1 || type == 16 || type == 59 || type == 71 || type == 81 || type == 150 || type == 138)
			{
				frameCounter += 1f;
				if (num > 0)
				{
					frameCounter += 1f;
				}
				if (num == 4)
				{
					frameCounter += 1f;
				}
				if (frameCounter >= 8f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
			else if (type == 141)
			{
				spriteDirection = direction;
				if (velocity.Y != 0f)
				{
					frameY = (short)(frameHeight << 1);
					return;
				}
				frameCounter += 1f;
				if (frameCounter >= 8f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY > frameHeight)
				{
					frameY = 0;
				}
			}
			else if (type == 143)
			{
				if (velocity.Y > 0f)
				{
					frameCounter += 1f;
				}
				else if (velocity.Y < 0f)
				{
					frameCounter -= 1f;
				}
				if (frameCounter < 6f)
				{
					frameY = frameHeight;
				}
				else if (frameCounter < 12f)
				{
					frameY = (short)(frameHeight << 1);
				}
				else if (frameCounter < 18f)
				{
					frameY = (short)(frameHeight * 3);
				}
				if (frameCounter < 0f)
				{
					frameCounter = 0f;
				}
				if (frameCounter > 17f)
				{
					frameCounter = 17f;
				}
			}
			else if (type == 144)
			{
				if (velocity.X == 0f && velocity.Y == 0f)
				{
					localAI3++;
					if (localAI3 < 6)
					{
						frameY = 0;
					}
					else if (localAI3 < 12)
					{
						frameY = frameHeight;
					}
					if (localAI3 >= 11)
					{
						localAI3 = 0;
					}
					return;
				}
				if (velocity.Y > 0f)
				{
					frameCounter += 1f;
				}
				else if (velocity.Y < 0f)
				{
					frameCounter -= 1f;
				}
				if (frameCounter < 6f)
				{
					frameY = (short)(frameHeight << 1);
				}
				else if (frameCounter < 12f)
				{
					frameY = (short)(frameHeight * 3);
				}
				else if (frameCounter < 18f)
				{
					frameY = (short)(frameHeight << 2);
				}
				if (frameCounter < 0f)
				{
					frameCounter = 0f;
				}
				else if (frameCounter > 17f)
				{
					frameCounter = 17f;
				}
			}
			else if (type == 145)
			{
				if (velocity.X == 0f && velocity.Y == 0f)
				{
					if (ai2 < 4f)
					{
						frameY = 0;
					}
					else if (ai2 < 8f)
					{
						frameY = frameHeight;
					}
					else if (ai2 < 12f)
					{
						frameY = (short)(frameHeight << 1);
					}
					else if (ai2 < 16f)
					{
						frameY = (short)(frameHeight * 3);
					}
					return;
				}
				if (velocity.Y > 0f)
				{
					frameCounter += 1f;
				}
				else if (velocity.Y < 0f)
				{
					frameCounter -= 1f;
				}
				if (frameCounter < 6f)
				{
					frameY = (short)(frameHeight << 2);
				}
				else if (frameCounter < 12f)
				{
					frameY = (short)(frameHeight * 5);
				}
				else if (frameCounter < 18f)
				{
					frameY = (short)(frameHeight * 6);
				}
				if (frameCounter < 0f)
				{
					frameCounter = 0f;
				}
				if (frameCounter > 17f)
				{
					frameCounter = 17f;
				}
			}
			else if (type == 50)
			{
				if (velocity.Y != 0f)
				{
					frameY = (short)(frameHeight << 2);
					return;
				}
				frameCounter += 1f;
				if (num > 0)
				{
					frameCounter += 1f;
				}
				if (num == 4)
				{
					frameCounter += 1f;
				}
				if (frameCounter >= 8f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * 4)
				{
					frameY = 0;
				}
			}
			else if (type == 135)
			{
				if (ai2 == 0f)
				{
					frameY = 0;
				}
				else
				{
					frameY = frameHeight;
				}
			}
			else if (type == 85)
			{
				if (ai0 == 0f)
				{
					frameCounter = 0f;
					frameY = 0;
				}
				else
				{
					if (velocity.Y == 0f)
					{
						frameCounter -= 1f;
					}
					else
					{
						frameCounter += 1f;
					}
					if (frameCounter < 0f)
					{
						frameCounter = 0f;
					}
					else if (frameCounter > 12f)
					{
						frameCounter = 12f;
					}
					if (frameCounter < 3f)
					{
						frameY = frameHeight;
					}
					else if (frameCounter < 6f)
					{
						frameY = (short)(frameHeight << 1);
					}
					else if (frameCounter < 9f)
					{
						frameY = (short)(frameHeight * 3);
					}
					else if (frameCounter < 12f)
					{
						frameY = (short)(frameHeight << 2);
					}
					else if (frameCounter < 15f)
					{
						frameY = (short)(frameHeight * 5);
					}
					else if (frameCounter < 18f)
					{
						frameY = (short)(frameHeight << 2);
					}
					else if (frameCounter < 21f)
					{
						frameY = (short)(frameHeight * 3);
					}
					else
					{
						frameY = (short)(frameHeight << 1);
						if (frameCounter >= 24f)
						{
							frameCounter = 3f;
						}
					}
				}
				if (ai3 == 2f)
				{
					frameY = (short)(frameY + frameHeight * 6);
				}
				else if (ai3 == 3f)
				{
					frameY = (short)(frameY + frameHeight * 12);
				}
			}
			else if (type == 113 || type == 114)
			{
				if (ai2 == 0f)
				{
					frameCounter += 1f;
					if (frameCounter >= 12f)
					{
						frameY += frameHeight;
						frameCounter = 0f;
					}
					if (frameY >= frameHeight * npcFrameCount[type])
					{
						frameY = 0;
					}
				}
				else
				{
					frameY = 0;
					frameCounter = -60f;
				}
			}
			else if (type == 61)
			{
				spriteDirection = direction;
				rotation = velocity.X * 0.1f;
				if (velocity.X == 0f && velocity.Y == 0f)
				{
					frameY = 0;
					frameCounter = 0f;
					return;
				}
				frameCounter += 1f;
				if (frameCounter < 4f)
				{
					frameY = frameHeight;
					return;
				}
				frameY = (short)(frameHeight << 1);
				if (frameCounter >= 7f)
				{
					frameCounter = 0f;
				}
			}
			else if (type == 122 || type == 153)
			{
				spriteDirection = direction;
				rotation = velocity.X * 0.05f;
				if (ai3 > 0f)
				{
					frameCounter = 0f;
					frameY = (short)((((int)ai3 >> 3) + 3) * frameHeight);
					return;
				}
				frameCounter += 1f;
				if (frameCounter >= 8f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * 3)
				{
					frameY = 0;
				}
			}
			else if (type == 74)
			{
				spriteDirection = direction;
				rotation = velocity.X * 0.1f;
				if (velocity.X == 0f && velocity.Y == 0f)
				{
					frameY = (short)(frameHeight << 2);
					frameCounter = 0f;
					return;
				}
				frameCounter += 1f;
				if (frameCounter >= 4f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
			else if (type == 62 || type == 165 || type == 66)
			{
				spriteDirection = direction;
				rotation = velocity.X * 0.1f;
				frameCounter += 1f;
				if (frameCounter < 6f)
				{
					frameY = 0;
					return;
				}
				frameY = frameHeight;
				if (frameCounter >= 11f)
				{
					frameCounter = 0f;
				}
			}
			else if (type == 63 || type == 64 || type == 103)
			{
				frameCounter += 1f;
				if (frameCounter < 6f)
				{
					frameY = 0;
					return;
				}
				if (frameCounter < 12f)
				{
					frameY = frameHeight;
					return;
				}
				if (frameCounter < 18f)
				{
					frameY = (short)(frameHeight << 1);
					return;
				}
				frameY = (short)(frameHeight * 3);
				if (frameCounter >= 23f)
				{
					frameCounter = 0f;
				}
			}
			else if (type == 2 || type == 23 || type == 121)
			{
				if (type == 2)
				{
					if (velocity.X > 0f)
					{
						spriteDirection = 1;
						rotation = (float)Math.Atan2(velocity.Y, velocity.X);
					}
					if (velocity.X < 0f)
					{
						spriteDirection = -1;
						rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 3.14f;
					}
				}
				else if (type == 121)
				{
					if (velocity.X > 0f)
					{
						spriteDirection = 1;
					}
					if (velocity.X < 0f)
					{
						spriteDirection = -1;
					}
					rotation = velocity.X * 0.1f;
				}
				if ((frameCounter += 1f) >= 8f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
			else if (type == 133)
			{
				if (velocity.X > 0f)
				{
					spriteDirection = 1;
					rotation = (float)Math.Atan2(velocity.Y, velocity.X);
				}
				if (velocity.X < 0f)
				{
					spriteDirection = -1;
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 3.14f;
				}
				if ((frameCounter += 1f) >= 8f)
				{
					frameY = frameHeight;
				}
				else
				{
					frameY = 0;
				}
				if (frameCounter >= 16f)
				{
					frameY = 0;
					frameCounter = 0f;
				}
				if ((double)life < (double)lifeMax * 0.5)
				{
					frameY = (short)(frameY + (frameHeight << 1));
				}
			}
			else if (type == 116)
			{
				if (velocity.X > 0f)
				{
					spriteDirection = 1;
					rotation = (float)Math.Atan2(velocity.Y, velocity.X);
				}
				if (velocity.X < 0f)
				{
					spriteDirection = -1;
					rotation = (float)Math.Atan2(velocity.Y, velocity.X) + 3.14f;
				}
				if ((frameCounter += 1f) >= 5f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
			else if (type == 75)
			{
				if (velocity.X > 0f)
				{
					spriteDirection = 1;
				}
				else
				{
					spriteDirection = -1;
				}
				rotation = velocity.X * 0.1f;
				if ((frameCounter += 1f) >= 4f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
			else if (type == 55 || type == 57 || type == 58 || type == 102)
			{
				spriteDirection = direction;
				frameCounter += 1f;
				if (wet)
				{
					if (frameCounter < 6f)
					{
						frameY = 0;
					}
					else if (frameCounter < 12f)
					{
						frameY = frameHeight;
					}
					else if (frameCounter < 18f)
					{
						frameY = (short)(frameHeight << 1);
					}
					else if (frameCounter < 24f)
					{
						frameY = (short)(frameHeight * 3);
					}
					else
					{
						frameCounter = 0f;
					}
				}
				else if (frameCounter < 6f)
				{
					frameY = (short)(frameHeight << 2);
				}
				else if (frameCounter < 12f)
				{
					frameY = (short)(frameHeight * 5);
				}
				else
				{
					frameCounter = 0f;
				}
			}
			else if (type == 69 || type == 147)
			{
				if (ai0 < 190f)
				{
					if ((frameCounter += 1f) >= 6f)
					{
						frameCounter = 0f;
						frameY += frameHeight;
						if (frameY / frameHeight >= npcFrameCount[type] - 1)
						{
							frameY = 0;
						}
					}
				}
				else
				{
					frameCounter = 0f;
					frameY = (short)(frameHeight * (npcFrameCount[type] - 1));
				}
			}
			else if (type == 86)
			{
				if (velocity.Y == 0f || wet)
				{
					if (velocity.X < -2f)
					{
						spriteDirection = -1;
					}
					else if (velocity.X > 2f)
					{
						spriteDirection = 1;
					}
					else
					{
						spriteDirection = direction;
					}
				}
				if (velocity.Y != 0f)
				{
					frameY = (short)(frameHeight * 15);
					frameCounter = 0f;
					return;
				}
				if (velocity.X == 0f)
				{
					frameCounter = 0f;
					frameY = 0;
					return;
				}
				if (Math.Abs(velocity.X) < 3f)
				{
					frameCounter += Math.Abs(velocity.X);
					if (frameCounter >= 6f)
					{
						frameCounter = 0f;
						frameY += frameHeight;
						if (frameY / frameHeight >= 9)
						{
							frameY = frameHeight;
						}
						if (frameY / frameHeight <= 0)
						{
							frameY = frameHeight;
						}
					}
					return;
				}
				frameCounter += Math.Abs(velocity.X);
				if (frameCounter >= 10f)
				{
					frameCounter = 0f;
					frameY += frameHeight;
					if (frameY / frameHeight >= 15)
					{
						frameY = (short)(frameHeight * 9);
					}
					if (frameY / frameHeight <= 8)
					{
						frameY = (short)(frameHeight * 9);
					}
				}
			}
			else if (type == 127)
			{
				if (ai1 == 0f)
				{
					frameCounter += 1f;
					if (frameCounter >= 12f)
					{
						frameCounter = 0f;
						frameY += frameHeight;
						if (frameY / frameHeight >= 2)
						{
							frameY = 0;
						}
					}
				}
				else
				{
					frameCounter = 0f;
					frameY = (short)(frameHeight << 1);
				}
			}
			else if (type == 129)
			{
				if (velocity.Y == 0f)
				{
					spriteDirection = direction;
				}
				frameCounter += 1f;
				if (frameCounter >= 2f)
				{
					frameCounter = 0f;
					frameY += frameHeight;
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = 0;
					}
				}
			}
			else if (type == 130)
			{
				if (velocity.Y == 0f)
				{
					spriteDirection = direction;
				}
				frameCounter += 1f;
				if (frameCounter >= 8f)
				{
					frameCounter = 0f;
					frameY += frameHeight;
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = 0;
					}
				}
			}
			else if (type == 67)
			{
				if (velocity.Y == 0f)
				{
					spriteDirection = direction;
				}
				frameCounter += 1f;
				if (frameCounter >= 6f)
				{
					frameCounter = 0f;
					frameY += frameHeight;
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = 0;
					}
				}
			}
			else if (type == 109)
			{
				if (velocity.Y == 0f && ((velocity.X <= 0f && direction < 0) || (velocity.X >= 0f && direction > 0)))
				{
					spriteDirection = direction;
				}
				frameCounter += Math.Abs(velocity.X);
				if (frameCounter >= 7f)
				{
					frameCounter -= 7f;
					frameY += frameHeight;
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = 0;
					}
				}
			}
			else if (type == 83 || type == 84 || type == 151)
			{
				if (ai0 == 2f)
				{
					frameCounter = 0f;
					frameY = 0;
					return;
				}
				frameCounter += 1f;
				if (frameCounter >= 4f)
				{
					frameCounter = 0f;
					frameY += frameHeight;
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = 0;
					}
				}
			}
			else if (type == 72)
			{
				frameCounter += 1f;
				if (frameCounter >= 3f)
				{
					frameCounter = 0f;
					frameY += frameHeight;
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = 0;
					}
				}
			}
			else if (type == 65 || type == 148)
			{
				spriteDirection = direction;
				frameCounter += 1f;
				if (wet)
				{
					if (frameCounter < 6f)
					{
						frameY = 0;
					}
					else if (frameCounter < 12f)
					{
						frameY = frameHeight;
					}
					else if (frameCounter < 18f)
					{
						frameY = (short)(frameHeight << 1);
					}
					else if (frameCounter < 24f)
					{
						frameY = (short)(frameHeight * 3);
					}
					else
					{
						frameCounter = 0f;
					}
				}
			}
			else if (type == 48 || type == 49 || type == 51 || type == 60 || type == 82 || type == 93 || type == 137)
			{
				if (velocity.X > 0f)
				{
					spriteDirection = 1;
				}
				if (velocity.X < 0f)
				{
					spriteDirection = -1;
				}
				rotation = velocity.X * 0.1f;
				frameCounter += 1f;
				if (frameCounter >= 6f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * 4)
				{
					frameY = 0;
				}
			}
			else if (type == 42 || type == 157)
			{
				frameCounter += 1f;
				if (frameCounter < 2f)
				{
					frameY = 0;
				}
				else if (frameCounter < 4f)
				{
					frameY = frameHeight;
				}
				else if (frameCounter < 6f)
				{
					frameY = (short)(frameHeight << 1);
				}
				else if (frameCounter < 8f)
				{
					frameY = frameHeight;
				}
				else
				{
					frameCounter = 0f;
				}
			}
			else if (type == 43 || type == 56 || type == 156)
			{
				frameCounter += 1f;
				if (frameCounter < 6f)
				{
					frameY = 0;
				}
				else if (frameCounter < 12f)
				{
					frameY = frameHeight;
				}
				else if (frameCounter < 18f)
				{
					frameY = (short)(frameHeight << 1);
				}
				else if (frameCounter < 24f)
				{
					frameY = frameHeight;
				}
				if (frameCounter == 23f)
				{
					frameCounter = 0f;
				}
			}
			else if (type == 115)
			{
				frameCounter += 1f;
				if (frameCounter < 3f)
				{
					frameY = 0;
				}
				else if (frameCounter < 6f)
				{
					frameY = frameHeight;
				}
				else if (frameCounter < 12f)
				{
					frameY = (short)(frameHeight << 1);
				}
				else if (frameCounter < 15f)
				{
					frameY = frameHeight;
				}
				if (frameCounter == 15f)
				{
					frameCounter = 0f;
				}
			}
			else if (type == 101)
			{
				frameCounter += 1f;
				if (frameCounter > 6f)
				{
					frameY = (short)(frameY + (frameHeight << 1));
					frameCounter = 0f;
				}
				if (frameY > frameHeight * 2)
				{
					frameY = 0;
				}
			}
			else if (type == 17 || type == 18 || type == 19 || type == 20 || type == 22 || type == 142 || type == 38 || type == 26 || type == 27 || type == 28 || type == 31 || type == 21 || type == 44 || type == 54 || type == 37 || type == 73 || type == 77 || type == 78 || type == 79 || type == 80 || type == 104 || type == 107 || type == 108 || type == 120 || type == 154 || type == 124 || type == 140 || type == 149 || type == 152 || type == 155)
			{
				if (velocity.Y == 0f)
				{
					if (direction == 1)
					{
						spriteDirection = 1;
					}
					else if (direction == -1)
					{
						spriteDirection = -1;
					}
					if (velocity.X == 0f)
					{
						if (type == 140)
						{
							frameY = frameHeight;
						}
						else
						{
							frameY = 0;
						}
						frameCounter = 0f;
						return;
					}
					frameCounter += Math.Abs(velocity.X) * 2f;
					if ((frameCounter += 1f) > 6f)
					{
						frameY += frameHeight;
						frameCounter = 0f;
					}
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = (short)(frameHeight << 1);
					}
				}
				else
				{
					frameCounter = 0f;
					if (type == 21 || type == 31 || type == 44 || type == 149 || type == 77 || type == 78 || type == 79 || type == 80 || type == 120 || type == 154 || type == 140 || type == 152 || type == 155)
					{
						frameY = 0;
					}
					else
					{
						frameY = frameHeight;
					}
				}
			}
			else if (type == 110)
			{
				if (velocity.Y == 0f)
				{
					if (direction != 0)
					{
						spriteDirection = direction;
					}
					if (ai2 > 0f)
					{
						spriteDirection = direction;
						frameY = (short)(frameHeight * (int)ai2);
						frameCounter = 0f;
						return;
					}
					if (frameY < frameHeight * 6)
					{
						frameY = (short)(frameHeight * 6);
					}
					frameCounter += Math.Abs(velocity.X) * 2f;
					frameCounter += velocity.X;
					if (frameCounter > 6f)
					{
						frameY += frameHeight;
						frameCounter = 0f;
					}
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = (short)(frameHeight * 6);
					}
				}
				else
				{
					frameCounter = 0f;
					frameY = 0;
				}
			}
			else if (type == 111)
			{
				if (velocity.Y == 0f)
				{
					if (direction != 0)
					{
						spriteDirection = direction;
					}
					if (ai2 > 0f)
					{
						spriteDirection = direction;
						frameY = (short)(frameHeight * ((int)ai2 - 1));
						frameCounter = 0f;
						return;
					}
					if (frameY < frameHeight * 7)
					{
						frameY = (short)(frameHeight * 7);
					}
					frameCounter += Math.Abs(velocity.X) * 2f;
					frameCounter += velocity.X * 1.3f;
					if (frameCounter > 6f)
					{
						frameY += frameHeight;
						frameCounter = 0f;
					}
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = (short)(frameHeight * 7);
					}
				}
				else
				{
					frameCounter = 0f;
					frameY = (short)(frameHeight * 6);
				}
			}
			else if (type == 3 || type == 52 || type == 53 || type == 132)
			{
				if (velocity.Y == 0f && direction != 0)
				{
					spriteDirection = direction;
				}
				if (velocity.Y != 0f || (direction == -1 && velocity.X > 0f) || (direction == 1 && velocity.X < 0f))
				{
					frameCounter = 0f;
					frameY = (short)(frameHeight << 1);
					return;
				}
				if (velocity.X == 0f)
				{
					frameCounter = 0f;
					frameY = 0;
					return;
				}
				frameCounter += Math.Abs(velocity.X);
				if (frameCounter < 8f)
				{
					frameY = 0;
				}
				else if (frameCounter < 16f)
				{
					frameY = frameHeight;
				}
				else if (frameCounter < 24f)
				{
					frameY = (short)(frameHeight << 1);
				}
				else if (frameCounter < 32f)
				{
					frameY = frameHeight;
				}
				else
				{
					frameCounter = 0f;
				}
			}
			else if (type == 46 || type == 47)
			{
				if (velocity.Y == 0f)
				{
					if (direction != 0)
					{
						spriteDirection = direction;
					}
					if (velocity.X == 0f)
					{
						frameY = 0;
						frameCounter = 0f;
						return;
					}
					frameCounter += Math.Abs(velocity.X);
					frameCounter += 1f;
					if (frameCounter > 6f)
					{
						frameY += frameHeight;
						frameCounter = 0f;
					}
					if (frameY / frameHeight >= npcFrameCount[type])
					{
						frameY = 0;
					}
				}
				else if (velocity.Y < 0f)
				{
					frameCounter = 0f;
					frameY = (short)(frameHeight << 2);
				}
				else if (velocity.Y > 0f)
				{
					frameCounter = 0f;
					frameY = (short)(frameHeight * 6);
				}
			}
			else if (type == 4 || type == 166 || type == 125 || type == 126)
			{
				if ((frameCounter += 1f) < 7f)
				{
					frameY = 0;
				}
				else if (frameCounter < 14f)
				{
					frameY = frameHeight;
				}
				else if (frameCounter < 21f)
				{
					frameY = (short)(frameHeight << 1);
				}
				else
				{
					frameCounter = 0f;
					frameY = 0;
				}
				if (ai0 > 1f)
				{
					frameY = (short)(frameY + frameHeight * 3);
				}
			}
			else if (type == 5 || type == 167)
			{
				if ((frameCounter += 1f) >= 8f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
			else if (type == 94)
			{
				if ((frameCounter += 1f) < 6f)
				{
					frameY = 0;
					return;
				}
				if (frameCounter < 12f)
				{
					frameY = frameHeight;
					return;
				}
				if (frameCounter < 18f)
				{
					frameY = (short)(frameHeight << 1);
					return;
				}
				frameY = frameHeight;
				if (frameCounter >= 23f)
				{
					frameCounter = 0f;
				}
			}
			else if (type == 6)
			{
				frameCounter += 1f;
				if (frameCounter >= 8f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
			else if (type == 24)
			{
				if (velocity.Y == 0f && direction != 0)
				{
					spriteDirection = direction;
				}
				if (ai1 > 0f)
				{
					if (frameY < 4)
					{
						frameCounter = 0f;
					}
					frameCounter += 1f;
					if (frameCounter <= 4f)
					{
						frameY = (short)(frameHeight << 2);
						return;
					}
					if (frameCounter <= 8f)
					{
						frameY = (short)(frameHeight * 5);
						return;
					}
					if (frameCounter <= 12f)
					{
						frameY = (short)(frameHeight * 6);
						return;
					}
					if (frameCounter <= 16f)
					{
						frameY = (short)(frameHeight * 7);
						return;
					}
					if (frameCounter <= 20f)
					{
						frameY = (short)(frameHeight << 3);
						return;
					}
					frameY = (short)(frameHeight * 9);
					frameCounter = 100f;
					return;
				}
				frameCounter += 1f;
				if (frameCounter <= 4f)
				{
					frameY = 0;
					return;
				}
				if (frameCounter <= 8f)
				{
					frameY = frameHeight;
					return;
				}
				if (frameCounter <= 12f)
				{
					frameY = (short)(frameHeight << 1);
					return;
				}
				frameY = (short)(frameHeight * 3);
				if (frameCounter >= 16f)
				{
					frameCounter = 0f;
				}
			}
			else if (type == 29 || type == 32 || type == 45)
			{
				if (velocity.Y == 0f && direction != 0)
				{
					spriteDirection = direction;
				}
				frameY = 0;
				if (velocity.Y != 0f)
				{
					frameY += frameHeight;
				}
				else if (ai1 > 0f)
				{
					frameY = (short)(frameY + (frameHeight << 1));
				}
			}
			else if (type == 34 || type == 158)
			{
				if ((frameCounter += 1f) >= 4f)
				{
					frameY += frameHeight;
					frameCounter = 0f;
				}
				if (frameY >= frameHeight * npcFrameCount[type])
				{
					frameY = 0;
				}
			}
		}

		public void TargetClosest(bool faceTarget = true)
		{
			int num = -1;
			target = 0;
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[i].active != 0 && !Main.player[i].dead && (num == -1 || Math.Abs(Main.player[i].aabb.X + 10 - aabb.X + (width >> 1)) + Math.Abs(Main.player[i].aabb.Y + 21 - aabb.Y + (height >> 1)) < num))
				{
					num = Math.Abs(Main.player[i].aabb.X + 10 - aabb.X + (width >> 1)) + Math.Abs(Main.player[i].aabb.Y + 21 - aabb.Y + (height >> 1));
					target = (byte)i;
				}
			}
			targetRect = Main.player[target].aabb;
			if (Main.player[target].dead)
			{
				faceTarget = false;
			}
			else if (faceTarget)
			{
				direction = 1;
				if (targetRect.X + (targetRect.Width >> 1) < aabb.X + (width >> 1))
				{
					direction = -1;
				}
				directionY = 1;
				if (targetRect.Y + (targetRect.Height >> 1) < aabb.Y + (height >> 1))
				{
					directionY = -1;
				}
			}
			if (confused)
			{
				direction = (sbyte)(-direction);
			}
			if ((direction != oldDirection || directionY != oldDirectionY || target != oldTarget) && !collideX && !collideY)
			{
				netUpdate = true;
			}
		}

		public void CheckActive()
		{
			if (active == 0 || type == 8 || type == 9 || type == 11 || type == 12 || type == 14 || type == 15 || type == 40 || type == 41 || type == 96 || type == 97 || type == 99 || type == 100 || (type > 87 && type <= 92) || (type > 159 && type <= 164) || type == 118 || type == 119 || type == 113 || type == 114 || type == 115 || (type >= 134 && type <= 136))
			{
				return;
			}
			if (townNPC)
			{
				Rectangle rectangle = new Rectangle(aabb.X + (width >> 1) - 1920, aabb.Y + (height >> 1) - 1080, 3840, 2160);
				for (int i = 0; i < 8; i++)
				{
					if (Main.player[i].active != 0 && rectangle.Intersects(Main.player[i].aabb))
					{
						Main.player[i].townNPCs += npcSlots;
					}
				}
				return;
			}
			bool flag = false;
			Rectangle rectangle2 = new Rectangle(aabb.X + (width >> 1) - 3264, aabb.Y + (height >> 1) - 1836, 6528, 3672);
			Rectangle rectangle3 = new Rectangle(aabb.X + (width >> 1) - 960 - width, aabb.Y + (height >> 1) - 540 - height, 1920 + width * 2, 1080 + height * 2);
			for (int j = 0; j < 8; j++)
			{
				if (Main.player[j].active == 0)
				{
					continue;
				}
				if (rectangle2.Intersects(Main.player[j].aabb))
				{
					flag = true;
					if (type != 25 && type != 30 && type != 33 && lifeMax > 0)
					{
						Main.player[j].activeNPCs += npcSlots;
					}
				}
				else if (boss || type == 7 || type == 10 || type == 13 || type == 39 || type == 87 || type == 159 || type == 35 || type == 36 || (type >= 127 && type <= 131))
				{
					flag = true;
				}
				if (rectangle3.Intersects(Main.player[j].aabb))
				{
					timeLeft = 750;
				}
			}
			if (--timeLeft <= 0)
			{
				flag = false;
			}
			if (flag || Main.netMode == 1)
			{
				return;
			}
			noSpawnCycle = true;
			active = 0;
			netSkip = -1;
			life = 0;
			NetMessage.CreateMessage1(23, whoAmI);
			NetMessage.SendMessage();
			if (aiStyle != 6)
			{
				return;
			}
			for (int num = (int)ai0; num > 0; num = (int)Main.npc[num].ai0)
			{
				if (Main.npc[num].active != 0)
				{
					Main.npc[num].active = 0;
					Main.npc[num].life = 0;
					Main.npc[num].netSkip = -1;
					NetMessage.CreateMessage1(23, num);
					NetMessage.SendMessage();
				}
			}
		}

		public static void SpawnNPC()
		{
			if (noSpawnCycle)
			{
				noSpawnCycle = false;
				return;
			}
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[i].active != 0)
				{
					num3++;
				}
			}
			int num4 = 0;
			bool flag3;
			bool flag4;
			bool flag5;
			bool flag6;
			while (true)
			{
				if (num4 >= 8)
				{
					return;
				}
				if (Main.player[num4].active != 0 && !Main.player[num4].dead)
				{
					flag3 = false;
					flag4 = false;
					flag5 = false;
					if (Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0 && Main.player[num4].position.Y < (float)(Main.worldSurfacePixels + 1080))
					{
						int num5 = 3000;
						if (Main.player[num4].position.X > Main.invasionX * 16f - (float)num5 && Main.player[num4].position.X < Main.invasionX * 16f + (float)num5)
						{
							flag4 = true;
						}
					}
					flag = false;
					spawnRate = 600;
					maxSpawns = 5;
					if (Main.hardMode)
					{
						spawnRate = 540;
						maxSpawns = 6;
					}
					if (Main.player[num4].position.Y > (float)((Main.maxTilesY - 200) * 16))
					{
						maxSpawns *= 2;
					}
					else if (Main.player[num4].position.Y > (float)((Main.rockLayer << 4) + 1080))
					{
						spawnRate = (int)((double)spawnRate * 0.4);
						maxSpawns = (int)((double)maxSpawns * 1.9);
					}
					else if (Main.player[num4].position.Y > (float)((Main.worldSurface << 4) + 1080))
					{
						if (Main.hardMode)
						{
							spawnRate = (int)((double)spawnRate * 0.45);
							maxSpawns = (int)((double)maxSpawns * 1.8);
						}
						else
						{
							spawnRate >>= 1;
							maxSpawns = (int)((double)maxSpawns * 1.7);
						}
					}
					else if (!Main.gameTime.dayTime)
					{
						spawnRate = (int)((double)spawnRate * 0.6);
						maxSpawns = (int)((double)maxSpawns * 1.3);
						if (Main.gameTime.bloodMoon)
						{
							spawnRate = (int)((double)spawnRate * 0.3);
							maxSpawns = (int)((double)maxSpawns * 1.8);
						}
					}
					if (Main.player[num4].zoneDungeon)
					{
						spawnRate = (int)((double)spawnRate * 0.4);
						maxSpawns = (int)((float)maxSpawns * 1.7f);
					}
					else if (Main.player[num4].zoneJungle)
					{
						spawnRate = (int)((double)spawnRate * 0.4);
						maxSpawns = (int)((float)maxSpawns * 1.5f);
					}
					else if (Main.player[num4].zoneEvil)
					{
						spawnRate = (int)((double)spawnRate * 0.65);
						maxSpawns = (int)((float)maxSpawns * 1.3f);
					}
					else if (Main.player[num4].zoneMeteor)
					{
						spawnRate = (int)((double)spawnRate * 0.4);
						maxSpawns = (int)((float)maxSpawns * 1.1f);
					}
					if (Main.player[num4].zoneHoly && Main.player[num4].position.Y > (float)((Main.rockLayer << 4) + 1080))
					{
						spawnRate = (int)((double)spawnRate * 0.65);
						maxSpawns = (int)((float)maxSpawns * 1.3f);
					}
					if (wof >= 0 && Main.player[num4].position.Y > (float)((Main.maxTilesY - 200) * 16))
					{
						maxSpawns = (int)((float)maxSpawns * 0.3f);
						spawnRate *= 3;
					}
					if (Main.player[num4].activeNPCs < (float)(int)((double)maxSpawns * 0.2))
					{
						spawnRate = (int)((float)spawnRate * 0.6f);
					}
					else if (Main.player[num4].activeNPCs < (float)(int)((double)maxSpawns * 0.4))
					{
						spawnRate = (int)((float)spawnRate * 0.7f);
					}
					else if (Main.player[num4].activeNPCs < (float)(int)((double)maxSpawns * 0.6))
					{
						spawnRate = (int)((float)spawnRate * 0.8f);
					}
					else if (Main.player[num4].activeNPCs < (float)(int)((double)maxSpawns * 0.8))
					{
						spawnRate = (int)((float)spawnRate * 0.9f);
					}
					if (Main.player[num4].position.Y * 16f > (float)(Main.worldSurface + Main.rockLayer >> 1) || Main.player[num4].zoneEvil)
					{
						if ((double)Main.player[num4].activeNPCs < (double)maxSpawns * 0.2)
						{
							spawnRate = (int)((float)spawnRate * 0.7f);
						}
						else if ((double)Main.player[num4].activeNPCs < (double)maxSpawns * 0.4)
						{
							spawnRate = (int)((float)spawnRate * 0.9f);
						}
					}
					if (Main.player[num4].inventory[Main.player[num4].selectedItem].type == 148)
					{
						spawnRate = (int)((double)spawnRate * 0.75);
						maxSpawns = (int)((float)maxSpawns * 1.5f);
					}
					if (Main.player[num4].enemySpawns)
					{
						spawnRate = (int)((double)spawnRate * 0.5);
						maxSpawns = (int)((float)maxSpawns * 2f);
					}
					if ((double)spawnRate < 60.0)
					{
						spawnRate = 60;
					}
					if (maxSpawns > 15)
					{
						maxSpawns = 15;
					}
					if (flag4)
					{
						maxSpawns = (int)(5.0 * (2.0 + 0.3 * (double)num3));
						spawnRate = 20;
					}
					if (Main.player[num4].zoneDungeon && !downedBoss3)
					{
						spawnRate = 10;
					}
					flag6 = false;
					if (!flag4 && (!Main.gameTime.bloodMoon || Main.gameTime.dayTime) && !Main.player[num4].zoneDungeon && !Main.player[num4].zoneEvil && !Main.player[num4].zoneMeteor)
					{
						if (Main.player[num4].townNPCs == 1f)
						{
							flag3 = true;
							if (Main.rand.Next(3) <= 1)
							{
								flag6 = true;
								maxSpawns = (int)((double)(float)maxSpawns * 0.6);
							}
							else
							{
								spawnRate = (int)((float)spawnRate * 2f);
							}
						}
						else if (Main.player[num4].townNPCs == 2f)
						{
							flag3 = true;
							if (Main.rand.Next(3) == 0)
							{
								flag6 = true;
								maxSpawns = (int)((double)(float)maxSpawns * 0.6);
							}
							else
							{
								spawnRate = (int)((float)spawnRate * 3f);
							}
						}
						else if (Main.player[num4].townNPCs >= 3f)
						{
							flag3 = true;
							flag6 = true;
							maxSpawns = (int)((double)(float)maxSpawns * 0.6);
						}
					}
					if (Main.player[num4].activeNPCs < (float)maxSpawns && Main.rand.Next(spawnRate) == 0)
					{
						int num6 = Main.player[num4].aabb.X >> 4;
						int num7 = Main.player[num4].aabb.Y >> 4;
						int num8 = num6 - 84;
						int num9 = num6 + 84;
						int num10 = num7 - 46;
						int num11 = num7 + 46;
						int num12 = num6 - 62;
						int num13 = num6 + 62;
						int num14 = num7 - 34;
						int num15 = num7 + 34;
						if (num8 < 0)
						{
							num8 = 0;
						}
						else if (num9 > Main.maxTilesX)
						{
							num9 = Main.maxTilesX;
						}
						if (num10 < 0)
						{
							num10 = 0;
						}
						else if (num11 > Main.maxTilesY)
						{
							num11 = Main.maxTilesY;
						}
						for (int j = 0; j < 48; j++)
						{
							int num16 = Main.rand.Next(num8, num9);
							int num17 = Main.rand.Next(num10, num11);
							if ((Main.tile[num16, num17].active != 0 && Main.tileSolid[Main.tile[num16, num17].type]) || Main.wallHouse[Main.tile[num16, num17].wall])
							{
								continue;
							}
							if (!flag4 && !flag6 && ((num17 < (int)((float)Main.worldSurface * 0.35f) && (num16 < (int)((double)Main.maxTilesX * 0.45) || num16 > (int)((double)Main.maxTilesX * 0.55) || Main.hardMode)) || (num17 < (int)((float)Main.worldSurface * 0.45f) && Main.hardMode && Main.rand.Next(10) == 0)))
							{
								_ = Main.tile[num16, num17].type;
								num = num16;
								num2 = num17;
								flag = true;
								flag2 = true;
							}
							if (!flag)
							{
								for (int k = num17; k < Main.maxTilesY; k++)
								{
									if (Main.tile[num16, k].active != 0 && Main.tileSolid[Main.tile[num16, k].type])
									{
										if (num16 < num12 || num16 > num13 || k < num14 || k > num15)
										{
											_ = Main.tile[num16, k].type;
											num = num16;
											num2 = k;
											flag = true;
										}
										break;
									}
								}
							}
							if (!flag)
							{
								continue;
							}
							int num18 = num - 1;
							int num19 = num + 1;
							int num20 = num2 - 3;
							int num21 = num2;
							if (num18 < 0 || num19 > Main.maxTilesX || num20 < 0 || num21 > Main.maxTilesY)
							{
								flag = false;
							}
							else
							{
								for (int l = num18; l < num19; l++)
								{
									for (int m = num20; m < num21; m++)
									{
										if (Main.tile[l, m].active != 0 && Main.tileSolid[Main.tile[l, m].type])
										{
											flag = false;
											break;
										}
										if (Main.tile[l, m].lava != 0)
										{
											flag = false;
											break;
										}
									}
									if (!flag)
									{
										break;
									}
								}
							}
							if (flag)
							{
								break;
							}
						}
					}
					if (flag)
					{
						Rectangle rectangle = new Rectangle(num * 16, num2 * 16, 16, 16);
						for (int n = 0; n < 8; n++)
						{
							if (Main.player[n].active != 0)
							{
								Rectangle rectangle2 = new Rectangle(Main.player[n].aabb.X + 10 - 960 - 62, Main.player[n].aabb.Y + 21 - 540 - 34, 2044, 1148);
								if (rectangle.Intersects(rectangle2))
								{
									flag = false;
									break;
								}
							}
						}
					}
					if (flag)
					{
						if (Main.player[num4].zoneDungeon && (!Main.tileDungeon[Main.tile[num, num2].type] || Main.tile[num, num2 - 1].wall == 0))
						{
							flag = false;
						}
						if (Main.tile[num, num2 - 1].liquid > 0 && Main.tile[num, num2 - 2].liquid > 0 && Main.tile[num, num2 - 1].lava == 0)
						{
							flag5 = true;
						}
					}
					if (flag)
					{
						break;
					}
				}
				num4++;
			}
			flag = false;
			int num22 = Main.tile[num, num2].type;
			int num23 = 196;
			int x = (num << 4) + 8;
			int y = num2 << 4;
			if (flag2)
			{
				if (Main.hardMode && Main.rand.Next(10) == 0 && !AnyNPCs(87, 159))
				{
					int num24 = (Main.rand.Next(2) == 0) ? 87 : 159;
					NewNPC(x, y, num24, 1);
				}
				else
				{
					NewNPC(x, y, 48);
				}
			}
			else if (flag4)
			{
				if (Main.invasionType == 1)
				{
					if (Main.rand.Next(9) == 0)
					{
						NewNPC(x, y, 29);
					}
					else if (Main.rand.Next(5) == 0)
					{
						NewNPC(x, y, 26);
					}
					else if (Main.rand.Next(3) == 0)
					{
						NewNPC(x, y, 111);
					}
					else if (Main.rand.Next(3) == 0)
					{
						NewNPC(x, y, 27);
					}
					else
					{
						NewNPC(x, y, 28);
					}
				}
				else if (Main.invasionType == 2)
				{
					if (Main.rand.Next(7) == 0)
					{
						NewNPC(x, y, 145);
					}
					else if (Main.rand.Next(3) == 0)
					{
						NewNPC(x, y, 143);
					}
					else
					{
						NewNPC(x, y, 144);
					}
				}
			}
			else if (flag5 && (num < 250 || num > Main.maxTilesX - 250) && num22 == 53 && num2 < Main.rockLayer)
			{
				int num25;
				switch (Main.rand.Next(16))
				{
				case 0:
					num25 = 65;
					break;
				case 1:
					num25 = 148;
					break;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					num25 = 67;
					break;
				default:
					num25 = 64;
					break;
				}
				NewNPC(x, y, num25);
			}
			else if (flag5 && ((num2 > Main.rockLayer && Main.rand.Next(2) == 0) || num22 == 60))
			{
				if (Main.hardMode && Main.rand.Next(3) > 0)
				{
					NewNPC(x, y, 102);
				}
				else
				{
					NewNPC(x, y, 58);
				}
			}
			else if (flag5 && num2 > Main.worldSurface && Main.rand.Next(3) == 0)
			{
				if (Main.hardMode)
				{
					NewNPC(x, y, 103);
				}
				else
				{
					NewNPC(x, y, 63);
				}
			}
			else if (flag5 && Main.rand.Next(4) == 0)
			{
				if (Main.player[num4].zoneEvil)
				{
					NewNPC(x, y, 57);
				}
				else
				{
					NewNPC(x, y, 55);
				}
			}
			else if (downedGoblins && Main.rand.Next(20) == 0 && !flag5 && num2 >= Main.rockLayer && num2 < Main.maxTilesY - 210 && !savedGoblin && !AnyNPCs(105))
			{
				NewNPC(x, y, 105);
			}
			else if (Main.hardMode && Main.rand.Next(20) == 0 && !flag5 && num2 >= Main.rockLayer && num2 < Main.maxTilesY - 210 && !savedWizard && !AnyNPCs(106))
			{
				NewNPC(x, y, 106);
			}
			else if (flag6)
			{
				if (flag5)
				{
					NewNPC(x, y, 55);
				}
				else
				{
					if (num22 != 2 && num22 != 109 && num22 != 147 && num2 <= Main.worldSurface)
					{
						return;
					}
					if (Main.rand.Next(2) == 0 && num2 <= Main.worldSurface)
					{
						NewNPC(x, y, 74);
					}
					else
					{
						NewNPC(x, y, 46);
					}
				}
			}
			else if (Main.player[num4].zoneDungeon)
			{
				if (!downedBoss3)
				{
					num23 = NewNPC(x, y, 68);
				}
				else if (!savedMech && !flag5 && Main.rand.Next(5) == 0 && num2 > Main.rockLayer && !AnyNPCs(123))
				{
					NewNPC(x, y, 123);
				}
				else if (Main.rand.Next(37) == 0)
				{
					num23 = NewNPC(x, y, 71);
				}
				else if (Main.rand.Next(4) == 0 && !NearSpikeBall(num, num2))
				{
					num23 = NewNPC(x, y, 70);
				}
				else if (Main.rand.Next(15) == 0)
				{
					num23 = NewNPC(x, y, 72);
				}
				else if (Main.rand.Next(9) == 0)
				{
					num23 = NewNPC(x, y, (Main.rand.Next(2) == 0) ? 34 : 158);
				}
				else if (Main.rand.Next(7) == 0)
				{
					num23 = NewNPC(x, y, 32);
				}
				else
				{
					num23 = NewNPC(x, y, 31);
					if (Main.rand.Next(4) == 0)
					{
						Main.npc[num23].SetDefaults("Big Boned");
					}
					else if (Main.rand.Next(5) == 0)
					{
						Main.npc[num23].SetDefaults("Short Bones");
					}
				}
			}
			else if (Main.player[num4].zoneMeteor)
			{
				num23 = NewNPC(x, y, 23);
			}
			else if (Main.player[num4].zoneEvil && Main.rand.Next(65) == 0)
			{
				num23 = ((!Main.hardMode || Main.rand.Next(4) == 0) ? NewNPC(x, y, 7, 1) : NewNPC(x, y, 98, 1));
			}
			else if (Main.hardMode && num2 > Main.worldSurface && Main.rand.Next(75) == 0)
			{
				num23 = NewNPC(x, y, 85);
			}
			else if (Main.hardMode && Main.tile[num, num2 - 1].wall == 2 && Main.rand.Next(20) == 0)
			{
				num23 = NewNPC(x, y, 85);
			}
			else if (Main.hardMode && num2 <= Main.worldSurface && !Main.gameTime.dayTime && (Main.rand.Next(20) == 0 || (Main.rand.Next(5) == 0 && Main.gameTime.moonPhase == 4)))
			{
				num23 = NewNPC(x, y, 82);
			}
			else if (num22 == 60 && Main.rand.Next(500) == 0 && !Main.gameTime.dayTime)
			{
				num23 = NewNPC(x, y, 52);
			}
			else if (num22 == 60 && num2 > Main.worldSurface + Main.rockLayer >> 1)
			{
				if (Main.rand.Next(3) == 0)
				{
					num23 = NewNPC(x, y, 43);
					Main.npc[num23].ai0 = num;
					Main.npc[num23].ai1 = num2;
					Main.npc[num23].netUpdate = true;
				}
				else if (Main.rand.Next(2) == 0)
				{
					num23 = NewNPC(x, y, 42);
					switch (Main.rand.Next(8))
					{
					case 0:
					case 1:
						Main.npc[num23].SetDefaults("Little Stinger");
						break;
					case 2:
						Main.npc[num23].SetDefaults("Big Stinger");
						break;
					}
				}
				else
				{
					num23 = NewNPC(x, y, 157);
				}
			}
			else if (num22 == 60 && Main.rand.Next(4) == 0)
			{
				num23 = NewNPC(x, y, 51);
			}
			else if (num22 == 60 && Main.rand.Next(8) == 0)
			{
				num23 = NewNPC(x, y, (Main.rand.Next(2) == 0) ? 56 : 156);
				Main.npc[num23].ai0 = num;
				Main.npc[num23].ai1 = num2;
				Main.npc[num23].netUpdate = true;
			}
			else if (Main.hardMode && num22 == 53 && Main.rand.Next(3) == 0)
			{
				num23 = NewNPC(x, y, 78);
			}
			else if (Main.hardMode && num22 == 112 && Main.rand.Next(2) == 0)
			{
				num23 = NewNPC(x, y, (Main.rand.Next(2) == 0) ? 79 : 152);
			}
			else if (Main.hardMode && num22 == 116 && Main.rand.Next(2) == 0)
			{
				num23 = NewNPC(x, y, (Main.rand.Next(2) == 0) ? 80 : 155);
			}
			else if (Main.hardMode && !flag5 && num2 < Main.rockLayer && (num22 == 116 || num22 == 117 || num22 == 109))
			{
				num23 = ((!Main.gameTime.dayTime && Main.rand.Next(2) == 0) ? NewNPC(x, y, (Main.rand.Next(2) == 0) ? 122 : 153) : ((Main.rand.Next(10) != 0) ? NewNPC(x, y, 75) : NewNPC(x, y, 86)));
			}
			else if (!flag3 && Main.hardMode && Main.rand.Next(50) == 0 && !flag5 && num2 >= Main.rockLayer && (num22 == 116 || num22 == 117 || num22 == 109))
			{
				num23 = NewNPC(x, y, 84);
			}
			else if ((num22 == 22 && Main.player[num4].zoneEvil) || num22 == 23 || num22 == 25 || num22 == 112)
			{
				if (Main.hardMode && num2 >= Main.rockLayer && Main.rand.Next(3) == 0)
				{
					num23 = NewNPC(x, y, 101);
					Main.npc[num23].ai0 = num;
					Main.npc[num23].ai1 = num2;
					Main.npc[num23].netUpdate = true;
				}
				else if (Main.hardMode && Main.rand.Next(3) == 0)
				{
					int num26;
					switch (Main.rand.Next(3))
					{
					case 0:
						num26 = 150;
						break;
					case 1:
						num26 = 81;
						break;
					default:
						num26 = 121;
						break;
					}
					num23 = NewNPC(x, y, num26);
				}
				else if (Main.hardMode && num2 >= Main.rockLayer && Main.rand.Next(40) == 0)
				{
					num23 = ((Main.rand.Next(2) != 0) ? NewNPC(x, y, 151) : NewNPC(x, y, 83));
				}
				else if (Main.hardMode && (Main.rand.Next(2) == 0 || num2 > Main.rockLayer))
				{
					num23 = NewNPC(x, y, 94);
				}
				else
				{
					num23 = NewNPC(x, y, 6);
					if (Main.rand.Next(3) == 0)
					{
						Main.npc[num23].SetDefaults("Little Eater");
					}
					else if (Main.rand.Next(3) == 0)
					{
						Main.npc[num23].SetDefaults("Big Eater");
					}
				}
			}
			else if (num2 <= Main.worldSurface)
			{
				if (Main.gameTime.dayTime)
				{
					int num27 = Math.Abs(num - Main.spawnTileX);
					if (num27 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num22 == 2 || num22 == 109 || num22 == 147))
					{
						NewNPC(x, y, 46);
					}
					else if (num27 < Main.maxTilesX / 3 && Main.rand.Next(15) == 0 && (num22 == 2 || num22 == 109 || num22 == 147))
					{
						NewNPC(x, y, 74);
					}
					else if (num27 > Main.maxTilesX / 3 && num22 == 2 && Main.rand.Next(300) == 0 && !AnyNPCs(50))
					{
						num23 = NewNPC(x, y, 50);
					}
					else if (num22 == 53 && Main.rand.Next(5) == 0 && !flag5)
					{
						num23 = NewNPC(x, y, (Main.rand.Next(2) == 0) ? 69 : 147);
					}
					else if (num22 == 53 && !flag5)
					{
						num23 = NewNPC(x, y, 61);
					}
					else if (num27 > Main.maxTilesX / 3 && Main.rand.Next(15) == 0)
					{
						num23 = NewNPC(x, y, 73);
					}
					else
					{
						num23 = NewNPC(x, y, 1);
						if (num22 == 60)
						{
							Main.npc[num23].SetDefaults("Jungle Slime");
						}
						else if (Main.rand.Next(3) == 0 || num27 < 200)
						{
							Main.npc[num23].SetDefaults("Green Slime");
						}
						else if (Main.rand.Next(10) == 0 && num27 > 400)
						{
							Main.npc[num23].SetDefaults("Purple Slime");
						}
					}
				}
				else if (Main.rand.Next(6) == 0 || (Main.gameTime.moonPhase == 4 && Main.rand.Next(2) == 0))
				{
					num23 = ((!Main.hardMode || Main.rand.Next(3) != 0) ? NewNPC(x, y, 2) : NewNPC(x, y, 133));
				}
				else if (Main.hardMode && Main.rand.Next(50) == 0 && Main.gameTime.bloodMoon && !AnyNPCs(109))
				{
					NewNPC(x, y, 109);
				}
				else if (Main.rand.Next(250) == 0 && Main.gameTime.bloodMoon)
				{
					NewNPC(x, y, 53);
				}
				else if (Main.gameTime.moonPhase == 0 && Main.hardMode && Main.rand.Next(3) != 0)
				{
					NewNPC(x, y, 104);
				}
				else if (Main.hardMode && Main.rand.Next(3) == 0)
				{
					NewNPC(x, y, 140);
				}
				else if (Main.rand.Next(3) == 0)
				{
					NewNPC(x, y, 132);
				}
				else
				{
					NewNPC(x, y, 3);
				}
			}
			else if (num2 <= Main.rockLayer)
			{
				if (!flag3 && Main.rand.Next(50) == 0)
				{
					num23 = ((!Main.hardMode) ? NewNPC(x, y, 10, 1) : NewNPC(x, y, 95, 1));
				}
				else if (Main.hardMode && Main.rand.Next(3) == 0)
				{
					num23 = NewNPC(x, y, 140);
				}
				else if (Main.hardMode && Main.rand.Next(4) != 0)
				{
					num23 = NewNPC(x, y, 141);
				}
				else
				{
					num23 = NewNPC(x, y, 1);
					if (Main.rand.Next(5) == 0)
					{
						Main.npc[num23].SetDefaults("Yellow Slime");
					}
					else if (Main.rand.Next(2) == 0)
					{
						Main.npc[num23].SetDefaults("Red Slime");
					}
				}
			}
			else if (num2 > Main.maxTilesY - 190)
			{
				int num28 = 60;
				int start = 0;
				if (Main.rand.Next(40) == 0 && !AnyNPCs(39))
				{
					num28 = 39;
					start = 1;
				}
				else if (Main.rand.Next(14) == 0)
				{
					num28 = 24;
				}
				else if (Main.rand.Next(8) == 0)
				{
					switch (Main.rand.Next(7))
					{
					case 0:
						num28 = 66;
						break;
					case 1:
					case 2:
					case 3:
						num28 = 62;
						break;
					default:
						num28 = 165;
						break;
					}
				}
				else if (Main.rand.Next(3) == 0)
				{
					num28 = 59;
				}
				num23 = NewNPC(x, y, num28, start);
			}
			else if ((num22 == 116 || num22 == 117) && !flag3 && Main.rand.Next(8) == 0)
			{
				num23 = NewNPC(x, y, (Main.rand.Next(2) == 0) ? 120 : 154);
			}
			else if (!flag3 && Main.rand.Next(75) == 0 && !Main.player[num4].zoneHoly)
			{
				num23 = NewNPC(x, y, Main.hardMode ? 95 : 10, 1);
			}
			else if (!Main.hardMode && Main.rand.Next(10) == 0)
			{
				num23 = NewNPC(x, y, 16);
			}
			else if (!Main.hardMode && Main.rand.Next(4) == 0)
			{
				num23 = NewNPC(x, y, 1);
				if (Main.player[num4].zoneJungle)
				{
					Main.npc[num23].SetDefaults("Jungle Slime");
				}
				else
				{
					Main.npc[num23].SetDefaults("Black Slime");
				}
			}
			else if (Main.rand.Next(2) != 0)
			{
				num23 = ((Main.hardMode && (Main.player[num4].zoneHoly & (Main.rand.Next(2) == 0))) ? NewNPC(x, y, 138) : (Main.player[num4].zoneJungle ? NewNPC(x, y, 51) : ((Main.hardMode && Main.player[num4].zoneHoly) ? NewNPC(x, y, 137) : ((!Main.hardMode || Main.rand.Next(6) <= 0) ? NewNPC(x, y, 49) : NewNPC(x, y, 93)))));
			}
			else if (num2 > Main.rockLayer + Main.maxTilesY >> 1 && Main.rand.Next(700) == 0)
			{
				num23 = NewNPC(x, y, 45);
			}
			else if (Main.hardMode && Main.rand.Next(10) != 0)
			{
				if (Main.rand.Next(2) == 0)
				{
					num23 = NewNPC(x, y, 77);
					if (num2 > Main.rockLayer + Main.maxTilesY >> 1 && Main.rand.Next(5) == 0)
					{
						Main.npc[num23].SetDefaults("Heavy Skeleton");
					}
				}
				else
				{
					num23 = NewNPC(x, y, 110);
				}
			}
			else if (Main.rand.Next(15) == 0)
			{
				int num29 = (Main.rand.Next(2) == 0) ? 44 : 149;
				num23 = NewNPC(x, y, num29);
			}
			else
			{
				num23 = NewNPC(x, y, 21);
			}
			if (num23 < 196)
			{
				if (Main.npc[num23].type == 1 && Main.rand.Next(250) == 0)
				{
					Main.npc[num23].SetDefaults("Pinky");
				}
				NetMessage.CreateMessage1(23, num23);
				NetMessage.SendMessage();
			}
		}

		public static bool SpawnWOF(ref Vector2 pos, bool force = false)
		{
			if (!force && (int)pos.Y >> 4 < Main.maxTilesY - 205)
			{
				return false;
			}
			if (wof >= 0)
			{
				return false;
			}
			if (Main.netMode == 1)
			{
				return false;
			}
			int num = -16;
			int num2 = (int)pos.X;
			if (num2 >> 4 > Main.maxTilesX >> 1)
			{
				num = 16;
			}
			bool flag;
			do
			{
				flag = true;
				for (int i = 0; i < 8; i++)
				{
					if (Main.player[i].active != 0 && Main.player[i].aabb.X > num2 - 1200 && Main.player[i].aabb.X < num2 + 1200)
					{
						num2 += num;
						flag = false;
						break;
					}
				}
				if ((num < 0 && num2 >> 4 < 42) || (num > 0 && num2 >> 4 > Main.maxTilesX - 34))
				{
					flag = true;
				}
			}
			while (!flag);
			int num3 = (int)pos.Y;
			int num4 = num2 >> 4;
			int num5 = num3 >> 4;
			int num6 = 0;
			try
			{
				while (true)
				{
					if (!WorldGen.SolidTile(num4, num5 - num6) && Main.tile[num4, num5 - num6].liquid < 100)
					{
						num5 -= num6;
						break;
					}
					if (!WorldGen.SolidTile(num4, num5 + num6) && Main.tile[num4, num5 + num6].liquid < 100)
					{
						num5 += num6;
						break;
					}
					num6++;
				}
			}
			catch
			{
			}
			num3 = num5 << 4;
			int num7 = NewNPC(num2, num3, 113);
			Main.npc[num7].direction = (sbyte)((num < 0) ? 1 : (-1));
			if (Main.npc[num7].displayName.Length == 0)
			{
				Main.npc[num7].displayName = Main.npc[num7].name;
			}
			NetMessage.SendText(Main.npc[num7].displayName, 16, 175, 75, 255, -1);
			return true;
		}

		public static void SpawnOnPlayer(Player p, int Type)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			int num2 = 0;
			int num3 = (p.aabb.X >> 4) - 168;
			int num4 = (p.aabb.X >> 4) + 168;
			int num5 = (p.aabb.Y >> 4) - 92;
			int num6 = (p.aabb.Y >> 4) + 92;
			int num7 = (p.aabb.X >> 4) - 62;
			int num8 = (p.aabb.X >> 4) + 62;
			int num9 = (p.aabb.Y >> 4) - 34;
			int num10 = (p.aabb.Y >> 4) + 34;
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
			for (int i = 0; i < 1000; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					int num11 = Main.rand.Next(num3, num4);
					int num12 = Main.rand.Next(num5, num6);
					if (Main.tile[num11, num12].active == 0 || !Main.tileSolid[Main.tile[num11, num12].type])
					{
						if (Main.wallHouse[Main.tile[num11, num12].wall] && i < 999)
						{
							continue;
						}
						for (int k = num12; k < Main.maxTilesY; k++)
						{
							if (Main.tile[num11, k].active != 0 && Main.tileSolid[Main.tile[num11, k].type])
							{
								if (num11 < num7 || num11 > num8 || k < num9 || k > num10 || i == 999)
								{
									_ = Main.tile[num11, k].type;
									num = num11;
									num2 = k;
									flag = true;
								}
								break;
							}
						}
						if (flag && i < 999)
						{
							int num13 = num - 1;
							int num14 = num + 1;
							int num15 = num2 - 3;
							int num16 = num2;
							if (num13 < 0)
							{
								flag = false;
							}
							if (num14 > Main.maxTilesX)
							{
								flag = false;
							}
							if (num15 < 0)
							{
								flag = false;
							}
							if (num16 > Main.maxTilesY)
							{
								flag = false;
							}
							if (flag)
							{
								for (int l = num13; l < num14; l++)
								{
									for (int m = num15; m < num16; m++)
									{
										if (Main.tile[l, m].active != 0 && Main.tileSolid[Main.tile[l, m].type])
										{
											flag = false;
											break;
										}
									}
								}
							}
						}
					}
					if (flag || flag)
					{
						break;
					}
				}
				if (flag && i < 999)
				{
					Rectangle rectangle = new Rectangle(num * 16, num2 * 16, 16, 16);
					for (int n = 0; n < 8; n++)
					{
						if (Main.player[n].active != 0)
						{
							Rectangle rectangle2 = new Rectangle(Main.player[n].aabb.X + 10 - 960 - 62, Main.player[n].aabb.Y + 21 - 540 - 34, 2044, 1148);
							if (rectangle.Intersects(rectangle2))
							{
								flag = false;
							}
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			int num17 = 196;
			num17 = NewNPC(num * 16 + 8, num2 * 16, Type, 1);
			if (num17 != 196)
			{
				Main.npc[num17].target = p.whoAmI;
				Main.npc[num17].timeLeft *= 20;
				string text = Main.npc[num17].displayName;
				if (text.Length == 0)
				{
					text = Main.npc[num17].name;
				}
				NetMessage.CreateMessage1(23, num17);
				NetMessage.SendMessage();
				switch (Type)
				{
				case 50:
				case 82:
				case 126:
					break;
				case 125:
					NetMessage.SendText(34, 175, 75, 255, -1);
					break;
				default:
					NetMessage.SendText(text, 16, 175, 75, 255, -1);
					break;
				}
			}
		}

		public static int NewNPC(int X, int Y, int Type, int Start = 0)
		{
			int num = 196;
			for (int i = Start; i < 196; i++)
			{
				if (Main.npc[i].active == 0)
				{
					num = i;
					break;
				}
			}
			if (num < 196)
			{
				Main.npc[num].SetDefaults(Type);
				Main.npc[num].position.X = (Main.npc[num].aabb.X = X - (Main.npc[num].width >> 1));
				Main.npc[num].position.Y = (Main.npc[num].aabb.Y = Y - Main.npc[num].height);
				Main.npc[num].active = 1;
				Main.npc[num].timeLeft = 750;
				Main.npc[num].wet = Collision.WetCollision(ref Main.npc[num].position, Main.npc[num].width, Main.npc[num].height);
				if (Type == 50)
				{
					NetMessage.SendText(Main.npc[num].name, 16, 175, 75, 255, -1);
				}
			}
			return num;
		}

		public void Transform(int newType)
		{
			Vector2 vector = velocity;
			position.Y += (int)height;
			sbyte b = spriteDirection;
			SetDefaults(newType);
			spriteDirection = b;
			TargetClosest();
			velocity = vector;
			position.Y -= (int)height;
			if (newType == 107 || newType == 108)
			{
				homeTileX = (short)((int)position.X + (width >> 1) >> 4);
				homeTileY = (short)((int)position.Y + height >> 4);
				homeless = true;
			}
			netUpdate = true;
			NetMessage.CreateMessage1(23, whoAmI);
			NetMessage.SendMessage();
		}

		public double StrikeNPC(int Damage, float knockBack, int hitDirection, bool crit = false, bool noEffect = false)
		{
			if (active == 0 || life <= 0)
			{
				return 0.0;
			}
			double num = Main.CalculateDamage(Damage, defense);
			if (crit)
			{
				num *= 2.0;
			}
			if (Damage != 9999 && lifeMax > 1)
			{
				if (friendly)
				{
					CombatText.NewText(position, width, height, (int)num, crit);
				}
				else
				{
					CombatText.NewText(position, width, height, (int)num, crit);
				}
				if (drawMyName < 96)
				{
					drawMyName = 96;
				}
			}
			if (num >= 1.0)
			{
				justHit = true;
				if (townNPC)
				{
					ai0 = 1f;
					ai1 = 300 + Main.rand.Next(300);
					ai2 = 0f;
					direction = (sbyte)hitDirection;
					netUpdate = true;
				}
				if (aiStyle == 8 && Main.netMode != 1)
				{
					ai0 = 400f;
					TargetClosest();
				}
				if (realLife >= 0)
				{
					Main.npc[realLife].life -= (int)num;
					life = Main.npc[realLife].life;
					lifeMax = Main.npc[realLife].lifeMax;
				}
				else
				{
					life -= (int)num;
				}
				if (knockBack > 0f && knockBackResist > 0f)
				{
					float num2 = knockBack * knockBackResist;
					if (num2 > 8f)
					{
						num2 = 8f;
					}
					if (crit)
					{
						num2 *= 1.4f;
					}
					if (num * 10.0 < (double)lifeMax)
					{
						if (hitDirection < 0 && velocity.X > 0f - num2)
						{
							if (velocity.X > 0f)
							{
								velocity.X -= num2;
							}
							velocity.X -= num2;
							if (velocity.X < 0f - num2)
							{
								velocity.X = 0f - num2;
							}
						}
						else if (hitDirection > 0 && velocity.X < num2)
						{
							if (velocity.X < 0f)
							{
								velocity.X += num2;
							}
							velocity.X += num2;
							if (velocity.X > num2)
							{
								velocity.X = num2;
							}
						}
						num2 = (noGravity ? (num2 * -0.5f) : (num2 * -0.75f));
						if (velocity.Y > num2)
						{
							velocity.Y += num2;
							if (velocity.Y < num2)
							{
								velocity.Y = num2;
							}
						}
					}
					else
					{
						if (!noGravity)
						{
							velocity.Y = (0f - num2) * 0.75f * knockBackResist;
						}
						else
						{
							velocity.Y = (0f - num2) * 0.5f * knockBackResist;
						}
						velocity.X = num2 * (float)hitDirection * knockBackResist;
					}
				}
				if ((type == 113 || type == 114) && life <= 0)
				{
					for (int i = 0; i < 196; i++)
					{
						if (Main.npc[i].active != 0 && (Main.npc[i].type == 113 || Main.npc[i].type == 114))
						{
							Main.npc[i].HitEffect(hitDirection, num);
						}
					}
				}
				else if (active != 0)
				{
					HitEffect(hitDirection, num);
				}
				if (soundHit > 0)
				{
					Main.PlaySound(3, (int)position.X, (int)position.Y, soundHit);
				}
				if (realLife >= 0)
				{
					Main.npc[realLife].checkDead();
				}
				else
				{
					checkDead();
				}
				return num;
			}
			return 0.0;
		}

		public void checkDead()
		{
			if (active == 0 || (realLife >= 0 && realLife != whoAmI) || life > 0)
			{
				return;
			}
			noSpawnCycle = true;
			if (townNPC && type != 37 && Main.netMode != 1)
			{
				string prefix = displayName;
				if (displayName.Length == 0)
				{
					prefix = name;
				}
				NetMessage.SendText(prefix, 19, 255, 25, 25, -1);
				chrName[type] = null;
				setNames();
				NetMessage.CreateMessage1(56, type);
				NetMessage.SendMessage();
			}
			if (townNPC && Main.netMode != 1 && homeless && WorldGen.spawnNPC == type)
			{
				WorldGen.spawnNPC = 0;
			}
			if (soundKilled > 0)
			{
				Main.PlaySound(4, (int)position.X, (int)position.Y, soundKilled);
			}
			NPCLoot();
			if ((type >= 26 && type <= 29) || type == 111 || (type >= 143 && type <= 145))
			{
				Main.invasionSize--;
			}
			active = 0;
		}

		public unsafe void NPCLoot()
		{
			if (Main.hardMode && lifeMax > 1 && damage > 0 && !friendly && aabb.Y > Main.rockLayerPixels && type != 121 && value > 0f && Main.rand.Next(7) == 0)
			{
				Player player = Player.FindClosest(ref aabb);
				if (player.zoneEvil)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 521);
				}
				if (player.zoneHoly)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 520);
				}
			}
			if (Time.xMas && lifeMax > 1 && damage > 0 && !friendly && type != 121 && value > 0f && Main.rand.Next(13) == 0)
			{
				Item.NewItem(aabb.X, aabb.Y, width, height, Main.rand.Next(599, 602));
			}
			switch (type)
			{
			case 109:
				if (!downedClown)
				{
					downedClown = true;
					if (Main.netMode == 2)
					{
						NetMessage.CreateMessage0(7);
						NetMessage.SendMessage();
					}
				}
				break;
			case 85:
				if (value > 0f)
				{
					switch (Main.rand.Next(7))
					{
					case 0:
						Item.NewItem(aabb.X, aabb.Y, width, height, 437, 1, noBroadcast: false, -1);
						break;
					case 1:
						Item.NewItem(aabb.X, aabb.Y, width, height, 517, 1, noBroadcast: false, -1);
						break;
					case 2:
						Item.NewItem(aabb.X, aabb.Y, width, height, 535, 1, noBroadcast: false, -1);
						break;
					case 3:
						Item.NewItem(aabb.X, aabb.Y, width, height, 536, 1, noBroadcast: false, -1);
						break;
					case 4:
						Item.NewItem(aabb.X, aabb.Y, width, height, 532, 1, noBroadcast: false, -1);
						break;
					case 5:
						Item.NewItem(aabb.X, aabb.Y, width, height, 393, 1, noBroadcast: false, -1);
						break;
					default:
						Item.NewItem(aabb.X, aabb.Y, width, height, 554, 1, noBroadcast: false, -1);
						break;
					}
				}
				break;
			case 87:
			case 159:
				Item.NewItem(aabb.X, aabb.Y, width, height, 575, Main.rand.Next(5, 11));
				break;
			case 143:
			case 144:
			case 145:
				Item.NewItem(aabb.X, aabb.Y, width, height, 593, Main.rand.Next(5, 11));
				break;
			case 79:
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 527);
				}
				break;
			case 80:
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 528);
				}
				break;
			case 98:
			case 101:
				Item.NewItem(aabb.X, aabb.Y, width, height, 522, Main.rand.Next(2, 6));
				break;
			case 86:
				Item.NewItem(aabb.X, aabb.Y, width, height, 526);
				break;
			case 113:
			{
				Item.NewItem(aabb.X, aabb.Y, width, height, 367, 1, noBroadcast: false, -1);
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, Main.rand.Next(489, 492), 1, noBroadcast: false, -1);
				}
				else
				{
					int num3;
					switch (Main.rand.Next(3))
					{
					case 0:
						num3 = 514;
						break;
					case 1:
						num3 = 426;
						break;
					default:
						num3 = 434;
						break;
					}
					Item.NewItem(aabb.X, aabb.Y, width, height, num3, 1, noBroadcast: false, -1);
				}
				if (Main.netMode == 1)
				{
					break;
				}
				int num4 = aabb.X + (width >> 1) >> 4;
				int num5 = aabb.Y + (height >> 1) >> 4;
				int num6 = (width >> 5) + 1;
				for (int i = num4 - num6; i <= num4 + num6; i++)
				{
					for (int j = num5 - num6; j <= num5 + num6; j++)
					{
						bool flag = false;
						fixed (Tile* ptr = &Main.tile[i, j])
						{
							if ((i == num4 - num6 || i == num4 + num6 || j == num5 - num6 || j == num5 + num6) && ptr->active == 0)
							{
								ptr->active = 1;
								ptr->type = 140;
								WorldGen.SquareTileFrame(i, j);
								flag = true;
							}
							if (ptr->liquid > 0)
							{
								ptr->lava = 0;
								ptr->liquid = 0;
								flag = true;
							}
						}
						if (flag)
						{
							NetMessage.SendTile(i, j);
						}
					}
				}
				break;
			}
			case 1:
			case 16:
			case 138:
			case 141:
				Item.NewItem(aabb.X, aabb.Y, width, height, 23, Main.rand.Next(1, 3));
				break;
			case 81:
				Item.NewItem(aabb.X, aabb.Y, width, height, 23, Main.rand.Next(2, 5));
				break;
			case 122:
				Item.NewItem(aabb.X, aabb.Y, width, height, 23, Main.rand.Next(5, 11));
				break;
			case 71:
				Item.NewItem(aabb.X, aabb.Y, width, height, 327);
				break;
			case 75:
				Item.NewItem(aabb.X, aabb.Y, width, height, 501, Main.rand.Next(1, 4));
				break;
			case 2:
			{
				int num7 = Main.rand.Next(150);
				if (num7 < 50)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, (num7 == 38) ? 236 : 38);
				}
				break;
			}
			case 104:
				if (Main.rand.Next(60) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 485, 1, noBroadcast: false, -1);
				}
				break;
			case 58:
			{
				int num2 = Main.rand.Next(500);
				if (num2 < 13)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, (num2 == 0) ? 263 : 118);
				}
				break;
			}
			case 102:
				if (Main.rand.Next(500) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 263);
				}
				break;
			case 3:
			case 132:
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 216, 1, noBroadcast: false, -1);
				}
				break;
			case 62:
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 272, 1, noBroadcast: false, -1);
				}
				break;
			case 66:
				Item.NewItem(aabb.X, aabb.Y, width, height, 267);
				break;
			case 52:
				Item.NewItem(aabb.X, aabb.Y, width, height, 251);
				break;
			case 53:
				Item.NewItem(aabb.X, aabb.Y, width, height, 239);
				break;
			case 54:
				Item.NewItem(aabb.X, aabb.Y, width, height, 260);
				break;
			case 55:
				Item.NewItem(aabb.X, aabb.Y, width, height, 261);
				break;
			case 69:
			case 147:
				if (Main.rand.Next(7) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 323);
				}
				break;
			case 73:
				Item.NewItem(aabb.X, aabb.Y, width, height, 362, Main.rand.Next(1, 3));
				break;
			case 4:
				Item.NewItem(aabb.X, aabb.Y, width, height, 47, Main.rand.Next(20, 50));
				Item.NewItem(aabb.X, aabb.Y, width, height, 56, Main.rand.Next(10, 30));
				Item.NewItem(aabb.X, aabb.Y, width, height, 56, Main.rand.Next(10, 30));
				Item.NewItem(aabb.X, aabb.Y, width, height, 56, Main.rand.Next(10, 30));
				Item.NewItem(aabb.X, aabb.Y, width, height, 59, Main.rand.Next(1, 4));
				break;
			case 166:
				Item.NewItem(aabb.X, aabb.Y, width, height, 366, Main.rand.Next(10, 30));
				Item.NewItem(aabb.X, aabb.Y, width, height, 620, Main.rand.Next(5, 10));
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 604 + Main.rand.Next(9));
				}
				break;
			case 6:
			case 94:
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 68);
				}
				break;
			case 7:
			case 8:
			case 9:
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 68, Main.rand.Next(1, 3));
				}
				Item.NewItem(aabb.X, aabb.Y, width, height, 69, Main.rand.Next(3, 9));
				break;
			case 10:
			case 11:
			case 12:
			case 95:
			case 96:
			case 97:
				if (Main.rand.Next(500) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 215);
				}
				break;
			case 47:
				if (Main.rand.Next(75) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 243);
				}
				break;
			case 13:
			case 14:
			case 15:
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 86, Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 56, Main.rand.Next(2, 6));
				}
				if (boss)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 56, Main.rand.Next(10, 30));
					Item.NewItem(aabb.X, aabb.Y, width, height, 56, Main.rand.Next(10, 31));
				}
				if (Main.rand.Next(3) == 0 && Player.FindClosest(ref aabb).canHeal())
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 58);
				}
				break;
			case 116:
			case 117:
			case 118:
			case 119:
			case 139:
				Item.NewItem(aabb.X, aabb.Y, width, height, 58);
				break;
			case 63:
			case 64:
			case 103:
				Item.NewItem(aabb.X, aabb.Y, width, height, 282, Main.rand.Next(1, 5));
				break;
			case 21:
			case 44:
			case 149:
				if (Main.rand.Next(25) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 118);
				}
				else if (type != 21)
				{
					if (Main.rand.Next(20) == 0)
					{
						Item.NewItem(aabb.X, aabb.Y, width, height, Main.rand.Next(410, 412));
					}
					else
					{
						Item.NewItem(aabb.X, aabb.Y, width, height, 166, Main.rand.Next(1, 4));
					}
				}
				break;
			case 45:
				Item.NewItem(aabb.X, aabb.Y, width, height, 238);
				break;
			case 50:
				Item.NewItem(aabb.X, aabb.Y, width, height, Main.rand.Next(256, 259));
				break;
			case 23:
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 116);
				}
				break;
			case 24:
				if (Main.rand.Next(300) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 244);
				}
				break;
			case 31:
			case 32:
			case 34:
				if (Main.rand.Next(65) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 327);
				}
				else
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 154, Main.rand.Next(1, 4));
				}
				break;
			case 26:
			case 27:
			case 28:
			case 29:
			case 111:
			{
				int num = Main.rand.Next(200);
				if (num < 100)
				{
					if (num == 0)
					{
						Item.NewItem(aabb.X, aabb.Y, width, height, 160);
					}
					else
					{
						Item.NewItem(aabb.X, aabb.Y, width, height, 161, Main.rand.Next(1, 6));
					}
				}
				break;
			}
			case 42:
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 209);
				}
				break;
			case 43:
				if (Main.rand.Next(4) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 210);
				}
				break;
			case 65:
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 268);
				}
				else
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 319);
				}
				break;
			case 148:
				if (Main.rand.Next(25) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 268);
				}
				break;
			case 48:
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 320);
				}
				break;
			case 125:
			case 126:
				if (!AnyNPCs((type == 125) ? 126 : 125))
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 549, Main.rand.Next(20, 31));
					break;
				}
				value = 0f;
				boss = false;
				break;
			case 127:
				Item.NewItem(aabb.X, aabb.Y, width, height, 547, Main.rand.Next(20, 31));
				break;
			case 134:
				Item.NewItem(aabb.X, aabb.Y, width, height, 548, Main.rand.Next(20, 31));
				break;
			}
			if (boss)
			{
				string prefix = displayName;
				switch (type)
				{
				case 4:
					downedBoss1 = true;
					break;
				case 13:
				case 14:
				case 15:
					downedBoss2 = true;
					break;
				case 35:
					downedBoss3 = true;
					break;
				case 125:
				case 126:
					prefix = Lang.misc[20];
					UI.SetTriggerStateForAll(Trigger.KilledTheTwins);
					break;
				case 127:
					UI.SetTriggerStateForAll(Trigger.KilledSkeletronPrime);
					break;
				case 134:
					UI.SetTriggerStateForAll(Trigger.KilledDestroyer);
					break;
				}
				short num8 = netID;
				if (realLife > 0)
				{
					num8 = Main.npc[realLife].netID;
				}
				UI.IncreaseStatisticForAll(Statistics.GetBossStatisticEntryFromNetID(num8));
				int num9 = 28;
				if (type == 113)
				{
					num9 = 188;
				}
				else if (type > 113)
				{
					num9 = 499;
				}
				Item.NewItem(aabb.X, aabb.Y, width, height, num9, Main.rand.Next(5, 16));
				for (int num10 = Main.rand.Next(5, 10); num10 > 0; num10--)
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 58);
				}
				if (Main.netMode != 1)
				{
					if (type == 113)
					{
						WorldGen.StartHardmode();
					}
					NetMessage.SendText(prefix, 17, 175, 75, 255, -1);
					NetMessage.CreateMessage0(7);
					NetMessage.SendMessage();
				}
			}
			if (lifeMax > 1 && damage > 0)
			{
				Player player2 = Player.FindClosest(ref aabb);
				if (Main.rand.Next(6) == 0)
				{
					if (Main.rand.Next(2) == 0 && player2.canUseMana())
					{
						Item.NewItem(aabb.X, aabb.Y, width, height, 184);
					}
					else if (Main.rand.Next(2) == 0 && player2.canHeal())
					{
						Item.NewItem(aabb.X, aabb.Y, width, height, 58);
					}
				}
				if (Main.rand.Next(2) == 0 && player2.canUseMana())
				{
					Item.NewItem(aabb.X, aabb.Y, width, height, 184);
				}
			}
			float num11 = value;
			num11 *= 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
			if (Main.rand.Next(5) == 0)
			{
				num11 *= 1f + (float)Main.rand.Next(5, 11) * 0.01f;
			}
			if (Main.rand.Next(10) == 0)
			{
				num11 *= 1f + (float)Main.rand.Next(10, 21) * 0.01f;
			}
			if (Main.rand.Next(15) == 0)
			{
				num11 *= 1f + (float)Main.rand.Next(15, 31) * 0.01f;
			}
			if (Main.rand.Next(20) == 0)
			{
				num11 *= 1f + (float)Main.rand.Next(20, 41) * 0.01f;
			}
			int num12 = (int)num11;
			while (num12 > 0)
			{
				if (num12 > 1000000)
				{
					int num13 = num12 / 1000000;
					if (num13 > 50 && Main.rand.Next(5) == 0)
					{
						num13 /= Main.rand.Next(1, 4);
					}
					if (Main.rand.Next(5) == 0)
					{
						num13 /= Main.rand.Next(1, 4);
					}
					if (num13 > 0)
					{
						num12 -= 1000000 * num13;
						Item.NewItem(aabb.X, aabb.Y, width, height, 74, num13);
					}
				}
				else if (num12 > 10000)
				{
					int num14 = num12 / 10000;
					if (num14 > 50 && Main.rand.Next(5) == 0)
					{
						num14 /= Main.rand.Next(1, 4);
					}
					if (Main.rand.Next(5) == 0)
					{
						num14 /= Main.rand.Next(1, 4);
					}
					if (num14 > 0)
					{
						num12 -= 10000 * num14;
						Item.NewItem(aabb.X, aabb.Y, width, height, 73, num14);
					}
				}
				else if (num12 > 100)
				{
					int num15 = num12 / 100;
					if (num15 > 50 && Main.rand.Next(5) == 0)
					{
						num15 /= Main.rand.Next(1, 4);
					}
					if (Main.rand.Next(5) == 0)
					{
						num15 /= Main.rand.Next(1, 4);
					}
					if (num15 > 0)
					{
						num12 -= 100 * num15;
						Item.NewItem(aabb.X, aabb.Y, width, height, 72, num15);
					}
				}
				else if (num12 > 0)
				{
					int num16 = num12;
					if (num16 > 50 && Main.rand.Next(5) == 0)
					{
						num16 /= Main.rand.Next(1, 4);
					}
					if (Main.rand.Next(5) == 0)
					{
						num16 /= Main.rand.Next(1, 4);
					}
					if (num16 < 1)
					{
						num16 = 1;
					}
					num12 -= num16;
					Item.NewItem(aabb.X, aabb.Y, width, height, 71, num16);
				}
			}
		}

		public unsafe void HitEffect(int hitDirection = 0, double dmg = 10.0)
		{
			if (type == 1 || type == 16 || type == 71)
			{
				if (life > 0)
				{
					int num = (int)(dmg / (double)lifeMax * 80.0);
					while (num > 0 && null != Main.dust.NewDust(4, ref aabb, hitDirection, -1.0, alpha, color))
					{
						num--;
					}
					return;
				}
				for (int i = 0; i < 48; i++)
				{
					if (null == Main.dust.NewDust(4, ref aabb, 2 * hitDirection, -2.0, alpha, color))
					{
						break;
					}
				}
				if (type != 16 || Main.netMode == 1)
				{
					return;
				}
				for (int num2 = Main.rand.Next(1, 3); num2 >= 0; num2--)
				{
					int num3 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, 1);
					if (num3 < 196)
					{
						Main.npc[num3].SetDefaults("Baby Slime");
						Main.npc[num3].velocity.X = velocity.X * 2f;
						Main.npc[num3].velocity.Y = velocity.Y;
						Main.npc[num3].velocity.X += (float)Main.rand.Next(-20, 20) * 0.1f + (float)(num2 * direction) * 0.3f;
						Main.npc[num3].velocity.Y -= (float)Main.rand.Next(10) * 0.1f + (float)num2;
						Main.npc[num3].ai1 = num2;
						NetMessage.CreateMessage1(23, num3);
						NetMessage.SendMessage();
					}
				}
			}
			else if (type == 143 || type == 144 || type == 145)
			{
				if (life > 0)
				{
					for (int num4 = (int)(dmg / (double)lifeMax * 80.0); num4 > 0; num4--)
					{
						Dust* ptr = Main.dust.NewDust(76, ref aabb, hitDirection, -1.0);
						if (ptr == null)
						{
							break;
						}
						ptr->noGravity = true;
					}
					return;
				}
				for (int j = 0; j < 32; j++)
				{
					Dust* ptr = Main.dust.NewDust(76, ref aabb, hitDirection, -1.0);
					if (ptr == null)
					{
						break;
					}
					ptr->noGravity = true;
					ptr->scale *= 1.2f;
				}
			}
			else if (type == 141)
			{
				if (life > 0)
				{
					int num5 = (int)(dmg / (double)lifeMax * 80.0);
					while (num5 > 0 && null != Main.dust.NewDust(4, ref aabb, hitDirection, -1.0, alpha, new Color(210, 230, 140)))
					{
						num5--;
					}
					return;
				}
				for (int k = 0; k < 40; k++)
				{
					if (null == Main.dust.NewDust(4, ref aabb, 2 * hitDirection, -2.0, alpha, new Color(210, 230, 140)))
					{
						break;
					}
				}
			}
			else if (type == 112)
			{
				for (int l = 0; l < 16; l++)
				{
					Dust* ptr2 = Main.dust.NewDust(aabb.X, aabb.Y + 2, width, height, 18, 0.0, 0.0, 100, default(Color), 2.0);
					if (ptr2 == null)
					{
						break;
					}
					if (Main.rand.Next(2) == 0)
					{
						ptr2->scale *= 0.6f;
						continue;
					}
					ptr2->velocity.X *= 1.4f;
					ptr2->velocity.Y *= 1.4f;
					ptr2->noGravity = true;
				}
			}
			else if (type == 81 || type == 150 || type == 121)
			{
				if (life > 0)
				{
					int num6 = (int)(dmg / (double)lifeMax * 80.0);
					while (num6 > 0 && null != Main.dust.NewDust(14, ref aabb, 0.0, 0.0, alpha, color))
					{
						num6--;
					}
					return;
				}
				for (int m = 0; m < 42; m++)
				{
					Dust* ptr3 = Main.dust.NewDust(14, ref aabb, hitDirection, 0.0, alpha, color);
					if (ptr3 == null)
					{
						break;
					}
					ptr3->velocity.X *= 2f;
					ptr3->velocity.Y *= 2f;
				}
				if (Main.netMode == 1)
				{
					return;
				}
				if (type == 121)
				{
					int num7 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, 81);
					if (num7 < 196)
					{
						Main.npc[num7].SetDefaults("Slimer2");
						Main.npc[num7].velocity.X = velocity.X;
						Main.npc[num7].velocity.Y = velocity.Y;
						Gore.NewGore(position, velocity, 94, scale);
						NetMessage.CreateMessage1(23, num7);
						NetMessage.SendMessage();
					}
				}
				else
				{
					if (!(scale >= 1f))
					{
						return;
					}
					string defaults = (type == 81) ? "Slimeling" : "Slimeling2";
					for (int num8 = Main.rand.Next(1, 3); num8 >= 0; num8--)
					{
						int num9 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, 1);
						if (num9 >= 196)
						{
							break;
						}
						Main.npc[num9].SetDefaults(defaults);
						Main.npc[num9].velocity.X = velocity.X * 3f;
						Main.npc[num9].velocity.Y = velocity.Y;
						Main.npc[num9].velocity.X += (float)Main.rand.Next(-10, 10) * 0.1f + (float)(num8 * direction) * 0.3f;
						Main.npc[num9].velocity.Y -= (float)Main.rand.Next(10) * 0.1f + (float)num8;
						Main.npc[num9].ai1 = num8;
						NetMessage.CreateMessage1(23, num9);
						NetMessage.SendMessage();
					}
				}
			}
			else if (type == 120 || type == 154 || type == 137 || type == 138)
			{
				if (life > 0)
				{
					for (int n = 0; (double)n < dmg / (double)lifeMax * 50.0; n++)
					{
						Dust* ptr4 = Main.dust.NewDust(71, ref aabb, 0.0, 0.0, 200);
						if (ptr4 == null)
						{
							break;
						}
						ptr4->velocity.X *= 1.5f;
						ptr4->velocity.Y *= 1.5f;
					}
					return;
				}
				for (int num10 = 0; num10 < 42; num10++)
				{
					Dust* ptr5 = Main.dust.NewDust(71, ref aabb, hitDirection, 0.0, 200);
					if (ptr5 == null)
					{
						break;
					}
					ptr5->velocity.X *= 1.5f;
					ptr5->velocity.Y *= 1.5f;
				}
			}
			else if (type == 122 || type == 153)
			{
				if (life > 0)
				{
					for (int num11 = 0; (double)num11 < dmg / (double)lifeMax * 50.0; num11++)
					{
						Dust* ptr6 = Main.dust.NewDust(72, ref aabb, 0.0, 0.0, 200);
						if (ptr6 == null)
						{
							break;
						}
						ptr6->velocity.X *= 1.5f;
						ptr6->velocity.Y *= 1.5f;
					}
					return;
				}
				for (int num12 = 0; num12 < 42; num12++)
				{
					Dust* ptr7 = Main.dust.NewDust(72, ref aabb, hitDirection, 0.0, 200);
					if (ptr7 == null)
					{
						break;
					}
					ptr7->velocity.X *= 1.5f;
					ptr7->velocity.Y *= 1.5f;
				}
			}
			else if (type == 75)
			{
				if (life > 0)
				{
					for (int num13 = 0; (double)num13 < dmg / (double)lifeMax * 50.0; num13++)
					{
						if (null == Main.dust.NewDust(55, ref aabb, 0.0, 0.0, 200, color))
						{
							break;
						}
					}
					return;
				}
				for (int num14 = 0; num14 < 42; num14++)
				{
					Dust* ptr8 = Main.dust.NewDust(55, ref aabb, hitDirection, 0.0, 200, color);
					if (ptr8 == null)
					{
						break;
					}
					ptr8->velocity.X *= 2f;
					ptr8->velocity.Y *= 2f;
				}
			}
			else if (type == 63 || type == 64 || type == 103)
			{
				Color newColor = new Color(50, 120, 255, 100);
				if (type == 64)
				{
					newColor = new Color(225, 70, 140, 100);
				}
				else if (type == 103)
				{
					newColor = new Color(70, 225, 140, 100);
				}
				if (life > 0)
				{
					for (int num15 = 0; (double)num15 < dmg / (double)lifeMax * 50.0; num15++)
					{
						if (null == Main.dust.NewDust(4, ref aabb, hitDirection, -1.0, 0, newColor))
						{
							break;
						}
					}
					return;
				}
				for (int num16 = 0; num16 < 16; num16++)
				{
					if (null == Main.dust.NewDust(4, ref aabb, 2 * hitDirection, -2.0, 0, newColor))
					{
						break;
					}
				}
			}
			else if (type == 59 || type == 60)
			{
				if (life > 0)
				{
					for (int num17 = 0; (double)num17 < dmg / (double)lifeMax * 80.0; num17++)
					{
						if (null == Main.dust.NewDust(6, ref aabb, hitDirection * 2, -1.0, alpha, default(Color), 1.5))
						{
							break;
						}
					}
					return;
				}
				for (int num18 = 0; num18 < 32; num18++)
				{
					if (null == Main.dust.NewDust(6, ref aabb, hitDirection * 2, -1.0, alpha, default(Color), 1.5))
					{
						break;
					}
				}
			}
			else if (type == 50)
			{
				if (life > 0)
				{
					for (int num19 = 0; (double)num19 < dmg / (double)lifeMax * 300.0; num19++)
					{
						if (null == Main.dust.NewDust(4, ref aabb, hitDirection, -1.0, 175, new Color(0, 80, 255, 100)))
						{
							break;
						}
					}
					return;
				}
				for (int num20 = 0; num20 < 128; num20++)
				{
					if (null == Main.dust.NewDust(4, ref aabb, hitDirection << 1, -2.0, 175, new Color(0, 80, 255, 100)))
					{
						break;
					}
				}
				if (Main.netMode == 1)
				{
					return;
				}
				for (int num21 = Main.rand.Next(3, 7); num21 >= 0; num21--)
				{
					int x = aabb.X + Main.rand.Next(width - 32);
					int y = aabb.Y + Main.rand.Next(height - 32);
					int num22 = NewNPC(x, y, 1);
					if (num22 < 196)
					{
						Main.npc[num22].SetDefaults(1);
						Main.npc[num22].velocity.X = (float)Main.rand.Next(-15, 16) * 0.1f;
						Main.npc[num22].velocity.Y = (float)Main.rand.Next(-30, 1) * 0.1f;
						Main.npc[num22].ai1 = Main.rand.Next(3);
						NetMessage.CreateMessage1(23, num22);
						NetMessage.SendMessage();
					}
				}
			}
			else if (type == 49 || type == 51 || type == 93)
			{
				if (life > 0)
				{
					for (int num23 = 0; (double)num23 < dmg / (double)lifeMax * 30.0; num23++)
					{
						if (null == Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
						{
							break;
						}
					}
					return;
				}
				for (int num24 = 0; num24 < 12; num24++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				if (type == 51)
				{
					Gore.NewGore(position, velocity, 83);
				}
				else if (type == 93)
				{
					Gore.NewGore(position, velocity, 107);
				}
				else
				{
					Gore.NewGore(position, velocity, 82);
				}
			}
			else if (type == 46 || type == 55 || type == 67 || type == 74 || type == 102)
			{
				if (life > 0)
				{
					for (int num25 = 0; (double)num25 < dmg / (double)lifeMax * 20.0; num25++)
					{
						if (null == Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
						{
							break;
						}
					}
					return;
				}
				for (int num26 = 0; num26 < 8; num26++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				if (type == 46)
				{
					Gore.NewGore(position, velocity, 76);
					Gore.NewGore(position, velocity, 77);
				}
				else if (type == 67)
				{
					Gore.NewGore(position, velocity, 95);
					Gore.NewGore(position, velocity, 95);
					Gore.NewGore(position, velocity, 96);
				}
				else if (type == 74)
				{
					Gore.NewGore(position, velocity, 100);
				}
				else if (type == 102)
				{
					Gore.NewGore(position, velocity, 116);
				}
			}
			else if (type == 47 || type == 57 || type == 58)
			{
				if (life > 0)
				{
					for (int num27 = 0; (double)num27 < dmg / (double)lifeMax * 20.0; num27++)
					{
						if (null == Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
						{
							break;
						}
					}
					return;
				}
				for (int num28 = 0; num28 < 8; num28++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				if (type == 57)
				{
					Gore.NewGore(position, velocity, 84);
					return;
				}
				if (type == 58)
				{
					Gore.NewGore(position, velocity, 85);
					return;
				}
				Gore.NewGore(position, velocity, 78);
				Gore.NewGore(position, velocity, 79);
			}
			else if (type == 2)
			{
				if (life > 0)
				{
					int num29 = (int)(dmg / (double)lifeMax * 80.0);
					while (num29 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num29--;
					}
					return;
				}
				for (int num30 = 0; num30 < 42; num30++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				Gore.NewGore(position, velocity, 1);
				Gore.NewGore(new Vector2(position.X + 14f, position.Y), velocity, 2);
			}
			else if (type == 133)
			{
				if (life > 0)
				{
					int num31 = (int)(dmg / (double)lifeMax * 80.0);
					while (num31 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num31--;
					}
					if (life < lifeMax >> 1 && localAI0 == 0)
					{
						localAI0 = 1;
						Gore.NewGore(position, velocity, 1);
					}
					return;
				}
				for (int num32 = 0; num32 < 48; num32++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				Gore.NewGore(position, velocity, 155);
				Gore.NewGore(new Vector2(position.X, position.Y + 14f), velocity, 155);
			}
			else if (type == 69 || type == 147)
			{
				if (life > 0)
				{
					int num33 = (int)(dmg / (double)lifeMax * 80.0);
					while (num33 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num33--;
					}
					return;
				}
				for (int num34 = 0; num34 < 42; num34++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				int num35 = (type == 69) ? 97 : 160;
				Gore.NewGore(position, velocity, num35);
				Gore.NewGore(position, velocity, ++num35);
			}
			else if (type == 61)
			{
				if (life > 0)
				{
					int num36 = (int)(dmg / (double)lifeMax * 80.0);
					while (num36 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num36--;
					}
					return;
				}
				for (int num37 = 0; num37 < 42; num37++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				Gore.NewGore(position, velocity, 86);
				Gore.NewGore(new Vector2(position.X + 14f, position.Y), velocity, 87);
				Gore.NewGore(new Vector2(position.X + 14f, position.Y), velocity, 88);
			}
			else if (type == 65 || type == 148)
			{
				if (life > 0)
				{
					for (int num38 = 0; (double)num38 < dmg / (double)lifeMax * 150.0; num38++)
					{
						if (null == Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
						{
							break;
						}
					}
					return;
				}
				for (int num39 = 0; num39 < 60; num39++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				int num40 = (type == 65) ? 89 : 162;
				Vector2 vector = velocity;
				vector.X *= 0.8f;
				vector.Y *= 0.8f;
				Gore.NewGore(position, vector, num40);
				Gore.NewGore(new Vector2(position.X + 14f, position.Y), vector, ++num40);
				Gore.NewGore(new Vector2(position.X + 14f, position.Y), vector, ++num40);
				Gore.NewGore(new Vector2(position.X + 14f, position.Y), vector, ++num40);
			}
			else if (type == 3 || type == 52 || type == 53 || type == 104 || type == 109 || type == 132)
			{
				if (life > 0)
				{
					int num41 = (int)(dmg / (double)lifeMax * 80.0);
					while (num41 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num41--;
					}
					return;
				}
				for (int num42 = 0; num42 < 42; num42++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5))
					{
						break;
					}
				}
				if (type == 104)
				{
					Gore.NewGore(position, velocity, 117);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 118);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 118);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 119);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 119);
					return;
				}
				if (type == 109)
				{
					Gore.NewGore(position, velocity, 121);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 122);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 122);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 123);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 123);
					Gore.NewGore(new Vector2(position.X, position.Y + 46f), velocity, 120);
					return;
				}
				if (type == 132)
				{
					Gore.NewGore(position, velocity, 154);
				}
				else
				{
					Gore.NewGore(position, velocity, 3);
				}
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 4);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 4);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 5);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 5);
			}
			else if (type == 83 || type == 84 || type == 151)
			{
				if (life > 0)
				{
					for (int num43 = 0; (double)num43 < dmg / (double)lifeMax * 50.0; num43++)
					{
						Dust* ptr9 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 0, default(Color), 1.5);
						if (ptr9 == null)
						{
							break;
						}
						ptr9->noGravity = true;
					}
					return;
				}
				for (int num44 = 0; num44 < 16; num44++)
				{
					Dust* ptr10 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 0, default(Color), 1.5);
					if (ptr10 == null)
					{
						break;
					}
					ptr10->velocity.X *= 2f;
					ptr10->velocity.Y *= 2f;
					ptr10->noGravity = true;
				}
				int num45 = Gore.NewGore(new Vector2(position.X, position.Y + (float)((height >> 1) - 10)), new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-2, 3)), 61, scale);
				Main.gore[num45].velocity *= 0.5f;
				num45 = Gore.NewGore(new Vector2(position.X, position.Y + (float)((height >> 1) - 10)), new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-2, 3)), 61, scale);
				Main.gore[num45].velocity *= 0.5f;
				num45 = Gore.NewGore(new Vector2(position.X, position.Y + (float)((height >> 1) - 10)), new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-2, 3)), 61, scale);
				Main.gore[num45].velocity *= 0.5f;
			}
			else if (type == 4 || type == 126 || type == 125)
			{
				if (life > 0)
				{
					int num46 = (int)(dmg / (double)lifeMax * 80.0);
					while (num46 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num46--;
					}
					return;
				}
				for (int num47 = 0; num47 < 128; num47++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				for (int num48 = 0; num48 < 2; num48++)
				{
					Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 2);
					Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7);
					Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 9);
					if (type == 4)
					{
						Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 10);
						Main.PlaySound(15, aabb.X, aabb.Y, 0);
					}
					else if (type == 125)
					{
						Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 146);
					}
					else if (type == 126)
					{
						Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 145);
					}
				}
				if (type != 125 && type != 126)
				{
					return;
				}
				for (int num49 = 0; num49 < 8; num49++)
				{
					Dust* ptr11 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr11 == null)
					{
						break;
					}
					ptr11->velocity.X *= 1.4f;
					ptr11->velocity.Y *= 1.4f;
				}
				for (int num50 = 0; num50 < 4; num50++)
				{
					Dust* ptr12 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
					if (ptr12 == null)
					{
						break;
					}
					ptr12->noGravity = true;
					ptr12->velocity.X *= 5f;
					ptr12->velocity.Y *= 5f;
					ptr12 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr12 == null)
					{
						break;
					}
					ptr12->velocity.X *= 3f;
					ptr12->velocity.Y *= 3f;
				}
				int num51 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num51].velocity.X *= 0.4f;
				Main.gore[num51].velocity.X += 1f;
				Main.gore[num51].velocity.Y *= 0.4f;
				Main.gore[num51].velocity.Y += 1f;
				num51 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num51].velocity.X *= 0.4f;
				Main.gore[num51].velocity.X -= 1f;
				Main.gore[num51].velocity.Y *= 0.4f;
				Main.gore[num51].velocity.Y += 1f;
				num51 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num51].velocity.X *= 0.4f;
				Main.gore[num51].velocity.X += 1f;
				Main.gore[num51].velocity.Y *= 0.4f;
				Main.gore[num51].velocity.Y -= 1f;
				num51 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num51].velocity.X *= 0.4f;
				Main.gore[num51].velocity.X -= 1f;
				Main.gore[num51].velocity.Y *= 0.4f;
				Main.gore[num51].velocity.Y -= 1f;
			}
			else if (type == 166)
			{
				if (life > 0)
				{
					int num52 = (int)(dmg / (double)lifeMax * 80.0);
					while (num52 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num52--;
					}
					return;
				}
				for (int num53 = 0; num53 < 128; num53++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				for (int num54 = 0; num54 < 2; num54++)
				{
					Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 172);
					Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 173);
					Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 174);
					Gore.NewGore(position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 172);
					Main.PlaySound(15, aabb.X, aabb.Y, 0);
				}
			}
			else if (type == 5)
			{
				if (life > 0)
				{
					for (int num55 = 0; (double)num55 < dmg / (double)lifeMax * 50.0; num55++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num56 = 0; num56 < 16; num56++)
				{
					Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0);
				}
				Gore.NewGore(position, velocity, 6);
				Gore.NewGore(position, velocity, 7);
			}
			else if (type == 167)
			{
				if (life > 0)
				{
					for (int num57 = 0; (double)num57 < dmg / (double)lifeMax * 50.0; num57++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
				}
				else
				{
					for (int num58 = 0; num58 < 16; num58++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0);
					}
				}
			}
			else if (type == 113 || type == 114)
			{
				if (life > 0)
				{
					for (int num59 = 0; num59 < 16; num59++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num60 = 0; num60 < 42; num60++)
				{
					Main.dust.NewDust(5, ref aabb, hitDirection << 1, -1.0);
				}
				Gore.NewGore(position, velocity, 137, scale);
				if (type == 114)
				{
					Gore.NewGore(new Vector2(position.X, position.Y + (float)(height >> 1)), velocity, 139, scale);
					Gore.NewGore(new Vector2(position.X + (float)(width >> 1), position.Y), velocity, 139, scale);
					Gore.NewGore(new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1)), velocity, 137, scale);
				}
				else
				{
					Gore.NewGore(new Vector2(position.X, position.Y + (float)(height >> 1)), velocity, 138, scale);
					Gore.NewGore(new Vector2(position.X + (float)(width >> 1), position.Y), velocity, 138, scale);
					Gore.NewGore(new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1)), velocity, 137, scale);
				}
			}
			else if (type == 115 || type == 116)
			{
				if (life > 0)
				{
					for (int num61 = 0; num61 < 4; num61++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				if (type == 115 && Main.netMode != 1)
				{
					NewNPC(aabb.X + (width >> 1), aabb.Y + height, 116);
					for (int num62 = 0; num62 < 8; num62++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num63 = 0; num63 < 16; num63++)
				{
					Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
				}
				Gore.NewGore(position, velocity, 132, scale);
				Gore.NewGore(position, velocity, 133, scale);
			}
			else if (type >= 117 && type <= 119)
			{
				if (life > 0)
				{
					for (int num64 = 0; num64 < 4; num64++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num65 = 0; num65 < 8; num65++)
				{
					Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
				}
				Gore.NewGore(position, velocity, 134 + type - 117, scale);
			}
			else if (type == 6 || type == 94)
			{
				if (life > 0)
				{
					for (int num66 = (int)(dmg / (double)lifeMax * 80.0); num66 > 0; num66--)
					{
						Main.dust.NewDust(18, ref aabb, hitDirection, -1.0, alpha, color, scale);
					}
					return;
				}
				for (int num67 = 0; num67 < 42; num67++)
				{
					Main.dust.NewDust(18, ref aabb, hitDirection, -2.0, alpha, color, scale);
				}
				if (type == 94)
				{
					int num68 = Gore.NewGore(position, velocity, 108, scale);
					num68 = Gore.NewGore(position, velocity, 108, scale);
					num68 = Gore.NewGore(position, velocity, 109, scale);
					num68 = Gore.NewGore(position, velocity, 110, scale);
				}
				else
				{
					int num68 = Gore.NewGore(position, velocity, 14, scale);
					Main.gore[num68].alpha = alpha;
					num68 = Gore.NewGore(position, velocity, 15, scale);
					Main.gore[num68].alpha = alpha;
				}
			}
			else if (type == 101)
			{
				if (life > 0)
				{
					for (int num69 = (int)(dmg / (double)lifeMax * 80.0); num69 > 0; num69--)
					{
						Main.dust.NewDust(18, ref aabb, hitDirection, -1.0, alpha, color, scale);
					}
					return;
				}
				for (int num70 = 0; num70 < 42; num70++)
				{
					Main.dust.NewDust(18, ref aabb, hitDirection, -2.0, alpha, color, scale);
				}
				Gore.NewGore(position, velocity, 110, scale);
				Gore.NewGore(position, velocity, 114, scale);
				Gore.NewGore(position, velocity, 114, scale);
				Gore.NewGore(position, velocity, 115, scale);
			}
			else if (type == 7 || type == 8 || type == 9)
			{
				if (life > 0)
				{
					for (int num71 = (int)(dmg / (double)lifeMax * 80.0); num71 > 0; num71--)
					{
						Main.dust.NewDust(18, ref aabb, hitDirection, -1.0, alpha, color, scale);
					}
					return;
				}
				for (int num72 = 0; num72 < 42; num72++)
				{
					Main.dust.NewDust(18, ref aabb, hitDirection, -2.0, alpha, color, scale);
				}
				int num73 = Gore.NewGore(position, velocity, type - 7 + 18);
				Main.gore[num73].alpha = alpha;
			}
			else if (type == 98 || type == 99 || type == 100)
			{
				if (life > 0)
				{
					for (int num74 = (int)(dmg / (double)lifeMax * 80.0); num74 > 0; num74--)
					{
						Main.dust.NewDust(18, ref aabb, hitDirection, -1.0, alpha, color, scale);
					}
					return;
				}
				for (int num75 = 0; num75 < 42; num75++)
				{
					Main.dust.NewDust(18, ref aabb, hitDirection, -2.0, alpha, color, scale);
				}
				int num76 = Gore.NewGore(position, velocity, 110);
				Main.gore[num76].alpha = alpha;
			}
			else if (type == 10 || type == 11 || type == 12)
			{
				if (life > 0)
				{
					for (int num77 = 0; (double)num77 < dmg / (double)lifeMax * 50.0; num77++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num78 = 0; num78 < 8; num78++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, type - 7 + 18);
			}
			else if (type == 95 || type == 96 || type == 97)
			{
				if (life > 0)
				{
					for (int num79 = 0; (double)num79 < dmg / (double)lifeMax * 50.0; num79++)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num80 = 0; num80 < 8; num80++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, type - 95 + 111);
			}
			else if (type >= 13 && type <= 15)
			{
				if (life > 0)
				{
					for (int num81 = (int)(dmg / (double)lifeMax * 80.0); num81 > 0; num81--)
					{
						Main.dust.NewDust(18, ref aabb, hitDirection, -1.0, alpha, color, scale);
					}
					return;
				}
				for (int num82 = 0; num82 < 42; num82++)
				{
					Main.dust.NewDust(18, ref aabb, hitDirection, -2.0, alpha, color, scale);
				}
				if (type == 13)
				{
					Gore.NewGore(position, velocity, 24);
					Gore.NewGore(position, velocity, 25);
				}
				else if (type == 14)
				{
					Gore.NewGore(position, velocity, 26);
					Gore.NewGore(position, velocity, 27);
				}
				else
				{
					Gore.NewGore(position, velocity, 28);
					Gore.NewGore(position, velocity, 29);
				}
			}
			else if (type == 17)
			{
				if (life > 0)
				{
					for (int num83 = (int)(dmg / (double)lifeMax * 80.0); num83 > 0; num83--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num84 = 0; num84 < 42; num84++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 30);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 31);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 31);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 32);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 32);
			}
			else if (type == 86)
			{
				if (life > 0)
				{
					for (int num85 = (int)(dmg / (double)lifeMax * 80.0); num85 > 0; num85--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num86 = 0; num86 < 42; num86++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 101);
				Gore.NewGore(position, velocity, 102);
				Gore.NewGore(position, velocity, 103);
				Gore.NewGore(position, velocity, 103);
				Gore.NewGore(position, velocity, 104);
				Gore.NewGore(position, velocity, 104);
				Gore.NewGore(position, velocity, 105);
			}
			else if (type >= 105 && type <= 108)
			{
				if (life > 0)
				{
					for (int num87 = (int)(dmg / (double)lifeMax * 80.0); num87 > 0; num87--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num88 = 0; num88 < 42; num88++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				if (type == 105 || type == 107)
				{
					Gore.NewGore(position, velocity, 124);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 125);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 125);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 126);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 126);
				}
				else
				{
					Gore.NewGore(position, velocity, 127);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 128);
					Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 128);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 129);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 129);
				}
			}
			else if (type == 123 || type == 124)
			{
				if (life > 0)
				{
					for (int num89 = (int)(dmg / (double)lifeMax * 80.0); num89 > 0; num89--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num90 = 0; num90 < 42; num90++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 151);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 152);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 152);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 153);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 153);
			}
			else if (type == 22)
			{
				if (life > 0)
				{
					for (int num91 = (int)(dmg / (double)lifeMax * 80.0); num91 > 0; num91--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num92 = 0; num92 < 42; num92++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 73);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 74);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 74);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 75);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 75);
			}
			else if (type == 142)
			{
				if (life > 0)
				{
					for (int num93 = (int)(dmg / (double)lifeMax * 80.0); num93 > 0; num93--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num94 = 0; num94 < 42; num94++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 157);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 158);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 158);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 159);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 159);
			}
			else if (type == 37 || type == 54)
			{
				if (life > 0)
				{
					for (int num95 = (int)(dmg / (double)lifeMax * 80.0); num95 > 0; num95--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num96 = 0; num96 < 42; num96++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 58);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 59);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 59);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 60);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 60);
			}
			else if (type == 18)
			{
				if (life > 0)
				{
					for (int num97 = (int)(dmg / (double)lifeMax * 80.0); num97 > 0; num97--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num98 = 0; num98 < 42; num98++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 33);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 34);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 34);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 35);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 35);
			}
			else if (type == 19)
			{
				if (life > 0)
				{
					for (int num99 = (int)(dmg / (double)lifeMax * 80.0); num99 > 0; num99--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num100 = 0; num100 < 42; num100++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 36);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 37);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 37);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 38);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 38);
			}
			else if (type == 38)
			{
				if (life > 0)
				{
					for (int num101 = (int)(dmg / (double)lifeMax * 80.0); num101 > 0; num101--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num102 = 0; num102 < 42; num102++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 64);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 65);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 65);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 66);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 66);
			}
			else if (type == 20)
			{
				if (life > 0)
				{
					for (int num103 = (int)(dmg / (double)lifeMax * 80.0); num103 > 0; num103--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num104 = 0; num104 < 42; num104++)
				{
					Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, 39);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 40);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 40);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 41);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 41);
			}
			else if (type == 21 || type == 31 || type == 32 || type == 44 || type == 45 || type == 77 || type == 110 || type == 149)
			{
				if (life > 0)
				{
					for (int num105 = 0; (double)num105 < dmg / (double)lifeMax * 50.0; num105++)
					{
						Main.dust.NewDust(26, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num106 = 0; num106 < 16; num106++)
				{
					Main.dust.NewDust(26, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				int num107 = (type == 149) ? 166 : 42;
				Gore.NewGore(position, velocity, num107, scale);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, ++num107, scale);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, num107, scale);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, ++num107, scale);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, num107, scale);
				if (type == 77)
				{
					Gore.NewGore(position, velocity, 106, scale);
				}
				else if (type == 110)
				{
					Gore.NewGore(position, velocity, 130, scale);
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 131, scale);
				}
			}
			else if (type == 85)
			{
				int num108 = 7;
				if (ai3 == 2f)
				{
					num108 = 10;
				}
				else if (ai3 == 3f)
				{
					num108 = 37;
				}
				if (life > 0)
				{
					for (int num109 = 0; (double)num109 < dmg / (double)lifeMax * 50.0; num109++)
					{
						if (null == Main.dust.NewDust(num108, ref aabb))
						{
							break;
						}
					}
					return;
				}
				for (int num110 = 0; num110 < 16; num110++)
				{
					if (null == Main.dust.NewDust(num108, ref aabb))
					{
						break;
					}
				}
				int num111 = Gore.NewGore(new Vector2(position.X, position.Y - 10f), new Vector2(hitDirection, 0f), 61, scale);
				Main.gore[num111].velocity *= 0.3f;
				num111 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(height >> 1) - 10f), new Vector2(hitDirection, 0f), 62, scale);
				Main.gore[num111].velocity *= 0.3f;
				num111 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(int)height - 10f), new Vector2(hitDirection, 0f), 63, scale);
				Main.gore[num111].velocity *= 0.3f;
			}
			else if ((type >= 87 && type <= 92) || (type >= 159 && type <= 164))
			{
				if (life > 0)
				{
					for (int num112 = 0; (double)num112 < dmg / (double)lifeMax * 50.0; num112++)
					{
						Dust* ptr13 = Main.dust.NewDust(16, ref aabb, 0.0, 0.0, 0, default(Color), 1.5);
						if (ptr13 == null)
						{
							break;
						}
						ptr13->velocity.X *= 1.5f;
						ptr13->velocity.Y *= 1.5f;
						ptr13->noGravity = true;
					}
					return;
				}
				for (int num113 = 0; num113 < 8; num113++)
				{
					Dust* ptr14 = Main.dust.NewDust(16, ref aabb, 0.0, 0.0, 0, default(Color), 1.5);
					if (ptr14 == null)
					{
						break;
					}
					ptr14->velocity.X *= 2f;
					ptr14->velocity.Y *= 2f;
					ptr14->noGravity = true;
				}
				for (int num114 = Main.rand.Next(1, 4); num114 > 0; num114--)
				{
					int num115 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(height >> 1) - 10f), new Vector2(hitDirection, 0f), Main.rand.Next(11, 14), scale);
					Main.gore[num115].velocity *= 0.8f;
				}
			}
			else if (type == 78 || type == 79 || type == 80 || type == 152 || type == 155)
			{
				if (life > 0)
				{
					for (int num116 = 0; (double)num116 < dmg / (double)lifeMax * 50.0; num116++)
					{
						Dust* ptr15 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 0, default(Color), 1.5);
						if (ptr15 == null)
						{
							break;
						}
						ptr15->velocity.X *= 2f;
						ptr15->velocity.Y *= 2f;
						ptr15->noGravity = true;
					}
					return;
				}
				for (int num117 = 0; num117 < 16; num117++)
				{
					Dust* ptr16 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 0, default(Color), 1.5);
					if (ptr16 == null)
					{
						break;
					}
					ptr16->velocity.X *= 2f;
					ptr16->velocity.Y *= 2f;
					ptr16->noGravity = true;
				}
				int num118 = Gore.NewGore(new Vector2(position.X, position.Y - 10f), new Vector2(hitDirection, 0f), 61, scale);
				Main.gore[num118].velocity *= 0.3f;
				num118 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(height >> 1) - 10f), new Vector2(hitDirection, 0f), 62, scale);
				Main.gore[num118].velocity *= 0.3f;
				num118 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(int)height - 10f), new Vector2(hitDirection, 0f), 63, scale);
				Main.gore[num118].velocity *= 0.3f;
			}
			else if (type == 82)
			{
				if (life > 0)
				{
					for (int num119 = 0; (double)num119 < dmg / (double)lifeMax * 50.0; num119++)
					{
						Dust* ptr17 = Main.dust.NewDust(54, ref aabb, 0.0, 0.0, 50, default(Color), 1.5);
						if (ptr17 == null)
						{
							break;
						}
						ptr17->velocity.X *= 2f;
						ptr17->velocity.Y *= 2f;
						ptr17->noGravity = true;
					}
					return;
				}
				for (int num120 = 0; num120 < 16; num120++)
				{
					Dust* ptr18 = Main.dust.NewDust(54, ref aabb, 0.0, 0.0, 50, default(Color), 1.5);
					if (ptr18 == null)
					{
						break;
					}
					ptr18->velocity.X *= 2f;
					ptr18->velocity.Y *= 2f;
					ptr18->noGravity = true;
				}
				int num121 = Gore.NewGore(new Vector2(position.X, position.Y - 10f), new Vector2(hitDirection, 0f), 99, scale);
				Main.gore[num121].velocity *= 0.3f;
				num121 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(height >> 1) - 15f), new Vector2(hitDirection, 0f), 99, scale);
				Main.gore[num121].velocity *= 0.3f;
				num121 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(int)height - 20f), new Vector2(hitDirection, 0f), 99, scale);
				Main.gore[num121].velocity *= 0.3f;
			}
			else if (type == 140)
			{
				if (life > 0)
				{
					return;
				}
				for (int num122 = 0; num122 < 16; num122++)
				{
					Dust* ptr19 = Main.dust.NewDust(54, ref aabb, 0.0, 0.0, 50, default(Color), 1.5);
					if (ptr19 == null)
					{
						break;
					}
					ptr19->velocity.X *= 2f;
					ptr19->velocity.Y *= 2f;
					ptr19->noGravity = true;
				}
				int num123 = Gore.NewGore(new Vector2(position.X, position.Y - 10f), new Vector2(hitDirection, 0f), 99, scale);
				Main.gore[num123].velocity *= 0.3f;
				num123 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(height >> 1) - 15f), new Vector2(hitDirection, 0f), 99, scale);
				Main.gore[num123].velocity *= 0.3f;
				num123 = Gore.NewGore(new Vector2(position.X, position.Y + (float)(int)height - 20f), new Vector2(hitDirection, 0f), 99, scale);
				Main.gore[num123].velocity *= 0.3f;
			}
			else if (type == 39 || type == 40 || type == 41)
			{
				if (life > 0)
				{
					for (int num124 = 0; (double)num124 < dmg / (double)lifeMax * 50.0; num124++)
					{
						Main.dust.NewDust(26, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num125 = 0; num125 < 16; num125++)
				{
					Main.dust.NewDust(26, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				Gore.NewGore(position, velocity, type - 39 + 67);
			}
			else if (type == 34 || type == 158)
			{
				if (life > 0)
				{
					for (int num126 = 0; (double)num126 < dmg / (double)lifeMax * 30.0; num126++)
					{
						Dust* ptr20 = Main.dust.NewDust(15, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 100, default(Color), 1.8);
						if (ptr20 == null)
						{
							break;
						}
						ptr20->noLight = true;
						ptr20->noGravity = true;
						ptr20->velocity.X *= 1.3f;
						ptr20->velocity.Y *= 1.3f;
						ptr20 = Main.dust.NewDust(26, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 0, default(Color), 0.9);
						if (ptr20 == null)
						{
							break;
						}
						ptr20->noLight = true;
						ptr20->velocity.X *= 1.3f;
						ptr20->velocity.Y *= 1.3f;
					}
					return;
				}
				for (int num127 = 0; num127 < 12; num127++)
				{
					Dust* ptr21 = Main.dust.NewDust(15, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 100, default(Color), 1.8);
					if (ptr21 == null)
					{
						break;
					}
					ptr21->noLight = true;
					ptr21->noGravity = true;
					ptr21->velocity.X *= 1.3f;
					ptr21->velocity.Y *= 1.3f;
					ptr21 = Main.dust.NewDust(26, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 0, default(Color), 0.9);
					if (ptr21 == null)
					{
						break;
					}
					ptr21->noLight = true;
					ptr21->velocity.X *= 1.3f;
					ptr21->velocity.Y *= 1.3f;
				}
			}
			else if (type == 35 || type == 36)
			{
				if (life > 0)
				{
					for (int num128 = (int)(dmg / (double)lifeMax * 80.0); num128 > 0; num128--)
					{
						Main.dust.NewDust(26, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num129 = 0; num129 < 128; num129++)
				{
					Main.dust.NewDust(26, ref aabb, 2.5 * (double)hitDirection, -2.5);
				}
				if (type == 35)
				{
					Gore.NewGore(position, velocity, 54);
					Gore.NewGore(position, velocity, 55);
					return;
				}
				Gore.NewGore(position, velocity, 56);
				Gore.NewGore(position, velocity, 57);
				Gore.NewGore(position, velocity, 57);
				Gore.NewGore(position, velocity, 57);
			}
			else if (type == 139)
			{
				if (life > 0)
				{
					return;
				}
				for (int num130 = 0; num130 < 8; num130++)
				{
					Dust* ptr22 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr22 == null)
					{
						break;
					}
					ptr22->velocity.X *= 1.4f;
					ptr22->velocity.Y *= 1.4f;
				}
				for (int num131 = 0; num131 < 4; num131++)
				{
					Dust* ptr23 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
					if (ptr23 == null)
					{
						break;
					}
					ptr23->noGravity = true;
					ptr23->velocity.X *= 5f;
					ptr23->velocity.Y *= 5f;
					ptr23 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr23 == null)
					{
						break;
					}
					ptr23->velocity.X *= 3f;
					ptr23->velocity.Y *= 3f;
				}
				int num132 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num132].velocity *= 0.4f;
				Main.gore[num132].velocity.X += 1f;
				Main.gore[num132].velocity.Y += 1f;
				num132 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num132].velocity *= 0.4f;
				Main.gore[num132].velocity.X -= 1f;
				Main.gore[num132].velocity.Y += 1f;
				num132 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num132].velocity *= 0.4f;
				Main.gore[num132].velocity.X += 1f;
				Main.gore[num132].velocity.Y -= 1f;
				num132 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num132].velocity *= 0.4f;
				Main.gore[num132].velocity.X -= 1f;
				Main.gore[num132].velocity.Y -= 1f;
			}
			else if (type >= 134 && type <= 136)
			{
				if (type == 135 && life > 0 && Main.netMode != 1 && ai2 == 0f && Main.rand.Next(25) == 0)
				{
					ai2 = 1f;
					int num133 = NewNPC(aabb.X + (width >> 1), aabb.Y + height, 139);
					if (Main.netMode == 2 && num133 < 196)
					{
						NetMessage.CreateMessage1(23, num133);
						NetMessage.SendMessage();
					}
					netUpdate = true;
				}
				if (life > 0)
				{
					return;
				}
				Gore.NewGore(position, velocity, 156);
				if (Main.rand.Next(2) != 0)
				{
					return;
				}
				for (int num134 = 0; num134 < 8; num134++)
				{
					Dust* ptr24 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr24 == null)
					{
						break;
					}
					ptr24->velocity.X *= 1.4f;
					ptr24->velocity.Y *= 1.4f;
				}
				for (int num135 = 0; num135 < 4; num135++)
				{
					Dust* ptr25 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
					if (ptr25 == null)
					{
						break;
					}
					ptr25->noGravity = true;
					ptr25->velocity.X *= 5f;
					ptr25->velocity.Y *= 5f;
					ptr25 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr25 == null)
					{
						break;
					}
					ptr25->velocity.X *= 3f;
					ptr25->velocity.Y *= 3f;
				}
				int num136 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num136].velocity.X *= 0.4f;
				Main.gore[num136].velocity.X += 1f;
				Main.gore[num136].velocity.Y *= 0.4f;
				Main.gore[num136].velocity.Y += 1f;
				num136 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num136].velocity.X *= 0.4f;
				Main.gore[num136].velocity.X -= 1f;
				Main.gore[num136].velocity.Y *= 0.4f;
				Main.gore[num136].velocity.Y += 1f;
				num136 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num136].velocity.X *= 0.4f;
				Main.gore[num136].velocity.X += 1f;
				Main.gore[num136].velocity.Y *= 0.4f;
				Main.gore[num136].velocity.Y -= 1f;
				num136 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num136].velocity.X *= 0.4f;
				Main.gore[num136].velocity.X -= 1f;
				Main.gore[num136].velocity.Y *= 0.4f;
				Main.gore[num136].velocity.Y -= 1f;
			}
			else if (type == 127)
			{
				if (life > 0)
				{
					return;
				}
				Gore.NewGore(position, velocity, 149);
				Gore.NewGore(position, velocity, 150);
				for (int num137 = 0; num137 < 8; num137++)
				{
					Dust* ptr26 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr26 == null)
					{
						break;
					}
					ptr26->velocity.X *= 1.4f;
					ptr26->velocity.Y *= 1.4f;
				}
				for (int num138 = 0; num138 < 4; num138++)
				{
					Dust* ptr27 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
					if (ptr27 == null)
					{
						break;
					}
					ptr27->noGravity = true;
					ptr27->velocity.X *= 5f;
					ptr27->velocity.Y *= 5f;
					ptr27 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr27 == null)
					{
						break;
					}
					ptr27->velocity.X *= 3f;
					ptr27->velocity.Y *= 3f;
				}
				int num139 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num139].velocity.X *= 0.4f;
				Main.gore[num139].velocity.X += 1f;
				Main.gore[num139].velocity.Y *= 0.4f;
				Main.gore[num139].velocity.Y += 1f;
				num139 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num139].velocity.X *= 0.4f;
				Main.gore[num139].velocity.X -= 1f;
				Main.gore[num139].velocity.Y *= 0.4f;
				Main.gore[num139].velocity.Y += 1f;
				num139 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num139].velocity.X *= 0.4f;
				Main.gore[num139].velocity.X += 1f;
				Main.gore[num139].velocity.Y *= 0.4f;
				Main.gore[num139].velocity.Y -= 1f;
				num139 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num139].velocity.X *= 0.4f;
				Main.gore[num139].velocity.X -= 1f;
				Main.gore[num139].velocity.Y *= 0.4f;
				Main.gore[num139].velocity.Y -= 1f;
			}
			else if (type >= 128 && type <= 131)
			{
				if (life > 0)
				{
					return;
				}
				Gore.NewGore(position, velocity, 147);
				Gore.NewGore(position, velocity, 148);
				for (int num140 = 0; num140 < 8; num140++)
				{
					Dust* ptr28 = Main.dust.NewDust(31, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr28 == null)
					{
						break;
					}
					ptr28->velocity.X *= 1.4f;
					ptr28->velocity.Y *= 1.4f;
				}
				for (int num141 = 0; num141 < 4; num141++)
				{
					Dust* ptr29 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 2.5);
					if (ptr29 == null)
					{
						break;
					}
					ptr29->noGravity = true;
					ptr29->velocity.X *= 5f;
					ptr29->velocity.Y *= 5f;
					ptr29 = Main.dust.NewDust(6, ref aabb, 0.0, 0.0, 100, default(Color), 1.5);
					if (ptr29 == null)
					{
						break;
					}
					ptr29->velocity.X *= 3f;
					ptr29->velocity.Y *= 3f;
				}
				int num142 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num142].velocity.X *= 0.4f;
				Main.gore[num142].velocity.X += 1f;
				Main.gore[num142].velocity.Y *= 0.4f;
				Main.gore[num142].velocity.Y += 1f;
				num142 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num142].velocity.X *= 0.4f;
				Main.gore[num142].velocity.X -= 1f;
				Main.gore[num142].velocity.Y *= 0.4f;
				Main.gore[num142].velocity.Y += 1f;
				num142 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num142].velocity.X *= 0.4f;
				Main.gore[num142].velocity.X += 1f;
				Main.gore[num142].velocity.Y *= 0.4f;
				Main.gore[num142].velocity.Y -= 1f;
				num142 = Gore.NewGore(position, default(Vector2), Main.rand.Next(61, 64));
				Main.gore[num142].velocity.X *= 0.4f;
				Main.gore[num142].velocity.X -= 1f;
				Main.gore[num142].velocity.Y *= 0.4f;
				Main.gore[num142].velocity.Y -= 1f;
			}
			else if (type == 23)
			{
				if (life > 0)
				{
					for (int num143 = (int)(dmg / (double)lifeMax * 80.0); num143 > 0; num143--)
					{
						int num144 = (Main.rand.Next(2) == 0) ? 6 : 25;
						Main.dust.NewDust(num144, ref aabb, hitDirection, -1.0);
						Dust* ptr30 = Main.dust.NewDust(6, ref aabb, (double)velocity.X * 0.2, (double)velocity.Y * 0.2, 100, default(Color), 2.0);
						if (ptr30 == null)
						{
							break;
						}
						ptr30->noGravity = true;
					}
					return;
				}
				for (int num145 = 0; num145 < 42; num145++)
				{
					int num146 = (Main.rand.Next(2) == 0) ? 6 : 25;
					if (null == Main.dust.NewDust(num146, ref aabb, hitDirection << 1, -2.0))
					{
						break;
					}
				}
				for (int num147 = 0; num147 < 42; num147++)
				{
					Dust* ptr31 = Main.dust.NewDust(6, ref aabb, (double)velocity.X * 0.2, (double)velocity.Y * 0.2, 100, default(Color), 2.5);
					if (ptr31 == null)
					{
						break;
					}
					ptr31->velocity.X *= 6f;
					ptr31->velocity.Y *= 6f;
					ptr31->noGravity = true;
				}
			}
			else if (type == 24)
			{
				if (life > 0)
				{
					for (int num148 = (int)(dmg / (double)lifeMax * 80.0); num148 > 0; num148--)
					{
						Dust* ptr32 = Main.dust.NewDust(6, ref aabb, velocity.X, velocity.Y, 100, default(Color), 2.5);
						if (ptr32 == null)
						{
							break;
						}
						ptr32->noGravity = true;
					}
					return;
				}
				for (int num149 = 0; num149 < 42; num149++)
				{
					Dust* ptr33 = Main.dust.NewDust(6, ref aabb, velocity.X, velocity.Y, 100, default(Color), 2.5);
					if (ptr33 == null)
					{
						break;
					}
					ptr33->noGravity = true;
					ptr33->velocity.X *= 2f;
					ptr33->velocity.Y *= 2f;
				}
				Gore.NewGore(position, velocity, 45);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 46);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 46);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 47);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 47);
			}
			else if (type == 25)
			{
				Main.PlaySound(2, aabb.X, aabb.Y, 10);
				for (int num150 = 0; num150 < 16; num150++)
				{
					Dust* ptr34 = Main.dust.NewDust(6, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 100, default(Color), 2.0);
					if (ptr34 == null)
					{
						break;
					}
					ptr34->noGravity = true;
					ptr34->velocity *= 2f;
					ptr34 = Main.dust.NewDust(6, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 100);
					if (ptr34 == null)
					{
						break;
					}
					ptr34->velocity.X *= 2f;
					ptr34->velocity.Y *= 2f;
				}
			}
			else if (type == 33)
			{
				Main.PlaySound(2, aabb.X, aabb.Y, 10);
				for (int num151 = 0; num151 < 16; num151++)
				{
					Dust* ptr35 = Main.dust.NewDust(29, ref aabb, velocity.X * -0.2f, (double)velocity.Y * -0.2, 100, default(Color), 2.0);
					if (ptr35 == null)
					{
						break;
					}
					ptr35->noGravity = true;
					ptr35->velocity.X *= 2f;
					ptr35->velocity.Y *= 2f;
					ptr35 = Main.dust.NewDust(29, ref aabb, velocity.X * -0.2f, (double)velocity.Y * -0.2, 100);
					if (ptr35 == null)
					{
						break;
					}
					ptr35->velocity.X *= 2f;
					ptr35->velocity.Y *= 2f;
				}
			}
			else if ((type >= 26 && type <= 29) || type == 73 || type == 111)
			{
				if (life > 0)
				{
					int num152 = (int)(dmg / (double)lifeMax * 80.0);
					while (num152 > 0 && null != Main.dust.NewDust(5, ref aabb, hitDirection, -1.0))
					{
						num152--;
					}
					return;
				}
				for (int num153 = 0; num153 < 42; num153++)
				{
					if (null == Main.dust.NewDust(5, ref aabb, 2.5 * (double)hitDirection, -2.5))
					{
						break;
					}
				}
				Gore.NewGore(position, velocity, 48, scale);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 49, scale);
				Gore.NewGore(new Vector2(position.X, position.Y + 20f), velocity, 49, scale);
				if (type == 111)
				{
					Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 131, scale);
				}
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 50, scale);
				Gore.NewGore(new Vector2(position.X, position.Y + 34f), velocity, 50, scale);
			}
			else if (type == 30)
			{
				Main.PlaySound(2, (int)position.X, (int)position.Y, 10);
				for (int num154 = 0; num154 < 15; num154++)
				{
					Dust* ptr36 = Main.dust.NewDust(27, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 100, default(Color), 2.0);
					if (ptr36 == null)
					{
						break;
					}
					ptr36->noGravity = true;
					ptr36->velocity.X *= 2f;
					ptr36->velocity.Y *= 2f;
					ptr36 = Main.dust.NewDust(27, ref aabb, (double)velocity.X * -0.2, (double)velocity.Y * -0.2, 100);
					if (ptr36 == null)
					{
						break;
					}
					ptr36->velocity.X *= 2f;
					ptr36->velocity.Y *= 2f;
				}
			}
			else if (type == 42 || type == 157)
			{
				if (life > 0)
				{
					for (int num155 = (int)(dmg / (double)lifeMax * 80.0); num155 > 0; num155--)
					{
						Main.dust.NewDust(18, ref aabb, hitDirection, -1.0, alpha, color, scale);
					}
					return;
				}
				for (int num156 = 0; num156 < 42; num156++)
				{
					Main.dust.NewDust(18, ref aabb, hitDirection, -2.0, alpha, color, scale);
				}
				int num157 = (type == 42) ? 70 : 169;
				Gore.NewGore(position, velocity, num157, scale);
				Gore.NewGore(position, velocity, ++num157, scale);
			}
			else if (type == 43 || type == 56 || type == 156)
			{
				if (life > 0)
				{
					for (int num158 = (int)(dmg / (double)lifeMax * 80.0); num158 > 0; num158--)
					{
						Main.dust.NewDust(40, ref aabb, hitDirection, -1.0, alpha, color, 1.2000000476837158);
					}
					return;
				}
				for (int num159 = 0; num159 < 42; num159++)
				{
					Main.dust.NewDust(40, ref aabb, hitDirection, -2.0, alpha, color, 1.2000000476837158);
				}
				Gore.NewGore(position, velocity, 72);
				Gore.NewGore(position, velocity, 72);
			}
			else if (type == 48)
			{
				if (life > 0)
				{
					for (int num160 = (int)(dmg / (double)lifeMax * 80.0); num160 > 0; num160--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num161 = 0; num161 < 42; num161++)
				{
					Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0);
				}
				Gore.NewGore(position, velocity, 80);
				Gore.NewGore(position, velocity, 81);
			}
			else
			{
				if (type != 62 && type != 165 && type != 66)
				{
					return;
				}
				if (life > 0)
				{
					for (int num162 = (int)(dmg / (double)lifeMax * 80.0); num162 > 0; num162--)
					{
						Main.dust.NewDust(5, ref aabb, hitDirection, -1.0);
					}
					return;
				}
				for (int num163 = 0; num163 < 42; num163++)
				{
					Main.dust.NewDust(5, ref aabb, hitDirection << 1, -2.0);
				}
				if (type == 165)
				{
					Gore.NewGore(position, velocity, 171);
					Gore.NewGore(position, velocity, 0);
					Gore.NewGore(position, velocity, 0);
				}
				else
				{
					Gore.NewGore(position, velocity, 93);
					Gore.NewGore(position, velocity, 94);
					Gore.NewGore(position, velocity, 94);
				}
			}
		}

		public static bool AnyNPCs(int Type)
		{
			for (int num = 195; num >= 0; num--)
			{
				if (Main.npc[num].type == Type && Main.npc[num].active != 0)
				{
					return true;
				}
			}
			return false;
		}

		public static bool AnyNPCs(int Type1, int Type2)
		{
			for (int num = 195; num >= 0; num--)
			{
				if (Main.npc[num].active != 0 && (Main.npc[num].type == Type1 || Main.npc[num].type == Type2))
				{
					return true;
				}
			}
			return false;
		}

		public static void SpawnSkeletron()
		{
			int num = -1;
			for (int i = 0; i < 196; i++)
			{
				if (Main.npc[i].active != 0)
				{
					if (Main.npc[i].type == 35)
					{
						return;
					}
					if (Main.npc[i].type == 37)
					{
						num = i;
						break;
					}
				}
			}
			if (num >= 0)
			{
				Main.npc[num].ai3 = 1f;
				int num2 = NewNPC(Main.npc[num].aabb.X + (Main.npc[num].width >> 1), Main.npc[num].aabb.Y + (Main.npc[num].height >> 1), 35);
				Main.npc[num2].netUpdate = true;
				NetMessage.CreateMessage1(23, num);
				NetMessage.SendMessage();
				NetMessage.SendText("Skeletron", 16, 175, 75, 255, -1);
			}
		}

		public static bool NearSpikeBall(int x, int y)
		{
			Rectangle rectangle = new Rectangle(x * 16 - 300, y * 16 - 300, 600, 600);
			for (int i = 0; i < 196; i++)
			{
				if (Main.npc[i].aiStyle == 20 && Main.npc[i].active != 0)
				{
					Rectangle rectangle2 = new Rectangle((int)Main.npc[i].ai1, (int)Main.npc[i].ai2, 20, 20);
					if (rectangle.Intersects(rectangle2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void AddBuff(int type, int time, bool quiet = false)
		{
			if (buffImmune[type])
			{
				return;
			}
			if (!quiet)
			{
				if (Main.netMode == 1)
				{
					NetMessage.CreateMessage3(53, whoAmI, type, time);
				}
				else
				{
					NetMessage.CreateMessage1(54, whoAmI);
				}
				NetMessage.SendMessage();
			}
			for (int i = 0; i < 5; i++)
			{
				if (buff[i].Type == type)
				{
					if (buff[i].Time < time)
					{
						buff[i].Time = (ushort)time;
					}
					return;
				}
			}
			int num = -1;
			do
			{
				int num2 = -1;
				for (int j = 0; j < 5; j++)
				{
					if (!buff[j].IsDebuff())
					{
						num2 = j;
						break;
					}
				}
				if (num2 == -1)
				{
					return;
				}
				for (int k = num2; k < 5; k++)
				{
					if (buff[k].Type == 0)
					{
						num = k;
						break;
					}
				}
				if (num == -1)
				{
					DelBuff(num2);
				}
			}
			while (num == -1);
			buff[num].Type = (ushort)type;
			buff[num].Time = (ushort)time;
		}

		public void DelBuff(int b)
		{
			buff[b].Time = 0;
			buff[b].Type = 0;
			for (int i = 0; i < 4; i++)
			{
				if (buff[i].Time == 0 || buff[i].Type == 0)
				{
					for (int j = i + 1; j < 5; j++)
					{
						buff[j - 1] = buff[j];
						buff[j].Time = 0;
						buff[j].Type = 0;
					}
				}
			}
			if (Main.netMode == 2)
			{
				NetMessage.CreateMessage1(54, whoAmI);
				NetMessage.SendMessage();
			}
		}

		private unsafe void FireEffect(int particleType)
		{
			if (Main.rand.Next(4) < 2)
			{
				Dust* ptr = Main.dust.NewDust((int)position.X - 2, (int)position.Y - 2, width + 4, height + 4, particleType, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default(Color), 3.5);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 1.8f;
					ptr->velocity.Y *= 1.8f;
					ptr->velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						ptr->noGravity = false;
						ptr->scale *= 0.5f;
					}
				}
			}
			Lighting.addLight((int)position.X >> 4, ((int)position.Y >> 4) + 1, new Vector3(1f, 0.3f, 0.1f));
		}

		public unsafe void UpdateNPC(int i)
		{
			whoAmI = (short)i;
			if (aabb.X <= 0 || aabb.X + width >= Main.rightWorld || aabb.Y <= 0 || aabb.Y + height >= Main.bottomWorld)
			{
				active = 0;
				return;
			}
			int num = 0;
			bool flag = false;
			poisoned = false;
			confused = false;
			for (int j = 0; j < 5; j++)
			{
				if (buff[j].Type <= 0 || buff[j].Time <= 0)
				{
					continue;
				}
				switch (buff[j].Type)
				{
				case 31:
					confused = true;
					break;
				case 20:
					poisoned = true;
					if (num > -4)
					{
						num = -4;
					}
					if (Main.rand.Next(30) == 0)
					{
						Dust* ptr2 = Main.dust.NewDust(46, ref aabb, 0.0, 0.0, 120, default(Color), 0.20000000298023224);
						if (ptr2 != null)
						{
							ptr2->noGravity = true;
							ptr2->fadeIn = 1.9f;
						}
					}
					break;
				case 24:
					flag = true;
					if (num > -8)
					{
						num = -8;
					}
					FireEffect(6);
					break;
				case 39:
					if (num > -12)
					{
						num = -12;
					}
					FireEffect(75);
					break;
				case 30:
					if (num > -16)
					{
						num = -16;
					}
					if (Main.rand.Next(30) == 0)
					{
						Dust* ptr = Main.dust.NewDust(5, ref aabb);
						if (ptr != null)
						{
							ptr->velocity.Y += 0.5f;
							ptr->velocity *= 0.25f;
						}
					}
					break;
				}
			}
			if (Main.netMode != 1)
			{
				for (int k = 0; k < 5; k++)
				{
					if (buff[k].Type > 0 && buff[k].Time == 0)
					{
						DelBuff(k);
					}
				}
			}
			if (!dontTakeDamage)
			{
				lifeRegenCount += num;
				while (lifeRegenCount <= -120)
				{
					lifeRegenCount += 120;
					int num2 = whoAmI;
					if (realLife >= 0)
					{
						num2 = realLife;
					}
					if (--Main.npc[num2].life <= 0)
					{
						Main.npc[num2].life = 1;
						if (Main.netMode != 1)
						{
							Main.npc[num2].StrikeNPC(9999, 0f, 0);
							NetMessage.SendNpcHurt(num2, 9999, 0.0, 0);
						}
					}
				}
			}
			if (Main.netMode != 1 && Main.gameTime.bloodMoon)
			{
				if (type == 46)
				{
					Transform(47);
				}
				else if (type == 55)
				{
					Transform(57);
				}
			}
			float num3 = 10f;
			float num4 = 0.3f;
			float num5 = (float)Main.maxTilesX * 0.000238095236f;
			num5 *= num5;
			float num6 = (position.Y * 0.0625f - (60f + 10f * num5)) / (float)(Main.worldSurface / 6);
			if ((double)num6 < 0.25)
			{
				num6 = 0.25f;
			}
			else if (num6 > 1f)
			{
				num6 = 1f;
			}
			num4 *= num6;
			if (wet)
			{
				num4 = 0.2f;
				num3 = 7f;
			}
			if (soundDelay > 0)
			{
				soundDelay--;
			}
			if (life <= 0)
			{
				active = 0;
				return;
			}
			oldTarget = target;
			oldDirection = direction;
			oldDirectionY = directionY;
			try
			{
				switch (aiStyle)
				{
				case 0:
					BoundAI();
					break;
				case 1:
					SlimeAI();
					break;
				case 2:
					FloatingEyeballAI();
					break;
				case 3:
					WalkAI();
					break;
				case 4:
					EyeOfCthulhuAI();
					break;
				case 5:
					AggressiveFlyerAI();
					break;
				case 6:
					WormAI();
					break;
				case 7:
					TownsfolkAI();
					break;
				case 8:
					SorcererAI();
					break;
				case 9:
					SphereAI();
					break;
				case 10:
					SkullHeadAI();
					break;
				case 11:
					SkeletronAI();
					break;
				case 12:
					SkeletronHandAI();
					break;
				case 13:
					PlantAI();
					break;
				case 14:
					FlyerAI();
					break;
				case 15:
					KingSlimeAI();
					break;
				case 16:
					FishAI();
					break;
				case 17:
					VultureAI();
					break;
				case 18:
					JellyfishAI();
					break;
				case 19:
					AntlionAI();
					break;
				case 20:
					SpinningSpikeballAI();
					break;
				case 21:
					GravityDiskAI();
					break;
				case 22:
					MoreFlyerAI();
					break;
				case 23:
					EnchantedWeaponAI();
					break;
				case 24:
					BirdAI();
					break;
				case 25:
					MimicAI();
					break;
				case 26:
					UnicornAI();
					break;
				case 27:
					WallOfFleshMouthAI();
					break;
				case 28:
					WallOfFleshEyesAI();
					break;
				case 29:
					WallOfFleshTentacleAI();
					break;
				case 30:
					RetinazerAI();
					break;
				case 31:
					SpazmatismAI();
					break;
				case 32:
					SkeletronPrimeAI();
					break;
				case 33:
					SkeletronPrimeSawHand();
					break;
				case 34:
					SkeletronPrimeViceHand();
					break;
				case 35:
					SkeletronPrimeCannonHand();
					break;
				case 36:
					SkeletronPrimeLaserHand();
					break;
				case 37:
					DestroyerAI();
					break;
				case 38:
					SnowmanAI();
					break;
				case 39:
					OcramAI();
					break;
				}
			}
			catch (Exception)
			{
				active = 0;
				return;
			}
			if (type == 44 || type == 149)
			{
				Lighting.addLight(aabb.X + (width >> 1) >> 4, aabb.Y + 4 >> 4, new Vector3(0.9f, 0.75f, 0.5f));
			}
			for (int l = 0; l < 9; l++)
			{
				if (immune[l] > 0)
				{
					immune[l]--;
				}
			}
			if (!noGravity)
			{
				velocity.Y += num4;
				if (velocity.Y > num3)
				{
					velocity.Y = num3;
				}
			}
			if (velocity.X < 0.005f && velocity.X > -0.005f)
			{
				velocity.X = 0f;
			}
			if (Main.netMode != 1 && type != 37 && (friendly || type == 46 || type == 55 || type == 74))
			{
				if (life < lifeMax)
				{
					friendlyRegen++;
					if (friendlyRegen > 300)
					{
						friendlyRegen = 0;
						life++;
						netUpdate = true;
					}
				}
				if (immune[8] == 0)
				{
					for (int m = 0; m < 196; m++)
					{
						if (Main.npc[m].active != 0 && !Main.npc[m].friendly && Main.npc[m].damage > 0 && aabb.Intersects(Main.npc[m].aabb))
						{
							int dmg = Main.npc[m].damage;
							int num7 = 6;
							int num8 = 1;
							if (Main.npc[m].aabb.X + (Main.npc[m].width >> 1) > aabb.X + (width >> 1))
							{
								num8 = -1;
							}
							Main.npc[i].StrikeNPC(dmg, num7, num8);
							NetMessage.SendNpcHurt(i, dmg, num7, num8);
							netUpdate = true;
							immune[8] = 30;
						}
					}
				}
			}
			if (!noTileCollide)
			{
				bool flag2 = Collision.LavaCollision(ref position, width, height);
				if (flag2)
				{
					lavaWet = true;
					if (!lavaImmune && !dontTakeDamage && Main.netMode != 1 && immune[8] == 0)
					{
						AddBuff(24, 420);
						immune[8] = 30;
						StrikeNPC(50, 0f, 0);
						NetMessage.SendNpcHurt(whoAmI, 50, 0.0, 0);
					}
				}
				bool flag3 = false;
				if (type == 72)
				{
					flag3 = false;
					wetCount = 0;
					flag2 = false;
				}
				else
				{
					flag3 = Collision.WetCollision(ref position, width, height);
				}
				if (flag3)
				{
					if (flag && !lavaWet && Main.netMode != 1)
					{
						for (int n = 0; n < 5; n++)
						{
							if (buff[n].Type == 24)
							{
								DelBuff(n);
								break;
							}
						}
					}
					if (!wet && wetCount == 0)
					{
						wetCount = 10;
						if (!flag2)
						{
							for (int num9 = 0; num9 < 24; num9++)
							{
								Dust* ptr3 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1) - 8, width + 12, 24, 33);
								if (ptr3 == null)
								{
									break;
								}
								ptr3->velocity.Y -= 4f;
								ptr3->velocity.X *= 2.5f;
								ptr3->scale = 1.3f;
								ptr3->alpha = 100;
								ptr3->noGravity = true;
							}
							if (type != 1 && type != 59 && !noGravity)
							{
								Main.PlaySound(19, aabb.X, aabb.Y, 0);
							}
						}
						else
						{
							for (int num10 = 0; num10 < 7; num10++)
							{
								Dust* ptr4 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1) - 8, width + 12, 24, 35);
								if (ptr4 == null)
								{
									break;
								}
								ptr4->velocity.Y -= 1.5f;
								ptr4->velocity.X *= 2.5f;
								ptr4->scale = 1.3f;
								ptr4->alpha = 100;
								ptr4->noGravity = true;
							}
							if (type != 1 && type != 59 && !noGravity)
							{
								Main.PlaySound(19, aabb.X, aabb.Y);
							}
						}
					}
					wet = true;
				}
				else if (wet)
				{
					velocity.X *= 0.5f;
					wet = false;
					if (wetCount == 0)
					{
						wetCount = 10;
						if (!lavaWet)
						{
							for (int num11 = 0; num11 < 24; num11++)
							{
								Dust* ptr5 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1) - 8, width + 12, 24, 33);
								if (ptr5 == null)
								{
									break;
								}
								ptr5->velocity.Y -= 4f;
								ptr5->velocity.X *= 2.5f;
								ptr5->scale = 1.3f;
								ptr5->alpha = 100;
								ptr5->noGravity = true;
							}
							if (type != 1 && type != 59 && !noGravity)
							{
								Main.PlaySound(19, aabb.X, aabb.Y, 0);
							}
						}
						else
						{
							for (int num12 = 0; num12 < 7; num12++)
							{
								Dust* ptr6 = Main.dust.NewDust(aabb.X - 6, aabb.Y + (height >> 1) - 8, width + 12, 24, 35);
								if (ptr6 == null)
								{
									break;
								}
								ptr6->velocity.Y -= 1.5f;
								ptr6->velocity.X *= 2.5f;
								ptr6->scale = 1.3f;
								ptr6->alpha = 100;
								ptr6->noGravity = true;
							}
							if (type != 1 && type != 59 && !noGravity)
							{
								Main.PlaySound(19, aabb.X, aabb.Y);
							}
						}
					}
				}
				if (!wet)
				{
					lavaWet = false;
				}
				if (wetCount > 0)
				{
					wetCount--;
				}
				bool flag4 = false;
				if (aiStyle == 10)
				{
					flag4 = true;
				}
				else if (aiStyle == 14)
				{
					flag4 = true;
				}
				else if (aiStyle == 3 && directionY == 1)
				{
					flag4 = true;
				}
				oldVelocity = velocity;
				collideX = false;
				collideY = false;
				if (wet)
				{
					Vector2 vector = velocity;
					Collision.TileCollision(ref position, ref velocity, width, height, flag4, flag4);
					if (Collision.up)
					{
						velocity.Y = 0.01f;
					}
					Vector2 vector2 = velocity;
					vector2.X *= 0.5f;
					vector2.Y *= 0.5f;
					if (velocity.X != vector.X)
					{
						vector2.X = velocity.X;
						collideX = true;
					}
					if (velocity.Y != vector.Y)
					{
						vector2.Y = velocity.Y;
						collideY = true;
					}
					oldPosition = position;
					position.X += vector2.X;
					position.Y += vector2.Y;
				}
				else
				{
					if (type == 72)
					{
						Vector2 Position = new Vector2(position.X + (float)(width >> 1), position.Y + (float)(height >> 1));
						int num13 = 12;
						int num14 = 12;
						Position.X -= num13 >> 1;
						Position.Y -= num14 >> 1;
						Collision.TileCollision(ref Position, ref velocity, num13, num14, fallThrough: true, fall2: true);
					}
					else
					{
						Collision.TileCollision(ref position, ref velocity, width, height, flag4, flag4);
					}
					if (Collision.up)
					{
						velocity.Y = 0.01f;
					}
					if (oldVelocity.X != velocity.X)
					{
						collideX = true;
					}
					if (oldVelocity.Y != velocity.Y)
					{
						collideY = true;
					}
					oldPosition = position;
					position.X += velocity.X;
					position.Y += velocity.Y;
				}
			}
			else
			{
				oldPosition = position;
				position.X += velocity.X;
				position.Y += velocity.Y;
			}
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
			if (Main.netMode != 1 && !noTileCollide && lifeMax > 1 && Collision.SwitchTiles(position, width, height, oldPosition) && type == 46)
			{
				ai0 = 1f;
				ai1 = 400f;
				ai2 = 0f;
			}
			if (active == 0)
			{
				netUpdate = true;
			}
			if (Main.netMode == 2)
			{
				if (townNPC)
				{
					netSpam = 0;
				}
				if (netUpdate2)
				{
					netUpdate = true;
				}
				if (active == 0)
				{
					netSpam = 0;
				}
				if (netUpdate)
				{
					if (netSpam <= 180)
					{
						netSpam += 60;
						NetMessage.CreateMessage1(23, i);
						NetMessage.SendMessage();
						netUpdate2 = false;
					}
					else
					{
						netUpdate2 = true;
					}
				}
				if (netSpam > 0)
				{
					netSpam--;
				}
				if (active != 0 && townNPC && getHeadTextureId() != -1)
				{
					if (homeless != oldHomeless || homeTileX != oldHomeTileX || homeTileY != oldHomeTileY)
					{
						NetMessage.CreateMessage4(60, i, Main.npc[i].homeTileX, Main.npc[i].homeTileY, homeless ? 1 : 0);
						NetMessage.SendMessage();
					}
					oldHomeless = homeless;
					oldHomeTileX = homeTileX;
					oldHomeTileY = homeTileY;
				}
			}
			FindFrame();
			CheckActive();
			netUpdate = false;
			justHit = false;
			if (type == 120 || type == 154 || type == 137 || type == 138)
			{
				for (int num15 = oldPos.Length - 1; num15 > 0; num15--)
				{
					oldPos[num15] = oldPos[num15 - 1];
					Lighting.addLight(aabb.X >> 4, aabb.Y >> 4, new Vector3(0.3f, 0f, 0.2f));
				}
				oldPos[0] = position;
			}
			else if (type == 94 || (type >= 125 && type <= 131) || type == 139 || type == 140)
			{
				for (int num16 = oldPos.Length - 1; num16 > 0; num16--)
				{
					oldPos[num16] = oldPos[num16 - 1];
				}
				oldPos[0] = position;
			}
		}

		public Color GetAlpha(Color newColor)
		{
			float num = (float)(255 - alpha) / 255f;
			int num2 = (int)((float)(int)newColor.R * num);
			int num3 = (int)((float)(int)newColor.G * num);
			int num4 = (int)((float)(int)newColor.B * num);
			int num5 = newColor.A - alpha;
			if (type == 25 || type == 30 || type == 33 || type == 59 || type == 60)
			{
				return new Color(200, 200, 200, 0);
			}
			if (type == 72)
			{
				num2 = newColor.R;
				num3 = newColor.G;
				num4 = newColor.B;
			}
			else if (type == 64 || type == 63 || type == 75 || type == 103)
			{
				num2 = (int)((double)(int)newColor.R * 1.5);
				num3 = (int)((double)(int)newColor.G * 1.5);
				num4 = (int)((double)(int)newColor.B * 1.5);
				if (num2 > 255)
				{
					num2 = 255;
				}
				if (num3 > 255)
				{
					num3 = 255;
				}
				if (num4 > 255)
				{
					num4 = 255;
				}
			}
			if (num5 < 0)
			{
				num5 = 0;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			return new Color(num2, num3, num4, num5);
		}

		public Color GetColor(Color newColor)
		{
			int num = color.R - (255 - newColor.R);
			int num2 = color.G - (255 - newColor.G);
			int num3 = color.B - (255 - newColor.B);
			int num4 = color.A - (255 - newColor.A);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			return new Color(num, num2, num3, num4);
		}

		public string GetChat(Player player)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			for (int i = 0; i < 196; i++)
			{
				if (Main.npc[i].active != 0)
				{
					if (Main.npc[i].type == 17)
					{
						flag = true;
					}
					else if (Main.npc[i].type == 18)
					{
						flag2 = true;
					}
					else if (Main.npc[i].type == 19)
					{
						flag3 = true;
					}
					else if (Main.npc[i].type == 20)
					{
						flag4 = true;
					}
					else if (Main.npc[i].type == 37)
					{
						flag5 = true;
					}
					else if (Main.npc[i].type == 38)
					{
						flag6 = true;
					}
					else if (Main.npc[i].type == 124)
					{
						flag7 = true;
					}
					else if (Main.npc[i].type == 107)
					{
						flag8 = true;
					}
					else if (Main.npc[i].type == 22)
					{
						flag9 = true;
					}
				}
			}
			string result = "";
			if (type == 17)
			{
				if (!downedBoss1 && Main.rand.Next(3) == 0)
				{
					result = ((player.statLifeMax < 200) ? Lang.dialog(player, 1) : ((player.statDefense > 10) ? Lang.dialog(player, 3) : Lang.dialog(player, 2)));
				}
				else if (Main.gameTime.dayTime)
				{
					if ((double)Main.gameTime.time < 16200.0)
					{
						switch (Main.rand.Next(3))
						{
						case 0:
							result = Lang.dialog(player, 4);
							break;
						case 1:
							result = Lang.dialog(player, 5);
							break;
						default:
							result = Lang.dialog(player, 6);
							break;
						}
					}
					else if ((double)Main.gameTime.time > 37800.0)
					{
						switch (Main.rand.Next(3))
						{
						case 0:
							result = Lang.dialog(player, 7);
							break;
						case 1:
							result = Lang.dialog(player, 8);
							break;
						default:
							result = Lang.dialog(player, 9);
							break;
						}
					}
					else
					{
						switch (Main.rand.Next(3))
						{
						case 0:
							result = Lang.dialog(player, 10);
							break;
						case 1:
							result = Lang.dialog(player, 11);
							break;
						default:
							result = Lang.dialog(player, 12);
							break;
						}
					}
				}
				else if (Main.gameTime.bloodMoon)
				{
					if (flag2 && flag7 && Main.rand.Next(3) == 0)
					{
						result = Lang.dialog(player, 13);
					}
					else
					{
						switch (Main.rand.Next(4))
						{
						case 0:
							result = Lang.dialog(player, 14);
							break;
						case 1:
							result = Lang.dialog(player, 15);
							break;
						case 2:
							result = Lang.dialog(player, 16);
							break;
						default:
							result = Lang.dialog(player, 17);
							break;
						}
					}
				}
				else if ((double)Main.gameTime.time < 9720.0)
				{
					result = ((Main.rand.Next(2) != 0) ? Lang.dialog(player, 19) : Lang.dialog(player, 18));
				}
				else if ((double)Main.gameTime.time > 22680.0)
				{
					result = ((Main.rand.Next(2) != 0) ? Lang.dialog(player, 21) : Lang.dialog(player, 20));
				}
				else
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 22);
						break;
					case 1:
						result = Lang.dialog(player, 23);
						break;
					default:
						result = Lang.dialog(player, 24);
						break;
					}
				}
			}
			else if (type == 18)
			{
				if (Main.gameTime.bloodMoon)
				{
					if ((double)player.statLife < (double)player.statLifeMax * 0.66)
					{
						switch (Main.rand.Next(3))
						{
						case 0:
							result = Lang.dialog(player, 25);
							break;
						case 1:
							result = Lang.dialog(player, 26);
							break;
						default:
							result = Lang.dialog(player, 27);
							break;
						}
					}
					else
					{
						switch (Main.rand.Next(4))
						{
						case 0:
							result = Lang.dialog(player, 28);
							break;
						case 1:
							result = Lang.dialog(player, 29);
							break;
						case 2:
							result = Lang.dialog(player, 30);
							break;
						default:
							result = Lang.dialog(player, 31);
							break;
						}
					}
				}
				else if (Main.rand.Next(3) == 0 && !downedBoss3)
				{
					result = Lang.dialog(player, 32);
				}
				else if (flag6 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 33);
				}
				else if (flag3 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 34);
				}
				else if (flag9 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 35);
				}
				else if ((double)player.statLife < (double)player.statLifeMax * 0.33)
				{
					switch (Main.rand.Next(5))
					{
					case 0:
						result = Lang.dialog(player, 36);
						break;
					case 1:
						result = Lang.dialog(player, 37);
						break;
					case 2:
						result = Lang.dialog(player, 38);
						break;
					case 3:
						result = Lang.dialog(player, 39);
						break;
					default:
						result = Lang.dialog(player, 40);
						break;
					}
				}
				else if ((double)player.statLife < (double)player.statLifeMax * 0.66)
				{
					switch (Main.rand.Next(7))
					{
					case 0:
						result = Lang.dialog(player, 41);
						break;
					case 1:
						result = Lang.dialog(player, 42);
						break;
					case 2:
						result = Lang.dialog(player, 43);
						break;
					case 3:
						result = Lang.dialog(player, 44);
						break;
					case 4:
						result = Lang.dialog(player, 45);
						break;
					case 5:
						result = Lang.dialog(player, 46);
						break;
					default:
						result = Lang.dialog(player, 47);
						break;
					}
				}
				else
				{
					switch (Main.rand.Next(4))
					{
					case 0:
						result = Lang.dialog(player, 48);
						break;
					case 1:
						result = Lang.dialog(player, 49);
						break;
					case 2:
						result = Lang.dialog(player, 50);
						break;
					default:
						result = Lang.dialog(player, 51);
						break;
					}
				}
			}
			else if (type == 19)
			{
				if (downedBoss3 && !Main.hardMode)
				{
					result = Lang.dialog(player, 58);
				}
				else if (flag2 && Main.rand.Next(5) == 0)
				{
					result = Lang.dialog(player, 59);
				}
				else if (flag2 && Main.rand.Next(5) == 0)
				{
					result = Lang.dialog(player, 60);
				}
				else if (flag4 && Main.rand.Next(5) == 0)
				{
					result = Lang.dialog(player, 61);
				}
				else if (flag6 && Main.rand.Next(5) == 0)
				{
					result = Lang.dialog(player, 62);
				}
				else if (flag6 && Main.rand.Next(5) == 0)
				{
					result = Lang.dialog(player, 63);
				}
				else if (Main.gameTime.bloodMoon)
				{
					result = ((Main.rand.Next(2) != 0) ? Lang.dialog(player, 65) : Lang.dialog(player, 64));
				}
				else
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 66);
						break;
					case 1:
						result = Lang.dialog(player, 67);
						break;
					default:
						result = Lang.dialog(player, 68);
						break;
					}
				}
			}
			else if (type == 20)
			{
				if (!downedBoss2 && Main.rand.Next(3) == 0)
				{
					result = Lang.dialog(player, 69);
				}
				else if (flag3 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 70);
				}
				else if (flag && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 71);
				}
				else if (flag5 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 72);
				}
				else if (Main.gameTime.bloodMoon)
				{
					switch (Main.rand.Next(4))
					{
					case 0:
						result = Lang.dialog(player, 73);
						break;
					case 1:
						result = Lang.dialog(player, 74);
						break;
					case 2:
						result = Lang.dialog(player, 75);
						break;
					default:
						result = Lang.dialog(player, 76);
						break;
					}
				}
				else
				{
					switch (Main.rand.Next(5))
					{
					case 0:
						result = Lang.dialog(player, 77);
						break;
					case 1:
						result = Lang.dialog(player, 78);
						break;
					case 2:
						result = Lang.dialog(player, 79);
						break;
					case 3:
						result = Lang.dialog(player, 80);
						break;
					default:
						result = Lang.dialog(player, 81);
						break;
					}
				}
			}
			else if (type == 37)
			{
				if (Main.gameTime.dayTime)
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 82);
						break;
					case 1:
						result = Lang.dialog(player, 83);
						break;
					default:
						result = Lang.dialog(player, 84);
						break;
					}
				}
				else if (player.statLifeMax < 300 || player.statDefense < 10)
				{
					switch (Main.rand.Next(4))
					{
					case 0:
						result = Lang.dialog(player, 85);
						break;
					case 1:
						result = Lang.dialog(player, 86);
						break;
					case 2:
						result = Lang.dialog(player, 87);
						break;
					default:
						result = Lang.dialog(player, 88);
						break;
					}
				}
				else
				{
					switch (Main.rand.Next(4))
					{
					case 0:
						result = Lang.dialog(player, 89);
						break;
					case 1:
						result = Lang.dialog(player, 90);
						break;
					case 2:
						result = Lang.dialog(player, 91);
						break;
					default:
						result = Lang.dialog(player, 92);
						break;
					}
				}
			}
			else if (type == 38)
			{
				if (!downedBoss2 && Main.rand.Next(3) == 0)
				{
					result = Lang.dialog(player, 93);
				}
				if (Main.gameTime.bloodMoon)
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 94);
						break;
					case 1:
						result = Lang.dialog(player, 95);
						break;
					default:
						result = Lang.dialog(player, 96);
						break;
					}
				}
				else if (flag3 && Main.rand.Next(5) == 0)
				{
					result = Lang.dialog(player, 97);
				}
				else if (flag3 && Main.rand.Next(5) == 0)
				{
					result = Lang.dialog(player, 98);
				}
				else if (flag2 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 99);
				}
				else if (flag4 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 100);
				}
				else if (!Main.gameTime.dayTime)
				{
					switch (Main.rand.Next(4))
					{
					case 0:
						result = Lang.dialog(player, 101);
						break;
					case 1:
						result = Lang.dialog(player, 102);
						break;
					case 2:
						result = Lang.dialog(player, 103);
						break;
					default:
						result = Lang.dialog(player, 104);
						break;
					}
				}
				else
				{
					switch (Main.rand.Next(5))
					{
					case 0:
						result = Lang.dialog(player, 105);
						break;
					case 1:
						result = Lang.dialog(player, 106);
						break;
					case 2:
						result = Lang.dialog(player, 107);
						break;
					case 3:
						result = Lang.dialog(player, 108);
						break;
					default:
						result = Lang.dialog(player, 109);
						break;
					}
				}
			}
			else if (type == 54)
			{
				if (!flag7 && Main.rand.Next(2) == 0)
				{
					result = Lang.dialog(player, 110);
				}
				else if (Main.gameTime.bloodMoon)
				{
					result = Lang.dialog(player, 111);
				}
				else if (flag2 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 112);
				}
				else if (player.head == 24)
				{
					result = Lang.dialog(player, 113);
				}
				else
				{
					switch (Main.rand.Next(6))
					{
					case 0:
						result = Lang.dialog(player, 114);
						break;
					case 1:
						result = Lang.dialog(player, 115);
						break;
					case 2:
						result = Lang.dialog(player, 116);
						break;
					case 3:
						result = Lang.dialog(player, 117);
						break;
					case 4:
						result = Lang.dialog(player, 118);
						break;
					default:
						result = Lang.dialog(player, 119);
						break;
					}
				}
			}
			else if (type == 105)
			{
				result = Lang.dialog(player, 120);
			}
			else if (type == 107)
			{
				if (homeless)
				{
					switch (Main.rand.Next(5))
					{
					case 0:
						result = Lang.dialog(player, 121);
						break;
					case 1:
						result = Lang.dialog(player, 122);
						break;
					case 2:
						result = Lang.dialog(player, 123);
						break;
					case 3:
						result = Lang.dialog(player, 124);
						break;
					default:
						result = Lang.dialog(player, 125);
						break;
					}
				}
				else if (flag7 && Main.rand.Next(4) == 0)
				{
					result = Lang.dialog(player, 126);
				}
				else if (!Main.gameTime.dayTime)
				{
					switch (Main.rand.Next(5))
					{
					case 0:
						result = Lang.dialog(player, 127);
						break;
					case 1:
						result = Lang.dialog(player, 128);
						break;
					case 2:
						result = Lang.dialog(player, 129);
						break;
					case 3:
						result = Lang.dialog(player, 130);
						break;
					default:
						result = Lang.dialog(player, 131);
						break;
					}
				}
				else
				{
					switch (Main.rand.Next(5))
					{
					case 0:
						result = Lang.dialog(player, 132);
						break;
					case 1:
						result = Lang.dialog(player, 133);
						break;
					case 2:
						result = Lang.dialog(player, 134);
						break;
					case 3:
						result = Lang.dialog(player, 135);
						break;
					default:
						result = Lang.dialog(player, 136);
						break;
					}
				}
			}
			else if (type == 106)
			{
				result = Lang.dialog(player, 137);
			}
			else if (type == 108)
			{
				if (homeless)
				{
					int num = Main.rand.Next(3);
					if (num == 0)
					{
						result = Lang.dialog(player, 138);
					}
					else if (num == 1 && !player.male)
					{
						result = Lang.dialog(player, 139);
					}
					else
					{
						switch (num)
						{
						case 1:
							result = Lang.dialog(player, 140);
							break;
						case 2:
							result = Lang.dialog(player, 141);
							break;
						}
					}
				}
				else if (player.male && flag9 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 142);
				}
				else if (player.male && flag6 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 143);
				}
				else if (player.male && flag8 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 144);
				}
				else if (!player.male && flag2 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 145);
				}
				else if (!player.male && flag7 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 146);
				}
				else if (!player.male && flag4 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 147);
				}
				else if (!Main.gameTime.dayTime)
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 148);
						break;
					case 1:
						result = Lang.dialog(player, 149);
						break;
					case 2:
						result = Lang.dialog(player, 150);
						break;
					}
				}
				else
				{
					switch (Main.rand.Next(5))
					{
					case 0:
						result = Lang.dialog(player, 151);
						break;
					case 1:
						result = Lang.dialog(player, 152);
						break;
					case 2:
						result = Lang.dialog(player, 153);
						break;
					case 3:
						result = Lang.dialog(player, 154);
						break;
					default:
						result = Lang.dialog(player, 155);
						break;
					}
				}
			}
			else if (type == 123)
			{
				result = Lang.dialog(player, 156);
			}
			else if (type == 124)
			{
				if (homeless)
				{
					switch (Main.rand.Next(4))
					{
					case 0:
						result = Lang.dialog(player, 157);
						break;
					case 1:
						result = Lang.dialog(player, 158);
						break;
					case 2:
						result = Lang.dialog(player, 159);
						break;
					default:
						result = Lang.dialog(player, 160);
						break;
					}
				}
				else if (Main.gameTime.bloodMoon)
				{
					switch (Main.rand.Next(4))
					{
					case 0:
						result = Lang.dialog(player, 161);
						break;
					case 1:
						result = Lang.dialog(player, 162);
						break;
					case 2:
						result = Lang.dialog(player, 163);
						break;
					default:
						result = Lang.dialog(player, 164);
						break;
					}
				}
				else if (flag8 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 165);
				}
				else if (flag3 && Main.rand.Next(6) == 0)
				{
					result = Lang.dialog(player, 166);
				}
				else
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 167);
						break;
					case 1:
						result = Lang.dialog(player, 168);
						break;
					default:
						result = Lang.dialog(player, 169);
						break;
					}
				}
			}
			else if (type == 22)
			{
				if (Main.gameTime.bloodMoon)
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 170);
						break;
					case 1:
						result = Lang.dialog(player, 171);
						break;
					default:
						result = Lang.dialog(player, 172);
						break;
					}
				}
				else if (!Main.gameTime.dayTime)
				{
					result = Lang.dialog(player, 173);
				}
				else
				{
					switch (Main.rand.Next(3))
					{
					case 0:
						result = Lang.dialog(player, 174);
						break;
					case 1:
						result = Lang.dialog(player, 175);
						break;
					default:
						result = Lang.dialog(player, 176);
						break;
					}
				}
			}
			else if (type == 142)
			{
				switch (Main.rand.Next(3))
				{
				case 0:
					result = Lang.dialog(player, 224);
					break;
				case 1:
					result = Lang.dialog(player, 225);
					break;
				case 2:
					result = Lang.dialog(player, 226);
					break;
				}
			}
			return result;
		}

		public static void checkForTownSpawns()
		{
			if (++checkForSpawnsTimer < 7200)
			{
				return;
			}
			checkForSpawnsTimer = 0;
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				if (Main.player[i].active != 0)
				{
					num++;
				}
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
			bool flag = true;
			for (int j = 0; j < 196; j++)
			{
				if (Main.npc[j].active != 0 && Main.npc[j].townNPC)
				{
					if (Main.npc[j].type != 37 && !Main.npc[j].homeless)
					{
						WorldGen.QuickFindHome(j);
					}
					bool flag2 = Main.npc[j].homeless;
					if (Main.npc[j].type == 37)
					{
						num7++;
						flag2 = false;
					}
					else if (Main.npc[j].type == 17)
					{
						num2++;
					}
					else if (Main.npc[j].type == 18)
					{
						num3++;
					}
					else if (Main.npc[j].type == 19)
					{
						num5++;
					}
					else if (Main.npc[j].type == 20)
					{
						num4++;
					}
					else if (Main.npc[j].type == 22)
					{
						num6++;
					}
					else if (Main.npc[j].type == 38)
					{
						num8++;
					}
					else if (Main.npc[j].type == 54)
					{
						num9++;
					}
					else if (Main.npc[j].type == 107)
					{
						num11++;
					}
					else if (Main.npc[j].type == 108)
					{
						num10++;
					}
					else if (Main.npc[j].type == 124)
					{
						num12++;
					}
					else if (Main.npc[j].type == 142)
					{
						num13++;
						flag2 = false;
					}
					flag = (flag && !flag2);
					num14++;
				}
			}
			if (WorldGen.spawnNPC != 0)
			{
				return;
			}
			int num15 = 0;
			bool flag3 = false;
			int num16 = 0;
			bool flag4 = false;
			bool flag5 = false;
			for (int k = 0; k < 8; k++)
			{
				if (Main.player[k].active == 0)
				{
					continue;
				}
				for (int l = 0; l < 48; l++)
				{
					if (Main.player[k].inventory[l].type > 0 && Main.player[k].inventory[l].stack > 0)
					{
						if (Main.player[k].inventory[l].type == 71)
						{
							num15 += Main.player[k].inventory[l].stack;
						}
						else if (Main.player[k].inventory[l].type == 72)
						{
							num15 += Main.player[k].inventory[l].stack * 100;
						}
						else if (Main.player[k].inventory[l].type == 73)
						{
							num15 += Main.player[k].inventory[l].stack * 10000;
						}
						else if (Main.player[k].inventory[l].type == 74)
						{
							num15 += Main.player[k].inventory[l].stack * 1000000;
						}
						if (Main.player[k].inventory[l].ammo == 14 || Main.player[k].inventory[l].useAmmo == 14)
						{
							flag4 = true;
						}
						if (Main.player[k].inventory[l].type == 166 || Main.player[k].inventory[l].type == 167 || Main.player[k].inventory[l].type == 168 || Main.player[k].inventory[l].type == 235)
						{
							flag5 = true;
						}
					}
				}
				int num17 = Main.player[k].statLifeMax / 20;
				if (num17 > 5)
				{
					flag3 = true;
				}
				num16 += num17;
			}
			if (!downedBoss3 && num7 == 0)
			{
				int num18 = NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37);
				Main.npc[num18].homeless = false;
				Main.npc[num18].homeTileX = Main.dungeonX;
				Main.npc[num18].homeTileY = Main.dungeonY;
			}
			if (num6 < 1)
			{
				WorldGen.spawnNPC = 22;
			}
			else if ((double)num15 > 5000.0 && num2 < 1)
			{
				WorldGen.spawnNPC = 17;
			}
			else if (flag3 && num3 < 1)
			{
				WorldGen.spawnNPC = 18;
			}
			else if (flag4 && num5 < 1)
			{
				WorldGen.spawnNPC = 19;
			}
			else if ((downedBoss1 || downedBoss2 || downedBoss3) && num4 < 1)
			{
				WorldGen.spawnNPC = 20;
			}
			else if (flag5 && num2 > 0 && num8 < 1)
			{
				WorldGen.spawnNPC = 38;
			}
			else if (downedBoss3 && num9 < 1)
			{
				WorldGen.spawnNPC = 54;
			}
			else if (savedGoblin && num11 < 1)
			{
				WorldGen.spawnNPC = 107;
			}
			else if (savedWizard && num10 < 1)
			{
				WorldGen.spawnNPC = 108;
			}
			else if (savedMech && num12 < 1)
			{
				WorldGen.spawnNPC = 124;
			}
			else if (downedFrost && num13 < 1 && Time.xMas)
			{
				WorldGen.spawnNPC = 142;
			}
		}

		public void ApplyProjectileBuff(int type)
		{
			switch (type)
			{
			case 2:
				if (Main.rand.Next(3) == 0)
				{
					AddBuff(24, 180);
				}
				break;
			case 15:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(24, 300);
				}
				break;
			case 19:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(24, 180);
				}
				break;
			case 33:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(20, 420);
				}
				break;
			case 34:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(24, 240);
				}
				break;
			case 35:
				if (Main.rand.Next(4) == 0)
				{
					AddBuff(24, 180);
				}
				break;
			case 54:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(20, 600);
				}
				break;
			case 63:
				if (Main.rand.Next(3) != 0)
				{
					AddBuff(31, 120);
				}
				break;
			case 85:
				AddBuff(24, 1200);
				break;
			case 95:
			case 103:
			case 104:
			case 113:
				AddBuff(39, 420);
				break;
			case 98:
				AddBuff(20, 600);
				break;
			}
		}

		public void ApplyWeaponBuff(int type)
		{
			switch (type)
			{
			case 121:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(24, 180);
				}
				break;
			case 122:
				if (Main.rand.Next(10) == 0)
				{
					AddBuff(24, 180);
				}
				break;
			case 190:
			case 614:
				if (Main.rand.Next(4) == 0)
				{
					AddBuff(20, 420);
				}
				break;
			case 217:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(24, 180);
				}
				break;
			case 613:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(30, 600);
				}
				break;
			}
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public void DrawInfo(WorldView view)
		{
			if (realLife >= 0 && realLife != whoAmI)
			{
				if (view.drawNpcName[realLife])
				{
					Main.npc[realLife].DrawInfo(view);
				}
				return;
			}
			view.drawNpcName[whoAmI] = false;
			string s = (!hasName()) ? displayName : getName();
			int num = aabb.X + (width >> 1) - view.screenPosition.X;
			int num2 = aabb.Y + height - view.screenPosition.Y - 10;
			num2 += (int)UI.DrawStringCT(UI.fontSmall, s, num, num2, UI.mouseTextColor);
			if (lifeMax <= 1 || dontTakeDamage)
			{
				return;
			}
			int num3 = life - healthBarLife;
			if (num3 != 0)
			{
				if (Math.Abs(num3) > 1)
				{
					healthBarLife += num3 >> 2;
				}
				else
				{
					healthBarLife = life;
				}
			}
			Rectangle rect = default(Rectangle);
			rect.X = num - 22;
			rect.Y = num2 - 4;
			rect.Height = 10;
			rect.Width = 52;
			Color wINDOW_OUTLINE = UI.WINDOW_OUTLINE;
			Main.DrawRect(rect, wINDOW_OUTLINE, center: false);
			rect.X += 2;
			rect.Y += 2;
			rect.Width = healthBarLife * 48 / lifeMax;
			rect.Height = 6;
			wINDOW_OUTLINE = new Color((48 - rect.Width) * 5, rect.Width * 5, 16, 128);
			Main.DrawSolidRect(ref rect, wINDOW_OUTLINE);
			if (rect.Width < 48)
			{
				wINDOW_OUTLINE = new Color(0, 0, 0, 128);
				rect.X += rect.Width;
				rect.Width = 48 - rect.Width;
				Main.DrawSolidRect(ref rect, wINDOW_OUTLINE);
			}
		}
	}
}
