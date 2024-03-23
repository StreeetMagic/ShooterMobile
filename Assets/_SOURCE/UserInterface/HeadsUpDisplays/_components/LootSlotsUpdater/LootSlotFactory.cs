using System.Collections;
using System.Collections.Generic;
using Gameplay.Currencies;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

public class LootSlotFactory
{
  private GameLoopZenjectFactory _factory;
  private HeadsUpDisplayProvider _headsUpDisplayProvider;
  private IStaticDataService _staticDataService;
  
  [Inject]
  public void Construct(GameLoopZenjectFactory factory, HeadsUpDisplayProvider headsUpDisplayProvider, IStaticDataService staticDataService)
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