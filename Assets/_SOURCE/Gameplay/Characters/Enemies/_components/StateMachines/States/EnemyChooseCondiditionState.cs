using Gameplay.Characters.Enemies.StateMachines.States;
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
      if (_enemy.Health.IsDead)
      {
        _enemyStateMachine.Enter<EnemyDyingState>();
      }
      else if (_hitStatus.IsHit)
      {
        float distanceToPlayer = Vector3.Distance(_playerProvider.Instance.transform.position, _enemy.transform.position);
        float shootRange = _config.ShootRange;

        if (distanceToPlayer > shootRange)
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