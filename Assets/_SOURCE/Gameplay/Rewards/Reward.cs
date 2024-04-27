using System;
using Configs.Resources.RewardConfigs;

namespace Gameplay.Rewards
{
  [Serializable]
  public class Reward
  {
    public RewardId RewardId;
    public int Quantity;
  }
}