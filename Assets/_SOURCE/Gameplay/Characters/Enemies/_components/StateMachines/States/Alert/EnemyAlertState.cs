using System.Collections.Generic;
using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.FiniteStateMachines;
using Loggers;

namespace Gameplay.Characters.Enemies.StateMachines.States.Alert
{
  public class EnemyAlertState : State
  {
    private readonly EnemyAlertTimer _alertTimer;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyToPlayerRotator _rotator;
    private readonly EnemyConfig _config;

    public EnemyAlertState(List<Transition> transitions, EnemyAlertTimer alertTimer,
      EnemyAnimatorProvider animatorProvider, EnemyToPlayerRotator rotator, EnemyConfig config) : base(transitions)
    {
      _alertTimer = alertTimer;
      _animatorProvider = animatorProvider;
      _rotator = rotator;
      _config = config;
    }

    public override void Enter()
    {
      _animatorProvider.Instance.PlayPanic(_config.AlertDuration);
      _alertTimer.Reset();
    }

    protected override void OnTick()
    {
      _alertTimer.Tick();
    }

    public override void Exit()
    {
      //_rotator.Rotate();
    }
  }
}