using UnityEngine;

namespace Gameplay.Rewards
{
  [CreateAssetMenu(menuName = "Configs/RewardConfig", fileName = "RewardConfig")]
  public class RewardConfig : ScriptableObject
  {
    public RewardId Id;
    public Sprite Icon;
  }
}