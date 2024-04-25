using Configs.Resources.UpgradeConfigs.Scripts;
using Infrastructure.StaticDataServices;
using Infrastructure.Upgrades;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells.Scripts
{
  public class CostText : MonoBehaviour
  {
    public UpgradeCell UpgradeCell;
    public TextMeshProUGUI CostTextUI;

    private UpgradeService _upgradeService;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(UpgradeService upgradeService, IStaticDataService staticDataService)
    {
      _upgradeService = upgradeService;
      _staticDataService = staticDataService;
    }

    private UpgradeConfig Config => UpgradeCell.UpgradeConfig;
    private Upgrade Upgrade => _upgradeService.GetUpgrade(Config.Id);

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
        CostTextUI.text = "MAX";
      else
        PrintText();
    }

    private void PrintText()
    {
      int nextLevelCost = NextLevelCost(CurrentLevel() + 1);
      CostTextUI.text = $"{nextLevelCost}";
    }

    private int NextLevelCost(int nextLevel)
    {
      if (Upgrade.IsMaxLevel)
      {
        return _staticDataService
          .GetUpgradeConfig(Config.Id)
          .Values[nextLevel - 1]
          .Cost;
      }
      else
      {
        return _staticDataService
          .GetUpgradeConfig(Config.Id)
          .Values[nextLevel]
          .Cost;
      }
    }

    private int CurrentLevel() =>
      Upgrade
        .Level
        .Value;
  }
}