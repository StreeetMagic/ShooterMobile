using System.Collections.Generic;
using UnityEngine;

namespace Sounds
{
  [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig")]
  public class SoundConfig : ScriptableObject
  {
    public List<SoundSetup> Sounds;
  }
}