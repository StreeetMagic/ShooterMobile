using System.Collections.Generic;
using System.Linq;
using Maps.EnemySpawnMarkers;
using Maps.PlayerSpawnMarkers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Maps
{
  public class Map : MonoBehaviour
  {
    public PlayerSpawnMarker PlayerSpawnPoint;
    public Transform EnemySpawnersContainer;
    public List<EnemySpawnMarker> EnemySpawnMarkers;

    [Button]
    private void Resolve()
    {
      PlayerSpawnPoint = GetComponentInChildren<PlayerSpawnMarker>();

      EnemySpawnMarkers =
        GetComponentsInChildren<EnemySpawnMarker>()
          .ToList();

      EnemySpawnersContainer =
        GetComponentInChildren<EnemySpawnMarker>()
          .transform
          .parent
          .transform;
    }
  }
}