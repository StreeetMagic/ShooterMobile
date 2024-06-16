using System;
using System.Collections.Generic;
using Gameplay.Weapons;
using Gameplay.WeaponShops;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponStorage : IProgressWriter, IInitializable, IDisposable
  {
    private readonly WeaponShop _weaponShop;

    public PlayerWeaponStorage(WeaponShop weaponShop)
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