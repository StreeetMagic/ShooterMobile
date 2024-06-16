using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.HideWeaponState
{
  public class PlayerHideWeaponState : PlayerState
  {
    public PlayerHideWeaponState(List<PlayerTransition> transitions) : base(transitions)
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