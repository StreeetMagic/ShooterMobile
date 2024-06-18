using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Loggers;

namespace Gameplay.Characters.Enemies.StateMachines.States.Alert
{
  public class EnemyAlertState : State
  {
    private readonly EnemyAlertTimer _alertTimer;
    
    public EnemyAlertState(List<Transition> transitions, EnemyAlertTimer alertTimer) : base(transitions)
    {
      _alertTimer = alertTimer;
    }

    public override void Enter()
    {
      new DebugLogger().Log("Player Alert Animation");
      _alertTimer.Reset();
    }
    
    public override void Tick()
    {
      base.Tick();
      _alertTimer.Tick();
    }

    public override void Exit()
    {
      new DebugLogger().Log("Stop Alert Animation");
    }
  }
}