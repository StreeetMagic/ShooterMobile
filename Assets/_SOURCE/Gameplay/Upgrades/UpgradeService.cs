using System.Collections.Generic;
using Configs.Resources.Upgrades;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using UnityEngine;

namespace Gameplay.Upgrades
{
  public class UpgradeService : IProgressWriter
  {
    public Dictionary<UpgradeId, Upgrade> Upgrades { get; set; }

    private readonly PersistentProgressService _progressService;
    private readonly IStaticDataService _staticDataService;
    private readonly SaveLoadService _saveLoadService;

    public UpgradeService(IStaticDataService staticDataService, PersistentProgressService progressService, SaveLoadService saveLoadService)
    {
      _staticDataService = staticDataService;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
    }

    public void ReadProgress(Progress progress)
    {
      Dictionary<UpgradeId, UpgradeConfig> upgrades = _staticDataService.ForUpgrades();

      List<UpgradeId> keys = new List<UpgradeId>(upgrades.Keys);

      foreach (UpgradeId upgradeId in upgrades.Keys)
      {
        keys.Add(upgradeId);
      }

      Upgrades = new Dictionary<UpgradeId, Upgrade>();

      for (int i = 0; i < upgrades.Count; i++)
      {
        Upgrade upgrade = new(upgrades[keys[i]])
        {
          Level =
          {
            Value = progress.Upgrades[i].Level
          }
        };

        Upgrades.Add(keys[i], upgrade);
      }

      Debug.Log(Upgrades.Count);
    }

    public void WriteProgress(Progress progress)
    {
      // progress.Upgrades.Clear();
      //
      // foreach (KeyValuePair<UpgradeId, Upgrade> upgrade in Upgrades)
      // {
      //   progress.Upgrades.Add(new UpgradeProgress
      //   {
      //     Level = upgrade.Value.Level.Value
      //   });
      // }
    }
  }
}