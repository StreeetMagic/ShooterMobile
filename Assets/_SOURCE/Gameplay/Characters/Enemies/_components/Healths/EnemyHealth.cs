using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Healths
{
  public class EnemyHealth : MonoBehaviour
  {
    private Enemy _enemy;
    private EnemyAnimator _enemyAnimator;

    public event Action<EnemyConfig, EnemyHealth> Died;
    public event Action<int> Damaged;

    public ReactiveProperty<int> Current { get; } = new();

    public int Initial => Config.InitialHealth;
    public bool IsFull => Current.Value == Initial;
    public bool IsDead { get; private set; }

    private EnemyConfig Config => _enemy.Config;

    [Inject]
    private void Construct(EnemyAnimator animator, Enemy enemy)
    {
      _enemyAnimator = animator;
      _enemy = enemy;
    }

    private void Start()
    {
      SetCurrentHealth(Initial);
    }

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

      _enemyAnimator.PlayDeathAnimation();

      IsDead = true;

      Died?.Invoke(Config, this);

      // Destroy(_enemy.gameObject);
    }

    private void SetCurrentHealth(int health)
    {
      Current.Value = health;

      Damaged?.Invoke(health);
    }
  }
}