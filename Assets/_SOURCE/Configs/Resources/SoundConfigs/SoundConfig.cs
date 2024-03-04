using System.Collections.Generic;
using PUNBALL.ServiceLocators.Services.AudioServices.Enums;
using UnityEngine;

namespace PUNBALL.Resources.SoundConfigs.ConfigSctipts
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig", order = 3)]
    public class SoundConfig : ScriptableObject
    {
        [field: SerializeField] public SoundId Name { get; private set; }
        [field: SerializeField] public AudioClip AudioClip { get; private set; }
        [field: SerializeField] public float Volume { get; private set; }
    }
}