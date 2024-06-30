using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Characters.Enemies._components.ActorUserInterfaces
{
  public class SliderValueUpdater : MonoBehaviour
  {
    public Slider Slider;
    public Slider WhiteSlider;
    public float SliderUpdateSpeed;
    public float WhiteSliderUpdateSpeed;

    [Inject] private IHealth _enemyHealth;

    private void Update()
    {
      float value = _enemyHealth.Current.Value / _enemyHealth.Initial;

      if (Math.Abs(Slider.value - value) > 0.01f)
      {
        Slider.value = Mathf.MoveTowards(Slider.value, value, Time.deltaTime * SliderUpdateSpeed);
      }

      if (Math.Abs(WhiteSlider.value - value) > 0.01f)
      {
        WhiteSlider.value = Mathf.MoveTowards(WhiteSlider.value, value, Time.deltaTime * WhiteSliderUpdateSpeed);
      }
    }
  }
}