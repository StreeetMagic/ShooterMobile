using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Healths;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Gameplay.Upgrades;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class TargetTrigger : MonoBehaviour
  {
    public Health Health;

    private UpgradeService _upgradeService;

    [Inject]
    private void Construct(UpgradeService upgradeService)
    {
      _upgradeService = upgradeService;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Projectile projectile) == false)
        return;

      Health.TakeDamage(_upgradeService.GetCurrentUpgradeValue(UpgradeId.Damage));

      Destroy(projectile.gameObject);
    }
  }
}