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
    private float _speed;
    private Vector3 _currentPosition;
    private Vector3 _futurePosition;

    private void Awake()
    {
      Destroy(gameObject, 2f);
    }

    private void Update()
    {
      _speed = _configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).BulletSpeed;

      _currentPosition = transform.position;
      Vector3 direction = transform.forward * (_speed * Time.deltaTime);
      _futurePosition = _currentPosition + direction;

      if (Physics.Linecast(_currentPosition, _futurePosition, out RaycastHit hit))
      {
        transform.position = hit.point;

        if (hit.collider.gameObject.TryGetComponent(out ITargetTrigger enemyTargetTrigger))
        {
          if (_count == 0)
          {
            _count++;
            enemyTargetTrigger.TakeDamage(_configProvider.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Damage);
          }
        }

        Destroy(hit.point);
      }
      else
      {
        transform.position = _futurePosition;
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

    private void Destroy(Vector3 position, float time = default)
    {
      transform.position = position;

      ImpactEffect(position);
      Destroy(gameObject, time);
    }
  }
}