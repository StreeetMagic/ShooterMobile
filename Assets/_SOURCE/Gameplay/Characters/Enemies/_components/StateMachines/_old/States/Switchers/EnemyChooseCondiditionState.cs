using Gameplay.Characters.Players;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines._old.States.Switchers
{
  public class EnemyChooseCondiditionState 
  {

    private readonly HitStatus _hitStatus;
    private readonly PlayerProvider _playerProvider;
    private readonly Enemy _enemy;
    private readonly EnemyConfig _config;

    public EnemyChooseCondiditionState(HitStatus hitStatus, 
      PlayerProvider playerProvider, Enemy enemy, EnemyConfig config)
    {
      _hitStatus = hitStatus;

      _playerProvider = playerProvider;
      _enemy = enemy;
      _config = config;
    }

    public void Enter()
    {
      if (_enemy.Health.IsDead)
      {
       // _oldEnemyStateMachine.Enter<EnemyDyingState>();
      }
      else if (_hitStatus.IsHit)
      {
        float distanceToPlayer = Vector3.Distance(_playerProvider.Instance.transform.position, _enemy.transform.position);
        
        float attackRange;

        if (_config.IsShooter)
          attackRange = _config.ShootRange;
        else
          attackRange = _config.MeleeRange;

        //if (distanceToPlayer > attackRange)
          //_oldEnemyStateMachine.Enter<EnemyChasingPlayerState>();
       // else
          //_oldEnemyStateMachine.Enter<EnemyChooseAttackState>();
      }
      else
      {
       // _oldEnemyStateMachine.Enter<EnemyPatrolingState>();
      }
    }

    public void Exit()
    {
    }
  }
}