using Microsoft.Xna.Framework.Net;
using System.IO;

namespace Terraria
{
	public struct Sign
	{
		public const int MAX_SIGNS = 1000;

		public short x;

		public short y;

		public UserString text;

		public void Init()
		{
			x = -1;
			y = -1;
			text = null;
		}

		public static void KillSign(int x, int y)
		{
			int num = 0;
			while (true)
			{
				if (num < 1000)
				{
					if (Main.sign[num].x == x && Main.sign[num].y == y)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			Main.sign[num].Init();
		}

		public static int ReadSign(int i, int j)
		{
			int num = (Main.tile[i, j].frameX / 18) & 1;
			int num2 = Main.tile[i, j].frameY / 18;
			int num3 = i - num;
			int num4 = j - num2;
			if (Main.tile[num3, num4].type != 55 && Main.tile[num3, num4].type != 85)
			{
				KillSign(num3, num4);
				return -1;
			}
			int num5 = 0;
			for (int k = 0; k < 1000; k++)
			{
				if (Main.sign[k].x < 0)
				{
					num5 = k;
				}
				else if (Main.sign[k].x == num3 && Main.sign[k].y == num4)
				{
					return k;
				}
			}
			for (int l = num5; l < 1000; l++)
			{
				if (Main.sign[l].x < 0)
				{
					Main.sign[l].x = (short)num3;
					Main.sign[l].y = (short)num4;
					Main.sign[l].text = new UserString("", verified: true);
					return l;
				}
			}
			return -1;
		}

		private unsafe bool Validate()
		{
			fixed (Tile* ptr = &Main.tile[x, y])
			{
				if (ptr->active == 0 || (ptr->type != 55 && ptr->type != 85))
				{
					Init();
					return false;
				}
			}
			return true;
		}

		public void SetText(UserString s)
		{
			if (Validate())
			{
				text = s;
			}
		}

		public void Read(PacketReader packetIn)
		{
			x = packetIn.ReadInt16();
			y = packetIn.ReadInt16();
			text = new UserString(packetIn);
		}

		public void Read(BinaryReader fileIO, int release)
		{
			if (fileIO.ReadBoolean())
			{
				if (release >= 49)
				{
					x = fileIO.ReadInt16();
					y = fileIO.ReadInt16();
					text = new UserString(fileIO);
				}
				else
				{
					text = fileIO.ReadString();
					x = fileIO.ReadInt16();
					y = fileIO.ReadInt16();
				}
				Validate();
			}
		}

		public void Write(BinaryWriter fileIO)
		{
			if (x < 0 || text == null)
			{
				fileIO.Write(value: false);
				return;
			}
			fileIO.Write(value: true);
			fileIO.Write(x);
			fileIO.Write(y);
			text.Write(fileIO);
		}
	}
}
