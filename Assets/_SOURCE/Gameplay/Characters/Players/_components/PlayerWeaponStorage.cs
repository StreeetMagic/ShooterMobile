using System;
using System.Collections.Generic;
using Gameplay.Weapons;
using Gameplay.WeaponStorages;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;
using Loggers;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponStorage : IProgressWriter, IInitializable, IDisposable
  {
    private readonly WeaponShop _weaponShop;
    private readonly DebugLogger _debugLogger;

    public PlayerWeaponStorage(WeaponShop weaponShop, DebugLogger debugLogger)
    {
      _weaponShop = weaponShop;
      _debugLogger = debugLogger;
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
      _debugLogger.LogPlayerWeapons(this);
    }
  }
}