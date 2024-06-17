using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyLowWeaponToReturnTransition : Transition
  {
    public EnemyLowWeaponToReturnTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}