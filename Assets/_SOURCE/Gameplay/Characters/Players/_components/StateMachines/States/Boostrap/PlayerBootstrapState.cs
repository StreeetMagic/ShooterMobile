using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using UnityEngine;

namespace Gameplay.Characters.Players.StateMachines.States.Boostrap
{
  public class PlayerBootstrapState : PlayerState
  {
    public PlayerBootstrapState(List<PlayerTransition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      Debug.Log("Зашли в PlayerBootstrapState");
    }

    public override void Exit()
    {
      Debug.Log("Вышли из PlayerBootstrapState");
    }
  }
}