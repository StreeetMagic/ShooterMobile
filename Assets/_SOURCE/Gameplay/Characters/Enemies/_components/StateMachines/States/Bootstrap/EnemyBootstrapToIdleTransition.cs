using System;
using Gameplay.Characters.Enemies.StateMachines.States.Idle;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Bootstrap
{
  public class EnemyBootstrapToIdleTransition : Transition
  {
    public EnemyBootstrapToIdleTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
       Process<EnemyIdleState>();
    }
  }
}