using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories.SceneContext
{
  public class GameLoopZenjectFactory : ZenjectFactory
  {
    public GameLoopZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator, ArtConfigProvider artConfigProvider) : base(assetProvider, instantiator, artConfigProvider)
    {
    }
  }
}