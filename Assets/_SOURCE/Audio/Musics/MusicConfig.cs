using System.Collections.Generic;
using UnityEngine;

namespace Musics
{
  [CreateAssetMenu(fileName = "MusicConfig", menuName = "Configs/MusicConfig")]
  public class MusicConfig : ScriptableObject
  {
    public List<MusicSetup> Musics;
  }
}