using System;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SliderValueUpdater : MonoBehaviour
{
  public Slider Slider;
  public float SliderUpdateSpeed;
  
  private EnemyComponentsProvider _componentsProvider;
  
  [Inject]
  public void Construct(EnemyComponentsProvider componentsProvider)
  {
    _componentsProvider = componentsProvider;
  }
  
  private EnemyHealth EnemyHealth => _componentsProvider.Health;

  private void Update()
  {
    float value = (float)EnemyHealth.Current.Value / EnemyHealth.Initial;

    if (Math.Abs(Slider.value - value) > 0.01f)
    {
      Slider.value = Mathf.MoveTowards(Slider.value, value, Time.deltaTime * SliderUpdateSpeed);
    }
  }
}