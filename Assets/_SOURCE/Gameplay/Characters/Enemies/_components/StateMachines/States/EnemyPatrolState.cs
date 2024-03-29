using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Movers;
using Infrastructure.StateMachines;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyPatrolState : IEnemyState, IFixedTickable
  {
    private readonly StateMachine<IEnemyState> _stateMachine;
    private readonly RoutePointsManager _routePointsManager;
    private readonly EnemyMover _enemyMover;
    private readonly Enemy _enemy;
    private bool _isActive;

    public EnemyPatrolState(RoutePointsManager routePointsManager,
      StateMachine<IEnemyState> stateMachine,
      EnemyMover enemyMover, Enemy enemy)
    {
      _routePointsManager = routePointsManager;
      _stateMachine = stateMachine;
      _enemyMover = enemyMover;
      _enemy = enemy;
    }

    private EnemyConfig Config => _enemy.ComponentsProvider.Config;

    public void Enter()
    {
      _isActive = true;
    }

    public void Exit()
    {
      _isActive = false;
    }

    public void FixedTick()
    {
      if (!_isActive)
      {
        return;
      }

      Move();
    }

    private void Move()
    {
      Vector3 targetPosition = _routePointsManager.NextRoutePointTransform.position;

      Vector3 direction = (targetPosition - _enemy.transform.position).normalized;
      float distance = Vector3.Distance(_enemy.transform.position, targetPosition);

      if (distance > 0.1f)
      {
        _enemyMover.Move(direction, Time.fixedDeltaTime, Config.MoveSpeed);
      }
      else
      {
        _stateMachine.Enter<EnemyWaitState>();
      }
    }
  }
}