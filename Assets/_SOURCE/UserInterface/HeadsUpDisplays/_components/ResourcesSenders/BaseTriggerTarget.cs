using Cameras;
using Maps;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.ResourcesSenders
{
  public class BaseTriggerTarget : MonoBehaviour
  {
    public RectTransform RectTransform;

    [Inject] private CameraProvider _cameraProvider;
    [Inject] private MapProvider _mapProvider;

    private void Update()
    {
      if (!_cameraProvider.MainCamera)
        return;

      if (!_mapProvider.Map)
        return;
      
      if (!_mapProvider.Map.BaseTrigger)
        return;

      var screenPosition = _cameraProvider.MainCamera.WorldToScreenPoint(_mapProvider.Map.BaseTrigger.transform.position);

      RectTransform.position = screenPosition;
    }
  }
}