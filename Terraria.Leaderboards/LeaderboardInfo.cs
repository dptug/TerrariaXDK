using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Net;

namespace Terraria.Leaderboards;

internal class LeaderboardInfo
{
	private enum TitleTextID
	{
		DISTANCE = 58,
		MINING_GATHERING,
		CRAFTING,
		USED,
		NORMAL_BOSSES,
		HARD_BOSSES,
		DEATHS
	}

	private class ColumnMapping
	{
		public StatisticEntry Statistic;

		public Column Column;

		public string ColumnName;

		public ColumnMapping(StatisticEntry entry, Column column, string name)
		{
			Statistic = entry;
			Column = column;
			ColumnName = name;
		}
	}

	private LeaderboardIdentity Identity;

	private ColumnMapping[] Columns;

	private int NameID;

	private static LeaderboardInfo[] LEADERBOARDS_INFO = CreateAll();

	private static ColumnMapping Map(StatisticEntry entry, Column column)
	{
		string name = column.ToString();
		return new ColumnMapping(entry, column, name);
	}

	private static LeaderboardIdentity CreateId(string key)
	{
		LeaderboardIdentity result = default(LeaderboardIdentity);
		result.Key = key;
		result.GameMode = 0;
		return result;
	}

	private LeaderboardInfo(LeaderboardIdentity identity, ColumnMapping[] columns, TitleTextID nameID)
	{
		Identity = identity;
		Columns = columns;
		NameID = (int)nameID;
	}

	public static LeaderboardInfo[] CreateAll()
	{
		LeaderboardInfo[] array = new LeaderboardInfo[5];
		ColumnMapping[] array2 = null;
		array2 = new ColumnMapping[4]
		{
			Map(StatisticEntry.AirTravel, Column.AIR_COLUMN),
			Map(StatisticEntry.GroundTravel, Column.GROUND_COLUMN),
			Map(StatisticEntry.WaterTravel, Column.WATER_COLUMN),
			Map(StatisticEntry.LavaTravel, Column.LAVA_COLUMN)
		};
		array[0] = new LeaderboardInfo(CreateId("Distance"), array2, TitleTextID.DISTANCE);
		array2 = new ColumnMapping[4]
		{
			Map(StatisticEntry.Ore, Column.ORE_COLUMN),
			Map(StatisticEntry.Gems, Column.GEMS_COLUMN),
			Map(StatisticEntry.Soils, Column.SOILS_COLUMN),
			Map(StatisticEntry.Wood, Column.WOOD_COLUMN)
		};
		array[1] = new LeaderboardInfo(CreateId("Mining"), array2, TitleTextID.MINING_GATHERING);
		array2 = new ColumnMapping[6]
		{
			Map(StatisticEntry.FurnitureCrafted, Column.FURNITURE_COLUMN),
			Map(StatisticEntry.ToolsCrafted, Column.TOOLS_COLUMN),
			Map(StatisticEntry.WeaponsCrafted, Column.WEAPONS_COLUMN),
			Map(StatisticEntry.ArmorCrafted, Column.ARMOR_COLUMN),
			Map(StatisticEntry.ConsumablesCrafted, Column.CONSUMABLES_COLUMN),
			Map(StatisticEntry.MiscCrafted, Column.MISC_COLUMN)
		};
		array[2] = new LeaderboardInfo(CreateId("Crafting"), array2, TitleTextID.CRAFTING);
		array2 = new ColumnMapping[5]
		{
			Map(StatisticEntry.KingSlime, Column.KING_SLIME_COLUMN),
			Map(StatisticEntry.EyeOfCthulhu, Column.CTHULHU_COLUMN),
			Map(StatisticEntry.EaterOfWorlds, Column.EATER_COLUMN),
			Map(StatisticEntry.Skeletron, Column.SKELETRON_COLUMN),
			Map(StatisticEntry.WallOfFlesh, Column.WALL_COLUMN)
		};
		array[3] = new LeaderboardInfo(CreateId("Normal bosses"), array2, TitleTextID.NORMAL_BOSSES);
		array2 = new ColumnMapping[4]
		{
			Map(StatisticEntry.TheTwins, Column.TWINS_COLUMN),
			Map(StatisticEntry.TheDestroyer, Column.DESTROYER_COLUMN),
			Map(StatisticEntry.SkeletronPrime, Column.SKELETRON_PRIME_COLUMN),
			Map(StatisticEntry.Ocram, Column.OCRAM_COLUMN)
		};
		array[4] = new LeaderboardInfo(CreateId("Hard bosses"), array2, TitleTextID.HARD_BOSSES);
		return array;
	}

	public static LeaderboardIdentity GetIdentity(Leaderboard board)
	{
		return LEADERBOARDS_INFO[(int)board].Identity;
	}

	public static Column[] GetColumns(Leaderboard board)
	{
		LeaderboardInfo leaderboardInfo = LEADERBOARDS_INFO[(int)board];
		Column[] array = new Column[leaderboardInfo.Columns.Length];
		for (int num = leaderboardInfo.Columns.Length - 1; num > -1; num--)
		{
			array[num] = leaderboardInfo.Columns[num].Column;
		}
		return array;
	}

	public static string GetName(Leaderboard board)
	{
		LeaderboardInfo leaderboardInfo = LEADERBOARDS_INFO[(int)board];
		return Lang.menu[leaderboardInfo.NameID];
	}

	public static void SubmitStatistics(Statistics stats, NetworkGamer gamer)
	{
		if (Netplay.session.SessionState != NetworkSessionState.Playing)
		{
			return;
		}
		LeaderboardWriter leaderboardWriter = gamer.LeaderboardWriter;
		if (leaderboardWriter != null)
		{
			LeaderboardInfo[] lEADERBOARDS_INFO = LEADERBOARDS_INFO;
			foreach (LeaderboardInfo leaderboardInfo in lEADERBOARDS_INFO)
			{
				leaderboardInfo.Submit(leaderboardWriter, stats);
			}
		}
	}

	public static void SubmitStatisticsToLeaderboard(Leaderboard board, Statistics stats, Gamer gamer)
	{
		LeaderboardWriter leaderboardWriter = gamer.LeaderboardWriter;
		if (leaderboardWriter != null)
		{
			LeaderboardInfo leaderboardInfo = LEADERBOARDS_INFO[(int)board];
			leaderboardInfo.Submit(leaderboardWriter, stats);
		}
	}

	private void Submit(LeaderboardWriter writer, Statistics stats)
	{
		long num = 0L;
		LeaderboardEntry leaderboard = writer.GetLeaderboard(Identity);
		ColumnMapping[] columns = Columns;
		foreach (ColumnMapping columnMapping in columns)
		{
			uint num2 = stats[columnMapping.Statistic];
			int num3 = 0;
			num3 = (int)num2;
			leaderboard.Columns[columnMapping.ColumnName] = num3;
			num += num2;
		}
		leaderboard.Rating = num;
	}
}
