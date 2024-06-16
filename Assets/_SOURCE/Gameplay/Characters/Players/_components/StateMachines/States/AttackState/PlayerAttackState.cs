using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.AttackState
{
  public class PlayerAttackState : PlayerState
  {
    public PlayerAttackState(List<PlayerTransition> transitions) : base(transitions)
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