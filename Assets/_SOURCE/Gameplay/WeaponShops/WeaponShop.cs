using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Weapons;
using Infrastructure.Utilities;
using Loggers;
using Zenject;

namespace Gameplay.WeaponShops
{
  public class WeaponShop : IInitializable, IDisposable
  {
    private readonly DebugLogger _debugLogger;

    public WeaponShop(DebugLogger debugLogger)
    {
      _debugLogger = debugLogger;
    }

    public ReactiveList<WeaponTypeId> Weapons { get; } = new();

    public void SetAllWeapons()
    {
      Weapons.Value = Enum
        .GetValues(typeof(WeaponTypeId))
        .Cast<WeaponTypeId>()
        .Where(x => x != WeaponTypeId.Unknown)
        .ToList();
    }

    public void RemoveWeapons(IEnumerable<WeaponTypeId> weapons)
    {
      foreach (WeaponTypeId weapon in weapons)
      {
        if (!Weapons.Value.Contains(weapon))
          continue;

        Weapons.Remove(weapon);
      }
    }

    public void Initialize()
    {
      Weapons.Changed += OnWeaponsChanged;
    }

    public void Dispose()
    {
      Weapons.Changed -= OnWeaponsChanged;
    }

    private void OnWeaponsChanged(List<WeaponTypeId> weapons)
    {
       
    }
  }
}