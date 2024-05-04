using Configs.Resources.UpgradeConfigs.Scripts;
using Infrastructure.Upgrades;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells.Scripts
{
  public class LevelText : MonoBehaviour
  {
    public UpgradeCell UpgradeCell;
    public TextMeshProUGUI LevelTextUI;

    [Inject] private UpgradeService _upgradeService;

    private UpgradeConfig Config => UpgradeCell.UpgradeConfig;

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
      int currentLevel = _upgradeService.GetUpgrade(Config.Id).Level.Value;
      int nextLevel = currentLevel + 1;

      int maxLevel = Config.Values[^1].Level;

      LevelTextUI.text = $"LEVEL {nextLevel}/{maxLevel}";

      if (currentLevel == maxLevel)
        LevelTextUI.text = "MAX";
    }
  }
}