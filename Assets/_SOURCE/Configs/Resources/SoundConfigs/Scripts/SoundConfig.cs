using UnityEngine;

namespace Configs.Resources.SoundConfigs.Scripts
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig", order = 3)]
    public class SoundConfig : ScriptableObject
    {
        [field: SerializeField] public SoundId Name { get; private set; }
        [field: SerializeField] public AudioClip AudioClip { get; private set; }
        [field: SerializeField] public float Volume { get; private set; }
    }
}