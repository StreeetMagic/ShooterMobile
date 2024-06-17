using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyLowWeaponToChaseTransition : Transition
  {
    public EnemyLowWeaponToChaseTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}