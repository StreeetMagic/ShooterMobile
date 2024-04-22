using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.QuestConfigs;
using Configs.Resources.UpgradeConfigs.Scripts;
using DataRepositories.Quests;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players._components.PlayerStatsServices;
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
    private readonly ExpierienceStorage _expierienceStorage;
    private readonly PlayerStatsProvider _playerStatsProvider;

    public RewardService(IStaticDataService staticDataService,
      MoneyInBankStorage moneyInBankStorage, EggsInBankStorage eggsInBankStorage,
      BackpackStorage backpackStorage, ExpierienceStorage expierienceStorage,
      PlayerStatsProvider playerStatsProvider)
    {
      _staticDataService = staticDataService;
      _moneyInBankStorage = moneyInBankStorage;
      _eggsInBankStorage = eggsInBankStorage;
      _backpackStorage = backpackStorage;
      _expierienceStorage = expierienceStorage;
      _playerStatsProvider = playerStatsProvider;
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

    public void OnSubQuestCompleted(QuestReward questReward)
    {
      switch (questReward.RewardId)
      {
        case QuestRewardId.Unknown:
          throw new System.NotImplementedException("Unknown quest reward type");

        case QuestRewardId.Expirience:
          _expierienceStorage.AllPoints.Value += questReward.Quantity;
          break;

        case QuestRewardId.BackpackCapacity:
          _playerStatsProvider.AddQuestReward(StatId.BackpackCapacity, questReward.Quantity);
          break;
      }
    }
  }
}