using System;
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
    private HealthStatusController _healthStatus;
    private EnemyShootAtPlayer _enemyShootAtPlayer;
    private EnemyReturnToSpawn _returnToSpawn;

    [Inject]
    public void Construct(EnemyMover mover, RoutePointsManager routePointsManager, Enemy enemy,
      EnemyMoverToPlayer enemyMoverToPlayer, HealthStatusController healthStatus, EnemyShootAtPlayer enemyShootAtPlayer,
      EnemyReturnToSpawn enemyReturnToSpawn)
    {
      _mover = mover;
      _routePointsManager = routePointsManager;
      _enemy = enemy;
      _enemyMoverToPlayer = enemyMoverToPlayer;
      _healthStatus = healthStatus;
      _enemyShootAtPlayer = enemyShootAtPlayer;
      _returnToSpawn = enemyReturnToSpawn;
    }

    private float MoveSpeed => _enemy.Config.MoveSpeed;

    private void OnEnable()
    {
      _enemyMoverToPlayer.enabled = false;
      _healthStatus.IsHit = false;
      _enemyShootAtPlayer.enabled = false;
    }

    private void FixedUpdate()
    {
      var direction = (_routePointsManager.NextRoutePointTransform.position - transform.position).normalized;

      _mover.Move(direction, MoveSpeed);
    }
  }
}