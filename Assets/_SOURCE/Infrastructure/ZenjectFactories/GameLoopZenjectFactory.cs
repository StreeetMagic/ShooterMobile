using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories
{
  public class GameLoopZenjectFactory : ZenjectFactory
  {
    public GameLoopZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}