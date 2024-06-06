using Gameplay.Characters.Players;
using PUNBALL.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyRunToPlayerState : IState, ITickable
  {
    private readonly EnemyStateMachine _enemyStateMachine;
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyMover _mover;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyConfig _config;
    private readonly Transform _spawnerTransform;
    private readonly Enemy _enemy;

    public EnemyRunToPlayerState(
      PlayerProvider playerProvider,
      EnemyMover mover,
      EnemyAnimatorProvider animatorProvider,
      EnemyConfig config,
      Transform spawnerTransform,
      Enemy enemy)
    {
      _playerProvider = playerProvider;
      _mover = mover;
      _animatorProvider = animatorProvider;
      _config = config;
      _spawnerTransform = spawnerTransform;
      _enemy = enemy;
    }

    private float RunSpeed => _config.RunSpeed;
    private Transform PlayerTransform => _playerProvider.Player.transform;

    public void Enter()
    {
    }

    public void Tick()
    {
      Move();
    }

    public void Exit()
    {
    }

    private void Move()
    {
      float distanceToSpawner = (_spawnerTransform.position - _enemy.transform.position).magnitude;

      if (distanceToSpawner < _config.PatrolingRadius)
        MoveToPlayer();
      else
        _enemyStateMachine.Enter<EnemyRunToSpawnPointState>();
    }

    private void MoveToPlayer()
    {
      _mover.Move(PlayerTransform.position, RunSpeed);
      _animatorProvider.Instance.PlayRunAnimation();
    }
  }
}