using Gameplay.Characters.Healths;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueUpdater : MonoBehaviour
{
  public Slider Slider;
  public Health Health;

  private void OnEnable()
  {
    Health.HealthChanged += OnHealthChanged;
  }
  
  private void OnDisable()
  {
    Health.HealthChanged -= OnHealthChanged;
  }

  private void OnHealthChanged(float health)
  {
    Slider.value = health / Health.Initial;
  }
}