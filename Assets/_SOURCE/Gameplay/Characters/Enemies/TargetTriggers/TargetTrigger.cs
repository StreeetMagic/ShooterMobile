using Gameplay.Characters.Healths;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class TargetTrigger : MonoBehaviour
  {
    public Health Health;

    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Projectile projectile))
      {
        Health.TakeDamage(_staticDataService.ForPlayer().BulletDamage);

        Destroy(projectile.gameObject);
      }
    }
  }
}