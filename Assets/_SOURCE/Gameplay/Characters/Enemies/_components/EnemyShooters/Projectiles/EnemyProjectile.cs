using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players._components.PlayerStatsProviders;
using Gameplay.Characters.Players._components.Projectiles._components.Raycasters;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.EnemyShooters.Projectiles
{
  public class EnemyProjectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;

    private VisualEffectFactory _visualEffectFactory;
    private int _count;

    [Inject]
    private void Construct(VisualEffectFactory visualEffectFactory, PlayerStatsProvider playerStatsProvider)
    {
      _visualEffectFactory = visualEffectFactory;
    }

    public string Guid { get; set; }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void PlayerVisualEffect() =>
      _visualEffectFactory.Create(VIsualEffectId.BulletImpact, transform.position, transform);

    private void DamageTargetTrigger(Collider other)
    {
      if (other.gameObject.TryGetComponent(out PlayerTargetTrigger player))
      {
        if (_count == 0)
        {
          _count++;
          player.TakeDamage(1);
        }
      }

      Destroy();
    }

    private void Destroy()
    {
      transform.position = CollisionPointRayCaster.HitPosition;
      PlayerVisualEffect();
      Destroy(gameObject);
    }
  }
}