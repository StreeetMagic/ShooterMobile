using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Weapons;
using Infrastructure.Utilities;

namespace Gameplay.WeaponStorages
{
  public class WeaponShop
  {
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

        Weapons.Value.Remove(weapon);
      }
    }
  }
}