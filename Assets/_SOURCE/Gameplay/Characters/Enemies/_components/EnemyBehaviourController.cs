using System;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyBehaviourController : MonoBehaviour
  {
    private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    private EnemyMoverToPlayer _enemyMoverToPlayer;
    private HealthStatusController _healthStatus;
    private EnemyHealth _enemyHealth;
    private EnemyShootAtPlayer _enemyShootAtPlayer;
    private Enemy _enemy;

    [Inject]
    public void Construct(EnemyMoverToSpawnPoint enemyMoverToSpawnPoint,
      EnemyMoverToPlayer enemyMoverToPlayer, HealthStatusController healthStatus, 
      EnemyHealth enemyHealth, EnemyShootAtPlayer enemyShooter, Enemy enemy)
    {
      _enemyMoverToSpawnPoint = enemyMoverToSpawnPoint;
      _enemyMoverToPlayer = enemyMoverToPlayer;
      _healthStatus = healthStatus;
      _enemyHealth = enemyHealth;
      _enemyShootAtPlayer = enemyShooter;
      _enemy = enemy;
    }

    private void Start()
    {
      _enemyMoverToSpawnPoint.enabled = false;
      _enemyMoverToPlayer.enabled = false;
      _enemyShootAtPlayer.enabled = false;
    }

    private void Update()
    {
      if (_enemyHealth.IsDead)
        return;
      
      var distanceToSpawner = (_enemy.SpawnerTransform.position - transform.position).magnitude;
      
      Debug.Log("distanceToSpawner" + distanceToSpawner);

      if (_healthStatus.IsHit && distanceToSpawner < _enemy.Config.PatrolingRadius)
      {
        _enemyMoverToSpawnPoint.enabled = false;
        _enemyMoverToPlayer.enabled = true;
      }
      else
      {
        _enemyMoverToSpawnPoint.enabled = true;
        _enemyMoverToPlayer.enabled = false;
      }
    }
  }
}