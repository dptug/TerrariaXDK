using System;

namespace Terraria.Leaderboards
{
	public class MockReader
	{
		private const int SEED = 1234567;

		private LeaderboardData.Row[] Database;

		private int PageSize;

		public bool Loaded;

		public int PageStart;

		public bool CanPageDown => PageStart + PageSize < TotalLeaderboardSize;

		public bool CanPageUp => PageStart > 0;

		public int TotalLeaderboardSize
		{
			get
			{
				if (!Loaded)
				{
					return 0;
				}
				return Database.Length;
			}
		}

		public LeaderboardData.Row[] Entries
		{
			get
			{
				LeaderboardData.Row[] array = new LeaderboardData.Row[PageSize];
				for (int num = PageSize - 1; num >= 0; num--)
				{
					array[num] = Database[PageStart + num];
				}
				return array;
			}
		}

		public static MockReader Create(int numEntries, int pageSize, int numColumns)
		{
			FastRandom fastRandom = new FastRandom(1234567u);
			LeaderboardData.Row[] array = new LeaderboardData.Row[numEntries];
			for (int num = numEntries - 1; num >= 0; num--)
			{
				array[num] = new LeaderboardData.Row
				{
					Available = true,
					Rank = num + 1,
					Statistics = new uint[numColumns]
				};
				for (int i = 0; i < numColumns; i++)
				{
					array[num].Statistics[i] = (uint)fastRandom.Next(109999998);
				}
			}
			return new MockReader(array, 0, Math.Min(numEntries, pageSize));
		}

		private MockReader(LeaderboardData.Row[] database, int pageStart, int pageSize)
		{
			Database = database;
			PageSize = pageSize;
			PageStart = pageStart;
		}

		public void PageDown()
		{
			PageStart = Math.Min(PageStart + PageSize, TotalLeaderboardSize - PageSize);
		}

		public void PageUp()
		{
			PageStart = Math.Max(PageStart - PageSize, 0);
		}
	}
}
