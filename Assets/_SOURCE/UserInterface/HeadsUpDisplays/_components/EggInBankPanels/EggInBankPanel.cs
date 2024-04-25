using DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.EggInBankPanels
{
  public class EggInBankPanel : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _eggsInBankText;

    private EggsInBankStorage _moneyInBankStorage;

    [Inject]
    public void Construct(EggsInBankStorage moneyInBankStorage)
    {
      _moneyInBankStorage = moneyInBankStorage;
    }

    private void Start()
    {
      SetEggsInBank();

      _moneyInBankStorage.EggsInBank.ValueChanged += OnEggsInBankValueChanged;
    }

    private void OnDestroy()
    {
      _moneyInBankStorage.EggsInBank.ValueChanged -= OnEggsInBankValueChanged;
    }

    private void SetEggsInBank() =>
      _eggsInBankText.text = "" + _moneyInBankStorage.EggsInBank.Value;

    private void OnEggsInBankValueChanged(int obj) =>
      SetEggsInBank();
  }
}