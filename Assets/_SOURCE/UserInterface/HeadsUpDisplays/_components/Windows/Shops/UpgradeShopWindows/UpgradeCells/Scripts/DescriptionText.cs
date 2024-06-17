using Gameplay.Characters.Players;
using Gameplay.Stats;
using Gameplay.Upgrades;
using Infrastructure.ArtConfigServices;
using Infrastructure.ConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows.UpgradeCells.Scripts
{
  public class DescriptionText : MonoBehaviour
  {
    public UpgradeCell UpgradeCell;
    public TextMeshProUGUI DescriptionTextUI;

    [Inject] private UpgradeService _upgradeService;
    [Inject] private ConfigProvider _configProvider;
    [Inject] private ArtConfigProvider _artConfigProvider;
    [Inject] private PlayerStatsProvider _playerStatsProvider;

    private UpgradeConfig Config => UpgradeCell.UpgradeConfig;
    private StatId Id => Config.Id;
    private Upgrade Upgrade => _upgradeService.GetUpgrade(Id);
    private UpgradeContentSetup UpgradeContentSetup => _artConfigProvider.GetUpgradeContentSetup(Id);

    private void Start()
    {
      UpdateText();

      _upgradeService.Changed += UpdateText;
    }

    private void OnDestroy()
    {
      _upgradeService.Changed -= UpdateText;
    }

    private void UpdateText()
    {
      if (Upgrade.IsMaxLevel)
      {
        DescriptionTextUI.text = $"{UpgradeContentSetup.Description} MAX";
        return;
      }

      int currentLevel =
        _upgradeService
          .GetUpgrade(Config.Id)
          .Level
          .Value;

      float currentValue =
        _playerStatsProvider
          .GetStat(Id);

      int nextValue =
        _configProvider
          .GetUpgradeConfig(Config.Id)
          .Values[currentLevel + 1]
          .Value;

      string description = UpgradeContentSetup.Description;

      DescriptionTextUI.text = $"{description} from {currentValue} to {currentValue + nextValue}";
    }
  }
}