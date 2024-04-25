using Configs.Resources.StatConfigs;
using DataRepositories;
using Infrastructure.Upgrades;
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
    private MoneyInBankStorage _moneyInBankStorage;

    [Inject]
    public void Construct(UpgradeService upgradeService, MoneyInBankStorage moneyInBankStorage)
    {
      _upgradeService = upgradeService;
      _moneyInBankStorage = moneyInBankStorage;
    }

    private StatId Id => UpgradeCell.UpgradeConfig.Id;

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

      if (_moneyInBankStorage.MoneyInBank.Value < _upgradeService.GetNextUpgradeCost(Id))
        return;

      _moneyInBankStorage.MoneyInBank.Value -= _upgradeService.GetNextUpgradeCost(Id);
      _upgradeService.BuyUpgrade(Id);
    }

    private bool IsMaxLevel() =>
      _upgradeService.GetUpgrade(UpgradeCell.UpgradeConfig.Id).IsMaxLevel;
  }
}