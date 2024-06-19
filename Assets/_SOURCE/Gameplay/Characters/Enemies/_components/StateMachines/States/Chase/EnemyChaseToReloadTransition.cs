using Gameplay.Characters.Enemies.StateMachines.States.RaiseWeapon;
using Gameplay.Characters.Enemies.StateMachines.States.Reload;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Chase
{
  public class EnemyChaseToReloadTransition : Transition
  {
    private readonly EnemyWeaponMagazine _magazine;

    public EnemyChaseToReloadTransition(EnemyWeaponMagazine magazine)
    {
      _magazine = magazine;
    }

    public override void Tick()
    {
      if (_magazine.IsEmpty)
        Enter<EnemyReloadState>();
    }
  }
}