using Configs.Resources.Upgrades;
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
      UpgradeCell cell = _factory.Instantiate<UpgradeCell>(parent);

      UpgradeConfig upgradeConfig = _staticDataService.ForConfig(id);

      int level = _upgradeService.Upgrades[id].Level.Value;

      cell.Description.text = upgradeConfig.Description;

      int index = level - 1;
      
      Debug.Log("Пытаюсь получить индекс " + index);
      
      cell.Cost.text = upgradeConfig.Values[index].Value.ToString();
    }
  }
}