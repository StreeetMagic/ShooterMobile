using System.Collections.Generic;
using System.Linq;
using Gameplay.CurrencyRepositories;
using Gameplay.Loots;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Infrastructure.AssetProviders;
using UnityEngine;

namespace Infrastructure.ArtConfigServices
{
  public class ArtConfigService
  {
    private readonly AssetProvider _assetProvider;

    public ArtConfigService(AssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    private Dictionary<CurrencyId, LootSpriteSetup> _lootSprites;
    private Dictionary<StatId, UpgradeContentSetup> _upgradeContentConfigs;
    private Dictionary<QuestId, QuestContentSetup> _questContentConfigs;
    private Dictionary<SubQuestId, SubQuestContentSetup> _subQuestContentConfigs;

    public Sprite GetLootSprite(CurrencyId id) => _lootSprites[id].Sprite;
    public UpgradeContentSetup GetUpgradeContentSetup(StatId id) => _upgradeContentConfigs[id];
    public QuestContentSetup GetQuestContentSetup(QuestId questId) => _questContentConfigs[questId];
    public SubQuestContentSetup GetSubQuestContentSetup(SubQuestId id) => _subQuestContentConfigs[id];

    public void LoadConfigs()
    {
      _lootSprites = _assetProvider.GetConfig<LootIconsConfig>().Setups.ToDictionary(x => x.Id, x => new LootSpriteSetup(x.Id, x.Sprite));
      _upgradeContentConfigs = _assetProvider.GetConfig<UpgradeContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
      _questContentConfigs = _assetProvider.GetConfig<QuestContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
      _subQuestContentConfigs = _assetProvider.GetConfig<SubQuestContentConfig>().Setups.ToDictionary(x => x.Id, x => x);
    }
  }
}