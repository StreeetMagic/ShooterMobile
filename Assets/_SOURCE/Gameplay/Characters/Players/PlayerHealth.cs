using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerHealth : MonoBehaviour
  {
    public event Action<EnemyConfig, EnemyHealth> Died;
    public event Action<int> Damaged;

    public ReactiveProperty<int> Current { get; } = new();

    public bool IsDead { get; private set; }

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

      IsDead = true;
    }

    private void SetCurrentHealth(int health)
    {
      Current.Value = health;

      Damaged?.Invoke(health);
    }
  }
}