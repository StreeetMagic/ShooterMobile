using Configs.Resources.SoundConfigs;
using Configs.Resources.SoundConfigs.Scripts;
using UnityEngine;

namespace Infrastructure.AudioServices
{
  public class MusicPlayer
  {
    public void Play(MusicConfig musicConfig, AudioSource audioSource)
    {
      audioSource.gameObject.SetActive(true);
      audioSource.loop = true;
      
      audioSource.clip = musicConfig.AudioClip;
      audioSource.volume = musicConfig.Volume;
      audioSource.Play();
    }
  }
}