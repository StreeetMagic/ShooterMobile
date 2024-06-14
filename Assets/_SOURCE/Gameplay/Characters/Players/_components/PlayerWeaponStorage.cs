using System;
using System.Collections.Generic;
using Gameplay.Weapons;
using Gameplay.WeaponStorages;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;
using UnityEngine;
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

      LogPlayerWeapons();
      LogShopWeapons();
    }

    private void LogPlayerWeapons()
    {
      string weapons = string.Empty;

      foreach (var weapon in Weapons.Value)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Debug.Log( "Player weapons: " + weapons);
    }

    private void LogShopWeapons()
    {
      string weapons = string.Empty;

      foreach (var weapon in _weaponShop.Weapons.Value)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Debug.Log( "Shop weapons: " + weapons);
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.PlayerWeapons = Weapons.Value;
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