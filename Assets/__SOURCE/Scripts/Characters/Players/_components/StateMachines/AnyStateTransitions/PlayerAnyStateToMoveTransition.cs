using Characters.FiniteStateMachines;
using Characters.Players._components.Animators;
using Characters.Players._components.StateMachines.States.MoveState;
using Inputs;

namespace Characters.Players._components.StateMachines.AnyStateTransitions
{
  public class PlayerAnyStateToMoveTransition : Transition
  {
    private readonly InputService _inputService;
    private readonly PlayerAnimator _playerAnimator;

    public PlayerAnyStateToMoveTransition(InputService inputService, PlayerAnimator playerAnimator)
    {
      _inputService = inputService;
      _playerAnimator = playerAnimator;
    }

    public override void Tick()
    {
      if (_inputService.HasMoveInput)
      {
        _playerAnimator.OffStateShooting();
        Enter<PlayerMoveState>();
      }
    }
  }
}