using System;
using System.Collections.Generic;
using Configs.Resources.Upgrades;
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
    
    public UpgradeProgress FindUpgrade(UpgradeId id) =>
      Upgrades.Find(x => x.Id == id);
  }
}