using Characters.Enemies._components.StateMachines.States.Patrol;
using Characters.Enemies._components.TargetTriggers;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Idle
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