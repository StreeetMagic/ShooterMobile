using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.Animators;

namespace Gameplay.Characters.Players.StateMachines.States.LowWeaponState
{
  public class PlayerLowWeaponState : State
  {
    private readonly PlayerAnimator _playerAnimator;
    private readonly PlayerWeaponLowerer _playerWeaponLowerer;

    public PlayerLowWeaponState(List<Transition> transitions, PlayerAnimator playerAnimator, 
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