using Gameplay.Characters.Enemies.StateMachines.States.Patrol;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Idle
{
  public class EnemyIdleToPatrolTransition : Transition
  {
    private readonly EnemyIdleTimer _idleTimer;

    public EnemyIdleToPatrolTransition(EnemyIdleTimer idleTimer)
    {
      _idleTimer = idleTimer;
    }

    public override void Tick()
    {
      if (_idleTimer.IsDone)
        Enter<EnemyPatrolState>();
    }
  }
}