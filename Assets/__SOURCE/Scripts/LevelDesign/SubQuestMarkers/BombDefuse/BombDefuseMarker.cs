using System.Collections.Generic;
using Loots;
using UnityEngine;

namespace LevelDesign.SubQuestMarkers.BombDefuse
{
  public class BombDefuseMarker : MonoBehaviour
  {
    [Tooltip("Время повторного появления этой же бомбы после дефьюза")]
    public float RespawnTime = 5;    
    
    [Tooltip("Награды за дефьюз бомбы")]
    public List<LootDrop> LootDrops;
  }
}