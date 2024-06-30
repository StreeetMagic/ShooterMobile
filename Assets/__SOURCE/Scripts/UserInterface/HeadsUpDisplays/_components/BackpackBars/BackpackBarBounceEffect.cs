using DG.Tweening;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays._components.BackpackBars
{
  public class BackpackBarBounceEffect : MonoBehaviour
  {
    public RectTransform slider;
    public float bounceStrength = 0.3f;
    public float bounceSpeed = 0.1f;
    
    private bool isAnimating = false;

    public void ApplyBounceEffect()
    {
      if (isAnimating)
      {
        return;
      }

      isAnimating = true;

      slider.transform
        .DOPunchScale(Vector3.one * bounceStrength, bounceSpeed, vibrato: 1, elasticity: 0)
        .SetEase(Ease.OutQuad)
        .OnComplete(() =>
        {
          slider.transform.localScale = Vector3.one;
          isAnimating = false;
        });
    }
  }
}