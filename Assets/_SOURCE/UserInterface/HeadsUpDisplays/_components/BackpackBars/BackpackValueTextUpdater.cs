using System.Collections.Generic;
using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.Loots;
using Gameplay.Stats;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.BackpackBars
{
  public class BackpackValueTextUpdater : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private BackpackStorage _backpackStorage;

    private void OnEnable()
    {
      DisplayText();
      _playerStatsProvider.GetStat(StatId.BackpackCapacity).ValueChanged += OnBackpackCapacityChanged;
      _backpackStorage.LootDrops.Changed += OnLootDropsChanged;
    }

    private void OnDisable()
    {
      _playerStatsProvider.GetStat(StatId.BackpackCapacity).ValueChanged -= OnBackpackCapacityChanged;
      _backpackStorage.LootDrops.Changed -= OnLootDropsChanged;
    }

    private void OnLootDropsChanged(List<LootDrop> obj)
    {
      DisplayText();
    }

    private void OnBackpackCapacityChanged(float obj)
    {
      DisplayText();
    }

    private void DisplayText()
    {
      float max = _playerStatsProvider.GetStat(StatId.BackpackCapacity).Value;
      int current = _backpackStorage.Volume;
      Text.text = $"{current}/{max}";
    }
  }
}