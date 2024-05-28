using Cameras;
using Maps;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays
{
  public class BaseTriggerTarget : MonoBehaviour
  {
    public RectTransform RectTransform;

    [Inject] private CameraProvider _cameraProvider;
    [Inject] private MapProvider _mapProvider;

    private void Update()
    {
      if (_cameraProvider.MainCamera == null)
        return;

      if (_mapProvider.Map == null)
        return;

      var screenPosition = _cameraProvider.MainCamera.WorldToScreenPoint(_mapProvider.Map.BaseTrigger.transform.position);

      RectTransform.position = screenPosition;
    }
  }
}