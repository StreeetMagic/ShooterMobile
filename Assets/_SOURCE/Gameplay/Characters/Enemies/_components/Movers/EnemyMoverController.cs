using System;
using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Movers
{
  public class EnemyMoverController : MonoBehaviour
  {
    private EnemyMover _enemyMover;
    private RoutePointsManager _routePointsManager = new RoutePointsManager();
    private bool _isMoving;
    private EnemyHealth _enemyHealth;
    private Enemy _enemy;
    private CoroutineDecorator _coroutine;
    private HealthStatusController _healthStatusController;
    private EnemyAnimator _enemyAnimator;
    private ICoroutineRunner _coroutineRunner;
    private bool _isDestroyed;

    [Inject]
    private void Construct(EnemyHealth enemyHealth, EnemyMover enemyMover,
      HealthStatusController healthStatusController, ICoroutineRunner coroutineRunner, EnemyAnimator enemyAnimator, Enemy enemy)
    {
      _enemyMover = enemyMover;
      _enemyHealth = enemyHealth;
      _healthStatusController = healthStatusController;
      _coroutineRunner = coroutineRunner;
      _enemyAnimator = enemyAnimator;
      _enemy = enemy;
    }

    public void Init(List<SpawnPoint> routePoints)
    {
      _coroutine = new CoroutineDecorator(_coroutineRunner, MoveToTargetPosition);

      _routePointsManager.Init(routePoints, transform);
    }

    private float MoveSpeed => _enemyConfig.MoveSpeed;
    private float RunSpeed => _enemyConfig.RunSpeed;
    private EnemyConfig _enemyConfig => _enemy.Config;

    public void FixedUpdate()
    {
      _routePointsManager.FixedTick();

      if (_enemyHealth.IsDead || _isDestroyed)
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
      _isDestroyed = true;
      _coroutine = null;
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

      while (_enemyHealth.IsDead == false && !_isDestroyed)
      {
        Vector3 moveDirection = (_routePointsManager.TargetPosition - transform.position).normalized;

        _enemyMover.Move(moveDirection, Time.fixedDeltaTime, GetCurrentSpeed());

        yield return null;
      }

      if (!_isDestroyed)
      {
        yield return new WaitForSeconds(_enemyConfig.WaitTimeAfterMove);
      }

      _isMoving = false;
    }

    public void Dispose()
    {
      _coroutine = null;
    }
  }
}