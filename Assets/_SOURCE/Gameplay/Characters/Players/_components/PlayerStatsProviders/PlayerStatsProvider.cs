using System;
using System.Collections.Generic;
using Gameplay.Stats;
using Gameplay.Upgrades;
using StaticDataServices;
using Utilities;

namespace Gameplay.Characters.Players.PlayerStatsProviders
{
  public class PlayerStatsProvider
  {
    private readonly UpgradeService _upgradeService;
    private readonly IStaticDataService _staticDataService;

    private readonly Dictionary<StatId, ReactiveProperty<float>> _upgradeStats = new();
    private readonly Dictionary<StatId, ReactiveProperty<float>> _questStats = new();

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
      if (_questStats.TryGetValue(statId, out ReactiveProperty<float> stat))
      {
        stat.Value += value;
      }
      else
      {
        _questStats.Add(statId, new ReactiveProperty<float>(value));
      }
    }

    public ReactiveProperty<float> GetStat(StatId id)
    {
      float value = 0;

      value += _staticDataService.GetInitialStat(id);
      
      if (_upgradeStats.TryGetValue(id, out ReactiveProperty<float> stat))
        value += stat.Value;
      
      if (_questStats.TryGetValue(id, out ReactiveProperty<float> questStat))
        value += questStat.Value;

      return new ReactiveProperty<float>(value);
    }

    private void UpdateValues()
    {
      _upgradeStats.Clear();

      foreach (StatId statId in Enum.GetValues(typeof(StatId)))
      {
        if (statId == StatId.Unknown)
          continue;

        var key = new ReactiveProperty<float>();
        _upgradeStats.Add(statId, key);

        int currentUpgradeValue = _upgradeService.GetCurrentUpgradeValue(statId);
        key.Value = currentUpgradeValue;
      }
    }
  }
}