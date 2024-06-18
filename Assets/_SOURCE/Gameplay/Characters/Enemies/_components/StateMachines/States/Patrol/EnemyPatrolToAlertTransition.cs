using System;
using Gameplay.Characters.Enemies.StateMachines.States.Alert;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Patrol
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