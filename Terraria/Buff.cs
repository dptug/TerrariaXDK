// Type: Terraria.Buff
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

namespace Terraria
{
  public struct Buff
  {
    public static string[] buffName = new string[46];
    public static string[] buffTip = new string[46];
    public const int NUM_BUFFS = 41;
    public const int NUM_BUFF_STRINGS = 46;
    public ushort Type;
    public ushort Time;

    static Buff()
    {
    }

    public bool IsPvpBuff()
    {
      switch ((Buff.ID) this.Type)
      {
        case Buff.ID.BLEED:
        case Buff.ID.CONFUSED:
        case Buff.ID.ON_FIRE_2:
        case Buff.ID.POISONED:
        case Buff.ID.ON_FIRE:
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
      return Buff.IsDebuff((int) this.Type);
    }

    public bool IsHealable()
    {
      switch (this.Type)
      {
        case (ushort) 20:
        case (ushort) 21:
        case (ushort) 22:
        case (ushort) 23:
        case (ushort) 24:
        case (ushort) 25:
        case (ushort) 30:
        case (ushort) 31:
        case (ushort) 32:
        case (ushort) 33:
        case (ushort) 35:
        case (ushort) 36:
        case (ushort) 37:
        case (ushort) 38:
        case (ushort) 39:
          return (int) this.Time > 0;
        default:
          return false;
      }
    }

    public void Init()
    {
      this.Type = (ushort) 0;
      this.Time = (ushort) 0;
    }

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
      NUM_TYPES,
    }
  }
}
