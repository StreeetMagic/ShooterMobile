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
    private MoneyInBankStorage _moneyInBankStorage;

    [Inject]
    public void Construct(IStaticDataService staticDataService, MoneyInBankStorage moneyInBankStorage)
    {
      _staticDataService = staticDataService;
      _moneyInBankStorage = moneyInBankStorage;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Projectile projectile) == false)
        return;

      Health.TakeDamage(_moneyInBankStorage.BulletDamage);

      Destroy(projectile.gameObject);
    }
  }
}