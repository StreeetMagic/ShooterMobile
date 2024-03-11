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

    private TargetTrigger _currentTarget;
    private List<TargetTrigger> _targets = new();

    public PlayerTargetHolder(PlayerProvider playerProvider)
    {
      _playerProvider = playerProvider;
    }

    public event Action<TargetTrigger> CurrentTargetUpdated;

    public bool HasTarget => _currentTarget != null;
    public Vector3 DirectionToTarget => _currentTarget.transform.position - Transform.position;

    private PlayerTargetLocator PlayerTargetLocator => _playerProvider.PlayerTargetLocator;
    private Transform Transform => _playerProvider.Player.transform;

    public void Start()
    {
      Subscribe();
    }

    public void Tick()
    {
      if (_currentTarget!=null &&_currentTarget.Health.Current <= 0)
      {
        RemoveTarget(_currentTarget);
        _currentTarget = null;
      }

      if (_currentTarget == null && _targets.Count > 0)
        UpdateCurrentTarget(ValidateRandomTarget());
    }

    private void AddTarget(TargetTrigger target)
    {
      if (_targets.Count == 0)
        UpdateCurrentTarget(target);

      _targets.Add(target);
    }

    private void UpdateCurrentTarget(TargetTrigger target)
    {
      _currentTarget = target;
      CurrentTargetUpdated?.Invoke(_currentTarget);
    }

    private void RemoveTarget(TargetTrigger target)
    {
      _targets.Remove(target);

      if (target == _currentTarget)
        UpdateCurrentTarget(ValidateRandomTarget());
    }

    private TargetTrigger ValidateRandomTarget() =>
      _targets.Count == 0
        ? null
        : RandomTarget();

    private TargetTrigger RandomTarget() =>
      _targets[Random.Range(0, _targets.Count)];

    private void OnPlayerTargetLocated(TargetTrigger target)
    {
      if (_targets.Contains(target))
        return;

      AddTarget(target);
    }

    private void OnPlayerTargetLost(TargetTrigger target)
    {
      if (_targets.Contains(target))
        RemoveTarget(target);
    }

    private void Subscribe()
    {
      PlayerTargetLocator.TargetLocated += OnPlayerTargetLocated;
      PlayerTargetLocator.TargetLost += OnPlayerTargetLost;
    }
  }
}