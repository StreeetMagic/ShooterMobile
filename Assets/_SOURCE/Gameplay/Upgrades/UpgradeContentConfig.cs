using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Upgrades
{
  [CreateAssetMenu(fileName = "UpgradeContentConfig", menuName = "ArtConfigs/UpgradeContentConfig")]
  public class UpgradeContentConfig : ScriptableObject
  {
    public List<UpgradeContentSetup> Setups;
  }
}