using Projects;
using SceneLoaders;
using Scenes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneInstallers.ChooseGameMode.Buttons
{
  public class VladTestButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private SceneLoader _sceneLoader;
    [Inject] private ProjectData _projectData;

    private void Start()
    {
      Button.onClick.AddListener(() =>
      {
        _projectData.GameMode = GameMode.VladTest;
        _projectData.SceneId = SceneId.VladTestScene;
        
        _sceneLoader.Load(SceneId.LoadConfigs.ToString());
      });
    }
  }
}