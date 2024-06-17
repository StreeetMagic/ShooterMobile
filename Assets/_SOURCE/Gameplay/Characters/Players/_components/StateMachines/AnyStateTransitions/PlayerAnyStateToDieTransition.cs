using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Players.StateMachines.AnyStateTransitions
{
  public class AnyStateToDieTransition : Transition
  {
    public override void Tick()
    {
    }

    public AnyStateToDieTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }
  }
}