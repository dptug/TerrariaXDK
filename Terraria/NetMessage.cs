// Type: Terraria.NetMessage
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Net;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Terraria.Achievements;

namespace Terraria
{
  public sealed class NetMessage
  {
    private static PacketWriter packetOut = new PacketWriter(65536);
    public static PacketReader packetIn = new PacketReader(65536);
    private static readonly byte[] PRIORITY = new byte[68]
    {
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 2,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 1,
      (byte) 3,
      (byte) 1,
      (byte) 2,
      (byte) 2,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1
    };

    static NetMessage()
    {
    }

    public static void CheckBytesServer()
    {
      LocalNetworkGamer localNetworkGamer = Netplay.gamer;
      if (localNetworkGamer == null)
        return;
      lock (NetMessage.packetIn)
      {
        while (localNetworkGamer.IsDataAvailable)
        {
          NetworkGamer local_1;
          localNetworkGamer.ReceiveData(NetMessage.packetIn, out local_1);
          NetMessage.GetData((local_1.Tag as Player).client);
        }
      }
    }

    public static void CheckBytesClient()
    {
      for (int index = Netplay.gamersWaitingForPlayerId.Count - 1; index >= 0; --index)
      {
        UI ui = Netplay.gamersWaitingForPlayerId[index];
        if (ui.localGamer.IsDataAvailable)
        {
          lock (NetMessage.packetIn)
          {
            NetworkGamer local_2;
            ui.localGamer.ReceiveData(NetMessage.packetIn, out local_2);
            int local_3 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int local_3_1 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            ui.JoinSession(local_3_1);
            ui.localGamer.Tag = (object) Main.player[local_3_1];
            NetMessage.SendHello(local_3_1);
            Netplay.gamersWaitingForPlayerId.RemoveAt(index);
            Netplay.gamersWaitingToSendSpawn.Add(ui);
            if (Netplay.clientState <= Netplay.ClientState.WAITING_FOR_PLAYER_ID)
              Netplay.clientState = Netplay.ClientState.WAITING_FOR_PLAYER_DATA_REQ;
          }
        }
      }
      if (Netplay.gamersWaitingToSendSpawn.Count > 0 && Netplay.clientState >= Netplay.ClientState.ANNOUNCING_SPAWN_LOCATION)
      {
        UI ui = Netplay.gamersWaitingToSendSpawn[0];
        Netplay.gamersWaitingToSendSpawn.RemoveAt(0);
        ui.player.FindSpawn();
        NetMessage.CreateMessage3(8, (int) ui.myPlayer, ui.player.SpawnX, ui.player.SpawnY);
        NetMessage.SendMessage();
        if (Netplay.clientState == Netplay.ClientState.ANNOUNCING_SPAWN_LOCATION)
          Netplay.clientState = Netplay.ClientState.WAITING_FOR_TILE_DATA;
      }
      else if (Netplay.gamersWaitingToSpawn.Count > 0 && Netplay.clientState >= Netplay.ClientState.PLAYING)
      {
        Main.JoinGame(Netplay.gamersWaitingToSpawn[0]);
        Netplay.gamersWaitingToSpawn.RemoveAt(0);
      }
      LocalNetworkGamer localNetworkGamer = Netplay.gamer;
      if (localNetworkGamer == null)
        return;
      lock (NetMessage.packetIn)
      {
        while (localNetworkGamer.IsDataAvailable)
        {
          NetworkGamer local_6;
          localNetworkGamer.ReceiveData(NetMessage.packetIn, out local_6);
          NetMessage.GetData((NetClient) null);
        }
      }
    }

    private static void WriteCompacted(uint value)
    {
      if (value < 128U)
      {
        ((BinaryWriter) NetMessage.packetOut).Write((byte) value);
      }
      else
      {
        uint num = (uint) ((int) value & (int) sbyte.MaxValue | 128 | (int) (value >> 7) << 8);
        if (value < 16384U)
        {
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) num);
        }
        else
        {
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) ((int) num & (int) short.MaxValue | 32768));
          value >>= 14;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) value);
        }
      }
    }

    private static uint ReadCompacted()
    {
      uint num = (uint) ((BinaryReader) NetMessage.packetIn).ReadByte();
      if (num >= 128U)
      {
        num = num & (uint) sbyte.MaxValue | (uint) ((BinaryReader) NetMessage.packetIn).ReadByte() << 7;
        if (num >= 16384U)
          num = num & 16383U | (uint) ((BinaryReader) NetMessage.packetIn).ReadByte() << 14;
      }
      return num;
    }

    public static void CreateMessage0(int msgType)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) msgType);
      switch (msgType)
      {
        case 57:
          ((BinaryWriter) NetMessage.packetOut).Write(WorldGen.tGood);
          ((BinaryWriter) NetMessage.packetOut).Write(WorldGen.tEvil);
          break;
        case 7:
          ((BinaryWriter) NetMessage.packetOut).Write(Main.gameTime.time);
          int num1 = (int) Main.gameTime.moonPhase << 2;
          if (Main.gameTime.dayTime)
            num1 |= 1;
          if (Main.gameTime.bloodMoon)
            num1 |= 2;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) num1);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) Main.maxTilesX);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) Main.maxTilesY);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) Main.spawnTileX);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) Main.spawnTileY);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) Main.worldSurface);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) Main.rockLayer);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.worldID);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.worldTimestamp);
          int num2 = WorldGen.shadowOrbSmashed ? 1 : 0;
          if (NPC.downedBoss1)
            num2 |= 2;
          if (NPC.downedBoss2)
            num2 |= 4;
          if (NPC.downedBoss3)
            num2 |= 8;
          if (Main.hardMode)
            num2 |= 16;
          if (NPC.downedClown)
            num2 |= 32;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) num2);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.worldName);
          break;
        case 11:
          if (Main.netMode != 2)
            break;
          GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
          int count = ((ReadOnlyCollection<NetworkGamer>) allGamers).Count;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) count);
          do
          {
            Player player = ((ReadOnlyCollection<NetworkGamer>) allGamers)[--count].Tag as Player;
            ((BinaryWriter) NetMessage.packetOut).Write(player.whoAmI);
          }
          while (count > 0);
          break;
      }
    }

    public static void CreateMessage1(int msgType, int number)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) msgType);
      switch (msgType)
      {
        case 36:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          int num1 = 0;
          if (Main.player[number].zoneEvil)
            num1 = 1;
          if (Main.player[number].zoneMeteor)
            num1 |= 2;
          if (Main.player[number].zoneDungeon)
            num1 |= 4;
          if (Main.player[number].zoneJungle)
            num1 |= 8;
          if (Main.player[number].zoneHoly)
            num1 |= 16;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) num1);
          break;
        case 40:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.player[number].talkNPC);
          break;
        case 41:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.player[number].itemRotation);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.player[number].itemAnimation);
          break;
        case 42:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.player[number].statMana);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.player[number].statManaMax);
          break;
        case 45:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) (number | (int) Main.player[number].team << 4));
          break;
        case 49:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          break;
        case 50:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          for (int index = 0; index < 10; ++index)
            ((BinaryWriter) NetMessage.packetOut).Write((byte) Main.player[number].buff[index].Type);
          break;
        case 51:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          break;
        case 54:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          for (int index = 0; index < 5; ++index)
          {
            uint num2 = (uint) Main.npc[number].buff[index].Type;
            ((BinaryWriter) NetMessage.packetOut).Write((byte) num2);
            if (num2 > 0U)
              NetMessage.WriteCompacted((uint) Main.npc[number].buff[index].Time);
          }
          break;
        case 56:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write(NPC.chrName[number]);
          break;
        case 58:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.harpNote);
          break;
        case 0:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          break;
        case 1:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) 1);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          break;
        case 2:
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number);
          break;
        case 3:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          break;
        case 4:
          Player player1 = Main.player[number];
          int num3 = number | (int) player1.hair << 4 | (int) player1.difficulty << 11;
          if (player1.male)
            num3 |= 1024;
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) num3);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.hairColor.R);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.hairColor.G);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.hairColor.B);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.skinColor.R);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.skinColor.G);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.skinColor.B);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.eyeColor.R);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.eyeColor.G);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.eyeColor.B);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.shirtColor.R);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.shirtColor.G);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.shirtColor.B);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.underShirtColor.R);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.underShirtColor.G);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.underShirtColor.B);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.pantsColor.R);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.pantsColor.G);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.pantsColor.B);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.shoeColor.R);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.shoeColor.G);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.shoeColor.B);
          ((BinaryWriter) NetMessage.packetOut).Write(player1.name);
          break;
        case 9:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          break;
        case 12:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((short) Main.player[number].SpawnX);
          ((BinaryWriter) NetMessage.packetOut).Write((short) Main.player[number].SpawnY);
          break;
        case 13:
          Player player2 = Main.player[number];
          int num4 = 0;
          if (player2.controlUp)
            num4 = 1;
          if (player2.controlDown)
            num4 |= 2;
          if (player2.controlLeft)
            num4 |= 4;
          if (player2.controlRight)
            num4 |= 8;
          if (player2.controlJump)
            num4 |= 16;
          if (player2.controlUseItem)
            num4 |= 32;
          if ((int) player2.direction == 1)
            number |= 64;
          if (num4 != 0)
          {
            ((BinaryWriter) NetMessage.packetOut).Write((byte) (number | 128));
            ((BinaryWriter) NetMessage.packetOut).Write((byte) num4);
            if ((num4 & 32) != 0)
              ((BinaryWriter) NetMessage.packetOut).Write(player2.selectedItem);
          }
          else
            ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          NetMessage.packetOut.Write(player2.position);
          HalfVector2 halfVector2_1 = new HalfVector2(player2.velocity);
          ((BinaryWriter) NetMessage.packetOut).Write(halfVector2_1.PackedValue);
          if (Main.netMode != 2 || (int) ++player2.netSkip <= 2)
            break;
          player2.netSkip = (sbyte) 0;
          break;
        case 16:
          int num5 = number | ((int) Main.player[number].statLife & 4095) << 4 | (int) Main.player[number].statLifeMax << 16;
          ((BinaryWriter) NetMessage.packetOut).Write(num5);
          break;
        case 22:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          int num6 = (int) Main.item[number].owner;
          if (num6 < 8)
          {
            Vector2 vector = Main.item[number].velocity;
            if ((double) vector.X != 0.0 || (double) vector.Y != 0.0)
              num6 |= 128;
            ((BinaryWriter) NetMessage.packetOut).Write((byte) num6);
            NetMessage.packetOut.Write(Main.item[number].position);
            if ((num6 & 128) == 0)
              break;
            HalfVector2 halfVector2_2 = new HalfVector2(vector);
            ((BinaryWriter) NetMessage.packetOut).Write(halfVector2_2.PackedValue);
            break;
          }
          else
          {
            ((BinaryWriter) NetMessage.packetOut).Write((byte) num6);
            break;
          }
        case 23:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          int num7 = (int) Main.npc[number].active != 0 ? Main.npc[number].life : 0;
          if (num7 <= 0)
          {
            ((BinaryWriter) NetMessage.packetOut).Write((byte) 0);
            Main.npc[number].netSkip = (short) 0;
            break;
          }
          else
          {
            NetMessage.WriteCompacted((uint) num7);
            ((BinaryWriter) NetMessage.packetOut).Write(Main.npc[number].netID);
            NetMessage.packetOut.Write(Main.npc[number].position);
            HalfVector2 halfVector2_2 = new HalfVector2(Main.npc[number].velocity);
            ((BinaryWriter) NetMessage.packetOut).Write(halfVector2_2.PackedValue);
            ((BinaryWriter) NetMessage.packetOut).Write((sbyte) ((int) Main.npc[number].target | ((int) Main.npc[number].direction & 3) << 4 | (int) Main.npc[number].directionY << 6));
            int num2 = 0;
            float num8 = Main.npc[number].ai0;
            if ((double) num8 != 0.0)
              num2 = 1;
            float num9 = Main.npc[number].ai1;
            if ((double) num9 != 0.0)
              num2 |= 2;
            float num10 = Main.npc[number].ai2;
            if ((double) num10 != 0.0)
              num2 |= 4;
            float num11 = Main.npc[number].ai3;
            if ((double) num11 != 0.0)
              num2 |= 8;
            ((BinaryWriter) NetMessage.packetOut).Write((byte) num2);
            if ((num2 & 1) != 0)
              ((BinaryWriter) NetMessage.packetOut).Write(num8);
            if ((num2 & 2) != 0)
              ((BinaryWriter) NetMessage.packetOut).Write(num9);
            if ((num2 & 4) != 0)
              ((BinaryWriter) NetMessage.packetOut).Write(num10);
            if ((num2 & 8) == 0)
              break;
            ((BinaryWriter) NetMessage.packetOut).Write(num11);
            break;
          }
        case 30:
          if (Main.player[number].hostile)
            number |= 128;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          break;
      }
    }

    public static unsafe void CreateMessage2(int msgType, int number, int number2)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) msgType);
      switch (msgType)
      {
        case 43:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((short) number2);
          break;
        case 47:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          NetMessage.WriteCompacted((uint) number2);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.sign[number2].x);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.sign[number2].y);
          Main.sign[number2].text.Write((BinaryWriter) NetMessage.packetOut);
          break;
        case 48:
          int index1 = number;
          int index2 = number2;
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) index1);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) (index2 | (int) Main.tile[index1, index2].lava << 10));
          ((BinaryWriter) NetMessage.packetOut).Write(Main.tile[index1, index2].liquid);
          break;
        case 59:
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          break;
        case 61:
          int num1 = number2;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((short) num1);
          break;
        case 64:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
          break;
        case 65:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
          break;
        case 24:
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          break;
        case 29:
          NetMessage.WriteCompacted((uint) number);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
          break;
        case 32:
          NetMessage.WriteCompacted((uint) number);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
          int num2 = (int) Main.chest[number].item[number2].netID;
          ((BinaryWriter) NetMessage.packetOut).Write((short) num2);
          if (num2 == 0)
            break;
          ((BinaryWriter) NetMessage.packetOut).Write(Main.chest[number].item[number2].prefix);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) Main.chest[number].item[number2].stack);
          break;
        case 33:
          ((BinaryWriter) NetMessage.packetOut).Write((short) (number2 << 5 | number));
          if (number2 < 0)
            break;
          ((BinaryWriter) NetMessage.packetOut).Write(Main.chest[number2].x);
          ((BinaryWriter) NetMessage.packetOut).Write(Main.chest[number2].y);
          break;
        case 34:
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          break;
        case 35:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          NetMessage.WriteCompacted((uint) number2);
          break;
        case 14:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) (number | number2 << 7));
          break;
        case 15:
          int index3 = number;
          int index4 = number2;
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) index3);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) index4);
          fixed (Tile* tilePtr = &Main.tile[index3, index4])
          {
            int num3 = (int) tilePtr->active;
            int num4 = num3;
            int num5 = (int) tilePtr->wall;
            if (num5 > 0)
              num4 |= 4;
            int num6 = Main.netMode != 2 ? 0 : (int) tilePtr->liquid;
            if (num6 > 0)
              num4 |= 8 | (int) tilePtr->lava;
            int num7 = num4 | tilePtr->wire;
            ((BinaryWriter) NetMessage.packetOut).Write((byte) num7);
            if (num3 != 0)
            {
              int index5 = (int) tilePtr->type;
              ((BinaryWriter) NetMessage.packetOut).Write((byte) index5);
              if (Main.tileFrameImportant[index5])
              {
                NetMessage.WriteCompacted((uint) tilePtr->frameX);
                NetMessage.WriteCompacted((uint) tilePtr->frameY);
              }
            }
            if (num5 > 0)
              ((BinaryWriter) NetMessage.packetOut).Write((byte) num5);
            if (num6 > 0)
              ((BinaryWriter) NetMessage.packetOut).Write((byte) num6);
          }
          break;
        case 21:
          int num8 = 0;
          int num9 = (int) Main.item[number2].stack;
          if (num9 > 0 && (int) Main.item[number2].active != 0)
            num8 = (int) Main.item[number2].netID;
          if (num8 == 0 && number2 >= 200)
          {
            NetMessage.ClearMessage();
            break;
          }
          else
          {
            ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
            ((BinaryWriter) NetMessage.packetOut).Write((short) (num8 << 5 | number));
            if (num8 == 0)
              break;
            ((BinaryWriter) NetMessage.packetOut).Write(Main.item[number2].prefix);
            ((BinaryWriter) NetMessage.packetOut).Write((byte) num9);
            NetMessage.packetOut.Write(Main.item[number2].position);
            HalfVector2 halfVector2 = new HalfVector2(Main.item[number2].velocity);
            ((BinaryWriter) NetMessage.packetOut).Write(halfVector2.PackedValue);
            break;
          }
        case 5:
          int index6 = number;
          int index7 = number2;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) index6);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) index7);
          int num10;
          int num11;
          int num12;
          if (index7 < 49)
          {
            num10 = (int) Main.player[index6].inventory[index7].stack;
            num11 = (int) Main.player[index6].inventory[index7].netID;
            num12 = (int) Main.player[index6].inventory[index7].prefix;
          }
          else
          {
            int index5 = index7 - 49;
            num10 = (int) Main.player[index6].armor[index5].stack;
            num11 = (int) Main.player[index6].armor[index5].netID;
            num12 = (int) Main.player[index6].armor[index5].prefix;
          }
          ((BinaryWriter) NetMessage.packetOut).Write((byte) num10);
          if (num10 <= 0)
            break;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) num12);
          ((BinaryWriter) NetMessage.packetOut).Write((short) num11);
          break;
        case 10:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
          int num13 = number * 40;
          int num14 = number2 * 30;
          Tile[,] tileArray;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
          {
            Tile* tilePtr2 = (Tile*) null;
            uint num3 = 0U;
            for (int index5 = num13; index5 < num13 + 40; ++index5)
            {
              Tile* tilePtr3 = tilePtr1 + (num14 + index5 * 1440);
              for (int index8 = 29; index8 >= 0; --index8)
              {
                if ((IntPtr) tilePtr2 != IntPtr.Zero && tilePtr3->isTheSameAsExcludingVisibility(ref *tilePtr2))
                {
                  ++num3;
                }
                else
                {
                  if ((IntPtr) tilePtr2 != IntPtr.Zero)
                    NetMessage.WriteCompacted(num3);
                  num3 = 0U;
                  tilePtr2 = tilePtr3;
                  int num4 = (int) tilePtr3->active;
                  int num5 = num4;
                  int num6 = (int) tilePtr3->wall;
                  if (num6 > 0)
                    num5 |= 4;
                  int num7 = (int) tilePtr3->liquid;
                  if (num7 > 0)
                    num5 |= 8 | (int) tilePtr3->lava;
                  int num15 = num5 | tilePtr3->wire;
                  ((BinaryWriter) NetMessage.packetOut).Write((byte) num15);
                  if (num4 != 0)
                  {
                    int index9 = (int) tilePtr3->type;
                    ((BinaryWriter) NetMessage.packetOut).Write((byte) index9);
                    if (Main.tileFrameImportant[index9])
                    {
                      NetMessage.WriteCompacted((uint) tilePtr3->frameX);
                      NetMessage.WriteCompacted((uint) tilePtr3->frameY);
                    }
                  }
                  if (num6 > 0)
                    ((BinaryWriter) NetMessage.packetOut).Write((byte) num6);
                  if (num7 > 0)
                    ((BinaryWriter) NetMessage.packetOut).Write((byte) num7);
                }
                ++tilePtr3;
              }
            }
            NetMessage.WriteCompacted(num3);
          }
          break;
      }
    }

    public static void CreateMessage3(int msgType, int number, int number2, int number3)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) msgType);
      switch (msgType)
      {
        case 31:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number3);
          break;
        case 46:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number3);
          break;
        case 52:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number3);
          break;
        case 53:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
          NetMessage.WriteCompacted((uint) number3);
          break;
        case 55:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number2);
          NetMessage.WriteCompacted((uint) number3);
          break;
        case 8:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((short) number2);
          ((BinaryWriter) NetMessage.packetOut).Write((short) number3);
          break;
        case 19:
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          ((BinaryWriter) NetMessage.packetOut).Write((sbyte) number3);
          break;
        case 20:
          int num1 = number2;
          int num2 = number3;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) num1);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) num2);
          for (int index1 = num1; index1 < num1 + number; ++index1)
          {
            for (int index2 = num2; index2 < num2 + number; ++index2)
            {
              int num3 = (int) Main.tile[index1, index2].active;
              int num4 = num3;
              int num5 = (int) Main.tile[index1, index2].wall;
              if (num5 > 0)
                num4 |= 4;
              int num6 = Main.netMode != 2 ? 0 : (int) Main.tile[index1, index2].liquid;
              if (num6 > 0)
                num4 |= 8 | (int) Main.tile[index1, index2].lava;
              int num7 = num4 | Main.tile[index1, index2].wire;
              ((BinaryWriter) NetMessage.packetOut).Write((byte) num7);
              if (num3 != 0)
              {
                int index3 = (int) Main.tile[index1, index2].type;
                ((BinaryWriter) NetMessage.packetOut).Write((byte) index3);
                if (Main.tileFrameImportant[index3])
                {
                  NetMessage.WriteCompacted((uint) Main.tile[index1, index2].frameX);
                  NetMessage.WriteCompacted((uint) Main.tile[index1, index2].frameY);
                }
              }
              if (num5 > 0)
                ((BinaryWriter) NetMessage.packetOut).Write((byte) num5);
              if (num6 > 0)
                ((BinaryWriter) NetMessage.packetOut).Write((byte) num6);
            }
          }
          break;
      }
    }

    public static void CreateMessage4(int msgType, int number, int number2, int number3, int number4)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) msgType);
      if (msgType != 60)
        return;
      ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
      ((BinaryWriter) NetMessage.packetOut).Write((short) number2);
      ((BinaryWriter) NetMessage.packetOut).Write((short) number3);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) number4);
    }

    public static void CreateMessage5(int msgType, int number, int number2, int number3, int number4, int number5 = 0)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) msgType);
      switch (msgType)
      {
        case 17:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number2);
          ((BinaryWriter) NetMessage.packetOut).Write((ushort) number3);
          if (number > 4)
            break;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number4);
          if (number != 1)
            break;
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number5);
          break;
        case 44:
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number);
          ((BinaryWriter) NetMessage.packetOut).Write((sbyte) number2);
          ((BinaryWriter) NetMessage.packetOut).Write((short) number3);
          ((BinaryWriter) NetMessage.packetOut).Write((byte) number4);
          ((BinaryWriter) NetMessage.packetOut).Write((uint) number5);
          break;
      }
    }

    public static void SendPlayerId(NetworkGamer gamer, int playerId)
    {
      NetMessage.CreateMessage1(0, playerId);
      NetMessage.SendMessage(gamer);
    }

    public static void SendHello(int playerId)
    {
      NetMessage.CreateMessage1(1, playerId);
      NetMessage.SendMessage();
    }

    public static void SendKick(NetClient client, int textId)
    {
      NetMessage.CreateMessage1(2, textId);
      NetMessage.SendMessage(client);
    }

    public static void SendPlayerInfoRequest(NetClient client, int playerId)
    {
      NetMessage.CreateMessage1(3, playerId);
      NetMessage.SendMessage(client);
    }

    public static void SendPlayerHurt(int playerId, int dir, int dmg, bool pvp, bool critical, uint deathText)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 26);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) playerId);
      ((BinaryWriter) NetMessage.packetOut).Write((sbyte) dir);
      ((BinaryWriter) NetMessage.packetOut).Write((short) dmg);
      ((BinaryWriter) NetMessage.packetOut).Write(pvp);
      ((BinaryWriter) NetMessage.packetOut).Write(critical);
      ((BinaryWriter) NetMessage.packetOut).Write(deathText);
      NetMessage.SendMessage();
    }

    public static void SendProjectile(int number, SendDataOptions sendOptions = SendDataOptions.Reliable)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 27);
      int num1 = 0;
      float num2 = Main.projectile[number].knockBack;
      if ((double) num2 != 0.0)
        num1 = 1;
      int num3 = (int) Main.projectile[number].damage;
      if (num3 != 0)
        num1 |= 2;
      float num4 = Main.projectile[number].ai0;
      if ((double) num4 != 0.0)
        num1 |= 4;
      int num5 = Main.projectile[number].ai1;
      if (num5 != 0)
        num1 |= 8;
      ((BinaryWriter) NetMessage.packetOut).Write((byte) ((uint) Main.projectile[number].owner | (uint) (num1 << 4)));
      ((BinaryWriter) NetMessage.packetOut).Write(Main.projectile[number].type);
      NetMessage.WriteCompacted((uint) Main.projectile[number].identity);
      NetMessage.packetOut.Write(Main.projectile[number].position);
      HalfVector2 halfVector2 = new HalfVector2(Main.projectile[number].velocity);
      ((BinaryWriter) NetMessage.packetOut).Write(halfVector2.PackedValue);
      if ((num1 & 1) != 0)
      {
        HalfSingle halfSingle = new HalfSingle(num2);
        ((BinaryWriter) NetMessage.packetOut).Write(halfSingle.PackedValue);
      }
      if ((num1 & 2) != 0)
        ((BinaryWriter) NetMessage.packetOut).Write((short) num3);
      if ((num1 & 4) != 0)
        ((BinaryWriter) NetMessage.packetOut).Write(num4);
      if ((num1 & 8) != 0)
        ((BinaryWriter) NetMessage.packetOut).Write((short) num5);
      NetMessage.SendProjectileMessage(ref Main.projectile[number], sendOptions);
    }

    public static void SendNpcHurt(int npcId, int dmg)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 28);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) npcId);
      ((BinaryWriter) NetMessage.packetOut).Write((short) dmg);
      NetMessage.SendMessage();
    }

    public static void SendNpcHurt(int npcId, int dmg, double kb, int dir, bool critical = false)
    {
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 28);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) npcId);
      ((BinaryWriter) NetMessage.packetOut).Write((short) dmg);
      if (dmg >= 0)
      {
        HalfSingle halfSingle = new HalfSingle((float) kb);
        ((BinaryWriter) NetMessage.packetOut).Write(halfSingle.PackedValue);
        dir <<= 1;
        if (critical)
          dir |= 1;
        ((BinaryWriter) NetMessage.packetOut).Write((sbyte) dir);
      }
      NetMessage.SendMessage();
    }

    public static void SendText(int textId, int r, int g, int b, int player)
    {
      if (player < 0 || Main.player[player].client == null)
      {
        Main.NewText(Lang.misc[textId], r, g, b);
        if (player >= 0 && Main.player[player].client == null)
          return;
      }
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 18);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) r);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) g);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) b);
      ((BinaryWriter) NetMessage.packetOut).Write((ushort) textId);
      if (player < 0)
        NetMessage.SendMessage();
      else
        NetMessage.SendMessage(Main.player[player].client);
    }

    public static void SendText(string prefix, int textId, int r, int g, int b, int player)
    {
      if (player < 0 || Main.player[player].client == null)
      {
        Main.NewText(prefix + Lang.misc[textId], r, g, b);
        if (player >= 0 && Main.player[player].client == null)
          return;
      }
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 37);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) r);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) g);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) b);
      ((BinaryWriter) NetMessage.packetOut).Write((ushort) textId);
      ((BinaryWriter) NetMessage.packetOut).Write(prefix);
      if (player < 0)
        NetMessage.SendMessage();
      else
        NetMessage.SendMessage(Main.player[player].client);
    }

    public static void SendText(int textId, string postfix, int r, int g, int b, int player)
    {
      if (player < 0 || Main.player[player].client == null)
      {
        Main.NewText(Lang.misc[textId] + postfix, r, g, b);
        if (player >= 0 && Main.player[player].client == null)
          return;
      }
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 38);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) r);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) g);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) b);
      ((BinaryWriter) NetMessage.packetOut).Write((ushort) textId);
      ((BinaryWriter) NetMessage.packetOut).Write(postfix);
      if (player < 0)
        NetMessage.SendMessage();
      else
        NetMessage.SendMessage(Main.player[player].client);
    }

    public static void SendText(string text, int r, int g, int b, int player)
    {
      if (player < 0 || Main.player[player].client == null)
      {
        Main.NewText(text, r, g, b);
        if (player >= 0 && Main.player[player].client == null)
          return;
      }
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 25);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) r);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) g);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) b);
      ((BinaryWriter) NetMessage.packetOut).Write(text);
      if (player < 0)
        NetMessage.SendMessage();
      else
        NetMessage.SendMessage(Main.player[player].client);
    }

    public static void SendDeathText(string name, uint deathText, int r, int g, int b)
    {
      Main.NewText(name + Lang.deathMsgString(deathText), r, g, b);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) 63);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) r);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) g);
      ((BinaryWriter) NetMessage.packetOut).Write((byte) b);
      ((BinaryWriter) NetMessage.packetOut).Write(deathText);
      ((BinaryWriter) NetMessage.packetOut).Write(name);
      NetMessage.SendMessage();
    }

    public static void SendMessage()
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryWriter) NetMessage.packetOut).BaseStream;
      int index1 = (int) memoryStream.GetBuffer()[0];
      SendDataOptions options = (SendDataOptions) NetMessage.PRIORITY[index1];
      if (Main.netMode == 1)
      {
        if (Netplay.session.Host != null)
        {
          try
          {
            Netplay.gamer.SendData(NetMessage.packetOut, options, Netplay.session.Host);
            goto label_10;
          }
          catch
          {
            goto label_10;
          }
        }
      }
      for (int index2 = Netplay.clients.Count - 1; index2 >= 0; --index2)
      {
        NetClient netClient = Netplay.clients[index2];
        if (netClient.IsReadyToReceive(memoryStream.GetBuffer()))
        {
          try
          {
            Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, NetMessage.packetOut.Length, options, netClient.gamer);
          }
          catch
          {
          }
        }
      }
label_10:
      memoryStream.Position = 0L;
      memoryStream.SetLength(0L);
    }

    private static void SendProjectileMessage(ref Projectile projectile, SendDataOptions sendOptions)
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryWriter) NetMessage.packetOut).BaseStream;
      if (Main.netMode == 1)
      {
        try
        {
          Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, NetMessage.packetOut.Length, sendOptions, Netplay.session.Host);
        }
        catch
        {
        }
      }
      else
      {
        for (int index = Netplay.clients.Count - 1; index >= 0; --index)
        {
          NetClient netClient = Netplay.clients[index];
          if (netClient.IsReadyToReceiveProjectile(ref projectile))
          {
            try
            {
              Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, NetMessage.packetOut.Length, sendOptions, netClient.gamer);
            }
            catch
            {
            }
          }
        }
      }
      memoryStream.Position = 0L;
      memoryStream.SetLength(0L);
    }

    public static void SendMessage(NetClient client)
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryWriter) NetMessage.packetOut).BaseStream;
      int index = (int) memoryStream.GetBuffer()[0];
      SendDataOptions options = (SendDataOptions) NetMessage.PRIORITY[index];
      switch (options)
      {
        case SendDataOptions.None:
          options = SendDataOptions.Reliable;
          break;
        case SendDataOptions.InOrder:
          options = SendDataOptions.ReliableInOrder;
          break;
      }
      try
      {
        Netplay.gamer.SendData(NetMessage.packetOut, options, client.gamer);
      }
      catch
      {
        memoryStream.Position = 0L;
        memoryStream.SetLength(0L);
      }
    }

    public static void SendMessageNoClear(NetClient client)
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryWriter) NetMessage.packetOut).BaseStream;
      int index = (int) memoryStream.GetBuffer()[0];
      SendDataOptions options = (SendDataOptions) NetMessage.PRIORITY[index];
      switch (options)
      {
        case SendDataOptions.None:
          options = SendDataOptions.Reliable;
          break;
        case SendDataOptions.InOrder:
          options = SendDataOptions.ReliableInOrder;
          break;
      }
      try
      {
        Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, NetMessage.packetOut.Length, options, client.gamer);
      }
      catch
      {
      }
    }

    public static void ClearMessage()
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryWriter) NetMessage.packetOut).BaseStream;
      memoryStream.Position = 0L;
      memoryStream.SetLength(0L);
    }

    public static void SendMessageIgnore(NetClient ignoreClient)
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryWriter) NetMessage.packetOut).BaseStream;
      int index1 = (int) memoryStream.GetBuffer()[0];
      SendDataOptions options = (SendDataOptions) NetMessage.PRIORITY[index1];
      for (int index2 = Netplay.clients.Count - 1; index2 >= 0; --index2)
      {
        NetClient netClient = Netplay.clients[index2];
        if (netClient != ignoreClient)
        {
          if (netClient.IsReadyToReceive(memoryStream.GetBuffer()))
          {
            try
            {
              Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, NetMessage.packetOut.Length, options, netClient.gamer);
            }
            catch
            {
            }
          }
        }
      }
      memoryStream.Position = 0L;
      memoryStream.SetLength(0L);
    }

    public static void SendMessage(NetworkGamer gamer)
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryWriter) NetMessage.packetOut).BaseStream;
      int index = (int) memoryStream.GetBuffer()[0];
      SendDataOptions options = (SendDataOptions) NetMessage.PRIORITY[index];
      try
      {
        Netplay.gamer.SendData(NetMessage.packetOut, options, gamer);
      }
      catch
      {
        memoryStream.Position = 0L;
        memoryStream.SetLength(0L);
      }
    }

    private static void EchoMessage(NetClient sender)
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryReader) NetMessage.packetIn).BaseStream;
      int index1 = (int) memoryStream.GetBuffer()[0];
      SendDataOptions options = (SendDataOptions) NetMessage.PRIORITY[index1];
      for (int index2 = Netplay.clients.Count - 1; index2 >= 0; --index2)
      {
        NetClient netClient = Netplay.clients[index2];
        if (netClient != sender)
        {
          if (netClient.IsReadyToReceive(memoryStream.GetBuffer()))
          {
            try
            {
              Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, NetMessage.packetIn.Length, options, netClient.gamer);
            }
            catch
            {
            }
          }
        }
      }
    }

    private static void EchoProjectileMessage(NetClient sender, ref Projectile projectile)
    {
      MemoryStream memoryStream = (MemoryStream) ((BinaryReader) NetMessage.packetIn).BaseStream;
      int index1 = (int) memoryStream.GetBuffer()[0];
      SendDataOptions options = (SendDataOptions) NetMessage.PRIORITY[index1];
      for (int index2 = Netplay.clients.Count - 1; index2 >= 0; --index2)
      {
        NetClient netClient = Netplay.clients[index2];
        if (netClient != sender)
        {
          if (netClient.IsReadyToReceiveProjectile(ref projectile))
          {
            try
            {
              Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, NetMessage.packetIn.Length, options, netClient.gamer);
            }
            catch
            {
            }
          }
        }
      }
    }

    public static unsafe void GetData(NetClient sender)
    {
      int num1 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
      if (Main.netMode == 1)
      {
        UI ui1 = UI.main;
        if (Netplay.clientStatusMax > 0)
          ++Netplay.clientStatusCount;
        switch (num1)
        {
          case 54:
            int index1 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            for (int index2 = 0; index2 < 5; ++index2)
            {
              uint num2 = (uint) ((BinaryReader) NetMessage.packetIn).ReadByte();
              Main.npc[index1].buff[index2].Type = (ushort) num2;
              Main.npc[index1].buff[index2].Time = num2 > 0U ? (ushort) NetMessage.ReadCompacted() : (ushort) 0;
            }
            break;
          case 56:
            int index3 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            NPC.chrName[index3] = ((BinaryReader) NetMessage.packetIn).ReadString();
            break;
          case 57:
            WorldGen.tGood = ((BinaryReader) NetMessage.packetIn).ReadByte();
            WorldGen.tEvil = ((BinaryReader) NetMessage.packetIn).ReadByte();
            break;
          case 63:
          case 37:
          case 38:
          case 18:
          case 25:
            byte num3 = ((BinaryReader) NetMessage.packetIn).ReadByte();
            byte num4 = ((BinaryReader) NetMessage.packetIn).ReadByte();
            byte num5 = ((BinaryReader) NetMessage.packetIn).ReadByte();
            uint num6 = 0U;
            string newText;
            if (num1 == 18)
            {
              uint num2 = (uint) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
              newText = Lang.misc[(IntPtr) num2];
            }
            else if (num1 == 63)
            {
              uint encoded = ((BinaryReader) NetMessage.packetIn).ReadUInt32();
              newText = ((BinaryReader) NetMessage.packetIn).ReadString() + Lang.deathMsgString(encoded);
            }
            else
            {
              if (num1 != 25)
                num6 = (uint) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
              newText = ((BinaryReader) NetMessage.packetIn).ReadString();
              if (num1 == 37)
                newText = newText + Lang.misc[(IntPtr) num6];
              else if (num1 == 38)
                newText = Lang.misc[(IntPtr) num6] + newText;
            }
            Main.NewText(newText, (int) num3, (int) num4, (int) num5);
            break;
          case 64:
            int index4 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            UI ui2 = Main.player[index4].ui;
            int num7 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            if (ui2 != null)
            {
              ui2.SetTriggerState((Trigger) num7);
              break;
            }
            else
              break;
          case 65:
            int index5 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            UI ui3 = Main.player[index5].ui;
            int num8 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            if (ui3 != null)
            {
              ui3.Statistics.incStat((StatisticEntry) num8);
              break;
            }
            else
              break;
          case 49:
            int num9 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            for (int index2 = 0; index2 < 4; ++index2)
            {
              UI ui4 = Main.ui[index2];
              if (ui4.localGamer != null && (int) ui4.myPlayer == num9)
              {
                Netplay.gamersWaitingToSpawn.Add(ui4);
                break;
              }
            }
            if (Netplay.clientState >= Netplay.ClientState.WAITING_FOR_TILE_DATA)
            {
              Netplay.clientState = Netplay.ClientState.PLAYING;
              break;
            }
            else
              break;
          case 2:
            Netplay.disconnect = true;
            ui1.statusText = Lang.misc[(int) ((BinaryReader) NetMessage.packetIn).ReadUInt16()];
            break;
          case 3:
            if (Netplay.clientState == Netplay.ClientState.WAITING_FOR_PLAYER_DATA_REQ)
              Netplay.clientState = Netplay.ClientState.RECEIVED_PLAYER_DATA_REQ;
            int number = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            NetMessage.CreateMessage1(4, number);
            NetMessage.SendMessage();
            NetMessage.CreateMessage1(16, number);
            NetMessage.SendMessage();
            NetMessage.CreateMessage1(42, number);
            NetMessage.SendMessage();
            NetMessage.CreateMessage1(50, number);
            NetMessage.SendMessage();
            for (int number2 = 0; number2 < 49; ++number2)
            {
              NetMessage.CreateMessage2(5, number, number2);
              NetMessage.SendMessage();
            }
            for (int index2 = 0; index2 < 11; ++index2)
            {
              NetMessage.CreateMessage2(5, number, index2 + 49);
              NetMessage.SendMessage();
            }
            NetMessage.CreateMessage0(6);
            NetMessage.SendMessage();
            break;
          case 7:
            Main.gameTime.time = ((BinaryReader) NetMessage.packetIn).ReadSingle();
            int num10 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            Main.gameTime.dayTime = (num10 & 1) != 0;
            Main.gameTime.bloodMoon = (num10 & 2) != 0;
            Main.gameTime.moonPhase = (byte) (num10 >> 2);
            Main.maxTilesX = ((BinaryReader) NetMessage.packetIn).ReadInt16();
            Main.maxTilesY = ((BinaryReader) NetMessage.packetIn).ReadInt16();
            Main.spawnTileX = ((BinaryReader) NetMessage.packetIn).ReadInt16();
            Main.spawnTileY = ((BinaryReader) NetMessage.packetIn).ReadInt16();
            Main.worldSurface = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
            Main.worldSurfacePixels = Main.worldSurface << 4;
            Main.rockLayer = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
            Main.rockLayerPixels = Main.rockLayer << 4;
            int num11 = ((BinaryReader) NetMessage.packetIn).ReadInt32();
            if (num11 != Main.worldID)
            {
              Main.worldID = num11;
              Main.checkWorldId = true;
            }
            int num12 = ((BinaryReader) NetMessage.packetIn).ReadInt32();
            if (num12 != Main.worldTimestamp)
            {
              Main.worldTimestamp = num12;
              Main.checkWorldId = true;
            }
            int num13 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            WorldGen.shadowOrbSmashed = (num13 & 1) != 0;
            NPC.downedBoss1 = (num13 & 2) != 0;
            NPC.downedBoss2 = (num13 & 4) != 0;
            NPC.downedBoss3 = (num13 & 8) != 0;
            Main.hardMode = (num13 & 16) != 0;
            NPC.downedClown = (num13 & 32) != 0;
            Main.worldName = ((BinaryReader) NetMessage.packetIn).ReadString();
            WorldGen.UpdateMagmaLayerPos();
            if (Netplay.clientState <= Netplay.ClientState.WAITING_FOR_WORLD_INFO)
            {
              Netplay.clientState = Netplay.ClientState.ANNOUNCING_SPAWN_LOCATION;
              UI.main.NextProgressStep(Lang.menu[74]);
              break;
            }
            else
              break;
          case 9:
            Netplay.clientStatusMax += (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            break;
          case 10:
            int startX = (int) ((BinaryReader) NetMessage.packetIn).ReadByte() * 40;
            int startY = (int) ((BinaryReader) NetMessage.packetIn).ReadByte() * 30;
            Tile[,] tileArray;
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            fixed (Tile* tilePtr1 = &^((tileArray = Main.tile) == null || tileArray.Length == 0 ? (Tile&) IntPtr.Zero : tileArray.Address(0, 0)))
            {
              uint num2 = 0U;
              Tile* tilePtr2 = (Tile*) null;
              for (int index2 = startX; index2 < startX + 40; ++index2)
              {
                Tile* tilePtr3 = tilePtr1 + (startY + index2 * 1440);
                for (int index6 = 29; index6 >= 0; --index6)
                {
                  if (num2 > 0U)
                  {
                    --num2;
                    *tilePtr3 = *tilePtr2;
                  }
                  else
                  {
                    tilePtr2 = tilePtr3;
                    int num14 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
                    int num15 = num14 & 1;
                    if (num15 != 0)
                    {
                      int num16 = (int) tilePtr3->type;
                      int index7 = (int) (tilePtr3->type = ((BinaryReader) NetMessage.packetIn).ReadByte());
                      if (Main.tileFrameImportant[index7])
                      {
                        tilePtr3->frameX = (short) NetMessage.ReadCompacted();
                        tilePtr3->frameY = (short) NetMessage.ReadCompacted();
                      }
                      else if (index7 != num16 || (int) tilePtr3->active == 0)
                      {
                        tilePtr3->frameX = (short) -1;
                        tilePtr3->frameY = (short) -1;
                      }
                    }
                    tilePtr3->active = (byte) num15;
                    tilePtr3->wall = (num14 & 4) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadByte() : (byte) 0;
                    tilePtr3->liquid = (num14 & 8) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadByte() : (byte) 0;
                    tilePtr3->wire = num14 & 16;
                    tilePtr3->lava = (byte) (num14 & 32);
                    num2 = NetMessage.ReadCompacted();
                  }
                  ++tilePtr3;
                }
              }
            }
            WorldGen.SectionTileFrame(startX, startY);
            break;
          case 11:
            int num17 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
            if (num17 != ((ReadOnlyCollection<NetworkGamer>) allGamers).Count)
            {
              NetMessage.CreateMessage0(11);
              NetMessage.SendMessage();
              break;
            }
            else
            {
              do
              {
                NetworkGamer networkGamer = ((ReadOnlyCollection<NetworkGamer>) allGamers)[--num17];
                int index2 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
                Player player = Main.player[index2];
                int num2 = networkGamer.IsLocal ? 1 : 0;
                networkGamer.Tag = (object) player;
              }
              while (num17 > 0);
              break;
            }
          case 14:
            int num18 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int num19 = num18 & 128;
            int i = num18 ^ num19;
            Player player1 = Main.player[i];
            if (num19 != 0)
            {
              if ((int) player1.active == 0)
              {
                player1.Init();
                player1.active = (byte) 1;
              }
              Netplay.SetAsRemotePlayerSlot(i);
              break;
            }
            else
            {
              player1.active = (byte) 0;
              break;
            }
          case 23:
            int index8 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int num20 = (int) NetMessage.ReadCompacted();
            Main.npc[index8].life = num20;
            if (num20 == 0)
            {
              Main.npc[index8].active = (byte) 0;
              break;
            }
            else
            {
              int type = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
              if ((int) Main.npc[index8].active == 0 || (int) Main.npc[index8].netID != type)
                Main.npc[index8].netDefaults(type);
              Main.npc[index8].position = NetMessage.packetIn.ReadVector2();
              Main.npc[index8].aabb.X = (int) Main.npc[index8].position.X;
              Main.npc[index8].aabb.Y = (int) Main.npc[index8].position.Y;
              Main.npc[index8].velocity = new HalfVector2()
              {
                PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt32()
              }.ToVector2();
              int num2 = (int) ((BinaryReader) NetMessage.packetIn).ReadSByte();
              Main.npc[index8].target = (byte) (num2 & 15);
              Main.npc[index8].direction = (sbyte) (num2 << 26 >> 30);
              Main.npc[index8].directionY = (sbyte) (num2 >> 6);
              int num14 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
              Main.npc[index8].ai0 = (num14 & 1) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadSingle() : 0.0f;
              Main.npc[index8].ai1 = (num14 & 2) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadSingle() : 0.0f;
              Main.npc[index8].ai2 = (num14 & 4) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadSingle() : 0.0f;
              Main.npc[index8].ai3 = (num14 & 8) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadSingle() : 0.0f;
              break;
            }
        }
      }
      else if (Main.netMode == 2)
      {
        switch (num1)
        {
          case 53:
            int number1 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int type1 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int time = (int) NetMessage.ReadCompacted();
            Main.npc[number1].AddBuff(type1, time, true);
            NetMessage.CreateMessage1(54, number1);
            NetMessage.SendMessage();
            break;
          case 61:
            int index9 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int Type1 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
            if (Type1 < 0)
            {
              if (Main.invasionType == 0)
              {
                Main.invasionDelay = 0;
                Main.StartInvasion(-Type1);
                break;
              }
              else
                break;
            }
            else
            {
              bool flag = true;
              for (int index1 = 0; index1 < 196; ++index1)
              {
                if ((int) Main.npc[index1].type == Type1 && (int) Main.npc[index1].active != 0)
                {
                  flag = false;
                  break;
                }
              }
              if (flag)
              {
                NPC.SpawnOnPlayer(Main.player[index9], Type1);
                break;
              }
              else
                break;
            }
          case 62:
            NPC.SpawnSkeletron();
            break;
          case 66:
            sender.RequestedPublicSlot();
            break;
          case 67:
            sender.CanceledPublicSlot();
            break;
          case 34:
            int index10 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
            int index11 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
            if ((int) Main.tile[index10, index11].type == 21 && WorldGen.KillTile(index10, index11))
            {
              NetMessage.CreateMessage5(17, 0, index10, index11, 0, 0);
              NetMessage.SendMessage();
              break;
            }
            else
              break;
          case 46:
            int number3 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int number2_1 = Sign.ReadSign((int) ((BinaryReader) NetMessage.packetIn).ReadUInt16(), (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16());
            if (number2_1 >= 0)
            {
              NetMessage.CreateMessage2(47, number3, number2_1);
              NetMessage.SendMessage(sender);
              break;
            }
            else
              break;
          case 11:
            NetMessage.CreateMessage0(11);
            NetMessage.SendMessage(sender);
            break;
          case 31:
            int number4 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            Player player2 = Main.player[number4];
            int chest = Chest.FindChest((int) ((BinaryReader) NetMessage.packetIn).ReadUInt16(), (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16());
            if (chest >= 0 && Chest.UsingChest(chest) == -1)
            {
              for (int number2_2 = 0; number2_2 < 20; ++number2_2)
              {
                NetMessage.CreateMessage2(32, chest, number2_2);
                NetMessage.SendMessage(sender);
              }
              NetMessage.CreateMessage2(33, number4, chest);
              NetMessage.SendMessage(sender);
              player2.chest = (short) chest;
              break;
            }
            else
              break;
          case 1:
            int num21 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            if ((int) sender.serverState == 0)
            {
              if (num21 == 1)
              {
                sender.serverState = (short) 1;
              }
              else
              {
                NetMessage.BootPlayer((int) ((BinaryReader) NetMessage.packetIn).ReadByte(), 22);
                break;
              }
            }
            int playerId = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            NetMessage.SendPlayerInfoRequest(sender, playerId);
            break;
          case 6:
            if ((int) sender.serverState == 1)
              sender.serverState = (short) 2;
            NetMessage.CreateMessage0(7);
            NetMessage.SendMessage(sender);
            break;
          case 8:
            int number5 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int num22 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
            int num23 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
            bool flag1 = num22 >= 0 && num23 >= 0;
            if (flag1)
            {
              if (num22 < 10 || num22 > (int) Main.maxTilesX - 10)
                flag1 = false;
              else if (num23 < 10 || num23 > (int) Main.maxTilesY - 10)
                flag1 = false;
            }
            int number6 = 9;
            if (flag1)
              number6 <<= 1;
            if ((int) sender.serverState == 2)
              sender.serverState = (short) 3;
            NetMessage.CreateMessage1(9, number6);
            NetMessage.SendMessage(sender);
            int sectionX1 = (int) Main.spawnTileX / 40;
            int sectionY1 = (int) Main.spawnTileY / 30;
            NetMessage.SendSectionSquare(sender, sectionX1, sectionY1, 3);
            if (flag1)
            {
              int sectionX2 = num22 / 40;
              int sectionY2 = num23 / 30;
              NetMessage.SendSectionSquare(sender, sectionX2, sectionY2, 3);
            }
            for (int index1 = 0; index1 < 200; ++index1)
            {
              if ((int) Main.item[index1].active != 0)
              {
                NetMessage.CreateMessage2(21, (int) UI.main.myPlayer, index1);
                NetMessage.SendMessage(sender);
                NetMessage.CreateMessage1(22, index1);
                NetMessage.SendMessage(sender);
              }
            }
            for (int number2 = 0; number2 < 196; ++number2)
            {
              NPC npc = Main.npc[number2];
              if ((int) npc.active != 0)
              {
                if (npc.townNPC)
                {
                  int sectionX2 = npc.aabb.X / 640;
                  int sectionY2 = npc.aabb.X / 640;
                  NetMessage.SendSectionSquare(sender, sectionX2, sectionY2, 3);
                }
                NetMessage.CreateMessage1(23, number2);
                NetMessage.SendMessage(sender);
              }
            }
            NetMessage.CreateMessage1(56, 17);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 18);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 19);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 20);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 22);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 38);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 54);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 107);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 108);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(56, 124);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage0(57);
            NetMessage.SendMessage(sender);
            NetMessage.CreateMessage1(49, number5);
            NetMessage.SendMessage(sender);
            break;
        }
      }
      switch (num1)
      {
        case 4:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int num24 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          Player player3 = Main.player[num24 & 7];
          int num25 = num24 >> 4;
          player3.hair = (byte) (num25 & 63);
          int num26 = num25 >> 6;
          player3.male = (num26 & 1) != 0;
          int num27 = num26 >> 1;
          player3.difficulty = (byte) num27;
          player3.hairColor.R = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.hairColor.G = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.hairColor.B = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.skinColor.R = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.skinColor.G = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.skinColor.B = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.eyeColor.R = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.eyeColor.G = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.eyeColor.B = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.shirtColor.R = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.shirtColor.G = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.shirtColor.B = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.underShirtColor.R = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.underShirtColor.G = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.underShirtColor.B = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.pantsColor.R = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.pantsColor.G = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.pantsColor.B = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.shoeColor.R = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.shoeColor.G = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.shoeColor.B = ((BinaryReader) NetMessage.packetIn).ReadByte();
          player3.oldName = player3.name;
          player3.name = ((BinaryReader) NetMessage.packetIn).ReadString();
          break;
        case 5:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index12 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player4 = Main.player[index12];
          int index13 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int Stack1 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int pre1 = 0;
          int Type2 = 0;
          if (Stack1 > 0)
          {
            pre1 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            Type2 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          }
          if (index13 < 49)
          {
            if (Stack1 > 0)
            {
              player4.inventory[index13].netDefaults(Type2, Stack1);
              player4.inventory[index13].Prefix(pre1);
              break;
            }
            else
            {
              player4.inventory[index13].Init();
              break;
            }
          }
          else
          {
            int index1 = index13 - 49;
            if (Stack1 > 0)
            {
              player4.armor[index1].netDefaults(Type2, Stack1);
              player4.armor[index1].Prefix(pre1);
              break;
            }
            else
            {
              player4.armor[index1].Init();
              break;
            }
          }
        case 12:
          int plr = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player5 = Main.player[plr];
          if (Main.netMode == 1)
          {
            if (player5.ui != null)
              player5.ui.setPlayer((Player) null);
          }
          else
            NetMessage.EchoMessage(sender);
          player5.SpawnX = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          player5.SpawnY = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          player5.Spawn();
          if (Main.netMode != 2 || (int) sender.serverState < 3)
            break;
          if ((int) sender.serverState == 3)
          {
            sender.serverState = (short) 10;
            NetMessage.greetPlayer(plr);
            NetMessage.syncPlayers();
            break;
          }
          else
          {
            NetMessage.syncPlayer(plr);
            break;
          }
        case 13:
          int num28 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player6 = Main.player[num28 & 63];
          player6.direction = (num28 & 64) != 0 ? (sbyte) 1 : (sbyte) -1;
          int num29 = (num28 & 128) != 0 ? (int) ((BinaryReader) NetMessage.packetIn).ReadByte() : 0;
          player6.controlUp = (num29 & 1) != 0;
          player6.controlDown = (num29 & 2) != 0;
          player6.controlLeft = (num29 & 4) != 0;
          player6.controlRight = (num29 & 8) != 0;
          player6.controlJump = (num29 & 16) != 0;
          player6.controlUseItem = (num29 & 32) != 0;
          if ((num29 & 32) != 0)
            player6.selectedItem = ((BinaryReader) NetMessage.packetIn).ReadSByte();
          player6.position = NetMessage.packetIn.ReadVector2();
          player6.aabb.X = (int) player6.position.X;
          player6.aabb.Y = (int) player6.position.Y;
          player6.velocity = new HalfVector2()
          {
            PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt32()
          }.ToVector2();
          player6.fallStart = (short) (player6.aabb.Y >> 4);
          if (Main.netMode != 2 || (int) sender.serverState != 10)
            break;
          NetMessage.EchoMessage(sender);
          break;
        case 15:
          int index14 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int index15 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int num30 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num31 = (int) Main.tile[index14, index15].active;
          Main.tile[index14, index15].active = (byte) (num30 & 1);
          Main.tile[index14, index15].wire = num30 & 16;
          if ((int) Main.tile[index14, index15].active != 0)
          {
            int num2 = (int) Main.tile[index14, index15].type;
            int index1 = (int) (Main.tile[index14, index15].type = ((BinaryReader) NetMessage.packetIn).ReadByte());
            if (Main.tileFrameImportant[index1])
            {
              Main.tile[index14, index15].frameX = (short) NetMessage.ReadCompacted();
              Main.tile[index14, index15].frameY = (short) NetMessage.ReadCompacted();
            }
            else if (num31 == 0 || index1 != num2)
            {
              Main.tile[index14, index15].frameX = (short) -1;
              Main.tile[index14, index15].frameY = (short) -1;
            }
          }
          if ((num30 & 4) != 0)
            Main.tile[index14, index15].wall = ((BinaryReader) NetMessage.packetIn).ReadByte();
          if (Main.netMode != 2 && (num30 & 8) != 0)
          {
            Main.tile[index14, index15].lava = (byte) (num30 & 32);
            Main.tile[index14, index15].liquid = ((BinaryReader) NetMessage.packetIn).ReadByte();
          }
          WorldGen.TileFrame(index14, index15, 0);
          WorldGen.WallFrame(index14, index15, false);
          if (Main.netMode != 2)
            break;
          NetMessage.CreateMessage2(15, index14, index15);
          NetMessage.SendMessageIgnore(sender);
          break;
        case 16:
          int num32 = ((BinaryReader) NetMessage.packetIn).ReadInt32();
          Player player7 = Main.player[num32 & 15];
          int num33 = num32 << 16 >> 20;
          player7.statLife = (short) num33;
          if (num33 <= 0)
            player7.dead = true;
          player7.statLifeMax = (short) (num32 >> 16);
          if (Main.netMode != 2)
            break;
          NetMessage.EchoMessage(sender);
          break;
        case 17:
          int num34 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num35 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int num36 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int type2 = num34 <= 4 ? (int) ((BinaryReader) NetMessage.packetIn).ReadByte() : 1;
          bool fail = type2 == 1;
          if (Main.netMode == 2)
          {
            if (!fail && (num34 == 0 || num34 == 2 || num34 == 4) && !sender.tileSection[num35 / 40, num36 / 30])
              fail = true;
            NetMessage.EchoMessage(sender);
          }
          switch (num34)
          {
            case 0:
              WorldGen.KillTile(num35, num36, fail, false, false);
              return;
            case 1:
              int style = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
              WorldGen.PlaceTile(num35, num36, type2, false, true, -1, style);
              if (type2 != 53 || Main.netMode != 2)
                return;
              NetMessage.SendTile(num35, num36);
              return;
            case 2:
              WorldGen.KillWall(num35, num36, fail);
              return;
            case 3:
              WorldGen.PlaceWall(num35, num36, type2);
              return;
            case 4:
              WorldGen.KillTile(num35, num36, fail, false, true);
              return;
            case 5:
              WorldGen.PlaceWire(num35, num36);
              return;
            case 6:
              WorldGen.KillWire(num35, num36);
              return;
            default:
              return;
          }
        case 19:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          WorldGen.OpenDoor((int) ((BinaryReader) NetMessage.packetIn).ReadUInt16(), (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16(), (int) ((BinaryReader) NetMessage.packetIn).ReadSByte());
          break;
        case 20:
          int number7 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num37 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int num38 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          for (int index1 = num37; index1 < num37 + number7; ++index1)
          {
            for (int index2 = num38; index2 < num38 + number7; ++index2)
            {
              int num2 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
              int num3 = (int) Main.tile[index1, index2].active;
              Main.tile[index1, index2].active = (byte) (num2 & 1);
              Main.tile[index1, index2].wire = num2 & 16;
              if ((int) Main.tile[index1, index2].active != 0)
              {
                int num4 = (int) Main.tile[index1, index2].type;
                int index3 = (int) (Main.tile[index1, index2].type = ((BinaryReader) NetMessage.packetIn).ReadByte());
                if (Main.tileFrameImportant[index3])
                {
                  Main.tile[index1, index2].frameX = (short) NetMessage.ReadCompacted();
                  Main.tile[index1, index2].frameY = (short) NetMessage.ReadCompacted();
                }
                else if (num3 == 0 || index3 != num4)
                {
                  Main.tile[index1, index2].frameX = (short) -1;
                  Main.tile[index1, index2].frameY = (short) -1;
                }
              }
              if ((num2 & 4) != 0)
                Main.tile[index1, index2].wall = ((BinaryReader) NetMessage.packetIn).ReadByte();
              if (Main.netMode != 2 && (num2 & 8) != 0)
              {
                Main.tile[index1, index2].lava = (byte) (num2 & 32);
                Main.tile[index1, index2].liquid = ((BinaryReader) NetMessage.packetIn).ReadByte();
              }
            }
          }
          WorldGen.RangeFrame(num37, num38, num37 + number7, num38 + number7);
          if (Main.netMode != 2)
            break;
          NetMessage.CreateMessage3(20, number7, num37, num38);
          NetMessage.SendMessageIgnore(sender);
          break;
        case 21:
          int number2_3 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num39 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          int number8 = num39 & 31;
          int Type3 = num39 >> 5;
          if (Main.netMode == 1)
          {
            if (Type3 == 0)
            {
              Main.item[number2_3].active = (byte) 0;
              break;
            }
            else
            {
              Main.item[number2_3].netDefaults(Type3, 1);
              Main.item[number2_3].Prefix((int) ((BinaryReader) NetMessage.packetIn).ReadByte());
              Main.item[number2_3].stack = (short) ((BinaryReader) NetMessage.packetIn).ReadByte();
              Main.item[number2_3].position = NetMessage.packetIn.ReadVector2();
              Main.item[number2_3].velocity = new HalfVector2()
              {
                PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt32()
              }.ToVector2();
              Main.item[number2_3].wet = Collision.WetCollision(ref Main.item[number2_3].position, (int) Main.item[number2_3].width, (int) Main.item[number2_3].height);
              break;
            }
          }
          else if (Type3 == 0)
          {
            Main.item[number2_3].active = (byte) 0;
            NetMessage.CreateMessage2(21, number8, number2_3);
            NetMessage.SendMessage();
            break;
          }
          else
          {
            int pre2 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int Stack2 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            float num2 = ((BinaryReader) NetMessage.packetIn).ReadSingle();
            float num3 = ((BinaryReader) NetMessage.packetIn).ReadSingle();
            bool flag2 = number2_3 == 200;
            if (flag2)
            {
              Item obj = new Item();
              obj.netDefaults(Type3, Stack2);
              number2_3 = (int) (short) Item.NewItem((int) num2, (int) num3, (int) obj.width, (int) obj.height, (int) obj.type, Stack2, true, 0);
            }
            else
            {
              Main.item[number2_3].position.X = num2;
              Main.item[number2_3].position.Y = num3;
            }
            Main.item[number2_3].netDefaults(Type3, Stack2);
            Main.item[number2_3].Prefix(pre2);
            Main.item[number2_3].velocity = new HalfVector2()
            {
              PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt32()
            }.ToVector2();
            Main.item[number2_3].owner = (byte) 8;
            NetMessage.CreateMessage2(21, number8, number2_3);
            if (flag2)
            {
              NetMessage.SendMessage();
              Main.item[number2_3].ownIgnore = (byte) number8;
              Main.item[number2_3].ownTime = (byte) 100;
              break;
            }
            else
            {
              NetMessage.SendMessageIgnore(Main.player[number8].client);
              break;
            }
          }
        case 22:
          int index16 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num40 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num41 = num40 & 128;
          int num42 = num40 ^ num41;
          Main.item[index16].owner = (byte) num42;
          if (num42 < 8)
          {
            Main.item[index16].keepTime = (byte) 15;
            Main.item[index16].position = NetMessage.packetIn.ReadVector2();
            if (num41 != 0)
            {
              Main.item[index16].velocity = new HalfVector2()
              {
                PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt32()
              }.ToVector2();
            }
            else
            {
              Main.item[index16].velocity.X = 0.0f;
              Main.item[index16].velocity.Y = 0.0f;
            }
          }
          if (Main.netMode != 2)
            break;
          NetMessage.EchoMessage(sender);
          break;
        case 24:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          WorldGen.CloseDoor((int) ((BinaryReader) NetMessage.packetIn).ReadUInt16(), (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16(), true);
          break;
        case 26:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index17 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int hitDirection1 = (int) ((BinaryReader) NetMessage.packetIn).ReadSByte();
          int Damage1 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          bool pvp = ((BinaryReader) NetMessage.packetIn).ReadBoolean();
          bool Crit = ((BinaryReader) NetMessage.packetIn).ReadBoolean();
          uint deathText1 = ((BinaryReader) NetMessage.packetIn).ReadUInt32();
          Main.player[index17].Hurt(Damage1, hitDirection1, pvp, true, deathText1, Crit);
          break;
        case 27:
          int num43 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num44 = num43 >> 4;
          int num45 = num43 & 15;
          int Type4 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num46 = (int) NetMessage.ReadCompacted();
          int index18 = 512;
          for (int index1 = 0; index1 < 512; ++index1)
          {
            if ((int) Main.projectile[index1].owner == num45 && (int) Main.projectile[index1].identity == num46 && (int) Main.projectile[index1].active != 0)
            {
              index18 = index1;
              break;
            }
          }
          if (index18 == 512)
          {
            for (int index1 = 0; index1 < 512; ++index1)
            {
              if ((int) Main.projectile[index1].active == 0)
              {
                index18 = index1;
                break;
              }
            }
          }
          if ((int) Main.projectile[index18].active == 0 || (int) Main.projectile[index18].type != Type4)
            Main.projectile[index18].SetDefaults(Type4);
          Main.projectile[index18].type = (byte) Type4;
          Main.projectile[index18].owner = (byte) num45;
          Main.projectile[index18].identity = (ushort) num46;
          Main.projectile[index18].position = NetMessage.packetIn.ReadVector2();
          Main.projectile[index18].aabb.X = (int) Main.projectile[index18].position.X;
          Main.projectile[index18].aabb.Y = (int) Main.projectile[index18].position.Y;
          Main.projectile[index18].velocity = new HalfVector2()
          {
            PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt32()
          }.ToVector2();
          if ((num44 & 1) != 0)
            Main.projectile[index18].knockBack = new HalfSingle()
            {
              PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt16()
            }.ToSingle();
          else
            Main.projectile[index18].knockBack = 0.0f;
          Main.projectile[index18].damage = (num44 & 2) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadInt16() : (short) 0;
          Main.projectile[index18].ai0 = (num44 & 4) != 0 ? ((BinaryReader) NetMessage.packetIn).ReadSingle() : 0.0f;
          Main.projectile[index18].ai1 = (num44 & 8) != 0 ? (int) ((BinaryReader) NetMessage.packetIn).ReadInt16() : 0;
          if (Main.netMode != 2)
            break;
          NetMessage.EchoProjectileMessage(sender, ref Main.projectile[index18]);
          break;
        case 28:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int number9 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int Damage2 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          if (Damage2 >= 0)
          {
            float knockBack = new HalfSingle()
            {
              PackedValue = ((BinaryReader) NetMessage.packetIn).ReadUInt16()
            }.ToSingle();
            int num2 = (int) ((BinaryReader) NetMessage.packetIn).ReadSByte();
            bool crit = (num2 & 1) != 0;
            int hitDirection2 = num2 >> 1;
            Main.npc[number9].StrikeNPC(Damage2, knockBack, hitDirection2, crit, false);
          }
          else
          {
            Main.npc[number9].life = 0;
            if ((int) Main.npc[number9].active == 0)
              break;
            Main.npc[number9].HitEffect(0, 10.0);
            Main.npc[number9].active = (byte) 0;
          }
          if (Main.netMode != 2)
            break;
          if (Main.npc[number9].life <= 0)
          {
            NetMessage.CreateMessage1(23, number9);
            NetMessage.SendMessage();
            break;
          }
          else
          {
            Main.npc[number9].netUpdate = true;
            break;
          }
        case 29:
          int num47 = (int) NetMessage.ReadCompacted();
          int num48 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          for (int index1 = 0; index1 < 512; ++index1)
          {
            if ((int) Main.projectile[index1].owner == num48 && (int) Main.projectile[index1].identity == num47 && (int) Main.projectile[index1].active != 0)
            {
              Main.projectile[index1].Kill();
              break;
            }
          }
          break;
        case 30:
          int num49 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num50 = num49 & 128;
          int index19 = num49 ^ num50;
          Player player8 = Main.player[index19];
          if (Main.netMode == 2)
          {
            NetMessage.EchoMessage(sender);
            int textId = num50 != 0 ? 24 : 25;
            NetMessage.SendText(player8.name, textId, (int) Main.teamColor[(int) player8.team].R, (int) Main.teamColor[(int) player8.team].G, (int) Main.teamColor[(int) player8.team].B, -1);
          }
          player8.hostile = num50 != 0;
          break;
        case 32:
          int index20 = (int) NetMessage.ReadCompacted();
          int index21 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          if (Main.chest[index20] == null)
            Main.chest[index20] = new Chest();
          int Type5 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          if (Type5 != 0)
          {
            int pre2 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            int Stack2 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            Main.chest[index20].item[index21].netDefaults(Type5, Stack2);
            Main.chest[index20].item[index21].Prefix(pre2);
            break;
          }
          else
          {
            Main.chest[index20].item[index21].Init();
            break;
          }
        case 33:
          int num51 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          Player player9 = Main.player[num51 & 31];
          int num52 = num51 >> 5;
          if (player9.isLocal())
          {
            int num2 = (int) player9.chest;
            player9.chest = (short) num52;
            if (num52 >= 0)
            {
              player9.chestX = ((BinaryReader) NetMessage.packetIn).ReadInt16();
              player9.chestY = ((BinaryReader) NetMessage.packetIn).ReadInt16();
            }
            if (num2 == -1)
            {
              player9.ui.OpenInventory();
              Main.PlaySound(10);
              break;
            }
            else if (num52 == -1)
            {
              if (player9.ui.inventorySection != UI.InventorySection.CHEST)
                break;
              player9.ui.CloseInventory();
              Main.PlaySound(11);
              break;
            }
            else
            {
              if (num2 == num52)
                break;
              player9.ui.OpenInventory();
              Main.PlaySound(12);
              break;
            }
          }
          else
          {
            player9.chest = (short) num52;
            if (num52 < 0)
              break;
            NetMessage.packetIn.Position = NetMessage.packetIn.Position + 4;
            break;
          }
        case 35:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index22 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int healAmount = (int) NetMessage.ReadCompacted();
          Main.player[index22].HealEffect(healAmount);
          break;
        case 36:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index23 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player10 = Main.player[index23];
          int num53 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          player10.zoneEvil = (num53 & 1) != 0;
          player10.zoneMeteor = (num53 & 2) != 0;
          player10.zoneDungeon = (num53 & 4) != 0;
          player10.zoneJungle = (num53 & 8) != 0;
          player10.zoneHoly = (num53 & 16) != 0;
          break;
        case 40:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index24 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Main.player[index24].talkNPC = ((BinaryReader) NetMessage.packetIn).ReadInt16();
          break;
        case 41:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index25 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player11 = Main.player[index25];
          player11.itemRotation = ((BinaryReader) NetMessage.packetIn).ReadSingle();
          player11.itemAnimation = ((BinaryReader) NetMessage.packetIn).ReadInt16();
          player11.channel = player11.inventory[(int) player11.selectedItem].channel;
          break;
        case 42:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index26 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player12 = Main.player[index26];
          player12.statMana = ((BinaryReader) NetMessage.packetIn).ReadInt16();
          player12.statManaMax = ((BinaryReader) NetMessage.packetIn).ReadInt16();
          break;
        case 43:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index27 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int manaAmount = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          Main.player[index27].ManaEffect(manaAmount);
          break;
        case 44:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index28 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int hitDirection3 = (int) ((BinaryReader) NetMessage.packetIn).ReadSByte();
          int num54 = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          int num55 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          uint deathText2 = ((BinaryReader) NetMessage.packetIn).ReadUInt32();
          Main.player[index28].KillMe((double) num54, hitDirection3, num55 != 0, deathText2);
          break;
        case 45:
          int num56 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int index29 = num56 >> 4;
          int index30 = num56 & 15;
          Player player13 = Main.player[index30];
          int num57 = (int) player13.team;
          player13.team = (byte) index29;
          if (Main.netMode != 2)
            break;
          NetMessage.EchoMessage(sender);
          int textId1 = 26 + index29;
          for (int player1 = 0; player1 < 8; ++player1)
          {
            if (player1 == index30 || num57 > 0 && (int) Main.player[player1].team == num57 || index29 > 0 && (int) Main.player[player1].team == index29)
              NetMessage.SendText(player13.name, textId1, (int) Main.teamColor[index29].R, (int) Main.teamColor[index29].G, (int) Main.teamColor[index29].B, player1);
          }
          break;
        case 47:
          int index31 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player14 = Main.player[index31];
          int index32 = (int) NetMessage.ReadCompacted();
          Main.sign[index32].Read(NetMessage.packetIn);
          if (Main.netMode != 1 || index32 == (int) player14.sign)
            break;
          player14.ui.CloseInventory();
          player14.talkNPC = (short) -1;
          player14.ui.editSign = false;
          Main.PlaySound(10);
          player14.sign = (short) index32;
          player14.ui.npcChatText = Main.sign[index32].text;
          break;
        case 48:
          int i1 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int num58 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int j = num58 & (int) short.MaxValue;
          Main.tile[i1, j].liquid = ((BinaryReader) NetMessage.packetIn).ReadByte();
          Main.tile[i1, j].lava = (byte) (num58 >> 10 & 32);
          if (Main.netMode != 2)
            break;
          WorldGen.SquareTileFrame(i1, j, -1);
          break;
        case 50:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index33 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player15 = Main.player[index33];
          for (int index1 = 0; index1 < 10; ++index1)
          {
            int num2 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
            player15.buff[index1].Type = (ushort) num2;
            player15.buff[index1].Time = num2 > 0 ? (ushort) 60 : (ushort) 0;
          }
          break;
        case 51:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          Player player16 = Main.player[(int) ((BinaryReader) NetMessage.packetIn).ReadByte()];
          Main.PlaySound(2, player16.aabb.X, player16.aabb.Y, 1);
          break;
        case 52:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int num59 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int num60 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          int num61 = (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16();
          Chest.Unlock(num60, num61);
          if (Main.netMode != 2)
            break;
          NetMessage.SendTileSquare(num60, num61, 2);
          break;
        case 55:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index34 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Main.player[index34].AddBuff((int) ((BinaryReader) NetMessage.packetIn).ReadByte(), (int) NetMessage.ReadCompacted(), true);
          break;
        case 58:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          int index35 = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          Player player17 = Main.player[index35];
          Main.harpNote = ((BinaryReader) NetMessage.packetIn).ReadSingle();
          Main.PlaySound(2, player17.aabb.X, player17.aabb.Y, (int) player17.inventory[(int) player17.selectedItem].type == 507 ? 35 : 26);
          break;
        case 59:
          if (Main.netMode == 2)
            NetMessage.EchoMessage(sender);
          WorldGen.hitSwitch((int) ((BinaryReader) NetMessage.packetIn).ReadUInt16(), (int) ((BinaryReader) NetMessage.packetIn).ReadUInt16());
          break;
        case 60:
          int n = (int) ((BinaryReader) NetMessage.packetIn).ReadByte();
          int x = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          int y = (int) ((BinaryReader) NetMessage.packetIn).ReadInt16();
          bool flag3 = ((BinaryReader) NetMessage.packetIn).ReadBoolean();
          if (Main.netMode == 1)
          {
            Main.npc[n].homeless = flag3;
            Main.npc[n].homeTileX = (short) x;
            Main.npc[n].homeTileY = (short) y;
            break;
          }
          else if (!flag3)
          {
            WorldGen.kickOut(n);
            break;
          }
          else
          {
            WorldGen.moveRoom(x, y, n);
            break;
          }
      }
    }

    public static void BootPlayer(int plr, int stringId)
    {
      NetMessage.SendKick(Main.player[plr].client, stringId);
      Main.player[plr].kill = true;
    }

    public static void SendTileSquare(int tileX, int tileY, int size)
    {
      int num = size - 1 >> 1;
      NetMessage.CreateMessage3(20, size, tileX - num, tileY - num);
      NetMessage.SendMessage();
    }

    public static void SendTile(int tileX, int tileY)
    {
      NetMessage.CreateMessage2(15, tileX, tileY);
      NetMessage.SendMessage();
    }

    public static bool SendSection(NetClient client, int sectionX, int sectionY)
    {
      if (sectionX < 0 || sectionY < 0 || (sectionX >= Main.maxSectionsX || sectionY >= Main.maxSectionsY) || client.tileSection[sectionX, sectionY])
        return false;
      client.tileSection[sectionX, sectionY] = true;
      NetMessage.CreateMessage2(10, sectionX, sectionY);
      NetMessage.SendMessage(client);
      return true;
    }

    public static void SendSectionSquare(NetClient client, int sectionX, int sectionY, int size)
    {
      int num = size - 1 >> 1;
      for (int sectionX1 = sectionX - num; sectionX1 <= sectionX + num; ++sectionX1)
      {
        for (int sectionY1 = sectionY - num; sectionY1 <= sectionY + num; ++sectionY1)
          NetMessage.SendSection(client, sectionX1, sectionY1);
      }
    }

    public static void greetPlayer(int plr)
    {
      NetMessage.SendText(31, Main.player[plr].name + "!", (int) byte.MaxValue, 240, 20, plr);
      string str = (string) null;
      for (int index = 0; index < 8; ++index)
      {
        if ((int) Main.player[index].active != 0)
          str = str != null ? str + ", " + Main.player[index].name : Main.player[index].name;
      }
      NetMessage.SendText(23, str + (object) '.', (int) byte.MaxValue, 240, 20, plr);
    }

    public static void sendWater(int x, int y)
    {
      NetMessage.CreateMessage2(48, x, y);
      if (Main.netMode == 1)
      {
        NetMessage.SendMessage();
      }
      else
      {
        for (int index1 = Netplay.clients.Count - 1; index1 >= 0; --index1)
        {
          NetClient client = Netplay.clients[index1];
          if ((int) client.serverState >= 3)
          {
            int index2 = x / 40;
            int index3 = y / 30;
            if (client.tileSection[index2, index3])
              NetMessage.SendMessageNoClear(client);
          }
        }
        NetMessage.ClearMessage();
      }
    }

    public static void syncPlayer(int plr)
    {
      Player player = Main.player[plr];
      NetClient ignoreClient = player.client;
      NetMessage.CreateMessage2(14, plr, (int) player.active);
      NetMessage.SendMessageIgnore(ignoreClient);
      if ((int) player.active != 0 && (ignoreClient == null || (int) ignoreClient.serverState == 10))
      {
        NetMessage.CreateMessage1(4, plr);
        NetMessage.SendMessageIgnore(ignoreClient);
        NetMessage.CreateMessage1(13, plr);
        NetMessage.SendMessageIgnore(ignoreClient);
        NetMessage.CreateMessage1(16, plr);
        NetMessage.SendMessageIgnore(ignoreClient);
        NetMessage.CreateMessage1(30, plr);
        NetMessage.SendMessageIgnore(ignoreClient);
        NetMessage.CreateMessage1(42, plr);
        NetMessage.SendMessageIgnore(ignoreClient);
        NetMessage.CreateMessage1(45, plr);
        NetMessage.SendMessageIgnore(ignoreClient);
        NetMessage.CreateMessage1(50, plr);
        NetMessage.SendMessageIgnore(ignoreClient);
        for (int number2 = 0; number2 < 49; ++number2)
        {
          NetMessage.CreateMessage2(5, plr, number2);
          NetMessage.SendMessage();
        }
        for (int index = 0; index < 11; ++index)
        {
          NetMessage.CreateMessage2(5, plr, index + 49);
          NetMessage.SendMessage();
        }
        if (Main.player[plr].announced)
          return;
        Main.player[plr].announced = true;
        NetMessage.SendText(player.name, 32, (int) byte.MaxValue, 240, 20, -1);
        player.oldName = player.name;
      }
      else
      {
        if (!player.announced)
          return;
        player.announced = false;
        NetMessage.SendText(player.oldName, 33, (int) byte.MaxValue, 240, 20, -1);
      }
    }

    public static void syncPlayers()
    {
      for (int plr = 0; plr < 8; ++plr)
        NetMessage.syncPlayer(plr);
      for (int number = 0; number < 196; ++number)
      {
        if ((int) Main.npc[number].active != 0 && Main.npc[number].townNPC && -1 != Main.npc[number].getHeadTextureId())
        {
          NetMessage.CreateMessage4(60, number, (int) Main.npc[number].homeTileX, (int) Main.npc[number].homeTileY, Main.npc[number].homeless ? 1 : 0);
          NetMessage.SendMessage();
        }
      }
    }
  }
}
