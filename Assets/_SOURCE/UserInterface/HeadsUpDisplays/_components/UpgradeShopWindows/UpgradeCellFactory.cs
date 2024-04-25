using Configs.Resources.StatConfigs;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells.Scripts;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows
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