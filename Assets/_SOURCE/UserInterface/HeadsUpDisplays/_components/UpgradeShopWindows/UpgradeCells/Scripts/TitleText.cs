using Configs.Resources.UpgradeConfigs.Scripts;
using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows.UpgradeCells.Scripts
{
  public class TitleText : MonoBehaviour
  {
    public UpgradeCell UpgradeCell;
    public TextMeshProUGUI Title;

    private UpgradeConfig Config => UpgradeCell.UpgradeConfig;

    private void Start()
    {
      Title.text = Config.Title;
    }
  }
}