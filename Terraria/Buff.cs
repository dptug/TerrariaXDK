namespace Terraria
{
	public struct Buff
	{
		public enum ID
		{
			NONE,
			LAVA_IMMUNE,
			LIFE_REGEN,
			HASTE,
			GILLS,
			IRONSKIN,
			MANA_REGEN,
			MAGIC_POWER,
			SLOWFALL,
			FIND_TREASURE,
			INVISIBLE,
			SHINE,
			NIGHTVISION,
			ENEMY_SPAWNS,
			THORNS,
			WATER_WALK,
			RANGED_DAMAGE,
			DETECT_CREATURE,
			GRAVITY_CONTROL,
			LIGHT_ORB,
			POISONED,
			POTION_DELAY,
			BLIND,
			NO_ITEMS,
			ON_FIRE,
			DRUNK,
			WELL_FED,
			FAIRY,
			WEREWOLF,
			CLARAVOYANCE,
			BLEED,
			CONFUSED,
			SLOW,
			WEAK,
			MERFOLK,
			SILENCE,
			BROKEN_ARMOR,
			HORRIFIED,
			TONGUED,
			ON_FIRE_2,
			PET,
			NUM_TYPES
		}

		public const int NUM_BUFFS = 41;

		public const int NUM_BUFF_STRINGS = 46;

		public static string[] buffName = new string[46];

		public static string[] buffTip = new string[46];

		public ushort Type;

		public ushort Time;

		public bool IsPvpBuff()
		{
			switch (Type)
			{
			case 20:
			case 24:
			case 30:
			case 31:
			case 39:
				return true;
			default:
				return false;
			}
		}

		public static bool IsDebuff(int type)
		{
			switch (type)
			{
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 28:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
				return true;
			default:
				return false;
			}
		}

		public bool IsDebuff()
		{
			return IsDebuff(Type);
		}

		public bool IsHealable()
		{
			switch (Type)
			{
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 30:
			case 31:
			case 32:
			case 33:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
				return Time > 0;
			default:
				return false;
			}
		}

		public void Init()
		{
			Type = 0;
			Time = 0;
		}
	}
}
