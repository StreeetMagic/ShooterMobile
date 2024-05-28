using _Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace _Infrastructure.ZenjectFactories
{
  public class GameLoopZenjectFactory : ZenjectFactory
  {
    public GameLoopZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}