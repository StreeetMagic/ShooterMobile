using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerTargetTrigger : MonoBehaviour
  {
    public Collider Collider;

    public PlayerHealth PlayerHealth;
    private UpgradeService _upgradeService;

    public bool IsTargeted { get; set; }

    [Inject]
    private void Construct(UpgradeService upgradeService, PlayerHealth playerHealth)
    {
      PlayerHealth = playerHealth;
      _upgradeService = upgradeService;

      PlayerHealth.Died += OnDied;
    }

    private void OnDied(EnemyConfig arg1, EnemyHealth arg2)
    {
      Collider.enabled = false;
    }

    public void TakeDamage(int damage)
    {
      PlayerHealth.TakeDamage(damage);
    }

    private void FixedUpdate()
    {
      transform.localPosition = Vector3.zero;
    }
  }
}