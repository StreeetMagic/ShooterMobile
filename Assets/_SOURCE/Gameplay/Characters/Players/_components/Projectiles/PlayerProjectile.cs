using System;
using Gameplay.Projectiles.Movers;
using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Projectiles
{
  public class PlayerProjectile : MonoBehaviour
  {
    [SerializeField] private ForwardMover _forwardMover;
    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ConfigProvider _configProvider;

    private int _count;

    private void Awake()
    {
      _forwardMover.BulletSpeed = _configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).BulletSpeed;

      Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void ImpactEffect()
    {
      VisualEffectId bulletImpactId;

      switch (_playerProvider.Instance.WeaponIdProvider.CurrentId.Value)
      {
        case WeaponTypeId.Unknown:
        case WeaponTypeId.Knife:
          throw new ArgumentOutOfRangeException();

        case WeaponTypeId.DesertEagle:
          bulletImpactId = VisualEffectId.PistolImpactExplosion;
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          bulletImpactId = VisualEffectId.RiffleImpactExplosion;
          break;

        case WeaponTypeId.Xm1014:
          bulletImpactId = VisualEffectId.ShotgunImpactExplosion;
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }

      _visualEffectFactory.CreateAndDestroy(bulletImpactId, transform.position, Quaternion.identity);
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