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
    [field: SerializeField] public PlayerSpawnMarker PlayerSpawnPoint { get; private set; }
    [field: SerializeField] public Transform EnemySpawnersContainer { get; private set; }
  
    [SerializeField] private List<EnemySpawnMarker> _enemySpawnPoints;

    public List<EnemySpawnMarker> EnemySpawnPoints => _enemySpawnPoints.ToList();

    [Button]
    private void Resolve()
    {
      PlayerSpawnPoint = GetComponentInChildren<PlayerSpawnMarker>();

      _enemySpawnPoints =
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