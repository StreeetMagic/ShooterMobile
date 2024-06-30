using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Die
{
  public class EnemyDieState : State
  {
    private readonly EnemyAnimatorProvider _animatorProvider;
    
    public EnemyDieState(List<Transition> transitions, EnemyAnimatorProvider animatorProvider) : base(transitions)
    {
      _animatorProvider = animatorProvider;
    }

    public override void Enter()
    {
      _animatorProvider.Instance.PlayDeathAnimation();
    }

    public override void Exit()
    {
    }
  }
}