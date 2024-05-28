using CurrencyRepositories;
using StaticDataServices;
using UnityEngine;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters.LootSlots;
using Zenject;
using ZenjectFactories;

namespace UserInterface.HeadsUpDisplays.LootSlotsUpdaters
{
  public class LootSlotFactory
  {
    private GameLoopZenjectFactory _factory;
    private HeadsUpDisplayProvider _headsUpDisplayProvider;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(GameLoopZenjectFactory factory,
      HeadsUpDisplayProvider headsUpDisplayProvider, IStaticDataService staticDataService)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _staticDataService = staticDataService;
    }

    private LootSlotsUpdater LootSlotsUpdater => _headsUpDisplayProvider.LootSlotsUpdater;

    public void Create(CurrencyId id, LootSlot prefab, Transform parent, int lootValue)
    {
      var slot = _factory.InstantiateMono(prefab, parent);
      LootSlotsUpdater.LootSlots.Add(slot);

      Sprite icon = _staticDataService.GetLootConfig(id).Icon;

      slot.Init(icon, lootValue);
    }
  }
}