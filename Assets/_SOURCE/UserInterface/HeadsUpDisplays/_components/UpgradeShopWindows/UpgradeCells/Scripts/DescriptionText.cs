using Configs.Resources.UpgradeConfigs.Scripts;
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

    [Inject]
    public void Construct(UpgradeService upgradeService, IStaticDataService staticDataService)
    {
      _upgradeService = upgradeService;
      _staticDataService = staticDataService;
    }

    private UpgradeConfig Config => UpgradeCell.UpgradeConfig;
    private UpgradeId Id => Config.Id;
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
        _staticDataService
          .ForUpgradeConfig(Config.Id)
          .Values[currentLevel]
          .Value;

      int nextValue =
        _staticDataService
          .ForUpgradeConfig(Config.Id)
          .Values[currentLevel + 1]
          .Value;

      string description = Config.Description;

      DescriptionTextUI.text = $"{description} from {currentValue} to {nextValue}";
    }
  }
}