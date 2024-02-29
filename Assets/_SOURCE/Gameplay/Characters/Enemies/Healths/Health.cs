using System;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Healths
{
  public class Health : MonoBehaviour
  {
    [SerializeField] private Enemy _enemy;
  
    private EnemyConfig _enemyConfig;
    private float _currentHealth;

    public event Action<float> HealthChanged;
    public event Action Dead;

    private float InitialHealth => _enemyConfig.InitialHealth;

    public void Init(EnemyConfig enemyConfig)
    {
      _enemyConfig = enemyConfig;
      SetCurrentHealth(InitialHealth);
    }

    public void TakeDamage(float damage)
    {
      if (damage <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(damage));
      }

      SetCurrentHealth(_currentHealth - damage);

      if (_currentHealth <= 0)
      {
        Dead?.Invoke(); 
        Destroy(_enemy.gameObject);
      }
    }

    private void SetCurrentHealth(float health)
    {
      _currentHealth = health;
      HealthChanged?.Invoke(_currentHealth);
    }
  }
}