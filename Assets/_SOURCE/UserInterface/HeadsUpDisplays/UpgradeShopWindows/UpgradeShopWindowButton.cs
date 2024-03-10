using Infrastructure.SaveLoadServices;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.UpgradeShopWindows
{
  public class UpgradeShopWindowButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    private WindowFactory _windowFactory;
    private SaveLoadService _saveLoadService;

    [Inject]
    public void Construct(WindowFactory windowFactory, SaveLoadService saveLoadService)
    {
      _windowFactory = windowFactory;
      _saveLoadService = saveLoadService;
    }

    private void Awake()
    {
      _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
      _windowFactory.Create(WindowId.UpgradeShop);
      _saveLoadService.SaveProgress();
    }
  }
}