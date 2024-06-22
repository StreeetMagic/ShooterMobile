using System.Collections.Generic;
using Gameplay.Loots;
using Gameplay.Rewards;
using UnityEngine;

namespace Maps.Markers.SubQuestMarkers.BombDefuse
{
  public class BombDefuseMarker : MonoBehaviour
  {
    [Tooltip("Время повторного появления этой же бомбы после дефьюза")]
    public float RespawnTime = 5;    
    
    [Tooltip("Награды за дефьюз бомбы")]
    public List<LootDrop> LootDrops;
  }
}