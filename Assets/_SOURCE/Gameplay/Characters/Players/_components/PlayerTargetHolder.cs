using System.Collections.Generic;
using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerTargetHolder : ITickable
  {
    private readonly Transform _transform;
    private readonly PlayerWeaponIdProvider _playerWeaponIdProvider;
    private readonly ConfigService _configService;

    private readonly List<ITargetTrigger> _targets = new();

    public PlayerTargetHolder(Transform transform,
      PlayerWeaponIdProvider playerWeaponIdProvider, ConfigService configService)
    {
      _transform = transform;
      _playerWeaponIdProvider = playerWeaponIdProvider;
      _configService = configService;
    }

    public bool HasTarget { get; private set; }
    public ITargetTrigger CurrentTarget { get; private set; }

    public Vector3 DirectionToTarget => CurrentTarget.transform.position - _transform.position;
    public Vector3 LookDirectionToTarget => new Vector3(CurrentTarget.transform.position.x, _transform.position.y, CurrentTarget.transform.position.z) - _transform.position;

    public void Tick()
    {
      ManageCurrentTarget();
      RemoveFarTargets();
      RemoveDeadTargets();

      if (CurrentTarget != null)
        CurrentTarget.IsTargeted = true;
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
        if (!(Vector3.Distance(_transform.position, target.transform.position) > _configService.GetWeaponConfig(_playerWeaponIdProvider.CurrentId.Value).FireRange))
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
        float distance = Vector3.Distance(_transform.position, target.transform.position);

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
  }
}