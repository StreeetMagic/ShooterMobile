using System;
using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Players._components.StateMachines.States.DieState
{
  public class PlayerDieState : State
  {
    public PlayerDieState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }
}