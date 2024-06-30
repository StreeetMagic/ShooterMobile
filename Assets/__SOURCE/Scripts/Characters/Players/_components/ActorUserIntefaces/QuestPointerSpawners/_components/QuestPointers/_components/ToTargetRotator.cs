using System.Collections.Generic;
using Quests;
using UnityEngine;
using Zenject;

namespace Characters.Players._components.ActorUserIntefaces.QuestPointerSpawners._components.QuestPointers._components
{
  public class ToTargetRotator : MonoBehaviour
  {
    [Inject] private MapProvider _mapProvider;
    [Inject] private QuestTargetsProvider _targetProvider;
    [Inject] private QuestConfig _config;

    private void LateUpdate()
    {
      if (_mapProvider.Map == null)
        return;

      List<Transform> targets = _targetProvider.GetTargetsOrNull(_config.Id);

      if (targets == null)
        return;

      if (targets.Count == 0)
        return;

      RotateTo(targets);
    }

    private void RotateTo(List<Transform> target)
    {
      if (target == null)
        return;

      List<Transform> validTargets = target.FindAll(t => t != null);

      Transform closestTarget = GetClosestTarget(validTargets);

      transform.rotation = Quaternion.LookRotation(transform.position - closestTarget.transform.position);

      Quaternion cachedRotation = transform.rotation;

      transform.rotation = new Quaternion(0, cachedRotation.y, 0, cachedRotation.w);
    }

    private Transform GetClosestTarget(List<Transform> validTargets)
    {
      Transform closestTarget = null;

      float minDistance = float.MaxValue;

      foreach (Transform target in validTargets)
      {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDistance)
        {
          minDistance = distance;
        }

        closestTarget = target;
      }
      
      return closestTarget;
    }
  }
}