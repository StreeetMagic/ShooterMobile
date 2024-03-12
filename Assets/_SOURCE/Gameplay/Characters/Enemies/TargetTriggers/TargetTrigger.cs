using Gameplay.Characters.Healths;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class TargetTrigger : MonoBehaviour
  {
    public Health Health;

    private IStaticDataService _staticDataService;
    private DataRepository _dataRepository;

    [Inject]
    public void Construct(IStaticDataService staticDataService, DataRepository dataRepository)
    {
      _staticDataService = staticDataService;
      _dataRepository = dataRepository;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Projectile projectile) == false)
        return;

      Health.TakeDamage(_dataRepository.BulletDamage);

      Destroy(projectile.gameObject);
    }
  }
}