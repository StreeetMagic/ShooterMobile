using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Buttons.OpenShopButtons
{
  public class OpenShopButton : MonoBehaviour
  {
    public Button Button;
    public RectTransform RectTransform;
    
    public WindowId WindowId { get; set; } = WindowId.Unknown;

    [Inject] private WindowService _windowService;

    private void Awake()
    {
      Button.onClick.AddListener(OpenShop);
    }

    private void OpenShop()
    {
      if (WindowId == WindowId.Unknown)
        throw new System.Exception("WindowId is unknown");

      _windowService.Create(WindowId);
    }
  }
}