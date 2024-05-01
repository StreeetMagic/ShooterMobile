using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Characters.Players.Projectiles.Raycasters;
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

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void PlayerVisualEffect() =>
      _visualEffectFactory.Create(ParticleEffectId.BulletImpact, transform.position, transform);

    private void DamageTargetTrigger(Collider other)
    {
      if (other.TryGetComponent(out Player player))
      {
        if (_count == 0)
        {
          _count++;
          player.GetComponentInChildren<PlayerTargetTrigger>().TakeDamage(15);
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