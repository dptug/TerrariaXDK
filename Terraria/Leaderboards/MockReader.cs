// Type: Terraria.Leaderboards.MockReader
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using System;
using Terraria;

namespace Terraria.Leaderboards
{
  public class MockReader
  {
    private const int SEED = 1234567;
    private LeaderboardData.Row[] Database;
    private int PageSize;
    public bool Loaded;
    public int PageStart;

    public bool CanPageDown
    {
      get
      {
        return this.PageStart + this.PageSize < this.TotalLeaderboardSize;
      }
    }

    public bool CanPageUp
    {
      get
      {
        return this.PageStart > 0;
      }
    }

    public int TotalLeaderboardSize
    {
      get
      {
        if (!this.Loaded)
          return 0;
        else
          return this.Database.Length;
      }
    }

    public LeaderboardData.Row[] Entries
    {
      get
      {
        LeaderboardData.Row[] rowArray = new LeaderboardData.Row[this.PageSize];
        for (int index = this.PageSize - 1; index >= 0; --index)
          rowArray[index] = this.Database[this.PageStart + index];
        return rowArray;
      }
    }

    private MockReader(LeaderboardData.Row[] database, int pageStart, int pageSize)
    {
      this.Database = database;
      this.PageSize = pageSize;
      this.PageStart = pageStart;
    }

    public static MockReader Create(int numEntries, int pageSize, int numColumns)
    {
      FastRandom fastRandom = new FastRandom(1234567U);
      LeaderboardData.Row[] database = new LeaderboardData.Row[numEntries];
      for (int index1 = numEntries - 1; index1 >= 0; --index1)
      {
        database[index1] = new LeaderboardData.Row()
        {
          Available = true,
          Rank = index1 + 1,
          Statistics = new uint[numColumns]
        };
        for (int index2 = 0; index2 < numColumns; ++index2)
          database[index1].Statistics[index2] = (uint) fastRandom.Next(109999998);
      }
      return new MockReader(database, 0, Math.Min(numEntries, pageSize));
    }

    public void PageDown()
    {
      this.PageStart = Math.Min(this.PageStart + this.PageSize, this.TotalLeaderboardSize - this.PageSize);
    }

    public void PageUp()
    {
      this.PageStart = Math.Max(this.PageStart - this.PageSize, 0);
    }
  }
}
