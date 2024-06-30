using Characters.Enemies._components.StateMachines.States.Chase;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Reload
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