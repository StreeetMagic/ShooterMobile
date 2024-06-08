using Gameplay.Characters.Players;
using StateMachine;
using UnityEngine;

namespace Gameplay.Characters.Enemies.States
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
      if (_hitStatus.IsHit)
      {
        float distanceToPlayer = Vector3.Distance(_playerProvider.Player.transform.position, _enemy.transform.position);
        float shootRange = _config.ShootRange;

        if (distanceToPlayer > shootRange)
          _enemyStateMachine.Enter<EnemyChasePlayerState>();
        else
          _enemyStateMachine.Enter<EnemyAttackPlayerState>();
      }
      else
      {
        _enemyStateMachine.Enter<EnemyPatrolState>();
      }
    }

    public void Exit()
    {
 
    }
  }
}