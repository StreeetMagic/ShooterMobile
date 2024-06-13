using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Characters;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.ActorUserInterfaces.LootSlots;
using Gameplay.Quests;
using Gameplay.Spawners.SpawnPoints;
using Infrastructure.ConfigServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Spawners
{
  public class EnemySpawner : MonoBehaviour
  {
    public Transform SpawnPointsContainer;

    private List<SpawnPoint> _spawnPoints;
    private int _respawnTime;
    private CoroutineDecorator _coroutine;

    [Inject] private ICoroutineRunner _coroutineRunner;
    [Inject] private QuestCompleter _questCompleter;
    [Inject] private EnemyLootSlotFactory _enemyLootSlotFactory;
    [Inject] private Enemy.Factory _enemyFactory;
    [Inject] private ConfigService _configService;

    public event Action<IHealth> EnemyDied;

    public EnemyTypeId EnemyId { get; private set; }
    public List<Enemy> Enemies { get; } = new();

    private void OnDisable()
    {
      Enemies.Clear();
    }

    public void Init(EnemyTypeId enemyId, List<SpawnPoint> spawnPoints, int respawnTime)
    {
      EnemyId = enemyId;
      _spawnPoints = spawnPoints;
      _respawnTime = respawnTime;
    }

    public void Spawn(int count)
    {
      if (_spawnPoints.Count == 0)
        return;

      for (int i = 0; i < count; i++)
        Spawn();
    }

    public void DeSpawnAll()
    {
      if (_coroutine != null)
        _coroutine.Stop();

      _coroutine = null;

      foreach (Enemy enemy in Enemies)
      {
        Destroy(enemy.gameObject);
      }

      Enemies.Clear();
    }

    private void Spawn()
    {
      if (_spawnPoints == null)
        throw new InvalidOperationException(nameof(_spawnPoints));

      if (transform == null)
        return;

      int randomSpawnPointNumber = Random.Range(0, _spawnPoints.Count - 1);

      Enemy enemy = _enemyFactory.Create(_configService.GetEnemyConfig(EnemyId), _spawnPoints, this);
      enemy.transform.position = _spawnPoints[randomSpawnPointNumber].transform.position;
      enemy.transform.SetParent(transform);

      Transform enemyLootSlotsContainer = enemy.GetComponentInChildren<EnemyLootSlotsContainer>().transform;
      _enemyLootSlotFactory.Create(enemyLootSlotsContainer, EnemyId);

      Enemies.Add(enemy);

      enemy.GetComponent<IHealth>().Died += OnEnemyDied;
    }

    private void OnEnemyDied(EnemyConfig config, IHealth enemyHealth)
    {
      _coroutine = new CoroutineDecorator(_coroutineRunner, WaitAndSpawn);

      _coroutine.Start();

      enemyHealth.Died -= OnEnemyDied;

      _questCompleter.OnEnemyKilled(config.Id);

      EnemyDied?.Invoke(enemyHealth);

      var component = enemyHealth.GetComponent<Enemy>();

      if (component == null)
        throw new InvalidOperationException(nameof(component));

      Enemies.Remove(component);
    }

    private IEnumerator WaitAndSpawn()
    {
      yield return new WaitForSeconds(_respawnTime);

      if (this == null)
        yield break;

      if (gameObject == null)
        yield break;

      Spawn();
    }
  }
}