using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMoverToSpawnPoint : MonoBehaviour
  {
    [Inject] private EnemyMover _mover;
    [Inject] private EnemyRoutePointsManager _enemyRoutePointsManager;
    [Inject] private EnemyMoverToPlayer _enemyMoverToPlayer;
    [Inject] private HitStatus _hitStatus;
    [Inject] private EnemyShootAtPlayer _enemyShootAtPlayer;
    [Inject] private EnemyReturnToSpawnStatus _returnToSpawnStatus;
    [Inject] private EnemyAnimatorProvider _animatorProvider;
    [Inject] private EnemyConfig _config;

    private float MoveSpeed => _config.MoveSpeed;
    private float RunSpeed => _config.RunSpeed;

    private void OnEnable()
    {
      _enemyMoverToPlayer.enabled = false;
      _hitStatus.IsHit = false;
      _enemyShootAtPlayer.enabled = false;
    }

    private void FixedUpdate()
    {
      Vector3 direction = (_enemyRoutePointsManager.NextRoutePointTransform.position - transform.position).normalized;

      _mover.Move(direction, GetMoveSpeed());
    }

    private float GetMoveSpeed()
    {
      if (_returnToSpawnStatus.IsReturn)
      {
        _animatorProvider.Instance.PlayRunAnimation();
        return RunSpeed;
      }
      else
      {
        _animatorProvider.Instance.PlayWalkAnimation();
        return MoveSpeed;
      }
    }
  }
}