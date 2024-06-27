using System;
using Gameplay.Projectiles;
using Gameplay.Weapons;
using Infrastructure.ConfigProviders;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Projectiles
{
  public class PlayerProjectile : MonoBehaviour
  {
    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ConfigProvider _configProvider;

    private ProjectileMover _projectileMover;
    private int _count;

    private void Awake()
    {
      _projectileMover = new ProjectileMover();
      Destroy(gameObject, _configProvider.CommonGameplayConfig.ProjectileLifeTime);
    }

    private void Start()
    {
      float speed = _configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).BulletSpeed;
      _projectileMover.Initialize(speed);
    }

    private void Update()
    {
      if (_projectileMover.MoveProjectile(transform, Physics.DefaultRaycastLayers, out RaycastHit hit))
      {
        if (hit.collider.gameObject.TryGetComponent(out ITargetTrigger enemyTargetTrigger))
        {
          if (_count == 0)
          {
            _count++;
            enemyTargetTrigger.TakeDamage(_configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Damage);
          }
        }

        DestroyProjectile(hit.point);
      }
    }

    private void ImpactEffect(Vector3 position)
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

      _visualEffectFactory.CreateAndDestroy(bulletImpactId, position, Quaternion.identity);
    }

    private void DestroyProjectile(Vector3 position, float time = default)
    {
      transform.position = position;
      ImpactEffect(position);
      Destroy(gameObject, time);
    }
  }
}