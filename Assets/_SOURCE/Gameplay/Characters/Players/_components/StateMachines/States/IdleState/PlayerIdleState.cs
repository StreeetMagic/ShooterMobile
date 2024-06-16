using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using UnityEngine;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
{
  public class PlayerIdleState : PlayerState
  {
    public PlayerIdleState(List<PlayerTransition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      Debug.Log("Вошли в PlayerIdleState");
    }

    public override void Exit()
    {
      Debug.Log("Вышли из PlayerIdleState");
    }
  }
}