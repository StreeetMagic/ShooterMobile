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
    private Enemy _enemy;
    private EnemyMoverToSpawnPoint _enemyMoverToSpawnPoint;
    private EnemyMoverToPlayer _enemyMoverToPlayer;
    private HitStatus _hitStatus;

    [Inject]
    private void Construct(EnemyAnimator animator, CorpseRemover corpseRemover, RewardService rewardService,
      Enemy enemy, EnemyMoverToSpawnPoint enemyMoverToSpawnPoint, EnemyMoverToPlayer enemyMoverToPlayer, HitStatus hitStatus)
    {
      _enemyAnimator = animator;
      _corpseRemover = corpseRemover;
      _rewardService = rewardService;
      _enemyMoverToSpawnPoint = enemyMoverToSpawnPoint;
      _enemyMoverToPlayer = enemyMoverToPlayer;
      _enemy = enemy;
      _hitStatus = hitStatus;
    }

    public event Action<EnemyConfig, EnemyHealth> Died;
    public event Action<int> Damaged;

    public ReactiveProperty<int> Current { get; } = new();

    public int Initial => Config.InitialHealth;
    public bool IsFull => Current.Value == Initial;
    public bool IsDead { get; private set; }

    private EnemyConfig Config => _enemy.Config;

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