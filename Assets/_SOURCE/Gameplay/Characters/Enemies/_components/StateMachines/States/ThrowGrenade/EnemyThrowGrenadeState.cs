using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.ThrowGrenade
{
  public class EnemyThrowGrenadeState : State
  {
    private readonly EnemyConfig _config;
    private readonly EnemyGrenadeThrower _configGrenadeThrower;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyToPlayerRotator _rotator;
    private readonly EnemyGrenadeThrowTimer _grenadeThrowTimer;

    private bool _thrown;

    public EnemyThrowGrenadeState(List<Transition> transitions, EnemyConfig config,
      EnemyAnimatorProvider animatorProvider, EnemyGrenadeThrower configGrenadeThrower,
      EnemyToPlayerRotator rotator, EnemyGrenadeThrowTimer grenadeThrowTimer) : base(transitions)
    {
      _config = config;
      _animatorProvider = animatorProvider;
      _configGrenadeThrower = configGrenadeThrower;
      _rotator = rotator;
      _grenadeThrowTimer = grenadeThrowTimer;
    }

    public override void Enter()
    {
      _animatorProvider.Instance.GrenadeThrown += OnGrenadeThrown;
      _thrown = false;
    }

    public override void Tick()
    {
      base.Tick();
      _rotator.Rotate();

      if (_thrown)
        return;

      _thrown = true;
      _animatorProvider.Instance.PlayGrenadeThrow(_config.GrenadeThrowDuration);
      _grenadeThrowTimer.Reset();
    }

    public override void Exit()
    {
      _animatorProvider.Instance.GrenadeThrown -= OnGrenadeThrown;
    }

    private void OnGrenadeThrown()
    {
      _configGrenadeThrower.Lauch();
    }
  }
}