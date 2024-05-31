using Projects;
using SceneLoaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneInstallers.ChooseGameMode.Buttons
{
  public class SimeonButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private SceneLoader _sceneLoader;

    private void Start()
    {
      Button.onClick.AddListener(() => { _sceneLoader.Load(ProjectConstants.Scenes.SimeonTestScene); });
    }
  }
}