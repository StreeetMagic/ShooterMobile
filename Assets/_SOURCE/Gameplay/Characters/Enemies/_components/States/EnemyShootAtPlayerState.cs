using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using PUNBALL.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
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

    public EnemyShootAtPlayerState(PlayerProvider playerProvider, EnemyShooter shooter,
      EnemyConfig config, EnemyShootingPoint shootingPoint, EnemyAnimatorProvider animatorProvider, Enemy enemy, EnemyToPlayerRotator enemyToPlayerRotator)
    {
      _shooter = shooter;
      _playerProvider = playerProvider;

      _config = config;
      _shootingPoint = shootingPoint;
      _animatorProvider = animatorProvider;
      _enemy = enemy;
      _enemyToPlayerRotator = enemyToPlayerRotator;
    }

    private float Cooldown => 1 / (float)_config.FireRate;
    private Transform PlayerTransform => _playerProvider.Player.transform;

    public void Enter()
    {
      Debug.Log("Enter shoot state");
      
      _animatorProvider.Instance.StopRunAnimation();
      _animatorProvider.Instance.StopWalkAnimation();
    }

    public void Exit()
    {
    }

    public void Tick()
    {
      if (_playerProvider.Player == null)
        return;

      _enemyToPlayerRotator.RotateToTargetPosition(PlayerTransform.position);

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