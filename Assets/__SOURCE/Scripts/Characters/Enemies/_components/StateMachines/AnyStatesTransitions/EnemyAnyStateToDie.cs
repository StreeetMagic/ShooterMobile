using Gameplay.Characters.Enemies.StateMachines.States.Die;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.AnyStatesTransitions
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