using System;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.Factories;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Players.TargetHolders
{
  public class TargetHolder : ITickable
  {
    private PlayerFactory _factory;
    private TargetLocator.TargetLocator _targetLocator;

    private List<TargetTrigger> _targets = new();
    private TargetTrigger _currentTarget;
    private Transform _transform;

    public event Action<TargetTrigger> CurrentTargetUpdated;

    public Vector3 DirectionToTarget => _currentTarget.transform.position - _transform.position;

    public TargetHolder(PlayerFactory factory)
    {
      _factory = factory;
      _factory.Created += OnPlayerCreated;
    }

    public bool HasTarget => _currentTarget != null;

    private void OnPlayerCreated(Player player)
    {
      _factory.Created -= OnPlayerCreated;
      _targetLocator = player.GetComponentInChildren<TargetLocator.TargetLocator>();
      _transform = player.transform;

      Subscribe();
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

    private void OnTargetLocated(TargetTrigger target)
    {
      if (_targets.Contains(target))
        return;

      AddTarget(target);
    }

    private void OnTargetLost(TargetTrigger obj)
    {
      if (_targets.Contains(obj))
        RemoveTarget(obj);
    }

    private void Subscribe()
    {
      _targetLocator.TargetLocated += OnTargetLocated;
      _targetLocator.TargetLost += OnTargetLost;
    }

    public void Tick()
    {
      if (_currentTarget == null && _targets.Count > 0)
        UpdateCurrentTarget(ValidateRandomTarget());
    }
  }
}