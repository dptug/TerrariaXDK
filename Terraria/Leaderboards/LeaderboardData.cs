// Type: Terraria.Leaderboards.LeaderboardData
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Terraria.Leaderboards
{
  public class LeaderboardData
  {
    private const int PAGE_SIZE = 50;
    public int NumEntries;
    private LeaderboardData.Cache Stale;
    private LeaderboardData.Cache Current;
    private LeaderboardData.Cache MergedCache;
    private LeaderboardReader Reader;
    private IAsyncResult Request;
    private LeaderboardData.AsyncRequest ReadState;
    private int DefaultBatchSize;
    public int BatchSize;
    public int BatchStart;
    public int Selected;
    public Column[] Columns;
    public string LeaderboardName;

    public bool Ready
    {
      get
      {
        return this.Reader != null;
      }
    }

    private bool CanPageDown
    {
      get
      {
        return this.Reader.CanPageDown;
      }
    }

    private bool CanPageUp
    {
      get
      {
        return this.Reader.CanPageUp;
      }
    }

    public LeaderboardData(int batchSize)
    {
      this.DefaultBatchSize = batchSize;
      this.BatchStart = 0;
      this.MergedCache = new LeaderboardData.Cache()
      {
        Entries = new LeaderboardData.Row[0],
        StartIndex = 0
      };
    }

    private static void ProcessEntries(LeaderboardReader reader, Column[] columns, ref LeaderboardData.Cache cache)
    {
      ReadOnlyCollection<LeaderboardEntry> entries = reader.get_Entries();
      int count = entries.Count;
      int index1 = 0;
      int length = columns.Length;
      string[] strArray = new string[length];
      for (int index2 = length - 1; index2 > -1; --index2)
        strArray[index2] = ((object) columns[index2]).ToString();
      for (int index2 = 0; index2 < entries.Count; ++index2)
      {
        LeaderboardEntry leaderboardEntry = entries[index2];
        if (LeaderboardEntryExtensions.GetRank(leaderboardEntry) == 0)
        {
          --count;
        }
        else
        {
          LeaderboardData.Row row = cache.Entries[index1];
          row.Rank = LeaderboardEntryExtensions.GetRank(leaderboardEntry);
          row.Gamer = leaderboardEntry.Gamer;
          row.Statistics = new uint[length];
          for (int index3 = length - 1; index3 > -1; --index3)
          {
            string index4 = strArray[index3];
            uint num = (uint) (int) leaderboardEntry.Columns[index4];
            row.Statistics[index3] = num;
          }
          row.Available = true;
          ++index1;
        }
      }
      cache.StartIndex = reader.PageStart;
      cache.NumEntries = count;
    }

    public void LoadLeaderboard(Leaderboard board)
    {
      this.Request = LeaderboardReader.BeginRead(LeaderboardInfo.GetIdentity(board), 0, 50, (AsyncCallback) null, (object) null);
      this.Reader = (LeaderboardReader) null;
      this.ReadState = LeaderboardData.AsyncRequest.FullRead;
      this.NumEntries = 0;
      this.ResetCaches();
      this.Columns = LeaderboardInfo.GetColumns(board);
      this.LeaderboardName = LeaderboardInfo.GetName(board);
    }

    public void LoadLeaderboard(Leaderboard board, Gamer gamer)
    {
      this.Request = LeaderboardReader.BeginRead(LeaderboardInfo.GetIdentity(board), gamer, 50, (AsyncCallback) null, (object) gamer);
      this.Reader = (LeaderboardReader) null;
      this.ReadState = LeaderboardData.AsyncRequest.FullRead;
      this.NumEntries = 0;
      this.ResetCaches();
      this.Columns = LeaderboardInfo.GetColumns(board);
      this.LeaderboardName = LeaderboardInfo.GetName(board);
    }

    public void LoadLeaderboard(Leaderboard board, FriendCollection friends, Gamer gamer)
    {
      this.Request = LeaderboardReader.BeginRead(LeaderboardInfo.GetIdentity(board), (IEnumerable<Gamer>) friends, gamer, ((ReadOnlyCollection<FriendGamer>) friends).Count + 1, (AsyncCallback) null, (object) gamer);
      this.Reader = (LeaderboardReader) null;
      this.ReadState = LeaderboardData.AsyncRequest.FullRead;
      this.NumEntries = 0;
      this.ResetCaches();
      this.Columns = LeaderboardInfo.GetColumns(board);
      this.LeaderboardName = LeaderboardInfo.GetName(board);
    }

    private void ResetCaches()
    {
      LeaderboardData.Row[] rowArray1 = new LeaderboardData.Row[50];
      LeaderboardData.Row[] rowArray2 = new LeaderboardData.Row[50];
      for (int index = 49; index >= 0; --index)
      {
        rowArray1[index] = new LeaderboardData.Row()
        {
          Available = false
        };
        rowArray2[index] = new LeaderboardData.Row()
        {
          Available = false
        };
      }
      this.Current = new LeaderboardData.Cache()
      {
        Entries = rowArray1,
        StartIndex = 0,
        NumEntries = 0
      };
      this.Stale = new LeaderboardData.Cache()
      {
        Entries = rowArray2,
        StartIndex = 0,
        NumEntries = 0
      };
      this.MergedCache = new LeaderboardData.Cache()
      {
        Entries = rowArray1,
        StartIndex = 0,
        NumEntries = 0
      };
      this.BatchStart = 0;
    }

    public bool Update()
    {
      if (this.ReadState == LeaderboardData.AsyncRequest.None || !this.Request.IsCompleted)
        return true;
      if (this.ReadState == LeaderboardData.AsyncRequest.FullRead)
      {
        try
        {
          this.Reader = LeaderboardReader.EndRead(this.Request);
        }
        catch
        {
          return false;
        }
        this.BatchStart = this.Reader.PageStart;
        this.Selected = 0;
        if (this.Request.AsyncState != null)
        {
          Gamer gamer = (Gamer) this.Request.AsyncState;
          int num = this.BatchStart;
          foreach (LeaderboardEntry leaderboardEntry in this.Reader.get_Entries())
          {
            if (leaderboardEntry.Gamer.Gamertag == gamer.Gamertag)
            {
              this.Selected = num;
              this.BatchStart = num;
              break;
            }
            else
              ++num;
          }
        }
      }
      else if (this.ReadState == LeaderboardData.AsyncRequest.NextPage)
        this.Reader.EndPageDown(this.Request);
      else if (this.ReadState == LeaderboardData.AsyncRequest.PreviousPage)
        this.Reader.EndPageUp(this.Request);
      LeaderboardData.ProcessEntries(this.Reader, this.Columns, ref this.Current);
      if (this.Stale.StartIndex <= this.Current.StartIndex)
        this.CreateMergedCache(this.Stale, this.Current);
      else
        this.CreateMergedCache(this.Current, this.Stale);
      if (this.ReadState == LeaderboardData.AsyncRequest.FullRead)
      {
        this.BatchSize = Math.Min(this.Current.NumEntries, this.DefaultBatchSize);
        this.NumEntries = this.Current.NumEntries <= 0 || !this.Reader.CanPageDown && !this.Reader.CanPageUp ? this.Current.NumEntries : this.Reader.TotalLeaderboardSize;
        if (this.BatchStart > this.NumEntries - this.BatchSize)
          this.BatchStart = this.NumEntries - this.BatchSize;
      }
      this.ReadState = LeaderboardData.AsyncRequest.None;
      this.Request = (IAsyncResult) null;
      return true;
    }

    public bool MoveDown()
    {
      ++this.Selected;
      if (this.Selected < this.BatchStart + this.BatchSize)
        return true;
      ++this.BatchStart;
      bool flag1 = this.Current.StartIndex + this.Current.NumEntries < this.BatchStart + this.BatchSize;
      if (flag1 && !this.CanPageDown && this.ReadState == LeaderboardData.AsyncRequest.None)
      {
        --this.Selected;
        --this.BatchStart;
        return false;
      }
      else
      {
        bool flag2 = true;
        if (flag1)
        {
          if (this.ReadState == LeaderboardData.AsyncRequest.None)
          {
            this.CacheNextPage();
          }
          else
          {
            --this.BatchStart;
            --this.Selected;
            flag2 = false;
          }
        }
        return flag2;
      }
    }

    public bool MoveUp()
    {
      --this.Selected;
      if (this.Selected >= this.BatchStart)
        return true;
      --this.BatchStart;
      bool flag1 = this.BatchStart < this.Current.StartIndex;
      if (flag1 && !this.CanPageUp && this.ReadState == LeaderboardData.AsyncRequest.None)
      {
        ++this.Selected;
        ++this.BatchStart;
        return false;
      }
      else
      {
        bool flag2 = true;
        if (flag1)
        {
          if (this.ReadState == LeaderboardData.AsyncRequest.None)
          {
            this.CachePreviousPage();
          }
          else
          {
            ++this.BatchStart;
            ++this.Selected;
            flag2 = false;
          }
        }
        return flag2;
      }
    }

    private void CacheNextPage()
    {
      this.FreeCache(this.Current.StartIndex + this.Current.NumEntries);
      this.CreateMergedCache(this.Stale, this.Current);
      this.Request = this.Reader.BeginPageDown((AsyncCallback) null, (object) null);
      this.ReadState = LeaderboardData.AsyncRequest.NextPage;
    }

    private void CachePreviousPage()
    {
      this.FreeCache(this.Current.StartIndex - Math.Min(this.Current.NumEntries, this.Current.StartIndex));
      this.CreateMergedCache(this.Current, this.Stale);
      this.Request = this.Reader.BeginPageUp((AsyncCallback) null, (object) null);
      this.ReadState = LeaderboardData.AsyncRequest.PreviousPage;
    }

    private void FreeCache(int newStartIndex)
    {
      LeaderboardData.Cache cache = this.Stale;
      this.Stale = this.Current;
      this.Current = cache;
      if (this.Current.StartIndex == newStartIndex)
        return;
      this.Current.StartIndex = newStartIndex;
      for (int index = 0; index < this.Current.NumEntries; ++index)
        this.Current.Entries[index].Available = false;
    }

    private void CreateMergedCache(LeaderboardData.Cache first, LeaderboardData.Cache second)
    {
      int length = second.StartIndex - first.StartIndex + second.NumEntries;
      LeaderboardData.Cache cache = new LeaderboardData.Cache()
      {
        Entries = new LeaderboardData.Row[length],
        StartIndex = first.StartIndex,
        NumEntries = length
      };
      for (int index = first.NumEntries - 1; index >= 0; --index)
        cache.Entries[index] = first.Entries[index];
      int num = second.StartIndex - first.StartIndex;
      for (int index = second.NumEntries - 1; index >= 0; --index)
      {
        LeaderboardData.Row row1 = cache.Entries[num + index];
        if (row1 == null || !row1.Available)
          cache.Entries[num + index] = second.Entries[index];
        LeaderboardData.Row row2 = cache.Entries[num + index];
      }
      this.MergedCache = cache;
    }

    public LeaderboardData.Row[] GetRows()
    {
      int count = Math.Min(this.BatchSize, this.MergedCache.NumEntries);
      int sourceIndex = this.BatchStart - this.MergedCache.StartIndex;
      if (sourceIndex < 0)
        sourceIndex = 0;
      if (sourceIndex + count > this.MergedCache.NumEntries)
        sourceIndex = this.MergedCache.NumEntries - count;
      LeaderboardData.Row[] destination = new LeaderboardData.Row[count];
      this.CopyRows(ref this.MergedCache.Entries, sourceIndex, ref destination, 0, count);
      return destination;
    }

    private void CopyRows(ref LeaderboardData.Row[] source, int sourceIndex, ref LeaderboardData.Row[] destination, int destinationIndex, int count)
    {
      for (int index = count - 1; index >= 0; --index)
        destination[destinationIndex + index] = source[sourceIndex + index];
    }

    public Gamer GetSelectedGamer()
    {
      int index = this.Selected - this.MergedCache.StartIndex;
      if (index >= 0 && index < this.MergedCache.NumEntries)
        return this.MergedCache.Entries[index].Gamer;
      else
        return (Gamer) null;
    }

    public class Row
    {
      public bool Available;
      public int Rank;
      public uint[] Statistics;
      public Gamer Gamer;

      public string Gamertag
      {
        get
        {
          return this.Gamer.Gamertag;
        }
      }
    }

    private class Cache
    {
      public LeaderboardData.Row[] Entries;
      public int StartIndex;
      public int NumEntries;
    }

    private enum AsyncRequest
    {
      None,
      FullRead,
      NextPage,
      PreviousPage,
    }
  }
}
