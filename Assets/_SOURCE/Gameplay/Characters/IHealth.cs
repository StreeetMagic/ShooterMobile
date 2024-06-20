using System;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Configs;
using Infrastructure.Utilities;
using UnityEngine;

namespace Gameplay.Characters
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
    T GetComponent<T>();
    void Hit();
    void NotifyOtherEnemies();
    
    // ReSharper disable once InconsistentNaming
    Transform transform { get; }
  }
}