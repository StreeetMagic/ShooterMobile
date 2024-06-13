using System.Collections.Generic;
using System.Linq;
using Gameplay.CurrencyRepositories;
using Gameplay.Loots;
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

    public Sprite GetLootSprite(CurrencyId id) => _lootSprites[id].Sprite;
    public UpgradeContentSetup GetUpgradeContentSetup(StatId id) => _upgradeContentConfigs[id];

    public void LoadConfigs()
    {
      _lootSprites = _assetProvider.GetConfig<LootIconsConfig>().Setups.ToDictionary(x => x.Id, x => new LootSpriteSetup(x.Id, x.Sprite));
      _upgradeContentConfigs = _assetProvider.GetConfig<UpgradeContentConfig>().Setups.ToDictionary(x => x.Id, x => x); 
    }
  }
}