using DebugServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.DebugWindows
{
  public class RestartGameButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private DebugService _debugService;

    private void Start()
    {
      Button.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
      _debugService.Restart();
    }
  }
}