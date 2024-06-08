using System;
using Gameplay.Stats;
using SceneInstallers.GameLoop;
using Utilities;

namespace Gameplay.Characters.Players
{
  public class PlayerHealth
  {
    private readonly IGameLoopInitializer _gameLoopInitializer;

    public PlayerHealth(PlayerStatsProvider playerStatsProvider, IGameLoopInitializer gameLoopInitializer)
    {
      _gameLoopInitializer = gameLoopInitializer;
      Current.Value = playerStatsProvider.GetStat(StatId.Health).Value;
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