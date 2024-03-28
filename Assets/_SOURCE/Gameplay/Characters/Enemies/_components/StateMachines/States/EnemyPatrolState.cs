using System.Collections;
using Gameplay.Characters.Enemies.Movers;
using Infrastructure.CoroutineRunners;
using Infrastructure.StateMachines;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyPatrolState : IEnemyState
  {
    private CoroutineDecorator _coroutine;
    private StateMachine<IEnemyState> _stateMachine;
    private readonly RoutePointsManager _routePointsManager;
    private readonly EnemyMover _enemyMover;

    public EnemyPatrolState(RoutePointsManager routePointsManager, StateMachine<IEnemyState> stateMachine, EnemyMover enemyMover, ICoroutineRunner coroutineRunner)
    {
      _coroutine = new CoroutineDecorator(coroutineRunner, MoveToNextPoint);
      _routePointsManager = routePointsManager;
      _stateMachine = stateMachine;
      _enemyMover = enemyMover;
    }

    public void Enter()
    {
      _routePointsManager.SetRandomRoute();
      _coroutine.Start();
    }

    public void Exit()
    {
    }

    private IEnumerator MoveToNextPoint()
    {
      while (_routePointsManager.DistanceToNextRoutePoint > 0.1f)
      {
        _enemyMover.Move(_routePointsManager.DirectionToNextRoutePoint, Time.fixedDeltaTime, 10f);
        yield return null;
      }

      _stateMachine.Enter<EnemyWaitState>();
    }
  }
}