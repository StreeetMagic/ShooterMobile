using Gameplay.Characters.Enemies.StateMachines.States.Chase;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Alert
{
  public class EnemyAlertToChaseTransition : Transition
  {
    private readonly EnemyAlertTimer _alertTimer;

    public EnemyAlertToChaseTransition(EnemyAlertTimer alertTimer)
    {
      _alertTimer = alertTimer;
    }

    public override void Tick()
    {
      if (_alertTimer.IsOver)
        Enter<EnemyChaseState>();
    }
  }
}