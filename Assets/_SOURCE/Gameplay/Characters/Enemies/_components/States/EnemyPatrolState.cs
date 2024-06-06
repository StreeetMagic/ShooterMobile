using PUNBALL.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyPatrolState : IState, ITickable
  {
    private readonly EnemyMover _mover;
    private readonly EnemyRoutePointsManager _enemyRoutePointsManager;
    private readonly EnemyReturnToSpawnStatus _returnToSpawnStatus;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;

    public EnemyPatrolState(
      EnemyMover mover,
      EnemyRoutePointsManager enemyRoutePointsManager,
      EnemyReturnToSpawnStatus returnToSpawnStatus,
      EnemyAnimatorProvider animatorProvider,
      EnemyConfig config,
      Enemy enemy)
    {
      _mover = mover;
      _enemyRoutePointsManager = enemyRoutePointsManager;
      _returnToSpawnStatus = returnToSpawnStatus;
      _animatorProvider = animatorProvider;
      _config = config;
      _enemy = enemy;

    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Tick()
    {
      _mover.Move(_enemyRoutePointsManager.NextRoutePointTransform.position, GetMoveSpeed());

      float distance = Vector3.Distance(_enemyRoutePointsManager.NextRoutePointTransform.position, _enemy.transform.position);

      if (distance < 0.1f)
      {
        _enemyRoutePointsManager.SetRandomRoute();
        _returnToSpawnStatus.IsReturn = false;
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