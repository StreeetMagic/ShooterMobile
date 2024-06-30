using System.Collections.Generic;
using System.Linq;
using Characters.Enemies;
using Characters.Enemies.Configs;
using CurrencyRepositories;
using Infrastructure.AssetProviders;
using Infrastructure.VisualEffects;
using Loots;
using Quests;
using Quests.Subquests;
using Rewards;
using Stats;
using UnityEngine;
using Upgrades;
using Weapons;

namespace Infrastructure.ArtConfigServices
{
  public class ArtConfigProvider
  {
    private readonly AssetProvider _assetProvider;

    public ArtConfigProvider(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    private Dictionary<CurrencyId, LootContentSetup> _loots;
    private Dictionary<StatId, UpgradeContentSetup> _upgrades;
    private Dictionary<QuestId, QuestContentSetup> _quests;
    private Dictionary<SubQuestId, SubQuestContentSetup> _subQuests;
    private Dictionary<WeaponTypeId, WeaponContentSetup> _weapons;
    private Dictionary<RewardId, RewardContentSetup> _rewards;
    private Dictionary<EnemyTypeId, EnemyVisualEffectsSetupId> _enemyTypeVisualEffectsSetups;
    private Dictionary<EnemyVisualEffectsSetupId, EnemyVisualEffectsSetup> _enemyVisualEffectsSetups;
    private Dictionary<EnemyTypeId, EnemyTypeVisualEffectsSetup> _enemyTypeVisualEffects; 
    private Dictionary<PrefabId, GameObject> _prefabs;

    public EnemyCommonVisualsConfig EnemyCommonVisualsConfig { get; private set; }

    public LootContentSetup GetLootContentSetup(CurrencyId id) => _loots[id];
    public UpgradeContentSetup GetUpgradeContentSetup(StatId id) => _upgrades[id];
    public QuestContentSetup GetQuestContentSetup(QuestId questId) => _quests[questId];
    public SubQuestContentSetup GetSubQuestContentSetup(SubQuestId id) => _subQuests[id];
    public WeaponContentSetup GetWeaponContentSetup(WeaponTypeId id) => _weapons[id];
    public RewardContentSetup GetRewardContentSetup(RewardId id) => _rewards[id];
    public GameObject GetPrefab(PrefabId id) => _prefabs[id];

    public VisualEffectId GetEnemyMuzzleFlashEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).MuzzleFlashId;
    public VisualEffectId GetEnemyBulletEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).Bullet;
    public VisualEffectId GetEnemyImpactEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).Impact;
    public VisualEffectId GetEnemyPanicEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).Panic;

    public EnemyTypeVisualEffectsSetup GetEnemyTypeVisualEffectsSetup(EnemyTypeId id) => _enemyTypeVisualEffects[id];
    
    private EnemyVisualEffectsSetupId GetEnemyVisualEffectsSetupId(EnemyTypeId id) => _enemyTypeVisualEffectsSetups[id];
    private EnemyVisualEffectsSetup GetEnemyVisualEffectsSetup(EnemyVisualEffectsSetupId id) => _enemyVisualEffectsSetups[id];

    public void LoadConfigs()
    {
      EnemyCommonVisualsConfig =
        _assetProvider
          .GetScriptable<EnemyCommonVisualsConfig>();

      _loots =
        _assetProvider
          .GetScriptable<LootIconsConfig>()
          .Setups
          .ToDictionary(lootContentSetup => lootContentSetup.Id, lootContentSetup => lootContentSetup);

      _upgrades =
        _assetProvider
          .GetScriptable<UpgradeContentConfig>()
          .Setups
          .ToDictionary(upgradeContentSetup => upgradeContentSetup.Id, upgradeContentSetup => upgradeContentSetup);

      _quests =
        _assetProvider
          .GetScriptable<QuestContentConfig>()
          .Setups
          .ToDictionary(questContentSetup => questContentSetup.Id, questContentSetup => questContentSetup);

      _subQuests =
        _assetProvider
          .GetScriptable<SubQuestContentConfig>()
          .Setups
          .ToDictionary(subQuestContentSetup => subQuestContentSetup.Id, subQuestContentSetup => subQuestContentSetup);

      _weapons =
        _assetProvider
          .GetScriptable<WeaponContentConfig>()
          .Setups
          .ToDictionary(weaponContentSetup => weaponContentSetup.Id, weaponContentSetup => weaponContentSetup);

      _rewards =
        _assetProvider
          .GetScriptable<RewardContentConfig>()
          .Setups
          .ToDictionary(rewardContentSetup => rewardContentSetup.Id, rewardContentSetup => rewardContentSetup);

      _enemyTypeVisualEffectsSetups =
        _assetProvider
          .GetScriptable<EnemyTypeVisualEffectsConfig>()
          .VisualEffectsSetups
          .ToDictionary(enemyTypeVisualEffectsSetup => enemyTypeVisualEffectsSetup.EnemyId, enemyTypeVisualEffectsSetup => enemyTypeVisualEffectsSetup.VisualEffectsSetupId);

      _enemyVisualEffectsSetups =
        _assetProvider
          .GetScriptable<EnemyVisualEffctsSetupsConfig>()
          .VisualEffectsSetups
          .ToDictionary(enemyVisualEffectsSetup => enemyVisualEffectsSetup.SetupId, enemyVisualEffectsSetup => enemyVisualEffectsSetup);
      
      _enemyTypeVisualEffects =
        _assetProvider
          .GetScriptable<EnemyTypeVisualEffectsConfig>()
          .VisualEffectsSetups
          .ToDictionary(enemyTypeVisualEffectsSetup => enemyTypeVisualEffectsSetup.EnemyId, enemyTypeVisualEffectsSetup => enemyTypeVisualEffectsSetup);
      
      _prefabs =
        _assetProvider
          .GetScriptable<PrefabPathConfig>()
          .Prefabs
          .ToDictionary(prefabPathSetup => prefabPathSetup.Id, prefabPathSetup => prefabPathSetup.Prefab);
    }
  }
}