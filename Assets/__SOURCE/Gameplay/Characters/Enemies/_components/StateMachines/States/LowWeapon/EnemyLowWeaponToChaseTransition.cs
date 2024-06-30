using Gameplay.Characters.Enemies.StateMachines.States.Chase;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.LowWeapon
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