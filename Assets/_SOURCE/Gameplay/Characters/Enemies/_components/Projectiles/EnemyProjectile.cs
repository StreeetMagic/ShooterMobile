using Gameplay.Characters.Players;
using Gameplay.Projectiles._components.Raycasters;
using UnityEngine;
using VisualEffects;
using Zenject;

namespace Gameplay.Characters.Enemies.Projectiles
{
  public class EnemyProjectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;

    private int _count;

    [Inject] private VisualEffectFactory _visualEffectFactory;

    public EnemyConfig EnemyConfig { get; set; }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void PlayerVisualEffect() =>
      _visualEffectFactory.Create(ParticleEffectId.EnemyBulletImpact, transform.position, transform);

    private void DamageTargetTrigger(Collider other)
    {
      Debug.Log(other.gameObject.name);

      if (other.TryGetComponent(out Player player))
      {
        if (_count == 0)
        {
          _count++;

          player
            .GetComponentInChildren<PlayerTargetTrigger>()
            .TakeDamage(EnemyConfig.BulletDamage);
        }
      }

      Destroy();
    }

    private void Destroy()
    {
      //transform.position = CollisionPointRayCaster.HitPosition;
      PlayerVisualEffect();
      Destroy(gameObject);
    }
  }
}