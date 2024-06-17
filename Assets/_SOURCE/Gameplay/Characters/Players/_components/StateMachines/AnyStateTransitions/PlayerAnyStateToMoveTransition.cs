using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.StateMachines.States.MoveState;
using Inputs;

namespace Gameplay.Characters.Players.StateMachines.AnyStateTransitions
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
        Process<PlayerMoveState>();
      }
    }
  }
}