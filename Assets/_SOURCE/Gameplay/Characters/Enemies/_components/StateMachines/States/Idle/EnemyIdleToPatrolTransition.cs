using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Idle
{
  public class EnemyIdleToPatrolTransition : Transition
  {
    public EnemyIdleToPatrolTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
    }
  }
}