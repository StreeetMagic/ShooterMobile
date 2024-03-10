using System.Collections.Generic;
using System.Linq;
using Configs.Resources;
using Configs.Resources.Enemies;
using Configs.Resources.Upgrades;
using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Infrastructure.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private PlayerConfig _playerConfig;
    private bool _enemyLoaded;

    private Dictionary<EnemyId, EnemyConfig> _enemyConfigs;
    private Dictionary<UpgradeId, UpgradeConfig> _upgradeConfigs;

    public PlayerConfig ForPlayer() =>
      _playerConfig ??= Resources.Load<PlayerConfig>(nameof(PlayerConfig));

    public EnemyConfig ForEnemy(EnemyId enemyId) =>
      _enemyConfigs[enemyId];

    public Dictionary<UpgradeId, UpgradeConfig> ForUpgrades() =>
      _upgradeConfigs;

    public UpgradeConfig ForConfig(UpgradeId id) =>
      _upgradeConfigs[id]; 

    public void LoadConfigs()
    {
      LoadEnemyConfigs();
      LoadUpgradeConfigs();
    }

    private void LoadUpgradeConfigs() =>
      _upgradeConfigs = Resources
        .LoadAll<UpgradeConfig>("Upgrades")
        .ToDictionary(x => x.Id, x => x);

    private void LoadEnemyConfigs() =>
      _enemyConfigs = Resources
        .LoadAll<EnemyConfig>("Enemies")
        .ToDictionary(x => x.Id, x => x);
  }
}