using System;
using Gameplay.Weapons;
using Infrastructure.VisualEffects;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponMuzzleFlashEffector
  {
    private readonly VisualEffectFactory _visualEffectFactory;

    public PlayerWeaponMuzzleFlashEffector(VisualEffectFactory visualEffectFactory)
    {
      _visualEffectFactory = visualEffectFactory;
    }

    public void Play(Transform parent, WeaponTypeId weaponTypeId)
    {
      VisualEffectId id;

      switch (weaponTypeId)
      {
        case WeaponTypeId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(weaponTypeId), weaponTypeId, null);

        case WeaponTypeId.DesertEagle:
          id = VisualEffectId.PistolMuzzleFlash;
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          id = VisualEffectId.RiffleMuzzleFlash;
          break;

        case WeaponTypeId.Xm1014:
          id = VisualEffectId.ShotgunMuzzleFlash;
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(weaponTypeId), weaponTypeId, null);
      }

      _visualEffectFactory.CreateAndDestroy(id, parent.position, parent.rotation);
    }
  }
}