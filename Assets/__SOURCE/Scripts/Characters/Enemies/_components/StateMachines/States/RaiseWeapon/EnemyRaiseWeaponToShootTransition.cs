using Gameplay.Characters.Enemies.StateMachines.States.Shoot;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.RaiseWeapon
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