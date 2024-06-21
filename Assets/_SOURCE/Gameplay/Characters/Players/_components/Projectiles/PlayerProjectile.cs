using System;
using Gameplay.Projectiles.Raycasters;
using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Projectiles
{
  public class PlayerProjectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;

    private int _count;

    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ConfigProvider _configProvider;

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void ImpactEffect()
    {
      VisualEffectId id;

      switch (_playerProvider.Instance.WeaponIdProvider.CurrentId.Value)
      {
        case WeaponTypeId.Unknown:
        case WeaponTypeId.Knife:
          throw new ArgumentOutOfRangeException(); 

        case WeaponTypeId.DesertEagle:
          id = VisualEffectId.PistolImpactExplosion;
          break;
        
        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          id = VisualEffectId.RiffleImpactExplosion;
          break;
        
        case WeaponTypeId.Xm1014:
          id = VisualEffectId.ShotgunImpactExplosion;
          break;

        default:
          throw new ArgumentOutOfRangeException(); 
      }

      _visualEffectFactory.CreateAndDestroy(id, transform.position, transform);
    }

    private void DamageTargetTrigger(Collider other)
    {
      if (other.gameObject.TryGetComponent(out ITargetTrigger enemyTargetTrigger))
      {
        if (_count == 0)
        {
          _count++;
          enemyTargetTrigger.TakeDamage(_configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Damage);
        }
      }

      Destroy();
    }

    private void Destroy()
    {
      // transform.position = CollisionPointRayCaster.HitPosition;

      ImpactEffect();
      Destroy(gameObject);
    }
  }
}