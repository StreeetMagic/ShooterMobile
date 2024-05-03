using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.DebugWindows.DebugButtons
{
  public class DebugButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private WindowService _windowService;

    private void Start()
    {
      Button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
      _windowService.Create(WindowId.Debug);
    }
  }
}