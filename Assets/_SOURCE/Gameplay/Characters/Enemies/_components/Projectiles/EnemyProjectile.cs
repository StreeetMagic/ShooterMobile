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
    [SerializeField] private ForwardMover _forwardMover;
    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private ArtConfigProvider _configProvider;

    private int _count;

    public EnemyConfig EnemyConfig { get; set; }

    private void Start()
    {
      _forwardMover.BulletSpeed = EnemyConfig.BulletSpeed;
      Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void ImpactEffect()
    {
      VisualEffectId id = _configProvider.GetEnemyImpactEffectId(EnemyConfig.Id);

      _visualEffectFactory.CreateAndDestroy(id, transform.position, transform.rotation);
    }

    private void DamageTargetTrigger(Collider other)
    {
      if (other.TryGetComponent(out PlayerTargetTrigger player))
      {
        if (_count == 0)
        {
          _count++;

          player.TakeDamage(EnemyConfig.BulletDamage);
        }
      }

      Destroy();
    }

    private void Destroy()
    {
      ImpactEffect();
      Destroy(gameObject);
    }
  }
}