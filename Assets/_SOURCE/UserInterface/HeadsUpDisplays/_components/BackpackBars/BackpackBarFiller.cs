using System;
using System.Collections.Generic;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Infrastructure.DataRepositories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
    float max = _playerStatsProvider.BackpackCapacity.Value;
    float current = _backpackStorage.Volume;
    Slider.value = Mathf.MoveTowards(Slider.value, current / max, Time.deltaTime * SliderUpdateSpeed);
  }
}