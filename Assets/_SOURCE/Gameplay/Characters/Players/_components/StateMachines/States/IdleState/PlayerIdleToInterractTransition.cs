using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
{
  public class PlayerIdleToInterractTransition : Transition
  {
    public override void Tick()
    {
    }

    public PlayerIdleToInterractTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }
  }
}