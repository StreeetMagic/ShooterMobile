using UnityEngine;
using Zenject;

namespace Characters.Players._components
{
  public class PlayerTargetTrigger : MonoBehaviour
  {
    public Collider Collider;

    [Inject] private PlayerHealth _playerHealth;

    public bool IsTargeted { get; set; }

    private void OnEnable()
    {
      _playerHealth.Died += OnDied;
    }

    private void OnDisable()
    {
      _playerHealth.Died -= OnDied;
    }

    private void FixedUpdate()
    {
      transform.localPosition = Vector3.zero;
    }

    private void OnDied()
    {
      Collider.enabled = false;
    }

    public void TakeDamage(float damage)
    {
      _playerHealth.TakeDamage(damage);
    }
  }
}