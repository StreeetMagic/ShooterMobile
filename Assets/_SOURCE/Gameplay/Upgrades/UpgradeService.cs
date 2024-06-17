using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Stats;
using Infrastructure.ConfigServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;

namespace Gameplay.Upgrades
{
  public class UpgradeService : IProgressWriter
  {
    private readonly ConfigProvider _configProvider;

    private Dictionary<StatId, Upgrade> _upgrades;

    public UpgradeService(ConfigProvider configProvider)
    {
      _configProvider = configProvider;
    }

    public event Action Changed;

    public void BuyUpgrade(StatId statId)
    {
      if (_upgrades.TryGetValue(statId, out Upgrade upgrade) == false)
        return;

      upgrade.Level.Value++;
      Changed?.Invoke();
    }

    public Upgrade GetUpgrade(StatId statId)
    {
      return _upgrades.GetValueOrDefault(statId);
    }

    public int GetCurrentUpgradeValue(StatId statId) =>
      _configProvider
        .GetUpgradeConfig(statId)
        .Values[GetUpgrade(statId).Level.Value]
        .Value;

    public int GetNextUpgradeCost(StatId statId) =>
      _configProvider
        .GetUpgradeConfig(statId)
        .Values[GetUpgrade(statId).Level.Value + 1]
        .Cost;

    public void ReadProgress(ProjectProgress projectProgress)
    {
      Dictionary<StatId, UpgradeConfig> upgrades = _configProvider.UpgradeConfigs;
      _upgrades = new Dictionary<StatId, Upgrade>();

      foreach (StatId upgradeId in upgrades.Keys)
      {
        UpgradeConfig config = upgrades[upgradeId];
        int level = projectProgress.Upgrades.FirstOrDefault(u => u.Id == upgradeId)!.Level;
        _upgrades.Add(upgradeId, new Upgrade(config, level));
      }
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.Upgrades =
        _upgrades
          .Select(keyValuePair => new UpgradeProgress(keyValuePair.Key, keyValuePair.Value.Level.Value))
          .ToList();
    }
  }
}