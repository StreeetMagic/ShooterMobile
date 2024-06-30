using System;
using System.Collections.Generic;
using Infrastructure.ConfigProviders;
using Infrastructure.Utilities;
using Weapons;
using Zenject;

namespace Characters.Players._components
{
  public class PlayerWeaponAmmo : IInitializable, IDisposable
  {
    private readonly WeaponStorage _weaponStorage;
    private readonly ConfigProvider _configProvider;

    private readonly Dictionary<WeaponTypeId, ReactiveProperty<int>> _ammo = new();

    public PlayerWeaponAmmo(WeaponStorage weaponStorage, ConfigProvider configProvider)
    {
      _weaponStorage = weaponStorage;
      _configProvider = configProvider;
    }

    public ReactiveProperty<int> GetAmmo(WeaponTypeId weaponTypeId)
    {
      if (_ammo.TryGetValue(weaponTypeId, out ReactiveProperty<int> ammo))
        return ammo;

      throw new Exception("Unknown weapon type id: " + weaponTypeId);
    }

    public void Initialize()
    {
      AddAmmos(_weaponStorage.Weapons.Value);

      _weaponStorage.Weapons.Changed += AddAmmos;
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
      if (_ammo[weaponTypeId].Value == _configProvider.GetWeaponConfig(weaponTypeId).MagazineCapacity)
        return;

      _ammo[weaponTypeId].Value = _configProvider.GetWeaponConfig(weaponTypeId).MagazineCapacity;
    }

    public void Dispose()
    {
      _weaponStorage.Weapons.Changed -= AddAmmos;
    }

    private void AddAmmos(IReadOnlyList<WeaponTypeId> weapons)
    {
      foreach (WeaponTypeId weapon in weapons)
      {
        if (_ammo.ContainsKey(weapon))
          continue;

        _ammo.Add(weapon, new ReactiveProperty<int>(_configProvider.GetWeaponConfig(weapon).MagazineCapacity));
      }
    }
  }
}