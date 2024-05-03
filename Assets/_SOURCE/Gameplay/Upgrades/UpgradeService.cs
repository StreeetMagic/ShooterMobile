using System;
using System.Collections.Generic;
using System.Linq;
using Configs.Resources.StatConfigs;
using Configs.Resources.UpgradeConfigs.Scripts;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;

namespace Infrastructure.Upgrades
{
  public class UpgradeService : IProgressWriter
  {
    private readonly IStaticDataService _staticDataService;

    private Dictionary<StatId, Upgrade> _upgrades;

    public UpgradeService(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
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
      _staticDataService
        .GetUpgradeConfig(statId)
        .Values[GetUpgrade(statId).Level.Value]
        .Value;

    public int GetNextUpgradeCost(StatId statId) =>
      _staticDataService
        .GetUpgradeConfig(statId)
        .Values[GetUpgrade(statId).Level.Value + 1]
        .Cost;

    public void ReadProgress(Progress progress)
    {
      Dictionary<StatId, UpgradeConfig> upgrades = _staticDataService.GetUpgradeConfigs();
      _upgrades = new Dictionary<StatId, Upgrade>();

      foreach (StatId upgradeId in upgrades.Keys)
      {
        UpgradeConfig config = upgrades[upgradeId];
        int level = progress.Upgrades.FirstOrDefault(u => u.Id == upgradeId)!.Level;
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