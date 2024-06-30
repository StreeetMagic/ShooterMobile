using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.ConfigProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using Stats;
using UnityEngine;
using UserInterface.Windows.ShopWinsows.UpgradeShopWindows.UpgradeCells;
using UserInterface.Windows.ShopWinsows.UpgradeShopWindows.UpgradeCells.Scripts;

namespace UserInterface.Windows.ShopWinsows.UpgradeShopWindows
{
  public class UpgradeCellFactory
  {
    private readonly ConfigProvider _configProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly ArtConfigProvider _artConfigProvider;

    public UpgradeCellFactory(ConfigProvider configProvider,
      GameLoopZenjectFactory shopWindowFactory, ArtConfigProvider artConfigProvider)
    {
      _configProvider = configProvider;
      _factory = shopWindowFactory;
      _artConfigProvider = artConfigProvider;
    }

    public void Create(StatId id, Transform parent)
    {
      // var cell = _factory.InstantiateMono<UpgradeCell>(parent);
      var cell = _factory.InstantiateGameObject(PrefabId.UpgradeCell).GetComponent<UpgradeCell>();
      cell.UpgradeConfig = _configProvider.GetUpgradeConfig(id);
      cell.UpgradeContentSetup = _artConfigProvider.GetUpgradeContentSetup(id);

      cell.GetComponentInChildren<Icon>().SetIcon(_artConfigProvider.GetUpgradeContentSetup(id).Icon);
    }
  }
}