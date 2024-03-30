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
    private bool _isActive = false;

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
      Debug.Log(_isActive);

      if (_stateMachine.ActiveState == this)
      {
        _isActive = true;
      }

      if (_isActive == false)
      {
        // Debug.Log("case 1");
        return;
      }

      Move();
    }

    private void Move()
    {
      if (AwayFrom(TargetPosition()))
      {
        //  Debug.Log("case 2");
        Move(TargetPosition());
      }
      else
      {
        // Debug.Log("case 3");
        EnterEnemyWaitState();
      }
    }

    private void EnterEnemyWaitState() =>
      _stateMachine.Enter<EnemyWaitState>();

    private Vector3 TargetPosition() =>
      _routePointsManager.NextRoutePointTransform.position;

    private void Move(Vector3 targetPosition) =>
      _enemyMover.Move(Direction(targetPosition), Time.fixedDeltaTime, Config.MoveSpeed);

    private Vector3 Direction(Vector3 targetPosition) =>
      (targetPosition - _enemy.transform.position).normalized;

    private bool AwayFrom(Vector3 targetPosition) =>
      Distance(targetPosition) > 0.1f;

    private float Distance(Vector3 targetPosition) =>
      Vector3.Distance(_enemy.transform.position, targetPosition);
  }
}