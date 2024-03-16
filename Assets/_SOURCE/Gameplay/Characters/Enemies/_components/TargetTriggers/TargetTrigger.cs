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

    [Inject]
    private void Construct(UpgradeService upgradeService)
    {
      _upgradeService = upgradeService;
    }
    
    public bool IsTargeted { get; set; }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Projectile projectile) == false)
        return;

      if (Health.IsDead)
      {
        Collider.enabled = false;
        return;
      }

      Health.TakeDamage(_upgradeService.GetCurrentUpgradeValue(UpgradeId.Damage));

      Destroy(projectile.gameObject);
    }
  }
}