using System;
using UnityEngine;

namespace Weapons
{
  [Serializable]
  public class WeaponSetup
  {
    public WeaponTypeId WeaponTypeId;
    public GameObject GameObject;
    public Transform ShootingPoint;
  }
}