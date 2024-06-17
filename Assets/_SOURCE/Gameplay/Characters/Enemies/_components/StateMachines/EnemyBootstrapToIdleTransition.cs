using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyBootstrapToIdleTransition : Transition
  {
    public EnemyBootstrapToIdleTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}