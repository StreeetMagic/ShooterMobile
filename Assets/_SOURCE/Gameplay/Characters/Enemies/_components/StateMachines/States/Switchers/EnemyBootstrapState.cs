using Infrastructure.StateMachine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Switchers
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
      _enemyStateMachine.Enter<EnemyChooseCondiditionState>();
    }

    public void Exit()
    {
    }
  }
}