using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories.GameobjectContext
{
  public class PlayerZenjectFactory : ZenjectFactory, IGameObjectZenjectFactory
  {
    public PlayerZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator, ArtConfigProvider artConfigProvider) : base(assetProvider, instantiator, artConfigProvider)
    {
    }
  }
}