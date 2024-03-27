using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Gameplay.Upgrades;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyTargetTrigger : MonoBehaviour
  {
    public Collider Collider;

    public EnemyHealth EnemyHealth;
    private UpgradeService _upgradeService;

    public bool IsTargeted { get; set; }

    [Inject]
    private void Construct(UpgradeService upgradeService, EnemyHealth enemyHealth)
    {
      EnemyHealth = enemyHealth;
      _upgradeService = upgradeService;

      EnemyHealth.Died += OnDied;
    }

    private void OnDied(EnemyConfig arg1, EnemyHealth arg2)
    {
      Collider.enabled = false;
    }

    public void TakeDamage(int damage)
    {
      EnemyHealth.TakeDamage(damage);
    }

    private void FixedUpdate()
    {
      transform.localPosition = Vector3.zero;
    }
  }
}