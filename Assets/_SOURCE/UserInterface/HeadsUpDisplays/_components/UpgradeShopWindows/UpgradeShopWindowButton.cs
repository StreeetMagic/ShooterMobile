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

    private WindowFactory _windowFactory;
    private HeadsUpDisplayProvider _headsUpDisplayProvider;
    private SaveLoadService _saveLoadService;

    [Inject]
    public void Construct(WindowFactory windowFactory, HeadsUpDisplayProvider headsUpDisplayProvider, SaveLoadService saveLoadService)
    {
      _windowFactory = windowFactory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
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