using System.Collections.Generic;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.RiseWeaponState
{
  public class PlayerRiseWeaponState : PlayerState
  {
    private readonly PlayerWeaponRaiser _weaponRaiser;
    private readonly PlayerAnimator _animator;
    private readonly PlayerRotator _rotator;
    private readonly PlayerTargetHolder _targetHolder;

    public PlayerRiseWeaponState(List<PlayerTransition> transitions,
      PlayerWeaponRaiser playerWeaponRaiser, PlayerAnimator playerAnimator, PlayerRotator rotator,
      PlayerTargetHolder targetHolder)
      : base(transitions)
    {
      _weaponRaiser = playerWeaponRaiser;
      _animator = playerAnimator;
      _rotator = rotator;
      _targetHolder = targetHolder;
    }

    public override void Enter()
    {
      _weaponRaiser.ResetTime();
      _animator.OnStateShooting();
    }

    public override void Tick()
    {
      base.Tick();

      if (_targetHolder.HasTarget)
        _rotator.RotateTowardsDirection(_targetHolder.LookDirectionToTarget);
    }

    public override void Exit()
    {
    }
  }
}