using Characters.Players;
using Characters.Players._components;
using Stats;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.Bars.HealthBars._components
{
  public class HealthBarSlider : MonoBehaviour
  {
    public Slider Slider;
    public float SliderUpdateSpeed;

    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private PlayerProvider _playerProvider;

    private void Update()
    {
      if (_playerProvider.Instance == null)
        return;
    
      UpdateSlider();
    }

    private void UpdateSlider()
    {
      float max = _playerStatsProvider.GetStat(StatId.Health);
      float current = _playerProvider.Instance.Health.Current.Value;
      Slider.value = Mathf.MoveTowards(Slider.value, current / max, Time.deltaTime * SliderUpdateSpeed);
    }
  }
}