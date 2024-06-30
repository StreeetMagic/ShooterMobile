using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.Animators;

namespace Gameplay.Characters.Players.StateMachines.States.MoveState
{
  public class PlayerMoveState : State
  {
    private readonly PlayerInputHandler _inputHandler;
    private readonly PlayerRotator _rotator;
    private readonly PlayerTargetHolder _targetHolder;
    private readonly PlayerAnimator _animator;
    private readonly PlayerWeaponMagazineReloader _playerWeaponMagazineReloader;

    public PlayerMoveState(List<Transition> transitions, PlayerInputHandler inputHandler,
      PlayerRotator rotator, PlayerTargetHolder targetHolder, PlayerAnimator animator,
      PlayerWeaponMagazineReloader playerWeaponMagazineReloader)
      : base(transitions)
    {
      _inputHandler = inputHandler;
      _rotator = rotator;
      _targetHolder = targetHolder;
      _animator = animator;
      _playerWeaponMagazineReloader = playerWeaponMagazineReloader;
    }

    public override void Enter()
    {
      _animator.PlayRunAnimation();
    }

    protected override void OnTick() 
    {
      _inputHandler.ReadInput();

      if (_targetHolder.HasTarget)
        _rotator.RotateTowardsDirection(_targetHolder.LookDirectionToTarget);
      else
        _rotator.RotateTowardsDirection(_inputHandler.GetDirection());

      if (_playerWeaponMagazineReloader.IsActive)
        _playerWeaponMagazineReloader.Tick();
    }

    public override void Exit()
    {
      _animator.Stop();
    }
  }
}