using Gameplay.CurrencyRepositories;
using Infrastructure.ArtConfigServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters.LootSlots;
using Zenject;

namespace UserInterface.HeadsUpDisplays.LootSlotsUpdaters
{
  public class LootSlotFactory
  {
    private GameLoopZenjectFactory _factory;
    private HeadsUpDisplayProvider _headsUpDisplayProvider;
    private ArtConfigService _artConfigService;

    [Inject]
    public void Construct(GameLoopZenjectFactory factory,
      HeadsUpDisplayProvider headsUpDisplayProvider, ArtConfigService configService)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _artConfigService = configService;
    }

    private LootSlotsUpdater LootSlotsUpdater => _headsUpDisplayProvider.LootSlotsUpdater;

    public void Create(CurrencyId id, LootSlot prefab, Transform parent, int lootValue)
    {
      var slot = _factory.InstantiateMono(prefab, parent);
      LootSlotsUpdater.LootSlots.Add(slot);

      Sprite icon = _artConfigService.GetLootSprite(id);

      slot.Init(icon, lootValue);
    }
  }
}