using System;
using _Infrastructure.SceneInstallers.GameLoop;
using _Infrastructure.Utilities;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerHealth : MonoBehaviour
  {
    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private IGameLoopInitializer _gameLoopInitializer;

    public event Action Died;
    public event Action<int> Damaged;

    public ReactiveProperty<int> Current { get; } = new();

    public bool IsDead { get; private set; }

    private void OnEnable()
    {
      Current.Value = _playerStatsProvider.GetStat(StatId.Health).Value;
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

      Died?.Invoke();

      IsDead = true;

      _gameLoopInitializer.Restart();
    }

    private void SetCurrentHealth(int health)
    {
      if (health < Current.Value)
      {
        Damaged?.Invoke(health);
      }

      Current.Value = health;
    }
  }
}