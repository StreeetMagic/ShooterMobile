using Projects;
using SceneLoaders;
using Scenes;
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

      _sceneLoader.Load(SceneId.LoadProgress.ToString());
    }
  }
}