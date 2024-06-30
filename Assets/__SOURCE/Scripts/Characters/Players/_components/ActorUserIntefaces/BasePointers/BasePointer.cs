using BaseTriggers;
using CurrencyRepositories.BackpackStorages;
using UnityEngine;
using Zenject;

namespace Characters.Players._components.ActorUserIntefaces.BasePointers
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
      if (!_mapProvider.Map)
      {
        Hide();
        return;
      }

      if (!_mapProvider.Map.BaseTrigger)
      {
        Hide();
        return;
      }

      RotateToBase();

      HideIfClose();
    }

    private void RotateToBase()
    {
      transform.rotation = Quaternion.LookRotation(transform.position - BaseTrigger.transform.position);

      Quaternion cachedRotation = transform.rotation;

      transform.rotation = new Quaternion(0, cachedRotation.y, 0, cachedRotation.w);
    }

    private void HideIfClose()
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

    private void Hide()
    {
      Pointer.gameObject.SetActive(false);
    }
  }
}