using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.HideWeaponState
{
  public class PlayerHideWeaponState : PlayerState
  {
    private readonly PlayerAnimator _playerAnimator;
    
    public PlayerHideWeaponState(List<PlayerTransition> transitions, PlayerAnimator playerAnimator) : base(transitions)
    {
      _playerAnimator = playerAnimator;
    }

    public override void Enter()
    {
      _playerAnimator.OffStateShooting();
    }

    public override void Exit()
    {
    }
  }
}