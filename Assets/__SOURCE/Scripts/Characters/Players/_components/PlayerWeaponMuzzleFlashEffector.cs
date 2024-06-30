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
          id = VisualEffectId.MuzzleStandardYellow;
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          id = VisualEffectId.MuzzleSmallYellow;
          break;

        case WeaponTypeId.Xm1014:
          id = VisualEffectId.MuzzleSmallYellow;
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(weaponTypeId), weaponTypeId, null);
      }

      _visualEffectFactory.CreateAndDestroy(id, parent.position, parent.rotation);
    }
  }
}