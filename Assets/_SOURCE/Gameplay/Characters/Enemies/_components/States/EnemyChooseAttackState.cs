using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyChooseAttackState : IState, ITickable
  {
    private readonly EnemyShooter _shooter;
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly EnemyShootingPoint _shootingPoint;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly Enemy _enemy;
    private readonly EnemyToPlayerRotator _toPlayerRotator;
    private readonly EnemyStateMachine _stateMachine;
    private readonly EnemyGrenadeLauncher _grenadeLauncher;

    private float _cooldownLeft;
    private bool _readyToThrow;
    private float _randomDelay;
    private float _randomDelayLeft;
    private int _grenadesLeft;
    private float _shootTimeLeft;

    public EnemyChooseAttackState(PlayerProvider playerProvider, EnemyShooter shooter,
      EnemyConfig config, EnemyShootingPoint shootingPoint, EnemyAnimatorProvider animatorProvider,
      Enemy enemy, EnemyToPlayerRotator toPlayerRotator, EnemyStateMachine stateMachine, EnemyGrenadeLauncher grenadeLauncher)
    {
      _shooter = shooter;
      _playerProvider = playerProvider;

      _config = config;
      _shootingPoint = shootingPoint;
      _animatorProvider = animatorProvider;
      _enemy = enemy;
      _toPlayerRotator = toPlayerRotator;
      _stateMachine = stateMachine;
      _grenadeLauncher = grenadeLauncher;
    }

    public void Enter()
    {
      _randomDelay = Random.Range(0, _config.GrenadeThrowRandomDelay);
      _randomDelayLeft = _randomDelay;
      _grenadesLeft = _config.MaxGrenadesCount;

      _shootTimeLeft = 0;
    }

    public void Tick()
    {
      if (_playerProvider.Player == null)
        return;

      Transform playerTransform = _playerProvider.Player.transform;

      _toPlayerRotator.RotateToTargetPosition(playerTransform.position);

      if (Vector3.Distance(playerTransform.position, _enemy.transform.position) > _config.ShootRange)
        _stateMachine.Enter<EnemyChasingPlayerState>();

      Vector3 direction = new Vector3(playerTransform.position.x - _enemy.transform.position.x, 0, playerTransform.position.z - _enemy.transform.position.z).normalized;

      _shootTimeLeft += Time.deltaTime;

      if (_shootTimeLeft >= 1 / (float)_config.FireRate)
      {
        Shoot(direction);
        _shootTimeLeft = 0;
      }

      if (_cooldownLeft > 0)
      {
        _cooldownLeft -= Time.deltaTime;
        _readyToThrow = false;
      }
      else if (_playerProvider.PlayerStandsOnSamePosition.TimeOnSamePosition >= _config.TargetStandsOnSamePositionTime)
      {
        if (_randomDelayLeft > 0)
        {
          _randomDelayLeft -= Time.deltaTime;

          _readyToThrow = false;
        }
        else
        {
          _readyToThrow = true;

          Throw();
        }
      }
    }

    public void Exit()
    {
      _shootTimeLeft = 0;
    }

    private void Shoot(Vector3 direction)
    {
      _animatorProvider.Instance.PlayShootAnimation();
      _shooter.Shoot(_shootingPoint.PointTransform, _shootingPoint.PointTransform.position, direction, _config);
    }

    private void Throw()
    {
      if (!_readyToThrow)
        return;

      if (_grenadesLeft <= 0)
        return;

      _cooldownLeft = _config.GrenadeThrowCooldown;
      _randomDelayLeft = _randomDelay;
      _grenadesLeft--;

      _grenadeLauncher.Lauch();
    }
  }
}