using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories.GameobjectContext
{
  public class PlayerZenjectFactory : ZenjectFactory, IGameObjectZenjectFactory
  {
    public PlayerZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}