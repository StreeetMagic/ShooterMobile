using Configs.Resources.Upgrades;
using Gameplay.Upgrades;
using Infrastructure.DataRepositories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells._.UpgradeButtons
{
  public class UpgradeButton : MonoBehaviour
  {
    public Button Button;
    public UpgradeCell UpgradeCell;

    private UpgradeService _upgradeService;
    private DataRepository _dataRepository;

    [Inject]
    public void Construct(UpgradeService upgradeService, DataRepository dataRepository)
    {
      _upgradeService = upgradeService;
      _dataRepository = dataRepository;
    }

    private UpgradeId Id => UpgradeCell.UpgradeConfig.Id;

    private void Start()
    {
      SetupButton();
    }

    private void SetupButton() =>
      Button.onClick.AddListener(() => { OnClick(); });

    private void OnClick()
    {
      if (IsMaxLevel())
        return;

      if (_dataRepository.MoneyInBank.Value < _upgradeService.GetNextUpgradeCost(Id))
        return;

      _dataRepository.MoneyInBank.Value -= _upgradeService.GetNextUpgradeCost(Id);
      _upgradeService.BuyUpgrade(Id);
    }

    private bool IsMaxLevel() =>
      _upgradeService.GetUpgrade(UpgradeCell.UpgradeConfig.Id).IsMaxLevel;
  }
}