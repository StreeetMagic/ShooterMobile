using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
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
        MoneyInBank = 500,
        MoneyInBackpack = 0,

        EggsInBank = 0,
        EggsInBackpack = 0,

        PlayerPosition = Vector3.zero,
        Expierience = 0,
        Upgrades = new List<UpgradeProgress>(),

        MusicMute = false
      };

      Dictionary<StatId, UpgradeConfig> upgrades = _staticDataService
        .GetUpgradeConfigs();

      foreach (KeyValuePair<StatId, UpgradeConfig> upgrade in upgrades)
        Progress.Upgrades.Add(new UpgradeProgress(upgrade.Key, 0));
    }
  }
}