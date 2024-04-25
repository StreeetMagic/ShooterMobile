using System;

namespace Configs.Resources.QuestConfigs.Scripts
{
  [Serializable]
  public class QuestReward
  {
    public QuestRewardId RewardId;
    public int Quantity;
  }

  public enum QuestRewardId
  {
    Unknown = 0,
    Expirience = 1,
    BackpackCapacity = 2,
  }
}