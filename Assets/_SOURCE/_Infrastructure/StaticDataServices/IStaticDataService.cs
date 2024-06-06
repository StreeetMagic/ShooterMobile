using System.Collections.Generic;
using CurrencyRepositories;
using CurrencyRepositories.Expirience;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Players;
using Gameplay.Grenades;
using Gameplay.Loots;
using Gameplay.Quests;
using Gameplay.Rewards;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Musics;
using PersistentProgresses;
using Sounds;

namespace StaticDataServices
{
  public interface IStaticDataService
  {
    void LoadConfigs();
    
    Dictionary<StatId, UpgradeConfig> GetUpgradeConfigs();
    Dictionary<QuestId, QuestConfig> GetQuestConfigs();
    Dictionary<RewardId, RewardConfig> GetRewardConfigs();
    
    PlayerConfig GetPlayerConfig();
    EnemyConfig GetEnemyConfig(EnemyId enemyId);
    UpgradeConfig GetUpgradeConfig(StatId id);
    LootConfig GetLootConfig(CurrencyId lootDropId);
    MusicConfig GetMusicConfig(MusicId musicId);
    SoundConfig GetSoundConfig(SoundId soundId);
    float GetInitialStat(StatId id);
    QuestConfig GetQuestConfig(QuestId questId);
    ExpirienceConfig GetExpirienceConfig();
    DefaultProjectProgressConfig GetDefaultProjectProgressConfig();
    WeaponConfig GetWeaponConfig(WeaponTypeId weaponTypeId);
    GrenadeConfig GetGrenadeConfig(GrenadeTypeId grenadeTypeId);
  }
}