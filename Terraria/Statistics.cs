using System;
using System.Collections;

namespace Terraria;

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

	public uint this[StatisticEntry stat] => Counters[(int)stat];

	public static StatisticEntry GetStatisticEntryFromNetID(short netID)
	{
		StatisticEntry result = StatisticEntry.Unknown;
		switch (netID)
		{
		case 1:
			result = StatisticEntry.BlueSlime;
			break;
		case -1:
			result = StatisticEntry.Slimeling;
			break;
		case -2:
			result = StatisticEntry.Slimer;
			break;
		case -3:
			result = StatisticEntry.GreenSlime;
			break;
		case -4:
			result = StatisticEntry.Pinky;
			break;
		case -5:
			result = StatisticEntry.BabySlime;
			break;
		case -6:
			result = StatisticEntry.BlackSlime;
			break;
		case -7:
			result = StatisticEntry.PurpleSlime;
			break;
		case -8:
			result = StatisticEntry.RedSlime;
			break;
		case -9:
			result = StatisticEntry.YellowSlime;
			break;
		case -10:
			result = StatisticEntry.JungleSlime;
			break;
		case -18:
			result = StatisticEntry.Slimeling;
			break;
		case 16:
			result = StatisticEntry.MotherSlime;
			break;
		case 59:
			result = StatisticEntry.LavaSlime;
			break;
		case 81:
			result = StatisticEntry.CorruptSlime;
			break;
		case 141:
			result = StatisticEntry.ToxicSludge;
			break;
		case 121:
			result = StatisticEntry.Slimer;
			break;
		case 150:
			result = StatisticEntry.ShadowSlime;
			break;
		case 138:
			result = StatisticEntry.IlluminantSlime;
			break;
		case 71:
			result = StatisticEntry.DungeonSlime;
			break;
		}
		return result;
	}

	public static StatisticEntry GetBossStatisticEntryFromNetID(short netID)
	{
		StatisticEntry result = StatisticEntry.Unknown;
		switch (netID)
		{
		case 50:
			result = StatisticEntry.KingSlime;
			break;
		case 4:
			result = StatisticEntry.EyeOfCthulhu;
			break;
		case 13:
		case 14:
		case 15:
			result = StatisticEntry.EaterOfWorlds;
			break;
		case 35:
			result = StatisticEntry.Skeletron;
			break;
		case 113:
			result = StatisticEntry.WallOfFlesh;
			break;
		case 125:
		case 126:
			result = StatisticEntry.TheTwins;
			break;
		case 134:
			result = StatisticEntry.TheDestroyer;
			break;
		case 127:
			result = StatisticEntry.SkeletronPrime;
			break;
		case 166:
			result = StatisticEntry.Ocram;
			break;
		}
		return result;
	}

	public static Statistics Create()
	{
		BitArray slimesKilled = new BitArray(19);
		BitArray bossesKilled = new BitArray(9);
		uint[] counters = new uint[50];
		return new Statistics(slimesKilled, bossesKilled, counters);
	}

	public Statistics(BitArray slimesKilled, BitArray bossesKilled, uint[] counters)
	{
		SlimesKilled = slimesKilled;
		BossesKilled = bossesKilled;
		Counters = counters;
		UpdateAllSlimesKilled();
		UpdateAllBossesKilled();
	}

	private void UpdateAllSlimesKilled()
	{
		AllSlimeTypesKilled = true;
		for (int i = 0; i < SlimesKilled.Count; i++)
		{
			AllSlimeTypesKilled &= SlimesKilled[i];
		}
	}

	private void UpdateAllBossesKilled()
	{
		AllBossesKilled = true;
		for (int i = 0; i < BossesKilled.Count; i++)
		{
			AllBossesKilled &= BossesKilled[i];
		}
	}

	public void incStat(StatisticEntry entry)
	{
		if (entry != StatisticEntry.Unknown)
		{
			if (entry < StatisticEntry.EyeOfCthulhu)
			{
				SlimesKilled.Set((int)entry, value: true);
				UpdateAllSlimesKilled();
			}
			if (entry < StatisticEntry.AirTravel && entry >= StatisticEntry.KingSlime)
			{
				int index = (int)(entry - 18);
				BossesKilled.Set(index, value: true);
				UpdateAllBossesKilled();
			}
			Counters[(int)entry]++;
		}
	}

	public void incWoodStat(uint count)
	{
		Counters[34] += count;
	}

	private uint CreateChecksum(uint[] array)
	{
		uint num = 0u;
		uint[] counters = Counters;
		foreach (uint num2 in counters)
		{
			num ^= num2;
		}
		return num;
	}

	public byte[] Serialize()
	{
		uint num = CreateChecksum(Counters);
		int num2 = 4;
		int num3 = Buffer.ByteLength(Counters);
		byte[] array = new byte[num3 + num2];
		Buffer.BlockCopy(Counters, 0, array, 0, num3);
		Buffer.BlockCopy(new uint[1] { num }, 0, array, num3, num2);
		return array;
	}

	public void Deserialize(byte[] stream)
	{
		if (stream.Length == 0)
		{
			Array.Clear(Counters, 0, Counters.Length);
			return;
		}
		int num = 4;
		int num2 = stream.Length - num;
		Buffer.BlockCopy(stream, 0, Counters, 0, num2);
		uint[] array = new uint[1];
		Buffer.BlockCopy(stream, num2, array, 0, num);
		uint num3 = CreateChecksum(Counters);
		if (num3 != array[0])
		{
			Array.Clear(Counters, 0, Counters.Length);
		}
		for (int i = 0; i < Counters.Length; i++)
		{
			bool flag = Counters[i] != 0;
			if (i < 19 && flag)
			{
				SlimesKilled.Set(i, value: true);
			}
			if (i < 27 && i >= 18 && flag)
			{
				int index = i - 18;
				BossesKilled.Set(index, value: true);
			}
		}
		UpdateAllSlimesKilled();
		UpdateAllBossesKilled();
	}

	public static int CalculateSerialisationSize()
	{
		return 204;
	}

	public void Init()
	{
		AllSlimeTypesKilled = false;
		AllBossesKilled = false;
		SlimesKilled.SetAll(value: false);
		BossesKilled.SetAll(value: false);
		for (int num = 49; num >= 0; num--)
		{
			Counters[num] = 0u;
		}
	}
}
