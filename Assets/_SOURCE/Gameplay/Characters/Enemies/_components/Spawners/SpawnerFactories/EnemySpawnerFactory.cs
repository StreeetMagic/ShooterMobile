using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using Maps;
using Maps.EnemySpawnMarkers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Spawners.SpawnerFactories
{
  public class EnemySpawnerFactory
  {
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly EnemySpawner _spawnerPrefab;
    private readonly MapProvider _mapProvider;
    private readonly IInstantiator _instantiator;

    public EnemySpawnerFactory(IAssetProvider assetProvider,
      GameLoopZenjectFactory zenjectFactory, MapProvider mapProvider, IInstantiator instantiator)
    {
      IAssetProvider assetProvider1 = assetProvider;
      _zenjectFactory = zenjectFactory;
      _mapProvider = mapProvider;
      _instantiator = instantiator;
      _spawnerPrefab = assetProvider1.Get<EnemySpawner>();
      assetProvider1.Get<SpawnPoint>();
    }

    public List<EnemySpawner> Spawners { get; } = new List<EnemySpawner>();

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
        SpawnPoint spawnPoint = _zenjectFactory.InstantiateMono<SpawnPoint>();
        spawnPoint.transform.SetParent(enemySpawnPointMarker.transform);
        spawnPoint.transform.localPosition = Vector3.zero;
        spawnPoints.Add(spawnPoint);
      }

      return spawnPoints;
    }
  }
}