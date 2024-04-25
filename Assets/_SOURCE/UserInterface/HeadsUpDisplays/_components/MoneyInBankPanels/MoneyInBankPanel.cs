using DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.MoneyInBankPanels
{
  public class MoneyInBankPanel : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _moneyInBankText;

    private MoneyInBankStorage _moneyInBankStorage;

    [Inject]
    public void Construct(MoneyInBankStorage moneyInBankStorage)
    {
      _moneyInBankStorage = moneyInBankStorage;
    }

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