using Infrastructure.SceneLoaders;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Scenes._Infrastructure.Scripts.LoadConfig
{
  public class LoadConfigsInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private IStaticDataService _staticDataService;

    public void Initialize()
    {
      _staticDataService.LoadConfigs();

      _sceneLoader.Load(SceneId.LoadProgress);
    }
  }
}