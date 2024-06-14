using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Infrastructure.ConfigServices;
using Infrastructure.Utilities;

namespace Gameplay.Characters.Players
{
  public class PlayerStatsProvider
  {
    private readonly UpgradeService _upgradeService;
    private readonly ConfigService _configService;

    private readonly Dictionary<StatId, ReactiveProperty<float>> _upgradeStats = new();
    private readonly Dictionary<StatId, ReactiveProperty<float>> _questStats = new();

    public PlayerStatsProvider(UpgradeService upgradeService, ConfigService configService)
    {
      _upgradeService = upgradeService;
      _configService = configService;
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

    public float GetStat(StatId id)
    {
      float value = 0;

      value += _configService.PlayerConfig.Stats.First(x => x.StatId == id).Value;
      
      if (_upgradeStats.TryGetValue(id, out ReactiveProperty<float> stat))
        value += stat.Value;
      
      if (_questStats.TryGetValue(id, out ReactiveProperty<float> questStat))
        value += questStat.Value;

      return value; 
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