// Type: Terraria.Item
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public struct Item
  {
    public static short[] headType = new short[48];
    public static short[] bodyType = new short[29];
    public static short[] legType = new short[28];
    private static readonly byte[] PREFIX_TOOLS = new byte[40]
    {
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 5,
      (byte) 6,
      (byte) 7,
      (byte) 8,
      (byte) 9,
      (byte) 10,
      (byte) 11,
      (byte) 12,
      (byte) 13,
      (byte) 14,
      (byte) 15,
      (byte) 36,
      (byte) 37,
      (byte) 38,
      (byte) 53,
      (byte) 54,
      (byte) 55,
      (byte) 39,
      (byte) 40,
      (byte) 56,
      (byte) 41,
      (byte) 57,
      (byte) 42,
      (byte) 43,
      (byte) 44,
      (byte) 45,
      (byte) 46,
      (byte) 47,
      (byte) 48,
      (byte) 49,
      (byte) 50,
      (byte) 51,
      (byte) 59,
      (byte) 60,
      (byte) 61,
      (byte) 81
    };
    private static readonly byte[] PREFIX_SPEARS = new byte[14]
    {
      (byte) 36,
      (byte) 37,
      (byte) 38,
      (byte) 53,
      (byte) 54,
      (byte) 55,
      (byte) 39,
      (byte) 40,
      (byte) 56,
      (byte) 41,
      (byte) 57,
      (byte) 59,
      (byte) 60,
      (byte) 61
    };
    private static readonly byte[] PREFIX_GUNS = new byte[36]
    {
      (byte) 16,
      (byte) 17,
      (byte) 18,
      (byte) 19,
      (byte) 20,
      (byte) 21,
      (byte) 22,
      (byte) 23,
      (byte) 24,
      (byte) 25,
      (byte) 58,
      (byte) 36,
      (byte) 37,
      (byte) 38,
      (byte) 53,
      (byte) 54,
      (byte) 55,
      (byte) 39,
      (byte) 40,
      (byte) 56,
      (byte) 41,
      (byte) 57,
      (byte) 42,
      (byte) 43,
      (byte) 44,
      (byte) 45,
      (byte) 46,
      (byte) 47,
      (byte) 48,
      (byte) 49,
      (byte) 50,
      (byte) 51,
      (byte) 59,
      (byte) 60,
      (byte) 61,
      (byte) 82
    };
    private static readonly byte[] PREFIX_MAGIC = new byte[36]
    {
      (byte) 26,
      (byte) 27,
      (byte) 28,
      (byte) 29,
      (byte) 30,
      (byte) 31,
      (byte) 32,
      (byte) 33,
      (byte) 34,
      (byte) 35,
      (byte) 52,
      (byte) 36,
      (byte) 37,
      (byte) 38,
      (byte) 53,
      (byte) 54,
      (byte) 55,
      (byte) 39,
      (byte) 40,
      (byte) 56,
      (byte) 41,
      (byte) 57,
      (byte) 42,
      (byte) 43,
      (byte) 44,
      (byte) 45,
      (byte) 46,
      (byte) 47,
      (byte) 48,
      (byte) 49,
      (byte) 50,
      (byte) 51,
      (byte) 59,
      (byte) 60,
      (byte) 61,
      (byte) 83
    };
    private static readonly byte[] PREFIX_BOOMERANG = new byte[14]
    {
      (byte) 36,
      (byte) 37,
      (byte) 38,
      (byte) 53,
      (byte) 54,
      (byte) 55,
      (byte) 39,
      (byte) 40,
      (byte) 56,
      (byte) 41,
      (byte) 57,
      (byte) 59,
      (byte) 60,
      (byte) 61
    };
    private static uint lastItemIndex = 0U;
    public const int MAX_TYPES = 632;
    public const uint potionDelay = 3600U;
    public const uint potionDelayPhilosopher = 2700U;
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

    static Item()
    {
    }

    public void Init()
    {
      this.active = (byte) 0;
      this.owner = (byte) 8;
      this.type = (short) 0;
      this.netID = (short) 0;
      this.prefix = (byte) 0;
      this.crit = (short) 0;
      this.wornArmor = false;
      this.mech = false;
      this.reuseDelay = (byte) 0;
      this.melee = false;
      this.magic = false;
      this.ranged = false;
      this.placeStyle = (byte) 0;
      this.buffTime = (ushort) 0;
      this.buffType = (byte) 0;
      this.material = false;
      this.noWet = false;
      this.vanity = false;
      this.mana = (byte) 0;
      this.wet = false;
      this.wetCount = (byte) 0;
      this.lavaWet = false;
      this.channel = false;
      this.buyOnce = false;
      this.social = false;
      this.release = (ushort) 0;
      this.noMelee = false;
      this.noUseGraphic = false;
      this.lifeRegen = (byte) 0;
      this.shootSpeed = 0.0f;
      this.alpha = (byte) 0;
      this.ammo = (byte) 0;
      this.useAmmo = (byte) 0;
      this.autoReuse = false;
      this.accessory = false;
      this.axe = (byte) 0;
      this.healMana = (short) 0;
      this.bodySlot = (short) -1;
      this.legSlot = (short) -1;
      this.headSlot = (short) -1;
      this.potion = false;
      this.consumable = false;
      this.createTile = (short) -1;
      this.createWall = (short) -1;
      this.damage = (short) 0;
      this.defense = (short) 0;
      this.hammer = (byte) 0;
      this.healLife = (short) 0;
      this.knockBack = 0.0f;
      this.pick = (byte) 0;
      this.rare = (sbyte) 0;
      this.scale = 1f;
      this.shoot = (byte) 0;
      this.stack = (short) 0;
      this.maxStack = (short) 0;
      this.tileBoost = (sbyte) 0;
      this.holdStyle = (byte) 0;
      this.useStyle = (byte) 0;
      this.useSound = (byte) 0;
      this.useTime = (byte) 100;
      this.useAnimation = (byte) 100;
      this.value = 0;
      this.useTurn = false;
      this.buy = false;
      this.ownIgnore = (byte) 8;
      this.ownTime = (byte) 0;
      this.keepTime = (byte) 0;
    }

    public bool isLocal()
    {
      if ((int) this.owner < 8)
        return Main.player[(int) this.owner].isLocal();
      else
        return false;
    }

    public bool isEquipable()
    {
      if (!this.accessory && (int) this.headSlot < 0 && (int) this.bodySlot < 0)
        return (int) this.legSlot >= 0;
      else
        return true;
    }

    public bool Prefix(int pre)
    {
      if (pre == 0 || (int) this.type == 0)
        return false;
      int num1 = pre;
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
        if (num1 == -1 && Main.rand.Next(4) == 0)
          num1 = 0;
        if (pre < -1)
          num1 = -1;
        if (num1 == -1 || num1 == -2 || num1 == -3)
        {
          if ((int) this.type == 1 || (int) this.type == 4 || ((int) this.type == 6 || (int) this.type == 7) || ((int) this.type == 10 || (int) this.type == 24 || ((int) this.type == 45 || (int) this.type == 46)) || ((int) this.type == 103 || (int) this.type == 104 || ((int) this.type == 121 || (int) this.type == 122) || ((int) this.type == 155 || (int) this.type == 190 || ((int) this.type == 196 || (int) this.type == 198))) || ((int) this.type == 199 || (int) this.type == 200 || ((int) this.type == 201 || (int) this.type == 202) || ((int) this.type == 203 || (int) this.type == 204 || ((int) this.type == 213 || (int) this.type == 217)) || ((int) this.type == 273 || (int) this.type == 367 || ((int) this.type == 368 || (int) this.type == 426) || ((int) this.type == 482 || (int) this.type == 483 || ((int) this.type == 484 || (int) this.type == 613)))))
            num1 = (int) Item.PREFIX_TOOLS[Main.rand.Next(Item.PREFIX_TOOLS.Length)];
          else if ((int) this.type == 162 || (int) this.type == 160 || ((int) this.type == 163 || (int) this.type == 220) || ((int) this.type == 274 || (int) this.type == 277 || ((int) this.type == 280 || (int) this.type == 383)) || ((int) this.type == 384 || (int) this.type == 385 || ((int) this.type == 386 || (int) this.type == 387) || ((int) this.type == 388 || (int) this.type == 389 || ((int) this.type == 390 || (int) this.type == 406))) || ((int) this.type == 537 || (int) this.type == 550 || ((int) this.type == 579 || (int) this.type == 614)))
            num1 = (int) Item.PREFIX_SPEARS[Main.rand.Next(Item.PREFIX_SPEARS.Length)];
          else if ((int) this.type == 39 || (int) this.type == 44 || ((int) this.type == 95 || (int) this.type == 96) || ((int) this.type == 98 || (int) this.type == 99 || ((int) this.type == 120 || (int) this.type == 164)) || ((int) this.type == 197 || (int) this.type == 219 || ((int) this.type == 266 || (int) this.type == 281) || ((int) this.type == 434 || (int) this.type == 435 || ((int) this.type == 436 || (int) this.type == 481))) || ((int) this.type == 506 || (int) this.type == 533 || ((int) this.type == 534 || (int) this.type == 578) || ((int) this.type == 615 || (int) this.type == 617)))
            num1 = (int) Item.PREFIX_GUNS[Main.rand.Next(Item.PREFIX_GUNS.Length)];
          else if ((int) this.type == 64 || (int) this.type == 65 || ((int) this.type == 112 || (int) this.type == 113) || ((int) this.type == (int) sbyte.MaxValue || (int) this.type == 157 || ((int) this.type == 165 || (int) this.type == 218)) || ((int) this.type == 272 || (int) this.type == 494 || ((int) this.type == 495 || (int) this.type == 496) || ((int) this.type == 514 || (int) this.type == 517 || ((int) this.type == 518 || (int) this.type == 519))))
            num1 = (int) Item.PREFIX_MAGIC[Main.rand.Next(Item.PREFIX_MAGIC.Length)];
          else if ((int) this.type == 55 || (int) this.type == 119 || ((int) this.type == 191 || (int) this.type == 284))
          {
            num1 = (int) Item.PREFIX_BOOMERANG[Main.rand.Next(Item.PREFIX_BOOMERANG.Length)];
          }
          else
          {
            if (!this.accessory || (int) this.type == 267 || ((int) this.type == 562 || (int) this.type == 563) || ((int) this.type == 564 || (int) this.type == 565 || ((int) this.type == 566 || (int) this.type == 567)) || ((int) this.type == 568 || (int) this.type == 569 || ((int) this.type == 570 || (int) this.type == 571) || ((int) this.type == 572 || (int) this.type == 573 || ((int) this.type == 574 || (int) this.type == 576))))
              return false;
            num1 = Main.rand.Next(62, 81);
          }
        }
        if (pre == -3)
          return true;
        if (pre == -1 && (num1 >= 7 && num1 <= 11 || (num1 == 22 || num1 == 23) || (num1 == 24 || num1 == 29 || (num1 == 30 || num1 == 31)) || (num1 == 39 || num1 == 40 || (num1 == 41 || num1 == 47) || (num1 == 48 || num1 == 49 || num1 == 56))) && Main.rand.Next(3) != 0)
          num1 = 0;
        if (num1 == 1)
          num5 = 1.12f;
        else if (num1 == 2)
          num5 = 1.18f;
        else if (num1 == 3)
        {
          num2 = 1.05f;
          num8 = 2;
          num5 = 1.05f;
        }
        else if (num1 == 4)
        {
          num2 = 1.1f;
          num5 = 1.1f;
          num3 = 1.1f;
        }
        else if (num1 == 5)
          num2 = 1.15f;
        else if (num1 == 6)
          num2 = 1.1f;
        else if (num1 == 81)
        {
          num3 = 1.15f;
          num2 = 1.15f;
          num8 = 5;
          num4 = 0.9f;
          num5 = 1.1f;
        }
        else if (num1 == 7)
          num5 = 0.82f;
        else if (num1 == 8)
        {
          num3 = 0.85f;
          num2 = 0.85f;
          num5 = 0.87f;
        }
        else if (num1 == 9)
          num5 = 0.9f;
        else if (num1 == 10)
          num2 = 0.85f;
        else if (num1 == 11)
        {
          num4 = 1.1f;
          num3 = 0.9f;
          num5 = 0.9f;
        }
        else if (num1 == 12)
        {
          num3 = 1.1f;
          num2 = 1.05f;
          num5 = 1.1f;
          num4 = 1.15f;
        }
        else if (num1 == 13)
        {
          num3 = 0.8f;
          num2 = 0.9f;
          num5 = 1.1f;
        }
        else if (num1 == 14)
        {
          num3 = 1.15f;
          num4 = 1.1f;
        }
        else if (num1 == 15)
        {
          num3 = 0.9f;
          num4 = 0.85f;
        }
        else if (num1 == 16)
        {
          num2 = 1.1f;
          num8 = 3;
        }
        else if (num1 == 17)
        {
          num4 = 0.85f;
          num6 = 1.1f;
        }
        else if (num1 == 18)
        {
          num4 = 0.9f;
          num6 = 1.15f;
        }
        else if (num1 == 19)
        {
          num3 = 1.15f;
          num6 = 1.05f;
        }
        else if (num1 == 20)
        {
          num3 = 1.05f;
          num6 = 1.05f;
          num2 = 1.1f;
          num4 = 0.95f;
          num8 = 2;
        }
        else if (num1 == 21)
        {
          num3 = 1.15f;
          num2 = 1.1f;
        }
        else if (num1 == 82)
        {
          num3 = 1.15f;
          num2 = 1.15f;
          num8 = 5;
          num4 = 0.9f;
          num6 = 1.1f;
        }
        else if (num1 == 22)
        {
          num3 = 0.9f;
          num6 = 0.9f;
          num2 = 0.85f;
        }
        else if (num1 == 23)
        {
          num4 = 1.15f;
          num6 = 0.9f;
        }
        else if (num1 == 24)
        {
          num4 = 1.1f;
          num3 = 0.8f;
        }
        else if (num1 == 25)
        {
          num4 = 1.1f;
          num2 = 1.15f;
          num8 = 1;
        }
        else if (num1 == 58)
        {
          num4 = 0.85f;
          num2 = 0.85f;
        }
        else if (num1 == 26)
        {
          num7 = 0.85f;
          num2 = 1.1f;
        }
        else if (num1 == 27)
          num7 = 0.85f;
        else if (num1 == 28)
        {
          num7 = 0.85f;
          num2 = 1.15f;
          num3 = 1.05f;
        }
        else if (num1 == 83)
        {
          num3 = 1.15f;
          num2 = 1.15f;
          num8 = 5;
          num4 = 0.9f;
          num7 = 0.9f;
        }
        else if (num1 == 29)
          num7 = 1.1f;
        else if (num1 == 30)
        {
          num7 = 1.2f;
          num2 = 0.9f;
        }
        else if (num1 == 31)
        {
          num3 = 0.9f;
          num2 = 0.9f;
        }
        else if (num1 == 32)
        {
          num7 = 1.15f;
          num2 = 1.1f;
        }
        else if (num1 == 33)
        {
          num7 = 1.1f;
          num3 = 1.1f;
          num4 = 0.9f;
        }
        else if (num1 == 34)
        {
          num7 = 0.9f;
          num3 = 1.1f;
          num4 = 1.1f;
          num2 = 1.1f;
        }
        else if (num1 == 35)
        {
          num7 = 1.2f;
          num2 = 1.15f;
          num3 = 1.15f;
        }
        else if (num1 == 52)
        {
          num7 = 0.9f;
          num2 = 0.9f;
          num4 = 0.9f;
        }
        else if (num1 == 36)
          num8 = 3;
        else if (num1 == 37)
        {
          num2 = 1.1f;
          num8 = 3;
          num3 = 1.1f;
        }
        else if (num1 == 38)
          num3 = 1.15f;
        else if (num1 == 53)
          num2 = 1.1f;
        else if (num1 == 54)
          num3 = 1.15f;
        else if (num1 == 55)
        {
          num3 = 1.15f;
          num2 = 1.05f;
        }
        else if (num1 == 59)
        {
          num3 = 1.15f;
          num2 = 1.15f;
          num8 = 5;
        }
        else if (num1 == 60)
        {
          num2 = 1.15f;
          num8 = 5;
        }
        else if (num1 == 61)
          num8 = 5;
        else if (num1 == 39)
        {
          num2 = 0.7f;
          num3 = 0.8f;
        }
        else if (num1 == 40)
          num2 = 0.85f;
        else if (num1 == 56)
          num3 = 0.8f;
        else if (num1 == 41)
        {
          num3 = 0.85f;
          num2 = 0.9f;
        }
        else if (num1 == 57)
        {
          num3 = 0.9f;
          num2 = 1.18f;
        }
        else if (num1 == 42)
          num4 = 0.9f;
        else if (num1 == 43)
        {
          num2 = 1.1f;
          num4 = 0.9f;
        }
        else if (num1 == 44)
        {
          num4 = 0.9f;
          num8 = 3;
        }
        else if (num1 == 45)
          num4 = 0.95f;
        else if (num1 == 46)
        {
          num8 = 3;
          num4 = 0.94f;
          num2 = 1.07f;
        }
        else if (num1 == 47)
          num4 = 1.15f;
        else if (num1 == 48)
          num4 = 1.2f;
        else if (num1 == 49)
          num4 = 1.08f;
        else if (num1 == 50)
        {
          num2 = 0.8f;
          num4 = 1.15f;
        }
        else if (num1 == 51)
        {
          num3 = 0.9f;
          num4 = 0.9f;
          num2 = 1.05f;
          num8 = 2;
        }
        if ((double) num2 != 1.0 && Math.Round((double) this.damage * (double) num2) == (double) this.damage)
        {
          flag = true;
          num1 = -1;
        }
        if ((double) num4 != 1.0 && Math.Round((double) this.useAnimation * (double) num4) == (double) this.useAnimation)
        {
          flag = true;
          num1 = -1;
        }
        if ((double) num7 != 1.0 && Math.Round((double) this.mana * (double) num7) == (double) this.mana)
        {
          flag = true;
          num1 = -1;
        }
        if ((double) num3 != 1.0 && (double) this.knockBack == 0.0)
        {
          flag = true;
          num1 = -1;
        }
        if (pre == -2 && num1 == 0)
        {
          num1 = -1;
          flag = true;
        }
      }
      this.damage = (short) Math.Round((double) this.damage * (double) num2);
      this.useAnimation = (byte) Math.Round((double) this.useAnimation * (double) num4);
      this.useTime = (byte) Math.Round((double) this.useTime * (double) num4);
      this.reuseDelay = (byte) Math.Round((double) this.reuseDelay * (double) num4);
      this.mana = (byte) Math.Round((double) this.mana * (double) num7);
      this.knockBack *= num3;
      this.scale *= num5;
      this.shootSpeed *= num6;
      this.crit += (short) num8;
      float num9 = (float) ((double) num2 * (2.0 - (double) num4) * (2.0 - (double) num7) * (double) num5 * (double) num3 * (double) num6 * (1.0 + (double) this.crit * 0.0199999995529652));
      if (num1 == 62 || num1 == 69 || (num1 == 73 || num1 == 77))
        num9 *= 1.05f;
      else if (num1 == 63 || num1 == 70 || (num1 == 74 || num1 == 78) || num1 == 67)
        num9 *= 1.1f;
      else if (num1 == 64 || num1 == 71 || (num1 == 75 || num1 == 79) || num1 == 66)
        num9 *= 1.15f;
      else if (num1 == 65 || num1 == 72 || (num1 == 76 || num1 == 80) || num1 == 68)
        num9 *= 1.2f;
      this.prefix = (byte) num1;
      if ((double) num9 >= 1.20000004768372)
        this.rare += (sbyte) 2;
      else if ((double) num9 >= 1.04999995231628)
        ++this.rare;
      else if ((double) num9 <= 0.800000011920929)
        this.rare -= (sbyte) 2;
      else if ((double) num9 <= 0.949999988079071)
        --this.rare;
      if ((int) this.rare < -1)
        this.rare = (sbyte) -1;
      else if ((int) this.rare > 6)
        this.rare = (sbyte) 6;
      this.value = (int) ((double) this.value * (double) (num9 * num9));
      return true;
    }

    public string Name()
    {
      return Lang.itemName((int) this.netID);
    }

    public string AffixName()
    {
      return Lang.itemAffixName((int) this.prefix, (int) this.netID);
    }

    public void SetDefaults(string ItemName)
    {
      bool flag = false;
      if (ItemName == "Gold Pickaxe")
      {
        this.SetDefaults(1, 1, false);
        this.color = new Color(210, 190, 0, 100);
        this.useTime = (byte) 17;
        this.pick = (byte) 55;
        this.useAnimation = (byte) 20;
        this.scale = 1.05f;
        this.damage = (short) 6;
        this.value = 10000;
        this.netID = (short) -1;
      }
      else if (ItemName == "Gold Broadsword")
      {
        this.SetDefaults(4, 1, false);
        this.color = new Color(210, 190, 0, 100);
        this.useAnimation = (byte) 20;
        this.damage = (short) 13;
        this.scale = 1.05f;
        this.value = 9000;
        this.netID = (short) -2;
      }
      else if (ItemName == "Gold Shortsword")
      {
        this.SetDefaults(6, 1, false);
        this.color = new Color(210, 190, 0, 100);
        this.damage = (short) 11;
        this.useAnimation = (byte) 11;
        this.scale = 0.95f;
        this.value = 7000;
        this.netID = (short) -3;
      }
      else if (ItemName == "Gold Axe")
      {
        this.SetDefaults(10, 1, false);
        this.color = new Color(210, 190, 0, 100);
        this.useTime = (byte) 18;
        this.axe = (byte) 11;
        this.useAnimation = (byte) 26;
        this.scale = 1.15f;
        this.damage = (short) 7;
        this.value = 8000;
        this.netID = (short) -4;
      }
      else if (ItemName == "Gold Hammer")
      {
        this.SetDefaults(7, 1, false);
        this.color = new Color(210, 190, 0, 100);
        this.useAnimation = (byte) 28;
        this.useTime = (byte) 23;
        this.scale = 1.25f;
        this.damage = (short) 9;
        this.hammer = (byte) 55;
        this.value = 8000;
        this.netID = (short) -5;
      }
      else if (ItemName == "Gold Bow")
      {
        this.SetDefaults(99, 1, false);
        this.useAnimation = (byte) 26;
        this.useTime = (byte) 26;
        this.color = new Color(210, 190, 0, 100);
        this.damage = (short) 11;
        this.value = 7000;
        this.netID = (short) -6;
      }
      else if (ItemName == "Silver Pickaxe")
      {
        this.SetDefaults(1, 1, false);
        this.color = new Color(180, 180, 180, 100);
        this.useTime = (byte) 11;
        this.pick = (byte) 45;
        this.useAnimation = (byte) 19;
        this.scale = 1.05f;
        this.damage = (short) 6;
        this.value = 5000;
        this.netID = (short) -7;
      }
      else if (ItemName == "Silver Broadsword")
      {
        this.SetDefaults(4, 1, false);
        this.color = new Color(180, 180, 180, 100);
        this.useAnimation = (byte) 21;
        this.damage = (short) 11;
        this.value = 4500;
        this.netID = (short) -8;
      }
      else if (ItemName == "Silver Shortsword")
      {
        this.SetDefaults(6, 1, false);
        this.color = new Color(180, 180, 180, 100);
        this.damage = (short) 9;
        this.useAnimation = (byte) 12;
        this.scale = 0.95f;
        this.value = 3500;
        this.netID = (short) -9;
      }
      else if (ItemName == "Silver Axe")
      {
        this.SetDefaults(10, 1, false);
        this.color = new Color(180, 180, 180, 100);
        this.useTime = (byte) 18;
        this.axe = (byte) 10;
        this.useAnimation = (byte) 26;
        this.scale = 1.15f;
        this.damage = (short) 6;
        this.value = 4000;
        this.netID = (short) -10;
      }
      else if (ItemName == "Silver Hammer")
      {
        this.SetDefaults(7, 1, false);
        this.color = new Color(180, 180, 180, 100);
        this.useAnimation = (byte) 29;
        this.useTime = (byte) 19;
        this.scale = 1.25f;
        this.damage = (short) 9;
        this.hammer = (byte) 45;
        this.value = 4000;
        this.netID = (short) -11;
      }
      else if (ItemName == "Silver Bow")
      {
        this.SetDefaults(99, 1, false);
        this.useAnimation = (byte) 27;
        this.useTime = (byte) 27;
        this.color = new Color(180, 180, 180, 100);
        this.damage = (short) 9;
        this.value = 3500;
        this.netID = (short) -12;
      }
      else if (ItemName == "Copper Pickaxe")
      {
        this.SetDefaults(1, 1, false);
        this.color = new Color(180, 100, 45, 80);
        this.useTime = (byte) 15;
        this.pick = (byte) 35;
        this.useAnimation = (byte) 23;
        this.damage = (short) 4;
        this.scale = 0.9f;
        this.tileBoost = (sbyte) -1;
        this.value = 500;
        this.netID = (short) -13;
      }
      else if (ItemName == "Copper Broadsword")
      {
        this.SetDefaults(4, 1, false);
        this.color = new Color(180, 100, 45, 80);
        this.useAnimation = (byte) 23;
        this.damage = (short) 8;
        this.value = 450;
        this.netID = (short) -14;
      }
      else if (ItemName == "Copper Shortsword")
      {
        this.SetDefaults(6, 1, false);
        this.color = new Color(180, 100, 45, 80);
        this.damage = (short) 5;
        this.useAnimation = (byte) 13;
        this.scale = 0.8f;
        this.value = 350;
        this.netID = (short) -15;
      }
      else if (ItemName == "Copper Axe")
      {
        this.SetDefaults(10, 1, false);
        this.color = new Color(180, 100, 45, 80);
        this.useTime = (byte) 21;
        this.axe = (byte) 7;
        this.useAnimation = (byte) 30;
        this.scale = 1f;
        this.damage = (short) 3;
        this.tileBoost = (sbyte) -1;
        this.value = 400;
        this.netID = (short) -16;
      }
      else if (ItemName == "Copper Hammer")
      {
        this.SetDefaults(7, 1, false);
        this.color = new Color(180, 100, 45, 80);
        this.useAnimation = (byte) 33;
        this.useTime = (byte) 23;
        this.scale = 1.1f;
        this.damage = (short) 4;
        this.hammer = (byte) 35;
        this.tileBoost = (sbyte) -1;
        this.value = 400;
        this.netID = (short) -17;
      }
      else if (ItemName == "Copper Bow")
      {
        this.SetDefaults(99, 1, false);
        this.useAnimation = (byte) 29;
        this.useTime = (byte) 29;
        this.color = new Color(180, 100, 45, 80);
        this.damage = (short) 6;
        this.value = 350;
        this.netID = (short) -18;
      }
      else if (ItemName == "Blue Phasesaber")
      {
        this.SetDefaults(198, 1, false);
        this.damage = (short) 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = (sbyte) 4;
        this.netID = (short) -19;
      }
      else if (ItemName == "Red Phasesaber")
      {
        this.SetDefaults(199, 1, false);
        this.damage = (short) 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = (sbyte) 4;
        this.netID = (short) -20;
      }
      else if (ItemName == "Green Phasesaber")
      {
        this.SetDefaults(200, 1, false);
        this.damage = (short) 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = (sbyte) 4;
        this.netID = (short) -21;
      }
      else if (ItemName == "Purple Phasesaber")
      {
        this.SetDefaults(201, 1, false);
        this.damage = (short) 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = (sbyte) 4;
        this.netID = (short) -22;
      }
      else if (ItemName == "White Phasesaber")
      {
        this.SetDefaults(202, 1, false);
        this.damage = (short) 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = (sbyte) 4;
        this.netID = (short) -23;
      }
      else if (ItemName == "Yellow Phasesaber")
      {
        this.SetDefaults(203, 1, false);
        this.damage = (short) 41;
        this.scale = 1.15f;
        flag = true;
        this.autoReuse = true;
        this.useTurn = true;
        this.rare = (sbyte) 4;
        this.netID = (short) -24;
      }
      if (flag)
        this.material = false;
      else
        this.checkMat();
    }

    public bool checkMat()
    {
      if (this.CanBePlacedInCoinSlot())
      {
        this.material = false;
        return false;
      }
      else
      {
        int index1 = 0;
label_8:
        if (index1 < Recipe.numRecipes)
        {
          int index2 = (int) Main.recipe[index1].numRequiredItems - 1;
          while ((int) this.netID != (int) Main.recipe[index1].requiredItem[index2].netID)
          {
            if (--index2 < 0)
            {
              ++index1;
              goto label_8;
            }
          }
          this.material = true;
          return true;
        }
        else
        {
          this.material = false;
          return false;
        }
      }
    }

    public void netDefaults(int Type, int Stack = 1)
    {
      if (Type < 0)
      {
        if (Type == -1)
          this.SetDefaults("Gold Pickaxe");
        else if (Type == -2)
          this.SetDefaults("Gold Broadsword");
        else if (Type == -3)
          this.SetDefaults("Gold Shortsword");
        else if (Type == -4)
          this.SetDefaults("Gold Axe");
        else if (Type == -5)
          this.SetDefaults("Gold Hammer");
        else if (Type == -6)
          this.SetDefaults("Gold Bow");
        else if (Type == -7)
          this.SetDefaults("Silver Pickaxe");
        else if (Type == -8)
          this.SetDefaults("Silver Broadsword");
        else if (Type == -9)
          this.SetDefaults("Silver Shortsword");
        else if (Type == -10)
          this.SetDefaults("Silver Axe");
        else if (Type == -11)
          this.SetDefaults("Silver Hammer");
        else if (Type == -12)
          this.SetDefaults("Silver Bow");
        else if (Type == -13)
          this.SetDefaults("Copper Pickaxe");
        else if (Type == -14)
          this.SetDefaults("Copper Broadsword");
        else if (Type == -15)
          this.SetDefaults("Copper Shortsword");
        else if (Type == -16)
          this.SetDefaults("Copper Axe");
        else if (Type == -17)
          this.SetDefaults("Copper Hammer");
        else if (Type == -18)
          this.SetDefaults("Copper Bow");
        else if (Type == -19)
          this.SetDefaults("Blue Phasesaber");
        else if (Type == -20)
          this.SetDefaults("Red Phasesaber");
        else if (Type == -21)
          this.SetDefaults("Green Phasesaber");
        else if (Type == -22)
          this.SetDefaults("Purple Phasesaber");
        else if (Type == -23)
        {
          this.SetDefaults("White Phasesaber");
        }
        else
        {
          if (Type != -24)
            return;
          this.SetDefaults("Yellow Phasesaber");
        }
      }
      else
        this.SetDefaults(Type, Stack, false);
    }

    public void SetDefaults(int Type, int Stack = 1, bool noMatCheck = false)
    {
      this.active = (byte) 1;
      this.owner = (byte) 8;
      this.type = (short) Type;
      this.netID = (short) Type;
      this.prefix = (byte) 0;
      this.crit = (short) 0;
      this.wornArmor = false;
      this.mech = false;
      this.reuseDelay = (byte) 0;
      this.melee = false;
      this.magic = false;
      this.ranged = false;
      this.placeStyle = (byte) 0;
      this.buffTime = (ushort) 0;
      this.buffType = (byte) 0;
      this.material = false;
      this.noWet = false;
      this.vanity = false;
      this.mana = (byte) 0;
      this.wet = false;
      this.wetCount = (byte) 0;
      this.lavaWet = false;
      this.channel = false;
      this.buyOnce = false;
      this.social = false;
      this.release = (ushort) 0;
      this.noMelee = false;
      this.noUseGraphic = false;
      this.lifeRegen = (byte) 0;
      this.shootSpeed = 0.0f;
      this.alpha = (byte) 0;
      this.ammo = (byte) 0;
      this.useAmmo = (byte) 0;
      this.autoReuse = false;
      this.accessory = false;
      this.axe = (byte) 0;
      this.healMana = (short) 0;
      this.bodySlot = (short) -1;
      this.legSlot = (short) -1;
      this.headSlot = (short) -1;
      this.potion = false;
      this.color = new Color();
      this.consumable = false;
      this.createTile = (short) -1;
      this.createWall = (short) -1;
      this.damage = (short) 0;
      this.defense = (short) 0;
      this.hammer = (byte) 0;
      this.healLife = (short) 0;
      this.knockBack = 0.0f;
      this.pick = (byte) 0;
      this.rare = (sbyte) 0;
      this.scale = 1f;
      this.shoot = (byte) 0;
      this.stack = (short) Stack;
      this.maxStack = (short) Stack;
      this.tileBoost = (sbyte) 0;
      this.holdStyle = (byte) 0;
      this.useStyle = (byte) 0;
      this.useSound = (byte) 0;
      this.useTime = (byte) 100;
      this.useAnimation = (byte) 100;
      this.value = 0;
      this.useTurn = false;
      this.buy = false;
      this.ownIgnore = (byte) 8;
      this.ownTime = (byte) 0;
      this.keepTime = (byte) 0;
      switch (Type)
      {
        case 1:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 13;
          this.autoReuse = true;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 5;
          this.pick = (byte) 40;
          this.useSound = (byte) 1;
          this.knockBack = 2f;
          this.value = 2000;
          this.melee = true;
          break;
        case 2:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 0;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 3:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 1;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 4:
          this.useStyle = (byte) 1;
          this.useTurn = false;
          this.useAnimation = (byte) 21;
          this.useTime = (byte) 21;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 10;
          this.knockBack = 5f;
          this.useSound = (byte) 1;
          this.scale = 1f;
          this.value = 1800;
          this.melee = true;
          break;
        case 5:
          this.useStyle = (byte) 2;
          this.useSound = (byte) 2;
          this.useTurn = false;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.width = (ushort) 16;
          this.height = (ushort) 18;
          this.healLife = (short) 15;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.potion = true;
          this.value = 25;
          break;
        case 6:
          this.useStyle = (byte) 3;
          this.useTurn = false;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 8;
          this.knockBack = 4f;
          this.scale = 0.9f;
          this.useSound = (byte) 1;
          this.useTurn = true;
          this.value = 1400;
          this.melee = true;
          break;
        case 7:
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 30;
          this.useTime = (byte) 20;
          this.hammer = (byte) 45;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 7;
          this.knockBack = 5.5f;
          this.scale = 1.2f;
          this.useSound = (byte) 1;
          this.value = 1600;
          this.melee = true;
          break;
        case 8:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 50;
          break;
        case 9:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 30;
          this.width = (ushort) 8;
          this.height = (ushort) 10;
          break;
        case 10:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 27;
          this.knockBack = 4.5f;
          this.useTime = (byte) 19;
          this.autoReuse = true;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 5;
          this.axe = (byte) 9;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.value = 1600;
          this.melee = true;
          break;
        case 11:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 6;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 500;
          break;
        case 12:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 7;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 250;
          break;
        case 13:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 8;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 2000;
          break;
        case 14:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 9;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 1000;
          break;
        case 15:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.accessory = true;
          this.value = 1000;
          break;
        case 16:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.accessory = true;
          this.value = 5000;
          break;
        case 17:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.accessory = true;
          this.rare = (sbyte) 1;
          this.value = 10000;
          break;
        case 18:
          this.width = (ushort) 24;
          this.height = (ushort) 18;
          this.accessory = true;
          this.rare = (sbyte) 1;
          this.value = 10000;
          break;
        case 19:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 6000;
          break;
        case 20:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 750;
          break;
        case 21:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 3000;
          break;
        case 22:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 1500;
          break;
        case 23:
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.maxStack = (short) 250;
          this.alpha = (byte) 175;
          this.ammo = (byte) 23;
          this.color = new Color(0, 80, (int) byte.MaxValue, 100);
          this.value = 5;
          break;
        case 24:
          this.useStyle = (byte) 1;
          this.useTurn = false;
          this.useAnimation = (byte) 25;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 7;
          this.knockBack = 4f;
          this.scale = 0.95f;
          this.useSound = (byte) 1;
          this.value = 100;
          this.melee = true;
          break;
        case 25:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 10;
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.value = 200;
          break;
        case 26:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 1;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 27:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 20;
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.value = 10;
          break;
        case 28:
          this.useSound = (byte) 3;
          this.healLife = (short) 50;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.potion = true;
          this.value = 300;
          break;
        case 29:
          this.maxStack = (short) 99;
          this.consumable = true;
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.useStyle = (byte) 4;
          this.useTime = (byte) 30;
          this.useSound = (byte) 4;
          this.useAnimation = (byte) 30;
          this.rare = (sbyte) 2;
          this.value = 75000;
          break;
        case 30:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 16;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 31:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 13;
          this.width = (ushort) 16;
          this.height = (ushort) 24;
          this.value = 20;
          break;
        case 32:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 14;
          this.width = (ushort) 26;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 33:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 17;
          this.width = (ushort) 26;
          this.height = (ushort) 24;
          this.value = 300;
          break;
        case 34:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 15;
          this.width = (ushort) 12;
          this.height = (ushort) 30;
          this.value = 150;
          break;
        case 35:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 16;
          this.width = (ushort) 28;
          this.height = (ushort) 14;
          this.value = 5000;
          break;
        case 36:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 18;
          this.width = (ushort) 28;
          this.height = (ushort) 14;
          this.value = 150;
          break;
        case 37:
          this.width = (ushort) 28;
          this.height = (ushort) 12;
          this.defense = (short) 1;
          this.headSlot = (short) 10;
          this.rare = (sbyte) 1;
          this.value = 1000;
          break;
        case 38:
          this.width = (ushort) 12;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 500;
          break;
        case 39:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 30;
          this.useTime = (byte) 30;
          this.width = (ushort) 12;
          this.height = (ushort) 28;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 4;
          this.shootSpeed = 6.1f;
          this.noMelee = true;
          this.value = 100;
          this.ranged = true;
          break;
        case 40:
          this.shootSpeed = 3f;
          this.shoot = (byte) 1;
          this.damage = (short) 4;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 2f;
          this.value = 10;
          this.ranged = true;
          break;
        case 41:
          this.shootSpeed = 3.5f;
          this.shoot = (byte) 2;
          this.damage = (short) 6;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 2f;
          this.value = 15;
          this.ranged = true;
          break;
        case 42:
          this.useStyle = (byte) 1;
          this.shootSpeed = 9f;
          this.shoot = (byte) 3;
          this.damage = (short) 10;
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 20;
          this.ranged = true;
          break;
        case 43:
          this.useStyle = (byte) 4;
          this.width = (ushort) 22;
          this.height = (ushort) 14;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.maxStack = (short) 20;
          break;
        case 44:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.width = (ushort) 12;
          this.height = (ushort) 28;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 14;
          this.shootSpeed = 6.7f;
          this.knockBack = 1f;
          this.alpha = (byte) 30;
          this.rare = (sbyte) 1;
          this.noMelee = true;
          this.value = 18000;
          this.ranged = true;
          break;
        case 45:
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 30;
          this.knockBack = 6f;
          this.useTime = (byte) 15;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 20;
          this.axe = (byte) 15;
          this.scale = 1.2f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 1;
          this.value = 13500;
          this.melee = true;
          break;
        case 46:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 20;
          this.knockBack = 5f;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 17;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 1;
          this.value = 13500;
          this.melee = true;
          break;
        case 47:
          this.shootSpeed = 3.4f;
          this.shoot = (byte) 4;
          this.damage = (short) 8;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 3f;
          this.alpha = (byte) 30;
          this.rare = (sbyte) 1;
          this.value = 40;
          this.ranged = true;
          break;
        case 48:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 21;
          this.width = (ushort) 26;
          this.height = (ushort) 22;
          this.value = 500;
          break;
        case 49:
          this.width = (ushort) 22;
          this.height = (ushort) 22;
          this.accessory = true;
          this.lifeRegen = (byte) 1;
          this.rare = (sbyte) 1;
          this.value = 50000;
          break;
        case 50:
          this.mana = (byte) 20;
          this.useTurn = true;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.useStyle = (byte) 4;
          this.useTime = (byte) 90;
          this.useSound = (byte) 6;
          this.useAnimation = (byte) 90;
          this.rare = (sbyte) 1;
          this.value = 50000;
          break;
        case 51:
          this.shootSpeed = 0.5f;
          this.shoot = (byte) 5;
          this.damage = (short) 9;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 4f;
          this.rare = (sbyte) 1;
          this.value = 100;
          this.ranged = true;
          break;
        case 52:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 1;
          break;
        case 53:
          this.width = (ushort) 16;
          this.height = (ushort) 24;
          this.accessory = true;
          this.rare = (sbyte) 1;
          this.value = 50000;
          break;
        case 54:
          this.width = (ushort) 28;
          this.height = (ushort) 24;
          this.accessory = true;
          this.rare = (sbyte) 1;
          this.value = 50000;
          break;
        case 55:
          this.noMelee = true;
          this.useStyle = (byte) 1;
          this.shootSpeed = 10f;
          this.shoot = (byte) 6;
          this.damage = (short) 13;
          this.knockBack = 8f;
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.rare = (sbyte) 1;
          this.value = 50000;
          this.melee = true;
          break;
        case 56:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 22;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.rare = (sbyte) 1;
          this.value = 4000;
          break;
        case 57:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.rare = (sbyte) 1;
          this.value = 16000;
          break;
        case 58:
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 59:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 23;
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.value = 500;
          break;
        case 60:
          this.width = (ushort) 16;
          this.height = (ushort) 18;
          this.maxStack = (short) 99;
          this.value = 50;
          break;
        case 61:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 25;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 62:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 2;
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.value = 20;
          break;
        case 63:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 27;
          this.width = (ushort) 26;
          this.height = (ushort) 26;
          this.value = 200;
          break;
        case 64:
          this.mana = (byte) 12;
          this.damage = (short) 8;
          this.useStyle = (byte) 1;
          this.shootSpeed = 32f;
          this.shoot = (byte) 7;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 8;
          this.useAnimation = (byte) 30;
          this.useTime = (byte) 30;
          this.rare = (sbyte) 1;
          this.noMelee = true;
          this.knockBack = 1f;
          this.value = 10000;
          this.magic = true;
          break;
        case 65:
          this.autoReuse = true;
          this.mana = (byte) 16;
          this.knockBack = 5f;
          this.alpha = (byte) 100;
          this.color = new Color(150, 150, 150, 0);
          this.damage = (short) 16;
          this.useStyle = (byte) 1;
          this.scale = 1.15f;
          this.shootSpeed = 12f;
          this.shoot = (byte) 9;
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.useSound = (byte) 9;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 10;
          this.rare = (sbyte) 1;
          this.value = 50000;
          this.magic = true;
          break;
        case 66:
          this.useStyle = (byte) 1;
          this.shootSpeed = 4f;
          this.shoot = (byte) 10;
          this.width = (ushort) 16;
          this.height = (ushort) 24;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noMelee = true;
          this.value = 75;
          break;
        case 67:
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shootSpeed = 4f;
          this.shoot = (byte) 11;
          this.width = (ushort) 16;
          this.height = (ushort) 24;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noMelee = true;
          this.value = 100;
          break;
        case 68:
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 10;
          break;
        case 69:
          this.width = (ushort) 8;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 100;
          break;
        case 70:
          this.useStyle = (byte) 4;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.width = (ushort) 28;
          this.height = (ushort) 28;
          this.maxStack = (short) 20;
          break;
        case 71:
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.maxStack = (short) 100;
          this.value = 5;
          break;
        case 72:
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.maxStack = (short) 100;
          this.value = 500;
          break;
        case 73:
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.maxStack = (short) 100;
          this.value = 50000;
          break;
        case 74:
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.maxStack = (short) 100;
          this.value = 5000000;
          break;
        case 75:
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 100;
          this.alpha = (byte) 75;
          this.ammo = (byte) 15;
          this.value = 500;
          this.useStyle = (byte) 4;
          this.useSound = (byte) 4;
          this.useTurn = false;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.consumable = true;
          this.rare = (sbyte) 1;
          break;
        case 76:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 1;
          this.legSlot = (short) 1;
          this.value = 750;
          break;
        case 77:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 2;
          this.legSlot = (short) 2;
          this.value = 3000;
          break;
        case 78:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 3;
          this.legSlot = (short) 3;
          this.value = 7500;
          break;
        case 79:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.legSlot = (short) 4;
          this.value = 15000;
          break;
        case 80:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 2;
          this.bodySlot = (short) 1;
          this.value = 1000;
          break;
        case 81:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 3;
          this.bodySlot = (short) 2;
          this.value = 4000;
          break;
        case 82:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.bodySlot = (short) 3;
          this.value = 10000;
          break;
        case 83:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 5;
          this.bodySlot = (short) 4;
          this.value = 20000;
          break;
        case 84:
          this.noUseGraphic = true;
          this.damage = (short) 0;
          this.knockBack = 7f;
          this.useStyle = (byte) 5;
          this.shootSpeed = 11f;
          this.shoot = (byte) 13;
          this.width = (ushort) 18;
          this.height = (ushort) 28;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 1;
          this.noMelee = true;
          this.value = 20000;
          break;
        case 85:
          this.width = (ushort) 14;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 1000;
          break;
        case 86:
          this.width = (ushort) 14;
          this.height = (ushort) 18;
          this.maxStack = (short) 99;
          this.rare = (sbyte) 1;
          this.value = 500;
          break;
        case 87:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 29;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.value = 10000;
          break;
        case 88:
          this.width = (ushort) 22;
          this.height = (ushort) 16;
          this.defense = (short) 1;
          this.headSlot = (short) 11;
          this.rare = (sbyte) 1;
          this.value = 80000;
          break;
        case 89:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 1;
          this.headSlot = (short) 1;
          this.value = 1250;
          break;
        case 90:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 2;
          this.headSlot = (short) 2;
          this.value = 5000;
          break;
        case 91:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 3;
          this.headSlot = (short) 3;
          this.value = 12500;
          break;
        case 92:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.headSlot = (short) 4;
          this.value = 25000;
          break;
        case 93:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 4;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 94:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 19;
          this.width = (ushort) 8;
          this.height = (ushort) 10;
          break;
        case 95:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 16;
          this.useTime = (byte) 16;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.shoot = (byte) 14;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 11;
          this.damage = (short) 10;
          this.shootSpeed = 5f;
          this.noMelee = true;
          this.value = 50000;
          this.scale = 0.9f;
          this.rare = (sbyte) 1;
          this.ranged = true;
          break;
        case 96:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 43;
          this.useTime = (byte) 43;
          this.width = (ushort) 44;
          this.height = (ushort) 14;
          this.shoot = (byte) 10;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 11;
          this.damage = (short) 23;
          this.shootSpeed = 8f;
          this.noMelee = true;
          this.value = 100000;
          this.knockBack = 4f;
          this.rare = (sbyte) 1;
          this.ranged = true;
          break;
        case 97:
          this.shootSpeed = 4f;
          this.shoot = (byte) 14;
          this.damage = (short) 7;
          this.width = (ushort) 8;
          this.height = (ushort) 8;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 14;
          this.knockBack = 2f;
          this.value = 7;
          this.ranged = true;
          break;
        case 98:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 8;
          this.useTime = (byte) 8;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 10;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 11;
          this.damage = (short) 6;
          this.shootSpeed = 7f;
          this.noMelee = true;
          this.value = 350000;
          this.rare = (sbyte) 2;
          this.ranged = true;
          break;
        case 99:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 28;
          this.useTime = (byte) 28;
          this.width = (ushort) 12;
          this.height = (ushort) 28;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 8;
          this.shootSpeed = 6.6f;
          this.noMelee = true;
          this.value = 1400;
          this.ranged = true;
          break;
        case 100:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 6;
          this.legSlot = (short) 5;
          this.rare = (sbyte) 1;
          this.value = 22500;
          break;
        case 101:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 7;
          this.bodySlot = (short) 5;
          this.rare = (sbyte) 1;
          this.value = 30000;
          break;
        case 102:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 6;
          this.headSlot = (short) 5;
          this.rare = (sbyte) 1;
          this.value = 37500;
          break;
        case 103:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 15;
          this.autoReuse = true;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 9;
          this.pick = (byte) 65;
          this.useSound = (byte) 1;
          this.knockBack = 3f;
          this.rare = (sbyte) 1;
          this.value = 18000;
          this.scale = 1.15f;
          this.melee = true;
          break;
        case 104:
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 19;
          this.hammer = (byte) 55;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 24;
          this.knockBack = 6f;
          this.scale = 1.3f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 1;
          this.value = 15000;
          this.melee = true;
          break;
        case 105:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 33;
          this.width = (ushort) 8;
          this.height = (ushort) 18;
          this.holdStyle = (byte) 1;
          break;
        case 106:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 34;
          this.width = (ushort) 26;
          this.height = (ushort) 26;
          break;
        case 107:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 35;
          this.width = (ushort) 26;
          this.height = (ushort) 26;
          break;
        case 108:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 36;
          this.width = (ushort) 26;
          this.height = (ushort) 26;
          break;
        case 109:
          this.maxStack = (short) 99;
          this.consumable = true;
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.useStyle = (byte) 4;
          this.useTime = (byte) 30;
          this.useSound = (byte) 29;
          this.useAnimation = (byte) 30;
          this.rare = (sbyte) 2;
          break;
        case 110:
          this.useSound = (byte) 3;
          this.healMana = (short) 50;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 20;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.value = 100;
          break;
        case 111:
          this.width = (ushort) 22;
          this.height = (ushort) 22;
          this.accessory = true;
          this.rare = (sbyte) 1;
          this.value = 50000;
          break;
        case 112:
          this.mana = (byte) 17;
          this.damage = (short) 44;
          this.useStyle = (byte) 1;
          this.shootSpeed = 6f;
          this.shoot = (byte) 15;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 20;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.knockBack = 5.5f;
          this.value = 10000;
          this.magic = true;
          break;
        case 113:
          this.mana = (byte) 10;
          this.channel = true;
          this.damage = (short) 22;
          this.useStyle = (byte) 1;
          this.shootSpeed = 6f;
          this.shoot = (byte) 16;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 9;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.rare = (sbyte) 2;
          this.noMelee = true;
          this.knockBack = 5f;
          this.tileBoost = (sbyte) 64;
          this.value = 10000;
          this.magic = true;
          break;
        case 114:
          this.mana = (byte) 5;
          this.channel = true;
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 17;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 8;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 1;
          this.noMelee = true;
          this.knockBack = 5f;
          this.value = 200000;
          break;
        case 115:
          this.mana = (byte) 40;
          this.channel = true;
          this.damage = (short) 0;
          this.useStyle = (byte) 4;
          this.shoot = (byte) 18;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.useSound = (byte) 8;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 1;
          this.noMelee = true;
          this.value = 10000;
          this.buffType = (byte) 19;
          this.buffTime = (ushort) 18000;
          break;
        case 116:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 37;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 1000;
          break;
        case 117:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.rare = (sbyte) 1;
          this.value = 7000;
          break;
        case 118:
          this.maxStack = (short) 99;
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.value = 1000;
          break;
        case 119:
          this.noMelee = true;
          this.useStyle = (byte) 1;
          this.shootSpeed = 11f;
          this.shoot = (byte) 19;
          this.damage = (short) 32;
          this.knockBack = 8f;
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.rare = (sbyte) 3;
          this.value = 100000;
          this.melee = true;
          break;
        case 120:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.width = (ushort) 14;
          this.height = (ushort) 32;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 29;
          this.shootSpeed = 8f;
          this.knockBack = 2f;
          this.alpha = (byte) 30;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.scale = 1.1f;
          this.value = 27000;
          this.ranged = true;
          break;
        case 121:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 34;
          this.knockBack = 6.5f;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 36;
          this.scale = 1.3f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 3;
          this.value = 27000;
          this.melee = true;
          break;
        case 122:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.autoReuse = true;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 12;
          this.pick = (byte) 100;
          this.scale = 1.15f;
          this.useSound = (byte) 1;
          this.knockBack = 2f;
          this.rare = (sbyte) 3;
          this.value = 27000;
          this.melee = true;
          break;
        case 123:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 3;
          this.headSlot = (short) 6;
          this.rare = (sbyte) 1;
          this.value = 45000;
          break;
        case 124:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.bodySlot = (short) 6;
          this.rare = (sbyte) 1;
          this.value = 30000;
          break;
        case 125:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 3;
          this.legSlot = (short) 6;
          this.rare = (sbyte) 1;
          this.value = 30000;
          break;
        case 126:
          this.useSound = (byte) 3;
          this.healLife = (short) 20;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.potion = true;
          this.value = 20;
          break;
        case (int) sbyte.MaxValue:
          this.autoReuse = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 19;
          this.useTime = (byte) 19;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.shoot = (byte) 20;
          this.mana = (byte) 8;
          this.useSound = (byte) 12;
          this.knockBack = 0.5f;
          this.damage = (short) 17;
          this.shootSpeed = 10f;
          this.noMelee = true;
          this.scale = 0.8f;
          this.rare = (sbyte) 1;
          this.magic = true;
          this.value = 20000;
          break;
        case 128:
          this.width = (ushort) 28;
          this.height = (ushort) 24;
          this.accessory = true;
          this.rare = (sbyte) 3;
          this.value = 50000;
          break;
        case 129:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 38;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 130:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 5;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 131:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 39;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 132:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 6;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 133:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 40;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 134:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 41;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 135:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 17;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 136:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 42;
          this.width = (ushort) 12;
          this.height = (ushort) 28;
          break;
        case 137:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 43;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 138:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 18;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 139:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 44;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 140:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 19;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 141:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 45;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 142:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 10;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 143:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 46;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 144:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 11;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 145:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 47;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 146:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 12;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 147:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 48;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 148:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 49;
          this.width = (ushort) 8;
          this.height = (ushort) 18;
          this.holdStyle = (byte) 1;
          break;
        case 149:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 50;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          break;
        case 150:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 51;
          this.width = (ushort) 20;
          this.height = (ushort) 24;
          this.alpha = (byte) 100;
          break;
        case 151:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 5;
          this.headSlot = (short) 7;
          this.rare = (sbyte) 2;
          this.value = 45000;
          break;
        case 152:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 6;
          this.bodySlot = (short) 7;
          this.rare = (sbyte) 2;
          this.value = 30000;
          break;
        case 153:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 5;
          this.legSlot = (short) 7;
          this.rare = (sbyte) 2;
          this.value = 30000;
          break;
        case 154:
          this.maxStack = (short) 99;
          this.consumable = true;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 50;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.useStyle = (byte) 1;
          this.useSound = (byte) 1;
          this.shootSpeed = 8f;
          this.noUseGraphic = true;
          this.damage = (short) 22;
          this.knockBack = 4f;
          this.shoot = (byte) 21;
          this.ranged = true;
          break;
        case 155:
          this.autoReuse = true;
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 20;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 18;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 2;
          this.value = 27000;
          this.knockBack = 1f;
          this.melee = true;
          break;
        case 156:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 2;
          this.value = 27000;
          this.accessory = true;
          this.defense = (short) 1;
          break;
        case 157:
          this.mana = (byte) 7;
          this.autoReuse = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 16;
          this.useTime = (byte) 8;
          this.knockBack = 5f;
          this.width = (ushort) 38;
          this.height = (ushort) 10;
          this.damage = (short) 14;
          this.scale = 1f;
          this.shoot = (byte) 22;
          this.shootSpeed = 11f;
          this.useSound = (byte) 13;
          this.rare = (sbyte) 2;
          this.value = 27000;
          this.magic = true;
          break;
        case 158:
          this.width = (ushort) 20;
          this.height = (ushort) 22;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.accessory = true;
          break;
        case 159:
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.accessory = true;
          break;
        case 160:
          this.autoReuse = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 30;
          this.useTime = (byte) 30;
          this.knockBack = 6f;
          this.width = (ushort) 30;
          this.height = (ushort) 10;
          this.damage = (short) 25;
          this.scale = 1.1f;
          this.shoot = (byte) 23;
          this.shootSpeed = 11f;
          this.useSound = (byte) 10;
          this.rare = (sbyte) 2;
          this.value = 27000;
          this.ranged = true;
          break;
        case 161:
          this.useStyle = (byte) 1;
          this.shootSpeed = 5f;
          this.shoot = (byte) 24;
          this.knockBack = 1f;
          this.damage = (short) 15;
          this.width = (ushort) 10;
          this.height = (ushort) 10;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 80;
          this.ranged = true;
          break;
        case 162:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.knockBack = 6.5f;
          this.width = (ushort) 30;
          this.height = (ushort) 10;
          this.damage = (short) 15;
          this.scale = 1.1f;
          this.noUseGraphic = true;
          this.shoot = (byte) 25;
          this.shootSpeed = 12f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.melee = true;
          this.channel = true;
          this.noMelee = true;
          break;
        case 163:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.knockBack = 7f;
          this.width = (ushort) 30;
          this.height = (ushort) 10;
          this.damage = (short) 23;
          this.scale = 1.1f;
          this.noUseGraphic = true;
          this.shoot = (byte) 26;
          this.shootSpeed = 12f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 2;
          this.value = 27000;
          this.melee = true;
          this.channel = true;
          break;
        case 164:
          this.autoReuse = false;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.shoot = (byte) 14;
          this.knockBack = 3f;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 11;
          this.damage = (short) 14;
          this.shootSpeed = 10f;
          this.noMelee = true;
          this.value = 50000;
          this.scale = 0.75f;
          this.rare = (sbyte) 2;
          this.ranged = true;
          break;
        case 165:
          this.autoReuse = true;
          this.rare = (sbyte) 2;
          this.mana = (byte) 14;
          this.useSound = (byte) 21;
          this.useStyle = (byte) 5;
          this.damage = (short) 17;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.shoot = (byte) 27;
          this.scale = 0.9f;
          this.shootSpeed = 4.5f;
          this.knockBack = 5f;
          this.magic = true;
          this.value = 50000;
          break;
        case 166:
          this.useStyle = (byte) 1;
          this.shootSpeed = 5f;
          this.shoot = (byte) 28;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 50;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 500;
          this.damage = (short) 0;
          break;
        case 167:
          this.useStyle = (byte) 1;
          this.shootSpeed = 4f;
          this.shoot = (byte) 29;
          this.width = (ushort) 8;
          this.height = (ushort) 28;
          this.maxStack = (short) 5;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 40;
          this.useTime = (byte) 40;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 5000;
          this.rare = (sbyte) 1;
          break;
        case 168:
          this.useStyle = (byte) 5;
          this.shootSpeed = 5.5f;
          this.shoot = (byte) 30;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 400;
          this.damage = (short) 60;
          this.knockBack = 8f;
          this.ranged = true;
          break;
        case 169:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 53;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.ammo = (byte) 42;
          break;
        case 170:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 54;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 171:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 55;
          this.width = (ushort) 28;
          this.height = (ushort) 28;
          break;
        case 172:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 57;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 173:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 56;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 174:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 58;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.rare = (sbyte) 2;
          break;
        case 175:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.rare = (sbyte) 2;
          this.value = 20000;
          break;
        case 176:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 59;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 177:
          this.maxStack = (short) 99;
          this.alpha = (byte) 50;
          this.width = (ushort) 10;
          this.height = (ushort) 14;
          this.value = 5625;
          break;
        case 178:
          this.maxStack = (short) 99;
          this.alpha = (byte) 50;
          this.width = (ushort) 10;
          this.height = (ushort) 14;
          this.value = 11250;
          break;
        case 179:
          this.maxStack = (short) 99;
          this.alpha = (byte) 50;
          this.width = (ushort) 10;
          this.height = (ushort) 14;
          this.value = 7500;
          break;
        case 180:
          this.maxStack = (short) 99;
          this.alpha = (byte) 50;
          this.width = (ushort) 10;
          this.height = (ushort) 14;
          this.value = 3750;
          break;
        case 181:
          this.maxStack = (short) 99;
          this.alpha = (byte) 50;
          this.width = (ushort) 10;
          this.height = (ushort) 14;
          this.value = 1875;
          break;
        case 182:
          this.maxStack = (short) 99;
          this.alpha = (byte) 50;
          this.width = (ushort) 10;
          this.height = (ushort) 14;
          this.value = 15000;
          break;
        case 183:
          this.useStyle = (byte) 2;
          this.useSound = (byte) 2;
          this.useTurn = false;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.width = (ushort) 16;
          this.height = (ushort) 18;
          this.healLife = (short) 25;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.potion = true;
          this.value = 50;
          break;
        case 184:
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 185:
          this.noUseGraphic = true;
          this.damage = (short) 0;
          this.knockBack = 7f;
          this.useStyle = (byte) 5;
          this.shootSpeed = 13f;
          this.shoot = (byte) 32;
          this.width = (ushort) 18;
          this.height = (ushort) 28;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.value = 20000;
          break;
        case 186:
          this.width = (ushort) 44;
          this.height = (ushort) 44;
          this.rare = (sbyte) 1;
          this.value = 10000;
          this.holdStyle = (byte) 2;
          break;
        case 187:
          this.width = (ushort) 28;
          this.height = (ushort) 28;
          this.rare = (sbyte) 1;
          this.value = 10000;
          this.accessory = true;
          break;
        case 188:
          this.useSound = (byte) 3;
          this.healLife = (short) 100;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.rare = (sbyte) 1;
          this.potion = true;
          this.value = 1000;
          break;
        case 189:
          this.useSound = (byte) 3;
          this.healMana = (short) 100;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 50;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.rare = (sbyte) 1;
          this.value = 250;
          break;
        case 190:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 30;
          this.knockBack = 3f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 28;
          this.scale = 1.4f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 3;
          this.value = 27000;
          this.melee = true;
          break;
        case 191:
          this.noMelee = true;
          this.useStyle = (byte) 1;
          this.shootSpeed = 11f;
          this.shoot = (byte) 33;
          this.damage = (short) 25;
          this.knockBack = 8f;
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.rare = (sbyte) 3;
          this.value = 50000;
          this.melee = true;
          break;
        case 192:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 75;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 193:
          this.width = (ushort) 20;
          this.height = (ushort) 22;
          this.rare = (sbyte) 2;
          this.value = 27000;
          this.accessory = true;
          this.defense = (short) 1;
          break;
        case 194:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 70;
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.value = 150;
          break;
        case 195:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 60;
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.value = 150;
          break;
        case 196:
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 37;
          this.useTime = (byte) 25;
          this.hammer = (byte) 25;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 2;
          this.knockBack = 5.5f;
          this.scale = 1.2f;
          this.useSound = (byte) 1;
          this.tileBoost = (sbyte) -1;
          this.value = 50;
          this.melee = true;
          break;
        case 197:
          this.autoReuse = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 12;
          this.useAmmo = (byte) 15;
          this.useSound = (byte) 9;
          this.damage = (short) 55;
          this.shootSpeed = 14f;
          this.noMelee = true;
          this.value = 500000;
          this.rare = (sbyte) 2;
          this.ranged = true;
          break;
        case 198:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.knockBack = 3f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 21;
          this.scale = 1f;
          this.useSound = (byte) 15;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.melee = true;
          break;
        case 199:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.knockBack = 3f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 21;
          this.scale = 1f;
          this.useSound = (byte) 15;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.melee = true;
          break;
        case 200:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.knockBack = 3f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 21;
          this.scale = 1f;
          this.useSound = (byte) 15;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.melee = true;
          break;
        case 201:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.knockBack = 3f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 21;
          this.scale = 1f;
          this.useSound = (byte) 15;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.melee = true;
          break;
        case 202:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.knockBack = 3f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 21;
          this.scale = 1f;
          this.useSound = (byte) 15;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.melee = true;
          break;
        case 203:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.knockBack = 3f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 21;
          this.scale = 1f;
          this.useSound = (byte) 15;
          this.rare = (sbyte) 1;
          this.value = 27000;
          this.melee = true;
          break;
        case 204:
          this.useTurn = true;
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 30;
          this.useTime = (byte) 16;
          this.hammer = (byte) 60;
          this.axe = (byte) 20;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 20;
          this.knockBack = 7f;
          this.scale = 1.2f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 1;
          this.value = 15000;
          this.melee = true;
          break;
        case 205:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.headSlot = (short) 13;
          this.defense = (short) 1;
          break;
        case 206:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          break;
        case 207:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          break;
        case 208:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 100;
          this.headSlot = (short) 23;
          this.vanity = true;
          break;
        case 209:
          this.width = (ushort) 16;
          this.height = (ushort) 18;
          this.maxStack = (short) 99;
          this.value = 200;
          break;
        case 210:
          this.width = (ushort) 14;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 1000;
          break;
        case 211:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.accessory = true;
          this.rare = (sbyte) 3;
          this.value = 50000;
          break;
        case 212:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.accessory = true;
          this.rare = (sbyte) 3;
          this.value = 50000;
          break;
        case 213:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 13;
          this.autoReuse = true;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 7;
          this.createTile = (short) 2;
          this.scale = 1.2f;
          this.useSound = (byte) 1;
          this.knockBack = 3f;
          this.rare = (sbyte) 3;
          this.value = 2000;
          this.melee = true;
          break;
        case 214:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 76;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 215:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.useTurn = true;
          this.useTime = (byte) 30;
          this.useAnimation = (byte) 30;
          this.noUseGraphic = true;
          this.useStyle = (byte) 10;
          this.useSound = (byte) 16;
          this.rare = (sbyte) 2;
          this.value = 100;
          break;
        case 216:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.rare = (sbyte) 1;
          this.value = 1500;
          this.accessory = true;
          this.defense = (short) 1;
          break;
        case 217:
          this.useTurn = true;
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 27;
          this.useTime = (byte) 14;
          this.hammer = (byte) 70;
          this.axe = (byte) 30;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 20;
          this.knockBack = 7f;
          this.scale = 1.4f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 3;
          this.value = 15000;
          this.melee = true;
          break;
        case 218:
          this.mana = (byte) 16;
          this.channel = true;
          this.damage = (short) 34;
          this.useStyle = (byte) 1;
          this.shootSpeed = 6f;
          this.shoot = (byte) 34;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 20;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.knockBack = 6.5f;
          this.tileBoost = (sbyte) 64;
          this.value = 10000;
          this.magic = true;
          break;
        case 219:
          this.autoReuse = false;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 11;
          this.useTime = (byte) 11;
          this.width = (ushort) 24;
          this.height = (ushort) 22;
          this.shoot = (byte) 14;
          this.knockBack = 2f;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 11;
          this.damage = (short) 23;
          this.shootSpeed = 13f;
          this.noMelee = true;
          this.value = 50000;
          this.scale = 0.75f;
          this.rare = (sbyte) 3;
          this.ranged = true;
          break;
        case 220:
          this.noMelee = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.knockBack = 7f;
          this.width = (ushort) 30;
          this.height = (ushort) 10;
          this.damage = (short) 33;
          this.scale = 1.1f;
          this.noUseGraphic = true;
          this.shoot = (byte) 35;
          this.shootSpeed = 12f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 3;
          this.value = 27000;
          this.melee = true;
          this.channel = true;
          break;
        case 221:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 77;
          this.width = (ushort) 26;
          this.height = (ushort) 24;
          this.value = 3000;
          break;
        case 222:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 78;
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.value = 100;
          break;
        case 223:
          this.width = (ushort) 20;
          this.height = (ushort) 22;
          this.rare = (sbyte) 3;
          this.value = 27000;
          this.accessory = true;
          break;
        case 224:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 79;
          this.width = (ushort) 28;
          this.height = (ushort) 20;
          this.value = 2000;
          break;
        case 225:
          this.maxStack = (short) 99;
          this.width = (ushort) 22;
          this.height = (ushort) 22;
          this.value = 1000;
          break;
        case 226:
          this.useSound = (byte) 3;
          this.healMana = (short) 50;
          this.healLife = (short) 50;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 20;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.potion = true;
          this.value = 2000;
          break;
        case 227:
          this.useSound = (byte) 3;
          this.healMana = (short) 100;
          this.healLife = (short) 100;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 20;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.potion = true;
          this.value = 4000;
          break;
        case 228:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.headSlot = (short) 8;
          this.rare = (sbyte) 3;
          this.value = 45000;
          break;
        case 229:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 5;
          this.bodySlot = (short) 8;
          this.rare = (sbyte) 3;
          this.value = 30000;
          break;
        case 230:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.legSlot = (short) 8;
          this.rare = (sbyte) 3;
          this.value = 30000;
          break;
        case 231:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 8;
          this.headSlot = (short) 9;
          this.rare = (sbyte) 3;
          this.value = 45000;
          break;
        case 232:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 9;
          this.bodySlot = (short) 9;
          this.rare = (sbyte) 3;
          this.value = 30000;
          break;
        case 233:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 8;
          this.legSlot = (short) 9;
          this.rare = (sbyte) 3;
          this.value = 30000;
          break;
        case 234:
          this.shootSpeed = 3f;
          this.shoot = (byte) 36;
          this.damage = (short) 9;
          this.width = (ushort) 8;
          this.height = (ushort) 8;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 14;
          this.knockBack = 1f;
          this.value = 8;
          this.rare = (sbyte) 1;
          this.ranged = true;
          break;
        case 235:
          this.useStyle = (byte) 1;
          this.shootSpeed = 5f;
          this.shoot = (byte) 37;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 50;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 500;
          this.damage = (short) 0;
          break;
        case 236:
          this.width = (ushort) 12;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 5000;
          break;
        case 237:
          this.width = (ushort) 28;
          this.height = (ushort) 12;
          this.headSlot = (short) 12;
          this.rare = (sbyte) 2;
          this.value = 10000;
          this.vanity = true;
          break;
        case 238:
          this.width = (ushort) 28;
          this.height = (ushort) 20;
          this.headSlot = (short) 14;
          this.rare = (sbyte) 2;
          this.value = 10000;
          this.defense = (short) 2;
          break;
        case 239:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.headSlot = (short) 15;
          this.value = 10000;
          this.vanity = true;
          break;
        case 240:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 10;
          this.value = 5000;
          this.vanity = true;
          break;
        case 241:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 10;
          this.value = 5000;
          this.vanity = true;
          break;
        case 242:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.headSlot = (short) 16;
          this.value = 10000;
          this.vanity = true;
          break;
        case 243:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.headSlot = (short) 17;
          this.value = 20000;
          this.vanity = true;
          break;
        case 244:
          this.width = (ushort) 18;
          this.height = (ushort) 12;
          this.headSlot = (short) 18;
          this.value = 10000;
          this.vanity = true;
          break;
        case 245:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 11;
          this.value = 250000;
          this.vanity = true;
          break;
        case 246:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 11;
          this.value = 250000;
          this.vanity = true;
          break;
        case 247:
          this.width = (ushort) 18;
          this.height = (ushort) 12;
          this.headSlot = (short) 19;
          this.value = 10000;
          this.vanity = true;
          break;
        case 248:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 12;
          this.value = 5000;
          this.vanity = true;
          break;
        case 249:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 12;
          this.value = 5000;
          this.vanity = true;
          break;
        case 250:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.headSlot = (short) 20;
          this.value = 10000;
          this.vanity = true;
          break;
        case 251:
          this.width = (ushort) 18;
          this.height = (ushort) 12;
          this.headSlot = (short) 21;
          this.value = 10000;
          this.vanity = true;
          break;
        case 252:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 13;
          this.value = 5000;
          this.vanity = true;
          break;
        case 253:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 13;
          this.value = 5000;
          this.vanity = true;
          break;
        case 254:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 20;
          this.value = 10000;
          break;
        case (int) byte.MaxValue:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 20;
          this.value = 2000;
          break;
        case 256:
          this.width = (ushort) 18;
          this.height = (ushort) 12;
          this.headSlot = (short) 22;
          this.value = 10000;
          this.vanity = true;
          break;
        case 257:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 14;
          this.value = 5000;
          this.vanity = true;
          break;
        case 258:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 14;
          this.value = 5000;
          this.vanity = true;
          break;
        case 259:
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 50;
          break;
        case 260:
          this.width = (ushort) 18;
          this.height = (ushort) 14;
          this.headSlot = (short) 24;
          this.value = 1000;
          this.vanity = true;
          break;
        case 261:
          this.useStyle = (byte) 2;
          this.useSound = (byte) 2;
          this.useTurn = false;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.width = (ushort) 20;
          this.height = (ushort) 10;
          this.maxStack = (short) 99;
          this.healLife = (short) 20;
          this.consumable = true;
          this.value = 1000;
          this.potion = true;
          break;
        case 262:
          this.width = (ushort) 18;
          this.height = (ushort) 14;
          this.bodySlot = (short) 15;
          this.value = 2000;
          this.vanity = true;
          break;
        case 263:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.headSlot = (short) 25;
          this.value = 10000;
          this.vanity = true;
          break;
        case 264:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.headSlot = (short) 26;
          this.value = 10000;
          this.vanity = true;
          break;
        case 265:
          this.shootSpeed = 6.5f;
          this.shoot = (byte) 41;
          this.damage = (short) 10;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 8f;
          this.value = 100;
          this.rare = (sbyte) 2;
          this.ranged = true;
          break;
        case 266:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 16;
          this.useTime = (byte) 16;
          this.autoReuse = true;
          this.width = (ushort) 40;
          this.height = (ushort) 20;
          this.shoot = (byte) 42;
          this.useAmmo = (byte) 42;
          this.useSound = (byte) 11;
          this.damage = (short) 30;
          this.shootSpeed = 12f;
          this.noMelee = true;
          this.knockBack = 5f;
          this.value = 10000;
          this.rare = (sbyte) 2;
          this.ranged = true;
          break;
        case 267:
          this.accessory = true;
          this.width = (ushort) 14;
          this.height = (ushort) 26;
          this.value = 1000;
          break;
        case 268:
          this.headSlot = (short) 27;
          this.defense = (short) 2;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 1000;
          this.rare = (sbyte) 2;
          break;
        case 269:
          this.bodySlot = (short) 0;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 10000;
          if (UI.current.player != null)
          {
            this.color = UI.current.player.shirtColor;
            break;
          }
          else
            break;
        case 270:
          this.legSlot = (short) 0;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 10000;
          if (UI.current.player != null)
          {
            this.color = UI.current.player.pantsColor;
            break;
          }
          else
            break;
        case 271:
          this.headSlot = (short) 0;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 10000;
          if (UI.current.player != null)
          {
            this.color = UI.current.player.hairColor;
            break;
          }
          else
            break;
        case 272:
          this.mana = (byte) 14;
          this.damage = (short) 35;
          this.useStyle = (byte) 5;
          this.shootSpeed = 0.2f;
          this.shoot = (byte) 45;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 8;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.knockBack = 5f;
          this.scale = 0.9f;
          this.value = 10000;
          this.magic = true;
          break;
        case 273:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 27;
          this.useTime = (byte) 27;
          this.knockBack = 4.5f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 42;
          this.scale = 1.15f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 3;
          this.value = 27000;
          this.melee = true;
          break;
        case 274:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.shootSpeed = 5f;
          this.knockBack = 4f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 27;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 46;
          this.rare = (sbyte) 3;
          this.value = 27000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 275:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 81;
          this.width = (ushort) 20;
          this.height = (ushort) 22;
          this.value = 400;
          break;
        case 276:
          this.maxStack = (short) 250;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 10;
          break;
        case 277:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 31;
          this.useTime = (byte) 31;
          this.shootSpeed = 4f;
          this.knockBack = 5f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 10;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 47;
          this.rare = (sbyte) 1;
          this.value = 10000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 278:
          this.shootSpeed = 4.5f;
          this.shoot = (byte) 14;
          this.damage = (short) 9;
          this.width = (ushort) 8;
          this.height = (ushort) 8;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 14;
          this.knockBack = 3f;
          this.value = 15;
          this.ranged = true;
          break;
        case 279:
          this.useStyle = (byte) 1;
          this.shootSpeed = 10f;
          this.shoot = (byte) 48;
          this.damage = (short) 12;
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 50;
          this.knockBack = 2f;
          this.ranged = true;
          break;
        case 280:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 31;
          this.useTime = (byte) 31;
          this.shootSpeed = 3.7f;
          this.knockBack = 6.5f;
          this.width = (ushort) 32;
          this.height = (ushort) 32;
          this.damage = (short) 8;
          this.scale = 1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 49;
          this.value = 1000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 281:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.width = (ushort) 38;
          this.height = (ushort) 6;
          this.shoot = (byte) 10;
          this.useAmmo = (byte) 51;
          this.useSound = (byte) 5;
          this.damage = (short) 9;
          this.shootSpeed = 11f;
          this.noMelee = true;
          this.value = 10000;
          this.knockBack = 4f;
          this.useAmmo = (byte) 51;
          this.ranged = true;
          break;
        case 282:
          this.useStyle = (byte) 1;
          this.shootSpeed = 6f;
          this.shoot = (byte) 50;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noMelee = true;
          this.value = 10;
          this.holdStyle = (byte) 1;
          break;
        case 283:
          this.shoot = (byte) 51;
          this.width = (ushort) 8;
          this.height = (ushort) 8;
          this.maxStack = (short) 250;
          this.ammo = (byte) 51;
          break;
        case 284:
          this.noMelee = true;
          this.useStyle = (byte) 1;
          this.shootSpeed = 6.5f;
          this.shoot = (byte) 52;
          this.damage = (short) 7;
          this.knockBack = 5f;
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 16;
          this.useTime = (byte) 16;
          this.noUseGraphic = true;
          this.value = 5000;
          this.melee = true;
          break;
        case 285:
          this.width = (ushort) 24;
          this.height = (ushort) 8;
          this.accessory = true;
          this.value = 5000;
          break;
        case 286:
          this.useStyle = (byte) 1;
          this.shootSpeed = 6f;
          this.shoot = (byte) 53;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noMelee = true;
          this.value = 20;
          this.holdStyle = (byte) 1;
          break;
        case 287:
          this.useStyle = (byte) 1;
          this.shootSpeed = 11f;
          this.shoot = (byte) 54;
          this.damage = (short) 13;
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 60;
          this.knockBack = 2f;
          this.ranged = true;
          break;
        case 288:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 1;
          this.buffTime = (ushort) 14400;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 289:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 2;
          this.buffTime = (ushort) 18000;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 290:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 3;
          this.buffTime = (ushort) 14400;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 291:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 4;
          this.buffTime = (ushort) 7200;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 292:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 5;
          this.buffTime = (ushort) 18000;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 293:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 6;
          this.buffTime = (ushort) 7200;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 294:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 7;
          this.buffTime = (ushort) 7200;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 295:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 8;
          this.buffTime = (ushort) 18000;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 296:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 9;
          this.buffTime = (ushort) 18000;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 297:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 10;
          this.buffTime = (ushort) 7200;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 298:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 11;
          this.buffTime = (ushort) 18000;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 299:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 12;
          this.buffTime = (ushort) 14400;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 300:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 13;
          this.buffTime = (ushort) 25200;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 301:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 14;
          this.buffTime = (ushort) 7200;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 302:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 15;
          this.buffTime = (ushort) 18000;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 303:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 16;
          this.buffTime = (ushort) 14400;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 304:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 17;
          this.buffTime = (ushort) 18000;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 305:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.buffType = (byte) 18;
          this.buffTime = (ushort) 10800;
          this.value = 1000;
          this.rare = (sbyte) 1;
          break;
        case 306:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 21;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 26;
          this.height = (ushort) 22;
          this.value = 5000;
          break;
        case 307:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 82;
          this.placeStyle = (byte) 0;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 80;
          break;
        case 308:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 82;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 80;
          break;
        case 309:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 82;
          this.placeStyle = (byte) 2;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 80;
          break;
        case 310:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 82;
          this.placeStyle = (byte) 3;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 80;
          break;
        case 311:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 82;
          this.placeStyle = (byte) 4;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 80;
          break;
        case 312:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 82;
          this.placeStyle = (byte) 5;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 80;
          break;
        case 313:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 100;
          break;
        case 314:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 100;
          break;
        case 315:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 100;
          break;
        case 316:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 100;
          break;
        case 317:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 100;
          break;
        case 318:
          this.maxStack = (short) 99;
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.value = 100;
          break;
        case 319:
          this.maxStack = (short) 99;
          this.width = (ushort) 16;
          this.height = (ushort) 14;
          this.value = 200;
          break;
        case 320:
          this.maxStack = (short) 99;
          this.width = (ushort) 16;
          this.height = (ushort) 14;
          this.value = 50;
          break;
        case 321:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 85;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          break;
        case 322:
          this.headSlot = (short) 28;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 20000;
          break;
        case 323:
          this.width = (ushort) 10;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 50;
          break;
        case 324:
          this.width = (ushort) 10;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 750000;
          break;
        case 325:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 16;
          this.value = 200000;
          this.vanity = true;
          break;
        case 326:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 15;
          this.value = 200000;
          this.vanity = true;
          break;
        case 327:
          this.width = (ushort) 14;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          break;
        case 328:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 21;
          this.placeStyle = (byte) 3;
          this.width = (ushort) 26;
          this.height = (ushort) 22;
          this.value = 5000;
          break;
        case 329:
          this.width = (ushort) 14;
          this.height = (ushort) 20;
          this.maxStack = (short) 1;
          this.value = 75000;
          break;
        case 330:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 20;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 331:
          this.width = (ushort) 18;
          this.height = (ushort) 16;
          this.maxStack = (short) 99;
          this.value = 100;
          break;
        case 332:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 86;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 333:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 87;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 334:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 88;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 335:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 89;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 336:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 90;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 337:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 91;
          this.placeStyle = (byte) 0;
          this.width = (ushort) 10;
          this.height = (ushort) 24;
          this.value = 500;
          break;
        case 338:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 91;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 10;
          this.height = (ushort) 24;
          this.value = 500;
          break;
        case 339:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 91;
          this.placeStyle = (byte) 2;
          this.width = (ushort) 10;
          this.height = (ushort) 24;
          this.value = 500;
          break;
        case 340:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 91;
          this.placeStyle = (byte) 3;
          this.width = (ushort) 10;
          this.height = (ushort) 24;
          this.value = 500;
          break;
        case 341:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 92;
          this.width = (ushort) 10;
          this.height = (ushort) 24;
          this.value = 500;
          break;
        case 342:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 93;
          this.width = (ushort) 10;
          this.height = (ushort) 24;
          this.value = 500;
          break;
        case 343:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 21;
          this.placeStyle = (byte) 5;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 500;
          break;
        case 344:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 95;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 500;
          break;
        case 345:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 96;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 500;
          break;
        case 346:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 97;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 500000;
          break;
        case 347:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 98;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 500;
          break;
        case 348:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 21;
          this.placeStyle = (byte) 6;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 1000;
          break;
        case 349:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 100;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 1500;
          break;
        case 350:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 13;
          this.placeStyle = (byte) 3;
          this.width = (ushort) 16;
          this.height = (ushort) 24;
          this.value = 70;
          break;
        case 351:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 13;
          this.placeStyle = (byte) 4;
          this.width = (ushort) 16;
          this.height = (ushort) 24;
          this.value = 20;
          break;
        case 352:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 94;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.value = 600;
          break;
        case 353:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 10;
          this.height = (ushort) 10;
          this.buffType = (byte) 25;
          this.buffTime = (ushort) 7200;
          this.value = 100;
          break;
        case 354:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 101;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 355:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 102;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 356:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 103;
          this.width = (ushort) 16;
          this.height = (ushort) 24;
          this.value = 20;
          break;
        case 357:
          this.useSound = (byte) 3;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 10;
          this.height = (ushort) 10;
          this.buffType = (byte) 26;
          this.buffTime = (ushort) 36000;
          this.rare = (sbyte) 1;
          this.value = 1000;
          break;
        case 358:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 15;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 12;
          this.height = (ushort) 30;
          this.value = 150;
          break;
        case 359:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 104;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 360:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 361:
          this.useStyle = (byte) 4;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.width = (ushort) 28;
          this.height = (ushort) 28;
          break;
        case 362:
          this.maxStack = (short) 99;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.value = 30;
          break;
        case 363:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 106;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          break;
        case 364:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 107;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 3500;
          this.rare = (sbyte) 3;
          break;
        case 365:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 108;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 5500;
          this.rare = (sbyte) 3;
          break;
        case 366:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 111;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 7500;
          this.rare = (sbyte) 3;
          break;
        case 367:
          this.useTurn = true;
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 27;
          this.useTime = (byte) 14;
          this.hammer = (byte) 80;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.damage = (short) 26;
          this.knockBack = 7.5f;
          this.scale = 1.2f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 4;
          this.value = 39000;
          this.melee = true;
          break;
        case 368:
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.knockBack = 4.5f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 47;
          this.scale = 1.15f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 5;
          this.value = 230000;
          this.melee = true;
          break;
        case 369:
          this.useTurn = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 109;
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.value = 2000;
          this.rare = (sbyte) 3;
          break;
        case 370:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 112;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.ammo = (byte) 42;
          break;
        case 371:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 2;
          this.headSlot = (short) 29;
          this.rare = (sbyte) 4;
          this.value = 75000;
          break;
        case 372:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 11;
          this.headSlot = (short) 30;
          this.rare = (sbyte) 4;
          this.value = 75000;
          break;
        case 373:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.headSlot = (short) 31;
          this.rare = (sbyte) 4;
          this.value = 75000;
          break;
        case 374:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 8;
          this.bodySlot = (short) 17;
          this.rare = (sbyte) 4;
          this.value = 60000;
          break;
        case 375:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 7;
          this.legSlot = (short) 16;
          this.rare = (sbyte) 4;
          this.value = 45000;
          break;
        case 376:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 3;
          this.headSlot = (short) 32;
          this.rare = (sbyte) 4;
          this.value = 112500;
          break;
        case 377:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 16;
          this.headSlot = (short) 33;
          this.rare = (sbyte) 4;
          this.value = 112500;
          break;
        case 378:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 6;
          this.headSlot = (short) 34;
          this.rare = (sbyte) 4;
          this.value = 112500;
          break;
        case 379:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 12;
          this.bodySlot = (short) 18;
          this.rare = (sbyte) 4;
          this.value = 90000;
          break;
        case 380:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 9;
          this.legSlot = (short) 17;
          this.rare = (sbyte) 4;
          this.value = 67500;
          break;
        case 381:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 10500;
          this.rare = (sbyte) 3;
          break;
        case 382:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 22000;
          this.rare = (sbyte) 3;
          break;
        case 383:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 8;
          this.shootSpeed = 40f;
          this.knockBack = 2.75f;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.damage = (short) 23;
          this.axe = (byte) 14;
          this.useSound = (byte) 23;
          this.shoot = (byte) 57;
          this.rare = (sbyte) 4;
          this.value = 54000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          this.channel = true;
          break;
        case 384:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 8;
          this.shootSpeed = 40f;
          this.knockBack = 3f;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.damage = (short) 29;
          this.axe = (byte) 17;
          this.useSound = (byte) 23;
          this.shoot = (byte) 58;
          this.rare = (sbyte) 4;
          this.value = 81000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          this.channel = true;
          break;
        case 385:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 13;
          this.shootSpeed = 32f;
          this.knockBack = 0.0f;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.damage = (short) 10;
          this.pick = (byte) 110;
          this.useSound = (byte) 23;
          this.shoot = (byte) 59;
          this.rare = (sbyte) 4;
          this.value = 54000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          this.channel = true;
          break;
        case 386:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 10;
          this.shootSpeed = 32f;
          this.knockBack = 0.0f;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.damage = (short) 15;
          this.pick = (byte) 150;
          this.useSound = (byte) 23;
          this.shoot = (byte) 60;
          this.rare = (sbyte) 4;
          this.value = 81000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          this.channel = true;
          break;
        case 387:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 6;
          this.shootSpeed = 40f;
          this.knockBack = 4.5f;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.damage = (short) 33;
          this.axe = (byte) 20;
          this.useSound = (byte) 23;
          this.shoot = (byte) 61;
          this.rare = (sbyte) 4;
          this.value = 108000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          this.channel = true;
          break;
        case 388:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 7;
          this.shootSpeed = 32f;
          this.knockBack = 0.0f;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.damage = (short) 20;
          this.pick = (byte) 180;
          this.useSound = (byte) 23;
          this.shoot = (byte) 62;
          this.rare = (sbyte) 4;
          this.value = 108000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          this.channel = true;
          break;
        case 389:
          this.noMelee = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.knockBack = 7f;
          this.width = (ushort) 30;
          this.height = (ushort) 10;
          this.damage = (short) 49;
          this.scale = 1.1f;
          this.noUseGraphic = true;
          this.shoot = (byte) 63;
          this.shootSpeed = 15f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 5;
          this.value = 144000;
          this.melee = true;
          this.channel = true;
          break;
        case 390:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 26;
          this.useTime = (byte) 26;
          this.shootSpeed = 4.5f;
          this.knockBack = 5f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 35;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 64;
          this.rare = (sbyte) 4;
          this.value = 67500;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 391:
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.maxStack = (short) 99;
          this.value = 37500;
          this.rare = (sbyte) 3;
          break;
        case 392:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 21;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 393:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 3;
          this.value = 100000;
          this.accessory = true;
          break;
        case 394:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 395:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 4;
          this.value = 150000;
          this.accessory = true;
          break;
        case 396:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 397:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          this.defense = (short) 2;
          break;
        case 398:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 114;
          this.width = (ushort) 26;
          this.height = (ushort) 20;
          this.value = 100000;
          break;
        case 399:
          this.width = (ushort) 14;
          this.height = (ushort) 28;
          this.rare = (sbyte) 4;
          this.value = 150000;
          this.accessory = true;
          break;
        case 400:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 4;
          this.headSlot = (short) 35;
          this.rare = (sbyte) 4;
          this.value = 150000;
          break;
        case 401:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 22;
          this.headSlot = (short) 36;
          this.rare = (sbyte) 4;
          this.value = 150000;
          break;
        case 402:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 8;
          this.headSlot = (short) 37;
          this.rare = (sbyte) 4;
          this.value = 150000;
          break;
        case 403:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 14;
          this.bodySlot = (short) 19;
          this.rare = (sbyte) 4;
          this.value = 120000;
          break;
        case 404:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 10;
          this.legSlot = (short) 18;
          this.rare = (sbyte) 4;
          this.value = 90000;
          break;
        case 405:
          this.width = (ushort) 28;
          this.height = (ushort) 24;
          this.accessory = true;
          this.rare = (sbyte) 4;
          this.value = 100000;
          break;
        case 406:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.shootSpeed = 5f;
          this.knockBack = 6f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 38;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 66;
          this.rare = (sbyte) 4;
          this.value = 90000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 407:
          this.width = (ushort) 28;
          this.height = (ushort) 24;
          this.accessory = true;
          this.rare = (sbyte) 3;
          this.value = 100000;
          break;
        case 408:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 116;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.ammo = (byte) 42;
          break;
        case 409:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 117;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 410:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 1;
          this.bodySlot = (short) 20;
          this.value = 5000;
          this.rare = (sbyte) 1;
          break;
        case 411:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 1;
          this.legSlot = (short) 19;
          this.value = 5000;
          this.rare = (sbyte) 1;
          break;
        case 412:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 118;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 413:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 119;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 414:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 120;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 415:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 121;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 416:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 122;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 417:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 22;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 418:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 23;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 419:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 24;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 420:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 25;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 421:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 26;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 422:
          this.useStyle = (byte) 1;
          this.shootSpeed = 9f;
          this.rare = (sbyte) 3;
          this.damage = (short) 20;
          this.shoot = (byte) 69;
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.knockBack = 3f;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 200;
          break;
        case 423:
          this.useStyle = (byte) 1;
          this.shootSpeed = 9f;
          this.rare = (sbyte) 3;
          this.damage = (short) 20;
          this.shoot = (byte) 70;
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.knockBack = 3f;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 200;
          break;
        case 424:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 123;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 425:
          this.mana = (byte) 40;
          this.channel = true;
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 72;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.useSound = (byte) 25;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 5;
          this.noMelee = true;
          this.value = this.value = 250000;
          this.buffType = (byte) 27;
          this.buffTime = (ushort) 18000;
          break;
        case 426:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 30;
          this.knockBack = 8f;
          this.width = (ushort) 60;
          this.height = (ushort) 70;
          this.damage = (short) 39;
          this.scale = 1.05f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 4;
          this.value = 150000;
          this.melee = true;
          break;
        case 427:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 200;
          break;
        case 428:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 2;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 200;
          break;
        case 429:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 3;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 200;
          break;
        case 430:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 4;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 200;
          break;
        case 431:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 5;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 500;
          break;
        case 432:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 6;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 200;
          break;
        case 433:
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 7;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 300;
          break;
        case 434:
          this.autoReuse = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 4;
          this.reuseDelay = (byte) 14;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 10;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 31;
          this.damage = (short) 19;
          this.shootSpeed = 7.75f;
          this.noMelee = true;
          this.value = 150000;
          this.rare = (sbyte) 4;
          this.ranged = true;
          break;
        case 435:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 30;
          this.shootSpeed = 9f;
          this.noMelee = true;
          this.value = 60000;
          this.ranged = true;
          this.rare = (sbyte) 4;
          this.knockBack = 1.5f;
          break;
        case 436:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 23;
          this.useTime = (byte) 23;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 34;
          this.shootSpeed = 9.5f;
          this.noMelee = true;
          this.value = 90000;
          this.ranged = true;
          this.rare = (sbyte) 4;
          this.knockBack = 2f;
          break;
        case 437:
          this.noUseGraphic = true;
          this.damage = (short) 0;
          this.knockBack = 7f;
          this.useStyle = (byte) 5;
          this.shootSpeed = 14f;
          this.shoot = (byte) 73;
          this.width = (ushort) 18;
          this.height = (ushort) 28;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 4;
          this.noMelee = true;
          this.value = 200000;
          break;
        case 438:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 2;
          break;
        case 439:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 3;
          break;
        case 440:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 4;
          break;
        case 441:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 5;
          break;
        case 442:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 6;
          break;
        case 443:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 7;
          break;
        case 444:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 8;
          break;
        case 445:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 9;
          break;
        case 446:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 10;
          break;
        case 447:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 11;
          break;
        case 448:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 12;
          break;
        case 449:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 13;
          break;
        case 450:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 14;
          break;
        case 451:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 15;
          break;
        case 452:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 16;
          break;
        case 453:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 17;
          break;
        case 454:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 18;
          break;
        case 455:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 19;
          break;
        case 456:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 20;
          break;
        case 457:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 21;
          break;
        case 458:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 22;
          break;
        case 459:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 23;
          break;
        case 460:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 24;
          break;
        case 461:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 25;
          break;
        case 462:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 26;
          break;
        case 463:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 27;
          break;
        case 464:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 28;
          break;
        case 465:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 29;
          break;
        case 466:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 30;
          break;
        case 467:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 31;
          break;
        case 468:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 32;
          break;
        case 469:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 33;
          break;
        case 470:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 34;
          break;
        case 471:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 35;
          break;
        case 472:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 36;
          break;
        case 473:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 37;
          break;
        case 474:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 38;
          break;
        case 475:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 39;
          break;
        case 476:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 40;
          break;
        case 477:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 41;
          break;
        case 478:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 105;
          this.width = (ushort) 20;
          this.height = (ushort) 20;
          this.value = 300;
          this.placeStyle = (byte) 42;
          break;
        case 479:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 7;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 27;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 480:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 124;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 481:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 37;
          this.shootSpeed = 10f;
          this.noMelee = true;
          this.value = 120000;
          this.ranged = true;
          this.rare = (sbyte) 4;
          this.knockBack = 2.5f;
          break;
        case 482:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 27;
          this.useTime = (byte) 27;
          this.knockBack = 6f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 44;
          this.scale = 1.2f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 4;
          this.value = 138000;
          this.melee = true;
          break;
        case 483:
          this.useTurn = true;
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 23;
          this.useTime = (byte) 23;
          this.knockBack = 3.85f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 34;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 4;
          this.value = 69000;
          this.melee = true;
          break;
        case 484:
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 26;
          this.useTime = (byte) 26;
          this.knockBack = 6f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 39;
          this.scale = 1.15f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 4;
          this.value = 103500;
          this.melee = true;
          break;
        case 485:
          this.rare = (sbyte) 4;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.accessory = true;
          this.value = 150000;
          break;
        case 486:
          this.width = (ushort) 10;
          this.height = (ushort) 26;
          this.accessory = true;
          this.value = 10000;
          this.rare = (sbyte) 1;
          break;
        case 487:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 125;
          this.width = (ushort) 22;
          this.height = (ushort) 22;
          this.value = 100000;
          this.rare = (sbyte) 3;
          break;
        case 488:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 126;
          this.width = (ushort) 22;
          this.height = (ushort) 26;
          this.value = 10000;
          break;
        case 489:
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.accessory = true;
          this.value = 100000;
          this.rare = (sbyte) 4;
          break;
        case 490:
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.accessory = true;
          this.value = 100000;
          this.rare = (sbyte) 4;
          break;
        case 491:
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.accessory = true;
          this.value = 100000;
          break;
        case 492:
          this.width = (ushort) 24;
          this.height = (ushort) 8;
          this.accessory = true;
          this.value = 400000;
          this.rare = (sbyte) 5;
          break;
        case 493:
          this.width = (ushort) 24;
          this.height = (ushort) 8;
          this.accessory = true;
          this.value = 400000;
          this.rare = (sbyte) 5;
          break;
        case 494:
          this.rare = (sbyte) 5;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.width = (ushort) 12;
          this.height = (ushort) 28;
          this.shoot = (byte) 76;
          this.holdStyle = (byte) 3;
          this.autoReuse = true;
          this.damage = (short) 30;
          this.shootSpeed = 4.5f;
          this.noMelee = true;
          this.value = 200000;
          this.mana = (byte) 4;
          this.magic = true;
          break;
        case 495:
          this.rare = (sbyte) 5;
          this.mana = (byte) 10;
          this.channel = true;
          this.damage = (short) 53;
          this.useStyle = (byte) 1;
          this.shootSpeed = 6f;
          this.shoot = (byte) 79;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 28;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noMelee = true;
          this.knockBack = 5f;
          this.tileBoost = (sbyte) 64;
          this.value = 200000;
          this.magic = true;
          break;
        case 496:
          this.rare = (sbyte) 4;
          this.mana = (byte) 7;
          this.damage = (short) 26;
          this.useStyle = (byte) 1;
          this.shootSpeed = 12f;
          this.shoot = (byte) 80;
          this.width = (ushort) 26;
          this.height = (ushort) 28;
          this.useSound = (byte) 28;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.rare = (sbyte) 4;
          this.autoReuse = true;
          this.noMelee = true;
          this.knockBack = 0.0f;
          this.value = 1000000;
          this.magic = true;
          this.knockBack = 2f;
          break;
        case 497:
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.accessory = true;
          this.value = 150000;
          this.rare = (sbyte) 5;
          break;
        case 498:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 128;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 499:
          this.useSound = (byte) 3;
          this.healLife = (short) 150;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 30;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.rare = (sbyte) 3;
          this.potion = true;
          this.value = 5000;
          break;
        case 500:
          this.useSound = (byte) 3;
          this.healMana = (short) 200;
          this.useStyle = (byte) 2;
          this.useTurn = true;
          this.useAnimation = (byte) 17;
          this.useTime = (byte) 17;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.width = (ushort) 14;
          this.height = (ushort) 24;
          this.rare = (sbyte) 3;
          this.value = 500;
          break;
        case 501:
          this.width = (ushort) 16;
          this.height = (ushort) 14;
          this.maxStack = (short) 99;
          this.value = 500;
          this.rare = (sbyte) 1;
          break;
        case 502:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 129;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.value = 8000;
          this.rare = (sbyte) 1;
          break;
        case 503:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.headSlot = (short) 40;
          this.value = 20000;
          this.vanity = true;
          this.rare = (sbyte) 2;
          break;
        case 504:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 23;
          this.value = 10000;
          this.vanity = true;
          this.rare = (sbyte) 2;
          break;
        case 505:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 22;
          this.value = 10000;
          this.vanity = true;
          this.rare = (sbyte) 2;
          break;
        case 506:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 30;
          this.useTime = (byte) 6;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 85;
          this.useAmmo = (byte) 23;
          this.useSound = (byte) 34;
          this.damage = (short) 27;
          this.knockBack = 0.3f;
          this.shootSpeed = 7f;
          this.noMelee = true;
          this.value = 500000;
          this.rare = (sbyte) 5;
          this.ranged = true;
          break;
        case 507:
          this.rare = (sbyte) 3;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.width = (ushort) 12;
          this.height = (ushort) 28;
          this.autoReuse = true;
          this.noMelee = true;
          this.value = 10000;
          break;
        case 508:
          this.rare = (sbyte) 3;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.width = (ushort) 12;
          this.height = (ushort) 28;
          this.autoReuse = true;
          this.noMelee = true;
          this.value = 10000;
          break;
        case 509:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 1;
          this.value = 20000;
          this.mech = true;
          break;
        case 510:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.rare = (sbyte) 1;
          this.value = 20000;
          this.mech = true;
          break;
        case 511:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 130;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 1000;
          this.mech = true;
          break;
        case 512:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 131;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 1000;
          this.mech = true;
          break;
        case 513:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 132;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.value = 3000;
          this.mech = true;
          break;
        case 514:
          this.autoReuse = true;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 12;
          this.useTime = (byte) 12;
          this.width = (ushort) 36;
          this.height = (ushort) 22;
          this.shoot = (byte) 88;
          this.mana = (byte) 8;
          this.useSound = (byte) 12;
          this.knockBack = 2.5f;
          this.damage = (short) 29;
          this.shootSpeed = 17f;
          this.noMelee = true;
          this.rare = (sbyte) 4;
          this.magic = true;
          this.value = 500000;
          break;
        case 515:
          this.shootSpeed = 5f;
          this.shoot = (byte) 89;
          this.damage = (short) 9;
          this.width = (ushort) 8;
          this.height = (ushort) 8;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 14;
          this.knockBack = 1f;
          this.value = 30;
          this.ranged = true;
          this.rare = (sbyte) 3;
          break;
        case 516:
          this.shootSpeed = 3.5f;
          this.shoot = (byte) 91;
          this.damage = (short) 6;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 2f;
          this.value = 80;
          this.ranged = true;
          this.rare = (sbyte) 3;
          break;
        case 517:
          this.useStyle = (byte) 1;
          this.shootSpeed = 10f;
          this.shoot = (byte) 93;
          this.damage = (short) 28;
          this.width = (ushort) 18;
          this.height = (ushort) 20;
          this.mana = (byte) 7;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.noMelee = true;
          this.value = 1000000;
          this.knockBack = 2f;
          this.magic = true;
          this.rare = (sbyte) 4;
          break;
        case 518:
          this.autoReuse = true;
          this.rare = (sbyte) 4;
          this.mana = (byte) 5;
          this.useSound = (byte) 9;
          this.useStyle = (byte) 5;
          this.damage = (short) 26;
          this.useAnimation = (byte) 7;
          this.useTime = (byte) 7;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.shoot = (byte) 94;
          this.scale = 0.9f;
          this.shootSpeed = 16f;
          this.knockBack = 5f;
          this.magic = true;
          this.value = 500000;
          break;
        case 519:
          this.autoReuse = true;
          this.rare = (sbyte) 4;
          this.mana = (byte) 14;
          this.useSound = (byte) 20;
          this.useStyle = (byte) 5;
          this.damage = (short) 35;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.width = (ushort) 24;
          this.height = (ushort) 28;
          this.shoot = (byte) 95;
          this.scale = 0.9f;
          this.shootSpeed = 10f;
          this.knockBack = 6.5f;
          this.magic = true;
          this.value = 500000;
          break;
        case 520:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 1000;
          this.rare = (sbyte) 3;
          break;
        case 521:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 1000;
          this.rare = (sbyte) 3;
          break;
        case 522:
          this.width = (ushort) 12;
          this.height = (ushort) 14;
          this.maxStack = (short) 99;
          this.value = 4000;
          this.rare = (sbyte) 3;
          break;
        case 523:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.holdStyle = (byte) 1;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 4;
          this.placeStyle = (byte) 8;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 300;
          this.rare = (sbyte) 1;
          break;
        case 524:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 133;
          this.width = (ushort) 44;
          this.height = (ushort) 30;
          this.value = 50000;
          this.rare = (sbyte) 3;
          break;
        case 525:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 134;
          this.width = (ushort) 28;
          this.height = (ushort) 14;
          this.value = 25000;
          this.rare = (sbyte) 3;
          break;
        case 526:
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.maxStack = (short) 99;
          this.value = 15000;
          this.rare = (sbyte) 1;
          break;
        case 527:
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.maxStack = (short) 99;
          this.value = 4500;
          this.rare = (sbyte) 2;
          break;
        case 528:
          this.width = (ushort) 14;
          this.height = (ushort) 14;
          this.maxStack = (short) 99;
          this.value = 4500;
          this.rare = (sbyte) 2;
          break;
        case 529:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 135;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.placeStyle = (byte) 0;
          this.mech = true;
          this.value = 5000;
          this.mech = true;
          break;
        case 530:
          this.width = (ushort) 12;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 500;
          this.mech = true;
          break;
        case 531:
          this.width = (ushort) 12;
          this.height = (ushort) 18;
          this.maxStack = (short) 99;
          this.value = 50000;
          this.rare = (sbyte) 1;
          break;
        case 532:
          this.width = (ushort) 20;
          this.height = (ushort) 24;
          this.value = 100000;
          this.accessory = true;
          this.rare = (sbyte) 4;
          break;
        case 533:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 7;
          this.useTime = (byte) 7;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 10;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 11;
          this.damage = (short) 23;
          this.shootSpeed = 10f;
          this.noMelee = true;
          this.value = 300000;
          this.rare = (sbyte) 5;
          this.knockBack = 1f;
          this.ranged = true;
          break;
        case 534:
          this.knockBack = 6.5f;
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.width = (ushort) 50;
          this.height = (ushort) 14;
          this.shoot = (byte) 10;
          this.useAmmo = (byte) 14;
          this.useSound = (byte) 36;
          this.damage = (short) 18;
          this.shootSpeed = 6f;
          this.noMelee = true;
          this.value = 700000;
          this.rare = (sbyte) 4;
          this.ranged = true;
          break;
        case 535:
          this.width = (ushort) 12;
          this.height = (ushort) 18;
          this.value = 100000;
          this.accessory = true;
          this.rare = (sbyte) 4;
          break;
        case 536:
          this.width = (ushort) 12;
          this.height = (ushort) 18;
          this.value = 100000;
          this.rare = (sbyte) 4;
          this.accessory = true;
          break;
        case 537:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 28;
          this.useTime = (byte) 28;
          this.shootSpeed = 4.3f;
          this.knockBack = 4f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 29;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 97;
          this.rare = (sbyte) 4;
          this.value = 45000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 538:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 136;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 2000;
          this.mech = true;
          break;
        case 539:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 137;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 10000;
          this.mech = true;
          break;
        case 540:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 138;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.mech = true;
          break;
        case 541:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 135;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.placeStyle = (byte) 1;
          this.mech = true;
          this.value = 5000;
          break;
        case 542:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 135;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.placeStyle = (byte) 2;
          this.mech = true;
          this.value = 5000;
          break;
        case 543:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 135;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.placeStyle = (byte) 3;
          this.mech = true;
          this.value = 5000;
          break;
        case 544:
          this.useStyle = (byte) 4;
          this.width = (ushort) 22;
          this.height = (ushort) 14;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.maxStack = (short) 20;
          this.rare = (sbyte) 3;
          break;
        case 545:
          this.shootSpeed = 4f;
          this.shoot = (byte) 103;
          this.damage = (short) 14;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 3f;
          this.value = 80;
          this.ranged = true;
          this.rare = (sbyte) 3;
          break;
        case 546:
          this.shootSpeed = 5f;
          this.shoot = (byte) 104;
          this.damage = (short) 12;
          this.width = (ushort) 8;
          this.height = (ushort) 8;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 14;
          this.knockBack = 4f;
          this.value = 30;
          this.rare = (sbyte) 1;
          this.ranged = true;
          this.rare = (sbyte) 3;
          break;
        case 547:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 100000;
          this.rare = (sbyte) 5;
          break;
        case 548:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 100000;
          this.rare = (sbyte) 5;
          break;
        case 549:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 100000;
          this.rare = (sbyte) 5;
          break;
        case 550:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 22;
          this.useTime = (byte) 22;
          this.shootSpeed = 5.6f;
          this.knockBack = 6.4f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 42;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 105;
          this.rare = (sbyte) 5;
          this.value = 1500000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 551:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 15;
          this.bodySlot = (short) 24;
          this.rare = (sbyte) 5;
          this.value = 200000;
          break;
        case 552:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 11;
          this.legSlot = (short) 23;
          this.rare = (sbyte) 5;
          this.value = 150000;
          break;
        case 553:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 9;
          this.headSlot = (short) 41;
          this.rare = (sbyte) 5;
          this.value = 250000;
          break;
        case 554:
          this.width = (ushort) 20;
          this.height = (ushort) 24;
          this.value = 1500;
          this.accessory = true;
          this.rare = (sbyte) 4;
          break;
        case 555:
          this.width = (ushort) 20;
          this.height = (ushort) 24;
          this.value = 50000;
          this.accessory = true;
          this.rare = (sbyte) 4;
          break;
        case 556:
          this.useStyle = (byte) 4;
          this.width = (ushort) 22;
          this.height = (ushort) 14;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.maxStack = (short) 20;
          this.rare = (sbyte) 3;
          break;
        case 557:
          this.useStyle = (byte) 4;
          this.width = (ushort) 22;
          this.height = (ushort) 14;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.maxStack = (short) 20;
          this.rare = (sbyte) 3;
          break;
        case 558:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 5;
          this.headSlot = (short) 42;
          this.rare = (sbyte) 5;
          this.value = 250000;
          break;
        case 559:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.defense = (short) 24;
          this.headSlot = (short) 43;
          this.rare = (sbyte) 5;
          this.value = 250000;
          break;
        case 560:
          this.useStyle = (byte) 4;
          this.width = (ushort) 22;
          this.height = (ushort) 14;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.maxStack = (short) 20;
          this.rare = (sbyte) 1;
          break;
        case 561:
          this.melee = true;
          this.autoReuse = true;
          this.noMelee = true;
          this.useStyle = (byte) 1;
          this.shootSpeed = 13f;
          this.shoot = (byte) 106;
          this.damage = (short) 35;
          this.knockBack = 8f;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.useSound = (byte) 1;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 15;
          this.noUseGraphic = true;
          this.rare = (sbyte) 5;
          this.maxStack = (short) 5;
          this.value = 500000;
          break;
        case 562:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 0;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 563:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 564:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 2;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 565:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 3;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 566:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 4;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 567:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 5;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 568:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 6;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 569:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 7;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 570:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 8;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 571:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 9;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 572:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 10;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 573:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 11;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 574:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 12;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 3;
          this.value = 100000;
          this.accessory = true;
          break;
        case 575:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 1000;
          this.rare = (sbyte) 3;
          break;
        case 576:
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 3;
          this.value = 100000;
          this.accessory = true;
          break;
        case 577:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 140;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 578:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 19;
          this.useTime = (byte) 19;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 39;
          this.shootSpeed = 11f;
          this.noMelee = true;
          this.value = 200000;
          this.ranged = true;
          this.rare = (sbyte) 4;
          this.knockBack = 2.5f;
          break;
        case 579:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 7;
          this.shootSpeed = 36f;
          this.knockBack = 4.75f;
          this.width = (ushort) 20;
          this.height = (ushort) 12;
          this.damage = (short) 35;
          this.pick = (byte) 200;
          this.axe = (byte) 22;
          this.hammer = (byte) 85;
          this.useSound = (byte) 23;
          this.shoot = (byte) 107;
          this.rare = (sbyte) 4;
          this.value = 220000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          this.channel = true;
          break;
        case 580:
          this.mech = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 141;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 581:
          this.mech = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 142;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 582:
          this.mech = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 143;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 583:
          this.mech = true;
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 144;
          this.placeStyle = (byte) 0;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 50;
          break;
        case 584:
          this.mech = true;
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 144;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 50;
          break;
        case 585:
          this.mech = true;
          this.noWet = true;
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 99;
          this.consumable = true;
          this.createTile = (short) 144;
          this.placeStyle = (byte) 2;
          this.width = (ushort) 10;
          this.height = (ushort) 12;
          this.value = 50;
          break;
        case 586:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 145;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 587:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 29;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 588:
          this.width = (ushort) 18;
          this.height = (ushort) 12;
          this.headSlot = (short) 44;
          this.value = 150000;
          this.vanity = true;
          break;
        case 589:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.bodySlot = (short) 25;
          this.value = 150000;
          this.vanity = true;
          break;
        case 590:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.legSlot = (short) 24;
          this.value = 150000;
          this.vanity = true;
          break;
        case 591:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 146;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 592:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 30;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 593:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 147;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 594:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 148;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 595:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createWall = (short) 31;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          break;
        case 596:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 149;
          this.placeStyle = (byte) 0;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 500;
          break;
        case 597:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 149;
          this.placeStyle = (byte) 1;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 500;
          break;
        case 598:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.createTile = (short) 149;
          this.placeStyle = (byte) 2;
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.value = 500;
          break;
        case 599:
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.rare = (sbyte) 1;
          break;
        case 600:
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.rare = (sbyte) 1;
          break;
        case 601:
          this.width = (ushort) 12;
          this.height = (ushort) 12;
          this.rare = (sbyte) 1;
          break;
        case 602:
          this.useStyle = (byte) 4;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.width = (ushort) 28;
          this.height = (ushort) 28;
          this.rare = (sbyte) 2;
          break;
        case 603:
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 111;
          this.width = (ushort) 16;
          this.height = (ushort) 30;
          this.useSound = (byte) 2;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.value = 0;
          this.buffType = (byte) 40;
          break;
        case 604:
          this.width = (ushort) 26;
          this.height = (ushort) 18;
          this.defense = (short) 26;
          this.headSlot = (short) 45;
          this.rare = (sbyte) 5;
          this.value = 500000;
          break;
        case 605:
          this.width = (ushort) 26;
          this.height = (ushort) 22;
          this.defense = (short) 14;
          this.headSlot = (short) 46;
          this.rare = (sbyte) 5;
          this.value = 500000;
          break;
        case 606:
          this.width = (ushort) 22;
          this.height = (ushort) 20;
          this.defense = (short) 10;
          this.headSlot = (short) 47;
          this.rare = (sbyte) 5;
          this.value = 500000;
          break;
        case 607:
          this.width = (ushort) 26;
          this.height = (ushort) 18;
          this.defense = (short) 20;
          this.bodySlot = (short) 26;
          this.rare = (sbyte) 5;
          this.value = 1000000;
          break;
        case 608:
          this.width = (ushort) 30;
          this.height = (ushort) 18;
          this.defense = (short) 18;
          this.bodySlot = (short) 27;
          this.rare = (sbyte) 5;
          this.value = 1000000;
          break;
        case 609:
          this.width = (ushort) 30;
          this.height = (ushort) 28;
          this.defense = (short) 15;
          this.bodySlot = (short) 28;
          this.rare = (sbyte) 5;
          this.value = 1000000;
          break;
        case 610:
          this.width = (ushort) 22;
          this.height = (ushort) 18;
          this.defense = (short) 14;
          this.legSlot = (short) 25;
          this.rare = (sbyte) 5;
          this.value = 750000;
          break;
        case 611:
          this.width = (ushort) 22;
          this.height = (ushort) 18;
          this.defense = (short) 13;
          this.legSlot = (short) 26;
          this.rare = (sbyte) 5;
          this.value = 750000;
          break;
        case 612:
          this.width = (ushort) 22;
          this.height = (ushort) 18;
          this.defense = (short) 15;
          this.legSlot = (short) 27;
          this.rare = (sbyte) 5;
          this.value = 750000;
          break;
        case 613:
          this.autoReuse = true;
          this.useStyle = (byte) 1;
          this.useAnimation = (byte) 25;
          this.useTime = (byte) 25;
          this.knockBack = 4.6f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 55;
          this.scale = 1.15f;
          this.useSound = (byte) 1;
          this.rare = (sbyte) 5;
          this.value = 300000;
          this.melee = true;
          break;
        case 614:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.shootSpeed = 5.75f;
          this.knockBack = 6.7f;
          this.width = (ushort) 40;
          this.height = (ushort) 40;
          this.damage = (short) 50;
          this.scale = 1.1f;
          this.useSound = (byte) 1;
          this.shoot = (byte) 112;
          this.rare = (sbyte) 5;
          this.value = 2000000;
          this.noMelee = true;
          this.noUseGraphic = true;
          this.melee = true;
          break;
        case 615:
          this.useStyle = (byte) 5;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.width = (ushort) 14;
          this.height = (ushort) 32;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 35;
          this.shootSpeed = 10f;
          this.knockBack = 2.3f;
          this.alpha = (byte) 30;
          this.rare = (sbyte) 5;
          this.noMelee = true;
          this.scale = 1.1f;
          this.value = 60000;
          this.ranged = true;
          break;
        case 616:
          this.shootSpeed = 4.2f;
          this.shoot = (byte) 113;
          this.damage = (short) 16;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 3.1f;
          this.value = 90;
          this.ranged = true;
          this.rare = (sbyte) 4;
          break;
        case 617:
          this.useStyle = (byte) 5;
          this.autoReuse = true;
          this.useAnimation = (byte) 18;
          this.useTime = (byte) 18;
          this.width = (ushort) 50;
          this.height = (ushort) 18;
          this.shoot = (byte) 1;
          this.useAmmo = (byte) 1;
          this.useSound = (byte) 5;
          this.damage = (short) 42;
          this.shootSpeed = 12f;
          this.noMelee = true;
          this.value = 250000;
          this.ranged = true;
          this.rare = (sbyte) 5;
          this.knockBack = 2.65f;
          break;
        case 618:
          this.shootSpeed = 6.6f;
          this.shoot = (byte) 114;
          this.damage = (short) 12;
          this.width = (ushort) 10;
          this.height = (ushort) 28;
          this.maxStack = (short) 250;
          this.consumable = true;
          this.ammo = (byte) 1;
          this.knockBack = 8.2f;
          this.value = 150;
          this.rare = (sbyte) 3;
          this.ranged = true;
          break;
        case 619:
          this.useStyle = (byte) 4;
          this.width = (ushort) 26;
          this.height = (ushort) 26;
          this.consumable = true;
          this.useAnimation = (byte) 45;
          this.useTime = (byte) 45;
          this.maxStack = (short) 20;
          break;
        case 620:
          this.width = (ushort) 18;
          this.height = (ushort) 18;
          this.maxStack = (short) 250;
          this.value = 100000;
          this.rare = (sbyte) 5;
          break;
        case 621:
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 115;
          this.width = (ushort) 16;
          this.height = (ushort) 30;
          this.useSound = (byte) 2;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.value = 0;
          this.buffType = (byte) 40;
          break;
        case 622:
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 116;
          this.width = (ushort) 16;
          this.height = (ushort) 30;
          this.useSound = (byte) 2;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.value = 0;
          this.buffType = (byte) 40;
          break;
        case 623:
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 117;
          this.width = (ushort) 16;
          this.height = (ushort) 30;
          this.useSound = (byte) 2;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.value = 0;
          this.buffType = (byte) 40;
          break;
        case 624:
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 118;
          this.width = (ushort) 16;
          this.height = (ushort) 30;
          this.useSound = (byte) 2;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.value = 0;
          this.buffType = (byte) 40;
          break;
        case 625:
          this.damage = (short) 0;
          this.useStyle = (byte) 1;
          this.shoot = (byte) 119;
          this.width = (ushort) 16;
          this.height = (ushort) 30;
          this.useSound = (byte) 2;
          this.useAnimation = (byte) 20;
          this.useTime = (byte) 20;
          this.rare = (sbyte) 3;
          this.noMelee = true;
          this.value = 0;
          this.buffType = (byte) 40;
          break;
        case 626:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 13;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 627:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 14;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 628:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 15;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 629:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 16;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 630:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 17;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        case 631:
          this.useStyle = (byte) 1;
          this.useTurn = true;
          this.useAnimation = (byte) 15;
          this.useTime = (byte) 10;
          this.autoReuse = true;
          this.consumable = true;
          this.createTile = (short) 139;
          this.placeStyle = (byte) 18;
          this.width = (ushort) 24;
          this.height = (ushort) 24;
          this.rare = (sbyte) 4;
          this.value = 100000;
          this.accessory = true;
          break;
        default:
          this.active = (byte) 0;
          this.stack = (short) 0;
          break;
      }
      if (noMatCheck)
        return;
      this.checkMat();
    }

    public Color GetAlpha(Color newColor)
    {
      if ((int) this.type == 75)
        return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) newColor.A - (int) this.alpha);
      if ((int) this.type >= 119 && (int) this.type <= 122 || (int) this.type >= 198 && (int) this.type <= 203 || ((int) this.type == 217 || (int) this.type == 218 || ((int) this.type == 219 || (int) this.type == 220)))
        return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      if ((int) this.type == 520 || (int) this.type == 521 || ((int) this.type == 522 || (int) this.type == 547) || ((int) this.type == 548 || (int) this.type == 549 || (int) this.type == 575))
        return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 50);
      if ((int) this.type == 58 || (int) this.type == 184 || (int) this.type == 501)
        return new Color(200, 200, 200, 200);
      int num = 256 - (int) this.alpha;
      return new Color((int) newColor.R * num >> 8, (int) newColor.G * num >> 8, (int) newColor.B * num >> 8, (int) newColor.A - (int) this.alpha);
    }

    public Color GetAlphaInventory(Color newColor)
    {
      int num = 256 - (int) this.alpha;
      return new Color((int) newColor.R * num >> 8, (int) newColor.G * num >> 8, (int) newColor.B * num >> 8, (int) newColor.A - (int) this.alpha);
    }

    public Color GetColor(Color newColor)
    {
      return new Color((int) this.color.R - ((int) byte.MaxValue - (int) newColor.R), (int) this.color.G - ((int) byte.MaxValue - (int) newColor.G), (int) this.color.B - ((int) byte.MaxValue - (int) newColor.B), (int) this.color.A - ((int) byte.MaxValue - (int) newColor.A));
    }

    public static bool MechSpawn(int x, int y, int type)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      for (int index = 0; index < 196; ++index)
      {
        if ((int) Main.item[index].active != 0 && (int) Main.item[index].type == type)
        {
          ++num1;
          Vector2 vector2 = new Vector2((float) x, (float) y);
          float num4 = Main.item[index].position.X - vector2.X;
          float num5 = Main.item[index].position.Y - vector2.Y;
          float num6 = (float) ((double) num4 * (double) num4 + (double) num5 * (double) num5);
          if ((double) num6 < 640000.0)
          {
            ++num3;
            if ((double) num6 < 90000.0)
              ++num2;
          }
        }
      }
      return num2 < 3 && num3 < 6 && num1 < 10;
    }

    public unsafe void UpdateItem(int i)
    {
      float num1 = 0.1f;
      float num2 = 7f;
      if (this.wet)
      {
        num2 = 5f;
        num1 = 0.08f;
      }
      Vector2 vector2_1 = this.velocity;
      vector2_1.X *= 0.5f;
      vector2_1.Y *= 0.5f;
      if ((int) this.ownTime > 0 && (int) --this.ownTime == 0)
        this.ownIgnore = (byte) 8;
      if ((int) this.keepTime > 0)
        --this.keepTime;
      else if (this.isLocal() || Main.netMode != 1 && ((int) this.owner == 8 || (int) Main.player[(int) this.owner].active == 0))
        this.FindOwner(i);
      if (!this.beingGrabbed)
      {
        this.velocity.X *= 0.95f;
        if ((double) this.velocity.X < 0.100000001490116 && (double) this.velocity.X > -0.100000001490116)
          this.velocity.X = 0.0f;
        if ((int) this.type == 520 || (int) this.type == 521 || ((int) this.type == 547 || (int) this.type == 548) || ((int) this.type == 549 || (int) this.type == 575))
        {
          this.velocity.Y *= 0.95f;
          if ((double) this.velocity.Y < 0.100000001490116 && (double) this.velocity.Y > -0.100000001490116)
            this.velocity.Y = 0.0f;
        }
        else
        {
          this.velocity.Y += num1;
          if ((double) this.velocity.Y > (double) num2)
            this.velocity.Y = num2;
        }
        bool flag = Collision.LavaCollision(ref this.position, (int) this.width, (int) this.height);
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Item& local = @this;
        // ISSUE: explicit reference operation
        int num3 = (^local).lavaWet | flag ? 1 : 0;
        // ISSUE: explicit reference operation
        (^local).lavaWet = num3 != 0;
        if (Collision.WetCollision(ref this.position, (int) this.width, (int) this.height))
        {
          if (!this.wet)
          {
            if ((int) this.wetCount == 0)
            {
              this.wetCount = (byte) 20;
              if (!flag)
              {
                for (int index = 0; index < 8; ++index)
                {
                  Dust* dustPtr = Main.dust.NewDust((int) this.position.X - 6, (int) this.position.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 33, 0.0, 0.0, 0, new Color(), 1.0);
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
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y, 1);
              }
              else
              {
                for (int index = 0; index < 4; ++index)
                {
                  Dust* dustPtr = Main.dust.NewDust((int) this.position.X - 6, (int) this.position.Y + ((int) this.height >> 1) - 8, (int) this.width + 12, 24, 35, 0.0, 0.0, 0, new Color(), 1.0);
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
                Main.PlaySound(19, (int) this.position.X, (int) this.position.Y, 1);
              }
            }
            this.wet = true;
          }
        }
        else if (this.wet)
          this.wet = false;
        if ((int) this.wetCount > 0)
          --this.wetCount;
        if (this.wet)
        {
          Vector2 vector2_2 = this.velocity;
          Collision.TileCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height, false, false);
          if ((double) this.velocity.X != (double) vector2_2.X)
            vector2_1.X = this.velocity.X;
          if ((double) this.velocity.Y != (double) vector2_2.Y)
            vector2_1.Y = this.velocity.Y;
        }
        else
        {
          this.lavaWet = false;
          Collision.TileCollision(ref this.position, ref this.velocity, (int) this.width, (int) this.height, false, false);
        }
        if (this.lavaWet)
        {
          if ((int) this.type == 267)
          {
            if (Main.netMode != 1)
            {
              this.active = (byte) 0;
              this.type = (short) 0;
              this.stack = (short) 0;
              for (int npcId = 0; npcId < 196; ++npcId)
              {
                if ((int) Main.npc[npcId].type == 22 && (int) Main.npc[npcId].active != 0)
                {
                  NetMessage.SendNpcHurt(npcId, 8192, 10.0, (int) -Main.npc[npcId].direction, false);
                  Main.npc[npcId].StrikeNPC(8192, 10f, (int) -Main.npc[npcId].direction, false, false);
                  NPC.SpawnWOF(ref this.position, false);
                  break;
                }
              }
              NetMessage.CreateMessage2(21, (int) UI.main.myPlayer, i);
              NetMessage.SendMessage();
            }
          }
          else if (this.isLocal() && (int) this.type != 312 && ((int) this.type != 318 && (int) this.type != 173) && ((int) this.type != 174 && (int) this.type != 175 && (int) this.rare == 0))
          {
            this.active = (byte) 0;
            this.type = (short) 0;
            this.stack = (short) 0;
            NetMessage.CreateMessage2(21, (int) UI.main.myPlayer, i);
            NetMessage.SendMessage();
          }
        }
        if ((int) this.type == 520)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * UI.essScale;
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.5f * num4, 0.1f * num4, 0.25f * num4));
        }
        else if ((int) this.type == 521)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * UI.essScale;
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.25f * num4, 0.1f * num4, 0.5f * num4));
        }
        else if ((int) this.type == 547)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * UI.essScale;
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.5f * num4, 0.3f * num4, 0.05f * num4));
        }
        else if ((int) this.type == 548)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * UI.essScale;
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.1f * num4, 0.1f * num4, 0.6f * num4));
        }
        else if ((int) this.type == 575)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * UI.essScale;
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.1f * num4, 0.3f * num4, 0.5f * num4));
        }
        else if ((int) this.type == 549)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * UI.essScale;
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.1f * num4, 0.5f * num4, 0.2f * num4));
        }
        else if ((int) this.type == 58)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * (UI.essScale * 0.5f);
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.5f * num4, 0.1f * num4, 0.1f * num4));
        }
        else if ((int) this.type == 184)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * (UI.essScale * 0.5f);
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.1f * num4, 0.1f * num4, 0.5f * num4));
        }
        else if ((int) this.type == 522)
        {
          float num4 = (float) Main.rand.Next(90, 111) * 0.01f * (UI.essScale * 0.2f);
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.5f * num4, 1f * num4, 0.1f * num4));
        }
        else if ((int) this.type == 75 && Main.gameTime.dayTime)
        {
          int num4 = 0;
          while (num4 < 8 && IntPtr.Zero != (IntPtr) Main.dust.NewDust((int) this.position.X, (int) this.position.Y, (int) this.width, (int) this.height, 15, (double) this.velocity.X, (double) this.velocity.Y, 150, new Color(), 1.20000004768372))
            ++num4;
          for (int index = 0; index < 3; ++index)
            Gore.NewGore(this.position, this.velocity, Main.rand.Next(16, 18), 1.0);
          this.active = (byte) 0;
          this.type = (short) 0;
          this.stack = (short) 0;
          if (Main.netMode == 2)
          {
            NetMessage.CreateMessage2(21, (int) UI.main.myPlayer, i);
            NetMessage.SendMessage();
          }
        }
      }
      else
        this.beingGrabbed = false;
      if ((int) this.type == 501)
      {
        if (Main.rand.Next(6) == 0)
        {
          Dust* dustPtr = Main.dust.NewDust((int) this.position.X, (int) this.position.Y, (int) this.width, (int) this.height, 55, 0.0, 0.0, 200, this.color, 1.0);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->velocity.X *= 0.3f;
            dustPtr->velocity.Y *= 0.3f;
            dustPtr->scale *= 0.5f;
          }
        }
      }
      else if ((int) this.type == 8 || (int) this.type == 105)
      {
        if (!this.wet)
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(1f, 0.95f, 0.8f));
      }
      else if ((int) this.type == 523)
        Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.85f, 1f, 0.7f));
      else if ((int) this.type >= 427 && (int) this.type <= 432)
      {
        if (!this.wet)
        {
          Vector3 rgb;
          switch (this.type)
          {
            case (short) 427:
              rgb = new Vector3(0.1f, 0.2f, 1.1f);
              break;
            case (short) 428:
              rgb = new Vector3(1f, 0.1f, 0.1f);
              break;
            case (short) 429:
              rgb = new Vector3(0.0f, 1f, 0.1f);
              break;
            case (short) 430:
              rgb = new Vector3(0.9f, 0.0f, 0.9f);
              break;
            case (short) 431:
              rgb = new Vector3(1.3f, 1.3f, 1.3f);
              break;
            default:
              rgb = new Vector3(0.9f, 0.9f, 0.0f);
              break;
          }
          Lighting.addLight((int) this.position.X + ((int) this.width >> 1) >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, rgb);
        }
      }
      else if ((int) this.type == 41)
      {
        if (!this.wet)
          Lighting.addLight((int) this.position.X + (int) this.width >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(1f, 0.75f, 0.55f));
      }
      else if ((int) this.type == 616)
        Lighting.addLight((int) this.position.X + (int) this.width >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, this.wet ? new Vector3(0.25f, 0.5f, 0.5f) : new Vector3(0.5f, 1f, 1f));
      else if ((int) this.type == 282)
        Lighting.addLight((int) this.position.X + (int) this.width >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.7f, 1f, 0.8f));
      else if ((int) this.type == 286)
        Lighting.addLight((int) this.position.X + (int) this.width >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.7f, 0.8f, 1f));
      else if ((int) this.type == 331)
        Lighting.addLight((int) this.position.X + (int) this.width >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.55f, 0.75f, 0.6f));
      else if ((int) this.type == 183)
        Lighting.addLight((int) this.position.X + (int) this.width >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.15f, 0.45f, 0.9f));
      else if ((int) this.type == 75)
      {
        Lighting.addLight((int) this.position.X + (int) this.width >> 4, (int) this.position.Y + ((int) this.height >> 1) >> 4, new Vector3(0.8f, 0.7f, 0.1f));
        if (Main.rand.Next(32) == 0)
          Main.dust.NewDust((int) this.position.X, (int) this.position.Y, (int) this.width, (int) this.height, 58, (double) this.velocity.X * 0.5, (double) this.velocity.Y * 0.5, 150, new Color(), 1.20000004768372);
        else if (Main.rand.Next(64) == 0)
          Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1.0);
      }
      ++this.spawnTime;
      if (Main.netMode == 2 && !this.isLocal() && (int) ++this.release >= 300)
      {
        this.release = (ushort) 0;
        this.FindOwner(i);
      }
      if (this.wet)
      {
        this.position.X += vector2_1.X;
        this.position.Y += vector2_1.Y;
      }
      else
      {
        this.position.X += this.velocity.X;
        this.position.Y += this.velocity.Y;
      }
      if ((int) this.noGrabDelay <= 0)
        return;
      --this.noGrabDelay;
    }

    public static unsafe int NewItem(int X, int Y, int Width, int Height, int Type, int Stack = 1, bool noBroadcast = false, int pfix = 0)
    {
      int index1 = 200;
      if (Main.netMode != 1)
      {
        uint num1 = Item.lastItemIndex;
        uint num2 = Main.item[(IntPtr) num1].spawnTime;
        uint num3 = num1;
        for (int index2 = 199; index2 >= 0; --index2)
        {
          if ((int) Main.item[(IntPtr) num1].active == 0)
          {
            index1 = (int) num1;
            break;
          }
          else
          {
            if ((int) ++num1 == 200)
              num1 = 0U;
            uint num4 = Main.item[(IntPtr) num1].spawnTime;
            if (num4 > num2)
            {
              num2 = num4;
              num3 = num1;
            }
          }
        }
        if (index1 == 200)
          index1 = (int) num3;
        uint num5;
        if ((int) (num5 = num1 + 1U) == 200)
          num5 = 0U;
        Item.lastItemIndex = num5;
      }
      fixed (Item* objPtr = &Main.item[index1])
      {
        objPtr->SetDefaults(Type, Stack, false);
        objPtr->Prefix(pfix);
        objPtr->position.X = (float) (X + (Width - (int) objPtr->width >> 1));
        objPtr->position.Y = (float) (Y + (Height - (int) objPtr->height >> 1));
        objPtr->wet = Collision.WetCollision(ref objPtr->position, (int) objPtr->width, (int) objPtr->height);
        objPtr->velocity.X = (float) Main.rand.Next(-30, 31) * 0.1f;
        if (Type == 520 || Type == 521)
          objPtr->velocity.Y = (float) Main.rand.Next(-30, 31) * 0.1f;
        else
          objPtr->velocity.Y = (float) Main.rand.Next(-40, -15) * 0.1f;
        objPtr->spawnTime = 0U;
        if (!noBroadcast && Main.netMode != 1)
        {
          NetMessage.CreateMessage2(21, (int) UI.main.myPlayer, index1);
          NetMessage.SendMessage();
          objPtr->FindOwner(index1);
        }
      }
      return index1;
    }

    public unsafe void FindOwner(int whoAmI)
    {
      if ((int) this.keepTime > 0)
        return;
      int num1 = 8;
      int num2 = 1920;
      int num3 = (int) this.position.X - ((int) this.width >> 1);
      int num4 = (int) this.position.Y - (int) this.height;
      fixed (Item* pNewItem = &this)
      {
        for (int index = 0; index < 8; ++index)
        {
          if ((int) this.ownIgnore != index && (int) Main.player[index].active != 0 && Main.player[index].ItemSpace(pNewItem))
          {
            int num5 = Math.Abs(Main.player[index].aabb.X + 10 - num3) + Math.Abs(Main.player[index].aabb.Y + 21 - num4);
            if (num5 < num2)
            {
              num2 = num5;
              num1 = index;
            }
          }
        }
      }
      int index1 = (int) this.owner;
      if (num1 == index1)
        return;
      bool flag = this.isLocal();
      this.owner = (byte) num1;
      if ((!flag || Main.netMode < 1) && (index1 != 8 || Main.netMode != 2) && (int) Main.player[index1].active != 0 || (int) this.active == 0)
        return;
      NetMessage.CreateMessage1(22, whoAmI);
      NetMessage.SendMessage();
    }

    public bool IsNotTheSameAs(ref Item compareItem)
    {
      if ((int) this.netID == (int) compareItem.netID && (int) this.stack == (int) compareItem.stack)
        return (int) this.prefix != (int) compareItem.prefix;
      else
        return true;
    }

    public bool CanBePlacedInAmmoSlot()
    {
      if ((int) this.ammo <= 0)
        return (int) this.type == 530;
      else
        return true;
    }

    public bool CanBeAutoPlacedInEmptyAmmoSlot()
    {
      if ((int) this.type != 169 && (int) this.type != 75 && ((int) this.type != 23 && (int) this.type != 370))
        return (int) this.type != 408;
      else
        return false;
    }

    public bool CanBePlacedInCoinSlot()
    {
      if ((int) this.type >= 71)
        return (int) this.type <= 74;
      else
        return false;
    }

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
      NUM_TYPES,
    }
  }
}
