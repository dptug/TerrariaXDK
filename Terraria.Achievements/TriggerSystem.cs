using Microsoft.Xna.Framework.GamerServices;
using System.Collections;

namespace Terraria.Achievements
{
	public class TriggerSystem
	{
		private struct TriggerLink
		{
			public Trigger Trigger;

			public Achievement Achievement;
		}

		private TriggerLink[] Links = new TriggerLink[30]
		{
			Link(Trigger.HighestPosition, Achievement.BewareIcharus),
			Link(Trigger.HouseGuide, Achievement.HomeSweetHome),
			Link(Trigger.HousedAllNPCs, Achievement.FamilyNight),
			Link(Trigger.LowestPosition, Achievement.GoingDown),
			Link(Trigger.AllSlimesKilled, Achievement.KingOfSlimes),
			Link(Trigger.AllBossesKilled, Achievement.Exterminator),
			Link(Trigger.UnlockedHardMode, Achievement.LookingForChallenge),
			Link(Trigger.MaxHealthAndMana, Achievement.AllPumpedUp),
			Link(Trigger.CorruptedWorld, Achievement.CorruptedSoul),
			Link(Trigger.HallowedWorld, Achievement.HallowedBeThyName),
			Link(Trigger.FirstTutorialTaskCompleted, Achievement.TerrariaStudent),
			Link(Trigger.AllTutorialTasksCompleted, Achievement.TerrariaExpert),
			Link(Trigger.KilledTheTwins, Achievement.Ophthalmologist),
			Link(Trigger.KilledSkeletronPrime, Achievement.Anthropologist),
			Link(Trigger.KilledDestroyer, Achievement.Biologist),
			Link(Trigger.Walked42KM, Achievement.MarathonRunner),
			Link(Trigger.RemovedLotsOfTiles, Achievement.LandscapeArchitect),
			Link(Trigger.KilledGoblinArmy, Achievement.DefeatedTheMob),
			Link(Trigger.Sunrise, Achievement.Survivor),
			Link(Trigger.SunriseAfterBloodMoon, Achievement.WhenTheMoonTurnsRed),
			Link(Trigger.AllVanitySlotsEquipped, Achievement.FashionModel),
			Link(Trigger.CreatedLotsOfBars, Achievement.Smelter),
			Link(Trigger.Has5Buffs, Achievement.PreparationIsEverything),
			Link(Trigger.SpawnedAllPets, Achievement.AnimalShelter),
			Link(Trigger.CollectedAllArmor, Achievement.Collector),
			Link(Trigger.UsedLotsOfAnvils, Achievement.Blacksmith),
			Link(Trigger.UsedAllCraftingStations, Achievement.ExpertCrafter),
			Link(Trigger.PlacedLotsOfWires, Achievement.Engineer),
			Link(Trigger.WentDownAndUpWithoutDyingOrWarping, Achievement.HellAndBack),
			Link(Trigger.InTheSky, Achievement.Airtime)
		};

		private bool[] Triggers = new bool[30];

		private bool[] CheckTriggers = new bool[30];

		private static TriggerLink Link(Trigger trigger, Achievement achievement)
		{
			TriggerLink result = default(TriggerLink);
			result.Trigger = trigger;
			result.Achievement = achievement;
			return result;
		}

		public bool CheckEnabled(Trigger trigger)
		{
			return CheckTriggers[(int)trigger];
		}

		public void SetState(Trigger trigger, bool state)
		{
			Triggers[(int)trigger] = state;
		}

		public void ReadProfile(SignedInGamer gamer)
		{
			if (!gamer.IsGuest)
			{
				Main.AchievementSystem.GetEarnedAchievements(gamer, UpdateTriggerChecks);
			}
		}

		private void UpdateTriggerChecks(BitArray earned)
		{
			for (int num = 29; num >= 0; num--)
			{
				int trigger = (int)Links[num].Trigger;
				int achievement = (int)Links[num].Achievement;
				CheckTriggers[trigger] = !earned.Get(achievement);
				Triggers[trigger] = false;
			}
		}

		public void UpdateAchievements(SignedInGamer gamer)
		{
			for (int num = 29; num >= 0; num--)
			{
				int trigger = (int)Links[num].Trigger;
				Achievement achievement = Links[num].Achievement;
				if (CheckTriggers[trigger] && Triggers[trigger])
				{
					CheckTriggers[trigger] = false;
					Main.AchievementSystem.Award(gamer, achievement);
				}
			}
		}
	}
}
