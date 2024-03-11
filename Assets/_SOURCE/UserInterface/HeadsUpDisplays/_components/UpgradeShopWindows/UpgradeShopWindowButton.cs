using System.Collections.Generic;
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

    [Inject]
    public void Construct(WindowFactory windowFactory)
    {
      _windowFactory = windowFactory;
    }

    private void Awake()
    {
      _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
      _windowFactory.Create(WindowId.UpgradeShop);
    }
  }
}