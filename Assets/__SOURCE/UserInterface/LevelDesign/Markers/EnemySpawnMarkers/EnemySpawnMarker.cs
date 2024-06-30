using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Maps.Markers.EnemySpawnMarkers
{
  public class EnemySpawnMarker : MonoBehaviour
  {
    public EnemyTypeId EnemyId;
    public int Count;
    public int RespawnTime = 15;
    public Transform Container;
  }
}