using System;

namespace Terraria
{
	public sealed class FastRandom
	{
		private const double REAL_UNIT_INT = 4.6566128730773926E-10;

		private const double REAL_UNIT_UINT = 2.3283064365386963E-10;

		private const uint Y = 842502087u;

		private const uint Z = 3579807591u;

		private const uint W = 273326509u;

		private uint x;

		private uint y;

		private uint z;

		private uint w;

		private uint bitBuffer;

		private uint bitMask = 1u;

		public FastRandom()
		{
			Reinitialise((uint)Environment.TickCount);
		}

		public FastRandom(uint seed)
		{
			Reinitialise(seed);
		}

		public void Reinitialise(uint seed)
		{
			x = seed;
			y = 842502087u;
			z = 3579807591u;
			w = 273326509u;
		}

		public int Next()
		{
			uint num2;
			do
			{
				uint num = x ^ (x << 11);
				x = y;
				y = z;
				z = w;
				w = (w ^ (w >> 19) ^ (num ^ (num >> 8)));
				num2 = (w & int.MaxValue);
			}
			while (num2 == int.MaxValue);
			return (int)num2;
		}

		public int Next(int upperBound)
		{
			uint num = x ^ (x << 11);
			x = y;
			y = z;
			z = w;
			return (int)(4.6566128730773926E-10 * (double)(int)(int.MaxValue & (w = (w ^ (w >> 19) ^ (num ^ (num >> 8))))) * (double)upperBound);
		}

		public int Next(int lowerBound, int upperBound)
		{
			uint num = x ^ (x << 11);
			x = y;
			y = z;
			z = w;
			return lowerBound + (int)(4.6566128730773926E-10 * (double)(int)(int.MaxValue & (w = (w ^ (w >> 19) ^ (num ^ (num >> 8))))) * (double)(upperBound - lowerBound));
		}

		public double NextDouble()
		{
			uint num = x ^ (x << 11);
			x = y;
			y = z;
			z = w;
			return 4.6566128730773926E-10 * (double)(int)(int.MaxValue & (w = (w ^ (w >> 19) ^ (num ^ (num >> 8)))));
		}

		public void NextBytes(byte[] buffer)
		{
			uint num = x;
			uint num2 = y;
			uint num3 = z;
			uint num4 = w;
			int num5 = 0;
			int num6 = buffer.Length - 3;
			while (num5 < num6)
			{
				uint num7 = num ^ (num << 11);
				num = num2;
				num2 = num3;
				num3 = num4;
				num4 = (num4 ^ (num4 >> 19) ^ (num7 ^ (num7 >> 8)));
				buffer[num5++] = (byte)num4;
				buffer[num5++] = (byte)(num4 >> 8);
				buffer[num5++] = (byte)(num4 >> 16);
				buffer[num5++] = (byte)(num4 >> 24);
			}
			if (num5 < buffer.Length)
			{
				uint num7 = num ^ (num << 11);
				num = num2;
				num2 = num3;
				num3 = num4;
				num4 = (num4 ^ (num4 >> 19) ^ (num7 ^ (num7 >> 8)));
				buffer[num5++] = (byte)num4;
				if (num5 < buffer.Length)
				{
					buffer[num5++] = (byte)(num4 >> 8);
					if (num5 < buffer.Length)
					{
						buffer[num5++] = (byte)(num4 >> 16);
						if (num5 < buffer.Length)
						{
							buffer[num5] = (byte)(num4 >> 24);
						}
					}
				}
			}
			x = num;
			y = num2;
			z = num3;
			w = num4;
		}

		public uint NextUInt()
		{
			uint num = x ^ (x << 11);
			x = y;
			y = z;
			z = w;
			return w = (w ^ (w >> 19) ^ (num ^ (num >> 8)));
		}

		public int NextInt()
		{
			uint num = x ^ (x << 11);
			x = y;
			y = z;
			z = w;
			return (int)(int.MaxValue & (w = (w ^ (w >> 19) ^ (num ^ (num >> 8)))));
		}

		public bool NextBool()
		{
			if (bitMask == 1)
			{
				uint num = x ^ (x << 11);
				x = y;
				y = z;
				z = w;
				bitBuffer = (w = (w ^ (w >> 19) ^ (num ^ (num >> 8))));
				bitMask = 2147483648u;
				return (bitBuffer & bitMask) == 0;
			}
			return (bitBuffer & (bitMask >>= 1)) == 0;
		}
	}
}
