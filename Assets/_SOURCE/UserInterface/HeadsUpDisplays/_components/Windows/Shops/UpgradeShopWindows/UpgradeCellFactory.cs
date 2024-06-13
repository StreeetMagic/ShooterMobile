using Gameplay.Stats;
using Infrastructure.ArtConfigServices;
using Infrastructure.ConfigServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows.UpgradeCells;
using UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows.UpgradeCells.Scripts;

namespace UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows
{
  public class UpgradeCellFactory
  {
    private readonly ConfigService _configService;
    private readonly GameLoopZenjectFactory _factory;
    private readonly ArtConfigService _artConfigService;

    public UpgradeCellFactory(ConfigService configService,
      GameLoopZenjectFactory shopWindowFactory, ArtConfigService artConfigService)
    {
      _configService = configService;
      _factory = shopWindowFactory;
      _artConfigService = artConfigService;
    }

    public void Create(StatId id, Transform parent)
    {
      var cell = _factory.InstantiateMono<UpgradeCell>(parent);
      cell.UpgradeConfig = _configService.GetUpgradeConfig(id);
      cell.UpgradeContentSetup = _artConfigService.GetUpgradeContentSetup(id);

      cell.GetComponentInChildren<Icon>().SetIcon(_artConfigService.GetUpgradeContentSetup(id).Icon);
    }
  }
}