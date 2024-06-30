using System;
using UnityEngine;

namespace Weapons
{
  [Serializable]
  public class WeaponContentSetup
  {
    public WeaponTypeId Id;
    public string Name;
    public string Description;
    public Sprite Icon;
  }
}