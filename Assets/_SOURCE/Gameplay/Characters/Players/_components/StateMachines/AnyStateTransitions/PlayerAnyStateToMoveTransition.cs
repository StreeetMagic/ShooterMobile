using System;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.MoveState;
using Inputs;

namespace Gameplay.Characters.Players.StateMachines.AnyStateTransitions
{
  public class PlayerAnyStateToMoveTransition : PlayerTransition
  {
    private readonly InputService _inputService;

    public PlayerAnyStateToMoveTransition(InputService inputService)
    {
      _inputService = inputService;
    }

    public override void Tick()
    {
      if (_inputService.HasMoveInput)
        Process(typeof(PlayerMoveState));
    }
  }
}