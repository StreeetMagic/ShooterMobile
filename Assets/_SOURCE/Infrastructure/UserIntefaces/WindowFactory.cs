﻿using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;

namespace Infrastructure.UserIntefaces
{
  public class WindowFactory
  {
    private readonly IZenjectFactory _factory;
    private readonly HeadsUpDisplayProvider _headsUpDisplayProvider;

    public WindowFactory(IZenjectFactory factory, HeadsUpDisplayProvider headsUpDisplayProvider)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
    }

    public void Create(WindowId windowId)
    {
      switch (windowId)
      {
        case WindowId.Unknown:
          break;

        case WindowId.UpgradeShop:
          Transform transform = _headsUpDisplayProvider.HeadsUpDisplay.GetComponentInChildren<Canvas>().transform;
          _factory.Instantiate<UpgradeShopWindow>(transform);
          break;
        
        case WindowId.Debug:
          Transform debugTransform = _headsUpDisplayProvider.HeadsUpDisplay.GetComponentInChildren<Canvas>().transform;
          _factory.Instantiate<DebugWindow>(debugTransform);
          break;
      }
    }
  }
}