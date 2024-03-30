using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
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
    private List<CoroutineDecorator> _respawners = new List<CoroutineDecorator>();

    public EnemyId EnemyId { get; private set; }

    [Inject]
    public void Construct(EnemyFactory enemyFactory, ICoroutineRunner coroutineRunner)
    {
      _enemyFactory = enemyFactory;
      _coroutineRunner = coroutineRunner;
    }

    public event Action<EnemyHealth> EnemyDied;

    public void Init(EnemyId enemyId, List<SpawnPoint> spawnPoints, int respawnTime)
    {
      EnemyId = enemyId;
      _spawnPoints = spawnPoints;
      _respawnTime = respawnTime;
    }

    private void OnDestroy()
    {
      // foreach (CoroutineDecorator coroutine in _respawners)
      // {
      //   if (coroutine == null)
      //     continue;
      //
      //   if (_coroutineRunner == null)
      //     continue;
      //
      //   coroutine.Stop();
      // }
      //
      // _respawners.Clear();
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
      if (_spawnPoints == null)
      {
        throw new InvalidOperationException(nameof(_spawnPoints));
      }

      int randomSpawnPointNumber = Random.Range(0, _spawnPoints.Count - 1);
      var enemy = _enemyFactory.Create(EnemyId, transform, _spawnPoints[randomSpawnPointNumber].transform.position, _spawnPoints);

      enemy.ComponentsProvider.Health.Died += OnEnemyDied;
    }

    private void OnEnemyDied(EnemyConfig config, EnemyHealth enemyHealth)
    {
      var coroutineDecorator = new CoroutineDecorator(_coroutineRunner, WaitAndSpawn);

      _respawners.Add(coroutineDecorator);

      coroutineDecorator.Start();

      enemyHealth.Died -= OnEnemyDied;

      EnemyDied?.Invoke(enemyHealth);
    }

    private IEnumerator WaitAndSpawn()
    {
      yield return new WaitForSeconds(_respawnTime);

      Spawn();
    }
  }
}