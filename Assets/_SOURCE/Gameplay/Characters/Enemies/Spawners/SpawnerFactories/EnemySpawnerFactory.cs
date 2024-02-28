using System.Collections.Generic;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using Maps;
using Maps.EnemySpawnMarkers;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Spawners.SpawnerFactories
{
  public class EnemySpawnerFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IZenjectFactory _zenjectFactory;
    private readonly EnemySpawner _prefab;

    private Map _map;
    private readonly MapFactory _mapFactory;

    public EnemySpawnerFactory(IAssetProvider assetProvider, MapFactory mapFactory, IZenjectFactory zenjectFactory)
    {
      _assetProvider = assetProvider;
      _mapFactory = mapFactory;
      _zenjectFactory = zenjectFactory;
      _prefab = _assetProvider.Get<EnemySpawner>();

      _mapFactory.Created += OnMapCreated;
    }

    public void Create()
    {
      Transform container = _map.EnemySpawnersContainer;

      List<EnemySpawnMarker> spawnPointMarkers = _map.EnemySpawnPoints;

      foreach (EnemySpawnMarker marker in spawnPointMarkers)
      {
        EnemySpawner enemySpawner = _zenjectFactory.Instantiate(_prefab);
        enemySpawner.transform.SetParent(container);

        enemySpawner.transform.localPosition = marker.transform.localPosition;
        enemySpawner.Init(marker.EnemyId);
        enemySpawner.Spawn(marker.Count);
      }
    }

    private void OnMapCreated(Map obj)
    {
      _map = obj;
      _mapFactory.Created -= OnMapCreated;
    }
  }
}