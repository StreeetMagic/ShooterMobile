using System.Collections.Generic;
using Configs.Resources.CurrencyConfigs;
using Configs.Resources.EnemyConfigs.Scripts;
using Infrastructure.AssetProviders;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;

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
        int count = _staticDataService.GetLootConfig(item.Id).Loots[item.Level - 1].Value;
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