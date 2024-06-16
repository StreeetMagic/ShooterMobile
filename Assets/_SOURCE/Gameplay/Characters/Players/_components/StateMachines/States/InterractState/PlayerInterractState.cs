using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.InterractState
{
  public class PlayerInterractState : PlayerState
  {
    public PlayerInterractState(List<PlayerTransition> transitions) : base(transitions)
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