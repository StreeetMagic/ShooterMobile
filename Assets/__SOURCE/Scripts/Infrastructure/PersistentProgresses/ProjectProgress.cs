using System;
using System.Collections.Generic;
using Quests;
using Upgrades;
using Weapons;

namespace Infrastructure.PersistentProgresses
{
  [Serializable]
  public class ProjectProgress
  {
    public int MoneyInBank;
    public int EggsInBank;
    public int Expierience;
    public bool MusicMute;
    public WeaponTypeId CurrentPlayerWeaponId;

    public List<UpgradeProgress> Upgrades;
    public List<QuestProgress> Quests;
    
    public List<WeaponTypeId> PlayerWeapons;
    
   // public Vector3 PlayerPosition;

   public ProjectProgress(int moneyInBank, int eggsInBank, int expierience, bool musicMute, 
     WeaponTypeId currentPlayerWeaponId, List<UpgradeProgress> upgrades, List<QuestProgress> quests, List<WeaponTypeId> playerWeapons)
   {
     MoneyInBank = moneyInBank;
     EggsInBank = eggsInBank;
     Expierience = expierience;
     MusicMute = musicMute;
     CurrentPlayerWeaponId = currentPlayerWeaponId;
     Upgrades = upgrades;
     Quests = quests;
     PlayerWeapons = playerWeapons;
   }
  }
}