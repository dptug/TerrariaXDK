namespace Terraria;

public sealed class Chest
{
	public const int MAX_ITEMS = 20;

	public Item[] item = new Item[20];

	public short x;

	public short y;

	public Chest()
	{
	}

	public Chest(int X, int Y)
	{
		x = (short)X;
		y = (short)Y;
		for (int i = 0; i < 20; i++)
		{
			item[i].Init();
		}
	}

	public unsafe static void Unlock(int X, int Y)
	{
		Main.PlaySound(22, X * 16, Y * 16);
		for (int i = X; i <= X + 1; i++)
		{
			for (int j = Y; j <= Y + 1; j++)
			{
				if ((Main.tile[i, j].frameX < 72 || Main.tile[i, j].frameX > 106) && (Main.tile[i, j].frameX < 144 || Main.tile[i, j].frameX > 178))
				{
					continue;
				}
				Main.tile[i, j].frameX -= 36;
				for (int k = 0; k < 3; k++)
				{
					if (null == Main.dust.NewDust(i * 16, j * 16, 16, 16, 11))
					{
						break;
					}
				}
			}
		}
	}

	public static int UsingChest(int i)
	{
		if (Main.chest[i] != null)
		{
			for (int j = 0; j < 8; j++)
			{
				if (Main.player[j].active != 0 && Main.player[j].chest == i)
				{
					return j;
				}
			}
		}
		return -1;
	}

	public static int FindChest(int X, int Y)
	{
		for (int i = 0; i < 1000; i++)
		{
			if (Main.chest[i] != null && Main.chest[i].x == X && Main.chest[i].y == Y)
			{
				return i;
			}
		}
		return -1;
	}

	public static int CreateChest(int X, int Y)
	{
		for (int i = 0; i < 1000; i++)
		{
			if (Main.chest[i] != null && Main.chest[i].x == X && Main.chest[i].y == Y)
			{
				return -1;
			}
		}
		for (int j = 0; j < 1000; j++)
		{
			if (Main.chest[j] == null)
			{
				Main.chest[j] = new Chest(X, Y);
				return j;
			}
		}
		return -1;
	}

	public static bool DestroyChest(int X, int Y)
	{
		for (int i = 0; i < 1000; i++)
		{
			if (Main.chest[i] == null || Main.chest[i].x != X || Main.chest[i].y != Y)
			{
				continue;
			}
			for (int j = 0; j < 20; j++)
			{
				if (Main.chest[i].item[j].type > 0 && Main.chest[i].item[j].stack > 0)
				{
					return false;
				}
			}
			Main.chest[i] = null;
			break;
		}
		return true;
	}

	public void AddShop(ref Item newItem)
	{
		for (int i = 0; i < 19; i++)
		{
			if (item[i].type != 0)
			{
				continue;
			}
			ref Item reference = ref item[i];
			reference = newItem;
			item[i].buyOnce = true;
			if (item[i].value > 0)
			{
				item[i].value = item[i].value / 5;
				if (item[i].value < 1)
				{
					item[i].value = 1;
				}
			}
			break;
		}
	}

	public static int GetShopOwnerHeadTextureId(int npcShop)
	{
		return npcShop switch
		{
			1 => 1257, 
			2 => 1261, 
			3 => 1260, 
			4 => 1259, 
			5 => 1262, 
			6 => 1264, 
			7 => 1265, 
			8 => 1263, 
			9 => 1266, 
			_ => -1, 
		};
	}

	public void SetupShop(int type, Player player = null)
	{
		int num = 20;
		while (num > 0)
		{
			item[--num].Init();
		}
		switch (type)
		{
		case 1:
			item[num++].SetDefaults(88);
			item[num++].SetDefaults(87);
			item[num++].SetDefaults(35);
			item[num++].netDefaults(-13);
			item[num++].netDefaults(-16);
			item[num++].SetDefaults(8);
			item[num++].SetDefaults(28);
			if (player != null && player.statManaMax >= 200)
			{
				item[num++].SetDefaults(110);
			}
			item[num++].SetDefaults(40);
			item[num++].SetDefaults(42);
			if (Main.gameTime.bloodMoon)
			{
				item[num++].SetDefaults(279);
			}
			if (!Main.gameTime.dayTime)
			{
				item[num++].SetDefaults(282);
			}
			if (NPC.downedBoss3)
			{
				item[num++].SetDefaults(346);
			}
			if (Main.hardMode)
			{
				item[num].SetDefaults(488);
			}
			break;
		case 2:
			item[num++].SetDefaults(97);
			if (Main.gameTime.bloodMoon || Main.hardMode)
			{
				item[num++].SetDefaults(278);
			}
			if ((NPC.downedBoss2 && !Main.gameTime.dayTime) || Main.hardMode)
			{
				item[num++].SetDefaults(47);
			}
			item[num++].SetDefaults(95);
			item[num++].SetDefaults(98);
			if (!Main.gameTime.dayTime)
			{
				item[num++].SetDefaults(324);
			}
			if (Main.hardMode)
			{
				item[num++].SetDefaults(534);
			}
			break;
		case 3:
			if (Main.gameTime.bloodMoon)
			{
				item[num++].SetDefaults(67);
				item[num++].SetDefaults(59);
			}
			else
			{
				item[num++].SetDefaults(66);
				item[num++].SetDefaults(62);
				item[num++].SetDefaults(63);
			}
			item[num++].SetDefaults(27);
			item[num++].SetDefaults(114);
			if (Main.hardMode)
			{
				item[num++].SetDefaults(369);
			}
			break;
		case 4:
			item[num++].SetDefaults(168);
			item[num++].SetDefaults(166);
			item[num++].SetDefaults(167);
			if (Main.hardMode)
			{
				item[num++].SetDefaults(265);
			}
			break;
		case 5:
			item[num].SetDefaults(254);
			num++;
			if (Main.gameTime.dayTime)
			{
				item[num].SetDefaults(242);
				num++;
			}
			if (Main.gameTime.moonPhase == 0)
			{
				item[num].SetDefaults(245);
				num++;
				item[num].SetDefaults(246);
				num++;
			}
			else if (Main.gameTime.moonPhase == 1)
			{
				item[num].SetDefaults(325);
				num++;
				item[num].SetDefaults(326);
				num++;
			}
			item[num].SetDefaults(269);
			num++;
			item[num].SetDefaults(270);
			num++;
			item[num].SetDefaults(271);
			num++;
			if (NPC.downedClown)
			{
				item[num].SetDefaults(503);
				num++;
				item[num].SetDefaults(504);
				num++;
				item[num].SetDefaults(505);
				num++;
			}
			if (Main.gameTime.bloodMoon)
			{
				item[num].SetDefaults(322);
				num++;
			}
			break;
		case 6:
			item[num].SetDefaults(128);
			num++;
			item[num].SetDefaults(486);
			num++;
			item[num].SetDefaults(398);
			num++;
			item[num].SetDefaults(84);
			num++;
			item[num].SetDefaults(407);
			num++;
			item[num].SetDefaults(161);
			num++;
			break;
		case 7:
			item[num].SetDefaults(487);
			num++;
			item[num].SetDefaults(496);
			num++;
			item[num].SetDefaults(500);
			num++;
			item[num].SetDefaults(507);
			num++;
			item[num].SetDefaults(508);
			num++;
			item[num].SetDefaults(531);
			num++;
			item[num].SetDefaults(576);
			num++;
			break;
		case 8:
			item[num].SetDefaults(509);
			num++;
			item[num].SetDefaults(510);
			num++;
			item[num].SetDefaults(530);
			num++;
			item[num].SetDefaults(513);
			num++;
			item[num].SetDefaults(538);
			num++;
			item[num].SetDefaults(529);
			num++;
			item[num].SetDefaults(541);
			num++;
			item[num].SetDefaults(542);
			num++;
			item[num].SetDefaults(543);
			num++;
			break;
		case 9:
			item[num].SetDefaults(588);
			num++;
			item[num].SetDefaults(589);
			num++;
			item[num].SetDefaults(590);
			num++;
			item[num].SetDefaults(597);
			num++;
			item[num].SetDefaults(598);
			num++;
			item[num].SetDefaults(596);
			num++;
			break;
		}
	}

	private void ConvertCoins(int id)
	{
		for (int i = 0; i < 20; i++)
		{
			if (item[i].stack != item[i].maxStack || !item[i].CanBePlacedInCoinSlot())
			{
				continue;
			}
			item[i].SetDefaults(item[i].type + 1);
			for (int j = 0; j < 20; j++)
			{
				if (j != i && item[j].type == item[i].type && item[j].stack < item[j].maxStack)
				{
					if (id >= 0)
					{
						NetMessage.CreateMessage2(32, id, j);
						NetMessage.SendMessage();
					}
					item[j].stack++;
					item[i].Init();
					ConvertCoins(id);
				}
			}
		}
	}

	public void LootAll(Player player)
	{
		int chest = player.chest;
		for (int i = 0; i < 20; i++)
		{
			if (item[i].type > 0)
			{
				player.GetItem(ref item[i]);
				if (chest >= 0)
				{
					NetMessage.CreateMessage2(32, chest, i);
					NetMessage.SendMessage();
				}
			}
		}
	}

	public void Deposit(Player player)
	{
		int chest = player.chest;
		for (int num = 40; num >= 10; num--)
		{
			if (player.inventory[num].stack > 0 && player.inventory[num].type > 0)
			{
				if (player.inventory[num].maxStack > 1)
				{
					for (int i = 0; i < 20; i++)
					{
						if (item[i].stack >= item[i].maxStack || player.inventory[num].netID != item[i].netID)
						{
							continue;
						}
						short num2 = player.inventory[num].stack;
						if (player.inventory[num].stack + item[i].stack > item[i].maxStack)
						{
							num2 = (short)(item[i].maxStack - item[i].stack);
						}
						player.inventory[num].stack -= num2;
						item[i].stack += num2;
						ConvertCoins(chest);
						Main.PlaySound(7);
						if (player.inventory[num].stack <= 0)
						{
							player.inventory[num].Init();
							if (chest >= 0)
							{
								NetMessage.CreateMessage2(32, chest, i);
								NetMessage.SendMessage();
							}
							break;
						}
						if (item[i].type == 0)
						{
							ref Item reference = ref item[i];
							reference = player.inventory[num];
							player.inventory[num].Init();
						}
						if (chest >= 0)
						{
							NetMessage.CreateMessage2(32, chest, i);
							NetMessage.SendMessage();
						}
					}
				}
				if (player.inventory[num].stack > 0)
				{
					for (int j = 0; j < 20; j++)
					{
						if (item[j].type == 0)
						{
							Main.PlaySound(7);
							ref Item reference2 = ref item[j];
							reference2 = player.inventory[num];
							player.inventory[num].Init();
							if (chest >= 0)
							{
								NetMessage.CreateMessage2(32, chest, j);
								NetMessage.SendMessage();
							}
							break;
						}
					}
				}
			}
		}
	}

	public void QuickStack(Player player)
	{
		int chest = player.chest;
		for (int i = 0; i < 20; i++)
		{
			if (item[i].type <= 0 || item[i].stack >= item[i].maxStack)
			{
				continue;
			}
			for (int j = 0; j < 48; j++)
			{
				if (item[i].netID == player.inventory[j].netID)
				{
					short num = player.inventory[j].stack;
					if (item[i].stack + num > item[i].maxStack)
					{
						num = (short)(item[i].maxStack - item[i].stack);
					}
					Main.PlaySound(7);
					item[i].stack += num;
					player.inventory[j].stack -= num;
					ConvertCoins(chest);
					if (player.inventory[j].stack == 0)
					{
						player.inventory[j].Init();
					}
					else if (item[i].type == 0)
					{
						ref Item reference = ref item[i];
						reference = player.inventory[j];
						player.inventory[j].Init();
					}
					if (chest >= 0)
					{
						NetMessage.CreateMessage2(32, chest, i);
						NetMessage.SendMessage();
					}
				}
			}
		}
	}
}
