using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.AudioServices.Music
{
  [Serializable]
  public class MusicSetup 
  {
    public MusicId Id;
    public List<AudioClip> AudioClip;

    [Range(0f, 1f)] public float Volume;
  }
}