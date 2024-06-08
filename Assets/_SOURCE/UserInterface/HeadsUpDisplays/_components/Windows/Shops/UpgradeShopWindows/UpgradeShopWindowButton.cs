using SaveLoadServices;
using UnityEngine;
using UnityEngine.UI;
using UserIntefaces;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows
{
  public class UpgradeShopWindowButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    [Inject] private WindowService _windowService;
    [Inject] private SaveLoadService _saveLoadService;

    private void Awake()
    {
      _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
      _windowService.Create(WindowId.UpgradeShop);
      _saveLoadService.SaveProgress();
    }
  }
}