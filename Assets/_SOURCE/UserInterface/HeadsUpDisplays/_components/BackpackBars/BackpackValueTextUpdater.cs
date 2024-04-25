using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.StatConfigs;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Players._components.PlayerStatsProviders;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.BackpackBars
{
  public class BackpackValueTextUpdater : MonoBehaviour
  {
    public TextMeshProUGUI Text;

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