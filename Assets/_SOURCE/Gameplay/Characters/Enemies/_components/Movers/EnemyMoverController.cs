using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Movers
{
  [RequireComponent(typeof(EnemyMover))]
  public class EnemyMoverController : MonoBehaviour
  {
    private EnemyMover _enemyMover;
    private RoutePointsManager _routePointsManager = new RoutePointsManager();
    private bool _isMoving;
    private Health _health;
    private EnemyConfig _enemyConfig;
    private CoroutineDecorator _coroutine;
    private HealthStatusController _healthStatusController;
    private EnemyAnimator _enemyAnimator;
    private ICoroutineRunner _coroutineRunner;

    public void Init(EnemyConfig enemyConfig, Health health, List<SpawnPoint> routePoints,
      HealthStatusController healthStatusController, EnemyAnimator enemyAnimator, ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
      _enemyAnimator = enemyAnimator;
      _coroutine = new CoroutineDecorator(_coroutineRunner, MoveToTargetPosition);
      _enemyConfig = enemyConfig;
      _enemyMover = GetComponent<EnemyMover>();
      _health = health;
      _healthStatusController = healthStatusController;
      _routePointsManager.Init(routePoints, transform);
    }

    private float MoveSpeed => _enemyConfig.MoveSpeed;
    private float RunSpeed => _enemyConfig.RunSpeed;

    public void FixedUpdate()
    {
      _routePointsManager.FixedTick();

      if (_health.IsDead)
      {
        _enemyMover.Disable();
        return;
      }

      SetAnimation();

      if (_isMoving)
        return;

      _coroutine.Start();
    }

    private void OnDestroy()
    {
      _routePointsManager.Dispose();

      _coroutine?.Stop();
    }

    private void SetAnimation()
    {
      if (_healthStatusController.IsHit)
        _enemyAnimator.PlayRunAnimation();
      else
        _enemyAnimator.PlayWalkAnimation();
    }

    private float GetCurrentSpeed() =>
      _healthStatusController.IsHit
        ? RunSpeed
        : MoveSpeed;

    private IEnumerator MoveToTargetPosition()
    {
      _isMoving = true;

      while (_health.IsDead == false)
      {
        Vector3 moveDirection = (_routePointsManager.TargetPosition - transform.position).normalized;

        _enemyMover.Move(moveDirection, Time.fixedDeltaTime, GetCurrentSpeed());

        yield return null;
      }

      yield return new WaitForSeconds(_enemyConfig.WaitTimeAfterMove);

      _isMoving = false;
    }
  }
}