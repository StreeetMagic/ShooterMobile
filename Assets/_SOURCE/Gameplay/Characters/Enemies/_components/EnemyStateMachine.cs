namespace Gameplay.Characters.Enemies
{
  public class EnemyStateMachine : StateMachine.StateMachine
  {
    public EnemyStateMachine(EnemyStatesProvider enemyStatesProvider) : base(enemyStatesProvider)
    {
    }
  }
}