using System.Collections.Generic;
using Configs.Resources.QuestConfigs.Scripts;
using Maps;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers
{
  public class PointerHider : MonoBehaviour
  {
    public GameObject Pointer;

    [Inject] private MapProvider _mapProvider;
    [Inject] private QuestTargetsProvider _targetProvider;
    [Inject] private QuestConfig _config;

    private void LateUpdate()
    {
      if (_mapProvider.Map == null)
        return;
      
      List<Transform> targets = _targetProvider.GetTargetsOrNull(_config.Id);

      if (targets == null)
      {
        Hide();
        return;
      }

      if (targets.Count == 0)
      {
        Hide();
        return;
      }

      MeasureDistance(targets[0]);
    }

    private void MeasureDistance(Transform target)
    {
      const float MinDistance = 5;

      var distance = Vector3.Distance(transform.position, target.transform.position);

      if (distance < MinDistance)
        Pointer.SetActive(false);
      else
        Hide();
    }

    private void Hide()
    {
      Pointer.SetActive(true);
    }
  }
}