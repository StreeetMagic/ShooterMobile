using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyShootAtPlayer : MonoBehaviour
  {
    private float _time;

    [Inject] private EnemyShooter _shooter;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private EnemyMoverToPlayer _enemyMoverToPlayer;
    [Inject] private EnemyToTargetRotator _enemyToTargetRotator;
    [Inject] private EnemyConfig _config;
    [Inject] private ShootingPoint _shootingPoint;
    [Inject] private EnemyAnimatorProvider _animatorProvider;

    private float Cooldown => 1 / (float)_config.FireRate;
    private Transform PlayerTransform => _playerProvider.Player.transform;

    private void OnEnable()
    {
      _animatorProvider.Instance.StopRunAnimation();
      _animatorProvider.Instance.StopWalkAnimation();
      _enemyMoverToPlayer.enabled = false;
    }

    private void Update()
    {
      if (_playerProvider.Player == null)
        return;

      // Vector3 direction = (PlayerTransform.position - transform.position).normalized;

      Vector3 direction = new Vector3(PlayerTransform.position.x - transform.position.x, 0, PlayerTransform.position.z - transform.position.z).normalized;

      _enemyToTargetRotator.RotateToTargetPosition(direction);

      _time += Time.deltaTime;

      if (_time >= Cooldown)
      {
        var distance = (PlayerTransform.position - transform.position).magnitude;

        if (distance <= _config.Radius)
        {
          Shoot(direction);
          _time = 0;
        }
      }
    }

    private void Shoot(Vector3 direction)
    {
      _shooter.Shoot(_shootingPoint.PointTransform, _shootingPoint.PointTransform.position, direction);

      _animatorProvider.Instance.PlayShootAnimation();
    }
  }
}