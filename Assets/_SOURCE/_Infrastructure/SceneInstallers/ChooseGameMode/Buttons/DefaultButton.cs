using _Infrastructure.Projects;
using _Infrastructure.SceneLoaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Infrastructure.SceneInstallers.ChooseGameMode.Buttons
{
  public class DefaultButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private SceneLoader _sceneLoader;

    private void Start()
    {
      Button.onClick.AddListener(() => { _sceneLoader.Load(ProjectConstants.Scenes.GameLoop); });
    }
  }
}