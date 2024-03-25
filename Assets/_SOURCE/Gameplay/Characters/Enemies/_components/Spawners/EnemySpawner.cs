using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.AssetProviders;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
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
    private ICoroutineRunner _coroutineRunner;
    private int _respawnTime;
    private List<Enemy> _enemies = new List<Enemy>();
    private List<CoroutineDecorator> _respawners = new List<CoroutineDecorator>();

    public EnemyId EnemyId { get; private set; }

    [Inject]
    public void Construct(EnemyFactory enemyFactory, ICoroutineRunner coroutineRunner)
    {
      _enemyFactory = enemyFactory;
      _coroutineRunner = coroutineRunner;
    }

    public void Init(EnemyId enemyId, List<SpawnPoint> spawnPoints, int respawnTime)
    {
      EnemyId = enemyId;
      _spawnPoints = spawnPoints;
      _respawnTime = respawnTime;
    }

    private void OnDestroy()
    {
      foreach (CoroutineDecorator respawner in _respawners)
      {
        respawner.Stop();
      }
      
      foreach (Enemy enemy in _enemies)
      {
        if (enemy == null)
          continue;
        
        _enemyFactory.Destroy(enemy);
      }
    }

    public void Spawn(int count)
    {
      if (_spawnPoints.Count == 0)
        return;

      for (int i = 0; i < count; i++)
      {
        Spawn();
      }
    }

    private void Spawn()
    {
      int randomSpawnPointNumber = Random.Range(0, _spawnPoints.Count - 1);
      var enemy = _enemyFactory.Create(EnemyId, transform, _spawnPoints[randomSpawnPointNumber].transform.position, _spawnPoints);
      _enemies.Add(enemy);
      enemy.GetComponentInChildren<Health>().Died += OnEnemyDied;
    }

    private void OnEnemyDied(EnemyConfig config, Health health)
    {
      var coroutineDecorator = new CoroutineDecorator(_coroutineRunner, WaitAndSpawn);

      coroutineDecorator.Start();

      _respawners.Add(coroutineDecorator);
    }

    private IEnumerator WaitAndSpawn()
    {
      yield return new WaitForSeconds(_respawnTime);

      Spawn();
    }
  }
}