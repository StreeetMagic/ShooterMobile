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
using Infrastructure.AssetProviders;
using Infrastructure.PersistentProgresses;
using Infrastructure.Projects;
using UnityEngine;

namespace Infrastructure.ConfigServices
{
  public class ConfigService
  {
    private readonly ProjectData _projectData;
    private readonly AssetProvider _assetProvider;

    private Dictionary<EnemyTypeId, EnemyConfig> _enemyConfigs;
    private Dictionary<CurrencyId, LootConfig> _lootConfigs;
    private Dictionary<WeaponTypeId, WeaponConfig> _weaponConfigs;
    private Dictionary<GrenadeTypeId, GrenadeConfig> _grenadeConfigs;

    public ConfigService(ProjectData projectData, AssetProvider assetProvider)
    {
      _projectData = projectData;
      _assetProvider = assetProvider;
    }
    
    public PlayerConfig PlayerConfig { get; private set; }
    public ExpirienceConfig ExpirienceConfig { get; private set; }
    public DefaultProjectProgressConfig DefaultProjectProgressConfig { get; private set; }

    public Dictionary<StatId, UpgradeConfig> UpgradeConfigs { get; private set; }
    public Dictionary<QuestId, QuestConfig> QuestConfigs { get; private set; }
    public Dictionary<RewardId, RewardConfig> RewardConfigs { get; private set; }

    public EnemyConfig GetEnemyConfig(EnemyTypeId enemyId) => _enemyConfigs[enemyId];
    public UpgradeConfig GetUpgradeConfig(StatId id) => UpgradeConfigs[id];
    public LootConfig GetLootConfig(CurrencyId lootDropId) => _lootConfigs[lootDropId];
    public QuestConfig GetQuestConfig(QuestId questId) => QuestConfigs[questId];
    public WeaponConfig GetWeaponConfig(WeaponTypeId weaponTypeId) => _weaponConfigs[weaponTypeId];
    public GrenadeConfig GetGrenadeConfig(GrenadeTypeId grenadeTypeId) => _grenadeConfigs[grenadeTypeId];

    public void LoadConfigs()
    {
      string startPath = _projectData.GameMode + "/";

      _enemyConfigs = _assetProvider.GetAllScriptable<EnemyConfig>(startPath + "EnemyConfigs").ToDictionary(x => x.Id, x => x);
      _lootConfigs = _assetProvider.GetAllScriptable<LootConfig>(startPath + "LootConfigs").ToDictionary(x => x.Id, x => x);
      _weaponConfigs = _assetProvider.GetAllScriptable<WeaponConfig>(startPath + "WeaponConfigs").ToDictionary(x => x.WeaponTypeId, x => x);
      _grenadeConfigs = _assetProvider.GetAllScriptable<GrenadeConfig>(startPath + "GrenadeConfigs").ToDictionary(x => x.TypeId, x => x);
     
      PlayerConfig = _assetProvider.GetScriptable<PlayerConfig>(startPath + "PlayerConfigs/PlayerConfig");
      ExpirienceConfig = _assetProvider.GetScriptable<ExpirienceConfig>(startPath + "ExpirienceConfigs/ExpirienceConfig");
      DefaultProjectProgressConfig = _assetProvider.GetScriptable<DefaultProjectProgressConfig>(startPath + "DefaultProjectProgressConfig/DefaultProjectProgressConfig");
      
      UpgradeConfigs = _assetProvider.GetAllScriptable<UpgradeConfig>(startPath + "UpgradeConfigs").ToDictionary(x => x.Id, x => x);
      QuestConfigs = _assetProvider.GetAllScriptable<QuestConfig>(startPath + "QuestConfigs").ToDictionary(x => x.Id, x => x);
      RewardConfigs = _assetProvider.GetAllScriptable<RewardConfig>(startPath + "RewardConfigs").ToDictionary(x => x.Id, x => x);
    }
  }
}