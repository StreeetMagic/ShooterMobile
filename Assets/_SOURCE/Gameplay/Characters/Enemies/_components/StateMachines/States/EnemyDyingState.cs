using Infrastructure.StateMachine;

namespace Gameplay.Characters.Enemies.StateMachines.States 
{
  public class EnemyDyingState : IState
  {
    private readonly EnemyAnimatorProvider _animatorProvider;

    public EnemyDyingState(EnemyAnimatorProvider animatorProvider)
    {
      _animatorProvider = animatorProvider;
    }

    public void Enter()
    {
      _animatorProvider.Instance.PlayDeathAnimation();
    }

    public void Exit()
    {
    }
  }
}