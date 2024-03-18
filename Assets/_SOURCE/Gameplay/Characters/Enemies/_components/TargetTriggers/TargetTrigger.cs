using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Gameplay.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class TargetTrigger : MonoBehaviour
  {
    public Health Health;
    public Collider Collider;

    private UpgradeService _upgradeService;

    public bool IsTargeted { get; set; }

    [Inject]
    private void Construct(UpgradeService upgradeService)
    {
      _upgradeService = upgradeService;

      Health.Died += OnDied;
    }

    private void OnDied(EnemyConfig arg1, Health arg2)
    {
      Collider.enabled = false;
    }

    public void TakeDamage(int damage)
    {
      Health.TakeDamage(damage);
    }

    private void FixedUpdate()
    {
       transform.localPosition = Vector3.zero;
    }
  }
}