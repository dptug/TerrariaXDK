// Type: Terraria.Leaderboards.LeaderboardInfo
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Net;
using Terraria;

namespace Terraria.Leaderboards
{
  internal class LeaderboardInfo
  {
    private static LeaderboardInfo[] LEADERBOARDS_INFO = LeaderboardInfo.CreateAll();
    private LeaderboardIdentity Identity;
    private LeaderboardInfo.ColumnMapping[] Columns;
    private int NameID;

    static LeaderboardInfo()
    {
    }

    private LeaderboardInfo(LeaderboardIdentity identity, LeaderboardInfo.ColumnMapping[] columns, LeaderboardInfo.TitleTextID nameID)
    {
      this.Identity = identity;
      this.Columns = columns;
      this.NameID = (int) nameID;
    }

    private static LeaderboardInfo.ColumnMapping Map(StatisticEntry entry, Column column)
    {
      string name = ((object) column).ToString();
      return new LeaderboardInfo.ColumnMapping(entry, column, name);
    }

    private static LeaderboardIdentity CreateId(string key)
    {
      return new LeaderboardIdentity()
      {
        Key = key,
        GameMode = 0
      };
    }

    public static LeaderboardInfo[] CreateAll()
    {
      LeaderboardInfo[] leaderboardInfoArray = new LeaderboardInfo[5];
      LeaderboardInfo.ColumnMapping[] columns1 = new LeaderboardInfo.ColumnMapping[4]
      {
        LeaderboardInfo.Map(StatisticEntry.AirTravel, Column.AIR_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.GroundTravel, Column.GROUND_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.WaterTravel, Column.WATER_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.LavaTravel, Column.LAVA_COLUMN)
      };
      leaderboardInfoArray[0] = new LeaderboardInfo(LeaderboardInfo.CreateId("Distance"), columns1, LeaderboardInfo.TitleTextID.DISTANCE);
      LeaderboardInfo.ColumnMapping[] columns2 = new LeaderboardInfo.ColumnMapping[4]
      {
        LeaderboardInfo.Map(StatisticEntry.Ore, Column.ORE_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.Gems, Column.GEMS_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.Soils, Column.SOILS_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.Wood, Column.WOOD_COLUMN)
      };
      leaderboardInfoArray[1] = new LeaderboardInfo(LeaderboardInfo.CreateId("Mining"), columns2, LeaderboardInfo.TitleTextID.MINING_GATHERING);
      LeaderboardInfo.ColumnMapping[] columns3 = new LeaderboardInfo.ColumnMapping[6]
      {
        LeaderboardInfo.Map(StatisticEntry.FurnitureCrafted, Column.FURNITURE_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.ToolsCrafted, Column.TOOLS_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.WeaponsCrafted, Column.WEAPONS_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.ArmorCrafted, Column.ARMOR_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.ConsumablesCrafted, Column.CONSUMABLES_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.MiscCrafted, Column.MISC_COLUMN)
      };
      leaderboardInfoArray[2] = new LeaderboardInfo(LeaderboardInfo.CreateId("Crafting"), columns3, LeaderboardInfo.TitleTextID.CRAFTING);
      LeaderboardInfo.ColumnMapping[] columns4 = new LeaderboardInfo.ColumnMapping[5]
      {
        LeaderboardInfo.Map(StatisticEntry.KingSlime, Column.KING_SLIME_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.EyeOfCthulhu, Column.CTHULHU_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.EaterOfWorlds, Column.EATER_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.Skeletron, Column.SKELETRON_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.WallOfFlesh, Column.WALL_COLUMN)
      };
      leaderboardInfoArray[3] = new LeaderboardInfo(LeaderboardInfo.CreateId("Normal bosses"), columns4, LeaderboardInfo.TitleTextID.NORMAL_BOSSES);
      LeaderboardInfo.ColumnMapping[] columns5 = new LeaderboardInfo.ColumnMapping[4]
      {
        LeaderboardInfo.Map(StatisticEntry.TheTwins, Column.TWINS_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.TheDestroyer, Column.DESTROYER_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.SkeletronPrime, Column.SKELETRON_PRIME_COLUMN),
        LeaderboardInfo.Map(StatisticEntry.Ocram, Column.OCRAM_COLUMN)
      };
      leaderboardInfoArray[4] = new LeaderboardInfo(LeaderboardInfo.CreateId("Hard bosses"), columns5, LeaderboardInfo.TitleTextID.HARD_BOSSES);
      return leaderboardInfoArray;
    }

    public static LeaderboardIdentity GetIdentity(Leaderboard board)
    {
      return LeaderboardInfo.LEADERBOARDS_INFO[(int) board].Identity;
    }

    public static Column[] GetColumns(Leaderboard board)
    {
      LeaderboardInfo leaderboardInfo = LeaderboardInfo.LEADERBOARDS_INFO[(int) board];
      Column[] columnArray = new Column[leaderboardInfo.Columns.Length];
      for (int index = leaderboardInfo.Columns.Length - 1; index > -1; --index)
        columnArray[index] = leaderboardInfo.Columns[index].Column;
      return columnArray;
    }

    public static string GetName(Leaderboard board)
    {
      LeaderboardInfo leaderboardInfo = LeaderboardInfo.LEADERBOARDS_INFO[(int) board];
      return Lang.menu[leaderboardInfo.NameID];
    }

    public static void SubmitStatistics(Statistics stats, NetworkGamer gamer)
    {
      if (Netplay.session.SessionState != NetworkSessionState.Playing)
        return;
      LeaderboardWriter leaderboardWriter = gamer.LeaderboardWriter;
      if (leaderboardWriter == null)
        return;
      foreach (LeaderboardInfo leaderboardInfo in LeaderboardInfo.LEADERBOARDS_INFO)
        leaderboardInfo.Submit(leaderboardWriter, stats);
    }

    public static void SubmitStatisticsToLeaderboard(Leaderboard board, Statistics stats, Gamer gamer)
    {
      LeaderboardWriter leaderboardWriter = gamer.LeaderboardWriter;
      if (leaderboardWriter == null)
        return;
      LeaderboardInfo.LEADERBOARDS_INFO[(int) board].Submit(leaderboardWriter, stats);
    }

    private void Submit(LeaderboardWriter writer, Statistics stats)
    {
      long num1 = 0L;
      LeaderboardEntry leaderboard = writer.GetLeaderboard(this.Identity);
      foreach (LeaderboardInfo.ColumnMapping columnMapping in this.Columns)
      {
        uint num2 = stats[columnMapping.Statistic];
        int num3 = (int) num2;
        leaderboard.Columns[columnMapping.ColumnName] = (object) num3;
        num1 += (long) num2;
      }
      leaderboard.Rating = num1;
    }

    private enum TitleTextID
    {
      DISTANCE = 58,
      MINING_GATHERING = 59,
      CRAFTING = 60,
      USED = 61,
      NORMAL_BOSSES = 62,
      HARD_BOSSES = 63,
      DEATHS = 64,
    }

    private class ColumnMapping
    {
      public StatisticEntry Statistic;
      public Column Column;
      public string ColumnName;

      public ColumnMapping(StatisticEntry entry, Column column, string name)
      {
        this.Statistic = entry;
        this.Column = column;
        this.ColumnName = name;
      }
    }
  }
}
