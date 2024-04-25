using DataRepositories.BackpackStorages;
using Gameplay.BaseTriggers;
using Maps;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players._components.ActorUserIntefaces.BasePointers
{
  public class BasePointer : MonoBehaviour
  {
    public GameObject Pointer;

    private MapProvider _mapProvider;
    private BackpackStorage _backpackStorage;

    [Inject]
    public void Construct(MapProvider mapProvider, BackpackStorage backpackStorage)
    {
      _mapProvider = mapProvider;
      _backpackStorage = backpackStorage;
    }

    private BaseTrigger BaseTrigger => _mapProvider.Map.BaseTrigger;

    private void LateUpdate()
    {
      RotateToBase();

      Hide();
    }

    private void RotateToBase()
    {
      transform.rotation = Quaternion.LookRotation(transform.position - BaseTrigger.transform.position);

      Quaternion cachedRotation = transform.rotation;

      transform.rotation = new Quaternion(0, cachedRotation.y, 0, cachedRotation.w);
    }

    private void Hide()
    {
      if (_backpackStorage.IsFull == false)
      {
        Pointer.gameObject.SetActive(false);
        return;
      }

      const float MinDistance = 5;

      var distance = Vector3.Distance(transform.position, BaseTrigger.transform.position);

      Pointer.gameObject.SetActive(!(distance < MinDistance));
    }
  }
}