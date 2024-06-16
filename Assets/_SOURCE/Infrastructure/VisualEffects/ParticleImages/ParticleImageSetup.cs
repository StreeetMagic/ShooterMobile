using System;
using System.Collections.Generic;
using UnityAssetsTools.ParticleImage.Runtime;

namespace Infrastructure.VisualEffects.ParticleImages
{
  [Serializable]
  public class ParticleImageSetup
  {
    public ParticleImageId Id;

    public List<ParticleImage> Prefabs;
  }
}