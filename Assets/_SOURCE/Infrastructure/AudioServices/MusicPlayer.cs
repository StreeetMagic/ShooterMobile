using System.Collections.Generic;
using System.Linq;
using PUNBALL.Resources.SoundConfigs.ConfigSctipts;
using PUNBALL.ServiceLocators.Services.AudioServices.Enums;
using UnityEngine;

namespace PUNBALL.ServiceLocators.Services.AudioServices
{
    public class MusicPlayer
    {
        private SoundConfig _soundConfig;
        private readonly AudioSource _audioSource;

        public MusicPlayer(AudioSource audioSource)
        {
            _audioSource = audioSource;

            _audioSource.loop = true;
        }

        public float SetMusic(SoundId music)
        {
            if (_soundConfig == null)
            {
                Debug.LogError($"{nameof(MusicPlayer)} : {nameof(_soundConfig)} sound type {music} not found");
                return 0f;
            }

            _audioSource.clip = _soundConfig.AudioClip;
            _audioSource.volume = _soundConfig.Volume;

            return _audioSource.volume;
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public void Continue()
        {
            _audioSource.Play();
        }
    }
}