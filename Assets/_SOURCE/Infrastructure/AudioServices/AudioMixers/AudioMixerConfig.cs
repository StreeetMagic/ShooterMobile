using UnityEngine;
using UnityEngine.Audio;

namespace Infrastructure.AudioServices.AudioMixers
{
  [CreateAssetMenu(fileName = "AudioMixerConfig", menuName = "ArtConfigs/AudioMixerConfig")]
  public class AudioMixerConfig : ScriptableObject
  {
    public AudioMixerGroup Master;
  }
}