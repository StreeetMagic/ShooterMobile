

namespace Gameplay.Characters.Enemies.StateMachines._old.States.Tickables 
{
  public class EnemyDyingState 
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