using System;

namespace Terraria
{
	public struct Tile
	{
		[Flags]
		public enum Flags : byte
		{
			WALLFRAME_MASK = 0x3,
			NEARBY = 0x4,
			VISITED = 0x8,
			WIRE = 0x10,
			SELECTED = 0x20,
			LAVA = 0x20,
			CHECKING_LIQUID = 0x40,
			SKIP_LIQUID = 0x80,
			HIGHLIGHT_MASK = 0x24
		}

		public byte active;

		public byte type;

		public Flags flags;

		public byte liquid;

		public byte lava;

		public byte wall;

		public ushort wallFrameX;

		public byte wallFrameY;

		public byte frameNumber;

		public short frameX;

		public short frameY;

		public int wallFrameNumber
		{
			get
			{
				return (int)(flags & Flags.WALLFRAME_MASK);
			}
			set
			{
				flags = (Flags)((int)(byte)value | (int)(flags & ~Flags.WALLFRAME_MASK));
			}
		}

		public int checkingLiquid
		{
			get
			{
				return (int)(flags & Flags.CHECKING_LIQUID);
			}
			set
			{
				flags = (Flags)((int)(byte)value | (int)(flags & ~Flags.CHECKING_LIQUID));
			}
		}

		public int skipLiquid
		{
			get
			{
				return (int)(flags & Flags.SKIP_LIQUID);
			}
			set
			{
				flags = (Flags)((int)(byte)value | (int)(flags & ~Flags.SKIP_LIQUID));
			}
		}

		public int wire
		{
			get
			{
				return (int)(flags & Flags.WIRE);
			}
			set
			{
				flags = (Flags)((int)(byte)value | (int)(flags & ~Flags.WIRE));
			}
		}

		public void Clear()
		{
			active = 0;
			flags = ~(Flags.WALLFRAME_MASK | Flags.NEARBY | Flags.VISITED | Flags.WIRE | Flags.SELECTED | Flags.CHECKING_LIQUID | Flags.SKIP_LIQUID);
			type = 0;
			wall = 0;
			wallFrameX = 0;
			wallFrameY = 0;
			liquid = 0;
			lava = 0;
			frameNumber = 0;
		}

		public bool isTheSameAsExcludingVisibility(ref Tile compTile)
		{
			if (active != compTile.active)
			{
				return false;
			}
			if (active != 0)
			{
				if (type != compTile.type)
				{
					return false;
				}
				if (Main.tileFrameImportant[type])
				{
					if (frameX != compTile.frameX)
					{
						return false;
					}
					if (frameY != compTile.frameY)
					{
						return false;
					}
				}
			}
			if (wall != compTile.wall)
			{
				return false;
			}
			if (liquid != compTile.liquid)
			{
				return false;
			}
			if ((flags & Flags.WIRE) != (compTile.flags & Flags.WIRE))
			{
				return false;
			}
			return true;
		}

		public bool isTheSameAs(ref Tile compTile)
		{
			if (active != compTile.active)
			{
				return false;
			}
			if (active != 0)
			{
				if (type != compTile.type)
				{
					return false;
				}
				if (Main.tileFrameImportant[type])
				{
					if (frameX != compTile.frameX)
					{
						return false;
					}
					if (frameY != compTile.frameY)
					{
						return false;
					}
				}
			}
			if (wall != compTile.wall)
			{
				return false;
			}
			if (liquid != compTile.liquid)
			{
				return false;
			}
			if ((flags & (Flags.VISITED | Flags.WIRE)) != (compTile.flags & (Flags.VISITED | Flags.WIRE)))
			{
				return false;
			}
			return true;
		}

		public bool isFullTile()
		{
			if (active != 0 && type != 10 && type != 54 && type != 138 && Main.tileSolidNotSolidTop[type])
			{
				int num = frameY;
				if (num == 18)
				{
					int num2 = frameX;
					if (num2 >= 18 && num2 <= 54)
					{
						return true;
					}
					if (num2 >= 108 && num2 <= 144)
					{
						return true;
					}
				}
				else if (num >= 90 && num <= 196)
				{
					int num3 = frameX;
					if (num3 <= 70)
					{
						return true;
					}
					if (num3 >= 144 && num3 <= 232)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool canStandOnTop()
		{
			if (active != 0)
			{
				if (!Main.tileSolid[type])
				{
					if (frameY == 0)
					{
						return Main.tileSolidTop[type];
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
