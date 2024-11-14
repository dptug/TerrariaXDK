using System;
using System.Collections;
using Microsoft.Xna.Framework.GamerServices;

namespace Terraria.Achievements;

public class AchievementSystem
{
	private class EarnedAchievementsData
	{
		public EarnedAchievementsCallback Callback;

		public SignedInGamer Gamer;
	}

	private const int MaxConcurrentSubmissions = 10;

	private const int MaxAchievementCount = 30;

	private IAsyncResult[] submissions;

	private int firstFree;

	public AchievementSystem()
	{
		submissions = new IAsyncResult[10];
		firstFree = 0;
	}

	~AchievementSystem()
	{
	}

	private static void ProcessEarnedAchievements(IAsyncResult result)
	{
		EarnedAchievementsData earnedAchievementsData = (EarnedAchievementsData)result.AsyncState;
		BitArray bitArray = new BitArray(39);
		try
		{
			AchievementCollection achievementCollection = earnedAchievementsData.Gamer.EndGetAchievements(result);
			Type typeFromHandle = typeof(Achievement);
			foreach (Microsoft.Xna.Framework.GamerServices.Achievement item in achievementCollection)
			{
				int num = -1;
				try
				{
					num = (int)Enum.Parse(typeFromHandle, item.Key, ignoreCase: false);
				}
				catch (ArgumentException)
				{
					continue;
				}
				bitArray.Set(num, item.IsEarned);
			}
		}
		catch
		{
		}
		earnedAchievementsData.Callback(bitArray);
	}

	public void GetEarnedAchievements(SignedInGamer gamer, EarnedAchievementsCallback callback)
	{
		EarnedAchievementsData earnedAchievementsData = new EarnedAchievementsData();
		earnedAchievementsData.Callback = callback;
		earnedAchievementsData.Gamer = gamer;
		EarnedAchievementsData earnedAchievementsData2 = earnedAchievementsData;
		gamer.BeginGetAchievements((AsyncCallback)ProcessEarnedAchievements, (object)earnedAchievementsData2);
	}

	public void Award(SignedInGamer gamer, Achievement achievement)
	{
		string text = achievement.ToString();
		if (achievement < Achievement.BackForSeconds)
		{
			IAsyncResult asyncResult = null;
			try
			{
				asyncResult = gamer.BeginAwardAchievement(text, (AsyncCallback)null, (object)null);
			}
			catch (ArgumentException)
			{
				return;
			}
			submissions[firstFree] = asyncResult;
			firstFree++;
		}
	}

	public void Update()
	{
		int num = 0;
		while (num < firstFree)
		{
			IAsyncResult asyncResult = submissions[num];
			if (!asyncResult.IsCompleted)
			{
				num++;
				continue;
			}
			firstFree--;
			submissions[num] = submissions[firstFree];
			submissions[firstFree] = null;
		}
	}
}
