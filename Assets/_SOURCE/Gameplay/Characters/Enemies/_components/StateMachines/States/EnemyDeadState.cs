using Gameplay.Characters.Enemies.Healths;
using Infrastructure.StateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyDeadState : IEnemyState
  {
    private EnemyComponentsProvider _componentsProvider;
    private StateMachine<IEnemyState> _stateMachine;
    private EnemyHealth _enemyHealth;

    public EnemyDeadState(EnemyComponentsProvider componentsProvider, StateMachine<IEnemyState> stateMachine, EnemyHealth enemyHealth)
    {
      _componentsProvider = componentsProvider;
      _stateMachine = stateMachine;
      _enemyHealth = enemyHealth;

      _componentsProvider.Destroyed += OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed()
    {
      _enemyHealth.TakeDamage(int.MaxValue);
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}