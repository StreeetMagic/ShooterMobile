using Gameplay.Characters.Players;
using Infrastructure.StateMachine;
using Loggers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyChooseAttackState : IState, ITickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;
    private readonly EnemyStateMachine _stateMachine;
    private readonly EnemyGrenadeThrower _grenadeThrower;
    private readonly EnemyToSpawnerDistance _toSpawnerDistance;
    private readonly EnemyReturnToSpawnStatus _returnToSpawnStatus;
    private readonly EnemyWeaponReloader _reloader;
    private readonly EnemyMaxAttakingRange _enemyMaxAttakingRange;
    private readonly DebugLogger _logger;

    private float _shootTimeLeft;

    public EnemyChooseAttackState(PlayerProvider playerProvider, EnemyConfig config,
      Enemy enemy, EnemyStateMachine stateMachine, EnemyGrenadeThrower grenadeThrower,
      EnemyToSpawnerDistance toSpawnerDistance, EnemyReturnToSpawnStatus returnToSpawnStatus, EnemyWeaponReloader reloader,
      EnemyMaxAttakingRange enemyMaxAttakingRange, DebugLogger logger)
    {
      _playerProvider = playerProvider;

      _config = config;

      _enemy = enemy;
      _stateMachine = stateMachine;
      _grenadeThrower = grenadeThrower;
      _toSpawnerDistance = toSpawnerDistance;
      _returnToSpawnStatus = returnToSpawnStatus;
      _reloader = reloader;
      _enemyMaxAttakingRange = enemyMaxAttakingRange;
      _logger = logger;
    }

    public void Enter()
    {
    }

    public void Tick()
    {
      if (_toSpawnerDistance.IsAway)
      {
        _returnToSpawnStatus.IsReturn = true;
        _stateMachine.Enter<EnemyPatrolingState>();
      }
      else if (Away())
      {
        _stateMachine.Enter<EnemyChasingPlayerState>();
      }
      else if (InMeleeRange())
      {
        _stateMachine.Enter<EnemyMeleeAttackingState>();
      }
      else if (_grenadeThrower.ReadyToThrow && _config.IsGrenadeThrower)
      {
        _stateMachine.Enter<EnemyThrowingGrenadeState>();
      }
      else if (_reloader.IsEmpty && _config.IsShooter)
      {
        _stateMachine.Enter<EnemyReloadingWeaponState>();
      }
      else if (_config.IsShooter)
      {
        _stateMachine.Enter<EnemyShootingState>();
      }
      else
      {
        _logger.Log("никуда не попали");
      }
    }

    public void Exit()
    {
    }

    private bool Away()
    {
      float distanceToPlayer = Vector3.Distance(_playerProvider.Instance.transform.position, _enemy.transform.position);

      return distanceToPlayer > _enemyMaxAttakingRange.Get();
    }

    private bool InMeleeRange()
    {
      return Vector3.Distance(_playerProvider.Instance.transform.position, _enemy.transform.position) <= _config.MeleeRange;
    }
  }
}