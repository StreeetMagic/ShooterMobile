namespace Gameplay.Characters.Enemies
{
  public class HitStatus
  {
    private readonly EnemyStateMachine _enemyStateMachine;

    private bool _isHit;

    public HitStatus(EnemyStateMachine enemyStateMachine)
    {
      _enemyStateMachine = enemyStateMachine;
    }

    public bool IsHit
    {
      get
      {
        return _isHit;
      }
      set
      {
        if (value)
        {
          _enemyStateMachine.Enter<EnemyRunToPlayerState>();
        }

        _isHit = value;
      }
    }
  }
}