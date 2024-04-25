using UnityEngine;

namespace Configs.Resources.MusicConfigs.Scripts
{
  [CreateAssetMenu(fileName = "MusicConfig", menuName = "Configs/MusicConfig")]
  public class MusicConfig : ScriptableObject
  {
    public MusicId Id;
    public AudioClip AudioClip;

    [Range(0f, 1f)] public float Volume;
  }
}