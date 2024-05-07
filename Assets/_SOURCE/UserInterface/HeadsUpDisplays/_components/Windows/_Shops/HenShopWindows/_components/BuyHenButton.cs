using DataRepositories;
using Gameplay.Characters.Players.Factories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
    
    _playerProvider.PlayerHenSpawner.Count++;
  }
}