using Musics;
using UnityEngine;

namespace AudioServices
{
  public class MusicPlayer
  {
    public void Play(MusicConfig musicConfig, AudioSource audioSource)
    {
      audioSource.gameObject.SetActive(true);
      audioSource.loop = true;
      
      // audioSource.clip = musicConfig.AudioClip;
      // audioSource.volume = musicConfig.Volume;
      // audioSource.Play();
    }
  }
}