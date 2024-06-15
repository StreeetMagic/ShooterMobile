using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories.GameobjectContext
{
  public class EnemyZenjectFactory : ZenjectFactory
  {
    public EnemyZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}