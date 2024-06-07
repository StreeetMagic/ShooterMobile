using Gameplay.CurrencyRepositories;
using Gameplay.Stats;
using Gameplay.Upgrades;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows._Shops.UpgradeShopWindows.UpgradeCells.UpgradeButtons
{
  public class UpgradeButton : MonoBehaviour
  {
    public Button Button;
    public UpgradeCell UpgradeCell;

    [Inject] private UpgradeService _upgradeService;
    [Inject] private MoneyInBankStorage _moneyInBankStorage;

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