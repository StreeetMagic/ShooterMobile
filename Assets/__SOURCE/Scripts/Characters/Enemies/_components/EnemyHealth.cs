using System;
using Characters.Enemies.Configs;
using CorpseRemovers;
using Infrastructure.Utilities;
using RewardServices;
using Spawners;
using UnityEngine;
using Zenject;

namespace Characters.Enemies._components
{
  public class EnemyHealth : MonoBehaviour, IHealth
  {
    [Inject] private RewardService _rewardService;
    [Inject] private CorpseRemover _corpseRemover;
    [Inject] private HitStatus _hitStatus;
    [Inject] private EnemyConfig _config;
    [Inject] private EnemySpawner _spawner;
    [Inject] private EnemyAssistCall _assistCall;

    public event Action<EnemyConfig, IHealth> Died;
    public event Action<float> Damaged;

    public ReactiveProperty<float> Current { get; } = new();

    public float Initial => _config.InitialHealth;
    public bool IsFull => Current.Value >= Initial;
    public bool IsDead { get; private set; }

    private void Start()
    {
      SetCurrentHealth(Initial);

      _corpseRemover.Add(this);
    }

    public void TakeDamage(float damage)
    {
      if (damage <= 0)
        throw new ArgumentOutOfRangeException(nameof(damage));

      SetCurrentHealth(Current.Value - damage);
      Damaged?.Invoke(Current.Value);

      NotifyOtherEnemies();

      if (Current.Value <= 0)
        Die();
    }

    public void NotifyOtherEnemies()
    {
      foreach (Enemy enemy in _spawner.Enemies)
        enemy.Health.Hit();

      _assistCall.Call();
    }

    public void Hit()
    {
      _hitStatus.IsHit = true;
    }

    private void Die()
    {
      if (IsDead)
        return;

      IsDead = true;
      _rewardService.OnLootDroped(_config.LootDrops);

      Died?.Invoke(_config, this);
    }

    private void SetCurrentHealth(float health)
    {
      Current.Value = health;
    }
  }
}