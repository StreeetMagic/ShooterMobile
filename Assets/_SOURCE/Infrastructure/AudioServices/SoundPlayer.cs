using System.Collections.Generic;
using System.Linq;
using Configs.Resources.SoundConfigs;
using Configs.Resources.SoundConfigs.Scripts;
using UnityEngine;

namespace Infrastructure.AudioServices
{
  public class SoundPlayer
  {
    private readonly List<AudioSource> _audioSources;

    public SoundPlayer(List<AudioSource> audioSources)
    {
      _audioSources = audioSources;
    }

    public void Play(SoundConfig config, AudioSource source, Vector3 at)
    {
      source.transform.position = at;
      source.PlayOneShot(config.AudioClip, config.Volume);
    }
  }
}