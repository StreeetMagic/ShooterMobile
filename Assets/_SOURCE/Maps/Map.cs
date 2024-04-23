using System.Collections.Generic;
using System.Linq;
using DataRepositories.Quests;
using Gameplay.BaseTriggers;
using JetBrains.Annotations;
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
    public List<Quester> Questers;

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
      
      Questers = GetComponentsInChildren<Quester>().ToList();
    }
  }
}