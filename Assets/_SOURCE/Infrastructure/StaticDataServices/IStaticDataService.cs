using System.Collections.Generic;
using Configs.Resources;
using Configs.Resources.Enemies;
using Configs.Resources.Upgrades;
using Gameplay.Characters.Enemies;

namespace Infrastructure.StaticDataServices
{
  public interface IStaticDataService
  {
    PlayerConfig ForPlayer();
    EnemyConfig ForEnemy(EnemyId enemyId);
    void LoadConfigs();
    Dictionary<UpgradeId, UpgradeConfig> ForUpgrades();
    UpgradeConfig ForConfig(UpgradeId id);
  }
}