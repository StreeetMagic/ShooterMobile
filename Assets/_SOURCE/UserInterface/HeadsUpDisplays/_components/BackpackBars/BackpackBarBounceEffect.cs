using DG.Tweening;
using UnityEngine;

public class BackpackBarBounceEffect : MonoBehaviour
{
  public RectTransform slider;
  public float bounceStrength = 0.3f;
  public float bounceSpeed = 0.1f;

  public void ApplyBounceEffect()
  {
    slider.transform
      .DOPunchScale(Vector3.one * bounceStrength, bounceSpeed, vibrato: 1, elasticity: 0)
      .SetEase(Ease.Linear)
      .OnComplete(() => slider.transform.localScale = Vector3.one);
  }
}