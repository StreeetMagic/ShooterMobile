using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.BoostrapState
{
  public class PlayerBootstrapState : PlayerState
  {
    public PlayerBootstrapState(List<PlayerTransition> transitions) : base(transitions)
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