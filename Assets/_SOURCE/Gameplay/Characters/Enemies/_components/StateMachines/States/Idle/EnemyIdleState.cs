using System.Collections.Generic;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Idle
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

    public override void Tick()
    {
      base.Tick();
      _idleTimer.Tick();
    }

    public override void Exit()
    {
    }
  }
}