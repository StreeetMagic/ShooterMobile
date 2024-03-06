using Infrastructure.DataRepositories;
using Infrastructure.PersistentProgresses;
using TMPro;
using UnityEngine;
using Zenject;

namespace Vlad.HeadsUpDisplays
{
  public class HeadsUpDisplay : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _moneyInBankText;
    [SerializeField] private TextMeshProUGUI _moneyInBackpackText;
    [SerializeField] private TextMeshProUGUI _eggsInBankText;
    [SerializeField] private TextMeshProUGUI _eggsInBackpackText;

    private DataRepository _dataRepository;

    [Inject]
    public void Construct(DataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    private void Start()
    {
      SetMoneyInBank();
      SetMoneyInBackPack();
      SetEggsInBank();
      SetEggsInBackpack();

      _dataRepository.MoneyInBank.ValueChanged += OnMoneyInBankValueChanged;
      _dataRepository.MoneyInBackpack.ValueChanged += OnMoneyInBackPackValueChanged;

      _dataRepository.EggsInBank.ValueChanged += OnEggsInBankValueChanged;
      _dataRepository.EggsInBackpack.ValueChanged += OnEggsInBackpackValueChanged;
    }

    private void OnDestroy()
    {
      _dataRepository.MoneyInBank.ValueChanged -= OnMoneyInBankValueChanged;
      _dataRepository.MoneyInBackpack.ValueChanged -= OnMoneyInBackPackValueChanged;

      _dataRepository.EggsInBank.ValueChanged -= OnEggsInBankValueChanged;
      _dataRepository.EggsInBackpack.ValueChanged -= OnEggsInBackpackValueChanged;
    }

    private void SetMoneyInBackPack() =>
      _moneyInBackpackText.text = "Money in backpack: " + _dataRepository.MoneyInBackpack.Value;

    private void SetMoneyInBank() =>
      _moneyInBankText.text = "Money in bank: " + _dataRepository.MoneyInBank.Value;

    private void SetEggsInBank() =>
      _eggsInBankText.text = "Eggs in bank: " + _dataRepository.EggsInBank.Value;

    private void SetEggsInBackpack() =>
      _eggsInBackpackText.text = "Eggs in backpack: " + _dataRepository.EggsInBackpack.Value;

    private void OnMoneyInBankValueChanged(int obj) =>
      SetMoneyInBank();

    private void OnMoneyInBackPackValueChanged(int obj) =>
      SetMoneyInBackPack();

    private void OnEggsInBankValueChanged(int obj) =>
      SetEggsInBank();

    private void OnEggsInBackpackValueChanged(int obj) =>
      SetEggsInBackpack();
  }
}