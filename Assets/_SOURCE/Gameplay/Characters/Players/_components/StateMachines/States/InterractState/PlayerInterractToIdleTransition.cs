using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Players.StateMachines.States.InterractState
{
  public class InterractToIdleTransition : Transition
  {
    public override void Tick()
    {
      throw new NotImplementedException();
    }

    public InterractToIdleTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }
  }
}