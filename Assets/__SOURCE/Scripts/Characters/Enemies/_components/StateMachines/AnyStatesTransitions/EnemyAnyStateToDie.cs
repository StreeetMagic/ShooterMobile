using Characters.Enemies._components.StateMachines.States.Die;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.AnyStatesTransitions
{
  public class EnemyAnyStateToDie : Transition
  {
    private IHealth _health;

    public EnemyAnyStateToDie(IHealth health)
    {
      _health = health;
    }

    public override void Tick()
    {
      if (_health.IsDead)
      {
        Enter<EnemyDieState>();
      }
    }
  }
}