using System;
using System.Collections.Generic;
using Infrastructure.StaticDataServices;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    private IStaticDataService _staticDataService;

    public PersistentProgressService(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public Progress Progress { get; private set; }

    public void LoadProgress(string getString) =>
      Progress =
        JsonUtility
          .FromJson<Progress>(getString);

    public void SetDefault()
    {
      Progress = new Progress
      {
        MoneyInBank = 20,
        MoneyInBackpack = 30,

        EggsInBank = 40,
        EggsInBackpack = 50,

        PlayerPosition = Vector3.zero,
        Expierience = 12,
      };

      Dictionary<UpgradeId, UpgradeConfig> upgrades = _staticDataService
        .ForUpgrades();

      foreach (KeyValuePair<UpgradeId, UpgradeConfig> upgrade in upgrades)
      {
        Progress.Upgrades.Add(new UpgradeProgress
        {
          Level = 3
        });
      }
    }
  }

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
  }

  [Serializable]
  public class UpgradeProgress
  {
    public int Level;
  }
}