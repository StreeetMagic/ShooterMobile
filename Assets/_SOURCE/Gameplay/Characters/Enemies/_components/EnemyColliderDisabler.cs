using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyColliderDisabler : MonoBehaviour
  {
    private EnemyHealth _enemy;

    [Inject]
    private void Construct(EnemyHealth enemy)
    {
      _enemy = enemy;
    }

    private void OnEnable()
    {
      _enemy.Died += DisableColliders;
    }

    private void OnDisable()
    {
      _enemy.Died -= DisableColliders;
    }

    private void DisableColliders(EnemyConfig enemyConfig, EnemyHealth enemyHealth)
    {
      Collider[] colliders = _enemy.GetComponentsInChildren<Collider>();

      foreach (Collider thisCollider in colliders)
        thisCollider.enabled = false;
    }
  }
}