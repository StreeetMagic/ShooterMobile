using System.Collections.Generic;
using AssetProviders;
using CurrencyRepositories;
using CurrencyRepositories.BackpackStorages;
using StaticDataServices;
using UnityEngine;
using ZenjectFactories;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces.LootSlots
{
  public class EnemyLootSlotFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly IStaticDataService _staticDataService;

    public EnemyLootSlotFactory(IAssetProvider assetProvider, GameLoopZenjectFactory factory,
      IStaticDataService staticDataService)
    {
      _assetProvider = assetProvider;
      _factory = factory;
      _staticDataService = staticDataService;
    }

    public void Create(Transform parent, EnemyId id)
    {
      var prefab = _assetProvider.Get<EnemyLootSlot>();
      EnemyConfig enemyConfig = _staticDataService.GetEnemyConfig(id);

      Dictionary<CurrencyId, int> lootData = new();

      List<LootDrop> list = enemyConfig.LootDrops;

      foreach (LootDrop item in list)
      {
        List<Loot> loots = _staticDataService.GetLootConfig(item.Id).Loots;
        int itemLevel = item.Level - 1;

        int count = loots[itemLevel].Value;
        lootData.Add(item.Id, count);
      }

      foreach (KeyValuePair<CurrencyId, int> item in lootData)
      {
        EnemyLootSlot slot = _factory.InstantiateMono(prefab, parent);
        Sprite sprite = _staticDataService.GetLootConfig(item.Key).Icon;

        slot.Init(sprite, item.Value);
      }
    }
  }
}