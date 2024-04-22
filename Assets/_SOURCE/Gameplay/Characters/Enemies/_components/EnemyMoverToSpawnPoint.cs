using System;
using Gameplay.Characters.Enemies.Animators;
using Gameplay.Characters.Enemies.Movers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMoverToSpawnPoint : MonoBehaviour
  {
    private EnemyMover _mover;
    private RoutePointsManager _routePointsManager;
    private Enemy _enemy;
    private EnemyMoverToPlayer _enemyMoverToPlayer;
    private HitStatus _hitStatus;
    private EnemyShootAtPlayer _enemyShootAtPlayer;
    private ReturnToSpawnStatus _returnToSpawnStatus;
    private EnemyAnimator _enemyAnimator;

    [Inject]
    public void Construct(EnemyMover mover, RoutePointsManager routePointsManager, Enemy enemy,
      EnemyMoverToPlayer enemyMoverToPlayer, HitStatus hitStatus, EnemyShootAtPlayer enemyShootAtPlayer,
      ReturnToSpawnStatus returnToSpawnStatus, ReturnToSpawnStatus returnToSpawnStatus1, EnemyAnimator enemyAnimator)
    {
      _mover = mover;
      _routePointsManager = routePointsManager;
      _enemy = enemy;
      _enemyMoverToPlayer = enemyMoverToPlayer;
      _hitStatus = hitStatus;
      _enemyShootAtPlayer = enemyShootAtPlayer;
      _returnToSpawnStatus = returnToSpawnStatus;
      _enemyAnimator = enemyAnimator;
    }

    private float MoveSpeed => _enemy.Config.MoveSpeed;
    private float RunSpeed => _enemy.Config.RunSpeed;

    private void OnEnable()
    {
      _enemyMoverToPlayer.enabled = false;
      _hitStatus.IsHit = false;
      _enemyShootAtPlayer.enabled = false;
    }

    private void FixedUpdate()
    {
      Vector3 direction = (_routePointsManager.NextRoutePointTransform.position - transform.position).normalized;

      _mover.Move(direction, GetMoveSpeed());
    }

    private float GetMoveSpeed()
    {
      if (_returnToSpawnStatus.IsReturn)
      {
        _enemyAnimator.PlayRunAnimation();
        return RunSpeed;
      }
      else
      {
        _enemyAnimator.PlayWalkAnimation();
        return MoveSpeed;
      }
    }
  }
}