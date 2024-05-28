using Sounds;
using UnityEngine;

namespace _Infrastructure.AudioServices
{
  public class SoundPlayer
  {
    public void Play(SoundConfig config, AudioSource source, Vector3 at)
    {
      source.transform.position = at;
      source.PlayOneShot(config.AudioClip, config.Volume);
    }
  }
}