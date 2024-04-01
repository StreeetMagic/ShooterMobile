using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.CorpseRemovers;
using Gameplay.RewardServices;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Healths
{
  public class EnemyHealth : MonoBehaviour
  {
    private EnemyAnimator _enemyAnimator;
    private RewardService _rewardService;
    private CorpseRemover _corpseRemover;
    private bool _isInitialized;
    private Enemy _enemy;

    [Inject]
    private void Construct(EnemyAnimator animator,
      CorpseRemover corpseRemover, RewardService rewardService, Enemy enemy)
    {
      _enemyAnimator = animator;
      _corpseRemover = corpseRemover;
      _rewardService = rewardService;

      _enemy = enemy;
    }

    public event Action<EnemyConfig, EnemyHealth> Died;
    public event Action<int> Damaged;

    public ReactiveProperty<int> Current { get; } = new();
    public int Initial => Config.InitialHealth;
    public bool IsFull => Current.Value == Initial;
    public bool IsDead { get; private set; }
    private EnemyConfig Config => _enemy.Config;

    public void Initialize()
    {
      _isInitialized = true;

      SetCurrentHealth(Initial);

      _corpseRemover.Add(this);
      _rewardService.AddEnemy(this);
    }

    public void TakeDamage(int damage)
    {
      if (_isInitialized == false)
      {
        Initialize();
      }

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

    public void Tick()
    {
      if (_isInitialized == false)
      {
        Initialize();
      }
    }
  }
}