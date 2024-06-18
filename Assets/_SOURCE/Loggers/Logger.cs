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

      foreach (WeaponTypeId weapon in weaponShop.Weapons.Value)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Log("Shop weapons: " + weapons);
    }

    public void LogPlayerWeapons(WeaponStorage weaponStorage)
    {
      string weapons = string.Empty;

      foreach (WeaponTypeId weapon in weaponStorage.Weapons.Value)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Log("Player weapons: " + weapons);
    }

    public void LogTransition(string message)
    {
      if (message.Contains("Player"))
        return;
      
      Log(message);
    }

    public void LogStateEnter(string message)
    {
      if (message.Contains("Player"))
        return;
      
      Log(message);
    }

    public void LogStateExit(string message)
    {
      if (message.Contains("Player"))
        return;
      
      Log(message);
    }
  }
}