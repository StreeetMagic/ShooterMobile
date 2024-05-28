using Infrastructure.DebugServices;
using Infrastructure.Games;
using Infrastructure.SceneLoaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.DebugWindows
{
  public class ChangeGameModeButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private SceneLoader _sceneLoader;

    private void Start()
    {
      Button.onClick.AddListener(ChangeGameMode);
    }

    private void ChangeGameMode()
    {
      _sceneLoader.Load(ProjectConstants.Scenes.ChooseGameMode);
    }
  }
}