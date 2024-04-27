using UnityEngine;

namespace Configs.Resources.RewardConfigs
{
  [CreateAssetMenu(menuName = "Configs/RewardConfig", fileName = "RewardConfig")]
  public class RewardConfig : ScriptableObject
  {
    public RewardId Id;
    public Sprite Icon;
  }
}