using System.Collections.Generic;
using CurrencyRepositories;
using CurrencyRepositories.Expirience;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Players;
using Gameplay.Loots;
using Gameplay.Quests;
using Gameplay.Rewards;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Musics;
using Sounds;

namespace _Infrastructure.StaticDataServices
{
  public interface IStaticDataService
  {
    PlayerConfig GetPlayerConfig();
    EnemyConfig GetEnemyConfig(EnemyId enemyId);
    void LoadConfigs();
    Dictionary<StatId, UpgradeConfig> GetUpgradeConfigs();
    UpgradeConfig GetUpgradeConfig(StatId id);
    LootConfig GetLootConfig(CurrencyId lootDropId);
    MusicConfig GetMusicConfig(MusicId musicId);
    SoundConfig GetSoundConfig(SoundId soundId);
    int GetInitialStat(StatId id);
    Dictionary<QuestId, QuestConfig> GetQuestConfigs();
    QuestConfig GetQuestConfig(QuestId questId);
    ExpirienceConfig GetExpirienceConfig();
    Dictionary<RewardId, RewardConfig> GetRewardConfigs();
  }
}