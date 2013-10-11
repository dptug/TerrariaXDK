// Type: Terraria.Chest
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria
{
  public sealed class Chest
  {
    public Item[] item = new Item[20];
    public const int MAX_ITEMS = 20;
    public short x;
    public short y;

    public Chest()
    {
    }

    public Chest(int X, int Y)
    {
      this.x = (short) X;
      this.y = (short) Y;
      for (int index = 0; index < 20; ++index)
        this.item[index].Init();
    }

    public static unsafe void Unlock(int X, int Y)
    {
      Main.PlaySound(22, X * 16, Y * 16, 1);
      for (int index1 = X; index1 <= X + 1; ++index1)
      {
        for (int index2 = Y; index2 <= Y + 1; ++index2)
        {
          if ((int) Main.tile[index1, index2].frameX >= 72 && (int) Main.tile[index1, index2].frameX <= 106 || (int) Main.tile[index1, index2].frameX >= 144 && (int) Main.tile[index1, index2].frameX <= 178)
          {
            Main.tile[index1, index2].frameX -= (short) 36;
            int num = 0;
            while (num < 3 && IntPtr.Zero != (IntPtr) Main.dust.NewDust(index1 * 16, index2 * 16, 16, 16, 11, 0.0, 0.0, 0, new Color(), 1.0))
              ++num;
          }
        }
      }
    }

    public static int UsingChest(int i)
    {
      if (Main.chest[i] != null)
      {
        for (int index = 0; index < 8; ++index)
        {
          if ((int) Main.player[index].active != 0 && (int) Main.player[index].chest == i)
            return index;
        }
      }
      return -1;
    }

    public static int FindChest(int X, int Y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.chest[index] != null && (int) Main.chest[index].x == X && (int) Main.chest[index].y == Y)
          return index;
      }
      return -1;
    }

    public static int CreateChest(int X, int Y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.chest[index] != null && (int) Main.chest[index].x == X && (int) Main.chest[index].y == Y)
          return -1;
      }
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.chest[index] == null)
        {
          Main.chest[index] = new Chest(X, Y);
          return index;
        }
      }
      return -1;
    }

    public static bool DestroyChest(int X, int Y)
    {
      for (int index1 = 0; index1 < 1000; ++index1)
      {
        if (Main.chest[index1] != null && (int) Main.chest[index1].x == X && (int) Main.chest[index1].y == Y)
        {
          for (int index2 = 0; index2 < 20; ++index2)
          {
            if ((int) Main.chest[index1].item[index2].type > 0 && (int) Main.chest[index1].item[index2].stack > 0)
              return false;
          }
          Main.chest[index1] = (Chest) null;
          break;
        }
      }
      return true;
    }

    public void AddShop(ref Item newItem)
    {
      for (int index = 0; index < 19; ++index)
      {
        if ((int) this.item[index].type == 0)
        {
          this.item[index] = newItem;
          this.item[index].buyOnce = true;
          if (this.item[index].value <= 0)
            break;
          this.item[index].value = this.item[index].value / 5;
          if (this.item[index].value >= 1)
            break;
          this.item[index].value = 1;
          break;
        }
      }
    }

    public static int GetShopOwnerHeadTextureId(int npcShop)
    {
      switch (npcShop)
      {
        case 1:
          return 1257;
        case 2:
          return 1261;
        case 3:
          return 1260;
        case 4:
          return 1259;
        case 5:
          return 1262;
        case 6:
          return 1264;
        case 7:
          return 1265;
        case 8:
          return 1263;
        case 9:
          return 1266;
        default:
          return -1;
      }
    }

    public void SetupShop(int type, Player player = null)
    {
      int index1 = 20;
      while (index1 > 0)
        this.item[--index1].Init();
      int num1;
      if (type == 1)
      {
        Item[] objArray1 = this.item;
        int index2 = index1;
        int num2 = 1;
        int num3 = index2 + num2;
        objArray1[index2].SetDefaults(88, 1, false);
        Item[] objArray2 = this.item;
        int index3 = num3;
        int num4 = 1;
        int num5 = index3 + num4;
        objArray2[index3].SetDefaults(87, 1, false);
        Item[] objArray3 = this.item;
        int index4 = num5;
        int num6 = 1;
        int num7 = index4 + num6;
        objArray3[index4].SetDefaults(35, 1, false);
        Item[] objArray4 = this.item;
        int index5 = num7;
        int num8 = 1;
        int num9 = index5 + num8;
        objArray4[index5].netDefaults(-13, 1);
        Item[] objArray5 = this.item;
        int index6 = num9;
        int num10 = 1;
        int num11 = index6 + num10;
        objArray5[index6].netDefaults(-16, 1);
        Item[] objArray6 = this.item;
        int index7 = num11;
        int num12 = 1;
        int num13 = index7 + num12;
        objArray6[index7].SetDefaults(8, 1, false);
        Item[] objArray7 = this.item;
        int index8 = num13;
        int num14 = 1;
        int num15 = index8 + num14;
        objArray7[index8].SetDefaults(28, 1, false);
        if (player != null && (int) player.statManaMax >= 200)
          this.item[num15++].SetDefaults(110, 1, false);
        Item[] objArray8 = this.item;
        int index9 = num15;
        int num16 = 1;
        int num17 = index9 + num16;
        objArray8[index9].SetDefaults(40, 1, false);
        Item[] objArray9 = this.item;
        int index10 = num17;
        int num18 = 1;
        int index11 = index10 + num18;
        objArray9[index10].SetDefaults(42, 1, false);
        if (Main.gameTime.bloodMoon)
          this.item[index11++].SetDefaults(279, 1, false);
        if (!Main.gameTime.dayTime)
          this.item[index11++].SetDefaults(282, 1, false);
        if (NPC.downedBoss3)
          this.item[index11++].SetDefaults(346, 1, false);
        if (!Main.hardMode)
          return;
        this.item[index11].SetDefaults(488, 1, false);
      }
      else if (type == 2)
      {
        Item[] objArray1 = this.item;
        int index2 = index1;
        int num2 = 1;
        int num3 = index2 + num2;
        objArray1[index2].SetDefaults(97, 1, false);
        if (Main.gameTime.bloodMoon || Main.hardMode)
          this.item[num3++].SetDefaults(278, 1, false);
        if (NPC.downedBoss2 && !Main.gameTime.dayTime || Main.hardMode)
          this.item[num3++].SetDefaults(47, 1, false);
        Item[] objArray2 = this.item;
        int index3 = num3;
        int num4 = 1;
        int num5 = index3 + num4;
        objArray2[index3].SetDefaults(95, 1, false);
        Item[] objArray3 = this.item;
        int index4 = num5;
        int num6 = 1;
        int num7 = index4 + num6;
        objArray3[index4].SetDefaults(98, 1, false);
        if (!Main.gameTime.dayTime)
          this.item[num7++].SetDefaults(324, 1, false);
        if (!Main.hardMode)
          return;
        Item[] objArray4 = this.item;
        int index5 = num7;
        int num8 = 1;
        num1 = index5 + num8;
        objArray4[index5].SetDefaults(534, 1, false);
      }
      else if (type == 3)
      {
        int num2;
        if (Main.gameTime.bloodMoon)
        {
          Item[] objArray1 = this.item;
          int index2 = index1;
          int num3 = 1;
          int num4 = index2 + num3;
          objArray1[index2].SetDefaults(67, 1, false);
          Item[] objArray2 = this.item;
          int index3 = num4;
          int num5 = 1;
          num2 = index3 + num5;
          objArray2[index3].SetDefaults(59, 1, false);
        }
        else
        {
          Item[] objArray1 = this.item;
          int index2 = index1;
          int num3 = 1;
          int num4 = index2 + num3;
          objArray1[index2].SetDefaults(66, 1, false);
          Item[] objArray2 = this.item;
          int index3 = num4;
          int num5 = 1;
          int num6 = index3 + num5;
          objArray2[index3].SetDefaults(62, 1, false);
          Item[] objArray3 = this.item;
          int index4 = num6;
          int num7 = 1;
          num2 = index4 + num7;
          objArray3[index4].SetDefaults(63, 1, false);
        }
        Item[] objArray4 = this.item;
        int index5 = num2;
        int num8 = 1;
        int num9 = index5 + num8;
        objArray4[index5].SetDefaults(27, 1, false);
        Item[] objArray5 = this.item;
        int index6 = num9;
        int num10 = 1;
        int num11 = index6 + num10;
        objArray5[index6].SetDefaults(114, 1, false);
        if (!Main.hardMode)
          return;
        Item[] objArray6 = this.item;
        int index7 = num11;
        int num12 = 1;
        num1 = index7 + num12;
        objArray6[index7].SetDefaults(369, 1, false);
      }
      else if (type == 4)
      {
        Item[] objArray1 = this.item;
        int index2 = index1;
        int num2 = 1;
        int num3 = index2 + num2;
        objArray1[index2].SetDefaults(168, 1, false);
        Item[] objArray2 = this.item;
        int index3 = num3;
        int num4 = 1;
        int num5 = index3 + num4;
        objArray2[index3].SetDefaults(166, 1, false);
        Item[] objArray3 = this.item;
        int index4 = num5;
        int num6 = 1;
        int num7 = index4 + num6;
        objArray3[index4].SetDefaults(167, 1, false);
        if (!Main.hardMode)
          return;
        Item[] objArray4 = this.item;
        int index5 = num7;
        int num8 = 1;
        num1 = index5 + num8;
        objArray4[index5].SetDefaults(265, 1, false);
      }
      else if (type == 5)
      {
        this.item[index1].SetDefaults(254, 1, false);
        int index2 = index1 + 1;
        if (Main.gameTime.dayTime)
        {
          this.item[index2].SetDefaults(242, 1, false);
          ++index2;
        }
        if ((int) Main.gameTime.moonPhase == 0)
        {
          this.item[index2].SetDefaults(245, 1, false);
          int index3 = index2 + 1;
          this.item[index3].SetDefaults(246, 1, false);
          index2 = index3 + 1;
        }
        else if ((int) Main.gameTime.moonPhase == 1)
        {
          this.item[index2].SetDefaults(325, 1, false);
          int index3 = index2 + 1;
          this.item[index3].SetDefaults(326, 1, false);
          index2 = index3 + 1;
        }
        this.item[index2].SetDefaults(269, 1, false);
        int index4 = index2 + 1;
        this.item[index4].SetDefaults(270, 1, false);
        int index5 = index4 + 1;
        this.item[index5].SetDefaults(271, 1, false);
        int index6 = index5 + 1;
        if (NPC.downedClown)
        {
          this.item[index6].SetDefaults(503, 1, false);
          int index3 = index6 + 1;
          this.item[index3].SetDefaults(504, 1, false);
          int index7 = index3 + 1;
          this.item[index7].SetDefaults(505, 1, false);
          index6 = index7 + 1;
        }
        if (!Main.gameTime.bloodMoon)
          return;
        this.item[index6].SetDefaults(322, 1, false);
        num1 = index6 + 1;
      }
      else if (type == 6)
      {
        this.item[index1].SetDefaults(128, 1, false);
        int index2 = index1 + 1;
        this.item[index2].SetDefaults(486, 1, false);
        int index3 = index2 + 1;
        this.item[index3].SetDefaults(398, 1, false);
        int index4 = index3 + 1;
        this.item[index4].SetDefaults(84, 1, false);
        int index5 = index4 + 1;
        this.item[index5].SetDefaults(407, 1, false);
        int index6 = index5 + 1;
        this.item[index6].SetDefaults(161, 1, false);
        num1 = index6 + 1;
      }
      else if (type == 7)
      {
        this.item[index1].SetDefaults(487, 1, false);
        int index2 = index1 + 1;
        this.item[index2].SetDefaults(496, 1, false);
        int index3 = index2 + 1;
        this.item[index3].SetDefaults(500, 1, false);
        int index4 = index3 + 1;
        this.item[index4].SetDefaults(507, 1, false);
        int index5 = index4 + 1;
        this.item[index5].SetDefaults(508, 1, false);
        int index6 = index5 + 1;
        this.item[index6].SetDefaults(531, 1, false);
        int index7 = index6 + 1;
        this.item[index7].SetDefaults(576, 1, false);
        num1 = index7 + 1;
      }
      else if (type == 8)
      {
        this.item[index1].SetDefaults(509, 1, false);
        int index2 = index1 + 1;
        this.item[index2].SetDefaults(510, 1, false);
        int index3 = index2 + 1;
        this.item[index3].SetDefaults(530, 1, false);
        int index4 = index3 + 1;
        this.item[index4].SetDefaults(513, 1, false);
        int index5 = index4 + 1;
        this.item[index5].SetDefaults(538, 1, false);
        int index6 = index5 + 1;
        this.item[index6].SetDefaults(529, 1, false);
        int index7 = index6 + 1;
        this.item[index7].SetDefaults(541, 1, false);
        int index8 = index7 + 1;
        this.item[index8].SetDefaults(542, 1, false);
        int index9 = index8 + 1;
        this.item[index9].SetDefaults(543, 1, false);
        num1 = index9 + 1;
      }
      else
      {
        if (type != 9)
          return;
        this.item[index1].SetDefaults(588, 1, false);
        int index2 = index1 + 1;
        this.item[index2].SetDefaults(589, 1, false);
        int index3 = index2 + 1;
        this.item[index3].SetDefaults(590, 1, false);
        int index4 = index3 + 1;
        this.item[index4].SetDefaults(597, 1, false);
        int index5 = index4 + 1;
        this.item[index5].SetDefaults(598, 1, false);
        int index6 = index5 + 1;
        this.item[index6].SetDefaults(596, 1, false);
        num1 = index6 + 1;
      }
    }

    private void ConvertCoins(int id)
    {
      for (int index = 0; index < 20; ++index)
      {
        if ((int) this.item[index].stack == (int) this.item[index].maxStack && this.item[index].CanBePlacedInCoinSlot())
        {
          this.item[index].SetDefaults((int) this.item[index].type + 1, 1, false);
          for (int number2 = 0; number2 < 20; ++number2)
          {
            if (number2 != index && (int) this.item[number2].type == (int) this.item[index].type && (int) this.item[number2].stack < (int) this.item[number2].maxStack)
            {
              if (id >= 0)
              {
                NetMessage.CreateMessage2(32, id, number2);
                NetMessage.SendMessage();
              }
              ++this.item[number2].stack;
              this.item[index].Init();
              this.ConvertCoins(id);
            }
          }
        }
      }
    }

    public void LootAll(Player player)
    {
      int number = (int) player.chest;
      for (int number2 = 0; number2 < 20; ++number2)
      {
        if ((int) this.item[number2].type > 0)
        {
          player.GetItem(ref this.item[number2]);
          if (number >= 0)
          {
            NetMessage.CreateMessage2(32, number, number2);
            NetMessage.SendMessage();
          }
        }
      }
    }

    public void Deposit(Player player)
    {
      int num1 = (int) player.chest;
      for (int index = 40; index >= 10; --index)
      {
        if ((int) player.inventory[index].stack > 0 && (int) player.inventory[index].type > 0)
        {
          if ((int) player.inventory[index].maxStack > 1)
          {
            for (int number2 = 0; number2 < 20; ++number2)
            {
              if ((int) this.item[number2].stack < (int) this.item[number2].maxStack && (int) player.inventory[index].netID == (int) this.item[number2].netID)
              {
                short num2 = player.inventory[index].stack;
                if ((int) player.inventory[index].stack + (int) this.item[number2].stack > (int) this.item[number2].maxStack)
                  num2 = (short) ((int) this.item[number2].maxStack - (int) this.item[number2].stack);
                player.inventory[index].stack -= num2;
                this.item[number2].stack += num2;
                this.ConvertCoins(num1);
                Main.PlaySound(7);
                if ((int) player.inventory[index].stack <= 0)
                {
                  player.inventory[index].Init();
                  if (num1 >= 0)
                  {
                    NetMessage.CreateMessage2(32, num1, number2);
                    NetMessage.SendMessage();
                    break;
                  }
                  else
                    break;
                }
                else
                {
                  if ((int) this.item[number2].type == 0)
                  {
                    this.item[number2] = player.inventory[index];
                    player.inventory[index].Init();
                  }
                  if (num1 >= 0)
                  {
                    NetMessage.CreateMessage2(32, num1, number2);
                    NetMessage.SendMessage();
                  }
                }
              }
            }
          }
          if ((int) player.inventory[index].stack > 0)
          {
            for (int number2 = 0; number2 < 20; ++number2)
            {
              if ((int) this.item[number2].type == 0)
              {
                Main.PlaySound(7);
                this.item[number2] = player.inventory[index];
                player.inventory[index].Init();
                if (num1 >= 0)
                {
                  NetMessage.CreateMessage2(32, num1, number2);
                  NetMessage.SendMessage();
                  break;
                }
                else
                  break;
              }
            }
          }
        }
      }
    }

    public void QuickStack(Player player)
    {
      int num1 = (int) player.chest;
      for (int number2 = 0; number2 < 20; ++number2)
      {
        if ((int) this.item[number2].type > 0 && (int) this.item[number2].stack < (int) this.item[number2].maxStack)
        {
          for (int index = 0; index < 48; ++index)
          {
            if ((int) this.item[number2].netID == (int) player.inventory[index].netID)
            {
              short num2 = player.inventory[index].stack;
              if ((int) this.item[number2].stack + (int) num2 > (int) this.item[number2].maxStack)
                num2 = (short) ((int) this.item[number2].maxStack - (int) this.item[number2].stack);
              Main.PlaySound(7);
              this.item[number2].stack += num2;
              player.inventory[index].stack -= num2;
              this.ConvertCoins(num1);
              if ((int) player.inventory[index].stack == 0)
                player.inventory[index].Init();
              else if ((int) this.item[number2].type == 0)
              {
                this.item[number2] = player.inventory[index];
                player.inventory[index].Init();
              }
              if (num1 >= 0)
              {
                NetMessage.CreateMessage2(32, num1, number2);
                NetMessage.SendMessage();
              }
            }
          }
        }
      }
    }
  }
}
