using System.Collections.Generic;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories;
using Gameplay.CurrencyRepositories.Expirience;
using Gameplay.Grenades;
using Gameplay.Loots;
using Gameplay.Quests;
using Gameplay.Rewards;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Gameplay.Weapons;
using Infrastructure.PersistentProgresses;

namespace Infrastructure.StaticDataServices
{
  public interface IStaticDataService
  {
    void LoadConfigs();
    
    Dictionary<StatId, UpgradeConfig> GetUpgradeConfigs();
    Dictionary<QuestId, QuestConfig> GetQuestConfigs();
    Dictionary<RewardId, RewardConfig> GetRewardConfigs();
    
    PlayerConfig GetPlayerConfig();
    EnemyConfig GetEnemyConfig(EnemyTypeId enemyId);
    UpgradeConfig GetUpgradeConfig(StatId id);
    LootConfig GetLootConfig(CurrencyId lootDropId);
    float GetInitialStat(StatId id);
    QuestConfig GetQuestConfig(QuestId questId);
    ExpirienceConfig GetExpirienceConfig();
    DefaultProjectProgressConfig GetDefaultProjectProgressConfig();
    WeaponConfig GetWeaponConfig(WeaponTypeId weaponTypeId);
    GrenadeConfig GetGrenadeConfig(GrenadeTypeId grenadeTypeId);
  }
}