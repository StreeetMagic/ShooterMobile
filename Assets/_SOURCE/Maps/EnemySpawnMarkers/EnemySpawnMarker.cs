using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Maps.EnemySpawnMarkers
{
  public class EnemySpawnMarker : MonoBehaviour
  {
    [field: SerializeField] public EnemyId EnemyId { get; private set; }
    [field: SerializeField] public int Count { get; private set; }
  }
}