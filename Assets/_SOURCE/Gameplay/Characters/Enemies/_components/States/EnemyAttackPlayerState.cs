using AssetProviders;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using Gameplay.Grenades;
using StateMachine;
using StaticDataServices;
using UnityEngine;
using Zenject;
using ZenjectFactories;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyAttackPlayerState : IState, ITickable
  {
    private readonly EnemyShooter _shooter;
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly EnemyShootingPoint _shootingPoint;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly Enemy _enemy;
    private readonly EnemyToPlayerRotator _enemyToPlayerRotator;
    private readonly EnemyStateMachine _enemyStateMachine;
    private readonly EnemyMover _mover;
    private readonly IStaticDataService _staticDataService;
    private readonly GameLoopZenjectFactory _gameLoopZenjectFactory;

    private float _cooldownLeft;
    private bool _readyToThrow;
    private float _randomDelay;
    private float _randomDelayLeft;
    private int _grenadesLeft;

    private float _shootTimeLeft;

    public EnemyAttackPlayerState(PlayerProvider playerProvider, EnemyShooter shooter,
      EnemyConfig config, EnemyShootingPoint shootingPoint, EnemyAnimatorProvider animatorProvider,
      Enemy enemy, EnemyToPlayerRotator enemyToPlayerRotator, EnemyStateMachine enemyStateMachine, EnemyMover mover,
      IStaticDataService staticDataService, GameLoopZenjectFactory gameLoopZenjectFactory)
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
      _staticDataService = staticDataService;
      _gameLoopZenjectFactory = gameLoopZenjectFactory;
    }

    public void Enter()
    {
      _animatorProvider.Instance.StopRunAnimation();
      _animatorProvider.Instance.StopWalkAnimation();
      _mover.Stop();

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

      _enemyToPlayerRotator.RotateToTargetPosition(playerTransform.position);

      if (Vector3.Distance(playerTransform.position, _enemy.transform.position) > _config.ShootRange)
        _enemyStateMachine.Enter<EnemyRunToPlayerState>();

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

      LauchGrenade();
    }

    private void LauchGrenade()
    {
      GrenadeTypeId grenadeTypeId = _config.GrenadeTypeId;

      var grenade = _gameLoopZenjectFactory.InstantiateMono<Grenade>();

      Vector3 targetPosition = _playerProvider.Player.transform.position;

      var offset = .6f;

      float xOffset = Random.Range(-offset, offset);
      float zOffset = Random.Range(-offset, offset);

      Vector3 newPosition = new Vector3(targetPosition.x + xOffset, targetPosition.y, targetPosition.z + zOffset);

      var mover = grenade.GetComponent<GrenadeMover>();
      mover.Init(_staticDataService.GetGrenadeConfig(grenadeTypeId), _enemy.transform.position, newPosition);

      var detonator = grenade.GetComponent<GrenadeDetonator>();
      detonator.Init(_staticDataService.GetGrenadeConfig(grenadeTypeId));

      mover.Throw();
    }
  }
}