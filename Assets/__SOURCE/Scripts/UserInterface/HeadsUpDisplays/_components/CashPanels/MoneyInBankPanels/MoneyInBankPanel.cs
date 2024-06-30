using CurrencyRepositories;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.CashPanels.MoneyInBankPanels
{
  public class MoneyInBankPanel : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _moneyInBankText;

    [Inject] private MoneyInBankStorage _moneyInBankStorage;

    private void Start()
    {
      SetMoneyInBank();

      _moneyInBankStorage.MoneyInBank.ValueChanged += OnMoneyInBankValueChanged;
    }

    private void OnDestroy()
    {
      _moneyInBankStorage.MoneyInBank.ValueChanged -= OnMoneyInBankValueChanged;
    }

    private void SetMoneyInBank() =>
      _moneyInBankText.text = "" + _moneyInBankStorage.MoneyInBank.Value;

    private void OnMoneyInBankValueChanged(int obj) =>
      SetMoneyInBank();
  }
}