using Gameplay.Characters.Players;
using Gameplay.WeaponStorages;
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

    public void LogPlayerWeapons(PlayerWeaponStorage playerWeaponStorage)
    {
      string weapons = string.Empty;

      foreach (var weapon in playerWeaponStorage.Weapons.Value)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Log("Player weapons: " + weapons);
    }
  }
}