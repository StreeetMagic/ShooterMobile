using Infrastructure.Games;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

public class LoadProgressBootstrapper : MonoBehaviour
{
  [Inject] private SaveLoadService _saveLoadService;
  [Inject] private SceneLoader _sceneLoader;
  
  public void Awake()
  {
    _saveLoadService.LoadProgress();
    _sceneLoader.Load(ProjectConstants.Scenes.GameLoop);
  }
}