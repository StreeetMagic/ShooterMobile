using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  [RequireComponent(typeof(RectTransform))]
  public class BombDefuseRadius : MonoBehaviour
  {
    private RectTransform _rectTransform;
    
    [Inject] private ConfigService _configService;

    private void Awake()
    {
      _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
      float value = _configService.PlayerConfig.BombDefuseRadius * 2f;

      _rectTransform.localScale = new Vector3(value, value, value);
    }
  }
}
