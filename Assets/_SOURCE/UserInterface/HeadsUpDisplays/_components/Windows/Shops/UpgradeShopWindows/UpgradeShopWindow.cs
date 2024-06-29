using System.Collections.Generic;
using Gameplay.Stats;
using Infrastructure.ConfigProviders;
using Infrastructure.UserIntefaces;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows
{
  public class UpgradeShopWindow : Window
  {
    [SerializeField] private Transform _container;

    private readonly List<GameObject> _otherStuff = new();

    [Inject] private ConfigProvider _configProvider;
    [Inject] private UpgradeCellFactory _upgradeCellFactory;
    [Inject] private HeadsUpDisplayProvider _headsUpDisplayProvider;

    private void Start()
    {
      CreateUpgradeCells();
      CollectOtherStuff();
      DisableOtherStuff();
    }

    private void OnDisable()
    {
      EnableOtherStuff();
    }

    private void CollectOtherStuff()
    {
      _otherStuff.Add(_headsUpDisplayProvider.UpgradeShopButton.gameObject);
      _otherStuff.Add(_headsUpDisplayProvider.FloatingJoystick.gameObject);
    }

    private void EnableOtherStuff() =>
      _otherStuff
        .ForEach(otherStuff => otherStuff.SetActive(true));

    private void DisableOtherStuff() =>
      _otherStuff
        .ForEach(otherStuff => otherStuff.SetActive(false));

    private void CreateUpgradeCells()
    {
      int upgradesCount = _configProvider.UpgradeConfigs.Count;

      List<StatId> keys = new List<StatId>(_configProvider.UpgradeConfigs.Keys);

      for (int i = 0; i < upgradesCount; i++)
        _upgradeCellFactory.Create(keys[i], _container);
    }
  }
}