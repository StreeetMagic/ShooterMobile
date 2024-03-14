using System.Collections.Generic;
using System.Linq;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.PlayerConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Infrastructure.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private const string PlayerConfigPath = "PlayerConfigs/PlayerConfig";
    private const string EnemyConfigPath = "EnemyConfigs";
    private const string UpgradeConfigPath = "UpgradeConfigs";
    private const string SoundConfigPath = "SoundConfigs";

    private PlayerConfig _playerConfig;
    private bool _enemyLoaded;

    private Dictionary<EnemyId, EnemyConfig> _enemyConfigs;
    private Dictionary<UpgradeId, UpgradeConfig> _upgradeConfigs;

    public PlayerConfig ForPlayer() =>
      _playerConfig ??= Resources.Load<PlayerConfig>(PlayerConfigPath);

    public EnemyConfig ForEnemy(EnemyId enemyId) =>
      _enemyConfigs[enemyId];

    public Dictionary<UpgradeId, UpgradeConfig> ForUpgrades() =>
      _upgradeConfigs;

    public UpgradeConfig ForUpgradeConfig(UpgradeId id) =>
      _upgradeConfigs[id];

    public void LoadConfigs()
    {
      LoadEnemyConfigs();
      LoadUpgradeConfigs();
    }

    private void LoadUpgradeConfigs() =>
      _upgradeConfigs = Resources
        .LoadAll<UpgradeConfig>(UpgradeConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadEnemyConfigs() =>
      _enemyConfigs = Resources
        .LoadAll<EnemyConfig>(EnemyConfigPath)
        .ToDictionary(x => x.Id, x => x);
  }
}