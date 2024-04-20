using System;
using Configs.Resources.QuestConfigs;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using Loggers;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.QuestWindows;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;
using Object = UnityEngine.Object;

namespace Infrastructure.UserIntefaces
{
  public class WindowService
  {
    private Window _activeWindow;

    private readonly GameLoopZenjectFactory _factory;
    private readonly HeadsUpDisplayProvider _headsUpDisplayProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly QuestStorage _storage;
    private readonly DebugLogger _logger;

    public WindowService(GameLoopZenjectFactory factory,
      HeadsUpDisplayProvider headsUpDisplayProvider, IStaticDataService staticDataService,
      QuestStorage storage, DebugLogger logger)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _staticDataService = staticDataService;
      _storage = storage;
    }

    private Transform HudTransform => _headsUpDisplayProvider.HeadsUpDisplay.GetComponentInChildren<Canvas>().transform;

    public Window Create(WindowId windowId, QuestId questId = QuestId.Unknown)
    {
      if (_activeWindow != null)
        Object.Destroy(_activeWindow.gameObject);

      Window window;

      switch (windowId)
      {
        case WindowId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(windowId), windowId, null);

        case WindowId.UpgradeShop:
          window = _factory.InstantiateMono<UpgradeShopWindow>(HudTransform);
          break;

        case WindowId.Debug:
          window = _factory.InstantiateMono<DebugWindow>(HudTransform);
          break;

        case WindowId.Settings:
          window = _factory.InstantiateMono<SettingsWindow>(HudTransform);
          break;

        case WindowId.Quest:
          var questWindoww = _factory.InstantiateMono<QuestWindow>(HudTransform);
          QuestConfig config = _staticDataService.GetQuestConfig(questId);
          questWindoww.Quest = _storage.GetQuest(questId);
          window = questWindoww;
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(windowId), windowId, null);
      }
      
      _activeWindow = window;

      return window;
    }
  }
}