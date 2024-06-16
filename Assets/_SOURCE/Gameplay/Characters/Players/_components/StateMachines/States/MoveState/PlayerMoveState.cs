using System.Collections.Generic;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.MoveState
{
  public class PlayerMoveState : PlayerState
  {
    private readonly PlayerInputHandler _inputHandler;
    private readonly PlayerRotator _rotator;
    private readonly PlayerTargetHolder _targetHolder;
    private readonly PlayerAnimator _animator;

    public PlayerMoveState(List<PlayerTransition> transitions, PlayerInputHandler inputHandler, 
      PlayerRotator rotator, PlayerTargetHolder targetHolder, PlayerAnimator animator)
      : base(transitions)
    {
      _inputHandler = inputHandler;
      _rotator = rotator;
      _targetHolder = targetHolder;
      _animator = animator;
    }

    public override void Enter()
    {
      _animator.PlayRunAnimation();
    }

    public override void Tick()
    {
      base.Tick();
      _inputHandler.ReadInput();
      
      if (_targetHolder.HasTarget)
        _rotator.RotateTowardsDirection(_targetHolder.LookDirectionToTarget);
      else
      _rotator.RotateTowardsDirection(_inputHandler.GetDirection());
    }

    public override void Exit()
    {
      _animator.Stop();
    }
  }
}