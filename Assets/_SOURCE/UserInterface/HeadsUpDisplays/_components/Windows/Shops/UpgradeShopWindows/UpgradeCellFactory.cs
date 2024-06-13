using Gameplay.Stats;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows.UpgradeCells;
using UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows.UpgradeCells.Scripts;

namespace UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows
{
  public class UpgradeCellFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly GameLoopZenjectFactory _factory;

    public UpgradeCellFactory(IStaticDataService staticDataService,
      GameLoopZenjectFactory shopWindowFactory)
    {
      _staticDataService = staticDataService;
      _factory = shopWindowFactory;
    }

    public void Create(StatId id, Transform parent)
    {
      var cell = _factory.InstantiateMono<UpgradeCell>(parent);
      cell.UpgradeConfig = _staticDataService.GetUpgradeConfig(id);

      cell.GetComponentInChildren<Icon>().SetIcon(cell.UpgradeConfig.Icon);
    }
  }
}