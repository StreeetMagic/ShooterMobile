using UnityEngine;

namespace Configs.Resources.SoundConfigs.Scripts
{
  [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig")]
  public class SoundConfig : ScriptableObject
  {
    public SoundId Id;
    public AudioClip AudioClip;

    [Range(0f, 1f)] public float Volume;
  }
}