using System.Collections.Generic;
using Configs.Resources.Upgrades;
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
        MoneyInBank = 1000,
        MoneyInBackpack = 0,

        EggsInBank = 40,
        EggsInBackpack = 0,

        PlayerPosition = Vector3.zero,
        Expierience = 0,
        Upgrades = new List<UpgradeProgress>()
      };

      Dictionary<UpgradeId, UpgradeConfig> upgrades = _staticDataService
        .ForUpgrades();

      foreach (KeyValuePair<UpgradeId, UpgradeConfig> upgrade in upgrades)
        Progress.Upgrades.Add(new UpgradeProgress(upgrade.Key, 0));
    }
  }
}