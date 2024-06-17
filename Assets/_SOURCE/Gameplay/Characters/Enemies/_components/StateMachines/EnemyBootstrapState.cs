using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines
{
  public class EnemyBootstrapState : State
  {
    public EnemyBootstrapState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new System.NotImplementedException();
    }

    public override void Exit()
    {
      throw new System.NotImplementedException();
    }
  }
}