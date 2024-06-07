using Gameplay.Characters.Players;
using Gameplay.Stats;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.HealthBars._components
{
  public class HealthBarSlider : MonoBehaviour
  {
    public Slider Slider;
    public float SliderUpdateSpeed;

    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private PlayerProvider _playerProvider;

    private PlayerHealth PlayerHealth => _playerProvider.PlayerHealth;

    private void Update()
    {
      if (PlayerHealth == null)
        return;
    
      UpdateSlider();
    }

    private void UpdateSlider()
    {
      float max = _playerStatsProvider.GetStat(StatId.Health).Value;
      float current = PlayerHealth.Current.Value;
      Slider.value = Mathf.MoveTowards(Slider.value, current / max, Time.deltaTime * SliderUpdateSpeed);
    }
  }
}