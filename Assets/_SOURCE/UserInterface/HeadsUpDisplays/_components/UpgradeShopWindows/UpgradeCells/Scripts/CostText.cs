
using Configs.Resources.Upgrades;
using Gameplay.Upgrades;
using Infrastructure.StaticDataServices;
using TMPro;
using UnityEngine;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells;
using Zenject;

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

        int nextLevel = currentLevel + 1;

        int nextLevelCost =
            _staticDataService
                .ForUpgradeConfig(Config.Id)
                .Values[nextLevel]
                .Cost;
        
        CostTextUI.text = $"{nextLevelCost}";
    }
}
