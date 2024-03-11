using Infrastructure.DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.MoneyInBankPanels
{
  public class MoneyInBankPanel : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _moneyInBankText;

    private DataRepository _dataRepository;

    [Inject]
    public void Construct(DataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    private void Start()
    {
      SetMoneyInBank();

      _dataRepository.MoneyInBank.ValueChanged += OnMoneyInBankValueChanged;
    }

    private void OnDestroy()
    {
      _dataRepository.MoneyInBank.ValueChanged -= OnMoneyInBankValueChanged;
    }

    private void SetMoneyInBank() =>
      _moneyInBankText.text = "" + _dataRepository.MoneyInBank.Value;

    private void OnMoneyInBankValueChanged(int obj) =>
      SetMoneyInBank();
  }
}