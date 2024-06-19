using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Shoot
{
  public class EnemyShootState : State
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyShooter _shooter;
    private readonly EnemyShootingPointProvider _shootingPointProvider;
    private readonly EnemyToPlayerRotator _toPlayerRotator;
    private readonly EnemyWeaponMagazine _magazine;

    private float _shootTimeLeft;

    public EnemyShootState(PlayerProvider playerProvider, EnemyConfig config,
      Enemy enemy, EnemyAnimatorProvider animatorProvider, EnemyShooter shooter,
      EnemyShootingPointProvider shootingPointProvider,
      EnemyToPlayerRotator toPlayerRotator, List<Transition> transitions,
      EnemyWeaponMagazine magazine) : base(transitions)
    {
      _playerProvider = playerProvider;
      _config = config;
      _enemy = enemy;
      _animatorProvider = animatorProvider;
      _shooter = shooter;
      _shootingPointProvider = shootingPointProvider;
      _toPlayerRotator = toPlayerRotator;
      _magazine = magazine;
    }

    public override void Enter()
    {
      _shootTimeLeft = 1 / (float)_config.FireRate;
    }

    protected override void OnTick()
    {
      _toPlayerRotator.Rotate();

      Vector3 playerPosition = _playerProvider.Instance.transform.position;
      Vector3 enemyPosition = _enemy.transform.position;
      Vector3 direction = new Vector3(playerPosition.x - enemyPosition.x, 0, playerPosition.z - enemyPosition.z).normalized;

      _shootTimeLeft -= Time.deltaTime;

      if ((_shootTimeLeft > 0))
        return;
      
      if (_magazine.TryGetBullet() == false)
        return;

      _animatorProvider.Instance.PlayRifleShootAnimation();
      Transform parentTransform = _shootingPointProvider.PointTransform;
      _shooter.Shoot(parentTransform, parentTransform.position, direction, _config);
      
      _shootTimeLeft = 1 / (float)_config.FireRate;
    }

    public override void Exit()
    {
    }
  }
}