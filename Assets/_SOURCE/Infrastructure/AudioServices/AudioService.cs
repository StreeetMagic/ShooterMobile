using System.Collections.Generic;
using Configs.Resources.SoundConfigs;
using UnityEngine;

namespace Infrastructure.AudioServices
{
  public class AudioService : MonoBehaviour
  {
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private List<AudioSource> _playerSources;

    private MusicPlayer _musicPlayer;
    private SoundEffectPlayer _soundEffectPlayer;

    private float _volume;

    public bool IsWorking { get; private set; } = true;

    private void Awake()
    {
      _volume = _musicSource.volume;
      _musicPlayer = new MusicPlayer(_musicSource);
      _soundEffectPlayer = new SoundEffectPlayer(_playerSources);

      SetMusic(SoundId.GameLoopMusic);
      _musicPlayer.Continue();
    }

    public void PlaySoundFx(SoundId clip, Vector3 at = default)
    {
      if (IsWorking == false)
        return;

      _soundEffectPlayer.Play(clip, at);
    }

    public void EnableSound()
    {
      Debug.Log("EnableSound");

      _musicPlayer.Continue();
      IsWorking = true;
    }

    public void DisableSound()
    {
      Debug.Log("DisableSound");

      _musicPlayer.Stop();
      IsWorking = false;
    }

    public void UnMuteMusic()
    {
      if (_musicSource == null)
        return;

      Debug.Log("UnMuteMusic");

      _musicSource.volume = _volume;
    }

    public void MuteMusic()
    {
      if (_musicSource == null)
        return;

      Debug.Log("MuteMusic");

      _musicSource.volume = 0;
    }

    private void SetMusic(SoundId clip)
    {
      _volume = _musicPlayer.SetMusic(clip);
    }
  }
}