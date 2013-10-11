// Type: Terraria.Achievements.TriggerSystem
// Assembly: game, Version=1.0.4.1, Culture=neutral, PublicKeyToken=null
// MVID: D0F84B30-D7A0-41D8-8306-C72BB0D9D9CF
// Assembly location: C:\Users\DartPower\Downloads\Terraria.Xbox.360.Edition.XBLA.XBOX360-MoNGoLS\5841128F\000D0000\Terraria\Terraria.exe\ASSEMBLY.exe

using Microsoft.Xna.Framework.GamerServices;
using System.Collections;
using Terraria;

namespace Terraria.Achievements
{
  public class TriggerSystem
  {
    private TriggerSystem.TriggerLink[] Links = new TriggerSystem.TriggerLink[30]
    {
      TriggerSystem.Link(Trigger.HighestPosition, Achievement.BewareIcharus),
      TriggerSystem.Link(Trigger.HouseGuide, Achievement.HomeSweetHome),
      TriggerSystem.Link(Trigger.HousedAllNPCs, Achievement.FamilyNight),
      TriggerSystem.Link(Trigger.LowestPosition, Achievement.GoingDown),
      TriggerSystem.Link(Trigger.AllSlimesKilled, Achievement.KingOfSlimes),
      TriggerSystem.Link(Trigger.AllBossesKilled, Achievement.Exterminator),
      TriggerSystem.Link(Trigger.UnlockedHardMode, Achievement.LookingForChallenge),
      TriggerSystem.Link(Trigger.MaxHealthAndMana, Achievement.AllPumpedUp),
      TriggerSystem.Link(Trigger.CorruptedWorld, Achievement.CorruptedSoul),
      TriggerSystem.Link(Trigger.HallowedWorld, Achievement.HallowedBeThyName),
      TriggerSystem.Link(Trigger.FirstTutorialTaskCompleted, Achievement.TerrariaStudent),
      TriggerSystem.Link(Trigger.AllTutorialTasksCompleted, Achievement.TerrariaExpert),
      TriggerSystem.Link(Trigger.KilledTheTwins, Achievement.Ophthalmologist),
      TriggerSystem.Link(Trigger.KilledSkeletronPrime, Achievement.Anthropologist),
      TriggerSystem.Link(Trigger.KilledDestroyer, Achievement.Biologist),
      TriggerSystem.Link(Trigger.Walked42KM, Achievement.MarathonRunner),
      TriggerSystem.Link(Trigger.RemovedLotsOfTiles, Achievement.LandscapeArchitect),
      TriggerSystem.Link(Trigger.KilledGoblinArmy, Achievement.DefeatedTheMob),
      TriggerSystem.Link(Trigger.Sunrise, Achievement.Survivor),
      TriggerSystem.Link(Trigger.SunriseAfterBloodMoon, Achievement.WhenTheMoonTurnsRed),
      TriggerSystem.Link(Trigger.AllVanitySlotsEquipped, Achievement.FashionModel),
      TriggerSystem.Link(Trigger.CreatedLotsOfBars, Achievement.Smelter),
      TriggerSystem.Link(Trigger.Has5Buffs, Achievement.PreparationIsEverything),
      TriggerSystem.Link(Trigger.SpawnedAllPets, Achievement.AnimalShelter),
      TriggerSystem.Link(Trigger.CollectedAllArmor, Achievement.Collector),
      TriggerSystem.Link(Trigger.UsedLotsOfAnvils, Achievement.Blacksmith),
      TriggerSystem.Link(Trigger.UsedAllCraftingStations, Achievement.ExpertCrafter),
      TriggerSystem.Link(Trigger.PlacedLotsOfWires, Achievement.Engineer),
      TriggerSystem.Link(Trigger.WentDownAndUpWithoutDyingOrWarping, Achievement.HellAndBack),
      TriggerSystem.Link(Trigger.InTheSky, Achievement.Airtime)
    };
    private bool[] Triggers = new bool[30];
    private bool[] CheckTriggers = new bool[30];

    private static TriggerSystem.TriggerLink Link(Trigger trigger, Achievement achievement)
    {
      return new TriggerSystem.TriggerLink()
      {
        Trigger = trigger,
        Achievement = achievement
      };
    }

    public bool CheckEnabled(Trigger trigger)
    {
      return this.CheckTriggers[(int) trigger];
    }

    public void SetState(Trigger trigger, bool state)
    {
      this.Triggers[(int) trigger] = state;
    }

    public void ReadProfile(SignedInGamer gamer)
    {
      if (gamer.IsGuest)
        return;
      Main.AchievementSystem.GetEarnedAchievements(gamer, new EarnedAchievementsCallback(this.UpdateTriggerChecks));
    }

    private void UpdateTriggerChecks(BitArray earned)
    {
      for (int index1 = 29; index1 >= 0; --index1)
      {
        int index2 = (int) this.Links[index1].Trigger;
        int index3 = (int) this.Links[index1].Achievement;
        this.CheckTriggers[index2] = !earned.Get(index3);
        this.Triggers[index2] = false;
      }
    }

    public void UpdateAchievements(SignedInGamer gamer)
    {
      for (int index1 = 29; index1 >= 0; --index1)
      {
        int index2 = (int) this.Links[index1].Trigger;
        Achievement achievement = this.Links[index1].Achievement;
        if (this.CheckTriggers[index2] && this.Triggers[index2])
        {
          this.CheckTriggers[index2] = false;
          Main.AchievementSystem.Award(gamer, achievement);
        }
      }
    }

    private struct TriggerLink
    {
      public Trigger Trigger;
      public Achievement Achievement;
    }
  }
}
