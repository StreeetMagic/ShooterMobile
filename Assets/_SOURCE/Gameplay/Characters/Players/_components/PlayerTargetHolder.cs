using System.Collections.Generic;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetHolders
{
  public class PlayerTargetHolder : MonoBehaviour
  {
    private List<ITargetTrigger> _targets;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private PlayerStatsProvider _playerStatsProvider;

    public bool HasTarget { get; private set; }
    public ITargetTrigger CurrentTarget { get; private set; }

    public Vector3 DirectionToTarget => CurrentTarget.transform.position - Transform.position;
    public Vector3 LookDirectionToTarget => new Vector3(CurrentTarget.transform.position.x, Transform.position.y, CurrentTarget.transform.position.z) - Transform.position;
    private float FireRange => _playerStatsProvider.GetStat(StatId.FireRange).Value;

    private Transform Transform => _playerProvider.Player.transform;

    private void OnEnable()
    {
      _targets = new List<ITargetTrigger>();
    }

    private void FixedUpdate()
    {
      if (_playerProvider.Player == null)
        return;

      ManageCurrentTarget();
      RemoveFarTargets();
      RemoveDeadTargets();

      if (CurrentTarget != null)
      {
        CurrentTarget.IsTargeted = true;
      }
    }

    private void RemoveDeadTargets()
    {
      List<ITargetTrigger> deadTargets = new List<ITargetTrigger>();

      foreach (ITargetTrigger target in _targets)
      {
        if (!target.Health.IsDead)
          continue;

        deadTargets.Add(target);

        if (CurrentTarget == target)
          target.IsTargeted = false;
      }

      _targets.RemoveAll(target => deadTargets.Contains(target));
    }

    private void RemoveFarTargets()
    {
      List<ITargetTrigger> farTargets = new List<ITargetTrigger>();

      foreach (ITargetTrigger target in _targets)
      {
        if (!(Vector3.Distance(Transform.position, target.transform.position) > FireRange))
          continue;

        farTargets.Add(target);

        if (CurrentTarget == target)
          target.IsTargeted = false;
      }

      _targets.RemoveAll(target => farTargets.Contains(target));
    }

    private void ManageCurrentTarget()
    {
      if (_targets.Count == 0)
      {
        if (CurrentTarget != null)
        {
          CurrentTarget.IsTargeted = false;
        }

        HasTarget = false;
        CurrentTarget = null;
      }
      else
      {
        SetNearestCurrentTarget();
        HasTarget = true;
      }
    }

    private void SetNearestCurrentTarget()
    {
      ITargetTrigger nearestTarget = null;
      float nearestDistance = float.MaxValue;

      foreach (ITargetTrigger target in _targets)
      {
        float distance = Vector3.Distance(Transform.position, target.transform.position);

        if (distance < nearestDistance)
        {
          nearestDistance = distance;
          nearestTarget = target;
        }
      }

      if (CurrentTarget != null && CurrentTarget != nearestTarget)
      {
        CurrentTarget.IsTargeted = false;
      }

      CurrentTarget = nearestTarget;

      if (CurrentTarget != null)
      {
        CurrentTarget.IsTargeted = true;
      }
    }

    public void AddTargets(List<ITargetTrigger> targets)
    {
      if (targets == null || targets.Count == 0)
        return;

      foreach (ITargetTrigger target in targets)
      {
        if (!_targets.Contains(target))
          _targets.Add(target);
      }

      _targets.RemoveAll(existingTarget => !targets.Contains(existingTarget));
    }
  }
}