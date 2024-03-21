using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies;
using Gameplay.Currencies;
using Infrastructure.AssetProviders;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;

public class EnemyLootSlotFactory
{
  private IAssetProvider _assetProvider;
  private ZenjectFactory _factory;
  private IStaticDataService _staticDataService;

  public EnemyLootSlotFactory(IAssetProvider assetProvider, ZenjectFactory factory,
    IStaticDataService staticDataService)
  {
    _assetProvider = assetProvider;
    _factory = factory;
    _staticDataService = staticDataService;
  }

  public void Create(Transform parent, EnemyId id)
  {
    var prefab = _assetProvider.Get<EnemyLootSlot>();
    EnemyConfig enemyConfig = _staticDataService.ForEnemy(id);

    Dictionary<CurrencyId, int> lootData = new();

    var list = enemyConfig.LootDrops;

    foreach (var item in list)
    {
      int count = _staticDataService.GetLootConfig(item.Id).Loots[item.Level - 1].Value;
      lootData.Add(item.Id, count);
    }

    foreach (var item in lootData)
    {
      var slot = _factory.Instantiate<EnemyLootSlot>(prefab, parent);
      Sprite sprite = _staticDataService.GetLootConfig(item.Key).Icon;

      slot.Init(sprite, item.Value);
    }
  }
}