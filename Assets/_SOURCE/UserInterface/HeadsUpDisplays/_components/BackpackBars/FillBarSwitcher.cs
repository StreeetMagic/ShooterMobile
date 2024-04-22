using System;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Infrastructure.DataRepositories;
using UnityEngine;
using Zenject;

public class FillBarSwitcher : MonoBehaviour
{
  public GameObject NotFullBar;
  public GameObject FullBar;

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
    Setup();

    _playerStatsProvider.GetStat(StatId.BackpackCapacity).ValueChanged += OnBackpackCapacityChanged;
    _backpackStorage.LootDrops.Changed += OnLootDropsChanged;
  }

  private void OnLootDropsChanged(List<LootDrop> obj)
  {
    Setup();
  }

  private void OnBackpackCapacityChanged(int obj)
  {
    Setup();
  }

  private void Setup()
  {
    bool isFull = _backpackStorage.Volume >= _playerStatsProvider.GetStat(StatId.BackpackCapacity).Value;

    if (FullBar == null || NotFullBar == null)
      return;

    FullBar.SetActive(isFull);
    NotFullBar.SetActive(!isFull);
  }
}