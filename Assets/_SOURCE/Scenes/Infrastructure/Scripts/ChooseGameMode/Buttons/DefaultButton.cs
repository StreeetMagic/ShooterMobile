using Projects;
using SceneLoaders;
using Scenes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneInstallers.ChooseGameMode.Buttons
{
  public class DefaultButton : MonoBehaviour
  {
    public Button Button;

    [Inject] private SceneLoader _sceneLoader;
    [Inject] private ProjectData _projectData;

    private void Start()
    {
      Button.onClick.AddListener(() =>
      {
        _projectData.GameMode = GameMode.Default;
        _projectData.SceneId = SceneId.CoreDust;
        
        _sceneLoader.Load(SceneId.LoadConfigs.ToString());
      });
    }
  }
}