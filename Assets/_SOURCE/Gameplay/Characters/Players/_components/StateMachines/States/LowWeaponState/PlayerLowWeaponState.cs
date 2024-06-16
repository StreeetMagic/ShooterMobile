using System.Collections.Generic;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.LowWeaponState
{
  public class PlayerLowWeaponState : PlayerState
  {
    private readonly PlayerAnimator _playerAnimator;
    private readonly PlayerWeaponLowerer _playerWeaponLowerer;

    public PlayerLowWeaponState(List<PlayerTransition> transitions, PlayerAnimator playerAnimator, 
      PlayerWeaponLowerer playerWeaponLowerer) : base(transitions)
    {
      _playerAnimator = playerAnimator;
      _playerWeaponLowerer = playerWeaponLowerer;
    }

    public override void Enter()
    {
      _playerWeaponLowerer.ResetTime();
      _playerAnimator.OffStateShooting();
    }

    public override void Exit()
    {
    }
  }
}