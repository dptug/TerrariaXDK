// Type: Terraria.Achievements.AchievementSystem
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Terraria.Achievements
{
  public class AchievementSystem
  {
    private const int MaxConcurrentSubmissions = 10;
    private const int MaxAchievementCount = 30;
    private IAsyncResult[] submissions;
    private int firstFree;

    public AchievementSystem()
    {
      this.submissions = new IAsyncResult[10];
      this.firstFree = 0;
    }

    ~AchievementSystem()
    {
    }

    private static void ProcessEarnedAchievements(IAsyncResult result)
    {
      AchievementSystem.EarnedAchievementsData achievementsData = (AchievementSystem.EarnedAchievementsData) result.AsyncState;
      BitArray earned = new BitArray(39);
      try
      {
        AchievementCollection achievements = achievementsData.Gamer.EndGetAchievements(result);
        Type enumType = typeof (Achievement);
        using (IEnumerator<Microsoft.Xna.Framework.GamerServices.Achievement> enumerator = achievements.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            Microsoft.Xna.Framework.GamerServices.Achievement current = enumerator.Current;
            int index;
            try
            {
              index = (int) Enum.Parse(enumType, current.Key, false);
            }
            catch (ArgumentException ex)
            {
              continue;
            }
            earned.Set(index, current.IsEarned);
          }
        }
      }
      catch
      {
      }
      achievementsData.Callback(earned);
    }

    public void GetEarnedAchievements(SignedInGamer gamer, EarnedAchievementsCallback callback)
    {
      AchievementSystem.EarnedAchievementsData achievementsData = new AchievementSystem.EarnedAchievementsData()
      {
        Callback = callback,
        Gamer = gamer
      };
      gamer.BeginGetAchievements(new AsyncCallback(AchievementSystem.ProcessEarnedAchievements), (object) achievementsData);
    }

    public void Award(SignedInGamer gamer, Achievement achievement)
    {
      string str = ((object) achievement).ToString();
      if (achievement >= Achievement.BackForSeconds)
        return;
      IAsyncResult asyncResult;
      try
      {
        asyncResult = gamer.BeginAwardAchievement(str, (AsyncCallback) null, (object) null);
      }
      catch (ArgumentException ex)
      {
        return;
      }
      this.submissions[this.firstFree] = asyncResult;
      ++this.firstFree;
    }

    public void Update()
    {
      int index = 0;
      while (index < this.firstFree)
      {
        if (!this.submissions[index].IsCompleted)
        {
          ++index;
        }
        else
        {
          --this.firstFree;
          this.submissions[index] = this.submissions[this.firstFree];
          this.submissions[this.firstFree] = (IAsyncResult) null;
        }
      }
    }

    private class EarnedAchievementsData
    {
      public EarnedAchievementsCallback Callback;
      public SignedInGamer Gamer;
    }
  }
}
