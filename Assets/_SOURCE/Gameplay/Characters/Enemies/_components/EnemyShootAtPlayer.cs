using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Players.Factories;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyShootAtPlayer : MonoBehaviour
  {
    private EnemyShooter _shooter;
    private Enemy _enemy;
    private float _time;
    private PlayerProvider _playerProvider;
    private EnemyMoverToPlayer _enemyMoverToPlayer;
    private EnemyToTargetRotator _enemyToTargetRotator;

    [Inject]
    public void Construct(EnemyShooter shooter, Enemy enemy,
      PlayerProvider playerProvider, EnemyMoverToPlayer enemyMoverToPlayer, EnemyToTargetRotator enemyToTargetRotator)
    {
      _shooter = shooter;
      _enemy = enemy;
      _playerProvider = playerProvider;
      _enemyMoverToPlayer = enemyMoverToPlayer;
      _enemyToTargetRotator = enemyToTargetRotator;
    }

    private float Cooldown => 1 / (float)_enemy.Config.FireRate;
    private Transform PlayerTransform => _playerProvider.Player.transform;

    private void OnEnable()
    {
      _time = 0;
      _enemyMoverToPlayer.enabled = false;
    }

    private void Update()
    {
      Vector3 direction = (PlayerTransform.position - transform.position).normalized;
      _enemyToTargetRotator.RotateToTargetPosition(direction);

      _time += Time.deltaTime;

      if (_time >= Cooldown)
      {
        var distance = (PlayerTransform.position - transform.position).magnitude;

        if (distance <= _enemy.Config.Radius)
        {
          Shoot(direction);
          _time = 0;
        }
      }
    }

    private void Shoot(Vector3 direction)
    {
      _shooter.Shoot(_enemy.ShootingPoint, _enemy.ShootingPoint.position, direction);
    }
  }
}