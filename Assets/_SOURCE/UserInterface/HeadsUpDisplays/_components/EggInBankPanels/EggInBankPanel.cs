using Infrastructure.DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.EggInBankPanels
{
  public class EggInBankPanel : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _eggsInBankText;

    private DataRepository _dataRepository;

    [Inject]
    public void Construct(DataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    private void Start()
    {
      SetEggsInBank();

      _dataRepository.EggsInBank.ValueChanged += OnEggsInBankValueChanged;
    }

    private void OnDestroy()
    {
      _dataRepository.EggsInBank.ValueChanged -= OnEggsInBankValueChanged;
    }

    private void SetEggsInBank() =>
      _eggsInBankText.text = "" + _dataRepository.EggsInBank.Value;

    private void OnEggsInBankValueChanged(int obj) =>
      SetEggsInBank();
  }
}