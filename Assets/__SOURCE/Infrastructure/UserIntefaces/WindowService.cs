using System;
using Gameplay.Quests;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
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

    public WindowService(GameLoopZenjectFactory factory,
      HeadsUpDisplayProvider headsUpDisplayProvider, QuestStorage storage,
      QuestWindow.Factory questWindowFactory)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _storage = storage;
      _questWindowFactory = questWindowFactory;
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
          window = _factory.InstantiateGameObject(PrefabId.UpgradeShopWindow, HudTransform).GetComponent<Window>();
          break;

        case WindowId.Debug:
          window = _factory.InstantiateGameObject(PrefabId.DebugWindow, HudTransform).GetComponent<Window>();
          break;

        case WindowId.Settings:
          window = _factory.InstantiateGameObject(PrefabId.SettingsWindow, HudTransform).GetComponent<Window>();
          break;

        case WindowId.Quest:
          if (questId == QuestId.Unknown)
            throw new ArgumentOutOfRangeException(nameof(questId), questId, null);

          Quest quest = _storage.GetQuest(questId);

          QuestWindow questWindow = _questWindowFactory.Create(quest, questId);

          questWindow.transform.SetParent(HudTransform, false);
          questWindow.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
          window = questWindow;
          break;

        case WindowId.HenShop:
          // window = _factory.InstantiateMono<HenShopWindow>(HudTransform);
          window = _factory.InstantiateGameObject(PrefabId.HenShopWindow, HudTransform).GetComponent<Window>();
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(windowId), windowId, null);
      }

      _activeWindow = window;

      return window;
    }
  }
}