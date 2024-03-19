using System;
using System.Collections.Generic;
using Gameplay.Currencies;
using Infrastructure.AssetProviders;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

public class LootSlotsUpdater : MonoBehaviour
{
  private LootSlotFactory _lootSlotFactory;
  private BackpackStorage _backpackStorage;
  private IAssetProvider _assetProvider;

  public List<LootSlot> LootSlots = new List<LootSlot>();

  [Inject]
  public void Construct(LootSlotFactory lootSlotFactory, BackpackStorage backpackStorage, IAssetProvider assetProvider)
  {
    _lootSlotFactory = lootSlotFactory;
    _backpackStorage = backpackStorage;
    _assetProvider = assetProvider;
  }

  private LootSlot Prefab => _assetProvider.Get<LootSlot>();

  private void OnEnable()
  {
    _backpackStorage.LootDrops.Changed += OnLootDropsChanged;
  }

  private void OnDisable()
  {
    _backpackStorage.LootDrops.Changed -= OnLootDropsChanged;
  }

  private void OnLootDropsChanged(List<LootDrop> list)
  {
    foreach (LootSlot loot in LootSlots)
      Destroy(loot.gameObject);

    LootSlots.Clear();

    var info = _backpackStorage.ReadLoot();

    foreach (var loot in info)
      _lootSlotFactory.Create(loot.Key, Prefab, transform, loot.Value);
  }
}