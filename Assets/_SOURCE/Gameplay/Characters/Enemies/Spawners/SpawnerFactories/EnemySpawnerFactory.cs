using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using Maps;
using Maps.EnemySpawnMarkers;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Spawners.SpawnerFactories
{
  public class EnemySpawnerFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IZenjectFactory _zenjectFactory;
    private readonly EnemySpawner _spawnerPrefab;
    private readonly SpawnPoint _spawnPointPrefab;

    private Map _map;
    private readonly MapFactory _mapFactory;

    public EnemySpawnerFactory(IAssetProvider assetProvider, MapFactory mapFactory, IZenjectFactory zenjectFactory)
    {
      _assetProvider = assetProvider;
      _mapFactory = mapFactory;
      _zenjectFactory = zenjectFactory;
      _spawnerPrefab = _assetProvider.Get<EnemySpawner>();
      _spawnPointPrefab = _assetProvider.Get<SpawnPoint>();

      _mapFactory.Created += OnMapCreated;
    }

    public void Create()
    {
      Transform container = _map.EnemySpawnersContainer;

      List<EnemySpawnMarker> spawnPointMarkers = _map.EnemySpawnMarkers;

      foreach (EnemySpawnMarker marker in spawnPointMarkers)
      {
        EnemySpawner enemySpawner = _zenjectFactory.Instantiate(_spawnerPrefab);
        enemySpawner.transform.SetParent(container);
        enemySpawner.transform.localPosition = marker.transform.localPosition;

        List<SpawnPoint> spawnPoints = CreateSpawnPoints();
        enemySpawner.Init(marker.EnemyId, spawnPoints);

        // enemySpawner.Init(marker.EnemyId);
        enemySpawner.Spawn(marker.Count);
      }
    }

    private List<SpawnPoint> CreateSpawnPoints()
    {
      List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

      foreach (EnemySpawnMarker marker in _map.EnemySpawnMarkers)
      {
        List<EnemySpawnPointMarker> markers = marker.GetComponentsInChildren<EnemySpawnPointMarker>().ToList();

        foreach (EnemySpawnPointMarker enemySpawnPointMarker in markers)
        {
          SpawnPoint spawnPoint = _zenjectFactory.Instantiate<SpawnPoint>();
          spawnPoint.transform.SetParent(enemySpawnPointMarker.transform);
          spawnPoint.transform.localPosition = Vector3.zero;
          spawnPoints.Add(spawnPoint);
        }
      }

      return spawnPoints;
    }

    private void OnMapCreated(Map obj)
    {
      _map = obj;
      _mapFactory.Created -= OnMapCreated;
    }
  }
}