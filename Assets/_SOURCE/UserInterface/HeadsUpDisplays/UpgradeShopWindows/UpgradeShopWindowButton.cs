using CodeBase.UI.Services.Windows;
using Infrastructure.SaveLoadServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Vlad.HeadsUpDisplays.UpgrageWindows
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