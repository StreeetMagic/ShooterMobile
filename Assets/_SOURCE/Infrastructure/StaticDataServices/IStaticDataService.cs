using System.Collections.Generic;
using Configs.Resources;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.PlayerConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies;

namespace Infrastructure.StaticDataServices
{
  public interface IStaticDataService
  {
    PlayerConfig ForPlayer();
    EnemyConfig ForEnemy(EnemyId enemyId);
    void LoadConfigs();
    Dictionary<UpgradeId, UpgradeConfig> ForUpgrades();
    UpgradeConfig ForUpgradeConfig(UpgradeId id);
  }
}