using Gameplay.Characters.Players;
using Infrastructure.StateMachine;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyChooseCondiditionState : IState
  {
    private readonly EnemyStateMachine _enemyStateMachine;
    private readonly HitStatus _hitStatus;
    private readonly PlayerProvider _playerProvider;
    private readonly Enemy _enemy;
    private readonly EnemyConfig _config;

    public EnemyChooseCondiditionState(HitStatus hitStatus, EnemyStateMachine enemyStateMachine,
      PlayerProvider playerProvider, Enemy enemy, EnemyConfig config)
    {
      _hitStatus = hitStatus;
      _enemyStateMachine = enemyStateMachine;
      _playerProvider = playerProvider;
      _enemy = enemy;
      _config = config;
    }

    public void Enter()
    {
      if (_enemy.Health.IsDead)
      {
        _enemyStateMachine.Enter<EnemyDyingState>();
      }
      else if (_hitStatus.IsHit)
      {
        float distanceToPlayer = Vector3.Distance(_playerProvider.Instance.transform.position, _enemy.transform.position);
        
        float attackRange;

        if (_config.IsShooter)
          attackRange = _config.ShootRange;
        else
          attackRange = _config.MeleeRange;

        if (distanceToPlayer > attackRange)
          _enemyStateMachine.Enter<EnemyChasingPlayerState>();
        else
          _enemyStateMachine.Enter<EnemyChooseAttackState>();
      }
      else
      {
        _enemyStateMachine.Enter<EnemyPatrolingState>();
      }
    }

    public void Exit()
    {
    }
  }
}