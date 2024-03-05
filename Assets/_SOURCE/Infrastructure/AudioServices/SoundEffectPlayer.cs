using System.Collections.Generic;
using System.Linq;
using Configs.Resources.SoundConfigs;
using UnityEngine;

namespace Infrastructure.AudioServices
{
  public class SoundEffectPlayer
  {
    private readonly List<SoundConfig> _playerEffects;
    private readonly List<AudioSource> _audioSources;

    public SoundEffectPlayer(List<AudioSource> audioSources)
    {
      _audioSources = audioSources;
    }

    public void Play(SoundId soundId, Vector3 at)
    {
      AudioSource source = _audioSources.FirstOrDefault(source => source.isPlaying == false);

      if (source == null)
        return;

      SoundConfig soundData = _playerEffects[0];

      if (soundData == null)
      {
        Debug.LogError($"{nameof(SoundEffectPlayer)} : {nameof(soundData)} sound type {soundId} not found");
        return;
      }

      source.transform.position = at;
      source.PlayOneShot(soundData.AudioClip, soundData.Volume);
    }
  }
}