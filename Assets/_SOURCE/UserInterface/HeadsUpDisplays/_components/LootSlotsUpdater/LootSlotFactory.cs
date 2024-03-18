using System.Collections;
using System.Collections.Generic;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

public class LootSlotFactory
{
  private IZenjectFactory _factory;
  private HeadsUpDisplayProvider _headsUpDisplayProvider;
  private IStaticDataService _staticDataService;
  
  [Inject]
  public void Construct(IZenjectFactory factory, HeadsUpDisplayProvider headsUpDisplayProvider, IStaticDataService staticDataService)
  {
    _factory = factory;
    _headsUpDisplayProvider = headsUpDisplayProvider;
    _staticDataService = staticDataService;
  }

  private LootSlotsUpdater LootSlotsUpdater => _headsUpDisplayProvider.LootSlotsUpdater;
  
  
  public void Create(LootDrop loot, LootSlot prefab, Transform parent, int lootValue)
  {
    var slot = _factory.Instantiate(prefab, parent);
    LootSlotsUpdater.LootSlots.Add(slot);
    
    Sprite icon = _staticDataService.GetLootConfig(loot.Id).Icon;
    
    slot.Init(icon, lootValue);
  }
}