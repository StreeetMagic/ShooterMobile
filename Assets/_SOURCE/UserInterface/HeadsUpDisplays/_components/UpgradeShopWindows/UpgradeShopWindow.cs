using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using Infrastructure.StaticDataServices;
using Infrastructure.UserIntefaces;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows
{
  public class UpgradeShopWindow : Window
  {
    [SerializeField] private Transform _container;

    private readonly List<GameObject> _otherStuff = new();

    private IStaticDataService _staticDataService;
    private UpgradeCellFactory _upgradeCellFactory;
    private HeadsUpDisplayProvider _headsUpDisplayProvider;

    [Inject]
    public void Construct(IStaticDataService staticDataService, 
      UpgradeCellFactory shopWindowFactory,
      HeadsUpDisplayProvider headsUpDisplayProvider)
    {
      _staticDataService = staticDataService;
      _upgradeCellFactory = shopWindowFactory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
    }

    private void Start()
    {
      CreateUpgradeCells();
      CollectOtherStuff();
      DisableOtherStuff();
    }

    private void OnDestroy()
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
      int upgradesCount = _staticDataService.ForUpgrades().Count;

      List<UpgradeId> keys = new List<UpgradeId>(_staticDataService.ForUpgrades().Keys);

      for (int i = 0; i < upgradesCount; i++)
        _upgradeCellFactory.Create(keys[i], _container);
    }
  }
}