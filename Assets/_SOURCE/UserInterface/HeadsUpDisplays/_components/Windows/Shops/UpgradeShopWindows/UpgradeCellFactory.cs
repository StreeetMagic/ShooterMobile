using Gameplay.Stats;
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

    public UpgradeCellFactory(ConfigService configService,
      GameLoopZenjectFactory shopWindowFactory)
    {
      _configService = configService;
      _factory = shopWindowFactory;
    }

    public void Create(StatId id, Transform parent)
    {
      var cell = _factory.InstantiateMono<UpgradeCell>(parent);
      cell.UpgradeConfig = _configService.GetUpgradeConfig(id);

      cell.GetComponentInChildren<Icon>().SetIcon(cell.UpgradeConfig.Icon);
    }
  }
}