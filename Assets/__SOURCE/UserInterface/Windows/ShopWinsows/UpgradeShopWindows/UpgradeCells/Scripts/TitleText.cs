using TMPro;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows.UpgradeCells.Scripts
{
  public class TitleText : MonoBehaviour
  {
    public UpgradeCell UpgradeCell;
    public TextMeshProUGUI Title;
    
    private void Start()
    {
      Title.text = UpgradeCell.UpgradeContentSetup.Title;
    }
  }
}