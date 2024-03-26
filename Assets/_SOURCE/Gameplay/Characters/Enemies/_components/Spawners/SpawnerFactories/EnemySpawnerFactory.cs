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
    public List<EnemySpawner> Spawners { get; } = new List<EnemySpawner>();
    
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly EnemySpawner _spawnerPrefab;
    private readonly MapProvider _mapProvider;
    private readonly IInstantiator _instantiator;

    public EnemySpawnerFactory(IAssetProvider assetProvider, 
      GameLoopZenjectFactory zenjectFactory, MapProvider mapProvider, IInstantiator instantiator)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _mapProvider = mapProvider;
      _instantiator = instantiator;
      _spawnerPrefab = _assetProvider.Get<EnemySpawner>();
      _assetProvider.Get<SpawnPoint>();
    }

    private Map Map => _mapProvider.Map;

    public void Create()
    {
      Transform container = Map.EnemySpawnersContainer;

      List<EnemySpawnMarker> spawnPointMarkers = Map.EnemySpawnMarkers;

      foreach (EnemySpawnMarker marker in spawnPointMarkers)
      {
        //EnemySpawner enemySpawner = _zenjectFactory.Instantiate(_spawnerPrefab);
        EnemySpawner enemySpawner = _instantiator.InstantiatePrefab(_spawnerPrefab, container).GetComponent<EnemySpawner>();

        enemySpawner.transform.SetParent(container);
        enemySpawner.transform.localPosition = marker.transform.localPosition;

        List<SpawnPoint> spawnPoints = CreateSpawnPoints(marker);
        enemySpawner.Init(marker.EnemyId, spawnPoints, marker.RespawnTime);

        // enemySpawner.Init(marker.EnemyId);
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