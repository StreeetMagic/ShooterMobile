using System;
using System.Collections.Generic;
using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using Infrastructure.Utilities;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponAmmo 
  {
    private readonly WeaponStorage _weaponStorage;
    private readonly ConfigService _configService;

    private readonly Dictionary<WeaponTypeId, ReactiveProperty<int>> _ammo = new();

    public PlayerWeaponAmmo(WeaponStorage weaponStorage, ConfigService configService)
    {
      _weaponStorage = weaponStorage;
      _configService = configService;
    }

    public ReactiveProperty<int> GetAmmo(WeaponTypeId weaponTypeId)
    {
      Initialize();
      
      if (_ammo.TryGetValue(weaponTypeId, out ReactiveProperty<int> ammo))
        return ammo;

      throw new Exception("Unknown weapon type id: " + weaponTypeId);
    }

    public void Initialize()
    {
      foreach (WeaponTypeId weapon in _weaponStorage.Weapons.Value)
      {
        if (_ammo.ContainsKey(weapon))
          continue;
        
        _ammo.Add(weapon, new ReactiveProperty<int>(_configService.GetWeaponConfig(weapon).MagazineCapacity));
      }
    }

    public bool TryGetAmmo(WeaponTypeId weaponTypeId, int count)
    {
      if (_ammo[weaponTypeId].Value < count)
        return false;

      _ammo[weaponTypeId].Value -= count;
      return true;
    }

    public void Reload(WeaponTypeId weaponTypeId)
    {
      if (_ammo[weaponTypeId].Value == _configService.GetWeaponConfig(weaponTypeId).MagazineCapacity)
        return;

      _ammo[weaponTypeId].Value = _configService.GetWeaponConfig(weaponTypeId).MagazineCapacity;
    }

    public void Dispose()
    {
    }
  }
}