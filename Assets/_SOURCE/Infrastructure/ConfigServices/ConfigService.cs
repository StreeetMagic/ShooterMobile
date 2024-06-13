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
using Infrastructure.PersistentProgresses;
using Infrastructure.Projects;
using UnityEngine;

namespace Infrastructure.ConfigServices
{
  public class ConfigService
  {
    private readonly ProjectData _projectData;

    private readonly Dictionary<StatId, float> _stats = new();

    private Dictionary<EnemyTypeId, EnemyConfig> _enemyConfigs;
    private Dictionary<CurrencyId, LootConfig> _lootConfigs;
    private Dictionary<WeaponTypeId, WeaponConfig> _weaponConfigs;
    private Dictionary<GrenadeTypeId, GrenadeConfig> _grenadeConfigs;

    public ConfigService(ProjectData projectData)
    {
      _projectData = projectData;
    }

    public Dictionary<StatId, UpgradeConfig> UpgradeConfigs { get; private set; }
    public Dictionary<QuestId, QuestConfig> QuestConfigs { get; private set; }
    public Dictionary<RewardId, RewardConfig> RewardConfigs { get; private set; }
    public PlayerConfig PlayerConfig { get; private set; }
    public ExpirienceConfig ExpirienceConfig { get; private set; }
    public DefaultProjectProgressConfig DefaultProjectProgressConfig { get; private set; }

    public float GetInitialStat(StatId id) => _stats[id];
    
    public EnemyConfig GetEnemyConfig(EnemyTypeId enemyId) => _enemyConfigs[enemyId];
    public UpgradeConfig GetUpgradeConfig(StatId id) => UpgradeConfigs[id];
    public LootConfig GetLootConfig(CurrencyId lootDropId) => _lootConfigs[lootDropId];
    public QuestConfig GetQuestConfig(QuestId questId) => QuestConfigs[questId];
    public WeaponConfig GetWeaponConfig(WeaponTypeId weaponTypeId) => _weaponConfigs[weaponTypeId];
    public GrenadeConfig GetGrenadeConfig(GrenadeTypeId grenadeTypeId) => _grenadeConfigs[grenadeTypeId];

    public void LoadConfigs()
    {
      string startPath = _projectData.GameMode + "/";

      Resources.Load<PlayerConfig>(startPath + "PlayerConfigs/PlayerConfig").Stats.ToList().ForEach(stat => _stats.Add(stat.StatId, stat.Value));
      
      _enemyConfigs = Resources.LoadAll<EnemyConfig>(startPath + "EnemyConfigs").ToDictionary(x => x.Id, x => x);
      _lootConfigs = Resources.LoadAll<LootConfig>(startPath + "LootConfigs").ToDictionary(x => x.Id, x => x);
      _weaponConfigs = Resources.LoadAll<WeaponConfig>(startPath + "WeaponConfigs").ToDictionary(x => x.WeaponTypeId, x => x);
      _grenadeConfigs = Resources.LoadAll<GrenadeConfig>(startPath + "GrenadeConfigs").ToDictionary(x => x.TypeId, x => x);
     
      UpgradeConfigs = Resources.LoadAll<UpgradeConfig>(startPath + "UpgradeConfigs").ToDictionary(x => x.Id, x => x);
      QuestConfigs = Resources.LoadAll<QuestConfig>(startPath + "QuestConfigs").ToDictionary(x => x.Id, x => x);
      PlayerConfig = Resources.Load<PlayerConfig>(startPath + "PlayerConfigs/PlayerConfig");
      ExpirienceConfig = Resources.Load<ExpirienceConfig>(startPath + "ExpirienceConfigs/ExpirienceConfig");
      RewardConfigs = Resources.LoadAll<RewardConfig>(startPath + "RewardConfigs").ToDictionary(x => x.Id, x => x);
      DefaultProjectProgressConfig = Resources.Load<DefaultProjectProgressConfig>(startPath + "DefaultProjectProgressConfig/DefaultProjectProgressConfig");
    }
  }
}