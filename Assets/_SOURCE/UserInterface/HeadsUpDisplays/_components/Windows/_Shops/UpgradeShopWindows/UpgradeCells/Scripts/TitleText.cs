using Gameplay.Upgrades;
using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.Windows._Shops.UpgradeShopWindows.UpgradeCells.Scripts
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