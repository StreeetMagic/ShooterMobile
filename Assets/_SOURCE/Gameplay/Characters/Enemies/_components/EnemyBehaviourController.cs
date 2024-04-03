using System;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players.Factories;
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

    [Inject]
    public void Construct(EnemyMoverToSpawnPoint enemyMoverToSpawnPoint,
      EnemyMoverToPlayer enemyMoverToPlayer, HitStatus hitStatus,
      EnemyHealth enemyHealth, EnemyShootAtPlayer enemyShooter, Enemy enemy, ReturnToSpawnStatus returnToSpawnStatus,
      PlayerProvider playerProvider)
    {
      _enemyMoverToSpawnPoint = enemyMoverToSpawnPoint;
      _enemyMoverToPlayer = enemyMoverToPlayer;
      _hitStatus = hitStatus;
      _enemyHealth = enemyHealth;
      _enemyShootAtPlayer = enemyShooter;
      _enemy = enemy;
      _returnToSpawnStatus = returnToSpawnStatus;
      _playerProvider = playerProvider;
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

        return;
      }

      var distanceToSpawner = (_enemy.SpawnerTransform.position - transform.position).magnitude;
      var distanceToPlayer = (_playerProvider.Player.transform.position - transform.position).magnitude;

      if (_returnToSpawnStatus.IsReturn)
      {
        _enemyMoverToSpawnPoint.enabled = true;
        _enemyMoverToPlayer.enabled = false;
        _enemyShootAtPlayer.enabled = false;
      }
      else if (_hitStatus.IsHit && distanceToSpawner < _enemy.Config.PatrolingRadius)
      {
        _enemyMoverToSpawnPoint.enabled = false;

        if (distanceToPlayer < _enemy.Config.Radius)
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
      else
      {
        _enemyMoverToSpawnPoint.enabled = true;
        _enemyMoverToPlayer.enabled = false;
      }
    }
  }
}