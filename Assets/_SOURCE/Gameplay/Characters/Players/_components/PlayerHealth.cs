using System;
using Gameplay.Stats;
using SceneInstallers.GameLoop;
using UnityEngine;
using Utilities;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerHealth : MonoBehaviour
  {
    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private IGameLoopInitializer _gameLoopInitializer;

    public event Action Died;
    public event Action<float> Damaged;

    public ReactiveProperty<float> Current { get; } = new();

    public bool IsDead { get; private set; }

    private void OnEnable()
    {
      Current.Value = _playerStatsProvider.GetStat(StatId.Health).Value;
    }

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