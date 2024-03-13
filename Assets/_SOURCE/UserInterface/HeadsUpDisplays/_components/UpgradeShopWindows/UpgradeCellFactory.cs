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
    private readonly IZenjectFactory _factory;
    private readonly UpgradeService _upgradeService;

    public UpgradeCellFactory(IStaticDataService staticDataService, IZenjectFactory shopWindowFactory, UpgradeService upgradeService)
    {
      _staticDataService = staticDataService;
      _factory = shopWindowFactory;
      _upgradeService = upgradeService;
    }

    public void Create(UpgradeId id, Transform parent)
    {
      var cell = _factory.Instantiate<UpgradeCell>(parent);
      cell.UpgradeConfig = _staticDataService.ForUpgradeConfig(id);
    }
  }
}