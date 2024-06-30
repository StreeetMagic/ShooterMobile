using Characters.Enemies._components.StateMachines.States.Alert;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Patrol
{
  public class EnemyPatrolToAlertTransition : Transition
  {
    private readonly HitStatus _hitStatus;

    public EnemyPatrolToAlertTransition(HitStatus hitStatus)
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