using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Currencies;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using UnityEngine;

namespace Gameplay.RewardServices
{
  public class RewardService
  {
    private readonly List<EnemyHealth> _healths = new();

    private readonly IStaticDataService _staticDataService;
    private readonly BackpackStorage _backpackStorage;
    private readonly MoneyInBankStorage _moneyInBankStorage;
    private readonly EggsInBankStorage _eggsInBankStorage;

    public RewardService(IStaticDataService staticDataService, MoneyInBankStorage moneyInBankStorage, EggsInBankStorage eggsInBankStorage, BackpackStorage backpackStorage)
    {
      _staticDataService = staticDataService;
      _moneyInBankStorage = moneyInBankStorage;
      _eggsInBankStorage = eggsInBankStorage;
      _backpackStorage = backpackStorage;
    }

    public void AddEnemy(EnemyHealth enemyHealth)
    {
      _healths.Add(enemyHealth);
      
      enemyHealth.Died += OnEnemyDied;
    }

    private void OnEnemyDied(EnemyConfig enemyConfig, EnemyHealth enemyHealth)
    {
      _healths.Remove(enemyHealth);
      
      _backpackStorage.AddLoot(enemyConfig.LootDrops);
    }

    // private void Reward(EnemyConfig enemyConfig)
    // {
    //   List<LootDrop> loot = enemyConfig.LootDrops;
    //
    //   foreach (LootDrop lootDrop in loot)
    //   {
    //     int reward = lootDrop.Loot.Value;
    //
    //     switch (lootDrop.Id)
    //     {
    //       case CurrencyId.Unknown:
    //         throw new System.NotImplementedException();
    //
    //       case CurrencyId.Eggs:
    //         _eggsInBankStorage.EggsInBank.Value += reward;
    //         break;
    //
    //       case CurrencyId.Money:
    //         _moneyInBankStorage.MoneyInBank.Value += reward;
    //         break;
    //
    //       default:
    //         throw new System.NotImplementedException();
    //     }
    //   }
    // }
  }
}