using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Players.Factories;
using Loggers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMoverToPlayer : MonoBehaviour
  {
    private PlayerProvider _playerProvider;
    private Enemy _enemy;
    private EnemyMover _mover;
    private EnemyShootAtPlayer _enemyShootAtPlayer;
    private ReturnToSpawnStatus _returnToSpawnStatus;
    private DebugLogger _logger;

    [Inject]
    public void Construct(PlayerProvider playerProvider, Enemy enemy, EnemyMover mover,
      EnemyShootAtPlayer enemyShootAtPlayer, ReturnToSpawnStatus returnToSpawnStatus, DebugLogger logger)
    {
      _playerProvider = playerProvider;
      _enemy = enemy;
      _mover = mover;
      _enemyShootAtPlayer = enemyShootAtPlayer;
      _returnToSpawnStatus = returnToSpawnStatus;
      _logger = logger;
    }

    private Transform PlayerTransform => _playerProvider.Player.transform;
    private float RunSpeed => _enemy.Config.RunSpeed;
    private Transform SpawnerTransform => _enemy.SpawnerTransform;

    private void FixedUpdate()
    {
      if (DistanceToSpawnPoint())
      {
        _logger.Log("ТО ЧТО НАДо");
        _returnToSpawnStatus.IsReturn = true;
      }

      StartShooting();
      Move();
    }

    private void StartShooting()
    {
      float distance = (PlayerTransform.position - transform.position).magnitude;

      if (distance < _enemy.Config.Radius)
      {
        _enemyShootAtPlayer.enabled = true;
      }
    }

    private void Move()
    {
      float distanceToSpawner = (SpawnerTransform.position - transform.position).magnitude;

      if (distanceToSpawner < _enemy.Config.PatrolingRadius)
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
      Vector3 direction = (PlayerTransform.position - transform.position).normalized;
      _mover.Move(direction, RunSpeed);
    }

    private bool DistanceToSpawnPoint()
    {
      float distance = Vector3.Distance(transform.position, _enemy.SpawnerTransform.position);
      int configPatrolingRadius = _enemy.Config.PatrolingRadius;

      _logger.Log($"{distance} < {configPatrolingRadius}");

      return distance >= configPatrolingRadius;
    }
  }
}