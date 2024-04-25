using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyTargetTrigger : MonoBehaviour
  {
    public Collider Collider;

    public EnemyHealth EnemyHealth;

    public event Action<EnemyTargetTrigger> TargetDied;

    public bool IsTargeted { get; set; }

    [Inject]
    private void Construct(UpgradeService upgradeService, EnemyHealth enemyHealth)
    {
      EnemyHealth = enemyHealth;

      EnemyHealth.Died += OnDied;
    }

    private void OnDied(EnemyConfig arg1, EnemyHealth arg2)
    {
      Collider.enabled = false;

      TargetDied?.Invoke(this);
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