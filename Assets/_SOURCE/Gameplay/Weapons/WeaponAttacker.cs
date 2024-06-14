using System;
using Gameplay.Characters.Players;
using Gameplay.Projectiles.Scripts;
using Gameplay.Utilities;
using Infrastructure.AudioServices;
using Infrastructure.AudioServices.Sounds;
using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Weapons
{
  public class WeaponAttacker : MonoBehaviour
  {
    [Inject] private ConfigService _configService;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ProjectileFactory _projectileFactory;
    [Inject] private AudioService _audioService;
    [Inject] private PlayerWeaponIdProvider _playerWeaponIdProvider;

    private float _timeLeft;
    private float _burstPauseLeft;
    private int _burstShots;

    private WeaponConfig WeaponConfig => _configService.GetWeaponConfig(_playerWeaponIdProvider.WeaponTypeId);
    private float Cooldown => (float)1 / WeaponConfig.FireRate;

    public void Attack()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return;
      }

      switch (WeaponConfig.WeaponAttackTypeId)
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
          Strike();
          _timeLeft = Cooldown;
          break;

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
      for (int i = 0; i < WeaponConfig.BulletsPerShot; i++)
      {
        Vector3 directionToTarget = _playerProvider.Instance.TargetHolder.DirectionToTarget;

        directionToTarget = AngleChanger.AddAngle(directionToTarget, WeaponConfig.BulletSpreadAngle);

        _projectileFactory.CreatePlayerProjectile(_playerProvider.Instance.WeaponShootingPointPoint.Transform, directionToTarget);
        _audioService.PlaySound(SoundId.Shoot);
      }
    }

    private void Strike()
    {
      _playerProvider.Instance.TargetHolder.CurrentTarget.TakeDamage(WeaponConfig.Damage);
    }
  }
}