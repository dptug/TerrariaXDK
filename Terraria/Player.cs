// Type: Terraria.Player
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections;
using System.IO;
using Terraria.Achievements;
using Terraria.Leaderboards;

namespace Terraria
{
  public sealed class Player
  {
    private static readonly sbyte[] TARGET_SEARCH_DIR_RIGHT = new sbyte[180]
    {
      (sbyte) 20,
      (sbyte) 42,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) -16,
      (sbyte) 32,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) -16,
      (sbyte) 32,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 48,
      (sbyte) 32,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16
    };
    private static readonly sbyte[] TARGET_SEARCH_DIR_LEFT = new sbyte[180]
    {
      (sbyte) -16,
      (sbyte) 42,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 16,
      (sbyte) 32,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 16,
      (sbyte) 32,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) -48,
      (sbyte) 32,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) 0,
      (sbyte) 16,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16,
      (sbyte) 0,
      (sbyte) -16
    };
    public bool male = true;
    public Rectangle aabb = new Rectangle(0, 0, 20, 42);
    public short sign = (short) -1;
    public sbyte oldSelectedItem = (sbyte) -1;
    public float ghostDir = 1f;
    public Buff[] buff = new Buff[10];
    public short heldProj = (short) -1;
    public short breath = (short) 200;
    public Item[] armor = new Item[11];
    public Item[] inventory = new Item[49];
    public Chest bank = new Chest();
    public Chest safe = new Chest();
    public string characterName = "";
    public string name = "";
    public short head = (short) -1;
    public short body = (short) -1;
    public short legs = (short) -1;
    public Vector2 controlDir = new Vector2();
    public sbyte direction = (sbyte) 1;
    private float buffR = 1f;
    private float buffG = 1f;
    private float buffB = 1f;
    public float manaCost = 1f;
    public Vector2[] shadowPos = new Vector2[3];
    public short healthBarLife = (short) 100;
    public short statLifeMax = (short) 100;
    public short statLife = (short) 100;
    public sbyte gravDir = (sbyte) 1;
    public sbyte pet = (sbyte) -1;
    public short meleeCrit = (short) 4;
    public short rangedCrit = (short) 4;
    public short magicCrit = (short) 4;
    public float meleeDamage = 1f;
    public float rangedDamage = 1f;
    public float magicDamage = 1f;
    public float meleeSpeed = 1f;
    public float moveSpeed = 1f;
    public float pickSpeed = 1f;
    public int SpawnX = -1;
    public int SpawnY = -1;
    public short[] spX = new short[200];
    public short[] spY = new short[200];
    public string[] spN = new string[200];
    public int[] spI = new int[200];
    public Player.Adj[] adjTile = new Player.Adj[135];
    public Color hairColor = new Color(215, 90, 55);
    public Color skinColor = new Color((int) byte.MaxValue, 125, 90);
    public Color eyeColor = new Color(105, 90, 75);
    public Color shirtColor = new Color(175, 165, 140);
    public Color underShirtColor = new Color(160, 180, 215);
    public Color pantsColor = new Color((int) byte.MaxValue, 230, 175);
    public Color shoeColor = new Color(160, 105, 60);
    public sbyte grappleItemSlot = (sbyte) -1;
    public short[] grappling = new short[20];
    public short chest = (short) -1;
    public ushort potionDelayTime = (ushort) 3600;
    public short talkNPC = (short) -1;
    public short npcChatBubble = (short) -1;
    public BitArray itemsFound = new BitArray(632);
    public BitArray craftingStationsFound = new BitArray(135);
    public BitArray recipesFound = new BitArray(342);
    public BitArray recipesNew = new BitArray(342);
    public string oldName = "";
    private Vector2i[] smartLocation = new Vector2i[3];
    public const int MAX_PLAYERS = 8;
    public const int MAX_ARMOR = 11;
    public const int MAX_INVENTORY = 48;
    public const int MAX_HAIR = 36;
    public const int NUM_ARMOR_HEAD = 48;
    public const int NUM_ARMOR_BODY = 29;
    public const int NUM_ARMOR_LEGS = 28;
    public const int NAME_LEN = 16;
    public const int MAX_BUFFS = 10;
    public const short breathMax = (short) 200;
    private const int bodyFrameHeight = 56;
    private const int legFrameHeight = 56;
    public const ushort width = (ushort) 20;
    public const ushort height = (ushort) 42;
    public const int tileRangeX = 5;
    public const int tileRangeY = 4;
    private const float CURSOR_SPEED = 6f;
    private const int itemGrabRange = 38;
    private const float itemGrabSpeed = 0.45f;
    private const float itemGrabSpeedMax = 4f;
    private const int rocketTimeMax = 7;
    private const int SMART_RAYS = 3;
    public NetClient client;
    public WorldView view;
    public UI ui;
    public byte wings;
    public short wingTime;
    public byte wingFrame;
    public byte wingFrameCounter;
    public bool flapSound;
    public bool ghost;
    public byte ghostFrameCounter;
    public bool pvpDeath;
    public bool zoneDungeon;
    public bool zoneEvil;
    public bool zoneHoly;
    public bool zoneMeteor;
    public bool zoneJungle;
    public bool boneArmor;
    public float townNPCs;
    public Vector2 position;
    public Vector2 oldPosition;
    public Vector2 velocity;
    public float bodyFrameCounter;
    public float legFrameCounter;
    public short immuneTime;
    public short immuneAlpha;
    public sbyte immuneAlphaDirection;
    public bool immune;
    public byte team;
    public sbyte netSkip;
    public byte reuseDelay;
    private short maxRegenDelay;
    public sbyte selectedItem;
    public float activeNPCs;
    public short itemAnimation;
    public short itemAnimationMax;
    public byte itemTime;
    public byte noThrow;
    public short toolTime;
    public float itemRotation;
    public short itemWidth;
    public short itemHeight;
    public Vector2i itemLocation;
    public float ghostFade;
    public short breathCD;
    public bool socialShadow;
    public string setBonus;
    public float headRotation;
    public float bodyRotation;
    public float legRotation;
    public Vector2 headPosition;
    public Vector2 bodyPosition;
    public Vector2 legPosition;
    public Vector2 headVelocity;
    public Vector2 bodyVelocity;
    public Vector2 legVelocity;
    public bool dead;
    public short respawnTimer;
    public short attackCD;
    public ushort potionDelay;
    public byte difficulty;
    public bool wet;
    public byte wetCount;
    public bool lavaWet;
    public short hitTile;
    public short hitTileX;
    public short hitTileY;
    public int jump;
    private short bodyFrameY;
    private short legFrameY;
    public bool controlLeft;
    public bool controlRight;
    public bool controlUp;
    public bool controlDown;
    public bool controlJump;
    public bool controlUseItem;
    public bool controlUseTile;
    public bool controlThrow;
    public bool controlInv;
    public bool controlHook;
    public bool releaseJump;
    public bool releaseUseItem;
    public bool releaseUseTile;
    public bool releaseHook;
    public bool delayUseItem;
    public byte active;
    public byte whoAmI;
    public sbyte runSoundDelay;
    public bool fireWalk;
    public float shadow;
    public byte shadowCount;
    public bool channel;
    public short statDefense;
    public short statAttack;
    public short statMana;
    public short statManaMax;
    public short statManaMax2;
    public int lifeRegen;
    public int lifeRegenCount;
    public int lifeRegenTime;
    public int manaRegen;
    public int manaRegenCount;
    public int manaRegenDelay;
    public bool manaRegenBuff;
    public bool noKnockback;
    public bool spaceGun;
    public byte freeAmmoChance;
    public byte stickyBreak;
    public bool lightOrb;
    public bool fairy;
    public bool archery;
    public bool poisoned;
    public bool blind;
    public bool onFire;
    public bool onFire2;
    public bool noItems;
    public bool wereWolf;
    public bool wolfAcc;
    public bool rulerAcc;
    public bool bleed;
    public bool confused;
    public bool accMerman;
    public bool merman;
    public bool brokenArmor;
    public bool silence;
    public bool slow;
    public bool horrified;
    public bool tongued;
    public bool kbGlove;
    public bool starCloak;
    public bool longInvince;
    public bool manaFlower;
    public short tileTargetX;
    public short tileTargetY;
    public short tileInteractX;
    public short tileInteractY;
    private float relativeTargetX;
    private float relativeTargetY;
    public bool adjWater;
    public bool oldAdjWater;
    public byte hair;
    public bool hostile;
    public byte accWatch;
    public bool accCompass;
    public bool accDepthMeter;
    public bool accDivingHelm;
    public bool accFlipper;
    public bool doubleJump;
    public bool jumpAgain;
    public bool spawnMax;
    public byte blockRange;
    public byte grapCount;
    public sbyte rocketTime;
    public sbyte rocketDelay;
    public sbyte rocketDelay2;
    public bool rocketRelease;
    public bool rocketFrame;
    public byte rocketBoots;
    public bool canRocket;
    public bool jumpBoost;
    public bool noFallDmg;
    public byte swimTime;
    public bool killGuide;
    public bool lavaImmune;
    public bool gills;
    public bool slowFall;
    public bool findTreasure;
    public bool invis;
    public bool detectCreature;
    public bool nightVision;
    public bool enemySpawns;
    public bool thorns;
    public bool waterWalk;
    public bool gravControl;
    public short chestX;
    public short chestY;
    public short fallStart;
    private uint totalSunMoonTransitions;
    private byte hellAndBackState;
    public bool kill;
    public bool announced;

    static Player()
    {
    }

    public Player()
    {
      for (int index = 0; index <= 48; ++index)
      {
        if (index < 11)
          this.armor[index].Init();
        this.inventory[index].Init();
      }
      for (int index = 0; index < 20; ++index)
      {
        this.bank.item[index].Init();
        this.safe.item[index].Init();
      }
      this.grappling[0] = (short) -1;
      this.inventory[0].SetDefaults("Copper Shortsword");
      this.inventory[1].SetDefaults("Copper Pickaxe");
      this.inventory[2].SetDefaults("Copper Axe");
      this.InitKnownItems();
      this.InitKnownCraftingStations();
    }

    public void HealEffect(int healAmount)
    {
      CombatText.NewText(this.position, 20, 42, healAmount, false);
      if (!this.isLocal())
        return;
      NetMessage.CreateMessage2(35, (int) this.whoAmI, healAmount);
      NetMessage.SendMessage();
    }

    public void ManaEffect(int manaAmount)
    {
      CombatText.NewText(this.position, 20, 42, manaAmount, false);
      if (!this.isLocal())
        return;
      NetMessage.CreateMessage2(43, (int) this.whoAmI, manaAmount);
      NetMessage.SendMessage();
    }

    public static Player FindClosest(ref Rectangle rect)
    {
      Player player1 = (Player) null;
      int num1 = int.MaxValue;
      for (int index = 0; index < 8; ++index)
      {
        Player player2 = Main.player[index];
        if ((int) player2.active != 0 && !player2.dead)
        {
          int num2 = Math.Abs(player2.aabb.X + 10 - (rect.X + (rect.Width >> 1))) + Math.Abs(player2.aabb.Y + 21 - (rect.Y + (rect.Height >> 1)));
          if (num2 < num1)
          {
            num1 = num2;
            player1 = player2;
          }
        }
      }
      if (player1 == null)
      {
        for (int index = 0; index < 8; ++index)
        {
          player1 = Main.player[index];
          if ((int) player1.active != 0)
            break;
        }
      }
      return player1;
    }

    public void toggleInv()
    {
      if ((int) this.ui.inventoryMode > 0)
      {
        Main.PlaySound(11);
        this.ui.CloseInventory();
      }
      else if ((int) this.talkNPC >= 0)
      {
        this.talkNPC = (short) -1;
        this.ui.npcChatText = (UserString) null;
        Main.PlaySound(11);
      }
      else if ((int) this.sign >= 0)
      {
        this.sign = (short) -1;
        this.ui.editSign = false;
        this.ui.npcChatText = (UserString) null;
        Main.PlaySound(11);
      }
      else
      {
        Main.PlaySound(10);
        this.ui.OpenInventory();
      }
    }

    public void dropItemCheck()
    {
      if ((int) this.ui.inventoryMode == 0)
        this.noThrow = (byte) 0;
      else if ((int) this.noThrow > 0)
        --this.noThrow;
      if ((int) this.noThrow != 0 || (!this.controlThrow || (int) this.inventory[(int) this.selectedItem].type <= 0) && ((int) this.ui.inventoryMode != 0 && !this.ui.IsButtonUntriggered(Buttons.X) || ((int) this.ui.mouseItem.type <= 0 || (int) this.ui.mouseItem.stack <= 0)))
        return;
      Item obj = new Item();
      bool flag = false;
      if (((int) this.ui.inventoryMode == 0 || this.ui.IsButtonUntriggered(Buttons.X)) && ((int) this.ui.mouseItem.type > 0 && (int) this.ui.mouseItem.stack > 0))
      {
        obj = this.inventory[(int) this.selectedItem];
        this.inventory[(int) this.selectedItem] = this.ui.mouseItem;
        this.delayUseItem = true;
        this.controlUseItem = false;
        flag = true;
      }
      int number2 = Item.NewItem(this.aabb.X, this.aabb.Y, 20, 42, (int) this.inventory[(int) this.selectedItem].type, 1, true, 0);
      if (!flag && (int) this.inventory[(int) this.selectedItem].type == 8 && (int) this.inventory[(int) this.selectedItem].stack > 1)
      {
        --this.inventory[(int) this.selectedItem].stack;
      }
      else
      {
        this.inventory[(int) this.selectedItem].position = Main.item[number2].position;
        Main.item[number2] = this.inventory[(int) this.selectedItem];
        this.inventory[(int) this.selectedItem].Init();
      }
      Main.item[number2].noGrabDelay = (byte) 100;
      Main.item[number2].velocity.Y = -2f;
      Main.item[number2].velocity.X = (float) (4 * (int) this.direction) + this.velocity.X;
      if ((int) this.ui.mouseItem.type > 0 && ((int) this.ui.inventoryMode == 0 || this.ui.IsButtonUntriggered(Buttons.X)))
      {
        this.inventory[(int) this.selectedItem] = obj;
        this.ui.mouseItem.Init();
      }
      NetMessage.CreateMessage2(21, (int) this.ui.myPlayer, number2);
      NetMessage.SendMessage();
    }

    public void AddBuff(int type, int time, bool quiet = true)
    {
      if (!quiet)
      {
        NetMessage.CreateMessage3(55, (int) this.whoAmI, type, time);
        NetMessage.SendMessage();
      }
      for (int index = 0; index < 10; ++index)
      {
        if ((int) this.buff[index].Type == type)
        {
          if ((int) this.buff[index].Time >= time)
            return;
          this.buff[index].Time = (ushort) time;
          return;
        }
      }
      while (true)
      {
        int b = -1;
        for (int index = 0; index < 10; ++index)
        {
          if (!this.buff[index].IsDebuff())
          {
            b = index;
            break;
          }
        }
        if (b != -1)
        {
          for (int index = b; index < 10; ++index)
          {
            if ((int) this.buff[index].Type == 0)
            {
              this.buff[index].Type = (ushort) type;
              this.buff[index].Time = (ushort) time;
              return;
            }
          }
          this.DelBuff(b);
        }
        else
          break;
      }
    }

    public void DelBuff(Buff.ID id)
    {
      for (int b = 0; b < 10; ++b)
      {
        if ((Buff.ID) this.buff[b].Type == id)
        {
          this.DelBuff(b);
          break;
        }
      }
    }

    public int DelBuff(int b)
    {
      if ((int) this.buff[b].Type == 40)
        this.pet = (sbyte) -1;
      this.buff[b].Type = (ushort) 0;
      this.buff[b].Time = (ushort) 0;
      int num = b + 1;
      for (int index1 = 0; index1 < 9; ++index1)
      {
        if ((int) this.buff[index1].Time == 0 || (int) this.buff[index1].Type == 0)
        {
          if (index1 < num)
            --num;
          for (int index2 = index1 + 1; index2 < 10; ++index2)
          {
            this.buff[index2 - 1] = this.buff[index2];
            this.buff[index2].Time = (ushort) 0;
            this.buff[index2].Type = (ushort) 0;
          }
        }
      }
      return num;
    }

    public bool canUseMana()
    {
      return (int) this.statMana < (int) this.statManaMax;
    }

    public bool canHeal()
    {
      return (int) this.statLife < (int) this.statLifeMax;
    }

    public void QuickMana()
    {
      if (this.noItems || (int) this.statMana == (int) this.statManaMax2)
        return;
      for (int index = 0; index < 48; ++index)
      {
        if ((int) this.inventory[index].stack > 0 && (int) this.inventory[index].type > 0 && (int) this.inventory[index].healMana > 0 && ((int) this.potionDelay == 0 || !this.inventory[index].potion))
        {
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, (int) this.inventory[index].useSound);
          if (this.inventory[index].potion)
          {
            this.potionDelay = this.potionDelayTime;
            this.AddBuff(21, (int) this.potionDelay, true);
          }
          this.statLife += this.inventory[index].healLife;
          this.statMana += this.inventory[index].healMana;
          if ((int) this.statLife > (int) this.statLifeMax)
            this.statLife = this.statLifeMax;
          if ((int) this.statMana > (int) this.statManaMax2)
            this.statMana = this.statManaMax2;
          if (this.isLocal())
          {
            if ((int) this.inventory[index].healLife > 0)
              this.HealEffect((int) this.inventory[index].healLife);
            if ((int) this.inventory[index].healMana > 0)
              this.ManaEffect((int) this.inventory[index].healMana);
          }
          if ((int) --this.inventory[index].stack > 0)
            break;
          this.inventory[index].Init();
          break;
        }
      }
    }

    public void ApplyProjectileBuffPvP(int type)
    {
      if (type == 2)
      {
        if (Main.rand.Next(3) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 15)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(24, 300, false);
      }
      else if (type == 19)
      {
        if (Main.rand.Next(5) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 33)
      {
        if (Main.rand.Next(5) != 0)
          return;
        this.AddBuff(20, 420, false);
      }
      else if (type == 34)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(24, 240, false);
      }
      else if (type == 35)
      {
        if (Main.rand.Next(4) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 54)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(20, 600, false);
      }
      else if (type == 63)
      {
        if (Main.rand.Next(3) == 0)
          return;
        this.AddBuff(31, 120, true);
      }
      else if (type == 85)
      {
        this.AddBuff(24, 1200, false);
      }
      else
      {
        if (type != 95 && type != 103 && type != 104)
          return;
        this.AddBuff(39, 420, true);
      }
    }

    public void ApplyProjectileBuff(int type)
    {
      if (type == 55)
      {
        if (Main.rand.Next(3) != 0)
          return;
        this.AddBuff(20, 600, true);
      }
      else if (type == 44)
      {
        if (Main.rand.Next(3) != 0)
          return;
        this.AddBuff(22, 900, true);
      }
      else if (type == 82)
      {
        if (Main.rand.Next(3) != 0)
          return;
        this.AddBuff(24, 420, true);
      }
      else if (type == 96 || type == 101)
      {
        if (Main.rand.Next(3) != 0)
          return;
        this.AddBuff(39, 480, true);
      }
      else
      {
        if (type != 98)
          return;
        this.AddBuff(20, 600, true);
      }
    }

    public void ApplyWeaponBuffPvP(int type)
    {
      if (type == 121)
      {
        if (Main.rand.Next(2) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 122)
      {
        if (Main.rand.Next(10) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else if (type == 190 || type == 614)
      {
        if (Main.rand.Next(4) != 0)
          return;
        this.AddBuff(20, 420, false);
      }
      else if (type == 217)
      {
        if (Main.rand.Next(5) != 0)
          return;
        this.AddBuff(24, 180, false);
      }
      else
      {
        if (type != 613 || Main.rand.Next(5) != 0)
          return;
        this.AddBuff(30, 600, false);
      }
    }

    private unsafe void FireEffect(int particleType)
    {
      this.buffB *= 0.6f;
      this.buffG *= 0.7f;
      if (Main.rand.Next(4) != 0)
        return;
      Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 2, this.aabb.Y - 2, 24, 46, particleType, (double) this.velocity.X * 0.400000005960464, (double) this.velocity.Y * 0.400000005960464, 100, new Color(), 3.0);
      if ((IntPtr) dustPtr == IntPtr.Zero)
        return;
      dustPtr->noGravity = true;
      dustPtr->velocity.X *= 1.8f;
      dustPtr->velocity.Y *= 1.8f;
      dustPtr->velocity.Y -= 0.5f;
    }

    private void Dead()
    {
      this.wings = (byte) 0;
      this.poisoned = false;
      this.onFire = false;
      this.onFire2 = false;
      this.blind = false;
      this.gravDir = (sbyte) 1;
      for (int index = 0; index < 10; ++index)
      {
        this.buff[index].Time = (ushort) 0;
        this.buff[index].Type = (ushort) 0;
      }
      if (this.isLocal() && !this.ui.editSign)
        this.sign = (short) -1;
      if (this.isLocal() && (int) this.sign < 0)
        this.ui.npcChatText = (UserString) null;
      this.grappling[0] = (short) -1;
      this.grappling[1] = (short) -1;
      this.grappling[2] = (short) -1;
      this.talkNPC = (short) -1;
      this.statLife = (short) 0;
      this.channel = false;
      this.potionDelay = (ushort) 0;
      this.chest = (short) -1;
      this.itemAnimation = (short) 0;
      this.immuneAlpha += (short) 2;
      if ((int) this.immuneAlpha > (int) byte.MaxValue)
        this.immuneAlpha = (short) byte.MaxValue;
      this.headPosition += this.headVelocity;
      this.bodyPosition += this.bodyVelocity;
      this.legPosition += this.legVelocity;
      this.headRotation += this.headVelocity.X * 0.1f;
      this.bodyRotation += this.bodyVelocity.X * 0.1f;
      this.legRotation += this.legVelocity.X * 0.1f;
      this.headVelocity.Y += 0.1f;
      this.bodyVelocity.Y += 0.1f;
      this.legVelocity.Y += 0.1f;
      this.headVelocity.X *= 0.99f;
      this.bodyVelocity.X *= 0.99f;
      this.legVelocity.X *= 0.99f;
      if (!this.isLocal() || (int) --this.respawnTimer > 0 && !this.ui.IsButtonTriggered(Buttons.A))
        return;
      this.ui.ClearButtonTriggers();
      if ((int) this.difficulty == 2)
      {
        this.ghost = true;
      }
      else
      {
        if ((int) this.ui.mouseItem.type > 0)
          this.ui.OpenInventory();
        this.Spawn();
      }
    }

    public void Ghost()
    {
      this.hellAndBackState = (byte) 0;
      this.immune = false;
      this.immuneAlpha = (short) 0;
      this.controlUp = false;
      this.controlLeft = false;
      this.controlDown = false;
      this.controlRight = false;
      this.controlJump = false;
      if (Main.hasFocus && this.ui.menuType == MenuType.NONE && (int) this.sign < 0)
      {
        if ((double) this.ui.gpState.ThumbSticks.Left.Y < -0.125)
          this.controlDown = true;
        else if ((double) this.ui.gpState.ThumbSticks.Left.Y > 0.125)
          this.controlUp = true;
        if ((double) this.ui.gpState.ThumbSticks.Left.X < -0.125)
          this.controlLeft = true;
        else if ((double) this.ui.gpState.ThumbSticks.Left.X > 0.125)
          this.controlRight = true;
        if (this.ui.gpState.IsButtonDown(Buttons.A) || this.ui.gpState.IsButtonDown(this.ui.BTN_JUMP2))
          this.controlJump = true;
      }
      if (this.controlUp || this.controlJump)
      {
        if ((double) this.velocity.Y > 0.0)
          this.velocity.Y *= 0.9f;
        this.velocity.Y -= 0.1f;
        if ((double) this.velocity.Y < -3.0)
          this.velocity.Y = -3f;
      }
      else if (this.controlDown)
      {
        if ((double) this.velocity.Y < 0.0)
          this.velocity.Y *= 0.9f;
        this.velocity.Y += 0.1f;
        if ((double) this.velocity.Y > 3.0)
          this.velocity.Y = 3f;
      }
      else if ((double) this.velocity.Y < -0.1 || (double) this.velocity.Y > 0.1)
        this.velocity.Y *= 0.9f;
      else
        this.velocity.Y = 0.0f;
      if (this.controlLeft && !this.controlRight)
      {
        if ((double) this.velocity.X > 0.0)
          this.velocity.X *= 0.9f;
        this.velocity.X -= 0.1f;
        if ((double) this.velocity.X < -3.0)
          this.velocity.X = -3f;
      }
      else if (this.controlRight && !this.controlLeft)
      {
        if ((double) this.velocity.X < 0.0)
          this.velocity.X *= 0.9f;
        this.velocity.X += 0.1f;
        if ((double) this.velocity.X > 3.0)
          this.velocity.X = 3f;
      }
      else if ((double) this.velocity.X < -0.100000001490116 || (double) this.velocity.X > 0.100000001490116)
        this.velocity.X *= 0.9f;
      else
        this.velocity.X = 0.0f;
      this.position.X += this.velocity.X;
      this.position.Y += this.velocity.Y;
      if ((double) this.velocity.X < 0.0)
        this.direction = (sbyte) -1;
      else if ((double) this.velocity.X > 0.0)
        this.direction = (sbyte) 1;
      ++this.ghostFrameCounter;
      if ((double) this.position.X < 560.0)
      {
        this.position.X = 560f;
        this.velocity.X = 0.0f;
      }
      else if ((double) this.position.X + 20.0 > (double) (Main.rightWorld - 544 - 32))
      {
        this.position.X = (float) (Main.rightWorld - 544 - 32 - 20);
        this.velocity.X = 0.0f;
      }
      if ((double) this.position.Y < 560.0)
      {
        this.position.Y = 560f;
        if ((double) this.velocity.Y < -0.1)
          this.velocity.Y = -0.1f;
      }
      else if ((double) this.position.Y > (double) (Main.bottomWorld - 544 - 32 - 42))
      {
        this.position.Y = (float) (Main.bottomWorld - 544 - 32 - 42);
        this.velocity.Y = 0.0f;
      }
      this.aabb.X = (int) this.position.X;
      this.aabb.Y = (int) this.position.Y;
    }

    private void UpdateTileInteractionLocation()
    {
      this.tileInteractX = (short) 0;
      this.tileInteractY = (short) 0;
      if (this.ui.smartCursor)
      {
        int x = this.aabb.X;
        int y = this.aabb.Y;
        int num1 = 0;
        sbyte[] numArray1 = (int) this.direction > 0 ? Player.TARGET_SEARCH_DIR_RIGHT : Player.TARGET_SEARCH_DIR_LEFT;
        bool flag;
        do
        {
          int num2 = x;
          sbyte[] numArray2 = numArray1;
          int index1 = num1;
          int num3 = 1;
          int num4 = index1 + num3;
          int num5 = (int) numArray2[index1];
          x = num2 + num5;
          int num6 = y;
          sbyte[] numArray3 = numArray1;
          int index2 = num4;
          int num7 = 1;
          num1 = index2 + num7;
          int num8 = (int) numArray3[index2];
          y = num6 + num8;
          flag = this.CanInteractWithTile(x, y);
        }
        while (!flag && num1 < Player.TARGET_SEARCH_DIR_RIGHT.Length);
        if (!flag)
          return;
        this.tileInteractX = (short) (x >> 4);
        this.tileInteractY = (short) (y >> 4);
      }
      else
      {
        if (!this.CanInteractWithTile((int) this.tileTargetX << 4, (int) this.tileTargetY << 4))
          return;
        this.tileInteractX = this.tileTargetX;
        this.tileInteractY = this.tileTargetY;
      }
    }

    public bool CanInteractWithNPC()
    {
      switch (Main.tile[(int) this.tileInteractX, (int) this.tileInteractY].type)
      {
        case (byte) 10:
        case (byte) 11:
          return false;
        default:
          this.tileInteractX = (short) 0;
          this.tileInteractY = (short) 0;
          return true;
      }
    }

    public unsafe void UpdatePlayer(int i)
    {
      float num1 = 10f;
      float num2 = 0.4f;
      int num3 = 15;
      float num4 = 5.01f;
      if (this.wet)
      {
        if (this.merman)
        {
          num2 = 0.3f;
          num1 = 7f;
        }
        else
        {
          num2 = 0.2f;
          num1 = 5f;
          num3 = 30;
          num4 = 6.01f;
        }
      }
      float num5 = 3f;
      float num6 = 0.08f;
      float num7 = num5;
      this.heldProj = (short) -1;
      float num8 = (float) Main.maxTilesX / 4200f;
      float num9 = (float) ((double) this.position.Y * (1.0 / 16.0) - (60.0 + 10.0 * (double) (num8 * num8))) / (float) (Main.worldSurface / 6);
      if ((double) num9 < 0.25)
        num9 = 0.25f;
      else if ((double) num9 > 1.0)
        num9 = 1f;
      float num10 = num2 * num9;
      if ((int) this.statManaMax2 > 0)
        this.maxRegenDelay = (short) ((int) ((1.0 - (double) this.statMana / (double) this.statManaMax2) * 60.0 * 4.0) + 45);
      if ((int) ++this.shadowCount == 1)
        this.shadowPos[2] = this.shadowPos[1];
      else if ((int) this.shadowCount == 2)
      {
        this.shadowPos[1] = this.shadowPos[0];
      }
      else
      {
        this.shadowCount = (byte) 0;
        this.shadowPos[0] = this.position;
      }
      if ((int) this.potionDelay > 0)
        --this.potionDelay;
      if ((int) this.runSoundDelay > 0)
        --this.runSoundDelay;
      if ((int) this.itemAnimation == 0)
        this.attackCD = (short) 0;
      else if ((int) this.attackCD > 0)
        --this.attackCD;
      if (this.isLocal())
      {
        UI.current = this.ui;
        this.zoneEvil = this.view.evilTiles >= 200;
        this.zoneHoly = this.view.holyTiles >= 100;
        this.zoneMeteor = this.view.meteorTiles >= 50;
        this.zoneDungeon = false;
        if (this.view.dungeonTiles >= 250 && (double) this.position.Y > (double) Main.worldSurfacePixels)
        {
          int index1 = this.aabb.X >> 4;
          int index2 = this.aabb.Y >> 4;
          int index3 = (int) Main.tile[index1, index2].wall;
          if (index3 > 0 && !Main.wallHouse[index3])
            this.zoneDungeon = true;
        }
        this.zoneJungle = this.view.jungleTiles >= 80;
      }
      if (this.ghost)
        this.Ghost();
      else if (this.dead)
      {
        this.Dead();
      }
      else
      {
        if (this.isLocal())
        {
          this.controlUp = false;
          this.controlLeft = false;
          this.controlDown = false;
          this.controlRight = false;
          bool flag1 = !this.controlJump;
          this.controlJump = false;
          this.controlUseItem = false;
          bool flag2 = !this.controlUseTile;
          this.controlUseTile = false;
          this.controlThrow = false;
          this.controlInv = false;
          this.controlHook = false;
          if (Main.hasFocus && this.ui.menuType == MenuType.NONE)
          {
            this.controlInv = (int) this.ui.inventoryMode > 0 ? this.ui.IsButtonTriggered(Buttons.B) : this.ui.IsButtonUntriggered(Buttons.Y);
            if (this.controlInv)
              this.toggleInv();
            if ((int) this.ui.inventoryMode == 0)
            {
              if ((int) this.sign < 0 && (int) this.talkNPC < 0)
              {
                GamePadThumbSticks thumbSticks = this.ui.gpState.ThumbSticks;
                if ((double) thumbSticks.Left.Y < -0.5)
                {
                  this.controlDown = true;
                }
                else
                {
                  thumbSticks = this.ui.gpState.ThumbSticks;
                  if ((double) thumbSticks.Left.Y > 0.5)
                    this.controlUp = true;
                }
                thumbSticks = this.ui.gpState.ThumbSticks;
                if ((double) thumbSticks.Left.X < -0.125)
                {
                  this.controlLeft = true;
                }
                else
                {
                  thumbSticks = this.ui.gpState.ThumbSticks;
                  if ((double) thumbSticks.Left.X > 0.125)
                    this.controlRight = true;
                }
                if (this.ui.gpState.IsButtonDown(this.ui.BTN_GRAPPLE))
                  this.controlHook = true;
                if (this.ui.gpState.IsButtonDown(Buttons.RightTrigger))
                  this.controlUseItem = true;
                else if ((int) this.itemTime == 0 && (int) this.itemAnimation == 0)
                {
                  if (this.ui.IsButtonTriggered(Buttons.LeftShoulder))
                  {
                    this.ui.hotbarItemNameTime = 210;
                    if ((int) this.oldSelectedItem >= 0)
                    {
                      this.selectedItem = this.oldSelectedItem;
                      this.oldSelectedItem = (sbyte) -1;
                    }
                    if ((int) --this.selectedItem < 0)
                      this.selectedItem += (sbyte) 10;
                    Main.PlaySound(12);
                  }
                  else if (this.ui.IsButtonTriggered(Buttons.RightShoulder))
                  {
                    this.ui.hotbarItemNameTime = 210;
                    if ((int) this.oldSelectedItem >= 0)
                    {
                      this.selectedItem = this.oldSelectedItem;
                      this.oldSelectedItem = (sbyte) -1;
                    }
                    if ((int) ++this.selectedItem >= 10)
                      this.selectedItem -= (sbyte) 10;
                    Main.PlaySound(12);
                  }
                  else
                  {
                    int index = this.ui.UpdateQuickAccess();
                    if (index >= 0)
                    {
                      if ((index > 9 || this.inventory[index].potion) && (int) this.oldSelectedItem < 0)
                        this.oldSelectedItem = this.selectedItem;
                      this.selectedItem = (sbyte) index;
                      if (index >= 0)
                      {
                        this.ui.hotbarItemNameTime = 210;
                        this.ui.quickAccessDisplayTime = 120;
                        if (this.inventory[index].potion)
                          this.controlUseItem = true;
                      }
                    }
                    else if ((int) this.oldSelectedItem >= 0 && ((int) this.inventory[(int) this.selectedItem].type == 0 || this.inventory[(int) this.selectedItem].potion))
                    {
                      this.selectedItem = this.oldSelectedItem;
                      this.oldSelectedItem = (sbyte) -1;
                    }
                  }
                }
                this.controlThrow = this.ui.IsButtonTriggered(Buttons.X);
                if (this.ui.IsJumpButtonDown())
                  this.controlJump = !flag1 || this.ui.WasJumpButtonUp();
                if (this.ui.gpState.IsButtonDown(Buttons.B))
                  this.controlUseTile = !flag2 || this.ui.gpPrevState.IsButtonUp(Buttons.B);
              }
              else if ((int) this.sign != -1 || this.ui.npcChatText != null)
                this.ui.UpdateNpcChat();
              if (this.confused)
              {
                bool flag3 = this.controlLeft;
                this.controlLeft = this.controlRight;
                this.controlRight = flag3;
                bool flag4 = this.controlUp;
                this.controlUp = this.controlRight;
                this.controlDown = flag4;
              }
              if ((int) this.chest != -1)
              {
                int num11 = this.aabb.X + 10 >> 4;
                int num12 = this.aabb.Y + 21 >> 4;
                if (num11 < (int) this.chestX - 5 || num11 > (int) this.chestX + 6 || (num12 < (int) this.chestY - 4 || num12 > (int) this.chestY + 5) || (int) Main.tile[(int) this.chestX, (int) this.chestY].active == 0)
                {
                  Main.PlaySound(11);
                  this.chest = (short) -1;
                }
              }
            }
            if (this.delayUseItem)
            {
              this.delayUseItem = this.controlUseItem;
              this.controlUseItem = false;
            }
            if ((int) this.itemAnimation == 0 && (int) this.itemTime == 0)
              this.dropItemCheck();
          }
          if (Main.netMode >= 1)
          {
            NetPlayer netPlayer = this.ui.netPlayer;
            bool flag3 = false;
            if ((int) this.statLife != (int) netPlayer.statLife || (int) this.statLifeMax != (int) netPlayer.statLifeMax)
            {
              netPlayer.statLife = this.statLife;
              netPlayer.statLifeMax = this.statLifeMax;
              NetMessage.CreateMessage1(16, i);
              NetMessage.SendMessage();
              flag3 = true;
            }
            if ((int) this.statMana != (int) netPlayer.statMana || (int) this.statManaMax != (int) netPlayer.statManaMax)
            {
              netPlayer.statMana = this.statMana;
              netPlayer.statManaMax = this.statManaMax;
              NetMessage.CreateMessage1(42, i);
              NetMessage.SendMessage();
              flag3 = true;
            }
            if (this.controlUp != netPlayer.controlUp)
            {
              netPlayer.controlUp = this.controlUp;
              flag3 = true;
            }
            if (this.controlDown != netPlayer.controlDown)
            {
              netPlayer.controlDown = this.controlDown;
              flag3 = true;
            }
            if (this.controlLeft != netPlayer.controlLeft)
            {
              netPlayer.controlLeft = this.controlLeft;
              flag3 = true;
            }
            if (this.controlRight != netPlayer.controlRight)
            {
              netPlayer.controlRight = this.controlRight;
              flag3 = true;
            }
            if (this.controlJump != netPlayer.controlJump)
            {
              netPlayer.controlJump = this.controlJump;
              flag3 = true;
            }
            if (this.controlUseItem != netPlayer.controlUseItem)
            {
              netPlayer.controlUseItem = this.controlUseItem;
              flag3 = true;
            }
            if ((int) this.selectedItem != (int) netPlayer.selectedItem)
            {
              netPlayer.selectedItem = this.selectedItem;
              flag3 = true;
            }
            if (flag3)
            {
              NetMessage.CreateMessage1(13, i);
              NetMessage.SendMessage();
            }
          }
          if ((double) this.velocity.Y == 0.0)
          {
            if (!this.noFallDmg && (int) this.wings == 0)
            {
              int num11 = ((this.aabb.Y >> 4) - (int) this.fallStart) * (int) this.gravDir - 25;
              if (num11 > 0)
              {
                this.immune = false;
                this.Hurt(num11 * 10, 0, false, false, Lang.deathMsg(-1, 0, 0, 0), false);
              }
            }
            this.fallStart = (short) (this.aabb.Y >> 4);
          }
          else if (this.jump > 0 || (int) this.rocketDelay > 0 || (this.wet || this.slowFall) || ((double) num9 < 0.8 || this.tongued))
            this.fallStart = (short) (this.aabb.Y >> 4);
          if ((int) this.ui.inventoryMode > 0)
            this.delayUseItem = true;
          this.tileTargetX = (short) ((int) this.ui.mouseX + this.view.screenPosition.X >> 4);
          this.tileTargetY = (short) ((int) this.ui.mouseY + this.view.screenPosition.Y >> 4);
          this.UpdateTileInteractionLocation();
        }
        if (this.immune)
        {
          if ((int) --this.immuneTime <= 0)
            this.immune = false;
          this.immuneAlpha = (short) ((int) this.immuneAlpha + (int) this.immuneAlphaDirection * 50);
          if ((int) this.immuneAlpha <= 50)
            this.immuneAlphaDirection = (sbyte) 1;
          else if ((int) this.immuneAlpha >= 205)
            this.immuneAlphaDirection = (sbyte) -1;
        }
        else
          this.immuneAlpha = (short) 0;
        this.potionDelayTime = (ushort) 3600;
        this.statDefense = (short) 0;
        this.accWatch = (byte) 0;
        this.accCompass = false;
        this.accDepthMeter = false;
        this.accDivingHelm = false;
        this.lifeRegen = 0;
        this.manaCost = 1f;
        this.meleeSpeed = 1f;
        this.meleeDamage = 1f;
        this.rangedDamage = 1f;
        this.magicDamage = 1f;
        this.moveSpeed = 1f;
        this.boneArmor = false;
        this.rocketBoots = (byte) 0;
        this.fireWalk = false;
        this.noKnockback = false;
        this.jumpBoost = false;
        this.noFallDmg = false;
        this.accFlipper = false;
        this.spawnMax = false;
        this.spaceGun = false;
        this.killGuide = false;
        this.lavaImmune = false;
        this.gills = false;
        this.slowFall = false;
        this.findTreasure = false;
        this.invis = false;
        this.nightVision = false;
        this.enemySpawns = false;
        this.thorns = false;
        this.waterWalk = false;
        this.detectCreature = false;
        this.gravControl = false;
        this.statManaMax2 = this.statManaMax;
        this.freeAmmoChance = (byte) 0;
        this.manaRegenBuff = false;
        this.meleeCrit = (short) 4;
        this.rangedCrit = (short) 4;
        this.magicCrit = (short) 4;
        this.lightOrb = false;
        this.fairy = false;
        this.archery = false;
        this.poisoned = false;
        this.blind = false;
        this.onFire = false;
        this.onFire2 = false;
        this.noItems = false;
        this.blockRange = (byte) 0;
        this.pickSpeed = 1f;
        this.wereWolf = false;
        this.rulerAcc = false;
        this.bleed = false;
        this.confused = false;
        this.wings = (byte) 0;
        this.brokenArmor = false;
        this.silence = false;
        this.slow = false;
        this.horrified = false;
        this.tongued = false;
        this.kbGlove = false;
        this.starCloak = false;
        this.longInvince = false;
        this.manaFlower = false;
        short num13 = this.inventory[(int) this.selectedItem].crit;
        this.meleeCrit += num13;
        this.magicCrit += num13;
        this.rangedCrit += num13;
        this.buffR = 1f;
        this.buffG = 1f;
        this.buffB = 1f;
        int num14 = 0;
        for (int b = 0; b < 10; ++b)
        {
          if ((int) this.buff[b].Type > 0 && (int) this.buff[b].Time > 0)
          {
            if (this.isLocal() && (int) this.buff[b].Type != 28)
            {
              --this.buff[b].Time;
              if (!this.buff[b].IsDebuff() && ++num14 == 5)
                this.ui.SetTriggerState(Trigger.Has5Buffs);
            }
            switch (this.buff[b].Type)
            {
              case (ushort) 1:
                this.lavaImmune = true;
                this.fireWalk = true;
                continue;
              case (ushort) 2:
                this.lifeRegen += 2;
                continue;
              case (ushort) 3:
                this.moveSpeed += 0.25f;
                continue;
              case (ushort) 4:
                this.gills = true;
                continue;
              case (ushort) 5:
                this.statDefense += (short) 8;
                continue;
              case (ushort) 6:
                this.manaRegenBuff = true;
                continue;
              case (ushort) 7:
                this.magicDamage += 0.2f;
                continue;
              case (ushort) 8:
                this.slowFall = true;
                continue;
              case (ushort) 9:
                this.findTreasure = true;
                continue;
              case (ushort) 10:
                this.invis = true;
                continue;
              case (ushort) 11:
                Lighting.addLight(this.aabb.X + 10 >> 4, this.aabb.Y + 21 >> 4, new Vector3(0.8f, 0.95f, 1f));
                continue;
              case (ushort) 12:
                this.nightVision = true;
                continue;
              case (ushort) 13:
                this.enemySpawns = true;
                continue;
              case (ushort) 14:
                this.thorns = true;
                continue;
              case (ushort) 15:
                this.waterWalk = true;
                continue;
              case (ushort) 16:
                this.archery = true;
                continue;
              case (ushort) 17:
                this.detectCreature = true;
                continue;
              case (ushort) 18:
                this.gravControl = true;
                continue;
              case (ushort) 19:
                this.lightOrb = true;
                bool flag1 = true;
                for (int index = 0; index < 512; ++index)
                {
                  if ((int) Main.projectile[index].type == 18 && (int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI)
                  {
                    flag1 = false;
                    break;
                  }
                }
                if (flag1)
                {
                  Projectile.NewProjectile(this.position.X + 10f, this.position.Y + 21f, 0.0f, 0.0f, 18, 0, 0.0f, (int) this.whoAmI, true);
                  continue;
                }
                else
                  continue;
              case (ushort) 20:
                this.poisoned = true;
                if (Main.rand.Next(52) == 0)
                {
                  Dust* dustPtr = Main.dust.NewDust(46, ref this.aabb, 0.0, 0.0, 150, new Color(), 0.200000002980232);
                  if ((IntPtr) dustPtr != IntPtr.Zero)
                  {
                    dustPtr->noGravity = true;
                    dustPtr->fadeIn = 1.9f;
                  }
                }
                this.buffR *= 0.65f;
                this.buffB *= 0.75f;
                continue;
              case (ushort) 21:
                this.potionDelay = this.buff[b].Time;
                continue;
              case (ushort) 22:
                this.blind = true;
                this.buffG *= 0.65f;
                this.buffR *= 0.7f;
                continue;
              case (ushort) 23:
                this.noItems = true;
                this.buffG *= 0.8f;
                this.buffR *= 0.65f;
                continue;
              case (ushort) 24:
                this.onFire = true;
                this.FireEffect(6);
                continue;
              case (ushort) 25:
                this.statDefense -= (short) 4;
                this.meleeCrit += (short) 2;
                this.meleeDamage += 0.1f;
                this.meleeSpeed += 0.1f;
                continue;
              case (ushort) 26:
                ++this.statDefense;
                ++this.meleeCrit;
                this.meleeDamage += 0.05f;
                this.meleeSpeed += 0.05f;
                ++this.magicCrit;
                this.magicDamage += 0.05f;
                ++this.rangedCrit;
                this.magicDamage += 0.05f;
                this.moveSpeed += 0.1f;
                continue;
              case (ushort) 27:
                this.fairy = true;
                bool flag2 = true;
                for (int index = 0; index < 512; ++index)
                {
                  if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI && ((int) Main.projectile[index].type == 72 || (int) Main.projectile[index].type == 86 || (int) Main.projectile[index].type == 87))
                  {
                    flag2 = false;
                    break;
                  }
                }
                if (flag2)
                {
                  int Type = Main.rand.Next(3);
                  switch (Type)
                  {
                    case 0:
                      Type = 72;
                      break;
                    case 1:
                      Type = 86;
                      break;
                    case 2:
                      Type = 87;
                      break;
                  }
                  Projectile.NewProjectile(this.position.X + 10f, this.position.Y + 21f, 0.0f, 0.0f, Type, 0, 0.0f, (int) this.whoAmI, true);
                  continue;
                }
                else
                  continue;
              case (ushort) 28:
                if (this.wolfAcc && !this.merman && (!Main.gameTime.dayTime && (int) Main.gameTime.moonPhase == 0))
                {
                  this.wereWolf = true;
                  ++this.meleeCrit;
                  this.meleeDamage += 0.051f;
                  this.meleeSpeed += 0.051f;
                  ++this.statDefense;
                  this.moveSpeed += 0.05f;
                  continue;
                }
                else
                {
                  b = this.DelBuff(b);
                  continue;
                }
              case (ushort) 29:
                this.magicCrit += (short) 2;
                this.magicDamage += 0.05f;
                this.statManaMax2 += (short) 20;
                this.manaCost -= 0.02f;
                continue;
              case (ushort) 30:
                this.bleed = true;
                if (!this.dead && Main.rand.Next(32) == 0)
                {
                  Dust* dustPtr = Main.dust.NewDust(5, ref this.aabb, 0.0, 0.0, 0, new Color(), 1.0);
                  if ((IntPtr) dustPtr != IntPtr.Zero)
                  {
                    dustPtr->velocity.X *= 0.25f;
                    dustPtr->velocity.Y += 0.5f;
                    dustPtr->velocity.Y *= 0.25f;
                  }
                }
                this.buffG *= 0.9f;
                this.buffB *= 0.9f;
                continue;
              case (ushort) 31:
                this.confused = true;
                continue;
              case (ushort) 32:
                this.slow = true;
                continue;
              case (ushort) 33:
                this.meleeDamage -= 0.051f;
                this.meleeSpeed -= 0.051f;
                this.statDefense -= (short) 4;
                this.moveSpeed -= 0.1f;
                continue;
              case (ushort) 35:
                this.silence = true;
                continue;
              case (ushort) 36:
                this.brokenArmor = true;
                continue;
              case (ushort) 37:
                if (NPC.wof >= 0 && (int) Main.npc[NPC.wof].type == 113)
                {
                  this.horrified = true;
                  this.buff[b].Time = (ushort) 10;
                  continue;
                }
                else
                {
                  b = this.DelBuff(b);
                  continue;
                }
              case (ushort) 38:
                this.buff[b].Time = (ushort) 10;
                this.tongued = true;
                continue;
              case (ushort) 39:
                this.onFire2 = true;
                this.FireEffect(75);
                continue;
              case (ushort) 40:
                if ((int) this.pet >= 0)
                {
                  this.buff[b].Time = (ushort) 18000;
                  this.SpawnPet();
                  continue;
                }
                else
                {
                  this.buff[b].Time = (ushort) 0;
                  continue;
                }
              default:
                continue;
            }
          }
        }
        if (this.accMerman && this.wet && !this.lavaWet)
        {
          this.releaseJump = true;
          this.wings = (byte) 0;
          this.merman = true;
          this.accFlipper = true;
          this.AddBuff(34, 2, true);
        }
        else
          this.merman = false;
        this.accMerman = false;
        if (this.wolfAcc && !this.merman && (!this.wereWolf && !Main.gameTime.dayTime) && (int) Main.gameTime.moonPhase == 0)
          this.AddBuff(28, 60, true);
        this.wolfAcc = false;
        if (this.isLocal())
        {
          for (int b = 0; b < 10; ++b)
          {
            if ((int) this.buff[b].Type > 0 && (int) this.buff[b].Time == 0)
              b = this.DelBuff(b);
          }
        }
        this.doubleJump = false;
        for (int index = 0; index < 8; ++index)
        {
          this.statDefense += this.armor[index].defense;
          this.lifeRegen += (int) this.armor[index].lifeRegen;
          switch (this.armor[index].type)
          {
            case (short) 400:
              this.magicDamage += 0.11f;
              this.magicCrit += (short) 11;
              this.statManaMax2 += (short) 80;
              break;
            case (short) 401:
              this.meleeCrit += (short) 7;
              this.meleeDamage += 0.14f;
              break;
            case (short) 402:
              this.rangedDamage += 0.14f;
              this.rangedCrit += (short) 8;
              break;
            case (short) 403:
              this.rangedDamage += 0.06f;
              this.meleeDamage += 0.06f;
              this.magicDamage += 0.06f;
              break;
            case (short) 404:
              this.magicCrit += (short) 4;
              this.meleeCrit += (short) 4;
              this.rangedCrit += (short) 4;
              this.moveSpeed += 0.05f;
              break;
            case (short) 551:
              this.magicCrit += (short) 7;
              this.meleeCrit += (short) 7;
              this.rangedCrit += (short) 7;
              break;
            case (short) 552:
              this.rangedDamage += 0.07f;
              this.meleeDamage += 0.07f;
              this.magicDamage += 0.07f;
              this.moveSpeed += 0.08f;
              break;
            case (short) 553:
              this.rangedDamage += 0.15f;
              this.rangedCrit += (short) 8;
              break;
            case (short) 558:
              this.magicDamage += 0.12f;
              this.magicCrit += (short) 12;
              this.statManaMax2 += (short) 100;
              break;
            case (short) 559:
              this.meleeCrit += (short) 10;
              this.meleeDamage += 0.1f;
              this.meleeSpeed += 0.1f;
              break;
            case (short) 604:
              this.meleeCrit += (short) 15;
              this.meleeDamage += 0.15f;
              this.meleeSpeed += 0.15f;
              break;
            case (short) 605:
              this.rangedDamage += 0.15f;
              this.rangedCrit += (short) 10;
              this.freeAmmoChance += (byte) 5;
              break;
            case (short) 606:
              this.magicDamage += 0.15f;
              this.magicCrit += (short) 15;
              this.statManaMax2 += (short) 120;
              break;
            case (short) 607:
              this.meleeCrit += (short) 5;
              this.meleeDamage += 0.05f;
              break;
            case (short) 608:
              this.rangedDamage += 0.05f;
              this.rangedCrit += (short) 10;
              this.freeAmmoChance += (byte) 5;
              break;
            case (short) 609:
              this.magicDamage += 0.05f;
              this.magicCrit += (short) 10;
              this.manaCost -= 0.1f;
              break;
            case (short) 610:
              this.moveSpeed += 0.12f;
              this.meleeSpeed += 0.02f;
              break;
            case (short) 611:
              this.rangedDamage += 0.1f;
              this.moveSpeed += 0.1f;
              this.freeAmmoChance += (byte) 10;
              break;
            case (short) 612:
              this.magicDamage += 0.1f;
              this.moveSpeed += 0.1f;
              this.statManaMax2 += (short) 30;
              break;
            case (short) 238:
              this.magicDamage += 0.15f;
              break;
            case (short) 268:
              this.accDivingHelm = true;
              break;
            case (short) 371:
              this.magicCrit += (short) 9;
              this.statManaMax2 += (short) 40;
              break;
            case (short) 372:
              this.moveSpeed += 0.07f;
              this.meleeSpeed += 0.12f;
              break;
            case (short) 373:
              this.rangedDamage += 0.1f;
              this.rangedCrit += (short) 6;
              break;
            case (short) 374:
              this.magicCrit += (short) 3;
              this.meleeCrit += (short) 3;
              this.rangedCrit += (short) 3;
              break;
            case (short) 375:
              this.moveSpeed += 0.1f;
              break;
            case (short) 376:
              this.magicDamage += 0.15f;
              this.statManaMax2 += (short) 60;
              break;
            case (short) 377:
              this.meleeCrit += (short) 5;
              this.meleeDamage += 0.1f;
              break;
            case (short) 378:
              this.rangedDamage += 0.12f;
              this.rangedCrit += (short) 7;
              break;
            case (short) 379:
              this.rangedDamage += 0.05f;
              this.meleeDamage += 0.05f;
              this.magicDamage += 0.05f;
              break;
            case (short) 380:
              this.magicCrit += (short) 3;
              this.meleeCrit += (short) 3;
              this.rangedCrit += (short) 3;
              break;
            case (short) 123:
            case (short) 124:
            case (short) 125:
              this.magicDamage += 0.05f;
              break;
            case (short) 151:
            case (short) 152:
            case (short) 153:
              this.rangedDamage += 0.05f;
              break;
            case (short) 228:
            case (short) 229:
            case (short) 230:
              this.magicCrit += (short) 3;
              this.statManaMax2 += (short) 20;
              break;
            case (short) 100:
            case (short) 101:
            case (short) 102:
              this.meleeSpeed += 0.07f;
              break;
            case (short) 111:
              this.statManaMax2 += (short) 20;
              break;
          }
          switch (this.armor[index].prefix)
          {
            case (byte) 62:
              ++this.statDefense;
              break;
            case (byte) 63:
              this.statDefense += (short) 2;
              break;
            case (byte) 64:
              this.statDefense += (short) 3;
              break;
            case (byte) 65:
              this.statDefense += (short) 4;
              break;
            case (byte) 66:
              this.statManaMax2 += (short) 20;
              break;
            case (byte) 67:
              ++this.meleeCrit;
              ++this.rangedCrit;
              ++this.magicCrit;
              break;
            case (byte) 68:
              this.meleeCrit += (short) 2;
              this.rangedCrit += (short) 2;
              this.magicCrit += (short) 2;
              break;
            case (byte) 69:
              this.meleeDamage += 0.01f;
              this.rangedDamage += 0.01f;
              this.magicDamage += 0.01f;
              break;
            case (byte) 70:
              this.meleeDamage += 0.02f;
              this.rangedDamage += 0.02f;
              this.magicDamage += 0.02f;
              break;
            case (byte) 71:
              this.meleeDamage += 0.03f;
              this.rangedDamage += 0.03f;
              this.magicDamage += 0.03f;
              break;
            case (byte) 72:
              this.meleeDamage += 0.04f;
              this.rangedDamage += 0.04f;
              this.magicDamage += 0.04f;
              break;
            case (byte) 73:
              this.moveSpeed += 0.01f;
              break;
            case (byte) 74:
              this.moveSpeed += 0.02f;
              break;
            case (byte) 75:
              this.moveSpeed += 0.03f;
              break;
            case (byte) 76:
              this.moveSpeed += 0.04f;
              break;
            case (byte) 77:
              this.meleeSpeed += 0.01f;
              break;
            case (byte) 78:
              this.meleeSpeed += 0.02f;
              break;
            case (byte) 79:
              this.meleeSpeed += 0.03f;
              break;
            case (byte) 80:
              this.meleeSpeed += 0.04f;
              break;
          }
        }
        this.head = this.armor[0].headSlot;
        this.body = this.armor[1].bodySlot;
        this.legs = this.armor[2].legSlot;
        for (int index = 3; index < 8; ++index)
        {
          switch (this.armor[index].type)
          {
            case (short) 554:
              this.longInvince = true;
              break;
            case (short) 555:
              this.manaFlower = true;
              this.manaCost -= 0.08f;
              break;
            case (short) 562:
            case (short) 563:
            case (short) 564:
            case (short) 565:
            case (short) 566:
            case (short) 567:
            case (short) 568:
            case (short) 569:
            case (short) 570:
            case (short) 571:
            case (short) 572:
            case (short) 573:
            case (short) 574:
            case (short) 626:
            case (short) 627:
            case (short) 628:
            case (short) 629:
            case (short) 630:
            case (short) 631:
              if (this.isLocal() && Main.musicBox < 0)
              {
                Main.musicBox = (int) this.armor[index].type >= 626 ? (int) this.armor[index].type - 613 : (int) this.armor[index].type - 562;
                break;
              }
              else
                break;
            case (short) 576:
              if (this.isLocal() && Main.rand.Next(18000) == 0 && Main.curMusic != Main.Music.NUM_SONGS)
              {
                this.armor[index].SetDefaults((int) Main.SONG_TO_MUSIC_BOX[(int) Main.curMusic], 1, false);
                break;
              }
              else
                break;
            case (short) 485:
              this.wolfAcc = true;
              break;
            case (short) 486:
              this.rulerAcc = true;
              break;
            case (short) 489:
              this.magicDamage += 0.15f;
              break;
            case (short) 490:
              this.meleeDamage += 0.15f;
              break;
            case (short) 491:
              this.rangedDamage += 0.15f;
              break;
            case (short) 492:
              this.wings = (byte) 1;
              break;
            case (short) 493:
              this.wings = (byte) 2;
              break;
            case (short) 497:
              this.accMerman = true;
              break;
            case (short) 532:
              this.starCloak = true;
              break;
            case (short) 535:
              this.potionDelayTime = (ushort) 2700;
              break;
            case (short) 536:
              this.kbGlove = true;
              break;
            case (short) 285:
              this.moveSpeed += 0.1f;
              break;
            case (short) 393:
              this.accCompass = true;
              break;
            case (short) 394:
              this.accFlipper = true;
              this.accDivingHelm = true;
              break;
            case (short) 395:
              this.accWatch = (byte) 3;
              this.accDepthMeter = true;
              this.accCompass = true;
              break;
            case (short) 396:
              this.noFallDmg = true;
              this.fireWalk = true;
              break;
            case (short) 397:
              this.noKnockback = true;
              this.fireWalk = true;
              break;
            case (short) 399:
              this.jumpBoost = true;
              this.doubleJump = true;
              break;
            case (short) 405:
              num7 = 6f;
              this.rocketBoots = (byte) 2;
              break;
            case (short) 407:
              this.blockRange = (byte) 1;
              break;
            case (short) 223:
              this.manaCost -= 0.06f;
              break;
            case (short) 267:
              this.killGuide = true;
              break;
            case (short) 193:
              this.fireWalk = true;
              break;
            case (short) 211:
              this.meleeSpeed += 0.12f;
              break;
            case (short) 212:
              this.moveSpeed += 0.1f;
              break;
            case (short) 156:
              this.noKnockback = true;
              break;
            case (short) 158:
              this.noFallDmg = true;
              break;
            case (short) 159:
              this.jumpBoost = true;
              break;
            case (short) 187:
              this.accFlipper = true;
              break;
            case (short) 15:
              if ((int) this.accWatch < 1)
              {
                this.accWatch = (byte) 1;
                break;
              }
              else
                break;
            case (short) 16:
              if ((int) this.accWatch < 2)
              {
                this.accWatch = (byte) 2;
                break;
              }
              else
                break;
            case (short) 17:
              this.accWatch = (byte) 3;
              break;
            case (short) 18:
              this.accDepthMeter = true;
              break;
            case (short) 53:
              this.doubleJump = true;
              break;
            case (short) 54:
              num7 = 6f;
              break;
            case (short) 128:
              this.rocketBoots = (byte) 1;
              break;
          }
        }
        Lighting.addLight(this.aabb.X + 10 + ((int) this.direction << 3) >> 4, this.aabb.Y + 2 >> 4, (int) this.head == 11 ? new Vector3(0.92f, 0.8f, 0.75f) : new Vector3(0.2f, 0.2f, 0.2f));
        this.setBonus = (string) null;
        if ((int) this.head == 1 && (int) this.body == 1 && (int) this.legs == 1 || (int) this.head == 2 && (int) this.body == 2 && (int) this.legs == 2)
        {
          this.setBonus = Lang.setBonus(0);
          this.statDefense += (short) 2;
        }
        else if ((int) this.head == 3 && (int) this.body == 3 && (int) this.legs == 3 || (int) this.head == 4 && (int) this.body == 4 && (int) this.legs == 4)
        {
          this.setBonus = Lang.setBonus(1);
          this.statDefense += (short) 3;
        }
        else if ((int) this.head == 5 && (int) this.body == 5 && (int) this.legs == 5)
        {
          this.setBonus = Lang.setBonus(2);
          this.moveSpeed += 0.15f;
        }
        else if ((int) this.head == 6 && (int) this.body == 6 && (int) this.legs == 6)
        {
          this.setBonus = Lang.setBonus(3);
          this.spaceGun = true;
        }
        else if ((int) this.head == 7 && (int) this.body == 7 && (int) this.legs == 7)
        {
          this.setBonus = Lang.setBonus(4);
          this.freeAmmoChance += (byte) 20;
        }
        else if ((int) this.head == 8 && (int) this.body == 8 && (int) this.legs == 8)
        {
          this.setBonus = Lang.setBonus(5);
          this.manaCost -= 0.16f;
        }
        else if ((int) this.head == 9 && (int) this.body == 9 && (int) this.legs == 9)
        {
          this.setBonus = Lang.setBonus(6);
          this.meleeDamage += 0.17f;
        }
        else if ((int) this.head == 11 && (int) this.body == 20 && (int) this.legs == 19)
        {
          this.setBonus = Lang.setBonus(7);
          this.pickSpeed = 0.8f;
        }
        else if ((int) this.body == 17 && (int) this.legs == 16)
        {
          if ((int) this.head == 29)
          {
            this.setBonus = Lang.setBonus(8);
            this.manaCost -= 0.14f;
          }
          else if ((int) this.head == 30)
          {
            this.setBonus = Lang.setBonus(9);
            this.meleeSpeed += 0.15f;
          }
          else if ((int) this.head == 31)
          {
            this.setBonus = Lang.setBonus(10);
            this.freeAmmoChance += (byte) 20;
          }
        }
        else if ((int) this.body == 18 && (int) this.legs == 17)
        {
          if ((int) this.head == 32)
          {
            this.setBonus = Lang.setBonus(11);
            this.manaCost -= 0.17f;
          }
          else if ((int) this.head == 33)
          {
            this.setBonus = Lang.setBonus(12);
            this.meleeCrit += (short) 5;
          }
          else if ((int) this.head == 34)
          {
            this.setBonus = Lang.setBonus(13);
            this.freeAmmoChance += (byte) 20;
          }
        }
        else if ((int) this.body == 19 && (int) this.legs == 18)
        {
          if ((int) this.head == 35)
          {
            this.setBonus = Lang.setBonus(14);
            this.manaCost -= 0.19f;
          }
          else if ((int) this.head == 36)
          {
            this.setBonus = Lang.setBonus(15);
            this.meleeSpeed += 0.18f;
            this.moveSpeed += 0.18f;
          }
          else if ((int) this.head == 37)
          {
            this.setBonus = Lang.setBonus(16);
            this.freeAmmoChance += (byte) 25;
          }
        }
        else if ((int) this.body == 24 && (int) this.legs == 23)
        {
          if ((int) this.head == 42)
          {
            this.setBonus = Lang.setBonus(17);
            this.manaCost -= 0.2f;
          }
          else if ((int) this.head == 43)
          {
            this.setBonus = Lang.setBonus(18);
            this.meleeSpeed += 0.19f;
            this.moveSpeed += 0.19f;
          }
          else if ((int) this.head == 41)
          {
            this.setBonus = Lang.setBonus(19);
            this.freeAmmoChance += (byte) 25;
          }
        }
        else if ((int) this.head == 45 && (int) this.body == 26 && (int) this.legs == 25)
        {
          this.setBonus = Lang.setBonus(21);
          this.meleeSpeed += 0.21f;
          this.moveSpeed += 0.21f;
        }
        else if ((int) this.head == 46 && (int) this.body == 27 && (int) this.legs == 26)
        {
          this.setBonus = Lang.setBonus(22);
          this.freeAmmoChance += (byte) 28;
        }
        else if ((int) this.head == 47 && (int) this.body == 28 && (int) this.legs == 27)
        {
          this.setBonus = Lang.setBonus(20);
          this.manaCost -= 0.23f;
        }
        if (this.merman)
          this.wings = (byte) 0;
        if ((double) this.meleeSpeed > 4.0)
          this.meleeSpeed = 4f;
        if ((double) this.moveSpeed > 1.39999997615814)
          this.moveSpeed = 1.4f;
        if (this.slow)
          this.moveSpeed *= 0.5f;
        if ((int) this.statManaMax2 > 400)
          this.statManaMax2 = (short) 400;
        if ((int) this.statDefense < 0)
          this.statDefense = (short) 0;
        this.meleeSpeed = 1f / this.meleeSpeed;
        if (this.onFire || this.onFire2)
        {
          this.lifeRegenTime = 0;
          this.lifeRegen = -8;
        }
        else if (this.poisoned)
        {
          this.lifeRegenTime = 0;
          this.lifeRegen = -4;
        }
        else if (this.bleed)
        {
          this.lifeRegenTime = 0;
        }
        else
        {
          double num11 = 0.0;
          if (++this.lifeRegenTime >= 3600)
          {
            num11 = 9.0;
            this.lifeRegenTime = 3600;
          }
          else if (this.lifeRegenTime >= 3000)
            num11 = 8.0;
          else if (this.lifeRegenTime >= 2400)
            num11 = 7.0;
          else if (this.lifeRegenTime >= 1800)
            num11 = 6.0;
          else if (this.lifeRegenTime >= 1500)
            num11 = 5.0;
          else if (this.lifeRegenTime >= 1200)
            num11 = 4.0;
          else if (this.lifeRegenTime >= 900)
            num11 = 3.0;
          else if (this.lifeRegenTime >= 600)
            num11 = 2.0;
          else if (this.lifeRegenTime >= 300)
            num11 = 1.0;
          this.lifeRegen += (int) Math.Round(((double) this.velocity.X == 0.0 || (int) this.grappling[0] > 0 ? num11 * 1.25 : num11 * 0.5) * ((double) this.statLifeMax / 400.0 * 0.85 + 0.15));
        }
        this.lifeRegenCount += this.lifeRegen;
        while (this.lifeRegenCount >= 120)
        {
          this.lifeRegenCount -= 120;
          if ((int) this.statLife < (int) this.statLifeMax)
            ++this.statLife;
          else if ((int) this.statLife > (int) this.statLifeMax)
          {
            this.statLife = this.statLifeMax;
            break;
          }
        }
        while (this.lifeRegenCount <= -120)
        {
          this.lifeRegenCount += 120;
          if ((int) --this.statLife <= 0 && this.isLocal())
          {
            if (this.poisoned)
              this.KillMe(10.0, 0, false, Lang.deathMsg(-1, 0, 0, 3));
            else if (this.onFire || this.onFire2)
              this.KillMe(10.0, 0, false, Lang.deathMsg(-1, 0, 0, 4));
          }
        }
        if (this.manaRegenDelay > 0 && !this.channel)
        {
          --this.manaRegenDelay;
          if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0 || ((int) this.grappling[0] >= 0 || this.manaRegenBuff))
            --this.manaRegenDelay;
        }
        if (this.manaRegenBuff && this.manaRegenDelay > 20)
          this.manaRegenDelay = 20;
        if (this.manaRegenDelay <= 0 && (int) this.statManaMax2 > 0)
        {
          this.manaRegenDelay = 0;
          this.manaRegen = (int) this.statManaMax2 / 7 + 1;
          if ((double) this.velocity.X == 0.0 && (double) this.velocity.Y == 0.0 || ((int) this.grappling[0] >= 0 || this.manaRegenBuff))
            this.manaRegen += (int) this.statManaMax2 >> 1;
          float num11 = (float) ((double) this.statMana / (double) this.statManaMax2 * 0.800000011920929 + 0.200000002980232);
          if (this.manaRegenBuff)
            num11 = 1f;
          this.manaRegen = (int) ((double) this.manaRegen * (double) num11);
        }
        else
          this.manaRegen = 0;
        this.manaRegenCount += this.manaRegen;
        while (this.manaRegenCount >= 120)
        {
          bool flag = false;
          this.manaRegenCount -= 120;
          if ((int) this.statMana < (int) this.statManaMax2)
          {
            ++this.statMana;
            flag = true;
          }
          if ((int) this.statMana >= (int) this.statManaMax2)
          {
            if (flag && this.isLocal())
            {
              Main.PlaySound(25);
              for (int index = 0; index < 4; ++index)
              {
                Dust* dustPtr = Main.dust.NewDust(45, ref this.aabb, 0.0, 0.0, (int) byte.MaxValue, new Color(), (double) Main.rand.Next(20, 26) * 0.100000001490116);
                if ((IntPtr) dustPtr != IntPtr.Zero)
                {
                  dustPtr->noLight = true;
                  dustPtr->noGravity = true;
                  dustPtr->velocity *= 0.5f;
                }
                else
                  break;
              }
            }
            this.statMana = this.statManaMax2;
          }
        }
        if (this.manaRegenCount < 0)
          this.manaRegenCount = 0;
        if ((int) this.statMana > (int) this.statManaMax2)
          this.statMana = this.statManaMax2;
        float num15 = num6 * this.moveSpeed;
        float num16 = num5 * this.moveSpeed;
        if (this.jumpBoost)
        {
          num3 = 20;
          num4 = 6.51f;
        }
        if (this.wereWolf)
        {
          num3 += 2;
          num4 += 0.2f;
        }
        if (this.brokenArmor)
          this.statDefense >>= 1;
        if (!this.doubleJump)
          this.jumpAgain = false;
        else if ((double) this.velocity.Y == 0.0)
          this.jumpAgain = true;
        if ((int) this.grappling[0] == -1 && !this.tongued)
        {
          if (this.controlLeft && (double) this.velocity.X > -(double) num16)
          {
            if ((double) this.velocity.X > 0.200000002980232)
              this.velocity.X -= 0.2f;
            this.velocity.X -= num15;
            if ((int) this.itemAnimation == 0 || this.inventory[(int) this.selectedItem].useTurn)
              this.direction = (sbyte) -1;
          }
          else if (this.controlRight && (double) this.velocity.X < (double) num16)
          {
            if ((double) this.velocity.X < -0.200000002980232)
              this.velocity.X += 0.2f;
            this.velocity.X += num15;
            if ((int) this.itemAnimation == 0 || this.inventory[(int) this.selectedItem].useTurn)
              this.direction = (sbyte) 1;
          }
          else if (this.controlLeft && (double) this.velocity.X > -(double) num7)
          {
            if ((int) this.itemAnimation == 0 || this.inventory[(int) this.selectedItem].useTurn)
              this.direction = (sbyte) -1;
            if ((double) this.velocity.Y == 0.0 || (int) this.wings > 0)
            {
              if ((double) this.velocity.X > 0.200000002980232)
                this.velocity.X -= 0.2f;
              this.velocity.X -= num15 * 0.2f;
            }
            if ((double) this.velocity.X < -((double) num7 + (double) num16) * 0.5 && (double) this.velocity.Y == 0.0)
            {
              int num11 = 0;
              if ((int) this.gravDir == -1)
                num11 -= 42;
              if ((int) this.runSoundDelay == 0 && (double) this.velocity.Y == 0.0)
              {
                Main.PlaySound(17, this.aabb.X, this.aabb.Y, 1);
                this.runSoundDelay = (sbyte) 9;
              }
              Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 4, this.aabb.Y + 42 + num11, 28, 4, 16, (double) this.velocity.X * -0.5, (double) this.velocity.Y * 0.5, 50, new Color(), 1.5);
              if ((IntPtr) dustPtr != IntPtr.Zero)
                dustPtr->velocity *= 0.2f;
            }
          }
          else if (this.controlRight && (double) this.velocity.X < (double) num7)
          {
            if ((int) this.itemAnimation == 0 || this.inventory[(int) this.selectedItem].useTurn)
              this.direction = (sbyte) 1;
            if ((double) this.velocity.Y == 0.0 || (int) this.wings > 0)
            {
              if ((double) this.velocity.X < -0.200000002980232)
                this.velocity.X += 0.2f;
              this.velocity.X += num15 * 0.2f;
            }
            if ((double) this.velocity.X > ((double) num7 + (double) num16) * 0.5 && (double) this.velocity.Y == 0.0)
            {
              int num11 = 0;
              if ((int) this.gravDir == -1)
                num11 -= 42;
              if ((int) this.runSoundDelay == 0 && (double) this.velocity.Y == 0.0)
              {
                Main.PlaySound(17, this.aabb.X, this.aabb.Y, 1);
                this.runSoundDelay = (sbyte) 9;
              }
              Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 4, this.aabb.Y + 42 + num11, 28, 4, 16, (double) this.velocity.X * -0.5, (double) this.velocity.Y * 0.5, 50, new Color(), 1.5);
              if ((IntPtr) dustPtr != IntPtr.Zero)
                dustPtr->velocity *= 0.2f;
            }
          }
          else if ((double) this.velocity.Y == 0.0)
          {
            if ((double) this.velocity.X > 0.200000002980232)
              this.velocity.X -= 0.2f;
            else if ((double) this.velocity.X < -0.200000002980232)
              this.velocity.X += 0.2f;
            else
              this.velocity.X = 0.0f;
          }
          else if ((double) this.velocity.X > 0.100000001490116)
            this.velocity.X -= 0.1f;
          else if ((double) this.velocity.X < -0.100000001490116)
            this.velocity.X += 0.1f;
          else
            this.velocity.X = 0.0f;
          if (this.gravControl)
          {
            if (this.controlUp && (int) this.gravDir == 1 || this.controlDown && (int) this.gravDir == -1)
            {
              this.gravDir = -this.gravDir;
              this.fallStart = (short) (this.aabb.Y >> 4);
              this.jump = 0;
              Main.PlaySound(2, this.aabb.X, this.aabb.Y, 8);
            }
          }
          else
            this.gravDir = (sbyte) 1;
          if (this.controlJump)
          {
            if (this.jump > 0)
            {
              if ((double) this.velocity.Y == 0.0)
              {
                this.jump = 0;
              }
              else
              {
                this.velocity.Y = -num4 * (float) this.gravDir;
                if (this.merman)
                {
                  if ((int) this.swimTime <= 10)
                    this.swimTime = (byte) 30;
                }
                else
                  --this.jump;
              }
            }
            else if (((double) this.velocity.Y == 0.0 || this.jumpAgain || this.wet && this.accFlipper) && this.releaseJump)
            {
              bool flag = this.wet && this.accFlipper;
              if (flag && (int) this.swimTime == 0)
                this.swimTime = (byte) 30;
              this.jumpAgain = false;
              this.canRocket = false;
              this.rocketRelease = false;
              if ((double) this.velocity.Y == 0.0 && this.doubleJump)
                this.jumpAgain = true;
              if ((double) this.velocity.Y == 0.0 || flag)
              {
                this.velocity.Y = -num4 * (float) this.gravDir;
                this.jump = num3;
              }
              else
              {
                int num11 = 42;
                if ((int) this.gravDir == -1)
                  num11 = 0;
                Main.PlaySound(16, this.aabb.X, this.aabb.Y, 1);
                this.velocity.Y = -num4 * (float) this.gravDir;
                this.jump = num3 >> 1;
                for (int index = 0; index < 8; ++index)
                {
                  Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 34, this.aabb.Y + num11 - 16, 102, 32, 16, (double) this.velocity.X * -0.5, (double) this.velocity.Y * 0.5, 100, new Color(), 1.5);
                  if ((IntPtr) dustPtr != IntPtr.Zero)
                  {
                    dustPtr->velocity.X = (float) ((double) dustPtr->velocity.X * 0.5 - (double) this.velocity.X * 0.100000001490116);
                    dustPtr->velocity.Y = (float) ((double) dustPtr->velocity.Y * 0.5 - (double) this.velocity.Y * 0.300000011920929);
                  }
                  else
                    break;
                }
                int index1 = Gore.NewGore(new Vector2((float) ((double) this.position.X + 10.0 - 16.0), (float) ((double) this.position.Y + (double) num11 - 16.0)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1.0);
                Main.gore[index1].velocity.X = (float) ((double) Main.gore[index1].velocity.X * 0.100000001490116 - (double) this.velocity.X * 0.100000001490116);
                Main.gore[index1].velocity.Y = (float) ((double) Main.gore[index1].velocity.Y * 0.100000001490116 - (double) this.velocity.Y * 0.0500000007450581);
                int index2 = Gore.NewGore(new Vector2(this.position.X - 36f, (float) ((double) this.position.Y + (double) num11 - 16.0)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1.0);
                Main.gore[index2].velocity.X = (float) ((double) Main.gore[index2].velocity.X * 0.100000001490116 - (double) this.velocity.X * 0.100000001490116);
                Main.gore[index2].velocity.Y = (float) ((double) Main.gore[index2].velocity.Y * 0.100000001490116 - (double) this.velocity.Y * 0.0500000007450581);
                int index3 = Gore.NewGore(new Vector2((float) ((double) this.position.X + 20.0 + 4.0), (float) ((double) this.position.Y + (double) num11 - 16.0)), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1.0);
                Main.gore[index3].velocity.X = (float) ((double) Main.gore[index3].velocity.X * 0.100000001490116 - (double) this.velocity.X * 0.100000001490116);
                Main.gore[index3].velocity.Y = (float) ((double) Main.gore[index3].velocity.Y * 0.100000001490116 - (double) this.velocity.Y * 0.0500000007450581);
              }
              if (this.ui != null)
                ++this.ui.totalJumps;
            }
            this.releaseJump = false;
          }
          else
          {
            this.jump = 0;
            this.releaseJump = true;
            this.rocketRelease = true;
          }
          if (this.doubleJump && !this.jumpAgain && ((int) this.gravDir == 1 && (double) this.velocity.Y < 0.0 || (int) this.gravDir == -1 && (double) this.velocity.Y > 0.0) && ((int) this.rocketBoots == 0 && !this.accFlipper))
          {
            int num11 = 42;
            if ((int) this.gravDir == -1)
              num11 = -6;
            Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 4, this.aabb.Y + num11, 28, 4, 16, (double) this.velocity.X * -0.5, (double) this.velocity.Y * 0.5, 100, new Color(), 1.5);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->velocity.X = (float) ((double) dustPtr->velocity.X * 0.5 - (double) this.velocity.X * 0.100000001490116);
              dustPtr->velocity.Y = (float) ((double) dustPtr->velocity.Y * 0.5 - (double) this.velocity.Y * 0.300000011920929);
            }
          }
          if (((int) this.gravDir == 1 && (double) this.velocity.Y > -(double) num4 || (int) this.gravDir == -1 && (double) this.velocity.Y < (double) num4) && (double) this.velocity.Y != 0.0)
            this.canRocket = true;
          bool flag1 = false;
          if ((double) this.velocity.Y == 0.0)
            this.wingTime = (short) 90;
          if ((int) this.wings > 0 && this.controlJump && ((int) this.wingTime > 0 && !this.jumpAgain) && (this.jump == 0 && (double) this.velocity.Y != 0.0))
            flag1 = true;
          if (flag1)
          {
            this.velocity.Y -= 0.1f * (float) this.gravDir;
            if ((int) this.gravDir == 1)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y -= 0.5f;
              else if ((double) this.velocity.Y > -(double) num4 * 0.5)
                this.velocity.Y -= 0.1f;
              if ((double) this.velocity.Y < -(double) num4 * 1.5)
                this.velocity.Y = (float) (-(double) num4 * 1.5);
            }
            else
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y += 0.5f;
              else if ((double) this.velocity.Y < (double) num4 * 0.5)
                this.velocity.Y += 0.1f;
              if ((double) this.velocity.Y > (double) num4 * 1.5)
                this.velocity.Y = num4 * 1.5f;
            }
            --this.wingTime;
          }
          if (flag1 || this.jump > 0)
          {
            if ((int) ++this.wingFrameCounter > 4)
            {
              this.wingFrameCounter = (byte) 0;
              this.wingFrame = (byte) ((int) this.wingFrame + 1 & 3);
            }
          }
          else
            this.wingFrame = (double) this.velocity.Y == 0.0 ? (byte) 0 : (byte) 1;
          if ((int) this.wings > 0 && (int) this.rocketBoots > 0)
          {
            this.wingTime = (short) ((int) this.wingTime + (int) this.rocketTime * 10);
            this.rocketTime = (sbyte) 0;
          }
          if (flag1)
          {
            if ((int) this.wingFrame == 3)
            {
              if (!this.flapSound)
              {
                this.flapSound = true;
                Main.PlaySound(2, this.aabb.X, this.aabb.Y, 32);
              }
            }
            else
              this.flapSound = false;
          }
          if ((double) this.velocity.Y == 0.0)
            this.rocketTime = (sbyte) 7;
          if (((int) this.wingTime == 0 || (int) this.wings == 0) && ((int) this.rocketBoots > 0 && this.controlJump) && ((int) this.rocketDelay == 0 && this.canRocket && (this.rocketRelease && !this.jumpAgain)))
          {
            if ((int) this.rocketTime > 0)
            {
              --this.rocketTime;
              this.rocketDelay = (sbyte) 10;
              if ((int) this.rocketDelay2 <= 0)
              {
                if ((int) this.rocketBoots == 1)
                {
                  Main.PlaySound(2, this.aabb.X, this.aabb.Y, 13);
                  this.rocketDelay2 = (sbyte) 30;
                }
                else if ((int) this.rocketBoots == 2)
                {
                  Main.PlaySound(2, this.aabb.X, this.aabb.Y, 24);
                  this.rocketDelay2 = (sbyte) 15;
                }
              }
            }
            else
              this.canRocket = false;
          }
          if ((int) this.rocketDelay2 > 0)
            --this.rocketDelay2;
          if ((int) this.rocketDelay == 0)
            this.rocketFrame = false;
          if ((int) this.rocketDelay > 0)
          {
            int num11 = 42;
            if ((int) this.gravDir == -1)
              num11 = 4;
            this.rocketFrame = true;
            if (((int) Main.frameCounter & 1) == 0)
            {
              int Type = 6;
              float num12 = 2.5f;
              int Alpha = 100;
              if ((int) this.rocketBoots == 2)
              {
                Type = 16;
                num12 = 1.5f;
                Alpha = 20;
              }
              else if (this.socialShadow)
              {
                Type = 27;
                num12 = 1.5f;
              }
              int X = this.aabb.X - 4;
              int Y = this.aabb.Y + num11 - 10;
              for (int index = 0; index < 2; ++index)
              {
                Dust* dustPtr = Main.dust.NewDust(X, Y, 8, 8, Type, 0.0, 0.0, Alpha, new Color(), (double) num12);
                if ((IntPtr) dustPtr != IntPtr.Zero)
                {
                  dustPtr->velocity.X = (float) ((double) dustPtr->velocity.X * 1.0 + 2.0 - (double) this.velocity.X * 0.300000011920929);
                  dustPtr->velocity.Y = (float) ((double) dustPtr->velocity.Y * 1.0 + (double) (2 * (int) this.gravDir) - (double) this.velocity.Y * 0.300000011920929);
                  if ((int) this.rocketBoots == 1)
                  {
                    dustPtr->noGravity = true;
                  }
                  else
                  {
                    dustPtr->velocity.X *= 0.1f;
                    dustPtr->velocity.Y *= 0.1f;
                  }
                  X += 20;
                }
                else
                  break;
              }
            }
            --this.rocketDelay;
            this.velocity.Y -= 0.1f * (float) this.gravDir;
            if ((int) this.gravDir == 1)
            {
              if ((double) this.velocity.Y > 0.0)
                this.velocity.Y -= 0.5f;
              else if ((double) this.velocity.Y > -(double) num4 * 0.5)
                this.velocity.Y -= 0.1f;
              if ((double) this.velocity.Y < -(double) num4 * 1.5)
                this.velocity.Y = (float) (-(double) num4 * 1.5);
            }
            else
            {
              if ((double) this.velocity.Y < 0.0)
                this.velocity.Y += 0.5f;
              else if ((double) this.velocity.Y < (double) num4 * 0.5)
                this.velocity.Y += 0.1f;
              if ((double) this.velocity.Y > (double) num4 * 1.5)
                this.velocity.Y = num4 * 1.5f;
            }
          }
          else if (!flag1)
          {
            if (this.slowFall && (!this.controlDown && (int) this.gravDir == 1 || !this.controlUp && (int) this.gravDir == -1))
            {
              if (this.controlUp && (int) this.gravDir == 1 || this.controlDown && (int) this.gravDir == -1)
                this.velocity.Y += num10 / 10f * (float) this.gravDir;
              else
                this.velocity.Y += num10 / 3f * (float) this.gravDir;
            }
            else if ((int) this.wings > 0 && this.controlJump && (double) this.velocity.Y > 0.0)
            {
              this.fallStart = (short) (this.aabb.Y >> 4);
              if ((double) this.velocity.Y > 0.0)
                this.wingFrame = (byte) 2;
              this.velocity.Y += num10 / 3f * (float) this.gravDir;
              if ((int) this.gravDir == 1)
              {
                if ((double) this.velocity.Y > (double) num1 / 3.0 && !this.controlDown)
                  this.velocity.Y = num1 / 3f;
              }
              else if ((double) this.velocity.Y < -(double) num1 / 3.0 && !this.controlUp)
                this.velocity.Y = (float) (-(double) num1 / 3.0);
            }
            else
              this.velocity.Y += num10 * (float) this.gravDir;
          }
          if ((int) this.gravDir == 1)
          {
            if ((double) this.velocity.Y > (double) num1)
              this.velocity.Y = num1;
            if (this.slowFall && (double) this.velocity.Y > (double) num1 / 3.0 && !this.controlDown)
              this.velocity.Y = num1 / 3f;
            if (this.slowFall && (double) this.velocity.Y > (double) num1 / 5.0 && this.controlUp)
              this.velocity.Y = num1 / 10f;
          }
          else
          {
            if ((double) this.velocity.Y < -(double) num1)
              this.velocity.Y = -num1;
            if (this.slowFall && (double) this.velocity.Y < -(double) num1 / 3.0 && !this.controlUp)
              this.velocity.Y = (float) (-(double) num1 / 3.0);
            if (this.slowFall && (double) this.velocity.Y < -(double) num1 / 5.0 && this.controlDown)
              this.velocity.Y = (float) (-(double) num1 / 10.0);
          }
        }
        fixed (Item* objPtr = Main.item)
        {
          Item* pNewItem = objPtr + 199;
          for (int number2 = 199; number2 >= 0; --number2)
          {
            if ((int) pNewItem->active != 0 && (int) pNewItem->noGrabDelay == 0 && (int) pNewItem->owner == i)
            {
              if (this.aabb.Intersects(new Rectangle((int) pNewItem->position.X, (int) pNewItem->position.Y, (int) pNewItem->width, (int) pNewItem->height)))
              {
                if (this.isLocal() && ((int) this.inventory[(int) this.selectedItem].type != 0 || (int) this.itemAnimation <= 0))
                {
                  if ((int) pNewItem->type == 58)
                  {
                    Main.PlaySound(7, this.aabb.X, this.aabb.Y, 1);
                    this.statLife += (short) 20;
                    this.HealEffect(20);
                    if ((int) this.statLife > (int) this.statLifeMax)
                      this.statLife = this.statLifeMax;
                    pNewItem->Init();
                    NetMessage.CreateMessage2(21, (int) this.whoAmI, number2);
                    NetMessage.SendMessage();
                  }
                  else if ((int) pNewItem->type == 184)
                  {
                    Main.PlaySound(7, this.aabb.X, this.aabb.Y, 1);
                    this.statMana += (short) 100;
                    this.ManaEffect(100);
                    if ((int) this.statMana > (int) this.statManaMax2)
                      this.statMana = this.statManaMax2;
                    pNewItem->Init();
                    NetMessage.CreateMessage2(21, (int) this.whoAmI, number2);
                    NetMessage.SendMessage();
                  }
                  else if (this.GetItem(ref *pNewItem))
                  {
                    NetMessage.CreateMessage2(21, (int) this.whoAmI, number2);
                    NetMessage.SendMessage();
                  }
                }
              }
              else if (new Rectangle(this.aabb.X - 38, this.aabb.Y - 38, 96, 118).Intersects(new Rectangle((int) pNewItem->position.X, (int) pNewItem->position.Y, (int) pNewItem->width, (int) pNewItem->height)) && this.ItemSpace(pNewItem))
              {
                pNewItem->beingGrabbed = true;
                if (this.aabb.X + 10 > (int) pNewItem->position.X + ((int) pNewItem->width >> 1))
                {
                  if ((double) pNewItem->velocity.X < 4.0 + (double) this.velocity.X)
                    pNewItem->velocity.X += 0.45f;
                  if ((double) pNewItem->velocity.X < 0.0)
                    pNewItem->velocity.X += 0.3375f;
                }
                else
                {
                  if ((double) pNewItem->velocity.X > (double) this.velocity.X - 4.0)
                    pNewItem->velocity.X -= 0.45f;
                  if ((double) pNewItem->velocity.X > 0.0)
                    pNewItem->velocity.X -= 0.3375f;
                }
                if (this.aabb.Y + 21 > (int) pNewItem->position.Y + ((int) pNewItem->height >> 1))
                {
                  if ((double) pNewItem->velocity.Y < 4.0)
                    pNewItem->velocity.Y += 0.45f;
                  if ((double) pNewItem->velocity.Y < 0.0)
                    pNewItem->velocity.Y += 0.3375f;
                }
                else
                {
                  if ((double) pNewItem->velocity.Y > -4.0)
                    pNewItem->velocity.Y -= 0.45f;
                  if ((double) pNewItem->velocity.Y > 0.0)
                    pNewItem->velocity.Y -= 0.3375f;
                }
              }
            }
            --pNewItem;
          }
        }
        if (this.isLocal() && (int) this.talkNPC < 0)
        {
          if (this.controlUseTile)
          {
            if (this.releaseUseTile)
            {
              this.releaseUseTile = false;
              this.controlUseTile = false;
              if ((int) this.tileInteractY > 0)
                this.InteractWithTile((int) this.tileInteractX << 4, (int) this.tileInteractY << 4);
              else if ((int) this.npcChatBubble >= 0)
              {
                this.ui.npcShop = (byte) 0;
                this.ui.craftGuide = false;
                this.dropItemCheck();
                this.noThrow = (byte) 2;
                this.sign = (short) -1;
                this.chest = (short) -1;
                this.ui.editSign = false;
                this.talkNPC = this.npcChatBubble;
                this.ui.npcChatText = (UserString) Main.npc[(int) this.talkNPC].GetChat(this);
                Main.PlaySound(24);
                this.ui.ClearButtonTriggers();
              }
            }
          }
          else
            this.releaseUseTile = true;
        }
        if (this.tongued)
        {
          bool flag = false;
          if (NPC.wof >= 0)
          {
            float num11 = Main.npc[NPC.wof].position.X + (float) ((int) Main.npc[NPC.wof].width >> 1) + (float) ((int) Main.npc[NPC.wof].direction * 200);
            float num12 = Main.npc[NPC.wof].position.Y + (float) ((int) Main.npc[NPC.wof].height >> 1);
            Vector2 vector2 = new Vector2(this.position.X + 10f, this.position.Y + 21f);
            float num17 = num11 - vector2.X;
            float num18 = num12 - vector2.Y;
            float num19 = (float) Math.Sqrt((double) num17 * (double) num17 + (double) num18 * (double) num18);
            float num20 = 11f;
            float num21;
            if ((double) num19 > (double) num20)
            {
              num21 = num20 / num19;
            }
            else
            {
              num21 = 1f;
              flag = true;
            }
            float num22 = num17 * num21;
            float num23 = num18 * num21;
            this.velocity.X = num22;
            this.velocity.Y = num23;
          }
          else
            flag = true;
          if (flag && this.isLocal())
            this.DelBuff(Buff.ID.TONGUED);
        }
        if (this.isLocal())
        {
          if (NPC.wof >= 0 && (int) Main.npc[NPC.wof].active != 0)
          {
            int num11 = Main.npc[NPC.wof].aabb.X + 40;
            if ((int) Main.npc[NPC.wof].direction > 0)
              num11 -= 96;
            if (this.aabb.X + 20 > num11 && this.aabb.X < num11 + 140 && this.horrified)
            {
              this.noKnockback = false;
              this.Hurt(50, (int) Main.npc[NPC.wof].direction, false, false, Lang.deathMsg(-1, 113, 0, -1), false);
            }
            if (!this.horrified)
            {
              if (this.aabb.Y > ((int) Main.maxTilesY - 250) * 16 && this.aabb.X > num11 - 1920 && this.aabb.X < num11 + 1920)
              {
                this.AddBuff(37, 10, true);
                Main.PlaySound(4, Main.npc[NPC.wof].aabb.X, Main.npc[NPC.wof].aabb.Y, 10);
              }
            }
            else if (this.aabb.Y < ((int) Main.maxTilesY - 200) * 16)
              this.AddBuff(38, 10, true);
            else if ((int) Main.npc[NPC.wof].direction < 0)
            {
              if (this.aabb.X + 10 > Main.npc[NPC.wof].aabb.X + ((int) Main.npc[NPC.wof].width >> 1) + 40)
                this.AddBuff(38, 10, true);
            }
            else if (this.aabb.X + 10 < Main.npc[NPC.wof].aabb.X + ((int) Main.npc[NPC.wof].width >> 1) - 40)
              this.AddBuff(38, 10, true);
            if (this.tongued)
            {
              this.controlHook = false;
              this.controlUseItem = false;
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == i && (int) Main.projectile[index].aiStyle == 7)
                  Main.projectile[index].Kill();
              }
              Vector2 vector2 = new Vector2(this.position.X + 10f, this.position.Y + 21f);
              float num12 = Main.npc[NPC.wof].position.X + (float) ((int) Main.npc[NPC.wof].width / 2) - vector2.X;
              float num17 = Main.npc[NPC.wof].position.Y + (float) ((int) Main.npc[NPC.wof].height / 2) - vector2.Y;
              if ((double) num12 * (double) num12 + (double) num17 * (double) num17 > 9000000.0)
                this.KillMe(1000.0, 0, false, Lang.deathMsg(-1, 0, 0, 5));
              else if (Main.npc[NPC.wof].aabb.X < 608 || Main.npc[NPC.wof].aabb.X > ((int) Main.maxTilesX - 38) * 16)
                this.KillMe(1000.0, 0, false, Lang.deathMsg(-1, 0, 0, 6));
            }
          }
          this.UpdateGrappleItemSlot();
          if (this.controlHook)
          {
            if (this.releaseHook)
            {
              this.releaseHook = false;
              this.QuickGrapple();
            }
          }
          else
            this.releaseHook = true;
          if ((int) this.talkNPC >= 0 && (!new Rectangle(this.aabb.X + 10 - 80, this.aabb.Y + 21 - 64, 160, 128).Intersects(Main.npc[(int) this.talkNPC].aabb) || (int) this.chest != -1 || (int) Main.npc[(int) this.talkNPC].active == 0))
          {
            if ((int) this.chest == -1)
              Main.PlaySound(11);
            this.talkNPC = (short) -1;
            this.ui.npcChatText = (UserString) null;
          }
          if (!this.immune)
          {
            for (int npcId = 0; npcId < 196; ++npcId)
            {
              if ((int) Main.npc[npcId].active != 0 && !Main.npc[npcId].friendly && (Main.npc[npcId].damage > 0 && this.aabb.Intersects(Main.npc[npcId].aabb)))
              {
                int num11 = 1;
                if (Main.npc[npcId].aabb.X + ((int) Main.npc[npcId].width >> 1) < this.aabb.X + 10)
                  num11 = -1;
                int Damage = Main.DamageVar(Main.npc[npcId].damage);
                if (this.isLocal() && this.thorns && !Main.npc[npcId].dontTakeDamage)
                {
                  int num12 = Damage / 3;
                  Main.npc[npcId].StrikeNPC(num12, 10f, num11, false, false);
                  NetMessage.SendNpcHurt(npcId, num12, 10.0, num11, false);
                }
                if ((int) Main.npc[npcId].netID == -6)
                {
                  if (Main.rand.Next(4) == 0)
                    this.AddBuff(22, 900, true);
                }
                else
                {
                  byte num12 = Main.npc[npcId].type;
                  if ((uint) num12 <= 104U)
                  {
                    if ((uint) num12 <= 34U)
                    {
                      switch (num12)
                      {
                        case (byte) 23:
                        case (byte) 25:
                          if (Main.rand.Next(3) == 0)
                          {
                            this.AddBuff(24, 420, true);
                            goto label_776;
                          }
                          else
                            goto label_776;
                        case (byte) 34:
                          goto label_753;
                        default:
                          goto label_776;
                      }
                    }
                    else
                    {
                      switch (num12)
                      {
                        case (byte) 75:
                          if (Main.rand.Next(10) == 0)
                          {
                            this.AddBuff(35, 420, true);
                            goto label_776;
                          }
                          else if (Main.rand.Next(8) == 0)
                          {
                            this.AddBuff(32, 900, true);
                            goto label_776;
                          }
                          else
                            goto label_776;
                        case (byte) 77:
                          if (Main.rand.Next(6) == 0)
                          {
                            this.AddBuff(36, 18000, true);
                            goto label_776;
                          }
                          else
                            goto label_776;
                        case (byte) 78:
                        case (byte) 82:
                          if (Main.rand.Next(8) == 0)
                          {
                            this.AddBuff(32, 900, true);
                            goto label_776;
                          }
                          else
                            goto label_776;
                        case (byte) 79:
                          goto label_747;
                        case (byte) 80:
                        case (byte) 93:
                          goto label_769;
                        case (byte) 81:
                          break;
                        case (byte) 83:
                        case (byte) 84:
                          goto label_753;
                        case (byte) 102:
                        case (byte) 104:
                          if (Main.rand.Next(8) == 0)
                          {
                            this.AddBuff(30, 2700, true);
                            goto label_776;
                          }
                          else
                            goto label_776;
                        case (byte) 103:
                          if (Main.rand.Next(5) == 0)
                          {
                            this.AddBuff(35, 420, true);
                            goto label_776;
                          }
                          else
                            goto label_776;
                        default:
                          goto label_776;
                      }
                    }
                  }
                  else if ((uint) num12 <= 112U)
                  {
                    if ((int) num12 != 109)
                    {
                      if ((int) num12 == 112 && Main.rand.Next(20) == 0)
                      {
                        this.AddBuff(33, 18000, true);
                        goto label_776;
                      }
                      else
                        goto label_776;
                    }
                    else
                      goto label_769;
                  }
                  else
                  {
                    switch (num12)
                    {
                      case (byte) 141:
                        if (Main.rand.Next(2) == 0)
                        {
                          this.AddBuff(20, 600, true);
                          goto label_776;
                        }
                        else
                          goto label_776;
                      case (byte) 150:
                        break;
                      case (byte) 151:
                        if (Main.rand.Next(4) == 0)
                        {
                          this.AddBuff(22, 900, true);
                          goto label_776;
                        }
                        else if (Main.rand.Next(3) == 0)
                        {
                          this.AddBuff(23, 240, true);
                          goto label_776;
                        }
                        else
                          goto label_776;
                      case (byte) 152:
                        goto label_747;
                      case (byte) 155:
                        goto label_769;
                      case (byte) 158:
                        goto label_753;
                      default:
                        goto label_776;
                    }
                  }
                  if (Main.rand.Next(4) == 0)
                  {
                    this.AddBuff(22, 900, true);
                    goto label_776;
                  }
                  else
                    goto label_776;
label_747:
                  if (Main.rand.Next(4) == 0)
                  {
                    this.AddBuff(22, 900, true);
                    goto label_776;
                  }
                  else if (Main.rand.Next(5) == 0)
                  {
                    this.AddBuff(35, 420, true);
                    goto label_776;
                  }
                  else
                    goto label_776;
label_753:
                  if (Main.rand.Next(3) == 0)
                  {
                    this.AddBuff(23, 240, true);
                    goto label_776;
                  }
                  else
                    goto label_776;
label_769:
                  if (Main.rand.Next(12) == 0)
                    this.AddBuff(31, 420, true);
                }
label_776:
                this.Hurt(Damage, -num11, false, false, Lang.deathMsg(-1, (int) Main.npc[npcId].netID, 0, -1), false);
              }
            }
          }
          int dmg = Collision.HurtTiles(ref this.position, ref this.velocity, 20, 42, this.fireWalk);
          if (dmg != 0)
            this.Hurt(Main.DamageVar(dmg), 0, false, false, Lang.deathMsg(-1, 0, 0, -1), false);
        }
        if ((int) this.grappling[0] >= 0)
        {
          this.wingFrame = (byte) 1;
          if ((double) this.velocity.Y == 0.0 || this.wet && (double) this.velocity.Y > -0.02 && (double) this.velocity.Y < 0.02)
            this.wingFrame = (byte) 0;
          this.wingTime = (short) 90;
          this.rocketTime = (sbyte) 7;
          this.rocketDelay = (sbyte) 0;
          this.rocketFrame = false;
          this.canRocket = false;
          this.rocketRelease = false;
          this.fallStart = (short) (this.aabb.Y >> 4);
          float num11 = 0.0f;
          float num12 = 0.0f;
          for (int index = 0; index < (int) this.grapCount; ++index)
          {
            num11 += Main.projectile[(int) this.grappling[index]].position.X + (float) ((int) Main.projectile[(int) this.grappling[index]].width >> 1);
            num12 += Main.projectile[(int) this.grappling[index]].position.Y + (float) ((int) Main.projectile[(int) this.grappling[index]].height >> 1);
          }
          float num17 = num11 / (float) this.grapCount;
          float num18 = num12 / (float) this.grapCount;
          Vector2 vector2 = new Vector2(this.position.X + 10f, this.position.Y + 21f);
          float num19 = num17 - vector2.X;
          float num20 = num18 - vector2.Y;
          float num21 = (float) ((double) num19 * (double) num19 + (double) num20 * (double) num20);
          if ((double) num21 > 121.0)
          {
            float num22 = 11f / (float) Math.Sqrt((double) num21);
            num19 *= num22;
            num20 *= num22;
          }
          this.velocity.X = num19;
          this.velocity.Y = num20;
          if ((int) this.itemAnimation == 0)
          {
            if ((double) this.velocity.X > 0.0)
              this.direction = (sbyte) 1;
            else if ((double) this.velocity.X < 0.0)
              this.direction = (sbyte) -1;
          }
          if (this.controlJump)
          {
            if (this.releaseJump)
            {
              if (((double) this.velocity.Y == 0.0 || this.wet && (double) this.velocity.Y > -0.02 && (double) this.velocity.Y < 0.02) && !this.controlDown)
              {
                this.velocity.Y = -num4;
                this.jump = num3 >> 1;
                this.releaseJump = false;
              }
              else
              {
                this.velocity.Y += 0.01f;
                this.releaseJump = false;
              }
              if (this.doubleJump)
                this.jumpAgain = true;
              this.grappling[0] = (short) 0;
              this.grapCount = (byte) 0;
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].owner == i && (int) Main.projectile[index].aiStyle == 7 && (int) Main.projectile[index].active != 0)
                  Main.projectile[index].Kill();
              }
            }
          }
          else
            this.releaseJump = true;
        }
        Vector2i vector2i = Collision.StickyTiles(this.position, this.velocity, 20, 42);
        if (vector2i.Y != -1 && vector2i.X != -1)
        {
          if (this.isLocal() && ((double) this.velocity.X != 0.0 || (double) this.velocity.Y != 0.0))
          {
            ++this.stickyBreak;
            if ((int) this.stickyBreak > Main.rand.Next(20, 100))
            {
              this.stickyBreak = (byte) 0;
              if (WorldGen.KillTile(vector2i.X, vector2i.Y))
              {
                NetMessage.CreateMessage5(17, 0, vector2i.X, vector2i.Y, 0, 0);
                NetMessage.SendMessage();
              }
            }
          }
          this.fallStart = (short) (this.aabb.Y >> 4);
          this.jump = 0;
          if ((double) this.velocity.X > 1.0)
            this.velocity.X = 1f;
          else if ((double) this.velocity.X < -1.0)
            this.velocity.X = -1f;
          if ((double) this.velocity.X > 0.75 || (double) this.velocity.X < -0.75)
            this.velocity.X *= 0.85f;
          else
            this.velocity.X *= 0.6f;
          if ((double) this.velocity.Y > 1.0)
            this.velocity.Y = 1f;
          else if ((double) this.velocity.Y < -5.0)
            this.velocity.Y = -5f;
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y *= 0.96f;
          else
            this.velocity.Y *= 0.3f;
        }
        else
          this.stickyBreak = (byte) 0;
        bool flag5 = Collision.DrownCollision(ref this.position, 20, 42, (int) this.gravDir);
        if ((int) this.armor[0].type == 250)
          flag5 = true;
        if ((int) this.inventory[(int) this.selectedItem].type == 186)
        {
          try
          {
            int index1 = this.aabb.X + 10 + 6 * (int) this.direction >> 4;
            int num11 = 0;
            if ((int) this.gravDir == -1)
              num11 = 42;
            int index2 = this.aabb.Y + num11 - 44 * (int) this.gravDir >> 4;
            if ((int) Main.tile[index1, index2].liquid < 128)
            {
              if ((int) Main.tile[index1, index2].active != 0)
              {
                if (Main.tileSolidNotSolidTop[(int) Main.tile[index1, index2].type])
                  goto label_838;
              }
              flag5 = false;
            }
          }
          catch
          {
          }
        }
label_838:
        bool flag6 = flag5 ^ this.gills;
        if (this.isLocal())
        {
          if (this.merman)
            flag6 = false;
          if (flag6)
          {
            ++this.breathCD;
            int num11 = 7;
            if ((int) this.inventory[(int) this.selectedItem].type == 186)
              num11 *= 2;
            if (this.accDivingHelm)
              num11 *= 4;
            if ((int) this.breathCD >= num11)
            {
              this.breathCD = (short) 0;
              --this.breath;
              if ((int) this.breath == 0)
                Main.PlaySound(23);
              if ((int) this.breath <= 0)
              {
                this.lifeRegenTime = 0;
                this.breath = (short) 0;
                this.statLife -= (short) 2;
                if ((int) this.statLife <= 0)
                {
                  this.statLife = (short) 0;
                  this.KillMe(10.0, 0, false, Lang.deathMsg(-1, 0, 0, 1));
                }
              }
            }
          }
          else
          {
            this.breath += (short) 3;
            if ((int) this.breath > 200)
              this.breath = (short) 200;
            this.breathCD = (short) 0;
          }
        }
        if (flag6 && Main.rand.Next(20) == 0 && !this.lavaWet)
        {
          int num11;
          if ((int) this.gravDir != -1)
          {
            num11 = 0;
          }
          else
          {
            int num12 = num11 = 30;
          }
          int num17 = num11;
          if ((int) this.inventory[(int) this.selectedItem].type == 186)
            Main.dust.NewDust(this.aabb.X + 10 * (int) this.direction + 4, this.aabb.Y + num17 - 54 * (int) this.gravDir, 12, 8, 34, 0.0, 0.0, 0, new Color(), 1.20000004768372);
          else
            Main.dust.NewDust(this.aabb.X + 12 * (int) this.direction, this.aabb.Y + num17 + 4 * (int) this.gravDir, 12, 8, 34, 0.0, 0.0, 0, new Color(), 1.20000004768372);
        }
        int Height = 42;
        if (this.waterWalk)
          Height -= 6;
        bool flag7 = Collision.LavaCollision(ref this.position, 20, Height);
        if (flag7)
        {
          if (!this.lavaImmune && !this.immune && this.isLocal())
          {
            this.AddBuff(24, 420, true);
            this.Hurt(80, 0, false, false, Lang.deathMsg(-1, 0, 0, 2), false);
          }
          this.lavaWet = true;
        }
        if (Collision.WetCollision(ref this.position, 20, 42))
        {
          if (this.onFire && !this.lavaWet)
            this.DelBuff(Buff.ID.ON_FIRE);
          if (!this.wet)
          {
            if ((int) this.wetCount == 0)
            {
              this.wetCount = (byte) 10;
              if (!flag7)
              {
                for (int index = 0; index < 32; ++index)
                {
                  Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + 21 - 8, 32, 24, 33, 0.0, 0.0, 0, new Color(), 1.0);
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
                Main.PlaySound(19, this.aabb.X, this.aabb.Y, 0);
              }
              else
              {
                for (int index = 0; index < 16; ++index)
                {
                  Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + 21 - 8, 32, 24, 35, 0.0, 0.0, 0, new Color(), 1.0);
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
                Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
              }
            }
            this.wet = true;
          }
        }
        else if (this.wet)
        {
          this.wet = false;
          if (this.jump > num3 / 5)
            this.jump = num3 / 5;
          if ((int) this.wetCount == 0)
          {
            this.wetCount = (byte) 16;
            if (!this.lavaWet)
            {
              for (int index = 0; index < 24; ++index)
              {
                Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + 21, 32, 24, 33, 0.0, 0.0, 0, new Color(), 1.0);
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
              Main.PlaySound(19, this.aabb.X, this.aabb.Y, 0);
            }
            else
            {
              for (int index = 0; index < 8; ++index)
              {
                Dust* dustPtr = Main.dust.NewDust(this.aabb.X - 6, this.aabb.Y + 21 - 8, 32, 24, 35, 0.0, 0.0, 0, new Color(), 1.0);
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
              Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
            }
          }
        }
        if (!this.wet)
          this.lavaWet = false;
        if ((int) this.wetCount > 0)
          --this.wetCount;
        this.oldPosition = this.position;
        if (this.tongued)
        {
          this.position.X += this.velocity.X;
          this.position.Y += this.velocity.Y;
        }
        else if (this.wet && !this.merman)
        {
          Vector2 vector2_1 = this.velocity;
          Collision.TileCollision(ref this.position, ref this.velocity, 20, 42, this.controlDown, false);
          Vector2 vector2_2 = this.velocity;
          vector2_2.X *= 0.5f;
          vector2_2.Y *= 0.5f;
          if ((double) this.velocity.X != (double) vector2_1.X)
            vector2_2.X = this.velocity.X;
          if ((double) this.velocity.Y != (double) vector2_1.Y)
            vector2_2.Y = this.velocity.Y;
          this.position.X += vector2_2.X;
          this.position.Y += vector2_2.Y;
        }
        else
        {
          Collision.TileCollision(ref this.position, ref this.velocity, 20, 42, this.controlDown, false);
          if (this.waterWalk)
            this.velocity = Collision.WaterCollision(this.position, this.velocity, 20, 42, this.controlDown);
          this.position.X += this.velocity.X;
          this.position.Y += this.velocity.Y;
        }
        if ((double) this.velocity.Y == 0.0)
        {
          if ((int) this.gravDir == 1 && Collision.up)
          {
            this.velocity.Y = 0.01f;
            if (!this.merman)
              this.jump = 0;
          }
          else if ((int) this.gravDir == -1 && Collision.down)
          {
            this.velocity.Y = -0.01f;
            if (!this.merman)
              this.jump = 0;
          }
        }
        if (this.isLocal())
        {
          switch (this.hellAndBackState)
          {
            case (byte) 0:
            case (byte) 2:
              if (this.aabb.Y < Main.worldSurfacePixels)
              {
                ++this.hellAndBackState;
                break;
              }
              else
                break;
            case (byte) 1:
              if (this.aabb.Y > Main.magmaLayerPixels)
              {
                ++this.hellAndBackState;
                break;
              }
              else
                break;
            case (byte) 3:
              ++this.hellAndBackState;
              this.ui.SetTriggerState(Trigger.WentDownAndUpWithoutDyingOrWarping);
              break;
          }
          Collision.SwitchTiles(this.position, 20, 42, this.oldPosition);
        }
        if ((double) this.position.X < 560.0)
        {
          this.position.X = 560f;
          this.velocity.X = 0.0f;
        }
        else if ((double) this.position.X + 20.0 > (double) (Main.rightWorld - 544 - 32))
        {
          this.position.X = (float) (Main.rightWorld - 544 - 32 - 20);
          this.velocity.X = 0.0f;
        }
        if (this.ui != null)
        {
          if (this.aabb.Y - 42 < 560)
            this.ui.SetTriggerState(Trigger.HighestPosition);
          else if (this.aabb.Y + 42 > Main.bottomWorld - 544 - 32 - 42)
            this.ui.SetTriggerState(Trigger.LowestPosition);
        }
        if ((double) this.position.Y < 560.0)
        {
          this.position.Y = 560f;
          if ((double) this.velocity.Y < 0.11)
            this.velocity.Y = 0.11f;
        }
        else if ((double) this.position.Y > (double) (Main.bottomWorld - 544 - 32 - 42))
        {
          this.position.Y = (float) (Main.bottomWorld - 544 - 32 - 42);
          this.velocity.Y = 0.0f;
        }
        this.aabb.X = (int) this.position.X;
        this.aabb.Y = (int) this.position.Y;
        this.ItemCheck(i);
        this.PlayerFrame();
        if ((int) this.statLife > (int) this.statLifeMax)
          this.statLife = this.statLifeMax;
        this.grappling[0] = (short) -1;
        this.grapCount = (byte) 0;
      }
      if (!this.isLocal() || Main.netMode < 1)
        return;
      NetPlayer netPlayer1 = this.ui.netPlayer;
      bool flag8 = false;
      for (int number2 = 0; number2 <= 48; ++number2)
      {
        if (this.inventory[number2].IsNotTheSameAs(ref netPlayer1.inventory[number2]))
        {
          netPlayer1.inventory[number2] = this.inventory[number2];
          NetMessage.CreateMessage2(5, i, number2);
          NetMessage.SendMessage();
        }
      }
      for (int index = 0; index < 11; ++index)
      {
        if (this.armor[index].IsNotTheSameAs(ref netPlayer1.armor[index]))
        {
          netPlayer1.armor[index] = this.armor[index];
          NetMessage.CreateMessage2(5, i, index + 49);
          NetMessage.SendMessage();
        }
      }
      if ((int) this.chest != (int) netPlayer1.chest)
      {
        netPlayer1.chest = this.chest;
        NetMessage.CreateMessage2(33, i, (int) this.chest);
        NetMessage.SendMessage();
      }
      if ((int) this.talkNPC != (int) netPlayer1.talkNPC)
      {
        netPlayer1.talkNPC = this.talkNPC;
        NetMessage.CreateMessage1(40, i);
        NetMessage.SendMessage();
      }
      if (this.zoneEvil != netPlayer1.zoneEvil)
      {
        netPlayer1.zoneEvil = this.zoneEvil;
        flag8 = true;
      }
      if (this.zoneMeteor != netPlayer1.zoneMeteor)
      {
        netPlayer1.zoneMeteor = this.zoneMeteor;
        flag8 = true;
      }
      if (this.zoneDungeon != netPlayer1.zoneDungeon)
      {
        netPlayer1.zoneDungeon = this.zoneDungeon;
        flag8 = true;
      }
      if (this.zoneJungle != netPlayer1.zoneJungle)
      {
        netPlayer1.zoneJungle = this.zoneJungle;
        flag8 = true;
      }
      if (this.zoneHoly != netPlayer1.zoneHoly)
      {
        netPlayer1.zoneHoly = this.zoneHoly;
        flag8 = true;
      }
      if (flag8)
      {
        flag8 = false;
        NetMessage.CreateMessage1(36, i);
        NetMessage.SendMessage();
      }
      for (int index = 0; index < 10; ++index)
      {
        if ((int) this.buff[index].Type != (int) netPlayer1.buff[index].Type)
        {
          netPlayer1.buff[index].Type = this.buff[index].Type;
          flag8 = true;
        }
      }
      if (flag8)
      {
        NetMessage.CreateMessage1(50, i);
        NetMessage.SendMessage();
        NetMessage.CreateMessage1(13, i);
        NetMessage.SendMessage();
      }
      if (this.ui.localGamer == null)
        return;
      LeaderboardInfo.SubmitStatistics(this.ui.Statistics, (NetworkGamer) this.ui.localGamer);
    }

    private unsafe bool CanInteractWithTile(int x, int y)
    {
      int i = x >> 4;
      int j = y >> 4;
      fixed (Tile* tilePtr = &Main.tile[i, j])
      {
        if ((int) tilePtr->active == 0)
          return false;
        int num1 = (int) tilePtr->type;
        switch (num1)
        {
          case 136:
          case 139:
          case 144:
          case 132:
            return true;
          case 128:
            int num2 = (int) tilePtr->frameX % 100 % 36;
            if (num2 == 18)
              num2 = (int) tilePtr[-1440].frameX;
            return num2 >= 100;
          case 104:
          case 125:
            return true;
          case 85:
          case 55:
            return true;
          case 97:
          case 21:
          case 29:
            if ((int) this.talkNPC != -1)
              return false;
            int num3 = -1;
            int num4 = (int) tilePtr->frameX;
            int num5 = (int) tilePtr->frameY;
            int X = i - (num4 / 18 & 1);
            int Y = j - num5 / 18;
            if (num1 == 29)
              num3 = -2;
            else if (num1 == 97)
              num3 = -3;
            int num6 = (int) tilePtr->frameX;
            if (Main.netMode == 1 && num3 == -1 && (num6 < 72 || num6 > 106) && (num6 < 144 || num6 > 178))
              return true;
            if (num3 == -1)
            {
              bool flag = false;
              if (num6 >= 72 && num6 <= 106 || num6 >= 144 && num6 <= 178)
              {
                int num7 = 327;
                if (num6 >= 144 && num6 <= 178)
                  num7 = 329;
                flag = true;
                for (int index = 0; index < 48; ++index)
                {
                  if ((int) this.inventory[index].type == num7 && (int) this.inventory[index].stack > 0)
                    return true;
                }
              }
              if (!flag)
                num3 = Chest.FindChest(X, Y);
            }
            return num3 != -1;
          case 79:
            return true;
          case 33:
          case 49:
          case 4:
          case 13:
            return !this.ui.smartCursor;
          case 50:
            return !this.ui.smartCursor && (int) tilePtr->frameX == 90;
          case 10:
            return WorldGen.CanOpenDoor(i, j);
          case 11:
            return WorldGen.CanCloseDoor(i, j);
          default:
            // ISSUE: __unpin statement
            __unpin(tilePtr);
            return false;
        }
      }
    }

    private bool InteractWithTile(int x, int y)
    {
      int index1 = x >> 4;
      int index2 = y >> 4;
      if ((int) Main.tile[index1, index2].active == 0)
        return false;
      int num1 = (int) Main.tile[index1, index2].type;
      switch (num1)
      {
        case 136:
        case 144:
        case 132:
          WorldGen.hitSwitch(index1, index2);
          NetMessage.CreateMessage2(59, index1, index2);
          NetMessage.SendMessage();
          return true;
        case 139:
          Main.PlaySound(28, x, y, 0);
          WorldGen.SwitchMB(index1, index2);
          return true;
        case 128:
          int num2 = (int) Main.tile[index1, index2].frameX % 100 % 36;
          if (num2 == 18)
          {
            --index1;
            num2 = (int) Main.tile[index1, index2].frameX;
          }
          if (num2 < 100)
            return false;
          WorldGen.KillTile(index1, index2, true, false, false);
          NetMessage.CreateMessage5(17, 0, index1, index2, 1, 0);
          NetMessage.SendMessage();
          return true;
        case 104:
          string str1 = "AM";
          double num3 = (double) Main.gameTime.time;
          if (!Main.gameTime.dayTime)
            num3 += 54000.0;
          double num4 = num3 / 86400.0 * 24.0 - 7.5 - 12.0;
          if (num4 < 0.0)
            num4 += 24.0;
          if (num4 >= 12.0)
            str1 = "PM";
          int num5 = (int) num4;
          int num6 = (int) ((num4 - (double) num5) * 60.0);
          string str2 = ToStringExtensions.ToStringLookup(num6);
          if (num6 < 10)
            str2 = "0" + str2;
          if (num5 > 12)
            num5 -= 12;
          if (num5 == 0)
            num5 = 12;
          Main.NewText(Lang.inter[34] + ToStringExtensions.ToStringLookup(num5) + ":" + str2 + " " + str1, (int) byte.MaxValue, 240, 20);
          return true;
        case 125:
          this.AddBuff(29, 36000, true);
          Main.PlaySound(2, this.aabb.X, this.aabb.Y, 4);
          return true;
        case 85:
        case 55:
          bool flag1 = true;
          if ((int) this.sign >= 0 && Sign.ReadSign(index1, index2) == (int) this.sign)
          {
            this.sign = (short) -1;
            this.ui.npcChatText = (UserString) null;
            this.ui.editSign = false;
            Main.PlaySound(11);
            flag1 = false;
          }
          if (flag1)
          {
            if (Main.netMode != 1)
            {
              this.talkNPC = (short) -1;
              this.ui.CloseInventory();
              this.ui.editSign = false;
              Main.PlaySound(10);
              int index3 = Sign.ReadSign(index1, index2);
              this.sign = (short) index3;
              this.ui.npcChatText = Main.sign[index3].text;
              this.ui.ClearButtonTriggers();
            }
            else
            {
              int number2 = index1 - ((int) Main.tile[index1, index2].frameX / 18 & 1);
              int number3 = index2 - (int) Main.tile[number2, index2].frameY / 18;
              switch (Main.tile[number2, number3].type)
              {
                case (byte) 55:
                case (byte) 85:
                  NetMessage.CreateMessage3(46, (int) this.whoAmI, number2, number3);
                  NetMessage.SendMessage();
                  break;
              }
            }
          }
          return true;
        case 97:
        case 21:
        case 29:
          if ((int) this.talkNPC == -1)
          {
            int num7 = -1;
            int num8 = (int) Main.tile[index1, index2].frameX;
            int num9 = (int) Main.tile[index1, index2].frameY;
            int index3 = index1 - (num8 / 18 & 1);
            int index4 = index2 - num9 / 18;
            if (num1 == 29)
              num7 = -2;
            else if (num1 == 97)
              num7 = -3;
            else
              this.ui.chestText = num8 < 216 ? (num8 < 180 ? Lang.itemName(48) : Lang.itemName(343)) : Lang.itemName(348);
            int num10 = (int) Main.tile[index3, index4].frameX;
            if (Main.netMode == 1 && num7 == -1 && (num10 < 72 || num10 > 106) && (num10 < 144 || num10 > 178))
            {
              if (index3 == (int) this.chestX && index4 == (int) this.chestY && (int) this.chest != -1)
              {
                this.chest = (short) -1;
                Main.PlaySound(11);
              }
              else
              {
                NetMessage.CreateMessage3(31, (int) this.whoAmI, index3, index4);
                NetMessage.SendMessage();
              }
              return true;
            }
            else
            {
              if (num7 == -1)
              {
                bool flag2 = false;
                if (num10 >= 72 && num10 <= 106 || num10 >= 144 && num10 <= 178)
                {
                  int num11 = 327;
                  if (num10 >= 144 && num10 <= 178)
                    num11 = 329;
                  flag2 = true;
                  for (int index5 = 0; index5 < 48; ++index5)
                  {
                    if ((int) this.inventory[index5].type == num11 && (int) this.inventory[index5].stack > 0)
                    {
                      if (num11 != 329)
                      {
                        --this.inventory[index5].stack;
                        if ((int) this.inventory[index5].stack <= 0)
                          this.inventory[index5].Init();
                      }
                      Chest.Unlock(index3, index4);
                      NetMessage.CreateMessage3(52, (int) this.whoAmI, index3, index4);
                      NetMessage.SendMessage();
                      return true;
                    }
                  }
                }
                if (!flag2)
                  num7 = Chest.FindChest(index3, index4);
              }
              if (num7 != -1)
              {
                if (num7 == (int) this.chest)
                {
                  this.chest = (short) -1;
                  Main.PlaySound(11);
                }
                else
                {
                  if (num7 != (int) this.chest && (int) this.chest == -1)
                    Main.PlaySound(10);
                  else
                    Main.PlaySound(12);
                  this.chest = (short) num7;
                  this.chestX = (short) index3;
                  this.chestY = (short) index4;
                  this.ui.OpenInventory();
                }
                return true;
              }
            }
          }
          return false;
        case 79:
          int num12 = index1;
          int num13 = index2;
          int num14 = num12 - (int) Main.tile[index1, index2].frameX / 18;
          int x1 = (int) Main.tile[index1, index2].frameX < 72 ? num14 + 2 : num14 + 5;
          int y1 = num13 - (int) Main.tile[index1, index2].frameY / 18 + 2;
          if (!Player.CheckSpawn(x1, y1))
            return false;
          this.ChangeSpawn(x1, y1);
          Main.NewText(Lang.menu[57], (int) byte.MaxValue, 240, 20);
          return true;
        case 33:
        case 49:
        case 4:
        case 13:
          WorldGen.KillTile(index1, index2);
          NetMessage.CreateMessage5(17, 0, index1, index2, 0, 0);
          NetMessage.SendMessage();
          return true;
        case 50:
          if ((int) Main.tile[index1, index2].frameX != 90)
            return false;
          else
            goto case 33;
        case 10:
          int number3_1 = WorldGen.OpenDoor(index1, index2, (int) this.direction);
          if (number3_1 == 0)
            return false;
          ++this.ui.totalDoorsOpened;
          NetMessage.CreateMessage3(19, index1, index2, number3_1);
          NetMessage.SendMessage();
          return true;
        case 11:
          if (!WorldGen.CloseDoor(index1, index2, false))
            return false;
          ++this.ui.totalDoorsClosed;
          NetMessage.CreateMessage2(24, index1, index2);
          NetMessage.SendMessage();
          return true;
        default:
          return false;
      }
    }

    public void NetClone(NetPlayer clonePlayer)
    {
      clonePlayer.zoneEvil = this.zoneEvil;
      clonePlayer.zoneMeteor = this.zoneMeteor;
      clonePlayer.zoneDungeon = this.zoneDungeon;
      clonePlayer.zoneJungle = this.zoneJungle;
      clonePlayer.zoneHoly = this.zoneHoly;
      clonePlayer.selectedItem = this.selectedItem;
      clonePlayer.controlUp = this.controlUp;
      clonePlayer.controlDown = this.controlDown;
      clonePlayer.controlLeft = this.controlLeft;
      clonePlayer.controlRight = this.controlRight;
      clonePlayer.controlJump = this.controlJump;
      clonePlayer.controlUseItem = this.controlUseItem;
      clonePlayer.statLife = this.statLife;
      clonePlayer.statLifeMax = this.statLifeMax;
      clonePlayer.statMana = this.statMana;
      clonePlayer.statManaMax = this.statManaMax;
      clonePlayer.chest = this.chest;
      clonePlayer.talkNPC = this.talkNPC;
      for (int index = 0; index <= 48; ++index)
        clonePlayer.inventory[index] = this.inventory[index];
      for (int index = 0; index < 11; ++index)
        clonePlayer.armor[index] = this.armor[index];
      for (int index = 0; index < 10; ++index)
        clonePlayer.buff[index].Type = this.buff[index].Type;
    }

    public bool SellItem(int price, int stack)
    {
      if (price <= 0)
        return false;
      Item[] objArray = new Item[48];
      for (int index = 0; index < 48; ++index)
        objArray[index] = this.inventory[index];
      int num = price / 5 * stack;
      if (num < 1)
        num = 1;
      bool flag = false;
      while (num >= 1000000 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && ((int) this.inventory[i].type == 0 || (int) this.inventory[i].stack == 0))
            index = i;
          while ((int) this.inventory[i].type == 74 && (int) this.inventory[i].stack < (int) this.inventory[i].maxStack && num >= 1000000)
          {
            ++this.inventory[i].stack;
            num -= 1000000;
            this.DoCoins(i);
            if ((int) this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 1000000)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(74, 1, false);
            num -= 1000000;
          }
        }
      }
      while (num >= 10000 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && ((int) this.inventory[i].type == 0 || (int) this.inventory[i].stack == 0))
            index = i;
          while ((int) this.inventory[i].type == 73 && (int) this.inventory[i].stack < (int) this.inventory[i].maxStack && num >= 10000)
          {
            ++this.inventory[i].stack;
            num -= 10000;
            this.DoCoins(i);
            if ((int) this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 10000)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(73, 1, false);
            num -= 10000;
          }
        }
      }
      while (num >= 100 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && ((int) this.inventory[i].type == 0 || (int) this.inventory[i].stack == 0))
            index = i;
          while ((int) this.inventory[i].type == 72 && (int) this.inventory[i].stack < (int) this.inventory[i].maxStack && num >= 100)
          {
            ++this.inventory[i].stack;
            num -= 100;
            this.DoCoins(i);
            if ((int) this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 100)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(72, 1, false);
            num -= 100;
          }
        }
      }
      while (num >= 1 && !flag)
      {
        int index = -1;
        for (int i = 43; i >= 0; --i)
        {
          if (index == -1 && ((int) this.inventory[i].type == 0 || (int) this.inventory[i].stack == 0))
            index = i;
          while ((int) this.inventory[i].type == 71 && (int) this.inventory[i].stack < (int) this.inventory[i].maxStack && num >= 1)
          {
            ++this.inventory[i].stack;
            --num;
            this.DoCoins(i);
            if ((int) this.inventory[i].stack == 0 && index == -1)
              index = i;
          }
        }
        if (num >= 1)
        {
          if (index == -1)
          {
            flag = true;
          }
          else
          {
            this.inventory[index].SetDefaults(71, 1, false);
            --num;
          }
        }
      }
      if (!flag)
        return true;
      for (int index = 0; index < 48; ++index)
        this.inventory[index] = objArray[index];
      return false;
    }

    public bool BuyItem(int price)
    {
      if (price == 0)
        return true;
      int num1 = 0;
      Item[] objArray = new Item[44];
      for (int index = 0; index < 44; ++index)
      {
        objArray[index] = this.inventory[index];
        if ((int) this.inventory[index].type == 71)
          num1 += (int) this.inventory[index].stack;
        if ((int) this.inventory[index].type == 72)
          num1 += (int) this.inventory[index].stack * 100;
        if ((int) this.inventory[index].type == 73)
          num1 += (int) this.inventory[index].stack * 10000;
        if ((int) this.inventory[index].type == 74)
          num1 += (int) this.inventory[index].stack * 1000000;
      }
      if (num1 < price)
        return false;
      int num2 = price;
      while (num2 > 0)
      {
        if (num2 >= 1000000)
        {
          for (int index = 0; index < 44; ++index)
          {
            if ((int) this.inventory[index].type == 74)
            {
              while ((int) this.inventory[index].stack > 0 && num2 >= 1000000)
              {
                num2 -= 1000000;
                --this.inventory[index].stack;
                if ((int) this.inventory[index].stack == 0)
                  this.inventory[index].Init();
              }
            }
          }
        }
        if (num2 >= 10000)
        {
          for (int index = 0; index < 44; ++index)
          {
            if ((int) this.inventory[index].type == 73)
            {
              while ((int) this.inventory[index].stack > 0 && num2 >= 10000)
              {
                num2 -= 10000;
                --this.inventory[index].stack;
                if ((int) this.inventory[index].stack == 0)
                  this.inventory[index].Init();
              }
            }
          }
        }
        if (num2 >= 100)
        {
          for (int index = 0; index < 44; ++index)
          {
            if ((int) this.inventory[index].type == 72)
            {
              while ((int) this.inventory[index].stack > 0 && num2 >= 100)
              {
                num2 -= 100;
                --this.inventory[index].stack;
                if ((int) this.inventory[index].stack == 0)
                  this.inventory[index].Init();
              }
            }
          }
        }
        if (num2 >= 1)
        {
          for (int index = 0; index < 44; ++index)
          {
            if ((int) this.inventory[index].type == 71)
            {
              while ((int) this.inventory[index].stack > 0 && num2 >= 1)
              {
                --num2;
                --this.inventory[index].stack;
                if ((int) this.inventory[index].stack == 0)
                  this.inventory[index].Init();
              }
            }
          }
        }
        if (num2 > 0)
        {
          int index1 = -1;
          for (int index2 = 43; index2 >= 0; --index2)
          {
            if ((int) this.inventory[index2].type == 0 || (int) this.inventory[index2].stack == 0)
            {
              index1 = index2;
              break;
            }
          }
          if (index1 >= 0)
          {
            bool flag = true;
            if (num2 >= 10000)
            {
              for (int index2 = 0; index2 < 48; ++index2)
              {
                if ((int) this.inventory[index2].type == 74 && (int) this.inventory[index2].stack >= 1)
                {
                  --this.inventory[index2].stack;
                  if ((int) this.inventory[index2].stack == 0)
                    this.inventory[index2].Init();
                  this.inventory[index1].SetDefaults(73, 100, false);
                  flag = false;
                  break;
                }
              }
            }
            else if (num2 >= 100)
            {
              for (int index2 = 0; index2 < 44; ++index2)
              {
                if ((int) this.inventory[index2].type == 73 && (int) this.inventory[index2].stack >= 1)
                {
                  --this.inventory[index2].stack;
                  if ((int) this.inventory[index2].stack == 0)
                    this.inventory[index2].Init();
                  this.inventory[index1].SetDefaults(72, 100, false);
                  flag = false;
                  break;
                }
              }
            }
            else if (num2 >= 1)
            {
              for (int index2 = 0; index2 < 44; ++index2)
              {
                if ((int) this.inventory[index2].type == 72 && (int) this.inventory[index2].stack >= 1)
                {
                  --this.inventory[index2].stack;
                  if ((int) this.inventory[index2].stack == 0)
                    this.inventory[index2].Init();
                  this.inventory[index1].SetDefaults(71, 100, false);
                  flag = false;
                  break;
                }
              }
            }
            if (flag)
            {
              if (num2 < 10000)
              {
                for (int index2 = 0; index2 < 44; ++index2)
                {
                  if ((int) this.inventory[index2].type == 73 && (int) this.inventory[index2].stack >= 1)
                  {
                    --this.inventory[index2].stack;
                    if ((int) this.inventory[index2].stack == 0)
                      this.inventory[index2].Init();
                    this.inventory[index1].SetDefaults(72, 100, false);
                    flag = false;
                    break;
                  }
                }
              }
              if (flag && num2 < 1000000)
              {
                for (int index2 = 0; index2 < 44; ++index2)
                {
                  if ((int) this.inventory[index2].type == 74 && (int) this.inventory[index2].stack >= 1)
                  {
                    --this.inventory[index2].stack;
                    if ((int) this.inventory[index2].stack == 0)
                      this.inventory[index2].Init();
                    this.inventory[index1].SetDefaults(73, 100, false);
                    break;
                  }
                }
              }
            }
          }
          else
          {
            for (int index2 = 0; index2 < 44; ++index2)
              this.inventory[index2] = objArray[index2];
            return false;
          }
        }
      }
      return true;
    }

    public void AdjTiles()
    {
      for (int index = 0; index < 135; ++index)
      {
        this.adjTile[index].old = this.adjTile[index].i;
        this.adjTile[index].i = false;
      }
      this.oldAdjWater = this.adjWater;
      this.adjWater = false;
      int num1 = this.aabb.X + 10 >> 4;
      int num2 = this.aabb.Y + 42 >> 4;
      for (int index1 = num1 - 4; index1 <= num1 + 4; ++index1)
      {
        for (int index2 = num2 - 3; index2 < num2 + 3; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0)
          {
            int type = (int) Main.tile[index1, index2].type;
            if (type < 135)
            {
              this.adjTile[type].i = true;
              this.FoundCraftingStation(type);
              if (type == 77)
              {
                this.adjTile[17].i = true;
                this.craftingStationsFound.Set(17, true);
              }
              else if (type == 133)
              {
                this.adjTile[17].i = true;
                this.adjTile[77].i = true;
                this.craftingStationsFound.Set(17, true);
                this.craftingStationsFound.Set(77, true);
              }
              else if (type == 134)
              {
                this.adjTile[16].i = true;
                this.craftingStationsFound.Set(16, true);
              }
            }
          }
          if ((int) Main.tile[index1, index2].liquid > 200 && (int) Main.tile[index1, index2].lava == 0)
            this.adjWater = true;
        }
      }
    }

    public unsafe void PlayerFrame()
    {
      if ((int) this.swimTime > 0)
      {
        if (!this.wet)
          this.swimTime = (byte) 0;
        else
          --this.swimTime;
      }
      this.head = this.armor[0].headSlot;
      this.body = this.armor[1].bodySlot;
      this.legs = this.armor[2].legSlot;
      if (this.merman)
      {
        this.head = (short) 39;
        this.legs = (short) 21;
        this.body = (short) 22;
      }
      else if (this.wereWolf)
      {
        this.legs = (short) 20;
        this.body = (short) 21;
        this.head = (short) 38;
      }
      else
      {
        int num = 0;
        if ((int) this.armor[8].headSlot >= 0)
        {
          this.head = this.armor[8].headSlot;
          ++num;
        }
        if ((int) this.armor[9].bodySlot >= 0)
        {
          this.body = this.armor[9].bodySlot;
          ++num;
        }
        if ((int) this.armor[10].legSlot >= 0)
        {
          this.legs = this.armor[10].legSlot;
          ++num;
        }
        if (num == 3 && this.ui != null)
          this.ui.SetTriggerState(Trigger.AllVanitySlotsEquipped);
      }
      if ((int) this.head == 5 && (int) this.body == 5 && (int) this.legs == 5)
      {
        if (Main.rand.Next(16) == 0)
          Main.dust.NewDust(14, ref this.aabb, 0.0, 0.0, 200, new Color(), 1.20000004768372);
        this.socialShadow = true;
      }
      else
      {
        this.socialShadow = false;
        if ((int) this.head == 6 && (int) this.body == 6 && (int) this.legs == 6)
        {
          if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 1.0 && !this.rocketFrame)
          {
            for (int index = 0; index < 2; ++index)
            {
              Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X * 2.0), (int) ((double) this.position.Y - (double) this.velocity.Y * 2.0) - 2, 20, 42, 6, 0.0, 0.0, 100, new Color(), 2.0);
              if ((IntPtr) dustPtr != IntPtr.Zero)
              {
                dustPtr->noGravity = true;
                dustPtr->noLight = true;
                dustPtr->velocity.X -= this.velocity.X * 0.5f;
                dustPtr->velocity.Y -= this.velocity.Y * 0.5f;
              }
              else
                break;
            }
          }
        }
        else if ((int) this.head == 7 && (int) this.body == 7 && (int) this.legs == 7)
          this.boneArmor = true;
        else if ((int) this.head == 8 && (int) this.body == 8 && (int) this.legs == 8)
        {
          if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 1.0)
          {
            Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X * 2.0), (int) ((double) this.position.Y - (double) this.velocity.Y * 2.0) - 2, 20, 42, 40, 0.0, 0.0, 50, new Color(), 1.39999997615814);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->noGravity = true;
              dustPtr->velocity *= 0.25f;
            }
          }
        }
        else if ((int) this.head == 9 && (int) this.body == 9 && (int) this.legs == 9)
        {
          if ((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Y) > 1.0 && !this.rocketFrame)
          {
            for (int index = 0; index < 2; ++index)
            {
              Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X * 2.0), (int) ((double) this.position.Y - (double) this.velocity.Y * 2.0) - 2, 20, 42, 6, 0.0, 0.0, 100, new Color(), 2.0);
              if ((IntPtr) dustPtr != IntPtr.Zero)
              {
                dustPtr->noGravity = true;
                dustPtr->noLight = true;
                dustPtr->velocity.X -= this.velocity.X * 0.5f;
                dustPtr->velocity.Y -= this.velocity.Y * 0.5f;
              }
              else
                break;
            }
          }
        }
        else if ((int) this.body == 18 && (int) this.legs == 17)
        {
          if (((int) this.head == 32 || (int) this.head == 33 || (int) this.head == 34) && Main.rand.Next(16) == 0)
          {
            Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X * 2.0), (int) ((double) this.position.Y - (double) this.velocity.Y * 2.0) - 2, 20, 42, 43, 0.0, 0.0, 100, new Color(), 0.300000011920929);
            if ((IntPtr) dustPtr != IntPtr.Zero)
            {
              dustPtr->fadeIn = 0.8f;
              dustPtr->velocity.X = 0.0f;
              dustPtr->velocity.Y = 0.0f;
            }
          }
        }
        else if ((int) this.body == 24 && (int) this.legs == 23 && ((int) this.head == 42 || (int) this.head == 43 || (int) this.head == 41) && (((double) this.velocity.X != 0.0 || (double) this.velocity.Y != 0.0) && Main.rand.Next(16) == 0))
        {
          Dust* dustPtr = Main.dust.NewDust((int) ((double) this.position.X - (double) this.velocity.X * 2.0), (int) ((double) this.position.Y - (double) this.velocity.Y * 2.0) - 2, 20, 42, 43, 0.0, 0.0, 100, new Color(), 0.300000011920929);
          if ((IntPtr) dustPtr != IntPtr.Zero)
          {
            dustPtr->fadeIn = 0.8f;
            dustPtr->velocity.X = 0.0f;
            dustPtr->velocity.Y = 0.0f;
          }
        }
      }
      if ((int) this.itemAnimation > 0 && (int) this.inventory[(int) this.selectedItem].useStyle != 10)
      {
        if ((int) this.inventory[(int) this.selectedItem].useStyle == 1 || (int) this.inventory[(int) this.selectedItem].type == 0)
          this.bodyFrameY = (int) this.itemAnimation >= (int) this.itemAnimationMax / 3 ? ((int) this.itemAnimation >= ((int) this.itemAnimationMax << 1) / 3 ? (short) 56 : (short) 112) : (short) 168;
        else if ((int) this.inventory[(int) this.selectedItem].useStyle == 2)
          this.bodyFrameY = (int) this.itemAnimation <= (int) this.itemAnimationMax >> 1 ? (short) 112 : (short) 168;
        else if ((int) this.inventory[(int) this.selectedItem].useStyle == 3)
          this.bodyFrameY = (int) this.itemAnimation <= ((int) this.itemAnimationMax << 1) / 3 ? (short) 168 : (short) 168;
        else if ((int) this.inventory[(int) this.selectedItem].useStyle == 4)
          this.bodyFrameY = (short) 112;
        else if ((int) this.inventory[(int) this.selectedItem].useStyle == 5)
        {
          if ((int) this.inventory[(int) this.selectedItem].type == 281)
          {
            this.bodyFrameY = (short) 112;
          }
          else
          {
            float num = this.itemRotation * (float) this.direction;
            this.bodyFrameY = (short) 168;
            if ((double) num < -0.75)
            {
              this.bodyFrameY = (short) 112;
              if ((int) this.gravDir == -1)
                this.bodyFrameY = (short) 224;
            }
            if ((double) num > 0.6)
            {
              this.bodyFrameY = (short) 224;
              if ((int) this.gravDir == -1)
                this.bodyFrameY = (short) 112;
            }
          }
        }
      }
      else if ((int) this.inventory[(int) this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[(int) this.selectedItem].noWet))
        this.bodyFrameY = (short) 168;
      else if ((int) this.inventory[(int) this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[(int) this.selectedItem].noWet))
        this.bodyFrameY = (short) 112;
      else if ((int) this.inventory[(int) this.selectedItem].holdStyle == 3)
        this.bodyFrameY = (short) 168;
      else if ((int) this.grappling[0] >= 0)
      {
        Vector2 vector2 = new Vector2(this.position.X + 10f, this.position.Y + 21f);
        float num1 = 0.0f;
        float num2 = 0.0f;
        for (int index = 0; index < (int) this.grapCount; ++index)
        {
          num1 += Main.projectile[(int) this.grappling[index]].position.X + (float) ((int) Main.projectile[(int) this.grappling[index]].width >> 1);
          num2 += Main.projectile[(int) this.grappling[index]].position.Y + (float) ((int) Main.projectile[(int) this.grappling[index]].height >> 1);
        }
        float num3 = num1 / (float) this.grapCount;
        float num4 = num2 / (float) this.grapCount;
        float num5 = num3 - vector2.X;
        float num6 = num4 - vector2.Y;
        if ((double) num6 < 0.0 && (double) Math.Abs(num6) > (double) Math.Abs(num5))
        {
          this.bodyFrameY = (short) 112;
          if ((int) this.gravDir == -1)
            this.bodyFrameY = (short) 224;
        }
        else if ((double) num6 > 0.0 && (double) Math.Abs(num6) > (double) Math.Abs(num5))
        {
          this.bodyFrameY = (short) 224;
          if ((int) this.gravDir == -1)
            this.bodyFrameY = (short) 112;
        }
        else
          this.bodyFrameY = (short) 168;
      }
      else if ((int) this.swimTime > 0)
        this.bodyFrameY = (int) this.swimTime <= 20 ? ((int) this.swimTime <= 10 ? (short) 0 : (short) 280) : (short) 0;
      else if ((double) this.velocity.Y != 0.0)
      {
        this.bodyFrameY = (int) this.wings <= 0 ? (short) 280 : ((double) this.velocity.Y <= 0.0 ? (short) 336 : (!this.controlJump ? (short) 280 : (short) 336));
        this.bodyFrameCounter = 0.0f;
      }
      else if ((double) this.velocity.X != 0.0)
      {
        this.bodyFrameCounter += Math.Abs(this.velocity.X) * 1.5f;
        this.bodyFrameY = this.legFrameY;
      }
      else
      {
        this.bodyFrameCounter = 0.0f;
        this.bodyFrameY = (short) 0;
      }
      if ((int) this.swimTime > 0)
      {
        this.legFrameCounter += 2f;
        while ((double) this.legFrameCounter > 8.0)
        {
          this.legFrameCounter -= 8f;
          this.legFrameY += (short) 56;
        }
        if ((int) this.legFrameY < 392)
          this.legFrameY = (short) 1064;
        else if ((int) this.legFrameY > 1064)
          this.legFrameY = (short) 392;
        this.ResetAirTime();
      }
      else if ((double) this.velocity.Y != 0.0 || (int) this.grappling[0] >= 0)
      {
        this.IncreaseAirTime();
        this.legFrameCounter = 0.0f;
        this.legFrameY = (short) 280;
      }
      else if ((double) this.velocity.X != 0.0)
      {
        this.legFrameCounter += Math.Abs(this.velocity.X) * 1.3f;
        int num = (int) this.legFrameCounter >> 3;
        if (num > 0)
        {
          this.legFrameCounter -= (float) (num << 3);
          this.legFrameY = (short) ((int) this.legFrameY + 56 * num);
          if ((int) this.legFrameY == 560 || (int) this.legFrameY == 784 || (int) this.legFrameY == 1008)
            this.IncreaseSteps();
        }
        if ((int) this.legFrameY < 392)
          this.legFrameY = (short) 1064;
        else if ((int) this.legFrameY > 1064)
          this.legFrameY = (short) 392;
        this.ResetAirTime();
      }
      else
      {
        this.legFrameCounter = 0.0f;
        this.legFrameY = (short) 0;
        this.ResetAirTime();
      }
    }

    public void Init()
    {
      this.velocity = new Vector2();
      this.headPosition = new Vector2();
      this.bodyPosition = new Vector2();
      this.legPosition = new Vector2();
      this.headRotation = 0.0f;
      this.bodyRotation = 0.0f;
      this.legRotation = 0.0f;
      this.immune = true;
      this.immuneTime = (short) 0;
      this.dead = false;
      this.wet = false;
      this.wetCount = (byte) 0;
      this.lavaWet = false;
      this.talkNPC = (short) -1;
    }

    public void Spawn()
    {
      this.Init();
      if (this.isLocal())
      {
        this.view.quickBG = 10;
        this.FindSpawn();
        if (!Player.CheckSpawn(this.SpawnX, this.SpawnY))
        {
          this.SpawnX = -1;
          this.SpawnY = -1;
        }
        NetMessage.CreateMessage1(12, (int) this.whoAmI);
        NetMessage.SendMessage();
      }
      if (this.SpawnX >= 0 && this.SpawnY >= 0)
      {
        this.position.X = (float) (this.SpawnX * 16 + 8 - 10);
        this.position.Y = (float) (this.SpawnY * 16 - 42);
      }
      else
      {
        this.position.X = (float) ((int) Main.spawnTileX * 16 + 8 - 10);
        this.position.Y = (float) ((int) Main.spawnTileY * 16 - 42);
        for (int i = (int) Main.spawnTileX - 1; i < (int) Main.spawnTileX + 2; ++i)
        {
          for (int j = (int) Main.spawnTileY - 3; j < (int) Main.spawnTileY; ++j)
          {
            if (Main.tileSolidNotSolidTop[(int) Main.tile[i, j].type])
              WorldGen.KillTile(i, j);
            if ((int) Main.tile[i, j].liquid > 0)
            {
              Main.tile[i, j].lava = (byte) 0;
              Main.tile[i, j].liquid = (byte) 0;
              WorldGen.SquareTileFrame(i, j, -1);
            }
          }
        }
      }
      this.shadowPos[0] = this.position;
      this.shadowPos[1] = this.position;
      this.shadowPos[2] = this.position;
      this.aabb.X = (int) this.position.X;
      this.aabb.Y = (int) this.position.Y;
      this.fallStart = (short) (this.aabb.Y >> 4);
      if ((int) this.statLife <= 0)
      {
        this.breath = (short) 200;
        if (this.spawnMax)
        {
          this.statLife = this.statLifeMax;
          this.statMana = this.statManaMax2;
        }
        else
          this.statLife = (short) 100;
        this.healthBarLife = this.statLife;
      }
      if (this.pvpDeath)
      {
        this.pvpDeath = false;
        this.immuneTime = (short) 300;
        this.healthBarLife = this.statLife = this.statLifeMax;
      }
      else
        this.immuneTime = (short) 60;
      if (this.isLocal())
      {
        this.hellAndBackState = (byte) 0;
        this.ui.worldFade = -0.25f;
        this.ui.worldFadeTarget = 1f;
        this.view.lighting.scrX = (short) -1;
        this.updateScreenPosition();
        this.UpdateMouse();
        this.UpdatePlayer((int) this.whoAmI);
      }
      this.active = (byte) 1;
    }

    public unsafe double Hurt(int Damage, int hitDirection, bool pvp, bool quiet, uint deathText, bool Crit = false)
    {
      if (this.immune)
        return 0.0;
      int Damage1 = Damage;
      if (pvp)
        Damage1 <<= 1;
      double dmg = Main.CalculateDamage(Damage1, (int) this.statDefense);
      if (Crit)
        Damage1 <<= 1;
      if (dmg >= 1.0)
      {
        if (this.isLocal() && !quiet)
        {
          NetMessage.CreateMessage1(13, (int) this.whoAmI);
          NetMessage.SendMessage();
          NetMessage.CreateMessage1(16, (int) this.whoAmI);
          NetMessage.SendMessage();
          NetMessage.SendPlayerHurt((int) this.whoAmI, hitDirection, Damage, pvp, false, deathText);
        }
        CombatText.NewText(this.position, 20, 42, (int) dmg, Crit);
        this.statLife -= (short) dmg;
        this.immune = true;
        this.immuneTime = (short) 40;
        if (this.longInvince)
          this.immuneTime += (short) 40;
        this.lifeRegenTime = 0;
        if (pvp)
          this.immuneTime = (short) 8;
        if (this.isLocal() && this.starCloak)
        {
          for (int index1 = 0; index1 < 3; ++index1)
          {
            float X = this.position.X + (float) Main.rand.Next(-400, 400);
            float Y = this.position.Y - (float) Main.rand.Next(500, 800);
            float num1 = this.position.X + 10f - X;
            float num2 = this.position.Y + 21f - Y;
            float num3 = num1 + (float) Main.rand.Next(-100, 101);
            float num4 = 23f / (float) Math.Sqrt((double) num3 * (double) num3 + (double) num2 * (double) num2);
            float SpeedX = num3 * num4;
            float SpeedY = num2 * num4;
            int index2 = Projectile.NewProjectile(X, Y, SpeedX, SpeedY, 92, 30, 5f, (int) this.whoAmI, true);
            if (index2 >= 0)
              Main.projectile[index2].ai1 = this.aabb.Y;
            else
              break;
          }
        }
        if (!this.noKnockback && hitDirection != 0)
        {
          this.velocity.X = 4.5f * (float) hitDirection;
          this.velocity.Y = -3.5f;
        }
        if (this.wereWolf)
          Main.PlaySound(3, this.aabb.X, this.aabb.Y, 6);
        else if (this.boneArmor)
          Main.PlaySound(3, this.aabb.X, this.aabb.Y, 2);
        else
          Main.PlaySound(this.male ? 1 : 20, this.aabb.X, this.aabb.Y, 1);
        if ((int) this.statLife > 0)
        {
          for (int index = (int) (dmg / (double) this.statLifeMax * 80.0); index > 0; --index)
            Main.dust.NewDust(this.boneArmor ? 26 : 5, ref this.aabb, (double) (2 * hitDirection), -2.0, 0, new Color(), 1.0);
        }
        else if (Main.IsTutorial())
        {
          this.statLife = (short) 1;
        }
        else
        {
          this.statLife = (short) 0;
          if (this.isLocal())
            this.KillMe(dmg, hitDirection, pvp, deathText);
        }
      }
      if (pvp)
        dmg = Main.CalculateDamage(Damage1, (int) this.statDefense);
      return dmg;
    }

    public void KillMeForGood()
    {
      this.ui.ErasePlayer((int) this.ui.selectedPlayer);
      this.ui.playerPathName = (string) null;
    }

    public unsafe void KillMe(double dmg, int hitDirection, bool pvp, uint deathText)
    {
      if (this.dead)
        return;
      if (pvp)
        this.pvpDeath = true;
      if (Main.netMode != 1)
      {
        float num1 = (float) Main.rand.Next(-35, 36) * 0.1f;
        while ((double) num1 < 2.0 && (double) num1 > -2.0)
          num1 += (float) Main.rand.Next(-30, 31) * 0.1f;
        int index = Projectile.NewProjectile(this.position.X + 10f, this.position.Y + (float) ((int) this.head >> 1), (float) Main.rand.Next(10, 30) * 0.1f * (float) hitDirection + num1, (float) Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0.0f, (int) this.whoAmI, true);
        if (index >= 0)
        {
          uint num2 = Projectile.tombstoneTextIndex++ & 7U;
          Projectile.tombstoneText[(IntPtr) num2] = this.name + Lang.deathMsgString(deathText);
          Main.projectile[index].tombstoneTextId = (byte) num2;
        }
      }
      if ((int) this.difficulty != 0 && this.isLocal())
      {
        this.ui.trashItem.Init();
        this.DropItems();
        if ((int) this.difficulty == 2)
          this.KillMeForGood();
      }
      Main.PlaySound(5, this.aabb.X, this.aabb.Y, 1);
      this.headVelocity.Y = (float) Main.rand.Next(-40, -10) * 0.1f;
      this.bodyVelocity.Y = (float) Main.rand.Next(-40, -10) * 0.1f;
      this.legVelocity.Y = (float) Main.rand.Next(-40, -10) * 0.1f;
      this.headVelocity.X = (float) Main.rand.Next(-20, 21) * 0.1f + (float) (2 * hitDirection);
      this.bodyVelocity.X = (float) Main.rand.Next(-20, 21) * 0.1f + (float) (2 * hitDirection);
      this.legVelocity.X = (float) Main.rand.Next(-20, 21) * 0.1f + (float) (2 * hitDirection);
      for (int index = 0; (double) index < 16.0 + dmg / (double) this.statLifeMax * 100.0; ++index)
        Main.dust.NewDust(this.boneArmor ? 26 : 5, ref this.aabb, (double) (hitDirection << 1), -2.0, 0, new Color(), 1.0);
      this.dead = true;
      this.respawnTimer = (short) 420;
      this.immuneAlpha = (short) 0;
      if (Main.netMode != 1)
        NetMessage.SendDeathText(this.name, deathText, 225, 25, 25);
      if (!this.isLocal())
        return;
      NetMessage.CreateMessage5(44, (int) this.whoAmI, hitDirection, (int) dmg, pvp ? 1 : 0, (int) deathText);
      NetMessage.SendMessage();
      if (pvp || (int) this.difficulty != 0)
        return;
      this.DropCoins();
    }

    public unsafe bool ItemSpace(Item* pNewItem)
    {
      int num1 = (int) pNewItem->type;
      switch (num1)
      {
        case 58:
        case 184:
          return true;
        default:
          int num2 = 40;
          if (num1 == 71 || num1 == 72 || (num1 == 73 || num1 == 74))
            num2 = 44;
          for (int index = 0; index < num2; ++index)
          {
            if ((int) this.inventory[index].type == 0 || (int) this.inventory[index].stack < (int) this.inventory[index].maxStack && (int) pNewItem->netID == (int) this.inventory[index].netID)
              return true;
          }
          if (pNewItem->CanBePlacedInAmmoSlot())
          {
            for (int index = 44; index < 48; ++index)
            {
              if ((int) this.inventory[index].type == 0 && pNewItem->CanBeAutoPlacedInEmptyAmmoSlot() || (int) this.inventory[index].stack < (int) this.inventory[index].maxStack && (int) pNewItem->netID == (int) this.inventory[index].netID)
                return true;
            }
          }
          else if (pNewItem->accessory)
          {
            for (int index = 3; index < 8; ++index)
            {
              if ((int) this.armor[index].netID == (int) pNewItem->netID)
                return false;
            }
            for (int index = 3; index < 8; ++index)
            {
              if ((int) this.armor[index].type == 0)
                return true;
            }
            return false;
          }
          else if ((int) pNewItem->headSlot >= 0)
          {
            if ((int) this.armor[0].type != 0)
              return (int) this.armor[8].type == 0;
            else
              return true;
          }
          else if ((int) pNewItem->bodySlot >= 0)
          {
            if ((int) this.armor[1].type != 0)
              return (int) this.armor[9].type == 0;
            else
              return true;
          }
          else if ((int) pNewItem->legSlot >= 0)
          {
            if ((int) this.armor[2].type != 0)
              return (int) this.armor[10].type == 0;
            else
              return true;
          }
          return false;
      }
    }

    public void DoCoins(int i)
    {
      if ((int) this.inventory[i].stack != 100 || (int) this.inventory[i].type != 71 && (int) this.inventory[i].type != 72 && (int) this.inventory[i].type != 73)
        return;
      this.inventory[i].SetDefaults((int) this.inventory[i].type + 1, 1, false);
      for (int i1 = 0; i1 < 44; ++i1)
      {
        if ((int) this.inventory[i1].netID == (int) this.inventory[i].netID && i1 != i && (int) this.inventory[i1].stack < (int) this.inventory[i1].maxStack)
        {
          ++this.inventory[i1].stack;
          this.inventory[i].Init();
          this.DoCoins(i1);
        }
      }
    }

    public bool AutoEquip(ref Item item)
    {
      int index = -1;
      bool flag = item.vanity;
      lock (this)
      {
        do
        {
          if (item.accessory)
          {
            for (int local_2 = 3; local_2 < 8; ++local_2)
            {
              if ((int) this.armor[local_2].netID == (int) item.netID)
                return false;
            }
            for (int local_3 = 3; local_3 < 8; ++local_3)
            {
              if ((int) this.armor[local_3].type == 0)
              {
                index = local_3;
                break;
              }
            }
          }
          else if ((int) item.headSlot >= 0)
            index = flag ? 8 : 0;
          else if ((int) item.bodySlot >= 0)
            index = flag ? 9 : 1;
          else if ((int) item.legSlot >= 0)
            index = flag ? 10 : 2;
          if (index >= 0 && (int) this.armor[index].type == 0)
          {
            this.armor[index] = item;
            this.itemsFound.Set((int) item.type, true);
            this.ui.FoundPotentialArmor((int) item.type);
            item.Init();
            return true;
          }
          else
            flag = !flag;
        }
        while (flag != item.vanity);
      }
      return false;
    }

    public bool FillAmmo(ref Item item)
    {
      bool flag = false;
      lock (this)
      {
        for (int local_1 = 44; local_1 < 48; ++local_1)
        {
          if ((int) this.inventory[local_1].type > 0 && (int) this.inventory[local_1].stack < (int) this.inventory[local_1].maxStack && (int) item.netID == (int) this.inventory[local_1].netID)
          {
            Main.PlaySound(7, this.aabb.X, this.aabb.Y, 1);
            if ((int) item.stack + (int) this.inventory[local_1].stack <= (int) this.inventory[local_1].maxStack)
            {
              this.inventory[local_1].stack += item.stack;
              this.view.itemTextLocal.NewText(ref item, (int) item.stack);
              item.Init();
              return true;
            }
            else
            {
              short local_2 = (short) ((int) this.inventory[local_1].maxStack - (int) this.inventory[local_1].stack);
              item.stack -= local_2;
              this.view.itemTextLocal.NewText(ref item, (int) local_2);
              this.inventory[local_1].stack = this.inventory[local_1].maxStack;
              flag = true;
            }
          }
        }
        if (item.CanBeAutoPlacedInEmptyAmmoSlot())
        {
          for (int local_3 = 44; local_3 < 48; ++local_3)
          {
            if ((int) this.inventory[local_3].type == 0)
            {
              this.inventory[local_3] = item;
              this.itemsFound.Set((int) item.type, true);
              this.view.itemTextLocal.NewText(ref item, (int) item.stack);
              Main.PlaySound(7, this.aabb.X, this.aabb.Y, 1);
              item.Init();
              return true;
            }
          }
        }
      }
      return flag;
    }

    public bool GetItem(ref Item item)
    {
      if ((int) item.noGrabDelay > 0)
        return false;
      bool flag1 = false;
      bool flag2 = this.isLocal() && (int) this.ui.inventoryMode > 0 && this.ui.inventorySection == UI.InventorySection.CRAFTING && this.ui.gpState.IsButtonUp(Buttons.A);
      int num1 = 40;
      int num2 = 0;
      if (item.CanBePlacedInCoinSlot())
      {
        num2 = -4;
        num1 = 44;
      }
      else if (item.CanBePlacedInAmmoSlot())
      {
        flag1 = this.FillAmmo(ref item);
        if (flag1 && ((int) item.type == 0 || (int) item.stack == 0))
        {
          if (flag2)
            Recipe.FindRecipes(this.ui, this.ui.craftingCategory, this.ui.craftingShowCraftable);
          return true;
        }
      }
      else if (this.AutoEquip(ref item))
        return true;
      lock (this)
      {
        for (int local_4 = num2; local_4 < 40; ++local_4)
        {
          int local_5 = local_4;
          if (local_5 < 0)
            local_5 += 44;
          if ((int) this.inventory[local_5].type > 0 && (int) this.inventory[local_5].stack < (int) this.inventory[local_5].maxStack && (int) item.netID == (int) this.inventory[local_5].netID)
          {
            Main.PlaySound(7, this.aabb.X, this.aabb.Y, 1);
            if ((int) item.stack + (int) this.inventory[local_5].stack <= (int) this.inventory[local_5].maxStack)
            {
              this.inventory[local_5].stack += item.stack;
              this.view.itemTextLocal.NewText(ref item, (int) item.stack);
              this.DoCoins(local_5);
              item.Init();
              if (flag2)
                Recipe.FindRecipes(this.ui, this.ui.craftingCategory, this.ui.craftingShowCraftable);
              return true;
            }
            else
            {
              short local_6 = (short) ((int) this.inventory[local_5].maxStack - (int) this.inventory[local_5].stack);
              item.stack -= local_6;
              this.view.itemTextLocal.NewText(ref item, (int) local_6);
              this.inventory[local_5].stack = this.inventory[local_5].maxStack;
              this.DoCoins(local_5);
              flag1 = true;
            }
          }
        }
        if ((int) item.useStyle > 0)
        {
          for (int local_7 = 0; local_7 < 10; ++local_7)
          {
            if ((int) this.inventory[local_7].type == 0)
            {
              this.inventory[local_7] = item;
              this.itemsFound.Set((int) item.type, true);
              this.view.itemTextLocal.NewText(ref item, (int) item.stack);
              this.DoCoins(local_7);
              Main.PlaySound(7, this.aabb.X, this.aabb.Y, 1);
              item.Init();
              if (flag2)
                Recipe.FindRecipes(this.ui, this.ui.craftingCategory, this.ui.craftingShowCraftable);
              return true;
            }
          }
        }
        for (int local_8 = num1 - 1; local_8 >= 0; --local_8)
        {
          if ((int) this.inventory[local_8].type == 0)
          {
            this.inventory[local_8] = item;
            this.itemsFound.Set((int) item.type, true);
            this.ui.FoundPotentialArmor((int) item.type);
            this.view.itemTextLocal.NewText(ref item, (int) item.stack);
            this.DoCoins(local_8);
            Main.PlaySound(7, this.aabb.X, this.aabb.Y, 1);
            item.Init();
            if (flag2)
              Recipe.FindRecipes(this.ui, this.ui.craftingCategory, this.ui.craftingShowCraftable);
            return true;
          }
        }
      }
      if (flag2 && flag1)
        Recipe.FindRecipes(this.ui, this.ui.craftingCategory, this.ui.craftingShowCraftable);
      return flag1;
    }

    private void PlaceThing()
    {
      int index1 = (int) this.inventory[(int) this.selectedItem].createTile;
      if (index1 >= 0)
      {
        bool flag1 = false;
        if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid > 0 && (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava != 0)
        {
          if (Main.tileSolid[index1])
            flag1 = true;
          else if (Main.tileLavaDeath[index1])
            flag1 = true;
        }
        if (((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].active == 0 && !flag1 || (Main.tileCut[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].type] || index1 == 23) || (index1 == 2 || index1 == 109 || (index1 == 60 || index1 == 70))) && ((int) this.itemTime == 0 && (int) this.itemAnimation > 0 && this.controlUseItem))
        {
          bool flag2 = false;
          if (index1 == 23 || index1 == 2 || index1 == 109)
          {
            if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].active != 0 && (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].type == 0)
              flag2 = true;
          }
          else if (index1 == 60 || index1 == 70)
          {
            if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].active != 0 && (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].type == 59)
              flag2 = true;
          }
          else if (index1 == 4 || index1 == 136)
          {
            int index2 = (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].type;
            int index3 = (int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].type;
            int index4 = (int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].type;
            int num1 = (int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY - 1].type;
            int num2 = (int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY - 1].type;
            int num3 = (int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY - 1].type;
            int num4 = (int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY + 1].type;
            if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].active == 0)
              index2 = -1;
            if ((int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].active == 0)
              index3 = -1;
            if ((int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].active == 0)
              index4 = -1;
            if ((int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY - 1].active == 0)
              num1 = -1;
            if ((int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY - 1].active == 0)
              num2 = -1;
            if ((int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY + 1].active == 0)
              num3 = -1;
            if ((int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY + 1].active == 0)
              num4 = -1;
            if (index2 >= 0 && Main.tileSolidAndAttach[index2])
              flag2 = true;
            else if (index3 >= 0 && (Main.tileSolidAndAttach[index3] || index3 == 124 || index3 == 5 && num1 == 5 && num3 == 5))
              flag2 = true;
            else if (index4 >= 0 && (Main.tileSolidAndAttach[index4] || index4 == 124 || index4 == 5 && num2 == 5 && num4 == 5))
              flag2 = true;
          }
          else if (index1 == 78 || index1 == 98 || index1 == 100)
          {
            if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].active != 0 && (Main.tileSolid[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].type] || Main.tileTable[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].type]))
              flag2 = true;
          }
          else if (index1 == 13 || index1 == 29 || (index1 == 33 || index1 == 49) || (index1 == 50 || index1 == 103))
          {
            if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].active != 0 && Main.tileTable[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].type])
              flag2 = true;
          }
          else if (index1 == 51)
          {
            if ((int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].active != 0 || (int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].wall > 0 || ((int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].active != 0 || (int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].wall > 0) || ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].active != 0 || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].wall > 0 || ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].active != 0 || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].wall > 0)))
              flag2 = true;
          }
          else if ((int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].active != 0 && Main.tileSolid[(int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].type] || (int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].wall > 0 || ((int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].active != 0 && Main.tileSolid[(int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].type] || (int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].wall > 0) || ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].active != 0 && (Main.tileSolid[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].type] || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].type == 124) || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].wall > 0) || ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].active != 0 && (Main.tileSolid[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].type] || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].type == 124) || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].wall > 0))
            flag2 = true;
          if (index1 >= 82 && index1 <= 84)
            flag2 = true;
          if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].active != 0 && Main.tileCut[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].type])
          {
            if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].type != 78)
            {
              if (WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY))
              {
                NetMessage.CreateMessage5(17, 4, (int) this.tileTargetX, (int) this.tileTargetY, 0, 0);
                NetMessage.SendMessage();
              }
            }
            else
              flag2 = false;
          }
          if (flag2)
          {
            int num = (int) this.inventory[(int) this.selectedItem].placeStyle;
            if (index1 == 141)
              num = Main.rand.Next(2);
            if (index1 == 128 || index1 == 137)
              num = (int) this.direction >= 0 ? 1 : -1;
            if (WorldGen.PlaceTile((int) this.tileTargetX, (int) this.tileTargetY, index1, false, false, (int) this.whoAmI, num))
            {
              this.itemTime = this.inventory[(int) this.selectedItem].useTime;
              NetMessage.CreateMessage5(17, 1, (int) this.tileTargetX, (int) this.tileTargetY, index1, num);
              NetMessage.SendMessage();
              if (index1 == 15)
              {
                if ((int) this.direction == 1)
                {
                  Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].frameX += (short) 18;
                  Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].frameX += (short) 18;
                }
                NetMessage.SendTileSquare((int) this.tileTargetX - 1, (int) this.tileTargetY - 1, 3);
              }
              else if (index1 == 19)
                ++this.ui.totalWoodPlatformsPlaced;
              else if (index1 == 79 || index1 == 90)
                NetMessage.SendTileSquare((int) this.tileTargetX, (int) this.tileTargetY, 5);
            }
          }
        }
      }
      int num5 = (int) this.inventory[(int) this.selectedItem].createWall;
      if (num5 >= 0 && (int) this.itemTime == 0 && ((int) this.itemAnimation > 0 && this.controlUseItem) && ((int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].active != 0 || (int) Main.tile[(int) this.tileTargetX + 1, (int) this.tileTargetY].wall > 0 || ((int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].active != 0 || (int) Main.tile[(int) this.tileTargetX - 1, (int) this.tileTargetY].wall > 0) || ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].active != 0 || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY + 1].wall > 0 || ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].active != 0 || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY - 1].wall > 0))) && ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].wall != num5 && WorldGen.PlaceWall((int) this.tileTargetX, (int) this.tileTargetY, num5)))
      {
        ++this.ui.totalWallsPlaced;
        this.itemTime = this.inventory[(int) this.selectedItem].useTime;
        NetMessage.CreateMessage5(17, 3, (int) this.tileTargetX, (int) this.tileTargetY, num5, 0);
        NetMessage.SendMessage();
        if ((int) this.inventory[(int) this.selectedItem].stack > 1)
        {
          for (int index2 = 0; index2 < 4; ++index2)
          {
            int index3 = (int) this.tileTargetX;
            int index4 = (int) this.tileTargetY;
            if (index2 == 0)
              --index3;
            else if (index2 == 1)
              ++index3;
            else if (index2 == 2)
              --index4;
            else
              ++index4;
            if ((int) Main.tile[index3, index4].wall == 0)
            {
              int num1 = 0;
              for (int index5 = 0; index5 < 4; ++index5)
              {
                int index6 = index3;
                int index7 = index4;
                if (index5 == 0)
                  --index6;
                else if (index5 == 1)
                  ++index6;
                else if (index5 == 2)
                  --index7;
                else
                  ++index7;
                if ((int) Main.tile[index6, index7].wall == num5)
                  ++num1;
              }
              if (num1 == 4 && WorldGen.PlaceWall(index3, index4, num5))
              {
                --this.inventory[(int) this.selectedItem].stack;
                if ((int) this.inventory[(int) this.selectedItem].stack == 0)
                  this.inventory[(int) this.selectedItem].Init();
                ++this.ui.totalWallsPlaced;
                NetMessage.CreateMessage5(17, 3, index3, index4, num5, 0);
                NetMessage.SendMessage();
              }
            }
          }
        }
      }
      if (!this.isLocal() || this.view.isFullScreen())
        return;
      if (index1 >= 0 || num5 >= 0)
      {
        if (this.ui.smartCursor || this.ui.hotbarItemNameTime > 0)
          return;
        this.view.Zoom(1.5f);
      }
      else
        this.view.Zoom(1.25f);
    }

    public unsafe void ItemCheck(int i)
    {
      fixed (Item* objPtr = &this.inventory[(int) this.selectedItem])
      {
        int num1 = (int) objPtr->damage;
        if (num1 > 0)
        {
          if (objPtr->melee)
            num1 = (int) ((double) num1 * (double) this.meleeDamage);
          else if (objPtr->ranged)
            num1 = (int) ((double) num1 * (double) this.rangedDamage);
          else if (objPtr->magic)
            num1 = (int) ((double) num1 * (double) this.magicDamage);
        }
        if (objPtr->autoReuse && !this.noItems)
        {
          this.releaseUseItem = true;
          if ((int) this.itemAnimation == 1 && (int) objPtr->stack > 0)
            this.itemAnimation = (int) objPtr->shoot <= 0 || this.isLocal() || !this.controlUseItem ? (short) 0 : (short) 2;
        }
        if ((int) this.itemAnimation == 0 && (int) this.reuseDelay > 0)
        {
          this.itemAnimation = (short) this.reuseDelay;
          this.itemTime = this.reuseDelay;
          this.reuseDelay = (byte) 0;
        }
        if (this.controlUseItem && this.releaseUseItem && ((int) objPtr->headSlot > 0 || (int) objPtr->bodySlot > 0 || (int) objPtr->legSlot > 0))
        {
          if ((int) objPtr->useStyle == 0)
            this.releaseUseItem = false;
          int index1 = (int) this.tileTargetX;
          int index2 = (int) this.tileTargetY;
          if ((int) Main.tile[index1, index2].active != 0 && (int) Main.tile[index1, index2].type == 128)
          {
            int num2 = (int) Main.tile[index1, index2].frameY;
            int num3 = 0;
            if ((int) objPtr->bodySlot >= 0)
              num3 = 1;
            else if ((int) objPtr->legSlot >= 0)
              num3 = 2;
            int num4;
            for (num4 = num2 / 18; num3 > num4; num4 = (int) Main.tile[index1, index2].frameY / 18)
              ++index2;
            for (; num3 < num4; num4 = (int) Main.tile[index1, index2].frameY / 18)
              --index2;
            int num5 = (int) Main.tile[index1, index2].frameX % 100;
            if (num5 >= 36)
              num5 -= 36;
            int index3 = index1 - num5 / 18;
            int num6 = (int) Main.tile[index3, index2].frameX;
            WorldGen.KillTile(index3, index2, true, false, false);
            NetMessage.CreateMessage5(17, 0, index3, index2, 1, 0);
            NetMessage.SendMessage();
            int num7 = num6 % 100;
            if (num4 == 0 && (int) objPtr->headSlot >= 0)
            {
              Main.tile[index3, index2].frameX = (short) (num7 + (int) objPtr->headSlot * 100);
              NetMessage.SendTile(index3, index2);
              objPtr->SetDefaults(0, 1, false);
              this.ui.mouseItem.SetDefaults(0, 1, false);
              this.releaseUseItem = false;
            }
            else if (num4 == 1 && (int) objPtr->bodySlot >= 0)
            {
              Main.tile[index3, index2].frameX = (short) (num7 + (int) objPtr->bodySlot * 100);
              NetMessage.SendTile(index3, index2);
              objPtr->SetDefaults(0, 1, false);
              this.ui.mouseItem.SetDefaults(0, 1, false);
              this.releaseUseItem = false;
            }
            else if (num4 == 2 && (int) objPtr->legSlot >= 0)
            {
              Main.tile[index3, index2].frameX = (short) (num7 + (int) objPtr->legSlot * 100);
              NetMessage.SendTile(index3, index2);
              objPtr->SetDefaults(0, 1, false);
              this.ui.mouseItem.SetDefaults(0, 1, false);
              this.releaseUseItem = false;
            }
          }
        }
        if (this.controlUseItem && (int) this.itemAnimation == 0 && (this.releaseUseItem && (int) objPtr->useStyle > 0))
        {
          bool flag = !this.noItems;
          if ((int) objPtr->shoot == 0)
            this.itemRotation = 0.0f;
          if (flag)
          {
            if ((int) objPtr->shoot == 85 || (int) objPtr->shoot == 15 || (int) objPtr->shoot == 34)
              flag = !this.wet;
            else if ((int) objPtr->shoot == 6 || (int) objPtr->shoot == 19 || ((int) objPtr->shoot == 33 || (int) objPtr->shoot == 52))
            {
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI && (int) Main.projectile[index].type == (int) objPtr->shoot)
                {
                  flag = false;
                  break;
                }
              }
            }
            else if ((int) objPtr->shoot == 106)
            {
              int num2 = 0;
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI && ((int) Main.projectile[index].type == (int) objPtr->shoot && num2 >= (int) objPtr->stack))
                {
                  flag = false;
                  break;
                }
              }
            }
            else if ((int) objPtr->shoot == 13 || (int) objPtr->shoot == 32)
            {
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI && ((int) Main.projectile[index].type == (int) objPtr->shoot && (double) Main.projectile[index].ai0 != 2.0))
                {
                  flag = false;
                  break;
                }
              }
            }
            else if ((int) objPtr->shoot == 73)
            {
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI && (int) Main.projectile[index].type == 74)
                {
                  flag = false;
                  break;
                }
              }
            }
          }
          if (flag && objPtr->potion)
          {
            if ((int) this.potionDelay <= 0)
            {
              this.potionDelay = this.potionDelayTime;
              this.AddBuff(21, (int) this.potionDelay, true);
            }
            else
            {
              flag = false;
              this.itemTime = objPtr->useTime;
            }
          }
          if ((int) objPtr->mana > 0 && this.silence)
            flag = false;
          if ((int) objPtr->mana > 0 && flag)
          {
            if ((int) objPtr->type != (int) sbyte.MaxValue || !this.spaceGun)
            {
              if ((int) this.statMana >= (int) ((double) objPtr->mana * (double) this.manaCost))
                this.statMana -= (short) ((double) objPtr->mana * (double) this.manaCost);
              else if (this.manaFlower)
              {
                this.QuickMana();
                if ((int) this.statMana >= (int) ((double) objPtr->mana * (double) this.manaCost))
                  this.statMana -= (short) ((double) objPtr->mana * (double) this.manaCost);
                else
                  flag = false;
              }
              else
                flag = false;
            }
            if (this.isLocal() && (int) objPtr->buffType != 0)
              this.AddBuff((int) objPtr->buffType, (int) objPtr->buffTime, true);
          }
          if (this.isLocal() && (int) objPtr->buffType == 40)
            this.ApplyPetBuff((int) objPtr->type);
          if (Main.gameTime.dayTime)
          {
            if ((int) objPtr->type == 43)
              flag = false;
            else if ((int) objPtr->type == 544)
              flag = false;
            else if ((int) objPtr->type == 556)
              flag = false;
            else if ((int) objPtr->type == 557)
              flag = false;
          }
          if ((int) objPtr->type == 70 && !this.zoneEvil)
            flag = false;
          else if (flag && this.isLocal() && (int) objPtr->shoot == 17)
          {
            int index1 = (int) this.ui.mouseX + this.view.screenPosition.X >> 4;
            int index2 = (int) this.ui.mouseY + this.view.screenPosition.Y >> 4;
            if ((int) Main.tile[index1, index2].active != 0 && ((int) Main.tile[index1, index2].type == 0 || (int) Main.tile[index1, index2].type == 2 || (int) Main.tile[index1, index2].type == 23))
            {
              WorldGen.KillTile(index1, index2, false, false, true);
              if ((int) Main.tile[index1, index2].active == 0)
              {
                NetMessage.CreateMessage5(17, 4, index1, index2, 0, 0);
                NetMessage.SendMessage();
              }
              else
                flag = false;
            }
            else
              flag = false;
          }
          if (flag && (int) objPtr->useAmmo > 0)
          {
            flag = false;
            for (int index = 0; index < 48; ++index)
            {
              if ((int) this.inventory[index].ammo == (int) objPtr->useAmmo && (int) this.inventory[index].stack > 0)
              {
                flag = true;
                break;
              }
            }
          }
          if (flag)
          {
            if ((int) objPtr->pick > 0 || (int) objPtr->axe > 0 || (int) objPtr->hammer > 0)
              this.toolTime = (short) 1;
            if ((int) this.grappling[0] >= 0)
            {
              if (this.controlRight)
                this.direction = (sbyte) 1;
              else if (this.controlLeft)
                this.direction = (sbyte) -1;
            }
            this.channel = objPtr->channel;
            this.attackCD = (short) 0;
            if (objPtr->melee)
            {
              this.itemAnimation = (short) ((double) objPtr->useAnimation * (double) this.meleeSpeed);
              this.itemAnimationMax = (short) ((double) objPtr->useAnimation * (double) this.meleeSpeed);
            }
            else
            {
              this.itemAnimation = (short) objPtr->useAnimation;
              this.itemAnimationMax = (short) objPtr->useAnimation;
              this.reuseDelay = objPtr->reuseDelay;
            }
            if ((int) objPtr->useSound > 0)
              Main.PlaySound(2, this.aabb.X, this.aabb.Y, (int) objPtr->useSound);
          }
          if (flag && ((int) objPtr->shoot == 18 || (int) objPtr->shoot == 72 || ((int) objPtr->shoot == 86 || (int) objPtr->shoot == 87) || (int) objPtr->shoot == 111))
          {
            for (int index = 0; index < 512; ++index)
            {
              if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == i)
              {
                if ((int) Main.projectile[index].type == (int) objPtr->shoot)
                  Main.projectile[index].Kill();
                else if ((int) objPtr->shoot == 72 && ((int) Main.projectile[index].type == 86 || (int) Main.projectile[index].type == 87))
                  Main.projectile[index].Kill();
              }
            }
          }
        }
        if (!this.controlUseItem)
          this.channel = false;
        this.itemHeight = (short) SpriteSheet<_sheetSprites>.src[451 + (int) objPtr->type].Height;
        this.itemWidth = (short) SpriteSheet<_sheetSprites>.src[451 + (int) objPtr->type].Width;
        if ((int) this.itemAnimation > 0)
        {
          this.itemAnimationMax = !objPtr->melee ? (short) objPtr->useAnimation : (short) ((double) objPtr->useAnimation * (double) this.meleeSpeed);
          if ((int) objPtr->mana > 0)
            this.manaRegenDelay = (int) this.maxRegenDelay;
          --this.itemAnimation;
          if ((int) objPtr->useStyle == 1)
          {
            if ((int) this.itemAnimation < (int) this.itemAnimationMax / 3)
            {
              int num2 = 10;
              if ((int) this.itemWidth > 32)
                num2 = (int) this.itemWidth <= 64 ? 14 : 28;
              this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) - num2) * (int) this.direction;
              this.itemLocation.Y = this.aabb.Y + 24;
            }
            else if ((int) this.itemAnimation < ((int) this.itemAnimationMax << 1) / 3)
            {
              int num2 = 10;
              if ((int) this.itemWidth > 32)
                num2 = (int) this.itemWidth <= 64 ? 18 : 28;
              this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) - num2) * (int) this.direction;
              int num3 = 10;
              if ((int) this.itemWidth > 32)
                num3 = (int) this.itemWidth <= 64 ? 8 : 14;
              this.itemLocation.Y = this.aabb.Y + num3;
            }
            else
            {
              int num2 = 6;
              if ((int) this.itemWidth > 32)
                num2 = (int) this.itemWidth <= 64 ? 14 : 28;
              this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) - num2) * (int) this.direction;
              int num3 = 10;
              if ((int) this.itemWidth > 32)
                num3 = (int) this.itemWidth <= 64 ? 10 : 14;
              this.itemLocation.Y = this.aabb.Y + num3;
            }
            this.itemRotation = (float) (((double) this.itemAnimation / (double) this.itemAnimationMax - 0.5) * (double) -this.direction * 3.5 - (double) this.direction * 0.300000011920929);
            if ((int) this.gravDir == -1)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = this.aabb.Y + 42 + (this.aabb.Y - this.itemLocation.Y);
            }
          }
          else if ((int) objPtr->useStyle == 2)
          {
            this.itemRotation = (float) ((double) this.itemAnimation / (double) this.itemAnimationMax * (double) ((int) this.direction << 1) + -1.39999997615814 * (double) this.direction);
            if ((int) this.itemAnimation < (int) this.itemAnimationMax >> 1)
            {
              this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) - 9 - (int) ((double) this.itemRotation * (double) (12 * (int) this.direction))) * (int) this.direction;
              this.itemLocation.Y = this.aabb.Y + 38 + (int) ((double) this.itemRotation * (double) ((int) this.direction << 2));
            }
            else
            {
              this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) - 9 - (int) ((double) this.itemRotation * (double) ((int) this.direction << 4))) * (int) this.direction;
              this.itemLocation.Y = this.aabb.Y + 38 + (int) ((double) this.itemRotation * (double) this.direction);
            }
            if ((int) this.gravDir == -1)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = this.aabb.Y + 42 + (this.aabb.Y - this.itemLocation.Y);
            }
          }
          else if ((int) objPtr->useStyle == 3)
          {
            if ((int) this.itemAnimation > ((int) this.itemAnimationMax << 1) / 3)
            {
              this.itemLocation.X = -1000;
              this.itemLocation.Y = -1000;
              this.itemRotation = -1.3f * (float) this.direction;
            }
            else
            {
              this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) - 4) * (int) this.direction;
              this.itemLocation.Y = this.aabb.Y + 24;
              float num2 = (float) ((double) this.itemAnimation / (double) this.itemAnimationMax * (double) this.itemWidth * (double) this.direction * (double) objPtr->scale * 1.20000004768372) - (float) (10 * (int) this.direction);
              if ((double) num2 > -4.0 && (int) this.direction == -1)
                num2 = -8f;
              if ((double) num2 < 4.0 && (int) this.direction == 1)
                num2 = 8f;
              this.itemLocation.X -= (int) num2;
              this.itemRotation = 0.8f * (float) this.direction;
            }
            if ((int) this.gravDir == -1)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = this.aabb.Y + 42 + (this.aabb.Y - this.itemLocation.Y);
            }
          }
          else if ((int) objPtr->useStyle == 4)
          {
            this.itemRotation = 0.0f;
            this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) - 9 - (int) ((double) this.itemRotation * (double) (14 * (int) this.direction)) - 4) * (int) this.direction;
            this.itemLocation.Y = this.aabb.Y + ((int) this.itemHeight >> 1) + 4;
            if ((int) this.gravDir == -1)
            {
              this.itemRotation = -this.itemRotation;
              this.itemLocation.Y = this.aabb.Y + 42 + (this.aabb.Y - this.itemLocation.Y);
            }
          }
          else if ((int) objPtr->useStyle == 5)
          {
            this.itemLocation.X = this.aabb.X + 10 - ((int) this.itemWidth >> 1) - ((int) this.direction << 1);
            this.itemLocation.Y = this.aabb.Y + 21 - ((int) this.itemHeight >> 1);
          }
        }
        else if ((int) objPtr->holdStyle == 1)
        {
          this.itemLocation.X = this.aabb.X + 10 + (((int) this.itemWidth >> 1) + 2) * (int) this.direction;
          if ((int) objPtr->type == 282 || (int) objPtr->type == 286)
          {
            this.itemLocation.X -= (int) this.direction << 1;
            this.itemLocation.Y += 4;
          }
          this.itemLocation.Y = this.aabb.Y + 24;
          this.itemRotation = 0.0f;
          if ((int) this.gravDir == -1)
          {
            this.itemRotation = -this.itemRotation;
            this.itemLocation.Y = this.aabb.Y + 42 + (this.aabb.Y - this.itemLocation.Y);
          }
        }
        else if ((int) objPtr->holdStyle == 2)
        {
          this.itemLocation.X = this.aabb.X + 10 + 6 * (int) this.direction;
          this.itemLocation.Y = this.aabb.Y + 16;
          this.itemRotation = -0.79f * (float) this.direction;
          if ((int) this.gravDir == -1)
          {
            this.itemRotation = -this.itemRotation;
            this.itemLocation.Y = this.aabb.Y + 42 + (this.aabb.Y - this.itemLocation.Y);
          }
        }
        else if ((int) objPtr->holdStyle == 3)
        {
          this.itemLocation.X = this.aabb.X + 10 - ((int) this.itemWidth >> 1) - ((int) this.direction << 1);
          this.itemLocation.Y = this.aabb.Y + 21 - ((int) this.itemHeight >> 1);
          this.itemRotation = 0.0f;
        }
        if (((int) objPtr->type == 8 || (int) objPtr->type == 523 || (int) objPtr->type >= 427 && (int) objPtr->type <= 433) && !this.wet)
        {
          int num2 = 0;
          if ((int) objPtr->type == 523)
            num2 = 8;
          else if ((int) objPtr->type >= 427)
            num2 = (int) objPtr->type - 426;
          Vector3 rgb = num2 != 1 ? (num2 != 2 ? (num2 != 3 ? (num2 != 4 ? (num2 != 5 ? (num2 != 6 ? (num2 != 7 ? (num2 != 8 ? new Vector3(1f, 0.95f, 0.8f) : new Vector3(0.85f, 1f, 0.7f)) : new Vector3((float) (0.5 * (double) Main.demonTorch + 1.0 * (1.0 - (double) Main.demonTorch)), 0.3f, Main.demonTorch + (float) (0.5 * (1.0 - (double) Main.demonTorch)))) : new Vector3(0.9f, 0.9f, 0.0f)) : new Vector3(1.3f, 1.3f, 1.3f)) : new Vector3(0.9f, 0.0f, 0.9f)) : new Vector3(0.0f, 1f, 0.1f)) : new Vector3(1f, 0.1f, 0.1f)) : new Vector3(0.0f, 0.1f, 1.3f);
          int num3 = num2;
          int Type;
          switch (num3)
          {
            case 0:
              Type = 6;
              break;
            case 8:
              Type = 75;
              break;
            default:
              Type = 58 + num3;
              break;
          }
          int upperBound = 20;
          if ((int) this.itemAnimation > 0)
            upperBound = 7;
          if ((int) this.direction == -1)
          {
            if (Main.rand.Next(upperBound) == 0)
              Main.dust.NewDust(this.itemLocation.X - 16, this.itemLocation.Y - 14 * (int) this.gravDir, 4, 4, Type, 0.0, 0.0, 100, new Color(), 1.0);
            Lighting.addLight((int) ((double) (this.itemLocation.X - 12) + (double) this.velocity.X) >> 4, (int) ((double) (this.itemLocation.Y - 14) + (double) this.velocity.Y) >> 4, rgb);
          }
          else
          {
            if (Main.rand.Next(upperBound) == 0)
              Main.dust.NewDust(this.itemLocation.X + 6, this.itemLocation.Y - 14 * (int) this.gravDir, 4, 4, Type, 0.0, 0.0, 100, new Color(), 1.0);
            Lighting.addLight((int) ((double) (this.itemLocation.X + 12) + (double) this.velocity.X) >> 4, (int) ((double) (this.itemLocation.Y - 14) + (double) this.velocity.Y) >> 4, rgb);
          }
        }
        if ((int) objPtr->type == 105 && !this.wet)
        {
          int upperBound = 20;
          if ((int) this.itemAnimation > 0)
            upperBound = 7;
          if ((int) this.direction == -1)
          {
            if (Main.rand.Next(upperBound) == 0)
              Main.dust.NewDust(this.itemLocation.X - 12, this.itemLocation.Y - 20 * (int) this.gravDir, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
            Lighting.addLight((int) ((double) (this.itemLocation.X - 16) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(1f, 0.95f, 0.8f));
          }
          else
          {
            if (Main.rand.Next(upperBound) == 0)
              Main.dust.NewDust(this.itemLocation.X + 4, this.itemLocation.Y - 20 * (int) this.gravDir, 4, 4, 6, 0.0, 0.0, 100, new Color(), 1.0);
            Lighting.addLight((int) ((double) (this.itemLocation.X + 6) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(1f, 0.95f, 0.8f));
          }
        }
        else if ((int) objPtr->type == 148 && !this.wet)
        {
          int upperBound = 10;
          if ((int) this.itemAnimation > 0)
            upperBound = 7;
          if ((int) this.direction == -1)
          {
            if (Main.rand.Next(upperBound) == 0)
              Main.dust.NewDust(this.itemLocation.X - 12, this.itemLocation.Y - 20 * (int) this.gravDir, 4, 4, 29, 0.0, 0.0, 100, new Color(), 1.0);
            Lighting.addLight((int) ((double) (this.itemLocation.X - 16) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(0.3f, 0.3f, 0.75f));
          }
          else
          {
            if (Main.rand.Next(upperBound) == 0)
              Main.dust.NewDust(this.itemLocation.X + 4, this.itemLocation.Y - 20 * (int) this.gravDir, 4, 4, 29, 0.0, 0.0, 100, new Color(), 1.0);
            Lighting.addLight((int) ((double) (this.itemLocation.X + 6) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(0.3f, 0.3f, 0.75f));
          }
        }
        if ((int) objPtr->type == 282)
        {
          if ((int) this.direction == -1)
            Lighting.addLight((int) ((double) (this.itemLocation.X - 16) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(0.7f, 1f, 0.8f));
          else
            Lighting.addLight((int) ((double) (this.itemLocation.X + 6) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(0.7f, 1f, 0.8f));
        }
        else if ((int) objPtr->type == 286)
        {
          if ((int) this.direction == -1)
            Lighting.addLight((int) ((double) (this.itemLocation.X - 16) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(0.7f, 0.8f, 1f));
          else
            Lighting.addLight((int) ((double) (this.itemLocation.X + 6) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, new Vector3(0.7f, 0.8f, 1f));
        }
        this.releaseUseItem = !this.controlUseItem;
        if ((int) this.itemTime > 0)
          --this.itemTime;
        if (this.isLocal())
        {
          if ((int) objPtr->shoot > 0 && (int) this.itemAnimation > 0 && (int) this.itemTime == 0)
          {
            int Type1 = (int) objPtr->shoot;
            float num2 = objPtr->shootSpeed;
            if (objPtr->melee && Type1 != 25 && (Type1 != 26 && Type1 != 35))
              num2 /= this.meleeSpeed;
            if (Type1 == 13 || Type1 == 32)
            {
              this.grappling[0] = (short) -1;
              this.grapCount = (byte) 0;
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].type == 13 && (int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == i)
                  Main.projectile[index].Kill();
              }
            }
            int Damage = num1;
            float KnockBack = objPtr->knockBack;
            bool flag = false;
            if ((int) objPtr->useAmmo > 0)
            {
              int index1 = -1;
              for (int index2 = 47; index2 >= 44; --index2)
              {
                if ((int) this.inventory[index2].ammo == (int) objPtr->useAmmo && (int) this.inventory[index2].stack > 0)
                {
                  index1 = index2;
                  flag = true;
                  break;
                }
              }
              if (!flag)
              {
                int num3 = int.MaxValue;
                for (int index2 = 39; index2 >= 0; --index2)
                {
                  if ((int) this.inventory[index2].ammo == (int) objPtr->useAmmo && (int) this.inventory[index2].stack > 0 && num3 > (int) this.inventory[index2].type)
                  {
                    num3 = (int) this.inventory[index2].type;
                    index1 = index2;
                    flag = true;
                  }
                }
              }
              if (flag)
              {
                if ((int) this.inventory[index1].shoot > 0)
                  Type1 = (int) this.inventory[index1].shoot;
                if (Type1 == 42)
                {
                  if ((int) this.inventory[index1].type == 370)
                  {
                    Type1 = 65;
                    Damage += 5;
                  }
                  else if ((int) this.inventory[index1].type == 408)
                  {
                    Type1 = 68;
                    Damage += 5;
                  }
                }
                num2 += this.inventory[index1].shootSpeed;
                if (this.inventory[index1].ranged)
                  Damage += (int) ((double) this.inventory[index1].damage * (double) this.rangedDamage);
                else
                  Damage += (int) this.inventory[index1].damage;
                if ((int) objPtr->useAmmo == 1 && this.archery)
                {
                  if ((double) num2 < 20.0)
                  {
                    num2 *= 1.2f;
                    if ((double) num2 > 20.0)
                      num2 = 20f;
                  }
                  Damage += Damage / 5;
                }
                KnockBack += this.inventory[index1].knockBack;
                if (((int) objPtr->type != 98 || Main.rand.Next(3) != 0) && ((int) objPtr->type != 533 || Main.rand.Next(2) != 0) && (((int) objPtr->type != 434 || (int) this.itemAnimation >= (int) objPtr->useAnimation - 2) && Main.rand.Next(100) >= (int) this.freeAmmoChance) && (Type1 != 85 || (int) this.itemAnimation >= (int) this.itemAnimationMax - 6) && (int) --this.inventory[index1].stack <= 0)
                  this.inventory[index1].Init();
              }
            }
            else
              flag = true;
            if (Type1 == 72)
            {
              int num3 = Main.rand.Next(3);
              if (num3 != 0)
                Type1 = num3 + 85;
            }
            else if (Type1 == 73)
            {
              for (int index = 0; index < 512; ++index)
              {
                if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == i)
                {
                  if ((int) Main.projectile[index].type == 73)
                    Type1 = 74;
                  else if ((int) Main.projectile[index].type == 74)
                  {
                    flag = false;
                    break;
                  }
                }
              }
            }
            if (flag)
            {
              if (this.kbGlove && objPtr->mech)
                KnockBack *= 1.7f;
              if ((int) objPtr->type == 120)
              {
                if (Type1 == 1)
                  Type1 = 2;
              }
              else if ((int) objPtr->type == 615)
                Type1 = 113;
              else if ((int) objPtr->type == 617)
                Type1 = 114;
              this.itemTime = objPtr->useTime;
              this.direction = (int) this.ui.mouseX + this.view.screenPosition.X > this.aabb.X + 10 ? (sbyte) 1 : (sbyte) -1;
              Vector2 vector2 = new Vector2(this.position.X + 10f, this.position.Y + 21f);
              if (Type1 == 9)
              {
                vector2.X += (float) (Main.rand.Next(601) * (int) -this.direction);
                vector2.Y += (float) (-300 - Main.rand.Next(100));
                KnockBack = 0.0f;
              }
              else if (Type1 == 51)
                vector2.Y -= (float) (6 * (int) this.gravDir);
              float num3 = (float) ((int) this.ui.mouseX + this.view.screenPosition.X) - vector2.X;
              float num4 = (float) ((int) this.ui.mouseY + this.view.screenPosition.Y) - vector2.Y;
              float num5 = (float) Math.Sqrt((double) num3 * (double) num3 + (double) num4 * (double) num4);
              float num6 = num5;
              float num7 = num2 / num5;
              float SpeedX1 = num3 * num7;
              float SpeedY1 = num4 * num7;
              if (Type1 == 12)
              {
                vector2.X += SpeedX1 * 3f;
                vector2.Y += SpeedY1 * 3f;
              }
              else if (Type1 == 17)
              {
                vector2.X = (float) ((int) this.ui.mouseX + this.view.screenPosition.X);
                vector2.Y = (float) ((int) this.ui.mouseY + this.view.screenPosition.Y);
              }
              if ((int) objPtr->useStyle == 5)
              {
                this.itemRotation = (float) Math.Atan2((double) SpeedY1 * (double) this.direction, (double) SpeedX1 * (double) this.direction);
                NetMessage.CreateMessage1(13, (int) this.whoAmI);
                NetMessage.SendMessage();
                NetMessage.CreateMessage1(41, (int) this.whoAmI);
                NetMessage.SendMessage();
              }
              if (Type1 == 76)
              {
                int Type2 = Type1 + Main.rand.Next(3);
                float num8 = num6 / 270f;
                if ((double) num8 > 1.0)
                  num8 = 1f;
                float num9 = SpeedX1 + (float) Main.rand.Next(-40, 41) * 0.01f;
                float num10 = SpeedY1 + (float) Main.rand.Next(-40, 41) * 0.01f;
                float SpeedX2 = num9 * (num8 + 0.25f);
                float SpeedY2 = num10 * (num8 + 0.25f);
                int number = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX2, SpeedY2, Type2, Damage, KnockBack, i, false);
                if (number >= 0)
                {
                  Main.projectile[number].ai1 = 1;
                  float num11 = (float) ((double) num8 * 2.0 - 1.0);
                  if ((double) num11 < -1.0)
                    num11 = -1f;
                  else if ((double) num11 > 1.0)
                    num11 = 1f;
                  Main.projectile[number].ai0 = num11;
                  NetMessage.SendProjectile(number, SendDataOptions.Reliable);
                }
              }
              else if ((int) objPtr->type == 98 || (int) objPtr->type == 533)
              {
                float SpeedX2 = SpeedX1 + (float) Main.rand.Next(-40, 41) * 0.01f;
                float SpeedY2 = SpeedY1 + (float) Main.rand.Next(-40, 41) * 0.01f;
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX2, SpeedY2, Type1, Damage, KnockBack, i, true);
              }
              else if ((int) objPtr->type == 518)
              {
                float num8 = SpeedX1;
                float num9 = SpeedY1;
                float SpeedX2 = num8 + (float) Main.rand.Next(-40, 41) * 0.04f;
                float SpeedY2 = num9 + (float) Main.rand.Next(-40, 41) * 0.04f;
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX2, SpeedY2, Type1, Damage, KnockBack, i, true);
              }
              else if ((int) objPtr->type == 534)
              {
                for (int index = 0; index < 4; ++index)
                {
                  float num8 = SpeedX1;
                  float num9 = SpeedY1;
                  float SpeedX2 = num8 + (float) Main.rand.Next(-40, 41) * 0.05f;
                  float SpeedY2 = num9 + (float) Main.rand.Next(-40, 41) * 0.05f;
                  Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX2, SpeedY2, Type1, Damage, KnockBack, i, true);
                }
              }
              else if ((int) objPtr->type == 434)
              {
                float SpeedX2 = SpeedX1;
                float SpeedY2 = SpeedY1;
                if ((int) this.itemAnimation < 5)
                {
                  float num8 = SpeedX2 + (float) Main.rand.Next(-40, 41) * 0.01f;
                  float num9 = SpeedY2 + (float) Main.rand.Next(-40, 41) * 0.01f;
                  SpeedX2 = num8 * 1.1f;
                  SpeedY2 = num9 * 1.1f;
                }
                else if ((int) this.itemAnimation < 10)
                {
                  float num8 = SpeedX2 + (float) Main.rand.Next(-20, 21) * 0.01f;
                  float num9 = SpeedY2 + (float) Main.rand.Next(-20, 21) * 0.01f;
                  SpeedX2 = num8 * 1.05f;
                  SpeedY2 = num9 * 1.05f;
                }
                Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX2, SpeedY2, Type1, Damage, KnockBack, i, true);
              }
              else if ((int) objPtr->buffType != 40)
              {
                int index = Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX1, SpeedY1, Type1, Damage, KnockBack, i, true);
                if (index >= 0 && Type1 == 80)
                {
                  Main.projectile[index].ai0 = (float) this.tileTargetX;
                  Main.projectile[index].ai1 = (int) this.tileTargetY;
                }
              }
            }
            else if ((int) objPtr->useStyle == 5)
            {
              this.itemRotation = 0.0f;
              NetMessage.CreateMessage1(41, (int) this.whoAmI);
              NetMessage.SendMessage();
            }
          }
          if (this.isLocal() && ((int) objPtr->type == 509 || (int) objPtr->type == 510) && ((int) this.itemAnimation > 0 && (int) this.itemTime == 0 && this.controlUseItem))
          {
            int i1 = (int) this.tileTargetX;
            int j = (int) this.tileTargetY;
            if ((int) objPtr->type == 509)
            {
              int index1 = -1;
              for (int index2 = 0; index2 < 48; ++index2)
              {
                if ((int) this.inventory[index2].stack > 0 && (int) this.inventory[index2].type == 530)
                {
                  index1 = index2;
                  break;
                }
              }
              if (index1 >= 0 && WorldGen.PlaceWire(i1, j))
              {
                if ((int) ++this.ui.totalWires == 100)
                  this.ui.SetTriggerState(Trigger.PlacedLotsOfWires);
                --this.inventory[index1].stack;
                if ((int) this.inventory[index1].stack <= 0)
                  this.inventory[index1].Init();
                this.itemTime = objPtr->useTime;
                NetMessage.CreateMessage5(17, 5, (int) this.tileTargetX, (int) this.tileTargetY, 0, 0);
                NetMessage.SendMessage();
              }
            }
            else if (WorldGen.KillWire(i1, j))
            {
              if (this.ui.totalWires > 0U)
                --this.ui.totalWires;
              this.itemTime = objPtr->useTime;
              NetMessage.CreateMessage5(17, 6, (int) this.tileTargetX, (int) this.tileTargetY, 0, 0);
              NetMessage.SendMessage();
            }
          }
          if ((int) this.itemAnimation > 0 && (int) this.itemTime == 0 && ((int) objPtr->type == 507 || (int) objPtr->type == 508))
          {
            this.itemTime = objPtr->useTime;
            Vector2 vector2 = new Vector2(this.position.X + 10f, this.position.Y + 21f);
            float num2 = (float) ((int) this.ui.mouseX + this.view.screenPosition.X) - vector2.X;
            float num3 = (float) ((int) this.ui.mouseY + this.view.screenPosition.Y) - vector2.Y;
            float num4 = (float) Math.Sqrt((double) num2 * (double) num2 + (double) num3 * (double) num3) / 270f;
            if ((double) num4 > 1.0)
              num4 = 1f;
            float num5 = (float) ((double) num4 * 2.0 - 1.0);
            if ((double) num5 < -1.0)
              num5 = -1f;
            if ((double) num5 > 1.0)
              num5 = 1f;
            Main.harpNote = num5;
            Main.PlaySound(2, this.aabb.X, this.aabb.Y, (int) objPtr->type == 507 ? 35 : 26);
            NetMessage.CreateMessage1(58, (int) this.whoAmI);
            NetMessage.SendMessage();
          }
          if ((int) objPtr->type >= 205 && (int) objPtr->type <= 207 && ((int) this.itemTime == 0 && (int) this.itemAnimation > 0) && this.controlUseItem)
          {
            if ((int) objPtr->type == 205)
            {
              int num2 = (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava;
              int num3 = 0;
              for (int index1 = (int) this.tileTargetX - 1; index1 <= (int) this.tileTargetX + 1; ++index1)
              {
                for (int index2 = (int) this.tileTargetY - 1; index2 <= (int) this.tileTargetY + 1; ++index2)
                {
                  if ((int) Main.tile[index1, index2].lava == num2)
                    num3 += (int) Main.tile[index1, index2].liquid;
                }
              }
              if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid > 0 && num3 > 100)
              {
                int num4 = (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava;
                if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava == 0)
                  objPtr->SetDefaults(206, 1, false);
                else
                  objPtr->SetDefaults(207, 1, false);
                Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
                this.itemTime = objPtr->useTime;
                int num5 = (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid;
                Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid = (byte) 0;
                Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava = (byte) 0;
                WorldGen.SquareTileFrame((int) this.tileTargetX, (int) this.tileTargetY, 0);
                if (Main.netMode == 1)
                  NetMessage.sendWater((int) this.tileTargetX, (int) this.tileTargetY);
                else
                  Liquid.AddWater((int) this.tileTargetX, (int) this.tileTargetY);
                for (int index1 = (int) this.tileTargetX - 1; index1 <= (int) this.tileTargetX + 1; ++index1)
                {
                  for (int index2 = (int) this.tileTargetY - 1; index2 <= (int) this.tileTargetY + 1; ++index2)
                  {
                    if (num5 < 256 && (int) Main.tile[index1, index2].lava == num2)
                    {
                      int num6 = (int) Main.tile[index1, index2].liquid;
                      if (num6 + num5 > (int) byte.MaxValue)
                        num6 = (int) byte.MaxValue - num5;
                      num5 += num6;
                      Main.tile[index1, index2].liquid -= (byte) num6;
                      Main.tile[index1, index2].lava = (int) Main.tile[index1, index2].liquid == 0 ? (byte) 0 : (byte) num4;
                      WorldGen.SquareTileFrame(index1, index2, 0);
                      if (Main.netMode == 1)
                        NetMessage.sendWater(index1, index2);
                      else
                        Liquid.AddWater(index1, index2);
                    }
                  }
                }
              }
            }
            else if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid < 200 && ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].active == 0 || !Main.tileSolidNotSolidTop[(int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].type]))
            {
              if ((int) objPtr->type == 207)
              {
                if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid == 0 || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava != 0)
                {
                  Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
                  Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava = (byte) 32;
                  Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid = byte.MaxValue;
                  WorldGen.SquareTileFrame((int) this.tileTargetX, (int) this.tileTargetY, -1);
                  objPtr->SetDefaults(205, 1, false);
                  this.itemTime = objPtr->useTime;
                  NetMessage.sendWater((int) this.tileTargetX, (int) this.tileTargetY);
                }
              }
              else if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid == 0 || (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava == 0)
              {
                Main.PlaySound(19, this.aabb.X, this.aabb.Y, 1);
                Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].lava = (byte) 0;
                Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].liquid = byte.MaxValue;
                WorldGen.SquareTileFrame((int) this.tileTargetX, (int) this.tileTargetY, -1);
                objPtr->SetDefaults(205, 1, false);
                this.itemTime = objPtr->useTime;
                NetMessage.sendWater((int) this.tileTargetX, (int) this.tileTargetY);
              }
            }
          }
          if (!this.channel)
            this.toolTime = (short) this.itemTime;
          else if ((int) --this.toolTime < 0)
            this.toolTime = (int) objPtr->pick <= 0 ? (short) ((double) objPtr->useTime * (double) this.pickSpeed) : (short) objPtr->useTime;
          if ((int) objPtr->pick > 0 || (int) objPtr->axe > 0 || (int) objPtr->hammer > 0)
          {
            bool flag = true;
            if ((int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].active != 0)
            {
              int index = (int) Main.tile[(int) this.tileTargetX, (int) this.tileTargetY].type;
              if ((int) objPtr->pick > 0 && !Main.tileAxe[index] && !Main.tileHammer[index] || ((int) objPtr->axe > 0 && Main.tileAxe[index] || (int) objPtr->hammer > 0 && Main.tileHammer[index]))
                flag = false;
              if ((int) this.toolTime == 0 && (int) this.itemAnimation > 0 && this.controlUseItem)
              {
                if ((int) this.hitTileX != (int) this.tileTargetX || (int) this.hitTileY != (int) this.tileTargetY)
                {
                  this.hitTile = (short) 0;
                  this.hitTileX = this.tileTargetX;
                  this.hitTileY = this.tileTargetY;
                }
                if (Main.tileNoFail[index])
                  this.hitTile = (short) 100;
                if (index != 27)
                {
                  if (Main.tileHammer[index])
                  {
                    flag = false;
                    if (index == 48)
                      this.hitTile += (short) ((int) objPtr->hammer >> 1);
                    else if (index == 129)
                      this.hitTile += (short) ((int) objPtr->hammer << 1);
                    else
                      this.hitTile += (short) objPtr->hammer;
                    if ((int) this.tileTargetY > Main.rockLayer && index == 77 && (int) objPtr->hammer < 60)
                      this.hitTile = (short) 0;
                    if ((int) objPtr->hammer > 0)
                    {
                      if (index == 26 && ((int) objPtr->hammer < 80 || !Main.hardMode))
                      {
                        this.hitTile = (short) 0;
                        this.Hurt((int) this.statLife >> 1, (int) -this.direction, false, false, Lang.deathMsg(-1, 0, 0, -1), false);
                      }
                      if ((int) this.hitTile >= 100)
                      {
                        if (Main.netMode == 1 && index == 21)
                        {
                          WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY, true, false, false);
                          NetMessage.CreateMessage5(17, 0, (int) this.tileTargetX, (int) this.tileTargetY, 1, 0);
                          NetMessage.SendMessage();
                          NetMessage.CreateMessage2(34, (int) this.tileTargetX, (int) this.tileTargetY);
                        }
                        else
                        {
                          this.hitTile = (short) 0;
                          WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY);
                          NetMessage.CreateMessage5(17, 0, (int) this.tileTargetX, (int) this.tileTargetY, 0, 0);
                        }
                      }
                      else
                      {
                        WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY, true, false, false);
                        NetMessage.CreateMessage5(17, 0, (int) this.tileTargetX, (int) this.tileTargetY, 1, 0);
                      }
                      NetMessage.SendMessage();
                      this.itemTime = objPtr->useTime;
                    }
                  }
                  else if (Main.tileAxe[index])
                  {
                    if ((int) objPtr->axe > 0)
                    {
                      if (index == 30 || index == 124)
                        this.hitTile += (short) ((int) objPtr->axe * 5);
                      else if (index == 80)
                        this.hitTile += (short) ((int) objPtr->axe * 3);
                      else
                        this.hitTile += (short) objPtr->axe;
                      if ((int) this.hitTile >= 100)
                      {
                        this.hitTile = (short) 0;
                        if (index == 5)
                        {
                          ++this.ui.totalChops;
                          WorldGen.woodSpawned = 0U;
                        }
                        ++this.ui.totalAxed;
                        WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY);
                        NetMessage.CreateMessage5(17, 0, (int) this.tileTargetX, (int) this.tileTargetY, 0, 0);
                        NetMessage.SendMessage();
                        if (index == 5)
                          this.ui.Statistics.incWoodStat(WorldGen.woodSpawned);
                      }
                      else
                      {
                        WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY, true, false, false);
                        NetMessage.CreateMessage5(17, 0, (int) this.tileTargetX, (int) this.tileTargetY, 1, 0);
                        NetMessage.SendMessage();
                      }
                      this.itemTime = objPtr->useTime;
                    }
                  }
                  else if ((int) objPtr->pick > 0)
                  {
                    if (index == 25 || index == 37 || (index == 41 || index == 43) || (index == 44 || index == 58 || (index == 107 || index == 117)))
                    {
                      this.hitTile += (short) ((int) objPtr->pick >> 1);
                      if (index == 41 || index == 43 || index == 44)
                      {
                        if ((double) this.tileTargetX < (double) Main.maxTilesX * 0.25 || (double) this.tileTargetX > (double) Main.maxTilesX * 0.75)
                          this.hitTile = (short) 0;
                      }
                      else if (index == 25 || index == 58 || index == 117)
                      {
                        if ((int) objPtr->pick < 65)
                          this.hitTile = (short) 0;
                      }
                      else if (index == 37 && (int) objPtr->pick < 55)
                        this.hitTile = (short) 0;
                    }
                    else if (index == 108)
                      this.hitTile += (short) ((int) objPtr->pick / 3);
                    else if (index == 111)
                      this.hitTile += (short) ((int) objPtr->pick >> 2);
                    else if (index == 0 || index == 40 || (index == 53 || index == 57) || (index == 59 || index == 123))
                      this.hitTile += (short) ((int) objPtr->pick << 1);
                    else
                      this.hitTile += (short) objPtr->pick;
                    if (index == 22 && (int) this.tileTargetY > Main.worldSurface && (int) objPtr->pick < 55)
                      this.hitTile = (short) 0;
                    else if (index == 56 && (int) objPtr->pick < 65)
                      this.hitTile = (short) 0;
                    else if (index == 107 && (int) objPtr->pick < 100)
                      this.hitTile = (short) 0;
                    else if (index == 108 && (int) objPtr->pick < 110)
                      this.hitTile = (short) 0;
                    else if (index == 111 && (int) objPtr->pick < 120)
                      this.hitTile = (short) 0;
                    if ((int) this.hitTile >= 100 && (index == 2 || index == 23 || (index == 60 || index == 70) || index == 109))
                      this.hitTile = (short) 0;
                    if ((int) this.hitTile >= 100)
                    {
                      switch (index)
                      {
                        case 123:
                        case 147:
                        case 112:
                        case 116:
                        case 0:
                        case 1:
                        case 53:
                        case 57:
                        case 58:
                        case 59:
                          this.ui.Statistics.incStat(StatisticEntry.Soils);
                          break;
                        case 107:
                        case 108:
                        case 111:
                        case 6:
                        case 8:
                        case 9:
                        case 22:
                        case 56:
                          this.ui.Statistics.incStat(StatisticEntry.Ore);
                          break;
                        case 7:
                          ++this.ui.totalCopper;
                          this.ui.Statistics.incStat(StatisticEntry.Ore);
                          break;
                        case 63:
                        case 64:
                        case 65:
                        case 66:
                        case 67:
                        case 68:
                          this.ui.Statistics.incStat(StatisticEntry.Gems);
                          break;
                      }
                      if ((int) ++this.ui.totalPicked == 10000)
                        this.ui.SetTriggerState(Trigger.RemovedLotsOfTiles);
                      this.hitTile = (short) 0;
                      WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY);
                      NetMessage.CreateMessage5(17, 0, (int) this.tileTargetX, (int) this.tileTargetY, 0, 0);
                      NetMessage.SendMessage();
                    }
                    else
                    {
                      WorldGen.KillTile((int) this.tileTargetX, (int) this.tileTargetY, true, false, false);
                      NetMessage.CreateMessage5(17, 0, (int) this.tileTargetX, (int) this.tileTargetY, 1, 0);
                      NetMessage.SendMessage();
                    }
                    this.itemTime = (byte) ((double) objPtr->useTime * (double) this.pickSpeed);
                  }
                }
              }
            }
            int index1 = (int) this.tileTargetX;
            int index2 = (int) this.tileTargetY;
            if (((int) Main.tile[index1, index2].wall == 0 || !WorldGen.CanKillWall(index1, index2)) && (int) Main.tile[index1, index2].active == 0)
            {
              int num2 = -1;
              if (((int) this.ui.mouseX + this.view.screenPosition.X & 15) < 8)
                num2 = 0;
              int num3 = -1;
              if (((int) this.ui.mouseY + this.view.screenPosition.Y & 15) < 8)
                num3 = 0;
              for (int index3 = (int) this.tileTargetX + num2; index3 <= (int) this.tileTargetX + num2 + 1; ++index3)
              {
                for (int index4 = (int) this.tileTargetY + num3; index4 <= (int) this.tileTargetY + num3 + 1; ++index4)
                {
                  index1 = index3;
                  index2 = index4;
                  if ((int) Main.tile[index1, index2].wall > 0 && WorldGen.CanKillWall(index1, index2))
                    goto label_487;
                }
              }
            }
label_487:
            if (flag && (int) Main.tile[index1, index2].wall > 0 && ((int) this.toolTime == 0 && (int) this.itemAnimation > 0) && (this.controlUseItem && (int) objPtr->hammer > 0 && WorldGen.CanKillWall(index1, index2)))
            {
              if ((int) this.hitTileX != index1 || (int) this.hitTileY != index2)
              {
                this.hitTile = (short) 0;
                this.hitTileX = (short) index1;
                this.hitTileY = (short) index2;
              }
              this.hitTile += (short) ((int) objPtr->hammer + ((int) objPtr->hammer >> 1));
              if ((int) this.hitTile >= 100)
              {
                this.hitTile = (short) 0;
                WorldGen.KillWall(index1, index2, false);
                NetMessage.CreateMessage5(17, 2, index1, index2, 0, 0);
              }
              else
              {
                WorldGen.KillWall(index1, index2, true);
                NetMessage.CreateMessage5(17, 2, index1, index2, 1, 0);
              }
              NetMessage.SendMessage();
              this.itemTime = (byte) ((uint) objPtr->useTime >> 1);
            }
          }
          if ((int) objPtr->type == 29)
          {
            if ((int) this.itemTime == 0 && (int) this.itemAnimation > 0 && (int) this.statLifeMax < 400)
            {
              this.itemTime = objPtr->useTime;
              this.statLifeMax += (short) 20;
              this.statLife += (short) 20;
              this.HealEffect(20);
            }
            if ((int) this.statManaMax == 200 && (int) this.statLifeMax == 400)
              this.ui.SetTriggerState(Trigger.MaxHealthAndMana);
          }
          else if ((int) objPtr->type == 109)
          {
            if ((int) this.itemTime == 0 && (int) this.itemAnimation > 0 && (int) this.statManaMax < 200)
            {
              this.itemTime = objPtr->useTime;
              this.statManaMax += (short) 20;
              this.statMana += (short) 20;
              this.ManaEffect(20);
            }
            if ((int) this.statManaMax == 200 && (int) this.statLifeMax == 400)
              this.ui.SetTriggerState(Trigger.MaxHealthAndMana);
          }
          else
            this.PlaceThing();
        }
        if ((int) objPtr->damage >= 0 && (int) objPtr->type > 0 && (!objPtr->noMelee && (int) this.itemAnimation > 0))
        {
          bool flag1 = false;
          Rectangle rectangle = new Rectangle(this.itemLocation.X, this.itemLocation.Y, (int) ((double) this.itemWidth * (double) objPtr->scale), (int) ((double) this.itemHeight * (double) objPtr->scale));
          if ((int) this.direction == -1)
            rectangle.X -= rectangle.Width;
          if ((int) this.gravDir == 1)
            rectangle.Y -= rectangle.Height;
          if ((int) objPtr->useStyle == 1)
          {
            if ((int) this.itemAnimation < (int) this.itemAnimationMax / 3)
            {
              if ((int) this.direction == -1)
                rectangle.X -= (int) ((double) rectangle.Width * 1.4 - (double) rectangle.Width);
              rectangle.Width = (int) ((double) rectangle.Width * 1.4);
              rectangle.Y += (int) ((double) rectangle.Height * 0.5 * (double) this.gravDir);
              rectangle.Height = (int) ((double) rectangle.Height * 1.1);
            }
            else if ((int) this.itemAnimation >= ((int) this.itemAnimationMax << 1) / 3)
            {
              if ((int) this.direction == 1)
                rectangle.X -= (int) ((double) rectangle.Width * 1.2);
              rectangle.Width = rectangle.Width * 2;
              rectangle.Y -= (int) (((double) rectangle.Height * 1.4 - (double) rectangle.Height) * (double) this.gravDir);
              rectangle.Height = (int) ((double) rectangle.Height * 1.4);
            }
          }
          else if ((int) objPtr->useStyle == 3)
          {
            if ((int) this.itemAnimation > ((int) this.itemAnimationMax << 1) / 3)
            {
              flag1 = true;
            }
            else
            {
              if ((int) this.direction == -1)
                rectangle.X -= (int) ((double) rectangle.Width * 1.4 - (double) rectangle.Width);
              rectangle.Width = (int) ((double) rectangle.Width * 1.4);
              rectangle.Y += (int) ((double) rectangle.Height * 0.6);
              rectangle.Height = (int) ((double) rectangle.Height * 0.6);
            }
          }
          if (!flag1)
          {
            if ((int) objPtr->type == 44 || (int) objPtr->type == 45 || ((int) objPtr->type == 46 || (int) objPtr->type == 103) || (int) objPtr->type == 104)
            {
              if (Main.rand.Next(18) == 0)
                Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 14, (double) ((int) this.direction * 2), 0.0, 150, new Color(), 1.29999995231628);
            }
            else if ((int) objPtr->type == 273)
            {
              if (Main.rand.Next(6) == 0)
                Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 14, (double) ((int) this.direction * 2), 0.0, 150, new Color(), 1.39999997615814);
              Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 27, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.20000004768372);
              if ((IntPtr) dustPtr != IntPtr.Zero)
              {
                dustPtr->noGravity = true;
                dustPtr->velocity *= 0.5f;
              }
            }
            else if ((int) objPtr->type == 65)
            {
              if (Main.rand.Next(6) == 0)
                Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 58, 0.0, 0.0, 150, new Color(), 1.20000004768372);
              if (Main.rand.Next(12) == 0)
                Gore.NewGore(new Vector2((float) rectangle.X, (float) rectangle.Y), new Vector2(), Main.rand.Next(16, 18), 1.0);
            }
            else if ((int) objPtr->type == 190 || (int) objPtr->type == 213)
            {
              Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 40, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 0, new Color(), 1.20000004768372);
              if ((IntPtr) dustPtr != IntPtr.Zero)
                dustPtr->noGravity = true;
            }
            else if ((int) objPtr->type == 121)
            {
              Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 6, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.5);
              if ((IntPtr) dustPtr != IntPtr.Zero)
              {
                dustPtr->noGravity = true;
                dustPtr->velocity.X *= 2f;
                dustPtr->velocity.Y *= 2f;
              }
            }
            else if ((int) objPtr->type == 122 || (int) objPtr->type == 217)
            {
              Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 6, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.89999997615814);
              if ((IntPtr) dustPtr != IntPtr.Zero)
                dustPtr->noGravity = true;
            }
            else if ((int) objPtr->type == 155)
            {
              Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 29, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 2.0);
              if ((IntPtr) dustPtr != IntPtr.Zero)
              {
                dustPtr->noGravity = true;
                dustPtr->velocity.X *= 0.5f;
                dustPtr->velocity.Y *= 0.5f;
              }
            }
            else if ((int) objPtr->type == 367 || (int) objPtr->type == 368)
            {
              if (Main.rand.Next(4) == 0)
              {
                Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 57, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, 100, new Color(), 1.10000002384186);
                if ((IntPtr) dustPtr != IntPtr.Zero)
                {
                  dustPtr->noGravity = true;
                  dustPtr->velocity.X *= 0.5f;
                  dustPtr->velocity.X += (float) ((int) this.direction << 1);
                  dustPtr->velocity.Y *= 0.5f;
                }
              }
              if (Main.rand.Next(5) == 0)
              {
                Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 43, 0.0, 0.0, 254, new Color(), 0.300000011920929);
                if ((IntPtr) dustPtr != IntPtr.Zero)
                {
                  dustPtr->velocity.X = 0.0f;
                  dustPtr->velocity.Y = 0.0f;
                }
              }
            }
            else if ((int) objPtr->type >= 198 && (int) objPtr->type <= 203)
              Lighting.addLight((int) ((double) (this.itemLocation.X + 6) + (double) this.velocity.X) >> 4, this.itemLocation.Y - 14 >> 4, (int) objPtr->type != 198 ? ((int) objPtr->type != 199 ? ((int) objPtr->type != 200 ? ((int) objPtr->type != 201 ? ((int) objPtr->type != 202 ? new Vector3(0.45f, 0.45f, 0.05f) : new Vector3(0.4f, 0.45f, 0.5f)) : new Vector3(0.4f, 0.05f, 0.5f)) : new Vector3(0.05f, 0.5f, 0.1f)) : new Vector3(0.5f, 0.1f, 0.05f)) : new Vector3(0.05f, 0.25f, 0.6f));
            else if ((int) objPtr->type == 613)
            {
              Dust* dustPtr = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 6, (double) this.velocity.X * 0.200000002980232 + (double) ((int) this.direction * 3), (double) this.velocity.Y * 0.200000002980232, Main.rand.Next(61, 62), new Color(), 2.5);
              if ((IntPtr) dustPtr != IntPtr.Zero)
              {
                dustPtr->noGravity = true;
                dustPtr->velocity.X *= 2f;
                dustPtr->velocity.Y *= 2f;
              }
            }
            if (this.isLocal())
            {
              int dmg = (int) ((double) objPtr->damage * (double) this.meleeDamage);
              float knockBack = objPtr->knockBack;
              if (this.kbGlove)
                knockBack *= 2f;
              int num2 = rectangle.X >> 4;
              int num3 = (rectangle.X + rectangle.Width >> 4) + 1;
              int num4 = rectangle.Y >> 4;
              int num5 = (rectangle.Y + rectangle.Height >> 4) + 1;
              for (int index1 = num2; index1 < num3; ++index1)
              {
                for (int index2 = num4; index2 < num5; ++index2)
                {
                  if (Main.tileCut[(int) Main.tile[index1, index2].type] && (int) Main.tile[index1, index2 + 1].type != 78)
                  {
                    WorldGen.KillTile(index1, index2);
                    NetMessage.CreateMessage5(17, 0, index1, index2, 0, 0);
                    NetMessage.SendMessage();
                  }
                }
              }
              for (int npcId = 0; npcId < 196; ++npcId)
              {
                NPC npc = Main.npc[npcId];
                if ((int) npc.active != 0 && (int) npc.immune[i] == 0 && ((int) this.attackCD == 0 && !npc.dontTakeDamage) && (!npc.friendly || (int) npc.type == 22 && this.killGuide) && (rectangle.Intersects(npc.aabb) && (npc.noTileCollide || Collision.CanHit(ref this.aabb, ref npc.aabb))))
                {
                  bool flag2 = Main.rand.Next(1, 101) <= (int) this.meleeCrit;
                  int num6 = Main.DamageVar(dmg);
                  npc.ApplyWeaponBuff((int) objPtr->type);
                  npc.StrikeNPC(num6, knockBack, (int) this.direction, flag2, false);
                  NetMessage.SendNpcHurt(npcId, num6, (double) knockBack, (int) this.direction, flag2);
                  if ((int) npc.active == 0)
                  {
                    this.ui.Statistics.incStat(Statistics.GetStatisticEntryFromNetID(npc.netID));
                    if ((int) npc.type == 1)
                      ++this.ui.totalSlimes;
                  }
                  npc.immune[i] = (byte) this.itemAnimation;
                  this.attackCD = (short) ((int) this.itemAnimationMax / 3);
                }
              }
              if (this.hostile)
              {
                for (int playerId = 0; playerId < 8; ++playerId)
                {
                  if (playerId != i && (int) Main.player[playerId].active != 0 && (Main.player[playerId].hostile && !Main.player[playerId].immune) && (!Main.player[playerId].dead && ((int) Main.player[i].team == 0 || (int) Main.player[i].team != (int) Main.player[playerId].team)) && (rectangle.Intersects(Main.player[playerId].aabb) && Collision.CanHit(ref this.aabb, ref Main.player[playerId].aabb)))
                  {
                    bool flag2 = false;
                    if (Main.rand.Next(1, 101) <= 10)
                      flag2 = true;
                    int num6 = Main.DamageVar(dmg);
                    Main.player[playerId].ApplyWeaponBuffPvP((int) objPtr->type);
                    Main.player[playerId].Hurt(num6, (int) this.direction, true, false, Lang.deathMsg(-1, 0, 0, -1), flag2);
                    NetMessage.SendPlayerHurt(playerId, (int) this.direction, num6, true, flag2, Lang.deathMsg((int) this.whoAmI, 0, 0, -1));
                    this.attackCD = (short) ((int) this.itemAnimationMax / 3);
                  }
                }
              }
            }
          }
        }
        if ((int) this.itemTime == 0 && (int) this.itemAnimation > 0)
        {
          if ((int) objPtr->healLife > 0)
          {
            this.statLife += objPtr->healLife;
            this.itemTime = objPtr->useTime;
            if (this.isLocal())
              this.HealEffect((int) objPtr->healLife);
          }
          if ((int) objPtr->healMana > 0)
          {
            this.statMana += objPtr->healMana;
            this.itemTime = objPtr->useTime;
            if (this.isLocal())
              this.ManaEffect((int) objPtr->healMana);
          }
          if ((int) objPtr->buffType > 0)
          {
            if (this.isLocal())
              this.AddBuff((int) objPtr->buffType, (int) objPtr->buffTime, true);
            this.itemTime = objPtr->useTime;
          }
          if (this.isLocal())
          {
            if ((int) objPtr->type == 361)
            {
              this.itemTime = objPtr->useTime;
              Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
              if (Main.netMode != 1)
              {
                if (Main.invasionType == 0)
                {
                  Main.invasionDelay = 0;
                  Main.StartInvasion(1);
                }
              }
              else
              {
                NetMessage.CreateMessage2(61, (int) this.whoAmI, -1);
                NetMessage.SendMessage();
              }
            }
            else if ((int) objPtr->type == 602)
            {
              this.itemTime = objPtr->useTime;
              Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
              if (Main.netMode != 1)
              {
                if (Main.invasionType == 0)
                {
                  Main.invasionDelay = 0;
                  Main.StartInvasion(2);
                }
              }
              else
              {
                NetMessage.CreateMessage2(61, (int) this.whoAmI, -2);
                NetMessage.SendMessage();
              }
            }
            else if ((int) objPtr->type == 43 || (int) objPtr->type == 619 || ((int) objPtr->type == 70 || (int) objPtr->type == 544) || ((int) objPtr->type == 556 || (int) objPtr->type == 557 || (int) objPtr->type == 560))
            {
              bool flag = false;
              for (int index = 0; index < 196; ++index)
              {
                if ((int) Main.npc[index].active != 0 && ((int) objPtr->type == 43 && (int) Main.npc[index].type == 4 || (int) objPtr->type == 619 && (int) Main.npc[index].type == 166 || ((int) objPtr->type == 70 && (int) Main.npc[index].type == 13 || (int) objPtr->type == 560 && (int) Main.npc[index].type == 50) || ((int) objPtr->type == 544 && (int) Main.npc[index].type == 125 || (int) objPtr->type == 544 && (int) Main.npc[index].type == 126 || ((int) objPtr->type == 556 && (int) Main.npc[index].type == 134 || (int) objPtr->type == 557 && (int) Main.npc[index].type == 128))))
                {
                  flag = true;
                  break;
                }
              }
              if (flag)
                this.itemTime = objPtr->useTime;
              else if ((int) objPtr->type == 560)
              {
                this.itemTime = objPtr->useTime;
                Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
                if (Main.netMode != 1)
                {
                  NPC.SpawnOnPlayer(this, 50);
                }
                else
                {
                  NetMessage.CreateMessage2(61, (int) this.whoAmI, 50);
                  NetMessage.SendMessage();
                }
              }
              else if ((int) objPtr->type == 43)
              {
                if (!Main.gameTime.dayTime)
                {
                  this.itemTime = objPtr->useTime;
                  Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
                  if (Main.netMode != 1)
                  {
                    NPC.SpawnOnPlayer(this, 4);
                  }
                  else
                  {
                    NetMessage.CreateMessage2(61, (int) this.whoAmI, 4);
                    NetMessage.SendMessage();
                  }
                }
              }
              else if ((int) objPtr->type == 619)
              {
                if (!Main.gameTime.dayTime && Main.hardMode)
                {
                  this.itemTime = objPtr->useTime;
                  Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
                  if (Main.netMode != 1)
                  {
                    NPC.SpawnOnPlayer(this, 166);
                  }
                  else
                  {
                    NetMessage.CreateMessage2(61, (int) this.whoAmI, 166);
                    NetMessage.SendMessage();
                  }
                }
              }
              else if ((int) objPtr->type == 70)
              {
                if (this.zoneEvil)
                {
                  this.itemTime = objPtr->useTime;
                  Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
                  if (Main.netMode != 1)
                  {
                    NPC.SpawnOnPlayer(this, 13);
                  }
                  else
                  {
                    NetMessage.CreateMessage2(61, (int) this.whoAmI, 13);
                    NetMessage.SendMessage();
                  }
                }
              }
              else if ((int) objPtr->type == 544)
              {
                if (!Main.gameTime.dayTime)
                {
                  this.itemTime = objPtr->useTime;
                  Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
                  if (Main.netMode != 1)
                  {
                    NPC.SpawnOnPlayer(this, 125);
                    NPC.SpawnOnPlayer(this, 126);
                  }
                  else
                  {
                    NetMessage.CreateMessage2(61, (int) this.whoAmI, 125);
                    NetMessage.SendMessage();
                    NetMessage.CreateMessage2(61, (int) this.whoAmI, 126);
                    NetMessage.SendMessage();
                  }
                }
              }
              else if ((int) objPtr->type == 556)
              {
                if (!Main.gameTime.dayTime)
                {
                  this.itemTime = objPtr->useTime;
                  Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
                  if (Main.netMode != 1)
                  {
                    NPC.SpawnOnPlayer(this, 134);
                  }
                  else
                  {
                    NetMessage.CreateMessage2(61, (int) this.whoAmI, 134);
                    NetMessage.SendMessage();
                  }
                }
              }
              else if ((int) objPtr->type == 557 && !Main.gameTime.dayTime)
              {
                this.itemTime = objPtr->useTime;
                Main.PlaySound(15, this.aabb.X, this.aabb.Y, 0);
                if (Main.netMode != 1)
                {
                  NPC.SpawnOnPlayer(this, (int) sbyte.MaxValue);
                }
                else
                {
                  NetMessage.CreateMessage2(61, (int) this.whoAmI, (int) sbyte.MaxValue);
                  NetMessage.SendMessage();
                }
              }
            }
          }
        }
        if ((int) objPtr->type == 50 && (int) this.itemAnimation > 0)
        {
          if ((int) this.itemTime == 0)
            this.itemTime = objPtr->useTime;
          else if ((int) this.itemTime == (int) objPtr->useTime >> 1)
          {
            for (int index = 0; index < 16; ++index)
              Main.dust.NewDust(15, ref this.aabb, (double) this.velocity.X * 0.5, (double) this.velocity.Y * 0.5, 150, new Color(), 1.5);
            this.grappling[0] = (short) -1;
            this.grapCount = (byte) 0;
            for (int index = 0; index < 512; ++index)
            {
              if ((int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == i && (int) Main.projectile[index].aiStyle == 7)
                Main.projectile[index].Kill();
            }
            this.Spawn();
            for (int index = 0; index < 32; ++index)
              Main.dust.NewDust(15, ref this.aabb, 0.0, 0.0, 150, new Color(), 1.5);
          }
          else if (Main.rand.Next(3) == 0)
            Main.dust.NewDust(15, ref this.aabb, 0.0, 0.0, 150, new Color(), 1.10000002384186);
        }
        if (!this.isLocal())
          return;
        if ((int) this.itemTime == (int) objPtr->useTime && objPtr->consumable)
        {
          bool flag = true;
          if (objPtr->ranged && Main.rand.Next(100) < (int) this.freeAmmoChance)
            flag = false;
          if (flag)
          {
            if ((int) objPtr->stack > 0)
            {
              IntPtr num2 = (IntPtr) objPtr;
              int num3 = (int) (short) ((int) ((Item*) num2)->stack - 1);
              ((Item*) num2)->stack = (short) num3;
            }
            if ((int) objPtr->stack <= 0)
              this.itemTime = (byte) this.itemAnimation;
          }
        }
        if ((int) objPtr->stack <= 0 && (int) this.itemAnimation == 0)
          objPtr->Init();
        if ((int) this.selectedItem != 48 || (int) this.itemAnimation == 0)
          return;
        this.ui.mouseItem = *objPtr;
      }
    }

    public Color GetImmuneAlpha(Color newColor)
    {
      if ((int) this.immuneAlpha > 125)
        return new Color();
      double num = (double) ((int) byte.MaxValue - (int) this.immuneAlpha) * (1.0 / (double) byte.MaxValue);
      if ((double) this.shadow > 0.0)
        num *= 1.0 - (double) this.shadow;
      return new Color((int) ((double) newColor.R * num), (int) ((double) newColor.G * num), (int) ((double) newColor.B * num), (int) ((double) newColor.A * num));
    }

    public Color GetImmuneAlpha2(Color newColor)
    {
      double num = (double) ((int) byte.MaxValue - (int) this.immuneAlpha) * (1.0 / (double) byte.MaxValue);
      if ((double) this.shadow > 0.0)
        num *= 1.0 - (double) this.shadow;
      return new Color((int) ((double) newColor.R * num), (int) ((double) newColor.G * num), (int) ((double) newColor.B * num), (int) ((double) newColor.A * num));
    }

    public Color GetDeathAlpha(Color newColor)
    {
      return new Color((int) newColor.R + (int) ((double) this.immuneAlpha * 0.9), (int) newColor.G + (int) ((double) this.immuneAlpha * 0.5), (int) newColor.B + (int) ((double) this.immuneAlpha * 0.5), (int) newColor.A + (int) ((double) this.immuneAlpha * 0.4));
    }

    public bool hasItemInInventory(int type)
    {
      for (int index = 0; index < 49; ++index)
      {
        if ((int) this.inventory[index].type == type)
          return true;
      }
      return false;
    }

    public void DropCoins()
    {
      for (int index = 0; index <= 48; ++index)
      {
        if (this.inventory[index].CanBePlacedInCoinSlot())
        {
          short num1 = (short) ((int) this.inventory[index].stack >> 1);
          short num2 = (short) ((int) this.inventory[index].stack - (int) num1);
          int number2 = Item.NewItem(this.aabb.X, this.aabb.Y, 20, 42, (int) this.inventory[index].type, (int) num2, false, 0);
          this.inventory[index].stack -= num2;
          if ((int) this.inventory[index].stack <= 0)
            this.inventory[index].Init();
          Main.item[number2].velocity.Y = (float) Main.rand.Next(-20, 1) * 0.2f;
          Main.item[number2].velocity.X = (float) Main.rand.Next(-20, 21) * 0.2f;
          Main.item[number2].noGrabDelay = (byte) 100;
          NetMessage.CreateMessage2(21, (int) this.whoAmI, number2);
          NetMessage.SendMessage();
          if (index == 48)
            this.ui.mouseItem = this.inventory[index];
        }
      }
    }

    public void DropItems()
    {
      for (int index = 0; index < 49; ++index)
      {
        if ((int) this.inventory[index].type > 0 && (int) this.inventory[index].netID != -13 && ((int) this.inventory[index].netID != -15 && (int) this.inventory[index].netID != -16))
        {
          int number2 = Item.NewItem(this.aabb.X, this.aabb.Y, 20, 42, (int) this.inventory[index].type, 1, false, 0);
          Main.item[number2].netDefaults((int) this.inventory[index].netID, (int) this.inventory[index].stack);
          Main.item[number2].Prefix((int) this.inventory[index].prefix);
          Main.item[number2].velocity.Y = (float) Main.rand.Next(-20, 1) * 0.2f;
          Main.item[number2].velocity.X = (float) Main.rand.Next(-20, 21) * 0.2f;
          Main.item[number2].noGrabDelay = (byte) 100;
          NetMessage.CreateMessage2(21, (int) this.whoAmI, number2);
          NetMessage.SendMessage();
        }
        this.inventory[index].Init();
        if (index < 11)
        {
          if ((int) this.armor[index].type > 0)
          {
            int number2 = Item.NewItem(this.aabb.X, this.aabb.Y, 20, 42, (int) this.armor[index].type, 1, false, 0);
            Main.item[number2].netDefaults((int) this.armor[index].netID, (int) this.armor[index].stack);
            Main.item[number2].Prefix((int) this.armor[index].prefix);
            Main.item[number2].velocity.Y = (float) Main.rand.Next(-20, 1) * 0.2f;
            Main.item[number2].velocity.X = (float) Main.rand.Next(-20, 21) * 0.2f;
            Main.item[number2].noGrabDelay = (byte) 100;
            NetMessage.CreateMessage2(21, (int) this.whoAmI, number2);
            NetMessage.SendMessage();
          }
          this.armor[index].Init();
        }
      }
      this.inventory[0].SetDefaults("Copper Shortsword");
      this.inventory[0].Prefix(-1);
      this.inventory[1].SetDefaults("Copper Pickaxe");
      this.inventory[1].Prefix(-1);
      this.inventory[2].SetDefaults("Copper Axe");
      this.inventory[2].Prefix(-1);
      this.ui.mouseItem.Init();
    }

    public Player ShallowCopy()
    {
      return (Player) this.MemberwiseClone();
    }

    public Player DeepCopy()
    {
      Player player = (Player) this.MemberwiseClone();
      player.buff = new Buff[10];
      player.armor = new Item[11];
      player.inventory = new Item[49];
      player.bank = new Chest();
      player.safe = new Chest();
      player.shadowPos = new Vector2[3];
      player.grappling = new short[20];
      player.adjTile = new Player.Adj[135];
      player.grappling[0] = (short) -1;
      for (int index = 0; index < 10; ++index)
        player.buff[index] = this.buff[index];
      for (int index = 0; index < 11; ++index)
        player.armor[index] = this.armor[index];
      for (int index = 0; index <= 48; ++index)
        player.inventory[index] = this.inventory[index];
      for (int index = 0; index < 20; ++index)
      {
        player.bank.item[index] = this.bank.item[index];
        player.safe.item[index] = this.safe.item[index];
      }
      player.spX = new short[200];
      player.spY = new short[200];
      player.spN = new string[200];
      player.spI = new int[200];
      for (int index = 0; index < 200; ++index)
      {
        player.spX[index] = this.spX[index];
        player.spY[index] = this.spY[index];
        player.spN[index] = this.spN[index];
        player.spI[index] = this.spI[index];
      }
      return player;
    }

    public static bool CheckSpawn(int x, int y)
    {
      if (x < 10 || x > (int) Main.maxTilesX - 10 || (y < 10 || y > (int) Main.maxTilesX - 10) || ((int) Main.tile[x, y - 1].active == 0 || (int) Main.tile[x, y - 1].type != 79))
        return false;
      for (int index1 = x - 1; index1 <= x + 1; ++index1)
      {
        for (int index2 = y - 3; index2 < y; ++index2)
        {
          if ((int) Main.tile[index1, index2].active != 0 && Main.tileSolidNotSolidTop[(int) Main.tile[index1, index2].type])
            return false;
        }
      }
      return WorldGen.StartRoomCheck(x, y - 1);
    }

    public void FindSpawn()
    {
      for (int index = 0; index < 200; ++index)
      {
        if (this.spN[index] == null)
        {
          this.SpawnX = -1;
          this.SpawnY = -1;
          break;
        }
        else if (this.spN[index] == Main.worldName && this.spI[index] == Main.worldID)
        {
          this.SpawnX = (int) this.spX[index];
          this.SpawnY = (int) this.spY[index];
          break;
        }
      }
    }

    public void ChangeSpawn(int x, int y)
    {
      for (int index1 = 0; index1 < 200 && this.spN[index1] != null; ++index1)
      {
        if (this.spN[index1] == Main.worldName && this.spI[index1] == Main.worldID)
        {
          for (int index2 = index1; index2 > 0; --index2)
          {
            this.spN[index2] = this.spN[index2 - 1];
            this.spI[index2] = this.spI[index2 - 1];
            this.spX[index2] = this.spX[index2 - 1];
            this.spY[index2] = this.spY[index2 - 1];
          }
          this.spX[0] = (short) x;
          this.spY[0] = (short) y;
          this.spN[0] = Main.worldName;
          this.spI[0] = Main.worldID;
          return;
        }
      }
      for (int index = 199; index > 0; --index)
      {
        if (this.spN[index - 1] != null)
        {
          this.spN[index] = this.spN[index - 1];
          this.spI[index] = this.spI[index - 1];
          this.spX[index] = this.spX[index - 1];
          this.spY[index] = this.spY[index - 1];
        }
      }
      this.spX[0] = (short) x;
      this.spY[0] = (short) y;
      this.spN[0] = Main.worldName;
      this.spI[0] = Main.worldID;
    }

    public bool Save(string playerPath)
    {
      bool flag = true;
      if (this.ui.HasPlayerStorage())
      {
        if (playerPath == null || playerPath.Length == 0)
          return false;
        using (MemoryStream memoryStream = new MemoryStream(2048))
        {
          using (BinaryWriter binaryWriter = new BinaryWriter((Stream) memoryStream))
          {
            binaryWriter.Write((short) 6);
            binaryWriter.Write(0U);
            binaryWriter.Write(this.characterName);
            binaryWriter.Write(this.difficulty);
            binaryWriter.Write(this.hair);
            binaryWriter.Write(this.male);
            binaryWriter.Write(this.statLife);
            binaryWriter.Write(this.statLifeMax);
            binaryWriter.Write(this.statMana);
            binaryWriter.Write(this.statManaMax);
            binaryWriter.Write(this.hairColor.R);
            binaryWriter.Write(this.hairColor.G);
            binaryWriter.Write(this.hairColor.B);
            binaryWriter.Write(this.skinColor.R);
            binaryWriter.Write(this.skinColor.G);
            binaryWriter.Write(this.skinColor.B);
            binaryWriter.Write(this.eyeColor.R);
            binaryWriter.Write(this.eyeColor.G);
            binaryWriter.Write(this.eyeColor.B);
            binaryWriter.Write(this.shirtColor.R);
            binaryWriter.Write(this.shirtColor.G);
            binaryWriter.Write(this.shirtColor.B);
            binaryWriter.Write(this.underShirtColor.R);
            binaryWriter.Write(this.underShirtColor.G);
            binaryWriter.Write(this.underShirtColor.B);
            binaryWriter.Write(this.pantsColor.R);
            binaryWriter.Write(this.pantsColor.G);
            binaryWriter.Write(this.pantsColor.B);
            binaryWriter.Write(this.shoeColor.R);
            binaryWriter.Write(this.shoeColor.G);
            binaryWriter.Write(this.shoeColor.B);
            lock (this)
            {
              for (int local_3 = 0; local_3 < 11; ++local_3)
              {
                binaryWriter.Write(this.armor[local_3].netID);
                binaryWriter.Write(this.armor[local_3].prefix);
              }
              for (int local_4 = 0; local_4 < 48; ++local_4)
              {
                binaryWriter.Write(this.inventory[local_4].netID);
                binaryWriter.Write(this.inventory[local_4].stack);
                binaryWriter.Write(this.inventory[local_4].prefix);
              }
              for (int local_5 = 0; local_5 < 20; ++local_5)
              {
                binaryWriter.Write(this.bank.item[local_5].netID);
                binaryWriter.Write(this.bank.item[local_5].stack);
                binaryWriter.Write(this.bank.item[local_5].prefix);
              }
              for (int local_6 = 0; local_6 < 20; ++local_6)
              {
                binaryWriter.Write(this.safe.item[local_6].netID);
                binaryWriter.Write(this.safe.item[local_6].stack);
                binaryWriter.Write(this.safe.item[local_6].prefix);
              }
              for (int local_7 = 0; local_7 < 10; ++local_7)
              {
                binaryWriter.Write(this.buff[local_7].Type);
                binaryWriter.Write(this.buff[local_7].Time);
              }
            }
            binaryWriter.Write(this.pet);
            int count1 = this.itemsFound.Length + 7 >> 3;
            byte[] buffer = new byte[count1];
            this.itemsFound.CopyTo((Array) buffer, 0);
            binaryWriter.Write((ushort) count1);
            binaryWriter.Write(buffer, 0, count1);
            int count2 = 43;
            this.recipesFound.CopyTo((Array) buffer, 0);
            binaryWriter.Write((ushort) count2);
            binaryWriter.Write(buffer, 0, count2);
            this.recipesNew.CopyTo((Array) buffer, 0);
            binaryWriter.Write(buffer, 0, count2);
            int count3 = 17;
            this.craftingStationsFound.CopyTo((Array) buffer, 0);
            binaryWriter.Write((ushort) count3);
            binaryWriter.Write(buffer, 0, count3);
            for (int index = 0; index < 200; ++index)
            {
              if (this.spN[index] == null)
              {
                binaryWriter.Write((short) -1);
                break;
              }
              else
              {
                binaryWriter.Write(this.spX[index]);
                binaryWriter.Write(this.spY[index]);
                binaryWriter.Write(this.spI[index]);
                binaryWriter.Write(this.spN[index]);
              }
            }
            CRC32 crC32 = new CRC32();
            crC32.Update(memoryStream.GetBuffer(), 6, (int) memoryStream.Length - 6);
            binaryWriter.Seek(2, SeekOrigin.Begin);
            binaryWriter.Write(crC32.GetValue());
            Main.ShowSaveIcon();
            try
            {
              if (!this.ui.TestStorageSpace("Characters", playerPath, (int) memoryStream.Length))
              {
                flag = false;
              }
              else
              {
                using (StorageContainer storageContainer = this.ui.OpenPlayerStorage("Characters"))
                {
                  using (Stream stream = storageContainer.OpenFile(playerPath, FileMode.Create))
                  {
                    stream.Write(memoryStream.GetBuffer(), 0, (int) memoryStream.Length);
                    stream.Close();
                  }
                }
              }
            }
            catch (IOException ex)
            {
              this.ui.WriteError();
              flag = false;
            }
            catch (Exception ex)
            {
            }
            binaryWriter.Close();
            Main.HideSaveIcon();
          }
        }
      }
      return flag;
    }

    public void Load(StorageContainer c, string playerPath)
    {
      try
      {
        using (Stream stream = c.OpenFile(playerPath, FileMode.Open))
        {
          using (MemoryStream memoryStream = new MemoryStream((int) stream.Length))
          {
            memoryStream.SetLength(stream.Length);
            stream.Read(memoryStream.GetBuffer(), 0, (int) stream.Length);
            stream.Close();
            using (BinaryReader binaryReader = new BinaryReader((Stream) memoryStream))
            {
              int num1 = (int) binaryReader.ReadInt16();
              if (num1 > 6)
                throw new InvalidOperationException("Invalid version");
              if (num1 >= 6)
              {
                CRC32 crC32 = new CRC32();
                crC32.Update(memoryStream.GetBuffer(), 6, (int) memoryStream.Length - 6);
                if ((int) crC32.GetValue() != (int) binaryReader.ReadUInt32())
                  throw new InvalidOperationException("Invalid CRC32");
              }
              this.characterName = binaryReader.ReadString();
              this.difficulty = binaryReader.ReadByte();
              this.hair = binaryReader.ReadByte();
              this.male = binaryReader.ReadBoolean();
              this.statLife = binaryReader.ReadInt16();
              this.statLifeMax = binaryReader.ReadInt16();
              if ((int) this.statLifeMax > 400)
                this.statLifeMax = (short) 400;
              if ((int) this.statLife > (int) this.statLifeMax)
                this.statLife = this.statLifeMax;
              this.statMana = binaryReader.ReadInt16();
              this.statManaMax = binaryReader.ReadInt16();
              if ((int) this.statManaMax > 200)
                this.statManaMax = (short) 200;
              if ((int) this.statMana > 400)
                this.statMana = (short) 400;
              if (num1 == 4)
              {
                int num2 = (int) binaryReader.ReadUInt32();
              }
              this.hairColor.R = binaryReader.ReadByte();
              this.hairColor.G = binaryReader.ReadByte();
              this.hairColor.B = binaryReader.ReadByte();
              this.skinColor.R = binaryReader.ReadByte();
              this.skinColor.G = binaryReader.ReadByte();
              this.skinColor.B = binaryReader.ReadByte();
              this.eyeColor.R = binaryReader.ReadByte();
              this.eyeColor.G = binaryReader.ReadByte();
              this.eyeColor.B = binaryReader.ReadByte();
              this.shirtColor.R = binaryReader.ReadByte();
              this.shirtColor.G = binaryReader.ReadByte();
              this.shirtColor.B = binaryReader.ReadByte();
              this.underShirtColor.R = binaryReader.ReadByte();
              this.underShirtColor.G = binaryReader.ReadByte();
              this.underShirtColor.B = binaryReader.ReadByte();
              this.pantsColor.R = binaryReader.ReadByte();
              this.pantsColor.G = binaryReader.ReadByte();
              this.pantsColor.B = binaryReader.ReadByte();
              this.shoeColor.R = binaryReader.ReadByte();
              this.shoeColor.G = binaryReader.ReadByte();
              this.shoeColor.B = binaryReader.ReadByte();
              for (int index = 0; index <= 10; ++index)
              {
                int Type = (int) binaryReader.ReadInt16();
                int pre = (int) binaryReader.ReadByte();
                if (Type == 0)
                {
                  this.armor[index].Init();
                }
                else
                {
                  this.armor[index].netDefaults(Type, 1);
                  this.armor[index].Prefix(pre);
                  this.itemsFound.Set((int) this.armor[index].type, true);
                }
              }
              for (int index = 0; index < 48; ++index)
              {
                int Type = (int) binaryReader.ReadInt16();
                int Stack = (int) binaryReader.ReadInt16();
                int pre = (int) binaryReader.ReadByte();
                if (Type == 0)
                {
                  this.inventory[index].Init();
                }
                else
                {
                  this.inventory[index].netDefaults(Type, Stack);
                  this.inventory[index].Prefix(pre);
                  this.itemsFound.Set((int) this.inventory[index].type, true);
                }
              }
              for (int index = 0; index < 20; ++index)
              {
                int Type = (int) binaryReader.ReadInt16();
                int Stack = (int) binaryReader.ReadInt16();
                int pre = (int) binaryReader.ReadByte();
                if (Type == 0)
                {
                  this.bank.item[index].Init();
                }
                else
                {
                  this.bank.item[index].netDefaults(Type, Stack);
                  this.bank.item[index].Prefix(pre);
                  this.itemsFound.Set((int) this.bank.item[index].type, true);
                }
              }
              for (int index = 0; index < 20; ++index)
              {
                int Type = (int) binaryReader.ReadInt16();
                int Stack = (int) binaryReader.ReadInt16();
                int pre = (int) binaryReader.ReadByte();
                if (Type == 0)
                {
                  this.safe.item[index].Init();
                }
                else
                {
                  this.safe.item[index].netDefaults(Type, Stack);
                  this.safe.item[index].Prefix(pre);
                  this.itemsFound.Set((int) this.safe.item[index].type, true);
                }
              }
              for (int index = 0; index < 10; ++index)
              {
                this.buff[index].Type = binaryReader.ReadUInt16();
                this.buff[index].Time = binaryReader.ReadUInt16();
              }
              if (num1 >= 1)
                this.pet = binaryReader.ReadSByte();
              if (num1 >= 2)
              {
                int count1 = (int) binaryReader.ReadUInt16();
                this.itemsFound = new BitArray(binaryReader.ReadBytes(count1));
                if (this.itemsFound.Length < 632)
                  this.itemsFound.Length = 632;
                int count2 = (int) binaryReader.ReadUInt16();
                this.recipesFound = new BitArray(binaryReader.ReadBytes(count2));
                this.recipesNew = new BitArray(binaryReader.ReadBytes(count2));
                if (num1 >= 3)
                {
                  int count3 = (int) binaryReader.ReadUInt16();
                  this.craftingStationsFound = new BitArray(binaryReader.ReadBytes(count3));
                }
                else
                  this.InitKnownCraftingStations();
              }
              else
                this.InitKnownItems();
              for (int index = 0; index < 200; ++index)
              {
                int num3 = (int) binaryReader.ReadInt16();
                if (num3 != -1)
                {
                  this.spX[index] = (short) num3;
                  this.spY[index] = binaryReader.ReadInt16();
                  this.spI[index] = binaryReader.ReadInt32();
                  this.spN[index] = binaryReader.ReadString();
                }
                else
                  break;
              }
              binaryReader.Close();
            }
          }
        }
        this.PlayerFrame();
      }
      catch
      {
        Main.ShowSaveIcon();
        c.DeleteFile(playerPath);
        this.name = (string) null;
        Main.HideSaveIcon();
      }
    }

    public bool HasItem(int type)
    {
      for (int index = 0; index < 48; ++index)
      {
        if (type == (int) this.inventory[index].type)
          return true;
      }
      return false;
    }

    public void UpdateGrappleItemSlot()
    {
      int index1 = -1;
      if (!this.noItems)
      {
        for (int index2 = 0; index2 < 48; ++index2)
        {
          if ((int) this.inventory[index2].shoot == 13 || (int) this.inventory[index2].shoot == 32 || (int) this.inventory[index2].shoot == 73)
          {
            index1 = index2;
            break;
          }
        }
        if (index1 >= 0)
        {
          int num1 = (int) this.inventory[index1].shoot;
          if (num1 == 73)
          {
            int num2 = 0;
            for (int index2 = 0; index2 < 512; ++index2)
            {
              if (((int) Main.projectile[index2].type == 73 || (int) Main.projectile[index2].type == 74) && ((int) Main.projectile[index2].active != 0 && (int) Main.projectile[index2].owner == (int) this.whoAmI) && ++num2 > 1)
              {
                index1 = -1;
                break;
              }
            }
          }
          else
          {
            for (int index2 = 0; index2 < 512; ++index2)
            {
              if ((int) Main.projectile[index2].type == num1 && (int) Main.projectile[index2].active != 0 && ((int) Main.projectile[index2].owner == (int) this.whoAmI && (double) Main.projectile[index2].ai0 != 2.0))
              {
                index1 = -1;
                break;
              }
            }
          }
        }
      }
      this.grappleItemSlot = (sbyte) index1;
    }

    public void QuickGrapple()
    {
      int index1 = (int) this.grappleItemSlot;
      if (index1 < 0)
        return;
      Main.PlaySound(2, this.aabb.X, this.aabb.Y, (int) this.inventory[index1].useSound);
      if (this.isLocal())
      {
        NetMessage.CreateMessage1(51, (int) this.whoAmI);
        NetMessage.SendMessage();
      }
      int Type = (int) this.inventory[index1].shoot;
      float num1 = this.inventory[index1].shootSpeed;
      int Damage = (int) this.inventory[index1].damage;
      float KnockBack = this.inventory[index1].knockBack;
      if (Type == 13 || Type == 32)
      {
        this.grappling[0] = (short) -1;
        this.grapCount = (byte) 0;
        for (int index2 = 0; index2 < 512; ++index2)
        {
          if ((int) Main.projectile[index2].active != 0 && (int) Main.projectile[index2].owner == (int) this.whoAmI && (int) Main.projectile[index2].type == 13)
            Main.projectile[index2].Kill();
        }
      }
      else if (Type == 73)
      {
        for (int index2 = 0; index2 < 512; ++index2)
        {
          if ((int) Main.projectile[index2].active != 0 && (int) Main.projectile[index2].owner == (int) this.whoAmI && (int) Main.projectile[index2].type == 73)
          {
            Type = 74;
            break;
          }
        }
      }
      Vector2 vector2 = new Vector2(this.position.X + 10f, this.position.Y + 21f);
      float num2 = this.controlDir.X;
      float num3 = this.controlDir.Y;
      float num4 = (float) ((double) num2 * (double) num2 + (double) num3 * (double) num3);
      if ((double) num4 <= 0.0)
        return;
      float num5 = num1 / (float) Math.Sqrt((double) num4);
      float SpeedX = num2 * num5;
      float SpeedY = num3 * num5;
      Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, KnockBack, (int) this.whoAmI, true);
    }

    public void InitKnownItems()
    {
      this.itemsFound.Set(9, true);
      this.itemsFound.Set(23, true);
      this.itemsFound.Set(3, true);
      this.itemsFound.Set(2, true);
      this.itemsFound.Set(38, true);
      this.itemsFound.Set(31, true);
      this.itemsFound.Set(68, true);
    }

    public void InitKnownCraftingStations()
    {
      this.craftingStationsFound.Set(13, true);
      this.craftingStationsFound.Set(15, true);
      this.craftingStationsFound.Set(18, true);
    }

    public void UpdateEditSign()
    {
      if ((int) this.sign == -1)
      {
        this.ui.editSign = false;
      }
      else
      {
        this.ui.npcChatText = this.ui.GetInputText(this.ui.npcChatText, (string) null, (string) null, true);
        if (!this.ui.inputTextEnter)
          return;
        this.ui.inputTextEnter = false;
        Main.PlaySound(12);
        int number2 = (int) this.sign;
        Main.sign[number2].SetText(this.ui.npcChatText);
        this.ui.editSign = false;
        if (Main.netMode != 1)
          return;
        NetMessage.CreateMessage2(47, (int) this.whoAmI, number2);
        NetMessage.SendMessage();
      }
    }

    public void UpdateMouse()
    {
      int num1 = this.aabb.X + 10 - this.view.screenPosition.X;
      int num2 = this.aabb.Y + 21 - this.view.screenPosition.Y;
      if (num1 > (int) this.view.viewWidth || num1 < 0 || (num2 > 540 || num2 < 0))
      {
        this.ui.mouseX = (short) (((int) this.view.viewWidth >> 1) + ((int) this.direction << 5));
        this.ui.mouseY = (short) 270;
      }
      else
      {
        int num3 = (int) this.inventory[(int) this.selectedItem].tileBoost + (int) this.blockRange;
        int num4 = 5 + num3 << 4;
        this.relativeTargetX += this.ui.gpState.ThumbSticks.Right.X * 6f;
        this.relativeTargetY -= this.ui.gpState.ThumbSticks.Right.Y * 6f;
        if ((double) this.relativeTargetX <= (double) -num4)
          this.relativeTargetX = (float) -(num4 - 1);
        else if ((double) this.relativeTargetX >= (double) num4)
          this.relativeTargetX = (float) (num4 - 1);
        int num5 = (int) this.relativeTargetX;
        int num6 = num1 + num5;
        if (num6 < 0)
        {
          this.relativeTargetX -= (float) num6;
          num6 = 0;
        }
        else if (num6 >= (int) this.view.viewWidth)
        {
          int num7 = (int) this.view.viewWidth - 1 - num6;
          this.relativeTargetX += (float) num7;
          num6 += num7;
        }
        this.ui.mouseX = (short) num6;
        int num8 = 4 + num3 << 4;
        if ((double) this.relativeTargetY <= (double) -num8)
          this.relativeTargetY = (float) -(num8 - 1);
        else if ((double) this.relativeTargetY >= (double) num8)
          this.relativeTargetY = (float) (num8 - 1);
        int num9 = num2 + (int) this.relativeTargetY;
        if (num9 < 0)
        {
          this.relativeTargetY -= (float) num9;
          num9 = 0;
        }
        else if (num9 >= 540)
        {
          int num7 = 539 - num9;
          this.relativeTargetY += (float) num7;
          num9 += num7;
        }
        this.ui.mouseY = (short) num9;
      }
      this.controlDir.X = (float) ((int) this.ui.mouseX - num1);
      this.controlDir.Y = (float) ((int) this.ui.mouseY - num2);
    }

    public unsafe void UpdateMouseSmart()
    {
      int num1 = this.aabb.X + 10 - this.view.screenPosition.X;
      int num2 = this.aabb.Y + 21 - this.view.screenPosition.Y;
      fixed (Item* objPtr = &this.inventory[(int) this.selectedItem])
      {
        Vector2 right = this.ui.gpState.ThumbSticks.Right;
        Vector2 vector2_1 = right;
        bool flag1 = (double) right.LengthSquared() <= 1.0 / 64.0;
        if (!flag1)
          vector2_1.Normalize();
        Vector2 left = this.ui.gpState.ThumbSticks.Left;
        Vector2 vector2_2 = left;
        bool flag2 = (double) left.LengthSquared() <= 1.0 / 64.0;
        if (!flag2)
          vector2_2.Normalize();
        int index1 = 0;
        if ((int) objPtr->type > 0)
        {
          if (flag1)
          {
            if (flag2)
            {
              this.controlDir.X = (float) this.direction;
              this.controlDir.Y = 0.0f;
            }
            else
            {
              this.controlDir.X = vector2_2.X;
              this.controlDir.Y = -vector2_2.Y;
            }
          }
          else
          {
            this.controlDir.X = vector2_1.X;
            this.controlDir.Y = -vector2_1.Y;
          }
          int num3 = (int) objPtr->tileBoost + (int) this.blockRange;
          Vector2 vector2_3 = new Vector2((float) (-(double) this.controlDir.Y * 16.0), this.controlDir.X * 16f);
          int num4 = this.aabb.X;
          int num5 = this.aabb.Y + 21;
          if ((double) this.controlDir.X >= 0.0)
            num4 += 20;
          double num6 = (double) num4;
          double num7 = (double) num5;
          for (int index2 = 2; index2 >= 0; --index2)
          {
            double num8 = num6 * (1.0 / 16.0);
            double num9 = num7 * (1.0 / 16.0);
            int num10 = (int) num8 + (5 + num3) * ((double) this.controlDir.X < 0.0 ? -1 : 1);
            int num11 = (int) num9 + (5 + num3) * ((double) this.controlDir.Y < 0.0 ? -1 : 1);
            int i;
            int j1;
            int index3;
            while (true)
            {
              i = (int) num8;
              j1 = (int) num9;
              index3 = (int) Main.tile[i, j1].type;
              bool flag3 = (int) objPtr->axe > 0 && Main.tileAxe[index3] || (int) objPtr->hammer > 0 && (Main.tileHammer[index3] || (int) Main.tile[i, j1].wall > 0 && WorldGen.CanKillWall(i, j1));
              if (flag3 || ((int) objPtr->pick > 0 || (int) objPtr->createTile >= 0) && ((int) Main.tile[i, j1].active != 0 && Main.tileSolid[index3]) || (int) objPtr->createWall >= 0 && (int) Main.tile[i, j1].wall == 0)
              {
                if (!flag3)
                {
                  if ((int) objPtr->pick > 0)
                  {
                    if (!Main.tileAxe[index3] && !Main.tileHammer[index3] && WorldGen.CanKillTile(i, j1))
                      goto label_30;
                  }
                  else if ((int) objPtr->createTile >= 0)
                  {
                    i = (int) (num8 - (double) this.controlDir.X);
                    if ((int) Main.tile[i, j1].active != 0 && Main.tileSolid[index3])
                    {
                      i = (int) num8;
                      j1 = (int) (num9 - (double) this.controlDir.Y);
                      if ((int) Main.tile[i, j1].active != 0 && Main.tileSolid[index3])
                      {
                        i = (int) (num8 - (double) this.controlDir.X);
                        if ((int) Main.tile[i, j1].active != 0 && Main.tileSolid[index3])
                        {
                          i = (int) num8;
                          j1 = (int) num9;
                          goto label_31;
                        }
                      }
                    }
                    int j2 = j1;
                    if (!WorldGen.CanPlaceTile(i, ref j2, (int) objPtr->createTile, -1))
                    {
                      i = (int) num8;
                      j1 = (int) num9;
                    }
                    else
                      goto label_30;
                  }
                  else
                    goto label_30;
                }
                else
                  break;
              }
label_31:
              if (i != num10 && j1 != num11)
              {
                num8 += (double) this.controlDir.X;
                num9 += (double) this.controlDir.Y;
              }
              else
                goto label_33;
            }
            if (Main.tileAxe[index3] && (!Main.tileAxe[(int) Main.tile[i, j1 - 1].type] || !Main.tileAxe[(int) Main.tile[i, j1 - 2].type]))
            {
              --i;
              if (!Main.tileAxe[(int) Main.tile[i, j1].type] || !Main.tileAxe[(int) Main.tile[i, j1 - 1].type] || !Main.tileAxe[(int) Main.tile[i, j1 - 2].type])
              {
                i += 2;
                if (!Main.tileAxe[(int) Main.tile[i, j1].type] || !Main.tileAxe[(int) Main.tile[i, j1 - 1].type] || !Main.tileAxe[(int) Main.tile[i, j1 - 2].type])
                  --i;
              }
            }
label_30:
            this.smartLocation[index1].X = (i << 4) + 8;
            this.smartLocation[index1].Y = (j1 << 4) + 8;
            ++index1;
label_33:
            if (index2 == 1)
            {
              double num12 = num6 - (double) vector2_3.X;
              double num13 = num7 - (double) vector2_3.Y;
              num6 = num12 - (double) vector2_3.X;
              num7 = num13 - (double) vector2_3.Y;
            }
            else
            {
              num6 += (double) vector2_3.X;
              num7 += (double) vector2_3.Y;
            }
          }
          if (index1 > 0)
          {
            int index2 = 0;
            if (index1 > 1)
            {
              int num8 = num4;
              int num9 = num5;
              if ((int) objPtr->createTile == 4)
              {
                num8 += (int) ((double) this.controlDir.X * 256.0);
                num9 += (int) ((double) this.controlDir.Y * 256.0);
              }
              else if ((int) objPtr->pick <= 0 && (int) objPtr->hammer <= 0 && ((int) objPtr->createWall < 0 && (int) objPtr->createTile < 0) && (int) objPtr->axe > 0)
                num9 += 42;
              int num10 = num8 - this.smartLocation[0].X;
              int num11 = num9 - this.smartLocation[0].Y;
              int num12 = num10 * num10 + num11 * num11;
              int index3 = 1;
              do
              {
                int num13 = num8 - this.smartLocation[index3].X;
                int num14 = num9 - this.smartLocation[index3].Y;
                int num15 = num13 * num13 + num14 * num14;
                if (num15 < num12)
                {
                  num12 = num15;
                  index2 = index3;
                }
              }
              while (++index3 < index1);
            }
            num1 = this.smartLocation[index2].X - this.view.screenPosition.X;
            num2 = this.smartLocation[index2].Y - this.view.screenPosition.Y;
          }
          else
            this.ui.cursorHighlight = 0;
        }
        if (flag1)
        {
          if (flag2)
            this.controlDir.X = (float) ((int) this.direction << 4);
          else if ((double) left.LengthSquared() < 0.25)
          {
            this.controlDir.X = vector2_2.X * 32f;
            this.controlDir.Y = vector2_2.Y * -32f;
          }
          else
          {
            this.controlDir.X = left.X * 80f;
            this.controlDir.Y = left.Y * -80f;
          }
        }
        else if ((double) right.LengthSquared() < 0.25)
        {
          this.controlDir.X = vector2_1.X * 32f;
          this.controlDir.Y = vector2_1.Y * -32f;
        }
        else
        {
          this.controlDir.X = right.X * 80f;
          this.controlDir.Y = right.Y * -80f;
        }
        if (index1 == 0 && (int) objPtr->shoot > 0)
        {
          num1 += (int) this.controlDir.X;
          num2 += (int) this.controlDir.Y;
        }
        this.ui.mouseX = (short) num1;
        this.ui.mouseY = (short) num2;
      }
    }

    public unsafe void Draw(WorldView drawView, bool isMenu = false, bool isIcon = false)
    {
      this.aabb.X = (int) this.position.X;
      this.aabb.Y = (int) this.position.Y;
      Color newColor1;
      Color newColor2;
      Color newColor3;
      Color newColor4;
      Color newColor5;
      Color newColor6;
      Color newColor7;
      Color newColor8;
      Color newColor9;
      Color newColor10;
      Color newColor11;
      Color newColor12;
      Color c;
      if (isMenu)
      {
        newColor1 = Color.White;
        newColor2 = Color.White;
        newColor3 = Color.White;
        newColor4 = Color.White;
        newColor5 = this.shirtColor;
        newColor6 = this.underShirtColor;
        newColor7 = this.pantsColor;
        newColor8 = this.shoeColor;
        newColor9 = this.eyeColor;
        newColor10 = this.hairColor;
        newColor11 = this.skinColor;
        newColor12 = this.skinColor;
        c = this.skinColor;
      }
      else
      {
        int x = this.aabb.X + 10 >> 4;
        int y1 = (int) ((double) this.position.Y + 21.0) >> 4;
        int y2 = (int) ((double) this.position.Y + 10.5) >> 4;
        int y3 = (int) ((double) this.position.Y + 31.5) >> 4;
        newColor5 = this.GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y1, this.shirtColor));
        newColor6 = this.GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y1, this.underShirtColor));
        newColor7 = this.GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y1, this.pantsColor));
        newColor8 = this.GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y3, this.shoeColor));
        newColor1 = this.GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y2));
        newColor2 = this.GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y1));
        newColor3 = this.GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y3));
        if ((double) this.shadow > 0.0)
        {
          newColor4 = new Color();
          newColor9 = new Color();
          newColor10 = new Color();
          newColor11 = new Color();
          newColor12 = new Color();
          c = new Color();
        }
        else
        {
          newColor4 = this.GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2));
          newColor9 = this.GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2, this.eyeColor));
          newColor10 = this.GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2, this.hairColor));
          newColor11 = this.GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2, this.skinColor));
          newColor12 = this.GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y1, this.skinColor));
          c = this.GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y3, this.skinColor));
        }
      }
      if ((double) this.buffR != 1.0 || (double) this.buffG != 1.0 || (double) this.buffB != 1.0)
      {
        if (this.onFire || this.onFire2)
        {
          newColor4 = this.GetImmuneAlpha(Color.White);
          newColor9 = this.GetImmuneAlpha(this.eyeColor);
          newColor10 = this.GetImmuneAlpha(this.hairColor);
          newColor11 = this.GetImmuneAlpha(this.skinColor);
          newColor12 = this.GetImmuneAlpha(this.skinColor);
          newColor5 = this.GetImmuneAlpha(this.shirtColor);
          newColor6 = this.GetImmuneAlpha(this.underShirtColor);
          newColor7 = this.GetImmuneAlpha(this.pantsColor);
          newColor8 = this.GetImmuneAlpha(this.shoeColor);
          newColor1 = this.GetImmuneAlpha(Color.White);
          newColor2 = this.GetImmuneAlpha(Color.White);
          newColor3 = this.GetImmuneAlpha(Color.White);
        }
        else
        {
          Player.buffColor(ref newColor4, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor9, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor10, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor11, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor12, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor5, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor6, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor7, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor8, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor1, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor2, (double) this.buffR, (double) this.buffG, (double) this.buffB);
          Player.buffColor(ref newColor3, (double) this.buffR, (double) this.buffG, (double) this.buffB);
        }
      }
      SpriteEffects e1;
      SpriteEffects e2;
      if ((int) this.gravDir == 1)
      {
        if ((int) this.direction == 1)
        {
          e1 = SpriteEffects.None;
          e2 = SpriteEffects.None;
        }
        else
        {
          e1 = SpriteEffects.FlipHorizontally;
          e2 = SpriteEffects.FlipHorizontally;
        }
        if (!this.dead)
        {
          this.legPosition.Y = 0.0f;
          this.headPosition.Y = 0.0f;
          this.bodyPosition.Y = 0.0f;
        }
      }
      else
      {
        if ((int) this.direction == 1)
        {
          e1 = SpriteEffects.FlipVertically;
          e2 = SpriteEffects.FlipVertically;
        }
        else
        {
          e1 = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
          e2 = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically;
        }
        if (!this.dead)
        {
          this.legPosition.Y = 6f;
          this.headPosition.Y = 6f;
          this.bodyPosition.Y = 6f;
        }
      }
      Vector2 pivot1 = new Vector2(20f, 42f);
      Vector2 pivot2 = new Vector2(20f, 28f);
      Vector2 pivot3 = new Vector2(20f, 22.4f);
      Vector2 pos = Vector2.Zero;
      if (this.merman)
      {
        this.headRotation = (float) ((double) this.velocity.Y * (double) this.direction * 0.100000001490116);
        if ((double) this.headRotation < -0.3)
          this.headRotation = -0.3f;
        if ((double) this.headRotation > 0.3)
          this.headRotation = 0.3f;
      }
      else if (!this.dead)
        this.headRotation = 0.0f;
      if (!isIcon)
      {
        if ((int) this.wings > 0)
        {
          pos = new Vector2((float) (this.aabb.X - drawView.screenPosition.X + 10 - 9 * (int) this.direction), (float) (this.aabb.Y - drawView.screenPosition.Y + 21 + ((int) this.gravDir << 1)));
          int id = 1484 + (int) this.wings;
          int sh = SpriteSheet<_sheetSprites>.src[id].Height >> 2;
          SpriteSheet<_sheetSprites>.DrawRotated(id, ref pos, sh * (int) this.wingFrame, sh, newColor2, this.bodyRotation, e1);
        }
        if (!this.invis)
        {
          pos = new Vector2((float) (20 + (int) this.bodyPosition.X + this.aabb.X - drawView.screenPosition.X - 20 + 10), (float) (28 + (int) this.bodyPosition.Y + this.aabb.Y - drawView.screenPosition.Y + 42 - 56 + 4));
          SpriteSheet<_sheetSprites>.DrawRotated(1472, ref pos, (int) this.bodyFrameY, 54, newColor12, this.bodyRotation, ref pivot2, e1);
          SpriteSheet<_sheetSprites>.DrawRotated(1473, ref pos, (int) this.legFrameY, 54, c, this.legRotation, ref pivot2, e1);
        }
        pos = new Vector2((float) (int) ((double) this.position.X - (double) drawView.screenPosition.X - 20.0 + 10.0), (float) (int) ((double) this.position.Y - (double) drawView.screenPosition.Y + 42.0 - 56.0 + 4.0)) + this.legPosition + pivot1;
        if ((int) this.legs > 0 && (int) this.legs < 28)
          SpriteSheet<_sheetSprites>.DrawRotated(107 + (int) this.legs, ref pos, (int) this.legFrameY, 54, newColor3, this.legRotation, ref pivot1, e1);
        else if (!this.invis)
        {
          if (!this.male)
          {
            SpriteSheet<_sheetSprites>.DrawRotated(249, ref pos, (int) this.legFrameY, 54, newColor7, this.legRotation, ref pivot1, e1);
            SpriteSheet<_sheetSprites>.DrawRotated(252, ref pos, (int) this.legFrameY, 54, newColor8, this.legRotation, ref pivot1, e1);
          }
          else
          {
            SpriteSheet<_sheetSprites>.DrawRotated(1344, ref pos, (int) this.legFrameY, 54, newColor7, this.legRotation, ref pivot1, e1);
            SpriteSheet<_sheetSprites>.DrawRotated(1346, ref pos, (int) this.legFrameY, 54, newColor8, this.legRotation, ref pivot1, e1);
          }
        }
        pos.X = (float) (this.aabb.X - drawView.screenPosition.X + 10);
        pos.Y = (float) (this.aabb.Y - drawView.screenPosition.Y + 42 - 56 + 4 + 28);
        pos.X += this.bodyPosition.X;
        pos.Y += this.bodyPosition.Y;
        if ((int) this.body > 0 && (int) this.body < 29)
        {
          SpriteSheet<_sheetSprites>.DrawRotated((this.male ? 32 : 220) + (int) this.body, ref pos, (int) this.bodyFrameY, 54, newColor2, this.bodyRotation, ref pivot2, e1);
          if (!this.invis && ((int) this.body >= 10 && (int) this.body <= 16 || (int) this.body == 20))
            SpriteSheet<_sheetSprites>.DrawRotated(1342, ref pos, (int) this.bodyFrameY, 54, newColor12, this.bodyRotation, ref pivot2, e1);
        }
        else if (!this.invis)
        {
          if (!this.male)
          {
            SpriteSheet<_sheetSprites>.DrawRotated(254, ref pos, (int) this.bodyFrameY, 54, newColor6, this.bodyRotation, ref pivot2, e1);
            SpriteSheet<_sheetSprites>.DrawRotated(251, ref pos, (int) this.bodyFrameY, 54, newColor5, this.bodyRotation, ref pivot2, e1);
          }
          else
          {
            SpriteSheet<_sheetSprites>.DrawRotated(1348, ref pos, (int) this.bodyFrameY, 54, newColor6, this.bodyRotation, ref pivot2, e1);
            SpriteSheet<_sheetSprites>.DrawRotated(1345, ref pos, (int) this.bodyFrameY, 54, newColor5, this.bodyRotation, ref pivot2, e1);
          }
          SpriteSheet<_sheetSprites>.DrawRotated(1342, ref pos, (int) this.bodyFrameY, 54, newColor12, this.bodyRotation, ref pivot2, e1);
        }
      }
      pos.X = (float) (this.aabb.X - drawView.screenPosition.X - 20 + 10);
      pos.Y = (float) (this.aabb.Y - drawView.screenPosition.Y + 42 - 56 + 4);
      pos.X += this.headPosition.X + pivot3.X;
      pos.Y += this.headPosition.Y + pivot3.Y;
      if (!this.invis && (int) this.head != 38)
      {
        SpriteSheet<_sheetSprites>.DrawRotated(1343, ref pos, (int) this.bodyFrameY, 54, newColor11, this.headRotation, ref pivot3, e1);
        SpriteSheet<_sheetSprites>.DrawRotated(1267, ref pos, (int) this.bodyFrameY, 54, newColor4, this.headRotation, ref pivot3, e1);
        SpriteSheet<_sheetSprites>.DrawRotated(1268, ref pos, (int) this.bodyFrameY, 54, newColor9, this.headRotation, ref pivot3, e1);
      }
      if ((int) this.head == 10 || (int) this.head == 12 || (int) this.head == 28)
      {
        SpriteSheet<_sheetSprites>.DrawRotated(60 + (int) this.head, ref pos, (int) this.bodyFrameY, 54, newColor1, this.headRotation, ref pivot3, e1);
        if (!this.invis)
        {
          int sy = (int) this.bodyFrameY - 336;
          if (sy < 0)
            sy = 0;
          SpriteSheet<_sheetSprites>.DrawRotated(1269 + (int) this.hair, ref pos, sy, 54, newColor10, this.headRotation, ref pivot3, e1);
        }
      }
      else if (((int) this.head >= 14 && (int) this.head <= 16 || ((int) this.head == 18 || (int) this.head == 21) || ((int) this.head >= 24 && (int) this.head <= 26 || ((int) this.head == 40 || (int) this.head == 44))) && !this.invis)
      {
        int sy = (int) this.bodyFrameY - 336;
        if (sy < 0)
          sy = 0;
        SpriteSheet<_sheetSprites>.DrawRotated(1305 + (int) this.hair, ref pos, sy, 54, newColor10, this.headRotation, ref pivot3, e1);
      }
      if ((int) this.head == 23)
      {
        int sy = (int) this.bodyFrameY - 336;
        if (sy < 0)
          sy = 0;
        if (!this.invis)
          SpriteSheet<_sheetSprites>.DrawRotated(1269 + (int) this.hair, ref pos, sy, 54, newColor10, this.headRotation, ref pivot3, e1);
        SpriteSheet<_sheetSprites>.DrawRotated(60 + (int) this.head, ref pos, sy, 54, newColor1, this.headRotation, ref pivot3, e1);
      }
      else if ((int) this.head == 14)
      {
        int num1 = (int) this.bodyFrameY;
        int sh = 56;
        int num2 = 0;
        if (num1 == sh * 6)
          sh -= 2;
        else if (num1 == sh * 7)
          num2 = -2;
        else if (num1 == sh << 3)
          num2 = -2;
        else if (num1 == sh * 9)
          num2 = -2;
        else if (num1 == sh * 10)
          num2 = -2;
        else if (num1 == sh * 13)
          sh -= 2;
        else if (num1 == sh * 14)
          num2 = -2;
        else if (num1 == sh * 15)
          num2 = -2;
        else if (num1 == sh << 4)
          num2 = -2;
        int sy = num1 + num2;
        pos.Y += (float) num2;
        SpriteSheet<_sheetSprites>.DrawRotated(74, ref pos, sy, sh, newColor1, this.headRotation, ref pivot3, e1);
      }
      else if ((int) this.head > 0 && (int) this.head < 48 && (int) this.head != 28)
        SpriteSheet<_sheetSprites>.DrawRotated(60 + (int) this.head, ref pos, (int) this.bodyFrameY, 54, newColor1, this.headRotation, ref pivot3, e1);
      else if (!this.invis)
      {
        int sy = (int) this.bodyFrameY - 336;
        if (sy < 0)
          sy = 0;
        SpriteSheet<_sheetSprites>.DrawRotated(1269 + (int) this.hair, ref pos, sy, 54, newColor10, this.headRotation, ref pivot3, e1);
      }
      if (isIcon)
        return;
      if (!isMenu)
      {
        if ((int) this.heldProj >= 0)
          Main.projectile[(int) this.heldProj].Draw(drawView);
        fixed (Item* objPtr = &this.inventory[(int) this.selectedItem])
        {
          int num1 = (int) objPtr->type;
          if (num1 > 0 && ((int) this.itemAnimation > 0 || (int) objPtr->holdStyle > 0) && (!this.dead && !objPtr->noUseGraphic && (!this.wet || !objPtr->noWet)))
          {
            int id = 451 + num1;
            int num2 = SpriteSheet<_sheetSprites>.src[id].Width;
            Color color = drawView.lighting.GetColor((int) ((double) this.position.X + 10.0) >> 4, (int) ((double) this.position.Y + 21.0) >> 4);
            Color alpha = objPtr->GetAlpha(color);
            pos.X = (float) (this.itemLocation.X - drawView.screenPosition.X);
            pos.Y = (float) (this.itemLocation.Y - drawView.screenPosition.Y);
            Vector2 pivot4 = new Vector2();
            if ((int) objPtr->useStyle == 5)
            {
              int num3 = 10;
              Vector2 centerPivot = SpriteSheet<_sheetSprites>.GetCenterPivot(id);
              pivot4.X = (int) this.direction == -1 ? (float) (num3 + num2) : (float) -num3;
              pivot4.Y = centerPivot.Y;
              int num4;
              if (num1 == 95)
                centerPivot.Y += (float) (2 * (int) this.gravDir);
              else if (num1 == 96)
                num4 = -5;
              else if (num1 == 98)
              {
                num4 = -5;
                centerPivot.Y -= (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 534)
              {
                num4 = -2;
                centerPivot.Y += (float) this.gravDir;
              }
              else if (num1 == 533)
              {
                num4 = -7;
                centerPivot.Y -= (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 506)
              {
                num4 = 0;
                centerPivot.Y -= (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 494 || num1 == 508)
                num4 = -2;
              else if (num1 == 434)
              {
                num4 = 0;
                centerPivot.Y -= (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 514)
              {
                num4 = 0;
                centerPivot.Y += (float) (3 * (int) this.gravDir);
              }
              else if (num1 == 435 || num1 == 436 || (num1 == 481 || num1 == 578))
              {
                num4 = -2;
                centerPivot.Y -= (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 197)
              {
                num4 = -5;
                centerPivot.Y += (float) (4 * (int) this.gravDir);
              }
              else if (num1 == 126)
              {
                num4 = 4;
                centerPivot.Y += (float) (4 * (int) this.gravDir);
              }
              else if (num1 == (int) sbyte.MaxValue)
              {
                num4 = 4;
                centerPivot.Y += (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 157)
              {
                num4 = 6;
                centerPivot.Y += (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 160)
                num4 = -8;
              else if (num1 == 164 || num1 == 219)
              {
                num4 = 2;
                centerPivot.Y += (float) (4 * (int) this.gravDir);
              }
              else if (num1 == 165 || num1 == 272)
              {
                num4 = 4;
                centerPivot.Y += (float) (4 * (int) this.gravDir);
              }
              else if (num1 == 266)
              {
                num4 = 0;
                centerPivot.Y += (float) (2 * (int) this.gravDir);
              }
              else if (num1 == 281)
              {
                num4 = 6;
                centerPivot.Y -= (float) (6 * (int) this.gravDir);
              }
              pos.X += centerPivot.X;
              pos.Y += centerPivot.Y;
              SpriteSheet<_sheetSprites>.Draw(id, ref pos, alpha, this.itemRotation, ref pivot4, objPtr->scale, e2);
              if ((int) objPtr->color.PackedValue != 0)
                SpriteSheet<_sheetSprites>.Draw(id, ref pos, objPtr->GetColor(color), this.itemRotation, ref pivot4, objPtr->scale, e2);
            }
            else if ((int) this.gravDir == -1)
            {
              pivot4.X = (float) ((num2 >> 1) - (num2 >> 1) * (int) this.direction);
              pivot4.Y = 0.0f;
              SpriteSheet<_sheetSprites>.Draw(id, ref pos, alpha, this.itemRotation, ref pivot4, objPtr->scale, e2);
              if ((int) objPtr->color.PackedValue != 0)
                SpriteSheet<_sheetSprites>.Draw(id, ref pos, objPtr->GetColor(color), this.itemRotation, ref pivot4, objPtr->scale, e2);
            }
            else
            {
              if (num1 == 507 || num1 == 425)
                e2 = (int) this.gravDir != 1 ? ((int) this.direction != 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None) : ((int) this.direction != 1 ? SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically : SpriteEffects.FlipVertically);
              pivot4 = new Vector2((float) ((num2 >> 1) - (num2 >> 1) * (int) this.direction), (float) SpriteSheet<_sheetSprites>.src[id].Height);
              SpriteSheet<_sheetSprites>.Draw(id, ref pos, alpha, this.itemRotation, ref pivot4, objPtr->scale, e2);
              if ((int) objPtr->color.PackedValue != 0)
                SpriteSheet<_sheetSprites>.Draw(id, ref pos, objPtr->GetColor(color), this.itemRotation, ref pivot4, objPtr->scale, e2);
            }
          }
        }
      }
      pos.X = (float) (this.aabb.X - drawView.screenPosition.X + 10);
      pos.Y = (float) (this.aabb.Y - drawView.screenPosition.Y + 42 - 28 + 4);
      pos.X += this.bodyPosition.X;
      pos.Y += this.bodyPosition.Y;
      if ((int) this.body > 0 && (int) this.body < 29)
      {
        SpriteSheet<_sheetSprites>.DrawRotated(4 + (int) this.body, ref pos, (int) this.bodyFrameY, 54, newColor2, this.bodyRotation, ref pivot2, e1);
        if (this.invis || ((int) this.body < 10 || (int) this.body > 16) && (int) this.body != 20)
          return;
        SpriteSheet<_sheetSprites>.DrawRotated(1341, ref pos, (int) this.bodyFrameY, 54, newColor12, this.bodyRotation, ref pivot2, e1);
      }
      else
      {
        if (this.invis)
          return;
        if (!this.male)
        {
          SpriteSheet<_sheetSprites>.DrawRotated(253, ref pos, (int) this.bodyFrameY, 54, newColor6, this.bodyRotation, ref pivot2, e1);
          SpriteSheet<_sheetSprites>.DrawRotated(250, ref pos, (int) this.bodyFrameY, 54, newColor5, this.bodyRotation, ref pivot2, e1);
        }
        else
          SpriteSheet<_sheetSprites>.DrawRotated(1347, ref pos, (int) this.bodyFrameY, 54, newColor6, this.bodyRotation, ref pivot2, e1);
        SpriteSheet<_sheetSprites>.DrawRotated(1341, ref pos, (int) this.bodyFrameY, 54, newColor12, this.bodyRotation, ref pivot2, e1);
      }
    }

    public void DrawGhost(WorldView drawView)
    {
      this.aabb.X = (int) this.position.X;
      this.aabb.Y = (int) this.position.Y;
      SpriteEffects e = (int) this.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
      int num = ((int) UI.mouseTextBrightness >> 1) + 100;
      Color immuneAlpha = this.GetImmuneAlpha(drawView.lighting.GetColorPlayer(this.aabb.X + 10 >> 4, this.aabb.Y + 21 >> 4, new Color(num, num, num, num)));
      int sh = SpriteSheet<_sheetSprites>.src[(int) byte.MaxValue].Height >> 2;
      Vector2 pos = new Vector2((float) (this.aabb.X - drawView.screenPosition.X), (float) (this.aabb.Y - drawView.screenPosition.Y));
      SpriteSheet<_sheetSprites>.Draw((int) byte.MaxValue, ref pos, sh * ((int) this.ghostFrameCounter >> 3 & 3), sh, immuneAlpha, e);
    }

    public Item armorSwap(ref Item newItem)
    {
      int index1 = 0;
      for (int index2 = 0; index2 < this.armor.Length; ++index2)
      {
        if ((int) newItem.netID == (int) this.armor[index2].netID)
          index1 = index2;
      }
      Item obj1 = newItem;
      Item obj2;
      if ((int) newItem.headSlot != -1)
      {
        int index2 = newItem.vanity ? 8 : 0;
        obj2 = this.armor[index2];
        this.armor[index2] = newItem;
      }
      else if ((int) newItem.bodySlot != -1)
      {
        int index2 = newItem.vanity ? 9 : 1;
        obj2 = this.armor[index2];
        this.armor[index2] = newItem;
      }
      else if ((int) newItem.legSlot != -1)
      {
        int index2 = newItem.vanity ? 10 : 2;
        obj2 = this.armor[index2];
        this.armor[index2] = newItem;
      }
      else
      {
        for (int index2 = 3; index2 < 8; ++index2)
        {
          if ((int) this.armor[index2].type == 0)
          {
            index1 = index2;
            break;
          }
        }
        for (int index2 = 0; index2 < this.armor.Length; ++index2)
        {
          if ((int) newItem.netID == (int) this.armor[index2].netID)
            index1 = index2;
        }
        if (index1 >= 8)
          index1 = 3;
        else if (index1 < 3)
          index1 = 7;
        obj2 = this.armor[index1];
        this.armor[index1] = newItem;
      }
      Main.PlaySound(7);
      return obj2;
    }

    public int CountInventory(int netID)
    {
      int num = 0;
      for (int index = 47; index >= 0; --index)
      {
        if ((int) this.inventory[index].netID == netID)
          num += (int) this.inventory[index].stack;
      }
      return num;
    }

    public int CountEquipment(int netID)
    {
      int num = 0;
      for (int index = 10; index >= 0; --index)
      {
        if ((int) this.armor[index].netID == netID)
          num += (int) this.inventory[index].stack;
      }
      return num;
    }

    public int CountPossession(int netID)
    {
      return this.CountInventory(netID) + this.CountEquipment(netID);
    }

    public bool IsNearCraftingStation(Recipe r)
    {
      for (int index = (int) r.numRequiredTiles - 1; index >= 0; --index)
      {
        if (!this.adjTile[(int) r.requiredTile[index]].i)
          return false;
      }
      if (!this.adjWater)
        return !r.needWater;
      else
        return true;
    }

    public bool CanCraftRecipe(Recipe r)
    {
      if (Main.tutorialState < Tutorial.CRAFT_TORCH || Main.tutorialState == Tutorial.CRAFT_TORCH && (int) r.createItem.type != 8)
        return false;
      for (int index1 = (int) r.numRequiredItems - 1; index1 >= 0; --index1)
      {
        int num = (int) r.requiredItem[index1].stack;
        for (int index2 = 47; index2 >= 0; --index2)
        {
          if ((int) this.inventory[index2].netID == (int) r.requiredItem[index1].netID)
          {
            num -= (int) this.inventory[index2].stack;
            if (num <= 0)
              break;
          }
        }
        if (num > 0)
          return false;
      }
      return this.IsNearCraftingStation(r);
    }

    public bool DiscoveredRecipe(Recipe r)
    {
      for (int index = (int) r.numRequiredItems - 1; index >= 0; --index)
      {
        if (!this.itemsFound.Get((int) r.requiredItem[index].type))
          return false;
      }
      for (int index = (int) r.numRequiredTiles - 1; index >= 0; --index)
      {
        if (!this.craftingStationsFound.Get((int) r.requiredTile[index]))
          return false;
      }
      return true;
    }

    public void UpdateRecipes()
    {
      for (int index = 341; index >= 0; --index)
      {
        if (!this.recipesFound.Get(index) && this.DiscoveredRecipe(Main.recipe[index]))
        {
          this.recipesFound.Set(index, true);
          this.recipesNew.Set(index, true);
        }
      }
    }

    private void ApplyPetBuff(int itemType)
    {
      if ((int) this.pet >= 0)
      {
        int num = (int) Projectile.petProj[(int) this.pet];
        for (int index = 0; index < 512; ++index)
        {
          if ((int) Main.projectile[index].type == num && (int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI)
          {
            Main.projectile[index].Kill();
            break;
          }
        }
        if (itemType == (int) Projectile.petItem[(int) this.pet])
        {
          this.DelBuff(Buff.ID.PET);
          return;
        }
      }
      int index1 = Projectile.petItem.Length - 1;
      while (index1 >= 0 && itemType != (int) Projectile.petItem[index1])
        --index1;
      this.pet = (sbyte) index1;
      this.ui.petSpawnMask |= (byte) (1 << index1);
      if ((int) this.ui.petSpawnMask == 63)
        this.ui.SetTriggerState(Trigger.SpawnedAllPets);
      this.AddBuff(40, 3600, true);
    }

    private void SpawnPet()
    {
      int Type = (int) Projectile.petProj[(int) this.pet];
      for (int index = 0; index < 512; ++index)
      {
        if ((int) Main.projectile[index].type == Type && (int) Main.projectile[index].active != 0 && (int) Main.projectile[index].owner == (int) this.whoAmI)
          return;
      }
      Projectile.NewProjectile(this.position.X + 10f, this.position.Y + 21f, 0.0f, 0.0f, Type, 0, 0.0f, (int) this.whoAmI, true);
    }

    public void AchievementTrigger(Trigger trigger)
    {
      if (this.isLocal())
      {
        this.ui.SetTriggerState(trigger);
      }
      else
      {
        NetMessage.CreateMessage2(64, (int) this.whoAmI, (int) trigger);
        NetMessage.SendMessage(this.client);
      }
    }

    public void IncreaseStatistic(StatisticEntry entry)
    {
      if (entry == StatisticEntry.Unknown)
        return;
      if (this.isLocal())
      {
        this.ui.Statistics.incStat(entry);
      }
      else
      {
        if (this.client == null)
          return;
        NetMessage.CreateMessage2(65, (int) this.whoAmI, (int) entry);
        NetMessage.SendMessage(this.client);
      }
    }

    public void SunMoonTransition(bool wasBloodMoon)
    {
      ++this.totalSunMoonTransitions;
      if (!Main.gameTime.dayTime || this.totalSunMoonTransitions < 2U)
        return;
      this.AchievementTrigger(Trigger.Sunrise);
      if (!wasBloodMoon)
        return;
      this.AchievementTrigger(Trigger.SunriseAfterBloodMoon);
    }

    private void FoundCraftingStation(int type)
    {
      if (!this.ui.TriggerCheckEnabled(Trigger.UsedAllCraftingStations))
        return;
      this.craftingStationsFound.Set(type, true);
      if (!this.craftingStationsFound.Get(133) || !this.craftingStationsFound.Get(134) || (!this.craftingStationsFound.Get(101) || !this.craftingStationsFound.Get(114)) || (!this.craftingStationsFound.Get(106) || !this.craftingStationsFound.Get(96) || (!this.craftingStationsFound.Get(94) || !this.craftingStationsFound.Get(86))) || (!this.craftingStationsFound.Get(26) || !this.craftingStationsFound.Get(13) || (!this.craftingStationsFound.Get(15) || !this.craftingStationsFound.Get(18))))
        return;
      this.ui.SetTriggerState(Trigger.UsedAllCraftingStations);
    }

    private void IncreaseSteps()
    {
      if (this.ui == null)
        return;
      if ((int) ++this.ui.totalSteps == 42000)
        this.ui.SetTriggerState(Trigger.Walked42KM);
      StatisticEntry entry = StatisticEntry.GroundTravel;
      if (this.wet)
        entry = this.lavaWet ? StatisticEntry.LavaTravel : StatisticEntry.WaterTravel;
      this.ui.Statistics.incStat(entry);
    }

    private void IncreaseAirTime()
    {
      if (this.ui == null)
        return;
      ++this.ui.currentAirTime;
      if (this.ui.currentAirTime < 60U)
        return;
      if ((int) this.ui.currentAirTime == 60)
        this.ui.totalAirTime += 60U;
      else
        ++this.ui.totalAirTime;
      if (this.ui.totalAirTime >= 216000U)
        this.ui.SetTriggerState(Trigger.InTheSky);
      this.ui.airTravel += this.velocity.Length();
      if ((double) this.ui.airTravel <= 20.0)
        return;
      this.ui.airTravel -= 20f;
      this.ui.Statistics.incStat(StatisticEntry.AirTravel);
    }

    private void ResetAirTime()
    {
      if (this.ui == null)
        return;
      this.ui.currentAirTime = 0U;
    }

    public static void buffColor(ref Color newColor, double R, double G, double B)
    {
      newColor.R = (byte) ((double) newColor.R * R);
      newColor.G = (byte) ((double) newColor.G * G);
      newColor.B = (byte) ((double) newColor.B * B);
    }

    public void updateScreenPosition()
    {
      this.view.screenPosition.X = this.aabb.X + 10 - ((int) this.view.viewWidth >> 1);
      this.view.screenPosition.Y = this.aabb.Y + 21 - 270;
    }

    public bool isLocal()
    {
      return this.view != null;
    }

    public void DrawInfo(WorldView view)
    {
      int x = this.aabb.X + 10 - view.screenPosition.X;
      int y = this.aabb.Y + 42 - view.screenPosition.Y;
      int num1 = (int) UI.DrawStringCT(UI.fontSmallOutline, this.name, x, y, Main.teamColor[(int) this.team]);
      int num2 = (int) this.statLife - (int) this.healthBarLife;
      if (num2 != 0)
      {
        if (Math.Abs(num2) > 1)
          this.healthBarLife += (short) (num2 >> 2);
        else
          this.healthBarLife = this.statLife;
      }
      Rectangle rect = new Rectangle();
      rect.X = x - 22;
      rect.Y = y + num1 - 2;
      rect.Height = 10;
      rect.Width = 52;
      Color color = UI.WINDOW_OUTLINE;
      Main.DrawRect(rect, color, false);
      rect.X += 2;
      rect.Y += 2;
      rect.Width = (int) this.healthBarLife * 48 / (int) this.statLifeMax;
      rect.Height = 6;
      color = new Color((48 - rect.Width) * 5, rect.Width * 5, 16, 128);
      Main.DrawSolidRect(ref rect, color);
      if (rect.Width >= 48)
        return;
      color = new Color(0, 0, 0, 128);
      rect.X += rect.Width;
      rect.Width = 48 - rect.Width;
      Main.DrawSolidRect(ref rect, color);
    }

    public struct Adj
    {
      public bool i;
      public bool old;
    }

    public enum ExtraStorage
    {
      SAFE = -3,
      PIGGYBANK = -2,
      NONE = -1,
    }
  }
}
