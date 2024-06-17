using Gameplay.Characters.Players;
using Gameplay.Spawners;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines._old.States.Tickables
{
  public class EnemyChasingPlayerState : ITickable
  {

    private readonly PlayerProvider _playerProvider;
    private readonly EnemyMover _mover;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyConfig _config;
    private readonly EnemySpawner _enemySpawner;
    private readonly Enemy _enemy;
    private readonly EnemyReturnToSpawnStatus _enemyReturnToSpawnStatus;
    private readonly EnemyMaxAttakingRange _enemyMaxAttakingRange;

    public EnemyChasingPlayerState(PlayerProvider playerProvider, EnemyMover mover, EnemyAnimatorProvider animatorProvider,
      EnemyConfig config, EnemySpawner enemySpawner, Enemy enemy, 
      EnemyReturnToSpawnStatus enemyReturnToSpawnStatus, EnemyMaxAttakingRange enemyMaxAttakingRange)
    {
      _playerProvider = playerProvider;
      _mover = mover;
      _animatorProvider = animatorProvider;
      _config = config;
      _enemySpawner = enemySpawner;
      _enemy = enemy;

      _enemyReturnToSpawnStatus = enemyReturnToSpawnStatus;
      _enemyMaxAttakingRange = enemyMaxAttakingRange;
    }

    public void Enter()
    {
    }

    public void Tick()
    {
      float distance = Vector3.Distance(_playerProvider.Instance.transform.position, _enemy.transform.position);

      // if (distance < _enemyMaxAttakingRange.Get())
      //   _oldEnemyStateMachine.Enter<EnemyChooseAttackState>();
      // else
      //   Move();
    }

    public void Exit()
    {
      _mover.Stop();
      _animatorProvider.Instance.StopWalkAnimation();
      _animatorProvider.Instance.StopRunAnimation();
    }

    private void Move()
    {
      float distanceToSpawner = (_enemySpawner.transform.position - _enemy.transform.position).magnitude;

      if (distanceToSpawner < _config.PatrolingRadius)
      {
        Chase();
      }
      else
      {
        _enemyReturnToSpawnStatus.IsReturn = true;
       // _oldEnemyStateMachine.Enter<EnemyPatrolingState>();
      }
    }

    private void Chase()
    {
      _mover.Move(_playerProvider.Instance.transform.position, _config.RunSpeed);
      _animatorProvider.Instance.PlayRunAnimation();
    }
  }
}