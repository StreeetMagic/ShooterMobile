using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Configs;
using Gameplay.CurrencyRepositories;
using Gameplay.Loots;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using Gameplay.Rewards;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Gameplay.Weapons;
using Infrastructure.AssetProviders;
using Infrastructure.VisualEffects;

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

    public EnemyCommonVisualsConfig EnemyCommonVisualsConfig { get; private set; }

    public LootContentSetup GetLootContentSetup(CurrencyId id) => _loots[id];
    public UpgradeContentSetup GetUpgradeContentSetup(StatId id) => _upgrades[id];
    public QuestContentSetup GetQuestContentSetup(QuestId questId) => _quests[questId];
    public SubQuestContentSetup GetSubQuestContentSetup(SubQuestId id) => _subQuests[id];
    public WeaponContentSetup GetWeaponContentSetup(WeaponTypeId id) => _weapons[id];
    public RewardContentSetup GetRewardContentSetup(RewardId id) => _rewards[id];
    
    public VisualEffectId GetMuzzleFlashEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).MuzzleFlashId;
    public VisualEffectId GetBulletEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).Bullet;
    public VisualEffectId GetImpactEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).Impact;
    public VisualEffectId GetPanicEffectId(EnemyTypeId id) => GetEnemyVisualEffectsSetup(GetEnemyVisualEffectsSetupId(id)).Panic;
    
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
    }
  }
}