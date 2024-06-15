using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.Idle;
using UnityEngine;

namespace Gameplay.Characters.Players.StateMachines.States.Boostrap.Transitions
{
  public class PlayerBootstrapToIdleTransition : PlayerTransition
  {
    private float _timeLeft;
    private float _timeToExit = 3f;

    public override void Tick()
    {
      _timeLeft += Time.deltaTime;

      if (_timeLeft > _timeToExit)
        Process(typeof(PlayerIdleState));
    }
  }
}