using System.Collections.Generic;
using System.Linq;
using _SOURCE.Gameplay.Characters.Enemies;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;
using Zenject;

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
    for (int i = 0; i < count; i++)
    {
      int j = Random.Range(0, _spawnPoints.Count - 1);

      _zenjectFactory.Instantiate(_prefab, _spawnPoints[j].transform.position, Quaternion.identity, transform);
    }
  }
}