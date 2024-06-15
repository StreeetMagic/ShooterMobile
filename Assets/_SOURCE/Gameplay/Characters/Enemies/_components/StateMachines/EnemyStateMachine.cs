using Infrastructure.StateMachine;
using Loggers;

namespace Gameplay.Characters.Enemies.StateMachines
{
  public class EnemyStateMachine : StateMachine
  {
    public EnemyStateMachine(EnemyStatesProvider enemyStatesProvider, DebugLogger logger) : base(enemyStatesProvider, logger)
    {
    }
  }
}