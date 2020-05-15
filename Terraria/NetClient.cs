using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;

namespace Terraria
{
	public sealed class NetClient
	{
		public NetworkMachine machine;

		public NetworkGamer gamer;

		public short serverState;

		private bool isPublicSlotRequest;

		public bool[] playerSlots;

		public bool[,] tileSection;

		public NetClient(NetworkGamer g)
		{
			machine = g.Machine;
			gamer = g;
			serverState = 0;
			isPublicSlotRequest = false;
			playerSlots = new bool[16];
			tileSection = new bool[127, 49];
		}

		public void RequestedPublicSlot()
		{
			Netplay.session.PrivateGamerSlots--;
			isPublicSlotRequest = true;
		}

		public void CanceledPublicSlot()
		{
			Netplay.session.PrivateGamerSlots++;
			isPublicSlotRequest = false;
		}

		public void GamerJoined(Player player)
		{
			player.client = this;
			int whoAmI = player.whoAmI;
			playerSlots[whoAmI] = true;
			playerSlots[whoAmI + 8] = isPublicSlotRequest;
			isPublicSlotRequest = false;
		}

		public bool GamerLeft(Player player)
		{
			int whoAmI = player.whoAmI;
			playerSlots[whoAmI] = false;
			if (playerSlots[whoAmI + 8])
			{
				playerSlots[whoAmI + 8] = false;
				Netplay.session.PrivateGamerSlots++;
			}
			player.client = null;
			return machine.Gamers.Count == 0;
		}

		public void ResetSections()
		{
			for (int i = 0; i < Main.maxSectionsX; i++)
			{
				for (int j = 0; j < Main.maxSectionsY; j++)
				{
					tileSection[i, j] = false;
				}
			}
		}

		public void ResetSections(ref Vector2i min, ref Vector2i max)
		{
			int num = min.X / 40;
			int num2 = min.Y / 30;
			int num3 = max.X / 40;
			int num4 = max.Y / 30;
			for (int i = num; i <= num3; i++)
			{
				for (int j = num2; j <= num4; j++)
				{
					tileSection[i, j] = false;
				}
			}
		}

		public bool SectionRange(int size, int firstX, int firstY)
		{
			int num = firstX / 40;
			int num2 = firstY / 30;
			if (tileSection[num, num2])
			{
				return true;
			}
			int num3 = (firstY + size) / 30;
			if (tileSection[num, num3])
			{
				return true;
			}
			num = (firstX + size) / 40;
			if (tileSection[num, num2])
			{
				return true;
			}
			return tileSection[num, num3];
		}

		public bool IsReadyToReceive(byte[] packet)
		{
			if (serverState < 10)
			{
				return false;
			}
			switch (packet[0])
			{
			case 13:
			{
				Player player2 = Main.player[packet[1] & 7];
				if (player2.netSkip == 0)
				{
					return true;
				}
				Rectangle aabb2 = player2.aabb;
				aabb2.X -= 2500;
				aabb2.Y -= 2500;
				aabb2.Width += 5000;
				aabb2.Height += 5000;
				for (int num2 = machine.Gamers.Count - 1; num2 >= 0; num2--)
				{
					NetworkGamer networkGamer2 = machine.Gamers[num2];
					Player player3 = networkGamer2.Tag as Player;
					if (aabb2.Intersects(player3.aabb))
					{
						return true;
					}
				}
				return false;
			}
			case 20:
				return SectionRange(packet[1], packet[2] | (packet[3] << 8), packet[4] | (packet[5] << 8));
			case 23:
			case 28:
			{
				NPC nPC = Main.npc[packet[1]];
				if (nPC.life <= 0)
				{
					return true;
				}
				if (nPC.townNPC)
				{
					return true;
				}
				Rectangle aabb = nPC.aabb;
				aabb.X -= 3000;
				aabb.Y -= 3000;
				aabb.Width += 6000;
				aabb.Height += 6000;
				for (int num = machine.Gamers.Count - 1; num >= 0; num--)
				{
					NetworkGamer networkGamer = machine.Gamers[num];
					Player player = networkGamer.Tag as Player;
					if (aabb.Intersects(player.aabb))
					{
						return true;
					}
				}
				return false;
			}
			default:
				return true;
			}
		}

		public bool IsReadyToReceiveProjectile(ref Projectile projectile)
		{
			if (serverState == 10)
			{
				if (projectile.type == 12)
				{
					return true;
				}
				Rectangle aabb = projectile.aabb;
				aabb.X -= 5000;
				aabb.Y -= 5000;
				aabb.Width += 10000;
				aabb.Height += 10000;
				for (int num = machine.Gamers.Count - 1; num >= 0; num--)
				{
					NetworkGamer networkGamer = machine.Gamers[num];
					Player player = networkGamer.Tag as Player;
					if (aabb.Intersects(player.aabb))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
