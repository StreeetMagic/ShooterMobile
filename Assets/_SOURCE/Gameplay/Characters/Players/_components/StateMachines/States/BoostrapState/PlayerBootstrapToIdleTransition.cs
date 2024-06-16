using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using UnityEngine;

namespace Gameplay.Characters.Players.StateMachines.States.BoostrapState
{
  public class PlayerBootstrapToIdleTransition : PlayerTransition
  {
    public override void Tick()
    {
      Process(typeof(PlayerIdleState));
    }
  }
}