using Gameplay.Characters.Enemies.StateMachines.States.Chase;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Reload
{
  public class EnemyReloadToChaseTransition : Transition
  {
    private readonly EnemyWeaponMagazine _magazine;

    public EnemyReloadToChaseTransition(EnemyWeaponMagazine magazine)
    {
      _magazine = magazine;
    }

    public override void Tick()
    {
      if (_magazine.IsEmpty == false)
        Enter<EnemyChaseState>();
    }
  }
}