using System.Collections.Generic;
using System.Linq;
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
    private Dictionary<StatId, float> _stats;
    private Dictionary<EnemyId, EnemyConfig> _enemyConfigs;
    private Dictionary<StatId, UpgradeConfig> _upgradeConfigs;
    private Dictionary<CurrencyId, LootConfig> _lootConfigs;
    private Dictionary<MusicId, MusicConfig> _musicConfigs;
    private Dictionary<SoundId, SoundConfig> _soundConfigs;
    private Dictionary<QuestId, QuestConfig> _questConfigs;
    private Dictionary<RewardId, RewardConfig> _rewardConfigs;
    private Dictionary<WeaponTypeId, WeaponConfig> _weaponConfigs;
    private Dictionary<GrenadeTypeId, GrenadeConfig> _grenadeConfigs;

    public StaticDataService(ProjectData projectData)
    {
      _projectData = projectData;
      _stats = new Dictionary<StatId, float>();
    }

    public Dictionary<StatId, UpgradeConfig> GetUpgradeConfigs() => _upgradeConfigs;
    public Dictionary<QuestId, QuestConfig> GetQuestConfigs() => _questConfigs;
    public Dictionary<RewardId, RewardConfig> GetRewardConfigs() => _rewardConfigs;

    public PlayerConfig GetPlayerConfig() => _playerConfig;
    public DefaultProjectProgressConfig GetDefaultProjectProgressConfig() => _defaultProjectProgressConfig;
    public EnemyConfig GetEnemyConfig(EnemyId enemyId) => _enemyConfigs[enemyId];
    public UpgradeConfig GetUpgradeConfig(StatId id) => _upgradeConfigs[id];
    public LootConfig GetLootConfig(CurrencyId lootDropId) => _lootConfigs[lootDropId];
    public MusicConfig GetMusicConfig(MusicId musicId) => _musicConfigs[musicId];
    public SoundConfig GetSoundConfig(SoundId soundId) => _soundConfigs[soundId];
    public float GetInitialStat(StatId id) => _stats[id];
    public QuestConfig GetQuestConfig(QuestId questId) => _questConfigs[questId];
    public ExpirienceConfig GetExpirienceConfig() => _expirienceConfig;
    public WeaponConfig GetWeaponConfig(WeaponTypeId weaponTypeId) => _weaponConfigs[weaponTypeId];
    public GrenadeConfig GetGrenadeConfig(GrenadeTypeId grenadeTypeId) => _grenadeConfigs[grenadeTypeId];

    public void LoadConfigs()
    {
      string startPath = _projectData.GameMode + "/";

      Resources.Load<PlayerConfig>(startPath + "PlayerConfigs/PlayerConfig").Stats.ToList().ForEach(stat => _stats.Add(stat.StatId, stat.Value));
      _enemyConfigs = Resources.LoadAll<EnemyConfig>(startPath + "EnemyConfigs").ToDictionary(x => x.Id, x => x);
      _upgradeConfigs = Resources.LoadAll<UpgradeConfig>(startPath + "UpgradeConfigs").ToDictionary(x => x.Id, x => x);
      _lootConfigs = Resources.LoadAll<LootConfig>(startPath + "LootConfigs").ToDictionary(x => x.Id, x => x);
      _musicConfigs = Resources.LoadAll<MusicConfig>(startPath + "MusicConfigs").ToDictionary(x => x.Id, x => x);
      _soundConfigs = Resources.LoadAll<SoundConfig>(startPath + "SoundConfigs").ToDictionary(x => x.Id, x => x);
      _questConfigs = Resources.LoadAll<QuestConfig>(startPath + "QuestConfigs").ToDictionary(x => x.Id, x => x);
      _expirienceConfig = Resources.Load<ExpirienceConfig>(startPath + "ExpirienceConfigs/ExpirienceConfig");
      _rewardConfigs = Resources.LoadAll<RewardConfig>(startPath + "RewardConfigs").ToDictionary(x => x.Id, x => x);
      _playerConfig = Resources.Load<PlayerConfig>(startPath + "PlayerConfigs/PlayerConfig");
      _defaultProjectProgressConfig = Resources.Load<DefaultProjectProgressConfig>(startPath + "DefaultProjectProgressConfig/DefaultProjectProgressConfig");
      _weaponConfigs = Resources.LoadAll<WeaponConfig>(startPath + "WeaponConfigs").ToDictionary(x => x.WeaponTypeId, x => x);
      _grenadeConfigs = Resources.LoadAll<GrenadeConfig>(startPath + "GrenadeConfigs").ToDictionary(x => x.TypeId, x => x);
    }
  }
}