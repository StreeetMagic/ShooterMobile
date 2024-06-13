using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Loots
{
  [CreateAssetMenu(fileName = "LootIconsConfig", menuName = "ArtConfigs/LootIconsConfig")]
  public class LootIconsConfig : ScriptableObject
  {
    public List<LootSpriteSetup> Sprites;
  }
}