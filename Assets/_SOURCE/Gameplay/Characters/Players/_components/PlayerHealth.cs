using System;
using Configs.Resources.StatConfigs;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Infrastructure.Games;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerHealth : MonoBehaviour
  {
    [Inject] private readonly IStateMachine<IGameState> _gameStateMachine;
    [Inject] private PlayerStatsProvider _playerStatsProvider;

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

      _gameStateMachine.Enter<LoadLevelState, string, string>(ProjectConstants.Scenes.Empty, ProjectConstants.Scenes.GameLoop);
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