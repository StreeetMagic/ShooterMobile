using System.Collections.Generic;
using UnityEngine;

namespace Loots
{
  [CreateAssetMenu(fileName = "LootIconsConfig", menuName = "ArtConfigs/LootIconsConfig")]
  public class LootIconsConfig : ScriptableObject
  {
    public List<LootContentSetup> Setups;
  }
}