using System;
using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponMagazineReloader
  {
    private readonly ConfigProvider _configProvider;
    private readonly PlayerProvider _playerProvider;

    private WeaponTypeId _weaponId;
    private float _timeLeft;

    public PlayerWeaponMagazineReloader(ConfigProvider configProvider, PlayerProvider playerProvider)
    {
      _configProvider = configProvider;
      _playerProvider = playerProvider;
    }

    public bool IsActive { get; private set; }

    public void Activate(WeaponTypeId weaponId)
    {
      if (IsActive)
        return;

      IsActive = true;
      _weaponId = weaponId;
      _timeLeft = _configProvider.GetWeaponConfig(weaponId).ReloadTime;
    }

    public void Tick()
    {
      if (IsActive == false)
        throw new Exception("Reloader is not active");

      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return;
      }

      if (_timeLeft <= 0)
      {
        _timeLeft = 0;
      }

      _playerProvider.Instance.WeaponAmmo.Reload(_weaponId);
      IsActive = false;
      _weaponId = WeaponTypeId.Unknown;
    }
  }
}