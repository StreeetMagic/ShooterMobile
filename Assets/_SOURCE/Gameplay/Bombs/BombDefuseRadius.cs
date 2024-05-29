using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  [RequireComponent(typeof(RectTransform))]
  public class BombDefuseRadius : MonoBehaviour
  {
    private RectTransform _rectTransform;
    
    [Inject] private IStaticDataService _staticDataService;

    private void Awake()
    {
      _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
      float value = _staticDataService.GetPlayerConfig().BombDefuseRadius * 2f;

      _rectTransform.localScale = new Vector3(value, value, value);
    }
  }
}
