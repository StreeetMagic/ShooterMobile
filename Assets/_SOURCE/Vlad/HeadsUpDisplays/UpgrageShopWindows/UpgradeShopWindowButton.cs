using System;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Vlad.HeadsUpDisplays.UpgrageWindows
{
  public class UpgradeShopWindowButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    private WindowFactory _windowFactory;

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
      _windowFactory.Open(WindowId.UpgradeShop);
    }
  }
}