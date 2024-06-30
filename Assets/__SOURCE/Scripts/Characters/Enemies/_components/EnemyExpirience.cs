using System;
using Characters.Enemies.Configs;
using CurrencyRepositories.Expirience;
using Zenject;

namespace Characters.Enemies._components
{
  public class EnemyExpirience : IInitializable, IDisposable
  {
    private readonly ExpierienceStorage _expierienceStorage;
    private readonly IHealth _enemyHealth;
    
    public EnemyExpirience(ExpierienceStorage expierienceStorage, IHealth enemyHealth)
    {
      _expierienceStorage = expierienceStorage;
      _enemyHealth = enemyHealth;
    }

    public void Initialize()
    {
      _enemyHealth.Died += OnDied;
    }

    public void Dispose()
    {
      _enemyHealth.Died -= OnDied;
    }

    private void OnDied(EnemyConfig config, IHealth health)
    {
      _expierienceStorage.AllPoints.Value += config.Expirience;
    }
  }
}