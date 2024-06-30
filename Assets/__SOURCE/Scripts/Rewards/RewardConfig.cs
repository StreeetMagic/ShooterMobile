using UnityEngine;

namespace Rewards
{
  [CreateAssetMenu(menuName = "Configs/RewardConfig", fileName = "RewardConfig")]
  public class RewardConfig : ScriptableObject
  {
    public RewardId Id;
  }
}