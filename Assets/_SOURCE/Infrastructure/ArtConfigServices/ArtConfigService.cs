using System.Collections.Generic;
using System.Linq;
using Gameplay.CurrencyRepositories;
using Gameplay.Loots;
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

    public Sprite GetLootSprite(CurrencyId id) => _lootSprites[id].Sprite;

    public void LoadConfigs()
    {
      LootIconsConfig lootIconsConfig = _assetProvider.GetConfig<LootIconsConfig>();

      _lootSprites = lootIconsConfig.Sprites.ToDictionary(x => x.Id, x => new LootSpriteSetup(x.Id, x.Sprite));
    }
  }
}