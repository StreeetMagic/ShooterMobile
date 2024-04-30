using Infrastructure.Upgrades;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerTargetTrigger : MonoBehaviour
  {
    public Collider Collider;

    public PlayerHealth PlayerHealth;

    public bool IsTargeted { get; set; }

    [Inject]
    private void Construct(UpgradeService upgradeService, PlayerHealth playerHealth)
    {
      PlayerHealth = playerHealth;

      PlayerHealth.Died += OnDied;
    }

    private void OnDied()
    {
      Collider.enabled = false;
    }

    public void TakeDamage(int damage)
    {
      Debug.Log("Пришел урон");
      PlayerHealth.TakeDamage(damage);
    }

    private void FixedUpdate()
    {
      transform.localPosition = Vector3.zero;
    }
  }
}