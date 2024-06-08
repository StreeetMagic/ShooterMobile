using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyShootingState : IState, ITickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyShooter _shooter;
    private readonly EnemyShootingPoint _shootingPoint;
    private readonly EnemyStateMachine _stateMachine;
    private readonly EnemyToPlayerRotator _toPlayerRotator;

    private float _shootTimeLeft;

    public EnemyShootingState(PlayerProvider playerProvider, EnemyConfig config,
      Enemy enemy, EnemyAnimatorProvider animatorProvider, EnemyShooter shooter, EnemyShootingPoint shootingPoint,
      EnemyStateMachine stateMachine, EnemyToPlayerRotator toPlayerRotator)
    {
      _playerProvider = playerProvider;
      _config = config;
      _enemy = enemy;
      _animatorProvider = animatorProvider;
      _shooter = shooter;
      _shootingPoint = shootingPoint;
      _stateMachine = stateMachine;
      _toPlayerRotator = toPlayerRotator;
    }

    public void Enter()
    {
      _shootTimeLeft = 1 / (float)_config.FireRate;
    }

    public void Tick()
    {
      _toPlayerRotator.Rotate();
      
      Vector3 direction = new Vector3(_playerProvider.Instance.transform.position.x - _enemy.transform.position.x, 0, _playerProvider.Instance.transform.position.z - _enemy.transform.position.z).normalized;

      _shootTimeLeft -= Time.deltaTime;

      if (_shootTimeLeft <= 0)
      {
        _animatorProvider.Instance.PlayShootAnimation();
        _shooter.Shoot(_shootingPoint.PointTransform, _shootingPoint.PointTransform.position, direction, _config);
        _stateMachine.Enter<EnemyChooseAttackState>();
      }
    }

    public void Exit()
    {
    }
  }
}