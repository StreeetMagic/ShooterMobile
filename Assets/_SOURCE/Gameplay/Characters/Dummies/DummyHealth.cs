using System;
using Gameplay.Characters.Enemies;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters.Dummies
{
  public class DummyHealth : MonoBehaviour, IHealth
  {
    public event Action<EnemyConfig, IHealth> Died;
    public event Action<float> Damaged;

    public ReactiveProperty<float> Current { get; } = new(float.MaxValue);
    public float Initial => float.MaxValue;
    public bool IsFull => true;
    public bool IsDead => false;

    public void TakeDamage(float damage)
    {
    }

    public void Hit()
    {
    }

    public void NotifyOtherEnemies()
    {
    }

    // ReSharper disable once UnusedMember.Local
    private void OnDied(EnemyConfig config, IHealth health)
    {
      Died?.Invoke(config, health);
    }

    // ReSharper disable once UnusedMember.Local
    private void OnDamaged(float damage)
    {
      Damaged?.Invoke(damage);
    }
  }
}