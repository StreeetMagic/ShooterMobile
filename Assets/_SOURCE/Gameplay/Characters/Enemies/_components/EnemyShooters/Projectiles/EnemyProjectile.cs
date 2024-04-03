using System.Collections;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using UnityEngine;
using Zenject;

public class EnemyProjectile : MonoBehaviour
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
    PlayerVisualEffect();
    transform.position = CollisionPointRayCaster.HitPosition;
    Destroy(gameObject);
  }
}