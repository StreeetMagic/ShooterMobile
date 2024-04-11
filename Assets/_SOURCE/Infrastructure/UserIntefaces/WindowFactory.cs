using Configs.Resources.QuestConfigs;
using Infrastructure.StaticDataServices;
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
    private readonly IStaticDataService _staticDataService;

    public WindowFactory(GameLoopZenjectFactory factory,
      HeadsUpDisplayProvider headsUpDisplayProvider, IStaticDataService staticDataService)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _staticDataService = staticDataService;
    }

    private Transform HudTransform => _headsUpDisplayProvider.HeadsUpDisplay.GetComponentInChildren<Canvas>().transform;

    public void Create(WindowId windowId, QuestId questId = QuestId.Unknown)
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
          var window = _factory.InstantiateMono<QuestWindow>(HudTransform);
          QuestConfig config = _staticDataService.GetQuestConfig(questId);
          window.QuestConfig = config;
          break;
      }
    }
  }
}