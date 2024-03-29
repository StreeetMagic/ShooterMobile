using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.StateMachines.States;
using Gameplay.CorpseRemovers;
using Gameplay.RewardServices;
using Infrastructure.StateMachines;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Healths
{
  public class EnemyHealth : IInitializable
  {
    private readonly EnemyComponentsProvider _enemy;
    private readonly EnemyAnimator _enemyAnimator;
    private readonly RewardService _rewardService;
    private readonly CorpseRemover _corpseRemover;

    private EnemyHealth(EnemyAnimator animator, EnemyComponentsProvider enemy,
      Transform transform, CorpseRemover corpseRemover, RewardService rewardService)
    {
      _enemyAnimator = animator;
      _enemy = enemy;
      Transform = transform;
      _corpseRemover = corpseRemover;
      _rewardService = rewardService;
      enemy.Health = this;
    }

    public event Action<EnemyConfig, EnemyHealth> Died;
    public event Action<int> Damaged;

    public ReactiveProperty<int> Current { get; } = new();
    public int Initial => Config.InitialHealth;
    public bool IsFull => Current.Value == Initial;
    public bool IsDead { get; private set; }
    private EnemyConfig Config => _enemy.Config;
    public Transform Transform { get; }

    public void Initialize()
    {
      SetCurrentHealth(Initial);

      _corpseRemover.Add(this);
      _rewardService.AddEnemy(this);
    }

    public void TakeDamage(int damage)
    {
      if (damage <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(damage));
      }

      SetCurrentHealth(Current.Value - damage);

      Damaged?.Invoke(Current.Value); 

      if (Current.Value <= 0)
      {
        Die();
      }
    }

    private void Die()
    {
      if (IsDead)
        return;

      _enemyAnimator.PlayDeathAnimation();

      IsDead = true;

      Died?.Invoke(Config, this);
    }

    private void SetCurrentHealth(int health)
    {
      Current.Value = health;
    }
  }
}