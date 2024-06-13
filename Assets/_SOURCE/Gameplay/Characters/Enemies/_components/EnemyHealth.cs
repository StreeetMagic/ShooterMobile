using System;
using Gameplay.Characters.Enemies.StateMachines;
using Gameplay.Characters.Enemies.StateMachines.States;
using Gameplay.CorpseRemovers;
using Gameplay.RewardServices;
using Gameplay.Spawners;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyHealth : MonoBehaviour, IHealth
  {
    [Inject] private RewardService _rewardService;
    [Inject] private CorpseRemover _corpseRemover;
    [Inject] private HitStatus _hitStatus;
    [Inject] private EnemyConfig _config;
    [Inject] private EnemySpawner _spawner;
    [Inject] private EnemyStateMachine _enemyStateMachine;
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
      _rewardService.AddEnemy(this);
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
      _hitStatus.Enable();
    }

    private void Die()
    {
      if (IsDead)
        return;

      IsDead = true;
      
      _enemyStateMachine.Enter<EnemyChooseCondiditionState>();

      Died?.Invoke(_config, this);
    }

    private void SetCurrentHealth(float health)
    {
      Current.Value = health;
    }
  }
}