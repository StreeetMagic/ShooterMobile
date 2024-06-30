using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Bootstrap
{
  public class EnemyBootstrapState : State
  {
    public EnemyBootstrapState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }
  }
}