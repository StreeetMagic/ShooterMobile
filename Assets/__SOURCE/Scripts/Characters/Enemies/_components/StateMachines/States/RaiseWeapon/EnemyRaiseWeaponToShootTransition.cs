using Characters.Enemies._components.StateMachines.States.Shoot;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.RaiseWeapon
{
  public class EnemyRaiseWeaponToShootTransition : Transition
  {
    private readonly EnemyWeaponRaiser _weaponRaiser;

    public EnemyRaiseWeaponToShootTransition(EnemyWeaponRaiser weaponRaiser)
    {
      _weaponRaiser = weaponRaiser;
    }

    public override void Tick()
    {
      _weaponRaiser.Tick();
      
      if (_weaponRaiser.IsDone)
        Enter<EnemyShootState>();
    }
  }
}