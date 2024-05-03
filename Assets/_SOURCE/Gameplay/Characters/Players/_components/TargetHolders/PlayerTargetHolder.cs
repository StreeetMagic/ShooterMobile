using System.Collections.Generic;
using Configs.Resources.StatConfigs;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.PlayerStatsProviders;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Players.TargetHolders
{
  public class PlayerTargetHolder : MonoBehaviour
  {
    private List<EnemyTargetTrigger> _targets;
    private EnemyTargetTrigger _currentEnemyTarget;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private PlayerStatsProvider _playerStatsProvider;

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
      if (_playerProvider.Player == null)
        return;

      ManageCurrentTarget();
      RemoveFarTargets();
      RemoveDeadTargets();

      if (_currentEnemyTarget != null)
      {
        _currentEnemyTarget.IsTargeted = true;
      }
    }

    private void RemoveDeadTargets()
    {
      List<EnemyTargetTrigger> deadTargets = new List<EnemyTargetTrigger>();

      foreach (EnemyTargetTrigger target in _targets)
      {
        if (!target.EnemyHealth.IsDead)
          continue;

        deadTargets.Add(target);

        if (_currentEnemyTarget == target)
          target.IsTargeted = false;
      }

      _targets.RemoveAll(target => deadTargets.Contains(target));
    }

    private void RemoveFarTargets()
    {
      List<EnemyTargetTrigger> farTargets = new List<EnemyTargetTrigger>();

      foreach (EnemyTargetTrigger target in _targets)
      {
        if (!(Vector3.Distance(Transform.position, target.transform.position) > FireRange))
          continue;

        farTargets.Add(target);

        if (_currentEnemyTarget == target)
          target.IsTargeted = false;
      }

      _targets.RemoveAll(target => farTargets.Contains(target));
    }

    private void ManageCurrentTarget()
    {
      if (_targets.Count == 0)
      {
        if (_currentEnemyTarget != null)
        {
          _currentEnemyTarget.IsTargeted = false;
        }

        HasTarget = false;
        _currentEnemyTarget = null;
      }
      else if (_currentEnemyTarget == null)
      {
        SetRandomCurrentTarget();
        HasTarget = true;
      }
      else if (_currentEnemyTarget.EnemyHealth.IsDead)
      {
        SetRandomCurrentTarget();
        HasTarget = true;
      }
    }

    private void SetRandomCurrentTarget()
    {
      EnemyTargetTrigger currentEnemyTarget = _targets[Random.Range(0, _targets.Count)];
      currentEnemyTarget.IsTargeted = true;
      _currentEnemyTarget = currentEnemyTarget;
    }

    public void AddTargets(List<EnemyTargetTrigger> targets)
    {
      if (targets == null || targets.Count == 0)
        return;

      foreach (EnemyTargetTrigger target in targets)
      {
        if (!_targets.Contains(target))
          _targets.Add(target);
      }

      _targets.RemoveAll(existingTarget => !targets.Contains(existingTarget));
    }
  }
}