using System.Collections.Generic;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Infrastructure.DataRepositories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BackpackBarFiller : MonoBehaviour
{
  public Slider Slider;

  private PlayerStatsProvider _playerStatsProvider;
  private BackpackStorage _backpackStorage;

  [Inject]
  private void Construct(PlayerStatsProvider playerStatsProvider, BackpackStorage backpackStorage)
  {
    _playerStatsProvider = playerStatsProvider;
    _backpackStorage = backpackStorage;
  }

  private void OnEnable()
  {
    FillBar();
    _playerStatsProvider.BackpackCapacity.ValueChanged += OnBackpackCapacityChanged;
    _backpackStorage.LootDrops.Changed += OnLootDropsChanged;
  }

  private void OnDisable()
  {
    _playerStatsProvider.BackpackCapacity.ValueChanged -= OnBackpackCapacityChanged;
    _backpackStorage.LootDrops.Changed -= OnLootDropsChanged;
  }

  private void OnLootDropsChanged(List<LootDrop> obj)
  {
    FillBar();
  }

  private void OnBackpackCapacityChanged(int obj)
  {
    FillBar();
  }

  private void FillBar()
  {
    float max = _playerStatsProvider.BackpackCapacity.Value;
    float current = _backpackStorage.Volume;
    Slider.value = current / max;
  }
}