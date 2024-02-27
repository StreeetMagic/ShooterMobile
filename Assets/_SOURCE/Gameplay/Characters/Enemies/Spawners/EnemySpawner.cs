using System.Collections.Generic;
using System.Linq;
using _SOURCE.Gameplay.Characters.Enemies;
using Infrastructure.Services.AssetProviders;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
  private IAssetProvider _assetProvider;
  private Enemy _prefab;
  private List<SpawnPoint> _spawnPoints;
  private List<RoutePoint> _routePoints;

  public EnemyId EnemyId { get; private set; }

  [Inject]
  public void Construct(IAssetProvider assetProvider)
  {
    _assetProvider = assetProvider;

    _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
    _routePoints = GetComponentsInChildren<RoutePoint>().ToList();
  }

  public void Init(EnemyId enemyId)
  {
    EnemyId = enemyId;
    _prefab = _assetProvider.ForEnemy(EnemyId);
  }
}