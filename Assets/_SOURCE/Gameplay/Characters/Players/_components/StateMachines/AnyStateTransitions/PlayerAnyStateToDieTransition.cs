using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Players.StateMachines.AnyStateTransitions
{
  public class PlayerAnyStateToDieTransition : Transition
  {
    public override void Tick()
    {
    }

    public PlayerAnyStateToDieTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }
  }
}