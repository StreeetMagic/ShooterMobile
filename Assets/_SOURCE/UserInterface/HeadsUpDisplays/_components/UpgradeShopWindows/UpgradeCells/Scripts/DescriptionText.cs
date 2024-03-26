using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Upgrades;
using Infrastructure.StaticDataServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells.Scripts
{
  public class DescriptionText : MonoBehaviour
  {
    public UpgradeCell UpgradeCell;
    public TextMeshProUGUI DescriptionTextUI;

    private UpgradeService _upgradeService;
    private IStaticDataService _staticDataService;
    private PlayerStatsProvider _playerStatsProvider;

    [Inject]
    public void Construct(UpgradeService upgradeService, IStaticDataService staticDataService, PlayerStatsProvider playerStatsProvider)
    {
      _upgradeService = upgradeService;
      _staticDataService = staticDataService;
      _playerStatsProvider = playerStatsProvider;
    }

    private UpgradeConfig Config => UpgradeCell.UpgradeConfig;
    private StatId Id => Config.Id;
    private Upgrade Upgrade => _upgradeService.GetUpgrade(Id);

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
        DescriptionTextUI.text = $"{Config.Description} MAX";
        return;
      }

      int currentLevel =
        _upgradeService
          .GetUpgrade(Config.Id)
          .Level
          .Value;

      int currentValue =
        _playerStatsProvider
          .GetStat(Id)
          .Value;

      int nextValue =
        _staticDataService
          .GetUpgradeConfig(Config.Id)
          .Values[currentLevel + 1]
          .Value;

      string description = Config.Description;

      DescriptionTextUI.text = $"{description} from {currentValue} to {currentValue + nextValue}";
    }
  }
}