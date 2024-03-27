using System;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetLocators;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Players.TargetHolders
{
  public class PlayerTargetHolder : ITickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly TickableManager _tickableManager;
    private readonly List<EnemyTargetTrigger> _targets = new();

    private EnemyTargetTrigger _currentEnemyTarget;

    public PlayerTargetHolder(PlayerProvider playerProvider, TickableManager tickableManager)
    {
      _playerProvider = playerProvider;
      _tickableManager = tickableManager;
    }

    public event Action<EnemyTargetTrigger> CurrentTargetUpdated;

    public bool HasTarget => _currentEnemyTarget != null;
    public Vector3 DirectionToTarget => _currentEnemyTarget.transform.position - Transform.position;
    public Vector3 LookDirectionToTarget => new Vector3(_currentEnemyTarget.transform.position.x, Transform.position.y, _currentEnemyTarget.transform.position.z) - Transform.position;

    private PlayerTargetLocator PlayerTargetLocator => _playerProvider.PlayerTargetLocator;
    private Transform Transform => _playerProvider.Player.transform;

    public void Start()
    {
      _tickableManager.Add(this);
      Subscribe();
    }

    public void Tick()
    {
      if (_currentEnemyTarget != null && _currentEnemyTarget.EnemyHealth.Current.Value <= 0)
      {
        RemoveTarget(_currentEnemyTarget);
        _currentEnemyTarget = null;
      }

      if (_currentEnemyTarget == null && _targets.Count > 0)
        UpdateCurrentTarget(ValidateRandomTarget());
    }

    private void AddTarget(EnemyTargetTrigger enemyTarget)
    {
      if (_targets.Count == 0)
        UpdateCurrentTarget(enemyTarget);

      _targets.Add(enemyTarget);
    }

    private void UpdateCurrentTarget(EnemyTargetTrigger enemyTarget)
    {
      _currentEnemyTarget = enemyTarget;
      CurrentTargetUpdated?.Invoke(_currentEnemyTarget);
    }

    private void RemoveTarget(EnemyTargetTrigger enemyTarget)
    {
      _targets.Remove(enemyTarget);

      if (enemyTarget == _currentEnemyTarget)
        UpdateCurrentTarget(ValidateRandomTarget());
    }

    private EnemyTargetTrigger ValidateRandomTarget() =>
      _targets.Count == 0
        ? null
        : RandomTarget();

    private EnemyTargetTrigger RandomTarget() =>
      _targets[Random.Range(0, _targets.Count)];

    private void OnPlayerTargetLocated(EnemyTargetTrigger enemyTarget)
    {
      if (_targets.Contains(enemyTarget))
        return;

      if (enemyTarget.EnemyHealth.IsDead)
        return;

      AddTarget(enemyTarget);
    }

    private void OnPlayerTargetLost(EnemyTargetTrigger enemyTarget)
    {
      if (_targets.Contains(enemyTarget))
        RemoveTarget(enemyTarget);
    }

    private void Subscribe()
    {
      PlayerTargetLocator.TargetLocated += OnPlayerTargetLocated;
      PlayerTargetLocator.TargetLost += OnPlayerTargetLost;
    }
  }
}