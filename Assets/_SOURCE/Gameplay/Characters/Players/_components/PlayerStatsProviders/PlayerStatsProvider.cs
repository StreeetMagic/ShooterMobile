using System;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Upgrades;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players._components.PlayerStatsServices
{
  public class PlayerStatsProvider : IInitializable
  {
    private readonly UpgradeService _upgradeService;
    private readonly IStaticDataService _staticDataService;

    public ReactiveProperty<int> Damage { get; } = new();
    public ReactiveProperty<int> BackpackCapacity { get; } = new();
    public ReactiveProperty<int> ChickenCount { get; } = new();
    public ReactiveProperty<int> GroupAttack { get; } = new();
    public ReactiveProperty<int> MoveSpeed { get; } = new();
    public ReactiveProperty<int> FireRange { get; } = new();
    public ReactiveProperty<int> Health { get; } = new();

    public PlayerStatsProvider(UpgradeService upgradeService, IStaticDataService staticDataService)
    {
      _upgradeService = upgradeService;
      _staticDataService = staticDataService;
    }

    public void Initialize()
    {
      var playerConfig = _staticDataService.GetPlayerConfig();

      Damage.Value = playerConfig.InitialDamage;
      BackpackCapacity.Value = playerConfig.InitialBackpackCapacity;
      ChickenCount.Value = playerConfig.InitialChickenCount;
      GroupAttack.Value = playerConfig.InitialGroupAttack;
      MoveSpeed.Value = playerConfig.InitialMoveSpeed;
      FireRange.Value = playerConfig.InitialFireRange;
      Health.Value = playerConfig.InitialHealth;
    }

    public ReactiveProperty<int> GetStat(StatId id)
    {
      switch (id)
      {
        case StatId.Damage:
          return Damage;
        case StatId.BackpackCapacity:
          return BackpackCapacity;
        case StatId.ChickenCount:
          return ChickenCount;
        case StatId.GroupAttack:
          return GroupAttack;
        case StatId.MoveSpeed:
          return MoveSpeed;
        case StatId.FireRange:
          return FireRange;
        case StatId.Health:
          return Health;
        default:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);
      }
    }
  }
}