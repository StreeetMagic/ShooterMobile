using System.Collections.Generic;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using UnityEngine;

namespace Gameplay.Upgrades
{
  public class UpgradeService : IProgressWriter
  {
    public Dictionary<UpgradeId, Upgrade> Upgrades;

    private readonly PersistentProgressService _progressService;
    private readonly IStaticDataService _staticDataService;

    public UpgradeService(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public void Work()
    {
    }

    public void ReadProgress(Progress progress)
    {
      Dictionary<UpgradeId, UpgradeConfig> upgrades = _staticDataService.ForUpgrades();

      List<UpgradeId> keys = new List<UpgradeId>(upgrades.Keys);

      foreach (UpgradeId upgradeId in keys)
      {
        keys.Add(upgradeId);
      }

      Upgrades = new Dictionary<UpgradeId, Upgrade>();

      for (int i = 0; i < upgrades.Count; i++)
      {
        Upgrade upgrade = new(upgrades[keys[i]]);

        Upgrades.Add(keys[i], upgrade);
      }
    }

    public void WriteProgress(Progress progress)
    {
      progress.Upgrades.Clear();

      foreach (KeyValuePair<UpgradeId, Upgrade> upgrade in Upgrades)
      {
        progress.Upgrades.Add(new UpgradeProgress
        {
          Level = upgrade.Value.Level.Value
        });
      }
    }
  }
}