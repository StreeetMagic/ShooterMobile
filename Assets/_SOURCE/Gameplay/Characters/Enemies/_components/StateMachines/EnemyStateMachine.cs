using Infrastructure.StateMachine;

namespace Gameplay.Characters.Enemies.StateMachines
{
  public class EnemyStateMachine : StateMachine
  {
    public EnemyStateMachine(EnemyStatesProvider enemyStatesProvider) : base(enemyStatesProvider)
    {
    }
  }
}