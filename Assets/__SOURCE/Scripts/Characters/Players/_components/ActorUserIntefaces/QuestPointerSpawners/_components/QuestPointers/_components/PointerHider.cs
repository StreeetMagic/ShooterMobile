using System.Collections.Generic;
using Quests;
using UnityEngine;
using Zenject;

namespace Characters.Players._components.ActorUserIntefaces.QuestPointerSpawners._components.QuestPointers._components
{
  public class PointerHider : MonoBehaviour
  {
    public GameObject Pointer;

    [Inject] private MapProvider _mapProvider;
    [Inject] private QuestTargetsProvider _targetProvider;

    [SerializeField] [Inject] QuestConfig _config;

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
      const float MinDistance = 4;

      var distance = Vector3.Distance(transform.position, target.transform.position);

      if (distance < MinDistance)
        Hide();
      else
        Show();
    }

    private void Show()
    {
      Pointer.SetActive(true);
    }

    private void Hide()
    {
      Pointer.SetActive(false);
    }
  }
}