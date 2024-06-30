using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.AudioServices.Music
{
  [CreateAssetMenu(fileName = "MusicConfig", menuName = "ArtConfigs/MusicConfig")]
  public class MusicConfig : ScriptableObject
  {
    public List<MusicSetup> Musics;
  }
}