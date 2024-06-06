using System;
using UnityEngine;
using Utilities;

namespace Gameplay.Characters.Enemies.Healths
{
  public interface IHealth
  {
    event Action<EnemyConfig, IHealth> Died;
    event Action<float> Damaged;
    ReactiveProperty<float> Current { get; }
    float Initial { get; }
    bool IsFull { get; }
    bool IsDead { get; }
    void TakeDamage(float damage);
    // ReSharper disable once InconsistentNaming
    Transform transform { get; }
    T GetComponent<T>();
    void Hit();
    void NotifyOtherEnemies();
  }
}