using System;
using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters.Projectiles
{
  public class Projectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;
    
    private VisualEffectFactory _visualEffectFactory;
    private PlayerStatsProvider _playerStatsProvider;

    [Inject]
    private void Construct(VisualEffectFactory visualEffectFactory, PlayerStatsProvider playerStatsProvider)
    {
      _visualEffectFactory = visualEffectFactory;
      _playerStatsProvider = playerStatsProvider;
    }

    public string Guid { get; set; }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
      PlayerVisualEffect();
      transform.position = CollisionPointRayCaster._hitPosition;
      Destroy(gameObject);
    }

    private void PlayerVisualEffect() =>
      _visualEffectFactory.Create(VIsualEffectId.BulletImpact, transform.position, transform);

    private void DamageTargetTrigger(Collider other)
    {
      if (other.gameObject.TryGetComponent(out TargetTrigger targetTrigger))
        targetTrigger.TakeDamage(_playerStatsProvider.Damage);
    }
  }
}