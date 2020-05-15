using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.ObjectModel;

namespace Terraria.Leaderboards
{
	public class LeaderboardData
	{
		public class Row
		{
			public bool Available;

			public int Rank;

			public uint[] Statistics;

			public Gamer Gamer;

			public string Gamertag => Gamer.Gamertag;
		}

		private class Cache
		{
			public Row[] Entries;

			public int StartIndex;

			public int NumEntries;
		}

		private enum AsyncRequest
		{
			None,
			FullRead,
			NextPage,
			PreviousPage
		}

		private const int PAGE_SIZE = 50;

		public int NumEntries;

		private Cache Stale;

		private Cache Current;

		private Cache MergedCache;

		private LeaderboardReader Reader;

		private IAsyncResult Request;

		private AsyncRequest ReadState;

		private int DefaultBatchSize;

		public int BatchSize;

		public int BatchStart;

		public int Selected;

		public Column[] Columns;

		public string LeaderboardName;

		public bool Ready => Reader != null;

		private bool CanPageDown => Reader.CanPageDown;

		private bool CanPageUp => Reader.CanPageUp;

		private static void ProcessEntries(LeaderboardReader reader, Column[] columns, ref Cache cache)
		{
			ReadOnlyCollection<LeaderboardEntry> entries = reader.Entries;
			int num = entries.Count;
			int num2 = 0;
			int num3 = columns.Length;
			string[] array = new string[num3];
			for (int num4 = num3 - 1; num4 > -1; num4--)
			{
				array[num4] = columns[num4].ToString();
			}
			for (int i = 0; i < entries.Count; i++)
			{
				LeaderboardEntry leaderboardEntry = entries[i];
				if (leaderboardEntry.GetRank() == 0)
				{
					num--;
					continue;
				}
				Row row = cache.Entries[num2];
				row.Rank = leaderboardEntry.GetRank();
				row.Gamer = leaderboardEntry.Gamer;
				row.Statistics = new uint[num3];
				for (int num5 = num3 - 1; num5 > -1; num5--)
				{
					string key = array[num5];
					int num6 = (int)leaderboardEntry.Columns[key];
					uint num7 = 0u;
					num7 = (uint)num6;
					row.Statistics[num5] = num7;
				}
				row.Available = true;
				num2++;
			}
			cache.StartIndex = reader.PageStart;
			cache.NumEntries = num;
		}

		public LeaderboardData(int batchSize)
		{
			DefaultBatchSize = batchSize;
			BatchStart = 0;
			MergedCache = new Cache
			{
				Entries = new Row[0],
				StartIndex = 0
			};
		}

		public void LoadLeaderboard(Leaderboard board)
		{
			LeaderboardIdentity identity = LeaderboardInfo.GetIdentity(board);
			Request = LeaderboardReader.BeginRead(identity, 0, 50, null, null);
			Reader = null;
			ReadState = AsyncRequest.FullRead;
			NumEntries = 0;
			ResetCaches();
			Columns = LeaderboardInfo.GetColumns(board);
			LeaderboardName = LeaderboardInfo.GetName(board);
		}

		public void LoadLeaderboard(Leaderboard board, Gamer gamer)
		{
			LeaderboardIdentity identity = LeaderboardInfo.GetIdentity(board);
			Request = LeaderboardReader.BeginRead(identity, gamer, 50, null, gamer);
			Reader = null;
			ReadState = AsyncRequest.FullRead;
			NumEntries = 0;
			ResetCaches();
			Columns = LeaderboardInfo.GetColumns(board);
			LeaderboardName = LeaderboardInfo.GetName(board);
		}

		public void LoadLeaderboard(Leaderboard board, FriendCollection friends, Gamer gamer)
		{
			LeaderboardIdentity identity = LeaderboardInfo.GetIdentity(board);
			Request = LeaderboardReader.BeginRead(identity, friends, gamer, friends.Count + 1, null, gamer);
			Reader = null;
			ReadState = AsyncRequest.FullRead;
			NumEntries = 0;
			ResetCaches();
			Columns = LeaderboardInfo.GetColumns(board);
			LeaderboardName = LeaderboardInfo.GetName(board);
		}

		private void ResetCaches()
		{
			Row[] array = new Row[50];
			Row[] array2 = new Row[50];
			for (int num = 49; num >= 0; num--)
			{
				array[num] = new Row
				{
					Available = false
				};
				array2[num] = new Row
				{
					Available = false
				};
			}
			Current = new Cache
			{
				Entries = array,
				StartIndex = 0,
				NumEntries = 0
			};
			Stale = new Cache
			{
				Entries = array2,
				StartIndex = 0,
				NumEntries = 0
			};
			MergedCache = new Cache
			{
				Entries = array,
				StartIndex = 0,
				NumEntries = 0
			};
			BatchStart = 0;
		}

		public bool Update()
		{
			if (ReadState == AsyncRequest.None || !Request.IsCompleted)
			{
				return true;
			}
			if (ReadState == AsyncRequest.FullRead)
			{
				try
				{
					Reader = LeaderboardReader.EndRead(Request);
				}
				catch
				{
					return false;
				}
				BatchStart = Reader.PageStart;
				Selected = 0;
				if (Request.AsyncState != null)
				{
					Gamer gamer = (Gamer)Request.AsyncState;
					int num = BatchStart;
					foreach (LeaderboardEntry entry in Reader.Entries)
					{
						if (entry.Gamer.Gamertag == gamer.Gamertag)
						{
							Selected = num;
							BatchStart = num;
							break;
						}
						num++;
					}
				}
			}
			else if (ReadState == AsyncRequest.NextPage)
			{
				Reader.EndPageDown(Request);
			}
			else if (ReadState == AsyncRequest.PreviousPage)
			{
				Reader.EndPageUp(Request);
			}
			ProcessEntries(Reader, Columns, ref Current);
			if (Stale.StartIndex <= Current.StartIndex)
			{
				CreateMergedCache(Stale, Current);
			}
			else
			{
				CreateMergedCache(Current, Stale);
			}
			if (ReadState == AsyncRequest.FullRead)
			{
				BatchSize = Math.Min(Current.NumEntries, DefaultBatchSize);
				if (Current.NumEntries > 0 && (Reader.CanPageDown || Reader.CanPageUp))
				{
					NumEntries = Reader.TotalLeaderboardSize;
				}
				else
				{
					NumEntries = Current.NumEntries;
				}
				if (BatchStart > NumEntries - BatchSize)
				{
					BatchStart = NumEntries - BatchSize;
				}
			}
			ReadState = AsyncRequest.None;
			Request = null;
			return true;
		}

		public bool MoveDown()
		{
			Selected++;
			if (Selected < BatchStart + BatchSize)
			{
				return true;
			}
			BatchStart++;
			bool flag = Current.StartIndex + Current.NumEntries < BatchStart + BatchSize;
			if (flag && !CanPageDown && ReadState == AsyncRequest.None)
			{
				Selected--;
				BatchStart--;
				return false;
			}
			bool result = true;
			if (flag)
			{
				if (ReadState == AsyncRequest.None)
				{
					CacheNextPage();
				}
				else
				{
					BatchStart--;
					Selected--;
					result = false;
				}
			}
			return result;
		}

		public bool MoveUp()
		{
			Selected--;
			if (Selected >= BatchStart)
			{
				return true;
			}
			BatchStart--;
			bool flag = BatchStart < Current.StartIndex;
			if (flag && !CanPageUp && ReadState == AsyncRequest.None)
			{
				Selected++;
				BatchStart++;
				return false;
			}
			bool result = true;
			if (flag)
			{
				if (ReadState == AsyncRequest.None)
				{
					CachePreviousPage();
				}
				else
				{
					BatchStart++;
					Selected++;
					result = false;
				}
			}
			return result;
		}

		private void CacheNextPage()
		{
			int newStartIndex = Current.StartIndex + Current.NumEntries;
			FreeCache(newStartIndex);
			CreateMergedCache(Stale, Current);
			Request = Reader.BeginPageDown(null, null);
			ReadState = AsyncRequest.NextPage;
		}

		private void CachePreviousPage()
		{
			int num = Math.Min(Current.NumEntries, Current.StartIndex);
			int newStartIndex = Current.StartIndex - num;
			FreeCache(newStartIndex);
			CreateMergedCache(Current, Stale);
			Request = Reader.BeginPageUp(null, null);
			ReadState = AsyncRequest.PreviousPage;
		}

		private void FreeCache(int newStartIndex)
		{
			Cache stale = Stale;
			Stale = Current;
			Current = stale;
			if (Current.StartIndex != newStartIndex)
			{
				Current.StartIndex = newStartIndex;
				for (int i = 0; i < Current.NumEntries; i++)
				{
					Current.Entries[i].Available = false;
				}
			}
		}

		private void CreateMergedCache(Cache first, Cache second)
		{
			int num = second.StartIndex - first.StartIndex + second.NumEntries;
			Cache cache = new Cache();
			cache.Entries = new Row[num];
			cache.StartIndex = first.StartIndex;
			cache.NumEntries = num;
			Cache cache2 = cache;
			for (int num2 = first.NumEntries - 1; num2 >= 0; num2--)
			{
				cache2.Entries[num2] = first.Entries[num2];
			}
			int num3 = second.StartIndex - first.StartIndex;
			for (int num4 = second.NumEntries - 1; num4 >= 0; num4--)
			{
				Row row = cache2.Entries[num3 + num4];
				if (row == null || !row.Available)
				{
					cache2.Entries[num3 + num4] = second.Entries[num4];
				}
				row = cache2.Entries[num3 + num4];
			}
			MergedCache = cache2;
		}

		public Row[] GetRows()
		{
			int num = Math.Min(BatchSize, MergedCache.NumEntries);
			int num2 = BatchStart - MergedCache.StartIndex;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 + num > MergedCache.NumEntries)
			{
				num2 = MergedCache.NumEntries - num;
			}
			Row[] destination = new Row[num];
			CopyRows(ref MergedCache.Entries, num2, ref destination, 0, num);
			return destination;
		}

		private void CopyRows(ref Row[] source, int sourceIndex, ref Row[] destination, int destinationIndex, int count)
		{
			for (int num = count - 1; num >= 0; num--)
			{
				destination[destinationIndex + num] = source[sourceIndex + num];
			}
		}

		public Gamer GetSelectedGamer()
		{
			int num = Selected - MergedCache.StartIndex;
			if (num >= 0 && num < MergedCache.NumEntries)
			{
				return MergedCache.Entries[num].Gamer;
			}
			return null;
		}
	}
}
