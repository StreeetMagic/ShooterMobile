using DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.EggInBankPanels
{
  public class EggInBankPanel : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _eggsInBankText;

    [Inject] private EggsInBankStorage _moneyInBankStorage;

    private void Update()
    {
      SetEggsInBank();
    }

    private void SetEggsInBank() =>
      _eggsInBankText.text = "" + _moneyInBankStorage.EggsInBank.Value;
  }
}