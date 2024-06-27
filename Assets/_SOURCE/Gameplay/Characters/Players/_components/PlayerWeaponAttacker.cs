using System;
using Gameplay.Characters.Players.Animators;
using Gameplay.Projectiles.Scripts;
using Gameplay.Utilities;
using Gameplay.Weapons;
using Infrastructure.AudioServices;
using Infrastructure.AudioServices.Sounds;
using Infrastructure.ConfigProviders;
using Infrastructure.VisualEffects;
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
    private readonly PlayerWeaponMagazineReloader _reloader;
    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly PlayerWeaponShootingPoint _shootingPoint;
    private readonly VisualEffectFactory _visualEffectFactory;

    private float _timeLeft;
    private float _burstPauseLeft;
    private int _burstShots;

    public PlayerWeaponAttacker(ConfigProvider configProvider,
      ProjectileFactory projectileFactory, AudioService audioService, PlayerWeaponIdProvider playerWeaponIdProvider,
      PlayerAnimator playerAnimator, PlayerWeaponAmmo playerWeaponAmmo, PlayerWeaponMagazineReloader reloader,
      PlayerTargetHolder playerTargetHolder, PlayerWeaponShootingPoint shootingPoint, VisualEffectFactory visualEffectFactory)
    {
      _configProvider = configProvider;
      _projectileFactory = projectileFactory;
      _audioService = audioService;
      _playerWeaponIdProvider = playerWeaponIdProvider;
      _playerAnimator = playerAnimator;
      _playerWeaponAmmo = playerWeaponAmmo;
      _reloader = reloader;
      _playerTargetHolder = playerTargetHolder;
      _shootingPoint = shootingPoint;
      _visualEffectFactory = visualEffectFactory;
    }

    private float Cooldown => (float)1 / GetWeaponConfig().FireRate;

    public void Tick()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return;
      }

      switch (GetWeaponConfig().WeaponAttackTypeId)
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

      PlayWeaponAnimation(GetWeaponConfig().WeaponTypeId);
    }

    public void ResetValues()
    {
      _timeLeft = Cooldown;
      _burstPauseLeft = GetWeaponConfig().TimeBetweenBursts;
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

      if (_burstShots >= GetWeaponConfig().ShotsPerBurst)
      {
        _burstPauseLeft = GetWeaponConfig().TimeBetweenBursts;
        _burstShots = 0;
      }
    }

    private void Shoot()
    {
      if (_playerWeaponAmmo.TryGetAmmo(GetWeaponConfig().WeaponTypeId, 1) == false)
      {
        _reloader.Activate(GetWeaponConfig().WeaponTypeId);
        return;
      }

      for (int i = 0; i < GetWeaponConfig().BulletsPerShot; i++)
      {
        Vector3 directionToTarget = _playerTargetHolder.CurrentTarget.transform.position - _shootingPoint.Transform.position;

        directionToTarget = AngleChanger.AddAngle(directionToTarget, GetWeaponConfig().BulletSpreadAngle);

        _projectileFactory.CreatePlayerProjectile(_shootingPoint.Transform, directionToTarget, _playerWeaponIdProvider.CurrentId.Value);
      }

      CreatePlayerMuzzleFlashEffect(_shootingPoint.Transform, _playerWeaponIdProvider.CurrentId.Value);
      _audioService.PlaySound(SoundId.Shoot);
    }

    private void Strike()
    {
      _playerTargetHolder.CurrentTarget.TakeDamage(GetWeaponConfig().Damage);
    }

    private void PlayWeaponAnimation(WeaponTypeId id)
    {
      switch (id)
      {
        case WeaponTypeId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(id), id, null);

        case WeaponTypeId.Knife:
          _playerAnimator.PlayRandomKnifeHitAnimation(GetWeaponConfig().MeeleAttackDuration);
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

    private WeaponConfig GetWeaponConfig() =>
      _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value);

    private void CreatePlayerMuzzleFlashEffect(Transform parent, WeaponTypeId weaponTypeId)
    {
      VisualEffectId id;

      switch (weaponTypeId)
      {
        case WeaponTypeId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(weaponTypeId), weaponTypeId, null);

        case WeaponTypeId.DesertEagle:
          id = VisualEffectId.PistolMuzzleFlash;
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          id = VisualEffectId.RiffleMuzzleFlash;
          break;

        case WeaponTypeId.Xm1014:
          id = VisualEffectId.ShotgunMuzzleFlash;
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(weaponTypeId), weaponTypeId, null);
      }

      _visualEffectFactory.CreateAndDestroy(id, parent.position, parent.rotation);
    }
  }
}