using System;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  [Serializable]
  public class Progress
  {
    public int MoneyInBank;
    public int MoneyInBackpack;

    public int EggsInBank;
    public int EggsInBackpack;

    public int Expierience;
    public Vector3 PlayerPosition;

    public List<UpgradeProgress> Upgrades;
    
    public UpgradeProgress FindUpgradeProgress(UpgradeId id) =>
      Upgrades.Find(x => x.Id == id);
  }
}