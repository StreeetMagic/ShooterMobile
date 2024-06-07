using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyColliderDisabler : MonoBehaviour
  {
    [Inject] private IHealth _health;
    [Inject] private Enemy _enemy;

    private void OnEnable()
    {
      _health.Died += DisableColliders;
    }

    private void OnDisable()
    {
      _health.Died -= DisableColliders;
    }

    private void DisableColliders(EnemyConfig enemyConfig, IHealth enemyHealth)
    {
      Collider[] colliders = _enemy.GetComponentsInChildren<Collider>();

      foreach (Collider thisCollider in colliders)
        thisCollider.enabled = false;
    }
  }
}