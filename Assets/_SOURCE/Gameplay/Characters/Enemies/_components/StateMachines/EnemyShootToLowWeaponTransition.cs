using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyShootToLowWeaponTransition : Transition
  {
    public EnemyShootToLowWeaponTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}