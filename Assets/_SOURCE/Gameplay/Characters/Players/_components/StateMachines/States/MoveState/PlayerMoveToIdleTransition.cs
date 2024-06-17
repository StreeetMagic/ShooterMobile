using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using Inputs;

namespace Gameplay.Characters.Players.StateMachines.States.MoveState
{
  public class PlayerMoveToIdleTransition : Transition
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