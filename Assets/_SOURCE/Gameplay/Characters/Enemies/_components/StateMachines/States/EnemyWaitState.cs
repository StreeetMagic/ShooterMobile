using System.Collections;
using Gameplay.Characters.Enemies.Movers;
using Infrastructure.CoroutineRunners;
using Infrastructure.StateMachines;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyWaitState : IEnemyState
  {
    private CoroutineDecorator _coroutine;
    private StateMachine<IEnemyState> _stateMachine;
    private RoutePointsManager _routePointsManager;

    public EnemyWaitState(ICoroutineRunner coroutineRunner, StateMachine<IEnemyState> stateMachine,
      RoutePointsManager routePointsManager)
    {
      _stateMachine = stateMachine;
      _routePointsManager = routePointsManager;
      _coroutine = new CoroutineDecorator(coroutineRunner, DoWait);
    }

    public void Enter()
    {
      _coroutine.Start();
    }

    public void Exit()
    {
      _coroutine.Stop();
    }

    private IEnumerator DoWait()
    {
      yield return new WaitForSeconds(1f);

      _routePointsManager.SetRandomRoute();
      _stateMachine.Enter<EnemyPatrolState>();
    }
  }
}