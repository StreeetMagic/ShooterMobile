using Characters.Enemies._components.StateMachines.States.Reload;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Chase
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