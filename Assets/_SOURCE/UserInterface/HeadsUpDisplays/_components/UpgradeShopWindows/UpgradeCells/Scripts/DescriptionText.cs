using Configs.Resources.Upgrades;
using Gameplay.Upgrades;
using Infrastructure.PersistentProgresses;
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

    private void Start()
    {
      UpdateText();
    }

    private void UpdateText()
    {
      int currentLevel =
        _upgradeService
          .ForUpgrade(Config.Id)
          .Level
          .Value;

      int currentValue =
        _staticDataService
          .ForUpgradeConfig(Config.Id)
          .Values[currentLevel]
          .Value;

      int nextValue = currentValue + 1;

      string description = Config.Description;

      DescriptionTextUI.text = $"{description} from {currentValue} to {nextValue}";
    }
  }
}