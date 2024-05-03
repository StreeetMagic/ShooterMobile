using System;
using System.Collections.Generic;
using Configs.Resources.StatConfigs;
using Infrastructure.StaticDataServices;
using Infrastructure.Upgrades;
using Infrastructure.Utilities;

namespace Gameplay.Characters.Players.PlayerStatsProviders
{
  public class PlayerStatsProvider
  {
    private readonly UpgradeService _upgradeService;
    private readonly IStaticDataService _staticDataService;

    private readonly Dictionary<StatId, ReactiveProperty<int>> _upgradeStats = new();
    private readonly Dictionary<StatId, ReactiveProperty<int>> _questStats = new();

    public PlayerStatsProvider(UpgradeService upgradeService, IStaticDataService staticDataService)
    {
      _upgradeService = upgradeService;
      _staticDataService = staticDataService;
    }

    public void Start()
    {
      UpdateValues();

      _upgradeService.Changed += UpdateValues;
    }
    
    public void Stop()
    {
      _upgradeService.Changed -= UpdateValues;
    }

    public void AddQuestReward(StatId statId, int value)
    {
      if (_questStats.TryGetValue(statId, out ReactiveProperty<int> stat))
      {
        stat.Value += value;
      }
      else
      {
        _questStats.Add(statId, new ReactiveProperty<int>(value));
      }
    }

    private void UpdateValues()
    {
      _upgradeStats.Clear();

      foreach (StatId statId in Enum.GetValues(typeof(StatId)))
      {
        if (statId == StatId.Unknown)
          continue;

        var key = new ReactiveProperty<int>();
        _upgradeStats.Add(statId, key);

        int currentUpgradeValue = _upgradeService.GetCurrentUpgradeValue(statId);
        key.Value = _staticDataService.GetInitialStat(statId) + currentUpgradeValue;
      }
    }

    public ReactiveProperty<int> GetStat(StatId id)
    {
      int value = 0;

      if (_upgradeStats.TryGetValue(id, out ReactiveProperty<int> upgrade))
        value += upgrade.Value;

      if (_questStats.TryGetValue(id, out ReactiveProperty<int> questStat))
        value += questStat.Value;

      return new ReactiveProperty<int>(value);
    }
  }
}