using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.RaiseWeapon
{
  public class EnemyRaiseWeaponState : State
  {
    private readonly EnemyAnimatorProvider _enemyAnimatorProvider;
    private readonly EnemyWeaponRaiser _weaponRaiser;

    public EnemyRaiseWeaponState(List<Transition> transitions,
      EnemyWeaponRaiser weaponRaiser, EnemyAnimatorProvider enemyAnimatorProvider) : base(transitions)
    {
      _weaponRaiser = weaponRaiser;
      _enemyAnimatorProvider = enemyAnimatorProvider;
    }

    public override void Enter()
    {
      _weaponRaiser.Reset();
      _enemyAnimatorProvider.Instance.OnStateShooting();
    }

    public override void Exit()
    {
    }
  }
}