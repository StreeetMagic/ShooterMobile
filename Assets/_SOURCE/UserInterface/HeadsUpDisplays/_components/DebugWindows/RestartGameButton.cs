using Infrastructure.DebugServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.DebugWindows
{
  public class RestartGameButton : MonoBehaviour
  {
    public Button Button;

    private DebugService _debugService;

    [Inject]
    private void Construct(DebugService debugService)
    {
      _debugService = debugService;
    }

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