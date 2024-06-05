using System;
using Gameplay.CorpseRemovers;
using Gameplay.RewardServices;
using UnityEngine;
using Utilities;
using Zenject;

namespace Gameplay.Characters.Enemies.Healths
{
  public class EnemyHealth : MonoBehaviour, IHealth
  {
    [Inject] private EnemyAnimatorProvider _animatorProvider;
    [Inject] private RewardService _rewardService;
    [Inject] private CorpseRemover _corpseRemover;
    [Inject] private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    [Inject] private EnemyMoverToPlayer _enemyMoverToPlayer;
    [Inject] private HitStatus _hitStatus;
    [Inject] private EnemyConfig _config;

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
      {
        throw new ArgumentOutOfRangeException(nameof(damage));
      }

      SetCurrentHealth(Current.Value - damage);
      Damaged?.Invoke(Current.Value);
      _hitStatus.IsHit = true;

      if (Current.Value <= 0)
      {
        Die();
      }
    }

    private void Die()
    {
      if (IsDead)
        return;

      _enemyMoverToSpawnPoint.enabled = false;
      _enemyMoverToPlayer.enabled = false;
      _animatorProvider.Instance.PlayDeathAnimation();

      IsDead = true;

      Died?.Invoke(_config, this);
    }

    private void SetCurrentHealth(float health)
    {
      Current.Value = health;
    }
  }
}