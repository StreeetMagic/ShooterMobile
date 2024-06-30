using System.Collections.Generic;
using Characters.Players._components;
using CurrencyRepositories.BackpackStorages;
using Loots;
using Stats;
using TMPro;
using UnityEngine;
using Upgrades;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.BackpackBars
{
  public class BackpackValueTextUpdater : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private UpgradeService _upgradeService;

    private void OnEnable()
    {
      DisplayText();

      _backpackStorage.LootDrops.Changed += OnLootDropsChanged;
      _upgradeService.Changed += OnUpgradeChanged;
    }

    private void OnDisable()
    {
      _backpackStorage.LootDrops.Changed -= OnLootDropsChanged;
      _upgradeService.Changed -= OnUpgradeChanged;
    }

    private void OnLootDropsChanged(List<LootDrop> list = null)
    {
      DisplayText();
    }
    
    private void OnUpgradeChanged()
    {
      DisplayText();
    }

    private void DisplayText()
    {
      float max = _playerStatsProvider.GetStat(StatId.BackpackCapacity);
      int current = _backpackStorage.Volume;
      Text.text = $"{current}/{max}";
    }
  }
}