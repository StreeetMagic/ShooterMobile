using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.QuestWindows;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;

namespace Infrastructure.UserIntefaces
{
  public class WindowFactory
  {
    private readonly GameLoopZenjectFactory _factory;
    private readonly HeadsUpDisplayProvider _headsUpDisplayProvider;

    public WindowFactory(GameLoopZenjectFactory factory, HeadsUpDisplayProvider headsUpDisplayProvider)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
    }

    private Transform HudTransform => _headsUpDisplayProvider.HeadsUpDisplay.GetComponentInChildren<Canvas>().transform;

    public void Create(WindowId windowId)
    {
      switch (windowId)
      {
        case WindowId.Unknown:
          break;

        case WindowId.UpgradeShop:
          _factory.InstantiateMono<UpgradeShopWindow>(HudTransform);
          break;
        
        case WindowId.Debug:
          _factory.InstantiateMono<DebugWindow>(HudTransform);
          break;
        
        case WindowId.Settings:
          _factory.InstantiateMono<SettingsWindow>(HudTransform);
          break;
        
        case WindowId.Quest:
          _factory.InstantiateMono<QuestWindow>(HudTransform);
          break;
      }
    }
  }
}