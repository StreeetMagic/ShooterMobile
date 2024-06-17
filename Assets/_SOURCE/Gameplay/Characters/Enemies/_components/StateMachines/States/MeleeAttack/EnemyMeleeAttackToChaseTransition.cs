using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.MeleeAttack
{
  public class EnemyMeleeAttackToChaseTransition : Transition
  {
    public EnemyMeleeAttackToChaseTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}