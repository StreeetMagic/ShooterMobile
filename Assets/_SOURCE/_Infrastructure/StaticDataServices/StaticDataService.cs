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

    private DefaultProjectProgressConfig _defaultProjectProgressConfig;
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
    private Dictionary<WeaponTypeId, WeaponConfig> _weaponConfigs;

    public StaticDataService(ProjectData projectData)
    {
      _projectData = projectData;
    }

    public PlayerConfig GetPlayerConfig() => _playerConfig;
    public DefaultProjectProgressConfig GetDefaultProjectProgressConfig() => _defaultProjectProgressConfig;
    public EnemyConfig GetEnemyConfig(EnemyId enemyId) => _enemyConfigs[enemyId];
    public Dictionary<StatId, UpgradeConfig> GetUpgradeConfigs() => _upgradeConfigs;
    public UpgradeConfig GetUpgradeConfig(StatId id) => _upgradeConfigs[id];
    public LootConfig GetLootConfig(CurrencyId lootDropId) => _lootConfigs[lootDropId];
    public MusicConfig GetMusicConfig(MusicId musicId) => _musicConfigs[musicId];
    public SoundConfig GetSoundConfig(SoundId soundId) => _soundConfigs[soundId];
    public float GetInitialStat(StatId id) => _stats[id];
    public QuestConfig GetQuestConfig(QuestId questId) => _questConfigs[questId];
    public ExpirienceConfig GetExpirienceConfig() => _expirienceConfig;
    public Dictionary<QuestId, QuestConfig> GetQuestConfigs() => _questConfigs;
    public Dictionary<RewardId, RewardConfig> GetRewardConfigs() => _rewardConfigs;
    public Dictionary<WeaponTypeId, WeaponConfig> GetWeaponConfigs() => _weaponConfigs;
    public WeaponConfig GetWeaponConfig(WeaponTypeId weaponTypeId) => _weaponConfigs[weaponTypeId];

    public void LoadConfigs()
    {
      string startPath = _projectData.GameMode + "/";

      string playerConfigPath = startPath + "PlayerConfigs/PlayerConfig";
      string enemyConfigPath = startPath + "EnemyConfigs";
      string upgradeConfigPath = startPath + "UpgradeConfigs";
      string soundConfigPath = startPath + "SoundConfigs";
      string lootConfigPath = startPath + "LootConfigs";
      string musicConfigPath = startPath + "MusicConfigs";
      string questConfigPath = startPath + "QuestConfigs";
      string expirienceConfigPath = startPath + "ExpirienceConfigs/ExpirienceConfig";
      string rewardConfigPath = startPath + "RewardConfigs";
      string defaultProjectProgressConfigPath = startPath + "DefaultProjectProgressConfig/DefaultProjectProgressConfig";
      string weaponConfigPath = startPath + "WeaponConfigs";

      LoadEnemyConfigs(enemyConfigPath);
      LoadUpgradeConfigs(upgradeConfigPath);
      LoadLootConfigs(lootConfigPath);
      LoadMusicConfigs(musicConfigPath);
      LoadSoundConfigs(soundConfigPath);
      LoadInitialStats(playerConfigPath);
      LoadQuestConfigs(questConfigPath);
      LoadExpirienceConfig(expirienceConfigPath);
      LoadRewardConfigs(rewardConfigPath);
      LoadPlayerConfig(playerConfigPath);
      LoadDefaultProjectProgressConfig(defaultProjectProgressConfigPath);
      LoadWeaponConfigs(weaponConfigPath);
    }

    private void LoadWeaponConfigs(string weaponConfigPath)
    {
      _weaponConfigs = Resources
        .LoadAll<WeaponConfig>(weaponConfigPath)
        .ToDictionary(x => x.WeaponTypeId, x => x);
    }

    private void LoadDefaultProjectProgressConfig(string defaultProjectProgressConfigPath)
    {
      _defaultProjectProgressConfig = Resources
        .Load<DefaultProjectProgressConfig>(defaultProjectProgressConfigPath);
    }

    private void LoadExpirienceConfig(string expirienceConfigPath)
    {
      _expirienceConfig = Resources.Load<ExpirienceConfig>(expirienceConfigPath);
    }

    private void LoadPlayerConfig(string playerConfigPath)
    {
      _playerConfig = Resources
        .Load<PlayerConfig>(playerConfigPath);
    }

    private void LoadRewardConfigs(string rewardConfigPath)
    {
      _rewardConfigs = Resources
        .LoadAll<RewardConfig>(rewardConfigPath)
        .ToDictionary(x => x.Id, x => x);
    }

    private void LoadQuestConfigs(string questConfigPath)
    {
      _questConfigs = Resources
        .LoadAll<QuestConfig>(questConfigPath)
        .ToDictionary(x => x.Id, x => x);
    }

    private void LoadInitialStats(string playerConfigPath)
    {
      List<StatSetup> stats = Resources.Load<PlayerConfig>(playerConfigPath).Stats;

      _stats = new Dictionary<StatId, float>();

      foreach (StatSetup stat in stats)
        _stats.Add(stat.StatId, stat.Value);
    }

    private void LoadUpgradeConfigs(string upgradeConfigPath)
    {
      _upgradeConfigs = Resources
        .LoadAll<UpgradeConfig>(upgradeConfigPath)
        .ToDictionary(x => x.Id, x => x);
    }

    private void LoadEnemyConfigs(string enemyConfigPath)
    {
      _enemyConfigs = Resources
        .LoadAll<EnemyConfig>(enemyConfigPath)
        .ToDictionary(x => x.Id, x => x);
    }

    private void LoadLootConfigs(string lootConfigPath)
    {
      _lootConfigs = Resources
        .LoadAll<LootConfig>(lootConfigPath)
        .ToDictionary(x => x.Id, x => x);
    }

    private void LoadMusicConfigs(string musicConfigPath)
    {
      _musicConfigs = Resources
        .LoadAll<MusicConfig>(musicConfigPath)
        .ToDictionary(x => x.Id, x => x);
    }

    private void LoadSoundConfigs(string soundConfigPath)
    {
      _soundConfigs = Resources
        .LoadAll<SoundConfig>(soundConfigPath)
        .ToDictionary(x => x.Id, x => x);
    }
  }
}