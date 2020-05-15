namespace Terraria
{
	public sealed class CRC32
	{
		private const uint kCrcPoly = 3988292384u;

		private const int CRC_NUM_TABLES = 8;

		private static uint[] table;

		private uint value;

		public static void Initialize()
		{
			table = new uint[2048];
			int i;
			for (i = 0; i < 256; i++)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					num = (uint)((int)(num >> 1) ^ (-306674912 & (int)(~((num & 1) - 1))));
				}
				table[i] = num;
			}
			for (; i < 2048; i++)
			{
				uint num2 = table[i - 256];
				table[i] = (table[num2 & 0xFF] ^ (num2 >> 8));
			}
		}

		public CRC32()
		{
			value = uint.MaxValue;
		}

		public void Init()
		{
			value = uint.MaxValue;
		}

		public uint GetValue()
		{
			return (uint)((int)value ^ -1);
		}

		public void UpdateByte(byte b)
		{
			value = ((value >> 8) ^ table[(byte)value ^ b]);
		}

		public void Update(byte[] data, int offset, int size)
		{
			if (size == 0)
			{
				return;
			}
			uint[] array = table;
			uint num = value;
			while ((offset & 7) != 0 && size != 0)
			{
				num = ((num >> 8) ^ array[(byte)num ^ data[offset++]]);
				size--;
			}
			if (size >= 8)
			{
				int num2 = (size - 8) & -8;
				size -= num2;
				num2 += offset;
				while (offset != num2)
				{
					num = (uint)((int)num ^ (data[offset] + (data[offset + 1] << 8) + (data[offset + 2] << 16) + (data[offset + 3] << 24)));
					uint num3 = (uint)(data[offset + 4] + (data[offset + 5] << 8) + (data[offset + 6] << 16) + (data[offset + 7] << 24));
					offset += 8;
					num = (array[(byte)num + 1792] ^ array[(byte)(num >>= 8) + 1536] ^ array[(byte)(num >>= 8) + 1280] ^ array[(num >> 8) + 1024] ^ array[(byte)num3 + 768] ^ array[(byte)(num3 >>= 8) + 512] ^ array[(byte)(num3 >>= 8) + 256] ^ array[num3 >> 8]);
				}
			}
			while (size-- != 0)
			{
				num = ((num >> 8) ^ array[(byte)num ^ data[offset++]]);
			}
			value = num;
		}
	}
}
