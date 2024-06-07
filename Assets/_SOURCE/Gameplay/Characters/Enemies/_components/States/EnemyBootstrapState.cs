using StateMachine;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyBootstrapState : IState
  {
    private readonly EnemyStateMachine _enemyStateMachine;

    public EnemyBootstrapState(EnemyStateMachine enemyStateMachine)
    {
      _enemyStateMachine = enemyStateMachine;
    }

    public void Enter()
    {
      _enemyStateMachine.Enter<EnemyPatrolState>();
    }

    public void Exit()
    {
    }
  }
}