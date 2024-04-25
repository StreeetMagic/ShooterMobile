using System.Collections.Generic;
using Configs.Resources.CurrencyConfigs;
using DataRepositories;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Players;
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
      if (!other.TryGetComponent(out PlayerTargetTrigger playerTrigger))
        return;

      if (!playerTrigger.transform.parent.TryGetComponent(out Player _))
        return;

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