using Gameplay.Characters.Healths;
using Gameplay.Characters.Players.Shooters.Projectiles;
using UnityEngine;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class TargetTrigger : MonoBehaviour
  {
    public Health Health;

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out Projectile projectile))
      {
        Health.TakeDamage(projectile.Damage);

        Destroy(projectile.gameObject);
      }
    }
  }
}