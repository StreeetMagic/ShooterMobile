using Infrastructure.ArtConfigServices;
using Infrastructure.ConfigProviders;
using Infrastructure.SceneLoaders;
using Infrastructure.VisualEffects;
using Infrastructure.VisualEffects.ParticleImages;
using UnityEngine;
using Zenject;

namespace Scenes._Infrastructure.Scripts.LoadConfigs
{
  public class LoadConfigsInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;

    [Inject] private ConfigProvider _configProvider;
    [Inject] private ArtConfigProvider _artConfigProvider;

    [Inject] private VisualEffectProvider _visualEffectProvider;
    [Inject] private ParticleImageProvider _particleImageProvider;

    public void Initialize()
    {
      _configProvider.LoadConfigs();
      _artConfigProvider.LoadConfigs();

      _visualEffectProvider.LoadPrefabs();
      _particleImageProvider.LoadPrefabs();

      _sceneLoader.Load(SceneId.LoadProgress);
    }
  }
}