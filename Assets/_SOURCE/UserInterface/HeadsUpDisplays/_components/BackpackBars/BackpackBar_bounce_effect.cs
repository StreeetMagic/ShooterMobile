using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackpackBar_bounce_effect : MonoBehaviour
{
    public RectTransform slider; // ссылка на объект слайдера
    public float bounceStrength = 0.3f; // сила баунса
    public float bounceSpeed = 0.1f; // скорость баунса

    public void ApplyBounceEffect()
    {
        slider.transform
            .DOPunchScale(Vector3.one * bounceStrength, bounceSpeed, vibrato: 1, elasticity: 0)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
                slider.transform.DOPunchScale(-Vector3.one * bounceStrength, bounceSpeed, vibrato: 1, elasticity: 0));
    }
}