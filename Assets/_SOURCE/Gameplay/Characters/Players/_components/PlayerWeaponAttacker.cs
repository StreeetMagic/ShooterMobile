using System;
using Gameplay.Characters.Players.Animators;
using Gameplay.Projectiles.Scripts;
using Gameplay.Utilities;
using Gameplay.Weapons;
using Infrastructure.AudioServices;
using Infrastructure.AudioServices.Sounds;
using Infrastructure.ConfigServices;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponAttacker
  {
    private readonly ConfigService _configService;
    private readonly PlayerProvider _playerProvider;
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;
    private readonly PlayerWeaponIdProvider _playerWeaponIdProvider;
    private readonly PlayerAnimator _playerAnimator;

    private float _timeLeft;
    private float _burstPauseLeft;
    private int _burstShots;

    public PlayerWeaponAttacker(ConfigService configService, PlayerProvider playerProvider, 
      ProjectileFactory projectileFactory, AudioService audioService, PlayerWeaponIdProvider playerWeaponIdProvider, PlayerAnimator playerAnimator)
    {
      _configService = configService;
      _playerProvider = playerProvider;
      _projectileFactory = projectileFactory;
      _audioService = audioService;
      _playerWeaponIdProvider = playerWeaponIdProvider;
      _playerAnimator = playerAnimator;
    }

    private WeaponConfig WeaponConfig => _configService.GetWeaponConfig(_playerWeaponIdProvider.Id);
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
      
      PlayWeaponAnimation(WeaponConfig.WeaponTypeId);
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

    private void PlayWeaponAnimation(WeaponTypeId id)
    {
      switch (id)
      {
        case WeaponTypeId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);
        
        case WeaponTypeId.Knife:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);
        
        case WeaponTypeId.DesertEagle:
          _playerAnimator.PlayPistolShoot();
          break;
        
        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          _playerAnimator.PlayRifleShoot();
          break;
        
        case WeaponTypeId.Xm1014:
          _playerAnimator.PlayShotgunShoot();
          Debug.Log("shotgun");
          break;
        
        default:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);
      }
    }
  }
}