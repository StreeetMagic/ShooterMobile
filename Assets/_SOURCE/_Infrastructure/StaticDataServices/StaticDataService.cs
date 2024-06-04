using System.Collections.Generic;
using System.Linq;
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
using PersistentProgresses;
using Projects;
using Sounds;
using UnityEngine;

namespace StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private readonly ProjectData _projectData;

    private string _playerConfigPath;
    private string _enemyConfigPath;
    private string _upgradeConfigPath;
    private string _soundConfigPath;
    private string _lootConfigPath;
    private string _musicConfigPath;
    private string _questConfigPath;
    private string _expirienceConfigPath;
    private string _rewardConfigPath;
    private string _defaultProjectProgressConfigPath;

    private PlayerConfig _playerConfig;
    private ExpirienceConfig _expirienceConfig;
    private Dictionary<EnemyId, EnemyConfig> _enemyConfigs;
    private Dictionary<StatId, UpgradeConfig> _upgradeConfigs;
    private Dictionary<CurrencyId, LootConfig> _lootConfigs;
    private Dictionary<MusicId, MusicConfig> _musicConfigs;
    private Dictionary<SoundId, SoundConfig> _soundConfigs;
    private Dictionary<StatId, float> _stats;
    private Dictionary<QuestId, QuestConfig> _questConfigs;
    private Dictionary<RewardId, RewardConfig> _rewardConfigs;
    private DefaultProjectProgressConfig _defaultProjectProgressConfig;

    public StaticDataService(ProjectData projectData)
    {
      _projectData = projectData;
    }

    public PlayerConfig GetPlayerConfig() =>
      _playerConfig;

    public DefaultProjectProgressConfig GetDefaultProjectProgressConfig() =>
      _defaultProjectProgressConfig;

    private void LoadExpirienceConfig() =>
      _expirienceConfig = Resources.Load<ExpirienceConfig>(_expirienceConfigPath);

    public EnemyConfig GetEnemyConfig(EnemyId enemyId) =>
      _enemyConfigs[enemyId];

    public Dictionary<StatId, UpgradeConfig> GetUpgradeConfigs() =>
      _upgradeConfigs;

    public UpgradeConfig GetUpgradeConfig(StatId id) =>
      _upgradeConfigs[id];

    public LootConfig GetLootConfig(CurrencyId lootDropId) =>
      _lootConfigs[lootDropId];

    public MusicConfig GetMusicConfig(MusicId musicId) =>
      _musicConfigs[musicId];

    public SoundConfig GetSoundConfig(SoundId soundId) =>
      _soundConfigs[soundId];

    public float GetInitialStat(StatId id) =>
      _stats[id];

    public QuestConfig GetQuestConfig(QuestId questId) =>
      _questConfigs[questId];

    public ExpirienceConfig GetExpirienceConfig() =>
      _expirienceConfig;

    public Dictionary<QuestId, QuestConfig> GetQuestConfigs() =>
      _questConfigs;

    public Dictionary<RewardId, RewardConfig> GetRewardConfigs() =>
      _rewardConfigs;

    public void LoadConfigs()
    {
      string startPath = _projectData.GameMode + "/";

      string playerConfigPath = startPath + "PlayerConfigs/PlayerConfig";

      _playerConfigPath = playerConfigPath;
      _enemyConfigPath = startPath + "EnemyConfigs";
      _upgradeConfigPath = startPath + "UpgradeConfigs";
      _soundConfigPath = startPath + "SoundConfigs";
      _lootConfigPath = startPath + "LootConfigs";
      _musicConfigPath = startPath + "MusicConfigs";
      _questConfigPath = startPath + "QuestConfigs";
      _expirienceConfigPath = startPath + "ExpirienceConfigs/ExpirienceConfig";
      _rewardConfigPath = startPath + "RewardConfigs";
      _defaultProjectProgressConfigPath = startPath + "DefaultProjectProgressConfig/DefaultProjectProgressConfig";

      LoadEnemyConfigs();
      LoadUpgradeConfigs();
      LoadLootConfigs();
      LoadMusicConfigs();
      LoadSoundConfigs();
      LoadInitialStats();
      LoadQuestConfigs();
      LoadExpirienceConfig();
      LoadRewardConfigs();
      LoadPlayerConfig();
      LoadDefaultProjectProgressConfig();
    }

    private void LoadDefaultProjectProgressConfig() =>
      _defaultProjectProgressConfig = Resources
        .Load<DefaultProjectProgressConfig>(_defaultProjectProgressConfigPath);

    private void LoadPlayerConfig() =>
      _playerConfig = Resources
        .Load<PlayerConfig>(_playerConfigPath);

    private void LoadRewardConfigs() =>
      _rewardConfigs = Resources
        .LoadAll<RewardConfig>(_rewardConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadQuestConfigs() =>
      _questConfigs = Resources
        .LoadAll<QuestConfig>(_questConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadInitialStats()
    {
      List<StatSetup> stats = Resources.Load<PlayerConfig>(_playerConfigPath).Stats;

      _stats = new Dictionary<StatId, float>();

      foreach (StatSetup stat in stats)
        _stats.Add(stat.StatId, stat.Value);
    }

    private void LoadUpgradeConfigs() =>
      _upgradeConfigs = Resources
        .LoadAll<UpgradeConfig>(_upgradeConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadEnemyConfigs() =>
      _enemyConfigs = Resources
        .LoadAll<EnemyConfig>(_enemyConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadLootConfigs() =>
      _lootConfigs = Resources
        .LoadAll<LootConfig>(_lootConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadMusicConfigs() =>
      _musicConfigs = Resources
        .LoadAll<MusicConfig>(_musicConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadSoundConfigs() =>
      _soundConfigs = Resources
        .LoadAll<SoundConfig>(_soundConfigPath)
        .ToDictionary(x => x.Id, x => x);
  }
}