using System;
using System.Collections.Generic;
using Gameplay.Quests;
using Gameplay.Upgrades;
using Gameplay.Weapons;

namespace PersistentProgresses
{
  [Serializable]
  public class ProjectProgress
  {
    public int MoneyInBank;
    public int EggsInBank;
    public int Expierience;
    public int Level;
    public bool MusicMute;
   // public Vector3 PlayerPosition;
    public WeaponTypeId PlayerWeaponId;

    public List<UpgradeProgress> Upgrades;
    public List<QuestProgress> Quests;
  }
}