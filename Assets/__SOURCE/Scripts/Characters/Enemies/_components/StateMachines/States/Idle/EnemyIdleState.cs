using System.Collections.Generic;
using Characters.Enemies._components.TargetTriggers;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Idle
{
  public class EnemyIdleState : State
  {
    private readonly EnemyIdleTimer _idleTimer;
      
    public EnemyIdleState(List<Transition> transitions, EnemyIdleTimer idleTimer) : base(transitions)
    {
      _idleTimer = idleTimer;
    }

    public override void Enter()
    {
       _idleTimer.Reset();
    }

    protected override void OnTick()
    {
      _idleTimer.Tick();
    }

    public override void Exit()
    {
    }
  }
}