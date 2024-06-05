using System;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Utilities;

namespace Gameplay.Dummies
{
  public class DummyHealth : MonoBehaviour, IHealth
  {
    public event Action<EnemyConfig, IHealth> Died;
    public event Action<float> Damaged;

    public ReactiveProperty<float> Current { get; }
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
  }
}