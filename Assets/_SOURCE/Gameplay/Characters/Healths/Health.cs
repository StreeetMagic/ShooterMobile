using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies;
using Gameplay.RewardServices;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Healths
{
  public class Health : MonoBehaviour
  {
    private EnemyConfig _enemyConfig;
    private EnemyAnimator _enemyAnimator;

    public event Action Died;

    public ReactiveProperty<int> Current { get; } = new();

    public int Initial => _enemyConfig.InitialHealth;
    public bool IsDead { get; private set; }

    public void Init(EnemyConfig enemyConfig, EnemyAnimator animator)
    {
      _enemyConfig = enemyConfig;
      SetCurrentHealth(Initial);

      _enemyAnimator = animator;
    }

    public void TakeDamage(int damage)
    {
      if (damage <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(damage));
      }

      SetCurrentHealth(Current.Value - damage);

      if (Current.Value <= 0)
      {
        Die();
      }
    }

    private void Die()
    {
      if (IsDead)
        return;

      Died?.Invoke();
      _enemyAnimator.PlayDeathAnimation();

      IsDead = true;

      // Destroy(_enemy.gameObject);
    }

    private void SetCurrentHealth(int health)
    {
      Current.Value = health;
    }
  }
}