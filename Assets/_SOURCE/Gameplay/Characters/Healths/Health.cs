using System;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Healths
{
  public class Health : MonoBehaviour
  {
    [SerializeField] private Enemy _enemy;
  
    private EnemyConfig _enemyConfig;

    public event Action<float> HealthChanged;
    public event Action Dead;

    public float Current { get; private set; }
    public float Initial => _enemyConfig.InitialHealth;

    public void Init(EnemyConfig enemyConfig)
    {
      _enemyConfig = enemyConfig;
      SetCurrentHealth(Initial);
    }

    public void TakeDamage(float damage)
    {
      if (damage <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(damage));
      }

      SetCurrentHealth(Current - damage);

      if (Current <= 0)
      {
        Dead?.Invoke(); 
        Destroy(_enemy.gameObject);
      }
    }

    private void SetCurrentHealth(float health)
    {
      Current = health;
      HealthChanged?.Invoke(Current);
    }
  }
}