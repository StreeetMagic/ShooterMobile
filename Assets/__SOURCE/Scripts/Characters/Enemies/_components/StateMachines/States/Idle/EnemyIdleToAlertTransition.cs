using Characters.Enemies._components.StateMachines.States.Alert;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Idle
{
  public class EnemyIdleToAlertTransition : Transition
  {
    private readonly HitStatus _hitStatus;

    public EnemyIdleToAlertTransition(HitStatus hitStatus)
    {
      _hitStatus = hitStatus;
    }

    public override void Tick()
    {
      if (_hitStatus.IsHit)
        Enter<EnemyAlertState>();
    }
  }
}