using System;
using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Players;
using Gameplay.Projectiles.Movers;
using Infrastructure.ArtConfigServices;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Projectiles
{
  public class EnemyProjectile : MonoBehaviour
  {
    [SerializeField] private LayerMask _layerMask;

    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private ArtConfigProvider _configProvider;

    private int _count;
    private float _speed;
    private Vector3 _currentPosition;
    private Vector3 _futurePosition;

    public EnemyConfig EnemyConfig { get; set; }

    private void Start()
    {
      _speed = EnemyConfig.BulletSpeed;
      Destroy(gameObject, 2f);
    }

    private void Update()
    {
      _currentPosition = transform.position;
      Vector3 direction = transform.forward * (_speed * Time.deltaTime);
      _futurePosition = _currentPosition + direction;

      if (Physics.Linecast(_currentPosition, _futurePosition, out RaycastHit hit, _layerMask.value))
      {
        if (hit.collider.TryGetComponent(out PlayerTargetTrigger player))
        {
          if (_count == 0)
          {
            _count++;

            player.TakeDamage(EnemyConfig.BulletDamage);
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
      VisualEffectId id = _configProvider.GetEnemyImpactEffectId(EnemyConfig.Id);

      _visualEffectFactory.CreateAndDestroy(id, position, transform.rotation);
    }

    private void Destroy(Vector3 position, float time = default)
    {
      transform.position = position;

      ImpactEffect(position);
      Destroy(gameObject, time);
    }
  }
}