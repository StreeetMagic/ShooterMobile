using Gameplay.CurrencyRepositories;
using Infrastructure.ArtConfigServices;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters.LootSlots;
using Zenject;

namespace UserInterface.HeadsUpDisplays.LootSlotsUpdaters
{
  public class LootSlotFactory
  {
    private GameLoopZenjectFactory _factory;
    private HeadsUpDisplayProvider _headsUpDisplayProvider;
    private ArtConfigProvider _artConfigProvider;

    [Inject]
    public void Construct(GameLoopZenjectFactory factory,
      HeadsUpDisplayProvider headsUpDisplayProvider, ArtConfigProvider configProvider)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _artConfigProvider = configProvider;
    }

    private LootSlotsUpdater LootSlotsUpdater => _headsUpDisplayProvider.LootSlotsUpdater;

    public void Create(CurrencyId id, LootSlot prefab, Transform parent, int lootValue)
    {
      var slot = _factory.InstantiateMono(prefab, parent);
      LootSlotsUpdater.LootSlots.Add(slot);

      Sprite icon = _artConfigProvider.GetLootContentSetup(id).Sprite;

      slot.Init(icon, lootValue);
    }
  }
}