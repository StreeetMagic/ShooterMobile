using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Enemies.Spawners.RoutePoints;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.Spawners
{
  public class EnemySpawner : MonoBehaviour
  {
    private IAssetProvider _assetProvider;
    private Enemy _prefab;
    private List<SpawnPoint> _spawnPoints;
    private List<RoutePoint> _routePoints;
    private IZenjectFactory _zenjectFactory;

    public EnemyId EnemyId { get; private set; }

    [Inject]
    public void Construct(IAssetProvider assetProvider, IZenjectFactory zenjectFactory)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;

      _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
      _routePoints = GetComponentsInChildren<RoutePoint>().ToList();
    }

    public void Init(EnemyId enemyId)
    {
      EnemyId = enemyId;
      _prefab = _assetProvider.ForEnemy(EnemyId);
    }

    public void Spawn(int count)
    {
      if (_routePoints.Count < 0)
        throw new Exception("Count should be more than 0");

      if (_spawnPoints.Count == 0)
        return;

      for (int i = 0; i < count; i++)
      {
        int j = Random.Range(0, _spawnPoints.Count - 1);
        Enemy enemy = _zenjectFactory.Instantiate(_prefab, _spawnPoints[j].transform.position, Quaternion.identity, transform);

        enemy.Init(_routePoints);
      }
    }
  }
}