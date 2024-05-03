using System;
using System.Collections.Generic;
using Quests;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  [Serializable]
  public class ProjectProgress
  {
    public int MoneyInBank;
    public int EggsInBank;
    public int Expierience;
    public int Level;
    public bool MusicMute;
    public Vector3 PlayerPosition;

    public List<UpgradeProgress> Upgrades;
    public List<QuestProgress> Quests;
  }
}