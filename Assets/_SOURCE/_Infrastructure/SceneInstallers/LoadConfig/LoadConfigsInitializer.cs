using Projects;
using SceneLoaders;
using StaticDataServices;
using UnityEngine;
using Zenject;

namespace SceneInstallers.LoadConfig
{
  public class LoadConfigsInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private IStaticDataService _staticDataService;

    public void Initialize()
    {
      _staticDataService.LoadConfigs();
      _sceneLoader.Load(ProjectConstants.Scenes.LoadProgress);
    }
  }
}