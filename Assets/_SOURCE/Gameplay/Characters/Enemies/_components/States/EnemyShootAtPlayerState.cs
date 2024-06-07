using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyShootAtPlayerState : IState, ITickable
  {
    private float _time;

    private readonly EnemyShooter _shooter;
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly EnemyShootingPoint _shootingPoint;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly Enemy _enemy;
    private readonly EnemyToPlayerRotator _enemyToPlayerRotator;
    private readonly EnemyStateMachine _enemyStateMachine;
    private readonly EnemyMover _mover;

    public EnemyShootAtPlayerState(PlayerProvider playerProvider, EnemyShooter shooter,
      EnemyConfig config, EnemyShootingPoint shootingPoint, EnemyAnimatorProvider animatorProvider,
      Enemy enemy, EnemyToPlayerRotator enemyToPlayerRotator, EnemyStateMachine enemyStateMachine, EnemyMover mover)
    {
      _shooter = shooter;
      _playerProvider = playerProvider;

      _config = config;
      _shootingPoint = shootingPoint;
      _animatorProvider = animatorProvider;
      _enemy = enemy;
      _enemyToPlayerRotator = enemyToPlayerRotator;
      _enemyStateMachine = enemyStateMachine;
      _mover = mover;
    }

    private float Cooldown => 1 / (float)_config.FireRate;
    private Transform PlayerTransform => _playerProvider.Player.transform;

    public void Enter()
    {
      _animatorProvider.Instance.StopRunAnimation();
      _animatorProvider.Instance.StopWalkAnimation();
      _mover.Stop();

      _time = 0;
    }

    public void Exit()
    {
      _time = 0;
    }

    public void Tick()
    {
      if (_playerProvider.Player == null)
        return;

      _enemyToPlayerRotator.RotateToTargetPosition(PlayerTransform.position);

      if (Vector3.Distance(PlayerTransform.position, _enemy.transform.position) > _config.ShootRange)
        _enemyStateMachine.Enter<EnemyRunToPlayerState>();

      Vector3 direction = new Vector3(PlayerTransform.position.x - _enemy.transform.position.x, 0, PlayerTransform.position.z - _enemy.transform.position.z).normalized;

      _time += Time.deltaTime;

      if (_time >= Cooldown)
      {
        Shoot(direction);
        _time = 0;
      }
    }

    private void Shoot(Vector3 direction)
    {
      _shooter.Shoot(_shootingPoint.PointTransform, _shootingPoint.PointTransform.position, direction, _config);

      _animatorProvider.Instance.PlayShootAnimation();
    }
  }
}