using Characters.FiniteStateMachines;
using Characters.Players._components.StateMachines.States.IdleState;
using Inputs;

namespace Characters.Players._components.StateMachines.States.MoveState
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

      Enter<PlayerIdleState>();
    }
  }
}