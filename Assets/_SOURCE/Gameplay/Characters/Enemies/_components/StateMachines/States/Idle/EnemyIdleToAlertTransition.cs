using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Idle
{
  public class EnemyIdleToAlertTransition : Transition
  {
    public EnemyIdleToAlertTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
    }
  }
}