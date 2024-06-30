using Characters.Enemies._components.StateMachines.States.Idle;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Bootstrap
{
  public class EnemyBootstrapToIdleTransition : Transition
  {
    public override void Tick()
    {
      Enter<EnemyIdleState>();
    }
  }
}