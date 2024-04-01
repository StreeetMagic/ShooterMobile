using System;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetLocators;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Players.TargetHolders
{
  public class PlayerTargetHolder : MonoBehaviour
  {
    private PlayerProvider _playerProvider;
    private List<EnemyTargetTrigger> _targets;

    private EnemyTargetTrigger _currentEnemyTarget;

    [Inject]
    public void Construct(PlayerProvider playerProvider)
    {
      _playerProvider = playerProvider;
    }

    public bool HasTarget { get; private set; }

    public Vector3 DirectionToTarget => _currentEnemyTarget.transform.position - Transform.position;
    public Vector3 LookDirectionToTarget => new Vector3(_currentEnemyTarget.transform.position.x, Transform.position.y, _currentEnemyTarget.transform.position.z) - Transform.position;

    private Transform Transform => _playerProvider.Player.transform;

    private void OnEnable()
    {
      _targets = new List<EnemyTargetTrigger>();
    }

    private void FixedUpdate()
    {
      if (_targets.Count == 0)
      {
        HasTarget = false;
        _currentEnemyTarget = null;
      }
      else if (_currentEnemyTarget == null)
      {
        _currentEnemyTarget = _targets[Random.Range(0, _targets.Count)];
        HasTarget = true;
      }
    }

    public void AddTargets(List<EnemyTargetTrigger> targets)
    {
      if (targets == null)
        return;

      if (targets.Count == 0)
        return;

      foreach (var target in targets)
      {
        if (_targets.Contains(target))
          continue;

        _targets.Add(target);
      }

      var targetsToRemove = new List<EnemyTargetTrigger>(_targets);

      foreach (var target in _targets)
      {
        if (!targets.Contains(target))
          targetsToRemove.Add(target);
      }

      foreach (var target in targetsToRemove)
      {
        _targets.Remove(target);
      }
    }
  }
}