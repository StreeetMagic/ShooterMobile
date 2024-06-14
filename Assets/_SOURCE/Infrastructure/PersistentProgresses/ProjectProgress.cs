using System;
using System.Collections.Generic;
using Gameplay.Quests;
using Gameplay.Upgrades;
using Gameplay.Weapons;
using UnityEngine.Serialization;

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
    
   // public Vector3 PlayerPosition;
  }
}