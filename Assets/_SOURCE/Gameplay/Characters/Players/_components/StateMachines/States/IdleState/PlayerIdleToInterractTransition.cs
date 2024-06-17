using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
{
  public class IdleToInterractTransition : Transition
  {
    public override void Tick()
    {
    }

    public IdleToInterractTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }
  }
}