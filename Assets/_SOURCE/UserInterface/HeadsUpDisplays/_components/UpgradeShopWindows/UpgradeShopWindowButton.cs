using System.Collections.Generic;
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

    private List<GameObject> _otherStuff = new List<GameObject>();

    private WindowService _windowService;
    private HeadsUpDisplayProvider _headsUpDisplayProvider;
    private SaveLoadService _saveLoadService;

    [Inject]
    public void Construct(WindowService windowService, HeadsUpDisplayProvider headsUpDisplayProvider, SaveLoadService saveLoadService)
    {
      _windowService = windowService;
      _headsUpDisplayProvider = headsUpDisplayProvider;
      _saveLoadService = saveLoadService;
    }

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