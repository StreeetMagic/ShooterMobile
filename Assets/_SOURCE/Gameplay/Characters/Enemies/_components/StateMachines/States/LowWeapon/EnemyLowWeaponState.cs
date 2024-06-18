using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Loggers;

namespace Gameplay.Characters.Enemies.StateMachines.States.LowWeapon
{
  public class EnemyLowWeaponState : State
  {
     private readonly EnemyWeaponLowerer _lowerer;
      
    public EnemyLowWeaponState(List<Transition> transitions, EnemyWeaponLowerer lowerer) : base(transitions)
    {
      _lowerer = lowerer;
    }

    public override void Enter()
    {
      _lowerer.Reset();
      new DebugLogger().Log("Опускаем оружие анимация у ENEMY");
    }

    public override void Exit()
    {
    }
  }
}