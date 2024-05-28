using UnityEngine;
using UnityEngine.UI;
using UserIntefaces;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Buttons.SettingsButtons
{
  public class OpenSettingsWindowButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private WindowService _windowService;

    private void Awake()
    {
      Button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
      _windowService.Create(WindowId.Settings);
    }
  }
}