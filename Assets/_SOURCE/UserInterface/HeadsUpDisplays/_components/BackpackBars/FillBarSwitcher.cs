using System;
using System.Collections.Generic;
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
        
        _playerStatsProvider.BackpackCapacity.ValueChanged += OnBackpackCapacityChanged;
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
        bool isFull = _backpackStorage.Volume >= _playerStatsProvider.BackpackCapacity.Value;
        FullBar.SetActive(isFull);
        NotFullBar.SetActive(!isFull);
    }
}
