using System.Collections.Generic;
using Configs.Resources.CurrencyConfigs;
using DataRepositories;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Players;
using Infrastructure.SaveLoadServices;
using UnityEngine;
using Zenject;

namespace Gameplay.BaseTriggers
{
  public class BaseTrigger : MonoBehaviour
  {
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private MoneyInBankStorage _moneyInBankStorage;
    [Inject] private EggsInBankStorage _eggsInBankStorage;
    [Inject] private SaveLoadService _saveLoadService;

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
      _saveLoadService.SaveProgress();
    }
  }
}