using System.Collections.Generic;
using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.Loots;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.BackpackBars
{
  public class FillBarSwitcher : MonoBehaviour
  {
    public GameObject NotFullBar;
    public GameObject FullBar;
    public GameObject Text;

    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private BackpackStorage _backpackStorage;

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

    private void OnBackpackCapacityChanged(float obj)
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
      Text.SetActive(!isFull);
    }
  }
}