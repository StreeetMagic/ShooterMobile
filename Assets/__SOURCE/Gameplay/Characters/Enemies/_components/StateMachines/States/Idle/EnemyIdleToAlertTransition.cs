using Gameplay.Characters.Enemies.StateMachines.States.Alert;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Idle
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