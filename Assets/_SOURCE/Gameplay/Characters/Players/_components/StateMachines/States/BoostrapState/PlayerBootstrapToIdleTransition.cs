using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.IdleState;

namespace Gameplay.Characters.Players.StateMachines.States.BoostrapState
{
  public class BootstrapToIdleTransition : Transition
  {
    public override void Tick()
    {
      Process<PlayerIdleState>();
    }

    public BootstrapToIdleTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }
  }
}