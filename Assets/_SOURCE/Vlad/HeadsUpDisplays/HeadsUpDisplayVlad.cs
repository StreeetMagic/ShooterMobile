using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using Zenject;

public class HeadsUpDisplayVlad : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _moneyInBankText;
  [SerializeField] private TextMeshProUGUI _moneyInBackpackText;
  [SerializeField] private TextMeshProUGUI _eggsInBankText;
  [SerializeField] private TextMeshProUGUI _eggsInBackpackText;

  private PersistentProgressService _persistentProgressService;

  [Inject]
  public void Construct(PersistentProgressService persistentProgressService)
  {
    _persistentProgressService = persistentProgressService;
  }

  private void Start()
  {
    SetMoneyInBank();
    SetMoneyInBackPack();
    SetEggsInBank();
    SetEggsInBackpack();

    _persistentProgressService.MoneyInBank.ValueChanged += OnMoneyInBankValueChanged;
    _persistentProgressService.MoneyInBackpack.ValueChanged += OnMoneyInBackPackValueChanged;

    _persistentProgressService.EggsInBank.ValueChanged += OnEggsInBankValueChanged;
    _persistentProgressService.EggsInBackpack.ValueChanged += OnEggsInBackpackValueChanged;
  }

  private void OnDestroy()
  {
    _persistentProgressService.MoneyInBank.ValueChanged -= OnMoneyInBankValueChanged;
    _persistentProgressService.MoneyInBackpack.ValueChanged -= OnMoneyInBackPackValueChanged;

    _persistentProgressService.EggsInBank.ValueChanged -= OnEggsInBankValueChanged;
    _persistentProgressService.EggsInBackpack.ValueChanged -= OnEggsInBackpackValueChanged;
  }

  private void SetMoneyInBackPack() =>
    _moneyInBackpackText.text = "Money in backpack: " + _persistentProgressService.MoneyInBackpack.Value;

  private void SetMoneyInBank() =>
    _moneyInBankText.text = "Money in bank: " + _persistentProgressService.MoneyInBank.Value;

  private void SetEggsInBank() =>
    _eggsInBankText.text = "Eggs in bank: " + _persistentProgressService.EggsInBank.Value;

  private void SetEggsInBackpack() =>
    _eggsInBackpackText.text = "Eggs in backpack: " + _persistentProgressService.EggsInBackpack.Value;

  private void OnMoneyInBankValueChanged(int obj) =>
    SetMoneyInBank();

  private void OnMoneyInBackPackValueChanged(int obj) =>
    SetMoneyInBackPack();

  private void OnEggsInBankValueChanged(int obj) =>
    SetEggsInBank();

  private void OnEggsInBackpackValueChanged(int obj) =>
    SetEggsInBackpack();
}