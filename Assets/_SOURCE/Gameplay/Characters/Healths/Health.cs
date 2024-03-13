using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies;
using Gameplay.RewardServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Healths
{
  public class Health : MonoBehaviour
  {
    [SerializeField] private Enemy _enemy;

    private EnemyConfig _enemyConfig;
    private RewardService _rewardService;
    private EnemyAnimator _enemyAnimator;

    public event Action<float> HealthChanged;
    public event Action Dead;

    public float Current { get; private set; }
    public float Initial => _enemyConfig.InitialHealth;
    public bool IsDead { get; private set; }

    [Inject]
    public void Construct(RewardService rewardService)
    {
      _rewardService = rewardService;
    }

    public void Init(EnemyConfig enemyConfig, EnemyAnimator animator)
    {
      _enemyConfig = enemyConfig;
      SetCurrentHealth(Initial);

      _enemyAnimator = animator;
    }

    public void TakeDamage(float damage)
    {
      if (damage <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(damage));
      }

      SetCurrentHealth(Current - damage);

      if (Current <= 0)
      {
        Die();
      }
    }

    private void Die()
    {
      if (IsDead)
        return;

      Dead?.Invoke();
      _rewardService.OnEnemyDied(_enemy.Id);
      _enemyAnimator.PlayDeathAnimation();

      IsDead = true;

     // Destroy(_enemy.gameObject);
    }

    private void SetCurrentHealth(float health)
    {
      Current = health;
      HealthChanged?.Invoke(Current);
    }
  }
}