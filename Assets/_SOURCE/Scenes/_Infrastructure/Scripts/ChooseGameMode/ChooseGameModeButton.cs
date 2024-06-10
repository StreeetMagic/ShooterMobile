using Projects;
using SceneLoaders;
using Scenes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneInstallers.ChooseGameMode.Buttons
{
  public class ChooseGameModeButton : MonoBehaviour
  {
    public GameMode GameMode;
    public SceneId SceneId;

    [Inject] private SceneLoader _sceneLoader;
    [Inject] private ProjectData _projectData;
    private Button _button;

    private void Start()
    {
      _button = GetComponent<Button>();
      
      _button.onClick.AddListener(() =>
      {
        _projectData.GameMode = GameMode; 
        _projectData.InitialSceneId = SceneId; 
        
        _sceneLoader.Load(SceneId.LoadConfigs);
      });
    }
  }
}