using System;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerHealth : MonoBehaviour
  {
    public event Action Died;
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

      Died?.Invoke();

      IsDead = true;
    }

    private void SetCurrentHealth(int health)
    {
      if (health < Current.Value)
      {
        Debug.Log("Игрока продамажили");
        Damaged?.Invoke(health);
      }

      Current.Value = health;
    }
  }
}