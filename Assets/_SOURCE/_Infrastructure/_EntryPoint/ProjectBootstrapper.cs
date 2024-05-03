using Infrastructure.Games;
using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

public class ProjectBootstrapper : MonoBehaviour
{
  [Inject] private SceneLoader _sceneLoader;
  
  public void Start()
  {
    _sceneLoader.Load(ProjectConstants.Scenes.LoadConfigs);
  }
}
