using Characters.Enemies._components.StateMachines.States.Chase;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.LowWeapon
{
  public class EnemyLowWeaponToChaseTransition : Transition
  {
    private readonly EnemyWeaponLowerer _lowerer;

    public EnemyLowWeaponToChaseTransition(EnemyWeaponLowerer lowerer)
    {
      _lowerer = lowerer;
    }

    public override void Tick()
    {
      _lowerer.Tick();

      if (_lowerer.IsDone)
        Enter<EnemyChaseState>();
    }
  }
}