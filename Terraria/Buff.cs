namespace Terraria;

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
		switch ((ID)Type)
		{
		case ID.POISONED:
		case ID.ON_FIRE:
		case ID.BLEED:
		case ID.CONFUSED:
		case ID.ON_FIRE_2:
			return true;
		default:
			return false;
		}
	}

	public static bool IsDebuff(int type)
	{
		switch ((ID)type)
		{
		case ID.POISONED:
		case ID.POTION_DELAY:
		case ID.BLIND:
		case ID.NO_ITEMS:
		case ID.ON_FIRE:
		case ID.DRUNK:
		case ID.WEREWOLF:
		case ID.BLEED:
		case ID.CONFUSED:
		case ID.SLOW:
		case ID.WEAK:
		case ID.MERFOLK:
		case ID.SILENCE:
		case ID.BROKEN_ARMOR:
		case ID.HORRIFIED:
		case ID.TONGUED:
		case ID.ON_FIRE_2:
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
		switch ((ID)Type)
		{
		case ID.POISONED:
		case ID.POTION_DELAY:
		case ID.BLIND:
		case ID.NO_ITEMS:
		case ID.ON_FIRE:
		case ID.DRUNK:
		case ID.BLEED:
		case ID.CONFUSED:
		case ID.SLOW:
		case ID.WEAK:
		case ID.SILENCE:
		case ID.BROKEN_ARMOR:
		case ID.HORRIFIED:
		case ID.TONGUED:
		case ID.ON_FIRE_2:
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
