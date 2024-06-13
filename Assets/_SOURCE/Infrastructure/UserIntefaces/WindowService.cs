using System;
using Gameplay.Quests;
using Infrastructure.ConfigServices;
using Infrastructure.ZenjectFactories;
using Loggers;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.Windows.DebugWindows;
using UserInterface.HeadsUpDisplays.Windows.QuestWindows;
using UserInterface.HeadsUpDisplays.Windows.SettingsWindows;
using UserInterface.HeadsUpDisplays.Windows.Shops.HenShopWindows;
using UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows;
using Object = UnityEngine.Object;

namespace Infrastructure.UserIntefaces
{
  public class WindowService
  {
    private Window _activeWindow;

    private readonly GameLoopZenjectFactory _factory;
    private readonly HeadsUpDisplayProvider _headsUpDisplayProvider;
    private readonly QuestStorage _storage;
    private readonly DebugLogger _logger;
    private readonly QuestWindow.Factory _questWindowFactory;
    private readonly ConfigService _configService;

    public WindowService(GameLoopZenjectFactory factory,
      HeadsUpDisplayProvider headsUpDisplayProvider, QuestStorage storage,
      QuestWindow.Factory questWindowFactory, ConfigService configService)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _storage = storage;
      _questWindowFactory = questWindowFactory;
      _configService = configService;
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
          if (questId == QuestId.Unknown)
            throw new ArgumentOutOfRangeException(nameof(questId), questId, null);

          Quest quest = _storage.GetQuest(questId);
          QuestConfig config = _configService.GetQuestConfig(questId);

          QuestWindow questWindow = _questWindowFactory.Create(quest, config);

          questWindow.transform.SetParent(HudTransform, false);
          questWindow.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
          window = questWindow;
          break;

        case WindowId.HenShop:
          window = _factory.InstantiateMono<HenShopWindow>(HudTransform);
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(windowId), windowId, null);
      }

      _activeWindow = window;

      return window;
    }
  }
}