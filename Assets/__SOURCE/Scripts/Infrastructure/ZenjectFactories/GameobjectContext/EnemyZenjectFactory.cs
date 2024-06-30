using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories.GameobjectContext
{
  public class EnemyZenjectFactory : ZenjectFactory, IGameObjectZenjectFactory
  {
    public EnemyZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator, ArtConfigProvider artConfigProvider) : base(assetProvider, instantiator, artConfigProvider)
    {
    }
  }
}