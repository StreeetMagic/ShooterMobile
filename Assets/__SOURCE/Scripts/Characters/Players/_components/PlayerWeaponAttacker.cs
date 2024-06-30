using System;
using Gameplay.Weapons;
using Infrastructure.ConfigProviders;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponAttacker
  {
    private readonly ConfigProvider _configProvider;

    private readonly PlayerWeaponIdProvider _playerWeaponIdProvider;
    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly PlayerWeaponAttackAnimationController _weaponAttackAnimationController;
    private readonly PlayerWeaponShooter _playerWeaponShooter;

    private float _timeLeft;
    private float _burstPauseLeft;
    private int _burstShots;

    public PlayerWeaponAttacker(ConfigProvider configProvider, PlayerWeaponIdProvider playerWeaponIdProvider,
      PlayerTargetHolder playerTargetHolder, PlayerWeaponAttackAnimationController playerWeaponAttackAnimationController,
      PlayerWeaponShooter playerWeaponShooter)
    {
      _configProvider = configProvider;
      _playerWeaponIdProvider = playerWeaponIdProvider;
      _playerTargetHolder = playerTargetHolder;
      _weaponAttackAnimationController = playerWeaponAttackAnimationController;
      _playerWeaponShooter = playerWeaponShooter;
    }

    public void Tick()
    {
      if (LifeTime())
        return;

      Attack();

      PlayAttackAnimation();
    }

    public void ResetValues()
    {
      _timeLeft = Cooldown();
      _burstPauseLeft = WeaponConfig().TimeBetweenBursts;
      _burstShots = 0;
    }

    private void Attack()
    {
      switch (WeaponConfig().WeaponAttackTypeId)
      {
        case WeaponAttackTypeId.Unknown:
          throw new Exception("WeaponAttackTypeId.Unknown");

        case WeaponAttackTypeId.Burst:
          Burst();
          break;

        case WeaponAttackTypeId.Auto:
          _playerWeaponShooter.Shoot(WeaponConfig());
          _timeLeft = Cooldown();
          break;

        case WeaponAttackTypeId.Melee:
          Strike();
          _timeLeft = Cooldown();
          break;

        case WeaponAttackTypeId.Throw:
          throw new NotImplementedException();

        default:
          throw new Exception("Unknown WeaponAttackTypeId");
      }
    }

    private bool LifeTime()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return true;
      }
      else
      {
        return false;
      }
    }

    private void Burst()
    {
      if (_burstPauseLeft > 0)
      {
        _burstPauseLeft -= Time.deltaTime;
        return;
      }

      _playerWeaponShooter.Shoot(WeaponConfig());
      _burstShots++;
      _timeLeft = Cooldown();

      if (_burstShots < WeaponConfig().ShotsPerBurst)
        return;

      _burstPauseLeft = WeaponConfig().TimeBetweenBursts;
      _burstShots = 0;
    }

    private void Strike()
    {
      _playerTargetHolder.CurrentTarget.TakeDamage(WeaponConfig().Damage);
    }

    private WeaponConfig WeaponConfig()
    {
      return _configProvider.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value);
    }

    private float Cooldown()
    {
      return 1 / WeaponConfig().FireRate;
    }

    private void PlayAttackAnimation()
    {
      _weaponAttackAnimationController.Play(WeaponConfig().WeaponTypeId, WeaponConfig().MeeleAttackDuration);
    }
  }
}