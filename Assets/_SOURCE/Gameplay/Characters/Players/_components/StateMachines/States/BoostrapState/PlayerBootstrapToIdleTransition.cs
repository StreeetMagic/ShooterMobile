using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.IdleState;

namespace Gameplay.Characters.Players.StateMachines.States.BoostrapState
{
  public class PlayerBootstrapToIdleTransition : Transition
  {
    public override void Tick()
    {
      Process<PlayerIdleState>();
    }
  }
}