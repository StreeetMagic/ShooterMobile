using System;
using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyReloadState : State
  {
    public EnemyReloadState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }
}