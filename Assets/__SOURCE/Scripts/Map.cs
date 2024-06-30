using System.Collections.Generic;
using System.Linq;
using BaseTriggers;
using Bombs;
using Characters.Questers;
using Characters.Shopers;
using LevelDesign.EnemySpawnMarkers;
using LevelDesign.PlayerSpawnMarkers;
using LevelDesign.SubQuestMarkers.BombDefuse;
using Portals;
using Sirenix.OdinInspector;
using UnityEngine;

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
  public List<BombDefuseMarker> BombDefuseMarkers;

  [Button]
  public void Setup()
  {
    PlayerSpawnMarker = GetComponentInChildren<PlayerSpawnMarker>();
    EnemySpawnMarkers = GetComponentsInChildren<EnemySpawnMarker>().ToList();
    EnemySpawnersContainer = GetComponentInChildren<EnemySpawnMarker>().transform.parent.transform;
    BaseTrigger = GetComponentInChildren<BaseTrigger>();
    Questers = GetComponentsInChildren<Quester>().ToList();
    Shopers = GetComponentsInChildren<Shoper>().ToList();
    BombSpawner = GetComponentInChildren<BombSpawner>();
    Portals = GetComponentsInChildren<Portal>().ToList();
    BombDefuseMarkers = GetComponentsInChildren<BombDefuseMarker>().ToList();
  }
}