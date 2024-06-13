using Infrastructure.ArtConfigServices;
using Infrastructure.ConfigServices;
using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

namespace Scenes._Infrastructure.Scripts.LoadConfig
{
  public class LoadConfigsInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private ConfigService _configService;
    [Inject] private ArtConfigService _artConfigService;

    public void Initialize()
    {
      _configService.LoadConfigs();
      _artConfigService.LoadConfigs();

      _sceneLoader.Load(SceneId.LoadProgress);
    }
  }
}