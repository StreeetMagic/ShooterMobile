using Gameplay.Characters.Players;
using Gameplay.Stats;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.HealthBars
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
      float max = _playerStatsProvider.GetStat(StatId.Health).Value;
      float current = _playerProvider.Instance.Health.Current.Value;
      Slider.value = Mathf.MoveTowards(Slider.value, current / max, Time.deltaTime * SliderUpdateSpeed);
    }
  }
}