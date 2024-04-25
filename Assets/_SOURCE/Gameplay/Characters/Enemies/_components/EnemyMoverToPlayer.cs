using Gameplay.Characters.Enemies.Animators;
using Gameplay.Characters.Players._components.Factories;
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
    private EnemyAnimator _enemyAnimator;

    [Inject]
    public void Construct(PlayerProvider playerProvider, Enemy enemy, EnemyMover mover,
      EnemyShootAtPlayer enemyShootAtPlayer, EnemyAnimator enemyAnimator)
    {
      _playerProvider = playerProvider;
      _enemy = enemy;
      _mover = mover;
      _enemyShootAtPlayer = enemyShootAtPlayer;
      _enemyAnimator = enemyAnimator;
    }

    private float RunSpeed => _enemy.Config.RunSpeed;
    private Transform PlayerTransform => _playerProvider.Player.transform;
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
      _enemyAnimator.PlayRunAnimation();
    }
  }
}