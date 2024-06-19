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
    private readonly ConfigProvider _configProvider;
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;
    private readonly PlayerWeaponIdProvider _playerWeaponIdProvider;
    private readonly PlayerAnimator _playerAnimator;
    private readonly PlayerWeaponAmmo _playerWeaponAmmo;
    private readonly PlayerWeaponMagazineReloader _playerWeaponMagazineReloader;
    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly PlayerWeaponShootingPoint _playerWeaponShootingPoint;

    private float _timeLeft;
    private float _burstPauseLeft;
    private int _burstShots;

    public PlayerWeaponAttacker(ConfigProvider configProvider,
      ProjectileFactory projectileFactory, AudioService audioService, PlayerWeaponIdProvider playerWeaponIdProvider,
      PlayerAnimator playerAnimator, PlayerWeaponAmmo playerWeaponAmmo, PlayerWeaponMagazineReloader playerWeaponMagazineReloader,
      PlayerTargetHolder playerTargetHolder, PlayerWeaponShootingPoint playerWeaponShootingPoint)
    {
      _configProvider = configProvider;
      _projectileFactory = projectileFactory;
      _audioService = audioService;
      _playerWeaponIdProvider = playerWeaponIdProvider;
      _playerAnimator = playerAnimator;
      _playerWeaponAmmo = playerWeaponAmmo;
      _playerWeaponMagazineReloader = playerWeaponMagazineReloader;
      _playerTargetHolder = playerTargetHolder;
      _playerWeaponShootingPoint = playerWeaponShootingPoint;
    }

    private float Cooldown => (float)1 / _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).FireRate;

    public void Tick()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return;
      }

      switch (_configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).WeaponAttackTypeId)
      {
        case WeaponAttackTypeId.Unknown:
          throw new Exception("WeaponAttackTypeId.Unknown");

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

        case WeaponAttackTypeId.СмениНаДругой:
          Debug.Log("СМЕНИ ТИП ОРУЖИЯ В КОНФИГЕ");
          break;

        case WeaponAttackTypeId.Throw:
          throw new NotImplementedException();

        default:
          throw new Exception("Unknown WeaponAttackTypeId");
      }

      PlayWeaponAnimation(_configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).WeaponTypeId);
    }

    public void ResetValues()
    {
      _timeLeft = Cooldown;
      _burstPauseLeft = _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).TimeBetweenBursts;
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

      if (_burstShots >= _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).ShotsPerBurst)
      {
        _burstPauseLeft = _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).TimeBetweenBursts;
        _burstShots = 0;
      }
    }

    private void Shoot()
    {
      if (_playerWeaponAmmo.TryGetAmmo(_configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).WeaponTypeId, 1) == false)
      {
        _playerWeaponMagazineReloader.Activate(_configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).WeaponTypeId);
        return;
      }

      for (int i = 0; i < _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).BulletsPerShot; i++)
      {
        Vector3 directionToTarget = _playerTargetHolder.DirectionToTarget;

        directionToTarget = AngleChanger.AddAngle(directionToTarget, _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).BulletSpreadAngle);

        _projectileFactory.CreatePlayerProjectile(_playerWeaponShootingPoint.Transform, directionToTarget, _playerWeaponIdProvider.CurrentId.Value);
      }

      _audioService.PlaySound(SoundId.Shoot);
    }

    private void Strike()
    {
      _playerTargetHolder.CurrentTarget.TakeDamage(_configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).Damage);
    }

    private void PlayWeaponAnimation(WeaponTypeId id)
    {
      switch (id)
      {
        case WeaponTypeId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);

        case WeaponTypeId.Knife:
          _playerAnimator.PlayRandomKnifeHitAnimation(_configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).MeeleAttackDuration);
          break;

        case WeaponTypeId.DesertEagle:
          _playerAnimator.PlayPistolShoot();
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          _playerAnimator.PlayRifleShoot();
          break;

        case WeaponTypeId.Xm1014:
          _playerAnimator.PlayShotgunShoot();
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);
      }
    }
  }
}