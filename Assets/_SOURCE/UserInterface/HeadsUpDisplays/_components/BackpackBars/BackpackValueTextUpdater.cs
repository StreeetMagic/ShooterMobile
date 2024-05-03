using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.StatConfigs;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Players.PlayerStatsProviders;
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

    private void OnBackpackCapacityChanged(int obj)
    {
      DisplayText();
    }

    private void DisplayText()
    {
      int max = _playerStatsProvider.GetStat(StatId.BackpackCapacity).Value;
      int current = _backpackStorage.Volume;
      Text.text = $"{current}/{max}";
    }
  }
}