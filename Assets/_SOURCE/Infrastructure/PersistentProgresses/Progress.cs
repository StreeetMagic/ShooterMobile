using System;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.PersistentProgresses
{
  [Serializable]
  public class Progress
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