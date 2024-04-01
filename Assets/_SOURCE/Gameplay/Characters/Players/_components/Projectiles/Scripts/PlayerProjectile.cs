using System;
using Configs.Resources.UpgradeConfigs.Scripts;
using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters.Projectiles
{
  public class PlayerProjectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;

    private VisualEffectFactory _visualEffectFactory;
    private PlayerStatsProvider _playerStatsProvider;
    private int _count;

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
    }

    private void PlayerVisualEffect() =>
      _visualEffectFactory.Create(VIsualEffectId.BulletImpact, transform.position, transform);

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
      PlayerVisualEffect();
      transform.position = CollisionPointRayCaster.HitPosition;
      Destroy(gameObject);
    }
  }
}