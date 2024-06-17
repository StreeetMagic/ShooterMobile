using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines._old.States.Tickables
{
  public class EnemyPatrolingState :  ITickable
  {
    private const float DistanceToRoutePoint = 0.2f;

    private readonly EnemyMover _mover;
    private readonly EnemyRoutePointsManager _enemyRoutePointsManager;
    private readonly EnemyReturnToSpawnStatus _returnToSpawnStatus;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;
    private readonly HitStatus _hitStatus;

    public EnemyPatrolingState(EnemyMover mover, EnemyRoutePointsManager enemyRoutePointsManager,
      EnemyReturnToSpawnStatus returnToSpawnStatus,
      EnemyAnimatorProvider animatorProvider, EnemyConfig config, Enemy enemy, HitStatus hitStatus)
    {
      _mover = mover;
      _enemyRoutePointsManager = enemyRoutePointsManager;
      _returnToSpawnStatus = returnToSpawnStatus;
      _animatorProvider = animatorProvider;
      _config = config;
      _enemy = enemy;
      _hitStatus = hitStatus;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
      _mover.Stop();
      _animatorProvider.Instance.StopWalkAnimation();
      _animatorProvider.Instance.StopRunAnimation();
    }

    public void Tick()
    {
      _mover.Move(_enemyRoutePointsManager.NextRoutePointTransform.position, GetMoveSpeed());

      float distance = Vector3.Distance(_enemyRoutePointsManager.NextRoutePointTransform.position, _enemy.transform.position);

      if (distance < DistanceToRoutePoint)
      {
        _enemyRoutePointsManager.SetRandomRoute();
        _returnToSpawnStatus.IsReturn = false;
        _hitStatus.Disable();
      }
    }

    private float GetMoveSpeed()
    {
      if (_returnToSpawnStatus.IsReturn)
      {
        _animatorProvider.Instance.PlayRunAnimation();
        return _config.RunSpeed;
      }
      else
      {
        _animatorProvider.Instance.PlayWalkAnimation();
        return _config.MoveSpeed;
      }
    }
  }
}