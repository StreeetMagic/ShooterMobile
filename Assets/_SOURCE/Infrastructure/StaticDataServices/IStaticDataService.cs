using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.ExpirienceConfigs;
using Configs.Resources.PlayerConfigs.Scripts;
using Configs.Resources.QuestConfigs;
using Configs.Resources.SoundConfigs;
using Configs.Resources.SoundConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies;
using Gameplay.Currencies;
using Infrastructure.DataRepositories;

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
  }
}