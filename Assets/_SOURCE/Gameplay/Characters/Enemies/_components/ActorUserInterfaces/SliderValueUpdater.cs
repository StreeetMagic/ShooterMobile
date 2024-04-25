using System;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces
{
  public class SliderValueUpdater : MonoBehaviour
  {
    public Slider Slider;
    public float SliderUpdateSpeed;

    private EnemyHealth _enemyHealth;
  
    [Inject]
    private void Construct(EnemyHealth enemyHealth)
    {
      _enemyHealth = enemyHealth;
    }

    private void Update()
    {
      float value = (float)_enemyHealth.Current.Value / _enemyHealth.Initial;

      if (Math.Abs(Slider.value - value) > 0.01f)
      {
        Slider.value = Mathf.MoveTowards(Slider.value, value, Time.deltaTime * SliderUpdateSpeed);
      }
    }
  }
}