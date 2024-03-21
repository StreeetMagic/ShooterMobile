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
  private ZenjectFactory _factory;
  private HeadsUpDisplayProvider _headsUpDisplayProvider;
  private IStaticDataService _staticDataService;
  
  [Inject]
  public void Construct(ZenjectFactory factory, HeadsUpDisplayProvider headsUpDisplayProvider, IStaticDataService staticDataService)
  {
    _factory = factory;
    _headsUpDisplayProvider = headsUpDisplayProvider;
    _staticDataService = staticDataService;
  }

  private LootSlotsUpdater LootSlotsUpdater => _headsUpDisplayProvider.LootSlotsUpdater;
  
  
  public void Create(CurrencyId id, LootSlot prefab, Transform parent, int lootValue)
  {
    var slot = _factory.Instantiate(prefab, parent);
    LootSlotsUpdater.LootSlots.Add(slot);
    
    Sprite icon = _staticDataService.GetLootConfig(id).Icon;
    
    slot.Init(icon, lootValue);
  }
}