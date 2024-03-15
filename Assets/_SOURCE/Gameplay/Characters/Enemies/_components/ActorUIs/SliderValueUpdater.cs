using Gameplay.Characters.Healths;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueUpdater : MonoBehaviour
{
  public Slider Slider;
  public Health Health;

  private void OnEnable()
  {
    Health.Current.ValueChanged += OnHealthChanged;
  }

  private void OnDisable()
  {
    Health.Current.ValueChanged -= OnHealthChanged;
  }

  private void OnHealthChanged(int health)
  {
    Slider.value = (float)health / Health.Initial;
  }
}