using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.MoveState
{
  public class PlayerMoveState : PlayerState
  {
    private readonly PlayerInputHandler _inputHandler;
    private readonly PlayerRotator _rotator;
    private readonly PlayerTargetHolder _targetHolder;

    public PlayerMoveState(List<PlayerTransition> transitions, PlayerInputHandler inputHandler, 
      PlayerRotator rotator, PlayerTargetHolder targetHolder)
      : base(transitions)
    {
      _inputHandler = inputHandler;
      _rotator = rotator;
      _targetHolder = targetHolder;
    }

    public override void Enter()
    {
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
    }
  }
}