using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Weapons
{
  [CreateAssetMenu(fileName = nameof(WeaponContentConfig), menuName = "ArtConfigs/WeaponContentConfig")]
  public class WeaponContentConfig : ScriptableObject
  {
    public List<WeaponContentSetup> Setups;
  }
}