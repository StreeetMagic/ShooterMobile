using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
{
  public class PlayerIdleState : PlayerState
  {
    public PlayerIdleState(List<PlayerTransition> transitions) : base(transitions)
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