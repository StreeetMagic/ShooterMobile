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
    private float _lifeTime;

    private void Start()
    {
      _projectileMover = new ProjectileMover();
      _projectileMover.Initialize(MoveSpeed());
    }

    private void Update()
    {
      if (LifeTime() == false)
        return;

      if (Move(out RaycastHit hit))
        return;

      TryDamageTarget(hit);
      transform.position = hit.point;
      ImpactEffect();
      Debug.Log(hit.collider.gameObject.name);
      Destroy(gameObject);
    }

    private bool LifeTime()
    {
      if (_lifeTime >= _configProvider.CommonGameplayConfig.ProjectileLifeTime)
      {
        Destroy(gameObject);
        return false;
      }
      else
      {
        _lifeTime += Time.deltaTime;

        return true;
      }
    }

    private float MoveSpeed()
    {
      return _configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).BulletSpeed;
    }

    private void TryDamageTarget(RaycastHit hit)
    {
      if (!hit.collider.gameObject.TryGetComponent(out ITargetTrigger enemyTargetTrigger))
        return;

      if (_count != 0)
        return;

      _count++;
      enemyTargetTrigger.TakeDamage(_configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Damage);
    }

    private bool Move(out RaycastHit hit)
    {
      return _projectileMover.MoveProjectile(transform, Physics.DefaultRaycastLayers, out hit);
    }

    private void ImpactEffect()
    {
      VisualEffectId bulletImpactId = _playerProvider.Instance.WeaponIdProvider.CurrentId.Value switch
      {
        WeaponTypeId.Unknown or WeaponTypeId.Knife
          => throw new ArgumentOutOfRangeException(),

        WeaponTypeId.DesertEagle
          => VisualEffectId.PistolImpactExplosion,

        WeaponTypeId.Famas or WeaponTypeId.Ak47
          => VisualEffectId.RiffleImpactExplosion,

        WeaponTypeId.Xm1014
          => VisualEffectId.ShotgunImpactExplosion,

        _
          => throw new ArgumentOutOfRangeException()
      };

      _visualEffectFactory.CreateAndDestroy(bulletImpactId, transform.position, Quaternion.identity);
    }
  }
}