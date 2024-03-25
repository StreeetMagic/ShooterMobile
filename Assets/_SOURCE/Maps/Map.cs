using System.Collections.Generic;
using System.Linq;
using Gameplay.BaseTriggers;
using Maps.EnemySpawnMarkers;
using Maps.PlayerSpawnMarkers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Maps
{
  public class Map : MonoBehaviour
  {
    public PlayerSpawnMarker PlayerSpawnMarker;
    public Transform EnemySpawnersContainer;
    public List<EnemySpawnMarker> EnemySpawnMarkers;
    public BaseTrigger BaseTrigger;

    [Button]
    private void Resolve()
    {
      PlayerSpawnMarker = GetComponentInChildren<PlayerSpawnMarker>();

      EnemySpawnMarkers =
        GetComponentsInChildren<EnemySpawnMarker>()
          .ToList();

      EnemySpawnersContainer =
        GetComponentInChildren<EnemySpawnMarker>()
          .transform
          .parent
          .transform;
      
      BaseTrigger = GetComponentInChildren<BaseTrigger>();
    }
  }
}