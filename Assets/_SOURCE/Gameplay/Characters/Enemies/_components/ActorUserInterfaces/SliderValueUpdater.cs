using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueUpdater : MonoBehaviour
{
  public Slider Slider;
  public Health Health;
  public float SliderUpdateSpeed;

  private void Update()
  {
    float value = (float)Health.Current.Value / Health.Initial;

    if (Math.Abs(Slider.value - value) > 0.01f)
    {
      Slider.value = Mathf.MoveTowards(Slider.value, value, Time.deltaTime * SliderUpdateSpeed);
    }
  }
}