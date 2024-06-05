using CurrencyRepositories.Expirience;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyExpirience : MonoBehaviour
  {
    [Inject] private ExpierienceStorage _expierienceStorage;
    [Inject] private IHealth _enemyHealth;

    private void OnEnable()
    {
      _enemyHealth.Died += OnDied;
    }

    private void OnDisable()
    {
      _enemyHealth.Died -= OnDied;
    }

    private void OnDied(EnemyConfig config, IHealth health)
    {
      _expierienceStorage.AllPoints.Value += config.Expirience;
    }
  }
}