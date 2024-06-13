using System;
using UnityEngine;

namespace Musics
{
  [Serializable]
  public class MusicSetup 
  {
    public MusicId Id;
    public AudioClip AudioClip;

    [Range(0f, 1f)] public float Volume;
  }
}