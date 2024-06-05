using AudioServices;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Projectiles.Scripts;
using Sounds;
using StaticDataServices;
using UnityEngine;
using Zenject;

public class WeaponAttacker : MonoBehaviour
{
  [Inject] private IStaticDataService _staticDataService;
  [Inject] private PlayerProvider _playerProvider;
  [Inject] private ProjectileFactory _projectileFactory;
  [Inject] private AudioService _audioService;
  [Inject] private PlayerWeaponId _playerWeaponId;

  private float _timeLeft;

  private WeaponConfig WeaponConfig => _staticDataService.GetWeaponConfig(_playerWeaponId.WeaponTypeId);
  private Transform Transform => _playerProvider.WeaponShootingPointPoint.Transform;
  private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
  private float Cooldown => (float)1 / WeaponConfig.FireRate;
  private int BulletsPerShot => WeaponConfig.BulletsPerShot;
  public float BulletSpreadAngle => WeaponConfig.BulletSpreadAngle;

  public void Attack()
  {
    if (_timeLeft > 0)
    {
      _timeLeft -= Time.deltaTime;
      return;
    }

    Shoot();

    _timeLeft = Cooldown;
  }

  public void ResetCooldown()
  {
    _timeLeft = Cooldown;
  }

  private void Shoot()
  {
    for (int i = 0; i < BulletsPerShot; i++)
    {
      Vector3 directionToTarget = PlayerTargetHolder.DirectionToTarget;

      directionToTarget = AddAngle(directionToTarget, BulletSpreadAngle);

      _projectileFactory.CreatePlayerProjectile(Transform, directionToTarget);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }

  private Vector3 AddAngle(Vector3 directionToTarget, float angle)
  {
    float randomHorizontalAngle = Random.Range(-angle, angle);
    float randomVerticalAngle = Random.Range(-angle, angle);

    Quaternion horizontalRotation = Quaternion.AngleAxis(randomHorizontalAngle, Vector3.up);
    Quaternion verticalRotation = Quaternion.AngleAxis(randomVerticalAngle, Vector3.right);

    directionToTarget = horizontalRotation * directionToTarget;
    directionToTarget = verticalRotation * directionToTarget;

    return directionToTarget.normalized;
  }
}