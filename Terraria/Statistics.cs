// Type: Terraria.Statistics
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using System;
using System.Collections;

namespace Terraria
{
  public class Statistics
  {
    private const int FirstNonSlimeIndex = 19;
    private const int FirstBossIndex = 18;
    private const int LastBossIndex = 26;
    public bool AllSlimeTypesKilled;
    public bool AllBossesKilled;
    private BitArray SlimesKilled;
    private BitArray BossesKilled;
    private uint[] Counters;

    public uint this[StatisticEntry stat]
    {
      get
      {
        return this.Counters[(int) stat];
      }
    }

    public Statistics(BitArray slimesKilled, BitArray bossesKilled, uint[] counters)
    {
      this.SlimesKilled = slimesKilled;
      this.BossesKilled = bossesKilled;
      this.Counters = counters;
      this.UpdateAllSlimesKilled();
      this.UpdateAllBossesKilled();
    }

    public static StatisticEntry GetStatisticEntryFromNetID(short netID)
    {
      StatisticEntry statisticEntry = StatisticEntry.Unknown;
      switch (netID)
      {
        case (short) 138:
          statisticEntry = StatisticEntry.IlluminantSlime;
          break;
        case (short) 141:
          statisticEntry = StatisticEntry.ToxicSludge;
          break;
        case (short) 150:
          statisticEntry = StatisticEntry.ShadowSlime;
          break;
        case (short) 81:
          statisticEntry = StatisticEntry.CorruptSlime;
          break;
        case (short) 121:
          statisticEntry = StatisticEntry.Slimer;
          break;
        case (short) 59:
          statisticEntry = StatisticEntry.LavaSlime;
          break;
        case (short) 71:
          statisticEntry = StatisticEntry.DungeonSlime;
          break;
        case (short) -18:
          statisticEntry = StatisticEntry.Slimeling;
          break;
        case (short) -10:
          statisticEntry = StatisticEntry.JungleSlime;
          break;
        case (short) -9:
          statisticEntry = StatisticEntry.YellowSlime;
          break;
        case (short) -8:
          statisticEntry = StatisticEntry.RedSlime;
          break;
        case (short) -7:
          statisticEntry = StatisticEntry.PurpleSlime;
          break;
        case (short) -6:
          statisticEntry = StatisticEntry.BlackSlime;
          break;
        case (short) -5:
          statisticEntry = StatisticEntry.BabySlime;
          break;
        case (short) -4:
          statisticEntry = StatisticEntry.Pinky;
          break;
        case (short) -3:
          statisticEntry = StatisticEntry.GreenSlime;
          break;
        case (short) -2:
          statisticEntry = StatisticEntry.Slimer;
          break;
        case (short) -1:
          statisticEntry = StatisticEntry.Slimeling;
          break;
        case (short) 1:
          statisticEntry = StatisticEntry.BlueSlime;
          break;
        case (short) 16:
          statisticEntry = StatisticEntry.MotherSlime;
          break;
      }
      return statisticEntry;
    }

    public static StatisticEntry GetBossStatisticEntryFromNetID(short netID)
    {
      StatisticEntry statisticEntry = StatisticEntry.Unknown;
      switch (netID)
      {
        case (short) 134:
          statisticEntry = StatisticEntry.TheDestroyer;
          break;
        case (short) 166:
          statisticEntry = StatisticEntry.Ocram;
          break;
        case (short) 113:
          statisticEntry = StatisticEntry.WallOfFlesh;
          break;
        case (short) 125:
        case (short) 126:
          statisticEntry = StatisticEntry.TheTwins;
          break;
        case (short) sbyte.MaxValue:
          statisticEntry = StatisticEntry.SkeletronPrime;
          break;
        case (short) 35:
          statisticEntry = StatisticEntry.Skeletron;
          break;
        case (short) 50:
          statisticEntry = StatisticEntry.KingSlime;
          break;
        case (short) 4:
          statisticEntry = StatisticEntry.EyeOfCthulhu;
          break;
        case (short) 13:
        case (short) 14:
        case (short) 15:
          statisticEntry = StatisticEntry.EaterOfWorlds;
          break;
      }
      return statisticEntry;
    }

    public static Statistics Create()
    {
      return new Statistics(new BitArray(19), new BitArray(9), new uint[50]);
    }

    private void UpdateAllSlimesKilled()
    {
      this.AllSlimeTypesKilled = true;
      for (int index = 0; index < this.SlimesKilled.Count; ++index)
      {
        Statistics statistics = this;
        int num = statistics.AllSlimeTypesKilled & this.SlimesKilled[index] ? 1 : 0;
        statistics.AllSlimeTypesKilled = num != 0;
      }
    }

    private void UpdateAllBossesKilled()
    {
      this.AllBossesKilled = true;
      for (int index = 0; index < this.BossesKilled.Count; ++index)
      {
        Statistics statistics = this;
        int num = statistics.AllBossesKilled & this.BossesKilled[index] ? 1 : 0;
        statistics.AllBossesKilled = num != 0;
      }
    }

    public void incStat(StatisticEntry entry)
    {
      if (entry == StatisticEntry.Unknown)
        return;
      int index = (int) entry;
      if (index < 19)
      {
        this.SlimesKilled.Set(index, true);
        this.UpdateAllSlimesKilled();
      }
      if (index < 27 && index >= 18)
      {
        this.BossesKilled.Set(index - 18, true);
        this.UpdateAllBossesKilled();
      }
      ++this.Counters[index];
    }

    public void incWoodStat(uint count)
    {
      this.Counters[34] += count;
    }

    private uint CreateChecksum(uint[] array)
    {
      uint num1 = 0U;
      foreach (uint num2 in this.Counters)
        num1 ^= num2;
      return num1;
    }

    public byte[] Serialize()
    {
      uint checksum = this.CreateChecksum(this.Counters);
      int count = 4;
      int num = Buffer.ByteLength((Array) this.Counters);
      byte[] numArray = new byte[num + count];
      Buffer.BlockCopy((Array) this.Counters, 0, (Array) numArray, 0, num);
      Buffer.BlockCopy((Array) new uint[1]
      {
        checksum
      }, 0, (Array) numArray, num, count);
      return numArray;
    }

    public void Deserialize(byte[] stream)
    {
      if (stream.Length == 0)
      {
        Array.Clear((Array) this.Counters, 0, this.Counters.Length);
      }
      else
      {
        int count = 4;
        int num = stream.Length - count;
        Buffer.BlockCopy((Array) stream, 0, (Array) this.Counters, 0, num);
        uint[] numArray = new uint[1];
        Buffer.BlockCopy((Array) stream, num, (Array) numArray, 0, count);
        if ((int) this.CreateChecksum(this.Counters) != (int) numArray[0])
          Array.Clear((Array) this.Counters, 0, this.Counters.Length);
        for (int index = 0; index < this.Counters.Length; ++index)
        {
          bool flag = this.Counters[index] > 0U;
          if (index < 19 && flag)
            this.SlimesKilled.Set(index, true);
          if (index < 27 && index >= 18 && flag)
            this.BossesKilled.Set(index - 18, true);
        }
        this.UpdateAllSlimesKilled();
        this.UpdateAllBossesKilled();
      }
    }

    public static int CalculateSerialisationSize()
    {
      return 204;
    }

    public void Init()
    {
      this.AllSlimeTypesKilled = false;
      this.AllBossesKilled = false;
      this.SlimesKilled.SetAll(false);
      this.BossesKilled.SetAll(false);
      for (int index = 49; index >= 0; --index)
        this.Counters[index] = 0U;
    }
  }
}
