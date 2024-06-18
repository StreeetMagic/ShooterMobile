using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Loggers;

namespace Gameplay.Characters.Enemies.StateMachines.States.RaiseWeapon
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
      new DebugLogger().Log("Анимация поднятия оружия у ENEMY");
    }

    public override void Exit()
    {
    }
  }
}