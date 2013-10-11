// Type: Terraria.FastRandom
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using System;

namespace Terraria
{
  public sealed class FastRandom
  {
    private uint bitMask = 1U;
    private const double REAL_UNIT_INT = 4.65661287307739E-10;
    private const double REAL_UNIT_UINT = 2.3283064365387E-10;
    private const uint Y = 842502087U;
    private const uint Z = 3579807591U;
    private const uint W = 273326509U;
    private uint x;
    private uint y;
    private uint z;
    private uint w;
    private uint bitBuffer;

    public FastRandom()
    {
      this.Reinitialise((uint) Environment.TickCount);
    }

    public FastRandom(uint seed)
    {
      this.Reinitialise(seed);
    }

    public void Reinitialise(uint seed)
    {
      this.x = seed;
      this.y = 842502087U;
      this.z = 3579807591U;
      this.w = 273326509U;
    }

    public int Next()
    {
      uint num1;
      do
      {
        uint num2 = this.x ^ this.x << 11;
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ ((int) num2 ^ (int) (num2 >> 8)));
        num1 = this.w & (uint) int.MaxValue;
      }
      while ((int) num1 == int.MaxValue);
      return (int) num1;
    }

    public int Next(int upperBound)
    {
      uint num = this.x ^ this.x << 11;
      this.x = this.y;
      this.y = this.z;
      this.z = this.w;
      return (int) (4.65661287307739E-10 * (double) (int.MaxValue & (int) (this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ ((int) num ^ (int) (num >> 8))))) * (double) upperBound);
    }

    public int Next(int lowerBound, int upperBound)
    {
      uint num = this.x ^ this.x << 11;
      this.x = this.y;
      this.y = this.z;
      this.z = this.w;
      return lowerBound + (int) (4.65661287307739E-10 * (double) (int.MaxValue & (int) (this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ ((int) num ^ (int) (num >> 8))))) * (double) (upperBound - lowerBound));
    }

    public double NextDouble()
    {
      uint num = this.x ^ this.x << 11;
      this.x = this.y;
      this.y = this.z;
      this.z = this.w;
      return 4.65661287307739E-10 * (double) (int.MaxValue & (int) (this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ ((int) num ^ (int) (num >> 8)))));
    }

    public void NextBytes(byte[] buffer)
    {
      uint num1 = this.x;
      uint num2 = this.y;
      uint num3 = this.z;
      uint num4 = this.w;
      int num5 = 0;
      int num6 = buffer.Length - 3;
      while (num5 < num6)
      {
        uint num7 = num1 ^ num1 << 11;
        num1 = num2;
        num2 = num3;
        num3 = num4;
        num4 = (uint) ((int) num4 ^ (int) (num4 >> 19) ^ ((int) num7 ^ (int) (num7 >> 8)));
        byte[] numArray1 = buffer;
        int index1 = num5;
        int num8 = 1;
        int num9 = index1 + num8;
        int num10 = (int) (byte) num4;
        numArray1[index1] = (byte) num10;
        byte[] numArray2 = buffer;
        int index2 = num9;
        int num11 = 1;
        int num12 = index2 + num11;
        int num13 = (int) (byte) (num4 >> 8);
        numArray2[index2] = (byte) num13;
        byte[] numArray3 = buffer;
        int index3 = num12;
        int num14 = 1;
        int num15 = index3 + num14;
        int num16 = (int) (byte) (num4 >> 16);
        numArray3[index3] = (byte) num16;
        byte[] numArray4 = buffer;
        int index4 = num15;
        int num17 = 1;
        num5 = index4 + num17;
        int num18 = (int) (byte) (num4 >> 24);
        numArray4[index4] = (byte) num18;
      }
      if (num5 < buffer.Length)
      {
        uint num7 = num1 ^ num1 << 11;
        num1 = num2;
        num2 = num3;
        num3 = num4;
        num4 = (uint) ((int) num4 ^ (int) (num4 >> 19) ^ ((int) num7 ^ (int) (num7 >> 8)));
        byte[] numArray1 = buffer;
        int index1 = num5;
        int num8 = 1;
        int num9 = index1 + num8;
        int num10 = (int) (byte) num4;
        numArray1[index1] = (byte) num10;
        if (num9 < buffer.Length)
        {
          byte[] numArray2 = buffer;
          int index2 = num9;
          int num11 = 1;
          int num12 = index2 + num11;
          int num13 = (int) (byte) (num4 >> 8);
          numArray2[index2] = (byte) num13;
          if (num12 < buffer.Length)
          {
            byte[] numArray3 = buffer;
            int index3 = num12;
            int num14 = 1;
            int index4 = index3 + num14;
            int num15 = (int) (byte) (num4 >> 16);
            numArray3[index3] = (byte) num15;
            if (index4 < buffer.Length)
              buffer[index4] = (byte) (num4 >> 24);
          }
        }
      }
      this.x = num1;
      this.y = num2;
      this.z = num3;
      this.w = num4;
    }

    public uint NextUInt()
    {
      uint num = this.x ^ this.x << 11;
      this.x = this.y;
      this.y = this.z;
      this.z = this.w;
      return this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ ((int) num ^ (int) (num >> 8)));
    }

    public int NextInt()
    {
      uint num = this.x ^ this.x << 11;
      this.x = this.y;
      this.y = this.z;
      this.z = this.w;
      return int.MaxValue & (int) (this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ ((int) num ^ (int) (num >> 8))));
    }

    public bool NextBool()
    {
      if ((int) this.bitMask != 1)
        return ((int) this.bitBuffer & (int) (this.bitMask >>= 1)) == 0;
      uint num = this.x ^ this.x << 11;
      this.x = this.y;
      this.y = this.z;
      this.z = this.w;
      this.bitBuffer = this.w = (uint) ((int) this.w ^ (int) (this.w >> 19) ^ ((int) num ^ (int) (num >> 8)));
      this.bitMask = (uint) int.MinValue;
      return ((int) this.bitBuffer & (int) this.bitMask) == 0;
    }
  }
}
