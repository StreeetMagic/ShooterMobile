using System;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.RaiseWeapon
{
  public class EnemyRaiseWeaponToShootTransition : Transition
  {
    public EnemyRaiseWeaponToShootTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}