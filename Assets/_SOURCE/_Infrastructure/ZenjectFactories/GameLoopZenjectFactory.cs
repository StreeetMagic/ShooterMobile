using AssetProviders;
using Zenject.Source.Main;

namespace ZenjectFactories
{
  public class GameLoopZenjectFactory : ZenjectFactory
  {
    public GameLoopZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}