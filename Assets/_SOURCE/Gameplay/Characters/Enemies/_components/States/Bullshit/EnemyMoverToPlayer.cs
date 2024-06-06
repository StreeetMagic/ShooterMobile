using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMoverToPlayer : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private EnemyMover _mover;
    [Inject] private EnemyShootAtPlayer _enemyShootAtPlayer;
    [Inject] private EnemyAnimatorProvider _animatorProvider;
    [Inject] private EnemyConfig _config;
    [Inject] private Transform _spawnerTransform;
    [Inject] private EnemyReturnToSpawnStatus _returnToSpawnStatus;

    private float RunSpeed => _config.RunSpeed;
    private Transform PlayerTransform => _playerProvider.Player.transform;

    private void OnEnable()
    {
      _returnToSpawnStatus.IsReturn = false;
    }

    private void FixedUpdate()
    {
      Move();
    }

    private void Move()
    {
      float distanceToSpawner = (_spawnerTransform.position - transform.position).magnitude;

      if (distanceToSpawner < _config.PatrolingRadius)
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
      _mover.Move(PlayerTransform.position, RunSpeed);
      _animatorProvider.Instance.PlayRunAnimation();
    }
  }
}