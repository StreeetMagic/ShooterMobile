using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Players.Factories;
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
    private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;

    [Inject]
    public void Construct(PlayerProvider playerProvider, Enemy enemy, EnemyMover mover,
      EnemyShootAtPlayer enemyShootAtPlayer, EnemyMoverToSpawnPoint enemyMoverToSpawnPoint)
    {
      _playerProvider = playerProvider;
      _enemy = enemy;
      _mover = mover;
      _enemyShootAtPlayer = enemyShootAtPlayer;
      _enemyMoverToSpawnPoint = enemyMoverToSpawnPoint;
    }

    private Transform PlayerTransform => _playerProvider.Player.transform;
    private float RunSpeed => _enemy.Config.RunSpeed;
    private Transform SpawnerTransform => _enemy.SpawnerTransform;

    private void FixedUpdate()
    {
      StartShooting();
      Move();
    }

    private void StartShooting()
    {
      float distance = (PlayerTransform.position - transform.position).magnitude;

      if (distance < _enemy.Config.Radius)
      {
        _enemyShootAtPlayer.enabled = true;
        enabled = false;
      }
    }

    private void Move()
    {
      var distanceToSpawner = (SpawnerTransform.position - transform.position).magnitude;

      if (distanceToSpawner < _enemy.Config.PatrolingRadius)
      {
        Vector3 direction = (PlayerTransform.position - transform.position).normalized;
        _mover.Move(direction, RunSpeed);
      }
      else
      {
        enabled = false;
        _enemyMoverToSpawnPoint.enabled = true;
      }
    }
  }
}