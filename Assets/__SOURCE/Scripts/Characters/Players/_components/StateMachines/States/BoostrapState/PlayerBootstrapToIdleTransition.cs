using Characters.FiniteStateMachines;
using Characters.Players._components.StateMachines.States.IdleState;

namespace Characters.Players._components.StateMachines.States.BoostrapState
{
  public class PlayerBootstrapToIdleTransition : Transition
  {
    public override void Tick()
    {
      Enter<PlayerIdleState>();
    }
  }
}