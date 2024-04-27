using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.ActorUserInterfaces.LootSlots;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.CoroutineRunners;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using Quests;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.Spawners
{
  public class EnemySpawner : MonoBehaviour
  {
    public Transform SpawnPointsContainer;

    private List<SpawnPoint> _spawnPoints;
    private int _respawnTime;

    [Inject] private ICoroutineRunner _coroutineRunner;
    [Inject] private QuestCompleter _questCompleter;
    [Inject] private EnemyLootSlotFactory _enemyLootSlotFactory;
    [Inject] private Enemy.Factory _enemyFactory;
    [Inject] private IStaticDataService _staticDataService;

    public event Action<EnemyHealth> EnemyDied;

    public EnemyId EnemyId { get; private set; }
    public List<Enemy> Enemies { get; } = new List<Enemy>();

    private void OnDisable()
    {
      Enemies.Clear();
    }

    public void Init(EnemyId enemyId, List<SpawnPoint> spawnPoints, int respawnTime)
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

    private void Spawn()
    {
      if (_spawnPoints == null)
        throw new InvalidOperationException(nameof(_spawnPoints));

      int randomSpawnPointNumber = Random.Range(0, _spawnPoints.Count - 1);

      Enemy enemy = _enemyFactory.Create(_staticDataService.GetEnemyConfig(EnemyId), _spawnPoints, transform);
      enemy.transform.position = _spawnPoints[randomSpawnPointNumber].transform.position;
      enemy.transform.SetParent(transform);

      Transform enemyLootSlotsContainer = enemy.GetComponentInChildren<EnemyLootSlotsContainer>().transform;
      _enemyLootSlotFactory.Create(enemyLootSlotsContainer, EnemyId);

      Enemies.Add(enemy);

      enemy.GetComponent<EnemyHealth>().Died += OnEnemyDied;
    }

    private void OnEnemyDied(EnemyConfig config, EnemyHealth enemyHealth)
    {
      var coroutineDecorator = new CoroutineDecorator(_coroutineRunner, WaitAndSpawn);

      coroutineDecorator.Start();

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

      Spawn();
    }
  }
}