using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderValueUpdater : MonoBehaviour
{
  public Slider Slider;
  [FormerlySerializedAs("Health")] public EnemyHealth enemyHealth;
  public float SliderUpdateSpeed;

  private void Update()
  {
    float value = (float)enemyHealth.Current.Value / enemyHealth.Initial;

    if (Math.Abs(Slider.value - value) > 0.01f)
    {
      Slider.value = Mathf.MoveTowards(Slider.value, value, Time.deltaTime * SliderUpdateSpeed);
    }
  }
}