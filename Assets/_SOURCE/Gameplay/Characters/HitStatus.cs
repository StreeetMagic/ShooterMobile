using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.StateMachines;
using Gameplay.Characters.Enemies.StateMachines.States;

namespace Gameplay.Characters
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
      if (IsHit)
        return;
      
      IsHit = true;
      
      if (_enemyReturnToSpawnStatus.IsReturn == false)
        _enemyStateMachine.Enter<EnemyChooseCondiditionState>();
    }

    public void Disable()
    {
      IsHit = false;
    }
  }
}