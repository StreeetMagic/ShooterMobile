namespace Gameplay.Characters.Enemies
{
  public class HitStatus
  {
    private readonly EnemyStateMachine _enemyStateMachine;
    private readonly EnemyReturnToSpawnStatus _enemyReturnToSpawnStatus;

    public HitStatus(EnemyStateMachine enemyStateMachine, EnemyReturnToSpawnStatus enemyReturnToSpawnStatus)
    {
      _enemyStateMachine = enemyStateMachine;
      _enemyReturnToSpawnStatus = enemyReturnToSpawnStatus;
    }

    public bool IsHit { get; private set; }

    public void Enable()
    {
      IsHit = true;
      
      if (_enemyReturnToSpawnStatus.IsReturn == false)
        _enemyStateMachine.Enter<EnemyRunToPlayerState>();
    }

    public void Disable()
    {
    }
  }
}