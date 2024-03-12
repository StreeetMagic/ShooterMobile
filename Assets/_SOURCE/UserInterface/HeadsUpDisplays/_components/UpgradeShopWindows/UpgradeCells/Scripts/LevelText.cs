using Configs.Resources.Upgrades;
using Gameplay.Upgrades;
using Infrastructure.PersistentProgresses;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells.Scripts
{
  public class LevelText : MonoBehaviour
  {
    public UpgradeCell UpgradeCell;
    public TextMeshProUGUI LevelTextUI;

    private UpgradeService _upgradeService;

    [Inject]
    public void Construct(PersistentProgressService progressService, UpgradeService upgradeService)
    {
      _upgradeService = upgradeService;
    }

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