using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyBehaviourController : MonoBehaviour
  {
    [Inject] private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    [Inject] private EnemyMoverToPlayer _enemyMoverToPlayer;
    [Inject] private HitStatus _hitStatus;
    [Inject] private IHealth _enemyHealth;
    [Inject] private EnemyShootAtPlayer _enemyShootAtPlayer;
    [Inject] private EnemyReturnToSpawnStatus _returnToSpawnStatus;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private EnemyToSpawnerDisance _enemyToSpawnerDisance;
    [Inject] private EnemyConfig _config;
    [Inject] private Transform _spawnerTransform;

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
      (_playerProvider.Player.transform.position - transform.position).magnitude < _config.ShootRange;

    private bool EnemyInPatrolingRadius() =>
      (_spawnerTransform.position - transform.position).magnitude < _config.PatrolingRadius;
  }
}