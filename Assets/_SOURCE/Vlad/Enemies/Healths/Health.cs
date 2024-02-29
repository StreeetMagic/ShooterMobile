using System;
using Gameplay.Characters.Enemies;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] private TargetTrigger _targetTrigger;

  private EnemyConfig _enemyConfig;
  private float _currentHealth;

  public event Action<float> HealthChanged;

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
      Debug.Log("Death");
    }
  }

  private void SetCurrentHealth(float health)
  {
    _currentHealth = health;
    HealthChanged?.Invoke(_currentHealth);
  }
}