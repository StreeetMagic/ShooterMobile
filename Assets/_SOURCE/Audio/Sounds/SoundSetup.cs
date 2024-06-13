using System;
using UnityEngine;

namespace Sounds
{
  [Serializable]
  public class SoundSetup
  {
    public SoundId Id;
    public AudioClip AudioClip;

    [Range(0f, 1f)] public float Volume;
  }
}