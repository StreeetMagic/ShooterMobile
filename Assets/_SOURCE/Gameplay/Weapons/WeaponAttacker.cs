using System;
using AudioServices;
using Gameplay.Characters.Players;
using Gameplay.Projectiles.Scripts;
using Sounds;
using StaticDataServices;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Weapons
{
  public class WeaponAttacker : MonoBehaviour
  {
    [Inject] private IStaticDataService _staticDataService;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ProjectileFactory _projectileFactory;
    [Inject] private AudioService _audioService;
    [Inject] private PlayerWeaponId _playerWeaponId;

    private float _timeLeft;
    private float _burstPauseLeft;
    private int _burstShots;

    private WeaponConfig WeaponConfig => _staticDataService.GetWeaponConfig(_playerWeaponId.WeaponTypeId);
    private float Cooldown => (float)1 / WeaponConfig.FireRate;

    private Transform Transform => _playerProvider.WeaponShootingPointPoint.Transform;
    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private int BulletsPerShot => WeaponConfig.BulletsPerShot;
    private float BulletSpreadAngle => WeaponConfig.BulletSpreadAngle;
    private WeaponAttackTypeId WeaponAttackTypeId => WeaponConfig.WeaponAttackTypeId;

    public void Attack()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return;
      }

      switch (WeaponAttackTypeId)
      {
        case WeaponAttackTypeId.Single:
          Shoot();
          _timeLeft = Cooldown;
          break;

        case WeaponAttackTypeId.Burst:
          Burst();
          break;

        case WeaponAttackTypeId.Auto:
          Shoot();
          _timeLeft = Cooldown;
          break;

        case WeaponAttackTypeId.Melee:
          throw new NotImplementedException();

        case WeaponAttackTypeId.Throw:
          throw new NotImplementedException();

        case WeaponAttackTypeId.Unknown:
          throw new Exception("WeaponAttackTypeId.Unknown");

        default:
          throw new Exception("Unknown WeaponAttackTypeId");
      }
    }

    public void ResetValues()
    {
      _timeLeft = Cooldown;
      _burstPauseLeft = WeaponConfig.TimeBetweenBursts;
      _burstShots = 0;
    }

    private void Burst()
    {
      if (_burstPauseLeft > 0)
      {
        _burstPauseLeft -= Time.deltaTime;
        return;
      }

      Shoot();
      _burstShots++;
      _timeLeft = Cooldown;

      if (_burstShots >= WeaponConfig.ShotsPerBurst)
      {
        _burstPauseLeft = WeaponConfig.TimeBetweenBursts;
        _burstShots = 0;
      }
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
}