using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Players.StateMachines.States.InterractState
{
  public class InterractToRiseWeaponTransition : Transition
  {
    public override void Tick()
    {
      throw new NotImplementedException();
    }

    public InterractToRiseWeaponTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }
  }
}