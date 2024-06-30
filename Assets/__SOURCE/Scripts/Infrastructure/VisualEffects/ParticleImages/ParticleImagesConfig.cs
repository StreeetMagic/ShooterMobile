using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.VisualEffects.ParticleImages
{
  [CreateAssetMenu(fileName = "ParticleImagesConfig", menuName = "ArtConfigs/ParticleImagesConfig")]
  public class ParticleImagesConfig : ScriptableObject
  {
    public List<ParticleImageSetup> Setups;
  }
}