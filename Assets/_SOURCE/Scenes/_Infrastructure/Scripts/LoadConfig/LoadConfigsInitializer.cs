using Infrastructure.ArtConfigServices;
using Infrastructure.ConfigServices;
using Infrastructure.SceneLoaders;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Scenes._Infrastructure.Scripts.LoadConfig
{
  public class LoadConfigsInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private ConfigService _configService;
    [Inject] private ArtConfigService _artConfigService;
    [Inject] private VisualEffectService _visualEffectService;

    public void Initialize()
    {
      _configService.LoadConfigs();
      _artConfigService.LoadConfigs();
      
      _visualEffectService.LoadPrefabs();

      _sceneLoader.Load(SceneId.LoadProgress);
    }
  }
}