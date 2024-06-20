using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Players;
using Gameplay.Projectiles.Raycasters;
using Infrastructure.ArtConfigServices;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Projectiles
{
  public class EnemyProjectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;

    private int _count;

    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private ArtConfigProvider _configProvider;

    public EnemyConfig EnemyConfig { get; set; }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void ImpactEffect()
    {
      VisualEffectId id = _configProvider.GetImpactEffectId(EnemyConfig.Id);

      _visualEffectFactory.Create(id, transform.position, transform);
    }

    private void DamageTargetTrigger(Collider other)
    {
      if (other.TryGetComponent(out PlayerTargetTrigger player))
      {
        if (_count == 0)
        {
          _count++;

          player
            // .GetComponentInChildren<PlayerTargetTrigger>()
            .TakeDamage(EnemyConfig.BulletDamage);
        }
      }

      Destroy();
    }

    private void Destroy()
    {
      //transform.position = CollisionPointRayCaster.HitPosition;
      ImpactEffect();
      Destroy(gameObject);
    }
  }
}