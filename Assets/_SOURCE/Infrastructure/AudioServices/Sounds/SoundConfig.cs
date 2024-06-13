using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.AudioServices.Sounds
{
  [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig")]
  public class SoundConfig : ScriptableObject
  {
    public List<SoundSetup> Sounds;
  }
}