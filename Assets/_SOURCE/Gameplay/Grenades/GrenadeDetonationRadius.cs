using DG.Tweening;
using UnityEngine;

namespace Gameplay.Grenades
{
  public class GrenadeDetonationRadius : MonoBehaviour
  {
    [SerializeField] private RectTransform _detonationRadius;
    
    public void Init(GrenadeConfig config)
    {
      float radius = config.DetonationRadius;
      float localRaius = radius * 2;

      transform.localScale = new Vector3(localRaius, localRaius, localRaius);
      
      StartDetonationDuration(localRaius, config.DetonationTime);
    }

    private void StartDetonationDuration(float targetScale, float duration)
    {
      _detonationRadius.DOScale(new Vector3(targetScale, targetScale, targetScale), duration)
          .SetEase(Ease.InOutQuad);
    }
  }
}