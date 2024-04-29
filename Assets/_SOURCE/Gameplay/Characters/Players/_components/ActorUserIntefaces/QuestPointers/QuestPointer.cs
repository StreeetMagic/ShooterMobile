using Maps;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointers
{
  public class QuestPointer : MonoBehaviour
  {
    public GameObject Pointer;

    private Transform _questTarget;
    private MapProvider _mapProvider;

    [Inject]
    public void Construct(MapProvider mapProvider)
    {
      _mapProvider = mapProvider;
      _questTarget = transform;
    }

    public Transform QuestTarget => _questTarget;

    private void LateUpdate()
    {
      Transform target = DefineTarget();
      RotateToBase(target);
      Hide(target);
    }

    private Transform DefineTarget()
    {
      Transform target = _mapProvider.Map.Questers[0].transform;

      return target;
    }

    private void RotateToBase(Transform target)
    {
      transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);

      Quaternion cachedRotation = transform.rotation;

      transform.rotation = new Quaternion(0, cachedRotation.y, 0, cachedRotation.w);
    }

    private void Hide(Transform target)
    {
      const float MinDistance = 5;

      var distance = Vector3.Distance(transform.position, target.transform.position);

      Pointer.gameObject.SetActive(!(distance < MinDistance));
    }
  }
}