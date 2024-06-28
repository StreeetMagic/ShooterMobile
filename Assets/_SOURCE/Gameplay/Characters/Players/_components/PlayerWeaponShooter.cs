using Gameplay.Projectiles.Scripts;
using Gameplay.Utilities;
using Gameplay.Weapons;
using Infrastructure.AudioServices;
using Infrastructure.AudioServices.Sounds;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponShooter
  {
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;
    private readonly PlayerWeaponAmmo _weaponAmmo;
    private readonly PlayerWeaponMagazineReloader _reloader;
    private readonly PlayerWeaponShootingPoint _shootingPoint;
    private readonly PlayerWeaponMuzzleFlashEffector _muzzleFlashEffector;
    private readonly PlayerWeaponIdProvider _weaponIdProvider;
    private readonly PlayerTargetHolder _targetHolder;

    public PlayerWeaponShooter(ProjectileFactory projectileFactory, AudioService audioService,
      PlayerWeaponAmmo playerWeaponAmmo, PlayerWeaponMagazineReloader reloader, PlayerWeaponShootingPoint shootingPoint,
      PlayerWeaponMuzzleFlashEffector muzzleFlashEffector, PlayerWeaponIdProvider playerWeaponIdProvider,
      PlayerTargetHolder playerTargetHolder)
    {
      _projectileFactory = projectileFactory;
      _audioService = audioService;
      _weaponAmmo = playerWeaponAmmo;
      _reloader = reloader;
      _shootingPoint = shootingPoint;
      _muzzleFlashEffector = muzzleFlashEffector;
      _weaponIdProvider = playerWeaponIdProvider;
      _targetHolder = playerTargetHolder;
    }

    public void Shoot(WeaponConfig weaponConfig)
    {
      if (_weaponAmmo.TryGetAmmo(weaponConfig.WeaponTypeId, 1) == false)
      {
        _reloader.Activate(weaponConfig.WeaponTypeId);
        return;
      }

      for (int i = 0; i < weaponConfig.BulletsPerShot; i++)
      {
        if (_targetHolder.CurrentTarget == null)
          return;

        Vector3 directionToTarget = _targetHolder.CurrentTarget.transform.position - _shootingPoint.Transform.position;

        directionToTarget = AngleChanger.AddAngle(directionToTarget, weaponConfig.BulletSpreadAngle);

        _projectileFactory.CreatePlayerProjectile(_shootingPoint.Transform, directionToTarget, _weaponIdProvider.CurrentId.Value);
      }

      _muzzleFlashEffector.Play(_shootingPoint.Transform, _weaponIdProvider.CurrentId.Value);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}