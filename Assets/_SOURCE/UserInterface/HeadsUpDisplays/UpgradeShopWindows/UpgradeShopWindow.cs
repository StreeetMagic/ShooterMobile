using System;
using System.Collections.Generic;
using Configs.Resources.Upgrades;
using Infrastructure.StaticDataServices;
using Infrastructure.UserIntefaces;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows
{
  public class UpgradeShopWindow : Window
  {
    [SerializeField] private Transform _container;

    private IStaticDataService _staticDataService;
    private UpgradeCellFactory _upgradeCellFactory;

    [Inject]
    public void Construct(IStaticDataService staticDataService, UpgradeCellFactory shopWindowFactory)
    {
      _staticDataService = staticDataService;
      _upgradeCellFactory = shopWindowFactory;
    }

    private void OnEnable()
    {
      int upgradesCount = _staticDataService.ForUpgrades().Count;

      List<UpgradeId> keys = new List<UpgradeId>(_staticDataService.ForUpgrades().Keys);

      for (int i = 0; i < upgradesCount; i++)
      {
        _upgradeCellFactory.Create(keys[i], _container);
      }
    }
  }
}