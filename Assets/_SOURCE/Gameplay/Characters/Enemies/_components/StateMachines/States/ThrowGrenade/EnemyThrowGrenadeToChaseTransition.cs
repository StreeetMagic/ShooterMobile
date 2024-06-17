using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.ThrowGrenade
{
  public class EnemyThrowGrenadeToChaseTransition : Transition
  {
    public EnemyThrowGrenadeToChaseTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}