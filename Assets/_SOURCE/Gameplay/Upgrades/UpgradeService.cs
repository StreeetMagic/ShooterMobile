using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Resources.UpgradeConfigs.Scripts;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Unity.VisualScripting;

namespace Gameplay.Upgrades
{
  public class UpgradeService : IProgressWriter
  {
    private readonly IStaticDataService _staticDataService;

    private Dictionary<UpgradeId, Upgrade> _upgrades;

    public UpgradeService(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public event Action Changed;

    public void BuyUpgrade(UpgradeId upgradeId)
    {
      if (_upgrades.TryGetValue(upgradeId, out Upgrade upgrade) == false)
        return;

      upgrade.Level.Value++;
      Changed?.Invoke();
    }

    public Upgrade GetUpgrade(UpgradeId upgradeId) =>
      _upgrades.GetValueOrDefault(upgradeId);

    public int GetNextUpgradeCost(UpgradeId upgradeId) =>
      _staticDataService
        .ForUpgradeConfig(upgradeId)
        .Values[GetUpgrade(upgradeId).Level.Value + 1]
        .Cost;

    public void ReadProgress(Progress progress)
    {
      Dictionary<UpgradeId, UpgradeConfig> upgrades = _staticDataService.ForUpgrades();
      _upgrades = new Dictionary<UpgradeId, Upgrade>();

      foreach (UpgradeId upgradeId in upgrades.Keys)
      {
        UpgradeConfig config = upgrades[upgradeId];
        int level = progress.Upgrades.FirstOrDefault(u => u.Id == upgradeId).Level;
        _upgrades.Add(upgradeId, new Upgrade(config, level));
      }
    }

    public void WriteProgress(Progress progress)
    {
      progress.Upgrades =
        _upgrades
          .Select(keyValuePair => new UpgradeProgress(keyValuePair.Key, keyValuePair.Value.Level.Value))
          .ToList();
    }
  }
}