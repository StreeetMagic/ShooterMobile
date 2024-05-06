using Maps;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers
{
  public class ToTargetRotator : MonoBehaviour
  {
    [Inject] private MapProvider _mapProvider;
    [Inject] private QuestTargetProvider _targetProvider;
    
    private Transform Target => _targetProvider.QuestTarget;

    private void LateUpdate()
    {
      if (_mapProvider.Map == null)
        return;

      RotateTo(Target);
    }

    private void RotateTo(Transform target)
    {
      transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);

      Quaternion cachedRotation = transform.rotation;

      transform.rotation = new Quaternion(0, cachedRotation.y, 0, cachedRotation.w);
    }
  }
}