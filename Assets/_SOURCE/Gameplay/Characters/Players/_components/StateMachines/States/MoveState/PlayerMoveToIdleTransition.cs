using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using Inputs;

namespace Gameplay.Characters.Players.StateMachines.States.MoveState
{
  public class PlayerMoveToIdleTransition : PlayerTransition
  {
    private readonly InputService _inputService;
    private readonly PlayerTargetHolder _targetHolder;

    public PlayerMoveToIdleTransition(InputService inputService, PlayerTargetHolder targetHolder)
    {
      _inputService = inputService;
      _targetHolder = targetHolder;
    }

    public override void Tick()
    {
       if (_inputService.HasMoveInput)
        return;
       
       Process(typeof(PlayerIdleState));
    }
  }
}