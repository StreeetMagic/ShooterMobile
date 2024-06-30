using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.Shops.HenShopWindows
{
  public class BuyHenButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private EggsInBankStorage _eggsInBankStorage;

    private void Awake()
    {
      Button.onClick.AddListener(Buy);
    }

    private void Buy()
    {
      int eggCost = 3;
    
      if (_eggsInBankStorage.EggsInBank.Value < eggCost)
        return;
    
      _eggsInBankStorage.EggsInBank.Value -= eggCost;
    
      _playerProvider.Instance.HenSpawner.Count++;
    }
  }
}