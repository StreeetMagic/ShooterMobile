using System.Collections.Generic;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.TargetLocators;
using Gameplay.Currencies;
using Infrastructure.DataRepositories;
using UnityEngine;
using Zenject;

namespace Gameplay.BaseTriggers
{
  public class BaseTrigger : MonoBehaviour
  {
    private BackpackStorage _backpackStorage;
    private MoneyInBankStorage _moneyInBankStorage;
    private EggsInBankStorage _eggsInBankStorage;

    [Inject]
    public void Construct(BackpackStorage backpackStorage, MoneyInBankStorage moneyInBankStorage, EggsInBankStorage eggsInBankStorage)
    {
      _backpackStorage = backpackStorage;
      _moneyInBankStorage = moneyInBankStorage;
      _eggsInBankStorage = eggsInBankStorage;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out TargetTrigger playerTrigger))
      {
        if (playerTrigger.transform.parent.TryGetComponent(out Player player))
        {
          Dictionary<CurrencyId, int> data = _backpackStorage.ReadLoot();

          foreach (KeyValuePair<CurrencyId, int> loot in data)
          {
            switch (loot.Key)
            {
              case CurrencyId.Money:
                _moneyInBankStorage.MoneyInBank.Value += loot.Value;
                break;
              
              case CurrencyId.Eggs:
                _eggsInBankStorage.EggsInBank.Value += loot.Value;
                break;
            }
          }

          _backpackStorage.Clean();
        }
      }
    }
  }
}