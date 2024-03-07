using Infrastructure.DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

namespace Vlad.HeadsUpDisplays
{
  public class HeadsUpDisplay : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _moneyInBackpackText;

    private DataRepository _dataRepository;

    [Inject]
    public void Construct(DataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    private void Start()
    {
      SetMoneyInBackPack();

      _dataRepository.MoneyInBackpack.ValueChanged += OnMoneyInBackPackValueChanged;
    }

    private void OnDestroy()
    {
      _dataRepository.MoneyInBackpack.ValueChanged -= OnMoneyInBackPackValueChanged;
    }

    private void SetMoneyInBackPack() =>
      _moneyInBackpackText.text = "" + _dataRepository.MoneyInBackpack.Value;

    private void OnMoneyInBackPackValueChanged(int obj) =>
      SetMoneyInBackPack();
  }
}