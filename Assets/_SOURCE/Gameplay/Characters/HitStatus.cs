namespace Gameplay.Characters.Enemies
{
  public class HitStatus
  {
    private readonly EnemyStateMachine _enemyStateMachine;
    private readonly EnemyReturnToSpawnStatus _enemyReturnToSpawnStatus;

    private bool _isHit;

    public HitStatus(EnemyStateMachine enemyStateMachine, EnemyReturnToSpawnStatus enemyReturnToSpawnStatus)
    {
      _enemyStateMachine = enemyStateMachine;
      _enemyReturnToSpawnStatus = enemyReturnToSpawnStatus;
    }

    public bool IsHit
    {
      get
      {
        return _isHit;
      }
      set
      {
        if (value && !_enemyReturnToSpawnStatus.IsReturn)
        {
          _enemyStateMachine.Enter<EnemyRunToPlayerState>();
        }

        _isHit = value;
      }
    }
  }
}