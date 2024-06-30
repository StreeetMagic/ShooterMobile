using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.LowWeapon
{
  public class EnemyLowWeaponState : State
  {
     private readonly EnemyWeaponLowerer _lowerer;
     private readonly EnemyAnimatorProvider _enemyAnimatorProvider;
      
    public EnemyLowWeaponState(List<Transition> transitions, EnemyWeaponLowerer lowerer, EnemyAnimatorProvider enemyAnimatorProvider) : base(transitions)
    {
      _lowerer = lowerer;
      _enemyAnimatorProvider = enemyAnimatorProvider;
    }

    public override void Enter()
    {
      _lowerer.Reset();
      _enemyAnimatorProvider.Instance.OffStateShooting();
    }

    public override void Exit()
    {
    }
  }
}