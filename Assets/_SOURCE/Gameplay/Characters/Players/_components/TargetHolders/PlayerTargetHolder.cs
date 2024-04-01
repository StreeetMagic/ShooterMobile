using System;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetLocators;
using Infrastructure.StaticDataServices;
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
    private PlayerStatsProvider _playerStatsProvider;

    [Inject]
    public void Construct(PlayerProvider playerProvider, PlayerStatsProvider playerStatsProvider)
    {
      _playerProvider = playerProvider;
      _playerStatsProvider = playerStatsProvider;
    }

    public bool HasTarget { get; private set; }

    public Vector3 DirectionToTarget => _currentEnemyTarget.transform.position - Transform.position;
    public Vector3 LookDirectionToTarget => new Vector3(_currentEnemyTarget.transform.position.x, Transform.position.y, _currentEnemyTarget.transform.position.z) - Transform.position;
    private float FireRange => _playerStatsProvider.GetStat(StatId.FireRange).Value;

    private Transform Transform => _playerProvider.Player.transform;

    private void OnEnable()
    {
      _targets = new List<EnemyTargetTrigger>();
    }

    private void FixedUpdate()
    {
      ManageCurrentTarget();
      RemoveFarTargets();
      RemoveDeadTargets();
    }

    private void RemoveDeadTargets()
    {
      _targets.RemoveAll(target => target.EnemyHealth == null || target.EnemyHealth.IsDead);
    }

    private void RemoveFarTargets()
    {
      _targets.RemoveAll(target => Vector3.Distance(Transform.position, target.transform.position) > FireRange);
    }

    private void ManageCurrentTarget()
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
      else if (_currentEnemyTarget.EnemyHealth.IsDead)
      {
        _currentEnemyTarget = _targets[Random.Range(0, _targets.Count)];
        HasTarget = true;
      }
    }

    public void AddTargets(List<EnemyTargetTrigger> targets)
    {
      if (targets == null || targets.Count == 0)
        return;

      foreach (var target in targets)
      {
        if (!_targets.Contains(target))
          _targets.Add(target);
      }

      _targets.RemoveAll(existingTarget => !targets.Contains(existingTarget));
    }
  }
}