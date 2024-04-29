using Configs.Resources.StatConfigs;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Players.PlayerStatsProviders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.BackpackBars
{
  public class BackpackBarFiller : MonoBehaviour
  {
    public Slider Slider;
    public float SliderUpdateSpeed;

    private PlayerStatsProvider _playerStatsProvider;
    private BackpackStorage _backpackStorage;

    [Inject]
    private void Construct(PlayerStatsProvider playerStatsProvider, BackpackStorage backpackStorage)
    {
      _playerStatsProvider = playerStatsProvider;
      _backpackStorage = backpackStorage;
    }

    private void Update()
    {
      UpdateSlider();
    }

    private void UpdateSlider()
    {
      float max = _playerStatsProvider.GetStat(StatId.BackpackCapacity).Value;
      float current = _backpackStorage.Volume;
      Slider.value = Mathf.MoveTowards(Slider.value, current / max, Time.deltaTime * SliderUpdateSpeed);
    }
  }
}