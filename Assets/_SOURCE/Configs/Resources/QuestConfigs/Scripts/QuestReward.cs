using System;
using Configs.Resources.UpgradeConfigs.Scripts;

namespace Configs.Resources.QuestConfigs
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