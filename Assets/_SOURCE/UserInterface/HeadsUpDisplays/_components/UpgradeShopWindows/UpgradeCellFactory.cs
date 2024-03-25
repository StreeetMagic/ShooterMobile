using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Upgrades;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows
{
  public class UpgradeCellFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly GameLoopZenjectFactory _factory;
    private readonly UpgradeService _upgradeService;

    public UpgradeCellFactory(IStaticDataService staticDataService, 
      GameLoopZenjectFactory shopWindowFactory, UpgradeService upgradeService)
    {
      _staticDataService = staticDataService;
      _factory = shopWindowFactory;
      _upgradeService = upgradeService;
    }

    public void Create(UpgradeId id, Transform parent)
    {
      var cell = _factory.InstantiateMono<UpgradeCell>(parent);
      cell.UpgradeConfig = _staticDataService.GetUpgradeConfig(id);

      cell.GetComponentInChildren<Icon>().SetIcon(cell.UpgradeConfig.Icon);
    }
  }
}