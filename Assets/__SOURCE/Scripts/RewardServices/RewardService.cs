using System.Collections.Generic;
using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.CurrencyRepositories.Expirience;
using Gameplay.Loots;
using Gameplay.Rewards;
using Gameplay.Stats;

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

    public void OnLootDroped(List<LootDrop> loots)
    {
      _backpackStorage.AddLoot(loots);
    }

    public void OnRewardGain(Reward reward)
    {
      switch (reward.RewardId)
      {
        case RewardId.Unknown:
          throw new System.NotImplementedException("Unknown quest reward type");

        case RewardId.Expirience:
          _expierienceStorage.AllPoints.Value += reward.Quantity;
          break;

        case RewardId.BackpackCapacity:
          _playerStatsProvider.AddQuestReward(StatId.BackpackCapacity, reward.Quantity);
          break;
      }
    }
  }
}