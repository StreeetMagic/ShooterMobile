using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.QuestConfigs.Scripts;
using Configs.Resources.StatConfigs;
using DataRepositories;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players._components.PlayerStatsProviders;

namespace Gameplay.RewardServices
{
  public class RewardService
  {
    private readonly BackpackStorage _backpackStorage;
    private readonly ExpierienceStorage _expierienceStorage;
    private readonly PlayerStatsProvider _playerStatsProvider;

    public RewardService(BackpackStorage backpackStorage, ExpierienceStorage expierienceStorage,
      PlayerStatsProvider playerStatsProvider)
    {
      _backpackStorage = backpackStorage;
      _expierienceStorage = expierienceStorage;
      _playerStatsProvider = playerStatsProvider;
    }

    public void AddEnemy(EnemyHealth enemyHealth)
    {
      enemyHealth.Died += OnEnemyDied;
    }

    private void OnEnemyDied(EnemyConfig enemyConfig, EnemyHealth enemyHealth)
    {
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

    public void OnQuestCompleted(QuestReward reward)
    {
      switch (reward.RewardId)
      {
        case QuestRewardId.Unknown:
          throw new System.NotImplementedException("Unknown quest reward type");

        case QuestRewardId.Expirience:
          _expierienceStorage.AllPoints.Value += reward.Quantity;
          break;

        case QuestRewardId.BackpackCapacity:
          _playerStatsProvider.AddQuestReward(StatId.BackpackCapacity, reward.Quantity);
          break;
      }
    }
  }
}