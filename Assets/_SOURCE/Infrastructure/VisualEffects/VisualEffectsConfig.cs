using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.VisualEffects
{
  [CreateAssetMenu(fileName = "VisualEffectsConfig", menuName = "ArtConfigs/VisualEffectsConfig")]
  public class VisualEffectsConfig : ScriptableObject
  {
    public List<VisualEffectSetup> Setups;
  }
}