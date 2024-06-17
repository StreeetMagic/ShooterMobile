using Gameplay.Characters.Players;
using Gameplay.Weapons;
using UnityEngine;

namespace Loggers
{
  public class DebugLogger
  {
    public void Log(string message)
    {
      Debug.Log(message);
    }

    public void LogShopWeapons(WeaponShop weaponShop)
    {
      string weapons = string.Empty;

      foreach (var weapon in weaponShop.Weapons.Value)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Log("Shop weapons: " + weapons);
    }

    public void LogPlayerWeapons(WeaponStorage weaponStorage)
    {
      string weapons = string.Empty;

      foreach (var weapon in weaponStorage.Weapons.Value)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Log("Player weapons: " + weapons);
    }
  }
}