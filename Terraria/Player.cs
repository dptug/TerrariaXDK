using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
		public struct Adj
		{
			public bool i;

			public bool old;
		}

		public enum ExtraStorage
		{
			NONE = -1,
			PIGGYBANK = -2,
			SAFE = -3
		}

		public const int MAX_PLAYERS = 8;

		public const int MAX_ARMOR = 11;

		public const int MAX_INVENTORY = 48;

		public const int MAX_HAIR = 36;

		public const int NUM_ARMOR_HEAD = 48;

		public const int NUM_ARMOR_BODY = 29;

		public const int NUM_ARMOR_LEGS = 28;

		public const int NAME_LEN = 16;

		public const int MAX_BUFFS = 10;

		public const short breathMax = 200;

		private const int bodyFrameHeight = 56;

		private const int legFrameHeight = 56;

		public const ushort width = 20;

		public const ushort height = 42;

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

		public bool male = true;

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

		public Rectangle aabb = new Rectangle(0, 0, 20, 42);

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

		public short sign = -1;

		public sbyte selectedItem;

		public sbyte oldSelectedItem = -1;

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

		public float ghostDir = 1f;

		public Buff[] buff = new Buff[10];

		public short heldProj = -1;

		public short breathCD;

		public short breath = 200;

		public bool socialShadow;

		public string setBonus;

		public Item[] armor = new Item[11];

		public Item[] inventory = new Item[49];

		public Chest bank = new Chest();

		public Chest safe = new Chest();

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

		public string characterName = "";

		public string name = "";

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

		public short head = -1;

		public short body = -1;

		public short legs = -1;

		private short bodyFrameY;

		private short legFrameY;

		public Vector2 controlDir = default(Vector2);

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

		public sbyte direction = 1;

		public byte whoAmI;

		public sbyte runSoundDelay;

		public bool fireWalk;

		private float buffR = 1f;

		private float buffG = 1f;

		private float buffB = 1f;

		public float shadow;

		public float manaCost = 1f;

		public Vector2[] shadowPos = new Vector2[3];

		public byte shadowCount;

		public bool channel;

		public short statDefense;

		public short statAttack;

		public short healthBarLife = 100;

		public short statLifeMax = 100;

		public short statLife = 100;

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

		public sbyte gravDir = 1;

		public byte freeAmmoChance;

		public byte stickyBreak;

		public bool lightOrb;

		public bool fairy;

		public sbyte pet = -1;

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

		public short meleeCrit = 4;

		public short rangedCrit = 4;

		public short magicCrit = 4;

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

		public short tileTargetX;

		public short tileTargetY;

		public short tileInteractX;

		public short tileInteractY;

		private float relativeTargetX;

		private float relativeTargetY;

		public bool adjWater;

		public bool oldAdjWater;

		public Adj[] adjTile = new Adj[135];

		public Color hairColor = new Color(215, 90, 55);

		public Color skinColor = new Color(255, 125, 90);

		public Color eyeColor = new Color(105, 90, 75);

		public Color shirtColor = new Color(175, 165, 140);

		public Color underShirtColor = new Color(160, 180, 215);

		public Color pantsColor = new Color(255, 230, 175);

		public Color shoeColor = new Color(160, 105, 60);

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

		public sbyte grappleItemSlot = -1;

		public short[] grappling = new short[20];

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

		public short chest = -1;

		public short chestX;

		public short chestY;

		public short fallStart;

		public ushort potionDelayTime = 3600;

		public short talkNPC = -1;

		public short npcChatBubble = -1;

		public BitArray itemsFound = new BitArray(632);

		public BitArray craftingStationsFound = new BitArray(135);

		public BitArray recipesFound = new BitArray(342);

		public BitArray recipesNew = new BitArray(342);

		private uint totalSunMoonTransitions;

		private byte hellAndBackState;

		public bool kill;

		public bool announced;

		public string oldName = "";

		private static readonly sbyte[] TARGET_SEARCH_DIR_RIGHT = new sbyte[180]
		{
			20,
			42,
			0,
			-16,
			0,
			-16,
			-16,
			32,
			0,
			-16,
			0,
			-16,
			-16,
			32,
			0,
			-16,
			0,
			-16,
			48,
			32,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16
		};

		private static readonly sbyte[] TARGET_SEARCH_DIR_LEFT = new sbyte[180]
		{
			-16,
			42,
			0,
			-16,
			0,
			-16,
			16,
			32,
			0,
			-16,
			0,
			-16,
			16,
			32,
			0,
			-16,
			0,
			-16,
			-48,
			32,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			0,
			16,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16,
			0,
			-16
		};

		private Vector2i[] smartLocation = new Vector2i[3];

		public void HealEffect(int healAmount)
		{
			CombatText.NewText(position, 20, 42, healAmount);
			if (isLocal())
			{
				NetMessage.CreateMessage2(35, whoAmI, healAmount);
				NetMessage.SendMessage();
			}
		}

		public void ManaEffect(int manaAmount)
		{
			CombatText.NewText(position, 20, 42, manaAmount);
			if (isLocal())
			{
				NetMessage.CreateMessage2(43, whoAmI, manaAmount);
				NetMessage.SendMessage();
			}
		}

		public static Player FindClosest(ref Rectangle rect)
		{
			Player player = null;
			int num = int.MaxValue;
			for (int i = 0; i < 8; i++)
			{
				Player player2 = Main.player[i];
				if (player2.active != 0 && !player2.dead)
				{
					int num2 = Math.Abs(player2.aabb.X + 10 - (rect.X + (rect.Width >> 1))) + Math.Abs(player2.aabb.Y + 21 - (rect.Y + (rect.Height >> 1)));
					if (num2 < num)
					{
						num = num2;
						player = player2;
					}
				}
			}
			if (player == null)
			{
				for (int j = 0; j < 8; j++)
				{
					player = Main.player[j];
					if (player.active != 0)
					{
						break;
					}
				}
			}
			return player;
		}

		public void toggleInv()
		{
			if (ui.inventoryMode > 0)
			{
				Main.PlaySound(11);
				ui.CloseInventory();
			}
			else if (talkNPC >= 0)
			{
				talkNPC = -1;
				ui.npcChatText = null;
				Main.PlaySound(11);
			}
			else if (sign >= 0)
			{
				sign = -1;
				ui.editSign = false;
				ui.npcChatText = null;
				Main.PlaySound(11);
			}
			else
			{
				Main.PlaySound(10);
				ui.OpenInventory();
			}
		}

		public void dropItemCheck()
		{
			if (ui.inventoryMode == 0)
			{
				noThrow = 0;
			}
			else if (noThrow > 0)
			{
				noThrow--;
			}
			if (noThrow == 0 && ((controlThrow && inventory[selectedItem].type > 0) || ((ui.inventoryMode == 0 || ui.IsButtonUntriggered(Buttons.X)) && ui.mouseItem.type > 0 && ui.mouseItem.stack > 0)))
			{
				Item item = default(Item);
				bool flag = false;
				if ((ui.inventoryMode == 0 || ui.IsButtonUntriggered(Buttons.X)) && ui.mouseItem.type > 0 && ui.mouseItem.stack > 0)
				{
					item = inventory[selectedItem];
					inventory[selectedItem] = ui.mouseItem;
					delayUseItem = true;
					controlUseItem = false;
					flag = true;
				}
				int num = Item.NewItem(aabb.X, aabb.Y, 20, 42, inventory[selectedItem].type, 1, noBroadcast: true);
				if (!flag && inventory[selectedItem].type == 8 && inventory[selectedItem].stack > 1)
				{
					inventory[selectedItem].stack--;
				}
				else
				{
					inventory[selectedItem].position = Main.item[num].position;
					Main.item[num] = inventory[selectedItem];
					inventory[selectedItem].Init();
				}
				Main.item[num].noGrabDelay = 100;
				Main.item[num].velocity.Y = -2f;
				Main.item[num].velocity.X = (float)(4 * direction) + velocity.X;
				if (ui.mouseItem.type > 0 && (ui.inventoryMode == 0 || ui.IsButtonUntriggered(Buttons.X)))
				{
					inventory[selectedItem] = item;
					ui.mouseItem.Init();
				}
				NetMessage.CreateMessage2(21, ui.myPlayer, num);
				NetMessage.SendMessage();
			}
		}

		public void AddBuff(int type, int time, bool quiet = true)
		{
			if (!quiet)
			{
				NetMessage.CreateMessage3(55, whoAmI, type, time);
				NetMessage.SendMessage();
			}
			for (int i = 0; i < 10; i++)
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
			while (true)
			{
				int num = -1;
				for (int j = 0; j < 10; j++)
				{
					if (!buff[j].IsDebuff())
					{
						num = j;
						break;
					}
				}
				if (num == -1)
				{
					break;
				}
				for (int k = num; k < 10; k++)
				{
					if (buff[k].Type == 0)
					{
						buff[k].Type = (ushort)type;
						buff[k].Time = (ushort)time;
						return;
					}
				}
				DelBuff(num);
			}
		}

		public void DelBuff(Buff.ID id)
		{
			int num = 0;
			while (true)
			{
				if (num < 10)
				{
					if ((Buff.ID)buff[num].Type == id)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			DelBuff(num);
		}

		public int DelBuff(int b)
		{
			if (buff[b].Type == 40)
			{
				pet = -1;
			}
			buff[b].Type = 0;
			buff[b].Time = 0;
			int num = b + 1;
			for (int i = 0; i < 9; i++)
			{
				if (buff[i].Time == 0 || buff[i].Type == 0)
				{
					if (i < num)
					{
						num--;
					}
					for (int j = i + 1; j < 10; j++)
					{
						buff[j - 1] = buff[j];
						buff[j].Time = 0;
						buff[j].Type = 0;
					}
				}
			}
			return num;
		}

		public bool canUseMana()
		{
			return statMana < statManaMax;
		}

		public bool canHeal()
		{
			return statLife < statLifeMax;
		}

		public void QuickMana()
		{
			if (noItems || statMana == statManaMax2)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				if (num < 48)
				{
					if (inventory[num].stack > 0 && inventory[num].type > 0 && inventory[num].healMana > 0 && (potionDelay == 0 || !inventory[num].potion))
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			Main.PlaySound(2, aabb.X, aabb.Y, inventory[num].useSound);
			if (inventory[num].potion)
			{
				potionDelay = potionDelayTime;
				AddBuff(21, potionDelay);
			}
			statLife += inventory[num].healLife;
			statMana += inventory[num].healMana;
			if (statLife > statLifeMax)
			{
				statLife = statLifeMax;
			}
			if (statMana > statManaMax2)
			{
				statMana = statManaMax2;
			}
			if (isLocal())
			{
				if (inventory[num].healLife > 0)
				{
					HealEffect(inventory[num].healLife);
				}
				if (inventory[num].healMana > 0)
				{
					ManaEffect(inventory[num].healMana);
				}
			}
			if (--inventory[num].stack <= 0)
			{
				inventory[num].Init();
			}
		}

		public void ApplyProjectileBuffPvP(int type)
		{
			switch (type)
			{
			case 2:
				if (Main.rand.Next(3) == 0)
				{
					AddBuff(24, 180, quiet: false);
				}
				break;
			case 15:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(24, 300, quiet: false);
				}
				break;
			case 19:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(24, 180, quiet: false);
				}
				break;
			case 33:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(20, 420, quiet: false);
				}
				break;
			case 34:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(24, 240, quiet: false);
				}
				break;
			case 35:
				if (Main.rand.Next(4) == 0)
				{
					AddBuff(24, 180, quiet: false);
				}
				break;
			case 54:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(20, 600, quiet: false);
				}
				break;
			case 63:
				if (Main.rand.Next(3) != 0)
				{
					AddBuff(31, 120);
				}
				break;
			case 85:
				AddBuff(24, 1200, quiet: false);
				break;
			case 95:
			case 103:
			case 104:
				AddBuff(39, 420);
				break;
			}
		}

		public void ApplyProjectileBuff(int type)
		{
			switch (type)
			{
			case 55:
				if (Main.rand.Next(3) == 0)
				{
					AddBuff(20, 600);
				}
				break;
			case 44:
				if (Main.rand.Next(3) == 0)
				{
					AddBuff(22, 900);
				}
				break;
			case 82:
				if (Main.rand.Next(3) == 0)
				{
					AddBuff(24, 420);
				}
				break;
			case 96:
			case 101:
				if (Main.rand.Next(3) == 0)
				{
					AddBuff(39, 480);
				}
				break;
			case 98:
				AddBuff(20, 600);
				break;
			}
		}

		public void ApplyWeaponBuffPvP(int type)
		{
			switch (type)
			{
			case 121:
				if (Main.rand.Next(2) == 0)
				{
					AddBuff(24, 180, quiet: false);
				}
				break;
			case 122:
				if (Main.rand.Next(10) == 0)
				{
					AddBuff(24, 180, quiet: false);
				}
				break;
			case 190:
			case 614:
				if (Main.rand.Next(4) == 0)
				{
					AddBuff(20, 420, quiet: false);
				}
				break;
			case 217:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(24, 180, quiet: false);
				}
				break;
			case 613:
				if (Main.rand.Next(5) == 0)
				{
					AddBuff(30, 600, quiet: false);
				}
				break;
			}
		}

		private unsafe void FireEffect(int particleType)
		{
			buffB *= 0.6f;
			buffG *= 0.7f;
			if (Main.rand.Next(4) == 0)
			{
				Dust* ptr = Main.dust.NewDust(aabb.X - 2, aabb.Y - 2, 24, 46, particleType, velocity.X * 0.4f, velocity.Y * 0.4f, 100, default(Color), 3.0);
				if (ptr != null)
				{
					ptr->noGravity = true;
					ptr->velocity.X *= 1.8f;
					ptr->velocity.Y *= 1.8f;
					ptr->velocity.Y -= 0.5f;
				}
			}
		}

		private void Dead()
		{
			wings = 0;
			poisoned = false;
			onFire = false;
			onFire2 = false;
			blind = false;
			gravDir = 1;
			for (int i = 0; i < 10; i++)
			{
				buff[i].Time = 0;
				buff[i].Type = 0;
			}
			if (isLocal() && !ui.editSign)
			{
				sign = -1;
			}
			if (isLocal() && sign < 0)
			{
				ui.npcChatText = null;
			}
			grappling[0] = -1;
			grappling[1] = -1;
			grappling[2] = -1;
			talkNPC = -1;
			statLife = 0;
			channel = false;
			potionDelay = 0;
			chest = -1;
			itemAnimation = 0;
			immuneAlpha += 2;
			if (immuneAlpha > 255)
			{
				immuneAlpha = 255;
			}
			headPosition += headVelocity;
			bodyPosition += bodyVelocity;
			legPosition += legVelocity;
			headRotation += headVelocity.X * 0.1f;
			bodyRotation += bodyVelocity.X * 0.1f;
			legRotation += legVelocity.X * 0.1f;
			headVelocity.Y += 0.1f;
			bodyVelocity.Y += 0.1f;
			legVelocity.Y += 0.1f;
			headVelocity.X *= 0.99f;
			bodyVelocity.X *= 0.99f;
			legVelocity.X *= 0.99f;
			if (!isLocal() || (--respawnTimer > 0 && !ui.IsButtonTriggered(Buttons.A)))
			{
				return;
			}
			ui.ClearButtonTriggers();
			if (difficulty == 2)
			{
				ghost = true;
				return;
			}
			if (ui.mouseItem.type > 0)
			{
				ui.OpenInventory();
			}
			Spawn();
		}

		public void Ghost()
		{
			hellAndBackState = 0;
			immune = false;
			immuneAlpha = 0;
			controlUp = false;
			controlLeft = false;
			controlDown = false;
			controlRight = false;
			controlJump = false;
			if (Main.hasFocus && ui.menuType == MenuType.NONE && sign < 0)
			{
				if (ui.gpState.ThumbSticks.Left.Y < -0.125f)
				{
					controlDown = true;
				}
				else if (ui.gpState.ThumbSticks.Left.Y > 0.125f)
				{
					controlUp = true;
				}
				if (ui.gpState.ThumbSticks.Left.X < -0.125f)
				{
					controlLeft = true;
				}
				else if (ui.gpState.ThumbSticks.Left.X > 0.125f)
				{
					controlRight = true;
				}
				if (ui.gpState.IsButtonDown(Buttons.A) || ui.gpState.IsButtonDown(ui.BTN_JUMP2))
				{
					controlJump = true;
				}
			}
			if (controlUp || controlJump)
			{
				if (velocity.Y > 0f)
				{
					velocity.Y *= 0.9f;
				}
				velocity.Y -= 0.1f;
				if (velocity.Y < -3f)
				{
					velocity.Y = -3f;
				}
			}
			else if (controlDown)
			{
				if (velocity.Y < 0f)
				{
					velocity.Y *= 0.9f;
				}
				velocity.Y += 0.1f;
				if (velocity.Y > 3f)
				{
					velocity.Y = 3f;
				}
			}
			else if ((double)velocity.Y < -0.1 || (double)velocity.Y > 0.1)
			{
				velocity.Y *= 0.9f;
			}
			else
			{
				velocity.Y = 0f;
			}
			if (controlLeft && !controlRight)
			{
				if (velocity.X > 0f)
				{
					velocity.X *= 0.9f;
				}
				velocity.X -= 0.1f;
				if (velocity.X < -3f)
				{
					velocity.X = -3f;
				}
			}
			else if (controlRight && !controlLeft)
			{
				if (velocity.X < 0f)
				{
					velocity.X *= 0.9f;
				}
				velocity.X += 0.1f;
				if (velocity.X > 3f)
				{
					velocity.X = 3f;
				}
			}
			else if (velocity.X < -0.1f || velocity.X > 0.1f)
			{
				velocity.X *= 0.9f;
			}
			else
			{
				velocity.X = 0f;
			}
			position.X += velocity.X;
			position.Y += velocity.Y;
			if (velocity.X < 0f)
			{
				direction = -1;
			}
			else if (velocity.X > 0f)
			{
				direction = 1;
			}
			ghostFrameCounter++;
			if (position.X < 560f)
			{
				position.X = 560f;
				velocity.X = 0f;
			}
			else if (position.X + 20f > (float)(Main.rightWorld - 544 - 32))
			{
				position.X = Main.rightWorld - 544 - 32 - 20;
				velocity.X = 0f;
			}
			if (position.Y < 560f)
			{
				position.Y = 560f;
				if ((double)velocity.Y < -0.1)
				{
					velocity.Y = -0.1f;
				}
			}
			else if (position.Y > (float)(Main.bottomWorld - 544 - 32 - 42))
			{
				position.Y = Main.bottomWorld - 544 - 32 - 42;
				velocity.Y = 0f;
			}
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
		}

		private void UpdateTileInteractionLocation()
		{
			tileInteractX = 0;
			tileInteractY = 0;
			if (ui.smartCursor)
			{
				int num = aabb.X;
				int num2 = aabb.Y;
				int num3 = 0;
				sbyte[] array = (direction > 0) ? TARGET_SEARCH_DIR_RIGHT : TARGET_SEARCH_DIR_LEFT;
				bool flag;
				do
				{
					num += array[num3++];
					num2 += array[num3++];
					flag = CanInteractWithTile(num, num2);
				}
				while (!flag && num3 < TARGET_SEARCH_DIR_RIGHT.Length);
				if (flag)
				{
					tileInteractX = (short)(num >> 4);
					tileInteractY = (short)(num2 >> 4);
				}
			}
			else if (CanInteractWithTile(tileTargetX << 4, tileTargetY << 4))
			{
				tileInteractX = tileTargetX;
				tileInteractY = tileTargetY;
			}
		}

		public bool CanInteractWithNPC()
		{
			switch (Main.tile[tileInteractX, tileInteractY].type)
			{
			case 10:
			case 11:
				return false;
			default:
				tileInteractX = 0;
				tileInteractY = 0;
				return true;
			}
		}

		public unsafe void UpdatePlayer(int i)
		{
			float num = 10f;
			float num2 = 0.4f;
			int num3 = 15;
			float num4 = 5.01f;
			if (wet)
			{
				if (merman)
				{
					num2 = 0.3f;
					num = 7f;
				}
				else
				{
					num2 = 0.2f;
					num = 5f;
					num3 = 30;
					num4 = 6.01f;
				}
			}
			float num5 = 3f;
			float num6 = 0.08f;
			float num7 = num5;
			heldProj = -1;
			float num8 = (float)Main.maxTilesX / 4200f;
			num8 *= num8;
			float num9 = (position.Y * 0.0625f - (60f + 10f * num8)) / (float)(Main.worldSurface / 6);
			if ((double)num9 < 0.25)
			{
				num9 = 0.25f;
			}
			else if (num9 > 1f)
			{
				num9 = 1f;
			}
			num2 *= num9;
			if (statManaMax2 > 0)
			{
				maxRegenDelay = (short)((int)((1f - (float)statMana / (float)statManaMax2) * 60f * 4f) + 45);
			}
			if (++shadowCount == 1)
			{
				shadowPos[2] = shadowPos[1];
			}
			else if (shadowCount == 2)
			{
				shadowPos[1] = shadowPos[0];
			}
			else
			{
				shadowCount = 0;
				shadowPos[0] = position;
			}
			if (potionDelay > 0)
			{
				potionDelay--;
			}
			if (runSoundDelay > 0)
			{
				runSoundDelay--;
			}
			if (itemAnimation == 0)
			{
				attackCD = 0;
			}
			else if (attackCD > 0)
			{
				attackCD--;
			}
			if (isLocal())
			{
				UI.current = ui;
				zoneEvil = (view.evilTiles >= 200);
				zoneHoly = (view.holyTiles >= 100);
				zoneMeteor = (view.meteorTiles >= 50);
				zoneDungeon = false;
				if (view.dungeonTiles >= 250 && position.Y > (float)Main.worldSurfacePixels)
				{
					int num10 = aabb.X >> 4;
					int num11 = aabb.Y >> 4;
					int wall = Main.tile[num10, num11].wall;
					if (wall > 0 && !Main.wallHouse[wall])
					{
						zoneDungeon = true;
					}
				}
				zoneJungle = (view.jungleTiles >= 80);
			}
			if (ghost)
			{
				Ghost();
			}
			else if (dead)
			{
				Dead();
			}
			else
			{
				if (isLocal())
				{
					controlUp = false;
					controlLeft = false;
					controlDown = false;
					controlRight = false;
					bool flag = !controlJump;
					controlJump = false;
					controlUseItem = false;
					bool flag2 = !controlUseTile;
					controlUseTile = false;
					controlThrow = false;
					controlInv = false;
					controlHook = false;
					if (Main.hasFocus && ui.menuType == MenuType.NONE)
					{
						controlInv = ((ui.inventoryMode > 0) ? ui.IsButtonTriggered(Buttons.B) : ui.IsButtonUntriggered(Buttons.Y));
						if (controlInv)
						{
							toggleInv();
						}
						if (ui.inventoryMode == 0)
						{
							if (sign < 0 && talkNPC < 0)
							{
								if (ui.gpState.ThumbSticks.Left.Y < -0.5f)
								{
									controlDown = true;
								}
								else if (ui.gpState.ThumbSticks.Left.Y > 0.5f)
								{
									controlUp = true;
								}
								if (ui.gpState.ThumbSticks.Left.X < -0.125f)
								{
									controlLeft = true;
								}
								else if (ui.gpState.ThumbSticks.Left.X > 0.125f)
								{
									controlRight = true;
								}
								if (ui.gpState.IsButtonDown(ui.BTN_GRAPPLE))
								{
									controlHook = true;
								}
								if (ui.gpState.IsButtonDown(Buttons.RightTrigger))
								{
									controlUseItem = true;
								}
								else if (itemTime == 0 && itemAnimation == 0)
								{
									if (ui.IsButtonTriggered(Buttons.LeftShoulder))
									{
										ui.hotbarItemNameTime = 210;
										if (oldSelectedItem >= 0)
										{
											selectedItem = oldSelectedItem;
											oldSelectedItem = -1;
										}
										if (--selectedItem < 0)
										{
											selectedItem += 10;
										}
										Main.PlaySound(12);
									}
									else if (ui.IsButtonTriggered(Buttons.RightShoulder))
									{
										ui.hotbarItemNameTime = 210;
										if (oldSelectedItem >= 0)
										{
											selectedItem = oldSelectedItem;
											oldSelectedItem = -1;
										}
										if (++selectedItem >= 10)
										{
											selectedItem -= 10;
										}
										Main.PlaySound(12);
									}
									else
									{
										int num12 = ui.UpdateQuickAccess();
										if (num12 >= 0)
										{
											if ((num12 > 9 || inventory[num12].potion) && oldSelectedItem < 0)
											{
												oldSelectedItem = selectedItem;
											}
											selectedItem = (sbyte)num12;
											if (num12 >= 0)
											{
												ui.hotbarItemNameTime = 210;
												ui.quickAccessDisplayTime = 120;
												if (inventory[num12].potion)
												{
													controlUseItem = true;
												}
											}
										}
										else if (oldSelectedItem >= 0 && (inventory[selectedItem].type == 0 || inventory[selectedItem].potion))
										{
											selectedItem = oldSelectedItem;
											oldSelectedItem = -1;
										}
									}
								}
								controlThrow = ui.IsButtonTriggered(Buttons.X);
								if (ui.IsJumpButtonDown())
								{
									controlJump = (!flag || ui.WasJumpButtonUp());
								}
								if (ui.gpState.IsButtonDown(Buttons.B))
								{
									controlUseTile = (!flag2 || ui.gpPrevState.IsButtonUp(Buttons.B));
								}
							}
							else if (sign != -1 || ui.npcChatText != null)
							{
								ui.UpdateNpcChat();
							}
							if (confused)
							{
								bool flag3 = controlLeft;
								controlLeft = controlRight;
								controlRight = flag3;
								flag3 = controlUp;
								controlUp = controlRight;
								controlDown = flag3;
							}
							if (chest != -1)
							{
								int num13 = aabb.X + 10 >> 4;
								int num14 = aabb.Y + 21 >> 4;
								if (num13 < chestX - 5 || num13 > chestX + 6 || num14 < chestY - 4 || num14 > chestY + 5 || Main.tile[chestX, chestY].active == 0)
								{
									Main.PlaySound(11);
									chest = -1;
								}
							}
						}
						if (delayUseItem)
						{
							delayUseItem = controlUseItem;
							controlUseItem = false;
						}
						if (itemAnimation == 0 && itemTime == 0)
						{
							dropItemCheck();
						}
					}
					if (Main.netMode >= 1)
					{
						NetPlayer netPlayer = ui.netPlayer;
						bool flag4 = false;
						if (statLife != netPlayer.statLife || statLifeMax != netPlayer.statLifeMax)
						{
							netPlayer.statLife = statLife;
							netPlayer.statLifeMax = statLifeMax;
							NetMessage.CreateMessage1(16, i);
							NetMessage.SendMessage();
							flag4 = true;
						}
						if (statMana != netPlayer.statMana || statManaMax != netPlayer.statManaMax)
						{
							netPlayer.statMana = statMana;
							netPlayer.statManaMax = statManaMax;
							NetMessage.CreateMessage1(42, i);
							NetMessage.SendMessage();
							flag4 = true;
						}
						if (controlUp != netPlayer.controlUp)
						{
							netPlayer.controlUp = controlUp;
							flag4 = true;
						}
						if (controlDown != netPlayer.controlDown)
						{
							netPlayer.controlDown = controlDown;
							flag4 = true;
						}
						if (controlLeft != netPlayer.controlLeft)
						{
							netPlayer.controlLeft = controlLeft;
							flag4 = true;
						}
						if (controlRight != netPlayer.controlRight)
						{
							netPlayer.controlRight = controlRight;
							flag4 = true;
						}
						if (controlJump != netPlayer.controlJump)
						{
							netPlayer.controlJump = controlJump;
							flag4 = true;
						}
						if (controlUseItem != netPlayer.controlUseItem)
						{
							netPlayer.controlUseItem = controlUseItem;
							flag4 = true;
						}
						if (selectedItem != netPlayer.selectedItem)
						{
							netPlayer.selectedItem = selectedItem;
							flag4 = true;
						}
						if (flag4)
						{
							NetMessage.CreateMessage1(13, i);
							NetMessage.SendMessage();
						}
					}
					if (velocity.Y == 0f)
					{
						if (!noFallDmg && wings == 0)
						{
							int num15 = (aabb.Y >> 4) - fallStart;
							int num16 = num15 * gravDir - 25;
							if (num16 > 0)
							{
								immune = false;
								Hurt(num16 * 10, 0, pvp: false, quiet: false, Lang.deathMsg(-1, 0, 0, 0));
							}
						}
						fallStart = (short)(aabb.Y >> 4);
					}
					else if (jump > 0 || rocketDelay > 0 || wet || slowFall || (double)num9 < 0.8 || tongued)
					{
						fallStart = (short)(aabb.Y >> 4);
					}
					if (ui.inventoryMode > 0)
					{
						delayUseItem = true;
					}
					tileTargetX = (short)(ui.mouseX + view.screenPosition.X >> 4);
					tileTargetY = (short)(ui.mouseY + view.screenPosition.Y >> 4);
					UpdateTileInteractionLocation();
				}
				if (immune)
				{
					if (--immuneTime <= 0)
					{
						immune = false;
					}
					immuneAlpha = (short)(immuneAlpha + immuneAlphaDirection * 50);
					if (immuneAlpha <= 50)
					{
						immuneAlphaDirection = 1;
					}
					else if (immuneAlpha >= 205)
					{
						immuneAlphaDirection = -1;
					}
				}
				else
				{
					immuneAlpha = 0;
				}
				potionDelayTime = 3600;
				statDefense = 0;
				accWatch = 0;
				accCompass = false;
				accDepthMeter = false;
				accDivingHelm = false;
				lifeRegen = 0;
				manaCost = 1f;
				meleeSpeed = 1f;
				meleeDamage = 1f;
				rangedDamage = 1f;
				magicDamage = 1f;
				moveSpeed = 1f;
				boneArmor = false;
				rocketBoots = 0;
				fireWalk = false;
				noKnockback = false;
				jumpBoost = false;
				noFallDmg = false;
				accFlipper = false;
				spawnMax = false;
				spaceGun = false;
				killGuide = false;
				lavaImmune = false;
				gills = false;
				slowFall = false;
				findTreasure = false;
				invis = false;
				nightVision = false;
				enemySpawns = false;
				thorns = false;
				waterWalk = false;
				detectCreature = false;
				gravControl = false;
				statManaMax2 = statManaMax;
				freeAmmoChance = 0;
				manaRegenBuff = false;
				meleeCrit = 4;
				rangedCrit = 4;
				magicCrit = 4;
				lightOrb = false;
				fairy = false;
				archery = false;
				poisoned = false;
				blind = false;
				onFire = false;
				onFire2 = false;
				noItems = false;
				blockRange = 0;
				pickSpeed = 1f;
				wereWolf = false;
				rulerAcc = false;
				bleed = false;
				confused = false;
				wings = 0;
				brokenArmor = false;
				silence = false;
				slow = false;
				horrified = false;
				tongued = false;
				kbGlove = false;
				starCloak = false;
				longInvince = false;
				manaFlower = false;
				short crit = inventory[selectedItem].crit;
				meleeCrit += crit;
				magicCrit += crit;
				rangedCrit += crit;
				buffR = 1f;
				buffG = 1f;
				buffB = 1f;
				int num17 = 0;
				for (int j = 0; j < 10; j++)
				{
					if (buff[j].Type <= 0 || buff[j].Time <= 0)
					{
						continue;
					}
					if (isLocal() && buff[j].Type != 28)
					{
						buff[j].Time--;
						if (!buff[j].IsDebuff() && ++num17 == 5)
						{
							ui.SetTriggerState(Trigger.Has5Buffs);
						}
					}
					switch (buff[j].Type)
					{
					case 1:
						lavaImmune = true;
						fireWalk = true;
						break;
					case 2:
						lifeRegen += 2;
						break;
					case 3:
						moveSpeed += 0.25f;
						break;
					case 4:
						gills = true;
						break;
					case 5:
						statDefense += 8;
						break;
					case 6:
						manaRegenBuff = true;
						break;
					case 7:
						magicDamage += 0.2f;
						break;
					case 8:
						slowFall = true;
						break;
					case 9:
						findTreasure = true;
						break;
					case 10:
						invis = true;
						break;
					case 11:
						Lighting.addLight(aabb.X + 10 >> 4, aabb.Y + 21 >> 4, new Vector3(0.8f, 0.95f, 1f));
						break;
					case 12:
						nightVision = true;
						break;
					case 13:
						enemySpawns = true;
						break;
					case 14:
						thorns = true;
						break;
					case 15:
						waterWalk = true;
						break;
					case 16:
						archery = true;
						break;
					case 17:
						detectCreature = true;
						break;
					case 18:
						gravControl = true;
						break;
					case 19:
					{
						lightOrb = true;
						bool flag5 = true;
						for (int k = 0; k < 512; k++)
						{
							if (Main.projectile[k].type == 18 && Main.projectile[k].active != 0 && Main.projectile[k].owner == whoAmI)
							{
								flag5 = false;
								break;
							}
						}
						if (flag5)
						{
							Projectile.NewProjectile(position.X + 10f, position.Y + 21f, 0f, 0f, 18, 0, 0f, whoAmI);
						}
						break;
					}
					case 20:
						poisoned = true;
						if (Main.rand.Next(52) == 0)
						{
							Dust* ptr2 = Main.dust.NewDust(46, ref aabb, 0.0, 0.0, 150, default(Color), 0.20000000298023224);
							if (ptr2 != null)
							{
								ptr2->noGravity = true;
								ptr2->fadeIn = 1.9f;
							}
						}
						buffR *= 0.65f;
						buffB *= 0.75f;
						break;
					case 21:
						potionDelay = buff[j].Time;
						break;
					case 22:
						blind = true;
						buffG *= 0.65f;
						buffR *= 0.7f;
						break;
					case 23:
						noItems = true;
						buffG *= 0.8f;
						buffR *= 0.65f;
						break;
					case 24:
						onFire = true;
						FireEffect(6);
						break;
					case 25:
						statDefense -= 4;
						meleeCrit += 2;
						meleeDamage += 0.1f;
						meleeSpeed += 0.1f;
						break;
					case 26:
						statDefense++;
						meleeCrit++;
						meleeDamage += 0.05f;
						meleeSpeed += 0.05f;
						magicCrit++;
						magicDamage += 0.05f;
						rangedCrit++;
						magicDamage += 0.05f;
						moveSpeed += 0.1f;
						break;
					case 27:
					{
						fairy = true;
						bool flag6 = true;
						for (int l = 0; l < 512; l++)
						{
							if (Main.projectile[l].active != 0 && Main.projectile[l].owner == whoAmI && (Main.projectile[l].type == 72 || Main.projectile[l].type == 86 || Main.projectile[l].type == 87))
							{
								flag6 = false;
								break;
							}
						}
						if (flag6)
						{
							int num18 = Main.rand.Next(3);
							switch (num18)
							{
							case 0:
								num18 = 72;
								break;
							case 1:
								num18 = 86;
								break;
							case 2:
								num18 = 87;
								break;
							}
							Projectile.NewProjectile(position.X + 10f, position.Y + 21f, 0f, 0f, num18, 0, 0f, whoAmI);
						}
						break;
					}
					case 28:
						if (wolfAcc && !merman && !Main.gameTime.dayTime && Main.gameTime.moonPhase == 0)
						{
							wereWolf = true;
							meleeCrit++;
							meleeDamage += 0.051f;
							meleeSpeed += 0.051f;
							statDefense++;
							moveSpeed += 0.05f;
						}
						else
						{
							j = DelBuff(j);
						}
						break;
					case 29:
						magicCrit += 2;
						magicDamage += 0.05f;
						statManaMax2 += 20;
						manaCost -= 0.02f;
						break;
					case 30:
						bleed = true;
						if (!dead && Main.rand.Next(32) == 0)
						{
							Dust* ptr = Main.dust.NewDust(5, ref aabb);
							if (ptr != null)
							{
								ptr->velocity.X *= 0.25f;
								ptr->velocity.Y += 0.5f;
								ptr->velocity.Y *= 0.25f;
							}
						}
						buffG *= 0.9f;
						buffB *= 0.9f;
						break;
					case 31:
						confused = true;
						break;
					case 32:
						slow = true;
						break;
					case 33:
						meleeDamage -= 0.051f;
						meleeSpeed -= 0.051f;
						statDefense -= 4;
						moveSpeed -= 0.1f;
						break;
					case 35:
						silence = true;
						break;
					case 36:
						brokenArmor = true;
						break;
					case 37:
						if (NPC.wof >= 0 && Main.npc[NPC.wof].type == 113)
						{
							horrified = true;
							buff[j].Time = 10;
						}
						else
						{
							j = DelBuff(j);
						}
						break;
					case 38:
						buff[j].Time = 10;
						tongued = true;
						break;
					case 39:
						onFire2 = true;
						FireEffect(75);
						break;
					case 40:
						if (pet >= 0)
						{
							buff[j].Time = 18000;
							SpawnPet();
						}
						else
						{
							buff[j].Time = 0;
						}
						break;
					}
				}
				if (accMerman && wet && !lavaWet)
				{
					releaseJump = true;
					wings = 0;
					merman = true;
					accFlipper = true;
					AddBuff(34, 2);
				}
				else
				{
					merman = false;
				}
				accMerman = false;
				if (wolfAcc && !merman && !wereWolf && !Main.gameTime.dayTime && Main.gameTime.moonPhase == 0)
				{
					AddBuff(28, 60);
				}
				wolfAcc = false;
				if (isLocal())
				{
					for (int m = 0; m < 10; m++)
					{
						if (buff[m].Type > 0 && buff[m].Time == 0)
						{
							m = DelBuff(m);
						}
					}
				}
				doubleJump = false;
				for (int n = 0; n < 8; n++)
				{
					statDefense += armor[n].defense;
					lifeRegen += armor[n].lifeRegen;
					switch (armor[n].type)
					{
					case 123:
					case 124:
					case 125:
						magicDamage += 0.05f;
						break;
					case 151:
					case 152:
					case 153:
						rangedDamage += 0.05f;
						break;
					case 238:
						magicDamage += 0.15f;
						break;
					case 111:
						statManaMax2 += 20;
						break;
					case 228:
					case 229:
					case 230:
						magicCrit += 3;
						statManaMax2 += 20;
						break;
					case 100:
					case 101:
					case 102:
						meleeSpeed += 0.07f;
						break;
					case 371:
						magicCrit += 9;
						statManaMax2 += 40;
						break;
					case 372:
						moveSpeed += 0.07f;
						meleeSpeed += 0.12f;
						break;
					case 373:
						rangedDamage += 0.1f;
						rangedCrit += 6;
						break;
					case 374:
						magicCrit += 3;
						meleeCrit += 3;
						rangedCrit += 3;
						break;
					case 375:
						moveSpeed += 0.1f;
						break;
					case 376:
						magicDamage += 0.15f;
						statManaMax2 += 60;
						break;
					case 377:
						meleeCrit += 5;
						meleeDamage += 0.1f;
						break;
					case 378:
						rangedDamage += 0.12f;
						rangedCrit += 7;
						break;
					case 379:
						rangedDamage += 0.05f;
						meleeDamage += 0.05f;
						magicDamage += 0.05f;
						break;
					case 380:
						magicCrit += 3;
						meleeCrit += 3;
						rangedCrit += 3;
						break;
					case 268:
						accDivingHelm = true;
						break;
					case 400:
						magicDamage += 0.11f;
						magicCrit += 11;
						statManaMax2 += 80;
						break;
					case 401:
						meleeCrit += 7;
						meleeDamage += 0.14f;
						break;
					case 402:
						rangedDamage += 0.14f;
						rangedCrit += 8;
						break;
					case 403:
						rangedDamage += 0.06f;
						meleeDamage += 0.06f;
						magicDamage += 0.06f;
						break;
					case 404:
						magicCrit += 4;
						meleeCrit += 4;
						rangedCrit += 4;
						moveSpeed += 0.05f;
						break;
					case 551:
						magicCrit += 7;
						meleeCrit += 7;
						rangedCrit += 7;
						break;
					case 552:
						rangedDamage += 0.07f;
						meleeDamage += 0.07f;
						magicDamage += 0.07f;
						moveSpeed += 0.08f;
						break;
					case 553:
						rangedDamage += 0.15f;
						rangedCrit += 8;
						break;
					case 558:
						magicDamage += 0.12f;
						magicCrit += 12;
						statManaMax2 += 100;
						break;
					case 559:
						meleeCrit += 10;
						meleeDamage += 0.1f;
						meleeSpeed += 0.1f;
						break;
					case 604:
						meleeCrit += 15;
						meleeDamage += 0.15f;
						meleeSpeed += 0.15f;
						break;
					case 607:
						meleeCrit += 5;
						meleeDamage += 0.05f;
						break;
					case 610:
						moveSpeed += 0.12f;
						meleeSpeed += 0.02f;
						break;
					case 605:
						rangedDamage += 0.15f;
						rangedCrit += 10;
						freeAmmoChance += 5;
						break;
					case 608:
						rangedDamage += 0.05f;
						rangedCrit += 10;
						freeAmmoChance += 5;
						break;
					case 611:
						rangedDamage += 0.1f;
						moveSpeed += 0.1f;
						freeAmmoChance += 10;
						break;
					case 606:
						magicDamage += 0.15f;
						magicCrit += 15;
						statManaMax2 += 120;
						break;
					case 609:
						magicDamage += 0.05f;
						magicCrit += 10;
						manaCost -= 0.1f;
						break;
					case 612:
						magicDamage += 0.1f;
						moveSpeed += 0.1f;
						statManaMax2 += 30;
						break;
					}
					switch (armor[n].prefix)
					{
					case 62:
						statDefense++;
						break;
					case 63:
						statDefense += 2;
						break;
					case 64:
						statDefense += 3;
						break;
					case 65:
						statDefense += 4;
						break;
					case 66:
						statManaMax2 += 20;
						break;
					case 67:
						meleeCrit++;
						rangedCrit++;
						magicCrit++;
						break;
					case 68:
						meleeCrit += 2;
						rangedCrit += 2;
						magicCrit += 2;
						break;
					case 69:
						meleeDamage += 0.01f;
						rangedDamage += 0.01f;
						magicDamage += 0.01f;
						break;
					case 70:
						meleeDamage += 0.02f;
						rangedDamage += 0.02f;
						magicDamage += 0.02f;
						break;
					case 71:
						meleeDamage += 0.03f;
						rangedDamage += 0.03f;
						magicDamage += 0.03f;
						break;
					case 72:
						meleeDamage += 0.04f;
						rangedDamage += 0.04f;
						magicDamage += 0.04f;
						break;
					case 73:
						moveSpeed += 0.01f;
						break;
					case 74:
						moveSpeed += 0.02f;
						break;
					case 75:
						moveSpeed += 0.03f;
						break;
					case 76:
						moveSpeed += 0.04f;
						break;
					case 77:
						meleeSpeed += 0.01f;
						break;
					case 78:
						meleeSpeed += 0.02f;
						break;
					case 79:
						meleeSpeed += 0.03f;
						break;
					case 80:
						meleeSpeed += 0.04f;
						break;
					}
				}
				head = armor[0].headSlot;
				body = armor[1].bodySlot;
				legs = armor[2].legSlot;
				for (int num19 = 3; num19 < 8; num19++)
				{
					switch (armor[num19].type)
					{
					case 15:
						if (accWatch < 1)
						{
							accWatch = 1;
						}
						break;
					case 16:
						if (accWatch < 2)
						{
							accWatch = 2;
						}
						break;
					case 17:
						accWatch = 3;
						break;
					case 18:
						accDepthMeter = true;
						break;
					case 53:
						doubleJump = true;
						break;
					case 54:
						num7 = 6f;
						break;
					case 128:
						rocketBoots = 1;
						break;
					case 156:
						noKnockback = true;
						break;
					case 158:
						noFallDmg = true;
						break;
					case 159:
						jumpBoost = true;
						break;
					case 187:
						accFlipper = true;
						break;
					case 193:
						fireWalk = true;
						break;
					case 211:
						meleeSpeed += 0.12f;
						break;
					case 212:
						moveSpeed += 0.1f;
						break;
					case 223:
						manaCost -= 0.06f;
						break;
					case 267:
						killGuide = true;
						break;
					case 285:
						moveSpeed += 0.1f;
						break;
					case 393:
						accCompass = true;
						break;
					case 394:
						accFlipper = true;
						accDivingHelm = true;
						break;
					case 395:
						accWatch = 3;
						accDepthMeter = true;
						accCompass = true;
						break;
					case 396:
						noFallDmg = true;
						fireWalk = true;
						break;
					case 397:
						noKnockback = true;
						fireWalk = true;
						break;
					case 399:
						jumpBoost = true;
						doubleJump = true;
						break;
					case 405:
						num7 = 6f;
						rocketBoots = 2;
						break;
					case 407:
						blockRange = 1;
						break;
					case 485:
						wolfAcc = true;
						break;
					case 486:
						rulerAcc = true;
						break;
					case 489:
						magicDamage += 0.15f;
						break;
					case 490:
						meleeDamage += 0.15f;
						break;
					case 491:
						rangedDamage += 0.15f;
						break;
					case 492:
						wings = 1;
						break;
					case 493:
						wings = 2;
						break;
					case 497:
						accMerman = true;
						break;
					case 532:
						starCloak = true;
						break;
					case 535:
						potionDelayTime = 2700;
						break;
					case 536:
						kbGlove = true;
						break;
					case 554:
						longInvince = true;
						break;
					case 555:
						manaFlower = true;
						manaCost -= 0.08f;
						break;
					case 576:
						if (isLocal() && Main.rand.Next(18000) == 0 && Main.curMusic != Main.Music.NUM_SONGS)
						{
							armor[num19].SetDefaults((int)Main.SONG_TO_MUSIC_BOX[(uint)Main.curMusic]);
						}
						break;
					case 562:
					case 563:
					case 564:
					case 565:
					case 566:
					case 567:
					case 568:
					case 569:
					case 570:
					case 571:
					case 572:
					case 573:
					case 574:
					case 626:
					case 627:
					case 628:
					case 629:
					case 630:
					case 631:
						if (isLocal() && Main.musicBox < 0)
						{
							if (armor[num19].type < 626)
							{
								Main.musicBox = armor[num19].type - 562;
							}
							else
							{
								Main.musicBox = armor[num19].type - 613;
							}
						}
						break;
					}
				}
				Lighting.addLight(aabb.X + 10 + (direction << 3) >> 4, aabb.Y + 2 >> 4, (head == 11) ? new Vector3(0.92f, 0.8f, 0.75f) : new Vector3(0.2f, 0.2f, 0.2f));
				setBonus = null;
				if ((head == 1 && body == 1 && legs == 1) || (head == 2 && body == 2 && legs == 2))
				{
					setBonus = Lang.setBonus(0);
					statDefense += 2;
				}
				else if ((head == 3 && body == 3 && legs == 3) || (head == 4 && body == 4 && legs == 4))
				{
					setBonus = Lang.setBonus(1);
					statDefense += 3;
				}
				else if (head == 5 && body == 5 && legs == 5)
				{
					setBonus = Lang.setBonus(2);
					moveSpeed += 0.15f;
				}
				else if (head == 6 && body == 6 && legs == 6)
				{
					setBonus = Lang.setBonus(3);
					spaceGun = true;
				}
				else if (head == 7 && body == 7 && legs == 7)
				{
					setBonus = Lang.setBonus(4);
					freeAmmoChance += 20;
				}
				else if (head == 8 && body == 8 && legs == 8)
				{
					setBonus = Lang.setBonus(5);
					manaCost -= 0.16f;
				}
				else if (head == 9 && body == 9 && legs == 9)
				{
					setBonus = Lang.setBonus(6);
					meleeDamage += 0.17f;
				}
				else if (head == 11 && body == 20 && legs == 19)
				{
					setBonus = Lang.setBonus(7);
					pickSpeed = 0.8f;
				}
				else if (body == 17 && legs == 16)
				{
					if (head == 29)
					{
						setBonus = Lang.setBonus(8);
						manaCost -= 0.14f;
					}
					else if (head == 30)
					{
						setBonus = Lang.setBonus(9);
						meleeSpeed += 0.15f;
					}
					else if (head == 31)
					{
						setBonus = Lang.setBonus(10);
						freeAmmoChance += 20;
					}
				}
				else if (body == 18 && legs == 17)
				{
					if (head == 32)
					{
						setBonus = Lang.setBonus(11);
						manaCost -= 0.17f;
					}
					else if (head == 33)
					{
						setBonus = Lang.setBonus(12);
						meleeCrit += 5;
					}
					else if (head == 34)
					{
						setBonus = Lang.setBonus(13);
						freeAmmoChance += 20;
					}
				}
				else if (body == 19 && legs == 18)
				{
					if (head == 35)
					{
						setBonus = Lang.setBonus(14);
						manaCost -= 0.19f;
					}
					else if (head == 36)
					{
						setBonus = Lang.setBonus(15);
						meleeSpeed += 0.18f;
						moveSpeed += 0.18f;
					}
					else if (head == 37)
					{
						setBonus = Lang.setBonus(16);
						freeAmmoChance += 25;
					}
				}
				else if (body == 24 && legs == 23)
				{
					if (head == 42)
					{
						setBonus = Lang.setBonus(17);
						manaCost -= 0.2f;
					}
					else if (head == 43)
					{
						setBonus = Lang.setBonus(18);
						meleeSpeed += 0.19f;
						moveSpeed += 0.19f;
					}
					else if (head == 41)
					{
						setBonus = Lang.setBonus(19);
						freeAmmoChance += 25;
					}
				}
				else if (head == 45 && body == 26 && legs == 25)
				{
					setBonus = Lang.setBonus(21);
					meleeSpeed += 0.21f;
					moveSpeed += 0.21f;
				}
				else if (head == 46 && body == 27 && legs == 26)
				{
					setBonus = Lang.setBonus(22);
					freeAmmoChance += 28;
				}
				else if (head == 47 && body == 28 && legs == 27)
				{
					setBonus = Lang.setBonus(20);
					manaCost -= 0.23f;
				}
				if (merman)
				{
					wings = 0;
				}
				if (meleeSpeed > 4f)
				{
					meleeSpeed = 4f;
				}
				if (moveSpeed > 1.4f)
				{
					moveSpeed = 1.4f;
				}
				if (slow)
				{
					moveSpeed *= 0.5f;
				}
				if (statManaMax2 > 400)
				{
					statManaMax2 = 400;
				}
				if (statDefense < 0)
				{
					statDefense = 0;
				}
				meleeSpeed = 1f / meleeSpeed;
				if (onFire || onFire2)
				{
					lifeRegenTime = 0;
					lifeRegen = -8;
				}
				else if (poisoned)
				{
					lifeRegenTime = 0;
					lifeRegen = -4;
				}
				else if (bleed)
				{
					lifeRegenTime = 0;
				}
				else
				{
					double num20 = 0.0;
					if (++lifeRegenTime >= 3600)
					{
						num20 = 9.0;
						lifeRegenTime = 3600;
					}
					else if (lifeRegenTime >= 3000)
					{
						num20 = 8.0;
					}
					else if (lifeRegenTime >= 2400)
					{
						num20 = 7.0;
					}
					else if (lifeRegenTime >= 1800)
					{
						num20 = 6.0;
					}
					else if (lifeRegenTime >= 1500)
					{
						num20 = 5.0;
					}
					else if (lifeRegenTime >= 1200)
					{
						num20 = 4.0;
					}
					else if (lifeRegenTime >= 900)
					{
						num20 = 3.0;
					}
					else if (lifeRegenTime >= 600)
					{
						num20 = 2.0;
					}
					else if (lifeRegenTime >= 300)
					{
						num20 = 1.0;
					}
					num20 = ((velocity.X != 0f && grappling[0] <= 0) ? (num20 * 0.5) : (num20 * 1.25));
					double num21 = (double)statLifeMax / 400.0 * 0.85 + 0.15;
					num20 *= num21;
					lifeRegen += (int)Math.Round(num20);
				}
				lifeRegenCount += lifeRegen;
				while (lifeRegenCount >= 120)
				{
					lifeRegenCount -= 120;
					if (statLife < statLifeMax)
					{
						statLife++;
					}
					else if (statLife > statLifeMax)
					{
						statLife = statLifeMax;
						break;
					}
				}
				while (lifeRegenCount <= -120)
				{
					lifeRegenCount += 120;
					if (--statLife <= 0 && isLocal())
					{
						if (poisoned)
						{
							KillMe(10.0, 0, pvp: false, Lang.deathMsg(-1, 0, 0, 3));
						}
						else if (onFire || onFire2)
						{
							KillMe(10.0, 0, pvp: false, Lang.deathMsg(-1, 0, 0, 4));
						}
					}
				}
				if (manaRegenDelay > 0 && !channel)
				{
					manaRegenDelay--;
					if ((velocity.X == 0f && velocity.Y == 0f) || grappling[0] >= 0 || manaRegenBuff)
					{
						manaRegenDelay--;
					}
				}
				if (manaRegenBuff && manaRegenDelay > 20)
				{
					manaRegenDelay = 20;
				}
				if (manaRegenDelay <= 0 && statManaMax2 > 0)
				{
					manaRegenDelay = 0;
					manaRegen = statManaMax2 / 7 + 1;
					if ((velocity.X == 0f && velocity.Y == 0f) || grappling[0] >= 0 || manaRegenBuff)
					{
						manaRegen += statManaMax2 >> 1;
					}
					float num22 = (float)statMana / (float)statManaMax2 * 0.8f + 0.2f;
					if (manaRegenBuff)
					{
						num22 = 1f;
					}
					manaRegen = (int)((float)manaRegen * num22);
				}
				else
				{
					manaRegen = 0;
				}
				manaRegenCount += manaRegen;
				while (manaRegenCount >= 120)
				{
					bool flag7 = false;
					manaRegenCount -= 120;
					if (statMana < statManaMax2)
					{
						statMana++;
						flag7 = true;
					}
					if (statMana < statManaMax2)
					{
						continue;
					}
					if (flag7 && isLocal())
					{
						Main.PlaySound(25);
						for (int num23 = 0; num23 < 4; num23++)
						{
							Dust* ptr3 = Main.dust.NewDust(45, ref aabb, 0.0, 0.0, 255, default(Color), (float)Main.rand.Next(20, 26) * 0.1f);
							if (ptr3 == null)
							{
								break;
							}
							ptr3->noLight = true;
							ptr3->noGravity = true;
							ptr3->velocity *= 0.5f;
						}
					}
					statMana = statManaMax2;
				}
				if (manaRegenCount < 0)
				{
					manaRegenCount = 0;
				}
				if (statMana > statManaMax2)
				{
					statMana = statManaMax2;
				}
				num6 *= moveSpeed;
				num5 *= moveSpeed;
				if (jumpBoost)
				{
					num3 = 20;
					num4 = 6.51f;
				}
				if (wereWolf)
				{
					num3 += 2;
					num4 += 0.2f;
				}
				if (brokenArmor)
				{
					statDefense >>= 1;
				}
				if (!doubleJump)
				{
					jumpAgain = false;
				}
				else if (velocity.Y == 0f)
				{
					jumpAgain = true;
				}
				if (grappling[0] == -1 && !tongued)
				{
					if (controlLeft && velocity.X > 0f - num5)
					{
						if (velocity.X > 0.2f)
						{
							velocity.X -= 0.2f;
						}
						velocity.X -= num6;
						if (itemAnimation == 0 || inventory[selectedItem].useTurn)
						{
							direction = -1;
						}
					}
					else if (controlRight && velocity.X < num5)
					{
						if (velocity.X < -0.2f)
						{
							velocity.X += 0.2f;
						}
						velocity.X += num6;
						if (itemAnimation == 0 || inventory[selectedItem].useTurn)
						{
							direction = 1;
						}
					}
					else if (controlLeft && velocity.X > 0f - num7)
					{
						if (itemAnimation == 0 || inventory[selectedItem].useTurn)
						{
							direction = -1;
						}
						if (velocity.Y == 0f || wings > 0)
						{
							if (velocity.X > 0.2f)
							{
								velocity.X -= 0.2f;
							}
							velocity.X -= num6 * 0.2f;
						}
						if (velocity.X < (0f - (num7 + num5)) * 0.5f && velocity.Y == 0f)
						{
							int num24 = 0;
							if (gravDir == -1)
							{
								num24 -= 42;
							}
							if (runSoundDelay == 0 && velocity.Y == 0f)
							{
								Main.PlaySound(17, aabb.X, aabb.Y);
								runSoundDelay = 9;
							}
							Dust* ptr4 = Main.dust.NewDust(aabb.X - 4, aabb.Y + 42 + num24, 28, 4, 16, velocity.X * -0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5);
							if (ptr4 != null)
							{
								ptr4->velocity *= 0.2f;
							}
						}
					}
					else if (controlRight && velocity.X < num7)
					{
						if (itemAnimation == 0 || inventory[selectedItem].useTurn)
						{
							direction = 1;
						}
						if (velocity.Y == 0f || wings > 0)
						{
							if (velocity.X < -0.2f)
							{
								velocity.X += 0.2f;
							}
							velocity.X += num6 * 0.2f;
						}
						if (velocity.X > (num7 + num5) * 0.5f && velocity.Y == 0f)
						{
							int num25 = 0;
							if (gravDir == -1)
							{
								num25 -= 42;
							}
							if (runSoundDelay == 0 && velocity.Y == 0f)
							{
								Main.PlaySound(17, aabb.X, aabb.Y);
								runSoundDelay = 9;
							}
							Dust* ptr5 = Main.dust.NewDust(aabb.X - 4, aabb.Y + 42 + num25, 28, 4, 16, velocity.X * -0.5f, velocity.Y * 0.5f, 50, default(Color), 1.5);
							if (ptr5 != null)
							{
								ptr5->velocity *= 0.2f;
							}
						}
					}
					else if (velocity.Y == 0f)
					{
						if (velocity.X > 0.2f)
						{
							velocity.X -= 0.2f;
						}
						else if (velocity.X < -0.2f)
						{
							velocity.X += 0.2f;
						}
						else
						{
							velocity.X = 0f;
						}
					}
					else if ((double)velocity.X > 0.10000000149011612)
					{
						velocity.X -= 0.1f;
					}
					else if ((double)velocity.X < -0.10000000149011612)
					{
						velocity.X += 0.1f;
					}
					else
					{
						velocity.X = 0f;
					}
					if (gravControl)
					{
						if ((controlUp && gravDir == 1) || (controlDown && gravDir == -1))
						{
							gravDir = (sbyte)(-gravDir);
							fallStart = (short)(aabb.Y >> 4);
							jump = 0;
							Main.PlaySound(2, aabb.X, aabb.Y, 8);
						}
					}
					else
					{
						gravDir = 1;
					}
					if (controlJump)
					{
						if (jump > 0)
						{
							if (velocity.Y == 0f)
							{
								jump = 0;
							}
							else
							{
								velocity.Y = (0f - num4) * (float)gravDir;
								if (merman)
								{
									if (swimTime <= 10)
									{
										swimTime = 30;
									}
								}
								else
								{
									jump--;
								}
							}
						}
						else if ((velocity.Y == 0f || jumpAgain || (wet && accFlipper)) && releaseJump)
						{
							bool flag8 = wet && accFlipper;
							if (flag8 && swimTime == 0)
							{
								swimTime = 30;
							}
							jumpAgain = false;
							canRocket = false;
							rocketRelease = false;
							if (velocity.Y == 0f && doubleJump)
							{
								jumpAgain = true;
							}
							if (velocity.Y == 0f || flag8)
							{
								velocity.Y = (0f - num4) * (float)gravDir;
								jump = num3;
							}
							else
							{
								int num26 = 42;
								if (gravDir == -1)
								{
									num26 = 0;
								}
								Main.PlaySound(16, aabb.X, aabb.Y);
								velocity.Y = (0f - num4) * (float)gravDir;
								jump = num3 >> 1;
								for (int num27 = 0; num27 < 8; num27++)
								{
									Dust* ptr6 = Main.dust.NewDust(aabb.X - 34, aabb.Y + num26 - 16, 102, 32, 16, velocity.X * -0.5f, velocity.Y * 0.5f, 100, default(Color), 1.5);
									if (ptr6 == null)
									{
										break;
									}
									ptr6->velocity.X = ptr6->velocity.X * 0.5f - velocity.X * 0.1f;
									ptr6->velocity.Y = ptr6->velocity.Y * 0.5f - velocity.Y * 0.3f;
								}
								int num28 = Gore.NewGore(new Vector2(position.X + 10f - 16f, position.Y + (float)num26 - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(11, 14));
								Main.gore[num28].velocity.X = Main.gore[num28].velocity.X * 0.1f - velocity.X * 0.1f;
								Main.gore[num28].velocity.Y = Main.gore[num28].velocity.Y * 0.1f - velocity.Y * 0.05f;
								num28 = Gore.NewGore(new Vector2(position.X - 36f, position.Y + (float)num26 - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(11, 14));
								Main.gore[num28].velocity.X = Main.gore[num28].velocity.X * 0.1f - velocity.X * 0.1f;
								Main.gore[num28].velocity.Y = Main.gore[num28].velocity.Y * 0.1f - velocity.Y * 0.05f;
								num28 = Gore.NewGore(new Vector2(position.X + 20f + 4f, position.Y + (float)num26 - 16f), new Vector2(0f - velocity.X, 0f - velocity.Y), Main.rand.Next(11, 14));
								Main.gore[num28].velocity.X = Main.gore[num28].velocity.X * 0.1f - velocity.X * 0.1f;
								Main.gore[num28].velocity.Y = Main.gore[num28].velocity.Y * 0.1f - velocity.Y * 0.05f;
							}
							if (ui != null)
							{
								ui.totalJumps++;
							}
						}
						releaseJump = false;
					}
					else
					{
						jump = 0;
						releaseJump = true;
						rocketRelease = true;
					}
					if (doubleJump && !jumpAgain && ((gravDir == 1 && velocity.Y < 0f) || (gravDir == -1 && velocity.Y > 0f)) && rocketBoots == 0 && !accFlipper)
					{
						int num29 = 42;
						if (gravDir == -1)
						{
							num29 = -6;
						}
						Dust* ptr7 = Main.dust.NewDust(aabb.X - 4, aabb.Y + num29, 28, 4, 16, velocity.X * -0.5f, velocity.Y * 0.5f, 100, default(Color), 1.5);
						if (ptr7 != null)
						{
							ptr7->velocity.X = ptr7->velocity.X * 0.5f - velocity.X * 0.1f;
							ptr7->velocity.Y = ptr7->velocity.Y * 0.5f - velocity.Y * 0.3f;
						}
					}
					if (((gravDir == 1 && velocity.Y > 0f - num4) || (gravDir == -1 && velocity.Y < num4)) && velocity.Y != 0f)
					{
						canRocket = true;
					}
					bool flag9 = false;
					if (velocity.Y == 0f)
					{
						wingTime = 90;
					}
					if (wings > 0 && controlJump && wingTime > 0 && !jumpAgain && jump == 0 && velocity.Y != 0f)
					{
						flag9 = true;
					}
					if (flag9)
					{
						velocity.Y -= 0.1f * (float)gravDir;
						if (gravDir == 1)
						{
							if (velocity.Y > 0f)
							{
								velocity.Y -= 0.5f;
							}
							else if ((double)velocity.Y > (double)(0f - num4) * 0.5)
							{
								velocity.Y -= 0.1f;
							}
							if (velocity.Y < (0f - num4) * 1.5f)
							{
								velocity.Y = (0f - num4) * 1.5f;
							}
						}
						else
						{
							if (velocity.Y < 0f)
							{
								velocity.Y += 0.5f;
							}
							else if ((double)velocity.Y < (double)num4 * 0.5)
							{
								velocity.Y += 0.1f;
							}
							if (velocity.Y > num4 * 1.5f)
							{
								velocity.Y = num4 * 1.5f;
							}
						}
						wingTime--;
					}
					if (flag9 || jump > 0)
					{
						if (++wingFrameCounter > 4)
						{
							wingFrameCounter = 0;
							wingFrame = (byte)((wingFrame + 1) & 3);
						}
					}
					else if (velocity.Y != 0f)
					{
						wingFrame = 1;
					}
					else
					{
						wingFrame = 0;
					}
					if (wings > 0 && rocketBoots > 0)
					{
						wingTime = (short)(wingTime + rocketTime * 10);
						rocketTime = 0;
					}
					if (flag9)
					{
						if (wingFrame == 3)
						{
							if (!flapSound)
							{
								flapSound = true;
								Main.PlaySound(2, aabb.X, aabb.Y, 32);
							}
						}
						else
						{
							flapSound = false;
						}
					}
					if (velocity.Y == 0f)
					{
						rocketTime = 7;
					}
					if ((wingTime == 0 || wings == 0) && rocketBoots > 0 && controlJump && rocketDelay == 0 && canRocket && rocketRelease && !jumpAgain)
					{
						if (rocketTime > 0)
						{
							rocketTime--;
							rocketDelay = 10;
							if (rocketDelay2 <= 0)
							{
								if (rocketBoots == 1)
								{
									Main.PlaySound(2, aabb.X, aabb.Y, 13);
									rocketDelay2 = 30;
								}
								else if (rocketBoots == 2)
								{
									Main.PlaySound(2, aabb.X, aabb.Y, 24);
									rocketDelay2 = 15;
								}
							}
						}
						else
						{
							canRocket = false;
						}
					}
					if (rocketDelay2 > 0)
					{
						rocketDelay2--;
					}
					if (rocketDelay == 0)
					{
						rocketFrame = false;
					}
					if (rocketDelay > 0)
					{
						int num30 = 42;
						if (gravDir == -1)
						{
							num30 = 4;
						}
						rocketFrame = true;
						if ((Main.frameCounter & 1) == 0)
						{
							int type = 6;
							float num31 = 2.5f;
							int alpha = 100;
							if (rocketBoots == 2)
							{
								type = 16;
								num31 = 1.5f;
								alpha = 20;
							}
							else if (socialShadow)
							{
								type = 27;
								num31 = 1.5f;
							}
							int num32 = aabb.X - 4;
							int y = aabb.Y + num30 - 10;
							for (int num33 = 0; num33 < 2; num33++)
							{
								Dust* ptr8 = Main.dust.NewDust(num32, y, 8, 8, type, 0.0, 0.0, alpha, default(Color), num31);
								if (ptr8 == null)
								{
									break;
								}
								ptr8->velocity.X = ptr8->velocity.X * 1f + 2f - velocity.X * 0.3f;
								ptr8->velocity.Y = ptr8->velocity.Y * 1f + (float)(2 * gravDir) - velocity.Y * 0.3f;
								if (rocketBoots == 1)
								{
									ptr8->noGravity = true;
								}
								else
								{
									ptr8->velocity.X *= 0.1f;
									ptr8->velocity.Y *= 0.1f;
								}
								num32 += 20;
							}
						}
						rocketDelay--;
						velocity.Y -= 0.1f * (float)gravDir;
						if (gravDir == 1)
						{
							if (velocity.Y > 0f)
							{
								velocity.Y -= 0.5f;
							}
							else if ((double)velocity.Y > (double)(0f - num4) * 0.5)
							{
								velocity.Y -= 0.1f;
							}
							if (velocity.Y < (0f - num4) * 1.5f)
							{
								velocity.Y = (0f - num4) * 1.5f;
							}
						}
						else
						{
							if (velocity.Y < 0f)
							{
								velocity.Y += 0.5f;
							}
							else if ((double)velocity.Y < (double)num4 * 0.5)
							{
								velocity.Y += 0.1f;
							}
							if (velocity.Y > num4 * 1.5f)
							{
								velocity.Y = num4 * 1.5f;
							}
						}
					}
					else if (!flag9)
					{
						if (slowFall && ((!controlDown && gravDir == 1) || (!controlUp && gravDir == -1)))
						{
							if ((controlUp && gravDir == 1) || (controlDown && gravDir == -1))
							{
								velocity.Y += num2 / 10f * (float)gravDir;
							}
							else
							{
								velocity.Y += num2 / 3f * (float)gravDir;
							}
						}
						else if (wings > 0 && controlJump && velocity.Y > 0f)
						{
							fallStart = (short)(aabb.Y >> 4);
							if (velocity.Y > 0f)
							{
								wingFrame = 2;
							}
							velocity.Y += num2 / 3f * (float)gravDir;
							if (gravDir == 1)
							{
								if (velocity.Y > num / 3f && !controlDown)
								{
									velocity.Y = num / 3f;
								}
							}
							else if (velocity.Y < (0f - num) / 3f && !controlUp)
							{
								velocity.Y = (0f - num) / 3f;
							}
						}
						else
						{
							velocity.Y += num2 * (float)gravDir;
						}
					}
					if (gravDir == 1)
					{
						if (velocity.Y > num)
						{
							velocity.Y = num;
						}
						if (slowFall && velocity.Y > num / 3f && !controlDown)
						{
							velocity.Y = num / 3f;
						}
						if (slowFall && velocity.Y > num / 5f && controlUp)
						{
							velocity.Y = num / 10f;
						}
					}
					else
					{
						if (velocity.Y < 0f - num)
						{
							velocity.Y = 0f - num;
						}
						if (slowFall && velocity.Y < (0f - num) / 3f && !controlUp)
						{
							velocity.Y = (0f - num) / 3f;
						}
						if (slowFall && velocity.Y < (0f - num) / 5f && controlDown)
						{
							velocity.Y = (0f - num) / 10f;
						}
					}
				}
				fixed (Item* ptr9 = Main.item)
				{
					Item* ptr10 = ptr9 + 199;
					for (int num34 = 199; num34 >= 0; num34--)
					{
						if (ptr10->active != 0 && ptr10->noGrabDelay == 0 && ptr10->owner == i)
						{
							if (aabb.Intersects(new Rectangle((int)ptr10->position.X, (int)ptr10->position.Y, ptr10->width, ptr10->height)))
							{
								if (isLocal() && (inventory[selectedItem].type != 0 || itemAnimation <= 0))
								{
									if (ptr10->type == 58)
									{
										Main.PlaySound(7, aabb.X, aabb.Y);
										statLife += 20;
										HealEffect(20);
										if (statLife > statLifeMax)
										{
											statLife = statLifeMax;
										}
										ptr10->Init();
										NetMessage.CreateMessage2(21, whoAmI, num34);
										NetMessage.SendMessage();
									}
									else if (ptr10->type == 184)
									{
										Main.PlaySound(7, aabb.X, aabb.Y);
										statMana += 100;
										ManaEffect(100);
										if (statMana > statManaMax2)
										{
											statMana = statManaMax2;
										}
										ptr10->Init();
										NetMessage.CreateMessage2(21, whoAmI, num34);
										NetMessage.SendMessage();
									}
									else if (GetItem(ref *ptr10))
									{
										NetMessage.CreateMessage2(21, whoAmI, num34);
										NetMessage.SendMessage();
									}
								}
							}
							else if (new Rectangle(aabb.X - 38, aabb.Y - 38, 96, 118).Intersects(new Rectangle((int)ptr10->position.X, (int)ptr10->position.Y, ptr10->width, ptr10->height)) && ItemSpace(ptr10))
							{
								ptr10->beingGrabbed = true;
								if (aabb.X + 10 > (int)ptr10->position.X + (ptr10->width >> 1))
								{
									if (ptr10->velocity.X < 4f + velocity.X)
									{
										ptr10->velocity.X += 0.45f;
									}
									if (ptr10->velocity.X < 0f)
									{
										ptr10->velocity.X += 0.337499976f;
									}
								}
								else
								{
									if (ptr10->velocity.X > -4f + velocity.X)
									{
										ptr10->velocity.X -= 0.45f;
									}
									if (ptr10->velocity.X > 0f)
									{
										ptr10->velocity.X -= 0.337499976f;
									}
								}
								if (aabb.Y + 21 > (int)ptr10->position.Y + (ptr10->height >> 1))
								{
									if (ptr10->velocity.Y < 4f)
									{
										ptr10->velocity.Y += 0.45f;
									}
									if (ptr10->velocity.Y < 0f)
									{
										ptr10->velocity.Y += 0.337499976f;
									}
								}
								else
								{
									if (ptr10->velocity.Y > -4f)
									{
										ptr10->velocity.Y -= 0.45f;
									}
									if (ptr10->velocity.Y > 0f)
									{
										ptr10->velocity.Y -= 0.337499976f;
									}
								}
							}
						}
						ptr10--;
					}
				}
				if (isLocal() && talkNPC < 0)
				{
					if (controlUseTile)
					{
						if (releaseUseTile)
						{
							releaseUseTile = false;
							controlUseTile = false;
							if (tileInteractY > 0)
							{
								InteractWithTile(tileInteractX << 4, tileInteractY << 4);
							}
							else if (npcChatBubble >= 0)
							{
								ui.npcShop = 0;
								ui.craftGuide = false;
								dropItemCheck();
								noThrow = 2;
								sign = -1;
								chest = -1;
								ui.editSign = false;
								talkNPC = npcChatBubble;
								ui.npcChatText = Main.npc[talkNPC].GetChat(this);
								Main.PlaySound(24);
								ui.ClearButtonTriggers();
							}
						}
					}
					else
					{
						releaseUseTile = true;
					}
				}
				if (tongued)
				{
					bool flag10 = false;
					if (NPC.wof >= 0)
					{
						float num35 = Main.npc[NPC.wof].position.X + (float)(Main.npc[NPC.wof].width >> 1);
						num35 += (float)(Main.npc[NPC.wof].direction * 200);
						float num36 = Main.npc[NPC.wof].position.Y + (float)(Main.npc[NPC.wof].height >> 1);
						Vector2 vector = new Vector2(position.X + 10f, position.Y + 21f);
						float num37 = num35 - vector.X;
						float num38 = num36 - vector.Y;
						float num39 = (float)Math.Sqrt(num37 * num37 + num38 * num38);
						float num40 = 11f;
						float num41 = num39;
						if (num39 > num40)
						{
							num41 = num40 / num39;
						}
						else
						{
							num41 = 1f;
							flag10 = true;
						}
						num37 *= num41;
						num38 *= num41;
						velocity.X = num37;
						velocity.Y = num38;
					}
					else
					{
						flag10 = true;
					}
					if (flag10 && isLocal())
					{
						DelBuff(Buff.ID.TONGUED);
					}
				}
				if (isLocal())
				{
					if (NPC.wof >= 0 && Main.npc[NPC.wof].active != 0)
					{
						int num42 = Main.npc[NPC.wof].aabb.X + 40;
						if (Main.npc[NPC.wof].direction > 0)
						{
							num42 -= 96;
						}
						if (aabb.X + 20 > num42 && aabb.X < num42 + 140 && horrified)
						{
							noKnockback = false;
							Hurt(50, Main.npc[NPC.wof].direction, pvp: false, quiet: false, Lang.deathMsg(-1, 113));
						}
						if (!horrified)
						{
							if (aabb.Y > (Main.maxTilesY - 250) * 16 && aabb.X > num42 - 1920 && aabb.X < num42 + 1920)
							{
								AddBuff(37, 10);
								Main.PlaySound(4, Main.npc[NPC.wof].aabb.X, Main.npc[NPC.wof].aabb.Y, 10);
							}
						}
						else if (aabb.Y < (Main.maxTilesY - 200) * 16)
						{
							AddBuff(38, 10);
						}
						else if (Main.npc[NPC.wof].direction < 0)
						{
							if (aabb.X + 10 > Main.npc[NPC.wof].aabb.X + (Main.npc[NPC.wof].width >> 1) + 40)
							{
								AddBuff(38, 10);
							}
						}
						else if (aabb.X + 10 < Main.npc[NPC.wof].aabb.X + (Main.npc[NPC.wof].width >> 1) - 40)
						{
							AddBuff(38, 10);
						}
						if (tongued)
						{
							controlHook = false;
							controlUseItem = false;
							for (int num43 = 0; num43 < 512; num43++)
							{
								if (Main.projectile[num43].active != 0 && Main.projectile[num43].owner == i && Main.projectile[num43].aiStyle == 7)
								{
									Main.projectile[num43].Kill();
								}
							}
							Vector2 vector2 = new Vector2(position.X + 10f, position.Y + 21f);
							float num44 = Main.npc[NPC.wof].position.X + (float)((int)Main.npc[NPC.wof].width / 2) - vector2.X;
							float num45 = Main.npc[NPC.wof].position.Y + (float)((int)Main.npc[NPC.wof].height / 2) - vector2.Y;
							float num46 = num44 * num44 + num45 * num45;
							if (num46 > 9000000f)
							{
								KillMe(1000.0, 0, pvp: false, Lang.deathMsg(-1, 0, 0, 5));
							}
							else if (Main.npc[NPC.wof].aabb.X < 608 || Main.npc[NPC.wof].aabb.X > (Main.maxTilesX - 38) * 16)
							{
								KillMe(1000.0, 0, pvp: false, Lang.deathMsg(-1, 0, 0, 6));
							}
						}
					}
					UpdateGrappleItemSlot();
					if (controlHook)
					{
						if (releaseHook)
						{
							releaseHook = false;
							QuickGrapple();
						}
					}
					else
					{
						releaseHook = true;
					}
					if (talkNPC >= 0 && (!new Rectangle(aabb.X + 10 - 80, aabb.Y + 21 - 64, 160, 128).Intersects(Main.npc[talkNPC].aabb) || chest != -1 || Main.npc[talkNPC].active == 0))
					{
						if (chest == -1)
						{
							Main.PlaySound(11);
						}
						talkNPC = -1;
						ui.npcChatText = null;
					}
					int num49;
					if (!immune)
					{
						for (int num47 = 0; num47 < 196; num47++)
						{
							if (Main.npc[num47].active == 0 || Main.npc[num47].friendly || Main.npc[num47].damage <= 0 || !aabb.Intersects(Main.npc[num47].aabb))
							{
								continue;
							}
							int num48 = 1;
							if (Main.npc[num47].aabb.X + (Main.npc[num47].width >> 1) < aabb.X + 10)
							{
								num48 = -1;
							}
							num49 = Main.DamageVar(Main.npc[num47].damage);
							if (isLocal() && thorns && !Main.npc[num47].dontTakeDamage)
							{
								int num50 = num49 / 3;
								Main.npc[num47].StrikeNPC(num50, 10f, num48);
								NetMessage.SendNpcHurt(num47, num50, 10.0, num48);
							}
							if (Main.npc[num47].netID == -6)
							{
								if (Main.rand.Next(4) == 0)
								{
									AddBuff(22, 900);
								}
							}
							else
							{
								switch (Main.npc[num47].type)
								{
								case 81:
								case 150:
									if (Main.rand.Next(4) == 0)
									{
										AddBuff(22, 900);
									}
									break;
								case 79:
								case 152:
									if (Main.rand.Next(4) == 0)
									{
										AddBuff(22, 900);
									}
									else if (Main.rand.Next(5) == 0)
									{
										AddBuff(35, 420);
									}
									break;
								case 23:
								case 25:
									if (Main.rand.Next(3) == 0)
									{
										AddBuff(24, 420);
									}
									break;
								case 34:
								case 83:
								case 84:
								case 158:
									if (Main.rand.Next(3) == 0)
									{
										AddBuff(23, 240);
									}
									break;
								case 151:
									if (Main.rand.Next(4) == 0)
									{
										AddBuff(22, 900);
									}
									else if (Main.rand.Next(3) == 0)
									{
										AddBuff(23, 240);
									}
									break;
								case 102:
								case 104:
									if (Main.rand.Next(8) == 0)
									{
										AddBuff(30, 2700);
									}
									break;
								case 75:
									if (Main.rand.Next(10) == 0)
									{
										AddBuff(35, 420);
									}
									else if (Main.rand.Next(8) == 0)
									{
										AddBuff(32, 900);
									}
									break;
								case 103:
									if (Main.rand.Next(5) == 0)
									{
										AddBuff(35, 420);
									}
									break;
								case 78:
								case 82:
									if (Main.rand.Next(8) == 0)
									{
										AddBuff(32, 900);
									}
									break;
								case 80:
								case 93:
								case 109:
								case 155:
									if (Main.rand.Next(12) == 0)
									{
										AddBuff(31, 420);
									}
									break;
								case 77:
									if (Main.rand.Next(6) == 0)
									{
										AddBuff(36, 18000);
									}
									break;
								case 112:
									if (Main.rand.Next(20) == 0)
									{
										AddBuff(33, 18000);
									}
									break;
								case 141:
									if (Main.rand.Next(2) == 0)
									{
										AddBuff(20, 600);
									}
									break;
								}
							}
							Hurt(num49, -num48, pvp: false, quiet: false, Lang.deathMsg(-1, Main.npc[num47].netID));
						}
					}
					num49 = Collision.HurtTiles(ref position, ref velocity, 20, 42, fireWalk);
					if (num49 != 0)
					{
						num49 = Main.DamageVar(num49);
						Hurt(num49, 0, pvp: false, quiet: false, Lang.deathMsg());
					}
				}
				if (grappling[0] >= 0)
				{
					wingFrame = 1;
					if (velocity.Y == 0f || (wet && (double)velocity.Y > -0.02 && (double)velocity.Y < 0.02))
					{
						wingFrame = 0;
					}
					wingTime = 90;
					rocketTime = 7;
					rocketDelay = 0;
					rocketFrame = false;
					canRocket = false;
					rocketRelease = false;
					fallStart = (short)(aabb.Y >> 4);
					float num51 = 0f;
					float num52 = 0f;
					for (int num53 = 0; num53 < grapCount; num53++)
					{
						num51 += Main.projectile[grappling[num53]].position.X + (float)(Main.projectile[grappling[num53]].width >> 1);
						num52 += Main.projectile[grappling[num53]].position.Y + (float)(Main.projectile[grappling[num53]].height >> 1);
					}
					num51 /= (float)(int)grapCount;
					num52 /= (float)(int)grapCount;
					Vector2 vector3 = new Vector2(position.X + 10f, position.Y + 21f);
					float num54 = num51 - vector3.X;
					float num55 = num52 - vector3.Y;
					float num56 = num54 * num54 + num55 * num55;
					if (num56 > 121f)
					{
						float num57 = 11f / (float)Math.Sqrt(num56);
						num54 *= num57;
						num55 *= num57;
					}
					velocity.X = num54;
					velocity.Y = num55;
					if (itemAnimation == 0)
					{
						if (velocity.X > 0f)
						{
							direction = 1;
						}
						else if (velocity.X < 0f)
						{
							direction = -1;
						}
					}
					if (controlJump)
					{
						if (releaseJump)
						{
							if ((velocity.Y == 0f || (wet && (double)velocity.Y > -0.02 && (double)velocity.Y < 0.02)) && !controlDown)
							{
								velocity.Y = 0f - num4;
								jump = num3 >> 1;
								releaseJump = false;
							}
							else
							{
								velocity.Y += 0.01f;
								releaseJump = false;
							}
							if (doubleJump)
							{
								jumpAgain = true;
							}
							grappling[0] = 0;
							grapCount = 0;
							for (int num58 = 0; num58 < 512; num58++)
							{
								if (Main.projectile[num58].owner == i && Main.projectile[num58].aiStyle == 7 && Main.projectile[num58].active != 0)
								{
									Main.projectile[num58].Kill();
								}
							}
						}
					}
					else
					{
						releaseJump = true;
					}
				}
				Vector2i vector2i = Collision.StickyTiles(position, velocity, 20, 42);
				if (vector2i.Y != -1 && vector2i.X != -1)
				{
					if (isLocal() && (velocity.X != 0f || velocity.Y != 0f))
					{
						stickyBreak++;
						if (stickyBreak > Main.rand.Next(20, 100))
						{
							stickyBreak = 0;
							if (WorldGen.KillTile(vector2i.X, vector2i.Y))
							{
								NetMessage.CreateMessage5(17, 0, vector2i.X, vector2i.Y, 0);
								NetMessage.SendMessage();
							}
						}
					}
					fallStart = (short)(aabb.Y >> 4);
					jump = 0;
					if (velocity.X > 1f)
					{
						velocity.X = 1f;
					}
					else if (velocity.X < -1f)
					{
						velocity.X = -1f;
					}
					if ((double)velocity.X > 0.75 || (double)velocity.X < -0.75)
					{
						velocity.X *= 0.85f;
					}
					else
					{
						velocity.X *= 0.6f;
					}
					if (velocity.Y > 1f)
					{
						velocity.Y = 1f;
					}
					else if (velocity.Y < -5f)
					{
						velocity.Y = -5f;
					}
					if (velocity.Y < 0f)
					{
						velocity.Y *= 0.96f;
					}
					else
					{
						velocity.Y *= 0.3f;
					}
				}
				else
				{
					stickyBreak = 0;
				}
				bool flag11 = Collision.DrownCollision(ref position, 20, 42, gravDir);
				if (armor[0].type == 250)
				{
					flag11 = true;
				}
				if (inventory[selectedItem].type == 186)
				{
					try
					{
						int num59 = aabb.X + 10 + 6 * direction >> 4;
						int num60 = 0;
						if (gravDir == -1)
						{
							num60 = 42;
						}
						int num61 = aabb.Y + num60 - 44 * gravDir >> 4;
						if (Main.tile[num59, num61].liquid < 128 && (Main.tile[num59, num61].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[num59, num61].type]))
						{
							flag11 = false;
						}
					}
					catch
					{
					}
				}
				flag11 ^= gills;
				if (isLocal())
				{
					if (merman)
					{
						flag11 = false;
					}
					if (flag11)
					{
						breathCD++;
						int num62 = 7;
						if (inventory[selectedItem].type == 186)
						{
							num62 *= 2;
						}
						if (accDivingHelm)
						{
							num62 *= 4;
						}
						if (breathCD >= num62)
						{
							breathCD = 0;
							breath--;
							if (breath == 0)
							{
								Main.PlaySound(23);
							}
							if (breath <= 0)
							{
								lifeRegenTime = 0;
								breath = 0;
								statLife -= 2;
								if (statLife <= 0)
								{
									statLife = 0;
									KillMe(10.0, 0, pvp: false, Lang.deathMsg(-1, 0, 0, 1));
								}
							}
						}
					}
					else
					{
						breath += 3;
						if (breath > 200)
						{
							breath = 200;
						}
						breathCD = 0;
					}
				}
				if (flag11 && Main.rand.Next(20) == 0 && !lavaWet)
				{
					int num63 = (gravDir == -1) ? (num63 = 30) : 0;
					if (inventory[selectedItem].type == 186)
					{
						Main.dust.NewDust(aabb.X + 10 * direction + 4, aabb.Y + num63 - 54 * gravDir, 12, 8, 34, 0.0, 0.0, 0, default(Color), 1.2000000476837158);
					}
					else
					{
						Main.dust.NewDust(aabb.X + 12 * direction, aabb.Y + num63 + 4 * gravDir, 12, 8, 34, 0.0, 0.0, 0, default(Color), 1.2000000476837158);
					}
				}
				int num64 = 42;
				if (waterWalk)
				{
					num64 -= 6;
				}
				bool flag12 = Collision.LavaCollision(ref position, 20, num64);
				if (flag12)
				{
					if (!lavaImmune && !immune && isLocal())
					{
						AddBuff(24, 420);
						Hurt(80, 0, pvp: false, quiet: false, Lang.deathMsg(-1, 0, 0, 2));
					}
					lavaWet = true;
				}
				if (Collision.WetCollision(ref position, 20, 42))
				{
					if (onFire && !lavaWet)
					{
						DelBuff(Buff.ID.ON_FIRE);
					}
					if (!wet)
					{
						if (wetCount == 0)
						{
							wetCount = 10;
							if (!flag12)
							{
								for (int num65 = 0; num65 < 32; num65++)
								{
									Dust* ptr11 = Main.dust.NewDust(aabb.X - 6, aabb.Y + 21 - 8, 32, 24, 33);
									if (ptr11 == null)
									{
										break;
									}
									ptr11->velocity.Y -= 4f;
									ptr11->velocity.X *= 2.5f;
									ptr11->scale = 1.3f;
									ptr11->alpha = 100;
									ptr11->noGravity = true;
								}
								Main.PlaySound(19, aabb.X, aabb.Y, 0);
							}
							else
							{
								for (int num66 = 0; num66 < 16; num66++)
								{
									Dust* ptr12 = Main.dust.NewDust(aabb.X - 6, aabb.Y + 21 - 8, 32, 24, 35);
									if (ptr12 == null)
									{
										break;
									}
									ptr12->velocity.Y -= 1.5f;
									ptr12->velocity.X *= 2.5f;
									ptr12->scale = 1.3f;
									ptr12->alpha = 100;
									ptr12->noGravity = true;
								}
								Main.PlaySound(19, aabb.X, aabb.Y);
							}
						}
						wet = true;
					}
				}
				else if (wet)
				{
					wet = false;
					if (jump > num3 / 5)
					{
						jump = num3 / 5;
					}
					if (wetCount == 0)
					{
						wetCount = 16;
						if (!lavaWet)
						{
							for (int num67 = 0; num67 < 24; num67++)
							{
								Dust* ptr13 = Main.dust.NewDust(aabb.X - 6, aabb.Y + 21, 32, 24, 33);
								if (ptr13 == null)
								{
									break;
								}
								ptr13->velocity.Y -= 4f;
								ptr13->velocity.X *= 2.5f;
								ptr13->scale = 1.3f;
								ptr13->alpha = 100;
								ptr13->noGravity = true;
							}
							Main.PlaySound(19, aabb.X, aabb.Y, 0);
						}
						else
						{
							for (int num68 = 0; num68 < 8; num68++)
							{
								Dust* ptr14 = Main.dust.NewDust(aabb.X - 6, aabb.Y + 21 - 8, 32, 24, 35);
								if (ptr14 == null)
								{
									break;
								}
								ptr14->velocity.Y -= 1.5f;
								ptr14->velocity.X *= 2.5f;
								ptr14->scale = 1.3f;
								ptr14->alpha = 100;
								ptr14->noGravity = true;
							}
							Main.PlaySound(19, aabb.X, aabb.Y);
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
				oldPosition = position;
				if (tongued)
				{
					position.X += velocity.X;
					position.Y += velocity.Y;
				}
				else if (wet && !merman)
				{
					Vector2 vector4 = velocity;
					Collision.TileCollision(ref position, ref velocity, 20, 42, controlDown);
					Vector2 vector5 = velocity;
					vector5.X *= 0.5f;
					vector5.Y *= 0.5f;
					if (velocity.X != vector4.X)
					{
						vector5.X = velocity.X;
					}
					if (velocity.Y != vector4.Y)
					{
						vector5.Y = velocity.Y;
					}
					position.X += vector5.X;
					position.Y += vector5.Y;
				}
				else
				{
					Collision.TileCollision(ref position, ref velocity, 20, 42, controlDown);
					if (waterWalk)
					{
						velocity = Collision.WaterCollision(position, velocity, 20, 42, controlDown);
					}
					position.X += velocity.X;
					position.Y += velocity.Y;
				}
				if (velocity.Y == 0f)
				{
					if (gravDir == 1 && Collision.up)
					{
						velocity.Y = 0.01f;
						if (!merman)
						{
							jump = 0;
						}
					}
					else if (gravDir == -1 && Collision.down)
					{
						velocity.Y = -0.01f;
						if (!merman)
						{
							jump = 0;
						}
					}
				}
				if (isLocal())
				{
					switch (hellAndBackState)
					{
					case 0:
					case 2:
						if (aabb.Y < Main.worldSurfacePixels)
						{
							hellAndBackState++;
						}
						break;
					case 1:
						if (aabb.Y > Main.magmaLayerPixels)
						{
							hellAndBackState++;
						}
						break;
					case 3:
						hellAndBackState++;
						ui.SetTriggerState(Trigger.WentDownAndUpWithoutDyingOrWarping);
						break;
					}
					Collision.SwitchTiles(position, 20, 42, oldPosition);
				}
				if (position.X < 560f)
				{
					position.X = 560f;
					velocity.X = 0f;
				}
				else if (position.X + 20f > (float)(Main.rightWorld - 544 - 32))
				{
					position.X = Main.rightWorld - 544 - 32 - 20;
					velocity.X = 0f;
				}
				if (ui != null)
				{
					if (aabb.Y - 42 < 560)
					{
						ui.SetTriggerState(Trigger.HighestPosition);
					}
					else if (aabb.Y + 42 > Main.bottomWorld - 544 - 32 - 42)
					{
						ui.SetTriggerState(Trigger.LowestPosition);
					}
				}
				if (position.Y < 560f)
				{
					position.Y = 560f;
					if ((double)velocity.Y < 0.11)
					{
						velocity.Y = 0.11f;
					}
				}
				else if (position.Y > (float)(Main.bottomWorld - 544 - 32 - 42))
				{
					position.Y = Main.bottomWorld - 544 - 32 - 42;
					velocity.Y = 0f;
				}
				aabb.X = (int)position.X;
				aabb.Y = (int)position.Y;
				ItemCheck(i);
				PlayerFrame();
				if (statLife > statLifeMax)
				{
					statLife = statLifeMax;
				}
				grappling[0] = -1;
				grapCount = 0;
			}
			if (!isLocal() || Main.netMode < 1)
			{
				return;
			}
			NetPlayer netPlayer2 = ui.netPlayer;
			bool flag13 = false;
			for (int num69 = 0; num69 <= 48; num69++)
			{
				if (inventory[num69].IsNotTheSameAs(ref netPlayer2.inventory[num69]))
				{
					netPlayer2.inventory[num69] = inventory[num69];
					NetMessage.CreateMessage2(5, i, num69);
					NetMessage.SendMessage();
				}
			}
			for (int num70 = 0; num70 < 11; num70++)
			{
				if (armor[num70].IsNotTheSameAs(ref netPlayer2.armor[num70]))
				{
					netPlayer2.armor[num70] = armor[num70];
					NetMessage.CreateMessage2(5, i, num70 + 49);
					NetMessage.SendMessage();
				}
			}
			if (chest != netPlayer2.chest)
			{
				netPlayer2.chest = chest;
				NetMessage.CreateMessage2(33, i, chest);
				NetMessage.SendMessage();
			}
			if (talkNPC != netPlayer2.talkNPC)
			{
				netPlayer2.talkNPC = talkNPC;
				NetMessage.CreateMessage1(40, i);
				NetMessage.SendMessage();
			}
			if (zoneEvil != netPlayer2.zoneEvil)
			{
				netPlayer2.zoneEvil = zoneEvil;
				flag13 = true;
			}
			if (zoneMeteor != netPlayer2.zoneMeteor)
			{
				netPlayer2.zoneMeteor = zoneMeteor;
				flag13 = true;
			}
			if (zoneDungeon != netPlayer2.zoneDungeon)
			{
				netPlayer2.zoneDungeon = zoneDungeon;
				flag13 = true;
			}
			if (zoneJungle != netPlayer2.zoneJungle)
			{
				netPlayer2.zoneJungle = zoneJungle;
				flag13 = true;
			}
			if (zoneHoly != netPlayer2.zoneHoly)
			{
				netPlayer2.zoneHoly = zoneHoly;
				flag13 = true;
			}
			if (flag13)
			{
				flag13 = false;
				NetMessage.CreateMessage1(36, i);
				NetMessage.SendMessage();
			}
			for (int num71 = 0; num71 < 10; num71++)
			{
				if (buff[num71].Type != netPlayer2.buff[num71].Type)
				{
					netPlayer2.buff[num71].Type = buff[num71].Type;
					flag13 = true;
				}
			}
			if (flag13)
			{
				NetMessage.CreateMessage1(50, i);
				NetMessage.SendMessage();
				NetMessage.CreateMessage1(13, i);
				NetMessage.SendMessage();
			}
			if (ui.localGamer != null)
			{
				LeaderboardInfo.SubmitStatistics(ui.Statistics, ui.localGamer);
			}
		}

		private unsafe bool CanInteractWithTile(int x, int y)
		{
			int num = x >> 4;
			int num2 = y >> 4;
			fixed (Tile* ptr = &Main.tile[num, num2])
			{
				if (ptr->active == 0)
				{
					return false;
				}
				int type = ptr->type;
				switch (type)
				{
				case 4:
				case 13:
				case 33:
				case 49:
					return !ui.smartCursor;
				case 10:
					return WorldGen.CanOpenDoor(num, num2);
				case 11:
					return WorldGen.CanCloseDoor(num, num2);
				case 21:
				case 29:
				case 97:
					if (talkNPC == -1)
					{
						int num3 = -1;
						int frameX2 = ptr->frameX;
						int frameY = ptr->frameY;
						num -= ((frameX2 / 18) & 1);
						num2 -= frameY / 18;
						switch (type)
						{
						case 29:
							num3 = -2;
							break;
						case 97:
							num3 = -3;
							break;
						}
						frameX2 = ptr->frameX;
						if (Main.netMode == 1 && num3 == -1 && (frameX2 < 72 || frameX2 > 106) && (frameX2 < 144 || frameX2 > 178))
						{
							return true;
						}
						if (num3 == -1)
						{
							bool flag = false;
							if ((frameX2 >= 72 && frameX2 <= 106) || (frameX2 >= 144 && frameX2 <= 178))
							{
								int num4 = 327;
								if (frameX2 >= 144 && frameX2 <= 178)
								{
									num4 = 329;
								}
								flag = true;
								for (int i = 0; i < 48; i++)
								{
									if (inventory[i].type == num4 && inventory[i].stack > 0)
									{
										return true;
									}
								}
							}
							if (!flag)
							{
								num3 = Chest.FindChest(num, num2);
							}
						}
						return num3 != -1;
					}
					return false;
				case 50:
					return !ui.smartCursor && ptr->frameX == 90;
				case 55:
				case 85:
					return true;
				case 79:
					return true;
				case 104:
				case 125:
					return true;
				case 128:
				{
					int frameX = ptr->frameX;
					frameX %= 100;
					frameX %= 36;
					if (frameX == 18)
					{
						frameX = ptr[-1440].frameX;
					}
					if (frameX >= 100)
					{
						return true;
					}
					return false;
				}
				case 132:
				case 136:
				case 139:
				case 144:
					return true;
				}
			}
			return false;
		}

		private bool InteractWithTile(int x, int y)
		{
			int num = x >> 4;
			int num2 = y >> 4;
			if (Main.tile[num, num2].active == 0)
			{
				return false;
			}
			int type = Main.tile[num, num2].type;
			switch (type)
			{
			case 4:
			case 13:
			case 33:
			case 49:
				WorldGen.KillTile(num, num2);
				NetMessage.CreateMessage5(17, 0, num, num2, 0);
				NetMessage.SendMessage();
				return true;
			case 10:
			{
				int num10 = WorldGen.OpenDoor(num, num2, direction);
				if (num10 != 0)
				{
					ui.totalDoorsOpened++;
					NetMessage.CreateMessage3(19, num, num2, num10);
					NetMessage.SendMessage();
					return true;
				}
				return false;
			}
			case 11:
				if (WorldGen.CloseDoor(num, num2))
				{
					ui.totalDoorsClosed++;
					NetMessage.CreateMessage2(24, num, num2);
					NetMessage.SendMessage();
					return true;
				}
				return false;
			case 21:
			case 29:
			case 97:
				if (talkNPC == -1)
				{
					int num5 = -1;
					int frameX2 = Main.tile[num, num2].frameX;
					int frameY = Main.tile[num, num2].frameY;
					num -= ((frameX2 / 18) & 1);
					num2 -= frameY / 18;
					switch (type)
					{
					case 29:
						num5 = -2;
						break;
					case 97:
						num5 = -3;
						break;
					default:
						if (frameX2 >= 216)
						{
							ui.chestText = Lang.itemName(348);
						}
						else if (frameX2 >= 180)
						{
							ui.chestText = Lang.itemName(343);
						}
						else
						{
							ui.chestText = Lang.itemName(48);
						}
						break;
					}
					frameX2 = Main.tile[num, num2].frameX;
					if (Main.netMode == 1 && num5 == -1 && (frameX2 < 72 || frameX2 > 106) && (frameX2 < 144 || frameX2 > 178))
					{
						if (num == chestX && num2 == chestY && chest != -1)
						{
							chest = -1;
							Main.PlaySound(11);
						}
						else
						{
							NetMessage.CreateMessage3(31, whoAmI, num, num2);
							NetMessage.SendMessage();
						}
						return true;
					}
					if (num5 == -1)
					{
						bool flag = false;
						if ((frameX2 >= 72 && frameX2 <= 106) || (frameX2 >= 144 && frameX2 <= 178))
						{
							int num6 = 327;
							if (frameX2 >= 144 && frameX2 <= 178)
							{
								num6 = 329;
							}
							flag = true;
							for (int i = 0; i < 48; i++)
							{
								if (inventory[i].type != num6 || inventory[i].stack <= 0)
								{
									continue;
								}
								if (num6 != 329)
								{
									inventory[i].stack--;
									if (inventory[i].stack <= 0)
									{
										inventory[i].Init();
									}
								}
								Chest.Unlock(num, num2);
								NetMessage.CreateMessage3(52, whoAmI, num, num2);
								NetMessage.SendMessage();
								return true;
							}
						}
						if (!flag)
						{
							num5 = Chest.FindChest(num, num2);
						}
					}
					if (num5 != -1)
					{
						if (num5 == chest)
						{
							chest = -1;
							Main.PlaySound(11);
						}
						else
						{
							if (num5 != chest && chest == -1)
							{
								Main.PlaySound(10);
							}
							else
							{
								Main.PlaySound(12);
							}
							chest = (short)num5;
							chestX = (short)num;
							chestY = (short)num2;
							ui.OpenInventory();
						}
						return true;
					}
				}
				return false;
			case 50:
				if (Main.tile[num, num2].frameX != 90)
				{
					return false;
				}
				goto case 4;
			case 55:
			case 85:
			{
				bool flag2 = true;
				if (sign >= 0)
				{
					int num11 = Sign.ReadSign(num, num2);
					if (num11 == sign)
					{
						sign = -1;
						ui.npcChatText = null;
						ui.editSign = false;
						Main.PlaySound(11);
						flag2 = false;
					}
				}
				if (flag2)
				{
					if (Main.netMode != 1)
					{
						talkNPC = -1;
						ui.CloseInventory();
						ui.editSign = false;
						Main.PlaySound(10);
						int num12 = Sign.ReadSign(num, num2);
						sign = (short)num12;
						ui.npcChatText = Main.sign[num12].text;
						ui.ClearButtonTriggers();
					}
					else
					{
						num -= ((Main.tile[num, num2].frameX / 18) & 1);
						num2 -= Main.tile[num, num2].frameY / 18;
						type = Main.tile[num, num2].type;
						if (type == 55 || type == 85)
						{
							NetMessage.CreateMessage3(46, whoAmI, num, num2);
							NetMessage.SendMessage();
						}
					}
				}
				return true;
			}
			case 79:
			{
				int num3 = num;
				int num4 = num2;
				num3 -= Main.tile[num, num2].frameX / 18;
				num3 = ((Main.tile[num, num2].frameX < 72) ? (num3 + 2) : (num3 + 5));
				num4 -= Main.tile[num, num2].frameY / 18;
				num4 += 2;
				if (CheckSpawn(num3, num4))
				{
					ChangeSpawn(num3, num4);
					Main.NewText(Lang.menu[57], 255, 240, 20);
					return true;
				}
				return false;
			}
			case 104:
			{
				string text = "AM";
				double num7 = Main.gameTime.time;
				if (!Main.gameTime.dayTime)
				{
					num7 += 54000.0;
				}
				num7 = num7 / 86400.0 * 24.0;
				num7 = num7 - 7.5 - 12.0;
				if (num7 < 0.0)
				{
					num7 += 24.0;
				}
				if (num7 >= 12.0)
				{
					text = "PM";
				}
				int num8 = (int)num7;
				int num9 = (int)((num7 - (double)num8) * 60.0);
				string text2 = num9.ToStringLookup();
				if (num9 < 10)
				{
					text2 = "0" + text2;
				}
				if (num8 > 12)
				{
					num8 -= 12;
				}
				if (num8 == 0)
				{
					num8 = 12;
				}
				string newText = Lang.inter[34] + num8.ToStringLookup() + ":" + text2 + " " + text;
				Main.NewText(newText, 255, 240, 20);
				return true;
			}
			case 125:
				AddBuff(29, 36000);
				Main.PlaySound(2, aabb.X, aabb.Y, 4);
				return true;
			case 128:
			{
				int frameX = Main.tile[num, num2].frameX;
				frameX %= 100;
				frameX %= 36;
				if (frameX == 18)
				{
					num--;
					frameX = Main.tile[num, num2].frameX;
				}
				if (frameX >= 100)
				{
					WorldGen.KillTile(num, num2, fail: true);
					NetMessage.CreateMessage5(17, 0, num, num2, 1);
					NetMessage.SendMessage();
					return true;
				}
				return false;
			}
			case 132:
			case 136:
			case 144:
				WorldGen.hitSwitch(num, num2);
				NetMessage.CreateMessage2(59, num, num2);
				NetMessage.SendMessage();
				return true;
			case 139:
				Main.PlaySound(28, x, y, 0);
				WorldGen.SwitchMB(num, num2);
				return true;
			default:
				return false;
			}
		}

		public void NetClone(NetPlayer clonePlayer)
		{
			clonePlayer.zoneEvil = zoneEvil;
			clonePlayer.zoneMeteor = zoneMeteor;
			clonePlayer.zoneDungeon = zoneDungeon;
			clonePlayer.zoneJungle = zoneJungle;
			clonePlayer.zoneHoly = zoneHoly;
			clonePlayer.selectedItem = selectedItem;
			clonePlayer.controlUp = controlUp;
			clonePlayer.controlDown = controlDown;
			clonePlayer.controlLeft = controlLeft;
			clonePlayer.controlRight = controlRight;
			clonePlayer.controlJump = controlJump;
			clonePlayer.controlUseItem = controlUseItem;
			clonePlayer.statLife = statLife;
			clonePlayer.statLifeMax = statLifeMax;
			clonePlayer.statMana = statMana;
			clonePlayer.statManaMax = statManaMax;
			clonePlayer.chest = chest;
			clonePlayer.talkNPC = talkNPC;
			for (int i = 0; i <= 48; i++)
			{
				clonePlayer.inventory[i] = inventory[i];
			}
			for (int j = 0; j < 11; j++)
			{
				clonePlayer.armor[j] = armor[j];
			}
			for (int k = 0; k < 10; k++)
			{
				clonePlayer.buff[k].Type = buff[k].Type;
			}
		}

		public bool SellItem(int price, int stack)
		{
			if (price <= 0)
			{
				return false;
			}
			Item[] array = new Item[48];
			for (int i = 0; i < 48; i++)
			{
				array[i] = inventory[i];
			}
			int num = price / 5;
			num *= stack;
			if (num < 1)
			{
				num = 1;
			}
			bool flag = false;
			while (num >= 1000000 && !flag)
			{
				int num2 = -1;
				for (int num3 = 43; num3 >= 0; num3--)
				{
					if (num2 == -1 && (inventory[num3].type == 0 || inventory[num3].stack == 0))
					{
						num2 = num3;
					}
					while (inventory[num3].type == 74 && inventory[num3].stack < inventory[num3].maxStack && num >= 1000000)
					{
						inventory[num3].stack++;
						num -= 1000000;
						DoCoins(num3);
						if (inventory[num3].stack == 0 && num2 == -1)
						{
							num2 = num3;
						}
					}
				}
				if (num >= 1000000)
				{
					if (num2 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num2].SetDefaults(74);
					num -= 1000000;
				}
			}
			while (num >= 10000 && !flag)
			{
				int num4 = -1;
				for (int num5 = 43; num5 >= 0; num5--)
				{
					if (num4 == -1 && (inventory[num5].type == 0 || inventory[num5].stack == 0))
					{
						num4 = num5;
					}
					while (inventory[num5].type == 73 && inventory[num5].stack < inventory[num5].maxStack && num >= 10000)
					{
						inventory[num5].stack++;
						num -= 10000;
						DoCoins(num5);
						if (inventory[num5].stack == 0 && num4 == -1)
						{
							num4 = num5;
						}
					}
				}
				if (num >= 10000)
				{
					if (num4 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num4].SetDefaults(73);
					num -= 10000;
				}
			}
			while (num >= 100 && !flag)
			{
				int num6 = -1;
				for (int num7 = 43; num7 >= 0; num7--)
				{
					if (num6 == -1 && (inventory[num7].type == 0 || inventory[num7].stack == 0))
					{
						num6 = num7;
					}
					while (inventory[num7].type == 72 && inventory[num7].stack < inventory[num7].maxStack && num >= 100)
					{
						inventory[num7].stack++;
						num -= 100;
						DoCoins(num7);
						if (inventory[num7].stack == 0 && num6 == -1)
						{
							num6 = num7;
						}
					}
				}
				if (num >= 100)
				{
					if (num6 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num6].SetDefaults(72);
					num -= 100;
				}
			}
			while (num >= 1 && !flag)
			{
				int num8 = -1;
				for (int num9 = 43; num9 >= 0; num9--)
				{
					if (num8 == -1 && (inventory[num9].type == 0 || inventory[num9].stack == 0))
					{
						num8 = num9;
					}
					while (inventory[num9].type == 71 && inventory[num9].stack < inventory[num9].maxStack && num >= 1)
					{
						inventory[num9].stack++;
						num--;
						DoCoins(num9);
						if (inventory[num9].stack == 0 && num8 == -1)
						{
							num8 = num9;
						}
					}
				}
				if (num >= 1)
				{
					if (num8 == -1)
					{
						flag = true;
						continue;
					}
					inventory[num8].SetDefaults(71);
					num--;
				}
			}
			if (flag)
			{
				for (int j = 0; j < 48; j++)
				{
					inventory[j] = array[j];
				}
				return false;
			}
			return true;
		}

		public bool BuyItem(int price)
		{
			if (price == 0)
			{
				return true;
			}
			int num = 0;
			int num2 = price;
			Item[] array = new Item[44];
			for (int i = 0; i < 44; i++)
			{
				array[i] = inventory[i];
				if (inventory[i].type == 71)
				{
					num += inventory[i].stack;
				}
				if (inventory[i].type == 72)
				{
					num += inventory[i].stack * 100;
				}
				if (inventory[i].type == 73)
				{
					num += inventory[i].stack * 10000;
				}
				if (inventory[i].type == 74)
				{
					num += inventory[i].stack * 1000000;
				}
			}
			if (num >= price)
			{
				num2 = price;
				while (num2 > 0)
				{
					if (num2 >= 1000000)
					{
						for (int j = 0; j < 44; j++)
						{
							if (inventory[j].type != 74)
							{
								continue;
							}
							while (inventory[j].stack > 0 && num2 >= 1000000)
							{
								num2 -= 1000000;
								inventory[j].stack--;
								if (inventory[j].stack == 0)
								{
									inventory[j].Init();
								}
							}
						}
					}
					if (num2 >= 10000)
					{
						for (int k = 0; k < 44; k++)
						{
							if (inventory[k].type != 73)
							{
								continue;
							}
							while (inventory[k].stack > 0 && num2 >= 10000)
							{
								num2 -= 10000;
								inventory[k].stack--;
								if (inventory[k].stack == 0)
								{
									inventory[k].Init();
								}
							}
						}
					}
					if (num2 >= 100)
					{
						for (int l = 0; l < 44; l++)
						{
							if (inventory[l].type != 72)
							{
								continue;
							}
							while (inventory[l].stack > 0 && num2 >= 100)
							{
								num2 -= 100;
								inventory[l].stack--;
								if (inventory[l].stack == 0)
								{
									inventory[l].Init();
								}
							}
						}
					}
					if (num2 >= 1)
					{
						for (int m = 0; m < 44; m++)
						{
							if (inventory[m].type != 71)
							{
								continue;
							}
							while (inventory[m].stack > 0 && num2 >= 1)
							{
								num2--;
								inventory[m].stack--;
								if (inventory[m].stack == 0)
								{
									inventory[m].Init();
								}
							}
						}
					}
					if (num2 <= 0)
					{
						continue;
					}
					int num3 = -1;
					for (int num4 = 43; num4 >= 0; num4--)
					{
						if (inventory[num4].type == 0 || inventory[num4].stack == 0)
						{
							num3 = num4;
							break;
						}
					}
					if (num3 >= 0)
					{
						bool flag = true;
						if (num2 >= 10000)
						{
							for (int n = 0; n < 48; n++)
							{
								if (inventory[n].type == 74 && inventory[n].stack >= 1)
								{
									inventory[n].stack--;
									if (inventory[n].stack == 0)
									{
										inventory[n].Init();
									}
									inventory[num3].SetDefaults(73, 100);
									flag = false;
									break;
								}
							}
						}
						else if (num2 >= 100)
						{
							for (int num5 = 0; num5 < 44; num5++)
							{
								if (inventory[num5].type == 73 && inventory[num5].stack >= 1)
								{
									inventory[num5].stack--;
									if (inventory[num5].stack == 0)
									{
										inventory[num5].Init();
									}
									inventory[num3].SetDefaults(72, 100);
									flag = false;
									break;
								}
							}
						}
						else if (num2 >= 1)
						{
							for (int num6 = 0; num6 < 44; num6++)
							{
								if (inventory[num6].type == 72 && inventory[num6].stack >= 1)
								{
									inventory[num6].stack--;
									if (inventory[num6].stack == 0)
									{
										inventory[num6].Init();
									}
									inventory[num3].SetDefaults(71, 100);
									flag = false;
									break;
								}
							}
						}
						if (!flag)
						{
							continue;
						}
						if (num2 < 10000)
						{
							for (int num7 = 0; num7 < 44; num7++)
							{
								if (inventory[num7].type == 73 && inventory[num7].stack >= 1)
								{
									inventory[num7].stack--;
									if (inventory[num7].stack == 0)
									{
										inventory[num7].Init();
									}
									inventory[num3].SetDefaults(72, 100);
									flag = false;
									break;
								}
							}
						}
						if (!flag || num2 >= 1000000)
						{
							continue;
						}
						for (int num8 = 0; num8 < 44; num8++)
						{
							if (inventory[num8].type == 74 && inventory[num8].stack >= 1)
							{
								inventory[num8].stack--;
								if (inventory[num8].stack == 0)
								{
									inventory[num8].Init();
								}
								inventory[num3].SetDefaults(73, 100);
								flag = false;
								break;
							}
						}
						continue;
					}
					for (int num9 = 0; num9 < 44; num9++)
					{
						inventory[num9] = array[num9];
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public void AdjTiles()
		{
			for (int i = 0; i < 135; i++)
			{
				adjTile[i].old = adjTile[i].i;
				adjTile[i].i = false;
			}
			oldAdjWater = adjWater;
			adjWater = false;
			int num = aabb.X + 10 >> 4;
			int num2 = aabb.Y + 42 >> 4;
			for (int j = num - 4; j <= num + 4; j++)
			{
				for (int k = num2 - 3; k < num2 + 3; k++)
				{
					if (Main.tile[j, k].active != 0)
					{
						int type = Main.tile[j, k].type;
						if (type < 135)
						{
							adjTile[type].i = true;
							FoundCraftingStation(type);
							switch (type)
							{
							case 77:
								adjTile[17].i = true;
								craftingStationsFound.Set(17, value: true);
								break;
							case 133:
								adjTile[17].i = true;
								adjTile[77].i = true;
								craftingStationsFound.Set(17, value: true);
								craftingStationsFound.Set(77, value: true);
								break;
							case 134:
								adjTile[16].i = true;
								craftingStationsFound.Set(16, value: true);
								break;
							}
						}
					}
					if (Main.tile[j, k].liquid > 200 && Main.tile[j, k].lava == 0)
					{
						adjWater = true;
					}
				}
			}
		}

		public unsafe void PlayerFrame()
		{
			if (swimTime > 0)
			{
				if (!wet)
				{
					swimTime = 0;
				}
				else
				{
					swimTime--;
				}
			}
			head = armor[0].headSlot;
			body = armor[1].bodySlot;
			legs = armor[2].legSlot;
			if (merman)
			{
				head = 39;
				legs = 21;
				body = 22;
			}
			else if (wereWolf)
			{
				legs = 20;
				body = 21;
				head = 38;
			}
			else
			{
				int num = 0;
				if (armor[8].headSlot >= 0)
				{
					head = armor[8].headSlot;
					num++;
				}
				if (armor[9].bodySlot >= 0)
				{
					body = armor[9].bodySlot;
					num++;
				}
				if (armor[10].legSlot >= 0)
				{
					legs = armor[10].legSlot;
					num++;
				}
				if (num == 3 && ui != null)
				{
					ui.SetTriggerState(Trigger.AllVanitySlotsEquipped);
				}
			}
			if (head == 5 && body == 5 && legs == 5)
			{
				if (Main.rand.Next(16) == 0)
				{
					Main.dust.NewDust(14, ref aabb, 0.0, 0.0, 200, default(Color), 1.2000000476837158);
				}
				socialShadow = true;
			}
			else
			{
				socialShadow = false;
				if (head == 6 && body == 6 && legs == 6)
				{
					if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 1f && !rocketFrame)
					{
						for (int i = 0; i < 2; i++)
						{
							Dust* ptr = Main.dust.NewDust((int)(position.X - velocity.X * 2f), (int)(position.Y - velocity.Y * 2f) - 2, 20, 42, 6, 0.0, 0.0, 100, default(Color), 2.0);
							if (ptr == null)
							{
								break;
							}
							ptr->noGravity = true;
							ptr->noLight = true;
							ptr->velocity.X -= velocity.X * 0.5f;
							ptr->velocity.Y -= velocity.Y * 0.5f;
						}
					}
				}
				else if (head == 7 && body == 7 && legs == 7)
				{
					boneArmor = true;
				}
				else if (head == 8 && body == 8 && legs == 8)
				{
					if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 1f)
					{
						Dust* ptr2 = Main.dust.NewDust((int)(position.X - velocity.X * 2f), (int)(position.Y - velocity.Y * 2f) - 2, 20, 42, 40, 0.0, 0.0, 50, default(Color), 1.3999999761581421);
						if (ptr2 != null)
						{
							ptr2->noGravity = true;
							ptr2->velocity *= 0.25f;
						}
					}
				}
				else if (head == 9 && body == 9 && legs == 9)
				{
					if (Math.Abs(velocity.X) + Math.Abs(velocity.Y) > 1f && !rocketFrame)
					{
						for (int j = 0; j < 2; j++)
						{
							Dust* ptr3 = Main.dust.NewDust((int)(position.X - velocity.X * 2f), (int)(position.Y - velocity.Y * 2f) - 2, 20, 42, 6, 0.0, 0.0, 100, default(Color), 2.0);
							if (ptr3 == null)
							{
								break;
							}
							ptr3->noGravity = true;
							ptr3->noLight = true;
							ptr3->velocity.X -= velocity.X * 0.5f;
							ptr3->velocity.Y -= velocity.Y * 0.5f;
						}
					}
				}
				else if (body == 18 && legs == 17)
				{
					if ((head == 32 || head == 33 || head == 34) && Main.rand.Next(16) == 0)
					{
						Dust* ptr4 = Main.dust.NewDust((int)(position.X - velocity.X * 2f), (int)(position.Y - velocity.Y * 2f) - 2, 20, 42, 43, 0.0, 0.0, 100, default(Color), 0.30000001192092896);
						if (ptr4 != null)
						{
							ptr4->fadeIn = 0.8f;
							ptr4->velocity.X = 0f;
							ptr4->velocity.Y = 0f;
						}
					}
				}
				else if (body == 24 && legs == 23 && (head == 42 || head == 43 || head == 41) && (velocity.X != 0f || velocity.Y != 0f) && Main.rand.Next(16) == 0)
				{
					Dust* ptr5 = Main.dust.NewDust((int)(position.X - velocity.X * 2f), (int)(position.Y - velocity.Y * 2f) - 2, 20, 42, 43, 0.0, 0.0, 100, default(Color), 0.30000001192092896);
					if (ptr5 != null)
					{
						ptr5->fadeIn = 0.8f;
						ptr5->velocity.X = 0f;
						ptr5->velocity.Y = 0f;
					}
				}
			}
			if (itemAnimation > 0 && inventory[selectedItem].useStyle != 10)
			{
				if (inventory[selectedItem].useStyle == 1 || inventory[selectedItem].type == 0)
				{
					if (itemAnimation < itemAnimationMax / 3)
					{
						bodyFrameY = 168;
					}
					else if (itemAnimation < (itemAnimationMax << 1) / 3)
					{
						bodyFrameY = 112;
					}
					else
					{
						bodyFrameY = 56;
					}
				}
				else if (inventory[selectedItem].useStyle == 2)
				{
					if (itemAnimation > itemAnimationMax >> 1)
					{
						bodyFrameY = 168;
					}
					else
					{
						bodyFrameY = 112;
					}
				}
				else if (inventory[selectedItem].useStyle == 3)
				{
					if (itemAnimation > (itemAnimationMax << 1) / 3)
					{
						bodyFrameY = 168;
					}
					else
					{
						bodyFrameY = 168;
					}
				}
				else if (inventory[selectedItem].useStyle == 4)
				{
					bodyFrameY = 112;
				}
				else if (inventory[selectedItem].useStyle == 5)
				{
					if (inventory[selectedItem].type == 281)
					{
						bodyFrameY = 112;
					}
					else
					{
						float num2 = itemRotation * (float)direction;
						bodyFrameY = 168;
						if ((double)num2 < -0.75)
						{
							bodyFrameY = 112;
							if (gravDir == -1)
							{
								bodyFrameY = 224;
							}
						}
						if ((double)num2 > 0.6)
						{
							bodyFrameY = 224;
							if (gravDir == -1)
							{
								bodyFrameY = 112;
							}
						}
					}
				}
			}
			else if (inventory[selectedItem].holdStyle == 1 && (!wet || !inventory[selectedItem].noWet))
			{
				bodyFrameY = 168;
			}
			else if (inventory[selectedItem].holdStyle == 2 && (!wet || !inventory[selectedItem].noWet))
			{
				bodyFrameY = 112;
			}
			else if (inventory[selectedItem].holdStyle == 3)
			{
				bodyFrameY = 168;
			}
			else if (grappling[0] >= 0)
			{
				Vector2 vector = new Vector2(position.X + 10f, position.Y + 21f);
				float num3 = 0f;
				float num4 = 0f;
				for (int k = 0; k < grapCount; k++)
				{
					num3 += Main.projectile[grappling[k]].position.X + (float)(Main.projectile[grappling[k]].width >> 1);
					num4 += Main.projectile[grappling[k]].position.Y + (float)(Main.projectile[grappling[k]].height >> 1);
				}
				num3 /= (float)(int)grapCount;
				num4 /= (float)(int)grapCount;
				num3 -= vector.X;
				num4 -= vector.Y;
				if (num4 < 0f && Math.Abs(num4) > Math.Abs(num3))
				{
					bodyFrameY = 112;
					if (gravDir == -1)
					{
						bodyFrameY = 224;
					}
				}
				else if (num4 > 0f && Math.Abs(num4) > Math.Abs(num3))
				{
					bodyFrameY = 224;
					if (gravDir == -1)
					{
						bodyFrameY = 112;
					}
				}
				else
				{
					bodyFrameY = 168;
				}
			}
			else if (swimTime > 0)
			{
				if (swimTime > 20)
				{
					bodyFrameY = 0;
				}
				else if (swimTime > 10)
				{
					bodyFrameY = 280;
				}
				else
				{
					bodyFrameY = 0;
				}
			}
			else if (velocity.Y != 0f)
			{
				if (wings > 0)
				{
					if (velocity.Y > 0f)
					{
						if (controlJump)
						{
							bodyFrameY = 336;
						}
						else
						{
							bodyFrameY = 280;
						}
					}
					else
					{
						bodyFrameY = 336;
					}
				}
				else
				{
					bodyFrameY = 280;
				}
				bodyFrameCounter = 0f;
			}
			else if (velocity.X != 0f)
			{
				bodyFrameCounter += Math.Abs(velocity.X) * 1.5f;
				bodyFrameY = legFrameY;
			}
			else
			{
				bodyFrameCounter = 0f;
				bodyFrameY = 0;
			}
			if (swimTime > 0)
			{
				legFrameCounter += 2f;
				while (legFrameCounter > 8f)
				{
					legFrameCounter -= 8f;
					legFrameY += 56;
				}
				if (legFrameY < 392)
				{
					legFrameY = 1064;
				}
				else if (legFrameY > 1064)
				{
					legFrameY = 392;
				}
				ResetAirTime();
			}
			else if (velocity.Y != 0f || grappling[0] >= 0)
			{
				IncreaseAirTime();
				legFrameCounter = 0f;
				legFrameY = 280;
			}
			else if (velocity.X != 0f)
			{
				legFrameCounter += Math.Abs(velocity.X) * 1.3f;
				int num5 = (int)legFrameCounter >> 3;
				if (num5 > 0)
				{
					legFrameCounter -= num5 << 3;
					legFrameY = (short)(legFrameY + 56 * num5);
					if (legFrameY == 560 || legFrameY == 784 || legFrameY == 1008)
					{
						IncreaseSteps();
					}
				}
				if (legFrameY < 392)
				{
					legFrameY = 1064;
				}
				else if (legFrameY > 1064)
				{
					legFrameY = 392;
				}
				ResetAirTime();
			}
			else
			{
				legFrameCounter = 0f;
				legFrameY = 0;
				ResetAirTime();
			}
		}

		public void Init()
		{
			velocity = default(Vector2);
			headPosition = default(Vector2);
			bodyPosition = default(Vector2);
			legPosition = default(Vector2);
			headRotation = 0f;
			bodyRotation = 0f;
			legRotation = 0f;
			immune = true;
			immuneTime = 0;
			dead = false;
			wet = false;
			wetCount = 0;
			lavaWet = false;
			talkNPC = -1;
		}

		public void Spawn()
		{
			Init();
			if (isLocal())
			{
				view.quickBG = 10;
				FindSpawn();
				if (!CheckSpawn(SpawnX, SpawnY))
				{
					SpawnX = -1;
					SpawnY = -1;
				}
				NetMessage.CreateMessage1(12, whoAmI);
				NetMessage.SendMessage();
			}
			if (SpawnX >= 0 && SpawnY >= 0)
			{
				position.X = SpawnX * 16 + 8 - 10;
				position.Y = SpawnY * 16 - 42;
			}
			else
			{
				position.X = Main.spawnTileX * 16 + 8 - 10;
				position.Y = Main.spawnTileY * 16 - 42;
				for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; i++)
				{
					for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
					{
						if (Main.tileSolidNotSolidTop[Main.tile[i, j].type])
						{
							WorldGen.KillTile(i, j);
						}
						if (Main.tile[i, j].liquid > 0)
						{
							Main.tile[i, j].lava = 0;
							Main.tile[i, j].liquid = 0;
							WorldGen.SquareTileFrame(i, j);
						}
					}
				}
			}
			shadowPos[0] = position;
			shadowPos[1] = position;
			shadowPos[2] = position;
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
			fallStart = (short)(aabb.Y >> 4);
			if (statLife <= 0)
			{
				breath = 200;
				if (spawnMax)
				{
					statLife = statLifeMax;
					statMana = statManaMax2;
				}
				else
				{
					statLife = 100;
				}
				healthBarLife = statLife;
			}
			if (pvpDeath)
			{
				pvpDeath = false;
				immuneTime = 300;
				healthBarLife = (statLife = statLifeMax);
			}
			else
			{
				immuneTime = 60;
			}
			if (isLocal())
			{
				hellAndBackState = 0;
				ui.worldFade = -0.25f;
				ui.worldFadeTarget = 1f;
				view.lighting.scrX = -1;
				updateScreenPosition();
				UpdateMouse();
				UpdatePlayer(whoAmI);
			}
			active = 1;
		}

		public unsafe double Hurt(int Damage, int hitDirection, bool pvp, bool quiet, uint deathText, bool Crit = false)
		{
			if (!immune)
			{
				int num = Damage;
				if (pvp)
				{
					num <<= 1;
				}
				double num2 = Main.CalculateDamage(num, statDefense);
				if (Crit)
				{
					num <<= 1;
				}
				if (num2 >= 1.0)
				{
					if (isLocal() && !quiet)
					{
						NetMessage.CreateMessage1(13, whoAmI);
						NetMessage.SendMessage();
						NetMessage.CreateMessage1(16, whoAmI);
						NetMessage.SendMessage();
						NetMessage.SendPlayerHurt(whoAmI, hitDirection, Damage, pvp, critical: false, deathText);
					}
					CombatText.NewText(position, 20, 42, (int)num2, Crit);
					statLife -= (short)num2;
					immune = true;
					immuneTime = 40;
					if (longInvince)
					{
						immuneTime += 40;
					}
					lifeRegenTime = 0;
					if (pvp)
					{
						immuneTime = 8;
					}
					if (isLocal() && starCloak)
					{
						for (int i = 0; i < 3; i++)
						{
							float num3 = position.X + (float)Main.rand.Next(-400, 400);
							float num4 = position.Y - (float)Main.rand.Next(500, 800);
							float num5 = position.X + 10f - num3;
							float num6 = position.Y + 21f - num4;
							num5 += (float)Main.rand.Next(-100, 101);
							float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
							num7 = 23f / num7;
							num5 *= num7;
							num6 *= num7;
							int num8 = Projectile.NewProjectile(num3, num4, num5, num6, 92, 30, 5f, whoAmI);
							if (num8 < 0)
							{
								break;
							}
							Main.projectile[num8].ai1 = aabb.Y;
						}
					}
					if (!noKnockback && hitDirection != 0)
					{
						velocity.X = 4.5f * (float)hitDirection;
						velocity.Y = -3.5f;
					}
					if (wereWolf)
					{
						Main.PlaySound(3, aabb.X, aabb.Y, 6);
					}
					else if (boneArmor)
					{
						Main.PlaySound(3, aabb.X, aabb.Y, 2);
					}
					else
					{
						Main.PlaySound(male ? 1 : 20, aabb.X, aabb.Y);
					}
					if (statLife > 0)
					{
						for (int num9 = (int)(num2 / (double)statLifeMax * 80.0); num9 > 0; num9--)
						{
							Main.dust.NewDust(boneArmor ? 26 : 5, ref aabb, 2 * hitDirection, -2.0);
						}
					}
					else if (Main.IsTutorial())
					{
						statLife = 1;
					}
					else
					{
						statLife = 0;
						if (isLocal())
						{
							KillMe(num2, hitDirection, pvp, deathText);
						}
					}
				}
				if (pvp)
				{
					num2 = Main.CalculateDamage(num, statDefense);
				}
				return num2;
			}
			return 0.0;
		}

		public void KillMeForGood()
		{
			ui.ErasePlayer(ui.selectedPlayer);
			ui.playerPathName = null;
		}

		public unsafe void KillMe(double dmg, int hitDirection, bool pvp, uint deathText)
		{
			if (dead)
			{
				return;
			}
			if (pvp)
			{
				pvpDeath = true;
			}
			if (Main.netMode != 1)
			{
				float num;
				for (num = (float)Main.rand.Next(-35, 36) * 0.1f; num < 2f && num > -2f; num += (float)Main.rand.Next(-30, 31) * 0.1f)
				{
				}
				int num2 = Projectile.NewProjectile(position.X + 10f, position.Y + (float)(head >> 1), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num, (float)Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0f, whoAmI);
				if (num2 >= 0)
				{
					uint num3 = Projectile.tombstoneTextIndex++ & 7;
					Projectile.tombstoneText[num3] = name + Lang.deathMsgString(deathText);
					Main.projectile[num2].tombstoneTextId = (byte)num3;
				}
			}
			if (difficulty != 0 && isLocal())
			{
				ui.trashItem.Init();
				DropItems();
				if (difficulty == 2)
				{
					KillMeForGood();
				}
			}
			Main.PlaySound(5, aabb.X, aabb.Y);
			headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
			headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
			for (int i = 0; (double)i < 16.0 + dmg / (double)statLifeMax * 100.0; i++)
			{
				Main.dust.NewDust(boneArmor ? 26 : 5, ref aabb, hitDirection << 1, -2.0);
			}
			dead = true;
			respawnTimer = 420;
			immuneAlpha = 0;
			if (Main.netMode != 1)
			{
				NetMessage.SendDeathText(name, deathText, 225, 25, 25);
			}
			if (isLocal())
			{
				NetMessage.CreateMessage5(44, whoAmI, hitDirection, (int)dmg, pvp ? 1 : 0, (int)deathText);
				NetMessage.SendMessage();
				if (!pvp && difficulty == 0)
				{
					DropCoins();
				}
			}
		}

		public unsafe bool ItemSpace(Item* pNewItem)
		{
			int type = pNewItem->type;
			if (type == 58 || type == 184)
			{
				return true;
			}
			int num = 40;
			if (type == 71 || type == 72 || type == 73 || type == 74)
			{
				num = 44;
			}
			for (int i = 0; i < num; i++)
			{
				if (inventory[i].type == 0)
				{
					return true;
				}
				if (inventory[i].stack < inventory[i].maxStack && pNewItem->netID == inventory[i].netID)
				{
					return true;
				}
			}
			if (pNewItem->CanBePlacedInAmmoSlot())
			{
				for (int j = 44; j < 48; j++)
				{
					if (inventory[j].type == 0 && pNewItem->CanBeAutoPlacedInEmptyAmmoSlot())
					{
						return true;
					}
					if (inventory[j].stack < inventory[j].maxStack && pNewItem->netID == inventory[j].netID)
					{
						return true;
					}
				}
			}
			else
			{
				if (pNewItem->accessory)
				{
					for (int k = 3; k < 8; k++)
					{
						if (armor[k].netID == pNewItem->netID)
						{
							return false;
						}
					}
					for (int l = 3; l < 8; l++)
					{
						if (armor[l].type == 0)
						{
							return true;
						}
					}
					return false;
				}
				if (pNewItem->headSlot >= 0)
				{
					if (armor[0].type != 0)
					{
						return armor[8].type == 0;
					}
					return true;
				}
				if (pNewItem->bodySlot >= 0)
				{
					if (armor[1].type != 0)
					{
						return armor[9].type == 0;
					}
					return true;
				}
				if (pNewItem->legSlot >= 0)
				{
					if (armor[2].type != 0)
					{
						return armor[10].type == 0;
					}
					return true;
				}
			}
			return false;
		}

		public void DoCoins(int i)
		{
			if (inventory[i].stack != 100 || (inventory[i].type != 71 && inventory[i].type != 72 && inventory[i].type != 73))
			{
				return;
			}
			inventory[i].SetDefaults(inventory[i].type + 1);
			for (int j = 0; j < 44; j++)
			{
				if (inventory[j].netID == inventory[i].netID && j != i && inventory[j].stack < inventory[j].maxStack)
				{
					inventory[j].stack++;
					inventory[i].Init();
					DoCoins(j);
				}
			}
		}

		public bool AutoEquip(ref Item item)
		{
			int num = -1;
			bool flag = item.vanity;
			lock (this)
			{
				do
				{
					if (item.accessory)
					{
						for (int i = 3; i < 8; i++)
						{
							if (armor[i].netID == item.netID)
							{
								return false;
							}
						}
						for (int j = 3; j < 8; j++)
						{
							if (armor[j].type == 0)
							{
								num = j;
								break;
							}
						}
					}
					else if (item.headSlot >= 0)
					{
						num = (flag ? 8 : 0);
					}
					else if (item.bodySlot >= 0)
					{
						num = ((!flag) ? 1 : 9);
					}
					else if (item.legSlot >= 0)
					{
						num = (flag ? 10 : 2);
					}
					if (num >= 0 && armor[num].type == 0)
					{
						armor[num] = item;
						itemsFound.Set(item.type, value: true);
						ui.FoundPotentialArmor(item.type);
						item.Init();
						return true;
					}
					flag = !flag;
				}
				while (flag != item.vanity);
			}
			return false;
		}

		public bool FillAmmo(ref Item item)
		{
			bool result = false;
			lock (this)
			{
				for (int i = 44; i < 48; i++)
				{
					if (inventory[i].type > 0 && inventory[i].stack < inventory[i].maxStack && item.netID == inventory[i].netID)
					{
						Main.PlaySound(7, aabb.X, aabb.Y);
						if (item.stack + inventory[i].stack <= inventory[i].maxStack)
						{
							inventory[i].stack += item.stack;
							view.itemTextLocal.NewText(ref item, item.stack);
							item.Init();
							return true;
						}
						short num = (short)(inventory[i].maxStack - inventory[i].stack);
						item.stack -= num;
						view.itemTextLocal.NewText(ref item, num);
						inventory[i].stack = inventory[i].maxStack;
						result = true;
					}
				}
				if (!item.CanBeAutoPlacedInEmptyAmmoSlot())
				{
					return result;
				}
				for (int j = 44; j < 48; j++)
				{
					if (inventory[j].type == 0)
					{
						inventory[j] = item;
						itemsFound.Set(item.type, value: true);
						view.itemTextLocal.NewText(ref item, item.stack);
						Main.PlaySound(7, aabb.X, aabb.Y);
						item.Init();
						return true;
					}
				}
				return result;
			}
		}

		public bool GetItem(ref Item item)
		{
			if (item.noGrabDelay > 0)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = isLocal() && ui.inventoryMode > 0 && ui.inventorySection == UI.InventorySection.CRAFTING && ui.gpState.IsButtonUp(Buttons.A);
			int num = 40;
			int num2 = 0;
			if (item.CanBePlacedInCoinSlot())
			{
				num2 = -4;
				num = 44;
			}
			else if (item.CanBePlacedInAmmoSlot())
			{
				flag = FillAmmo(ref item);
				if (flag && (item.type == 0 || item.stack == 0))
				{
					if (flag2)
					{
						Recipe.FindRecipes(ui, ui.craftingCategory, ui.craftingShowCraftable);
					}
					return true;
				}
			}
			else if (AutoEquip(ref item))
			{
				return true;
			}
			lock (this)
			{
				for (int i = num2; i < 40; i++)
				{
					int num3 = i;
					if (num3 < 0)
					{
						num3 += 44;
					}
					if (inventory[num3].type > 0 && inventory[num3].stack < inventory[num3].maxStack && item.netID == inventory[num3].netID)
					{
						Main.PlaySound(7, aabb.X, aabb.Y);
						if (item.stack + inventory[num3].stack <= inventory[num3].maxStack)
						{
							inventory[num3].stack += item.stack;
							view.itemTextLocal.NewText(ref item, item.stack);
							DoCoins(num3);
							item.Init();
							if (flag2)
							{
								Recipe.FindRecipes(ui, ui.craftingCategory, ui.craftingShowCraftable);
							}
							return true;
						}
						short num4 = (short)(inventory[num3].maxStack - inventory[num3].stack);
						item.stack -= num4;
						view.itemTextLocal.NewText(ref item, num4);
						inventory[num3].stack = inventory[num3].maxStack;
						DoCoins(num3);
						flag = true;
					}
				}
				if (item.useStyle > 0)
				{
					for (int j = 0; j < 10; j++)
					{
						if (inventory[j].type == 0)
						{
							inventory[j] = item;
							itemsFound.Set(item.type, value: true);
							view.itemTextLocal.NewText(ref item, item.stack);
							DoCoins(j);
							Main.PlaySound(7, aabb.X, aabb.Y);
							item.Init();
							if (flag2)
							{
								Recipe.FindRecipes(ui, ui.craftingCategory, ui.craftingShowCraftable);
							}
							return true;
						}
					}
				}
				for (int num5 = num - 1; num5 >= 0; num5--)
				{
					if (inventory[num5].type == 0)
					{
						inventory[num5] = item;
						itemsFound.Set(item.type, value: true);
						ui.FoundPotentialArmor(item.type);
						view.itemTextLocal.NewText(ref item, item.stack);
						DoCoins(num5);
						Main.PlaySound(7, aabb.X, aabb.Y);
						item.Init();
						if (flag2)
						{
							Recipe.FindRecipes(ui, ui.craftingCategory, ui.craftingShowCraftable);
						}
						return true;
					}
				}
			}
			if (flag2 && flag)
			{
				Recipe.FindRecipes(ui, ui.craftingCategory, ui.craftingShowCraftable);
			}
			return flag;
		}

		private void PlaceThing()
		{
			int createTile = inventory[selectedItem].createTile;
			if (createTile >= 0)
			{
				bool flag = false;
				if (Main.tile[tileTargetX, tileTargetY].liquid > 0 && Main.tile[tileTargetX, tileTargetY].lava != 0)
				{
					if (Main.tileSolid[createTile])
					{
						flag = true;
					}
					else if (Main.tileLavaDeath[createTile])
					{
						flag = true;
					}
				}
				if (((Main.tile[tileTargetX, tileTargetY].active == 0 && !flag) || Main.tileCut[Main.tile[tileTargetX, tileTargetY].type] || createTile == 23 || createTile == 2 || createTile == 109 || createTile == 60 || createTile == 70) && itemTime == 0 && itemAnimation > 0 && controlUseItem)
				{
					bool flag2 = false;
					switch (createTile)
					{
					case 2:
					case 23:
					case 109:
						if (Main.tile[tileTargetX, tileTargetY].active != 0 && Main.tile[tileTargetX, tileTargetY].type == 0)
						{
							flag2 = true;
						}
						break;
					case 60:
					case 70:
						if (Main.tile[tileTargetX, tileTargetY].active != 0 && Main.tile[tileTargetX, tileTargetY].type == 59)
						{
							flag2 = true;
						}
						break;
					case 4:
					case 136:
					{
						int num = Main.tile[tileTargetX, tileTargetY + 1].type;
						int num2 = Main.tile[tileTargetX - 1, tileTargetY].type;
						int num3 = Main.tile[tileTargetX + 1, tileTargetY].type;
						int num4 = Main.tile[tileTargetX - 1, tileTargetY - 1].type;
						int num5 = Main.tile[tileTargetX + 1, tileTargetY - 1].type;
						int num6 = Main.tile[tileTargetX - 1, tileTargetY - 1].type;
						int num7 = Main.tile[tileTargetX + 1, tileTargetY + 1].type;
						if (Main.tile[tileTargetX, tileTargetY + 1].active == 0)
						{
							num = -1;
						}
						if (Main.tile[tileTargetX - 1, tileTargetY].active == 0)
						{
							num2 = -1;
						}
						if (Main.tile[tileTargetX + 1, tileTargetY].active == 0)
						{
							num3 = -1;
						}
						if (Main.tile[tileTargetX - 1, tileTargetY - 1].active == 0)
						{
							num4 = -1;
						}
						if (Main.tile[tileTargetX + 1, tileTargetY - 1].active == 0)
						{
							num5 = -1;
						}
						if (Main.tile[tileTargetX - 1, tileTargetY + 1].active == 0)
						{
							num6 = -1;
						}
						if (Main.tile[tileTargetX + 1, tileTargetY + 1].active == 0)
						{
							num7 = -1;
						}
						if (num >= 0 && Main.tileSolidAndAttach[num])
						{
							flag2 = true;
						}
						else if (num2 >= 0 && (Main.tileSolidAndAttach[num2] || num2 == 124 || (num2 == 5 && num4 == 5 && num6 == 5)))
						{
							flag2 = true;
						}
						else if (num3 >= 0 && (Main.tileSolidAndAttach[num3] || num3 == 124 || (num3 == 5 && num5 == 5 && num7 == 5)))
						{
							flag2 = true;
						}
						break;
					}
					case 78:
					case 98:
					case 100:
						if (Main.tile[tileTargetX, tileTargetY + 1].active != 0 && (Main.tileSolid[Main.tile[tileTargetX, tileTargetY + 1].type] || Main.tileTable[Main.tile[tileTargetX, tileTargetY + 1].type]))
						{
							flag2 = true;
						}
						break;
					case 13:
					case 29:
					case 33:
					case 49:
					case 50:
					case 103:
						if (Main.tile[tileTargetX, tileTargetY + 1].active != 0 && Main.tileTable[Main.tile[tileTargetX, tileTargetY + 1].type])
						{
							flag2 = true;
						}
						break;
					case 51:
						if (Main.tile[tileTargetX + 1, tileTargetY].active != 0 || Main.tile[tileTargetX + 1, tileTargetY].wall > 0 || Main.tile[tileTargetX - 1, tileTargetY].active != 0 || Main.tile[tileTargetX - 1, tileTargetY].wall > 0 || Main.tile[tileTargetX, tileTargetY + 1].active != 0 || Main.tile[tileTargetX, tileTargetY + 1].wall > 0 || Main.tile[tileTargetX, tileTargetY - 1].active != 0 || Main.tile[tileTargetX, tileTargetY - 1].wall > 0)
						{
							flag2 = true;
						}
						break;
					default:
						if ((Main.tile[tileTargetX + 1, tileTargetY].active != 0 && Main.tileSolid[Main.tile[tileTargetX + 1, tileTargetY].type]) || Main.tile[tileTargetX + 1, tileTargetY].wall > 0 || (Main.tile[tileTargetX - 1, tileTargetY].active != 0 && Main.tileSolid[Main.tile[tileTargetX - 1, tileTargetY].type]) || Main.tile[tileTargetX - 1, tileTargetY].wall > 0 || (Main.tile[tileTargetX, tileTargetY + 1].active != 0 && (Main.tileSolid[Main.tile[tileTargetX, tileTargetY + 1].type] || Main.tile[tileTargetX, tileTargetY + 1].type == 124)) || Main.tile[tileTargetX, tileTargetY + 1].wall > 0 || (Main.tile[tileTargetX, tileTargetY - 1].active != 0 && (Main.tileSolid[Main.tile[tileTargetX, tileTargetY - 1].type] || Main.tile[tileTargetX, tileTargetY - 1].type == 124)) || Main.tile[tileTargetX, tileTargetY - 1].wall > 0)
						{
							flag2 = true;
						}
						break;
					}
					if (createTile >= 82 && createTile <= 84)
					{
						flag2 = true;
					}
					if (Main.tile[tileTargetX, tileTargetY].active != 0 && Main.tileCut[Main.tile[tileTargetX, tileTargetY].type])
					{
						if (Main.tile[tileTargetX, tileTargetY + 1].type != 78)
						{
							if (WorldGen.KillTile(tileTargetX, tileTargetY))
							{
								NetMessage.CreateMessage5(17, 4, tileTargetX, tileTargetY, 0);
								NetMessage.SendMessage();
							}
						}
						else
						{
							flag2 = false;
						}
					}
					if (flag2)
					{
						int num8 = inventory[selectedItem].placeStyle;
						if (createTile == 141)
						{
							num8 = Main.rand.Next(2);
						}
						if (createTile == 128 || createTile == 137)
						{
							num8 = ((direction >= 0) ? 1 : (-1));
						}
						if (WorldGen.PlaceTile(tileTargetX, tileTargetY, createTile, mute: false, forced: false, whoAmI, num8))
						{
							itemTime = inventory[selectedItem].useTime;
							NetMessage.CreateMessage5(17, 1, tileTargetX, tileTargetY, createTile, num8);
							NetMessage.SendMessage();
							switch (createTile)
							{
							case 15:
								if (direction == 1)
								{
									Main.tile[tileTargetX, tileTargetY].frameX += 18;
									Main.tile[tileTargetX, tileTargetY - 1].frameX += 18;
								}
								NetMessage.SendTileSquare(tileTargetX - 1, tileTargetY - 1, 3);
								break;
							case 19:
								ui.totalWoodPlatformsPlaced++;
								break;
							case 79:
							case 90:
								NetMessage.SendTileSquare(tileTargetX, tileTargetY, 5);
								break;
							}
						}
					}
				}
			}
			int createWall = inventory[selectedItem].createWall;
			if (createWall >= 0 && itemTime == 0 && itemAnimation > 0 && controlUseItem && (Main.tile[tileTargetX + 1, tileTargetY].active != 0 || Main.tile[tileTargetX + 1, tileTargetY].wall > 0 || Main.tile[tileTargetX - 1, tileTargetY].active != 0 || Main.tile[tileTargetX - 1, tileTargetY].wall > 0 || Main.tile[tileTargetX, tileTargetY + 1].active != 0 || Main.tile[tileTargetX, tileTargetY + 1].wall > 0 || Main.tile[tileTargetX, tileTargetY - 1].active != 0 || Main.tile[tileTargetX, tileTargetY - 1].wall > 0) && Main.tile[tileTargetX, tileTargetY].wall != createWall && WorldGen.PlaceWall(tileTargetX, tileTargetY, createWall))
			{
				ui.totalWallsPlaced++;
				itemTime = inventory[selectedItem].useTime;
				NetMessage.CreateMessage5(17, 3, tileTargetX, tileTargetY, createWall);
				NetMessage.SendMessage();
				if (inventory[selectedItem].stack > 1)
				{
					for (int i = 0; i < 4; i++)
					{
						int num9 = tileTargetX;
						int num10 = tileTargetY;
						switch (i)
						{
						case 0:
							num9--;
							break;
						case 1:
							num9++;
							break;
						case 2:
							num10--;
							break;
						default:
							num10++;
							break;
						}
						if (Main.tile[num9, num10].wall != 0)
						{
							continue;
						}
						int num11 = 0;
						for (int j = 0; j < 4; j++)
						{
							int num12 = num9;
							int num13 = num10;
							switch (j)
							{
							case 0:
								num12--;
								break;
							case 1:
								num12++;
								break;
							case 2:
								num13--;
								break;
							default:
								num13++;
								break;
							}
							if (Main.tile[num12, num13].wall == createWall)
							{
								num11++;
							}
						}
						if (num11 == 4 && WorldGen.PlaceWall(num9, num10, createWall))
						{
							inventory[selectedItem].stack--;
							if (inventory[selectedItem].stack == 0)
							{
								inventory[selectedItem].Init();
							}
							ui.totalWallsPlaced++;
							NetMessage.CreateMessage5(17, 3, num9, num10, createWall);
							NetMessage.SendMessage();
						}
					}
				}
			}
			if (!isLocal() || view.isFullScreen())
			{
				return;
			}
			if (createTile >= 0 || createWall >= 0)
			{
				if (!ui.smartCursor && ui.hotbarItemNameTime <= 0)
				{
					view.Zoom(1.5f);
				}
			}
			else
			{
				view.Zoom(1.25f);
			}
		}

		public unsafe void ItemCheck(int i)
		{
			try
			{
				fixed (Item* ptr = &inventory[selectedItem])
				{
					int num = ptr->damage;
					if (num > 0)
					{
						if (ptr->melee)
						{
							num = (int)((float)num * meleeDamage);
						}
						else if (ptr->ranged)
						{
							num = (int)((float)num * rangedDamage);
						}
						else if (ptr->magic)
						{
							num = (int)((float)num * magicDamage);
						}
					}
					if (ptr->autoReuse && !noItems)
					{
						releaseUseItem = true;
						if (itemAnimation == 1 && ptr->stack > 0)
						{
							if (ptr->shoot > 0 && !isLocal() && controlUseItem)
							{
								itemAnimation = 2;
							}
							else
							{
								itemAnimation = 0;
							}
						}
					}
					if (itemAnimation == 0 && reuseDelay > 0)
					{
						itemAnimation = reuseDelay;
						itemTime = reuseDelay;
						reuseDelay = 0;
					}
					if (controlUseItem && releaseUseItem && (ptr->headSlot > 0 || ptr->bodySlot > 0 || ptr->legSlot > 0))
					{
						if (ptr->useStyle == 0)
						{
							releaseUseItem = false;
						}
						int num2 = tileTargetX;
						int num3 = tileTargetY;
						if (Main.tile[num2, num3].active != 0 && Main.tile[num2, num3].type == 128)
						{
							int frameY = Main.tile[num2, num3].frameY;
							int num4 = 0;
							if (ptr->bodySlot >= 0)
							{
								num4 = 1;
							}
							else if (ptr->legSlot >= 0)
							{
								num4 = 2;
							}
							frameY /= 18;
							while (num4 > frameY)
							{
								num3++;
								frameY = Main.tile[num2, num3].frameY / 18;
							}
							while (num4 < frameY)
							{
								num3--;
								frameY = Main.tile[num2, num3].frameY / 18;
							}
							int num5 = Main.tile[num2, num3].frameX % 100;
							if (num5 >= 36)
							{
								num5 -= 36;
							}
							num2 -= num5 / 18;
							int frameX = Main.tile[num2, num3].frameX;
							WorldGen.KillTile(num2, num3, fail: true);
							NetMessage.CreateMessage5(17, 0, num2, num3, 1);
							NetMessage.SendMessage();
							frameX %= 100;
							if (frameY == 0 && ptr->headSlot >= 0)
							{
								Main.tile[num2, num3].frameX = (short)(frameX + ptr->headSlot * 100);
								NetMessage.SendTile(num2, num3);
								ptr->SetDefaults(0);
								ui.mouseItem.SetDefaults(0);
								releaseUseItem = false;
							}
							else if (frameY == 1 && ptr->bodySlot >= 0)
							{
								Main.tile[num2, num3].frameX = (short)(frameX + ptr->bodySlot * 100);
								NetMessage.SendTile(num2, num3);
								ptr->SetDefaults(0);
								ui.mouseItem.SetDefaults(0);
								releaseUseItem = false;
							}
							else if (frameY == 2 && ptr->legSlot >= 0)
							{
								Main.tile[num2, num3].frameX = (short)(frameX + ptr->legSlot * 100);
								NetMessage.SendTile(num2, num3);
								ptr->SetDefaults(0);
								ui.mouseItem.SetDefaults(0);
								releaseUseItem = false;
							}
						}
					}
					if (controlUseItem && itemAnimation == 0 && releaseUseItem && ptr->useStyle > 0)
					{
						bool flag = !noItems;
						if (ptr->shoot == 0)
						{
							itemRotation = 0f;
						}
						if (flag)
						{
							if (ptr->shoot == 85 || ptr->shoot == 15 || ptr->shoot == 34)
							{
								flag = !wet;
							}
							else if (ptr->shoot == 6 || ptr->shoot == 19 || ptr->shoot == 33 || ptr->shoot == 52)
							{
								for (int j = 0; j < 512; j++)
								{
									if (Main.projectile[j].active != 0 && Main.projectile[j].owner == whoAmI && Main.projectile[j].type == ptr->shoot)
									{
										flag = false;
										break;
									}
								}
							}
							else if (ptr->shoot == 106)
							{
								int num6 = 0;
								for (int k = 0; k < 512; k++)
								{
									if (Main.projectile[k].active != 0 && Main.projectile[k].owner == whoAmI && Main.projectile[k].type == ptr->shoot && num6 >= ptr->stack)
									{
										flag = false;
										break;
									}
								}
							}
							else if (ptr->shoot == 13 || ptr->shoot == 32)
							{
								for (int l = 0; l < 512; l++)
								{
									if (Main.projectile[l].active != 0 && Main.projectile[l].owner == whoAmI && Main.projectile[l].type == ptr->shoot && Main.projectile[l].ai0 != 2f)
									{
										flag = false;
										break;
									}
								}
							}
							else if (ptr->shoot == 73)
							{
								for (int m = 0; m < 512; m++)
								{
									if (Main.projectile[m].active != 0 && Main.projectile[m].owner == whoAmI && Main.projectile[m].type == 74)
									{
										flag = false;
										break;
									}
								}
							}
						}
						if (flag && ptr->potion)
						{
							if (potionDelay <= 0)
							{
								potionDelay = potionDelayTime;
								AddBuff(21, potionDelay);
							}
							else
							{
								flag = false;
								itemTime = ptr->useTime;
							}
						}
						if (ptr->mana > 0 && silence)
						{
							flag = false;
						}
						if (ptr->mana > 0 && flag)
						{
							if (ptr->type != 127 || !spaceGun)
							{
								if (statMana >= (int)((float)(int)ptr->mana * manaCost))
								{
									statMana -= (short)((float)(int)ptr->mana * manaCost);
								}
								else if (manaFlower)
								{
									QuickMana();
									if (statMana >= (int)((float)(int)ptr->mana * manaCost))
									{
										statMana -= (short)((float)(int)ptr->mana * manaCost);
									}
									else
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
							}
							if (isLocal() && ptr->buffType != 0)
							{
								AddBuff(ptr->buffType, ptr->buffTime);
							}
						}
						if (isLocal() && ptr->buffType == 40)
						{
							ApplyPetBuff(ptr->type);
						}
						if (Main.gameTime.dayTime)
						{
							if (ptr->type == 43)
							{
								flag = false;
							}
							else if (ptr->type == 544)
							{
								flag = false;
							}
							else if (ptr->type == 556)
							{
								flag = false;
							}
							else if (ptr->type == 557)
							{
								flag = false;
							}
						}
						if (ptr->type == 70 && !zoneEvil)
						{
							flag = false;
						}
						else if (flag && isLocal() && ptr->shoot == 17)
						{
							int num7 = ui.mouseX + view.screenPosition.X >> 4;
							int num8 = ui.mouseY + view.screenPosition.Y >> 4;
							if (Main.tile[num7, num8].active != 0 && (Main.tile[num7, num8].type == 0 || Main.tile[num7, num8].type == 2 || Main.tile[num7, num8].type == 23))
							{
								WorldGen.KillTile(num7, num8, fail: false, effectOnly: false, noItem: true);
								if (Main.tile[num7, num8].active == 0)
								{
									NetMessage.CreateMessage5(17, 4, num7, num8, 0);
									NetMessage.SendMessage();
								}
								else
								{
									flag = false;
								}
							}
							else
							{
								flag = false;
							}
						}
						if (flag && ptr->useAmmo > 0)
						{
							flag = false;
							for (int n = 0; n < 48; n++)
							{
								if (inventory[n].ammo == ptr->useAmmo && inventory[n].stack > 0)
								{
									flag = true;
									break;
								}
							}
						}
						if (flag)
						{
							if (ptr->pick > 0 || ptr->axe > 0 || ptr->hammer > 0)
							{
								toolTime = 1;
							}
							if (grappling[0] >= 0)
							{
								if (controlRight)
								{
									direction = 1;
								}
								else if (controlLeft)
								{
									direction = -1;
								}
							}
							channel = ptr->channel;
							attackCD = 0;
							if (ptr->melee)
							{
								itemAnimation = (short)((float)(int)ptr->useAnimation * meleeSpeed);
								itemAnimationMax = (short)((float)(int)ptr->useAnimation * meleeSpeed);
							}
							else
							{
								itemAnimation = ptr->useAnimation;
								itemAnimationMax = ptr->useAnimation;
								reuseDelay = ptr->reuseDelay;
							}
							if (ptr->useSound > 0)
							{
								Main.PlaySound(2, aabb.X, aabb.Y, ptr->useSound);
							}
						}
						if (flag && (ptr->shoot == 18 || ptr->shoot == 72 || ptr->shoot == 86 || ptr->shoot == 87 || ptr->shoot == 111))
						{
							for (int num9 = 0; num9 < 512; num9++)
							{
								if (Main.projectile[num9].active != 0 && Main.projectile[num9].owner == i)
								{
									if (Main.projectile[num9].type == ptr->shoot)
									{
										Main.projectile[num9].Kill();
									}
									else if (ptr->shoot == 72 && (Main.projectile[num9].type == 86 || Main.projectile[num9].type == 87))
									{
										Main.projectile[num9].Kill();
									}
								}
							}
						}
					}
					if (!controlUseItem)
					{
						channel = false;
					}
					itemHeight = (short)SpriteSheet<_sheetSprites>.src[451 + ptr->type].Height;
					itemWidth = (short)SpriteSheet<_sheetSprites>.src[451 + ptr->type].Width;
					if (itemAnimation > 0)
					{
						if (ptr->melee)
						{
							itemAnimationMax = (short)((float)(int)ptr->useAnimation * meleeSpeed);
						}
						else
						{
							itemAnimationMax = ptr->useAnimation;
						}
						if (ptr->mana > 0)
						{
							manaRegenDelay = maxRegenDelay;
						}
						itemAnimation--;
						if (ptr->useStyle == 1)
						{
							if (itemAnimation < itemAnimationMax / 3)
							{
								int num10 = 10;
								if (itemWidth > 32)
								{
									num10 = ((itemWidth <= 64) ? 14 : 28);
								}
								itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) - num10) * direction;
								itemLocation.Y = aabb.Y + 24;
							}
							else if (itemAnimation < (itemAnimationMax << 1) / 3)
							{
								int num11 = 10;
								if (itemWidth > 32)
								{
									num11 = ((itemWidth <= 64) ? 18 : 28);
								}
								itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) - num11) * direction;
								num11 = 10;
								if (itemWidth > 32)
								{
									num11 = ((itemWidth <= 64) ? 8 : 14);
								}
								itemLocation.Y = aabb.Y + num11;
							}
							else
							{
								int num12 = 6;
								if (itemWidth > 32)
								{
									num12 = ((itemWidth <= 64) ? 14 : 28);
								}
								itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) - num12) * direction;
								num12 = 10;
								if (itemWidth > 32)
								{
									num12 = ((itemWidth <= 64) ? 10 : 14);
								}
								itemLocation.Y = aabb.Y + num12;
							}
							itemRotation = ((float)itemAnimation / (float)itemAnimationMax - 0.5f) * (float)(-direction) * 3.5f - (float)direction * 0.3f;
							if (gravDir == -1)
							{
								itemRotation = 0f - itemRotation;
								itemLocation.Y = aabb.Y + 42 + (aabb.Y - itemLocation.Y);
							}
						}
						else if (ptr->useStyle == 2)
						{
							itemRotation = (float)itemAnimation / (float)itemAnimationMax * (float)(direction << 1) + -1.4f * (float)direction;
							if (itemAnimation < itemAnimationMax >> 1)
							{
								itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) - 9 - (int)(itemRotation * (float)(12 * direction))) * direction;
								itemLocation.Y = aabb.Y + 38 + (int)(itemRotation * (float)(direction << 2));
							}
							else
							{
								itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) - 9 - (int)(itemRotation * (float)(direction << 4))) * direction;
								itemLocation.Y = aabb.Y + 38 + (int)(itemRotation * (float)direction);
							}
							if (gravDir == -1)
							{
								itemRotation = 0f - itemRotation;
								itemLocation.Y = aabb.Y + 42 + (aabb.Y - itemLocation.Y);
							}
						}
						else if (ptr->useStyle == 3)
						{
							if (itemAnimation > (itemAnimationMax << 1) / 3)
							{
								itemLocation.X = -1000;
								itemLocation.Y = -1000;
								itemRotation = -1.3f * (float)direction;
							}
							else
							{
								itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) - 4) * direction;
								itemLocation.Y = aabb.Y + 24;
								float num13 = (float)itemAnimation / (float)itemAnimationMax * (float)itemWidth * (float)direction * ptr->scale * 1.2f - (float)(10 * direction);
								if (num13 > -4f && direction == -1)
								{
									num13 = -8f;
								}
								if (num13 < 4f && direction == 1)
								{
									num13 = 8f;
								}
								itemLocation.X -= (int)num13;
								itemRotation = 0.8f * (float)direction;
							}
							if (gravDir == -1)
							{
								itemRotation = 0f - itemRotation;
								itemLocation.Y = aabb.Y + 42 + (aabb.Y - itemLocation.Y);
							}
						}
						else if (ptr->useStyle == 4)
						{
							itemRotation = 0f;
							itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) - 9 - (int)(itemRotation * (float)(14 * direction)) - 4) * direction;
							itemLocation.Y = aabb.Y + (itemHeight >> 1) + 4;
							if (gravDir == -1)
							{
								itemRotation = 0f - itemRotation;
								itemLocation.Y = aabb.Y + 42 + (aabb.Y - itemLocation.Y);
							}
						}
						else if (ptr->useStyle == 5)
						{
							itemLocation.X = aabb.X + 10 - (itemWidth >> 1) - (direction << 1);
							itemLocation.Y = aabb.Y + 21 - (itemHeight >> 1);
						}
					}
					else if (ptr->holdStyle == 1)
					{
						itemLocation.X = aabb.X + 10 + ((itemWidth >> 1) + 2) * direction;
						if (ptr->type == 282 || ptr->type == 286)
						{
							itemLocation.X -= direction << 1;
							itemLocation.Y += 4;
						}
						itemLocation.Y = aabb.Y + 24;
						itemRotation = 0f;
						if (gravDir == -1)
						{
							itemRotation = 0f - itemRotation;
							itemLocation.Y = aabb.Y + 42 + (aabb.Y - itemLocation.Y);
						}
					}
					else if (ptr->holdStyle == 2)
					{
						itemLocation.X = aabb.X + 10 + 6 * direction;
						itemLocation.Y = aabb.Y + 16;
						itemRotation = -0.79f * (float)direction;
						if (gravDir == -1)
						{
							itemRotation = 0f - itemRotation;
							itemLocation.Y = aabb.Y + 42 + (aabb.Y - itemLocation.Y);
						}
					}
					else if (ptr->holdStyle == 3)
					{
						itemLocation.X = aabb.X + 10 - (itemWidth >> 1) - (direction << 1);
						itemLocation.Y = aabb.Y + 21 - (itemHeight >> 1);
						itemRotation = 0f;
					}
					if ((ptr->type == 8 || ptr->type == 523 || (ptr->type >= 427 && ptr->type <= 433)) && !wet)
					{
						int num14 = 0;
						if (ptr->type == 523)
						{
							num14 = 8;
						}
						else if (ptr->type >= 427)
						{
							num14 = ptr->type - 426;
						}
						Vector3 rgb;
						switch (num14)
						{
						case 1:
							rgb = new Vector3(0f, 0.1f, 1.3f);
							break;
						case 2:
							rgb = new Vector3(1f, 0.1f, 0.1f);
							break;
						case 3:
							rgb = new Vector3(0f, 1f, 0.1f);
							break;
						case 4:
							rgb = new Vector3(0.9f, 0f, 0.9f);
							break;
						case 5:
							rgb = new Vector3(1.3f, 1.3f, 1.3f);
							break;
						case 6:
							rgb = new Vector3(0.9f, 0.9f, 0f);
							break;
						case 7:
							rgb = new Vector3(0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch), 0.3f, Main.demonTorch + 0.5f * (1f - Main.demonTorch));
							break;
						case 8:
							rgb = new Vector3(0.85f, 1f, 0.7f);
							break;
						default:
							rgb = new Vector3(1f, 0.95f, 0.8f);
							break;
						}
						int num15 = num14;
						switch (num15)
						{
						case 0:
							num15 = 6;
							break;
						case 8:
							num15 = 75;
							break;
						default:
							num15 = 58 + num15;
							break;
						}
						int upperBound = 20;
						if (itemAnimation > 0)
						{
							upperBound = 7;
						}
						if (direction == -1)
						{
							if (Main.rand.Next(upperBound) == 0)
							{
								Main.dust.NewDust(itemLocation.X - 16, itemLocation.Y - 14 * gravDir, 4, 4, num15, 0.0, 0.0, 100);
							}
							Lighting.addLight((int)((float)(itemLocation.X - 12) + velocity.X) >> 4, (int)((float)(itemLocation.Y - 14) + velocity.Y) >> 4, rgb);
						}
						else
						{
							if (Main.rand.Next(upperBound) == 0)
							{
								Main.dust.NewDust(itemLocation.X + 6, itemLocation.Y - 14 * gravDir, 4, 4, num15, 0.0, 0.0, 100);
							}
							Lighting.addLight((int)((float)(itemLocation.X + 12) + velocity.X) >> 4, (int)((float)(itemLocation.Y - 14) + velocity.Y) >> 4, rgb);
						}
					}
					if (ptr->type == 105 && !wet)
					{
						int upperBound2 = 20;
						if (itemAnimation > 0)
						{
							upperBound2 = 7;
						}
						if (direction == -1)
						{
							if (Main.rand.Next(upperBound2) == 0)
							{
								Main.dust.NewDust(itemLocation.X - 12, itemLocation.Y - 20 * gravDir, 4, 4, 6, 0.0, 0.0, 100);
							}
							Lighting.addLight((int)((float)(itemLocation.X - 16) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(1f, 0.95f, 0.8f));
						}
						else
						{
							if (Main.rand.Next(upperBound2) == 0)
							{
								Main.dust.NewDust(itemLocation.X + 4, itemLocation.Y - 20 * gravDir, 4, 4, 6, 0.0, 0.0, 100);
							}
							Lighting.addLight((int)((float)(itemLocation.X + 6) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(1f, 0.95f, 0.8f));
						}
					}
					else if (ptr->type == 148 && !wet)
					{
						int upperBound3 = 10;
						if (itemAnimation > 0)
						{
							upperBound3 = 7;
						}
						if (direction == -1)
						{
							if (Main.rand.Next(upperBound3) == 0)
							{
								Main.dust.NewDust(itemLocation.X - 12, itemLocation.Y - 20 * gravDir, 4, 4, 29, 0.0, 0.0, 100);
							}
							Lighting.addLight((int)((float)(itemLocation.X - 16) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(0.3f, 0.3f, 0.75f));
						}
						else
						{
							if (Main.rand.Next(upperBound3) == 0)
							{
								Main.dust.NewDust(itemLocation.X + 4, itemLocation.Y - 20 * gravDir, 4, 4, 29, 0.0, 0.0, 100);
							}
							Lighting.addLight((int)((float)(itemLocation.X + 6) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(0.3f, 0.3f, 0.75f));
						}
					}
					if (ptr->type == 282)
					{
						if (direction == -1)
						{
							Lighting.addLight((int)((float)(itemLocation.X - 16) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(0.7f, 1f, 0.8f));
						}
						else
						{
							Lighting.addLight((int)((float)(itemLocation.X + 6) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(0.7f, 1f, 0.8f));
						}
					}
					else if (ptr->type == 286)
					{
						if (direction == -1)
						{
							Lighting.addLight((int)((float)(itemLocation.X - 16) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(0.7f, 0.8f, 1f));
						}
						else
						{
							Lighting.addLight((int)((float)(itemLocation.X + 6) + velocity.X) >> 4, itemLocation.Y - 14 >> 4, new Vector3(0.7f, 0.8f, 1f));
						}
					}
					releaseUseItem = !controlUseItem;
					if (itemTime > 0)
					{
						itemTime--;
					}
					bool flag3;
					int num54;
					int num55;
					if (isLocal())
					{
						if (ptr->shoot > 0 && itemAnimation > 0 && itemTime == 0)
						{
							int num16 = ptr->shoot;
							float num17 = ptr->shootSpeed;
							if (ptr->melee && num16 != 25 && num16 != 26 && num16 != 35)
							{
								num17 /= meleeSpeed;
							}
							if (num16 == 13 || num16 == 32)
							{
								grappling[0] = -1;
								grapCount = 0;
								for (int num18 = 0; num18 < 512; num18++)
								{
									if (Main.projectile[num18].type == 13 && Main.projectile[num18].active != 0 && Main.projectile[num18].owner == i)
									{
										Main.projectile[num18].Kill();
									}
								}
							}
							int num19 = num;
							float num20 = ptr->knockBack;
							bool flag2 = false;
							if (ptr->useAmmo > 0)
							{
								int num21 = -1;
								for (int num22 = 47; num22 >= 44; num22--)
								{
									if (inventory[num22].ammo == ptr->useAmmo && inventory[num22].stack > 0)
									{
										num21 = num22;
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									int num23 = int.MaxValue;
									for (int num24 = 39; num24 >= 0; num24--)
									{
										if (inventory[num24].ammo == ptr->useAmmo && inventory[num24].stack > 0 && num23 > inventory[num24].type)
										{
											num23 = inventory[num24].type;
											num21 = num24;
											flag2 = true;
										}
									}
								}
								if (flag2)
								{
									if (inventory[num21].shoot > 0)
									{
										num16 = inventory[num21].shoot;
									}
									if (num16 == 42)
									{
										if (inventory[num21].type == 370)
										{
											num16 = 65;
											num19 += 5;
										}
										else if (inventory[num21].type == 408)
										{
											num16 = 68;
											num19 += 5;
										}
									}
									num17 += inventory[num21].shootSpeed;
									num19 = ((!inventory[num21].ranged) ? (num19 + inventory[num21].damage) : (num19 + (int)((float)inventory[num21].damage * rangedDamage)));
									if (ptr->useAmmo == 1 && archery)
									{
										if (num17 < 20f)
										{
											num17 *= 1.2f;
											if (num17 > 20f)
											{
												num17 = 20f;
											}
										}
										num19 += num19 / 5;
									}
									num20 += inventory[num21].knockBack;
									if ((ptr->type != 98 || Main.rand.Next(3) != 0) && (ptr->type != 533 || Main.rand.Next(2) != 0) && (ptr->type != 434 || itemAnimation >= ptr->useAnimation - 2) && Main.rand.Next(100) >= freeAmmoChance && (num16 != 85 || itemAnimation >= itemAnimationMax - 6) && --inventory[num21].stack <= 0)
									{
										inventory[num21].Init();
									}
								}
							}
							else
							{
								flag2 = true;
							}
							switch (num16)
							{
							case 72:
							{
								int num26 = Main.rand.Next(3);
								if (num26 != 0)
								{
									num16 = num26 + 85;
								}
								break;
							}
							case 73:
							{
								for (int num25 = 0; num25 < 512; num25++)
								{
									if (Main.projectile[num25].active != 0 && Main.projectile[num25].owner == i)
									{
										if (Main.projectile[num25].type == 73)
										{
											num16 = 74;
										}
										else if (Main.projectile[num25].type == 74)
										{
											flag2 = false;
											break;
										}
									}
								}
								break;
							}
							}
							if (flag2)
							{
								if (kbGlove && ptr->mech)
								{
									num20 *= 1.7f;
								}
								if (ptr->type == 120)
								{
									if (num16 == 1)
									{
										num16 = 2;
									}
								}
								else if (ptr->type == 615)
								{
									num16 = 113;
								}
								else if (ptr->type == 617)
								{
									num16 = 114;
								}
								itemTime = ptr->useTime;
								direction = (sbyte)((ui.mouseX + view.screenPosition.X > aabb.X + 10) ? 1 : (-1));
								Vector2 vector = new Vector2(position.X + 10f, position.Y + 21f);
								switch (num16)
								{
								case 9:
									vector.X += Main.rand.Next(601) * -direction;
									vector.Y += -300 - Main.rand.Next(100);
									num20 = 0f;
									break;
								case 51:
									vector.Y -= 6 * gravDir;
									break;
								}
								float num27 = (float)(ui.mouseX + view.screenPosition.X) - vector.X;
								float num28 = (float)(ui.mouseY + view.screenPosition.Y) - vector.Y;
								float num29 = (float)Math.Sqrt(num27 * num27 + num28 * num28);
								float num30 = num29;
								num29 = num17 / num29;
								num27 *= num29;
								num28 *= num29;
								switch (num16)
								{
								case 12:
									vector.X += num27 * 3f;
									vector.Y += num28 * 3f;
									break;
								case 17:
									vector.X = ui.mouseX + view.screenPosition.X;
									vector.Y = ui.mouseY + view.screenPosition.Y;
									break;
								}
								if (ptr->useStyle == 5)
								{
									itemRotation = (float)Math.Atan2(num28 * (float)direction, num27 * (float)direction);
									NetMessage.CreateMessage1(13, whoAmI);
									NetMessage.SendMessage();
									NetMessage.CreateMessage1(41, whoAmI);
									NetMessage.SendMessage();
								}
								if (num16 == 76)
								{
									num16 += Main.rand.Next(3);
									num30 /= 270f;
									if (num30 > 1f)
									{
										num30 = 1f;
									}
									float num31 = num27 + (float)Main.rand.Next(-40, 41) * 0.01f;
									float num32 = num28 + (float)Main.rand.Next(-40, 41) * 0.01f;
									num31 *= num30 + 0.25f;
									num32 *= num30 + 0.25f;
									int num33 = Projectile.NewProjectile(vector.X, vector.Y, num31, num32, num16, num19, num20, i, send: false);
									if (num33 >= 0)
									{
										Main.projectile[num33].ai1 = 1;
										num30 = num30 * 2f - 1f;
										if (num30 < -1f)
										{
											num30 = -1f;
										}
										else if (num30 > 1f)
										{
											num30 = 1f;
										}
										Main.projectile[num33].ai0 = num30;
										NetMessage.SendProjectile(num33);
									}
								}
								else if (ptr->type == 98 || ptr->type == 533)
								{
									float speedX = num27 + (float)Main.rand.Next(-40, 41) * 0.01f;
									float speedY = num28 + (float)Main.rand.Next(-40, 41) * 0.01f;
									Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, num16, num19, num20, i);
								}
								else if (ptr->type == 518)
								{
									float num34 = num27;
									float num35 = num28;
									num34 += (float)Main.rand.Next(-40, 41) * 0.04f;
									num35 += (float)Main.rand.Next(-40, 41) * 0.04f;
									Projectile.NewProjectile(vector.X, vector.Y, num34, num35, num16, num19, num20, i);
								}
								else if (ptr->type == 534)
								{
									for (int num36 = 0; num36 < 4; num36++)
									{
										float num37 = num27;
										float num38 = num28;
										num37 += (float)Main.rand.Next(-40, 41) * 0.05f;
										num38 += (float)Main.rand.Next(-40, 41) * 0.05f;
										Projectile.NewProjectile(vector.X, vector.Y, num37, num38, num16, num19, num20, i);
									}
								}
								else if (ptr->type == 434)
								{
									float num39 = num27;
									float num40 = num28;
									if (itemAnimation < 5)
									{
										num39 += (float)Main.rand.Next(-40, 41) * 0.01f;
										num40 += (float)Main.rand.Next(-40, 41) * 0.01f;
										num39 *= 1.1f;
										num40 *= 1.1f;
									}
									else if (itemAnimation < 10)
									{
										num39 += (float)Main.rand.Next(-20, 21) * 0.01f;
										num40 += (float)Main.rand.Next(-20, 21) * 0.01f;
										num39 *= 1.05f;
										num40 *= 1.05f;
									}
									Projectile.NewProjectile(vector.X, vector.Y, num39, num40, num16, num19, num20, i);
								}
								else if (ptr->buffType != 40)
								{
									int num41 = Projectile.NewProjectile(vector.X, vector.Y, num27, num28, num16, num19, num20, i);
									if (num41 >= 0 && num16 == 80)
									{
										Main.projectile[num41].ai0 = tileTargetX;
										Main.projectile[num41].ai1 = tileTargetY;
									}
								}
							}
							else if (ptr->useStyle == 5)
							{
								itemRotation = 0f;
								NetMessage.CreateMessage1(41, whoAmI);
								NetMessage.SendMessage();
							}
						}
						if (isLocal() && (ptr->type == 509 || ptr->type == 510) && itemAnimation > 0 && itemTime == 0 && controlUseItem)
						{
							int i2 = tileTargetX;
							int j2 = tileTargetY;
							if (ptr->type == 509)
							{
								int num42 = -1;
								for (int num43 = 0; num43 < 48; num43++)
								{
									if (inventory[num43].stack > 0 && inventory[num43].type == 530)
									{
										num42 = num43;
										break;
									}
								}
								if (num42 >= 0 && WorldGen.PlaceWire(i2, j2))
								{
									if (++ui.totalWires == 100)
									{
										ui.SetTriggerState(Trigger.PlacedLotsOfWires);
									}
									inventory[num42].stack--;
									if (inventory[num42].stack <= 0)
									{
										inventory[num42].Init();
									}
									itemTime = ptr->useTime;
									NetMessage.CreateMessage5(17, 5, tileTargetX, tileTargetY, 0);
									NetMessage.SendMessage();
								}
							}
							else if (WorldGen.KillWire(i2, j2))
							{
								if (ui.totalWires != 0)
								{
									ui.totalWires--;
								}
								itemTime = ptr->useTime;
								NetMessage.CreateMessage5(17, 6, tileTargetX, tileTargetY, 0);
								NetMessage.SendMessage();
							}
						}
						if (itemAnimation > 0 && itemTime == 0 && (ptr->type == 507 || ptr->type == 508))
						{
							itemTime = ptr->useTime;
							Vector2 vector2 = new Vector2(position.X + 10f, position.Y + 21f);
							float num44 = (float)(ui.mouseX + view.screenPosition.X) - vector2.X;
							float num45 = (float)(ui.mouseY + view.screenPosition.Y) - vector2.Y;
							float num46 = (float)Math.Sqrt(num44 * num44 + num45 * num45);
							num46 /= 270f;
							if (num46 > 1f)
							{
								num46 = 1f;
							}
							num46 = num46 * 2f - 1f;
							if (num46 < -1f)
							{
								num46 = -1f;
							}
							if (num46 > 1f)
							{
								num46 = 1f;
							}
							Main.harpNote = num46;
							int style = (ptr->type == 507) ? 35 : 26;
							Main.PlaySound(2, aabb.X, aabb.Y, style);
							NetMessage.CreateMessage1(58, whoAmI);
							NetMessage.SendMessage();
						}
						if (ptr->type >= 205 && ptr->type <= 207 && itemTime == 0 && itemAnimation > 0 && controlUseItem)
						{
							if (ptr->type == 205)
							{
								int lava = Main.tile[tileTargetX, tileTargetY].lava;
								int num47 = 0;
								for (int num48 = tileTargetX - 1; num48 <= tileTargetX + 1; num48++)
								{
									for (int num49 = tileTargetY - 1; num49 <= tileTargetY + 1; num49++)
									{
										if (Main.tile[num48, num49].lava == lava)
										{
											num47 += Main.tile[num48, num49].liquid;
										}
									}
								}
								if (Main.tile[tileTargetX, tileTargetY].liquid > 0 && num47 > 100)
								{
									int lava2 = Main.tile[tileTargetX, tileTargetY].lava;
									if (Main.tile[tileTargetX, tileTargetY].lava == 0)
									{
										ptr->SetDefaults(206);
									}
									else
									{
										ptr->SetDefaults(207);
									}
									Main.PlaySound(19, aabb.X, aabb.Y);
									itemTime = ptr->useTime;
									int num50 = Main.tile[tileTargetX, tileTargetY].liquid;
									Main.tile[tileTargetX, tileTargetY].liquid = 0;
									Main.tile[tileTargetX, tileTargetY].lava = 0;
									WorldGen.SquareTileFrame(tileTargetX, tileTargetY, 0);
									if (Main.netMode == 1)
									{
										NetMessage.sendWater(tileTargetX, tileTargetY);
									}
									else
									{
										Liquid.AddWater(tileTargetX, tileTargetY);
									}
									for (int num51 = tileTargetX - 1; num51 <= tileTargetX + 1; num51++)
									{
										for (int num52 = tileTargetY - 1; num52 <= tileTargetY + 1; num52++)
										{
											if (num50 < 256 && Main.tile[num51, num52].lava == lava)
											{
												int num53 = Main.tile[num51, num52].liquid;
												if (num53 + num50 > 255)
												{
													num53 = 255 - num50;
												}
												num50 += num53;
												Main.tile[num51, num52].liquid -= (byte)num53;
												Main.tile[num51, num52].lava = (byte)((Main.tile[num51, num52].liquid != 0) ? lava2 : 0);
												WorldGen.SquareTileFrame(num51, num52, 0);
												if (Main.netMode == 1)
												{
													NetMessage.sendWater(num51, num52);
												}
												else
												{
													Liquid.AddWater(num51, num52);
												}
											}
										}
									}
								}
							}
							else if (Main.tile[tileTargetX, tileTargetY].liquid < 200 && (Main.tile[tileTargetX, tileTargetY].active == 0 || !Main.tileSolidNotSolidTop[Main.tile[tileTargetX, tileTargetY].type]))
							{
								if (ptr->type == 207)
								{
									if (Main.tile[tileTargetX, tileTargetY].liquid == 0 || Main.tile[tileTargetX, tileTargetY].lava != 0)
									{
										Main.PlaySound(19, aabb.X, aabb.Y);
										Main.tile[tileTargetX, tileTargetY].lava = 32;
										Main.tile[tileTargetX, tileTargetY].liquid = byte.MaxValue;
										WorldGen.SquareTileFrame(tileTargetX, tileTargetY);
										ptr->SetDefaults(205);
										itemTime = ptr->useTime;
										NetMessage.sendWater(tileTargetX, tileTargetY);
									}
								}
								else if (Main.tile[tileTargetX, tileTargetY].liquid == 0 || Main.tile[tileTargetX, tileTargetY].lava == 0)
								{
									Main.PlaySound(19, aabb.X, aabb.Y);
									Main.tile[tileTargetX, tileTargetY].lava = 0;
									Main.tile[tileTargetX, tileTargetY].liquid = byte.MaxValue;
									WorldGen.SquareTileFrame(tileTargetX, tileTargetY);
									ptr->SetDefaults(205);
									itemTime = ptr->useTime;
									NetMessage.sendWater(tileTargetX, tileTargetY);
								}
							}
						}
						if (!channel)
						{
							toolTime = itemTime;
						}
						else if (--toolTime < 0)
						{
							if (ptr->pick > 0)
							{
								toolTime = ptr->useTime;
							}
							else
							{
								toolTime = (short)((float)(int)ptr->useTime * pickSpeed);
							}
						}
						if (ptr->pick > 0 || ptr->axe > 0 || ptr->hammer > 0)
						{
							flag3 = true;
							if (Main.tile[tileTargetX, tileTargetY].active != 0)
							{
								int type = Main.tile[tileTargetX, tileTargetY].type;
								if ((ptr->pick > 0 && !Main.tileAxe[type] && !Main.tileHammer[type]) || (ptr->axe > 0 && Main.tileAxe[type]) || (ptr->hammer > 0 && Main.tileHammer[type]))
								{
									flag3 = false;
								}
								if (toolTime == 0 && itemAnimation > 0 && controlUseItem)
								{
									if (hitTileX != tileTargetX || hitTileY != tileTargetY)
									{
										hitTile = 0;
										hitTileX = tileTargetX;
										hitTileY = tileTargetY;
									}
									if (Main.tileNoFail[type])
									{
										hitTile = 100;
									}
									if (type != 27)
									{
										if (Main.tileHammer[type])
										{
											flag3 = false;
											switch (type)
											{
											case 48:
												hitTile += (short)(ptr->hammer >> 1);
												break;
											case 129:
												hitTile += (short)(ptr->hammer << 1);
												break;
											default:
												hitTile = (short)(hitTile + ptr->hammer);
												break;
											}
											if (tileTargetY > Main.rockLayer && type == 77 && ptr->hammer < 60)
											{
												hitTile = 0;
											}
											if (ptr->hammer > 0)
											{
												if (type == 26 && (ptr->hammer < 80 || !Main.hardMode))
												{
													hitTile = 0;
													Hurt(statLife >> 1, -direction, pvp: false, quiet: false, Lang.deathMsg());
												}
												if (hitTile >= 100)
												{
													if (Main.netMode == 1 && type == 21)
													{
														WorldGen.KillTile(tileTargetX, tileTargetY, fail: true);
														NetMessage.CreateMessage5(17, 0, tileTargetX, tileTargetY, 1);
														NetMessage.SendMessage();
														NetMessage.CreateMessage2(34, tileTargetX, tileTargetY);
													}
													else
													{
														hitTile = 0;
														WorldGen.KillTile(tileTargetX, tileTargetY);
														NetMessage.CreateMessage5(17, 0, tileTargetX, tileTargetY, 0);
													}
												}
												else
												{
													WorldGen.KillTile(tileTargetX, tileTargetY, fail: true);
													NetMessage.CreateMessage5(17, 0, tileTargetX, tileTargetY, 1);
												}
												NetMessage.SendMessage();
												itemTime = ptr->useTime;
											}
										}
										else if (Main.tileAxe[type])
										{
											if (ptr->axe > 0)
											{
												switch (type)
												{
												case 30:
												case 124:
													hitTile += (short)(ptr->axe * 5);
													break;
												case 80:
													hitTile += (short)(ptr->axe * 3);
													break;
												default:
													hitTile = (short)(hitTile + ptr->axe);
													break;
												}
												if (hitTile >= 100)
												{
													hitTile = 0;
													if (type == 5)
													{
														ui.totalChops++;
														WorldGen.woodSpawned = 0u;
													}
													ui.totalAxed++;
													WorldGen.KillTile(tileTargetX, tileTargetY);
													NetMessage.CreateMessage5(17, 0, tileTargetX, tileTargetY, 0);
													NetMessage.SendMessage();
													if (type == 5)
													{
														ui.Statistics.incWoodStat(WorldGen.woodSpawned);
													}
												}
												else
												{
													WorldGen.KillTile(tileTargetX, tileTargetY, fail: true);
													NetMessage.CreateMessage5(17, 0, tileTargetX, tileTargetY, 1);
													NetMessage.SendMessage();
												}
												itemTime = ptr->useTime;
											}
										}
										else if (ptr->pick > 0)
										{
											switch (type)
											{
											case 25:
											case 37:
											case 41:
											case 43:
											case 44:
											case 58:
											case 107:
											case 117:
												hitTile += (short)(ptr->pick >> 1);
												switch (type)
												{
												case 41:
												case 43:
												case 44:
													if ((double)tileTargetX < (double)Main.maxTilesX * 0.25 || (double)tileTargetX > (double)Main.maxTilesX * 0.75)
													{
														hitTile = 0;
													}
													break;
												case 25:
												case 58:
												case 117:
													if (ptr->pick < 65)
													{
														hitTile = 0;
													}
													break;
												case 37:
													if (ptr->pick < 55)
													{
														hitTile = 0;
													}
													break;
												}
												break;
											case 108:
												hitTile += (short)((int)ptr->pick / 3);
												break;
											case 111:
												hitTile += (short)(ptr->pick >> 2);
												break;
											case 0:
											case 40:
											case 53:
											case 57:
											case 59:
											case 123:
												hitTile += (short)(ptr->pick << 1);
												break;
											default:
												hitTile = (short)(hitTile + ptr->pick);
												break;
											}
											if (type == 22 && tileTargetY > Main.worldSurface && ptr->pick < 55)
											{
												hitTile = 0;
											}
											else if (type == 56 && ptr->pick < 65)
											{
												hitTile = 0;
											}
											else if (type == 107 && ptr->pick < 100)
											{
												hitTile = 0;
											}
											else if (type == 108 && ptr->pick < 110)
											{
												hitTile = 0;
											}
											else if (type == 111 && ptr->pick < 120)
											{
												hitTile = 0;
											}
											if (hitTile >= 100 && (type == 2 || type == 23 || type == 60 || type == 70 || type == 109))
											{
												hitTile = 0;
											}
											if (hitTile >= 100)
											{
												switch (type)
												{
												case 0:
												case 1:
												case 53:
												case 57:
												case 58:
												case 59:
												case 112:
												case 116:
												case 123:
												case 147:
													ui.Statistics.incStat(StatisticEntry.Soils);
													break;
												case 7:
													ui.totalCopper++;
													ui.Statistics.incStat(StatisticEntry.Ore);
													break;
												case 6:
												case 8:
												case 9:
												case 22:
												case 56:
												case 107:
												case 108:
												case 111:
													ui.Statistics.incStat(StatisticEntry.Ore);
													break;
												case 63:
												case 64:
												case 65:
												case 66:
												case 67:
												case 68:
													ui.Statistics.incStat(StatisticEntry.Gems);
													break;
												}
												if (++ui.totalPicked == 10000)
												{
													ui.SetTriggerState(Trigger.RemovedLotsOfTiles);
												}
												hitTile = 0;
												WorldGen.KillTile(tileTargetX, tileTargetY);
												NetMessage.CreateMessage5(17, 0, tileTargetX, tileTargetY, 0);
												NetMessage.SendMessage();
											}
											else
											{
												WorldGen.KillTile(tileTargetX, tileTargetY, fail: true);
												NetMessage.CreateMessage5(17, 0, tileTargetX, tileTargetY, 1);
												NetMessage.SendMessage();
											}
											itemTime = (byte)((float)(int)ptr->useTime * pickSpeed);
										}
									}
								}
							}
							num54 = tileTargetX;
							num55 = tileTargetY;
							if ((Main.tile[num54, num55].wall == 0 || !WorldGen.CanKillWall(num54, num55)) && Main.tile[num54, num55].active == 0)
							{
								int num56 = -1;
								if (((ui.mouseX + view.screenPosition.X) & 0xF) < 8)
								{
									num56 = 0;
								}
								int num57 = -1;
								if (((ui.mouseY + view.screenPosition.Y) & 0xF) < 8)
								{
									num57 = 0;
								}
								for (int num58 = tileTargetX + num56; num58 <= tileTargetX + num56 + 1; num58++)
								{
									int num59 = tileTargetY + num57;
									while (num59 <= tileTargetY + num57 + 1)
									{
										num54 = num58;
										num55 = num59;
										int wall = Main.tile[num54, num55].wall;
										if (wall <= 0 || !WorldGen.CanKillWall(num54, num55))
										{
											num59++;
											continue;
										}
										goto IL_38b2;
									}
								}
							}
							goto IL_38b2;
						}
						goto IL_39b4;
					}
					goto IL_3ad2;
					IL_3ad2:
					if (ptr->damage >= 0 && ptr->type > 0 && !ptr->noMelee && itemAnimation > 0)
					{
						bool flag4 = false;
						Rectangle rectangle = new Rectangle(itemLocation.X, itemLocation.Y, (int)((float)itemWidth * ptr->scale), (int)((float)itemHeight * ptr->scale));
						if (direction == -1)
						{
							rectangle.X -= rectangle.Width;
						}
						if (gravDir == 1)
						{
							rectangle.Y -= rectangle.Height;
						}
						if (ptr->useStyle == 1)
						{
							if (itemAnimation < itemAnimationMax / 3)
							{
								if (direction == -1)
								{
									rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
								}
								rectangle.Width = (int)((double)rectangle.Width * 1.4);
								rectangle.Y += (int)((double)rectangle.Height * 0.5 * (double)gravDir);
								rectangle.Height = (int)((double)rectangle.Height * 1.1);
							}
							else if (itemAnimation >= (itemAnimationMax << 1) / 3)
							{
								if (direction == 1)
								{
									rectangle.X -= (int)((double)rectangle.Width * 1.2);
								}
								rectangle.Width *= 2;
								rectangle.Y -= (int)(((double)rectangle.Height * 1.4 - (double)rectangle.Height) * (double)gravDir);
								rectangle.Height = (int)((double)rectangle.Height * 1.4);
							}
						}
						else if (ptr->useStyle == 3)
						{
							if (itemAnimation > (itemAnimationMax << 1) / 3)
							{
								flag4 = true;
							}
							else
							{
								if (direction == -1)
								{
									rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
								}
								rectangle.Width = (int)((double)rectangle.Width * 1.4);
								rectangle.Y += (int)((double)rectangle.Height * 0.6);
								rectangle.Height = (int)((double)rectangle.Height * 0.6);
							}
						}
						if (!flag4)
						{
							if (ptr->type == 44 || ptr->type == 45 || ptr->type == 46 || ptr->type == 103 || ptr->type == 104)
							{
								if (Main.rand.Next(18) == 0)
								{
									Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 14, direction * 2, 0.0, 150, default(Color), 1.2999999523162842);
								}
							}
							else if (ptr->type == 273)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 14, direction * 2, 0.0, 150, default(Color), 1.3999999761581421);
								}
								Dust* ptr2 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 27, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.2000000476837158);
								if (ptr2 != null)
								{
									ptr2->noGravity = true;
									ptr2->velocity *= 0.5f;
								}
							}
							else if (ptr->type == 65)
							{
								if (Main.rand.Next(6) == 0)
								{
									Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 58, 0.0, 0.0, 150, default(Color), 1.2000000476837158);
								}
								if (Main.rand.Next(12) == 0)
								{
									Gore.NewGore(new Vector2(rectangle.X, rectangle.Y), default(Vector2), Main.rand.Next(16, 18));
								}
							}
							else if (ptr->type == 190 || ptr->type == 213)
							{
								Dust* ptr3 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 40, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 0, default(Color), 1.2000000476837158);
								if (ptr3 != null)
								{
									ptr3->noGravity = true;
								}
							}
							else if (ptr->type == 121)
							{
								Dust* ptr4 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.5);
								if (ptr4 != null)
								{
									ptr4->noGravity = true;
									ptr4->velocity.X *= 2f;
									ptr4->velocity.Y *= 2f;
								}
							}
							else if (ptr->type == 122 || ptr->type == 217)
							{
								Dust* ptr5 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.8999999761581421);
								if (ptr5 != null)
								{
									ptr5->noGravity = true;
								}
							}
							else if (ptr->type == 155)
							{
								Dust* ptr6 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 29, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 2.0);
								if (ptr6 != null)
								{
									ptr6->noGravity = true;
									ptr6->velocity.X *= 0.5f;
									ptr6->velocity.Y *= 0.5f;
								}
							}
							else if (ptr->type == 367 || ptr->type == 368)
							{
								if (Main.rand.Next(4) == 0)
								{
									Dust* ptr7 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 57, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, 100, default(Color), 1.1000000238418579);
									if (ptr7 != null)
									{
										ptr7->noGravity = true;
										ptr7->velocity.X *= 0.5f;
										ptr7->velocity.X += direction << 1;
										ptr7->velocity.Y *= 0.5f;
									}
								}
								if (Main.rand.Next(5) == 0)
								{
									Dust* ptr8 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 43, 0.0, 0.0, 254, default(Color), 0.30000001192092896);
									if (ptr8 != null)
									{
										ptr8->velocity.X = 0f;
										ptr8->velocity.Y = 0f;
									}
								}
							}
							else if (ptr->type >= 198 && ptr->type <= 203)
							{
								Lighting.addLight(rgb: (ptr->type == 198) ? new Vector3(0.05f, 0.25f, 0.6f) : ((ptr->type == 199) ? new Vector3(0.5f, 0.1f, 0.05f) : ((ptr->type == 200) ? new Vector3(0.05f, 0.5f, 0.1f) : ((ptr->type == 201) ? new Vector3(0.4f, 0.05f, 0.5f) : ((ptr->type == 202) ? new Vector3(0.4f, 0.45f, 0.5f) : new Vector3(0.45f, 0.45f, 0.05f))))), i: (int)((float)(itemLocation.X + 6) + velocity.X) >> 4, j: itemLocation.Y - 14 >> 4);
							}
							else if (ptr->type == 613)
							{
								Dust* ptr9 = Main.dust.NewDust(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, 6, velocity.X * 0.2f + (float)(direction * 3), velocity.Y * 0.2f, Main.rand.Next(61, 62), default(Color), 2.5);
								if (ptr9 != null)
								{
									ptr9->noGravity = true;
									ptr9->velocity.X *= 2f;
									ptr9->velocity.Y *= 2f;
								}
							}
							if (isLocal())
							{
								int dmg = (int)((float)ptr->damage * meleeDamage);
								float num60 = ptr->knockBack;
								if (kbGlove)
								{
									num60 *= 2f;
								}
								int num61 = rectangle.X >> 4;
								int num62 = (rectangle.X + rectangle.Width >> 4) + 1;
								int num63 = rectangle.Y >> 4;
								int num64 = (rectangle.Y + rectangle.Height >> 4) + 1;
								for (int num65 = num61; num65 < num62; num65++)
								{
									for (int num66 = num63; num66 < num64; num66++)
									{
										if (Main.tileCut[Main.tile[num65, num66].type] && Main.tile[num65, num66 + 1].type != 78)
										{
											WorldGen.KillTile(num65, num66);
											NetMessage.CreateMessage5(17, 0, num65, num66, 0);
											NetMessage.SendMessage();
										}
									}
								}
								for (int num67 = 0; num67 < 196; num67++)
								{
									NPC nPC = Main.npc[num67];
									if (nPC.active != 0 && nPC.immune[i] == 0 && attackCD == 0 && !nPC.dontTakeDamage && (!nPC.friendly || (nPC.type == 22 && killGuide)) && rectangle.Intersects(nPC.aabb) && (nPC.noTileCollide || Collision.CanHit(ref aabb, ref nPC.aabb)))
									{
										bool flag5 = Main.rand.Next(1, 101) <= meleeCrit;
										int num68 = Main.DamageVar(dmg);
										nPC.ApplyWeaponBuff(ptr->type);
										nPC.StrikeNPC(num68, num60, direction, flag5);
										NetMessage.SendNpcHurt(num67, num68, num60, direction, flag5);
										if (nPC.active == 0)
										{
											StatisticEntry statisticEntryFromNetID = Statistics.GetStatisticEntryFromNetID(nPC.netID);
											ui.Statistics.incStat(statisticEntryFromNetID);
											if (nPC.type == 1)
											{
												ui.totalSlimes++;
											}
										}
										nPC.immune[i] = (byte)itemAnimation;
										attackCD = (short)(itemAnimationMax / 3);
									}
								}
								if (hostile)
								{
									for (int num69 = 0; num69 < 8; num69++)
									{
										if (num69 != i && Main.player[num69].active != 0 && Main.player[num69].hostile && !Main.player[num69].immune && !Main.player[num69].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num69].team) && rectangle.Intersects(Main.player[num69].aabb) && Collision.CanHit(ref aabb, ref Main.player[num69].aabb))
										{
											bool flag6 = false;
											if (Main.rand.Next(1, 101) <= 10)
											{
												flag6 = true;
											}
											int num70 = Main.DamageVar(dmg);
											Main.player[num69].ApplyWeaponBuffPvP(ptr->type);
											Main.player[num69].Hurt(num70, direction, pvp: true, quiet: false, Lang.deathMsg(), flag6);
											NetMessage.SendPlayerHurt(num69, direction, num70, pvp: true, flag6, Lang.deathMsg(whoAmI));
											attackCD = (short)(itemAnimationMax / 3);
										}
									}
								}
							}
						}
					}
					if (itemTime == 0 && itemAnimation > 0)
					{
						if (ptr->healLife > 0)
						{
							statLife += ptr->healLife;
							itemTime = ptr->useTime;
							if (isLocal())
							{
								HealEffect(ptr->healLife);
							}
						}
						if (ptr->healMana > 0)
						{
							statMana += ptr->healMana;
							itemTime = ptr->useTime;
							if (isLocal())
							{
								ManaEffect(ptr->healMana);
							}
						}
						if (ptr->buffType > 0)
						{
							if (isLocal())
							{
								AddBuff(ptr->buffType, ptr->buffTime);
							}
							itemTime = ptr->useTime;
						}
						if (isLocal())
						{
							if (ptr->type == 361)
							{
								itemTime = ptr->useTime;
								Main.PlaySound(15, aabb.X, aabb.Y, 0);
								if (Main.netMode != 1)
								{
									if (Main.invasionType == 0)
									{
										Main.invasionDelay = 0;
										Main.StartInvasion();
									}
								}
								else
								{
									NetMessage.CreateMessage2(61, whoAmI, -1);
									NetMessage.SendMessage();
								}
							}
							else if (ptr->type == 602)
							{
								itemTime = ptr->useTime;
								Main.PlaySound(15, aabb.X, aabb.Y, 0);
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
									NetMessage.CreateMessage2(61, whoAmI, -2);
									NetMessage.SendMessage();
								}
							}
							else if (ptr->type == 43 || ptr->type == 619 || ptr->type == 70 || ptr->type == 544 || ptr->type == 556 || ptr->type == 557 || ptr->type == 560)
							{
								bool flag7 = false;
								for (int num71 = 0; num71 < 196; num71++)
								{
									if (Main.npc[num71].active != 0 && ((ptr->type == 43 && Main.npc[num71].type == 4) || (ptr->type == 619 && Main.npc[num71].type == 166) || (ptr->type == 70 && Main.npc[num71].type == 13) || (ptr->type == 560 && Main.npc[num71].type == 50) || (ptr->type == 544 && Main.npc[num71].type == 125) || (ptr->type == 544 && Main.npc[num71].type == 126) || (ptr->type == 556 && Main.npc[num71].type == 134) || (ptr->type == 557 && Main.npc[num71].type == 128)))
									{
										flag7 = true;
										break;
									}
								}
								if (flag7)
								{
									itemTime = ptr->useTime;
								}
								else if (ptr->type == 560)
								{
									itemTime = ptr->useTime;
									Main.PlaySound(15, aabb.X, aabb.Y, 0);
									if (Main.netMode != 1)
									{
										NPC.SpawnOnPlayer(this, 50);
									}
									else
									{
										NetMessage.CreateMessage2(61, whoAmI, 50);
										NetMessage.SendMessage();
									}
								}
								else if (ptr->type == 43)
								{
									if (!Main.gameTime.dayTime)
									{
										itemTime = ptr->useTime;
										Main.PlaySound(15, aabb.X, aabb.Y, 0);
										if (Main.netMode != 1)
										{
											NPC.SpawnOnPlayer(this, 4);
										}
										else
										{
											NetMessage.CreateMessage2(61, whoAmI, 4);
											NetMessage.SendMessage();
										}
									}
								}
								else if (ptr->type == 619)
								{
									if (!Main.gameTime.dayTime && Main.hardMode)
									{
										itemTime = ptr->useTime;
										Main.PlaySound(15, aabb.X, aabb.Y, 0);
										if (Main.netMode != 1)
										{
											NPC.SpawnOnPlayer(this, 166);
										}
										else
										{
											NetMessage.CreateMessage2(61, whoAmI, 166);
											NetMessage.SendMessage();
										}
									}
								}
								else if (ptr->type == 70)
								{
									if (zoneEvil)
									{
										itemTime = ptr->useTime;
										Main.PlaySound(15, aabb.X, aabb.Y, 0);
										if (Main.netMode != 1)
										{
											NPC.SpawnOnPlayer(this, 13);
										}
										else
										{
											NetMessage.CreateMessage2(61, whoAmI, 13);
											NetMessage.SendMessage();
										}
									}
								}
								else if (ptr->type == 544)
								{
									if (!Main.gameTime.dayTime)
									{
										itemTime = ptr->useTime;
										Main.PlaySound(15, aabb.X, aabb.Y, 0);
										if (Main.netMode != 1)
										{
											NPC.SpawnOnPlayer(this, 125);
											NPC.SpawnOnPlayer(this, 126);
										}
										else
										{
											NetMessage.CreateMessage2(61, whoAmI, 125);
											NetMessage.SendMessage();
											NetMessage.CreateMessage2(61, whoAmI, 126);
											NetMessage.SendMessage();
										}
									}
								}
								else if (ptr->type == 556)
								{
									if (!Main.gameTime.dayTime)
									{
										itemTime = ptr->useTime;
										Main.PlaySound(15, aabb.X, aabb.Y, 0);
										if (Main.netMode != 1)
										{
											NPC.SpawnOnPlayer(this, 134);
										}
										else
										{
											NetMessage.CreateMessage2(61, whoAmI, 134);
											NetMessage.SendMessage();
										}
									}
								}
								else if (ptr->type == 557 && !Main.gameTime.dayTime)
								{
									itemTime = ptr->useTime;
									Main.PlaySound(15, aabb.X, aabb.Y, 0);
									if (Main.netMode != 1)
									{
										NPC.SpawnOnPlayer(this, 127);
									}
									else
									{
										NetMessage.CreateMessage2(61, whoAmI, 127);
										NetMessage.SendMessage();
									}
								}
							}
						}
					}
					if (ptr->type == 50 && itemAnimation > 0)
					{
						if (itemTime == 0)
						{
							itemTime = ptr->useTime;
						}
						else if (itemTime == ptr->useTime >> 1)
						{
							for (int num72 = 0; num72 < 16; num72++)
							{
								Main.dust.NewDust(15, ref aabb, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.5);
							}
							grappling[0] = -1;
							grapCount = 0;
							for (int num73 = 0; num73 < 512; num73++)
							{
								if (Main.projectile[num73].active != 0 && Main.projectile[num73].owner == i && Main.projectile[num73].aiStyle == 7)
								{
									Main.projectile[num73].Kill();
								}
							}
							Spawn();
							for (int num74 = 0; num74 < 32; num74++)
							{
								Main.dust.NewDust(15, ref aabb, 0.0, 0.0, 150, default(Color), 1.5);
							}
						}
						else if (Main.rand.Next(3) == 0)
						{
							Main.dust.NewDust(15, ref aabb, 0.0, 0.0, 150, default(Color), 1.1000000238418579);
						}
					}
					if (isLocal())
					{
						if (itemTime == ptr->useTime && ptr->consumable)
						{
							bool flag8 = true;
							if (ptr->ranged && Main.rand.Next(100) < freeAmmoChance)
							{
								flag8 = false;
							}
							if (flag8)
							{
								if (ptr->stack > 0)
								{
									ptr->stack--;
								}
								if (ptr->stack <= 0)
								{
									itemTime = (byte)itemAnimation;
								}
							}
						}
						if (ptr->stack <= 0 && itemAnimation == 0)
						{
							ptr->Init();
						}
						if (selectedItem == 48 && itemAnimation != 0)
						{
							ui.mouseItem = *ptr;
						}
					}
					goto end_IL_0019;
					IL_38b2:
					if (flag3 && Main.tile[num54, num55].wall > 0 && toolTime == 0 && itemAnimation > 0 && controlUseItem && ptr->hammer > 0 && WorldGen.CanKillWall(num54, num55))
					{
						if (hitTileX != num54 || hitTileY != num55)
						{
							hitTile = 0;
							hitTileX = (short)num54;
							hitTileY = (short)num55;
						}
						hitTile += (short)(ptr->hammer + (ptr->hammer >> 1));
						if (hitTile >= 100)
						{
							hitTile = 0;
							WorldGen.KillWall(num54, num55);
							NetMessage.CreateMessage5(17, 2, num54, num55, 0);
						}
						else
						{
							WorldGen.KillWall(num54, num55, fail: true);
							NetMessage.CreateMessage5(17, 2, num54, num55, 1);
						}
						NetMessage.SendMessage();
						itemTime = (byte)(ptr->useTime >> 1);
					}
					goto IL_39b4;
					IL_39b4:
					if (ptr->type == 29)
					{
						if (itemTime == 0 && itemAnimation > 0 && statLifeMax < 400)
						{
							itemTime = ptr->useTime;
							statLifeMax += 20;
							statLife += 20;
							HealEffect(20);
						}
						if (statManaMax == 200 && statLifeMax == 400)
						{
							ui.SetTriggerState(Trigger.MaxHealthAndMana);
						}
					}
					else if (ptr->type == 109)
					{
						if (itemTime == 0 && itemAnimation > 0 && statManaMax < 200)
						{
							itemTime = ptr->useTime;
							statManaMax += 20;
							statMana += 20;
							ManaEffect(20);
						}
						if (statManaMax == 200 && statLifeMax == 400)
						{
							ui.SetTriggerState(Trigger.MaxHealthAndMana);
						}
					}
					else
					{
						PlaceThing();
					}
					goto IL_3ad2;
					end_IL_0019:;
				}
			}
			finally
			{
			}
		}

		public Color GetImmuneAlpha(Color newColor)
		{
			if (immuneAlpha > 125)
			{
				return default(Color);
			}
			double num = (double)(255 - immuneAlpha) * 0.00392156862745098;
			if (shadow > 0f)
			{
				num *= (double)(1f - shadow);
			}
			int r = (int)((double)(int)newColor.R * num);
			int g = (int)((double)(int)newColor.G * num);
			int b = (int)((double)(int)newColor.B * num);
			int a = (int)((double)(int)newColor.A * num);
			return new Color(r, g, b, a);
		}

		public Color GetImmuneAlpha2(Color newColor)
		{
			double num = (double)(255 - immuneAlpha) * 0.00392156862745098;
			if (shadow > 0f)
			{
				num *= (double)(1f - shadow);
			}
			int r = (int)((double)(int)newColor.R * num);
			int g = (int)((double)(int)newColor.G * num);
			int b = (int)((double)(int)newColor.B * num);
			int a = (int)((double)(int)newColor.A * num);
			return new Color(r, g, b, a);
		}

		public Color GetDeathAlpha(Color newColor)
		{
			int r = newColor.R + (int)((double)immuneAlpha * 0.9);
			int g = newColor.G + (int)((double)immuneAlpha * 0.5);
			int b = newColor.B + (int)((double)immuneAlpha * 0.5);
			int a = newColor.A + (int)((double)immuneAlpha * 0.4);
			return new Color(r, g, b, a);
		}

		public bool hasItemInInventory(int type)
		{
			for (int i = 0; i < 49; i++)
			{
				if (inventory[i].type == type)
				{
					return true;
				}
			}
			return false;
		}

		public void DropCoins()
		{
			for (int i = 0; i <= 48; i++)
			{
				if (inventory[i].CanBePlacedInCoinSlot())
				{
					short num = (short)(inventory[i].stack >> 1);
					num = (short)(inventory[i].stack - num);
					int num2 = Item.NewItem(aabb.X, aabb.Y, 20, 42, inventory[i].type, num);
					inventory[i].stack -= num;
					if (inventory[i].stack <= 0)
					{
						inventory[i].Init();
					}
					Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num2].noGrabDelay = 100;
					NetMessage.CreateMessage2(21, whoAmI, num2);
					NetMessage.SendMessage();
					if (i == 48)
					{
						ui.mouseItem = inventory[i];
					}
				}
			}
		}

		public void DropItems()
		{
			for (int i = 0; i < 49; i++)
			{
				if (inventory[i].type > 0 && inventory[i].netID != -13 && inventory[i].netID != -15 && inventory[i].netID != -16)
				{
					int num = Item.NewItem(aabb.X, aabb.Y, 20, 42, inventory[i].type);
					Main.item[num].netDefaults(inventory[i].netID, inventory[i].stack);
					Main.item[num].Prefix(inventory[i].prefix);
					Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
					Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
					Main.item[num].noGrabDelay = 100;
					NetMessage.CreateMessage2(21, whoAmI, num);
					NetMessage.SendMessage();
				}
				inventory[i].Init();
				if (i < 11)
				{
					if (armor[i].type > 0)
					{
						int num2 = Item.NewItem(aabb.X, aabb.Y, 20, 42, armor[i].type);
						Main.item[num2].netDefaults(armor[i].netID, armor[i].stack);
						Main.item[num2].Prefix(armor[i].prefix);
						Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
						Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
						Main.item[num2].noGrabDelay = 100;
						NetMessage.CreateMessage2(21, whoAmI, num2);
						NetMessage.SendMessage();
					}
					armor[i].Init();
				}
			}
			inventory[0].SetDefaults("Copper Shortsword");
			inventory[0].Prefix(-1);
			inventory[1].SetDefaults("Copper Pickaxe");
			inventory[1].Prefix(-1);
			inventory[2].SetDefaults("Copper Axe");
			inventory[2].Prefix(-1);
			ui.mouseItem.Init();
		}

		public Player ShallowCopy()
		{
			return (Player)MemberwiseClone();
		}

		public Player DeepCopy()
		{
			Player player = (Player)MemberwiseClone();
			player.buff = new Buff[10];
			player.armor = new Item[11];
			player.inventory = new Item[49];
			player.bank = new Chest();
			player.safe = new Chest();
			player.shadowPos = new Vector2[3];
			player.grappling = new short[20];
			player.adjTile = new Adj[135];
			player.grappling[0] = -1;
			for (int i = 0; i < 10; i++)
			{
				player.buff[i] = buff[i];
			}
			for (int j = 0; j < 11; j++)
			{
				player.armor[j] = armor[j];
			}
			for (int k = 0; k <= 48; k++)
			{
				player.inventory[k] = inventory[k];
			}
			for (int l = 0; l < 20; l++)
			{
				player.bank.item[l] = bank.item[l];
				player.safe.item[l] = safe.item[l];
			}
			player.spX = new short[200];
			player.spY = new short[200];
			player.spN = new string[200];
			player.spI = new int[200];
			for (int m = 0; m < 200; m++)
			{
				player.spX[m] = spX[m];
				player.spY[m] = spY[m];
				player.spN[m] = spN[m];
				player.spI[m] = spI[m];
			}
			return player;
		}

		public static bool CheckSpawn(int x, int y)
		{
			if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10)
			{
				return false;
			}
			if (Main.tile[x, y - 1].active == 0 || Main.tile[x, y - 1].type != 79)
			{
				return false;
			}
			for (int i = x - 1; i <= x + 1; i++)
			{
				for (int j = y - 3; j < y; j++)
				{
					if (Main.tile[i, j].active != 0 && Main.tileSolidNotSolidTop[Main.tile[i, j].type])
					{
						return false;
					}
				}
			}
			if (!WorldGen.StartRoomCheck(x, y - 1))
			{
				return false;
			}
			return true;
		}

		public void FindSpawn()
		{
			int num = 0;
			while (true)
			{
				if (num < 200)
				{
					if (spN[num] == null)
					{
						SpawnX = -1;
						SpawnY = -1;
						return;
					}
					if (spN[num] == Main.worldName && spI[num] == Main.worldID)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			SpawnX = spX[num];
			SpawnY = spY[num];
		}

		public void ChangeSpawn(int x, int y)
		{
			for (int i = 0; i < 200 && spN[i] != null; i++)
			{
				if (spN[i] == Main.worldName && spI[i] == Main.worldID)
				{
					for (int num = i; num > 0; num--)
					{
						spN[num] = spN[num - 1];
						spI[num] = spI[num - 1];
						spX[num] = spX[num - 1];
						spY[num] = spY[num - 1];
					}
					spX[0] = (short)x;
					spY[0] = (short)y;
					spN[0] = Main.worldName;
					spI[0] = Main.worldID;
					return;
				}
			}
			for (int num2 = 199; num2 > 0; num2--)
			{
				if (spN[num2 - 1] != null)
				{
					spN[num2] = spN[num2 - 1];
					spI[num2] = spI[num2 - 1];
					spX[num2] = spX[num2 - 1];
					spY[num2] = spY[num2 - 1];
				}
			}
			spX[0] = (short)x;
			spY[0] = (short)y;
			spN[0] = Main.worldName;
			spI[0] = Main.worldID;
		}

		public bool Save(string playerPath)
		{
			bool result = true;
			if (ui.HasPlayerStorage())
			{
				if (playerPath == null || playerPath.Length == 0)
				{
					return false;
				}
				using (MemoryStream memoryStream = new MemoryStream(2048))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						binaryWriter.Write((short)6);
						binaryWriter.Write(0u);
						binaryWriter.Write(characterName);
						binaryWriter.Write(difficulty);
						binaryWriter.Write(hair);
						binaryWriter.Write(male);
						binaryWriter.Write(statLife);
						binaryWriter.Write(statLifeMax);
						binaryWriter.Write(statMana);
						binaryWriter.Write(statManaMax);
						binaryWriter.Write(hairColor.R);
						binaryWriter.Write(hairColor.G);
						binaryWriter.Write(hairColor.B);
						binaryWriter.Write(skinColor.R);
						binaryWriter.Write(skinColor.G);
						binaryWriter.Write(skinColor.B);
						binaryWriter.Write(eyeColor.R);
						binaryWriter.Write(eyeColor.G);
						binaryWriter.Write(eyeColor.B);
						binaryWriter.Write(shirtColor.R);
						binaryWriter.Write(shirtColor.G);
						binaryWriter.Write(shirtColor.B);
						binaryWriter.Write(underShirtColor.R);
						binaryWriter.Write(underShirtColor.G);
						binaryWriter.Write(underShirtColor.B);
						binaryWriter.Write(pantsColor.R);
						binaryWriter.Write(pantsColor.G);
						binaryWriter.Write(pantsColor.B);
						binaryWriter.Write(shoeColor.R);
						binaryWriter.Write(shoeColor.G);
						binaryWriter.Write(shoeColor.B);
						lock (this)
						{
							for (int i = 0; i < 11; i++)
							{
								binaryWriter.Write(armor[i].netID);
								binaryWriter.Write(armor[i].prefix);
							}
							for (int j = 0; j < 48; j++)
							{
								binaryWriter.Write(inventory[j].netID);
								binaryWriter.Write(inventory[j].stack);
								binaryWriter.Write(inventory[j].prefix);
							}
							for (int k = 0; k < 20; k++)
							{
								binaryWriter.Write(bank.item[k].netID);
								binaryWriter.Write(bank.item[k].stack);
								binaryWriter.Write(bank.item[k].prefix);
							}
							for (int l = 0; l < 20; l++)
							{
								binaryWriter.Write(safe.item[l].netID);
								binaryWriter.Write(safe.item[l].stack);
								binaryWriter.Write(safe.item[l].prefix);
							}
							for (int m = 0; m < 10; m++)
							{
								binaryWriter.Write(buff[m].Type);
								binaryWriter.Write(buff[m].Time);
							}
						}
						binaryWriter.Write(pet);
						int num = itemsFound.Length + 7 >> 3;
						byte[] array = new byte[num];
						itemsFound.CopyTo(array, 0);
						binaryWriter.Write((ushort)num);
						binaryWriter.Write(array, 0, num);
						num = 43;
						recipesFound.CopyTo(array, 0);
						binaryWriter.Write((ushort)num);
						binaryWriter.Write(array, 0, num);
						recipesNew.CopyTo(array, 0);
						binaryWriter.Write(array, 0, num);
						num = 17;
						craftingStationsFound.CopyTo(array, 0);
						binaryWriter.Write((ushort)num);
						binaryWriter.Write(array, 0, num);
						for (int n = 0; n < 200; n++)
						{
							if (spN[n] == null)
							{
								binaryWriter.Write((short)(-1));
								break;
							}
							binaryWriter.Write(spX[n]);
							binaryWriter.Write(spY[n]);
							binaryWriter.Write(spI[n]);
							binaryWriter.Write(spN[n]);
						}
						CRC32 cRC = new CRC32();
						cRC.Update(memoryStream.GetBuffer(), 6, (int)memoryStream.Length - 6);
						binaryWriter.Seek(2, SeekOrigin.Begin);
						binaryWriter.Write(cRC.GetValue());
						Main.ShowSaveIcon();
						try
						{
							if (!ui.TestStorageSpace("Characters", playerPath, (int)memoryStream.Length))
							{
								result = false;
							}
							else
							{
								using (StorageContainer storageContainer = ui.OpenPlayerStorage("Characters"))
								{
									using (Stream stream = storageContainer.OpenFile(playerPath, FileMode.Create))
									{
										stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
										stream.Close();
									}
								}
							}
						}
						catch (IOException)
						{
							ui.WriteError();
							result = false;
						}
						catch (Exception)
						{
						}
						binaryWriter.Close();
						Main.HideSaveIcon();
						return result;
					}
				}
			}
			return result;
		}

		public void Load(StorageContainer c, string playerPath)
		{
			try
			{
				using (Stream stream = c.OpenFile(playerPath, FileMode.Open))
				{
					using (MemoryStream memoryStream = new MemoryStream((int)stream.Length))
					{
						memoryStream.SetLength(stream.Length);
						stream.Read(memoryStream.GetBuffer(), 0, (int)stream.Length);
						stream.Close();
						using (BinaryReader binaryReader = new BinaryReader(memoryStream))
						{
							int num = binaryReader.ReadInt16();
							if (num > 6)
							{
								throw new InvalidOperationException("Invalid version");
							}
							if (num >= 6)
							{
								CRC32 cRC = new CRC32();
								cRC.Update(memoryStream.GetBuffer(), 6, (int)memoryStream.Length - 6);
								if (cRC.GetValue() != binaryReader.ReadUInt32())
								{
									throw new InvalidOperationException("Invalid CRC32");
								}
							}
							characterName = binaryReader.ReadString();
							difficulty = binaryReader.ReadByte();
							hair = binaryReader.ReadByte();
							male = binaryReader.ReadBoolean();
							statLife = binaryReader.ReadInt16();
							statLifeMax = binaryReader.ReadInt16();
							if (statLifeMax > 400)
							{
								statLifeMax = 400;
							}
							if (statLife > statLifeMax)
							{
								statLife = statLifeMax;
							}
							statMana = binaryReader.ReadInt16();
							statManaMax = binaryReader.ReadInt16();
							if (statManaMax > 200)
							{
								statManaMax = 200;
							}
							if (statMana > 400)
							{
								statMana = 400;
							}
							if (num == 4)
							{
								binaryReader.ReadUInt32();
							}
							hairColor.R = binaryReader.ReadByte();
							hairColor.G = binaryReader.ReadByte();
							hairColor.B = binaryReader.ReadByte();
							skinColor.R = binaryReader.ReadByte();
							skinColor.G = binaryReader.ReadByte();
							skinColor.B = binaryReader.ReadByte();
							eyeColor.R = binaryReader.ReadByte();
							eyeColor.G = binaryReader.ReadByte();
							eyeColor.B = binaryReader.ReadByte();
							shirtColor.R = binaryReader.ReadByte();
							shirtColor.G = binaryReader.ReadByte();
							shirtColor.B = binaryReader.ReadByte();
							underShirtColor.R = binaryReader.ReadByte();
							underShirtColor.G = binaryReader.ReadByte();
							underShirtColor.B = binaryReader.ReadByte();
							pantsColor.R = binaryReader.ReadByte();
							pantsColor.G = binaryReader.ReadByte();
							pantsColor.B = binaryReader.ReadByte();
							shoeColor.R = binaryReader.ReadByte();
							shoeColor.G = binaryReader.ReadByte();
							shoeColor.B = binaryReader.ReadByte();
							for (int i = 0; i <= 10; i++)
							{
								int num2 = binaryReader.ReadInt16();
								int pre = binaryReader.ReadByte();
								if (num2 == 0)
								{
									armor[i].Init();
								}
								else
								{
									armor[i].netDefaults(num2);
									armor[i].Prefix(pre);
									itemsFound.Set(armor[i].type, value: true);
								}
							}
							for (int j = 0; j < 48; j++)
							{
								int num3 = binaryReader.ReadInt16();
								int stack = binaryReader.ReadInt16();
								int pre2 = binaryReader.ReadByte();
								if (num3 == 0)
								{
									inventory[j].Init();
								}
								else
								{
									inventory[j].netDefaults(num3, stack);
									inventory[j].Prefix(pre2);
									itemsFound.Set(inventory[j].type, value: true);
								}
							}
							for (int k = 0; k < 20; k++)
							{
								int num4 = binaryReader.ReadInt16();
								int stack2 = binaryReader.ReadInt16();
								int pre3 = binaryReader.ReadByte();
								if (num4 == 0)
								{
									bank.item[k].Init();
								}
								else
								{
									bank.item[k].netDefaults(num4, stack2);
									bank.item[k].Prefix(pre3);
									itemsFound.Set(bank.item[k].type, value: true);
								}
							}
							for (int l = 0; l < 20; l++)
							{
								int num5 = binaryReader.ReadInt16();
								int stack3 = binaryReader.ReadInt16();
								int pre4 = binaryReader.ReadByte();
								if (num5 == 0)
								{
									safe.item[l].Init();
								}
								else
								{
									safe.item[l].netDefaults(num5, stack3);
									safe.item[l].Prefix(pre4);
									itemsFound.Set(safe.item[l].type, value: true);
								}
							}
							for (int m = 0; m < 10; m++)
							{
								buff[m].Type = binaryReader.ReadUInt16();
								buff[m].Time = binaryReader.ReadUInt16();
							}
							if (num >= 1)
							{
								pet = binaryReader.ReadSByte();
							}
							if (num >= 2)
							{
								int count = binaryReader.ReadUInt16();
								itemsFound = new BitArray(binaryReader.ReadBytes(count));
								if (itemsFound.Length < 632)
								{
									itemsFound.Length = 632;
								}
								count = binaryReader.ReadUInt16();
								recipesFound = new BitArray(binaryReader.ReadBytes(count));
								recipesNew = new BitArray(binaryReader.ReadBytes(count));
								if (num >= 3)
								{
									count = binaryReader.ReadUInt16();
									craftingStationsFound = new BitArray(binaryReader.ReadBytes(count));
								}
								else
								{
									InitKnownCraftingStations();
								}
							}
							else
							{
								InitKnownItems();
							}
							for (int n = 0; n < 200; n++)
							{
								int num6 = binaryReader.ReadInt16();
								if (num6 == -1)
								{
									break;
								}
								spX[n] = (short)num6;
								spY[n] = binaryReader.ReadInt16();
								spI[n] = binaryReader.ReadInt32();
								spN[n] = binaryReader.ReadString();
							}
							binaryReader.Close();
						}
					}
				}
				PlayerFrame();
			}
			catch
			{
				Main.ShowSaveIcon();
				c.DeleteFile(playerPath);
				name = null;
				Main.HideSaveIcon();
			}
		}

		public bool HasItem(int type)
		{
			for (int i = 0; i < 48; i++)
			{
				if (type == inventory[i].type)
				{
					return true;
				}
			}
			return false;
		}

		public void UpdateGrappleItemSlot()
		{
			int num = -1;
			if (!noItems)
			{
				for (int i = 0; i < 48; i++)
				{
					if (inventory[i].shoot == 13 || inventory[i].shoot == 32 || inventory[i].shoot == 73)
					{
						num = i;
						break;
					}
				}
				if (num >= 0)
				{
					int shoot = inventory[num].shoot;
					if (shoot == 73)
					{
						int num2 = 0;
						for (int j = 0; j < 512; j++)
						{
							if ((Main.projectile[j].type == 73 || Main.projectile[j].type == 74) && Main.projectile[j].active != 0 && Main.projectile[j].owner == whoAmI && ++num2 > 1)
							{
								num = -1;
								break;
							}
						}
					}
					else
					{
						for (int k = 0; k < 512; k++)
						{
							if (Main.projectile[k].type == shoot && Main.projectile[k].active != 0 && Main.projectile[k].owner == whoAmI && Main.projectile[k].ai0 != 2f)
							{
								num = -1;
								break;
							}
						}
					}
				}
			}
			grappleItemSlot = (sbyte)num;
		}

		public void QuickGrapple()
		{
			int num = grappleItemSlot;
			if (num < 0)
			{
				return;
			}
			Main.PlaySound(2, aabb.X, aabb.Y, inventory[num].useSound);
			if (isLocal())
			{
				NetMessage.CreateMessage1(51, whoAmI);
				NetMessage.SendMessage();
			}
			int num2 = inventory[num].shoot;
			float shootSpeed = inventory[num].shootSpeed;
			int damage = inventory[num].damage;
			float knockBack = inventory[num].knockBack;
			switch (num2)
			{
			case 13:
			case 32:
			{
				grappling[0] = -1;
				grapCount = 0;
				for (int j = 0; j < 512; j++)
				{
					if (Main.projectile[j].active != 0 && Main.projectile[j].owner == whoAmI && Main.projectile[j].type == 13)
					{
						Main.projectile[j].Kill();
					}
				}
				break;
			}
			case 73:
			{
				for (int i = 0; i < 512; i++)
				{
					if (Main.projectile[i].active != 0 && Main.projectile[i].owner == whoAmI && Main.projectile[i].type == 73)
					{
						num2 = 74;
						break;
					}
				}
				break;
			}
			}
			Vector2 vector = new Vector2(position.X + 10f, position.Y + 21f);
			float x = controlDir.X;
			float y = controlDir.Y;
			float num3 = x * x + y * y;
			if (num3 > 0f)
			{
				num3 = shootSpeed / (float)Math.Sqrt(num3);
				x *= num3;
				y *= num3;
				Projectile.NewProjectile(vector.X, vector.Y, x, y, num2, damage, knockBack, whoAmI);
			}
		}

		public Player()
		{
			for (int i = 0; i <= 48; i++)
			{
				if (i < 11)
				{
					armor[i].Init();
				}
				inventory[i].Init();
			}
			for (int j = 0; j < 20; j++)
			{
				bank.item[j].Init();
				safe.item[j].Init();
			}
			grappling[0] = -1;
			inventory[0].SetDefaults("Copper Shortsword");
			inventory[1].SetDefaults("Copper Pickaxe");
			inventory[2].SetDefaults("Copper Axe");
			InitKnownItems();
			InitKnownCraftingStations();
		}

		public void InitKnownItems()
		{
			itemsFound.Set(9, value: true);
			itemsFound.Set(23, value: true);
			itemsFound.Set(3, value: true);
			itemsFound.Set(2, value: true);
			itemsFound.Set(38, value: true);
			itemsFound.Set(31, value: true);
			itemsFound.Set(68, value: true);
		}

		public void InitKnownCraftingStations()
		{
			craftingStationsFound.Set(13, value: true);
			craftingStationsFound.Set(15, value: true);
			craftingStationsFound.Set(18, value: true);
		}

		public void UpdateEditSign()
		{
			if (sign == -1)
			{
				ui.editSign = false;
				return;
			}
			ui.npcChatText = ui.GetInputText(ui.npcChatText);
			if (ui.inputTextEnter)
			{
				ui.inputTextEnter = false;
				Main.PlaySound(12);
				int num = sign;
				Main.sign[num].SetText(ui.npcChatText);
				ui.editSign = false;
				if (Main.netMode == 1)
				{
					NetMessage.CreateMessage2(47, whoAmI, num);
					NetMessage.SendMessage();
				}
			}
		}

		public void UpdateMouse()
		{
			int num = aabb.X + 10 - view.screenPosition.X;
			int num2 = aabb.Y + 21 - view.screenPosition.Y;
			if (num > view.viewWidth || num < 0 || num2 > 540 || num2 < 0)
			{
				ui.mouseX = (short)((view.viewWidth >> 1) + (direction << 5));
				ui.mouseY = 270;
			}
			else
			{
				int num3 = inventory[selectedItem].tileBoost + blockRange;
				int num4 = 5 + num3 << 4;
				relativeTargetX += ui.gpState.ThumbSticks.Right.X * 6f;
				relativeTargetY -= ui.gpState.ThumbSticks.Right.Y * 6f;
				if (relativeTargetX <= (float)(-num4))
				{
					relativeTargetX = -(num4 - 1);
				}
				else if (relativeTargetX >= (float)num4)
				{
					relativeTargetX = num4 - 1;
				}
				int num5 = (int)relativeTargetX;
				int num6 = num + num5;
				if (num6 < 0)
				{
					relativeTargetX -= num6;
					num6 = 0;
				}
				else if (num6 >= view.viewWidth)
				{
					int num7 = view.viewWidth - 1 - num6;
					relativeTargetX += num7;
					num6 += num7;
				}
				ui.mouseX = (short)num6;
				num4 = 4 + num3 << 4;
				if (relativeTargetY <= (float)(-num4))
				{
					relativeTargetY = -(num4 - 1);
				}
				else if (relativeTargetY >= (float)num4)
				{
					relativeTargetY = num4 - 1;
				}
				num6 = num2 + (int)relativeTargetY;
				if (num6 < 0)
				{
					relativeTargetY -= num6;
					num6 = 0;
				}
				else if (num6 >= 540)
				{
					int num8 = 539 - num6;
					relativeTargetY += num8;
					num6 += num8;
				}
				ui.mouseY = (short)num6;
			}
			controlDir.X = ui.mouseX - num;
			controlDir.Y = ui.mouseY - num2;
		}

		public unsafe void UpdateMouseSmart()
		{
			int num = aabb.X + 10 - view.screenPosition.X;
			int num2 = aabb.Y + 21 - view.screenPosition.Y;
			try
			{
				fixed (Item* ptr = &inventory[selectedItem])
				{
					Vector2 right = ui.gpState.ThumbSticks.Right;
					Vector2 vector = right;
					bool flag = right.LengthSquared() <= 0.015625f;
					if (!flag)
					{
						vector.Normalize();
					}
					Vector2 left = ui.gpState.ThumbSticks.Left;
					Vector2 vector2 = left;
					bool flag2 = left.LengthSquared() <= 0.015625f;
					if (!flag2)
					{
						vector2.Normalize();
					}
					int num3 = 0;
					if (ptr->type > 0)
					{
						if (flag)
						{
							if (flag2)
							{
								controlDir.X = direction;
								controlDir.Y = 0f;
							}
							else
							{
								controlDir.X = vector2.X;
								controlDir.Y = 0f - vector2.Y;
							}
						}
						else
						{
							controlDir.X = vector.X;
							controlDir.Y = 0f - vector.Y;
						}
						int num4 = ptr->tileBoost + blockRange;
						Vector2 vector3 = new Vector2((0f - controlDir.Y) * 16f, controlDir.X * 16f);
						int num5 = aabb.X;
						int num6 = aabb.Y + 21;
						if (controlDir.X >= 0f)
						{
							num5 += 20;
						}
						double num7 = num5;
						double num8 = num6;
						for (int num9 = 2; num9 >= 0; num9--)
						{
							double num10 = num7 * 0.0625;
							double num11 = num8 * 0.0625;
							int num12 = (int)num10 + (5 + num4) * ((!(controlDir.X < 0f)) ? 1 : (-1));
							int num13 = (int)num11 + (5 + num4) * ((!(controlDir.Y < 0f)) ? 1 : (-1));
							while (true)
							{
								int num14 = (int)num10;
								int num15 = (int)num11;
								int type = Main.tile[num14, num15].type;
								bool flag3 = (ptr->axe > 0 && Main.tileAxe[type]) || (ptr->hammer > 0 && (Main.tileHammer[type] || (Main.tile[num14, num15].wall > 0 && WorldGen.CanKillWall(num14, num15))));
								if (flag3 || ((ptr->pick > 0 || ptr->createTile >= 0) && Main.tile[num14, num15].active != 0 && Main.tileSolid[type]) || (ptr->createWall >= 0 && Main.tile[num14, num15].wall == 0))
								{
									if (flag3)
									{
										if (Main.tileAxe[type] && (!Main.tileAxe[Main.tile[num14, num15 - 1].type] || !Main.tileAxe[Main.tile[num14, num15 - 2].type]))
										{
											num14--;
											if (!Main.tileAxe[Main.tile[num14, num15].type] || !Main.tileAxe[Main.tile[num14, num15 - 1].type] || !Main.tileAxe[Main.tile[num14, num15 - 2].type])
											{
												num14 += 2;
												if (!Main.tileAxe[Main.tile[num14, num15].type] || !Main.tileAxe[Main.tile[num14, num15 - 1].type] || !Main.tileAxe[Main.tile[num14, num15 - 2].type])
												{
													num14--;
												}
											}
										}
									}
									else if (ptr->pick > 0)
									{
										if (Main.tileAxe[type] || Main.tileHammer[type] || !WorldGen.CanKillTile(num14, num15))
										{
											goto IL_055d;
										}
									}
									else if (ptr->createTile >= 0)
									{
										num14 = (int)(num10 - (double)controlDir.X);
										if (Main.tile[num14, num15].active != 0 && Main.tileSolid[type])
										{
											num14 = (int)num10;
											num15 = (int)(num11 - (double)controlDir.Y);
											if (Main.tile[num14, num15].active != 0 && Main.tileSolid[type])
											{
												num14 = (int)(num10 - (double)controlDir.X);
												if (Main.tile[num14, num15].active != 0 && Main.tileSolid[type])
												{
													num14 = (int)num10;
													num15 = (int)num11;
													goto IL_055d;
												}
											}
										}
										int j = num15;
										if (!WorldGen.CanPlaceTile(num14, ref j, ptr->createTile, -1))
										{
											num14 = (int)num10;
											num15 = (int)num11;
											goto IL_055d;
										}
									}
									smartLocation[num3].X = (num14 << 4) + 8;
									smartLocation[num3].Y = (num15 << 4) + 8;
									num3++;
									break;
								}
								goto IL_055d;
								IL_055d:
								if (num14 == num12 || num15 == num13)
								{
									break;
								}
								num10 += (double)controlDir.X;
								num11 += (double)controlDir.Y;
							}
							if (num9 == 1)
							{
								num7 -= (double)vector3.X;
								num8 -= (double)vector3.Y;
								num7 -= (double)vector3.X;
								num8 -= (double)vector3.Y;
							}
							else
							{
								num7 += (double)vector3.X;
								num8 += (double)vector3.Y;
							}
						}
						if (num3 > 0)
						{
							int num16 = 0;
							if (num3 > 1)
							{
								int num17 = num5;
								int num18 = num6;
								if (ptr->createTile == 4)
								{
									num17 += (int)(controlDir.X * 256f);
									num18 += (int)(controlDir.Y * 256f);
								}
								else if (ptr->pick <= 0 && ptr->hammer <= 0 && ptr->createWall < 0 && ptr->createTile < 0 && ptr->axe > 0)
								{
									num18 += 42;
								}
								int num19 = num17 - smartLocation[0].X;
								int num20 = num18 - smartLocation[0].Y;
								int num21 = num19 * num19 + num20 * num20;
								int num22 = 1;
								do
								{
									num19 = num17 - smartLocation[num22].X;
									num20 = num18 - smartLocation[num22].Y;
									int num23 = num19 * num19 + num20 * num20;
									if (num23 < num21)
									{
										num21 = num23;
										num16 = num22;
									}
								}
								while (++num22 < num3);
							}
							num = smartLocation[num16].X - view.screenPosition.X;
							num2 = smartLocation[num16].Y - view.screenPosition.Y;
						}
						else
						{
							ui.cursorHighlight = 0;
						}
					}
					if (flag)
					{
						if (flag2)
						{
							controlDir.X = direction << 4;
						}
						else if (left.LengthSquared() < 0.25f)
						{
							controlDir.X = vector2.X * 32f;
							controlDir.Y = vector2.Y * -32f;
						}
						else
						{
							controlDir.X = left.X * 80f;
							controlDir.Y = left.Y * -80f;
						}
					}
					else if (right.LengthSquared() < 0.25f)
					{
						controlDir.X = vector.X * 32f;
						controlDir.Y = vector.Y * -32f;
					}
					else
					{
						controlDir.X = right.X * 80f;
						controlDir.Y = right.Y * -80f;
					}
					if (num3 == 0 && ptr->shoot > 0)
					{
						num += (int)controlDir.X;
						num2 += (int)controlDir.Y;
					}
					ui.mouseX = (short)num;
					ui.mouseY = (short)num2;
				}
			}
			finally
			{
			}
		}

		public unsafe void Draw(WorldView drawView, bool isMenu = false, bool isIcon = false)
		{
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
			SpriteEffects spriteEffects = SpriteEffects.None;
			SpriteEffects spriteEffects2 = SpriteEffects.FlipHorizontally;
			Color newColor;
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
				newColor = Color.White;
				newColor2 = Color.White;
				newColor3 = Color.White;
				newColor4 = Color.White;
				newColor5 = shirtColor;
				newColor6 = underShirtColor;
				newColor7 = pantsColor;
				newColor8 = shoeColor;
				newColor9 = eyeColor;
				newColor10 = hairColor;
				newColor11 = skinColor;
				newColor12 = skinColor;
				c = skinColor;
			}
			else
			{
				int x = aabb.X + 10 >> 4;
				int y = (int)(position.Y + 21f) >> 4;
				int y2 = (int)(position.Y + 10.5f) >> 4;
				int y3 = (int)(position.Y + 31.5f) >> 4;
				newColor5 = GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y, shirtColor));
				newColor6 = GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y, underShirtColor));
				newColor7 = GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y, pantsColor));
				newColor8 = GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y3, shoeColor));
				newColor = GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y2));
				newColor2 = GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y));
				newColor3 = GetImmuneAlpha2(drawView.lighting.GetColorPlayer(x, y3));
				if (shadow > 0f)
				{
					newColor4 = default(Color);
					newColor9 = default(Color);
					newColor10 = default(Color);
					newColor11 = default(Color);
					newColor12 = default(Color);
					c = default(Color);
				}
				else
				{
					newColor4 = GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2));
					newColor9 = GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2, eyeColor));
					newColor10 = GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2, hairColor));
					newColor11 = GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y2, skinColor));
					newColor12 = GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y, skinColor));
					c = GetImmuneAlpha(drawView.lighting.GetColorPlayer(x, y3, skinColor));
				}
			}
			if (buffR != 1f || buffG != 1f || buffB != 1f)
			{
				if (onFire || onFire2)
				{
					newColor4 = GetImmuneAlpha(Color.White);
					newColor9 = GetImmuneAlpha(eyeColor);
					newColor10 = GetImmuneAlpha(hairColor);
					newColor11 = GetImmuneAlpha(skinColor);
					newColor12 = GetImmuneAlpha(skinColor);
					newColor5 = GetImmuneAlpha(shirtColor);
					newColor6 = GetImmuneAlpha(underShirtColor);
					newColor7 = GetImmuneAlpha(pantsColor);
					newColor8 = GetImmuneAlpha(shoeColor);
					newColor = GetImmuneAlpha(Color.White);
					newColor2 = GetImmuneAlpha(Color.White);
					newColor3 = GetImmuneAlpha(Color.White);
				}
				else
				{
					buffColor(ref newColor4, buffR, buffG, buffB);
					buffColor(ref newColor9, buffR, buffG, buffB);
					buffColor(ref newColor10, buffR, buffG, buffB);
					buffColor(ref newColor11, buffR, buffG, buffB);
					buffColor(ref newColor12, buffR, buffG, buffB);
					buffColor(ref newColor5, buffR, buffG, buffB);
					buffColor(ref newColor6, buffR, buffG, buffB);
					buffColor(ref newColor7, buffR, buffG, buffB);
					buffColor(ref newColor8, buffR, buffG, buffB);
					buffColor(ref newColor, buffR, buffG, buffB);
					buffColor(ref newColor2, buffR, buffG, buffB);
					buffColor(ref newColor3, buffR, buffG, buffB);
				}
			}
			if (gravDir == 1)
			{
				if (direction == 1)
				{
					spriteEffects = SpriteEffects.None;
					spriteEffects2 = SpriteEffects.None;
				}
				else
				{
					spriteEffects = SpriteEffects.FlipHorizontally;
					spriteEffects2 = SpriteEffects.FlipHorizontally;
				}
				if (!dead)
				{
					legPosition.Y = 0f;
					headPosition.Y = 0f;
					bodyPosition.Y = 0f;
				}
			}
			else
			{
				if (direction == 1)
				{
					spriteEffects = SpriteEffects.FlipVertically;
					spriteEffects2 = SpriteEffects.FlipVertically;
				}
				else
				{
					spriteEffects = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
					spriteEffects2 = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
				}
				if (!dead)
				{
					legPosition.Y = 6f;
					headPosition.Y = 6f;
					bodyPosition.Y = 6f;
				}
			}
			Vector2 pivot = new Vector2(20f, 42f);
			Vector2 pivot2 = new Vector2(20f, 28f);
			Vector2 pivot3 = new Vector2(20f, 22.4f);
			Vector2 pos = Vector2.Zero;
			if (merman)
			{
				headRotation = velocity.Y * (float)direction * 0.1f;
				if ((double)headRotation < -0.3)
				{
					headRotation = -0.3f;
				}
				if ((double)headRotation > 0.3)
				{
					headRotation = 0.3f;
				}
			}
			else if (!dead)
			{
				headRotation = 0f;
			}
			if (!isIcon)
			{
				if (wings > 0)
				{
					pos = new Vector2(aabb.X - drawView.screenPosition.X + 10 - 9 * direction, aabb.Y - drawView.screenPosition.Y + 21 + (gravDir << 1));
					int num = 1484 + wings;
					int num2 = SpriteSheet<_sheetSprites>.src[num].Height >> 2;
					SpriteSheet<_sheetSprites>.DrawRotated(num, ref pos, num2 * wingFrame, num2, newColor2, bodyRotation, spriteEffects);
				}
				if (!invis)
				{
					pos = new Vector2(20 + (int)bodyPosition.X + aabb.X - drawView.screenPosition.X - 20 + 10, 28 + (int)bodyPosition.Y + aabb.Y - drawView.screenPosition.Y + 42 - 56 + 4);
					SpriteSheet<_sheetSprites>.DrawRotated(1472, ref pos, bodyFrameY, 54, newColor12, bodyRotation, ref pivot2, spriteEffects);
					SpriteSheet<_sheetSprites>.DrawRotated(1473, ref pos, legFrameY, 54, c, legRotation, ref pivot2, spriteEffects);
				}
				pos = new Vector2((int)(position.X - (float)drawView.screenPosition.X - 20f + 10f), (int)(position.Y - (float)drawView.screenPosition.Y + 42f - 56f + 4f)) + legPosition + pivot;
				if (legs > 0 && legs < 28)
				{
					SpriteSheet<_sheetSprites>.DrawRotated(107 + legs, ref pos, legFrameY, 54, newColor3, legRotation, ref pivot, spriteEffects);
				}
				else if (!invis)
				{
					if (!male)
					{
						SpriteSheet<_sheetSprites>.DrawRotated(249, ref pos, legFrameY, 54, newColor7, legRotation, ref pivot, spriteEffects);
						SpriteSheet<_sheetSprites>.DrawRotated(252, ref pos, legFrameY, 54, newColor8, legRotation, ref pivot, spriteEffects);
					}
					else
					{
						SpriteSheet<_sheetSprites>.DrawRotated(1344, ref pos, legFrameY, 54, newColor7, legRotation, ref pivot, spriteEffects);
						SpriteSheet<_sheetSprites>.DrawRotated(1346, ref pos, legFrameY, 54, newColor8, legRotation, ref pivot, spriteEffects);
					}
				}
				pos.X = aabb.X - drawView.screenPosition.X + 10;
				pos.Y = aabb.Y - drawView.screenPosition.Y + 42 - 56 + 4 + 28;
				pos.X += bodyPosition.X;
				pos.Y += bodyPosition.Y;
				if (body > 0 && body < 29)
				{
					int id = (male ? 32 : 220) + body;
					SpriteSheet<_sheetSprites>.DrawRotated(id, ref pos, bodyFrameY, 54, newColor2, bodyRotation, ref pivot2, spriteEffects);
					if (!invis && ((body >= 10 && body <= 16) || body == 20))
					{
						SpriteSheet<_sheetSprites>.DrawRotated(1342, ref pos, bodyFrameY, 54, newColor12, bodyRotation, ref pivot2, spriteEffects);
					}
				}
				else if (!invis)
				{
					if (!male)
					{
						SpriteSheet<_sheetSprites>.DrawRotated(254, ref pos, bodyFrameY, 54, newColor6, bodyRotation, ref pivot2, spriteEffects);
						SpriteSheet<_sheetSprites>.DrawRotated(251, ref pos, bodyFrameY, 54, newColor5, bodyRotation, ref pivot2, spriteEffects);
					}
					else
					{
						SpriteSheet<_sheetSprites>.DrawRotated(1348, ref pos, bodyFrameY, 54, newColor6, bodyRotation, ref pivot2, spriteEffects);
						SpriteSheet<_sheetSprites>.DrawRotated(1345, ref pos, bodyFrameY, 54, newColor5, bodyRotation, ref pivot2, spriteEffects);
					}
					SpriteSheet<_sheetSprites>.DrawRotated(1342, ref pos, bodyFrameY, 54, newColor12, bodyRotation, ref pivot2, spriteEffects);
				}
			}
			pos.X = aabb.X - drawView.screenPosition.X - 20 + 10;
			pos.Y = aabb.Y - drawView.screenPosition.Y + 42 - 56 + 4;
			pos.X += headPosition.X + pivot3.X;
			pos.Y += headPosition.Y + pivot3.Y;
			if (!invis && head != 38)
			{
				SpriteSheet<_sheetSprites>.DrawRotated(1343, ref pos, bodyFrameY, 54, newColor11, headRotation, ref pivot3, spriteEffects);
				SpriteSheet<_sheetSprites>.DrawRotated(1267, ref pos, bodyFrameY, 54, newColor4, headRotation, ref pivot3, spriteEffects);
				SpriteSheet<_sheetSprites>.DrawRotated(1268, ref pos, bodyFrameY, 54, newColor9, headRotation, ref pivot3, spriteEffects);
			}
			if (head == 10 || head == 12 || head == 28)
			{
				SpriteSheet<_sheetSprites>.DrawRotated(60 + head, ref pos, bodyFrameY, 54, newColor, headRotation, ref pivot3, spriteEffects);
				if (!invis)
				{
					int num3 = bodyFrameY;
					num3 -= 336;
					if (num3 < 0)
					{
						num3 = 0;
					}
					SpriteSheet<_sheetSprites>.DrawRotated(1269 + hair, ref pos, num3, 54, newColor10, headRotation, ref pivot3, spriteEffects);
				}
			}
			else if (((head >= 14 && head <= 16) || head == 18 || head == 21 || (head >= 24 && head <= 26) || head == 40 || head == 44) && !invis)
			{
				int num4 = bodyFrameY;
				num4 -= 336;
				if (num4 < 0)
				{
					num4 = 0;
				}
				SpriteSheet<_sheetSprites>.DrawRotated(1305 + hair, ref pos, num4, 54, newColor10, headRotation, ref pivot3, spriteEffects);
			}
			if (head == 23)
			{
				int num5 = bodyFrameY;
				num5 -= 336;
				if (num5 < 0)
				{
					num5 = 0;
				}
				if (!invis)
				{
					SpriteSheet<_sheetSprites>.DrawRotated(1269 + hair, ref pos, num5, 54, newColor10, headRotation, ref pivot3, spriteEffects);
				}
				SpriteSheet<_sheetSprites>.DrawRotated(60 + head, ref pos, num5, 54, newColor, headRotation, ref pivot3, spriteEffects);
			}
			else if (head == 14)
			{
				int num6 = bodyFrameY;
				int num7 = 56;
				int num8 = 0;
				if (num6 == num7 * 6)
				{
					num7 -= 2;
				}
				else if (num6 == num7 * 7)
				{
					num8 = -2;
				}
				else if (num6 == num7 << 3)
				{
					num8 = -2;
				}
				else if (num6 == num7 * 9)
				{
					num8 = -2;
				}
				else if (num6 == num7 * 10)
				{
					num8 = -2;
				}
				else if (num6 == num7 * 13)
				{
					num7 -= 2;
				}
				else if (num6 == num7 * 14)
				{
					num8 = -2;
				}
				else if (num6 == num7 * 15)
				{
					num8 = -2;
				}
				else if (num6 == num7 << 4)
				{
					num8 = -2;
				}
				num6 += num8;
				pos.Y += num8;
				SpriteSheet<_sheetSprites>.DrawRotated(74, ref pos, num6, num7, newColor, headRotation, ref pivot3, spriteEffects);
			}
			else if (head > 0 && head < 48 && head != 28)
			{
				SpriteSheet<_sheetSprites>.DrawRotated(60 + head, ref pos, bodyFrameY, 54, newColor, headRotation, ref pivot3, spriteEffects);
			}
			else if (!invis)
			{
				int num9 = bodyFrameY;
				num9 -= 336;
				if (num9 < 0)
				{
					num9 = 0;
				}
				SpriteSheet<_sheetSprites>.DrawRotated(1269 + hair, ref pos, num9, 54, newColor10, headRotation, ref pivot3, spriteEffects);
			}
			if (isIcon)
			{
				return;
			}
			if (!isMenu)
			{
				if (heldProj >= 0)
				{
					Main.projectile[heldProj].Draw(drawView);
				}
				fixed (Item* ptr = &inventory[selectedItem])
				{
					int type = ptr->type;
					if (type > 0 && (itemAnimation > 0 || ptr->holdStyle > 0) && !dead && !ptr->noUseGraphic && (!wet || !ptr->noWet))
					{
						int num10 = 451 + type;
						int num11 = SpriteSheet<_sheetSprites>.src[num10].Width;
						Color color = drawView.lighting.GetColor((int)(position.X + 10f) >> 4, (int)(position.Y + 21f) >> 4);
						Color alpha = ptr->GetAlpha(color);
						pos.X = itemLocation.X - drawView.screenPosition.X;
						pos.Y = itemLocation.Y - drawView.screenPosition.Y;
						Vector2 pivot4 = default(Vector2);
						if (ptr->useStyle == 5)
						{
							int num12 = 10;
							Vector2 centerPivot = SpriteSheet<_sheetSprites>.GetCenterPivot(num10);
							pivot4.X = ((direction == -1) ? (num12 + num11) : (-num12));
							pivot4.Y = centerPivot.Y;
							switch (type)
							{
							case 95:
								centerPivot.Y += 2 * gravDir;
								break;
							case 96:
								num12 = -5;
								break;
							case 98:
								num12 = -5;
								centerPivot.Y -= 2 * gravDir;
								break;
							case 534:
								num12 = -2;
								centerPivot.Y += gravDir;
								break;
							case 533:
								num12 = -7;
								centerPivot.Y -= 2 * gravDir;
								break;
							case 506:
								num12 = 0;
								centerPivot.Y -= 2 * gravDir;
								break;
							case 494:
							case 508:
								num12 = -2;
								break;
							case 434:
								num12 = 0;
								centerPivot.Y -= 2 * gravDir;
								break;
							case 514:
								num12 = 0;
								centerPivot.Y += 3 * gravDir;
								break;
							case 435:
							case 436:
							case 481:
							case 578:
								num12 = -2;
								centerPivot.Y -= 2 * gravDir;
								break;
							case 197:
								num12 = -5;
								centerPivot.Y += 4 * gravDir;
								break;
							case 126:
								num12 = 4;
								centerPivot.Y += 4 * gravDir;
								break;
							case 127:
								num12 = 4;
								centerPivot.Y += 2 * gravDir;
								break;
							case 157:
								num12 = 6;
								centerPivot.Y += 2 * gravDir;
								break;
							case 160:
								num12 = -8;
								break;
							case 164:
							case 219:
								num12 = 2;
								centerPivot.Y += 4 * gravDir;
								break;
							case 165:
							case 272:
								num12 = 4;
								centerPivot.Y += 4 * gravDir;
								break;
							case 266:
								num12 = 0;
								centerPivot.Y += 2 * gravDir;
								break;
							case 281:
								num12 = 6;
								centerPivot.Y -= 6 * gravDir;
								break;
							}
							pos.X += centerPivot.X;
							pos.Y += centerPivot.Y;
							SpriteSheet<_sheetSprites>.Draw(num10, ref pos, alpha, itemRotation, ref pivot4, ptr->scale, spriteEffects2);
							if (ptr->color.PackedValue != 0)
							{
								SpriteSheet<_sheetSprites>.Draw(num10, ref pos, ptr->GetColor(color), itemRotation, ref pivot4, ptr->scale, spriteEffects2);
							}
						}
						else if (gravDir == -1)
						{
							pivot4.X = (num11 >> 1) - (num11 >> 1) * direction;
							pivot4.Y = 0f;
							SpriteSheet<_sheetSprites>.Draw(num10, ref pos, alpha, itemRotation, ref pivot4, ptr->scale, spriteEffects2);
							if (ptr->color.PackedValue != 0)
							{
								SpriteSheet<_sheetSprites>.Draw(num10, ref pos, ptr->GetColor(color), itemRotation, ref pivot4, ptr->scale, spriteEffects2);
							}
						}
						else
						{
							if (type == 507 || type == 425)
							{
								spriteEffects2 = ((gravDir == 1) ? ((direction != 1) ? (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically) : SpriteEffects.FlipVertically) : ((direction != 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None));
							}
							pivot4 = new Vector2((num11 >> 1) - (num11 >> 1) * direction, SpriteSheet<_sheetSprites>.src[num10].Height);
							SpriteSheet<_sheetSprites>.Draw(num10, ref pos, alpha, itemRotation, ref pivot4, ptr->scale, spriteEffects2);
							if (ptr->color.PackedValue != 0)
							{
								SpriteSheet<_sheetSprites>.Draw(num10, ref pos, ptr->GetColor(color), itemRotation, ref pivot4, ptr->scale, spriteEffects2);
							}
						}
					}
				}
			}
			pos.X = aabb.X - drawView.screenPosition.X + 10;
			pos.Y = aabb.Y - drawView.screenPosition.Y + 42 - 28 + 4;
			pos.X += bodyPosition.X;
			pos.Y += bodyPosition.Y;
			if (body > 0 && body < 29)
			{
				SpriteSheet<_sheetSprites>.DrawRotated(4 + body, ref pos, bodyFrameY, 54, newColor2, bodyRotation, ref pivot2, spriteEffects);
				if (!invis && ((body >= 10 && body <= 16) || body == 20))
				{
					SpriteSheet<_sheetSprites>.DrawRotated(1341, ref pos, bodyFrameY, 54, newColor12, bodyRotation, ref pivot2, spriteEffects);
				}
			}
			else if (!invis)
			{
				if (!male)
				{
					SpriteSheet<_sheetSprites>.DrawRotated(253, ref pos, bodyFrameY, 54, newColor6, bodyRotation, ref pivot2, spriteEffects);
					SpriteSheet<_sheetSprites>.DrawRotated(250, ref pos, bodyFrameY, 54, newColor5, bodyRotation, ref pivot2, spriteEffects);
				}
				else
				{
					SpriteSheet<_sheetSprites>.DrawRotated(1347, ref pos, bodyFrameY, 54, newColor6, bodyRotation, ref pivot2, spriteEffects);
				}
				SpriteSheet<_sheetSprites>.DrawRotated(1341, ref pos, bodyFrameY, 54, newColor12, bodyRotation, ref pivot2, spriteEffects);
			}
		}

		public void DrawGhost(WorldView drawView)
		{
			aabb.X = (int)position.X;
			aabb.Y = (int)position.Y;
			SpriteEffects e = (direction != 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			int num = (UI.mouseTextBrightness >> 1) + 100;
			Color c = GetImmuneAlpha(drawView.lighting.GetColorPlayer(aabb.X + 10 >> 4, aabb.Y + 21 >> 4, new Color(num, num, num, num)));
			int num2 = SpriteSheet<_sheetSprites>.src[255].Height >> 2;
			Vector2 pos = new Vector2(aabb.X - drawView.screenPosition.X, aabb.Y - drawView.screenPosition.Y);
			SpriteSheet<_sheetSprites>.Draw(255, ref pos, num2 * ((ghostFrameCounter >> 3) & 3), num2, c, e);
		}

		public Item armorSwap(ref Item newItem)
		{
			int num = 0;
			for (int i = 0; i < armor.Length; i++)
			{
				if (newItem.netID == armor[i].netID)
				{
					num = i;
				}
			}
			Item item = newItem;
			if (newItem.headSlot != -1)
			{
				int num2 = newItem.vanity ? 8 : 0;
				item = armor[num2];
				armor[num2] = newItem;
			}
			else if (newItem.bodySlot != -1)
			{
				int num3 = (!newItem.vanity) ? 1 : 9;
				item = armor[num3];
				armor[num3] = newItem;
			}
			else if (newItem.legSlot != -1)
			{
				int num4 = newItem.vanity ? 10 : 2;
				item = armor[num4];
				armor[num4] = newItem;
			}
			else
			{
				for (int j = 3; j < 8; j++)
				{
					if (armor[j].type == 0)
					{
						num = j;
						break;
					}
				}
				for (int k = 0; k < armor.Length; k++)
				{
					if (newItem.netID == armor[k].netID)
					{
						num = k;
					}
				}
				if (num >= 8)
				{
					num = 3;
				}
				else if (num < 3)
				{
					num = 7;
				}
				item = armor[num];
				armor[num] = newItem;
			}
			Main.PlaySound(7);
			return item;
		}

		public int CountInventory(int netID)
		{
			int num = 0;
			for (int num2 = 47; num2 >= 0; num2--)
			{
				if (inventory[num2].netID == netID)
				{
					num += inventory[num2].stack;
				}
			}
			return num;
		}

		public int CountEquipment(int netID)
		{
			int num = 0;
			for (int num2 = 10; num2 >= 0; num2--)
			{
				if (armor[num2].netID == netID)
				{
					num += inventory[num2].stack;
				}
			}
			return num;
		}

		public int CountPossession(int netID)
		{
			return CountInventory(netID) + CountEquipment(netID);
		}

		public bool IsNearCraftingStation(Recipe r)
		{
			for (int num = r.numRequiredTiles - 1; num >= 0; num--)
			{
				if (!adjTile[r.requiredTile[num]].i)
				{
					return false;
				}
			}
			if (!adjWater)
			{
				return !r.needWater;
			}
			return true;
		}

		public bool CanCraftRecipe(Recipe r)
		{
			if (Main.tutorialState < Tutorial.CRAFT_TORCH)
			{
				return false;
			}
			if (Main.tutorialState == Tutorial.CRAFT_TORCH && r.createItem.type != 8)
			{
				return false;
			}
			for (int num = r.numRequiredItems - 1; num >= 0; num--)
			{
				int num2 = r.requiredItem[num].stack;
				for (int num3 = 47; num3 >= 0; num3--)
				{
					if (inventory[num3].netID == r.requiredItem[num].netID)
					{
						num2 -= inventory[num3].stack;
						if (num2 <= 0)
						{
							break;
						}
					}
				}
				if (num2 > 0)
				{
					return false;
				}
			}
			return IsNearCraftingStation(r);
		}

		public bool DiscoveredRecipe(Recipe r)
		{
			for (int num = r.numRequiredItems - 1; num >= 0; num--)
			{
				if (!itemsFound.Get(r.requiredItem[num].type))
				{
					return false;
				}
			}
			for (int num2 = r.numRequiredTiles - 1; num2 >= 0; num2--)
			{
				if (!craftingStationsFound.Get(r.requiredTile[num2]))
				{
					return false;
				}
			}
			return true;
		}

		public void UpdateRecipes()
		{
			for (int num = 341; num >= 0; num--)
			{
				if (!recipesFound.Get(num) && DiscoveredRecipe(Main.recipe[num]))
				{
					recipesFound.Set(num, value: true);
					recipesNew.Set(num, value: true);
				}
			}
		}

		private void ApplyPetBuff(int itemType)
		{
			int i;
			if (pet >= 0)
			{
				int num = Projectile.petProj[pet];
				for (i = 0; i < 512; i++)
				{
					if (Main.projectile[i].type == num && Main.projectile[i].active != 0 && Main.projectile[i].owner == whoAmI)
					{
						Main.projectile[i].Kill();
						break;
					}
				}
				if (itemType == Projectile.petItem[pet])
				{
					DelBuff(Buff.ID.PET);
					return;
				}
			}
			i = Projectile.petItem.Length - 1;
			while (i >= 0 && itemType != Projectile.petItem[i])
			{
				i--;
			}
			pet = (sbyte)i;
			ui.petSpawnMask |= (byte)(1 << i);
			if (ui.petSpawnMask == 63)
			{
				ui.SetTriggerState(Trigger.SpawnedAllPets);
			}
			AddBuff(40, 3600);
		}

		private void SpawnPet()
		{
			int num = Projectile.petProj[pet];
			for (int i = 0; i < 512; i++)
			{
				if (Main.projectile[i].type == num && Main.projectile[i].active != 0 && Main.projectile[i].owner == whoAmI)
				{
					return;
				}
			}
			Projectile.NewProjectile(position.X + 10f, position.Y + 21f, 0f, 0f, num, 0, 0f, whoAmI);
		}

		public void AchievementTrigger(Trigger trigger)
		{
			if (isLocal())
			{
				ui.SetTriggerState(trigger);
				return;
			}
			NetMessage.CreateMessage2(64, whoAmI, (int)trigger);
			NetMessage.SendMessage(client);
		}

		public void IncreaseStatistic(StatisticEntry entry)
		{
			if (entry != StatisticEntry.Unknown)
			{
				if (isLocal())
				{
					ui.Statistics.incStat(entry);
				}
				else if (client != null)
				{
					NetMessage.CreateMessage2(65, whoAmI, (int)entry);
					NetMessage.SendMessage(client);
				}
			}
		}

		public void SunMoonTransition(bool wasBloodMoon)
		{
			totalSunMoonTransitions++;
			if (Main.gameTime.dayTime && totalSunMoonTransitions >= 2)
			{
				AchievementTrigger(Trigger.Sunrise);
				if (wasBloodMoon)
				{
					AchievementTrigger(Trigger.SunriseAfterBloodMoon);
				}
			}
		}

		private void FoundCraftingStation(int type)
		{
			if (ui.TriggerCheckEnabled(Trigger.UsedAllCraftingStations))
			{
				craftingStationsFound.Set(type, value: true);
				if (craftingStationsFound.Get(133) && craftingStationsFound.Get(134) && craftingStationsFound.Get(101) && craftingStationsFound.Get(114) && craftingStationsFound.Get(106) && craftingStationsFound.Get(96) && craftingStationsFound.Get(94) && craftingStationsFound.Get(86) && craftingStationsFound.Get(26) && craftingStationsFound.Get(13) && craftingStationsFound.Get(15) && craftingStationsFound.Get(18))
				{
					ui.SetTriggerState(Trigger.UsedAllCraftingStations);
				}
			}
		}

		private void IncreaseSteps()
		{
			if (ui != null)
			{
				if (++ui.totalSteps == 42000)
				{
					ui.SetTriggerState(Trigger.Walked42KM);
				}
				StatisticEntry entry = StatisticEntry.GroundTravel;
				if (wet)
				{
					entry = (lavaWet ? StatisticEntry.LavaTravel : StatisticEntry.WaterTravel);
				}
				ui.Statistics.incStat(entry);
			}
		}

		private void IncreaseAirTime()
		{
			if (ui == null)
			{
				return;
			}
			ui.currentAirTime++;
			if (ui.currentAirTime >= 60)
			{
				if (ui.currentAirTime == 60)
				{
					ui.totalAirTime += 60u;
				}
				else
				{
					ui.totalAirTime++;
				}
				if (ui.totalAirTime >= 216000)
				{
					ui.SetTriggerState(Trigger.InTheSky);
				}
				ui.airTravel += velocity.Length();
				if (ui.airTravel > 20f)
				{
					ui.airTravel -= 20f;
					ui.Statistics.incStat(StatisticEntry.AirTravel);
				}
			}
		}

		private void ResetAirTime()
		{
			if (ui != null)
			{
				ui.currentAirTime = 0u;
			}
		}

		public static void buffColor(ref Color newColor, double R, double G, double B)
		{
			newColor.R = (byte)((double)(int)newColor.R * R);
			newColor.G = (byte)((double)(int)newColor.G * G);
			newColor.B = (byte)((double)(int)newColor.B * B);
		}

		public void updateScreenPosition()
		{
			view.screenPosition.X = aabb.X + 10 - (view.viewWidth >> 1);
			view.screenPosition.Y = aabb.Y + 21 - 270;
		}

		public bool isLocal()
		{
			return view != null;
		}

		public void DrawInfo(WorldView view)
		{
			int num = aabb.X + 10 - view.screenPosition.X;
			int num2 = aabb.Y + 42 - view.screenPosition.Y;
			int num3 = (int)UI.DrawStringCT(UI.fontSmallOutline, name, num, num2, Main.teamColor[team]);
			int num4 = statLife - healthBarLife;
			if (num4 != 0)
			{
				if (Math.Abs(num4) > 1)
				{
					healthBarLife += (short)(num4 >> 2);
				}
				else
				{
					healthBarLife = statLife;
				}
			}
			Rectangle rect = default(Rectangle);
			rect.X = num - 22;
			rect.Y = num2 + num3 - 2;
			rect.Height = 10;
			rect.Width = 52;
			Color wINDOW_OUTLINE = UI.WINDOW_OUTLINE;
			Main.DrawRect(rect, wINDOW_OUTLINE, center: false);
			rect.X += 2;
			rect.Y += 2;
			rect.Width = healthBarLife * 48 / statLifeMax;
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
