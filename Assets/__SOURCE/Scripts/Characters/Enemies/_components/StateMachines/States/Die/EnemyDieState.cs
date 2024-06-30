using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Die
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