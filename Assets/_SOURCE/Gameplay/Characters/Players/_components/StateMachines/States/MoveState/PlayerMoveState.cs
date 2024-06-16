using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using UnityEngine;

namespace Gameplay.Characters.Players.StateMachines.States.MoveState
{
  public class PlayerMoveState : PlayerState
  {
    private readonly PlayerInputHandler _inputHandler;

    public PlayerMoveState(List<PlayerTransition> transitions, PlayerInputHandler inputHandler)
      : base(transitions)
    {
      _inputHandler = inputHandler;
    }

    public override void Enter()
    {
      Debug.Log("Enter Move State");
    }

    public override void Tick()
    {
      base.Tick();
      _inputHandler.ReadInput();
    }

    public override void Exit()
    {
      Debug.Log("Exit Move State");
    }
  }
}