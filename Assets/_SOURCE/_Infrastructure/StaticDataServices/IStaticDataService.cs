using System.Collections.Generic;
using Configs.Resources.CurrencyConfigs;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.ExpirienceConfigs;
using Configs.Resources.LootConfigs;
using Configs.Resources.MusicConfigs.Scripts;
using Configs.Resources.PlayerConfigs.Scripts;
using Configs.Resources.QuestConfigs.Scripts;
using Configs.Resources.RewardConfigs;
using Configs.Resources.SoundConfigs.Scripts;
using Configs.Resources.StatConfigs;
using Configs.Resources.UpgradeConfigs.Scripts;

namespace Infrastructure.StaticDataServices
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