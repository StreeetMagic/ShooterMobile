using System.Collections.Generic;
using System.Linq;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using LevelDesign.EnemySpawnMarkers;
using LevelDesign.EnemySpawnMarkers._components;
using Spawners.SpawnPoints;
using UnityEngine;
using Zenject.Source.Main;

namespace Spawners.SpawnerFactories
{
  public class EnemySpawnerFactory
  {
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly EnemySpawner _spawnerPrefab;
    private readonly MapProvider _mapProvider;
    private readonly IInstantiator _instantiator;
    private readonly ArtConfigProvider _artConfigProvider;

    public EnemySpawnerFactory(AssetProvider assetProvider,
      GameLoopZenjectFactory zenjectFactory, MapProvider mapProvider, IInstantiator instantiator,
      ArtConfigProvider artConfigProvider)
    {
      _zenjectFactory = zenjectFactory;
      _mapProvider = mapProvider;
      _instantiator = instantiator;
      _artConfigProvider = artConfigProvider;

      // _spawnerPrefab = assetProvider.Get<EnemySpawner>();
      _spawnerPrefab = _artConfigProvider.GetPrefab(PrefabId.EnemySpawner).GetComponent<EnemySpawner>();
    }

    public List<EnemySpawner> Spawners { get; } = new();

    private Map Map => _mapProvider.Map;

    public void Create()
    {
      Transform container = Map.EnemySpawnersContainer;

      List<EnemySpawnMarker> spawnPointMarkers = Map.EnemySpawnMarkers;

      foreach (EnemySpawnMarker marker in spawnPointMarkers)
      {
        EnemySpawner enemySpawner = _instantiator.InstantiatePrefab(_spawnerPrefab, container).GetComponent<EnemySpawner>();

        enemySpawner.transform.SetParent(container);
        enemySpawner.transform.localPosition = marker.transform.localPosition;

        List<SpawnPoint> spawnPoints = CreateSpawnPoints(marker);
        enemySpawner.Init(marker.EnemyId, spawnPoints, marker.RespawnTime);

        if (enemySpawner == null)
          continue;

        enemySpawner.Spawn(marker.Count);

        Spawners.Add(enemySpawner);
      }
    }

    private List<SpawnPoint> CreateSpawnPoints(EnemySpawnMarker marker)
    {
      List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

      List<EnemySpawnPointMarker> markers = marker.GetComponentsInChildren<EnemySpawnPointMarker>().ToList();

      foreach (EnemySpawnPointMarker enemySpawnPointMarker in markers)
      {
       // SpawnPoint spawnPoint = _zenjectFactory.InstantiateMono<SpawnPoint>();
       
        SpawnPoint spawnPoint = _zenjectFactory.InstantiateGameObject(PrefabId.SpawnPoint, marker.transform).GetComponent<SpawnPoint>();
        spawnPoint.transform.SetParent(enemySpawnPointMarker.transform);
        spawnPoint.transform.localPosition = Vector3.zero;
        spawnPoints.Add(spawnPoint);
      }

      return spawnPoints;
    }

    public void Destroy()
    {
      foreach (EnemySpawner spawner in Spawners)
      {
        spawner.DeSpawnAll();
      }

      Spawners.Clear();
    }
  }
}