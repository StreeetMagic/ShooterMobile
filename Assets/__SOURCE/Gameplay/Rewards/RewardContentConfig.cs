using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Rewards
{
  [CreateAssetMenu(menuName = "ArtConfigs/RewardContentConfig", fileName = "RewardContentConfig")]
  public class RewardContentConfig : ScriptableObject
  {
    public List<RewardContentSetup> Setups;
  }
}