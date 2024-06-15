using System.Collections.Generic;
using Gameplay.CurrencyRepositories;
using Gameplay.Loots;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.ConfigServices;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces.LootSlots
{
  public class EnemyLootSlotFactory
  {
    private readonly AssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly ArtConfigService _artConfigService;
    private readonly ConfigService _configService;

    public EnemyLootSlotFactory(AssetProvider assetProvider, GameLoopZenjectFactory factory, ArtConfigService artConfigService, ConfigService configService)
    {
      _assetProvider = assetProvider;
      _factory = factory;
      _configService = configService;
      _artConfigService = artConfigService;
    }

    public void Create(Transform parent, EnemyTypeId id)
    {
      var prefab = _assetProvider.Get<EnemyLootSlot>();
      EnemyConfig enemyConfig = _configService.GetEnemyConfig(id);

      Dictionary<CurrencyId, int> lootData = new();

      List<LootDrop> list = enemyConfig.LootDrops;

      foreach (LootDrop item in list)
      {
        List<Loot> loots = _configService.GetLootConfig(item.Id).Loots;
        int itemLevel = item.Level - 1;

        int count = loots[itemLevel].Value;
        lootData.Add(item.Id, count);
      }

      foreach (KeyValuePair<CurrencyId, int> item in lootData)
      {
        EnemyLootSlot slot = _factory.InstantiateMono(prefab, parent);
        Sprite sprite = _artConfigService.GetLootContentSetup(item.Key).Sprite;

        slot.Init(sprite, item.Value);
      }
    }
  }
}