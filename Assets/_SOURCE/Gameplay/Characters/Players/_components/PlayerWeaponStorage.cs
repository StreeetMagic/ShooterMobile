using System.Collections.Generic;
using Gameplay.Weapons;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponStorage : IProgressWriter
  {
    public List<WeaponTypeId> Weapons { get; set; }

    public void ReadProgress(ProjectProgress projectProgress)
    {
      Weapons = projectProgress.PlayerWeapons;

      string weapons = string.Empty;

      foreach (var weapon in Weapons)
      {
        weapons += weapon.ToString();
        weapons += ",";
      }

      Debug.Log(weapons);
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.PlayerWeapons = Weapons;
    }
  }
}