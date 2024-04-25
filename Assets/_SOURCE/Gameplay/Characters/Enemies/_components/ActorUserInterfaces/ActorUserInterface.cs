using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces
{
  public class ActorUserInterface : MonoBehaviour
  {
    private EnemyHealth _enemyHealth;

    [Inject]
    public void Construct(EnemyHealth enemyHealth)
    {
      _enemyHealth = enemyHealth;
    }

    private void OnEnable()
    {
      _enemyHealth.Died += OnDied;
    }

    private void OnDisable()
    {
      _enemyHealth.Died -= OnDied;
    }

    private void OnDied(EnemyConfig arg1, EnemyHealth arg2)
    {
      gameObject.SetActive(false);
    }
  }
}