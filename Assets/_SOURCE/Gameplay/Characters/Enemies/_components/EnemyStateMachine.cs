using PUNBALL.Infrastructure.StateMachine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyStateMachine : StateMachine
  {
    public EnemyStateMachine(EnemyStatesProvider enemyStatesProvider) : base(enemyStatesProvider)
    {
    }
  }
}