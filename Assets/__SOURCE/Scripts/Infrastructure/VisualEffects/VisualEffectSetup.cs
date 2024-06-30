using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.VisualEffects
{
  [Serializable]
  public class VisualEffectSetup
  {
    public VisualEffectId Id;

    public List<ParticleSystem> Prefabs;
  }
}