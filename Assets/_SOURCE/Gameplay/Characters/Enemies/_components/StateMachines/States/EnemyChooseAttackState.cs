using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Players;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyChooseAttackState : IState, ITickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;
    private readonly EnemyStateMachine _stateMachine;
    private readonly EnemyGrenadeThrower _grenadeThrower;
    private readonly EnemyToSpawnerDisance _toSpawnerDisance;
    private readonly EnemyReturnToSpawnStatus _returnToSpawnStatus;
    private readonly EnemyWeaponReloader _reloader;

    private float _shootTimeLeft;

    public EnemyChooseAttackState(PlayerProvider playerProvider, EnemyConfig config,
      Enemy enemy, EnemyStateMachine stateMachine, EnemyGrenadeThrower grenadeThrower,
      EnemyToSpawnerDisance toSpawnerDisance, EnemyReturnToSpawnStatus returnToSpawnStatus, EnemyWeaponReloader reloader)
    {
      _playerProvider = playerProvider;

      _config = config;

      _enemy = enemy;
      _stateMachine = stateMachine;
      _grenadeThrower = grenadeThrower;
      _toSpawnerDisance = toSpawnerDisance;
      _returnToSpawnStatus = returnToSpawnStatus;
      _reloader = reloader;
    }

    public void Enter()
    {
      if (_toSpawnerDisance.IsAway)
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
      else if (
        _grenadeThrower.TargetStandsOnSamePosition 
        && _grenadeThrower.GrenadesLeft > 0 
        && _grenadeThrower.GrenadeCooldownLeft <= 0
        && _config.GrenadeThrower)
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
    }

    public void Tick()
    {
    }

    public void Exit()
    {
    }

    private bool Away()
    {
      List<float> distances = new();

      if (_config.IsShooter)
        distances.Add(_config.ShootRange);

      if (_config.GrenadeThrower)
        distances.Add(_config.GrenadeThrowRange);

      distances.Add(_config.MeleeRange);

      float maxDistance = distances.Max();

      float distanceToPlayer = Vector3.Distance(_playerProvider.Player.transform.position, _enemy.transform.position);

      return distanceToPlayer > maxDistance;
    }

    private bool InMeleeRange()
    {
      return Vector3.Distance(_playerProvider.Player.transform.position, _enemy.transform.position) <= _config.MeleeRange;
    }
  }
}