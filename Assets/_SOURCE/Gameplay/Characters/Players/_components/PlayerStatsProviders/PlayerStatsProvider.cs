using System;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Upgrades;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using Zenject;
using System.Collections.Generic;
using Configs.Resources.PlayerConfigs.Scripts;
using UnityEngine;

namespace Gameplay.Characters.Players._components.PlayerStatsServices
{
  public class PlayerStatsProvider
  {
    private readonly UpgradeService _upgradeService;
    private readonly IStaticDataService _staticDataService;
    private readonly Dictionary<StatId, ReactiveProperty<int>> _stats = new();

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

    private void UpdateValues()
    {
      _stats.Clear();

      foreach (StatId statId in Enum.GetValues(typeof(StatId)))
      {
        if (statId == StatId.Unknown)
          continue;

        var key = new ReactiveProperty<int>();
        _stats.Add(statId, key);

        int currentUpgradeValue = _upgradeService.GetCurrentUpgradeValue(statId);
        key.Value = _staticDataService.GetInitialStat(statId) + currentUpgradeValue;
      }
    }

    public ReactiveProperty<int> GetStat(StatId id)
    {
      if (_stats.TryGetValue(id, out ReactiveProperty<int> stat))
        return stat;

      throw new ArgumentOutOfRangeException(nameof(id), id, null);
    }
  }
}