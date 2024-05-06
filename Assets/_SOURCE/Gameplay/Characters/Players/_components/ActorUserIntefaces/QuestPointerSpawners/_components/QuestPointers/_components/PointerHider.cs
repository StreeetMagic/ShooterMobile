using Maps;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers
{
  public class PointerHider : MonoBehaviour
  {
    public GameObject Pointer;

    [Inject] private MapProvider _mapProvider;
    [Inject] private QuestTargetProvider _targetProvider;

    public Transform Target => _targetProvider.QuestTarget;

    private void LateUpdate()
    {
      if (_mapProvider.Map == null)
        return;

      Hide(Target);
    }

    private void Hide(Transform target)
    {
      const float MinDistance = 5;

      var distance = Vector3.Distance(transform.position, target.transform.position);

      Pointer.gameObject.SetActive(!(distance < MinDistance));
    }
  }
}