using Gameplay.Characters.Enemies.Configs;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces
{
  public class EnemyActorUserInterface : MonoBehaviour
  {
    [Inject] private IHealth _enemyHealth;

    private void OnEnable()
    {
      _enemyHealth.Died += OnDied;
    }

    private void OnDisable()
    {
      _enemyHealth.Died -= OnDied;
    }

    private void OnDied(EnemyConfig arg1, IHealth arg2)
    {
      gameObject.SetActive(false);
    }
  }
}