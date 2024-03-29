using Infrastructure.StateMachines;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyBootstrapState : IEnemyState
  {
    private readonly StateMachine<IEnemyState> _stateMachine;

    public EnemyBootstrapState(StateMachine<IEnemyState> stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public void Enter()
    {
      Debug.Log("EnemyBootstrapState");
      _stateMachine.Enter<EnemyWaitState>();
    }

    public void Exit()
    {
    }
  }
}