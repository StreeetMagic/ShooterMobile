using System.Collections.Generic;
using UnityEngine;

namespace Rewards
{
  [CreateAssetMenu(menuName = "ArtConfigs/RewardContentConfig", fileName = "RewardContentConfig")]
  public class RewardContentConfig : ScriptableObject
  {
    public List<RewardContentSetup> Setups;
  }
}