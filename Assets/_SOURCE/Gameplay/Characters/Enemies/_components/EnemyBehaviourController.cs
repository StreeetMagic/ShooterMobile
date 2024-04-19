using System;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players.Factories;
using Loggers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyBehaviourController : MonoBehaviour
  {
    private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    private EnemyMoverToPlayer _enemyMoverToPlayer;
    private HitStatus _hitStatus;
    private EnemyHealth _enemyHealth;
    private EnemyShootAtPlayer _enemyShootAtPlayer;
    private Enemy _enemy;
    private ReturnToSpawnStatus _returnToSpawnStatus;
    private PlayerProvider _playerProvider;
    private DebugLogger _debugLogger;
    private EnemyToSpawnerDisance _enemyToSpawnerDisance;

    [Inject]
    public void Construct(EnemyMoverToSpawnPoint enemyMoverToSpawnPoint,
      EnemyMoverToPlayer enemyMoverToPlayer, HitStatus hitStatus,
      EnemyHealth enemyHealth, EnemyShootAtPlayer enemyShooter, Enemy enemy, ReturnToSpawnStatus returnToSpawnStatus,
      PlayerProvider playerProvider, DebugLogger debugLogger, EnemyToSpawnerDisance enemyToSpawnerDisance)
    {
      _enemyMoverToSpawnPoint = enemyMoverToSpawnPoint;
      _enemyMoverToPlayer = enemyMoverToPlayer;
      _hitStatus = hitStatus;
      _enemyHealth = enemyHealth;
      _enemyShootAtPlayer = enemyShooter;
      _enemy = enemy;
      _returnToSpawnStatus = returnToSpawnStatus;
      _playerProvider = playerProvider;
      _debugLogger = debugLogger;
      _enemyToSpawnerDisance = enemyToSpawnerDisance;
    }

    private void Start()
    {
      _enemyMoverToSpawnPoint.enabled = false;
      _enemyMoverToPlayer.enabled = false;
      _enemyShootAtPlayer.enabled = false;
    }

    private void FixedUpdate()
    {
      if (_enemyHealth.IsDead)
      {
        _enemyMoverToSpawnPoint.enabled = false;
        _enemyMoverToPlayer.enabled = false;
        _enemyShootAtPlayer.enabled = false;
      }
      else if (_returnToSpawnStatus.IsReturn)
      {
        _enemyMoverToSpawnPoint.enabled = true;
        _enemyMoverToPlayer.enabled = false;
        _enemyShootAtPlayer.enabled = false;
      }
      else if (EnemyInPatrolingRadius() == false && _enemyToSpawnerDisance.IsAway)
      {
        _enemyMoverToSpawnPoint.enabled = true;
        _returnToSpawnStatus.IsReturn = true;
        _enemyMoverToPlayer.enabled = false;
        _enemyShootAtPlayer.enabled = false;
      }
      else if (_hitStatus.IsHit && EnemyInPatrolingRadius())
      {
        _enemyMoverToSpawnPoint.enabled = false;

        if (EnemyInShootingRadius())
        {
          _enemyMoverToPlayer.enabled = false;
          _enemyShootAtPlayer.enabled = true;
        }
        else
        {
          _enemyMoverToPlayer.enabled = true;
          _enemyShootAtPlayer.enabled = false;
        }
      }
    }

    private bool EnemyInShootingRadius() =>
      (_playerProvider.Player.transform.position - transform.position).magnitude < _enemy.Config.Radius;

    private bool EnemyInPatrolingRadius() =>
      (_enemy.SpawnerTransform.position - transform.position).magnitude < _enemy.Config.PatrolingRadius;
  }
}