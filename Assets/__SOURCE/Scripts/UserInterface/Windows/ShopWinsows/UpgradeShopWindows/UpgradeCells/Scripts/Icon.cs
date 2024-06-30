using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Windows.ShopWinsows.UpgradeShopWindows.UpgradeCells.Scripts
{
    public class Icon : MonoBehaviour
    {
        public Image Image;
    
        public void SetIcon(Sprite icon)
        {
            Image.sprite = icon;
        }
    }
}
