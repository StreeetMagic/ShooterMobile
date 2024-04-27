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
    [Inject] private EnemyAnimatorProvider _animatorProvider;
    [Inject] private RewardService _rewardService;
    [Inject] private CorpseRemover _corpseRemover;
    [Inject] private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    [Inject] private EnemyMoverToPlayer _enemyMoverToPlayer;
    [Inject] private HitStatus _hitStatus;
    [Inject] private EnemyConfig _config;

    public event Action<EnemyConfig, EnemyHealth> Died;
    public event Action<int> Damaged;

    public ReactiveProperty<int> Current { get; } = new();

    public int Initial => _config.InitialHealth;
    public bool IsFull => Current.Value == Initial;
    public bool IsDead { get; private set; }

    private void Start()
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

    private void SetCurrentHealth(int health)
    {
      Current.Value = health;
    }
  }
}