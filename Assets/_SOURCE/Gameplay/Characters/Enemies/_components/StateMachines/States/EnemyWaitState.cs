using System.Collections;
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

    public EnemyWaitState(ICoroutineRunner coroutineRunner, StateMachine<IEnemyState> stateMachine)
    {
      _stateMachine = stateMachine;
      _coroutine = new CoroutineDecorator(coroutineRunner, DoWait);
    }

    public void Enter()
    {
      _coroutine.Start();
    }

    private IEnumerator DoWait()
    {
      yield return new WaitForSeconds(1f);

      _stateMachine.Enter<EnemyPatrolState>();
    }

    public void Exit()
    {
    }
  }
}