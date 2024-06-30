using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.AudioServices.Sounds
{
  [Serializable]
  public class SoundSetup
  {
    public SoundId Id;
    public List<AudioClip> AudioClip;

    [Range(0f, 1f)] public float Volume;
  }
}