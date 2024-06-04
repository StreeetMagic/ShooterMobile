using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponId : MonoBehaviour
  {
    public WeaponTypeId WeaponTypeId { get; set; } = WeaponTypeId.Unknown;
  }
}