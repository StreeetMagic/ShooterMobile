using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using Inputs;

namespace Gameplay.Characters.Players.StateMachines.States.MoveState
{
  public class PlayerMoveToIdleTransition : PlayerTransition
  {
    private readonly InputService _inputService;

    public PlayerMoveToIdleTransition(InputService inputService)
    {
      _inputService = inputService;
    }

    public override void Tick()
    {
      if (_inputService.HasMoveInput)
        return;

      Process<PlayerIdleState>();
    }
  }
}