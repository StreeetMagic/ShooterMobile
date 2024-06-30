using Characters.Enemies._components.StateMachines.States.Chase;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Alert
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