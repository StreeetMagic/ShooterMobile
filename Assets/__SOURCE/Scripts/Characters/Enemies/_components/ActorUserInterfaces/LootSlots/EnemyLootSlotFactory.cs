using System.Collections.Generic;
using Characters.Enemies.Configs;
using CurrencyRepositories;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.ConfigProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using Loots;
using UnityEngine;

namespace Characters.Enemies._components.ActorUserInterfaces.LootSlots
{
  public class EnemyLootSlotFactory
  {
    private readonly AssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly ArtConfigProvider _artConfigProvider;
    private readonly ConfigProvider _configProvider;

    public EnemyLootSlotFactory(AssetProvider assetProvider, GameLoopZenjectFactory factory, ArtConfigProvider artConfigProvider, ConfigProvider configProvider)
    {
      _assetProvider = assetProvider;
      _factory = factory;
      _configProvider = configProvider;
      _artConfigProvider = artConfigProvider;
    }

    public void Create(Transform parent, EnemyTypeId id)
    {
      //var prefab = _assetProvider.Get<EnemyLootSlot>();
      EnemyConfig enemyConfig = _configProvider.GetEnemyConfig(id);

      Dictionary<CurrencyId, int> lootData = new();

      List<LootDrop> list = enemyConfig.LootDrops;

      foreach (LootDrop item in list)
      {
        List<Loot> loots = _configProvider.GetLootConfig(item.Id).Loots;
        int itemLevel = item.Level - 1;

        int count = loots[itemLevel].Value;
        lootData.Add(item.Id, count);
      }

      foreach (KeyValuePair<CurrencyId, int> item in lootData)
      {
        // EnemyLootSlot slot = _factory.InstantiateMono(prefab, parent);
        EnemyLootSlot slot = _factory.InstantiateGameObject(PrefabId.EnemyLootSlot, parent).GetComponent<EnemyLootSlot>();
        Sprite sprite = _artConfigProvider.GetLootContentSetup(item.Key).Sprite;

        slot.Init(sprite, item.Value);
      }
    }
  }
}