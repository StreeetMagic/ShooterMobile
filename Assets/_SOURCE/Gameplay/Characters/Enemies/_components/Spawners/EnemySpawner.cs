using System;
using System.Collections.Generic;
using System.Linq;
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
    public Transform SpawnPointsContainer;

    private List<SpawnPoint> _spawnPoints;
    private EnemyFactory _enemyFactory;

    public EnemyId EnemyId { get; private set; }

    [Inject]
    public void Construct(EnemyFactory enemyFactory)
    {
      _enemyFactory = enemyFactory;
    }

    public void Init(EnemyId enemyId, List<SpawnPoint> spawnPoints)
    {
      EnemyId = enemyId;
      _spawnPoints = spawnPoints;
    }

    public void Spawn(int count)
    {
      if (_spawnPoints.Count == 0)
        return;

      for (int i = 0; i < count; i++)
      {
        int randomSpawnPointNumber = Random.Range(0, _spawnPoints.Count - 1);
        _enemyFactory.Create(EnemyId, transform, _spawnPoints[randomSpawnPointNumber].transform.position, _spawnPoints);
      }
    }
  }
}