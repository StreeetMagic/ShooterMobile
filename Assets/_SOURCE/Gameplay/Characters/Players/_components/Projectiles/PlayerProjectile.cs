using _Infrastructure.VisualEffects;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Projectiles._components.Raycasters;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Projectiles
{
  public class PlayerProjectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;

    private int _count;

    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private PlayerStatsProvider _playerStatsProvider;

    public string Guid { get; set; }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void PlayerVisualEffect()
    {
      _visualEffectFactory.Create(ParticleEffectId.PlayerBulletImpact, transform.position, transform);
    }

    private void DamageTargetTrigger(Collider other)
    {
      if (other.gameObject.TryGetComponent(out EnemyTargetTrigger enemyTargetTrigger))
      {
        if (_count == 0)
        {
          _count++;
          enemyTargetTrigger.TakeDamage(_playerStatsProvider.GetStat(StatId.Damage).Value);
        }
      }

      Destroy();
    }

    private void Destroy()
    {
     // transform.position = CollisionPointRayCaster.HitPosition;
     
      PlayerVisualEffect();
      Destroy(gameObject);
    }
  }
}