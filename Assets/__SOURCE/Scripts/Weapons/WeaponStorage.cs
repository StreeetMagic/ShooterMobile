using System;
using System.Collections.Generic;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;
using Zenject;

namespace Weapons
{
  public class WeaponStorage : IProgressWriter, IInitializable, IDisposable
  {
    private readonly WeaponShop _weaponShop;

    public WeaponStorage(WeaponShop weaponShop)
    {
      _weaponShop = weaponShop;
    }

    public ReactiveList<WeaponTypeId> Weapons { get; } = new();

    public void ReadProgress(ProjectProgress projectProgress)
    {
      Weapons.Value = projectProgress.PlayerWeapons; 
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.PlayerWeapons = new List<WeaponTypeId>(Weapons.Value);
    }

    public void Initialize()
    {
      Weapons.Changed += OnWeaponsChanged;
    }

    public void Dispose()
    {
      Weapons.Changed -= OnWeaponsChanged;
    }

    private void OnWeaponsChanged(List<WeaponTypeId> obj)
    {
      _weaponShop.SetAllWeapons();
      _weaponShop.RemoveWeapons(Weapons.Value);
    }
  }
}