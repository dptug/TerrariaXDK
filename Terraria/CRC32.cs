// Type: Terraria.CRC32
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using System;

namespace Terraria
{
  public sealed class CRC32
  {
    private const uint kCrcPoly = 3988292384U;
    private const int CRC_NUM_TABLES = 8;
    private static uint[] table;
    private uint value;

    public CRC32()
    {
      this.value = uint.MaxValue;
    }

    public static void Initialize()
    {
      CRC32.table = new uint[2048];
      int index1;
      for (index1 = 0; index1 < 256; ++index1)
      {
        uint num = (uint) index1;
        for (int index2 = 0; index2 < 8; ++index2)
          num = num >> 1 ^ (uint) (-306674912 & ~(((int) num & 1) - 1));
        CRC32.table[index1] = num;
      }
      for (; index1 < 2048; ++index1)
      {
        uint num = CRC32.table[index1 - 256];
        CRC32.table[index1] = CRC32.table[(IntPtr) (num & (uint) byte.MaxValue)] ^ num >> 8;
      }
    }

    public void Init()
    {
      this.value = uint.MaxValue;
    }

    public uint GetValue()
    {
      return this.value ^ uint.MaxValue;
    }

    public void UpdateByte(byte b)
    {
      this.value = this.value >> 8 ^ CRC32.table[(int) (byte) this.value ^ (int) b];
    }

    public void Update(byte[] data, int offset, int size)
    {
      if (size == 0)
        return;
      uint[] numArray = CRC32.table;
      uint num1 = this.value;
      for (; (offset & 7) != 0 && size != 0; --size)
        num1 = num1 >> 8 ^ numArray[(int) (byte) num1 ^ (int) data[offset++]];
      if (size >= 8)
      {
        int num2 = size - 8 & -8;
        size -= num2;
        int num3 = num2 + offset;
        while (offset != num3)
        {
          uint num4 = num1 ^ (uint) ((int) data[offset] + ((int) data[offset + 1] << 8) + ((int) data[offset + 2] << 16) + ((int) data[offset + 3] << 24));
          uint num5 = (uint) ((int) data[offset + 4] + ((int) data[offset + 5] << 8) + ((int) data[offset + 6] << 16) + ((int) data[offset + 7] << 24));
          offset += 8;
          uint num6;
          uint num7;
          uint num8;
          uint num9;
          num1 = numArray[(int) (byte) num4 + 1792] ^ numArray[(int) (num6 = num4 >> 8) + 1536] ^ numArray[(int) (num7 = num6 >> 8) + 1280] ^ numArray[(IntPtr) ((num7 >> 8) + 1024U)] ^ numArray[(int) (byte) num5 + 768] ^ numArray[(int) (num8 = num5 >> 8) + 512] ^ numArray[(int) (num9 = num8 >> 8) + 256] ^ numArray[(IntPtr) (num9 >> 8)];
        }
      }
      while (size-- != 0)
        num1 = num1 >> 8 ^ numArray[(int) (byte) num1 ^ (int) data[offset++]];
      this.value = num1;
    }
  }
}
