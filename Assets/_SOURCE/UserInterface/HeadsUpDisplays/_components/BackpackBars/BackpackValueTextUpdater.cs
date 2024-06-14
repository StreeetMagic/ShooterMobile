using System.Collections.Generic;
using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.Loots;
using Gameplay.Stats;
using Gameplay.Upgrades;
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