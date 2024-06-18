using Gameplay.Characters.Enemies.StateMachines.States.Chase;
using Gameplay.Characters.FiniteStateMachines;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.ThrowGrenade
{
  public class EnemyThrowGrenadeToChaseTransition : Transition
  {
    private float _timeLeft;
    private readonly EnemyConfig _config;

    public EnemyThrowGrenadeToChaseTransition(EnemyConfig config)
    {
      _config = config;
      _timeLeft = config.GrenadeThrowDuration;
    }

    public override void Tick()
    {
      _timeLeft -= Time.deltaTime;

      if (_timeLeft < 0)
      {
        _timeLeft = _config.GrenadeThrowDuration;

        Enter<EnemyChaseState>();
      }
    }
  }
}