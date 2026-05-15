using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Net;
using Terraria.Achievements;

namespace Terraria;

public sealed class NetMessage
{
	private static PacketWriter packetOut = new PacketWriter(65536);

	public static PacketReader packetIn = new PacketReader(65536);

	private static readonly byte[] PRIORITY = new byte[68]
	{
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 3, 1, 1, 3, 1, 1, 1,
		1, 1, 1, 2, 1, 1, 1, 0, 1, 1,
		1, 1, 1, 1, 1, 1, 0, 1, 1, 3,
		1, 2, 2, 1, 1, 1, 1, 1, 1, 1,
		1, 0, 1, 1, 1, 1, 1, 1, 0, 1,
		1, 1, 1, 1, 1, 1, 1, 1
	};

	public static void CheckBytesServer()
	{
		LocalNetworkGamer gamer = Netplay.gamer;
		if (gamer == null)
		{
			return;
		}
		lock (packetIn)
		{
			while (gamer.IsDataAvailable)
			{
				gamer.ReceiveData(packetIn, out var sender);
				Player player = sender.Tag as Player;
				GetData(player.client);
			}
		}
	}

	public static void CheckBytesClient()
	{
		for (int num = Netplay.gamersWaitingForPlayerId.Count - 1; num >= 0; num--)
		{
			UI uI = Netplay.gamersWaitingForPlayerId[num];
			if (uI.localGamer.IsDataAvailable)
			{
				lock (packetIn)
				{
					uI.localGamer.ReceiveData(packetIn, out var _);
					int num2 = packetIn.ReadByte();
					num2 = packetIn.ReadByte();
					uI.JoinSession(num2);
					uI.localGamer.Tag = Main.player[num2];
					SendHello(num2);
					Netplay.gamersWaitingForPlayerId.RemoveAt(num);
					Netplay.gamersWaitingToSendSpawn.Add(uI);
					if (Netplay.clientState <= Netplay.ClientState.WAITING_FOR_PLAYER_ID)
					{
						Netplay.clientState = Netplay.ClientState.WAITING_FOR_PLAYER_DATA_REQ;
					}
				}
			}
		}
		if (Netplay.gamersWaitingToSendSpawn.Count > 0 && Netplay.clientState >= Netplay.ClientState.ANNOUNCING_SPAWN_LOCATION)
		{
			UI uI2 = Netplay.gamersWaitingToSendSpawn[0];
			Netplay.gamersWaitingToSendSpawn.RemoveAt(0);
			uI2.player.FindSpawn();
			CreateMessage3(8, uI2.myPlayer, uI2.player.SpawnX, uI2.player.SpawnY);
			SendMessage();
			if (Netplay.clientState == Netplay.ClientState.ANNOUNCING_SPAWN_LOCATION)
			{
				Netplay.clientState = Netplay.ClientState.WAITING_FOR_TILE_DATA;
			}
		}
		else if (Netplay.gamersWaitingToSpawn.Count > 0 && Netplay.clientState >= Netplay.ClientState.PLAYING)
		{
			Main.JoinGame(Netplay.gamersWaitingToSpawn[0]);
			Netplay.gamersWaitingToSpawn.RemoveAt(0);
		}
		LocalNetworkGamer gamer = Netplay.gamer;
		if (gamer == null)
		{
			return;
		}
		lock (packetIn)
		{
			while (gamer.IsDataAvailable)
			{
				gamer.ReceiveData(packetIn, out var _);
				GetData(null);
			}
		}
	}

	private static void WriteCompacted(uint value)
	{
		if (value < 128)
		{
			packetOut.Write((byte)value);
			return;
		}
		uint num = (value & 0x7F) | 0x80 | (value >> 7 << 8);
		if (value < 16384)
		{
			packetOut.Write((ushort)num);
			return;
		}
		packetOut.Write((ushort)((num & 0x7FFF) | 0x8000));
		value >>= 14;
		packetOut.Write((byte)value);
	}

	private static uint ReadCompacted()
	{
		uint num = packetIn.ReadByte();
		if (num >= 128)
		{
			num &= 0x7F;
			num |= (uint)(packetIn.ReadByte() << 7);
			if (num >= 16384)
			{
				num &= 0x3FFF;
				num |= (uint)(packetIn.ReadByte() << 14);
			}
		}
		return num;
	}

	public static void CreateMessage0(int msgType)
	{
		packetOut.Write((byte)msgType);
		switch (msgType)
		{
		case 7:
		{
			packetOut.Write(Main.gameTime.time);
			int num2 = Main.gameTime.moonPhase << 2;
			if (Main.gameTime.dayTime)
			{
				num2 |= 1;
			}
			if (Main.gameTime.bloodMoon)
			{
				num2 |= 2;
			}
			packetOut.Write((byte)num2);
			packetOut.Write((ushort)Main.maxTilesX);
			packetOut.Write((ushort)Main.maxTilesY);
			packetOut.Write((ushort)Main.spawnTileX);
			packetOut.Write((ushort)Main.spawnTileY);
			packetOut.Write((ushort)Main.worldSurface);
			packetOut.Write((ushort)Main.rockLayer);
			packetOut.Write(Main.worldID);
			packetOut.Write(Main.worldTimestamp);
			num2 = (WorldGen.shadowOrbSmashed ? 1 : 0);
			if (NPC.downedBoss1)
			{
				num2 |= 2;
			}
			if (NPC.downedBoss2)
			{
				num2 |= 4;
			}
			if (NPC.downedBoss3)
			{
				num2 |= 8;
			}
			if (Main.hardMode)
			{
				num2 |= 0x10;
			}
			if (NPC.downedClown)
			{
				num2 |= 0x20;
			}
			packetOut.Write((byte)num2);
			packetOut.Write(Main.worldName);
			break;
		}
		case 11:
			if (Main.netMode == 2)
			{
				GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
				int num = allGamers.Count;
				packetOut.Write((byte)num);
				do
				{
					Player player = allGamers[--num].Tag as Player;
					packetOut.Write(player.whoAmI);
				}
				while (num > 0);
			}
			break;
		case 57:
			packetOut.Write(WorldGen.tGood);
			packetOut.Write(WorldGen.tEvil);
			break;
		}
	}

	public static void CreateMessage1(int msgType, int number)
	{
		packetOut.Write((byte)msgType);
		switch (msgType)
		{
		case 0:
			packetOut.Write((byte)number);
			break;
		case 1:
			packetOut.Write((byte)1);
			packetOut.Write((byte)number);
			break;
		case 2:
			packetOut.Write((ushort)number);
			break;
		case 3:
			packetOut.Write((byte)number);
			break;
		case 4:
		{
			Player player2 = Main.player[number];
			int num6 = number | (player2.hair << 4) | (player2.difficulty << 11);
			if (player2.male)
			{
				num6 |= 0x400;
			}
			packetOut.Write((ushort)num6);
			packetOut.Write(player2.hairColor.R);
			packetOut.Write(player2.hairColor.G);
			packetOut.Write(player2.hairColor.B);
			packetOut.Write(player2.skinColor.R);
			packetOut.Write(player2.skinColor.G);
			packetOut.Write(player2.skinColor.B);
			packetOut.Write(player2.eyeColor.R);
			packetOut.Write(player2.eyeColor.G);
			packetOut.Write(player2.eyeColor.B);
			packetOut.Write(player2.shirtColor.R);
			packetOut.Write(player2.shirtColor.G);
			packetOut.Write(player2.shirtColor.B);
			packetOut.Write(player2.underShirtColor.R);
			packetOut.Write(player2.underShirtColor.G);
			packetOut.Write(player2.underShirtColor.B);
			packetOut.Write(player2.pantsColor.R);
			packetOut.Write(player2.pantsColor.G);
			packetOut.Write(player2.pantsColor.B);
			packetOut.Write(player2.shoeColor.R);
			packetOut.Write(player2.shoeColor.G);
			packetOut.Write(player2.shoeColor.B);
			packetOut.Write(player2.name);
			break;
		}
		case 9:
			packetOut.Write((byte)number);
			break;
		case 12:
			packetOut.Write((byte)number);
			packetOut.Write((short)Main.player[number].SpawnX);
			packetOut.Write((short)Main.player[number].SpawnY);
			break;
		case 13:
		{
			Player player = Main.player[number];
			int num5 = 0;
			if (player.controlUp)
			{
				num5 = 1;
			}
			if (player.controlDown)
			{
				num5 |= 2;
			}
			if (player.controlLeft)
			{
				num5 |= 4;
			}
			if (player.controlRight)
			{
				num5 |= 8;
			}
			if (player.controlJump)
			{
				num5 |= 0x10;
			}
			if (player.controlUseItem)
			{
				num5 |= 0x20;
			}
			if (player.direction == 1)
			{
				number |= 0x40;
			}
			if (num5 != 0)
			{
				packetOut.Write((byte)(number | 0x80));
				packetOut.Write((byte)num5);
				if ((num5 & 0x20) != 0)
				{
					packetOut.Write(player.selectedItem);
				}
			}
			else
			{
				packetOut.Write((byte)number);
			}
			packetOut.Write(player.position);
			HalfVector2 halfVector3 = new HalfVector2(player.velocity);
			packetOut.Write(halfVector3.PackedValue);
			if (Main.netMode == 2 && ++player.netSkip > 2)
			{
				player.netSkip = 0;
			}
			break;
		}
		case 16:
		{
			int value = number | ((Main.player[number].statLife & 0xFFF) << 4) | (Main.player[number].statLifeMax << 16);
			packetOut.Write(value);
			break;
		}
		case 22:
		{
			packetOut.Write((byte)number);
			int num = Main.item[number].owner;
			if (num < 8)
			{
				Vector2 velocity = Main.item[number].velocity;
				if (velocity.X != 0f || velocity.Y != 0f)
				{
					num |= 0x80;
				}
				packetOut.Write((byte)num);
				packetOut.Write(Main.item[number].position);
				if ((num & 0x80) != 0)
				{
					HalfVector2 halfVector = new HalfVector2(velocity);
					packetOut.Write(halfVector.PackedValue);
				}
			}
			else
			{
				packetOut.Write((byte)num);
			}
			break;
		}
		case 23:
		{
			packetOut.Write((byte)number);
			int num3 = ((Main.npc[number].active != 0) ? Main.npc[number].life : 0);
			if (num3 <= 0)
			{
				packetOut.Write((byte)0);
				Main.npc[number].netSkip = 0;
				break;
			}
			WriteCompacted((uint)num3);
			packetOut.Write(Main.npc[number].netID);
			packetOut.Write(Main.npc[number].position);
			HalfVector2 halfVector2 = new HalfVector2(Main.npc[number].velocity);
			packetOut.Write(halfVector2.PackedValue);
			packetOut.Write((sbyte)(Main.npc[number].target | ((Main.npc[number].direction & 3) << 4) | (Main.npc[number].directionY << 6)));
			int num4 = 0;
			float ai = Main.npc[number].ai0;
			if (ai != 0f)
			{
				num4 = 1;
			}
			float ai2 = Main.npc[number].ai1;
			if (ai2 != 0f)
			{
				num4 |= 2;
			}
			float ai3 = Main.npc[number].ai2;
			if (ai3 != 0f)
			{
				num4 |= 4;
			}
			float ai4 = Main.npc[number].ai3;
			if (ai4 != 0f)
			{
				num4 |= 8;
			}
			packetOut.Write((byte)num4);
			if ((num4 & 1) != 0)
			{
				packetOut.Write(ai);
			}
			if ((num4 & 2) != 0)
			{
				packetOut.Write(ai2);
			}
			if ((num4 & 4) != 0)
			{
				packetOut.Write(ai3);
			}
			if ((num4 & 8) != 0)
			{
				packetOut.Write(ai4);
			}
			break;
		}
		case 30:
			if (Main.player[number].hostile)
			{
				number |= 0x80;
			}
			packetOut.Write((byte)number);
			break;
		case 36:
		{
			packetOut.Write((byte)number);
			int num2 = 0;
			if (Main.player[number].zoneEvil)
			{
				num2 = 1;
			}
			if (Main.player[number].zoneMeteor)
			{
				num2 |= 2;
			}
			if (Main.player[number].zoneDungeon)
			{
				num2 |= 4;
			}
			if (Main.player[number].zoneJungle)
			{
				num2 |= 8;
			}
			if (Main.player[number].zoneHoly)
			{
				num2 |= 0x10;
			}
			packetOut.Write((byte)num2);
			break;
		}
		case 40:
			packetOut.Write((byte)number);
			packetOut.Write(Main.player[number].talkNPC);
			break;
		case 41:
			packetOut.Write((byte)number);
			packetOut.Write(Main.player[number].itemRotation);
			packetOut.Write(Main.player[number].itemAnimation);
			break;
		case 42:
			packetOut.Write((byte)number);
			packetOut.Write(Main.player[number].statMana);
			packetOut.Write(Main.player[number].statManaMax);
			break;
		case 45:
			packetOut.Write((byte)(number | (Main.player[number].team << 4)));
			break;
		case 49:
			packetOut.Write((byte)number);
			break;
		case 50:
		{
			packetOut.Write((byte)number);
			for (int j = 0; j < 10; j++)
			{
				packetOut.Write((byte)Main.player[number].buff[j].Type);
			}
			break;
		}
		case 51:
			packetOut.Write((byte)number);
			break;
		case 54:
		{
			packetOut.Write((byte)number);
			for (int i = 0; i < 5; i++)
			{
				uint type = Main.npc[number].buff[i].Type;
				packetOut.Write((byte)type);
				if (type != 0)
				{
					WriteCompacted(Main.npc[number].buff[i].Time);
				}
			}
			break;
		}
		case 56:
			packetOut.Write((byte)number);
			packetOut.Write(NPC.chrName[number]);
			break;
		case 58:
			packetOut.Write((byte)number);
			packetOut.Write(Main.harpNote);
			break;
		}
	}

	public unsafe static void CreateMessage2(int msgType, int number, int number2)
	{
		packetOut.Write((byte)msgType);
		switch (msgType)
		{
		case 5:
		{
			int num9 = number2;
			packetOut.Write((byte)number);
			packetOut.Write((byte)num9);
			int stack2;
			int netID2;
			int prefix;
			if (num9 < 49)
			{
				stack2 = Main.player[number].inventory[num9].stack;
				netID2 = Main.player[number].inventory[num9].netID;
				prefix = Main.player[number].inventory[num9].prefix;
			}
			else
			{
				num9 -= 49;
				stack2 = Main.player[number].armor[num9].stack;
				netID2 = Main.player[number].armor[num9].netID;
				prefix = Main.player[number].armor[num9].prefix;
			}
			packetOut.Write((byte)stack2);
			if (stack2 > 0)
			{
				packetOut.Write((byte)prefix);
				packetOut.Write((short)netID2);
			}
			break;
		}
		case 10:
		{
			packetOut.Write((byte)number);
			packetOut.Write((byte)number2);
			int num = number * 40;
			int num2 = number2 * 30;
			fixed (Tile* tile = Main.tile)
			{
				Tile* ptr = null;
				uint num3 = 0u;
				for (int i = num; i < num + 40; i++)
				{
					Tile* ptr2 = tile + (num2 + i * 1440);
					for (int num4 = 29; num4 >= 0; num4--)
					{
						if (ptr != null && ptr2->isTheSameAsExcludingVisibility(ref *ptr))
						{
							num3++;
						}
						else
						{
							if (ptr != null)
							{
								WriteCompacted(num3);
							}
							num3 = 0u;
							ptr = ptr2;
							int active = ptr2->active;
							int num5 = active;
							int wall = ptr2->wall;
							if (wall > 0)
							{
								num5 |= 4;
							}
							int liquid = ptr2->liquid;
							if (liquid > 0)
							{
								num5 |= 8 | ptr2->lava;
							}
							num5 |= ptr2->wire;
							packetOut.Write((byte)num5);
							if (active != 0)
							{
								int type = ptr2->type;
								packetOut.Write((byte)type);
								if (Main.tileFrameImportant[type])
								{
									WriteCompacted((uint)ptr2->frameX);
									WriteCompacted((uint)ptr2->frameY);
								}
							}
							if (wall > 0)
							{
								packetOut.Write((byte)wall);
							}
							if (liquid > 0)
							{
								packetOut.Write((byte)liquid);
							}
						}
						ptr2++;
					}
				}
				WriteCompacted(num3);
			}
			break;
		}
		case 14:
			packetOut.Write((byte)(number | (number2 << 7)));
			break;
		case 15:
			packetOut.Write((ushort)number);
			packetOut.Write((ushort)number2);
			fixed (Tile* ptr3 = &Main.tile[number, number2])
			{
				int active2 = ptr3->active;
				int num7 = active2;
				int wall2 = ptr3->wall;
				if (wall2 > 0)
				{
					num7 |= 4;
				}
				int num8 = ((Main.netMode == 2) ? ptr3->liquid : 0);
				if (num8 > 0)
				{
					num7 |= 8 | ptr3->lava;
				}
				num7 |= ptr3->wire;
				packetOut.Write((byte)num7);
				if (active2 != 0)
				{
					int type2 = ptr3->type;
					packetOut.Write((byte)type2);
					if (Main.tileFrameImportant[type2])
					{
						WriteCompacted((uint)ptr3->frameX);
						WriteCompacted((uint)ptr3->frameY);
					}
				}
				if (wall2 > 0)
				{
					packetOut.Write((byte)wall2);
				}
				if (num8 > 0)
				{
					packetOut.Write((byte)num8);
				}
			}
			break;
		case 21:
		{
			int num6 = 0;
			int stack = Main.item[number2].stack;
			if (stack > 0 && Main.item[number2].active != 0)
			{
				num6 = Main.item[number2].netID;
			}
			if (num6 == 0 && number2 >= 200)
			{
				ClearMessage();
				break;
			}
			packetOut.Write((byte)number2);
			packetOut.Write((short)((num6 << 5) | number));
			if (num6 != 0)
			{
				packetOut.Write(Main.item[number2].prefix);
				packetOut.Write((byte)stack);
				packetOut.Write(Main.item[number2].position);
				HalfVector2 halfVector = new HalfVector2(Main.item[number2].velocity);
				packetOut.Write(halfVector.PackedValue);
			}
			break;
		}
		case 24:
			packetOut.Write((ushort)number);
			packetOut.Write((ushort)number2);
			break;
		case 29:
			WriteCompacted((uint)number);
			packetOut.Write((byte)number2);
			break;
		case 32:
		{
			WriteCompacted((uint)number);
			packetOut.Write((byte)number2);
			int netID = Main.chest[number].item[number2].netID;
			packetOut.Write((short)netID);
			if (netID != 0)
			{
				packetOut.Write(Main.chest[number].item[number2].prefix);
				packetOut.Write((byte)Main.chest[number].item[number2].stack);
			}
			break;
		}
		case 33:
			packetOut.Write((short)((number2 << 5) | number));
			if (number2 >= 0)
			{
				packetOut.Write(Main.chest[number2].x);
				packetOut.Write(Main.chest[number2].y);
			}
			break;
		case 34:
			packetOut.Write((ushort)number);
			packetOut.Write((ushort)number2);
			break;
		case 35:
			packetOut.Write((byte)number);
			WriteCompacted((uint)number2);
			break;
		case 43:
			packetOut.Write((byte)number);
			packetOut.Write((short)number2);
			break;
		case 47:
			packetOut.Write((byte)number);
			WriteCompacted((uint)number2);
			packetOut.Write(Main.sign[number2].x);
			packetOut.Write(Main.sign[number2].y);
			Main.sign[number2].text.Write(packetOut);
			break;
		case 48:
			packetOut.Write((ushort)number);
			packetOut.Write((ushort)(number2 | (Main.tile[number, number2].lava << 10)));
			packetOut.Write(Main.tile[number, number2].liquid);
			break;
		case 59:
			packetOut.Write((ushort)number);
			packetOut.Write((ushort)number2);
			break;
		case 61:
			packetOut.Write((byte)number);
			packetOut.Write((short)number2);
			break;
		case 64:
			packetOut.Write((byte)number);
			packetOut.Write((byte)number2);
			break;
		case 65:
			packetOut.Write((byte)number);
			packetOut.Write((byte)number2);
			break;
		}
	}

	public static void CreateMessage3(int msgType, int number, int number2, int number3)
	{
		packetOut.Write((byte)msgType);
		switch (msgType)
		{
		case 8:
			packetOut.Write((byte)number);
			packetOut.Write((short)number2);
			packetOut.Write((short)number3);
			break;
		case 19:
			packetOut.Write((ushort)number);
			packetOut.Write((ushort)number2);
			packetOut.Write((sbyte)number3);
			break;
		case 20:
		{
			packetOut.Write((byte)number);
			packetOut.Write((ushort)number2);
			packetOut.Write((ushort)number3);
			for (int i = number2; i < number2 + number; i++)
			{
				for (int j = number3; j < number3 + number; j++)
				{
					int active = Main.tile[i, j].active;
					int num = active;
					int wall = Main.tile[i, j].wall;
					if (wall > 0)
					{
						num |= 4;
					}
					int num2 = ((Main.netMode == 2) ? Main.tile[i, j].liquid : 0);
					if (num2 > 0)
					{
						num |= 8 | Main.tile[i, j].lava;
					}
					num |= Main.tile[i, j].wire;
					packetOut.Write((byte)num);
					if (active != 0)
					{
						int type = Main.tile[i, j].type;
						packetOut.Write((byte)type);
						if (Main.tileFrameImportant[type])
						{
							WriteCompacted((uint)Main.tile[i, j].frameX);
							WriteCompacted((uint)Main.tile[i, j].frameY);
						}
					}
					if (wall > 0)
					{
						packetOut.Write((byte)wall);
					}
					if (num2 > 0)
					{
						packetOut.Write((byte)num2);
					}
				}
			}
			break;
		}
		case 31:
			packetOut.Write((byte)number);
			packetOut.Write((ushort)number2);
			packetOut.Write((ushort)number3);
			break;
		case 46:
			packetOut.Write((byte)number);
			packetOut.Write((ushort)number2);
			packetOut.Write((ushort)number3);
			break;
		case 52:
			packetOut.Write((byte)number);
			packetOut.Write((ushort)number2);
			packetOut.Write((ushort)number3);
			break;
		case 53:
			packetOut.Write((byte)number);
			packetOut.Write((byte)number2);
			WriteCompacted((uint)number3);
			break;
		case 55:
			packetOut.Write((byte)number);
			packetOut.Write((byte)number2);
			WriteCompacted((uint)number3);
			break;
		}
	}

	public static void CreateMessage4(int msgType, int number, int number2, int number3, int number4)
	{
		packetOut.Write((byte)msgType);
		if (msgType == 60)
		{
			packetOut.Write((byte)number);
			packetOut.Write((short)number2);
			packetOut.Write((short)number3);
			packetOut.Write((byte)number4);
		}
	}

	public static void CreateMessage5(int msgType, int number, int number2, int number3, int number4, int number5 = 0)
	{
		packetOut.Write((byte)msgType);
		switch (msgType)
		{
		case 17:
			packetOut.Write((byte)number);
			packetOut.Write((ushort)number2);
			packetOut.Write((ushort)number3);
			if (number <= 4)
			{
				packetOut.Write((byte)number4);
				if (number == 1)
				{
					packetOut.Write((byte)number5);
				}
			}
			break;
		case 44:
			packetOut.Write((byte)number);
			packetOut.Write((sbyte)number2);
			packetOut.Write((short)number3);
			packetOut.Write((byte)number4);
			packetOut.Write((uint)number5);
			break;
		}
	}

	public static void SendPlayerId(NetworkGamer gamer, int playerId)
	{
		CreateMessage1(0, playerId);
		SendMessage(gamer);
	}

	public static void SendHello(int playerId)
	{
		CreateMessage1(1, playerId);
		SendMessage();
	}

	public static void SendKick(NetClient client, int textId)
	{
		CreateMessage1(2, textId);
		SendMessage(client);
	}

	public static void SendPlayerInfoRequest(NetClient client, int playerId)
	{
		CreateMessage1(3, playerId);
		SendMessage(client);
	}

	public static void SendPlayerHurt(int playerId, int dir, int dmg, bool pvp, bool critical, uint deathText)
	{
		packetOut.Write((byte)26);
		packetOut.Write((byte)playerId);
		packetOut.Write((sbyte)dir);
		packetOut.Write((short)dmg);
		packetOut.Write(pvp);
		packetOut.Write(critical);
		packetOut.Write(deathText);
		SendMessage();
	}

	public static void SendProjectile(int number, SendDataOptions sendOptions = SendDataOptions.Reliable)
	{
		packetOut.Write((byte)27);
		int num = 0;
		float knockBack = Main.projectile[number].knockBack;
		if (knockBack != 0f)
		{
			num = 1;
		}
		int damage = Main.projectile[number].damage;
		if (damage != 0)
		{
			num |= 2;
		}
		float ai = Main.projectile[number].ai0;
		if (ai != 0f)
		{
			num |= 4;
		}
		int ai2 = Main.projectile[number].ai1;
		if (ai2 != 0)
		{
			num |= 8;
		}
		packetOut.Write((byte)(Main.projectile[number].owner | (num << 4)));
		packetOut.Write(Main.projectile[number].type);
		WriteCompacted(Main.projectile[number].identity);
		packetOut.Write(Main.projectile[number].position);
		HalfVector2 halfVector = new HalfVector2(Main.projectile[number].velocity);
		packetOut.Write(halfVector.PackedValue);
		if ((num & 1) != 0)
		{
			HalfSingle halfSingle = new HalfSingle(knockBack);
			packetOut.Write(halfSingle.PackedValue);
		}
		if ((num & 2) != 0)
		{
			packetOut.Write((short)damage);
		}
		if ((num & 4) != 0)
		{
			packetOut.Write(ai);
		}
		if ((num & 8) != 0)
		{
			packetOut.Write((short)ai2);
		}
		SendProjectileMessage(ref Main.projectile[number], sendOptions);
	}

	public static void SendNpcHurt(int npcId, int dmg)
	{
		packetOut.Write((byte)28);
		packetOut.Write((byte)npcId);
		packetOut.Write((short)dmg);
		SendMessage();
	}

	public static void SendNpcHurt(int npcId, int dmg, double kb, int dir, bool critical = false)
	{
		packetOut.Write((byte)28);
		packetOut.Write((byte)npcId);
		packetOut.Write((short)dmg);
		if (dmg >= 0)
		{
			HalfSingle halfSingle = new HalfSingle((float)kb);
			packetOut.Write(halfSingle.PackedValue);
			dir <<= 1;
			if (critical)
			{
				dir |= 1;
			}
			packetOut.Write((sbyte)dir);
		}
		SendMessage();
	}

	public static void SendText(int textId, int r, int g, int b, int player)
	{
		if (player < 0 || Main.player[player].client == null)
		{
			Main.NewText(Lang.misc[textId], r, g, b);
			if (player >= 0 && Main.player[player].client == null)
			{
				return;
			}
		}
		packetOut.Write((byte)18);
		packetOut.Write((byte)r);
		packetOut.Write((byte)g);
		packetOut.Write((byte)b);
		packetOut.Write((ushort)textId);
		if (player < 0)
		{
			SendMessage();
		}
		else
		{
			SendMessage(Main.player[player].client);
		}
	}

	public static void SendText(string prefix, int textId, int r, int g, int b, int player)
	{
		if (player < 0 || Main.player[player].client == null)
		{
			Main.NewText(prefix + Lang.misc[textId], r, g, b);
			if (player >= 0 && Main.player[player].client == null)
			{
				return;
			}
		}
		packetOut.Write((byte)37);
		packetOut.Write((byte)r);
		packetOut.Write((byte)g);
		packetOut.Write((byte)b);
		packetOut.Write((ushort)textId);
		packetOut.Write(prefix);
		if (player < 0)
		{
			SendMessage();
		}
		else
		{
			SendMessage(Main.player[player].client);
		}
	}

	public static void SendText(int textId, string postfix, int r, int g, int b, int player)
	{
		if (player < 0 || Main.player[player].client == null)
		{
			Main.NewText(Lang.misc[textId] + postfix, r, g, b);
			if (player >= 0 && Main.player[player].client == null)
			{
				return;
			}
		}
		packetOut.Write((byte)38);
		packetOut.Write((byte)r);
		packetOut.Write((byte)g);
		packetOut.Write((byte)b);
		packetOut.Write((ushort)textId);
		packetOut.Write(postfix);
		if (player < 0)
		{
			SendMessage();
		}
		else
		{
			SendMessage(Main.player[player].client);
		}
	}

	public static void SendText(string text, int r, int g, int b, int player)
	{
		if (player < 0 || Main.player[player].client == null)
		{
			Main.NewText(text, r, g, b);
			if (player >= 0 && Main.player[player].client == null)
			{
				return;
			}
		}
		packetOut.Write((byte)25);
		packetOut.Write((byte)r);
		packetOut.Write((byte)g);
		packetOut.Write((byte)b);
		packetOut.Write(text);
		if (player < 0)
		{
			SendMessage();
		}
		else
		{
			SendMessage(Main.player[player].client);
		}
	}

	public static void SendDeathText(string name, uint deathText, int r, int g, int b)
	{
		Main.NewText(name + Lang.deathMsgString(deathText), r, g, b);
		packetOut.Write((byte)63);
		packetOut.Write((byte)r);
		packetOut.Write((byte)g);
		packetOut.Write((byte)b);
		packetOut.Write(deathText);
		packetOut.Write(name);
		SendMessage();
	}

	public static void SendMessage()
	{
		MemoryStream memoryStream = (MemoryStream)packetOut.BaseStream;
		int num = memoryStream.GetBuffer()[0];
		SendDataOptions options = (SendDataOptions)PRIORITY[num];
		if (Main.netMode == 1 && Netplay.session.Host != null)
		{
			try
			{
				Netplay.gamer.SendData(packetOut, options, Netplay.session.Host);
			}
			catch
			{
			}
		}
		else
		{
			for (int num2 = Netplay.clients.Count - 1; num2 >= 0; num2--)
			{
				NetClient netClient = Netplay.clients[num2];
				if (netClient.IsReadyToReceive(memoryStream.GetBuffer()))
				{
					try
					{
						Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, packetOut.Length, options, netClient.gamer);
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

	private static void SendProjectileMessage(ref Projectile projectile, SendDataOptions sendOptions)
	{
		MemoryStream memoryStream = (MemoryStream)packetOut.BaseStream;
		if (Main.netMode == 1)
		{
			try
			{
				Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, packetOut.Length, sendOptions, Netplay.session.Host);
			}
			catch
			{
			}
		}
		else
		{
			for (int num = Netplay.clients.Count - 1; num >= 0; num--)
			{
				NetClient netClient = Netplay.clients[num];
				if (netClient.IsReadyToReceiveProjectile(ref projectile))
				{
					try
					{
						Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, packetOut.Length, sendOptions, netClient.gamer);
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
		MemoryStream memoryStream = (MemoryStream)packetOut.BaseStream;
		int num = memoryStream.GetBuffer()[0];
		SendDataOptions sendDataOptions = (SendDataOptions)PRIORITY[num];
		switch (sendDataOptions)
		{
		case SendDataOptions.None:
			sendDataOptions = SendDataOptions.Reliable;
			break;
		case SendDataOptions.InOrder:
			sendDataOptions = SendDataOptions.ReliableInOrder;
			break;
		}
		try
		{
			Netplay.gamer.SendData(packetOut, sendDataOptions, client.gamer);
		}
		catch
		{
			memoryStream.Position = 0L;
			memoryStream.SetLength(0L);
		}
	}

	public static void SendMessageNoClear(NetClient client)
	{
		MemoryStream memoryStream = (MemoryStream)packetOut.BaseStream;
		int num = memoryStream.GetBuffer()[0];
		SendDataOptions sendDataOptions = (SendDataOptions)PRIORITY[num];
		switch (sendDataOptions)
		{
		case SendDataOptions.None:
			sendDataOptions = SendDataOptions.Reliable;
			break;
		case SendDataOptions.InOrder:
			sendDataOptions = SendDataOptions.ReliableInOrder;
			break;
		}
		try
		{
			Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, packetOut.Length, sendDataOptions, client.gamer);
		}
		catch
		{
		}
	}

	public static void ClearMessage()
	{
		MemoryStream memoryStream = (MemoryStream)packetOut.BaseStream;
		memoryStream.Position = 0L;
		memoryStream.SetLength(0L);
	}

	public static void SendMessageIgnore(NetClient ignoreClient)
	{
		MemoryStream memoryStream = (MemoryStream)packetOut.BaseStream;
		int num = memoryStream.GetBuffer()[0];
		SendDataOptions options = (SendDataOptions)PRIORITY[num];
		for (int num2 = Netplay.clients.Count - 1; num2 >= 0; num2--)
		{
			NetClient netClient = Netplay.clients[num2];
			if (netClient != ignoreClient && netClient.IsReadyToReceive(memoryStream.GetBuffer()))
			{
				try
				{
					Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, packetOut.Length, options, netClient.gamer);
				}
				catch
				{
				}
			}
		}
		memoryStream.Position = 0L;
		memoryStream.SetLength(0L);
	}

	public static void SendMessage(NetworkGamer gamer)
	{
		MemoryStream memoryStream = (MemoryStream)packetOut.BaseStream;
		int num = memoryStream.GetBuffer()[0];
		SendDataOptions options = (SendDataOptions)PRIORITY[num];
		try
		{
			Netplay.gamer.SendData(packetOut, options, gamer);
		}
		catch
		{
			memoryStream.Position = 0L;
			memoryStream.SetLength(0L);
		}
	}

	private static void EchoMessage(NetClient sender)
	{
		MemoryStream memoryStream = (MemoryStream)packetIn.BaseStream;
		int num = memoryStream.GetBuffer()[0];
		SendDataOptions options = (SendDataOptions)PRIORITY[num];
		for (int num2 = Netplay.clients.Count - 1; num2 >= 0; num2--)
		{
			NetClient netClient = Netplay.clients[num2];
			if (netClient != sender && netClient.IsReadyToReceive(memoryStream.GetBuffer()))
			{
				try
				{
					Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, packetIn.Length, options, netClient.gamer);
				}
				catch
				{
				}
			}
		}
	}

	private static void EchoProjectileMessage(NetClient sender, ref Projectile projectile)
	{
		MemoryStream memoryStream = (MemoryStream)packetIn.BaseStream;
		int num = memoryStream.GetBuffer()[0];
		SendDataOptions options = (SendDataOptions)PRIORITY[num];
		for (int num2 = Netplay.clients.Count - 1; num2 >= 0; num2--)
		{
			NetClient netClient = Netplay.clients[num2];
			if (netClient != sender && netClient.IsReadyToReceiveProjectile(ref projectile))
			{
				try
				{
					Netplay.gamer.SendData(memoryStream.GetBuffer(), 0, packetIn.Length, options, netClient.gamer);
				}
				catch
				{
				}
			}
		}
	}

	public unsafe static void GetData(NetClient sender)
	{
		int num = packetIn.ReadByte();
		if (Main.netMode == 1)
		{
			UI main = UI.main;
			if (Netplay.clientStatusMax > 0)
			{
				Netplay.clientStatusCount++;
			}
			switch (num)
			{
			case 2:
				Netplay.disconnect = true;
				main.statusText = Lang.misc[packetIn.ReadUInt16()];
				break;
			case 3:
			{
				if (Netplay.clientState == Netplay.ClientState.WAITING_FOR_PLAYER_DATA_REQ)
				{
					Netplay.clientState = Netplay.ClientState.RECEIVED_PLAYER_DATA_REQ;
				}
				int num2 = packetIn.ReadByte();
				CreateMessage1(4, num2);
				SendMessage();
				CreateMessage1(16, num2);
				SendMessage();
				CreateMessage1(42, num2);
				SendMessage();
				CreateMessage1(50, num2);
				SendMessage();
				for (int k = 0; k < 49; k++)
				{
					CreateMessage2(5, num2, k);
					SendMessage();
				}
				for (int l = 0; l < 11; l++)
				{
					CreateMessage2(5, num2, l + 49);
					SendMessage();
				}
				CreateMessage0(6);
				SendMessage();
				break;
			}
			case 7:
			{
				Main.gameTime.time = packetIn.ReadSingle();
				int num2 = packetIn.ReadByte();
				Main.gameTime.dayTime = (num2 & 1) != 0;
				Main.gameTime.bloodMoon = (num2 & 2) != 0;
				Main.gameTime.moonPhase = (byte)(num2 >> 2);
				Main.maxTilesX = packetIn.ReadInt16();
				Main.maxTilesY = packetIn.ReadInt16();
				Main.spawnTileX = packetIn.ReadInt16();
				Main.spawnTileY = packetIn.ReadInt16();
				Main.worldSurface = packetIn.ReadInt16();
				Main.worldSurfacePixels = Main.worldSurface << 4;
				Main.rockLayer = packetIn.ReadInt16();
				Main.rockLayerPixels = Main.rockLayer << 4;
				num2 = packetIn.ReadInt32();
				if (num2 != Main.worldID)
				{
					Main.worldID = num2;
					Main.checkWorldId = true;
				}
				num2 = packetIn.ReadInt32();
				if (num2 != Main.worldTimestamp)
				{
					Main.worldTimestamp = num2;
					Main.checkWorldId = true;
				}
				num2 = packetIn.ReadByte();
				WorldGen.shadowOrbSmashed = (num2 & 1) != 0;
				NPC.downedBoss1 = (num2 & 2) != 0;
				NPC.downedBoss2 = (num2 & 4) != 0;
				NPC.downedBoss3 = (num2 & 8) != 0;
				Main.hardMode = (num2 & 0x10) != 0;
				NPC.downedClown = (num2 & 0x20) != 0;
				Main.worldName = packetIn.ReadString();
				WorldGen.UpdateMagmaLayerPos();
				if (Netplay.clientState <= Netplay.ClientState.WAITING_FOR_WORLD_INFO)
				{
					Netplay.clientState = Netplay.ClientState.ANNOUNCING_SPAWN_LOCATION;
					UI.main.NextProgressStep(Lang.menu[74]);
				}
				break;
			}
			case 9:
				Netplay.clientStatusMax += packetIn.ReadByte();
				break;
			case 10:
			{
				int num11 = packetIn.ReadByte() * 40;
				int num12 = packetIn.ReadByte() * 30;
				fixed (Tile* tile = Main.tile)
				{
					uint num13 = 0u;
					Tile* ptr = null;
					for (int m = num11; m < num11 + 40; m++)
					{
						Tile* ptr2 = tile + (num12 + m * 1440);
						for (int num14 = 29; num14 >= 0; num14--)
						{
							if (num13 != 0)
							{
								num13--;
								*ptr2 = *ptr;
							}
							else
							{
								ptr = ptr2;
								int num15 = packetIn.ReadByte();
								int num16 = num15 & 1;
								if (num16 != 0)
								{
									int type = ptr2->type;
									int num17 = (ptr2->type = packetIn.ReadByte());
									if (Main.tileFrameImportant[num17])
									{
										ptr2->frameX = (short)ReadCompacted();
										ptr2->frameY = (short)ReadCompacted();
									}
									else if (num17 != type || ptr2->active == 0)
									{
										ptr2->frameX = -1;
										ptr2->frameY = -1;
									}
								}
								ptr2->active = (byte)num16;
								ptr2->wall = (byte)(((num15 & 4) != 0) ? packetIn.ReadByte() : 0);
								ptr2->liquid = (byte)(((num15 & 8) != 0) ? packetIn.ReadByte() : 0);
								ptr2->wire = num15 & 0x10;
								ptr2->lava = (byte)(num15 & 0x20);
								num13 = ReadCompacted();
							}
							ptr2++;
						}
					}
				}
				WorldGen.SectionTileFrame(num11, num12);
				break;
			}
			case 11:
			{
				int num5 = packetIn.ReadByte();
				GamerCollection<NetworkGamer> allGamers = Netplay.session.AllGamers;
				if (num5 != allGamers.Count)
				{
					CreateMessage0(11);
					SendMessage();
					break;
				}
				do
				{
					NetworkGamer networkGamer = allGamers[--num5];
					int num2 = packetIn.ReadByte();
					Player player = Main.player[num2];
					_ = networkGamer.IsLocal;
					networkGamer.Tag = player;
				}
				while (num5 > 0);
				break;
			}
			case 14:
			{
				int num2 = packetIn.ReadByte();
				int num3 = num2 & 0x80;
				num2 ^= num3;
				Player player = Main.player[num2];
				if (num3 != 0)
				{
					if (player.active == 0)
					{
						player.Init();
						player.active = 1;
					}
					Netplay.SetAsRemotePlayerSlot(num2);
				}
				else
				{
					player.active = 0;
				}
				break;
			}
			case 23:
			{
				int num2 = packetIn.ReadByte();
				int num6 = (int)ReadCompacted();
				Main.npc[num2].life = num6;
				if (num6 == 0)
				{
					Main.npc[num2].active = 0;
					break;
				}
				int num7 = packetIn.ReadInt16();
				if (Main.npc[num2].active == 0 || Main.npc[num2].netID != num7)
				{
					Main.npc[num2].netDefaults(num7);
				}
				Main.npc[num2].position = packetIn.ReadVector2();
				Main.npc[num2].aabb.X = (int)Main.npc[num2].position.X;
				Main.npc[num2].aabb.Y = (int)Main.npc[num2].position.Y;
				HalfVector2 halfVector = new HalfVector2
				{
					PackedValue = packetIn.ReadUInt32()
				};
				Main.npc[num2].velocity = halfVector.ToVector2();
				int num8 = packetIn.ReadSByte();
				Main.npc[num2].target = (byte)(num8 & 0xF);
				Main.npc[num2].direction = (sbyte)(num8 << 26 >> 30);
				Main.npc[num2].directionY = (sbyte)(num8 >> 6);
				int num9 = packetIn.ReadByte();
				Main.npc[num2].ai0 = (((num9 & 1) != 0) ? packetIn.ReadSingle() : 0f);
				Main.npc[num2].ai1 = (((num9 & 2) != 0) ? packetIn.ReadSingle() : 0f);
				Main.npc[num2].ai2 = (((num9 & 4) != 0) ? packetIn.ReadSingle() : 0f);
				Main.npc[num2].ai3 = (((num9 & 8) != 0) ? packetIn.ReadSingle() : 0f);
				break;
			}
			case 18:
			case 25:
			case 37:
			case 38:
			case 63:
			{
				byte r = packetIn.ReadByte();
				byte g = packetIn.ReadByte();
				byte b = packetIn.ReadByte();
				uint num10 = 0u;
				string text;
				if (num == 18)
				{
					num10 = packetIn.ReadUInt16();
					text = Lang.misc[num10];
				}
				else if (num == 63)
				{
					num10 = packetIn.ReadUInt32();
					text = packetIn.ReadString();
					text += Lang.deathMsgString(num10);
				}
				else
				{
					if (num != 25)
					{
						num10 = packetIn.ReadUInt16();
					}
					text = packetIn.ReadString();
					switch (num)
					{
					case 37:
						text += Lang.misc[num10];
						break;
					case 38:
						text = Lang.misc[num10] + text;
						break;
					}
				}
				Main.NewText(text, r, g, b);
				break;
			}
			case 49:
			{
				int num2 = packetIn.ReadByte();
				for (int j = 0; j < 4; j++)
				{
					UI uI = Main.ui[j];
					if (uI.localGamer != null && uI.myPlayer == num2)
					{
						Netplay.gamersWaitingToSpawn.Add(uI);
						break;
					}
				}
				if (Netplay.clientState >= Netplay.ClientState.WAITING_FOR_TILE_DATA)
				{
					Netplay.clientState = Netplay.ClientState.PLAYING;
				}
				break;
			}
			case 54:
			{
				int num2 = packetIn.ReadByte();
				for (int i = 0; i < 5; i++)
				{
					uint num4 = packetIn.ReadByte();
					Main.npc[num2].buff[i].Type = (ushort)num4;
					Main.npc[num2].buff[i].Time = (ushort)((num4 != 0) ? ReadCompacted() : 0u);
				}
				break;
			}
			case 56:
			{
				int num2 = packetIn.ReadByte();
				NPC.chrName[num2] = packetIn.ReadString();
				break;
			}
			case 57:
				WorldGen.tGood = packetIn.ReadByte();
				WorldGen.tEvil = packetIn.ReadByte();
				break;
			case 64:
			{
				int num2 = packetIn.ReadByte();
				UI ui2 = Main.player[num2].ui;
				num2 = packetIn.ReadByte();
				ui2?.SetTriggerState((Trigger)num2);
				break;
			}
			case 65:
			{
				int num2 = packetIn.ReadByte();
				UI ui = Main.player[num2].ui;
				num2 = packetIn.ReadByte();
				ui?.Statistics.incStat((StatisticEntry)num2);
				break;
			}
			}
		}
		else if (Main.netMode == 2)
		{
			switch (num)
			{
			case 1:
			{
				int num2 = packetIn.ReadByte();
				if (sender.serverState == 0)
				{
					if (num2 != 1)
					{
						num2 = packetIn.ReadByte();
						BootPlayer(num2, 22);
						break;
					}
					sender.serverState = 1;
				}
				num2 = packetIn.ReadByte();
				SendPlayerInfoRequest(sender, num2);
				break;
			}
			case 6:
				if (sender.serverState == 1)
				{
					sender.serverState = 2;
				}
				CreateMessage0(7);
				SendMessage(sender);
				break;
			case 8:
			{
				int num2 = packetIn.ReadByte();
				int num19 = packetIn.ReadInt16();
				int num20 = packetIn.ReadInt16();
				bool flag2 = num19 >= 0 && num20 >= 0;
				if (flag2)
				{
					if (num19 < 10 || num19 > Main.maxTilesX - 10)
					{
						flag2 = false;
					}
					else if (num20 < 10 || num20 > Main.maxTilesY - 10)
					{
						flag2 = false;
					}
				}
				int num21 = 9;
				if (flag2)
				{
					num21 <<= 1;
				}
				if (sender.serverState == 2)
				{
					sender.serverState = 3;
				}
				CreateMessage1(9, num21);
				SendMessage(sender);
				int sectionX = Main.spawnTileX / 40;
				int sectionY = Main.spawnTileY / 30;
				SendSectionSquare(sender, sectionX, sectionY, 3);
				if (flag2)
				{
					num19 /= 40;
					num20 /= 30;
					SendSectionSquare(sender, num19, num20, 3);
				}
				for (int num22 = 0; num22 < 200; num22++)
				{
					if (Main.item[num22].active != 0)
					{
						CreateMessage2(21, UI.main.myPlayer, num22);
						SendMessage(sender);
						CreateMessage1(22, num22);
						SendMessage(sender);
					}
				}
				for (int num23 = 0; num23 < 196; num23++)
				{
					NPC nPC = Main.npc[num23];
					if (nPC.active != 0)
					{
						if (nPC.townNPC)
						{
							int sectionX2 = nPC.aabb.X / 640;
							int sectionY2 = nPC.aabb.X / 640;
							SendSectionSquare(sender, sectionX2, sectionY2, 3);
						}
						CreateMessage1(23, num23);
						SendMessage(sender);
					}
				}
				CreateMessage1(56, 17);
				SendMessage(sender);
				CreateMessage1(56, 18);
				SendMessage(sender);
				CreateMessage1(56, 19);
				SendMessage(sender);
				CreateMessage1(56, 20);
				SendMessage(sender);
				CreateMessage1(56, 22);
				SendMessage(sender);
				CreateMessage1(56, 38);
				SendMessage(sender);
				CreateMessage1(56, 54);
				SendMessage(sender);
				CreateMessage1(56, 107);
				SendMessage(sender);
				CreateMessage1(56, 108);
				SendMessage(sender);
				CreateMessage1(56, 124);
				SendMessage(sender);
				CreateMessage0(57);
				SendMessage(sender);
				CreateMessage1(49, num2);
				SendMessage(sender);
				break;
			}
			case 11:
				CreateMessage0(11);
				SendMessage(sender);
				break;
			case 31:
			{
				int num2 = packetIn.ReadByte();
				Player player = Main.player[num2];
				int x = packetIn.ReadUInt16();
				int y = packetIn.ReadUInt16();
				int num26 = Chest.FindChest(x, y);
				if (num26 >= 0 && Chest.UsingChest(num26) == -1)
				{
					for (int num27 = 0; num27 < 20; num27++)
					{
						CreateMessage2(32, num26, num27);
						SendMessage(sender);
					}
					CreateMessage2(33, num2, num26);
					SendMessage(sender);
					player.chest = (short)num26;
				}
				break;
			}
			case 34:
			{
				int num24 = packetIn.ReadUInt16();
				int num25 = packetIn.ReadUInt16();
				if (Main.tile[num24, num25].type == 21 && WorldGen.KillTile(num24, num25))
				{
					CreateMessage5(17, 0, num24, num25, 0);
					SendMessage();
				}
				break;
			}
			case 46:
			{
				int num2 = packetIn.ReadByte();
				int i2 = packetIn.ReadUInt16();
				int j2 = packetIn.ReadUInt16();
				int num28 = Sign.ReadSign(i2, j2);
				if (num28 >= 0)
				{
					CreateMessage2(47, num2, num28);
					SendMessage(sender);
				}
				break;
			}
			case 53:
			{
				int num2 = packetIn.ReadByte();
				int type2 = packetIn.ReadByte();
				int time = (int)ReadCompacted();
				Main.npc[num2].AddBuff(type2, time, quiet: true);
				CreateMessage1(54, num2);
				SendMessage();
				break;
			}
			case 61:
			{
				int num2 = packetIn.ReadByte();
				int num18 = packetIn.ReadInt16();
				if (num18 < 0)
				{
					if (Main.invasionType == 0)
					{
						Main.invasionDelay = 0;
						Main.StartInvasion(-num18);
					}
					break;
				}
				bool flag = true;
				for (int n = 0; n < 196; n++)
				{
					if (Main.npc[n].type == num18 && Main.npc[n].active != 0)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					NPC.SpawnOnPlayer(Main.player[num2], num18);
				}
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
			}
		}
		switch (num)
		{
		case 4:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadUInt16();
			Player player = Main.player[num2 & 7];
			num2 >>= 4;
			player.hair = (byte)(num2 & 0x3F);
			num2 >>= 6;
			player.male = (num2 & 1) != 0;
			num2 >>= 1;
			player.difficulty = (byte)num2;
			player.hairColor.R = packetIn.ReadByte();
			player.hairColor.G = packetIn.ReadByte();
			player.hairColor.B = packetIn.ReadByte();
			player.skinColor.R = packetIn.ReadByte();
			player.skinColor.G = packetIn.ReadByte();
			player.skinColor.B = packetIn.ReadByte();
			player.eyeColor.R = packetIn.ReadByte();
			player.eyeColor.G = packetIn.ReadByte();
			player.eyeColor.B = packetIn.ReadByte();
			player.shirtColor.R = packetIn.ReadByte();
			player.shirtColor.G = packetIn.ReadByte();
			player.shirtColor.B = packetIn.ReadByte();
			player.underShirtColor.R = packetIn.ReadByte();
			player.underShirtColor.G = packetIn.ReadByte();
			player.underShirtColor.B = packetIn.ReadByte();
			player.pantsColor.R = packetIn.ReadByte();
			player.pantsColor.G = packetIn.ReadByte();
			player.pantsColor.B = packetIn.ReadByte();
			player.shoeColor.R = packetIn.ReadByte();
			player.shoeColor.G = packetIn.ReadByte();
			player.shoeColor.B = packetIn.ReadByte();
			player.oldName = player.name;
			player.name = packetIn.ReadString();
			break;
		}
		case 5:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			int num79 = packetIn.ReadByte();
			int num80 = packetIn.ReadByte();
			int pre3 = 0;
			int type6 = 0;
			if (num80 > 0)
			{
				pre3 = packetIn.ReadByte();
				type6 = packetIn.ReadInt16();
			}
			if (num79 < 49)
			{
				if (num80 > 0)
				{
					player.inventory[num79].netDefaults(type6, num80);
					player.inventory[num79].Prefix(pre3);
				}
				else
				{
					player.inventory[num79].Init();
				}
				break;
			}
			num79 -= 49;
			if (num80 > 0)
			{
				player.armor[num79].netDefaults(type6, num80);
				player.armor[num79].Prefix(pre3);
			}
			else
			{
				player.armor[num79].Init();
			}
			break;
		}
		case 12:
		{
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			if (Main.netMode == 1)
			{
				if (player.ui != null)
				{
					player.ui.setPlayer(null);
				}
			}
			else
			{
				EchoMessage(sender);
			}
			player.SpawnX = packetIn.ReadInt16();
			player.SpawnY = packetIn.ReadInt16();
			player.Spawn();
			if (Main.netMode == 2 && sender.serverState >= 3)
			{
				if (sender.serverState == 3)
				{
					sender.serverState = 10;
					greetPlayer(num2);
					syncPlayers();
				}
				else
				{
					syncPlayer(num2);
				}
			}
			break;
		}
		case 13:
		{
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2 & 0x3F];
			player.direction = (sbyte)(((num2 & 0x40) != 0) ? 1 : (-1));
			int num64 = (((num2 & 0x80) != 0) ? packetIn.ReadByte() : 0);
			player.controlUp = (num64 & 1) != 0;
			player.controlDown = (num64 & 2) != 0;
			player.controlLeft = (num64 & 4) != 0;
			player.controlRight = (num64 & 8) != 0;
			player.controlJump = (num64 & 0x10) != 0;
			player.controlUseItem = (num64 & 0x20) != 0;
			if ((num64 & 0x20) != 0)
			{
				player.selectedItem = packetIn.ReadSByte();
			}
			player.position = packetIn.ReadVector2();
			player.aabb.X = (int)player.position.X;
			player.aabb.Y = (int)player.position.Y;
			player.velocity = new HalfVector2
			{
				PackedValue = packetIn.ReadUInt32()
			}.ToVector2();
			player.fallStart = (short)(player.aabb.Y >> 4);
			if (Main.netMode == 2 && sender.serverState == 10)
			{
				EchoMessage(sender);
			}
			break;
		}
		case 15:
		{
			int num38 = packetIn.ReadUInt16();
			int num39 = packetIn.ReadUInt16();
			int num40 = packetIn.ReadByte();
			int active = Main.tile[num38, num39].active;
			Main.tile[num38, num39].active = (byte)(num40 & 1);
			Main.tile[num38, num39].wire = num40 & 0x10;
			if (Main.tile[num38, num39].active != 0)
			{
				int type3 = Main.tile[num38, num39].type;
				int num41 = (Main.tile[num38, num39].type = packetIn.ReadByte());
				if (Main.tileFrameImportant[num41])
				{
					Main.tile[num38, num39].frameX = (short)ReadCompacted();
					Main.tile[num38, num39].frameY = (short)ReadCompacted();
				}
				else if (active == 0 || num41 != type3)
				{
					Main.tile[num38, num39].frameX = -1;
					Main.tile[num38, num39].frameY = -1;
				}
			}
			if ((num40 & 4) != 0)
			{
				Main.tile[num38, num39].wall = packetIn.ReadByte();
			}
			if (Main.netMode != 2 && (num40 & 8) != 0)
			{
				Main.tile[num38, num39].lava = (byte)(num40 & 0x20);
				Main.tile[num38, num39].liquid = packetIn.ReadByte();
			}
			WorldGen.TileFrame(num38, num39);
			WorldGen.WallFrame(num38, num39);
			if (Main.netMode == 2)
			{
				CreateMessage2(15, num38, num39);
				SendMessageIgnore(sender);
			}
			break;
		}
		case 16:
		{
			int num2 = packetIn.ReadInt32();
			Player player = Main.player[num2 & 0xF];
			int num33 = num2 << 16 >> 20;
			player.statLife = (short)num33;
			if (num33 <= 0)
			{
				player.dead = true;
			}
			player.statLifeMax = (short)(num2 >> 16);
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			break;
		}
		case 17:
		{
			int num59 = packetIn.ReadByte();
			int num60 = packetIn.ReadUInt16();
			int num61 = packetIn.ReadUInt16();
			int num62 = ((num59 > 4) ? 1 : packetIn.ReadByte());
			bool flag5 = num62 == 1;
			int num63 = 0;
			if (Main.netMode == 2)
			{
				if (!flag5 && (num59 == 0 || num59 == 2 || num59 == 4) && !sender.tileSection[num60 / 40, num61 / 30])
				{
					flag5 = true;
				}
				EchoMessage(sender);
			}
			switch (num59)
			{
			case 0:
				WorldGen.KillTile(num60, num61, flag5);
				break;
			case 1:
				num63 = packetIn.ReadByte();
				WorldGen.PlaceTile(num60, num61, num62, mute: false, forced: true, -1, num63);
				if (num62 == 53 && Main.netMode == 2)
				{
					SendTile(num60, num61);
				}
				break;
			case 2:
				WorldGen.KillWall(num60, num61, flag5);
				break;
			case 3:
				WorldGen.PlaceWall(num60, num61, num62);
				break;
			case 4:
				WorldGen.KillTile(num60, num61, flag5, effectOnly: false, noItem: true);
				break;
			case 5:
				WorldGen.PlaceWire(num60, num61);
				break;
			case 6:
				WorldGen.KillWire(num60, num61);
				break;
			}
			break;
		}
		case 19:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int i5 = packetIn.ReadUInt16();
			int j5 = packetIn.ReadUInt16();
			int direction = packetIn.ReadSByte();
			WorldGen.OpenDoor(i5, j5, direction);
			break;
		}
		case 20:
		{
			int num51 = packetIn.ReadByte();
			int num52 = packetIn.ReadUInt16();
			int num53 = packetIn.ReadUInt16();
			for (int num54 = num52; num54 < num52 + num51; num54++)
			{
				for (int num55 = num53; num55 < num53 + num51; num55++)
				{
					int num56 = packetIn.ReadByte();
					int active2 = Main.tile[num54, num55].active;
					Main.tile[num54, num55].active = (byte)(num56 & 1);
					Main.tile[num54, num55].wire = num56 & 0x10;
					if (Main.tile[num54, num55].active != 0)
					{
						int type5 = Main.tile[num54, num55].type;
						int num57 = (Main.tile[num54, num55].type = packetIn.ReadByte());
						if (Main.tileFrameImportant[num57])
						{
							Main.tile[num54, num55].frameX = (short)ReadCompacted();
							Main.tile[num54, num55].frameY = (short)ReadCompacted();
						}
						else if (active2 == 0 || num57 != type5)
						{
							Main.tile[num54, num55].frameX = -1;
							Main.tile[num54, num55].frameY = -1;
						}
					}
					if ((num56 & 4) != 0)
					{
						Main.tile[num54, num55].wall = packetIn.ReadByte();
					}
					if (Main.netMode != 2 && (num56 & 8) != 0)
					{
						Main.tile[num54, num55].lava = (byte)(num56 & 0x20);
						Main.tile[num54, num55].liquid = packetIn.ReadByte();
					}
				}
			}
			WorldGen.RangeFrame(num52, num53, num52 + num51, num53 + num51);
			if (Main.netMode == 2)
			{
				CreateMessage3(20, num51, num52, num53);
				SendMessageIgnore(sender);
			}
			break;
		}
		case 21:
		{
			int num2 = packetIn.ReadByte();
			int num45 = packetIn.ReadInt16();
			int num46 = num45 & 0x1F;
			num45 >>= 5;
			if (Main.netMode == 1)
			{
				if (num45 == 0)
				{
					Main.item[num2].active = 0;
					break;
				}
				Main.item[num2].netDefaults(num45);
				Main.item[num2].Prefix(packetIn.ReadByte());
				Main.item[num2].stack = packetIn.ReadByte();
				Main.item[num2].position = packetIn.ReadVector2();
				HalfVector2 halfVector3 = new HalfVector2
				{
					PackedValue = packetIn.ReadUInt32()
				};
				Main.item[num2].velocity = halfVector3.ToVector2();
				Main.item[num2].wet = Collision.WetCollision(ref Main.item[num2].position, Main.item[num2].width, Main.item[num2].height);
				break;
			}
			if (num45 == 0)
			{
				Main.item[num2].active = 0;
				CreateMessage2(21, num46, num2);
				SendMessage();
				break;
			}
			int pre2 = packetIn.ReadByte();
			int stack2 = packetIn.ReadByte();
			float num47 = packetIn.ReadSingle();
			float num48 = packetIn.ReadSingle();
			bool flag4 = num2 == 200;
			if (flag4)
			{
				Item item = default(Item);
				item.netDefaults(num45, stack2);
				num2 = (short)Item.NewItem((int)num47, (int)num48, item.width, item.height, item.type, stack2, noBroadcast: true);
			}
			else
			{
				Main.item[num2].position.X = num47;
				Main.item[num2].position.Y = num48;
			}
			Main.item[num2].netDefaults(num45, stack2);
			Main.item[num2].Prefix(pre2);
			HalfVector2 halfVector4 = new HalfVector2
			{
				PackedValue = packetIn.ReadUInt32()
			};
			Main.item[num2].velocity = halfVector4.ToVector2();
			Main.item[num2].owner = 8;
			CreateMessage2(21, num46, num2);
			if (flag4)
			{
				SendMessage();
				Main.item[num2].ownIgnore = (byte)num46;
				Main.item[num2].ownTime = 100;
			}
			else
			{
				SendMessageIgnore(Main.player[num46].client);
			}
			break;
		}
		case 22:
		{
			int num2 = packetIn.ReadByte();
			int num34 = packetIn.ReadByte();
			int num35 = num34 & 0x80;
			num34 ^= num35;
			Main.item[num2].owner = (byte)num34;
			if (num34 < 8)
			{
				Main.item[num2].keepTime = 15;
				Main.item[num2].position = packetIn.ReadVector2();
				if (num35 != 0)
				{
					HalfVector2 halfVector2 = new HalfVector2
					{
						PackedValue = packetIn.ReadUInt32()
					};
					Main.item[num2].velocity = halfVector2.ToVector2();
				}
				else
				{
					Main.item[num2].velocity.X = 0f;
					Main.item[num2].velocity.Y = 0f;
				}
			}
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			break;
		}
		case 24:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int i4 = packetIn.ReadUInt16();
			int j4 = packetIn.ReadUInt16();
			WorldGen.CloseDoor(i4, j4, forced: true);
			break;
		}
		case 26:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			int hitDirection2 = packetIn.ReadSByte();
			int damage = packetIn.ReadInt16();
			bool pvp = packetIn.ReadBoolean();
			bool crit2 = packetIn.ReadBoolean();
			uint deathText2 = packetIn.ReadUInt32();
			Main.player[num2].Hurt(damage, hitDirection2, pvp, quiet: true, deathText2, crit2);
			break;
		}
		case 27:
		{
			int num71 = packetIn.ReadByte();
			int num72 = num71 >> 4;
			num71 &= 0xF;
			int num73 = packetIn.ReadByte();
			int num2 = (int)ReadCompacted();
			int num74 = 512;
			for (int num75 = 0; num75 < 512; num75++)
			{
				if (Main.projectile[num75].owner == num71 && Main.projectile[num75].identity == num2 && Main.projectile[num75].active != 0)
				{
					num74 = num75;
					break;
				}
			}
			if (num74 == 512)
			{
				for (int num76 = 0; num76 < 512; num76++)
				{
					if (Main.projectile[num76].active == 0)
					{
						num74 = num76;
						break;
					}
				}
			}
			if (Main.projectile[num74].active == 0 || Main.projectile[num74].type != num73)
			{
				Main.projectile[num74].SetDefaults(num73);
			}
			Main.projectile[num74].type = (byte)num73;
			Main.projectile[num74].owner = (byte)num71;
			Main.projectile[num74].identity = (ushort)num2;
			Main.projectile[num74].position = packetIn.ReadVector2();
			Main.projectile[num74].aabb.X = (int)Main.projectile[num74].position.X;
			Main.projectile[num74].aabb.Y = (int)Main.projectile[num74].position.Y;
			HalfVector2 halfVector5 = new HalfVector2
			{
				PackedValue = packetIn.ReadUInt32()
			};
			Main.projectile[num74].velocity = halfVector5.ToVector2();
			if ((num72 & 1) != 0)
			{
				HalfSingle halfSingle2 = new HalfSingle
				{
					PackedValue = packetIn.ReadUInt16()
				};
				Main.projectile[num74].knockBack = halfSingle2.ToSingle();
			}
			else
			{
				Main.projectile[num74].knockBack = 0f;
			}
			Main.projectile[num74].damage = (short)(((num72 & 2) != 0) ? packetIn.ReadInt16() : 0);
			Main.projectile[num74].ai0 = (((num72 & 4) != 0) ? packetIn.ReadSingle() : 0f);
			Main.projectile[num74].ai1 = (((num72 & 8) != 0) ? packetIn.ReadInt16() : 0);
			if (Main.netMode == 2)
			{
				EchoProjectileMessage(sender, ref Main.projectile[num74]);
			}
			break;
		}
		case 28:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			int num36 = packetIn.ReadInt16();
			if (num36 >= 0)
			{
				HalfSingle halfSingle = new HalfSingle
				{
					PackedValue = packetIn.ReadUInt16()
				};
				float knockBack = halfSingle.ToSingle();
				int num37 = packetIn.ReadSByte();
				bool crit = (num37 & 1) != 0;
				num37 >>= 1;
				Main.npc[num2].StrikeNPC(num36, knockBack, num37, crit);
			}
			else
			{
				Main.npc[num2].life = 0;
				if (Main.npc[num2].active == 0)
				{
					break;
				}
				Main.npc[num2].HitEffect();
				Main.npc[num2].active = 0;
			}
			if (Main.netMode == 2)
			{
				if (Main.npc[num2].life <= 0)
				{
					CreateMessage1(23, num2);
					SendMessage();
				}
				else
				{
					Main.npc[num2].netUpdate = true;
				}
			}
			break;
		}
		case 29:
		{
			int num2 = (int)ReadCompacted();
			int num81 = packetIn.ReadByte();
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			for (int num82 = 0; num82 < 512; num82++)
			{
				if (Main.projectile[num82].owner == num81 && Main.projectile[num82].identity == num2 && Main.projectile[num82].active != 0)
				{
					Main.projectile[num82].Kill();
					break;
				}
			}
			break;
		}
		case 30:
		{
			int num2 = packetIn.ReadByte();
			int num67 = num2 & 0x80;
			num2 ^= num67;
			Player player = Main.player[num2];
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
				int textId = ((num67 != 0) ? 24 : 25);
				SendText(player.name, textId, Main.teamColor[player.team].R, Main.teamColor[player.team].G, Main.teamColor[player.team].B, -1);
			}
			player.hostile = num67 != 0;
			break;
		}
		case 32:
		{
			int num42 = (int)ReadCompacted();
			int num43 = packetIn.ReadByte();
			if (Main.chest[num42] == null)
			{
				Main.chest[num42] = new Chest();
			}
			int num44 = packetIn.ReadInt16();
			if (num44 != 0)
			{
				int pre = packetIn.ReadByte();
				int stack = packetIn.ReadByte();
				Main.chest[num42].item[num43].netDefaults(num44, stack);
				Main.chest[num42].item[num43].Prefix(pre);
			}
			else
			{
				Main.chest[num42].item[num43].Init();
			}
			break;
		}
		case 33:
		{
			int num2 = packetIn.ReadInt16();
			Player player = Main.player[num2 & 0x1F];
			num2 >>= 5;
			if (player.isLocal())
			{
				int chest = player.chest;
				player.chest = (short)num2;
				if (num2 >= 0)
				{
					player.chestX = packetIn.ReadInt16();
					player.chestY = packetIn.ReadInt16();
				}
				if (chest == -1)
				{
					player.ui.OpenInventory();
					Main.PlaySound(10);
				}
				else if (num2 == -1)
				{
					if (player.ui.inventorySection == UI.InventorySection.CHEST)
					{
						player.ui.CloseInventory();
						Main.PlaySound(11);
					}
				}
				else if (chest != num2)
				{
					player.ui.OpenInventory();
					Main.PlaySound(12);
				}
			}
			else
			{
				player.chest = (short)num2;
				if (num2 >= 0)
				{
					packetIn.Position += 4;
				}
			}
			break;
		}
		case 35:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			int healAmount = (int)ReadCompacted();
			Player player = Main.player[num2];
			player.HealEffect(healAmount);
			break;
		}
		case 36:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			int num58 = packetIn.ReadByte();
			player.zoneEvil = (num58 & 1) != 0;
			player.zoneMeteor = (num58 & 2) != 0;
			player.zoneDungeon = (num58 & 4) != 0;
			player.zoneJungle = (num58 & 8) != 0;
			player.zoneHoly = (num58 & 0x10) != 0;
			break;
		}
		case 40:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			player.talkNPC = packetIn.ReadInt16();
			break;
		}
		case 41:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			player.itemRotation = packetIn.ReadSingle();
			player.itemAnimation = packetIn.ReadInt16();
			player.channel = player.inventory[player.selectedItem].channel;
			break;
		}
		case 42:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			player.statMana = packetIn.ReadInt16();
			player.statManaMax = packetIn.ReadInt16();
			break;
		}
		case 43:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			int manaAmount = packetIn.ReadInt16();
			Player player = Main.player[num2];
			player.ManaEffect(manaAmount);
			break;
		}
		case 44:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			int hitDirection = packetIn.ReadSByte();
			int num31 = packetIn.ReadInt16();
			int num32 = packetIn.ReadByte();
			uint deathText = packetIn.ReadUInt32();
			Player player = Main.player[num2];
			player.KillMe(num31, hitDirection, num32 != 0, deathText);
			break;
		}
		case 45:
		{
			int num2 = packetIn.ReadByte();
			int num77 = num2 >> 4;
			num2 &= 0xF;
			Player player = Main.player[num2];
			int team = player.team;
			player.team = (byte)num77;
			if (Main.netMode != 2)
			{
				break;
			}
			EchoMessage(sender);
			int textId2 = 26 + num77;
			for (int num78 = 0; num78 < 8; num78++)
			{
				if (num78 == num2 || (team > 0 && Main.player[num78].team == team) || (num77 > 0 && Main.player[num78].team == num77))
				{
					SendText(player.name, textId2, Main.teamColor[num77].R, Main.teamColor[num77].G, Main.teamColor[num77].B, num78);
				}
			}
			break;
		}
		case 47:
		{
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			num2 = (int)ReadCompacted();
			Main.sign[num2].Read(packetIn);
			if (Main.netMode == 1 && num2 != player.sign)
			{
				player.ui.CloseInventory();
				player.talkNPC = -1;
				player.ui.editSign = false;
				Main.PlaySound(10);
				player.sign = (short)num2;
				player.ui.npcChatText = Main.sign[num2].text;
			}
			break;
		}
		case 48:
		{
			int num68 = packetIn.ReadUInt16();
			int num69 = packetIn.ReadUInt16();
			int num70 = num69 & 0x7FFF;
			Main.tile[num68, num70].liquid = packetIn.ReadByte();
			Main.tile[num68, num70].lava = (byte)((num69 >> 10) & 0x20);
			if (Main.netMode == 2)
			{
				WorldGen.SquareTileFrame(num68, num70);
			}
			break;
		}
		case 50:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			for (int num65 = 0; num65 < 10; num65++)
			{
				int num66 = packetIn.ReadByte();
				player.buff[num65].Type = (ushort)num66;
				player.buff[num65].Time = (ushort)((num66 > 0) ? 60u : 0u);
			}
			break;
		}
		case 51:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			Player player = Main.player[packetIn.ReadByte()];
			Main.PlaySound(2, player.aabb.X, player.aabb.Y);
			break;
		}
		case 52:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			int num49 = packetIn.ReadUInt16();
			int num50 = packetIn.ReadUInt16();
			Chest.Unlock(num49, num50);
			if (Main.netMode == 2)
			{
				SendTileSquare(num49, num50, 2);
			}
			break;
		}
		case 55:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			int type4 = packetIn.ReadByte();
			int time2 = (int)ReadCompacted();
			player.AddBuff(type4, time2);
			break;
		}
		case 58:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int num2 = packetIn.ReadByte();
			Player player = Main.player[num2];
			Main.harpNote = packetIn.ReadSingle();
			Main.PlaySound(2, player.aabb.X, player.aabb.Y, (player.inventory[player.selectedItem].type == 507) ? 35 : 26);
			break;
		}
		case 59:
		{
			if (Main.netMode == 2)
			{
				EchoMessage(sender);
			}
			int i3 = packetIn.ReadUInt16();
			int j3 = packetIn.ReadUInt16();
			WorldGen.hitSwitch(i3, j3);
			break;
		}
		case 60:
		{
			int num2 = packetIn.ReadByte();
			int num29 = packetIn.ReadInt16();
			int num30 = packetIn.ReadInt16();
			bool flag3 = packetIn.ReadBoolean();
			if (Main.netMode == 1)
			{
				Main.npc[num2].homeless = flag3;
				Main.npc[num2].homeTileX = (short)num29;
				Main.npc[num2].homeTileY = (short)num30;
			}
			else if (!flag3)
			{
				WorldGen.kickOut(num2);
			}
			else
			{
				WorldGen.moveRoom(num29, num30, num2);
			}
			break;
		}
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 14:
		case 18:
		case 23:
		case 25:
		case 31:
		case 34:
		case 37:
		case 38:
		case 39:
		case 46:
		case 49:
		case 53:
		case 54:
		case 56:
		case 57:
			break;
		}
	}

	public static void BootPlayer(int plr, int stringId)
	{
		SendKick(Main.player[plr].client, stringId);
		Main.player[plr].kill = true;
	}

	public static void SendTileSquare(int tileX, int tileY, int size)
	{
		int num = size - 1 >> 1;
		CreateMessage3(20, size, tileX - num, tileY - num);
		SendMessage();
	}

	public static void SendTile(int tileX, int tileY)
	{
		CreateMessage2(15, tileX, tileY);
		SendMessage();
	}

	public static bool SendSection(NetClient client, int sectionX, int sectionY)
	{
		if (sectionX >= 0 && sectionY >= 0 && sectionX < Main.maxSectionsX && sectionY < Main.maxSectionsY && !client.tileSection[sectionX, sectionY])
		{
			client.tileSection[sectionX, sectionY] = true;
			CreateMessage2(10, sectionX, sectionY);
			SendMessage(client);
			return true;
		}
		return false;
	}

	public static void SendSectionSquare(NetClient client, int sectionX, int sectionY, int size)
	{
		int num = size - 1 >> 1;
		for (int i = sectionX - num; i <= sectionX + num; i++)
		{
			for (int j = sectionY - num; j <= sectionY + num; j++)
			{
				SendSection(client, i, j);
			}
		}
	}

	public static void greetPlayer(int plr)
	{
		SendText(31, Main.player[plr].name + "!", 255, 240, 20, plr);
		string text = null;
		for (int i = 0; i < 8; i++)
		{
			if (Main.player[i].active != 0)
			{
				text = ((text != null) ? (text + ", " + Main.player[i].name) : Main.player[i].name);
			}
		}
		text += '.';
		SendText(23, text, 255, 240, 20, plr);
	}

	public static void sendWater(int x, int y)
	{
		CreateMessage2(48, x, y);
		if (Main.netMode == 1)
		{
			SendMessage();
			return;
		}
		for (int num = Netplay.clients.Count - 1; num >= 0; num--)
		{
			NetClient netClient = Netplay.clients[num];
			if (netClient.serverState >= 3)
			{
				int num2 = x / 40;
				int num3 = y / 30;
				if (netClient.tileSection[num2, num3])
				{
					SendMessageNoClear(netClient);
				}
			}
		}
		ClearMessage();
	}

	public static void syncPlayer(int plr)
	{
		Player player = Main.player[plr];
		NetClient client = player.client;
		CreateMessage2(14, plr, player.active);
		SendMessageIgnore(client);
		if (player.active != 0 && (client == null || client.serverState == 10))
		{
			CreateMessage1(4, plr);
			SendMessageIgnore(client);
			CreateMessage1(13, plr);
			SendMessageIgnore(client);
			CreateMessage1(16, plr);
			SendMessageIgnore(client);
			CreateMessage1(30, plr);
			SendMessageIgnore(client);
			CreateMessage1(42, plr);
			SendMessageIgnore(client);
			CreateMessage1(45, plr);
			SendMessageIgnore(client);
			CreateMessage1(50, plr);
			SendMessageIgnore(client);
			for (int i = 0; i < 49; i++)
			{
				CreateMessage2(5, plr, i);
				SendMessage();
			}
			for (int j = 0; j < 11; j++)
			{
				CreateMessage2(5, plr, j + 49);
				SendMessage();
			}
			if (!Main.player[plr].announced)
			{
				Main.player[plr].announced = true;
				SendText(player.name, 32, 255, 240, 20, -1);
				player.oldName = player.name;
			}
		}
		else if (player.announced)
		{
			player.announced = false;
			SendText(player.oldName, 33, 255, 240, 20, -1);
		}
	}

	public static void syncPlayers()
	{
		for (int i = 0; i < 8; i++)
		{
			syncPlayer(i);
		}
		for (int j = 0; j < 196; j++)
		{
			if (Main.npc[j].active != 0 && Main.npc[j].townNPC && -1 != Main.npc[j].getHeadTextureId())
			{
				CreateMessage4(60, j, Main.npc[j].homeTileX, Main.npc[j].homeTileY, Main.npc[j].homeless ? 1 : 0);
				SendMessage();
			}
		}
	}
}
