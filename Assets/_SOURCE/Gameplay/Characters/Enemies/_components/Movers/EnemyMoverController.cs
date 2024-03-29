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
  public class EnemyMoverController : IFixedTickable, IDisposable
  {
    private readonly EnemyMover _enemyMover;
    private readonly EnemyHealth _enemyHealth;
    private readonly Enemy _enemy;
    private readonly HealthStatusController _healthStatusController;
    private readonly EnemyAnimator _enemyAnimator;
    private readonly Transform _transform;

    private bool _isMoving;
    private bool _isDestroyed;
    private CoroutineDecorator _coroutine;
    private RoutePointsManager _routePointsManager;

    private EnemyMoverController(EnemyHealth enemyHealth, EnemyMover enemyMover,
      HealthStatusController healthStatusController, ICoroutineRunner coroutineRunner, EnemyAnimator enemyAnimator,
      Enemy enemy, Transform transform)
    {
      _enemyMover = enemyMover;
      _enemyHealth = enemyHealth;
      _healthStatusController = healthStatusController;
      _enemyAnimator = enemyAnimator;
      _enemy = enemy;
      _transform = transform;

      _coroutine = new CoroutineDecorator(coroutineRunner, MoveToTargetPosition);
    }

    private List<SpawnPoint> RoutePoints => _enemy.ComponentsProvider.SpawnPoints;
    private float MoveSpeed => _enemyConfig.MoveSpeed;
    private float RunSpeed => _enemyConfig.RunSpeed;
    private EnemyConfig _enemyConfig => _enemy.ComponentsProvider.Config;

    public void FixedTick()
    {
      // _routePointsManager.FixedTick();

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

    public void Dispose()
    {
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
        Vector3 moveDirection = (_routePointsManager.NextRoutePointTransform.position - _transform.position).normalized;

        _enemyMover.Move(moveDirection, Time.fixedDeltaTime, GetCurrentSpeed());

        yield return null;
      }

      if (!_isDestroyed)
      {
        yield return new WaitForSeconds(_enemyConfig.WaitTimeAfterMove);
      }

      _isMoving = false;
    }
  }
}