using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Loggers;

namespace Gameplay.Characters.Enemies.StateMachines.States.LowWeapon
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