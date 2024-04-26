using System.Collections.Generic;
using Configs.Resources.CurrencyConfigs;
using Configs.Resources.EnemyConfigs.Scripts;
using DataRepositories.BackpackStorages;
using Infrastructure.AssetProviders;
using UnityEngine;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters.LootSlots;
using Zenject;

namespace UserInterface.HeadsUpDisplays.LootSlotsUpdaters
{
  public class LootSlotsUpdater : MonoBehaviour
  {
    private LootSlotFactory _lootSlotFactory;
    private BackpackStorage _backpackStorage;
    private IAssetProvider _assetProvider;

    public List<LootSlot> LootSlots = new();

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

      Dictionary<CurrencyId, int> info = _backpackStorage.ReadLoot();

      foreach (KeyValuePair<CurrencyId, int> loot in info)
        _lootSlotFactory.Create(loot.Key, Prefab, transform, loot.Value);
    }
  }
}