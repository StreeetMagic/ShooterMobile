using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
  [CreateAssetMenu(fileName = nameof(WeaponContentConfig), menuName = "ArtConfigs/WeaponContentConfig")]
  public class WeaponContentConfig : ScriptableObject
  {
    public List<WeaponContentSetup> Setups;
  }
}