using System;
using Infrastructure.SceneInstallers.GameLoop;
using Infrastructure.Utilities;
using Stats;

namespace Characters.Players._components
{
  public class PlayerHealth
  {
    private readonly GameLoopInitializer _gameLoopInitializer;

    public PlayerHealth(PlayerStatsProvider playerStatsProvider, GameLoopInitializer gameLoopInitializer)
    {
      _gameLoopInitializer = gameLoopInitializer;
      Current.Value = playerStatsProvider.GetStat(StatId.Health);
    }

    public event Action Died;
    public event Action<float> Damaged;

    public ReactiveProperty<float> Current { get; } = new();
    public bool IsDead { get; private set; }

    public void TakeDamage(float damage)
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

      Died?.Invoke();

      IsDead = true;

      _gameLoopInitializer.Restart();
    }

    private void SetCurrentHealth(float health)
    {
      if (health < Current.Value)
      {
        Damaged?.Invoke(health);
      }

      Current.Value = health;
    }
  }
}