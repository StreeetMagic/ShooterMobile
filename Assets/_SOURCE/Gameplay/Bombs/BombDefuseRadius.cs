using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  [RequireComponent(typeof(RectTransform))]
  public class BombDefuseRadius : MonoBehaviour
  {
    private RectTransform _rectTransform;
    
    [Inject] private ConfigProvider _configProvider;

    private void Awake()
    {
      _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
      float value = _configProvider.PlayerConfig.BombDefuseRadius * 2f;

      _rectTransform.localScale = new Vector3(value, value, value);
    }
  }
}
