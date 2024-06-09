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
    [Inject] private ProjectData _projectData;

    private void Start()
    {
      Button.onClick.AddListener(() =>
      {
        _projectData.GameMode = GameMode.SimeonTest;
        _sceneLoader.Load(ProjectConstants.Scenes.LoadConfigs);
      });
    }
  }
}