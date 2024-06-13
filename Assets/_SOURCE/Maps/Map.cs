using System.Collections.Generic;
using System.Linq;
using Gameplay.BaseTriggers;
using Gameplay.Bombs;
using Gameplay.Characters.Questers;
using Gameplay.Characters.Shopers;
using Gameplay.Portals;
using Maps.Markers.EnemySpawnMarkers;
using Maps.Markers.PlayerSpawnMarkers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Maps
{
  public class Map : MonoBehaviour
  {
    public PlayerSpawnMarker PlayerSpawnMarker;
    public Transform EnemySpawnersContainer;
    public List<EnemySpawnMarker> EnemySpawnMarkers;
    public BaseTrigger BaseTrigger;
    public List<Quester> Questers;
    public List<Shoper> Shopers;
    public BombSpawner BombSpawner;
    public List<Portal> Portals;

    [Button]
    public void Setup()
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

      Shopers = GetComponentsInChildren<Shoper>().ToList();

      BombSpawner = GetComponentInChildren<BombSpawner>();
      
      Portals = GetComponentsInChildren<Portal>().ToList();
    }
  }
}