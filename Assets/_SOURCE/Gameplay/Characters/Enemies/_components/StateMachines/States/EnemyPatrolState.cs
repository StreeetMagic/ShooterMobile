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
    private readonly Transform _transform;
    private readonly Enemy _enemy;

    public EnemyPatrolState(RoutePointsManager routePointsManager,
      StateMachine<IEnemyState> stateMachine,
      EnemyMover enemyMover, Transform transform, Enemy enemy)
    {
      _routePointsManager = routePointsManager;
      _stateMachine = stateMachine;
      _enemyMover = enemyMover;
      _transform = transform;
      _enemy = enemy;
    }
    
    private EnemyConfig Config => _enemy.ComponentsProvider.Config;

    public void Enter()
    {
      Debug.Log("EnemyPatrolState");
    }

    public void Exit()
    {
    }

    public void FixedTick()
    {
      Move();
    }

    private void Move()
    {
      Vector3 targetPosition = _routePointsManager.NextRoutePointTransform.position;

      Vector3 direction = (targetPosition - _transform.position).normalized;
      float distance = Vector3.Distance(_transform.position, targetPosition);

      if (distance > 0.1f)
        _enemyMover.Move(direction, Time.fixedDeltaTime, Config.MoveSpeed);
      else
        _stateMachine.Enter<EnemyWaitState>();
    }
  }
}