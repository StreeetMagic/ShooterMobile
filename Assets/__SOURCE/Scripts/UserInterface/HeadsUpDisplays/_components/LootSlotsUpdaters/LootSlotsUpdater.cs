using System.Collections.Generic;
using CurrencyRepositories;
using CurrencyRepositories.BackpackStorages;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Loots;
using UnityEngine;
using UserInterface.HeadsUpDisplays._components.LootSlotsUpdaters.LootSlots;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.LootSlotsUpdaters
{
  public class LootSlotsUpdater : MonoBehaviour
  {
    public List<LootSlot> LootSlots = new();

    [Inject] private LootSlotFactory _lootSlotFactory;
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private AssetProvider _assetProvider;
    [Inject] private ArtConfigProvider _artConfigProvider;

    private LootSlot Prefab =>
      _artConfigProvider.GetPrefab(PrefabId.LootSlot).GetComponent<LootSlot>();
    
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

      Dictionary<CurrencyId, int> info = _backpackStorage.ReadLoot();

      foreach (KeyValuePair<CurrencyId, int> loot in info)
        _lootSlotFactory.Create(loot.Key, Prefab, transform, loot.Value);
    }
  }
}